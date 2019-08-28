using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using Terraria.IO;
using Terraria.Localization;
using Terraria.Net;
using Terraria.Net.Sockets;
using Terraria.Social;
using Terraria.Utilities;

namespace Terraria
{
	// Token: 0x0200001C RID: 28
	public class Netplay
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600014A RID: 330 RVA: 0x00029FE8 File Offset: 0x000281E8
		// (remove) Token: 0x0600014B RID: 331 RVA: 0x0002A01C File Offset: 0x0002821C
		[method: CompilerGenerated]
		[CompilerGenerated]
		public static event Action OnDisconnect;

		// Token: 0x0600014C RID: 332 RVA: 0x0002A050 File Offset: 0x00028250
		private static void OpenPort()
		{
			Netplay.portForwardIP = Netplay.GetLocalIPAddress();
			Netplay.portForwardPort = Netplay.ListenPort;
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0002A068 File Offset: 0x00028268
		public static void closePort()
		{
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0002A06C File Offset: 0x0002826C
		public static string GetLocalIPAddress()
		{
			string result = "";
			IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
			for (int i = 0; i < addressList.Length; i++)
			{
				IPAddress iPAddress = addressList[i];
				if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
				{
					result = iPAddress.ToString();
					break;
				}
			}
			return result;
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0002A0B4 File Offset: 0x000282B4
		public static void ResetNetDiag()
		{
			Main.rxMsg = 0;
			Main.rxData = 0;
			Main.txMsg = 0;
			Main.txData = 0;
			for (int i = 0; i < Main.maxMsg; i++)
			{
				Main.rxMsgType[i] = 0;
				Main.rxDataType[i] = 0;
				Main.txMsgType[i] = 0;
				Main.txDataType[i] = 0;
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0002A10C File Offset: 0x0002830C
		public static void ResetSections()
		{
			for (int i = 0; i < 256; i++)
			{
				for (int j = 0; j < Main.maxSectionsX; j++)
				{
					for (int k = 0; k < Main.maxSectionsY; k++)
					{
						Netplay.Clients[i].TileSections[j, k] = false;
					}
				}
			}
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0002A160 File Offset: 0x00028360
		public static void AddBan(int plr)
		{
			RemoteAddress remoteAddress = Netplay.Clients[plr].Socket.GetRemoteAddress();
			using (StreamWriter streamWriter = new StreamWriter(Netplay.BanFilePath, true))
			{
				streamWriter.WriteLine("//" + Main.player[plr].name);
				streamWriter.WriteLine(remoteAddress.GetIdentifier());
			}
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0002A1D0 File Offset: 0x000283D0
		public static bool IsBanned(RemoteAddress address)
		{
			try
			{
				string identifier = address.GetIdentifier();
				if (File.Exists(Netplay.BanFilePath))
				{
					using (StreamReader streamReader = new StreamReader(Netplay.BanFilePath))
					{
						string a;
						while ((a = streamReader.ReadLine()) != null)
						{
							if (a == identifier)
							{
								return true;
							}
						}
					}
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0002A244 File Offset: 0x00028444
		public static void newRecent()
		{
			if (Netplay.Connection.Socket.GetRemoteAddress().Type != AddressType.Tcp)
			{
				return;
			}
			for (int i = 0; i < Main.maxMP; i++)
			{
				if (Main.recentIP[i].ToLower() == Netplay.ServerIPText.ToLower() && Main.recentPort[i] == Netplay.ListenPort)
				{
					for (int j = i; j < Main.maxMP - 1; j++)
					{
						Main.recentIP[j] = Main.recentIP[j + 1];
						Main.recentPort[j] = Main.recentPort[j + 1];
						Main.recentWorld[j] = Main.recentWorld[j + 1];
					}
				}
			}
			for (int k = Main.maxMP - 1; k > 0; k--)
			{
				Main.recentIP[k] = Main.recentIP[k - 1];
				Main.recentPort[k] = Main.recentPort[k - 1];
				Main.recentWorld[k] = Main.recentWorld[k - 1];
			}
			Main.recentIP[0] = Netplay.ServerIPText;
			Main.recentPort[0] = Netplay.ListenPort;
			Main.recentWorld[0] = Main.worldName;
			Main.SaveRecent();
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0002A350 File Offset: 0x00028550
		public static void SocialClientLoop(object threadContext)
		{
			ISocket socket = (ISocket)threadContext;
			Netplay.ClientLoopSetup(socket.GetRemoteAddress());
			Netplay.Connection.Socket = socket;
			Netplay.InnerClientLoop();
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0002A380 File Offset: 0x00028580
		public static void TcpClientLoop(object threadContext)
		{
			Netplay.ClientLoopSetup(new TcpAddress(Netplay.ServerIP, Netplay.ListenPort));
			Main.menuMode = 14;
			bool flag = true;
			while (flag)
			{
				flag = false;
				try
				{
					Netplay.Connection.Socket.Connect(new TcpAddress(Netplay.ServerIP, Netplay.ListenPort));
					flag = false;
				}
				catch
				{
					if (!Netplay.disconnect && Main.gameMenu)
					{
						flag = true;
					}
				}
			}
			Netplay.InnerClientLoop();
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0002A3FC File Offset: 0x000285FC
		private static void ClientLoopSetup(RemoteAddress address)
		{
			Netplay.ResetNetDiag();
			Main.ServerSideCharacter = false;
			if (Main.rand == null)
			{
				Main.rand = new UnifiedRandom((int)DateTime.Now.Ticks);
			}
			Main.player[Main.myPlayer].hostile = false;
			Main.clientPlayer = (Player)Main.player[Main.myPlayer].clientClone();
			for (int i = 0; i < 255; i++)
			{
				if (i != Main.myPlayer)
				{
					Main.player[i] = new Player();
				}
			}
			Main.netMode = 1;
			Main.menuMode = 14;
			if (!Main.autoPass)
			{
				Main.statusText = Language.GetTextValue("Net.ConnectingTo", address.GetFriendlyName());
			}
			Netplay.disconnect = false;
			Netplay.Connection = new RemoteServer();
			Netplay.Connection.ReadBuffer = new byte[1024];
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0002A4D0 File Offset: 0x000286D0
		private static void InnerClientLoop()
		{
			try
			{
				NetMessage.buffer[256].Reset();
				int num = -1;
				while (!Netplay.disconnect)
				{
					if (Netplay.Connection.Socket.IsConnected())
					{
						if (NetMessage.buffer[256].checkBytes)
						{
							NetMessage.CheckBytes(256);
						}
						Netplay.Connection.IsActive = true;
						if (Netplay.Connection.State == 0)
						{
							Main.statusText = Language.GetTextValue("Net.FoundServer");
							Netplay.Connection.State = 1;
							NetMessage.SendData(1, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
						}
						if (Netplay.Connection.State == 2 && num != Netplay.Connection.State)
						{
							Main.statusText = Language.GetTextValue("Net.SendingPlayerData");
						}
						if (Netplay.Connection.State == 3 && num != Netplay.Connection.State)
						{
							Main.statusText = Language.GetTextValue("Net.RequestingWorldInformation");
						}
						if (Netplay.Connection.State == 4)
						{
							WorldGen.worldCleared = false;
							Netplay.Connection.State = 5;
							if (Main.cloudBGActive >= 1f)
							{
								Main.cloudBGAlpha = 1f;
							}
							else
							{
								Main.cloudBGAlpha = 0f;
							}
							Main.windSpeed = Main.windSpeedSet;
							Cloud.resetClouds();
							Main.cloudAlpha = Main.maxRaining;
							WorldGen.clearWorld();
							if (Main.mapEnabled)
							{
								Main.Map.Load();
							}
						}
						if (Netplay.Connection.State == 5 && Main.loadMapLock)
						{
							float num2 = (float)Main.loadMapLastX / (float)Main.maxTilesX;
							Main.statusText = string.Concat(new object[]
							{
								Lang.gen[68].Value,
								" ",
								(int)(num2 * 100f + 1f),
								"%"
							});
						}
						else if (Netplay.Connection.State == 5 && WorldGen.worldCleared)
						{
							Netplay.Connection.State = 6;
							Main.player[Main.myPlayer].FindSpawn();
							NetMessage.SendData(8, -1, -1, null, Main.player[Main.myPlayer].SpawnX, (float)Main.player[Main.myPlayer].SpawnY, 0f, 0f, 0, 0, 0);
						}
						if (Netplay.Connection.State == 6 && num != Netplay.Connection.State)
						{
							Main.statusText = Language.GetTextValue("Net.RequestingTileData");
						}
						if (!Netplay.Connection.IsReading && !Netplay.disconnect && Netplay.Connection.Socket.IsDataAvailable())
						{
							Netplay.Connection.IsReading = true;
							Netplay.Connection.Socket.AsyncReceive(Netplay.Connection.ReadBuffer, 0, Netplay.Connection.ReadBuffer.Length, new SocketReceiveCallback(Netplay.Connection.ClientReadCallBack), null);
						}
						if (Netplay.Connection.StatusMax > 0 && Netplay.Connection.StatusText != "")
						{
							if (Netplay.Connection.StatusCount >= Netplay.Connection.StatusMax)
							{
								Main.statusText = Language.GetTextValue("Net.StatusComplete", Netplay.Connection.StatusText);
								Netplay.Connection.StatusText = "";
								Netplay.Connection.StatusMax = 0;
								Netplay.Connection.StatusCount = 0;
							}
							else
							{
								Main.statusText = string.Concat(new object[]
								{
									Netplay.Connection.StatusText,
									": ",
									(int)((float)Netplay.Connection.StatusCount / (float)Netplay.Connection.StatusMax * 100f),
									"%"
								});
							}
						}
						Thread.Sleep(1);
					}
					else if (Netplay.Connection.IsActive)
					{
						Main.statusText = Language.GetTextValue("Net.LostConnection");
						Netplay.disconnect = true;
					}
					num = Netplay.Connection.State;
				}
				try
				{
					Netplay.Connection.Socket.Close();
				}
				catch
				{
				}
				if (!Main.gameMenu)
				{
					Main.SwitchNetMode(0);
					Player.SavePlayer(Main.ActivePlayerFileData, false);
					Main.ActivePlayerFileData.StopPlayTimer();
					Main.gameMenu = true;
					Main.StopTrackedSounds();
					Main.menuMode = 14;
				}
				NetMessage.buffer[256].Reset();
				if (Main.menuMode == 15 && Main.statusText == Language.GetTextValue("Net.LostConnection"))
				{
					Main.menuMode = 14;
				}
				if (Netplay.Connection.StatusText != "" && Netplay.Connection.StatusText != null)
				{
					Main.statusText = Language.GetTextValue("Net.LostConnection");
				}
				Netplay.Connection.StatusCount = 0;
				Netplay.Connection.StatusMax = 0;
				Netplay.Connection.StatusText = "";
				Main.SwitchNetMode(0);
			}
			catch (Exception value)
			{
				try
				{
					using (StreamWriter streamWriter = new StreamWriter("client-crashlog.txt", true))
					{
						streamWriter.WriteLine(DateTime.Now);
						streamWriter.WriteLine(value);
						streamWriter.WriteLine("");
					}
				}
				catch
				{
				}
				Netplay.disconnect = true;
			}
			if (Netplay.OnDisconnect != null)
			{
				Netplay.OnDisconnect();
			}
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0002AA3C File Offset: 0x00028C3C
		private static int FindNextOpenClientSlot()
		{
			for (int i = 0; i < Main.maxNetPlayers; i++)
			{
				if (!Netplay.Clients[i].IsConnected())
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0002AA6C File Offset: 0x00028C6C
		private static void OnConnectionAccepted(ISocket client)
		{
			int num = Netplay.FindNextOpenClientSlot();
			if (num != -1)
			{
				Netplay.Clients[num].Reset();
				Netplay.Clients[num].Socket = client;
				Console.WriteLine(Language.GetTextValue("Net.ClientConnecting", client.GetRemoteAddress()));
			}
			if (Netplay.FindNextOpenClientSlot() == -1)
			{
				Netplay.StopListening();
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0002AAC0 File Offset: 0x00028CC0
		public static void OnConnectedToSocialServer(ISocket client)
		{
			Netplay.StartSocialClient(client);
		}

		// Token: 0x0600015B RID: 347 RVA: 0x0002AAC8 File Offset: 0x00028CC8
		private static bool StartListening()
		{
			if (SocialAPI.Network != null)
			{
				SocialAPI.Network.StartListening(new SocketConnectionAccepted(Netplay.OnConnectionAccepted));
			}
			return Netplay.TcpListener.StartListening(new SocketConnectionAccepted(Netplay.OnConnectionAccepted));
		}

		// Token: 0x0600015C RID: 348 RVA: 0x0002AB00 File Offset: 0x00028D00
		private static void StopListening()
		{
			if (SocialAPI.Network != null)
			{
				SocialAPI.Network.StopListening();
			}
			Netplay.TcpListener.StopListening();
		}

		// Token: 0x0600015D RID: 349 RVA: 0x0002AB20 File Offset: 0x00028D20
		public static void ServerLoop(object threadContext)
		{
			Netplay.ResetNetDiag();
			if (Main.rand == null)
			{
				Main.rand = new UnifiedRandom((int)DateTime.Now.Ticks);
			}
			Main.myPlayer = 255;
			Netplay.ServerIP = IPAddress.Any;
			Main.menuMode = 14;
			Main.statusText = Lang.menu[8].Value;
			Main.netMode = 2;
			Netplay.disconnect = false;
			for (int i = 0; i < 256; i++)
			{
				Netplay.Clients[i] = new RemoteClient();
				Netplay.Clients[i].Reset();
				Netplay.Clients[i].Id = i;
				Netplay.Clients[i].ReadBuffer = new byte[1024];
			}
			Netplay.TcpListener = new TcpSocket();
			if (!Netplay.disconnect)
			{
				if (!Netplay.StartListening())
				{
					Main.menuMode = 15;
					Main.statusText = Language.GetTextValue("Error.TriedToRunServerTwice");
					Netplay.disconnect = true;
				}
				Main.statusText = Language.GetTextValue("CLI.ServerStarted");
			}
			if (Netplay.UseUPNP)
			{
				try
				{
					Netplay.OpenPort();
				}
				catch
				{
				}
			}
			int num = 0;
			while (!Netplay.disconnect)
			{
				if (!Netplay.IsListening)
				{
					int num2 = -1;
					for (int j = 0; j < Main.maxNetPlayers; j++)
					{
						if (!Netplay.Clients[j].IsConnected())
						{
							num2 = j;
							break;
						}
					}
					if (num2 >= 0)
					{
						if (Main.ignoreErrors)
						{
							try
							{
								Netplay.StartListening();
								Netplay.IsListening = true;
								goto IL_15E;
							}
							catch
							{
								goto IL_15E;
							}
						}
						Netplay.StartListening();
						Netplay.IsListening = true;
					}
				}
				IL_15E:
				int num3 = 0;
				for (int k = 0; k < 256; k++)
				{
					if (NetMessage.buffer[k].checkBytes)
					{
						NetMessage.CheckBytes(k);
					}
					if (Netplay.Clients[k].PendingTermination)
					{
						Netplay.Clients[k].Reset();
						NetMessage.SyncDisconnectedPlayer(k);
					}
					else
					{
						if (Netplay.Clients[k].IsConnected())
						{
							if (!Netplay.Clients[k].IsActive)
							{
								Netplay.Clients[k].State = 0;
							}
							Netplay.Clients[k].IsActive = true;
							num3++;
							if (!Netplay.Clients[k].IsReading)
							{
								try
								{
									if (Netplay.Clients[k].Socket.IsDataAvailable())
									{
										Netplay.Clients[k].IsReading = true;
										Netplay.Clients[k].Socket.AsyncReceive(Netplay.Clients[k].ReadBuffer, 0, Netplay.Clients[k].ReadBuffer.Length, new SocketReceiveCallback(Netplay.Clients[k].ServerReadCallBack), null);
									}
								}
								catch
								{
									Netplay.Clients[k].PendingTermination = true;
								}
							}
							if (Netplay.Clients[k].StatusMax > 0 && Netplay.Clients[k].StatusText2 != "")
							{
								if (Netplay.Clients[k].StatusCount >= Netplay.Clients[k].StatusMax)
								{
									Netplay.Clients[k].StatusText = Language.GetTextValue("Net.ClientStatusComplete", Netplay.Clients[k].Socket.GetRemoteAddress(), Netplay.Clients[k].Name, Netplay.Clients[k].StatusText2);
									Netplay.Clients[k].StatusText2 = "";
									Netplay.Clients[k].StatusMax = 0;
									Netplay.Clients[k].StatusCount = 0;
									goto IL_58E;
								}
								Netplay.Clients[k].StatusText = string.Concat(new object[]
								{
									"(",
									Netplay.Clients[k].Socket.GetRemoteAddress(),
									") ",
									Netplay.Clients[k].Name,
									" ",
									Netplay.Clients[k].StatusText2,
									": ",
									(int)((float)Netplay.Clients[k].StatusCount / (float)Netplay.Clients[k].StatusMax * 100f),
									"%"
								});
								goto IL_58E;
							}
							else
							{
								if (Netplay.Clients[k].State == 0)
								{
									Netplay.Clients[k].StatusText = Language.GetTextValue("Net.ClientConnecting", string.Format("({0}) {1}", Netplay.Clients[k].Socket.GetRemoteAddress(), Netplay.Clients[k].Name));
									goto IL_58E;
								}
								if (Netplay.Clients[k].State == 1)
								{
									Netplay.Clients[k].StatusText = Language.GetTextValue("Net.ClientSendingData", Netplay.Clients[k].Socket.GetRemoteAddress(), Netplay.Clients[k].Name);
									goto IL_58E;
								}
								if (Netplay.Clients[k].State == 2)
								{
									Netplay.Clients[k].StatusText = Language.GetTextValue("Net.ClientRequestedWorldInfo", Netplay.Clients[k].Socket.GetRemoteAddress(), Netplay.Clients[k].Name);
									goto IL_58E;
								}
								if (Netplay.Clients[k].State == 3 || Netplay.Clients[k].State != 10)
								{
									goto IL_58E;
								}
								try
								{
									Netplay.Clients[k].StatusText = Language.GetTextValue("Net.ClientPlaying", Netplay.Clients[k].Socket.GetRemoteAddress(), Netplay.Clients[k].Name);
									goto IL_58E;
								}
								catch (Exception)
								{
									Netplay.Clients[k].PendingTermination = true;
									goto IL_58E;
								}
							}
						}
						if (Netplay.Clients[k].IsActive)
						{
							Netplay.Clients[k].PendingTermination = true;
						}
						else
						{
							Netplay.Clients[k].StatusText2 = "";
							if (k < 255)
							{
								bool arg_585_0 = Main.player[k].active;
								Main.player[k].active = false;
								if (arg_585_0)
								{
									Player.Hooks.PlayerDisconnect(k);
								}
							}
						}
					}
					IL_58E:;
				}
				num++;
				if (num > 10)
				{
					Thread.Sleep(1);
					num = 0;
				}
				else
				{
					Thread.Sleep(0);
				}
				if (!WorldGen.saveLock && !Main.dedServ)
				{
					if (num3 == 0)
					{
						Main.statusText = Language.GetTextValue("Net.WaitingForClients");
					}
					else
					{
						Main.statusText = Language.GetTextValue("Net.ClientsConnected", num3);
					}
				}
				if (num3 == 0)
				{
					Netplay.anyClients = false;
				}
				else
				{
					Netplay.anyClients = true;
				}
				Netplay.IsServerRunning = true;
			}
			Netplay.StopListening();
			try
			{
				Netplay.closePort();
			}
			catch
			{
			}
			for (int l = 0; l < 256; l++)
			{
				Netplay.Clients[l].Reset();
			}
			if (Main.menuMode != 15)
			{
				Main.netMode = 0;
				Main.menuMode = 10;
				WorldFile.saveWorld();
				while (WorldGen.saveLock)
				{
				}
				Main.menuMode = 0;
			}
			else
			{
				Main.netMode = 0;
			}
			Main.myPlayer = 0;
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0002B1E4 File Offset: 0x000293E4
		public static void StartSocialClient(ISocket socket)
		{
			ThreadPool.QueueUserWorkItem(new WaitCallback(Netplay.SocialClientLoop), socket);
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0002B1FC File Offset: 0x000293FC
		public static void StartTcpClient()
		{
			ThreadPool.QueueUserWorkItem(new WaitCallback(Netplay.TcpClientLoop), 1);
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0002B218 File Offset: 0x00029418
		public static void StartServer()
		{
			Netplay.ServerThread = new Thread(new ParameterizedThreadStart(Netplay.ServerLoop));
			Netplay.ServerThread.Start();
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0002B23C File Offset: 0x0002943C
		public static bool SetRemoteIP(string remoteAddress)
		{
			try
			{
				IPAddress iPAddress;
				if (IPAddress.TryParse(remoteAddress, out iPAddress))
				{
					Netplay.ServerIP = iPAddress;
					Netplay.ServerIPText = iPAddress.ToString();
					bool result = true;
					return result;
				}
				IPAddress[] addressList = Dns.GetHostEntry(remoteAddress).AddressList;
				for (int i = 0; i < addressList.Length; i++)
				{
					if (addressList[i].AddressFamily == AddressFamily.InterNetwork)
					{
						Netplay.ServerIP = addressList[i];
						Netplay.ServerIPText = remoteAddress;
						bool result = true;
						return result;
					}
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0002B2B8 File Offset: 0x000294B8
		public static void Initialize()
		{
			NetMessage.buffer[256] = new MessageBuffer();
			NetMessage.buffer[256].whoAmI = 256;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0002B2EC File Offset: 0x000294EC
		public static int GetSectionX(int x)
		{
			return x / 200;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0002B2F8 File Offset: 0x000294F8
		public static int GetSectionY(int y)
		{
			return y / 150;
		}

		// Token: 0x04000150 RID: 336
		public const int MaxConnections = 256;

		// Token: 0x04000151 RID: 337
		public const int NetBufferSize = 1024;

		// Token: 0x04000153 RID: 339
		public static string BanFilePath = "banlist.txt";

		// Token: 0x04000154 RID: 340
		public static string ServerPassword = "";

		// Token: 0x04000155 RID: 341
		public static RemoteClient[] Clients = new RemoteClient[256];

		// Token: 0x04000156 RID: 342
		public static RemoteServer Connection = new RemoteServer();

		// Token: 0x04000157 RID: 343
		public static IPAddress ServerIP;

		// Token: 0x04000158 RID: 344
		public static string ServerIPText = "";

		// Token: 0x04000159 RID: 345
		public static ISocket TcpListener;

		// Token: 0x0400015A RID: 346
		public static int ListenPort = 7777;

		// Token: 0x0400015B RID: 347
		public static bool IsServerRunning = false;

		// Token: 0x0400015C RID: 348
		public static bool IsListening = true;

		// Token: 0x0400015D RID: 349
		public static bool UseUPNP = true;

		// Token: 0x0400015E RID: 350
		public static bool disconnect = false;

		// Token: 0x0400015F RID: 351
		public static bool spamCheck = false;

		// Token: 0x04000160 RID: 352
		public static bool anyClients = false;

		// Token: 0x04000161 RID: 353
		private static Thread ServerThread;

		// Token: 0x04000162 RID: 354
		public static string portForwardIP;

		// Token: 0x04000163 RID: 355
		public static int portForwardPort;

		// Token: 0x04000164 RID: 356
		public static bool portForwardOpen;
	}
}

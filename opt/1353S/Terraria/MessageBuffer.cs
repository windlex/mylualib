using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Net;
using Terraria.UI;

namespace Terraria
{
	// Token: 0x02000016 RID: 22
	public class MessageBuffer
	{
		// Token: 0x060000CD RID: 205 RVA: 0x000157CC File Offset: 0x000139CC
		public void GetData(int start, int length, out int messageType)
		{
			if (this.whoAmI < 256)
			{
				Netplay.Clients[this.whoAmI].TimeOutTimer = 0;
			}
			else
			{
				Netplay.Connection.TimeOutTimer = 0;
			}
			int num = start + 1;
			byte b = this.readBuffer[start];
			messageType = (int)b;
			if (b >= 120)
			{
				return;
			}
			Main.rxMsg++;
			Main.rxData += length;
			Main.rxMsgType[(int)b]++;
			Main.rxDataType[(int)b] += length;
			if (Main.netMode == 1 && Netplay.Connection.StatusMax > 0)
			{
				Netplay.Connection.StatusCount++;
			}
			if (Main.verboseNetplay)
			{
				for (int i = start; i < start + length; i++)
				{
				}
				for (int j = start; j < start + length; j++)
				{
					byte arg_C6_0 = this.readBuffer[j];
				}
			}
			if (Main.netMode == 2 && b != 38 && Netplay.Clients[this.whoAmI].State == -1)
			{
				NetMessage.SendData(2, this.whoAmI, -1, Lang.mp[1].ToNetworkText(), 0, 0f, 0f, 0f, 0, 0, 0);
				return;
			}
			if (Main.netMode == 2 && Netplay.Clients[this.whoAmI].State < 10 && b > 12 && b != 93 && b != 16 && b != 42 && b != 50 && b != 38 && b != 68)
			{
				NetMessage.BootPlayer(this.whoAmI, Lang.mp[2].ToNetworkText());
			}
			if (this.reader == null)
			{
				this.ResetReader();
			}
			this.reader.BaseStream.Position = (long)num;
			switch (b)
			{
				case 1:
					if (Main.netMode != 2)
					{
						return;
					}
					if (Main.dedServ && Netplay.IsBanned(Netplay.Clients[this.whoAmI].Socket.GetRemoteAddress()))
					{
						NetMessage.SendData(2, this.whoAmI, -1, Lang.mp[3].ToNetworkText(), 0, 0f, 0f, 0f, 0, 0, 0);
						return;
					}
					if (Netplay.Clients[this.whoAmI].State != 0)
					{
						return;
					}
					if (!(this.reader.ReadString() == "Terraria" + 194))
					{
						NetMessage.SendData(2, this.whoAmI, -1, Lang.mp[4].ToNetworkText(), 0, 0f, 0f, 0f, 0, 0, 0);
						return;
					}
					if (string.IsNullOrEmpty(Netplay.ServerPassword))
					{
						Netplay.Clients[this.whoAmI].State = 1;
						NetMessage.SendData(3, this.whoAmI, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
						return;
					}
					Netplay.Clients[this.whoAmI].State = -1;
					NetMessage.SendData(37, this.whoAmI, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
					return;
				case 2:
					if (Main.netMode != 1)
					{
						return;
					}
					Netplay.disconnect = true;
					Main.statusText = NetworkText.Deserialize(this.reader).ToString();
					return;
				case 3:
					{
						if (Main.netMode != 1)
						{
							return;
						}
						if (Netplay.Connection.State == 1)
						{
							Netplay.Connection.State = 2;
						}
						int num2 = (int)this.reader.ReadByte();
						if (num2 != Main.myPlayer)
						{
							Main.player[num2] = Main.ActivePlayerFileData.Player;
							Main.player[Main.myPlayer] = new Player();
						}
						Main.player[num2].whoAmI = num2;
						Main.myPlayer = num2;
						Player player = Main.player[num2];
						NetMessage.SendData(4, -1, -1, null, num2, 0f, 0f, 0f, 0, 0, 0);
						NetMessage.SendData(68, -1, -1, null, num2, 0f, 0f, 0f, 0, 0, 0);
						NetMessage.SendData(16, -1, -1, null, num2, 0f, 0f, 0f, 0, 0, 0);
						NetMessage.SendData(42, -1, -1, null, num2, 0f, 0f, 0f, 0, 0, 0);
						NetMessage.SendData(50, -1, -1, null, num2, 0f, 0f, 0f, 0, 0, 0);
						for (int k = 0; k < 59; k++)
						{
							NetMessage.SendData(5, -1, -1, null, num2, (float)k, (float)player.inventory[k].prefix, 0f, 0, 0, 0);
						}
						for (int l = 0; l < player.armor.Length; l++)
						{
							NetMessage.SendData(5, -1, -1, null, num2, (float)(59 + l), (float)player.armor[l].prefix, 0f, 0, 0, 0);
						}
						for (int m = 0; m < player.dye.Length; m++)
						{
							NetMessage.SendData(5, -1, -1, null, num2, (float)(58 + player.armor.Length + 1 + m), (float)player.dye[m].prefix, 0f, 0, 0, 0);
						}
						for (int n = 0; n < player.miscEquips.Length; n++)
						{
							NetMessage.SendData(5, -1, -1, null, num2, (float)(58 + player.armor.Length + player.dye.Length + 1 + n), (float)player.miscEquips[n].prefix, 0f, 0, 0, 0);
						}
						for (int num3 = 0; num3 < player.miscDyes.Length; num3++)
						{
							NetMessage.SendData(5, -1, -1, null, num2, (float)(58 + player.armor.Length + player.dye.Length + player.miscEquips.Length + 1 + num3), (float)player.miscDyes[num3].prefix, 0f, 0, 0, 0);
						}
						for (int num4 = 0; num4 < player.bank.item.Length; num4++)
						{
							NetMessage.SendData(5, -1, -1, null, num2, (float)(58 + player.armor.Length + player.dye.Length + player.miscEquips.Length + player.miscDyes.Length + 1 + num4), (float)player.bank.item[num4].prefix, 0f, 0, 0, 0);
						}
						for (int num5 = 0; num5 < player.bank2.item.Length; num5++)
						{
							NetMessage.SendData(5, -1, -1, null, num2, (float)(58 + player.armor.Length + player.dye.Length + player.miscEquips.Length + player.miscDyes.Length + player.bank.item.Length + 1 + num5), (float)player.bank2.item[num5].prefix, 0f, 0, 0, 0);
						}
						NetMessage.SendData(5, -1, -1, null, num2, (float)(58 + player.armor.Length + player.dye.Length + player.miscEquips.Length + player.miscDyes.Length + player.bank.item.Length + player.bank2.item.Length + 1), (float)player.trashItem.prefix, 0f, 0, 0, 0);
						for (int num6 = 0; num6 < player.bank3.item.Length; num6++)
						{
							NetMessage.SendData(5, -1, -1, null, num2, (float)(58 + player.armor.Length + player.dye.Length + player.miscEquips.Length + player.miscDyes.Length + player.bank.item.Length + player.bank2.item.Length + 2 + num6), (float)player.bank3.item[num6].prefix, 0f, 0, 0, 0);
						}
						NetMessage.SendData(6, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
						if (Netplay.Connection.State == 2)
						{
							Netplay.Connection.State = 3;
							return;
						}
						return;
					}
				case 4:
					{
						int num7 = (int)this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							num7 = this.whoAmI;
						}
						if (num7 == Main.myPlayer && !Main.ServerSideCharacter)
						{
							return;
						}
						Player player2 = Main.player[num7];
						player2.whoAmI = num7;
						player2.skinVariant = (int)this.reader.ReadByte();
						player2.skinVariant = (int)MathHelper.Clamp((float)player2.skinVariant, 0f, 9f);
						player2.hair = (int)this.reader.ReadByte();
						if (player2.hair >= 134)
						{
							player2.hair = 0;
						}
						player2.name = this.reader.ReadString().Trim().Trim();
						player2.hairDye = this.reader.ReadByte();
						BitsByte bitsByte = this.reader.ReadByte();
						for (int num8 = 0; num8 < 8; num8++)
						{
							player2.hideVisual[num8] = bitsByte[num8];
						}
						bitsByte = this.reader.ReadByte();
						for (int num9 = 0; num9 < 2; num9++)
						{
							player2.hideVisual[num9 + 8] = bitsByte[num9];
						}
						player2.hideMisc = this.reader.ReadByte();
						player2.hairColor = this.reader.ReadRGB();
						player2.skinColor = this.reader.ReadRGB();
						player2.eyeColor = this.reader.ReadRGB();
						player2.shirtColor = this.reader.ReadRGB();
						player2.underShirtColor = this.reader.ReadRGB();
						player2.pantsColor = this.reader.ReadRGB();
						player2.shoeColor = this.reader.ReadRGB();
						BitsByte bitsByte2 = this.reader.ReadByte();
						player2.difficulty = 0;
						if (bitsByte2[0])
						{
							Player expr_B84 = player2;
							expr_B84.difficulty += 1;
						}
						if (bitsByte2[1])
						{
							Player expr_B9E = player2;
							expr_B9E.difficulty += 2;
						}
						if (player2.difficulty > 2)
						{
							player2.difficulty = 2;
						}
						player2.extraAccessory = bitsByte2[2];
						if (Main.netMode != 2)
						{
							return;
						}
						bool flag = false;
						if (Netplay.Clients[this.whoAmI].State < 10)
						{
							for (int num10 = 0; num10 < 255; num10++)
							{
								if (num10 != num7 && player2.name == Main.player[num10].name && Netplay.Clients[num10].IsActive)
								{
									flag = true;
								}
							}
						}
						if (flag)
						{
							NetMessage.SendData(2, this.whoAmI, -1, NetworkText.FromFormattable("{0} {1}", new object[]
							{
						player2.name,
						Lang.mp[5].ToNetworkText()
							}), 0, 0f, 0f, 0f, 0, 0, 0);
							return;
						}
						if (player2.name.Length > Player.nameLen)
						{
							NetMessage.SendData(2, this.whoAmI, -1, NetworkText.FromKey("Net.NameTooLong", new object[0]), 0, 0f, 0f, 0f, 0, 0, 0);
							return;
						}
						if (player2.name == "")
						{
							NetMessage.SendData(2, this.whoAmI, -1, NetworkText.FromKey("Net.EmptyName", new object[0]), 0, 0f, 0f, 0f, 0, 0, 0);
							return;
						}
						Netplay.Clients[this.whoAmI].Name = player2.name;
						Netplay.Clients[this.whoAmI].Name = player2.name;
						NetMessage.SendData(4, -1, this.whoAmI, null, num7, 0f, 0f, 0f, 0, 0, 0);
						return;
					}
				case 5:
					{
						int num11 = (int)this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							num11 = this.whoAmI;
						}
						if (num11 == Main.myPlayer && !Main.ServerSideCharacter && !Main.player[num11].IsStackingItems())
						{
							return;
						}
						Player player3 = Main.player[num11];
						Player obj = player3;
						lock (obj)
						{
							int num12 = (int)this.reader.ReadByte();
							int stack = (int)this.reader.ReadInt16();
							int num13 = (int)this.reader.ReadByte();
							int type = (int)this.reader.ReadInt16();
							Item[] array = null;
							int num14 = 0;
							bool flag3 = false;
							if (num12 > 58 + player3.armor.Length + player3.dye.Length + player3.miscEquips.Length + player3.miscDyes.Length + player3.bank.item.Length + player3.bank2.item.Length + 1)
							{
								num14 = num12 - 58 - (player3.armor.Length + player3.dye.Length + player3.miscEquips.Length + player3.miscDyes.Length + player3.bank.item.Length + player3.bank2.item.Length + 1) - 1;
								array = player3.bank3.item;
							}
							else if (num12 > 58 + player3.armor.Length + player3.dye.Length + player3.miscEquips.Length + player3.miscDyes.Length + player3.bank.item.Length + player3.bank2.item.Length)
							{
								flag3 = true;
							}
							else if (num12 > 58 + player3.armor.Length + player3.dye.Length + player3.miscEquips.Length + player3.miscDyes.Length + player3.bank.item.Length)
							{
								num14 = num12 - 58 - (player3.armor.Length + player3.dye.Length + player3.miscEquips.Length + player3.miscDyes.Length + player3.bank.item.Length) - 1;
								array = player3.bank2.item;
							}
							else if (num12 > 58 + player3.armor.Length + player3.dye.Length + player3.miscEquips.Length + player3.miscDyes.Length)
							{
								num14 = num12 - 58 - (player3.armor.Length + player3.dye.Length + player3.miscEquips.Length + player3.miscDyes.Length) - 1;
								array = player3.bank.item;
							}
							else if (num12 > 58 + player3.armor.Length + player3.dye.Length + player3.miscEquips.Length)
							{
								num14 = num12 - 58 - (player3.armor.Length + player3.dye.Length + player3.miscEquips.Length) - 1;
								array = player3.miscDyes;
							}
							else if (num12 > 58 + player3.armor.Length + player3.dye.Length)
							{
								num14 = num12 - 58 - (player3.armor.Length + player3.dye.Length) - 1;
								array = player3.miscEquips;
							}
							else if (num12 > 58 + player3.armor.Length)
							{
								num14 = num12 - 58 - player3.armor.Length - 1;
								array = player3.dye;
							}
							else if (num12 > 58)
							{
								num14 = num12 - 58 - 1;
								array = player3.armor;
							}
							else
							{
								num14 = num12;
								array = player3.inventory;
							}
							if (flag3)
							{
								player3.trashItem = new Item();
								player3.trashItem.netDefaults(type);
								player3.trashItem.stack = stack;
								player3.trashItem.Prefix(num13);
							}
							else if (num12 <= 58)
							{
								int type2 = array[num14].type;
								int stack2 = array[num14].stack;
								array[num14] = new Item();
								array[num14].netDefaults(type);
								array[num14].stack = stack;
								array[num14].Prefix(num13);
								if (num11 == Main.myPlayer && num14 == 58)
								{
									Main.mouseItem = array[num14].Clone();
								}
								if (num11 == Main.myPlayer && Main.netMode == 1)
								{
									Main.player[num11].inventoryChestStack[num12] = false;
									if (array[num14].stack != stack2 || array[num14].type != type2)
									{
										Recipe.FindRecipes();
										Main.PlaySound(7, -1, -1, 1, 1f, 0f);
									}
								}
							}
							else
							{
								array[num14] = new Item();
								array[num14].netDefaults(type);
								array[num14].stack = stack;
								array[num14].Prefix(num13);
							}
							if (Main.netMode == 2 && num11 == this.whoAmI && num12 <= 58 + player3.armor.Length + player3.dye.Length + player3.miscEquips.Length + player3.miscDyes.Length)
							{
								NetMessage.SendData(5, -1, this.whoAmI, null, num11, (float)num12, (float)num13, 0f, 0, 0, 0);
							}
							return;
						}
						break;
					}
				case 6:
					break;
				case 7:
					{
						if (Main.netMode != 1)
						{
							return;
						}
						Main.time = (double)this.reader.ReadInt32();
						BitsByte bitsByte3 = this.reader.ReadByte();
						Main.dayTime = bitsByte3[0];
						Main.bloodMoon = bitsByte3[1];
						Main.eclipse = bitsByte3[2];
						Main.moonPhase = (int)this.reader.ReadByte();
						Main.maxTilesX = (int)this.reader.ReadInt16();
						Main.maxTilesY = (int)this.reader.ReadInt16();
						Main.spawnTileX = (int)this.reader.ReadInt16();
						Main.spawnTileY = (int)this.reader.ReadInt16();
						Main.worldSurface = (double)this.reader.ReadInt16();
						Main.rockLayer = (double)this.reader.ReadInt16();
						Main.worldID = this.reader.ReadInt32();
						Main.worldName = this.reader.ReadString();
						Main.ActiveWorldFileData.UniqueId = new Guid(this.reader.ReadBytes(16));
						Main.ActiveWorldFileData.WorldGeneratorVersion = this.reader.ReadUInt64();
						Main.moonType = (int)this.reader.ReadByte();
						WorldGen.setBG(0, (int)this.reader.ReadByte());
						WorldGen.setBG(1, (int)this.reader.ReadByte());
						WorldGen.setBG(2, (int)this.reader.ReadByte());
						WorldGen.setBG(3, (int)this.reader.ReadByte());
						WorldGen.setBG(4, (int)this.reader.ReadByte());
						WorldGen.setBG(5, (int)this.reader.ReadByte());
						WorldGen.setBG(6, (int)this.reader.ReadByte());
						WorldGen.setBG(7, (int)this.reader.ReadByte());
						Main.iceBackStyle = (int)this.reader.ReadByte();
						Main.jungleBackStyle = (int)this.reader.ReadByte();
						Main.hellBackStyle = (int)this.reader.ReadByte();
						Main.windSpeedSet = this.reader.ReadSingle();
						Main.numClouds = (int)this.reader.ReadByte();
						for (int num15 = 0; num15 < 3; num15++)
						{
							Main.treeX[num15] = this.reader.ReadInt32();
						}
						for (int num16 = 0; num16 < 4; num16++)
						{
							Main.treeStyle[num16] = (int)this.reader.ReadByte();
						}
						for (int num17 = 0; num17 < 3; num17++)
						{
							Main.caveBackX[num17] = this.reader.ReadInt32();
						}
						for (int num18 = 0; num18 < 4; num18++)
						{
							Main.caveBackStyle[num18] = (int)this.reader.ReadByte();
						}
						Main.maxRaining = this.reader.ReadSingle();
						Main.raining = (Main.maxRaining > 0f);
						BitsByte bitsByte4 = this.reader.ReadByte();
						WorldGen.shadowOrbSmashed = bitsByte4[0];
						NpcMgr.downedBoss1 = bitsByte4[1];
						NpcMgr.downedBoss2 = bitsByte4[2];
						NpcMgr.downedBoss3 = bitsByte4[3];
						Main.hardMode = bitsByte4[4];
						NpcMgr.downedClown = bitsByte4[5];
						Main.ServerSideCharacter = bitsByte4[6];
						NpcMgr.downedPlantBoss = bitsByte4[7];
						BitsByte bitsByte5 = this.reader.ReadByte();
						NpcMgr.downedMechBoss1 = bitsByte5[0];
						NpcMgr.downedMechBoss2 = bitsByte5[1];
						NpcMgr.downedMechBoss3 = bitsByte5[2];
						NpcMgr.downedMechBossAny = bitsByte5[3];
						Main.cloudBGActive = (float)(bitsByte5[4] ? 1 : 0);
						WorldGen.crimson = bitsByte5[5];
						Main.pumpkinMoon = bitsByte5[6];
						Main.snowMoon = bitsByte5[7];
						BitsByte bitsByte6 = this.reader.ReadByte();
						Main.expertMode = bitsByte6[0];
						Main.fastForwardTime = bitsByte6[1];
						Main.UpdateSundial();
						bool arg_1801_0 = bitsByte6[2];
						NpcMgr.downedSlimeKing = bitsByte6[3];
						NpcMgr.downedQueenBee = bitsByte6[4];
						NpcMgr.downedFishron = bitsByte6[5];
						NpcMgr.downedMartians = bitsByte6[6];
						NpcMgr.downedAncientCultist = bitsByte6[7];
						BitsByte bitsByte7 = this.reader.ReadByte();
						NpcMgr.downedMoonlord = bitsByte7[0];
						NpcMgr.downedHalloweenKing = bitsByte7[1];
						NpcMgr.downedHalloweenTree = bitsByte7[2];
						NpcMgr.downedChristmasIceQueen = bitsByte7[3];
						NpcMgr.downedChristmasSantank = bitsByte7[4];
						NpcMgr.downedChristmasTree = bitsByte7[5];
						NpcMgr.downedGolemBoss = bitsByte7[6];
						BirthdayParty.ManualParty = bitsByte7[7];
						BitsByte bitsByte8 = this.reader.ReadByte();
						NpcMgr.downedPirates = bitsByte8[0];
						NpcMgr.downedFrost = bitsByte8[1];
						NpcMgr.downedGoblins = bitsByte8[2];
						Sandstorm.Happening = bitsByte8[3];
						DD2Event.Ongoing = bitsByte8[4];
						DD2Event.DownedInvasionT1 = bitsByte8[5];
						DD2Event.DownedInvasionT2 = bitsByte8[6];
						DD2Event.DownedInvasionT3 = bitsByte8[7];
						if (arg_1801_0)
						{
							Main.StartSlimeRain(true);
						}
						else
						{
							Main.StopSlimeRain(true);
						}
						Main.invasionType = (int)this.reader.ReadSByte();
						Main.LobbyId = this.reader.ReadUInt64();
						Sandstorm.IntendedSeverity = this.reader.ReadSingle();
						if (Netplay.Connection.State == 3)
						{
							Netplay.Connection.State = 4;
							return;
						}
						return;
					}
				case 8:
					{
						if (Main.netMode != 2)
						{
							return;
						}
						int num19 = this.reader.ReadInt32();
						int num20 = this.reader.ReadInt32();
						bool flag4 = true;
						if (num19 == -1 || num20 == -1)
						{
							flag4 = false;
						}
						else if (num19 < 10 || num19 > Main.maxTilesX - 10)
						{
							flag4 = false;
						}
						else if (num20 < 10 || num20 > Main.maxTilesY - 10)
						{
							flag4 = false;
						}
						int num21 = Netplay.GetSectionX(Main.spawnTileX) - 2;
						int num22 = Netplay.GetSectionY(Main.spawnTileY) - 1;
						int num23 = num21 + 5;
						int num24 = num22 + 3;
						if (num21 < 0)
						{
							num21 = 0;
						}
						if (num23 >= Main.maxSectionsX)
						{
							num23 = Main.maxSectionsX - 1;
						}
						if (num22 < 0)
						{
							num22 = 0;
						}
						if (num24 >= Main.maxSectionsY)
						{
							num24 = Main.maxSectionsY - 1;
						}
						int num25 = (num23 - num21) * (num24 - num22);
						List<Point> list = new List<Point>();
						for (int num26 = num21; num26 < num23; num26++)
						{
							for (int num27 = num22; num27 < num24; num27++)
							{
								list.Add(new Point(num26, num27));
							}
						}
						int num28 = -1;
						int num29 = -1;
						if (flag4)
						{
							num19 = Netplay.GetSectionX(num19) - 2;
							num20 = Netplay.GetSectionY(num20) - 1;
							num28 = num19 + 5;
							num29 = num20 + 3;
							if (num19 < 0)
							{
								num19 = 0;
							}
							if (num28 >= Main.maxSectionsX)
							{
								num28 = Main.maxSectionsX - 1;
							}
							if (num20 < 0)
							{
								num20 = 0;
							}
							if (num29 >= Main.maxSectionsY)
							{
								num29 = Main.maxSectionsY - 1;
							}
							for (int num30 = num19; num30 < num28; num30++)
							{
								for (int num31 = num20; num31 < num29; num31++)
								{
									if (num30 < num21 || num30 >= num23 || num31 < num22 || num31 >= num24)
									{
										list.Add(new Point(num30, num31));
										num25++;
									}
								}
							}
						}
						int num32 = 1;
						List<Point> list2;
						List<Point> list3;
						PortalHelper.SyncPortalsOnPlayerJoin(this.whoAmI, 1, list, out list2, out list3);
						num25 += list2.Count;
						if (Netplay.Clients[this.whoAmI].State == 2)
						{
							Netplay.Clients[this.whoAmI].State = 3;
						}
						NetMessage.SendData(9, this.whoAmI, -1, Lang.inter[44].ToNetworkText(), num25, 0f, 0f, 0f, 0, 0, 0);
						Netplay.Clients[this.whoAmI].StatusText2 = Language.GetTextValue("Net.IsReceivingTileData");
						Netplay.Clients[this.whoAmI].StatusMax += num25;
						for (int num33 = num21; num33 < num23; num33++)
						{
							for (int num34 = num22; num34 < num24; num34++)
							{
								NetMessage.SendSection(this.whoAmI, num33, num34, false);
							}
						}
						NetMessage.SendData(11, this.whoAmI, -1, null, num21, (float)num22, (float)(num23 - 1), (float)(num24 - 1), 0, 0, 0);
						if (flag4)
						{
							for (int num35 = num19; num35 < num28; num35++)
							{
								for (int num36 = num20; num36 < num29; num36++)
								{
									NetMessage.SendSection(this.whoAmI, num35, num36, true);
								}
							}
							NetMessage.SendData(11, this.whoAmI, -1, null, num19, (float)num20, (float)(num28 - 1), (float)(num29 - 1), 0, 0, 0);
						}
						for (int num37 = 0; num37 < list2.Count; num37++)
						{
							NetMessage.SendSection(this.whoAmI, list2[num37].X, list2[num37].Y, true);
						}
						for (int num38 = 0; num38 < list3.Count; num38++)
						{
							NetMessage.SendData(11, this.whoAmI, -1, null, list3[num38].X - num32, (float)(list3[num38].Y - num32), (float)(list3[num38].X + num32 + 1), (float)(list3[num38].Y + num32 + 1), 0, 0, 0);
						}
						for (int num39 = 0; num39 < 400; num39++)
						{
							if (Main.item[num39].active)
							{
								NetMessage.SendData(21, this.whoAmI, -1, null, num39, 0f, 0f, 0f, 0, 0, 0);
								NetMessage.SendData(22, this.whoAmI, -1, null, num39, 0f, 0f, 0f, 0, 0, 0);
							}
						}
						for (int num40 = 0; num40 < 200; num40++)
						{
							if (Main.npc[num40].active)
							{
								NetMessage.SendData(23, this.whoAmI, -1, null, num40, 0f, 0f, 0f, 0, 0, 0);
							}
						}
						for (int num41 = 0; num41 < 1000; num41++)
						{
							if (Main.projectile[num41].active && (Main.projPet[Main.projectile[num41].type] || Main.projectile[num41].netImportant))
							{
								NetMessage.SendData(27, this.whoAmI, -1, null, num41, 0f, 0f, 0f, 0, 0, 0);
							}
						}
						for (int num42 = 0; num42 < 267; num42++)
						{
							NetMessage.SendData(83, this.whoAmI, -1, null, num42, 0f, 0f, 0f, 0, 0, 0);
						}
						NetMessage.SendData(49, this.whoAmI, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
						NetMessage.SendData(57, this.whoAmI, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
						NetMessage.SendData(7, this.whoAmI, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
						NetMessage.SendData(103, -1, -1, null, NpcMgr.MoonLordCountdown, 0f, 0f, 0f, 0, 0, 0);
						NetMessage.SendData(101, this.whoAmI, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
						return;
					}
				case 9:
					if (Main.netMode != 1)
					{
						return;
					}
					Netplay.Connection.StatusMax += this.reader.ReadInt32();
					Netplay.Connection.StatusText = NetworkText.Deserialize(this.reader).ToString();
					return;
				case 10:
					if (Main.netMode != 1)
					{
						return;
					}
					NetMessage.DecompressTileBlock(this.readBuffer, num, length);
					return;
				case 11:
					if (Main.netMode != 1)
					{
						return;
					}
					WorldGen.SectionTileFrame((int)this.reader.ReadInt16(), (int)this.reader.ReadInt16(), (int)this.reader.ReadInt16(), (int)this.reader.ReadInt16());
					return;
				case 12:
					{
						int num43 = (int)this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							num43 = this.whoAmI;
						}
						Player expr_1ED1 = Main.player[num43];
						expr_1ED1.SpawnX = (int)this.reader.ReadInt16();
						expr_1ED1.SpawnY = (int)this.reader.ReadInt16();
						expr_1ED1.Spawn();
						if (num43 == Main.myPlayer && Main.netMode != 2)
						{
							Main.ActivePlayerFileData.StartPlayTimer();
							Player.Hooks.EnterWorld(Main.myPlayer);
						}
						if (Main.netMode != 2 || Netplay.Clients[this.whoAmI].State < 3)
						{
							return;
						}
						if (Netplay.Clients[this.whoAmI].State == 3)
						{
							Netplay.Clients[this.whoAmI].State = 10;
							NetMessage.greetPlayer(this.whoAmI);
							NetMessage.buffer[this.whoAmI].broadcast = true;
							NetMessage.SyncConnectedPlayer(this.whoAmI);
							NetMessage.SendData(12, -1, this.whoAmI, null, this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
							NetMessage.SendData(74, this.whoAmI, -1, NetworkText.FromLiteral(Main.player[this.whoAmI].name), Main.anglerQuest, 0f, 0f, 0f, 0, 0, 0);
							return;
						}
						NetMessage.SendData(12, -1, this.whoAmI, null, this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
						return;
					}
				case 13:
					{
						int num44 = (int)this.reader.ReadByte();
						if (num44 == Main.myPlayer && !Main.ServerSideCharacter)
						{
							return;
						}
						if (Main.netMode == 2)
						{
							num44 = this.whoAmI;
						}
						Player player4 = Main.player[num44];
						BitsByte bitsByte9 = this.reader.ReadByte();
						player4.controlUp = bitsByte9[0];
						player4.controlDown = bitsByte9[1];
						player4.controlLeft = bitsByte9[2];
						player4.controlRight = bitsByte9[3];
						player4.controlJump = bitsByte9[4];
						player4.controlUseItem = bitsByte9[5];
						player4.direction = (bitsByte9[6] ? 1 : -1);
						BitsByte bitsByte10 = this.reader.ReadByte();
						if (bitsByte10[0])
						{
							player4.pulley = true;
							player4.pulleyDir = ((byte)(bitsByte10[1] ? 2 : 1));
						}
						else
						{
							player4.pulley = false;
						}
						player4.selectedItem = (int)this.reader.ReadByte();
						player4.position = this.reader.ReadVector2();
						if (bitsByte10[2])
						{
							player4.velocity = this.reader.ReadVector2();
						}
						else
						{
							player4.velocity = Vector2.Zero;
						}
						player4.vortexStealthActive = bitsByte10[3];
						player4.gravDir = (float)(bitsByte10[4] ? 1 : -1);
						if (Main.netMode == 2 && Netplay.Clients[this.whoAmI].State == 10)
						{
							NetMessage.SendData(13, -1, this.whoAmI, null, num44, 0f, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 14:
					{
						int num45 = (int)this.reader.ReadByte();
						int num46 = (int)this.reader.ReadByte();
						if (Main.netMode != 1)
						{
							return;
						}
						bool arg_224F_0 = Main.player[num45].active;
						if (num46 == 1)
						{
							if (!Main.player[num45].active)
							{
								Main.player[num45] = new Player();
							}
							Main.player[num45].active = true;
						}
						else
						{
							Main.player[num45].active = false;
						}
						if (arg_224F_0 == Main.player[num45].active)
						{
							return;
						}
						if (Main.player[num45].active)
						{
							Player.Hooks.PlayerConnect(num45);
							return;
						}
						Player.Hooks.PlayerDisconnect(num45);
						return;
					}
				case 15:
				case 25:
				case 26:
				case 44:
				case 67:
				case 93:
				case 94:
					return;
				case 16:
					{
						int num47 = (int)this.reader.ReadByte();
						if (num47 == Main.myPlayer && !Main.ServerSideCharacter)
						{
							return;
						}
						if (Main.netMode == 2)
						{
							num47 = this.whoAmI;
						}
						Player player5 = Main.player[num47];
						player5.statLife = (int)this.reader.ReadInt16();
						player5.statLifeMax = (int)this.reader.ReadInt16();
						if (player5.statLifeMax < 100)
						{
							player5.statLifeMax = 100;
						}
						player5.dead = (player5.statLife <= 0);
						if (Main.netMode == 2)
						{
							NetMessage.SendData(16, -1, this.whoAmI, null, num47, 0f, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 17:
					{
						byte b2 = this.reader.ReadByte();
						int num48 = (int)this.reader.ReadInt16();
						int num49 = (int)this.reader.ReadInt16();
						short num50 = this.reader.ReadInt16();
						int num51 = (int)this.reader.ReadByte();
						bool flag5 = num50 == 1;
						if (!WorldGen.InWorld(num48, num49, 3))
						{
							return;
						}
						if (Main.tile[num48, num49] == null)
						{
							Main.tile[num48, num49] = new Tile();
						}
						if (Main.netMode == 2)
						{
							if (!flag5)
							{
								if (b2 == 0 || b2 == 2 || b2 == 4)
								{
									Netplay.Clients[this.whoAmI].SpamDeleteBlock += 1f;
								}
								if (b2 == 1 || b2 == 3)
								{
									Netplay.Clients[this.whoAmI].SpamAddBlock += 1f;
								}
							}
							if (!Netplay.Clients[this.whoAmI].TileSections[Netplay.GetSectionX(num48), Netplay.GetSectionY(num49)])
							{
								flag5 = true;
							}
						}
						if (b2 == 0)
						{
							WorldGen.KillTile(num48, num49, flag5, false, false);
						}
						if (b2 == 1)
						{
							WorldGen.PlaceTile(num48, num49, (int)num50, false, true, -1, num51);
						}
						if (b2 == 2)
						{
							WorldGen.KillWall(num48, num49, flag5);
						}
						if (b2 == 3)
						{
							WorldGen.PlaceWall(num48, num49, (int)num50, false);
						}
						if (b2 == 4)
						{
							WorldGen.KillTile(num48, num49, flag5, false, true);
						}
						if (b2 == 5)
						{
							WorldGen.PlaceWire(num48, num49);
						}
						if (b2 == 6)
						{
							WorldGen.KillWire(num48, num49);
						}
						if (b2 == 7)
						{
							WorldGen.PoundTile(num48, num49);
						}
						if (b2 == 8)
						{
							WorldGen.PlaceActuator(num48, num49);
						}
						if (b2 == 9)
						{
							WorldGen.KillActuator(num48, num49);
						}
						if (b2 == 10)
						{
							WorldGen.PlaceWire2(num48, num49);
						}
						if (b2 == 11)
						{
							WorldGen.KillWire2(num48, num49);
						}
						if (b2 == 12)
						{
							WorldGen.PlaceWire3(num48, num49);
						}
						if (b2 == 13)
						{
							WorldGen.KillWire3(num48, num49);
						}
						if (b2 == 14)
						{
							WorldGen.SlopeTile(num48, num49, (int)num50);
						}
						if (b2 == 15)
						{
							Minecart.FrameTrack(num48, num49, true, false);
						}
						if (b2 == 16)
						{
							WorldGen.PlaceWire4(num48, num49);
						}
						if (b2 == 17)
						{
							WorldGen.KillWire4(num48, num49);
						}
						if (b2 == 18)
						{
							Wiring.SetCurrentUser(this.whoAmI);
							Wiring.PokeLogicGate(num48, num49);
							Wiring.SetCurrentUser(-1);
							return;
						}
						if (b2 == 19)
						{
							Wiring.SetCurrentUser(this.whoAmI);
							Wiring.Actuate(num48, num49);
							Wiring.SetCurrentUser(-1);
							return;
						}
						if (Main.netMode != 2)
						{
							return;
						}
						NetMessage.SendData(17, -1, this.whoAmI, null, (int)b2, (float)num48, (float)num49, (float)num50, num51, 0, 0);
						if (b2 == 1 && num50 == 53)
						{
							NetMessage.SendTileSquare(-1, num48, num49, 1, TileChangeType.None);
							return;
						}
						return;
					}
				case 18:
					if (Main.netMode != 1)
					{
						return;
					}
					Main.dayTime = (this.reader.ReadByte() == 1);
					Main.time = (double)this.reader.ReadInt32();
					Main.sunModY = this.reader.ReadInt16();
					Main.moonModY = this.reader.ReadInt16();
					return;
				case 19:
					{
						byte b3 = this.reader.ReadByte();
						int num52 = (int)this.reader.ReadInt16();
						int num53 = (int)this.reader.ReadInt16();
						if (!WorldGen.InWorld(num52, num53, 3))
						{
							return;
						}
						int num54 = (this.reader.ReadByte() == 0) ? -1 : 1;
						if (b3 == 0)
						{
							WorldGen.OpenDoor(num52, num53, num54);
						}
						else if (b3 == 1)
						{
							WorldGen.CloseDoor(num52, num53, true);
						}
						else if (b3 == 2)
						{
							WorldGen.ShiftTrapdoor(num52, num53, num54 == 1, 1);
						}
						else if (b3 == 3)
						{
							WorldGen.ShiftTrapdoor(num52, num53, num54 == 1, 0);
						}
						else if (b3 == 4)
						{
							WorldGen.ShiftTallGate(num52, num53, false);
						}
						else if (b3 == 5)
						{
							WorldGen.ShiftTallGate(num52, num53, true);
						}
						if (Main.netMode == 2)
						{
							NetMessage.SendData(19, -1, this.whoAmI, null, (int)b3, (float)num52, (float)num53, (float)((num54 == 1) ? 1 : 0), 0, 0, 0);
							return;
						}
						return;
					}
				case 20:
					{
						ushort expr_271D = this.reader.ReadUInt16();
						short num55 = (short)(expr_271D & 32767);
						bool arg_2733_0 = (expr_271D & 32768) > 0;
						byte b4 = 0;
						if (arg_2733_0)
						{
							b4 = this.reader.ReadByte();
						}
						int num56 = (int)this.reader.ReadInt16();
						int num57 = (int)this.reader.ReadInt16();
						if (!WorldGen.InWorld(num56, num57, 3))
						{
							return;
						}
						TileChangeType type3 = TileChangeType.None;
						if (Enum.IsDefined(typeof(TileChangeType), b4))
						{
							type3 = (TileChangeType)b4;
						}
						if (MessageBuffer.OnTileChangeReceived != null)
						{
							MessageBuffer.OnTileChangeReceived(num56, num57, (int)num55, type3);
						}
						BitsByte bitsByte11 = 0;
						BitsByte bitsByte12 = 0;
						for (int num58 = num56; num58 < num56 + (int)num55; num58++)
						{
							for (int num59 = num57; num59 < num57 + (int)num55; num59++)
							{
								if (Main.tile[num58, num59] == null)
								{
									Main.tile[num58, num59] = new Tile();
								}
								Tile tile = Main.tile[num58, num59];
								bool flag6 = tile.active();
								bitsByte11 = this.reader.ReadByte();
								bitsByte12 = this.reader.ReadByte();
								tile.active(bitsByte11[0]);
								tile.wall = ((byte)(bitsByte11[2] ? 1 : 0));
								bool flag7 = bitsByte11[3];
								if (Main.netMode != 2)
								{
									tile.liquid = ((byte)(flag7 ? 1 : 0));
								}
								tile.wire(bitsByte11[4]);
								tile.halfBrick(bitsByte11[5]);
								tile.actuator(bitsByte11[6]);
								tile.inActive(bitsByte11[7]);
								tile.wire2(bitsByte12[0]);
								tile.wire3(bitsByte12[1]);
								if (bitsByte12[2])
								{
									tile.color(this.reader.ReadByte());
								}
								if (bitsByte12[3])
								{
									tile.wallColor(this.reader.ReadByte());
								}
								if (tile.active())
								{
									int type4 = (int)tile.type;
									tile.type = this.reader.ReadUInt16();
									if (Main.tileFrameImportant[(int)tile.type])
									{
										tile.frameX = this.reader.ReadInt16();
										tile.frameY = this.reader.ReadInt16();
									}
									else if (!flag6 || (int)tile.type != type4)
									{
										tile.frameX = -1;
										tile.frameY = -1;
									}
									byte b5 = 0;
									if (bitsByte12[4])
									{
										b5 += 1;
									}
									if (bitsByte12[5])
									{
										b5 += 2;
									}
									if (bitsByte12[6])
									{
										b5 += 4;
									}
									tile.slope(b5);
								}
								tile.wire4(bitsByte12[7]);
								if (tile.wall > 0)
								{
									tile.wall = this.reader.ReadByte();
								}
								if (flag7)
								{
									tile.liquid = this.reader.ReadByte();
									tile.liquidType((int)this.reader.ReadByte());
								}
							}
						}
						WorldGen.RangeFrame(num56, num57, num56 + (int)num55, num57 + (int)num55);
						if (Main.netMode == 2)
						{
							NetMessage.SendData((int)b, -1, this.whoAmI, null, (int)num55, (float)num56, (float)num57, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 21:
				case 90:
					{
						int num60 = (int)this.reader.ReadInt16();
						Vector2 vector = this.reader.ReadVector2();
						Vector2 velocity = this.reader.ReadVector2();
						int stack3 = (int)this.reader.ReadInt16();
						int pre = (int)this.reader.ReadByte();
						int num61 = (int)this.reader.ReadByte();
						int num62 = (int)this.reader.ReadInt16();
						if (Main.netMode == 1)
						{
							if (num62 == 0)
							{
								Main.item[num60].active = false;
								return;
							}
							int num63 = num60;
							Item item = Main.item[num63];
							bool newAndShiny = (item.newAndShiny || item.netID != num62) && ItemSlot.Options.HighlightNewItems && (num62 < 0 || num62 >= 3930 || !ItemID.Sets.NeverShiny[num62]);
							item.netDefaults(num62);
							item.newAndShiny = newAndShiny;
							item.Prefix(pre);
							item.stack = stack3;
							item.position = vector;
							item.velocity = velocity;
							item.active = true;
							if (b == 90)
							{
								item.instanced = true;
								item.owner = Main.myPlayer;
								item.keepTime = 600;
							}
							item.wet = Collision.WetCollision(item.position, item.width, item.height);
							return;
						}
						else
						{
							if (Main.itemLockoutTime[num60] > 0)
							{
								return;
							}
							if (num62 == 0)
							{
								if (num60 < 400)
								{
									Main.item[num60].active = false;
									NetMessage.SendData(21, -1, -1, null, num60, 0f, 0f, 0f, 0, 0, 0);
									return;
								}
								return;
							}
							else
							{
								bool flag8 = false;
								if (num60 == 400)
								{
									flag8 = true;
								}
								if (flag8)
								{
									Item item2 = new Item();
									item2.netDefaults(num62);
									num60 = Item.NewItem((int)vector.X, (int)vector.Y, item2.width, item2.height, item2.type, stack3, true, 0, false, false);
								}
								Item expr_2C5E = Main.item[num60];
								expr_2C5E.netDefaults(num62);
								expr_2C5E.Prefix(pre);
								expr_2C5E.stack = stack3;
								expr_2C5E.position = vector;
								expr_2C5E.velocity = velocity;
								expr_2C5E.active = true;
								expr_2C5E.owner = Main.myPlayer;
								if (flag8)
								{
									NetMessage.SendData(21, -1, -1, null, num60, 0f, 0f, 0f, 0, 0, 0);
									if (num61 == 0)
									{
										Main.item[num60].ownIgnore = this.whoAmI;
										Main.item[num60].ownTime = 100;
									}
									Main.item[num60].FindOwner(num60);
									return;
								}
								NetMessage.SendData(21, -1, this.whoAmI, null, num60, 0f, 0f, 0f, 0, 0, 0);
								return;
							}
						}
						break;
					}
				case 22:
					{
						int num64 = (int)this.reader.ReadInt16();
						int num65 = (int)this.reader.ReadByte();
						if (Main.netMode == 2 && Main.item[num64].owner != this.whoAmI)
						{
							return;
						}
						Main.item[num64].owner = num65;
						if (num65 == Main.myPlayer)
						{
							Main.item[num64].keepTime = 15;
						}
						else
						{
							Main.item[num64].keepTime = 0;
						}
						if (Main.netMode == 2)
						{
							Main.item[num64].owner = 255;
							Main.item[num64].keepTime = 15;
							NetMessage.SendData(22, -1, -1, null, num64, 0f, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 23:
					{
						if (Main.netMode != 1)
						{
							return;
						}
						int num66 = (int)this.reader.ReadInt16();
						Vector2 vector2 = this.reader.ReadVector2();
						Vector2 velocity2 = this.reader.ReadVector2();
						int num67 = (int)this.reader.ReadUInt16();
						if (num67 == 65535)
						{
							num67 = 0;
						}
						BitsByte bitsByte13 = this.reader.ReadByte();
						float[] array2 = new float[NPC.maxAI];
						for (int num68 = 0; num68 < NPC.maxAI; num68++)
						{
							if (bitsByte13[num68 + 2])
							{
								array2[num68] = this.reader.ReadSingle();
							}
							else
							{
								array2[num68] = 0f;
							}
						}
						int num69 = (int)this.reader.ReadInt16();
						int num70 = 0;
						if (!bitsByte13[7])
						{
							byte b6 = this.reader.ReadByte();
							if (b6 == 2)
							{
								num70 = (int)this.reader.ReadInt16();
							}
							else if (b6 == 4)
							{
								num70 = this.reader.ReadInt32();
							}
							else
							{
								num70 = (int)this.reader.ReadSByte();
							}
						}
						int num71 = -1;
						NPC nPC = Main.npc[num66];
						if (!nPC.active || nPC.netID != num69)
						{
							if (nPC.active)
							{
								num71 = nPC.type;
							}
							nPC.active = true;
							nPC.SetDefaults(num69, -1f);
						}
						if (Vector2.DistanceSquared(nPC.position, vector2) < 6400f)
						{
							nPC.visualOffset = nPC.position - vector2;
						}
						nPC.position = vector2;
						nPC.velocity = velocity2;
						nPC.target = num67;
						nPC.direction = (bitsByte13[0] ? 1 : -1);
						nPC.directionY = (bitsByte13[1] ? 1 : -1);
						nPC.spriteDirection = (bitsByte13[6] ? 1 : -1);
						if (bitsByte13[7])
						{
							num70 = (nPC.life = nPC.lifeMax);
						}
						else
						{
							nPC.life = num70;
						}
						if (num70 <= 0)
						{
							nPC.active = false;
						}
						for (int num72 = 0; num72 < NPC.maxAI; num72++)
						{
							nPC.ai[num72] = array2[num72];
						}
						if (num71 > -1 && num71 != nPC.type)
						{
							nPC.TransformVisuals(num71, nPC.type);
						}
						if (num69 == 262)
						{
							NPC.plantBoss = num66;
						}
						if (num69 == 245)
						{
							NPC.golemBoss = num66;
						}
						if (nPC.type >= 0 && nPC.type < 580 && Main.npcCatchable[nPC.type])
						{
							nPC.releaseOwner = (short)this.reader.ReadByte();
							return;
						}
						return;
					}
				case 24:
					{
						int num73 = (int)this.reader.ReadInt16();
						int num74 = (int)this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							num74 = this.whoAmI;
						}
						Player player6 = Main.player[num74];
						Main.npc[num73].StrikeNPC(player6.inventory[player6.selectedItem].damage, player6.inventory[player6.selectedItem].knockBack, player6.direction, false, false, false);
						if (Main.netMode == 2)
						{
							NetMessage.SendData(24, -1, this.whoAmI, null, num73, (float)num74, 0f, 0f, 0, 0, 0);
							NetMessage.SendData(23, -1, -1, null, num73, 0f, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 27:
					{
						int num75 = (int)this.reader.ReadInt16();
						Vector2 position = this.reader.ReadVector2();
						Vector2 velocity3 = this.reader.ReadVector2();
						float knockBack = this.reader.ReadSingle();
						int damage = (int)this.reader.ReadInt16();
						int num76 = (int)this.reader.ReadByte();
						int num77 = (int)this.reader.ReadInt16();
						BitsByte bitsByte14 = this.reader.ReadByte();
						float[] array3 = new float[Projectile.maxAI];
						for (int num78 = 0; num78 < Projectile.maxAI; num78++)
						{
							if (bitsByte14[num78])
							{
								array3[num78] = this.reader.ReadSingle();
							}
							else
							{
								array3[num78] = 0f;
							}
						}
						int num79 = (int)(bitsByte14[Projectile.maxAI] ? this.reader.ReadInt16() : -1);
						if (num79 >= 1000)
						{
							num79 = -1;
						}
						if (Main.netMode == 2)
						{
							num76 = this.whoAmI;
							if (Main.projHostile[num77])
							{
								return;
							}
						}
						int num80 = 1000;
						for (int num81 = 0; num81 < 1000; num81++)
						{
							if (Main.projectile[num81].owner == num76 && Main.projectile[num81].identity == num75 && Main.projectile[num81].active)
							{
								num80 = num81;
								break;
							}
						}
						if (num80 == 1000)
						{
							for (int num82 = 0; num82 < 1000; num82++)
							{
								if (!Main.projectile[num82].active)
								{
									num80 = num82;
									break;
								}
							}
						}
						Projectile projectile = Main.projectile[num80];
						if (!projectile.active || projectile.type != num77)
						{
							projectile.SetDefaults(num77);
							if (Main.netMode == 2)
							{
								Netplay.Clients[this.whoAmI].SpamProjectile += 1f;
							}
						}
						projectile.identity = num75;
						projectile.position = position;
						projectile.velocity = velocity3;
						projectile.type = num77;
						projectile.damage = damage;
						projectile.knockBack = knockBack;
						projectile.owner = num76;
						for (int num83 = 0; num83 < Projectile.maxAI; num83++)
						{
							projectile.ai[num83] = array3[num83];
						}
						if (num79 >= 0)
						{
							projectile.projUUID = num79;
							Main.projectileIdentity[num76, num79] = num80;
						}
						projectile.ProjectileFixDesperation();
						if (Main.netMode == 2)
						{
							NetMessage.SendData(27, -1, this.whoAmI, null, num80, 0f, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 28:
					{
						int num84 = (int)this.reader.ReadInt16();
						int num85 = (int)this.reader.ReadInt16();
						float num86 = this.reader.ReadSingle();
						int num87 = (int)(this.reader.ReadByte() - 1);
						byte b7 = this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							if (num85 < 0)
							{
								num85 = 0;
							}
							Main.npc[num84].PlayerInteraction(this.whoAmI);
						}
						if (num85 >= 0)
						{
							Main.npc[num84].StrikeNPC(num85, num86, num87, b7 == 1, false, true);
						}
						else
						{
							Main.npc[num84].life = 0;
							Main.npc[num84].HitEffect(0, 10.0);
							Main.npc[num84].active = false;
						}
						if (Main.netMode != 2)
						{
							return;
						}
						NetMessage.SendData(28, -1, this.whoAmI, null, num84, (float)num85, num86, (float)num87, (int)b7, 0, 0);
						if (Main.npc[num84].life <= 0)
						{
							NetMessage.SendData(23, -1, -1, null, num84, 0f, 0f, 0f, 0, 0, 0);
						}
						else
						{
							Main.npc[num84].netUpdate = true;
						}
						if (Main.npc[num84].realLife < 0)
						{
							return;
						}
						if (Main.npc[Main.npc[num84].realLife].life <= 0)
						{
							NetMessage.SendData(23, -1, -1, null, Main.npc[num84].realLife, 0f, 0f, 0f, 0, 0, 0);
							return;
						}
						Main.npc[Main.npc[num84].realLife].netUpdate = true;
						return;
					}
				case 29:
					{
						int num88 = (int)this.reader.ReadInt16();
						int num89 = (int)this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							num89 = this.whoAmI;
						}
						for (int num90 = 0; num90 < 1000; num90++)
						{
							if (Main.projectile[num90].owner == num89 && Main.projectile[num90].identity == num88 && Main.projectile[num90].active)
							{
								Main.projectile[num90].Kill();
								break;
							}
						}
						if (Main.netMode == 2)
						{
							NetMessage.SendData(29, -1, this.whoAmI, null, num88, (float)num89, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 30:
					{
						int num91 = (int)this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							num91 = this.whoAmI;
						}
						bool flag9 = this.reader.ReadBoolean();
						Main.player[num91].hostile = flag9;
						if (Main.netMode == 2)
						{
							NetMessage.SendData(30, -1, this.whoAmI, null, num91, 0f, 0f, 0f, 0, 0, 0);
							LocalizedText arg_368A_0 = flag9 ? Lang.mp[11] : Lang.mp[12];
							Color color = Main.teamColor[Main.player[num91].team];
							NetMessage.BroadcastChatMessage(NetworkText.FromKey(arg_368A_0.Key, new object[]
							{
						Main.player[num91].name
							}), color, -1);
							return;
						}
						return;
					}
				case 31:
					{
						if (Main.netMode != 2)
						{
							return;
						}
						int arg_36D6_0 = (int)this.reader.ReadInt16();
						int y = (int)this.reader.ReadInt16();
						int num92 = Chest.FindChest(arg_36D6_0, y);
						if (num92 > -1 && Chest.UsingChest(num92) == -1)
						{
							for (int num93 = 0; num93 < 40; num93++)
							{
								NetMessage.SendData(32, this.whoAmI, -1, null, num92, (float)num93, 0f, 0f, 0, 0, 0);
							}
							NetMessage.SendData(33, this.whoAmI, -1, null, num92, 0f, 0f, 0f, 0, 0, 0);
							Main.player[this.whoAmI].chest = num92;
							if (Main.myPlayer == this.whoAmI)
							{
								Main.recBigList = false;
							}
							NetMessage.SendData(80, -1, this.whoAmI, null, this.whoAmI, (float)num92, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 32:
					{
						int num94 = (int)this.reader.ReadInt16();
						int num95 = (int)this.reader.ReadByte();
						int stack4 = (int)this.reader.ReadInt16();
						int pre2 = (int)this.reader.ReadByte();
						int type5 = (int)this.reader.ReadInt16();
						if (Main.chest[num94] == null)
						{
							Main.chest[num94] = new Chest(false);
						}
						if (Main.chest[num94].item[num95] == null)
						{
							Main.chest[num94].item[num95] = new Item();
						}
						Main.chest[num94].item[num95].netDefaults(type5);
						Main.chest[num94].item[num95].Prefix(pre2);
						Main.chest[num94].item[num95].stack = stack4;
						Recipe.FindRecipes();
						return;
					}
				case 33:
					{
						int num96 = (int)this.reader.ReadInt16();
						int num97 = (int)this.reader.ReadInt16();
						int num98 = (int)this.reader.ReadInt16();
						int num99 = (int)this.reader.ReadByte();
						string name = string.Empty;
						if (num99 != 0)
						{
							if (num99 <= 20)
							{
								name = this.reader.ReadString();
							}
							else if (num99 != 255)
							{
								num99 = 0;
							}
						}
						if (Main.netMode != 1)
						{
							if (num99 != 0)
							{
								int chest = Main.player[this.whoAmI].chest;
								Chest chest2 = Main.chest[chest];
								chest2.name = name;
								NetMessage.SendData(69, -1, this.whoAmI, null, chest, (float)chest2.x, (float)chest2.y, 0f, 0, 0, 0);
							}
							Main.player[this.whoAmI].chest = num96;
							Recipe.FindRecipes();
							NetMessage.SendData(80, -1, this.whoAmI, null, this.whoAmI, (float)num96, 0f, 0f, 0, 0, 0);
							return;
						}
						Player player7 = Main.player[Main.myPlayer];
						if (player7.chest == -1)
						{
							Main.playerInventory = true;
							Main.PlaySound(10, -1, -1, 1, 1f, 0f);
						}
						else if (player7.chest != num96 && num96 != -1)
						{
							Main.playerInventory = true;
							Main.PlaySound(12, -1, -1, 1, 1f, 0f);
							Main.recBigList = false;
						}
						else if (player7.chest != -1 && num96 == -1)
						{
							Main.PlaySound(11, -1, -1, 1, 1f, 0f);
							Main.recBigList = false;
						}
						player7.chest = num96;
						player7.chestX = num97;
						player7.chestY = num98;
						Recipe.FindRecipes();
						if (Main.tile[num97, num98].frameX >= 36 && Main.tile[num97, num98].frameX < 72)
						{
							AchievementsHelper.HandleSpecialEvent(Main.player[Main.myPlayer], 16);
							return;
						}
						return;
					}
				case 34:
					{
						byte b8 = this.reader.ReadByte();
						int num100 = (int)this.reader.ReadInt16();
						int num101 = (int)this.reader.ReadInt16();
						int num102 = (int)this.reader.ReadInt16();
						int num103 = (int)this.reader.ReadInt16();
						if (Main.netMode == 2)
						{
							num103 = 0;
						}
						if (Main.netMode == 2)
						{
							if (b8 == 0)
							{
								int num104 = WorldGen.PlaceChest(num100, num101, 21, false, num102);
								if (num104 == -1)
								{
									NetMessage.SendData(34, this.whoAmI, -1, null, (int)b8, (float)num100, (float)num101, (float)num102, num104, 0, 0);
									Item.NewItem(num100 * 16, num101 * 16, 32, 32, Chest.chestItemSpawn[num102], 1, true, 0, false, false);
									return;
								}
								NetMessage.SendData(34, -1, -1, null, (int)b8, (float)num100, (float)num101, (float)num102, num104, 0, 0);
								return;
							}
							else if (b8 == 1 && Main.tile[num100, num101].type == 21)
							{
								Tile expr_3B4A = Main.tile[num100, num101];
								if (expr_3B4A.frameX % 36 != 0)
								{
									num100--;
								}
								if (expr_3B4A.frameY % 36 != 0)
								{
									num101--;
								}
								int number = Chest.FindChest(num100, num101);
								WorldGen.KillTile(num100, num101, false, false, false);
								if (!expr_3B4A.active())
								{
									NetMessage.SendData(34, -1, -1, null, (int)b8, (float)num100, (float)num101, 0f, number, 0, 0);
									return;
								}
								return;
							}
							else if (b8 == 2)
							{
								int num105 = WorldGen.PlaceChest(num100, num101, 88, false, num102);
								if (num105 == -1)
								{
									NetMessage.SendData(34, this.whoAmI, -1, null, (int)b8, (float)num100, (float)num101, (float)num102, num105, 0, 0);
									Item.NewItem(num100 * 16, num101 * 16, 32, 32, Chest.dresserItemSpawn[num102], 1, true, 0, false, false);
									return;
								}
								NetMessage.SendData(34, -1, -1, null, (int)b8, (float)num100, (float)num101, (float)num102, num105, 0, 0);
								return;
							}
							else if (b8 == 3 && Main.tile[num100, num101].type == 88)
							{
								Tile tile2 = Main.tile[num100, num101];
								num100 -= (int)(tile2.frameX % 54 / 18);
								if (tile2.frameY % 36 != 0)
								{
									num101--;
								}
								int number2 = Chest.FindChest(num100, num101);
								WorldGen.KillTile(num100, num101, false, false, false);
								if (!tile2.active())
								{
									NetMessage.SendData(34, -1, -1, null, (int)b8, (float)num100, (float)num101, 0f, number2, 0, 0);
									return;
								}
								return;
							}
							else if (b8 == 4)
							{
								int num106 = WorldGen.PlaceChest(num100, num101, 467, false, num102);
								if (num106 == -1)
								{
									NetMessage.SendData(34, this.whoAmI, -1, null, (int)b8, (float)num100, (float)num101, (float)num102, num106, 0, 0);
									Item.NewItem(num100 * 16, num101 * 16, 32, 32, Chest.chestItemSpawn2[num102], 1, true, 0, false, false);
									return;
								}
								NetMessage.SendData(34, -1, -1, null, (int)b8, (float)num100, (float)num101, (float)num102, num106, 0, 0);
								return;
							}
							else
							{
								if (b8 != 5 || Main.tile[num100, num101].type != 467)
								{
									return;
								}
								Tile expr_3D59 = Main.tile[num100, num101];
								if (expr_3D59.frameX % 36 != 0)
								{
									num100--;
								}
								if (expr_3D59.frameY % 36 != 0)
								{
									num101--;
								}
								int number3 = Chest.FindChest(num100, num101);
								WorldGen.KillTile(num100, num101, false, false, false);
								if (!expr_3D59.active())
								{
									NetMessage.SendData(34, -1, -1, null, (int)b8, (float)num100, (float)num101, 0f, number3, 0, 0);
									return;
								}
								return;
							}
						}
						else if (b8 == 0)
						{
							if (num103 == -1)
							{
								WorldGen.KillTile(num100, num101, false, false, false);
								return;
							}
							WorldGen.PlaceChestDirect(num100, num101, 21, num102, num103);
							return;
						}
						else if (b8 == 2)
						{
							if (num103 == -1)
							{
								WorldGen.KillTile(num100, num101, false, false, false);
								return;
							}
							WorldGen.PlaceDresserDirect(num100, num101, 88, num102, num103);
							return;
						}
						else
						{
							if (b8 != 4)
							{
								Chest.DestroyChestDirect(num100, num101, num103);
								WorldGen.KillTile(num100, num101, false, false, false);
								return;
							}
							if (num103 == -1)
							{
								WorldGen.KillTile(num100, num101, false, false, false);
								return;
							}
							WorldGen.PlaceChestDirect(num100, num101, 467, num102, num103);
							return;
						}
						break;
					}
				case 35:
					{
						int num107 = (int)this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							num107 = this.whoAmI;
						}
						int num108 = (int)this.reader.ReadInt16();
						if (num107 != Main.myPlayer || Main.ServerSideCharacter)
						{
							Main.player[num107].HealEffect(num108, true);
						}
						if (Main.netMode == 2)
						{
							NetMessage.SendData(35, -1, this.whoAmI, null, num107, (float)num108, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 36:
					{
						int num109 = (int)this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							num109 = this.whoAmI;
						}
						Player expr_3EE3 = Main.player[num109];
						expr_3EE3.zone1 = this.reader.ReadByte();
						expr_3EE3.zone2 = this.reader.ReadByte();
						expr_3EE3.zone3 = this.reader.ReadByte();
						expr_3EE3.zone4 = this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							NetMessage.SendData(36, -1, this.whoAmI, null, num109, 0f, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 37:
					if (Main.netMode != 1)
					{
						return;
					}
					if (Main.autoPass)
					{
						NetMessage.SendData(38, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
						Main.autoPass = false;
						return;
					}
					Netplay.ServerPassword = "";
					Main.menuMode = 31;
					return;
				case 38:
					if (Main.netMode != 2)
					{
						return;
					}
					if (this.reader.ReadString() == Netplay.ServerPassword)
					{
						Netplay.Clients[this.whoAmI].State = 1;
						NetMessage.SendData(3, this.whoAmI, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
						return;
					}
					NetMessage.SendData(2, this.whoAmI, -1, Lang.mp[1].ToNetworkText(), 0, 0f, 0f, 0f, 0, 0, 0);
					return;
				case 39:
					{
						if (Main.netMode != 1)
						{
							return;
						}
						int num110 = (int)this.reader.ReadInt16();
						Main.item[num110].owner = 255;
						NetMessage.SendData(22, -1, -1, null, num110, 0f, 0f, 0f, 0, 0, 0);
						return;
					}
				case 40:
					{
						int num111 = (int)this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							num111 = this.whoAmI;
						}
						int talkNPC = (int)this.reader.ReadInt16();
						Main.player[num111].talkNPC = talkNPC;
						if (Main.netMode == 2)
						{
							NetMessage.SendData(40, -1, this.whoAmI, null, num111, 0f, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 41:
					{
						int num112 = (int)this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							num112 = this.whoAmI;
						}
						Player player8 = Main.player[num112];
						float itemRotation = this.reader.ReadSingle();
						int itemAnimation = (int)this.reader.ReadInt16();
						player8.itemRotation = itemRotation;
						player8.itemAnimation = itemAnimation;
						player8.channel = player8.inventory[player8.selectedItem].channel;
						if (Main.netMode == 2)
						{
							NetMessage.SendData(41, -1, this.whoAmI, null, num112, 0f, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 42:
					{
						int num113 = (int)this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							num113 = this.whoAmI;
						}
						else if (Main.myPlayer == num113 && !Main.ServerSideCharacter)
						{
							return;
						}
						int statMana = (int)this.reader.ReadInt16();
						int statManaMax = (int)this.reader.ReadInt16();
						Main.player[num113].statMana = statMana;
						Main.player[num113].statManaMax = statManaMax;
						return;
					}
				case 43:
					{
						int num114 = (int)this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							num114 = this.whoAmI;
						}
						int num115 = (int)this.reader.ReadInt16();
						if (num114 != Main.myPlayer)
						{
							Main.player[num114].ManaEffect(num115);
						}
						if (Main.netMode == 2)
						{
							NetMessage.SendData(43, -1, this.whoAmI, null, num114, (float)num115, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 45:
					{
						int num116 = (int)this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							num116 = this.whoAmI;
						}
						int num117 = (int)this.reader.ReadByte();
						Player player9 = Main.player[num116];
						int team = player9.team;
						player9.team = num117;
						Color color2 = Main.teamColor[num117];
						if (Main.netMode == 2)
						{
							NetMessage.SendData(45, -1, this.whoAmI, null, num116, 0f, 0f, 0f, 0, 0, 0);
							LocalizedText localizedText = Lang.mp[13 + num117];
							if (num117 == 5)
							{
								localizedText = Lang.mp[22];
							}
							for (int num118 = 0; num118 < 255; num118++)
							{
								if (num118 == this.whoAmI || (team > 0 && Main.player[num118].team == team) || (num117 > 0 && Main.player[num118].team == num117))
								{
									NetMessage.SendChatMessageToClient(NetworkText.FromKey(localizedText.Key, new object[]
									{
								player9.name
									}), color2, num118);
								}
							}
							return;
						}
						return;
					}
				case 46:
					{
						if (Main.netMode != 2)
						{
							return;
						}
						int arg_4386_0 = (int)this.reader.ReadInt16();
						int j2 = (int)this.reader.ReadInt16();
						int num119 = Sign.ReadSign(arg_4386_0, j2, true);
						if (num119 >= 0)
						{
							NetMessage.SendData(47, this.whoAmI, -1, null, num119, (float)this.whoAmI, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 47:
					{
						int num120 = (int)this.reader.ReadInt16();
						int x = (int)this.reader.ReadInt16();
						int y2 = (int)this.reader.ReadInt16();
						string text = this.reader.ReadString();
						string a = null;
						if (Main.sign[num120] != null)
						{
							a = Main.sign[num120].text;
						}
						Main.sign[num120] = new Sign();
						Main.sign[num120].x = x;
						Main.sign[num120].y = y2;
						Sign.TextSign(num120, text);
						int num121 = (int)this.reader.ReadByte();
						if (Main.netMode == 2 && a != text)
						{
							num121 = this.whoAmI;
							NetMessage.SendData(47, -1, this.whoAmI, null, num120, (float)num121, 0f, 0f, 0, 0, 0);
						}
						if (Main.netMode == 1 && num121 == Main.myPlayer && Main.sign[num120] != null)
						{
							Main.playerInventory = false;
							Main.player[Main.myPlayer].talkNPC = -1;
							Main.npcChatCornerItem = 0;
							Main.editSign = false;
							Main.PlaySound(10, -1, -1, 1, 1f, 0f);
							Main.player[Main.myPlayer].sign = num120;
							Main.npcChatText = Main.sign[num120].text;
							return;
						}
						return;
					}
				case 48:
					{
						int num122 = (int)this.reader.ReadInt16();
						int num123 = (int)this.reader.ReadInt16();
						byte liquid = this.reader.ReadByte();
						byte liquidType = this.reader.ReadByte();
						if (Main.netMode == 2 && Netplay.spamCheck)
						{
							int num124 = this.whoAmI;
							int num125 = (int)(Main.player[num124].position.X + (float)(Main.player[num124].width / 2));
							int arg_45B6_0 = (int)(Main.player[num124].position.Y + (float)(Main.player[num124].height / 2));
							int num126 = 10;
							int num127 = num125 - num126;
							int num128 = num125 + num126;
							int num129 = arg_45B6_0 - num126;
							int num130 = arg_45B6_0 + num126;
							if (num122 < num127 || num122 > num128 || num123 < num129 || num123 > num130)
							{
								NetMessage.BootPlayer(this.whoAmI, NetworkText.FromKey("Net.CheatingLiquidSpam", new object[0]));
								return;
							}
						}
						if (Main.tile[num122, num123] == null)
						{
							Main.tile[num122, num123] = new Tile();
						}
						Tile obj2 = Main.tile[num122, num123];
						lock (obj2)
						{
							Main.tile[num122, num123].liquid = liquid;
							Main.tile[num122, num123].liquidType((int)liquidType);
							if (Main.netMode == 2)
							{
								WorldGen.SquareTileFrame(num122, num123, true);
							}
							return;
						}
						goto IL_4681;
					}
				case 49:
					goto IL_4681;
				case 50:
					{
						int num131 = (int)this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							num131 = this.whoAmI;
						}
						else if (num131 == Main.myPlayer && !Main.ServerSideCharacter)
						{
							return;
						}
						Player player10 = Main.player[num131];
						for (int num132 = 0; num132 < 22; num132++)
						{
							player10.buffType[num132] = (int)this.reader.ReadByte();
							if (player10.buffType[num132] > 0)
							{
								player10.buffTime[num132] = 60;
							}
							else
							{
								player10.buffTime[num132] = 0;
							}
						}
						if (Main.netMode == 2)
						{
							NetMessage.SendData(50, -1, this.whoAmI, null, num131, 0f, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 51:
					{
						byte b9 = this.reader.ReadByte();
						byte b10 = this.reader.ReadByte();
						if (b10 == 1)
						{
							NpcMgr.SpawnSkeletron();
							return;
						}
						if (b10 == 2)
						{
							if (Main.netMode == 2)
							{
								NetMessage.SendData(51, -1, this.whoAmI, null, (int)b9, (float)b10, 0f, 0f, 0, 0, 0);
								return;
							}
							Main.PlaySound(SoundID.Item1, (int)Main.player[(int)b9].position.X, (int)Main.player[(int)b9].position.Y);
							return;
						}
						else if (b10 == 3)
						{
							if (Main.netMode == 2)
							{
								Main.Sundialing();
								return;
							}
							return;
						}
						else
						{
							if (b10 == 4)
							{
								Main.npc[(int)b9].BigMimicSpawnSmoke();
								return;
							}
							return;
						}
						break;
					}
				case 52:
					{
						int num133 = (int)this.reader.ReadByte();
						int num134 = (int)this.reader.ReadInt16();
						int num135 = (int)this.reader.ReadInt16();
						if (num133 == 1)
						{
							Chest.Unlock(num134, num135);
							if (Main.netMode == 2)
							{
								NetMessage.SendData(52, -1, this.whoAmI, null, 0, (float)num133, (float)num134, (float)num135, 0, 0, 0);
								NetMessage.SendTileSquare(-1, num134, num135, 2, TileChangeType.None);
							}
						}
						if (num133 != 2)
						{
							return;
						}
						WorldGen.UnlockDoor(num134, num135);
						if (Main.netMode == 2)
						{
							NetMessage.SendData(52, -1, this.whoAmI, null, 0, (float)num133, (float)num134, (float)num135, 0, 0, 0);
							NetMessage.SendTileSquare(-1, num134, num135, 2, TileChangeType.None);
							return;
						}
						return;
					}
				case 53:
					{
						int num136 = (int)this.reader.ReadInt16();
						int type6 = (int)this.reader.ReadByte();
						int time = (int)this.reader.ReadInt16();
						Main.npc[num136].AddBuff(type6, time, true);
						if (Main.netMode == 2)
						{
							NetMessage.SendData(54, -1, -1, null, num136, 0f, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 54:
					{
						if (Main.netMode != 1)
						{
							return;
						}
						int num137 = (int)this.reader.ReadInt16();
						NPC nPC2 = Main.npc[num137];
						for (int num138 = 0; num138 < 5; num138++)
						{
							nPC2.buffType[num138] = (int)this.reader.ReadByte();
							nPC2.buffTime[num138] = (int)this.reader.ReadInt16();
						}
						return;
					}
				case 55:
					{
						int num139 = (int)this.reader.ReadByte();
						int num140 = (int)this.reader.ReadByte();
						int num141 = this.reader.ReadInt32();
						if (Main.netMode == 2 && num139 != this.whoAmI && !Main.pvpBuff[num140])
						{
							return;
						}
						if (Main.netMode == 1 && num139 == Main.myPlayer)
						{
							Main.player[num139].AddBuff(num140, num141, true);
							return;
						}
						if (Main.netMode == 2)
						{
							NetMessage.SendData(55, num139, -1, null, num139, (float)num140, (float)num141, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 56:
					{
						int num142 = (int)this.reader.ReadInt16();
						if (num142 < 0 || num142 >= 200)
						{
							return;
						}
						if (Main.netMode == 1)
						{
							string givenName = this.reader.ReadString();
							Main.npc[num142].GivenName = givenName;
							return;
						}
						if (Main.netMode == 2)
						{
							NetMessage.SendData(56, this.whoAmI, -1, null, num142, 0f, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 57:
					if (Main.netMode != 1)
					{
						return;
					}
					WorldGen.tGood = this.reader.ReadByte();
					WorldGen.tEvil = this.reader.ReadByte();
					WorldGen.tBlood = this.reader.ReadByte();
					return;
				case 58:
					{
						int num143 = (int)this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							num143 = this.whoAmI;
						}
						float num144 = this.reader.ReadSingle();
						if (Main.netMode == 2)
						{
							NetMessage.SendData(58, -1, this.whoAmI, null, this.whoAmI, num144, 0f, 0f, 0, 0, 0);
							return;
						}
						Player player11 = Main.player[num143];
						Main.harpNote = num144;
						LegacySoundStyle type7 = SoundID.Item26;
						if (player11.inventory[player11.selectedItem].type == 507)
						{
							type7 = SoundID.Item35;
						}
						Main.PlaySound(type7, player11.position);
						return;
					}
				case 59:
					{
						int num145 = (int)this.reader.ReadInt16();
						int num146 = (int)this.reader.ReadInt16();
						Wiring.SetCurrentUser(this.whoAmI);
						Wiring.HitSwitch(num145, num146);
						Wiring.SetCurrentUser(-1);
						if (Main.netMode == 2)
						{
							NetMessage.SendData(59, -1, this.whoAmI, null, num145, (float)num146, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 60:
					{
						int num147 = (int)this.reader.ReadInt16();
						int num148 = (int)this.reader.ReadInt16();
						int num149 = (int)this.reader.ReadInt16();
						byte b11 = this.reader.ReadByte();
						if (num147 >= 200)
						{
							NetMessage.BootPlayer(this.whoAmI, NetworkText.FromKey("Net.CheatingInvalid", new object[0]));
							return;
						}
						if (Main.netMode == 1)
						{
							Main.npc[num147].homeless = (b11 == 1);
							Main.npc[num147].homeTileX = num148;
							Main.npc[num147].homeTileY = num149;
							if (b11 == 1)
							{
								WorldGen.TownManager.KickOut(Main.npc[num147].type);
								return;
							}
							if (b11 == 2)
							{
								WorldGen.TownManager.SetRoom(Main.npc[num147].type, num148, num149);
								return;
							}
							return;
						}
						else
						{
							if (b11 == 1)
							{
								WorldGen.kickOut(num147);
								return;
							}
							WorldGen.moveRoom(num148, num149, num147);
							return;
						}
						break;
					}
				case 61:
					{
						int plr = (int)this.reader.ReadInt16();
						int num150 = (int)this.reader.ReadInt16();
						if (Main.netMode != 2)
						{
							return;
						}
						if (num150 >= 0 && num150 < 580 && NPCID.Sets.MPAllowedEnemies[num150])
						{
							if (!NPC.AnyNPCs(num150))
							{
								NpcMgr.SpawnOnPlayer(plr, num150);
								return;
							}
							return;
						}
						else if (num150 == -4)
						{
							if (!Main.dayTime && !DD2Event.Ongoing)
							{
								NetMessage.BroadcastChatMessage(NetworkText.FromKey(Lang.misc[31].Key, new object[0]), new Color(50, 255, 130), -1);
								Main.startPumpkinMoon();
								NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
								NetMessage.SendData(78, -1, -1, null, 0, 1f, 2f, 1f, 0, 0, 0);
								return;
							}
							return;
						}
						else if (num150 == -5)
						{
							if (!Main.dayTime && !DD2Event.Ongoing)
							{
								NetMessage.BroadcastChatMessage(NetworkText.FromKey(Lang.misc[34].Key, new object[0]), new Color(50, 255, 130), -1);
								Main.startSnowMoon();
								NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
								NetMessage.SendData(78, -1, -1, null, 0, 1f, 1f, 1f, 0, 0, 0);
								return;
							}
							return;
						}
						else if (num150 == -6)
						{
							if (Main.dayTime && !Main.eclipse)
							{
								NetMessage.BroadcastChatMessage(NetworkText.FromKey(Lang.misc[20].Key, new object[0]), new Color(50, 255, 130), -1);
								Main.eclipse = true;
								NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
								return;
							}
							return;
						}
						else
						{
							if (num150 == -7)
							{
								Main.invasionDelay = 0;
								Main.StartInvasion(4);
								NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
								NetMessage.SendData(78, -1, -1, null, 0, 1f, (float)(Main.invasionType + 3), 0f, 0, 0, 0);
								return;
							}
							if (num150 == -8)
							{
								if (NpcMgr.downedGolemBoss && Main.hardMode && !NPC.AnyDanger() && !NPC.AnyoneNearCultists())
								{
									WorldGen.StartImpendingDoom();
									NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
									return;
								}
								return;
							}
							else
							{
								if (num150 < 0)
								{
									int num151 = 1;
									if (num150 > -5)
									{
										num151 = -num150;
									}
									if (num151 > 0 && Main.invasionType == 0)
									{
										Main.invasionDelay = 0;
										Main.StartInvasion(num151);
									}
									NetMessage.SendData(78, -1, -1, null, 0, 1f, (float)(Main.invasionType + 3), 0f, 0, 0, 0);
									return;
								}
								return;
							}
						}
						break;
					}
				case 62:
					{
						int num152 = (int)this.reader.ReadByte();
						int num153 = (int)this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							num152 = this.whoAmI;
						}
						if (num153 == 1)
						{
							Main.player[num152].NinjaDodge();
						}
						if (num153 == 2)
						{
							Main.player[num152].ShadowDodge();
						}
						if (Main.netMode == 2)
						{
							NetMessage.SendData(62, -1, this.whoAmI, null, num152, (float)num153, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 63:
					{
						int num154 = (int)this.reader.ReadInt16();
						int num155 = (int)this.reader.ReadInt16();
						byte b12 = this.reader.ReadByte();
						WorldGen.paintTile(num154, num155, b12, false);
						if (Main.netMode == 2)
						{
							NetMessage.SendData(63, -1, this.whoAmI, null, num154, (float)num155, (float)b12, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 64:
					{
						int num156 = (int)this.reader.ReadInt16();
						int num157 = (int)this.reader.ReadInt16();
						byte b13 = this.reader.ReadByte();
						WorldGen.paintWall(num156, num157, b13, false);
						if (Main.netMode == 2)
						{
							NetMessage.SendData(64, -1, this.whoAmI, null, num156, (float)num157, (float)b13, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 65:
					{
						BitsByte bitsByte15 = this.reader.ReadByte();
						int num158 = (int)this.reader.ReadInt16();
						if (Main.netMode == 2)
						{
							num158 = this.whoAmI;
						}
						Vector2 vector3 = this.reader.ReadVector2();
						int num159 = 0;
						int num160 = 0;
						if (bitsByte15[0])
						{
							num159++;
						}
						if (bitsByte15[1])
						{
							num159 += 2;
						}
						if (bitsByte15[2])
						{
							num160++;
						}
						if (bitsByte15[3])
						{
							num160 += 2;
						}
						if (num159 == 0)
						{
							Main.player[num158].Teleport(vector3, num160, 0);
						}
						else if (num159 == 1)
						{
							Main.npc[num158].Teleport(vector3, num160, 0);
						}
						else if (num159 == 2)
						{
							Main.player[num158].Teleport(vector3, num160, 0);
							if (Main.netMode == 2)
							{
								RemoteClient.CheckSection(this.whoAmI, vector3, 1);
								NetMessage.SendData(65, -1, -1, null, 0, (float)num158, vector3.X, vector3.Y, num160, 0, 0);
								int num161 = -1;
								float num162 = 9999f;
								for (int num163 = 0; num163 < 255; num163++)
								{
									if (Main.player[num163].active && num163 != this.whoAmI)
									{
										Vector2 vector4 = Main.player[num163].position - Main.player[this.whoAmI].position;
										if (vector4.Length() < num162)
										{
											num162 = vector4.Length();
											num161 = num163;
										}
									}
								}
								if (num161 >= 0)
								{
									NetMessage.BroadcastChatMessage(NetworkText.FromKey("Game.HasTeleportedTo", new object[]
									{
								Main.player[this.whoAmI].name,
								Main.player[num161].name
									}), new Color(250, 250, 0), -1);
								}
							}
						}
						if (Main.netMode == 2 && num159 == 0)
						{
							NetMessage.SendData(65, -1, this.whoAmI, null, 0, (float)num158, vector3.X, vector3.Y, num160, 0, 0);
							return;
						}
						return;
					}
				case 66:
					{
						int num164 = (int)this.reader.ReadByte();
						int num165 = (int)this.reader.ReadInt16();
						if (num165 <= 0)
						{
							return;
						}
						Player player12 = Main.player[num164];
						player12.statLife += num165;
						if (player12.statLife > player12.statLifeMax2)
						{
							player12.statLife = player12.statLifeMax2;
						}
						player12.HealEffect(num165, false);
						if (Main.netMode == 2)
						{
							NetMessage.SendData(66, -1, this.whoAmI, null, num164, (float)num165, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 68:
					this.reader.ReadString();
					return;
				case 69:
					{
						int num166 = (int)this.reader.ReadInt16();
						int num167 = (int)this.reader.ReadInt16();
						int num168 = (int)this.reader.ReadInt16();
						if (Main.netMode == 1)
						{
							if (num166 < 0 || num166 >= 1000)
							{
								return;
							}
							Chest chest3 = Main.chest[num166];
							if (chest3 == null)
							{
								chest3 = new Chest(false);
								chest3.x = num167;
								chest3.y = num168;
								Main.chest[num166] = chest3;
							}
							else if (chest3.x != num167 || chest3.y != num168)
							{
								return;
							}
							chest3.name = this.reader.ReadString();
							return;
						}
						else
						{
							if (num166 < -1 || num166 >= 1000)
							{
								return;
							}
							if (num166 == -1)
							{
								num166 = Chest.FindChest(num167, num168);
								if (num166 == -1)
								{
									return;
								}
							}
							Chest chest4 = Main.chest[num166];
							if (chest4.x != num167 || chest4.y != num168)
							{
								return;
							}
							NetMessage.SendData(69, this.whoAmI, -1, null, num166, (float)num167, (float)num168, 0f, 0, 0, 0);
							return;
						}
						break;
					}
				case 70:
					{
						if (Main.netMode != 2)
						{
							return;
						}
						int num169 = (int)this.reader.ReadInt16();
						int who = (int)this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							who = this.whoAmI;
						}
						if (num169 < 200 && num169 >= 0)
						{
							NPC.CatchNPC(num169, who);
							return;
						}
						return;
					}
				case 71:
					{
						if (Main.netMode != 2)
						{
							return;
						}
						int arg_5831_0 = this.reader.ReadInt32();
						int y3 = this.reader.ReadInt32();
						int type8 = (int)this.reader.ReadInt16();
						byte style = this.reader.ReadByte();
						NPC.ReleaseNPC(arg_5831_0, y3, type8, (int)style, this.whoAmI);
						return;
					}
				case 72:
					if (Main.netMode != 1)
					{
						return;
					}
					for (int num170 = 0; num170 < 40; num170++)
					{
						Main.travelShop[num170] = (int)this.reader.ReadInt16();
					}
					return;
				case 73:
					Main.player[this.whoAmI].TeleportationPotion();
					return;
				case 74:
					if (Main.netMode != 1)
					{
						return;
					}
					Main.anglerQuest = (int)this.reader.ReadByte();
					Main.anglerQuestFinished = this.reader.ReadBoolean();
					return;
				case 75:
					{
						if (Main.netMode != 2)
						{
							return;
						}
						string name2 = Main.player[this.whoAmI].name;
						if (!Main.anglerWhoFinishedToday.Contains(name2))
						{
							Main.anglerWhoFinishedToday.Add(name2);
							return;
						}
						return;
					}
				case 76:
					{
						int num171 = (int)this.reader.ReadByte();
						if (num171 == Main.myPlayer && !Main.ServerSideCharacter)
						{
							return;
						}
						if (Main.netMode == 2)
						{
							num171 = this.whoAmI;
						}
						Main.player[num171].anglerQuestsFinished = this.reader.ReadInt32();
						if (Main.netMode == 2)
						{
							NetMessage.SendData(76, -1, this.whoAmI, null, num171, 0f, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 77:
					{
						int arg_59D4_0 = (int)this.reader.ReadInt16();
						ushort tileType = this.reader.ReadUInt16();
						short x2 = this.reader.ReadInt16();
						short y4 = this.reader.ReadInt16();
						Animation.NewTemporaryAnimation(arg_59D4_0, tileType, (int)x2, (int)y4);
						return;
					}
				case 78:
					if (Main.netMode != 1)
					{
						return;
					}
					Main.ReportInvasionProgress(this.reader.ReadInt32(), this.reader.ReadInt32(), (int)this.reader.ReadSByte(), (int)this.reader.ReadSByte());
					return;
				case 79:
					{
						int x3 = (int)this.reader.ReadInt16();
						int y5 = (int)this.reader.ReadInt16();
						short type9 = this.reader.ReadInt16();
						int style2 = (int)this.reader.ReadInt16();
						int num172 = (int)this.reader.ReadByte();
						int random = (int)this.reader.ReadSByte();
						int direction;
						if (this.reader.ReadBoolean())
						{
							direction = 1;
						}
						else
						{
							direction = -1;
						}
						if (Main.netMode == 2)
						{
							Netplay.Clients[this.whoAmI].SpamAddBlock += 1f;
							if (!WorldGen.InWorld(x3, y5, 10) || !Netplay.Clients[this.whoAmI].TileSections[Netplay.GetSectionX(x3), Netplay.GetSectionY(y5)])
							{
								return;
							}
						}
						WorldGen.PlaceObject(x3, y5, (int)type9, false, style2, num172, random, direction);
						if (Main.netMode == 2)
						{
							NetMessage.SendObjectPlacment(this.whoAmI, x3, y5, (int)type9, style2, num172, random, direction);
							return;
						}
						return;
					}
				case 80:
					{
						if (Main.netMode != 1)
						{
							return;
						}
						int num173 = (int)this.reader.ReadByte();
						int num174 = (int)this.reader.ReadInt16();
						if (num174 >= -3 && num174 < 1000)
						{
							Main.player[num173].chest = num174;
							Recipe.FindRecipes();
							return;
						}
						return;
					}
				case 81:
					{
						if (Main.netMode != 1)
						{
							return;
						}
						int arg_5C29_0 = (int)this.reader.ReadSingle();
						int y6 = (int)this.reader.ReadSingle();
						Color color3 = this.reader.ReadRGB();
						int amount = this.reader.ReadInt32();
						CombatText.NewText(new Rectangle(arg_5C29_0, y6, 0, 0), color3, amount, false, false);
						return;
					}
				case 82:
					NetManager.Instance.Read(this.reader, this.whoAmI);
					return;
				case 83:
					{
						if (Main.netMode != 1)
						{
							return;
						}
						int num175 = (int)this.reader.ReadInt16();
						int num176 = this.reader.ReadInt32();
						if (num175 >= 0 && num175 < 267)
						{
							NPC.killCount[num175] = num176;
							return;
						}
						return;
					}
				case 84:
					{
						int num177 = (int)this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							num177 = this.whoAmI;
						}
						float stealth = this.reader.ReadSingle();
						Main.player[num177].stealth = stealth;
						if (Main.netMode == 2)
						{
							NetMessage.SendData(84, -1, this.whoAmI, null, num177, 0f, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 85:
					{
						int num178 = this.whoAmI;
						byte b14 = this.reader.ReadByte();
						if (Main.netMode == 2 && num178 < 255 && b14 < 58)
						{
							Chest.ServerPlaceItem(this.whoAmI, (int)b14);
							return;
						}
						return;
					}
				case 86:
					{
						if (Main.netMode != 1)
						{
							return;
						}
						int num179 = this.reader.ReadInt32();
						if (this.reader.ReadBoolean())
						{
							TileEntity tileEntity = TileEntity.Read(this.reader, true);
							tileEntity.ID = num179;
							TileEntity.ByID[tileEntity.ID] = tileEntity;
							TileEntity.ByPosition[tileEntity.Position] = tileEntity;
							return;
						}
						TileEntity tileEntity2;
						if (TileEntity.ByID.TryGetValue(num179, out tileEntity2) && (tileEntity2 is TETrainingDummy || tileEntity2 is TEItemFrame || tileEntity2 is TELogicSensor))
						{
							TileEntity.ByID.Remove(num179);
							TileEntity.ByPosition.Remove(tileEntity2.Position);
							return;
						}
						return;
					}
				case 87:
					{
						if (Main.netMode != 2)
						{
							return;
						}
						int x4 = (int)this.reader.ReadInt16();
						int y7 = (int)this.reader.ReadInt16();
						int type10 = (int)this.reader.ReadByte();
						if (!WorldGen.InWorld(x4, y7, 0))
						{
							return;
						}
						if (TileEntity.ByPosition.ContainsKey(new Point16(x4, y7)))
						{
							return;
						}
						TileEntity.PlaceEntityNet(x4, y7, type10);
						return;
					}
				case 88:
					{
						if (Main.netMode != 1)
						{
							return;
						}
						int num180 = (int)this.reader.ReadInt16();
						if (num180 < 0 || num180 > 400)
						{
							return;
						}
						Item item3 = Main.item[num180];
						BitsByte bitsByte16 = this.reader.ReadByte();
						if (bitsByte16[0])
						{
							item3.color.PackedValue = this.reader.ReadUInt32();
						}
						if (bitsByte16[1])
						{
							item3.damage = (int)this.reader.ReadUInt16();
						}
						if (bitsByte16[2])
						{
							item3.knockBack = this.reader.ReadSingle();
						}
						if (bitsByte16[3])
						{
							item3.useAnimation = (int)this.reader.ReadUInt16();
						}
						if (bitsByte16[4])
						{
							item3.useTime = (int)this.reader.ReadUInt16();
						}
						if (bitsByte16[5])
						{
							item3.shoot = (int)this.reader.ReadInt16();
						}
						if (bitsByte16[6])
						{
							item3.shootSpeed = this.reader.ReadSingle();
						}
						if (!bitsByte16[7])
						{
							return;
						}
						bitsByte16 = this.reader.ReadByte();
						if (bitsByte16[0])
						{
							item3.width = (int)this.reader.ReadInt16();
						}
						if (bitsByte16[1])
						{
							item3.height = (int)this.reader.ReadInt16();
						}
						if (bitsByte16[2])
						{
							item3.scale = this.reader.ReadSingle();
						}
						if (bitsByte16[3])
						{
							item3.ammo = (int)this.reader.ReadInt16();
						}
						if (bitsByte16[4])
						{
							item3.useAmmo = (int)this.reader.ReadInt16();
						}
						if (bitsByte16[5])
						{
							item3.notAmmo = this.reader.ReadBoolean();
							return;
						}
						return;
					}
				case 89:
					{
						if (Main.netMode != 2)
						{
							return;
						}
						int arg_6242_0 = (int)this.reader.ReadInt16();
						int y8 = (int)this.reader.ReadInt16();
						int netid = (int)this.reader.ReadInt16();
						int prefix = (int)this.reader.ReadByte();
						int stack5 = (int)this.reader.ReadInt16();
						TEItemFrame.TryPlacing(arg_6242_0, y8, netid, prefix, stack5);
						return;
					}
				case 91:
					{
						if (Main.netMode != 1)
						{
							return;
						}
						int num181 = this.reader.ReadInt32();
						int num182 = (int)this.reader.ReadByte();
						if (num182 != 255)
						{
							int meta = (int)this.reader.ReadUInt16();
							int num183 = (int)this.reader.ReadByte();
							int num184 = (int)this.reader.ReadByte();
							int metadata = 0;
							if (num184 < 0)
							{
								metadata = (int)this.reader.ReadInt16();
							}
							WorldUIAnchor worldUIAnchor = EmoteBubble.DeserializeNetAnchor(num182, meta);
							Dictionary<int, EmoteBubble> byID = EmoteBubble.byID;
							lock (byID)
							{
								if (!EmoteBubble.byID.ContainsKey(num181))
								{
									EmoteBubble.byID[num181] = new EmoteBubble(num184, worldUIAnchor, num183);
								}
								else
								{
									EmoteBubble.byID[num181].lifeTime = num183;
									EmoteBubble.byID[num181].lifeTimeStart = num183;
									EmoteBubble.byID[num181].emote = num184;
									EmoteBubble.byID[num181].anchor = worldUIAnchor;
								}
								EmoteBubble.byID[num181].ID = num181;
								EmoteBubble.byID[num181].metadata = metadata;
								return;
							}
							goto IL_641F;
						}
						if (EmoteBubble.byID.ContainsKey(num181))
						{
							EmoteBubble.byID.Remove(num181);
							return;
						}
						return;
					}
				case 92:
					goto IL_641F;
				case 95:
					{
						ushort num185 = this.reader.ReadUInt16();
						if (Main.netMode != 2)
						{
							return;
						}
						if (num185 < 0 || num185 >= 1000)
						{
							return;
						}
						Projectile projectile2 = Main.projectile[(int)num185];
						if (projectile2.type == 602)
						{
							projectile2.Kill();
							NetMessage.SendData(29, -1, -1, null, projectile2.whoAmI, (float)projectile2.owner, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 96:
					{
						int num186 = (int)this.reader.ReadByte();
						Player arg_6608_0 = Main.player[num186];
						int num187 = (int)this.reader.ReadInt16();
						Vector2 newPos = this.reader.ReadVector2();
						Vector2 velocity4 = this.reader.ReadVector2();
						int lastPortalColorIndex = num187 + ((num187 % 2 == 0) ? 1 : -1);
						arg_6608_0.lastPortalColorIndex = lastPortalColorIndex;
						arg_6608_0.Teleport(newPos, 4, num187);
						arg_6608_0.velocity = velocity4;
						return;
					}
				case 97:
					if (Main.netMode != 1)
					{
						return;
					}
					AchievementsHelper.NotifyNPCKilledDirect(Main.player[Main.myPlayer], (int)this.reader.ReadInt16());
					return;
				case 98:
					if (Main.netMode != 1)
					{
						return;
					}
					AchievementsHelper.NotifyProgressionEvent((int)this.reader.ReadInt16());
					return;
				case 99:
					{
						int num188 = (int)this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							num188 = this.whoAmI;
						}
						Main.player[num188].MinionRestTargetPoint = this.reader.ReadVector2();
						if (Main.netMode == 2)
						{
							NetMessage.SendData(99, -1, this.whoAmI, null, num188, 0f, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 100:
					{
						int num189 = (int)this.reader.ReadUInt16();
						NPC arg_67C5_0 = Main.npc[num189];
						int num190 = (int)this.reader.ReadInt16();
						Vector2 newPos2 = this.reader.ReadVector2();
						Vector2 velocity5 = this.reader.ReadVector2();
						int lastPortalColorIndex2 = num190 + ((num190 % 2 == 0) ? 1 : -1);
						arg_67C5_0.lastPortalColorIndex = lastPortalColorIndex2;
						arg_67C5_0.Teleport(newPos2, 4, num190);
						arg_67C5_0.velocity = velocity5;
						return;
					}
				case 101:
					if (Main.netMode == 2)
					{
						return;
					}
                    NpcMgr.ShieldStrengthTowerSolar = (int)this.reader.ReadUInt16();
                    NpcMgr.ShieldStrengthTowerVortex = (int)this.reader.ReadUInt16();
                    NpcMgr.ShieldStrengthTowerNebula = (int)this.reader.ReadUInt16();
                    NpcMgr.ShieldStrengthTowerStardust = (int)this.reader.ReadUInt16();
                    if (NpcMgr.ShieldStrengthTowerSolar < 0)
					{
                        NpcMgr.ShieldStrengthTowerSolar = 0;
					}
                    if (NpcMgr.ShieldStrengthTowerVortex < 0)
					{
                        NpcMgr.ShieldStrengthTowerVortex = 0;
					}
                    if (NpcMgr.ShieldStrengthTowerNebula < 0)
					{
                        NpcMgr.ShieldStrengthTowerNebula = 0;
					}
                    if (NpcMgr.ShieldStrengthTowerStardust < 0)
					{
                        NpcMgr.ShieldStrengthTowerStardust = 0;
					}
                    if (NpcMgr.ShieldStrengthTowerSolar > NPC.LunarShieldPowerExpert)
					{
                        NpcMgr.ShieldStrengthTowerSolar = NPC.LunarShieldPowerExpert;
					}
                    if (NpcMgr.ShieldStrengthTowerVortex > NPC.LunarShieldPowerExpert)
					{
                        NpcMgr.ShieldStrengthTowerVortex = NPC.LunarShieldPowerExpert;
					}
                    if (NpcMgr.ShieldStrengthTowerNebula > NPC.LunarShieldPowerExpert)
					{
                        NpcMgr.ShieldStrengthTowerNebula = NPC.LunarShieldPowerExpert;
					}
                    if (NpcMgr.ShieldStrengthTowerStardust > NPC.LunarShieldPowerExpert)
					{
                        NpcMgr.ShieldStrengthTowerStardust = NPC.LunarShieldPowerExpert;
						return;
					}
					return;
				case 102:
					{
						int num191 = (int)this.reader.ReadByte();
						byte b15 = this.reader.ReadByte();
						Vector2 vector5 = this.reader.ReadVector2();
						if (Main.netMode == 2)
						{
							num191 = this.whoAmI;
							NetMessage.SendData(102, -1, -1, null, num191, (float)b15, vector5.X, vector5.Y, 0, 0, 0);
							return;
						}
						Player player13 = Main.player[num191];
						for (int num192 = 0; num192 < 255; num192++)
						{
							Player player14 = Main.player[num192];
							if (player14.active && !player14.dead && (player13.team == 0 || player13.team == player14.team) && player14.Distance(vector5) < 700f)
							{
								Vector2 value = player13.Center - player14.Center;
								Vector2 vector6 = Vector2.Normalize(value);
								if (!vector6.HasNaNs())
								{
									int type11 = 90;
									float num193 = 0f;
									float num194 = 0.209439516f;
									Vector2 spinningpoint = new Vector2(0f, -8f);
									Vector2 value2 = new Vector2(-3f);
									float num195 = 0f;
									float num196 = 0.005f;
									if (b15 != 173)
									{
										if (b15 != 176)
										{
											if (b15 == 179)
											{
												type11 = 86;
											}
										}
										else
										{
											type11 = 88;
										}
									}
									else
									{
										type11 = 90;
									}
									int num197 = 0;
									while ((float)num197 < value.Length() / 6f)
									{
										Vector2 arg_6B5C_0 = player14.Center + 6f * (float)num197 * vector6 + spinningpoint.RotatedBy((double)num193, default(Vector2)) + value2;
										num193 += num194;
										int num198 = Dust.NewDust(arg_6B5C_0, 6, 6, type11, 0f, 0f, 100, default(Color), 1.5f);
										Main.dust[num198].noGravity = true;
										Main.dust[num198].velocity = Vector2.Zero;
										num195 = (Main.dust[num198].fadeIn = num195 + num196);
										Main.dust[num198].velocity += vector6 * 1.5f;
										num197++;
									}
								}
								player14.NebulaLevelup((int)b15);
							}
						}
						return;
					}
				case 103:
					if (Main.netMode == 1)
					{
						NpcMgr.MoonLordCountdown = this.reader.ReadInt32();
						return;
					}
					return;
				case 104:
					{
						if (Main.netMode != 1 || Main.npcShop <= 0)
						{
							return;
						}
						Item[] item4 = Main.instance.shop[Main.npcShop].item;
						int num199 = (int)this.reader.ReadByte();
						int type12 = (int)this.reader.ReadInt16();
						int stack6 = (int)this.reader.ReadInt16();
						int pre3 = (int)this.reader.ReadByte();
						int value3 = this.reader.ReadInt32();
						BitsByte bitsByte17 = this.reader.ReadByte();
						if (num199 < item4.Length)
						{
							item4[num199] = new Item();
							item4[num199].netDefaults(type12);
							item4[num199].stack = stack6;
							item4[num199].Prefix(pre3);
							item4[num199].value = value3;
							item4[num199].buyOnce = bitsByte17[0];
							return;
						}
						return;
					}
				case 105:
					{
						if (Main.netMode == 1)
						{
							return;
						}
						int arg_6DDA_0 = (int)this.reader.ReadInt16();
						int j3 = (int)this.reader.ReadInt16();
						bool on = this.reader.ReadBoolean();
						WorldGen.ToggleGemLock(arg_6DDA_0, j3, on);
						return;
					}
				case 106:
					{
						if (Main.netMode != 1)
						{
							return;
						}
						HalfVector2 halfVector = default(HalfVector2);
						halfVector.PackedValue = this.reader.ReadUInt32();
						Utils.PoofOfSmoke(halfVector.ToVector2());
						return;
					}
				case 107:
					{
						if (Main.netMode != 1)
						{
							return;
						}
						Color c = this.reader.ReadRGB();
						string arg_6E64_0 = NetworkText.Deserialize(this.reader).ToString();
						int widthLimit = (int)this.reader.ReadInt16();
						Main.NewTextMultiline(arg_6E64_0, false, c, widthLimit);
						return;
					}
				case 108:
					{
						if (Main.netMode != 1)
						{
							return;
						}
						int damage2 = (int)this.reader.ReadInt16();
						float knockBack2 = this.reader.ReadSingle();
						int x5 = (int)this.reader.ReadInt16();
						int y9 = (int)this.reader.ReadInt16();
						int angle = (int)this.reader.ReadInt16();
						int ammo = (int)this.reader.ReadInt16();
						int num200 = (int)this.reader.ReadByte();
						if (num200 != Main.myPlayer)
						{
							return;
						}
						WorldGen.ShootFromCannon(x5, y9, angle, ammo, damage2, knockBack2, num200);
						return;
					}
				case 109:
					{
						if (Main.netMode != 2)
						{
							return;
						}
						int arg_6F9C_0 = (int)this.reader.ReadInt16();
						int y10 = (int)this.reader.ReadInt16();
						int x6 = (int)this.reader.ReadInt16();
						int y11 = (int)this.reader.ReadInt16();
						WiresUI.Settings.MultiToolMode arg_6F91_0 = (WiresUI.Settings.MultiToolMode)this.reader.ReadByte();
						int num201 = this.whoAmI;
						WiresUI.Settings.MultiToolMode toolMode = WiresUI.Settings.ToolMode;
						WiresUI.Settings.ToolMode = arg_6F91_0;
						Wiring.MassWireOperation(new Point(arg_6F9C_0, y10), new Point(x6, y11), Main.player[num201]);
						WiresUI.Settings.ToolMode = toolMode;
						return;
					}
				case 110:
					{
						if (Main.netMode != 1)
						{
							return;
						}
						int type13 = (int)this.reader.ReadInt16();
						int num202 = (int)this.reader.ReadInt16();
						int num203 = (int)this.reader.ReadByte();
						if (num203 != Main.myPlayer)
						{
							return;
						}
						Player player15 = Main.player[num203];
						for (int num204 = 0; num204 < num202; num204++)
						{
							player15.ConsumeItem(type13, false);
						}
						player15.wireOperationsCooldown = 0;
						return;
					}
				case 111:
					if (Main.netMode != 2)
					{
						return;
					}
					BirthdayParty.ToggleManualParty();
					return;
				case 112:
					{
						int num205 = (int)this.reader.ReadByte();
						int num206 = (int)this.reader.ReadInt16();
						int num207 = (int)this.reader.ReadInt16();
						int num208 = (int)this.reader.ReadByte();
						int num209 = (int)this.reader.ReadInt16();
						if (num205 != 1)
						{
							return;
						}
						if (Main.netMode == 1)
						{
							WorldGen.TreeGrowFX(num206, num207, num208, num209);
						}
						if (Main.netMode == 2)
						{
							NetMessage.SendData((int)b, -1, -1, null, num205, (float)num206, (float)num207, (float)num208, num209, 0, 0);
							return;
						}
						return;
					}
				case 113:
					{
						int x7 = (int)this.reader.ReadInt16();
						int y12 = (int)this.reader.ReadInt16();
						if (Main.netMode == 2 && !Main.snowMoon && !Main.pumpkinMoon)
						{
							if (DD2Event.WouldFailSpawningHere(x7, y12))
							{
								DD2Event.FailureMessage(this.whoAmI);
							}
							DD2Event.SummonCrystal(x7, y12);
							return;
						}
						return;
					}
				case 114:
					if (Main.netMode != 1)
					{
						return;
					}
					DD2Event.WipeEntities();
					return;
				case 115:
					{
						int num210 = (int)this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							num210 = this.whoAmI;
						}
						Main.player[num210].MinionAttackTargetNPC = (int)this.reader.ReadInt16();
						if (Main.netMode == 2)
						{
							NetMessage.SendData(115, -1, this.whoAmI, null, num210, 0f, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
				case 116:
					if (Main.netMode != 1)
					{
						return;
					}
					DD2Event.TimeLeftBetweenWaves = this.reader.ReadInt32();
					return;
				case 117:
					{
						int num211 = (int)this.reader.ReadByte();
						if (Main.netMode == 2 && this.whoAmI != num211 && (!Main.player[num211].hostile || !Main.player[this.whoAmI].hostile))
						{
							return;
						}
						PlayerDeathReason playerDeathReason = PlayerDeathReason.FromReader(this.reader);
						int damage3 = (int)this.reader.ReadInt16();
						int num212 = (int)(this.reader.ReadByte() - 1);
						BitsByte bitsByte18 = this.reader.ReadByte();
						bool flag10 = bitsByte18[0];
						bool pvp = bitsByte18[1];
						int num213 = (int)this.reader.ReadSByte();
						Main.player[num211].Hurt(playerDeathReason, damage3, num212, pvp, true, flag10, num213);
						if (Main.netMode == 2)
						{
							NetMessage.SendPlayerHurt(num211, playerDeathReason, damage3, num212, flag10, pvp, num213, -1, this.whoAmI);
							return;
						}
						return;
					}
				case 118:
					{
						int num214 = (int)this.reader.ReadByte();
						if (Main.netMode == 2)
						{
							num214 = this.whoAmI;
						}
						PlayerDeathReason playerDeathReason2 = PlayerDeathReason.FromReader(this.reader);
						int num215 = (int)this.reader.ReadInt16();
						int num216 = (int)(this.reader.ReadByte() - 1);
						bool pvp2 = ((BitsByte)this.reader.ReadByte())[0];
						Main.player[num214].KillMe(playerDeathReason2, (double)num215, num216, pvp2);
						if (Main.netMode == 2)
						{
							NetMessage.SendPlayerDeath(num214, playerDeathReason2, num215, num216, pvp2, -1, this.whoAmI);
							return;
						}
						return;
					}
				case 119:
					{
						if (Main.netMode != 1)
						{
							return;
						}
						int arg_5C94_0 = (int)this.reader.ReadSingle();
						int y13 = (int)this.reader.ReadSingle();
						Color color4 = this.reader.ReadRGB();
						NetworkText networkText = NetworkText.Deserialize(this.reader);
						CombatText.NewText(new Rectangle(arg_5C94_0, y13, 0, 0), color4, networkText.ToString(), false, false);
						return;
					}
				default:
					return;
			}
			if (Main.netMode != 2)
			{
				return;
			}
			if (Netplay.Clients[this.whoAmI].State == 1)
			{
				Netplay.Clients[this.whoAmI].State = 2;
			}
			NetMessage.SendData(7, this.whoAmI, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
			Main.SyncAnInvasion(this.whoAmI);
			return;
			IL_4681:
			if (Netplay.Connection.State == 6)
			{
				Netplay.Connection.State = 10;
				Main.ActivePlayerFileData.StartPlayTimer();
				Player.Hooks.EnterWorld(Main.myPlayer);
				Main.player[Main.myPlayer].Spawn();
				return;
			}
			return;
			IL_641F:
			int num217 = (int)this.reader.ReadInt16();
			float num218 = this.reader.ReadSingle();
			float num219 = this.reader.ReadSingle();
			float num220 = this.reader.ReadSingle();
			if (num217 < 0 || num217 > 200)
			{
				return;
			}
			if (Main.netMode == 1)
			{
				Main.npc[num217].moneyPing(new Vector2(num219, num220));
				Main.npc[num217].extraValue = num218;
				return;
			}
			Main.npc[num217].extraValue += num218;
			NetMessage.SendData(92, -1, -1, null, num217, Main.npc[num217].extraValue, num219, num220, 0, 0, 0);
			return;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000156F0 File Offset: 0x000138F0
		public void Reset()
		{
			Array.Clear(this.readBuffer, 0, this.readBuffer.Length);
			Array.Clear(this.writeBuffer, 0, this.writeBuffer.Length);
			this.writeLocked = false;
			this.messageLength = 0;
			this.totalData = 0;
			this.spamCount = 0;
			this.broadcast = false;
			this.checkBytes = false;
			this.ResetReader();
			this.ResetWriter();
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0001575B File Offset: 0x0001395B
		public void ResetReader()
		{
			if (this.readerStream != null)
			{
				this.readerStream.Close();
			}
			this.readerStream = new MemoryStream(this.readBuffer);
			this.reader = new BinaryReader(this.readerStream);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00015792 File Offset: 0x00013992
		public void ResetWriter()
		{
			if (this.writerStream != null)
			{
				this.writerStream.Close();
			}
			this.writerStream = new MemoryStream(this.writeBuffer);
			this.writer = new BinaryWriter(this.writerStream);
		}

		// Token: 0x14000001 RID: 1
		// Token: 0x060000C8 RID: 200 RVA: 0x00015688 File Offset: 0x00013888
		// Token: 0x060000C9 RID: 201 RVA: 0x000156BC File Offset: 0x000138BC
		[method: CompilerGenerated]
		[CompilerGenerated]
		public static event TileChangeReceivedEvent OnTileChangeReceived;

		// Token: 0x040000BD RID: 189
		public bool broadcast;

		// Token: 0x040000C6 RID: 198
		public bool checkBytes;

		// Token: 0x040000C5 RID: 197
		public int maxSpam;

		// Token: 0x040000C1 RID: 193
		public int messageLength;

		// Token: 0x040000BE RID: 190
		public byte[] readBuffer = new byte[131070];

		// Token: 0x040000BB RID: 187
		public const int readBufferMax = 131070;

		// Token: 0x040000C9 RID: 201
		public BinaryReader reader;

		// Token: 0x040000C7 RID: 199
		public MemoryStream readerStream;

		// Token: 0x040000C4 RID: 196
		public int spamCount;

		// Token: 0x040000C2 RID: 194
		public int totalData;

		// Token: 0x040000C3 RID: 195
		public int whoAmI;

		// Token: 0x040000BF RID: 191
		public byte[] writeBuffer = new byte[131070];

		// Token: 0x040000BC RID: 188
		public const int writeBufferMax = 131070;

		// Token: 0x040000C0 RID: 192
		public bool writeLocked;

		// Token: 0x040000CA RID: 202
		public BinaryWriter writer;

		// Token: 0x040000C8 RID: 200
		public MemoryStream writerStream;
	}
}

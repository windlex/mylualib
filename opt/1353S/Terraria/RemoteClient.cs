using System;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.Net.Sockets;

namespace Terraria
{
	// Token: 0x0200001A RID: 26
	public class RemoteClient
	{
		// Token: 0x0600013D RID: 317 RVA: 0x00029928 File Offset: 0x00027B28
		public bool IsConnected()
		{
			return this.Socket != null && this.Socket.IsConnected();
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00029940 File Offset: 0x00027B40
		public void SpamUpdate()
		{
			if (!Netplay.spamCheck)
			{
				this.SpamProjectile = 0f;
				this.SpamDeleteBlock = 0f;
				this.SpamAddBlock = 0f;
				this.SpamWater = 0f;
				return;
			}
			if (this.SpamProjectile > this.SpamProjectileMax)
			{
				NetMessage.BootPlayer(this.Id, NetworkText.FromKey("Net.CheatingProjectileSpam", new object[0]));
			}
			if (this.SpamAddBlock > this.SpamAddBlockMax)
			{
				NetMessage.BootPlayer(this.Id, NetworkText.FromKey("Net.CheatingTileSpam", new object[0]));
			}
			if (this.SpamDeleteBlock > this.SpamDeleteBlockMax)
			{
				NetMessage.BootPlayer(this.Id, NetworkText.FromKey("Net.CheatingTileRemovalSpam", new object[0]));
			}
			if (this.SpamWater > this.SpamWaterMax)
			{
				NetMessage.BootPlayer(this.Id, NetworkText.FromKey("Net.CheatingLiquidSpam", new object[0]));
			}
			this.SpamProjectile -= 0.4f;
			if (this.SpamProjectile < 0f)
			{
				this.SpamProjectile = 0f;
			}
			this.SpamAddBlock -= 0.3f;
			if (this.SpamAddBlock < 0f)
			{
				this.SpamAddBlock = 0f;
			}
			this.SpamDeleteBlock -= 5f;
			if (this.SpamDeleteBlock < 0f)
			{
				this.SpamDeleteBlock = 0f;
			}
			this.SpamWater -= 0.2f;
			if (this.SpamWater < 0f)
			{
				this.SpamWater = 0f;
			}
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00029AD0 File Offset: 0x00027CD0
		public void SpamClear()
		{
			this.SpamProjectile = 0f;
			this.SpamAddBlock = 0f;
			this.SpamDeleteBlock = 0f;
			this.SpamWater = 0f;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00029B00 File Offset: 0x00027D00
		public static void CheckSection(int playerIndex, Vector2 position, int fluff = 1)
		{
			int sectionX = Netplay.GetSectionX((int)(position.X / 16f));
			int sectionY = Netplay.GetSectionY((int)(position.Y / 16f));
			int num = 0;
			for (int i = sectionX - fluff; i < sectionX + fluff + 1; i++)
			{
				for (int j = sectionY - fluff; j < sectionY + fluff + 1; j++)
				{
					if (i >= 0 && i < Main.maxSectionsX && j >= 0 && j < Main.maxSectionsY && !Netplay.Clients[playerIndex].TileSections[i, j])
					{
						num++;
					}
				}
			}
			if (num > 0)
			{
				int num2 = num;
				NetMessage.SendData(9, playerIndex, -1, Lang.inter[44].ToNetworkText(), num2, 0f, 0f, 0f, 0, 0, 0);
				Netplay.Clients[playerIndex].StatusText2 = Language.GetTextValue("Net.IsReceivingTileData");
				Netplay.Clients[playerIndex].StatusMax += num2;
				for (int k = sectionX - fluff; k < sectionX + fluff + 1; k++)
				{
					for (int l = sectionY - fluff; l < sectionY + fluff + 1; l++)
					{
						if (k >= 0 && k < Main.maxSectionsX && l >= 0 && l < Main.maxSectionsY && !Netplay.Clients[playerIndex].TileSections[k, l])
						{
							NetMessage.SendSection(playerIndex, k, l, false);
							NetMessage.SendData(11, playerIndex, -1, null, k, (float)l, (float)k, (float)l, 0, 0, 0);
						}
					}
				}
			}
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00029C7C File Offset: 0x00027E7C
		public bool SectionRange(int size, int firstX, int firstY)
		{
			for (int i = 0; i < 4; i++)
			{
				int num = firstX;
				int num2 = firstY;
				if (i == 1)
				{
					num += size;
				}
				if (i == 2)
				{
					num2 += size;
				}
				if (i == 3)
				{
					num += size;
					num2 += size;
				}
				int sectionX = Netplay.GetSectionX(num);
				int sectionY = Netplay.GetSectionY(num2);
				if (this.TileSections[sectionX, sectionY])
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00029CD8 File Offset: 0x00027ED8
		public void ResetSections()
		{
			for (int i = 0; i < Main.maxSectionsX; i++)
			{
				for (int j = 0; j < Main.maxSectionsY; j++)
				{
					this.TileSections[i, j] = false;
				}
			}
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00029D14 File Offset: 0x00027F14
		public void Reset()
		{
			this.ResetSections();
			if (this.Id < 255)
			{
				Main.player[this.Id] = new Player();
			}
			this.TimeOutTimer = 0;
			this.StatusCount = 0;
			this.StatusMax = 0;
			this.StatusText2 = "";
			this.StatusText = "";
			this.State = 0;
			this.IsReading = false;
			this.PendingTermination = false;
			this.SpamClear();
			this.IsActive = false;
			NetMessage.buffer[this.Id].Reset();
			if (this.Socket != null)
			{
				this.Socket.Close();
			}
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00029DB8 File Offset: 0x00027FB8
		public void ServerWriteCallBack(object state)
		{
			NetMessage.buffer[this.Id].spamCount--;
			if (this.StatusMax > 0)
			{
				this.StatusCount++;
			}
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00029DEC File Offset: 0x00027FEC
		public void ServerReadCallBack(object state, int length)
		{
			if (!Netplay.disconnect)
			{
				if (length == 0)
				{
					this.PendingTermination = true;
				}
				else
				{
					if (Main.ignoreErrors)
					{
						try
						{
							NetMessage.ReceiveBytes(this.ReadBuffer, length, this.Id);
							goto IL_45;
						}
						catch
						{
							goto IL_45;
						}
					}
					NetMessage.ReceiveBytes(this.ReadBuffer, length, this.Id);
				}
			}
			IL_45:
			this.IsReading = false;
		}

		// Token: 0x04000130 RID: 304
		public ISocket Socket;

		// Token: 0x04000131 RID: 305
		public int Id;

		// Token: 0x04000132 RID: 306
		public string Name = "Anonymous";

		// Token: 0x04000133 RID: 307
		public bool IsActive;

		// Token: 0x04000134 RID: 308
		public bool PendingTermination;

		// Token: 0x04000135 RID: 309
		public bool IsAnnouncementCompleted;

		// Token: 0x04000136 RID: 310
		public bool IsReading;

		// Token: 0x04000137 RID: 311
		public int State;

		// Token: 0x04000138 RID: 312
		public int TimeOutTimer;

		// Token: 0x04000139 RID: 313
		public string StatusText = "";

		// Token: 0x0400013A RID: 314
		public string StatusText2;

		// Token: 0x0400013B RID: 315
		public int StatusCount;

		// Token: 0x0400013C RID: 316
		public int StatusMax;

		// Token: 0x0400013D RID: 317
		public bool[,] TileSections = new bool[Main.maxTilesX / 200 + 1, Main.maxTilesY / 150 + 1];

		// Token: 0x0400013E RID: 318
		public byte[] ReadBuffer;

		// Token: 0x0400013F RID: 319
		public float SpamProjectile;

		// Token: 0x04000140 RID: 320
		public float SpamAddBlock;

		// Token: 0x04000141 RID: 321
		public float SpamDeleteBlock;

		// Token: 0x04000142 RID: 322
		public float SpamWater;

		// Token: 0x04000143 RID: 323
		public float SpamProjectileMax = 100f;

		// Token: 0x04000144 RID: 324
		public float SpamAddBlockMax = 100f;

		// Token: 0x04000145 RID: 325
		public float SpamDeleteBlockMax = 500f;

		// Token: 0x04000146 RID: 326
		public float SpamWaterMax = 50f;
	}
}

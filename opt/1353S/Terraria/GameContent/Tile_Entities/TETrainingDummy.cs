using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.ID;

namespace Terraria.GameContent.Tile_Entities
{
	// Token: 0x02000120 RID: 288
	public class TETrainingDummy : TileEntity
	{
		// Token: 0x06000F98 RID: 3992 RVA: 0x003F6194 File Offset: 0x003F4394
		public static void Initialize()
		{
			TileEntity._UpdateStart += new Action(TETrainingDummy.ClearBoxes);
			TileEntity._NetPlaceEntity += new Action<int, int, int>(TETrainingDummy.NetPlaceEntity);
		}

		// Token: 0x06000F99 RID: 3993 RVA: 0x003F61B8 File Offset: 0x003F43B8
		public static void NetPlaceEntity(int x, int y, int type)
		{
			if (type != 0)
			{
				return;
			}
			if (!TETrainingDummy.ValidTile(x, y))
			{
				return;
			}
			TETrainingDummy.Place(x, y);
		}

		// Token: 0x06000F9A RID: 3994 RVA: 0x003F61D0 File Offset: 0x003F43D0
		public static void ClearBoxes()
		{
			TETrainingDummy.playerBox.Clear();
			TETrainingDummy.playerBoxFilled = false;
		}

		// Token: 0x06000F9B RID: 3995 RVA: 0x003F61E4 File Offset: 0x003F43E4
		public override void Update()
		{
			Rectangle rectangle = new Rectangle(0, 0, 32, 48);
			rectangle.Inflate(1600, 1600);
			int x = rectangle.X;
			int y = rectangle.Y;
			if (this.npc != -1)
			{
				if (!Main.npc[this.npc].active || Main.npc[this.npc].type != 488 || Main.npc[this.npc].ai[0] != (float)this.Position.X || Main.npc[this.npc].ai[1] != (float)this.Position.Y)
				{
					this.Deactivate();
					return;
				}
			}
			else
			{
				TETrainingDummy.FillPlayerHitboxes();
				rectangle.X = (int)(this.Position.X * 16) + x;
				rectangle.Y = (int)(this.Position.Y * 16) + y;
				bool flag = false;
				foreach (KeyValuePair<int, Rectangle> current in TETrainingDummy.playerBox)
				{
					if (current.Value.Intersects(rectangle))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					this.Activate();
				}
			}
		}

		// Token: 0x06000F9C RID: 3996 RVA: 0x003F6334 File Offset: 0x003F4534
		private static void FillPlayerHitboxes()
		{
			if (!TETrainingDummy.playerBoxFilled)
			{
				for (int i = 0; i < 255; i++)
				{
					if (Main.player[i].active)
					{
						TETrainingDummy.playerBox[i] = Main.player[i].getRect();
					}
				}
				TETrainingDummy.playerBoxFilled = true;
			}
		}

		// Token: 0x06000F9D RID: 3997 RVA: 0x003F6384 File Offset: 0x003F4584
		public static bool ValidTile(int x, int y)
		{
			return Main.tile[x, y].active() && Main.tile[x, y].type == 378 && Main.tile[x, y].frameY == 0 && Main.tile[x, y].frameX % 36 == 0;
		}

		// Token: 0x06000F9E RID: 3998 RVA: 0x003F63E8 File Offset: 0x003F45E8
		public TETrainingDummy()
		{
			this.npc = -1;
		}

		// Token: 0x06000F9F RID: 3999 RVA: 0x003F63F8 File Offset: 0x003F45F8
		public static int Place(int x, int y)
		{
			TETrainingDummy tETrainingDummy = new TETrainingDummy();
			tETrainingDummy.Position = new Point16(x, y);
			tETrainingDummy.ID = TileEntity.AssignNewID();
			tETrainingDummy.type = 0;
			TileEntity.ByID[tETrainingDummy.ID] = tETrainingDummy;
			TileEntity.ByPosition[tETrainingDummy.Position] = tETrainingDummy;
			return tETrainingDummy.ID;
		}

		// Token: 0x06000FA0 RID: 4000 RVA: 0x003F6454 File Offset: 0x003F4654
		public static int Hook_AfterPlacement(int x, int y, int type = 378, int style = 0, int direction = 1)
		{
			if (Main.netMode == 1)
			{
				NetMessage.SendTileSquare(Main.myPlayer, x - 1, y - 1, 3, TileChangeType.None);
				NetMessage.SendData(87, -1, -1, null, x - 1, (float)(y - 2), 0f, 0f, 0, 0, 0);
				return -1;
			}
			return TETrainingDummy.Place(x - 1, y - 2);
		}

		// Token: 0x06000FA1 RID: 4001 RVA: 0x003F64A8 File Offset: 0x003F46A8
		public static void Kill(int x, int y)
		{
			TileEntity tileEntity;
			if (TileEntity.ByPosition.TryGetValue(new Point16(x, y), out tileEntity) && tileEntity.type == 0)
			{
				TileEntity.ByID.Remove(tileEntity.ID);
				TileEntity.ByPosition.Remove(new Point16(x, y));
			}
		}

		// Token: 0x06000FA2 RID: 4002 RVA: 0x003F64F8 File Offset: 0x003F46F8
		public static int Find(int x, int y)
		{
			TileEntity tileEntity;
			if (TileEntity.ByPosition.TryGetValue(new Point16(x, y), out tileEntity) && tileEntity.type == 0)
			{
				return tileEntity.ID;
			}
			return -1;
		}

		// Token: 0x06000FA3 RID: 4003 RVA: 0x003F652C File Offset: 0x003F472C
		public override void WriteExtraData(BinaryWriter writer, bool networkSend)
		{
			writer.Write((short)this.npc);
		}

		// Token: 0x06000FA4 RID: 4004 RVA: 0x003F653C File Offset: 0x003F473C
		public override void ReadExtraData(BinaryReader reader, bool networkSend)
		{
			this.npc = (int)reader.ReadInt16();
		}

		// Token: 0x06000FA5 RID: 4005 RVA: 0x003F654C File Offset: 0x003F474C
		public void Activate()
		{
			int num = NPC.NewNPC((int)(this.Position.X * 16 + 16), (int)(this.Position.Y * 16 + 48), 488, 100, 0f, 0f, 0f, 0f, 255);
			Main.npc[num].ai[0] = (float)this.Position.X;
			Main.npc[num].ai[1] = (float)this.Position.Y;
			Main.npc[num].netUpdate = true;
			this.npc = num;
			if (Main.netMode != 1)
			{
				NetMessage.SendData(86, -1, -1, null, this.ID, (float)this.Position.X, (float)this.Position.Y, 0f, 0, 0, 0);
			}
		}

		// Token: 0x06000FA6 RID: 4006 RVA: 0x003F6624 File Offset: 0x003F4824
		public void Deactivate()
		{
			if (this.npc != -1)
			{
				Main.npc[this.npc].active = false;
			}
			this.npc = -1;
			if (Main.netMode != 1)
			{
				NetMessage.SendData(86, -1, -1, null, this.ID, (float)this.Position.X, (float)this.Position.Y, 0f, 0, 0, 0);
			}
		}

		// Token: 0x06000FA7 RID: 4007 RVA: 0x003F668C File Offset: 0x003F488C
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				this.Position.X,
				"x  ",
				this.Position.Y,
				"y npc: ",
				this.npc
			});
		}

		// Token: 0x0400306E RID: 12398
		private static Dictionary<int, Rectangle> playerBox = new Dictionary<int, Rectangle>();

		// Token: 0x0400306F RID: 12399
		private static bool playerBoxFilled = false;

		// Token: 0x04003070 RID: 12400
		public int npc;
	}
}

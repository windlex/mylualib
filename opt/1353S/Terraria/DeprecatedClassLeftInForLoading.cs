using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace Terraria
{
	// Token: 0x0200000E RID: 14
	public class DeprecatedClassLeftInForLoading
	{
		// Token: 0x06000078 RID: 120 RVA: 0x00008B08 File Offset: 0x00006D08
		public static void UpdateDummies()
		{
			Dictionary<int, Rectangle> dictionary = new Dictionary<int, Rectangle>();
			bool flag = false;
			Rectangle rectangle = new Rectangle(0, 0, 32, 48);
			rectangle.Inflate(1600, 1600);
			int num = rectangle.X;
			int num2 = rectangle.Y;
			for (int i = 0; i < 1000; i++)
			{
				if (DeprecatedClassLeftInForLoading.dummies[i] != null)
				{
					DeprecatedClassLeftInForLoading.dummies[i].whoAmI = i;
					if (DeprecatedClassLeftInForLoading.dummies[i].npc != -1)
					{
						if (!Main.npc[DeprecatedClassLeftInForLoading.dummies[i].npc].active || Main.npc[DeprecatedClassLeftInForLoading.dummies[i].npc].type != 488 || Main.npc[DeprecatedClassLeftInForLoading.dummies[i].npc].ai[0] != (float)DeprecatedClassLeftInForLoading.dummies[i].x || Main.npc[DeprecatedClassLeftInForLoading.dummies[i].npc].ai[1] != (float)DeprecatedClassLeftInForLoading.dummies[i].y)
						{
							DeprecatedClassLeftInForLoading.dummies[i].Deactivate();
						}
					}
					else
					{
						if (!flag)
						{
							for (int j = 0; j < 255; j++)
							{
								if (Main.player[j].active)
								{
									dictionary[j] = Main.player[j].getRect();
								}
							}
							flag = true;
						}
						rectangle.X = (int)(DeprecatedClassLeftInForLoading.dummies[i].x * 16) + num;
						rectangle.Y = (int)(DeprecatedClassLeftInForLoading.dummies[i].y * 16) + num2;
						bool flag2 = false;
						foreach (KeyValuePair<int, Rectangle> current in dictionary)
						{
							if (current.Value.Intersects(rectangle))
							{
								flag2 = true;
								break;
							}
						}
						if (flag2)
						{
							DeprecatedClassLeftInForLoading.dummies[i].Activate();
						}
					}
				}
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00008D10 File Offset: 0x00006F10
		public DeprecatedClassLeftInForLoading(int x, int y)
		{
			this.x = (short)x;
			this.y = (short)y;
			this.npc = -1;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00008D30 File Offset: 0x00006F30
		public static int Find(int x, int y)
		{
			for (int i = 0; i < 1000; i++)
			{
				if (DeprecatedClassLeftInForLoading.dummies[i] != null && (int)DeprecatedClassLeftInForLoading.dummies[i].x == x && (int)DeprecatedClassLeftInForLoading.dummies[i].y == y)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00008D78 File Offset: 0x00006F78
		public static int Place(int x, int y)
		{
			int num = -1;
			for (int i = 0; i < 1000; i++)
			{
				if (DeprecatedClassLeftInForLoading.dummies[i] == null)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				return num;
			}
			DeprecatedClassLeftInForLoading.dummies[num] = new DeprecatedClassLeftInForLoading(x, y);
			return num;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00008DBC File Offset: 0x00006FBC
		public static void Kill(int x, int y)
		{
			for (int i = 0; i < 1000; i++)
			{
				DeprecatedClassLeftInForLoading deprecatedClassLeftInForLoading = DeprecatedClassLeftInForLoading.dummies[i];
				if (deprecatedClassLeftInForLoading != null && (int)deprecatedClassLeftInForLoading.x == x && (int)deprecatedClassLeftInForLoading.y == y)
				{
					DeprecatedClassLeftInForLoading.dummies[i] = null;
				}
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00008E00 File Offset: 0x00007000
		public static int Hook_AfterPlacement(int x, int y, int type = 21, int style = 0, int direction = 1)
		{
			if (Main.netMode == 1)
			{
				NetMessage.SendTileSquare(Main.myPlayer, x - 1, y - 1, 3, TileChangeType.None);
				NetMessage.SendData(87, -1, -1, null, x - 1, (float)(y - 2), 0f, 0f, 0, 0, 0);
				return -1;
			}
			return DeprecatedClassLeftInForLoading.Place(x - 1, y - 2);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00008E54 File Offset: 0x00007054
		public void Activate()
		{
			int num = NPC.NewNPC((int)(this.x * 16 + 16), (int)(this.y * 16 + 48), 488, 100, 0f, 0f, 0f, 0f, 255);
			Main.npc[num].ai[0] = (float)this.x;
			Main.npc[num].ai[1] = (float)this.y;
			Main.npc[num].netUpdate = true;
			this.npc = num;
			if (Main.netMode != 1)
			{
				NetMessage.SendData(86, -1, -1, null, this.whoAmI, (float)this.x, (float)this.y, 0f, 0, 0, 0);
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00008F0C File Offset: 0x0000710C
		public void Deactivate()
		{
			if (this.npc != -1)
			{
				Main.npc[this.npc].active = false;
			}
			this.npc = -1;
			if (Main.netMode != 1)
			{
				NetMessage.SendData(86, -1, -1, null, this.whoAmI, (float)this.x, (float)this.y, 0f, 0, 0, 0);
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00008F6C File Offset: 0x0000716C
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				this.x,
				"x  ",
				this.y,
				"y npc: ",
				this.npc
			});
		}

		// Token: 0x04000061 RID: 97
		public const int MaxDummies = 1000;

		// Token: 0x04000062 RID: 98
		public static DeprecatedClassLeftInForLoading[] dummies = new DeprecatedClassLeftInForLoading[1000];

		// Token: 0x04000063 RID: 99
		public short x;

		// Token: 0x04000064 RID: 100
		public short y;

		// Token: 0x04000065 RID: 101
		public int npc;

		// Token: 0x04000066 RID: 102
		public int whoAmI;
	}
}

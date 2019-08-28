using System;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ObjectData;

namespace Terraria
{
	// Token: 0x02000004 RID: 4
	public class Chest
	{
		// Token: 0x06000027 RID: 39 RVA: 0x00003172 File Offset: 0x00001372
		public Chest(bool bank = false)
		{
			this.item = new Item[40];
			this.bankChest = bank;
			this.name = string.Empty;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000422C File Offset: 0x0000242C
		public void AddShop(Item newItem)
		{
			int i = 0;
			while (i < 39)
			{
				if (this.item[i] == null || this.item[i].type == 0)
				{
					this.item[i] = newItem.Clone();
					this.item[i].favorited = false;
					this.item[i].buyOnce = true;
					if (this.item[i].value <= 0)
					{
						break;
					}
					this.item[i].value = this.item[i].value / 5;
					if (this.item[i].value < 1)
					{
						this.item[i].value = 1;
						return;
					}
					break;
				}
				else
				{
					i++;
				}
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003F34 File Offset: 0x00002134
		public static int AfterPlacement_Hook(int x, int y, int type = 21, int style = 0, int direction = 1)
		{
			Point16 point = new Point16(x, y);
			TileObjectData.OriginToTopLeft(type, style, ref point);
			int num = Chest.FindEmptyChest((int)point.X, (int)point.Y, 21, 0, 1);
			if (num == -1)
			{
				return -1;
			}
			if (Main.netMode != 1)
			{
				Chest chest = new Chest(false);
				chest.x = (int)point.X;
				chest.y = (int)point.Y;
				for (int i = 0; i < 40; i++)
				{
					chest.item[i] = new Item();
				}
				Main.chest[num] = chest;
			}
			else if (type == 21)
			{
				NetMessage.SendData(34, -1, -1, null, 0, (float)x, (float)y, (float)style, 0, 0, 0);
			}
			else if (type == 467)
			{
				NetMessage.SendData(34, -1, -1, null, 4, (float)x, (float)y, (float)style, 0, 0, 0);
			}
			else
			{
				NetMessage.SendData(34, -1, -1, null, 2, (float)x, (float)y, (float)style, 0, 0, 0);
			}
			return num;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00004080 File Offset: 0x00002280
		public static bool CanDestroyChest(int X, int Y)
		{
			for (int i = 0; i < 1000; i++)
			{
				Chest chest = Main.chest[i];
				if (chest != null && chest.x == X && chest.y == Y)
				{
					for (int j = 0; j < 40; j++)
					{
						if (chest.item[j] != null && chest.item[j].type > 0 && chest.item[j].stack > 0)
						{
							return false;
						}
					}
					return true;
				}
			}
			return true;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00003C56 File Offset: 0x00001E56
		public object Clone()
		{
			return base.MemberwiseClone();
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00004008 File Offset: 0x00002208
		public static int CreateChest(int X, int Y, int id = -1)
		{
			int num = id;
			if (num == -1)
			{
				num = Chest.FindEmptyChest(X, Y, 21, 0, 1);
				if (num == -1)
				{
					return -1;
				}
				if (Main.netMode == 1)
				{
					return num;
				}
			}
			Main.chest[num] = new Chest(false);
			Main.chest[num].x = X;
			Main.chest[num].y = Y;
			for (int i = 0; i < 40; i++)
			{
				Main.chest[num].item[i] = new Item();
			}
			return num;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000040F8 File Offset: 0x000022F8
		public static bool DestroyChest(int X, int Y)
		{
			for (int i = 0; i < 1000; i++)
			{
				Chest chest = Main.chest[i];
				if (chest != null && chest.x == X && chest.y == Y)
				{
					for (int j = 0; j < 40; j++)
					{
						if (chest.item[j] != null && chest.item[j].type > 0 && chest.item[j].stack > 0)
						{
							return false;
						}
					}
					Main.chest[i] = null;
					if (Main.player[Main.myPlayer].chest == i)
					{
						Main.player[Main.myPlayer].chest = -1;
					}
					Recipe.FindRecipes();
					return true;
				}
			}
			return true;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000041A8 File Offset: 0x000023A8
		public static void DestroyChestDirect(int X, int Y, int id)
		{
			if (id < 0 || id >= Main.chest.Length)
			{
				return;
			}
			try
			{
				Chest chest = Main.chest[id];
				if (chest != null)
				{
					if (chest.x == X && chest.y == Y)
					{
						Main.chest[id] = null;
						if (Main.player[Main.myPlayer].chest == id)
						{
							Main.player[Main.myPlayer].chest = -1;
						}
						Recipe.FindRecipes();
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003DE8 File Offset: 0x00001FE8
		public static int FindChest(int X, int Y)
		{
			for (int i = 0; i < 1000; i++)
			{
				if (Main.chest[i] != null && Main.chest[i].x == X && Main.chest[i].y == Y)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003E30 File Offset: 0x00002030
		public static int FindChestByGuessing(int X, int Y)
		{
			for (int i = 0; i < 1000; i++)
			{
				if (Main.chest[i] != null && Main.chest[i].x >= X && Main.chest[i].x < X + 2 && Main.chest[i].y >= Y && Main.chest[i].y < Y + 2)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003E9C File Offset: 0x0000209C
		public static int FindEmptyChest(int x, int y, int type = 21, int style = 0, int direction = 1)
		{
			int num = -1;
			for (int i = 0; i < 1000; i++)
			{
				Chest chest = Main.chest[i];
				if (chest != null)
				{
					if (chest.x == x && chest.y == y)
					{
						return -1;
					}
				}
				else if (num == -1)
				{
					num = i;
				}
			}
			return num;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000031F8 File Offset: 0x000013F8
		public static void Initialize()
		{
			int[] array = Chest.chestItemSpawn;
			int[] expr_0B = Chest.chestTypeToIcon;
			expr_0B[0] = (array[0] = 48);
			expr_0B[1] = (array[1] = 306);
			expr_0B[2] = 327;
			array[2] = 306;
			expr_0B[3] = (array[3] = 328);
			expr_0B[4] = 329;
			array[4] = 328;
			expr_0B[5] = (array[5] = 343);
			expr_0B[6] = (array[6] = 348);
			expr_0B[7] = (array[7] = 625);
			expr_0B[8] = (array[8] = 626);
			expr_0B[9] = (array[9] = 627);
			expr_0B[10] = (array[10] = 680);
			expr_0B[11] = (array[11] = 681);
			expr_0B[12] = (array[12] = 831);
			expr_0B[13] = (array[13] = 838);
			expr_0B[14] = (array[14] = 914);
			expr_0B[15] = (array[15] = 952);
			expr_0B[16] = (array[16] = 1142);
			expr_0B[17] = (array[17] = 1298);
			expr_0B[18] = (array[18] = 1528);
			expr_0B[19] = (array[19] = 1529);
			expr_0B[20] = (array[20] = 1530);
			expr_0B[21] = (array[21] = 1531);
			expr_0B[22] = (array[22] = 1532);
			expr_0B[23] = 1533;
			array[23] = 1528;
			expr_0B[24] = 1534;
			array[24] = 1529;
			expr_0B[25] = 1535;
			array[25] = 1530;
			expr_0B[26] = 1536;
			array[26] = 1531;
			expr_0B[27] = 1537;
			array[27] = 1532;
			expr_0B[28] = (array[28] = 2230);
			expr_0B[29] = (array[29] = 2249);
			expr_0B[30] = (array[30] = 2250);
			expr_0B[31] = (array[31] = 2526);
			expr_0B[32] = (array[32] = 2544);
			expr_0B[33] = (array[33] = 2559);
			expr_0B[34] = (array[34] = 2574);
			expr_0B[35] = (array[35] = 2612);
			expr_0B[36] = 327;
			array[36] = 2612;
			expr_0B[37] = (array[37] = 2613);
			expr_0B[38] = 327;
			array[38] = 2613;
			expr_0B[39] = (array[39] = 2614);
			expr_0B[40] = 327;
			array[40] = 2614;
			expr_0B[41] = (array[41] = 2615);
			expr_0B[42] = (array[42] = 2616);
			expr_0B[43] = (array[43] = 2617);
			expr_0B[44] = (array[44] = 2618);
			expr_0B[45] = (array[45] = 2619);
			expr_0B[46] = (array[46] = 2620);
			expr_0B[47] = (array[47] = 2748);
			expr_0B[48] = (array[48] = 2814);
			expr_0B[49] = (array[49] = 3180);
			expr_0B[50] = (array[50] = 3125);
			expr_0B[51] = (array[51] = 3181);
			int[] array2 = Chest.chestItemSpawn2;
			int[] expr_354 = Chest.chestTypeToIcon2;
			expr_354[0] = (array2[0] = 3884);
			expr_354[1] = (array2[1] = 3885);
			Chest.dresserTypeToIcon[0] = (Chest.dresserItemSpawn[0] = 334);
			Chest.dresserTypeToIcon[1] = (Chest.dresserItemSpawn[1] = 647);
			Chest.dresserTypeToIcon[2] = (Chest.dresserItemSpawn[2] = 648);
			Chest.dresserTypeToIcon[3] = (Chest.dresserItemSpawn[3] = 649);
			Chest.dresserTypeToIcon[4] = (Chest.dresserItemSpawn[4] = 918);
			Chest.dresserTypeToIcon[5] = (Chest.dresserItemSpawn[5] = 2386);
			Chest.dresserTypeToIcon[6] = (Chest.dresserItemSpawn[6] = 2387);
			Chest.dresserTypeToIcon[7] = (Chest.dresserItemSpawn[7] = 2388);
			Chest.dresserTypeToIcon[8] = (Chest.dresserItemSpawn[8] = 2389);
			Chest.dresserTypeToIcon[9] = (Chest.dresserItemSpawn[9] = 2390);
			Chest.dresserTypeToIcon[10] = (Chest.dresserItemSpawn[10] = 2391);
			Chest.dresserTypeToIcon[11] = (Chest.dresserItemSpawn[11] = 2392);
			Chest.dresserTypeToIcon[12] = (Chest.dresserItemSpawn[12] = 2393);
			Chest.dresserTypeToIcon[13] = (Chest.dresserItemSpawn[13] = 2394);
			Chest.dresserTypeToIcon[14] = (Chest.dresserItemSpawn[14] = 2395);
			Chest.dresserTypeToIcon[15] = (Chest.dresserItemSpawn[15] = 2396);
			Chest.dresserTypeToIcon[16] = (Chest.dresserItemSpawn[16] = 2529);
			Chest.dresserTypeToIcon[17] = (Chest.dresserItemSpawn[17] = 2545);
			Chest.dresserTypeToIcon[18] = (Chest.dresserItemSpawn[18] = 2562);
			Chest.dresserTypeToIcon[19] = (Chest.dresserItemSpawn[19] = 2577);
			Chest.dresserTypeToIcon[20] = (Chest.dresserItemSpawn[20] = 2637);
			Chest.dresserTypeToIcon[21] = (Chest.dresserItemSpawn[21] = 2638);
			Chest.dresserTypeToIcon[22] = (Chest.dresserItemSpawn[22] = 2639);
			Chest.dresserTypeToIcon[23] = (Chest.dresserItemSpawn[23] = 2640);
			Chest.dresserTypeToIcon[24] = (Chest.dresserItemSpawn[24] = 2816);
			Chest.dresserTypeToIcon[25] = (Chest.dresserItemSpawn[25] = 3132);
			Chest.dresserTypeToIcon[26] = (Chest.dresserItemSpawn[26] = 3134);
			Chest.dresserTypeToIcon[27] = (Chest.dresserItemSpawn[27] = 3133);
			Chest.dresserTypeToIcon[28] = (Chest.dresserItemSpawn[28] = 3911);
			Chest.dresserTypeToIcon[29] = (Chest.dresserItemSpawn[29] = 3912);
			Chest.dresserTypeToIcon[30] = (Chest.dresserItemSpawn[30] = 3913);
			Chest.dresserTypeToIcon[31] = (Chest.dresserItemSpawn[31] = 3914);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003894 File Offset: 0x00001A94
		public static bool isLocked(int x, int y)
		{
			return Main.tile[x, y] == null || ((Main.tile[x, y].frameX >= 72 && Main.tile[x, y].frameX <= 106) || (Main.tile[x, y].frameX >= 144 && Main.tile[x, y].frameX <= 178) || (Main.tile[x, y].frameX >= 828 && Main.tile[x, y].frameX <= 1006) || (Main.tile[x, y].frameX >= 1296 && Main.tile[x, y].frameX <= 1330) || (Main.tile[x, y].frameX >= 1368 && Main.tile[x, y].frameX <= 1402) || (Main.tile[x, y].frameX >= 1440 && Main.tile[x, y].frameX <= 1474));
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00003864 File Offset: 0x00001A64
		private static bool IsPlayerInChest(int i)
		{
			for (int j = 0; j < 255; j++)
			{
				if (Main.player[j].chest == i)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003EE4 File Offset: 0x000020E4
		public static bool NearOtherChests(int x, int y)
		{
			for (int i = x - 25; i < x + 25; i++)
			{
				for (int j = y - 8; j < y + 8; j++)
				{
					Tile tileSafely = Framing.GetTileSafely(i, j);
					if (tileSafely.active() && TileID.Sets.BasicChest[(int)tileSafely.type])
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00003A3C File Offset: 0x00001C3C
		public static Item PutItemInNearbyChest(Item item, Vector2 position)
		{
			if (Main.netMode == 1)
			{
				return item;
			}
			for (int i = 0; i < 1000; i++)
			{
				bool flag = false;
				bool flag2 = false;
				if (Main.chest[i] != null && !Chest.IsPlayerInChest(i) && !Chest.isLocked(Main.chest[i].x, Main.chest[i].y) && (new Vector2((float)(Main.chest[i].x * 16 + 16), (float)(Main.chest[i].y * 16 + 16)) - position).Length() < 200f)
				{
					for (int j = 0; j < Main.chest[i].item.Length; j++)
					{
						if (Main.chest[i].item[j].type > 0 && Main.chest[i].item[j].stack > 0)
						{
							if (item.IsTheSameAs(Main.chest[i].item[j]))
							{
								flag = true;
								int num = Main.chest[i].item[j].maxStack - Main.chest[i].item[j].stack;
								if (num > 0)
								{
									if (num > item.stack)
									{
										num = item.stack;
									}
									item.stack -= num;
									Main.chest[i].item[j].stack += num;
									if (item.stack <= 0)
									{
										item.SetDefaults(0, false);
										return item;
									}
								}
							}
						}
						else
						{
							flag2 = true;
						}
					}
					if ((flag & flag2) && item.stack > 0)
					{
						for (int k = 0; k < Main.chest[i].item.Length; k++)
						{
							if (Main.chest[i].item[k].type == 0 || Main.chest[i].item[k].stack == 0)
							{
								Main.chest[i].item[k] = item.Clone();
								item.SetDefaults(0, false);
								return item;
							}
						}
					}
				}
			}
			return item;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000039D8 File Offset: 0x00001BD8
		public static void ServerPlaceItem(int plr, int slot)
		{
			Main.player[plr].inventory[slot] = Chest.PutItemInNearbyChest(Main.player[plr].inventory[slot], Main.player[plr].Center);
			NetMessage.SendData(5, -1, -1, null, plr, (float)slot, (float)Main.player[plr].inventory[slot].prefix, 0f, 0, 0, 0);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00004A30 File Offset: 0x00002C30
		public void SetupShop(int type)
		{
			for (int i = 0; i < 40; i++)
			{
				this.item[i] = new Item();
			}
			int num = 0;
			if (type == 1)
			{
				this.item[num].SetDefaults(88, false);
				num++;
				this.item[num].SetDefaults(87, false);
				num++;
				this.item[num].SetDefaults(35, false);
				num++;
				this.item[num].SetDefaults(1991, false);
				num++;
				this.item[num].SetDefaults(3509, false);
				num++;
				this.item[num].SetDefaults(3506, false);
				num++;
				this.item[num].SetDefaults(8, false);
				num++;
				this.item[num].SetDefaults(28, false);
				num++;
				this.item[num].SetDefaults(110, false);
				num++;
				this.item[num].SetDefaults(40, false);
				num++;
				this.item[num].SetDefaults(42, false);
				num++;
				this.item[num].SetDefaults(965, false);
				num++;
				if (Main.player[Main.myPlayer].ZoneSnow)
				{
					this.item[num].SetDefaults(967, false);
					num++;
				}
				if (Main.bloodMoon)
				{
					this.item[num].SetDefaults(279, false);
					num++;
				}
				if (!Main.dayTime)
				{
					this.item[num].SetDefaults(282, false);
					num++;
				}
                if (NpcMgr.downedBoss3)
				{
					this.item[num].SetDefaults(346, false);
					num++;
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(488, false);
					num++;
				}
				for (int j = 0; j < 58; j++)
				{
					if (Main.player[Main.myPlayer].inventory[j].type == 930)
					{
						this.item[num].SetDefaults(931, false);
						num++;
						this.item[num].SetDefaults(1614, false);
						num++;
						break;
					}
				}
				this.item[num].SetDefaults(1786, false);
				num++;
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(1348, false);
					num++;
				}
				if (Main.player[Main.myPlayer].HasItem(3107))
				{
					this.item[num].SetDefaults(3108, false);
					num++;
				}
				if (Main.halloween)
				{
					this.item[num++].SetDefaults(3242, false);
					this.item[num++].SetDefaults(3243, false);
					this.item[num++].SetDefaults(3244, false);
				}
			}
			else if (type == 2)
			{
				this.item[num].SetDefaults(97, false);
				num++;
				if (Main.bloodMoon || Main.hardMode)
				{
					this.item[num].SetDefaults(278, false);
					num++;
				}
				if ((NpcMgr.downedBoss2 && !Main.dayTime) || Main.hardMode)
				{
					this.item[num].SetDefaults(47, false);
					num++;
				}
				this.item[num].SetDefaults(95, false);
				num++;
				this.item[num].SetDefaults(98, false);
				num++;
				if (!Main.dayTime)
				{
					this.item[num].SetDefaults(324, false);
					num++;
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(534, false);
					num++;
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(1432, false);
					num++;
				}
				if (Main.player[Main.myPlayer].HasItem(1258))
				{
					this.item[num].SetDefaults(1261, false);
					num++;
				}
				if (Main.player[Main.myPlayer].HasItem(1835))
				{
					this.item[num].SetDefaults(1836, false);
					num++;
				}
				if (Main.player[Main.myPlayer].HasItem(3107))
				{
					this.item[num].SetDefaults(3108, false);
					num++;
				}
				if (Main.player[Main.myPlayer].HasItem(1782))
				{
					this.item[num].SetDefaults(1783, false);
					num++;
				}
				if (Main.player[Main.myPlayer].HasItem(1784))
				{
					this.item[num].SetDefaults(1785, false);
					num++;
				}
				if (Main.halloween)
				{
					this.item[num].SetDefaults(1736, false);
					num++;
					this.item[num].SetDefaults(1737, false);
					num++;
					this.item[num].SetDefaults(1738, false);
					num++;
				}
			}
			else if (type == 3)
			{
				if (Main.bloodMoon)
				{
					if (WorldGen.crimson)
					{
						this.item[num].SetDefaults(2886, false);
						num++;
						this.item[num].SetDefaults(2171, false);
						num++;
					}
					else
					{
						this.item[num].SetDefaults(67, false);
						num++;
						this.item[num].SetDefaults(59, false);
						num++;
					}
				}
				else
				{
					this.item[num].SetDefaults(66, false);
					num++;
					this.item[num].SetDefaults(62, false);
					num++;
					this.item[num].SetDefaults(63, false);
					num++;
				}
				this.item[num].SetDefaults(27, false);
				num++;
				this.item[num].SetDefaults(114, false);
				num++;
				this.item[num].SetDefaults(1828, false);
				num++;
				this.item[num].SetDefaults(745, false);
				num++;
				this.item[num].SetDefaults(747, false);
				num++;
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(746, false);
					num++;
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(369, false);
					num++;
				}
				if (Main.shroomTiles > 50)
				{
					this.item[num].SetDefaults(194, false);
					num++;
				}
				if (Main.halloween)
				{
					this.item[num].SetDefaults(1853, false);
					num++;
					this.item[num].SetDefaults(1854, false);
					num++;
				}
				if (NpcMgr.downedSlimeKing)
				{
					this.item[num].SetDefaults(3215, false);
					num++;
				}
				if (NpcMgr.downedQueenBee)
				{
					this.item[num].SetDefaults(3216, false);
					num++;
				}
				if (NpcMgr.downedBoss1)
				{
					this.item[num].SetDefaults(3219, false);
					num++;
				}
				if (NpcMgr.downedBoss2)
				{
					if (WorldGen.crimson)
					{
						this.item[num].SetDefaults(3218, false);
						num++;
					}
					else
					{
						this.item[num].SetDefaults(3217, false);
						num++;
					}
				}
				if (NpcMgr.downedBoss3)
				{
					this.item[num].SetDefaults(3220, false);
					num++;
					this.item[num].SetDefaults(3221, false);
					num++;
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(3222, false);
					num++;
				}
			}
			else if (type == 4)
			{
				this.item[num].SetDefaults(168, false);
				num++;
				this.item[num].SetDefaults(166, false);
				num++;
				this.item[num].SetDefaults(167, false);
				num++;
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(265, false);
					num++;
				}
				if (Main.hardMode && NpcMgr.downedPlantBoss && NpcMgr.downedPirates)
				{
					this.item[num].SetDefaults(937, false);
					num++;
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(1347, false);
					num++;
				}
			}
			else if (type == 5)
			{
				this.item[num].SetDefaults(254, false);
				num++;
				this.item[num].SetDefaults(981, false);
				num++;
				if (Main.dayTime)
				{
					this.item[num].SetDefaults(242, false);
					num++;
				}
				if (Main.moonPhase == 0)
				{
					this.item[num].SetDefaults(245, false);
					num++;
					this.item[num].SetDefaults(246, false);
					num++;
					if (!Main.dayTime)
					{
						this.item[num++].SetDefaults(1288, false);
						this.item[num++].SetDefaults(1289, false);
					}
				}
				else if (Main.moonPhase == 1)
				{
					this.item[num].SetDefaults(325, false);
					num++;
					this.item[num].SetDefaults(326, false);
					num++;
				}
				this.item[num].SetDefaults(269, false);
				num++;
				this.item[num].SetDefaults(270, false);
				num++;
				this.item[num].SetDefaults(271, false);
				num++;
				if (NpcMgr.downedClown)
				{
					this.item[num].SetDefaults(503, false);
					num++;
					this.item[num].SetDefaults(504, false);
					num++;
					this.item[num].SetDefaults(505, false);
					num++;
				}
				if (Main.bloodMoon)
				{
					this.item[num].SetDefaults(322, false);
					num++;
					if (!Main.dayTime)
					{
						this.item[num++].SetDefaults(3362, false);
						this.item[num++].SetDefaults(3363, false);
					}
				}
				if (NpcMgr.downedAncientCultist)
				{
					if (Main.dayTime)
					{
						this.item[num++].SetDefaults(2856, false);
						this.item[num++].SetDefaults(2858, false);
					}
					else
					{
						this.item[num++].SetDefaults(2857, false);
						this.item[num++].SetDefaults(2859, false);
					}
				}
				if (NPC.AnyNPCs(441))
				{
					this.item[num++].SetDefaults(3242, false);
					this.item[num++].SetDefaults(3243, false);
					this.item[num++].SetDefaults(3244, false);
				}
				if (Main.player[Main.myPlayer].ZoneSnow)
				{
					this.item[num].SetDefaults(1429, false);
					num++;
				}
				if (Main.halloween)
				{
					this.item[num].SetDefaults(1740, false);
					num++;
				}
				if (Main.hardMode)
				{
					if (Main.moonPhase == 2)
					{
						this.item[num].SetDefaults(869, false);
						num++;
					}
					if (Main.moonPhase == 4)
					{
						this.item[num].SetDefaults(864, false);
						num++;
						this.item[num].SetDefaults(865, false);
						num++;
					}
					if (Main.moonPhase == 6)
					{
						this.item[num].SetDefaults(873, false);
						num++;
						this.item[num].SetDefaults(874, false);
						num++;
						this.item[num].SetDefaults(875, false);
						num++;
					}
				}
				if (NpcMgr.downedFrost)
				{
					this.item[num].SetDefaults(1275, false);
					num++;
					this.item[num].SetDefaults(1276, false);
					num++;
				}
				if (Main.halloween)
				{
					this.item[num++].SetDefaults(3246, false);
					this.item[num++].SetDefaults(3247, false);
				}
				if (BirthdayParty.PartyIsUp)
				{
					this.item[num++].SetDefaults(3730, false);
					this.item[num++].SetDefaults(3731, false);
					this.item[num++].SetDefaults(3733, false);
					this.item[num++].SetDefaults(3734, false);
					this.item[num++].SetDefaults(3735, false);
				}
			}
			else if (type == 6)
			{
				this.item[num].SetDefaults(128, false);
				num++;
				this.item[num].SetDefaults(486, false);
				num++;
				this.item[num].SetDefaults(398, false);
				num++;
				this.item[num].SetDefaults(84, false);
				num++;
				this.item[num].SetDefaults(407, false);
				num++;
				this.item[num].SetDefaults(161, false);
				num++;
			}
			else if (type == 7)
			{
				this.item[num].SetDefaults(487, false);
				num++;
				this.item[num].SetDefaults(496, false);
				num++;
				this.item[num].SetDefaults(500, false);
				num++;
				this.item[num].SetDefaults(507, false);
				num++;
				this.item[num].SetDefaults(508, false);
				num++;
				this.item[num].SetDefaults(531, false);
				num++;
				this.item[num].SetDefaults(576, false);
				num++;
				this.item[num].SetDefaults(3186, false);
				num++;
				if (Main.halloween)
				{
					this.item[num].SetDefaults(1739, false);
					num++;
				}
			}
			else if (type == 8)
			{
				this.item[num].SetDefaults(509, false);
				num++;
				this.item[num].SetDefaults(850, false);
				num++;
				this.item[num].SetDefaults(851, false);
				num++;
				this.item[num].SetDefaults(3612, false);
				num++;
				this.item[num].SetDefaults(510, false);
				num++;
				this.item[num].SetDefaults(530, false);
				num++;
				this.item[num].SetDefaults(513, false);
				num++;
				this.item[num].SetDefaults(538, false);
				num++;
				this.item[num].SetDefaults(529, false);
				num++;
				this.item[num].SetDefaults(541, false);
				num++;
				this.item[num].SetDefaults(542, false);
				num++;
				this.item[num].SetDefaults(543, false);
				num++;
				this.item[num].SetDefaults(852, false);
				num++;
				this.item[num].SetDefaults(853, false);
				num++;
				this.item[num++].SetDefaults(3707, false);
				this.item[num].SetDefaults(2739, false);
				num++;
				this.item[num].SetDefaults(849, false);
				num++;
				this.item[num++].SetDefaults(3616, false);
				this.item[num++].SetDefaults(2799, false);
				this.item[num++].SetDefaults(3619, false);
				this.item[num++].SetDefaults(3627, false);
				this.item[num++].SetDefaults(3629, false);
				if (NPC.AnyNPCs(369) && Main.hardMode && Main.moonPhase == 3)
				{
					this.item[num].SetDefaults(2295, false);
					num++;
				}
			}
			else if (type == 9)
			{
				this.item[num].SetDefaults(588, false);
				num++;
				this.item[num].SetDefaults(589, false);
				num++;
				this.item[num].SetDefaults(590, false);
				num++;
				this.item[num].SetDefaults(597, false);
				num++;
				this.item[num].SetDefaults(598, false);
				num++;
				this.item[num].SetDefaults(596, false);
				num++;
				for (int k = 1873; k < 1906; k++)
				{
					this.item[num].SetDefaults(k, false);
					num++;
				}
			}
			else if (type == 10)
			{
				if (NpcMgr.downedMechBossAny)
				{
					this.item[num].SetDefaults(756, false);
					num++;
					this.item[num].SetDefaults(787, false);
					num++;
				}
				this.item[num].SetDefaults(868, false);
				num++;
				if (NpcMgr.downedPlantBoss)
				{
					this.item[num].SetDefaults(1551, false);
					num++;
				}
				this.item[num].SetDefaults(1181, false);
				num++;
				this.item[num].SetDefaults(783, false);
				num++;
			}
			else if (type == 11)
			{
				this.item[num].SetDefaults(779, false);
				num++;
				if (Main.moonPhase >= 4)
				{
					this.item[num].SetDefaults(748, false);
					num++;
				}
				else
				{
					this.item[num].SetDefaults(839, false);
					num++;
					this.item[num].SetDefaults(840, false);
					num++;
					this.item[num].SetDefaults(841, false);
					num++;
				}
				if (NpcMgr.downedGolemBoss)
				{
					this.item[num].SetDefaults(948, false);
					num++;
				}
				this.item[num++].SetDefaults(3623, false);
				this.item[num++].SetDefaults(3603, false);
				this.item[num++].SetDefaults(3604, false);
				this.item[num++].SetDefaults(3607, false);
				this.item[num++].SetDefaults(3605, false);
				this.item[num++].SetDefaults(3606, false);
				this.item[num++].SetDefaults(3608, false);
				this.item[num++].SetDefaults(3618, false);
				this.item[num++].SetDefaults(3602, false);
				this.item[num++].SetDefaults(3663, false);
				this.item[num++].SetDefaults(3609, false);
				this.item[num++].SetDefaults(3610, false);
				this.item[num].SetDefaults(995, false);
				num++;
				if (NpcMgr.downedBoss1 && NpcMgr.downedBoss2 && NpcMgr.downedBoss3)
				{
					this.item[num].SetDefaults(2203, false);
					num++;
				}
				if (WorldGen.crimson)
				{
					this.item[num].SetDefaults(2193, false);
					num++;
				}
				this.item[num].SetDefaults(1263, false);
				num++;
				if (Main.eclipse || Main.bloodMoon)
				{
					if (WorldGen.crimson)
					{
						this.item[num].SetDefaults(784, false);
						num++;
					}
					else
					{
						this.item[num].SetDefaults(782, false);
						num++;
					}
				}
				else if (Main.player[Main.myPlayer].ZoneHoly)
				{
					this.item[num].SetDefaults(781, false);
					num++;
				}
				else
				{
					this.item[num].SetDefaults(780, false);
					num++;
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(1344, false);
					num++;
				}
				if (Main.halloween)
				{
					this.item[num].SetDefaults(1742, false);
					num++;
				}
			}
			else if (type == 12)
			{
				this.item[num].SetDefaults(1037, false);
				num++;
				this.item[num].SetDefaults(2874, false);
				num++;
				this.item[num].SetDefaults(1120, false);
				num++;
				if (Main.netMode == 1)
				{
					this.item[num].SetDefaults(1969, false);
					num++;
				}
				if (Main.halloween)
				{
					this.item[num].SetDefaults(3248, false);
					num++;
					this.item[num].SetDefaults(1741, false);
					num++;
				}
				if (Main.moonPhase == 0)
				{
					this.item[num].SetDefaults(2871, false);
					num++;
					this.item[num].SetDefaults(2872, false);
					num++;
				}
			}
			else if (type == 13)
			{
				this.item[num].SetDefaults(859, false);
				num++;
				this.item[num].SetDefaults(1000, false);
				num++;
				this.item[num].SetDefaults(1168, false);
				num++;
				this.item[num].SetDefaults(1449, false);
				num++;
				this.item[num].SetDefaults(1345, false);
				num++;
				this.item[num].SetDefaults(1450, false);
				num++;
				this.item[num++].SetDefaults(3253, false);
				this.item[num++].SetDefaults(2700, false);
				this.item[num++].SetDefaults(2738, false);
				if (Main.player[Main.myPlayer].HasItem(3548))
				{
					this.item[num].SetDefaults(3548, false);
					num++;
				}
				if (NPC.AnyNPCs(229))
				{
					this.item[num++].SetDefaults(3369, false);
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(3214, false);
					num++;
					this.item[num].SetDefaults(2868, false);
					num++;
					this.item[num].SetDefaults(970, false);
					num++;
					this.item[num].SetDefaults(971, false);
					num++;
					this.item[num].SetDefaults(972, false);
					num++;
					this.item[num].SetDefaults(973, false);
					num++;
				}
				this.item[num++].SetDefaults(3747, false);
				this.item[num++].SetDefaults(3732, false);
				this.item[num++].SetDefaults(3742, false);
				if (BirthdayParty.PartyIsUp)
				{
					this.item[num++].SetDefaults(3749, false);
					this.item[num++].SetDefaults(3746, false);
					this.item[num++].SetDefaults(3739, false);
					this.item[num++].SetDefaults(3740, false);
					this.item[num++].SetDefaults(3741, false);
					this.item[num++].SetDefaults(3737, false);
					this.item[num++].SetDefaults(3738, false);
					this.item[num++].SetDefaults(3736, false);
					this.item[num++].SetDefaults(3745, false);
					this.item[num++].SetDefaults(3744, false);
					this.item[num++].SetDefaults(3743, false);
				}
			}
			else if (type == 14)
			{
				this.item[num].SetDefaults(771, false);
				num++;
				if (Main.bloodMoon)
				{
					this.item[num].SetDefaults(772, false);
					num++;
				}
				if (!Main.dayTime || Main.eclipse)
				{
					this.item[num].SetDefaults(773, false);
					num++;
				}
				if (Main.eclipse)
				{
					this.item[num].SetDefaults(774, false);
					num++;
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(760, false);
					num++;
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(1346, false);
					num++;
				}
				if (Main.halloween)
				{
					this.item[num].SetDefaults(1743, false);
					num++;
					this.item[num].SetDefaults(1744, false);
					num++;
					this.item[num].SetDefaults(1745, false);
					num++;
				}
				if (NpcMgr.downedMartians)
				{
					this.item[num++].SetDefaults(2862, false);
					this.item[num++].SetDefaults(3109, false);
				}
				if (Main.player[Main.myPlayer].HasItem(3384) || Main.player[Main.myPlayer].HasItem(3664))
				{
					this.item[num].SetDefaults(3664, false);
					num++;
				}
			}
			else if (type == 15)
			{
				this.item[num].SetDefaults(1071, false);
				num++;
				this.item[num].SetDefaults(1072, false);
				num++;
				this.item[num].SetDefaults(1100, false);
				num++;
				for (int l = 1073; l <= 1084; l++)
				{
					this.item[num].SetDefaults(l, false);
					num++;
				}
				this.item[num].SetDefaults(1097, false);
				num++;
				this.item[num].SetDefaults(1099, false);
				num++;
				this.item[num].SetDefaults(1098, false);
				num++;
				this.item[num].SetDefaults(1966, false);
				num++;
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(1967, false);
					num++;
					this.item[num].SetDefaults(1968, false);
					num++;
				}
				this.item[num].SetDefaults(1490, false);
				num++;
				if (Main.moonPhase <= 1)
				{
					this.item[num].SetDefaults(1481, false);
					num++;
				}
				else if (Main.moonPhase <= 3)
				{
					this.item[num].SetDefaults(1482, false);
					num++;
				}
				else if (Main.moonPhase <= 5)
				{
					this.item[num].SetDefaults(1483, false);
					num++;
				}
				else
				{
					this.item[num].SetDefaults(1484, false);
					num++;
				}
				if (Main.player[Main.myPlayer].ZoneCrimson)
				{
					this.item[num].SetDefaults(1492, false);
					num++;
				}
				if (Main.player[Main.myPlayer].ZoneCorrupt)
				{
					this.item[num].SetDefaults(1488, false);
					num++;
				}
				if (Main.player[Main.myPlayer].ZoneHoly)
				{
					this.item[num].SetDefaults(1489, false);
					num++;
				}
				if (Main.player[Main.myPlayer].ZoneJungle)
				{
					this.item[num].SetDefaults(1486, false);
					num++;
				}
				if (Main.player[Main.myPlayer].ZoneSnow)
				{
					this.item[num].SetDefaults(1487, false);
					num++;
				}
				if (Main.sandTiles > 1000)
				{
					this.item[num].SetDefaults(1491, false);
					num++;
				}
				if (Main.bloodMoon)
				{
					this.item[num].SetDefaults(1493, false);
					num++;
				}
				if ((double)(Main.player[Main.myPlayer].position.Y / 16f) < Main.worldSurface * 0.34999999403953552)
				{
					this.item[num].SetDefaults(1485, false);
					num++;
				}
				if ((double)(Main.player[Main.myPlayer].position.Y / 16f) < Main.worldSurface * 0.34999999403953552 && Main.hardMode)
				{
					this.item[num].SetDefaults(1494, false);
					num++;
				}
				if (Main.xMas)
				{
					for (int m = 1948; m <= 1957; m++)
					{
						this.item[num].SetDefaults(m, false);
						num++;
					}
				}
				for (int n = 2158; n <= 2160; n++)
				{
					if (num < 39)
					{
						this.item[num].SetDefaults(n, false);
					}
					num++;
				}
				for (int num2 = 2008; num2 <= 2014; num2++)
				{
					if (num < 39)
					{
						this.item[num].SetDefaults(num2, false);
					}
					num++;
				}
			}
			else if (type == 16)
			{
				this.item[num].SetDefaults(1430, false);
				num++;
				this.item[num].SetDefaults(986, false);
				num++;
				if (NPC.AnyNPCs(108))
				{
					this.item[num++].SetDefaults(2999, false);
				}
				if (Main.hardMode && NpcMgr.downedPlantBoss)
				{
					if (Main.player[Main.myPlayer].HasItem(1157))
					{
						this.item[num].SetDefaults(1159, false);
						num++;
						this.item[num].SetDefaults(1160, false);
						num++;
						this.item[num].SetDefaults(1161, false);
						num++;
						if (!Main.dayTime)
						{
							this.item[num].SetDefaults(1158, false);
							num++;
						}
						if (Main.player[Main.myPlayer].ZoneJungle)
						{
							this.item[num].SetDefaults(1167, false);
							num++;
						}
					}
					this.item[num].SetDefaults(1339, false);
					num++;
				}
				if (Main.hardMode && Main.player[Main.myPlayer].ZoneJungle)
				{
					this.item[num].SetDefaults(1171, false);
					num++;
					if (!Main.dayTime)
					{
						this.item[num].SetDefaults(1162, false);
						num++;
					}
				}
				this.item[num].SetDefaults(909, false);
				num++;
				this.item[num].SetDefaults(910, false);
				num++;
				this.item[num].SetDefaults(940, false);
				num++;
				this.item[num].SetDefaults(941, false);
				num++;
				this.item[num].SetDefaults(942, false);
				num++;
				this.item[num].SetDefaults(943, false);
				num++;
				this.item[num].SetDefaults(944, false);
				num++;
				this.item[num].SetDefaults(945, false);
				num++;
				if (Main.player[Main.myPlayer].HasItem(1835))
				{
					this.item[num].SetDefaults(1836, false);
					num++;
				}
				if (Main.player[Main.myPlayer].HasItem(1258))
				{
					this.item[num].SetDefaults(1261, false);
					num++;
				}
				if (Main.halloween)
				{
					this.item[num].SetDefaults(1791, false);
					num++;
				}
			}
			else if (type == 17)
			{
				this.item[num].SetDefaults(928, false);
				num++;
				this.item[num].SetDefaults(929, false);
				num++;
				this.item[num].SetDefaults(876, false);
				num++;
				this.item[num].SetDefaults(877, false);
				num++;
				this.item[num].SetDefaults(878, false);
				num++;
				this.item[num].SetDefaults(2434, false);
				num++;
				int num3 = (int)((Main.screenPosition.X + (float)(Main.screenWidth / 2)) / 16f);
				if ((double)(Main.screenPosition.Y / 16f) < Main.worldSurface + 10.0 && (num3 < 380 || num3 > Main.maxTilesX - 380))
				{
					this.item[num].SetDefaults(1180, false);
					num++;
				}
				if (Main.hardMode && NpcMgr.downedMechBossAny && NPC.AnyNPCs(208))
				{
					this.item[num].SetDefaults(1337, false);
					num++;
				}
			}
			else if (type == 18)
			{
				this.item[num].SetDefaults(1990, false);
				num++;
				this.item[num].SetDefaults(1979, false);
				num++;
				if (Main.player[Main.myPlayer].statLifeMax >= 400)
				{
					this.item[num].SetDefaults(1977, false);
					num++;
				}
				if (Main.player[Main.myPlayer].statManaMax >= 200)
				{
					this.item[num].SetDefaults(1978, false);
					num++;
				}
				long num4 = 0L;
				for (int num5 = 0; num5 < 54; num5++)
				{
					if (Main.player[Main.myPlayer].inventory[num5].type == 71)
					{
						num4 += (long)Main.player[Main.myPlayer].inventory[num5].stack;
					}
					if (Main.player[Main.myPlayer].inventory[num5].type == 72)
					{
						num4 += (long)(Main.player[Main.myPlayer].inventory[num5].stack * 100);
					}
					if (Main.player[Main.myPlayer].inventory[num5].type == 73)
					{
						num4 += (long)(Main.player[Main.myPlayer].inventory[num5].stack * 10000);
					}
					if (Main.player[Main.myPlayer].inventory[num5].type == 74)
					{
						num4 += (long)(Main.player[Main.myPlayer].inventory[num5].stack * 1000000);
					}
				}
				if (num4 >= 1000000L)
				{
					this.item[num].SetDefaults(1980, false);
					num++;
				}
				if ((Main.moonPhase % 2 == 0 && Main.dayTime) || (Main.moonPhase % 2 == 1 && !Main.dayTime))
				{
					this.item[num].SetDefaults(1981, false);
					num++;
				}
				if (Main.player[Main.myPlayer].team != 0)
				{
					this.item[num].SetDefaults(1982, false);
					num++;
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(1983, false);
					num++;
				}
				if (NPC.AnyNPCs(208))
				{
					this.item[num].SetDefaults(1984, false);
					num++;
				}
				if (Main.hardMode && NpcMgr.downedMechBoss1 && NpcMgr.downedMechBoss2 && NpcMgr.downedMechBoss3)
				{
					this.item[num].SetDefaults(1985, false);
					num++;
				}
				if (Main.hardMode && NpcMgr.downedMechBossAny)
				{
					this.item[num].SetDefaults(1986, false);
					num++;
				}
				if (Main.hardMode && NpcMgr.downedMartians)
				{
					this.item[num].SetDefaults(2863, false);
					num++;
					this.item[num].SetDefaults(3259, false);
					num++;
				}
			}
			else if (type == 19)
			{
				for (int num6 = 0; num6 < 40; num6++)
				{
					if (Main.travelShop[num6] != 0)
					{
						this.item[num].netDefaults(Main.travelShop[num6]);
						num++;
					}
				}
			}
			else if (type == 20)
			{
				if (Main.moonPhase % 2 == 0)
				{
					this.item[num].SetDefaults(3001, false);
				}
				else
				{
					this.item[num].SetDefaults(28, false);
				}
				num++;
				if (!Main.dayTime || Main.moonPhase == 0)
				{
					this.item[num].SetDefaults(3002, false);
				}
				else
				{
					this.item[num].SetDefaults(282, false);
				}
				num++;
				if (Main.time % 60.0 * 60.0 * 6.0 <= 10800.0)
				{
					this.item[num].SetDefaults(3004, false);
				}
				else
				{
					this.item[num].SetDefaults(8, false);
				}
				num++;
				if (Main.moonPhase == 0 || Main.moonPhase == 1 || Main.moonPhase == 4 || Main.moonPhase == 5)
				{
					this.item[num].SetDefaults(3003, false);
				}
				else
				{
					this.item[num].SetDefaults(40, false);
				}
				num++;
				if (Main.moonPhase % 4 == 0)
				{
					this.item[num].SetDefaults(3310, false);
				}
				else if (Main.moonPhase % 4 == 1)
				{
					this.item[num].SetDefaults(3313, false);
				}
				else if (Main.moonPhase % 4 == 2)
				{
					this.item[num].SetDefaults(3312, false);
				}
				else
				{
					this.item[num].SetDefaults(3311, false);
				}
				num++;
				this.item[num].SetDefaults(166, false);
				num++;
				this.item[num].SetDefaults(965, false);
				num++;
				if (Main.hardMode)
				{
					if (Main.moonPhase < 4)
					{
						this.item[num].SetDefaults(3316, false);
					}
					else
					{
						this.item[num].SetDefaults(3315, false);
					}
					num++;
					this.item[num].SetDefaults(3334, false);
					num++;
					if (Main.bloodMoon)
					{
						this.item[num].SetDefaults(3258, false);
						num++;
					}
				}
				if (Main.moonPhase == 0 && !Main.dayTime)
				{
					this.item[num].SetDefaults(3043, false);
					num++;
				}
			}
			else if (type == 21)
			{
				bool flag = Main.hardMode && NpcMgr.downedMechBossAny;
				object arg_27F8_0 = Main.hardMode && NpcMgr.downedGolemBoss;
				this.item[num].SetDefaults(353, false);
				num++;
				this.item[num].SetDefaults(3828, false);
				object expr_27F8 = arg_27F8_0;
				if (expr_27F8 != null)
				{
					this.item[num].shopCustomPrice = new int?(Item.buyPrice(0, 4, 0, 0));
				}
				else if (flag)
				{
					this.item[num].shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0));
				}
				else
				{
					this.item[num].shopCustomPrice = new int?(Item.buyPrice(0, 0, 25, 0));
				}
				num++;
				this.item[num].SetDefaults(3816, false);
				num++;
				this.item[num].SetDefaults(3813, false);
				this.item[num].shopCustomPrice = new int?(75);
				this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
				num++;
				num = 10;
				this.item[num].SetDefaults(3818, false);
				this.item[num].shopCustomPrice = new int?(5);
				this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
				num++;
				this.item[num].SetDefaults(3824, false);
				this.item[num].shopCustomPrice = new int?(5);
				this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
				num++;
				this.item[num].SetDefaults(3832, false);
				this.item[num].shopCustomPrice = new int?(5);
				this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
				num++;
				this.item[num].SetDefaults(3829, false);
				this.item[num].shopCustomPrice = new int?(5);
				this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
				if (flag)
				{
					num = 20;
					this.item[num].SetDefaults(3819, false);
					this.item[num].shopCustomPrice = new int?(25);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					this.item[num].SetDefaults(3825, false);
					this.item[num].shopCustomPrice = new int?(25);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					this.item[num].SetDefaults(3833, false);
					this.item[num].shopCustomPrice = new int?(25);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					this.item[num].SetDefaults(3830, false);
					this.item[num].shopCustomPrice = new int?(25);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
				}
				if (expr_27F8 != null)
				{
					num = 30;
					this.item[num].SetDefaults(3820, false);
					this.item[num].shopCustomPrice = new int?(100);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					this.item[num].SetDefaults(3826, false);
					this.item[num].shopCustomPrice = new int?(100);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					this.item[num].SetDefaults(3834, false);
					this.item[num].shopCustomPrice = new int?(100);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					this.item[num].SetDefaults(3831, false);
					this.item[num].shopCustomPrice = new int?(100);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
				}
				if (flag)
				{
					num = 4;
					this.item[num].SetDefaults(3800, false);
					this.item[num].shopCustomPrice = new int?(25);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					this.item[num].SetDefaults(3801, false);
					this.item[num].shopCustomPrice = new int?(25);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					this.item[num].SetDefaults(3802, false);
					this.item[num].shopCustomPrice = new int?(25);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					num = 14;
					this.item[num].SetDefaults(3797, false);
					this.item[num].shopCustomPrice = new int?(25);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					this.item[num].SetDefaults(3798, false);
					this.item[num].shopCustomPrice = new int?(25);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					this.item[num].SetDefaults(3799, false);
					this.item[num].shopCustomPrice = new int?(25);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					num = 24;
					this.item[num].SetDefaults(3803, false);
					this.item[num].shopCustomPrice = new int?(25);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					this.item[num].SetDefaults(3804, false);
					this.item[num].shopCustomPrice = new int?(25);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					this.item[num].SetDefaults(3805, false);
					this.item[num].shopCustomPrice = new int?(25);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					num = 34;
					this.item[num].SetDefaults(3806, false);
					this.item[num].shopCustomPrice = new int?(25);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					this.item[num].SetDefaults(3807, false);
					this.item[num].shopCustomPrice = new int?(25);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					this.item[num].SetDefaults(3808, false);
					this.item[num].shopCustomPrice = new int?(25);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
				}
				if (expr_27F8 != null)
				{
					num = 7;
					this.item[num].SetDefaults(3871, false);
					this.item[num].shopCustomPrice = new int?(75);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					this.item[num].SetDefaults(3872, false);
					this.item[num].shopCustomPrice = new int?(75);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					this.item[num].SetDefaults(3873, false);
					this.item[num].shopCustomPrice = new int?(75);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					num = 17;
					this.item[num].SetDefaults(3874, false);
					this.item[num].shopCustomPrice = new int?(75);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					this.item[num].SetDefaults(3875, false);
					this.item[num].shopCustomPrice = new int?(75);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					this.item[num].SetDefaults(3876, false);
					this.item[num].shopCustomPrice = new int?(75);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					num = 27;
					this.item[num].SetDefaults(3877, false);
					this.item[num].shopCustomPrice = new int?(75);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					this.item[num].SetDefaults(3878, false);
					this.item[num].shopCustomPrice = new int?(75);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					this.item[num].SetDefaults(3879, false);
					this.item[num].shopCustomPrice = new int?(75);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					num = 37;
					this.item[num].SetDefaults(3880, false);
					this.item[num].shopCustomPrice = new int?(75);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					this.item[num].SetDefaults(3881, false);
					this.item[num].shopCustomPrice = new int?(75);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					this.item[num].SetDefaults(3882, false);
					this.item[num].shopCustomPrice = new int?(75);
					this.item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
				}
			}
			if (Main.player[Main.myPlayer].discount)
			{
				for (int num7 = 0; num7 < num; num7++)
				{
					this.item[num7].value = (int)((float)this.item[num7].value * 0.8f);
				}
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000042DC File Offset: 0x000024DC
		public static void SetupTravelShop()
		{
			for (int i = 0; i < 40; i++)
			{
				Main.travelShop[i] = 0;
			}
			int num = Main.rand.Next(4, 7);
			if (Main.rand.Next(4) == 0)
			{
				num++;
			}
			if (Main.rand.Next(8) == 0)
			{
				num++;
			}
			if (Main.rand.Next(16) == 0)
			{
				num++;
			}
			if (Main.rand.Next(32) == 0)
			{
				num++;
			}
			if (Main.expertMode && Main.rand.Next(2) == 0)
			{
				num++;
			}
			int num2 = 0;
			int j = 0;
			int[] array = new int[]
			{
				100,
				200,
				300,
				400,
				500,
				600
			};
			while (j < num)
			{
				int num3 = 0;
				if (Main.rand.Next(array[4]) == 0)
				{
					num3 = 3309;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num3 = 3314;
				}
				if (Main.rand.Next(array[5]) == 0)
				{
					num3 = 1987;
				}
				if (Main.rand.Next(array[4]) == 0 && Main.hardMode)
				{
					num3 = 2270;
				}
				if (Main.rand.Next(array[4]) == 0)
				{
					num3 = 2278;
				}
				if (Main.rand.Next(array[4]) == 0)
				{
					num3 = 2271;
				}
				if (Main.rand.Next(array[3]) == 0 && Main.hardMode && NpcMgr.downedPlantBoss)
				{
					num3 = 2223;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num3 = 2272;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num3 = 2219;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num3 = 2276;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num3 = 2284;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num3 = 2285;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num3 = 2286;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num3 = 2287;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num3 = 2296;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num3 = 3628;
				}
				if (Main.rand.Next(array[2]) == 0 && WorldGen.shadowOrbSmashed)
				{
					num3 = 2269;
				}
				if (Main.rand.Next(array[2]) == 0)
				{
					num3 = 2177;
				}
				if (Main.rand.Next(array[2]) == 0)
				{
					num3 = 1988;
				}
				if (Main.rand.Next(array[2]) == 0)
				{
					num3 = 2275;
				}
				if (Main.rand.Next(array[2]) == 0)
				{
					num3 = 2279;
				}
				if (Main.rand.Next(array[2]) == 0)
				{
					num3 = 2277;
				}
				if (Main.rand.Next(array[2]) == 0 && NpcMgr.downedBoss1)
				{
					num3 = 3262;
				}
				if (Main.rand.Next(array[2]) == 0 && NpcMgr.downedMechBossAny)
				{
					num3 = 3284;
				}
				if (Main.rand.Next(array[2]) == 0 && Main.hardMode && NpcMgr.downedMoonlord)
				{
					num3 = 3596;
				}
				if (Main.rand.Next(array[2]) == 0 && Main.hardMode && NpcMgr.downedMartians)
				{
					num3 = 2865;
				}
				if (Main.rand.Next(array[2]) == 0 && Main.hardMode && NpcMgr.downedMartians)
				{
					num3 = 2866;
				}
				if (Main.rand.Next(array[2]) == 0 && Main.hardMode && NpcMgr.downedMartians)
				{
					num3 = 2867;
				}
				if (Main.rand.Next(array[2]) == 0 && Main.xMas)
				{
					num3 = 3055;
				}
				if (Main.rand.Next(array[2]) == 0 && Main.xMas)
				{
					num3 = 3056;
				}
				if (Main.rand.Next(array[2]) == 0 && Main.xMas)
				{
					num3 = 3057;
				}
				if (Main.rand.Next(array[2]) == 0 && Main.xMas)
				{
					num3 = 3058;
				}
				if (Main.rand.Next(array[2]) == 0 && Main.xMas)
				{
					num3 = 3059;
				}
				if (Main.rand.Next(array[1]) == 0)
				{
					num3 = 2214;
				}
				if (Main.rand.Next(array[1]) == 0)
				{
					num3 = 2215;
				}
				if (Main.rand.Next(array[1]) == 0)
				{
					num3 = 2216;
				}
				if (Main.rand.Next(array[1]) == 0)
				{
					num3 = 2217;
				}
				if (Main.rand.Next(array[1]) == 0)
				{
					num3 = 3624;
				}
				if (Main.rand.Next(array[1]) == 0)
				{
					num3 = 2273;
				}
				if (Main.rand.Next(array[1]) == 0)
				{
					num3 = 2274;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num3 = 2266;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num3 = 2267;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num3 = 2268;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num3 = 2281 + Main.rand.Next(3);
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num3 = 2258;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num3 = 2242;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num3 = 2260;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num3 = 3637;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num3 = 3119;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num3 = 3118;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num3 = 3099;
				}
				if (num3 != 0)
				{
					for (int k = 0; k < 40; k++)
					{
						if (Main.travelShop[k] == num3)
						{
							num3 = 0;
							break;
						}
						if (num3 == 3637)
						{
							int num4 = Main.travelShop[k];
							if (num4 - 3621 <= 1 || num4 - 3633 <= 9)
							{
								num3 = 0;
							}
							if (num3 == 0)
							{
								break;
							}
						}
					}
				}
				if (num3 != 0)
				{
					j++;
					Main.travelShop[num2] = num3;
					num2++;
					if (num3 == 2260)
					{
						Main.travelShop[num2] = 2261;
						num2++;
						Main.travelShop[num2] = 2262;
						num2++;
					}
					if (num3 == 3637)
					{
						num2--;
						switch (Main.rand.Next(6))
						{
							case 0:
								Main.travelShop[num2++] = 3637;
								Main.travelShop[num2++] = 3642;
								break;
							case 1:
								Main.travelShop[num2++] = 3621;
								Main.travelShop[num2++] = 3622;
								break;
							case 2:
								Main.travelShop[num2++] = 3634;
								Main.travelShop[num2++] = 3639;
								break;
							case 3:
								Main.travelShop[num2++] = 3633;
								Main.travelShop[num2++] = 3638;
								break;
							case 4:
								Main.travelShop[num2++] = 3635;
								Main.travelShop[num2++] = 3640;
								break;
							case 5:
								Main.travelShop[num2++] = 3636;
								Main.travelShop[num2++] = 3641;
								break;
						}
					}
				}
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000319C File Offset: 0x0000139C
		public override string ToString()
		{
			int num = 0;
			for (int i = 0; i < this.item.Length; i++)
			{
				if (this.item[i].stack > 0)
				{
					num++;
				}
			}
			return string.Format("{{X: {0}, Y: {1}, Count: {2}}}", this.x, this.y, num);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003C60 File Offset: 0x00001E60
		public static bool Unlock(int X, int Y)
		{
			if (Main.tile[X, Y] == null)
			{
				return false;
			}
			short num2 = 36;
			int type = 11;
			int num = (int)(Main.tile[X, Y].frameX / 36);
			if (num <= 4)
			{
				if (num == 2)
				{
					num2 = 36;
					type = 11;
					AchievementsHelper.NotifyProgressionEvent(19);
					goto IL_95;
				}
				if (num == 4)
				{
					num2 = 36;
					type = 11;
					goto IL_95;
				}
			}
			else if (num - 23 > 4)
			{
				switch (num)
				{
					case 36:
					case 38:
					case 40:
						{
							num2 = 36;
							type = 11;
							goto IL_95;
						}
				}
			}
			else
			{
				if (!NpcMgr.downedPlantBoss)
				{
					return false;
				}
				num2 = 180;
				type = 11;
				AchievementsHelper.NotifyProgressionEvent(20);
				goto IL_95;
			}
			return false;
			IL_95:
			Main.PlaySound(22, X * 16, Y * 16, 1, 1f, 0f);
			for (int i = X; i <= X + 1; i++)
			{
				for (int j = Y; j <= Y + 1; j++)
				{
					Tile expr_C6 = Main.tile[i, j];
					expr_C6.frameX -= num2;
					for (int k = 0; k < 4; k++)
					{
						Dust.NewDust(new Vector2((float)(i * 16), (float)(j * 16)), 16, 16, type, 0f, 0f, 0, default(Color), 1f);
					}
				}
			}
			return true;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00007BEC File Offset: 0x00005DEC
		public static void UpdateChestFrames()
		{
			bool[] array = new bool[1000];
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active && Main.player[i].chest >= 0 && Main.player[i].chest < 1000)
				{
					array[Main.player[i].chest] = true;
				}
			}
			for (int j = 0; j < 1000; j++)
			{
				Chest chest = Main.chest[j];
				if (chest != null)
				{
					if (array[j])
					{
						chest.frameCounter++;
					}
					else
					{
						chest.frameCounter--;
					}
					if (chest.frameCounter < 0)
					{
						chest.frameCounter = 0;
					}
					if (chest.frameCounter > 10)
					{
						chest.frameCounter = 10;
					}
					if (chest.frameCounter == 0)
					{
						chest.frame = 0;
					}
					else if (chest.frameCounter == 10)
					{
						chest.frame = 2;
					}
					else
					{
						chest.frame = 1;
					}
				}
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003DA0 File Offset: 0x00001FA0
		public static int UsingChest(int i)
		{
			if (Main.chest[i] != null)
			{
				for (int j = 0; j < 255; j++)
				{
					if (Main.player[j].active && Main.player[j].chest == i)
					{
						return j;
					}
				}
			}
			return -1;
		}

		// Token: 0x0400002D RID: 45
		public bool bankChest;

		// Token: 0x04000021 RID: 33
		public static int[] chestItemSpawn = new int[52];

		// Token: 0x04000024 RID: 36
		public static int[] chestItemSpawn2 = new int[2];

		// Token: 0x04000020 RID: 32
		public static int[] chestTypeToIcon = new int[52];

		// Token: 0x04000023 RID: 35
		public static int[] chestTypeToIcon2 = new int[2];

		// Token: 0x04000027 RID: 39
		public static int[] dresserItemSpawn = new int[32];

		// Token: 0x04000026 RID: 38
		public static int[] dresserTypeToIcon = new int[32];

		// Token: 0x04000030 RID: 48
		public int frame;

		// Token: 0x0400002F RID: 47
		public int frameCounter;

		// Token: 0x0400002A RID: 42
		public Item[] item;

		// Token: 0x0400001F RID: 31
		public const int maxChestTypes = 52;

		// Token: 0x04000022 RID: 34
		public const int maxChestTypes2 = 2;

		// Token: 0x04000025 RID: 37
		public const int maxDresserTypes = 32;

		// Token: 0x04000028 RID: 40
		public const int maxItems = 40;

		// Token: 0x04000029 RID: 41
		public const int MaxNameLength = 20;

		// Token: 0x0400002E RID: 46
		public string name;

		// Token: 0x0400002B RID: 43
		public int x;

		// Token: 0x0400002C RID: 44
		public int y;
	}
}

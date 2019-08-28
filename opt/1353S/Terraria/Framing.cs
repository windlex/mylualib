using System;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.ID;

namespace Terraria
{
	// Token: 0x0200003A RID: 58
	public class Framing
	{
		// Token: 0x06000876 RID: 2166 RVA: 0x003ACA34 File Offset: 0x003AAC34
		public static void Initialize()
		{
			Framing.selfFrame8WayLookup = new Point16[256][];
			Framing.frameSize8Way = new Point16(18, 18);
			Framing.Add8WayLookup(0, 9, 3, 10, 3, 11, 3);
			Framing.Add8WayLookup(1, 6, 3, 7, 3, 8, 3);
			Framing.Add8WayLookup(2, 12, 0, 12, 1, 12, 2);
			Framing.Add8WayLookup(3, 15, 2);
			Framing.Add8WayLookup(4, 9, 0, 9, 1, 9, 2);
			Framing.Add8WayLookup(5, 13, 2);
			Framing.Add8WayLookup(6, 6, 4, 7, 4, 8, 4);
			Framing.Add8WayLookup(7, 14, 2);
			Framing.Add8WayLookup(8, 6, 0, 7, 0, 8, 0);
			Framing.Add8WayLookup(9, 5, 0, 5, 1, 5, 2);
			Framing.Add8WayLookup(10, 15, 0);
			Framing.Add8WayLookup(11, 15, 1);
			Framing.Add8WayLookup(12, 13, 0);
			Framing.Add8WayLookup(13, 13, 1);
			Framing.Add8WayLookup(14, 14, 0);
			Framing.Add8WayLookup(15, 14, 1);
			Framing.Add8WayLookup(19, 1, 4, 3, 4, 5, 4);
			Framing.Add8WayLookup(23, 16, 3);
			Framing.Add8WayLookup(27, 17, 0);
			Framing.Add8WayLookup(31, 13, 4);
			Framing.Add8WayLookup(37, 0, 4, 2, 4, 4, 4);
			Framing.Add8WayLookup(39, 17, 3);
			Framing.Add8WayLookup(45, 16, 0);
			Framing.Add8WayLookup(47, 12, 4);
			Framing.Add8WayLookup(55, 1, 2, 2, 2, 3, 2);
			Framing.Add8WayLookup(63, 6, 2, 7, 2, 8, 2);
			Framing.Add8WayLookup(74, 1, 3, 3, 3, 5, 3);
			Framing.Add8WayLookup(75, 17, 1);
			Framing.Add8WayLookup(78, 16, 2);
			Framing.Add8WayLookup(79, 13, 3);
			Framing.Add8WayLookup(91, 4, 0, 4, 1, 4, 2);
			Framing.Add8WayLookup(95, 11, 0, 11, 1, 11, 2);
			Framing.Add8WayLookup(111, 17, 4);
			Framing.Add8WayLookup(127, 14, 3);
			Framing.Add8WayLookup(140, 0, 3, 2, 3, 4, 3);
			Framing.Add8WayLookup(141, 16, 1);
			Framing.Add8WayLookup(142, 17, 2);
			Framing.Add8WayLookup(143, 12, 3);
			Framing.Add8WayLookup(159, 16, 4);
			Framing.Add8WayLookup(173, 0, 0, 0, 1, 0, 2);
			Framing.Add8WayLookup(175, 10, 0, 10, 1, 10, 2);
			Framing.Add8WayLookup(191, 15, 3);
			Framing.Add8WayLookup(206, 1, 0, 2, 0, 3, 0);
			Framing.Add8WayLookup(207, 6, 1, 7, 1, 8, 1);
			Framing.Add8WayLookup(223, 14, 4);
			Framing.Add8WayLookup(239, 15, 4);
			Framing.Add8WayLookup(255, 1, 1, 2, 1, 3, 1);
			Framing.blockStyleLookup = new Framing.BlockStyle[6];
			Framing.blockStyleLookup[0] = new Framing.BlockStyle(true, true, true, true);
			Framing.blockStyleLookup[1] = new Framing.BlockStyle(false, true, true, true);
			Framing.blockStyleLookup[2] = new Framing.BlockStyle(false, true, true, false);
			Framing.blockStyleLookup[3] = new Framing.BlockStyle(false, true, false, true);
			Framing.blockStyleLookup[4] = new Framing.BlockStyle(true, false, true, false);
			Framing.blockStyleLookup[5] = new Framing.BlockStyle(true, false, false, true);
			Framing.phlebasTileFrameNumberLookup = new int[][]
			{
				new int[]
				{
					2,
					4,
					2
				},
				new int[]
				{
					1,
					3,
					1
				},
				new int[]
				{
					2,
					2,
					4
				},
				new int[]
				{
					1,
					1,
					3
				}
			};
			Framing.lazureTileFrameNumberLookup = new int[][]
			{
				new int[]
				{
					1,
					3
				},
				new int[]
				{
					2,
					4
				}
			};
			int[][] expr_36D = new int[3][];
			int arg_379_1 = 0;
			int[] expr_375 = new int[3];
			expr_375[0] = 2;
			expr_36D[arg_379_1] = expr_375;
			expr_36D[1] = new int[]
			{
				0,
				1,
				4
			};
			int arg_397_1 = 2;
			int[] expr_393 = new int[3];
			expr_393[1] = 3;
			expr_36D[arg_397_1] = expr_393;
			Framing.centerWallFrameLookup = expr_36D;
			Framing.wallFrameLookup = new Point16[20][];
			Framing.wallFrameSize = new Point16(36, 36);
			Framing.AddWallFrameLookup(0, 9, 3, 10, 3, 11, 3, 6, 6);
			Framing.AddWallFrameLookup(1, 6, 3, 7, 3, 8, 3, 4, 6);
			Framing.AddWallFrameLookup(2, 12, 0, 12, 1, 12, 2, 12, 5);
			Framing.AddWallFrameLookup(3, 1, 4, 3, 4, 5, 4, 3, 6);
			Framing.AddWallFrameLookup(4, 9, 0, 9, 1, 9, 2, 9, 5);
			Framing.AddWallFrameLookup(5, 0, 4, 2, 4, 4, 4, 2, 6);
			Framing.AddWallFrameLookup(6, 6, 4, 7, 4, 8, 4, 5, 6);
			Framing.AddWallFrameLookup(7, 1, 2, 2, 2, 3, 2, 3, 5);
			Framing.AddWallFrameLookup(8, 6, 0, 7, 0, 8, 0, 6, 5);
			Framing.AddWallFrameLookup(9, 5, 0, 5, 1, 5, 2, 5, 5);
			Framing.AddWallFrameLookup(10, 1, 3, 3, 3, 5, 3, 1, 6);
			Framing.AddWallFrameLookup(11, 4, 0, 4, 1, 4, 2, 4, 5);
			Framing.AddWallFrameLookup(12, 0, 3, 2, 3, 4, 3, 0, 6);
			Framing.AddWallFrameLookup(13, 0, 0, 0, 1, 0, 2, 0, 5);
			Framing.AddWallFrameLookup(14, 1, 0, 2, 0, 3, 0, 1, 6);
			Framing.AddWallFrameLookup(15, 1, 1, 2, 1, 3, 1, 2, 5);
			Framing.AddWallFrameLookup(16, 6, 1, 7, 1, 8, 1, 7, 5);
			Framing.AddWallFrameLookup(17, 6, 2, 7, 2, 8, 2, 8, 5);
			Framing.AddWallFrameLookup(18, 10, 0, 10, 1, 10, 2, 10, 5);
			Framing.AddWallFrameLookup(19, 11, 0, 11, 1, 11, 2, 11, 5);
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x003ACF30 File Offset: 0x003AB130
		private static Framing.BlockStyle FindBlockStyle(Tile blockTile)
		{
			return Framing.blockStyleLookup[blockTile.blockType()];
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x003ACF44 File Offset: 0x003AB144
		public static void Add8WayLookup(int lookup, short point1X, short point1Y, short point2X, short point2Y, short point3X, short point3Y)
		{
			Point16[] array = new Point16[]
			{
				new Point16((int)(point1X * Framing.frameSize8Way.X), (int)(point1Y * Framing.frameSize8Way.Y)),
				new Point16((int)(point2X * Framing.frameSize8Way.X), (int)(point2Y * Framing.frameSize8Way.Y)),
				new Point16((int)(point3X * Framing.frameSize8Way.X), (int)(point3Y * Framing.frameSize8Way.Y))
			};
			Framing.selfFrame8WayLookup[lookup] = array;
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x003ACFD0 File Offset: 0x003AB1D0
		public static void Add8WayLookup(int lookup, short x, short y)
		{
			Point16[] array = new Point16[]
			{
				new Point16((int)(x * Framing.frameSize8Way.X), (int)(y * Framing.frameSize8Way.Y)),
				new Point16((int)(x * Framing.frameSize8Way.X), (int)(y * Framing.frameSize8Way.Y)),
				new Point16((int)(x * Framing.frameSize8Way.X), (int)(y * Framing.frameSize8Way.Y))
			};
			Framing.selfFrame8WayLookup[lookup] = array;
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x003AD058 File Offset: 0x003AB258
		public static void AddWallFrameLookup(int lookup, short point1X, short point1Y, short point2X, short point2Y, short point3X, short point3Y, short point4X, short point4Y)
		{
			Point16[] array = new Point16[]
			{
				new Point16((int)(point1X * Framing.wallFrameSize.X), (int)(point1Y * Framing.wallFrameSize.Y)),
				new Point16((int)(point2X * Framing.wallFrameSize.X), (int)(point2Y * Framing.wallFrameSize.Y)),
				new Point16((int)(point3X * Framing.wallFrameSize.X), (int)(point3Y * Framing.wallFrameSize.Y)),
				new Point16((int)(point4X * Framing.wallFrameSize.X), (int)(point4Y * Framing.wallFrameSize.Y))
			};
			Framing.wallFrameLookup[lookup] = array;
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x003AD10C File Offset: 0x003AB30C
		public static void SelfFrame4Way()
		{
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x003AD110 File Offset: 0x003AB310
		public static void SelfFrame8Way(int i, int j, Tile centerTile, bool resetFrame)
		{
			if (!centerTile.active())
			{
				return;
			}
			ushort num = TileID.Sets.GemsparkFramingTypes[(int)centerTile.type];
			Framing.BlockStyle arg_28_0 = Framing.FindBlockStyle(centerTile);
			int num2 = 0;
			Framing.BlockStyle blockStyle = default(Framing.BlockStyle);
			if (arg_28_0.top)
			{
				Tile tileSafely = Framing.GetTileSafely(i, j - 1);
				if (tileSafely.active() && TileID.Sets.GemsparkFramingTypes[(int)tileSafely.type] == num)
				{
					blockStyle = Framing.FindBlockStyle(tileSafely);
					if (blockStyle.bottom)
					{
						num2 |= 1;
					}
					else
					{
						blockStyle.Clear();
					}
				}
			}
			Framing.BlockStyle blockStyle2 = default(Framing.BlockStyle);
			if (arg_28_0.left)
			{
				Tile tileSafely2 = Framing.GetTileSafely(i - 1, j);
				if (tileSafely2.active() && TileID.Sets.GemsparkFramingTypes[(int)tileSafely2.type] == num)
				{
					blockStyle2 = Framing.FindBlockStyle(tileSafely2);
					if (blockStyle2.right)
					{
						num2 |= 2;
					}
					else
					{
						blockStyle2.Clear();
					}
				}
			}
			Framing.BlockStyle blockStyle3 = default(Framing.BlockStyle);
			if (arg_28_0.right)
			{
				Tile tileSafely3 = Framing.GetTileSafely(i + 1, j);
				if (tileSafely3.active() && TileID.Sets.GemsparkFramingTypes[(int)tileSafely3.type] == num)
				{
					blockStyle3 = Framing.FindBlockStyle(tileSafely3);
					if (blockStyle3.left)
					{
						num2 |= 4;
					}
					else
					{
						blockStyle3.Clear();
					}
				}
			}
			Framing.BlockStyle blockStyle4 = default(Framing.BlockStyle);
			if (arg_28_0.bottom)
			{
				Tile tileSafely4 = Framing.GetTileSafely(i, j + 1);
				if (tileSafely4.active() && TileID.Sets.GemsparkFramingTypes[(int)tileSafely4.type] == num)
				{
					blockStyle4 = Framing.FindBlockStyle(tileSafely4);
					if (blockStyle4.top)
					{
						num2 |= 8;
					}
					else
					{
						blockStyle4.Clear();
					}
				}
			}
			if (blockStyle.left && blockStyle2.top)
			{
				Tile tileSafely5 = Framing.GetTileSafely(i - 1, j - 1);
				if (tileSafely5.active() && TileID.Sets.GemsparkFramingTypes[(int)tileSafely5.type] == num)
				{
					Framing.BlockStyle blockStyle5 = Framing.FindBlockStyle(tileSafely5);
					if (blockStyle5.right && blockStyle5.bottom)
					{
						num2 |= 16;
					}
				}
			}
			if (blockStyle.right && blockStyle3.top)
			{
				Tile tileSafely6 = Framing.GetTileSafely(i + 1, j - 1);
				if (tileSafely6.active() && TileID.Sets.GemsparkFramingTypes[(int)tileSafely6.type] == num)
				{
					Framing.BlockStyle blockStyle6 = Framing.FindBlockStyle(tileSafely6);
					if (blockStyle6.left && blockStyle6.bottom)
					{
						num2 |= 32;
					}
				}
			}
			if (blockStyle4.left && blockStyle2.bottom)
			{
				Tile tileSafely7 = Framing.GetTileSafely(i - 1, j + 1);
				if (tileSafely7.active() && TileID.Sets.GemsparkFramingTypes[(int)tileSafely7.type] == num)
				{
					Framing.BlockStyle blockStyle7 = Framing.FindBlockStyle(tileSafely7);
					if (blockStyle7.right && blockStyle7.top)
					{
						num2 |= 64;
					}
				}
			}
			if (blockStyle4.right && blockStyle3.bottom)
			{
				Tile tileSafely8 = Framing.GetTileSafely(i + 1, j + 1);
				if (tileSafely8.active() && TileID.Sets.GemsparkFramingTypes[(int)tileSafely8.type] == num)
				{
					Framing.BlockStyle blockStyle8 = Framing.FindBlockStyle(tileSafely8);
					if (blockStyle8.left && blockStyle8.top)
					{
						num2 |= 128;
					}
				}
			}
			if (resetFrame)
			{
				centerTile.frameNumber((byte)WorldGen.genRand.Next(0, 3));
			}
			Point16 point = Framing.selfFrame8WayLookup[num2][(int)centerTile.frameNumber()];
			centerTile.frameX = point.X;
			centerTile.frameY = point.Y;
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x003AD438 File Offset: 0x003AB638
		public static void WallFrame(int i, int j, bool resetFrame = false)
		{
			if (i <= 0 || j <= 0 || i >= Main.maxTilesX - 1 || j >= Main.maxTilesY - 1 || Main.tile[i, j] == null)
			{
				return;
			}
			WorldGen.UpdateMapTile(i, j, true);
			Tile tile = Main.tile[i, j];
			if (tile.wall == 0)
			{
				tile.wallColor(0);
				return;
			}
			int num = 0;
			Tile tile2 = Main.tile[i, j - 1];
			if (tile2 != null && (tile2.wall > 0 || (tile2.active() && tile2.type == 54)))
			{
				num = 1;
			}
			tile2 = Main.tile[i - 1, j];
			if (tile2 != null && (tile2.wall > 0 || (tile2.active() && tile2.type == 54)))
			{
				num |= 2;
			}
			tile2 = Main.tile[i + 1, j];
			if (tile2 != null && (tile2.wall > 0 || (tile2.active() && tile2.type == 54)))
			{
				num |= 4;
			}
			tile2 = Main.tile[i, j + 1];
			if (tile2 != null && (tile2.wall > 0 || (tile2.active() && tile2.type == 54)))
			{
				num |= 8;
			}
			int num2;
			if (Main.wallLargeFrames[(int)tile.wall] == 1)
			{
				num2 = Framing.phlebasTileFrameNumberLookup[j % 4][i % 3] - 1;
				tile.wallFrameNumber((byte)num2);
			}
			else if (Main.wallLargeFrames[(int)tile.wall] == 2)
			{
				num2 = Framing.lazureTileFrameNumberLookup[i % 2][j % 2] - 1;
				tile.wallFrameNumber((byte)num2);
			}
			else if (resetFrame)
			{
				num2 = WorldGen.genRand.Next(0, 3);
				tile.wallFrameNumber((byte)num2);
			}
			else
			{
				num2 = (int)tile.wallFrameNumber();
			}
			if (num == 15)
			{
				num += Framing.centerWallFrameLookup[i % 3][j % 3];
			}
			Point16 point = Framing.wallFrameLookup[num][num2];
			tile.wallFrameX((int)point.X);
			tile.wallFrameY((int)point.Y);
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x003AD610 File Offset: 0x003AB810
		public static Tile GetTileSafely(Vector2 position)
		{
			position /= 16f;
			return Framing.GetTileSafely((int)position.X, (int)position.Y);
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x003AD634 File Offset: 0x003AB834
		public static Tile GetTileSafely(Point pt)
		{
			return Framing.GetTileSafely(pt.X, pt.Y);
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x003AD648 File Offset: 0x003AB848
		public static Tile GetTileSafely(Point16 pt)
		{
			return Framing.GetTileSafely((int)pt.X, (int)pt.Y);
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x003AD65C File Offset: 0x003AB85C
		public static Tile GetTileSafely(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			if (tile == null)
			{
				tile = new Tile();
				Main.tile[i, j] = tile;
			}
			return tile;
		}

		// Token: 0x04000D1A RID: 3354
		private static Point16[][] selfFrame8WayLookup;

		// Token: 0x04000D1B RID: 3355
		private static Point16[][] wallFrameLookup;

		// Token: 0x04000D1C RID: 3356
		private static Point16 frameSize8Way;

		// Token: 0x04000D1D RID: 3357
		private static Point16 wallFrameSize;

		// Token: 0x04000D1E RID: 3358
		private static Framing.BlockStyle[] blockStyleLookup;

		// Token: 0x04000D1F RID: 3359
		private static int[][] phlebasTileFrameNumberLookup;

		// Token: 0x04000D20 RID: 3360
		private static int[][] lazureTileFrameNumberLookup;

		// Token: 0x04000D21 RID: 3361
		private static int[][] centerWallFrameLookup;

		// Token: 0x020001DF RID: 479
		private struct BlockStyle
		{
			// Token: 0x060014D0 RID: 5328 RVA: 0x0042E7EC File Offset: 0x0042C9EC
			public BlockStyle(bool up, bool down, bool left, bool right)
			{
				this.top = up;
				this.bottom = down;
				this.left = left;
				this.right = right;
			}

			// Token: 0x060014D1 RID: 5329 RVA: 0x0042E80C File Offset: 0x0042CA0C
			public void Clear()
			{
				this.top = (this.bottom = (this.left = (this.right = false)));
			}

			// Token: 0x0400372D RID: 14125
			public bool top;

			// Token: 0x0400372E RID: 14126
			public bool bottom;

			// Token: 0x0400372F RID: 14127
			public bool left;

			// Token: 0x04003730 RID: 14128
			public bool right;
		}
	}
}

﻿using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.World.Generation;

namespace Terraria.GameContent.Generation
{
	// Token: 0x02000119 RID: 281
	public class TrackGenerator
	{
		// Token: 0x06000F62 RID: 3938 RVA: 0x003F460C File Offset: 0x003F280C
		public void Generate(int trackCount, int minimumLength)
		{
			int i = trackCount;
			while (i > 0)
			{
				int x = WorldGen.genRand.Next(150, Main.maxTilesX - 150);
				int num = WorldGen.genRand.Next((int)Main.worldSurface + 25, Main.maxTilesY - 200);
				if (this.IsLocationEmpty(x, num))
				{
					while (this.IsLocationEmpty(x, num + 1))
					{
						num++;
					}
					if (this.FindPath(x, num, minimumLength, false))
					{
						i--;
					}
				}
			}
		}

		// Token: 0x06000F63 RID: 3939 RVA: 0x003F4688 File Offset: 0x003F2888
		private bool IsLocationEmpty(int x, int y)
		{
			if (y > Main.maxTilesY - 200 || x < 0 || y < (int)Main.worldSurface || x > Main.maxTilesX - 5)
			{
				return false;
			}
			for (int i = 0; i < 6; i++)
			{
				if (WorldGen.SolidTile(x, y - i))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000F64 RID: 3940 RVA: 0x003F46D8 File Offset: 0x003F28D8
		private bool CanTrackBePlaced(int x, int y)
		{
			if (y > Main.maxTilesY - 200 || x < 0 || y < (int)Main.worldSurface || x > Main.maxTilesX - 5)
			{
				return false;
			}
			byte wall = Main.tile[x, y].wall;
			for (int i = 0; i < TrackGenerator.INVALID_WALLS.Length; i++)
			{
				if (wall == TrackGenerator.INVALID_WALLS[i])
				{
					return false;
				}
			}
			for (int j = -1; j <= 1; j++)
			{
				if (Main.tile[x + j, y].active() && (Main.tile[x + j, y].type == 314 || !TileID.Sets.GeneralPlacementTiles[(int)Main.tile[x + j, y].type]))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000F65 RID: 3941 RVA: 0x003F4798 File Offset: 0x003F2998
		private void SmoothTrack(TrackGenerator.TrackHistory[] history, int length)
		{
			int num = length - 1;
			bool flag = false;
			for (int i = length - 1; i >= 0; i--)
			{
				if (flag)
				{
					num = Math.Min(i + 15, num);
					if (history[i].Y >= history[num].Y)
					{
						int num2 = i + 1;
						while (history[num2].Y > history[i].Y)
						{
							history[num2].Y = history[i].Y;
							num2++;
						}
						if (history[i].Y == history[num].Y)
						{
							flag = false;
						}
					}
				}
				else if (history[i].Y > history[num].Y)
				{
					flag = true;
				}
				else
				{
					num = i;
				}
			}
		}

		// Token: 0x06000F66 RID: 3942 RVA: 0x003F4864 File Offset: 0x003F2A64
		public bool FindPath(int x, int y, int minimumLength, bool debugMode = false)
		{
			TrackGenerator.TrackHistory[] historyCache = this._historyCache;
			int num = 0;
			Tile[,] arg_0E_0 = Main.tile;
			bool flag = true;
			int num2 = (WorldGen.genRand.Next(2) == 0) ? 1 : -1;
			if (debugMode)
			{
				num2 = Main.player[Main.myPlayer].direction;
			}
			int num3 = 1;
			int num4 = 0;
			int num5 = 400;
			bool flag2 = false;
			int num6 = 150;
			int num7 = 0;
			int num8 = 1000000;
			while ((num8 > 0 & flag) && num < historyCache.Length - 1)
			{
				num8--;
				historyCache[num] = new TrackGenerator.TrackHistory(x, y, num3);
				bool flag3 = false;
				int num9 = 1;
				if (num > minimumLength >> 1)
				{
					num9 = -1;
				}
				else if (num > (minimumLength >> 1) - 5)
				{
					num9 = 0;
				}
				if (flag2)
				{
					int num10 = 0;
					int num11 = num6;
					bool flag4 = false;
					for (int i = Math.Min(1, num3 + 1); i >= Math.Max(-1, num3 - 1); i--)
					{
						int j;
						for (j = 0; j <= num6; j++)
						{
							if (this.IsLocationEmpty(x + (j + 1) * num2, y + (j + 1) * i * num9))
							{
								flag4 = true;
								break;
							}
						}
						if (j < num11)
						{
							num11 = j;
							num10 = i;
						}
					}
					if (flag4)
					{
						num3 = num10;
						for (int k = 0; k < num11 - 1; k++)
						{
							num++;
							x += num2;
							y += num3 * num9;
							historyCache[num] = new TrackGenerator.TrackHistory(x, y, num3);
							num7 = num;
						}
						x += num2;
						y += num3 * num9;
						num4 = num + 1;
						flag2 = false;
					}
					num6 -= num11;
					if (num6 < 0)
					{
						flag = false;
					}
				}
				else
				{
					for (int l = Math.Min(1, num3 + 1); l >= Math.Max(-1, num3 - 1); l--)
					{
						if (this.IsLocationEmpty(x + num2, y + l * num9))
						{
							num3 = l;
							flag3 = true;
							x += num2;
							y += num3 * num9;
							num4 = num + 1;
							break;
						}
					}
					if (!flag3)
					{
						while (num > num7 && y == (int)historyCache[num].Y)
						{
							num--;
						}
						x = (int)historyCache[num].X;
						y = (int)historyCache[num].Y;
						num3 = (int)(historyCache[num].YDirection - 1);
						num5--;
						if (num5 <= 0)
						{
							num = num4;
							x = (int)historyCache[num].X;
							y = (int)historyCache[num].Y;
							num3 = (int)historyCache[num].YDirection;
							flag2 = true;
							num5 = 200;
						}
						num--;
					}
				}
				num++;
			}
			if (num4 > minimumLength | debugMode)
			{
				this.SmoothTrack(historyCache, num4);
				if (!debugMode)
				{
					for (int m = 0; m < num4; m++)
					{
						for (int n = -1; n < 7; n++)
						{
							if (!this.CanTrackBePlaced((int)historyCache[m].X, (int)historyCache[m].Y - n))
							{
								return false;
							}
						}
					}
				}
				for (int num12 = 0; num12 < num4; num12++)
				{
					TrackGenerator.TrackHistory trackHistory = historyCache[num12];
					for (int num13 = 0; num13 < 6; num13++)
					{
						Main.tile[(int)trackHistory.X, (int)trackHistory.Y - num13].active(false);
					}
				}
				for (int num14 = 0; num14 < num4; num14++)
				{
					TrackGenerator.TrackHistory trackHistory2 = historyCache[num14];
					Tile.SmoothSlope((int)trackHistory2.X, (int)(trackHistory2.Y + 1), true);
					Tile.SmoothSlope((int)trackHistory2.X, (int)(trackHistory2.Y - 6), true);
					bool wire = Main.tile[(int)trackHistory2.X, (int)trackHistory2.Y].wire();
					Main.tile[(int)trackHistory2.X, (int)trackHistory2.Y].ResetToType(314);
					Main.tile[(int)trackHistory2.X, (int)trackHistory2.Y].wire(wire);
					if (num14 != 0)
					{
						for (int num15 = 0; num15 < 6; num15++)
						{
							WorldUtils.TileFrame((int)historyCache[num14 - 1].X, (int)historyCache[num14 - 1].Y - num15, true);
						}
						if (num14 == num4 - 1)
						{
							for (int num16 = 0; num16 < 6; num16++)
							{
								WorldUtils.TileFrame((int)trackHistory2.X, (int)trackHistory2.Y - num16, true);
							}
						}
					}
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000F67 RID: 3943 RVA: 0x003F4CA4 File Offset: 0x003F2EA4
		public static void Run(int trackCount = 30, int minimumLength = 250)
		{
			new TrackGenerator().Generate(trackCount, minimumLength);
		}

		// Token: 0x06000F68 RID: 3944 RVA: 0x003F4CB4 File Offset: 0x003F2EB4
		public static void Run(Point start)
		{
			new TrackGenerator().FindPath(start.X, start.Y, 250, true);
		}

		// Token: 0x04003058 RID: 12376
		private static readonly byte[] INVALID_WALLS = new byte[]
		{
			7,
			94,
			95,
			8,
			98,
			99,
			9,
			96,
			97,
			3,
			83,
			87,
			86
		};

		// Token: 0x04003059 RID: 12377
		private const int TOTAL_TILE_IGNORES = 150;

		// Token: 0x0400305A RID: 12378
		private const int PLAYER_HEIGHT = 6;

		// Token: 0x0400305B RID: 12379
		private const int MAX_RETRIES = 400;

		// Token: 0x0400305C RID: 12380
		private const int MAX_SMOOTH_DISTANCE = 15;

		// Token: 0x0400305D RID: 12381
		private const int MAX_ITERATIONS = 1000000;

		// Token: 0x0400305E RID: 12382
		private TrackGenerator.TrackHistory[] _historyCache = new TrackGenerator.TrackHistory[2048];

		// Token: 0x0200028A RID: 650
		private struct TrackHistory
		{
			// Token: 0x060016AA RID: 5802 RVA: 0x00438E9C File Offset: 0x0043709C
			public TrackHistory(int x, int y, int yDirection)
			{
				this.X = (short)x;
				this.Y = (short)y;
				this.YDirection = (byte)yDirection;
			}

			// Token: 0x060016AB RID: 5803 RVA: 0x00438EB8 File Offset: 0x004370B8
			public TrackHistory(short x, short y, byte yDirection)
			{
				this.X = x;
				this.Y = y;
				this.YDirection = yDirection;
			}

			// Token: 0x04003C8A RID: 15498
			public short X;

			// Token: 0x04003C8B RID: 15499
			public short Y;

			// Token: 0x04003C8C RID: 15500
			public byte YDirection;
		}
	}
}

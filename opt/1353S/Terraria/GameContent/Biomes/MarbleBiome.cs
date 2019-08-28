using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
	// Token: 0x02000123 RID: 291
	public class MarbleBiome : MicroBiome
	{
		// Token: 0x06000FAE RID: 4014 RVA: 0x003F7584 File Offset: 0x003F5784
		private void SmoothSlope(int x, int y)
		{
			MarbleBiome.Slab slab = this._slabs[x, y];
			if (!slab.IsSolid)
			{
				return;
			}
			bool arg_6B_0 = this._slabs[x, y - 1].IsSolid;
			bool isSolid = this._slabs[x, y + 1].IsSolid;
			bool isSolid2 = this._slabs[x - 1, y].IsSolid;
			bool isSolid3 = this._slabs[x + 1, y].IsSolid;
			switch ((arg_6B_0 ? 1 : 0) << 3 | (isSolid ? 1 : 0) << 2 | (isSolid2 ? 1 : 0) << 1 | (isSolid3 ? 1 : 0))
			{
			case 4:
				this._slabs[x, y] = slab.WithState(new MarbleBiome.SlabState(MarbleBiome.SlabStates.HalfBrick));
				return;
			case 5:
				this._slabs[x, y] = slab.WithState(new MarbleBiome.SlabState(MarbleBiome.SlabStates.BottomRightFilled));
				return;
			case 6:
				this._slabs[x, y] = slab.WithState(new MarbleBiome.SlabState(MarbleBiome.SlabStates.BottomLeftFilled));
				return;
			case 9:
				this._slabs[x, y] = slab.WithState(new MarbleBiome.SlabState(MarbleBiome.SlabStates.TopRightFilled));
				return;
			case 10:
				this._slabs[x, y] = slab.WithState(new MarbleBiome.SlabState(MarbleBiome.SlabStates.TopLeftFilled));
				return;
			}
			this._slabs[x, y] = slab.WithState(new MarbleBiome.SlabState(MarbleBiome.SlabStates.Solid));
		}

		// Token: 0x06000FAF RID: 4015 RVA: 0x003F7714 File Offset: 0x003F5914
		private void PlaceSlab(MarbleBiome.Slab slab, int originX, int originY, int scale)
		{
			for (int i = 0; i < scale; i++)
			{
				for (int j = 0; j < scale; j++)
				{
					Tile tile = GenBase._tiles[originX + i, originY + j];
					if (TileID.Sets.Ore[(int)tile.type])
					{
						tile.ResetToType(tile.type);
					}
					else
					{
						tile.ResetToType(367);
					}
					bool active = slab.State(i, j, scale);
					tile.active(active);
					if (slab.HasWall)
					{
						tile.wall = 178;
					}
					WorldUtils.TileFrame(originX + i, originY + j, true);
					WorldGen.SquareWallFrame(originX + i, originY + j, true);
					Tile.SmoothSlope(originX + i, originY + j, true);
					if (WorldGen.SolidTile(originX + i, originY + j - 1) && GenBase._random.Next(4) == 0)
					{
						WorldGen.PlaceTight(originX + i, originY + j, 165, false);
					}
					if (WorldGen.SolidTile(originX + i, originY + j) && GenBase._random.Next(4) == 0)
					{
						WorldGen.PlaceTight(originX + i, originY + j - 1, 165, false);
					}
				}
			}
		}

		// Token: 0x06000FB0 RID: 4016 RVA: 0x003F7828 File Offset: 0x003F5A28
		private bool IsGroupSolid(int x, int y, int scale)
		{
			int num = 0;
			for (int i = 0; i < scale; i++)
			{
				for (int j = 0; j < scale; j++)
				{
					if (WorldGen.SolidOrSlopedTile(x + i, y + j))
					{
						num++;
					}
				}
			}
			return num > scale / 4 * 3;
		}

		// Token: 0x06000FB1 RID: 4017 RVA: 0x003F7868 File Offset: 0x003F5A68
		public override bool Place(Point origin, StructureMap structures)
		{
			if (this._slabs == null)
			{
				this._slabs = new MarbleBiome.Slab[56, 26];
			}
			int num = GenBase._random.Next(80, 150) / 3;
			int num2 = GenBase._random.Next(40, 60) / 3;
			int num3 = (num2 * 3 - GenBase._random.Next(20, 30)) / 3;
			origin.X -= num * 3 / 2;
			origin.Y -= num2 * 3 / 2;
			for (int i = -1; i < num + 1; i++)
			{
				float num4 = (float)(i - num / 2) / (float)num + 0.5f;
				int num5 = (int)((0.5f - Math.Abs(num4 - 0.5f)) * 5f) - 2;
				for (int j = -1; j < num2 + 1; j++)
				{
					bool hasWall = true;
					bool flag = false;
					bool flag2 = this.IsGroupSolid(i * 3 + origin.X, j * 3 + origin.Y, 3);
					int num6 = Math.Abs(j - num2 / 2) - num3 / 4 + num5;
					if (num6 > 3)
					{
						flag = flag2;
						hasWall = false;
					}
					else if (num6 > 0)
					{
						flag = (j - num2 / 2 > 0 | flag2);
						hasWall = (j - num2 / 2 < 0 || num6 <= 2);
					}
					else if (num6 == 0)
					{
						flag = (GenBase._random.Next(2) == 0 && (j - num2 / 2 > 0 | flag2));
					}
					if (Math.Abs(num4 - 0.5f) > 0.35f + GenBase._random.NextFloat() * 0.1f && !flag2)
					{
						hasWall = false;
						flag = false;
					}
					this._slabs[i + 1, j + 1] = MarbleBiome.Slab.Create(flag ? new MarbleBiome.SlabState(MarbleBiome.SlabStates.Solid) : new MarbleBiome.SlabState(MarbleBiome.SlabStates.Empty), hasWall);
				}
			}
			for (int k = 0; k < num; k++)
			{
				for (int l = 0; l < num2; l++)
				{
					this.SmoothSlope(k + 1, l + 1);
				}
			}
			int num7 = num / 2;
			int num8 = num2 / 2;
			int num9 = (num8 + 1) * (num8 + 1);
			float value = GenBase._random.NextFloat() * 2f - 1f;
			float num10 = GenBase._random.NextFloat() * 2f - 1f;
			float value2 = GenBase._random.NextFloat() * 2f - 1f;
			float num11 = 0f;
			for (int m = 0; m <= num; m++)
			{
				float num12 = (float)num8 / (float)num7 * (float)(m - num7);
				int num13 = Math.Min(num8, (int)Math.Sqrt((double)Math.Max(0f, (float)num9 - num12 * num12)));
				if (m < num / 2)
				{
					num11 += MathHelper.Lerp(value, num10, (float)m / (float)(num / 2));
				}
				else
				{
					num11 += MathHelper.Lerp(num10, value2, (float)m / (float)(num / 2) - 1f);
				}
				for (int n = num8 - num13; n <= num8 + num13; n++)
				{
					this.PlaceSlab(this._slabs[m + 1, n + 1], m * 3 + origin.X, n * 3 + origin.Y + (int)num11, 3);
				}
			}
			return true;
		}

		// Token: 0x04003074 RID: 12404
		private const int SCALE = 3;

		// Token: 0x04003075 RID: 12405
		private MarbleBiome.Slab[,] _slabs;

		// Token: 0x0200028E RID: 654
		// (Invoke) Token: 0x060016B5 RID: 5813
		private delegate bool SlabState(int x, int y, int scale);

		// Token: 0x0200028F RID: 655
		private class SlabStates
		{
			// Token: 0x060016B8 RID: 5816 RVA: 0x00438F18 File Offset: 0x00437118
			public static bool Empty(int x, int y, int scale)
			{
				return false;
			}

			// Token: 0x060016B9 RID: 5817 RVA: 0x00438F1C File Offset: 0x0043711C
			public static bool Solid(int x, int y, int scale)
			{
				return true;
			}

			// Token: 0x060016BA RID: 5818 RVA: 0x00438F20 File Offset: 0x00437120
			public static bool HalfBrick(int x, int y, int scale)
			{
				return y >= scale / 2;
			}

			// Token: 0x060016BB RID: 5819 RVA: 0x00438F2C File Offset: 0x0043712C
			public static bool BottomRightFilled(int x, int y, int scale)
			{
				return x >= scale - y;
			}

			// Token: 0x060016BC RID: 5820 RVA: 0x00438F38 File Offset: 0x00437138
			public static bool BottomLeftFilled(int x, int y, int scale)
			{
				return x < y;
			}

			// Token: 0x060016BD RID: 5821 RVA: 0x00438F40 File Offset: 0x00437140
			public static bool TopRightFilled(int x, int y, int scale)
			{
				return x > y;
			}

			// Token: 0x060016BE RID: 5822 RVA: 0x00438F48 File Offset: 0x00437148
			public static bool TopLeftFilled(int x, int y, int scale)
			{
				return x < scale - y;
			}
		}

		// Token: 0x02000290 RID: 656
		private struct Slab
		{
			// Token: 0x170001C7 RID: 455
			// (get) Token: 0x060016C0 RID: 5824 RVA: 0x00438F58 File Offset: 0x00437158
			public bool IsSolid
			{
				get
				{
					return this.State != new MarbleBiome.SlabState(MarbleBiome.SlabStates.Empty);
				}
			}

			// Token: 0x060016C1 RID: 5825 RVA: 0x00438F74 File Offset: 0x00437174
			private Slab(MarbleBiome.SlabState state, bool hasWall)
			{
				this.State = state;
				this.HasWall = hasWall;
			}

			// Token: 0x060016C2 RID: 5826 RVA: 0x00438F84 File Offset: 0x00437184
			public MarbleBiome.Slab WithState(MarbleBiome.SlabState state)
			{
				return new MarbleBiome.Slab(state, this.HasWall);
			}

			// Token: 0x060016C3 RID: 5827 RVA: 0x00438F94 File Offset: 0x00437194
			public static MarbleBiome.Slab Create(MarbleBiome.SlabState state, bool hasWall)
			{
				return new MarbleBiome.Slab(state, hasWall);
			}

			// Token: 0x04003C99 RID: 15513
			public readonly MarbleBiome.SlabState State;

			// Token: 0x04003C9A RID: 15514
			public readonly bool HasWall;
		}
	}
}

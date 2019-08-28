using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
	// Token: 0x02000121 RID: 289
	public class GraniteBiome : MicroBiome
	{
		// Token: 0x06000FA9 RID: 4009 RVA: 0x003F5A3C File Offset: 0x003F3C3C
		public unsafe override bool Place(Point origin, StructureMap structures)
		{
			if (GenBase._tiles[origin.X, origin.Y].active())
			{
				return false;
			}
			int length = GraniteBiome._sourceMagmaMap.GetLength(0);
			int length2 = GraniteBiome._sourceMagmaMap.GetLength(1);
			int num = length / 2;
			int num2 = length2 / 2;
			origin.X -= num;
			origin.Y -= num2;
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length2; j++)
				{
					int i2 = i + origin.X;
					int j2 = j + origin.Y;
					GraniteBiome._sourceMagmaMap[i, j] = GraniteBiome.Magma.CreateEmpty(WorldGen.SolidTile(i2, j2) ? 4f : 1f);
					GraniteBiome._targetMagmaMap[i, j] = GraniteBiome._sourceMagmaMap[i, j];
				}
			}
			int num3 = num;
			int num4 = num;
			int num5 = num2;
			int num6 = num2;
			for (int k = 0; k < 300; k++)
			{
				for (int l = num3; l <= num4; l++)
				{
					for (int m = num5; m <= num6; m++)
					{
						GraniteBiome.Magma magma = GraniteBiome._sourceMagmaMap[l, m];
						if (magma.IsActive)
						{
							float num7 = 0f;
							Vector2 value = Vector2.Zero;
							for (int n = -1; n <= 1; n++)
							{
								for (int num8 = -1; num8 <= 1; num8++)
								{
									if (n != 0 || num8 != 0)
									{
										Vector2 value2 = new Vector2((float)n, (float)num8);
										value2.Normalize();
										GraniteBiome.Magma magma2 = GraniteBiome._sourceMagmaMap[l + n, m + num8];
										if (magma.Pressure > 0.01f && !magma2.IsActive)
										{
											if (n == -1)
											{
												num3 = Utils.Clamp<int>(l + n, 1, num3);
											}
											else
											{
												num4 = Utils.Clamp<int>(l + n, num4, length - 2);
											}
											if (num8 == -1)
											{
												num5 = Utils.Clamp<int>(m + num8, 1, num5);
											}
											else
											{
												num6 = Utils.Clamp<int>(m + num8, num6, length2 - 2);
											}
											GraniteBiome._targetMagmaMap[l + n, m + num8] = magma2.ToFlow();
										}
										float pressure = magma2.Pressure;
										num7 += pressure;
										value += pressure * value2;
									}
								}
							}
							num7 /= 8f;
							if (num7 > magma.Resistance)
							{
								float num9 = value.Length() / 8f;
								float num10 = Math.Max(num7 - num9 - magma.Pressure, 0f) + num9 + magma.Pressure * 0.875f - magma.Resistance;
								num10 = Math.Max(0f, num10);
								GraniteBiome._targetMagmaMap[l, m] = GraniteBiome.Magma.CreateFlow(num10, Math.Max(0f, magma.Resistance - num10 * 0.02f));
							}
						}
					}
				}
				if (k < 2)
				{
					GraniteBiome._targetMagmaMap[num, num2] = GraniteBiome.Magma.CreateFlow(25f, 0f);
				}
				Utils.Swap<GraniteBiome.Magma[,]>(ref GraniteBiome._sourceMagmaMap, ref GraniteBiome._targetMagmaMap);
			}
			bool flag = origin.Y + num2 > WorldGen.lavaLine - 30;
			bool flag2 = false;
			int num11 = -50;
			while (num11 < 50 && !flag2)
			{
				int num12 = -50;
				while (num12 < 50 && !flag2)
				{
					if (GenBase._tiles[origin.X + num + num11, origin.Y + num2 + num12].active())
					{
						ushort type = GenBase._tiles[origin.X + num + num11, origin.Y + num2 + num12].type;
						if (type == 147 || type - 161 <= 2 || type == 200)
						{
							flag = false;
							flag2 = true;
						}
					}
					num12++;
				}
				num11++;
			}
			for (int num13 = num3; num13 <= num4; num13++)
			{
				for (int num14 = num5; num14 <= num6; num14++)
				{
					GraniteBiome.Magma magma3 = GraniteBiome._sourceMagmaMap[num13, num14];
					if (magma3.IsActive)
					{
						Tile tile = GenBase._tiles[origin.X + num13, origin.Y + num14];
						float num15 = (float)Math.Sin((double)((float)(origin.Y + num14) * 0.4f)) * 0.7f + 1.2f;
						float num16 = 0.2f + 0.5f / (float)Math.Sqrt((double)Math.Max(0f, magma3.Pressure - magma3.Resistance));
						if (Math.Max(1f - Math.Max(0f, num15 * num16), magma3.Pressure / 15f) > 0.35f + (WorldGen.SolidTile(origin.X + num13, origin.Y + num14) ? 0f : 0.5f))
						{
							if (TileID.Sets.Ore[(int)tile.type])
							{
								tile.ResetToType(tile.type);
							}
							else
							{
								tile.ResetToType(368);
							}
							tile.wall = 180;
						}
						else if (magma3.Resistance < 0.01f)
						{
							WorldUtils.ClearTile(origin.X + num13, origin.Y + num14, false);
							tile.wall = 180;
						}
						if (tile.liquid > 0 & flag)
						{
							tile.liquidType(1);
						}
					}
				}
			}
			List<Point16> list = new List<Point16>();
			for (int num17 = num3; num17 <= num4; num17++)
			{
				for (int num18 = num5; num18 <= num6; num18++)
				{
					if (GraniteBiome._sourceMagmaMap[num17, num18].IsActive)
					{
						int num19 = 0;
						int num20 = num17 + origin.X;
						int num21 = num18 + origin.Y;
						if (WorldGen.SolidTile(num20, num21))
						{
							for (int num22 = -1; num22 <= 1; num22++)
							{
								for (int num23 = -1; num23 <= 1; num23++)
								{
									if (WorldGen.SolidTile(num20 + num22, num21 + num23))
									{
										num19++;
									}
								}
							}
							if (num19 < 3)
							{
								list.Add(new Point16(num20, num21));
							}
						}
					}
				}
			}
			foreach (Point16 expr_636 in list)
			{
				int x = (int)expr_636.X;
				int y = (int)expr_636.Y;
				WorldUtils.ClearTile(x, y, true);
				GenBase._tiles[x, y].wall = 180;
			}
			list.Clear();
			for (int num24 = num3; num24 <= num4; num24++)
			{
				for (int num25 = num5; num25 <= num6; num25++)
				{
					int num26 = num24 + origin.X;
					int num27 = num25 + origin.Y;
					if (GraniteBiome._sourceMagmaMap[num24, num25].IsActive)
					{
						WorldUtils.TileFrame(num26, num27, false);
						WorldGen.SquareWallFrame(num26, num27, true);
						if (GenBase._random.Next(8) == 0 && GenBase._tiles[num26, num27].active())
						{
							if (!GenBase._tiles[num26, num27 + 1].active())
							{
								WorldGen.PlaceTight(num26, num27 + 1, 165, false);
							}
							if (!GenBase._tiles[num26, num27 - 1].active())
							{
								WorldGen.PlaceTight(num26, num27 - 1, 165, false);
							}
						}
						if (GenBase._random.Next(2) == 0)
						{
							Tile.SmoothSlope(num26, num27, true);
						}
					}
				}
			}
			return true;
		}

		// Token: 0x04003071 RID: 12401
		private const int MAX_MAGMA_ITERATIONS = 300;

		// Token: 0x04003072 RID: 12402
		private static GraniteBiome.Magma[,] _sourceMagmaMap = new GraniteBiome.Magma[200, 200];

		// Token: 0x04003073 RID: 12403
		private static GraniteBiome.Magma[,] _targetMagmaMap = new GraniteBiome.Magma[200, 200];

		// Token: 0x0200028D RID: 653
		private struct Magma
		{
			// Token: 0x060016B0 RID: 5808 RVA: 0x0043763D File Offset: 0x0043583D
			private Magma(float pressure, float resistance, bool active)
			{
				this.Pressure = pressure;
				this.Resistance = resistance;
				this.IsActive = active;
			}

			// Token: 0x060016B3 RID: 5811 RVA: 0x00437672 File Offset: 0x00435872
			public static GraniteBiome.Magma CreateEmpty(float resistance = 0f)
			{
				return new GraniteBiome.Magma(0f, resistance, false);
			}

			// Token: 0x060016B2 RID: 5810 RVA: 0x00437668 File Offset: 0x00435868
			public static GraniteBiome.Magma CreateFlow(float pressure, float resistance = 0f)
			{
				return new GraniteBiome.Magma(pressure, resistance, true);
			}

			// Token: 0x060016B1 RID: 5809 RVA: 0x00437654 File Offset: 0x00435854
			public GraniteBiome.Magma ToFlow()
			{
				return new GraniteBiome.Magma(this.Pressure, this.Resistance, true);
			}

			// Token: 0x04003C96 RID: 15510
			public readonly float Pressure;

			// Token: 0x04003C97 RID: 15511
			public readonly float Resistance;

			// Token: 0x04003C98 RID: 15512
			public readonly bool IsActive;
		}
	}
}

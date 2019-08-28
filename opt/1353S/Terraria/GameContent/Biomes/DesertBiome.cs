using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
	// Token: 0x02000127 RID: 295
	public class DesertBiome : MicroBiome
	{
		// Token: 0x06000FC8 RID: 4040 RVA: 0x003FA8D0 File Offset: 0x003F8AD0
		private void PlaceSand(DesertBiome.ClusterGroup clusters, Point start, Vector2 scale)
		{
			int num = (int)(scale.X * (float)clusters.Width);
			int num2 = (int)(scale.Y * (float)clusters.Height);
			int num3 = 5;
			int num4 = start.Y + (num2 >> 1);
			float num5 = 0f;
			short[] array = new short[num + num3 * 2];
			for (int i = -num3; i < num + num3; i++)
			{
				for (int j = 150; j < num4; j++)
				{
					if (WorldGen.SolidOrSlopedTile(i + start.X, j))
					{
						num5 += (float)(j - 1);
						array[i + num3] = (short)(j - 1);
						break;
					}
				}
			}
			float num6 = num5 / (float)(num + num3 * 2);
			int num7 = 0;
			for (int k = -num3; k < num + num3; k++)
			{
				float num8 = Math.Abs((float)(k + num3) / (float)(num + num3 * 2)) * 2f - 1f;
				num8 = MathHelper.Clamp(num8, -1f, 1f);
				if (k % 3 == 0)
				{
					num7 = Utils.Clamp<int>(num7 + GenBase._random.Next(-1, 2), -10, 10);
				}
				float num9 = (float)Math.Sqrt((double)(1f - num8 * num8 * num8 * num8));
				int num10 = num4 - (int)(num9 * ((float)num4 - num6)) + num7;
				int num11 = num4 - (int)(((float)num4 - num6) * (num9 - 0.15f / (float)Math.Sqrt(Math.Max(0.01, (double)Math.Abs(8f * num8) - 0.1)) + 0.25f));
				num11 = Math.Min(num4, num11);
				if (Math.Abs(num8) < 0.8f)
				{
					float num12 = Utils.SmoothStep(0.5f, 0.8f, Math.Abs(num8));
					num12 = num12 * num12 * num12;
					int num13 = 10 + (int)(num6 - num12 * 20f) + num7;
					num13 = Math.Min(num13, num10);
					int num14 = 50;
					int num15 = num14;
					while ((float)num15 < num6)
					{
						int num16 = k + start.X;
						if (GenBase._tiles[num16, num15].active() && (GenBase._tiles[num16, num15].type == 189 || GenBase._tiles[num16, num15].type == 196))
						{
							num14 = num15 + 5;
						}
						num15++;
					}
					for (int l = num14; l < num13; l++)
					{
						int num17 = k + start.X;
						int num18 = l;
						GenBase._tiles[num17, num18].active(false);
						GenBase._tiles[num17, num18].wall = 0;
					}
					array[k + num3] = (short)num13;
				}
				for (int m = num4 - 1; m >= num10; m--)
				{
					int num19 = k + start.X;
					int num20 = m;
					Tile tile = GenBase._tiles[num19, num20];
					tile.liquid = 0;
					Tile testTile = GenBase._tiles[num19, num20 + 1];
					Tile testTile2 = GenBase._tiles[num19, num20 + 2];
					tile.type = (ushort)((WorldGen.SolidTile(testTile) && WorldGen.SolidTile(testTile2)) ? 53 : 397);
					if (m > num10 + 5)
					{
						tile.wall = 187;
					}
					tile.active(true);
					if (tile.wall != 187)
					{
						tile.wall = 0;
					}
					if (m < num11)
					{
						if (m > num10 + 5)
						{
							tile.wall = 187;
						}
						tile.active(false);
					}
					WorldGen.SquareWallFrame(num19, num20, true);
				}
			}
		}

		// Token: 0x06000FC9 RID: 4041 RVA: 0x003FAC60 File Offset: 0x003F8E60
		private void PlaceClusters(DesertBiome.ClusterGroup clusters, Point start, Vector2 scale)
		{
			int num = (int)(scale.X * (float)clusters.Width);
			int num2 = (int)(scale.Y * (float)clusters.Height);
			Vector2 value = new Vector2((float)num, (float)num2);
			Vector2 value2 = new Vector2((float)clusters.Width, (float)clusters.Height);
			for (int i = -20; i < num + 20; i++)
			{
				for (int j = -20; j < num2 + 20; j++)
				{
					float num3 = 0f;
					int num4 = -1;
					float num5 = 0f;
					int num6 = i + start.X;
					int num7 = j + start.Y;
					Vector2 vector = new Vector2((float)i, (float)j) / value * value2;
					float num8 = (new Vector2((float)i, (float)j) / value * 2f - Vector2.One).Length();
					for (int k = 0; k < clusters.Count; k++)
					{
						DesertBiome.Cluster cluster = clusters[k];
						if (Math.Abs(cluster[0].Position.X - vector.X) <= 10f && Math.Abs(cluster[0].Position.Y - vector.Y) <= 10f)
						{
							float num9 = 0f;
							foreach (DesertBiome.Hub current in cluster)
							{
								num9 += 1f / Vector2.DistanceSquared(current.Position, vector);
							}
							if (num9 > num3)
							{
								if (num3 > num5)
								{
									num5 = num3;
								}
								num3 = num9;
								num4 = k;
							}
							else if (num9 > num5)
							{
								num5 = num9;
							}
						}
					}
					float num10 = num3 + num5;
					Tile tile = GenBase._tiles[num6, num7];
					bool flag = num8 >= 0.8f;
					if (num10 > 3.5f)
					{
						tile.ClearEverything();
						tile.wall = 187;
						tile.liquid = 0;
						if (num4 % 15 == 2)
						{
							tile.ResetToType(404);
							tile.wall = 187;
							tile.active(true);
						}
						Tile.SmoothSlope(num6, num7, true);
					}
					else if (num10 > 1.8f)
					{
						tile.wall = 187;
						if (!flag || tile.active())
						{
							tile.ResetToType(396);
							tile.wall = 187;
							tile.active(true);
							Tile.SmoothSlope(num6, num7, true);
						}
						tile.liquid = 0;
					}
					else if (num10 > 0.7f || !flag)
					{
						if (!flag || tile.active())
						{
							tile.ResetToType(397);
							tile.active(true);
							Tile.SmoothSlope(num6, num7, true);
						}
						tile.liquid = 0;
						tile.wall = 216;
					}
					else if (num10 > 0.25f)
					{
						float num11 = (num10 - 0.25f) / 0.45f;
						if (GenBase._random.NextFloat() < num11)
						{
							if (tile.active())
							{
								tile.ResetToType(397);
								tile.active(true);
								Tile.SmoothSlope(num6, num7, true);
								tile.wall = 216;
							}
							tile.liquid = 0;
							tile.wall = 187;
						}
					}
				}
			}
		}

		// Token: 0x06000FCA RID: 4042 RVA: 0x003FAFDC File Offset: 0x003F91DC
		private void AddTileVariance(DesertBiome.ClusterGroup clusters, Point start, Vector2 scale)
		{
			int num = (int)(scale.X * (float)clusters.Width);
			int num2 = (int)(scale.Y * (float)clusters.Height);
			for (int i = -20; i < num + 20; i++)
			{
				for (int j = -20; j < num2 + 20; j++)
				{
					int num3 = i + start.X;
					int num4 = j + start.Y;
					Tile tile = GenBase._tiles[num3, num4];
					Tile testTile = GenBase._tiles[num3, num4 + 1];
					Tile testTile2 = GenBase._tiles[num3, num4 + 2];
					if (tile.type == 53 && (!WorldGen.SolidTile(testTile) || !WorldGen.SolidTile(testTile2)))
					{
						tile.type = 397;
					}
				}
			}
			for (int k = -20; k < num + 20; k++)
			{
				for (int l = -20; l < num2 + 20; l++)
				{
					int num5 = k + start.X;
					int num6 = l + start.Y;
					Tile tile2 = GenBase._tiles[num5, num6];
					if (tile2.active() && tile2.type == 396)
					{
						bool flag = true;
						for (int m = -1; m >= -3; m--)
						{
							if (GenBase._tiles[num5, num6 + m].active())
							{
								flag = false;
								break;
							}
						}
						bool flag2 = true;
						for (int n = 1; n <= 3; n++)
						{
							if (GenBase._tiles[num5, num6 + n].active())
							{
								flag2 = false;
								break;
							}
						}
						if ((flag ^ flag2) && GenBase._random.Next(5) == 0)
						{
							WorldGen.PlaceTile(num5, num6 + (flag ? -1 : 1), 165, true, true, -1, 0);
						}
						else if (flag && GenBase._random.Next(5) == 0)
						{
							WorldGen.PlaceTile(num5, num6 - 1, 187, true, true, -1, 29 + GenBase._random.Next(6));
						}
					}
				}
			}
		}

		// Token: 0x06000FCB RID: 4043 RVA: 0x003FB1E0 File Offset: 0x003F93E0
		private bool FindStart(Point origin, Vector2 scale, int xHubCount, int yHubCount, out Point start)
		{
			start = new Point(0, 0);
			int num = (int)(scale.X * (float)xHubCount);
			int height = (int)(scale.Y * (float)yHubCount);
			origin.X -= num >> 1;
			int num2 = 220;
			for (int i = -20; i < num + 20; i++)
			{
				int j = 220;
				while (j < Main.maxTilesY)
				{
					if (WorldGen.SolidTile(i + origin.X, j))
					{
						ushort type = GenBase._tiles[i + origin.X, j].type;
						if (type == 59 || type == 60)
						{
							return false;
						}
						if (j > num2)
						{
							num2 = j;
							break;
						}
						break;
					}
					else
					{
						j++;
					}
				}
			}
			WorldGen.UndergroundDesertLocation = new Rectangle(origin.X, num2, num, height);
			start = new Point(origin.X, num2);
			return true;
		}

		// Token: 0x06000FCC RID: 4044 RVA: 0x003FB2BC File Offset: 0x003F94BC
		public override bool Place(Point origin, StructureMap structures)
		{
			float num = (float)Main.maxTilesX / 4200f;
			int num2 = (int)(80f * num);
			int num3 = (int)((GenBase._random.NextFloat() + 1f) * 80f * num);
			Vector2 vector = new Vector2(4f, 2f);
			Point point;
			if (!this.FindStart(origin, vector, num2, num3, out point))
			{
				return false;
			}
			DesertBiome.ClusterGroup clusterGroup = new DesertBiome.ClusterGroup();
			clusterGroup.Generate(num2, num3);
			this.PlaceSand(clusterGroup, point, vector);
			this.PlaceClusters(clusterGroup, point, vector);
			this.AddTileVariance(clusterGroup, point, vector);
			int num4 = (int)(vector.X * (float)clusterGroup.Width);
			int num5 = (int)(vector.Y * (float)clusterGroup.Height);
			for (int i = -20; i < num4 + 20; i++)
			{
				for (int j = -20; j < num5 + 20; j++)
				{
					if (i + point.X > 0 && i + point.X < Main.maxTilesX - 1 && j + point.Y > 0 && j + point.Y < Main.maxTilesY - 1)
					{
						WorldGen.SquareWallFrame(i + point.X, j + point.Y, true);
						WorldUtils.TileFrame(i + point.X, j + point.Y, true);
					}
				}
			}
			return true;
		}

		// Token: 0x02000292 RID: 658
		private struct Hub
		{
			// Token: 0x060016CD RID: 5837 RVA: 0x00439338 File Offset: 0x00437538
			public Hub(Vector2 position)
			{
				this.Position = position;
			}

			// Token: 0x060016CE RID: 5838 RVA: 0x00439344 File Offset: 0x00437544
			public Hub(float x, float y)
			{
				this.Position = new Vector2(x, y);
			}

			// Token: 0x04003CAD RID: 15533
			public Vector2 Position;
		}

		// Token: 0x02000293 RID: 659
		private class Cluster : List<DesertBiome.Hub>
		{
		}

		// Token: 0x02000294 RID: 660
		private class ClusterGroup : List<DesertBiome.Cluster>
		{
			// Token: 0x060016D0 RID: 5840 RVA: 0x0043935C File Offset: 0x0043755C
			private void SearchForCluster(bool[,] hubMap, List<Point> pointCluster, int x, int y, int level = 2)
			{
				pointCluster.Add(new Point(x, y));
				hubMap[x, y] = false;
				level--;
				if (level == -1)
				{
					return;
				}
				if (x > 0 && hubMap[x - 1, y])
				{
					this.SearchForCluster(hubMap, pointCluster, x - 1, y, level);
				}
				if (x < hubMap.GetLength(0) - 1 && hubMap[x + 1, y])
				{
					this.SearchForCluster(hubMap, pointCluster, x + 1, y, level);
				}
				if (y > 0 && hubMap[x, y - 1])
				{
					this.SearchForCluster(hubMap, pointCluster, x, y - 1, level);
				}
				if (y < hubMap.GetLength(1) - 1 && hubMap[x, y + 1])
				{
					this.SearchForCluster(hubMap, pointCluster, x, y + 1, level);
				}
			}

			// Token: 0x060016D1 RID: 5841 RVA: 0x00439420 File Offset: 0x00437620
			private void AttemptClaim(int x, int y, int[,] clusterIndexMap, List<List<Point>> pointClusters, int index)
			{
				int num = clusterIndexMap[x, y];
				if (num != -1 && num != index)
				{
					int num2 = (WorldGen.genRand.Next(2) == 0) ? -1 : index;
					foreach (Point current in pointClusters[num])
					{
						clusterIndexMap[current.X, current.Y] = num2;
					}
				}
			}

			// Token: 0x060016D2 RID: 5842 RVA: 0x004394A8 File Offset: 0x004376A8
			public void Generate(int width, int height)
			{
				this.Width = width;
				this.Height = height;
				base.Clear();
				bool[,] array = new bool[width, height];
				int num = (width >> 1) - 1;
				int num2 = (height >> 1) - 1;
				int num3 = (num + 1) * (num + 1);
				Point point = new Point(num, num2);
				for (int i = point.Y - num2; i <= point.Y + num2; i++)
				{
					float num4 = (float)num / (float)num2 * (float)(i - point.Y);
					int num5 = Math.Min(num, (int)Math.Sqrt((double)((float)num3 - num4 * num4)));
					for (int j = point.X - num5; j <= point.X + num5; j++)
					{
						array[j, i] = (WorldGen.genRand.Next(2) == 0);
					}
				}
				List<List<Point>> list = new List<List<Point>>();
				for (int k = 0; k < array.GetLength(0); k++)
				{
					for (int l = 0; l < array.GetLength(1); l++)
					{
						if (array[k, l] && WorldGen.genRand.Next(2) == 0)
						{
							List<Point> list2 = new List<Point>();
							this.SearchForCluster(array, list2, k, l, 2);
							if (list2.Count > 2)
							{
								list.Add(list2);
							}
						}
					}
				}
				int[,] array2 = new int[array.GetLength(0), array.GetLength(1)];
				for (int m = 0; m < array2.GetLength(0); m++)
				{
					for (int n = 0; n < array2.GetLength(1); n++)
					{
						array2[m, n] = -1;
					}
				}
				for (int num6 = 0; num6 < list.Count; num6++)
				{
					foreach (Point current in list[num6])
					{
						array2[current.X, current.Y] = num6;
					}
				}
				for (int num7 = 0; num7 < list.Count; num7++)
				{
					foreach (Point expr_205 in list[num7])
					{
						int x = expr_205.X;
						int y = expr_205.Y;
						if (array2[x, y] == -1)
						{
							break;
						}
						int index = array2[x, y];
						if (x > 0)
						{
							this.AttemptClaim(x - 1, y, array2, list, index);
						}
						if (x < array2.GetLength(0) - 1)
						{
							this.AttemptClaim(x + 1, y, array2, list, index);
						}
						if (y > 0)
						{
							this.AttemptClaim(x, y - 1, array2, list, index);
						}
						if (y < array2.GetLength(1) - 1)
						{
							this.AttemptClaim(x, y + 1, array2, list, index);
						}
					}
				}
				using (List<List<Point>>.Enumerator enumerator2 = list.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						enumerator2.Current.Clear();
					}
				}
				for (int num8 = 0; num8 < array2.GetLength(0); num8++)
				{
					for (int num9 = 0; num9 < array2.GetLength(1); num9++)
					{
						if (array2[num8, num9] != -1)
						{
							list[array2[num8, num9]].Add(new Point(num8, num9));
						}
					}
				}
				foreach (List<Point> current2 in list)
				{
					if (current2.Count < 4)
					{
						current2.Clear();
					}
				}
				foreach (List<Point> current3 in list)
				{
					DesertBiome.Cluster cluster = new DesertBiome.Cluster();
					if (current3.Count > 0)
					{
						foreach (Point current4 in current3)
						{
							cluster.Add(new DesertBiome.Hub((float)current4.X + (WorldGen.genRand.NextFloat() - 0.5f) * 0.5f, (float)current4.Y + (WorldGen.genRand.NextFloat() - 0.5f) * 0.5f));
						}
						base.Add(cluster);
					}
				}
			}

			// Token: 0x04003CAE RID: 15534
			public int Width;

			// Token: 0x04003CAF RID: 15535
			public int Height;
		}
	}
}

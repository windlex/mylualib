using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace Terraria
{
	// Token: 0x02000038 RID: 56
	public class WorldSections
	{
		// Token: 0x0600085F RID: 2143 RVA: 0x003ABBC0 File Offset: 0x003A9DC0
		public WorldSections(int numSectionsX, int numSectionsY)
		{
			this.width = numSectionsX;
			this.height = numSectionsY;
			this.data = new BitsByte[this.width * this.height];
			this.mapSectionsLeft = this.width * this.height;
			this.prevFrame.Reset();
			this.prevMap.Reset();
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000860 RID: 2144 RVA: 0x003ABC24 File Offset: 0x003A9E24
		public int FrameSectionsLeft
		{
			get
			{
				return this.frameSectionsLeft;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000861 RID: 2145 RVA: 0x003ABC2C File Offset: 0x003A9E2C
		public int MapSectionsLeft
		{
			get
			{
				return this.mapSectionsLeft;
			}
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x003ABC34 File Offset: 0x003A9E34
		public bool SectionLoaded(int x, int y)
		{
			return x >= 0 && x < this.width && y >= 0 && y < this.height && this.data[y * this.width + x][0];
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x003ABC70 File Offset: 0x003A9E70
		public void SectionLoaded(int x, int y, bool value)
		{
			if (x < 0 || x >= this.width)
			{
				return;
			}
			if (y < 0 || y >= this.height)
			{
				return;
			}
			this.data[y * this.width + x][0] = value;
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x003ABCAC File Offset: 0x003A9EAC
		public bool SectionFramed(int x, int y)
		{
			return x >= 0 && x < this.width && y >= 0 && y < this.height && this.data[y * this.width + x][1];
		}

		// Token: 0x06000865 RID: 2149 RVA: 0x003ABCE8 File Offset: 0x003A9EE8
		public void SectionFramed(int x, int y, bool value)
		{
			if (x < 0 || x >= this.width)
			{
				return;
			}
			if (y < 0 || y >= this.height)
			{
				return;
			}
			if (this.data[y * this.width + x][1] != value)
			{
				if (value)
				{
					this.frameSectionsLeft++;
				}
				else
				{
					this.frameSectionsLeft--;
				}
			}
			this.data[y * this.width + x][1] = value;
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x003ABD6C File Offset: 0x003A9F6C
		public bool MapSectionDrawn(int x, int y)
		{
			return x >= 0 && x < this.width && y >= 0 && y < this.height && this.data[y * this.width + x][2];
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x003ABDA8 File Offset: 0x003A9FA8
		public void MapSectionDrawn(int x, int y, bool value)
		{
			if (x < 0 || x >= this.width)
			{
				return;
			}
			if (y < 0 || y >= this.height)
			{
				return;
			}
			if (this.data[y * this.width + x][1] != value)
			{
				if (value)
				{
					this.mapSectionsLeft++;
				}
				else
				{
					this.mapSectionsLeft--;
				}
			}
			this.data[y * this.width + x][2] = value;
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x003ABE2C File Offset: 0x003AA02C
		public void ClearMapDraw()
		{
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i][2] = false;
			}
			this.prevMap.Reset();
			this.mapSectionsLeft = this.data.Length;
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x003ABE78 File Offset: 0x003AA078
		public void SetSectionLoaded(int x, int y)
		{
			if (x < 0 || x >= this.width)
			{
				return;
			}
			if (y < 0 || y >= this.height)
			{
				return;
			}
			if (!this.data[y * this.width + x][0])
			{
				this.data[y * this.width + x][0] = true;
				this.frameSectionsLeft++;
			}
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x003ABEE8 File Offset: 0x003AA0E8
		public void SetSectionFramed(int x, int y)
		{
			if (x < 0 || x >= this.width)
			{
				return;
			}
			if (y < 0 || y >= this.height)
			{
				return;
			}
			if (!this.data[y * this.width + x][1])
			{
				this.data[y * this.width + x][1] = true;
				this.frameSectionsLeft--;
			}
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x003ABF58 File Offset: 0x003AA158
		public void SetAllFramesLoaded()
		{
			for (int i = 0; i < this.data.Length; i++)
			{
				if (!this.data[i][0])
				{
					this.data[i][0] = true;
					this.frameSectionsLeft++;
				}
			}
		}

		// Token: 0x0600086C RID: 2156 RVA: 0x003ABFB0 File Offset: 0x003AA1B0
		public bool GetNextMapDraw(Vector2 playerPos, out int x, out int y)
		{
			if (this.mapSectionsLeft <= 0)
			{
				x = -1;
				y = -1;
				return false;
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			int num = 0;
			int num2 = 0;
			Vector2 vector = this.prevMap.centerPos;
			playerPos *= 0.0625f;
			int sectionX = Netplay.GetSectionX((int)playerPos.X);
			int sectionY = Netplay.GetSectionY((int)playerPos.Y);
			int num3 = Netplay.GetSectionX((int)vector.X);
			int num4 = Netplay.GetSectionY((int)vector.Y);
			int num5;
			if (num3 != sectionX || num4 != sectionY)
			{
				vector = playerPos;
				num3 = sectionX;
				num4 = sectionY;
				num5 = 4;
				x = sectionX;
				y = sectionY;
			}
			else
			{
				num5 = this.prevMap.leg;
				x = this.prevMap.X;
				y = this.prevMap.Y;
				num = this.prevMap.xDir;
				num2 = this.prevMap.yDir;
			}
			int num6 = (int)(playerPos.X - ((float)num3 + 0.5f) * 200f);
			int num7 = (int)(playerPos.Y - ((float)num4 + 0.5f) * 150f);
			if (num == 0)
			{
				if (num6 > 0)
				{
					num = -1;
				}
				else
				{
					num = 1;
				}
				if (num7 > 0)
				{
					num2 = -1;
				}
				else
				{
					num2 = 1;
				}
			}
			int num8 = 0;
			bool flag = false;
			bool flag2 = false;
			while (true)
			{
				if (num8 == 4)
				{
					if (flag2)
					{
						break;
					}
					flag2 = true;
					x = num3;
					y = num4;
					num6 = (int)(vector.X - ((float)num3 + 0.5f) * 200f);
					num7 = (int)(vector.Y - ((float)num4 + 0.5f) * 150f);
					if (num6 > 0)
					{
						num = -1;
					}
					else
					{
						num = 1;
					}
					if (num7 > 0)
					{
						num2 = -1;
					}
					else
					{
						num2 = 1;
					}
					num5 = 4;
					num8 = 0;
				}
				if (y >= 0 && y < this.height && x >= 0 && x < this.width)
				{
					flag = false;
					if (!this.data[y * this.width + x][2])
					{
						goto Block_14;
					}
				}
				int num9 = x - num3;
				int num10 = y - num4;
				if (num9 == 0 || num10 == 0)
				{
					if (num5 == 4)
					{
						if (num9 == 0 && num10 == 0)
						{
							if (Math.Abs(num6) > Math.Abs(num7))
							{
								y -= num2;
							}
							else
							{
								x -= num;
							}
						}
						else
						{
							if (num9 != 0)
							{
								x += num9 / Math.Abs(num9);
							}
							if (num10 != 0)
							{
								y += num10 / Math.Abs(num10);
							}
						}
						num5 = 0;
						num8 = -2;
						flag = true;
					}
					else
					{
						if (num9 == 0)
						{
							if (num10 > 0)
							{
								num2 = -1;
							}
							else
							{
								num2 = 1;
							}
						}
						else if (num9 > 0)
						{
							num = -1;
						}
						else
						{
							num = 1;
						}
						x += num;
						y += num2;
						num5++;
					}
					if (flag)
					{
						num8++;
					}
					else
					{
						flag = true;
					}
				}
				else
				{
					x += num;
					y += num2;
				}
			}
			throw new Exception("Infinite loop in WorldSections.GetNextMapDraw");
			Block_14:
			this.data[y * this.width + x][2] = true;
			this.mapSectionsLeft--;
			this.prevMap.centerPos = playerPos;
			this.prevMap.X = x;
			this.prevMap.Y = y;
			this.prevMap.leg = num5;
			this.prevMap.xDir = num;
			this.prevMap.yDir = num2;
			stopwatch.Stop();
			return true;
		}

		// Token: 0x0600086D RID: 2157 RVA: 0x003AC2F4 File Offset: 0x003AA4F4
		public bool GetNextTileFrame(Vector2 playerPos, out int x, out int y)
		{
			if (this.frameSectionsLeft <= 0)
			{
				x = -1;
				y = -1;
				return false;
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			int num = 0;
			int num2 = 0;
			Vector2 vector = this.prevFrame.centerPos;
			playerPos *= 0.0625f;
			int sectionX = Netplay.GetSectionX((int)playerPos.X);
			int sectionY = Netplay.GetSectionY((int)playerPos.Y);
			int num3 = Netplay.GetSectionX((int)vector.X);
			int num4 = Netplay.GetSectionY((int)vector.Y);
			int num5;
			if (num3 != sectionX || num4 != sectionY)
			{
				vector = playerPos;
				num3 = sectionX;
				num4 = sectionY;
				num5 = 4;
				x = sectionX;
				y = sectionY;
			}
			else
			{
				num5 = this.prevFrame.leg;
				x = this.prevFrame.X;
				y = this.prevFrame.Y;
				num = this.prevFrame.xDir;
				num2 = this.prevFrame.yDir;
			}
			int num6 = (int)(playerPos.X - ((float)num3 + 0.5f) * 200f);
			int num7 = (int)(playerPos.Y - ((float)num4 + 0.5f) * 150f);
			if (num == 0)
			{
				if (num6 > 0)
				{
					num = -1;
				}
				else
				{
					num = 1;
				}
				if (num7 > 0)
				{
					num2 = -1;
				}
				else
				{
					num2 = 1;
				}
			}
			int num8 = 0;
			bool flag = false;
			bool flag2 = false;
			while (true)
			{
				if (num8 == 4)
				{
					if (flag2)
					{
						break;
					}
					flag2 = true;
					x = num3;
					y = num4;
					num6 = (int)(vector.X - ((float)num3 + 0.5f) * 200f);
					num7 = (int)(vector.Y - ((float)num4 + 0.5f) * 150f);
					if (num6 > 0)
					{
						num = -1;
					}
					else
					{
						num = 1;
					}
					if (num7 > 0)
					{
						num2 = -1;
					}
					else
					{
						num2 = 1;
					}
					num5 = 4;
					num8 = 0;
				}
				if (y >= 0 && y < this.height && x >= 0 && x < this.width)
				{
					flag = false;
					if (this.data[y * this.width + x][0] && !this.data[y * this.width + x][1])
					{
						goto Block_15;
					}
				}
				int num9 = x - num3;
				int num10 = y - num4;
				if (num9 == 0 || num10 == 0)
				{
					if (num5 == 4)
					{
						if (num9 == 0 && num10 == 0)
						{
							if (Math.Abs(num6) > Math.Abs(num7))
							{
								y -= num2;
							}
							else
							{
								x -= num;
							}
						}
						else
						{
							if (num9 != 0)
							{
								x += num9 / Math.Abs(num9);
							}
							if (num10 != 0)
							{
								y += num10 / Math.Abs(num10);
							}
						}
						num5 = 0;
						num8 = 0;
						flag = true;
					}
					else
					{
						if (num9 == 0)
						{
							if (num10 > 0)
							{
								num2 = -1;
							}
							else
							{
								num2 = 1;
							}
						}
						else if (num9 > 0)
						{
							num = -1;
						}
						else
						{
							num = 1;
						}
						x += num;
						y += num2;
						num5++;
					}
					if (flag)
					{
						num8++;
					}
					else
					{
						flag = true;
					}
				}
				else
				{
					x += num;
					y += num2;
				}
			}
			throw new Exception("Infinite loop in WorldSections.GetNextTileFrame");
			Block_15:
			this.data[y * this.width + x][1] = true;
			this.frameSectionsLeft--;
			this.prevFrame.centerPos = playerPos;
			this.prevFrame.X = x;
			this.prevFrame.Y = y;
			this.prevFrame.leg = num5;
			this.prevFrame.xDir = num;
			this.prevFrame.yDir = num2;
			stopwatch.Stop();
			return true;
		}

		// Token: 0x04000D07 RID: 3335
		private int width;

		// Token: 0x04000D08 RID: 3336
		private int height;

		// Token: 0x04000D09 RID: 3337
		private BitsByte[] data;

		// Token: 0x04000D0A RID: 3338
		private int mapSectionsLeft;

		// Token: 0x04000D0B RID: 3339
		private int frameSectionsLeft;

		// Token: 0x04000D0C RID: 3340
		private WorldSections.IterationState prevFrame;

		// Token: 0x04000D0D RID: 3341
		private WorldSections.IterationState prevMap;

		// Token: 0x020001DE RID: 478
		private struct IterationState
		{
			// Token: 0x060014CF RID: 5327 RVA: 0x0042E7B0 File Offset: 0x0042C9B0
			public void Reset()
			{
				this.centerPos = new Vector2(-3200f, -2400f);
				this.X = 0;
				this.Y = 0;
				this.leg = 0;
				this.xDir = 0;
				this.yDir = 0;
			}

			// Token: 0x04003727 RID: 14119
			public Vector2 centerPos;

			// Token: 0x04003728 RID: 14120
			public int X;

			// Token: 0x04003729 RID: 14121
			public int Y;

			// Token: 0x0400372A RID: 14122
			public int leg;

			// Token: 0x0400372B RID: 14123
			public int xDir;

			// Token: 0x0400372C RID: 14124
			public int yDir;
		}
	}
}

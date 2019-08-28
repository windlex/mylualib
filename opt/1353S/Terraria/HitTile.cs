using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Utilities;

namespace Terraria
{
	// Token: 0x02000010 RID: 16
	public class HitTile
	{
		// Token: 0x06000089 RID: 137 RVA: 0x0000B720 File Offset: 0x00009920
		public HitTile()
		{
			HitTile.rand = new UnifiedRandom();
			this.data = new HitTile.HitTileObject[21];
			this.order = new int[21];
			for (int i = 0; i <= 20; i++)
			{
				this.data[i] = new HitTile.HitTileObject();
				this.order[i] = i;
			}
			this.bufferLocation = 0;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000B824 File Offset: 0x00009A24
		public int AddDamage(int tileId, int damageAmount, bool updateAmount = true)
		{
			if (tileId < 0 || tileId > 20)
			{
				return 0;
			}
			if (tileId == this.bufferLocation && damageAmount == 0)
			{
				return 0;
			}
			HitTile.HitTileObject hitTileObject = this.data[tileId];
			if (!updateAmount)
			{
				return hitTileObject.damage + damageAmount;
			}
			hitTileObject.damage += damageAmount;
			hitTileObject.timeToLive = 60;
			hitTileObject.animationTimeElapsed = 0;
			hitTileObject.animationDirection = (Main.rand.NextFloat() * 6.28318548f).ToRotationVector2() * 2f;
			if (tileId != this.bufferLocation)
			{
				for (int i = 0; i <= 20; i++)
				{
					if (this.order[i] == tileId)
					{
						IL_10D:
						while (i > 1)
						{
							int num = this.order[i - 1];
							this.order[i - 1] = this.order[i];
							this.order[i] = num;
							i--;
						}
						this.order[1] = tileId;
						goto IL_11A;
					}
				}
			}
			this.bufferLocation = this.order[20];
			this.data[this.bufferLocation].Clear();
			for (int i = 20; i > 0; i--)
			{
				this.order[i] = this.order[i - 1];
			}
			this.order[0] = this.bufferLocation;
			IL_11A:
			return hitTileObject.damage;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000B954 File Offset: 0x00009B54
		public void Clear(int tileId)
		{
			if (tileId < 0 || tileId > 20)
			{
				return;
			}
			this.data[tileId].Clear();
			for (int i = 0; i < 20; i++)
			{
				if (this.order[i] == tileId)
				{
					while (i < 20)
					{
						this.order[i] = this.order[i + 1];
						i++;
					}
					this.order[20] = tileId;
					return;
				}
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000BB70 File Offset: 0x00009D70
		public void DrawFreshAnimations(SpriteBatch spriteBatch)
		{
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i].animationTimeElapsed++;
			}
			if (!Main.SettingsEnabled_MinersWobble)
			{
				return;
			}
			int num = 1;
			Vector2 zero = new Vector2((float)Main.offScreenRange);
			if (Main.drawToScreen)
			{
				zero = Vector2.Zero;
			}
			zero = Vector2.Zero;
			for (int j = 0; j < this.data.Length; j++)
			{
				if (this.data[j].type == num)
				{
					int damage = this.data[j].damage;
					if (damage >= 20)
					{
						int x = this.data[j].X;
						int y = this.data[j].Y;
						if (WorldGen.InWorld(x, y, 0))
						{
							bool flag = Main.tile[x, y] != null;
							if (flag && num == 1)
							{
								flag = (flag && Main.tile[x, y].active() && Main.tileSolid[(int)Main.tile[x, y].type]);
							}
							if (flag && num == 2)
							{
								flag = (flag && Main.tile[x, y].wall > 0);
							}
							if (flag)
							{
								bool flag2 = false;
								bool flag3 = false;
								if (Main.tile[x, y].type == 10)
								{
									flag2 = false;
								}
								else if (Main.tileSolid[(int)Main.tile[x, y].type] && !Main.tileSolidTop[(int)Main.tile[x, y].type])
								{
									flag2 = true;
								}
								else if (Main.tile[x, y].type == 5)
								{
									flag3 = true;
									int num2 = (int)(Main.tile[x, y].frameX / 22);
									int num3 = (int)(Main.tile[x, y].frameY / 22);
									if (num3 < 9)
									{
										flag2 = (((num2 != 1 && num2 != 2) || num3 < 6 || num3 > 8) && (num2 != 3 || num3 > 2) && (num2 != 4 || num3 < 3 || num3 > 5) && (num2 != 5 || num3 < 6 || num3 > 8));
									}
								}
								else if (Main.tile[x, y].type == 72)
								{
									flag3 = true;
									if (Main.tile[x, y].frameX <= 34)
									{
										flag2 = true;
									}
								}
								if (flag2 && Main.tile[x, y].slope() == 0 && !Main.tile[x, y].halfBrick())
								{
									int num4 = 0;
									if (damage >= 80)
									{
										num4 = 3;
									}
									else if (damage >= 60)
									{
										num4 = 2;
									}
									else if (damage >= 40)
									{
										num4 = 1;
									}
									else if (damage >= 20)
									{
										num4 = 0;
									}
									Rectangle value = new Rectangle(this.data[j].crackStyle * 18, num4 * 18, 16, 16);
									value.Inflate(-2, -2);
									if (flag3)
									{
										value.X = (4 + this.data[j].crackStyle / 2) * 18;
									}
									int animationTimeElapsed = this.data[j].animationTimeElapsed;
									if ((float)animationTimeElapsed < 10f)
									{
										float arg_365_0 = (float)animationTimeElapsed / 10f;
										Color color = Lighting.GetColor(x, y);
										float rotation = 0f;
										Vector2 zero2 = Vector2.Zero;
										float num5 = 0.5f;
										float num6 = arg_365_0 % num5;
										num6 *= 1f / num5;
										if ((int)(arg_365_0 / num5) % 2 == 1)
										{
											num6 = 1f - num6;
										}
										Tile tileSafely = Framing.GetTileSafely(x, y);
										Tile tile = tileSafely;
										Texture2D texture;
										if (Main.canDrawColorTile(tileSafely.type, (int)tileSafely.color()))
										{
											texture = Main.tileAltTexture[(int)tileSafely.type, (int)tileSafely.color()];
										}
										else
										{
											texture = Main.tileTexture[(int)tileSafely.type];
										}
										Vector2 vector = new Vector2(8f);
										Vector2 value2 = new Vector2(1f);
										float arg_427_0 = num6 * 0.2f + 1f;
										float num7 = 1f - num6;
										num7 = 1f;
										color *= num7 * num7 * 0.8f;
										Vector2 scale = arg_427_0 * value2;
										Vector2 position = (new Vector2((float)(x * 16 - (int)Main.screenPosition.X), (float)(y * 16 - (int)Main.screenPosition.Y)) + zero + vector + zero2).Floor();
										spriteBatch.Draw(texture, position, new Rectangle?(new Rectangle((int)tile.frameX, (int)tile.frameY, 16, 16)), color, rotation, vector, scale, SpriteEffects.None, 0f);
										color.A = 180;
										spriteBatch.Draw(Main.tileCrackTexture, position, new Rectangle?(value), color, rotation, vector, scale, SpriteEffects.None, 0f);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000B784 File Offset: 0x00009984
		public int HitObject(int x, int y, int hitType)
		{
			HitTile.HitTileObject hitTileObject;
			for (int i = 0; i <= 20; i++)
			{
				int num = this.order[i];
				hitTileObject = this.data[num];
				if (hitTileObject.type == hitType)
				{
					if (hitTileObject.X == x && hitTileObject.Y == y)
					{
						return num;
					}
				}
				else if (i != 0 && hitTileObject.type == 0)
				{
					break;
				}
			}
			hitTileObject = this.data[this.bufferLocation];
			hitTileObject.X = x;
			hitTileObject.Y = y;
			hitTileObject.type = hitType;
			return this.bufferLocation;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000B9B8 File Offset: 0x00009BB8
		public void Prune()
		{
			bool flag = false;
			for (int i = 0; i <= 20; i++)
			{
				HitTile.HitTileObject hitTileObject = this.data[i];
				if (hitTileObject.type != 0)
				{
					Tile tile = Main.tile[hitTileObject.X, hitTileObject.Y];
					if (hitTileObject.timeToLive <= 1)
					{
						hitTileObject.Clear();
						flag = true;
					}
					else
					{
						hitTileObject.timeToLive--;
						if ((double)hitTileObject.timeToLive < 12.0)
						{
							hitTileObject.damage -= 10;
						}
						else if ((double)hitTileObject.timeToLive < 24.0)
						{
							hitTileObject.damage -= 7;
						}
						else if ((double)hitTileObject.timeToLive < 36.0)
						{
							hitTileObject.damage -= 5;
						}
						else if ((double)hitTileObject.timeToLive < 48.0)
						{
							hitTileObject.damage -= 2;
						}
						if (hitTileObject.damage < 0)
						{
							hitTileObject.Clear();
							flag = true;
						}
						else if (hitTileObject.type == 1)
						{
							if (!tile.active())
							{
								hitTileObject.Clear();
								flag = true;
							}
						}
						else if (tile.wall == 0)
						{
							hitTileObject.Clear();
							flag = true;
						}
					}
				}
			}
			if (!flag)
			{
				return;
			}
			int num = 1;
			while (flag)
			{
				flag = false;
				for (int j = num; j < 20; j++)
				{
					if (this.data[this.order[j]].type == 0 && this.data[this.order[j + 1]].type != 0)
					{
						int num2 = this.order[j];
						this.order[j] = this.order[j + 1];
						this.order[j + 1] = num2;
						flag = true;
					}
				}
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000B801 File Offset: 0x00009A01
		public void UpdatePosition(int tileId, int x, int y)
		{
			if (tileId < 0 || tileId > 20)
			{
				return;
			}
			HitTile.HitTileObject expr_12 = this.data[tileId];
			expr_12.X = x;
			expr_12.Y = y;
		}

		// Token: 0x0400007F RID: 127
		private int bufferLocation;

		// Token: 0x0400007D RID: 125
		public HitTile.HitTileObject[] data;

		// Token: 0x0400007C RID: 124
		private static int lastCrack = -1;

		// Token: 0x04000079 RID: 121
		internal const int MAX_HITTILES = 20;

		// Token: 0x0400007E RID: 126
		private int[] order;

		// Token: 0x0400007B RID: 123
		private static UnifiedRandom rand;

		// Token: 0x04000077 RID: 119
		internal const int TILE = 1;

		// Token: 0x0400007A RID: 122
		internal const int TIMETOLIVE = 60;

		// Token: 0x04000076 RID: 118
		internal const int UNUSED = 0;

		// Token: 0x04000078 RID: 120
		internal const int WALL = 2;

		// Token: 0x020001B8 RID: 440
		public class HitTileObject
		{
			// Token: 0x060013EA RID: 5098 RVA: 0x0041B974 File Offset: 0x00419B74
			public HitTileObject()
			{
				this.Clear();
			}

			// Token: 0x060013EB RID: 5099 RVA: 0x0041B984 File Offset: 0x00419B84
			public void Clear()
			{
				this.X = 0;
				this.Y = 0;
				this.damage = 0;
				this.type = 0;
				this.timeToLive = 0;
				if (HitTile.rand == null)
				{
					HitTile.rand = new UnifiedRandom((int)DateTime.Now.Ticks);
				}
				this.crackStyle = HitTile.rand.Next(4);
				while (this.crackStyle == HitTile.lastCrack)
				{
					this.crackStyle = HitTile.rand.Next(4);
				}
				HitTile.lastCrack = this.crackStyle;
			}

			// Token: 0x04003619 RID: 13849
			public Vector2 animationDirection;

			// Token: 0x04003618 RID: 13848
			public int animationTimeElapsed;

			// Token: 0x04003617 RID: 13847
			public int crackStyle;

			// Token: 0x04003614 RID: 13844
			public int damage;

			// Token: 0x04003616 RID: 13846
			public int timeToLive;

			// Token: 0x04003615 RID: 13845
			public int type;

			// Token: 0x04003612 RID: 13842
			public int X;

			// Token: 0x04003613 RID: 13843
			public int Y;
		}
	}
}

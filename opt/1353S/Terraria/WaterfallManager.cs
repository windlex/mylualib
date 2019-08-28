using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria
{
	// Token: 0x02000035 RID: 53
	public class WaterfallManager
	{
		// Token: 0x060006DC RID: 1756 RVA: 0x0034703B File Offset: 0x0034523B
		public WaterfallManager()
		{
			this.waterfalls = new WaterfallManager.WaterfallData[200];
		}

		// Token: 0x060006DE RID: 1758 RVA: 0x003470C8 File Offset: 0x003452C8
		public bool CheckForWaterfall(int i, int j)
		{
			for (int k = 0; k < this.currentMax; k++)
			{
				if (this.waterfalls[k].x == i && this.waterfalls[k].y == j)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x00349028 File Offset: 0x00347228
		public void Draw(SpriteBatch spriteBatch)
		{
			for (int i = 0; i < this.currentMax; i++)
			{
				this.waterfalls[i].stopAtStep = this.waterfallDist;
			}
			Main.drewLava = false;
			if (Main.liquidAlpha[0] > 0f)
			{
				this.DrawWaterfall(spriteBatch, 0, Main.liquidAlpha[0]);
			}
			if (Main.liquidAlpha[2] > 0f)
			{
				this.DrawWaterfall(spriteBatch, 3, Main.liquidAlpha[2]);
			}
			if (Main.liquidAlpha[3] > 0f)
			{
				this.DrawWaterfall(spriteBatch, 4, Main.liquidAlpha[3]);
			}
			if (Main.liquidAlpha[4] > 0f)
			{
				this.DrawWaterfall(spriteBatch, 5, Main.liquidAlpha[4]);
			}
			if (Main.liquidAlpha[5] > 0f)
			{
				this.DrawWaterfall(spriteBatch, 6, Main.liquidAlpha[5]);
			}
			if (Main.liquidAlpha[6] > 0f)
			{
				this.DrawWaterfall(spriteBatch, 7, Main.liquidAlpha[6]);
			}
			if (Main.liquidAlpha[7] > 0f)
			{
				this.DrawWaterfall(spriteBatch, 8, Main.liquidAlpha[7]);
			}
			if (Main.liquidAlpha[8] > 0f)
			{
				this.DrawWaterfall(spriteBatch, 9, Main.liquidAlpha[8]);
			}
			if (Main.liquidAlpha[9] > 0f)
			{
				this.DrawWaterfall(spriteBatch, 10, Main.liquidAlpha[9]);
			}
			if (Main.liquidAlpha[10] > 0f)
			{
				this.DrawWaterfall(spriteBatch, 13, Main.liquidAlpha[10]);
			}
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x00347714 File Offset: 0x00345914
		private void DrawWaterfall(SpriteBatch spriteBatch, int Style = 0, float Alpha = 1f)
		{
			float num = 0f;
			float num2 = 99999f;
			float num3 = 99999f;
			int num4 = -1;
			int num5 = -1;
			float num6 = 0f;
			float num7 = 99999f;
			float num8 = 99999f;
			int num9 = -1;
			int num10 = -1;
			int i = 0;
			while (i < this.currentMax)
			{
				int num11 = 0;
				int num12 = this.waterfalls[i].type;
				int num13 = this.waterfalls[i].x;
				int num14 = this.waterfalls[i].y;
				int num15 = 0;
				int num16 = 0;
				int num17 = 0;
				int num18 = 0;
				int num19 = 0;
				int num20 = 0;
				int num21 = 0;
				int num22;
				if (num12 == 1 || num12 == 14)
				{
					if (!Main.drewLava && this.waterfalls[i].stopAtStep != 0)
					{
						num21 = 32 * this.slowFrame;
						goto IL_459;
					}
				}
				else
				{
					if (num12 != 11 && num12 != 22)
					{
						if (num12 == 0)
						{
							num12 = Style;
						}
						else if (num12 == 2 && Main.drewLava)
						{
							goto IL_18C8;
						}
						num21 = 32 * this.regularFrame;
						goto IL_459;
					}
					if (!Main.drewLava)
					{
						num22 = this.waterfallDist / 4;
						if (num12 == 22)
						{
							num22 = this.waterfallDist / 2;
						}
						if (this.waterfalls[i].stopAtStep > num22)
						{
							this.waterfalls[i].stopAtStep = num22;
						}
						if (this.waterfalls[i].stopAtStep != 0 && (float)(num14 + num22) >= Main.screenPosition.Y / 16f && (float)num13 >= Main.screenPosition.X / 16f - 1f && (float)num13 <= (Main.screenPosition.X + (float)Main.screenWidth) / 16f + 1f)
						{
							int num23;
							int num24;
							if (num13 % 2 == 0)
							{
								num23 = this.rainFrameForeground + 3;
								if (num23 > 7)
								{
									num23 -= 8;
								}
								num24 = this.rainFrameBackground + 2;
								if (num24 > 7)
								{
									num24 -= 8;
								}
								if (num12 == 22)
								{
									num23 = this.snowFrameForeground + 3;
									if (num23 > 7)
									{
										num23 -= 8;
									}
								}
							}
							else
							{
								num23 = this.rainFrameForeground;
								num24 = this.rainFrameBackground;
								if (num12 == 22)
								{
									num23 = this.snowFrameForeground;
								}
							}
							Rectangle value = new Rectangle(num24 * 18, 0, 16, 16);
							Rectangle value2 = new Rectangle(num23 * 18, 0, 16, 16);
							Vector2 origin = new Vector2(8f, 8f);
							Vector2 position;
							if (num14 % 2 == 0)
							{
								position = new Vector2((float)(num13 * 16 + 9), (float)(num14 * 16 + 8)) - Main.screenPosition;
							}
							else
							{
								position = new Vector2((float)(num13 * 16 + 8), (float)(num14 * 16 + 8)) - Main.screenPosition;
							}
							bool flag = false;
							for (int j = 0; j < num22; j++)
							{
								Color arg_2C8_0 = Lighting.GetColor(num13, num14);
								float num25 = 0.6f;
								float num26 = 0.3f;
								if (j > num22 - 8)
								{
									float num27 = (float)(num22 - j) / 8f;
									num25 *= num27;
									num26 *= num27;
								}
								Color color = arg_2C8_0 * num25;
								Color color2 = arg_2C8_0 * num26;
								if (num12 == 22)
								{
									spriteBatch.Draw(this.waterfallTexture[22], position, new Rectangle?(value2), color, 0f, origin, 1f, SpriteEffects.None, 0f);
								}
								else
								{
									spriteBatch.Draw(this.waterfallTexture[12], position, new Rectangle?(value), color2, 0f, origin, 1f, SpriteEffects.None, 0f);
									spriteBatch.Draw(this.waterfallTexture[11], position, new Rectangle?(value2), color, 0f, origin, 1f, SpriteEffects.None, 0f);
								}
								if (flag)
								{
									break;
								}
								num14++;
								Tile tile = Main.tile[num13, num14];
								if (WorldGen.SolidTile(tile))
								{
									flag = true;
								}
								if (tile.liquid > 0)
								{
									int num28 = (int)(16f * ((float)tile.liquid / 255f)) & 254;
									if (num28 >= 15)
									{
										break;
									}
									value2.Height -= num28;
									value.Height -= num28;
								}
								if (num14 % 2 == 0)
								{
									position.X += 1f;
								}
								else
								{
									position.X -= 1f;
								}
								position.Y += 16f;
							}
							this.waterfalls[i].stopAtStep = 0;
						}
					}
				}
				IL_18C8:
				i++;
				continue;
				IL_459:
				int num29 = 0;
				num22 = this.waterfallDist;
				Color color3 = Color.White;
				for (int k = 0; k < num22; k++)
				{
					if (num29 < 2)
					{
						if (num12 != 1)
						{
							if (num12 != 2)
							{
								switch (num12)
								{
									case 15:
										{
											float num30 = 0f;
											float num31 = 0f;
											float num32 = 0.2f;
											Lighting.AddLight(num13, num14, num30, num31, num32);
											break;
										}
									case 16:
										{
											float num30 = 0f;
											float num31 = 0.2f;
											float num32 = 0f;
											Lighting.AddLight(num13, num14, num30, num31, num32);
											break;
										}
									case 17:
										{
											float num30 = 0f;
											float num31 = 0f;
											float num32 = 0.2f;
											Lighting.AddLight(num13, num14, num30, num31, num32);
											break;
										}
									case 18:
										{
											float num30 = 0f;
											float num31 = 0.2f;
											float num32 = 0f;
											Lighting.AddLight(num13, num14, num30, num31, num32);
											break;
										}
									case 19:
										{
											float num30 = 0.2f;
											float num31 = 0f;
											float num32 = 0f;
											Lighting.AddLight(num13, num14, num30, num31, num32);
											break;
										}
									case 20:
										Lighting.AddLight(num13, num14, 0.2f, 0.2f, 0.2f);
										break;
									case 21:
										{
											float num30 = 0.2f;
											float num31 = 0f;
											float num32 = 0f;
											Lighting.AddLight(num13, num14, num30, num31, num32);
											break;
										}
								}
							}
							else
							{
								float num30 = (float)Main.DiscoR / 255f;
								float num31 = (float)Main.DiscoG / 255f;
								float num32 = (float)Main.DiscoB / 255f;
								num30 *= 0.2f;
								num31 *= 0.2f;
								num32 *= 0.2f;
								Lighting.AddLight(num13, num14, num30, num31, num32);
							}
						}
						else
						{
							float num30;
							float expr_4CE = num30 = (0.55f + (float)(270 - (int)Main.mouseTextColor) / 900f) * 0.4f;
							float num31 = expr_4CE * 0.3f;
							float num32 = expr_4CE * 0.1f;
							Lighting.AddLight(num13, num14, num30, num31, num32);
						}
						Tile tile2 = Main.tile[num13, num14];
						if (tile2 == null)
						{
							tile2 = new Tile();
							Main.tile[num13, num14] = tile2;
						}
						Tile tile3 = Main.tile[num13 - 1, num14];
						if (tile3 == null)
						{
							tile3 = new Tile();
							Main.tile[num13 - 1, num14] = tile3;
						}
						Tile tile4 = Main.tile[num13, num14 + 1];
						if (tile4 == null)
						{
							tile4 = new Tile();
							Main.tile[num13, num14 + 1] = tile4;
						}
						Tile tile5 = Main.tile[num13 + 1, num14];
						if (tile5 == null)
						{
							tile5 = new Tile();
							Main.tile[num13 + 1, num14] = tile5;
						}
						int num33 = (int)(tile2.liquid / 16);
						int num34 = 0;
						int num35 = num18;
						int num36;
						int num37;
						if (tile4.topSlope())
						{
							if (tile4.slope() == 1)
							{
								num34 = 1;
								num36 = 1;
								num17 = 1;
								num18 = num17;
							}
							else
							{
								num34 = -1;
								num36 = -1;
								num17 = -1;
								num18 = num17;
							}
							num37 = 1;
						}
						else if ((((!WorldGen.SolidTile(tile4) && !tile4.bottomSlope()) || tile4.type == 162) && !tile2.halfBrick()) || (!tile4.active() && !tile2.halfBrick()))
						{
							num29 = 0;
							num37 = 1;
							num36 = 0;
						}
						else if ((WorldGen.SolidTile(tile3) || tile3.topSlope() || tile3.liquid > 0) && !WorldGen.SolidTile(tile5) && tile5.liquid == 0)
						{
							if (num17 == -1)
							{
								num29++;
							}
							num36 = 1;
							num37 = 0;
							num17 = 1;
						}
						else if ((WorldGen.SolidTile(tile5) || tile5.topSlope() || tile5.liquid > 0) && !WorldGen.SolidTile(tile3) && tile3.liquid == 0)
						{
							if (num17 == 1)
							{
								num29++;
							}
							num36 = -1;
							num37 = 0;
							num17 = -1;
						}
						else if (((!WorldGen.SolidTile(tile5) && !tile2.topSlope()) || tile5.liquid == 0) && !WorldGen.SolidTile(tile3) && !tile2.topSlope() && tile3.liquid == 0)
						{
							num37 = 0;
							num36 = num17;
						}
						else
						{
							num29++;
							num37 = 0;
							num36 = 0;
						}
						if (num29 >= 2)
						{
							num17 *= -1;
							num36 *= -1;
						}
						int num38 = -1;
						if (num12 != 1 && num12 != 14)
						{
							if (tile4.active())
							{
								num38 = (int)tile4.type;
							}
							if (tile2.active())
							{
								num38 = (int)tile2.type;
							}
						}
						if (num38 != -1)
						{
							if (num38 == 160)
							{
								num12 = 2;
							}
							else if (num38 >= 262 && num38 <= 268)
							{
								num12 = 15 + num38 - 262;
							}
						}
						if (WorldGen.SolidTile(tile4) && !tile2.halfBrick())
						{
							num11 = 8;
						}
						else if (num16 != 0)
						{
							num11 = 0;
						}
						Color color4 = Lighting.GetColor(num13, num14);
						Color color5 = color4;
						float num39;
						if (num12 == 1)
						{
							num39 = 1f;
						}
						else if (num12 == 14)
						{
							num39 = 0.8f;
						}
						else if (tile2.wall == 0 && (double)num14 < Main.worldSurface)
						{
							num39 = Alpha;
						}
						else
						{
							num39 = 0.6f * Alpha;
						}
						if (k > num22 - 10)
						{
							num39 *= (float)(num22 - k) / 10f;
						}
						float num40 = (float)color4.R * num39;
						float num41 = (float)color4.G * num39;
						float num42 = (float)color4.B * num39;
						float num43 = (float)color4.A * num39;
						if (num12 == 1)
						{
							if (num40 < 190f * num39)
							{
								num40 = 190f * num39;
							}
							if (num41 < 190f * num39)
							{
								num41 = 190f * num39;
							}
							if (num42 < 190f * num39)
							{
								num42 = 190f * num39;
							}
						}
						else if (num12 == 2)
						{
							num40 = (float)Main.DiscoR * num39;
							num41 = (float)Main.DiscoG * num39;
							num42 = (float)Main.DiscoB * num39;
						}
						else if (num12 >= 15 && num12 <= 21)
						{
							num40 = 255f * num39;
							num41 = 255f * num39;
							num42 = 255f * num39;
						}
						color4 = new Color((int)num40, (int)num41, (int)num42, (int)num43);
						if (num12 == 1)
						{
							float num44 = Math.Abs((float)(num13 * 16 + 8) - (Main.screenPosition.X + (float)(Main.screenWidth / 2)));
							float num45 = Math.Abs((float)(num14 * 16 + 8) - (Main.screenPosition.Y + (float)(Main.screenHeight / 2)));
							if (num44 < (float)(Main.screenWidth * 2) && num45 < (float)(Main.screenHeight * 2))
							{
								float num46 = (float)Math.Sqrt((double)(num44 * num44 + num45 * num45));
								float num47 = 1f - num46 / ((float)Main.screenWidth * 0.75f);
								if (num47 > 0f)
								{
									num6 += num47;
								}
							}
							if (num44 < num7)
							{
								num7 = num44;
								num9 = num13 * 16 + 8;
							}
							if (num45 < num8)
							{
								num8 = num44;
								num10 = num14 * 16 + 8;
							}
						}
						else if (num12 != 1 && num12 != 14 && num12 != 11 && num12 != 12 && num12 != 22)
						{
							float num48 = Math.Abs((float)(num13 * 16 + 8) - (Main.screenPosition.X + (float)(Main.screenWidth / 2)));
							float num49 = Math.Abs((float)(num14 * 16 + 8) - (Main.screenPosition.Y + (float)(Main.screenHeight / 2)));
							if (num48 < (float)(Main.screenWidth * 2) && num49 < (float)(Main.screenHeight * 2))
							{
								float num50 = (float)Math.Sqrt((double)(num48 * num48 + num49 * num49));
								float num51 = 1f - num50 / ((float)Main.screenWidth * 0.75f);
								if (num51 > 0f)
								{
									num += num51;
								}
							}
							if (num48 < num2)
							{
								num2 = num48;
								num4 = num13 * 16 + 8;
							}
							if (num49 < num3)
							{
								num3 = num48;
								num5 = num14 * 16 + 8;
							}
						}
						if (k > 50 && (color5.R > 20 || color5.B > 20 || color5.G > 20))
						{
							float num52 = (float)color5.R;
							if ((float)color5.G > num52)
							{
								num52 = (float)color5.G;
							}
							if ((float)color5.B > num52)
							{
								num52 = (float)color5.B;
							}
							if ((float)Main.rand.Next(20000) < num52 / 30f)
							{
								int num53 = Dust.NewDust(new Vector2((float)(num13 * 16 - num17 * 7), (float)(num14 * 16 + 6)), 10, 8, 43, 0f, 0f, 254, Color.White, 0.5f);
								Main.dust[num53].velocity *= 0f;
							}
						}
						if (num15 == 0 && num34 != 0 && num16 == 1 && num17 != num18)
						{
							num34 = 0;
							num17 = num18;
							color4 = Color.White;
							if (num17 == 1)
							{
								spriteBatch.Draw(this.waterfallTexture[num12], new Vector2((float)(num13 * 16 - 16), (float)(num14 * 16 + 16)) - Main.screenPosition, new Rectangle?(new Rectangle(num21, 24, 32, 16 - num33)), color4, 0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0f);
							}
							else
							{
								spriteBatch.Draw(this.waterfallTexture[num12], new Vector2((float)(num13 * 16 - 16), (float)(num14 * 16 + 16)) - Main.screenPosition, new Rectangle?(new Rectangle(num21, 24, 32, 8)), color4, 0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0f);
							}
						}
						if (num19 != 0 && num36 == 0 && num37 == 1)
						{
							if (num17 == 1)
							{
								if (num20 != num12)
								{
									spriteBatch.Draw(this.waterfallTexture[num20], new Vector2((float)(num13 * 16), (float)(num14 * 16 + num11 + 8)) - Main.screenPosition, new Rectangle?(new Rectangle(num21, 0, 16, 16 - num33 - 8)), color3, 0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0f);
								}
								else
								{
									spriteBatch.Draw(this.waterfallTexture[num12], new Vector2((float)(num13 * 16), (float)(num14 * 16 + num11 + 8)) - Main.screenPosition, new Rectangle?(new Rectangle(num21, 0, 16, 16 - num33 - 8)), color4, 0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0f);
								}
							}
							else
							{
								spriteBatch.Draw(this.waterfallTexture[num12], new Vector2((float)(num13 * 16), (float)(num14 * 16 + num11 + 8)) - Main.screenPosition, new Rectangle?(new Rectangle(num21, 0, 16, 16 - num33 - 8)), color4, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
							}
						}
						if (num11 == 8 && num16 == 1 && num19 == 0)
						{
							if (num18 == -1)
							{
								if (num20 != num12)
								{
									spriteBatch.Draw(this.waterfallTexture[num20], new Vector2((float)(num13 * 16), (float)(num14 * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(num21, 24, 32, 8)), color3, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
								}
								else
								{
									spriteBatch.Draw(this.waterfallTexture[num12], new Vector2((float)(num13 * 16), (float)(num14 * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(num21, 24, 32, 8)), color4, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
								}
							}
							else if (num20 != num12)
							{
								spriteBatch.Draw(this.waterfallTexture[num20], new Vector2((float)(num13 * 16 - 16), (float)(num14 * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(num21, 24, 32, 8)), color3, 0f, default(Vector2), 1f, SpriteEffects.FlipHorizontally, 0f);
							}
							else
							{
								spriteBatch.Draw(this.waterfallTexture[num12], new Vector2((float)(num13 * 16 - 16), (float)(num14 * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(num21, 24, 32, 8)), color4, 0f, default(Vector2), 1f, SpriteEffects.FlipHorizontally, 0f);
							}
						}
						if (num34 != 0 && num15 == 0)
						{
							if (num35 == 1)
							{
								if (num20 != num12)
								{
									spriteBatch.Draw(this.waterfallTexture[num20], new Vector2((float)(num13 * 16 - 16), (float)(num14 * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(num21, 24, 32, 16 - num33)), color3, 0f, default(Vector2), 1f, SpriteEffects.FlipHorizontally, 0f);
								}
								else
								{
									spriteBatch.Draw(this.waterfallTexture[num12], new Vector2((float)(num13 * 16 - 16), (float)(num14 * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(num21, 24, 32, 16 - num33)), color4, 0f, default(Vector2), 1f, SpriteEffects.FlipHorizontally, 0f);
								}
							}
							else if (num20 != num12)
							{
								spriteBatch.Draw(this.waterfallTexture[num20], new Vector2((float)(num13 * 16), (float)(num14 * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(num21, 24, 32, 16 - num33)), color3, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
							}
							else
							{
								spriteBatch.Draw(this.waterfallTexture[num12], new Vector2((float)(num13 * 16), (float)(num14 * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(num21, 24, 32, 16 - num33)), color4, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
							}
						}
						if (num37 == 1 && num34 == 0 && num19 == 0)
						{
							if (num17 == -1)
							{
								if (num16 == 0)
								{
									spriteBatch.Draw(this.waterfallTexture[num12], new Vector2((float)(num13 * 16), (float)(num14 * 16 + num11)) - Main.screenPosition, new Rectangle?(new Rectangle(num21, 0, 16, 16 - num33)), color4, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
								}
								else if (num20 != num12)
								{
									spriteBatch.Draw(this.waterfallTexture[num20], new Vector2((float)(num13 * 16), (float)(num14 * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(num21, 24, 32, 16 - num33)), color3, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
								}
								else
								{
									spriteBatch.Draw(this.waterfallTexture[num12], new Vector2((float)(num13 * 16), (float)(num14 * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(num21, 24, 32, 16 - num33)), color4, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
								}
							}
							else if (num16 == 0)
							{
								spriteBatch.Draw(this.waterfallTexture[num12], new Vector2((float)(num13 * 16), (float)(num14 * 16 + num11)) - Main.screenPosition, new Rectangle?(new Rectangle(num21, 0, 16, 16 - num33)), color4, 0f, default(Vector2), 1f, SpriteEffects.FlipHorizontally, 0f);
							}
							else if (num20 != num12)
							{
								spriteBatch.Draw(this.waterfallTexture[num20], new Vector2((float)(num13 * 16 - 16), (float)(num14 * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(num21, 24, 32, 16 - num33)), color3, 0f, default(Vector2), 1f, SpriteEffects.FlipHorizontally, 0f);
							}
							else
							{
								spriteBatch.Draw(this.waterfallTexture[num12], new Vector2((float)(num13 * 16 - 16), (float)(num14 * 16)) - Main.screenPosition, new Rectangle?(new Rectangle(num21, 24, 32, 16 - num33)), color4, 0f, default(Vector2), 1f, SpriteEffects.FlipHorizontally, 0f);
							}
						}
						else if (num36 == 1)
						{
							if (Main.tile[num13, num14].liquid <= 0 || Main.tile[num13, num14].halfBrick())
							{
								if (num34 == 1)
								{
									for (int l = 0; l < 8; l++)
									{
										int num54 = l * 2;
										int num55 = 14 - l * 2;
										int num56 = num54;
										num11 = 8;
										if (num15 == 0 && l < 2)
										{
											num56 = 4;
										}
										spriteBatch.Draw(this.waterfallTexture[num12], new Vector2((float)(num13 * 16 + num54), (float)(num14 * 16 + num11 + num56)) - Main.screenPosition, new Rectangle?(new Rectangle(16 + num21 + num55, 0, 2, 16 - num11)), color4, 0f, default(Vector2), 1f, SpriteEffects.FlipHorizontally, 0f);
									}
								}
								else
								{
									spriteBatch.Draw(this.waterfallTexture[num12], new Vector2((float)(num13 * 16), (float)(num14 * 16 + num11)) - Main.screenPosition, new Rectangle?(new Rectangle(16 + num21, 0, 16, 16)), color4, 0f, default(Vector2), 1f, SpriteEffects.FlipHorizontally, 0f);
								}
							}
						}
						else if (num36 == -1)
						{
							if (Main.tile[num13, num14].liquid <= 0 || Main.tile[num13, num14].halfBrick())
							{
								if (num34 == -1)
								{
									for (int m = 0; m < 8; m++)
									{
										int num57 = m * 2;
										int num58 = m * 2;
										int num59 = 14 - m * 2;
										num11 = 8;
										if (num15 == 0 && m > 5)
										{
											num59 = 4;
										}
										spriteBatch.Draw(this.waterfallTexture[num12], new Vector2((float)(num13 * 16 + num57), (float)(num14 * 16 + num11 + num59)) - Main.screenPosition, new Rectangle?(new Rectangle(16 + num21 + num58, 0, 2, 16 - num11)), color4, 0f, default(Vector2), 1f, SpriteEffects.FlipHorizontally, 0f);
									}
								}
								else
								{
									spriteBatch.Draw(this.waterfallTexture[num12], new Vector2((float)(num13 * 16), (float)(num14 * 16 + num11)) - Main.screenPosition, new Rectangle?(new Rectangle(16 + num21, 0, 16, 16)), color4, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
								}
							}
						}
						else if (num36 == 0 && num37 == 0)
						{
							if (Main.tile[num13, num14].liquid <= 0 || Main.tile[num13, num14].halfBrick())
							{
								spriteBatch.Draw(this.waterfallTexture[num12], new Vector2((float)(num13 * 16), (float)(num14 * 16 + num11)) - Main.screenPosition, new Rectangle?(new Rectangle(16 + num21, 0, 16, 16)), color4, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
							}
							k = 1000;
						}
						if (tile2.liquid > 0 && !tile2.halfBrick())
						{
							k = 1000;
						}
						num16 = num37;
						num18 = num17;
						num15 = num36;
						num13 += num36;
						num14 += num37;
						num19 = num34;
						color3 = color4;
						if (num20 != num12)
						{
							num20 = num12;
						}
						if ((tile3.active() && (tile3.type == 189 || tile3.type == 196)) || (tile5.active() && (tile5.type == 189 || tile5.type == 196)) || (tile4.active() && (tile4.type == 189 || tile4.type == 196)))
						{
							num22 = (int)((float)(40 * (Main.maxTilesX / 4200)) * Main.gfxQuality);
						}
					}
				}
				goto IL_18C8;
			}
			Main.ambientWaterfallX = (float)num4;
			Main.ambientWaterfallY = (float)num5;
			Main.ambientWaterfallStrength = num;
			Main.ambientLavafallX = (float)num9;
			Main.ambientLavafallY = (float)num10;
			Main.ambientLavafallStrength = num6;
		}

		// Token: 0x060006DF RID: 1759 RVA: 0x00347114 File Offset: 0x00345314
		public void FindWaterfalls(bool forced = false)
		{
			this.findWaterfallCount++;
			if (this.findWaterfallCount < 30 && !forced)
			{
				return;
			}
			this.findWaterfallCount = 0;
			this.waterfallDist = (int)(75f * Main.gfxQuality) + 25;
			this.qualityMax = (int)(175f * Main.gfxQuality) + 25;
			this.currentMax = 0;
			int num = (int)(Main.screenPosition.X / 16f - 1f);
			int num2 = (int)((Main.screenPosition.X + (float)Main.screenWidth) / 16f) + 2;
			int num3 = (int)(Main.screenPosition.Y / 16f - 1f);
			int num4 = (int)((Main.screenPosition.Y + (float)Main.screenHeight) / 16f) + 2;
			num -= this.waterfallDist;
			num2 += this.waterfallDist;
			num3 -= this.waterfallDist;
			num4 += 20;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 > Main.maxTilesX)
			{
				num2 = Main.maxTilesX;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesY)
			{
				num4 = Main.maxTilesY;
			}
			for (int i = num; i < num2; i++)
			{
				for (int j = num3; j < num4; j++)
				{
					Tile tile = Main.tile[i, j];
					if (tile == null)
					{
						tile = new Tile();
						Main.tile[i, j] = tile;
					}
					if (tile.active())
					{
						if (tile.halfBrick())
						{
							Tile tile2 = Main.tile[i, j - 1];
							if (tile2 == null)
							{
								tile2 = new Tile();
								Main.tile[i, j - 1] = tile2;
							}
							if (tile2.liquid < 16 || WorldGen.SolidTile(tile2))
							{
								Tile tile3 = Main.tile[i + 1, j];
								if (tile3 == null)
								{
									tile3 = new Tile();
									Main.tile[i - 1, j] = tile3;
								}
								Tile tile4 = Main.tile[i - 1, j];
								if (tile4 == null)
								{
									tile4 = new Tile();
									Main.tile[i + 1, j] = tile4;
								}
								if ((tile3.liquid > 160 || tile4.liquid > 160) && ((tile3.liquid == 0 && !WorldGen.SolidTile(tile3) && tile3.slope() == 0) || (tile4.liquid == 0 && !WorldGen.SolidTile(tile4) && tile4.slope() == 0)) && this.currentMax < this.qualityMax)
								{
									this.waterfalls[this.currentMax].type = 0;
									if (tile2.lava() || tile4.lava() || tile3.lava())
									{
										this.waterfalls[this.currentMax].type = 1;
									}
									else if (tile2.honey() || tile4.honey() || tile3.honey())
									{
										this.waterfalls[this.currentMax].type = 14;
									}
									else
									{
										this.waterfalls[this.currentMax].type = 0;
									}
									this.waterfalls[this.currentMax].x = i;
									this.waterfalls[this.currentMax].y = j;
									this.currentMax++;
								}
							}
						}
						if (tile.type == 196)
						{
							Tile tile5 = Main.tile[i, j + 1];
							if (tile5 == null)
							{
								tile5 = new Tile();
								Main.tile[i, j + 1] = tile5;
							}
							if (!WorldGen.SolidTile(tile5) && tile5.slope() == 0 && this.currentMax < this.qualityMax)
							{
								this.waterfalls[this.currentMax].type = 11;
								this.waterfalls[this.currentMax].x = i;
								this.waterfalls[this.currentMax].y = j + 1;
								this.currentMax++;
							}
						}
						if (tile.type == 460)
						{
							Tile tile6 = Main.tile[i, j + 1];
							if (tile6 == null)
							{
								tile6 = new Tile();
								Main.tile[i, j + 1] = tile6;
							}
							if (!WorldGen.SolidTile(tile6) && tile6.slope() == 0 && this.currentMax < this.qualityMax)
							{
								this.waterfalls[this.currentMax].type = 22;
								this.waterfalls[this.currentMax].x = i;
								this.waterfalls[this.currentMax].y = j + 1;
								this.currentMax++;
							}
						}
					}
				}
			}
		}

		// Token: 0x060006DD RID: 1757 RVA: 0x00347068 File Offset: 0x00345268
		public void LoadContent()
		{
			for (int i = 0; i < 23; i++)
			{
				this.waterfallTexture[i] = Main.instance.OurLoad<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar.ToString(),
					"Waterfall_",
					i
				}));
			}
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x003475EC File Offset: 0x003457EC
		public void UpdateFrame()
		{
			this.wFallFrCounter++;
			if (this.wFallFrCounter > 2)
			{
				this.wFallFrCounter = 0;
				this.regularFrame++;
				if (this.regularFrame > 15)
				{
					this.regularFrame = 0;
				}
			}
			this.wFallFrCounter2++;
			if (this.wFallFrCounter2 > 6)
			{
				this.wFallFrCounter2 = 0;
				this.slowFrame++;
				if (this.slowFrame > 15)
				{
					this.slowFrame = 0;
				}
			}
			this.rainFrameCounter++;
			if (this.rainFrameCounter > 0)
			{
				this.rainFrameForeground++;
				if (this.rainFrameForeground > 7)
				{
					this.rainFrameForeground -= 8;
				}
				if (this.rainFrameCounter > 2)
				{
					this.rainFrameCounter = 0;
					this.rainFrameBackground--;
					if (this.rainFrameBackground < 0)
					{
						this.rainFrameBackground = 7;
					}
				}
			}
			int num = this.snowFrameCounter + 1;
			this.snowFrameCounter = num;
			if (num > 3)
			{
				this.snowFrameCounter = 0;
				num = this.snowFrameForeground + 1;
				this.snowFrameForeground = num;
				if (num > 7)
				{
					this.snowFrameForeground = 0;
				}
			}
		}

		// Token: 0x04000C29 RID: 3113
		private int currentMax;

		// Token: 0x04000C35 RID: 3125
		private int findWaterfallCount;

		// Token: 0x04000C25 RID: 3109
		private const int maxCount = 200;

		// Token: 0x04000C26 RID: 3110
		private const int maxLength = 100;

		// Token: 0x04000C27 RID: 3111
		private const int maxTypes = 23;

		// Token: 0x04000C24 RID: 3108
		private const int minWet = 160;

		// Token: 0x04000C28 RID: 3112
		private int qualityMax;

		// Token: 0x04000C32 RID: 3122
		private int rainFrameBackground;

		// Token: 0x04000C30 RID: 3120
		private int rainFrameCounter;

		// Token: 0x04000C31 RID: 3121
		private int rainFrameForeground;

		// Token: 0x04000C2D RID: 3117
		private int regularFrame;

		// Token: 0x04000C2F RID: 3119
		private int slowFrame;

		// Token: 0x04000C33 RID: 3123
		private int snowFrameCounter;

		// Token: 0x04000C34 RID: 3124
		private int snowFrameForeground;

		// Token: 0x04000C36 RID: 3126
		private int waterfallDist = 100;

		// Token: 0x04000C2A RID: 3114
		private WaterfallManager.WaterfallData[] waterfalls;

		// Token: 0x04000C2B RID: 3115
		public Texture2D[] waterfallTexture = new Texture2D[23];

		// Token: 0x04000C2C RID: 3116
		private int wFallFrCounter;

		// Token: 0x04000C2E RID: 3118
		private int wFallFrCounter2;

		// Token: 0x020001D8 RID: 472
		public struct WaterfallData
		{
			// Token: 0x040036D4 RID: 14036
			public int x;

			// Token: 0x040036D5 RID: 14037
			public int y;

			// Token: 0x040036D6 RID: 14038
			public int type;

			// Token: 0x040036D7 RID: 14039
			public int stopAtStep;
		}
	}
}

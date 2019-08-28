using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.GameContent.Events;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;

namespace Terraria
{
	// Token: 0x02000036 RID: 54
	public static class Wiring
	{
		// Token: 0x060006EA RID: 1770 RVA: 0x003499D0 File Offset: 0x00347BD0
		public static bool Actuate(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			if (!tile.actuator())
			{
				return false;
			}
			if ((tile.type != 226 || (double)j <= Main.worldSurface || NPC.downedPlantBoss) && ((double)j <= Main.worldSurface || NPC.downedGolemBoss || Main.tile[i, j - 1].type != 237))
			{
				if (tile.inActive())
				{
					Wiring.ReActive(i, j);
				}
				else
				{
					Wiring.DeActive(i, j);
				}
			}
			return true;
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x00349A54 File Offset: 0x00347C54
		public static void ActuateForced(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			if (tile.type != 226 || (double)j <= Main.worldSurface || NPC.downedPlantBoss)
			{
				if (tile.inActive())
				{
					Wiring.ReActive(i, j);
					return;
				}
				Wiring.DeActive(i, j);
			}
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x0034A58C File Offset: 0x0034878C
		private static void CheckLogicGate(int lampX, int lampY)
		{
			if (!WorldGen.InWorld(lampX, lampY, 1))
			{
				return;
			}
			int i = lampY;
			while (i < Main.maxTilesY)
			{
				Tile tile = Main.tile[lampX, i];
				if (!tile.active())
				{
					return;
				}
				if (tile.type == 420)
				{
					bool flag;
					Wiring._GatesDone.TryGetValue(new Point16(lampX, i), out flag);
					int num = (int)(tile.frameY / 18);
					bool flag2 = tile.frameX == 18;
					bool flag3 = tile.frameX == 36;
					if (num < 0)
					{
						return;
					}
					int num2 = 0;
					int num3 = 0;
					bool flag4 = false;
					for (int j = i - 1; j > 0; j--)
					{
						Tile tile2 = Main.tile[lampX, j];
						if (!tile2.active() || tile2.type != 419)
						{
							break;
						}
						if (tile2.frameX == 36)
						{
							flag4 = true;
							break;
						}
						num2++;
						num3 += (tile2.frameX == 18).ToInt();
					}
					bool flag5;
					switch (num)
					{
						case 0:
							flag5 = (num2 == num3);
							break;
						case 1:
							flag5 = (num3 > 0);
							break;
						case 2:
							flag5 = (num2 != num3);
							break;
						case 3:
							flag5 = (num3 == 0);
							break;
						case 4:
							flag5 = (num3 == 1);
							break;
						case 5:
							flag5 = (num3 != 1);
							break;
						default:
							return;
					}
					bool flag6 = !flag4 & flag3;
					bool flag7 = false;
					if (flag4 && Framing.GetTileSafely(lampX, lampY).frameX == 36)
					{
						flag7 = true;
					}
					if (flag5 != flag2 | flag6 | flag7)
					{
						short arg_181_0 = (short)(tile.frameX % 18 / 18);
						tile.frameX = (short)(18 * flag5.ToInt());
						if (flag4)
						{
							tile.frameX = 36;
						}
						Wiring.SkipWire(lampX, i);
						WorldGen.SquareTileFrame(lampX, i, true);
						NetMessage.SendTileSquare(-1, lampX, i, 1, TileChangeType.None);
						bool flag8 = !flag4 | flag7;
						if (flag7)
						{
							if (num3 == 0 || num2 == 0)
							{
							}
							flag8 = (Main.rand.NextFloat() < (float)num3 / (float)num2);
						}
						if (flag6)
						{
							flag8 = false;
						}
						if (flag8)
						{
							if (!flag)
							{
								Wiring._GatesNext.Enqueue(new Point16(lampX, i));
								return;
							}
							Vector2 vector = new Vector2((float)lampX, (float)i) * 16f - new Vector2(10f);
							Utils.PoofOfSmoke(vector);
							NetMessage.SendData(106, -1, -1, null, (int)vector.X, vector.Y, 0f, 0f, 0, 0, 0);
						}
					}
					return;
				}
				else
				{
					if (tile.type != 419)
					{
						return;
					}
					i++;
				}
			}
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x00349BC8 File Offset: 0x00347DC8
		private static bool CheckMech(int i, int j, int time)
		{
			for (int k = 0; k < Wiring._numMechs; k++)
			{
				if (Wiring._mechX[k] == i && Wiring._mechY[k] == j)
				{
					return false;
				}
			}
			if (Wiring._numMechs < 999)
			{
				Wiring._mechX[Wiring._numMechs] = i;
				Wiring._mechY[Wiring._numMechs] = j;
				Wiring._mechTime[Wiring._numMechs] = time;
				Wiring._numMechs++;
				return true;
			}
			return false;
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x0034DE50 File Offset: 0x0034C050
		private static void DeActive(int i, int j)
		{
			if (!Main.tile[i, j].active())
			{
				return;
			}
			bool flag = Main.tileSolid[(int)Main.tile[i, j].type] && !TileID.Sets.NotReallySolid[(int)Main.tile[i, j].type];
			ushort type = Main.tile[i, j].type;
			if (type == 314 || type - 386 <= 3)
			{
				flag = false;
			}
			if (!flag)
			{
				return;
			}
			if (Main.tile[i, j - 1].active() && (Main.tile[i, j - 1].type == 5 || TileID.Sets.BasicChest[(int)Main.tile[i, j - 1].type] || Main.tile[i, j - 1].type == 26 || Main.tile[i, j - 1].type == 77 || Main.tile[i, j - 1].type == 72 || Main.tile[i, j - 1].type == 88))
			{
				return;
			}
			Main.tile[i, j].inActive(true);
			WorldGen.SquareTileFrame(i, j, false);
			if (Main.netMode != 1)
			{
				NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
			}
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x003495C8 File Offset: 0x003477C8
		public static void HitSwitch(int i, int j)
		{
			if (!WorldGen.InWorld(i, j, 0))
			{
				return;
			}
			if (Main.tile[i, j] == null)
			{
				return;
			}
			if (Main.tile[i, j].type == 135 || Main.tile[i, j].type == 314 || Main.tile[i, j].type == 423 || Main.tile[i, j].type == 428 || Main.tile[i, j].type == 442)
			{
				Main.PlaySound(28, i * 16, j * 16, 0, 1f, 0f);
				Wiring.TripWire(i, j, 1, 1);
				return;
			}
			if (Main.tile[i, j].type == 440)
			{
				Main.PlaySound(28, i * 16 + 16, j * 16 + 16, 0, 1f, 0f);
				Wiring.TripWire(i, j, 3, 3);
				return;
			}
			if (Main.tile[i, j].type == 136)
			{
				if (Main.tile[i, j].frameY == 0)
				{
					Main.tile[i, j].frameY = 18;
				}
				else
				{
					Main.tile[i, j].frameY = 0;
				}
				Main.PlaySound(28, i * 16, j * 16, 0, 1f, 0f);
				Wiring.TripWire(i, j, 1, 1);
				return;
			}
			if (Main.tile[i, j].type == 144)
			{
				if (Main.tile[i, j].frameY == 0)
				{
					Main.tile[i, j].frameY = 18;
					if (Main.netMode != 1)
					{
						Wiring.CheckMech(i, j, 18000);
					}
				}
				else
				{
					Main.tile[i, j].frameY = 0;
				}
				Main.PlaySound(28, i * 16, j * 16, 0, 1f, 0f);
				return;
			}
			if (Main.tile[i, j].type == 441 || Main.tile[i, j].type == 468)
			{
				int num = (int)(Main.tile[i, j].frameX / 18 * -1);
				int num2 = (int)(Main.tile[i, j].frameY / 18 * -1);
				num %= 4;
				if (num < -1)
				{
					num += 2;
				}
				num += i;
				num2 += j;
				Main.PlaySound(28, i * 16, j * 16, 0, 1f, 0f);
				Wiring.TripWire(num, num2, 2, 2);
				return;
			}
			if (Main.tile[i, j].type == 132 || Main.tile[i, j].type == 411)
			{
				short num3 = 36;
				int num4 = (int)(Main.tile[i, j].frameX / 18 * -1);
				int num5 = (int)(Main.tile[i, j].frameY / 18 * -1);
				num4 %= 4;
				if (num4 < -1)
				{
					num4 += 2;
					num3 = -36;
				}
				num4 += i;
				num5 += j;
				if (Main.netMode != 1 && Main.tile[num4, num5].type == 411)
				{
					Wiring.CheckMech(num4, num5, 60);
				}
				for (int k = num4; k < num4 + 2; k++)
				{
					for (int l = num5; l < num5 + 2; l++)
					{
						if (Main.tile[k, l].type == 132 || Main.tile[k, l].type == 411)
						{
							Tile expr_382 = Main.tile[k, l];
							expr_382.frameX += num3;
						}
					}
				}
				WorldGen.TileFrame(num4, num5, false, false);
				Main.PlaySound(28, i * 16, j * 16, 0, 1f, 0f);
				Wiring.TripWire(num4, num5, 2, 2);
			}
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x0034A810 File Offset: 0x00348A10
		private static void HitWire(DoubleStack<Point16> next, int wireType)
		{
			Wiring._wireDirectionList.Clear(true);
			for (int i = 0; i < next.Count; i++)
			{
				Point16 point = next.PopFront();
				Wiring.SkipWire(point);
				Wiring._toProcess.Add(point, 4);
				next.PushBack(point);
				Wiring._wireDirectionList.PushBack(0);
			}
			Wiring._currentWireColor = wireType;
			while (next.Count > 0)
			{
				Point16 point2 = next.PopFront();
				int num = (int)Wiring._wireDirectionList.PopFront();
				int x = (int)point2.X;
				int y = (int)point2.Y;
				if (!Wiring._wireSkip.ContainsKey(point2))
				{
					Wiring.HitWireSingle(x, y);
				}
				for (int j = 0; j < 4; j++)
				{
					int num2;
					int num3;
					switch (j)
					{
						case 0:
							num2 = x;
							num3 = y + 1;
							break;
						case 1:
							num2 = x;
							num3 = y - 1;
							break;
						case 2:
							num2 = x + 1;
							num3 = y;
							break;
						case 3:
							num2 = x - 1;
							num3 = y;
							break;
						default:
							num2 = x;
							num3 = y + 1;
							break;
					}
					if (num2 >= 2 && num2 < Main.maxTilesX - 2 && num3 >= 2 && num3 < Main.maxTilesY - 2)
					{
						Tile tile = Main.tile[num2, num3];
						if (tile != null)
						{
							Tile tile2 = Main.tile[x, y];
							if (tile2 != null)
							{
								byte b = 3;
								if (tile.type == 424 || tile.type == 445)
								{
									b = 0;
								}
								if (tile2.type == 424)
								{
									switch (tile2.frameX / 18)
									{
										case 0:
											if (j != num)
											{
												goto IL_318;
											}
											break;
										case 1:
											if ((num != 0 || j != 3) && (num != 3 || j != 0) && (num != 1 || j != 2))
											{
												if (num != 2)
												{
													goto IL_318;
												}
												if (j != 1)
												{
													goto IL_318;
												}
											}
											break;
										case 2:
											if ((num != 0 || j != 2) && (num != 2 || j != 0) && (num != 1 || j != 3) && (num != 3 || j != 1))
											{
												goto IL_318;
											}
											break;
									}
								}
								if (tile2.type == 445)
								{
									if (j != num)
									{
										goto IL_318;
									}
									if (Wiring._PixelBoxTriggers.ContainsKey(point2))
									{
										Dictionary<Point16, byte> pixelBoxTriggers = Wiring._PixelBoxTriggers;
										Point16 key = point2;
										//TODO: 看看这是做什么的   //										(byte) ((byte) (pixelBoxTriggers[key] |= ((j == 0 | j == 1) ? 2 : 1)));
									}
									else
									{
										Wiring._PixelBoxTriggers[point2] = ((byte)((j == 0 | j == 1) ? 2 : 1));
									}
								}
								bool flag;
								switch (wireType)
								{
									case 1:
										flag = tile.wire();
										break;
									case 2:
										flag = tile.wire2();
										break;
									case 3:
										flag = tile.wire3();
										break;
									case 4:
										flag = tile.wire4();
										break;
									default:
										flag = false;
										break;
								}
								if (flag)
								{
									Point16 point3 = new Point16(num2, num3);
									byte b2;
									if (Wiring._toProcess.TryGetValue(point3, out b2))
									{
										b2 -= 1;
										if (b2 == 0)
										{
											Wiring._toProcess.Remove(point3);
										}
										else
										{
											Wiring._toProcess[point3] = b2;
										}
									}
									else
									{
										next.PushBack(point3);
										Wiring._wireDirectionList.PushBack((byte)j);
										if (b > 0)
										{
											Wiring._toProcess.Add(point3, b);
										}
									}
								}
							}
						}
					}
					IL_318:;
				}
			}
			Wiring._wireSkip.Clear();
			Wiring._toProcess.Clear();
			Wiring.running = false;
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x0034AB6C File Offset: 0x00348D6C
		private static void HitWireSingle(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			int type = (int)tile.type;
			if (tile.actuator())
			{
				Wiring.ActuateForced(i, j);
			}
			if (tile.active())
			{
				if (type == 144)
				{
					Wiring.HitSwitch(i, j);
					WorldGen.SquareTileFrame(i, j, true);
					NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
				}
				else if (type == 421)
				{
					if (!tile.actuator())
					{
						tile.type = 422;
						WorldGen.SquareTileFrame(i, j, true);
						NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
					}
				}
				else if (type == 422 && !tile.actuator())
				{
					tile.type = 421;
					WorldGen.SquareTileFrame(i, j, true);
					NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
				}
				if (type >= 255 && type <= 268)
				{
					if (!tile.actuator())
					{
						if (type >= 262)
						{
							Tile expr_D1 = tile;
							expr_D1.type -= 7;
						}
						else
						{
							Tile expr_E2 = tile;
							expr_E2.type += 7;
						}
						WorldGen.SquareTileFrame(i, j, true);
						NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
						return;
					}
				}
				else
				{
					if (type == 419)
					{
						int num = 18;
						if ((int)tile.frameX >= num)
						{
							num = -num;
						}
						if (tile.frameX == 36)
						{
							num = 0;
						}
						Wiring.SkipWire(i, j);
						tile.frameX = (short)((int)tile.frameX + num);
						WorldGen.SquareTileFrame(i, j, true);
						NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
						Wiring._LampsToCheck.Enqueue(new Point16(i, j));
						return;
					}
					if (type == 406)
					{
						int num2 = (int)(tile.frameX % 54 / 18);
						int num3 = (int)(tile.frameY % 54 / 18);
						int num4 = i - num2;
						int num5 = j - num3;
						int num6 = 54;
						if (Main.tile[num4, num5].frameY >= 108)
						{
							num6 = -108;
						}
						for (int k = num4; k < num4 + 3; k++)
						{
							for (int l = num5; l < num5 + 3; l++)
							{
								Wiring.SkipWire(k, l);
								Main.tile[k, l].frameY = (short)((int)Main.tile[k, l].frameY + num6);
							}
						}
						NetMessage.SendTileSquare(-1, num4 + 1, num5 + 1, 3, TileChangeType.None);
						return;
					}
					if (type == 452)
					{
						int num7 = (int)(tile.frameX % 54 / 18);
						int num8 = (int)(tile.frameY % 54 / 18);
						int num9 = i - num7;
						int num10 = j - num8;
						int num11 = 54;
						if (Main.tile[num9, num10].frameX >= 54)
						{
							num11 = -54;
						}
						for (int m = num9; m < num9 + 3; m++)
						{
							for (int n = num10; n < num10 + 3; n++)
							{
								Wiring.SkipWire(m, n);
								Main.tile[m, n].frameX = (short)((int)Main.tile[m, n].frameX + num11);
							}
						}
						NetMessage.SendTileSquare(-1, num9 + 1, num10 + 1, 3, TileChangeType.None);
						return;
					}
					if (type == 411)
					{
						int num12 = (int)(tile.frameX % 36 / 18);
						int num13 = (int)(tile.frameY % 36 / 18);
						int num14 = i - num12;
						int num15 = j - num13;
						int num16 = 36;
						if (Main.tile[num14, num15].frameX >= 36)
						{
							num16 = -36;
						}
						for (int num17 = num14; num17 < num14 + 2; num17++)
						{
							for (int num18 = num15; num18 < num15 + 2; num18++)
							{
								Wiring.SkipWire(num17, num18);
								Main.tile[num17, num18].frameX = (short)((int)Main.tile[num17, num18].frameX + num16);
							}
						}
						NetMessage.SendTileSquare(-1, num14, num15, 2, TileChangeType.None);
						return;
					}
					if (type == 425)
					{
						int num19 = (int)(tile.frameX % 36 / 18);
						int num20 = (int)(tile.frameY % 36 / 18);
						int num21 = i - num19;
						int num22 = j - num20;
						for (int num23 = num21; num23 < num21 + 2; num23++)
						{
							for (int num24 = num22; num24 < num22 + 2; num24++)
							{
								Wiring.SkipWire(num23, num24);
							}
						}
						if (!Main.AnnouncementBoxDisabled)
						{
							Color pink = Color.Pink;
							int num25 = Sign.ReadSign(num21, num22, false);
							if (num25 != -1 && Main.sign[num25] != null && !string.IsNullOrWhiteSpace(Main.sign[num25].text))
							{
								if (Main.AnnouncementBoxRange == -1)
								{
									if (Main.netMode == 0)
									{
										Main.NewTextMultiline(Main.sign[num25].text, false, pink, 460);
										return;
									}
									if (Main.netMode == 2)
									{
										NetMessage.SendData(107, -1, -1, NetworkText.FromLiteral(Main.sign[num25].text), 255, (float)pink.R, (float)pink.G, (float)pink.B, 460, 0, 0);
										return;
									}
								}
								else if (Main.netMode == 0)
								{
									if (Main.player[Main.myPlayer].Distance(new Vector2((float)(num21 * 16 + 16), (float)(num22 * 16 + 16))) <= (float)Main.AnnouncementBoxRange)
									{
										Main.NewTextMultiline(Main.sign[num25].text, false, pink, 460);
										return;
									}
								}
								else if (Main.netMode == 2)
								{
									for (int num26 = 0; num26 < 255; num26++)
									{
										if (Main.player[num26].active && Main.player[num26].Distance(new Vector2((float)(num21 * 16 + 16), (float)(num22 * 16 + 16))) <= (float)Main.AnnouncementBoxRange)
										{
											NetMessage.SendData(107, num26, -1, NetworkText.FromLiteral(Main.sign[num25].text), 255, (float)pink.R, (float)pink.G, (float)pink.B, 460, 0, 0);
										}
									}
									return;
								}
							}
						}
					}
					else
					{
						if (type == 405)
						{
							int num27 = (int)(tile.frameX % 54 / 18);
							int num28 = (int)(tile.frameY % 36 / 18);
							int num29 = i - num27;
							int num30 = j - num28;
							int num31 = 54;
							if (Main.tile[num29, num30].frameX >= 54)
							{
								num31 = -54;
							}
							for (int num32 = num29; num32 < num29 + 3; num32++)
							{
								for (int num33 = num30; num33 < num30 + 2; num33++)
								{
									Wiring.SkipWire(num32, num33);
									Main.tile[num32, num33].frameX = (short)((int)Main.tile[num32, num33].frameX + num31);
								}
							}
							NetMessage.SendTileSquare(-1, num29 + 1, num30 + 1, 3, TileChangeType.None);
							return;
						}
						if (type == 209)
						{
							int num34 = (int)(tile.frameX % 72 / 18);
							int num35 = (int)(tile.frameY % 54 / 18);
							int num36 = i - num34;
							int num37 = j - num35;
							int num38 = (int)(tile.frameY / 54);
							int num39 = (int)(tile.frameX / 72);
							int num40 = -1;
							if (num34 == 1 || num34 == 2)
							{
								num40 = num35;
							}
							int num41 = 0;
							if (num34 == 3)
							{
								num41 = -54;
							}
							if (num34 == 0)
							{
								num41 = 54;
							}
							if (num38 >= 8 && num41 > 0)
							{
								num41 = 0;
							}
							if (num38 == 0 && num41 < 0)
							{
								num41 = 0;
							}
							bool flag = false;
							if (num41 != 0)
							{
								for (int num42 = num36; num42 < num36 + 4; num42++)
								{
									for (int num43 = num37; num43 < num37 + 3; num43++)
									{
										Wiring.SkipWire(num42, num43);
										Main.tile[num42, num43].frameY = (short)((int)Main.tile[num42, num43].frameY + num41);
									}
								}
								flag = true;
							}
							if ((num39 == 3 || num39 == 4) && (num40 == 0 || num40 == 1))
							{
								num41 = ((num39 == 3) ? 72 : -72);
								for (int num44 = num36; num44 < num36 + 4; num44++)
								{
									for (int num45 = num37; num45 < num37 + 3; num45++)
									{
										Wiring.SkipWire(num44, num45);
										Main.tile[num44, num45].frameX = (short)((int)Main.tile[num44, num45].frameX + num41);
									}
								}
								flag = true;
							}
							if (flag)
							{
								NetMessage.SendTileSquare(-1, num36 + 1, num37 + 1, 4, TileChangeType.None);
							}
							if (num40 != -1)
							{
								bool flag2 = true;
								if ((num39 == 3 || num39 == 4) && num40 < 2)
								{
									flag2 = false;
								}
								if (Wiring.CheckMech(num36, num37, 30) & flag2)
								{
									WorldGen.ShootFromCannon(num36, num37, num38, num39 + 1, 0, 0f, Wiring.CurrentUser);
									return;
								}
							}
						}
						else if (type == 212)
						{
							int num46 = (int)(tile.frameX % 54 / 18);
							int num47 = (int)(tile.frameY % 54 / 18);
							int num48 = i - num46;
							int num49 = j - num47;
							short arg_88E_0 = (short)(tile.frameX / 54);
							int num50 = -1;
							if (num46 == 1)
							{
								num50 = num47;
							}
							int num51 = 0;
							if (num46 == 0)
							{
								num51 = -54;
							}
							if (num46 == 2)
							{
								num51 = 54;
							}
							if (arg_88E_0 >= 1 && num51 > 0)
							{
								num51 = 0;
							}
							if (arg_88E_0 == 0 && num51 < 0)
							{
								num51 = 0;
							}
							bool flag3 = false;
							if (num51 != 0)
							{
								for (int num52 = num48; num52 < num48 + 3; num52++)
								{
									for (int num53 = num49; num53 < num49 + 3; num53++)
									{
										Wiring.SkipWire(num52, num53);
										Main.tile[num52, num53].frameX = (short)((int)Main.tile[num52, num53].frameX + num51);
									}
								}
								flag3 = true;
							}
							if (flag3)
							{
								NetMessage.SendTileSquare(-1, num48 + 1, num49 + 1, 4, TileChangeType.None);
							}
							if (num50 != -1 && Wiring.CheckMech(num48, num49, 10))
							{
								float arg_9F0_0 = 12f + (float)Main.rand.Next(450) * 0.01f;
								float num54 = (float)Main.rand.Next(85, 105);
								float arg_9D8_0 = (float)Main.rand.Next(-35, 11);
								int type2 = 166;
								int damage = 0;
								float knockBack = 0f;
								Vector2 vector = new Vector2((float)((num48 + 2) * 16 - 8), (float)((num49 + 2) * 16 - 8));
								if (tile.frameX / 54 == 0)
								{
									num54 *= -1f;
									vector.X -= 12f;
								}
								else
								{
									vector.X += 12f;
								}
								float num55 = num54;
								float num56 = arg_9D8_0;
								float num57 = (float)Math.Sqrt((double)(num55 * num55 + num56 * num56));
								num57 = arg_9F0_0 / num57;
								num55 *= num57;
								num56 *= num57;
								Projectile.NewProjectile(vector.X, vector.Y, num55, num56, type2, damage, knockBack, Wiring.CurrentUser, 0f, 0f);
								return;
							}
						}
						else
						{
							if (type == 215)
							{
								int num58 = (int)(tile.frameX % 54 / 18);
								int num59 = (int)(tile.frameY % 36 / 18);
								int num60 = i - num58;
								int num61 = j - num59;
								int num62 = 36;
								if (Main.tile[num60, num61].frameY >= 36)
								{
									num62 = -36;
								}
								for (int num63 = num60; num63 < num60 + 3; num63++)
								{
									for (int num64 = num61; num64 < num61 + 2; num64++)
									{
										Wiring.SkipWire(num63, num64);
										Main.tile[num63, num64].frameY = (short)((int)Main.tile[num63, num64].frameY + num62);
									}
								}
								NetMessage.SendTileSquare(-1, num60 + 1, num61 + 1, 3, TileChangeType.None);
								return;
							}
							if (type == 130)
							{
								if (Main.tile[i, j - 1] == null || !Main.tile[i, j - 1].active() || (!TileID.Sets.BasicChest[(int)Main.tile[i, j - 1].type] && !TileID.Sets.BasicChestFake[(int)Main.tile[i, j - 1].type] && Main.tile[i, j - 1].type != 88))
								{
									tile.type = 131;
									WorldGen.SquareTileFrame(i, j, true);
									NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
									return;
								}
							}
							else
							{
								if (type == 131)
								{
									tile.type = 130;
									WorldGen.SquareTileFrame(i, j, true);
									NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
									return;
								}
								if (type == 387 || type == 386)
								{
									bool value = type == 387;
									int num65 = WorldGen.ShiftTrapdoor(i, j, true, -1).ToInt();
									if (num65 == 0)
									{
										num65 = -WorldGen.ShiftTrapdoor(i, j, false, -1).ToInt();
									}
									if (num65 != 0)
									{
										NetMessage.SendData(19, -1, -1, null, 3 - value.ToInt(), (float)i, (float)j, (float)num65, 0, 0, 0);
										return;
									}
								}
								else
								{
									if (type == 389 || type == 388)
									{
										bool flag4 = type == 389;
										WorldGen.ShiftTallGate(i, j, flag4);
										NetMessage.SendData(19, -1, -1, null, 4 + flag4.ToInt(), (float)i, (float)j, 0f, 0, 0, 0);
										return;
									}
									if (type == 11)
									{
										if (WorldGen.CloseDoor(i, j, true))
										{
											NetMessage.SendData(19, -1, -1, null, 1, (float)i, (float)j, 0f, 0, 0, 0);
											return;
										}
									}
									else if (type == 10)
									{
										int num66 = 1;
										if (Main.rand.Next(2) == 0)
										{
											num66 = -1;
										}
										if (WorldGen.OpenDoor(i, j, num66))
										{
											NetMessage.SendData(19, -1, -1, null, 0, (float)i, (float)j, (float)num66, 0, 0, 0);
											return;
										}
										if (WorldGen.OpenDoor(i, j, -num66))
										{
											NetMessage.SendData(19, -1, -1, null, 0, (float)i, (float)j, (float)(-(float)num66), 0, 0, 0);
											return;
										}
									}
									else
									{
										if (type == 216)
										{
											WorldGen.LaunchRocket(i, j);
											Wiring.SkipWire(i, j);
											return;
										}
										if (type == 335)
										{
											int num67 = j - (int)(tile.frameY / 18);
											int num68 = i - (int)(tile.frameX / 18);
											Wiring.SkipWire(num68, num67);
											Wiring.SkipWire(num68, num67 + 1);
											Wiring.SkipWire(num68 + 1, num67);
											Wiring.SkipWire(num68 + 1, num67 + 1);
											if (Wiring.CheckMech(num68, num67, 30))
											{
												WorldGen.LaunchRocketSmall(num68, num67);
												return;
											}
										}
										else if (type == 338)
										{
											int num69 = j - (int)(tile.frameY / 18);
											int num70 = i - (int)(tile.frameX / 18);
											Wiring.SkipWire(num70, num69);
											Wiring.SkipWire(num70, num69 + 1);
											if (Wiring.CheckMech(num70, num69, 30))
											{
												bool flag5 = false;
												for (int num71 = 0; num71 < 1000; num71++)
												{
													if (Main.projectile[num71].active && Main.projectile[num71].aiStyle == 73 && Main.projectile[num71].ai[0] == (float)num70 && Main.projectile[num71].ai[1] == (float)num69)
													{
														flag5 = true;
														break;
													}
												}
												if (!flag5)
												{
													Projectile.NewProjectile((float)(num70 * 16 + 8), (float)(num69 * 16 + 2), 0f, 0f, 419 + Main.rand.Next(4), 0, 0f, Main.myPlayer, (float)num70, (float)num69);
													return;
												}
											}
										}
										else if (type == 235)
										{
											int num72 = i - (int)(tile.frameX / 18);
											if (tile.wall != 87 || (double)j <= Main.worldSurface || NPC.downedPlantBoss)
											{
												if (Wiring._teleport[0].X == -1f)
												{
													Wiring._teleport[0].X = (float)num72;
													Wiring._teleport[0].Y = (float)j;
													if (tile.halfBrick())
													{
														Vector2[] expr_EEA_cp_0_cp_0 = Wiring._teleport;
														int expr_EEA_cp_0_cp_1 = 0;
														expr_EEA_cp_0_cp_0[expr_EEA_cp_0_cp_1].Y = expr_EEA_cp_0_cp_0[expr_EEA_cp_0_cp_1].Y + 0.5f;
														return;
													}
												}
												else if (Wiring._teleport[0].X != (float)num72 || Wiring._teleport[0].Y != (float)j)
												{
													Wiring._teleport[1].X = (float)num72;
													Wiring._teleport[1].Y = (float)j;
													if (tile.halfBrick())
													{
														Vector2[] expr_F60_cp_0_cp_0 = Wiring._teleport;
														int expr_F60_cp_0_cp_1 = 1;
														expr_F60_cp_0_cp_0[expr_F60_cp_0_cp_1].Y = expr_F60_cp_0_cp_0[expr_F60_cp_0_cp_1].Y + 0.5f;
														return;
													}
												}
											}
										}
										else
										{
											if (type == 4)
											{
												if (tile.frameX < 66)
												{
													Tile expr_F79 = tile;
													expr_F79.frameX += 66;
												}
												else
												{
													Tile expr_F8B = tile;
													expr_F8B.frameX -= 66;
												}
												NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
												return;
											}
											if (type == 429)
											{
												short expr_FC4 = (short)(Main.tile[i, j].frameX / 18);
												bool flag6 = expr_FC4 % 2 >= 1;
												bool flag7 = expr_FC4 % 4 >= 2;
												bool flag8 = expr_FC4 % 8 >= 4;
												bool flag9 = expr_FC4 % 16 >= 8;
												bool flag10 = false;
												short num73 = 0;
												switch (Wiring._currentWireColor)
												{
													case 1:
														num73 = 18;
														flag10 = !flag6;
														break;
													case 2:
														num73 = 72;
														flag10 = !flag8;
														break;
													case 3:
														num73 = 36;
														flag10 = !flag7;
														break;
													case 4:
														num73 = 144;
														flag10 = !flag9;
														break;
												}
												if (flag10)
												{
													Tile expr_1052 = tile;
													expr_1052.frameX += num73;
												}
												else
												{
													Tile expr_1064 = tile;
													expr_1064.frameX -= num73;
												}
												NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
												return;
											}
											if (type == 149)
											{
												if (tile.frameX < 54)
												{
													Tile expr_1091 = tile;
													expr_1091.frameX += 54;
												}
												else
												{
													Tile expr_10A3 = tile;
													expr_10A3.frameX -= 54;
												}
												NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
												return;
											}
											if (type == 244)
											{
												int num74;
												for (num74 = (int)(tile.frameX / 18); num74 >= 3; num74 -= 3)
												{
												}
												int num75;
												for (num75 = (int)(tile.frameY / 18); num75 >= 3; num75 -= 3)
												{
												}
												int num76 = i - num74;
												int num77 = j - num75;
												int num78 = 54;
												if (Main.tile[num76, num77].frameX >= 54)
												{
													num78 = -54;
												}
												for (int num79 = num76; num79 < num76 + 3; num79++)
												{
													for (int num80 = num77; num80 < num77 + 2; num80++)
													{
														Wiring.SkipWire(num79, num80);
														Main.tile[num79, num80].frameX = (short)((int)Main.tile[num79, num80].frameX + num78);
													}
												}
												NetMessage.SendTileSquare(-1, num76 + 1, num77 + 1, 3, TileChangeType.None);
												return;
											}
											if (type == 42)
											{
												int num81;
												for (num81 = (int)(tile.frameY / 18); num81 >= 2; num81 -= 2)
												{
												}
												int num82 = j - num81;
												short num83 = 18;
												if (tile.frameX > 0)
												{
													num83 = -18;
												}
												Tile expr_11D3 = Main.tile[i, num82];
												expr_11D3.frameX += num83;
												Tile expr_11F1 = Main.tile[i, num82 + 1];
												expr_11F1.frameX += num83;
												Wiring.SkipWire(i, num82);
												Wiring.SkipWire(i, num82 + 1);
												NetMessage.SendTileSquare(-1, i, j, 2, TileChangeType.None);
												return;
											}
											if (type == 93)
											{
												int num84;
												for (num84 = (int)(tile.frameY / 18); num84 >= 3; num84 -= 3)
												{
												}
												num84 = j - num84;
												short num85 = 18;
												if (tile.frameX > 0)
												{
													num85 = -18;
												}
												Tile expr_1261 = Main.tile[i, num84];
												expr_1261.frameX += num85;
												Tile expr_127F = Main.tile[i, num84 + 1];
												expr_127F.frameX += num85;
												Tile expr_129D = Main.tile[i, num84 + 2];
												expr_129D.frameX += num85;
												Wiring.SkipWire(i, num84);
												Wiring.SkipWire(i, num84 + 1);
												Wiring.SkipWire(i, num84 + 2);
												NetMessage.SendTileSquare(-1, i, num84 + 1, 3, TileChangeType.None);
												return;
											}
											if (type == 126 || type == 95 || type == 100 || type == 173)
											{
												int num86;
												for (num86 = (int)(tile.frameY / 18); num86 >= 2; num86 -= 2)
												{
												}
												num86 = j - num86;
												int num87 = (int)(tile.frameX / 18);
												if (num87 > 1)
												{
													num87 -= 2;
												}
												num87 = i - num87;
												short num88 = 36;
												if (Main.tile[num87, num86].frameX > 0)
												{
													num88 = -36;
												}
												Tile expr_1356 = Main.tile[num87, num86];
												expr_1356.frameX += num88;
												Tile expr_1375 = Main.tile[num87, num86 + 1];
												expr_1375.frameX += num88;
												Tile expr_1394 = Main.tile[num87 + 1, num86];
												expr_1394.frameX += num88;
												Tile expr_13B5 = Main.tile[num87 + 1, num86 + 1];
												expr_13B5.frameX += num88;
												Wiring.SkipWire(num87, num86);
												Wiring.SkipWire(num87 + 1, num86);
												Wiring.SkipWire(num87, num86 + 1);
												Wiring.SkipWire(num87 + 1, num86 + 1);
												NetMessage.SendTileSquare(-1, num87, num86, 3, TileChangeType.None);
												return;
											}
											if (type == 34)
											{
												int num89;
												for (num89 = (int)(tile.frameY / 18); num89 >= 3; num89 -= 3)
												{
												}
												int num90 = j - num89;
												int num91 = (int)(tile.frameX % 108 / 18);
												if (num91 > 2)
												{
													num91 -= 3;
												}
												num91 = i - num91;
												short num92 = 54;
												if (Main.tile[num91, num90].frameX % 108 > 0)
												{
													num92 = -54;
												}
												for (int num93 = num91; num93 < num91 + 3; num93++)
												{
													for (int num94 = num90; num94 < num90 + 3; num94++)
													{
														Tile expr_147D = Main.tile[num93, num94];
														expr_147D.frameX += num92;
														Wiring.SkipWire(num93, num94);
													}
												}
												NetMessage.SendTileSquare(-1, num91 + 1, num90 + 1, 3, TileChangeType.None);
												return;
											}
											if (type == 314)
											{
												if (Wiring.CheckMech(i, j, 5))
												{
													Minecart.FlipSwitchTrack(i, j);
													return;
												}
											}
											else
											{
												if (type == 33 || type == 174)
												{
													short num95 = 18;
													if (tile.frameX > 0)
													{
														num95 = -18;
													}
													Tile expr_14FE = tile;
													expr_14FE.frameX += num95;
													NetMessage.SendTileSquare(-1, i, j, 3, TileChangeType.None);
													return;
												}
												if (type == 92)
												{
													int num96 = j - (int)(tile.frameY / 18);
													short num97 = 18;
													if (tile.frameX > 0)
													{
														num97 = -18;
													}
													for (int num98 = num96; num98 < num96 + 6; num98++)
													{
														Tile expr_154E = Main.tile[i, num98];
														expr_154E.frameX += num97;
														Wiring.SkipWire(i, num98);
													}
													NetMessage.SendTileSquare(-1, i, num96 + 3, 7, TileChangeType.None);
													return;
												}
												if (type == 137)
												{
													int num99 = (int)(tile.frameY / 18);
													Vector2 zero = Vector2.Zero;
													float speedX = 0f;
													float speedY = 0f;
													int num100 = 0;
													int damage2 = 0;
													switch (num99)
													{
														case 0:
														case 1:
														case 2:
															if (Wiring.CheckMech(i, j, 200))
															{
																int num101 = (tile.frameX == 0) ? -1 : ((tile.frameX == 18) ? 1 : 0);
																int num102 = (tile.frameX < 36) ? 0 : ((tile.frameX < 72) ? -1 : 1);
																zero = new Vector2((float)(i * 16 + 8 + 10 * num101), (float)(j * 16 + 9 + num102 * 9));
																float num103 = 3f;
																if (num99 == 0)
																{
																	num100 = 98;
																	damage2 = 20;
																	num103 = 12f;
																}
																if (num99 == 1)
																{
																	num100 = 184;
																	damage2 = 40;
																	num103 = 12f;
																}
																if (num99 == 2)
																{
																	num100 = 187;
																	damage2 = 40;
																	num103 = 5f;
																}
																speedX = (float)num101 * num103;
																speedY = (float)num102 * num103;
															}
															break;
														case 3:
															if (Wiring.CheckMech(i, j, 300))
															{
																int num104 = 200;
																for (int num105 = 0; num105 < 1000; num105++)
																{
																	if (Main.projectile[num105].active && Main.projectile[num105].type == num100)
																	{
																		float num106 = (new Vector2((float)(i * 16 + 8), (float)(j * 18 + 8)) - Main.projectile[num105].Center).Length();
																		if (num106 < 50f)
																		{
																			num104 -= 50;
																		}
																		else if (num106 < 100f)
																		{
																			num104 -= 15;
																		}
																		else if (num106 < 200f)
																		{
																			num104 -= 10;
																		}
																		else if (num106 < 300f)
																		{
																			num104 -= 8;
																		}
																		else if (num106 < 400f)
																		{
																			num104 -= 6;
																		}
																		else if (num106 < 500f)
																		{
																			num104 -= 5;
																		}
																		else if (num106 < 700f)
																		{
																			num104 -= 4;
																		}
																		else if (num106 < 900f)
																		{
																			num104 -= 3;
																		}
																		else if (num106 < 1200f)
																		{
																			num104 -= 2;
																		}
																		else
																		{
																			num104--;
																		}
																	}
																}
																if (num104 > 0)
																{
																	num100 = 185;
																	damage2 = 40;
																	int num107 = 0;
																	int num108 = 0;
																	switch (tile.frameX / 18)
																	{
																		case 0:
																		case 1:
																			num107 = 0;
																			num108 = 1;
																			break;
																		case 2:
																			num107 = 0;
																			num108 = -1;
																			break;
																		case 3:
																			num107 = -1;
																			num108 = 0;
																			break;
																		case 4:
																			num107 = 1;
																			num108 = 0;
																			break;
																	}
																	speedX = (float)(4 * num107) + (float)Main.rand.Next(-20 + ((num107 == 1) ? 20 : 0), 21 - ((num107 == -1) ? 20 : 0)) * 0.05f;
																	speedY = (float)(4 * num108) + (float)Main.rand.Next(-20 + ((num108 == 1) ? 20 : 0), 21 - ((num108 == -1) ? 20 : 0)) * 0.05f;
																	zero = new Vector2((float)(i * 16 + 8 + 14 * num107), (float)(j * 16 + 8 + 14 * num108));
																}
															}
															break;
														case 4:
															if (Wiring.CheckMech(i, j, 90))
															{
																int num109 = 0;
																int num110 = 0;
																switch (tile.frameX / 18)
																{
																	case 0:
																	case 1:
																		num109 = 0;
																		num110 = 1;
																		break;
																	case 2:
																		num109 = 0;
																		num110 = -1;
																		break;
																	case 3:
																		num109 = -1;
																		num110 = 0;
																		break;
																	case 4:
																		num109 = 1;
																		num110 = 0;
																		break;
																}
																speedX = (float)(8 * num109);
																speedY = (float)(8 * num110);
																damage2 = 60;
																num100 = 186;
																zero = new Vector2((float)(i * 16 + 8 + 18 * num109), (float)(j * 16 + 8 + 18 * num110));
															}
															break;
													}
													switch (num99 + 10)
													{
														case 0:
															if (Wiring.CheckMech(i, j, 200))
															{
																int num111 = -1;
																if (tile.frameX != 0)
																{
																	num111 = 1;
																}
																speedX = (float)(12 * num111);
																damage2 = 20;
																num100 = 98;
																zero = new Vector2((float)(i * 16 + 8), (float)(j * 16 + 7));
																zero.X += (float)(10 * num111);
																zero.Y += 2f;
															}
															break;
														case 1:
															if (Wiring.CheckMech(i, j, 200))
															{
																int num112 = -1;
																if (tile.frameX != 0)
																{
																	num112 = 1;
																}
																speedX = (float)(12 * num112);
																damage2 = 40;
																num100 = 184;
																zero = new Vector2((float)(i * 16 + 8), (float)(j * 16 + 7));
																zero.X += (float)(10 * num112);
																zero.Y += 2f;
															}
															break;
														case 2:
															if (Wiring.CheckMech(i, j, 200))
															{
																int num113 = -1;
																if (tile.frameX != 0)
																{
																	num113 = 1;
																}
																speedX = (float)(5 * num113);
																damage2 = 40;
																num100 = 187;
																zero = new Vector2((float)(i * 16 + 8), (float)(j * 16 + 7));
																zero.X += (float)(10 * num113);
																zero.Y += 2f;
															}
															break;
														case 3:
															if (Wiring.CheckMech(i, j, 300))
															{
																num100 = 185;
																int num114 = 200;
																for (int num115 = 0; num115 < 1000; num115++)
																{
																	if (Main.projectile[num115].active && Main.projectile[num115].type == num100)
																	{
																		float num116 = (new Vector2((float)(i * 16 + 8), (float)(j * 18 + 8)) - Main.projectile[num115].Center).Length();
																		if (num116 < 50f)
																		{
																			num114 -= 50;
																		}
																		else if (num116 < 100f)
																		{
																			num114 -= 15;
																		}
																		else if (num116 < 200f)
																		{
																			num114 -= 10;
																		}
																		else if (num116 < 300f)
																		{
																			num114 -= 8;
																		}
																		else if (num116 < 400f)
																		{
																			num114 -= 6;
																		}
																		else if (num116 < 500f)
																		{
																			num114 -= 5;
																		}
																		else if (num116 < 700f)
																		{
																			num114 -= 4;
																		}
																		else if (num116 < 900f)
																		{
																			num114 -= 3;
																		}
																		else if (num116 < 1200f)
																		{
																			num114 -= 2;
																		}
																		else
																		{
																			num114--;
																		}
																	}
																}
																if (num114 > 0)
																{
																	speedX = (float)Main.rand.Next(-20, 21) * 0.05f;
																	speedY = 4f + (float)Main.rand.Next(0, 21) * 0.05f;
																	damage2 = 40;
																	zero = new Vector2((float)(i * 16 + 8), (float)(j * 16 + 16));
																	zero.Y += 6f;
																	Projectile.NewProjectile((float)((int)zero.X), (float)((int)zero.Y), speedX, speedY, num100, damage2, 2f, Main.myPlayer, 0f, 0f);
																}
															}
															break;
														case 4:
															if (Wiring.CheckMech(i, j, 90))
															{
																speedX = 0f;
																speedY = 8f;
																damage2 = 60;
																num100 = 186;
																zero = new Vector2((float)(i * 16 + 8), (float)(j * 16 + 16));
																zero.Y += 10f;
															}
															break;
													}
													if (num100 != 0)
													{
														Projectile.NewProjectile((float)((int)zero.X), (float)((int)zero.Y), speedX, speedY, num100, damage2, 2f, Main.myPlayer, 0f, 0f);
														return;
													}
												}
												else if (type == 443)
												{
													int num117 = (int)(tile.frameX / 36);
													int num118 = i - ((int)tile.frameX - num117 * 36) / 18;
													if (Wiring.CheckMech(num118, j, 200))
													{
														Vector2 vector2 = Vector2.Zero;
														Vector2 zero2 = Vector2.Zero;
														int num119 = 654;
														int damage3 = 20;
														if (num117 < 2)
														{
															vector2 = new Vector2((float)(num118 + 1), (float)j) * 16f;
															zero2 = new Vector2(0f, -8f);
														}
														else
														{
															vector2 = new Vector2((float)(num118 + 1), (float)(j + 1)) * 16f;
															zero2 = new Vector2(0f, 8f);
														}
														if (num119 != 0)
														{
															Projectile.NewProjectile((float)((int)vector2.X), (float)((int)vector2.Y), zero2.X, zero2.Y, num119, damage3, 2f, Main.myPlayer, 0f, 0f);
															return;
														}
													}
												}
												else
												{
													if (type == 139 || type == 35)
													{
														WorldGen.SwitchMB(i, j);
														return;
													}
													if (type == 207)
													{
														WorldGen.SwitchFountain(i, j);
														return;
													}
													if (type == 410)
													{
														WorldGen.SwitchMonolith(i, j);
														return;
													}
													if (type == 455)
													{
														BirthdayParty.ToggleManualParty();
														return;
													}
													if (type == 141)
													{
														WorldGen.KillTile(i, j, false, false, true);
														NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
														Projectile.NewProjectile((float)(i * 16 + 8), (float)(j * 16 + 8), 0f, 0f, 108, 500, 10f, Main.myPlayer, 0f, 0f);
														return;
													}
													if (type == 210)
													{
														WorldGen.ExplodeMine(i, j);
														return;
													}
													if (type == 142 || type == 143)
													{
														int num120 = j - (int)(tile.frameY / 18);
														int num121 = (int)(tile.frameX / 18);
														if (num121 > 1)
														{
															num121 -= 2;
														}
														num121 = i - num121;
														Wiring.SkipWire(num121, num120);
														Wiring.SkipWire(num121, num120 + 1);
														Wiring.SkipWire(num121 + 1, num120);
														Wiring.SkipWire(num121 + 1, num120 + 1);
														if (type == 142)
														{
															for (int num122 = 0; num122 < 4; num122++)
															{
																if (Wiring._numInPump >= 19)
																{
																	return;
																}
																int num123;
																int num124;
																if (num122 == 0)
																{
																	num123 = num121;
																	num124 = num120 + 1;
																}
																else if (num122 == 1)
																{
																	num123 = num121 + 1;
																	num124 = num120 + 1;
																}
																else if (num122 == 2)
																{
																	num123 = num121;
																	num124 = num120;
																}
																else
																{
																	num123 = num121 + 1;
																	num124 = num120;
																}
																Wiring._inPumpX[Wiring._numInPump] = num123;
																Wiring._inPumpY[Wiring._numInPump] = num124;
																Wiring._numInPump++;
															}
															return;
														}
														for (int num125 = 0; num125 < 4; num125++)
														{
															if (Wiring._numOutPump >= 19)
															{
																return;
															}
															int num123;
															int num124;
															if (num125 == 0)
															{
																num123 = num121;
																num124 = num120 + 1;
															}
															else if (num125 == 1)
															{
																num123 = num121 + 1;
																num124 = num120 + 1;
															}
															else if (num125 == 2)
															{
																num123 = num121;
																num124 = num120;
															}
															else
															{
																num123 = num121 + 1;
																num124 = num120;
															}
															Wiring._outPumpX[Wiring._numOutPump] = num123;
															Wiring._outPumpY[Wiring._numOutPump] = num124;
															Wiring._numOutPump++;
														}
														return;
													}
													else if (type == 105)
													{
														int num126 = j - (int)(tile.frameY / 18);
														int num127 = (int)(tile.frameX / 18);
														int num128 = 0;
														while (num127 >= 2)
														{
															num127 -= 2;
															num128++;
														}
														num127 = i - num127;
														num127 = i - (int)(tile.frameX % 36 / 18);
														num126 = j - (int)(tile.frameY % 54 / 18);
														num128 = (int)(tile.frameX / 36 + tile.frameY / 54 * 55);
														Wiring.SkipWire(num127, num126);
														Wiring.SkipWire(num127, num126 + 1);
														Wiring.SkipWire(num127, num126 + 2);
														Wiring.SkipWire(num127 + 1, num126);
														Wiring.SkipWire(num127 + 1, num126 + 1);
														Wiring.SkipWire(num127 + 1, num126 + 2);
														int num129 = num127 * 16 + 16;
														int num130 = (num126 + 3) * 16;
														int num131 = -1;
														int num132 = -1;
														bool flag11 = true;
														bool flag12 = false;
														switch (num128)
														{
															case 51:
																num132 = (int)Utils.SelectRandom<short>(Main.rand, new short[]
																{
																299,
																538
																});
																break;
															case 52:
																num132 = 356;
																break;
															case 53:
																num132 = 357;
																break;
															case 54:
																num132 = (int)Utils.SelectRandom<short>(Main.rand, new short[]
																{
																355,
																358
																});
																break;
															case 55:
																num132 = (int)Utils.SelectRandom<short>(Main.rand, new short[]
																{
																367,
																366
																});
																break;
															case 56:
																num132 = (int)Utils.SelectRandom<short>(Main.rand, new short[]
																{
																359,
																359,
																359,
																359,
																360
																});
																break;
															case 57:
																num132 = 377;
																break;
															case 58:
																num132 = 300;
																break;
															case 59:
																num132 = (int)Utils.SelectRandom<short>(Main.rand, new short[]
																{
																364,
																362
																});
																break;
															case 60:
																num132 = 148;
																break;
															case 61:
																num132 = 361;
																break;
															case 62:
																num132 = (int)Utils.SelectRandom<short>(Main.rand, new short[]
																{
																487,
																486,
																485
																});
																break;
															case 63:
																num132 = 164;
																flag11 &= NPC.MechSpawn((float)num129, (float)num130, 165);
																break;
															case 64:
																num132 = 86;
																flag12 = true;
																break;
															case 65:
																num132 = 490;
																break;
															case 66:
																num132 = 82;
																break;
															case 67:
																num132 = 449;
																break;
															case 68:
																num132 = 167;
																break;
															case 69:
																num132 = 480;
																break;
															case 70:
																num132 = 48;
																break;
															case 71:
																num132 = (int)Utils.SelectRandom<short>(Main.rand, new short[]
																{
																170,
																180,
																171
																});
																flag12 = true;
																break;
															case 72:
																num132 = 481;
																break;
															case 73:
																num132 = 482;
																break;
															case 74:
																num132 = 430;
																break;
															case 75:
																num132 = 489;
																break;
														}
														if ((num132 != -1 && Wiring.CheckMech(num127, num126, 30) && NPC.MechSpawn((float)num129, (float)num130, num132)) & flag11)
														{
															if (!flag12 || !Collision.SolidTiles(num127 - 2, num127 + 3, num126, num126 + 2))
															{
																num131 = NPC.NewNPC(num129, num130 - 12, num132, 0, 0f, 0f, 0f, 0f, 255);
															}
															else
															{
																Vector2 vector3 = new Vector2((float)(num129 - 4), (float)(num130 - 22)) - new Vector2(10f);
																Utils.PoofOfSmoke(vector3);
																NetMessage.SendData(106, -1, -1, null, (int)vector3.X, vector3.Y, 0f, 0f, 0, 0, 0);
															}
														}
														if (num131 <= -1)
														{
															if (num128 == 4)
															{
																if (Wiring.CheckMech(num127, num126, 30) && NPC.MechSpawn((float)num129, (float)num130, 1))
																{
																	num131 = NPC.NewNPC(num129, num130 - 12, 1, 0, 0f, 0f, 0f, 0f, 255);
																}
															}
															else if (num128 == 7)
															{
																if (Wiring.CheckMech(num127, num126, 30) && NPC.MechSpawn((float)num129, (float)num130, 49))
																{
																	num131 = NPC.NewNPC(num129 - 4, num130 - 6, 49, 0, 0f, 0f, 0f, 0f, 255);
																}
															}
															else if (num128 == 8)
															{
																if (Wiring.CheckMech(num127, num126, 30) && NPC.MechSpawn((float)num129, (float)num130, 55))
																{
																	num131 = NPC.NewNPC(num129, num130 - 12, 55, 0, 0f, 0f, 0f, 0f, 255);
																}
															}
															else if (num128 == 9)
															{
																if (Wiring.CheckMech(num127, num126, 30) && NPC.MechSpawn((float)num129, (float)num130, 46))
																{
																	num131 = NPC.NewNPC(num129, num130 - 12, 46, 0, 0f, 0f, 0f, 0f, 255);
																}
															}
															else if (num128 == 10)
															{
																if (Wiring.CheckMech(num127, num126, 30) && NPC.MechSpawn((float)num129, (float)num130, 21))
																{
																	num131 = NPC.NewNPC(num129, num130, 21, 0, 0f, 0f, 0f, 0f, 255);
																}
															}
															else if (num128 == 18)
															{
																if (Wiring.CheckMech(num127, num126, 30) && NPC.MechSpawn((float)num129, (float)num130, 67))
																{
																	num131 = NPC.NewNPC(num129, num130 - 12, 67, 0, 0f, 0f, 0f, 0f, 255);
																}
															}
															else if (num128 == 23)
															{
																if (Wiring.CheckMech(num127, num126, 30) && NPC.MechSpawn((float)num129, (float)num130, 63))
																{
																	num131 = NPC.NewNPC(num129, num130 - 12, 63, 0, 0f, 0f, 0f, 0f, 255);
																}
															}
															else if (num128 == 27)
															{
																if (Wiring.CheckMech(num127, num126, 30) && NPC.MechSpawn((float)num129, (float)num130, 85))
																{
																	num131 = NPC.NewNPC(num129 - 9, num130, 85, 0, 0f, 0f, 0f, 0f, 255);
																}
															}
															else if (num128 == 28)
															{
																if (Wiring.CheckMech(num127, num126, 30) && NPC.MechSpawn((float)num129, (float)num130, 74))
																{
																	num131 = NPC.NewNPC(num129, num130 - 12, (int)Utils.SelectRandom<short>(Main.rand, new short[]
																	{
																		74,
																		297,
																		298
																	}), 0, 0f, 0f, 0f, 0f, 255);
																}
															}
															else if (num128 == 34)
															{
																for (int num133 = 0; num133 < 2; num133++)
																{
																	for (int num134 = 0; num134 < 3; num134++)
																	{
																		Tile expr_2731 = Main.tile[num127 + num133, num126 + num134];
																		expr_2731.type = 349;
																		expr_2731.frameX = (short)(num133 * 18 + 216);
																		expr_2731.frameY = (short)(num134 * 18);
																	}
																}
																Animation.NewTemporaryAnimation(0, 349, num127, num126);
																if (Main.netMode == 2)
																{
																	NetMessage.SendTileRange(-1, num127, num126, 2, 3, TileChangeType.None);
																}
															}
															else if (num128 == 42)
															{
																if (Wiring.CheckMech(num127, num126, 30) && NPC.MechSpawn((float)num129, (float)num130, 58))
																{
																	num131 = NPC.NewNPC(num129, num130 - 12, 58, 0, 0f, 0f, 0f, 0f, 255);
																}
															}
															else if (num128 == 37)
															{
																if (Wiring.CheckMech(num127, num126, 600) && Item.MechSpawn((float)num129, (float)num130, 58) && Item.MechSpawn((float)num129, (float)num130, 1734) && Item.MechSpawn((float)num129, (float)num130, 1867))
																{
																	Item.NewItem(num129, num130 - 16, 0, 0, 58, 1, false, 0, false, false);
																}
															}
															else if (num128 == 50)
															{
																if (Wiring.CheckMech(num127, num126, 30) && NPC.MechSpawn((float)num129, (float)num130, 65))
																{
																	if (!Collision.SolidTiles(num127 - 2, num127 + 3, num126, num126 + 2))
																	{
																		num131 = NPC.NewNPC(num129, num130 - 12, 65, 0, 0f, 0f, 0f, 0f, 255);
																	}
																	else
																	{
																		Vector2 vector4 = new Vector2((float)(num129 - 4), (float)(num130 - 22)) - new Vector2(10f);
																		Utils.PoofOfSmoke(vector4);
																		NetMessage.SendData(106, -1, -1, null, (int)vector4.X, vector4.Y, 0f, 0f, 0, 0, 0);
																	}
																}
															}
															else if (num128 == 2)
															{
																if (Wiring.CheckMech(num127, num126, 600) && Item.MechSpawn((float)num129, (float)num130, 184) && Item.MechSpawn((float)num129, (float)num130, 1735) && Item.MechSpawn((float)num129, (float)num130, 1868))
																{
																	Item.NewItem(num129, num130 - 16, 0, 0, 184, 1, false, 0, false, false);
																}
															}
															else if (num128 == 17)
															{
																if (Wiring.CheckMech(num127, num126, 600) && Item.MechSpawn((float)num129, (float)num130, 166))
																{
																	Item.NewItem(num129, num130 - 20, 0, 0, 166, 1, false, 0, false, false);
																}
															}
															else if (num128 == 40)
															{
																if (Wiring.CheckMech(num127, num126, 300))
																{
																	int[] array = new int[10];
																	int num135 = 0;
																	for (int num136 = 0; num136 < 200; num136++)
																	{
																		if (Main.npc[num136].active && (Main.npc[num136].type == 17 || Main.npc[num136].type == 19 || Main.npc[num136].type == 22 || Main.npc[num136].type == 38 || Main.npc[num136].type == 54 || Main.npc[num136].type == 107 || Main.npc[num136].type == 108 || Main.npc[num136].type == 142 || Main.npc[num136].type == 160 || Main.npc[num136].type == 207 || Main.npc[num136].type == 209 || Main.npc[num136].type == 227 || Main.npc[num136].type == 228 || Main.npc[num136].type == 229 || Main.npc[num136].type == 358 || Main.npc[num136].type == 369 || Main.npc[num136].type == 550))
																		{
																			array[num135] = num136;
																			num135++;
																			if (num135 >= 9)
																			{
																				break;
																			}
																		}
																	}
																	if (num135 > 0)
																	{
																		int num137 = array[Main.rand.Next(num135)];
																		Main.npc[num137].position.X = (float)(num129 - Main.npc[num137].width / 2);
																		Main.npc[num137].position.Y = (float)(num130 - Main.npc[num137].height - 1);
																		NetMessage.SendData(23, -1, -1, null, num137, 0f, 0f, 0f, 0, 0, 0);
																	}
																}
															}
															else if (num128 == 41 && Wiring.CheckMech(num127, num126, 300))
															{
																int[] array2 = new int[10];
																int num138 = 0;
																for (int num139 = 0; num139 < 200; num139++)
																{
																	if (Main.npc[num139].active && (Main.npc[num139].type == 18 || Main.npc[num139].type == 20 || Main.npc[num139].type == 124 || Main.npc[num139].type == 178 || Main.npc[num139].type == 208 || Main.npc[num139].type == 353))
																	{
																		array2[num138] = num139;
																		num138++;
																		if (num138 >= 9)
																		{
																			break;
																		}
																	}
																}
																if (num138 > 0)
																{
																	int num140 = array2[Main.rand.Next(num138)];
																	Main.npc[num140].position.X = (float)(num129 - Main.npc[num140].width / 2);
																	Main.npc[num140].position.Y = (float)(num130 - Main.npc[num140].height - 1);
																	NetMessage.SendData(23, -1, -1, null, num140, 0f, 0f, 0f, 0, 0, 0);
																}
															}
														}
														if (num131 >= 0)
														{
															Main.npc[num131].value = 0f;
															Main.npc[num131].npcSlots = 0f;
															Main.npc[num131].SpawnedFromStatue = true;
															return;
														}
													}
													else if (type == 349)
													{
														int num141 = j - (int)(tile.frameY / 18);
														int num142;
														for (num142 = (int)(tile.frameX / 18); num142 >= 2; num142 -= 2)
														{
														}
														num142 = i - num142;
														Wiring.SkipWire(num142, num141);
														Wiring.SkipWire(num142, num141 + 1);
														Wiring.SkipWire(num142, num141 + 2);
														Wiring.SkipWire(num142 + 1, num141);
														Wiring.SkipWire(num142 + 1, num141 + 1);
														Wiring.SkipWire(num142 + 1, num141 + 2);
														short num143;
														if (Main.tile[num142, num141].frameX == 0)
														{
															num143 = 216;
														}
														else
														{
															num143 = -216;
														}
														for (int num144 = 0; num144 < 2; num144++)
														{
															for (int num145 = 0; num145 < 3; num145++)
															{
																Tile expr_2E7B = Main.tile[num142 + num144, num141 + num145];
																expr_2E7B.frameX += num143;
															}
														}
														if (Main.netMode == 2)
														{
															NetMessage.SendTileRange(-1, num142, num141, 2, 3, TileChangeType.None);
														}
														Animation.NewTemporaryAnimation((num143 > 0) ? 0 : 1, 349, num142, num141);
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x003491B8 File Offset: 0x003473B8
		public static void Initialize()
		{
			Wiring._wireSkip = new Dictionary<Point16, bool>();
			Wiring._wireList = new DoubleStack<Point16>(1024, 0);
			Wiring._wireDirectionList = new DoubleStack<byte>(1024, 0);
			Wiring._toProcess = new Dictionary<Point16, byte>();
			Wiring._GatesCurrent = new Queue<Point16>();
			Wiring._GatesNext = new Queue<Point16>();
			Wiring._GatesDone = new Dictionary<Point16, bool>();
			Wiring._LampsToCheck = new Queue<Point16>();
			Wiring._PixelBoxTriggers = new Dictionary<Point16, byte>();
			Wiring._inPumpX = new int[20];
			Wiring._inPumpY = new int[20];
			Wiring._outPumpX = new int[20];
			Wiring._outPumpY = new int[20];
			Wiring._teleport = new Vector2[2];
			Wiring._mechX = new int[1000];
			Wiring._mechY = new int[1000];
			Wiring._mechTime = new int[1000];
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x0034A490 File Offset: 0x00348690
		private static void LogicGatePass()
		{
			if (Wiring._GatesCurrent.Count == 0)
			{
				Wiring._GatesDone.Clear();
				while (Wiring._LampsToCheck.Count > 0)
				{
					while (Wiring._LampsToCheck.Count > 0)
					{
						Point16 point = Wiring._LampsToCheck.Dequeue();
						Wiring.CheckLogicGate((int)point.X, (int)point.Y);
					}
					while (Wiring._GatesNext.Count > 0)
					{
						Utils.Swap<Queue<Point16>>(ref Wiring._GatesCurrent, ref Wiring._GatesNext);
						while (Wiring._GatesCurrent.Count > 0)
						{
							Point16 point2 = Wiring._GatesCurrent.Peek();
							bool flag;
							if (Wiring._GatesDone.TryGetValue(point2, out flag) && flag)
							{
								Wiring._GatesCurrent.Dequeue();
							}
							else
							{
								Wiring._GatesDone.Add(point2, true);
								Wiring.TripWire((int)point2.X, (int)point2.Y, 1, 1);
								Wiring._GatesCurrent.Dequeue();
							}
						}
					}
				}
				Wiring._GatesDone.Clear();
				if (Wiring.blockPlayerTeleportationForOneIteration)
				{
					Wiring.blockPlayerTeleportationForOneIteration = false;
				}
			}
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x00349AA4 File Offset: 0x00347CA4
		public static void MassWireOperation(Point ps, Point pe, Player master)
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < 58; i++)
			{
				if (master.inventory[i].type == 530)
				{
					num += master.inventory[i].stack;
				}
				if (master.inventory[i].type == 849)
				{
					num2 += master.inventory[i].stack;
				}
			}
			int arg_7F_0 = num;
			int num3 = num2;
			Wiring.MassWireOperationInner(ps, pe, master.Center, master.direction == 1, ref num, ref num2);
			int num4 = arg_7F_0 - num;
			int num5 = num3 - num2;
			if (Main.netMode == 2)
			{
				NetMessage.SendData(110, master.whoAmI, -1, null, 530, (float)num4, (float)master.whoAmI, 0f, 0, 0, 0);
				NetMessage.SendData(110, master.whoAmI, -1, null, 849, (float)num5, (float)master.whoAmI, 0f, 0, 0, 0);
				return;
			}
			for (int j = 0; j < num4; j++)
			{
				master.ConsumeItem(530, false);
			}
			for (int k = 0; k < num5; k++)
			{
				master.ConsumeItem(849, false);
			}
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x0034DFD4 File Offset: 0x0034C1D4
		private static void MassWireOperationInner(Point ps, Point pe, Vector2 dropPoint, bool dir, ref int wireCount, ref int actuatorCount)
		{
			Math.Abs(ps.X - pe.X);
			Math.Abs(ps.Y - pe.Y);
			int num = Math.Sign(pe.X - ps.X);
			int num2 = Math.Sign(pe.Y - ps.Y);
			WiresUI.Settings.MultiToolMode toolMode = WiresUI.Settings.ToolMode;
			Point pt = default(Point);
			bool flag = false;
			Item.StartCachingType(530);
			Item.StartCachingType(849);
			int num3;
			int num4;
			int num5;
			if (dir)
			{
				pt.X = ps.X;
				num3 = ps.Y;
				num4 = pe.Y;
				num5 = num2;
			}
			else
			{
				pt.Y = ps.Y;
				num3 = ps.X;
				num4 = pe.X;
				num5 = num;
			}
			int num6 = num3;
			while (num6 != num4 && !flag)
			{
				if (dir)
				{
					pt.Y = num6;
				}
				else
				{
					pt.X = num6;
				}
				bool? flag2 = Wiring.MassWireOperationStep(pt, toolMode, ref wireCount, ref actuatorCount);
				if (flag2.HasValue && !flag2.Value)
				{
					flag = true;
					break;
				}
				num6 += num5;
			}
			if (dir)
			{
				pt.Y = pe.Y;
				num3 = ps.X;
				num4 = pe.X;
				num5 = num;
			}
			else
			{
				pt.X = pe.X;
				num3 = ps.Y;
				num4 = pe.Y;
				num5 = num2;
			}
			int num7 = num3;
			while (num7 != num4 && !flag)
			{
				if (!dir)
				{
					pt.Y = num7;
				}
				else
				{
					pt.X = num7;
				}
				bool? flag3 = Wiring.MassWireOperationStep(pt, toolMode, ref wireCount, ref actuatorCount);
				if (flag3.HasValue && !flag3.Value)
				{
					flag = true;
					break;
				}
				num7 += num5;
			}
			if (!flag)
			{
				Wiring.MassWireOperationStep(pe, toolMode, ref wireCount, ref actuatorCount);
			}
			Item.DropCache(dropPoint, Vector2.Zero, 530, true);
			Item.DropCache(dropPoint, Vector2.Zero, 849, true);
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x0034E1BC File Offset: 0x0034C3BC
		private static bool? MassWireOperationStep(Point pt, WiresUI.Settings.MultiToolMode mode, ref int wiresLeftToConsume, ref int actuatorsLeftToConstume)
		{
			if (!WorldGen.InWorld(pt.X, pt.Y, 1))
			{
				return null;
			}
			Tile tile = Main.tile[pt.X, pt.Y];
			if (tile == null)
			{
				return null;
			}
			if (!mode.HasFlag(WiresUI.Settings.MultiToolMode.Cutter))
			{
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Red) && !tile.wire())
				{
					if (wiresLeftToConsume <= 0)
					{
						return new bool?(false);
					}
					wiresLeftToConsume--;
					WorldGen.PlaceWire(pt.X, pt.Y);
					NetMessage.SendData(17, -1, -1, null, 5, (float)pt.X, (float)pt.Y, 0f, 0, 0, 0);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Green) && !tile.wire3())
				{
					if (wiresLeftToConsume <= 0)
					{
						return new bool?(false);
					}
					wiresLeftToConsume--;
					WorldGen.PlaceWire3(pt.X, pt.Y);
					NetMessage.SendData(17, -1, -1, null, 12, (float)pt.X, (float)pt.Y, 0f, 0, 0, 0);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Blue) && !tile.wire2())
				{
					if (wiresLeftToConsume <= 0)
					{
						return new bool?(false);
					}
					wiresLeftToConsume--;
					WorldGen.PlaceWire2(pt.X, pt.Y);
					NetMessage.SendData(17, -1, -1, null, 10, (float)pt.X, (float)pt.Y, 0f, 0, 0, 0);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Yellow) && !tile.wire4())
				{
					if (wiresLeftToConsume <= 0)
					{
						return new bool?(false);
					}
					wiresLeftToConsume--;
					WorldGen.PlaceWire4(pt.X, pt.Y);
					NetMessage.SendData(17, -1, -1, null, 16, (float)pt.X, (float)pt.Y, 0f, 0, 0, 0);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Actuator) && !tile.actuator())
				{
					if (actuatorsLeftToConstume <= 0)
					{
						return new bool?(false);
					}
					actuatorsLeftToConstume--;
					WorldGen.PlaceActuator(pt.X, pt.Y);
					NetMessage.SendData(17, -1, -1, null, 8, (float)pt.X, (float)pt.Y, 0f, 0, 0, 0);
				}
			}
			if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Cutter))
			{
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Red) && tile.wire() && WorldGen.KillWire(pt.X, pt.Y))
				{
					NetMessage.SendData(17, -1, -1, null, 6, (float)pt.X, (float)pt.Y, 0f, 0, 0, 0);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Green) && tile.wire3() && WorldGen.KillWire3(pt.X, pt.Y))
				{
					NetMessage.SendData(17, -1, -1, null, 13, (float)pt.X, (float)pt.Y, 0f, 0, 0, 0);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Blue) && tile.wire2() && WorldGen.KillWire2(pt.X, pt.Y))
				{
					NetMessage.SendData(17, -1, -1, null, 11, (float)pt.X, (float)pt.Y, 0f, 0, 0, 0);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Yellow) && tile.wire4() && WorldGen.KillWire4(pt.X, pt.Y))
				{
					NetMessage.SendData(17, -1, -1, null, 17, (float)pt.X, (float)pt.Y, 0f, 0, 0, 0);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Actuator) && tile.actuator() && WorldGen.KillActuator(pt.X, pt.Y))
				{
					NetMessage.SendData(17, -1, -1, null, 9, (float)pt.X, (float)pt.Y, 0f, 0, 0, 0);
				}
			}
			return new bool?(true);
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x0034A31C File Offset: 0x0034851C
		private static void PixelBoxPass()
		{
			foreach (KeyValuePair<Point16, byte> current in Wiring._PixelBoxTriggers)
			{
				if (current.Value != 2)
				{
					if (current.Value == 1)
					{
						if (Main.tile[(int)current.Key.X, (int)current.Key.Y].frameX != 0)
						{
							Main.tile[(int)current.Key.X, (int)current.Key.Y].frameX = 0;
							NetMessage.SendTileSquare(-1, (int)current.Key.X, (int)current.Key.Y, 1, TileChangeType.None);
						}
					}
					else if (current.Value == 3 && Main.tile[(int)current.Key.X, (int)current.Key.Y].frameX != 18)
					{
						Main.tile[(int)current.Key.X, (int)current.Key.Y].frameX = 18;
						NetMessage.SendTileSquare(-1, (int)current.Key.X, (int)current.Key.Y, 1, TileChangeType.None);
					}
				}
			}
			Wiring._PixelBoxTriggers.Clear();
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x003499AF File Offset: 0x00347BAF
		public static void PokeLogicGate(int lampX, int lampY)
		{
			if (Main.netMode == 1)
			{
				return;
			}
			Wiring._LampsToCheck.Enqueue(new Point16(lampX, lampY));
			Wiring.LogicGatePass();
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x0034DFA4 File Offset: 0x0034C1A4
		private static void ReActive(int i, int j)
		{
			Main.tile[i, j].inActive(false);
			WorldGen.SquareTileFrame(i, j, false);
			if (Main.netMode != 1)
			{
				NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
			}
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x0034918C File Offset: 0x0034738C
		public static void SetCurrentUser(int plr = -1)
		{
			if (plr < 0 || plr >= 255)
			{
				plr = 254;
			}
			if (Main.netMode == 0)
			{
				plr = Main.myPlayer;
			}
			Wiring.CurrentUser = plr;
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x003492A7 File Offset: 0x003474A7
		public static void SkipWire(Point16 point)
		{
			Wiring._wireSkip[point] = true;
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x00349293 File Offset: 0x00347493
		public static void SkipWire(int x, int y)
		{
			Wiring._wireSkip[new Point16(x, y)] = true;
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x0034DA48 File Offset: 0x0034BC48
		private static void Teleport()
		{
			if (Wiring._teleport[0].X < Wiring._teleport[1].X + 3f && Wiring._teleport[0].X > Wiring._teleport[1].X - 3f && Wiring._teleport[0].Y > Wiring._teleport[1].Y - 3f && Wiring._teleport[0].Y < Wiring._teleport[1].Y)
			{
				return;
			}
			Rectangle[] array = new Rectangle[2];
			array[0].X = (int)(Wiring._teleport[0].X * 16f);
			array[0].Width = 48;
			array[0].Height = 48;
			array[0].Y = (int)(Wiring._teleport[0].Y * 16f - (float)array[0].Height);
			array[1].X = (int)(Wiring._teleport[1].X * 16f);
			array[1].Width = 48;
			array[1].Height = 48;
			array[1].Y = (int)(Wiring._teleport[1].Y * 16f - (float)array[1].Height);
			for (int i = 0; i < 2; i++)
			{
				Vector2 value = new Vector2((float)(array[1].X - array[0].X), (float)(array[1].Y - array[0].Y));
				if (i == 1)
				{
					value = new Vector2((float)(array[0].X - array[1].X), (float)(array[0].Y - array[1].Y));
				}
				if (!Wiring.blockPlayerTeleportationForOneIteration)
				{
					for (int j = 0; j < 255; j++)
					{
						if (Main.player[j].active && !Main.player[j].dead && !Main.player[j].teleporting && array[i].Intersects(Main.player[j].getRect()))
						{
							Vector2 vector = Main.player[j].position + value;
							Main.player[j].teleporting = true;
							if (Main.netMode == 2)
							{
								RemoteClient.CheckSection(j, vector, 1);
							}
							Main.player[j].Teleport(vector, 0, 0);
							if (Main.netMode == 2)
							{
								NetMessage.SendData(65, -1, -1, null, 0, (float)j, vector.X, vector.Y, 0, 0, 0);
							}
						}
					}
				}
				for (int k = 0; k < 200; k++)
				{
					if (Main.npc[k].active && !Main.npc[k].teleporting && Main.npc[k].lifeMax > 5 && !Main.npc[k].boss && !Main.npc[k].noTileCollide)
					{
						int type = Main.npc[k].type;
						if (!NPCID.Sets.TeleportationImmune[type] && array[i].Intersects(Main.npc[k].getRect()))
						{
							Main.npc[k].teleporting = true;
							Main.npc[k].Teleport(Main.npc[k].position + value, 0, 0);
						}
					}
				}
			}
			for (int l = 0; l < 255; l++)
			{
				Main.player[l].teleporting = false;
			}
			for (int m = 0; m < 200; m++)
			{
				Main.npc[m].teleporting = false;
			}
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x00349E18 File Offset: 0x00348018
		private static void TripWire(int left, int top, int width, int height)
		{
			if (Main.netMode == 1)
			{
				return;
			}
			Wiring.running = true;
			if (Wiring._wireList.Count != 0)
			{
				Wiring._wireList.Clear(true);
			}
			if (Wiring._wireDirectionList.Count != 0)
			{
				Wiring._wireDirectionList.Clear(true);
			}
			Vector2[] array = new Vector2[8];
			int num = 0;
			for (int i = left; i < left + width; i++)
			{
				for (int j = top; j < top + height; j++)
				{
					Point16 back = new Point16(i, j);
					Tile tile = Main.tile[i, j];
					if (tile != null && tile.wire())
					{
						Wiring._wireList.PushBack(back);
					}
				}
			}
			Wiring._teleport[0].X = -1f;
			Wiring._teleport[0].Y = -1f;
			Wiring._teleport[1].X = -1f;
			Wiring._teleport[1].Y = -1f;
			if (Wiring._wireList.Count > 0)
			{
				Wiring._numInPump = 0;
				Wiring._numOutPump = 0;
				Wiring.HitWire(Wiring._wireList, 1);
				if (Wiring._numInPump > 0 && Wiring._numOutPump > 0)
				{
					Wiring.XferWater();
				}
			}
			array[num++] = Wiring._teleport[0];
			array[num++] = Wiring._teleport[1];
			for (int k = left; k < left + width; k++)
			{
				for (int l = top; l < top + height; l++)
				{
					Point16 back = new Point16(k, l);
					Tile tile2 = Main.tile[k, l];
					if (tile2 != null && tile2.wire2())
					{
						Wiring._wireList.PushBack(back);
					}
				}
			}
			Wiring._teleport[0].X = -1f;
			Wiring._teleport[0].Y = -1f;
			Wiring._teleport[1].X = -1f;
			Wiring._teleport[1].Y = -1f;
			if (Wiring._wireList.Count > 0)
			{
				Wiring._numInPump = 0;
				Wiring._numOutPump = 0;
				Wiring.HitWire(Wiring._wireList, 2);
				if (Wiring._numInPump > 0 && Wiring._numOutPump > 0)
				{
					Wiring.XferWater();
				}
			}
			array[num++] = Wiring._teleport[0];
			array[num++] = Wiring._teleport[1];
			Wiring._teleport[0].X = -1f;
			Wiring._teleport[0].Y = -1f;
			Wiring._teleport[1].X = -1f;
			Wiring._teleport[1].Y = -1f;
			for (int m = left; m < left + width; m++)
			{
				for (int n = top; n < top + height; n++)
				{
					Point16 back = new Point16(m, n);
					Tile tile3 = Main.tile[m, n];
					if (tile3 != null && tile3.wire3())
					{
						Wiring._wireList.PushBack(back);
					}
				}
			}
			if (Wiring._wireList.Count > 0)
			{
				Wiring._numInPump = 0;
				Wiring._numOutPump = 0;
				Wiring.HitWire(Wiring._wireList, 3);
				if (Wiring._numInPump > 0 && Wiring._numOutPump > 0)
				{
					Wiring.XferWater();
				}
			}
			array[num++] = Wiring._teleport[0];
			array[num++] = Wiring._teleport[1];
			Wiring._teleport[0].X = -1f;
			Wiring._teleport[0].Y = -1f;
			Wiring._teleport[1].X = -1f;
			Wiring._teleport[1].Y = -1f;
			for (int num2 = left; num2 < left + width; num2++)
			{
				for (int num3 = top; num3 < top + height; num3++)
				{
					Point16 back = new Point16(num2, num3);
					Tile tile4 = Main.tile[num2, num3];
					if (tile4 != null && tile4.wire4())
					{
						Wiring._wireList.PushBack(back);
					}
				}
			}
			if (Wiring._wireList.Count > 0)
			{
				Wiring._numInPump = 0;
				Wiring._numOutPump = 0;
				Wiring.HitWire(Wiring._wireList, 4);
				if (Wiring._numInPump > 0 && Wiring._numOutPump > 0)
				{
					Wiring.XferWater();
				}
			}
			array[num++] = Wiring._teleport[0];
			array[num++] = Wiring._teleport[1];
			for (int num4 = 0; num4 < 8; num4 += 2)
			{
				Wiring._teleport[0] = array[num4];
				Wiring._teleport[1] = array[num4 + 1];
				if (Wiring._teleport[0].X >= 0f && Wiring._teleport[1].X >= 0f)
				{
					Wiring.Teleport();
				}
			}
			Wiring.PixelBoxPass();
			Wiring.LogicGatePass();
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x003492B8 File Offset: 0x003474B8
		public static void UpdateMech()
		{
			Wiring.SetCurrentUser(-1);
			for (int i = Wiring._numMechs - 1; i >= 0; i--)
			{
				Wiring._mechTime[i]--;
				if (Main.tile[Wiring._mechX[i], Wiring._mechY[i]].active() && Main.tile[Wiring._mechX[i], Wiring._mechY[i]].type == 144)
				{
					if (Main.tile[Wiring._mechX[i], Wiring._mechY[i]].frameY == 0)
					{
						Wiring._mechTime[i] = 0;
					}
					else
					{
						int num = (int)(Main.tile[Wiring._mechX[i], Wiring._mechY[i]].frameX / 18);
						if (num == 0)
						{
							num = 60;
						}
						else if (num == 1)
						{
							num = 180;
						}
						else if (num == 2)
						{
							num = 300;
						}
						if (Math.IEEERemainder((double)Wiring._mechTime[i], (double)num) == 0.0)
						{
							Wiring._mechTime[i] = 18000;
							Wiring.TripWire(Wiring._mechX[i], Wiring._mechY[i], 1, 1);
						}
					}
				}
				if (Wiring._mechTime[i] <= 0)
				{
					if (Main.tile[Wiring._mechX[i], Wiring._mechY[i]].active() && Main.tile[Wiring._mechX[i], Wiring._mechY[i]].type == 144)
					{
						Main.tile[Wiring._mechX[i], Wiring._mechY[i]].frameY = 0;
						NetMessage.SendTileSquare(-1, Wiring._mechX[i], Wiring._mechY[i], 1, TileChangeType.None);
					}
					if (Main.tile[Wiring._mechX[i], Wiring._mechY[i]].active() && Main.tile[Wiring._mechX[i], Wiring._mechY[i]].type == 411)
					{
						Tile expr_1F4 = Main.tile[Wiring._mechX[i], Wiring._mechY[i]];
						int num2 = (int)(expr_1F4.frameX % 36 / 18);
						int num3 = (int)(expr_1F4.frameY % 36 / 18);
						int num4 = Wiring._mechX[i] - num2;
						int num5 = Wiring._mechY[i] - num3;
						int num6 = 36;
						if (Main.tile[num4, num5].frameX >= 36)
						{
							num6 = -36;
						}
						for (int j = num4; j < num4 + 2; j++)
						{
							for (int k = num5; k < num5 + 2; k++)
							{
								Main.tile[j, k].frameX = (short)((int)Main.tile[j, k].frameX + num6);
							}
						}
						NetMessage.SendTileSquare(-1, num4, num5, 2, TileChangeType.None);
					}
					for (int l = i; l < Wiring._numMechs; l++)
					{
						Wiring._mechX[l] = Wiring._mechX[l + 1];
						Wiring._mechY[l] = Wiring._mechY[l + 1];
						Wiring._mechTime[l] = Wiring._mechTime[l + 1];
					}
					Wiring._numMechs--;
				}
			}
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x00349C3C File Offset: 0x00347E3C
		private static void XferWater()
		{
			for (int i = 0; i < Wiring._numInPump; i++)
			{
				int num = Wiring._inPumpX[i];
				int num2 = Wiring._inPumpY[i];
				int liquid = (int)Main.tile[num, num2].liquid;
				if (liquid > 0)
				{
					bool flag = Main.tile[num, num2].lava();
					bool flag2 = Main.tile[num, num2].honey();
					for (int j = 0; j < Wiring._numOutPump; j++)
					{
						int num3 = Wiring._outPumpX[j];
						int num4 = Wiring._outPumpY[j];
						int liquid2 = (int)Main.tile[num3, num4].liquid;
						if (liquid2 < 255)
						{
							bool flag3 = Main.tile[num3, num4].lava();
							bool flag4 = Main.tile[num3, num4].honey();
							if (liquid2 == 0)
							{
								flag3 = flag;
								flag4 = flag2;
							}
							if (flag == flag3 && flag2 == flag4)
							{
								int num5 = liquid;
								if (num5 + liquid2 > 255)
								{
									num5 = 255 - liquid2;
								}
								Tile expr_102 = Main.tile[num3, num4];
								expr_102.liquid += (byte)num5;
								Tile expr_11E = Main.tile[num, num2];
								expr_11E.liquid -= (byte)num5;
								liquid = (int)Main.tile[num, num2].liquid;
								Main.tile[num3, num4].lava(flag);
								Main.tile[num3, num4].honey(flag2);
								WorldGen.SquareTileFrame(num3, num4, true);
								if (Main.tile[num, num2].liquid == 0)
								{
									Main.tile[num, num2].lava(false);
									WorldGen.SquareTileFrame(num, num2, true);
									break;
								}
							}
						}
					}
					WorldGen.SquareTileFrame(num, num2, true);
				}
			}
		}

		// Token: 0x04000C37 RID: 3127
		public static bool blockPlayerTeleportationForOneIteration;

		// Token: 0x04000C50 RID: 3152
		private static int CurrentUser = 254;

		// Token: 0x04000C4A RID: 3146
		private const int MaxMech = 1000;

		// Token: 0x04000C43 RID: 3139
		private const int MaxPump = 20;

		// Token: 0x04000C38 RID: 3128
		public static bool running;

		// Token: 0x04000C4F RID: 3151
		private static int _currentWireColor;

		// Token: 0x04000C3D RID: 3133
		private static Queue<Point16> _GatesCurrent;

		// Token: 0x04000C40 RID: 3136
		private static Dictionary<Point16, bool> _GatesDone;

		// Token: 0x04000C3F RID: 3135
		private static Queue<Point16> _GatesNext;

		// Token: 0x04000C44 RID: 3140
		private static int[] _inPumpX;

		// Token: 0x04000C45 RID: 3141
		private static int[] _inPumpY;

		// Token: 0x04000C3E RID: 3134
		private static Queue<Point16> _LampsToCheck;

		// Token: 0x04000C4E RID: 3150
		private static int[] _mechTime;

		// Token: 0x04000C4B RID: 3147
		private static int[] _mechX;

		// Token: 0x04000C4C RID: 3148
		private static int[] _mechY;

		// Token: 0x04000C46 RID: 3142
		private static int _numInPump;

		// Token: 0x04000C4D RID: 3149
		private static int _numMechs;

		// Token: 0x04000C49 RID: 3145
		private static int _numOutPump;

		// Token: 0x04000C47 RID: 3143
		private static int[] _outPumpX;

		// Token: 0x04000C48 RID: 3144
		private static int[] _outPumpY;

		// Token: 0x04000C41 RID: 3137
		private static Dictionary<Point16, byte> _PixelBoxTriggers;

		// Token: 0x04000C42 RID: 3138
		private static Vector2[] _teleport;

		// Token: 0x04000C3C RID: 3132
		private static Dictionary<Point16, byte> _toProcess;

		// Token: 0x04000C3B RID: 3131
		private static DoubleStack<byte> _wireDirectionList;

		// Token: 0x04000C3A RID: 3130
		private static DoubleStack<Point16> _wireList;

		// Token: 0x04000C39 RID: 3129
		private static Dictionary<Point16, bool> _wireSkip;
	}
}

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace Terraria
{
	// Token: 0x02000029 RID: 41
	public class Collision
	{
		// Token: 0x060002DC RID: 732 RVA: 0x001DC66C File Offset: 0x001DA86C
		public static Vector2 AdvancedTileCollision(bool[] forcedIgnoredTiles, Vector2 Position, Vector2 Velocity, int Width, int Height, bool fallThrough = false, bool fall2 = false, int gravDir = 1)
		{
			Collision.up = false;
			Collision.down = false;
			Vector2 result = Velocity;
			Vector2 vector = Position + Velocity;
			int arg_78_0 = (int)(Position.X / 16f) - 1;
			int num = (int)((Position.X + (float)Width) / 16f) + 2;
			int num2 = (int)(Position.Y / 16f) - 1;
			int num3 = (int)((Position.Y + (float)Height) / 16f) + 2;
			int num4 = -1;
			int num5 = -1;
			int num6 = -1;
			int num7 = -1;
			int arg_BA_0 = Utils.Clamp<int>(arg_78_0, 0, Main.maxTilesX - 1);
			num = Utils.Clamp<int>(num, 0, Main.maxTilesX - 1);
			num2 = Utils.Clamp<int>(num2, 0, Main.maxTilesY - 1);
			num3 = Utils.Clamp<int>(num3, 0, Main.maxTilesY - 1);
			float num8 = (float)((num3 + 3) * 16);
			for (int i = arg_BA_0; i < num; i++)
			{
				for (int j = num2; j < num3; j++)
				{
					Tile tile = Main.tile[i, j];
					if (tile != null && tile.active() && !tile.inActive() && !forcedIgnoredTiles[(int)tile.type] && (Main.tileSolid[(int)tile.type] || (Main.tileSolidTop[(int)tile.type] && tile.frameY == 0)))
					{
						Vector2 vector2;
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16);
						int num9 = 16;
						if (tile.halfBrick())
						{
							vector2.Y += 8f;
							num9 -= 8;
						}
						if (vector.X + (float)Width > vector2.X && vector.X < vector2.X + 16f && vector.Y + (float)Height > vector2.Y && vector.Y < vector2.Y + (float)num9)
						{
							bool flag = false;
							bool flag2 = false;
							if (tile.slope() > 2)
							{
								if (tile.slope() == 3 && Position.Y + Math.Abs(Velocity.X) >= vector2.Y && Position.X >= vector2.X)
								{
									flag2 = true;
								}
								if (tile.slope() == 4 && Position.Y + Math.Abs(Velocity.X) >= vector2.Y && Position.X + (float)Width <= vector2.X + 16f)
								{
									flag2 = true;
								}
							}
							else if (tile.slope() > 0)
							{
								flag = true;
								if (tile.slope() == 1 && Position.Y + (float)Height - Math.Abs(Velocity.X) <= vector2.Y + (float)num9 && Position.X >= vector2.X)
								{
									flag2 = true;
								}
								if (tile.slope() == 2 && Position.Y + (float)Height - Math.Abs(Velocity.X) <= vector2.Y + (float)num9 && Position.X + (float)Width <= vector2.X + 16f)
								{
									flag2 = true;
								}
							}
							if (!flag2)
							{
								if (Position.Y + (float)Height <= vector2.Y)
								{
									Collision.down = true;
									if ((!(Main.tileSolidTop[(int)tile.type] & fallThrough) || !(Velocity.Y <= 1f | fall2)) && num8 > vector2.Y)
									{
										num6 = i;
										num7 = j;
										if (num9 < 16)
										{
											num7++;
										}
										if (num6 != num4 && !flag)
										{
											result.Y = vector2.Y - (Position.Y + (float)Height) + ((gravDir == -1) ? -0.01f : 0f);
											num8 = vector2.Y;
										}
									}
								}
								else if (Position.X + (float)Width <= vector2.X && !Main.tileSolidTop[(int)tile.type])
								{
									if (Main.tile[i - 1, j] == null)
									{
										Main.tile[i - 1, j] = new Tile();
									}
									if (Main.tile[i - 1, j].slope() != 2 && Main.tile[i - 1, j].slope() != 4)
									{
										num4 = i;
										num5 = j;
										if (num5 != num7)
										{
											result.X = vector2.X - (Position.X + (float)Width);
										}
										if (num6 == num4)
										{
											result.Y = Velocity.Y;
										}
									}
								}
								else if (Position.X >= vector2.X + 16f && !Main.tileSolidTop[(int)tile.type])
								{
									if (Main.tile[i + 1, j] == null)
									{
										Main.tile[i + 1, j] = new Tile();
									}
									if (Main.tile[i + 1, j].slope() != 1 && Main.tile[i + 1, j].slope() != 3)
									{
										num4 = i;
										num5 = j;
										if (num5 != num7)
										{
											result.X = vector2.X + 16f - Position.X;
										}
										if (num6 == num4)
										{
											result.Y = Velocity.Y;
										}
									}
								}
								else if (Position.Y >= vector2.Y + (float)num9 && !Main.tileSolidTop[(int)tile.type])
								{
									Collision.up = true;
									num6 = i;
									num7 = j;
									result.Y = vector2.Y + (float)num9 - Position.Y + ((gravDir == 1) ? 0.01f : 0f);
									if (num7 == num5)
									{
										result.X = Velocity.X;
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060002CC RID: 716 RVA: 0x001D9FF0 File Offset: 0x001D81F0
		public static Vector2 AnyCollision(Vector2 Position, Vector2 Velocity, int Width, int Height, bool evenActuated = false)
		{
			Vector2 result = Velocity;
			Vector2 vector = Position + Velocity;
			int num = (int)(Position.X / 16f) - 1;
			int num2 = (int)((Position.X + (float)Width) / 16f) + 2;
			int num3 = (int)(Position.Y / 16f) - 1;
			int num4 = (int)((Position.Y + (float)Height) / 16f) + 2;
			int num5 = -1;
			int num6 = -1;
			int num7 = -1;
			int num8 = -1;
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
					if (Main.tile[i, j] != null && Main.tile[i, j].active() && (evenActuated || !Main.tile[i, j].inActive()))
					{
						Vector2 vector2;
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16);
						int num9 = 16;
						if (Main.tile[i, j].halfBrick())
						{
							vector2.Y += 8f;
							num9 -= 8;
						}
						if (vector.X + (float)Width > vector2.X && vector.X < vector2.X + 16f && vector.Y + (float)Height > vector2.Y && vector.Y < vector2.Y + (float)num9)
						{
							if (Position.Y + (float)Height <= vector2.Y)
							{
								num7 = i;
								num8 = j;
								if (num7 != num5)
								{
									result.Y = vector2.Y - (Position.Y + (float)Height);
								}
							}
							else if (Position.X + (float)Width <= vector2.X && !Main.tileSolidTop[(int)Main.tile[i, j].type])
							{
								num5 = i;
								num6 = j;
								if (num6 != num8)
								{
									result.X = vector2.X - (Position.X + (float)Width);
								}
								if (num7 == num5)
								{
									result.Y = Velocity.Y;
								}
							}
							else if (Position.X >= vector2.X + 16f && !Main.tileSolidTop[(int)Main.tile[i, j].type])
							{
								num5 = i;
								num6 = j;
								if (num6 != num8)
								{
									result.X = vector2.X + 16f - Position.X;
								}
								if (num7 == num5)
								{
									result.Y = Velocity.Y;
								}
							}
							else if (Position.Y >= vector2.Y + (float)num9 && !Main.tileSolidTop[(int)Main.tile[i, j].type])
							{
								num7 = i;
								num8 = j;
								result.Y = vector2.Y + (float)num9 - Position.Y + 0.01f;
								if (num8 == num6)
								{
									result.X = Velocity.X + 0.01f;
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x001D5EEC File Offset: 0x001D40EC
		public static bool CanHit(Vector2 Position1, int Width1, int Height1, Vector2 Position2, int Width2, int Height2)
		{
			int num = (int)((Position1.X + (float)(Width1 / 2)) / 16f);
			int num2 = (int)((Position1.Y + (float)(Height1 / 2)) / 16f);
			int num3 = (int)((Position2.X + (float)(Width2 / 2)) / 16f);
			int num4 = (int)((Position2.Y + (float)(Height2 / 2)) / 16f);
			if (num <= 1)
			{
				num = 1;
			}
			if (num >= Main.maxTilesX)
			{
				num = Main.maxTilesX - 1;
			}
			if (num3 <= 1)
			{
				num3 = 1;
			}
			if (num3 >= Main.maxTilesX)
			{
				num3 = Main.maxTilesX - 1;
			}
			if (num2 <= 1)
			{
				num2 = 1;
			}
			if (num2 >= Main.maxTilesY)
			{
				num2 = Main.maxTilesY - 1;
			}
			if (num4 <= 1)
			{
				num4 = 1;
			}
			if (num4 >= Main.maxTilesY)
			{
				num4 = Main.maxTilesY - 1;
			}
			bool result;
			try
			{
				while (true)
				{
					int num5 = Math.Abs(num - num3);
					int num6 = Math.Abs(num2 - num4);
					if (num == num3 && num2 == num4)
					{
						break;
					}
					if (num5 > num6)
					{
						if (num < num3)
						{
							num++;
						}
						else
						{
							num--;
						}
						if (Main.tile[num, num2 - 1] == null)
						{
							goto Block_14;
						}
						if (Main.tile[num, num2 + 1] == null)
						{
							goto Block_15;
						}
						if (!Main.tile[num, num2 - 1].inActive() && Main.tile[num, num2 - 1].active() && Main.tileSolid[(int)Main.tile[num, num2 - 1].type] && !Main.tileSolidTop[(int)Main.tile[num, num2 - 1].type] && Main.tile[num, num2 - 1].slope() == 0 && !Main.tile[num, num2 - 1].halfBrick() && !Main.tile[num, num2 + 1].inActive() && Main.tile[num, num2 + 1].active() && Main.tileSolid[(int)Main.tile[num, num2 + 1].type] && !Main.tileSolidTop[(int)Main.tile[num, num2 + 1].type] && Main.tile[num, num2 + 1].slope() == 0 && !Main.tile[num, num2 + 1].halfBrick())
						{
							goto Block_27;
						}
					}
					else
					{
						if (num2 < num4)
						{
							num2++;
						}
						else
						{
							num2--;
						}
						if (Main.tile[num - 1, num2] == null)
						{
							goto Block_29;
						}
						if (Main.tile[num + 1, num2] == null)
						{
							goto Block_30;
						}
						if (!Main.tile[num - 1, num2].inActive() && Main.tile[num - 1, num2].active() && Main.tileSolid[(int)Main.tile[num - 1, num2].type] && !Main.tileSolidTop[(int)Main.tile[num - 1, num2].type] && Main.tile[num - 1, num2].slope() == 0 && !Main.tile[num - 1, num2].halfBrick() && !Main.tile[num + 1, num2].inActive() && Main.tile[num + 1, num2].active() && Main.tileSolid[(int)Main.tile[num + 1, num2].type] && !Main.tileSolidTop[(int)Main.tile[num + 1, num2].type] && Main.tile[num + 1, num2].slope() == 0 && !Main.tile[num + 1, num2].halfBrick())
						{
							goto Block_42;
						}
					}
					if (Main.tile[num, num2] == null)
					{
						goto Block_43;
					}
					if (!Main.tile[num, num2].inActive() && Main.tile[num, num2].active() && Main.tileSolid[(int)Main.tile[num, num2].type] && !Main.tileSolidTop[(int)Main.tile[num, num2].type])
					{
						goto Block_47;
					}
				}
				result = true;
				return result;
				Block_14:
				result = false;
				return result;
				Block_15:
				result = false;
				return result;
				Block_27:
				result = false;
				return result;
				Block_29:
				result = false;
				return result;
				Block_30:
				result = false;
				return result;
				Block_42:
				result = false;
				return result;
				Block_43:
				result = false;
				return result;
				Block_47:
				result = false;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060002BB RID: 699 RVA: 0x001D67CC File Offset: 0x001D49CC
		public static bool CanHitLine(Vector2 Position1, int Width1, int Height1, Vector2 Position2, int Width2, int Height2)
		{
			int num = (int)((Position1.X + (float)(Width1 / 2)) / 16f);
			int num2 = (int)((Position1.Y + (float)(Height1 / 2)) / 16f);
			int num3 = (int)((Position2.X + (float)(Width2 / 2)) / 16f);
			int num4 = (int)((Position2.Y + (float)(Height2 / 2)) / 16f);
			if (num <= 1)
			{
				num = 1;
			}
			if (num >= Main.maxTilesX)
			{
				num = Main.maxTilesX - 1;
			}
			if (num3 <= 1)
			{
				num3 = 1;
			}
			if (num3 >= Main.maxTilesX)
			{
				num3 = Main.maxTilesX - 1;
			}
			if (num2 <= 1)
			{
				num2 = 1;
			}
			if (num2 >= Main.maxTilesY)
			{
				num2 = Main.maxTilesY - 1;
			}
			if (num4 <= 1)
			{
				num4 = 1;
			}
			if (num4 >= Main.maxTilesY)
			{
				num4 = Main.maxTilesY - 1;
			}
			float num5 = (float)Math.Abs(num - num3);
			float num6 = (float)Math.Abs(num2 - num4);
			if (num5 == 0f && num6 == 0f)
			{
				return true;
			}
			float num7 = 1f;
			float num8 = 1f;
			if (num5 == 0f || num6 == 0f)
			{
				if (num5 == 0f)
				{
					num7 = 0f;
				}
				if (num6 == 0f)
				{
					num8 = 0f;
				}
			}
			else if (num5 > num6)
			{
				num7 = num5 / num6;
			}
			else
			{
				num8 = num6 / num5;
			}
			float num9 = 0f;
			float num10 = 0f;
			int num11 = 1;
			if (num2 < num4)
			{
				num11 = 2;
			}
			int num12 = (int)num5;
			int num13 = (int)num6;
			int num14 = Math.Sign(num3 - num);
			int num15 = Math.Sign(num4 - num2);
			bool flag = false;
			bool flag2 = false;
			bool result;
			try
			{
				while (true)
				{
					if (num11 == 2)
					{
						num9 += num7;
						int num16 = (int)num9;
						num9 %= 1f;
						for (int i = 0; i < num16; i++)
						{
							if (Main.tile[num, num2 - 1] == null)
							{
								goto Block_18;
							}
							if (Main.tile[num, num2] == null)
							{
								goto Block_19;
							}
							if (Main.tile[num, num2 + 1] == null)
							{
								goto Block_20;
							}
							Tile tile = Main.tile[num, num2 - 1];
							Tile tile2 = Main.tile[num, num2 + 1];
							Tile tile3 = Main.tile[num, num2];
							if ((!tile.inActive() && tile.active() && Main.tileSolid[(int)tile.type] && !Main.tileSolidTop[(int)tile.type]) || (!tile2.inActive() && tile2.active() && Main.tileSolid[(int)tile2.type] && !Main.tileSolidTop[(int)tile2.type]) || (!tile3.inActive() && tile3.active() && Main.tileSolid[(int)tile3.type] && !Main.tileSolidTop[(int)tile3.type]))
							{
								goto IL_28E;
							}
							if (num12 == 0 && num13 == 0)
							{
								flag = true;
								break;
							}
							num += num14;
							num12--;
							if (num12 == 0 && num13 == 0 && num16 == 1)
							{
								flag2 = true;
							}
						}
						if (num13 != 0)
						{
							num11 = 1;
						}
					}
					else if (num11 == 1)
					{
						num10 += num8;
						int num17 = (int)num10;
						num10 %= 1f;
						for (int j = 0; j < num17; j++)
						{
							if (Main.tile[num - 1, num2] == null)
							{
								goto Block_37;
							}
							if (Main.tile[num, num2] == null)
							{
								goto Block_38;
							}
							if (Main.tile[num + 1, num2] == null)
							{
								goto Block_39;
							}
							Tile tile4 = Main.tile[num - 1, num2];
							Tile tile5 = Main.tile[num + 1, num2];
							Tile tile6 = Main.tile[num, num2];
							if ((!tile4.inActive() && tile4.active() && Main.tileSolid[(int)tile4.type] && !Main.tileSolidTop[(int)tile4.type]) || (!tile5.inActive() && tile5.active() && Main.tileSolid[(int)tile5.type] && !Main.tileSolidTop[(int)tile5.type]) || (!tile6.inActive() && tile6.active() && Main.tileSolid[(int)tile6.type] && !Main.tileSolidTop[(int)tile6.type]))
							{
								goto IL_406;
							}
							if (num12 == 0 && num13 == 0)
							{
								flag = true;
								break;
							}
							num2 += num15;
							num13--;
							if (num12 == 0 && num13 == 0 && num17 == 1)
							{
								flag2 = true;
							}
						}
						if (num12 != 0)
						{
							num11 = 2;
						}
					}
					if (Main.tile[num, num2] == null)
					{
						goto Block_55;
					}
					Tile tile7 = Main.tile[num, num2];
					if (!tile7.inActive() && tile7.active() && Main.tileSolid[(int)tile7.type] && !Main.tileSolidTop[(int)tile7.type])
					{
						goto Block_59;
					}
					if (flag | flag2)
					{
						goto Block_60;
					}
				}
				Block_18:
				result = false;
				return result;
				Block_19:
				result = false;
				return result;
				Block_20:
				result = false;
				return result;
				IL_28E:
				result = false;
				return result;
				Block_37:
				result = false;
				return result;
				Block_38:
				result = false;
				return result;
				Block_39:
				result = false;
				return result;
				IL_406:
				result = false;
				return result;
				Block_55:
				result = false;
				return result;
				Block_59:
				result = false;
				return result;
				Block_60:
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060002BA RID: 698 RVA: 0x001D6358 File Offset: 0x001D4558
		public static bool CanHitWithCheck(Vector2 Position1, int Width1, int Height1, Vector2 Position2, int Width2, int Height2, Utils.PerLinePoint check)
		{
			int num = (int)((Position1.X + (float)(Width1 / 2)) / 16f);
			int num2 = (int)((Position1.Y + (float)(Height1 / 2)) / 16f);
			int num3 = (int)((Position2.X + (float)(Width2 / 2)) / 16f);
			int num4 = (int)((Position2.Y + (float)(Height2 / 2)) / 16f);
			if (num <= 1)
			{
				num = 1;
			}
			if (num >= Main.maxTilesX)
			{
				num = Main.maxTilesX - 1;
			}
			if (num3 <= 1)
			{
				num3 = 1;
			}
			if (num3 >= Main.maxTilesX)
			{
				num3 = Main.maxTilesX - 1;
			}
			if (num2 <= 1)
			{
				num2 = 1;
			}
			if (num2 >= Main.maxTilesY)
			{
				num2 = Main.maxTilesY - 1;
			}
			if (num4 <= 1)
			{
				num4 = 1;
			}
			if (num4 >= Main.maxTilesY)
			{
				num4 = Main.maxTilesY - 1;
			}
			bool result;
			try
			{
				while (true)
				{
					int num5 = Math.Abs(num - num3);
					int num6 = Math.Abs(num2 - num4);
					if (num == num3 && num2 == num4)
					{
						break;
					}
					if (num5 > num6)
					{
						if (num < num3)
						{
							num++;
						}
						else
						{
							num--;
						}
						if (Main.tile[num, num2 - 1] == null)
						{
							goto Block_14;
						}
						if (Main.tile[num, num2 + 1] == null)
						{
							goto Block_15;
						}
						if (!Main.tile[num, num2 - 1].inActive() && Main.tile[num, num2 - 1].active() && Main.tileSolid[(int)Main.tile[num, num2 - 1].type] && !Main.tileSolidTop[(int)Main.tile[num, num2 - 1].type] && Main.tile[num, num2 - 1].slope() == 0 && !Main.tile[num, num2 - 1].halfBrick() && !Main.tile[num, num2 + 1].inActive() && Main.tile[num, num2 + 1].active() && Main.tileSolid[(int)Main.tile[num, num2 + 1].type] && !Main.tileSolidTop[(int)Main.tile[num, num2 + 1].type] && Main.tile[num, num2 + 1].slope() == 0 && !Main.tile[num, num2 + 1].halfBrick())
						{
							goto Block_27;
						}
					}
					else
					{
						if (num2 < num4)
						{
							num2++;
						}
						else
						{
							num2--;
						}
						if (Main.tile[num - 1, num2] == null)
						{
							goto Block_29;
						}
						if (Main.tile[num + 1, num2] == null)
						{
							goto Block_30;
						}
						if (!Main.tile[num - 1, num2].inActive() && Main.tile[num - 1, num2].active() && Main.tileSolid[(int)Main.tile[num - 1, num2].type] && !Main.tileSolidTop[(int)Main.tile[num - 1, num2].type] && Main.tile[num - 1, num2].slope() == 0 && !Main.tile[num - 1, num2].halfBrick() && !Main.tile[num + 1, num2].inActive() && Main.tile[num + 1, num2].active() && Main.tileSolid[(int)Main.tile[num + 1, num2].type] && !Main.tileSolidTop[(int)Main.tile[num + 1, num2].type] && Main.tile[num + 1, num2].slope() == 0 && !Main.tile[num + 1, num2].halfBrick())
						{
							goto Block_42;
						}
					}
					if (Main.tile[num, num2] == null)
					{
						goto Block_43;
					}
					if (!Main.tile[num, num2].inActive() && Main.tile[num, num2].active() && Main.tileSolid[(int)Main.tile[num, num2].type] && !Main.tileSolidTop[(int)Main.tile[num, num2].type])
					{
						goto Block_47;
					}
					if (!check(num, num2))
					{
						goto Block_48;
					}
				}
				result = true;
				return result;
				Block_14:
				result = false;
				return result;
				Block_15:
				result = false;
				return result;
				Block_27:
				result = false;
				return result;
				Block_29:
				result = false;
				return result;
				Block_30:
				result = false;
				return result;
				Block_42:
				result = false;
				return result;
				Block_43:
				result = false;
				return result;
				Block_47:
				result = false;
				return result;
				Block_48:
				result = false;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x001D58AC File Offset: 0x001D3AAC
		public static bool CheckAABBvAABBCollision(Vector2 position1, Vector2 dimensions1, Vector2 position2, Vector2 dimensions2)
		{
			return position1.X < position2.X + dimensions2.X && position1.Y < position2.Y + dimensions2.Y && position1.X + dimensions1.X > position2.X && position1.Y + dimensions1.Y > position2.Y;
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x001D59B4 File Offset: 0x001D3BB4
		public static bool CheckAABBvLineCollision(Vector2 aabbPosition, Vector2 aabbDimensions, Vector2 lineStart, Vector2 lineEnd)
		{
			int num;
			if ((num = Collision.collisionOutcode(aabbPosition, aabbDimensions, lineEnd)) == 0)
			{
				return true;
			}
			int num2;
			while ((num2 = Collision.collisionOutcode(aabbPosition, aabbDimensions, lineStart)) != 0)
			{
				if ((num2 & num) != 0)
				{
					return false;
				}
				if ((num2 & 5) != 0)
				{
					float num3 = aabbPosition.X;
					if ((num2 & 4) != 0)
					{
						num3 += aabbDimensions.X;
					}
					lineStart.Y += (num3 - lineStart.X) * (lineEnd.Y - lineStart.Y) / (lineEnd.X - lineStart.X);
					lineStart.X = num3;
				}
				else
				{
					float num4 = aabbPosition.Y;
					if ((num2 & 8) != 0)
					{
						num4 += aabbDimensions.Y;
					}
					lineStart.X += (num4 - lineStart.Y) * (lineEnd.X - lineStart.X) / (lineEnd.Y - lineStart.Y);
					lineStart.Y = num4;
				}
			}
			return true;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x001D5AC0 File Offset: 0x001D3CC0
		public static bool CheckAABBvLineCollision(Vector2 objectPosition, Vector2 objectDimensions, Vector2 lineStart, Vector2 lineEnd, float lineWidth, ref float collisionPoint)
		{
			float num = lineWidth * 0.5f;
			Vector2 position = lineStart;
			Vector2 vector = lineEnd - lineStart;
			if (vector.X > 0f)
			{
				vector.X += lineWidth;
				position.X -= num;
			}
			else
			{
				position.X += vector.X - num;
				vector.X = -vector.X + lineWidth;
			}
			if (vector.Y > 0f)
			{
				vector.Y += lineWidth;
				position.Y -= num;
			}
			else
			{
				position.Y += vector.Y - num;
				vector.Y = -vector.Y + lineWidth;
			}
			if (!Collision.CheckAABBvAABBCollision(objectPosition, objectDimensions, position, vector))
			{
				return false;
			}
			Vector2 vector2 = objectPosition - lineStart;
			Vector2 vector3 = vector2 + objectDimensions;
			Vector2 spinningpoint = new Vector2(vector2.X, vector3.Y);
			Vector2 spinningpoint2 = new Vector2(vector3.X, vector2.Y);
			Vector2 vector4 = lineEnd - lineStart;
			float num2 = vector4.Length();
			float num3 = (float)Math.Atan2((double)vector4.Y, (double)vector4.X);
			Vector2[] array = new Vector2[]
			{
				vector2.RotatedBy((double)(-(double)num3), default(Vector2)),
				spinningpoint2.RotatedBy((double)(-(double)num3), default(Vector2)),
				vector3.RotatedBy((double)(-(double)num3), default(Vector2)),
				spinningpoint.RotatedBy((double)(-(double)num3), default(Vector2))
			};
			collisionPoint = num2;
			bool result = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (Math.Abs(array[i].Y) < num && array[i].X < collisionPoint && array[i].X >= 0f)
				{
					collisionPoint = array[i].X;
					result = true;
				}
			}
			Vector2 vector5 = new Vector2(0f, num);
			Vector2 value = new Vector2(num2, num);
			Vector2 vector6 = new Vector2(0f, -num);
			Vector2 value2 = new Vector2(num2, -num);
			for (int j = 0; j < array.Length; j++)
			{
				int num4 = (j + 1) % array.Length;
				Vector2 vector7 = value - vector5;
				Vector2 vector8 = array[num4] - array[j];
				float num5 = vector7.X * vector8.Y - vector7.Y * vector8.X;
				if (num5 != 0f)
				{
					Vector2 vector9 = array[j] - vector5;
					float num6 = (vector9.X * vector8.Y - vector9.Y * vector8.X) / num5;
					if (num6 >= 0f && num6 <= 1f)
					{
						float num7 = (vector9.X * vector7.Y - vector9.Y * vector7.X) / num5;
						if (num7 >= 0f && num7 <= 1f)
						{
							result = true;
							collisionPoint = Math.Min(collisionPoint, vector5.X + num6 * vector7.X);
						}
					}
				}
				vector7 = value2 - vector6;
				num5 = vector7.X * vector8.Y - vector7.Y * vector8.X;
				if (num5 != 0f)
				{
					Vector2 vector10 = array[j] - vector6;
					float num8 = (vector10.X * vector8.Y - vector10.Y * vector8.X) / num5;
					if (num8 >= 0f && num8 <= 1f)
					{
						float num9 = (vector10.X * vector7.Y - vector10.Y * vector7.X) / num5;
						if (num9 >= 0f && num9 <= 1f)
						{
							result = true;
							collisionPoint = Math.Min(collisionPoint, vector6.X + num8 * vector7.X);
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x001D5A88 File Offset: 0x001D3C88
		public static bool CheckAABBvLineCollision2(Vector2 aabbPosition, Vector2 aabbDimensions, Vector2 lineStart, Vector2 lineEnd)
		{
			float num = 0f;
			return Utils.RectangleLineCollision(aabbPosition, aabbPosition + aabbDimensions, lineStart, lineEnd) || Collision.CheckAABBvLineCollision(aabbPosition, aabbDimensions, lineStart, lineEnd, 0.0001f, ref num);
		}

		// Token: 0x060002AF RID: 687 RVA: 0x001D54B0 File Offset: 0x001D36B0
		public static Vector2[] CheckLinevLine(Vector2 a1, Vector2 a2, Vector2 b1, Vector2 b2)
		{
			if (a1.Equals(a2) && b1.Equals(b2))
			{
				if (a1.Equals(b1))
				{
					return new Vector2[]
					{
						a1
					};
				}
				return new Vector2[0];
			}
			else if (b1.Equals(b2))
			{
				if (Collision.PointOnLine(b1, a1, a2))
				{
					return new Vector2[]
					{
						b1
					};
				}
				return new Vector2[0];
			}
			else if (a1.Equals(a2))
			{
				if (Collision.PointOnLine(a1, b1, b2))
				{
					return new Vector2[]
					{
						a1
					};
				}
				return new Vector2[0];
			}
			else
			{
				float num = (b2.X - b1.X) * (a1.Y - b1.Y) - (b2.Y - b1.Y) * (a1.X - b1.X);
				float num2 = (a2.X - a1.X) * (a1.Y - b1.Y) - (a2.Y - a1.Y) * (a1.X - b1.X);
				float num3 = (b2.Y - b1.Y) * (a2.X - a1.X) - (b2.X - b1.X) * (a2.Y - a1.Y);
				if (-Collision.Epsilon >= num3 || num3 >= Collision.Epsilon)
				{
					float num4 = num / num3;
					float num5 = num2 / num3;
					if (0f <= num4 && num4 <= 1f && 0f <= num5 && num5 <= 1f)
					{
						return new Vector2[]
						{
							new Vector2(a1.X + num4 * (a2.X - a1.X), a1.Y + num4 * (a2.Y - a1.Y))
						};
					}
					return new Vector2[0];
				}
				else
				{
					if ((-Collision.Epsilon >= num || num >= Collision.Epsilon) && (-Collision.Epsilon >= num2 || num2 >= Collision.Epsilon))
					{
						return new Vector2[0];
					}
					if (a1.Equals(a2))
					{
						return Collision.OneDimensionalIntersection(b1, b2, a1, a2);
					}
					return Collision.OneDimensionalIntersection(a1, a2, b1, b2);
				}
			}
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x001D5910 File Offset: 0x001D3B10
		private static int collisionOutcode(Vector2 aabbPosition, Vector2 aabbDimensions, Vector2 point)
		{
			float num = aabbPosition.X + aabbDimensions.X;
			float num2 = aabbPosition.Y + aabbDimensions.Y;
			int num3 = 0;
			if (aabbDimensions.X <= 0f)
			{
				num3 |= 5;
			}
			else if (point.X < aabbPosition.X)
			{
				num3 |= 1;
			}
			else if (point.X - num > 0f)
			{
				num3 |= 4;
			}
			if (aabbDimensions.Y <= 0f)
			{
				num3 |= 10;
			}
			else if (point.Y < aabbPosition.Y)
			{
				num3 |= 2;
			}
			else if (point.Y - num2 > 0f)
			{
				num3 |= 8;
			}
			return num3;
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x001D56B8 File Offset: 0x001D38B8
		private static double DistFromSeg(Vector2 p, Vector2 q0, Vector2 q1, double radius, ref float u)
		{
			double arg_3B_0 = (double)(q1.X - q0.X);
			double num = (double)(q1.Y - q0.Y);
			double num2 = (double)(q0.X - p.X);
			double num3 = (double)(q0.Y - p.Y);
			double num4 = Math.Sqrt(arg_3B_0 * arg_3B_0 + num * num);
			if (num4 < (double)Collision.Epsilon)
			{
				throw new Exception("Expected line segment, not point.");
			}
			return Math.Abs(arg_3B_0 * num3 - num2 * num) / num4;
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x001D773C File Offset: 0x001D593C
		public static bool DrownCollision(Vector2 Position, int Width, int Height, float gravDir = -1f)
		{
			Vector2 vector = new Vector2(Position.X + (float)(Width / 2), Position.Y + (float)(Height / 2));
			int num = 10;
			int num2 = 12;
			if (num > Width)
			{
				num = Width;
			}
			if (num2 > Height)
			{
				num2 = Height;
			}
			vector = new Vector2(vector.X - (float)(num / 2), Position.Y + -2f);
			if (gravDir == -1f)
			{
				vector.Y += (float)(Height / 2 - 6);
			}
			int arg_B6_0 = (int)(Position.X / 16f) - 1;
			int num3 = (int)((Position.X + (float)Width) / 16f) + 2;
			int num4 = (int)(Position.Y / 16f) - 1;
			int num5 = (int)((Position.Y + (float)Height) / 16f) + 2;
			int arg_100_0 = Utils.Clamp<int>(arg_B6_0, 0, Main.maxTilesX - 1);
			num3 = Utils.Clamp<int>(num3, 0, Main.maxTilesX - 1);
			num4 = Utils.Clamp<int>(num4, 0, Main.maxTilesY - 1);
			num5 = Utils.Clamp<int>(num5, 0, Main.maxTilesY - 1);
			int num6 = (gravDir == 1f) ? num4 : (num5 - 1);
			for (int i = arg_100_0; i < num3; i++)
			{
				for (int j = num4; j < num5; j++)
				{
					Tile tile = Main.tile[i, j];
					if (tile != null && tile.liquid > 0 && !tile.lava() && (j != num6 || !tile.active() || !Main.tileSolid[(int)tile.type] || Main.tileSolidTop[(int)tile.type]))
					{
						Vector2 vector2;
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16);
						int num7 = 16;
						float num8 = (float)(256 - (int)Main.tile[i, j].liquid);
						num8 /= 32f;
						vector2.Y += num8 * 2f;
						num7 -= (int)(num8 * 2f);
						if (vector.X + (float)num > vector2.X && vector.X < vector2.X + 16f && vector.Y + (float)num2 > vector2.Y && vector.Y < vector2.Y + (float)num7)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x060002BF RID: 703 RVA: 0x001D762C File Offset: 0x001D582C
		public static bool EmptyTile(int i, int j, bool ignoreTiles = false)
		{
			Rectangle rectangle = new Rectangle(i * 16, j * 16, 16, 16);
			if (Main.tile[i, j].active() && !ignoreTiles)
			{
				return false;
			}
			for (int k = 0; k < 255; k++)
			{
				if (Main.player[k].active && rectangle.Intersects(new Rectangle((int)Main.player[k].position.X, (int)Main.player[k].position.Y, Main.player[k].width, Main.player[k].height)))
				{
					return false;
				}
			}
			for (int l = 0; l < 200; l++)
			{
				if (Main.npc[l].active && rectangle.Intersects(new Rectangle((int)Main.npc[l].position.X, (int)Main.npc[l].position.Y, Main.npc[l].width, Main.npc[l].height)))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060002DB RID: 731 RVA: 0x001DC5D0 File Offset: 0x001DA7D0
		public static void ExpandVertically(int startX, int startY, out int topY, out int bottomY, int maxExpandUp = 100, int maxExpandDown = 100)
		{
			topY = startY;
			bottomY = startY;
			if (!WorldGen.InWorld(startX, startY, 10))
			{
				return;
			}
			int num = 0;
			while (num < maxExpandUp && topY > 0 && topY >= 10 && Main.tile[startX, topY] != null && !WorldGen.SolidTile3(startX, topY))
			{
				topY--;
				num++;
			}
			int num2 = 0;
			while (num2 < maxExpandDown && bottomY < Main.maxTilesY - 10 && bottomY <= Main.maxTilesY - 10 && Main.tile[startX, bottomY] != null && !WorldGen.SolidTile3(startX, bottomY))
			{
				bottomY++;
				num2++;
			}
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x001D9B5C File Offset: 0x001D7D5C
		public static bool FindCollisionDirection(out int Direction, Vector2 position, int Width, int Height, bool fallThrough = false, bool fall2 = false, int gravDir = 1)
		{
			Vector2 vector = Vector2.UnitX * 16f;
			if (Collision.TileCollision(position - vector, vector, Width, Height, fallThrough, fall2, gravDir) != vector)
			{
				Direction = 0;
				return true;
			}
			vector = -Vector2.UnitX * 16f;
			if (Collision.TileCollision(position - vector, vector, Width, Height, fallThrough, fall2, gravDir) != vector)
			{
				Direction = 1;
				return true;
			}
			vector = Vector2.UnitY * 16f;
			if (Collision.TileCollision(position - vector, vector, Width, Height, fallThrough, fall2, gravDir) != vector)
			{
				Direction = 2;
				return true;
			}
			vector = -Vector2.UnitY * 16f;
			if (Collision.TileCollision(position - vector, vector, Width, Height, fallThrough, fall2, gravDir) != vector)
			{
				Direction = 3;
				return true;
			}
			Direction = -1;
			return false;
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x001D9688 File Offset: 0x001D7888
		public static List<Point> FindCollisionTile(int Direction, Vector2 position, float testMagnitude, int Width, int Height, bool fallThrough = false, bool fall2 = false, int gravDir = 1, bool checkCardinals = true, bool checkSlopes = false)
		{
			List<Point> list = new List<Point>();
			if (Direction > 1)
			{
				if (Direction - 2 <= 1)
				{
					Vector2 vector = (Direction == 2) ? (Vector2.UnitY * testMagnitude) : (-Vector2.UnitY * testMagnitude);
					Vector4 vec = new Vector4(position, vector.X, vector.Y);
					int num = (int)(position.Y + (float)((Direction == 2) ? Height : 0)) / 16;
					float num2 = Math.Min(16f - position.X % 16f, (float)Width);
					float num3 = num2;
					if (checkCardinals && Collision.TileCollision(position - vector, vector, (int)num2, Height, fallThrough, fall2, gravDir) != vector)
					{
						list.Add(new Point((int)position.X / 16, num));
					}
					else if (checkSlopes && Collision.SlopeCollision(position, vector, (int)num2, Height, (float)gravDir, fallThrough).YZW() != vec.YZW())
					{
						list.Add(new Point((int)position.X / 16, num));
					}
					while (num3 + 16f <= (float)(Width - 16))
					{
						if (checkCardinals && Collision.TileCollision(position - vector + Vector2.UnitX * num3, vector, 16, Height, fallThrough, fall2, gravDir) != vector)
						{
							list.Add(new Point((int)(position.X + num3) / 16, num));
						}
						else if (checkSlopes && Collision.SlopeCollision(position + Vector2.UnitX * num3, vector, 16, Height, (float)gravDir, fallThrough).YZW() != vec.YZW())
						{
							list.Add(new Point((int)(position.X + num3) / 16, num));
						}
						num3 += 16f;
					}
					int width = Width - (int)num3;
					if (checkCardinals && Collision.TileCollision(position - vector + Vector2.UnitX * num3, vector, width, Height, fallThrough, fall2, gravDir) != vector)
					{
						list.Add(new Point((int)(position.X + num3) / 16, num));
					}
					else if (checkSlopes && Collision.SlopeCollision(position + Vector2.UnitX * num3, vector, width, Height, (float)gravDir, fallThrough).YZW() != vec.YZW())
					{
						list.Add(new Point((int)(position.X + num3) / 16, num));
					}
				}
			}
			else
			{
				Vector2 vector = (Direction == 0) ? (Vector2.UnitX * testMagnitude) : (-Vector2.UnitX * testMagnitude);
				Vector4 vec = new Vector4(position, vector.X, vector.Y);
				int num = (int)(position.X + (float)((Direction == 0) ? Width : 0)) / 16;
				float num4 = Math.Min(16f - position.Y % 16f, (float)Height);
				float num5 = num4;
				if (checkCardinals && Collision.TileCollision(position - vector, vector, Width, (int)num4, fallThrough, fall2, gravDir) != vector)
				{
					list.Add(new Point(num, (int)position.Y / 16));
				}
				else if (checkSlopes && Collision.SlopeCollision(position, vector, Width, (int)num4, (float)gravDir, fallThrough).XZW() != vec.XZW())
				{
					list.Add(new Point(num, (int)position.Y / 16));
				}
				while (num5 + 16f <= (float)(Height - 16))
				{
					if (checkCardinals && Collision.TileCollision(position - vector + Vector2.UnitY * num5, vector, Width, 16, fallThrough, fall2, gravDir) != vector)
					{
						list.Add(new Point(num, (int)(position.Y + num5) / 16));
					}
					else if (checkSlopes && Collision.SlopeCollision(position + Vector2.UnitY * num5, vector, Width, 16, (float)gravDir, fallThrough).XZW() != vec.XZW())
					{
						list.Add(new Point(num, (int)(position.Y + num5) / 16));
					}
					num5 += 16f;
				}
				int height = Height - (int)num5;
				if (checkCardinals && Collision.TileCollision(position - vector + Vector2.UnitY * num5, vector, Width, height, fallThrough, fall2, gravDir) != vector)
				{
					list.Add(new Point(num, (int)(position.Y + num5) / 16));
				}
				else if (checkSlopes && Collision.SlopeCollision(position + Vector2.UnitY * num5, vector, Width, height, (float)gravDir, fallThrough).XZW() != vec.XZW())
				{
					list.Add(new Point(num, (int)(position.Y + num5) / 16));
				}
			}
			return list;
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x001D584C File Offset: 0x001D3A4C
		private static float[] FindOverlapPoints(float relativePoint1, float relativePoint2)
		{
			float val = Math.Min(relativePoint1, relativePoint2);
			float val2 = Math.Max(relativePoint1, relativePoint2);
			float num = Math.Max(0f, val);
			float num2 = Math.Min(1f, val2);
			if (num > num2)
			{
				return new float[0];
			}
			if (num == num2)
			{
				return new float[]
				{
					num
				};
			}
			return new float[]
			{
				num,
				num2
			};
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x001DBF90 File Offset: 0x001DA190
		public static List<Point> GetEntityEdgeTiles(Entity entity, bool left = true, bool right = true, bool up = true, bool down = true)
		{
			int num = (int)entity.position.X;
			int num2 = (int)entity.position.Y;
			int arg_1E_0 = num % 16;
			int arg_23_0 = num2 % 16;
			int num3 = (int)entity.Right.X;
			int num4 = (int)entity.Bottom.Y;
			if (num % 16 == 0)
			{
				num--;
			}
			if (num2 % 16 == 0)
			{
				num2--;
			}
			if (num3 % 16 == 0)
			{
				num3++;
			}
			if (num4 % 16 == 0)
			{
				num4++;
			}
			int num5 = num3 / 16 - num / 16 + 1;
			int num6 = num4 / 16 - num2 / 16;
			List<Point> list = new List<Point>();
			num /= 16;
			num2 /= 16;
			for (int i = num; i < num + num5; i++)
			{
				if (up)
				{
					list.Add(new Point(i, num2));
				}
				if (down)
				{
					list.Add(new Point(i, num2 + num6));
				}
			}
			for (int j = num2; j < num2 + num6; j++)
			{
				if (left)
				{
					list.Add(new Point(num, j));
				}
				if (right)
				{
					list.Add(new Point(num + num5, j));
				}
			}
			return list;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x001DBDE4 File Offset: 0x001D9FE4
		public static float GetTileRotation(Vector2 position)
		{
			float num = position.Y % 16f;
			int num2 = (int)(position.X / 16f);
			int num3 = (int)(position.Y / 16f);
			Tile tile = Main.tile[num2, num3];
			bool flag = false;
			for (int i = 2; i >= 0; i--)
			{
				if (tile.active())
				{
					if (Main.tileSolid[(int)tile.type])
					{
						int num4 = tile.blockType();
						if (tile.type == 19)
						{
							int num5 = (int)(tile.frameX / 18);
							if (((num5 >= 0 && num5 <= 7) || (num5 >= 12 && num5 <= 16)) && (num == 0f | flag))
							{
								return 0f;
							}
							switch (num5)
							{
								case 8:
								case 19:
								case 21:
								case 23:
									return -0.7853982f;
								case 10:
								case 20:
								case 22:
								case 24:
									return 0.7853982f;
								case 25:
								case 26:
									if (flag)
									{
										return 0f;
									}
									if (num4 == 2)
									{
										return 0.7853982f;
									}
									if (num4 == 3)
									{
										return -0.7853982f;
									}
									break;
							}
						}
						else
						{
							if (num4 == 1)
							{
								return 0f;
							}
							if (num4 == 2)
							{
								return 0.7853982f;
							}
							if (num4 == 3)
							{
								return -0.7853982f;
							}
							return 0f;
						}
					}
					else if ((Main.tileSolidTop[(int)tile.type] && tile.frameY == 0) & flag)
					{
						return 0f;
					}
				}
				num3++;
				tile = Main.tile[num2, num3];
				flag = true;
			}
			return 0f;
		}

		// Token: 0x060002DA RID: 730 RVA: 0x001DC51C File Offset: 0x001DA71C
		public static List<Point> GetTilesIn(Vector2 TopLeft, Vector2 BottomRight)
		{
			List<Point> list = new List<Point>();
			Point arg_13_0 = TopLeft.ToTileCoordinates();
			Point point = BottomRight.ToTileCoordinates();
			int num = Utils.Clamp<int>(arg_13_0.X, 0, Main.maxTilesX - 1);
			int num2 = Utils.Clamp<int>(arg_13_0.Y, 0, Main.maxTilesY - 1);
			int num3 = Utils.Clamp<int>(point.X, 0, Main.maxTilesX - 1);
			int num4 = Utils.Clamp<int>(point.Y, 0, Main.maxTilesY - 1);
			for (int i = num; i <= num3; i++)
			{
				for (int j = num2; j <= num4; j++)
				{
					if (Main.tile[i, j] != null)
					{
						list.Add(new Point(i, j));
					}
				}
			}
			return list;
		}

		// Token: 0x060002CD RID: 717 RVA: 0x001DA334 File Offset: 0x001D8534
		public static void HitTiles(Vector2 Position, Vector2 Velocity, int Width, int Height)
		{
			Vector2 vector = Position + Velocity;
			int num = (int)(Position.X / 16f) - 1;
			int num2 = (int)((Position.X + (float)Width) / 16f) + 2;
			int num3 = (int)(Position.Y / 16f) - 1;
			int num4 = (int)((Position.Y + (float)Height) / 16f) + 2;
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
					if (Main.tile[i, j] != null && !Main.tile[i, j].inActive() && Main.tile[i, j].active() && (Main.tileSolid[(int)Main.tile[i, j].type] || (Main.tileSolidTop[(int)Main.tile[i, j].type] && Main.tile[i, j].frameY == 0)))
					{
						Vector2 vector2;
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16);
						int num5 = 16;
						if (Main.tile[i, j].halfBrick())
						{
							vector2.Y += 8f;
							num5 -= 8;
						}
						if (vector.X + (float)Width >= vector2.X && vector.X <= vector2.X + 16f && vector.Y + (float)Height >= vector2.Y && vector.Y <= vector2.Y + (float)num5)
						{
							WorldGen.KillTile(i, j, true, true, false);
						}
					}
				}
			}
		}

		// Token: 0x060002BE RID: 702 RVA: 0x001D7530 File Offset: 0x001D5730
		public static bool HitWallSubstep(int x, int y)
		{
			if (Main.tile[x, y].wall == 0)
			{
				return false;
			}
			bool flag = false;
			if (Main.wallHouse[(int)Main.tile[x, y].wall])
			{
				flag = true;
			}
			if (!flag)
			{
				for (int i = -1; i < 2; i++)
				{
					for (int j = -1; j < 2; j++)
					{
						if ((i != 0 || j != 0) && Main.tile[x + i, y + j].wall == 0)
						{
							flag = true;
						}
					}
				}
			}
			if (Main.tile[x, y].active() & flag)
			{
				bool flag2 = true;
				for (int k = -1; k < 2; k++)
				{
					for (int l = -1; l < 2; l++)
					{
						if (k != 0 || l != 0)
						{
							Tile tile = Main.tile[x + k, y + l];
							if (!tile.active() || !Main.tileSolid[(int)tile.type] || Main.tileSolidTop[(int)tile.type])
							{
								flag2 = false;
							}
						}
					}
				}
				if (flag2)
				{
					flag = false;
				}
			}
			return flag;
		}

		// Token: 0x060002CE RID: 718 RVA: 0x001DA51C File Offset: 0x001D871C
		public static Vector2 HurtTiles(Vector2 Position, Vector2 Velocity, int Width, int Height, bool fireImmune = false)
		{
			int num = (int)(Position.X / 16f) - 1;
			int num2 = (int)((Position.X + (float)Width) / 16f) + 2;
			int num3 = (int)(Position.Y / 16f) - 1;
			int num4 = (int)((Position.Y + (float)Height) / 16f) + 2;
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
					if (Main.tile[i, j] != null && Main.tile[i, j].slope() == 0 && !Main.tile[i, j].inActive() && Main.tile[i, j].active() && (Main.tile[i, j].type == 32 || Main.tile[i, j].type == 37 || Main.tile[i, j].type == 48 || Main.tile[i, j].type == 232 || Main.tile[i, j].type == 53 || Main.tile[i, j].type == 57 || Main.tile[i, j].type == 58 || Main.tile[i, j].type == 69 || Main.tile[i, j].type == 76 || Main.tile[i, j].type == 112 || Main.tile[i, j].type == 116 || Main.tile[i, j].type == 123 || Main.tile[i, j].type == 224 || Main.tile[i, j].type == 234 || Main.tile[i, j].type == 352))
					{
						Vector2 vector;
						vector.X = (float)(i * 16);
						vector.Y = (float)(j * 16);
						int num5 = 0;
						int type = (int)Main.tile[i, j].type;
						int num6 = 16;
						if (Main.tile[i, j].halfBrick())
						{
							vector.Y += 8f;
							num6 -= 8;
						}
						if (type == 32 || type == 69 || type == 80 || type == 352 || (type == 80 && Main.expertMode))
						{
							if (Position.X + (float)Width > vector.X && Position.X < vector.X + 16f && Position.Y + (float)Height > vector.Y && Position.Y < vector.Y + (float)num6 + 0.011f)
							{
								int num7 = 1;
								if (Position.X + (float)(Width / 2) < vector.X + 8f)
								{
									num7 = -1;
								}
								num5 = 10;
								if (type == 69)
								{
									num5 = 17;
								}
								else if (type == 80)
								{
									num5 = 6;
								}
								if (type == 32 || type == 69 || type == 352)
								{
									WorldGen.KillTile(i, j, false, false, false);
									if (Main.netMode == 1 && !Main.tile[i, j].active() && Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, null, 4, (float)i, (float)j, 0f, 0, 0, 0);
									}
								}
								return new Vector2((float)num7, (float)num5);
							}
						}
						else if (type == 53 || type == 112 || type == 116 || type == 123 || type == 224 || type == 234)
						{
							if (Position.X + (float)Width - 2f >= vector.X && Position.X + 2f <= vector.X + 16f && Position.Y + (float)Height - 2f >= vector.Y && Position.Y + 2f <= vector.Y + (float)num6)
							{
								int num8 = 1;
								if (Position.X + (float)(Width / 2) < vector.X + 8f)
								{
									num8 = -1;
								}
								num5 = 15;
								return new Vector2((float)num8, (float)num5);
							}
						}
						else if (Position.X + (float)Width >= vector.X && Position.X <= vector.X + 16f && Position.Y + (float)Height >= vector.Y && Position.Y <= vector.Y + (float)num6 + 0.011f)
						{
							int num9 = 1;
							if (Position.X + (float)(Width / 2) < vector.X + 8f)
							{
								num9 = -1;
							}
							if (!fireImmune && (type == 37 || type == 58 || type == 76))
							{
								num5 = 20;
							}
							if (type == 48)
							{
								num5 = 40;
							}
							if (type == 232)
							{
								num5 = 60;
							}
							return new Vector2((float)num9, (float)num5);
						}
					}
				}
			}
			return default(Vector2);
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x001DBDCB File Offset: 0x001D9FCB
		public static bool InTileBounds(int x, int y, int lx, int ly, int hx, int hy)
		{
			return x >= lx && x <= hx && y >= ly && y <= hy;
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x001D94E0 File Offset: 0x001D76E0
		public static bool IsClearSpotTest(Vector2 position, float testMagnitude, int Width, int Height, bool fallThrough = false, bool fall2 = false, int gravDir = 1, bool checkCardinals = true, bool checkSlopes = false)
		{
			if (checkCardinals)
			{
				Vector2 vector = Vector2.UnitX * testMagnitude;
				if (Collision.TileCollision(position - vector, vector, Width, Height, fallThrough, fall2, gravDir) != vector)
				{
					return false;
				}
				vector = -Vector2.UnitX * testMagnitude;
				if (Collision.TileCollision(position - vector, vector, Width, Height, fallThrough, fall2, gravDir) != vector)
				{
					return false;
				}
				vector = Vector2.UnitY * testMagnitude;
				if (Collision.TileCollision(position - vector, vector, Width, Height, fallThrough, fall2, gravDir) != vector)
				{
					return false;
				}
				vector = -Vector2.UnitY * testMagnitude;
				if (Collision.TileCollision(position - vector, vector, Width, Height, fallThrough, fall2, gravDir) != vector)
				{
					return false;
				}
			}
			if (checkSlopes)
			{
				Vector2 vector = Vector2.UnitX * testMagnitude;
				Vector4 value = new Vector4(position, testMagnitude, 0f);
				if (Collision.SlopeCollision(position, vector, Width, Height, (float)gravDir, fallThrough) != value)
				{
					return false;
				}
				vector = -Vector2.UnitX * testMagnitude;
				value = new Vector4(position, -testMagnitude, 0f);
				if (Collision.SlopeCollision(position, vector, Width, Height, (float)gravDir, fallThrough) != value)
				{
					return false;
				}
				vector = Vector2.UnitY * testMagnitude;
				value = new Vector4(position, 0f, testMagnitude);
				if (Collision.SlopeCollision(position, vector, Width, Height, (float)gravDir, fallThrough) != value)
				{
					return false;
				}
				vector = -Vector2.UnitY * testMagnitude;
				value = new Vector4(position, 0f, -testMagnitude);
				if (Collision.SlopeCollision(position, vector, Width, Height, (float)gravDir, fallThrough) != value)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060002DD RID: 733 RVA: 0x001DCC3C File Offset: 0x001DAE3C
		public static void LaserScan(Vector2 samplingPoint, Vector2 directionUnit, float samplingWidth, float maxDistance, float[] samples)
		{
			for (int i = 0; i < samples.Length; i++)
			{
				float num = (float)i / (float)(samples.Length - 1);
				Vector2 expr_43 = samplingPoint + directionUnit.RotatedBy(1.5707963705062866, default(Vector2)) * (num - 0.5f) * samplingWidth;
				int num2 = (int)expr_43.X / 16;
				int num3 = (int)expr_43.Y / 16;
				Vector2 expr_65 = expr_43 + directionUnit * maxDistance;
				int num4 = (int)expr_65.X / 16;
				int num5 = (int)expr_65.Y / 16;
				Tuple<int, int> tuple;
				float num6;
				if (!Collision.TupleHitLine(num2, num3, num4, num5, 0, 0, new List<Tuple<int, int>>(), out tuple))
				{
					num6 = new Vector2((float)Math.Abs(num2 - tuple.Item1), (float)Math.Abs(num3 - tuple.Item2)).Length() * 16f;
				}
				else if (tuple.Item1 == num4 && tuple.Item2 == num5)
				{
					num6 = maxDistance;
				}
				else
				{
					num6 = new Vector2((float)Math.Abs(num2 - tuple.Item1), (float)Math.Abs(num3 - tuple.Item2)).Length() * 16f;
				}
				samples[i] = num6;
			}
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x001D7C90 File Offset: 0x001D5E90
		public static bool LavaCollision(Vector2 Position, int Width, int Height)
		{
			int arg_50_0 = (int)(Position.X / 16f) - 1;
			int num = (int)((Position.X + (float)Width) / 16f) + 2;
			int num2 = (int)(Position.Y / 16f) - 1;
			int num3 = (int)((Position.Y + (float)Height) / 16f) + 2;
			int arg_84_0 = Utils.Clamp<int>(arg_50_0, 0, Main.maxTilesX - 1);
			num = Utils.Clamp<int>(num, 0, Main.maxTilesX - 1);
			num2 = Utils.Clamp<int>(num2, 0, Main.maxTilesY - 1);
			num3 = Utils.Clamp<int>(num3, 0, Main.maxTilesY - 1);
			for (int i = arg_84_0; i < num; i++)
			{
				for (int j = num2; j < num3; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].liquid > 0 && Main.tile[i, j].lava())
					{
						Vector2 vector;
						vector.X = (float)(i * 16);
						vector.Y = (float)(j * 16);
						int num4 = 16;
						float num5 = (float)(256 - (int)Main.tile[i, j].liquid);
						num5 /= 32f;
						vector.Y += num5 * 2f;
						num4 -= (int)(num5 * 2f);
						if (Position.X + (float)Width > vector.X && Position.X < vector.X + 16f && Position.Y + (float)Height > vector.Y && Position.Y < vector.Y + (float)num4)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x001D8A6C File Offset: 0x001D6C6C
		public static Vector2 noSlopeCollision(Vector2 Position, Vector2 Velocity, int Width, int Height, bool fallThrough = false, bool fall2 = false)
		{
			Collision.up = false;
			Collision.down = false;
			Vector2 result = Velocity;
			Vector2 vector = Position + Velocity;
			int arg_77_0 = (int)(Position.X / 16f) - 1;
			int num = (int)((Position.X + (float)Width) / 16f) + 2;
			int num2 = (int)(Position.Y / 16f) - 1;
			int num3 = (int)((Position.Y + (float)Height) / 16f) + 2;
			int num4 = -1;
			int num5 = -1;
			int num6 = -1;
			int num7 = -1;
			int arg_B9_0 = Utils.Clamp<int>(arg_77_0, 0, Main.maxTilesX - 1);
			num = Utils.Clamp<int>(num, 0, Main.maxTilesX - 1);
			num2 = Utils.Clamp<int>(num2, 0, Main.maxTilesY - 1);
			num3 = Utils.Clamp<int>(num3, 0, Main.maxTilesY - 1);
			float num8 = (float)((num3 + 3) * 16);
			for (int i = arg_B9_0; i < num; i++)
			{
				for (int j = num2; j < num3; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].active() && (Main.tileSolid[(int)Main.tile[i, j].type] || (Main.tileSolidTop[(int)Main.tile[i, j].type] && Main.tile[i, j].frameY == 0)))
					{
						Vector2 vector2;
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16);
						int num9 = 16;
						if (Main.tile[i, j].halfBrick())
						{
							vector2.Y += 8f;
							num9 -= 8;
						}
						if (vector.X + (float)Width > vector2.X && vector.X < vector2.X + 16f && vector.Y + (float)Height > vector2.Y && vector.Y < vector2.Y + (float)num9)
						{
							if (Position.Y + (float)Height <= vector2.Y)
							{
								Collision.down = true;
								if ((!(Main.tileSolidTop[(int)Main.tile[i, j].type] & fallThrough) || !(Velocity.Y <= 1f | fall2)) && num8 > vector2.Y)
								{
									num6 = i;
									num7 = j;
									if (num9 < 16)
									{
										num7++;
									}
									if (num6 != num4)
									{
										result.Y = vector2.Y - (Position.Y + (float)Height);
										num8 = vector2.Y;
									}
								}
							}
							else if (Position.X + (float)Width <= vector2.X && !Main.tileSolidTop[(int)Main.tile[i, j].type])
							{
								num4 = i;
								num5 = j;
								if (num5 != num7)
								{
									result.X = vector2.X - (Position.X + (float)Width);
								}
								if (num6 == num4)
								{
									result.Y = Velocity.Y;
								}
							}
							else if (Position.X >= vector2.X + 16f && !Main.tileSolidTop[(int)Main.tile[i, j].type])
							{
								num4 = i;
								num5 = j;
								if (num5 != num7)
								{
									result.X = vector2.X + 16f - Position.X;
								}
								if (num6 == num4)
								{
									result.Y = Velocity.Y;
								}
							}
							else if (Position.Y >= vector2.Y + (float)num9 && !Main.tileSolidTop[(int)Main.tile[i, j].type])
							{
								Collision.up = true;
								num6 = i;
								num7 = j;
								result.Y = vector2.Y + (float)num9 - Position.Y + 0.01f;
								if (num7 == num5)
								{
									result.X = Velocity.X;
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x001D575C File Offset: 0x001D395C
		private static Vector2[] OneDimensionalIntersection(Vector2 a1, Vector2 a2, Vector2 b1, Vector2 b2)
		{
			float num = a2.X - a1.X;
			float num2 = a2.Y - a1.Y;
			float relativePoint;
			float relativePoint2;
			if (Math.Abs(num) > Math.Abs(num2))
			{
				relativePoint = (b1.X - a1.X) / num;
				relativePoint2 = (b2.X - a1.X) / num;
			}
			else
			{
				relativePoint = (b1.Y - a1.Y) / num2;
				relativePoint2 = (b2.Y - a1.Y) / num2;
			}
			List<Vector2> list = new List<Vector2>();
			float[] array = Collision.FindOverlapPoints(relativePoint, relativePoint2);
			for (int i = 0; i < array.Length; i++)
			{
				float num3 = array[i];
				float x = a2.X * num3 + a1.X * (1f - num3);
				float y = a2.Y * num3 + a1.Y * (1f - num3);
				list.Add(new Vector2(x, y));
			}
			return list.ToArray();
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x001D5730 File Offset: 0x001D3930
		private static bool PointOnLine(Vector2 p, Vector2 a1, Vector2 a2)
		{
			float num = 0f;
			return Collision.DistFromSeg(p, a1, a2, (double)Collision.Epsilon, ref num) < (double)Collision.Epsilon;
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x001D81AC File Offset: 0x001D63AC
		public static Vector4 SlopeCollision(Vector2 Position, Vector2 Velocity, int Width, int Height, float gravity = 0f, bool fall = false)
		{
			Collision.stair = false;
			Collision.stairFall = false;
			bool[] array = new bool[5];
			float y = Position.Y;
			float y2 = Position.Y;
			Collision.sloping = false;
			Vector2 vector = Position;
			Vector2 vector2 = Velocity;
			int arg_7F_0 = (int)(Position.X / 16f) - 1;
			int num = (int)((Position.X + (float)Width) / 16f) + 2;
			int num2 = (int)(Position.Y / 16f) - 1;
			int num3 = (int)((Position.Y + (float)Height) / 16f) + 2;
			int arg_B7_0 = Utils.Clamp<int>(arg_7F_0, 0, Main.maxTilesX - 1);
			num = Utils.Clamp<int>(num, 0, Main.maxTilesX - 1);
			num2 = Utils.Clamp<int>(num2, 0, Main.maxTilesY - 1);
			num3 = Utils.Clamp<int>(num3, 0, Main.maxTilesY - 1);
			for (int i = arg_B7_0; i < num; i++)
			{
				for (int j = num2; j < num3; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].active() && !Main.tile[i, j].inActive() && (Main.tileSolid[(int)Main.tile[i, j].type] || (Main.tileSolidTop[(int)Main.tile[i, j].type] && Main.tile[i, j].frameY == 0)))
					{
						Vector2 vector3;
						vector3.X = (float)(i * 16);
						vector3.Y = (float)(j * 16);
						int num4 = 16;
						if (Main.tile[i, j].halfBrick())
						{
							vector3.Y += 8f;
							num4 -= 8;
						}
						if (Position.X + (float)Width > vector3.X && Position.X < vector3.X + 16f && Position.Y + (float)Height > vector3.Y && Position.Y < vector3.Y + (float)num4)
						{
							bool flag = true;
							if (Main.tile[i, j].slope() > 0)
							{
								if (Main.tile[i, j].slope() > 2)
								{
									if (Main.tile[i, j].slope() == 3 && Position.Y + Math.Abs(Velocity.X) + 1f >= vector3.Y && Position.X >= vector3.X)
									{
										flag = true;
									}
									if (Main.tile[i, j].slope() == 4 && Position.Y + Math.Abs(Velocity.X) + 1f >= vector3.Y && Position.X + (float)Width <= vector3.X + 16f)
									{
										flag = true;
									}
								}
								else
								{
									if (Main.tile[i, j].slope() == 1 && Position.Y + (float)Height - Math.Abs(Velocity.X) - 1f <= vector3.Y + (float)num4 && Position.X >= vector3.X)
									{
										flag = true;
									}
									if (Main.tile[i, j].slope() == 2 && Position.Y + (float)Height - Math.Abs(Velocity.X) - 1f <= vector3.Y + (float)num4 && Position.X + (float)Width <= vector3.X + 16f)
									{
										flag = true;
									}
								}
							}
							if (TileID.Sets.Platforms[(int)Main.tile[i, j].type])
							{
								if (Velocity.Y < 0f)
								{
									flag = false;
								}
								if (Position.Y + (float)Height < (float)(j * 16) || Position.Y + (float)Height - (1f + Math.Abs(Velocity.X)) > (float)(j * 16 + 16))
								{
									flag = false;
								}
							}
							if (flag)
							{
								bool flag2 = false;
								if (fall && TileID.Sets.Platforms[(int)Main.tile[i, j].type])
								{
									flag2 = true;
								}
								int num5 = (int)Main.tile[i, j].slope();
								vector3.X = (float)(i * 16);
								vector3.Y = (float)(j * 16);
								if (Position.X + (float)Width > vector3.X && Position.X < vector3.X + 16f && Position.Y + (float)Height > vector3.Y && Position.Y < vector3.Y + 16f)
								{
									float num6 = 0f;
									if (num5 == 3 || num5 == 4)
									{
										if (num5 == 3)
										{
											num6 = Position.X - vector3.X;
										}
										if (num5 == 4)
										{
											num6 = vector3.X + 16f - (Position.X + (float)Width);
										}
										if (num6 >= 0f)
										{
											if (Position.Y <= vector3.Y + 16f - num6)
											{
												float num7 = vector3.Y + 16f - Position.Y - num6;
												if (Position.Y + num7 > y2)
												{
													vector.Y = Position.Y + num7;
													y2 = vector.Y;
													if (vector2.Y < 0.0101f)
													{
														vector2.Y = 0.0101f;
													}
													array[num5] = true;
												}
											}
										}
										else if (Position.Y > vector3.Y)
										{
											float num8 = vector3.Y + 16f;
											if (vector.Y < num8)
											{
												vector.Y = num8;
												if (vector2.Y < 0.0101f)
												{
													vector2.Y = 0.0101f;
												}
											}
										}
									}
									if (num5 == 1 || num5 == 2)
									{
										if (num5 == 1)
										{
											num6 = Position.X - vector3.X;
										}
										if (num5 == 2)
										{
											num6 = vector3.X + 16f - (Position.X + (float)Width);
										}
										if (num6 >= 0f)
										{
											if (Position.Y + (float)Height >= vector3.Y + num6)
											{
												float num9 = vector3.Y - (Position.Y + (float)Height) + num6;
												if (Position.Y + num9 < y)
												{
													if (flag2)
													{
														Collision.stairFall = true;
													}
													else
													{
														if (TileID.Sets.Platforms[(int)Main.tile[i, j].type])
														{
															Collision.stair = true;
														}
														else
														{
															Collision.stair = false;
														}
														vector.Y = Position.Y + num9;
														y = vector.Y;
														if (vector2.Y > 0f)
														{
															vector2.Y = 0f;
														}
														array[num5] = true;
													}
												}
											}
										}
										else if (TileID.Sets.Platforms[(int)Main.tile[i, j].type] && Position.Y + (float)Height - 4f - Math.Abs(Velocity.X) > vector3.Y)
										{
											if (flag2)
											{
												Collision.stairFall = true;
											}
										}
										else
										{
											float num10 = vector3.Y - (float)Height;
											if (vector.Y > num10)
											{
												if (flag2)
												{
													Collision.stairFall = true;
												}
												else
												{
													if (TileID.Sets.Platforms[(int)Main.tile[i, j].type])
													{
														Collision.stair = true;
													}
													else
													{
														Collision.stair = false;
													}
													vector.Y = num10;
													if (vector2.Y > 0f)
													{
														vector2.Y = 0f;
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
			Vector2 vector4 = vector - Position;
			Vector2 vector5 = Collision.TileCollision(Position, vector4, Width, Height, false, false, 1);
			if (vector5.Y > vector4.Y)
			{
				float num11 = vector4.Y - vector5.Y;
				vector.Y = Position.Y + vector5.Y;
				if (array[1])
				{
					vector.X = Position.X - num11;
				}
				if (array[2])
				{
					vector.X = Position.X + num11;
				}
				vector2.X = 0f;
				vector2.Y = 0f;
				Collision.up = false;
			}
			else if (vector5.Y < vector4.Y)
			{
				float num12 = vector5.Y - vector4.Y;
				vector.Y = Position.Y + vector5.Y;
				if (array[3])
				{
					vector.X = Position.X - num12;
				}
				if (array[4])
				{
					vector.X = Position.X + num12;
				}
				vector2.X = 0f;
				vector2.Y = 0f;
			}
			return new Vector4(vector, vector2.X, vector2.Y);
		}

		// Token: 0x060002CA RID: 714 RVA: 0x001D9C40 File Offset: 0x001D7E40
		public static bool SolidCollision(Vector2 Position, int Width, int Height)
		{
			int arg_4D_0 = (int)(Position.X / 16f) - 1;
			int num = (int)((Position.X + (float)Width) / 16f) + 2;
			int num2 = (int)(Position.Y / 16f) - 1;
			int num3 = (int)((Position.Y + (float)Height) / 16f) + 2;
			int arg_7F_0 = Utils.Clamp<int>(arg_4D_0, 0, Main.maxTilesX - 1);
			num = Utils.Clamp<int>(num, 0, Main.maxTilesX - 1);
			num2 = Utils.Clamp<int>(num2, 0, Main.maxTilesY - 1);
			num3 = Utils.Clamp<int>(num3, 0, Main.maxTilesY - 1);
			for (int i = arg_7F_0; i < num; i++)
			{
				for (int j = num2; j < num3; j++)
				{
					if (Main.tile[i, j] != null && !Main.tile[i, j].inActive() && Main.tile[i, j].active() && Main.tileSolid[(int)Main.tile[i, j].type] && !Main.tileSolidTop[(int)Main.tile[i, j].type])
					{
						Vector2 vector;
						vector.X = (float)(i * 16);
						vector.Y = (float)(j * 16);
						int num4 = 16;
						if (Main.tile[i, j].halfBrick())
						{
							vector.Y += 8f;
							num4 -= 8;
						}
						if (Position.X + (float)Width > vector.X && Position.X < vector.X + 16f && Position.Y + (float)Height > vector.Y && Position.Y < vector.Y + (float)num4)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x001DB308 File Offset: 0x001D9508
		public static bool SolidTiles(int startX, int endX, int startY, int endY)
		{
			if (startX < 0)
			{
				return true;
			}
			if (endX >= Main.maxTilesX)
			{
				return true;
			}
			if (startY < 0)
			{
				return true;
			}
			if (endY >= Main.maxTilesY)
			{
				return true;
			}
			for (int i = startX; i < endX + 1; i++)
			{
				for (int j = startY; j < endY + 1; j++)
				{
					if (Main.tile[i, j] == null)
					{
						return false;
					}
					if (Main.tile[i, j].active() && !Main.tile[i, j].inActive() && Main.tileSolid[(int)Main.tile[i, j].type] && !Main.tileSolidTop[(int)Main.tile[i, j].type])
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x001DB2E3 File Offset: 0x001D94E3
		public static bool SolidTilesVersatile(int startX, int endX, int startY, int endY)
		{
			if (startX > endX)
			{
				Utils.Swap<int>(ref startX, ref endX);
			}
			if (startY > endY)
			{
				Utils.Swap<int>(ref startY, ref endY);
			}
			return Collision.SolidTiles(startX, endX, startY, endY);
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x001DC0A4 File Offset: 0x001DA2A4
		public static void StepConveyorBelt(Entity entity, float gravDir)
		{
			if (entity is Player)
			{
				Player player = (Player)entity;
				if (Math.Abs(player.gfxOffY) > 2f || player.grapCount > 0 || player.pulley)
				{
					return;
				}
			}
			int num = 0;
			int num2 = 0;
			bool flag = false;
			int arg_49_0 = (int)entity.position.Y;
			int arg_50_0 = entity.height;
			entity.Hitbox.Inflate(2, 2);
			Vector2 arg_67_0 = entity.TopLeft;
			Vector2 arg_6E_0 = entity.TopRight;
			Vector2 arg_75_0 = entity.BottomLeft;
			Vector2 arg_7C_0 = entity.BottomRight;
			List<Point> arg_93_0 = Collision.GetEntityEdgeTiles(entity, false, false, true, true);
			Vector2 vector = new Vector2(0.0001f);
			foreach (Point current in arg_93_0)
			{
				Tile tile = Main.tile[current.X, current.Y];
				if (tile != null && tile.active() && tile.nactive())
				{
					int num3 = TileID.Sets.ConveyorDirection[(int)tile.type];
					if (num3 != 0)
					{
						Vector2 lineStart;
						Vector2 lineStart2;
						lineStart.X = (lineStart2.X = (float)(current.X * 16));
						Vector2 lineEnd;
						Vector2 lineEnd2;
						lineEnd.X = (lineEnd2.X = (float)(current.X * 16 + 16));
						switch (tile.slope())
						{
							case 1:
								lineStart2.Y = (float)(current.Y * 16);
								lineEnd2.Y = (lineEnd.Y = (lineStart.Y = (float)(current.Y * 16 + 16)));
								break;
							case 2:
								lineEnd2.Y = (float)(current.Y * 16);
								lineStart2.Y = (lineEnd.Y = (lineStart.Y = (float)(current.Y * 16 + 16)));
								break;
							case 3:
								lineEnd.Y = (lineStart2.Y = (lineEnd2.Y = (float)(current.Y * 16)));
								lineStart.Y = (float)(current.Y * 16 + 16);
								break;
							case 4:
								lineStart.Y = (lineStart2.Y = (lineEnd2.Y = (float)(current.Y * 16)));
								lineEnd.Y = (float)(current.Y * 16 + 16);
								break;
							default:
								if (tile.halfBrick())
								{
									lineStart2.Y = (lineEnd2.Y = (float)(current.Y * 16 + 8));
								}
								else
								{
									lineStart2.Y = (lineEnd2.Y = (float)(current.Y * 16));
								}
								lineStart.Y = (lineEnd.Y = (float)(current.Y * 16 + 16));
								break;
						}
						int num4 = 0;
						if (!TileID.Sets.Platforms[(int)tile.type] && Collision.CheckAABBvLineCollision2(entity.position - vector, entity.Size + vector * 2f, lineStart, lineEnd))
						{
							num4--;
						}
						if (Collision.CheckAABBvLineCollision2(entity.position - vector, entity.Size + vector * 2f, lineStart2, lineEnd2))
						{
							num4++;
						}
						if (num4 != 0)
						{
							flag = true;
							num += num3 * num4 * (int)gravDir;
							if (tile.leftSlope())
							{
								num2 += (int)gravDir * -num3;
							}
							if (tile.rightSlope())
							{
								num2 -= (int)gravDir * -num3;
							}
						}
					}
				}
			}
			if (!flag)
			{
				return;
			}
			if (num != 0)
			{
				num = Math.Sign(num);
				num2 = Math.Sign(num2);
				Vector2 velocity = Vector2.Normalize(new Vector2((float)num * gravDir, (float)num2)) * 2.5f;
				Vector2 value = Collision.TileCollision(entity.position, velocity, entity.width, entity.height, false, false, (int)gravDir);
				entity.position += value;
				velocity = new Vector2(0f, 2.5f * gravDir);
				value = Collision.TileCollision(entity.position, velocity, entity.width, entity.height, false, false, (int)gravDir);
				entity.position += value;
			}
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x001DB3C0 File Offset: 0x001D95C0
		public static void StepDown(ref Vector2 position, ref Vector2 velocity, int width, int height, ref float stepSpeed, ref float gfxOffY, int gravDir = 1, bool waterWalk = false)
		{
			Vector2 vector = position;
			vector.X += velocity.X;
			vector.Y = (float)Math.Floor((double)((vector.Y + (float)height) / 16f)) * 16f - (float)height;
			bool flag = false;
			int arg_A3_0 = (int)(vector.X / 16f);
			int num = (int)((vector.X + (float)width) / 16f);
			int num2 = (int)((vector.Y + (float)height + 4f) / 16f);
			int num3 = height / 16 + ((height % 16 == 0) ? 0 : 1);
			float num4 = (float)((num2 + num3) * 16);
			float num5 = Main.bottomWorld / 16f - 42f;
			for (int i = arg_A3_0; i <= num; i++)
			{
				for (int j = num2; j <= num2 + 1; j++)
				{
					if (WorldGen.InWorld(i, j, 1))
					{
						if (Main.tile[i, j] == null)
						{
							Main.tile[i, j] = new Tile();
						}
						if (Main.tile[i, j - 1] == null)
						{
							Main.tile[i, j - 1] = new Tile();
						}
						if (Main.tile[i, j].topSlope())
						{
							flag = true;
						}
						if (waterWalk && Main.tile[i, j].liquid > 0 && Main.tile[i, j - 1].liquid == 0)
						{
							int num6 = (int)(Main.tile[i, j].liquid / 32 * 2 + 2);
							int num7 = j * 16 + 16 - num6;
							Rectangle rectangle = new Rectangle(i * 16, j * 16 - 17, 16, 16);
							if (rectangle.Intersects(new Rectangle((int)position.X, (int)position.Y, width, height)) && (float)num7 < num4)
							{
								num4 = (float)num7;
							}
						}
						if ((float)j >= num5 || (Main.tile[i, j].nactive() && (Main.tileSolid[(int)Main.tile[i, j].type] || Main.tileSolidTop[(int)Main.tile[i, j].type])))
						{
							int num8 = j * 16;
							if (Main.tile[i, j].halfBrick())
							{
								num8 += 8;
							}
							if (Utils.FloatIntersect((float)(i * 16), (float)(j * 16 - 17), 16f, 16f, position.X, position.Y, (float)width, (float)height) && (float)num8 < num4)
							{
								num4 = (float)num8;
							}
						}
					}
				}
			}
			float num9 = num4 - (position.Y + (float)height);
			if (num9 > 7f && num9 < 17f && !flag)
			{
				stepSpeed = 1.5f;
				if (num9 > 9f)
				{
					stepSpeed = 2.5f;
				}
				gfxOffY += position.Y + (float)height - num4;
				position.Y = num4 - (float)height;
			}
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x001DB6BC File Offset: 0x001D98BC
		public static void StepUp(ref Vector2 position, ref Vector2 velocity, int width, int height, ref float stepSpeed, ref float gfxOffY, int gravDir = 1, bool holdsMatching = false, int specialChecksMode = 0)
		{
			int num = 0;
			if (velocity.X < 0f)
			{
				num = -1;
			}
			if (velocity.X > 0f)
			{
				num = 1;
			}
			Vector2 vector = position;
			vector.X += velocity.X;
			int num2 = (int)((vector.X + (float)(width / 2) + (float)((width / 2 + 1) * num)) / 16f);
			int num3 = (int)(((double)vector.Y + 0.1) / 16.0);
			if (gravDir == 1)
			{
				num3 = (int)((vector.Y + (float)height - 1f) / 16f);
			}
			int num4 = height / 16 + ((height % 16 == 0) ? 0 : 1);
			bool flag = true;
			bool flag2 = true;
			if (Main.tile[num2, num3] == null)
			{
				return;
			}
			for (int i = 1; i < num4 + 2; i++)
			{
				if (!WorldGen.InWorld(num2, num3 - i * gravDir, 0) || Main.tile[num2, num3 - i * gravDir] == null)
				{
					return;
				}
			}
			if (!WorldGen.InWorld(num2 - num, num3 - num4 * gravDir, 0) || Main.tile[num2 - num, num3 - num4 * gravDir] == null)
			{
				return;
			}
			Tile tile;
			for (int j = 2; j < num4 + 1; j++)
			{
				if (!WorldGen.InWorld(num2, num3 - j * gravDir, 0))
				{
					return;
				}
				if (Main.tile[num2, num3 - j * gravDir] == null)
				{
					return;
				}
				tile = Main.tile[num2, num3 - j * gravDir];
				flag = (flag && (!tile.nactive() || !Main.tileSolid[(int)tile.type] || Main.tileSolidTop[(int)tile.type]));
			}
			tile = Main.tile[num2 - num, num3 - num4 * gravDir];
			flag2 = (flag2 && (!tile.nactive() || !Main.tileSolid[(int)tile.type] || Main.tileSolidTop[(int)tile.type]));
			bool flag3 = true;
			bool flag4 = true;
			bool flag5 = true;
			if (gravDir == 1)
			{
				if (Main.tile[num2, num3 - gravDir] == null)
				{
					return;
				}
				if (Main.tile[num2, num3 - (num4 + 1) * gravDir] == null)
				{
					return;
				}
				tile = Main.tile[num2, num3 - gravDir];
				Tile tile2 = Main.tile[num2, num3 - (num4 + 1) * gravDir];
				flag3 = (flag3 && (!tile.nactive() || !Main.tileSolid[(int)tile.type] || Main.tileSolidTop[(int)tile.type] || (tile.slope() == 1 && position.X + (float)(width / 2) > (float)(num2 * 16)) || (tile.slope() == 2 && position.X + (float)(width / 2) < (float)(num2 * 16 + 16)) || (tile.halfBrick() && (!tile2.nactive() || !Main.tileSolid[(int)tile2.type] || Main.tileSolidTop[(int)tile2.type]))));
				tile = Main.tile[num2, num3];
				tile2 = Main.tile[num2, num3 - 1];
				if (specialChecksMode == 1)
				{
					flag5 = (tile.type != 16 && tile.type != 18 && tile.type != 134);
				}
				flag4 = (flag4 && ((tile.nactive() && (!tile.topSlope() || (tile.slope() == 1 && position.X + (float)(width / 2) < (float)(num2 * 16)) || (tile.slope() == 2 && position.X + (float)(width / 2) > (float)(num2 * 16 + 16))) && (!tile.topSlope() || position.Y + (float)height > (float)(num3 * 16)) && ((Main.tileSolid[(int)tile.type] && !Main.tileSolidTop[(int)tile.type]) || ((holdsMatching && ((Main.tileSolidTop[(int)tile.type] && tile.frameY == 0) || TileID.Sets.Platforms[(int)tile.type]) && (!Main.tileSolid[(int)tile2.type] || !tile2.nactive())) & flag5))) || (tile2.halfBrick() && tile2.nactive())));
				flag4 &= (!Main.tileSolidTop[(int)tile.type] || !Main.tileSolidTop[(int)tile2.type]);
			}
			else
			{
				tile = Main.tile[num2, num3 - gravDir];
				Tile tile2 = Main.tile[num2, num3 - (num4 + 1) * gravDir];
				flag3 = (flag3 && (!tile.nactive() || !Main.tileSolid[(int)tile.type] || Main.tileSolidTop[(int)tile.type] || tile.slope() != 0 || (tile.halfBrick() && (!tile2.nactive() || !Main.tileSolid[(int)tile2.type] || Main.tileSolidTop[(int)tile2.type]))));
				tile = Main.tile[num2, num3];
				tile2 = Main.tile[num2, num3 + 1];
				flag4 = (flag4 && ((tile.nactive() && ((Main.tileSolid[(int)tile.type] && !Main.tileSolidTop[(int)tile.type]) || (holdsMatching && Main.tileSolidTop[(int)tile.type] && tile.frameY == 0 && (!Main.tileSolid[(int)tile2.type] || !tile2.nactive())))) || (tile2.halfBrick() && tile2.nactive())));
			}
			if ((float)(num2 * 16) < vector.X + (float)width && (float)(num2 * 16 + 16) > vector.X)
			{
				if (gravDir == 1)
				{
					if (flag4 & flag3 & flag & flag2)
					{
						float num5 = (float)(num3 * 16);
						if (Main.tile[num2, num3 - 1].halfBrick())
						{
							num5 -= 8f;
						}
						else if (Main.tile[num2, num3].halfBrick())
						{
							num5 += 8f;
						}
						if (num5 < vector.Y + (float)height)
						{
							float num6 = vector.Y + (float)height - num5;
							if ((double)num6 <= 16.1)
							{
								gfxOffY += position.Y + (float)height - num5;
								position.Y = num5 - (float)height;
								if (num6 < 9f)
								{
									stepSpeed = 1f;
									return;
								}
								stepSpeed = 2f;
								return;
							}
						}
					}
				}
				else if ((flag4 & flag3 & flag & flag2) && !Main.tile[num2, num3].bottomSlope())
				{
					float num7 = (float)(num3 * 16 + 16);
					if (num7 > vector.Y)
					{
						float num8 = num7 - vector.Y;
						if ((double)num8 <= 16.1)
						{
							gfxOffY -= num7 - position.Y;
							position.Y = num7;
							velocity.Y = 0f;
							if (num8 < 9f)
							{
								stepSpeed = 1f;
								return;
							}
							stepSpeed = 2f;
						}
					}
				}
			}
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x001DAF4C File Offset: 0x001D914C
		public static Vector2 StickyTiles(Vector2 Position, Vector2 Velocity, int Width, int Height)
		{
			int num = (int)(Position.X / 16f) - 1;
			int num2 = (int)((Position.X + (float)Width) / 16f) + 2;
			int num3 = (int)(Position.Y / 16f) - 1;
			int num4 = (int)((Position.Y + (float)Height) / 16f) + 2;
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
					if (Main.tile[i, j] != null && Main.tile[i, j].active() && !Main.tile[i, j].inActive())
					{
						if (Main.tile[i, j].type == 51)
						{
							int num5 = 0;
							Vector2 vector;
							vector.X = (float)(i * 16);
							vector.Y = (float)(j * 16);
							if (Position.X + (float)Width > vector.X - (float)num5 && Position.X < vector.X + 16f + (float)num5 && Position.Y + (float)Height > vector.Y && (double)Position.Y < (double)vector.Y + 16.01)
							{
								if (Main.tile[i, j].type == 51 && (double)(Math.Abs(Velocity.X) + Math.Abs(Velocity.Y)) > 0.7 && Main.rand.Next(30) == 0)
								{
									Dust.NewDust(new Vector2((float)(i * 16), (float)(j * 16)), 16, 16, 30, 0f, 0f, 0, default(Color), 1f);
								}
								return new Vector2((float)i, (float)j);
							}
						}
						else if (Main.tile[i, j].type == 229 && Main.tile[i, j].slope() == 0)
						{
							int num6 = 1;
							Vector2 vector;
							vector.X = (float)(i * 16);
							vector.Y = (float)(j * 16);
							float num7 = 16.01f;
							if (Main.tile[i, j].halfBrick())
							{
								vector.Y += 8f;
								num7 -= 8f;
							}
							if (Position.X + (float)Width > vector.X - (float)num6 && Position.X < vector.X + 16f + (float)num6 && Position.Y + (float)Height > vector.Y && Position.Y < vector.Y + num7)
							{
								if (Main.tile[i, j].type == 51 && (double)(Math.Abs(Velocity.X) + Math.Abs(Velocity.Y)) > 0.7 && Main.rand.Next(30) == 0)
								{
									Dust.NewDust(new Vector2((float)(i * 16), (float)(j * 16)), 16, 16, 30, 0f, 0f, 0, default(Color), 1f);
								}
								return new Vector2((float)i, (float)j);
							}
						}
					}
				}
			}
			return new Vector2(-1f, -1f);
		}

		// Token: 0x060002CF RID: 719 RVA: 0x001DAABC File Offset: 0x001D8CBC
		public static bool SwitchTiles(Vector2 Position, int Width, int Height, Vector2 oldPosition, int objType)
		{
			int num = (int)(Position.X / 16f) - 1;
			int num2 = (int)((Position.X + (float)Width) / 16f) + 2;
			int num3 = (int)(Position.Y / 16f) - 1;
			int num4 = (int)((Position.Y + (float)Height) / 16f) + 2;
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
					if (Main.tile[i, j] != null)
					{
						int type = (int)Main.tile[i, j].type;
						if (Main.tile[i, j].active() && (type == 135 || type == 210 || type == 442))
						{
							Vector2 vector;
							vector.X = (float)(i * 16);
							vector.Y = (float)(j * 16 + 12);
							bool flag = false;
							if (objType == 4)
							{
								if (type == 442)
								{
									float r1StartX = 0f;
									float r1StartY = 0f;
									float r1Width = 0f;
									float r1Height = 0f;
									switch (Main.tile[i, j].frameX / 22)
									{
										case 0:
											r1StartX = (float)(i * 16);
											r1StartY = (float)(j * 16 + 16 - 10);
											r1Width = 16f;
											r1Height = 10f;
											break;
										case 1:
											r1StartX = (float)(i * 16);
											r1StartY = (float)(j * 16);
											r1Width = 16f;
											r1Height = 10f;
											break;
										case 2:
											r1StartX = (float)(i * 16);
											r1StartY = (float)(j * 16);
											r1Width = 10f;
											r1Height = 16f;
											break;
										case 3:
											r1StartX = (float)(i * 16 + 16 - 10);
											r1StartY = (float)(j * 16);
											r1Width = 10f;
											r1Height = 16f;
											break;
									}
									if (Utils.FloatIntersect(r1StartX, r1StartY, r1Width, r1Height, Position.X, Position.Y, (float)Width, (float)Height) && !Utils.FloatIntersect(r1StartX, r1StartY, r1Width, r1Height, oldPosition.X, oldPosition.Y, (float)Width, (float)Height))
									{
										Wiring.HitSwitch(i, j);
										NetMessage.SendData(59, -1, -1, null, i, (float)j, 0f, 0f, 0, 0, 0);
										return true;
									}
								}
								flag = true;
							}
							if (!flag && Position.X + (float)Width > vector.X && Position.X < vector.X + 16f && Position.Y + (float)Height > vector.Y && (double)Position.Y < (double)vector.Y + 4.01)
							{
								if (type == 210)
								{
									WorldGen.ExplodeMine(i, j);
								}
								else if (type != 442 && (oldPosition.X + (float)Width <= vector.X || oldPosition.X >= vector.X + 16f || oldPosition.Y + (float)Height <= vector.Y || (double)oldPosition.Y >= (double)vector.Y + 16.01))
								{
									int num5 = (int)(Main.tile[i, j].frameY / 18);
									bool flag2 = true;
									if ((num5 == 4 || num5 == 2 || num5 == 3 || num5 == 6) && objType != 1)
									{
										flag2 = false;
									}
									if (num5 == 5 && (objType == 1 || objType == 4))
									{
										flag2 = false;
									}
									if (flag2)
									{
										Wiring.HitSwitch(i, j);
										NetMessage.SendData(59, -1, -1, null, i, (float)j, 0f, 0f, 0, 0, 0);
										return true;
									}
								}
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x001DAE88 File Offset: 0x001D9088
		public bool SwitchTilesNew(Vector2 Position, int Width, int Height, Vector2 oldPosition, int objType)
		{
			Point arg_1B_0 = Position.ToTileCoordinates();
			Point point = (Position + new Vector2((float)Width, (float)Height)).ToTileCoordinates();
			int num = Utils.Clamp<int>(arg_1B_0.X, 0, Main.maxTilesX - 1);
			int num2 = Utils.Clamp<int>(arg_1B_0.Y, 0, Main.maxTilesY - 1);
			int num3 = Utils.Clamp<int>(point.X, 0, Main.maxTilesX - 1);
			int num4 = Utils.Clamp<int>(point.Y, 0, Main.maxTilesY - 1);
			for (int i = num; i <= num3; i++)
			{
				for (int j = num2; j <= num4; j++)
				{
					if (Main.tile[i, j] != null)
					{
						ushort arg_9E_0 = Main.tile[i, j].type;
					}
				}
			}
			return false;
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x001D8E64 File Offset: 0x001D7064
		public static Vector2 TileCollision(Vector2 Position, Vector2 Velocity, int Width, int Height, bool fallThrough = false, bool fall2 = false, int gravDir = 1)
		{
			Collision.up = false;
			Collision.down = false;
			Vector2 result = Velocity;
			Vector2 vector = Position + Velocity;
			int arg_77_0 = (int)(Position.X / 16f) - 1;
			int num = (int)((Position.X + (float)Width) / 16f) + 2;
			int num2 = (int)(Position.Y / 16f) - 1;
			int num3 = (int)((Position.Y + (float)Height) / 16f) + 2;
			int num4 = -1;
			int num5 = -1;
			int num6 = -1;
			int num7 = -1;
			int arg_B9_0 = Utils.Clamp<int>(arg_77_0, 0, Main.maxTilesX - 1);
			num = Utils.Clamp<int>(num, 0, Main.maxTilesX - 1);
			num2 = Utils.Clamp<int>(num2, 0, Main.maxTilesY - 1);
			num3 = Utils.Clamp<int>(num3, 0, Main.maxTilesY - 1);
			float num8 = (float)((num3 + 3) * 16);
			for (int i = arg_B9_0; i < num; i++)
			{
				for (int j = num2; j < num3; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].active() && !Main.tile[i, j].inActive() && (Main.tileSolid[(int)Main.tile[i, j].type] || (Main.tileSolidTop[(int)Main.tile[i, j].type] && Main.tile[i, j].frameY == 0)))
					{
						Vector2 vector2;
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16);
						int num9 = 16;
						if (Main.tile[i, j].halfBrick())
						{
							vector2.Y += 8f;
							num9 -= 8;
						}
						if (vector.X + (float)Width > vector2.X && vector.X < vector2.X + 16f && vector.Y + (float)Height > vector2.Y && vector.Y < vector2.Y + (float)num9)
						{
							bool flag = false;
							bool flag2 = false;
							if (Main.tile[i, j].slope() > 2)
							{
								if (Main.tile[i, j].slope() == 3 && Position.Y + Math.Abs(Velocity.X) >= vector2.Y && Position.X >= vector2.X)
								{
									flag2 = true;
								}
								if (Main.tile[i, j].slope() == 4 && Position.Y + Math.Abs(Velocity.X) >= vector2.Y && Position.X + (float)Width <= vector2.X + 16f)
								{
									flag2 = true;
								}
							}
							else if (Main.tile[i, j].slope() > 0)
							{
								flag = true;
								if (Main.tile[i, j].slope() == 1 && Position.Y + (float)Height - Math.Abs(Velocity.X) <= vector2.Y + (float)num9 && Position.X >= vector2.X)
								{
									flag2 = true;
								}
								if (Main.tile[i, j].slope() == 2 && Position.Y + (float)Height - Math.Abs(Velocity.X) <= vector2.Y + (float)num9 && Position.X + (float)Width <= vector2.X + 16f)
								{
									flag2 = true;
								}
							}
							if (!flag2)
							{
								if (Position.Y + (float)Height <= vector2.Y)
								{
									Collision.down = true;
									if ((!(Main.tileSolidTop[(int)Main.tile[i, j].type] & fallThrough) || !(Velocity.Y <= 1f | fall2)) && num8 > vector2.Y)
									{
										num6 = i;
										num7 = j;
										if (num9 < 16)
										{
											num7++;
										}
										if (num6 != num4 && !flag)
										{
											result.Y = vector2.Y - (Position.Y + (float)Height) + ((gravDir == -1) ? -0.01f : 0f);
											num8 = vector2.Y;
										}
									}
								}
								else if (Position.X + (float)Width <= vector2.X && !Main.tileSolidTop[(int)Main.tile[i, j].type])
								{
									if (Main.tile[i - 1, j] == null)
									{
										Main.tile[i - 1, j] = new Tile();
									}
									if (Main.tile[i - 1, j].slope() != 2 && Main.tile[i - 1, j].slope() != 4)
									{
										num4 = i;
										num5 = j;
										if (num5 != num7)
										{
											result.X = vector2.X - (Position.X + (float)Width);
										}
										if (num6 == num4)
										{
											result.Y = Velocity.Y;
										}
									}
								}
								else if (Position.X >= vector2.X + 16f && !Main.tileSolidTop[(int)Main.tile[i, j].type])
								{
									if (Main.tile[i + 1, j] == null)
									{
										Main.tile[i + 1, j] = new Tile();
									}
									if (Main.tile[i + 1, j].slope() != 1 && Main.tile[i + 1, j].slope() != 3)
									{
										num4 = i;
										num5 = j;
										if (num5 != num7)
										{
											result.X = vector2.X + 16f - Position.X;
										}
										if (num6 == num4)
										{
											result.Y = Velocity.Y;
										}
									}
								}
								else if (Position.Y >= vector2.Y + (float)num9 && !Main.tileSolidTop[(int)Main.tile[i, j].type])
								{
									Collision.up = true;
									num6 = i;
									num7 = j;
									result.Y = vector2.Y + (float)num9 - Position.Y + ((gravDir == 1) ? 0.01f : 0f);
									if (num7 == num5)
									{
										result.X = Velocity.X;
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060002BC RID: 700 RVA: 0x001D6CB0 File Offset: 0x001D4EB0
		public static bool TupleHitLine(int x1, int y1, int x2, int y2, int ignoreX, int ignoreY, List<Tuple<int, int>> ignoreTargets, out Tuple<int, int> col)
		{
			int num = Utils.Clamp<int>(x1, 1, Main.maxTilesX - 1);
			int num2 = Utils.Clamp<int>(x2, 1, Main.maxTilesX - 1);
			int num3 = Utils.Clamp<int>(y1, 1, Main.maxTilesY - 1);
			int num4 = Utils.Clamp<int>(y2, 1, Main.maxTilesY - 1);
			float num5 = (float)Math.Abs(num - num2);
			float num6 = (float)Math.Abs(num3 - num4);
			if (num5 == 0f && num6 == 0f)
			{
				col = new Tuple<int, int>(num, num3);
				return true;
			}
			float num7 = 1f;
			float num8 = 1f;
			if (num5 == 0f || num6 == 0f)
			{
				if (num5 == 0f)
				{
					num7 = 0f;
				}
				if (num6 == 0f)
				{
					num8 = 0f;
				}
			}
			else if (num5 > num6)
			{
				num7 = num5 / num6;
			}
			else
			{
				num8 = num6 / num5;
			}
			float num9 = 0f;
			float num10 = 0f;
			int num11 = 1;
			if (num3 < num4)
			{
				num11 = 2;
			}
			int num12 = (int)num5;
			int num13 = (int)num6;
			int num14 = Math.Sign(num2 - num);
			int num15 = Math.Sign(num4 - num3);
			bool flag = false;
			bool flag2 = false;
			bool result;
			try
			{
				while (true)
				{
					if (num11 == 2)
					{
						num9 += num7;
						int num16 = (int)num9;
						num9 %= 1f;
						for (int i = 0; i < num16; i++)
						{
							if (Main.tile[num, num3 - 1] == null)
							{
								goto Block_10;
							}
							if (Main.tile[num, num3 + 1] == null)
							{
								goto Block_11;
							}
							Tile tile = Main.tile[num, num3 - 1];
							Tile tile2 = Main.tile[num, num3 + 1];
							Tile tile3 = Main.tile[num, num3];
							if (!ignoreTargets.Contains(new Tuple<int, int>(num, num3)) && !ignoreTargets.Contains(new Tuple<int, int>(num, num3 - 1)) && !ignoreTargets.Contains(new Tuple<int, int>(num, num3 + 1)))
							{
								if (ignoreY != -1 && num15 < 0 && !tile.inActive() && tile.active() && Main.tileSolid[(int)tile.type] && !Main.tileSolidTop[(int)tile.type])
								{
									goto Block_20;
								}
								if (ignoreY != 1 && num15 > 0 && !tile2.inActive() && tile2.active() && Main.tileSolid[(int)tile2.type] && !Main.tileSolidTop[(int)tile2.type])
								{
									goto Block_26;
								}
								if (!tile3.inActive() && tile3.active() && Main.tileSolid[(int)tile3.type] && !Main.tileSolidTop[(int)tile3.type])
								{
									goto Block_30;
								}
							}
							if (num12 == 0 && num13 == 0)
							{
								flag = true;
								break;
							}
							num += num14;
							num12--;
							if (num12 == 0 && num13 == 0 && num16 == 1)
							{
								flag2 = true;
							}
						}
						if (num13 != 0)
						{
							num11 = 1;
						}
					}
					else if (num11 == 1)
					{
						num10 += num8;
						int num17 = (int)num10;
						num10 %= 1f;
						for (int j = 0; j < num17; j++)
						{
							if (Main.tile[num - 1, num3] == null)
							{
								goto Block_38;
							}
							if (Main.tile[num + 1, num3] == null)
							{
								goto Block_39;
							}
							Tile tile4 = Main.tile[num - 1, num3];
							Tile tile5 = Main.tile[num + 1, num3];
							Tile tile6 = Main.tile[num, num3];
							if (!ignoreTargets.Contains(new Tuple<int, int>(num, num3)) && !ignoreTargets.Contains(new Tuple<int, int>(num - 1, num3)) && !ignoreTargets.Contains(new Tuple<int, int>(num + 1, num3)))
							{
								if (ignoreX != -1 && num14 < 0 && !tile4.inActive() && tile4.active() && Main.tileSolid[(int)tile4.type] && !Main.tileSolidTop[(int)tile4.type])
								{
									goto Block_48;
								}
								if (ignoreX != 1 && num14 > 0 && !tile5.inActive() && tile5.active() && Main.tileSolid[(int)tile5.type] && !Main.tileSolidTop[(int)tile5.type])
								{
									goto Block_54;
								}
								if (!tile6.inActive() && tile6.active() && Main.tileSolid[(int)tile6.type] && !Main.tileSolidTop[(int)tile6.type])
								{
									goto Block_58;
								}
							}
							if (num12 == 0 && num13 == 0)
							{
								flag = true;
								break;
							}
							num3 += num15;
							num13--;
							if (num12 == 0 && num13 == 0 && num17 == 1)
							{
								flag2 = true;
							}
						}
						if (num12 != 0)
						{
							num11 = 2;
						}
					}
					if (Main.tile[num, num3] == null)
					{
						goto Block_65;
					}
					Tile tile7 = Main.tile[num, num3];
					if (!ignoreTargets.Contains(new Tuple<int, int>(num, num3)) && !tile7.inActive() && tile7.active() && Main.tileSolid[(int)tile7.type] && !Main.tileSolidTop[(int)tile7.type])
					{
						goto Block_70;
					}
					if (flag | flag2)
					{
						goto Block_71;
					}
				}
				Block_10:
				col = new Tuple<int, int>(num, num3 - 1);
				result = false;
				return result;
				Block_11:
				col = new Tuple<int, int>(num, num3 + 1);
				result = false;
				return result;
				Block_20:
				col = new Tuple<int, int>(num, num3 - 1);
				result = true;
				return result;
				Block_26:
				col = new Tuple<int, int>(num, num3 + 1);
				result = true;
				return result;
				Block_30:
				col = new Tuple<int, int>(num, num3);
				result = true;
				return result;
				Block_38:
				col = new Tuple<int, int>(num - 1, num3);
				result = false;
				return result;
				Block_39:
				col = new Tuple<int, int>(num + 1, num3);
				result = false;
				return result;
				Block_48:
				col = new Tuple<int, int>(num - 1, num3);
				result = true;
				return result;
				Block_54:
				col = new Tuple<int, int>(num + 1, num3);
				result = true;
				return result;
				Block_58:
				col = new Tuple<int, int>(num, num3);
				result = true;
				return result;
				Block_65:
				col = new Tuple<int, int>(num, num3);
				result = false;
				return result;
				Block_70:
				col = new Tuple<int, int>(num, num3);
				result = true;
				return result;
				Block_71:
				col = new Tuple<int, int>(num, num3);
				result = true;
			}
			catch
			{
				col = new Tuple<int, int>(x1, y1);
				result = false;
			}
			return result;
		}

		// Token: 0x060002BD RID: 701 RVA: 0x001D7280 File Offset: 0x001D5480
		public static Tuple<int, int> TupleHitLineWall(int x1, int y1, int x2, int y2)
		{
			int num = x1;
			int num2 = y1;
			int num3 = x2;
			int num4 = y2;
			if (num <= 1)
			{
				num = 1;
			}
			if (num >= Main.maxTilesX)
			{
				num = Main.maxTilesX - 1;
			}
			if (num3 <= 1)
			{
				num3 = 1;
			}
			if (num3 >= Main.maxTilesX)
			{
				num3 = Main.maxTilesX - 1;
			}
			if (num2 <= 1)
			{
				num2 = 1;
			}
			if (num2 >= Main.maxTilesY)
			{
				num2 = Main.maxTilesY - 1;
			}
			if (num4 <= 1)
			{
				num4 = 1;
			}
			if (num4 >= Main.maxTilesY)
			{
				num4 = Main.maxTilesY - 1;
			}
			float num5 = (float)Math.Abs(num - num3);
			float num6 = (float)Math.Abs(num2 - num4);
			if (num5 == 0f && num6 == 0f)
			{
				return new Tuple<int, int>(num, num2);
			}
			float num7 = 1f;
			float num8 = 1f;
			if (num5 == 0f || num6 == 0f)
			{
				if (num5 == 0f)
				{
					num7 = 0f;
				}
				if (num6 == 0f)
				{
					num8 = 0f;
				}
			}
			else if (num5 > num6)
			{
				num7 = num5 / num6;
			}
			else
			{
				num8 = num6 / num5;
			}
			float num9 = 0f;
			float num10 = 0f;
			int num11 = 1;
			if (num2 < num4)
			{
				num11 = 2;
			}
			int num12 = (int)num5;
			int num13 = (int)num6;
			int num14 = Math.Sign(num3 - num);
			int num15 = Math.Sign(num4 - num2);
			bool flag = false;
			bool flag2 = false;
			Tuple<int, int> result;
			try
			{
				while (true)
				{
					if (num11 == 2)
					{
						num9 += num7;
						int num16 = (int)num9;
						num9 %= 1f;
						for (int i = 0; i < num16; i++)
						{
							//TODO: 看看这是做什么的   //							Main.tile[num, num2];
							if (Collision.HitWallSubstep(num, num2))
							{
								goto Block_18;
							}
							if (num12 == 0 && num13 == 0)
							{
								flag = true;
								break;
							}
							num += num14;
							num12--;
							if (num12 == 0 && num13 == 0 && num16 == 1)
							{
								flag2 = true;
							}
						}
						if (num13 != 0)
						{
							num11 = 1;
						}
					}
					else if (num11 == 1)
					{
						num10 += num8;
						int num17 = (int)num10;
						num10 %= 1f;
						for (int j = 0; j < num17; j++)
						{
							//TODO: 看看这是做什么的   //							Main.tile[num, num2];
							if (Collision.HitWallSubstep(num, num2))
							{
								goto Block_26;
							}
							if (num12 == 0 && num13 == 0)
							{
								flag = true;
								break;
							}
							num2 += num15;
							num13--;
							if (num12 == 0 && num13 == 0 && num17 == 1)
							{
								flag2 = true;
							}
						}
						if (num12 != 0)
						{
							num11 = 2;
						}
					}
					if (Main.tile[num, num2] == null)
					{
						goto Block_33;
					}
					//TODO: 看看这是做什么的   //					Main.tile[num, num2];
					if (Collision.HitWallSubstep(num, num2))
					{
						goto Block_34;
					}
					if (flag | flag2)
					{
						goto Block_35;
					}
				}
				Block_18:
				result = new Tuple<int, int>(num, num2);
				return result;
				Block_26:
				result = new Tuple<int, int>(num, num2);
				return result;
				Block_33:
				result = new Tuple<int, int>(-1, -1);
				return result;
				Block_34:
				result = new Tuple<int, int>(num, num2);
				return result;
				Block_35:
				result = new Tuple<int, int>(num, num2);
			}
			catch
			{
				result = new Tuple<int, int>(-1, -1);
			}
			return result;
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x001D7E44 File Offset: 0x001D6044
		public static Vector4 WalkDownSlope(Vector2 Position, Vector2 Velocity, int Width, int Height, float gravity = 0f)
		{
			if (Velocity.Y != gravity)
			{
				return new Vector4(Position, Velocity.X, Velocity.Y);
			}
			int num = (int)(Position.X / 16f);
			int num2 = (int)((Position.X + (float)Width) / 16f);
			int num3 = (int)((Position.Y + (float)Height + 4f) / 16f);
			num = Utils.Clamp<int>(num, 0, Main.maxTilesX - 1);
			num2 = Utils.Clamp<int>(num2, 0, Main.maxTilesX - 1);
			num3 = Utils.Clamp<int>(num3, 0, Main.maxTilesY - 3);
			float num4 = (float)((num3 + 3) * 16);
			int num5 = -1;
			int num6 = -1;
			int num7 = 1;
			if (Velocity.X < 0f)
			{
				num7 = 2;
			}
			for (int i = num; i <= num2; i++)
			{
				for (int j = num3; j <= num3 + 1; j++)
				{
					if (Main.tile[i, j] == null)
					{
						Main.tile[i, j] = new Tile();
					}
					if (Main.tile[i, j].nactive() && (Main.tileSolid[(int)Main.tile[i, j].type] || Main.tileSolidTop[(int)Main.tile[i, j].type]))
					{
						int num8 = j * 16;
						if (Main.tile[i, j].halfBrick())
						{
							num8 += 8;
						}
						Rectangle rectangle = new Rectangle(i * 16, j * 16 - 17, 16, 16);
						if (rectangle.Intersects(new Rectangle((int)Position.X, (int)Position.Y, Width, Height)) && (float)num8 <= num4)
						{
							if (num4 == (float)num8)
							{
								if (Main.tile[i, j].slope() != 0)
								{
									if (num5 != -1 && num6 != -1 && Main.tile[num5, num6] != null && Main.tile[num5, num6].slope() != 0)
									{
										if ((int)Main.tile[i, j].slope() == num7)
										{
											num4 = (float)num8;
											num5 = i;
											num6 = j;
										}
									}
									else
									{
										num4 = (float)num8;
										num5 = i;
										num6 = j;
									}
								}
							}
							else
							{
								num4 = (float)num8;
								num5 = i;
								num6 = j;
							}
						}
					}
				}
			}
			int num9 = num5;
			int num10 = num6;
			if (num5 != -1 && num6 != -1 && Main.tile[num9, num10] != null && Main.tile[num9, num10].slope() > 0)
			{
				int num11 = (int)Main.tile[num9, num10].slope();
				Vector2 vector;
				vector.X = (float)(num9 * 16);
				vector.Y = (float)(num10 * 16);
				if (num11 == 2)
				{
					float num12 = vector.X + 16f - (Position.X + (float)Width);
					if (Position.Y + (float)Height >= vector.Y + num12 && Velocity.X < 0f)
					{
						Velocity.Y += Math.Abs(Velocity.X);
					}
				}
				else if (num11 == 1)
				{
					float num12 = Position.X - vector.X;
					if (Position.Y + (float)Height >= vector.Y + num12 && Velocity.X > 0f)
					{
						Velocity.Y += Math.Abs(Velocity.X);
					}
				}
			}
			return new Vector4(Position, Velocity.X, Velocity.Y);
		}

		// Token: 0x060002CB RID: 715 RVA: 0x001D9E0C File Offset: 0x001D800C
		public static Vector2 WaterCollision(Vector2 Position, Vector2 Velocity, int Width, int Height, bool fallThrough = false, bool fall2 = false, bool lavaWalk = true)
		{
			Vector2 result = Velocity;
			Vector2 vector = Position + Velocity;
			int arg_5C_0 = (int)(Position.X / 16f) - 1;
			int num = (int)((Position.X + (float)Width) / 16f) + 2;
			int num2 = (int)(Position.Y / 16f) - 1;
			int num3 = (int)((Position.Y + (float)Height) / 16f) + 2;
			int arg_94_0 = Utils.Clamp<int>(arg_5C_0, 0, Main.maxTilesX - 1);
			num = Utils.Clamp<int>(num, 0, Main.maxTilesX - 1);
			num2 = Utils.Clamp<int>(num2, 0, Main.maxTilesY - 1);
			num3 = Utils.Clamp<int>(num3, 0, Main.maxTilesY - 1);
			for (int i = arg_94_0; i < num; i++)
			{
				for (int j = num2; j < num3; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].liquid > 0 && Main.tile[i, j - 1].liquid == 0 && (!Main.tile[i, j].lava() || lavaWalk))
					{
						int num4 = (int)(Main.tile[i, j].liquid / 32 * 2 + 2);
						Vector2 vector2;
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16 + 16 - num4);
						if (vector.X + (float)Width > vector2.X && vector.X < vector2.X + 16f && vector.Y + (float)Height > vector2.Y && vector.Y < vector2.Y + (float)num4 && Position.Y + (float)Height <= vector2.Y && !fallThrough)
						{
							result.Y = vector2.Y - (Position.Y + (float)Height);
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x001D7988 File Offset: 0x001D5B88
		public static bool WetCollision(Vector2 Position, int Width, int Height)
		{
			Collision.honey = false;
			Vector2 vector = new Vector2(Position.X + (float)(Width / 2), Position.Y + (float)(Height / 2));
			int num = 10;
			int num2 = Height / 2;
			if (num > Width)
			{
				num = Width;
			}
			if (num2 > Height)
			{
				num2 = Height;
			}
			vector = new Vector2(vector.X - (float)(num / 2), vector.Y - (float)(num2 / 2));
			int arg_A3_0 = (int)(Position.X / 16f) - 1;
			int num3 = (int)((Position.X + (float)Width) / 16f) + 2;
			int num4 = (int)(Position.Y / 16f) - 1;
			int num5 = (int)((Position.Y + (float)Height) / 16f) + 2;
			int arg_DB_0 = Utils.Clamp<int>(arg_A3_0, 0, Main.maxTilesX - 1);
			num3 = Utils.Clamp<int>(num3, 0, Main.maxTilesX - 1);
			num4 = Utils.Clamp<int>(num4, 0, Main.maxTilesY - 1);
			num5 = Utils.Clamp<int>(num5, 0, Main.maxTilesY - 1);
			for (int i = arg_DB_0; i < num3; i++)
			{
				for (int j = num4; j < num5; j++)
				{
					if (Main.tile[i, j] != null)
					{
						if (Main.tile[i, j].liquid > 0)
						{
							Vector2 vector2;
							vector2.X = (float)(i * 16);
							vector2.Y = (float)(j * 16);
							int num6 = 16;
							float num7 = (float)(256 - (int)Main.tile[i, j].liquid);
							num7 /= 32f;
							vector2.Y += num7 * 2f;
							num6 -= (int)(num7 * 2f);
							if (vector.X + (float)num > vector2.X && vector.X < vector2.X + 16f && vector.Y + (float)num2 > vector2.Y && vector.Y < vector2.Y + (float)num6)
							{
								if (Main.tile[i, j].honey())
								{
									Collision.honey = true;
								}
								return true;
							}
						}
						else if (Main.tile[i, j].active() && Main.tile[i, j].slope() != 0 && j > 0 && Main.tile[i, j - 1] != null && Main.tile[i, j - 1].liquid > 0)
						{
							Vector2 vector2;
							vector2.X = (float)(i * 16);
							vector2.Y = (float)(j * 16);
							int num8 = 16;
							if (vector.X + (float)num > vector2.X && vector.X < vector2.X + 16f && vector.Y + (float)num2 > vector2.Y && vector.Y < vector2.Y + (float)num8)
							{
								if (Main.tile[i, j - 1].honey())
								{
									Collision.honey = true;
								}
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x040002F4 RID: 756
		public static bool down = false;

		// Token: 0x040002F5 RID: 757
		public static float Epsilon = 2.71828175f;

		// Token: 0x040002F0 RID: 752
		public static bool honey = false;

		// Token: 0x040002F2 RID: 754
		public static bool landMine = false;

		// Token: 0x040002F1 RID: 753
		public static bool sloping = false;

		// Token: 0x040002EE RID: 750
		public static bool stair = false;

		// Token: 0x040002EF RID: 751
		public static bool stairFall = false;

		// Token: 0x040002F3 RID: 755
		public static bool up = false;
	}
}

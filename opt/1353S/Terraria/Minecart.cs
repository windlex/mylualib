﻿using System;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace Terraria
{
	// Token: 0x02000017 RID: 23
	public static class Minecart
	{
		// Token: 0x060000CF RID: 207 RVA: 0x0001CCE8 File Offset: 0x0001AEE8
		public static void Initialize()
		{
			if ((float)Main.minecartMountTexture.Width != 50f)
			{
				throw new Exception("Be sure to update Minecart.textureWidth to match the actual texture size of " + 50f + ".");
			}
			Minecart._rightSideConnection = new int[36];
			Minecart._leftSideConnection = new int[36];
			Minecart._trackType = new int[36];
			Minecart._boostLeft = new bool[36];
			Minecart._texturePosition = new Vector2[40];
			Minecart._tileHeight = new int[36][];
			for (int i = 0; i < 36; i++)
			{
				int[] array = new int[8];
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = 5;
				}
				Minecart._tileHeight[i] = array;
			}
			int num = 0;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = -1;
			Minecart._tileHeight[num][0] = -4;
			Minecart._tileHeight[num][7] = -4;
			Minecart._texturePosition[num] = new Vector2(0f, 0f);
			num++;
			Minecart._leftSideConnection[num] = 1;
			Minecart._rightSideConnection[num] = 1;
			Minecart._texturePosition[num] = new Vector2(1f, 0f);
			num++;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = 1;
			for (int k = 0; k < 4; k++)
			{
				Minecart._tileHeight[num][k] = -1;
			}
			Minecart._texturePosition[num] = new Vector2(2f, 1f);
			num++;
			Minecart._leftSideConnection[num] = 1;
			Minecart._rightSideConnection[num] = -1;
			for (int l = 4; l < 8; l++)
			{
				Minecart._tileHeight[num][l] = -1;
			}
			Minecart._texturePosition[num] = new Vector2(3f, 1f);
			num++;
			Minecart._leftSideConnection[num] = 2;
			Minecart._rightSideConnection[num] = 1;
			Minecart._tileHeight[num][0] = 1;
			Minecart._tileHeight[num][1] = 2;
			Minecart._tileHeight[num][2] = 3;
			Minecart._tileHeight[num][3] = 3;
			Minecart._tileHeight[num][4] = 4;
			Minecart._tileHeight[num][5] = 4;
			Minecart._texturePosition[num] = new Vector2(0f, 2f);
			num++;
			Minecart._leftSideConnection[num] = 1;
			Minecart._rightSideConnection[num] = 2;
			Minecart._tileHeight[num][2] = 4;
			Minecart._tileHeight[num][3] = 4;
			Minecart._tileHeight[num][4] = 3;
			Minecart._tileHeight[num][5] = 3;
			Minecart._tileHeight[num][6] = 2;
			Minecart._tileHeight[num][7] = 1;
			Minecart._texturePosition[num] = new Vector2(1f, 2f);
			num++;
			Minecart._leftSideConnection[num] = 1;
			Minecart._rightSideConnection[num] = 0;
			Minecart._tileHeight[num][4] = 6;
			Minecart._tileHeight[num][5] = 6;
			Minecart._tileHeight[num][6] = 7;
			Minecart._tileHeight[num][7] = 8;
			Minecart._texturePosition[num] = new Vector2(0f, 1f);
			num++;
			Minecart._leftSideConnection[num] = 0;
			Minecart._rightSideConnection[num] = 1;
			Minecart._tileHeight[num][0] = 8;
			Minecart._tileHeight[num][1] = 7;
			Minecart._tileHeight[num][2] = 6;
			Minecart._tileHeight[num][3] = 6;
			Minecart._texturePosition[num] = new Vector2(1f, 1f);
			num++;
			Minecart._leftSideConnection[num] = 0;
			Minecart._rightSideConnection[num] = 2;
			for (int m = 0; m < 8; m++)
			{
				Minecart._tileHeight[num][m] = 8 - m;
			}
			Minecart._texturePosition[num] = new Vector2(0f, 3f);
			num++;
			Minecart._leftSideConnection[num] = 2;
			Minecart._rightSideConnection[num] = 0;
			for (int n = 0; n < 8; n++)
			{
				Minecart._tileHeight[num][n] = n + 1;
			}
			Minecart._texturePosition[num] = new Vector2(1f, 3f);
			num++;
			Minecart._leftSideConnection[num] = 2;
			Minecart._rightSideConnection[num] = -1;
			Minecart._tileHeight[num][0] = 1;
			Minecart._tileHeight[num][1] = 2;
			for (int num2 = 2; num2 < 8; num2++)
			{
				Minecart._tileHeight[num][num2] = -1;
			}
			Minecart._texturePosition[num] = new Vector2(4f, 1f);
			num++;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = 2;
			Minecart._tileHeight[num][6] = 2;
			Minecart._tileHeight[num][7] = 1;
			for (int num3 = 0; num3 < 6; num3++)
			{
				Minecart._tileHeight[num][num3] = -1;
			}
			Minecart._texturePosition[num] = new Vector2(5f, 1f);
			num++;
			Minecart._leftSideConnection[num] = 0;
			Minecart._rightSideConnection[num] = -1;
			Minecart._tileHeight[num][0] = 8;
			Minecart._tileHeight[num][1] = 7;
			Minecart._tileHeight[num][2] = 6;
			for (int num4 = 3; num4 < 8; num4++)
			{
				Minecart._tileHeight[num][num4] = -1;
			}
			Minecart._texturePosition[num] = new Vector2(6f, 1f);
			num++;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = 0;
			Minecart._tileHeight[num][5] = 6;
			Minecart._tileHeight[num][6] = 7;
			Minecart._tileHeight[num][7] = 8;
			for (int num5 = 0; num5 < 5; num5++)
			{
				Minecart._tileHeight[num][num5] = -1;
			}
			Minecart._texturePosition[num] = new Vector2(7f, 1f);
			num++;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = 1;
			Minecart._tileHeight[num][0] = -4;
			Minecart._texturePosition[num] = new Vector2(2f, 0f);
			num++;
			Minecart._leftSideConnection[num] = 1;
			Minecart._rightSideConnection[num] = -1;
			Minecart._tileHeight[num][7] = -4;
			Minecart._texturePosition[num] = new Vector2(3f, 0f);
			num++;
			Minecart._leftSideConnection[num] = 2;
			Minecart._rightSideConnection[num] = -1;
			for (int num6 = 0; num6 < 6; num6++)
			{
				Minecart._tileHeight[num][num6] = num6 + 1;
			}
			Minecart._tileHeight[num][6] = -3;
			Minecart._tileHeight[num][7] = -3;
			Minecart._texturePosition[num] = new Vector2(4f, 0f);
			num++;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = 2;
			Minecart._tileHeight[num][0] = -3;
			Minecart._tileHeight[num][1] = -3;
			for (int num7 = 2; num7 < 8; num7++)
			{
				Minecart._tileHeight[num][num7] = 8 - num7;
			}
			Minecart._texturePosition[num] = new Vector2(5f, 0f);
			num++;
			Minecart._leftSideConnection[num] = 0;
			Minecart._rightSideConnection[num] = -1;
			for (int num8 = 0; num8 < 6; num8++)
			{
				Minecart._tileHeight[num][num8] = 8 - num8;
			}
			Minecart._tileHeight[num][6] = -3;
			Minecart._tileHeight[num][7] = -3;
			Minecart._texturePosition[num] = new Vector2(6f, 0f);
			num++;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = 0;
			Minecart._tileHeight[num][0] = -3;
			Minecart._tileHeight[num][1] = -3;
			for (int num9 = 2; num9 < 8; num9++)
			{
				Minecart._tileHeight[num][num9] = num9 + 1;
			}
			Minecart._texturePosition[num] = new Vector2(7f, 0f);
			num++;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = -1;
			Minecart._tileHeight[num][0] = -4;
			Minecart._tileHeight[num][7] = -4;
			Minecart._trackType[num] = 1;
			Minecart._texturePosition[num] = new Vector2(0f, 4f);
			num++;
			Minecart._leftSideConnection[num] = 1;
			Minecart._rightSideConnection[num] = 1;
			Minecart._trackType[num] = 1;
			Minecart._texturePosition[num] = new Vector2(1f, 4f);
			num++;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = 1;
			Minecart._tileHeight[num][0] = -4;
			Minecart._trackType[num] = 1;
			Minecart._texturePosition[num] = new Vector2(0f, 5f);
			num++;
			Minecart._leftSideConnection[num] = 1;
			Minecart._rightSideConnection[num] = -1;
			Minecart._tileHeight[num][7] = -4;
			Minecart._trackType[num] = 1;
			Minecart._texturePosition[num] = new Vector2(1f, 5f);
			num++;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = 1;
			for (int num10 = 0; num10 < 6; num10++)
			{
				Minecart._tileHeight[num][num10] = -2;
			}
			Minecart._texturePosition[num] = new Vector2(2f, 2f);
			num++;
			Minecart._leftSideConnection[num] = 1;
			Minecart._rightSideConnection[num] = -1;
			for (int num11 = 2; num11 < 8; num11++)
			{
				Minecart._tileHeight[num][num11] = -2;
			}
			Minecart._texturePosition[num] = new Vector2(3f, 2f);
			num++;
			Minecart._leftSideConnection[num] = 2;
			Minecart._rightSideConnection[num] = -1;
			Minecart._tileHeight[num][0] = 1;
			Minecart._tileHeight[num][1] = 2;
			for (int num12 = 2; num12 < 8; num12++)
			{
				Minecart._tileHeight[num][num12] = -2;
			}
			Minecart._texturePosition[num] = new Vector2(4f, 2f);
			num++;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = 2;
			Minecart._tileHeight[num][6] = 2;
			Minecart._tileHeight[num][7] = 1;
			for (int num13 = 0; num13 < 6; num13++)
			{
				Minecart._tileHeight[num][num13] = -2;
			}
			Minecart._texturePosition[num] = new Vector2(5f, 2f);
			num++;
			Minecart._leftSideConnection[num] = 0;
			Minecart._rightSideConnection[num] = -1;
			Minecart._tileHeight[num][0] = 8;
			Minecart._tileHeight[num][1] = 7;
			Minecart._tileHeight[num][2] = 6;
			for (int num14 = 3; num14 < 8; num14++)
			{
				Minecart._tileHeight[num][num14] = -2;
			}
			Minecart._texturePosition[num] = new Vector2(6f, 2f);
			num++;
			Minecart._leftSideConnection[num] = -1;
			Minecart._rightSideConnection[num] = 0;
			Minecart._tileHeight[num][5] = 6;
			Minecart._tileHeight[num][6] = 7;
			Minecart._tileHeight[num][7] = 8;
			for (int num15 = 0; num15 < 5; num15++)
			{
				Minecart._tileHeight[num][num15] = -2;
			}
			Minecart._texturePosition[num] = new Vector2(7f, 2f);
			num++;
			Minecart._leftSideConnection[num] = 1;
			Minecart._rightSideConnection[num] = 1;
			Minecart._trackType[num] = 2;
			Minecart._boostLeft[num] = false;
			Minecart._texturePosition[num] = new Vector2(2f, 3f);
			num++;
			Minecart._leftSideConnection[num] = 1;
			Minecart._rightSideConnection[num] = 1;
			Minecart._trackType[num] = 2;
			Minecart._boostLeft[num] = true;
			Minecart._texturePosition[num] = new Vector2(3f, 3f);
			num++;
			Minecart._leftSideConnection[num] = 0;
			Minecart._rightSideConnection[num] = 2;
			for (int num16 = 0; num16 < 8; num16++)
			{
				Minecart._tileHeight[num][num16] = 8 - num16;
			}
			Minecart._trackType[num] = 2;
			Minecart._boostLeft[num] = false;
			Minecart._texturePosition[num] = new Vector2(4f, 3f);
			num++;
			Minecart._leftSideConnection[num] = 2;
			Minecart._rightSideConnection[num] = 0;
			for (int num17 = 0; num17 < 8; num17++)
			{
				Minecart._tileHeight[num][num17] = num17 + 1;
			}
			Minecart._trackType[num] = 2;
			Minecart._boostLeft[num] = true;
			Minecart._texturePosition[num] = new Vector2(5f, 3f);
			num++;
			Minecart._leftSideConnection[num] = 0;
			Minecart._rightSideConnection[num] = 2;
			for (int num18 = 0; num18 < 8; num18++)
			{
				Minecart._tileHeight[num][num18] = 8 - num18;
			}
			Minecart._trackType[num] = 2;
			Minecart._boostLeft[num] = true;
			Minecart._texturePosition[num] = new Vector2(6f, 3f);
			num++;
			Minecart._leftSideConnection[num] = 2;
			Minecart._rightSideConnection[num] = 0;
			for (int num19 = 0; num19 < 8; num19++)
			{
				Minecart._tileHeight[num][num19] = num19 + 1;
			}
			Minecart._trackType[num] = 2;
			Minecart._boostLeft[num] = false;
			Minecart._texturePosition[num] = new Vector2(7f, 3f);
			num++;
			Minecart._texturePosition[36] = new Vector2(0f, 6f);
			Minecart._texturePosition[37] = new Vector2(1f, 6f);
			Minecart._texturePosition[39] = new Vector2(0f, 7f);
			Minecart._texturePosition[38] = new Vector2(1f, 7f);
			for (int num20 = 0; num20 < Minecart._texturePosition.Length; num20++)
			{
				Minecart._texturePosition[num20] = Minecart._texturePosition[num20] * 18f;
			}
			for (int num21 = 0; num21 < Minecart._tileHeight.Length; num21++)
			{
				int[] array2 = Minecart._tileHeight[num21];
				for (int num22 = 0; num22 < array2.Length; num22++)
				{
					if (array2[num22] >= 0)
					{
						array2[num22] = (8 - array2[num22]) * 2;
					}
				}
			}
			int[] array3 = new int[36];
			Minecart._trackSwitchOptions = new int[64][];
			for (int num23 = 0; num23 < 64; num23++)
			{
				int num24 = 0;
				for (int num25 = 1; num25 < 256; num25 <<= 1)
				{
					if ((num23 & num25) == num25)
					{
						num24++;
					}
				}
				int num26 = 0;
				int num27 = 0;
				while (num27 < 36)
				{
					array3[num27] = -1;
					int num28 = 0;
					switch (Minecart._leftSideConnection[num27])
					{
					case 0:
						num28 |= 1;
						break;
					case 1:
						num28 |= 2;
						break;
					case 2:
						num28 |= 4;
						break;
					}
					switch (Minecart._rightSideConnection[num27])
					{
					case 0:
						num28 |= 8;
						break;
					case 1:
						num28 |= 16;
						break;
					case 2:
						num28 |= 32;
						break;
					}
					if (num24 < 2)
					{
						if (num23 == num28)
						{
							goto IL_E30;
						}
					}
					else if (num28 != 0 && (num23 & num28) == num28)
					{
						goto IL_E30;
					}
					IL_E3C:
					num27++;
					continue;
					IL_E30:
					array3[num27] = num27;
					num26++;
					goto IL_E3C;
				}
				if (num26 != 0)
				{
					int[] array4 = new int[num26];
					int num29 = 0;
					for (int num30 = 0; num30 < 36; num30++)
					{
						if (array3[num30] != -1)
						{
							array4[num29] = array3[num30];
							num29++;
						}
					}
					Minecart._trackSwitchOptions[num23] = array4;
				}
			}
			Minecart._firstPressureFrame = -1;
			Minecart._firstLeftBoostFrame = -1;
			Minecart._firstRightBoostFrame = -1;
			for (int num31 = 0; num31 < Minecart._trackType.Length; num31++)
			{
				int num32 = Minecart._trackType[num31];
				if (num32 != 1)
				{
					if (num32 == 2)
					{
						if (Minecart._boostLeft[num31])
						{
							if (Minecart._firstLeftBoostFrame == -1)
							{
								Minecart._firstLeftBoostFrame = (short)num31;
							}
						}
						else if (Minecart._firstRightBoostFrame == -1)
						{
							Minecart._firstRightBoostFrame = (short)num31;
						}
					}
				}
				else if (Minecart._firstPressureFrame == -1)
				{
					Minecart._firstPressureFrame = (short)num31;
				}
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0001DC0C File Offset: 0x0001BE0C
		public static BitsByte TrackCollision(ref Vector2 Position, ref Vector2 Velocity, ref Vector2 lastBoost, int Width, int Height, bool followDown, bool followUp, int fallStart, bool trackOnly, Action<Vector2> MinecartDust)
		{
			if (followDown & followUp)
			{
				followDown = false;
				followUp = false;
			}
			Vector2 vector = new Vector2((float)(Width / 2) - 25f, (float)(Height / 2));
			Vector2 vector2 = Position + new Vector2((float)(Width / 2) - 25f, (float)(Height / 2)) + Minecart._trackMagnetOffset;
			Vector2 vector3 = Velocity;
			float num = vector3.Length();
			vector3.Normalize();
			Vector2 vector4 = vector2;
			Tile tile = null;
			bool flag = false;
			bool flag2 = true;
			int num2 = -1;
			int num3 = -1;
			int num4 = -1;
			Minecart.TrackState trackState = Minecart.TrackState.NoTrack;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			Vector2 vector5 = Vector2.Zero;
			Vector2 value = Vector2.Zero;
			BitsByte result = default(BitsByte);
			while (true)
			{
				int num5 = (int)(vector4.X / 16f);
				int num6 = (int)(vector4.Y / 16f);
				int num7 = (int)vector4.X % 16 / 2;
				if (flag2)
				{
					num4 = num7;
				}
				bool flag7 = num7 != num4;
				if ((trackState == Minecart.TrackState.OnBack || trackState == Minecart.TrackState.OnTrack || trackState == Minecart.TrackState.OnFront) && num5 != num2)
				{
					int num8;
					if (trackState == Minecart.TrackState.OnBack)
					{
						num8 = (int)tile.BackTrack();
					}
					else
					{
						num8 = (int)tile.FrontTrack();
					}
					int num9;
					if (vector3.X < 0f)
					{
						num9 = Minecart._leftSideConnection[num8];
					}
					else
					{
						num9 = Minecart._rightSideConnection[num8];
					}
					switch (num9)
					{
					case 0:
						num6--;
						vector4.Y -= 2f;
						break;
					case 2:
						num6++;
						vector4.Y += 2f;
						break;
					}
				}
				Minecart.TrackState trackState2 = Minecart.TrackState.NoTrack;
				bool flag8 = false;
				if (num5 != num2 || num6 != num3)
				{
					if (flag2)
					{
						flag2 = false;
					}
					else
					{
						flag8 = true;
					}
					tile = Main.tile[num5, num6];
					if (tile == null)
					{
						tile = new Tile();
						Main.tile[num5, num6] = tile;
					}
					flag = (tile.nactive() && tile.type == 314);
				}
				if (flag)
				{
					Minecart.TrackState trackState3 = Minecart.TrackState.NoTrack;
					int num10 = (int)tile.FrontTrack();
					int num11 = (int)tile.BackTrack();
					int num12 = Minecart._tileHeight[num10][num7];
					switch (num12)
					{
					case -4:
						if (trackState == Minecart.TrackState.OnFront)
						{
							if (trackOnly)
							{
								vector4 -= value;
								num = 0f;
								trackState2 = Minecart.TrackState.OnFront;
								flag6 = true;
							}
							else
							{
								trackState2 = Minecart.TrackState.NoTrack;
								flag5 = true;
							}
						}
						break;
					case -3:
						if (trackState == Minecart.TrackState.OnFront)
						{
							trackState = Minecart.TrackState.NoTrack;
							Matrix matrix;
							if (Velocity.X > 0f)
							{
								if (Minecart._leftSideConnection[num10] == 2)
								{
									matrix = Matrix.CreateRotationZ(-0.7853982f);
								}
								else
								{
									matrix = Matrix.CreateRotationZ(0.7853982f);
								}
							}
							else if (Minecart._rightSideConnection[num10] == 2)
							{
								matrix = Matrix.CreateRotationZ(0.7853982f);
							}
							else
							{
								matrix = Matrix.CreateRotationZ(-0.7853982f);
							}
							vector5 = Vector2.Transform(new Vector2(Velocity.X, 0f), matrix);
							vector5.X = Velocity.X;
							flag4 = true;
							num = 0f;
						}
						break;
					case -2:
						if (trackState == Minecart.TrackState.OnFront)
						{
							if (trackOnly)
							{
								vector4 -= value;
								num = 0f;
								trackState2 = Minecart.TrackState.OnFront;
								flag6 = true;
							}
							else
							{
								if (vector3.X < 0f)
								{
									float num13 = (float)(num5 * 16 + (num7 + 1) * 2) - vector4.X;
									vector4.X += num13;
									num += num13 / vector3.X;
								}
								vector3.X = -vector3.X;
								result[1] = true;
								trackState2 = Minecart.TrackState.OnFront;
							}
						}
						break;
					case -1:
						if (trackState == Minecart.TrackState.OnFront)
						{
							vector4 -= value;
							num = 0f;
							trackState2 = Minecart.TrackState.OnFront;
							flag6 = true;
						}
						break;
					default:
					{
						float num14 = (float)(num6 * 16 + num12);
						if (num5 != num2 && trackState == Minecart.TrackState.NoTrack && vector4.Y > num14 && vector4.Y - num14 < 2f)
						{
							flag8 = false;
							trackState = Minecart.TrackState.AboveFront;
						}
						Minecart.TrackState trackState4;
						if (vector4.Y < num14)
						{
							trackState4 = Minecart.TrackState.AboveTrack;
						}
						else if (vector4.Y > num14)
						{
							trackState4 = Minecart.TrackState.BelowTrack;
						}
						else
						{
							trackState4 = Minecart.TrackState.OnTrack;
						}
						if (num11 != -1)
						{
							float num15 = (float)(num6 * 16 + Minecart._tileHeight[num11][num7]);
							if (vector4.Y < num15)
							{
								trackState3 = Minecart.TrackState.AboveTrack;
							}
							else if (vector4.Y > num15)
							{
								trackState3 = Minecart.TrackState.BelowTrack;
							}
							else
							{
								trackState3 = Minecart.TrackState.OnTrack;
							}
						}
						switch (trackState4)
						{
						case Minecart.TrackState.AboveTrack:
							switch (trackState3)
							{
							case Minecart.TrackState.AboveTrack:
								trackState2 = Minecart.TrackState.AboveTrack;
								break;
							case Minecart.TrackState.OnTrack:
								trackState2 = Minecart.TrackState.OnBack;
								break;
							case Minecart.TrackState.BelowTrack:
								trackState2 = Minecart.TrackState.AboveFront;
								break;
							default:
								trackState2 = Minecart.TrackState.AboveFront;
								break;
							}
							break;
						case Minecart.TrackState.OnTrack:
							if (trackState3 == Minecart.TrackState.OnTrack)
							{
								trackState2 = Minecart.TrackState.OnTrack;
							}
							else
							{
								trackState2 = Minecart.TrackState.OnFront;
							}
							break;
						case Minecart.TrackState.BelowTrack:
							switch (trackState3)
							{
							case Minecart.TrackState.AboveTrack:
								trackState2 = Minecart.TrackState.AboveBack;
								break;
							case Minecart.TrackState.OnTrack:
								trackState2 = Minecart.TrackState.OnBack;
								break;
							case Minecart.TrackState.BelowTrack:
								trackState2 = Minecart.TrackState.BelowTrack;
								break;
							default:
								trackState2 = Minecart.TrackState.BelowTrack;
								break;
							}
							break;
						}
						break;
					}
					}
				}
				if (!flag8)
				{
					if (trackState != trackState2)
					{
						bool flag9 = false;
						if (flag7 || vector3.Y > 0f)
						{
							switch (trackState)
							{
							case Minecart.TrackState.AboveTrack:
								switch (trackState2)
								{
								case Minecart.TrackState.AboveTrack:
									trackState2 = Minecart.TrackState.OnTrack;
									break;
								case Minecart.TrackState.AboveFront:
									trackState2 = Minecart.TrackState.OnBack;
									break;
								case Minecart.TrackState.AboveBack:
									trackState2 = Minecart.TrackState.OnFront;
									break;
								}
								break;
							case Minecart.TrackState.OnTrack:
							{
								int num16 = Minecart._tileHeight[(int)tile.FrontTrack()][num7];
								int num17 = Minecart._tileHeight[(int)tile.BackTrack()][num7];
								if (followDown)
								{
									if (num16 < num17)
									{
										trackState2 = Minecart.TrackState.OnBack;
									}
									else
									{
										trackState2 = Minecart.TrackState.OnFront;
									}
								}
								else if (followUp)
								{
									if (num16 < num17)
									{
										trackState2 = Minecart.TrackState.OnFront;
									}
									else
									{
										trackState2 = Minecart.TrackState.OnBack;
									}
								}
								else
								{
									trackState2 = Minecart.TrackState.OnFront;
								}
								flag9 = true;
								break;
							}
							case Minecart.TrackState.AboveFront:
								if (trackState2 == Minecart.TrackState.BelowTrack)
								{
									trackState2 = Minecart.TrackState.OnFront;
								}
								break;
							case Minecart.TrackState.AboveBack:
								if (trackState2 == Minecart.TrackState.BelowTrack)
								{
									trackState2 = Minecart.TrackState.OnBack;
								}
								break;
							case Minecart.TrackState.OnFront:
								trackState2 = Minecart.TrackState.OnFront;
								flag9 = true;
								break;
							case Minecart.TrackState.OnBack:
								trackState2 = Minecart.TrackState.OnBack;
								flag9 = true;
								break;
							}
							int num18 = -1;
							if (trackState2 != Minecart.TrackState.OnTrack && trackState2 != Minecart.TrackState.OnFront)
							{
								if (trackState2 == Minecart.TrackState.OnBack)
								{
									num18 = (int)tile.BackTrack();
								}
							}
							else
							{
								num18 = (int)tile.FrontTrack();
							}
							if (num18 != -1)
							{
								if (!flag9 && Velocity.Y > Player.defaultGravity)
								{
									int num19 = (int)(Position.Y / 16f);
									if (fallStart < num19 - 1)
									{
										Main.PlaySound(SoundID.Item53, (int)Position.X + Width / 2, (int)Position.Y + Height / 2);
										Minecart.WheelSparks(MinecartDust, Position, Width, Height, 10);
									}
								}
								if (trackState == Minecart.TrackState.AboveFront && Minecart._trackType[num18] == 1)
								{
									flag3 = true;
								}
								vector3.Y = 0f;
								vector4.Y = (float)(num6 * 16 + Minecart._tileHeight[num18][num7]);
							}
						}
					}
				}
				else if (trackState2 == Minecart.TrackState.OnFront || trackState2 == Minecart.TrackState.OnBack || trackState2 == Minecart.TrackState.OnTrack)
				{
					if (flag && Minecart._trackType[(int)tile.FrontTrack()] == 1)
					{
						flag3 = true;
					}
					vector3.Y = 0f;
				}
				if (trackState2 == Minecart.TrackState.OnFront)
				{
					int num20 = (int)tile.FrontTrack();
					if (Minecart._trackType[num20] == 2 && lastBoost.X == 0f && lastBoost.Y == 0f)
					{
						lastBoost = new Vector2((float)num5, (float)num6);
						if (Minecart._boostLeft[num20])
						{
							result[4] = true;
						}
						else
						{
							result[5] = true;
						}
					}
				}
				num4 = num7;
				trackState = trackState2;
				num2 = num5;
				num3 = num6;
				if (num <= 0f)
				{
					break;
				}
				float num21 = vector4.X % 2f;
				float num22 = vector4.Y % 2f;
				float num23 = 3f;
				float num24 = 3f;
				if (vector3.X < 0f)
				{
					num23 = num21 + 0.125f;
				}
				else if (vector3.X > 0f)
				{
					num23 = 2f - num21;
				}
				if (vector3.Y < 0f)
				{
					num24 = num22 + 0.125f;
				}
				else if (vector3.Y > 0f)
				{
					num24 = 2f - num22;
				}
				if (num23 == 3f && num24 == 3f)
				{
					goto IL_83E;
				}
				float num25 = Math.Abs(num23 / vector3.X);
				float num26 = Math.Abs(num24 / vector3.Y);
				float num27 = (num25 < num26) ? num25 : num26;
				if (num27 > num)
				{
					value = vector3 * num;
					num = 0f;
				}
				else
				{
					value = vector3 * num27;
					num -= num27;
				}
				vector4 += value;
			}
			if (lastBoost.X != (float)num2 || lastBoost.Y != (float)num3)
			{
				lastBoost = Vector2.Zero;
			}
			IL_83E:
			if (flag3)
			{
				result[3] = true;
			}
			if (flag5)
			{
				Velocity.X = vector4.X - vector2.X;
				Velocity.Y = Player.defaultGravity;
			}
			else if (flag4)
			{
				result[2] = true;
				Velocity = vector5;
			}
			else if (result[1])
			{
				Velocity.X = -Velocity.X;
				Position.X = vector4.X - Minecart._trackMagnetOffset.X - vector.X - Velocity.X;
				if (vector3.Y == 0f)
				{
					Velocity.Y = 0f;
				}
			}
			else
			{
				if (flag6)
				{
					Velocity.X = vector4.X - vector2.X;
				}
				if (vector3.Y == 0f)
				{
					Velocity.Y = 0f;
				}
			}
			Position.Y += vector4.Y - vector2.Y - Velocity.Y;
			Position.Y = (float)Math.Round((double)Position.Y, 2);
			if (trackState == Minecart.TrackState.OnTrack || trackState - Minecart.TrackState.OnFront <= 1)
			{
				result[0] = true;
			}
			return result;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0001E578 File Offset: 0x0001C778
		public static bool FrameTrack(int i, int j, bool pound, bool mute = false)
		{
			int num = 0;
			Tile tile = Main.tile[i, j];
			if (tile == null)
			{
				tile = new Tile();
				Main.tile[i, j] = tile;
			}
			if (mute && tile.type != 314)
			{
				return false;
			}
			if (Main.tile[i - 1, j - 1] != null && Main.tile[i - 1, j - 1].type == 314)
			{
				num++;
			}
			if (Main.tile[i - 1, j] != null && Main.tile[i - 1, j].type == 314)
			{
				num += 2;
			}
			if (Main.tile[i - 1, j + 1] != null && Main.tile[i - 1, j + 1].type == 314)
			{
				num += 4;
			}
			if (Main.tile[i + 1, j - 1] != null && Main.tile[i + 1, j - 1].type == 314)
			{
				num += 8;
			}
			if (Main.tile[i + 1, j] != null && Main.tile[i + 1, j].type == 314)
			{
				num += 16;
			}
			if (Main.tile[i + 1, j + 1] != null && Main.tile[i + 1, j + 1].type == 314)
			{
				num += 32;
			}
			int num2 = (int)tile.FrontTrack();
			int num3 = (int)tile.BackTrack();
			if (Minecart._trackType == null)
			{
				return false;
			}
			int num4;
			if (num2 >= 0 && num2 < Minecart._trackType.Length)
			{
				num4 = Minecart._trackType[num2];
			}
			else
			{
				num4 = 0;
			}
			int num5 = -1;
			int num6 = -1;
			int[] array = Minecart._trackSwitchOptions[num];
			if (array != null)
			{
				if (!pound)
				{
					int num7 = -1;
					int num8 = -1;
					bool flag = false;
					for (int k = 0; k < array.Length; k++)
					{
						int num9 = array[k];
						if (num3 == array[k])
						{
							num6 = k;
						}
						if (Minecart._trackType[num9] == num4)
						{
							if (Minecart._leftSideConnection[num9] == -1 || Minecart._rightSideConnection[num9] == -1)
							{
								if (num2 == array[k])
								{
									num5 = k;
									flag = true;
								}
								if (num7 == -1)
								{
									num7 = k;
								}
							}
							else
							{
								if (num2 == array[k])
								{
									num5 = k;
									flag = false;
								}
								if (num8 == -1)
								{
									num8 = k;
								}
							}
						}
					}
					if (num8 != -1)
					{
						if (num5 == -1 | flag)
						{
							num5 = num8;
						}
					}
					else
					{
						if (num5 == -1)
						{
							if (num4 == 2)
							{
								return false;
							}
							if (num4 == 1)
							{
								return false;
							}
							num5 = num7;
						}
						num6 = -1;
					}
				}
				else
				{
					for (int l = 0; l < array.Length; l++)
					{
						if (num2 == array[l])
						{
							num5 = l;
						}
						if (num3 == array[l])
						{
							num6 = l;
						}
					}
					int num10 = 0;
					int num11 = 0;
					for (int m = 0; m < array.Length; m++)
					{
						if (Minecart._trackType[array[m]] == num4)
						{
							if (Minecart._leftSideConnection[array[m]] == -1 || Minecart._rightSideConnection[array[m]] == -1)
							{
								num11++;
							}
							else
							{
								num10++;
							}
						}
					}
					if (num10 < 2 && num11 < 2)
					{
						return false;
					}
					bool flag2 = num10 == 0;
					bool flag3 = false;
					if (!flag2)
					{
						while (!flag3)
						{
							num6++;
							if (num6 >= array.Length)
							{
								num6 = -1;
								break;
							}
							if ((Minecart._leftSideConnection[array[num6]] != Minecart._leftSideConnection[array[num5]] || Minecart._rightSideConnection[array[num6]] != Minecart._rightSideConnection[array[num5]]) && Minecart._trackType[array[num6]] == num4 && Minecart._leftSideConnection[array[num6]] != -1 && Minecart._rightSideConnection[array[num6]] != -1)
							{
								flag3 = true;
							}
						}
					}
					if (!flag3)
					{
						while (true)
						{
							num5++;
							if (num5 >= array.Length)
							{
								break;
							}
							if (Minecart._trackType[array[num5]] == num4 && (Minecart._leftSideConnection[array[num5]] == -1 || Minecart._rightSideConnection[array[num5]] == -1) == flag2)
							{
								goto IL_40A;
							}
						}
						num5 = -1;
						while (true)
						{
							num5++;
							if (Minecart._trackType[array[num5]] == num4)
							{
								if ((Minecart._leftSideConnection[array[num5]] == -1 || Minecart._rightSideConnection[array[num5]] == -1) == flag2)
								{
									break;
								}
							}
						}
					}
				}
				IL_40A:
				bool flag4 = false;
				if (num5 == -2)
				{
					if (tile.FrontTrack() != Minecart._firstPressureFrame)
					{
						flag4 = true;
					}
				}
				else if (num5 == -1)
				{
					if (tile.FrontTrack() != 0)
					{
						flag4 = true;
					}
				}
				else if ((int)tile.FrontTrack() != array[num5])
				{
					flag4 = true;
				}
				if (num6 == -1)
				{
					if (tile.BackTrack() != -1)
					{
						flag4 = true;
					}
				}
				else if ((int)tile.BackTrack() != array[num6])
				{
					flag4 = true;
				}
				if (num5 == -2)
				{
					tile.FrontTrack(Minecart._firstPressureFrame);
				}
				else if (num5 == -1)
				{
					tile.FrontTrack(0);
				}
				else
				{
					tile.FrontTrack((short)array[num5]);
				}
				if (num6 == -1)
				{
					tile.BackTrack(-1);
				}
				else
				{
					tile.BackTrack((short)array[num6]);
				}
				if ((pound & flag4) && !mute)
				{
					WorldGen.KillTile(i, j, true, false, false);
				}
				return true;
			}
			if (pound)
			{
				return false;
			}
			tile.FrontTrack(0);
			tile.BackTrack(-1);
			return false;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0001EA4C File Offset: 0x0001CC4C
		public static bool GetOnTrack(int tileX, int tileY, ref Vector2 Position, int Width, int Height)
		{
			Tile tile = Main.tile[tileX, tileY];
			if (tile.type != 314)
			{
				return false;
			}
			Vector2 value = new Vector2((float)(Width / 2) - 25f, (float)(Height / 2));
			Vector2 vector = Position + value + Minecart._trackMagnetOffset;
			int num = (int)vector.X % 16 / 2;
			int num2 = -1;
			int num3 = 0;
			for (int i = num; i < 8; i++)
			{
				num3 = Minecart._tileHeight[(int)tile.frameX][i];
				if (num3 >= 0)
				{
					num2 = i;
					break;
				}
			}
			if (num2 == -1)
			{
				for (int j = num - 1; j >= 0; j--)
				{
					num3 = Minecart._tileHeight[(int)tile.frameX][j];
					if (num3 >= 0)
					{
						num2 = j;
						break;
					}
				}
			}
			if (num2 == -1)
			{
				return false;
			}
			vector.X = (float)(tileX * 16 + num2 * 2);
			vector.Y = (float)(tileY * 16 + num3);
			vector -= Minecart._trackMagnetOffset;
			vector -= value;
			Position = vector;
			return true;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0001EB58 File Offset: 0x0001CD58
		public static bool OnTrack(Vector2 Position, int Width, int Height)
		{
			Vector2 expr_23 = Position + new Vector2((float)(Width / 2) - 25f, (float)(Height / 2)) + Minecart._trackMagnetOffset;
			int num = (int)(expr_23.X / 16f);
			int num2 = (int)(expr_23.Y / 16f);
			return Main.tile[num, num2] != null && Main.tile[num, num2].type == 314;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0001EBCC File Offset: 0x0001CDCC
		public static float TrackRotation(ref float rotation, Vector2 Position, int Width, int Height, bool followDown, bool followUp, Action<Vector2> MinecartDust)
		{
			Vector2 vector = Position;
			Vector2 vector2 = Position;
			Vector2 zero = Vector2.Zero;
			Vector2 value = new Vector2(-12f, 0f);
			Minecart.TrackCollision(ref vector, ref value, ref zero, Width, Height, followDown, followUp, 0, true, MinecartDust);
			vector += value;
			value = new Vector2(12f, 0f);
			Minecart.TrackCollision(ref vector2, ref value, ref zero, Width, Height, followDown, followUp, 0, true, MinecartDust);
			vector2 += value;
			float num = vector2.Y - vector.Y;
			float num2 = vector2.X - vector.X;
			float num3 = num / num2;
			float arg_CC_0 = vector.Y + (Position.X - vector.X) * num3;
			float num4 = (Position.X - (float)((int)Position.X)) * num3;
			rotation = (float)Math.Atan2((double)num, (double)num2);
			return arg_CC_0 - Position.Y + num4;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0001ECAC File Offset: 0x0001CEAC
		public static void HitTrackSwitch(Vector2 Position, int Width, int Height)
		{
			new Vector2((float)(Width / 2) - 25f, (float)(Height / 2));
			Vector2 expr_37 = Position + new Vector2((float)(Width / 2) - 25f, (float)(Height / 2)) + Minecart._trackMagnetOffset;
			int num = (int)(expr_37.X / 16f);
			int num2 = (int)(expr_37.Y / 16f);
			Wiring.HitSwitch(num, num2);
			NetMessage.SendData(59, -1, -1, null, num, (float)num2, 0f, 0f, 0, 0, 0);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0001ED2C File Offset: 0x0001CF2C
		public static void FlipSwitchTrack(int i, int j)
		{
			Tile tileTrack = Main.tile[i, j];
			short num = tileTrack.FrontTrack();
			if (num == -1)
			{
				return;
			}
			int num2 = Minecart._trackType[(int)num];
			if (num2 != 0)
			{
				if (num2 != 2)
				{
					return;
				}
				Minecart.FrameTrack(i, j, true, true);
				NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
			}
			else if (tileTrack.BackTrack() != -1)
			{
				tileTrack.FrontTrack(tileTrack.BackTrack());
				tileTrack.BackTrack(num);
				NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
				return;
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0001EDA0 File Offset: 0x0001CFA0
		public static void TrackColors(int i, int j, Tile trackTile, out int frontColor, out int backColor)
		{
			if (trackTile.type == 314)
			{
				frontColor = (int)trackTile.color();
				backColor = frontColor;
				if (trackTile.frameY == -1)
				{
					return;
				}
				int num = Minecart._leftSideConnection[(int)trackTile.frameX];
				int num2 = Minecart._rightSideConnection[(int)trackTile.frameX];
				int num3 = Minecart._leftSideConnection[(int)trackTile.frameY];
				int num4 = Minecart._rightSideConnection[(int)trackTile.frameY];
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				int num8 = 0;
				for (int k = 0; k < 4; k++)
				{
					int num9;
					switch (k)
					{
					case 1:
						num9 = num2;
						break;
					case 2:
						num9 = num3;
						break;
					case 3:
						num9 = num4;
						break;
					default:
						num9 = num;
						break;
					}
					int num10;
					switch (num9)
					{
					case 0:
						num10 = -1;
						break;
					case 1:
						num10 = 0;
						break;
					case 2:
						num10 = 1;
						break;
					default:
						num10 = 0;
						break;
					}
					Tile tile;
					if (k % 2 == 0)
					{
						tile = Main.tile[i - 1, j + num10];
					}
					else
					{
						tile = Main.tile[i + 1, j + num10];
					}
					int num11;
					if (tile == null || !tile.active() || tile.type != 314)
					{
						num11 = 0;
					}
					else
					{
						num11 = (int)tile.color();
					}
					switch (k)
					{
					case 1:
						num6 = num11;
						break;
					case 2:
						num7 = num11;
						break;
					case 3:
						num8 = num11;
						break;
					default:
						num5 = num11;
						break;
					}
				}
				if (num == num3)
				{
					if (num6 != 0)
					{
						frontColor = num6;
					}
					else if (num5 != 0)
					{
						frontColor = num5;
					}
					if (num8 != 0)
					{
						backColor = num8;
						return;
					}
					if (num7 != 0)
					{
						backColor = num7;
						return;
					}
				}
				else if (num2 == num4)
				{
					if (num5 != 0)
					{
						frontColor = num5;
					}
					else if (num6 != 0)
					{
						frontColor = num6;
					}
					if (num7 != 0)
					{
						backColor = num7;
						return;
					}
					if (num8 != 0)
					{
						backColor = num8;
						return;
					}
				}
				else
				{
					if (num6 == 0)
					{
						if (num5 != 0)
						{
							frontColor = num5;
						}
					}
					else if (num5 != 0)
					{
						frontColor = ((num2 <= num) ? num6 : num5);
					}
					if (num8 == 0)
					{
						if (num7 != 0)
						{
							backColor = num7;
							return;
						}
					}
					else if (num7 != 0)
					{
						backColor = ((num4 <= num3) ? num8 : num7);
						return;
					}
				}
			}
			else
			{
				frontColor = 0;
				backColor = 0;
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0001EF94 File Offset: 0x0001D194
		public static bool DrawLeftDecoration(int frameID)
		{
			return frameID >= 0 && frameID < 36 && Minecart._leftSideConnection[frameID] == 2;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0001EFAC File Offset: 0x0001D1AC
		public static bool DrawRightDecoration(int frameID)
		{
			return frameID >= 0 && frameID < 36 && Minecart._rightSideConnection[frameID] == 2;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0001EFC4 File Offset: 0x0001D1C4
		public static bool DrawBumper(int frameID)
		{
			return frameID >= 0 && frameID < 36 && (Minecart._tileHeight[frameID][0] == -1 || Minecart._tileHeight[frameID][7] == -1);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0001EFEC File Offset: 0x0001D1EC
		public static bool DrawBouncyBumper(int frameID)
		{
			return frameID >= 0 && frameID < 36 && (Minecart._tileHeight[frameID][0] == -2 || Minecart._tileHeight[frameID][7] == -2);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0001F018 File Offset: 0x0001D218
		public static void PlaceTrack(Tile trackCache, int style)
		{
			trackCache.active(true);
			trackCache.type = 314;
			trackCache.frameY = -1;
			switch (style)
			{
			case 0:
				trackCache.frameX = -1;
				return;
			case 1:
				trackCache.frameX = Minecart._firstPressureFrame;
				return;
			case 2:
				trackCache.frameX = Minecart._firstLeftBoostFrame;
				return;
			case 3:
				trackCache.frameX = Minecart._firstRightBoostFrame;
				return;
			default:
				return;
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0001F080 File Offset: 0x0001D280
		public static int GetTrackItem(Tile trackCache)
		{
			switch (Minecart._trackType[(int)trackCache.frameX])
			{
			case 0:
				return 2340;
			case 1:
				return 2492;
			case 2:
				return 2739;
			default:
				return 0;
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0001F0C4 File Offset: 0x0001D2C4
		public static Rectangle GetSourceRect(int frameID, int animationFrame = 0)
		{
			if (frameID < 0 || frameID >= 40)
			{
				return new Rectangle(0, 0, 0, 0);
			}
			Vector2 vector = Minecart._texturePosition[frameID];
			Rectangle result = new Rectangle((int)vector.X, (int)vector.Y, 16, 16);
			if (frameID < 36 && Minecart._trackType[frameID] == 2)
			{
				result.Y += 18 * animationFrame;
			}
			return result;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0001F128 File Offset: 0x0001D328
		public static void WheelSparks(Action<Vector2> DustAction, Vector2 Position, int Width, int Height, int sparkCount)
		{
			Vector2 value = new Vector2((float)(Width / 2) - 25f, (float)(Height / 2));
			Vector2 obj = Position + value + Minecart._trackMagnetOffset;
			for (int i = 0; i < sparkCount; i++)
			{
				DustAction(obj);
			}
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0001F170 File Offset: 0x0001D370
		private static short FrontTrack(this Tile tileTrack)
		{
			return tileTrack.frameX;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0001F178 File Offset: 0x0001D378
		private static void FrontTrack(this Tile tileTrack, short trackID)
		{
			tileTrack.frameX = trackID;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0001F184 File Offset: 0x0001D384
		private static short BackTrack(this Tile tileTrack)
		{
			return tileTrack.frameY;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0001F18C File Offset: 0x0001D38C
		private static void BackTrack(this Tile tileTrack, short trackID)
		{
			tileTrack.frameY = trackID;
		}

		// Token: 0x040000CC RID: 204
		private const int TotalFrames = 36;

		// Token: 0x040000CD RID: 205
		public const int LeftDownDecoration = 36;

		// Token: 0x040000CE RID: 206
		public const int RightDownDecoration = 37;

		// Token: 0x040000CF RID: 207
		public const int BouncyBumperDecoration = 38;

		// Token: 0x040000D0 RID: 208
		public const int RegularBumperDecoration = 39;

		// Token: 0x040000D1 RID: 209
		public const int Flag_OnTrack = 0;

		// Token: 0x040000D2 RID: 210
		public const int Flag_BouncyBumper = 1;

		// Token: 0x040000D3 RID: 211
		public const int Flag_UsedRamp = 2;

		// Token: 0x040000D4 RID: 212
		public const int Flag_HitSwitch = 3;

		// Token: 0x040000D5 RID: 213
		public const int Flag_BoostLeft = 4;

		// Token: 0x040000D6 RID: 214
		public const int Flag_BoostRight = 5;

		// Token: 0x040000D7 RID: 215
		private const int NoConnection = -1;

		// Token: 0x040000D8 RID: 216
		private const int TopConnection = 0;

		// Token: 0x040000D9 RID: 217
		private const int MiddleConnection = 1;

		// Token: 0x040000DA RID: 218
		private const int BottomConnection = 2;

		// Token: 0x040000DB RID: 219
		private const int BumperEnd = -1;

		// Token: 0x040000DC RID: 220
		private const int BouncyEnd = -2;

		// Token: 0x040000DD RID: 221
		private const int RampEnd = -3;

		// Token: 0x040000DE RID: 222
		private const int OpenEnd = -4;

		// Token: 0x040000DF RID: 223
		public const float BoosterSpeed = 4f;

		// Token: 0x040000E0 RID: 224
		private const int Type_Normal = 0;

		// Token: 0x040000E1 RID: 225
		private const int Type_Pressure = 1;

		// Token: 0x040000E2 RID: 226
		private const int Type_Booster = 2;

		// Token: 0x040000E3 RID: 227
		private static Vector2 _trackMagnetOffset = new Vector2(25f, 26f);

		// Token: 0x040000E4 RID: 228
		private const float MinecartTextureWidth = 50f;

		// Token: 0x040000E5 RID: 229
		private static int[] _leftSideConnection;

		// Token: 0x040000E6 RID: 230
		private static int[] _rightSideConnection;

		// Token: 0x040000E7 RID: 231
		private static int[] _trackType;

		// Token: 0x040000E8 RID: 232
		private static bool[] _boostLeft;

		// Token: 0x040000E9 RID: 233
		private static Vector2[] _texturePosition;

		// Token: 0x040000EA RID: 234
		private static short _firstPressureFrame;

		// Token: 0x040000EB RID: 235
		private static short _firstLeftBoostFrame;

		// Token: 0x040000EC RID: 236
		private static short _firstRightBoostFrame;

		// Token: 0x040000ED RID: 237
		private static int[][] _trackSwitchOptions;

		// Token: 0x040000EE RID: 238
		private static int[][] _tileHeight;

		// Token: 0x020001BE RID: 446
		private enum TrackState
		{
			// Token: 0x04003627 RID: 13863
			NoTrack = -1,
			// Token: 0x04003628 RID: 13864
			AboveTrack,
			// Token: 0x04003629 RID: 13865
			OnTrack,
			// Token: 0x0400362A RID: 13866
			BelowTrack,
			// Token: 0x0400362B RID: 13867
			AboveFront,
			// Token: 0x0400362C RID: 13868
			AboveBack,
			// Token: 0x0400362D RID: 13869
			OnFront,
			// Token: 0x0400362E RID: 13870
			OnBack
		}
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Graphics;
using Terraria.ID;
using Terraria.Utilities;

namespace Terraria
{
	// Token: 0x0200002D RID: 45
	public class Lighting
	{
		// Token: 0x0600043C RID: 1084 RVA: 0x00291C7C File Offset: 0x0028FE7C
		public static void AddLight(Vector2 position, Vector3 rgb)
		{
			Lighting.AddLight((int)(position.X / 16f), (int)(position.Y / 16f), rgb.X, rgb.Y, rgb.Z);
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00291CAF File Offset: 0x0028FEAF
		public static void AddLight(Vector2 position, float R, float G, float B)
		{
			Lighting.AddLight((int)(position.X / 16f), (int)(position.Y / 16f), R, G, B);
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x00291CD4 File Offset: 0x0028FED4
		public static void AddLight(int i, int j, float R, float G, float B)
		{
			if (Main.gamePaused)
			{
				return;
			}
			if (Main.netMode == 2)
			{
				return;
			}
			if (i - Lighting.firstTileX + Lighting.offScreenTiles >= 0 && i - Lighting.firstTileX + Lighting.offScreenTiles < Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 && j - Lighting.firstTileY + Lighting.offScreenTiles >= 0 && j - Lighting.firstTileY + Lighting.offScreenTiles < Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10)
			{
				if (Lighting.tempLights.Count == Lighting.maxTempLights)
				{
					return;
				}
				Point16 key = new Point16(i, j);
				Lighting.ColorTriplet colorTriplet;
				if (Lighting.tempLights.TryGetValue(key, out colorTriplet))
				{
					if (Lighting.RGB)
					{
						if (colorTriplet.r < R)
						{
							colorTriplet.r = R;
						}
						if (colorTriplet.g < G)
						{
							colorTriplet.g = G;
						}
						if (colorTriplet.b < B)
						{
							colorTriplet.b = B;
						}
						Lighting.tempLights[key] = colorTriplet;
						return;
					}
					float num = (R + G + B) / 3f;
					if (colorTriplet.r < num)
					{
						Lighting.tempLights[key] = new Lighting.ColorTriplet(num);
						return;
					}
				}
				else
				{
					if (Lighting.RGB)
					{
						colorTriplet = new Lighting.ColorTriplet(R, G, B);
					}
					else
					{
						colorTriplet = new Lighting.ColorTriplet((R + G + B) / 3f);
					}
					Lighting.tempLights.Add(key, colorTriplet);
				}
			}
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x00291E84 File Offset: 0x00290084
		public static void BlackOut()
		{
			int num = Main.screenWidth / 16 + Lighting.offScreenTiles * 2;
			int num2 = Main.screenHeight / 16 + Lighting.offScreenTiles * 2;
			for (int i = 0; i < num; i++)
			{
				Lighting.LightingState[] array = Lighting.states[i];
				for (int j = 0; j < num2; j++)
				{
					Lighting.LightingState expr_37 = array[j];
					expr_37.r = 0f;
					expr_37.g = 0f;
					expr_37.b = 0f;
				}
			}
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x00293138 File Offset: 0x00291338
		public static float Brightness(int x, int y)
		{
			int num = x - Lighting.firstTileX + Lighting.offScreenTiles;
			int num2 = y - Lighting.firstTileY + Lighting.offScreenTiles;
			if (num < 0 || num2 < 0 || num >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 || num2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10)
			{
				return 0f;
			}
			Lighting.LightingState lightingState = Lighting.states[num][num2];
			return Lighting.brightness * (lightingState.r + lightingState.g + lightingState.b) / 3f;
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x002931C8 File Offset: 0x002913C8
		public static float BrightnessAverage(int x, int y, int width, int height)
		{
			int num = x - Lighting.firstTileX + Lighting.offScreenTiles;
			int num2 = y - Lighting.firstTileY + Lighting.offScreenTiles;
			int num3 = num + width;
			int num4 = num2 + height;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num3 >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10)
			{
				num3 = Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10;
			}
			if (num4 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10)
			{
				num4 = Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10;
			}
			float num5 = 0f;
			float num6 = 0f;
			for (int i = num; i < num3; i++)
			{
				for (int j = num2; j < num4; j++)
				{
					num5 += 1f;
					Lighting.LightingState lightingState = Lighting.states[i][j];
					num6 += (lightingState.r + lightingState.g + lightingState.b) / 3f;
				}
			}
			if (num5 == 0f)
			{
				return 0f;
			}
			return num6 / num5;
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x002914EC File Offset: 0x0028F6EC
		private static void callback_LightingSwipe(object obj)
		{
			Lighting.LightingSwipeData lightingSwipeData = obj as Lighting.LightingSwipeData;
			try
			{
				lightingSwipeData.function(lightingSwipeData);
			}
			catch
			{
			}
			Lighting.countdown.Signal();
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00290AA0 File Offset: 0x0028ECA0
		public static void doColors()
		{
			if (Lighting.lightMode < 2)
			{
				Lighting.blueWave += (float)Lighting.blueDir * 0.0001f;
				if (Lighting.blueWave > 1f)
				{
					Lighting.blueWave = 1f;
					Lighting.blueDir = -1;
				}
				else if (Lighting.blueWave < 0.97f)
				{
					Lighting.blueWave = 0.97f;
					Lighting.blueDir = 1;
				}
				if (Lighting.RGB)
				{
					Lighting.negLight = 0.91f;
					Lighting.negLight2 = 0.56f;
					Lighting.honeyLightG = 0.7f * Lighting.negLight * Lighting.blueWave;
					Lighting.honeyLightR = 0.75f * Lighting.negLight * Lighting.blueWave;
					Lighting.honeyLightB = 0.6f * Lighting.negLight * Lighting.blueWave;
					switch (Main.waterStyle)
					{
						case 0:
						case 1:
						case 7:
						case 8:
							Lighting.wetLightG = 0.96f * Lighting.negLight * Lighting.blueWave;
							Lighting.wetLightR = 0.88f * Lighting.negLight * Lighting.blueWave;
							Lighting.wetLightB = 1.015f * Lighting.negLight * Lighting.blueWave;
							break;
						case 2:
							Lighting.wetLightG = 0.85f * Lighting.negLight * Lighting.blueWave;
							Lighting.wetLightR = 0.94f * Lighting.negLight * Lighting.blueWave;
							Lighting.wetLightB = 1.01f * Lighting.negLight * Lighting.blueWave;
							break;
						case 3:
							Lighting.wetLightG = 0.95f * Lighting.negLight * Lighting.blueWave;
							Lighting.wetLightR = 0.84f * Lighting.negLight * Lighting.blueWave;
							Lighting.wetLightB = 1.015f * Lighting.negLight * Lighting.blueWave;
							break;
						case 4:
							Lighting.wetLightG = 0.86f * Lighting.negLight * Lighting.blueWave;
							Lighting.wetLightR = 0.9f * Lighting.negLight * Lighting.blueWave;
							Lighting.wetLightB = 1.01f * Lighting.negLight * Lighting.blueWave;
							break;
						case 5:
							Lighting.wetLightG = 0.99f * Lighting.negLight * Lighting.blueWave;
							Lighting.wetLightR = 0.84f * Lighting.negLight * Lighting.blueWave;
							Lighting.wetLightB = 1.01f * Lighting.negLight * Lighting.blueWave;
							break;
						case 6:
							Lighting.wetLightG = 0.98f * Lighting.negLight * Lighting.blueWave;
							Lighting.wetLightR = 0.95f * Lighting.negLight * Lighting.blueWave;
							Lighting.wetLightB = 0.85f * Lighting.negLight * Lighting.blueWave;
							break;
						case 9:
							Lighting.wetLightG = 0.88f * Lighting.negLight * Lighting.blueWave;
							Lighting.wetLightR = 1f * Lighting.negLight * Lighting.blueWave;
							Lighting.wetLightB = 0.84f * Lighting.negLight * Lighting.blueWave;
							break;
						case 10:
							Lighting.wetLightG = 1f * Lighting.negLight * Lighting.blueWave;
							Lighting.wetLightR = 0.83f * Lighting.negLight * Lighting.blueWave;
							Lighting.wetLightB = 1f * Lighting.negLight * Lighting.blueWave;
							break;
						default:
							Lighting.wetLightG = 0f;
							Lighting.wetLightR = 0f;
							Lighting.wetLightB = 0f;
							break;
					}
				}
				else
				{
					Lighting.negLight = 0.9f;
					Lighting.negLight2 = 0.54f;
					Lighting.wetLightR = 0.95f * Lighting.negLight * Lighting.blueWave;
				}
				if (Main.player[Main.myPlayer].nightVision)
				{
					Lighting.negLight *= 1.03f;
					Lighting.negLight2 *= 1.03f;
				}
				if (Main.player[Main.myPlayer].blind)
				{
					Lighting.negLight *= 0.95f;
					Lighting.negLight2 *= 0.95f;
				}
				if (Main.player[Main.myPlayer].blackout)
				{
					Lighting.negLight *= 0.85f;
					Lighting.negLight2 *= 0.85f;
				}
				if (Main.player[Main.myPlayer].headcovered)
				{
					Lighting.negLight *= 0.85f;
					Lighting.negLight2 *= 0.85f;
				}
			}
			else
			{
				Lighting.negLight = 0.04f;
				Lighting.negLight2 = 0.16f;
				if (Main.player[Main.myPlayer].nightVision)
				{
					Lighting.negLight -= 0.013f;
					Lighting.negLight2 -= 0.04f;
				}
				if (Main.player[Main.myPlayer].blind)
				{
					Lighting.negLight += 0.03f;
					Lighting.negLight2 += 0.06f;
				}
				if (Main.player[Main.myPlayer].blackout)
				{
					Lighting.negLight += 0.09f;
					Lighting.negLight2 += 0.18f;
				}
				if (Main.player[Main.myPlayer].headcovered)
				{
					Lighting.negLight += 0.09f;
					Lighting.negLight2 += 0.18f;
				}
				Lighting.wetLightR = Lighting.negLight * 1.2f;
				Lighting.wetLightG = Lighting.negLight * 1.1f;
			}
			int num;
			int num2;
			switch (Main.renderCount)
			{
				case 0:
					num = 0;
					num2 = 1;
					break;
				case 1:
					num = 1;
					num2 = 3;
					break;
				case 2:
					num = 3;
					num2 = 4;
					break;
				default:
					num = 0;
					num2 = 0;
					break;
			}
			if (Lighting.LightingThreads < 0)
			{
				Lighting.LightingThreads = 0;
			}
			if (Lighting.LightingThreads >= Environment.ProcessorCount)
			{
				Lighting.LightingThreads = Environment.ProcessorCount - 1;
			}
			int num3 = Lighting.LightingThreads;
			if (num3 > 0)
			{
				num3++;
			}
			Stopwatch stopwatch = new Stopwatch();
			for (int i = num; i < num2; i++)
			{
				stopwatch.Restart();
				switch (i)
				{
					case 0:
						Lighting.swipe.innerLoop1Start = Lighting.minY7 - Lighting.firstToLightY7;
						Lighting.swipe.innerLoop1End = Lighting.lastToLightY27 + Lighting.maxRenderCount - Lighting.firstToLightY7;
						Lighting.swipe.innerLoop2Start = Lighting.maxY7 - Lighting.firstToLightY;
						Lighting.swipe.innerLoop2End = Lighting.firstTileY7 - Lighting.maxRenderCount - Lighting.firstToLightY7;
						Lighting.swipe.outerLoopStart = Lighting.minX7 - Lighting.firstToLightX7;
						Lighting.swipe.outerLoopEnd = Lighting.maxX7 - Lighting.firstToLightX7;
						Lighting.swipe.jaggedArray = Lighting.states;
						break;
					case 1:
						Lighting.swipe.innerLoop1Start = Lighting.minX7 - Lighting.firstToLightX7;
						Lighting.swipe.innerLoop1End = Lighting.lastTileX7 + Lighting.maxRenderCount - Lighting.firstToLightX7;
						Lighting.swipe.innerLoop2Start = Lighting.maxX7 - Lighting.firstToLightX7;
						Lighting.swipe.innerLoop2End = Lighting.firstTileX7 - Lighting.maxRenderCount - Lighting.firstToLightX7;
						Lighting.swipe.outerLoopStart = Lighting.firstToLightY7 - Lighting.firstToLightY7;
						Lighting.swipe.outerLoopEnd = Lighting.lastToLightY7 - Lighting.firstToLightY7;
						Lighting.swipe.jaggedArray = Lighting.axisFlipStates;
						break;
					case 2:
						Lighting.swipe.innerLoop1Start = Lighting.firstToLightY27 - Lighting.firstToLightY7;
						Lighting.swipe.innerLoop1End = Lighting.lastTileY7 + Lighting.maxRenderCount - Lighting.firstToLightY7;
						Lighting.swipe.innerLoop2Start = Lighting.lastToLightY27 - Lighting.firstToLightY;
						Lighting.swipe.innerLoop2End = Lighting.firstTileY7 - Lighting.maxRenderCount - Lighting.firstToLightY7;
						Lighting.swipe.outerLoopStart = Lighting.firstToLightX27 - Lighting.firstToLightX7;
						Lighting.swipe.outerLoopEnd = Lighting.lastToLightX27 - Lighting.firstToLightX7;
						Lighting.swipe.jaggedArray = Lighting.states;
						break;
					case 3:
						Lighting.swipe.innerLoop1Start = Lighting.firstToLightX27 - Lighting.firstToLightX7;
						Lighting.swipe.innerLoop1End = Lighting.lastTileX7 + Lighting.maxRenderCount - Lighting.firstToLightX7;
						Lighting.swipe.innerLoop2Start = Lighting.lastToLightX27 - Lighting.firstToLightX7;
						Lighting.swipe.innerLoop2End = Lighting.firstTileX7 - Lighting.maxRenderCount - Lighting.firstToLightX7;
						Lighting.swipe.outerLoopStart = Lighting.firstToLightY27 - Lighting.firstToLightY7;
						Lighting.swipe.outerLoopEnd = Lighting.lastToLightY27 - Lighting.firstToLightY7;
						Lighting.swipe.jaggedArray = Lighting.axisFlipStates;
						break;
				}
				if (Lighting.swipe.innerLoop1Start > Lighting.swipe.innerLoop1End)
				{
					Lighting.swipe.innerLoop1Start = Lighting.swipe.innerLoop1End;
				}
				if (Lighting.swipe.innerLoop2Start < Lighting.swipe.innerLoop2End)
				{
					Lighting.swipe.innerLoop2Start = Lighting.swipe.innerLoop2End;
				}
				if (Lighting.swipe.outerLoopStart > Lighting.swipe.outerLoopEnd)
				{
					Lighting.swipe.outerLoopStart = Lighting.swipe.outerLoopEnd;
				}
				switch (Lighting.lightMode)
				{
					case 0:
						Lighting.swipe.function = new Action<Lighting.LightingSwipeData>(Lighting.doColors_Mode0_Swipe);
						break;
					case 1:
						Lighting.swipe.function = new Action<Lighting.LightingSwipeData>(Lighting.doColors_Mode1_Swipe);
						break;
					case 2:
						Lighting.swipe.function = new Action<Lighting.LightingSwipeData>(Lighting.doColors_Mode2_Swipe);
						break;
					case 3:
						Lighting.swipe.function = new Action<Lighting.LightingSwipeData>(Lighting.doColors_Mode3_Swipe);
						break;
					default:
						Lighting.swipe.function = null;
						break;
				}
				if (num3 == 0)
				{
					Lighting.swipe.function(Lighting.swipe);
				}
				else
				{
					int expr_989 = Lighting.swipe.outerLoopEnd - Lighting.swipe.outerLoopStart;
					int num4 = expr_989 / num3;
					int num5 = expr_989 % num3;
					int num6 = Lighting.swipe.outerLoopStart;
					Lighting.countdown.Reset(num3);
					for (int j = 0; j < num3; j++)
					{
						Lighting.LightingSwipeData lightingSwipeData = Lighting.threadSwipes[j];
						lightingSwipeData.CopyFrom(Lighting.swipe);
						lightingSwipeData.outerLoopStart = num6;
						num6 += num4;
						if (num5 > 0)
						{
							num6++;
							num5--;
						}
						lightingSwipeData.outerLoopEnd = num6;
						ThreadPool.QueueUserWorkItem(new WaitCallback(Lighting.callback_LightingSwipe), lightingSwipeData);
					}
					while (Lighting.countdown.CurrentCount != 0)
					{
					}
				}
				TimeLogger.LightingTime(i + 1, stopwatch.Elapsed.TotalMilliseconds);
			}
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x0029152C File Offset: 0x0028F72C
		private static void doColors_Mode0_Swipe(Lighting.LightingSwipeData swipeData)
		{
			try
			{
				bool flag = true;
				while (true)
				{
					int num;
					int num2;
					int num3;
					if (flag)
					{
						num = 1;
						num2 = swipeData.innerLoop1Start;
						num3 = swipeData.innerLoop1End;
					}
					else
					{
						num = -1;
						num2 = swipeData.innerLoop2Start;
						num3 = swipeData.innerLoop2End;
					}
					int arg_35_0 = swipeData.outerLoopStart;
					int outerLoopEnd = swipeData.outerLoopEnd;
					for (int i = arg_35_0; i < outerLoopEnd; i++)
					{
						Lighting.LightingState[] array = swipeData.jaggedArray[i];
						float num4 = 0f;
						float num5 = 0f;
						float num6 = 0f;
						int arg_60_0 = num2;
						int num7 = num3;
						int num8 = arg_60_0;
						while (num8 != num7)
						{
							Lighting.LightingState lightingState = array[num8];
							Lighting.LightingState lightingState2 = array[num8 + num];
							bool flag3;
							bool flag2 = flag3 = false;
							if (lightingState.r2 > num4)
							{
								num4 = lightingState.r2;
							}
							else if ((double)num4 <= 0.0185)
							{
								flag3 = true;
							}
							else if (lightingState.r2 < num4)
							{
								lightingState.r2 = num4;
							}
							if (!flag3 && lightingState2.r2 <= num4)
							{
								if (lightingState.stopLight)
								{
									num4 *= Lighting.negLight2;
								}
								else if (lightingState.wetLight)
								{
									if (lightingState.honeyLight)
									{
										num4 *= Lighting.honeyLightR * (float)swipeData.rand.Next(98, 100) * 0.01f;
									}
									else
									{
										num4 *= Lighting.wetLightR * (float)swipeData.rand.Next(98, 100) * 0.01f;
									}
								}
								else
								{
									num4 *= Lighting.negLight;
								}
							}
							if (lightingState.g2 > num5)
							{
								num5 = lightingState.g2;
							}
							else if ((double)num5 <= 0.0185)
							{
								flag2 = true;
							}
							else
							{
								lightingState.g2 = num5;
							}
							if (!flag2 && lightingState2.g2 <= num5)
							{
								if (lightingState.stopLight)
								{
									num5 *= Lighting.negLight2;
								}
								else if (lightingState.wetLight)
								{
									if (lightingState.honeyLight)
									{
										num5 *= Lighting.honeyLightG * (float)swipeData.rand.Next(97, 100) * 0.01f;
									}
									else
									{
										num5 *= Lighting.wetLightG * (float)swipeData.rand.Next(97, 100) * 0.01f;
									}
								}
								else
								{
									num5 *= Lighting.negLight;
								}
							}
							if (lightingState.b2 > num6)
							{
								num6 = lightingState.b2;
								goto IL_22E;
							}
							if ((double)num6 > 0.0185)
							{
								lightingState.b2 = num6;
								goto IL_22E;
							}
							IL_2B0:
							num8 += num;
							continue;
							IL_22E:
							if (lightingState2.b2 >= num6)
							{
								goto IL_2B0;
							}
							if (lightingState.stopLight)
							{
								num6 *= Lighting.negLight2;
								goto IL_2B0;
							}
							if (!lightingState.wetLight)
							{
								num6 *= Lighting.negLight;
								goto IL_2B0;
							}
							if (lightingState.honeyLight)
							{
								num6 *= Lighting.honeyLightB * (float)swipeData.rand.Next(97, 100) * 0.01f;
								goto IL_2B0;
							}
							num6 *= Lighting.wetLightB * (float)swipeData.rand.Next(97, 100) * 0.01f;
							goto IL_2B0;
						}
					}
					if (!flag)
					{
						break;
					}
					flag = false;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00291834 File Offset: 0x0028FA34
		private static void doColors_Mode1_Swipe(Lighting.LightingSwipeData swipeData)
		{
			try
			{
				bool flag = true;
				while (true)
				{
					int num;
					int num2;
					int num3;
					if (flag)
					{
						num = 1;
						num2 = swipeData.innerLoop1Start;
						num3 = swipeData.innerLoop1End;
					}
					else
					{
						num = -1;
						num2 = swipeData.innerLoop2Start;
						num3 = swipeData.innerLoop2End;
					}
					int arg_35_0 = swipeData.outerLoopStart;
					int outerLoopEnd = swipeData.outerLoopEnd;
					for (int i = arg_35_0; i < outerLoopEnd; i++)
					{
						Lighting.LightingState[] array = swipeData.jaggedArray[i];
						float num4 = 0f;
						int num5 = num2;
						while (num5 != num3)
						{
							Lighting.LightingState lightingState = array[num5];
							if (lightingState.r2 > num4)
							{
								num4 = lightingState.r2;
								goto IL_98;
							}
							if ((double)num4 > 0.0185)
							{
								if (lightingState.r2 < num4)
								{
									lightingState.r2 = num4;
									goto IL_98;
								}
								goto IL_98;
							}
							IL_11F:
							num5 += num;
							continue;
							IL_98:
							if (array[num5 + num].r2 > num4)
							{
								goto IL_11F;
							}
							if (lightingState.stopLight)
							{
								num4 *= Lighting.negLight2;
								goto IL_11F;
							}
							if (!lightingState.wetLight)
							{
								num4 *= Lighting.negLight;
								goto IL_11F;
							}
							if (lightingState.honeyLight)
							{
								num4 *= Lighting.honeyLightR * (float)swipeData.rand.Next(98, 100) * 0.01f;
								goto IL_11F;
							}
							num4 *= Lighting.wetLightR * (float)swipeData.rand.Next(98, 100) * 0.01f;
							goto IL_11F;
						}
					}
					if (!flag)
					{
						break;
					}
					flag = false;
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x002919A8 File Offset: 0x0028FBA8
		private static void doColors_Mode2_Swipe(Lighting.LightingSwipeData swipeData)
		{
			try
			{
				bool flag = true;
				while (true)
				{
					int num;
					int num2;
					int num3;
					if (flag)
					{
						num = 1;
						num2 = swipeData.innerLoop1Start;
						num3 = swipeData.innerLoop1End;
					}
					else
					{
						num = -1;
						num2 = swipeData.innerLoop2Start;
						num3 = swipeData.innerLoop2End;
					}
					int arg_35_0 = swipeData.outerLoopStart;
					int outerLoopEnd = swipeData.outerLoopEnd;
					for (int i = arg_35_0; i < outerLoopEnd; i++)
					{
						Lighting.LightingState[] array = swipeData.jaggedArray[i];
						float num4 = 0f;
						int num5 = num2;
						while (num5 != num3)
						{
							Lighting.LightingState lightingState = array[num5];
							if (lightingState.r2 > num4)
							{
								num4 = lightingState.r2;
								goto IL_82;
							}
							if (num4 > 0f)
							{
								lightingState.r2 = num4;
								goto IL_82;
							}
							IL_B6:
							num5 += num;
							continue;
							IL_82:
							if (lightingState.stopLight)
							{
								num4 -= Lighting.negLight2;
								goto IL_B6;
							}
							if (lightingState.wetLight)
							{
								num4 -= Lighting.wetLightR;
								goto IL_B6;
							}
							num4 -= Lighting.negLight;
							goto IL_B6;
						}
					}
					if (!flag)
					{
						break;
					}
					flag = false;
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x00291AA4 File Offset: 0x0028FCA4
		private static void doColors_Mode3_Swipe(Lighting.LightingSwipeData swipeData)
		{
			try
			{
				bool flag = true;
				while (true)
				{
					int num;
					int num2;
					int num3;
					if (flag)
					{
						num = 1;
						num2 = swipeData.innerLoop1Start;
						num3 = swipeData.innerLoop1End;
					}
					else
					{
						num = -1;
						num2 = swipeData.innerLoop2Start;
						num3 = swipeData.innerLoop2End;
					}
					int arg_35_0 = swipeData.outerLoopStart;
					int outerLoopEnd = swipeData.outerLoopEnd;
					for (int i = arg_35_0; i < outerLoopEnd; i++)
					{
						Lighting.LightingState[] array = swipeData.jaggedArray[i];
						float num4 = 0f;
						float num5 = 0f;
						float num6 = 0f;
						int num7 = num2;
						while (num7 != num3)
						{
							Lighting.LightingState lightingState = array[num7];
							bool flag3;
							bool flag2 = flag3 = false;
							if (lightingState.r2 > num4)
							{
								num4 = lightingState.r2;
							}
							else if (num4 <= 0f)
							{
								flag3 = true;
							}
							else
							{
								lightingState.r2 = num4;
							}
							if (!flag3)
							{
								if (lightingState.stopLight)
								{
									num4 -= Lighting.negLight2;
								}
								else if (lightingState.wetLight)
								{
									num4 -= Lighting.wetLightR;
								}
								else
								{
									num4 -= Lighting.negLight;
								}
							}
							if (lightingState.g2 > num5)
							{
								num5 = lightingState.g2;
							}
							else if (num5 <= 0f)
							{
								flag2 = true;
							}
							else
							{
								lightingState.g2 = num5;
							}
							if (!flag2)
							{
								if (lightingState.stopLight)
								{
									num5 -= Lighting.negLight2;
								}
								else if (lightingState.wetLight)
								{
									num5 -= Lighting.wetLightG;
								}
								else
								{
									num5 -= Lighting.negLight;
								}
							}
							if (lightingState.b2 > num6)
							{
								num6 = lightingState.b2;
								goto IL_163;
							}
							if (num6 > 0f)
							{
								lightingState.b2 = num6;
								goto IL_163;
							}
							IL_182:
							num7 += num;
							continue;
							IL_163:
							if (lightingState.stopLight)
							{
								num6 -= Lighting.negLight2;
								goto IL_182;
							}
							num6 -= Lighting.negLight;
							goto IL_182;
						}
					}
					if (!flag)
					{
						break;
					}
					flag = false;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x002930B0 File Offset: 0x002912B0
		public static Color GetBlackness(int x, int y)
		{
			int num = x - Lighting.firstTileX + Lighting.offScreenTiles;
			int num2 = y - Lighting.firstTileY + Lighting.offScreenTiles;
			if (num < 0 || num2 < 0 || num >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 || num2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10)
			{
				return Color.Black;
			}
			return new Color(0, 0, 0, (int)((byte)(255f - 255f * Lighting.states[num][num2].r)));
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x00292010 File Offset: 0x00290210
		public static Color GetColor(int x, int y)
		{
			int num = x - Lighting.firstTileX + Lighting.offScreenTiles;
			int num2 = y - Lighting.firstTileY + Lighting.offScreenTiles;
			if (Main.gameMenu)
			{
				return Color.White;
			}
			if (num < 0 || num2 < 0 || num >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 || num2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2)
			{
				return Color.Black;
			}
			Lighting.LightingState lightingState = Lighting.states[num][num2];
			int num3 = (int)(255f * lightingState.r * Lighting.brightness);
			int num4 = (int)(255f * lightingState.g * Lighting.brightness);
			int num5 = (int)(255f * lightingState.b * Lighting.brightness);
			if (num3 > 255)
			{
				num3 = 255;
			}
			if (num4 > 255)
			{
				num4 = 255;
			}
			if (num5 > 255)
			{
				num5 = 255;
			}
			return new Color((int)((byte)num3), (int)((byte)num4), (int)((byte)num5), 255);
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x00291EFC File Offset: 0x002900FC
		public static Color GetColor(int x, int y, Color oldColor)
		{
			int num = x - Lighting.firstTileX + Lighting.offScreenTiles;
			int num2 = y - Lighting.firstTileY + Lighting.offScreenTiles;
			if (Main.gameMenu)
			{
				return oldColor;
			}
			if (num < 0 || num2 < 0 || num >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 || num2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10)
			{
				return Color.Black;
			}
			Color white = Color.White;
			Lighting.LightingState lightingState = Lighting.states[num][num2];
			int num3 = (int)((float)oldColor.R * lightingState.r * Lighting.brightness);
			int num4 = (int)((float)oldColor.G * lightingState.g * Lighting.brightness);
			int num5 = (int)((float)oldColor.B * lightingState.b * Lighting.brightness);
			if (num3 > 255)
			{
				num3 = 255;
			}
			if (num4 > 255)
			{
				num4 = 255;
			}
			if (num5 > 255)
			{
				num5 = 255;
			}
			white.R = (byte)num3;
			white.G = (byte)num4;
			white.B = (byte)num5;
			return white;
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00292B1C File Offset: 0x00290D1C
		public static void GetColor4Slice(int centerX, int centerY, ref Color[] slices)
		{
			int i = centerX - Lighting.firstTileX + Lighting.offScreenTiles;
			int num = centerY - Lighting.firstTileY + Lighting.offScreenTiles;
			if (i <= 0 || num <= 0 || i >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 - 1 || num >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 - 1)
			{
				for (i = 0; i < 4; i++)
				{
					slices[i] = Color.Black;
				}
				return;
			}
			Lighting.LightingState lightingState = Lighting.states[i][num - 1];
			Lighting.LightingState lightingState2 = Lighting.states[i][num + 1];
			Lighting.LightingState lightingState3 = Lighting.states[i - 1][num];
			Lighting.LightingState lightingState4 = Lighting.states[i + 1][num];
			float arg_F9_0 = lightingState.r + lightingState.g + lightingState.b;
			float num2 = lightingState2.r + lightingState2.g + lightingState2.b;
			float num3 = lightingState4.r + lightingState4.g + lightingState4.b;
			float num4 = lightingState3.r + lightingState3.g + lightingState3.b;
			if (arg_F9_0 >= num4)
			{
				int num5 = (int)(255f * lightingState3.r * Lighting.brightness);
				int num6 = (int)(255f * lightingState3.g * Lighting.brightness);
				int num7 = (int)(255f * lightingState3.b * Lighting.brightness);
				if (num5 > 255)
				{
					num5 = 255;
				}
				if (num6 > 255)
				{
					num6 = 255;
				}
				if (num7 > 255)
				{
					num7 = 255;
				}
				slices[0] = new Color((int)((byte)num5), (int)((byte)num6), (int)((byte)num7), 255);
			}
			else
			{
				int num8 = (int)(255f * lightingState.r * Lighting.brightness);
				int num9 = (int)(255f * lightingState.g * Lighting.brightness);
				int num10 = (int)(255f * lightingState.b * Lighting.brightness);
				if (num8 > 255)
				{
					num8 = 255;
				}
				if (num9 > 255)
				{
					num9 = 255;
				}
				if (num10 > 255)
				{
					num10 = 255;
				}
				slices[0] = new Color((int)((byte)num8), (int)((byte)num9), (int)((byte)num10), 255);
			}
			if (arg_F9_0 >= num3)
			{
				int num11 = (int)(255f * lightingState4.r * Lighting.brightness);
				int num12 = (int)(255f * lightingState4.g * Lighting.brightness);
				int num13 = (int)(255f * lightingState4.b * Lighting.brightness);
				if (num11 > 255)
				{
					num11 = 255;
				}
				if (num12 > 255)
				{
					num12 = 255;
				}
				if (num13 > 255)
				{
					num13 = 255;
				}
				slices[1] = new Color((int)((byte)num11), (int)((byte)num12), (int)((byte)num13), 255);
			}
			else
			{
				int num14 = (int)(255f * lightingState.r * Lighting.brightness);
				int num15 = (int)(255f * lightingState.g * Lighting.brightness);
				int num16 = (int)(255f * lightingState.b * Lighting.brightness);
				if (num14 > 255)
				{
					num14 = 255;
				}
				if (num15 > 255)
				{
					num15 = 255;
				}
				if (num16 > 255)
				{
					num16 = 255;
				}
				slices[1] = new Color((int)((byte)num14), (int)((byte)num15), (int)((byte)num16), 255);
			}
			if (num2 >= num4)
			{
				int num17 = (int)(255f * lightingState3.r * Lighting.brightness);
				int num18 = (int)(255f * lightingState3.g * Lighting.brightness);
				int num19 = (int)(255f * lightingState3.b * Lighting.brightness);
				if (num17 > 255)
				{
					num17 = 255;
				}
				if (num18 > 255)
				{
					num18 = 255;
				}
				if (num19 > 255)
				{
					num19 = 255;
				}
				slices[2] = new Color((int)((byte)num17), (int)((byte)num18), (int)((byte)num19), 255);
			}
			else
			{
				int num20 = (int)(255f * lightingState2.r * Lighting.brightness);
				int num21 = (int)(255f * lightingState2.g * Lighting.brightness);
				int num22 = (int)(255f * lightingState2.b * Lighting.brightness);
				if (num20 > 255)
				{
					num20 = 255;
				}
				if (num21 > 255)
				{
					num21 = 255;
				}
				if (num22 > 255)
				{
					num22 = 255;
				}
				slices[2] = new Color((int)((byte)num20), (int)((byte)num21), (int)((byte)num22), 255);
			}
			if (num2 >= num3)
			{
				int num23 = (int)(255f * lightingState4.r * Lighting.brightness);
				int num24 = (int)(255f * lightingState4.g * Lighting.brightness);
				int num25 = (int)(255f * lightingState4.b * Lighting.brightness);
				if (num23 > 255)
				{
					num23 = 255;
				}
				if (num24 > 255)
				{
					num24 = 255;
				}
				if (num25 > 255)
				{
					num25 = 255;
				}
				slices[3] = new Color((int)((byte)num23), (int)((byte)num24), (int)((byte)num25), 255);
				return;
			}
			int num26 = (int)(255f * lightingState2.r * Lighting.brightness);
			int num27 = (int)(255f * lightingState2.g * Lighting.brightness);
			int num28 = (int)(255f * lightingState2.b * Lighting.brightness);
			if (num26 > 255)
			{
				num26 = 255;
			}
			if (num27 > 255)
			{
				num27 = 255;
			}
			if (num28 > 255)
			{
				num28 = 255;
			}
			slices[3] = new Color((int)((byte)num26), (int)((byte)num27), (int)((byte)num28), 255);
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00292380 File Offset: 0x00290580
		public static void GetColor4Slice_New(int centerX, int centerY, out VertexColors vertices, float scale = 1f)
		{
			int num = centerX - Lighting.firstTileX + Lighting.offScreenTiles;
			int num2 = centerY - Lighting.firstTileY + Lighting.offScreenTiles;
			if (num <= 0 || num2 <= 0 || num >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 - 1 || num2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 - 1)
			{
				vertices.BottomLeftColor = Color.Black;
				vertices.BottomRightColor = Color.Black;
				vertices.TopLeftColor = Color.Black;
				vertices.TopRightColor = Color.Black;
				return;
			}
			Lighting.LightingState lightingState = Lighting.states[num][num2];
			Lighting.LightingState arg_10A_0 = Lighting.states[num][num2 - 1];
			Lighting.LightingState lightingState2 = Lighting.states[num][num2 + 1];
			Lighting.LightingState lightingState3 = Lighting.states[num - 1][num2];
			Lighting.LightingState lightingState4 = Lighting.states[num + 1][num2];
			Lighting.LightingState lightingState5 = Lighting.states[num - 1][num2 - 1];
			Lighting.LightingState lightingState6 = Lighting.states[num + 1][num2 - 1];
			Lighting.LightingState lightingState7 = Lighting.states[num - 1][num2 + 1];
			Lighting.LightingState lightingState8 = Lighting.states[num + 1][num2 + 1];
			float num3 = Lighting.brightness * scale * 255f * 0.25f;
			float num4 = (arg_10A_0.r + lightingState5.r + lightingState3.r + lightingState.r) * num3;
			float num5 = (arg_10A_0.g + lightingState5.g + lightingState3.g + lightingState.g) * num3;
			float num6 = (arg_10A_0.b + lightingState5.b + lightingState3.b + lightingState.b) * num3;
			if (num4 > 255f)
			{
				num4 = 255f;
			}
			if (num5 > 255f)
			{
				num5 = 255f;
			}
			if (num6 > 255f)
			{
				num6 = 255f;
			}
			vertices.TopLeftColor = new Color((int)((byte)num4), (int)((byte)num5), (int)((byte)num6), 255);
			num4 = (arg_10A_0.r + lightingState6.r + lightingState4.r + lightingState.r) * num3;
			num5 = (arg_10A_0.g + lightingState6.g + lightingState4.g + lightingState.g) * num3;
			num6 = (arg_10A_0.b + lightingState6.b + lightingState4.b + lightingState.b) * num3;
			if (num4 > 255f)
			{
				num4 = 255f;
			}
			if (num5 > 255f)
			{
				num5 = 255f;
			}
			if (num6 > 255f)
			{
				num6 = 255f;
			}
			vertices.TopRightColor = new Color((int)((byte)num4), (int)((byte)num5), (int)((byte)num6), 255);
			num4 = (lightingState2.r + lightingState7.r + lightingState3.r + lightingState.r) * num3;
			num5 = (lightingState2.g + lightingState7.g + lightingState3.g + lightingState.g) * num3;
			num6 = (lightingState2.b + lightingState7.b + lightingState3.b + lightingState.b) * num3;
			if (num4 > 255f)
			{
				num4 = 255f;
			}
			if (num5 > 255f)
			{
				num5 = 255f;
			}
			if (num6 > 255f)
			{
				num6 = 255f;
			}
			vertices.BottomLeftColor = new Color((int)((byte)num4), (int)((byte)num5), (int)((byte)num6), 255);
			num4 = (lightingState2.r + lightingState8.r + lightingState4.r + lightingState.r) * num3;
			num5 = (lightingState2.g + lightingState8.g + lightingState4.g + lightingState.g) * num3;
			num6 = (lightingState2.b + lightingState8.b + lightingState4.b + lightingState.b) * num3;
			if (num4 > 255f)
			{
				num4 = 255f;
			}
			if (num5 > 255f)
			{
				num5 = 255f;
			}
			if (num6 > 255f)
			{
				num6 = 255f;
			}
			vertices.BottomRightColor = new Color((int)((byte)num4), (int)((byte)num5), (int)((byte)num6), 255);
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00292754 File Offset: 0x00290954
		public static void GetColor4Slice_New(int centerX, int centerY, out VertexColors vertices, Color centerColor, float scale = 1f)
		{
			int num = centerX - Lighting.firstTileX + Lighting.offScreenTiles;
			int num2 = centerY - Lighting.firstTileY + Lighting.offScreenTiles;
			if (num <= 0 || num2 <= 0 || num >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 - 1 || num2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 - 1)
			{
				vertices.BottomLeftColor = Color.Black;
				vertices.BottomRightColor = Color.Black;
				vertices.TopLeftColor = Color.Black;
				vertices.TopRightColor = Color.Black;
				return;
			}
			float num3 = (float)centerColor.R / 255f;
			float num4 = (float)centerColor.G / 255f;
			float num5 = (float)centerColor.B / 255f;
			Lighting.LightingState arg_130_0 = Lighting.states[num][num2 - 1];
			Lighting.LightingState lightingState = Lighting.states[num][num2 + 1];
			Lighting.LightingState lightingState2 = Lighting.states[num - 1][num2];
			Lighting.LightingState lightingState3 = Lighting.states[num + 1][num2];
			Lighting.LightingState lightingState4 = Lighting.states[num - 1][num2 - 1];
			Lighting.LightingState lightingState5 = Lighting.states[num + 1][num2 - 1];
			Lighting.LightingState lightingState6 = Lighting.states[num - 1][num2 + 1];
			Lighting.LightingState lightingState7 = Lighting.states[num + 1][num2 + 1];
			float num6 = Lighting.brightness * scale * 255f * 0.25f;
			float num7 = (arg_130_0.r + lightingState4.r + lightingState2.r + num3) * num6;
			float num8 = (arg_130_0.g + lightingState4.g + lightingState2.g + num4) * num6;
			float num9 = (arg_130_0.b + lightingState4.b + lightingState2.b + num5) * num6;
			if (num7 > 255f)
			{
				num7 = 255f;
			}
			if (num8 > 255f)
			{
				num8 = 255f;
			}
			if (num9 > 255f)
			{
				num9 = 255f;
			}
			vertices.TopLeftColor = new Color((int)((byte)num7), (int)((byte)num8), (int)((byte)num9), 255);
			num7 = (arg_130_0.r + lightingState5.r + lightingState3.r + num3) * num6;
			num8 = (arg_130_0.g + lightingState5.g + lightingState3.g + num4) * num6;
			num9 = (arg_130_0.b + lightingState5.b + lightingState3.b + num5) * num6;
			if (num7 > 255f)
			{
				num7 = 255f;
			}
			if (num8 > 255f)
			{
				num8 = 255f;
			}
			if (num9 > 255f)
			{
				num9 = 255f;
			}
			vertices.TopRightColor = new Color((int)((byte)num7), (int)((byte)num8), (int)((byte)num9), 255);
			num7 = (lightingState.r + lightingState6.r + lightingState2.r + num3) * num6;
			num8 = (lightingState.g + lightingState6.g + lightingState2.g + num4) * num6;
			num9 = (lightingState.b + lightingState6.b + lightingState2.b + num5) * num6;
			if (num7 > 255f)
			{
				num7 = 255f;
			}
			if (num8 > 255f)
			{
				num8 = 255f;
			}
			if (num9 > 255f)
			{
				num9 = 255f;
			}
			vertices.BottomLeftColor = new Color((int)((byte)num7), (int)((byte)num8), (int)((byte)num9), 255);
			num7 = (lightingState.r + lightingState7.r + lightingState3.r + num3) * num6;
			num8 = (lightingState.g + lightingState7.g + lightingState3.g + num4) * num6;
			num9 = (lightingState.b + lightingState7.b + lightingState3.b + num5) * num6;
			if (num7 > 255f)
			{
				num7 = 255f;
			}
			if (num8 > 255f)
			{
				num8 = 255f;
			}
			if (num9 > 255f)
			{
				num9 = 255f;
			}
			vertices.BottomRightColor = new Color((int)((byte)num7), (int)((byte)num8), (int)((byte)num9), 255);
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x00292108 File Offset: 0x00290308
		public static void GetColor9Slice(int centerX, int centerY, ref Color[] slices)
		{
			int num = centerX - Lighting.firstTileX + Lighting.offScreenTiles;
			int num2 = centerY - Lighting.firstTileY + Lighting.offScreenTiles;
			if (num <= 0 || num2 <= 0 || num >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 - 1 || num2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 - 1)
			{
				for (int i = 0; i < 9; i++)
				{
					slices[i] = Color.Black;
				}
				return;
			}
			int num3 = 0;
			for (int j = num - 1; j <= num + 1; j++)
			{
				Lighting.LightingState[] array = Lighting.states[j];
				for (int k = num2 - 1; k <= num2 + 1; k++)
				{
					Lighting.LightingState lightingState = array[k];
					int num4 = (int)(255f * lightingState.r * Lighting.brightness);
					int num5 = (int)(255f * lightingState.g * Lighting.brightness);
					int num6 = (int)(255f * lightingState.b * Lighting.brightness);
					if (num4 > 255)
					{
						num4 = 255;
					}
					if (num5 > 255)
					{
						num5 = 255;
					}
					if (num6 > 255)
					{
						num6 = 255;
					}
					slices[num3] = new Color((int)((byte)num4), (int)((byte)num5), (int)((byte)num6), 255);
					num3 += 3;
				}
				num3 -= 8;
			}
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00292260 File Offset: 0x00290460
		public static Vector3 GetSubLight(Vector2 position)
		{
			Vector2 vector = position / 16f - new Vector2(0.5f, 0.5f);
			Vector2 vector2 = new Vector2(vector.X % 1f, vector.Y % 1f);
			int num = (int)vector.X - Lighting.firstTileX + Lighting.offScreenTiles;
			int num2 = (int)vector.Y - Lighting.firstTileY + Lighting.offScreenTiles;
			if (num <= 0 || num2 <= 0 || num >= Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 - 1 || num2 >= Main.screenHeight / 16 + Lighting.offScreenTiles * 2 - 1)
			{
				return Vector3.One;
			}
			Vector3 arg_F0_0 = Lighting.states[num][num2].ToVector3();
			Vector3 value = Lighting.states[num + 1][num2].ToVector3();
			Vector3 value2 = Lighting.states[num][num2 + 1].ToVector3();
			Vector3 value3 = Lighting.states[num + 1][num2 + 1].ToVector3();
			Vector3 arg_10E_0 = Vector3.Lerp(arg_F0_0, value, vector2.X);
			Vector3 value4 = Vector3.Lerp(value2, value3, vector2.X);
			return Vector3.Lerp(arg_10E_0, value4, vector2.Y);
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x0028C4D8 File Offset: 0x0028A6D8
		public static void Initialize(bool resize = false)
		{
			if (!resize)
			{
				Lighting.tempLights = new Dictionary<Point16, Lighting.ColorTriplet>();
				Lighting.swipe = new Lighting.LightingSwipeData();
				Lighting.countdown = new CountdownEvent(0);
				Lighting.threadSwipes = new Lighting.LightingSwipeData[Environment.ProcessorCount];
				for (int i = 0; i < Lighting.threadSwipes.Length; i++)
				{
					Lighting.threadSwipes[i] = new Lighting.LightingSwipeData();
				}
			}
			int num = Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10;
			int num2 = Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10;
			if (Lighting.states == null || Lighting.states.Length < num || Lighting.states[0].Length < num2)
			{
				Lighting.states = new Lighting.LightingState[num][];
				Lighting.axisFlipStates = new Lighting.LightingState[num2][];
				for (int j = 0; j < num2; j++)
				{
					Lighting.axisFlipStates[j] = new Lighting.LightingState[num];
				}
				for (int k = 0; k < num; k++)
				{
					Lighting.LightingState[] array = new Lighting.LightingState[num2];
					for (int l = 0; l < num2; l++)
					{
						Lighting.LightingState lightingState = new Lighting.LightingState();
						array[l] = lightingState;
						Lighting.axisFlipStates[l][k] = lightingState;
					}
					Lighting.states[k] = array;
				}
			}
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x0028C5F8 File Offset: 0x0028A7F8
		public static void LightTiles(int firstX, int lastX, int firstY, int lastY)
		{
			Main.render = true;
			Lighting.oldSkyColor = Lighting.skyColor;
			float num = (float)Main.tileColor.R / 255f;
			float num2 = (float)Main.tileColor.G / 255f;
			float num3 = (float)Main.tileColor.B / 255f;
			Lighting.skyColor = (num + num2 + num3) / 3f;
			if (Lighting.lightMode < 2)
			{
				Lighting.brightness = 1.2f;
				Lighting.offScreenTiles2 = 34;
				Lighting.offScreenTiles = 40;
			}
			else
			{
				Lighting.brightness = 1f;
				Lighting.offScreenTiles2 = 18;
				Lighting.offScreenTiles = 23;
			}
			Lighting.brightness = 1.2f;
			if (Main.player[Main.myPlayer].blind)
			{
				Lighting.brightness = 1f;
			}
			Lighting.defBrightness = Lighting.brightness;
			Lighting.firstTileX = firstX;
			Lighting.lastTileX = lastX;
			Lighting.firstTileY = firstY;
			Lighting.lastTileY = lastY;
			Lighting.firstToLightX = Lighting.firstTileX - Lighting.offScreenTiles;
			Lighting.firstToLightY = Lighting.firstTileY - Lighting.offScreenTiles;
			Lighting.lastToLightX = Lighting.lastTileX + Lighting.offScreenTiles;
			Lighting.lastToLightY = Lighting.lastTileY + Lighting.offScreenTiles;
			Lighting.lightCounter++;
			Main.renderCount++;
			int num4 = Main.screenWidth / 16 + Lighting.offScreenTiles * 2;
			int num5 = Main.screenHeight / 16 + Lighting.offScreenTiles * 2;
			Vector2 vector = Main.screenLastPosition;
			if (Main.renderCount < 3)
			{
				Lighting.doColors();
			}
			if (Main.renderCount == 2)
			{
				vector = Main.screenPosition;
				int num6 = (int)Math.Floor((double)(Main.screenPosition.X / 16f)) - Lighting.scrX;
				int num7 = (int)Math.Floor((double)(Main.screenPosition.Y / 16f)) - Lighting.scrY;
				if (num6 > 16)
				{
					num6 = 0;
				}
				if (num7 > 16)
				{
					num7 = 0;
				}
				int num8 = 0;
				int num9 = num4;
				int num10 = 0;
				int num11 = num5;
				if (num6 < 0)
				{
					num8 -= num6;
				}
				else
				{
					num9 -= num6;
				}
				if (num7 < 0)
				{
					num10 -= num7;
				}
				else
				{
					num11 -= num7;
				}
				if (Lighting.RGB)
				{
					int num12 = num4;
					if (Lighting.states.Length <= num12 + num6)
					{
						num12 = Lighting.states.Length - num6 - 1;
					}
					for (int i = num8; i < num12; i++)
					{
						Lighting.LightingState[] array = Lighting.states[i];
						Lighting.LightingState[] array2 = Lighting.states[i + num6];
						int num13 = num11;
						if (array2.Length <= num13 + num6)
						{
							num13 = array2.Length - num7 - 1;
						}
						for (int j = num10; j < num13; j++)
						{
							Lighting.LightingState arg_276_0 = array[j];
							Lighting.LightingState lightingState = array2[j + num7];
							arg_276_0.r = lightingState.r2;
							arg_276_0.g = lightingState.g2;
							arg_276_0.b = lightingState.b2;
						}
					}
				}
				else
				{
					int num14 = num9;
					if (Lighting.states.Length <= num14 + num6)
					{
						num14 = Lighting.states.Length - num6 - 1;
					}
					for (int k = num8; k < num14; k++)
					{
						Lighting.LightingState[] array3 = Lighting.states[k];
						Lighting.LightingState[] array4 = Lighting.states[k + num6];
						int num15 = num11;
						if (array4.Length <= num15 + num6)
						{
							num15 = array4.Length - num7 - 1;
						}
						for (int l = num10; l < num15; l++)
						{
							Lighting.LightingState arg_328_0 = array3[l];
							Lighting.LightingState lightingState2 = array4[l + num7];
							arg_328_0.r = lightingState2.r2;
							arg_328_0.g = lightingState2.r2;
							arg_328_0.b = lightingState2.r2;
						}
					}
				}
			}
			else if (!Main.renderNow)
			{
				int num16 = (int)Math.Floor((double)(Main.screenPosition.X / 16f)) - (int)Math.Floor((double)(vector.X / 16f));
				if (num16 > 5 || num16 < -5)
				{
					num16 = 0;
				}
				int num17;
				int num18;
				int num19;
				if (num16 < 0)
				{
					num17 = -1;
					num16 *= -1;
					num18 = num4;
					num19 = num16;
				}
				else
				{
					num17 = 1;
					num18 = 0;
					num19 = num4 - num16;
				}
				int num20 = (int)Math.Floor((double)(Main.screenPosition.Y / 16f)) - (int)Math.Floor((double)(vector.Y / 16f));
				if (num20 > 5 || num20 < -5)
				{
					num20 = 0;
				}
				int num21;
				int num22;
				int num23;
				if (num20 < 0)
				{
					num21 = -1;
					num20 *= -1;
					num22 = num5;
					num23 = num20;
				}
				else
				{
					num21 = 1;
					num22 = 0;
					num23 = num5 - num20;
				}
				if (num16 != 0 || num20 != 0)
				{
					for (int num24 = num18; num24 != num19; num24 += num17)
					{
						Lighting.LightingState[] array5 = Lighting.states[num24];
						Lighting.LightingState[] array6 = Lighting.states[num24 + num16 * num17];
						for (int num25 = num22; num25 != num23; num25 += num21)
						{
							Lighting.LightingState arg_478_0 = array5[num25];
							Lighting.LightingState lightingState3 = array6[num25 + num20 * num21];
							arg_478_0.r = lightingState3.r;
							arg_478_0.g = lightingState3.g;
							arg_478_0.b = lightingState3.b;
						}
					}
				}
				if (Netplay.Connection.StatusMax > 0)
				{
					Main.mapTime = 1;
				}
				if (Main.mapTime == 0 && Main.mapEnabled && Main.renderCount == 3)
				{
					try
					{
						Main.mapTime = Main.mapTimeMax;
						Main.updateMap = true;
						Main.mapMinX = Utils.Clamp<int>(Lighting.firstToLightX + Lighting.offScreenTiles, 0, Main.maxTilesX - 1);
						Main.mapMaxX = Utils.Clamp<int>(Lighting.lastToLightX - Lighting.offScreenTiles, 0, Main.maxTilesX - 1);
						Main.mapMinY = Utils.Clamp<int>(Lighting.firstToLightY + Lighting.offScreenTiles, 0, Main.maxTilesY - 1);
						Main.mapMaxY = Utils.Clamp<int>(Lighting.lastToLightY - Lighting.offScreenTiles, 0, Main.maxTilesY - 1);
						for (int m = Main.mapMinX; m < Main.mapMaxX; m++)
						{
							Lighting.LightingState[] array7 = Lighting.states[m - Lighting.firstTileX + Lighting.offScreenTiles];
							for (int n = Main.mapMinY; n < Main.mapMaxY; n++)
							{
								Lighting.LightingState lightingState4 = array7[n - Lighting.firstTileY + Lighting.offScreenTiles];
								Tile tile = Main.tile[m, n];
								float num26 = 0f;
								if (lightingState4.r > num26)
								{
									num26 = lightingState4.r;
								}
								if (lightingState4.g > num26)
								{
									num26 = lightingState4.g;
								}
								if (lightingState4.b > num26)
								{
									num26 = lightingState4.b;
								}
								if (Lighting.lightMode < 2)
								{
									num26 *= 1.5f;
								}
								byte b = (byte)Math.Min(255f, num26 * 255f);
								if ((double)n < Main.worldSurface && !tile.active() && tile.wall == 0 && tile.liquid == 0)
								{
									b = 22;
								}
								if (b > 18 || Main.Map[m, n].Light > 0)
								{
									if (b < 22)
									{
										b = 22;
									}
									Main.Map.UpdateLighting(m, n, b);
								}
							}
						}
					}
					catch
					{
					}
				}
				if (Lighting.oldSkyColor != Lighting.skyColor)
				{
					int num27 = Utils.Clamp<int>(Lighting.firstToLightX, 0, Main.maxTilesX - 1);
					int num28 = Utils.Clamp<int>(Lighting.lastToLightX, 0, Main.maxTilesX - 1);
					int num29 = Utils.Clamp<int>(Lighting.firstToLightY, 0, Main.maxTilesY - 1);
					int num30 = Utils.Clamp<int>(Lighting.lastToLightY, 0, (int)Main.worldSurface - 1);
					if ((double)num29 < Main.worldSurface)
					{
						for (int num31 = num27; num31 < num28; num31++)
						{
							Lighting.LightingState[] array8 = Lighting.states[num31 - Lighting.firstToLightX];
							for (int num32 = num29; num32 < num30; num32++)
							{
								Lighting.LightingState lightingState5 = array8[num32 - Lighting.firstToLightY];
								Tile tile2 = Main.tile[num31, num32];
								if (tile2 == null)
								{
									tile2 = new Tile();
									Main.tile[num31, num32] = tile2;
								}
								if ((!tile2.active() || !Main.tileNoSunLight[(int)tile2.type]) && lightingState5.r < Lighting.skyColor && tile2.liquid < 200 && (Main.wallLight[(int)tile2.wall] || tile2.wall == 73))
								{
									lightingState5.r = num;
									if (lightingState5.g < Lighting.skyColor)
									{
										lightingState5.g = num2;
									}
									if (lightingState5.b < Lighting.skyColor)
									{
										lightingState5.b = num3;
									}
								}
							}
						}
					}
				}
			}
			else
			{
				Lighting.lightCounter = 0;
			}
			if (Main.renderCount > Lighting.maxRenderCount)
			{
				Lighting.PreRenderPhase();
			}
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x00291E30 File Offset: 0x00290030
		public static void NextLightMode()
		{
			Lighting.lightCounter += 100;
			Lighting.lightMode++;
			if (Lighting.lightMode >= 4)
			{
				Lighting.lightMode = 0;
			}
			if (Lighting.lightMode == 2 || Lighting.lightMode == 0)
			{
				Main.renderCount = 0;
				Main.renderNow = true;
				Lighting.BlackOut();
			}
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x0028CE54 File Offset: 0x0028B054
		public static void PreRenderPhase()
		{
			float num = (float)Main.tileColor.R / 255f;
			float num2 = (float)Main.tileColor.G / 255f;
			float num3 = (float)Main.tileColor.B / 255f;
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			int num4 = 0;
			int num5 = Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10;
			int num6 = 0;
			int num7 = Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10;
			Lighting.minX = num5;
			Lighting.maxX = num4;
			Lighting.minY = num7;
			Lighting.maxY = num6;
			if (Lighting.lightMode == 0 || Lighting.lightMode == 3)
			{
				Lighting.RGB = true;
			}
			else
			{
				Lighting.RGB = false;
			}
			for (int i = num4; i < num5; i++)
			{
				Lighting.LightingState[] array = Lighting.states[i];
				for (int j = num6; j < num7; j++)
				{
					Lighting.LightingState expr_C6 = array[j];
					expr_C6.r2 = 0f;
					expr_C6.g2 = 0f;
					expr_C6.b2 = 0f;
					expr_C6.stopLight = false;
					expr_C6.wetLight = false;
					expr_C6.honeyLight = false;
				}
			}
			if (Main.wof >= 0 && Main.player[Main.myPlayer].gross)
			{
				try
				{
					int num8 = (int)Main.screenPosition.Y / 16 - 10;
					int num9 = (int)(Main.screenPosition.Y + (float)Main.screenHeight) / 16 + 10;
					int num10 = (int)Main.npc[Main.wof].position.X / 16;
					if (Main.npc[Main.wof].direction > 0)
					{
						num10 -= 3;
					}
					else
					{
						num10 += 2;
					}
					int num11 = num10 + 8;
					float num12 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
					float num13 = 0.3f;
					float num14 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
					num12 *= 0.2f;
					num13 *= 0.1f;
					num14 *= 0.3f;
					for (int k = num10; k <= num11; k++)
					{
						Lighting.LightingState[] array2 = Lighting.states[k - num10];
						for (int l = num8; l <= num9; l++)
						{
							Lighting.LightingState lightingState = array2[l - Lighting.firstToLightY];
							if (lightingState.r2 < num12)
							{
								lightingState.r2 = num12;
							}
							if (lightingState.g2 < num13)
							{
								lightingState.g2 = num13;
							}
							if (lightingState.b2 < num14)
							{
								lightingState.b2 = num14;
							}
						}
					}
				}
				catch
				{
				}
			}
			Main.sandTiles = 0;
			Main.evilTiles = 0;
			Main.bloodTiles = 0;
			Main.shroomTiles = 0;
			Main.snowTiles = 0;
			Main.holyTiles = 0;
			Main.meteorTiles = 0;
			Main.jungleTiles = 0;
			Main.dungeonTiles = 0;
			Main.campfire = false;
			Main.sunflower = false;
			Main.starInBottle = false;
			Main.heartLantern = false;
			Main.campfire = false;
			Main.clock = false;
			Main.musicBox = -1;
			Main.waterCandles = 0;
			for (int m = 0; m < Main.player[Main.myPlayer].NPCBannerBuff.Length; m++)
			{
				Main.player[Main.myPlayer].NPCBannerBuff[m] = false;
			}
			Main.player[Main.myPlayer].hasBanner = false;
			int[] screenTileCounts = Main.screenTileCounts;
			Array.Clear(screenTileCounts, 0, screenTileCounts.Length);
			num4 = Utils.Clamp<int>(Lighting.firstToLightX, 5, Main.maxTilesX - 1);
			num5 = Utils.Clamp<int>(Lighting.lastToLightX, 5, Main.maxTilesX - 1);
			num6 = Utils.Clamp<int>(Lighting.firstToLightY, 5, Main.maxTilesY - 1);
			num7 = Utils.Clamp<int>(Lighting.lastToLightY, 5, Main.maxTilesY - 1);
			int num15 = (num5 - num4 - Main.zoneX) / 2;
			int num16 = (num7 - num6 - Main.zoneY) / 2;
			Main.fountainColor = -1;
			Main.monolithType = -1;
			for (int n = num4; n < num5; n++)
			{
				Lighting.LightingState[] array3 = Lighting.states[n - Lighting.firstToLightX];
				for (int num17 = num6; num17 < num7; num17++)
				{
					Lighting.LightingState lightingState2 = array3[num17 - Lighting.firstToLightY];
					Tile tile = Main.tile[n, num17];
					if (tile == null)
					{
						tile = new Tile();
						Main.tile[n, num17] = tile;
					}
					float num18 = 0f;
					float num19 = 0f;
					float num20 = 0f;
					if ((double)num17 < Main.worldSurface)
					{
						if ((!tile.active() || !Main.tileNoSunLight[(int)tile.type] || ((tile.slope() != 0 || tile.halfBrick()) && Main.tile[n, num17 - 1].liquid == 0 && Main.tile[n, num17 + 1].liquid == 0 && Main.tile[n - 1, num17].liquid == 0 && Main.tile[n + 1, num17].liquid == 0)) && lightingState2.r2 < Lighting.skyColor && (Main.wallLight[(int)tile.wall] || tile.wall == 73 || tile.wall == 227) && tile.liquid < 200 && (!tile.halfBrick() || Main.tile[n, num17 - 1].liquid < 200))
						{
							num18 = num;
							num19 = num2;
							num20 = num3;
						}
						if ((!tile.active() || tile.halfBrick() || !Main.tileNoSunLight[(int)tile.type]) && tile.wall >= 88 && tile.wall <= 93 && tile.liquid < 255)
						{
							num18 = num;
							num19 = num2;
							num20 = num3;
							switch (tile.wall)
							{
								case 88:
									num18 *= 0.9f;
									num19 *= 0.15f;
									num20 *= 0.9f;
									break;
								case 89:
									num18 *= 0.9f;
									num19 *= 0.9f;
									num20 *= 0.15f;
									break;
								case 90:
									num18 *= 0.15f;
									num19 *= 0.15f;
									num20 *= 0.9f;
									break;
								case 91:
									num18 *= 0.15f;
									num19 *= 0.9f;
									num20 *= 0.15f;
									break;
								case 92:
									num18 *= 0.9f;
									num19 *= 0.15f;
									num20 *= 0.15f;
									break;
								case 93:
									{
										float num21 = 0.2f;
										float num22 = 0.7f - num21;
										num18 *= num22 + (float)Main.DiscoR / 255f * num21;
										num19 *= num22 + (float)Main.DiscoG / 255f * num21;
										num20 *= num22 + (float)Main.DiscoB / 255f * num21;
										break;
									}
							}
						}
						if (!Lighting.RGB)
						{
							num19 = (num18 = (num20 = (num18 + num19 + num20) / 3f));
						}
						if (lightingState2.r2 < num18)
						{
							lightingState2.r2 = num18;
						}
						if (lightingState2.g2 < num19)
						{
							lightingState2.g2 = num19;
						}
						if (lightingState2.b2 < num20)
						{
							lightingState2.b2 = num20;
						}
					}
					float num23 = 0.55f + (float)Math.Sin((double)(Main.GlobalTime * 2f)) * 0.08f;
					if (num17 > Main.maxTilesY - 200)
					{
						if ((!tile.active() || !Main.tileNoSunLight[(int)tile.type] || ((tile.slope() != 0 || tile.halfBrick()) && Main.tile[n, num17 - 1].liquid == 0 && Main.tile[n, num17 + 1].liquid == 0 && Main.tile[n - 1, num17].liquid == 0 && Main.tile[n + 1, num17].liquid == 0)) && lightingState2.r2 < num23 && (Main.wallLight[(int)tile.wall] || tile.wall == 73 || tile.wall == 227) && tile.liquid < 200 && (!tile.halfBrick() || Main.tile[n, num17 - 1].liquid < 200))
						{
							num18 = num23;
							num19 = num23 * 0.6f;
							num20 = num23 * 0.2f;
						}
						if ((!tile.active() || tile.halfBrick() || !Main.tileNoSunLight[(int)tile.type]) && tile.wall >= 88 && tile.wall <= 93 && tile.liquid < 255)
						{
							num18 = num23;
							num19 = num23 * 0.6f;
							num20 = num23 * 0.2f;
							switch (tile.wall)
							{
								case 88:
									num18 *= 0.9f;
									num19 *= 0.15f;
									num20 *= 0.9f;
									break;
								case 89:
									num18 *= 0.9f;
									num19 *= 0.9f;
									num20 *= 0.15f;
									break;
								case 90:
									num18 *= 0.15f;
									num19 *= 0.15f;
									num20 *= 0.9f;
									break;
								case 91:
									num18 *= 0.15f;
									num19 *= 0.9f;
									num20 *= 0.15f;
									break;
								case 92:
									num18 *= 0.9f;
									num19 *= 0.15f;
									num20 *= 0.15f;
									break;
								case 93:
									{
										float num24 = 0.2f;
										float num25 = 0.7f - num24;
										num18 *= num25 + (float)Main.DiscoR / 255f * num24;
										num19 *= num25 + (float)Main.DiscoG / 255f * num24;
										num20 *= num25 + (float)Main.DiscoB / 255f * num24;
										break;
									}
							}
						}
						if (!Lighting.RGB)
						{
							num19 = (num18 = (num20 = (num18 + num19 + num20) / 3f));
						}
						if (lightingState2.r2 < num18)
						{
							lightingState2.r2 = num18;
						}
						if (lightingState2.g2 < num19)
						{
							lightingState2.g2 = num19;
						}
						if (lightingState2.b2 < num20)
						{
							lightingState2.b2 = num20;
						}
					}
					byte wall = tile.wall;
					if (wall <= 137)
					{
						if (wall != 33)
						{
							if (wall != 44)
							{
								if (wall == 137)
								{
									if (!tile.active() || !Main.tileBlockLight[(int)tile.type])
									{
										float num26 = 0.4f;
										num26 += (float)(270 - (int)Main.mouseTextColor) / 1500f;
										num26 += (float)Main.rand.Next(0, 50) * 0.0005f;
										num18 = 1f * num26;
										num19 = 0.5f * num26;
										num20 = 0.1f * num26;
									}
								}
							}
							else if (!tile.active() || !Main.tileBlockLight[(int)tile.type])
							{
								num18 = (float)Main.DiscoR / 255f * 0.15f;
								num19 = (float)Main.DiscoG / 255f * 0.15f;
								num20 = (float)Main.DiscoB / 255f * 0.15f;
							}
						}
						else if (!tile.active() || !Main.tileBlockLight[(int)tile.type])
						{
							num18 = 0.0899999961f;
							num19 = 0.0525000021f;
							num20 = 0.24f;
						}
					}
					else if (wall <= 166)
					{
						switch (wall)
						{
							case 153:
								num18 = 0.6f;
								num19 = 0.3f;
								break;
							case 154:
								num18 = 0.6f;
								num20 = 0.6f;
								break;
							case 155:
								num18 = 0.6f;
								num19 = 0.6f;
								num20 = 0.6f;
								break;
							case 156:
								num19 = 0.6f;
								break;
							default:
								switch (wall)
								{
									case 164:
										num18 = 0.6f;
										break;
									case 165:
										num20 = 0.6f;
										break;
									case 166:
										num18 = 0.6f;
										num19 = 0.6f;
										break;
								}
								break;
						}
					}
					else
					{
						switch (wall)
						{
							case 174:
								if (!tile.active() || !Main.tileBlockLight[(int)tile.type])
								{
									num18 = 0.2975f;
								}
								break;
							case 175:
								if (!tile.active() || !Main.tileBlockLight[(int)tile.type])
								{
									num18 = 0.075f;
									num19 = 0.15f;
									num20 = 0.4f;
								}
								break;
							case 176:
								if (!tile.active() || !Main.tileBlockLight[(int)tile.type])
								{
									num18 = 0.1f;
									num19 = 0.1f;
									num20 = 0.1f;
								}
								break;
							default:
								if (wall == 182 && (!tile.active() || !Main.tileBlockLight[(int)tile.type]))
								{
									num18 = 0.24f;
									num19 = 0.12f;
									num20 = 0.0899999961f;
								}
								break;
						}
					}
					if (tile.active())
					{
						if (n > num4 + num15 && n < num5 - num15 && num17 > num6 + num16 && num17 < num7 - num16)
						{
							screenTileCounts[(int)tile.type]++;
							if (tile.type == 215 && tile.frameY < 36)
							{
								Main.campfire = true;
							}
							if (tile.type == 405)
							{
								Main.campfire = true;
							}
							if (tile.type == 42 && tile.frameY >= 324 && tile.frameY <= 358)
							{
								Main.heartLantern = true;
							}
							if (tile.type == 42 && tile.frameY >= 252 && tile.frameY <= 286)
							{
								Main.starInBottle = true;
							}
							if (tile.type == 91 && (tile.frameX >= 396 || tile.frameY >= 54))
							{
								int num27 = (int)(tile.frameX / 18 - 21);
								for (int num28 = (int)tile.frameY; num28 >= 54; num28 -= 54)
								{
									num27 += 90;
									num27 += 21;
								}
								int num29 = Item.BannerToItem(num27);
								if (ItemID.Sets.BannerStrength[num29].Enabled)
								{
									Main.player[Main.myPlayer].NPCBannerBuff[num27] = true;
									Main.player[Main.myPlayer].hasBanner = true;
								}
							}
						}
						ushort type = tile.type;
						if (type != 139)
						{
							if (type != 207)
							{
								if (type == 410)
								{
									if (tile.frameY >= 56)
									{
										Main.monolithType = (int)(tile.frameX / 36);
									}
								}
							}
							else if (tile.frameY >= 72)
							{
								switch (tile.frameX / 36)
								{
									case 0:
										Main.fountainColor = 0;
										break;
									case 1:
										Main.fountainColor = 6;
										break;
									case 2:
										Main.fountainColor = 3;
										break;
									case 3:
										Main.fountainColor = 5;
										break;
									case 4:
										Main.fountainColor = 2;
										break;
									case 5:
										Main.fountainColor = 10;
										break;
									case 6:
										Main.fountainColor = 4;
										break;
									case 7:
										Main.fountainColor = 9;
										break;
									default:
										Main.fountainColor = -1;
										break;
								}
							}
						}
						else if (tile.frameX >= 36)
						{
							Main.musicBox = (int)(tile.frameY / 36);
						}
						if (Main.tileBlockLight[(int)tile.type] && (Lighting.lightMode >= 2 || (tile.type != 131 && !tile.inActive() && tile.slope() == 0)))
						{
							lightingState2.stopLight = true;
						}
						if (tile.type == 104)
						{
							Main.clock = true;
						}
						if (Main.tileLighted[(int)tile.type])
						{
							type = tile.type;
							if (type <= 184)
							{
								if (type <= 77)
								{
									if (type <= 37)
									{
										if (type <= 17)
										{
											if (type != 4)
											{
												if (type != 17)
												{
													goto IL_33D6;
												}
												goto IL_29E7;
											}
											else
											{
												if (tile.frameX >= 66)
												{
													goto IL_33D6;
												}
												switch (tile.frameY / 22)
												{
													case 0:
														num18 = 1f;
														num19 = 0.95f;
														num20 = 0.8f;
														goto IL_33D6;
													case 1:
														num18 = 0f;
														num19 = 0.1f;
														num20 = 1.3f;
														goto IL_33D6;
													case 2:
														num18 = 1f;
														num19 = 0.1f;
														num20 = 0.1f;
														goto IL_33D6;
													case 3:
														num18 = 0f;
														num19 = 1f;
														num20 = 0.1f;
														goto IL_33D6;
													case 4:
														num18 = 0.9f;
														num19 = 0f;
														num20 = 0.9f;
														goto IL_33D6;
													case 5:
														num18 = 1.3f;
														num19 = 1.3f;
														num20 = 1.3f;
														goto IL_33D6;
													case 6:
														num18 = 0.9f;
														num19 = 0.9f;
														num20 = 0f;
														goto IL_33D6;
													case 7:
														num18 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
														num19 = 0.3f;
														num20 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
														goto IL_33D6;
													case 8:
														num18 = 0.85f;
														num19 = 1f;
														num20 = 0.7f;
														goto IL_33D6;
													case 9:
														num18 = 0.7f;
														num19 = 0.85f;
														num20 = 1f;
														goto IL_33D6;
													case 10:
														num18 = 1f;
														num19 = 0.5f;
														num20 = 0f;
														goto IL_33D6;
													case 11:
														num18 = 1.25f;
														num19 = 1.25f;
														num20 = 0.8f;
														goto IL_33D6;
													case 12:
														num18 = 0.75f;
														num19 = 1.28249991f;
														num20 = 1.2f;
														goto IL_33D6;
													case 13:
														num18 = 0.95f;
														num19 = 0.65f;
														num20 = 1.3f;
														goto IL_33D6;
													case 14:
														num18 = (float)Main.DiscoR / 255f;
														num19 = (float)Main.DiscoG / 255f;
														num20 = (float)Main.DiscoB / 255f;
														goto IL_33D6;
													case 15:
														num18 = 1f;
														num19 = 0f;
														num20 = 1f;
														goto IL_33D6;
													default:
														num18 = 1f;
														num19 = 0.95f;
														num20 = 0.8f;
														goto IL_33D6;
												}
											}
										}
										else if (type != 22)
										{
											switch (type)
											{
												case 26:
												case 31:
													{
														if ((tile.type == 31 && tile.frameX >= 36) || (tile.type == 26 && tile.frameX >= 54))
														{
															float num30 = (float)Main.rand.Next(-5, 6) * 0.0025f;
															num18 = 0.5f + num30 * 2f;
															num19 = 0.2f + num30;
															num20 = 0.1f;
															goto IL_33D6;
														}
														float num31 = (float)Main.rand.Next(-5, 6) * 0.0025f;
														num18 = 0.31f + num31;
														num19 = 0.1f;
														num20 = 0.44f + num31 * 2f;
														goto IL_33D6;
													}
												case 27:
													if (tile.frameY < 36)
													{
														num18 = 0.3f;
														num19 = 0.27f;
														goto IL_33D6;
													}
													goto IL_33D6;
												case 28:
												case 29:
												case 30:
												case 32:
												case 36:
													goto IL_33D6;
												case 33:
													if (tile.frameX == 0)
													{
														int num32 = (int)(tile.frameY / 22);
														if (num32 <= 14)
														{
															switch (num32)
															{
																case 0:
																	num18 = 1f;
																	num19 = 0.95f;
																	num20 = 0.65f;
																	goto IL_33D6;
																case 1:
																	num18 = 0.55f;
																	num19 = 0.85f;
																	num20 = 0.35f;
																	goto IL_33D6;
																case 2:
																	num18 = 0.65f;
																	num19 = 0.95f;
																	num20 = 0.5f;
																	goto IL_33D6;
																case 3:
																	num18 = 0.2f;
																	num19 = 0.75f;
																	num20 = 1f;
																	goto IL_33D6;
																default:
																	if (num32 == 14)
																	{
																		num18 = 1f;
																		num19 = 1f;
																		num20 = 0.6f;
																		goto IL_33D6;
																	}
																	break;
															}
														}
														else
														{
															switch (num32)
															{
																case 19:
																	num18 = 0.37f;
																	num19 = 0.8f;
																	num20 = 1f;
																	goto IL_33D6;
																case 20:
																	num18 = 0f;
																	num19 = 0.9f;
																	num20 = 1f;
																	goto IL_33D6;
																case 21:
																	num18 = 0.25f;
																	num19 = 0.7f;
																	num20 = 1f;
																	goto IL_33D6;
																case 22:
																case 23:
																case 24:
																	break;
																case 25:
																	num18 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
																	num19 = 0.3f;
																	num20 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
																	goto IL_33D6;
																default:
																	if (num32 == 28)
																	{
																		num18 = 0.9f;
																		num19 = 0.75f;
																		num20 = 1f;
																		goto IL_33D6;
																	}
																	if (num32 == 30)
																	{
																		Vector3 expr_23F4 = Main.hslToRgb(Main.demonTorch * 0.12f + 0.69f, 1f, 0.75f).ToVector3() * 1.2f;
																		num18 = expr_23F4.X;
																		num19 = expr_23F4.Y;
																		num20 = expr_23F4.Z;
																		goto IL_33D6;
																	}
																	break;
															}
														}
														num18 = 1f;
														num19 = 0.95f;
														num20 = 0.65f;
														goto IL_33D6;
													}
													goto IL_33D6;
												case 34:
													if (tile.frameX % 108 < 54)
													{
														int num33 = (int)(tile.frameY / 54);
														switch (num33 + (int)(37 * (tile.frameX / 108)))
														{
															case 7:
																num18 = 0.95f;
																num19 = 0.95f;
																num20 = 0.5f;
																goto IL_33D6;
															case 8:
																num18 = 0.85f;
																num19 = 0.6f;
																num20 = 1f;
																goto IL_33D6;
															case 9:
																num18 = 1f;
																num19 = 0.6f;
																num20 = 0.6f;
																goto IL_33D6;
															case 11:
															case 17:
																num18 = 0.75f;
																num19 = 0.9f;
																num20 = 1f;
																goto IL_33D6;
															case 15:
																num18 = 1f;
																num19 = 1f;
																num20 = 0.7f;
																goto IL_33D6;
															case 18:
																num18 = 1f;
																num19 = 1f;
																num20 = 0.6f;
																goto IL_33D6;
															case 24:
																num18 = 0.37f;
																num19 = 0.8f;
																num20 = 1f;
																goto IL_33D6;
															case 25:
																num18 = 0f;
																num19 = 0.9f;
																num20 = 1f;
																goto IL_33D6;
															case 26:
																num18 = 0.25f;
																num19 = 0.7f;
																num20 = 1f;
																goto IL_33D6;
															case 27:
																num18 = 0.55f;
																num19 = 0.85f;
																num20 = 0.35f;
																goto IL_33D6;
															case 28:
																num18 = 0.65f;
																num19 = 0.95f;
																num20 = 0.5f;
																goto IL_33D6;
															case 29:
																num18 = 0.2f;
																num19 = 0.75f;
																num20 = 1f;
																goto IL_33D6;
															case 32:
																num18 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
																num19 = 0.3f;
																num20 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
																goto IL_33D6;
															case 35:
																num18 = 0.9f;
																num19 = 0.75f;
																num20 = 1f;
																goto IL_33D6;
															case 37:
																{
																	Vector3 expr_2961 = Main.hslToRgb(Main.demonTorch * 0.12f + 0.69f, 1f, 0.75f).ToVector3() * 1.2f;
																	num18 = expr_2961.X;
																	num19 = expr_2961.Y;
																	num20 = expr_2961.Z;
																	goto IL_33D6;
																}
														}
														num18 = 1f;
														num19 = 0.95f;
														num20 = 0.8f;
														goto IL_33D6;
													}
													goto IL_33D6;
												case 35:
													if (tile.frameX < 36)
													{
														num18 = 0.75f;
														num19 = 0.6f;
														num20 = 0.3f;
														goto IL_33D6;
													}
													goto IL_33D6;
												case 37:
													num18 = 0.56f;
													num19 = 0.43f;
													num20 = 0.15f;
													goto IL_33D6;
												default:
													goto IL_33D6;
											}
										}
									}
									else if (type <= 49)
									{
										if (type != 42)
										{
											if (type != 49)
											{
												goto IL_33D6;
											}
											num18 = 0f;
											num19 = 0.35f;
											num20 = 0.8f;
											goto IL_33D6;
										}
										else
										{
											if (tile.frameX != 0)
											{
												goto IL_33D6;
											}
											int num34 = (int)(tile.frameY / 36);
											switch (num34)
											{
												case 0:
													num18 = 0.7f;
													num19 = 0.65f;
													num20 = 0.55f;
													goto IL_33D6;
												case 1:
													num18 = 0.9f;
													num19 = 0.75f;
													num20 = 0.6f;
													goto IL_33D6;
												case 2:
													num18 = 0.8f;
													num19 = 0.6f;
													num20 = 0.6f;
													goto IL_33D6;
												case 3:
													num18 = 0.65f;
													num19 = 0.5f;
													num20 = 0.2f;
													goto IL_33D6;
												case 4:
													num18 = 0.5f;
													num19 = 0.7f;
													num20 = 0.4f;
													goto IL_33D6;
												case 5:
													num18 = 0.9f;
													num19 = 0.4f;
													num20 = 0.2f;
													goto IL_33D6;
												case 6:
													num18 = 0.7f;
													num19 = 0.75f;
													num20 = 0.3f;
													goto IL_33D6;
												case 7:
													{
														float num35 = Main.demonTorch * 0.2f;
														num18 = 0.9f - num35;
														num19 = 0.9f - num35;
														num20 = 0.7f + num35;
														goto IL_33D6;
													}
												case 8:
													num18 = 0.75f;
													num19 = 0.6f;
													num20 = 0.3f;
													goto IL_33D6;
												case 9:
													num18 = 1f;
													num19 = 0.3f;
													num20 = 0.5f;
													num20 += Main.demonTorch * 0.2f;
													num18 -= Main.demonTorch * 0.1f;
													num19 -= Main.demonTorch * 0.2f;
													goto IL_33D6;
												default:
													switch (num34)
													{
														case 28:
															num18 = 0.37f;
															num19 = 0.8f;
															num20 = 1f;
															goto IL_33D6;
														case 29:
															num18 = 0f;
															num19 = 0.9f;
															num20 = 1f;
															goto IL_33D6;
														case 30:
															num18 = 0.25f;
															num19 = 0.7f;
															num20 = 1f;
															goto IL_33D6;
														case 32:
															num18 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
															num19 = 0.3f;
															num20 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
															goto IL_33D6;
														case 35:
															num18 = 0.7f;
															num19 = 0.6f;
															num20 = 0.9f;
															goto IL_33D6;
														case 37:
															{
																Vector3 expr_2E70 = Main.hslToRgb(Main.demonTorch * 0.12f + 0.69f, 1f, 0.75f).ToVector3() * 1.2f;
																num18 = expr_2E70.X;
																num19 = expr_2E70.Y;
																num20 = expr_2E70.Z;
																goto IL_33D6;
															}
													}
													num18 = 1f;
													num19 = 1f;
													num20 = 1f;
													goto IL_33D6;
											}
										}
									}
									else if (type != 61)
									{
										if (type - 70 <= 2)
										{
											goto IL_2EC0;
										}
										if (type != 77)
										{
											goto IL_33D6;
										}
										num18 = 0.75f;
										num19 = 0.45f;
										num20 = 0.25f;
										goto IL_33D6;
									}
									else
									{
										if (tile.frameX == 144)
										{
											float num36 = 1f + (float)(270 - (int)Main.mouseTextColor) / 400f;
											float num37 = 0.8f - (float)(270 - (int)Main.mouseTextColor) / 400f;
											num18 = 0.42f * num37;
											num19 = 0.81f * num36;
											num20 = 0.52f * num37;
											goto IL_33D6;
										}
										goto IL_33D6;
									}
								}
								else
								{
									if (type <= 133)
									{
										if (type <= 84)
										{
											if (type != 83)
											{
												if (type != 84)
												{
													goto IL_33D6;
												}
												int num38 = (int)(tile.frameX / 18);
												if (num38 == 2)
												{
													float num39 = (float)(270 - (int)Main.mouseTextColor) / 800f;
													if (num39 > 1f)
													{
														num39 = 1f;
													}
													else if (num39 < 0f)
													{
														num39 = 0f;
													}
													num18 = num39 * 0.7f;
													num19 = num39;
													num20 = num39 * 0.1f;
													goto IL_33D6;
												}
												if (num38 == 5)
												{
													float num39 = 0.9f;
													num18 = num39;
													num19 = num39 * 0.8f;
													num20 = num39 * 0.2f;
													goto IL_33D6;
												}
												if (num38 == 6)
												{
													float num39 = 0.08f;
													num19 = num39 * 0.8f;
													num20 = num39;
													goto IL_33D6;
												}
												goto IL_33D6;
											}
											else
											{
												if (tile.frameX == 18 && !Main.dayTime)
												{
													num18 = 0.1f;
													num19 = 0.4f;
													num20 = 0.6f;
												}
												if (tile.frameX == 90 && !Main.raining && Main.time > 40500.0)
												{
													num18 = 0.9f;
													num19 = 0.72f;
													num20 = 0.18f;
													goto IL_33D6;
												}
												goto IL_33D6;
											}
										}
										else
										{
											switch (type)
											{
												case 92:
													if (tile.frameY <= 18 && tile.frameX == 0)
													{
														num18 = 1f;
														num19 = 1f;
														num20 = 1f;
														goto IL_33D6;
													}
													goto IL_33D6;
												case 93:
													if (tile.frameX == 0)
													{
														switch (tile.frameY / 54)
														{
															case 1:
																num18 = 0.95f;
																num19 = 0.95f;
																num20 = 0.5f;
																goto IL_33D6;
															case 2:
																num18 = 0.85f;
																num19 = 0.6f;
																num20 = 1f;
																goto IL_33D6;
															case 3:
																num18 = 0.75f;
																num19 = 1f;
																num20 = 0.6f;
																goto IL_33D6;
															case 4:
															case 5:
																num18 = 0.75f;
																num19 = 0.9f;
																num20 = 1f;
																goto IL_33D6;
															case 9:
																num18 = 1f;
																num19 = 1f;
																num20 = 0.7f;
																goto IL_33D6;
															case 13:
																num18 = 1f;
																num19 = 1f;
																num20 = 0.6f;
																goto IL_33D6;
															case 19:
																num18 = 0.37f;
																num19 = 0.8f;
																num20 = 1f;
																goto IL_33D6;
															case 20:
																num18 = 0f;
																num19 = 0.9f;
																num20 = 1f;
																goto IL_33D6;
															case 21:
																num18 = 0.25f;
																num19 = 0.7f;
																num20 = 1f;
																goto IL_33D6;
															case 23:
																num18 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
																num19 = 0.3f;
																num20 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
																goto IL_33D6;
															case 24:
																num18 = 0.35f;
																num19 = 0.5f;
																num20 = 0.3f;
																goto IL_33D6;
															case 25:
																num18 = 0.34f;
																num19 = 0.4f;
																num20 = 0.31f;
																goto IL_33D6;
															case 26:
																num18 = 0.25f;
																num19 = 0.32f;
																num20 = 0.5f;
																goto IL_33D6;
															case 29:
																num18 = 0.9f;
																num19 = 0.75f;
																num20 = 1f;
																goto IL_33D6;
															case 31:
																{
																	Vector3 expr_1EFE = Main.hslToRgb(Main.demonTorch * 0.12f + 0.69f, 1f, 0.75f).ToVector3() * 1.2f;
																	num18 = expr_1EFE.X;
																	num19 = expr_1EFE.Y;
																	num20 = expr_1EFE.Z;
																	goto IL_33D6;
																}
														}
														num18 = 1f;
														num19 = 0.97f;
														num20 = 0.85f;
														goto IL_33D6;
													}
													goto IL_33D6;
												case 94:
												case 97:
												case 99:
													goto IL_33D6;
												case 95:
													if (tile.frameX < 36)
													{
														num18 = 1f;
														num19 = 0.95f;
														num20 = 0.8f;
														goto IL_33D6;
													}
													goto IL_33D6;
												case 96:
													if (tile.frameX >= 36)
													{
														num18 = 0.5f;
														num19 = 0.35f;
														num20 = 0.1f;
														goto IL_33D6;
													}
													goto IL_33D6;
												case 98:
													if (tile.frameY == 0)
													{
														num18 = 1f;
														num19 = 0.97f;
														num20 = 0.85f;
														goto IL_33D6;
													}
													goto IL_33D6;
												case 100:
													break;
												default:
													switch (type)
													{
														case 125:
															{
																float num40 = (float)Main.rand.Next(28, 42) * 0.01f;
																num40 += (float)(270 - (int)Main.mouseTextColor) / 800f;
																num19 = (lightingState2.g2 = 0.3f * num40);
																num20 = (lightingState2.b2 = 0.6f * num40);
																goto IL_33D6;
															}
														case 126:
															if (tile.frameX < 36)
															{
																num18 = (float)Main.DiscoR / 255f;
																num19 = (float)Main.DiscoG / 255f;
																num20 = (float)Main.DiscoB / 255f;
																goto IL_33D6;
															}
															goto IL_33D6;
														case 127:
														case 128:
															goto IL_33D6;
														case 129:
															switch (tile.frameX / 18 % 3)
															{
																case 0:
																	num18 = 0f;
																	num19 = 0.05f;
																	num20 = 0.25f;
																	goto IL_33D6;
																case 1:
																	num18 = 0.2f;
																	num19 = 0f;
																	num20 = 0.15f;
																	goto IL_33D6;
																case 2:
																	num18 = 0.1f;
																	num19 = 0f;
																	num20 = 0.2f;
																	goto IL_33D6;
																default:
																	goto IL_33D6;
															}
															break;
														default:
															if (type != 133)
															{
																goto IL_33D6;
															}
															goto IL_29E7;
													}
													break;
											}
										}
									}
									else if (type <= 149)
									{
										if (type == 140)
										{
											goto IL_2A35;
										}
										if (type != 149)
										{
											goto IL_33D6;
										}
										if (tile.frameX <= 36)
										{
											switch (tile.frameX / 18)
											{
												case 0:
													num18 = 0.1f;
													num19 = 0.2f;
													num20 = 0.5f;
													break;
												case 1:
													num18 = 0.5f;
													num19 = 0.1f;
													num20 = 0.1f;
													break;
												case 2:
													num18 = 0.2f;
													num19 = 0.5f;
													num20 = 0.1f;
													break;
											}
											num18 *= (float)Main.rand.Next(970, 1031) * 0.001f;
											num19 *= (float)Main.rand.Next(970, 1031) * 0.001f;
											num20 *= (float)Main.rand.Next(970, 1031) * 0.001f;
											goto IL_33D6;
										}
										goto IL_33D6;
									}
									else
									{
										if (type == 160)
										{
											num18 = (float)Main.DiscoR / 255f * 0.25f;
											num19 = (float)Main.DiscoG / 255f * 0.25f;
											num20 = (float)Main.DiscoB / 255f * 0.25f;
											goto IL_33D6;
										}
										switch (type)
										{
											case 171:
												{
													int num41 = n;
													int num42 = num17;
													if (tile.frameX < 10)
													{
														num41 -= (int)tile.frameX;
														num42 -= (int)tile.frameY;
													}
													switch ((Main.tile[num41, num42].frameY & 15360) >> 10)
													{
														case 1:
															num18 = 0.1f;
															num19 = 0.1f;
															num20 = 0.1f;
															break;
														case 2:
															num18 = 0.2f;
															break;
														case 3:
															num19 = 0.2f;
															break;
														case 4:
															num20 = 0.2f;
															break;
														case 5:
															num18 = 0.125f;
															num19 = 0.125f;
															break;
														case 6:
															num18 = 0.2f;
															num19 = 0.1f;
															break;
														case 7:
															num18 = 0.125f;
															num19 = 0.125f;
															break;
														case 8:
															num18 = 0.08f;
															num19 = 0.175f;
															break;
														case 9:
															num19 = 0.125f;
															num20 = 0.125f;
															break;
														case 10:
															num18 = 0.125f;
															num20 = 0.125f;
															break;
														case 11:
															num18 = 0.1f;
															num19 = 0.1f;
															num20 = 0.2f;
															break;
														default:
															num19 = (num18 = (num20 = 0f));
															break;
													}
													num18 *= 0.5f;
													num19 *= 0.5f;
													num20 *= 0.5f;
													goto IL_33D6;
												}
											case 172:
												goto IL_33D6;
											case 173:
												break;
											case 174:
												if (tile.frameX == 0)
												{
													num18 = 1f;
													num19 = 0.95f;
													num20 = 0.65f;
													goto IL_33D6;
												}
												goto IL_33D6;
											default:
												if (type != 184)
												{
													goto IL_33D6;
												}
												if (tile.frameX == 110)
												{
													num18 = 0.25f;
													num19 = 0.1f;
													num20 = 0f;
													goto IL_33D6;
												}
												goto IL_33D6;
										}
									}
									if (tile.frameX < 36)
									{
										int num43 = (int)(tile.frameY / 36);
										switch (num43)
										{
											case 1:
												num18 = 0.95f;
												num19 = 0.95f;
												num20 = 0.5f;
												goto IL_33D6;
											case 2:
											case 4:
											case 5:
											case 7:
											case 8:
											case 10:
											case 12:
											case 14:
											case 15:
											case 16:
											case 17:
											case 18:
												break;
											case 3:
												num18 = 1f;
												num19 = 0.6f;
												num20 = 0.6f;
												goto IL_33D6;
											case 6:
											case 9:
												num18 = 0.75f;
												num19 = 0.9f;
												num20 = 1f;
												goto IL_33D6;
											case 11:
												num18 = 1f;
												num19 = 1f;
												num20 = 0.7f;
												goto IL_33D6;
											case 13:
												num18 = 1f;
												num19 = 1f;
												num20 = 0.6f;
												goto IL_33D6;
											case 19:
												num18 = 0.37f;
												num19 = 0.8f;
												num20 = 1f;
												goto IL_33D6;
											case 20:
												num18 = 0f;
												num19 = 0.9f;
												num20 = 1f;
												goto IL_33D6;
											case 21:
												num18 = 0.25f;
												num19 = 0.7f;
												num20 = 1f;
												goto IL_33D6;
											case 22:
												num18 = 0.35f;
												num19 = 0.5f;
												num20 = 0.3f;
												goto IL_33D6;
											case 23:
												num18 = 0.34f;
												num19 = 0.4f;
												num20 = 0.31f;
												goto IL_33D6;
											case 24:
												num18 = 0.25f;
												num19 = 0.32f;
												num20 = 0.5f;
												goto IL_33D6;
											case 25:
												num18 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
												num19 = 0.3f;
												num20 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
												goto IL_33D6;
											default:
												if (num43 == 29)
												{
													num18 = 0.9f;
													num19 = 0.75f;
													num20 = 1f;
													goto IL_33D6;
												}
												if (num43 == 31)
												{
													Vector3 expr_26A3 = Main.hslToRgb(Main.demonTorch * 0.12f + 0.69f, 1f, 0.75f).ToVector3() * 1.2f;
													num18 = expr_26A3.X;
													num19 = expr_26A3.Y;
													num20 = expr_26A3.Z;
													goto IL_33D6;
												}
												break;
										}
										num18 = 1f;
										num19 = 0.95f;
										num20 = 0.65f;
										goto IL_33D6;
									}
									goto IL_33D6;
								}
								IL_2A35:
								num18 = 0.12f;
								num19 = 0.07f;
								num20 = 0.32f;
								goto IL_33D6;
							}
							if (type <= 327)
							{
								if (type <= 238)
								{
									if (type <= 204)
									{
										if (type == 190)
										{
											goto IL_2EC0;
										}
										if (type != 204)
										{
											goto IL_33D6;
										}
									}
									else if (type != 209)
									{
										if (type != 215)
										{
											switch (type)
											{
												case 235:
													if ((double)lightingState2.r2 < 0.6)
													{
														lightingState2.r2 = 0.6f;
													}
													if ((double)lightingState2.g2 < 0.6)
													{
														lightingState2.g2 = 0.6f;
														goto IL_33D6;
													}
													goto IL_33D6;
												case 236:
													goto IL_33D6;
												case 237:
													num18 = 0.1f;
													num19 = 0.1f;
													goto IL_33D6;
												case 238:
													if ((double)lightingState2.r2 < 0.5)
													{
														lightingState2.r2 = 0.5f;
													}
													if ((double)lightingState2.b2 < 0.5)
													{
														lightingState2.b2 = 0.5f;
														goto IL_33D6;
													}
													goto IL_33D6;
												default:
													goto IL_33D6;
											}
										}
										else
										{
											if (tile.frameY < 36)
											{
												float num44 = (float)Main.rand.Next(28, 42) * 0.005f;
												num44 += (float)(270 - (int)Main.mouseTextColor) / 700f;
												switch (tile.frameX / 54)
												{
													case 1:
														num18 = 0.7f;
														num19 = 1f;
														num20 = 0.5f;
														break;
													case 2:
														num18 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
														num19 = 0.3f;
														num20 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
														break;
													case 3:
														num18 = 0.45f;
														num19 = 0.75f;
														num20 = 1f;
														break;
													case 4:
														num18 = 1.15f;
														num19 = 1.15f;
														num20 = 0.5f;
														break;
													case 5:
														num18 = (float)Main.DiscoR / 255f;
														num19 = (float)Main.DiscoG / 255f;
														num20 = (float)Main.DiscoB / 255f;
														break;
													case 6:
														num18 = 0.75f;
														num19 = 1.28249991f;
														num20 = 1.2f;
														break;
													case 7:
														num18 = 0.95f;
														num19 = 0.65f;
														num20 = 1.3f;
														break;
													default:
														num18 = 0.9f;
														num19 = 0.3f;
														num20 = 0.1f;
														break;
												}
												num18 += num44;
												num19 += num44;
												num20 += num44;
												goto IL_33D6;
											}
											goto IL_33D6;
										}
									}
									else
									{
										if (tile.frameX == 234 || tile.frameX == 252)
										{
											Vector3 expr_13CF = PortalHelper.GetPortalColor(Main.myPlayer, 0).ToVector3() * 0.65f;
											num18 = expr_13CF.X;
											num19 = expr_13CF.Y;
											num20 = expr_13CF.Z;
											goto IL_33D6;
										}
										if (tile.frameX == 306 || tile.frameX == 324)
										{
											Vector3 expr_1428 = PortalHelper.GetPortalColor(Main.myPlayer, 1).ToVector3() * 0.65f;
											num18 = expr_1428.X;
											num19 = expr_1428.Y;
											num20 = expr_1428.Z;
											goto IL_33D6;
										}
										goto IL_33D6;
									}
								}
								else if (type <= 286)
								{
									switch (type)
									{
										case 262:
											num18 = 0.75f;
											num20 = 0.75f;
											goto IL_33D6;
										case 263:
											num18 = 0.75f;
											num19 = 0.75f;
											goto IL_33D6;
										case 264:
											num20 = 0.75f;
											goto IL_33D6;
										case 265:
											num19 = 0.75f;
											goto IL_33D6;
										case 266:
											num18 = 0.75f;
											goto IL_33D6;
										case 267:
											num18 = 0.75f;
											num19 = 0.75f;
											num20 = 0.75f;
											goto IL_33D6;
										case 268:
											num18 = 0.75f;
											num19 = 0.375f;
											goto IL_33D6;
										case 269:
											goto IL_33D6;
										case 270:
											num18 = 0.73f;
											num19 = 1f;
											num20 = 0.41f;
											goto IL_33D6;
										case 271:
											num18 = 0.45f;
											num19 = 0.95f;
											num20 = 1f;
											goto IL_33D6;
										default:
											if (type != 286)
											{
												goto IL_33D6;
											}
											num18 = 0.1f;
											num19 = 0.2f;
											num20 = 0.7f;
											goto IL_33D6;
									}
								}
								else
								{
									if (type == 302)
									{
										goto IL_29E7;
									}
									if (type - 316 > 2)
									{
										if (type != 327)
										{
											goto IL_33D6;
										}
										float num45 = 0.5f;
										num45 += (float)(270 - (int)Main.mouseTextColor) / 1500f;
										num45 += (float)Main.rand.Next(0, 50) * 0.0005f;
										num18 = 1f * num45;
										num19 = 0.5f * num45;
										num20 = 0.1f * num45;
										goto IL_33D6;
									}
									else
									{
										int arg_16A0_0 = n - (int)(tile.frameX / 18);
										int num46 = num17 - (int)(tile.frameY / 18);
										int num47 = arg_16A0_0 / 2 * (num46 / 3);
										num47 %= Main.cageFrames;
										bool flag = Main.jellyfishCageMode[(int)(tile.type - 316), num47] == 2;
										if (tile.type == 316)
										{
											if (flag)
											{
												num18 = 0.2f;
												num19 = 0.3f;
												num20 = 0.8f;
											}
											else
											{
												num18 = 0.1f;
												num19 = 0.2f;
												num20 = 0.5f;
											}
										}
										if (tile.type == 317)
										{
											if (flag)
											{
												num18 = 0.2f;
												num19 = 0.7f;
												num20 = 0.3f;
											}
											else
											{
												num18 = 0.05f;
												num19 = 0.45f;
												num20 = 0.1f;
											}
										}
										if (tile.type != 318)
										{
											goto IL_33D6;
										}
										if (flag)
										{
											num18 = 0.7f;
											num19 = 0.2f;
											num20 = 0.5f;
											goto IL_33D6;
										}
										num18 = 0.4f;
										num19 = 0.1f;
										num20 = 0.25f;
										goto IL_33D6;
									}
								}
							}
							else if (type <= 390)
							{
								if (type <= 370)
								{
									switch (type)
									{
										case 336:
											num18 = 0.85f;
											num19 = 0.5f;
											num20 = 0.3f;
											goto IL_33D6;
										case 337:
										case 338:
										case 339:
										case 345:
										case 346:
											goto IL_33D6;
										case 340:
											num18 = 0.45f;
											num19 = 1f;
											num20 = 0.45f;
											goto IL_33D6;
										case 341:
											num18 = 0.4f * Main.demonTorch + 0.6f * (1f - Main.demonTorch);
											num19 = 0.35f;
											num20 = 1f * Main.demonTorch + 0.6f * (1f - Main.demonTorch);
											goto IL_33D6;
										case 342:
											num18 = 0.5f;
											num19 = 0.5f;
											num20 = 1.1f;
											goto IL_33D6;
										case 343:
											num18 = 0.85f;
											num19 = 0.85f;
											num20 = 0.3f;
											goto IL_33D6;
										case 344:
											num18 = 0.6f;
											num19 = 1.026f;
											num20 = 0.960000038f;
											goto IL_33D6;
										case 347:
											break;
										case 348:
										case 349:
											goto IL_2EC0;
										case 350:
											{
												double num48 = Main.time * 0.08;
												num19 = (num20 = (num18 = (float)(-(float)Math.Cos(((int)(num48 / 6.283) % 3 == 1) ? num48 : 0.0) * 0.1 + 0.1)));
												goto IL_33D6;
											}
										default:
											if (type != 370)
											{
												goto IL_33D6;
											}
											num18 = 0.32f;
											num19 = 0.16f;
											num20 = 0.12f;
											goto IL_33D6;
									}
								}
								else if (type != 372)
								{
									if (type == 381)
									{
										num18 = 0.25f;
										num19 = 0.1f;
										num20 = 0f;
										goto IL_33D6;
									}
									if (type != 390)
									{
										goto IL_33D6;
									}
									num18 = 0.4f;
									num19 = 0.2f;
									num20 = 0.1f;
									goto IL_33D6;
								}
								else
								{
									if (tile.frameX == 0)
									{
										num18 = 0.9f;
										num19 = 0.1f;
										num20 = 0.75f;
										goto IL_33D6;
									}
									goto IL_33D6;
								}
							}
							else if (type <= 405)
							{
								if (type == 391)
								{
									num18 = 0.3f;
									num19 = 0.1f;
									num20 = 0.25f;
									goto IL_33D6;
								}
								if (type != 405)
								{
									goto IL_33D6;
								}
								if (tile.frameX < 54)
								{
									float num49 = (float)Main.rand.Next(28, 42) * 0.005f;
									num49 += (float)(270 - (int)Main.mouseTextColor) / 700f;
									switch (tile.frameX / 54)
									{
										case 1:
											num18 = 0.7f;
											num19 = 1f;
											num20 = 0.5f;
											break;
										case 2:
											num18 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
											num19 = 0.3f;
											num20 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
											break;
										case 3:
											num18 = 0.45f;
											num19 = 0.75f;
											num20 = 1f;
											break;
										case 4:
											num18 = 1.15f;
											num19 = 1.15f;
											num20 = 0.5f;
											break;
										case 5:
											num18 = (float)Main.DiscoR / 255f;
											num19 = (float)Main.DiscoG / 255f;
											num20 = (float)Main.DiscoB / 255f;
											break;
										default:
											num18 = 0.9f;
											num19 = 0.3f;
											num20 = 0.1f;
											break;
									}
									num18 += num49;
									num19 += num49;
									num20 += num49;
									goto IL_33D6;
								}
								goto IL_33D6;
							}
							else
							{
								switch (type)
								{
									case 415:
										num18 = 0.7f;
										num19 = 0.5f;
										num20 = 0.1f;
										goto IL_33D6;
									case 416:
										num18 = 0f;
										num19 = 0.6f;
										num20 = 0.7f;
										goto IL_33D6;
									case 417:
										num18 = 0.6f;
										num19 = 0.2f;
										num20 = 0.6f;
										goto IL_33D6;
									case 418:
										num18 = 0.6f;
										num19 = 0.6f;
										num20 = 0.9f;
										goto IL_33D6;
									default:
										if (type != 429)
										{
											if (type == 463)
											{
												num18 = 0.2f;
												num19 = 0.4f;
												num20 = 0.8f;
												goto IL_33D6;
											}
											goto IL_33D6;
										}
										else
										{
											short expr_179F = (short)(tile.frameX / 18);
											bool flag2 = expr_179F % 2 >= 1;
											bool flag3 = expr_179F % 4 >= 2;
											bool flag4 = expr_179F % 8 >= 4;
											bool arg_17F3_0 = expr_179F % 16 >= 8;
											if (flag2)
											{
												num18 += 0.5f;
											}
											if (flag3)
											{
												num19 += 0.5f;
											}
											if (flag4)
											{
												num20 += 0.5f;
											}
											if (arg_17F3_0)
											{
												num18 += 0.2f;
												num19 += 0.2f;
												goto IL_33D6;
											}
											goto IL_33D6;
										}
										break;
								}
							}
							num18 = 0.35f;
							goto IL_33D6;
							IL_29E7:
							num18 = 0.83f;
							num19 = 0.6f;
							num20 = 0.5f;
							goto IL_33D6;
							IL_2EC0:
							if (tile.type != 349 || tile.frameX >= 36)
							{
								float num50 = (float)Main.rand.Next(28, 42) * 0.005f;
								num50 += (float)(270 - (int)Main.mouseTextColor) / 1000f;
								num18 = 0.1f;
								num19 = 0.2f + num50 / 2f;
								num20 = 0.7f + num50;
							}
						}
					}
					IL_33D6:
					if (Lighting.RGB)
					{
						if (lightingState2.r2 < num18)
						{
							lightingState2.r2 = num18;
						}
						if (lightingState2.g2 < num19)
						{
							lightingState2.g2 = num19;
						}
						if (lightingState2.b2 < num20)
						{
							lightingState2.b2 = num20;
						}
					}
					else
					{
						float num51 = (num18 + num19 + num20) / 3f;
						if (lightingState2.r2 < num51)
						{
							lightingState2.r2 = num51;
						}
					}
					if (tile.lava() && tile.liquid > 0)
					{
						if (Lighting.RGB)
						{
							float num52 = (float)(tile.liquid / 255) * 0.41f + 0.14f;
							num52 = 0.55f;
							num52 += (float)(270 - (int)Main.mouseTextColor) / 900f;
							if (lightingState2.r2 < num52)
							{
								lightingState2.r2 = num52;
							}
							if (lightingState2.g2 < num52)
							{
								lightingState2.g2 = num52 * 0.6f;
							}
							if (lightingState2.b2 < num52)
							{
								lightingState2.b2 = num52 * 0.2f;
							}
						}
						else
						{
							float num53 = (float)(tile.liquid / 255) * 0.38f + 0.08f;
							num53 += (float)(270 - (int)Main.mouseTextColor) / 2000f;
							if (lightingState2.r2 < num53)
							{
								lightingState2.r2 = num53;
							}
						}
					}
					else if (tile.liquid > 128)
					{
						lightingState2.wetLight = true;
						if (tile.honey())
						{
							lightingState2.honeyLight = true;
						}
					}
					if (lightingState2.r2 > 0f || (Lighting.RGB && (lightingState2.g2 > 0f || lightingState2.b2 > 0f)))
					{
						int num54 = n - Lighting.firstToLightX;
						int num55 = num17 - Lighting.firstToLightY;
						if (Lighting.minX > num54)
						{
							Lighting.minX = num54;
						}
						if (Lighting.maxX < num54 + 1)
						{
							Lighting.maxX = num54 + 1;
						}
						if (Lighting.minY > num55)
						{
							Lighting.minY = num55;
						}
						if (Lighting.maxY < num55 + 1)
						{
							Lighting.maxY = num55 + 1;
						}
					}
				}
			}
			foreach (KeyValuePair<Point16, Lighting.ColorTriplet> current in Lighting.tempLights)
			{
				int num56 = (int)current.Key.X - Lighting.firstTileX + Lighting.offScreenTiles;
				int num57 = (int)current.Key.Y - Lighting.firstTileY + Lighting.offScreenTiles;
				if (num56 >= 0 && num56 < Main.screenWidth / 16 + Lighting.offScreenTiles * 2 + 10 && num57 >= 0 && num57 < Main.screenHeight / 16 + Lighting.offScreenTiles * 2 + 10)
				{
					Lighting.LightingState lightingState3 = Lighting.states[num56][num57];
					if (lightingState3.r2 < current.Value.r)
					{
						lightingState3.r2 = current.Value.r;
					}
					if (lightingState3.g2 < current.Value.g)
					{
						lightingState3.g2 = current.Value.g;
					}
					if (lightingState3.b2 < current.Value.b)
					{
						lightingState3.b2 = current.Value.b;
					}
					if (Lighting.minX > num56)
					{
						Lighting.minX = num56;
					}
					if (Lighting.maxX < num56 + 1)
					{
						Lighting.maxX = num56 + 1;
					}
					if (Lighting.minY > num57)
					{
						Lighting.minY = num57;
					}
					if (Lighting.maxY < num57 + 1)
					{
						Lighting.maxY = num57 + 1;
					}
				}
			}
			if (!Main.gamePaused)
			{
				Lighting.tempLights.Clear();
			}
			if (screenTileCounts[27] > 0)
			{
				Main.sunflower = true;
			}
			Main.holyTiles = screenTileCounts[109] + screenTileCounts[110] + screenTileCounts[113] + screenTileCounts[117] + screenTileCounts[116] + screenTileCounts[164] + screenTileCounts[403] + screenTileCounts[402];
			Main.evilTiles = screenTileCounts[23] + screenTileCounts[24] + screenTileCounts[25] + screenTileCounts[32] + screenTileCounts[112] + screenTileCounts[163] + screenTileCounts[400] + screenTileCounts[398] + -5 * screenTileCounts[27];
			Main.bloodTiles = screenTileCounts[199] + screenTileCounts[203] + screenTileCounts[200] + screenTileCounts[401] + screenTileCounts[399] + screenTileCounts[234] + screenTileCounts[352] - 5 * screenTileCounts[27];
			Main.snowTiles = screenTileCounts[147] + screenTileCounts[148] + screenTileCounts[161] + screenTileCounts[162] + screenTileCounts[164] + screenTileCounts[163] + screenTileCounts[200];
			Main.jungleTiles = screenTileCounts[60] + screenTileCounts[61] + screenTileCounts[62] + screenTileCounts[74] + screenTileCounts[226];
			Main.shroomTiles = screenTileCounts[70] + screenTileCounts[71] + screenTileCounts[72];
			Main.meteorTiles = screenTileCounts[37];
			Main.dungeonTiles = screenTileCounts[41] + screenTileCounts[43] + screenTileCounts[44];
			Main.sandTiles = screenTileCounts[53] + screenTileCounts[112] + screenTileCounts[116] + screenTileCounts[234] + screenTileCounts[397] + screenTileCounts[398] + screenTileCounts[402] + screenTileCounts[399] + screenTileCounts[396] + screenTileCounts[400] + screenTileCounts[403] + screenTileCounts[401];
			Main.waterCandles = screenTileCounts[49];
			Main.peaceCandles = screenTileCounts[372];
			Main.partyMonoliths = screenTileCounts[455];
			if (Main.player[Main.myPlayer].accOreFinder)
			{
				Main.player[Main.myPlayer].bestOre = -1;
				for (int num58 = 0; num58 < 470; num58++)
				{
					if (screenTileCounts[num58] > 0 && Main.tileValue[num58] > 0 && (Main.player[Main.myPlayer].bestOre < 0 || Main.tileValue[num58] > Main.tileValue[Main.player[Main.myPlayer].bestOre]))
					{
						Main.player[Main.myPlayer].bestOre = num58;
					}
				}
			}
			if (Main.holyTiles < 0)
			{
				Main.holyTiles = 0;
			}
			if (Main.evilTiles < 0)
			{
				Main.evilTiles = 0;
			}
			if (Main.bloodTiles < 0)
			{
				Main.bloodTiles = 0;
			}
			int holyTiles = Main.holyTiles;
			Main.holyTiles -= Main.evilTiles;
			Main.holyTiles -= Main.bloodTiles;
			Main.evilTiles -= holyTiles;
			Main.bloodTiles -= holyTiles;
			if (Main.holyTiles < 0)
			{
				Main.holyTiles = 0;
			}
			if (Main.evilTiles < 0)
			{
				Main.evilTiles = 0;
			}
			if (Main.bloodTiles < 0)
			{
				Main.bloodTiles = 0;
			}
			Lighting.minX += Lighting.firstToLightX;
			Lighting.maxX += Lighting.firstToLightX;
			Lighting.minY += Lighting.firstToLightY;
			Lighting.maxY += Lighting.firstToLightY;
			Lighting.minX7 = Lighting.minX;
			Lighting.maxX7 = Lighting.maxX;
			Lighting.minY7 = Lighting.minY;
			Lighting.maxY7 = Lighting.maxY;
			Lighting.firstTileX7 = Lighting.firstTileX;
			Lighting.lastTileX7 = Lighting.lastTileX;
			Lighting.lastTileY7 = Lighting.lastTileY;
			Lighting.firstTileY7 = Lighting.firstTileY;
			Lighting.firstToLightX7 = Lighting.firstToLightX;
			Lighting.lastToLightX7 = Lighting.lastToLightX;
			Lighting.firstToLightY7 = Lighting.firstToLightY;
			Lighting.lastToLightY7 = Lighting.lastToLightY;
			Lighting.firstToLightX27 = Lighting.firstTileX - Lighting.offScreenTiles2;
			Lighting.firstToLightY27 = Lighting.firstTileY - Lighting.offScreenTiles2;
			Lighting.lastToLightX27 = Lighting.lastTileX + Lighting.offScreenTiles2;
			Lighting.lastToLightY27 = Lighting.lastTileY + Lighting.offScreenTiles2;
			Lighting.scrX = (int)Math.Floor((double)(Main.screenPosition.X / 16f));
			Lighting.scrY = (int)Math.Floor((double)(Main.screenPosition.Y / 16f));
			Main.renderCount = 0;
			TimeLogger.LightingTime(0, stopwatch.Elapsed.TotalMilliseconds);
			Lighting.doColors();
		}

		// Token: 0x17000089 RID: 137
		public static bool LightingDrawToScreen
		{
			// Token: 0x06000432 RID: 1074 RVA: 0x0028C4CE File Offset: 0x0028A6CE
			get
			{
				return Main.drawToScreen;
			}
		}

		// Token: 0x17000087 RID: 135
		public static bool NotRetro
		{
			// Token: 0x06000430 RID: 1072 RVA: 0x0028C4AA File Offset: 0x0028A6AA
			get
			{
				return Lighting.lightMode < 2;
			}
		}

		// Token: 0x17000088 RID: 136
		public static bool UpdateEveryFrame
		{
			// Token: 0x06000431 RID: 1073 RVA: 0x0028C4B4 File Offset: 0x0028A6B4
			get
			{
				return Main.LightingEveryFrame && !Main.RenderTargetsRequired && !Lighting.NotRetro;
			}
		}

		// Token: 0x0400068C RID: 1676
		private static Lighting.LightingState[][] axisFlipStates;

		// Token: 0x040006A5 RID: 1701
		private static int blueDir = 1;

		// Token: 0x040006A4 RID: 1700
		private static float blueWave = 1f;

		// Token: 0x0400067D RID: 1661
		public static float brightness = 1f;

		// Token: 0x0400068F RID: 1679
		private static CountdownEvent countdown;

		// Token: 0x0400067E RID: 1662
		public static float defBrightness = 1f;

		// Token: 0x04000686 RID: 1670
		private static int firstTileX;

		// Token: 0x040006AA RID: 1706
		private static int firstTileX7;

		// Token: 0x04000688 RID: 1672
		private static int firstTileY;

		// Token: 0x040006AD RID: 1709
		private static int firstTileY7;

		// Token: 0x04000698 RID: 1688
		private static int firstToLightX;

		// Token: 0x040006B2 RID: 1714
		private static int firstToLightX27;

		// Token: 0x040006AE RID: 1710
		private static int firstToLightX7;

		// Token: 0x04000699 RID: 1689
		private static int firstToLightY;

		// Token: 0x040006B4 RID: 1716
		private static int firstToLightY27;

		// Token: 0x040006B0 RID: 1712
		private static int firstToLightY7;

		// Token: 0x040006A3 RID: 1699
		private static float honeyLightB = 0.16f;

		// Token: 0x040006A2 RID: 1698
		private static float honeyLightG = 0.16f;

		// Token: 0x040006A1 RID: 1697
		private static float honeyLightR = 0.16f;

		// Token: 0x04000687 RID: 1671
		private static int lastTileX;

		// Token: 0x040006AB RID: 1707
		private static int lastTileX7;

		// Token: 0x04000689 RID: 1673
		private static int lastTileY;

		// Token: 0x040006AC RID: 1708
		private static int lastTileY7;

		// Token: 0x0400069A RID: 1690
		private static int lastToLightX;

		// Token: 0x040006B3 RID: 1715
		private static int lastToLightX27;

		// Token: 0x040006AF RID: 1711
		private static int lastToLightX7;

		// Token: 0x0400069B RID: 1691
		private static int lastToLightY;

		// Token: 0x040006B5 RID: 1717
		private static int lastToLightY27;

		// Token: 0x040006B1 RID: 1713
		private static int lastToLightY7;

		// Token: 0x04000683 RID: 1667
		private static int lightCounter = 0;

		// Token: 0x0400068A RID: 1674
		public static int LightingThreads = 0;

		// Token: 0x0400067F RID: 1663
		public static int lightMode = 0;

		// Token: 0x0400067C RID: 1660
		public static int maxRenderCount = 4;

		// Token: 0x04000696 RID: 1686
		private static int maxTempLights = 2000;

		// Token: 0x04000693 RID: 1683
		public static int maxX;

		// Token: 0x040006A7 RID: 1703
		private static int maxX7;

		// Token: 0x04000695 RID: 1685
		public static int maxY;

		// Token: 0x040006A9 RID: 1705
		private static int maxY7;

		// Token: 0x04000692 RID: 1682
		public static int minX;

		// Token: 0x040006A6 RID: 1702
		private static int minX7;

		// Token: 0x04000694 RID: 1684
		public static int minY;

		// Token: 0x040006A8 RID: 1704
		private static int minY7;

		// Token: 0x0400069C RID: 1692
		private static float negLight = 0.04f;

		// Token: 0x0400069D RID: 1693
		private static float negLight2 = 0.16f;

		// Token: 0x04000684 RID: 1668
		public static int offScreenTiles = 45;

		// Token: 0x04000685 RID: 1669
		public static int offScreenTiles2 = 35;

		// Token: 0x04000681 RID: 1665
		private static float oldSkyColor = 0f;

		// Token: 0x04000680 RID: 1664
		public static bool RGB = true;

		// Token: 0x04000690 RID: 1680
		public static int scrX;

		// Token: 0x04000691 RID: 1681
		public static int scrY;

		// Token: 0x04000682 RID: 1666
		private static float skyColor = 0f;

		// Token: 0x0400068B RID: 1675
		private static Lighting.LightingState[][] states;

		// Token: 0x0400068D RID: 1677
		private static Lighting.LightingSwipeData swipe;

		// Token: 0x04000697 RID: 1687
		private static Dictionary<Point16, Lighting.ColorTriplet> tempLights;

		// Token: 0x0400068E RID: 1678
		private static Lighting.LightingSwipeData[] threadSwipes;

		// Token: 0x040006A0 RID: 1696
		private static float wetLightB = 0.16f;

		// Token: 0x0400069F RID: 1695
		private static float wetLightG = 0.16f;

		// Token: 0x0400069E RID: 1694
		private static float wetLightR = 0.16f;

		// Token: 0x020001CB RID: 459
		private struct ColorTriplet
		{
			// Token: 0x06001421 RID: 5153 RVA: 0x0041C74C File Offset: 0x0041A94C
			public ColorTriplet(float averageColor)
			{
				this.b = averageColor;
				this.g = averageColor;
				this.r = averageColor;
			}

			// Token: 0x06001420 RID: 5152 RVA: 0x0041C732 File Offset: 0x0041A932
			public ColorTriplet(float R, float G, float B)
			{
				this.r = R;
				this.g = G;
				this.b = B;
			}

			// Token: 0x040036A1 RID: 13985
			public float r;

			// Token: 0x040036A2 RID: 13986
			public float g;

			// Token: 0x040036A3 RID: 13987
			public float b;
		}

		// Token: 0x020001CA RID: 458
		private class LightingState
		{
			// Token: 0x0600141E RID: 5150 RVA: 0x0041C719 File Offset: 0x0041A919
			public Vector3 ToVector3()
			{
				return new Vector3(this.r, this.g, this.b);
			}

			// Token: 0x0400369C RID: 13980
			public float b;

			// Token: 0x0400369D RID: 13981
			public float b2;

			// Token: 0x0400369A RID: 13978
			public float g;

			// Token: 0x0400369B RID: 13979
			public float g2;

			// Token: 0x040036A0 RID: 13984
			public bool honeyLight;

			// Token: 0x04003698 RID: 13976
			public float r;

			// Token: 0x04003699 RID: 13977
			public float r2;

			// Token: 0x0400369E RID: 13982
			public bool stopLight;

			// Token: 0x0400369F RID: 13983
			public bool wetLight;
		}

		// Token: 0x020001C9 RID: 457
		private class LightingSwipeData
		{
			// Token: 0x0600141C RID: 5148 RVA: 0x0041C65C File Offset: 0x0041A85C
			public LightingSwipeData()
			{
				this.innerLoop1Start = 0;
				this.outerLoopStart = 0;
				this.innerLoop1End = 0;
				this.outerLoopEnd = 0;
				this.innerLoop2Start = 0;
				this.innerLoop2End = 0;
				this.function = null;
				this.rand = new UnifiedRandom();
			}

			// Token: 0x0600141D RID: 5149 RVA: 0x0041C6AC File Offset: 0x0041A8AC
			public void CopyFrom(Lighting.LightingSwipeData from)
			{
				this.innerLoop1Start = from.innerLoop1Start;
				this.outerLoopStart = from.outerLoopStart;
				this.innerLoop1End = from.innerLoop1End;
				this.outerLoopEnd = from.outerLoopEnd;
				this.innerLoop2Start = from.innerLoop2Start;
				this.innerLoop2End = from.innerLoop2End;
				this.function = from.function;
				this.jaggedArray = from.jaggedArray;
			}

			// Token: 0x04003696 RID: 13974
			public Action<Lighting.LightingSwipeData> function;

			// Token: 0x04003692 RID: 13970
			public int innerLoop1End;

			// Token: 0x04003691 RID: 13969
			public int innerLoop1Start;

			// Token: 0x04003694 RID: 13972
			public int innerLoop2End;

			// Token: 0x04003693 RID: 13971
			public int innerLoop2Start;

			// Token: 0x04003697 RID: 13975
			public Lighting.LightingState[][] jaggedArray;

			// Token: 0x04003690 RID: 13968
			public int outerLoopEnd;

			// Token: 0x0400368F RID: 13967
			public int outerLoopStart;

			// Token: 0x04003695 RID: 13973
			public UnifiedRandom rand;
		}
	}
}

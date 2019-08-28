using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace Terraria.GameContent.Events
{
	// Token: 0x02000174 RID: 372
	public class Sandstorm
	{
		// Token: 0x0600125C RID: 4700 RVA: 0x00416B00 File Offset: 0x00414D00
		public static void WorldClear()
		{
			Sandstorm.Happening = false;
		}

		// Token: 0x0600125D RID: 4701 RVA: 0x00416B08 File Offset: 0x00414D08
		public static void UpdateTime()
		{
			if (Main.netMode != 1)
			{
				if (Sandstorm.Happening)
				{
					if (Sandstorm.TimeLeft > 86400)
					{
						Sandstorm.TimeLeft = 0;
					}
					Sandstorm.TimeLeft -= Main.dayRate;
					if (Sandstorm.TimeLeft <= 0)
					{
						Sandstorm.StopSandstorm();
					}
				}
				else
				{
					int value = (int)(Main.windSpeed * 100f);
					for (int i = 0; i < Main.dayRate; i++)
					{
						if (Main.rand.Next(777600) == 0)
						{
							Sandstorm.StartSandstorm();
						}
						else if ((Main.numClouds < 40 || Math.Abs(value) > 50) && Main.rand.Next(518400) == 0)
						{
							Sandstorm.StartSandstorm();
						}
					}
				}
				if (Main.rand.Next(18000) == 0)
				{
					Sandstorm.ChangeSeverityIntentions();
				}
			}
			Sandstorm.UpdateSeverity();
		}

		// Token: 0x0600125E RID: 4702 RVA: 0x00416BD4 File Offset: 0x00414DD4
		private static void ChangeSeverityIntentions()
		{
			if (Sandstorm.Happening)
			{
				Sandstorm.IntendedSeverity = 0.4f + Main.rand.NextFloat();
			}
			else if (Main.rand.Next(3) == 0)
			{
				Sandstorm.IntendedSeverity = 0f;
			}
			else
			{
				Sandstorm.IntendedSeverity = Main.rand.NextFloat() * 0.3f;
			}
			if (Main.netMode != 1)
			{
				NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
			}
		}

		// Token: 0x0600125F RID: 4703 RVA: 0x00416C54 File Offset: 0x00414E54
		private static void UpdateSeverity()
		{
			int num = Math.Sign(Sandstorm.IntendedSeverity - Sandstorm.Severity);
			Sandstorm.Severity = MathHelper.Clamp(Sandstorm.Severity + 0.003f * (float)num, 0f, 1f);
			int num2 = Math.Sign(Sandstorm.IntendedSeverity - Sandstorm.Severity);
			if (num != num2)
			{
				Sandstorm.Severity = Sandstorm.IntendedSeverity;
			}
		}

		// Token: 0x06001260 RID: 4704 RVA: 0x00416CB4 File Offset: 0x00414EB4
		private static void StartSandstorm()
		{
			Sandstorm.Happening = true;
			Sandstorm.TimeLeft = (int)(3600f * (8f + Main.rand.NextFloat() * 16f));
			Sandstorm.ChangeSeverityIntentions();
		}

		// Token: 0x06001261 RID: 4705 RVA: 0x00416CE4 File Offset: 0x00414EE4
		private static void StopSandstorm()
		{
			Sandstorm.Happening = false;
			Sandstorm.TimeLeft = 0;
			Sandstorm.ChangeSeverityIntentions();
		}

		// Token: 0x06001262 RID: 4706 RVA: 0x00416CF8 File Offset: 0x00414EF8
		public static void HandleEffectAndSky(bool toState)
		{
			if (toState == Sandstorm._effectsUp)
			{
				return;
			}
			Sandstorm._effectsUp = toState;
			Vector2 center = Main.player[Main.myPlayer].Center;
			if (Sandstorm._effectsUp)
			{
				SkyManager.Instance.Activate("Sandstorm", center, new object[0]);
				Filters.Scene.Activate("Sandstorm", center, new object[0]);
				Overlays.Scene.Activate("Sandstorm", center, new object[0]);
				return;
			}
			SkyManager.Instance.Deactivate("Sandstorm", new object[0]);
			Filters.Scene.Deactivate("Sandstorm", new object[0]);
			Overlays.Scene.Deactivate("Sandstorm", new object[0]);
		}

		// Token: 0x06001263 RID: 4707 RVA: 0x00416DB4 File Offset: 0x00414FB4
		public static void EmitDust()
		{
			if (Main.gamePaused)
			{
				return;
			}
			int sandTiles = Main.sandTiles;
			Player player = Main.player[Main.myPlayer];
			bool flag = Sandstorm.Happening && player.ZoneSandstorm && (Main.bgStyle == 2 || Main.bgStyle == 5) && Main.bgDelay < 50;
			Sandstorm.HandleEffectAndSky(flag && Main.UseStormEffects);
			if (sandTiles < 100 || (double)player.position.Y > Main.worldSurface * 16.0 || player.ZoneBeach)
			{
				return;
			}
			int maxValue = 1;
			if (!flag)
			{
				return;
			}
			if (Main.rand.Next(maxValue) != 0)
			{
				return;
			}
			int num = Math.Sign(Main.windSpeed);
			float num2 = Math.Abs(Main.windSpeed);
			if (num2 < 0.01f)
			{
				return;
			}
			float num3 = (float)num * MathHelper.Lerp(0.9f, 1f, num2);
			float num4 = 2000f / (float)sandTiles;
			float num5 = 3f / num4;
			num5 = MathHelper.Clamp(num5, 0.77f, 1f);
			int num6 = (int)num4;
			float num7 = (float)Main.screenWidth / (float)Main.maxScreenW;
			int num8 = (int)(1000f * num7);
			float num9 = 20f * Sandstorm.Severity;
			float num10 = (float)num8 * (Main.gfxQuality * 0.5f + 0.5f) + (float)num8 * 0.1f - (float)Dust.SandStormCount;
			if (num10 <= 0f)
			{
				return;
			}
			float num11 = (float)Main.screenWidth + 1000f;
			float num12 = (float)Main.screenHeight;
			Vector2 value = Main.screenPosition + player.velocity;
			WeightedRandom<Color> weightedRandom = new WeightedRandom<Color>();
			weightedRandom.Add(new Color(200, 160, 20, 180), (double)(Main.screenTileCounts[53] + Main.screenTileCounts[396] + Main.screenTileCounts[397]));
			weightedRandom.Add(new Color(103, 98, 122, 180), (double)(Main.screenTileCounts[112] + Main.screenTileCounts[400] + Main.screenTileCounts[398]));
			weightedRandom.Add(new Color(135, 43, 34, 180), (double)(Main.screenTileCounts[234] + Main.screenTileCounts[401] + Main.screenTileCounts[399]));
			weightedRandom.Add(new Color(213, 196, 197, 180), (double)(Main.screenTileCounts[116] + Main.screenTileCounts[403] + Main.screenTileCounts[402]));
			float num13 = MathHelper.Lerp(0.2f, 0.35f, Sandstorm.Severity);
			float num14 = MathHelper.Lerp(0.5f, 0.7f, Sandstorm.Severity);
			float amount = (num5 - 0.77f) / 0.230000019f;
			int maxValue2 = (int)MathHelper.Lerp(1f, 10f, amount);
			int num15 = 0;
			while ((float)num15 < num9)
			{
				if (Main.rand.Next(num6 / 4) == 0)
				{
					Vector2 vector = new Vector2(Main.rand.NextFloat() * num11 - 500f, Main.rand.NextFloat() * -50f);
					if (Main.rand.Next(3) == 0 && num == 1)
					{
						vector.X = (float)(Main.rand.Next(500) - 500);
					}
					else if (Main.rand.Next(3) == 0 && num == -1)
					{
						vector.X = (float)(Main.rand.Next(500) + Main.screenWidth);
					}
					if (vector.X < 0f || vector.X > (float)Main.screenWidth)
					{
						vector.Y += Main.rand.NextFloat() * num12 * 0.9f;
					}
					vector += value;
					int num16 = (int)vector.X / 16;
					int num17 = (int)vector.Y / 16;
					if (Main.tile[num16, num17] != null && Main.tile[num16, num17].wall == 0)
					{
						for (int i = 0; i < 1; i++)
						{
							Dust dust = Main.dust[Dust.NewDust(vector, 10, 10, 268, 0f, 0f, 0, default(Color), 1f)];
							dust.velocity.Y = 2f + Main.rand.NextFloat() * 0.2f;
							Dust expr_462_cp_0_cp_0 = dust;
							expr_462_cp_0_cp_0.velocity.Y = expr_462_cp_0_cp_0.velocity.Y * dust.scale;
							Dust expr_479_cp_0_cp_0 = dust;
							expr_479_cp_0_cp_0.velocity.Y = expr_479_cp_0_cp_0.velocity.Y * 0.35f;
							dust.velocity.X = num3 * 5f + Main.rand.NextFloat() * 1f;
							Dust expr_4B3_cp_0_cp_0 = dust;
							expr_4B3_cp_0_cp_0.velocity.X = expr_4B3_cp_0_cp_0.velocity.X + num3 * num14 * 20f;
							dust.fadeIn += num14 * 0.2f;
							dust.velocity *= 1f + num13 * 0.5f;
							dust.color = weightedRandom;
							dust.velocity *= 1f + num13;
							dust.velocity *= num5;
							dust.scale = 0.9f;
							num10 -= 1f;
							if (num10 <= 0f)
							{
								break;
							}
							if (Main.rand.Next(maxValue2) != 0)
							{
								i--;
								vector += Utils.RandomVector2(Main.rand, -10f, 10f) + dust.velocity * -1.1f;
								num16 = (int)vector.X / 16;
								num17 = (int)vector.Y / 16;
								if (WorldGen.InWorld(num16, num17, 10) && Main.tile[num16, num17] != null)
								{
									byte arg_5EA_0 = Main.tile[num16, num17].wall;
								}
							}
						}
						if (num10 <= 0f)
						{
							break;
						}
					}
				}
				num15++;
			}
		}

		// Token: 0x06001264 RID: 4708 RVA: 0x004173D4 File Offset: 0x004155D4
		public static void DrawGrains(SpriteBatch spriteBatch)
		{
		}

		// Token: 0x0400328E RID: 12942
		public static bool Happening;

		// Token: 0x0400328F RID: 12943
		public static int TimeLeft;

		// Token: 0x04003290 RID: 12944
		public static float Severity;

		// Token: 0x04003291 RID: 12945
		public static float IntendedSeverity;

		// Token: 0x04003292 RID: 12946
		private static bool _effectsUp;
	}
}

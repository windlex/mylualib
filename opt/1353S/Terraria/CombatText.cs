using System;
using Microsoft.Xna.Framework;

namespace Terraria
{
	// Token: 0x0200001D RID: 29
	public class CombatText
	{
		// Token: 0x06000167 RID: 359 RVA: 0x0002B380 File Offset: 0x00029580
		public static int NewText(Rectangle location, Color color, int amount, bool dramatic = false, bool dot = false)
		{
			return CombatText.NewText(location, color, amount.ToString(), dramatic, dot);
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0002B394 File Offset: 0x00029594
		public static int NewText(Rectangle location, Color color, string text, bool dramatic = false, bool dot = false)
		{
			if (Main.netMode == 2)
			{
				return 100;
			}
			for (int i = 0; i < 100; i++)
			{
				if (!Main.combatText[i].active)
				{
					int num = 0;
					if (dramatic)
					{
						num = 1;
					}
					Vector2 vector = Main.fontCombatText[num].MeasureString(text);
					Main.combatText[i].alpha = 1f;
					Main.combatText[i].alphaDir = -1;
					Main.combatText[i].active = true;
					Main.combatText[i].scale = 0f;
					Main.combatText[i].rotation = 0f;
					Main.combatText[i].position.X = (float)location.X + (float)location.Width * 0.5f - vector.X * 0.5f;
					Main.combatText[i].position.Y = (float)location.Y + (float)location.Height * 0.25f - vector.Y * 0.5f;
					CombatText expr_FC_cp_0_cp_0 = Main.combatText[i];
					expr_FC_cp_0_cp_0.position.X = expr_FC_cp_0_cp_0.position.X + (float)Main.rand.Next(-(int)((double)location.Width * 0.5), (int)((double)location.Width * 0.5) + 1);
					CombatText expr_143_cp_0_cp_0 = Main.combatText[i];
					expr_143_cp_0_cp_0.position.Y = expr_143_cp_0_cp_0.position.Y + (float)Main.rand.Next(-(int)((double)location.Height * 0.5), (int)((double)location.Height * 0.5) + 1);
					Main.combatText[i].color = color;
					Main.combatText[i].text = text;
					Main.combatText[i].velocity.Y = -7f;
					if (Main.player[Main.myPlayer].gravDir == -1f)
					{
						CombatText expr_1D1_cp_0_cp_0 = Main.combatText[i];
						expr_1D1_cp_0_cp_0.velocity.Y = expr_1D1_cp_0_cp_0.velocity.Y * -1f;
						Main.combatText[i].position.Y = (float)location.Y + (float)location.Height * 0.75f + vector.Y * 0.5f;
					}
					Main.combatText[i].lifeTime = 60;
					Main.combatText[i].crit = dramatic;
					Main.combatText[i].dot = dot;
					if (dramatic)
					{
						Main.combatText[i].text = text;
						Main.combatText[i].lifeTime *= 2;
						CombatText expr_26E_cp_0_cp_0 = Main.combatText[i];
						expr_26E_cp_0_cp_0.velocity.Y = expr_26E_cp_0_cp_0.velocity.Y * 2f;
						Main.combatText[i].velocity.X = (float)Main.rand.Next(-25, 26) * 0.05f;
						Main.combatText[i].rotation = (float)(Main.combatText[i].lifeTime / 2) * 0.002f;
						if (Main.combatText[i].velocity.X < 0f)
						{
							Main.combatText[i].rotation *= -1f;
						}
					}
					if (dot)
					{
						Main.combatText[i].velocity.Y = -4f;
						Main.combatText[i].lifeTime = 40;
					}
					return i;
				}
			}
			return 100;
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0002B6C8 File Offset: 0x000298C8
		public static void clearAll()
		{
			for (int i = 0; i < 100; i++)
			{
				Main.combatText[i].active = false;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600016A RID: 362 RVA: 0x0002B6F0 File Offset: 0x000298F0
		public static float TargetScale
		{
			get
			{
				return Main.UIScale / (Main.GameViewMatrix.Zoom.X / Main.ForcedMinimumZoom);
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0002B710 File Offset: 0x00029910
		public void Update()
		{
			if (this.active)
			{
				float targetScale = CombatText.TargetScale;
				this.alpha += (float)this.alphaDir * 0.05f;
				if ((double)this.alpha <= 0.6)
				{
					this.alphaDir = 1;
				}
				if (this.alpha >= 1f)
				{
					this.alpha = 1f;
					this.alphaDir = -1;
				}
				if (this.dot)
				{
					this.velocity.Y = this.velocity.Y + 0.15f;
				}
				else
				{
					this.velocity.Y = this.velocity.Y * 0.92f;
					if (this.crit)
					{
						this.velocity.Y = this.velocity.Y * 0.92f;
					}
				}
				this.velocity.X = this.velocity.X * 0.93f;
				this.position += this.velocity;
				this.lifeTime--;
				if (this.lifeTime <= 0)
				{
					this.scale -= 0.1f * targetScale;
					if ((double)this.scale < 0.1)
					{
						this.active = false;
					}
					this.lifeTime = 0;
					if (this.crit)
					{
						this.alphaDir = -1;
						this.scale += 0.07f * targetScale;
						return;
					}
				}
				else
				{
					if (this.crit)
					{
						if (this.velocity.X < 0f)
						{
							this.rotation += 0.001f;
						}
						else
						{
							this.rotation -= 0.001f;
						}
					}
					if (this.dot)
					{
						this.scale += 0.5f * targetScale;
						if ((double)this.scale > 0.8 * (double)targetScale)
						{
							this.scale = 0.8f * targetScale;
							return;
						}
					}
					else
					{
						if (this.scale < targetScale)
						{
							this.scale += 0.1f * targetScale;
						}
						if (this.scale > targetScale)
						{
							this.scale = targetScale;
						}
					}
				}
			}
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0002B918 File Offset: 0x00029B18
		public static void UpdateCombatText()
		{
			for (int i = 0; i < 100; i++)
			{
				if (Main.combatText[i].active)
				{
					Main.combatText[i].Update();
				}
			}
		}

		// Token: 0x04000165 RID: 357
		public static readonly Color DamagedFriendly = new Color(255, 80, 90, 255);

		// Token: 0x04000166 RID: 358
		public static readonly Color DamagedFriendlyCrit = new Color(255, 100, 30, 255);

		// Token: 0x04000167 RID: 359
		public static readonly Color DamagedHostile = new Color(255, 160, 80, 255);

		// Token: 0x04000168 RID: 360
		public static readonly Color DamagedHostileCrit = new Color(255, 100, 30, 255);

		// Token: 0x04000169 RID: 361
		public static readonly Color OthersDamagedHostile = CombatText.DamagedHostile * 0.4f;

		// Token: 0x0400016A RID: 362
		public static readonly Color OthersDamagedHostileCrit = CombatText.DamagedHostileCrit * 0.4f;

		// Token: 0x0400016B RID: 363
		public static readonly Color HealLife = new Color(100, 255, 100, 255);

		// Token: 0x0400016C RID: 364
		public static readonly Color HealMana = new Color(100, 100, 255, 255);

		// Token: 0x0400016D RID: 365
		public static readonly Color LifeRegen = new Color(255, 60, 70, 255);

		// Token: 0x0400016E RID: 366
		public static readonly Color LifeRegenNegative = new Color(255, 140, 40, 255);

		// Token: 0x0400016F RID: 367
		public Vector2 position;

		// Token: 0x04000170 RID: 368
		public Vector2 velocity;

		// Token: 0x04000171 RID: 369
		public float alpha;

		// Token: 0x04000172 RID: 370
		public int alphaDir = 1;

		// Token: 0x04000173 RID: 371
		public string text;

		// Token: 0x04000174 RID: 372
		public float scale = 1f;

		// Token: 0x04000175 RID: 373
		public float rotation;

		// Token: 0x04000176 RID: 374
		public Color color;

		// Token: 0x04000177 RID: 375
		public bool active;

		// Token: 0x04000178 RID: 376
		public int lifeTime;

		// Token: 0x04000179 RID: 377
		public bool crit;

		// Token: 0x0400017A RID: 378
		public bool dot;
	}
}

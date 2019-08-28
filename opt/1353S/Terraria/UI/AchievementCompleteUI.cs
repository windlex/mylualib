using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Achievements;
using Terraria.GameInput;
using Terraria.Graphics;

namespace Terraria.UI
{
	// Token: 0x020000A4 RID: 164
	public class AchievementCompleteUI
	{
		// Token: 0x06000BAD RID: 2989 RVA: 0x003CF594 File Offset: 0x003CD794
		public static void LoadContent()
		{
			AchievementCompleteUI.AchievementsTexture = TextureManager.Load("Images/UI/Achievements");
			AchievementCompleteUI.AchievementsTextureBorder = TextureManager.Load("Images/UI/Achievement_Borders");
		}

		// Token: 0x06000BAE RID: 2990 RVA: 0x003CF5B4 File Offset: 0x003CD7B4
		public static void Initialize()
		{
			Main.Achievements.OnAchievementCompleted += new Achievement.AchievementCompleted(AchievementCompleteUI.AddCompleted);
		}

		// Token: 0x06000BAF RID: 2991 RVA: 0x003CF5CC File Offset: 0x003CD7CC
		public static void Draw(SpriteBatch sb)
		{
			float num = (float)(Main.screenHeight - 40);
			if (PlayerInput.UsingGamepad)
			{
				num -= 25f;
			}
			Vector2 vector = new Vector2((float)(Main.screenWidth / 2), num);
			foreach (AchievementCompleteUI.DrawCache current in AchievementCompleteUI.caches)
			{
				AchievementCompleteUI.DrawAchievement(sb, ref vector, current);
				if (vector.Y < -100f)
				{
					break;
				}
			}
		}

		// Token: 0x06000BB0 RID: 2992 RVA: 0x003CF658 File Offset: 0x003CD858
		public static void AddCompleted(Achievement achievement)
		{
			if (Main.netMode == 2)
			{
				return;
			}
			AchievementCompleteUI.caches.Add(new AchievementCompleteUI.DrawCache(achievement));
		}

		// Token: 0x06000BB1 RID: 2993 RVA: 0x003CF674 File Offset: 0x003CD874
		public static void Clear()
		{
			AchievementCompleteUI.caches.Clear();
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x003CF680 File Offset: 0x003CD880
		public static void Update()
		{
			using (List<AchievementCompleteUI.DrawCache>.Enumerator enumerator = AchievementCompleteUI.caches.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.Update();
				}
			}
			for (int i = 0; i < AchievementCompleteUI.caches.Count; i++)
			{
				if (AchievementCompleteUI.caches[i].TimeLeft == 0)
				{
					AchievementCompleteUI.caches.Remove(AchievementCompleteUI.caches[i]);
					i--;
				}
			}
		}

		// Token: 0x06000BB3 RID: 2995 RVA: 0x003CF710 File Offset: 0x003CD910
		private static void DrawAchievement(SpriteBatch sb, ref Vector2 center, AchievementCompleteUI.DrawCache ach)
		{
			float alpha = ach.Alpha;
			if (alpha > 0f)
			{
				string title = ach.Title;
				Vector2 arg_53_0 = center;
				Vector2 value = Main.fontItemStack.MeasureString(title);
				float num = ach.Scale * 1.1f;
				Rectangle r = Utils.CenteredRectangle(arg_53_0, (value + new Vector2(58f, 10f)) * num);
				Vector2 mouseScreen = Main.MouseScreen;
				bool expr_6F = r.Contains(mouseScreen.ToPoint());
				Color c = expr_6F ? (new Color(64, 109, 164) * 0.75f) : (new Color(64, 109, 164) * 0.5f);
				Utils.DrawInvBG(sb, r, c);
				float num2 = num * 0.3f;
				Color value2 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)(Main.mouseTextColor / 5), (int)Main.mouseTextColor);
				Vector2 vector = r.Right() - Vector2.UnitX * num * (12f + num2 * (float)ach.Frame.Width);
				sb.Draw(AchievementCompleteUI.AchievementsTexture, vector, new Rectangle?(ach.Frame), Color.White * alpha, 0f, new Vector2(0f, (float)(ach.Frame.Height / 2)), num2, SpriteEffects.None, 0f);
				sb.Draw(AchievementCompleteUI.AchievementsTextureBorder, vector, null, Color.White * alpha, 0f, new Vector2(0f, (float)(ach.Frame.Height / 2)), num2, SpriteEffects.None, 0f);
				Utils.DrawBorderString(sb, title, vector - Vector2.UnitX * 10f, value2 * alpha, num * 0.9f, 1f, 0.4f, -1);
				if (expr_6F && !PlayerInput.IgnoreMouseInterface)
				{
					Main.player[Main.myPlayer].mouseInterface = true;
					if (Main.mouseLeft && Main.mouseLeftRelease)
					{
						IngameFancyUI.OpenAchievementsAndGoto(ach.theAchievement);
						ach.TimeLeft = 0;
					}
				}
			}
			ach.ApplyHeight(ref center);
		}

		// Token: 0x04000EB5 RID: 3765
		private static Texture2D AchievementsTexture;

		// Token: 0x04000EB6 RID: 3766
		private static Texture2D AchievementsTextureBorder;

		// Token: 0x04000EB7 RID: 3767
		private static List<AchievementCompleteUI.DrawCache> caches = new List<AchievementCompleteUI.DrawCache>();

		// Token: 0x02000251 RID: 593
		public class DrawCache
		{
			// Token: 0x0600163E RID: 5694 RVA: 0x0043533C File Offset: 0x0043353C
			public void Update()
			{
				this.TimeLeft--;
				if (this.TimeLeft < 0)
				{
					this.TimeLeft = 0;
				}
			}

			// Token: 0x0600163F RID: 5695 RVA: 0x0043535C File Offset: 0x0043355C
			public DrawCache(Achievement achievement)
			{
				this.theAchievement = achievement;
				this.Title = achievement.FriendlyName.Value;
				int iconIndex = Main.Achievements.GetIconIndex(achievement.Name);
				this.IconIndex = iconIndex;
				this.Frame = new Rectangle(iconIndex % 8 * 66, iconIndex / 8 * 66, 64, 64);
				this.TimeLeft = 300;
			}

			// Token: 0x170001C5 RID: 453
			// (get) Token: 0x06001640 RID: 5696 RVA: 0x004353C8 File Offset: 0x004335C8
			public float Scale
			{
				get
				{
					if (this.TimeLeft < 30)
					{
						return MathHelper.Lerp(0f, 1f, (float)this.TimeLeft / 30f);
					}
					if (this.TimeLeft > 285)
					{
						return MathHelper.Lerp(1f, 0f, ((float)this.TimeLeft - 285f) / 15f);
					}
					return 1f;
				}
			}

			// Token: 0x170001C6 RID: 454
			// (get) Token: 0x06001641 RID: 5697 RVA: 0x00435434 File Offset: 0x00433634
			public float Alpha
			{
				get
				{
					float scale = this.Scale;
					if (scale <= 0.5f)
					{
						return 0f;
					}
					return (scale - 0.5f) / 0.5f;
				}
			}

			// Token: 0x06001642 RID: 5698 RVA: 0x00435464 File Offset: 0x00433664
			public void ApplyHeight(ref Vector2 v)
			{
				v.Y -= 50f * this.Alpha;
			}

			// Token: 0x0400388F RID: 14479
			public Achievement theAchievement;

			// Token: 0x04003890 RID: 14480
			private const int _iconSize = 64;

			// Token: 0x04003891 RID: 14481
			private const int _iconSizeWithSpace = 66;

			// Token: 0x04003892 RID: 14482
			private const int _iconsPerRow = 8;

			// Token: 0x04003893 RID: 14483
			public int IconIndex;

			// Token: 0x04003894 RID: 14484
			public Rectangle Frame;

			// Token: 0x04003895 RID: 14485
			public string Title;

			// Token: 0x04003896 RID: 14486
			public int TimeLeft;
		}
	}
}

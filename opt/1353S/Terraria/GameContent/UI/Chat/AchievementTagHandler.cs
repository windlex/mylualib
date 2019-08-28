using System;
using Microsoft.Xna.Framework;
using Terraria.Achievements;
using Terraria.UI;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Chat
{
	// Token: 0x0200015B RID: 347
	public class AchievementTagHandler : ITagHandler
	{
		// Token: 0x06001184 RID: 4484 RVA: 0x0040DDC8 File Offset: 0x0040BFC8
		TextSnippet ITagHandler.Parse(string text, Color baseColor, string options)
		{
			Achievement achievement = Main.Achievements.GetAchievement(text);
			if (achievement == null)
			{
				return new TextSnippet(text);
			}
			return new AchievementTagHandler.AchievementSnippet(achievement);
		}

		// Token: 0x06001185 RID: 4485 RVA: 0x0040DDF4 File Offset: 0x0040BFF4
		public static string GenerateTag(Achievement achievement)
		{
			return "[a:" + achievement.Name + "]";
		}

		// Token: 0x020002AF RID: 687
		private class AchievementSnippet : TextSnippet
		{
			// Token: 0x06001771 RID: 6001 RVA: 0x0043C0C0 File Offset: 0x0043A2C0
			public AchievementSnippet(Achievement achievement) : base(achievement.FriendlyName.Value, Color.LightBlue, 1f)
			{
				this.CheckForHover = true;
				this._achievement = achievement;
			}

			// Token: 0x06001772 RID: 6002 RVA: 0x0043C0EC File Offset: 0x0043A2EC
			public override void OnClick()
			{
				IngameOptions.Close();
				IngameFancyUI.OpenAchievementsAndGoto(this._achievement);
			}

			// Token: 0x04003D1F RID: 15647
			private Achievement _achievement;
		}
	}
}

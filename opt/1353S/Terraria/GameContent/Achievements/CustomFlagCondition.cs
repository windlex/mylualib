using System;
using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
	// Token: 0x0200012E RID: 302
	public class CustomFlagCondition : AchievementCondition
	{
		// Token: 0x06000FF6 RID: 4086 RVA: 0x003FD480 File Offset: 0x003FB680
		private CustomFlagCondition(string name) : base(name)
		{
		}

		// Token: 0x06000FF7 RID: 4087 RVA: 0x003FD48C File Offset: 0x003FB68C
		public static AchievementCondition Create(string name)
		{
			return new CustomFlagCondition(name);
		}
	}
}

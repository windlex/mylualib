using System;

namespace Terraria.Achievements
{
	// Token: 0x020001B0 RID: 432
	public interface IAchievementTracker
	{
		// Token: 0x060013DA RID: 5082
		void ReportAs(string name);

		// Token: 0x060013DB RID: 5083
		TrackerType GetTrackerType();

		// Token: 0x060013DC RID: 5084
		void Load();

		// Token: 0x060013DD RID: 5085
		void Clear();
	}
}

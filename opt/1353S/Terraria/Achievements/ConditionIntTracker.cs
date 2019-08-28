using System;
using Terraria.Social;

namespace Terraria.Achievements
{
	// Token: 0x020001AB RID: 427
	public class ConditionIntTracker : AchievementTracker<int>
	{
		// Token: 0x060013B6 RID: 5046 RVA: 0x0041C3A0 File Offset: 0x0041A5A0
		public ConditionIntTracker() : base(TrackerType.Int)
		{
		}

		// Token: 0x060013B7 RID: 5047 RVA: 0x0041C3AC File Offset: 0x0041A5AC
		public ConditionIntTracker(int maxValue) : base(TrackerType.Int)
		{
			this._maxValue = maxValue;
		}

		// Token: 0x060013B8 RID: 5048 RVA: 0x0041C3BC File Offset: 0x0041A5BC
		public override void ReportUpdate()
		{
			if (SocialAPI.Achievements != null && this._name != null)
			{
				SocialAPI.Achievements.UpdateIntStat(this._name, this._value);
			}
		}

		// Token: 0x060013B9 RID: 5049 RVA: 0x0041C3E4 File Offset: 0x0041A5E4
		protected override void Load()
		{
		}
	}
}

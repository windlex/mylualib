using System;
using Terraria.Social;

namespace Terraria.Achievements
{
	// Token: 0x020001AA RID: 426
	public class ConditionFloatTracker : AchievementTracker<float>
	{
		// Token: 0x060013B2 RID: 5042 RVA: 0x0041C358 File Offset: 0x0041A558
		public ConditionFloatTracker(float maxValue) : base(TrackerType.Float)
		{
			this._maxValue = maxValue;
		}

		// Token: 0x060013B3 RID: 5043 RVA: 0x0041C368 File Offset: 0x0041A568
		public ConditionFloatTracker() : base(TrackerType.Float)
		{
		}

		// Token: 0x060013B4 RID: 5044 RVA: 0x0041C374 File Offset: 0x0041A574
		public override void ReportUpdate()
		{
			if (SocialAPI.Achievements != null && this._name != null)
			{
				SocialAPI.Achievements.UpdateFloatStat(this._name, this._value);
			}
		}

		// Token: 0x060013B5 RID: 5045 RVA: 0x0041C39C File Offset: 0x0041A59C
		protected override void Load()
		{
		}
	}
}

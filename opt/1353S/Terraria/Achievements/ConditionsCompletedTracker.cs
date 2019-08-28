using System;
using System.Collections.Generic;

namespace Terraria.Achievements
{
	// Token: 0x020001AE RID: 430
	public class ConditionsCompletedTracker : ConditionIntTracker
	{
		// Token: 0x060013D7 RID: 5079 RVA: 0x0041CA58 File Offset: 0x0041AC58
		public void AddCondition(AchievementCondition condition)
		{
			this._maxValue++;
			condition.OnComplete += new AchievementCondition.AchievementUpdate(this.OnConditionCompleted);
			this._conditions.Add(condition);
		}

		// Token: 0x060013D8 RID: 5080 RVA: 0x0041CA88 File Offset: 0x0041AC88
		private void OnConditionCompleted(AchievementCondition condition)
		{
			base.SetValue(Math.Min(this._value + 1, this._maxValue), true);
		}

		// Token: 0x060013D9 RID: 5081 RVA: 0x0041CAA4 File Offset: 0x0041ACA4
		protected override void Load()
		{
			for (int i = 0; i < this._conditions.Count; i++)
			{
				if (this._conditions[i].IsCompleted)
				{
					this._value++;
				}
			}
		}

		// Token: 0x040034DF RID: 13535
		private List<AchievementCondition> _conditions = new List<AchievementCondition>();
	}
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Terraria.Localization;
using Terraria.Social;

namespace Terraria.Achievements
{
	// Token: 0x020001A8 RID: 424
	[JsonObject(MemberSerialization.OptIn)]
	public class Achievement
	{
		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06001394 RID: 5012 RVA: 0x0041BE70 File Offset: 0x0041A070
		public AchievementCategory Category
		{
			get
			{
				return this._category;
			}
		}

		// Token: 0x14000031 RID: 49
		// (add) Token: 0x06001395 RID: 5013 RVA: 0x0041BE78 File Offset: 0x0041A078
		// (remove) Token: 0x06001396 RID: 5014 RVA: 0x0041BEB0 File Offset: 0x0041A0B0
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event Achievement.AchievementCompleted OnCompleted;

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06001397 RID: 5015 RVA: 0x0041BEE8 File Offset: 0x0041A0E8
		public bool HasTracker
		{
			get
			{
				return this._tracker != null;
			}
		}

		// Token: 0x06001398 RID: 5016 RVA: 0x0041BEF4 File Offset: 0x0041A0F4
		public IAchievementTracker GetTracker()
		{
			return this._tracker;
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06001399 RID: 5017 RVA: 0x0041BEFC File Offset: 0x0041A0FC
		public bool IsCompleted
		{
			get
			{
				return this._completedCount == this._conditions.Count;
			}
		}

		// Token: 0x0600139A RID: 5018 RVA: 0x0041BF14 File Offset: 0x0041A114
		public Achievement(string name)
		{
			this.Name = name;
			this.FriendlyName = Language.GetText("Achievements." + name + "_Name");
			this.Description = Language.GetText("Achievements." + name + "_Description");
		}

		// Token: 0x0600139B RID: 5019 RVA: 0x0041BF84 File Offset: 0x0041A184
		public void ClearProgress()
		{
			this._completedCount = 0;
			foreach (KeyValuePair<string, AchievementCondition> current in this._conditions)
			{
				current.Value.Clear();
			}
			if (this._tracker != null)
			{
				this._tracker.Clear();
			}
		}

		// Token: 0x0600139C RID: 5020 RVA: 0x0041BFF8 File Offset: 0x0041A1F8
		public void Load(Dictionary<string, JObject> conditions)
		{
			foreach (KeyValuePair<string, JObject> current in conditions)
			{
				AchievementCondition achievementCondition;
				if (this._conditions.TryGetValue(current.Key, out achievementCondition))
				{
					achievementCondition.Load(current.Value);
					if (achievementCondition.IsCompleted)
					{
						this._completedCount++;
					}
				}
			}
			if (this._tracker != null)
			{
				this._tracker.Load();
			}
		}

		// Token: 0x0600139D RID: 5021 RVA: 0x0041C08C File Offset: 0x0041A28C
		public void AddCondition(AchievementCondition condition)
		{
			this._conditions[condition.Name] = condition;
			condition.OnComplete += new AchievementCondition.AchievementUpdate(this.OnConditionComplete);
		}

		// Token: 0x0600139E RID: 5022 RVA: 0x0041C0B4 File Offset: 0x0041A2B4
		private void OnConditionComplete(AchievementCondition condition)
		{
			this._completedCount++;
			if (this._completedCount == this._conditions.Count)
			{
				if (this._tracker == null && SocialAPI.Achievements != null)
				{
					SocialAPI.Achievements.CompleteAchievement(this.Name);
				}
				if (this.OnCompleted != null)
				{
					this.OnCompleted(this);
				}
			}
		}

		// Token: 0x0600139F RID: 5023 RVA: 0x0041C118 File Offset: 0x0041A318
		private void UseTracker(IAchievementTracker tracker)
		{
			tracker.ReportAs("STAT_" + this.Name);
			this._tracker = tracker;
		}

		// Token: 0x060013A0 RID: 5024 RVA: 0x0041C138 File Offset: 0x0041A338
		public void UseTrackerFromCondition(string conditionName)
		{
			this.UseTracker(this.GetConditionTracker(conditionName));
		}

		// Token: 0x060013A1 RID: 5025 RVA: 0x0041C148 File Offset: 0x0041A348
		public void UseConditionsCompletedTracker()
		{
			ConditionsCompletedTracker conditionsCompletedTracker = new ConditionsCompletedTracker();
			foreach (KeyValuePair<string, AchievementCondition> current in this._conditions)
			{
				conditionsCompletedTracker.AddCondition(current.Value);
			}
			this.UseTracker(conditionsCompletedTracker);
		}

		// Token: 0x060013A2 RID: 5026 RVA: 0x0041C1B0 File Offset: 0x0041A3B0
		public void UseConditionsCompletedTracker(params string[] conditions)
		{
			ConditionsCompletedTracker conditionsCompletedTracker = new ConditionsCompletedTracker();
			for (int i = 0; i < conditions.Length; i++)
			{
				string key = conditions[i];
				conditionsCompletedTracker.AddCondition(this._conditions[key]);
			}
			this.UseTracker(conditionsCompletedTracker);
		}

		// Token: 0x060013A3 RID: 5027 RVA: 0x0041C1F0 File Offset: 0x0041A3F0
		public void ClearTracker()
		{
			this._tracker = null;
		}

		// Token: 0x060013A4 RID: 5028 RVA: 0x0041C1FC File Offset: 0x0041A3FC
		private IAchievementTracker GetConditionTracker(string name)
		{
			return this._conditions[name].GetAchievementTracker();
		}

		// Token: 0x060013A5 RID: 5029 RVA: 0x0041C210 File Offset: 0x0041A410
		public void AddConditions(params AchievementCondition[] conditions)
		{
			for (int i = 0; i < conditions.Length; i++)
			{
				this.AddCondition(conditions[i]);
			}
		}

		// Token: 0x060013A6 RID: 5030 RVA: 0x0041C234 File Offset: 0x0041A434
		public AchievementCondition GetCondition(string conditionName)
		{
			AchievementCondition result;
			if (this._conditions.TryGetValue(conditionName, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060013A7 RID: 5031 RVA: 0x0041C254 File Offset: 0x0041A454
		public void SetCategory(AchievementCategory category)
		{
			this._category = category;
		}

		// Token: 0x040034C5 RID: 13509
		private static int _totalAchievements;

		// Token: 0x040034C6 RID: 13510
		public readonly string Name;

		// Token: 0x040034C7 RID: 13511
		public readonly LocalizedText FriendlyName;

		// Token: 0x040034C8 RID: 13512
		public readonly LocalizedText Description;

		// Token: 0x040034C9 RID: 13513
		public readonly int Id = Achievement._totalAchievements++;

		// Token: 0x040034CA RID: 13514
		private AchievementCategory _category;

		// Token: 0x040034CB RID: 13515
		private IAchievementTracker _tracker;

		// Token: 0x040034CD RID: 13517
		[JsonProperty("Conditions")]
		private Dictionary<string, AchievementCondition> _conditions = new Dictionary<string, AchievementCondition>();

		// Token: 0x040034CE RID: 13518
		private int _completedCount;

		// Token: 0x020002C5 RID: 709
		// (Invoke) Token: 0x060017BA RID: 6074
		public delegate void AchievementCompleted(Achievement achievement);
	}
}

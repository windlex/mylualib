using System;
using Terraria.Social;

namespace Terraria.Achievements
{
	// Token: 0x020001AD RID: 429
	public abstract class AchievementTracker<T> : IAchievementTracker
	{
		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x060013CB RID: 5067 RVA: 0x0041C978 File Offset: 0x0041AB78
		public T Value
		{
			get
			{
				return this._value;
			}
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x060013CC RID: 5068 RVA: 0x0041C980 File Offset: 0x0041AB80
		public T MaxValue
		{
			get
			{
				return this._maxValue;
			}
		}

		// Token: 0x060013CD RID: 5069 RVA: 0x0041C988 File Offset: 0x0041AB88
		protected AchievementTracker(TrackerType type)
		{
			this._type = type;
		}

		// Token: 0x060013CE RID: 5070 RVA: 0x0041C998 File Offset: 0x0041AB98
		void IAchievementTracker.ReportAs(string name)
		{
			this._name = name;
		}

		// Token: 0x060013CF RID: 5071 RVA: 0x0041C9A4 File Offset: 0x0041ABA4
		TrackerType IAchievementTracker.GetTrackerType()
		{
			return this._type;
		}

		// Token: 0x060013D0 RID: 5072 RVA: 0x0041C9AC File Offset: 0x0041ABAC
		void IAchievementTracker.Clear()
		{
			this.SetValue(default(T), true);
		}

		// Token: 0x060013D1 RID: 5073 RVA: 0x0041C9CC File Offset: 0x0041ABCC
		public void SetValue(T newValue, bool reportUpdate = true)
		{
			if (!newValue.Equals(this._value))
			{
				this._value = newValue;
				if (reportUpdate)
				{
					this.ReportUpdate();
					if (this._value.Equals(this._maxValue))
					{
						this.OnComplete();
					}
				}
			}
		}

		// Token: 0x060013D2 RID: 5074
		public abstract void ReportUpdate();

		// Token: 0x060013D3 RID: 5075
		protected abstract void Load();

		// Token: 0x060013D4 RID: 5076 RVA: 0x0041CA28 File Offset: 0x0041AC28
		void IAchievementTracker.Load()
		{
			this.Load();
		}

		// Token: 0x060013D5 RID: 5077 RVA: 0x0041CA30 File Offset: 0x0041AC30
		protected void OnComplete()
		{
			if (SocialAPI.Achievements != null)
			{
				SocialAPI.Achievements.StoreStats();
			}
		}

		// Token: 0x040034DB RID: 13531
		protected T _value;

		// Token: 0x040034DC RID: 13532
		protected T _maxValue;

		// Token: 0x040034DD RID: 13533
		protected string _name;

		// Token: 0x040034DE RID: 13534
		private TrackerType _type;
	}
}

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
	// Token: 0x02000130 RID: 304
	public class CustomIntCondition : AchievementCondition
	{
		// Token: 0x06001001 RID: 4097 RVA: 0x003FC898 File Offset: 0x003FAA98
		private CustomIntCondition(string name, int maxValue) : base(name)
		{
			this._maxValue = maxValue;
			this._value = 0;
		}

		// Token: 0x06001002 RID: 4098 RVA: 0x003FC8AF File Offset: 0x003FAAAF
		public override void Clear()
		{
			this._value = 0;
			base.Clear();
		}

		// Token: 0x06001005 RID: 4101 RVA: 0x003FC909 File Offset: 0x003FAB09
		public static AchievementCondition Create(string name, int maxValue)
		{
			return new CustomIntCondition(name, maxValue);
		}

		// Token: 0x06001004 RID: 4100 RVA: 0x003FC8FC File Offset: 0x003FAAFC
		protected override IAchievementTracker CreateAchievementTracker()
		{
			return new ConditionIntTracker(this._maxValue);
		}

		// Token: 0x06001003 RID: 4099 RVA: 0x003FC8BE File Offset: 0x003FAABE
		public override void Load(JObject state)
		{
			base.Load(state);
			this._value = (int)state["Value"];
			if (this._tracker != null)
			{
				((ConditionIntTracker)this._tracker).SetValue(this._value, false);
			}
		}

		// Token: 0x1700016A RID: 362
		public int Value
		{
			// Token: 0x06000FFF RID: 4095 RVA: 0x003FC83F File Offset: 0x003FAA3F
			get
			{
				return this._value;
			}
			// Token: 0x06001000 RID: 4096 RVA: 0x003FC848 File Offset: 0x003FAA48
			set
			{
				int num = Utils.Clamp<int>(value, 0, this._maxValue);
				if (this._tracker != null)
				{
					((ConditionIntTracker)this._tracker).SetValue(num, true);
				}
				this._value = num;
				if (this._value == this._maxValue)
				{
					this.Complete();
				}
			}
		}

		// Token: 0x04003088 RID: 12424
		private int _maxValue;

		// Token: 0x04003087 RID: 12423
		[JsonProperty("Value")]
		private int _value;
	}
}

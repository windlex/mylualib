using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
	// Token: 0x0200012F RID: 303
	public class CustomFloatCondition : AchievementCondition
	{
		// Token: 0x06000FFA RID: 4090 RVA: 0x003FC7BC File Offset: 0x003FA9BC
		private CustomFloatCondition(string name, float maxValue) : base(name)
		{
			this._maxValue = maxValue;
			this._value = 0f;
		}

		// Token: 0x06000FFB RID: 4091 RVA: 0x003FC7D7 File Offset: 0x003FA9D7
		public override void Clear()
		{
			this._value = 0f;
			base.Clear();
		}

		// Token: 0x06000FFE RID: 4094 RVA: 0x003FC836 File Offset: 0x003FAA36
		public static AchievementCondition Create(string name, float maxValue)
		{
			return new CustomFloatCondition(name, maxValue);
		}

		// Token: 0x06000FFD RID: 4093 RVA: 0x003FC829 File Offset: 0x003FAA29
		protected override IAchievementTracker CreateAchievementTracker()
		{
			return new ConditionFloatTracker(this._maxValue);
		}

		// Token: 0x06000FFC RID: 4092 RVA: 0x003FC7EA File Offset: 0x003FA9EA
		public override void Load(JObject state)
		{
			base.Load(state);
			this._value = (float)state["Value"];
			if (this._tracker != null)
			{
				((ConditionFloatTracker)this._tracker).SetValue(this._value, false);
			}
		}

		// Token: 0x17000169 RID: 361
		public float Value
		{
			// Token: 0x06000FF8 RID: 4088 RVA: 0x003FC75D File Offset: 0x003FA95D
			get
			{
				return this._value;
			}
			// Token: 0x06000FF9 RID: 4089 RVA: 0x003FC768 File Offset: 0x003FA968
			set
			{
				float num = Utils.Clamp<float>(value, 0f, this._maxValue);
				if (this._tracker != null)
				{
					((ConditionFloatTracker)this._tracker).SetValue(num, true);
				}
				this._value = num;
				if (this._value == this._maxValue)
				{
					this.Complete();
				}
			}
		}

		// Token: 0x04003086 RID: 12422
		private float _maxValue;

		// Token: 0x04003085 RID: 12421
		[JsonProperty("Value")]
		private float _value;
	}
}

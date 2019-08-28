using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Terraria.Achievements
{
	// Token: 0x020001A9 RID: 425
	[JsonObject(MemberSerialization.OptIn)]
	public abstract class AchievementCondition
	{
		// Token: 0x060013AC RID: 5036 RVA: 0x0041B001 File Offset: 0x00419201
		protected AchievementCondition(string name)
		{
			this.Name = name;
		}

		// Token: 0x060013AE RID: 5038 RVA: 0x0041B028 File Offset: 0x00419228
		public virtual void Clear()
		{
			this._isCompleted = false;
		}

		// Token: 0x060013AF RID: 5039 RVA: 0x0041B031 File Offset: 0x00419231
		public virtual void Complete()
		{
			if (this._isCompleted)
			{
				return;
			}
			this._isCompleted = true;
			if (this.OnComplete != null)
			{
				this.OnComplete(this);
			}
		}

		// Token: 0x060013B0 RID: 5040 RVA: 0x003B65A2 File Offset: 0x003B47A2
		protected virtual IAchievementTracker CreateAchievementTracker()
		{
			return null;
		}

		// Token: 0x060013B1 RID: 5041 RVA: 0x0041B057 File Offset: 0x00419257
		public IAchievementTracker GetAchievementTracker()
		{
			if (this._tracker == null)
			{
				this._tracker = this.CreateAchievementTracker();
			}
			return this._tracker;
		}

		// Token: 0x060013AD RID: 5037 RVA: 0x0041B010 File Offset: 0x00419210
		public virtual void Load(JObject state)
		{
			this._isCompleted = (bool)state["Completed"];
		}

		// Token: 0x170001B2 RID: 434
		public bool IsCompleted
		{
			// Token: 0x060013AB RID: 5035 RVA: 0x0041AFF9 File Offset: 0x004191F9
			get
			{
				return this._isCompleted;
			}
		}

		// Token: 0x14000032 RID: 50
		// Token: 0x060013A9 RID: 5033 RVA: 0x0041AF8C File Offset: 0x0041918C
		// Token: 0x060013AA RID: 5034 RVA: 0x0041AFC4 File Offset: 0x004191C4
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event AchievementCondition.AchievementUpdate OnComplete;

		// Token: 0x040034CF RID: 13519
		public readonly string Name;

		// Token: 0x040034D2 RID: 13522
		[JsonProperty("Completed")]
		private bool _isCompleted;

		// Token: 0x040034D1 RID: 13521
		protected IAchievementTracker _tracker;

		// Token: 0x020002C6 RID: 710
		// Token: 0x060017BE RID: 6078
		public delegate void AchievementUpdate(AchievementCondition condition);
	}
}

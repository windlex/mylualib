using System;

namespace Terraria.Social.Base
{
	// Token: 0x0200009C RID: 156
	public abstract class AchievementsSocialModule : ISocialModule
	{
		// Token: 0x06000B85 RID: 2949
		public abstract void Initialize();

		// Token: 0x06000B86 RID: 2950
		public abstract void Shutdown();

		// Token: 0x06000B87 RID: 2951
		public abstract byte[] GetEncryptionKey();

		// Token: 0x06000B88 RID: 2952
		public abstract string GetSavePath();

		// Token: 0x06000B89 RID: 2953
		public abstract void UpdateIntStat(string name, int value);

		// Token: 0x06000B8A RID: 2954
		public abstract void UpdateFloatStat(string name, float value);

		// Token: 0x06000B8B RID: 2955
		public abstract void CompleteAchievement(string name);

		// Token: 0x06000B8C RID: 2956
		public abstract bool IsAchievementCompleted(string name);

		// Token: 0x06000B8D RID: 2957
		public abstract void StoreStats();
	}
}

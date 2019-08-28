using System;

namespace Terraria.Social.Base
{
	// Token: 0x0200009A RID: 154
	public abstract class FriendsSocialModule : ISocialModule
	{
		// Token: 0x06000B70 RID: 2928
		public abstract string GetUsername();

		// Token: 0x06000B71 RID: 2929
		public abstract void OpenJoinInterface();

		// Token: 0x06000B72 RID: 2930
		public abstract void Initialize();

		// Token: 0x06000B73 RID: 2931
		public abstract void Shutdown();
	}
}

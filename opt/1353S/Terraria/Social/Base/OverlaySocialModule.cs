using System;

namespace Terraria.Social.Base
{
	// Token: 0x02000098 RID: 152
	public abstract class OverlaySocialModule : ISocialModule
	{
		// Token: 0x06000B5C RID: 2908
		public abstract void Initialize();

		// Token: 0x06000B5D RID: 2909
		public abstract void Shutdown();

		// Token: 0x06000B5E RID: 2910
		public abstract bool IsGamepadTextInputActive();

		// Token: 0x06000B5F RID: 2911
		public abstract bool ShowGamepadTextInput(string description, uint maxLength, bool multiLine = false, string existingText = "", bool password = false);

		// Token: 0x06000B60 RID: 2912
		public abstract string GetGamepadText();
	}
}

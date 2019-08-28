using System;

namespace Terraria.UI
{
	// Token: 0x020000AD RID: 173
	public class UIEvent
	{
		// Token: 0x06000C3E RID: 3134 RVA: 0x003D8AA4 File Offset: 0x003D6CA4
		public UIEvent(UIElement target)
		{
			this.Target = target;
		}

		// Token: 0x04000F02 RID: 3842
		public readonly UIElement Target;
	}
}

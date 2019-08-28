using System;
using Microsoft.Xna.Framework;

namespace Terraria.UI
{
	// Token: 0x020000AE RID: 174
	public class UIMouseEvent : UIEvent
	{
		// Token: 0x06000C3F RID: 3135 RVA: 0x003D8AB4 File Offset: 0x003D6CB4
		public UIMouseEvent(UIElement target, Vector2 mousePosition) : base(target)
		{
			this.MousePosition = mousePosition;
		}

		// Token: 0x04000F03 RID: 3843
		public readonly Vector2 MousePosition;
	}
}

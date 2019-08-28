using System;
using Microsoft.Xna.Framework;

namespace Terraria.UI
{
	// Token: 0x020000AF RID: 175
	public class UIScrollWheelEvent : UIMouseEvent
	{
		// Token: 0x06000C40 RID: 3136 RVA: 0x003D8AC4 File Offset: 0x003D6CC4
		public UIScrollWheelEvent(UIElement target, Vector2 mousePosition, int scrollWheelValue) : base(target, mousePosition)
		{
			this.ScrollWheelValue = scrollWheelValue;
		}

		// Token: 0x04000F04 RID: 3844
		public readonly int ScrollWheelValue;
	}
}

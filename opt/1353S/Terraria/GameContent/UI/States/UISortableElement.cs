using System;
using Terraria.UI;

namespace Terraria.GameContent.UI.States
{
	// Token: 0x0200013E RID: 318
	public class UISortableElement : UIElement
	{
		// Token: 0x0600106A RID: 4202 RVA: 0x00400B64 File Offset: 0x003FED64
		public UISortableElement(int index)
		{
			this.OrderIndex = index;
		}

		// Token: 0x0600106B RID: 4203 RVA: 0x00400B74 File Offset: 0x003FED74
		public override int CompareTo(object obj)
		{
			UISortableElement uISortableElement = obj as UISortableElement;
			if (uISortableElement != null)
			{
				return this.OrderIndex.CompareTo(uISortableElement.OrderIndex);
			}
			return base.CompareTo(obj);
		}

		// Token: 0x0400313F RID: 12607
		public int OrderIndex;
	}
}

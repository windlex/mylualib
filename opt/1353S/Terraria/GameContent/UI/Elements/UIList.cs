using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	// Token: 0x02000150 RID: 336
	public class UIList : UIElement
	{
		// Token: 0x17000171 RID: 369
		// (get) Token: 0x0600111D RID: 4381 RVA: 0x0040B48C File Offset: 0x0040968C
		public int Count
		{
			get
			{
				return this._items.Count;
			}
		}

		// Token: 0x0600111E RID: 4382 RVA: 0x0040B49C File Offset: 0x0040969C
		public UIList()
		{
			this._innerList.OverflowHidden = false;
			this._innerList.Width.Set(0f, 1f);
			this._innerList.Height.Set(0f, 1f);
			this.OverflowHidden = true;
			base.Append(this._innerList);
		}

		// Token: 0x0600111F RID: 4383 RVA: 0x0040B524 File Offset: 0x00409724
		public float GetTotalHeight()
		{
			return this._innerListHeight;
		}

		// Token: 0x06001120 RID: 4384 RVA: 0x0040B52C File Offset: 0x0040972C
		public void Goto(UIList.ElementSearchMethod searchMethod)
		{
			for (int i = 0; i < this._items.Count; i++)
			{
				if (searchMethod(this._items[i]))
				{
					this._scrollbar.ViewPosition = this._items[i].Top.Pixels;
					return;
				}
			}
		}

		// Token: 0x06001121 RID: 4385 RVA: 0x0040B588 File Offset: 0x00409788
		public virtual void Add(UIElement item)
		{
			this._items.Add(item);
			this._innerList.Append(item);
			this.UpdateOrder();
			this._innerList.Recalculate();
		}

		// Token: 0x06001122 RID: 4386 RVA: 0x0040B5B4 File Offset: 0x004097B4
		public virtual bool Remove(UIElement item)
		{
			this._innerList.RemoveChild(item);
			this.UpdateOrder();
			return this._items.Remove(item);
		}

		// Token: 0x06001123 RID: 4387 RVA: 0x0040B5D4 File Offset: 0x004097D4
		public virtual void Clear()
		{
			this._innerList.RemoveAllChildren();
			this._items.Clear();
		}

		// Token: 0x06001124 RID: 4388 RVA: 0x0040B5EC File Offset: 0x004097EC
		public override void Recalculate()
		{
			base.Recalculate();
			this.UpdateScrollbar();
		}

		// Token: 0x06001125 RID: 4389 RVA: 0x0040B5FC File Offset: 0x004097FC
		public override void ScrollWheel(UIScrollWheelEvent evt)
		{
			base.ScrollWheel(evt);
			if (this._scrollbar != null)
			{
				this._scrollbar.ViewPosition -= (float)evt.ScrollWheelValue;
			}
		}

		// Token: 0x06001126 RID: 4390 RVA: 0x0040B628 File Offset: 0x00409828
		public override void RecalculateChildren()
		{
			base.RecalculateChildren();
			float num = 0f;
			for (int i = 0; i < this._items.Count; i++)
			{
				this._items[i].Top.Set(num, 0f);
				this._items[i].Recalculate();
				CalculatedStyle outerDimensions = this._items[i].GetOuterDimensions();
				num += outerDimensions.Height + this.ListPadding;
			}
			this._innerListHeight = num;
		}

		// Token: 0x06001127 RID: 4391 RVA: 0x0040B6B0 File Offset: 0x004098B0
		private void UpdateScrollbar()
		{
			if (this._scrollbar == null)
			{
				return;
			}
			this._scrollbar.SetView(base.GetInnerDimensions().Height, this._innerListHeight);
		}

		// Token: 0x06001128 RID: 4392 RVA: 0x0040B6D8 File Offset: 0x004098D8
		public void SetScrollbar(UIScrollbar scrollbar)
		{
			this._scrollbar = scrollbar;
			this.UpdateScrollbar();
		}

		// Token: 0x06001129 RID: 4393 RVA: 0x0040B6E8 File Offset: 0x004098E8
		public void UpdateOrder()
		{
			this._items.Sort(new Comparison<UIElement>(this.SortMethod));
			this.UpdateScrollbar();
		}

		// Token: 0x0600112A RID: 4394 RVA: 0x0040B708 File Offset: 0x00409908
		public int SortMethod(UIElement item1, UIElement item2)
		{
			return item1.CompareTo(item2);
		}

		// Token: 0x0600112B RID: 4395 RVA: 0x0040B714 File Offset: 0x00409914
		public override List<SnapPoint> GetSnapPoints()
		{
			List<SnapPoint> list = new List<SnapPoint>();
			SnapPoint item;
			if (base.GetSnapPoint(out item))
			{
				list.Add(item);
			}
			foreach (UIElement current in this._items)
			{
				list.AddRange(current.GetSnapPoints());
			}
			return list;
		}

		// Token: 0x0600112C RID: 4396 RVA: 0x0040B784 File Offset: 0x00409984
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			if (this._scrollbar != null)
			{
				this._innerList.Top.Set(-this._scrollbar.GetValue(), 0f);
			}
			this.Recalculate();
		}

		// Token: 0x040031D1 RID: 12753
		protected List<UIElement> _items = new List<UIElement>();

		// Token: 0x040031D2 RID: 12754
		protected UIScrollbar _scrollbar;

		// Token: 0x040031D3 RID: 12755
		private UIElement _innerList = new UIList.UIInnerList();

		// Token: 0x040031D4 RID: 12756
		private float _innerListHeight;

		// Token: 0x040031D5 RID: 12757
		public float ListPadding = 5f;

		// Token: 0x020002AB RID: 683
		// (Invoke) Token: 0x06001766 RID: 5990
		public delegate bool ElementSearchMethod(UIElement element);

		// Token: 0x020002AC RID: 684
		private class UIInnerList : UIElement
		{
			// Token: 0x06001769 RID: 5993 RVA: 0x0043BEA4 File Offset: 0x0043A0A4
			public override bool ContainsPoint(Vector2 point)
			{
				return true;
			}

			// Token: 0x0600176A RID: 5994 RVA: 0x0043BEA8 File Offset: 0x0043A0A8
			protected override void DrawChildren(SpriteBatch spriteBatch)
			{
				Vector2 position = this.Parent.GetDimensions().Position();
				Vector2 dimensions = new Vector2(this.Parent.GetDimensions().Width, this.Parent.GetDimensions().Height);
				foreach (UIElement current in this.Elements)
				{
					Vector2 position2 = current.GetDimensions().Position();
					Vector2 dimensions2 = new Vector2(current.GetDimensions().Width, current.GetDimensions().Height);
					if (Collision.CheckAABBvAABBCollision(position, dimensions, position2, dimensions2))
					{
						current.Draw(spriteBatch);
					}
				}
			}
		}
	}
}

using System;
using Microsoft.Xna.Framework;

namespace Terraria.UI
{
	// Token: 0x020000AA RID: 170
	public class SnapPoint
	{
		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000C05 RID: 3077 RVA: 0x003D7B3C File Offset: 0x003D5D3C
		public string Name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000C06 RID: 3078 RVA: 0x003D7B44 File Offset: 0x003D5D44
		public int ID
		{
			get
			{
				return this._id;
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000C07 RID: 3079 RVA: 0x003D7B4C File Offset: 0x003D5D4C
		public Vector2 Position
		{
			get
			{
				return this._calculatedPosition;
			}
		}

		// Token: 0x06000C08 RID: 3080 RVA: 0x003D7B54 File Offset: 0x003D5D54
		public SnapPoint(string name, int id, Vector2 anchor, Vector2 offset)
		{
			this._name = name;
			this._id = id;
			this._anchor = anchor;
			this._offset = offset;
		}

		// Token: 0x06000C09 RID: 3081 RVA: 0x003D7B7C File Offset: 0x003D5D7C
		public void Calculate(UIElement element)
		{
			this.BoundElement = element;
			CalculatedStyle dimensions = element.GetDimensions();
			this._calculatedPosition = dimensions.Position() + this._offset + this._anchor * new Vector2(dimensions.Width, dimensions.Height);
		}

		// Token: 0x06000C0A RID: 3082 RVA: 0x003D7BD0 File Offset: 0x003D5DD0
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"Snap Point - ",
				this.Name,
				" ",
				this.ID
			});
		}

		// Token: 0x04000ED1 RID: 3793
		private Vector2 _anchor;

		// Token: 0x04000ED2 RID: 3794
		private Vector2 _offset;

		// Token: 0x04000ED3 RID: 3795
		private Vector2 _calculatedPosition;

		// Token: 0x04000ED4 RID: 3796
		private string _name;

		// Token: 0x04000ED5 RID: 3797
		private int _id;

		// Token: 0x04000ED6 RID: 3798
		public UIElement BoundElement;
	}
}

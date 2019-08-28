using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	// Token: 0x02000155 RID: 341
	public class UIToggleImage : UIElement
	{
		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06001155 RID: 4437 RVA: 0x0040C480 File Offset: 0x0040A680
		public bool IsOn
		{
			get
			{
				return this._isOn;
			}
		}

		// Token: 0x06001156 RID: 4438 RVA: 0x0040C488 File Offset: 0x0040A688
		public UIToggleImage(Texture2D texture, int width, int height, Point onTextureOffset, Point offTextureOffset)
		{
			this._onTexture = texture;
			this._offTexture = texture;
			this._offTextureOffset = offTextureOffset;
			this._onTextureOffset = onTextureOffset;
			this._drawWidth = width;
			this._drawHeight = height;
			this.Width.Set((float)width, 0f);
			this.Height.Set((float)height, 0f);
		}

		// Token: 0x06001157 RID: 4439 RVA: 0x0040C504 File Offset: 0x0040A704
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			CalculatedStyle dimensions = base.GetDimensions();
			Texture2D texture;
			Point point;
			if (this._isOn)
			{
				texture = this._onTexture;
				point = this._onTextureOffset;
			}
			else
			{
				texture = this._offTexture;
				point = this._offTextureOffset;
			}
			Color color = base.IsMouseHovering ? Color.White : Color.Silver;
			spriteBatch.Draw(texture, new Rectangle((int)dimensions.X, (int)dimensions.Y, this._drawWidth, this._drawHeight), new Rectangle?(new Rectangle(point.X, point.Y, this._drawWidth, this._drawHeight)), color);
		}

		// Token: 0x06001158 RID: 4440 RVA: 0x0040C59C File Offset: 0x0040A79C
		public override void Click(UIMouseEvent evt)
		{
			this.Toggle();
			base.Click(evt);
		}

		// Token: 0x06001159 RID: 4441 RVA: 0x0040C5AC File Offset: 0x0040A7AC
		public void SetState(bool value)
		{
			this._isOn = value;
		}

		// Token: 0x0600115A RID: 4442 RVA: 0x0040C5B8 File Offset: 0x0040A7B8
		public void Toggle()
		{
			this._isOn = !this._isOn;
		}

		// Token: 0x040031EF RID: 12783
		private Texture2D _onTexture;

		// Token: 0x040031F0 RID: 12784
		private Texture2D _offTexture;

		// Token: 0x040031F1 RID: 12785
		private int _drawWidth;

		// Token: 0x040031F2 RID: 12786
		private int _drawHeight;

		// Token: 0x040031F3 RID: 12787
		private Point _onTextureOffset = Point.Zero;

		// Token: 0x040031F4 RID: 12788
		private Point _offTextureOffset = Point.Zero;

		// Token: 0x040031F5 RID: 12789
		private bool _isOn;
	}
}

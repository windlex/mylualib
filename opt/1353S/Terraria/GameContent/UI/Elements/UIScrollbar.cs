using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	// Token: 0x02000152 RID: 338
	public class UIScrollbar : UIElement
	{
		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06001131 RID: 4401 RVA: 0x0040BB4C File Offset: 0x00409D4C
		// (set) Token: 0x06001132 RID: 4402 RVA: 0x0040BB54 File Offset: 0x00409D54
		public float ViewPosition
		{
			get
			{
				return this._viewPosition;
			}
			set
			{
				this._viewPosition = MathHelper.Clamp(value, 0f, this._maxViewSize - this._viewSize);
			}
		}

		// Token: 0x06001133 RID: 4403 RVA: 0x0040BB74 File Offset: 0x00409D74
		public UIScrollbar()
		{
			this.Width.Set(20f, 0f);
			this.MaxWidth.Set(20f, 0f);
			this._texture = TextureManager.Load("Images/UI/Scrollbar");
			this._innerTexture = TextureManager.Load("Images/UI/ScrollbarInner");
			this.PaddingTop = 5f;
			this.PaddingBottom = 5f;
		}

		// Token: 0x06001134 RID: 4404 RVA: 0x0040BC00 File Offset: 0x00409E00
		public void SetView(float viewSize, float maxViewSize)
		{
			viewSize = MathHelper.Clamp(viewSize, 0f, maxViewSize);
			this._viewPosition = MathHelper.Clamp(this._viewPosition, 0f, maxViewSize - viewSize);
			this._viewSize = viewSize;
			this._maxViewSize = maxViewSize;
		}

		// Token: 0x06001135 RID: 4405 RVA: 0x0040BC38 File Offset: 0x00409E38
		public float GetValue()
		{
			return this._viewPosition;
		}

		// Token: 0x06001136 RID: 4406 RVA: 0x0040BC40 File Offset: 0x00409E40
		private Rectangle GetHandleRectangle()
		{
			CalculatedStyle innerDimensions = base.GetInnerDimensions();
			if (this._maxViewSize == 0f && this._viewSize == 0f)
			{
				this._viewSize = 1f;
				this._maxViewSize = 1f;
			}
			return new Rectangle((int)innerDimensions.X, (int)(innerDimensions.Y + innerDimensions.Height * (this._viewPosition / this._maxViewSize)) - 3, 20, (int)(innerDimensions.Height * (this._viewSize / this._maxViewSize)) + 7);
		}

		// Token: 0x06001137 RID: 4407 RVA: 0x0040BCC8 File Offset: 0x00409EC8
		private void DrawBar(SpriteBatch spriteBatch, Texture2D texture, Rectangle dimensions, Color color)
		{
			spriteBatch.Draw(texture, new Rectangle(dimensions.X, dimensions.Y - 6, dimensions.Width, 6), new Rectangle?(new Rectangle(0, 0, texture.Width, 6)), color);
			spriteBatch.Draw(texture, new Rectangle(dimensions.X, dimensions.Y, dimensions.Width, dimensions.Height), new Rectangle?(new Rectangle(0, 6, texture.Width, 4)), color);
			spriteBatch.Draw(texture, new Rectangle(dimensions.X, dimensions.Y + dimensions.Height, dimensions.Width, 6), new Rectangle?(new Rectangle(0, texture.Height - 6, texture.Width, 6)), color);
		}

		// Token: 0x06001138 RID: 4408 RVA: 0x0040BD88 File Offset: 0x00409F88
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			CalculatedStyle dimensions = base.GetDimensions();
			CalculatedStyle innerDimensions = base.GetInnerDimensions();
			if (this._isDragging)
			{
				float num = UserInterface.ActiveInstance.MousePosition.Y - innerDimensions.Y - this._dragYOffset;
				this._viewPosition = MathHelper.Clamp(num / innerDimensions.Height * this._maxViewSize, 0f, this._maxViewSize - this._viewSize);
			}
			Rectangle handleRectangle = this.GetHandleRectangle();
			Vector2 mousePosition = UserInterface.ActiveInstance.MousePosition;
			bool arg_9A_0 = this._isHoveringOverHandle;
			this._isHoveringOverHandle = handleRectangle.Contains(new Point((int)mousePosition.X, (int)mousePosition.Y));
			if (!arg_9A_0 && this._isHoveringOverHandle && Main.hasFocus)
			{
				Main.PlaySound(12, -1, -1, 1, 1f, 0f);
			}
			this.DrawBar(spriteBatch, this._texture, dimensions.ToRectangle(), Color.White);
			this.DrawBar(spriteBatch, this._innerTexture, handleRectangle, Color.White * ((this._isDragging || this._isHoveringOverHandle) ? 1f : 0.85f));
		}

		// Token: 0x06001139 RID: 4409 RVA: 0x0040BEA4 File Offset: 0x0040A0A4
		public override void MouseDown(UIMouseEvent evt)
		{
			base.MouseDown(evt);
			if (evt.Target == this)
			{
				Rectangle handleRectangle = this.GetHandleRectangle();
				if (handleRectangle.Contains(new Point((int)evt.MousePosition.X, (int)evt.MousePosition.Y)))
				{
					this._isDragging = true;
					this._dragYOffset = evt.MousePosition.Y - (float)handleRectangle.Y;
					return;
				}
				CalculatedStyle innerDimensions = base.GetInnerDimensions();
				float num = UserInterface.ActiveInstance.MousePosition.Y - innerDimensions.Y - (float)(handleRectangle.Height >> 1);
				this._viewPosition = MathHelper.Clamp(num / innerDimensions.Height * this._maxViewSize, 0f, this._maxViewSize - this._viewSize);
			}
		}

		// Token: 0x0600113A RID: 4410 RVA: 0x0040BF68 File Offset: 0x0040A168
		public override void MouseUp(UIMouseEvent evt)
		{
			base.MouseUp(evt);
			this._isDragging = false;
		}

		// Token: 0x040031DC RID: 12764
		private float _viewPosition;

		// Token: 0x040031DD RID: 12765
		private float _viewSize = 1f;

		// Token: 0x040031DE RID: 12766
		private float _maxViewSize = 20f;

		// Token: 0x040031DF RID: 12767
		private bool _isDragging;

		// Token: 0x040031E0 RID: 12768
		private bool _isHoveringOverHandle;

		// Token: 0x040031E1 RID: 12769
		private float _dragYOffset;

		// Token: 0x040031E2 RID: 12770
		private Texture2D _texture;

		// Token: 0x040031E3 RID: 12771
		private Texture2D _innerTexture;
	}
}

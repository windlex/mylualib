using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	// Token: 0x0200014E RID: 334
	public class UIImageButton : UIElement
	{
		// Token: 0x06001114 RID: 4372 RVA: 0x0040B204 File Offset: 0x00409404
		public UIImageButton(Texture2D texture)
		{
			this._texture = texture;
			this.Width.Set((float)this._texture.Width, 0f);
			this.Height.Set((float)this._texture.Height, 0f);
		}

		// Token: 0x06001115 RID: 4373 RVA: 0x0040B26C File Offset: 0x0040946C
		public void SetImage(Texture2D texture)
		{
			this._texture = texture;
			this.Width.Set((float)this._texture.Width, 0f);
			this.Height.Set((float)this._texture.Height, 0f);
		}

		// Token: 0x06001116 RID: 4374 RVA: 0x0040B2B8 File Offset: 0x004094B8
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			CalculatedStyle dimensions = base.GetDimensions();
			spriteBatch.Draw(this._texture, dimensions.Position(), Color.White * (base.IsMouseHovering ? this._visibilityActive : this._visibilityInactive));
		}

		// Token: 0x06001117 RID: 4375 RVA: 0x0040B300 File Offset: 0x00409500
		public override void MouseOver(UIMouseEvent evt)
		{
			base.MouseOver(evt);
			Main.PlaySound(12, -1, -1, 1, 1f, 0f);
		}

		// Token: 0x06001118 RID: 4376 RVA: 0x0040B320 File Offset: 0x00409520
		public void SetVisibility(float whenActive, float whenInactive)
		{
			this._visibilityActive = MathHelper.Clamp(whenActive, 0f, 1f);
			this._visibilityInactive = MathHelper.Clamp(whenInactive, 0f, 1f);
		}

		// Token: 0x040031CB RID: 12747
		private Texture2D _texture;

		// Token: 0x040031CC RID: 12748
		private float _visibilityActive = 1f;

		// Token: 0x040031CD RID: 12749
		private float _visibilityInactive = 0.4f;
	}
}

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	// Token: 0x0200014D RID: 333
	public class UIImage : UIElement
	{
		// Token: 0x06001111 RID: 4369 RVA: 0x0040B0E0 File Offset: 0x004092E0
		public UIImage(Texture2D texture)
		{
			this._texture = texture;
			this.Width.Set((float)this._texture.Width, 0f);
			this.Height.Set((float)this._texture.Height, 0f);
		}

		// Token: 0x06001112 RID: 4370 RVA: 0x0040B140 File Offset: 0x00409340
		public void SetImage(Texture2D texture)
		{
			this._texture = texture;
			this.Width.Set((float)this._texture.Width, 0f);
			this.Height.Set((float)this._texture.Height, 0f);
		}

		// Token: 0x06001113 RID: 4371 RVA: 0x0040B18C File Offset: 0x0040938C
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			CalculatedStyle dimensions = base.GetDimensions();
			spriteBatch.Draw(this._texture, dimensions.Position() + this._texture.Size() * (1f - this.ImageScale) / 2f, null, Color.White, 0f, Vector2.Zero, this.ImageScale, SpriteEffects.None, 0f);
		}

		// Token: 0x040031C9 RID: 12745
		private Texture2D _texture;

		// Token: 0x040031CA RID: 12746
		public float ImageScale = 1f;
	}
}

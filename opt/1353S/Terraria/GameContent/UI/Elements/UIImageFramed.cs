using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	// Token: 0x0200014F RID: 335
	public class UIImageFramed : UIElement
	{
		// Token: 0x06001119 RID: 4377 RVA: 0x0040B350 File Offset: 0x00409550
		public UIImageFramed(Texture2D texture, Rectangle frame)
		{
			this._texture = texture;
			this._frame = frame;
			this.Width.Set((float)this._frame.Width, 0f);
			this.Height.Set((float)this._frame.Height, 0f);
		}

		// Token: 0x0600111A RID: 4378 RVA: 0x0040B3B4 File Offset: 0x004095B4
		public void SetImage(Texture2D texture, Rectangle frame)
		{
			this._texture = texture;
			this._frame = frame;
			this.Width.Set((float)this._frame.Width, 0f);
			this.Height.Set((float)this._frame.Height, 0f);
		}

		// Token: 0x0600111B RID: 4379 RVA: 0x0040B408 File Offset: 0x00409608
		public void SetFrame(Rectangle frame)
		{
			this._frame = frame;
			this.Width.Set((float)this._frame.Width, 0f);
			this.Height.Set((float)this._frame.Height, 0f);
		}

		// Token: 0x0600111C RID: 4380 RVA: 0x0040B454 File Offset: 0x00409654
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			CalculatedStyle dimensions = base.GetDimensions();
			spriteBatch.Draw(this._texture, dimensions.Position(), new Rectangle?(this._frame), this.Color);
		}

		// Token: 0x040031CE RID: 12750
		private Texture2D _texture;

		// Token: 0x040031CF RID: 12751
		private Rectangle _frame;

		// Token: 0x040031D0 RID: 12752
		public Color Color = Color.White;
	}
}

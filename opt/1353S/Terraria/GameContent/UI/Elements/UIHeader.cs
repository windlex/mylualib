using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	// Token: 0x02000159 RID: 345
	public class UIHeader : UIElement
	{
		// Token: 0x1700017D RID: 381
		// (get) Token: 0x0600117A RID: 4474 RVA: 0x0040D998 File Offset: 0x0040BB98
		// (set) Token: 0x0600117B RID: 4475 RVA: 0x0040D9A0 File Offset: 0x0040BBA0
		public string Text
		{
			get
			{
				return this._text;
			}
			set
			{
				if (this._text != value)
				{
					this._text = value;
					Vector2 vector = Main.fontDeathText.MeasureString(this.Text);
					this.Width.Pixels = vector.X;
					this.Height.Pixels = vector.Y;
					this.Width.Precent = 0f;
					this.Height.Precent = 0f;
					this.Recalculate();
				}
			}
		}

		// Token: 0x0600117C RID: 4476 RVA: 0x0040DA1C File Offset: 0x0040BC1C
		public UIHeader()
		{
			this.Text = "";
		}

		// Token: 0x0600117D RID: 4477 RVA: 0x0040DA30 File Offset: 0x0040BC30
		public UIHeader(string text)
		{
			this.Text = text;
		}

		// Token: 0x0600117E RID: 4478 RVA: 0x0040DA40 File Offset: 0x0040BC40
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			CalculatedStyle dimensions = base.GetDimensions();
			DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, Main.fontDeathText, this.Text, new Vector2(dimensions.X, dimensions.Y), Color.White);
		}

		// Token: 0x0400320F RID: 12815
		private string _text;
	}
}

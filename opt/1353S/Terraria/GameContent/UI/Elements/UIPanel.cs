using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	// Token: 0x02000151 RID: 337
	public class UIPanel : UIElement
	{
		// Token: 0x0600112D RID: 4397 RVA: 0x0040B7B8 File Offset: 0x004099B8
		public UIPanel()
		{
			if (UIPanel._borderTexture == null)
			{
				UIPanel._borderTexture = TextureManager.Load("Images/UI/PanelBorder");
			}
			if (UIPanel._backgroundTexture == null)
			{
				UIPanel._backgroundTexture = TextureManager.Load("Images/UI/PanelBackground");
			}
			base.SetPadding((float)UIPanel.CORNER_SIZE);
		}

		// Token: 0x0600112E RID: 4398 RVA: 0x0040B82C File Offset: 0x00409A2C
		private void DrawPanel(SpriteBatch spriteBatch, Texture2D texture, Color color)
		{
			CalculatedStyle dimensions = base.GetDimensions();
			Point point = new Point((int)dimensions.X, (int)dimensions.Y);
			Point point2 = new Point(point.X + (int)dimensions.Width - UIPanel.CORNER_SIZE, point.Y + (int)dimensions.Height - UIPanel.CORNER_SIZE);
			int width = point2.X - point.X - UIPanel.CORNER_SIZE;
			int height = point2.Y - point.Y - UIPanel.CORNER_SIZE;
			spriteBatch.Draw(texture, new Rectangle(point.X, point.Y, UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE), new Rectangle?(new Rectangle(0, 0, UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE)), color);
			spriteBatch.Draw(texture, new Rectangle(point2.X, point.Y, UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE), new Rectangle?(new Rectangle(UIPanel.CORNER_SIZE + UIPanel.BAR_SIZE, 0, UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE)), color);
			spriteBatch.Draw(texture, new Rectangle(point.X, point2.Y, UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE), new Rectangle?(new Rectangle(0, UIPanel.CORNER_SIZE + UIPanel.BAR_SIZE, UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE)), color);
			spriteBatch.Draw(texture, new Rectangle(point2.X, point2.Y, UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE), new Rectangle?(new Rectangle(UIPanel.CORNER_SIZE + UIPanel.BAR_SIZE, UIPanel.CORNER_SIZE + UIPanel.BAR_SIZE, UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE)), color);
			spriteBatch.Draw(texture, new Rectangle(point.X + UIPanel.CORNER_SIZE, point.Y, width, UIPanel.CORNER_SIZE), new Rectangle?(new Rectangle(UIPanel.CORNER_SIZE, 0, UIPanel.BAR_SIZE, UIPanel.CORNER_SIZE)), color);
			spriteBatch.Draw(texture, new Rectangle(point.X + UIPanel.CORNER_SIZE, point2.Y, width, UIPanel.CORNER_SIZE), new Rectangle?(new Rectangle(UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE + UIPanel.BAR_SIZE, UIPanel.BAR_SIZE, UIPanel.CORNER_SIZE)), color);
			spriteBatch.Draw(texture, new Rectangle(point.X, point.Y + UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE, height), new Rectangle?(new Rectangle(0, UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE, UIPanel.BAR_SIZE)), color);
			spriteBatch.Draw(texture, new Rectangle(point2.X, point.Y + UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE, height), new Rectangle?(new Rectangle(UIPanel.CORNER_SIZE + UIPanel.BAR_SIZE, UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE, UIPanel.BAR_SIZE)), color);
			spriteBatch.Draw(texture, new Rectangle(point.X + UIPanel.CORNER_SIZE, point.Y + UIPanel.CORNER_SIZE, width, height), new Rectangle?(new Rectangle(UIPanel.CORNER_SIZE, UIPanel.CORNER_SIZE, UIPanel.BAR_SIZE, UIPanel.BAR_SIZE)), color);
		}

		// Token: 0x0600112F RID: 4399 RVA: 0x0040BB14 File Offset: 0x00409D14
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			this.DrawPanel(spriteBatch, UIPanel._backgroundTexture, this.BackgroundColor);
			this.DrawPanel(spriteBatch, UIPanel._borderTexture, this.BorderColor);
		}

		// Token: 0x040031D6 RID: 12758
		private static int CORNER_SIZE = 12;

		// Token: 0x040031D7 RID: 12759
		private static int BAR_SIZE = 4;

		// Token: 0x040031D8 RID: 12760
		private static Texture2D _borderTexture;

		// Token: 0x040031D9 RID: 12761
		private static Texture2D _backgroundTexture;

		// Token: 0x040031DA RID: 12762
		public Color BorderColor = Color.Black;

		// Token: 0x040031DB RID: 12763
		public Color BackgroundColor = new Color(63, 82, 151) * 0.7f;
	}
}

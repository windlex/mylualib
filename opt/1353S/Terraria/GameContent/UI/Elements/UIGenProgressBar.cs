using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	// Token: 0x02000157 RID: 343
	public class UIGenProgressBar : UIElement
	{
		// Token: 0x06001171 RID: 4465 RVA: 0x0040D49C File Offset: 0x0040B69C
		public UIGenProgressBar()
		{
			if (Main.netMode != 2)
			{
				this._texInnerDirt = TextureManager.Load("Images/UI/WorldGen/Outer Dirt");
				this._texOuterCorrupt = TextureManager.Load("Images/UI/WorldGen/Outer Corrupt");
				this._texOuterCrimson = TextureManager.Load("Images/UI/WorldGen/Outer Crimson");
				this._texOuterLower = TextureManager.Load("Images/UI/WorldGen/Outer Lower");
			}
			this.Recalculate();
		}

		// Token: 0x06001172 RID: 4466 RVA: 0x0040D500 File Offset: 0x0040B700
		public override void Recalculate()
		{
			this.Width.Precent = 0f;
			this.Height.Precent = 0f;
			this.Width.Pixels = 612f;
			this.Height.Pixels = 70f;
			base.Recalculate();
		}

		// Token: 0x06001173 RID: 4467 RVA: 0x0040D554 File Offset: 0x0040B754
		public void SetProgress(float overallProgress, float currentProgress)
		{
			this._targetCurrentProgress = currentProgress;
			this._targetOverallProgress = overallProgress;
		}

		// Token: 0x06001174 RID: 4468 RVA: 0x0040D564 File Offset: 0x0040B764
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			this._visualOverallProgress = this._targetOverallProgress;
			this._visualCurrentProgress = this._targetCurrentProgress;
			CalculatedStyle dimensions = base.GetDimensions();
			int completedWidth = (int)(this._visualOverallProgress * 504f);
			int completedWidth2 = (int)(this._visualCurrentProgress * 504f);
			Vector2 value = new Vector2(dimensions.X, dimensions.Y);
			Color color = default(Color);
			color.PackedValue = (WorldGen.crimson ? 4286836223u : 4283888223u);
			this.DrawFilling2(spriteBatch, value + new Vector2(20f, 40f), 16, completedWidth, 564, color, Color.Lerp(color, Color.Black, 0.5f), new Color(48, 48, 48));
			color.PackedValue = 4290947159u;
			this.DrawFilling2(spriteBatch, value + new Vector2(50f, 60f), 8, completedWidth2, 504, color, Color.Lerp(color, Color.Black, 0.5f), new Color(33, 33, 33));
			Rectangle r = base.GetDimensions().ToRectangle();
			r.X -= 8;
			spriteBatch.Draw(WorldGen.crimson ? this._texOuterCrimson : this._texOuterCorrupt, r.TopLeft(), Color.White);
			spriteBatch.Draw(this._texOuterLower, r.TopLeft() + new Vector2(44f, 60f), Color.White);
		}

		// Token: 0x06001175 RID: 4469 RVA: 0x0040D6E0 File Offset: 0x0040B8E0
		private void DrawFilling(SpriteBatch spritebatch, Texture2D tex, Texture2D texShadow, Vector2 topLeft, int completedWidth, int totalWidth, Color separator, Color empty)
		{
			if (completedWidth % 2 != 0)
			{
				completedWidth--;
			}
			Vector2 position = topLeft + (float)completedWidth * Vector2.UnitX;
			int i = completedWidth;
			Rectangle rectangle = tex.Frame(1, 1, 0, 0);
			while (i > 0)
			{
				if (rectangle.Width > i)
				{
					rectangle.X += rectangle.Width - i;
					rectangle.Width = i;
				}
				spritebatch.Draw(tex, position, new Rectangle?(rectangle), Color.White, 0f, new Vector2((float)rectangle.Width, 0f), 1f, SpriteEffects.None, 0f);
				position.X -= (float)rectangle.Width;
				i -= rectangle.Width;
			}
			if (texShadow != null)
			{
				spritebatch.Draw(texShadow, topLeft, new Rectangle?(new Rectangle(0, 0, completedWidth, texShadow.Height)), Color.White);
			}
			spritebatch.Draw(Main.magicPixel, new Rectangle((int)topLeft.X + completedWidth, (int)topLeft.Y, totalWidth - completedWidth, tex.Height), new Rectangle?(new Rectangle(0, 0, 1, 1)), empty);
			spritebatch.Draw(Main.magicPixel, new Rectangle((int)topLeft.X + completedWidth - 2, (int)topLeft.Y, 2, tex.Height), new Rectangle?(new Rectangle(0, 0, 1, 1)), separator);
		}

		// Token: 0x06001176 RID: 4470 RVA: 0x0040D834 File Offset: 0x0040BA34
		private void DrawFilling2(SpriteBatch spritebatch, Vector2 topLeft, int height, int completedWidth, int totalWidth, Color filled, Color separator, Color empty)
		{
			if (completedWidth % 2 != 0)
			{
				completedWidth--;
			}
			spritebatch.Draw(Main.magicPixel, new Rectangle((int)topLeft.X, (int)topLeft.Y, completedWidth, height), new Rectangle?(new Rectangle(0, 0, 1, 1)), filled);
			spritebatch.Draw(Main.magicPixel, new Rectangle((int)topLeft.X + completedWidth, (int)topLeft.Y, totalWidth - completedWidth, height), new Rectangle?(new Rectangle(0, 0, 1, 1)), empty);
			spritebatch.Draw(Main.magicPixel, new Rectangle((int)topLeft.X + completedWidth - 2, (int)topLeft.Y, 2, height), new Rectangle?(new Rectangle(0, 0, 1, 1)), separator);
		}

		// Token: 0x04003204 RID: 12804
		private Texture2D _texInnerDirt;

		// Token: 0x04003205 RID: 12805
		private Texture2D _texOuterCrimson;

		// Token: 0x04003206 RID: 12806
		private Texture2D _texOuterCorrupt;

		// Token: 0x04003207 RID: 12807
		private Texture2D _texOuterLower;

		// Token: 0x04003208 RID: 12808
		private float _visualOverallProgress;

		// Token: 0x04003209 RID: 12809
		private float _targetOverallProgress;

		// Token: 0x0400320A RID: 12810
		private float _visualCurrentProgress;

		// Token: 0x0400320B RID: 12811
		private float _targetCurrentProgress;
	}
}

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	// Token: 0x02000158 RID: 344
	public class UIProgressBar : UIElement
	{
		// Token: 0x06001177 RID: 4471 RVA: 0x0040D8EC File Offset: 0x0040BAEC
		public UIProgressBar()
		{
			this._progressBar.Height.Precent = 1f;
			this._progressBar.Recalculate();
			base.Append(this._progressBar);
		}

		// Token: 0x06001178 RID: 4472 RVA: 0x0040D92C File Offset: 0x0040BB2C
		public void SetProgress(float value)
		{
			this._targetProgress = value;
			if (value < this._visualProgress)
			{
				this._visualProgress = value;
			}
		}

		// Token: 0x06001179 RID: 4473 RVA: 0x0040D948 File Offset: 0x0040BB48
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			this._visualProgress = this._visualProgress * 0.95f + 0.05f * this._targetProgress;
			this._progressBar.Width.Precent = this._visualProgress;
			this._progressBar.Recalculate();
		}

		// Token: 0x0400320C RID: 12812
		private UIProgressBar.UIInnerProgressBar _progressBar = new UIProgressBar.UIInnerProgressBar();

		// Token: 0x0400320D RID: 12813
		private float _visualProgress;

		// Token: 0x0400320E RID: 12814
		private float _targetProgress;

		// Token: 0x020002AD RID: 685
		private class UIInnerProgressBar : UIElement
		{
			// Token: 0x0600176C RID: 5996 RVA: 0x0043BF80 File Offset: 0x0043A180
			protected override void DrawSelf(SpriteBatch spriteBatch)
			{
				CalculatedStyle dimensions = base.GetDimensions();
				spriteBatch.Draw(Main.magicPixel, new Vector2(dimensions.X, dimensions.Y), null, Color.Blue, 0f, Vector2.Zero, new Vector2(dimensions.Width, dimensions.Height / 1000f), SpriteEffects.None, 0f);
			}
		}
	}
}

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	// Token: 0x02000153 RID: 339
	public class UIText : UIElement
	{
		// Token: 0x17000173 RID: 371
		// (get) Token: 0x0600113B RID: 4411 RVA: 0x0040BF78 File Offset: 0x0040A178
		public string Text
		{
			get
			{
				return this._text.ToString();
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x0600113C RID: 4412 RVA: 0x0040BF88 File Offset: 0x0040A188
		// (set) Token: 0x0600113D RID: 4413 RVA: 0x0040BF90 File Offset: 0x0040A190
		public Color TextColor
		{
			get
			{
				return this._color;
			}
			set
			{
				this._color = value;
			}
		}

		// Token: 0x0600113E RID: 4414 RVA: 0x0040BF9C File Offset: 0x0040A19C
		public UIText(string text, float textScale = 1f, bool large = false)
		{
			this.InternalSetText(text, textScale, large);
		}

		// Token: 0x0600113F RID: 4415 RVA: 0x0040BFDC File Offset: 0x0040A1DC
		public UIText(LocalizedText text, float textScale = 1f, bool large = false)
		{
			this.InternalSetText(text, textScale, large);
		}

		// Token: 0x06001140 RID: 4416 RVA: 0x0040C01C File Offset: 0x0040A21C
		public override void Recalculate()
		{
			this.InternalSetText(this._text, this._textScale, this._isLarge);
			base.Recalculate();
		}

		// Token: 0x06001141 RID: 4417 RVA: 0x0040C03C File Offset: 0x0040A23C
		public void SetText(string text)
		{
			this.InternalSetText(text, this._textScale, this._isLarge);
		}

		// Token: 0x06001142 RID: 4418 RVA: 0x0040C054 File Offset: 0x0040A254
		public void SetText(LocalizedText text)
		{
			this.InternalSetText(text, this._textScale, this._isLarge);
		}

		// Token: 0x06001143 RID: 4419 RVA: 0x0040C06C File Offset: 0x0040A26C
		public void SetText(string text, float textScale, bool large)
		{
			this.InternalSetText(text, textScale, large);
		}

		// Token: 0x06001144 RID: 4420 RVA: 0x0040C078 File Offset: 0x0040A278
		public void SetText(LocalizedText text, float textScale, bool large)
		{
			this.InternalSetText(text, textScale, large);
		}

		// Token: 0x06001145 RID: 4421 RVA: 0x0040C084 File Offset: 0x0040A284
		private void InternalSetText(object text, float textScale, bool large)
		{
			Vector2 vector = new Vector2((large ? Main.fontDeathText : Main.fontMouseText).MeasureString(text.ToString()).X, large ? 32f : 16f) * textScale;
			this._text = text;
			this._textScale = textScale;
			this._textSize = vector;
			this._isLarge = large;
			this.MinWidth.Set(vector.X + this.PaddingLeft + this.PaddingRight, 0f);
			this.MinHeight.Set(vector.Y + this.PaddingTop + this.PaddingBottom, 0f);
		}

		// Token: 0x06001146 RID: 4422 RVA: 0x0040C130 File Offset: 0x0040A330
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			base.DrawSelf(spriteBatch);
			CalculatedStyle innerDimensions = base.GetInnerDimensions();
			Vector2 pos = innerDimensions.Position();
			if (this._isLarge)
			{
				pos.Y -= 10f * this._textScale;
			}
			else
			{
				pos.Y -= 2f * this._textScale;
			}
			pos.X += (innerDimensions.Width - this._textSize.X) * 0.5f;
			if (this._isLarge)
			{
				Utils.DrawBorderStringBig(spriteBatch, this.Text, pos, this._color, this._textScale, 0f, 0f, -1);
				return;
			}
			Utils.DrawBorderString(spriteBatch, this.Text, pos, this._color, this._textScale, 0f, 0f, -1);
		}

		// Token: 0x040031E4 RID: 12772
		private object _text = "";

		// Token: 0x040031E5 RID: 12773
		private float _textScale = 1f;

		// Token: 0x040031E6 RID: 12774
		private Vector2 _textSize = Vector2.Zero;

		// Token: 0x040031E7 RID: 12775
		private bool _isLarge;

		// Token: 0x040031E8 RID: 12776
		private Color _color = Color.White;
	}
}

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	// Token: 0x02000154 RID: 340
	public class UITextPanel<T> : UIPanel
	{
		// Token: 0x17000175 RID: 373
		// (get) Token: 0x06001147 RID: 4423 RVA: 0x0040C204 File Offset: 0x0040A404
		public bool IsLarge
		{
			get
			{
				return this._isLarge;
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x06001148 RID: 4424 RVA: 0x0040C20C File Offset: 0x0040A40C
		// (set) Token: 0x06001149 RID: 4425 RVA: 0x0040C214 File Offset: 0x0040A414
		public bool DrawPanel
		{
			get
			{
				return this._drawPanel;
			}
			set
			{
				this._drawPanel = value;
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x0600114A RID: 4426 RVA: 0x0040C220 File Offset: 0x0040A420
		// (set) Token: 0x0600114B RID: 4427 RVA: 0x0040C228 File Offset: 0x0040A428
		public float TextScale
		{
			get
			{
				return this._textScale;
			}
			set
			{
				this._textScale = value;
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x0600114C RID: 4428 RVA: 0x0040C234 File Offset: 0x0040A434
		public Vector2 TextSize
		{
			get
			{
				return this._textSize;
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x0600114D RID: 4429 RVA: 0x0040C23C File Offset: 0x0040A43C
		public string Text
		{
			get
			{
				if (this._text != null)
				{
					return this._text.ToString();
				}
				return "";
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x0600114E RID: 4430 RVA: 0x0040C264 File Offset: 0x0040A464
		// (set) Token: 0x0600114F RID: 4431 RVA: 0x0040C26C File Offset: 0x0040A46C
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

		// Token: 0x06001150 RID: 4432 RVA: 0x0040C278 File Offset: 0x0040A478
		public UITextPanel(T text, float textScale = 1f, bool large = false)
		{
			this.SetText(text, textScale, large);
		}

		// Token: 0x06001151 RID: 4433 RVA: 0x0040C2B4 File Offset: 0x0040A4B4
		public override void Recalculate()
		{
			this.SetText(this._text, this._textScale, this._isLarge);
			base.Recalculate();
		}

		// Token: 0x06001152 RID: 4434 RVA: 0x0040C2D4 File Offset: 0x0040A4D4
		public void SetText(T text)
		{
			this.SetText(text, this._textScale, this._isLarge);
		}

		// Token: 0x06001153 RID: 4435 RVA: 0x0040C2EC File Offset: 0x0040A4EC
		public virtual void SetText(T text, float textScale, bool large)
		{
			Vector2 vector = new Vector2((large ? Main.fontDeathText : Main.fontMouseText).MeasureString(text.ToString()).X, large ? 32f : 16f) * textScale;
			this._text = text;
			this._textScale = textScale;
			this._textSize = vector;
			this._isLarge = large;
			this.MinWidth.Set(vector.X + this.PaddingLeft + this.PaddingRight, 0f);
			this.MinHeight.Set(vector.Y + this.PaddingTop + this.PaddingBottom, 0f);
		}

		// Token: 0x06001154 RID: 4436 RVA: 0x0040C3A0 File Offset: 0x0040A5A0
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			if (this._drawPanel)
			{
				base.DrawSelf(spriteBatch);
			}
			CalculatedStyle innerDimensions = base.GetInnerDimensions();
			Vector2 pos = innerDimensions.Position();
			if (this._isLarge)
			{
				pos.Y -= 10f * this._textScale * this._textScale;
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

		// Token: 0x040031E9 RID: 12777
		private T _text;

		// Token: 0x040031EA RID: 12778
		private float _textScale = 1f;

		// Token: 0x040031EB RID: 12779
		private Vector2 _textSize = Vector2.Zero;

		// Token: 0x040031EC RID: 12780
		private bool _isLarge;

		// Token: 0x040031ED RID: 12781
		private Color _color = Color.White;

		// Token: 0x040031EE RID: 12782
		private bool _drawPanel = true;
	}
}

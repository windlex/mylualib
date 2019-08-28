using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	// Token: 0x02000149 RID: 329
	internal class UITextBox : UITextPanel<string>
	{
		// Token: 0x060010EA RID: 4330 RVA: 0x004091CC File Offset: 0x004073CC
		public UITextBox(string text, float textScale = 1f, bool large = false) : base(text, textScale, large)
		{
		}

		// Token: 0x060010EB RID: 4331 RVA: 0x004091E0 File Offset: 0x004073E0
		public void Write(string text)
		{
			base.SetText(base.Text.Insert(this._cursor, text));
			this._cursor += text.Length;
		}

		// Token: 0x060010EC RID: 4332 RVA: 0x00409210 File Offset: 0x00407410
		public override void SetText(string text, float textScale, bool large)
		{
			if (text.ToString().Length > this._maxLength)
			{
				text = text.ToString().Substring(0, this._maxLength);
			}
			base.SetText(text, textScale, large);
			this._cursor = Math.Min(base.Text.Length, this._cursor);
		}

		// Token: 0x060010ED RID: 4333 RVA: 0x0040926C File Offset: 0x0040746C
		public void SetTextMaxLength(int maxLength)
		{
			this._maxLength = maxLength;
		}

		// Token: 0x060010EE RID: 4334 RVA: 0x00409278 File Offset: 0x00407478
		public void Backspace()
		{
			if (this._cursor == 0)
			{
				return;
			}
			base.SetText(base.Text.Substring(0, base.Text.Length - 1));
		}

		// Token: 0x060010EF RID: 4335 RVA: 0x004092A4 File Offset: 0x004074A4
		public void CursorLeft()
		{
			if (this._cursor == 0)
			{
				return;
			}
			this._cursor--;
		}

		// Token: 0x060010F0 RID: 4336 RVA: 0x004092C0 File Offset: 0x004074C0
		public void CursorRight()
		{
			if (this._cursor < base.Text.Length)
			{
				this._cursor++;
			}
		}

		// Token: 0x060010F1 RID: 4337 RVA: 0x004092E4 File Offset: 0x004074E4
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			this._cursor = base.Text.Length;
			base.DrawSelf(spriteBatch);
			this._frameCount++;
			if ((this._frameCount %= 40) > 20)
			{
				return;
			}
			CalculatedStyle innerDimensions = base.GetInnerDimensions();
			Vector2 pos = innerDimensions.Position();
			Vector2 vector = new Vector2((base.IsLarge ? Main.fontDeathText : Main.fontMouseText).MeasureString(base.Text.Substring(0, this._cursor)).X, base.IsLarge ? 32f : 16f) * base.TextScale;
			if (base.IsLarge)
			{
				pos.Y -= 8f * base.TextScale;
			}
			else
			{
				pos.Y += 2f * base.TextScale;
			}
			pos.X += (innerDimensions.Width - base.TextSize.X) * 0.5f + vector.X - (base.IsLarge ? 8f : 4f) * base.TextScale + 6f;
			if (base.IsLarge)
			{
				Utils.DrawBorderStringBig(spriteBatch, "|", pos, base.TextColor, base.TextScale, 0f, 0f, -1);
				return;
			}
			Utils.DrawBorderString(spriteBatch, "|", pos, base.TextColor, base.TextScale, 0f, 0f, -1);
		}

		// Token: 0x040031A7 RID: 12711
		private int _cursor;

		// Token: 0x040031A8 RID: 12712
		private int _frameCount;

		// Token: 0x040031A9 RID: 12713
		private int _maxLength = 20;
	}
}

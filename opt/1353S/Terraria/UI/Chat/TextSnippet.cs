using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;

namespace Terraria.UI.Chat
{
	// Token: 0x020000B5 RID: 181
	public class TextSnippet
	{
		// Token: 0x06000C62 RID: 3170 RVA: 0x003D9C30 File Offset: 0x003D7E30
		public TextSnippet(string text = "")
		{
			this.Text = text;
			this.TextOriginal = text;
		}

		// Token: 0x06000C63 RID: 3171 RVA: 0x003D9C5C File Offset: 0x003D7E5C
		public TextSnippet(string text, Color color, float scale = 1f)
		{
			this.Text = text;
			this.TextOriginal = text;
			this.Color = color;
			this.Scale = scale;
		}

		// Token: 0x06000C64 RID: 3172 RVA: 0x003D9C98 File Offset: 0x003D7E98
		public virtual void Update()
		{
		}

		// Token: 0x06000C65 RID: 3173 RVA: 0x003D9C9C File Offset: 0x003D7E9C
		public virtual void OnHover()
		{
		}

		// Token: 0x06000C66 RID: 3174 RVA: 0x003D9CA0 File Offset: 0x003D7EA0
		public virtual void OnClick()
		{
		}

		// Token: 0x06000C67 RID: 3175 RVA: 0x003D9CA4 File Offset: 0x003D7EA4
		public virtual Color GetVisibleColor()
		{
			return ChatManager.WaveColor(this.Color);
		}

		// Token: 0x06000C68 RID: 3176 RVA: 0x003D9CB4 File Offset: 0x003D7EB4
		public virtual bool UniqueDraw(bool justCheckingString, out Vector2 size, SpriteBatch spriteBatch, Vector2 position = default(Vector2), Color color = default(Color), float scale = 1f)
		{
			size = Vector2.Zero;
			return false;
		}

		// Token: 0x06000C69 RID: 3177 RVA: 0x003D9CC4 File Offset: 0x003D7EC4
		public virtual TextSnippet CopyMorph(string newText)
		{
			TextSnippet expr_0B = (TextSnippet)base.MemberwiseClone();
			expr_0B.Text = newText;
			return expr_0B;
		}

		// Token: 0x06000C6A RID: 3178 RVA: 0x003D9CD8 File Offset: 0x003D7ED8
		public virtual float GetStringLength(DynamicSpriteFont font)
		{
			return font.MeasureString(this.Text).X * this.Scale;
		}

		// Token: 0x04000F1B RID: 3867
		public string Text;

		// Token: 0x04000F1C RID: 3868
		public string TextOriginal;

		// Token: 0x04000F1D RID: 3869
		public Color Color = Color.White;

		// Token: 0x04000F1E RID: 3870
		public float Scale = 1f;

		// Token: 0x04000F1F RID: 3871
		public bool CheckForHover;

		// Token: 0x04000F20 RID: 3872
		public bool DeleteWhole;
	}
}

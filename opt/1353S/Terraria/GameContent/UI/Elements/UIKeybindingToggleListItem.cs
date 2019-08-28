using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics;
using Terraria.UI;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Elements
{
	// Token: 0x02000148 RID: 328
	public class UIKeybindingToggleListItem : UIElement
	{
		// Token: 0x060010E8 RID: 4328 RVA: 0x00408048 File Offset: 0x00406248
		public UIKeybindingToggleListItem(Func<string> getText, Func<bool> getStatus, Color color)
		{
			this._color = color;
			this._toggleTexture = TextureManager.Load("Images/UI/Settings_Toggle");
			this._TextDisplayFunction = getText != null ? getText : (Func<string>)(() => "???");
			this._IsOnFunction = getStatus != null ? getStatus : (Func<bool>)(() => false);
		}

		// Token: 0x060010E9 RID: 4329 RVA: 0x004080C8 File Offset: 0x004062C8
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			float num = 6f;
			base.DrawSelf(spriteBatch);
			CalculatedStyle dimensions = base.GetDimensions();
			float num2 = dimensions.Width + 1f;
			Vector2 arg_B1_0 = new Vector2(dimensions.X, dimensions.Y);
			bool arg_3F_0 = false;
			Vector2 baseScale = new Vector2(0.8f);
			Color color = arg_3F_0 ? Color.Gold : (base.IsMouseHovering ? Color.White : Color.Silver);
			color = Color.Lerp(color, Color.White, base.IsMouseHovering ? 0.5f : 0f);
			Color color2 = base.IsMouseHovering ? this._color : this._color.MultiplyRGBA(new Color(180, 180, 180));
			Vector2 position = arg_B1_0;
			Utils.DrawSettingsPanel(spriteBatch, position, num2, color2);
			position.X += 8f;
			position.Y += 2f + num;
			ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, this._TextDisplayFunction(), position, color, 0f, Vector2.Zero, baseScale, num2, 2f);
			position.X -= 17f;
			Rectangle rectangle = new Rectangle(this._IsOnFunction() ? ((this._toggleTexture.Width - 2) / 2 + 2) : 0, 0, (this._toggleTexture.Width - 2) / 2, this._toggleTexture.Height);
			Vector2 vector = new Vector2((float)rectangle.Width, 0f);
			position = new Vector2(dimensions.X + dimensions.Width - vector.X - 10f, dimensions.Y + 2f + num);
			spriteBatch.Draw(this._toggleTexture, position, new Rectangle?(rectangle), Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
		}

		// Token: 0x040031A3 RID: 12707
		private Color _color;

		// Token: 0x040031A5 RID: 12709
		private Func<bool> _IsOnFunction;

		// Token: 0x040031A4 RID: 12708
		private Func<string> _TextDisplayFunction;

		// Token: 0x040031A6 RID: 12710
		private Texture2D _toggleTexture;

	}
}


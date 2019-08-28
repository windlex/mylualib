using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Elements
{
	// Token: 0x02000146 RID: 326
	public class UIKeybindingSimpleListItem : UIElement
	{
		// Token: 0x060010E4 RID: 4324 RVA: 0x00407B83 File Offset: 0x00405D83
		public UIKeybindingSimpleListItem(Func<string> getText, Color color)
		{
			this._color = color;
			this._GetTextFunction = getText != null ? getText : (Func<string>)(() => "???");
		}

		// Token: 0x060010E5 RID: 4325 RVA: 0x00407BC0 File Offset: 0x00405DC0
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			float num = 6f;
			base.DrawSelf(spriteBatch);
			CalculatedStyle dimensions = base.GetDimensions();
			float num2 = dimensions.Width + 1f;
			Vector2 arg_A7_0 = new Vector2(dimensions.X, dimensions.Y);
			Vector2 baseScale = new Vector2(0.8f);
			Color color = base.IsMouseHovering ? Color.White : Color.Silver;
			color = Color.Lerp(color, Color.White, base.IsMouseHovering ? 0.5f : 0f);
			Color color2 = base.IsMouseHovering ? this._color : this._color.MultiplyRGBA(new Color(180, 180, 180));
			Vector2 position = arg_A7_0;
			Utils.DrawSettings2Panel(spriteBatch, position, num2, color2);
			position.X += 8f;
			position.Y += 2f + num;
			string text = this._GetTextFunction();
			Vector2 stringSize = ChatManager.GetStringSize(Main.fontItemStack, text, baseScale, -1f);
			position.X = dimensions.X + dimensions.Width / 2f - stringSize.X / 2f;
			ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, text, position, color, 0f, Vector2.Zero, baseScale, num2, 2f);
		}

		// Token: 0x0400319A RID: 12698
		private Color _color;

		// Token: 0x0400319B RID: 12699
		private Func<string> _GetTextFunction;

	}
}

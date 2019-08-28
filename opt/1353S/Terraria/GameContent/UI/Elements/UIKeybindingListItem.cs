using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.UI.Chat;
using Terraria.GameInput;
using Terraria.Localization;
using Terraria.UI;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Elements
{
	// Token: 0x02000145 RID: 325
	public class UIKeybindingListItem : UIElement
	{
		// Token: 0x060010DF RID: 4319 RVA: 0x00406E74 File Offset: 0x00405074
		public UIKeybindingListItem(string bind, InputMode mode, Color color)
		{
			this._keybind = bind;
			this._inputmode = mode;
			this._color = color;
			base.OnClick += new UIElement.MouseEvent(this.OnClickMethod);
		}

		// Token: 0x060010E1 RID: 4321 RVA: 0x00406EE4 File Offset: 0x004050E4
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			float num = 6f;
			base.DrawSelf(spriteBatch);
			CalculatedStyle dimensions = base.GetDimensions();
			float num2 = dimensions.Width + 1f;
			Vector2 arg_C2_0 = new Vector2(dimensions.X, dimensions.Y);
			bool flag = PlayerInput.ListeningTrigger == this._keybind;
			Vector2 baseScale = new Vector2(0.8f);
			Color color = flag ? Color.Gold : (base.IsMouseHovering ? Color.White : Color.Silver);
			color = Color.Lerp(color, Color.White, base.IsMouseHovering ? 0.5f : 0f);
			Color color2 = base.IsMouseHovering ? this._color : this._color.MultiplyRGBA(new Color(180, 180, 180));
			Vector2 vector = arg_C2_0;
			Utils.DrawSettingsPanel(spriteBatch, vector, num2, color2);
			vector.X += 8f;
			vector.Y += 2f + num;
			ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, this.GetFriendlyName(), vector, color, 0f, Vector2.Zero, baseScale, num2, 2f);
			vector.X -= 17f;
			List<string> list = PlayerInput.CurrentProfile.InputModes[this._inputmode].KeyStatus[this._keybind];
			string text = this.GenInput(list);
			if (string.IsNullOrEmpty(text))
			{
				text = Lang.menu[195].Value;
				if (!flag)
				{
					color = new Color(80, 80, 80);
				}
			}
			Vector2 stringSize = ChatManager.GetStringSize(Main.fontItemStack, text, baseScale, -1f);
			vector = new Vector2(dimensions.X + dimensions.Width - stringSize.X - 10f, dimensions.Y + 2f + num);
			if (this._inputmode == InputMode.XBoxGamepad || this._inputmode == InputMode.XBoxGamepadUI)
			{
				vector += new Vector2(0f, -3f);
			}
			GlyphTagHandler.GlyphsScale = 0.85f;
			ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, text, vector, color, 0f, Vector2.Zero, baseScale, num2, 2f);
			GlyphTagHandler.GlyphsScale = 1f;
		}

		// Token: 0x060010E2 RID: 4322 RVA: 0x00407120 File Offset: 0x00405320
		private string GenInput(List<string> list)
		{
			if (list.Count == 0)
			{
				return "";
			}
			string text = "";
			InputMode inputmode = this._inputmode;
			if (inputmode > InputMode.Mouse)
			{
				if (inputmode - InputMode.XBoxGamepad <= 1)
				{
					text = GlyphTagHandler.GenerateTag(list[0]);
					for (int i = 1; i < list.Count; i++)
					{
						text = text + "/" + GlyphTagHandler.GenerateTag(list[i]);
					}
				}
			}
			else
			{
				text = list[0];
				for (int j = 1; j < list.Count; j++)
				{
					text = text + "/" + list[j];
				}
			}
			return text;
		}

		// Token: 0x060010E3 RID: 4323 RVA: 0x004071B8 File Offset: 0x004053B8
		private string GetFriendlyName()
		{
			string keybind = this._keybind;
			switch (this._keybind)
			{
				case "MouseLeft":
					return Lang.menu[162].Value;
				case "MouseRight":
					return Lang.menu[163].Value;
				case "Up":
					return Lang.menu[148].Value;
				case "Down":
					return Lang.menu[149].Value;
				case "Left":
					return Lang.menu[150].Value;
				case "Right":
					return Lang.menu[151].Value;
				case "Jump":
					return Lang.menu[152].Value;
				case "Throw":
					return Lang.menu[153].Value;
				case "Inventory":
					return Lang.menu[154].Value;
				case "Grapple":
					return Lang.menu[155].Value;
				case "SmartSelect":
					return Lang.menu[160].Value;
				case "SmartCursor":
					return Lang.menu[161].Value;
				case "QuickMount":
					return Lang.menu[158].Value;
				case "QuickHeal":
					return Lang.menu[159].Value;
				case "QuickMana":
					return Lang.menu[156].Value;
				case "QuickBuff":
					return Lang.menu[157].Value;
				case "MapZoomIn":
					return Lang.menu[168].Value;
				case "MapZoomOut":
					return Lang.menu[169].Value;
				case "MapAlphaUp":
					return Lang.menu[171].Value;
				case "MapAlphaDown":
					return Lang.menu[170].Value;
				case "MapFull":
					return Lang.menu[173].Value;
				case "MapStyle":
					return Lang.menu[172].Value;
				case "Hotbar1":
					return Lang.menu[176].Value;
				case "Hotbar2":
					return Lang.menu[177].Value;
				case "Hotbar3":
					return Lang.menu[178].Value;
				case "Hotbar4":
					return Lang.menu[179].Value;
				case "Hotbar5":
					return Lang.menu[180].Value;
				case "Hotbar6":
					return Lang.menu[181].Value;
				case "Hotbar7":
					return Lang.menu[182].Value;
				case "Hotbar8":
					return Lang.menu[183].Value;
				case "Hotbar9":
					return Lang.menu[184].Value;
				case "Hotbar10":
					return Lang.menu[185].Value;
				case "HotbarMinus":
					return Lang.menu[174].Value;
				case "HotbarPlus":
					return Lang.menu[175].Value;
				case "DpadRadial1":
					return Lang.menu[186].Value;
				case "DpadRadial2":
					return Lang.menu[187].Value;
				case "DpadRadial3":
					return Lang.menu[188].Value;
				case "DpadRadial4":
					return Lang.menu[189].Value;
				case "RadialHotbar":
					return Lang.menu[190].Value;
				case "RadialQuickbar":
					return Lang.menu[244].Value;
				case "DpadSnap1":
					return Lang.menu[191].Value;
				case "DpadSnap2":
					return Lang.menu[192].Value;
				case "DpadSnap3":
					return Lang.menu[193].Value;
				case "DpadSnap4":
					return Lang.menu[194].Value;
				case "LockOn":
					return Lang.menu[231].Value;
				default:
					return this._keybind;
			}
		}

		// Token: 0x060010E0 RID: 4320 RVA: 0x00406EA3 File Offset: 0x004050A3
		public void OnClickMethod(UIMouseEvent evt, UIElement listeningElement)
		{
			if (PlayerInput.ListeningTrigger != this._keybind)
			{
				if (PlayerInput.CurrentProfile.AllowEditting)
				{
					PlayerInput.ListenFor(this._keybind, this._inputmode);
					return;
				}
				PlayerInput.ListenFor(null, this._inputmode);
			}
		}

		// Token: 0x04003198 RID: 12696
		private Color _color;

		// Token: 0x04003197 RID: 12695
		private InputMode _inputmode;

		// Token: 0x04003199 RID: 12697
		private string _keybind;
	}
}

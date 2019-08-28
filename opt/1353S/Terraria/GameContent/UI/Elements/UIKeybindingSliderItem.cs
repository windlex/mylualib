using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameInput;
using Terraria.Graphics;
using Terraria.UI;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Elements
{
	// Token: 0x02000147 RID: 327
	public class UIKeybindingSliderItem : UIElement
	{
		// Token: 0x060010E6 RID: 4326 RVA: 0x00407D10 File Offset: 0x00405F10
		public UIKeybindingSliderItem(Func<string> getText, Func<float> getStatus, Action<float> setStatusKeyboard, Action setStatusGamepad, int sliderIDInPage, Color color)
		{
			this._color = color;
			this._toggleTexture = TextureManager.Load("Images/UI/Settings_Toggle");
			this._TextDisplayFunction = getText != null ? getText : (Func<string>)(() => "???");
			this._GetStatusFunction = getStatus != null ? getStatus : (Func<float>)(() => 0.0f);
			this._SlideKeyboardAction = setStatusKeyboard != null ? setStatusKeyboard : (Action<float>)(s => { });
			this._SlideGamepadAction = setStatusGamepad != null ? setStatusGamepad : (Action)(() => { });
			this._sliderIDInPage = sliderIDInPage;
		}

		// Token: 0x060010E7 RID: 4327 RVA: 0x00407DF4 File Offset: 0x00405FF4
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			float num = 6f;
			base.DrawSelf(spriteBatch);
			int num2 = 0;
			IngameOptions.rightHover = -1;
			if (!Main.mouseLeft)
			{
				IngameOptions.rightLock = -1;
			}
			if (IngameOptions.rightLock == this._sliderIDInPage)
			{
				num2 = 1;
			}
			else if (IngameOptions.rightLock != -1)
			{
				num2 = 2;
			}
			CalculatedStyle dimensions = base.GetDimensions();
			float num3 = dimensions.Width + 1f;
			Vector2 arg_EB_0 = new Vector2(dimensions.X, dimensions.Y);
			bool arg_85_0 = false;
			bool flag = base.IsMouseHovering;
			if (num2 == 1)
			{
				flag = true;
			}
			if (num2 == 2)
			{
				flag = false;
			}
			Vector2 baseScale = new Vector2(0.8f);
			Color color = arg_85_0 ? Color.Gold : (flag ? Color.White : Color.Silver);
			color = Color.Lerp(color, Color.White, flag ? 0.5f : 0f);
			Color color2 = flag ? this._color : this._color.MultiplyRGBA(new Color(180, 180, 180));
			Vector2 vector = arg_EB_0;
			Utils.DrawSettingsPanel(spriteBatch, vector, num3, color2);
			vector.X += 8f;
			vector.Y += 2f + num;
			ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, this._TextDisplayFunction(), vector, color, 0f, Vector2.Zero, baseScale, num3, 2f);
			vector.X -= 17f;
			Main.colorBarTexture.Frame(1, 1, 0, 0);
			vector = new Vector2(dimensions.X + dimensions.Width - 10f, dimensions.Y + 10f + num);
			IngameOptions.valuePosition = vector;
			float obj = IngameOptions.DrawValueBar(spriteBatch, 1f, this._GetStatusFunction(), num2, null);
			if (IngameOptions.inBar || IngameOptions.rightLock == this._sliderIDInPage)
			{
				IngameOptions.rightHover = this._sliderIDInPage;
				if (PlayerInput.Triggers.Current.MouseLeft && PlayerInput.CurrentProfile.AllowEditting && !PlayerInput.UsingGamepad && IngameOptions.rightLock == this._sliderIDInPage)
				{
					this._SlideKeyboardAction(obj);
				}
			}
			if (IngameOptions.rightHover != -1 && IngameOptions.rightLock == -1)
			{
				IngameOptions.rightLock = IngameOptions.rightHover;
			}
			if (base.IsMouseHovering && PlayerInput.CurrentProfile.AllowEditting)
			{
				this._SlideGamepadAction();
			}
		}

		// Token: 0x0400319C RID: 12700
		private Color _color;

		// Token: 0x0400319E RID: 12702
		private Func<float> _GetStatusFunction;

		// Token: 0x040031A0 RID: 12704
		private Action _SlideGamepadAction;

		// Token: 0x0400319F RID: 12703
		private Action<float> _SlideKeyboardAction;

		// Token: 0x040031A1 RID: 12705
		private int _sliderIDInPage;

		// Token: 0x0400319D RID: 12701
		private Func<string> _TextDisplayFunction;

		// Token: 0x040031A2 RID: 12706
		private Texture2D _toggleTexture;

	}
}

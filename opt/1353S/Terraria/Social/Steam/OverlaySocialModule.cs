using System;
using Steamworks;
using Terraria.Social.Base;

namespace Terraria.Social.Steam
{
	// Token: 0x0200008C RID: 140
	public class OverlaySocialModule : Terraria.Social.Base.OverlaySocialModule
	{
		// Token: 0x06000AE8 RID: 2792 RVA: 0x003CC268 File Offset: 0x003CA468
		public override string GetGamepadText()
		{
			uint enteredGamepadTextLength = SteamUtils.GetEnteredGamepadTextLength();
			string result;
			SteamUtils.GetEnteredGamepadTextInput(out result, enteredGamepadTextLength);
			return result;
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x003CC219 File Offset: 0x003CA419
		public override void Initialize()
		{
			this._gamepadTextInputDismissed = Callback<GamepadTextInputDismissed_t>.Create(new Callback<GamepadTextInputDismissed_t>.DispatchDelegate(this.OnGamepadTextInputDismissed));
		}

		// Token: 0x06000AE6 RID: 2790 RVA: 0x003CC232 File Offset: 0x003CA432
		public override bool IsGamepadTextInputActive()
		{
			return this._gamepadTextInputActive;
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x003CC285 File Offset: 0x003CA485
		private void OnGamepadTextInputDismissed(GamepadTextInputDismissed_t result)
		{
			this._gamepadTextInputActive = false;
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x003CC23A File Offset: 0x003CA43A
		public override bool ShowGamepadTextInput(string description, uint maxLength, bool multiLine = false, string existingText = "", bool password = false)
		{
			if (this._gamepadTextInputActive)
			{
				return false;
			}
			bool expr_22 = SteamUtils.ShowGamepadTextInput(password ? EGamepadTextInputMode.k_EGamepadTextInputModePassword : EGamepadTextInputMode.k_EGamepadTextInputModeNormal, multiLine ? EGamepadTextInputLineMode.k_EGamepadTextInputLineModeMultipleLines : EGamepadTextInputLineMode.k_EGamepadTextInputLineModeSingleLine, description, maxLength, existingText);
			if (expr_22)
			{
				this._gamepadTextInputActive = true;
			}
			return expr_22;
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x00029F71 File Offset: 0x00028171
		public override void Shutdown()
		{
		}

		// Token: 0x04000E62 RID: 3682
		private bool _gamepadTextInputActive;

		// Token: 0x04000E61 RID: 3681
		private Callback<GamepadTextInputDismissed_t> _gamepadTextInputDismissed;
	}
}

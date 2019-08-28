using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.Graphics;
using Terraria.Initializers;
using Terraria.Localization;
using Terraria.UI;
using Terraria.UI.Gamepad;

namespace Terraria.GameContent.UI.States
{
	// Token: 0x0200013F RID: 319
	public class UIManageControls : UIState
	{
		// Token: 0x0600106E RID: 4206 RVA: 0x004007DC File Offset: 0x003FE9DC
		private void AssembleBindPanels()
		{
			List<string> bindings = new List<string>
			{
				"MouseLeft",
				"MouseRight",
				"Up",
				"Down",
				"Left",
				"Right",
				"Jump",
				"Grapple",
				"SmartSelect",
				"SmartCursor",
				"QuickMount",
				"QuickHeal",
				"QuickMana",
				"QuickBuff",
				"Throw",
				"Inventory",
				"ViewZoomIn",
				"ViewZoomOut",
				"sp9"
			};
			List<string> bindings2 = new List<string>
			{
				"MouseLeft",
				"MouseRight",
				"Up",
				"Down",
				"Left",
				"Right",
				"Jump",
				"Grapple",
				"SmartSelect",
				"SmartCursor",
				"QuickMount",
				"QuickHeal",
				"QuickMana",
				"QuickBuff",
				"LockOn",
				"Throw",
				"Inventory",
				"sp9"
			};
			List<string> bindings3 = new List<string>
			{
				"HotbarMinus",
				"HotbarPlus",
				"Hotbar1",
				"Hotbar2",
				"Hotbar3",
				"Hotbar4",
				"Hotbar5",
				"Hotbar6",
				"Hotbar7",
				"Hotbar8",
				"Hotbar9",
				"Hotbar10",
				"sp10"
			};
			List<string> bindings4 = new List<string>
			{
				"MapZoomIn",
				"MapZoomOut",
				"MapAlphaUp",
				"MapAlphaDown",
				"MapFull",
				"MapStyle",
				"sp11"
			};
			List<string> bindings5 = new List<string>
			{
				"sp1",
				"sp2",
				"RadialHotbar",
				"RadialQuickbar",
				"sp12"
			};
			List<string> bindings6 = new List<string>
			{
				"sp3",
				"sp4",
				"sp5",
				"sp6",
				"sp7",
				"sp8",
				"sp14",
				"sp15",
				"sp16",
				"sp17",
				"sp18",
				"sp19",
				"sp13"
			};
			InputMode currentInputMode = InputMode.Keyboard;
			this._bindsKeyboard.Add(this.CreateBindingGroup(0, bindings, currentInputMode));
			this._bindsKeyboard.Add(this.CreateBindingGroup(1, bindings4, currentInputMode));
			this._bindsKeyboard.Add(this.CreateBindingGroup(2, bindings3, currentInputMode));
			currentInputMode = InputMode.XBoxGamepad;
			this._bindsGamepad.Add(this.CreateBindingGroup(0, bindings2, currentInputMode));
			this._bindsGamepad.Add(this.CreateBindingGroup(1, bindings4, currentInputMode));
			this._bindsGamepad.Add(this.CreateBindingGroup(2, bindings3, currentInputMode));
			this._bindsGamepad.Add(this.CreateBindingGroup(3, bindings5, currentInputMode));
			this._bindsGamepad.Add(this.CreateBindingGroup(4, bindings6, currentInputMode));
			currentInputMode = InputMode.KeyboardUI;
			this._bindsKeyboardUI.Add(this.CreateBindingGroup(0, bindings, currentInputMode));
			this._bindsKeyboardUI.Add(this.CreateBindingGroup(1, bindings4, currentInputMode));
			this._bindsKeyboardUI.Add(this.CreateBindingGroup(2, bindings3, currentInputMode));
			currentInputMode = InputMode.XBoxGamepadUI;
			this._bindsGamepadUI.Add(this.CreateBindingGroup(0, bindings2, currentInputMode));
			this._bindsGamepadUI.Add(this.CreateBindingGroup(1, bindings4, currentInputMode));
			this._bindsGamepadUI.Add(this.CreateBindingGroup(2, bindings3, currentInputMode));
			this._bindsGamepadUI.Add(this.CreateBindingGroup(3, bindings5, currentInputMode));
			this._bindsGamepadUI.Add(this.CreateBindingGroup(4, bindings6, currentInputMode));
		}

		// Token: 0x0600106F RID: 4207 RVA: 0x00400CA8 File Offset: 0x003FEEA8
		private UISortableElement CreateBindingGroup(int elementIndex, List<string> bindings, InputMode currentInputMode)
		{
			UISortableElement uISortableElement = new UISortableElement(elementIndex);
			uISortableElement.HAlign = 0.5f;
			uISortableElement.Width.Set(0f, 1f);
			uISortableElement.Height.Set(2000f, 0f);
			UIPanel uIPanel = new UIPanel();
			uIPanel.Width.Set(0f, 1f);
			uIPanel.Height.Set(-16f, 1f);
			uIPanel.VAlign = 1f;
			uIPanel.BackgroundColor = new Color(33, 43, 79) * 0.8f;
			uISortableElement.Append(uIPanel);
			UIList uIList = new UIList();
			uIList.OverflowHidden = false;
			uIList.Width.Set(0f, 1f);
			uIList.Height.Set(-8f, 1f);
			uIList.VAlign = 1f;
			uIList.ListPadding = 5f;
			uIPanel.Append(uIList);
			Color arg_F3_0 = uIPanel.BackgroundColor;
			switch (elementIndex)
			{
				case 0:
					uIPanel.BackgroundColor = Color.Lerp(uIPanel.BackgroundColor, Color.Green, 0.18f);
					break;
				case 1:
					uIPanel.BackgroundColor = Color.Lerp(uIPanel.BackgroundColor, Color.Goldenrod, 0.18f);
					break;
				case 2:
					uIPanel.BackgroundColor = Color.Lerp(uIPanel.BackgroundColor, Color.HotPink, 0.18f);
					break;
				case 3:
					uIPanel.BackgroundColor = Color.Lerp(uIPanel.BackgroundColor, Color.Indigo, 0.18f);
					break;
				case 4:
					uIPanel.BackgroundColor = Color.Lerp(uIPanel.BackgroundColor, Color.Turquoise, 0.18f);
					break;
			}
			this.CreateElementGroup(uIList, bindings, currentInputMode, uIPanel.BackgroundColor);
			uIPanel.BackgroundColor = uIPanel.BackgroundColor.MultiplyRGBA(new Color(111, 111, 111));
			LocalizedText text = LocalizedText.Empty;
			switch (elementIndex)
			{
				case 0:
					text = ((currentInputMode == InputMode.Keyboard || currentInputMode == InputMode.XBoxGamepad) ? Lang.menu[164] : Lang.menu[243]);
					break;
				case 1:
					text = Lang.menu[165];
					break;
				case 2:
					text = Lang.menu[166];
					break;
				case 3:
					text = Lang.menu[167];
					break;
				case 4:
					text = Lang.menu[198];
					break;
			}
			UITextPanel<LocalizedText> element = new UITextPanel<LocalizedText>(text, 0.7f, false)
			{
				VAlign = 0f,
				HAlign = 0.5f
			};
			uISortableElement.Append(element);
			uISortableElement.Recalculate();
			float totalHeight = uIList.GetTotalHeight();
			uISortableElement.Width.Set(0f, 1f);
			uISortableElement.Height.Set(totalHeight + 30f + 16f, 0f);
			return uISortableElement;
		}

		// Token: 0x06001070 RID: 4208 RVA: 0x00400F6C File Offset: 0x003FF16C
		private void CreateElementGroup(UIList parent, List<string> bindings, InputMode currentInputMode, Color color)
		{
			for (int i = 0; i < bindings.Count; i++)
			{
				string arg_0E_0 = bindings[i];
				UISortableElement uISortableElement = new UISortableElement(i);
				uISortableElement.Width.Set(0f, 1f);
				uISortableElement.Height.Set(30f, 0f);
				uISortableElement.HAlign = 0.5f;
				parent.Add(uISortableElement);
				if (UIManageControls._BindingsHalfSingleLine.Contains(bindings[i]))
				{
					UIElement uIElement = this.CreatePanel(bindings[i], currentInputMode, color);
					uIElement.Width.Set(0f, 0.5f);
					uIElement.HAlign = 0.5f;
					uIElement.Height.Set(0f, 1f);
					uIElement.SetSnapPoint("Wide", UIManageControls.SnapPointIndex++, null, null);
					uISortableElement.Append(uIElement);
				}
				else if (UIManageControls._BindingsFullLine.Contains(bindings[i]))
				{
					UIElement uIElement2 = this.CreatePanel(bindings[i], currentInputMode, color);
					uIElement2.Width.Set(0f, 1f);
					uIElement2.Height.Set(0f, 1f);
					uIElement2.SetSnapPoint("Wide", UIManageControls.SnapPointIndex++, null, null);
					uISortableElement.Append(uIElement2);
				}
				else
				{
					UIElement uIElement3 = this.CreatePanel(bindings[i], currentInputMode, color);
					uIElement3.Width.Set(-5f, 0.5f);
					uIElement3.Height.Set(0f, 1f);
					uIElement3.SetSnapPoint("Thin", UIManageControls.SnapPointIndex++, null, null);
					uISortableElement.Append(uIElement3);
					i++;
					if (i < bindings.Count)
					{
						uIElement3 = this.CreatePanel(bindings[i], currentInputMode, color);
						uIElement3.Width.Set(-5f, 0.5f);
						uIElement3.Height.Set(0f, 1f);
						uIElement3.HAlign = 1f;
						uIElement3.SetSnapPoint("Thin", UIManageControls.SnapPointIndex++, null, null);
						uISortableElement.Append(uIElement3);
					}
				}
			}
		}

		// Token: 0x06001071 RID: 4209 RVA: 0x004011F0 File Offset: 0x003FF3F0
		public UIElement CreatePanel(string bind, InputMode currentInputMode, Color color)
		{
			switch (bind)
			{
				case "sp1":
					UIElement uiElement1 = (UIElement)new UIKeybindingToggleListItem((Func<string>)(() => Lang.menu[196].Value), (Func<bool>)(() =>
					{
						if (PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap1"].Contains(Buttons.DPadUp.ToString()) && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap2"].Contains(Buttons.DPadRight.ToString()) && (PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap3"].Contains(Buttons.DPadDown.ToString()) && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap4"].Contains(Buttons.DPadLeft.ToString())) && (PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap1"].Contains(Buttons.DPadUp.ToString()) && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap2"].Contains(Buttons.DPadRight.ToString()) && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap3"].Contains(Buttons.DPadDown.ToString())))
							return PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap4"].Contains(Buttons.DPadLeft.ToString());
						return false;
					}), color);
					uiElement1.OnClick += new UIElement.MouseEvent(this.SnapButtonClick);
					return uiElement1;
				case "sp2":
					UIElement uiElement2 = (UIElement)new UIKeybindingToggleListItem((Func<string>)(() => Lang.menu[197].Value), (Func<bool>)(() =>
					{
						if (PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial1"].Contains(Buttons.DPadUp.ToString()) && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial2"].Contains(Buttons.DPadRight.ToString()) && (PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial3"].Contains(Buttons.DPadDown.ToString()) && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial4"].Contains(Buttons.DPadLeft.ToString())) && (PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial1"].Contains(Buttons.DPadUp.ToString()) && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial2"].Contains(Buttons.DPadRight.ToString()) && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial3"].Contains(Buttons.DPadDown.ToString())))
							return PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial4"].Contains(Buttons.DPadLeft.ToString());
						return false;
					}), color);
					uiElement2.OnClick += new UIElement.MouseEvent(this.RadialButtonClick);
					return uiElement2;
				case "sp3":
					return (UIElement)new UIKeybindingSliderItem((Func<string>)(() => Lang.menu[199] + " (" + PlayerInput.CurrentProfile.TriggersDeadzone.ToString("P1") + ")"), (Func<float>)(() => PlayerInput.CurrentProfile.TriggersDeadzone), (Action<float>)(f => PlayerInput.CurrentProfile.TriggersDeadzone = f), (Action)(() => PlayerInput.CurrentProfile.TriggersDeadzone = UILinksInitializer.HandleSlider(PlayerInput.CurrentProfile.TriggersDeadzone, 0.0f, 0.95f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f)), 1000, color);
				case "sp4":
					return (UIElement)new UIKeybindingSliderItem((Func<string>)(() => Lang.menu[200] + " (" + PlayerInput.CurrentProfile.InterfaceDeadzoneX.ToString("P1") + ")"), (Func<float>)(() => PlayerInput.CurrentProfile.InterfaceDeadzoneX), (Action<float>)(f => PlayerInput.CurrentProfile.InterfaceDeadzoneX = f), (Action)(() => PlayerInput.CurrentProfile.InterfaceDeadzoneX = UILinksInitializer.HandleSlider(PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.0f, 0.95f, 0.35f, 0.35f)), 1001, color);
				case "sp5":
					return (UIElement)new UIKeybindingSliderItem((Func<string>)(() => Lang.menu[201] + " (" + PlayerInput.CurrentProfile.LeftThumbstickDeadzoneX.ToString("P1") + ")"), (Func<float>)(() => PlayerInput.CurrentProfile.LeftThumbstickDeadzoneX), (Action<float>)(f => PlayerInput.CurrentProfile.LeftThumbstickDeadzoneX = f), (Action)(() => PlayerInput.CurrentProfile.LeftThumbstickDeadzoneX = UILinksInitializer.HandleSlider(PlayerInput.CurrentProfile.LeftThumbstickDeadzoneX, 0.0f, 0.95f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f)), 1002, color);
				case "sp6":
					return (UIElement)new UIKeybindingSliderItem((Func<string>)(() => Lang.menu[202] + " (" + PlayerInput.CurrentProfile.LeftThumbstickDeadzoneY.ToString("P1") + ")"), (Func<float>)(() => PlayerInput.CurrentProfile.LeftThumbstickDeadzoneY), (Action<float>)(f => PlayerInput.CurrentProfile.LeftThumbstickDeadzoneY = f), (Action)(() => PlayerInput.CurrentProfile.LeftThumbstickDeadzoneY = UILinksInitializer.HandleSlider(PlayerInput.CurrentProfile.LeftThumbstickDeadzoneY, 0.0f, 0.95f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f)), 1003, color);
				case "sp7":
					return (UIElement)new UIKeybindingSliderItem((Func<string>)(() => Lang.menu[203] + " (" + PlayerInput.CurrentProfile.RightThumbstickDeadzoneX.ToString("P1") + ")"), (Func<float>)(() => PlayerInput.CurrentProfile.RightThumbstickDeadzoneX), (Action<float>)(f => PlayerInput.CurrentProfile.RightThumbstickDeadzoneX = f), (Action)(() => PlayerInput.CurrentProfile.RightThumbstickDeadzoneX = UILinksInitializer.HandleSlider(PlayerInput.CurrentProfile.RightThumbstickDeadzoneX, 0.0f, 0.95f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f)), 1004, color);
				case "sp8":
					return (UIElement)new UIKeybindingSliderItem((Func<string>)(() => Lang.menu[204] + " (" + PlayerInput.CurrentProfile.RightThumbstickDeadzoneY.ToString("P1") + ")"), (Func<float>)(() => PlayerInput.CurrentProfile.RightThumbstickDeadzoneY), (Action<float>)(f => PlayerInput.CurrentProfile.RightThumbstickDeadzoneY = f), (Action)(() => PlayerInput.CurrentProfile.RightThumbstickDeadzoneY = UILinksInitializer.HandleSlider(PlayerInput.CurrentProfile.RightThumbstickDeadzoneY, 0.0f, 0.95f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f)), 1005, color);
				case "sp9":
					UIElement uiElement3 = (UIElement)new UIKeybindingSimpleListItem((Func<string>)(() => Lang.menu[86].Value), color);
					uiElement3.OnClick += (UIElement.MouseEvent)((evt, listeningElement) =>
					{
						string copyableProfileName = UIManageControls.GetCopyableProfileName();
						PlayerInput.CurrentProfile.CopyGameplaySettingsFrom(PlayerInput.OriginalProfiles[copyableProfileName], currentInputMode);
					});
					return uiElement3;
				case "sp10":
					UIElement uiElement4 = (UIElement)new UIKeybindingSimpleListItem((Func<string>)(() => Lang.menu[86].Value), color);
					uiElement4.OnClick += (UIElement.MouseEvent)((evt, listeningElement) =>
					{
						string copyableProfileName = UIManageControls.GetCopyableProfileName();
						PlayerInput.CurrentProfile.CopyHotbarSettingsFrom(PlayerInput.OriginalProfiles[copyableProfileName], currentInputMode);
					});
					return uiElement4;
				case "sp11":
					UIElement uiElement5 = (UIElement)new UIKeybindingSimpleListItem((Func<string>)(() => Lang.menu[86].Value), color);
					uiElement5.OnClick += (UIElement.MouseEvent)((evt, listeningElement) =>
					{
						string copyableProfileName = UIManageControls.GetCopyableProfileName();
						PlayerInput.CurrentProfile.CopyMapSettingsFrom(PlayerInput.OriginalProfiles[copyableProfileName], currentInputMode);
					});
					return uiElement5;
				case "sp12":
					UIElement uiElement6 = (UIElement)new UIKeybindingSimpleListItem((Func<string>)(() => Lang.menu[86].Value), color);
					uiElement6.OnClick += (UIElement.MouseEvent)((evt, listeningElement) =>
					{
						string copyableProfileName = UIManageControls.GetCopyableProfileName();
						PlayerInput.CurrentProfile.CopyGamepadSettingsFrom(PlayerInput.OriginalProfiles[copyableProfileName], currentInputMode);
					});
					return uiElement6;
				case "sp13":
					UIElement uiElement7 = (UIElement)new UIKeybindingSimpleListItem((Func<string>)(() => Lang.menu[86].Value), color);
					uiElement7.OnClick += (UIElement.MouseEvent)((evt, listeningElement) =>
					{
						string copyableProfileName = UIManageControls.GetCopyableProfileName();
						PlayerInput.CurrentProfile.CopyGamepadAdvancedSettingsFrom(PlayerInput.OriginalProfiles[copyableProfileName], currentInputMode);
					});
					return uiElement7;
				case "sp14":
					UIElement uiElement8 = (UIElement)new UIKeybindingToggleListItem((Func<string>)(() => Lang.menu[205].Value), (Func<bool>)(() => PlayerInput.CurrentProfile.LeftThumbstickInvertX), color);
					uiElement8.OnClick += (UIElement.MouseEvent)((evt, listeningElement) =>
					{
						if (!PlayerInput.CurrentProfile.AllowEditting)
							return;
						PlayerInput.CurrentProfile.LeftThumbstickInvertX = !PlayerInput.CurrentProfile.LeftThumbstickInvertX;
					});
					return uiElement8;
				case "sp15":
					UIElement uiElement9 = (UIElement)new UIKeybindingToggleListItem((Func<string>)(() => Lang.menu[206].Value), (Func<bool>)(() => PlayerInput.CurrentProfile.LeftThumbstickInvertY), color);
					uiElement9.OnClick += (UIElement.MouseEvent)((evt, listeningElement) =>
					{
						if (!PlayerInput.CurrentProfile.AllowEditting)
							return;
						PlayerInput.CurrentProfile.LeftThumbstickInvertY = !PlayerInput.CurrentProfile.LeftThumbstickInvertY;
					});
					return uiElement9;
				case "sp16":
					UIElement uiElement10 = (UIElement)new UIKeybindingToggleListItem((Func<string>)(() => Lang.menu[207].Value), (Func<bool>)(() => PlayerInput.CurrentProfile.RightThumbstickInvertX), color);
					uiElement10.OnClick += (UIElement.MouseEvent)((evt, listeningElement) =>
					{
						if (!PlayerInput.CurrentProfile.AllowEditting)
							return;
						PlayerInput.CurrentProfile.RightThumbstickInvertX = !PlayerInput.CurrentProfile.RightThumbstickInvertX;
					});
					return uiElement10;
				case "sp17":
					UIElement uiElement11 = (UIElement)new UIKeybindingToggleListItem((Func<string>)(() => Lang.menu[208].Value), (Func<bool>)(() => PlayerInput.CurrentProfile.RightThumbstickInvertY), color);
					uiElement11.OnClick += (UIElement.MouseEvent)((evt, listeningElement) =>
					{
						if (!PlayerInput.CurrentProfile.AllowEditting)
							return;
						PlayerInput.CurrentProfile.RightThumbstickInvertY = !PlayerInput.CurrentProfile.RightThumbstickInvertY;
					});
					return uiElement11;
				case "sp18":
					return (UIElement)new UIKeybindingSliderItem((Func<string>)(() =>
					{
						int holdTimeRequired = PlayerInput.CurrentProfile.HotbarRadialHoldTimeRequired;
						if (holdTimeRequired == -1)
							return Lang.menu[228].Value;
						return Lang.menu[227] + " (" + ((float)holdTimeRequired / 60f).ToString("F2") + "s)";
					}), (Func<float>)(() =>
					{
						if (PlayerInput.CurrentProfile.HotbarRadialHoldTimeRequired == -1)
							return 1f;
						return (float)PlayerInput.CurrentProfile.HotbarRadialHoldTimeRequired / 301f;
					}), (Action<float>)(f =>
					{
						PlayerInput.CurrentProfile.HotbarRadialHoldTimeRequired = (int)((double)f * 301.0);
						if ((double)PlayerInput.CurrentProfile.HotbarRadialHoldTimeRequired != 301.0)
							return;
						PlayerInput.CurrentProfile.HotbarRadialHoldTimeRequired = -1;
					}), (Action)(() =>
					{
						PlayerInput.CurrentProfile.HotbarRadialHoldTimeRequired = (int)((double)UILinksInitializer.HandleSlider(PlayerInput.CurrentProfile.HotbarRadialHoldTimeRequired == -1 ? 1f : (float)PlayerInput.CurrentProfile.HotbarRadialHoldTimeRequired / 301f, 0.0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.5f) * 301.0);
						if ((double)PlayerInput.CurrentProfile.HotbarRadialHoldTimeRequired != 301.0)
							return;
						PlayerInput.CurrentProfile.HotbarRadialHoldTimeRequired = -1;
					}), 1007, color);
				case "sp19":
					return (UIElement)new UIKeybindingSliderItem((Func<string>)(() =>
					{
						int inventoryMoveCd = PlayerInput.CurrentProfile.InventoryMoveCD;
						return Lang.menu[252] + " (" + ((float)inventoryMoveCd / 60f).ToString("F2") + "s)";
					}), (Func<float>)(() => Utils.InverseLerp(4f, 12f, (float)PlayerInput.CurrentProfile.InventoryMoveCD, true)), (Action<float>)(f => PlayerInput.CurrentProfile.InventoryMoveCD = (int)Math.Round((double)MathHelper.Lerp(4f, 12f, f))), (Action)(() =>
					{
						if (UILinkPointNavigator.Shortcuts.INV_MOVE_OPTION_CD > 0)
							--UILinkPointNavigator.Shortcuts.INV_MOVE_OPTION_CD;
						if (UILinkPointNavigator.Shortcuts.INV_MOVE_OPTION_CD != 0)
							return;
						float currentValue = Utils.InverseLerp(4f, 12f, (float)PlayerInput.CurrentProfile.InventoryMoveCD, true);
						float num = UILinksInitializer.HandleSlider(currentValue, 0.0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.5f);
						if ((double)currentValue == (double)num)
							return;
						UILinkPointNavigator.Shortcuts.INV_MOVE_OPTION_CD = 8;
						PlayerInput.CurrentProfile.InventoryMoveCD = (int)MathHelper.Clamp((float)(PlayerInput.CurrentProfile.InventoryMoveCD + Math.Sign(num - currentValue)), 4f, 12f);
					}), 1008, color);
				default:
					return (UIElement)new UIKeybindingListItem(bind, currentInputMode, color);
			}
		}

		// Token: 0x06001087 RID: 4231 RVA: 0x00402DA6 File Offset: 0x00400FA6
		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
			this.SetupGamepadPoints(spriteBatch);
		}

		// Token: 0x06001085 RID: 4229 RVA: 0x00402D6B File Offset: 0x00400F6B
		private void FadedMouseOut(UIMouseEvent evt, UIElement listeningElement)
		{
			((UIPanel)evt.Target).BackgroundColor = new Color(63, 82, 151) * 0.7f;
		}

		// Token: 0x06001084 RID: 4228 RVA: 0x00402D36 File Offset: 0x00400F36
		private void FadedMouseOver(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(12, -1, -1, 1, 1f, 0f);
			((UIPanel)evt.Target).BackgroundColor = new Color(73, 94, 171);
		}

		// Token: 0x06001074 RID: 4212 RVA: 0x00401D58 File Offset: 0x003FFF58
		private void FillList()
		{
			List<UIElement> list = this._bindsKeyboard;
			if (!this.OnKeyboard)
			{
				list = this._bindsGamepad;
			}
			if (!this.OnGameplay)
			{
				list = (this.OnKeyboard ? this._bindsKeyboardUI : this._bindsGamepadUI);
			}
			this._uilist.Clear();
			foreach (UIElement current in list)
			{
				this._uilist.Add(current);
			}
		}

		// Token: 0x06001078 RID: 4216 RVA: 0x00402A34 File Offset: 0x00400C34
		private void GamepadButtonClick(UIMouseEvent evt, UIElement listeningElement)
		{
			this._buttonKeyboard.SetFrame(this._KeyboardGamepadTexture.Frame(2, 2, 0, 1));
			this._buttonGamepad.SetFrame(this._KeyboardGamepadTexture.Frame(2, 2, 1, 0));
			this.OnKeyboard = false;
			this.FillList();
		}

		// Token: 0x06001073 RID: 4211 RVA: 0x00401D20 File Offset: 0x003FFF20
		private static string GetCopyableProfileName()
		{
			string result = "Redigit's Pick";
			if (PlayerInput.OriginalProfiles.ContainsKey(PlayerInput.CurrentProfile.Name))
			{
				result = PlayerInput.CurrentProfile.Name;
			}
			return result;
		}

		// Token: 0x06001086 RID: 4230 RVA: 0x00402D95 File Offset: 0x00400F95
		private void GoBackClick(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.menuMode = 1127;
			IngameFancyUI.Close();
		}

		// Token: 0x06001077 RID: 4215 RVA: 0x004029E4 File Offset: 0x00400BE4
		private void KeyboardButtonClick(UIMouseEvent evt, UIElement listeningElement)
		{
			this._buttonKeyboard.SetFrame(this._KeyboardGamepadTexture.Frame(2, 2, 0, 0));
			this._buttonGamepad.SetFrame(this._KeyboardGamepadTexture.Frame(2, 2, 1, 1));
			this.OnKeyboard = true;
			this.FillList();
		}

		// Token: 0x0600107C RID: 4220 RVA: 0x00402B24 File Offset: 0x00400D24
		private void ManageBorderGamepadOff(UIMouseEvent evt, UIElement listeningElement)
		{
			this._buttonBorder1.Color = (this.OnKeyboard ? Color.Silver : Color.Black);
			this._buttonBorder2.Color = ((!this.OnKeyboard) ? Color.Silver : Color.Black);
		}

		// Token: 0x0600107B RID: 4219 RVA: 0x00402AF3 File Offset: 0x00400CF3
		private void ManageBorderGamepadOn(UIMouseEvent evt, UIElement listeningElement)
		{
			this._buttonBorder1.Color = (this.OnKeyboard ? Color.Silver : Color.Black);
			this._buttonBorder2.Color = Main.OurFavoriteColor;
		}

		// Token: 0x06001080 RID: 4224 RVA: 0x00402C33 File Offset: 0x00400E33
		private void ManageBorderGameplayOff(UIMouseEvent evt, UIElement listeningElement)
		{
			this._buttonBorderVs2.Color = ((!this.OnGameplay) ? Color.Silver : Color.Black);
			this._buttonBorderVs1.Color = (this.OnGameplay ? Color.Silver : Color.Black);
		}

		// Token: 0x0600107F RID: 4223 RVA: 0x00402C02 File Offset: 0x00400E02
		private void ManageBorderGameplayOn(UIMouseEvent evt, UIElement listeningElement)
		{
			this._buttonBorderVs2.Color = ((!this.OnGameplay) ? Color.Silver : Color.Black);
			this._buttonBorderVs1.Color = Main.OurFavoriteColor;
		}

		// Token: 0x0600107A RID: 4218 RVA: 0x00402AB3 File Offset: 0x00400CB3
		private void ManageBorderKeyboardOff(UIMouseEvent evt, UIElement listeningElement)
		{
			this._buttonBorder2.Color = ((!this.OnKeyboard) ? Color.Silver : Color.Black);
			this._buttonBorder1.Color = (this.OnKeyboard ? Color.Silver : Color.Black);
		}

		// Token: 0x06001079 RID: 4217 RVA: 0x00402A82 File Offset: 0x00400C82
		private void ManageBorderKeyboardOn(UIMouseEvent evt, UIElement listeningElement)
		{
			this._buttonBorder2.Color = ((!this.OnKeyboard) ? Color.Silver : Color.Black);
			this._buttonBorder1.Color = Main.OurFavoriteColor;
		}

		// Token: 0x06001082 RID: 4226 RVA: 0x00402CA4 File Offset: 0x00400EA4
		private void ManageBorderMenuOff(UIMouseEvent evt, UIElement listeningElement)
		{
			this._buttonBorderVs1.Color = (this.OnGameplay ? Color.Silver : Color.Black);
			this._buttonBorderVs2.Color = ((!this.OnGameplay) ? Color.Silver : Color.Black);
		}

		// Token: 0x06001081 RID: 4225 RVA: 0x00402C73 File Offset: 0x00400E73
		private void ManageBorderMenuOn(UIMouseEvent evt, UIElement listeningElement)
		{
			this._buttonBorderVs1.Color = (this.OnGameplay ? Color.Silver : Color.Black);
			this._buttonBorderVs2.Color = Main.OurFavoriteColor;
		}

		// Token: 0x06001072 RID: 4210 RVA: 0x00401C90 File Offset: 0x003FFE90
		public override void OnActivate()
		{
			if (Main.gameMenu)
			{
				this._outerContainer.Top.Set(220f, 0f);
				this._outerContainer.Height.Set(-220f, 1f);
			}
			else
			{
				this._outerContainer.Top.Set(120f, 0f);
				this._outerContainer.Height.Set(-120f, 1f);
			}
			if (PlayerInput.UsingGamepadUI)
			{
				UILinkPointNavigator.ChangePoint(3002);
			}
		}

		// Token: 0x0600106D RID: 4205 RVA: 0x003FFE60 File Offset: 0x003FE060
		public override void OnInitialize()
		{
			this._KeyboardGamepadTexture = TextureManager.Load("Images/UI/Settings_Inputs");
			this._keyboardGamepadBorderTexture = TextureManager.Load("Images/UI/Settings_Inputs_Border");
			this._GameplayVsUITexture = TextureManager.Load("Images/UI/Settings_Inputs_2");
			this._GameplayVsUIBorderTexture = TextureManager.Load("Images/UI/Settings_Inputs_2_Border");
			UIElement uIElement = new UIElement();
			uIElement.Width.Set(0f, 0.8f);
			uIElement.MaxWidth.Set(600f, 0f);
			uIElement.Top.Set(220f, 0f);
			uIElement.Height.Set(-200f, 1f);
			uIElement.HAlign = 0.5f;
			this._outerContainer = uIElement;
			UIPanel uIPanel = new UIPanel();
			uIPanel.Width.Set(0f, 1f);
			uIPanel.Height.Set(-110f, 1f);
			uIPanel.BackgroundColor = new Color(33, 43, 79) * 0.8f;
			uIElement.Append(uIPanel);
			this._buttonKeyboard = new UIImageFramed(this._KeyboardGamepadTexture, this._KeyboardGamepadTexture.Frame(2, 2, 0, 0));
			this._buttonKeyboard.VAlign = 0f;
			this._buttonKeyboard.HAlign = 0f;
			this._buttonKeyboard.Left.Set(0f, 0f);
			this._buttonKeyboard.Top.Set(8f, 0f);
			this._buttonKeyboard.OnClick += new UIElement.MouseEvent(this.KeyboardButtonClick);
			this._buttonKeyboard.OnMouseOver += new UIElement.MouseEvent(this.ManageBorderKeyboardOn);
			this._buttonKeyboard.OnMouseOut += new UIElement.MouseEvent(this.ManageBorderKeyboardOff);
			uIPanel.Append(this._buttonKeyboard);
			this._buttonGamepad = new UIImageFramed(this._KeyboardGamepadTexture, this._KeyboardGamepadTexture.Frame(2, 2, 1, 1));
			this._buttonGamepad.VAlign = 0f;
			this._buttonGamepad.HAlign = 0f;
			this._buttonGamepad.Left.Set(76f, 0f);
			this._buttonGamepad.Top.Set(8f, 0f);
			this._buttonGamepad.OnClick += new UIElement.MouseEvent(this.GamepadButtonClick);
			this._buttonGamepad.OnMouseOver += new UIElement.MouseEvent(this.ManageBorderGamepadOn);
			this._buttonGamepad.OnMouseOut += new UIElement.MouseEvent(this.ManageBorderGamepadOff);
			uIPanel.Append(this._buttonGamepad);
			this._buttonBorder1 = new UIImageFramed(this._keyboardGamepadBorderTexture, this._keyboardGamepadBorderTexture.Frame(1, 1, 0, 0));
			this._buttonBorder1.VAlign = 0f;
			this._buttonBorder1.HAlign = 0f;
			this._buttonBorder1.Left.Set(0f, 0f);
			this._buttonBorder1.Top.Set(8f, 0f);
			this._buttonBorder1.Color = Color.Silver;
			uIPanel.Append(this._buttonBorder1);
			this._buttonBorder2 = new UIImageFramed(this._keyboardGamepadBorderTexture, this._keyboardGamepadBorderTexture.Frame(1, 1, 0, 0));
			this._buttonBorder2.VAlign = 0f;
			this._buttonBorder2.HAlign = 0f;
			this._buttonBorder2.Left.Set(76f, 0f);
			this._buttonBorder2.Top.Set(8f, 0f);
			this._buttonBorder2.Color = Color.Transparent;
			uIPanel.Append(this._buttonBorder2);
			this._buttonVs1 = new UIImageFramed(this._GameplayVsUITexture, this._GameplayVsUITexture.Frame(2, 2, 0, 0));
			this._buttonVs1.VAlign = 0f;
			this._buttonVs1.HAlign = 0f;
			this._buttonVs1.Left.Set(172f, 0f);
			this._buttonVs1.Top.Set(8f, 0f);
			this._buttonVs1.OnClick += new UIElement.MouseEvent(this.VsGameplayButtonClick);
			this._buttonVs1.OnMouseOver += new UIElement.MouseEvent(this.ManageBorderGameplayOn);
			this._buttonVs1.OnMouseOut += new UIElement.MouseEvent(this.ManageBorderGameplayOff);
			uIPanel.Append(this._buttonVs1);
			this._buttonVs2 = new UIImageFramed(this._GameplayVsUITexture, this._GameplayVsUITexture.Frame(2, 2, 1, 1));
			this._buttonVs2.VAlign = 0f;
			this._buttonVs2.HAlign = 0f;
			this._buttonVs2.Left.Set(212f, 0f);
			this._buttonVs2.Top.Set(8f, 0f);
			this._buttonVs2.OnClick += new UIElement.MouseEvent(this.VsMenuButtonClick);
			this._buttonVs2.OnMouseOver += new UIElement.MouseEvent(this.ManageBorderMenuOn);
			this._buttonVs2.OnMouseOut += new UIElement.MouseEvent(this.ManageBorderMenuOff);
			uIPanel.Append(this._buttonVs2);
			this._buttonBorderVs1 = new UIImageFramed(this._GameplayVsUIBorderTexture, this._GameplayVsUIBorderTexture.Frame(1, 1, 0, 0));
			this._buttonBorderVs1.VAlign = 0f;
			this._buttonBorderVs1.HAlign = 0f;
			this._buttonBorderVs1.Left.Set(172f, 0f);
			this._buttonBorderVs1.Top.Set(8f, 0f);
			this._buttonBorderVs1.Color = Color.Silver;
			uIPanel.Append(this._buttonBorderVs1);
			this._buttonBorderVs2 = new UIImageFramed(this._GameplayVsUIBorderTexture, this._GameplayVsUIBorderTexture.Frame(1, 1, 0, 0));
			this._buttonBorderVs2.VAlign = 0f;
			this._buttonBorderVs2.HAlign = 0f;
			this._buttonBorderVs2.Left.Set(212f, 0f);
			this._buttonBorderVs2.Top.Set(8f, 0f);
			this._buttonBorderVs2.Color = Color.Transparent;
			uIPanel.Append(this._buttonBorderVs2);
			this._buttonProfile = new UIKeybindingSimpleListItem(() => { return PlayerInput.CurrentProfile.Name; }, new Color(73, 94, 171, 255) * 0.9f);
			this._buttonProfile.VAlign = 0f;
			this._buttonProfile.HAlign = 1f;
			this._buttonProfile.Width.Set(180f, 0f);
			this._buttonProfile.Height.Set(30f, 0f);
			this._buttonProfile.MarginRight = 30f;
			this._buttonProfile.Left.Set(0f, 0f);
			this._buttonProfile.Top.Set(8f, 0f);
			this._buttonProfile.OnClick += new UIElement.MouseEvent(this.profileButtonClick);
			uIPanel.Append(this._buttonProfile);
			this._uilist = new UIList();
			this._uilist.Width.Set(-25f, 1f);
			this._uilist.Height.Set(-50f, 1f);
			this._uilist.VAlign = 1f;
			this._uilist.PaddingBottom = 5f;
			this._uilist.ListPadding = 20f;
			uIPanel.Append(this._uilist);
			this.AssembleBindPanels();
			this.FillList();
			UIScrollbar uIScrollbar = new UIScrollbar();
			uIScrollbar.SetView(100f, 1000f);
			uIScrollbar.Height.Set(-67f, 1f);
			uIScrollbar.HAlign = 1f;
			uIScrollbar.VAlign = 1f;
			uIScrollbar.MarginBottom = 11f;
			uIPanel.Append(uIScrollbar);
			this._uilist.SetScrollbar(uIScrollbar);
			UITextPanel<LocalizedText> uITextPanel = new UITextPanel<LocalizedText>(Language.GetText("UI.Keybindings"), 0.7f, true);
			uITextPanel.HAlign = 0.5f;
			uITextPanel.Top.Set(-45f, 0f);
			uITextPanel.Left.Set(-10f, 0f);
			uITextPanel.SetPadding(15f);
			uITextPanel.BackgroundColor = new Color(73, 94, 171);
			uIElement.Append(uITextPanel);
			UITextPanel<LocalizedText> uITextPanel2 = new UITextPanel<LocalizedText>(Language.GetText("UI.Back"), 0.7f, true);
			uITextPanel2.Width.Set(-10f, 0.5f);
			uITextPanel2.Height.Set(50f, 0f);
			uITextPanel2.VAlign = 1f;
			uITextPanel2.HAlign = 0.5f;
			uITextPanel2.Top.Set(-45f, 0f);
			uITextPanel2.OnMouseOver += new UIElement.MouseEvent(this.FadedMouseOver);
			uITextPanel2.OnMouseOut += new UIElement.MouseEvent(this.FadedMouseOut);
			uITextPanel2.OnClick += new UIElement.MouseEvent(this.GoBackClick);
			uIElement.Append(uITextPanel2);
			this._buttonBack = uITextPanel2;
			base.Append(uIElement);
		}

		// Token: 0x06001083 RID: 4227 RVA: 0x00402CE4 File Offset: 0x00400EE4
		private void profileButtonClick(UIMouseEvent evt, UIElement listeningElement)
		{
			string name = PlayerInput.CurrentProfile.Name;
			List<string> list = PlayerInput.Profiles.Keys.ToList<string>();
			int num = list.IndexOf(name);
			num++;
			if (num >= list.Count)
			{
				num -= list.Count;
			}
			PlayerInput.SetSelectedProfile(list[num]);
		}

		// Token: 0x06001076 RID: 4214 RVA: 0x004023E8 File Offset: 0x004005E8
		private void RadialButtonClick(UIMouseEvent evt, UIElement listeningElement)
		{
			if (PlayerInput.CurrentProfile.AllowEditting)
			{
				Main.PlaySound(12, -1, -1, 1, 1f, 0f);
				if (PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial1"].Contains(Buttons.DPadUp.ToString()) && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial2"].Contains(Buttons.DPadRight.ToString()) && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial3"].Contains(Buttons.DPadDown.ToString()) && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial4"].Contains(Buttons.DPadLeft.ToString()) && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial1"].Contains(Buttons.DPadUp.ToString()) && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial2"].Contains(Buttons.DPadRight.ToString()) && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial3"].Contains(Buttons.DPadDown.ToString()) && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial4"].Contains(Buttons.DPadLeft.ToString()))
				{
					PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial1"].Clear();
					PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial2"].Clear();
					PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial3"].Clear();
					PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial4"].Clear();
					PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial1"].Clear();
					PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial2"].Clear();
					PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial3"].Clear();
					PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial4"].Clear();
					return;
				}
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap1"].Clear();
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap2"].Clear();
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap3"].Clear();
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap4"].Clear();
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap1"].Clear();
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap2"].Clear();
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap3"].Clear();
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap4"].Clear();
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial1"] = new List<string>
				{
					Buttons.DPadUp.ToString()
				};
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial2"] = new List<string>
				{
					Buttons.DPadRight.ToString()
				};
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial3"] = new List<string>
				{
					Buttons.DPadDown.ToString()
				};
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial4"] = new List<string>
				{
					Buttons.DPadLeft.ToString()
				};
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial1"] = new List<string>
				{
					Buttons.DPadUp.ToString()
				};
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial2"] = new List<string>
				{
					Buttons.DPadRight.ToString()
				};
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial3"] = new List<string>
				{
					Buttons.DPadDown.ToString()
				};
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial4"] = new List<string>
				{
					Buttons.DPadLeft.ToString()
				};
			}
		}

		// Token: 0x06001088 RID: 4232 RVA: 0x00402DB8 File Offset: 0x00400FB8
		private void SetupGamepadPoints(SpriteBatch spriteBatch)
		{
			UILinkPointNavigator.Shortcuts.BackButtonCommand = 4;
			int num = 3000;
			UILinkPointNavigator.SetPosition(num, this._buttonBack.GetInnerDimensions().ToRectangle().Center.ToVector2());
			UILinkPointNavigator.SetPosition(num + 1, this._buttonKeyboard.GetInnerDimensions().ToRectangle().Center.ToVector2());
			UILinkPointNavigator.SetPosition(num + 2, this._buttonGamepad.GetInnerDimensions().ToRectangle().Center.ToVector2());
			UILinkPointNavigator.SetPosition(num + 3, this._buttonProfile.GetInnerDimensions().ToRectangle().Center.ToVector2());
			UILinkPointNavigator.SetPosition(num + 4, this._buttonVs1.GetInnerDimensions().ToRectangle().Center.ToVector2());
			UILinkPointNavigator.SetPosition(num + 5, this._buttonVs2.GetInnerDimensions().ToRectangle().Center.ToVector2());
			int num2 = num;
			UILinkPoint expr_113 = UILinkPointNavigator.Points[num2];
			expr_113.Unlink();
			expr_113.Up = num + 6;
			num2 = num + 1;
			UILinkPoint expr_130 = UILinkPointNavigator.Points[num2];
			expr_130.Unlink();
			expr_130.Right = num + 2;
			expr_130.Down = num + 6;
			num2 = num + 2;
			UILinkPoint expr_156 = UILinkPointNavigator.Points[num2];
			expr_156.Unlink();
			expr_156.Left = num + 1;
			expr_156.Right = num + 4;
			expr_156.Down = num + 6;
			num2 = num + 4;
			UILinkPoint expr_185 = UILinkPointNavigator.Points[num2];
			expr_185.Unlink();
			expr_185.Left = num + 2;
			expr_185.Right = num + 5;
			expr_185.Down = num + 6;
			num2 = num + 5;
			UILinkPoint expr_1B4 = UILinkPointNavigator.Points[num2];
			expr_1B4.Unlink();
			expr_1B4.Left = num + 4;
			expr_1B4.Right = num + 3;
			expr_1B4.Down = num + 6;
			num2 = num + 3;
			UILinkPoint expr_1E3 = UILinkPointNavigator.Points[num2];
			expr_1E3.Unlink();
			expr_1E3.Left = num + 5;
			expr_1E3.Down = num + 6;
			float scaleFactor = 1f / Main.UIScale;
			Rectangle expr_212 = this._uilist.GetClippingRectangle(spriteBatch);
			Vector2 minimum = expr_212.TopLeft() * scaleFactor;
			Vector2 maximum = expr_212.BottomRight() * scaleFactor;
			List<SnapPoint> snapPoints = this._uilist.GetSnapPoints();
			for (int i = 0; i < snapPoints.Count; i++)
			{
				if (!snapPoints[i].Position.Between(minimum, maximum))
				{
					Vector2 arg_264_0 = snapPoints[i].Position;
					snapPoints.Remove(snapPoints[i]);
					i--;
				}
			}
			List<SnapPoint> arg_2AE_0 = snapPoints;
			Comparison<SnapPoint> arg_2AE_1;
			arg_2AE_0.Sort((x, y) => { return x.ID.CompareTo(y.ID); });
			for (int j = 0; j < snapPoints.Count; j++)
			{
				num2 = num + 6 + j;
				if (snapPoints[j].Name == "Thin")
				{
					UILinkPoint expr_2EA = UILinkPointNavigator.Points[num2];
					expr_2EA.Unlink();
					UILinkPointNavigator.SetPosition(num2, snapPoints[j].Position);
					expr_2EA.Right = num2 + 1;
					expr_2EA.Down = ((j < snapPoints.Count - 2) ? (num2 + 2) : num);
					expr_2EA.Up = ((j < 2) ? (num + 1) : ((snapPoints[j - 1].Name == "Wide") ? (num2 - 1) : (num2 - 2)));
					UILinkPointNavigator.Points[num].Up = num2;
					UILinkPointNavigator.Shortcuts.FANCYUI_HIGHEST_INDEX = num2;
					j++;
					if (j < snapPoints.Count)
					{
						num2 = num + 6 + j;
						UILinkPoint expr_396 = UILinkPointNavigator.Points[num2];
						expr_396.Unlink();
						UILinkPointNavigator.SetPosition(num2, snapPoints[j].Position);
						expr_396.Left = num2 - 1;
						expr_396.Down = ((j < snapPoints.Count - 1) ? ((snapPoints[j + 1].Name == "Wide") ? (num2 + 1) : (num2 + 2)) : num);
						expr_396.Up = ((j < 2) ? (num + 1) : (num2 - 2));
						UILinkPointNavigator.Shortcuts.FANCYUI_HIGHEST_INDEX = num2;
					}
				}
				else
				{
					UILinkPoint expr_41B = UILinkPointNavigator.Points[num2];
					expr_41B.Unlink();
					UILinkPointNavigator.SetPosition(num2, snapPoints[j].Position);
					expr_41B.Down = ((j < snapPoints.Count - 1) ? (num2 + 1) : num);
					expr_41B.Up = ((j < 1) ? (num + 1) : ((snapPoints[j - 1].Name == "Wide") ? (num2 - 1) : (num2 - 2)));
					UILinkPointNavigator.Shortcuts.FANCYUI_HIGHEST_INDEX = num2;
					UILinkPointNavigator.Points[num].Up = num2;
				}
			}
			if (UIManageControls.ForceMoveTo != -1)
			{
				UILinkPointNavigator.ChangePoint((int)MathHelper.Clamp((float)UIManageControls.ForceMoveTo, (float)num, (float)UILinkPointNavigator.Shortcuts.FANCYUI_HIGHEST_INDEX));
				UIManageControls.ForceMoveTo = -1;
			}
		}

		// Token: 0x06001075 RID: 4213 RVA: 0x00401DEC File Offset: 0x003FFFEC
		private void SnapButtonClick(UIMouseEvent evt, UIElement listeningElement)
		{
			if (PlayerInput.CurrentProfile.AllowEditting)
			{
				Main.PlaySound(12, -1, -1, 1, 1f, 0f);
				if (PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap1"].Contains(Buttons.DPadUp.ToString()) && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap2"].Contains(Buttons.DPadRight.ToString()) && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap3"].Contains(Buttons.DPadDown.ToString()) && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap4"].Contains(Buttons.DPadLeft.ToString()) && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap1"].Contains(Buttons.DPadUp.ToString()) && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap2"].Contains(Buttons.DPadRight.ToString()) && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap3"].Contains(Buttons.DPadDown.ToString()) && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap4"].Contains(Buttons.DPadLeft.ToString()))
				{
					PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap1"].Clear();
					PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap2"].Clear();
					PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap3"].Clear();
					PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap4"].Clear();
					PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap1"].Clear();
					PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap2"].Clear();
					PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap3"].Clear();
					PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap4"].Clear();
					return;
				}
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial1"].Clear();
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial2"].Clear();
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial3"].Clear();
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial4"].Clear();
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial1"].Clear();
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial2"].Clear();
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial3"].Clear();
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial4"].Clear();
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap1"] = new List<string>
				{
					Buttons.DPadUp.ToString()
				};
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap2"] = new List<string>
				{
					Buttons.DPadRight.ToString()
				};
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap3"] = new List<string>
				{
					Buttons.DPadDown.ToString()
				};
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap4"] = new List<string>
				{
					Buttons.DPadLeft.ToString()
				};
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap1"] = new List<string>
				{
					Buttons.DPadUp.ToString()
				};
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap2"] = new List<string>
				{
					Buttons.DPadRight.ToString()
				};
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap3"] = new List<string>
				{
					Buttons.DPadDown.ToString()
				};
				PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap4"] = new List<string>
				{
					Buttons.DPadLeft.ToString()
				};
			}
		}

		// Token: 0x0600107D RID: 4221 RVA: 0x00402B64 File Offset: 0x00400D64
		private void VsGameplayButtonClick(UIMouseEvent evt, UIElement listeningElement)
		{
			this._buttonVs1.SetFrame(this._GameplayVsUITexture.Frame(2, 2, 0, 0));
			this._buttonVs2.SetFrame(this._GameplayVsUITexture.Frame(2, 2, 1, 1));
			this.OnGameplay = true;
			this.FillList();
		}

		// Token: 0x0600107E RID: 4222 RVA: 0x00402BB4 File Offset: 0x00400DB4
		private void VsMenuButtonClick(UIMouseEvent evt, UIElement listeningElement)
		{
			this._buttonVs1.SetFrame(this._GameplayVsUITexture.Frame(2, 2, 0, 1));
			this._buttonVs2.SetFrame(this._GameplayVsUITexture.Frame(2, 2, 1, 0));
			this.OnGameplay = false;
			this.FillList();
		}

		// Token: 0x04003140 RID: 12608
		public static int ForceMoveTo = -1;

		// Token: 0x04003145 RID: 12613
		private bool OnGameplay = true;

		// Token: 0x04003144 RID: 12612
		private bool OnKeyboard = true;

		// Token: 0x04003141 RID: 12609
		private const float PanelTextureHeight = 30f;

		// Token: 0x0400315A RID: 12634
		private static int SnapPointIndex = 0;

		// Token: 0x04003142 RID: 12610
		private static List<string> _BindingsFullLine = new List<string>
		{
			"Throw",
			"Inventory",
			"RadialHotbar",
			"RadialQuickbar",
			"LockOn",
			"sp3",
			"sp4",
			"sp5",
			"sp6",
			"sp7",
			"sp8",
			"sp18",
			"sp19",
			"sp9",
			"sp10",
			"sp11",
			"sp12",
			"sp13"
		};

		// Token: 0x04003143 RID: 12611
		private static List<string> _BindingsHalfSingleLine = new List<string>
		{
			"sp9",
			"sp10",
			"sp11",
			"sp12",
			"sp13"
		};

		// Token: 0x04003147 RID: 12615
		private List<UIElement> _bindsGamepad = new List<UIElement>();

		// Token: 0x04003149 RID: 12617
		private List<UIElement> _bindsGamepadUI = new List<UIElement>();

		// Token: 0x04003146 RID: 12614
		private List<UIElement> _bindsKeyboard = new List<UIElement>();

		// Token: 0x04003148 RID: 12616
		private List<UIElement> _bindsKeyboardUI = new List<UIElement>();

		// Token: 0x04003151 RID: 12625
		private UIElement _buttonBack;

		// Token: 0x0400314E RID: 12622
		private UIImageFramed _buttonBorder1;

		// Token: 0x0400314F RID: 12623
		private UIImageFramed _buttonBorder2;

		// Token: 0x04003154 RID: 12628
		private UIImageFramed _buttonBorderVs1;

		// Token: 0x04003155 RID: 12629
		private UIImageFramed _buttonBorderVs2;

		// Token: 0x0400314D RID: 12621
		private UIImageFramed _buttonGamepad;

		// Token: 0x0400314C RID: 12620
		private UIImageFramed _buttonKeyboard;

		// Token: 0x04003150 RID: 12624
		private UIKeybindingSimpleListItem _buttonProfile;

		// Token: 0x04003152 RID: 12626
		private UIImageFramed _buttonVs1;

		// Token: 0x04003153 RID: 12627
		private UIImageFramed _buttonVs2;

		// Token: 0x04003159 RID: 12633
		private Texture2D _GameplayVsUIBorderTexture;

		// Token: 0x04003158 RID: 12632
		private Texture2D _GameplayVsUITexture;

		// Token: 0x04003157 RID: 12631
		private Texture2D _keyboardGamepadBorderTexture;

		// Token: 0x04003156 RID: 12630
		private Texture2D _KeyboardGamepadTexture;

		// Token: 0x0400314A RID: 12618
		private UIElement _outerContainer;

		// Token: 0x0400314B RID: 12619
		private UIList _uilist;


	}
}

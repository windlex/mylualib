using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Terraria.GameInput
{
	// Token: 0x02000103 RID: 259
	public class PlayerInputProfile
	{
		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000E43 RID: 3651 RVA: 0x003E8BE0 File Offset: 0x003E6DE0
		public bool HotbarAllowsRadial
		{
			get
			{
				return this.HotbarRadialHoldTimeRequired != -1;
			}
		}

		// Token: 0x06000E44 RID: 3652 RVA: 0x003E8BF0 File Offset: 0x003E6DF0
		public PlayerInputProfile(string name)
		{
			this.Name = name;
		}

		// Token: 0x06000E45 RID: 3653 RVA: 0x003E8C94 File Offset: 0x003E6E94
		public void Initialize(PresetProfiles style)
		{
			foreach (KeyValuePair<InputMode, KeyConfiguration> current in this.InputModes)
			{
				current.Value.SetupKeys();
				PlayerInput.Reset(current.Value, style, current.Key);
			}
		}

		// Token: 0x06000E46 RID: 3654 RVA: 0x003E8D00 File Offset: 0x003E6F00
		public bool Load(Dictionary<string, object> dict)
		{
			int num = 0;
			object obj;
			if (dict.TryGetValue("Last Launched Version", out obj))
			{
				num = (int)((long)obj);
			}
			if (dict.TryGetValue("Mouse And Keyboard", out obj))
			{
				this.InputModes[InputMode.Keyboard].ReadPreferences(JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(((JObject)obj).ToString()));
			}
			if (dict.TryGetValue("Gamepad", out obj))
			{
				this.InputModes[InputMode.XBoxGamepad].ReadPreferences(JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(((JObject)obj).ToString()));
			}
			if (dict.TryGetValue("Mouse And Keyboard UI", out obj))
			{
				this.InputModes[InputMode.KeyboardUI].ReadPreferences(JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(((JObject)obj).ToString()));
			}
			if (dict.TryGetValue("Gamepad UI", out obj))
			{
				this.InputModes[InputMode.XBoxGamepadUI].ReadPreferences(JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(((JObject)obj).ToString()));
			}
			if (num < 190)
			{
				this.InputModes[InputMode.Keyboard].KeyStatus["ViewZoomIn"] = new List<string>();
				this.InputModes[InputMode.Keyboard].KeyStatus["ViewZoomIn"].AddRange(PlayerInput.OriginalProfiles["Redigit's Pick"].InputModes[InputMode.Keyboard].KeyStatus["ViewZoomIn"]);
				this.InputModes[InputMode.Keyboard].KeyStatus["ViewZoomOut"] = new List<string>();
				this.InputModes[InputMode.Keyboard].KeyStatus["ViewZoomOut"].AddRange(PlayerInput.OriginalProfiles["Redigit's Pick"].InputModes[InputMode.Keyboard].KeyStatus["ViewZoomOut"]);
			}
			if (dict.TryGetValue("Settings", out obj))
			{
				Dictionary<string, object> expr_1D8 = JsonConvert.DeserializeObject<Dictionary<string, object>>(((JObject)obj).ToString());
				if (expr_1D8.TryGetValue("Edittable", out obj))
				{
					this.AllowEditting = (bool)obj;
				}
				if (expr_1D8.TryGetValue("Gamepad - HotbarRadialHoldTime", out obj))
				{
					this.HotbarRadialHoldTimeRequired = (int)((long)obj);
				}
				if (expr_1D8.TryGetValue("Gamepad - LeftThumbstickDeadzoneX", out obj))
				{
					this.LeftThumbstickDeadzoneX = (float)((double)obj);
				}
				if (expr_1D8.TryGetValue("Gamepad - LeftThumbstickDeadzoneY", out obj))
				{
					this.LeftThumbstickDeadzoneY = (float)((double)obj);
				}
				if (expr_1D8.TryGetValue("Gamepad - RightThumbstickDeadzoneX", out obj))
				{
					this.RightThumbstickDeadzoneX = (float)((double)obj);
				}
				if (expr_1D8.TryGetValue("Gamepad - RightThumbstickDeadzoneY", out obj))
				{
					this.RightThumbstickDeadzoneY = (float)((double)obj);
				}
				if (expr_1D8.TryGetValue("Gamepad - LeftThumbstickInvertX", out obj))
				{
					this.LeftThumbstickInvertX = (bool)obj;
				}
				if (expr_1D8.TryGetValue("Gamepad - LeftThumbstickInvertY", out obj))
				{
					this.LeftThumbstickInvertY = (bool)obj;
				}
				if (expr_1D8.TryGetValue("Gamepad - RightThumbstickInvertX", out obj))
				{
					this.RightThumbstickInvertX = (bool)obj;
				}
				if (expr_1D8.TryGetValue("Gamepad - RightThumbstickInvertY", out obj))
				{
					this.RightThumbstickInvertY = (bool)obj;
				}
				if (expr_1D8.TryGetValue("Gamepad - TriggersDeadzone", out obj))
				{
					this.TriggersDeadzone = (float)((double)obj);
				}
				if (expr_1D8.TryGetValue("Gamepad - InterfaceDeadzoneX", out obj))
				{
					this.InterfaceDeadzoneX = (float)((double)obj);
				}
				if (expr_1D8.TryGetValue("Gamepad - InventoryMoveCD", out obj))
				{
					this.InventoryMoveCD = (int)((long)obj);
				}
			}
			return true;
		}

		// Token: 0x06000E47 RID: 3655 RVA: 0x003E904C File Offset: 0x003E724C
		public Dictionary<string, object> Save()
		{
			Dictionary<string, object> arg_0B_0 = new Dictionary<string, object>();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			arg_0B_0.Add("Last Launched Version", 194);
			dictionary.Add("Edittable", this.AllowEditting);
			dictionary.Add("Gamepad - HotbarRadialHoldTime", this.HotbarRadialHoldTimeRequired);
			dictionary.Add("Gamepad - LeftThumbstickDeadzoneX", this.LeftThumbstickDeadzoneX);
			dictionary.Add("Gamepad - LeftThumbstickDeadzoneY", this.LeftThumbstickDeadzoneY);
			dictionary.Add("Gamepad - RightThumbstickDeadzoneX", this.RightThumbstickDeadzoneX);
			dictionary.Add("Gamepad - RightThumbstickDeadzoneY", this.RightThumbstickDeadzoneY);
			dictionary.Add("Gamepad - LeftThumbstickInvertX", this.LeftThumbstickInvertX);
			dictionary.Add("Gamepad - LeftThumbstickInvertY", this.LeftThumbstickInvertY);
			dictionary.Add("Gamepad - RightThumbstickInvertX", this.RightThumbstickInvertX);
			dictionary.Add("Gamepad - RightThumbstickInvertY", this.RightThumbstickInvertY);
			dictionary.Add("Gamepad - TriggersDeadzone", this.TriggersDeadzone);
			dictionary.Add("Gamepad - InterfaceDeadzoneX", this.InterfaceDeadzoneX);
			dictionary.Add("Gamepad - InventoryMoveCD", this.InventoryMoveCD);
			arg_0B_0.Add("Settings", dictionary);
			arg_0B_0.Add("Mouse And Keyboard", this.InputModes[InputMode.Keyboard].WritePreferences());
			arg_0B_0.Add("Gamepad", this.InputModes[InputMode.XBoxGamepad].WritePreferences());
			arg_0B_0.Add("Mouse And Keyboard UI", this.InputModes[InputMode.KeyboardUI].WritePreferences());
			arg_0B_0.Add("Gamepad UI", this.InputModes[InputMode.XBoxGamepadUI].WritePreferences());
			return arg_0B_0;
		}

		// Token: 0x06000E48 RID: 3656 RVA: 0x003E9214 File Offset: 0x003E7414
		public void ConditionalAddProfile(Dictionary<string, object> dicttouse, string k, InputMode nm, Dictionary<string, List<string>> dict)
		{
			if (PlayerInput.OriginalProfiles.ContainsKey(this.Name))
			{
				foreach (KeyValuePair<string, List<string>> current in PlayerInput.OriginalProfiles[this.Name].InputModes[nm].WritePreferences())
				{
					bool flag = true;
					List<string> list;
					if (dict.TryGetValue(current.Key, out list))
					{
						if (list.Count != current.Value.Count)
						{
							flag = false;
						}
						if (!flag)
						{
							for (int i = 0; i < list.Count; i++)
							{
								if (list[i] != current.Value[i])
								{
									flag = false;
									break;
								}
							}
						}
					}
					else
					{
						flag = false;
					}
					if (flag)
					{
						dict.Remove(current.Key);
					}
				}
			}
			if (dict.Count > 0)
			{
				dicttouse.Add(k, dict);
			}
		}

		// Token: 0x06000E49 RID: 3657 RVA: 0x003E9324 File Offset: 0x003E7524
		public void ConditionalAdd(Dictionary<string, object> dicttouse, string a, object b, Func<PlayerInputProfile, bool> check)
		{
			if (PlayerInput.OriginalProfiles.ContainsKey(this.Name) && check(PlayerInput.OriginalProfiles[this.Name]))
			{
				return;
			}
			dicttouse.Add(a, b);
		}

		// Token: 0x06000E4A RID: 3658 RVA: 0x003E935C File Offset: 0x003E755C
		public void CopyGameplaySettingsFrom(PlayerInputProfile profile, InputMode mode)
		{
			string[] keysToCopy = new string[]
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
				"ViewZoomOut"
			};
			this.CopyKeysFrom(profile, mode, keysToCopy);
		}

		// Token: 0x06000E4B RID: 3659 RVA: 0x003E9414 File Offset: 0x003E7614
		public void CopyHotbarSettingsFrom(PlayerInputProfile profile, InputMode mode)
		{
			string[] keysToCopy = new string[]
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
				"Hotbar10"
			};
			this.CopyKeysFrom(profile, mode, keysToCopy);
		}

		// Token: 0x06000E4C RID: 3660 RVA: 0x003E9498 File Offset: 0x003E7698
		public void CopyMapSettingsFrom(PlayerInputProfile profile, InputMode mode)
		{
			string[] keysToCopy = new string[]
			{
				"MapZoomIn",
				"MapZoomOut",
				"MapAlphaUp",
				"MapAlphaDown",
				"MapFull",
				"MapStyle"
			};
			this.CopyKeysFrom(profile, mode, keysToCopy);
		}

		// Token: 0x06000E4D RID: 3661 RVA: 0x003E94E8 File Offset: 0x003E76E8
		public void CopyGamepadSettingsFrom(PlayerInputProfile profile, InputMode mode)
		{
			string[] keysToCopy = new string[]
			{
				"RadialHotbar",
				"RadialQuickbar",
				"DpadSnap1",
				"DpadSnap2",
				"DpadSnap3",
				"DpadSnap4",
				"DpadRadial1",
				"DpadRadial2",
				"DpadRadial3",
				"DpadRadial4"
			};
			this.CopyKeysFrom(profile, InputMode.XBoxGamepad, keysToCopy);
			this.CopyKeysFrom(profile, InputMode.XBoxGamepadUI, keysToCopy);
		}

		// Token: 0x06000E4E RID: 3662 RVA: 0x003E9560 File Offset: 0x003E7760
		public void CopyGamepadAdvancedSettingsFrom(PlayerInputProfile profile, InputMode mode)
		{
			this.TriggersDeadzone = profile.TriggersDeadzone;
			this.InterfaceDeadzoneX = profile.InterfaceDeadzoneX;
			this.LeftThumbstickDeadzoneX = profile.LeftThumbstickDeadzoneX;
			this.LeftThumbstickDeadzoneY = profile.LeftThumbstickDeadzoneY;
			this.RightThumbstickDeadzoneX = profile.RightThumbstickDeadzoneX;
			this.RightThumbstickDeadzoneY = profile.RightThumbstickDeadzoneY;
			this.LeftThumbstickInvertX = profile.LeftThumbstickInvertX;
			this.LeftThumbstickInvertY = profile.LeftThumbstickInvertY;
			this.RightThumbstickInvertX = profile.RightThumbstickInvertX;
			this.RightThumbstickInvertY = profile.RightThumbstickInvertY;
			this.InventoryMoveCD = profile.InventoryMoveCD;
		}

		// Token: 0x06000E4F RID: 3663 RVA: 0x003E95F4 File Offset: 0x003E77F4
		private void CopyKeysFrom(PlayerInputProfile profile, InputMode mode, string[] keysToCopy)
		{
			for (int i = 0; i < keysToCopy.Length; i++)
			{
				List<string> collection;
				if (profile.InputModes[mode].KeyStatus.TryGetValue(keysToCopy[i], out collection))
				{
					this.InputModes[mode].KeyStatus[keysToCopy[i]].Clear();
					this.InputModes[mode].KeyStatus[keysToCopy[i]].AddRange(collection);
				}
			}
		}

		// Token: 0x06000E50 RID: 3664 RVA: 0x003E966C File Offset: 0x003E786C
		public bool UsingDpadHotbar()
		{
			return this.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial1"].Contains(Buttons.DPadUp.ToString()) && this.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial2"].Contains(Buttons.DPadRight.ToString()) && this.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial3"].Contains(Buttons.DPadDown.ToString()) && this.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadRadial4"].Contains(Buttons.DPadLeft.ToString()) && this.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial1"].Contains(Buttons.DPadUp.ToString()) && this.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial2"].Contains(Buttons.DPadRight.ToString()) && this.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial3"].Contains(Buttons.DPadDown.ToString()) && this.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadRadial4"].Contains(Buttons.DPadLeft.ToString());
		}

		// Token: 0x06000E51 RID: 3665 RVA: 0x003E9810 File Offset: 0x003E7A10
		public bool UsingDpadMovekeys()
		{
			return this.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap1"].Contains(Buttons.DPadUp.ToString()) && this.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap2"].Contains(Buttons.DPadRight.ToString()) && this.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap3"].Contains(Buttons.DPadDown.ToString()) && this.InputModes[InputMode.XBoxGamepad].KeyStatus["DpadSnap4"].Contains(Buttons.DPadLeft.ToString()) && this.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap1"].Contains(Buttons.DPadUp.ToString()) && this.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap2"].Contains(Buttons.DPadRight.ToString()) && this.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap3"].Contains(Buttons.DPadDown.ToString()) && this.InputModes[InputMode.XBoxGamepadUI].KeyStatus["DpadSnap4"].Contains(Buttons.DPadLeft.ToString());
		}

		// Token: 0x04002FA1 RID: 12193
		public Dictionary<InputMode, KeyConfiguration> InputModes = new Dictionary<InputMode, KeyConfiguration>
		{
			{
				InputMode.Keyboard,
				new KeyConfiguration()
			},
			{
				InputMode.KeyboardUI,
				new KeyConfiguration()
			},
			{
				InputMode.XBoxGamepad,
				new KeyConfiguration()
			},
			{
				InputMode.XBoxGamepadUI,
				new KeyConfiguration()
			}
		};

		// Token: 0x04002FA2 RID: 12194
		public string Name = "";

		// Token: 0x04002FA3 RID: 12195
		public bool AllowEditting = true;

		// Token: 0x04002FA4 RID: 12196
		public int HotbarRadialHoldTimeRequired = 16;

		// Token: 0x04002FA5 RID: 12197
		public float TriggersDeadzone = 0.3f;

		// Token: 0x04002FA6 RID: 12198
		public float InterfaceDeadzoneX = 0.2f;

		// Token: 0x04002FA7 RID: 12199
		public float LeftThumbstickDeadzoneX = 0.25f;

		// Token: 0x04002FA8 RID: 12200
		public float LeftThumbstickDeadzoneY = 0.4f;

		// Token: 0x04002FA9 RID: 12201
		public float RightThumbstickDeadzoneX;

		// Token: 0x04002FAA RID: 12202
		public float RightThumbstickDeadzoneY;

		// Token: 0x04002FAB RID: 12203
		public bool LeftThumbstickInvertX;

		// Token: 0x04002FAC RID: 12204
		public bool LeftThumbstickInvertY;

		// Token: 0x04002FAD RID: 12205
		public bool RightThumbstickInvertX;

		// Token: 0x04002FAE RID: 12206
		public bool RightThumbstickInvertY;

		// Token: 0x04002FAF RID: 12207
		public int InventoryMoveCD = 6;
	}
}

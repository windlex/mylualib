using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Terraria.GameContent.UI;
using Terraria.GameContent.UI.Chat;
using Terraria.GameContent.UI.States;
using Terraria.ID;
using Terraria.IO;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Gamepad;

namespace Terraria.GameInput
{
	// Token: 0x02000109 RID: 265
	public class PlayerInput
	{
		// Token: 0x06000EED RID: 3821 RVA: 0x003EC410 File Offset: 0x003EA610
		public static string BuildCommand(string CommandText, bool Last, params List<string>[] Bindings)
		{
			string text = "";
			if (Bindings.Length == 0)
			{
				return text;
			}
			text += PlayerInput.GenInput(Bindings[0]);
			for (int i = 1; i < Bindings.Length; i++)
			{
				string text2 = PlayerInput.GenInput(Bindings[i]);
				if (text2.Length > 0)
				{
					text = text + "/" + text2;
				}
			}
			if (text.Length > 0)
			{
				text = text + ": " + CommandText;
				if (!Last)
				{
					text += "   ";
				}
			}
			return text;
		}

		// Token: 0x06000EE1 RID: 3809 RVA: 0x003EA708 File Offset: 0x003E8908
		public static void CacheMousePositionForZoom()
		{
			float num = 1f;
			PlayerInput._originalMouseX = (int)((float)Main.mouseX * num);
			PlayerInput._originalMouseY = (int)((float)Main.mouseY * num);
		}

		// Token: 0x06000EE2 RID: 3810 RVA: 0x003EA737 File Offset: 0x003E8937
		private static void CacheOriginalInput()
		{
			PlayerInput._originalMouseX = Main.mouseX;
			PlayerInput._originalMouseY = Main.mouseY;
			PlayerInput._originalLastMouseX = Main.lastMouseX;
			PlayerInput._originalLastMouseY = Main.lastMouseY;
		}

		// Token: 0x06000EE3 RID: 3811 RVA: 0x003EA761 File Offset: 0x003E8961
		public static void CacheOriginalScreenDimensions()
		{
			PlayerInput._originalScreenWidth = Main.screenWidth;
			PlayerInput._originalScreenHeight = Main.screenHeight;
		}

		// Token: 0x06000EE0 RID: 3808 RVA: 0x003EA6F9 File Offset: 0x003E88F9
		public static void CacheZoomableValues()
		{
			PlayerInput.CacheOriginalInput();
			PlayerInput.CacheOriginalScreenDimensions();
		}

		// Token: 0x06000EE8 RID: 3816 RVA: 0x003EB8F4 File Offset: 0x003E9AF4
		private static bool CheckRebindingProcessGamepad(string newKey)
		{
			PlayerInput._canReleaseRebindingLock = false;
			if (PlayerInput.CurrentlyRebinding && PlayerInput._listeningInputMode == InputMode.XBoxGamepad)
			{
				PlayerInput.NavigatorRebindingLock = 3;
				PlayerInput._memoOfLastPoint = UILinkPointNavigator.CurrentPoint;
				Main.PlaySound(12, -1, -1, 1, 1f, 0f);
				if (PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus[PlayerInput.ListeningTrigger].Contains(newKey))
				{
					PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus[PlayerInput.ListeningTrigger].Remove(newKey);
				}
				else
				{
					PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].KeyStatus[PlayerInput.ListeningTrigger] = new List<string>
					{
						newKey
					};
				}
				PlayerInput.ListenFor(null, InputMode.XBoxGamepad);
			}
			if (PlayerInput.CurrentlyRebinding && PlayerInput._listeningInputMode == InputMode.XBoxGamepadUI)
			{
				PlayerInput.NavigatorRebindingLock = 3;
				PlayerInput._memoOfLastPoint = UILinkPointNavigator.CurrentPoint;
				Main.PlaySound(12, -1, -1, 1, 1f, 0f);
				if (PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus[PlayerInput.ListeningTrigger].Contains(newKey))
				{
					PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus[PlayerInput.ListeningTrigger].Remove(newKey);
				}
				else
				{
					PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI].KeyStatus[PlayerInput.ListeningTrigger] = new List<string>
					{
						newKey
					};
				}
				PlayerInput.ListenFor(null, InputMode.XBoxGamepadUI);
			}
			PlayerInput.FixDerpedRebinds();
			return PlayerInput.NavigatorRebindingLock > 0;
		}

		// Token: 0x06000EE9 RID: 3817 RVA: 0x003EBA8C File Offset: 0x003E9C8C
		private static bool CheckRebindingProcessKeyboard(string newKey)
		{
			PlayerInput._canReleaseRebindingLock = false;
			if (PlayerInput.CurrentlyRebinding && PlayerInput._listeningInputMode == InputMode.Keyboard)
			{
				PlayerInput.NavigatorRebindingLock = 3;
				PlayerInput._memoOfLastPoint = UILinkPointNavigator.CurrentPoint;
				Main.PlaySound(12, -1, -1, 1, 1f, 0f);
				if (PlayerInput.CurrentProfile.InputModes[InputMode.Keyboard].KeyStatus[PlayerInput.ListeningTrigger].Contains(newKey))
				{
					PlayerInput.CurrentProfile.InputModes[InputMode.Keyboard].KeyStatus[PlayerInput.ListeningTrigger].Remove(newKey);
				}
				else
				{
					PlayerInput.CurrentProfile.InputModes[InputMode.Keyboard].KeyStatus[PlayerInput.ListeningTrigger] = new List<string>
					{
						newKey
					};
				}
				PlayerInput.ListenFor(null, InputMode.Keyboard);
				Main.blockKey = newKey;
				Main.blockInput = false;
			}
			if (PlayerInput.CurrentlyRebinding && PlayerInput._listeningInputMode == InputMode.KeyboardUI)
			{
				PlayerInput.NavigatorRebindingLock = 3;
				PlayerInput._memoOfLastPoint = UILinkPointNavigator.CurrentPoint;
				Main.PlaySound(12, -1, -1, 1, 1f, 0f);
				if (PlayerInput.CurrentProfile.InputModes[InputMode.KeyboardUI].KeyStatus[PlayerInput.ListeningTrigger].Contains(newKey))
				{
					PlayerInput.CurrentProfile.InputModes[InputMode.KeyboardUI].KeyStatus[PlayerInput.ListeningTrigger].Remove(newKey);
				}
				else
				{
					PlayerInput.CurrentProfile.InputModes[InputMode.KeyboardUI].KeyStatus[PlayerInput.ListeningTrigger] = new List<string>
					{
						newKey
					};
				}
				PlayerInput.ListenFor(null, InputMode.KeyboardUI);
				Main.blockKey = newKey;
				Main.blockInput = false;
			}
			PlayerInput.FixDerpedRebinds();
			return PlayerInput.NavigatorRebindingLock > 0;
		}

		// Token: 0x06000EEC RID: 3820 RVA: 0x003EBEE0 File Offset: 0x003EA0E0
		public static string ComposeInstructionsForGamepad()
		{
			string text = "";
			if (!PlayerInput.UsingGamepad)
			{
				return text;
			}
			InputMode inputMode = InputMode.XBoxGamepad;
			if (Main.gameMenu || UILinkPointNavigator.Available)
			{
				inputMode = InputMode.XBoxGamepadUI;
			}
			if (PlayerInput.InBuildingMode && !Main.gameMenu)
			{
				inputMode = InputMode.XBoxGamepad;
			}
			KeyConfiguration keyConfiguration = PlayerInput.CurrentProfile.InputModes[inputMode];
			if (Main.mapFullscreen && !Main.gameMenu)
			{
				text += "          ";
				text += PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				});
				text += PlayerInput.BuildCommand(Lang.inter[118].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"]
				});
				text += PlayerInput.BuildCommand(Lang.inter[119].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				});
				if (Main.netMode == 1 && Main.player[Main.myPlayer].HasItem(2997))
				{
					text += PlayerInput.BuildCommand(Lang.inter[120].Value, false, new List<string>[]
					{
						PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]
					});
				}
			}
			else if (inputMode == InputMode.XBoxGamepadUI && !PlayerInput.InBuildingMode)
			{
				text = UILinkPointNavigator.GetInstructions();
			}
			else
			{
				if (!PlayerInput.GrappleAndInteractAreShared || (!WiresUI.Settings.DrawToolModeUI && (!Main.SmartInteractShowingGenuine || (Main.SmartInteractNPC == -1 && (Main.SmartInteractX == -1 || Main.SmartInteractY == -1)))))
				{
					text += PlayerInput.BuildCommand(Lang.misc[57].Value, false, new List<string>[]
					{
						keyConfiguration.KeyStatus["Grapple"]
					});
				}
				text += PlayerInput.BuildCommand(Lang.misc[58].Value, false, new List<string>[]
				{
					keyConfiguration.KeyStatus["Jump"]
				});
				text += PlayerInput.BuildCommand(Lang.misc[59].Value, false, new List<string>[]
				{
					keyConfiguration.KeyStatus["HotbarMinus"],
					keyConfiguration.KeyStatus["HotbarPlus"]
				});
				if (PlayerInput.InBuildingMode)
				{
					text += PlayerInput.BuildCommand(Lang.menu[6].Value, false, new List<string>[]
					{
						keyConfiguration.KeyStatus["Inventory"],
						keyConfiguration.KeyStatus["MouseRight"]
					});
				}
				if (WiresUI.Open)
				{
					text += PlayerInput.BuildCommand(Lang.misc[53].Value, false, new List<string>[]
					{
						keyConfiguration.KeyStatus["MouseLeft"]
					});
					text += PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
					{
						keyConfiguration.KeyStatus["MouseRight"]
					});
				}
				else
				{
					Item item = Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem];
					if (item.damage > 0 && item.ammo == 0)
					{
						text += PlayerInput.BuildCommand(Lang.misc[60].Value, false, new List<string>[]
						{
							keyConfiguration.KeyStatus["MouseLeft"]
						});
					}
					else if (item.createTile >= 0 || item.createWall > 0)
					{
						text += PlayerInput.BuildCommand(Lang.misc[61].Value, false, new List<string>[]
						{
							keyConfiguration.KeyStatus["MouseLeft"]
						});
					}
					else
					{
						text += PlayerInput.BuildCommand(Lang.misc[63].Value, false, new List<string>[]
						{
							keyConfiguration.KeyStatus["MouseLeft"]
						});
					}
					if (Main.SmartInteractShowingGenuine)
					{
						if (Main.SmartInteractNPC != -1)
						{
							text += PlayerInput.BuildCommand(Lang.misc[80].Value, false, new List<string>[]
							{
								keyConfiguration.KeyStatus["MouseRight"]
							});
						}
						else if (Main.SmartInteractX != -1 && Main.SmartInteractY != -1)
						{
							Tile tile = Main.tile[Main.SmartInteractX, Main.SmartInteractY];
							if (TileID.Sets.TileInteractRead[(int)tile.type])
							{
								text += PlayerInput.BuildCommand(Lang.misc[81].Value, false, new List<string>[]
								{
									keyConfiguration.KeyStatus["MouseRight"]
								});
							}
							else
							{
								text += PlayerInput.BuildCommand(Lang.misc[79].Value, false, new List<string>[]
								{
									keyConfiguration.KeyStatus["MouseRight"]
								});
							}
						}
					}
					else if (WiresUI.Settings.DrawToolModeUI)
					{
						text += PlayerInput.BuildCommand(Lang.misc[89].Value, false, new List<string>[]
						{
							keyConfiguration.KeyStatus["MouseRight"]
						});
					}
				}
			}
			return text;
		}

		// Token: 0x06000ED2 RID: 3794 RVA: 0x003E9E0C File Offset: 0x003E800C
		public static void EnterBuildingMode()
		{
			PlayerInput._InBuildingMode = true;
			PlayerInput._UIPointForBuildingMode = UILinkPointNavigator.CurrentPoint;
			Main.SmartCursorEnabled = true;
			if (Main.mouseItem.stack <= 0)
			{
				int uIPointForBuildingMode = PlayerInput._UIPointForBuildingMode;
				if (uIPointForBuildingMode < 50 && uIPointForBuildingMode >= 0 && Main.player[Main.myPlayer].inventory[uIPointForBuildingMode].stack > 0)
				{
					Utils.Swap<Item>(ref Main.mouseItem, ref Main.player[Main.myPlayer].inventory[uIPointForBuildingMode]);
				}
			}
		}

		// Token: 0x06000ED3 RID: 3795 RVA: 0x003E9E88 File Offset: 0x003E8088
		public static void ExitBuildingMode()
		{
			PlayerInput._InBuildingMode = false;
			UILinkPointNavigator.ChangePoint(PlayerInput._UIPointForBuildingMode);
			if (Main.mouseItem.stack > 0 && Main.player[Main.myPlayer].itemAnimation == 0)
			{
				int uIPointForBuildingMode = PlayerInput._UIPointForBuildingMode;
				if (uIPointForBuildingMode < 50 && uIPointForBuildingMode >= 0 && Main.player[Main.myPlayer].inventory[uIPointForBuildingMode].stack <= 0)
				{
					Utils.Swap<Item>(ref Main.mouseItem, ref Main.player[Main.myPlayer].inventory[uIPointForBuildingMode]);
				}
			}
			PlayerInput._UIPointForBuildingMode = -1;
		}

		// Token: 0x06000EE7 RID: 3815 RVA: 0x003EB79C File Offset: 0x003E999C
		private static void FixDerpedRebinds()
		{
			List<string> list = new List<string>
			{
				"MouseLeft",
				"MouseRight",
				"Inventory"
			};
			foreach (InputMode inputMode in Enum.GetValues(typeof(InputMode)))
			{
				if (inputMode != InputMode.Mouse)
				{
					foreach (string current in list)
					{
						if (PlayerInput.CurrentProfile.InputModes[inputMode].KeyStatus[current].Count < 1)
						{
							string key = "Redigit's Pick";
							if (PlayerInput.OriginalProfiles.ContainsKey(PlayerInput._selectedProfile))
							{
								key = PlayerInput._selectedProfile;
							}
							PlayerInput.CurrentProfile.InputModes[inputMode].KeyStatus[current].AddRange(PlayerInput.OriginalProfiles[key].InputModes[inputMode].KeyStatus[current]);
						}
					}
				}
			}
		}

		// Token: 0x06000EE4 RID: 3812 RVA: 0x003EA778 File Offset: 0x003E8978
		private static void GamePadInput()
		{
			bool flag = false;
			PlayerInput.ScrollWheelValue += PlayerInput.GamepadScrollValue;
			GamePadState gamePadState = default(GamePadState);
			bool flag2 = false;
			for (int i = 0; i < 4; i++)
			{
				GamePadState state = GamePad.GetState((PlayerIndex)i);
				if (state.IsConnected)
				{
					flag2 = true;
					gamePadState = state;
					break;
				}
			}
			if (!flag2)
			{
				return;
			}
			if (!Main.instance.IsActive && !Main.AllowUnfocusedInputOnGamepad)
			{
				return;
			}
			Player player = Main.player[Main.myPlayer];
			bool flag3 = UILinkPointNavigator.Available && !PlayerInput.InBuildingMode;
			InputMode inputMode = InputMode.XBoxGamepad;
			if ((Main.gameMenu | flag3) || player.talkNPC != -1 || player.sign != -1 || IngameFancyUI.CanCover())
			{
				inputMode = InputMode.XBoxGamepadUI;
			}
			if (!Main.gameMenu && PlayerInput.InBuildingMode)
			{
				inputMode = InputMode.XBoxGamepad;
			}
			if (PlayerInput.CurrentInputMode == InputMode.XBoxGamepad && inputMode == InputMode.XBoxGamepadUI)
			{
				flag = true;
			}
			if (PlayerInput.CurrentInputMode == InputMode.XBoxGamepadUI && inputMode == InputMode.XBoxGamepad)
			{
				flag = true;
			}
			if (flag)
			{
				PlayerInput.CurrentInputMode = inputMode;
			}
			KeyConfiguration keyConfiguration = PlayerInput.CurrentProfile.InputModes[inputMode];
			int num = 2145386496;
			for (int j = 0; j < PlayerInput.ButtonsGamepad.Length; j++)
			{
				if ((num & (int)PlayerInput.ButtonsGamepad[j]) <= 0 && gamePadState.IsButtonDown(PlayerInput.ButtonsGamepad[j]))
				{
					if (PlayerInput.CheckRebindingProcessGamepad(PlayerInput.ButtonsGamepad[j].ToString()))
					{
						return;
					}
					keyConfiguration.Processkey(PlayerInput.Triggers.Current, PlayerInput.ButtonsGamepad[j].ToString());
					flag = true;
				}
			}
			PlayerInput.GamepadThumbstickLeft = gamePadState.ThumbSticks.Left * new Vector2(1f, -1f) * new Vector2((float)(PlayerInput.CurrentProfile.LeftThumbstickInvertX.ToDirectionInt() * -1), (float)(PlayerInput.CurrentProfile.LeftThumbstickInvertY.ToDirectionInt() * -1));
			PlayerInput.GamepadThumbstickRight = gamePadState.ThumbSticks.Right * new Vector2(1f, -1f) * new Vector2((float)(PlayerInput.CurrentProfile.RightThumbstickInvertX.ToDirectionInt() * -1), (float)(PlayerInput.CurrentProfile.RightThumbstickInvertY.ToDirectionInt() * -1));
			Vector2 gamepadThumbstickRight = PlayerInput.GamepadThumbstickRight;
			Vector2 gamepadThumbstickLeft = PlayerInput.GamepadThumbstickLeft;
			Vector2 vector = gamepadThumbstickRight;
			if (vector != Vector2.Zero)
			{
				vector.Normalize();
			}
			Vector2 vector2 = gamepadThumbstickLeft;
			if (vector2 != Vector2.Zero)
			{
				vector2.Normalize();
			}
			float num2 = 0.6f;
			float triggersDeadzone = PlayerInput.CurrentProfile.TriggersDeadzone;
			if (inputMode == InputMode.XBoxGamepadUI)
			{
				num2 = 0.4f;
				if (PlayerInput.GamepadAllowScrolling)
				{
					PlayerInput.GamepadScrollValue -= (int)(gamepadThumbstickRight.Y * 16f);
				}
				PlayerInput.GamepadAllowScrolling = false;
			}
			if (Vector2.Dot(-Vector2.UnitX, vector2) >= num2 && gamepadThumbstickLeft.X < -PlayerInput.CurrentProfile.LeftThumbstickDeadzoneX)
			{
				if (PlayerInput.CheckRebindingProcessGamepad(Buttons.LeftThumbstickLeft.ToString()))
				{
					return;
				}
				keyConfiguration.Processkey(PlayerInput.Triggers.Current, Buttons.LeftThumbstickLeft.ToString());
				flag = true;
			}
			if (Vector2.Dot(Vector2.UnitX, vector2) >= num2 && gamepadThumbstickLeft.X > PlayerInput.CurrentProfile.LeftThumbstickDeadzoneX)
			{
				if (PlayerInput.CheckRebindingProcessGamepad(Buttons.LeftThumbstickRight.ToString()))
				{
					return;
				}
				keyConfiguration.Processkey(PlayerInput.Triggers.Current, Buttons.LeftThumbstickRight.ToString());
				flag = true;
			}
			if (Vector2.Dot(-Vector2.UnitY, vector2) >= num2 && gamepadThumbstickLeft.Y < -PlayerInput.CurrentProfile.LeftThumbstickDeadzoneY)
			{
				if (PlayerInput.CheckRebindingProcessGamepad(Buttons.LeftThumbstickUp.ToString()))
				{
					return;
				}
				keyConfiguration.Processkey(PlayerInput.Triggers.Current, Buttons.LeftThumbstickUp.ToString());
				flag = true;
			}
			if (Vector2.Dot(Vector2.UnitY, vector2) >= num2 && gamepadThumbstickLeft.Y > PlayerInput.CurrentProfile.LeftThumbstickDeadzoneY)
			{
				if (PlayerInput.CheckRebindingProcessGamepad(Buttons.LeftThumbstickDown.ToString()))
				{
					return;
				}
				keyConfiguration.Processkey(PlayerInput.Triggers.Current, Buttons.LeftThumbstickDown.ToString());
				flag = true;
			}
			if (Vector2.Dot(-Vector2.UnitX, vector) >= num2 && gamepadThumbstickRight.X < -PlayerInput.CurrentProfile.RightThumbstickDeadzoneX)
			{
				if (PlayerInput.CheckRebindingProcessGamepad(Buttons.RightThumbstickLeft.ToString()))
				{
					return;
				}
				keyConfiguration.Processkey(PlayerInput.Triggers.Current, Buttons.RightThumbstickLeft.ToString());
				flag = true;
			}
			if (Vector2.Dot(Vector2.UnitX, vector) >= num2 && gamepadThumbstickRight.X > PlayerInput.CurrentProfile.RightThumbstickDeadzoneX)
			{
				if (PlayerInput.CheckRebindingProcessGamepad(Buttons.RightThumbstickRight.ToString()))
				{
					return;
				}
				keyConfiguration.Processkey(PlayerInput.Triggers.Current, Buttons.RightThumbstickRight.ToString());
				flag = true;
			}
			if (Vector2.Dot(-Vector2.UnitY, vector) >= num2 && gamepadThumbstickRight.Y < -PlayerInput.CurrentProfile.RightThumbstickDeadzoneY)
			{
				if (PlayerInput.CheckRebindingProcessGamepad(Buttons.RightThumbstickUp.ToString()))
				{
					return;
				}
				keyConfiguration.Processkey(PlayerInput.Triggers.Current, Buttons.RightThumbstickUp.ToString());
				flag = true;
			}
			if (Vector2.Dot(Vector2.UnitY, vector) >= num2 && gamepadThumbstickRight.Y > PlayerInput.CurrentProfile.RightThumbstickDeadzoneY)
			{
				if (PlayerInput.CheckRebindingProcessGamepad(Buttons.RightThumbstickDown.ToString()))
				{
					return;
				}
				keyConfiguration.Processkey(PlayerInput.Triggers.Current, Buttons.RightThumbstickDown.ToString());
				flag = true;
			}
			if (gamePadState.Triggers.Left > triggersDeadzone)
			{
				if (PlayerInput.CheckRebindingProcessGamepad(Buttons.LeftTrigger.ToString()))
				{
					return;
				}
				keyConfiguration.Processkey(PlayerInput.Triggers.Current, Buttons.LeftTrigger.ToString());
				flag = true;
			}
			if (gamePadState.Triggers.Right > triggersDeadzone)
			{
				if (PlayerInput.CheckRebindingProcessGamepad(Buttons.RightTrigger.ToString()))
				{
					return;
				}
				keyConfiguration.Processkey(PlayerInput.Triggers.Current, Buttons.RightTrigger.ToString());
				flag = true;
			}
			bool flag4 = ItemID.Sets.GamepadWholeScreenUseRange[player.inventory[player.selectedItem].type] || player.scope;
			int num3 = player.inventory[player.selectedItem].tileBoost + ItemID.Sets.GamepadExtraRange[player.inventory[player.selectedItem].type];
			if (player.yoyoString && ItemID.Sets.Yoyo[player.inventory[player.selectedItem].type])
			{
				num3 += 5;
			}
			else if (player.inventory[player.selectedItem].createTile < 0 && player.inventory[player.selectedItem].createWall <= 0 && player.inventory[player.selectedItem].shoot > 0)
			{
				num3 += 10;
			}
			else if (player.controlTorch)
			{
				num3++;
			}
			if (flag4)
			{
				num3 += 30;
			}
			if (player.mount.Active && player.mount.Type == 8)
			{
				num3 = 10;
			}
			bool flag5 = false;
			bool flag6 = !Main.gameMenu && !flag3 && Main.SmartCursorEnabled;
			if (!PlayerInput.CursorIsBusy)
			{
				bool flag7 = Main.mapFullscreen || (!Main.gameMenu && !flag3);
				int num4 = Main.screenWidth / 2;
				int num5 = Main.screenHeight / 2;
				if ((!Main.mapFullscreen & flag7) && !flag4)
				{
					Point expr_81B = Main.ReverseGravitySupport(player.Center - Main.screenPosition, 0f).ToPoint();
					num4 = expr_81B.X;
					num5 = expr_81B.Y;
				}
				if ((player.velocity == Vector2.Zero && gamepadThumbstickLeft == Vector2.Zero && gamepadThumbstickRight == Vector2.Zero) & flag6)
				{
					num4 += player.direction * 10;
				}
				if (gamepadThumbstickRight != Vector2.Zero & flag7)
				{
					Vector2 vector3 = new Vector2(8f);
					if (!Main.gameMenu && Main.mapFullscreen)
					{
						vector3 = new Vector2(16f);
					}
					if (flag6)
					{
						vector3 = new Vector2((float)(Player.tileRangeX * 16), (float)(Player.tileRangeY * 16));
						if (num3 != 0)
						{
							vector3 += new Vector2((float)(num3 * 16), (float)(num3 * 16));
						}
						if (flag4)
						{
							vector3 = new Vector2((float)(Math.Max(Main.screenWidth, Main.screenHeight) / 2));
						}
					}
					else if (!Main.mapFullscreen)
					{
						if (player.inventory[player.selectedItem].mech)
						{
							vector3 += Vector2.Zero;
						}
						else
						{
							vector3 += new Vector2((float)num3) / 4f;
						}
					}
					float m = Main.GameViewMatrix.ZoomMatrix.M11;
					Vector2 vector4 = gamepadThumbstickRight * vector3 * m;
					int num6 = PlayerInput.MouseX - num4;
					int num7 = PlayerInput.MouseY - num5;
					if (flag6)
					{
						num6 = 0;
						num7 = 0;
					}
					num6 += (int)vector4.X;
					num7 += (int)vector4.Y;
					PlayerInput.MouseX = num6 + num4;
					PlayerInput.MouseY = num7 + num5;
					flag = true;
					flag5 = true;
				}
				if (gamepadThumbstickLeft != Vector2.Zero & flag7)
				{
					float scaleFactor = 8f;
					if (!Main.gameMenu && Main.mapFullscreen)
					{
						scaleFactor = 3f;
					}
					if (Main.mapFullscreen)
					{
						Vector2 value = gamepadThumbstickLeft * scaleFactor;
						Main.mapFullscreenPos += value * scaleFactor * (1f / Main.mapFullscreenScale);
					}
					else if (!flag5 && Main.SmartCursorEnabled)
					{
						float m2 = Main.GameViewMatrix.ZoomMatrix.M11;
						Vector2 vector5 = gamepadThumbstickLeft * new Vector2((float)(Player.tileRangeX * 16), (float)(Player.tileRangeY * 16)) * m2;
						if (num3 != 0)
						{
							vector5 = gamepadThumbstickLeft * new Vector2((float)((Player.tileRangeX + num3) * 16), (float)((Player.tileRangeY + num3) * 16)) * m2;
						}
						if (flag4)
						{
							vector5 = new Vector2((float)(Math.Max(Main.screenWidth, Main.screenHeight) / 2)) * gamepadThumbstickLeft;
						}
						int arg_ADD_0 = (int)vector5.X;
						int num8 = (int)vector5.Y;
						PlayerInput.MouseX = arg_ADD_0 + num4;
						PlayerInput.MouseY = num8 + num5;
					}
					flag = true;
				}
				if (PlayerInput.CurrentInputMode == InputMode.XBoxGamepad)
				{
					PlayerInput.HandleDpadSnap();
					int num9 = PlayerInput.MouseX - num4;
					int num10 = PlayerInput.MouseY - num5;
					if (!Main.gameMenu && !flag3)
					{
						if (flag4 && !Main.mapFullscreen)
						{
							float num11 = 1f;
							int num12 = Main.screenWidth / 2;
							int num13 = Main.screenHeight / 2;
							num9 = (int)Utils.Clamp<float>((float)num9, (float)(-(float)num12) * num11, (float)num12 * num11);
							num10 = (int)Utils.Clamp<float>((float)num10, (float)(-(float)num13) * num11, (float)num13 * num11);
						}
						else
						{
							float m3 = Main.GameViewMatrix.ZoomMatrix.M11;
							num9 = (int)Utils.Clamp<float>((float)num9, (float)(-(float)(Player.tileRangeX + num3) * 16) * m3, (float)((Player.tileRangeX + num3) * 16) * m3);
							num10 = (int)Utils.Clamp<float>((float)num10, (float)(-(float)(Player.tileRangeY + num3) * 16) * m3, (float)((Player.tileRangeY + num3) * 16) * m3);
						}
						if (flag6 && (!flag | flag4))
						{
							float num14 = 0.81f;
							if (flag4)
							{
								num14 = 0.95f;
							}
							num9 = (int)((float)num9 * num14);
							num10 = (int)((float)num10 * num14);
						}
					}
					else
					{
						num9 = Utils.Clamp<int>(num9, -num4 + 10, num4 - 10);
						num10 = Utils.Clamp<int>(num10, -num5 + 10, num5 - 10);
					}
					PlayerInput.MouseX = num9 + num4;
					PlayerInput.MouseY = num10 + num5;
				}
			}
			if (flag)
			{
				PlayerInput.CurrentInputMode = inputMode;
			}
			if (PlayerInput.CurrentInputMode == InputMode.XBoxGamepad)
			{
				Main.SetCameraGamepadLerp(0.1f);
			}
		}

		// Token: 0x06000EEE RID: 3822 RVA: 0x003EC48C File Offset: 0x003EA68C
		private static string GenInput(List<string> list)
		{
			if (list.Count == 0)
			{
				return "";
			}
			string text = GlyphTagHandler.GenerateTag(list[0]);
			for (int i = 1; i < list.Count; i++)
			{
				text = text + "/" + GlyphTagHandler.GenerateTag(list[i]);
			}
			return text;
		}

		// Token: 0x06000EEB RID: 3819 RVA: 0x003EBD2C File Offset: 0x003E9F2C
		private static void HandleDpadSnap()
		{
			Vector2 value = Vector2.Zero;
			Player player = Main.player[Main.myPlayer];
			for (int i = 0; i < 4; i++)
			{
				bool flag = false;
				Vector2 value2 = Vector2.Zero;
				if (Main.gameMenu || (UILinkPointNavigator.Available && !PlayerInput.InBuildingMode))
				{
					return;
				}
				switch (i)
				{
					case 0:
						flag = PlayerInput.Triggers.Current.DpadMouseSnap1;
						value2 = -Vector2.UnitY;
						break;
					case 1:
						flag = PlayerInput.Triggers.Current.DpadMouseSnap2;
						value2 = Vector2.UnitX;
						break;
					case 2:
						flag = PlayerInput.Triggers.Current.DpadMouseSnap3;
						value2 = Vector2.UnitY;
						break;
					case 3:
						flag = PlayerInput.Triggers.Current.DpadMouseSnap4;
						value2 = -Vector2.UnitX;
						break;
				}
				if (PlayerInput.DpadSnapCooldown[i] > 0)
				{
					PlayerInput.DpadSnapCooldown[i]--;
				}
				if (flag)
				{
					if (PlayerInput.DpadSnapCooldown[i] == 0)
					{
						int num = 6;
						if (ItemSlot.IsABuildingItem(player.inventory[player.selectedItem]))
						{
							num = player.inventory[player.selectedItem].useTime;
						}
						PlayerInput.DpadSnapCooldown[i] = num;
						value += value2;
					}
				}
				else
				{
					PlayerInput.DpadSnapCooldown[i] = 0;
				}
			}
			if (value != Vector2.Zero)
			{
				Main.SmartCursorEnabled = false;
				Point expr_170 = (Main.MouseScreen + Main.screenPosition + value * new Vector2(16f)).ToTileCoordinates();
				PlayerInput.MouseX = expr_170.X * 16 + 8 - (int)Main.screenPosition.X;
				PlayerInput.MouseY = expr_170.Y * 16 + 8 - (int)Main.screenPosition.Y;
			}
		}

		// Token: 0x06000ED9 RID: 3801 RVA: 0x003EA10F File Offset: 0x003E830F
		public static void Hook_OnEnterWorld(Player player)
		{
			if (PlayerInput.UsingGamepad && player.whoAmI == Main.myPlayer)
			{
				Main.SmartCursorEnabled = true;
			}
		}

		// Token: 0x06000ED8 RID: 3800 RVA: 0x003E9F8C File Offset: 0x003E818C
		public static void Initialize()
		{
			Main.InputProfiles.OnProcessText += new Preferences.TextProcessAction(PlayerInput.PrettyPrintProfiles);
			Player.Hooks.OnEnterWorld += new Action<Player>(PlayerInput.Hook_OnEnterWorld);
			PlayerInputProfile playerInputProfile = new PlayerInputProfile("Redigit's Pick");
			playerInputProfile.Initialize(PresetProfiles.Redigit);
			PlayerInput.Profiles.Add(playerInputProfile.Name, playerInputProfile);
			playerInputProfile = new PlayerInputProfile("Yoraiz0r's Pick");
			playerInputProfile.Initialize(PresetProfiles.Yoraiz0r);
			PlayerInput.Profiles.Add(playerInputProfile.Name, playerInputProfile);
			playerInputProfile = new PlayerInputProfile("Console (Playstation)");
			playerInputProfile.Initialize(PresetProfiles.ConsolePS);
			PlayerInput.Profiles.Add(playerInputProfile.Name, playerInputProfile);
			playerInputProfile = new PlayerInputProfile("Console (Xbox)");
			playerInputProfile.Initialize(PresetProfiles.ConsoleXBox);
			PlayerInput.Profiles.Add(playerInputProfile.Name, playerInputProfile);
			playerInputProfile = new PlayerInputProfile("Custom");
			playerInputProfile.Initialize(PresetProfiles.Redigit);
			PlayerInput.Profiles.Add(playerInputProfile.Name, playerInputProfile);
			playerInputProfile = new PlayerInputProfile("Redigit's Pick");
			playerInputProfile.Initialize(PresetProfiles.Redigit);
			PlayerInput.OriginalProfiles.Add(playerInputProfile.Name, playerInputProfile);
			playerInputProfile = new PlayerInputProfile("Yoraiz0r's Pick");
			playerInputProfile.Initialize(PresetProfiles.Yoraiz0r);
			PlayerInput.OriginalProfiles.Add(playerInputProfile.Name, playerInputProfile);
			playerInputProfile = new PlayerInputProfile("Console (Playstation)");
			playerInputProfile.Initialize(PresetProfiles.ConsolePS);
			PlayerInput.OriginalProfiles.Add(playerInputProfile.Name, playerInputProfile);
			playerInputProfile = new PlayerInputProfile("Console (Xbox)");
			playerInputProfile.Initialize(PresetProfiles.ConsoleXBox);
			PlayerInput.OriginalProfiles.Add(playerInputProfile.Name, playerInputProfile);
			PlayerInput.SetSelectedProfile("Custom");
			PlayerInput.Triggers.Initialize();
		}

		// Token: 0x06000ECF RID: 3791 RVA: 0x003E9CD4 File Offset: 0x003E7ED4
		private static bool InvalidateKeyboardSwap()
		{
			if (PlayerInput._invalidatorCheck.Length == 0)
			{
				return false;
			}
			string text = "";
			Keys[] pressedKeys = Main.keyState.GetPressedKeys();
			for (int i = 0; i < pressedKeys.Length; i++)
			{
				Keys keys = pressedKeys[i];
				text = text + keys.ToString() + ", ";
			}
			if (text == PlayerInput._invalidatorCheck)
			{
				return true;
			}
			PlayerInput._invalidatorCheck = "";
			return false;
		}

		// Token: 0x06000EE6 RID: 3814 RVA: 0x003EB55C File Offset: 0x003E975C
		private static void KeyboardInput()
		{
			bool flag = false;
			bool flag2 = false;
			Keys[] pressedKeys = Main.keyState.GetPressedKeys();
			if (PlayerInput.InvalidateKeyboardSwap() && PlayerInput.MouseKeys.Count == 0)
			{
				return;
			}
			for (int i = 0; i < pressedKeys.Length; i++)
			{
				if (pressedKeys[i] == Keys.LeftShift || pressedKeys[i] == Keys.RightShift)
				{
					flag = true;
				}
				else if (pressedKeys[i] == Keys.LeftAlt || pressedKeys[i] == Keys.RightAlt)
				{
					flag2 = true;
				}
			}
            for (int k = (int)Keys.F1; k <= (int)Keys.F12; k++)
            {
                if (Main.keyState.IsKeyDown((Keys)k))
                    EventCenter.FireKeyEvent(EventID.Key_Fn, k);
            }
            if (Main.blockKey != Keys.None.ToString())
            {
                bool flag3 = false;
                for (int j = 0; j < pressedKeys.Length; j++)
                {
                    if (pressedKeys[j].ToString() == Main.blockKey)
                    {
                        pressedKeys[j] = Keys.None;
                        flag3 = true;
                    }
                }
                if (!flag3)
                {
                    Main.blockKey = Keys.None.ToString();
                }
            }
			KeyConfiguration keyConfiguration = PlayerInput.CurrentProfile.InputModes[InputMode.Keyboard];
			if (Main.gameMenu && !PlayerInput.WritingText)
			{
				keyConfiguration = PlayerInput.CurrentProfile.InputModes[InputMode.KeyboardUI];
			}
			List<string> list = new List<string>(pressedKeys.Length);
			for (int k = 0; k < pressedKeys.Length; k++)
			{
				list.Add(pressedKeys[k].ToString());
			}
			if (PlayerInput.WritingText)
			{
				list.Clear();
			}
			int count = list.Count;
			list.AddRange(PlayerInput.MouseKeys);
			bool flag4 = false;
			for (int l = 0; l < list.Count; l++)
			{
				string newKey = list[l].ToString();
				if (!(list[l] == Keys.Tab.ToString()) || !((flag && SocialAPI.Mode == SocialMode.Steam) | flag2))
				{
					if (PlayerInput.CheckRebindingProcessKeyboard(newKey))
					{
						return;
					}
					KeyboardState arg_1BE_0 = Main.oldKeyState;
					if (l >= count || !Main.oldKeyState.IsKeyDown(pressedKeys[l]))
					{
						keyConfiguration.Processkey(PlayerInput.Triggers.Current, newKey);
					}
					else
					{
						keyConfiguration.CopyKeyState(PlayerInput.Triggers.Old, PlayerInput.Triggers.Current, newKey);
					}
					if (l >= count || pressedKeys[l] != Keys.None)
					{
						flag4 = true;
					}
				}
			}
			if (flag4)
			{
				PlayerInput.CurrentInputMode = InputMode.Keyboard;
			}
		}

		// Token: 0x06000EC6 RID: 3782 RVA: 0x003E9BF2 File Offset: 0x003E7DF2
		public static void ListenFor(string triggerName, InputMode inputmode)
		{
			PlayerInput._listeningTrigger = triggerName;
			PlayerInput._listeningInputMode = inputmode;
		}

		// Token: 0x06000EDB RID: 3803 RVA: 0x003EA1C4 File Offset: 0x003E83C4
		public static void Load()
		{
			Main.InputProfiles.Load();
			Dictionary<string, PlayerInputProfile> dictionary = new Dictionary<string, PlayerInputProfile>();
			string text = null;
			Main.InputProfiles.Get<string>("Selected Profile", ref text);
			List<string> allKeys = Main.InputProfiles.GetAllKeys();
			for (int i = 0; i < allKeys.Count; i++)
			{
				string text2 = allKeys[i];
				if (!(text2 == "Selected Profile") && !string.IsNullOrEmpty(text2))
				{
					Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
					Main.InputProfiles.Get<Dictionary<string, object>>(text2, ref dictionary2);
					if (dictionary2.Count > 0)
					{
						PlayerInputProfile playerInputProfile = new PlayerInputProfile(text2);
						playerInputProfile.Initialize(PresetProfiles.None);
						if (playerInputProfile.Load(dictionary2))
						{
							dictionary.Add(text2, playerInputProfile);
						}
					}
				}
			}
			if (dictionary.Count > 0)
			{
				PlayerInput.Profiles = dictionary;
				if (!string.IsNullOrEmpty(text) && PlayerInput.Profiles.ContainsKey(text))
				{
					PlayerInput.SetSelectedProfile(text);
					return;
				}
				PlayerInput.SetSelectedProfile(PlayerInput.Profiles.Keys.First<string>());
			}
		}

		// Token: 0x06000EF1 RID: 3825 RVA: 0x003EC50A File Offset: 0x003EA70A
		public static void LockOnCachePosition()
		{
			PlayerInput.PreLockOnX = PlayerInput.MouseX;
			PlayerInput.PreLockOnY = PlayerInput.MouseY;
		}

		// Token: 0x06000EF2 RID: 3826 RVA: 0x003EC520 File Offset: 0x003EA720
		public static void LockOnUnCachePosition()
		{
			PlayerInput.MouseX = PlayerInput.PreLockOnX;
			PlayerInput.MouseY = PlayerInput.PreLockOnY;
		}

		// Token: 0x06000EDC RID: 3804 RVA: 0x003EA2B8 File Offset: 0x003E84B8
		public static void ManageVersion_1_3()
		{
			PlayerInputProfile playerInputProfile = PlayerInput.Profiles["Custom"];
			string[,] expr_18 = new string[20, 2];
			expr_18[0, 0] = "KeyUp";
			expr_18[0, 1] = "Up";
			expr_18[1, 0] = "KeyDown";
			expr_18[1, 1] = "Down";
			expr_18[2, 0] = "KeyLeft";
			expr_18[2, 1] = "Left";
			expr_18[3, 0] = "KeyRight";
			expr_18[3, 1] = "Right";
			expr_18[4, 0] = "KeyJump";
			expr_18[4, 1] = "Jump";
			expr_18[5, 0] = "KeyThrowItem";
			expr_18[5, 1] = "Throw";
			expr_18[6, 0] = "KeyInventory";
			expr_18[6, 1] = "Inventory";
			expr_18[7, 0] = "KeyQuickHeal";
			expr_18[7, 1] = "QuickHeal";
			expr_18[8, 0] = "KeyQuickMana";
			expr_18[8, 1] = "QuickMana";
			expr_18[9, 0] = "KeyQuickBuff";
			expr_18[9, 1] = "QuickBuff";
			expr_18[10, 0] = "KeyUseHook";
			expr_18[10, 1] = "Grapple";
			expr_18[11, 0] = "KeyAutoSelect";
			expr_18[11, 1] = "SmartSelect";
			expr_18[12, 0] = "KeySmartCursor";
			expr_18[12, 1] = "SmartCursor";
			expr_18[13, 0] = "KeyMount";
			expr_18[13, 1] = "QuickMount";
			expr_18[14, 0] = "KeyMapStyle";
			expr_18[14, 1] = "MapStyle";
			expr_18[15, 0] = "KeyFullscreenMap";
			expr_18[15, 1] = "MapFull";
			expr_18[16, 0] = "KeyMapZoomIn";
			expr_18[16, 1] = "MapZoomIn";
			expr_18[17, 0] = "KeyMapZoomOut";
			expr_18[17, 1] = "MapZoomOut";
			expr_18[18, 0] = "KeyMapAlphaUp";
			expr_18[18, 1] = "MapAlphaUp";
			expr_18[19, 0] = "KeyMapAlphaDown";
			expr_18[19, 1] = "MapAlphaDown";
			string[,] array = expr_18;
			for (int i = 0; i < array.GetLength(0); i++)
			{
				string text = null;
				Main.Configuration.Get<string>(array[i, 0], ref text);
				if (text != null)
				{
					playerInputProfile.InputModes[InputMode.Keyboard].KeyStatus[array[i, 1]] = new List<string>
					{
						text
					};
					playerInputProfile.InputModes[InputMode.KeyboardUI].KeyStatus[array[i, 1]] = new List<string>
					{
						text
					};
				}
			}
		}

		// Token: 0x06000EE5 RID: 3813 RVA: 0x003EB3F4 File Offset: 0x003E95F4
		private static void MouseInput()
		{
			bool flag = false;
			PlayerInput.MouseInfoOld = PlayerInput.MouseInfo;
			PlayerInput.MouseInfo = Mouse.GetState();
			PlayerInput.ScrollWheelValue += PlayerInput.MouseInfo.ScrollWheelValue;
			bool arg_56_0 = PlayerInput.MouseInfo.X - PlayerInput.MouseInfoOld.X != 0;
			int num = PlayerInput.MouseInfo.Y - PlayerInput.MouseInfoOld.Y;
			if (arg_56_0 || num != 0 || PlayerInput.MouseInfo.ScrollWheelValue != PlayerInput.MouseInfoOld.ScrollWheelValue)
			{
				PlayerInput.MouseX = PlayerInput.MouseInfo.X;
				PlayerInput.MouseY = PlayerInput.MouseInfo.Y;
				flag = true;
			}
			PlayerInput.MouseKeys.Clear();
			if (Main.instance.IsActive)
			{
				if (PlayerInput.MouseInfo.LeftButton == ButtonState.Pressed)
				{
					PlayerInput.MouseKeys.Add("Mouse1");
					flag = true;
				}
				if (PlayerInput.MouseInfo.RightButton == ButtonState.Pressed)
				{
					PlayerInput.MouseKeys.Add("Mouse2");
					flag = true;
				}
				if (PlayerInput.MouseInfo.MiddleButton == ButtonState.Pressed)
				{
					PlayerInput.MouseKeys.Add("Mouse3");
					flag = true;
				}
				if (PlayerInput.MouseInfo.XButton1 == ButtonState.Pressed)
				{
					PlayerInput.MouseKeys.Add("Mouse4");
					flag = true;
				}
				if (PlayerInput.MouseInfo.XButton2 == ButtonState.Pressed)
				{
					PlayerInput.MouseKeys.Add("Mouse5");
					flag = true;
				}
			}
			if (flag)
			{
				PlayerInput.CurrentInputMode = InputMode.Mouse;
				PlayerInput.Triggers.Current.UsedMovementKey = false;
			}
		}

		// Token: 0x06000EEF RID: 3823 RVA: 0x003EC4DE File Offset: 0x003EA6DE
		public static void NavigatorCachePosition()
		{
			PlayerInput.PreUIX = PlayerInput.MouseX;
			PlayerInput.PreUIY = PlayerInput.MouseY;
		}

		// Token: 0x06000EF0 RID: 3824 RVA: 0x003EC4F4 File Offset: 0x003EA6F4
		public static void NavigatorUnCachePosition()
		{
			PlayerInput.MouseX = PlayerInput.PreUIX;
			PlayerInput.MouseY = PlayerInput.PreUIY;
		}

		// Token: 0x06000EEA RID: 3818 RVA: 0x003EBC3C File Offset: 0x003E9E3C
		private static void PostInput()
		{
			Main.GamepadCursorAlpha = MathHelper.Clamp(Main.GamepadCursorAlpha + ((Main.SmartCursorEnabled && !UILinkPointNavigator.Available && PlayerInput.GamepadThumbstickLeft == Vector2.Zero && PlayerInput.GamepadThumbstickRight == Vector2.Zero) ? -0.05f : 0.05f), 0f, 1f);
			if (PlayerInput.CurrentProfile.HotbarAllowsRadial)
			{
				int num = PlayerInput.Triggers.Current.HotbarPlus.ToInt() - PlayerInput.Triggers.Current.HotbarMinus.ToInt();
				if (PlayerInput.MiscSettingsTEMP.HotbarRadialShouldBeUsed)
				{
					if (num == 1)
					{
						PlayerInput.Triggers.Current.RadialHotbar = true;
						PlayerInput.Triggers.JustReleased.RadialHotbar = false;
					}
					else if (num == -1)
					{
						PlayerInput.Triggers.Current.RadialQuickbar = true;
						PlayerInput.Triggers.JustReleased.RadialQuickbar = false;
					}
				}
			}
			PlayerInput.MiscSettingsTEMP.HotbarRadialShouldBeUsed = false;
		}

		// Token: 0x06000EF3 RID: 3827 RVA: 0x003EC538 File Offset: 0x003EA738
		public static void PrettyPrintProfiles(ref string text)
		{
			string[] array = text.Split(new string[]
			{
				"\r\n"
			}, StringSplitOptions.None);
			for (int i = 0; i < array.Length; i++)
			{
				string text2 = array[i];
				if (text2.Contains(": {"))
				{
					string str = text2.Substring(0, text2.IndexOf('"'));
					string text3 = text2 + "\r\n  ";
					string newValue = text3.Replace(": {\r\n  ", ": \r\n" + str + "{\r\n  ");
					text = text.Replace(text3, newValue);
				}
			}
			text = text.Replace("[\r\n        ", "[");
			text = text.Replace("[\r\n      ", "[");
			text = text.Replace("\"\r\n      ", "\"");
			text = text.Replace("\",\r\n        ", "\", ");
			text = text.Replace("\",\r\n      ", "\", ");
			text = text.Replace("\r\n    ]", "]");
		}

		// Token: 0x06000EF4 RID: 3828 RVA: 0x003EC638 File Offset: 0x003EA838
		public static void PrettyPrintProfilesOld(ref string text)
		{
			text = text.Replace(": {\r\n  ", ": \r\n  {\r\n  ");
			text = text.Replace("[\r\n      ", "[");
			text = text.Replace("\"\r\n      ", "\"");
			text = text.Replace("\",\r\n      ", "\", ");
			text = text.Replace("\r\n    ]", "]");
		}

		// Token: 0x06000EF5 RID: 3829 RVA: 0x003EC6A4 File Offset: 0x003EA8A4
		public static void Reset(KeyConfiguration c, PresetProfiles style, InputMode mode)
		{
			switch (style)
			{
				case PresetProfiles.Redigit:
					switch (mode)
					{
						case InputMode.Keyboard:
							c.KeyStatus["MouseLeft"].Add("Mouse1");
							c.KeyStatus["MouseRight"].Add("Mouse2");
							c.KeyStatus["Up"].Add("W");
							c.KeyStatus["Down"].Add("S");
							c.KeyStatus["Left"].Add("A");
							c.KeyStatus["Right"].Add("D");
							c.KeyStatus["Jump"].Add("Space");
							c.KeyStatus["Inventory"].Add("Escape");
							c.KeyStatus["Grapple"].Add("E");
							c.KeyStatus["SmartSelect"].Add("LeftShift");
							c.KeyStatus["SmartCursor"].Add("LeftControl");
							c.KeyStatus["QuickMount"].Add("R");
							c.KeyStatus["QuickHeal"].Add("H");
							c.KeyStatus["QuickMana"].Add("J");
							c.KeyStatus["QuickBuff"].Add("B");
							c.KeyStatus["MapStyle"].Add("Tab");
							c.KeyStatus["MapFull"].Add("M");
							c.KeyStatus["MapZoomIn"].Add("Add");
							c.KeyStatus["MapZoomOut"].Add("Subtract");
							c.KeyStatus["MapAlphaUp"].Add("PageUp");
							c.KeyStatus["MapAlphaDown"].Add("PageDown");
							c.KeyStatus["Hotbar1"].Add("D1");
							c.KeyStatus["Hotbar2"].Add("D2");
							c.KeyStatus["Hotbar3"].Add("D3");
							c.KeyStatus["Hotbar4"].Add("D4");
							c.KeyStatus["Hotbar5"].Add("D5");
							c.KeyStatus["Hotbar6"].Add("D6");
							c.KeyStatus["Hotbar7"].Add("D7");
							c.KeyStatus["Hotbar8"].Add("D8");
							c.KeyStatus["Hotbar9"].Add("D9");
							c.KeyStatus["Hotbar10"].Add("D0");
							c.KeyStatus["ViewZoomOut"].Add("OemMinus");
							c.KeyStatus["ViewZoomIn"].Add("OemPlus");
							return;
						case InputMode.KeyboardUI:
							c.KeyStatus["MouseLeft"].Add("Mouse1");
							c.KeyStatus["MouseLeft"].Add("Space");
							c.KeyStatus["MouseRight"].Add("Mouse2");
							c.KeyStatus["Up"].Add("W");
							c.KeyStatus["Up"].Add("Up");
							c.KeyStatus["Down"].Add("S");
							c.KeyStatus["Down"].Add("Down");
							c.KeyStatus["Left"].Add("A");
							c.KeyStatus["Left"].Add("Left");
							c.KeyStatus["Right"].Add("D");
							c.KeyStatus["Right"].Add("Right");
							c.KeyStatus["Inventory"].Add(Keys.Escape.ToString());
							c.KeyStatus["MenuUp"].Add(string.Concat(Buttons.DPadUp));
							c.KeyStatus["MenuDown"].Add(string.Concat(Buttons.DPadDown));
							c.KeyStatus["MenuLeft"].Add(string.Concat(Buttons.DPadLeft));
							c.KeyStatus["MenuRight"].Add(string.Concat(Buttons.DPadRight));
							return;
						case InputMode.Mouse:
							break;
						case InputMode.XBoxGamepad:
							c.KeyStatus["MouseLeft"].Add(string.Concat(Buttons.RightTrigger));
							c.KeyStatus["MouseRight"].Add(string.Concat(Buttons.B));
							c.KeyStatus["Up"].Add(string.Concat(Buttons.LeftThumbstickUp));
							c.KeyStatus["Down"].Add(string.Concat(Buttons.LeftThumbstickDown));
							c.KeyStatus["Left"].Add(string.Concat(Buttons.LeftThumbstickLeft));
							c.KeyStatus["Right"].Add(string.Concat(Buttons.LeftThumbstickRight));
							c.KeyStatus["Jump"].Add(string.Concat(Buttons.LeftTrigger));
							c.KeyStatus["Inventory"].Add(string.Concat(Buttons.Y));
							c.KeyStatus["Grapple"].Add(string.Concat(Buttons.B));
							c.KeyStatus["LockOn"].Add(string.Concat(Buttons.X));
							c.KeyStatus["QuickMount"].Add(string.Concat(Buttons.A));
							c.KeyStatus["SmartSelect"].Add(string.Concat(Buttons.LeftStick));
							c.KeyStatus["SmartCursor"].Add(string.Concat(Buttons.RightStick));
							c.KeyStatus["HotbarMinus"].Add(string.Concat(Buttons.LeftShoulder));
							c.KeyStatus["HotbarPlus"].Add(string.Concat(Buttons.RightShoulder));
							c.KeyStatus["MapFull"].Add(string.Concat(Buttons.Start));
							c.KeyStatus["DpadSnap1"].Add(string.Concat(Buttons.DPadUp));
							c.KeyStatus["DpadSnap3"].Add(string.Concat(Buttons.DPadDown));
							c.KeyStatus["DpadSnap4"].Add(string.Concat(Buttons.DPadLeft));
							c.KeyStatus["DpadSnap2"].Add(string.Concat(Buttons.DPadRight));
							c.KeyStatus["MapStyle"].Add(string.Concat(Buttons.Back));
							return;
						case InputMode.XBoxGamepadUI:
							c.KeyStatus["MouseLeft"].Add(string.Concat(Buttons.A));
							c.KeyStatus["MouseRight"].Add(string.Concat(Buttons.LeftShoulder));
							c.KeyStatus["SmartCursor"].Add(string.Concat(Buttons.RightShoulder));
							c.KeyStatus["Up"].Add(string.Concat(Buttons.LeftThumbstickUp));
							c.KeyStatus["Down"].Add(string.Concat(Buttons.LeftThumbstickDown));
							c.KeyStatus["Left"].Add(string.Concat(Buttons.LeftThumbstickLeft));
							c.KeyStatus["Right"].Add(string.Concat(Buttons.LeftThumbstickRight));
							c.KeyStatus["Inventory"].Add(string.Concat(Buttons.B));
							c.KeyStatus["Inventory"].Add(string.Concat(Buttons.Y));
							c.KeyStatus["HotbarMinus"].Add(string.Concat(Buttons.LeftTrigger));
							c.KeyStatus["HotbarPlus"].Add(string.Concat(Buttons.RightTrigger));
							c.KeyStatus["Grapple"].Add(string.Concat(Buttons.X));
							c.KeyStatus["MapFull"].Add(string.Concat(Buttons.Start));
							c.KeyStatus["SmartSelect"].Add(string.Concat(Buttons.Back));
							c.KeyStatus["QuickMount"].Add(string.Concat(Buttons.RightStick));
							c.KeyStatus["DpadSnap1"].Add(string.Concat(Buttons.DPadUp));
							c.KeyStatus["DpadSnap3"].Add(string.Concat(Buttons.DPadDown));
							c.KeyStatus["DpadSnap4"].Add(string.Concat(Buttons.DPadLeft));
							c.KeyStatus["DpadSnap2"].Add(string.Concat(Buttons.DPadRight));
							c.KeyStatus["MenuUp"].Add(string.Concat(Buttons.DPadUp));
							c.KeyStatus["MenuDown"].Add(string.Concat(Buttons.DPadDown));
							c.KeyStatus["MenuLeft"].Add(string.Concat(Buttons.DPadLeft));
							c.KeyStatus["MenuRight"].Add(string.Concat(Buttons.DPadRight));
							return;
						default:
							return;
					}
					break;
				case PresetProfiles.Yoraiz0r:
					switch (mode)
					{
						case InputMode.Keyboard:
							c.KeyStatus["MouseLeft"].Add("Mouse1");
							c.KeyStatus["MouseRight"].Add("Mouse2");
							c.KeyStatus["Up"].Add("W");
							c.KeyStatus["Down"].Add("S");
							c.KeyStatus["Left"].Add("A");
							c.KeyStatus["Right"].Add("D");
							c.KeyStatus["Jump"].Add("Space");
							c.KeyStatus["Inventory"].Add("Escape");
							c.KeyStatus["Grapple"].Add("E");
							c.KeyStatus["SmartSelect"].Add("LeftShift");
							c.KeyStatus["SmartCursor"].Add("LeftControl");
							c.KeyStatus["QuickMount"].Add("R");
							c.KeyStatus["QuickHeal"].Add("H");
							c.KeyStatus["QuickMana"].Add("J");
							c.KeyStatus["QuickBuff"].Add("B");
							c.KeyStatus["MapStyle"].Add("Tab");
							c.KeyStatus["MapFull"].Add("M");
							c.KeyStatus["MapZoomIn"].Add("Add");
							c.KeyStatus["MapZoomOut"].Add("Subtract");
							c.KeyStatus["MapAlphaUp"].Add("PageUp");
							c.KeyStatus["MapAlphaDown"].Add("PageDown");
							c.KeyStatus["Hotbar1"].Add("D1");
							c.KeyStatus["Hotbar2"].Add("D2");
							c.KeyStatus["Hotbar3"].Add("D3");
							c.KeyStatus["Hotbar4"].Add("D4");
							c.KeyStatus["Hotbar5"].Add("D5");
							c.KeyStatus["Hotbar6"].Add("D6");
							c.KeyStatus["Hotbar7"].Add("D7");
							c.KeyStatus["Hotbar8"].Add("D8");
							c.KeyStatus["Hotbar9"].Add("D9");
							c.KeyStatus["Hotbar10"].Add("D0");
							c.KeyStatus["ViewZoomOut"].Add("OemMinus");
							c.KeyStatus["ViewZoomIn"].Add("OemPlus");
							return;
						case InputMode.KeyboardUI:
							c.KeyStatus["MouseLeft"].Add("Mouse1");
							c.KeyStatus["MouseLeft"].Add("Space");
							c.KeyStatus["MouseRight"].Add("Mouse2");
							c.KeyStatus["Up"].Add("W");
							c.KeyStatus["Up"].Add("Up");
							c.KeyStatus["Down"].Add("S");
							c.KeyStatus["Down"].Add("Down");
							c.KeyStatus["Left"].Add("A");
							c.KeyStatus["Left"].Add("Left");
							c.KeyStatus["Right"].Add("D");
							c.KeyStatus["Right"].Add("Right");
							c.KeyStatus["Inventory"].Add(Keys.Escape.ToString());
							c.KeyStatus["MenuUp"].Add(string.Concat(Buttons.DPadUp));
							c.KeyStatus["MenuDown"].Add(string.Concat(Buttons.DPadDown));
							c.KeyStatus["MenuLeft"].Add(string.Concat(Buttons.DPadLeft));
							c.KeyStatus["MenuRight"].Add(string.Concat(Buttons.DPadRight));
							return;
						case InputMode.Mouse:
							break;
						case InputMode.XBoxGamepad:
							c.KeyStatus["MouseLeft"].Add(string.Concat(Buttons.RightTrigger));
							c.KeyStatus["MouseRight"].Add(string.Concat(Buttons.B));
							c.KeyStatus["Up"].Add(string.Concat(Buttons.LeftThumbstickUp));
							c.KeyStatus["Down"].Add(string.Concat(Buttons.LeftThumbstickDown));
							c.KeyStatus["Left"].Add(string.Concat(Buttons.LeftThumbstickLeft));
							c.KeyStatus["Right"].Add(string.Concat(Buttons.LeftThumbstickRight));
							c.KeyStatus["Jump"].Add(string.Concat(Buttons.LeftTrigger));
							c.KeyStatus["Inventory"].Add(string.Concat(Buttons.Y));
							c.KeyStatus["Grapple"].Add(string.Concat(Buttons.LeftShoulder));
							c.KeyStatus["SmartSelect"].Add(string.Concat(Buttons.LeftStick));
							c.KeyStatus["SmartCursor"].Add(string.Concat(Buttons.RightStick));
							c.KeyStatus["QuickMount"].Add(string.Concat(Buttons.X));
							c.KeyStatus["QuickHeal"].Add(string.Concat(Buttons.A));
							c.KeyStatus["RadialHotbar"].Add(string.Concat(Buttons.RightShoulder));
							c.KeyStatus["MapFull"].Add(string.Concat(Buttons.Start));
							c.KeyStatus["DpadSnap1"].Add(string.Concat(Buttons.DPadUp));
							c.KeyStatus["DpadSnap3"].Add(string.Concat(Buttons.DPadDown));
							c.KeyStatus["DpadSnap4"].Add(string.Concat(Buttons.DPadLeft));
							c.KeyStatus["DpadSnap2"].Add(string.Concat(Buttons.DPadRight));
							c.KeyStatus["MapStyle"].Add(string.Concat(Buttons.Back));
							return;
						case InputMode.XBoxGamepadUI:
							c.KeyStatus["MouseLeft"].Add(string.Concat(Buttons.A));
							c.KeyStatus["MouseRight"].Add(string.Concat(Buttons.LeftShoulder));
							c.KeyStatus["SmartCursor"].Add(string.Concat(Buttons.RightShoulder));
							c.KeyStatus["Up"].Add(string.Concat(Buttons.LeftThumbstickUp));
							c.KeyStatus["Down"].Add(string.Concat(Buttons.LeftThumbstickDown));
							c.KeyStatus["Left"].Add(string.Concat(Buttons.LeftThumbstickLeft));
							c.KeyStatus["Right"].Add(string.Concat(Buttons.LeftThumbstickRight));
							c.KeyStatus["LockOn"].Add(string.Concat(Buttons.B));
							c.KeyStatus["Inventory"].Add(string.Concat(Buttons.Y));
							c.KeyStatus["HotbarMinus"].Add(string.Concat(Buttons.LeftTrigger));
							c.KeyStatus["HotbarPlus"].Add(string.Concat(Buttons.RightTrigger));
							c.KeyStatus["Grapple"].Add(string.Concat(Buttons.X));
							c.KeyStatus["MapFull"].Add(string.Concat(Buttons.Start));
							c.KeyStatus["SmartSelect"].Add(string.Concat(Buttons.Back));
							c.KeyStatus["QuickMount"].Add(string.Concat(Buttons.RightStick));
							c.KeyStatus["DpadSnap1"].Add(string.Concat(Buttons.DPadUp));
							c.KeyStatus["DpadSnap3"].Add(string.Concat(Buttons.DPadDown));
							c.KeyStatus["DpadSnap4"].Add(string.Concat(Buttons.DPadLeft));
							c.KeyStatus["DpadSnap2"].Add(string.Concat(Buttons.DPadRight));
							c.KeyStatus["MenuUp"].Add(string.Concat(Buttons.DPadUp));
							c.KeyStatus["MenuDown"].Add(string.Concat(Buttons.DPadDown));
							c.KeyStatus["MenuLeft"].Add(string.Concat(Buttons.DPadLeft));
							c.KeyStatus["MenuRight"].Add(string.Concat(Buttons.DPadRight));
							return;
						default:
							return;
					}
					break;
				case PresetProfiles.ConsolePS:
					switch (mode)
					{
						case InputMode.Keyboard:
							c.KeyStatus["MouseLeft"].Add("Mouse1");
							c.KeyStatus["MouseRight"].Add("Mouse2");
							c.KeyStatus["Up"].Add("W");
							c.KeyStatus["Down"].Add("S");
							c.KeyStatus["Left"].Add("A");
							c.KeyStatus["Right"].Add("D");
							c.KeyStatus["Jump"].Add("Space");
							c.KeyStatus["Inventory"].Add("Escape");
							c.KeyStatus["Grapple"].Add("E");
							c.KeyStatus["SmartSelect"].Add("LeftShift");
							c.KeyStatus["SmartCursor"].Add("LeftControl");
							c.KeyStatus["QuickMount"].Add("R");
							c.KeyStatus["QuickHeal"].Add("H");
							c.KeyStatus["QuickMana"].Add("J");
							c.KeyStatus["QuickBuff"].Add("B");
							c.KeyStatus["MapStyle"].Add("Tab");
							c.KeyStatus["MapFull"].Add("M");
							c.KeyStatus["MapZoomIn"].Add("Add");
							c.KeyStatus["MapZoomOut"].Add("Subtract");
							c.KeyStatus["MapAlphaUp"].Add("PageUp");
							c.KeyStatus["MapAlphaDown"].Add("PageDown");
							c.KeyStatus["Hotbar1"].Add("D1");
							c.KeyStatus["Hotbar2"].Add("D2");
							c.KeyStatus["Hotbar3"].Add("D3");
							c.KeyStatus["Hotbar4"].Add("D4");
							c.KeyStatus["Hotbar5"].Add("D5");
							c.KeyStatus["Hotbar6"].Add("D6");
							c.KeyStatus["Hotbar7"].Add("D7");
							c.KeyStatus["Hotbar8"].Add("D8");
							c.KeyStatus["Hotbar9"].Add("D9");
							c.KeyStatus["Hotbar10"].Add("D0");
							c.KeyStatus["ViewZoomOut"].Add("OemMinus");
							c.KeyStatus["ViewZoomIn"].Add("OemPlus");
							return;
						case InputMode.KeyboardUI:
							c.KeyStatus["MouseLeft"].Add("Mouse1");
							c.KeyStatus["MouseLeft"].Add("Space");
							c.KeyStatus["MouseRight"].Add("Mouse2");
							c.KeyStatus["Up"].Add("W");
							c.KeyStatus["Up"].Add("Up");
							c.KeyStatus["Down"].Add("S");
							c.KeyStatus["Down"].Add("Down");
							c.KeyStatus["Left"].Add("A");
							c.KeyStatus["Left"].Add("Left");
							c.KeyStatus["Right"].Add("D");
							c.KeyStatus["Right"].Add("Right");
							c.KeyStatus["MenuUp"].Add(string.Concat(Buttons.DPadUp));
							c.KeyStatus["MenuDown"].Add(string.Concat(Buttons.DPadDown));
							c.KeyStatus["MenuLeft"].Add(string.Concat(Buttons.DPadLeft));
							c.KeyStatus["MenuRight"].Add(string.Concat(Buttons.DPadRight));
							c.KeyStatus["Inventory"].Add(Keys.Escape.ToString());
							return;
						case InputMode.Mouse:
							break;
						case InputMode.XBoxGamepad:
							c.KeyStatus["MouseLeft"].Add(string.Concat(Buttons.RightShoulder));
							c.KeyStatus["MouseRight"].Add(string.Concat(Buttons.B));
							c.KeyStatus["Up"].Add(string.Concat(Buttons.LeftThumbstickUp));
							c.KeyStatus["Down"].Add(string.Concat(Buttons.LeftThumbstickDown));
							c.KeyStatus["Left"].Add(string.Concat(Buttons.LeftThumbstickLeft));
							c.KeyStatus["Right"].Add(string.Concat(Buttons.LeftThumbstickRight));
							c.KeyStatus["Jump"].Add(string.Concat(Buttons.A));
							c.KeyStatus["LockOn"].Add(string.Concat(Buttons.X));
							c.KeyStatus["Inventory"].Add(string.Concat(Buttons.Y));
							c.KeyStatus["Grapple"].Add(string.Concat(Buttons.LeftShoulder));
							c.KeyStatus["SmartSelect"].Add(string.Concat(Buttons.LeftStick));
							c.KeyStatus["SmartCursor"].Add(string.Concat(Buttons.RightStick));
							c.KeyStatus["HotbarMinus"].Add(string.Concat(Buttons.LeftTrigger));
							c.KeyStatus["HotbarPlus"].Add(string.Concat(Buttons.RightTrigger));
							c.KeyStatus["MapFull"].Add(string.Concat(Buttons.Start));
							c.KeyStatus["DpadRadial1"].Add(string.Concat(Buttons.DPadUp));
							c.KeyStatus["DpadRadial3"].Add(string.Concat(Buttons.DPadDown));
							c.KeyStatus["DpadRadial4"].Add(string.Concat(Buttons.DPadLeft));
							c.KeyStatus["DpadRadial2"].Add(string.Concat(Buttons.DPadRight));
							c.KeyStatus["QuickMount"].Add(string.Concat(Buttons.Back));
							return;
						case InputMode.XBoxGamepadUI:
							c.KeyStatus["MouseLeft"].Add(string.Concat(Buttons.A));
							c.KeyStatus["MouseRight"].Add(string.Concat(Buttons.LeftShoulder));
							c.KeyStatus["SmartCursor"].Add(string.Concat(Buttons.RightShoulder));
							c.KeyStatus["Up"].Add(string.Concat(Buttons.LeftThumbstickUp));
							c.KeyStatus["Down"].Add(string.Concat(Buttons.LeftThumbstickDown));
							c.KeyStatus["Left"].Add(string.Concat(Buttons.LeftThumbstickLeft));
							c.KeyStatus["Right"].Add(string.Concat(Buttons.LeftThumbstickRight));
							c.KeyStatus["Inventory"].Add(string.Concat(Buttons.B));
							c.KeyStatus["Inventory"].Add(string.Concat(Buttons.Y));
							c.KeyStatus["HotbarMinus"].Add(string.Concat(Buttons.LeftTrigger));
							c.KeyStatus["HotbarPlus"].Add(string.Concat(Buttons.RightTrigger));
							c.KeyStatus["Grapple"].Add(string.Concat(Buttons.X));
							c.KeyStatus["MapFull"].Add(string.Concat(Buttons.Start));
							c.KeyStatus["SmartSelect"].Add(string.Concat(Buttons.Back));
							c.KeyStatus["QuickMount"].Add(string.Concat(Buttons.RightStick));
							c.KeyStatus["DpadRadial1"].Add(string.Concat(Buttons.DPadUp));
							c.KeyStatus["DpadRadial3"].Add(string.Concat(Buttons.DPadDown));
							c.KeyStatus["DpadRadial4"].Add(string.Concat(Buttons.DPadLeft));
							c.KeyStatus["DpadRadial2"].Add(string.Concat(Buttons.DPadRight));
							c.KeyStatus["MenuUp"].Add(string.Concat(Buttons.DPadUp));
							c.KeyStatus["MenuDown"].Add(string.Concat(Buttons.DPadDown));
							c.KeyStatus["MenuLeft"].Add(string.Concat(Buttons.DPadLeft));
							c.KeyStatus["MenuRight"].Add(string.Concat(Buttons.DPadRight));
							return;
						default:
							return;
					}
					break;
				case PresetProfiles.ConsoleXBox:
					switch (mode)
					{
						case InputMode.Keyboard:
							c.KeyStatus["MouseLeft"].Add("Mouse1");
							c.KeyStatus["MouseRight"].Add("Mouse2");
							c.KeyStatus["Up"].Add("W");
							c.KeyStatus["Down"].Add("S");
							c.KeyStatus["Left"].Add("A");
							c.KeyStatus["Right"].Add("D");
							c.KeyStatus["Jump"].Add("Space");
							c.KeyStatus["Inventory"].Add("Escape");
							c.KeyStatus["Grapple"].Add("E");
							c.KeyStatus["SmartSelect"].Add("LeftShift");
							c.KeyStatus["SmartCursor"].Add("LeftControl");
							c.KeyStatus["QuickMount"].Add("R");
							c.KeyStatus["QuickHeal"].Add("H");
							c.KeyStatus["QuickMana"].Add("J");
							c.KeyStatus["QuickBuff"].Add("B");
							c.KeyStatus["MapStyle"].Add("Tab");
							c.KeyStatus["MapFull"].Add("M");
							c.KeyStatus["MapZoomIn"].Add("Add");
							c.KeyStatus["MapZoomOut"].Add("Subtract");
							c.KeyStatus["MapAlphaUp"].Add("PageUp");
							c.KeyStatus["MapAlphaDown"].Add("PageDown");
							c.KeyStatus["Hotbar1"].Add("D1");
							c.KeyStatus["Hotbar2"].Add("D2");
							c.KeyStatus["Hotbar3"].Add("D3");
							c.KeyStatus["Hotbar4"].Add("D4");
							c.KeyStatus["Hotbar5"].Add("D5");
							c.KeyStatus["Hotbar6"].Add("D6");
							c.KeyStatus["Hotbar7"].Add("D7");
							c.KeyStatus["Hotbar8"].Add("D8");
							c.KeyStatus["Hotbar9"].Add("D9");
							c.KeyStatus["Hotbar10"].Add("D0");
							c.KeyStatus["ViewZoomOut"].Add("OemMinus");
							c.KeyStatus["ViewZoomIn"].Add("OemPlus");
							return;
						case InputMode.KeyboardUI:
							c.KeyStatus["MouseLeft"].Add("Mouse1");
							c.KeyStatus["MouseLeft"].Add("Space");
							c.KeyStatus["MouseRight"].Add("Mouse2");
							c.KeyStatus["Up"].Add("W");
							c.KeyStatus["Up"].Add("Up");
							c.KeyStatus["Down"].Add("S");
							c.KeyStatus["Down"].Add("Down");
							c.KeyStatus["Left"].Add("A");
							c.KeyStatus["Left"].Add("Left");
							c.KeyStatus["Right"].Add("D");
							c.KeyStatus["Right"].Add("Right");
							c.KeyStatus["MenuUp"].Add(string.Concat(Buttons.DPadUp));
							c.KeyStatus["MenuDown"].Add(string.Concat(Buttons.DPadDown));
							c.KeyStatus["MenuLeft"].Add(string.Concat(Buttons.DPadLeft));
							c.KeyStatus["MenuRight"].Add(string.Concat(Buttons.DPadRight));
							c.KeyStatus["Inventory"].Add(Keys.Escape.ToString());
							return;
						case InputMode.Mouse:
							break;
						case InputMode.XBoxGamepad:
							c.KeyStatus["MouseLeft"].Add(string.Concat(Buttons.RightTrigger));
							c.KeyStatus["MouseRight"].Add(string.Concat(Buttons.B));
							c.KeyStatus["Up"].Add(string.Concat(Buttons.LeftThumbstickUp));
							c.KeyStatus["Down"].Add(string.Concat(Buttons.LeftThumbstickDown));
							c.KeyStatus["Left"].Add(string.Concat(Buttons.LeftThumbstickLeft));
							c.KeyStatus["Right"].Add(string.Concat(Buttons.LeftThumbstickRight));
							c.KeyStatus["Jump"].Add(string.Concat(Buttons.A));
							c.KeyStatus["LockOn"].Add(string.Concat(Buttons.X));
							c.KeyStatus["Inventory"].Add(string.Concat(Buttons.Y));
							c.KeyStatus["Grapple"].Add(string.Concat(Buttons.LeftTrigger));
							c.KeyStatus["SmartSelect"].Add(string.Concat(Buttons.LeftStick));
							c.KeyStatus["SmartCursor"].Add(string.Concat(Buttons.RightStick));
							c.KeyStatus["HotbarMinus"].Add(string.Concat(Buttons.LeftShoulder));
							c.KeyStatus["HotbarPlus"].Add(string.Concat(Buttons.RightShoulder));
							c.KeyStatus["MapFull"].Add(string.Concat(Buttons.Start));
							c.KeyStatus["DpadRadial1"].Add(string.Concat(Buttons.DPadUp));
							c.KeyStatus["DpadRadial3"].Add(string.Concat(Buttons.DPadDown));
							c.KeyStatus["DpadRadial4"].Add(string.Concat(Buttons.DPadLeft));
							c.KeyStatus["DpadRadial2"].Add(string.Concat(Buttons.DPadRight));
							c.KeyStatus["QuickMount"].Add(string.Concat(Buttons.Back));
							return;
						case InputMode.XBoxGamepadUI:
							c.KeyStatus["MouseLeft"].Add(string.Concat(Buttons.A));
							c.KeyStatus["MouseRight"].Add(string.Concat(Buttons.LeftShoulder));
							c.KeyStatus["SmartCursor"].Add(string.Concat(Buttons.RightShoulder));
							c.KeyStatus["Up"].Add(string.Concat(Buttons.LeftThumbstickUp));
							c.KeyStatus["Down"].Add(string.Concat(Buttons.LeftThumbstickDown));
							c.KeyStatus["Left"].Add(string.Concat(Buttons.LeftThumbstickLeft));
							c.KeyStatus["Right"].Add(string.Concat(Buttons.LeftThumbstickRight));
							c.KeyStatus["Inventory"].Add(string.Concat(Buttons.B));
							c.KeyStatus["Inventory"].Add(string.Concat(Buttons.Y));
							c.KeyStatus["HotbarMinus"].Add(string.Concat(Buttons.LeftTrigger));
							c.KeyStatus["HotbarPlus"].Add(string.Concat(Buttons.RightTrigger));
							c.KeyStatus["Grapple"].Add(string.Concat(Buttons.X));
							c.KeyStatus["MapFull"].Add(string.Concat(Buttons.Start));
							c.KeyStatus["SmartSelect"].Add(string.Concat(Buttons.Back));
							c.KeyStatus["QuickMount"].Add(string.Concat(Buttons.RightStick));
							c.KeyStatus["DpadRadial1"].Add(string.Concat(Buttons.DPadUp));
							c.KeyStatus["DpadRadial3"].Add(string.Concat(Buttons.DPadDown));
							c.KeyStatus["DpadRadial4"].Add(string.Concat(Buttons.DPadLeft));
							c.KeyStatus["DpadRadial2"].Add(string.Concat(Buttons.DPadRight));
							c.KeyStatus["MenuUp"].Add(string.Concat(Buttons.DPadUp));
							c.KeyStatus["MenuDown"].Add(string.Concat(Buttons.DPadDown));
							c.KeyStatus["MenuLeft"].Add(string.Concat(Buttons.DPadLeft));
							c.KeyStatus["MenuRight"].Add(string.Concat(Buttons.DPadRight));
							break;
						default:
							return;
					}
					break;
				default:
					return;
			}
		}

		// Token: 0x06000ED0 RID: 3792 RVA: 0x003E9D48 File Offset: 0x003E7F48
		public static void ResetInputsOnActiveStateChange()
		{
			bool isActive = Main.instance.IsActive;
			if (PlayerInput._lastActivityState != isActive)
			{
				PlayerInput.MouseInfo = default(MouseState);
				PlayerInput.MouseInfoOld = default(MouseState);
				Main.keyState = Keyboard.GetState();
				Main.inputText = Keyboard.GetState();
				Main.oldInputText = Keyboard.GetState();
				Main.keyCount = 0;
				PlayerInput.Triggers.Reset();
				PlayerInput.Triggers.Reset();
				string text = "";
				Keys[] pressedKeys = Main.keyState.GetPressedKeys();
				for (int i = 0; i < pressedKeys.Length; i++)
				{
					Keys keys = pressedKeys[i];
					text = text + keys.ToString() + ", ";
				}
				PlayerInput._invalidatorCheck = text;
			}
			PlayerInput._lastActivityState = isActive;
		}

		// Token: 0x06000EDA RID: 3802 RVA: 0x003EA12C File Offset: 0x003E832C
		public static bool Save()
		{
			Main.InputProfiles.Clear();
			Main.InputProfiles.Put("Selected Profile", PlayerInput._selectedProfile);
			foreach (KeyValuePair<string, PlayerInputProfile> current in PlayerInput.Profiles)
			{
				Main.InputProfiles.Put(current.Value.Name, current.Value.Save());
			}
			return Main.InputProfiles.Save(true);
		}

		// Token: 0x06000EFB RID: 3835 RVA: 0x003EF5EE File Offset: 0x003ED7EE
		public static void SetDesiredZoomContext(ZoomContext context)
		{
			PlayerInput._currentWantedZoom = context;
		}

		// Token: 0x06000ED7 RID: 3799 RVA: 0x003E9F63 File Offset: 0x003E8163
		public static void SetSelectedProfile(string name)
		{
			if (PlayerInput.Profiles.ContainsKey(name))
			{
				PlayerInput._selectedProfile = name;
				PlayerInput._currentProfile = PlayerInput.Profiles[PlayerInput._selectedProfile];
			}
		}

		// Token: 0x06000EFC RID: 3836 RVA: 0x003EF5F8 File Offset: 0x003ED7F8
		public static void SetZoom_Context()
		{
			switch (PlayerInput._currentWantedZoom)
			{
				case ZoomContext.Unscaled:
					PlayerInput.SetZoom_Unscaled();
					Main.SetRecommendedZoomContext(Matrix.Identity);
					return;
				case ZoomContext.World:
					PlayerInput.SetZoom_World();
					Main.SetRecommendedZoomContext(Main.GameViewMatrix.ZoomMatrix);
					return;
				case ZoomContext.Unscaled_MouseInWorld:
					PlayerInput.SetZoom_Unscaled();
					PlayerInput.SetZoom_MouseInWorld();
					Main.SetRecommendedZoomContext(Main.GameViewMatrix.ZoomMatrix);
					return;
				case ZoomContext.UI:
					PlayerInput.SetZoom_UI();
					Main.SetRecommendedZoomContext(Main.UIScaleMatrix);
					return;
				default:
					return;
			}
		}

		// Token: 0x06000EFA RID: 3834 RVA: 0x003EF500 File Offset: 0x003ED700
		public static void SetZoom_MouseInWorld()
		{
			Vector2 vector = Main.screenPosition + new Vector2((float)Main.screenWidth, (float)Main.screenHeight) / 2f;
			Vector2 value = Main.screenPosition + new Vector2((float)PlayerInput._originalMouseX, (float)PlayerInput._originalMouseY);
			Vector2 arg_66_0 = Main.screenPosition + new Vector2((float)PlayerInput._originalLastMouseX, (float)PlayerInput._originalLastMouseY);
			Vector2 value2 = value - vector;
			Vector2 value3 = arg_66_0 - vector;
			float scaleFactor = 1f / Main.GameViewMatrix.Zoom.X;
			Vector2 expr_9B = vector - Main.screenPosition + value2 * scaleFactor;
			Main.mouseX = (int)expr_9B.X;
			Main.mouseY = (int)expr_9B.Y;
			Vector2 expr_CA = vector - Main.screenPosition + value3 * scaleFactor;
			Main.lastMouseX = (int)expr_CA.X;
			Main.lastMouseY = (int)expr_CA.Y;
		}

		// Token: 0x06000EFD RID: 3837 RVA: 0x003EF670 File Offset: 0x003ED870
		private static void SetZoom_Scaled(float scale)
		{
			Main.lastMouseX = (int)((float)PlayerInput._originalLastMouseX * scale);
			Main.lastMouseY = (int)((float)PlayerInput._originalLastMouseY * scale);
			Main.mouseX = (int)((float)PlayerInput._originalMouseX * scale);
			Main.mouseY = (int)((float)PlayerInput._originalMouseY * scale);
			Main.screenWidth = (int)((float)PlayerInput._originalScreenWidth * scale);
			Main.screenHeight = (int)((float)PlayerInput._originalScreenHeight * scale);
		}

		// Token: 0x06000EF9 RID: 3833 RVA: 0x003EF384 File Offset: 0x003ED584
		public static void SetZoom_Test()
		{
			Vector2 vector = Main.screenPosition + new Vector2((float)Main.screenWidth, (float)Main.screenHeight) / 2f;
			Vector2 value = Main.screenPosition + new Vector2((float)PlayerInput._originalMouseX, (float)PlayerInput._originalMouseY);
			Vector2 value2 = Main.screenPosition + new Vector2((float)PlayerInput._originalLastMouseX, (float)PlayerInput._originalLastMouseY);
			Vector2 value3 = Main.screenPosition + new Vector2(0f, 0f);
			Vector2 arg_AF_0 = Main.screenPosition + new Vector2((float)Main.screenWidth, (float)Main.screenHeight);
			Vector2 value4 = value - vector;
			Vector2 value5 = value2 - vector;
			Vector2 value6 = value3 - vector;
			//			arg_AF_0 - vector;
			float scaleFactor = 1f / Main.GameViewMatrix.Zoom.X;
			float num = 1f;
			Vector2 arg_118_0 = vector - Main.screenPosition + value4 * scaleFactor;
			Vector2 vector2 = vector - Main.screenPosition + value5 * scaleFactor;
			Vector2 screenPosition = vector + value6 * num;
			Main.mouseX = (int)arg_118_0.X;
			Main.mouseY = (int)arg_118_0.Y;
			Main.lastMouseX = (int)vector2.X;
			Main.lastMouseY = (int)vector2.Y;
			Main.screenPosition = screenPosition;
			Main.screenWidth = (int)((float)PlayerInput._originalScreenWidth * num);
			Main.screenHeight = (int)((float)PlayerInput._originalScreenHeight * num);
		}

		// Token: 0x06000EF6 RID: 3830 RVA: 0x003EF314 File Offset: 0x003ED514
		public static void SetZoom_UI()
		{
			float uIScale = Main.UIScale;
			PlayerInput.SetZoom_Scaled(1f / uIScale);
		}

		// Token: 0x06000EF8 RID: 3832 RVA: 0x003EF344 File Offset: 0x003ED544
		public static void SetZoom_Unscaled()
		{
			Main.lastMouseX = PlayerInput._originalLastMouseX;
			Main.lastMouseY = PlayerInput._originalLastMouseY;
			Main.mouseX = PlayerInput._originalMouseX;
			Main.mouseY = PlayerInput._originalMouseY;
			Main.screenWidth = PlayerInput._originalScreenWidth;
			Main.screenHeight = PlayerInput._originalScreenHeight;
		}

		// Token: 0x06000EF7 RID: 3831 RVA: 0x003EF333 File Offset: 0x003ED533
		public static void SetZoom_World()
		{
			PlayerInput.SetZoom_Scaled(1f);
			PlayerInput.SetZoom_MouseInWorld();
		}

		// Token: 0x06000EDE RID: 3806 RVA: 0x003EA598 File Offset: 0x003E8798
		public static void UpdateInput()
		{
			PlayerInput.Triggers.Reset();
			PlayerInput.ScrollWheelValueOld = PlayerInput.ScrollWheelValue;
			PlayerInput.ScrollWheelValue = 0;
			PlayerInput.GamepadThumbstickLeft = Vector2.Zero;
			PlayerInput.GamepadThumbstickRight = Vector2.Zero;
			PlayerInput.GrappleAndInteractAreShared = (PlayerInput.UsingGamepad && PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepad].DoGrappleAndInteractShareTheSameKey);
			if (PlayerInput.InBuildingMode && !PlayerInput.UsingGamepad)
			{
				PlayerInput.ExitBuildingMode();
			}
			if (PlayerInput._canReleaseRebindingLock && PlayerInput.NavigatorRebindingLock > 0)
			{
				PlayerInput.NavigatorRebindingLock--;
				PlayerInput.Triggers.Current.UsedMovementKey = false;
				if (PlayerInput.NavigatorRebindingLock == 0 && PlayerInput._memoOfLastPoint != -1)
				{
					UIManageControls.ForceMoveTo = PlayerInput._memoOfLastPoint;
					PlayerInput._memoOfLastPoint = -1;
				}
			}
			PlayerInput._canReleaseRebindingLock = true;
			PlayerInput.VerifyBuildingMode();
			PlayerInput.MouseInput();
			PlayerInput.KeyboardInput();
			PlayerInput.GamePadInput();
			PlayerInput.Triggers.Update();
			PlayerInput.PostInput();
			PlayerInput.ScrollWheelDelta = PlayerInput.ScrollWheelValue - PlayerInput.ScrollWheelValueOld;
			PlayerInput.ScrollWheelDeltaForUI = PlayerInput.ScrollWheelDelta;
			PlayerInput.WritingText = false;
			PlayerInput.UpdateMainMouse();
			Main.mouseLeft = PlayerInput.Triggers.Current.MouseLeft;
			Main.mouseRight = PlayerInput.Triggers.Current.MouseRight;
			PlayerInput.CacheZoomableValues();
		}

		// Token: 0x06000EDF RID: 3807 RVA: 0x003EA6CF File Offset: 0x003E88CF
		public static void UpdateMainMouse()
		{
			Main.lastMouseX = Main.mouseX;
			Main.lastMouseY = Main.mouseY;
			Main.mouseX = PlayerInput.MouseX;
			Main.mouseY = PlayerInput.MouseY;
		}

		// Token: 0x06000ED4 RID: 3796 RVA: 0x003E9F14 File Offset: 0x003E8114
		public static void VerifyBuildingMode()
		{
			if (PlayerInput._InBuildingMode)
			{
				Player arg_23_0 = Main.player[Main.myPlayer];
				bool flag = false;
				if (Main.mouseItem.stack <= 0)
				{
					flag = true;
				}
				if (arg_23_0.dead)
				{
					flag = true;
				}
				if (flag)
				{
					PlayerInput.ExitBuildingMode();
				}
			}
		}

		// Token: 0x1700015D RID: 349
		public static bool CurrentlyRebinding
		{
			// Token: 0x06000EC8 RID: 3784 RVA: 0x003E9C07 File Offset: 0x003E7E07
			get
			{
				return PlayerInput._listeningTrigger != null;
			}
		}

		// Token: 0x1700015F RID: 351
		public static PlayerInputProfile CurrentProfile
		{
			// Token: 0x06000ECA RID: 3786 RVA: 0x003E9C88 File Offset: 0x003E7E88
			get
			{
				return PlayerInput._currentProfile;
			}
		}

		// Token: 0x17000167 RID: 359
		public static bool CursorIsBusy
		{
			// Token: 0x06000EDD RID: 3805 RVA: 0x003EA57B File Offset: 0x003E877B
			get
			{
				return ItemSlot.CircularRadialOpacity > 0f || ItemSlot.QuicksRadialOpacity > 0f;
			}
		}

		// Token: 0x17000163 RID: 355
		public static bool IgnoreMouseInterface
		{
			// Token: 0x06000ECE RID: 3790 RVA: 0x003E9CBF File Offset: 0x003E7EBF
			get
			{
				return PlayerInput.UsingGamepad && !UILinkPointNavigator.Available;
			}
		}

		// Token: 0x17000164 RID: 356
		public static bool InBuildingMode
		{
			// Token: 0x06000ED1 RID: 3793 RVA: 0x003E9E02 File Offset: 0x003E8002
			get
			{
				return PlayerInput._InBuildingMode;
			}
		}

		// Token: 0x1700015E RID: 350
		public static bool InvisibleGamepadInMenus
		{
			// Token: 0x06000EC9 RID: 3785 RVA: 0x003E9C14 File Offset: 0x003E7E14
			get
			{
				return ((Main.gameMenu || Main.ingameOptionsWindow || Main.playerInventory || Main.player[Main.myPlayer].talkNPC != -1 || Main.player[Main.myPlayer].sign != -1) && !PlayerInput._InBuildingMode && Main.InvisibleCursorForGamepad) || (PlayerInput.CursorIsBusy && !PlayerInput._InBuildingMode);
			}
		}

		// Token: 0x1700015C RID: 348
		public static string ListeningTrigger
		{
			// Token: 0x06000EC7 RID: 3783 RVA: 0x003E9C00 File Offset: 0x003E7E00
			get
			{
				return PlayerInput._listeningTrigger;
			}
		}

		// Token: 0x17000160 RID: 352
		public static KeyConfiguration ProfileGamepadUI
		{
			// Token: 0x06000ECB RID: 3787 RVA: 0x003E9C8F File Offset: 0x003E7E8F
			get
			{
				return PlayerInput.CurrentProfile.InputModes[InputMode.XBoxGamepadUI];
			}
		}

		// Token: 0x17000166 RID: 358
		public static int RealScreenHeight
		{
			// Token: 0x06000ED6 RID: 3798 RVA: 0x003E9F5C File Offset: 0x003E815C
			get
			{
				return PlayerInput._originalScreenHeight;
			}
		}

		// Token: 0x17000165 RID: 357
		public static int RealScreenWidth
		{
			// Token: 0x06000ED5 RID: 3797 RVA: 0x003E9F55 File Offset: 0x003E8155
			get
			{
				return PlayerInput._originalScreenWidth;
			}
		}

		// Token: 0x17000161 RID: 353
		public static bool UsingGamepad
		{
			// Token: 0x06000ECC RID: 3788 RVA: 0x003E9CA1 File Offset: 0x003E7EA1
			get
			{
				return PlayerInput.CurrentInputMode == InputMode.XBoxGamepad || PlayerInput.CurrentInputMode == InputMode.XBoxGamepadUI;
			}
		}

		// Token: 0x17000162 RID: 354
		public static bool UsingGamepadUI
		{
			// Token: 0x06000ECD RID: 3789 RVA: 0x003E9CB5 File Offset: 0x003E7EB5
			get
			{
				return PlayerInput.CurrentInputMode == InputMode.XBoxGamepadUI;
			}
		}

		// Token: 0x04002FFC RID: 12284
		public static string BlockedKey = "";

		// Token: 0x04003004 RID: 12292
		private static Buttons[] ButtonsGamepad = (Buttons[])Enum.GetValues(typeof(Buttons));

		// Token: 0x04003003 RID: 12291
		public static InputMode CurrentInputMode = InputMode.Keyboard;

		// Token: 0x04003024 RID: 12324
		private static int[] DpadSnapCooldown = new int[4];

		// Token: 0x04003016 RID: 12310
		public static bool GamepadAllowScrolling;

		// Token: 0x04003017 RID: 12311
		public static int GamepadScrollValue;

		// Token: 0x04003018 RID: 12312
		public static Vector2 GamepadThumbstickLeft = Vector2.Zero;

		// Token: 0x04003019 RID: 12313
		public static Vector2 GamepadThumbstickRight = Vector2.Zero;

		// Token: 0x04003005 RID: 12293
		public static bool GrappleAndInteractAreShared = false;

		// Token: 0x04002FF8 RID: 12280
		public static List<string> KnownTriggers = new List<string>
		{
			"MouseLeft",
			"MouseRight",
			"Up",
			"Down",
			"Left",
			"Right",
			"Jump",
			"Throw",
			"Inventory",
			"Grapple",
			"SmartSelect",
			"SmartCursor",
			"QuickMount",
			"QuickHeal",
			"QuickMana",
			"QuickBuff",
			"MapZoomIn",
			"MapZoomOut",
			"MapAlphaUp",
			"MapAlphaDown",
			"MapFull",
			"MapStyle",
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
			"HotbarMinus",
			"HotbarPlus",
			"DpadRadial1",
			"DpadRadial2",
			"DpadRadial3",
			"DpadRadial4",
			"RadialHotbar",
			"RadialQuickbar",
			"DpadSnap1",
			"DpadSnap2",
			"DpadSnap3",
			"DpadSnap4",
			"MenuUp",
			"MenuDown",
			"MenuLeft",
			"MenuRight",
			"LockOn",
			"ViewZoomIn",
			"ViewZoomOut"
		};

		// Token: 0x0400300C RID: 12300
		public static bool LockTileUseButton = false;

		// Token: 0x04003008 RID: 12296
		public static MouseState MouseInfo;

		// Token: 0x04003009 RID: 12297
		public static MouseState MouseInfoOld;

		// Token: 0x0400300D RID: 12301
		public static List<string> MouseKeys = new List<string>();

		// Token: 0x0400300A RID: 12298
		public static int MouseX;

		// Token: 0x0400300B RID: 12299
		public static int MouseY;

		// Token: 0x04002FFB RID: 12283
		public static int NavigatorRebindingLock = 0;

		// Token: 0x04003000 RID: 12288
		public static Dictionary<string, PlayerInputProfile> OriginalProfiles = new Dictionary<string, PlayerInputProfile>();

		// Token: 0x04003010 RID: 12304
		public static int PreLockOnX = 0;

		// Token: 0x04003011 RID: 12305
		public static int PreLockOnY = 0;

		// Token: 0x0400300E RID: 12302
		public static int PreUIX = 0;

		// Token: 0x0400300F RID: 12303
		public static int PreUIY = 0;

		// Token: 0x04002FFF RID: 12287
		public static Dictionary<string, PlayerInputProfile> Profiles = new Dictionary<string, PlayerInputProfile>();

		// Token: 0x04003014 RID: 12308
		public static int ScrollWheelDelta;

		// Token: 0x04003015 RID: 12309
		public static int ScrollWheelDeltaForUI;

		// Token: 0x04003012 RID: 12306
		public static int ScrollWheelValue;

		// Token: 0x04003013 RID: 12307
		public static int ScrollWheelValueOld;

		// Token: 0x04002FF7 RID: 12279
		public static TriggersPack Triggers = new TriggersPack();

		// Token: 0x0400301C RID: 12316
		public static bool WritingText = false;

		// Token: 0x04002FF9 RID: 12281
		private static bool _canReleaseRebindingLock = true;

		// Token: 0x04003002 RID: 12290
		private static PlayerInputProfile _currentProfile;

		// Token: 0x04003023 RID: 12323
		private static ZoomContext _currentWantedZoom;

		// Token: 0x0400301A RID: 12314
		private static bool _InBuildingMode = false;

		// Token: 0x04003006 RID: 12294
		private static string _invalidatorCheck = "";

		// Token: 0x04003007 RID: 12295
		private static bool _lastActivityState = false;

		// Token: 0x04002FFE RID: 12286
		private static InputMode _listeningInputMode;

		// Token: 0x04002FFD RID: 12285
		private static string _listeningTrigger;

		// Token: 0x04002FFA RID: 12282
		private static int _memoOfLastPoint = -1;

		// Token: 0x0400301F RID: 12319
		private static int _originalLastMouseX;

		// Token: 0x04003020 RID: 12320
		private static int _originalLastMouseY;

		// Token: 0x0400301D RID: 12317
		private static int _originalMouseX;

		// Token: 0x0400301E RID: 12318
		private static int _originalMouseY;

		// Token: 0x04003022 RID: 12322
		private static int _originalScreenHeight;

		// Token: 0x04003021 RID: 12321
		private static int _originalScreenWidth;

		// Token: 0x04003001 RID: 12289
		private static string _selectedProfile;

		// Token: 0x0400301B RID: 12315
		private static int _UIPointForBuildingMode = -1;

		// Token: 0x02000283 RID: 643
		public class MiscSettingsTEMP
		{
			// Token: 0x04003C63 RID: 15459
			public static bool HotbarRadialShouldBeUsed = true;
		}
	}
}

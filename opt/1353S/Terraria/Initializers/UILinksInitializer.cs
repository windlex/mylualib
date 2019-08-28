using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.States;
using Terraria.GameInput;
using Terraria.UI;
using Terraria.UI.Gamepad;

namespace Terraria.Initializers
{
	public class UILinksInitializer
	{
		public UILinksInitializer()
		{
		}

		public static void FancyExit()
		{
			switch (UILinkPointNavigator.Shortcuts.BackButtonCommand)
			{
				case 1:
					Main.PlaySound(11, -1, -1, 1, 1f, 0f);
					Main.menuMode = 0;
					return;
				case 2:
					Main.PlaySound(11, -1, -1, 1, 1f, 0f);
					Main.menuMode = (Main.menuMultiplayer ? 12 : 1);
					return;
				case 3:
					Main.menuMode = 0;
					IngameFancyUI.Close();
					return;
				case 4:
					Main.PlaySound(11, -1, -1, 1, 1f, 0f);
					Main.menuMode = 11;
					return;
				case 5:
					Main.PlaySound(11, -1, -1, 1, 1f, 0f);
					Main.menuMode = 11;
					return;
				case 6:
					UIVirtualKeyboard.Cancel();
					return;
				default:
					return;
			}
		}

		public static string FancyUISpecialInstructions()
		{
			string text = "";
			int fANCYUI_SPECIAL_INSTRUCTIONS = UILinkPointNavigator.Shortcuts.FANCYUI_SPECIAL_INSTRUCTIONS;
			if (fANCYUI_SPECIAL_INSTRUCTIONS == 1)
			{
				if (PlayerInput.Triggers.JustPressed.HotbarMinus)
				{
					UIVirtualKeyboard.CycleSymbols();
				}

				text += PlayerInput.BuildCommand(Lang.menu[235].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"]
				});
				if (PlayerInput.Triggers.JustPressed.MouseRight)
				{
					UIVirtualKeyboard.BackSpace();
				}

				text += PlayerInput.BuildCommand(Lang.menu[236].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]
				});
				if (PlayerInput.Triggers.JustPressed.SmartCursor)
				{
					UIVirtualKeyboard.Write(" ");
				}

				text += PlayerInput.BuildCommand(Lang.menu[238].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["SmartCursor"]
				});
				if (UIVirtualKeyboard.CanSubmit)
				{
					if (PlayerInput.Triggers.JustPressed.HotbarPlus)
					{
						UIVirtualKeyboard.Submit();
					}

					text += PlayerInput.BuildCommand(Lang.menu[237].Value, false, new List<string>[]
					{
						PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
					});
				}
			}

			return text;
		}

		public static void HandleOptionsSpecials()
		{
			switch (UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE)
			{
				case 1:
					Main.bgScroll = (int)UILinksInitializer.HandleSlider((float)Main.bgScroll, 0f, 100f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 1f);
					Main.caveParallax = 1f - (float)Main.bgScroll / 500f;
					return;
				case 2:
					Main.musicVolume = UILinksInitializer.HandleSlider(Main.musicVolume, 0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f);
					return;
				case 3:
					Main.soundVolume = UILinksInitializer.HandleSlider(Main.soundVolume, 0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f);
					return;
				case 4:
					Main.ambientVolume = UILinksInitializer.HandleSlider(Main.ambientVolume, 0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f);
					return;
				case 5:
					{
						float expr_100 = Main.hBar;
						float num = Main.hBar = UILinksInitializer.HandleSlider(expr_100, 0f, 1f, 0.2f, 0.5f);
						if (expr_100 != num)
						{
							int menuMode = Main.menuMode;
							switch (menuMode)
							{
								case 17:
									Main.player[Main.myPlayer].hairColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
									break;
								case 18:
									Main.player[Main.myPlayer].eyeColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
									break;
								case 19:
									Main.player[Main.myPlayer].skinColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
									break;
								case 20:
									break;
								case 21:
									Main.player[Main.myPlayer].shirtColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
									break;
								case 22:
									Main.player[Main.myPlayer].underShirtColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
									break;
								case 23:
									Main.player[Main.myPlayer].pantsColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
									break;
								case 24:
									Main.player[Main.myPlayer].shoeColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
									break;
								case 25:
									Main.mouseColorSlider.Hue = num;
									break;
								default:
									if (menuMode == 252)
									{
										Main.mouseBorderColorSlider.Hue = num;
									}

									break;
							}

							Main.PlaySound(12, -1, -1, 1, 1f, 0f);
							return;
						}

						break;
					}

				case 6:
					{
						float expr_2DD = Main.sBar;
						float num2 = Main.sBar = UILinksInitializer.HandleSlider(expr_2DD, 0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.5f);
						if (expr_2DD != num2)
						{
							int menuMode = Main.menuMode;
							switch (menuMode)
							{
								case 17:
									Main.player[Main.myPlayer].hairColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
									break;
								case 18:
									Main.player[Main.myPlayer].eyeColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
									break;
								case 19:
									Main.player[Main.myPlayer].skinColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
									break;
								case 20:
									break;
								case 21:
									Main.player[Main.myPlayer].shirtColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
									break;
								case 22:
									Main.player[Main.myPlayer].underShirtColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
									break;
								case 23:
									Main.player[Main.myPlayer].pantsColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
									break;
								case 24:
									Main.player[Main.myPlayer].shoeColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
									break;
								case 25:
									Main.mouseColorSlider.Saturation = num2;
									break;
								default:
									if (menuMode == 252)
									{
										Main.mouseBorderColorSlider.Saturation = num2;
									}

									break;
							}

							Main.PlaySound(12, -1, -1, 1, 1f, 0f);
							return;
						}

						break;
					}

				case 7:
					{
						float arg_4D7_0 = Main.lBar;
						float min = 0.15f;
						if (Main.menuMode == 252)
						{
							min = 0f;
						}

						float num3 = Main.lBar = UILinksInitializer.HandleSlider(arg_4D7_0, min, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.5f);
						if (arg_4D7_0 != num3)
						{
							int menuMode = Main.menuMode;
							switch (menuMode)
							{
								case 17:
									Main.player[Main.myPlayer].hairColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
									break;
								case 18:
									Main.player[Main.myPlayer].eyeColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
									break;
								case 19:
									Main.player[Main.myPlayer].skinColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
									break;
								case 20:
									break;
								case 21:
									Main.player[Main.myPlayer].shirtColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
									break;
								case 22:
									Main.player[Main.myPlayer].underShirtColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
									break;
								case 23:
									Main.player[Main.myPlayer].pantsColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
									break;
								case 24:
									Main.player[Main.myPlayer].shoeColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
									break;
								case 25:
									Main.mouseColorSlider.Luminance = num3;
									break;
								default:
									if (menuMode == 252)
									{
										Main.mouseBorderColorSlider.Luminance = num3;
									}

									break;
							}

							Main.PlaySound(12, -1, -1, 1, 1f, 0f);
							return;
						}

						break;
					}

				case 8:
					{
						float expr_6B9 = Main.aBar;
						float num4 = Main.aBar = UILinksInitializer.HandleSlider(expr_6B9, 0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.5f);
						if (expr_6B9 != num4)
						{
							int menuMode = Main.menuMode;
							if (menuMode == 252)
							{
								Main.mouseBorderColorSlider.Alpha = num4;
							}

							Main.PlaySound(12, -1, -1, 1, 1f, 0f);
							return;
						}

						break;
					}

				case 9:
					{
						bool left = PlayerInput.Triggers.Current.Left;
						bool right = PlayerInput.Triggers.Current.Right;
						if (PlayerInput.Triggers.JustPressed.Left || PlayerInput.Triggers.JustPressed.Right)
						{
							UILinksInitializer.SomeVarsForUILinkers.HairMoveCD = 0;
						}
						else if (UILinksInitializer.SomeVarsForUILinkers.HairMoveCD > 0)
						{
							UILinksInitializer.SomeVarsForUILinkers.HairMoveCD--;
						}

						if (UILinksInitializer.SomeVarsForUILinkers.HairMoveCD == 0 && (left | right))
						{
							if (left)
							{
								Main.PendingPlayer.hair--;
							}

							if (right)
							{
								Main.PendingPlayer.hair++;
							}

							UILinksInitializer.SomeVarsForUILinkers.HairMoveCD = 12;
						}

						int num5 = 51;
						if (Main.PendingPlayer.hair >= num5)
						{
							Main.PendingPlayer.hair = 0;
						}

						if (Main.PendingPlayer.hair < 0)
						{
							Main.PendingPlayer.hair = num5 - 1;
							return;
						}

						break;
					}

				case 10:
					Main.GameZoomTarget = UILinksInitializer.HandleSlider(Main.GameZoomTarget, 1f, 2f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f);
					return;
				case 11:
					Main.UIScale = UILinksInitializer.HandleSlider(Main.UIScaleWanted, 1f, 2f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f);
					Main.temporaryGUIScaleSlider = Main.UIScaleWanted;
					break;
				default:
					return;
			}
		}

		public static float HandleSlider(float currentValue, float min, float max, float deadZone = 0.2f, float sensitivity = 0.5f)
		{
			float num = PlayerInput.GamepadThumbstickLeft.X;
			if (num < -deadZone || num > deadZone)
			{
				num = MathHelper.Lerp(0f, sensitivity / 60f, (Math.Abs(num) - deadZone) / (1f - deadZone)) * (float)Math.Sign(num);
			}
			else
			{
				num = 0f;
			}

			return MathHelper.Clamp((currentValue - min) / (max - min) + num, 0f, 1f) * (max - min) + min;
		}

		public static void Load()
		{
			Func<string> arg_1F_0 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[53].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
				});
			});

			Func<string> value = arg_1F_0;
			UILinkPage uILinkPage = new UILinkPage();
			UILinkPage arg_46_0 = uILinkPage;
			Action arg_46_1 = new Action(() => {
				PlayerInput.GamepadAllowScrolling = true;
			});

			arg_46_0.UpdateEvent += arg_46_1;
			for (int i = 0; i < 20; i++)
			{
				uILinkPage.LinkMap.Add(2000 + i, new UILinkPoint(2000 + i, true, -3, -4, -1, -2));
			}

			UILinkPage arg_9E_0 = uILinkPage;
			Func<string> arg_9E_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[53].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
				}) + PlayerInput.BuildCommand(Lang.misc[82].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				});
			});

			arg_9E_0.OnSpecialInteracts += arg_9E_1;
			UILinkPage arg_C3_0 = uILinkPage;
			Action arg_C3_1 = new Action(() => {
				if (PlayerInput.Triggers.JustPressed.Inventory)
				{
					UILinksInitializer.FancyExit();
				}

				UILinkPointNavigator.Shortcuts.BackButtonInUse = PlayerInput.Triggers.JustPressed.Inventory;
				UILinksInitializer.HandleOptionsSpecials();
			});

			arg_C3_0.UpdateEvent += arg_C3_1;
			UILinkPage arg_E8_0 = uILinkPage;
			Func<bool> arg_E8_1 = new Func<bool>(() => {
				return Main.gameMenu && !Main.MenuUI.IsVisible;
			});

			arg_E8_0.IsValidEvent += arg_E8_1;
			UILinkPage arg_10D_0 = uILinkPage;
			Func<bool> arg_10D_1 = new Func<bool>(() => {
				return Main.gameMenu && !Main.MenuUI.IsVisible;
			});

			arg_10D_0.CanEnterEvent += arg_10D_1;
			UILinkPointNavigator.RegisterPage(uILinkPage, 1000, true);
			UILinkPage cp2 = new UILinkPage();
			cp2.LinkMap.Add(2500, new UILinkPoint(2500, true, -3, 2501, -1, -2));
			cp2.LinkMap.Add(2501, new UILinkPoint(2501, true, 2500, 2502, -1, -2));
			cp2.LinkMap.Add(2502, new UILinkPoint(2502, true, 2501, -4, -1, -2));
			cp2.UpdateEvent += delegate
			{
				cp2.LinkMap[2501].Right = (UILinkPointNavigator.Shortcuts.NPCCHAT_ButtonsRight ? 2502 : -4);
			};
			UILinkPage arg_1EC_0 = cp2;
			Func<string> arg_1EC_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[53].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
				}) + PlayerInput.BuildCommand(Lang.misc[56].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				});
			});

			arg_1EC_0.OnSpecialInteracts += arg_1EC_1;
			UILinkPage arg_216_0 = cp2;
			Func<bool> arg_216_1 = new Func<bool>(() => {
				return (Main.player[Main.myPlayer].talkNPC != -1 || Main.player[Main.myPlayer].sign != -1) && UILinksInitializer.NothingMoreImportantThanNPCChat();
			});

			arg_216_0.IsValidEvent += arg_216_1;
			UILinkPage arg_240_0 = cp2;
			Func<bool> arg_240_1 = new Func<bool>(() => {
				return (Main.player[Main.myPlayer].talkNPC != -1 || Main.player[Main.myPlayer].sign != -1) && UILinksInitializer.NothingMoreImportantThanNPCChat();
			});

			arg_240_0.CanEnterEvent += arg_240_1;
			UILinkPage arg_26A_0 = cp2;
			Action arg_26A_1 = new Action(() => {
				Main.player[Main.myPlayer].releaseInventory = false;
			});

			arg_26A_0.EnterEvent += arg_26A_1;
			UILinkPage arg_294_0 = cp2;
			Action arg_294_1 = new Action(() => {
				Main.npcChatRelease = false;
				Main.player[Main.myPlayer].releaseUseTile = false;
			});

			arg_294_0.LeaveEvent += arg_294_1;
			UILinkPointNavigator.RegisterPage(cp2, 1003, true);
			UILinkPage cp3 = new UILinkPage();
			UILinkPage arg_2E3_0 = cp3;
			Func<string> arg_2E3_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"],
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				});
			});

			arg_2E3_0.OnSpecialInteracts += arg_2E3_1;
			Func<string> arg_307_0 = new Func<string>(() => {
				int currentPoint = UILinkPointNavigator.CurrentPoint;
				return ItemSlot.GetGamepadInstructions(Main.player[Main.myPlayer].inventory, 0, currentPoint);
			});

			Func<string> value2 = arg_307_0;
			Func<string> arg_328_0 = new Func<string>(() => {
				return ItemSlot.GetGamepadInstructions(ref Main.player[Main.myPlayer].trashItem, 6);
			});

			Func<string> value3 = arg_328_0;
			for (int j = 0; j <= 49; j++)
			{
				UILinkPoint uILinkPoint = new UILinkPoint(j, true, j - 1, j + 1, j - 10, j + 10);
				uILinkPoint.OnSpecialInteracts += value2;
				int expr_356 = j;
				if (expr_356 < 10)
				{
					uILinkPoint.Up = -1;
				}

				if (expr_356 >= 40)
				{
					uILinkPoint.Down = -2;
				}

				if (expr_356 % 10 == 9)
				{
					uILinkPoint.Right = -4;
				}

				if (expr_356 % 10 == 0)
				{
					uILinkPoint.Left = -3;
				}

				cp3.LinkMap.Add(j, uILinkPoint);
			}

			cp3.LinkMap[9].Right = 0;
			cp3.LinkMap[19].Right = 50;
			cp3.LinkMap[29].Right = 51;
			cp3.LinkMap[39].Right = 52;
			cp3.LinkMap[49].Right = 53;
			cp3.LinkMap[0].Left = 9;
			cp3.LinkMap[10].Left = 54;
			cp3.LinkMap[20].Left = 55;
			cp3.LinkMap[30].Left = 56;
			cp3.LinkMap[40].Left = 57;
			cp3.LinkMap.Add(300, new UILinkPoint(300, true, 302, 301, 49, -2));
			cp3.LinkMap.Add(301, new UILinkPoint(301, true, 300, 302, 53, 50));
			cp3.LinkMap.Add(302, new UILinkPoint(302, true, 301, 300, 57, 54));
			cp3.LinkMap[301].OnSpecialInteracts += value;
			cp3.LinkMap[302].OnSpecialInteracts += value;
			cp3.LinkMap[300].OnSpecialInteracts += value3;
			cp3.UpdateEvent += delegate
			{
				bool inReforgeMenu = Main.InReforgeMenu;
				bool flag = Main.player[Main.myPlayer].chest != -1;
				bool flag2 = Main.npcShop != 0;
				for (int num20 = 40; num20 <= 49; num20++)
				{
					if (inReforgeMenu)
					{
						cp3.LinkMap[num20].Down = ((num20 < 45) ? 303 : 304);
					}
					else if (flag)
					{
						cp3.LinkMap[num20].Down = 400 + num20 - 40;
					}
					else if (flag2)
					{
						cp3.LinkMap[num20].Down = 2700 + num20 - 40;
					}
					else
					{
						cp3.LinkMap[num20].Down = -2;
					}
				}

				if (flag)
				{
					cp3.LinkMap[300].Up = 439;
					cp3.LinkMap[300].Right = -4;
					cp3.LinkMap[300].Left = -3;
				}
				else if (flag2)
				{
					cp3.LinkMap[300].Up = 2739;
					cp3.LinkMap[300].Right = -4;
					cp3.LinkMap[300].Left = -3;
				}
				else
				{
					cp3.LinkMap[300].Up = 49;
					cp3.LinkMap[300].Right = 301;
					cp3.LinkMap[300].Left = 302;
					cp3.LinkMap[49].Down = 300;
				}

				cp3.LinkMap[10].Left = 54;
				cp3.LinkMap[20].Left = 55;
				cp3.LinkMap[30].Left = 56;
				cp3.LinkMap[40].Left = 57;
				if (UILinkPointNavigator.Shortcuts.BUILDERACCCOUNT > 8)
				{
					cp3.LinkMap[0].Left = 4000;
					cp3.LinkMap[10].Left = 4002;
					cp3.LinkMap[20].Left = 4004;
					cp3.LinkMap[30].Left = 4006;
					cp3.LinkMap[40].Left = 4008;
				}
				else
				{
					cp3.LinkMap[0].Left = 9;
					if (UILinkPointNavigator.Shortcuts.BUILDERACCCOUNT > 0)
					{
						cp3.LinkMap[10].Left = 4000;
					}

					if (UILinkPointNavigator.Shortcuts.BUILDERACCCOUNT > 2)
					{
						cp3.LinkMap[20].Left = 4002;
					}

					if (UILinkPointNavigator.Shortcuts.BUILDERACCCOUNT > 4)
					{
						cp3.LinkMap[30].Left = 4004;
					}

					if (UILinkPointNavigator.Shortcuts.BUILDERACCCOUNT > 6)
					{
						cp3.LinkMap[40].Left = 4006;
					}
				}

				cp3.PageOnLeft = (Main.InReforgeMenu ? 5 : 9);
			};
			UILinkPage arg_5D7_0 = cp3;
			Func<bool> arg_5D7_1 = new Func<bool>(() => {
				return Main.playerInventory;
			});

			arg_5D7_0.IsValidEvent += arg_5D7_1;
			cp3.PageOnLeft = 9;
			cp3.PageOnRight = 2;
			UILinkPointNavigator.RegisterPage(cp3, 0, true);
			UILinkPage cp4 = new UILinkPage();
			UILinkPage arg_63E_0 = cp4;
			Func<string> arg_63E_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"],
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				});
			});

			arg_63E_0.OnSpecialInteracts += arg_63E_1;
			Func<string> arg_662_0 = new Func<string>(() => {
				int currentPoint = UILinkPointNavigator.CurrentPoint;
				return ItemSlot.GetGamepadInstructions(Main.player[Main.myPlayer].inventory, 1, currentPoint);
			});

			Func<string> value4 = arg_662_0;
			for (int k = 50; k <= 53; k++)
			{
				UILinkPoint uILinkPoint2 = new UILinkPoint(k, true, -3, -4, k - 1, k + 1);
				uILinkPoint2.OnSpecialInteracts += value4;
				cp4.LinkMap.Add(k, uILinkPoint2);
			}

			cp4.LinkMap[50].Left = 19;
			cp4.LinkMap[51].Left = 29;
			cp4.LinkMap[52].Left = 39;
			cp4.LinkMap[53].Left = 49;
			cp4.LinkMap[50].Right = 54;
			cp4.LinkMap[51].Right = 55;
			cp4.LinkMap[52].Right = 56;
			cp4.LinkMap[53].Right = 57;
			cp4.LinkMap[50].Up = -1;
			cp4.LinkMap[53].Down = -2;
			cp4.UpdateEvent += delegate
			{
				if (Main.player[Main.myPlayer].chest == -1 && Main.npcShop == 0)
				{
					cp4.LinkMap[50].Up = 301;
					cp4.LinkMap[53].Down = 301;
					return;
				}

				cp4.LinkMap[50].Up = 504;
				cp4.LinkMap[53].Down = 500;
			};
			UILinkPage arg_7EC_0 = cp4;
			Func<bool> arg_7EC_1 = new Func<bool>(() => {
				return Main.playerInventory;
			});

			arg_7EC_0.IsValidEvent += arg_7EC_1;
			cp4.PageOnLeft = 0;
			cp4.PageOnRight = 2;
			UILinkPointNavigator.RegisterPage(cp4, 1, true);
			UILinkPage cp5 = new UILinkPage();
			UILinkPage arg_852_0 = cp5;
			Func<string> arg_852_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"],
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				});
			});

			arg_852_0.OnSpecialInteracts += arg_852_1;
			Func<string> arg_876_0 = new Func<string>(() => {
				int currentPoint = UILinkPointNavigator.CurrentPoint;
				return ItemSlot.GetGamepadInstructions(Main.player[Main.myPlayer].inventory, 2, currentPoint);
			});

			Func<string> value5 = arg_876_0;
			for (int l = 54; l <= 57; l++)
			{
				UILinkPoint uILinkPoint3 = new UILinkPoint(l, true, -3, -4, l - 1, l + 1);
				uILinkPoint3.OnSpecialInteracts += value5;
				cp5.LinkMap.Add(l, uILinkPoint3);
			}

			cp5.LinkMap[54].Left = 50;
			cp5.LinkMap[55].Left = 51;
			cp5.LinkMap[56].Left = 52;
			cp5.LinkMap[57].Left = 53;
			cp5.LinkMap[54].Right = 10;
			cp5.LinkMap[55].Right = 20;
			cp5.LinkMap[56].Right = 30;
			cp5.LinkMap[57].Right = 40;
			cp5.LinkMap[54].Up = -1;
			cp5.LinkMap[57].Down = -2;
			cp5.UpdateEvent += delegate
			{
				if (Main.player[Main.myPlayer].chest == -1 && Main.npcShop == 0)
				{
					cp5.LinkMap[54].Up = 302;
					cp5.LinkMap[57].Down = 302;
					return;
				}

				cp5.LinkMap[54].Up = 504;
				cp5.LinkMap[57].Down = 500;
			};
			cp5.PageOnLeft = 0;
			cp5.PageOnRight = 8;
			UILinkPointNavigator.RegisterPage(cp5, 2, true);
			UILinkPage cp6 = new UILinkPage();
			UILinkPage arg_A3B_0 = cp6;
			Func<string> arg_A3B_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"],
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				});
			});

			arg_A3B_0.OnSpecialInteracts += arg_A3B_1;
			Func<string> arg_A5F_0 = new Func<string>(() => {
				int num = UILinkPointNavigator.CurrentPoint - 100;
				return ItemSlot.GetGamepadInstructions(Main.player[Main.myPlayer].armor, (num < 10) ? 8 : 9, num);
			});

			Func<string> value6 = arg_A5F_0;
			Func<string> arg_A80_0 = new Func<string>(() => {
				int slot = UILinkPointNavigator.CurrentPoint - 120;
				return ItemSlot.GetGamepadInstructions(Main.player[Main.myPlayer].dye, 12, slot);
			});

			Func<string> value7 = arg_A80_0;
			for (int m = 100; m <= 119; m++)
			{
				UILinkPoint uILinkPoint4 = new UILinkPoint(m, true, m + 10, m - 10, m - 1, m + 1);
				uILinkPoint4.OnSpecialInteracts += value6;
				int num = m - 100;
				if (num == 0)
				{
					uILinkPoint4.Up = 305;
				}

				if (num == 10)
				{
					uILinkPoint4.Up = 306;
				}

				if (num == 9 || num == 19)
				{
					uILinkPoint4.Down = -2;
				}

				if (num >= 10)
				{
					uILinkPoint4.Left = 120 + num % 10;
				}
				else
				{
					uILinkPoint4.Right = -4;
				}

				cp6.LinkMap.Add(m, uILinkPoint4);
			}

			for (int n = 120; n <= 129; n++)
			{
				UILinkPoint uILinkPoint4 = new UILinkPoint(n, true, -3, -10 + n, n - 1, n + 1);
				uILinkPoint4.OnSpecialInteracts += value7;
				int expr_B5F = n - 120;
				if (expr_B5F == 0)
				{
					uILinkPoint4.Up = 307;
				}

				if (expr_B5F == 9)
				{
					uILinkPoint4.Down = 308;
					uILinkPoint4.Left = 1557;
				}

				cp6.LinkMap.Add(n, uILinkPoint4);
			}

			UILinkPage arg_BD4_0 = cp6;
			Func<bool> arg_BD4_1 = new Func<bool>(() => {
				return Main.playerInventory && Main.EquipPage == 0;
			});

			arg_BD4_0.IsValidEvent += arg_BD4_1;
			cp6.UpdateEvent += delegate
			{
				int num20 = 107;
				int extraAccessorySlots = Main.player[Main.myPlayer].extraAccessorySlots;
				for (int num21 = 0; num21 < extraAccessorySlots; num21++)
				{
					cp6.LinkMap[num20 + num21].Down = num20 + num21 + 1;
					cp6.LinkMap[num20 - 100 + 120 + num21].Down = num20 - 100 + 120 + num21 + 1;
					cp6.LinkMap[num20 + 10 + num21].Down = num20 + 10 + num21 + 1;
				}

				cp6.LinkMap[num20 + extraAccessorySlots].Down = 308;
				cp6.LinkMap[num20 - 100 + 120 + extraAccessorySlots].Down = 308;
				cp6.LinkMap[num20 + 10 + extraAccessorySlots].Down = 308;
				bool shouldPVPDraw = Main.ShouldPVPDraw;
				for (int num22 = 120; num22 <= 129; num22++)
				{
					UILinkPoint uILinkPoint15 = cp6.LinkMap[num22];
					int expr_111 = num22 - 120;
					if (expr_111 == 0)
					{
						uILinkPoint15.Left = (shouldPVPDraw ? 1550 : -3);
					}

					if (expr_111 == 1)
					{
						uILinkPoint15.Left = (shouldPVPDraw ? 1552 : -3);
					}

					if (expr_111 == 2)
					{
						uILinkPoint15.Left = (shouldPVPDraw ? 1556 : -3);
					}

					if (expr_111 == 3)
					{
						uILinkPoint15.Left = ((UILinkPointNavigator.Shortcuts.INFOACCCOUNT >= 1) ? 1558 : -3);
					}

					if (expr_111 == 4)
					{
						uILinkPoint15.Left = ((UILinkPointNavigator.Shortcuts.INFOACCCOUNT >= 5) ? 1562 : -3);
					}

					if (expr_111 == 5)
					{
						uILinkPoint15.Left = ((UILinkPointNavigator.Shortcuts.INFOACCCOUNT >= 9) ? 1566 : -3);
					}

					if (expr_111 == 7)
					{
						uILinkPoint15.Left = (shouldPVPDraw ? 1557 : -3);
					}
				}
			};
			cp6.PageOnLeft = 8;
			cp6.PageOnRight = 8;
			UILinkPointNavigator.RegisterPage(cp6, 3, true);
			UILinkPage uILinkPage2 = new UILinkPage();
			UILinkPage arg_C42_0 = uILinkPage2;
			Func<string> arg_C42_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"],
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				});
			});

			arg_C42_0.OnSpecialInteracts += arg_C42_1;
			Func<string> arg_C66_0 = new Func<string>(() => {
				int slot = UILinkPointNavigator.CurrentPoint - 400;
				int context = 4;
				Item[] item = Main.player[Main.myPlayer].bank.item;
				switch (Main.player[Main.myPlayer].chest)
				{
					case -4:
						item = Main.player[Main.myPlayer].bank3.item;
						break;
					case -3:
						item = Main.player[Main.myPlayer].bank2.item;
						break;
					case -2:
						break;
					case -1:
						return "";
					default:
						item = Main.chest[Main.player[Main.myPlayer].chest].item;
						context = 3;
						break;
				}

				return ItemSlot.GetGamepadInstructions(item, context, slot);
			});

			Func<string> value8 = arg_C66_0;
			for (int num2 = 400; num2 <= 439; num2++)
			{
				UILinkPoint uILinkPoint5 = new UILinkPoint(num2, true, num2 - 1, num2 + 1, num2 - 10, num2 + 10);
				uILinkPoint5.OnSpecialInteracts += value8;
				int num3 = num2 - 400;
				if (num3 < 10)
				{
					uILinkPoint5.Up = 40 + num3;
				}

				if (num3 >= 30)
				{
					uILinkPoint5.Down = -2;
				}

				if (num3 % 10 == 9)
				{
					uILinkPoint5.Right = -4;
				}

				if (num3 % 10 == 0)
				{
					uILinkPoint5.Left = -3;
				}

				uILinkPage2.LinkMap.Add(num2, uILinkPoint5);
			}

			uILinkPage2.LinkMap.Add(500, new UILinkPoint(500, true, 409, -4, 53, 501));
			uILinkPage2.LinkMap.Add(501, new UILinkPoint(501, true, 419, -4, 500, 502));
			uILinkPage2.LinkMap.Add(502, new UILinkPoint(502, true, 429, -4, 501, 503));
			uILinkPage2.LinkMap.Add(503, new UILinkPoint(503, true, 439, -4, 502, 505));
			uILinkPage2.LinkMap.Add(505, new UILinkPoint(505, true, 439, -4, 503, 504));
			uILinkPage2.LinkMap.Add(504, new UILinkPoint(504, true, 439, -4, 505, 50));
			uILinkPage2.LinkMap[500].OnSpecialInteracts += value;
			uILinkPage2.LinkMap[501].OnSpecialInteracts += value;
			uILinkPage2.LinkMap[502].OnSpecialInteracts += value;
			uILinkPage2.LinkMap[503].OnSpecialInteracts += value;
			uILinkPage2.LinkMap[504].OnSpecialInteracts += value;
			uILinkPage2.LinkMap[505].OnSpecialInteracts += value;
			uILinkPage2.LinkMap[409].Right = 500;
			uILinkPage2.LinkMap[419].Right = 501;
			uILinkPage2.LinkMap[429].Right = 502;
			uILinkPage2.LinkMap[439].Right = 503;
			uILinkPage2.LinkMap[439].Down = 300;
			uILinkPage2.PageOnLeft = 0;
			uILinkPage2.PageOnRight = 0;
			uILinkPage2.DefaultPoint = 500;
			UILinkPointNavigator.RegisterPage(uILinkPage2, 4, false);
			UILinkPage arg_F67_0 = uILinkPage2;
			Func<bool> arg_F67_1 = new Func<bool>(() => {
				return Main.playerInventory && Main.player[Main.myPlayer].chest != -1;
			});

			arg_F67_0.IsValidEvent += arg_F67_1;
			UILinkPage uILinkPage3 = new UILinkPage();
			UILinkPage arg_F94_0 = uILinkPage3;
			Func<string> arg_F94_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"],
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				});
			});

			arg_F94_0.OnSpecialInteracts += arg_F94_1;
			Func<string> arg_FB8_0 = new Func<string>(() => {
				int slot = UILinkPointNavigator.CurrentPoint - 2700;
				return ItemSlot.GetGamepadInstructions(Main.instance.shop[Main.npcShop].item, 15, slot);
			});

			Func<string> value9 = arg_FB8_0;
			for (int num4 = 2700; num4 <= 2739; num4++)
			{
				UILinkPoint uILinkPoint6 = new UILinkPoint(num4, true, num4 - 1, num4 + 1, num4 - 10, num4 + 10);
				uILinkPoint6.OnSpecialInteracts += value9;
				int num5 = num4 - 2700;
				if (num5 < 10)
				{
					uILinkPoint6.Up = 40 + num5;
				}

				if (num5 >= 30)
				{
					uILinkPoint6.Down = -2;
				}

				if (num5 % 10 == 9)
				{
					uILinkPoint6.Right = -4;
				}

				if (num5 % 10 == 0)
				{
					uILinkPoint6.Left = -3;
				}

				uILinkPage3.LinkMap.Add(num4, uILinkPoint6);
			}

			uILinkPage3.LinkMap[2739].Down = 300;
			uILinkPage3.PageOnLeft = 0;
			uILinkPage3.PageOnRight = 0;
			UILinkPointNavigator.RegisterPage(uILinkPage3, 13, true);
			UILinkPage arg_10B0_0 = uILinkPage3;
			Func<bool> arg_10B0_1 = new Func<bool>(() => {
				return Main.playerInventory && Main.npcShop != 0;
			});

			arg_10B0_0.IsValidEvent += arg_10B0_1;
			UILinkPage cp7 = new UILinkPage();
			cp7.LinkMap.Add(303, new UILinkPoint(303, true, 304, 304, 40, -2));
			cp7.LinkMap.Add(304, new UILinkPoint(304, true, 303, 303, 40, -2));
			UILinkPage arg_114C_0 = cp7;
			Func<string> arg_114C_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"],
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				});
			});

			arg_114C_0.OnSpecialInteracts += arg_114C_1;
			Func<string> arg_1170_0 = new Func<string>(() => {
				return ItemSlot.GetGamepadInstructions(ref Main.reforgeItem, 5);
			});

			Func<string> value10 = arg_1170_0;
			cp7.LinkMap[303].OnSpecialInteracts += value10;
			UILinkPoint arg_11C4_0 = cp7.LinkMap[304];
			Func<string> arg_11C4_1 = new Func<string>(() => {
				return Lang.misc[53].Value;
			});

			arg_11C4_0.OnSpecialInteracts += arg_11C4_1;
			cp7.UpdateEvent += delegate
			{
				if (Main.reforgeItem.type > 0)
				{
					cp7.LinkMap[303].Left = (cp7.LinkMap[303].Right = 304);
					return;
				}

				if (UILinkPointNavigator.OverridePoint == -1 && cp7.CurrentPoint == 304)
				{
					UILinkPointNavigator.ChangePoint(303);
				}

				cp7.LinkMap[303].Left = -3;
				cp7.LinkMap[303].Right = -4;
			};
			UILinkPage arg_1208_0 = cp7;
			Func<bool> arg_1208_1 = new Func<bool>(() => {
				return Main.playerInventory && Main.InReforgeMenu;
			});

			arg_1208_0.IsValidEvent += arg_1208_1;
			cp7.PageOnLeft = 0;
			cp7.PageOnRight = 0;
			UILinkPointNavigator.RegisterPage(cp7, 5, true);
			UILinkPage cp8 = new UILinkPage();
			UILinkPage arg_126E_0 = cp8;
			Func<string> arg_126E_1 = new Func<string>(() => {
				if (PlayerInput.Triggers.JustPressed.Grapple)
				{
					Point point = Main.player[Main.myPlayer].Center.ToTileCoordinates();
					if (UILinkPointNavigator.CurrentPoint == 600)
					{
						if (WorldGen.MoveTownNPC(point.X, point.Y, -1))
						{
							Main.NewText(Lang.inter[39].Value, 255, 240, 20, false);
						}

						Main.PlaySound(12, -1, -1, 1, 1f, 0f);
					}
					else if (WorldGen.MoveTownNPC(point.X, point.Y, UILinkPointNavigator.Shortcuts.NPCS_LastHovered))
					{
						WorldGen.moveRoom(point.X, point.Y, UILinkPointNavigator.Shortcuts.NPCS_LastHovered);
						Main.PlaySound(12, -1, -1, 1, 1f, 0f);
					}
				}

				if (PlayerInput.Triggers.JustPressed.SmartSelect)
				{
					UILinkPointNavigator.Shortcuts.NPCS_IconsDisplay = !UILinkPointNavigator.Shortcuts.NPCS_IconsDisplay;
				}

				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + PlayerInput.BuildCommand(Lang.misc[64].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"],
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				}) + PlayerInput.BuildCommand(Lang.misc[70].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]
				}) + PlayerInput.BuildCommand(Lang.misc[69].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["SmartSelect"]
				});
			});

			arg_126E_0.OnSpecialInteracts += arg_126E_1;
			for (int num6 = 600; num6 <= 650; num6++)
			{
				UILinkPoint value11 = new UILinkPoint(num6, true, num6 + 10, num6 - 10, num6 - 1, num6 + 1);
				cp8.LinkMap.Add(num6, value11);
			}

			cp8.UpdateEvent += delegate
			{
				int num20 = UILinkPointNavigator.Shortcuts.NPCS_IconsPerColumn;
				if (num20 == 0)
				{
					num20 = 100;
				}

				for (int num21 = 0; num21 < 50; num21++)
				{
					cp8.LinkMap[600 + num21].Up = ((num21 % num20 == 0) ? -1 : (600 + num21 - 1));
					if (cp8.LinkMap[600 + num21].Up == -1)
					{
						if (num21 >= num20 * 2)
						{
							cp8.LinkMap[600 + num21].Up = 307;
						}
						else if (num21 >= num20)
						{
							cp8.LinkMap[600 + num21].Up = 306;
						}
						else
						{
							cp8.LinkMap[600 + num21].Up = 305;
						}
					}

					cp8.LinkMap[600 + num21].Down = (((num21 + 1) % num20 == 0 || num21 == UILinkPointNavigator.Shortcuts.NPCS_IconsTotal - 1) ? 308 : (600 + num21 + 1));
					cp8.LinkMap[600 + num21].Left = ((num21 < UILinkPointNavigator.Shortcuts.NPCS_IconsTotal - num20) ? (600 + num21 + num20) : -3);
					cp8.LinkMap[600 + num21].Right = ((num21 < num20) ? -4 : (600 + num21 - num20));
				}
			};
			UILinkPage arg_12FB_0 = cp8;
			Func<bool> arg_12FB_1 = new Func<bool>(() => {
				return Main.playerInventory && Main.EquipPage == 1;
			});

			arg_12FB_0.IsValidEvent += arg_12FB_1;
			cp8.PageOnLeft = 8;
			cp8.PageOnRight = 8;
			UILinkPointNavigator.RegisterPage(cp8, 6, true);
			UILinkPage cp9 = new UILinkPage();
			UILinkPage arg_1361_0 = cp9;
			Func<string> arg_1361_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"],
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				});
			});

			arg_1361_0.OnSpecialInteracts += arg_1361_1;
			Func<string> arg_1385_0 = new Func<string>(() => {
				int slot = UILinkPointNavigator.CurrentPoint - 180;
				return ItemSlot.GetGamepadInstructions(Main.player[Main.myPlayer].miscEquips, 20, slot);
			});

			Func<string> value12 = arg_1385_0;
			Func<string> arg_13A6_0 = new Func<string>(() => {
				int slot = UILinkPointNavigator.CurrentPoint - 180;
				return ItemSlot.GetGamepadInstructions(Main.player[Main.myPlayer].miscEquips, 19, slot);
			});

			Func<string> value13 = arg_13A6_0;
			Func<string> arg_13C7_0 = new Func<string>(() => {
				int slot = UILinkPointNavigator.CurrentPoint - 180;
				return ItemSlot.GetGamepadInstructions(Main.player[Main.myPlayer].miscEquips, 18, slot);
			});

			Func<string> value14 = arg_13C7_0;
			Func<string> arg_13E8_0 = new Func<string>(() => {
				int slot = UILinkPointNavigator.CurrentPoint - 180;
				return ItemSlot.GetGamepadInstructions(Main.player[Main.myPlayer].miscEquips, 17, slot);
			});

			Func<string> value15 = arg_13E8_0;
			Func<string> arg_1409_0 = new Func<string>(() => {
				int slot = UILinkPointNavigator.CurrentPoint - 180;
				return ItemSlot.GetGamepadInstructions(Main.player[Main.myPlayer].miscEquips, 16, slot);
			});

			Func<string> value16 = arg_1409_0;
			Func<string> arg_142A_0 = new Func<string>(() => {
				int slot = UILinkPointNavigator.CurrentPoint - 185;
				return ItemSlot.GetGamepadInstructions(Main.player[Main.myPlayer].miscDyes, 12, slot);
			});

			Func<string> value17 = arg_142A_0;
			for (int num7 = 180; num7 <= 184; num7++)
			{
				UILinkPoint uILinkPoint7 = new UILinkPoint(num7, true, 185 + num7 - 180, -4, num7 - 1, num7 + 1);
				int expr_1462 = num7 - 180;
				if (expr_1462 == 0)
				{
					uILinkPoint7.Up = 305;
				}

				if (expr_1462 == 4)
				{
					uILinkPoint7.Down = 308;
				}

				cp9.LinkMap.Add(num7, uILinkPoint7);
				switch (num7)
				{
					case 180:
						uILinkPoint7.OnSpecialInteracts += value13;
						break;
					case 181:
						uILinkPoint7.OnSpecialInteracts += value12;
						break;
					case 182:
						uILinkPoint7.OnSpecialInteracts += value14;
						break;
					case 183:
						uILinkPoint7.OnSpecialInteracts += value15;
						break;
					case 184:
						uILinkPoint7.OnSpecialInteracts += value16;
						break;
				}
			}

			for (int num8 = 185; num8 <= 189; num8++)
			{
				UILinkPoint uILinkPoint7 = new UILinkPoint(num8, true, -3, -5 + num8, num8 - 1, num8 + 1);
				uILinkPoint7.OnSpecialInteracts += value17;
				int expr_1536 = num8 - 185;
				if (expr_1536 == 0)
				{
					uILinkPoint7.Up = 306;
				}

				if (expr_1536 == 4)
				{
					uILinkPoint7.Down = 308;
				}

				cp9.LinkMap.Add(num8, uILinkPoint7);
			}

			cp9.UpdateEvent += delegate
			{
				cp9.LinkMap[184].Down = ((UILinkPointNavigator.Shortcuts.BUFFS_DRAWN > 0) ? 9000 : 308);
				cp9.LinkMap[189].Down = ((UILinkPointNavigator.Shortcuts.BUFFS_DRAWN > 0) ? 9000 : 308);
			};
			UILinkPage arg_15B7_0 = cp9;
			Func<bool> arg_15B7_1 = new Func<bool>(() => {
				return Main.playerInventory && Main.EquipPage == 2;
			});

			arg_15B7_0.IsValidEvent += arg_15B7_1;
			cp9.PageOnLeft = 8;
			cp9.PageOnRight = 8;
			UILinkPointNavigator.RegisterPage(cp9, 7, true);
			UILinkPage cp10 = new UILinkPage();
			UILinkPage arg_161D_0 = cp10;
			Func<string> arg_161D_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"],
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				});
			});

			arg_161D_0.OnSpecialInteracts += arg_161D_1;
			cp10.LinkMap.Add(305, new UILinkPoint(305, true, 306, -4, 308, -2));
			cp10.LinkMap.Add(306, new UILinkPoint(306, true, 307, 305, 308, -2));
			cp10.LinkMap.Add(307, new UILinkPoint(307, true, -3, 306, 308, -2));
			cp10.LinkMap.Add(308, new UILinkPoint(308, true, -3, -4, -1, 305));
			cp10.LinkMap[305].OnSpecialInteracts += value;
			cp10.LinkMap[306].OnSpecialInteracts += value;
			cp10.LinkMap[307].OnSpecialInteracts += value;
			cp10.LinkMap[308].OnSpecialInteracts += value;
			cp10.UpdateEvent += delegate
			{
				switch (Main.EquipPage)
				{
					case 0:
						cp10.LinkMap[305].Down = 100;
						cp10.LinkMap[306].Down = 110;
						cp10.LinkMap[307].Down = 120;
						cp10.LinkMap[308].Up = 108 + Main.player[Main.myPlayer].extraAccessorySlots - 1;
						return;
					case 1:
						{
							cp10.LinkMap[305].Down = 600;
							cp10.LinkMap[306].Down = ((UILinkPointNavigator.Shortcuts.NPCS_IconsTotal / UILinkPointNavigator.Shortcuts.NPCS_IconsPerColumn > 0) ? (600 + UILinkPointNavigator.Shortcuts.NPCS_IconsPerColumn) : -2);
							cp10.LinkMap[307].Down = ((UILinkPointNavigator.Shortcuts.NPCS_IconsTotal / UILinkPointNavigator.Shortcuts.NPCS_IconsPerColumn > 1) ? (600 + UILinkPointNavigator.Shortcuts.NPCS_IconsPerColumn * 2) : -2);
							int num20 = UILinkPointNavigator.Shortcuts.NPCS_IconsPerColumn;
							if (num20 == 0)
							{
								num20 = 100;
							}

							if (num20 == 100)
							{
								num20 = UILinkPointNavigator.Shortcuts.NPCS_IconsTotal;
							}

							cp10.LinkMap[308].Up = 600 + num20 - 1;
							return;
						}

					case 2:
						cp10.LinkMap[305].Down = 180;
						cp10.LinkMap[306].Down = 185;
						cp10.LinkMap[307].Down = -2;
						cp10.LinkMap[308].Up = ((UILinkPointNavigator.Shortcuts.BUFFS_DRAWN > 0) ? 9000 : 184);
						break;
					case 3:
						break;
					default:
						return;
				}
			};
			UILinkPage arg_178C_0 = cp10;
			Func<bool> arg_178C_1 = new Func<bool>(() => {
				return Main.playerInventory;
			});

			arg_178C_0.IsValidEvent += arg_178C_1;
			cp10.PageOnLeft = 0;
			cp10.PageOnRight = 0;
			UILinkPointNavigator.RegisterPage(cp10, 8, true);
			UILinkPage arg_17F2_0 = new UILinkPage();
			Func<string> arg_17F2_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"],
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				});
			});

			arg_17F2_0.OnSpecialInteracts += arg_17F2_1;
			Func<string> arg_1816_0 = new Func<string>(() => {
				return ItemSlot.GetGamepadInstructions(ref Main.guideItem, 7);
			});

			Func<string> value18 = arg_1816_0;
			Func<string> arg_1839_1 = new Func<string>(() => {
				if (Main.mouseItem.type < 1)
				{
					return "";
				}

				return ItemSlot.GetGamepadInstructions(ref Main.mouseItem, 22);
			});

			var DC10HandleItem2 = arg_1839_1;
			for (int num9 = 1500; num9 < 1550; num9++)
			{
				UILinkPoint uILinkPoint8 = new UILinkPoint(num9, true, num9, num9, -1, -2);
				if (num9 != 1500)
				{
					uILinkPoint8.OnSpecialInteracts += DC10HandleItem2;
				}

				arg_17F2_0.LinkMap.Add(num9, uILinkPoint8);
			}

			arg_17F2_0.LinkMap[1500].OnSpecialInteracts += value18;
			arg_17F2_0.UpdateEvent += delegate
			{
				int num20 = UILinkPointNavigator.Shortcuts.CRAFT_CurrentIngridientsCount;
				int num21 = num20;
				if (Main.numAvailableRecipes > 0)
				{
					num21 += 2;
				}

				if (num20 < num21)
				{
					num20 = num21;
				}

				if (UILinkPointNavigator.OverridePoint == -1 && arg_17F2_0.CurrentPoint > 1500 + num20)
				{
					UILinkPointNavigator.ChangePoint(1500);
				}

				if (UILinkPointNavigator.OverridePoint == -1 && arg_17F2_0.CurrentPoint == 1500 && !Main.InGuideCraftMenu)
				{
					UILinkPointNavigator.ChangePoint(1501);
				}

				for (int num22 = 1; num22 < num20; num22++)
				{
					arg_17F2_0.LinkMap[1500 + num22].Left = 1500 + num22 - 1;
					arg_17F2_0.LinkMap[1500 + num22].Right = ((num22 == num20 - 2) ? -4 : (1500 + num22 + 1));
				}

				arg_17F2_0.LinkMap[1501].Left = -3;
				arg_17F2_0.LinkMap[1500 + num20 - 1].Right = -4;
				arg_17F2_0.LinkMap[1500].Down = ((num20 >= 2) ? 1502 : -2);
				arg_17F2_0.LinkMap[1500].Left = ((num20 >= 1) ? 1501 : -3);
				arg_17F2_0.LinkMap[1502].Up = (Main.InGuideCraftMenu ? 1500 : -1);
			};
			arg_17F2_0.LinkMap[1501].OnSpecialInteracts += delegate
			{
				if (Main.InGuideCraftMenu)
				{
					return "";
				}

				string str = "";
				Player player = Main.player[Main.myPlayer];
				bool flag = false;
				if (Main.mouseItem.type == 0 && player.ItemSpace(Main.recipe[Main.availableRecipe[Main.focusRecipe]].createItem) && !player.IsStackingItems())
				{
					flag = true;
					if (PlayerInput.Triggers.Current.Grapple && Main.stackSplit <= 1)
					{
						if (PlayerInput.Triggers.JustPressed.Grapple)
						{
							UILinksInitializer.SomeVarsForUILinkers.SequencedCraftingCurrent = Main.recipe[Main.availableRecipe[Main.focusRecipe]];
						}

						if (Main.stackSplit == 0)
						{
							Main.stackSplit = 15;
						}
						else
						{
							Main.stackSplit = Main.stackDelay;
						}

						if (UILinksInitializer.SomeVarsForUILinkers.SequencedCraftingCurrent == Main.recipe[Main.availableRecipe[Main.focusRecipe]])
						{
							Main.CraftItem(Main.recipe[Main.availableRecipe[Main.focusRecipe]]);
							Main.mouseItem = player.GetItem(player.whoAmI, Main.mouseItem, false, false);
						}
					}
				}
				else if (Main.mouseItem.type > 0 && Main.mouseItem.maxStack == 1 && ItemSlot.Equippable(ref Main.mouseItem, 0))
				{
					str += PlayerInput.BuildCommand(Lang.misc[67].Value, false, new List<string>[]
					{
						PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]
					});
					if (PlayerInput.Triggers.JustPressed.Grapple)
					{
						ItemSlot.SwapEquip(ref Main.mouseItem, 0);
						if (Main.player[Main.myPlayer].ItemSpace(Main.mouseItem))
						{
							Main.mouseItem = player.GetItem(player.whoAmI, Main.mouseItem, false, false);
						}
					}
				}

				bool flag2 = Main.mouseItem.stack <= 0;
				if (flag2 || (Main.mouseItem.type == Main.recipe[Main.availableRecipe[Main.focusRecipe]].createItem.type && Main.mouseItem.stack < Main.mouseItem.maxStack))
				{
					if (flag2)
					{
						str += PlayerInput.BuildCommand(Lang.misc[72].Value, false, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"],
							PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]
						});
					}
					else
					{
						str += PlayerInput.BuildCommand(Lang.misc[72].Value, false, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
						});
					}
				}

				if (!flag2 && Main.mouseItem.type == Main.recipe[Main.availableRecipe[Main.focusRecipe]].createItem.type && Main.mouseItem.stack < Main.mouseItem.maxStack)
				{
					str += PlayerInput.BuildCommand(Lang.misc[93].Value, false, new List<string>[]
					{
						PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]
					});
				}

				if (flag)
				{
					str += PlayerInput.BuildCommand(Lang.misc[71].Value, false, new List<string>[]
					{
						PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]
					});
				}

				return str + DC10HandleItem2();
			};
			UILinkPage arg_1917_0 = arg_17F2_0;
			Action<int, int> arg_1917_1 = new Action<int, int>((int current, int next) => {
				if (current != 1500)
				{
					if (current == 1501)
					{
						if (next == -1)
						{
							if (Main.focusRecipe > 0)
							{
								Main.focusRecipe--;
								return;
							}
						}
						else if (next == -2 && Main.focusRecipe < Main.numAvailableRecipes - 1)
						{
							Main.focusRecipe++;
							return;
						}
					}
					else if (next == -1)
					{
						if (Main.focusRecipe > 0)
						{
							UILinkPointNavigator.ChangePoint(1501);
							Main.focusRecipe--;
							return;
						}
					}
					else if (next == -2 && Main.focusRecipe < Main.numAvailableRecipes - 1)
					{
						UILinkPointNavigator.ChangePoint(1501);
						Main.focusRecipe++;
					}
				}
			});

			arg_1917_0.ReachEndEvent += arg_1917_1;
			UILinkPage arg_1942_0 = arg_17F2_0;
			Action arg_1942_1 = new Action(() => {
				Main.recBigList = false;
			});

			arg_1942_0.EnterEvent += arg_1942_1;
			UILinkPage arg_196D_0 = arg_17F2_0;
			Func<bool> arg_196D_1 = new Func<bool>(() => {
				return Main.playerInventory && (Main.numAvailableRecipes > 0 || Main.InGuideCraftMenu);
			});

			arg_196D_0.CanEnterEvent += arg_196D_1;
			UILinkPage arg_1998_0 = arg_17F2_0;
			Func<bool> arg_1998_1 = new Func<bool>(() => {
				return Main.playerInventory && (Main.numAvailableRecipes > 0 || Main.InGuideCraftMenu);
			});

			arg_1998_0.IsValidEvent += arg_1998_1;
			arg_17F2_0.PageOnLeft = 10;
			arg_17F2_0.PageOnRight = 0;
			UILinkPointNavigator.RegisterPage(arg_17F2_0, 9, true);
			UILinkPage cp11 = new UILinkPage();
			UILinkPage arg_1A00_0 = cp11;
			Func<string> arg_1A00_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"],
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				});
			});

			arg_1A00_0.OnSpecialInteracts += arg_1A00_1;
			for (int num10 = 700; num10 < 1500; num10++)
			{
				UILinkPoint uILinkPoint9 = new UILinkPoint(num10, true, num10, num10, num10, num10);
				int IHateLambda = num10;
				uILinkPoint9.OnSpecialInteracts += delegate
				{
					string text = "";
					bool flag = false;
					Player player = Main.player[Main.myPlayer];
					if (IHateLambda + Main.recStart < Main.numAvailableRecipes)
					{
						int num20 = Main.recStart + IHateLambda - 700;
						if (Main.mouseItem.type == 0 && player.ItemSpace(Main.recipe[Main.availableRecipe[num20]].createItem) && !player.IsStackingItems())
						{
							flag = true;
							if (PlayerInput.Triggers.JustPressed.Grapple)
							{
								UILinksInitializer.SomeVarsForUILinkers.SequencedCraftingCurrent = Main.recipe[Main.availableRecipe[num20]];
							}

							if (PlayerInput.Triggers.Current.Grapple && Main.stackSplit <= 1)
							{
								if (Main.stackSplit == 0)
								{
									Main.stackSplit = 15;
								}
								else
								{
									Main.stackSplit = Main.stackDelay;
								}

								if (UILinksInitializer.SomeVarsForUILinkers.SequencedCraftingCurrent == Main.recipe[Main.availableRecipe[num20]])
								{
									Main.CraftItem(Main.recipe[Main.availableRecipe[num20]]);
									Main.mouseItem = player.GetItem(player.whoAmI, Main.mouseItem, false, false);
								}
							}
						}
					}

					text += PlayerInput.BuildCommand(Lang.misc[73].Value, !flag, new List<string>[]
					{
						PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
					});
					if (flag)
					{
						text += PlayerInput.BuildCommand(Lang.misc[71].Value, true, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]
						});
					}

					return text;
				};
				cp11.LinkMap.Add(num10, uILinkPoint9);
			}

			cp11.UpdateEvent += delegate
			{
				int num20 = UILinkPointNavigator.Shortcuts.CRAFT_IconsPerRow;
				int cRAFT_IconsPerColumn = UILinkPointNavigator.Shortcuts.CRAFT_IconsPerColumn;
				if (num20 == 0)
				{
					num20 = 100;
				}

				int num21 = num20 * cRAFT_IconsPerColumn;
				if (num21 > 800)
				{
					num21 = 800;
				}

				if (num21 > Main.numAvailableRecipes)
				{
					num21 = Main.numAvailableRecipes;
				}

				for (int num22 = 0; num22 < num21; num22++)
				{
					cp11.LinkMap[700 + num22].Left = ((num22 % num20 == 0) ? -3 : (700 + num22 - 1));
					cp11.LinkMap[700 + num22].Right = (((num22 + 1) % num20 == 0 || num22 == Main.numAvailableRecipes - 1) ? -4 : (700 + num22 + 1));
					cp11.LinkMap[700 + num22].Down = ((num22 < num21 - num20) ? (700 + num22 + num20) : -2);
					cp11.LinkMap[700 + num22].Up = ((num22 < num20) ? -1 : (700 + num22 - num20));
				}
			};
			UILinkPage arg_1AA7_0 = cp11;
			Action<int, int> arg_1AA7_1 = new Action<int, int>((int current, int next) => {
				int cRAFT_IconsPerRow = UILinkPointNavigator.Shortcuts.CRAFT_IconsPerRow;
				if (next == -1)
				{
					Main.recStart -= cRAFT_IconsPerRow;
					if (Main.recStart < 0)
					{
						Main.recStart = 0;
						return;
					}
				}
				else if (next == -2)
				{
					Main.recStart += cRAFT_IconsPerRow;
					Main.PlaySound(12, -1, -1, 1, 1f, 0f);
					if (Main.recStart > Main.numAvailableRecipes - cRAFT_IconsPerRow)
					{
						Main.recStart = Main.numAvailableRecipes - cRAFT_IconsPerRow;
					}
				}
			});

			arg_1AA7_0.ReachEndEvent += arg_1AA7_1;
			UILinkPage arg_1AD2_0 = cp11;
			Action arg_1AD2_1 = new Action(() => {
				Main.recBigList = true;
			});

			arg_1AD2_0.EnterEvent += arg_1AD2_1;
			UILinkPage arg_1AFD_0 = cp11;
			Action arg_1AFD_1 = new Action(() => {
				Main.recBigList = false;
			});

			arg_1AFD_0.LeaveEvent += arg_1AFD_1;
			UILinkPage arg_1B28_0 = cp11;
			Func<bool> arg_1B28_1 = new Func<bool>(() => {
				return Main.playerInventory && Main.numAvailableRecipes > 0;
			});

			arg_1B28_0.CanEnterEvent += arg_1B28_1;
			UILinkPage arg_1B53_0 = cp11;
			Func<bool> arg_1B53_1 = new Func<bool>(() => {
				return Main.playerInventory && Main.recBigList && Main.numAvailableRecipes > 0;
			});

			arg_1B53_0.IsValidEvent += arg_1B53_1;
			cp11.PageOnLeft = 0;
			cp11.PageOnRight = 9;
			UILinkPointNavigator.RegisterPage(cp11, 10, true);
			UILinkPage cp12 = new UILinkPage();
			UILinkPage arg_1BBB_0 = cp12;
			Func<string> arg_1BBB_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"],
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				});
			});

			arg_1BBB_0.OnSpecialInteracts += arg_1BBB_1;
			for (int num11 = 2605; num11 < 2620; num11++)
			{
				UILinkPoint uILinkPoint10 = new UILinkPoint(num11, true, num11, num11, num11, num11);
				UILinkPoint arg_1BFC_0 = uILinkPoint10;
				Func<string> arg_1BFC_1 = new Func<string>(() => {
					return PlayerInput.BuildCommand(Lang.misc[73].Value, true, new List<string>[]
					{
						PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
					});
				});

				arg_1BFC_0.OnSpecialInteracts += arg_1BFC_1;
				cp12.LinkMap.Add(num11, uILinkPoint10);
			}

			cp12.UpdateEvent += delegate
			{
				int num20 = 5;
				int num21 = 3;
				int num22 = num20 * num21;
				int num23 = Main.UnlockedMaxHair();
				for (int num24 = 0; num24 < num22; num24++)
				{
					cp12.LinkMap[2605 + num24].Left = ((num24 % num20 == 0) ? -3 : (2605 + num24 - 1));
					cp12.LinkMap[2605 + num24].Right = (((num24 + 1) % num20 == 0 || num24 == num23 - 1) ? -4 : (2605 + num24 + 1));
					cp12.LinkMap[2605 + num24].Down = ((num24 < num22 - num20) ? (2605 + num24 + num20) : -2);
					cp12.LinkMap[2605 + num24].Up = ((num24 < num20) ? -1 : (2605 + num24 - num20));
				}
			};
			UILinkPage arg_1C64_0 = cp12;
			Action<int, int> arg_1C64_1 = new Action<int, int>((int current, int next) => {
				int num = 5;
				if (next == -1)
				{
					Main.hairStart -= num;
					Main.PlaySound(12, -1, -1, 1, 1f, 0f);
					return;
				}

				if (next == -2)
				{
					Main.hairStart += num;
					Main.PlaySound(12, -1, -1, 1, 1f, 0f);
				}
			});

			arg_1C64_0.ReachEndEvent += arg_1C64_1;
			UILinkPage arg_1C8F_0 = cp12;
			Func<bool> arg_1C8F_1 = new Func<bool>(() => {
				return Main.hairWindow;
			});

			arg_1C8F_0.CanEnterEvent += arg_1C8F_1;
			UILinkPage arg_1CBA_0 = cp12;
			Func<bool> arg_1CBA_1 = new Func<bool>(() => {
				return Main.hairWindow;
			});

			arg_1CBA_0.IsValidEvent += arg_1CBA_1;
			cp12.PageOnLeft = 12;
			cp12.PageOnRight = 12;
			UILinkPointNavigator.RegisterPage(cp12, 11, true);
			UILinkPage expr_1CEF = new UILinkPage();
			Func<string> arg_1D0F_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"],
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				});
			});

			expr_1CEF.OnSpecialInteracts += arg_1D0F_1;
			expr_1CEF.LinkMap.Add(2600, new UILinkPoint(2600, true, -3, -4, -1, 2601));
			expr_1CEF.LinkMap.Add(2601, new UILinkPoint(2601, true, -3, -4, 2600, 2602));
			expr_1CEF.LinkMap.Add(2602, new UILinkPoint(2602, true, -3, -4, 2601, 2603));
			expr_1CEF.LinkMap.Add(2603, new UILinkPoint(2603, true, -3, 2604, 2602, -2));
			expr_1CEF.LinkMap.Add(2604, new UILinkPoint(2604, true, 2603, -4, 2602, -2));
			Action arg_1DFD_1 = new Action(() => {
				Vector3 arg_D0_0 = Main.rgbToHsl(Main.selColor);
				float interfaceDeadzoneX = PlayerInput.CurrentProfile.InterfaceDeadzoneX;
				float num = PlayerInput.GamepadThumbstickLeft.X;
				if (num < -interfaceDeadzoneX || num > interfaceDeadzoneX)
				{
					num = MathHelper.Lerp(0f, 0.008333334f, (Math.Abs(num) - interfaceDeadzoneX) / (1f - interfaceDeadzoneX)) * (float)Math.Sign(num);
				}
				else
				{
					num = 0f;
				}

				int expr_5E = UILinkPointNavigator.CurrentPoint;
				if (expr_5E == 2600)
				{
					Main.hBar = MathHelper.Clamp(Main.hBar + num, 0f, 1f);
				}

				if (expr_5E == 2601)
				{
					Main.sBar = MathHelper.Clamp(Main.sBar + num, 0f, 1f);
				}

				if (expr_5E == 2602)
				{
					Main.lBar = MathHelper.Clamp(Main.lBar + num, 0.15f, 1f);
				}

				Vector3.Clamp(arg_D0_0, Vector3.Zero, Vector3.One);
				if (num != 0f)
				{
					if (Main.hairWindow)
					{
						Main.player[Main.myPlayer].hairColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
					}

					Main.PlaySound(12, -1, -1, 1, 1f, 0f);
				}
			});

			expr_1CEF.UpdateEvent += arg_1DFD_1;
			Func<bool> arg_1E22_1 = new Func<bool>(() => {
				return Main.hairWindow;
			});

			expr_1CEF.CanEnterEvent += arg_1E22_1;
			Func<bool> arg_1E47_1 = new Func<bool>(() => {
				return Main.hairWindow;
			});

			expr_1CEF.IsValidEvent += arg_1E47_1;
			expr_1CEF.PageOnLeft = 11;
			expr_1CEF.PageOnRight = 11;
			UILinkPointNavigator.RegisterPage(expr_1CEF, 12, true);
			UILinkPage cp13 = new UILinkPage();
			for (int num12 = 0; num12 < 30; num12++)
			{
				cp13.LinkMap.Add(2900 + num12, new UILinkPoint(2900 + num12, true, -3, -4, -1, -2));
				cp13.LinkMap[2900 + num12].OnSpecialInteracts += value;
			}

			UILinkPage arg_1EFB_0 = cp13;
			Func<string> arg_1EFB_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"],
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				});
			});

			arg_1EFB_0.OnSpecialInteracts += arg_1EFB_1;
			cp13.TravelEvent += delegate
			{
				if (UILinkPointNavigator.CurrentPage == cp13.ID)
				{
					int num20 = cp13.CurrentPoint - 2900;
					if (num20 < 4)
					{
						IngameOptions.category = num20;
					}
				}
			};
			cp13.UpdateEvent += delegate
			{
				int num20 = UILinkPointNavigator.Shortcuts.INGAMEOPTIONS_BUTTONS_LEFT;
				if (num20 == 0)
				{
					num20 = 5;
				}

				if (UILinkPointNavigator.OverridePoint == -1 && cp13.CurrentPoint < 2930 && cp13.CurrentPoint > 2900 + num20 - 1)
				{
					UILinkPointNavigator.ChangePoint(2900);
				}

				for (int num21 = 2900; num21 < 2900 + num20; num21++)
				{
					cp13.LinkMap[num21].Up = num21 - 1;
					cp13.LinkMap[num21].Down = num21 + 1;
				}

				cp13.LinkMap[2900].Up = 2900 + num20 - 1;
				cp13.LinkMap[2900 + num20 - 1].Down = 2900;
				int num22 = cp13.CurrentPoint - 2900;
				if (num22 < 4 && PlayerInput.Triggers.JustPressed.MouseLeft)
				{
					IngameOptions.category = num22;
					UILinkPointNavigator.ChangePage(1002);
				}
			};
			cp13.EnterEvent += delegate
			{
				cp13.CurrentPoint = 2900 + IngameOptions.category;
			};
			cp13.PageOnLeft = (cp13.PageOnRight = 1002);
			UILinkPage arg_1F93_0 = cp13;
			Func<bool> arg_1F93_1 = new Func<bool>(() => {
				return Main.ingameOptionsWindow && !Main.InGameUI.IsVisible;
			});

			arg_1F93_0.IsValidEvent += arg_1F93_1;
			UILinkPage arg_1FBE_0 = cp13;
			Func<bool> arg_1FBE_1 = new Func<bool>(() => {
				return Main.ingameOptionsWindow && !Main.InGameUI.IsVisible;
			});

			arg_1FBE_0.CanEnterEvent += arg_1FBE_1;
			UILinkPointNavigator.RegisterPage(cp13, 1001, true);
			UILinkPage cp14 = new UILinkPage();
			for (int num13 = 0; num13 < 30; num13++)
			{
				cp14.LinkMap.Add(2930 + num13, new UILinkPoint(2930 + num13, true, -3, -4, -1, -2));
				cp14.LinkMap[2930 + num13].OnSpecialInteracts += value;
			}

			UILinkPage arg_206C_0 = cp14;
			Func<string> arg_206C_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"],
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				});
			});

			arg_206C_0.OnSpecialInteracts += arg_206C_1;
			cp14.UpdateEvent += delegate
			{
				int num20 = UILinkPointNavigator.Shortcuts.INGAMEOPTIONS_BUTTONS_RIGHT;
				if (num20 == 0)
				{
					num20 = 5;
				}

				if (UILinkPointNavigator.OverridePoint == -1 && cp14.CurrentPoint >= 2930 && cp14.CurrentPoint > 2930 + num20 - 1)
				{
					UILinkPointNavigator.ChangePoint(2930);
				}

				for (int num21 = 2930; num21 < 2930 + num20; num21++)
				{
					cp14.LinkMap[num21].Up = num21 - 1;
					cp14.LinkMap[num21].Down = num21 + 1;
				}

				cp14.LinkMap[2930].Up = -1;
				cp14.LinkMap[2930 + num20 - 1].Down = -2;
				bool arg_D7_0 = PlayerInput.Triggers.JustPressed.Inventory;
				UILinksInitializer.HandleOptionsSpecials();
			};
			cp14.PageOnLeft = (cp14.PageOnRight = 1001);
			UILinkPage arg_20D2_0 = cp14;
			Func<bool> arg_20D2_1 = new Func<bool>(() => {
				return Main.ingameOptionsWindow;
			});

			arg_20D2_0.IsValidEvent += arg_20D2_1;
			UILinkPage arg_20FD_0 = cp14;
			Func<bool> arg_20FD_1 = new Func<bool>(() => {
				return Main.ingameOptionsWindow;
			});

			arg_20FD_0.CanEnterEvent += arg_20FD_1;
			UILinkPointNavigator.RegisterPage(cp14, 1002, true);
			UILinkPage cp15 = new UILinkPage();
			UILinkPage arg_214D_0 = cp15;
			Func<string> arg_214D_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"],
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				});
			});

			arg_214D_0.OnSpecialInteracts += arg_214D_1;
			for (int num14 = 1550; num14 < 1558; num14++)
			{
				UILinkPoint uILinkPoint11 = new UILinkPoint(num14, true, -3, -4, -1, -2);
				switch (num14 - 1550)
				{
					case 1:
					case 3:
					case 5:
						uILinkPoint11.Up = uILinkPoint11.ID - 2;
						uILinkPoint11.Down = uILinkPoint11.ID + 2;
						uILinkPoint11.Right = uILinkPoint11.ID + 1;
						break;
					case 2:
					case 4:
					case 6:
						uILinkPoint11.Up = uILinkPoint11.ID - 2;
						uILinkPoint11.Down = uILinkPoint11.ID + 2;
						uILinkPoint11.Left = uILinkPoint11.ID - 1;
						break;
				}

				cp15.LinkMap.Add(num14, uILinkPoint11);
			}

			cp15.LinkMap[1550].Down = 1551;
			cp15.LinkMap[1550].Right = 120;
			cp15.LinkMap[1550].Up = 307;
			cp15.LinkMap[1551].Up = 1550;
			cp15.LinkMap[1552].Up = 1550;
			cp15.LinkMap[1552].Right = 121;
			cp15.LinkMap[1554].Right = 121;
			cp15.LinkMap[1555].Down = 1557;
			cp15.LinkMap[1556].Down = 1557;
			cp15.LinkMap[1556].Right = 122;
			cp15.LinkMap[1557].Up = 1555;
			cp15.LinkMap[1557].Down = 308;
			cp15.LinkMap[1557].Right = 127;
			for (int num15 = 0; num15 < 7; num15++)
			{
				cp15.LinkMap[1550 + num15].OnSpecialInteracts += value;
			}

			cp15.UpdateEvent += delegate
			{
				if (!Main.ShouldPVPDraw)
				{
					if (UILinkPointNavigator.OverridePoint == -1 && cp15.CurrentPoint != 1557)
					{
						UILinkPointNavigator.ChangePoint(1557);
					}

					cp15.LinkMap[1557].Up = -1;
					cp15.LinkMap[1557].Down = 308;
					cp15.LinkMap[1557].Right = 127;
				}
				else
				{
					cp15.LinkMap[1557].Up = 1555;
					cp15.LinkMap[1557].Down = 308;
					cp15.LinkMap[1557].Right = 127;
				}

				int iNFOACCCOUNT = UILinkPointNavigator.Shortcuts.INFOACCCOUNT;
				if (iNFOACCCOUNT > 0)
				{
					cp15.LinkMap[1557].Up = 1558 + (iNFOACCCOUNT - 1) / 2 * 2;
				}

				if (Main.ShouldPVPDraw)
				{
					if (iNFOACCCOUNT >= 1)
					{
						cp15.LinkMap[1555].Down = 1558;
						cp15.LinkMap[1556].Down = 1558;
					}
					else
					{
						cp15.LinkMap[1555].Down = 1557;
						cp15.LinkMap[1556].Down = 1557;
					}

					if (iNFOACCCOUNT >= 2)
					{
						cp15.LinkMap[1556].Down = 1559;
						return;
					}

					cp15.LinkMap[1556].Down = 1557;
				}
			};
			UILinkPage arg_2424_0 = cp15;
			Func<bool> arg_2424_1 = new Func<bool>(() => {
				return Main.playerInventory;
			});

			arg_2424_0.IsValidEvent += arg_2424_1;
			cp15.PageOnLeft = 8;
			cp15.PageOnRight = 8;
			UILinkPointNavigator.RegisterPage(cp15, 16, true);
			UILinkPage cp16 = new UILinkPage();
			UILinkPage arg_248B_0 = cp16;
			Func<string> arg_248B_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"],
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				});
			});

			arg_248B_0.OnSpecialInteracts += arg_248B_1;
			for (int num16 = 1558; num16 < 1570; num16++)
			{
				UILinkPoint uILinkPoint12 = new UILinkPoint(num16, true, -3, -4, -1, -2);
				uILinkPoint12.OnSpecialInteracts += value;
				switch (num16 - 1558)
				{
					case 1:
					case 3:
					case 5:
						uILinkPoint12.Up = uILinkPoint12.ID - 2;
						uILinkPoint12.Down = uILinkPoint12.ID + 2;
						uILinkPoint12.Right = uILinkPoint12.ID + 1;
						break;
					case 2:
					case 4:
					case 6:
						uILinkPoint12.Up = uILinkPoint12.ID - 2;
						uILinkPoint12.Down = uILinkPoint12.ID + 2;
						uILinkPoint12.Left = uILinkPoint12.ID - 1;
						break;
				}

				cp16.LinkMap.Add(num16, uILinkPoint12);
			}

			cp16.UpdateEvent += delegate
			{
				int iNFOACCCOUNT = UILinkPointNavigator.Shortcuts.INFOACCCOUNT;
				if (UILinkPointNavigator.OverridePoint == -1 && cp16.CurrentPoint - 1558 >= iNFOACCCOUNT)
				{
					UILinkPointNavigator.ChangePoint(1558 + iNFOACCCOUNT - 1);
				}

				for (int num20 = 0; num20 < iNFOACCCOUNT; num20++)
				{
					bool flag = num20 % 2 == 0;
					int num21 = num20 + 1558;
					cp16.LinkMap[num21].Down = ((num20 < iNFOACCCOUNT - 2) ? (num21 + 2) : 1557);
					cp16.LinkMap[num21].Up = ((num20 > 1) ? (num21 - 2) : (Main.ShouldPVPDraw ? (flag ? 1555 : 1556) : -1));
					cp16.LinkMap[num21].Right = ((flag && num20 + 1 < iNFOACCCOUNT) ? (num21 + 1) : (123 + num20 / 4));
					cp16.LinkMap[num21].Left = (flag ? -3 : (num21 - 1));
				}
			};
			UILinkPage arg_25AA_0 = cp16;
			Func<bool> arg_25AA_1 = new Func<bool>(() => {
				return Main.playerInventory && UILinkPointNavigator.Shortcuts.INFOACCCOUNT > 0;
			});

			arg_25AA_0.IsValidEvent += arg_25AA_1;
			cp16.PageOnLeft = 8;
			cp16.PageOnRight = 8;
			UILinkPointNavigator.RegisterPage(cp16, 17, true);
			UILinkPage cp17 = new UILinkPage();
			UILinkPage arg_2611_0 = cp17;
			Func<string> arg_2611_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"],
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				});
			});

			arg_2611_0.OnSpecialInteracts += arg_2611_1;
			for (int num17 = 4000; num17 < 4010; num17++)
			{
				UILinkPoint uILinkPoint13 = new UILinkPoint(num17, true, -3, -4, -1, -2);
				switch (num17)
				{
					case 4000:
					case 4001:
						uILinkPoint13.Right = 0;
						break;
					case 4002:
					case 4003:
						uILinkPoint13.Right = 10;
						break;
					case 4004:
					case 4005:
						uILinkPoint13.Right = 20;
						break;
					case 4006:
					case 4007:
						uILinkPoint13.Right = 30;
						break;
					case 4008:
					case 4009:
						uILinkPoint13.Right = 40;
						break;
				}

				cp17.LinkMap.Add(num17, uILinkPoint13);
			}

			cp17.UpdateEvent += delegate
			{
				int bUILDERACCCOUNT = UILinkPointNavigator.Shortcuts.BUILDERACCCOUNT;
				if (UILinkPointNavigator.OverridePoint == -1 && cp17.CurrentPoint - 4000 >= bUILDERACCCOUNT)
				{
					UILinkPointNavigator.ChangePoint(4000 + bUILDERACCCOUNT - 1);
				}

				for (int num20 = 0; num20 < bUILDERACCCOUNT; num20++)
				{
					int arg_37_0 = num20 % 2;
					int num21 = num20 + 4000;
					cp17.LinkMap[num21].Down = ((num20 < bUILDERACCCOUNT - 1) ? (num21 + 1) : -2);
					cp17.LinkMap[num21].Up = ((num20 > 0) ? (num21 - 1) : -1);
				}
			};
			UILinkPage arg_2708_0 = cp17;
			Func<bool> arg_2708_1 = new Func<bool>(() => {
				return Main.playerInventory && UILinkPointNavigator.Shortcuts.BUILDERACCCOUNT > 0;
			});

			arg_2708_0.IsValidEvent += arg_2708_1;
			cp17.PageOnLeft = 8;
			cp17.PageOnRight = 8;
			UILinkPointNavigator.RegisterPage(cp17, 18, true);
			UILinkPage expr_273B = new UILinkPage();
			Func<string> arg_275B_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"],
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				});
			});

			expr_273B.OnSpecialInteracts += arg_275B_1;
			expr_273B.LinkMap.Add(2806, new UILinkPoint(2806, true, 2805, 2807, -1, 2808));
			expr_273B.LinkMap.Add(2807, new UILinkPoint(2807, true, 2806, -4, -1, 2809));
			expr_273B.LinkMap.Add(2808, new UILinkPoint(2808, true, 2805, 2809, 2806, -2));
			expr_273B.LinkMap.Add(2809, new UILinkPoint(2809, true, 2808, -4, 2807, -2));
			expr_273B.LinkMap.Add(2805, new UILinkPoint(2805, true, -3, 2806, -1, -2));
			expr_273B.LinkMap[2806].OnSpecialInteracts += value;
			expr_273B.LinkMap[2807].OnSpecialInteracts += value;
			expr_273B.LinkMap[2808].OnSpecialInteracts += value;
			expr_273B.LinkMap[2809].OnSpecialInteracts += value;
			expr_273B.LinkMap[2805].OnSpecialInteracts += value;
			Func<bool> arg_28BB_1 = new Func<bool>(() => {
				return Main.clothesWindow;
			});

			expr_273B.CanEnterEvent += arg_28BB_1;
			Func<bool> arg_28E0_1 = new Func<bool>(() => {
				return Main.clothesWindow;
			});

			expr_273B.IsValidEvent += arg_28E0_1;
			Action arg_2905_1 = new Action(() => {
				Main.player[Main.myPlayer].releaseInventory = false;
			});

			expr_273B.EnterEvent += arg_2905_1;
			Action arg_292A_1 = new Action(() => {
				Main.player[Main.myPlayer].releaseUseTile = false;
			});

			expr_273B.LeaveEvent += arg_292A_1;
			expr_273B.PageOnLeft = 15;
			expr_273B.PageOnRight = 15;
			UILinkPointNavigator.RegisterPage(expr_273B, 14, true);
			UILinkPage expr_294C = new UILinkPage();
			Func<string> arg_296C_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"],
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				});
			});

			expr_294C.OnSpecialInteracts += arg_296C_1;
			expr_294C.LinkMap.Add(2800, new UILinkPoint(2800, true, -3, -4, -1, 2801));
			expr_294C.LinkMap.Add(2801, new UILinkPoint(2801, true, -3, -4, 2800, 2802));
			expr_294C.LinkMap.Add(2802, new UILinkPoint(2802, true, -3, -4, 2801, 2803));
			expr_294C.LinkMap.Add(2803, new UILinkPoint(2803, true, -3, 2804, 2802, -2));
			expr_294C.LinkMap.Add(2804, new UILinkPoint(2804, true, 2803, -4, 2802, -2));
			expr_294C.LinkMap[2800].OnSpecialInteracts += value;
			expr_294C.LinkMap[2801].OnSpecialInteracts += value;
			expr_294C.LinkMap[2802].OnSpecialInteracts += value;
			expr_294C.LinkMap[2803].OnSpecialInteracts += value;
			expr_294C.LinkMap[2804].OnSpecialInteracts += value;
			Action arg_2AC8_1 = new Action(() => {
				Vector3 arg_D0_0 = Main.rgbToHsl(Main.selColor);
				float interfaceDeadzoneX = PlayerInput.CurrentProfile.InterfaceDeadzoneX;
				float num = PlayerInput.GamepadThumbstickLeft.X;
				if (num < -interfaceDeadzoneX || num > interfaceDeadzoneX)
				{
					num = MathHelper.Lerp(0f, 0.008333334f, (Math.Abs(num) - interfaceDeadzoneX) / (1f - interfaceDeadzoneX)) * (float)Math.Sign(num);
				}
				else
				{
					num = 0f;
				}

				int expr_5E = UILinkPointNavigator.CurrentPoint;
				if (expr_5E == 2800)
				{
					Main.hBar = MathHelper.Clamp(Main.hBar + num, 0f, 1f);
				}

				if (expr_5E == 2801)
				{
					Main.sBar = MathHelper.Clamp(Main.sBar + num, 0f, 1f);
				}

				if (expr_5E == 2802)
				{
					Main.lBar = MathHelper.Clamp(Main.lBar + num, 0.15f, 1f);
				}

				Vector3.Clamp(arg_D0_0, Vector3.Zero, Vector3.One);
				if (num != 0f)
				{
					if (Main.clothesWindow)
					{
						Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
						switch (Main.selClothes)
						{
							case 0:
								Main.player[Main.myPlayer].shirtColor = Main.selColor;
								break;
							case 1:
								Main.player[Main.myPlayer].underShirtColor = Main.selColor;
								break;
							case 2:
								Main.player[Main.myPlayer].pantsColor = Main.selColor;
								break;
							case 3:
								Main.player[Main.myPlayer].shoeColor = Main.selColor;
								break;
						}
					}

					Main.PlaySound(12, -1, -1, 1, 1f, 0f);
				}
			});

			expr_294C.UpdateEvent += arg_2AC8_1;
			Func<bool> arg_2AED_1 = new Func<bool>(() => {
				return Main.clothesWindow;
			});

			expr_294C.CanEnterEvent += arg_2AED_1;
			Func<bool> arg_2B12_1 = new Func<bool>(() => {
				return Main.clothesWindow;
			});

			expr_294C.IsValidEvent += arg_2B12_1;
			Action arg_2B37_1 = new Action(() => {
				Main.player[Main.myPlayer].releaseInventory = false;
			});

			expr_294C.EnterEvent += arg_2B37_1;
			Action arg_2B5C_1 = new Action(() => {
				Main.player[Main.myPlayer].releaseUseTile = false;
			});

			expr_294C.LeaveEvent += arg_2B5C_1;
			expr_294C.PageOnLeft = 14;
			expr_294C.PageOnRight = 14;
			UILinkPointNavigator.RegisterPage(expr_294C, 15, true);
			UILinkPage cp18 = new UILinkPage();
			UILinkPage arg_2BB2_0 = cp18;
			Action arg_2BB2_1 = new Action(() => {
				PlayerInput.GamepadAllowScrolling = true;
			});

			arg_2BB2_0.UpdateEvent += arg_2BB2_1;
			for (int num18 = 0; num18 < 200; num18++)
			{
				cp18.LinkMap.Add(3000 + num18, new UILinkPoint(3000 + num18, true, -3, -4, -1, -2));
			}

			UILinkPage arg_2C1F_0 = cp18;
			Func<string> arg_2C1F_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[53].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
				}) + PlayerInput.BuildCommand(Lang.misc[82].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + UILinksInitializer.FancyUISpecialInstructions();
			});

			arg_2C1F_0.OnSpecialInteracts += arg_2C1F_1;
			UILinkPage arg_2C4A_0 = cp18;
			Action arg_2C4A_1 = new Action(() => {
				if (PlayerInput.Triggers.JustPressed.Inventory)
				{
					UILinksInitializer.FancyExit();
				}

				UILinkPointNavigator.Shortcuts.BackButtonInUse = false;
			});

			arg_2C4A_0.UpdateEvent += arg_2C4A_1;
			cp18.EnterEvent += delegate
			{
				cp18.CurrentPoint = 3002;
			};
			UILinkPage arg_2C8E_0 = cp18;
			Func<bool> arg_2C8E_1 = new Func<bool>(() => {
				return Main.MenuUI.IsVisible || Main.InGameUI.IsVisible;
			});

			arg_2C8E_0.CanEnterEvent += arg_2C8E_1;
			UILinkPage arg_2CB9_0 = cp18;
			Func<bool> arg_2CB9_1 = new Func<bool>(() => {
				return Main.MenuUI.IsVisible || Main.InGameUI.IsVisible;
			});

			arg_2CB9_0.IsValidEvent += arg_2CB9_1;
			UILinkPointNavigator.RegisterPage(cp18, 1004, true);
			UILinkPage cp = new UILinkPage();
			UILinkPage arg_2D09_0 = cp;
			Func<string> arg_2D09_1 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]
				}) + PlayerInput.BuildCommand(Lang.misc[64].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"],
					PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]
				});
			});

			arg_2D09_0.OnSpecialInteracts += arg_2D09_1;
			Func<string> arg_2D2D_0 = new Func<string>(() => {
				return PlayerInput.BuildCommand(Lang.misc[94].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
				});
			});

			Func<string> value19 = arg_2D2D_0;
			for (int num19 = 9000; num19 <= 9050; num19++)
			{
				UILinkPoint uILinkPoint14 = new UILinkPoint(num19, true, num19 + 10, num19 - 10, num19 - 1, num19 + 1);
				cp.LinkMap.Add(num19, uILinkPoint14);
				uILinkPoint14.OnSpecialInteracts += value19;
			}

			cp.UpdateEvent += delegate
			{
				int num20 = UILinkPointNavigator.Shortcuts.BUFFS_PER_COLUMN;
				if (num20 == 0)
				{
					num20 = 100;
				}

				for (int num21 = 0; num21 < 50; num21++)
				{
					cp.LinkMap[9000 + num21].Up = ((num21 % num20 == 0) ? -1 : (9000 + num21 - 1));
					if (cp.LinkMap[9000 + num21].Up == -1)
					{
						if (num21 >= num20)
						{
							cp.LinkMap[9000 + num21].Up = 184;
						}
						else
						{
							cp.LinkMap[9000 + num21].Up = 189;
						}
					}

					cp.LinkMap[9000 + num21].Down = (((num21 + 1) % num20 == 0 || num21 == UILinkPointNavigator.Shortcuts.BUFFS_DRAWN - 1) ? 308 : (9000 + num21 + 1));
					cp.LinkMap[9000 + num21].Left = ((num21 < UILinkPointNavigator.Shortcuts.BUFFS_DRAWN - num20) ? (9000 + num21 + num20) : -3);
					cp.LinkMap[9000 + num21].Right = ((num21 < num20) ? -4 : (9000 + num21 - num20));
				}
			};
			UILinkPage arg_2DC0_0 = cp;
			Func<bool> arg_2DC0_1 = new Func<bool>(() => {
				return Main.playerInventory && Main.EquipPage == 2 && UILinkPointNavigator.Shortcuts.BUFFS_DRAWN > 0;
			});

			arg_2DC0_0.IsValidEvent += arg_2DC0_1;
			cp.PageOnLeft = 8;
			cp.PageOnRight = 8;
			UILinkPointNavigator.RegisterPage(cp, 19, true);
			UILinkPage expr_2DFD = UILinkPointNavigator.Pages[UILinkPointNavigator.CurrentPage];
			expr_2DFD.CurrentPoint = expr_2DFD.DefaultPoint;
			expr_2DFD.Enter();
		}

		public static bool NothingMoreImportantThanNPCChat()
		{
			return !Main.hairWindow && Main.npcShop == 0 && Main.player[Main.myPlayer].chest == -1;
		}

		public class SomeVarsForUILinkers
		{
			static SomeVarsForUILinkers()
			{
				// Note: this type is marked as 'beforefieldinit'.
			}

			public SomeVarsForUILinkers()
			{
			}

			public static int HairMoveCD;

			public static Recipe SequencedCraftingCurrent;
		}
	}
}
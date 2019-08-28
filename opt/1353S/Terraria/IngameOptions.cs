using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.Localization;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Gamepad;

namespace Terraria
{
	// Token: 0x02000011 RID: 17
	public static class IngameOptions
	{
		// Token: 0x06000091 RID: 145 RVA: 0x0000C0D4 File Offset: 0x0000A2D4
		public static void Open()
		{
			Main.playerInventory = false;
			Main.editChest = false;
			Main.npcChatText = "";
			Main.PlaySound(10, -1, -1, 1, 1f, 0f);
			Main.ingameOptionsWindow = true;
			IngameOptions.category = 0;
			for (int i = 0; i < IngameOptions.leftScale.Length; i++)
			{
				IngameOptions.leftScale[i] = 0f;
			}
			for (int j = 0; j < IngameOptions.rightScale.Length; j++)
			{
				IngameOptions.rightScale[j] = 0f;
			}
			IngameOptions.leftHover = -1;
			IngameOptions.rightHover = -1;
			IngameOptions.oldLeftHover = -1;
			IngameOptions.oldRightHover = -1;
			IngameOptions.rightLock = -1;
			IngameOptions.inBar = false;
			IngameOptions.notBar = false;
			IngameOptions.noSound = false;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000C184 File Offset: 0x0000A384
		public static void Close()
		{
			if (Main.setKey != -1)
			{
				return;
			}
			Main.ingameOptionsWindow = false;
			Main.PlaySound(11, -1, -1, 1, 1f, 0f);
			Recipe.FindRecipes();
			Main.playerInventory = true;
			Main.SaveSettings();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000C1BC File Offset: 0x0000A3BC
		public static void Draw(Main mainInstance, SpriteBatch sb)
		{
			if (Main.player[Main.myPlayer].dead && !Main.player[Main.myPlayer].ghost)
			{
				Main.setKey = -1;
				IngameOptions.Close();
				Main.playerInventory = false;
				return;
			}
			for (int i = 0; i < IngameOptions.skipRightSlot.Length; i++)
			{
				IngameOptions.skipRightSlot[i] = false;
			}
			bool flag = GameCulture.Russian.IsActive || GameCulture.Portuguese.IsActive || GameCulture.Polish.IsActive || GameCulture.French.IsActive;
			bool isActive = GameCulture.Polish.IsActive;
			bool isActive2 = GameCulture.German.IsActive;
			bool flag2 = GameCulture.Italian.IsActive || GameCulture.Spanish.IsActive;
			bool flag3 = false;
			int num = 70;
			float scale = 0.75f;
			float num2 = 60f;
			float num3 = 300f;
			if (flag)
			{
				flag3 = true;
			}
			if (isActive)
			{
				num3 = 200f;
			}
			new Vector2((float)Main.mouseX, (float)Main.mouseY);
			bool flag4 = Main.mouseLeft && Main.mouseLeftRelease;
			Vector2 arg_12D_0 = new Vector2((float)Main.screenWidth, (float)Main.screenHeight);
			Vector2 vector = new Vector2(670f, 480f);
			Vector2 vector2 = arg_12D_0 / 2f - vector / 2f;
			int num4 = 20;
			IngameOptions._GUIHover = new Rectangle((int)(vector2.X - (float)num4), (int)(vector2.Y - (float)num4), (int)(vector.X + (float)(num4 * 2)), (int)(vector.Y + (float)(num4 * 2)));
			Utils.DrawInvBG(sb, vector2.X - (float)num4, vector2.Y - (float)num4, vector.X + (float)(num4 * 2), vector.Y + (float)(num4 * 2), new Color(33, 15, 91, 255) * 0.685f);
			if (new Rectangle((int)vector2.X - num4, (int)vector2.Y - num4, (int)vector.X + num4 * 2, (int)vector.Y + num4 * 2).Contains(new Point(Main.mouseX, Main.mouseY)))
			{
				Main.player[Main.myPlayer].mouseInterface = true;
			}
			Utils.DrawBorderString(sb, Language.GetTextValue("GameUI.SettingsMenu"), vector2 + vector * new Vector2(0.5f, 0f), Color.White, 1f, 0.5f, 0f, -1);
			if (flag)
			{
				Utils.DrawInvBG(sb, vector2.X + (float)(num4 / 2), vector2.Y + (float)(num4 * 5 / 2), vector.X / 3f - (float)num4, vector.Y - (float)(num4 * 3), default(Color));
				Utils.DrawInvBG(sb, vector2.X + vector.X / 3f + (float)num4, vector2.Y + (float)(num4 * 5 / 2), vector.X * 2f / 3f - (float)(num4 * 3 / 2), vector.Y - (float)(num4 * 3), default(Color));
			}
			else
			{
				Utils.DrawInvBG(sb, vector2.X + (float)(num4 / 2), vector2.Y + (float)(num4 * 5 / 2), vector.X / 2f - (float)num4, vector.Y - (float)(num4 * 3), default(Color));
				Utils.DrawInvBG(sb, vector2.X + vector.X / 2f + (float)num4, vector2.Y + (float)(num4 * 5 / 2), vector.X / 2f - (float)(num4 * 3 / 2), vector.Y - (float)(num4 * 3), default(Color));
			}
			float num5 = 0.7f;
			float num6 = 0.8f;
			float num7 = 0.01f;
			if (flag)
			{
				num5 = 0.4f;
				num6 = 0.44f;
			}
			if (isActive2)
			{
				num5 = 0.55f;
				num6 = 0.6f;
			}
			if (IngameOptions.oldLeftHover != IngameOptions.leftHover && IngameOptions.leftHover != -1)
			{
				Main.PlaySound(12, -1, -1, 1, 1f, 0f);
			}
			if (IngameOptions.oldRightHover != IngameOptions.rightHover && IngameOptions.rightHover != -1)
			{
				Main.PlaySound(12, -1, -1, 1, 1f, 0f);
			}
			if (flag4 && IngameOptions.rightHover != -1 && !IngameOptions.noSound)
			{
				Main.PlaySound(12, -1, -1, 1, 1f, 0f);
			}
			IngameOptions.oldLeftHover = IngameOptions.leftHover;
			IngameOptions.oldRightHover = IngameOptions.rightHover;
			IngameOptions.noSound = false;
			bool flag5 = SocialAPI.Network != null && SocialAPI.Network.CanInvite();
			int num8 = flag5 ? 1 : 0;
			int num9 = 5 + num8 + 2;
			Vector2 vector3 = new Vector2(vector2.X + vector.X / 4f, vector2.Y + (float)(num4 * 5 / 2));
			Vector2 vector4 = new Vector2(0f, vector.Y - (float)(num4 * 5)) / (float)(num9 + 1);
			if (flag)
			{
				vector3.X -= 55f;
			}
			UILinkPointNavigator.Shortcuts.INGAMEOPTIONS_BUTTONS_LEFT = num9 + 1;
			for (int j = 0; j <= num9; j++)
			{
				if (IngameOptions.leftHover == j || j == IngameOptions.category)
				{
					IngameOptions.leftScale[j] += num7;
				}
				else
				{
					IngameOptions.leftScale[j] -= num7;
				}
				if (IngameOptions.leftScale[j] < num5)
				{
					IngameOptions.leftScale[j] = num5;
				}
				if (IngameOptions.leftScale[j] > num6)
				{
					IngameOptions.leftScale[j] = num6;
				}
			}
			IngameOptions.leftHover = -1;
			int arg_8B2_0 = IngameOptions.category;
			int num10 = 0;
			if (IngameOptions.DrawLeftSide(sb, Lang.menu[114].Value, num10, vector3, vector4, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
			{
				IngameOptions.leftHover = num10;
				if (flag4)
				{
					IngameOptions.category = 0;
					Main.PlaySound(10, -1, -1, 1, 1f, 0f);
				}
			}
			num10++;
			if (IngameOptions.DrawLeftSide(sb, Lang.menu[210].Value, num10, vector3, vector4, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
			{
				IngameOptions.leftHover = num10;
				if (flag4)
				{
					IngameOptions.category = 1;
					Main.PlaySound(10, -1, -1, 1, 1f, 0f);
				}
			}
			num10++;
			if (IngameOptions.DrawLeftSide(sb, Lang.menu[63].Value, num10, vector3, vector4, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
			{
				IngameOptions.leftHover = num10;
				if (flag4)
				{
					IngameOptions.category = 2;
					Main.PlaySound(10, -1, -1, 1, 1f, 0f);
				}
			}
			num10++;
			if (IngameOptions.DrawLeftSide(sb, Lang.menu[218].Value, num10, vector3, vector4, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
			{
				IngameOptions.leftHover = num10;
				if (flag4)
				{
					IngameOptions.category = 3;
					Main.PlaySound(10, -1, -1, 1, 1f, 0f);
				}
			}
			num10++;
			if (IngameOptions.DrawLeftSide(sb, Lang.menu[66].Value, num10, vector3, vector4, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
			{
				IngameOptions.leftHover = num10;
				if (flag4)
				{
					IngameOptions.Close();
					IngameFancyUI.OpenKeybinds();
				}
			}
			num10++;
			if (flag5 && IngameOptions.DrawLeftSide(sb, Lang.menu[147].Value, num10, vector3, vector4, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
			{
				IngameOptions.leftHover = num10;
				if (flag4)
				{
					IngameOptions.Close();
					SocialAPI.Network.OpenInviteInterface();
				}
			}
			if (flag5)
			{
				num10++;
			}
			if (IngameOptions.DrawLeftSide(sb, Lang.menu[131].Value, num10, vector3, vector4, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
			{
				IngameOptions.leftHover = num10;
				if (flag4)
				{
					IngameOptions.Close();
					IngameFancyUI.OpenAchievements();
				}
			}
			num10++;
			if (IngameOptions.DrawLeftSide(sb, Lang.menu[118].Value, num10, vector3, vector4, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
			{
				IngameOptions.leftHover = num10;
				if (flag4)
				{
					IngameOptions.Close();
				}
			}
			num10++;
			if (IngameOptions.DrawLeftSide(sb, Lang.inter[35].Value, num10, vector3, vector4, IngameOptions.leftScale, 0.7f, 0.8f, 0.01f))
			{
				IngameOptions.leftHover = num10;
				if (flag4)
				{
					IngameOptions.Close();
					Main.menuMode = 10;
					WorldGen.SaveAndQuit(null);
				}
			}
			num10++;
			if (arg_8B2_0 != IngameOptions.category)
			{
				for (int k = 0; k < IngameOptions.rightScale.Length; k++)
				{
					IngameOptions.rightScale[k] = 0f;
				}
			}
			int num11 = 0;
			switch (IngameOptions.category)
			{
			case 0:
				num11 = 15;
				num5 = 1f;
				num6 = 1.001f;
				num7 = 0.001f;
				break;
			case 1:
				num11 = 6;
				num5 = 1f;
				num6 = 1.001f;
				num7 = 0.001f;
				break;
			case 2:
				num11 = 12;
				num5 = 1f;
				num6 = 1.001f;
				num7 = 0.001f;
				break;
			case 3:
				num11 = 15;
				num5 = 1f;
				num6 = 1.001f;
				num7 = 0.001f;
				break;
			}
			if (flag)
			{
				num5 -= 0.1f;
				num6 -= 0.1f;
			}
			if (isActive2 && IngameOptions.category == 3)
			{
				num5 -= 0.15f;
				num6 -= 0.15f;
			}
			if (flag2 && (IngameOptions.category == 0 || IngameOptions.category == 3))
			{
				num5 -= 0.2f;
				num6 -= 0.2f;
			}
			UILinkPointNavigator.Shortcuts.INGAMEOPTIONS_BUTTONS_RIGHT = num11;
			Vector2 vector5 = new Vector2(vector2.X + vector.X * 3f / 4f, vector2.Y + (float)(num4 * 5 / 2));
			if (flag)
			{
				vector5.X = vector2.X + vector.X * 2f / 3f;
			}
			Vector2 vector6 = new Vector2(0f, vector.Y - (float)(num4 * 3)) / (float)(num11 + 1);
			if (IngameOptions.category == 2)
			{
				vector6.Y -= 2f;
			}
			for (int l = 0; l < 15; l++)
			{
				if (IngameOptions.rightLock == l || (IngameOptions.rightHover == l && IngameOptions.rightLock == -1))
				{
					IngameOptions.rightScale[l] += num7;
				}
				else
				{
					IngameOptions.rightScale[l] -= num7;
				}
				if (IngameOptions.rightScale[l] < num5)
				{
					IngameOptions.rightScale[l] = num5;
				}
				if (IngameOptions.rightScale[l] > num6)
				{
					IngameOptions.rightScale[l] = num6;
				}
			}
			IngameOptions.inBar = false;
			IngameOptions.rightHover = -1;
			if (!Main.mouseLeft)
			{
				IngameOptions.rightLock = -1;
			}
			if (IngameOptions.rightLock == -1)
			{
				IngameOptions.notBar = false;
			}
			if (IngameOptions.category == 0)
			{
				int num12 = 0;
				IngameOptions.DrawRightSide(sb, Lang.menu[65].Value, num12, vector5, vector6, IngameOptions.rightScale[num12], 1f, default(Color));
				IngameOptions.skipRightSlot[num12] = true;
				num12++;
				vector5.X -= (float)num;
				if (IngameOptions.DrawRightSide(sb, string.Concat(new object[]
				{
					Lang.menu[99].Value,
					" ",
					Math.Round((double)(Main.musicVolume * 100f)),
					"%"
				}), num12, vector5, vector6, IngameOptions.rightScale[num12], (IngameOptions.rightScale[num12] - num5) / (num6 - num5), default(Color)))
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.noSound = true;
					IngameOptions.rightHover = num12;
				}
				IngameOptions.valuePosition.X = vector2.X + vector.X - (float)(num4 / 2) - 20f;
				IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
				float musicVolume = IngameOptions.DrawValueBar(sb, scale, Main.musicVolume, 0, null);
				if ((IngameOptions.inBar || IngameOptions.rightLock == num12) && !IngameOptions.notBar)
				{
					IngameOptions.rightHover = num12;
					if (Main.mouseLeft && IngameOptions.rightLock == num12)
					{
						Main.musicVolume = musicVolume;
					}
				}
				if ((float)Main.mouseX > vector2.X + vector.X * 2f / 3f + (float)num4 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num12;
				}
				if (IngameOptions.rightHover == num12)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 2;
				}
				num12++;
				if (IngameOptions.DrawRightSide(sb, string.Concat(new object[]
				{
					Lang.menu[98].Value,
					" ",
					Math.Round((double)(Main.soundVolume * 100f)),
					"%"
				}), num12, vector5, vector6, IngameOptions.rightScale[num12], (IngameOptions.rightScale[num12] - num5) / (num6 - num5), default(Color)))
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num12;
				}
				IngameOptions.valuePosition.X = vector2.X + vector.X - (float)(num4 / 2) - 20f;
				IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
				float soundVolume = IngameOptions.DrawValueBar(sb, scale, Main.soundVolume, 0, null);
				if ((IngameOptions.inBar || IngameOptions.rightLock == num12) && !IngameOptions.notBar)
				{
					IngameOptions.rightHover = num12;
					if (Main.mouseLeft && IngameOptions.rightLock == num12)
					{
						Main.soundVolume = soundVolume;
						IngameOptions.noSound = true;
					}
				}
				if ((float)Main.mouseX > vector2.X + vector.X * 2f / 3f + (float)num4 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num12;
				}
				if (IngameOptions.rightHover == num12)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 3;
				}
				num12++;
				if (IngameOptions.DrawRightSide(sb, string.Concat(new object[]
				{
					Lang.menu[119].Value,
					" ",
					Math.Round((double)(Main.ambientVolume * 100f)),
					"%"
				}), num12, vector5, vector6, IngameOptions.rightScale[num12], (IngameOptions.rightScale[num12] - num5) / (num6 - num5), default(Color)))
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num12;
				}
				IngameOptions.valuePosition.X = vector2.X + vector.X - (float)(num4 / 2) - 20f;
				IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
				float ambientVolume = IngameOptions.DrawValueBar(sb, scale, Main.ambientVolume, 0, null);
				if ((IngameOptions.inBar || IngameOptions.rightLock == num12) && !IngameOptions.notBar)
				{
					IngameOptions.rightHover = num12;
					if (Main.mouseLeft && IngameOptions.rightLock == num12)
					{
						Main.ambientVolume = ambientVolume;
						IngameOptions.noSound = true;
					}
				}
				if ((float)Main.mouseX > vector2.X + vector.X * 2f / 3f + (float)num4 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num12;
				}
				if (IngameOptions.rightHover == num12)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 4;
				}
				num12++;
				vector5.X += (float)num;
				IngameOptions.DrawRightSide(sb, "", num12, vector5, vector6, IngameOptions.rightScale[num12], 1f, default(Color));
				IngameOptions.skipRightSlot[num12] = true;
				num12++;
				IngameOptions.DrawRightSide(sb, Language.GetTextValue("GameUI.ZoomCategory"), num12, vector5, vector6, IngameOptions.rightScale[num12], 1f, default(Color));
				IngameOptions.skipRightSlot[num12] = true;
				num12++;
				vector5.X -= (float)num;
				string text = Language.GetTextValue("GameUI.GameZoom", Math.Round((double)(Main.GameZoomTarget * 100f)), Math.Round((double)(Main.GameViewMatrix.Zoom.X * 100f)));
				if (flag3)
				{
					text = Main.fontItemStack.CreateWrappedText(text, num3, Language.ActiveCulture.CultureInfo);
				}
				if (IngameOptions.DrawRightSide(sb, text, num12, vector5, vector6, IngameOptions.rightScale[num12] * 0.85f, (IngameOptions.rightScale[num12] - num5) / (num6 - num5), default(Color)))
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num12;
				}
				IngameOptions.valuePosition.X = vector2.X + vector.X - (float)(num4 / 2) - 20f;
				IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
				float num13 = IngameOptions.DrawValueBar(sb, scale, Main.GameZoomTarget - 1f, 0, null);
				if ((IngameOptions.inBar || IngameOptions.rightLock == num12) && !IngameOptions.notBar)
				{
					IngameOptions.rightHover = num12;
					if (Main.mouseLeft && IngameOptions.rightLock == num12)
					{
						Main.GameZoomTarget = num13 + 1f;
					}
				}
				if ((float)Main.mouseX > vector2.X + vector.X * 2f / 3f + (float)num4 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num12;
				}
				if (IngameOptions.rightHover == num12)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 10;
				}
				num12++;
				bool flag6 = false;
				if (Main.temporaryGUIScaleSlider == -1f)
				{
					Main.temporaryGUIScaleSlider = Main.UIScaleWanted;
				}
				string text2 = Language.GetTextValue("GameUI.UIScale", Math.Round((double)(Main.temporaryGUIScaleSlider * 100f)), Math.Round((double)(Main.UIScale * 100f)));
				if (flag3)
				{
					text2 = Main.fontItemStack.CreateWrappedText(text2, num3, Language.ActiveCulture.CultureInfo);
				}
				if (IngameOptions.DrawRightSide(sb, text2, num12, vector5, vector6, IngameOptions.rightScale[num12] * 0.75f, (IngameOptions.rightScale[num12] - num5) / (num6 - num5), default(Color)))
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num12;
				}
				IngameOptions.valuePosition.X = vector2.X + vector.X - (float)(num4 / 2) - 20f;
				IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
				float num14 = IngameOptions.DrawValueBar(sb, scale, Main.temporaryGUIScaleSlider - 1f, 0, null);
				if ((IngameOptions.inBar || IngameOptions.rightLock == num12) && !IngameOptions.notBar)
				{
					IngameOptions.rightHover = num12;
					if (Main.mouseLeft && IngameOptions.rightLock == num12)
					{
						Main.temporaryGUIScaleSlider = num14 + 1f;
						Main.temporaryGUIScaleSliderUpdate = true;
						flag6 = true;
					}
				}
				if (!flag6 && Main.temporaryGUIScaleSliderUpdate && Main.temporaryGUIScaleSlider != -1f)
				{
					Main.UIScale = Main.temporaryGUIScaleSlider;
					Main.temporaryGUIScaleSliderUpdate = false;
				}
				if ((float)Main.mouseX > vector2.X + vector.X * 2f / 3f + (float)num4 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num12;
				}
				if (IngameOptions.rightHover == num12)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 11;
				}
				num12++;
				vector5.X += (float)num;
				IngameOptions.DrawRightSide(sb, "", num12, vector5, vector6, IngameOptions.rightScale[num12], 1f, default(Color));
				IngameOptions.skipRightSlot[num12] = true;
				num12++;
				IngameOptions.DrawRightSide(sb, Language.GetTextValue("GameUI.Gameplay"), num12, vector5, vector6, IngameOptions.rightScale[num12], 1f, default(Color));
				IngameOptions.skipRightSlot[num12] = true;
				num12++;
				if (IngameOptions.DrawRightSide(sb, Main.autoSave ? Lang.menu[67].Value : Lang.menu[68].Value, num12, vector5, vector6, IngameOptions.rightScale[num12], (IngameOptions.rightScale[num12] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num12;
					if (flag4)
					{
						Main.autoSave = !Main.autoSave;
					}
				}
				num12++;
				if (IngameOptions.DrawRightSide(sb, Main.autoPause ? Lang.menu[69].Value : Lang.menu[70].Value, num12, vector5, vector6, IngameOptions.rightScale[num12], (IngameOptions.rightScale[num12] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num12;
					if (flag4)
					{
						Main.autoPause = !Main.autoPause;
					}
				}
				num12++;
				if (IngameOptions.DrawRightSide(sb, Player.SmartCursorSettings.SmartWallReplacement ? Lang.menu[226].Value : Lang.menu[225].Value, num12, vector5, vector6, IngameOptions.rightScale[num12], (IngameOptions.rightScale[num12] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num12;
					if (flag4)
					{
						Player.SmartCursorSettings.SmartWallReplacement = !Player.SmartCursorSettings.SmartWallReplacement;
					}
				}
				num12++;
				if (IngameOptions.DrawRightSide(sb, Main.ReversedUpDownArmorSetBonuses ? Lang.menu[220].Value : Lang.menu[221].Value, num12, vector5, vector6, IngameOptions.rightScale[num12], (IngameOptions.rightScale[num12] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num12;
					if (flag4)
					{
						Main.ReversedUpDownArmorSetBonuses = !Main.ReversedUpDownArmorSetBonuses;
					}
				}
				num12++;
				IngameOptions.DrawRightSide(sb, "", num12, vector5, vector6, IngameOptions.rightScale[num12], 1f, default(Color));
				IngameOptions.skipRightSlot[num12] = true;
				num12++;
			}
			if (IngameOptions.category == 1)
			{
				int num15 = 0;
				if (IngameOptions.DrawRightSide(sb, Main.showItemText ? Lang.menu[71].Value : Lang.menu[72].Value, num15, vector5, vector6, IngameOptions.rightScale[num15], (IngameOptions.rightScale[num15] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num15;
					if (flag4)
					{
						Main.showItemText = !Main.showItemText;
					}
				}
				num15++;
				if (IngameOptions.DrawRightSide(sb, Lang.menu[123].Value + " " + Lang.menu[124 + Main.invasionProgressMode], num15, vector5, vector6, IngameOptions.rightScale[num15], (IngameOptions.rightScale[num15] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num15;
					if (flag4)
					{
						Main.invasionProgressMode++;
						if (Main.invasionProgressMode >= 3)
						{
							Main.invasionProgressMode = 0;
						}
					}
				}
				num15++;
				if (IngameOptions.DrawRightSide(sb, Main.placementPreview ? Lang.menu[128].Value : Lang.menu[129].Value, num15, vector5, vector6, IngameOptions.rightScale[num15], (IngameOptions.rightScale[num15] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num15;
					if (flag4)
					{
						Main.placementPreview = !Main.placementPreview;
					}
				}
				num15++;
				if (IngameOptions.DrawRightSide(sb, ItemSlot.Options.HighlightNewItems ? Lang.inter[117].Value : Lang.inter[116].Value, num15, vector5, vector6, IngameOptions.rightScale[num15], (IngameOptions.rightScale[num15] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num15;
					if (flag4)
					{
						ItemSlot.Options.HighlightNewItems = !ItemSlot.Options.HighlightNewItems;
					}
				}
				num15++;
				if (IngameOptions.DrawRightSide(sb, Main.MouseShowBuildingGrid ? Lang.menu[229].Value : Lang.menu[230].Value, num15, vector5, vector6, IngameOptions.rightScale[num15], (IngameOptions.rightScale[num15] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num15;
					if (flag4)
					{
						Main.MouseShowBuildingGrid = !Main.MouseShowBuildingGrid;
					}
				}
				num15++;
				if (IngameOptions.DrawRightSide(sb, Main.GamepadDisableInstructionsDisplay ? Lang.menu[241].Value : Lang.menu[242].Value, num15, vector5, vector6, IngameOptions.rightScale[num15], (IngameOptions.rightScale[num15] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num15;
					if (flag4)
					{
						Main.GamepadDisableInstructionsDisplay = !Main.GamepadDisableInstructionsDisplay;
					}
				}
				num15++;
			}
			if (IngameOptions.category == 2)
			{
				int num16 = 0;
				if (IngameOptions.DrawRightSide(sb, Main.graphics.IsFullScreen ? Lang.menu[49].Value : Lang.menu[50].Value, num16, vector5, vector6, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num16;
					if (flag4)
					{
						Main.ToggleFullScreen();
					}
				}
				num16++;
				if (IngameOptions.DrawRightSide(sb, string.Concat(new object[]
				{
					Lang.menu[51].Value,
					": ",
					Main.PendingResolutionWidth,
					"x",
					Main.PendingResolutionHeight
				}), num16, vector5, vector6, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num16;
					if (flag4)
					{
						int num17 = 0;
						for (int m = 0; m < Main.numDisplayModes; m++)
						{
							if (Main.displayWidth[m] == Main.PendingResolutionWidth && Main.displayHeight[m] == Main.PendingResolutionHeight)
							{
								num17 = m;
								break;
							}
						}
						num17++;
						if (num17 >= Main.numDisplayModes)
						{
							num17 = 0;
						}
						Main.PendingResolutionWidth = Main.displayWidth[num17];
						Main.PendingResolutionHeight = Main.displayHeight[num17];
					}
				}
				num16++;
				vector5.X -= (float)num;
				if (IngameOptions.DrawRightSide(sb, string.Concat(new object[]
				{
					Lang.menu[52].Value,
					": ",
					Main.bgScroll,
					"%"
				}), num16, vector5, vector6, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num5) / (num6 - num5), default(Color)))
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.noSound = true;
					IngameOptions.rightHover = num16;
				}
				IngameOptions.valuePosition.X = vector2.X + vector.X - (float)(num4 / 2) - 20f;
				IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
				float num18 = IngameOptions.DrawValueBar(sb, scale, (float)Main.bgScroll / 100f, 0, null);
				if ((IngameOptions.inBar || IngameOptions.rightLock == num16) && !IngameOptions.notBar)
				{
					IngameOptions.rightHover = num16;
					if (Main.mouseLeft && IngameOptions.rightLock == num16)
					{
						Main.bgScroll = (int)(num18 * 100f);
						Main.caveParallax = 1f - (float)Main.bgScroll / 500f;
					}
				}
				if ((float)Main.mouseX > vector2.X + vector.X * 2f / 3f + (float)num4 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num16;
				}
				if (IngameOptions.rightHover == num16)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 1;
				}
				num16++;
				vector5.X += (float)num;
				if (IngameOptions.DrawRightSide(sb, Lang.menu[247 + Main.FrameSkipMode].Value, num16, vector5, vector6, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num16;
					if (flag4)
					{
						Main.FrameSkipMode++;
						if (Main.FrameSkipMode < 0 || Main.FrameSkipMode > 2)
						{
							Main.FrameSkipMode = 0;
						}
					}
				}
				num16++;
				if (IngameOptions.DrawRightSide(sb, Lang.menu[55 + Lighting.lightMode].Value, num16, vector5, vector6, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num16;
					if (flag4)
					{
						Lighting.NextLightMode();
					}
				}
				num16++;
				if (IngameOptions.DrawRightSide(sb, Lang.menu[116].Value + " " + ((Lighting.LightingThreads > 0) ? string.Concat(Lighting.LightingThreads + 1) : Lang.menu[117].Value), num16, vector5, vector6, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num16;
					if (flag4)
					{
						Lighting.LightingThreads++;
						if (Lighting.LightingThreads > Environment.ProcessorCount - 1)
						{
							Lighting.LightingThreads = 0;
						}
					}
				}
				num16++;
				if (IngameOptions.DrawRightSide(sb, Lang.menu[59 + Main.qaStyle].Value, num16, vector5, vector6, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num16;
					if (flag4)
					{
						Main.qaStyle++;
						if (Main.qaStyle > 3)
						{
							Main.qaStyle = 0;
						}
					}
				}
				num16++;
				if (IngameOptions.DrawRightSide(sb, Main.BackgroundEnabled ? Lang.menu[100].Value : Lang.menu[101].Value, num16, vector5, vector6, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num16;
					if (flag4)
					{
						Main.BackgroundEnabled = !Main.BackgroundEnabled;
					}
				}
				num16++;
				if (IngameOptions.DrawRightSide(sb, ChildSafety.Disabled ? Lang.menu[132].Value : Lang.menu[133].Value, num16, vector5, vector6, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num16;
					if (flag4)
					{
						ChildSafety.Disabled = !ChildSafety.Disabled;
					}
				}
				num16++;
				if (IngameOptions.DrawRightSide(sb, Language.GetTextValue("GameUI.HeatDistortion", Main.UseHeatDistortion ? Language.GetTextValue("GameUI.Enabled") : Language.GetTextValue("GameUI.Disabled")), num16, vector5, vector6, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num16;
					if (flag4)
					{
						Main.UseHeatDistortion = !Main.UseHeatDistortion;
					}
				}
				num16++;
				if (IngameOptions.DrawRightSide(sb, Language.GetTextValue("GameUI.StormEffects", Main.UseStormEffects ? Language.GetTextValue("GameUI.Enabled") : Language.GetTextValue("GameUI.Disabled")), num16, vector5, vector6, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num16;
					if (flag4)
					{
						Main.UseStormEffects = !Main.UseStormEffects;
					}
				}
				num16++;
				string textValue;
				switch (Main.WaveQuality)
				{
				case 1:
					textValue = Language.GetTextValue("GameUI.QualityLow");
					break;
				case 2:
					textValue = Language.GetTextValue("GameUI.QualityMedium");
					break;
				case 3:
					textValue = Language.GetTextValue("GameUI.QualityHigh");
					break;
				default:
					textValue = Language.GetTextValue("GameUI.QualityOff");
					break;
				}
				if (IngameOptions.DrawRightSide(sb, Language.GetTextValue("GameUI.WaveQuality", textValue), num16, vector5, vector6, IngameOptions.rightScale[num16], (IngameOptions.rightScale[num16] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num16;
					if (flag4)
					{
						Main.WaveQuality = (Main.WaveQuality + 1) % 4;
					}
				}
				num16++;
			}
			if (IngameOptions.category == 3)
			{
				int num19 = 0;
				float num20 = (float)num;
				if (flag)
				{
					num2 = 126f;
				}
				Vector3 hSLVector = Main.mouseColorSlider.GetHSLVector();
				Main.mouseColorSlider.ApplyToMainLegacyBars();
				IngameOptions.DrawRightSide(sb, Lang.menu[64].Value, num19, vector5, vector6, IngameOptions.rightScale[num19], 1f, default(Color));
				IngameOptions.skipRightSlot[num19] = true;
				num19++;
				vector5.X -= num20;
				if (IngameOptions.DrawRightSide(sb, "", num19, vector5, vector6, IngameOptions.rightScale[num19], (IngameOptions.rightScale[num19] - num5) / (num6 - num5), default(Color)))
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num19;
				}
				IngameOptions.valuePosition.X = vector2.X + vector.X - (float)(num4 / 2) - 20f;
				IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X - num2;
				DelegateMethods.v3_1 = hSLVector;
				float num21 = IngameOptions.DrawValueBar(sb, scale, hSLVector.X, 0, new Utils.ColorLerpMethod(DelegateMethods.ColorLerp_HSL_H));
				if ((IngameOptions.inBar || IngameOptions.rightLock == num19) && !IngameOptions.notBar)
				{
					IngameOptions.rightHover = num19;
					if (Main.mouseLeft && IngameOptions.rightLock == num19)
					{
						hSLVector.X = num21;
						IngameOptions.noSound = true;
					}
				}
				if ((float)Main.mouseX > vector2.X + vector.X * 2f / 3f + (float)num4 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num19;
				}
				if (IngameOptions.rightHover == num19)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 5;
					Main.menuMode = 25;
				}
				num19++;
				if (IngameOptions.DrawRightSide(sb, "", num19, vector5, vector6, IngameOptions.rightScale[num19], (IngameOptions.rightScale[num19] - num5) / (num6 - num5), default(Color)))
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num19;
				}
				IngameOptions.valuePosition.X = vector2.X + vector.X - (float)(num4 / 2) - 20f;
				IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X - num2;
				DelegateMethods.v3_1 = hSLVector;
				num21 = IngameOptions.DrawValueBar(sb, scale, hSLVector.Y, 0, new Utils.ColorLerpMethod(DelegateMethods.ColorLerp_HSL_S));
				if ((IngameOptions.inBar || IngameOptions.rightLock == num19) && !IngameOptions.notBar)
				{
					IngameOptions.rightHover = num19;
					if (Main.mouseLeft && IngameOptions.rightLock == num19)
					{
						hSLVector.Y = num21;
						IngameOptions.noSound = true;
					}
				}
				if ((float)Main.mouseX > vector2.X + vector.X * 2f / 3f + (float)num4 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num19;
				}
				if (IngameOptions.rightHover == num19)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 6;
					Main.menuMode = 25;
				}
				num19++;
				if (IngameOptions.DrawRightSide(sb, "", num19, vector5, vector6, IngameOptions.rightScale[num19], (IngameOptions.rightScale[num19] - num5) / (num6 - num5), default(Color)))
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num19;
				}
				IngameOptions.valuePosition.X = vector2.X + vector.X - (float)(num4 / 2) - 20f;
				IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X - num2;
				DelegateMethods.v3_1 = hSLVector;
				DelegateMethods.v3_1.Z = Utils.InverseLerp(0.15f, 1f, DelegateMethods.v3_1.Z, true);
				num21 = IngameOptions.DrawValueBar(sb, scale, DelegateMethods.v3_1.Z, 0, new Utils.ColorLerpMethod(DelegateMethods.ColorLerp_HSL_L));
				if ((IngameOptions.inBar || IngameOptions.rightLock == num19) && !IngameOptions.notBar)
				{
					IngameOptions.rightHover = num19;
					if (Main.mouseLeft && IngameOptions.rightLock == num19)
					{
						hSLVector.Z = num21 * 0.85f + 0.15f;
						IngameOptions.noSound = true;
					}
				}
				if ((float)Main.mouseX > vector2.X + vector.X * 2f / 3f + (float)num4 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num19;
				}
				if (IngameOptions.rightHover == num19)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 7;
					Main.menuMode = 25;
				}
				num19++;
				if (hSLVector.Z < 0.15f)
				{
					hSLVector.Z = 0.15f;
				}
				Main.mouseColorSlider.SetHSL(hSLVector);
				Main.mouseColor = Main.mouseColorSlider.GetColor();
				vector5.X += num20;
				IngameOptions.DrawRightSide(sb, "", num19, vector5, vector6, IngameOptions.rightScale[num19], 1f, default(Color));
				IngameOptions.skipRightSlot[num19] = true;
				num19++;
				hSLVector = Main.mouseBorderColorSlider.GetHSLVector();
				if (PlayerInput.UsingGamepad && IngameOptions.rightHover == -1)
				{
					Main.mouseBorderColorSlider.ApplyToMainLegacyBars();
				}
				IngameOptions.DrawRightSide(sb, Lang.menu[217].Value, num19, vector5, vector6, IngameOptions.rightScale[num19], 1f, default(Color));
				IngameOptions.skipRightSlot[num19] = true;
				num19++;
				vector5.X -= num20;
				if (IngameOptions.DrawRightSide(sb, "", num19, vector5, vector6, IngameOptions.rightScale[num19], (IngameOptions.rightScale[num19] - num5) / (num6 - num5), default(Color)))
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num19;
				}
				IngameOptions.valuePosition.X = vector2.X + vector.X - (float)(num4 / 2) - 20f;
				IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X - num2;
				DelegateMethods.v3_1 = hSLVector;
				num21 = IngameOptions.DrawValueBar(sb, scale, hSLVector.X, 0, new Utils.ColorLerpMethod(DelegateMethods.ColorLerp_HSL_H));
				if ((IngameOptions.inBar || IngameOptions.rightLock == num19) && !IngameOptions.notBar)
				{
					IngameOptions.rightHover = num19;
					if (Main.mouseLeft && IngameOptions.rightLock == num19)
					{
						hSLVector.X = num21;
						IngameOptions.noSound = true;
					}
				}
				if ((float)Main.mouseX > vector2.X + vector.X * 2f / 3f + (float)num4 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num19;
				}
				if (IngameOptions.rightHover == num19)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 5;
					Main.menuMode = 252;
				}
				num19++;
				if (IngameOptions.DrawRightSide(sb, "", num19, vector5, vector6, IngameOptions.rightScale[num19], (IngameOptions.rightScale[num19] - num5) / (num6 - num5), default(Color)))
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num19;
				}
				IngameOptions.valuePosition.X = vector2.X + vector.X - (float)(num4 / 2) - 20f;
				IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X - num2;
				DelegateMethods.v3_1 = hSLVector;
				num21 = IngameOptions.DrawValueBar(sb, scale, hSLVector.Y, 0, new Utils.ColorLerpMethod(DelegateMethods.ColorLerp_HSL_S));
				if ((IngameOptions.inBar || IngameOptions.rightLock == num19) && !IngameOptions.notBar)
				{
					IngameOptions.rightHover = num19;
					if (Main.mouseLeft && IngameOptions.rightLock == num19)
					{
						hSLVector.Y = num21;
						IngameOptions.noSound = true;
					}
				}
				if ((float)Main.mouseX > vector2.X + vector.X * 2f / 3f + (float)num4 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num19;
				}
				if (IngameOptions.rightHover == num19)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 6;
					Main.menuMode = 252;
				}
				num19++;
				if (IngameOptions.DrawRightSide(sb, "", num19, vector5, vector6, IngameOptions.rightScale[num19], (IngameOptions.rightScale[num19] - num5) / (num6 - num5), default(Color)))
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num19;
				}
				IngameOptions.valuePosition.X = vector2.X + vector.X - (float)(num4 / 2) - 20f;
				IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X - num2;
				DelegateMethods.v3_1 = hSLVector;
				num21 = IngameOptions.DrawValueBar(sb, scale, hSLVector.Z, 0, new Utils.ColorLerpMethod(DelegateMethods.ColorLerp_HSL_L));
				if ((IngameOptions.inBar || IngameOptions.rightLock == num19) && !IngameOptions.notBar)
				{
					IngameOptions.rightHover = num19;
					if (Main.mouseLeft && IngameOptions.rightLock == num19)
					{
						hSLVector.Z = num21;
						IngameOptions.noSound = true;
					}
				}
				if ((float)Main.mouseX > vector2.X + vector.X * 2f / 3f + (float)num4 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num19;
				}
				if (IngameOptions.rightHover == num19)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 7;
					Main.menuMode = 252;
				}
				num19++;
				if (IngameOptions.DrawRightSide(sb, "", num19, vector5, vector6, IngameOptions.rightScale[num19], (IngameOptions.rightScale[num19] - num5) / (num6 - num5), default(Color)))
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num19;
				}
				IngameOptions.valuePosition.X = vector2.X + vector.X - (float)(num4 / 2) - 20f;
				IngameOptions.valuePosition.Y = IngameOptions.valuePosition.Y - 3f;
				IngameOptions.valuePosition.X = IngameOptions.valuePosition.X - num2;
				DelegateMethods.v3_1 = hSLVector;
				float num22 = Main.mouseBorderColorSlider.Alpha;
				num21 = IngameOptions.DrawValueBar(sb, scale, num22, 0, new Utils.ColorLerpMethod(DelegateMethods.ColorLerp_HSL_O));
				if ((IngameOptions.inBar || IngameOptions.rightLock == num19) && !IngameOptions.notBar)
				{
					IngameOptions.rightHover = num19;
					if (Main.mouseLeft && IngameOptions.rightLock == num19)
					{
						num22 = num21;
						IngameOptions.noSound = true;
					}
				}
				if ((float)Main.mouseX > vector2.X + vector.X * 2f / 3f + (float)num4 && (float)Main.mouseX < IngameOptions.valuePosition.X + 3.75f && (float)Main.mouseY > IngameOptions.valuePosition.Y - 10f && (float)Main.mouseY <= IngameOptions.valuePosition.Y + 10f)
				{
					if (IngameOptions.rightLock == -1)
					{
						IngameOptions.notBar = true;
					}
					IngameOptions.rightHover = num19;
				}
				if (IngameOptions.rightHover == num19)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 8;
					Main.menuMode = 252;
				}
				num19++;
				Main.mouseBorderColorSlider.SetHSL(hSLVector);
				Main.mouseBorderColorSlider.Alpha = num22;
				Main.MouseBorderColor = Main.mouseBorderColorSlider.GetColor();
				vector5.X += num20;
				IngameOptions.DrawRightSide(sb, "", num19, vector5, vector6, IngameOptions.rightScale[num19], 1f, default(Color));
				IngameOptions.skipRightSlot[num19] = true;
				num19++;
				string txt = "";
				switch (LockOnHelper.UseMode)
				{
				case LockOnHelper.LockOnMode.FocusTarget:
					txt = Lang.menu[232].Value;
					break;
				case LockOnHelper.LockOnMode.TargetClosest:
					txt = Lang.menu[233].Value;
					break;
				case LockOnHelper.LockOnMode.ThreeDS:
					txt = Lang.menu[234].Value;
					break;
				}
				if (IngameOptions.DrawRightSide(sb, txt, num19, vector5, vector6, IngameOptions.rightScale[num19] * 0.9f, (IngameOptions.rightScale[num19] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num19;
					if (flag4)
					{
						LockOnHelper.CycleUseModes();
					}
				}
				num19++;
				if (IngameOptions.DrawRightSide(sb, Player.SmartCursorSettings.SmartBlocksEnabled ? Lang.menu[215].Value : Lang.menu[216].Value, num19, vector5, vector6, IngameOptions.rightScale[num19] * 0.9f, (IngameOptions.rightScale[num19] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num19;
					if (flag4)
					{
						Player.SmartCursorSettings.SmartBlocksEnabled = !Player.SmartCursorSettings.SmartBlocksEnabled;
					}
				}
				num19++;
				if (IngameOptions.DrawRightSide(sb, Main.cSmartCursorToggle ? Lang.menu[121].Value : Lang.menu[122].Value, num19, vector5, vector6, IngameOptions.rightScale[num19], (IngameOptions.rightScale[num19] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num19;
					if (flag4)
					{
						Main.cSmartCursorToggle = !Main.cSmartCursorToggle;
					}
				}
				num19++;
				if (IngameOptions.DrawRightSide(sb, Player.SmartCursorSettings.SmartAxeAfterPickaxe ? Lang.menu[214].Value : Lang.menu[213].Value, num19, vector5, vector6, IngameOptions.rightScale[num19] * 0.9f, (IngameOptions.rightScale[num19] - num5) / (num6 - num5), default(Color)))
				{
					IngameOptions.rightHover = num19;
					if (flag4)
					{
						Player.SmartCursorSettings.SmartAxeAfterPickaxe = !Player.SmartCursorSettings.SmartAxeAfterPickaxe;
					}
				}
				num19++;
			}
			if (IngameOptions.rightHover != -1 && IngameOptions.rightLock == -1)
			{
				IngameOptions.rightLock = IngameOptions.rightHover;
			}
			for (int n = 0; n < num9 + 1; n++)
			{
				UILinkPointNavigator.SetPosition(2900 + n, vector3 + vector4 * (float)(n + 1));
			}
			int num23 = 0;
			Vector2 zero = Vector2.Zero;
			if (flag)
			{
				zero.X = -40f;
			}
			for (int num24 = 0; num24 < num11; num24++)
			{
				if (!IngameOptions.skipRightSlot[num24])
				{
					UILinkPointNavigator.SetPosition(2930 + num23, vector5 + zero + vector6 * (float)(num24 + 1));
					num23++;
				}
			}
			UILinkPointNavigator.Shortcuts.INGAMEOPTIONS_BUTTONS_RIGHT = num23;
			Main.DrawGamepadInstructions();
			Main.mouseText = false;
			Main.instance.GUIBarsDraw();
			Main.instance.DrawMouseOver();
			Main.DrawCursor(Main.DrawThickCursor(false), false);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000F3CC File Offset: 0x0000D5CC
		public static void MouseOver()
		{
			if (!Main.ingameOptionsWindow)
			{
				return;
			}
			if (IngameOptions._GUIHover.Contains(Main.MouseScreen.ToPoint()))
			{
				Main.mouseText = true;
			}
			if (IngameOptions._mouseOverText != null)
			{
				Main.instance.MouseText(IngameOptions._mouseOverText, 0, 0, -1, -1, -1, -1);
			}
			IngameOptions._mouseOverText = null;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000F420 File Offset: 0x0000D620
		public static bool DrawLeftSide(SpriteBatch sb, string txt, int i, Vector2 anchor, Vector2 offset, float[] scales, float minscale = 0.7f, float maxscale = 0.8f, float scalespeed = 0.01f)
		{
			bool arg_25_0 = i == IngameOptions.category;
			Color color = Color.Lerp(Color.Gray, Color.White, (scales[i] - minscale) / (maxscale - minscale));
			if (arg_25_0)
			{
				color = Color.Gold;
			}
			Vector2 vector = Utils.DrawBorderStringBig(sb, txt, anchor + offset * (float)(1 + i), color, scales[i], 0.5f, 0.5f, -1);
			return new Rectangle((int)anchor.X - (int)vector.X / 2, (int)anchor.Y + (int)(offset.Y * (float)(1 + i)) - (int)vector.Y / 2, (int)vector.X, (int)vector.Y).Contains(new Point(Main.mouseX, Main.mouseY));
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000F4E4 File Offset: 0x0000D6E4
		public static bool DrawRightSide(SpriteBatch sb, string txt, int i, Vector2 anchor, Vector2 offset, float scale, float colorScale, Color over = default(Color))
		{
			Color color = Color.Lerp(Color.Gray, Color.White, colorScale);
			if (over != default(Color))
			{
				color = over;
			}
			Vector2 vector = Utils.DrawBorderString(sb, txt, anchor + offset * (float)(1 + i), color, scale, 0.5f, 0.5f, -1);
			IngameOptions.valuePosition = anchor + offset * (float)(1 + i) + vector * new Vector2(0.5f, 0f);
			return new Rectangle((int)anchor.X - (int)vector.X / 2, (int)anchor.Y + (int)(offset.Y * (float)(1 + i)) - (int)vector.Y / 2, (int)vector.X, (int)vector.Y).Contains(new Point(Main.mouseX, Main.mouseY));
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000F5D0 File Offset: 0x0000D7D0
		public static bool DrawValue(SpriteBatch sb, string txt, int i, float scale, Color over = default(Color))
		{
			Color color = Color.Gray;
			Vector2 vector = Main.fontMouseText.MeasureString(txt) * scale;
			bool expr_62 = new Rectangle((int)IngameOptions.valuePosition.X, (int)IngameOptions.valuePosition.Y - (int)vector.Y / 2, (int)vector.X, (int)vector.Y).Contains(new Point(Main.mouseX, Main.mouseY));
			if (expr_62)
			{
				color = Color.White;
			}
			if (over != default(Color))
			{
				color = over;
			}
			Utils.DrawBorderString(sb, txt, IngameOptions.valuePosition, color, scale, 0f, 0.5f, -1);
			IngameOptions.valuePosition.X = IngameOptions.valuePosition.X + vector.X;
			return expr_62;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000F690 File Offset: 0x0000D890
		public static float DrawValueBar(SpriteBatch sb, float scale, float perc, int lockState = 0, Utils.ColorLerpMethod colorMethod = null)
		{
			if (colorMethod == null)
			{
				colorMethod = new Utils.ColorLerpMethod(Utils.ColorLerp_BlackToWhite);
			}
			Texture2D colorBarTexture = Main.colorBarTexture;
			Vector2 vector = new Vector2((float)colorBarTexture.Width, (float)colorBarTexture.Height) * scale;
			IngameOptions.valuePosition.X = IngameOptions.valuePosition.X - (float)((int)vector.X);
			Rectangle rectangle = new Rectangle((int)IngameOptions.valuePosition.X, (int)IngameOptions.valuePosition.Y - (int)vector.Y / 2, (int)vector.X, (int)vector.Y);
			Rectangle destinationRectangle = rectangle;
			sb.Draw(colorBarTexture, rectangle, Color.White);
			int num = 167;
			float num2 = (float)rectangle.X + 5f * scale;
			float num3 = (float)rectangle.Y + 4f * scale;
			for (float num4 = 0f; num4 < (float)num; num4 += 1f)
			{
				float percent = num4 / (float)num;
				sb.Draw(Main.colorBlipTexture, new Vector2(num2 + num4 * scale, num3), null, colorMethod(percent), 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
			}
			rectangle.X = (int)num2;
			rectangle.Y = (int)num3;
			bool flag = rectangle.Contains(new Point(Main.mouseX, Main.mouseY));
			if (lockState == 2)
			{
				flag = false;
			}
			if (flag || lockState == 1)
			{
				sb.Draw(Main.colorHighlightTexture, destinationRectangle, Main.OurFavoriteColor);
			}
			sb.Draw(Main.colorSliderTexture, new Vector2(num2 + 167f * scale * perc, num3 + 4f * scale), null, Color.White, 0f, new Vector2(0.5f * (float)Main.colorSliderTexture.Width, 0.5f * (float)Main.colorSliderTexture.Height), scale, SpriteEffects.None, 0f);
			if (Main.mouseX >= rectangle.X && Main.mouseX <= rectangle.X + rectangle.Width)
			{
				IngameOptions.inBar = flag;
				return (float)(Main.mouseX - rectangle.X) / (float)rectangle.Width;
			}
			IngameOptions.inBar = false;
			if (rectangle.X >= Main.mouseX)
			{
				return 0f;
			}
			return 1f;
		}

		// Token: 0x04000080 RID: 128
		public const int width = 670;

		// Token: 0x04000081 RID: 129
		public const int height = 480;

		// Token: 0x04000082 RID: 130
		public static float[] leftScale = new float[]
		{
			0.7f,
			0.7f,
			0.7f,
			0.7f,
			0.7f,
			0.7f,
			0.7f,
			0.7f,
			0.7f
		};

		// Token: 0x04000083 RID: 131
		public static float[] rightScale = new float[]
		{
			0.7f,
			0.7f,
			0.7f,
			0.7f,
			0.7f,
			0.7f,
			0.7f,
			0.7f,
			0.7f,
			0.7f,
			0.7f,
			0.7f,
			0.7f,
			0.7f,
			0.7f
		};

		// Token: 0x04000084 RID: 132
		public static bool[] skipRightSlot = new bool[20];

		// Token: 0x04000085 RID: 133
		public static int leftHover = -1;

		// Token: 0x04000086 RID: 134
		public static int rightHover = -1;

		// Token: 0x04000087 RID: 135
		public static int oldLeftHover = -1;

		// Token: 0x04000088 RID: 136
		public static int oldRightHover = -1;

		// Token: 0x04000089 RID: 137
		public static int rightLock = -1;

		// Token: 0x0400008A RID: 138
		public static bool inBar = false;

		// Token: 0x0400008B RID: 139
		public static bool notBar = false;

		// Token: 0x0400008C RID: 140
		public static bool noSound = false;

		// Token: 0x0400008D RID: 141
		private static Rectangle _GUIHover = default(Rectangle);

		// Token: 0x0400008E RID: 142
		public static int category = 0;

		// Token: 0x0400008F RID: 143
		public static Vector2 valuePosition = Vector2.Zero;

		// Token: 0x04000090 RID: 144
		private static string _mouseOverText;
	}
}

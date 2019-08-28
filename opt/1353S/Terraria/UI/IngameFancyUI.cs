using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Achievements;
using Terraria.GameContent.UI.States;
using Terraria.GameInput;
using Terraria.Localization;
using Terraria.UI.Gamepad;

namespace Terraria.UI
{
	// Token: 0x020000A5 RID: 165
	public class IngameFancyUI
	{
		// Token: 0x06000BB7 RID: 2999 RVA: 0x003CF086 File Offset: 0x003CD286
		public static bool CanCover()
		{
			if (IngameFancyUI.CoverForOneUIFrame)
			{
				IngameFancyUI.CoverForOneUIFrame = false;
				return true;
			}
			return false;
		}

		// Token: 0x06000BBB RID: 3003 RVA: 0x003CF10E File Offset: 0x003CD30E
		public static bool CanShowVirtualKeyboard(int context)
		{
			return UIVirtualKeyboard.CanDisplay(context);
		}

		// Token: 0x06000BBD RID: 3005 RVA: 0x003CF374 File Offset: 0x003CD574
		public static void Close()
		{
			Main.inFancyUI = false;
			Main.PlaySound(11, -1, -1, 1, 1f, 0f);
			if (!Main.gameMenu && (!(Main.InGameUI.CurrentState is UIVirtualKeyboard) || UIVirtualKeyboard.KeyboardContext == 2))
			{
				Main.playerInventory = true;
			}
			Main.InGameUI.SetState(null);
			UILinkPointNavigator.Shortcuts.FANCYUI_SPECIAL_INSTRUCTIONS = 0;
		}

		// Token: 0x06000BB6 RID: 2998 RVA: 0x003CF07E File Offset: 0x003CD27E
		public static void CoverNextFrame()
		{
			IngameFancyUI.CoverForOneUIFrame = true;
		}

		// Token: 0x06000BBE RID: 3006 RVA: 0x003CF3D4 File Offset: 0x003CD5D4
		public static bool Draw(SpriteBatch spriteBatch, GameTime gameTime)
		{
			if (!Main.gameMenu && Main.player[Main.myPlayer].dead && !Main.player[Main.myPlayer].ghost)
			{
				IngameFancyUI.Close();
				Main.playerInventory = false;
				return false;
			}
			bool result = false;
			if (Main.InGameUI.CurrentState is UIVirtualKeyboard && UIVirtualKeyboard.KeyboardContext > 0)
			{
				if (!Main.inFancyUI)
				{
					Main.InGameUI.SetState(null);
				}
				if (Main.screenWidth >= 1705 || !PlayerInput.UsingGamepad)
				{
					result = true;
				}
			}
			if (!Main.gameMenu)
			{
				Main.mouseText = false;
				if (Main.InGameUI != null && Main.InGameUI.IsElementUnderMouse())
				{
					Main.player[Main.myPlayer].mouseInterface = true;
				}
				Main.instance.GUIBarsDraw();
				if (Main.InGameUI.CurrentState is UIVirtualKeyboard && UIVirtualKeyboard.KeyboardContext > 0)
				{
					Main.instance.GUIChatDraw();
				}
				if (!Main.inFancyUI)
				{
					Main.InGameUI.SetState(null);
				}
				Main.instance.DrawMouseOver();
				Main.DrawCursor(Main.DrawThickCursor(false), false);
			}
			return result;
		}

		// Token: 0x06000BBF RID: 3007 RVA: 0x003CF4E2 File Offset: 0x003CD6E2
		public static void MouseOver()
		{
			if (!Main.inFancyUI)
			{
				return;
			}
			if (Main.InGameUI.IsElementUnderMouse())
			{
				Main.mouseText = true;
			}
		}

		// Token: 0x06000BB8 RID: 3000 RVA: 0x003CF098 File Offset: 0x003CD298
		public static void OpenAchievements()
		{
			IngameFancyUI.CoverNextFrame();
			Main.playerInventory = false;
			Main.editChest = false;
			Main.npcChatText = "";
			Main.inFancyUI = true;
			Main.InGameUI.SetState(Main.AchievementsMenu);
		}

		// Token: 0x06000BB9 RID: 3001 RVA: 0x003CF0CA File Offset: 0x003CD2CA
		public static void OpenAchievementsAndGoto(Achievement achievement)
		{
			IngameFancyUI.OpenAchievements();
			Main.AchievementsMenu.GotoAchievement(achievement);
		}

		// Token: 0x06000BBA RID: 3002 RVA: 0x003CF0DC File Offset: 0x003CD2DC
		public static void OpenKeybinds()
		{
			IngameFancyUI.CoverNextFrame();
			Main.playerInventory = false;
			Main.editChest = false;
			Main.npcChatText = "";
			Main.inFancyUI = true;
			Main.InGameUI.SetState(Main.ManageControlsMenu);
		}

		// Token: 0x06000BBC RID: 3004 RVA: 0x003CF118 File Offset: 0x003CD318
		public static void OpenVirtualKeyboard(int keyboardContext)
		{
			IngameFancyUI.CoverNextFrame();
			Main.PlaySound(12, -1, -1, 1, 1f, 0f);
			string text = "";
			if (keyboardContext != 1)
			{
				if (keyboardContext == 2)
				{
					text = Language.GetTextValue("UI.EnterNewName");
					Player player = Main.player[Main.myPlayer];
					Main.npcChatText = Main.chest[player.chest].name;
					if (Main.tile[player.chestX, player.chestY].type == 21)
					{
						Main.defaultChestName = Lang.chestType[(int)(Main.tile[player.chestX, player.chestY].frameX / 36)].Value;
					}
					if (Main.tile[player.chestX, player.chestY].type == 467)
					{
						Main.defaultChestName = Lang.chestType2[(int)(Main.tile[player.chestX, player.chestY].frameX / 36)].Value;
					}
					if (Main.tile[player.chestX, player.chestY].type == 88)
					{
						Main.defaultChestName = Lang.dresserType[(int)(Main.tile[player.chestX, player.chestY].frameX / 54)].Value;
					}
					if (Main.npcChatText == "")
					{
						Main.npcChatText = Main.defaultChestName;
					}
					Main.editChest = true;
				}
			}
			else
			{
				Main.editSign = true;
				text = Language.GetTextValue("UI.EnterMessage");
			}
			Main.clrInput();
			if (!IngameFancyUI.CanShowVirtualKeyboard(keyboardContext))
			{
				return;
			}
			Main.inFancyUI = true;
			if (keyboardContext != 1)
			{
				if (keyboardContext == 2)
				{
					UserInterface arg_243_0 = Main.InGameUI;
					string arg_23E_0 = text;
					string arg_23E_1 = Main.npcChatText;
					arg_243_0.SetState(new UIVirtualKeyboard(arg_23E_0, arg_23E_1, (s) => {
						ChestUI.RenameChestSubmit(Main.player[Main.myPlayer]);
						IngameFancyUI.Close();
					}, () => {
						ChestUI.RenameChestCancel();
						IngameFancyUI.Close();
					}, keyboardContext, false));
				}
			}
			else
			{
				UserInterface arg_1EC_0 = Main.InGameUI;
				string arg_1E7_0 = text;
				string arg_1E7_1 = Main.npcChatText;
				arg_1EC_0.SetState(new UIVirtualKeyboard(arg_1E7_0, arg_1E7_1, (s) => {
					Main.SubmitSignText();
					IngameFancyUI.Close();
				}, () => {
					Main.InputTextSignCancel();
					IngameFancyUI.Close();
				}, keyboardContext, false));
			}
			UILinkPointNavigator.GoToDefaultPage(1);
		}

		// Token: 0x04000EB8 RID: 3768
		private static bool CoverForOneUIFrame;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria.GameInput;

namespace Terraria.UI.Gamepad
{
	// Token: 0x020000BB RID: 187
	public class UILinkPointNavigator
	{
		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000C95 RID: 3221 RVA: 0x003DA628 File Offset: 0x003D8828
		public static int CurrentPoint
		{
			get
			{
				return UILinkPointNavigator.Pages[UILinkPointNavigator.CurrentPage].CurrentPoint;
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000C96 RID: 3222 RVA: 0x003DA640 File Offset: 0x003D8840
		public static bool Available
		{
			get
			{
				return Main.playerInventory || Main.ingameOptionsWindow || Main.player[Main.myPlayer].talkNPC != -1 || Main.player[Main.myPlayer].sign != -1 || Main.mapFullscreen || Main.clothesWindow || Main.MenuUI.IsVisible || Main.InGameUI.IsVisible;
			}
		}

		// Token: 0x06000C97 RID: 3223 RVA: 0x003DA6A8 File Offset: 0x003D88A8
		public static void GoToDefaultPage(int specialFlag = 0)
		{
			if (Main.MenuUI.IsVisible)
			{
				UILinkPointNavigator.CurrentPage = 1004;
				return;
			}
			if (Main.InGameUI.IsVisible || specialFlag == 1)
			{
				UILinkPointNavigator.CurrentPage = 1004;
				return;
			}
			if (Main.gameMenu)
			{
				UILinkPointNavigator.CurrentPage = 1000;
				return;
			}
			if (Main.ingameOptionsWindow)
			{
				UILinkPointNavigator.CurrentPage = 1001;
				return;
			}
			if (Main.hairWindow)
			{
				UILinkPointNavigator.CurrentPage = 12;
				return;
			}
			if (Main.clothesWindow)
			{
				UILinkPointNavigator.CurrentPage = 15;
				return;
			}
			if (Main.npcShop != 0)
			{
				UILinkPointNavigator.CurrentPage = 13;
				return;
			}
			if (Main.InGuideCraftMenu)
			{
				UILinkPointNavigator.CurrentPage = 9;
				return;
			}
			if (Main.InReforgeMenu)
			{
				UILinkPointNavigator.CurrentPage = 5;
				return;
			}
			if (Main.player[Main.myPlayer].chest != -1)
			{
				UILinkPointNavigator.CurrentPage = 4;
				return;
			}
			if (Main.player[Main.myPlayer].talkNPC != -1 || Main.player[Main.myPlayer].sign != -1)
			{
				UILinkPointNavigator.CurrentPage = 1003;
				return;
			}
			UILinkPointNavigator.CurrentPage = 0;
		}

		// Token: 0x06000C98 RID: 3224 RVA: 0x003DA7A8 File Offset: 0x003D89A8
		public static void Update()
		{
			bool inUse = UILinkPointNavigator.InUse;
			UILinkPointNavigator.InUse = false;
			bool flag = true;
			if (flag)
			{
				InputMode currentInputMode = PlayerInput.CurrentInputMode;
				if (currentInputMode <= InputMode.Mouse && !Main.gameMenu)
				{
					flag = false;
				}
			}
			if (flag && PlayerInput.NavigatorRebindingLock > 0)
			{
				flag = false;
			}
			if (flag && !Main.gameMenu && !PlayerInput.UsingGamepadUI)
			{
				flag = false;
			}
			if (flag && !Main.gameMenu && PlayerInput.InBuildingMode)
			{
				flag = false;
			}
			if (flag && !Main.gameMenu && !UILinkPointNavigator.Available)
			{
				flag = false;
			}
			bool flag2 = false;
			UILinkPage uILinkPage;
			if (!UILinkPointNavigator.Pages.TryGetValue(UILinkPointNavigator.CurrentPage, out uILinkPage))
			{
				flag2 = true;
			}
			else if (!uILinkPage.IsValid())
			{
				flag2 = true;
			}
			if (flag2)
			{
				UILinkPointNavigator.GoToDefaultPage(0);
				UILinkPointNavigator.ProcessChanges();
				flag = false;
			}
			if (inUse != flag)
			{
				if (!flag)
				{
					uILinkPage.Leave();
					UILinkPointNavigator.GoToDefaultPage(0);
					UILinkPointNavigator.ProcessChanges();
				}
				else
				{
					UILinkPointNavigator.GoToDefaultPage(0);
					UILinkPointNavigator.ProcessChanges();
					uILinkPage.Enter();
				}
				if (flag)
				{
					Main.player[Main.myPlayer].releaseInventory = false;
					Main.player[Main.myPlayer].releaseUseTile = false;
					PlayerInput.LockTileUseButton = true;
				}
				if (!Main.gameMenu)
				{
					if (flag)
					{
						PlayerInput.NavigatorCachePosition();
					}
					else
					{
						PlayerInput.NavigatorUnCachePosition();
					}
				}
			}
			if (!flag)
			{
				return;
			}
			UILinkPointNavigator.InUse = true;
			UILinkPointNavigator.OverridePoint = -1;
			if (UILinkPointNavigator.PageLeftCD > 0)
			{
				UILinkPointNavigator.PageLeftCD--;
			}
			if (UILinkPointNavigator.PageRightCD > 0)
			{
				UILinkPointNavigator.PageRightCD--;
			}
			Vector2 navigatorDirections = PlayerInput.Triggers.Current.GetNavigatorDirections();
			bool flag3 = PlayerInput.Triggers.Current.HotbarMinus && !PlayerInput.Triggers.Current.HotbarPlus;
			object arg_1AC_0 = PlayerInput.Triggers.Current.HotbarPlus && !PlayerInput.Triggers.Current.HotbarMinus;
			if (!flag3)
			{
				UILinkPointNavigator.PageLeftCD = 0;
			}
			object expr_1AC = arg_1AC_0;
			if (expr_1AC == null)
			{
				UILinkPointNavigator.PageRightCD = 0;
			}
			flag3 = (flag3 && UILinkPointNavigator.PageLeftCD == 0);
			object arg_23F_0 = expr_1AC != null && UILinkPointNavigator.PageRightCD == 0;
			if (UILinkPointNavigator.LastInput.X != navigatorDirections.X)
			{
				UILinkPointNavigator.XCooldown = 0;
			}
			if (UILinkPointNavigator.LastInput.Y != navigatorDirections.Y)
			{
				UILinkPointNavigator.YCooldown = 0;
			}
			if (UILinkPointNavigator.XCooldown > 0)
			{
				UILinkPointNavigator.XCooldown--;
			}
			if (UILinkPointNavigator.YCooldown > 0)
			{
				UILinkPointNavigator.YCooldown--;
			}
			UILinkPointNavigator.LastInput = navigatorDirections;
			if (flag3)
			{
				UILinkPointNavigator.PageLeftCD = 16;
			}
			object expr_23F = arg_23F_0;
			if (expr_23F != null)
			{
				UILinkPointNavigator.PageRightCD = 16;
			}
			UILinkPointNavigator.Pages[UILinkPointNavigator.CurrentPage].Update();
			int num = 10;
			if (!Main.gameMenu && Main.playerInventory && !Main.ingameOptionsWindow && !Main.inFancyUI && (UILinkPointNavigator.CurrentPage == 0 || UILinkPointNavigator.CurrentPage == 4 || UILinkPointNavigator.CurrentPage == 2 || UILinkPointNavigator.CurrentPage == 1))
			{
				num = PlayerInput.CurrentProfile.InventoryMoveCD;
			}
			if (navigatorDirections.X == -1f && UILinkPointNavigator.XCooldown == 0)
			{
				UILinkPointNavigator.XCooldown = num;
				UILinkPointNavigator.Pages[UILinkPointNavigator.CurrentPage].TravelLeft();
			}
			if (navigatorDirections.X == 1f && UILinkPointNavigator.XCooldown == 0)
			{
				UILinkPointNavigator.XCooldown = num;
				UILinkPointNavigator.Pages[UILinkPointNavigator.CurrentPage].TravelRight();
			}
			if (navigatorDirections.Y == -1f && UILinkPointNavigator.YCooldown == 0)
			{
				UILinkPointNavigator.YCooldown = num;
				UILinkPointNavigator.Pages[UILinkPointNavigator.CurrentPage].TravelUp();
			}
			if (navigatorDirections.Y == 1f && UILinkPointNavigator.YCooldown == 0)
			{
				UILinkPointNavigator.YCooldown = num;
				UILinkPointNavigator.Pages[UILinkPointNavigator.CurrentPage].TravelDown();
			}
			UILinkPointNavigator.XCooldown = (UILinkPointNavigator.YCooldown = Math.Max(UILinkPointNavigator.XCooldown, UILinkPointNavigator.YCooldown));
			if (flag3)
			{
				UILinkPointNavigator.Pages[UILinkPointNavigator.CurrentPage].SwapPageLeft();
			}
			if (expr_23F != null)
			{
				UILinkPointNavigator.Pages[UILinkPointNavigator.CurrentPage].SwapPageRight();
			}
			if (PlayerInput.Triggers.Current.UsedMovementKey)
			{
				Vector2 position = UILinkPointNavigator.Points[UILinkPointNavigator.CurrentPoint].Position;
				Vector2 arg_404_0 = new Vector2((float)PlayerInput.MouseX, (float)PlayerInput.MouseY);
				float amount = 0.3f;
				if (PlayerInput.InvisibleGamepadInMenus)
				{
					amount = 1f;
				}
				Vector2 vector = Vector2.Lerp(arg_404_0, position, amount);
				if (Main.gameMenu)
				{
					if (Math.Abs(vector.X - position.X) <= 5f)
					{
						vector.X = position.X;
					}
					if (Math.Abs(vector.Y - position.Y) <= 5f)
					{
						vector.Y = position.Y;
					}
				}
				PlayerInput.MouseX = (int)vector.X;
				PlayerInput.MouseY = (int)vector.Y;
			}
			UILinkPointNavigator.ResetFlagsEnd();
		}

		// Token: 0x06000C99 RID: 3225 RVA: 0x003DAC38 File Offset: 0x003D8E38
		public static void ResetFlagsEnd()
		{
			UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 0;
			UILinkPointNavigator.Shortcuts.BackButtonLock = false;
			UILinkPointNavigator.Shortcuts.BackButtonCommand = 0;
		}

		// Token: 0x06000C9A RID: 3226 RVA: 0x003DAC4C File Offset: 0x003D8E4C
		public static string GetInstructions()
		{
			string text = UILinkPointNavigator.Pages[UILinkPointNavigator.CurrentPage].SpecialInteractions();
			string text2 = UILinkPointNavigator.Points[UILinkPointNavigator.CurrentPoint].SpecialInteractions();
			if (!string.IsNullOrEmpty(text2))
			{
				if (string.IsNullOrEmpty(text))
				{
					return text2;
				}
				text = text + "   " + text2;
			}
			return text;
		}

		// Token: 0x06000C9B RID: 3227 RVA: 0x003DACA4 File Offset: 0x003D8EA4
		public static void SetPosition(int ID, Vector2 Position)
		{
			UILinkPointNavigator.Points[ID].Position = Position * Main.UIScale;
		}

		// Token: 0x06000C9C RID: 3228 RVA: 0x003DACC4 File Offset: 0x003D8EC4
		public static void RegisterPage(UILinkPage page, int ID, bool automatedDefault = true)
		{
			if (automatedDefault)
			{
				page.DefaultPoint = page.LinkMap.Keys.First<int>();
			}
			page.CurrentPoint = page.DefaultPoint;
			page.ID = ID;
			UILinkPointNavigator.Pages.Add(page.ID, page);
			foreach (KeyValuePair<int, UILinkPoint> current in page.LinkMap)
			{
				current.Value.SetPage(ID);
				UILinkPointNavigator.Points.Add(current.Key, current.Value);
			}
		}

		// Token: 0x06000C9D RID: 3229 RVA: 0x003DAD74 File Offset: 0x003D8F74
		public static void ChangePage(int PageID)
		{
			if (UILinkPointNavigator.Pages.ContainsKey(PageID) && UILinkPointNavigator.Pages[PageID].CanEnter())
			{
				UILinkPointNavigator.CurrentPage = PageID;
				UILinkPointNavigator.ProcessChanges();
			}
		}

		// Token: 0x06000C9E RID: 3230 RVA: 0x003DADA0 File Offset: 0x003D8FA0
		public static void ChangePoint(int PointID)
		{
			if (UILinkPointNavigator.Points.ContainsKey(PointID))
			{
				UILinkPointNavigator.CurrentPage = UILinkPointNavigator.Points[PointID].Page;
				UILinkPointNavigator.OverridePoint = PointID;
				UILinkPointNavigator.ProcessChanges();
			}
		}

		// Token: 0x06000C9F RID: 3231 RVA: 0x003DADD0 File Offset: 0x003D8FD0
		public static void ProcessChanges()
		{
			UILinkPage uILinkPage = UILinkPointNavigator.Pages[UILinkPointNavigator.OldPage];
			if (UILinkPointNavigator.OldPage != UILinkPointNavigator.CurrentPage)
			{
				uILinkPage.Leave();
				if (!UILinkPointNavigator.Pages.TryGetValue(UILinkPointNavigator.CurrentPage, out uILinkPage))
				{
					UILinkPointNavigator.GoToDefaultPage(0);
					UILinkPointNavigator.ProcessChanges();
					UILinkPointNavigator.OverridePoint = -1;
				}
				uILinkPage.CurrentPoint = uILinkPage.DefaultPoint;
				uILinkPage.Enter();
				uILinkPage.Update();
				UILinkPointNavigator.OldPage = UILinkPointNavigator.CurrentPage;
			}
			if (UILinkPointNavigator.OverridePoint != -1 && uILinkPage.LinkMap.ContainsKey(UILinkPointNavigator.OverridePoint))
			{
				uILinkPage.CurrentPoint = UILinkPointNavigator.OverridePoint;
			}
		}

		// Token: 0x04001025 RID: 4133
		public static Dictionary<int, UILinkPage> Pages = new Dictionary<int, UILinkPage>();

		// Token: 0x04001026 RID: 4134
		public static Dictionary<int, UILinkPoint> Points = new Dictionary<int, UILinkPoint>();

		// Token: 0x04001027 RID: 4135
		public static int CurrentPage = 1000;

		// Token: 0x04001028 RID: 4136
		public static int OldPage = 1000;

		// Token: 0x04001029 RID: 4137
		private static int XCooldown = 0;

		// Token: 0x0400102A RID: 4138
		private static int YCooldown = 0;

		// Token: 0x0400102B RID: 4139
		private static Vector2 LastInput;

		// Token: 0x0400102C RID: 4140
		private static int PageLeftCD = 0;

		// Token: 0x0400102D RID: 4141
		private static int PageRightCD = 0;

		// Token: 0x0400102E RID: 4142
		public static bool InUse;

		// Token: 0x0400102F RID: 4143
		public static int OverridePoint = -1;

		// Token: 0x02000259 RID: 601
		public static class Shortcuts
		{
			// Token: 0x040038BF RID: 14527
			public static int NPCS_IconsPerColumn = 100;

			// Token: 0x040038C0 RID: 14528
			public static int NPCS_IconsTotal = 0;

			// Token: 0x040038C1 RID: 14529
			public static int NPCS_LastHovered = -1;

			// Token: 0x040038C2 RID: 14530
			public static bool NPCS_IconsDisplay = false;

			// Token: 0x040038C3 RID: 14531
			public static int CRAFT_IconsPerRow = 100;

			// Token: 0x040038C4 RID: 14532
			public static int CRAFT_IconsPerColumn = 100;

			// Token: 0x040038C5 RID: 14533
			public static int CRAFT_CurrentIngridientsCount = 0;

			// Token: 0x040038C6 RID: 14534
			public static int CRAFT_CurrentRecipeBig = 0;

			// Token: 0x040038C7 RID: 14535
			public static int CRAFT_CurrentRecipeSmall = 0;

			// Token: 0x040038C8 RID: 14536
			public static bool NPCCHAT_ButtonsLeft = false;

			// Token: 0x040038C9 RID: 14537
			public static bool NPCCHAT_ButtonsMiddle = false;

			// Token: 0x040038CA RID: 14538
			public static bool NPCCHAT_ButtonsRight = false;

			// Token: 0x040038CB RID: 14539
			public static int INGAMEOPTIONS_BUTTONS_LEFT = 0;

			// Token: 0x040038CC RID: 14540
			public static int INGAMEOPTIONS_BUTTONS_RIGHT = 0;

			// Token: 0x040038CD RID: 14541
			public static int OPTIONS_BUTTON_SPECIALFEATURE = 0;

			// Token: 0x040038CE RID: 14542
			public static int BackButtonCommand = 0;

			// Token: 0x040038CF RID: 14543
			public static bool BackButtonInUse = false;

			// Token: 0x040038D0 RID: 14544
			public static bool BackButtonLock = false;

			// Token: 0x040038D1 RID: 14545
			public static int FANCYUI_HIGHEST_INDEX = 1;

			// Token: 0x040038D2 RID: 14546
			public static int FANCYUI_SPECIAL_INSTRUCTIONS = 0;

			// Token: 0x040038D3 RID: 14547
			public static int INFOACCCOUNT = 0;

			// Token: 0x040038D4 RID: 14548
			public static int BUILDERACCCOUNT = 0;

			// Token: 0x040038D5 RID: 14549
			public static int BUFFS_PER_COLUMN = 0;

			// Token: 0x040038D6 RID: 14550
			public static int BUFFS_DRAWN = 0;

			// Token: 0x040038D7 RID: 14551
			public static int INV_MOVE_OPTION_CD = 0;
		}
	}
}

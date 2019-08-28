using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Achievements;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.Graphics;
using Terraria.Localization;
using Terraria.UI;
using Terraria.UI.Gamepad;

namespace Terraria.GameContent.UI.States
{
	// Token: 0x02000141 RID: 321
	public class UIAchievementsMenu : UIState
	{
		// Token: 0x060010BA RID: 4282 RVA: 0x00405D28 File Offset: 0x00403F28
		public void InitializePage()
		{
			base.RemoveAllChildren();
			this._categoryButtons.Clear();
			this._achievementElements.Clear();
			this._achievementsList = null;
			bool flag = true;
			int num = flag.ToInt() * 100;
			UIElement uIElement = new UIElement();
			uIElement.Width.Set(0f, 0.8f);
			uIElement.MaxWidth.Set(800f + (float)num, 0f);
			uIElement.MinWidth.Set(600f + (float)num, 0f);
			uIElement.Top.Set(220f, 0f);
			uIElement.Height.Set(-220f, 1f);
			uIElement.HAlign = 0.5f;
			this._outerContainer = uIElement;
			base.Append(uIElement);
			UIPanel uIPanel = new UIPanel();
			uIPanel.Width.Set(0f, 1f);
			uIPanel.Height.Set(-110f, 1f);
			uIPanel.BackgroundColor = new Color(33, 43, 79) * 0.8f;
			uIPanel.PaddingTop = 0f;
			uIElement.Append(uIPanel);
			this._achievementsList = new UIList();
			this._achievementsList.Width.Set(-25f, 1f);
			this._achievementsList.Height.Set(-50f, 1f);
			this._achievementsList.Top.Set(50f, 0f);
			this._achievementsList.ListPadding = 5f;
			uIPanel.Append(this._achievementsList);
			UITextPanel<LocalizedText> uITextPanel = new UITextPanel<LocalizedText>(Language.GetText("UI.Achievements"), 1f, true);
			uITextPanel.HAlign = 0.5f;
			uITextPanel.Top.Set(-33f, 0f);
			uITextPanel.SetPadding(13f);
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
			this._backpanel = uITextPanel2;
			List<Achievement> list = Main.Achievements.CreateAchievementsList();
			for (int i = 0; i < list.Count; i++)
			{
				UIAchievementListItem item = new UIAchievementListItem(list[i], flag);
				this._achievementsList.Add(item);
				this._achievementElements.Add(item);
			}
			UIScrollbar uIScrollbar = new UIScrollbar();
			uIScrollbar.SetView(100f, 1000f);
			uIScrollbar.Height.Set(-50f, 1f);
			uIScrollbar.Top.Set(50f, 0f);
			uIScrollbar.HAlign = 1f;
			uIPanel.Append(uIScrollbar);
			this._achievementsList.SetScrollbar(uIScrollbar);
			UIElement uIElement2 = new UIElement();
			uIElement2.Width.Set(0f, 1f);
			uIElement2.Height.Set(32f, 0f);
			uIElement2.Top.Set(10f, 0f);
			Texture2D texture = TextureManager.Load("Images/UI/Achievement_Categories");
			for (int j = 0; j < 4; j++)
			{
				UIToggleImage uIToggleImage = new UIToggleImage(texture, 32, 32, new Point(34 * j, 0), new Point(34 * j, 34));
				uIToggleImage.Left.Set((float)(j * 36 + 8), 0f);
				uIToggleImage.SetState(true);
				uIToggleImage.OnClick += new UIElement.MouseEvent(this.FilterList);
				this._categoryButtons.Add(uIToggleImage);
				uIElement2.Append(uIToggleImage);
			}
			uIPanel.Append(uIElement2);
		}

		// Token: 0x060010BB RID: 4283 RVA: 0x00406170 File Offset: 0x00404370
		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
			for (int i = 0; i < this._categoryButtons.Count; i++)
			{
				if (this._categoryButtons[i].IsMouseHovering)
				{
					string textValue;
					switch (i)
					{
					case -1:
						textValue = Language.GetTextValue("Achievements.NoCategory");
						break;
					case 0:
						textValue = Language.GetTextValue("Achievements.SlayerCategory");
						break;
					case 1:
						textValue = Language.GetTextValue("Achievements.CollectorCategory");
						break;
					case 2:
						textValue = Language.GetTextValue("Achievements.ExplorerCategory");
						break;
					case 3:
						textValue = Language.GetTextValue("Achievements.ChallengerCategory");
						break;
					default:
						textValue = Language.GetTextValue("Achievements.NoCategory");
						break;
					}
					float x = Main.fontMouseText.MeasureString(textValue).X;
					Vector2 vector = new Vector2((float)Main.mouseX, (float)Main.mouseY) + new Vector2(16f);
					if (vector.Y > (float)(Main.screenHeight - 30))
					{
						vector.Y = (float)(Main.screenHeight - 30);
					}
					if (vector.X > (float)Main.screenWidth - x)
					{
						vector.X = (float)(Main.screenWidth - 460);
					}
					Utils.DrawBorderStringFourWay(spriteBatch, Main.fontMouseText, textValue, vector.X, vector.Y, new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor), Color.Black, Vector2.Zero, 1f);
					break;
				}
			}
			this.SetupGamepadPoints(spriteBatch);
		}

		// Token: 0x060010BC RID: 4284 RVA: 0x004062E8 File Offset: 0x004044E8
		public void GotoAchievement(Achievement achievement)
		{
			this._achievementsList.Goto(delegate(UIElement element)
			{
				UIAchievementListItem uIAchievementListItem = element as UIAchievementListItem;
				return uIAchievementListItem != null && uIAchievementListItem.GetAchievement() == achievement;
			});
		}

		// Token: 0x060010BD RID: 4285 RVA: 0x0040631C File Offset: 0x0040451C
		private void GoBackClick(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.menuMode = 0;
			IngameFancyUI.Close();
		}

		// Token: 0x060010BE RID: 4286 RVA: 0x0040632C File Offset: 0x0040452C
		private void FadedMouseOver(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(12, -1, -1, 1, 1f, 0f);
			((UIPanel)evt.Target).BackgroundColor = new Color(73, 94, 171);
		}

		// Token: 0x060010BF RID: 4287 RVA: 0x00406364 File Offset: 0x00404564
		private void FadedMouseOut(UIMouseEvent evt, UIElement listeningElement)
		{
			((UIPanel)evt.Target).BackgroundColor = new Color(63, 82, 151) * 0.8f;
		}

		// Token: 0x060010C0 RID: 4288 RVA: 0x00406390 File Offset: 0x00404590
		private void FilterList(UIMouseEvent evt, UIElement listeningElement)
		{
			this._achievementsList.Clear();
			foreach (UIAchievementListItem current in this._achievementElements)
			{
				if (this._categoryButtons[(int)current.GetAchievement().Category].IsOn)
				{
					this._achievementsList.Add(current);
				}
			}
			this.Recalculate();
		}

		// Token: 0x060010C1 RID: 4289 RVA: 0x00406418 File Offset: 0x00404618
		public override void OnActivate()
		{
			this.InitializePage();
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
			this._achievementsList.UpdateOrder();
			if (PlayerInput.UsingGamepadUI)
			{
				UILinkPointNavigator.ChangePoint(3002);
			}
		}

		// Token: 0x060010C2 RID: 4290 RVA: 0x004064B8 File Offset: 0x004046B8
		private void SetupGamepadPoints(SpriteBatch spriteBatch)
		{
			UILinkPointNavigator.Shortcuts.BackButtonCommand = 3;
			int num = 3000;
			UILinkPointNavigator.SetPosition(num, this._backpanel.GetInnerDimensions().ToRectangle().Center.ToVector2());
			UILinkPointNavigator.SetPosition(num + 1, this._outerContainer.GetInnerDimensions().ToRectangle().Center.ToVector2());
			int num2 = num;
			UILinkPoint expr_67 = UILinkPointNavigator.Points[num2];
			expr_67.Unlink();
			expr_67.Up = num2 + 1;
			num2++;
			UILinkPoint expr_84 = UILinkPointNavigator.Points[num2];
			expr_84.Unlink();
			expr_84.Up = num2 + 1;
			expr_84.Down = num2 - 1;
			for (int i = 0; i < this._categoryButtons.Count; i++)
			{
				num2++;
				UILinkPointNavigator.Shortcuts.FANCYUI_HIGHEST_INDEX = num2;
				UILinkPointNavigator.SetPosition(num2, this._categoryButtons[i].GetInnerDimensions().ToRectangle().Center.ToVector2());
				UILinkPoint expr_E5 = UILinkPointNavigator.Points[num2];
				expr_E5.Unlink();
				expr_E5.Left = ((i == 0) ? -3 : (num2 - 1));
				expr_E5.Right = ((i == this._categoryButtons.Count - 1) ? -4 : (num2 + 1));
				expr_E5.Down = num;
			}
		}

		// Token: 0x04003182 RID: 12674
		private UIList _achievementsList;

		// Token: 0x04003183 RID: 12675
		private List<UIAchievementListItem> _achievementElements = new List<UIAchievementListItem>();

		// Token: 0x04003184 RID: 12676
		private List<UIToggleImage> _categoryButtons = new List<UIToggleImage>();

		// Token: 0x04003185 RID: 12677
		private UIElement _backpanel;

		// Token: 0x04003186 RID: 12678
		private UIElement _outerContainer;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.IO;
using Terraria.Localization;
using Terraria.UI;
using Terraria.UI.Gamepad;

namespace Terraria.GameContent.UI.States
{
	// Token: 0x02000142 RID: 322
	public class UIWorldSelect : UIState
	{
		// Token: 0x060010CB RID: 4299 RVA: 0x00405C00 File Offset: 0x00403E00
		public override void Draw(SpriteBatch spriteBatch)
		{
			if (this.skipDraw)
			{
				this.skipDraw = false;
				return;
			}
			if (this.UpdateFavoritesCache())
			{
				this.skipDraw = true;
				Main.MenuUI.Draw(spriteBatch, new GameTime());
			}
			base.Draw(spriteBatch);
			this.SetupGamepadPoints(spriteBatch);
		}

		// Token: 0x060010C8 RID: 4296 RVA: 0x00402D6B File Offset: 0x00400F6B
		private void FadedMouseOut(UIMouseEvent evt, UIElement listeningElement)
		{
			((UIPanel)evt.Target).BackgroundColor = new Color(63, 82, 151) * 0.7f;
		}

		// Token: 0x060010C7 RID: 4295 RVA: 0x00402D36 File Offset: 0x00400F36
		private void FadedMouseOver(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(12, -1, -1, 1, 1f, 0f);
			((UIPanel)evt.Target).BackgroundColor = new Color(73, 94, 171);
		}

		// Token: 0x060010C6 RID: 4294 RVA: 0x00405B0E File Offset: 0x00403D0E
		private void GoBackClick(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(11, -1, -1, 1, 1f, 0f);
			Main.menuMode = (Main.menuMultiplayer ? 12 : 1);
		}

		// Token: 0x060010C5 RID: 4293 RVA: 0x00405AB8 File Offset: 0x00403CB8
		private void NewWorldClick(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(10, -1, -1, 1, 1f, 0f);
			Main.menuMode = 16;
			Main.newWorldName = Lang.gen[57].Value + " " + (Main.WorldList.Count + 1);
		}

		// Token: 0x060010C9 RID: 4297 RVA: 0x00405B36 File Offset: 0x00403D36
		public override void OnActivate()
		{
			Main.LoadWorlds();
			this.UpdateWorldsList();
			if (PlayerInput.UsingGamepadUI)
			{
				UILinkPointNavigator.ChangePoint(3000 + ((this._worldList.Count == 0) ? 1 : 2));
			}
		}

		// Token: 0x060010C4 RID: 4292 RVA: 0x004057C0 File Offset: 0x004039C0
		public override void OnInitialize()
		{
			UIElement uIElement = new UIElement();
			uIElement.Width.Set(0f, 0.8f);
			uIElement.MaxWidth.Set(650f, 0f);
			uIElement.Top.Set(220f, 0f);
			uIElement.Height.Set(-220f, 1f);
			uIElement.HAlign = 0.5f;
			UIPanel uIPanel = new UIPanel();
			uIPanel.Width.Set(0f, 1f);
			uIPanel.Height.Set(-110f, 1f);
			uIPanel.BackgroundColor = new Color(33, 43, 79) * 0.8f;
			uIElement.Append(uIPanel);
			this._containerPanel = uIPanel;
			this._worldList = new UIList();
			this._worldList.Width.Set(-25f, 1f);
			this._worldList.Height.Set(0f, 1f);
			this._worldList.ListPadding = 5f;
			uIPanel.Append(this._worldList);
			UIScrollbar uIScrollbar = new UIScrollbar();
			uIScrollbar.SetView(100f, 1000f);
			uIScrollbar.Height.Set(0f, 1f);
			uIScrollbar.HAlign = 1f;
			uIPanel.Append(uIScrollbar);
			this._worldList.SetScrollbar(uIScrollbar);
			UITextPanel<LocalizedText> uITextPanel = new UITextPanel<LocalizedText>(Language.GetText("UI.SelectWorld"), 0.8f, true);
			uITextPanel.HAlign = 0.5f;
			uITextPanel.Top.Set(-35f, 0f);
			uITextPanel.SetPadding(15f);
			uITextPanel.BackgroundColor = new Color(73, 94, 171);
			uIElement.Append(uITextPanel);
			UITextPanel<LocalizedText> uITextPanel2 = new UITextPanel<LocalizedText>(Language.GetText("UI.Back"), 0.7f, true);
			uITextPanel2.Width.Set(-10f, 0.5f);
			uITextPanel2.Height.Set(50f, 0f);
			uITextPanel2.VAlign = 1f;
			uITextPanel2.Top.Set(-45f, 0f);
			uITextPanel2.OnMouseOver += new UIElement.MouseEvent(this.FadedMouseOver);
			uITextPanel2.OnMouseOut += new UIElement.MouseEvent(this.FadedMouseOut);
			uITextPanel2.OnClick += new UIElement.MouseEvent(this.GoBackClick);
			uIElement.Append(uITextPanel2);
			this._backPanel = uITextPanel2;
			UITextPanel<LocalizedText> uITextPanel3 = new UITextPanel<LocalizedText>(Language.GetText("UI.New"), 0.7f, true);
			uITextPanel3.CopyStyle(uITextPanel2);
			uITextPanel3.HAlign = 1f;
			uITextPanel3.OnMouseOver += new UIElement.MouseEvent(this.FadedMouseOver);
			uITextPanel3.OnMouseOut += new UIElement.MouseEvent(this.FadedMouseOut);
			uITextPanel3.OnClick += new UIElement.MouseEvent(this.NewWorldClick);
			uIElement.Append(uITextPanel3);
			this._newPanel = uITextPanel3;
			base.Append(uIElement);
		}

		// Token: 0x060010CD RID: 4301 RVA: 0x00405D60 File Offset: 0x00403F60
		private void SetupGamepadPoints(SpriteBatch spriteBatch)
		{
			UILinkPointNavigator.Shortcuts.BackButtonCommand = 2;
			int num = 3000;
			UILinkPointNavigator.SetPosition(num, this._backPanel.GetInnerDimensions().ToRectangle().Center.ToVector2());
			UILinkPointNavigator.SetPosition(num + 1, this._newPanel.GetInnerDimensions().ToRectangle().Center.ToVector2());
			int num2 = num;
			UILinkPoint uILinkPoint = UILinkPointNavigator.Points[num2];
			uILinkPoint.Unlink();
			uILinkPoint.Right = num2 + 1;
			num2 = num + 1;
			uILinkPoint = UILinkPointNavigator.Points[num2];
			uILinkPoint.Unlink();
			uILinkPoint.Left = num2 - 1;
			Rectangle expr_A6 = this._containerPanel.GetClippingRectangle(spriteBatch);
			Vector2 minimum = expr_A6.TopLeft();
			Vector2 maximum = expr_A6.BottomRight();
			List<SnapPoint> snapPoints = this.GetSnapPoints();
			for (int i = 0; i < snapPoints.Count; i++)
			{
				if (!snapPoints[i].Position.Between(minimum, maximum))
				{
					snapPoints.Remove(snapPoints[i]);
					i--;
				}
			}
			SnapPoint[,] array = new SnapPoint[this._worldList.Count, 5];
			IEnumerable<SnapPoint> arg_135_0 = snapPoints;
			foreach (SnapPoint current in arg_135_0.Where((a) => { return a.Name == "Play"; }))
			{
				array[current.ID, 0] = current;
			}
			IEnumerable<SnapPoint> arg_195_0 = snapPoints;
			foreach (SnapPoint current2 in arg_195_0.Where((a) => { return a.Name == "Favorite"; }))
			{
				array[current2.ID, 1] = current2;
			}
			IEnumerable<SnapPoint> arg_1F5_0 = snapPoints;
			foreach (SnapPoint current3 in arg_1F5_0.Where((a) => { return a.Name == "Cloud"; }))
			{
				array[current3.ID, 2] = current3;
			}
			IEnumerable<SnapPoint> arg_255_0 = snapPoints;
			foreach (SnapPoint current4 in arg_255_0.Where((a) => { return a.Name == "Seed"; }))
			{
				array[current4.ID, 3] = current4;
			}
			IEnumerable<SnapPoint> arg_2B5_0 = snapPoints;
			foreach (SnapPoint current5 in arg_2B5_0.Where((a) => { return a.Name == "Delete"; }))
			{
				array[current5.ID, 4] = current5;
			}
			num2 = num + 2;
			int[] array2 = new int[this._worldList.Count];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = -1;
			}
			for (int k = 0; k < 5; k++)
			{
				int num3 = -1;
				for (int l = 0; l < array.GetLength(0); l++)
				{
					if (array[l, k] != null)
					{
						uILinkPoint = UILinkPointNavigator.Points[num2];
						uILinkPoint.Unlink();
						UILinkPointNavigator.SetPosition(num2, array[l, k].Position);
						if (num3 != -1)
						{
							uILinkPoint.Up = num3;
							UILinkPointNavigator.Points[num3].Down = num2;
						}
						if (array2[l] != -1)
						{
							uILinkPoint.Left = array2[l];
							UILinkPointNavigator.Points[array2[l]].Right = num2;
						}
						uILinkPoint.Down = num;
						if (k == 0)
						{
							UILinkPointNavigator.Points[num].Up = (UILinkPointNavigator.Points[num + 1].Up = num2);
						}
						num3 = num2;
						array2[l] = num2;
						UILinkPointNavigator.Shortcuts.FANCYUI_HIGHEST_INDEX = num2;
						num2++;
					}
				}
			}
			if (PlayerInput.UsingGamepadUI && this._worldList.Count == 0 && UILinkPointNavigator.CurrentPoint > 3001)
			{
				UILinkPointNavigator.ChangePoint(3001);
			}
		}

		// Token: 0x060010CC RID: 4300 RVA: 0x00405C40 File Offset: 0x00403E40
		private bool UpdateFavoritesCache()
		{
			List<WorldFileData> list = new List<WorldFileData>(Main.WorldList);
			List<WorldFileData> arg_2B_0 = list;
			Comparison<WorldFileData> arg_2B_1;
			arg_2B_0.Sort((x, y) => {
				if (x.IsFavorite && !y.IsFavorite)
				{
					return -1;
				}
				if (!x.IsFavorite && y.IsFavorite)
				{
					return 1;
				}
				if (x.Name.CompareTo(y.Name) != 0)
				{
					return x.Name.CompareTo(y.Name);
				}
				return x.GetFileName(true).CompareTo(y.GetFileName(true));
			});
			bool flag = false;
			if (!flag && list.Count != this.favoritesCache.Count)
			{
				flag = true;
			}
			if (!flag)
			{
				for (int i = 0; i < this.favoritesCache.Count; i++)
				{
					Tuple<string, bool> tuple = this.favoritesCache[i];
					if (!(list[i].Name == tuple.Item1) || list[i].IsFavorite != tuple.Item2)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				this.favoritesCache.Clear();
				foreach (WorldFileData current in list)
				{
					this.favoritesCache.Add(Tuple.Create<string, bool>(current.Name, current.IsFavorite));
				}
				this.UpdateWorldsList();
			}
			return flag;
		}

		// Token: 0x060010CA RID: 4298 RVA: 0x00405B68 File Offset: 0x00403D68
		private void UpdateWorldsList()
		{
			this._worldList.Clear();
			List<WorldFileData> expr_15 = new List<WorldFileData>(Main.WorldList);
			expr_15.Sort((x, y) => {
				if (x.IsFavorite && !y.IsFavorite)
				{
					return -1;
				}
				if (!x.IsFavorite && y.IsFavorite)
				{
					return 1;
				}
				if (x.Name.CompareTo(y.Name) != 0)
				{
					return x.Name.CompareTo(y.Name);
				}
				return x.GetFileName(true).CompareTo(y.GetFileName(true));
			});
			int num = 0;
			foreach (WorldFileData current in expr_15)
			{
				this._worldList.Add(new UIWorldListItem(current, num++));
			}
		}

		// Token: 0x0400318B RID: 12683
		private List<Tuple<string, bool>> favoritesCache = new List<Tuple<string, bool>>();

		// Token: 0x0400318C RID: 12684
		private bool skipDraw;

		// Token: 0x04003188 RID: 12680
		private UITextPanel<LocalizedText> _backPanel;

		// Token: 0x0400318A RID: 12682
		private UIPanel _containerPanel;

		// Token: 0x04003189 RID: 12681
		private UITextPanel<LocalizedText> _newPanel;

		// Token: 0x04003187 RID: 12679
		private UIList _worldList;

		// Token: 0x020002A6 RID: 678
	}
}

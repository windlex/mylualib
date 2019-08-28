using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameInput;

namespace Terraria.UI
{
	// Token: 0x020000B1 RID: 177
	public class UserInterface
	{
		// Token: 0x06000C42 RID: 3138 RVA: 0x003D8B08 File Offset: 0x003D6D08
		public void ResetLasts()
		{
			this._lastElementHover = null;
			this._lastElementDown = null;
			this._lastElementClicked = null;
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000C43 RID: 3139 RVA: 0x003D8B20 File Offset: 0x003D6D20
		public UIState CurrentState
		{
			get
			{
				return this._currentState;
			}
		}

		// Token: 0x06000C44 RID: 3140 RVA: 0x003D8B28 File Offset: 0x003D6D28
		public UserInterface()
		{
			UserInterface.ActiveInstance = this;
		}

		// Token: 0x06000C45 RID: 3141 RVA: 0x003D8B44 File Offset: 0x003D6D44
		public void Use()
		{
			if (UserInterface.ActiveInstance != this)
			{
				UserInterface.ActiveInstance = this;
				this.Recalculate();
				return;
			}
			UserInterface.ActiveInstance = this;
		}

		// Token: 0x06000C46 RID: 3142 RVA: 0x003D8B64 File Offset: 0x003D6D64
		private void ResetState()
		{
			this.MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			this._wasMouseDown = Main.mouseLeft;
			if (this._lastElementHover != null)
			{
				this._lastElementHover.MouseOut(new UIMouseEvent(this._lastElementHover, this.MousePosition));
			}
			this._lastElementHover = null;
			this._lastElementDown = null;
			this._lastElementClicked = null;
			this._lastMouseDownTime = 0.0;
			this._clickDisabledTimeRemaining = Math.Max(this._clickDisabledTimeRemaining, 200.0);
		}

		// Token: 0x06000C47 RID: 3143 RVA: 0x003D8BF8 File Offset: 0x003D6DF8
		public void Update(GameTime time)
		{
			if (this._currentState != null)
			{
				this.MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
				bool flag = Main.mouseLeft && Main.hasFocus;
				UIElement uIElement = Main.hasFocus ? this._currentState.GetElementAt(this.MousePosition) : null;
				this._clickDisabledTimeRemaining = Math.Max(0.0, this._clickDisabledTimeRemaining - time.ElapsedGameTime.TotalMilliseconds);
				bool flag2 = this._clickDisabledTimeRemaining > 0.0;
				if (uIElement != this._lastElementHover)
				{
					if (this._lastElementHover != null)
					{
						this._lastElementHover.MouseOut(new UIMouseEvent(this._lastElementHover, this.MousePosition));
					}
					if (uIElement != null)
					{
						uIElement.MouseOver(new UIMouseEvent(uIElement, this.MousePosition));
					}
					this._lastElementHover = uIElement;
				}
				if (flag && !this._wasMouseDown && uIElement != null && !flag2)
				{
					this._lastElementDown = uIElement;
					uIElement.MouseDown(new UIMouseEvent(uIElement, this.MousePosition));
					if (this._lastElementClicked == uIElement && time.TotalGameTime.TotalMilliseconds - this._lastMouseDownTime < 500.0)
					{
						uIElement.DoubleClick(new UIMouseEvent(uIElement, this.MousePosition));
						this._lastElementClicked = null;
					}
					this._lastMouseDownTime = time.TotalGameTime.TotalMilliseconds;
				}
				else if (!flag && this._wasMouseDown && this._lastElementDown != null && !flag2)
				{
					UIElement lastElementDown = this._lastElementDown;
					if (lastElementDown.ContainsPoint(this.MousePosition))
					{
						lastElementDown.Click(new UIMouseEvent(lastElementDown, this.MousePosition));
						this._lastElementClicked = this._lastElementDown;
					}
					lastElementDown.MouseUp(new UIMouseEvent(lastElementDown, this.MousePosition));
					this._lastElementDown = null;
				}
				if (PlayerInput.ScrollWheelDeltaForUI != 0)
				{
					if (uIElement != null)
					{
						uIElement.ScrollWheel(new UIScrollWheelEvent(uIElement, this.MousePosition, PlayerInput.ScrollWheelDeltaForUI));
					}
					PlayerInput.ScrollWheelDeltaForUI = 0;
				}
				this._wasMouseDown = flag;
				if (this._currentState != null)
				{
					this._currentState.Update(time);
				}
			}
		}

		// Token: 0x06000C48 RID: 3144 RVA: 0x003D8E04 File Offset: 0x003D7004
		public void Draw(SpriteBatch spriteBatch, GameTime time)
		{
			this.Use();
			if (this._currentState != null)
			{
				this._currentState.Draw(spriteBatch);
			}
		}

		// Token: 0x06000C49 RID: 3145 RVA: 0x003D8E20 File Offset: 0x003D7020
		public void SetState(UIState state)
		{
			if (state != null)
			{
				this.AddToHistory(state);
			}
			if (this._currentState != null)
			{
				this._currentState.Deactivate();
			}
			this._currentState = state;
			this.ResetState();
			if (state != null)
			{
				state.Activate();
				state.Recalculate();
			}
		}

		// Token: 0x06000C4A RID: 3146 RVA: 0x003D8E5C File Offset: 0x003D705C
		public void GoBack()
		{
			if (this._history.Count < 2)
			{
				return;
			}
			UIState state = this._history[this._history.Count - 2];
			this._history.RemoveRange(this._history.Count - 2, 2);
			this.SetState(state);
		}

		// Token: 0x06000C4B RID: 3147 RVA: 0x003D8EB4 File Offset: 0x003D70B4
		private void AddToHistory(UIState state)
		{
			this._history.Add(state);
			if (this._history.Count > 32)
			{
				this._history.RemoveRange(0, 4);
			}
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x003D8EE0 File Offset: 0x003D70E0
		public void Recalculate()
		{
			if (this._currentState != null)
			{
				this._currentState.Recalculate();
			}
		}

		// Token: 0x06000C4D RID: 3149 RVA: 0x003D8EF8 File Offset: 0x003D70F8
		public CalculatedStyle GetDimensions()
		{
			return new CalculatedStyle(0f, 0f, (float)Main.screenWidth, (float)Main.screenHeight);
		}

		// Token: 0x06000C4E RID: 3150 RVA: 0x003D8F18 File Offset: 0x003D7118
		internal void RefreshState()
		{
			if (this._currentState != null)
			{
				this._currentState.Deactivate();
			}
			this.ResetState();
			this._currentState.Activate();
			this._currentState.Recalculate();
		}

		// Token: 0x06000C4F RID: 3151 RVA: 0x003D8F4C File Offset: 0x003D714C
		public bool IsElementUnderMouse()
		{
			return this.IsVisible && this._lastElementHover != null && !(this._lastElementHover is UIState);
		}

		// Token: 0x04000F05 RID: 3845
		private const double DOUBLE_CLICK_TIME = 500.0;

		// Token: 0x04000F06 RID: 3846
		private const double STATE_CHANGE_CLICK_DISABLE_TIME = 200.0;

		// Token: 0x04000F07 RID: 3847
		private const int MAX_HISTORY_SIZE = 32;

		// Token: 0x04000F08 RID: 3848
		private const int HISTORY_PRUNE_SIZE = 4;

		// Token: 0x04000F09 RID: 3849
		public static UserInterface ActiveInstance = new UserInterface();

		// Token: 0x04000F0A RID: 3850
		private List<UIState> _history = new List<UIState>();

		// Token: 0x04000F0B RID: 3851
		public Vector2 MousePosition;

		// Token: 0x04000F0C RID: 3852
		private bool _wasMouseDown;

		// Token: 0x04000F0D RID: 3853
		private UIElement _lastElementHover;

		// Token: 0x04000F0E RID: 3854
		private UIElement _lastElementDown;

		// Token: 0x04000F0F RID: 3855
		private UIElement _lastElementClicked;

		// Token: 0x04000F10 RID: 3856
		private double _lastMouseDownTime;

		// Token: 0x04000F11 RID: 3857
		private double _clickDisabledTimeRemaining;

		// Token: 0x04000F12 RID: 3858
		public bool IsVisible;

		// Token: 0x04000F13 RID: 3859
		private UIState _currentState;
	}
}

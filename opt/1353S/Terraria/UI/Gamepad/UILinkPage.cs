using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Terraria.UI.Gamepad
{
	// Token: 0x020000B9 RID: 185
	public class UILinkPage
	{
		// Token: 0x1400001B RID: 27
		// (add) Token: 0x06000C6E RID: 3182 RVA: 0x003D9FC8 File Offset: 0x003D81C8
		// (remove) Token: 0x06000C6F RID: 3183 RVA: 0x003DA000 File Offset: 0x003D8200
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event Action<int, int> ReachEndEvent;

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x06000C70 RID: 3184 RVA: 0x003DA038 File Offset: 0x003D8238
		// (remove) Token: 0x06000C71 RID: 3185 RVA: 0x003DA070 File Offset: 0x003D8270
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event Action TravelEvent;

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x06000C72 RID: 3186 RVA: 0x003DA0A8 File Offset: 0x003D82A8
		// (remove) Token: 0x06000C73 RID: 3187 RVA: 0x003DA0E0 File Offset: 0x003D82E0
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event Action LeaveEvent;

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x06000C74 RID: 3188 RVA: 0x003DA118 File Offset: 0x003D8318
		// (remove) Token: 0x06000C75 RID: 3189 RVA: 0x003DA150 File Offset: 0x003D8350
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event Action EnterEvent;

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x06000C76 RID: 3190 RVA: 0x003DA188 File Offset: 0x003D8388
		// (remove) Token: 0x06000C77 RID: 3191 RVA: 0x003DA1C0 File Offset: 0x003D83C0
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event Action UpdateEvent;

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x06000C78 RID: 3192 RVA: 0x003DA1F8 File Offset: 0x003D83F8
		// (remove) Token: 0x06000C79 RID: 3193 RVA: 0x003DA230 File Offset: 0x003D8430
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event Func<bool> IsValidEvent;

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x06000C7A RID: 3194 RVA: 0x003DA268 File Offset: 0x003D8468
		// (remove) Token: 0x06000C7B RID: 3195 RVA: 0x003DA2A0 File Offset: 0x003D84A0
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event Func<bool> CanEnterEvent;

		// Token: 0x06000C7C RID: 3196 RVA: 0x003DA2D8 File Offset: 0x003D84D8
		public UILinkPage()
		{
		}

		// Token: 0x06000C7D RID: 3197 RVA: 0x003DA2FC File Offset: 0x003D84FC
		public UILinkPage(int id)
		{
			this.ID = id;
		}

		// Token: 0x06000C7E RID: 3198 RVA: 0x003DA324 File Offset: 0x003D8524
		public void Update()
		{
			if (this.UpdateEvent != null)
			{
				this.UpdateEvent();
			}
		}

		// Token: 0x06000C7F RID: 3199 RVA: 0x003DA33C File Offset: 0x003D853C
		public void Leave()
		{
			if (this.LeaveEvent != null)
			{
				this.LeaveEvent();
			}
		}

		// Token: 0x06000C80 RID: 3200 RVA: 0x003DA354 File Offset: 0x003D8554
		public void Enter()
		{
			if (this.EnterEvent != null)
			{
				this.EnterEvent();
			}
		}

		// Token: 0x06000C81 RID: 3201 RVA: 0x003DA36C File Offset: 0x003D856C
		public bool IsValid()
		{
			return this.IsValidEvent == null || this.IsValidEvent();
		}

		// Token: 0x06000C82 RID: 3202 RVA: 0x003DA384 File Offset: 0x003D8584
		public bool CanEnter()
		{
			return this.CanEnterEvent == null || this.CanEnterEvent();
		}

		// Token: 0x06000C83 RID: 3203 RVA: 0x003DA39C File Offset: 0x003D859C
		public void TravelUp()
		{
			this.Travel(this.LinkMap[this.CurrentPoint].Up);
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x003DA3BC File Offset: 0x003D85BC
		public void TravelDown()
		{
			this.Travel(this.LinkMap[this.CurrentPoint].Down);
		}

		// Token: 0x06000C85 RID: 3205 RVA: 0x003DA3DC File Offset: 0x003D85DC
		public void TravelLeft()
		{
			this.Travel(this.LinkMap[this.CurrentPoint].Left);
		}

		// Token: 0x06000C86 RID: 3206 RVA: 0x003DA3FC File Offset: 0x003D85FC
		public void TravelRight()
		{
			this.Travel(this.LinkMap[this.CurrentPoint].Right);
		}

		// Token: 0x06000C87 RID: 3207 RVA: 0x003DA41C File Offset: 0x003D861C
		public void SwapPageLeft()
		{
			UILinkPointNavigator.ChangePage(this.PageOnLeft);
		}

		// Token: 0x06000C88 RID: 3208 RVA: 0x003DA42C File Offset: 0x003D862C
		public void SwapPageRight()
		{
			UILinkPointNavigator.ChangePage(this.PageOnRight);
		}

		// Token: 0x06000C89 RID: 3209 RVA: 0x003DA43C File Offset: 0x003D863C
		private void Travel(int next)
		{
			if (next < 0)
			{
				if (this.ReachEndEvent != null)
				{
					this.ReachEndEvent(this.CurrentPoint, next);
					if (this.TravelEvent != null)
					{
						this.TravelEvent();
						return;
					}
				}
			}
			else
			{
				UILinkPointNavigator.ChangePoint(next);
				if (this.TravelEvent != null)
				{
					this.TravelEvent();
				}
			}
		}

		// Token: 0x14000022 RID: 34
		// (add) Token: 0x06000C8A RID: 3210 RVA: 0x003DA494 File Offset: 0x003D8694
		// (remove) Token: 0x06000C8B RID: 3211 RVA: 0x003DA4CC File Offset: 0x003D86CC
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event Func<string> OnSpecialInteracts;

		// Token: 0x06000C8C RID: 3212 RVA: 0x003DA504 File Offset: 0x003D8704
		public string SpecialInteractions()
		{
			if (this.OnSpecialInteracts != null)
			{
				return this.OnSpecialInteracts();
			}
			return string.Empty;
		}

		// Token: 0x0400100E RID: 4110
		public int ID;

		// Token: 0x0400100F RID: 4111
		public int PageOnLeft = -1;

		// Token: 0x04001010 RID: 4112
		public int PageOnRight = -1;

		// Token: 0x04001011 RID: 4113
		public int DefaultPoint;

		// Token: 0x04001012 RID: 4114
		public int CurrentPoint;

		// Token: 0x04001013 RID: 4115
		public Dictionary<int, UILinkPoint> LinkMap = new Dictionary<int, UILinkPoint>();
	}
}

using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;

namespace Terraria.UI.Gamepad
{
	// Token: 0x020000BA RID: 186
	public class UILinkPoint
	{
		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000C8D RID: 3213 RVA: 0x003DA520 File Offset: 0x003D8720
		// (set) Token: 0x06000C8E RID: 3214 RVA: 0x003DA528 File Offset: 0x003D8728
		public int Page
		{
			get;
			private set;
		}

		// Token: 0x06000C8F RID: 3215 RVA: 0x003DA534 File Offset: 0x003D8734
		public UILinkPoint(int id, bool enabled, int left, int right, int up, int down)
		{
			this.ID = id;
			this.Enabled = enabled;
			this.Left = left;
			this.Right = right;
			this.Up = up;
			this.Down = down;
		}

		// Token: 0x06000C90 RID: 3216 RVA: 0x003DA56C File Offset: 0x003D876C
		public void SetPage(int page)
		{
			this.Page = page;
		}

		// Token: 0x06000C91 RID: 3217 RVA: 0x003DA578 File Offset: 0x003D8778
		public void Unlink()
		{
			this.Left = -3;
			this.Right = -4;
			this.Up = -1;
			this.Down = -2;
		}

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x06000C92 RID: 3218 RVA: 0x003DA59C File Offset: 0x003D879C
		// (remove) Token: 0x06000C93 RID: 3219 RVA: 0x003DA5D4 File Offset: 0x003D87D4
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event Func<string> OnSpecialInteracts;

		// Token: 0x06000C94 RID: 3220 RVA: 0x003DA60C File Offset: 0x003D880C
		public string SpecialInteractions()
		{
			if (this.OnSpecialInteracts != null)
			{
				return this.OnSpecialInteracts();
			}
			return string.Empty;
		}

		// Token: 0x0400101C RID: 4124
		public int ID;

		// Token: 0x0400101E RID: 4126
		public bool Enabled;

		// Token: 0x0400101F RID: 4127
		public Vector2 Position;

		// Token: 0x04001020 RID: 4128
		public int Left;

		// Token: 0x04001021 RID: 4129
		public int Right;

		// Token: 0x04001022 RID: 4130
		public int Up;

		// Token: 0x04001023 RID: 4131
		public int Down;
	}
}

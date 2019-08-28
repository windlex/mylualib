using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.DataStructures
{
	// Token: 0x02000187 RID: 391
	public class DrawAnimation
	{
		// Token: 0x060012A0 RID: 4768 RVA: 0x00418948 File Offset: 0x00416B48
		public virtual void Update()
		{
		}

		// Token: 0x060012A1 RID: 4769 RVA: 0x0041894C File Offset: 0x00416B4C
		public virtual Rectangle GetFrame(Texture2D texture)
		{
			return texture.Frame(1, 1, 0, 0);
		}

		// Token: 0x0400344B RID: 13387
		public int Frame;

		// Token: 0x0400344C RID: 13388
		public int FrameCount;

		// Token: 0x0400344D RID: 13389
		public int TicksPerFrame;

		// Token: 0x0400344E RID: 13390
		public int FrameCounter;
	}
}

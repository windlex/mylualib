using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.DataStructures
{
	// Token: 0x02000188 RID: 392
	public class DrawAnimationVertical : DrawAnimation
	{
		// Token: 0x060012A3 RID: 4771 RVA: 0x00418960 File Offset: 0x00416B60
		public DrawAnimationVertical(int ticksperframe, int frameCount)
		{
			this.Frame = 0;
			this.FrameCounter = 0;
			this.FrameCount = frameCount;
			this.TicksPerFrame = ticksperframe;
		}

		// Token: 0x060012A4 RID: 4772 RVA: 0x00418984 File Offset: 0x00416B84
		public override void Update()
		{
			int num = this.FrameCounter + 1;
			this.FrameCounter = num;
			if (num >= this.TicksPerFrame)
			{
				this.FrameCounter = 0;
				num = this.Frame + 1;
				this.Frame = num;
				if (num >= this.FrameCount)
				{
					this.Frame = 0;
				}
			}
		}

		// Token: 0x060012A5 RID: 4773 RVA: 0x004189D4 File Offset: 0x00416BD4
		public override Rectangle GetFrame(Texture2D texture)
		{
			return texture.Frame(1, this.FrameCount, 0, this.Frame);
		}
	}
}

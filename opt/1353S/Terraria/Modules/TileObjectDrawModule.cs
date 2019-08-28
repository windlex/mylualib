using System;

namespace Terraria.Modules
{
	// Token: 0x02000042 RID: 66
	public class TileObjectDrawModule
	{
		// Token: 0x060008FA RID: 2298 RVA: 0x003B4CC8 File Offset: 0x003B2EC8
		public TileObjectDrawModule(TileObjectDrawModule copyFrom = null)
		{
			if (copyFrom == null)
			{
				this.yOffset = 0;
				this.flipHorizontal = false;
				this.flipVertical = false;
				this.stepDown = 0;
				return;
			}
			this.yOffset = copyFrom.yOffset;
			this.flipHorizontal = copyFrom.flipHorizontal;
			this.flipVertical = copyFrom.flipVertical;
			this.stepDown = copyFrom.stepDown;
		}

		// Token: 0x04000D69 RID: 3433
		public int yOffset;

		// Token: 0x04000D6A RID: 3434
		public bool flipHorizontal;

		// Token: 0x04000D6B RID: 3435
		public bool flipVertical;

		// Token: 0x04000D6C RID: 3436
		public int stepDown;
	}
}

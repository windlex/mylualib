using System;

namespace Terraria.Modules
{
	// Token: 0x02000045 RID: 69
	public class TileObjectStyleModule
	{
		// Token: 0x060008FD RID: 2301 RVA: 0x003B4E1C File Offset: 0x003B301C
		public TileObjectStyleModule(TileObjectStyleModule copyFrom = null)
		{
			if (copyFrom == null)
			{
				this.style = 0;
				this.horizontal = false;
				this.styleWrapLimit = 0;
				this.styleMultiplier = 1;
				this.styleLineSkip = 1;
				return;
			}
			this.style = copyFrom.style;
			this.horizontal = copyFrom.horizontal;
			this.styleWrapLimit = copyFrom.styleWrapLimit;
			this.styleMultiplier = copyFrom.styleMultiplier;
			this.styleLineSkip = copyFrom.styleLineSkip;
		}

		// Token: 0x04000D72 RID: 3442
		public int style;

		// Token: 0x04000D73 RID: 3443
		public bool horizontal;

		// Token: 0x04000D74 RID: 3444
		public int styleWrapLimit;

		// Token: 0x04000D75 RID: 3445
		public int styleMultiplier;

		// Token: 0x04000D76 RID: 3446
		public int styleLineSkip;
	}
}

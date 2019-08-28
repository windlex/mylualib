using System;
using Terraria.DataStructures;

namespace Terraria.Modules
{
	// Token: 0x0200003C RID: 60
	public class AnchorDataModule
	{
		// Token: 0x060008F4 RID: 2292 RVA: 0x003B49A4 File Offset: 0x003B2BA4
		public AnchorDataModule(AnchorDataModule copyFrom = null)
		{
			if (copyFrom == null)
			{
				this.top = default(AnchorData);
				this.bottom = default(AnchorData);
				this.left = default(AnchorData);
				this.right = default(AnchorData);
				this.wall = false;
				return;
			}
			this.top = copyFrom.top;
			this.bottom = copyFrom.bottom;
			this.left = copyFrom.left;
			this.right = copyFrom.right;
			this.wall = copyFrom.wall;
		}

		// Token: 0x04000D55 RID: 3413
		public AnchorData top;

		// Token: 0x04000D56 RID: 3414
		public AnchorData bottom;

		// Token: 0x04000D57 RID: 3415
		public AnchorData left;

		// Token: 0x04000D58 RID: 3416
		public AnchorData right;

		// Token: 0x04000D59 RID: 3417
		public bool wall;
	}
}

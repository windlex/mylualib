using System;
using Terraria.DataStructures;
using Terraria.Enums;

namespace Terraria.Modules
{
	// Token: 0x0200003F RID: 63
	public class TileObjectBaseModule
	{
		// Token: 0x060008F7 RID: 2295 RVA: 0x003B4BD0 File Offset: 0x003B2DD0
		public TileObjectBaseModule(TileObjectBaseModule copyFrom = null)
		{
			if (copyFrom == null)
			{
				this.width = 1;
				this.height = 1;
				this.origin = Point16.Zero;
				this.direction = TileObjectDirection.None;
				this.randomRange = 0;
				this.flattenAnchors = false;
				return;
			}
			this.width = copyFrom.width;
			this.height = copyFrom.height;
			this.origin = copyFrom.origin;
			this.direction = copyFrom.direction;
			this.randomRange = copyFrom.randomRange;
			this.flattenAnchors = copyFrom.flattenAnchors;
		}

		// Token: 0x04000D5F RID: 3423
		public int width;

		// Token: 0x04000D60 RID: 3424
		public int height;

		// Token: 0x04000D61 RID: 3425
		public Point16 origin;

		// Token: 0x04000D62 RID: 3426
		public TileObjectDirection direction;

		// Token: 0x04000D63 RID: 3427
		public int randomRange;

		// Token: 0x04000D64 RID: 3428
		public bool flattenAnchors;
	}
}

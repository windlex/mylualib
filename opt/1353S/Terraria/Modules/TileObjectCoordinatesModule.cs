using System;
using Terraria.DataStructures;

namespace Terraria.Modules
{
	// Token: 0x02000046 RID: 70
	public class TileObjectCoordinatesModule
	{
		// Token: 0x060008FE RID: 2302 RVA: 0x003B4E94 File Offset: 0x003B3094
		public TileObjectCoordinatesModule(TileObjectCoordinatesModule copyFrom = null, int[] drawHeight = null)
		{
			if (copyFrom == null)
			{
				this.width = 0;
				this.padding = 0;
				this.paddingFix = Point16.Zero;
				this.styleWidth = 0;
				this.styleHeight = 0;
				this.calculated = false;
				this.heights = drawHeight;
				return;
			}
			this.width = copyFrom.width;
			this.padding = copyFrom.padding;
			this.paddingFix = copyFrom.paddingFix;
			this.styleWidth = copyFrom.styleWidth;
			this.styleHeight = copyFrom.styleHeight;
			this.calculated = copyFrom.calculated;
			if (drawHeight != null)
			{
				this.heights = drawHeight;
				return;
			}
			if (copyFrom.heights == null)
			{
				this.heights = null;
				return;
			}
			this.heights = new int[copyFrom.heights.Length];
			Array.Copy(copyFrom.heights, this.heights, this.heights.Length);
		}

		// Token: 0x04000D77 RID: 3447
		public int width;

		// Token: 0x04000D78 RID: 3448
		public int[] heights;

		// Token: 0x04000D79 RID: 3449
		public int padding;

		// Token: 0x04000D7A RID: 3450
		public Point16 paddingFix;

		// Token: 0x04000D7B RID: 3451
		public int styleWidth;

		// Token: 0x04000D7C RID: 3452
		public int styleHeight;

		// Token: 0x04000D7D RID: 3453
		public bool calculated;
	}
}

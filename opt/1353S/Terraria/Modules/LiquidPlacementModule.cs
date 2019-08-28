using System;
using Terraria.Enums;

namespace Terraria.Modules
{
	// Token: 0x02000041 RID: 65
	public class LiquidPlacementModule
	{
		// Token: 0x060008F9 RID: 2297 RVA: 0x003B4C94 File Offset: 0x003B2E94
		public LiquidPlacementModule(LiquidPlacementModule copyFrom = null)
		{
			if (copyFrom == null)
			{
				this.water = LiquidPlacement.Allowed;
				this.lava = LiquidPlacement.Allowed;
				return;
			}
			this.water = copyFrom.water;
			this.lava = copyFrom.lava;
		}

		// Token: 0x04000D67 RID: 3431
		public LiquidPlacement water;

		// Token: 0x04000D68 RID: 3432
		public LiquidPlacement lava;
	}
}

using System;

namespace Terraria.Modules
{
	// Token: 0x02000040 RID: 64
	public class LiquidDeathModule
	{
		// Token: 0x060008F8 RID: 2296 RVA: 0x003B4C60 File Offset: 0x003B2E60
		public LiquidDeathModule(LiquidDeathModule copyFrom = null)
		{
			if (copyFrom == null)
			{
				this.water = false;
				this.lava = false;
				return;
			}
			this.water = copyFrom.water;
			this.lava = copyFrom.lava;
		}

		// Token: 0x04000D65 RID: 3429
		public bool water;

		// Token: 0x04000D66 RID: 3430
		public bool lava;
	}
}

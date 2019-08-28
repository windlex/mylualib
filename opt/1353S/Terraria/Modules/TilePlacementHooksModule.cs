using System;
using Terraria.DataStructures;

namespace Terraria.Modules
{
	// Token: 0x02000044 RID: 68
	public class TilePlacementHooksModule
	{
		// Token: 0x060008FC RID: 2300 RVA: 0x003B4DA4 File Offset: 0x003B2FA4
		public TilePlacementHooksModule(TilePlacementHooksModule copyFrom = null)
		{
			if (copyFrom == null)
			{
				this.check = default(PlacementHook);
				this.postPlaceEveryone = default(PlacementHook);
				this.postPlaceMyPlayer = default(PlacementHook);
				this.placeOverride = default(PlacementHook);
				return;
			}
			this.check = copyFrom.check;
			this.postPlaceEveryone = copyFrom.postPlaceEveryone;
			this.postPlaceMyPlayer = copyFrom.postPlaceMyPlayer;
			this.placeOverride = copyFrom.placeOverride;
		}

		// Token: 0x04000D6E RID: 3438
		public PlacementHook check;

		// Token: 0x04000D6F RID: 3439
		public PlacementHook postPlaceEveryone;

		// Token: 0x04000D70 RID: 3440
		public PlacementHook postPlaceMyPlayer;

		// Token: 0x04000D71 RID: 3441
		public PlacementHook placeOverride;
	}
}

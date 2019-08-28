using System;
using System.Collections.Generic;
using Terraria.ObjectData;

namespace Terraria.Modules
{
	// Token: 0x02000043 RID: 67
	public class TileObjectSubTilesModule
	{
		// Token: 0x060008FB RID: 2299 RVA: 0x003B4D2C File Offset: 0x003B2F2C
		public TileObjectSubTilesModule(TileObjectSubTilesModule copyFrom = null, List<TileObjectData> newData = null)
		{
			if (copyFrom == null)
			{
				this.data = null;
				return;
			}
			if (copyFrom.data == null)
			{
				this.data = null;
				return;
			}
			this.data = new List<TileObjectData>(copyFrom.data.Count);
			for (int i = 0; i < this.data.Count; i++)
			{
				this.data.Add(new TileObjectData(copyFrom.data[i]));
			}
		}

		// Token: 0x04000D6D RID: 3437
		public List<TileObjectData> data;
	}
}

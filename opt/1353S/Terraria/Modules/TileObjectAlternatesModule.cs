using System;
using System.Collections.Generic;
using Terraria.ObjectData;

namespace Terraria.Modules
{
	// Token: 0x0200003E RID: 62
	public class TileObjectAlternatesModule
	{
		// Token: 0x060008F6 RID: 2294 RVA: 0x003B4B58 File Offset: 0x003B2D58
		public TileObjectAlternatesModule(TileObjectAlternatesModule copyFrom = null)
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
			for (int i = 0; i < copyFrom.data.Count; i++)
			{
				this.data.Add(new TileObjectData(copyFrom.data[i]));
			}
		}

		// Token: 0x04000D5E RID: 3422
		public List<TileObjectData> data;
	}
}

using System;

namespace Terraria.World.Generation
{
	// Token: 0x0200004E RID: 78
	public abstract class GenModShape : GenShape
	{
		// Token: 0x0600091B RID: 2331 RVA: 0x003B5234 File Offset: 0x003B3434
		public GenModShape(ShapeData data)
		{
			this._data = data;
		}

		// Token: 0x04000D8A RID: 3466
		protected ShapeData _data;
	}
}

using System;
using Microsoft.Xna.Framework;

namespace Terraria.World.Generation
{
	// Token: 0x02000058 RID: 88
	public abstract class GenShape : GenBase
	{
		// Token: 0x06000930 RID: 2352
		public abstract bool Perform(Point origin, GenAction action);

		// Token: 0x06000931 RID: 2353 RVA: 0x003B53C8 File Offset: 0x003B35C8
		protected bool UnitApply(GenAction action, Point origin, int x, int y, params object[] args)
		{
			if (this._outputData != null)
			{
				this._outputData.Add(x - origin.X, y - origin.Y);
			}
			return action.Apply(origin, x, y, args);
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x003B53FC File Offset: 0x003B35FC
		public GenShape Output(ShapeData outputData)
		{
			this._outputData = outputData;
			return this;
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x003B5408 File Offset: 0x003B3608
		public GenShape QuitOnFail(bool value = true)
		{
			this._quitOnFail = value;
			return this;
		}

		// Token: 0x04000D92 RID: 3474
		private ShapeData _outputData;

		// Token: 0x04000D93 RID: 3475
		protected bool _quitOnFail;
	}
}

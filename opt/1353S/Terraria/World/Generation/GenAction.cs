using System;
using Microsoft.Xna.Framework;

namespace Terraria.World.Generation
{
	// Token: 0x02000047 RID: 71
	public abstract class GenAction : GenBase
	{
		// Token: 0x060008FF RID: 2303
		public abstract bool Apply(Point origin, int x, int y, params object[] args);

		// Token: 0x06000900 RID: 2304 RVA: 0x003B4F70 File Offset: 0x003B3170
		protected bool UnitApply(Point origin, int x, int y, params object[] args)
		{
			if (this.OutputData != null)
			{
				this.OutputData.Add(x - origin.X, y - origin.Y);
			}
			return this.NextAction == null || this.NextAction.Apply(origin, x, y, args);
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x003B4FB0 File Offset: 0x003B31B0
		public GenAction IgnoreFailures()
		{
			this._returnFalseOnFailure = false;
			return this;
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x003B4FBC File Offset: 0x003B31BC
		protected bool Fail()
		{
			return !this._returnFalseOnFailure;
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x003B4FC8 File Offset: 0x003B31C8
		public GenAction Output(ShapeData data)
		{
			this.OutputData = data;
			return this;
		}

		// Token: 0x04000D7E RID: 3454
		public GenAction NextAction;

		// Token: 0x04000D7F RID: 3455
		public ShapeData OutputData;

		// Token: 0x04000D80 RID: 3456
		private bool _returnFalseOnFailure = true;
	}
}

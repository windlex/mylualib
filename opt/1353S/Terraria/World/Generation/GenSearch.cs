using System;
using Microsoft.Xna.Framework;

namespace Terraria.World.Generation
{
	// Token: 0x02000052 RID: 82
	public abstract class GenSearch : GenBase
	{
		// Token: 0x0600091E RID: 2334 RVA: 0x003B525C File Offset: 0x003B345C
		public GenSearch Conditions(params GenCondition[] conditions)
		{
			this._conditions = conditions;
			return this;
		}

		// Token: 0x0600091F RID: 2335
		public abstract Point Find(Point origin);

		// Token: 0x06000920 RID: 2336 RVA: 0x003B5268 File Offset: 0x003B3468
		protected bool Check(int x, int y)
		{
			for (int i = 0; i < this._conditions.Length; i++)
			{
				if (this._requireAll ^ this._conditions[i].IsValid(x, y))
				{
					return !this._requireAll;
				}
			}
			return this._requireAll;
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x003B52B0 File Offset: 0x003B34B0
		public GenSearch RequireAll(bool mode)
		{
			this._requireAll = mode;
			return this;
		}

		// Token: 0x04000D8D RID: 3469
		public static Point NOT_FOUND = new Point(2147483647, 2147483647);

		// Token: 0x04000D8E RID: 3470
		private bool _requireAll = true;

		// Token: 0x04000D8F RID: 3471
		private GenCondition[] _conditions;
	}
}

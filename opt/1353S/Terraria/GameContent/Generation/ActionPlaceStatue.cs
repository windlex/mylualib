using System;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.World.Generation;

namespace Terraria.GameContent.Generation
{
	// Token: 0x02000111 RID: 273
	public class ActionPlaceStatue : GenAction
	{
		// Token: 0x06000F46 RID: 3910 RVA: 0x003F3DA4 File Offset: 0x003F1FA4
		public ActionPlaceStatue(int index = -1)
		{
			this._statueIndex = index;
		}

		// Token: 0x06000F47 RID: 3911 RVA: 0x003F3DB4 File Offset: 0x003F1FB4
		public override bool Apply(Point origin, int x, int y, params object[] args)
		{
			Point16 point;
			if (this._statueIndex == -1)
			{
				point = WorldGen.statueList[GenBase._random.Next(2, WorldGen.statueList.Length)];
			}
			else
			{
				point = WorldGen.statueList[this._statueIndex];
			}
			WorldGen.PlaceTile(x, y, (int)point.X, true, false, -1, (int)point.Y);
			return base.UnitApply(origin, x, y, args);
		}

		// Token: 0x0400304B RID: 12363
		private int _statueIndex;
	}
}

using System;
using Microsoft.Xna.Framework;
using Terraria.World.Generation;

namespace Terraria.GameContent.Generation
{
	// Token: 0x02000112 RID: 274
	public class ActionStalagtite : GenAction
	{
		// Token: 0x06000F48 RID: 3912 RVA: 0x003F3E1C File Offset: 0x003F201C
		public override bool Apply(Point origin, int x, int y, params object[] args)
		{
			WorldGen.PlaceTight(x, y, 165, false);
			return base.UnitApply(origin, x, y, args);
		}
	}
}

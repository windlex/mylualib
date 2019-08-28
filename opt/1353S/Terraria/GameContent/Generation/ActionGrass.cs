﻿using System;
using Microsoft.Xna.Framework;
using Terraria.World.Generation;

namespace Terraria.GameContent.Generation
{
	// Token: 0x02000110 RID: 272
	public class ActionGrass : GenAction
	{
		// Token: 0x06000F44 RID: 3908 RVA: 0x003F3D34 File Offset: 0x003F1F34
		public override bool Apply(Point origin, int x, int y, params object[] args)
		{
			if (GenBase._tiles[x, y].active() || GenBase._tiles[x, y - 1].active())
			{
				return false;
			}
			WorldGen.PlaceTile(x, y, (int)Utils.SelectRandom<ushort>(GenBase._random, new ushort[]
			{
				3,
				73
			}), true, false, -1, 0);
			return base.UnitApply(origin, x, y, args);
		}
	}
}

using System;

namespace Terraria.World.Generation
{
	// Token: 0x02000051 RID: 81
	public static class Passes
	{
		// Token: 0x02000213 RID: 531
		public class Clear : GenPass
		{
			// Token: 0x06001543 RID: 5443 RVA: 0x0042FB64 File Offset: 0x0042DD64
			public Clear() : base("clear", 1f)
			{
			}

			// Token: 0x06001544 RID: 5444 RVA: 0x0042FB78 File Offset: 0x0042DD78
			public override void Apply(GenerationProgress progress)
			{
				for (int i = 0; i < GenBase._worldWidth; i++)
				{
					for (int j = 0; j < GenBase._worldHeight; j++)
					{
						if (GenBase._tiles[i, j] == null)
						{
							GenBase._tiles[i, j] = new Tile();
						}
						else
						{
							GenBase._tiles[i, j].ClearEverything();
						}
					}
				}
			}
		}

		// Token: 0x02000214 RID: 532
		public class ScatterCustom : GenPass
		{
			// Token: 0x06001545 RID: 5445 RVA: 0x0042FBD8 File Offset: 0x0042DDD8
			public ScatterCustom(string name, float loadWeight, int count, GenBase.CustomPerUnitAction perUnit = null) : base(name, loadWeight)
			{
				this._perUnit = perUnit;
				this._count = count;
			}

			// Token: 0x06001546 RID: 5446 RVA: 0x0042FBF4 File Offset: 0x0042DDF4
			public void SetCustomAction(GenBase.CustomPerUnitAction perUnit)
			{
				this._perUnit = perUnit;
			}

			// Token: 0x06001547 RID: 5447 RVA: 0x0042FC00 File Offset: 0x0042DE00
			public override void Apply(GenerationProgress progress)
			{
				int i = this._count;
				while (i > 0)
				{
					if (this._perUnit(GenBase._random.Next(1, GenBase._worldWidth), GenBase._random.Next(1, GenBase._worldHeight), new object[0]))
					{
						i--;
					}
				}
			}

			// Token: 0x04003776 RID: 14198
			private GenBase.CustomPerUnitAction _perUnit;

			// Token: 0x04003777 RID: 14199
			private int _count;
		}
	}
}

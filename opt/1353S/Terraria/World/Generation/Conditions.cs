using System;

namespace Terraria.World.Generation
{
	// Token: 0x0200004B RID: 75
	public static class Conditions
	{
		// Token: 0x020001F8 RID: 504
		public class IsTile : GenCondition
		{
			// Token: 0x06001505 RID: 5381 RVA: 0x0042EE20 File Offset: 0x0042D020
			public IsTile(params ushort[] types)
			{
				this._types = types;
			}

			// Token: 0x06001506 RID: 5382 RVA: 0x0042EE30 File Offset: 0x0042D030
			protected override bool CheckValidity(int x, int y)
			{
				if (GenBase._tiles[x, y].active())
				{
					for (int i = 0; i < this._types.Length; i++)
					{
						if (GenBase._tiles[x, y].type == this._types[i])
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x0400374E RID: 14158
			private ushort[] _types;
		}

		// Token: 0x020001F9 RID: 505
		public class Continue : GenCondition
		{
			// Token: 0x06001507 RID: 5383 RVA: 0x0042EE84 File Offset: 0x0042D084
			protected override bool CheckValidity(int x, int y)
			{
				return false;
			}
		}

		// Token: 0x020001FA RID: 506
		public class IsSolid : GenCondition
		{
			// Token: 0x06001509 RID: 5385 RVA: 0x0042EE90 File Offset: 0x0042D090
			protected override bool CheckValidity(int x, int y)
			{
				return GenBase._tiles[x, y].active() && Main.tileSolid[(int)GenBase._tiles[x, y].type];
			}
		}

		// Token: 0x020001FB RID: 507
		public class HasLava : GenCondition
		{
			// Token: 0x0600150B RID: 5387 RVA: 0x0042EEC8 File Offset: 0x0042D0C8
			protected override bool CheckValidity(int x, int y)
			{
				return GenBase._tiles[x, y].liquid > 0 && GenBase._tiles[x, y].liquidType() == 1;
			}
		}
	}
}

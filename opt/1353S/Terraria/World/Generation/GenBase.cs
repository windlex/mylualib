using System;
using Terraria.Utilities;

namespace Terraria.World.Generation
{
	// Token: 0x02000049 RID: 73
	public class GenBase
	{
		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000907 RID: 2311 RVA: 0x003B501C File Offset: 0x003B321C
		protected static UnifiedRandom _random
		{
			get
			{
				return WorldGen.genRand;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000908 RID: 2312 RVA: 0x003B5024 File Offset: 0x003B3224
		protected static Tile[,] _tiles
		{
			get
			{
				return Main.tile;
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000909 RID: 2313 RVA: 0x003B502C File Offset: 0x003B322C
		protected static int _worldWidth
		{
			get
			{
				return Main.maxTilesX;
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x0600090A RID: 2314 RVA: 0x003B5034 File Offset: 0x003B3234
		protected static int _worldHeight
		{
			get
			{
				return Main.maxTilesY;
			}
		}

		// Token: 0x020001F6 RID: 502
		// (Invoke) Token: 0x06001502 RID: 5378
		public delegate bool CustomPerUnitAction(int x, int y, params object[] args);
	}
}

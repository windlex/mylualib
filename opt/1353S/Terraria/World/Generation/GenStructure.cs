using System;
using Microsoft.Xna.Framework;

namespace Terraria.World.Generation
{
	// Token: 0x02000054 RID: 84
	public abstract class GenStructure : GenBase
	{
		// Token: 0x06000925 RID: 2341
		public abstract bool Place(Point origin, StructureMap structures);
	}
}

using System;
using System.Collections.Generic;

namespace Terraria.World.Generation
{
	// Token: 0x02000057 RID: 87
	public abstract class MicroBiome : GenStructure
	{
		// Token: 0x0600092D RID: 2349 RVA: 0x003B536C File Offset: 0x003B356C
		public MicroBiome()
		{
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x003B5374 File Offset: 0x003B3574
		public virtual void Reset()
		{
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x003B5378 File Offset: 0x003B3578
		public static void ResetAll()
		{
			using (List<MicroBiome>.Enumerator enumerator = BiomeCollection.Biomes.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.Reset();
				}
			}
		}
	}
}

using System;
using Microsoft.Xna.Framework;

namespace Terraria.World.Generation
{
	// Token: 0x02000056 RID: 86
	public static class Biomes<T> where T : MicroBiome, new()
	{
		// Token: 0x06000928 RID: 2344 RVA: 0x003B5304 File Offset: 0x003B3504
		public static bool Place(int x, int y, StructureMap structures)
		{
			return Biomes<T>._microBiome.Place(new Point(x, y), structures);
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x003B5320 File Offset: 0x003B3520
		public static bool Place(Point origin, StructureMap structures)
		{
			return Biomes<T>._microBiome.Place(origin, structures);
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x003B5334 File Offset: 0x003B3534
		public static T Get()
		{
			return Biomes<T>._microBiome;
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x003B533C File Offset: 0x003B353C
		private static T CreateInstance()
		{
			T t = Activator.CreateInstance<T>();
			BiomeCollection.Biomes.Add(t);
			return t;
		}

		// Token: 0x04000D91 RID: 3473
		private static T _microBiome = Biomes<T>.CreateInstance();
	}
}

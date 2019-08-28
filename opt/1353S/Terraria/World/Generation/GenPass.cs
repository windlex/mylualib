using System;

namespace Terraria.World.Generation
{
	// Token: 0x02000050 RID: 80
	public abstract class GenPass : GenBase
	{
		// Token: 0x0600091C RID: 2332 RVA: 0x003B5244 File Offset: 0x003B3444
		public GenPass(string name, float loadWeight)
		{
			this.Name = name;
			this.Weight = loadWeight;
		}

		// Token: 0x0600091D RID: 2333
		public abstract void Apply(GenerationProgress progress);

		// Token: 0x04000D8B RID: 3467
		public string Name;

		// Token: 0x04000D8C RID: 3468
		public float Weight;
	}
}

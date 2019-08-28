using System;
using System.Collections.Generic;
using System.Diagnostics;
using Terraria.GameContent.UI.States;
using Terraria.Utilities;

namespace Terraria.World.Generation
{
	// Token: 0x0200005D RID: 93
	public class WorldGenerator
	{
		// Token: 0x0600094D RID: 2381 RVA: 0x003B59EC File Offset: 0x003B3BEC
		public WorldGenerator(int seed)
		{
			this._seed = seed;
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x003B5A08 File Offset: 0x003B3C08
		public void Append(GenPass pass)
		{
			this._passes.Add(pass);
			this._totalLoadWeight += pass.Weight;
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x003B5A2C File Offset: 0x003B3C2C
		public void GenerateWorld(GenerationProgress progress = null)
		{
			Stopwatch stopwatch = new Stopwatch();
			float num = 0f;
			foreach (GenPass current in this._passes)
			{
				num += current.Weight;
			}
			if (progress == null)
			{
				progress = new GenerationProgress();
			}
			progress.TotalWeight = num;
			Main.menuMode = 888;
			Main.MenuUI.SetState(new UIWorldLoad(progress));
			foreach (GenPass current2 in this._passes)
			{
				WorldGen._genRand = new UnifiedRandom(this._seed);
				Main.rand = new UnifiedRandom(this._seed);
				stopwatch.Start();
				progress.Start(current2.Weight);
				current2.Apply(progress);
				progress.End();
				stopwatch.Reset();
			}
		}

		// Token: 0x04000D9C RID: 3484
		private List<GenPass> _passes = new List<GenPass>();

		// Token: 0x04000D9D RID: 3485
		private float _totalLoadWeight;

		// Token: 0x04000D9E RID: 3486
		private int _seed;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Terraria.Utilities
{
	// Token: 0x02000062 RID: 98
	public class WeightedRandom<T>
	{
		// Token: 0x06000968 RID: 2408 RVA: 0x003B63B0 File Offset: 0x003B45B0
		public WeightedRandom()
		{
			this.random = new UnifiedRandom();
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x003B63D8 File Offset: 0x003B45D8
		public WeightedRandom(int seed)
		{
			this.random = new UnifiedRandom(seed);
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x003B6400 File Offset: 0x003B4600
		public WeightedRandom(UnifiedRandom random)
		{
			this.random = random;
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x003B6424 File Offset: 0x003B4624
		public WeightedRandom(params Tuple<T, double>[] theElements)
		{
			this.random = new UnifiedRandom();
			this.elements = theElements.ToList<Tuple<T, double>>();
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x003B6458 File Offset: 0x003B4658
		public WeightedRandom(int seed, params Tuple<T, double>[] theElements)
		{
			this.random = new UnifiedRandom(seed);
			this.elements = theElements.ToList<Tuple<T, double>>();
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x003B648C File Offset: 0x003B468C
		public WeightedRandom(UnifiedRandom random, params Tuple<T, double>[] theElements)
		{
			this.random = random;
			this.elements = theElements.ToList<Tuple<T, double>>();
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x003B64BC File Offset: 0x003B46BC
		public void Add(T element, double weight = 1.0)
		{
			this.elements.Add(new Tuple<T, double>(element, weight));
			this.needsRefresh = true;
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x003B64D8 File Offset: 0x003B46D8
		public T Get()
		{
			if (this.needsRefresh)
			{
				this.CalculateTotalWeight();
			}
			double num = this.random.NextDouble();
			num *= this._totalWeight;
			foreach (Tuple<T, double> current in this.elements)
			{
				if (num <= current.Item2)
				{
					return current.Item1;
				}
				num -= current.Item2;
			}
			return default(T);
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x003B6570 File Offset: 0x003B4770
		public void CalculateTotalWeight()
		{
			this._totalWeight = 0.0;
			foreach (Tuple<T, double> current in this.elements)
			{
				this._totalWeight += current.Item2;
			}
			this.needsRefresh = false;
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x003B65E8 File Offset: 0x003B47E8
		public void Clear()
		{
			this.elements.Clear();
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x003B65F8 File Offset: 0x003B47F8
		public static implicit operator T(WeightedRandom<T> weightedRandom)
		{
			return weightedRandom.Get();
		}

		// Token: 0x04000DAA RID: 3498
		public readonly List<Tuple<T, double>> elements = new List<Tuple<T, double>>();

		// Token: 0x04000DAB RID: 3499
		public readonly UnifiedRandom random;

		// Token: 0x04000DAC RID: 3500
		public bool needsRefresh = true;

		// Token: 0x04000DAD RID: 3501
		private double _totalWeight;
	}
}

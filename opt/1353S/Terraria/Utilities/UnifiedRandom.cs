using System;

namespace Terraria.Utilities
{
	// Token: 0x02000061 RID: 97
	[Serializable]
	public class UnifiedRandom
	{
		// Token: 0x0600095E RID: 2398 RVA: 0x003B6120 File Offset: 0x003B4320
		public UnifiedRandom() : this(Environment.TickCount)
		{
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x003B6130 File Offset: 0x003B4330
		public UnifiedRandom(int Seed)
		{
			int num = (Seed == -2147483648) ? 2147483647 : Math.Abs(Seed);
			int num2 = 161803398 - num;
			this.SeedArray[55] = num2;
			int num3 = 1;
			for (int i = 1; i < 55; i++)
			{
				int num4 = 21 * i % 55;
				this.SeedArray[num4] = num3;
				num3 = num2 - num3;
				if (num3 < 0)
				{
					num3 += 2147483647;
				}
				num2 = this.SeedArray[num4];
			}
			for (int j = 1; j < 5; j++)
			{
				for (int k = 1; k < 56; k++)
				{
					this.SeedArray[k] -= this.SeedArray[1 + (k + 30) % 55];
					if (this.SeedArray[k] < 0)
					{
						this.SeedArray[k] += 2147483647;
					}
				}
			}
			this.inext = 0;
			this.inextp = 21;
			Seed = 1;
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x003B6230 File Offset: 0x003B4430
		protected virtual double Sample()
		{
			return (double)this.InternalSample() * 4.6566128752457969E-10;
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x003B6244 File Offset: 0x003B4444
		private int InternalSample()
		{
			int num = this.inext;
			int num2 = this.inextp;
			if (++num >= 56)
			{
				num = 1;
			}
			if (++num2 >= 56)
			{
				num2 = 1;
			}
			int num3 = this.SeedArray[num] - this.SeedArray[num2];
			if (num3 == 2147483647)
			{
				num3--;
			}
			if (num3 < 0)
			{
				num3 += 2147483647;
			}
			this.SeedArray[num] = num3;
			this.inext = num;
			this.inextp = num2;
			return num3;
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x003B62B8 File Offset: 0x003B44B8
		public virtual int Next()
		{
			return this.InternalSample();
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x003B62C0 File Offset: 0x003B44C0
		private double GetSampleForLargeRange()
		{
			int num = this.InternalSample();
			if (this.InternalSample() % 2 == 0)
			{
				num = -num;
			}
			return ((double)num + 2147483646.0) / 4294967293.0;
		}

		// Token: 0x06000964 RID: 2404 RVA: 0x003B6300 File Offset: 0x003B4500
		public virtual int Next(int minValue, int maxValue)
		{
			if (minValue > maxValue)
			{
				throw new ArgumentOutOfRangeException("minValue", "minValue must be less than maxValue");
			}
			long num = (long)maxValue - (long)minValue;
			if (num <= 2147483647L)
			{
				return (int)(this.Sample() * (double)num) + minValue;
			}
			return (int)((long)(this.GetSampleForLargeRange() * (double)num) + (long)minValue);
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x003B634C File Offset: 0x003B454C
		public virtual int Next(int maxValue)
		{
			if (maxValue < 0)
			{
				throw new ArgumentOutOfRangeException("maxValue", "maxValue must be positive.");
			}
			return (int)(this.Sample() * (double)maxValue);
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x003B636C File Offset: 0x003B456C
		public virtual double NextDouble()
		{
			return this.Sample();
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x003B6374 File Offset: 0x003B4574
		public virtual void NextBytes(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			for (int i = 0; i < buffer.Length; i++)
			{
				buffer[i] = (byte)(this.InternalSample() % 256);
			}
		}

		// Token: 0x04000DA4 RID: 3492
		private const int MBIG = 2147483647;

		// Token: 0x04000DA5 RID: 3493
		private const int MSEED = 161803398;

		// Token: 0x04000DA6 RID: 3494
		private const int MZ = 0;

		// Token: 0x04000DA7 RID: 3495
		private int inext;

		// Token: 0x04000DA8 RID: 3496
		private int inextp;

		// Token: 0x04000DA9 RID: 3497
		private int[] SeedArray = new int[56];
	}
}

using System;

namespace Terraria.World.Generation
{
	// Token: 0x0200004A RID: 74
	public abstract class GenCondition : GenBase
	{
		// Token: 0x0600090C RID: 2316 RVA: 0x003B5044 File Offset: 0x003B3244
		public bool IsValid(int x, int y)
		{
			switch (this._areaType)
			{
			case GenCondition.AreaType.And:
				for (int i = x; i < x + this._width; i++)
				{
					for (int j = y; j < y + this._height; j++)
					{
						if (!this.CheckValidity(i, j))
						{
							return this.InvertResults;
						}
					}
				}
				return !this.InvertResults;
			case GenCondition.AreaType.Or:
				for (int k = x; k < x + this._width; k++)
				{
					for (int l = y; l < y + this._height; l++)
					{
						if (this.CheckValidity(k, l))
						{
							return !this.InvertResults;
						}
					}
				}
				return this.InvertResults;
			case GenCondition.AreaType.None:
				return this.CheckValidity(x, y) ^ this.InvertResults;
			default:
				return true;
			}
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x003B5108 File Offset: 0x003B3308
		public GenCondition Not()
		{
			this.InvertResults = !this.InvertResults;
			return this;
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x003B511C File Offset: 0x003B331C
		public GenCondition AreaOr(int width, int height)
		{
			this._areaType = GenCondition.AreaType.Or;
			this._width = width;
			this._height = height;
			return this;
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x003B5134 File Offset: 0x003B3334
		public GenCondition AreaAnd(int width, int height)
		{
			this._areaType = GenCondition.AreaType.And;
			this._width = width;
			this._height = height;
			return this;
		}

		// Token: 0x06000910 RID: 2320
		protected abstract bool CheckValidity(int x, int y);

		// Token: 0x04000D81 RID: 3457
		private bool InvertResults;

		// Token: 0x04000D82 RID: 3458
		private int _width;

		// Token: 0x04000D83 RID: 3459
		private int _height;

		// Token: 0x04000D84 RID: 3460
		private GenCondition.AreaType _areaType = GenCondition.AreaType.None;

		// Token: 0x020001F7 RID: 503
		private enum AreaType
		{
			// Token: 0x0400374B RID: 14155
			And,
			// Token: 0x0400374C RID: 14156
			Or,
			// Token: 0x0400374D RID: 14157
			None
		}
	}
}

using System;

namespace Terraria.UI
{
	// Token: 0x020000A8 RID: 168
	public struct StyleDimension
	{
		// Token: 0x06000BFD RID: 3069 RVA: 0x003D7A54 File Offset: 0x003D5C54
		public StyleDimension(float pixels, float precent)
		{
			this.Pixels = pixels;
			this.Precent = precent;
		}

		// Token: 0x06000BFE RID: 3070 RVA: 0x003D7A64 File Offset: 0x003D5C64
		public void Set(float pixels, float precent)
		{
			this.Pixels = pixels;
			this.Precent = precent;
		}

		// Token: 0x06000BFF RID: 3071 RVA: 0x003D7A74 File Offset: 0x003D5C74
		public float GetValue(float containerSize)
		{
			return this.Pixels + this.Precent * containerSize;
		}

		// Token: 0x04000EC9 RID: 3785
		public static StyleDimension Fill = new StyleDimension(0f, 1f);

		// Token: 0x04000ECA RID: 3786
		public static StyleDimension Empty = new StyleDimension(0f, 0f);

		// Token: 0x04000ECB RID: 3787
		public float Pixels;

		// Token: 0x04000ECC RID: 3788
		public float Precent;
	}
}

using System;
using Microsoft.Xna.Framework;

namespace Terraria.UI
{
	// Token: 0x020000A9 RID: 169
	public struct CalculatedStyle
	{
		// Token: 0x06000C01 RID: 3073 RVA: 0x003D7AB4 File Offset: 0x003D5CB4
		public CalculatedStyle(float x, float y, float width, float height)
		{
			this.X = x;
			this.Y = y;
			this.Width = width;
			this.Height = height;
		}

		// Token: 0x06000C02 RID: 3074 RVA: 0x003D7AD4 File Offset: 0x003D5CD4
		public Rectangle ToRectangle()
		{
			return new Rectangle((int)this.X, (int)this.Y, (int)this.Width, (int)this.Height);
		}

		// Token: 0x06000C03 RID: 3075 RVA: 0x003D7AF8 File Offset: 0x003D5CF8
		public Vector2 Position()
		{
			return new Vector2(this.X, this.Y);
		}

		// Token: 0x06000C04 RID: 3076 RVA: 0x003D7B0C File Offset: 0x003D5D0C
		public Vector2 Center()
		{
			return new Vector2(this.X + this.Width * 0.5f, this.Y + this.Height * 0.5f);
		}

		// Token: 0x04000ECD RID: 3789
		public float X;

		// Token: 0x04000ECE RID: 3790
		public float Y;

		// Token: 0x04000ECF RID: 3791
		public float Width;

		// Token: 0x04000ED0 RID: 3792
		public float Height;
	}
}

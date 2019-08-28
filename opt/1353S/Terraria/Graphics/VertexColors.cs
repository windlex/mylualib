using System;
using Microsoft.Xna.Framework;

namespace Terraria.Graphics
{
	// Token: 0x020000E4 RID: 228
	public struct VertexColors
	{
		// Token: 0x06000D56 RID: 3414 RVA: 0x003E34E8 File Offset: 0x003E16E8
		public VertexColors(Color color)
		{
			this.TopLeftColor = color;
			this.TopRightColor = color;
			this.BottomRightColor = color;
			this.BottomLeftColor = color;
		}

		// Token: 0x06000D57 RID: 3415 RVA: 0x003E3508 File Offset: 0x003E1708
		public VertexColors(Color topLeft, Color topRight, Color bottomRight, Color bottomLeft)
		{
			this.TopLeftColor = topLeft;
			this.TopRightColor = topRight;
			this.BottomLeftColor = bottomLeft;
			this.BottomRightColor = bottomRight;
		}

		// Token: 0x04002F01 RID: 12033
		public Color TopLeftColor;

		// Token: 0x04002F02 RID: 12034
		public Color TopRightColor;

		// Token: 0x04002F03 RID: 12035
		public Color BottomLeftColor;

		// Token: 0x04002F04 RID: 12036
		public Color BottomRightColor;
	}
}

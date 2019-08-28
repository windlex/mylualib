using System;
using Microsoft.Xna.Framework;

namespace Terraria.DataStructures
{
	// Token: 0x0200018A RID: 394
	public struct DrillDebugDraw
	{
		// Token: 0x060012AF RID: 4783 RVA: 0x00418DA0 File Offset: 0x00416FA0
		public DrillDebugDraw(Vector2 p, Color c)
		{
			this.point = p;
			this.color = c;
		}

		// Token: 0x0400345C RID: 13404
		public Vector2 point;

		// Token: 0x0400345D RID: 13405
		public Color color;
	}
}

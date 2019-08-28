using System;

namespace Terraria
{
	// Token: 0x02000014 RID: 20
	public class LiquidBuffer
	{
		// Token: 0x060000C1 RID: 193 RVA: 0x00015658 File Offset: 0x00013858
		public static void AddBuffer(int x, int y)
		{
			if (LiquidBuffer.numLiquidBuffer == 9999)
			{
				return;
			}
			if (Main.tile[x, y].checkingLiquid())
			{
				return;
			}
			Main.tile[x, y].checkingLiquid(true);
			Main.liquidBuffer[LiquidBuffer.numLiquidBuffer].x = x;
			Main.liquidBuffer[LiquidBuffer.numLiquidBuffer].y = y;
			LiquidBuffer.numLiquidBuffer++;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x000156C8 File Offset: 0x000138C8
		public static void DelBuffer(int l)
		{
			LiquidBuffer.numLiquidBuffer--;
			Main.liquidBuffer[l].x = Main.liquidBuffer[LiquidBuffer.numLiquidBuffer].x;
			Main.liquidBuffer[l].y = Main.liquidBuffer[LiquidBuffer.numLiquidBuffer].y;
		}

		// Token: 0x040000B7 RID: 183
		public const int maxLiquidBuffer = 10000;

		// Token: 0x040000B8 RID: 184
		public static int numLiquidBuffer;

		// Token: 0x040000B9 RID: 185
		public int x;

		// Token: 0x040000BA RID: 186
		public int y;
	}
}

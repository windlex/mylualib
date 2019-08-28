using System;

namespace Terraria.Graphics.Capture
{
	// Token: 0x020000E5 RID: 229
	public class CaptureBiome
	{
		// Token: 0x06000D58 RID: 3416 RVA: 0x003E3528 File Offset: 0x003E1728
		public CaptureBiome(int backgroundIndex, int backgroundIndex2, int waterStyle, CaptureBiome.TileColorStyle tileColorStyle = CaptureBiome.TileColorStyle.Normal)
		{
			this.BackgroundIndex = backgroundIndex;
			this.BackgroundIndex2 = backgroundIndex2;
			this.WaterStyle = waterStyle;
			this.TileColor = tileColorStyle;
		}

		// Token: 0x06000D59 RID: 3417 RVA: 0x003E3550 File Offset: 0x003E1750
		static CaptureBiome()
		{
			// Note: this type is marked as 'beforefieldinit'.
			CaptureBiome[] expr_07 = new CaptureBiome[12];
			expr_07[0] = new CaptureBiome(0, 0, 0, CaptureBiome.TileColorStyle.Normal);
			expr_07[2] = new CaptureBiome(1, 2, 2, CaptureBiome.TileColorStyle.Corrupt);
			expr_07[3] = new CaptureBiome(3, 0, 3, CaptureBiome.TileColorStyle.Jungle);
			expr_07[4] = new CaptureBiome(6, 2, 4, CaptureBiome.TileColorStyle.Normal);
			expr_07[5] = new CaptureBiome(7, 4, 5, CaptureBiome.TileColorStyle.Normal);
			expr_07[6] = new CaptureBiome(2, 1, 6, CaptureBiome.TileColorStyle.Normal);
			expr_07[7] = new CaptureBiome(9, 6, 7, CaptureBiome.TileColorStyle.Mushroom);
			expr_07[8] = new CaptureBiome(0, 0, 8, CaptureBiome.TileColorStyle.Normal);
			expr_07[10] = new CaptureBiome(8, 5, 10, CaptureBiome.TileColorStyle.Crimson);
			CaptureBiome.Biomes = expr_07;
		}

		// Token: 0x04002F05 RID: 12037
		public static CaptureBiome[] Biomes;

		// Token: 0x04002F06 RID: 12038
		public readonly int WaterStyle;

		// Token: 0x04002F07 RID: 12039
		public readonly int BackgroundIndex;

		// Token: 0x04002F08 RID: 12040
		public readonly int BackgroundIndex2;

		// Token: 0x04002F09 RID: 12041
		public readonly CaptureBiome.TileColorStyle TileColor;

		// Token: 0x0200027B RID: 635
		public enum TileColorStyle
		{
			// Token: 0x04003C4A RID: 15434
			Normal,
			// Token: 0x04003C4B RID: 15435
			Jungle,
			// Token: 0x04003C4C RID: 15436
			Crimson,
			// Token: 0x04003C4D RID: 15437
			Corrupt,
			// Token: 0x04003C4E RID: 15438
			Mushroom
		}
	}
}

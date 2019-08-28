using System;
using Microsoft.Xna.Framework;

namespace Terraria.Graphics.Capture
{
	// Token: 0x020000E9 RID: 233
	public class CaptureSettings
	{
		// Token: 0x06000D87 RID: 3463 RVA: 0x003E53FC File Offset: 0x003E35FC
		public CaptureSettings()
		{
			DateTime dateTime = DateTime.Now.ToLocalTime();
			this.OutputName = string.Concat(new string[]
			{
				"Capture ",
				dateTime.Year.ToString("D4"),
				"-",
				dateTime.Month.ToString("D2"),
				"-",
				dateTime.Day.ToString("D2"),
				" ",
				dateTime.Hour.ToString("D2"),
				"_",
				dateTime.Minute.ToString("D2"),
				"_",
				dateTime.Second.ToString("D2")
			});
		}

		// Token: 0x04002F32 RID: 12082
		public Rectangle Area;

		// Token: 0x04002F33 RID: 12083
		public bool UseScaling = true;

		// Token: 0x04002F34 RID: 12084
		public string OutputName;

		// Token: 0x04002F35 RID: 12085
		public bool CaptureEntities = true;

		// Token: 0x04002F36 RID: 12086
		public CaptureBiome Biome = CaptureBiome.Biomes[0];

		// Token: 0x04002F37 RID: 12087
		public bool CaptureMech;

		// Token: 0x04002F38 RID: 12088
		public bool CaptureBackground;
	}
}

using System;
using Microsoft.Xna.Framework;

namespace Terraria.DataStructures
{
	// Token: 0x02000185 RID: 389
	public class ColorSlidersSet
	{
		// Token: 0x06001291 RID: 4753 RVA: 0x00418364 File Offset: 0x00416564
		public void SetHSL(Color color)
		{
			Vector3 vector = Main.rgbToHsl(color);
			this.Hue = vector.X;
			this.Saturation = vector.Y;
			this.Luminance = vector.Z;
		}

		// Token: 0x06001292 RID: 4754 RVA: 0x0041839C File Offset: 0x0041659C
		public void SetHSL(Vector3 vector)
		{
			this.Hue = vector.X;
			this.Saturation = vector.Y;
			this.Luminance = vector.Z;
		}

		// Token: 0x06001293 RID: 4755 RVA: 0x004183C4 File Offset: 0x004165C4
		public Color GetColor()
		{
			Color result = Main.hslToRgb(this.Hue, this.Saturation, this.Luminance);
			result.A = (byte)(this.Alpha * 255f);
			return result;
		}

		// Token: 0x06001294 RID: 4756 RVA: 0x00418400 File Offset: 0x00416600
		public Vector3 GetHSLVector()
		{
			return new Vector3(this.Hue, this.Saturation, this.Luminance);
		}

		// Token: 0x06001295 RID: 4757 RVA: 0x0041841C File Offset: 0x0041661C
		public void ApplyToMainLegacyBars()
		{
			Main.hBar = this.Hue;
			Main.sBar = this.Saturation;
			Main.lBar = this.Luminance;
			Main.aBar = this.Alpha;
		}

		// Token: 0x0400343F RID: 13375
		public float Hue;

		// Token: 0x04003440 RID: 13376
		public float Saturation;

		// Token: 0x04003441 RID: 13377
		public float Luminance;

		// Token: 0x04003442 RID: 13378
		public float Alpha = 1f;
	}
}

using System;
using Terraria.Graphics.Shaders;

namespace Terraria.GameContent.Shaders
{
	// Token: 0x0200016E RID: 366
	public class BloodMoonScreenShaderData : ScreenShaderData
	{
		// Token: 0x06001209 RID: 4617 RVA: 0x00412BB4 File Offset: 0x00410DB4
		public BloodMoonScreenShaderData(string passName) : base(passName)
		{
		}

		// Token: 0x0600120A RID: 4618 RVA: 0x00412BC0 File Offset: 0x00410DC0
		public override void Apply()
		{
			float num = 1f - Utils.SmoothStep((float)Main.worldSurface + 50f, (float)Main.rockLayer + 100f, (Main.screenPosition.Y + (float)(Main.screenHeight / 2)) / 16f);
			base.UseOpacity(num * 0.75f);
			base.Apply();
		}
	}
}

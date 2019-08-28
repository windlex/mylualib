using System;
using Terraria.Graphics.Shaders;

namespace Terraria.GameContent.Shaders
{
	// Token: 0x0200016F RID: 367
	public class MoonLordScreenShaderData : ScreenShaderData
	{
		// Token: 0x0600120B RID: 4619 RVA: 0x00412C20 File Offset: 0x00410E20
		public MoonLordScreenShaderData(string passName) : base(passName)
		{
		}

		// Token: 0x0600120C RID: 4620 RVA: 0x00412C30 File Offset: 0x00410E30
		private void UpdateMoonLordIndex()
		{
			if (this._moonLordIndex >= 0 && Main.npc[this._moonLordIndex].active && Main.npc[this._moonLordIndex].type == 398)
			{
				return;
			}
			int moonLordIndex = -1;
			for (int i = 0; i < Main.npc.Length; i++)
			{
				if (Main.npc[i].active && Main.npc[i].type == 398)
				{
					moonLordIndex = i;
					break;
				}
			}
			this._moonLordIndex = moonLordIndex;
		}

		// Token: 0x0600120D RID: 4621 RVA: 0x00412CB4 File Offset: 0x00410EB4
		public override void Apply()
		{
			this.UpdateMoonLordIndex();
			if (this._moonLordIndex != -1)
			{
				base.UseTargetPosition(Main.npc[this._moonLordIndex].Center);
			}
			base.Apply();
		}

		// Token: 0x04003273 RID: 12915
		private int _moonLordIndex = -1;
	}
}

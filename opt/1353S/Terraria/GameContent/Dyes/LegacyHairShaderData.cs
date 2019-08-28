using System;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Shaders;

namespace Terraria.GameContent.Dyes
{
	// Token: 0x0200011B RID: 283
	public class LegacyHairShaderData : HairShaderData
	{
		// Token: 0x06000F6C RID: 3948 RVA: 0x003F4F40 File Offset: 0x003F3140
		public LegacyHairShaderData() : base(null, null)
		{
			this._shaderDisabled = true;
		}

		// Token: 0x06000F6D RID: 3949 RVA: 0x003F4F54 File Offset: 0x003F3154
		public override Color GetColor(Player player, Color lightColor)
		{
			bool flag = true;
			Color result = this._colorProcessor(player, player.hairColor, ref flag);
			if (flag)
			{
				return new Color(result.ToVector4() * lightColor.ToVector4());
			}
			return result;
		}

		// Token: 0x06000F6E RID: 3950 RVA: 0x003F4F98 File Offset: 0x003F3198
		public LegacyHairShaderData UseLegacyMethod(LegacyHairShaderData.ColorProcessingMethod colorProcessor)
		{
			this._colorProcessor = colorProcessor;
			return this;
		}

		// Token: 0x04003062 RID: 12386
		private LegacyHairShaderData.ColorProcessingMethod _colorProcessor;

		// Token: 0x0200028B RID: 651
		// (Invoke) Token: 0x060016AD RID: 5805
		public delegate Color ColorProcessingMethod(Player player, Color color, ref bool lighting);
	}
}

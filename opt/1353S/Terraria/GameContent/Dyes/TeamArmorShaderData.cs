using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;

namespace Terraria.GameContent.Dyes
{
	// Token: 0x0200011C RID: 284
	public class TeamArmorShaderData : ArmorShaderData
	{
		// Token: 0x06000F6F RID: 3951 RVA: 0x003F4FA4 File Offset: 0x003F31A4
		public TeamArmorShaderData(Ref<Effect> shader, string passName) : base(shader, passName)
		{
			if (!TeamArmorShaderData.isInitialized)
			{
				TeamArmorShaderData.isInitialized = true;
				TeamArmorShaderData.dustShaderData = new ArmorShaderData[Main.teamColor.Length];
				for (int i = 1; i < Main.teamColor.Length; i++)
				{
					TeamArmorShaderData.dustShaderData[i] = new ArmorShaderData(shader, passName).UseColor(Main.teamColor[i]);
				}
				TeamArmorShaderData.dustShaderData[0] = new ArmorShaderData(shader, "Default");
			}
		}

		// Token: 0x06000F70 RID: 3952 RVA: 0x003F501C File Offset: 0x003F321C
		public override void Apply(Entity entity, DrawData? drawData)
		{
			Player player = entity as Player;
			if (player == null || player.team == 0)
			{
				TeamArmorShaderData.dustShaderData[0].Apply(player, drawData);
				return;
			}
			base.UseColor(Main.teamColor[player.team]);
			base.Apply(player, drawData);
		}

		// Token: 0x06000F71 RID: 3953 RVA: 0x003F506C File Offset: 0x003F326C
		public override ArmorShaderData GetSecondaryShader(Entity entity)
		{
			Player player = entity as Player;
			return TeamArmorShaderData.dustShaderData[player.team];
		}

		// Token: 0x04003063 RID: 12387
		private static bool isInitialized;

		// Token: 0x04003064 RID: 12388
		private static ArmorShaderData[] dustShaderData;
	}
}

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.GameContent.Events
{
	// Token: 0x02000176 RID: 374
	public class ScreenDarkness
	{
		// Token: 0x06001270 RID: 4720 RVA: 0x00417964 File Offset: 0x00415B64
		public static void Update()
		{
			float value = 0f;
			float amount = 0.1f;
			Vector2 mountedCenter = Main.player[Main.myPlayer].MountedCenter;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && Main.npc[i].type == 370 && Main.npc[i].Distance(mountedCenter) < 3000f && (Main.npc[i].ai[0] >= 10f || (Main.npc[i].ai[0] == 9f && Main.npc[i].ai[2] > 120f)))
				{
					value = 0.95f;
					amount = 0.03f;
				}
			}
			ScreenDarkness.screenObstruction = MathHelper.Lerp(ScreenDarkness.screenObstruction, value, amount);
		}

		// Token: 0x06001271 RID: 4721 RVA: 0x00417A38 File Offset: 0x00415C38
		public static void DrawBack(SpriteBatch spriteBatch)
		{
			if (ScreenDarkness.screenObstruction == 0f)
			{
				return;
			}
			Color color = Color.Black * ScreenDarkness.screenObstruction;
			spriteBatch.Draw(Main.magicPixel, new Rectangle(-2, -2, Main.screenWidth + 4, Main.screenHeight + 4), new Rectangle?(new Rectangle(0, 0, 1, 1)), color);
		}

		// Token: 0x06001272 RID: 4722 RVA: 0x00417A94 File Offset: 0x00415C94
		public static void DrawFront(SpriteBatch spriteBatch)
		{
			if (ScreenDarkness.screenObstruction == 0f)
			{
				return;
			}
			Color color = new Color(0, 0, 120) * ScreenDarkness.screenObstruction * 0.3f;
			spriteBatch.Draw(Main.magicPixel, new Rectangle(-2, -2, Main.screenWidth + 4, Main.screenHeight + 4), new Rectangle?(new Rectangle(0, 0, 1, 1)), color);
		}

		// Token: 0x04003298 RID: 12952
		public static float screenObstruction;
	}
}

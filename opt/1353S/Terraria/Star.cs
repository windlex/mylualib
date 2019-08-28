using System;
using Microsoft.Xna.Framework;

namespace Terraria
{
	// Token: 0x02000020 RID: 32
	public class Star
	{
		// Token: 0x0600017F RID: 383 RVA: 0x0002D9B8 File Offset: 0x0002BBB8
		public static void SpawnStars()
		{
			Main.numStars = Main.rand.Next(65, 130);
			Main.numStars = 130;
			for (int i = 0; i < Main.numStars; i++)
			{
				Main.star[i] = new Star();
				Main.star[i].position.X = (float)Main.rand.Next(-12, Main.screenWidth + 1);
				Main.star[i].position.Y = (float)Main.rand.Next(-12, Main.screenHeight);
				Main.star[i].rotation = (float)Main.rand.Next(628) * 0.01f;
				Main.star[i].scale = (float)Main.rand.Next(50, 120) * 0.01f;
				Main.star[i].type = Main.rand.Next(0, 5);
				Main.star[i].twinkle = (float)Main.rand.Next(101) * 0.01f;
				Main.star[i].twinkleSpeed = (float)Main.rand.Next(40, 100) * 0.0001f;
				if (Main.rand.Next(2) == 0)
				{
					Main.star[i].twinkleSpeed *= -1f;
				}
				Main.star[i].rotationSpeed = (float)Main.rand.Next(10, 40) * 0.0001f;
				if (Main.rand.Next(2) == 0)
				{
					Main.star[i].rotationSpeed *= -1f;
				}
			}
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0002DB58 File Offset: 0x0002BD58
		public static void UpdateStars()
		{
			for (int i = 0; i < Main.numStars; i++)
			{
				Main.star[i].twinkle += Main.star[i].twinkleSpeed;
				if (Main.star[i].twinkle > 1f)
				{
					Main.star[i].twinkle = 1f;
					Main.star[i].twinkleSpeed *= -1f;
				}
				else if ((double)Main.star[i].twinkle < 0.5)
				{
					Main.star[i].twinkle = 0.5f;
					Main.star[i].twinkleSpeed *= -1f;
				}
				Main.star[i].rotation += Main.star[i].rotationSpeed;
				if ((double)Main.star[i].rotation > 6.28)
				{
					Main.star[i].rotation -= 6.28f;
				}
				if (Main.star[i].rotation < 0f)
				{
					Main.star[i].rotation += 6.28f;
				}
			}
		}

		// Token: 0x04000199 RID: 409
		public Vector2 position;

		// Token: 0x0400019A RID: 410
		public float scale;

		// Token: 0x0400019B RID: 411
		public float rotation;

		// Token: 0x0400019C RID: 412
		public int type;

		// Token: 0x0400019D RID: 413
		public float twinkle;

		// Token: 0x0400019E RID: 414
		public float twinkleSpeed;

		// Token: 0x0400019F RID: 415
		public float rotationSpeed;
	}
}

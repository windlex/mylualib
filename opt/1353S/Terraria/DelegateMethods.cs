using System;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;

namespace Terraria
{
	// Token: 0x02000022 RID: 34
	public static class DelegateMethods
	{
		// Token: 0x06000194 RID: 404 RVA: 0x0002E12C File Offset: 0x0002C32C
		public static Color ColorLerp_BlackToWhite(float percent)
		{
			return Color.Lerp(Color.Black, Color.White, percent);
		}

		// Token: 0x06000195 RID: 405 RVA: 0x0002E140 File Offset: 0x0002C340
		public static Color ColorLerp_HSL_H(float percent)
		{
			return Main.hslToRgb(percent, 1f, 0.5f);
		}

		// Token: 0x06000196 RID: 406 RVA: 0x0002E154 File Offset: 0x0002C354
		public static Color ColorLerp_HSL_S(float percent)
		{
			return Main.hslToRgb(DelegateMethods.v3_1.X, percent, DelegateMethods.v3_1.Z);
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0002E170 File Offset: 0x0002C370
		public static Color ColorLerp_HSL_L(float percent)
		{
			return Main.hslToRgb(DelegateMethods.v3_1.X, DelegateMethods.v3_1.Y, 0.15f + 0.85f * percent);
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0002E198 File Offset: 0x0002C398
		public static Color ColorLerp_HSL_O(float percent)
		{
			return Color.Lerp(Color.White, Main.hslToRgb(DelegateMethods.v3_1.X, DelegateMethods.v3_1.Y, DelegateMethods.v3_1.Z), percent);
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0002E1C8 File Offset: 0x0002C3C8
		public static bool TestDust(int x, int y)
		{
			if (x < 0 || x >= Main.maxTilesX || y < 0 || y >= Main.maxTilesY)
			{
				return false;
			}
			int num = Dust.NewDust(new Vector2((float)x, (float)y) * 16f + new Vector2(8f), 0, 0, 6, 0f, 0f, 0, default(Color), 1f);
			Main.dust[num].noGravity = true;
			Main.dust[num].noLight = true;
			return true;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0002E250 File Offset: 0x0002C450
		public static bool CastLight(int x, int y)
		{
			if (x < 0 || x >= Main.maxTilesX || y < 0 || y >= Main.maxTilesY)
			{
				return false;
			}
			if (Main.tile[x, y] == null)
			{
				return false;
			}
			Lighting.AddLight(x, y, DelegateMethods.v3_1.X, DelegateMethods.v3_1.Y, DelegateMethods.v3_1.Z);
			return true;
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0002E2B0 File Offset: 0x0002C4B0
		public static bool CastLightOpen(int x, int y)
		{
			if (x < 0 || x >= Main.maxTilesX || y < 0 || y >= Main.maxTilesY)
			{
				return false;
			}
			if (Main.tile[x, y] == null)
			{
				return false;
			}
			if (!Main.tile[x, y].active() || Main.tile[x, y].inActive() || Main.tileSolidTop[(int)Main.tile[x, y].type] || !Main.tileSolid[(int)Main.tile[x, y].type])
			{
				Lighting.AddLight(x, y, DelegateMethods.v3_1.X, DelegateMethods.v3_1.Y, DelegateMethods.v3_1.Z);
			}
			return true;
		}

		// Token: 0x0600019C RID: 412 RVA: 0x0002E368 File Offset: 0x0002C568
		public static bool NotDoorStand(int x, int y)
		{
			return Main.tile[x, y] == null || !Main.tile[x, y].active() || Main.tile[x, y].type != 11 || (Main.tile[x, y].frameX >= 18 && Main.tile[x, y].frameX < 54);
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0002E3DC File Offset: 0x0002C5DC
		public static bool CutTiles(int x, int y)
		{
			if (!WorldGen.InWorld(x, y, 1))
			{
				return false;
			}
			if (Main.tile[x, y] == null)
			{
				return false;
			}
			if (!Main.tileCut[(int)Main.tile[x, y].type])
			{
				return true;
			}
			if (WorldGen.CanCutTile(x, y, DelegateMethods.tilecut_0))
			{
				WorldGen.KillTile(x, y, false, false, false);
				if (Main.netMode != 0)
				{
					NetMessage.SendData(17, -1, -1, null, 0, (float)x, (float)y, 0f, 0, 0, 0);
				}
			}
			return true;
		}

		// Token: 0x0600019E RID: 414 RVA: 0x0002E458 File Offset: 0x0002C658
		public static bool SearchAvoidedByNPCs(int x, int y)
		{
			return WorldGen.InWorld(x, y, 1) && Main.tile[x, y] != null && (!Main.tile[x, y].active() || !TileID.Sets.AvoidedByNPCs[(int)Main.tile[x, y].type]);
		}

		// Token: 0x0600019F RID: 415 RVA: 0x0002E4B0 File Offset: 0x0002C6B0
		public static void RainbowLaserDraw(int stage, Vector2 currentPosition, float distanceLeft, Rectangle lastFrame, out float distCovered, out Rectangle frame, out Vector2 origin, out Color color)
		{
			color = DelegateMethods.c_1;
			if (stage == 0)
			{
				distCovered = 33f;
				frame = new Rectangle(0, 0, 26, 22);
				origin = frame.Size() / 2f;
				return;
			}
			if (stage == 1)
			{
				frame = new Rectangle(0, 25, 26, 28);
				distCovered = (float)frame.Height;
				origin = new Vector2((float)(frame.Width / 2), 0f);
				return;
			}
			if (stage == 2)
			{
				distCovered = 22f;
				frame = new Rectangle(0, 56, 26, 22);
				origin = new Vector2((float)(frame.Width / 2), 1f);
				return;
			}
			distCovered = 9999f;
			frame = Rectangle.Empty;
			origin = Vector2.Zero;
			color = Color.Transparent;
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x0002E5AC File Offset: 0x0002C7AC
		public static void TurretLaserDraw(int stage, Vector2 currentPosition, float distanceLeft, Rectangle lastFrame, out float distCovered, out Rectangle frame, out Vector2 origin, out Color color)
		{
			color = DelegateMethods.c_1;
			if (stage == 0)
			{
				distCovered = 32f;
				frame = new Rectangle(0, 0, 22, 20);
				origin = frame.Size() / 2f;
				return;
			}
			if (stage == 1)
			{
				DelegateMethods.i_1++;
				int num = DelegateMethods.i_1 % 5;
				frame = new Rectangle(0, 22 * (num + 1), 22, 20);
				distCovered = (float)(frame.Height - 1);
				origin = new Vector2((float)(frame.Width / 2), 0f);
				return;
			}
			if (stage == 2)
			{
				frame = new Rectangle(0, 154, 22, 30);
				distCovered = (float)frame.Height;
				origin = new Vector2((float)(frame.Width / 2), 1f);
				return;
			}
			distCovered = 9999f;
			frame = Rectangle.Empty;
			origin = Vector2.Zero;
			color = Color.Transparent;
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x0002E6C8 File Offset: 0x0002C8C8
		public static void LightningLaserDraw(int stage, Vector2 currentPosition, float distanceLeft, Rectangle lastFrame, out float distCovered, out Rectangle frame, out Vector2 origin, out Color color)
		{
			color = DelegateMethods.c_1 * DelegateMethods.f_1;
			if (stage == 0)
			{
				distCovered = 0f;
				frame = new Rectangle(0, 0, 21, 8);
				origin = frame.Size() / 2f;
				return;
			}
			if (stage == 1)
			{
				frame = new Rectangle(0, 8, 21, 6);
				distCovered = (float)frame.Height;
				origin = new Vector2((float)(frame.Width / 2), 0f);
				return;
			}
			if (stage == 2)
			{
				distCovered = 8f;
				frame = new Rectangle(0, 14, 21, 8);
				origin = new Vector2((float)(frame.Width / 2), 2f);
				return;
			}
			distCovered = 9999f;
			frame = Rectangle.Empty;
			origin = Vector2.Zero;
			color = Color.Transparent;
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x0002E7C8 File Offset: 0x0002C9C8
		public static int CompareYReverse(Point a, Point b)
		{
			return b.Y.CompareTo(a.Y);
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0002E7DC File Offset: 0x0002C9DC
		public static int CompareDrawSorterByYScale(DrawData a, DrawData b)
		{
			return a.scale.Y.CompareTo(b.scale.Y);
		}

		// Token: 0x040001A2 RID: 418
		public static Vector3 v3_1 = Vector3.Zero;

		// Token: 0x040001A3 RID: 419
		public static float f_1 = 0f;

		// Token: 0x040001A4 RID: 420
		public static Color c_1 = Color.Transparent;

		// Token: 0x040001A5 RID: 421
		public static int i_1 = 0;

		// Token: 0x040001A6 RID: 422
		public static TileCuttingContext tilecut_0 = TileCuttingContext.Unknown;

		// Token: 0x020001C3 RID: 451
		public static class Minecart
		{
			// Token: 0x060013FF RID: 5119 RVA: 0x0041D058 File Offset: 0x0041B258
			public static void Sparks(Vector2 dustPosition)
			{
				dustPosition += new Vector2((float)((Main.rand.Next(2) == 0) ? 13 : -13), 0f).RotatedBy((double)DelegateMethods.Minecart.rotation, default(Vector2));
				int num = Dust.NewDust(dustPosition, 1, 1, 213, (float)Main.rand.Next(-2, 3), (float)Main.rand.Next(-2, 3), 0, default(Color), 1f);
				Main.dust[num].noGravity = true;
				Main.dust[num].fadeIn = Main.dust[num].scale + 1f + 0.01f * (float)Main.rand.Next(0, 51);
				Main.dust[num].noGravity = true;
				Main.dust[num].velocity *= (float)Main.rand.Next(15, 51) * 0.01f;
				Dust expr_FD_cp_0_cp_0 = Main.dust[num];
				expr_FD_cp_0_cp_0.velocity.X = expr_FD_cp_0_cp_0.velocity.X * ((float)Main.rand.Next(25, 101) * 0.01f);
				Dust expr_127_cp_0_cp_0 = Main.dust[num];
				expr_127_cp_0_cp_0.velocity.Y = expr_127_cp_0_cp_0.velocity.Y - (float)Main.rand.Next(15, 31) * 0.1f;
				Dust expr_151_cp_0_cp_0 = Main.dust[num];
				expr_151_cp_0_cp_0.position.Y = expr_151_cp_0_cp_0.position.Y - 4f;
				if (Main.rand.Next(3) != 0)
				{
					Main.dust[num].noGravity = false;
					return;
				}
				Main.dust[num].scale *= 0.6f;
			}

			// Token: 0x06001400 RID: 5120 RVA: 0x0041D1F4 File Offset: 0x0041B3F4
			public static void SparksMech(Vector2 dustPosition)
			{
				dustPosition += new Vector2((float)((Main.rand.Next(2) == 0) ? 13 : -13), 0f).RotatedBy((double)DelegateMethods.Minecart.rotation, default(Vector2));
				int num = Dust.NewDust(dustPosition, 1, 1, 260, (float)Main.rand.Next(-2, 3), (float)Main.rand.Next(-2, 3), 0, default(Color), 1f);
				Main.dust[num].noGravity = true;
				Main.dust[num].fadeIn = Main.dust[num].scale + 0.5f + 0.01f * (float)Main.rand.Next(0, 51);
				Main.dust[num].noGravity = true;
				Main.dust[num].velocity *= (float)Main.rand.Next(15, 51) * 0.01f;
				Dust expr_FD_cp_0_cp_0 = Main.dust[num];
				expr_FD_cp_0_cp_0.velocity.X = expr_FD_cp_0_cp_0.velocity.X * ((float)Main.rand.Next(25, 101) * 0.01f);
				Dust expr_127_cp_0_cp_0 = Main.dust[num];
				expr_127_cp_0_cp_0.velocity.Y = expr_127_cp_0_cp_0.velocity.Y - (float)Main.rand.Next(15, 31) * 0.1f;
				Dust expr_151_cp_0_cp_0 = Main.dust[num];
				expr_151_cp_0_cp_0.position.Y = expr_151_cp_0_cp_0.position.Y - 4f;
				if (Main.rand.Next(3) != 0)
				{
					Main.dust[num].noGravity = false;
					return;
				}
				Main.dust[num].scale *= 0.6f;
			}

			// Token: 0x04003678 RID: 13944
			public static Vector2 rotationOrigin;

			// Token: 0x04003679 RID: 13945
			public static float rotation;
		}
	}
}

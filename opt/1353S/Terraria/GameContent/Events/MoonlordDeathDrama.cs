using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics;
using Terraria.Utilities;

namespace Terraria.GameContent.Events
{
	// Token: 0x02000175 RID: 373
	public class MoonlordDeathDrama
	{
		// Token: 0x06001267 RID: 4711 RVA: 0x004173E4 File Offset: 0x004155E4
		public static void Update()
		{
			for (int i = 0; i < MoonlordDeathDrama._pieces.Count; i++)
			{
				MoonlordDeathDrama.MoonlordPiece moonlordPiece = MoonlordDeathDrama._pieces[i];
				moonlordPiece.Update();
				if (moonlordPiece.Dead)
				{
					MoonlordDeathDrama._pieces.Remove(moonlordPiece);
					i--;
				}
			}
			for (int j = 0; j < MoonlordDeathDrama._explosions.Count; j++)
			{
				MoonlordDeathDrama.MoonlordExplosion moonlordExplosion = MoonlordDeathDrama._explosions[j];
				moonlordExplosion.Update();
				if (moonlordExplosion.Dead)
				{
					MoonlordDeathDrama._explosions.Remove(moonlordExplosion);
					j--;
				}
			}
			bool flag = false;
			for (int k = 0; k < MoonlordDeathDrama._lightSources.Count; k++)
			{
				if (Main.player[Main.myPlayer].Distance(MoonlordDeathDrama._lightSources[k]) < 2000f)
				{
					flag = true;
					break;
				}
			}
			MoonlordDeathDrama._lightSources.Clear();
			if (!flag)
			{
				MoonlordDeathDrama.requestedLight = 0f;
			}
			if (MoonlordDeathDrama.requestedLight != MoonlordDeathDrama.whitening)
			{
				if (Math.Abs(MoonlordDeathDrama.requestedLight - MoonlordDeathDrama.whitening) < 0.02f)
				{
					MoonlordDeathDrama.whitening = MoonlordDeathDrama.requestedLight;
				}
				else
				{
					MoonlordDeathDrama.whitening += (float)Math.Sign(MoonlordDeathDrama.requestedLight - MoonlordDeathDrama.whitening) * 0.02f;
				}
			}
			MoonlordDeathDrama.requestedLight = 0f;
		}

		// Token: 0x06001268 RID: 4712 RVA: 0x00417528 File Offset: 0x00415728
		public static void DrawPieces(SpriteBatch spriteBatch)
		{
			Rectangle playerScreen = Utils.CenteredRectangle(Main.screenPosition + new Vector2((float)Main.screenWidth, (float)Main.screenHeight) * 0.5f, new Vector2((float)(Main.screenWidth + 1000), (float)(Main.screenHeight + 1000)));
			for (int i = 0; i < MoonlordDeathDrama._pieces.Count; i++)
			{
				if (MoonlordDeathDrama._pieces[i].InDrawRange(playerScreen))
				{
					MoonlordDeathDrama._pieces[i].Draw(spriteBatch);
				}
			}
		}

		// Token: 0x06001269 RID: 4713 RVA: 0x004175B8 File Offset: 0x004157B8
		public static void DrawExplosions(SpriteBatch spriteBatch)
		{
			Rectangle playerScreen = Utils.CenteredRectangle(Main.screenPosition + new Vector2((float)Main.screenWidth, (float)Main.screenHeight) * 0.5f, new Vector2((float)(Main.screenWidth + 1000), (float)(Main.screenHeight + 1000)));
			for (int i = 0; i < MoonlordDeathDrama._explosions.Count; i++)
			{
				if (MoonlordDeathDrama._explosions[i].InDrawRange(playerScreen))
				{
					MoonlordDeathDrama._explosions[i].Draw(spriteBatch);
				}
			}
		}

		// Token: 0x0600126A RID: 4714 RVA: 0x00417648 File Offset: 0x00415848
		public static void DrawWhite(SpriteBatch spriteBatch)
		{
			if (MoonlordDeathDrama.whitening == 0f)
			{
				return;
			}
			Color color = Color.White * MoonlordDeathDrama.whitening;
			spriteBatch.Draw(Main.magicPixel, new Rectangle(-2, -2, Main.screenWidth + 4, Main.screenHeight + 4), new Rectangle?(new Rectangle(0, 0, 1, 1)), color);
		}

		// Token: 0x0600126B RID: 4715 RVA: 0x004176A4 File Offset: 0x004158A4
		public static void ThrowPieces(Vector2 MoonlordCoreCenter, int DramaSeed)
		{
			UnifiedRandom r = new UnifiedRandom(DramaSeed);
			Vector2 value = Vector2.UnitY.RotatedBy((double)(r.NextFloat() * 1.57079637f - 0.7853982f + 3.14159274f), default(Vector2));
			MoonlordDeathDrama._pieces.Add(new MoonlordDeathDrama.MoonlordPiece(TextureManager.Load("Images/Misc/MoonExplosion/Spine"), new Vector2(64f, 150f), MoonlordCoreCenter + new Vector2(0f, 50f), value * 6f, 0f, r.NextFloat() * 0.1f - 0.05f));
			value = Vector2.UnitY.RotatedBy((double)(r.NextFloat() * 1.57079637f - 0.7853982f + 3.14159274f), default(Vector2));
			MoonlordDeathDrama._pieces.Add(new MoonlordDeathDrama.MoonlordPiece(TextureManager.Load("Images/Misc/MoonExplosion/Shoulder"), new Vector2(40f, 120f), MoonlordCoreCenter + new Vector2(50f, -120f), value * 10f, 0f, r.NextFloat() * 0.1f - 0.05f));
			value = Vector2.UnitY.RotatedBy((double)(r.NextFloat() * 1.57079637f - 0.7853982f + 3.14159274f), default(Vector2));
			MoonlordDeathDrama._pieces.Add(new MoonlordDeathDrama.MoonlordPiece(TextureManager.Load("Images/Misc/MoonExplosion/Torso"), new Vector2(192f, 252f), MoonlordCoreCenter, value * 8f, 0f, r.NextFloat() * 0.1f - 0.05f));
			value = Vector2.UnitY.RotatedBy((double)(r.NextFloat() * 1.57079637f - 0.7853982f + 3.14159274f), default(Vector2));
			MoonlordDeathDrama._pieces.Add(new MoonlordDeathDrama.MoonlordPiece(TextureManager.Load("Images/Misc/MoonExplosion/Head"), new Vector2(138f, 185f), MoonlordCoreCenter - new Vector2(0f, 200f), value * 12f, 0f, r.NextFloat() * 0.1f - 0.05f));
		}

		// Token: 0x0600126C RID: 4716 RVA: 0x004178D4 File Offset: 0x00415AD4
		public static void AddExplosion(Vector2 spot)
		{
			MoonlordDeathDrama._explosions.Add(new MoonlordDeathDrama.MoonlordExplosion(TextureManager.Load("Images/Misc/MoonExplosion/Explosion"), spot, Main.rand.Next(2, 4)));
		}

		// Token: 0x0600126D RID: 4717 RVA: 0x004178FC File Offset: 0x00415AFC
		public static void RequestLight(float light, Vector2 spot)
		{
			MoonlordDeathDrama._lightSources.Add(spot);
			if (light > 1f)
			{
				light = 1f;
			}
			if (MoonlordDeathDrama.requestedLight < light)
			{
				MoonlordDeathDrama.requestedLight = light;
			}
		}

		// Token: 0x04003293 RID: 12947
		private static List<MoonlordDeathDrama.MoonlordPiece> _pieces = new List<MoonlordDeathDrama.MoonlordPiece>();

		// Token: 0x04003294 RID: 12948
		private static List<MoonlordDeathDrama.MoonlordExplosion> _explosions = new List<MoonlordDeathDrama.MoonlordExplosion>();

		// Token: 0x04003295 RID: 12949
		private static List<Vector2> _lightSources = new List<Vector2>();

		// Token: 0x04003296 RID: 12950
		private static float whitening = 0f;

		// Token: 0x04003297 RID: 12951
		private static float requestedLight = 0f;

		// Token: 0x020002BF RID: 703
		public class MoonlordPiece
		{
			// Token: 0x060017A1 RID: 6049 RVA: 0x0043C818 File Offset: 0x0043AA18
			public MoonlordPiece(Texture2D pieceTexture, Vector2 textureOrigin, Vector2 centerPos, Vector2 velocity, float rot, float angularVelocity)
			{
				this._texture = pieceTexture;
				this._origin = textureOrigin;
				this._position = centerPos;
				this._velocity = velocity;
				this._rotation = rot;
				this._rotationVelocity = angularVelocity;
			}

			// Token: 0x060017A2 RID: 6050 RVA: 0x0043C850 File Offset: 0x0043AA50
			public void Update()
			{
				this._velocity.Y = this._velocity.Y + 0.3f;
				this._rotation += this._rotationVelocity;
				this._rotationVelocity *= 0.99f;
				this._position += this._velocity;
			}

			// Token: 0x060017A3 RID: 6051 RVA: 0x0043C8B0 File Offset: 0x0043AAB0
			public void Draw(SpriteBatch sp)
			{
				Color light = this.GetLight();
				sp.Draw(this._texture, this._position - Main.screenPosition, null, light, this._rotation, this._origin, 1f, SpriteEffects.None, 0f);
			}

			// Token: 0x170001D4 RID: 468
			// (get) Token: 0x060017A4 RID: 6052 RVA: 0x0043C904 File Offset: 0x0043AB04
			public bool Dead
			{
				get
				{
					return this._position.Y > (float)(Main.maxTilesY * 16) - 480f || this._position.X < 480f || this._position.X >= (float)(Main.maxTilesX * 16) - 480f;
				}
			}

			// Token: 0x060017A5 RID: 6053 RVA: 0x0043C960 File Offset: 0x0043AB60
			public bool InDrawRange(Rectangle playerScreen)
			{
				return playerScreen.Contains(this._position.ToPoint());
			}

			// Token: 0x060017A6 RID: 6054 RVA: 0x0043C974 File Offset: 0x0043AB74
			public Color GetLight()
			{
				Vector3 vector = Vector3.Zero;
				float num = 0f;
				int num2 = 5;
				Point point = this._position.ToTileCoordinates();
				for (int i = point.X - num2; i <= point.X + num2; i++)
				{
					for (int j = point.Y - num2; j <= point.Y + num2; j++)
					{
						vector += Lighting.GetColor(i, j).ToVector3();
						num += 1f;
					}
				}
				if (num == 0f)
				{
					return Color.White;
				}
				return new Color(vector / num);
			}

			// Token: 0x04003D66 RID: 15718
			private Texture2D _texture;

			// Token: 0x04003D67 RID: 15719
			private Vector2 _position;

			// Token: 0x04003D68 RID: 15720
			private Vector2 _velocity;

			// Token: 0x04003D69 RID: 15721
			private Vector2 _origin;

			// Token: 0x04003D6A RID: 15722
			private float _rotation;

			// Token: 0x04003D6B RID: 15723
			private float _rotationVelocity;
		}

		// Token: 0x020002C0 RID: 704
		public class MoonlordExplosion
		{
			// Token: 0x060017A7 RID: 6055 RVA: 0x0043CA14 File Offset: 0x0043AC14
			public MoonlordExplosion(Texture2D pieceTexture, Vector2 centerPos, int frameSpeed)
			{
				this._texture = pieceTexture;
				this._position = centerPos;
				this._frameSpeed = frameSpeed;
				this._frameCounter = 0;
				this._frame = this._texture.Frame(1, 7, 0, 0);
				this._origin = this._frame.Size() / 2f;
			}

			// Token: 0x060017A8 RID: 6056 RVA: 0x0043CA74 File Offset: 0x0043AC74
			public void Update()
			{
				this._frameCounter++;
				this._frame = this._texture.Frame(1, 7, 0, this._frameCounter / this._frameSpeed);
			}

			// Token: 0x060017A9 RID: 6057 RVA: 0x0043CAA8 File Offset: 0x0043ACA8
			public void Draw(SpriteBatch sp)
			{
				Color light = this.GetLight();
				sp.Draw(this._texture, this._position - Main.screenPosition, new Rectangle?(this._frame), light, 0f, this._origin, 1f, SpriteEffects.None, 0f);
			}

			// Token: 0x170001D5 RID: 469
			// (get) Token: 0x060017AA RID: 6058 RVA: 0x0043CAFC File Offset: 0x0043ACFC
			public bool Dead
			{
				get
				{
					return this._position.Y > (float)(Main.maxTilesY * 16) - 480f || this._position.X < 480f || this._position.X >= (float)(Main.maxTilesX * 16) - 480f || this._frameCounter >= this._frameSpeed * 7;
				}
			}

			// Token: 0x060017AB RID: 6059 RVA: 0x0043CB68 File Offset: 0x0043AD68
			public bool InDrawRange(Rectangle playerScreen)
			{
				return playerScreen.Contains(this._position.ToPoint());
			}

			// Token: 0x060017AC RID: 6060 RVA: 0x0043CB7C File Offset: 0x0043AD7C
			public Color GetLight()
			{
				return new Color(255, 255, 255, 127);
			}

			// Token: 0x04003D6C RID: 15724
			private Texture2D _texture;

			// Token: 0x04003D6D RID: 15725
			private Vector2 _position;

			// Token: 0x04003D6E RID: 15726
			private Vector2 _origin;

			// Token: 0x04003D6F RID: 15727
			private Rectangle _frame;

			// Token: 0x04003D70 RID: 15728
			private int _frameCounter;

			// Token: 0x04003D71 RID: 15729
			private int _frameSpeed;
		}
	}
}

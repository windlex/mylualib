using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace Terraria.GameContent.Skies
{
	// Token: 0x02000164 RID: 356
	public class VortexSky : CustomSky
	{
		// Token: 0x060011B9 RID: 4537 RVA: 0x0040ED48 File Offset: 0x0040CF48
		public override void OnLoad()
		{
			this._planetTexture = TextureManager.Load("Images/Misc/VortexSky/Planet");
			this._bgTexture = TextureManager.Load("Images/Misc/VortexSky/Background");
			this._boltTexture = TextureManager.Load("Images/Misc/VortexSky/Bolt");
			this._flashTexture = TextureManager.Load("Images/Misc/VortexSky/Flash");
		}

		// Token: 0x060011BA RID: 4538 RVA: 0x0040ED98 File Offset: 0x0040CF98
		public override void Update(GameTime gameTime)
		{
			if (this._isActive)
			{
				this._fadeOpacity = Math.Min(1f, 0.01f + this._fadeOpacity);
			}
			else
			{
				this._fadeOpacity = Math.Max(0f, this._fadeOpacity - 0.01f);
			}
			if (this._ticksUntilNextBolt <= 0)
			{
				this._ticksUntilNextBolt = this._random.Next(1, 5);
				int num = 0;
				while (this._bolts[num].IsAlive && num != this._bolts.Length - 1)
				{
					num++;
				}
				this._bolts[num].IsAlive = true;
				this._bolts[num].Position.X = this._random.NextFloat() * ((float)Main.maxTilesX * 16f + 4000f) - 2000f;
				this._bolts[num].Position.Y = this._random.NextFloat() * 500f;
				this._bolts[num].Depth = this._random.NextFloat() * 8f + 2f;
				this._bolts[num].Life = 30;
			}
			this._ticksUntilNextBolt--;
			for (int i = 0; i < this._bolts.Length; i++)
			{
				if (this._bolts[i].IsAlive)
				{
					VortexSky.Bolt[] expr_16D_cp_0_cp_0 = this._bolts;
					int expr_16D_cp_0_cp_1 = i;
					expr_16D_cp_0_cp_0[expr_16D_cp_0_cp_1].Life = expr_16D_cp_0_cp_0[expr_16D_cp_0_cp_1].Life - 1;
					if (this._bolts[i].Life <= 0)
					{
						this._bolts[i].IsAlive = false;
					}
				}
			}
		}

		// Token: 0x060011BB RID: 4539 RVA: 0x0040EF4C File Offset: 0x0040D14C
		public override Color OnTileColor(Color inColor)
		{
			return new Color(Vector4.Lerp(inColor.ToVector4(), Vector4.One, this._fadeOpacity * 0.5f));
		}

		// Token: 0x060011BC RID: 4540 RVA: 0x0040EF70 File Offset: 0x0040D170
		public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			if (maxDepth >= 3.40282347E+38f && minDepth < 3.40282347E+38f)
			{
				spriteBatch.Draw(Main.blackTileTexture, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.Black * this._fadeOpacity);
				spriteBatch.Draw(this._bgTexture, new Rectangle(0, Math.Max(0, (int)((Main.worldSurface * 16.0 - (double)Main.screenPosition.Y - 2400.0) * 0.10000000149011612)), Main.screenWidth, Main.screenHeight), Color.White * Math.Min(1f, (Main.screenPosition.Y - 800f) / 1000f) * this._fadeOpacity);
				Vector2 value = new Vector2((float)(Main.screenWidth >> 1), (float)(Main.screenHeight >> 1));
				Vector2 value2 = 0.01f * (new Vector2((float)Main.maxTilesX * 8f, (float)Main.worldSurface / 2f) - Main.screenPosition);
				spriteBatch.Draw(this._planetTexture, value + new Vector2(-200f, -200f) + value2, null, Color.White * 0.9f * this._fadeOpacity, 0f, new Vector2((float)(this._planetTexture.Width >> 1), (float)(this._planetTexture.Height >> 1)), 1f, SpriteEffects.None, 1f);
			}
			float scale = Math.Min(1f, (Main.screenPosition.Y - 1000f) / 1000f);
			Vector2 value3 = Main.screenPosition + new Vector2((float)(Main.screenWidth >> 1), (float)(Main.screenHeight >> 1));
			Rectangle rectangle = new Rectangle(-1000, -1000, 4000, 4000);
			for (int i = 0; i < this._bolts.Length; i++)
			{
				if (this._bolts[i].IsAlive && this._bolts[i].Depth > minDepth && this._bolts[i].Depth < maxDepth)
				{
					Vector2 vector = new Vector2(1f / this._bolts[i].Depth, 0.9f / this._bolts[i].Depth);
					Vector2 vector2 = (this._bolts[i].Position - value3) * vector + value3 - Main.screenPosition;
					if (rectangle.Contains((int)vector2.X, (int)vector2.Y))
					{
						Texture2D texture = this._boltTexture;
						int life = this._bolts[i].Life;
						if (life > 26 && life % 2 == 0)
						{
							texture = this._flashTexture;
						}
						float scale2 = (float)life / 30f;
						spriteBatch.Draw(texture, vector2, null, Color.White * scale * scale2 * this._fadeOpacity, 0f, Vector2.Zero, vector.X * 5f, SpriteEffects.None, 0f);
					}
				}
			}
		}

		// Token: 0x060011BD RID: 4541 RVA: 0x0040F2DC File Offset: 0x0040D4DC
		public override float GetCloudAlpha()
		{
			return (1f - this._fadeOpacity) * 0.3f + 0.7f;
		}

		// Token: 0x060011BE RID: 4542 RVA: 0x0040F2F8 File Offset: 0x0040D4F8
		internal override void Activate(Vector2 position, params object[] args)
		{
			this._fadeOpacity = 0.002f;
			this._isActive = true;
			this._bolts = new VortexSky.Bolt[500];
			for (int i = 0; i < this._bolts.Length; i++)
			{
				this._bolts[i].IsAlive = false;
			}
		}

		// Token: 0x060011BF RID: 4543 RVA: 0x0040F34C File Offset: 0x0040D54C
		internal override void Deactivate(params object[] args)
		{
			this._isActive = false;
		}

		// Token: 0x060011C0 RID: 4544 RVA: 0x0040F358 File Offset: 0x0040D558
		public override void Reset()
		{
			this._isActive = false;
		}

		// Token: 0x060011C1 RID: 4545 RVA: 0x0040F364 File Offset: 0x0040D564
		public override bool IsActive()
		{
			return this._isActive || this._fadeOpacity > 0.001f;
		}

		// Token: 0x04003227 RID: 12839
		private UnifiedRandom _random = new UnifiedRandom();

		// Token: 0x04003228 RID: 12840
		private Texture2D _planetTexture;

		// Token: 0x04003229 RID: 12841
		private Texture2D _bgTexture;

		// Token: 0x0400322A RID: 12842
		private Texture2D _boltTexture;

		// Token: 0x0400322B RID: 12843
		private Texture2D _flashTexture;

		// Token: 0x0400322C RID: 12844
		private bool _isActive;

		// Token: 0x0400322D RID: 12845
		private int _ticksUntilNextBolt;

		// Token: 0x0400322E RID: 12846
		private float _fadeOpacity;

		// Token: 0x0400322F RID: 12847
		private VortexSky.Bolt[] _bolts;

		// Token: 0x020002B3 RID: 691
		private struct Bolt
		{
			// Token: 0x04003D2D RID: 15661
			public Vector2 Position;

			// Token: 0x04003D2E RID: 15662
			public float Depth;

			// Token: 0x04003D2F RID: 15663
			public int Life;

			// Token: 0x04003D30 RID: 15664
			public bool IsAlive;
		}
	}
}

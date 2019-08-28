using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace Terraria.GameContent.Skies
{
	// Token: 0x02000169 RID: 361
	public class NebulaSky : CustomSky
	{
		// Token: 0x060011EA RID: 4586 RVA: 0x00410F24 File Offset: 0x0040F124
		public override void OnLoad()
		{
			this._planetTexture = TextureManager.Load("Images/Misc/NebulaSky/Planet");
			this._bgTexture = TextureManager.Load("Images/Misc/NebulaSky/Background");
			this._beamTexture = TextureManager.Load("Images/Misc/NebulaSky/Beam");
			this._rockTextures = new Texture2D[3];
			for (int i = 0; i < this._rockTextures.Length; i++)
			{
				this._rockTextures[i] = TextureManager.Load("Images/Misc/NebulaSky/Rock_" + i);
			}
		}

		// Token: 0x060011EB RID: 4587 RVA: 0x00410FA0 File Offset: 0x0040F1A0
		public override void Update(GameTime gameTime)
		{
			if (this._isActive)
			{
				this._fadeOpacity = Math.Min(1f, 0.01f + this._fadeOpacity);
				return;
			}
			this._fadeOpacity = Math.Max(0f, this._fadeOpacity - 0.01f);
		}

		// Token: 0x060011EC RID: 4588 RVA: 0x00410FF0 File Offset: 0x0040F1F0
		public override Color OnTileColor(Color inColor)
		{
			return new Color(Vector4.Lerp(inColor.ToVector4(), Vector4.One, this._fadeOpacity * 0.5f));
		}

		// Token: 0x060011ED RID: 4589 RVA: 0x00411014 File Offset: 0x0040F214
		public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			if (maxDepth >= 3.40282347E+38f && minDepth < 3.40282347E+38f)
			{
				spriteBatch.Draw(Main.blackTileTexture, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.Black * this._fadeOpacity);
				spriteBatch.Draw(this._bgTexture, new Rectangle(0, Math.Max(0, (int)((Main.worldSurface * 16.0 - (double)Main.screenPosition.Y - 2400.0) * 0.10000000149011612)), Main.screenWidth, Main.screenHeight), Color.White * Math.Min(1f, (Main.screenPosition.Y - 800f) / 1000f * this._fadeOpacity));
				Vector2 value = new Vector2((float)(Main.screenWidth >> 1), (float)(Main.screenHeight >> 1));
				Vector2 value2 = 0.01f * (new Vector2((float)Main.maxTilesX * 8f, (float)Main.worldSurface / 2f) - Main.screenPosition);
				spriteBatch.Draw(this._planetTexture, value + new Vector2(-200f, -200f) + value2, null, Color.White * 0.9f * this._fadeOpacity, 0f, new Vector2((float)(this._planetTexture.Width >> 1), (float)(this._planetTexture.Height >> 1)), 1f, SpriteEffects.None, 1f);
			}
			int num = -1;
			int num2 = 0;
			for (int i = 0; i < this._pillars.Length; i++)
			{
				float depth = this._pillars[i].Depth;
				if (num == -1 && depth < maxDepth)
				{
					num = i;
				}
				if (depth <= minDepth)
				{
					break;
				}
				num2 = i;
			}
			if (num == -1)
			{
				return;
			}
			Vector2 value3 = Main.screenPosition + new Vector2((float)(Main.screenWidth >> 1), (float)(Main.screenHeight >> 1));
			Rectangle rectangle = new Rectangle(-1000, -1000, 4000, 4000);
			float scale = Math.Min(1f, (Main.screenPosition.Y - 1000f) / 1000f);
			for (int j = num; j < num2; j++)
			{
				Vector2 vector = new Vector2(1f / this._pillars[j].Depth, 0.9f / this._pillars[j].Depth);
				Vector2 vector2 = this._pillars[j].Position;
				vector2 = (vector2 - value3) * vector + value3 - Main.screenPosition;
				if (rectangle.Contains((int)vector2.X, (int)vector2.Y))
				{
					float num3 = vector.X * 450f;
					spriteBatch.Draw(this._beamTexture, vector2, null, Color.White * 0.2f * scale * this._fadeOpacity, 0f, Vector2.Zero, new Vector2(num3 / 70f, num3 / 45f), SpriteEffects.None, 0f);
					int num4 = 0;
					for (float num5 = 0f; num5 <= 1f; num5 += 0.03f)
					{
						float num6 = 1f - (num5 + Main.GlobalTime * 0.02f + (float)Math.Sin((double)((float)j))) % 1f;
						spriteBatch.Draw(this._rockTextures[num4], vector2 + new Vector2((float)Math.Sin((double)(num5 * 1582f)) * (num3 * 0.5f) + num3 * 0.5f, num6 * 2000f), null, Color.White * num6 * scale * this._fadeOpacity, num6 * 20f, new Vector2((float)(this._rockTextures[num4].Width >> 1), (float)(this._rockTextures[num4].Height >> 1)), 0.9f, SpriteEffects.None, 0f);
						num4 = (num4 + 1) % this._rockTextures.Length;
					}
				}
			}
		}

		// Token: 0x060011EE RID: 4590 RVA: 0x00411460 File Offset: 0x0040F660
		public override float GetCloudAlpha()
		{
			return (1f - this._fadeOpacity) * 0.3f + 0.7f;
		}

		// Token: 0x060011EF RID: 4591 RVA: 0x0041147C File Offset: 0x0040F67C
		internal override void Activate(Vector2 position, params object[] args)
		{
			this._fadeOpacity = 0.002f;
			this._isActive = true;
			this._pillars = new NebulaSky.LightPillar[40];
			for (int i = 0; i < this._pillars.Length; i++)
			{
				this._pillars[i].Position.X = (float)i / (float)this._pillars.Length * ((float)Main.maxTilesX * 16f + 20000f) + this._random.NextFloat() * 40f - 20f - 20000f;
				this._pillars[i].Position.Y = this._random.NextFloat() * 200f - 2000f;
				this._pillars[i].Depth = this._random.NextFloat() * 8f + 7f;
			}
			Array.Sort<NebulaSky.LightPillar>(this._pillars, new Comparison<NebulaSky.LightPillar>(this.SortMethod));
		}

		// Token: 0x060011F0 RID: 4592 RVA: 0x00411580 File Offset: 0x0040F780
		private int SortMethod(NebulaSky.LightPillar pillar1, NebulaSky.LightPillar pillar2)
		{
			return pillar2.Depth.CompareTo(pillar1.Depth);
		}

		// Token: 0x060011F1 RID: 4593 RVA: 0x00411594 File Offset: 0x0040F794
		internal override void Deactivate(params object[] args)
		{
			this._isActive = false;
		}

		// Token: 0x060011F2 RID: 4594 RVA: 0x004115A0 File Offset: 0x0040F7A0
		public override void Reset()
		{
			this._isActive = false;
		}

		// Token: 0x060011F3 RID: 4595 RVA: 0x004115AC File Offset: 0x0040F7AC
		public override bool IsActive()
		{
			return this._isActive || this._fadeOpacity > 0.001f;
		}

		// Token: 0x0400324A RID: 12874
		private NebulaSky.LightPillar[] _pillars;

		// Token: 0x0400324B RID: 12875
		private UnifiedRandom _random = new UnifiedRandom();

		// Token: 0x0400324C RID: 12876
		private Texture2D _planetTexture;

		// Token: 0x0400324D RID: 12877
		private Texture2D _bgTexture;

		// Token: 0x0400324E RID: 12878
		private Texture2D _beamTexture;

		// Token: 0x0400324F RID: 12879
		private Texture2D[] _rockTextures;

		// Token: 0x04003250 RID: 12880
		private bool _isActive;

		// Token: 0x04003251 RID: 12881
		private float _fadeOpacity;

		// Token: 0x020002BC RID: 700
		private struct LightPillar
		{
			// Token: 0x04003D5C RID: 15708
			public Vector2 Position;

			// Token: 0x04003D5D RID: 15709
			public float Depth;
		}
	}
}

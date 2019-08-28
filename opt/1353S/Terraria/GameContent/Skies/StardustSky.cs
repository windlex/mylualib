using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace Terraria.GameContent.Skies
{
	// Token: 0x02000167 RID: 359
	public class StardustSky : CustomSky
	{
		// Token: 0x060011D7 RID: 4567 RVA: 0x004102D0 File Offset: 0x0040E4D0
		public override void OnLoad()
		{
			this._planetTexture = TextureManager.Load("Images/Misc/StarDustSky/Planet");
			this._bgTexture = TextureManager.Load("Images/Misc/StarDustSky/Background");
			this._starTextures = new Texture2D[2];
			for (int i = 0; i < this._starTextures.Length; i++)
			{
				this._starTextures[i] = TextureManager.Load("Images/Misc/StarDustSky/Star " + i);
			}
		}

		// Token: 0x060011D8 RID: 4568 RVA: 0x0041033C File Offset: 0x0040E53C
		public override void Update(GameTime gameTime)
		{
			if (this._isActive)
			{
				this._fadeOpacity = Math.Min(1f, 0.01f + this._fadeOpacity);
				return;
			}
			this._fadeOpacity = Math.Max(0f, this._fadeOpacity - 0.01f);
		}

		// Token: 0x060011D9 RID: 4569 RVA: 0x0041038C File Offset: 0x0040E58C
		public override Color OnTileColor(Color inColor)
		{
			return new Color(Vector4.Lerp(inColor.ToVector4(), Vector4.One, this._fadeOpacity * 0.5f));
		}

		// Token: 0x060011DA RID: 4570 RVA: 0x004103B0 File Offset: 0x0040E5B0
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
			for (int i = 0; i < this._stars.Length; i++)
			{
				float depth = this._stars[i].Depth;
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
			float scale = Math.Min(1f, (Main.screenPosition.Y - 1000f) / 1000f);
			Vector2 value3 = Main.screenPosition + new Vector2((float)(Main.screenWidth >> 1), (float)(Main.screenHeight >> 1));
			Rectangle rectangle = new Rectangle(-1000, -1000, 4000, 4000);
			for (int j = num; j < num2; j++)
			{
				Vector2 vector = new Vector2(1f / this._stars[j].Depth, 1.1f / this._stars[j].Depth);
				Vector2 vector2 = (this._stars[j].Position - value3) * vector + value3 - Main.screenPosition;
				if (rectangle.Contains((int)vector2.X, (int)vector2.Y))
				{
					float num3 = (float)Math.Sin((double)(this._stars[j].AlphaFrequency * Main.GlobalTime + this._stars[j].SinOffset)) * this._stars[j].AlphaAmplitude + this._stars[j].AlphaAmplitude;
					float num4 = (float)Math.Sin((double)(this._stars[j].AlphaFrequency * Main.GlobalTime * 5f + this._stars[j].SinOffset)) * 0.1f - 0.1f;
					num3 = MathHelper.Clamp(num3, 0f, 1f);
					Texture2D texture2D = this._starTextures[this._stars[j].TextureIndex];
					spriteBatch.Draw(texture2D, vector2, null, Color.White * scale * num3 * 0.8f * (1f - num4) * this._fadeOpacity, 0f, new Vector2((float)(texture2D.Width >> 1), (float)(texture2D.Height >> 1)), (vector.X * 0.5f + 0.5f) * (num3 * 0.3f + 0.7f), SpriteEffects.None, 0f);
				}
			}
		}

		// Token: 0x060011DB RID: 4571 RVA: 0x004107E4 File Offset: 0x0040E9E4
		public override float GetCloudAlpha()
		{
			return (1f - this._fadeOpacity) * 0.3f + 0.7f;
		}

		// Token: 0x060011DC RID: 4572 RVA: 0x00410800 File Offset: 0x0040EA00
		internal override void Activate(Vector2 position, params object[] args)
		{
			this._fadeOpacity = 0.002f;
			this._isActive = true;
			int num = 200;
			int num2 = 10;
			this._stars = new StardustSky.Star[num * num2];
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				float num4 = (float)i / (float)num;
				for (int j = 0; j < num2; j++)
				{
					float num5 = (float)j / (float)num2;
					this._stars[num3].Position.X = num4 * (float)Main.maxTilesX * 16f;
					this._stars[num3].Position.Y = num5 * ((float)Main.worldSurface * 16f + 2000f) - 1000f;
					this._stars[num3].Depth = this._random.NextFloat() * 8f + 1.5f;
					this._stars[num3].TextureIndex = this._random.Next(this._starTextures.Length);
					this._stars[num3].SinOffset = this._random.NextFloat() * 6.28f;
					this._stars[num3].AlphaAmplitude = this._random.NextFloat() * 5f;
					this._stars[num3].AlphaFrequency = this._random.NextFloat() + 1f;
					num3++;
				}
			}
			Array.Sort<StardustSky.Star>(this._stars, new Comparison<StardustSky.Star>(this.SortMethod));
		}

		// Token: 0x060011DD RID: 4573 RVA: 0x00410994 File Offset: 0x0040EB94
		private int SortMethod(StardustSky.Star meteor1, StardustSky.Star meteor2)
		{
			return meteor2.Depth.CompareTo(meteor1.Depth);
		}

		// Token: 0x060011DE RID: 4574 RVA: 0x004109A8 File Offset: 0x0040EBA8
		internal override void Deactivate(params object[] args)
		{
			this._isActive = false;
		}

		// Token: 0x060011DF RID: 4575 RVA: 0x004109B4 File Offset: 0x0040EBB4
		public override void Reset()
		{
			this._isActive = false;
		}

		// Token: 0x060011E0 RID: 4576 RVA: 0x004109C0 File Offset: 0x0040EBC0
		public override bool IsActive()
		{
			return this._isActive || this._fadeOpacity > 0.001f;
		}

		// Token: 0x0400323D RID: 12861
		private UnifiedRandom _random = new UnifiedRandom();

		// Token: 0x0400323E RID: 12862
		private Texture2D _planetTexture;

		// Token: 0x0400323F RID: 12863
		private Texture2D _bgTexture;

		// Token: 0x04003240 RID: 12864
		private Texture2D[] _starTextures;

		// Token: 0x04003241 RID: 12865
		private bool _isActive;

		// Token: 0x04003242 RID: 12866
		private StardustSky.Star[] _stars;

		// Token: 0x04003243 RID: 12867
		private float _fadeOpacity;

		// Token: 0x020002B6 RID: 694
		private struct Star
		{
			// Token: 0x04003D40 RID: 15680
			public Vector2 Position;

			// Token: 0x04003D41 RID: 15681
			public float Depth;

			// Token: 0x04003D42 RID: 15682
			public int TextureIndex;

			// Token: 0x04003D43 RID: 15683
			public float SinOffset;

			// Token: 0x04003D44 RID: 15684
			public float AlphaFrequency;

			// Token: 0x04003D45 RID: 15685
			public float AlphaAmplitude;
		}
	}
}

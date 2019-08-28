using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace Terraria.GameContent.Skies
{
	// Token: 0x02000165 RID: 357
	public class SolarSky : CustomSky
	{
		// Token: 0x060011C3 RID: 4547 RVA: 0x0040F394 File Offset: 0x0040D594
		public override void OnLoad()
		{
			this._planetTexture = TextureManager.Load("Images/Misc/SolarSky/Planet");
			this._bgTexture = TextureManager.Load("Images/Misc/SolarSky/Background");
			this._meteorTexture = TextureManager.Load("Images/Misc/SolarSky/Meteor");
		}

		// Token: 0x060011C4 RID: 4548 RVA: 0x0040F3C8 File Offset: 0x0040D5C8
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
			float num = 1200f;
			for (int i = 0; i < this._meteors.Length; i++)
			{
				SolarSky.Meteor[] expr_65_cp_0_cp_0_cp_0 = this._meteors;
				int expr_65_cp_0_cp_0_cp_1 = i;
				expr_65_cp_0_cp_0_cp_0[expr_65_cp_0_cp_0_cp_1].Position.X = expr_65_cp_0_cp_0_cp_0[expr_65_cp_0_cp_0_cp_1].Position.X - num * (float)gameTime.ElapsedGameTime.TotalSeconds;
				SolarSky.Meteor[] expr_90_cp_0_cp_0_cp_0 = this._meteors;
				int expr_90_cp_0_cp_0_cp_1 = i;
				expr_90_cp_0_cp_0_cp_0[expr_90_cp_0_cp_0_cp_1].Position.Y = expr_90_cp_0_cp_0_cp_0[expr_90_cp_0_cp_0_cp_1].Position.Y + num * (float)gameTime.ElapsedGameTime.TotalSeconds;
				if ((double)this._meteors[i].Position.Y > Main.worldSurface * 16.0)
				{
					this._meteors[i].Position.X = this._meteors[i].StartX;
					this._meteors[i].Position.Y = -10000f;
				}
			}
		}

		// Token: 0x060011C5 RID: 4549 RVA: 0x0040F4F8 File Offset: 0x0040D6F8
		public override Color OnTileColor(Color inColor)
		{
			return new Color(Vector4.Lerp(inColor.ToVector4(), Vector4.One, this._fadeOpacity * 0.5f));
		}

		// Token: 0x060011C6 RID: 4550 RVA: 0x0040F51C File Offset: 0x0040D71C
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
			for (int i = 0; i < this._meteors.Length; i++)
			{
				float depth = this._meteors[i].Depth;
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
				Vector2 vector = new Vector2(1f / this._meteors[j].Depth, 0.9f / this._meteors[j].Depth);
				Vector2 vector2 = (this._meteors[j].Position - value3) * vector + value3 - Main.screenPosition;
				int num3 = this._meteors[j].FrameCounter / 3;
				this._meteors[j].FrameCounter = (this._meteors[j].FrameCounter + 1) % 12;
				if (rectangle.Contains((int)vector2.X, (int)vector2.Y))
				{
					spriteBatch.Draw(this._meteorTexture, vector2, new Rectangle?(new Rectangle(0, num3 * (this._meteorTexture.Height / 4), this._meteorTexture.Width, this._meteorTexture.Height / 4)), Color.White * scale * this._fadeOpacity, 0f, Vector2.Zero, vector.X * 5f * this._meteors[j].Scale, SpriteEffects.None, 0f);
				}
			}
		}

		// Token: 0x060011C7 RID: 4551 RVA: 0x0040F8BC File Offset: 0x0040DABC
		public override float GetCloudAlpha()
		{
			return (1f - this._fadeOpacity) * 0.3f + 0.7f;
		}

		// Token: 0x060011C8 RID: 4552 RVA: 0x0040F8D8 File Offset: 0x0040DAD8
		internal override void Activate(Vector2 position, params object[] args)
		{
			this._fadeOpacity = 0.002f;
			this._isActive = true;
			this._meteors = new SolarSky.Meteor[150];
			for (int i = 0; i < this._meteors.Length; i++)
			{
				float num = (float)i / (float)this._meteors.Length;
				this._meteors[i].Position.X = num * ((float)Main.maxTilesX * 16f) + this._random.NextFloat() * 40f - 20f;
				this._meteors[i].Position.Y = this._random.NextFloat() * -((float)Main.worldSurface * 16f + 10000f) - 10000f;
				if (this._random.Next(3) != 0)
				{
					this._meteors[i].Depth = this._random.NextFloat() * 3f + 1.8f;
				}
				else
				{
					this._meteors[i].Depth = this._random.NextFloat() * 5f + 4.8f;
				}
				this._meteors[i].FrameCounter = this._random.Next(12);
				this._meteors[i].Scale = this._random.NextFloat() * 0.5f + 1f;
				this._meteors[i].StartX = this._meteors[i].Position.X;
			}
			Array.Sort<SolarSky.Meteor>(this._meteors, new Comparison<SolarSky.Meteor>(this.SortMethod));
		}

		// Token: 0x060011C9 RID: 4553 RVA: 0x0040FA88 File Offset: 0x0040DC88
		private int SortMethod(SolarSky.Meteor meteor1, SolarSky.Meteor meteor2)
		{
			return meteor2.Depth.CompareTo(meteor1.Depth);
		}

		// Token: 0x060011CA RID: 4554 RVA: 0x0040FA9C File Offset: 0x0040DC9C
		internal override void Deactivate(params object[] args)
		{
			this._isActive = false;
		}

		// Token: 0x060011CB RID: 4555 RVA: 0x0040FAA8 File Offset: 0x0040DCA8
		public override void Reset()
		{
			this._isActive = false;
		}

		// Token: 0x060011CC RID: 4556 RVA: 0x0040FAB4 File Offset: 0x0040DCB4
		public override bool IsActive()
		{
			return this._isActive || this._fadeOpacity > 0.001f;
		}

		// Token: 0x04003230 RID: 12848
		private UnifiedRandom _random = new UnifiedRandom();

		// Token: 0x04003231 RID: 12849
		private Texture2D _planetTexture;

		// Token: 0x04003232 RID: 12850
		private Texture2D _bgTexture;

		// Token: 0x04003233 RID: 12851
		private Texture2D _meteorTexture;

		// Token: 0x04003234 RID: 12852
		private bool _isActive;

		// Token: 0x04003235 RID: 12853
		private SolarSky.Meteor[] _meteors;

		// Token: 0x04003236 RID: 12854
		private float _fadeOpacity;

		// Token: 0x020002B4 RID: 692
		private struct Meteor
		{
			// Token: 0x04003D31 RID: 15665
			public Vector2 Position;

			// Token: 0x04003D32 RID: 15666
			public float Depth;

			// Token: 0x04003D33 RID: 15667
			public int FrameCounter;

			// Token: 0x04003D34 RID: 15668
			public float Scale;

			// Token: 0x04003D35 RID: 15669
			public float StartX;
		}
	}
}

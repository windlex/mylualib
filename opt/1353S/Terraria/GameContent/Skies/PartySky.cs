using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace Terraria.GameContent.Skies
{
	// Token: 0x02000161 RID: 353
	public class PartySky : CustomSky
	{
		// Token: 0x06001199 RID: 4505 RVA: 0x0040E228 File Offset: 0x0040C428
		public override void OnLoad()
		{
			this._textures = new Texture2D[3];
			for (int i = 0; i < this._textures.Length; i++)
			{
				this._textures[i] = Main.extraTexture[69 + i];
			}
			this.GenerateBalloons(false);
		}

		// Token: 0x0600119A RID: 4506 RVA: 0x0040E270 File Offset: 0x0040C470
		private void GenerateBalloons(bool onlyMissing)
		{
			if (!onlyMissing)
			{
				this._balloons = new PartySky.Balloon[Main.maxTilesY / 4];
			}
			for (int i = 0; i < this._balloons.Length; i++)
			{
				if (!onlyMissing || !this._balloons[i].Active)
				{
					int num = (int)((double)Main.screenPosition.Y * 0.7 - (double)Main.screenHeight);
					int minValue = (int)((double)num - Main.worldSurface * 16.0);
					this._balloons[i].Position = new Vector2((float)(this._random.Next(0, Main.maxTilesX) * 16), (float)this._random.Next(minValue, num));
					this.ResetBalloon(i);
					this._balloons[i].Active = true;
				}
			}
			this._balloonsDrawing = this._balloons.Length;
		}

		// Token: 0x0600119B RID: 4507 RVA: 0x0040E358 File Offset: 0x0040C558
		public void ResetBalloon(int i)
		{
			this._balloons[i].Depth = (float)i / (float)this._balloons.Length * 1.75f + 1.6f;
			this._balloons[i].Speed = -1.5f - 2.5f * (float)this._random.NextDouble();
			this._balloons[i].Texture = this._textures[this._random.Next(2)];
			this._balloons[i].Variant = this._random.Next(3);
			if (this._random.Next(30) == 0)
			{
				this._balloons[i].Texture = this._textures[2];
			}
		}

		// Token: 0x0600119C RID: 4508 RVA: 0x0040E420 File Offset: 0x0040C620
		private bool IsNearParty()
		{
			return Main.player[Main.myPlayer].townNPCs > 0f || Main.partyMonoliths > 0;
		}

		// Token: 0x0600119D RID: 4509 RVA: 0x0040E444 File Offset: 0x0040C644
		public override void Update(GameTime gameTime)
		{
			if (!PartySky.MultipleSkyWorkaroundFix)
			{
				return;
			}
			PartySky.MultipleSkyWorkaroundFix = false;
			if (Main.gamePaused || !Main.hasFocus)
			{
				return;
			}
			this._opacity = Utils.Clamp<float>(this._opacity + (float)this.IsNearParty().ToDirectionInt() * 0.01f, 0f, 1f);
			for (int i = 0; i < this._balloons.Length; i++)
			{
				if (this._balloons[i].Active)
				{
					PartySky.Balloon[] expr_74_cp_0 = this._balloons;
					int expr_74_cp_1 = i;
					int frame = expr_74_cp_0[expr_74_cp_1].Frame;
					expr_74_cp_0[expr_74_cp_1].Frame = frame + 1;
					PartySky.Balloon[] expr_99_cp_0_cp_0_cp_0 = this._balloons;
					int expr_99_cp_0_cp_0_cp_1 = i;
					expr_99_cp_0_cp_0_cp_0[expr_99_cp_0_cp_0_cp_1].Position.Y = expr_99_cp_0_cp_0_cp_0[expr_99_cp_0_cp_0_cp_1].Position.Y + this._balloons[i].Speed;
					PartySky.Balloon[] expr_C4_cp_0_cp_0_cp_0 = this._balloons;
					int expr_C4_cp_0_cp_0_cp_1 = i;
					expr_C4_cp_0_cp_0_cp_0[expr_C4_cp_0_cp_0_cp_1].Position.X = expr_C4_cp_0_cp_0_cp_0[expr_C4_cp_0_cp_0_cp_1].Position.X + Main.windSpeed * (3f - this._balloons[i].Speed);
					if (this._balloons[i].Position.Y < 300f)
					{
						if (!this._leaving)
						{
							this.ResetBalloon(i);
							this._balloons[i].Position = new Vector2((float)(this._random.Next(0, Main.maxTilesX) * 16), (float)Main.worldSurface * 16f + 1600f);
							if (this._random.Next(30) == 0)
							{
								this._balloons[i].Texture = this._textures[2];
							}
						}
						else
						{
							this._balloons[i].Active = false;
							this._balloonsDrawing--;
						}
					}
				}
			}
			if (this._balloonsDrawing == 0)
			{
				this._active = false;
			}
			this._active = true;
		}

		// Token: 0x0600119E RID: 4510 RVA: 0x0040E614 File Offset: 0x0040C814
		public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			if (Main.gameMenu && this._active)
			{
				this._active = false;
				this._leaving = false;
				for (int i = 0; i < this._balloons.Length; i++)
				{
					this._balloons[i].Active = false;
				}
			}
			if ((double)Main.screenPosition.Y > Main.worldSurface * 16.0 || Main.gameMenu)
			{
				return;
			}
			if (this._opacity <= 0f)
			{
				return;
			}
			int num = -1;
			int num2 = 0;
			for (int j = 0; j < this._balloons.Length; j++)
			{
				float depth = this._balloons[j].Depth;
				if (num == -1 && depth < maxDepth)
				{
					num = j;
				}
				if (depth <= minDepth)
				{
					break;
				}
				num2 = j;
			}
			if (num == -1)
			{
				return;
			}
			Vector2 value = Main.screenPosition + new Vector2((float)(Main.screenWidth >> 1), (float)(Main.screenHeight >> 1));
			Rectangle rectangle = new Rectangle(-1000, -1000, 4000, 4000);
			for (int k = num; k < num2; k++)
			{
				if (this._balloons[k].Active)
				{
					Color value2 = new Color(Main.bgColor.ToVector4() * 0.9f + new Vector4(0.1f)) * 0.8f;
					float num3 = 1f;
					if (this._balloons[k].Depth > 3f)
					{
						num3 = 0.6f;
					}
					else if ((double)this._balloons[k].Depth > 2.5)
					{
						num3 = 0.7f;
					}
					else if (this._balloons[k].Depth > 2f)
					{
						num3 = 0.8f;
					}
					else if ((double)this._balloons[k].Depth > 1.5)
					{
						num3 = 0.9f;
					}
					num3 *= 0.9f;
					value2 = new Color((int)((float)value2.R * num3), (int)((float)value2.G * num3), (int)((float)value2.B * num3), (int)((float)value2.A * num3));
					Vector2 vector = new Vector2(1f / this._balloons[k].Depth, 0.9f / this._balloons[k].Depth);
					Vector2 vector2 = this._balloons[k].Position;
					vector2 = (vector2 - value) * vector + value - Main.screenPosition;
					vector2.X = (vector2.X + 500f) % 4000f;
					if (vector2.X < 0f)
					{
						vector2.X += 4000f;
					}
					vector2.X -= 500f;
					if (rectangle.Contains((int)vector2.X, (int)vector2.Y))
					{
						spriteBatch.Draw(this._balloons[k].Texture, vector2, new Rectangle?(this._balloons[k].GetSourceRectangle()), value2 * this._opacity, 0f, Vector2.Zero, vector.X * 2f, SpriteEffects.None, 0f);
					}
				}
			}
		}

		// Token: 0x0600119F RID: 4511 RVA: 0x0040E980 File Offset: 0x0040CB80
		internal override void Activate(Vector2 position, params object[] args)
		{
			if (this._active)
			{
				this._leaving = false;
				this.GenerateBalloons(true);
				return;
			}
			this.GenerateBalloons(false);
			this._active = true;
			this._leaving = false;
		}

		// Token: 0x060011A0 RID: 4512 RVA: 0x0040E9B0 File Offset: 0x0040CBB0
		internal override void Deactivate(params object[] args)
		{
			this._leaving = true;
		}

		// Token: 0x060011A1 RID: 4513 RVA: 0x0040E9BC File Offset: 0x0040CBBC
		public override bool IsActive()
		{
			return this._active;
		}

		// Token: 0x060011A2 RID: 4514 RVA: 0x0040E9C4 File Offset: 0x0040CBC4
		public override void Reset()
		{
			this._active = false;
		}

		// Token: 0x04003218 RID: 12824
		public static bool MultipleSkyWorkaroundFix;

		// Token: 0x04003219 RID: 12825
		private bool _active;

		// Token: 0x0400321A RID: 12826
		private bool _leaving;

		// Token: 0x0400321B RID: 12827
		private float _opacity;

		// Token: 0x0400321C RID: 12828
		private Texture2D[] _textures;

		// Token: 0x0400321D RID: 12829
		private PartySky.Balloon[] _balloons;

		// Token: 0x0400321E RID: 12830
		private UnifiedRandom _random = new UnifiedRandom();

		// Token: 0x0400321F RID: 12831
		private int _balloonsDrawing;

		// Token: 0x020002B2 RID: 690
		private struct Balloon
		{
			// Token: 0x170001CC RID: 460
			// (get) Token: 0x0600177A RID: 6010 RVA: 0x0043C2A8 File Offset: 0x0043A4A8
			// (set) Token: 0x0600177B RID: 6011 RVA: 0x0043C2B0 File Offset: 0x0043A4B0
			public Texture2D Texture
			{
				get
				{
					return this._texture;
				}
				set
				{
					this._texture = value;
					this.FrameWidth = value.Width / 3;
					this.FrameHeight = value.Height / 3;
				}
			}

			// Token: 0x170001CD RID: 461
			// (get) Token: 0x0600177C RID: 6012 RVA: 0x0043C2D8 File Offset: 0x0043A4D8
			// (set) Token: 0x0600177D RID: 6013 RVA: 0x0043C2E0 File Offset: 0x0043A4E0
			public int Frame
			{
				get
				{
					return this._frameCounter;
				}
				set
				{
					this._frameCounter = value % 42;
				}
			}

			// Token: 0x0600177E RID: 6014 RVA: 0x0043C2EC File Offset: 0x0043A4EC
			public Rectangle GetSourceRectangle()
			{
				return new Rectangle(this.FrameWidth * this.Variant, this._frameCounter / 14 * this.FrameHeight, this.FrameWidth, this.FrameHeight);
			}

			// Token: 0x04003D21 RID: 15649
			private const int MAX_FRAMES_X = 3;

			// Token: 0x04003D22 RID: 15650
			private const int MAX_FRAMES_Y = 3;

			// Token: 0x04003D23 RID: 15651
			private const int FRAME_RATE = 14;

			// Token: 0x04003D24 RID: 15652
			public int Variant;

			// Token: 0x04003D25 RID: 15653
			private Texture2D _texture;

			// Token: 0x04003D26 RID: 15654
			public Vector2 Position;

			// Token: 0x04003D27 RID: 15655
			public float Depth;

			// Token: 0x04003D28 RID: 15656
			public int FrameHeight;

			// Token: 0x04003D29 RID: 15657
			public int FrameWidth;

			// Token: 0x04003D2A RID: 15658
			public float Speed;

			// Token: 0x04003D2B RID: 15659
			public bool Active;

			// Token: 0x04003D2C RID: 15660
			private int _frameCounter;
		}
	}
}

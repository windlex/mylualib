using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace Terraria.GameContent.Skies
{
	// Token: 0x02000166 RID: 358
	public class SlimeSky : CustomSky
	{
		// Token: 0x060011CE RID: 4558 RVA: 0x0040FAE4 File Offset: 0x0040DCE4
		public override void OnLoad()
		{
			this._textures = new Texture2D[4];
			for (int i = 0; i < 4; i++)
			{
				this._textures[i] = TextureManager.Load("Images/Misc/Sky_Slime_" + (i + 1));
			}
			this.GenerateSlimes();
		}

		// Token: 0x060011CF RID: 4559 RVA: 0x0040FB30 File Offset: 0x0040DD30
		private void GenerateSlimes()
		{
			this._slimes = new SlimeSky.Slime[Main.maxTilesY / 6];
			for (int i = 0; i < this._slimes.Length; i++)
			{
				int num = (int)((double)Main.screenPosition.Y * 0.7 - (double)Main.screenHeight);
				int minValue = (int)((double)num - Main.worldSurface * 16.0);
				this._slimes[i].Position = new Vector2((float)(this._random.Next(0, Main.maxTilesX) * 16), (float)this._random.Next(minValue, num));
				this._slimes[i].Speed = 5f + 3f * (float)this._random.NextDouble();
				this._slimes[i].Depth = (float)i / (float)this._slimes.Length * 1.75f + 1.6f;
				this._slimes[i].Texture = this._textures[this._random.Next(2)];
				if (this._random.Next(60) == 0)
				{
					this._slimes[i].Texture = this._textures[3];
					this._slimes[i].Speed = 6f + 3f * (float)this._random.NextDouble();
					SlimeSky.Slime[] expr_15C_cp_0_cp_0 = this._slimes;
					int expr_15C_cp_0_cp_1 = i;
					expr_15C_cp_0_cp_0[expr_15C_cp_0_cp_1].Depth = expr_15C_cp_0_cp_0[expr_15C_cp_0_cp_1].Depth + 0.5f;
				}
				else if (this._random.Next(30) == 0)
				{
					this._slimes[i].Texture = this._textures[2];
					this._slimes[i].Speed = 6f + 2f * (float)this._random.NextDouble();
				}
				this._slimes[i].Active = true;
			}
			this._slimesRemaining = this._slimes.Length;
		}

		// Token: 0x060011D0 RID: 4560 RVA: 0x0040FD28 File Offset: 0x0040DF28
		public override void Update(GameTime gameTime)
		{
			if (Main.gamePaused || !Main.hasFocus)
			{
				return;
			}
			for (int i = 0; i < this._slimes.Length; i++)
			{
				if (this._slimes[i].Active)
				{
					SlimeSky.Slime[] expr_38_cp_0 = this._slimes;
					int expr_38_cp_1 = i;
					int frame = expr_38_cp_0[expr_38_cp_1].Frame;
					expr_38_cp_0[expr_38_cp_1].Frame = frame + 1;
					SlimeSky.Slime[] expr_5D_cp_0_cp_0_cp_0 = this._slimes;
					int expr_5D_cp_0_cp_0_cp_1 = i;
					expr_5D_cp_0_cp_0_cp_0[expr_5D_cp_0_cp_0_cp_1].Position.Y = expr_5D_cp_0_cp_0_cp_0[expr_5D_cp_0_cp_0_cp_1].Position.Y + this._slimes[i].Speed;
					if ((double)this._slimes[i].Position.Y > Main.worldSurface * 16.0)
					{
						if (!this._isLeaving)
						{
							this._slimes[i].Depth = (float)i / (float)this._slimes.Length * 1.75f + 1.6f;
							this._slimes[i].Position = new Vector2((float)(this._random.Next(0, Main.maxTilesX) * 16), -100f);
							this._slimes[i].Texture = this._textures[this._random.Next(2)];
							this._slimes[i].Speed = 5f + 3f * (float)this._random.NextDouble();
							if (this._random.Next(60) == 0)
							{
								this._slimes[i].Texture = this._textures[3];
								this._slimes[i].Speed = 6f + 3f * (float)this._random.NextDouble();
								SlimeSky.Slime[] expr_1B0_cp_0_cp_0 = this._slimes;
								int expr_1B0_cp_0_cp_1 = i;
								expr_1B0_cp_0_cp_0[expr_1B0_cp_0_cp_1].Depth = expr_1B0_cp_0_cp_0[expr_1B0_cp_0_cp_1].Depth + 0.5f;
							}
							else if (this._random.Next(30) == 0)
							{
								this._slimes[i].Texture = this._textures[2];
								this._slimes[i].Speed = 6f + 2f * (float)this._random.NextDouble();
							}
						}
						else
						{
							this._slimes[i].Active = false;
							this._slimesRemaining--;
						}
					}
				}
			}
			if (this._slimesRemaining == 0)
			{
				this._isActive = false;
			}
		}

		// Token: 0x060011D1 RID: 4561 RVA: 0x0040FF84 File Offset: 0x0040E184
		public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			if (Main.screenPosition.Y > 10000f || Main.gameMenu)
			{
				return;
			}
			int num = -1;
			int num2 = 0;
			for (int i = 0; i < this._slimes.Length; i++)
			{
				float depth = this._slimes[i].Depth;
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
			Vector2 value = Main.screenPosition + new Vector2((float)(Main.screenWidth >> 1), (float)(Main.screenHeight >> 1));
			Rectangle rectangle = new Rectangle(-1000, -1000, 4000, 4000);
			for (int j = num; j < num2; j++)
			{
				if (this._slimes[j].Active)
				{
					Color color = new Color(Main.bgColor.ToVector4() * 0.9f + new Vector4(0.1f)) * 0.8f;
					float num3 = 1f;
					if (this._slimes[j].Depth > 3f)
					{
						num3 = 0.6f;
					}
					else if ((double)this._slimes[j].Depth > 2.5)
					{
						num3 = 0.7f;
					}
					else if (this._slimes[j].Depth > 2f)
					{
						num3 = 0.8f;
					}
					else if ((double)this._slimes[j].Depth > 1.5)
					{
						num3 = 0.9f;
					}
					num3 *= 0.8f;
					color = new Color((int)((float)color.R * num3), (int)((float)color.G * num3), (int)((float)color.B * num3), (int)((float)color.A * num3));
					Vector2 vector = new Vector2(1f / this._slimes[j].Depth, 0.9f / this._slimes[j].Depth);
					Vector2 vector2 = this._slimes[j].Position;
					vector2 = (vector2 - value) * vector + value - Main.screenPosition;
					vector2.X = (vector2.X + 500f) % 4000f;
					if (vector2.X < 0f)
					{
						vector2.X += 4000f;
					}
					vector2.X -= 500f;
					if (rectangle.Contains((int)vector2.X, (int)vector2.Y))
					{
						spriteBatch.Draw(this._slimes[j].Texture, vector2, new Rectangle?(this._slimes[j].GetSourceRectangle()), color, 0f, Vector2.Zero, vector.X * 2f, SpriteEffects.None, 0f);
					}
				}
			}
		}

		// Token: 0x060011D2 RID: 4562 RVA: 0x00410284 File Offset: 0x0040E484
		internal override void Activate(Vector2 position, params object[] args)
		{
			this.GenerateSlimes();
			this._isActive = true;
			this._isLeaving = false;
		}

		// Token: 0x060011D3 RID: 4563 RVA: 0x0041029C File Offset: 0x0040E49C
		internal override void Deactivate(params object[] args)
		{
			this._isLeaving = true;
		}

		// Token: 0x060011D4 RID: 4564 RVA: 0x004102A8 File Offset: 0x0040E4A8
		public override void Reset()
		{
			this._isActive = false;
		}

		// Token: 0x060011D5 RID: 4565 RVA: 0x004102B4 File Offset: 0x0040E4B4
		public override bool IsActive()
		{
			return this._isActive;
		}

		// Token: 0x04003237 RID: 12855
		private Texture2D[] _textures;

		// Token: 0x04003238 RID: 12856
		private SlimeSky.Slime[] _slimes;

		// Token: 0x04003239 RID: 12857
		private UnifiedRandom _random = new UnifiedRandom();

		// Token: 0x0400323A RID: 12858
		private int _slimesRemaining;

		// Token: 0x0400323B RID: 12859
		private bool _isActive;

		// Token: 0x0400323C RID: 12860
		private bool _isLeaving;

		// Token: 0x020002B5 RID: 693
		private struct Slime
		{
			// Token: 0x170001CE RID: 462
			// (get) Token: 0x0600177F RID: 6015 RVA: 0x0043C31C File Offset: 0x0043A51C
			// (set) Token: 0x06001780 RID: 6016 RVA: 0x0043C324 File Offset: 0x0043A524
			public Texture2D Texture
			{
				get
				{
					return this._texture;
				}
				set
				{
					this._texture = value;
					this.FrameWidth = value.Width;
					this.FrameHeight = value.Height / 4;
				}
			}

			// Token: 0x170001CF RID: 463
			// (get) Token: 0x06001781 RID: 6017 RVA: 0x0043C348 File Offset: 0x0043A548
			// (set) Token: 0x06001782 RID: 6018 RVA: 0x0043C350 File Offset: 0x0043A550
			public int Frame
			{
				get
				{
					return this._frame;
				}
				set
				{
					this._frame = value % 24;
				}
			}

			// Token: 0x06001783 RID: 6019 RVA: 0x0043C35C File Offset: 0x0043A55C
			public Rectangle GetSourceRectangle()
			{
				return new Rectangle(0, this._frame / 6 * this.FrameHeight, this.FrameWidth, this.FrameHeight);
			}

			// Token: 0x04003D36 RID: 15670
			private const int MAX_FRAMES = 4;

			// Token: 0x04003D37 RID: 15671
			private const int FRAME_RATE = 6;

			// Token: 0x04003D38 RID: 15672
			private Texture2D _texture;

			// Token: 0x04003D39 RID: 15673
			public Vector2 Position;

			// Token: 0x04003D3A RID: 15674
			public float Depth;

			// Token: 0x04003D3B RID: 15675
			public int FrameHeight;

			// Token: 0x04003D3C RID: 15676
			public int FrameWidth;

			// Token: 0x04003D3D RID: 15677
			public float Speed;

			// Token: 0x04003D3E RID: 15678
			public bool Active;

			// Token: 0x04003D3F RID: 15679
			private int _frame;
		}
	}
}

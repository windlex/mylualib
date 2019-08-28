using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace Terraria.GameContent.Skies
{
	// Token: 0x02000168 RID: 360
	public class MartianSky : CustomSky
	{
		// Token: 0x060011E5 RID: 4581 RVA: 0x0040FDA4 File Offset: 0x0040DFA4
		internal override void Activate(Vector2 position, params object[] args)
		{
			this._activeUfos = 0;
			this.GenerateUfos();
			Array.Sort<MartianSky.Ufo>(this._ufos, (Comparison<MartianSky.Ufo>)((ufo1, ufo2) => ufo2.Depth.CompareTo(ufo1.Depth)));
			this._active = true;
			this._leaving = false;
		}

		// Token: 0x060011E6 RID: 4582 RVA: 0x0040FDF6 File Offset: 0x0040DFF6
		internal override void Deactivate(params object[] args)
		{
			this._leaving = true;
		}

		// Token: 0x060011E3 RID: 4579 RVA: 0x0040F9DC File Offset: 0x0040DBDC
		public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			if (Main.screenPosition.Y > 10000f)
			{
				return;
			}
			int num = -1;
			int num2 = 0;
			for (int i = 0; i < this._ufos.Length; i++)
			{
				float depth = this._ufos[i].Depth;
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
			Color value = new Color(Main.bgColor.ToVector4() * 0.9f + new Vector4(0.1f));
			Vector2 value2 = Main.screenPosition + new Vector2((float)(Main.screenWidth >> 1), (float)(Main.screenHeight >> 1));
			Rectangle rectangle = new Rectangle(-1000, -1000, 4000, 4000);
			for (int j = num; j < num2; j++)
			{
				Vector2 vector = new Vector2(1f / this._ufos[j].Depth, 0.9f / this._ufos[j].Depth);
				Vector2 vector2 = this._ufos[j].Position;
				vector2 = (vector2 - value2) * vector + value2 - Main.screenPosition;
				if (this._ufos[j].IsActive && rectangle.Contains((int)vector2.X, (int)vector2.Y))
				{
					spriteBatch.Draw(this._ufos[j].Texture, vector2, new Rectangle?(this._ufos[j].GetSourceRectangle()), value * this._ufos[j].Opacity, this._ufos[j].Rotation, Vector2.Zero, vector.X * 5f * this._ufos[j].Scale, SpriteEffects.None, 0f);
					if (this._ufos[j].GlowTexture != null)
					{
						spriteBatch.Draw(this._ufos[j].GlowTexture, vector2, new Rectangle?(this._ufos[j].GetSourceRectangle()), Color.White * this._ufos[j].Opacity, this._ufos[j].Rotation, Vector2.Zero, vector.X * 5f * this._ufos[j].Scale, SpriteEffects.None, 0f);
					}
				}
			}
		}

		// Token: 0x060011E4 RID: 4580 RVA: 0x0040FC84 File Offset: 0x0040DE84
		private void GenerateUfos()
		{
			float num = (float)Main.maxTilesX / 4200f;
			this._maxUfos = (int)(256f * num);
			this._ufos = new MartianSky.Ufo[this._maxUfos];
			int num2 = this._maxUfos >> 4;
			for (int i = 0; i < num2; i++)
			{
				float arg_3E_0 = (float)i / (float)num2;
				this._ufos[i] = new MartianSky.Ufo(Main.extraTexture[5], (float)Main.rand.NextDouble() * 4f + 6.6f);
				this._ufos[i].GlowTexture = Main.glowMaskTexture[90];
			}
			for (int j = num2; j < this._ufos.Length; j++)
			{
				float arg_A3_0 = (float)(j - num2) / (float)(this._ufos.Length - num2);
				this._ufos[j] = new MartianSky.Ufo(Main.extraTexture[6], (float)Main.rand.NextDouble() * 5f + 1.6f);
				this._ufos[j].Scale = 0.5f;
				this._ufos[j].GlowTexture = Main.glowMaskTexture[91];
			}
		}

		// Token: 0x060011E7 RID: 4583 RVA: 0x0040FDFF File Offset: 0x0040DFFF
		public override bool IsActive()
		{
			return this._active;
		}

		// Token: 0x060011E8 RID: 4584 RVA: 0x0040FE07 File Offset: 0x0040E007
		public override void Reset()
		{
			this._active = false;
		}

		// Token: 0x060011E2 RID: 4578 RVA: 0x0040F8F8 File Offset: 0x0040DAF8
		public override void Update(GameTime gameTime)
		{
			if (Main.gamePaused || !Main.hasFocus)
			{
				return;
			}
			int num = this._activeUfos;
			for (int i = 0; i < this._ufos.Length; i++)
			{
				MartianSky.Ufo ufo = this._ufos[i];
				if (ufo.IsActive)
				{
					int frame = ufo.Frame;
					ufo.Frame = frame + 1;
					if (!ufo.Update())
					{
						if (!this._leaving)
						{
							ufo.AssignNewBehavior();
						}
						else
						{
							ufo.IsActive = false;
							num--;
						}
					}
				}
				this._ufos[i] = ufo;
			}
			if (!this._leaving && num != this._maxUfos)
			{
				this._ufos[num].IsActive = true;
				this._ufos[num++].AssignNewBehavior();
			}
			this._active = (!this._leaving || num != 0);
			this._activeUfos = num;
		}

		// Token: 0x04003247 RID: 12871
		private bool _active;

		// Token: 0x04003249 RID: 12873
		private int _activeUfos;

		// Token: 0x04003248 RID: 12872
		private bool _leaving;

		// Token: 0x04003246 RID: 12870
		private int _maxUfos;

		// Token: 0x04003245 RID: 12869
		private UnifiedRandom _random = new UnifiedRandom();

		// Token: 0x04003244 RID: 12868
		private MartianSky.Ufo[] _ufos;



		// Token: 0x020002B9 RID: 697
		private class HoverBehavior : MartianSky.IUfoController
		{
			// Token: 0x0600178A RID: 6026 RVA: 0x0043AA5C File Offset: 0x00438C5C
			public override void InitializeUfo(ref MartianSky.Ufo ufo)
			{
				ufo.Position.X = (float)(MartianSky.Ufo.Random.NextDouble() * (double)(Main.maxTilesX << 4));
				ufo.Position.Y = (float)(MartianSky.Ufo.Random.NextDouble() * 5000.0);
				ufo.Opacity = 0f;
				ufo.Rotation = 0f;
				this._ticks = 0;
				this._maxTicks = MartianSky.Ufo.Random.Next(120, 240);
			}

			// Token: 0x0600178B RID: 6027 RVA: 0x0043AADC File Offset: 0x00438CDC
			public override bool Update(ref MartianSky.Ufo ufo)
			{
				if (this._ticks < 10)
				{
					ufo.Opacity += 0.1f;
				}
				else if (this._ticks > this._maxTicks - 10)
				{
					ufo.Opacity -= 0.1f;
				}
				if (this._ticks == this._maxTicks)
				{
					return false;
				}
				this._ticks++;
				return true;
			}

			// Token: 0x04003D4A RID: 15690
			private int _maxTicks;

			// Token: 0x04003D49 RID: 15689
			private int _ticks;
		}

		// Token: 0x020002B7 RID: 695
		private abstract class IUfoController
		{
			// Token: 0x06001784 RID: 6020
			public abstract void InitializeUfo(ref MartianSky.Ufo ufo);

			// Token: 0x06001785 RID: 6021
			public abstract bool Update(ref MartianSky.Ufo ufo);
		}

		// Token: 0x020002BA RID: 698
		private struct Ufo
		{
			// Token: 0x06001793 RID: 6035 RVA: 0x0043AB9C File Offset: 0x00438D9C
			public Ufo(Texture2D texture, float depth = 1f)
			{
				this._frame = 0;
				this.Position = Vector2.Zero;
				this._texture = texture;
				this.Depth = depth;
				this.Scale = 1f;
				this.FrameWidth = texture.Width;
				this.FrameHeight = texture.Height / 3;
				this.GlowTexture = null;
				this.Opacity = 0f;
				this.Rotation = 0f;
				this.IsActive = false;
				this._controller = null;
			}

			// Token: 0x06001796 RID: 6038 RVA: 0x0043AC4C File Offset: 0x00438E4C
			public void AssignNewBehavior()
			{
				int num = MartianSky.Ufo.Random.Next(2);
				if (num == 0)
				{
					this.Controller = new MartianSky.ZipBehavior();
					return;
				}
				if (num != 1)
				{
					return;
				}
				this.Controller = new MartianSky.HoverBehavior();
			}

			// Token: 0x06001794 RID: 6036 RVA: 0x0043AC19 File Offset: 0x00438E19
			public Rectangle GetSourceRectangle()
			{
				return new Rectangle(0, this._frame / 4 * this.FrameHeight, this.FrameWidth, this.FrameHeight);
			}

			// Token: 0x06001795 RID: 6037 RVA: 0x0043AC3C File Offset: 0x00438E3C
			public bool Update()
			{
				return this.Controller.Update(ref this);
			}

			// Token: 0x170001D2 RID: 466
			public MartianSky.IUfoController Controller
			{
				// Token: 0x06001791 RID: 6033 RVA: 0x0043AB82 File Offset: 0x00438D82
				get
				{
					return this._controller;
				}
				// Token: 0x06001792 RID: 6034 RVA: 0x0043AB8A File Offset: 0x00438D8A
				set
				{
					this._controller = value;
					value.InitializeUfo(ref this);
				}
			}

			// Token: 0x170001D0 RID: 464
			public int Frame
			{
				// Token: 0x0600178D RID: 6029 RVA: 0x0043AB43 File Offset: 0x00438D43
				get
				{
					return this._frame;
				}
				// Token: 0x0600178E RID: 6030 RVA: 0x0043AB4B File Offset: 0x00438D4B
				set
				{
					this._frame = value % 12;
				}
			}

			// Token: 0x170001D1 RID: 465
			public Texture2D Texture
			{
				// Token: 0x0600178F RID: 6031 RVA: 0x0043AB57 File Offset: 0x00438D57
				get
				{
					return this._texture;
				}
				// Token: 0x06001790 RID: 6032 RVA: 0x0043AB5F File Offset: 0x00438D5F
				set
				{
					this._texture = value;
					this.FrameWidth = value.Width;
					this.FrameHeight = value.Height / 3;
				}
			}

			// Token: 0x04003D4B RID: 15691
			private const int MAX_FRAMES = 3;

			// Token: 0x04003D4C RID: 15692
			private const int FRAME_RATE = 4;

			// Token: 0x04003D4D RID: 15693
			public static UnifiedRandom Random = new UnifiedRandom();

			// Token: 0x04003D4E RID: 15694
			private int _frame;

			// Token: 0x04003D4F RID: 15695
			private Texture2D _texture;

			// Token: 0x04003D50 RID: 15696
			private MartianSky.IUfoController _controller;

			// Token: 0x04003D51 RID: 15697
			public Texture2D GlowTexture;

			// Token: 0x04003D52 RID: 15698
			public Vector2 Position;

			// Token: 0x04003D53 RID: 15699
			public int FrameHeight;

			// Token: 0x04003D54 RID: 15700
			public int FrameWidth;

			// Token: 0x04003D55 RID: 15701
			public float Depth;

			// Token: 0x04003D56 RID: 15702
			public float Scale;

			// Token: 0x04003D57 RID: 15703
			public float Opacity;

			// Token: 0x04003D58 RID: 15704
			public bool IsActive;

			// Token: 0x04003D59 RID: 15705
			public float Rotation;
		}

		// Token: 0x020002B8 RID: 696
		private class ZipBehavior : MartianSky.IUfoController
		{
			// Token: 0x06001787 RID: 6023 RVA: 0x0043A8E0 File Offset: 0x00438AE0
			public override void InitializeUfo(ref MartianSky.Ufo ufo)
			{
				ufo.Position.X = (float)(MartianSky.Ufo.Random.NextDouble() * (double)(Main.maxTilesX << 4));
				ufo.Position.Y = (float)(MartianSky.Ufo.Random.NextDouble() * 5000.0);
				ufo.Opacity = 0f;
				float num = (float)MartianSky.Ufo.Random.NextDouble() * 5f + 10f;
				double num2 = MartianSky.Ufo.Random.NextDouble() * 0.60000002384185791 - 0.30000001192092896;
				ufo.Rotation = (float)num2;
				if (MartianSky.Ufo.Random.Next(2) == 0)
				{
					num2 += 3.1415927410125732;
				}
				this._speed = new Vector2((float)Math.Cos(num2) * num, (float)Math.Sin(num2) * num);
				this._ticks = 0;
				this._maxTicks = MartianSky.Ufo.Random.Next(400, 500);
			}

			// Token: 0x06001788 RID: 6024 RVA: 0x0043A9D0 File Offset: 0x00438BD0
			public override bool Update(ref MartianSky.Ufo ufo)
			{
				if (this._ticks < 10)
				{
					ufo.Opacity += 0.1f;
				}
				else if (this._ticks > this._maxTicks - 10)
				{
					ufo.Opacity -= 0.1f;
				}
				ufo.Position += this._speed;
				if (this._ticks == this._maxTicks)
				{
					return false;
				}
				this._ticks++;
				return true;
			}

			// Token: 0x04003D48 RID: 15688
			private int _maxTicks;

			// Token: 0x04003D46 RID: 15686
			private Vector2 _speed;

			// Token: 0x04003D47 RID: 15687
			private int _ticks;
		}
	}
}

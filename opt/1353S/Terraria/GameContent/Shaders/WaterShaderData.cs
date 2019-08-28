using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameContent.Liquid;
using Terraria.Graphics;
using Terraria.Graphics.Shaders;
using Terraria.ID;

namespace Terraria.GameContent.Shaders
{
	// Token: 0x0200016D RID: 365
	public class WaterShaderData : ScreenShaderData
	{
		// Token: 0x1400002D RID: 45
		// (add) Token: 0x060011FB RID: 4603 RVA: 0x00411814 File Offset: 0x0040FA14
		// (remove) Token: 0x060011FC RID: 4604 RVA: 0x0041184C File Offset: 0x0040FA4C
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event Action<TileBatch> OnWaveDraw;

		// Token: 0x060011FD RID: 4605 RVA: 0x00411884 File Offset: 0x0040FA84
		public WaterShaderData(string passName) : base(passName)
		{
			Main.OnRenderTargetsInitialized += new ResolutionChangeEvent(this.InitRenderTargets);
			Main.OnRenderTargetsReleased += new Action(this.ReleaseRenderTargets);
			this._rippleShapeTexture = Main.instance.OurLoad<Texture2D>("Images/Misc/Ripples");
			Main.OnPreDraw += new Action<GameTime>(this.PreDraw);
		}

		// Token: 0x060011FE RID: 4606 RVA: 0x00411940 File Offset: 0x0040FB40
		public override void Update(GameTime gameTime)
		{
			this._useViscosityFilter = (Main.WaveQuality >= 3);
			this._useProjectileWaves = (Main.WaveQuality >= 3);
			this._usePlayerWaves = (Main.WaveQuality >= 2);
			this._useRippleWaves = (Main.WaveQuality >= 2);
			this._useCustomWaves = (Main.WaveQuality >= 2);
			if (Main.gamePaused || !Main.hasFocus)
			{
				return;
			}
			this._progress += (float)gameTime.ElapsedGameTime.TotalSeconds * base.Intensity * 0.75f;
			this._progress %= 86400f;
			if (this._useProjectileWaves || this._useRippleWaves || this._useCustomWaves || this._usePlayerWaves)
			{
				this._queuedSteps++;
			}
			base.Update(gameTime);
		}

		// Token: 0x060011FF RID: 4607 RVA: 0x00411A24 File Offset: 0x0040FC24
		private void StepLiquids()
		{
			this._isWaveBufferDirty = true;
			Vector2 vector = Main.drawToScreen ? Vector2.Zero : new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
			Vector2 vector2 = vector - Main.screenPosition;
			TileBatch tileBatch = Main.tileBatch;
			GraphicsDevice graphicsDevice = Main.instance.GraphicsDevice;
			graphicsDevice.SetRenderTarget(this._distortionTarget);
			if (this._clearNextFrame)
			{
				graphicsDevice.Clear(new Color(0.5f, 0.5f, 0f, 1f));
				this._clearNextFrame = false;
			}
			this.DrawWaves();
			graphicsDevice.SetRenderTarget(this._distortionTargetSwap);
			graphicsDevice.Clear(new Color(0.5f, 0.5f, 0.5f, 1f));
			Main.tileBatch.Begin();
			vector2 *= 0.25f;
			vector2.X = (float)Math.Floor((double)vector2.X);
			vector2.Y = (float)Math.Floor((double)vector2.Y);
			Vector2 vector3 = vector2 - this._lastDistortionDrawOffset;
			this._lastDistortionDrawOffset = vector2;
			tileBatch.Draw(this._distortionTarget, new Vector4(vector3.X, vector3.Y, (float)this._distortionTarget.Width, (float)this._distortionTarget.Height), new VertexColors(Color.White));
			GameShaders.Misc["WaterProcessor"].Apply(new DrawData?(new DrawData(this._distortionTarget, Vector2.Zero, Color.White)));
			tileBatch.End();
			RenderTarget2D distortionTarget = this._distortionTarget;
			this._distortionTarget = this._distortionTargetSwap;
			this._distortionTargetSwap = distortionTarget;
			if (this._useViscosityFilter)
			{
				LiquidRenderer.Instance.SetWaveMaskData(ref this._viscosityMaskChain[this._activeViscosityMask]);
				tileBatch.Begin();
				Rectangle cachedDrawArea = LiquidRenderer.Instance.GetCachedDrawArea();
				Rectangle value = new Rectangle(0, 0, cachedDrawArea.Height, cachedDrawArea.Width);
				Vector4 vector4 = new Vector4((float)(cachedDrawArea.X + cachedDrawArea.Width), (float)cachedDrawArea.Y, (float)cachedDrawArea.Height, (float)cachedDrawArea.Width);
				vector4 *= 16f;
				vector4.X -= vector.X;
				vector4.Y -= vector.Y;
				vector4 *= 0.25f;
				vector4.X += vector2.X;
				vector4.Y += vector2.Y;
				graphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
				tileBatch.Draw(this._viscosityMaskChain[this._activeViscosityMask], vector4, new Rectangle?(value), new VertexColors(Color.White), Vector2.Zero, SpriteEffects.FlipHorizontally, 1.57079637f);
				tileBatch.End();
				this._activeViscosityMask++;
				this._activeViscosityMask %= this._viscosityMaskChain.Length;
			}
			graphicsDevice.SetRenderTarget(null);
		}

		// Token: 0x06001200 RID: 4608 RVA: 0x00411D14 File Offset: 0x0040FF14
		private void DrawWaves()
		{
			Vector2 screenPosition = Main.screenPosition;
			Vector2 value = Main.drawToScreen ? Vector2.Zero : new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
			Vector2 value2 = -this._lastDistortionDrawOffset / 0.25f + value;
			TileBatch tileBatch = Main.tileBatch;
			GraphicsDevice arg_52_0 = Main.instance.GraphicsDevice;
			Vector2 dimensions = new Vector2((float)Main.screenWidth, (float)Main.screenHeight);
			Vector2 value3 = new Vector2(16f, 16f);
			tileBatch.Begin();
			GameShaders.Misc["WaterDistortionObject"].Apply(null);
			if (this._useNPCWaves)
			{
				for (int i = 0; i < 200; i++)
				{
					if (Main.npc[i] != null && Main.npc[i].active && (Main.npc[i].wet || Main.npc[i].wetCount != 0) && Collision.CheckAABBvAABBCollision(screenPosition, dimensions, Main.npc[i].position - value3, Main.npc[i].Size + value3))
					{
						NPC nPC = Main.npc[i];
						Vector2 vector = nPC.Center - value2;
						Vector2 vector2 = nPC.velocity.RotatedBy((double)(-(double)nPC.rotation), default(Vector2)) / new Vector2((float)nPC.height, (float)nPC.width);
						float num = vector2.LengthSquared();
						num = num * 0.3f + 0.7f * num * (1024f / (float)(nPC.height * nPC.width));
						num = Math.Min(num, 0.08f);
						num += (nPC.velocity - nPC.oldVelocity).Length() * 0.5f;
						vector2.Normalize();
						Vector2 velocity = nPC.velocity;
						velocity.Normalize();
						vector -= velocity * 10f;
						if (!this._useViscosityFilter && (nPC.honeyWet || nPC.lavaWet))
						{
							num *= 0.3f;
						}
						if (nPC.wet)
						{
							tileBatch.Draw(Main.magicPixel, new Vector4(vector.X, vector.Y, (float)nPC.width * 2f, (float)nPC.height * 2f) * 0.25f, null, new VertexColors(new Color(vector2.X * 0.5f + 0.5f, vector2.Y * 0.5f + 0.5f, 0.5f * num)), new Vector2((float)Main.magicPixel.Width / 2f, (float)Main.magicPixel.Height / 2f), SpriteEffects.None, nPC.rotation);
						}
						if (nPC.wetCount != 0)
						{
							num = nPC.velocity.Length();
							num = 0.195f * (float)Math.Sqrt((double)num);
							float scaleFactor = 5f;
							if (!nPC.wet)
							{
								scaleFactor = -20f;
							}
							this.QueueRipple(nPC.Center + velocity * scaleFactor, new Color(0.5f, (nPC.wet ? num : (-num)) * 0.5f + 0.5f, 0f, 1f) * 0.5f, new Vector2((float)nPC.width, (float)nPC.height * ((float)nPC.wetCount / 9f)) * MathHelper.Clamp(num * 10f, 0f, 1f), RippleShape.Circle, 0f);
						}
					}
				}
			}
			if (this._usePlayerWaves)
			{
				for (int j = 0; j < 255; j++)
				{
					if (Main.player[j] != null && Main.player[j].active && (Main.player[j].wet || Main.player[j].wetCount != 0) && Collision.CheckAABBvAABBCollision(screenPosition, dimensions, Main.player[j].position - value3, Main.player[j].Size + value3))
					{
						Player player = Main.player[j];
						Vector2 vector3 = player.Center - value2;
						float num2 = player.velocity.Length();
						num2 = 0.05f * (float)Math.Sqrt((double)num2);
						Vector2 velocity2 = player.velocity;
						velocity2.Normalize();
						vector3 -= velocity2 * 10f;
						if (!this._useViscosityFilter && (player.honeyWet || player.lavaWet))
						{
							num2 *= 0.3f;
						}
						if (player.wet)
						{
							tileBatch.Draw(Main.magicPixel, new Vector4(vector3.X - (float)player.width * 2f * 0.5f, vector3.Y - (float)player.height * 2f * 0.5f, (float)player.width * 2f, (float)player.height * 2f) * 0.25f, new VertexColors(new Color(velocity2.X * 0.5f + 0.5f, velocity2.Y * 0.5f + 0.5f, 0.5f * num2)));
						}
						if (player.wetCount != 0)
						{
							float scaleFactor2 = 5f;
							if (!player.wet)
							{
								scaleFactor2 = -20f;
							}
							num2 *= 3f;
							this.QueueRipple(player.Center + velocity2 * scaleFactor2, player.wet ? num2 : (-num2), new Vector2((float)player.width, (float)player.height * ((float)player.wetCount / 9f)) * MathHelper.Clamp(num2 * 10f, 0f, 1f), RippleShape.Circle, 0f);
						}
					}
				}
			}
			if (this._useProjectileWaves)
			{
				for (int k = 0; k < 1000; k++)
				{
					Projectile projectile = Main.projectile[k];
					if (projectile.wet && !projectile.lavaWet)
					{
						bool arg_686_0 = !projectile.honeyWet;
					}
					bool flag = projectile.lavaWet;
					bool flag2 = projectile.honeyWet;
					bool flag3 = projectile.wet;
					if (projectile.ignoreWater)
					{
						flag3 = true;
					}
					if (((projectile != null && projectile.active && ProjectileID.Sets.CanDistortWater[projectile.type]) & flag3) && !ProjectileID.Sets.NoLiquidDistortion[projectile.type] && Collision.CheckAABBvAABBCollision(screenPosition, dimensions, projectile.position - value3, projectile.Size + value3))
					{
						if (projectile.ignoreWater)
						{
							bool arg_756_0 = Collision.LavaCollision(projectile.position, projectile.width, projectile.height);
							flag = Collision.WetCollision(projectile.position, projectile.width, projectile.height);
							flag2 = Collision.honey;
							flag3 = (arg_756_0 | flag | flag2);
							if (!flag3)
							{
								goto IL_86A;
							}
						}
						Vector2 vector4 = projectile.Center - value2;
						float num3 = projectile.velocity.Length();
						num3 = 2f * (float)Math.Sqrt((double)(0.05f * num3));
						Vector2 velocity3 = projectile.velocity;
						velocity3.Normalize();
						if (!this._useViscosityFilter && (flag2 | flag))
						{
							num3 *= 0.3f;
						}
						float num4 = Math.Max(12f, (float)projectile.width * 0.75f);
						float num5 = Math.Max(12f, (float)projectile.height * 0.75f);
						tileBatch.Draw(Main.magicPixel, new Vector4(vector4.X - num4 * 0.5f, vector4.Y - num5 * 0.5f, num4, num5) * 0.25f, new VertexColors(new Color(velocity3.X * 0.5f + 0.5f, velocity3.Y * 0.5f + 0.5f, num3 * 0.5f)));
					}
					IL_86A:;
				}
			}
			tileBatch.End();
			if (this._useRippleWaves)
			{
				tileBatch.Begin();
				for (int l = 0; l < this._rippleQueueCount; l++)
				{
					Vector2 vector5 = this._rippleQueue[l].Position - value2;
					Vector2 size = this._rippleQueue[l].Size;
					Rectangle sourceRectangle = this._rippleQueue[l].SourceRectangle;
					Texture2D rippleShapeTexture = this._rippleShapeTexture;
					tileBatch.Draw(rippleShapeTexture, new Vector4(vector5.X, vector5.Y, size.X, size.Y) * 0.25f, new Rectangle?(sourceRectangle), new VertexColors(this._rippleQueue[l].WaveData), new Vector2((float)(sourceRectangle.Width / 2), (float)(sourceRectangle.Height / 2)), SpriteEffects.None, this._rippleQueue[l].Rotation);
				}
				tileBatch.End();
			}
			this._rippleQueueCount = 0;
			if (this._useCustomWaves && this.OnWaveDraw != null)
			{
				tileBatch.Begin();
				this.OnWaveDraw(tileBatch);
				tileBatch.End();
			}
		}

		// Token: 0x06001201 RID: 4609 RVA: 0x004126CC File Offset: 0x004108CC
		private void PreDraw(GameTime gameTime)
		{
			this.ValidateRenderTargets();
			if (!this._usingRenderTargets || !Main.IsGraphicsDeviceAvailable)
			{
				return;
			}
			if (this._useProjectileWaves || this._useRippleWaves || this._useCustomWaves || this._usePlayerWaves)
			{
				for (int i = 0; i < Math.Min(this._queuedSteps, 2); i++)
				{
					this.StepLiquids();
				}
			}
			else if (this._isWaveBufferDirty || this._clearNextFrame)
			{
				GraphicsDevice expr_6F = Main.instance.GraphicsDevice;
				expr_6F.SetRenderTarget(this._distortionTarget);
				expr_6F.Clear(new Color(0.5f, 0.5f, 0f, 1f));
				this._clearNextFrame = false;
				this._isWaveBufferDirty = false;
				expr_6F.SetRenderTarget(null);
			}
			this._queuedSteps = 0;
		}

		// Token: 0x06001202 RID: 4610 RVA: 0x00412790 File Offset: 0x00410990
		public override void Apply()
		{
			if (!this._usingRenderTargets || !Main.IsGraphicsDeviceAvailable)
			{
				return;
			}
			base.UseProgress(this._progress);
			Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
			Vector2 value = new Vector2((float)Main.screenWidth, (float)Main.screenHeight) * 0.5f * (Vector2.One - Vector2.One / Main.GameViewMatrix.Zoom);
			Vector2 value2 = (Main.drawToScreen ? Vector2.Zero : new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange)) - Main.screenPosition - value;
			base.UseImage(this._distortionTarget, 1, null);
			base.UseImage(Main.waterTarget, 2, SamplerState.PointClamp);
			base.UseTargetPosition(Main.screenPosition - Main.sceneWaterPos + new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange) + value);
			base.UseImageOffset(-(value2 * 0.25f - this._lastDistortionDrawOffset) / new Vector2((float)this._distortionTarget.Width, (float)this._distortionTarget.Height));
			base.Apply();
		}

		// Token: 0x06001203 RID: 4611 RVA: 0x004128E0 File Offset: 0x00410AE0
		private void ValidateRenderTargets()
		{
			int backBufferWidth = Main.instance.GraphicsDevice.PresentationParameters.BackBufferWidth;
			int backBufferHeight = Main.instance.GraphicsDevice.PresentationParameters.BackBufferHeight;
			bool flag = !Main.drawToScreen;
			if (this._usingRenderTargets && !flag)
			{
				this.ReleaseRenderTargets();
				return;
			}
			if (!this._usingRenderTargets & flag)
			{
				this.InitRenderTargets(backBufferWidth, backBufferHeight);
				return;
			}
			if ((this._usingRenderTargets & flag) && (this._distortionTarget.IsContentLost || this._distortionTargetSwap.IsContentLost))
			{
				this._clearNextFrame = true;
			}
		}

		// Token: 0x06001204 RID: 4612 RVA: 0x00412974 File Offset: 0x00410B74
		private void InitRenderTargets(int width, int height)
		{
			this._lastScreenWidth = width;
			this._lastScreenHeight = height;
			width = (int)((float)width * 0.25f);
			height = (int)((float)height * 0.25f);
			try
			{
				this._distortionTarget = new RenderTarget2D(Main.instance.GraphicsDevice, width, height, false, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.PreserveContents);
				this._distortionTargetSwap = new RenderTarget2D(Main.instance.GraphicsDevice, width, height, false, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.PreserveContents);
				this._usingRenderTargets = true;
				this._clearNextFrame = true;
			}
			catch (Exception ex)
			{
				Lighting.lightMode = 2;
				this._usingRenderTargets = false;
				Console.WriteLine("Failed to create water distortion render targets. " + ex.ToString());
			}
		}

		// Token: 0x06001205 RID: 4613 RVA: 0x00412A24 File Offset: 0x00410C24
		private void ReleaseRenderTargets()
		{
			try
			{
				if (this._distortionTarget != null)
				{
					this._distortionTarget.Dispose();
				}
				if (this._distortionTargetSwap != null)
				{
					this._distortionTargetSwap.Dispose();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error disposing of water distortion render targets. " + ex.ToString());
			}
			this._distortionTarget = null;
			this._distortionTargetSwap = null;
			this._usingRenderTargets = false;
		}

		// Token: 0x06001206 RID: 4614 RVA: 0x00412A98 File Offset: 0x00410C98
		public void QueueRipple(Vector2 position, float strength = 1f, RippleShape shape = RippleShape.Square, float rotation = 0f)
		{
			float g = strength * 0.5f + 0.5f;
			float scale = Math.Min(Math.Abs(strength), 1f);
			this.QueueRipple(position, new Color(0.5f, g, 0f, 1f) * scale, new Vector2(4f * Math.Max(Math.Abs(strength), 1f)), shape, rotation);
		}

		// Token: 0x06001207 RID: 4615 RVA: 0x00412B04 File Offset: 0x00410D04
		public void QueueRipple(Vector2 position, float strength, Vector2 size, RippleShape shape = RippleShape.Square, float rotation = 0f)
		{
			float g = strength * 0.5f + 0.5f;
			float scale = Math.Min(Math.Abs(strength), 1f);
			this.QueueRipple(position, new Color(0.5f, g, 0f, 1f) * scale, size, shape, rotation);
		}

		// Token: 0x06001208 RID: 4616 RVA: 0x00412B58 File Offset: 0x00410D58
		public void QueueRipple(Vector2 position, Color waveData, Vector2 size, RippleShape shape = RippleShape.Square, float rotation = 0f)
		{
			if (!this._useRippleWaves || Main.drawToScreen)
			{
				this._rippleQueueCount = 0;
				return;
			}
			if (this._rippleQueueCount < this._rippleQueue.Length)
			{
				WaterShaderData.Ripple[] arg_4A_0 = this._rippleQueue;
				int rippleQueueCount = this._rippleQueueCount;
				this._rippleQueueCount = rippleQueueCount + 1;
				arg_4A_0[rippleQueueCount] = new WaterShaderData.Ripple(position, waveData, size, shape, rotation);
			}
		}

		// Token: 0x04003259 RID: 12889
		private const float DISTORTION_BUFFER_SCALE = 0.25f;

		// Token: 0x0400325A RID: 12890
		private const float WAVE_FRAMERATE = 0.0166666675f;

		// Token: 0x0400325B RID: 12891
		private const int MAX_RIPPLES_QUEUED = 200;

		// Token: 0x0400325D RID: 12893
		public bool _useViscosityFilter = true;

		// Token: 0x0400325E RID: 12894
		private RenderTarget2D _distortionTarget;

		// Token: 0x0400325F RID: 12895
		private RenderTarget2D _distortionTargetSwap;

		// Token: 0x04003260 RID: 12896
		private bool _usingRenderTargets;

		// Token: 0x04003261 RID: 12897
		private Vector2 _lastDistortionDrawOffset = Vector2.Zero;

		// Token: 0x04003262 RID: 12898
		private float _progress;

		// Token: 0x04003263 RID: 12899
		private WaterShaderData.Ripple[] _rippleQueue = new WaterShaderData.Ripple[200];

		// Token: 0x04003264 RID: 12900
		private int _rippleQueueCount;

		// Token: 0x04003265 RID: 12901
		private int _lastScreenWidth;

		// Token: 0x04003266 RID: 12902
		private int _lastScreenHeight;

		// Token: 0x04003267 RID: 12903
		public bool _useProjectileWaves = true;

		// Token: 0x04003268 RID: 12904
		private bool _useNPCWaves = true;

		// Token: 0x04003269 RID: 12905
		private bool _usePlayerWaves = true;

		// Token: 0x0400326A RID: 12906
		private bool _useRippleWaves = true;

		// Token: 0x0400326B RID: 12907
		private bool _useCustomWaves = true;

		// Token: 0x0400326C RID: 12908
		private bool _clearNextFrame = true;

		// Token: 0x0400326D RID: 12909
		private Texture2D[] _viscosityMaskChain = new Texture2D[3];

		// Token: 0x0400326E RID: 12910
		private int _activeViscosityMask;

		// Token: 0x0400326F RID: 12911
		private Texture2D _rippleShapeTexture;

		// Token: 0x04003270 RID: 12912
		private bool _isWaveBufferDirty = true;

		// Token: 0x04003271 RID: 12913
		private int _queuedSteps;

		// Token: 0x04003272 RID: 12914
		private const int MAX_QUEUED_STEPS = 2;

		// Token: 0x020002BD RID: 701
		private struct Ripple
		{
			// Token: 0x170001D3 RID: 467
			// (get) Token: 0x0600179B RID: 6043 RVA: 0x0043C76C File Offset: 0x0043A96C
			public Rectangle SourceRectangle
			{
				get
				{
					return WaterShaderData.Ripple.RIPPLE_SHAPE_SOURCE_RECTS[(int)this.Shape];
				}
			}

			// Token: 0x0600179C RID: 6044 RVA: 0x0043C780 File Offset: 0x0043A980
			public Ripple(Vector2 position, Color waveData, Vector2 size, RippleShape shape, float rotation)
			{
				this.Position = position;
				this.WaveData = waveData;
				this.Size = size;
				this.Shape = shape;
				this.Rotation = rotation;
			}

			// Token: 0x04003D5E RID: 15710
			private static readonly Rectangle[] RIPPLE_SHAPE_SOURCE_RECTS = new Rectangle[]
			{
				new Rectangle(0, 0, 0, 0),
				new Rectangle(1, 1, 62, 62),
				new Rectangle(1, 65, 62, 62)
			};

			// Token: 0x04003D5F RID: 15711
			public readonly Vector2 Position;

			// Token: 0x04003D60 RID: 15712
			public readonly Color WaveData;

			// Token: 0x04003D61 RID: 15713
			public readonly Vector2 Size;

			// Token: 0x04003D62 RID: 15714
			public readonly RippleShape Shape;

			// Token: 0x04003D63 RID: 15715
			public readonly float Rotation;
		}
	}
}

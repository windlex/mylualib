using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Graphics.Shaders
{
	// Token: 0x020000EE RID: 238
	public class ScreenShaderData : ShaderData
	{
		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000DAE RID: 3502 RVA: 0x003E5DFC File Offset: 0x003E3FFC
		public float Intensity
		{
			get
			{
				return this._uIntensity;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000DAF RID: 3503 RVA: 0x003E5E04 File Offset: 0x003E4004
		public float CombinedOpacity
		{
			get
			{
				return this._uOpacity * this._globalOpacity;
			}
		}

		// Token: 0x06000DB0 RID: 3504 RVA: 0x003E5E14 File Offset: 0x003E4014
		public ScreenShaderData(string passName) : base(Main.ScreenShaderRef, passName)
		{
		}

		// Token: 0x06000DB1 RID: 3505 RVA: 0x003E5ED8 File Offset: 0x003E40D8
		public ScreenShaderData(Ref<Effect> shader, string passName) : base(shader, passName)
		{
		}

		// Token: 0x06000DB2 RID: 3506 RVA: 0x003E5F98 File Offset: 0x003E4198
		public virtual void Update(GameTime gameTime)
		{
		}

		// Token: 0x06000DB3 RID: 3507 RVA: 0x003E5F9C File Offset: 0x003E419C
		public new virtual void Apply()
		{
			Vector2 value = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
			Vector2 value2 = new Vector2((float)Main.screenWidth, (float)Main.screenHeight) / Main.GameViewMatrix.Zoom;
			Vector2 value3 = new Vector2((float)Main.screenWidth, (float)Main.screenHeight) * 0.5f;
			Vector2 value4 = Main.screenPosition + value3 * (Vector2.One - Vector2.One / Main.GameViewMatrix.Zoom);
			base.Shader.Parameters["uColor"].SetValue(this._uColor);
			base.Shader.Parameters["uOpacity"].SetValue(this.CombinedOpacity);
			base.Shader.Parameters["uSecondaryColor"].SetValue(this._uSecondaryColor);
			base.Shader.Parameters["uTime"].SetValue(Main.GlobalTime);
			base.Shader.Parameters["uScreenResolution"].SetValue(value2);
			base.Shader.Parameters["uScreenPosition"].SetValue(value4 - value);
			base.Shader.Parameters["uTargetPosition"].SetValue(this._uTargetPosition - value);
			base.Shader.Parameters["uImageOffset"].SetValue(this._uImageOffset);
			base.Shader.Parameters["uIntensity"].SetValue(this._uIntensity);
			base.Shader.Parameters["uProgress"].SetValue(this._uProgress);
			base.Shader.Parameters["uDirection"].SetValue(this._uDirection);
			base.Shader.Parameters["uZoom"].SetValue(Main.GameViewMatrix.Zoom);
			for (int i = 0; i < this._uImages.Length; i++)
			{
				if (this._uImages[i] != null && this._uImages[i].Value != null)
				{
					Main.graphics.GraphicsDevice.Textures[i + 1] = this._uImages[i].Value;
					int width = this._uImages[i].Value.Width;
					int height = this._uImages[i].Value.Height;
					if (this._samplerStates[i] != null)
					{
						Main.graphics.GraphicsDevice.SamplerStates[i + 1] = this._samplerStates[i];
					}
					else if (Utils.IsPowerOfTwo(width) && Utils.IsPowerOfTwo(height))
					{
						Main.graphics.GraphicsDevice.SamplerStates[i + 1] = SamplerState.LinearWrap;
					}
					else
					{
						Main.graphics.GraphicsDevice.SamplerStates[i + 1] = SamplerState.AnisotropicClamp;
					}
					base.Shader.Parameters["uImageSize" + (i + 1)].SetValue(new Vector2((float)width, (float)height) * this._imageScales[i]);
				}
			}
			base.Apply();
		}

		// Token: 0x06000DB4 RID: 3508 RVA: 0x003E6304 File Offset: 0x003E4504
		public ScreenShaderData UseImageOffset(Vector2 offset)
		{
			this._uImageOffset = offset;
			return this;
		}

		// Token: 0x06000DB5 RID: 3509 RVA: 0x003E6310 File Offset: 0x003E4510
		public ScreenShaderData UseIntensity(float intensity)
		{
			this._uIntensity = intensity;
			return this;
		}

		// Token: 0x06000DB6 RID: 3510 RVA: 0x003E631C File Offset: 0x003E451C
		public ScreenShaderData UseColor(float r, float g, float b)
		{
			return this.UseColor(new Vector3(r, g, b));
		}

		// Token: 0x06000DB7 RID: 3511 RVA: 0x003E632C File Offset: 0x003E452C
		public ScreenShaderData UseProgress(float progress)
		{
			this._uProgress = progress;
			return this;
		}

		// Token: 0x06000DB8 RID: 3512 RVA: 0x003E6338 File Offset: 0x003E4538
		public ScreenShaderData UseImage(Texture2D image, int index = 0, SamplerState samplerState = null)
		{
			this._samplerStates[index] = samplerState;
			if (this._uImages[index] == null)
			{
				this._uImages[index] = new Ref<Texture2D>(image);
			}
			else
			{
				this._uImages[index].Value = image;
			}
			return this;
		}

		// Token: 0x06000DB9 RID: 3513 RVA: 0x003E636C File Offset: 0x003E456C
		public ScreenShaderData UseImage(string path, int index = 0, SamplerState samplerState = null)
		{
			this._uImages[index] = TextureManager.AsyncLoad(path);
			this._samplerStates[index] = samplerState;
			return this;
		}

		// Token: 0x06000DBA RID: 3514 RVA: 0x003E6388 File Offset: 0x003E4588
		public ScreenShaderData UseColor(Color color)
		{
			return this.UseColor(color.ToVector3());
		}

		// Token: 0x06000DBB RID: 3515 RVA: 0x003E6398 File Offset: 0x003E4598
		public ScreenShaderData UseColor(Vector3 color)
		{
			this._uColor = color;
			return this;
		}

		// Token: 0x06000DBC RID: 3516 RVA: 0x003E63A4 File Offset: 0x003E45A4
		public ScreenShaderData UseDirection(Vector2 direction)
		{
			this._uDirection = direction;
			return this;
		}

		// Token: 0x06000DBD RID: 3517 RVA: 0x003E63B0 File Offset: 0x003E45B0
		public ScreenShaderData UseGlobalOpacity(float opacity)
		{
			this._globalOpacity = opacity;
			return this;
		}

		// Token: 0x06000DBE RID: 3518 RVA: 0x003E63BC File Offset: 0x003E45BC
		public ScreenShaderData UseTargetPosition(Vector2 position)
		{
			this._uTargetPosition = position;
			return this;
		}

		// Token: 0x06000DBF RID: 3519 RVA: 0x003E63C8 File Offset: 0x003E45C8
		public ScreenShaderData UseSecondaryColor(float r, float g, float b)
		{
			return this.UseSecondaryColor(new Vector3(r, g, b));
		}

		// Token: 0x06000DC0 RID: 3520 RVA: 0x003E63D8 File Offset: 0x003E45D8
		public ScreenShaderData UseSecondaryColor(Color color)
		{
			return this.UseSecondaryColor(color.ToVector3());
		}

		// Token: 0x06000DC1 RID: 3521 RVA: 0x003E63E8 File Offset: 0x003E45E8
		public ScreenShaderData UseSecondaryColor(Vector3 color)
		{
			this._uSecondaryColor = color;
			return this;
		}

		// Token: 0x06000DC2 RID: 3522 RVA: 0x003E63F4 File Offset: 0x003E45F4
		public ScreenShaderData UseOpacity(float opacity)
		{
			this._uOpacity = opacity;
			return this;
		}

		// Token: 0x06000DC3 RID: 3523 RVA: 0x003E6400 File Offset: 0x003E4600
		public ScreenShaderData UseImageScale(Vector2 scale, int index = 0)
		{
			this._imageScales[index] = scale;
			return this;
		}

		// Token: 0x06000DC4 RID: 3524 RVA: 0x003E6410 File Offset: 0x003E4610
		public virtual ScreenShaderData GetSecondaryShader(Player player)
		{
			return this;
		}

		// Token: 0x04002F4A RID: 12106
		private Vector3 _uColor = Vector3.One;

		// Token: 0x04002F4B RID: 12107
		private Vector3 _uSecondaryColor = Vector3.One;

		// Token: 0x04002F4C RID: 12108
		private float _uOpacity = 1f;

		// Token: 0x04002F4D RID: 12109
		private float _globalOpacity = 1f;

		// Token: 0x04002F4E RID: 12110
		private float _uIntensity = 1f;

		// Token: 0x04002F4F RID: 12111
		private Vector2 _uTargetPosition = Vector2.One;

		// Token: 0x04002F50 RID: 12112
		private Vector2 _uDirection = new Vector2(0f, 1f);

		// Token: 0x04002F51 RID: 12113
		private float _uProgress;

		// Token: 0x04002F52 RID: 12114
		private Vector2 _uImageOffset = Vector2.Zero;

		// Token: 0x04002F53 RID: 12115
		private Ref<Texture2D>[] _uImages = new Ref<Texture2D>[3];

		// Token: 0x04002F54 RID: 12116
		private SamplerState[] _samplerStates = new SamplerState[3];

		// Token: 0x04002F55 RID: 12117
		private Vector2[] _imageScales = new Vector2[]
		{
			Vector2.One,
			Vector2.One,
			Vector2.One
		};
	}
}

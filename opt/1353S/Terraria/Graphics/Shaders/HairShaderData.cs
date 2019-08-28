using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace Terraria.Graphics.Shaders
{
	// Token: 0x020000ED RID: 237
	public class HairShaderData : ShaderData
	{
		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000DA1 RID: 3489 RVA: 0x003E5AC0 File Offset: 0x003E3CC0
		public bool ShaderDisabled
		{
			get
			{
				return this._shaderDisabled;
			}
		}

		// Token: 0x06000DA2 RID: 3490 RVA: 0x003E5AC8 File Offset: 0x003E3CC8
		public HairShaderData(Ref<Effect> shader, string passName) : base(shader, passName)
		{
		}

		// Token: 0x06000DA3 RID: 3491 RVA: 0x003E5B00 File Offset: 0x003E3D00
		public virtual void Apply(Player player, DrawData? drawData = null)
		{
			if (this._shaderDisabled)
			{
				return;
			}
			base.Shader.Parameters["uColor"].SetValue(this._uColor);
			base.Shader.Parameters["uSaturation"].SetValue(this._uSaturation);
			base.Shader.Parameters["uSecondaryColor"].SetValue(this._uSecondaryColor);
			base.Shader.Parameters["uTime"].SetValue(Main.GlobalTime);
			base.Shader.Parameters["uOpacity"].SetValue(this._uOpacity);
			if (drawData.HasValue)
			{
				DrawData value = drawData.Value;
				Vector4 value2 = new Vector4((float)value.sourceRect.Value.X, (float)value.sourceRect.Value.Y, (float)value.sourceRect.Value.Width, (float)value.sourceRect.Value.Height);
				base.Shader.Parameters["uSourceRect"].SetValue(value2);
				base.Shader.Parameters["uWorldPosition"].SetValue(Main.screenPosition + value.position);
				base.Shader.Parameters["uImageSize0"].SetValue(new Vector2((float)value.texture.Width, (float)value.texture.Height));
			}
			else
			{
				base.Shader.Parameters["uSourceRect"].SetValue(new Vector4(0f, 0f, 4f, 4f));
			}
			if (this._uImage != null)
			{
				Main.graphics.GraphicsDevice.Textures[1] = this._uImage.Value;
				base.Shader.Parameters["uImageSize1"].SetValue(new Vector2((float)this._uImage.Value.Width, (float)this._uImage.Value.Height));
			}
			if (player != null)
			{
				base.Shader.Parameters["uDirection"].SetValue((float)player.direction);
			}
			this.Apply();
		}

		// Token: 0x06000DA4 RID: 3492 RVA: 0x003E5D5C File Offset: 0x003E3F5C
		public virtual Color GetColor(Player player, Color lightColor)
		{
			return new Color(lightColor.ToVector4() * player.hairColor.ToVector4());
		}

		// Token: 0x06000DA5 RID: 3493 RVA: 0x003E5D7C File Offset: 0x003E3F7C
		public HairShaderData UseColor(float r, float g, float b)
		{
			return this.UseColor(new Vector3(r, g, b));
		}

		// Token: 0x06000DA6 RID: 3494 RVA: 0x003E5D8C File Offset: 0x003E3F8C
		public HairShaderData UseColor(Color color)
		{
			return this.UseColor(color.ToVector3());
		}

		// Token: 0x06000DA7 RID: 3495 RVA: 0x003E5D9C File Offset: 0x003E3F9C
		public HairShaderData UseColor(Vector3 color)
		{
			this._uColor = color;
			return this;
		}

		// Token: 0x06000DA8 RID: 3496 RVA: 0x003E5DA8 File Offset: 0x003E3FA8
		public HairShaderData UseImage(string path)
		{
			this._uImage = TextureManager.AsyncLoad(path);
			return this;
		}

		// Token: 0x06000DA9 RID: 3497 RVA: 0x003E5DB8 File Offset: 0x003E3FB8
		public HairShaderData UseOpacity(float alpha)
		{
			this._uOpacity = alpha;
			return this;
		}

		// Token: 0x06000DAA RID: 3498 RVA: 0x003E5DC4 File Offset: 0x003E3FC4
		public HairShaderData UseSecondaryColor(float r, float g, float b)
		{
			return this.UseSecondaryColor(new Vector3(r, g, b));
		}

		// Token: 0x06000DAB RID: 3499 RVA: 0x003E5DD4 File Offset: 0x003E3FD4
		public HairShaderData UseSecondaryColor(Color color)
		{
			return this.UseSecondaryColor(color.ToVector3());
		}

		// Token: 0x06000DAC RID: 3500 RVA: 0x003E5DE4 File Offset: 0x003E3FE4
		public HairShaderData UseSecondaryColor(Vector3 color)
		{
			this._uSecondaryColor = color;
			return this;
		}

		// Token: 0x06000DAD RID: 3501 RVA: 0x003E5DF0 File Offset: 0x003E3FF0
		public HairShaderData UseSaturation(float saturation)
		{
			this._uSaturation = saturation;
			return this;
		}

		// Token: 0x04002F44 RID: 12100
		protected Vector3 _uColor = Vector3.One;

		// Token: 0x04002F45 RID: 12101
		protected Vector3 _uSecondaryColor = Vector3.One;

		// Token: 0x04002F46 RID: 12102
		protected float _uSaturation = 1f;

		// Token: 0x04002F47 RID: 12103
		protected float _uOpacity = 1f;

		// Token: 0x04002F48 RID: 12104
		protected Ref<Texture2D> _uImage;

		// Token: 0x04002F49 RID: 12105
		protected bool _shaderDisabled;
	}
}

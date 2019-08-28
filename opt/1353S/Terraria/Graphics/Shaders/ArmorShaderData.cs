using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace Terraria.Graphics.Shaders
{
	// Token: 0x020000EF RID: 239
	public class ArmorShaderData : ShaderData
	{
		// Token: 0x06000DC5 RID: 3525 RVA: 0x003E6414 File Offset: 0x003E4614
		public ArmorShaderData(Ref<Effect> shader, string passName) : base(shader, passName)
		{
		}

		// Token: 0x06000DC6 RID: 3526 RVA: 0x003E644C File Offset: 0x003E464C
		public virtual void Apply(Entity entity, DrawData? drawData = null)
		{
			base.Shader.Parameters["uColor"].SetValue(this._uColor);
			base.Shader.Parameters["uSaturation"].SetValue(this._uSaturation);
			base.Shader.Parameters["uSecondaryColor"].SetValue(this._uSecondaryColor);
			base.Shader.Parameters["uTime"].SetValue(Main.GlobalTime);
			base.Shader.Parameters["uOpacity"].SetValue(this._uOpacity);
			if (drawData.HasValue)
			{
				DrawData value = drawData.Value;
				Vector4 value2;
				if (value.sourceRect.HasValue)
				{
					value2 = new Vector4((float)value.sourceRect.Value.X, (float)value.sourceRect.Value.Y, (float)value.sourceRect.Value.Width, (float)value.sourceRect.Value.Height);
				}
				else
				{
					value2 = new Vector4(0f, 0f, (float)value.texture.Width, (float)value.texture.Height);
				}
				base.Shader.Parameters["uSourceRect"].SetValue(value2);
				base.Shader.Parameters["uWorldPosition"].SetValue(Main.screenPosition + value.position);
				base.Shader.Parameters["uImageSize0"].SetValue(new Vector2((float)value.texture.Width, (float)value.texture.Height));
				base.Shader.Parameters["uRotation"].SetValue(value.rotation * (value.effect.HasFlag(SpriteEffects.FlipHorizontally) ? -1f : 1f));
				base.Shader.Parameters["uDirection"].SetValue(value.effect.HasFlag(SpriteEffects.FlipHorizontally) ? -1 : 1);
			}
			else
			{
				base.Shader.Parameters["uSourceRect"].SetValue(new Vector4(0f, 0f, 4f, 4f));
				base.Shader.Parameters["uRotation"].SetValue(0f);
			}
			if (this._uImage != null)
			{
				Main.graphics.GraphicsDevice.Textures[1] = this._uImage.Value;
				base.Shader.Parameters["uImageSize1"].SetValue(new Vector2((float)this._uImage.Value.Width, (float)this._uImage.Value.Height));
			}
			if (entity != null)
			{
				base.Shader.Parameters["uDirection"].SetValue((float)entity.direction);
			}
			this.Apply();
		}

		// Token: 0x06000DC7 RID: 3527 RVA: 0x003E6774 File Offset: 0x003E4974
		public ArmorShaderData UseColor(float r, float g, float b)
		{
			return this.UseColor(new Vector3(r, g, b));
		}

		// Token: 0x06000DC8 RID: 3528 RVA: 0x003E6784 File Offset: 0x003E4984
		public ArmorShaderData UseColor(Color color)
		{
			return this.UseColor(color.ToVector3());
		}

		// Token: 0x06000DC9 RID: 3529 RVA: 0x003E6794 File Offset: 0x003E4994
		public ArmorShaderData UseColor(Vector3 color)
		{
			this._uColor = color;
			return this;
		}

		// Token: 0x06000DCA RID: 3530 RVA: 0x003E67A0 File Offset: 0x003E49A0
		public ArmorShaderData UseImage(string path)
		{
			this._uImage = TextureManager.AsyncLoad(path);
			return this;
		}

		// Token: 0x06000DCB RID: 3531 RVA: 0x003E67B0 File Offset: 0x003E49B0
		public ArmorShaderData UseOpacity(float alpha)
		{
			this._uOpacity = alpha;
			return this;
		}

		// Token: 0x06000DCC RID: 3532 RVA: 0x003E67BC File Offset: 0x003E49BC
		public ArmorShaderData UseSecondaryColor(float r, float g, float b)
		{
			return this.UseSecondaryColor(new Vector3(r, g, b));
		}

		// Token: 0x06000DCD RID: 3533 RVA: 0x003E67CC File Offset: 0x003E49CC
		public ArmorShaderData UseSecondaryColor(Color color)
		{
			return this.UseSecondaryColor(color.ToVector3());
		}

		// Token: 0x06000DCE RID: 3534 RVA: 0x003E67DC File Offset: 0x003E49DC
		public ArmorShaderData UseSecondaryColor(Vector3 color)
		{
			this._uSecondaryColor = color;
			return this;
		}

		// Token: 0x06000DCF RID: 3535 RVA: 0x003E67E8 File Offset: 0x003E49E8
		public ArmorShaderData UseSaturation(float saturation)
		{
			this._uSaturation = saturation;
			return this;
		}

		// Token: 0x06000DD0 RID: 3536 RVA: 0x003E67F4 File Offset: 0x003E49F4
		public virtual ArmorShaderData GetSecondaryShader(Entity entity)
		{
			return this;
		}

		// Token: 0x04002F56 RID: 12118
		private Vector3 _uColor = Vector3.One;

		// Token: 0x04002F57 RID: 12119
		private Vector3 _uSecondaryColor = Vector3.One;

		// Token: 0x04002F58 RID: 12120
		private float _uSaturation = 1f;

		// Token: 0x04002F59 RID: 12121
		private float _uOpacity = 1f;

		// Token: 0x04002F5A RID: 12122
		private Ref<Texture2D> _uImage;
	}
}

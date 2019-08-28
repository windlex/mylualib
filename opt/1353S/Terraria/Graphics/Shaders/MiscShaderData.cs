using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace Terraria.Graphics.Shaders
{
	// Token: 0x020000EC RID: 236
	public class MiscShaderData : ShaderData
	{
		// Token: 0x06000D95 RID: 3477 RVA: 0x003E57B8 File Offset: 0x003E39B8
		public MiscShaderData(Ref<Effect> shader, string passName) : base(shader, passName)
		{
		}

		// Token: 0x06000D96 RID: 3478 RVA: 0x003E57F0 File Offset: 0x003E39F0
		public virtual void Apply(DrawData? drawData = null)
		{
			base.Shader.Parameters["uColor"].SetValue(this._uColor);
			base.Shader.Parameters["uSaturation"].SetValue(this._uSaturation);
			base.Shader.Parameters["uSecondaryColor"].SetValue(this._uSecondaryColor);
			base.Shader.Parameters["uTime"].SetValue(Main.GlobalTime);
			base.Shader.Parameters["uOpacity"].SetValue(this._uOpacity);
			if (drawData.HasValue)
			{
				DrawData value = drawData.Value;
				Vector4 zero = Vector4.Zero;
				if (drawData.Value.sourceRect.HasValue)
				{
					zero = new Vector4((float)value.sourceRect.Value.X, (float)value.sourceRect.Value.Y, (float)value.sourceRect.Value.Width, (float)value.sourceRect.Value.Height);
				}
				base.Shader.Parameters["uSourceRect"].SetValue(zero);
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
			base.Apply();
		}

		// Token: 0x06000D97 RID: 3479 RVA: 0x003E5A3C File Offset: 0x003E3C3C
		public MiscShaderData UseColor(float r, float g, float b)
		{
			return this.UseColor(new Vector3(r, g, b));
		}

		// Token: 0x06000D98 RID: 3480 RVA: 0x003E5A4C File Offset: 0x003E3C4C
		public MiscShaderData UseColor(Color color)
		{
			return this.UseColor(color.ToVector3());
		}

		// Token: 0x06000D99 RID: 3481 RVA: 0x003E5A5C File Offset: 0x003E3C5C
		public MiscShaderData UseColor(Vector3 color)
		{
			this._uColor = color;
			return this;
		}

		// Token: 0x06000D9A RID: 3482 RVA: 0x003E5A68 File Offset: 0x003E3C68
		public MiscShaderData UseImage(string path)
		{
			this._uImage = TextureManager.AsyncLoad(path);
			return this;
		}

		// Token: 0x06000D9B RID: 3483 RVA: 0x003E5A78 File Offset: 0x003E3C78
		public MiscShaderData UseOpacity(float alpha)
		{
			this._uOpacity = alpha;
			return this;
		}

		// Token: 0x06000D9C RID: 3484 RVA: 0x003E5A84 File Offset: 0x003E3C84
		public MiscShaderData UseSecondaryColor(float r, float g, float b)
		{
			return this.UseSecondaryColor(new Vector3(r, g, b));
		}

		// Token: 0x06000D9D RID: 3485 RVA: 0x003E5A94 File Offset: 0x003E3C94
		public MiscShaderData UseSecondaryColor(Color color)
		{
			return this.UseSecondaryColor(color.ToVector3());
		}

		// Token: 0x06000D9E RID: 3486 RVA: 0x003E5AA4 File Offset: 0x003E3CA4
		public MiscShaderData UseSecondaryColor(Vector3 color)
		{
			this._uSecondaryColor = color;
			return this;
		}

		// Token: 0x06000D9F RID: 3487 RVA: 0x003E5AB0 File Offset: 0x003E3CB0
		public MiscShaderData UseSaturation(float saturation)
		{
			this._uSaturation = saturation;
			return this;
		}

		// Token: 0x06000DA0 RID: 3488 RVA: 0x003E5ABC File Offset: 0x003E3CBC
		public virtual MiscShaderData GetSecondaryShader(Entity entity)
		{
			return this;
		}

		// Token: 0x04002F3F RID: 12095
		private Vector3 _uColor = Vector3.One;

		// Token: 0x04002F40 RID: 12096
		private Vector3 _uSecondaryColor = Vector3.One;

		// Token: 0x04002F41 RID: 12097
		private float _uSaturation = 1f;

		// Token: 0x04002F42 RID: 12098
		private float _uOpacity = 1f;

		// Token: 0x04002F43 RID: 12099
		private Ref<Texture2D> _uImage;
	}
}

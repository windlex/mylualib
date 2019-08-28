using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Shaders;

namespace Terraria.Graphics.Effects
{
	// Token: 0x02000100 RID: 256
	public class SimpleOverlay : Overlay
	{
		// Token: 0x06000E1D RID: 3613 RVA: 0x003E779C File Offset: 0x003E599C
		public SimpleOverlay(string textureName, ScreenShaderData shader, EffectPriority priority = EffectPriority.VeryLow, RenderLayers layer = RenderLayers.All) : base(priority, layer)
		{
			this._texture = TextureManager.AsyncLoad((textureName == null) ? "" : textureName);
			this._shader = shader;
		}

		// Token: 0x06000E1E RID: 3614 RVA: 0x003E77D0 File Offset: 0x003E59D0
		public SimpleOverlay(string textureName, string shaderName = "Default", EffectPriority priority = EffectPriority.VeryLow, RenderLayers layer = RenderLayers.All) : base(priority, layer)
		{
			this._texture = TextureManager.AsyncLoad((textureName == null) ? "" : textureName);
			this._shader = new ScreenShaderData(Main.ScreenShaderRef, shaderName);
		}

		// Token: 0x06000E1F RID: 3615 RVA: 0x003E7810 File Offset: 0x003E5A10
		public ScreenShaderData GetShader()
		{
			return this._shader;
		}

		// Token: 0x06000E20 RID: 3616 RVA: 0x003E7818 File Offset: 0x003E5A18
		public override void Draw(SpriteBatch spriteBatch)
		{
			this._shader.UseGlobalOpacity(this.Opacity);
			this._shader.UseTargetPosition(this.TargetPosition);
			this._shader.Apply();
			spriteBatch.Draw(this._texture.Value, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Main.bgColor);
		}

		// Token: 0x06000E21 RID: 3617 RVA: 0x003E787C File Offset: 0x003E5A7C
		public override void Update(GameTime gameTime)
		{
			this._shader.Update(gameTime);
		}

		// Token: 0x06000E22 RID: 3618 RVA: 0x003E788C File Offset: 0x003E5A8C
		internal override void Activate(Vector2 position, params object[] args)
		{
			this.TargetPosition = position;
			this.Mode = OverlayMode.FadeIn;
		}

		// Token: 0x06000E23 RID: 3619 RVA: 0x003E789C File Offset: 0x003E5A9C
		internal override void Deactivate(params object[] args)
		{
			this.Mode = OverlayMode.FadeOut;
		}

		// Token: 0x06000E24 RID: 3620 RVA: 0x003E78A8 File Offset: 0x003E5AA8
		public override bool IsVisible()
		{
			return this._shader.CombinedOpacity > 0f;
		}

		// Token: 0x04002F92 RID: 12178
		private Ref<Texture2D> _texture;

		// Token: 0x04002F93 RID: 12179
		private ScreenShaderData _shader;

		// Token: 0x04002F94 RID: 12180
		public Vector2 TargetPosition = Vector2.Zero;
	}
}

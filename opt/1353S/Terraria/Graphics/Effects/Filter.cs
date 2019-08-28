using System;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Shaders;

namespace Terraria.Graphics.Effects
{
	// Token: 0x020000F7 RID: 247
	public class Filter : GameEffect
	{
		// Token: 0x06000DF6 RID: 3574 RVA: 0x003E6D38 File Offset: 0x003E4F38
		public Filter(ScreenShaderData shader, EffectPriority priority = EffectPriority.VeryLow)
		{
			this._shader = shader;
			this._priority = priority;
		}

		// Token: 0x06000DF7 RID: 3575 RVA: 0x003E6D50 File Offset: 0x003E4F50
		public void Update(GameTime gameTime)
		{
			this._shader.UseGlobalOpacity(this.Opacity);
			this._shader.Update(gameTime);
		}

		// Token: 0x06000DF8 RID: 3576 RVA: 0x003E6D70 File Offset: 0x003E4F70
		public void Apply()
		{
			this._shader.Apply();
		}

		// Token: 0x06000DF9 RID: 3577 RVA: 0x003E6D80 File Offset: 0x003E4F80
		public ScreenShaderData GetShader()
		{
			return this._shader;
		}

		// Token: 0x06000DFA RID: 3578 RVA: 0x003E6D88 File Offset: 0x003E4F88
		internal override void Activate(Vector2 position, params object[] args)
		{
			this._shader.UseGlobalOpacity(this.Opacity);
			this._shader.UseTargetPosition(position);
			this.Active = true;
		}

		// Token: 0x06000DFB RID: 3579 RVA: 0x003E6DB0 File Offset: 0x003E4FB0
		internal override void Deactivate(params object[] args)
		{
			this.Active = false;
		}

		// Token: 0x06000DFC RID: 3580 RVA: 0x003E6DBC File Offset: 0x003E4FBC
		public bool IsInUse()
		{
			return this.Active || this.Opacity != 0f;
		}

		// Token: 0x06000DFD RID: 3581 RVA: 0x003E6DD8 File Offset: 0x003E4FD8
		public bool IsActive()
		{
			return this.Active;
		}

		// Token: 0x06000DFE RID: 3582 RVA: 0x003E6DE0 File Offset: 0x003E4FE0
		public override bool IsVisible()
		{
			return this.GetShader().CombinedOpacity > 0f && !this.IsHidden;
		}

		// Token: 0x04002F78 RID: 12152
		public bool Active;

		// Token: 0x04002F79 RID: 12153
		private ScreenShaderData _shader;

		// Token: 0x04002F7A RID: 12154
		public bool IsHidden;
	}
}

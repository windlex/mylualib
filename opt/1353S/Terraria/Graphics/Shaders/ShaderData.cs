using System;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Graphics.Shaders
{
	// Token: 0x020000F1 RID: 241
	public class ShaderData
	{
		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000DD3 RID: 3539 RVA: 0x003E6820 File Offset: 0x003E4A20
		public Effect Shader
		{
			get
			{
				if (this._shader != null)
				{
					return this._shader.Value;
				}
				return null;
			}
		}

		// Token: 0x06000DD4 RID: 3540 RVA: 0x003E6838 File Offset: 0x003E4A38
		public ShaderData(Ref<Effect> shader, string passName)
		{
			this._passName = passName;
			this._shader = shader;
		}

		// Token: 0x06000DD5 RID: 3541 RVA: 0x003E6850 File Offset: 0x003E4A50
		public void SwapProgram(string passName)
		{
			this._passName = passName;
			if (passName != null)
			{
				this._effectPass = this.Shader.CurrentTechnique.Passes[passName];
			}
		}

		// Token: 0x06000DD6 RID: 3542 RVA: 0x003E6878 File Offset: 0x003E4A78
		protected virtual void Apply()
		{
			if (this._shader != null && this._lastEffect != this._shader.Value && this.Shader != null && this._passName != null)
			{
				this._effectPass = this.Shader.CurrentTechnique.Passes[this._passName];
			}
			this._effectPass.Apply();
		}

		// Token: 0x04002F5E RID: 12126
		protected Ref<Effect> _shader;

		// Token: 0x04002F5F RID: 12127
		protected string _passName;

		// Token: 0x04002F60 RID: 12128
		private EffectPass _effectPass;

		// Token: 0x04002F61 RID: 12129
		private Effect _lastEffect;
	}
}

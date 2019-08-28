using System;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Shaders;

namespace Terraria.GameContent.Shaders
{
	// Token: 0x0200016B RID: 363
	public class BlizzardShaderData : ScreenShaderData
	{
		// Token: 0x060011F8 RID: 4600 RVA: 0x004116C4 File Offset: 0x0040F8C4
		public BlizzardShaderData(string passName) : base(passName)
		{
		}

		// Token: 0x060011F9 RID: 4601 RVA: 0x004116E4 File Offset: 0x0040F8E4
		public override void Update(GameTime gameTime)
		{
			float num = Main.windSpeed;
			if (num >= 0f && num <= 0.1f)
			{
				num = 0.1f;
			}
			else if (num <= 0f && num >= -0.1f)
			{
				num = -0.1f;
			}
			this.windSpeed = num * 0.05f + this.windSpeed * 0.95f;
			Vector2 vector = new Vector2(-this.windSpeed, -1f) * new Vector2(10f, 2f);
			vector.Normalize();
			vector *= new Vector2(0.8f, 0.6f);
			if (!Main.gamePaused && Main.hasFocus)
			{
				this._texturePosition += vector * (float)gameTime.ElapsedGameTime.TotalSeconds;
			}
			this._texturePosition.X = this._texturePosition.X % 10f;
			this._texturePosition.Y = this._texturePosition.Y % 10f;
			base.UseDirection(vector);
			base.UseTargetPosition(this._texturePosition);
			base.Update(gameTime);
		}

		// Token: 0x060011FA RID: 4602 RVA: 0x004117FC File Offset: 0x0040F9FC
		public override void Apply()
		{
			base.UseTargetPosition(this._texturePosition);
			base.Apply();
		}

		// Token: 0x04003253 RID: 12883
		private Vector2 _texturePosition = Vector2.Zero;

		// Token: 0x04003254 RID: 12884
		private float windSpeed = 0.1f;
	}
}

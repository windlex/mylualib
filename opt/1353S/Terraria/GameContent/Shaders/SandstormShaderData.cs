using System;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Shaders;

namespace Terraria.GameContent.Shaders
{
	// Token: 0x0200016A RID: 362
	public class SandstormShaderData : ScreenShaderData
	{
		// Token: 0x060011F5 RID: 4597 RVA: 0x004115DC File Offset: 0x0040F7DC
		public SandstormShaderData(string passName) : base(passName)
		{
		}

		// Token: 0x060011F6 RID: 4598 RVA: 0x004115F0 File Offset: 0x0040F7F0
		public override void Update(GameTime gameTime)
		{
			Vector2 vector = new Vector2(-Main.windSpeed, -1f) * new Vector2(20f, 0.1f);
			vector.Normalize();
			vector *= new Vector2(2f, 0.2f);
			if (!Main.gamePaused && Main.hasFocus)
			{
				this._texturePosition += vector * (float)gameTime.ElapsedGameTime.TotalSeconds;
			}
			this._texturePosition.X = this._texturePosition.X % 10f;
			this._texturePosition.Y = this._texturePosition.Y % 10f;
			base.UseDirection(vector);
			base.Update(gameTime);
		}

		// Token: 0x060011F7 RID: 4599 RVA: 0x004116AC File Offset: 0x0040F8AC
		public override void Apply()
		{
			base.UseTargetPosition(this._texturePosition);
			base.Apply();
		}

		// Token: 0x04003252 RID: 12882
		private Vector2 _texturePosition = Vector2.Zero;
	}
}

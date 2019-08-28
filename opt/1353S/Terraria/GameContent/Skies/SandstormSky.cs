using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.Events;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace Terraria.GameContent.Skies
{
	// Token: 0x02000162 RID: 354
	public class SandstormSky : CustomSky
	{
		// Token: 0x060011A5 RID: 4517 RVA: 0x0040E9E8 File Offset: 0x0040CBE8
		public override void OnLoad()
		{
		}

		// Token: 0x060011A6 RID: 4518 RVA: 0x0040E9EC File Offset: 0x0040CBEC
		public override void Update(GameTime gameTime)
		{
			if (Main.gamePaused || !Main.hasFocus)
			{
				return;
			}
			if (this._isLeaving)
			{
				this._opacity -= (float)gameTime.ElapsedGameTime.TotalSeconds;
				if (this._opacity < 0f)
				{
					this._isActive = false;
					this._opacity = 0f;
					return;
				}
			}
			else
			{
				this._opacity += (float)gameTime.ElapsedGameTime.TotalSeconds;
				if (this._opacity > 1f)
				{
					this._opacity = 1f;
				}
			}
		}

		// Token: 0x060011A7 RID: 4519 RVA: 0x0040EA80 File Offset: 0x0040CC80
		public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			if (minDepth < 1f || maxDepth == 3.40282347E+38f)
			{
				float scale = Math.Min(1f, Sandstorm.Severity * 1.5f);
				Color color = new Color(new Vector4(0.85f, 0.66f, 0.33f, 1f) * 0.8f * Main.bgColor.ToVector4()) * this._opacity * scale;
				spriteBatch.Draw(Main.magicPixel, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), color);
			}
		}

		// Token: 0x060011A8 RID: 4520 RVA: 0x0040EB1C File Offset: 0x0040CD1C
		internal override void Activate(Vector2 position, params object[] args)
		{
			this._isActive = true;
			this._isLeaving = false;
		}

		// Token: 0x060011A9 RID: 4521 RVA: 0x0040EB2C File Offset: 0x0040CD2C
		internal override void Deactivate(params object[] args)
		{
			this._isLeaving = true;
		}

		// Token: 0x060011AA RID: 4522 RVA: 0x0040EB38 File Offset: 0x0040CD38
		public override void Reset()
		{
			this._opacity = 0f;
			this._isActive = false;
		}

		// Token: 0x060011AB RID: 4523 RVA: 0x0040EB4C File Offset: 0x0040CD4C
		public override bool IsActive()
		{
			return this._isActive;
		}

		// Token: 0x04003220 RID: 12832
		private UnifiedRandom _random = new UnifiedRandom();

		// Token: 0x04003221 RID: 12833
		private bool _isActive;

		// Token: 0x04003222 RID: 12834
		private bool _isLeaving;

		// Token: 0x04003223 RID: 12835
		private float _opacity;
	}
}

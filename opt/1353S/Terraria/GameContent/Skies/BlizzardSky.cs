using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace Terraria.GameContent.Skies
{
	// Token: 0x02000160 RID: 352
	public class BlizzardSky : CustomSky
	{
		// Token: 0x06001191 RID: 4497 RVA: 0x0040E0B8 File Offset: 0x0040C2B8
		public override void OnLoad()
		{
		}

		// Token: 0x06001192 RID: 4498 RVA: 0x0040E0BC File Offset: 0x0040C2BC
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

		// Token: 0x06001193 RID: 4499 RVA: 0x0040E150 File Offset: 0x0040C350
		public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			if (minDepth < 1f || maxDepth == 3.40282347E+38f)
			{
				float scale = Math.Min(1f, Main.cloudAlpha * 2f);
				Color color = new Color(new Vector4(1f) * Main.bgColor.ToVector4()) * this._opacity * 0.7f * scale;
				spriteBatch.Draw(Main.magicPixel, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), color);
			}
		}

		// Token: 0x06001194 RID: 4500 RVA: 0x0040E1DC File Offset: 0x0040C3DC
		internal override void Activate(Vector2 position, params object[] args)
		{
			this._isActive = true;
			this._isLeaving = false;
		}

		// Token: 0x06001195 RID: 4501 RVA: 0x0040E1EC File Offset: 0x0040C3EC
		internal override void Deactivate(params object[] args)
		{
			this._isLeaving = true;
		}

		// Token: 0x06001196 RID: 4502 RVA: 0x0040E1F8 File Offset: 0x0040C3F8
		public override void Reset()
		{
			this._opacity = 0f;
			this._isActive = false;
		}

		// Token: 0x06001197 RID: 4503 RVA: 0x0040E20C File Offset: 0x0040C40C
		public override bool IsActive()
		{
			return this._isActive;
		}

		// Token: 0x04003214 RID: 12820
		private UnifiedRandom _random = new UnifiedRandom();

		// Token: 0x04003215 RID: 12821
		private bool _isActive;

		// Token: 0x04003216 RID: 12822
		private bool _isLeaving;

		// Token: 0x04003217 RID: 12823
		private float _opacity;
	}
}

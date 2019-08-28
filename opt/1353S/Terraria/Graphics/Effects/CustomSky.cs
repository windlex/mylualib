using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Graphics.Effects
{
	// Token: 0x020000F3 RID: 243
	public abstract class CustomSky : GameEffect
	{
		// Token: 0x06000DD7 RID: 3543
		public abstract void Update(GameTime gameTime);

		// Token: 0x06000DD8 RID: 3544
		public abstract void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth);

		// Token: 0x06000DD9 RID: 3545
		public abstract bool IsActive();

		// Token: 0x06000DDA RID: 3546
		public abstract void Reset();

		// Token: 0x06000DDB RID: 3547 RVA: 0x003E68DC File Offset: 0x003E4ADC
		public virtual Color OnTileColor(Color inColor)
		{
			return inColor;
		}

		// Token: 0x06000DDC RID: 3548 RVA: 0x003E68E0 File Offset: 0x003E4AE0
		public virtual float GetCloudAlpha()
		{
			return 1f;
		}

		// Token: 0x06000DDD RID: 3549 RVA: 0x003E68E8 File Offset: 0x003E4AE8
		public override bool IsVisible()
		{
			return true;
		}
	}
}

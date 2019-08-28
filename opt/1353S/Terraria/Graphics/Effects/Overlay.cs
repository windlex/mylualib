using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Graphics.Effects
{
	// Token: 0x020000FD RID: 253
	public abstract class Overlay : GameEffect
	{
		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000E14 RID: 3604 RVA: 0x003E746C File Offset: 0x003E566C
		public RenderLayers Layer
		{
			get
			{
				return this._layer;
			}
		}

		// Token: 0x06000E15 RID: 3605 RVA: 0x003E7474 File Offset: 0x003E5674
		public Overlay(EffectPriority priority, RenderLayers layer)
		{
			this._priority = priority;
			this._layer = layer;
		}

		// Token: 0x06000E16 RID: 3606
		public abstract void Draw(SpriteBatch spriteBatch);

		// Token: 0x06000E17 RID: 3607
		public abstract void Update(GameTime gameTime);

		// Token: 0x04002F8B RID: 12171
		public OverlayMode Mode = OverlayMode.Inactive;

		// Token: 0x04002F8C RID: 12172
		private RenderLayers _layer = RenderLayers.All;
	}
}

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Graphics
{
	// Token: 0x020000E1 RID: 225
	public class SpriteViewMatrix
	{
		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000D2F RID: 3375 RVA: 0x003E25AC File Offset: 0x003E07AC
		// (set) Token: 0x06000D30 RID: 3376 RVA: 0x003E25B4 File Offset: 0x003E07B4
		public Vector2 Zoom
		{
			get
			{
				return this._zoom;
			}
			set
			{
				if (this._zoom != value)
				{
					this._zoom = value;
					this._needsRebuild = true;
				}
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000D31 RID: 3377 RVA: 0x003E25D4 File Offset: 0x003E07D4
		public Vector2 Translation
		{
			get
			{
				if (this.ShouldRebuild())
				{
					this.Rebuild();
				}
				return this._translation;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000D32 RID: 3378 RVA: 0x003E25EC File Offset: 0x003E07EC
		public Matrix ZoomMatrix
		{
			get
			{
				if (this.ShouldRebuild())
				{
					this.Rebuild();
				}
				return this._zoomMatrix;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000D33 RID: 3379 RVA: 0x003E2604 File Offset: 0x003E0804
		public Matrix TransformationMatrix
		{
			get
			{
				if (this.ShouldRebuild())
				{
					this.Rebuild();
				}
				return this._transformationMatrix;
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000D34 RID: 3380 RVA: 0x003E261C File Offset: 0x003E081C
		// (set) Token: 0x06000D35 RID: 3381 RVA: 0x003E2624 File Offset: 0x003E0824
		public SpriteEffects Effects
		{
			get
			{
				return this._effects;
			}
			set
			{
				if (this._effects != value)
				{
					this._effects = value;
					this._needsRebuild = true;
				}
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000D36 RID: 3382 RVA: 0x003E2640 File Offset: 0x003E0840
		public Matrix EffectMatrix
		{
			get
			{
				if (this.ShouldRebuild())
				{
					this.Rebuild();
				}
				return this._effectMatrix;
			}
		}

		// Token: 0x06000D37 RID: 3383 RVA: 0x003E2658 File Offset: 0x003E0858
		public SpriteViewMatrix(GraphicsDevice graphicsDevice)
		{
			this._graphicsDevice = graphicsDevice;
		}

		// Token: 0x06000D38 RID: 3384 RVA: 0x003E26A8 File Offset: 0x003E08A8
		private void Rebuild()
		{
			if (!this._overrideSystemViewport)
			{
				this._viewport = this._graphicsDevice.Viewport;
			}
			Vector2 vector = new Vector2((float)this._viewport.Width, (float)this._viewport.Height);
			Matrix matrix = Matrix.Identity;
			if (this._effects.HasFlag(SpriteEffects.FlipHorizontally))
			{
				matrix *= Matrix.CreateScale(-1f, 1f, 1f) * Matrix.CreateTranslation(vector.X, 0f, 0f);
			}
			if (this._effects.HasFlag(SpriteEffects.FlipVertically))
			{
				matrix *= Matrix.CreateScale(1f, -1f, 1f) * Matrix.CreateTranslation(0f, vector.Y, 0f);
			}
			Vector2 expr_E3 = vector * 0.5f;
			Vector2 vector2 = expr_E3 - expr_E3 / this._zoom;
			this._translation = vector2;
			this._zoomMatrix = Matrix.CreateTranslation(-vector2.X, -vector2.Y, 0f) * Matrix.CreateScale(this._zoom.X, this._zoom.Y, 1f);
			this._effectMatrix = matrix;
			this._transformationMatrix = matrix * this._zoomMatrix;
			this._needsRebuild = false;
		}

		// Token: 0x06000D39 RID: 3385 RVA: 0x003E2814 File Offset: 0x003E0A14
		public void SetViewportOverride(Viewport viewport)
		{
			this._viewport = viewport;
			this._overrideSystemViewport = true;
		}

		// Token: 0x06000D3A RID: 3386 RVA: 0x003E2824 File Offset: 0x003E0A24
		public void ClearViewportOverride()
		{
			this._overrideSystemViewport = false;
		}

		// Token: 0x06000D3B RID: 3387 RVA: 0x003E2830 File Offset: 0x003E0A30
		private bool ShouldRebuild()
		{
			return this._needsRebuild || (!this._overrideSystemViewport && (this._graphicsDevice.Viewport.Width != this._viewport.Width || this._graphicsDevice.Viewport.Height != this._viewport.Height));
		}

		// Token: 0x04002EE4 RID: 12004
		private Vector2 _zoom = Vector2.One;

		// Token: 0x04002EE5 RID: 12005
		private Vector2 _translation = Vector2.Zero;

		// Token: 0x04002EE6 RID: 12006
		private Matrix _zoomMatrix = Matrix.Identity;

		// Token: 0x04002EE7 RID: 12007
		private Matrix _transformationMatrix = Matrix.Identity;

		// Token: 0x04002EE8 RID: 12008
		private SpriteEffects _effects;

		// Token: 0x04002EE9 RID: 12009
		private Matrix _effectMatrix;

		// Token: 0x04002EEA RID: 12010
		private GraphicsDevice _graphicsDevice;

		// Token: 0x04002EEB RID: 12011
		private Viewport _viewport;

		// Token: 0x04002EEC RID: 12012
		private bool _overrideSystemViewport;

		// Token: 0x04002EED RID: 12013
		private bool _needsRebuild = true;
	}
}

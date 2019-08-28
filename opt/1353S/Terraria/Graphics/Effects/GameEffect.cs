using System;
using Microsoft.Xna.Framework;

namespace Terraria.Graphics.Effects
{
	// Token: 0x020000FA RID: 250
	public abstract class GameEffect
	{
		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000E0B RID: 3595 RVA: 0x003E742C File Offset: 0x003E562C
		public bool IsLoaded
		{
			get
			{
				return this._isLoaded;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000E0C RID: 3596 RVA: 0x003E7434 File Offset: 0x003E5634
		public EffectPriority Priority
		{
			get
			{
				return this._priority;
			}
		}

		// Token: 0x06000E0D RID: 3597 RVA: 0x003E743C File Offset: 0x003E563C
		public void Load()
		{
			if (this._isLoaded)
			{
				return;
			}
			this._isLoaded = true;
			this.OnLoad();
		}

		// Token: 0x06000E0E RID: 3598 RVA: 0x003E7454 File Offset: 0x003E5654
		public virtual void OnLoad()
		{
		}

		// Token: 0x06000E0F RID: 3599
		public abstract bool IsVisible();

		// Token: 0x06000E10 RID: 3600
		internal abstract void Activate(Vector2 position, params object[] args);

		// Token: 0x06000E11 RID: 3601
		internal abstract void Deactivate(params object[] args);

		// Token: 0x04002F83 RID: 12163
		public float Opacity;

		// Token: 0x04002F84 RID: 12164
		protected bool _isLoaded;

		// Token: 0x04002F85 RID: 12165
		protected EffectPriority _priority;
	}
}

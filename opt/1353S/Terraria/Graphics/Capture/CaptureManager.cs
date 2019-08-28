using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Graphics.Capture
{
	// Token: 0x020000E8 RID: 232
	public class CaptureManager
	{
		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000D7A RID: 3450 RVA: 0x003E52CC File Offset: 0x003E34CC
		public bool IsCapturing
		{
			get
			{
				return this._camera.IsCapturing;
			}
		}

		// Token: 0x06000D7B RID: 3451 RVA: 0x003E52DC File Offset: 0x003E34DC
		public CaptureManager()
		{
			this._interface = new CaptureInterface();
			this._camera = new CaptureCamera(Main.instance.GraphicsDevice);
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000D7C RID: 3452 RVA: 0x003E5304 File Offset: 0x003E3504
		// (set) Token: 0x06000D7D RID: 3453 RVA: 0x003E5314 File Offset: 0x003E3514
		public bool Active
		{
			get
			{
				return this._interface.Active;
			}
			set
			{
				if (Main.CaptureModeDisabled)
				{
					return;
				}
				if (this._interface.Active != value)
				{
					this._interface.ToggleCamera(value);
				}
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000D7E RID: 3454 RVA: 0x003E5338 File Offset: 0x003E3538
		public bool UsingMap
		{
			get
			{
				return this.Active && this._interface.UsingMap();
			}
		}

		// Token: 0x06000D7F RID: 3455 RVA: 0x003E5350 File Offset: 0x003E3550
		public void Scrolling()
		{
			this._interface.Scrolling();
		}

		// Token: 0x06000D80 RID: 3456 RVA: 0x003E5360 File Offset: 0x003E3560
		public void Update()
		{
			this._interface.Update();
		}

		// Token: 0x06000D81 RID: 3457 RVA: 0x003E5370 File Offset: 0x003E3570
		public void Draw(SpriteBatch sb)
		{
			this._interface.Draw(sb);
		}

		// Token: 0x06000D82 RID: 3458 RVA: 0x003E5380 File Offset: 0x003E3580
		public float GetProgress()
		{
			return this._camera.GetProgress();
		}

		// Token: 0x06000D83 RID: 3459 RVA: 0x003E5390 File Offset: 0x003E3590
		public void Capture()
		{
			CaptureSettings settings = new CaptureSettings
			{
				Area = new Rectangle(2660, 100, 1000, 1000),
				UseScaling = false
			};
			this.Capture(settings);
		}

		// Token: 0x06000D84 RID: 3460 RVA: 0x003E53D0 File Offset: 0x003E35D0
		public void Capture(CaptureSettings settings)
		{
			this._camera.Capture(settings);
		}

		// Token: 0x06000D85 RID: 3461 RVA: 0x003E53E0 File Offset: 0x003E35E0
		public void DrawTick()
		{
			this._camera.DrawTick();
		}

		// Token: 0x04002F2F RID: 12079
		public static CaptureManager Instance = new CaptureManager();

		// Token: 0x04002F30 RID: 12080
		private CaptureInterface _interface;

		// Token: 0x04002F31 RID: 12081
		private CaptureCamera _camera;
	}
}

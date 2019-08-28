using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Server
{
	// Token: 0x02000066 RID: 102
	public class Game : IDisposable
	{
		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000992 RID: 2450 RVA: 0x003B6BEC File Offset: 0x003B4DEC
		public GameComponentCollection Components
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000993 RID: 2451 RVA: 0x003B6BF0 File Offset: 0x003B4DF0
		// (set) Token: 0x06000994 RID: 2452 RVA: 0x003B6BF4 File Offset: 0x003B4DF4
		public ContentManager Content
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000995 RID: 2453 RVA: 0x003B6BF8 File Offset: 0x003B4DF8
		public GraphicsDevice GraphicsDevice
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000996 RID: 2454 RVA: 0x003B6BFC File Offset: 0x003B4DFC
		// (set) Token: 0x06000997 RID: 2455 RVA: 0x003B6C04 File Offset: 0x003B4E04
		public TimeSpan InactiveSleepTime
		{
			get
			{
				return TimeSpan.Zero;
			}
			set
			{
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000998 RID: 2456 RVA: 0x003B6C08 File Offset: 0x003B4E08
		public bool IsActive
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000999 RID: 2457 RVA: 0x003B6C0C File Offset: 0x003B4E0C
		// (set) Token: 0x0600099A RID: 2458 RVA: 0x003B6C10 File Offset: 0x003B4E10
		public bool IsFixedTimeStep
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x0600099B RID: 2459 RVA: 0x003B6C14 File Offset: 0x003B4E14
		// (set) Token: 0x0600099C RID: 2460 RVA: 0x003B6C18 File Offset: 0x003B4E18
		public bool IsMouseVisible
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x0600099D RID: 2461 RVA: 0x003B6C1C File Offset: 0x003B4E1C
		public LaunchParameters LaunchParameters
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x0600099E RID: 2462 RVA: 0x003B6C20 File Offset: 0x003B4E20
		public GameServiceContainer Services
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x0600099F RID: 2463 RVA: 0x003B6C24 File Offset: 0x003B4E24
		// (set) Token: 0x060009A0 RID: 2464 RVA: 0x003B6C2C File Offset: 0x003B4E2C
		public TimeSpan TargetElapsedTime
		{
			get
			{
				return TimeSpan.Zero;
			}
			set
			{
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060009A1 RID: 2465 RVA: 0x003B6C30 File Offset: 0x003B4E30
		public GameWindow Window
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060009A2 RID: 2466 RVA: 0x003B6C34 File Offset: 0x003B4E34
		// (remove) Token: 0x060009A3 RID: 2467 RVA: 0x003B6C6C File Offset: 0x003B4E6C
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event EventHandler<EventArgs> Activated;

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060009A4 RID: 2468 RVA: 0x003B6CA4 File Offset: 0x003B4EA4
		// (remove) Token: 0x060009A5 RID: 2469 RVA: 0x003B6CDC File Offset: 0x003B4EDC
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event EventHandler<EventArgs> Deactivated;

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x060009A6 RID: 2470 RVA: 0x003B6D14 File Offset: 0x003B4F14
		// (remove) Token: 0x060009A7 RID: 2471 RVA: 0x003B6D4C File Offset: 0x003B4F4C
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event EventHandler<EventArgs> Disposed;

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x060009A8 RID: 2472 RVA: 0x003B6D84 File Offset: 0x003B4F84
		// (remove) Token: 0x060009A9 RID: 2473 RVA: 0x003B6DBC File Offset: 0x003B4FBC
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event EventHandler<EventArgs> Exiting;

		// Token: 0x060009AA RID: 2474 RVA: 0x003B6DF4 File Offset: 0x003B4FF4
		protected virtual bool BeginDraw()
		{
			return true;
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x003B6DF8 File Offset: 0x003B4FF8
		protected virtual void BeginRun()
		{
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x003B6DFC File Offset: 0x003B4FFC
		public void Dispose()
		{
		}

		// Token: 0x060009AD RID: 2477 RVA: 0x003B6E00 File Offset: 0x003B5000
		protected virtual void Dispose(bool disposing)
		{
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x003B6E04 File Offset: 0x003B5004
		protected virtual void Draw(GameTime gameTime)
		{
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x003B6E08 File Offset: 0x003B5008
		protected virtual void EndDraw()
		{
		}

		// Token: 0x060009B0 RID: 2480 RVA: 0x003B6E0C File Offset: 0x003B500C
		protected virtual void EndRun()
		{
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x003B6E10 File Offset: 0x003B5010
		public void Exit()
		{
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x003B6E14 File Offset: 0x003B5014
		protected virtual void Initialize()
		{
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x003B6E18 File Offset: 0x003B5018
		protected virtual void LoadContent()
		{
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x003B6E1C File Offset: 0x003B501C
		protected virtual void OnActivated(object sender, EventArgs args)
		{
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x003B6E20 File Offset: 0x003B5020
		protected virtual void OnDeactivated(object sender, EventArgs args)
		{
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x003B6E24 File Offset: 0x003B5024
		protected virtual void OnExiting(object sender, EventArgs args)
		{
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x003B6E28 File Offset: 0x003B5028
		public void ResetElapsedTime()
		{
		}

		// Token: 0x060009B8 RID: 2488 RVA: 0x003B6E2C File Offset: 0x003B502C
		public void Run()
		{
		}

		// Token: 0x060009B9 RID: 2489 RVA: 0x003B6E30 File Offset: 0x003B5030
		public void RunOneFrame()
		{
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x003B6E34 File Offset: 0x003B5034
		protected virtual bool ShowMissingRequirementMessage(Exception exception)
		{
			return true;
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x003B6E38 File Offset: 0x003B5038
		public void SuppressDraw()
		{
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x003B6E3C File Offset: 0x003B503C
		public void Tick()
		{
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x003B6E40 File Offset: 0x003B5040
		protected virtual void UnloadContent()
		{
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x003B6E44 File Offset: 0x003B5044
		protected virtual void Update(GameTime gameTime)
		{
		}
	}
}

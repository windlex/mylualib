using System;

namespace Terraria.UI
{
	// Token: 0x020000A3 RID: 163
	public class LegacyGameInterfaceLayer : GameInterfaceLayer
	{
		// Token: 0x06000BAB RID: 2987 RVA: 0x003CF570 File Offset: 0x003CD770
		public LegacyGameInterfaceLayer(string name, GameInterfaceDrawMethod drawMethod, InterfaceScaleType scaleType = InterfaceScaleType.Game) : base(name, scaleType)
		{
			this._drawMethod = drawMethod;
		}

		// Token: 0x06000BAC RID: 2988 RVA: 0x003CF584 File Offset: 0x003CD784
		protected override bool DrawSelf()
		{
			return this._drawMethod();
		}

		// Token: 0x04000EB4 RID: 3764
		private GameInterfaceDrawMethod _drawMethod;
	}
}

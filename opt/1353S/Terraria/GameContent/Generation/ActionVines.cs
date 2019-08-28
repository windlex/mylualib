using System;
using Microsoft.Xna.Framework;
using Terraria.World.Generation;

namespace Terraria.GameContent.Generation
{
	// Token: 0x02000113 RID: 275
	public class ActionVines : GenAction
	{
		// Token: 0x06000F4A RID: 3914 RVA: 0x003F3E40 File Offset: 0x003F2040
		public ActionVines(int minLength = 6, int maxLength = 10, int vineId = 52)
		{
			this._minLength = minLength;
			this._maxLength = maxLength;
			this._vineId = vineId;
		}

		// Token: 0x06000F4B RID: 3915 RVA: 0x003F3E60 File Offset: 0x003F2060
		public override bool Apply(Point origin, int x, int y, params object[] args)
		{
			int num = GenBase._random.Next(this._minLength, this._maxLength + 1);
			int num2 = 0;
			while (num2 < num && !GenBase._tiles[x, y + num2].active())
			{
				GenBase._tiles[x, y + num2].type = (ushort)this._vineId;
				GenBase._tiles[x, y + num2].active(true);
				num2++;
			}
			return num2 > 0 && base.UnitApply(origin, x, y, args);
		}

		// Token: 0x0400304C RID: 12364
		private int _minLength;

		// Token: 0x0400304D RID: 12365
		private int _maxLength;

		// Token: 0x0400304E RID: 12366
		private int _vineId;
	}
}

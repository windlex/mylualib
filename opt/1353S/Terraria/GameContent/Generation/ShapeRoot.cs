using System;
using Microsoft.Xna.Framework;
using Terraria.World.Generation;

namespace Terraria.GameContent.Generation
{
	// Token: 0x02000118 RID: 280
	public class ShapeRoot : GenShape
	{
		// Token: 0x06000F5E RID: 3934 RVA: 0x003F4460 File Offset: 0x003F2660
		public ShapeRoot(float angle, float distance = 10f, float startingSize = 4f, float endingSize = 1f)
		{
			this._angle = angle;
			this._distance = distance;
			this._startingSize = startingSize;
			this._endingSize = endingSize;
		}

		// Token: 0x06000F5F RID: 3935 RVA: 0x003F4488 File Offset: 0x003F2688
		private bool DoRoot(Point origin, GenAction action, float angle, float distance, float startingSize)
		{
			float num = (float)origin.X;
			float num2 = (float)origin.Y;
			for (float num3 = 0f; num3 < distance * 0.85f; num3 += 1f)
			{
				float num4 = num3 / distance;
				float num5 = MathHelper.Lerp(startingSize, this._endingSize, num4);
				num += (float)Math.Cos((double)angle);
				num2 += (float)Math.Sin((double)angle);
				angle += GenBase._random.NextFloat() - 0.5f + GenBase._random.NextFloat() * (this._angle - 1.57079637f) * 0.1f * (1f - num4);
				angle = angle * 0.4f + 0.45f * MathHelper.Clamp(angle, this._angle - 2f * (1f - 0.5f * num4), this._angle + 2f * (1f - 0.5f * num4)) + MathHelper.Lerp(this._angle, 1.57079637f, num4) * 0.15f;
				for (int i = 0; i < (int)num5; i++)
				{
					for (int j = 0; j < (int)num5; j++)
					{
						if (!base.UnitApply(action, origin, (int)num + i, (int)num2 + j, new object[0]) && this._quitOnFail)
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		// Token: 0x06000F60 RID: 3936 RVA: 0x003F45D8 File Offset: 0x003F27D8
		public override bool Perform(Point origin, GenAction action)
		{
			return this.DoRoot(origin, action, this._angle, this._distance, this._startingSize);
		}

		// Token: 0x04003054 RID: 12372
		private float _angle;

		// Token: 0x04003055 RID: 12373
		private float _startingSize;

		// Token: 0x04003056 RID: 12374
		private float _endingSize;

		// Token: 0x04003057 RID: 12375
		private float _distance;
	}
}

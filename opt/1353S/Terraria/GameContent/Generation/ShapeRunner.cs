using System;
using Microsoft.Xna.Framework;
using Terraria.World.Generation;

namespace Terraria.GameContent.Generation
{
	// Token: 0x0200011A RID: 282
	public class ShapeRunner : GenShape
	{
		// Token: 0x06000F6A RID: 3946 RVA: 0x003F4CF0 File Offset: 0x003F2EF0
		public ShapeRunner(float strength, int steps, Vector2 velocity)
		{
			this._startStrength = strength;
			this._steps = steps;
			this._startVelocity = velocity;
		}

		// Token: 0x06000F6B RID: 3947 RVA: 0x003F4D10 File Offset: 0x003F2F10
		public override bool Perform(Point origin, GenAction action)
		{
			float num = (float)this._steps;
			float num2 = (float)this._steps;
			double num3 = (double)this._startStrength;
			Vector2 vector = new Vector2((float)origin.X, (float)origin.Y);
			Vector2 vector2 = (this._startVelocity == Vector2.Zero) ? Utils.RandomVector2(GenBase._random, -1f, 1f) : this._startVelocity;
			while (num > 0f && num3 > 0.0)
			{
				num3 = (double)(this._startStrength * (num / num2));
				num -= 1f;
				int arg_EC_0 = Math.Max(1, (int)((double)vector.X - num3 * 0.5));
				int num4 = Math.Max(1, (int)((double)vector.Y - num3 * 0.5));
				int num5 = Math.Min(GenBase._worldWidth, (int)((double)vector.X + num3 * 0.5));
				int num6 = Math.Min(GenBase._worldHeight, (int)((double)vector.Y + num3 * 0.5));
				for (int i = arg_EC_0; i < num5; i++)
				{
					for (int j = num4; j < num6; j++)
					{
						if ((double)(Math.Abs((float)i - vector.X) + Math.Abs((float)j - vector.Y)) < num3 * 0.5 * (1.0 + (double)GenBase._random.Next(-10, 11) * 0.015))
						{
							base.UnitApply(action, origin, i, j, new object[0]);
						}
					}
				}
				int num7 = (int)(num3 / 50.0) + 1;
				num -= (float)num7;
				vector += vector2;
				for (int k = 0; k < num7; k++)
				{
					vector += vector2;
					vector2 += Utils.RandomVector2(GenBase._random, -0.5f, 0.5f);
				}
				vector2 += Utils.RandomVector2(GenBase._random, -0.5f, 0.5f);
				vector2 = Vector2.Clamp(vector2, -Vector2.One, Vector2.One);
			}
			return true;
		}

		// Token: 0x0400305F RID: 12383
		private float _startStrength;

		// Token: 0x04003060 RID: 12384
		private int _steps;

		// Token: 0x04003061 RID: 12385
		private Vector2 _startVelocity;
	}
}

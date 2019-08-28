using System;
using Microsoft.Xna.Framework;

namespace Terraria.World.Generation
{
	// Token: 0x02000059 RID: 89
	public static class Shapes
	{
		// Token: 0x0200021A RID: 538
		public class Circle : GenShape
		{
			// Token: 0x06001552 RID: 5458 RVA: 0x0042FE50 File Offset: 0x0042E050
			public Circle(int radius)
			{
				this._verticalRadius = radius;
				this._horizontalRadius = radius;
			}

			// Token: 0x06001553 RID: 5459 RVA: 0x0042FE68 File Offset: 0x0042E068
			public Circle(int horizontalRadius, int verticalRadius)
			{
				this._horizontalRadius = horizontalRadius;
				this._verticalRadius = verticalRadius;
			}

			// Token: 0x06001554 RID: 5460 RVA: 0x0042FE80 File Offset: 0x0042E080
			public override bool Perform(Point origin, GenAction action)
			{
				int num = (this._horizontalRadius + 1) * (this._horizontalRadius + 1);
				for (int i = origin.Y - this._verticalRadius; i <= origin.Y + this._verticalRadius; i++)
				{
					float num2 = (float)this._horizontalRadius / (float)this._verticalRadius * (float)(i - origin.Y);
					int num3 = Math.Min(this._horizontalRadius, (int)Math.Sqrt((double)((float)num - num2 * num2)));
					for (int j = origin.X - num3; j <= origin.X + num3; j++)
					{
						if (!base.UnitApply(action, origin, j, i, new object[0]) && this._quitOnFail)
						{
							return false;
						}
					}
				}
				return true;
			}

			// Token: 0x0400377E RID: 14206
			private int _verticalRadius;

			// Token: 0x0400377F RID: 14207
			private int _horizontalRadius;
		}

		// Token: 0x0200021B RID: 539
		public class HalfCircle : GenShape
		{
			// Token: 0x06001555 RID: 5461 RVA: 0x0042FF38 File Offset: 0x0042E138
			public HalfCircle(int radius)
			{
				this._radius = radius;
			}

			// Token: 0x06001556 RID: 5462 RVA: 0x0042FF48 File Offset: 0x0042E148
			public override bool Perform(Point origin, GenAction action)
			{
				int num = (this._radius + 1) * (this._radius + 1);
				for (int i = origin.Y - this._radius; i <= origin.Y; i++)
				{
					int num2 = Math.Min(this._radius, (int)Math.Sqrt((double)(num - (i - origin.Y) * (i - origin.Y))));
					for (int j = origin.X - num2; j <= origin.X + num2; j++)
					{
						if (!base.UnitApply(action, origin, j, i, new object[0]) && this._quitOnFail)
						{
							return false;
						}
					}
				}
				return true;
			}

			// Token: 0x04003780 RID: 14208
			private int _radius;
		}

		// Token: 0x0200021C RID: 540
		public class Slime : GenShape
		{
			// Token: 0x06001557 RID: 5463 RVA: 0x0042FFE4 File Offset: 0x0042E1E4
			public Slime(int radius)
			{
				this._radius = radius;
				this._xScale = 1f;
				this._yScale = 1f;
			}

			// Token: 0x06001558 RID: 5464 RVA: 0x0043000C File Offset: 0x0042E20C
			public Slime(int radius, float xScale, float yScale)
			{
				this._radius = radius;
				this._xScale = xScale;
				this._yScale = yScale;
			}

			// Token: 0x06001559 RID: 5465 RVA: 0x0043002C File Offset: 0x0042E22C
			public override bool Perform(Point origin, GenAction action)
			{
				float num = (float)this._radius;
				int num2 = (this._radius + 1) * (this._radius + 1);
				for (int i = origin.Y - (int)(num * this._yScale); i <= origin.Y; i++)
				{
					float num3 = (float)(i - origin.Y) / this._yScale;
					int num4 = (int)Math.Min((float)this._radius * this._xScale, this._xScale * (float)Math.Sqrt((double)((float)num2 - num3 * num3)));
					for (int j = origin.X - num4; j <= origin.X + num4; j++)
					{
						if (!base.UnitApply(action, origin, j, i, new object[0]) && this._quitOnFail)
						{
							return false;
						}
					}
				}
				for (int k = origin.Y + 1; k <= origin.Y + (int)(num * this._yScale * 0.5f) - 1; k++)
				{
					float num5 = (float)(k - origin.Y) * (2f / this._yScale);
					int num6 = (int)Math.Min((float)this._radius * this._xScale, this._xScale * (float)Math.Sqrt((double)((float)num2 - num5 * num5)));
					for (int l = origin.X - num6; l <= origin.X + num6; l++)
					{
						if (!base.UnitApply(action, origin, l, k, new object[0]) && this._quitOnFail)
						{
							return false;
						}
					}
				}
				return true;
			}

			// Token: 0x04003781 RID: 14209
			private int _radius;

			// Token: 0x04003782 RID: 14210
			private float _xScale;

			// Token: 0x04003783 RID: 14211
			private float _yScale;
		}

		// Token: 0x0200021D RID: 541
		public class Rectangle : GenShape
		{
			// Token: 0x0600155A RID: 5466 RVA: 0x004301A8 File Offset: 0x0042E3A8
			public Rectangle(int width, int height)
			{
				this._width = width;
				this._height = height;
			}

			// Token: 0x0600155B RID: 5467 RVA: 0x004301C0 File Offset: 0x0042E3C0
			public override bool Perform(Point origin, GenAction action)
			{
				for (int i = origin.X; i < origin.X + this._width; i++)
				{
					for (int j = origin.Y; j < origin.Y + this._height; j++)
					{
						if (!base.UnitApply(action, origin, i, j, new object[0]) && this._quitOnFail)
						{
							return false;
						}
					}
				}
				return true;
			}

			// Token: 0x04003784 RID: 14212
			private int _width;

			// Token: 0x04003785 RID: 14213
			private int _height;
		}

		// Token: 0x0200021E RID: 542
		public class Tail : GenShape
		{
			// Token: 0x0600155C RID: 5468 RVA: 0x00430224 File Offset: 0x0042E424
			public Tail(float width, Vector2 endOffset)
			{
				this._width = width * 16f;
				this._endOffset = endOffset * 16f;
			}

			// Token: 0x0600155D RID: 5469 RVA: 0x0043024C File Offset: 0x0042E44C
			public override bool Perform(Point origin, GenAction action)
			{
				Vector2 expr_3C = new Vector2((float)(origin.X << 4), (float)(origin.Y << 4));
				return Utils.PlotTileTale(expr_3C, expr_3C + this._endOffset, this._width, (int x, int y) => this.UnitApply(action, origin, x, y, new object[0]) || !this._quitOnFail);
			}

			// Token: 0x04003786 RID: 14214
			private float _width;

			// Token: 0x04003787 RID: 14215
			private Vector2 _endOffset;
		}

		// Token: 0x0200021F RID: 543
		public class Mound : GenShape
		{
			// Token: 0x0600155E RID: 5470 RVA: 0x004302B8 File Offset: 0x0042E4B8
			public Mound(int halfWidth, int height)
			{
				this._halfWidth = halfWidth;
				this._height = height;
			}

			// Token: 0x0600155F RID: 5471 RVA: 0x004302D0 File Offset: 0x0042E4D0
			public override bool Perform(Point origin, GenAction action)
			{
				int arg_06_0 = this._height;
				float num = (float)this._halfWidth;
				for (int i = -this._halfWidth; i <= this._halfWidth; i++)
				{
					int num2 = Math.Min(this._height, (int)(-((float)(this._height + 1) / (num * num)) * ((float)i + num) * ((float)i - num)));
					for (int j = 0; j < num2; j++)
					{
						if (!base.UnitApply(action, origin, i + origin.X, origin.Y - j, new object[0]) && this._quitOnFail)
						{
							return false;
						}
					}
				}
				return true;
			}

			// Token: 0x04003788 RID: 14216
			private int _halfWidth;

			// Token: 0x04003789 RID: 14217
			private int _height;
		}
	}
}

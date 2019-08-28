using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.World.Generation;

namespace Terraria.GameContent.Generation
{
	// Token: 0x02000116 RID: 278
	public class ShapeBranch : GenShape
	{
		// Token: 0x06000F56 RID: 3926 RVA: 0x003F3325 File Offset: 0x003F1525
		public ShapeBranch()
		{
			this._offset = new Point(10, -5);
		}

		// Token: 0x06000F57 RID: 3927 RVA: 0x003F333C File Offset: 0x003F153C
		public ShapeBranch(Point offset)
		{
			this._offset = offset;
		}

		// Token: 0x06000F58 RID: 3928 RVA: 0x003F334B File Offset: 0x003F154B
		public ShapeBranch(double angle, double distance)
		{
			this._offset = new Point((int)(Math.Cos(angle) * distance), (int)(Math.Sin(angle) * distance));
		}

		// Token: 0x06000F5B RID: 3931 RVA: 0x003F363E File Offset: 0x003F183E
		public ShapeBranch OutputEndpoints(List<Point> endpoints)
		{
			this._endPoints = endpoints;
			return this;
		}

		// Token: 0x06000F5A RID: 3930 RVA: 0x003F3410 File Offset: 0x003F1610
		public override bool Perform(Point origin, GenAction action)
		{
			Vector2 vector = new Vector2((float)this._offset.X, (float)this._offset.Y);
			float num = vector.Length();
			int num2 = (int)(num / 6f);
			if (this._endPoints != null)
			{
				this._endPoints.Add(new Point(origin.X + this._offset.X, origin.Y + this._offset.Y));
			}
			if (!this.PerformSegment(origin, action, origin, new Point(origin.X + this._offset.X, origin.Y + this._offset.Y), num2))
			{
				return false;
			}
			int num3 = (int)(num / 8f);
			for (int i = 0; i < num3; i++)
			{
				float num4 = ((float)i + 1f) / ((float)num3 + 1f);
				Point point = new Point((int)(num4 * (float)this._offset.X), (int)(num4 * (float)this._offset.Y));
				Vector2 vector2 = new Vector2((float)(this._offset.X - point.X), (float)(this._offset.Y - point.Y));
				vector2 = vector2.RotatedBy((double)(((float)GenBase._random.NextDouble() * 0.5f + 1f) * (float)((GenBase._random.Next(2) == 0) ? -1 : 1)), default(Vector2)) * 0.75f;
				Point point2 = new Point((int)vector2.X + point.X, (int)vector2.Y + point.Y);
				if (this._endPoints != null)
				{
					this._endPoints.Add(new Point(point2.X + origin.X, point2.Y + origin.Y));
				}
				if (!this.PerformSegment(origin, action, new Point(point.X + origin.X, point.Y + origin.Y), new Point(point2.X + origin.X, point2.Y + origin.Y), num2 - 1))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000F59 RID: 3929 RVA: 0x003F3370 File Offset: 0x003F1570
		private bool PerformSegment(Point origin, GenAction action, Point start, Point end, int size)
		{
			size = Math.Max(1, size);
			for (int index1 = -(size >> 1); index1 < size - (size >> 1); ++index1)
			{
				for (int index2 = -(size >> 1); index2 < size - (size >> 1); ++index2)
				{
					if (!Utils.PlotLine(new Point(start.X + index1, start.Y + index2), end, (Utils.PerLinePoint)((tileX, tileY) =>
					{
						if (!this.UnitApply(action, origin, tileX, tileY))
							return !this._quitOnFail;
						return true;
					}), false))
						return false;
				}
			}
			return true;
		}

		// Token: 0x04003052 RID: 12370
		private List<Point> _endPoints;

		// Token: 0x04003051 RID: 12369
		private Point _offset;
	}
}

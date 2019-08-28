using System;
using Microsoft.Xna.Framework;

namespace Terraria.DataStructures
{
	// Token: 0x02000192 RID: 402
	public struct Point16
	{
		// Token: 0x060012F7 RID: 4855 RVA: 0x00419C8C File Offset: 0x00417E8C
		public Point16(Point point)
		{
			this.X = (short)point.X;
			this.Y = (short)point.Y;
		}

		// Token: 0x060012F8 RID: 4856 RVA: 0x00419CA8 File Offset: 0x00417EA8
		public Point16(int X, int Y)
		{
			this.X = (short)X;
			this.Y = (short)Y;
		}

		// Token: 0x060012F9 RID: 4857 RVA: 0x00419CBC File Offset: 0x00417EBC
		public Point16(short X, short Y)
		{
			this.X = X;
			this.Y = Y;
		}

		// Token: 0x060012FA RID: 4858 RVA: 0x00419CCC File Offset: 0x00417ECC
		public static Point16 Max(int firstX, int firstY, int secondX, int secondY)
		{
			return new Point16((firstX > secondX) ? firstX : secondX, (firstY > secondY) ? firstY : secondY);
		}

		// Token: 0x060012FB RID: 4859 RVA: 0x00419CE4 File Offset: 0x00417EE4
		public Point16 Max(int compareX, int compareY)
		{
			return new Point16(((int)this.X > compareX) ? ((int)this.X) : compareX, ((int)this.Y > compareY) ? ((int)this.Y) : compareY);
		}

		// Token: 0x060012FC RID: 4860 RVA: 0x00419D10 File Offset: 0x00417F10
		public Point16 Max(Point16 compareTo)
		{
			return new Point16((this.X > compareTo.X) ? this.X : compareTo.X, (this.Y > compareTo.Y) ? this.Y : compareTo.Y);
		}

		// Token: 0x060012FD RID: 4861 RVA: 0x00419D50 File Offset: 0x00417F50
		public static bool operator ==(Point16 first, Point16 second)
		{
			return first.X == second.X && first.Y == second.Y;
		}

		// Token: 0x060012FE RID: 4862 RVA: 0x00419D70 File Offset: 0x00417F70
		public static bool operator !=(Point16 first, Point16 second)
		{
			return first.X != second.X || first.Y != second.Y;
		}

		// Token: 0x060012FF RID: 4863 RVA: 0x00419D94 File Offset: 0x00417F94
		public override bool Equals(object obj)
		{
			Point16 point = (Point16)obj;
			return this.X == point.X && this.Y == point.Y;
		}

		// Token: 0x06001300 RID: 4864 RVA: 0x00419DC8 File Offset: 0x00417FC8
		public override int GetHashCode()
		{
			return (int)this.X << 16 | (int)((ushort)this.Y);
		}

		// Token: 0x06001301 RID: 4865 RVA: 0x00419DDC File Offset: 0x00417FDC
		public override string ToString()
		{
			return string.Format("{{{0}, {1}}}", this.X, this.Y);
		}

		// Token: 0x04003493 RID: 13459
		public readonly short X;

		// Token: 0x04003494 RID: 13460
		public readonly short Y;

		// Token: 0x04003495 RID: 13461
		public static Point16 Zero = new Point16(0, 0);

		// Token: 0x04003496 RID: 13462
		public static Point16 NegativeOne = new Point16(-1, -1);
	}
}

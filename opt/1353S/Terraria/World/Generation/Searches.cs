using System;
using Microsoft.Xna.Framework;

namespace Terraria.World.Generation
{
	// Token: 0x02000053 RID: 83
	public static class Searches
	{
		// Token: 0x06000924 RID: 2340 RVA: 0x003B52E4 File Offset: 0x003B34E4
		public static GenSearch Chain(GenSearch search, params GenCondition[] conditions)
		{
			return search.Conditions(conditions);
		}

		// Token: 0x02000215 RID: 533
		public class Left : GenSearch
		{
			// Token: 0x06001548 RID: 5448 RVA: 0x0042FC54 File Offset: 0x0042DE54
			public Left(int maxDistance)
			{
				this._maxDistance = maxDistance;
			}

			// Token: 0x06001549 RID: 5449 RVA: 0x0042FC64 File Offset: 0x0042DE64
			public override Point Find(Point origin)
			{
				for (int i = 0; i < this._maxDistance; i++)
				{
					if (base.Check(origin.X - i, origin.Y))
					{
						return new Point(origin.X - i, origin.Y);
					}
				}
				return GenSearch.NOT_FOUND;
			}

			// Token: 0x04003778 RID: 14200
			private int _maxDistance;
		}

		// Token: 0x02000216 RID: 534
		public class Right : GenSearch
		{
			// Token: 0x0600154A RID: 5450 RVA: 0x0042FCB4 File Offset: 0x0042DEB4
			public Right(int maxDistance)
			{
				this._maxDistance = maxDistance;
			}

			// Token: 0x0600154B RID: 5451 RVA: 0x0042FCC4 File Offset: 0x0042DEC4
			public override Point Find(Point origin)
			{
				for (int i = 0; i < this._maxDistance; i++)
				{
					if (base.Check(origin.X + i, origin.Y))
					{
						return new Point(origin.X + i, origin.Y);
					}
				}
				return GenSearch.NOT_FOUND;
			}

			// Token: 0x04003779 RID: 14201
			private int _maxDistance;
		}

		// Token: 0x02000217 RID: 535
		public class Down : GenSearch
		{
			// Token: 0x0600154C RID: 5452 RVA: 0x0042FD14 File Offset: 0x0042DF14
			public Down(int maxDistance)
			{
				this._maxDistance = maxDistance;
			}

			// Token: 0x0600154D RID: 5453 RVA: 0x0042FD24 File Offset: 0x0042DF24
			public override Point Find(Point origin)
			{
				for (int i = 0; i < this._maxDistance; i++)
				{
					if (base.Check(origin.X, origin.Y + i))
					{
						return new Point(origin.X, origin.Y + i);
					}
				}
				return GenSearch.NOT_FOUND;
			}

			// Token: 0x0400377A RID: 14202
			private int _maxDistance;
		}

		// Token: 0x02000218 RID: 536
		public class Up : GenSearch
		{
			// Token: 0x0600154E RID: 5454 RVA: 0x0042FD74 File Offset: 0x0042DF74
			public Up(int maxDistance)
			{
				this._maxDistance = maxDistance;
			}

			// Token: 0x0600154F RID: 5455 RVA: 0x0042FD84 File Offset: 0x0042DF84
			public override Point Find(Point origin)
			{
				for (int i = 0; i < this._maxDistance; i++)
				{
					if (base.Check(origin.X, origin.Y - i))
					{
						return new Point(origin.X, origin.Y - i);
					}
				}
				return GenSearch.NOT_FOUND;
			}

			// Token: 0x0400377B RID: 14203
			private int _maxDistance;
		}

		// Token: 0x02000219 RID: 537
		public class Rectangle : GenSearch
		{
			// Token: 0x06001550 RID: 5456 RVA: 0x0042FDD4 File Offset: 0x0042DFD4
			public Rectangle(int width, int height)
			{
				this._width = width;
				this._height = height;
			}

			// Token: 0x06001551 RID: 5457 RVA: 0x0042FDEC File Offset: 0x0042DFEC
			public override Point Find(Point origin)
			{
				for (int i = 0; i < this._width; i++)
				{
					for (int j = 0; j < this._height; j++)
					{
						if (base.Check(origin.X + i, origin.Y + j))
						{
							return new Point(origin.X + i, origin.Y + j);
						}
					}
				}
				return GenSearch.NOT_FOUND;
			}

			// Token: 0x0400377C RID: 14204
			private int _width;

			// Token: 0x0400377D RID: 14205
			private int _height;
		}
	}
}

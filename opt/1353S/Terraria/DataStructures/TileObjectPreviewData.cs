using System;

namespace Terraria.DataStructures
{
	// Token: 0x02000190 RID: 400
	public class TileObjectPreviewData
	{
		// Token: 0x060012DB RID: 4827 RVA: 0x004196C8 File Offset: 0x004178C8
		public void Reset()
		{
			this._active = false;
			this._size = Point16.Zero;
			this._coordinates = Point16.Zero;
			this._objectStart = Point16.Zero;
			this._percentValid = 0f;
			this._type = 0;
			this._style = 0;
			this._alternate = -1;
			this._random = -1;
			if (this._data != null)
			{
				Array.Clear(this._data, 0, (int)(this._dataSize.X * this._dataSize.Y));
			}
		}

		// Token: 0x060012DC RID: 4828 RVA: 0x00419750 File Offset: 0x00417950
		public void CopyFrom(TileObjectPreviewData copy)
		{
			this._type = copy._type;
			this._style = copy._style;
			this._alternate = copy._alternate;
			this._random = copy._random;
			this._active = copy._active;
			this._size = copy._size;
			this._coordinates = copy._coordinates;
			this._objectStart = copy._objectStart;
			this._percentValid = copy._percentValid;
			if (this._data == null)
			{
				this._data = new int[(int)copy._dataSize.X, (int)copy._dataSize.Y];
				this._dataSize = copy._dataSize;
			}
			else
			{
				Array.Clear(this._data, 0, this._data.Length);
			}
			if (this._dataSize.X < copy._dataSize.X || this._dataSize.Y < copy._dataSize.Y)
			{
				int num = (int)((copy._dataSize.X > this._dataSize.X) ? copy._dataSize.X : this._dataSize.X);
				int num2 = (int)((copy._dataSize.Y > this._dataSize.Y) ? copy._dataSize.Y : this._dataSize.Y);
				this._data = new int[num, num2];
				this._dataSize = new Point16(num, num2);
			}
			for (int i = 0; i < (int)copy._dataSize.X; i++)
			{
				for (int j = 0; j < (int)copy._dataSize.Y; j++)
				{
					this._data[i, j] = copy._data[i, j];
				}
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x060012DD RID: 4829 RVA: 0x0041990C File Offset: 0x00417B0C
		// (set) Token: 0x060012DE RID: 4830 RVA: 0x00419914 File Offset: 0x00417B14
		public bool Active
		{
			get
			{
				return this._active;
			}
			set
			{
				this._active = value;
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x060012DF RID: 4831 RVA: 0x00419920 File Offset: 0x00417B20
		// (set) Token: 0x060012E0 RID: 4832 RVA: 0x00419928 File Offset: 0x00417B28
		public ushort Type
		{
			get
			{
				return this._type;
			}
			set
			{
				this._type = value;
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x060012E1 RID: 4833 RVA: 0x00419934 File Offset: 0x00417B34
		// (set) Token: 0x060012E2 RID: 4834 RVA: 0x0041993C File Offset: 0x00417B3C
		public short Style
		{
			get
			{
				return this._style;
			}
			set
			{
				this._style = value;
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x060012E3 RID: 4835 RVA: 0x00419948 File Offset: 0x00417B48
		// (set) Token: 0x060012E4 RID: 4836 RVA: 0x00419950 File Offset: 0x00417B50
		public int Alternate
		{
			get
			{
				return this._alternate;
			}
			set
			{
				this._alternate = value;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x060012E5 RID: 4837 RVA: 0x0041995C File Offset: 0x00417B5C
		// (set) Token: 0x060012E6 RID: 4838 RVA: 0x00419964 File Offset: 0x00417B64
		public int Random
		{
			get
			{
				return this._random;
			}
			set
			{
				this._random = value;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x060012E7 RID: 4839 RVA: 0x00419970 File Offset: 0x00417B70
		// (set) Token: 0x060012E8 RID: 4840 RVA: 0x00419978 File Offset: 0x00417B78
		public Point16 Size
		{
			get
			{
				return this._size;
			}
			set
			{
				if (value.X <= 0 || value.Y <= 0)
				{
					throw new FormatException("PlacementData.Size was set to a negative value.");
				}
				if (value.X > this._dataSize.X || value.Y > this._dataSize.Y)
				{
					int num = (int)((value.X > this._dataSize.X) ? value.X : this._dataSize.X);
					int num2 = (int)((value.Y > this._dataSize.Y) ? value.Y : this._dataSize.Y);
					int[,] array = new int[num, num2];
					if (this._data != null)
					{
						for (int i = 0; i < (int)this._dataSize.X; i++)
						{
							for (int j = 0; j < (int)this._dataSize.Y; j++)
							{
								array[i, j] = this._data[i, j];
							}
						}
					}
					this._data = array;
					this._dataSize = new Point16(num, num2);
				}
				this._size = value;
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x060012E9 RID: 4841 RVA: 0x00419A8C File Offset: 0x00417C8C
		// (set) Token: 0x060012EA RID: 4842 RVA: 0x00419A94 File Offset: 0x00417C94
		public Point16 Coordinates
		{
			get
			{
				return this._coordinates;
			}
			set
			{
				this._coordinates = value;
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x060012EB RID: 4843 RVA: 0x00419AA0 File Offset: 0x00417CA0
		// (set) Token: 0x060012EC RID: 4844 RVA: 0x00419AA8 File Offset: 0x00417CA8
		public Point16 ObjectStart
		{
			get
			{
				return this._objectStart;
			}
			set
			{
				this._objectStart = value;
			}
		}

		// Token: 0x060012ED RID: 4845 RVA: 0x00419AB4 File Offset: 0x00417CB4
		public void AllInvalid()
		{
			for (int i = 0; i < (int)this._size.X; i++)
			{
				for (int j = 0; j < (int)this._size.Y; j++)
				{
					if (this._data[i, j] != 0)
					{
						this._data[i, j] = 2;
					}
				}
			}
		}

		// Token: 0x17000194 RID: 404
		public int this[int x, int y]
		{
			get
			{
				if (x < 0 || y < 0 || x >= (int)this._size.X || y >= (int)this._size.Y)
				{
					throw new IndexOutOfRangeException();
				}
				return this._data[x, y];
			}
			set
			{
				if (x < 0 || y < 0 || x >= (int)this._size.X || y >= (int)this._size.Y)
				{
					throw new IndexOutOfRangeException();
				}
				this._data[x, y] = value;
			}
		}

		// Token: 0x0400347D RID: 13437
		private ushort _type;

		// Token: 0x0400347E RID: 13438
		private short _style;

		// Token: 0x0400347F RID: 13439
		private int _alternate;

		// Token: 0x04003480 RID: 13440
		private int _random;

		// Token: 0x04003481 RID: 13441
		private bool _active;

		// Token: 0x04003482 RID: 13442
		private Point16 _size;

		// Token: 0x04003483 RID: 13443
		private Point16 _coordinates;

		// Token: 0x04003484 RID: 13444
		private Point16 _objectStart;

		// Token: 0x04003485 RID: 13445
		private int[,] _data;

		// Token: 0x04003486 RID: 13446
		private Point16 _dataSize;

		// Token: 0x04003487 RID: 13447
		private float _percentValid;

		// Token: 0x04003488 RID: 13448
		public static TileObjectPreviewData placementCache;

		// Token: 0x04003489 RID: 13449
		public static TileObjectPreviewData randomCache;

		// Token: 0x0400348A RID: 13450
		public const int None = 0;

		// Token: 0x0400348B RID: 13451
		public const int ValidSpot = 1;

		// Token: 0x0400348C RID: 13452
		public const int InvalidSpot = 2;
	}
}

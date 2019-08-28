using System;

namespace Terraria.DataStructures
{
	// Token: 0x02000186 RID: 390
	public class DoubleStack<T1>
	{
		// Token: 0x06001297 RID: 4759 RVA: 0x00418460 File Offset: 0x00416660
		public DoubleStack(int segmentSize = 1024, int initialSize = 0)
		{
			if (segmentSize < 16)
			{
				segmentSize = 16;
			}
			this._start = segmentSize / 2;
			this._end = this._start;
			this._size = 0;
			this._segmentShiftPosition = segmentSize + this._start;
			initialSize += this._start;
			int num = initialSize / segmentSize + 1;
			this._segmentList = new T1[num][];
			for (int i = 0; i < num; i++)
			{
				this._segmentList[i] = new T1[segmentSize];
			}
			this._segmentSize = segmentSize;
			this._segmentCount = num;
			this._last = this._segmentSize * this._segmentCount - 1;
		}

		// Token: 0x06001298 RID: 4760 RVA: 0x00418500 File Offset: 0x00416700
		public void PushFront(T1 front)
		{
			if (this._start == 0)
			{
				T1[][] array = new T1[this._segmentCount + 1][];
				for (int i = 0; i < this._segmentCount; i++)
				{
					array[i + 1] = this._segmentList[i];
				}
				array[0] = new T1[this._segmentSize];
				this._segmentList = array;
				this._segmentCount++;
				this._start += this._segmentSize;
				this._end += this._segmentSize;
				this._last += this._segmentSize;
			}
			this._start--;
			T1[] arg_C5_0 = this._segmentList[this._start / this._segmentSize];
			int num = this._start % this._segmentSize;
			arg_C5_0[num] = front;
			this._size++;
		}

		// Token: 0x06001299 RID: 4761 RVA: 0x004185E8 File Offset: 0x004167E8
		public T1 PopFront()
		{
			if (this._size == 0)
			{
				throw new InvalidOperationException("The DoubleStack is empty.");
			}
			T1[] arg_35_0 = this._segmentList[this._start / this._segmentSize];
			int num = this._start % this._segmentSize;
			T1 result = arg_35_0[num];
			arg_35_0[num] = default(T1);
			this._start++;
			this._size--;
			if (this._start >= this._segmentShiftPosition)
			{
				T1[] array = this._segmentList[0];
				for (int i = 0; i < this._segmentCount - 1; i++)
				{
					this._segmentList[i] = this._segmentList[i + 1];
				}
				this._segmentList[this._segmentCount - 1] = array;
				this._start -= this._segmentSize;
				this._end -= this._segmentSize;
			}
			if (this._size == 0)
			{
				this._start = this._segmentSize / 2;
				this._end = this._start;
			}
			return result;
		}

		// Token: 0x0600129A RID: 4762 RVA: 0x004186F8 File Offset: 0x004168F8
		public T1 PeekFront()
		{
			if (this._size == 0)
			{
				throw new InvalidOperationException("The DoubleStack is empty.");
			}
			T1[] arg_36_0 = this._segmentList[this._start / this._segmentSize];
			int num = this._start % this._segmentSize;
			return arg_36_0[num];
		}

		// Token: 0x0600129B RID: 4763 RVA: 0x00418740 File Offset: 0x00416940
		public void PushBack(T1 back)
		{
			if (this._end == this._last)
			{
				T1[][] array = new T1[this._segmentCount + 1][];
				for (int i = 0; i < this._segmentCount; i++)
				{
					array[i] = this._segmentList[i];
				}
				array[this._segmentCount] = new T1[this._segmentSize];
				this._segmentCount++;
				this._segmentList = array;
				this._last += this._segmentSize;
			}
			T1[] arg_97_0 = this._segmentList[this._end / this._segmentSize];
			int num = this._end % this._segmentSize;
			arg_97_0[num] = back;
			this._end++;
			this._size++;
		}

		// Token: 0x0600129C RID: 4764 RVA: 0x00418808 File Offset: 0x00416A08
		public T1 PopBack()
		{
			if (this._size == 0)
			{
				throw new InvalidOperationException("The DoubleStack is empty.");
			}
			T1[] arg_35_0 = this._segmentList[this._end / this._segmentSize];
			int num = this._end % this._segmentSize;
			T1 result = arg_35_0[num];
			arg_35_0[num] = default(T1);
			this._end--;
			this._size--;
			if (this._size == 0)
			{
				this._start = this._segmentSize / 2;
				this._end = this._start;
			}
			return result;
		}

		// Token: 0x0600129D RID: 4765 RVA: 0x004188A0 File Offset: 0x00416AA0
		public T1 PeekBack()
		{
			if (this._size == 0)
			{
				throw new InvalidOperationException("The DoubleStack is empty.");
			}
			T1[] arg_36_0 = this._segmentList[this._end / this._segmentSize];
			int num = this._end % this._segmentSize;
			return arg_36_0[num];
		}

		// Token: 0x0600129E RID: 4766 RVA: 0x004188E8 File Offset: 0x00416AE8
		public void Clear(bool quickClear = false)
		{
			if (!quickClear)
			{
				for (int i = 0; i < this._segmentCount; i++)
				{
					Array.Clear(this._segmentList[i], 0, this._segmentSize);
				}
			}
			this._start = this._segmentSize / 2;
			this._end = this._start;
			this._size = 0;
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x0600129F RID: 4767 RVA: 0x00418940 File Offset: 0x00416B40
		public int Count
		{
			get
			{
				return this._size;
			}
		}

		// Token: 0x04003443 RID: 13379
		private T1[][] _segmentList;

		// Token: 0x04003444 RID: 13380
		private readonly int _segmentSize;

		// Token: 0x04003445 RID: 13381
		private int _segmentCount;

		// Token: 0x04003446 RID: 13382
		private readonly int _segmentShiftPosition;

		// Token: 0x04003447 RID: 13383
		private int _start;

		// Token: 0x04003448 RID: 13384
		private int _end;

		// Token: 0x04003449 RID: 13385
		private int _size;

		// Token: 0x0400344A RID: 13386
		private int _last;
	}
}

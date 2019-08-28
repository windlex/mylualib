using System;
using System.Collections.Generic;

namespace Terraria.ID
{
	// Token: 0x020000D2 RID: 210
	public class SetFactory
	{
		// Token: 0x06000D12 RID: 3346 RVA: 0x003DD08C File Offset: 0x003DB28C
		public SetFactory(int size)
		{
			this._size = size;
		}

		// Token: 0x06000D18 RID: 3352 RVA: 0x003DD304 File Offset: 0x003DB504
		public bool[] CreateBoolSet(params int[] types)
		{
			return this.CreateBoolSet(false, types);
		}

		// Token: 0x06000D19 RID: 3353 RVA: 0x003DD310 File Offset: 0x003DB510
		public bool[] CreateBoolSet(bool defaultState, params int[] types)
		{
			bool[] boolBuffer = this.GetBoolBuffer();
			for (int i = 0; i < boolBuffer.Length; i++)
			{
				boolBuffer[i] = defaultState;
			}
			for (int j = 0; j < types.Length; j++)
			{
				boolBuffer[types[j]] = !defaultState;
			}
			return boolBuffer;
		}

		// Token: 0x06000D1D RID: 3357 RVA: 0x003DD44C File Offset: 0x003DB64C
		public T[] CreateCustomSet<T>(T defaultState, params object[] inputs)
		{
			if (inputs.Length % 2 != 0)
			{
				throw new Exception("You have a bad length for inputs on CreateCustomSet");
			}
			T[] array = new T[this._size];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = defaultState;
			}
			if (inputs != null)
			{
				for (int j = 0; j < inputs.Length; j += 2)
				{
					array[(int)(inputs[j])] = (T)((object)inputs[j + 1]);
				}
			}
			return array;
		}

		// Token: 0x06000D1C RID: 3356 RVA: 0x003DD3F8 File Offset: 0x003DB5F8
		public float[] CreateFloatSet(float defaultState, params float[] inputs)
		{
			if (inputs.Length % 2 != 0)
			{
				throw new Exception("You have a bad length for inputs on CreateArraySet");
			}
			float[] floatBuffer = this.GetFloatBuffer();
			for (int i = 0; i < floatBuffer.Length; i++)
			{
				floatBuffer[i] = defaultState;
			}
			for (int j = 0; j < inputs.Length; j += 2)
			{
				floatBuffer[(int)inputs[j]] = inputs[j + 1];
			}
			return floatBuffer;
		}

		// Token: 0x06000D1A RID: 3354 RVA: 0x003DD350 File Offset: 0x003DB550
		public int[] CreateIntSet(int defaultState, params int[] inputs)
		{
			if (inputs.Length % 2 != 0)
			{
				throw new Exception("You have a bad length for inputs on CreateArraySet");
			}
			int[] intBuffer = this.GetIntBuffer();
			for (int i = 0; i < intBuffer.Length; i++)
			{
				intBuffer[i] = defaultState;
			}
			for (int j = 0; j < inputs.Length; j += 2)
			{
				intBuffer[inputs[j]] = inputs[j + 1];
			}
			return intBuffer;
		}

		// Token: 0x06000D1B RID: 3355 RVA: 0x003DD3A4 File Offset: 0x003DB5A4
		public ushort[] CreateUshortSet(ushort defaultState, params ushort[] inputs)
		{
			if (inputs.Length % 2 != 0)
			{
				throw new Exception("You have a bad length for inputs on CreateArraySet");
			}
			ushort[] ushortBuffer = this.GetUshortBuffer();
			for (int i = 0; i < ushortBuffer.Length; i++)
			{
				ushortBuffer[i] = defaultState;
			}
			for (int j = 0; j < inputs.Length; j += 2)
			{
				ushortBuffer[(int)inputs[j]] = inputs[j + 1];
			}
			return ushortBuffer;
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x003DD0E0 File Offset: 0x003DB2E0
		protected bool[] GetBoolBuffer()
		{
			object queueLock = this._queueLock;
			bool[] result;
			lock (queueLock)
			{
				if (this._boolBufferCache.Count == 0)
				{
					result = new bool[this._size];
				}
				else
				{
					result = this._boolBufferCache.Dequeue();
				}
			}
			return result;
		}

		// Token: 0x06000D16 RID: 3350 RVA: 0x003DD20C File Offset: 0x003DB40C
		protected float[] GetFloatBuffer()
		{
			object queueLock = this._queueLock;
			float[] result;
			lock (queueLock)
			{
				if (this._floatBufferCache.Count == 0)
				{
					result = new float[this._size];
				}
				else
				{
					result = this._floatBufferCache.Dequeue();
				}
			}
			return result;
		}

		// Token: 0x06000D14 RID: 3348 RVA: 0x003DD144 File Offset: 0x003DB344
		protected int[] GetIntBuffer()
		{
			object queueLock = this._queueLock;
			int[] result;
			lock (queueLock)
			{
				if (this._intBufferCache.Count == 0)
				{
					result = new int[this._size];
				}
				else
				{
					result = this._intBufferCache.Dequeue();
				}
			}
			return result;
		}

		// Token: 0x06000D15 RID: 3349 RVA: 0x003DD1A8 File Offset: 0x003DB3A8
		protected ushort[] GetUshortBuffer()
		{
			object queueLock = this._queueLock;
			ushort[] result;
			lock (queueLock)
			{
				if (this._ushortBufferCache.Count == 0)
				{
					result = new ushort[this._size];
				}
				else
				{
					result = this._ushortBufferCache.Dequeue();
				}
			}
			return result;
		}

		// Token: 0x06000D17 RID: 3351 RVA: 0x003DD270 File Offset: 0x003DB470
		public void Recycle<T>(T[] buffer)
		{
			object queueLock = this._queueLock;
			lock (queueLock)
			{
				if (typeof(T).Equals(typeof(bool)))
				{
					this._boolBufferCache.Enqueue((bool[])(object)buffer);
				}
				else if (typeof(T).Equals(typeof(int)))
				{
					this._intBufferCache.Enqueue((int[])(object)buffer);
				}
			}
		}

		// Token: 0x04001485 RID: 5253
		private Queue<bool[]> _boolBufferCache = new Queue<bool[]>();

		// Token: 0x04001486 RID: 5254
		private Queue<float[]> _floatBufferCache = new Queue<float[]>();

		// Token: 0x04001483 RID: 5251
		private Queue<int[]> _intBufferCache = new Queue<int[]>();

		// Token: 0x04001487 RID: 5255
		private object _queueLock = new object();

		// Token: 0x04001482 RID: 5250
		protected int _size;

		// Token: 0x04001484 RID: 5252
		private Queue<ushort[]> _ushortBufferCache = new Queue<ushort[]>();
	}
}

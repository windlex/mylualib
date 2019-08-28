using System;
using System.Collections.Generic;

namespace Terraria.DataStructures
{
	// Token: 0x02000183 RID: 387
	public static class BufferPool
	{
		// Token: 0x06001287 RID: 4743 RVA: 0x00418074 File Offset: 0x00416274
		public static CachedBuffer Request(int size)
		{
			object obj = BufferPool.bufferLock;
			CachedBuffer result;
			lock (obj)
			{
				if (size <= 32)
				{
					if (BufferPool.SmallBufferQueue.Count == 0)
					{
						result = new CachedBuffer(new byte[32]);
					}
					else
					{
						result = BufferPool.SmallBufferQueue.Dequeue().Activate();
					}
				}
				else if (size <= 256)
				{
					if (BufferPool.MediumBufferQueue.Count == 0)
					{
						result = new CachedBuffer(new byte[256]);
					}
					else
					{
						result = BufferPool.MediumBufferQueue.Dequeue().Activate();
					}
				}
				else if (size <= 16384)
				{
					if (BufferPool.LargeBufferQueue.Count == 0)
					{
						result = new CachedBuffer(new byte[16384]);
					}
					else
					{
						result = BufferPool.LargeBufferQueue.Dequeue().Activate();
					}
				}
				else
				{
					result = new CachedBuffer(new byte[size]);
				}
			}
			return result;
		}

		// Token: 0x06001288 RID: 4744 RVA: 0x00418164 File Offset: 0x00416364
		public static CachedBuffer Request(byte[] data, int offset, int size)
		{
			CachedBuffer cachedBuffer = BufferPool.Request(size);
			Buffer.BlockCopy(data, offset, cachedBuffer.Data, 0, size);
			return cachedBuffer;
		}

		// Token: 0x06001289 RID: 4745 RVA: 0x00418188 File Offset: 0x00416388
		public static void Recycle(CachedBuffer buffer)
		{
			int length = buffer.Length;
			object obj = BufferPool.bufferLock;
			lock (obj)
			{
				if (length <= 32)
				{
					BufferPool.SmallBufferQueue.Enqueue(buffer);
				}
				else if (length <= 256)
				{
					BufferPool.MediumBufferQueue.Enqueue(buffer);
				}
				else if (length <= 16384)
				{
					BufferPool.LargeBufferQueue.Enqueue(buffer);
				}
			}
		}

		// Token: 0x0600128A RID: 4746 RVA: 0x00418204 File Offset: 0x00416404
		public static void PrintBufferSizes()
		{
			object obj = BufferPool.bufferLock;
			lock (obj)
			{
				Console.WriteLine("SmallBufferQueue.Count: " + BufferPool.SmallBufferQueue.Count);
				Console.WriteLine("MediumBufferQueue.Count: " + BufferPool.MediumBufferQueue.Count);
				Console.WriteLine("LargeBufferQueue.Count: " + BufferPool.LargeBufferQueue.Count);
				Console.WriteLine("");
			}
		}

		// Token: 0x04003433 RID: 13363
		private const int SMALL_BUFFER_SIZE = 32;

		// Token: 0x04003434 RID: 13364
		private const int MEDIUM_BUFFER_SIZE = 256;

		// Token: 0x04003435 RID: 13365
		private const int LARGE_BUFFER_SIZE = 16384;

		// Token: 0x04003436 RID: 13366
		private static object bufferLock = new object();

		// Token: 0x04003437 RID: 13367
		private static Queue<CachedBuffer> SmallBufferQueue = new Queue<CachedBuffer>();

		// Token: 0x04003438 RID: 13368
		private static Queue<CachedBuffer> MediumBufferQueue = new Queue<CachedBuffer>();

		// Token: 0x04003439 RID: 13369
		private static Queue<CachedBuffer> LargeBufferQueue = new Queue<CachedBuffer>();
	}
}

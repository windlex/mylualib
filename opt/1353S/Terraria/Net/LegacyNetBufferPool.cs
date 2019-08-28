using System;
using System.Collections.Generic;

namespace Terraria.Net
{
	// Token: 0x0200006C RID: 108
	public class LegacyNetBufferPool
	{
		// Token: 0x060009CD RID: 2509 RVA: 0x003B6FA8 File Offset: 0x003B51A8
		public static byte[] RequestBuffer(int size)
		{
			object obj = LegacyNetBufferPool.bufferLock;
			byte[] result;
			lock (obj)
			{
				if (size <= 256)
				{
					if (LegacyNetBufferPool._smallBufferQueue.Count == 0)
					{
						LegacyNetBufferPool._smallBufferCount++;
						result = new byte[256];
					}
					else
					{
						result = LegacyNetBufferPool._smallBufferQueue.Dequeue();
					}
				}
				else if (size <= 1024)
				{
					if (LegacyNetBufferPool._mediumBufferQueue.Count == 0)
					{
						LegacyNetBufferPool._mediumBufferCount++;
						result = new byte[1024];
					}
					else
					{
						result = LegacyNetBufferPool._mediumBufferQueue.Dequeue();
					}
				}
				else if (size <= 16384)
				{
					if (LegacyNetBufferPool._largeBufferQueue.Count == 0)
					{
						LegacyNetBufferPool._largeBufferCount++;
						result = new byte[16384];
					}
					else
					{
						result = LegacyNetBufferPool._largeBufferQueue.Dequeue();
					}
				}
				else
				{
					LegacyNetBufferPool._customBufferCount++;
					result = new byte[size];
				}
			}
			return result;
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x003B70AC File Offset: 0x003B52AC
		public static byte[] RequestBuffer(byte[] data, int offset, int size)
		{
			byte[] array = LegacyNetBufferPool.RequestBuffer(size);
			Buffer.BlockCopy(data, offset, array, 0, size);
			return array;
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x003B70CC File Offset: 0x003B52CC
		public static void ReturnBuffer(byte[] buffer)
		{
			int num = buffer.Length;
			object obj = LegacyNetBufferPool.bufferLock;
			lock (obj)
			{
				if (num <= 256)
				{
					LegacyNetBufferPool._smallBufferQueue.Enqueue(buffer);
				}
				else if (num <= 1024)
				{
					LegacyNetBufferPool._mediumBufferQueue.Enqueue(buffer);
				}
				else if (num <= 16384)
				{
					LegacyNetBufferPool._largeBufferQueue.Enqueue(buffer);
				}
			}
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x003B7148 File Offset: 0x003B5348
		public static void DisplayBufferSizes()
		{
			object obj = LegacyNetBufferPool.bufferLock;
			lock (obj)
			{
				Main.NewText(string.Concat(new object[]
				{
					"Small Buffers:  ",
					LegacyNetBufferPool._smallBufferQueue.Count,
					" queued of ",
					LegacyNetBufferPool._smallBufferCount
				}), 255, 255, 255, false);
				Main.NewText(string.Concat(new object[]
				{
					"Medium Buffers: ",
					LegacyNetBufferPool._mediumBufferQueue.Count,
					" queued of ",
					LegacyNetBufferPool._mediumBufferCount
				}), 255, 255, 255, false);
				Main.NewText(string.Concat(new object[]
				{
					"Large Buffers:  ",
					LegacyNetBufferPool._largeBufferQueue.Count,
					" queued of ",
					LegacyNetBufferPool._largeBufferCount
				}), 255, 255, 255, false);
				Main.NewText("Custom Buffers: 0 queued of " + LegacyNetBufferPool._customBufferCount, 255, 255, 255, false);
			}
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x003B72A4 File Offset: 0x003B54A4
		public static void PrintBufferSizes()
		{
			object obj = LegacyNetBufferPool.bufferLock;
			lock (obj)
			{
				Console.WriteLine(string.Concat(new object[]
				{
					"Small Buffers:  ",
					LegacyNetBufferPool._smallBufferQueue.Count,
					" queued of ",
					LegacyNetBufferPool._smallBufferCount
				}));
				Console.WriteLine(string.Concat(new object[]
				{
					"Medium Buffers: ",
					LegacyNetBufferPool._mediumBufferQueue.Count,
					" queued of ",
					LegacyNetBufferPool._mediumBufferCount
				}));
				Console.WriteLine(string.Concat(new object[]
				{
					"Large Buffers:  ",
					LegacyNetBufferPool._largeBufferQueue.Count,
					" queued of ",
					LegacyNetBufferPool._largeBufferCount
				}));
				Console.WriteLine("Custom Buffers: 0 queued of " + LegacyNetBufferPool._customBufferCount);
				Console.WriteLine("");
			}
		}

		// Token: 0x04000DC0 RID: 3520
		private const int SMALL_BUFFER_SIZE = 256;

		// Token: 0x04000DC1 RID: 3521
		private const int MEDIUM_BUFFER_SIZE = 1024;

		// Token: 0x04000DC2 RID: 3522
		private const int LARGE_BUFFER_SIZE = 16384;

		// Token: 0x04000DC3 RID: 3523
		private static object bufferLock = new object();

		// Token: 0x04000DC4 RID: 3524
		private static Queue<byte[]> _smallBufferQueue = new Queue<byte[]>();

		// Token: 0x04000DC5 RID: 3525
		private static Queue<byte[]> _mediumBufferQueue = new Queue<byte[]>();

		// Token: 0x04000DC6 RID: 3526
		private static Queue<byte[]> _largeBufferQueue = new Queue<byte[]>();

		// Token: 0x04000DC7 RID: 3527
		private static int _smallBufferCount = 0;

		// Token: 0x04000DC8 RID: 3528
		private static int _mediumBufferCount = 0;

		// Token: 0x04000DC9 RID: 3529
		private static int _largeBufferCount = 0;

		// Token: 0x04000DCA RID: 3530
		private static int _customBufferCount = 0;
	}
}

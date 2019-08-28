using System;
using System.Collections.Generic;
using Steamworks;

namespace Terraria.Social.Steam
{
	// Token: 0x02000096 RID: 150
	public class SteamP2PReader
	{
		// Token: 0x06000B51 RID: 2897 RVA: 0x003CD886 File Offset: 0x003CBA86
		public SteamP2PReader(int channel)
		{
			this._channel = channel;
		}

		// Token: 0x06000B52 RID: 2898 RVA: 0x003CD8C4 File Offset: 0x003CBAC4
		public void ClearUser(CSteamID id)
		{
			Dictionary<CSteamID, Queue<SteamP2PReader.ReadResult>> pendingReadBuffers = this._pendingReadBuffers;
			lock (pendingReadBuffers)
			{
				this._deletionQueue.Enqueue(id);
			}
		}

		// Token: 0x06000B53 RID: 2899 RVA: 0x003CD90C File Offset: 0x003CBB0C
		public bool IsDataAvailable(CSteamID id)
		{
			Dictionary<CSteamID, Queue<SteamP2PReader.ReadResult>> pendingReadBuffers = this._pendingReadBuffers;
			bool result;
			lock (pendingReadBuffers)
			{
				if (!this._pendingReadBuffers.ContainsKey(id))
				{
					result = false;
				}
				else
				{
					Queue<SteamP2PReader.ReadResult> queue = this._pendingReadBuffers[id];
					if (queue.Count == 0 || queue.Peek().Size == 0u)
					{
						result = false;
					}
					else
					{
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x06000B55 RID: 2901 RVA: 0x003CD990 File Offset: 0x003CBB90
		private bool IsPacketAvailable(out uint size)
		{
			object steamLock = this.SteamLock;
			bool result;
			lock (steamLock)
			{
				result = SteamNetworking.IsP2PPacketAvailable(out size, this._channel);
			}
			return result;
		}

		// Token: 0x06000B56 RID: 2902 RVA: 0x003CD9D8 File Offset: 0x003CBBD8
		public void ReadTick()
		{
			Dictionary<CSteamID, Queue<SteamP2PReader.ReadResult>> pendingReadBuffers = this._pendingReadBuffers;
			lock (pendingReadBuffers)
			{
				while (this._deletionQueue.Count > 0)
				{
					this._pendingReadBuffers.Remove(this._deletionQueue.Dequeue());
				}
				uint val;
				while (this.IsPacketAvailable(out val))
				{
					byte[] array;
					if (this._bufferPool.Count == 0)
					{
						array = new byte[Math.Max(val, 4096u)];
					}
					else
					{
						array = this._bufferPool.Dequeue();
					}
					object steamLock = this.SteamLock;
					uint size;
					CSteamID cSteamID;
					bool flag3;
					lock (steamLock)
					{
						flag3 = SteamNetworking.ReadP2PPacket(array, (uint)array.Length, out size, out cSteamID, this._channel);
					}
					if (flag3)
					{
						if (this._readEvent == null || this._readEvent(array, (int)size, cSteamID))
						{
							if (!this._pendingReadBuffers.ContainsKey(cSteamID))
							{
								this._pendingReadBuffers[cSteamID] = new Queue<SteamP2PReader.ReadResult>();
							}
							this._pendingReadBuffers[cSteamID].Enqueue(new SteamP2PReader.ReadResult(array, size));
						}
						else
						{
							this._bufferPool.Enqueue(array);
						}
					}
				}
			}
		}

		// Token: 0x06000B57 RID: 2903 RVA: 0x003CDB3C File Offset: 0x003CBD3C
		public int Receive(CSteamID user, byte[] buffer, int bufferOffset, int bufferSize)
		{
			uint num = 0u;
			Dictionary<CSteamID, Queue<SteamP2PReader.ReadResult>> pendingReadBuffers = this._pendingReadBuffers;
			lock (pendingReadBuffers)
			{
				if (!this._pendingReadBuffers.ContainsKey(user))
				{
					int result = 0;
					return result;
				}
				Queue<SteamP2PReader.ReadResult> queue = this._pendingReadBuffers[user];
				while (queue.Count > 0)
				{
					SteamP2PReader.ReadResult readResult = queue.Peek();
					uint num2 = Math.Min((uint)(bufferSize - (int)num), readResult.Size - readResult.Offset);
					if (num2 == 0u)
					{
						int result = (int)num;
						return result;
					}
					Array.Copy(readResult.Data, (long)((ulong)readResult.Offset), buffer, (long)bufferOffset + (long)((ulong)num), (long)((ulong)num2));
					if (num2 == readResult.Size - readResult.Offset)
					{
						this._bufferPool.Enqueue(queue.Dequeue().Data);
					}
					else
					{
						readResult.Offset += num2;
					}
					num += num2;
				}
			}
			return (int)num;
		}

		// Token: 0x06000B54 RID: 2900 RVA: 0x003CD984 File Offset: 0x003CBB84
		public void SetReadEvent(SteamP2PReader.OnReadEvent method)
		{
			this._readEvent = method;
		}

		// Token: 0x04000E99 RID: 3737
		private const int BUFFER_SIZE = 4096;

		// Token: 0x04000E98 RID: 3736
		public object SteamLock = new object();

		// Token: 0x04000E9C RID: 3740
		private Queue<byte[]> _bufferPool = new Queue<byte[]>();

		// Token: 0x04000E9D RID: 3741
		private int _channel;

		// Token: 0x04000E9B RID: 3739
		private Queue<CSteamID> _deletionQueue = new Queue<CSteamID>();

		// Token: 0x04000E9A RID: 3738
		private Dictionary<CSteamID, Queue<SteamP2PReader.ReadResult>> _pendingReadBuffers = new Dictionary<CSteamID, Queue<SteamP2PReader.ReadResult>>();

		// Token: 0x04000E9E RID: 3742
		private SteamP2PReader.OnReadEvent _readEvent;

		// Token: 0x0200024C RID: 588
		// Token: 0x06001631 RID: 5681
		public delegate bool OnReadEvent(byte[] data, int size, CSteamID user);

		// Token: 0x0200024B RID: 587
		public class ReadResult
		{
			// Token: 0x0600162F RID: 5679 RVA: 0x00433644 File Offset: 0x00431844
			public ReadResult(byte[] data, uint size)
			{
				this.Data = data;
				this.Size = size;
				this.Offset = 0u;
			}

			// Token: 0x0400385F RID: 14431
			public byte[] Data;

			// Token: 0x04003861 RID: 14433
			public uint Offset;

			// Token: 0x04003860 RID: 14432
			public uint Size;
		}
	}
}

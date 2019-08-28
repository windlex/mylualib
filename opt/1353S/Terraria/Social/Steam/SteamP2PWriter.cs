using System;
using System.Collections.Generic;
using Steamworks;

namespace Terraria.Social.Steam
{
	// Token: 0x02000097 RID: 151
	public class SteamP2PWriter
	{
		// Token: 0x06000B58 RID: 2904 RVA: 0x003CDC38 File Offset: 0x003CBE38
		public SteamP2PWriter(int channel)
		{
			this._channel = channel;
		}

		// Token: 0x06000B5A RID: 2906 RVA: 0x003CDD90 File Offset: 0x003CBF90
		public void ClearUser(CSteamID user)
		{
			object @lock = this._lock;
			lock (@lock)
			{
				if (this._pendingSendData.ContainsKey(user))
				{
					Queue<SteamP2PWriter.WriteInformation> queue = this._pendingSendData[user];
					while (queue.Count > 0)
					{
						this._bufferPool.Enqueue(queue.Dequeue().Data);
					}
				}
				if (this._pendingSendDataSwap.ContainsKey(user))
				{
					Queue<SteamP2PWriter.WriteInformation> queue2 = this._pendingSendDataSwap[user];
					while (queue2.Count > 0)
					{
						this._bufferPool.Enqueue(queue2.Dequeue().Data);
					}
				}
			}
		}

		// Token: 0x06000B59 RID: 2905 RVA: 0x003CDC74 File Offset: 0x003CBE74
		public void QueueSend(CSteamID user, byte[] data, int length)
		{
			object @lock = this._lock;
			lock (@lock)
			{
				Queue<SteamP2PWriter.WriteInformation> queue;
				if (this._pendingSendData.ContainsKey(user))
				{
					queue = this._pendingSendData[user];
				}
				else
				{
					queue = (this._pendingSendData[user] = new Queue<SteamP2PWriter.WriteInformation>());
				}
				int i = length;
				int num = 0;
				while (i > 0)
				{
					SteamP2PWriter.WriteInformation writeInformation;
					if (queue.Count == 0 || 1024 - queue.Peek().Size == 0)
					{
						if (this._bufferPool.Count > 0)
						{
							writeInformation = new SteamP2PWriter.WriteInformation(this._bufferPool.Dequeue());
						}
						else
						{
							writeInformation = new SteamP2PWriter.WriteInformation();
						}
						queue.Enqueue(writeInformation);
					}
					else
					{
						writeInformation = queue.Peek();
					}
					int num2 = Math.Min(i, 1024 - writeInformation.Size);
					Array.Copy(data, num, writeInformation.Data, writeInformation.Size, num2);
					writeInformation.Size += num2;
					i -= num2;
					num += num2;
				}
			}
		}

		// Token: 0x06000B5B RID: 2907 RVA: 0x003CDE44 File Offset: 0x003CC044
		public void SendAll()
		{
			object @lock = this._lock;
			lock (@lock)
			{
				Utils.Swap<Dictionary<CSteamID, Queue<SteamP2PWriter.WriteInformation>>>(ref this._pendingSendData, ref this._pendingSendDataSwap);
			}
			foreach (KeyValuePair<CSteamID, Queue<SteamP2PWriter.WriteInformation>> current in this._pendingSendDataSwap)
			{
				Queue<SteamP2PWriter.WriteInformation> value = current.Value;
				while (value.Count > 0)
				{
					SteamP2PWriter.WriteInformation writeInformation = value.Dequeue();
					SteamNetworking.SendP2PPacket(current.Key, writeInformation.Data, (uint)writeInformation.Size, EP2PSend.k_EP2PSendReliable, this._channel);
					this._bufferPool.Enqueue(writeInformation.Data);
				}
			}
		}

		// Token: 0x04000E9F RID: 3743
		private const int BUFFER_SIZE = 1024;

		// Token: 0x04000EA2 RID: 3746
		private Queue<byte[]> _bufferPool = new Queue<byte[]>();

		// Token: 0x04000EA3 RID: 3747
		private int _channel;

		// Token: 0x04000EA4 RID: 3748
		private object _lock = new object();

		// Token: 0x04000EA0 RID: 3744
		private Dictionary<CSteamID, Queue<SteamP2PWriter.WriteInformation>> _pendingSendData = new Dictionary<CSteamID, Queue<SteamP2PWriter.WriteInformation>>();

		// Token: 0x04000EA1 RID: 3745
		private Dictionary<CSteamID, Queue<SteamP2PWriter.WriteInformation>> _pendingSendDataSwap = new Dictionary<CSteamID, Queue<SteamP2PWriter.WriteInformation>>();

		// Token: 0x0200024D RID: 589
		public class WriteInformation
		{
			// Token: 0x06001634 RID: 5684 RVA: 0x00433661 File Offset: 0x00431861
			public WriteInformation()
			{
				this.Data = new byte[1024];
				this.Size = 0;
			}

			// Token: 0x06001635 RID: 5685 RVA: 0x00433680 File Offset: 0x00431880
			public WriteInformation(byte[] data)
			{
				this.Data = data;
				this.Size = 0;
			}

			// Token: 0x04003862 RID: 14434
			public byte[] Data;

			// Token: 0x04003863 RID: 14435
			public int Size;
		}
	}
}

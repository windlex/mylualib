using System;
using System.Threading;
using Terraria.Social;

namespace Terraria.Net.Sockets
{
	// Token: 0x02000074 RID: 116
	public class SocialSocket : ISocket
	{
		// Token: 0x060009FF RID: 2559 RVA: 0x003B7710 File Offset: 0x003B5910
		public SocialSocket()
		{
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x003B7718 File Offset: 0x003B5918
		public SocialSocket(RemoteAddress remoteAddress)
		{
			this._remoteAddress = remoteAddress;
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x003B7728 File Offset: 0x003B5928
		void ISocket.Close()
		{
			if (this._remoteAddress == null)
			{
				return;
			}
			SocialAPI.Network.Close(this._remoteAddress);
			this._remoteAddress = null;
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x003B774C File Offset: 0x003B594C
		bool ISocket.IsConnected()
		{
			return SocialAPI.Network.IsConnected(this._remoteAddress);
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x003B7760 File Offset: 0x003B5960
		void ISocket.Connect(RemoteAddress address)
		{
			this._remoteAddress = address;
			SocialAPI.Network.Connect(address);
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x003B7774 File Offset: 0x003B5974
		void ISocket.AsyncSend(byte[] data, int offset, int size, SocketSendCallback callback, object state)
		{
			SocialAPI.Network.Send(this._remoteAddress, data, size);
			callback.BeginInvoke(state, null, null);
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x003B7798 File Offset: 0x003B5998
		private void ReadCallback(byte[] data, int offset, int size, SocketReceiveCallback callback, object state)
		{
			int size2;
			while ((size2 = SocialAPI.Network.Receive(this._remoteAddress, data, offset, size)) == 0)
			{
				Thread.Sleep(1);
			}
			callback(state, size2);
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x003B77D0 File Offset: 0x003B59D0
		void ISocket.AsyncReceive(byte[] data, int offset, int size, SocketReceiveCallback callback, object state)
		{
			new SocialSocket.InternalReadCallback(this.ReadCallback).BeginInvoke(data, offset, size, callback, state, null, null);
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x003B77F0 File Offset: 0x003B59F0
		void ISocket.SendQueuedPackets()
		{
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x003B77F4 File Offset: 0x003B59F4
		bool ISocket.IsDataAvailable()
		{
			return SocialAPI.Network.IsDataAvailable(this._remoteAddress);
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x003B7808 File Offset: 0x003B5A08
		RemoteAddress ISocket.GetRemoteAddress()
		{
			return this._remoteAddress;
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x003B7810 File Offset: 0x003B5A10
		bool ISocket.StartListening(SocketConnectionAccepted callback)
		{
			return SocialAPI.Network.StartListening(callback);
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x003B7820 File Offset: 0x003B5A20
		void ISocket.StopListening()
		{
			SocialAPI.Network.StopListening();
		}

		// Token: 0x04000DD2 RID: 3538
		private RemoteAddress _remoteAddress;

		// Token: 0x0200022C RID: 556
		// (Invoke) Token: 0x06001577 RID: 5495
		private delegate void InternalReadCallback(byte[] data, int offset, int size, SocketReceiveCallback callback, object state);
	}
}

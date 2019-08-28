using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Terraria.Localization;

namespace Terraria.Net.Sockets
{
	// Token: 0x02000075 RID: 117
	public class TcpSocket : ISocket
	{
		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000A0C RID: 2572 RVA: 0x003B782C File Offset: 0x003B5A2C
		public int MessagesInQueue
		{
			get
			{
				return this._messagesInQueue;
			}
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x003B7834 File Offset: 0x003B5A34
		public TcpSocket()
		{
			this._connection = new TcpClient();
			this._connection.NoDelay = true;
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x003B7870 File Offset: 0x003B5A70
		public TcpSocket(TcpClient tcpClient)
		{
			this._connection = tcpClient;
			this._connection.NoDelay = true;
			IPEndPoint iPEndPoint = (IPEndPoint)tcpClient.Client.RemoteEndPoint;
			this._remoteAddress = new TcpAddress(iPEndPoint.Address, iPEndPoint.Port);
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x003B78DC File Offset: 0x003B5ADC
		void ISocket.Close()
		{
			this._remoteAddress = null;
			this._connection.Close();
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x003B78F0 File Offset: 0x003B5AF0
		bool ISocket.IsConnected()
		{
			return this._connection != null && this._connection.Client != null && this._connection.Connected;
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x003B7914 File Offset: 0x003B5B14
		void ISocket.Connect(RemoteAddress address)
		{
			TcpAddress tcpAddress = (TcpAddress)address;
			this._connection.Connect(tcpAddress.Address, tcpAddress.Port);
			this._remoteAddress = address;
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x003B7948 File Offset: 0x003B5B48
		private void ReadCallback(IAsyncResult result)
		{
			Tuple<SocketReceiveCallback, object> tuple = (Tuple<SocketReceiveCallback, object>)result.AsyncState;
			tuple.Item1(tuple.Item2, this._connection.GetStream().EndRead(result));
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x003B7984 File Offset: 0x003B5B84
		private void SendCallback(IAsyncResult result)
		{
			Tuple<SocketSendCallback, object> tuple = (Tuple<SocketSendCallback, object>)result.AsyncState;
			try
			{
				this._connection.GetStream().EndWrite(result);
				tuple.Item1(tuple.Item2);
			}
			catch (Exception)
			{
				((ISocket)this).Close();
			}
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x003B79DC File Offset: 0x003B5BDC
		void ISocket.SendQueuedPackets()
		{
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x003B79E0 File Offset: 0x003B5BE0
		void ISocket.AsyncSend(byte[] data, int offset, int size, SocketSendCallback callback, object state)
		{
			this._connection.GetStream().BeginWrite(data, 0, size, new AsyncCallback(this.SendCallback), new Tuple<SocketSendCallback, object>(callback, state));
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x003B7A0C File Offset: 0x003B5C0C
		void ISocket.AsyncReceive(byte[] data, int offset, int size, SocketReceiveCallback callback, object state)
		{
			this._connection.GetStream().BeginRead(data, offset, size, new AsyncCallback(this.ReadCallback), new Tuple<SocketReceiveCallback, object>(callback, state));
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x003B7A38 File Offset: 0x003B5C38
		bool ISocket.IsDataAvailable()
		{
			return this._connection.GetStream().DataAvailable;
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x003B7A4C File Offset: 0x003B5C4C
		RemoteAddress ISocket.GetRemoteAddress()
		{
			return this._remoteAddress;
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x003B7A54 File Offset: 0x003B5C54
		bool ISocket.StartListening(SocketConnectionAccepted callback)
		{
			IPAddress any = IPAddress.Any;
			string ipString;
			if (Program.LaunchParameters.TryGetValue("-ip", out ipString) && !IPAddress.TryParse(ipString, out any))
			{
				any = IPAddress.Any;
			}
			this._isListening = true;
			this._listenerCallback = callback;
			if (this._listener == null)
			{
				this._listener = new TcpListener(any, Netplay.ListenPort);
			}
			try
			{
				this._listener.Start();
			}
			catch (Exception)
			{
				return false;
			}
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.ListenLoop));
			return true;
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x003B7AEC File Offset: 0x003B5CEC
		void ISocket.StopListening()
		{
			this._isListening = false;
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x003B7AF8 File Offset: 0x003B5CF8
		private void ListenLoop(object unused)
		{
			while (this._isListening && !Netplay.disconnect)
			{
				try
				{
					ISocket socket = new TcpSocket(this._listener.AcceptTcpClient());
					Console.WriteLine(Language.GetTextValue("Net.ClientConnecting", socket.GetRemoteAddress()));
					this._listenerCallback(socket);
				}
				catch (Exception)
				{
				}
			}
			this._listener.Stop();
		}

		// Token: 0x04000DD3 RID: 3539
		private byte[] _packetBuffer = new byte[1024];

		// Token: 0x04000DD4 RID: 3540
		private int _packetBufferLength;

		// Token: 0x04000DD5 RID: 3541
		private List<object> _callbackBuffer = new List<object>();

		// Token: 0x04000DD6 RID: 3542
		private int _messagesInQueue;

		// Token: 0x04000DD7 RID: 3543
		private TcpClient _connection;

		// Token: 0x04000DD8 RID: 3544
		private TcpListener _listener;

		// Token: 0x04000DD9 RID: 3545
		private SocketConnectionAccepted _listenerCallback;

		// Token: 0x04000DDA RID: 3546
		private RemoteAddress _remoteAddress;

		// Token: 0x04000DDB RID: 3547
		private bool _isListening;
	}
}

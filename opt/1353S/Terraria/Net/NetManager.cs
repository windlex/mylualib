using System;
using System.Collections.Generic;
using System.IO;
using Terraria.Localization;
using Terraria.Net.Sockets;

namespace Terraria.Net
{
	// Token: 0x0200006E RID: 110
	public class NetManager
	{
		// Token: 0x060009D7 RID: 2519 RVA: 0x003B7440 File Offset: 0x003B5640
		private NetManager()
		{
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x003B7454 File Offset: 0x003B5654
		public void Register<T>() where T : NetModule, new()
		{
			T t = Activator.CreateInstance<T>();
			NetManager.PacketTypeStorage<T>.Id = this._moduleCount;
			NetManager.PacketTypeStorage<T>.Module = t;
			this._modules[this._moduleCount] = t;
			this._moduleCount += 1;
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x003B74A0 File Offset: 0x003B56A0
		public NetModule GetModule<T>() where T : NetModule
		{
			return NetManager.PacketTypeStorage<T>.Module;
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x003B74AC File Offset: 0x003B56AC
		public ushort GetId<T>() where T : NetModule
		{
			return NetManager.PacketTypeStorage<T>.Id;
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x003B74B4 File Offset: 0x003B56B4
		public void Read(BinaryReader reader, int userId)
		{
			ushort key = reader.ReadUInt16();
			if (this._modules.ContainsKey(key))
			{
				this._modules[key].Deserialize(reader, userId);
			}
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x003B74EC File Offset: 0x003B56EC
		public void Broadcast(NetPacket packet, int ignoreClient = -1)
		{
			for (int i = 0; i < 256; i++)
			{
				if (i != ignoreClient && Netplay.Clients[i].IsConnected())
				{
					this.SendData(Netplay.Clients[i].Socket, packet);
				}
			}
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x003B7530 File Offset: 0x003B5730
		public void SendToServer(NetPacket packet)
		{
			this.SendData(Netplay.Connection.Socket, packet);
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x003B7544 File Offset: 0x003B5744
		public void SendToClient(NetPacket packet, int playerId)
		{
			this.SendData(Netplay.Clients[playerId].Socket, packet);
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x003B755C File Offset: 0x003B575C
		private void SendData(ISocket socket, NetPacket packet)
		{
			if (Main.netMode == 0)
			{
				return;
			}
			packet.ShrinkToFit();
			try
			{
				socket.AsyncSend(packet.Buffer.Data, 0, packet.Length, new SocketSendCallback(NetManager.SendCallback), packet);
			}
			catch
			{
				Console.WriteLine(Language.GetTextValue("Error.ExceptionNormal", Language.GetTextValue("Error.DataSentAfterConnectionLost")));
			}
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x003B75D4 File Offset: 0x003B57D4
		public static void SendCallback(object state)
		{
			((NetPacket)state).Recycle();
		}

		// Token: 0x04000DCB RID: 3531
		public static readonly NetManager Instance = new NetManager();

		// Token: 0x04000DCC RID: 3532
		private Dictionary<ushort, NetModule> _modules = new Dictionary<ushort, NetModule>();

		// Token: 0x04000DCD RID: 3533
		private ushort _moduleCount;

		// Token: 0x0200022B RID: 555
		private class PacketTypeStorage<T> where T : NetModule
		{
			// Token: 0x040037CA RID: 14282
			public static ushort Id;

			// Token: 0x040037CB RID: 14283
			public static T Module;
		}
	}
}

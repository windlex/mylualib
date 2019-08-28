using System;
using System.Diagnostics;
using Terraria.Net;
using Terraria.Net.Sockets;

namespace Terraria.Social.Base
{
	// Token: 0x0200009B RID: 155
	public abstract class NetSocialModule : ISocialModule
	{
		// Token: 0x06000B75 RID: 2933
		public abstract void Initialize();

		// Token: 0x06000B76 RID: 2934
		public abstract void Shutdown();

		// Token: 0x06000B77 RID: 2935
		public abstract void Close(RemoteAddress address);

		// Token: 0x06000B78 RID: 2936
		public abstract bool IsConnected(RemoteAddress address);

		// Token: 0x06000B79 RID: 2937
		public abstract void Connect(RemoteAddress address);

		// Token: 0x06000B7A RID: 2938
		public abstract bool Send(RemoteAddress address, byte[] data, int length);

		// Token: 0x06000B7B RID: 2939
		public abstract int Receive(RemoteAddress address, byte[] data, int offset, int length);

		// Token: 0x06000B7C RID: 2940
		public abstract bool IsDataAvailable(RemoteAddress address);

		// Token: 0x06000B7D RID: 2941
		public abstract void LaunchLocalServer(Process process, ServerMode mode);

		// Token: 0x06000B7E RID: 2942
		public abstract bool CanInvite();

		// Token: 0x06000B7F RID: 2943
		public abstract void OpenInviteInterface();

		// Token: 0x06000B80 RID: 2944
		public abstract void CancelJoin();

		// Token: 0x06000B81 RID: 2945
		public abstract bool StartListening(SocketConnectionAccepted callback);

		// Token: 0x06000B82 RID: 2946
		public abstract void StopListening();

		// Token: 0x06000B83 RID: 2947
		public abstract ulong GetLobbyId();
	}
}

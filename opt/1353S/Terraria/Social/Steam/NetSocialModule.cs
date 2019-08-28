using System;
using System.Collections.Concurrent;
using System.IO;
using Steamworks;
using Terraria.Net;
using Terraria.Social.Base;

namespace Terraria.Social.Steam
{
	// Token: 0x02000095 RID: 149
	public abstract class NetSocialModule : Terraria.Social.Base.NetSocialModule
	{
		// Token: 0x06000B46 RID: 2886 RVA: 0x003CD5F4 File Offset: 0x003CB7F4
		protected NetSocialModule(int readChannel, int writeChannel)
		{
			this._reader = new SteamP2PReader(readChannel);
			this._writer = new SteamP2PWriter(writeChannel);
		}

		// Token: 0x06000B4B RID: 2891 RVA: 0x003CD7D8 File Offset: 0x003CB9D8
		protected P2PSessionState_t GetSessionState(CSteamID userId)
		{
			P2PSessionState_t result;
			SteamNetworking.GetP2PSessionState(userId, out result);
			return result;
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x003CD640 File Offset: 0x003CB840
		public override void Initialize()
		{
			CoreSocialModule.OnTick += new Action(this._reader.ReadTick);
			CoreSocialModule.OnTick += new Action(this._writer.SendAll);
			this._lobbyChatMessage = Callback<LobbyChatMsg_t>.Create(new Callback<LobbyChatMsg_t>.DispatchDelegate(this.OnLobbyChatMessage));
		}

		// Token: 0x06000B49 RID: 2889 RVA: 0x003CD6A0 File Offset: 0x003CB8A0
		public override bool IsConnected(RemoteAddress address)
		{
			if (address == null)
			{
				return false;
			}
			CSteamID cSteamID = this.RemoteAddressToSteamId(address);
			if (!this._connectionStateMap.ContainsKey(cSteamID) || this._connectionStateMap[cSteamID] != NetSocialModule.ConnectionState.Connected)
			{
				return false;
			}
			if (this.GetSessionState(cSteamID).m_bConnectionActive != 1)
			{
				this.Close(address);
				return false;
			}
			return true;
		}

		// Token: 0x06000B4F RID: 2895 RVA: 0x003CD84C File Offset: 0x003CBA4C
		public override bool IsDataAvailable(RemoteAddress address)
		{
			CSteamID id = this.RemoteAddressToSteamId(address);
			return this._reader.IsDataAvailable(id);
		}

		// Token: 0x06000B4A RID: 2890 RVA: 0x003CD6F4 File Offset: 0x003CB8F4
		protected virtual void OnLobbyChatMessage(LobbyChatMsg_t result)
		{
			if (result.m_ulSteamIDLobby != this._lobby.Id.m_SteamID)
			{
				return;
			}
			if (result.m_eChatEntryType != 1)
			{
				return;
			}
			if (result.m_ulSteamIDUser != this._lobby.Owner.m_SteamID)
			{
				return;
			}
			byte[] message = this._lobby.GetMessage((int)result.m_iChatID);
			if (message.Length == 0)
			{
				return;
			}
			using (MemoryStream memoryStream = new MemoryStream(message))
			{
				using (BinaryReader binaryReader = new BinaryReader(memoryStream))
				{
					byte b = binaryReader.ReadByte();
					if (b == 1)
					{
						while ((long)message.Length - memoryStream.Position >= 8L)
						{
							CSteamID cSteamID = new CSteamID(binaryReader.ReadUInt64());
							if (cSteamID != SteamUser.GetSteamID())
							{
								this._lobby.SetPlayedWith(cSteamID);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000B4E RID: 2894 RVA: 0x003CD820 File Offset: 0x003CBA20
		public override int Receive(RemoteAddress address, byte[] data, int offset, int length)
		{
			if (address == null)
			{
				return 0;
			}
			CSteamID user = this.RemoteAddressToSteamId(address);
			return this._reader.Receive(user, data, offset, length);
		}

		// Token: 0x06000B4C RID: 2892 RVA: 0x003CD7EF File Offset: 0x003CB9EF
		protected CSteamID RemoteAddressToSteamId(RemoteAddress address)
		{
			return ((SteamAddress)address).SteamId;
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x003CD7FC File Offset: 0x003CB9FC
		public override bool Send(RemoteAddress address, byte[] data, int length)
		{
			CSteamID user = this.RemoteAddressToSteamId(address);
			this._writer.QueueSend(user, data, length);
			return true;
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x003CD691 File Offset: 0x003CB891
		public override void Shutdown()
		{
			this._lobby.Leave();
		}

		// Token: 0x04000E8C RID: 3724
		protected const int ClientReadChannel = 2;

		// Token: 0x04000E8E RID: 3726
		protected const ushort GamePort = 27005;

		// Token: 0x04000E8D RID: 3725
		protected const int LobbyMessageJoin = 1;

		// Token: 0x04000E90 RID: 3728
		protected const ushort QueryPort = 27007;

		// Token: 0x04000E8B RID: 3723
		protected const int ServerReadChannel = 1;

		// Token: 0x04000E8F RID: 3727
		protected const ushort SteamPort = 27006;

		// Token: 0x04000E95 RID: 3733
		protected ConcurrentDictionary<CSteamID, NetSocialModule.ConnectionState> _connectionStateMap = new ConcurrentDictionary<CSteamID, NetSocialModule.ConnectionState>();

		// Token: 0x04000E91 RID: 3729
		protected static readonly byte[] _handshake = new byte[]
		{
			10,
			0,
			93,
			114,
			101,
			108,
			111,
			103,
			105,
			99
		};

		// Token: 0x04000E94 RID: 3732
		protected Lobby _lobby = new Lobby();

		// Token: 0x04000E97 RID: 3735
		private Callback<LobbyChatMsg_t> _lobbyChatMessage;

		// Token: 0x04000E92 RID: 3730
		protected SteamP2PReader _reader;

		// Token: 0x04000E96 RID: 3734
		protected object _steamLock = new object();

		// Token: 0x04000E93 RID: 3731
		protected SteamP2PWriter _writer;

		// Token: 0x0200024A RID: 586
		// Token: 0x0600162C RID: 5676
		protected delegate void AsyncHandshake(CSteamID client);

		// Token: 0x02000249 RID: 585
		public enum ConnectionState
		{
			// Token: 0x0400385C RID: 14428
			Inactive,
			// Token: 0x0400385D RID: 14429
			Authenticating,
			// Token: 0x0400385E RID: 14430
			Connected
		}
	}
}

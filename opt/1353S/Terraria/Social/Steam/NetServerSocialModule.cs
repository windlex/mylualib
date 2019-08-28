using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Steamworks;
using Terraria.Localization;
using Terraria.Net;
using Terraria.Net.Sockets;

namespace Terraria.Social.Steam
{
	// Token: 0x02000094 RID: 148
	public class NetServerSocialModule : NetSocialModule
	{
		// Token: 0x06000B36 RID: 2870 RVA: 0x003CD157 File Offset: 0x003CB357
		public NetServerSocialModule() : base(1, 2)
		{
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x003CD164 File Offset: 0x003CB364
		private void BroadcastConnectedUsers()
		{
			List<ulong> list = new List<ulong>();
			foreach (KeyValuePair<CSteamID, NetSocialModule.ConnectionState> current in this._connectionStateMap)
			{
				if (current.Value == NetSocialModule.ConnectionState.Connected)
				{
					list.Add(current.Key.m_SteamID);
				}
			}
			byte[] array = new byte[list.Count * 8 + 1];
			using (MemoryStream memoryStream = new MemoryStream(array))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(1);
					foreach (ulong current2 in list)
					{
						binaryWriter.Write(current2);
					}
				}
			}
			this._lobby.SendMessage(array);
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x00029F71 File Offset: 0x00028171
		public override void CancelJoin()
		{
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x003B65AC File Offset: 0x003B47AC
		public override bool CanInvite()
		{
			return false;
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x003CD3AC File Offset: 0x003CB5AC
		public override void Close(RemoteAddress address)
		{
			CSteamID user = base.RemoteAddressToSteamId(address);
			this.Close(user);
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x003CD3C8 File Offset: 0x003CB5C8
		private void Close(CSteamID user)
		{
			if (!this._connectionStateMap.ContainsKey(user))
			{
				return;
			}
			SteamUser.EndAuthSession(user);
			SteamNetworking.CloseP2PSessionWithUser(user);
			this._connectionStateMap[user] = NetSocialModule.ConnectionState.Inactive;
			this._reader.ClearUser(user);
			this._writer.ClearUser(user);
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x00029F71 File Offset: 0x00028171
		public override void Connect(RemoteAddress address)
		{
		}

		// Token: 0x06000B39 RID: 2873 RVA: 0x003CD37D File Offset: 0x003CB57D
		public override ulong GetLobbyId()
		{
			return this._lobby.Id.m_SteamID;
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x003CD274 File Offset: 0x003CB474
		public override void Initialize()
		{
			base.Initialize();
			this._reader.SetReadEvent(new SteamP2PReader.OnReadEvent(this.OnPacketRead));
			this._p2pSessionRequest = Callback<P2PSessionRequest_t>.Create(new Callback<P2PSessionRequest_t>.DispatchDelegate(this.OnP2PSessionRequest));
			if (Program.LaunchParameters.ContainsKey("-lobby"))
			{
				this._mode |= ServerMode.Lobby;
				string a = Program.LaunchParameters["-lobby"];
				if (!(a == "private"))
				{
					if (!(a == "friends"))
					{
						Console.WriteLine(Language.GetTextValue("Error.InvalidLobbyFlag", "private", "friends"));
					}
					else
					{
						this._mode |= ServerMode.FriendsCanJoin;
						this._lobby.Create(false, new CallResult<LobbyCreated_t>.APIDispatchDelegate(this.OnLobbyCreated));
					}
				}
				else
				{
					this._lobby.Create(true, new CallResult<LobbyCreated_t>.APIDispatchDelegate(this.OnLobbyCreated));
				}
			}
			if (Program.LaunchParameters.ContainsKey("-friendsoffriends"))
			{
				this._mode |= ServerMode.FriendsOfFriends;
			}
		}

		// Token: 0x06000B3D RID: 2877 RVA: 0x00029F71 File Offset: 0x00028171
		public override void LaunchLocalServer(Process process, ServerMode mode)
		{
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x003CD416 File Offset: 0x003CB616
		private void OnLobbyCreated(LobbyCreated_t result, bool failure)
		{
			if (failure)
			{
				return;
			}
			SteamFriends.SetRichPresence("status", Language.GetTextValue("Social.StatusInGame"));
		}

		// Token: 0x06000B45 RID: 2885 RVA: 0x003CD544 File Offset: 0x003CB744
		private void OnP2PSessionRequest(P2PSessionRequest_t result)
		{
			CSteamID steamIDRemote = result.m_steamIDRemote;
			if (this._connectionStateMap.ContainsKey(steamIDRemote) && this._connectionStateMap[steamIDRemote] != NetSocialModule.ConnectionState.Inactive)
			{
				SteamNetworking.AcceptP2PSessionWithUser(steamIDRemote);
				return;
			}
			if (!this._acceptingClients)
			{
				return;
			}
			if (!this._mode.HasFlag(ServerMode.FriendsOfFriends) && SteamFriends.GetFriendRelationship(steamIDRemote) != EFriendRelationship.k_EFriendRelationshipFriend)
			{
				return;
			}
			SteamNetworking.AcceptP2PSessionWithUser(steamIDRemote);
			P2PSessionState_t p2PSessionState_t;
			while (SteamNetworking.GetP2PSessionState(steamIDRemote, out p2PSessionState_t) && p2PSessionState_t.m_bConnecting == 1)
			{
			}
			if (p2PSessionState_t.m_bConnectionActive == 0)
			{
				this.Close(steamIDRemote);
			}
			this._connectionStateMap[steamIDRemote] = NetSocialModule.ConnectionState.Authenticating;
			this._connectionAcceptedCallback(new SocialSocket(new SteamAddress(steamIDRemote)));
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x003CD434 File Offset: 0x003CB634
		private bool OnPacketRead(byte[] data, int length, CSteamID userId)
		{
			if (!this._connectionStateMap.ContainsKey(userId) || this._connectionStateMap[userId] == NetSocialModule.ConnectionState.Inactive)
			{
				P2PSessionRequest_t result;
				result.m_steamIDRemote = userId;
				this.OnP2PSessionRequest(result);
				if (!this._connectionStateMap.ContainsKey(userId) || this._connectionStateMap[userId] == NetSocialModule.ConnectionState.Inactive)
				{
					return false;
				}
			}
			NetSocialModule.ConnectionState connectionState = this._connectionStateMap[userId];
			if (connectionState != NetSocialModule.ConnectionState.Authenticating)
			{
				return connectionState == NetSocialModule.ConnectionState.Connected;
			}
			if (length < 3)
			{
				return false;
			}
			if (((int)data[1] << 8 | (int)data[0]) != length)
			{
				return false;
			}
			if (data[2] != 93)
			{
				return false;
			}
			byte[] array = new byte[data.Length - 3];
			Array.Copy(data, 3, array, 0, array.Length);
			switch (SteamUser.BeginAuthSession(array, array.Length, userId))
			{
				case EBeginAuthSessionResult.k_EBeginAuthSessionResultOK:
					this._connectionStateMap[userId] = NetSocialModule.ConnectionState.Connected;
					this.BroadcastConnectedUsers();
					break;
				case EBeginAuthSessionResult.k_EBeginAuthSessionResultInvalidTicket:
					this.Close(userId);
					break;
				case EBeginAuthSessionResult.k_EBeginAuthSessionResultDuplicateRequest:
					this.Close(userId);
					break;
				case EBeginAuthSessionResult.k_EBeginAuthSessionResultInvalidVersion:
					this.Close(userId);
					break;
				case EBeginAuthSessionResult.k_EBeginAuthSessionResultGameMismatch:
					this.Close(userId);
					break;
				case EBeginAuthSessionResult.k_EBeginAuthSessionResultExpiredTicket:
					this.Close(userId);
					break;
			}
			return false;
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x00029F71 File Offset: 0x00028171
		public override void OpenInviteInterface()
		{
		}

		// Token: 0x06000B3E RID: 2878 RVA: 0x003CD38F File Offset: 0x003CB58F
		public override bool StartListening(SocketConnectionAccepted callback)
		{
			this._acceptingClients = true;
			this._connectionAcceptedCallback = callback;
			return true;
		}

		// Token: 0x06000B3F RID: 2879 RVA: 0x003CD3A0 File Offset: 0x003CB5A0
		public override void StopListening()
		{
			this._acceptingClients = false;
		}

		// Token: 0x04000E89 RID: 3721
		private bool _acceptingClients;

		// Token: 0x04000E8A RID: 3722
		private SocketConnectionAccepted _connectionAcceptedCallback;

		// Token: 0x04000E87 RID: 3719
		private ServerMode _mode;

		// Token: 0x04000E88 RID: 3720
		private Callback<P2PSessionRequest_t> _p2pSessionRequest;
	}
}

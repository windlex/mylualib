using System;
using System.Diagnostics;
using Steamworks;
using Terraria.IO;
using Terraria.Localization;
using Terraria.Net;
using Terraria.Net.Sockets;

namespace Terraria.Social.Steam
{
	// Token: 0x02000093 RID: 147
	public class NetClientSocialModule : NetSocialModule
	{
		// Token: 0x06000B22 RID: 2850 RVA: 0x003CCB81 File Offset: 0x003CAD81
		public NetClientSocialModule() : base(2, 1)
		{
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x003CCE4D File Offset: 0x003CB04D
		public override void CancelJoin()
		{
			if (this._lobby.State != LobbyState.Inactive)
			{
				this._lobby.Leave();
			}
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x003CCDBD File Offset: 0x003CAFBD
		public override bool CanInvite()
		{
			return (this._hasLocalHost || this._lobby.State == LobbyState.Active || Main.LobbyId != 0uL) && Main.netMode != 0;
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x003CCC14 File Offset: 0x003CAE14
		private void CheckParameters()
		{
			ulong ulSteamID;
			if (Program.LaunchParameters.ContainsKey("+connect_lobby") && ulong.TryParse(Program.LaunchParameters["+connect_lobby"], out ulSteamID))
			{
				CSteamID lobbySteamId = new CSteamID(ulSteamID);
				if (lobbySteamId.IsValid())
				{
					Main.OpenPlayerSelect(delegate (PlayerFileData playerData)
					{
						Main.ServerSideCharacter = false;
						playerData.SetAsActive();
						Main.menuMode = 882;
						Main.statusText = Language.GetTextValue("Social.Joining");
						this._lobby.Join(lobbySteamId, new CallResult<LobbyEnter_t>.APIDispatchDelegate(this.OnLobbyEntered));
					});
				}
			}
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x003CD098 File Offset: 0x003CB298
		private void ClearAuthTicket()
		{
			if (this._authTicket != HAuthTicket.Invalid)
			{
				SteamUser.CancelAuthTicket(this._authTicket);
			}
			this._authTicket = HAuthTicket.Invalid;
			for (int i = 0; i < this._authData.Length; i++)
			{
				this._authData[i] = 0;
			}
			this._authDataLength = 0u;
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x003CCD9C File Offset: 0x003CAF9C
		public override void Close(RemoteAddress address)
		{
			SteamFriends.ClearRichPresence();
			CSteamID user = base.RemoteAddressToSteamId(address);
			this.Close(user);
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x003CCDF4 File Offset: 0x003CAFF4
		private void Close(CSteamID user)
		{
			if (!this._connectionStateMap.ContainsKey(user))
			{
				return;
			}
			SteamNetworking.CloseP2PSessionWithUser(user);
			this.ClearAuthTicket();
			this._connectionStateMap[user] = NetSocialModule.ConnectionState.Inactive;
			this._lobby.Leave();
			this._reader.ClearUser(user);
			this._writer.ClearUser(user);
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x00029F71 File Offset: 0x00028171
		public override void Connect(RemoteAddress address)
		{
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x003CCD96 File Offset: 0x003CAF96
		public override ulong GetLobbyId()
		{
			return 0uL;
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x003CCBA8 File Offset: 0x003CADA8
		public override void Initialize()
		{
			base.Initialize();
			this._gameLobbyJoinRequested = Callback<GameLobbyJoinRequested_t>.Create(new Callback<GameLobbyJoinRequested_t>.DispatchDelegate(this.OnLobbyJoinRequest));
			this._p2pSessionRequest = Callback<P2PSessionRequest_t>.Create(new Callback<P2PSessionRequest_t>.DispatchDelegate(this.OnP2PSessionRequest));
			this._p2pSessionConnectfail = Callback<P2PSessionConnectFail_t>.Create(new Callback<P2PSessionConnectFail_t>.DispatchDelegate(this.OnSessionConnectFail));
			Main.OnEngineLoad += new Action(this.CheckParameters);
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x003CCC84 File Offset: 0x003CAE84
		public override void LaunchLocalServer(Process process, ServerMode mode)
		{
			if (this._lobby.State != LobbyState.Inactive)
			{
				this._lobby.Leave();
			}
			ProcessStartInfo expr_1E = process.StartInfo;
			expr_1E.Arguments = expr_1E.Arguments + " -steam -localsteamid " + SteamUser.GetSteamID().m_SteamID;
			if (mode.HasFlag(ServerMode.Lobby))
			{
				this._hasLocalHost = true;
				if (mode.HasFlag(ServerMode.FriendsCanJoin))
				{
					ProcessStartInfo expr_78 = process.StartInfo;
					expr_78.Arguments += " -lobby friends";
				}
				else
				{
					ProcessStartInfo expr_95 = process.StartInfo;
					expr_95.Arguments += " -lobby private";
				}
				if (mode.HasFlag(ServerMode.FriendsOfFriends))
				{
					ProcessStartInfo expr_C3 = process.StartInfo;
					expr_C3.Arguments += " -friendsoffriends";
				}
			}
			SteamFriends.SetRichPresence("status", Language.GetTextValue("Social.StatusInGame"));
			Netplay.OnDisconnect += new Action(this.OnDisconnect);
			process.Start();
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x003CD0F0 File Offset: 0x003CB2F0
		private void OnDisconnect()
		{
			SteamFriends.ClearRichPresence();
			this._hasLocalHost = false;
			Netplay.OnDisconnect -= new Action(this.OnDisconnect);
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x003CCEC8 File Offset: 0x003CB0C8
		private void OnLobbyEntered(LobbyEnter_t result, bool failure)
		{
			SteamNetworking.AllowP2PPacketRelay(true);
			this.SendAuthTicket(this._lobby.Owner);
			int num = 0;
			P2PSessionState_t p2PSessionState_t;
			while (SteamNetworking.GetP2PSessionState(this._lobby.Owner, out p2PSessionState_t) && p2PSessionState_t.m_bConnectionActive != 1)
			{
				switch (p2PSessionState_t.m_eP2PSessionError)
				{
					case 1:
						this.ClearAuthTicket();
						return;
					case 2:
						this.ClearAuthTicket();
						return;
					case 3:
						this.ClearAuthTicket();
						return;
					case 4:
						if (++num > 5)
						{
							this.ClearAuthTicket();
							return;
						}
						SteamNetworking.CloseP2PSessionWithUser(this._lobby.Owner);
						this.SendAuthTicket(this._lobby.Owner);
						break;
					case 5:
						this.ClearAuthTicket();
						return;
				}
			}
			this._connectionStateMap[this._lobby.Owner] = NetSocialModule.ConnectionState.Connected;
			SteamFriends.SetPlayedWith(this._lobby.Owner);
			SteamFriends.SetRichPresence("status", Language.GetTextValue("Social.StatusInGame"));
			Main.clrInput();
			Netplay.ServerPassword = "";
			Main.GetInputText("");
			Main.autoPass = false;
			Main.netMode = 1;
			Netplay.OnConnectedToSocialServer(new SocialSocket(new SteamAddress(this._lobby.Owner)));
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x003CCE68 File Offset: 0x003CB068
		private void OnLobbyJoinRequest(GameLobbyJoinRequested_t result)
		{
			if (this._lobby.State != LobbyState.Inactive)
			{
				this._lobby.Leave();
			}
			string friendName = SteamFriends.GetFriendPersonaName(result.m_steamIDFriend);
			Main.OpenPlayerSelect(delegate (PlayerFileData playerData)
			{
				Main.ServerSideCharacter = false;
				playerData.SetAsActive();
				Main.menuMode = 882;
				Main.statusText = Language.GetTextValue("Social.JoiningFriend", friendName);
				this._lobby.Join(result.m_steamIDLobby, new CallResult<LobbyEnter_t>.APIDispatchDelegate(this.OnLobbyEntered));
			});
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x003CD120 File Offset: 0x003CB320
		private void OnP2PSessionRequest(P2PSessionRequest_t result)
		{
			CSteamID steamIDRemote = result.m_steamIDRemote;
			if (this._connectionStateMap.ContainsKey(steamIDRemote) && this._connectionStateMap[steamIDRemote] != NetSocialModule.ConnectionState.Inactive)
			{
				SteamNetworking.AcceptP2PSessionWithUser(steamIDRemote);
			}
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x003CD10F File Offset: 0x003CB30F
		private void OnSessionConnectFail(P2PSessionConnectFail_t result)
		{
			this.Close(result.m_steamIDRemote);
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x003CCDE6 File Offset: 0x003CAFE6
		public override void OpenInviteInterface()
		{
			this._lobby.OpenInviteOverlay();
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x003CD000 File Offset: 0x003CB200
		private void SendAuthTicket(CSteamID address)
		{
			if (this._authTicket == HAuthTicket.Invalid)
			{
				this._authTicket = SteamUser.GetAuthSessionTicket(this._authData, this._authData.Length, out this._authDataLength);
			}
			int num = (int)(this._authDataLength + 3u);
			byte[] array = new byte[num];
			array[0] = (byte)(num & 255);
			array[1] = (byte)(num >> 8 & 255);
			array[2] = 93;
			int num2 = 0;
			while ((long)num2 < (long)((ulong)this._authDataLength))
			{
				array[num2 + 3] = this._authData[num2];
				num2++;
			}
			SteamNetworking.SendP2PPacket(address, array, (uint)num, EP2PSend.k_EP2PSendReliable, 1);
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x003B65AC File Offset: 0x003B47AC
		public override bool StartListening(SocketConnectionAccepted callback)
		{
			return false;
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x00029F71 File Offset: 0x00028171
		public override void StopListening()
		{
		}

		// Token: 0x04000E84 RID: 3716
		private byte[] _authData = new byte[1021];

		// Token: 0x04000E85 RID: 3717
		private uint _authDataLength;

		// Token: 0x04000E83 RID: 3715
		private HAuthTicket _authTicket = HAuthTicket.Invalid;

		// Token: 0x04000E80 RID: 3712
		private Callback<GameLobbyJoinRequested_t> _gameLobbyJoinRequested;

		// Token: 0x04000E86 RID: 3718
		private bool _hasLocalHost;

		// Token: 0x04000E82 RID: 3714
		private Callback<P2PSessionConnectFail_t> _p2pSessionConnectfail;

		// Token: 0x04000E81 RID: 3713
		private Callback<P2PSessionRequest_t> _p2pSessionRequest;
	}
}

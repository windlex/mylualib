using System;
using System.Collections.Generic;
using Steamworks;

namespace Terraria.Social.Steam
{
	// Token: 0x02000092 RID: 146
	public class Lobby
	{
		// Token: 0x06000B14 RID: 2836 RVA: 0x003CC8D4 File Offset: 0x003CAAD4
		public Lobby()
		{
			this._lobbyEnter = CallResult<LobbyEnter_t>.Create(new CallResult<LobbyEnter_t>.APIDispatchDelegate(this.OnLobbyEntered));
			this._lobbyCreated = CallResult<LobbyCreated_t>.Create(new CallResult<LobbyCreated_t>.APIDispatchDelegate(this.OnLobbyCreated));
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x003CC948 File Offset: 0x003CAB48
		public void Create(bool inviteOnly, CallResult<LobbyCreated_t>.APIDispatchDelegate callResult)
		{
			SteamAPICall_t hAPICall = SteamMatchmaking.CreateLobby(inviteOnly ? ELobbyType.k_ELobbyTypePrivate : ELobbyType.k_ELobbyTypeFriendsOnly, 256);
			this._lobbyCreatedExternalCallback = callResult;
			this._lobbyCreated.Set(hAPICall, null);
			this.State = LobbyState.Creating;
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x003CC9E0 File Offset: 0x003CABE0
		public byte[] GetMessage(int index)
		{
			CSteamID cSteamID;
			EChatEntryType eChatEntryType;
			int lobbyChatEntry = SteamMatchmaking.GetLobbyChatEntry(this.Id, index, out cSteamID, this._messageBuffer, this._messageBuffer.Length, out eChatEntryType);
			byte[] array = new byte[lobbyChatEntry];
			Array.Copy(this._messageBuffer, array, lobbyChatEntry);
			return array;
		}

		// Token: 0x06000B1A RID: 2842 RVA: 0x003CCA2E File Offset: 0x003CAC2E
		public CSteamID GetUserByIndex(int index)
		{
			return SteamMatchmaking.GetLobbyMemberByIndex(this.Id, index);
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x003CCA21 File Offset: 0x003CAC21
		public int GetUserCount()
		{
			return SteamMatchmaking.GetNumLobbyMembers(this.Id);
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x003CC9A8 File Offset: 0x003CABA8
		public void Join(CSteamID lobbyId, CallResult<LobbyEnter_t>.APIDispatchDelegate callResult)
		{
			if (this.State != LobbyState.Inactive)
			{
				return;
			}
			this.State = LobbyState.Connecting;
			this._lobbyEnterExternalCallback = callResult;
			SteamAPICall_t hAPICall = SteamMatchmaking.JoinLobby(lobbyId);
			this._lobbyEnter.Set(hAPICall, null);
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x003CCAA2 File Offset: 0x003CACA2
		public void Leave()
		{
			if (this.State == LobbyState.Active)
			{
				SteamMatchmaking.LeaveLobby(this.Id);
			}
			this.State = LobbyState.Inactive;
			this._usersSeen.Clear();
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x003CCB28 File Offset: 0x003CAD28
		private void OnLobbyCreated(LobbyCreated_t result, bool failure)
		{
			if (this.State != LobbyState.Creating)
			{
				return;
			}
			if (failure)
			{
				this.State = LobbyState.Inactive;
			}
			else
			{
				this.State = LobbyState.Active;
			}
			this.Id = new CSteamID(result.m_ulSteamIDLobby);
			this.Owner = SteamMatchmaking.GetLobbyOwner(this.Id);
			this._lobbyCreatedExternalCallback(result, failure);
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x003CCACC File Offset: 0x003CACCC
		private void OnLobbyEntered(LobbyEnter_t result, bool failure)
		{
			if (this.State != LobbyState.Connecting)
			{
				return;
			}
			if (failure)
			{
				this.State = LobbyState.Inactive;
			}
			else
			{
				this.State = LobbyState.Active;
			}
			this.Id = new CSteamID(result.m_ulSteamIDLobby);
			this.Owner = SteamMatchmaking.GetLobbyOwner(this.Id);
			this._lobbyEnterExternalCallback(result, failure);
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x003CC982 File Offset: 0x003CAB82
		public void OpenInviteOverlay()
		{
			if (this.State == LobbyState.Inactive)
			{
				SteamFriends.ActivateGameOverlayInviteDialog(new CSteamID(Main.LobbyId));
				return;
			}
			SteamFriends.ActivateGameOverlayInviteDialog(this.Id);
		}

		// Token: 0x06000B1B RID: 2843 RVA: 0x003CCA3C File Offset: 0x003CAC3C
		public bool SendMessage(byte[] data)
		{
			return this.SendMessage(data, data.Length);
		}

		// Token: 0x06000B1C RID: 2844 RVA: 0x003CCA48 File Offset: 0x003CAC48
		public bool SendMessage(byte[] data, int length)
		{
			return this.State == LobbyState.Active && SteamMatchmaking.SendLobbyChatMsg(this.Id, data, length);
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x003CCA62 File Offset: 0x003CAC62
		public void Set(CSteamID lobbyId)
		{
			this.Id = lobbyId;
			this.State = LobbyState.Active;
			this.Owner = SteamMatchmaking.GetLobbyOwner(lobbyId);
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x003CCA7E File Offset: 0x003CAC7E
		public void SetPlayedWith(CSteamID userId)
		{
			if (this._usersSeen.Contains(userId))
			{
				return;
			}
			SteamFriends.SetPlayedWith(userId);
			this._usersSeen.Add(userId);
		}

		// Token: 0x04000E79 RID: 3705
		public CSteamID Id = CSteamID.Nil;

		// Token: 0x04000E7A RID: 3706
		public CSteamID Owner = CSteamID.Nil;

		// Token: 0x04000E7B RID: 3707
		public LobbyState State;

		// Token: 0x04000E7E RID: 3710
		private CallResult<LobbyCreated_t> _lobbyCreated;

		// Token: 0x04000E7F RID: 3711
		private CallResult<LobbyCreated_t>.APIDispatchDelegate _lobbyCreatedExternalCallback;

		// Token: 0x04000E7C RID: 3708
		private CallResult<LobbyEnter_t> _lobbyEnter;

		// Token: 0x04000E7D RID: 3709
		private CallResult<LobbyEnter_t>.APIDispatchDelegate _lobbyEnterExternalCallback;

		// Token: 0x04000E78 RID: 3704
		private byte[] _messageBuffer = new byte[1024];

		// Token: 0x04000E77 RID: 3703
		private HashSet<CSteamID> _usersSeen = new HashSet<CSteamID>();
	}
}

using System;
using Steamworks;
using Terraria.Social.Base;

namespace Terraria.Social.Steam
{
	// Token: 0x02000090 RID: 144
	public class FriendsSocialModule : Terraria.Social.Base.FriendsSocialModule
	{
		// Token: 0x06000B11 RID: 2833 RVA: 0x003CC8B7 File Offset: 0x003CAAB7
		public override string GetUsername()
		{
			return SteamFriends.GetPersonaName();
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x00029F71 File Offset: 0x00028171
		public override void Initialize()
		{
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x003CC8BE File Offset: 0x003CAABE
		public override void OpenJoinInterface()
		{
			SteamFriends.ActivateGameOverlay("Friends");
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x00029F71 File Offset: 0x00028171
		public override void Shutdown()
		{
		}
	}
}

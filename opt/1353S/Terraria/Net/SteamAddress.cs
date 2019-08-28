using System;
using Steamworks;

namespace Terraria.Net
{
	// Token: 0x0200006A RID: 106
	public class SteamAddress : RemoteAddress
	{
		// Token: 0x060009C8 RID: 2504 RVA: 0x003B6EB4 File Offset: 0x003B50B4
		public SteamAddress(CSteamID steamId)
		{
			this.Type = AddressType.Steam;
			this.SteamId = steamId;
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x003B6ECC File Offset: 0x003B50CC
		public override string ToString()
		{
			string str = (this.SteamId.m_SteamID % 2uL).ToString();
			string str2 = ((this.SteamId.m_SteamID - (76561197960265728uL + this.SteamId.m_SteamID % 2uL)) / 2uL).ToString();
			return "STEAM_0:" + str + ":" + str2;
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x003B6F34 File Offset: 0x003B5134
		public override string GetIdentifier()
		{
			return this.ToString();
		}

		// Token: 0x060009CB RID: 2507 RVA: 0x003B6F3C File Offset: 0x003B513C
		public override bool IsLocalHost()
		{
			return Program.LaunchParameters.ContainsKey("-localsteamid") && Program.LaunchParameters["-localsteamid"].Equals(this.SteamId.m_SteamID.ToString());
		}

		// Token: 0x060009CC RID: 2508 RVA: 0x003B6F84 File Offset: 0x003B5184
		public override string GetFriendlyName()
		{
			if (this._friendlyName == null)
			{
				this._friendlyName = SteamFriends.GetFriendPersonaName(this.SteamId);
			}
			return this._friendlyName;
		}

		// Token: 0x04000DB9 RID: 3513
		public readonly CSteamID SteamId;

		// Token: 0x04000DBA RID: 3514
		private string _friendlyName;
	}
}

using System;

namespace Terraria.Net
{
	// Token: 0x0200006B RID: 107
	[Flags]
	public enum ServerMode : byte
	{
		// Token: 0x04000DBC RID: 3516
		None = 0,
		// Token: 0x04000DBD RID: 3517
		Lobby = 1,
		// Token: 0x04000DBE RID: 3518
		FriendsCanJoin = 2,
		// Token: 0x04000DBF RID: 3519
		FriendsOfFriends = 4
	}
}

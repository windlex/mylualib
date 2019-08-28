using System;
using Terraria.GameContent.NetModules;
using Terraria.Localization;
using Terraria.Net;

namespace Terraria.Chat.Commands
{
	// Token: 0x020001A2 RID: 418
	[ChatCommand("Say")]
	public class SayChatCommand : IChatCommand
	{
		// Token: 0x0600136B RID: 4971 RVA: 0x0041B92C File Offset: 0x00419B2C
		public void ProcessMessage(string text, byte clientId)
		{
			NetPacket packet = NetTextModule.SerializeServerMessage(NetworkText.FromLiteral(text), Main.player[(int)clientId].ChatColor(), clientId);
			NetManager.Instance.Broadcast(packet, -1);
			Console.WriteLine("<{0}> {1}", Main.player[(int)clientId].name, text);
		}
	}
}

using System;
using Microsoft.Xna.Framework;
using Terraria.GameContent.NetModules;
using Terraria.Localization;
using Terraria.Net;

namespace Terraria.Chat.Commands
{
	// Token: 0x020001A0 RID: 416
	[ChatCommand("Party")]
	public class PartyChatCommand : IChatCommand
	{
		// Token: 0x06001363 RID: 4963 RVA: 0x0041B7D8 File Offset: 0x004199D8
		public void ProcessMessage(string text, byte clientId)
		{
			int team = Main.player[(int)clientId].team;
			Color color = Main.teamColor[team];
			if (team == 0)
			{
				this.SendNoTeamError(clientId);
				return;
			}
			if (text == "")
			{
				return;
			}
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].team == team)
				{
					NetPacket packet = NetTextModule.SerializeServerMessage(NetworkText.FromLiteral(text), color, clientId);
					NetManager.Instance.SendToClient(packet, i);
				}
			}
		}

		// Token: 0x06001364 RID: 4964 RVA: 0x0041B850 File Offset: 0x00419A50
		private void SendNoTeamError(byte clientId)
		{
			NetPacket packet = NetTextModule.SerializeServerMessage(Lang.mp[10].ToNetworkText(), PartyChatCommand.ERROR_COLOR);
			NetManager.Instance.SendToClient(packet, (int)clientId);
		}

		// Token: 0x040034B0 RID: 13488
		private static readonly Color ERROR_COLOR = new Color(255, 240, 20);
	}
}

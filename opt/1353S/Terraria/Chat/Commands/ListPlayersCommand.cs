using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Terraria.Chat.Commands
{
	// Token: 0x0200019F RID: 415
	[ChatCommand("Playing")]
	public class ListPlayersCommand : IChatCommand
	{
		// Token: 0x06001360 RID: 4960 RVA: 0x0041A4C8 File Offset: 0x004186C8
		public void ProcessMessage(string text, byte clientId)
		{
			string spliter = ", ";
			IEnumerable<Player> players = Main.player.Where((player) => { return player.active; });
			NetMessage.SendChatMessageToClient(NetworkText.FromLiteral(string.Join(spliter, players.Select((player) => { return player.name; }))), ListPlayersCommand.RESPONSE_COLOR, (int)clientId);
		}

		// Token: 0x040034AF RID: 13487
		private static readonly Color RESPONSE_COLOR = new Color(255, 240, 20);
	}
}

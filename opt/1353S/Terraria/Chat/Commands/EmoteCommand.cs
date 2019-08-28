using System;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Terraria.Chat.Commands
{
	// Token: 0x0200019E RID: 414
	[ChatCommand("Emote")]
	public class EmoteCommand : IChatCommand
	{
		// Token: 0x0600135D RID: 4957 RVA: 0x0041B6EC File Offset: 0x004198EC
		public void ProcessMessage(string text, byte clientId)
		{
			if (text != "")
			{
				text = string.Format("*{0} {1}", Main.player[(int)clientId].name, text);
				NetMessage.BroadcastChatMessage(NetworkText.FromLiteral(text), EmoteCommand.RESPONSE_COLOR, -1);
			}
		}

		// Token: 0x040034AE RID: 13486
		private static readonly Color RESPONSE_COLOR = new Color(200, 100, 0);
	}
}

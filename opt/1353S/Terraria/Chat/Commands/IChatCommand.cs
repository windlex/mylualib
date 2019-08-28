using System;

namespace Terraria.Chat.Commands
{
	// Token: 0x0200019D RID: 413
	public interface IChatCommand
	{
		// Token: 0x0600135C RID: 4956
		void ProcessMessage(string text, byte clientId);
	}
}

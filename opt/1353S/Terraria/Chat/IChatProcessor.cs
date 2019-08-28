using System;

namespace Terraria.Chat
{
	// Token: 0x0200019B RID: 411
	public interface IChatProcessor
	{
		// Token: 0x06001359 RID: 4953
		bool ProcessReceivedMessage(ChatMessage message, int clientId);

		// Token: 0x0600135A RID: 4954
		bool ProcessOutgoingMessage(ChatMessage message);
	}
}

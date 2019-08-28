using System;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Terraria.Chat.Commands
{
	// Token: 0x020001A1 RID: 417
	[ChatCommand("Roll")]
	public class RollCommand : IChatCommand
	{
		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06001367 RID: 4967 RVA: 0x0041B8A4 File Offset: 0x00419AA4
		public string InternalName
		{
			get
			{
				return "roll";
			}
		}

		// Token: 0x06001368 RID: 4968 RVA: 0x0041B8AC File Offset: 0x00419AAC
		public void ProcessMessage(string text, byte clientId)
		{
			int num = Main.rand.Next(1, 101);
			NetMessage.BroadcastChatMessage(NetworkText.FromFormattable("*{0} {1} {2}", new object[]
			{
				Main.player[(int)clientId].name,
				Lang.mp[9].ToNetworkText(),
				num
			}), RollCommand.RESPONSE_COLOR, -1);
		}

		// Token: 0x040034B1 RID: 13489
		private static readonly Color RESPONSE_COLOR = new Color(255, 240, 20);
	}
}

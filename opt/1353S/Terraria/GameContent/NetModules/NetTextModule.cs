using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria.Chat;
using Terraria.GameContent.UI.Chat;
using Terraria.Localization;
using Terraria.Net;
using Terraria.UI.Chat;

namespace Terraria.GameContent.NetModules
{
	// Token: 0x02000170 RID: 368
	public class NetTextModule : NetModule
	{
		// Token: 0x0600120E RID: 4622 RVA: 0x00412CE4 File Offset: 0x00410EE4
		public static NetPacket SerializeClientMessage(ChatMessage message)
		{
			NetPacket result = NetModule.CreatePacket<NetTextModule>(message.GetMaxSerializedSize());
			message.Serialize(result.Writer);
			return result;
		}

		// Token: 0x0600120F RID: 4623 RVA: 0x00412D0C File Offset: 0x00410F0C
		public static NetPacket SerializeServerMessage(NetworkText text, Color color)
		{
			return NetTextModule.SerializeServerMessage(text, color, 255);
		}

		// Token: 0x06001210 RID: 4624 RVA: 0x00412D1C File Offset: 0x00410F1C
		public static NetPacket SerializeServerMessage(NetworkText text, Color color, byte authorId)
		{
			NetPacket result = NetModule.CreatePacket<NetTextModule>(1 + text.GetMaxSerializedSize() + 3);
			result.Writer.Write(authorId);
			text.Serialize(result.Writer);
			result.Writer.WriteRGB(color);
			return result;
		}

		// Token: 0x06001211 RID: 4625 RVA: 0x00412D64 File Offset: 0x00410F64
		private bool DeserializeAsClient(BinaryReader reader, int senderPlayerId)
		{
			byte b = reader.ReadByte();
			string text = NetworkText.Deserialize(reader).ToString();
			Color c = reader.ReadRGB();
			if (b < 255)
			{
				Main.player[(int)b].chatOverhead.NewMessage(text, Main.chatLength / 2);
				text = NameTagHandler.GenerateTag(Main.player[(int)b].name) + " " + text;
			}
			Main.NewTextMultiline(text, false, c, -1);
			return true;
		}

		// Token: 0x06001212 RID: 4626 RVA: 0x00412DD4 File Offset: 0x00410FD4
		private bool DeserializeAsServer(BinaryReader reader, int senderPlayerId)
		{
			ChatMessage message = ChatMessage.Deserialize(reader);
			ChatManager.Commands.ProcessReceivedMessage(message, senderPlayerId);
			return true;
		}

		// Token: 0x06001213 RID: 4627 RVA: 0x00412DF8 File Offset: 0x00410FF8
		private void BroadcastRawMessage(ChatMessage message, byte author, Color messageColor)
		{
			NetManager.Instance.Broadcast(NetTextModule.SerializeServerMessage(NetworkText.FromLiteral(message.Text), messageColor), -1);
		}

		// Token: 0x06001214 RID: 4628 RVA: 0x00412E18 File Offset: 0x00411018
		public override bool Deserialize(BinaryReader reader, int senderPlayerId)
		{
			return this.DeserializeAsClient(reader, senderPlayerId);
		}
	}
}

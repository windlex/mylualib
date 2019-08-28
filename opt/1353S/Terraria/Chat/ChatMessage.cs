using System;
using System.IO;
using System.Text;
using Terraria.Chat.Commands;

namespace Terraria.Chat
{
	// Token: 0x0200019A RID: 410
	public class ChatMessage
	{
		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x0600134E RID: 4942 RVA: 0x0041B5EC File Offset: 0x004197EC
		// (set) Token: 0x0600134F RID: 4943 RVA: 0x0041B5F4 File Offset: 0x004197F4
		public ChatCommandId CommandId
		{
			get;
			private set;
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06001350 RID: 4944 RVA: 0x0041B600 File Offset: 0x00419800
		// (set) Token: 0x06001351 RID: 4945 RVA: 0x0041B608 File Offset: 0x00419808
		public string Text
		{
			get;
			set;
		}

		// Token: 0x06001352 RID: 4946 RVA: 0x0041B614 File Offset: 0x00419814
		public ChatMessage(string message)
		{
			this.CommandId = ChatCommandId.FromType<SayChatCommand>();
			this.Text = message;
		}

		// Token: 0x06001353 RID: 4947 RVA: 0x0041B630 File Offset: 0x00419830
		private ChatMessage(string message, ChatCommandId commandId)
		{
			this.CommandId = commandId;
			this.Text = message;
		}

		// Token: 0x06001354 RID: 4948 RVA: 0x0041B648 File Offset: 0x00419848
		public void Serialize(BinaryWriter writer)
		{
			this.CommandId.Serialize(writer);
			writer.Write(this.Text);
		}

		// Token: 0x06001355 RID: 4949 RVA: 0x0041B670 File Offset: 0x00419870
		public int GetMaxSerializedSize()
		{
			return 0 + this.CommandId.GetMaxSerializedSize() + (4 + Encoding.UTF8.GetByteCount(this.Text));
		}

		// Token: 0x06001356 RID: 4950 RVA: 0x0041B6A0 File Offset: 0x004198A0
		public static ChatMessage Deserialize(BinaryReader reader)
		{
			ChatCommandId commandId = ChatCommandId.Deserialize(reader);
			return new ChatMessage(reader.ReadString(), commandId);
		}

		// Token: 0x06001357 RID: 4951 RVA: 0x0041B6C0 File Offset: 0x004198C0
		public void SetCommand(ChatCommandId commandId)
		{
			this.CommandId = commandId;
		}

		// Token: 0x06001358 RID: 4952 RVA: 0x0041B6CC File Offset: 0x004198CC
		public void SetCommand<T>() where T : IChatCommand
		{
			this.CommandId = ChatCommandId.FromType<T>();
		}
	}
}

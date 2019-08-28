using System;
using System.IO;
using System.Text;
using ReLogic.Utilities;
using Terraria.Chat.Commands;

namespace Terraria.Chat
{
	// Token: 0x02000198 RID: 408
	public struct ChatCommandId
	{
		// Token: 0x06001342 RID: 4930 RVA: 0x0041B2F4 File Offset: 0x004194F4
		private ChatCommandId(string name)
		{
			this._name = name;
		}

		// Token: 0x06001343 RID: 4931 RVA: 0x0041B300 File Offset: 0x00419500
		public static ChatCommandId FromType<T>() where T : IChatCommand
		{
			ChatCommandAttribute cacheableAttribute = AttributeUtilities.GetCacheableAttribute<T, ChatCommandAttribute>();
			if (cacheableAttribute != null)
			{
				return new ChatCommandId(cacheableAttribute.Name);
			}
			return new ChatCommandId(null);
		}

		// Token: 0x06001344 RID: 4932 RVA: 0x0041B328 File Offset: 0x00419528
		public void Serialize(BinaryWriter writer)
		{
			writer.Write(this._name ?? "");
		}

		// Token: 0x06001345 RID: 4933 RVA: 0x0041B340 File Offset: 0x00419540
		public static ChatCommandId Deserialize(BinaryReader reader)
		{
			return new ChatCommandId(reader.ReadString());
		}

		// Token: 0x06001346 RID: 4934 RVA: 0x0041B350 File Offset: 0x00419550
		public int GetMaxSerializedSize()
		{
			return 4 + Encoding.UTF8.GetByteCount(this._name ?? "");
		}

		// Token: 0x040034A7 RID: 13479
		private readonly string _name;
	}
}

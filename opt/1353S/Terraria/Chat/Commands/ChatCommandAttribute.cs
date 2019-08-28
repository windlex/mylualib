using System;

namespace Terraria.Chat.Commands
{
	// Token: 0x0200019C RID: 412
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
	public sealed class ChatCommandAttribute : Attribute
	{
		// Token: 0x0600135B RID: 4955 RVA: 0x0041B6DC File Offset: 0x004198DC
		public ChatCommandAttribute(string name)
		{
			this.Name = name;
		}

		// Token: 0x040034AD RID: 13485
		public readonly string Name;
	}
}

using System;
using Microsoft.Xna.Framework;

namespace Terraria.UI.Chat
{
	// Token: 0x020000B2 RID: 178
	public class ChatLine
	{
		// Token: 0x04000F14 RID: 3860
		public Color color = Color.White;

		// Token: 0x04000F15 RID: 3861
		public int showTime;

		// Token: 0x04000F16 RID: 3862
		public string text = "";

		// Token: 0x04000F17 RID: 3863
		public TextSnippet[] parsedText = new TextSnippet[0];
	}
}

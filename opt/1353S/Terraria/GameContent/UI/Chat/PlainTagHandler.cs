using System;
using Microsoft.Xna.Framework;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Chat
{
	// Token: 0x0200015F RID: 351
	public class PlainTagHandler : ITagHandler
	{
		// Token: 0x0600118F RID: 4495 RVA: 0x0040E0A8 File Offset: 0x0040C2A8
		TextSnippet ITagHandler.Parse(string text, Color baseColor, string options)
		{
			return new PlainTagHandler.PlainSnippet(text);
		}

		// Token: 0x020002B1 RID: 689
		public class PlainSnippet : TextSnippet
		{
			// Token: 0x06001777 RID: 6007 RVA: 0x0043C288 File Offset: 0x0043A488
			public PlainSnippet(string text = "") : base(text)
			{
			}

			// Token: 0x06001778 RID: 6008 RVA: 0x0043C294 File Offset: 0x0043A494
			public PlainSnippet(string text, Color color, float scale = 1f) : base(text, color, scale)
			{
			}

			// Token: 0x06001779 RID: 6009 RVA: 0x0043C2A0 File Offset: 0x0043A4A0
			public override Color GetVisibleColor()
			{
				return this.Color;
			}
		}
	}
}

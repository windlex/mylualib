using System;
using Microsoft.Xna.Framework;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Chat
{
	// Token: 0x0200015E RID: 350
	public class NameTagHandler : ITagHandler
	{
		// Token: 0x0600118C RID: 4492 RVA: 0x0040E034 File Offset: 0x0040C234
		TextSnippet ITagHandler.Parse(string text, Color baseColor, string options)
		{
			return new TextSnippet("<" + text.Replace("\\[", "[").Replace("\\]", "]") + ">", baseColor, 1f);
		}

		// Token: 0x0600118D RID: 4493 RVA: 0x0040E070 File Offset: 0x0040C270
		public static string GenerateTag(string name)
		{
			return "[n:" + name.Replace("[", "\\[").Replace("]", "\\]") + "]";
		}
	}
}

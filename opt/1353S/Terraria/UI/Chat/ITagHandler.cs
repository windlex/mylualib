using System;
using Microsoft.Xna.Framework;

namespace Terraria.UI.Chat
{
	// Token: 0x020000B4 RID: 180
	public interface ITagHandler
	{
		// Token: 0x06000C61 RID: 3169
		TextSnippet Parse(string text, Color baseColor = default(Color), string options = null);
	}
}

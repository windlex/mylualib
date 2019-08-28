using System;
using System.Globalization;
using Microsoft.Xna.Framework;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Chat
{
	// Token: 0x0200015C RID: 348
	public class ColorTagHandler : ITagHandler
	{
		// Token: 0x06001187 RID: 4487 RVA: 0x0040DE14 File Offset: 0x0040C014
		TextSnippet ITagHandler.Parse(string text, Color baseColor, string options)
		{
			TextSnippet textSnippet = new TextSnippet(text);
			int num;
			if (!int.TryParse(options, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out num))
			{
				return textSnippet;
			}
			textSnippet.Color = new Color(num >> 16 & 255, num >> 8 & 255, num & 255);
			return textSnippet;
		}
	}
}

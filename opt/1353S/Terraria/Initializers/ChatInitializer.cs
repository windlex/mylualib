using System;
using Terraria.Chat.Commands;
using Terraria.GameContent.UI.Chat;
using Terraria.UI.Chat;

namespace Terraria.Initializers
{
	// Token: 0x02000083 RID: 131
	public static class ChatInitializer
	{
		// Token: 0x06000AB9 RID: 2745 RVA: 0x003C6F6C File Offset: 0x003C516C
		public static void Load()
		{
			ChatManager.Register<ColorTagHandler>(new string[]
			{
				"c",
				"color"
			});
			ChatManager.Register<ItemTagHandler>(new string[]
			{
				"i",
				"item"
			});
			ChatManager.Register<NameTagHandler>(new string[]
			{
				"n",
				"name"
			});
			ChatManager.Register<AchievementTagHandler>(new string[]
			{
				"a",
				"achievement"
			});
			ChatManager.Register<GlyphTagHandler>(new string[]
			{
				"g",
				"glyph"
			});
			ChatManager.Commands.AddCommand<PartyChatCommand>().AddCommand<RollCommand>().AddCommand<EmoteCommand>().AddCommand<ListPlayersCommand>().AddDefaultCommand<SayChatCommand>();
		}
	}
}

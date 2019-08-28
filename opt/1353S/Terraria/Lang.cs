using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Terraria.GameContent.Events;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Map;
using Terraria.UI;

namespace Terraria
{
	// Token: 0x02000012 RID: 18
	public class Lang
	{
		// Token: 0x060000AB RID: 171 RVA: 0x0000FED0 File Offset: 0x0000E0D0
		public static string AnglerQuestChat(bool turnIn = false)
		{
			object obj = Lang.CreateDialogSubstitutionObject(null);
			if (turnIn)
			{
				return Language.SelectRandom(Lang.CreateDialogFilter("AnglerQuestText.TurnIn_", obj), null).FormatWith(obj);
			}
			if (Main.anglerQuestFinished)
			{
				return Language.SelectRandom(Lang.CreateDialogFilter("AnglerQuestText.NoQuest_", obj), null).FormatWith(obj);
			}
			int num = Main.anglerQuestItemNetIDs[Main.anglerQuest];
			Main.npcChatCornerItem = num;
			return Language.GetTextValueWith("AnglerQuestText.Quest_" + ItemID.Search.GetName(num), obj);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000FE24 File Offset: 0x0000E024
		public static string BartenderChat(NPC npc)
		{
			object obj = Lang.CreateDialogSubstitutionObject(npc);
			if (Main.rand.Next(5) == 0)
			{
				string key;
				if (DD2Event.DownedInvasionT3)
				{
					key = "BartenderSpecialText.AfterDD2Tier3";
				}
				else if (DD2Event.DownedInvasionT2)
				{
					key = "BartenderSpecialText.AfterDD2Tier2";
				}
				else if (DD2Event.DownedInvasionT1)
				{
					key = "BartenderSpecialText.AfterDD2Tier1";
				}
				else
				{
					key = "BartenderSpecialText.BeforeDD2Tier1";
				}
				return Language.GetTextValueWith(key, obj);
			}
			return Language.SelectRandom(Lang.CreateDialogFilter("BartenderChatter.", obj), null).FormatWith(obj);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000FD08 File Offset: 0x0000DF08
		public static string BartenderHelpText(NPC npc)
		{
			object obj = Lang.CreateDialogSubstitutionObject(npc);
			Player player = Main.player[Main.myPlayer];
			if (player.bartenderQuestLog == 0)
			{
				player.bartenderQuestLog++;
				Item item = new Item();
				item.SetDefaults(3817, false);
				item.stack = 5;
				item.position = player.Center;
				item = player.GetItem(player.whoAmI, item, true, false);
				if (item.stack > 0)
				{
					int number = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, item.type, item.stack, false, 0, true, false);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, null, number, 1f, 0f, 0f, 0, 0, 0);
					}
				}
				return Language.GetTextValueWith("BartenderSpecialText.FirstHelp", obj);
			}
			LocalizedText[] array = Language.FindAll(Lang.CreateDialogFilter("BartenderHelpText.", obj));
			if (Main.BartenderHelpTextIndex >= array.Length)
			{
				Main.BartenderHelpTextIndex = 0;
			}
			return array[Main.BartenderHelpTextIndex++].FormatWith(obj);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000103D0 File Offset: 0x0000E5D0
		public static void BuildMapAtlas()
		{
			Lang._mapLegendCache = new LocalizedText[MapHelper.LookupCount()];
			for (int i = 0; i < Lang._mapLegendCache.Length; i++)
			{
				Lang._mapLegendCache[i] = LocalizedText.Empty;
			}
			Lang._mapLegendCache[MapHelper.TileToLookup(4, 0)] = Lang._itemNameCache[8];
			Lang._mapLegendCache[MapHelper.TileToLookup(4, 1)] = Lang._itemNameCache[8];
			Lang._mapLegendCache[MapHelper.TileToLookup(5, 0)] = Language.GetText("MapObject.Tree");
			Lang._mapLegendCache[MapHelper.TileToLookup(6, 0)] = Language.GetText("MapObject.Iron");
			Lang._mapLegendCache[MapHelper.TileToLookup(7, 0)] = Language.GetText("MapObject.Copper");
			Lang._mapLegendCache[MapHelper.TileToLookup(8, 0)] = Language.GetText("MapObject.Gold");
			Lang._mapLegendCache[MapHelper.TileToLookup(9, 0)] = Language.GetText("MapObject.Silver");
			Lang._mapLegendCache[MapHelper.TileToLookup(10, 0)] = Language.GetText("MapObject.Door");
			Lang._mapLegendCache[MapHelper.TileToLookup(11, 0)] = Language.GetText("MapObject.Door");
			Lang._mapLegendCache[MapHelper.TileToLookup(12, 0)] = Lang._itemNameCache[29];
			Lang._mapLegendCache[MapHelper.TileToLookup(13, 0)] = Lang._itemNameCache[31];
			Lang._mapLegendCache[MapHelper.TileToLookup(14, 0)] = Language.GetText("MapObject.Table");
			Lang._mapLegendCache[MapHelper.TileToLookup(469, 0)] = Language.GetText("MapObject.Table");
			Lang._mapLegendCache[MapHelper.TileToLookup(15, 0)] = Language.GetText("MapObject.Chair");
			Lang._mapLegendCache[MapHelper.TileToLookup(16, 0)] = Language.GetText("MapObject.Anvil");
			Lang._mapLegendCache[MapHelper.TileToLookup(17, 0)] = Lang._itemNameCache[33];
			Lang._mapLegendCache[MapHelper.TileToLookup(18, 0)] = Lang._itemNameCache[36];
			Lang._mapLegendCache[MapHelper.TileToLookup(20, 0)] = Language.GetText("MapObject.Sapling");
			Lang._mapLegendCache[MapHelper.TileToLookup(21, 0)] = Lang._itemNameCache[48];
			Lang._mapLegendCache[MapHelper.TileToLookup(467, 0)] = Lang._itemNameCache[48];
			Lang._mapLegendCache[MapHelper.TileToLookup(22, 0)] = Language.GetText("MapObject.Demonite");
			Lang._mapLegendCache[MapHelper.TileToLookup(26, 0)] = Language.GetText("MapObject.DemonAltar");
			Lang._mapLegendCache[MapHelper.TileToLookup(26, 1)] = Language.GetText("MapObject.CrimsonAltar");
			Lang._mapLegendCache[MapHelper.TileToLookup(27, 0)] = Lang._itemNameCache[63];
			Lang._mapLegendCache[MapHelper.TileToLookup(407, 0)] = Language.GetText("MapObject.Fossil");
			Lang._mapLegendCache[MapHelper.TileToLookup(412, 0)] = Lang._itemNameCache[3549];
			Lang._mapLegendCache[MapHelper.TileToLookup(441, 0)] = Lang._itemNameCache[48];
			Lang._mapLegendCache[MapHelper.TileToLookup(468, 0)] = Lang._itemNameCache[48];
			for (int j = 0; j < 9; j++)
			{
				Lang._mapLegendCache[MapHelper.TileToLookup(28, j)] = Language.GetText("MapObject.Pot");
			}
			Lang._mapLegendCache[MapHelper.TileToLookup(37, 0)] = Lang._itemNameCache[116];
			Lang._mapLegendCache[MapHelper.TileToLookup(29, 0)] = Lang._itemNameCache[87];
			Lang._mapLegendCache[MapHelper.TileToLookup(31, 0)] = Lang._itemNameCache[115];
			Lang._mapLegendCache[MapHelper.TileToLookup(31, 1)] = Lang._itemNameCache[3062];
			Lang._mapLegendCache[MapHelper.TileToLookup(32, 0)] = Language.GetText("MapObject.Thorns");
			Lang._mapLegendCache[MapHelper.TileToLookup(33, 0)] = Lang._itemNameCache[105];
			Lang._mapLegendCache[MapHelper.TileToLookup(34, 0)] = Language.GetText("MapObject.Chandelier");
			Lang._mapLegendCache[MapHelper.TileToLookup(35, 0)] = Lang._itemNameCache[1813];
			Lang._mapLegendCache[MapHelper.TileToLookup(36, 0)] = Lang._itemNameCache[1869];
			Lang._mapLegendCache[MapHelper.TileToLookup(42, 0)] = Language.GetText("MapObject.Lantern");
			Lang._mapLegendCache[MapHelper.TileToLookup(48, 0)] = Lang._itemNameCache[147];
			Lang._mapLegendCache[MapHelper.TileToLookup(49, 0)] = Lang._itemNameCache[148];
			Lang._mapLegendCache[MapHelper.TileToLookup(50, 0)] = Lang._itemNameCache[149];
			Lang._mapLegendCache[MapHelper.TileToLookup(51, 0)] = Language.GetText("MapObject.Web");
			Lang._mapLegendCache[MapHelper.TileToLookup(55, 0)] = Lang._itemNameCache[171];
			Lang._mapLegendCache[MapHelper.TileToLookup(454, 0)] = Lang._itemNameCache[3746];
			Lang._mapLegendCache[MapHelper.TileToLookup(455, 0)] = Lang._itemNameCache[3747];
			Lang._mapLegendCache[MapHelper.TileToLookup(452, 0)] = Lang._itemNameCache[3742];
			Lang._mapLegendCache[MapHelper.TileToLookup(456, 0)] = Lang._itemNameCache[3748];
			Lang._mapLegendCache[MapHelper.TileToLookup(453, 0)] = Lang._itemNameCache[3744];
			Lang._mapLegendCache[MapHelper.TileToLookup(453, 1)] = Lang._itemNameCache[3745];
			Lang._mapLegendCache[MapHelper.TileToLookup(453, 2)] = Lang._itemNameCache[3743];
			Lang._mapLegendCache[MapHelper.TileToLookup(63, 0)] = Lang._itemNameCache[177];
			Lang._mapLegendCache[MapHelper.TileToLookup(64, 0)] = Lang._itemNameCache[178];
			Lang._mapLegendCache[MapHelper.TileToLookup(65, 0)] = Lang._itemNameCache[179];
			Lang._mapLegendCache[MapHelper.TileToLookup(66, 0)] = Lang._itemNameCache[180];
			Lang._mapLegendCache[MapHelper.TileToLookup(67, 0)] = Lang._itemNameCache[181];
			Lang._mapLegendCache[MapHelper.TileToLookup(68, 0)] = Lang._itemNameCache[182];
			Lang._mapLegendCache[MapHelper.TileToLookup(69, 0)] = Language.GetText("MapObject.Thorn");
			Lang._mapLegendCache[MapHelper.TileToLookup(72, 0)] = Language.GetText("MapObject.GiantMushroom");
			Lang._mapLegendCache[MapHelper.TileToLookup(77, 0)] = Lang._itemNameCache[221];
			Lang._mapLegendCache[MapHelper.TileToLookup(78, 0)] = Lang._itemNameCache[222];
			Lang._mapLegendCache[MapHelper.TileToLookup(79, 0)] = Lang._itemNameCache[224];
			Lang._mapLegendCache[MapHelper.TileToLookup(80, 0)] = Lang._itemNameCache[276];
			Lang._mapLegendCache[MapHelper.TileToLookup(81, 0)] = Lang._itemNameCache[275];
			Lang._mapLegendCache[MapHelper.TileToLookup(82, 0)] = Lang._itemNameCache[313];
			Lang._mapLegendCache[MapHelper.TileToLookup(82, 1)] = Lang._itemNameCache[314];
			Lang._mapLegendCache[MapHelper.TileToLookup(82, 2)] = Lang._itemNameCache[315];
			Lang._mapLegendCache[MapHelper.TileToLookup(82, 3)] = Lang._itemNameCache[316];
			Lang._mapLegendCache[MapHelper.TileToLookup(82, 4)] = Lang._itemNameCache[317];
			Lang._mapLegendCache[MapHelper.TileToLookup(82, 5)] = Lang._itemNameCache[318];
			Lang._mapLegendCache[MapHelper.TileToLookup(82, 6)] = Lang._itemNameCache[2358];
			Lang._mapLegendCache[MapHelper.TileToLookup(83, 0)] = Lang._itemNameCache[313];
			Lang._mapLegendCache[MapHelper.TileToLookup(83, 1)] = Lang._itemNameCache[314];
			Lang._mapLegendCache[MapHelper.TileToLookup(83, 2)] = Lang._itemNameCache[315];
			Lang._mapLegendCache[MapHelper.TileToLookup(83, 3)] = Lang._itemNameCache[316];
			Lang._mapLegendCache[MapHelper.TileToLookup(83, 4)] = Lang._itemNameCache[317];
			Lang._mapLegendCache[MapHelper.TileToLookup(83, 5)] = Lang._itemNameCache[318];
			Lang._mapLegendCache[MapHelper.TileToLookup(83, 6)] = Lang._itemNameCache[2358];
			Lang._mapLegendCache[MapHelper.TileToLookup(84, 0)] = Lang._itemNameCache[313];
			Lang._mapLegendCache[MapHelper.TileToLookup(84, 1)] = Lang._itemNameCache[314];
			Lang._mapLegendCache[MapHelper.TileToLookup(84, 2)] = Lang._itemNameCache[315];
			Lang._mapLegendCache[MapHelper.TileToLookup(84, 3)] = Lang._itemNameCache[316];
			Lang._mapLegendCache[MapHelper.TileToLookup(84, 4)] = Lang._itemNameCache[317];
			Lang._mapLegendCache[MapHelper.TileToLookup(84, 5)] = Lang._itemNameCache[318];
			Lang._mapLegendCache[MapHelper.TileToLookup(84, 6)] = Lang._itemNameCache[2358];
			Lang._mapLegendCache[MapHelper.TileToLookup(85, 0)] = Lang._itemNameCache[321];
			Lang._mapLegendCache[MapHelper.TileToLookup(86, 0)] = Lang._itemNameCache[332];
			Lang._mapLegendCache[MapHelper.TileToLookup(87, 0)] = Lang._itemNameCache[333];
			Lang._mapLegendCache[MapHelper.TileToLookup(88, 0)] = Lang._itemNameCache[334];
			Lang._mapLegendCache[MapHelper.TileToLookup(89, 0)] = Lang._itemNameCache[335];
			Lang._mapLegendCache[MapHelper.TileToLookup(90, 0)] = Lang._itemNameCache[336];
			Lang._mapLegendCache[MapHelper.TileToLookup(91, 0)] = Language.GetText("MapObject.Banner");
			Lang._mapLegendCache[MapHelper.TileToLookup(92, 0)] = Lang._itemNameCache[341];
			Lang._mapLegendCache[MapHelper.TileToLookup(93, 0)] = Language.GetText("MapObject.FloorLamp");
			Lang._mapLegendCache[MapHelper.TileToLookup(94, 0)] = Lang._itemNameCache[352];
			Lang._mapLegendCache[MapHelper.TileToLookup(95, 0)] = Lang._itemNameCache[344];
			Lang._mapLegendCache[MapHelper.TileToLookup(96, 0)] = Lang._itemNameCache[345];
			Lang._mapLegendCache[MapHelper.TileToLookup(97, 0)] = Lang._itemNameCache[346];
			Lang._mapLegendCache[MapHelper.TileToLookup(98, 0)] = Lang._itemNameCache[347];
			Lang._mapLegendCache[MapHelper.TileToLookup(100, 0)] = Lang._itemNameCache[349];
			Lang._mapLegendCache[MapHelper.TileToLookup(101, 0)] = Lang._itemNameCache[354];
			Lang._mapLegendCache[MapHelper.TileToLookup(102, 0)] = Lang._itemNameCache[355];
			Lang._mapLegendCache[MapHelper.TileToLookup(103, 0)] = Lang._itemNameCache[356];
			Lang._mapLegendCache[MapHelper.TileToLookup(104, 0)] = Lang._itemNameCache[359];
			Lang._mapLegendCache[MapHelper.TileToLookup(105, 0)] = Language.GetText("MapObject.Statue");
			Lang._mapLegendCache[MapHelper.TileToLookup(105, 2)] = Language.GetText("MapObject.Vase");
			Lang._mapLegendCache[MapHelper.TileToLookup(106, 0)] = Lang._itemNameCache[363];
			Lang._mapLegendCache[MapHelper.TileToLookup(107, 0)] = Language.GetText("MapObject.Cobalt");
			Lang._mapLegendCache[MapHelper.TileToLookup(108, 0)] = Language.GetText("MapObject.Mythril");
			Lang._mapLegendCache[MapHelper.TileToLookup(111, 0)] = Language.GetText("MapObject.Adamantite");
			Lang._mapLegendCache[MapHelper.TileToLookup(114, 0)] = Lang._itemNameCache[398];
			Lang._mapLegendCache[MapHelper.TileToLookup(125, 0)] = Lang._itemNameCache[487];
			Lang._mapLegendCache[MapHelper.TileToLookup(128, 0)] = Lang._itemNameCache[498];
			Lang._mapLegendCache[MapHelper.TileToLookup(129, 0)] = Lang._itemNameCache[502];
			Lang._mapLegendCache[MapHelper.TileToLookup(132, 0)] = Lang._itemNameCache[513];
			Lang._mapLegendCache[MapHelper.TileToLookup(411, 0)] = Lang._itemNameCache[3545];
			Lang._mapLegendCache[MapHelper.TileToLookup(133, 0)] = Lang._itemNameCache[524];
			Lang._mapLegendCache[MapHelper.TileToLookup(133, 1)] = Lang._itemNameCache[1221];
			Lang._mapLegendCache[MapHelper.TileToLookup(134, 0)] = Lang._itemNameCache[525];
			Lang._mapLegendCache[MapHelper.TileToLookup(134, 1)] = Lang._itemNameCache[1220];
			Lang._mapLegendCache[MapHelper.TileToLookup(136, 0)] = Lang._itemNameCache[538];
			Lang._mapLegendCache[MapHelper.TileToLookup(137, 0)] = Language.GetText("MapObject.Trap");
			Lang._mapLegendCache[MapHelper.TileToLookup(138, 0)] = Lang._itemNameCache[540];
			Lang._mapLegendCache[MapHelper.TileToLookup(139, 0)] = Lang._itemNameCache[576];
			Lang._mapLegendCache[MapHelper.TileToLookup(142, 0)] = Lang._itemNameCache[581];
			Lang._mapLegendCache[MapHelper.TileToLookup(143, 0)] = Lang._itemNameCache[582];
			Lang._mapLegendCache[MapHelper.TileToLookup(144, 0)] = Language.GetText("MapObject.Timer");
			Lang._mapLegendCache[MapHelper.TileToLookup(149, 0)] = Language.GetText("MapObject.ChristmasLight");
			Lang._mapLegendCache[MapHelper.TileToLookup(166, 0)] = Language.GetText("MapObject.Tin");
			Lang._mapLegendCache[MapHelper.TileToLookup(167, 0)] = Language.GetText("MapObject.Lead");
			Lang._mapLegendCache[MapHelper.TileToLookup(168, 0)] = Language.GetText("MapObject.Tungsten");
			Lang._mapLegendCache[MapHelper.TileToLookup(169, 0)] = Language.GetText("MapObject.Platinum");
			Lang._mapLegendCache[MapHelper.TileToLookup(170, 0)] = Language.GetText("MapObject.PineTree");
			Lang._mapLegendCache[MapHelper.TileToLookup(171, 0)] = Lang._itemNameCache[1873];
			Lang._mapLegendCache[MapHelper.TileToLookup(172, 0)] = Language.GetText("MapObject.Sink");
			Lang._mapLegendCache[MapHelper.TileToLookup(173, 0)] = Lang._itemNameCache[349];
			Lang._mapLegendCache[MapHelper.TileToLookup(174, 0)] = Lang._itemNameCache[713];
			Lang._mapLegendCache[MapHelper.TileToLookup(178, 0)] = Lang._itemNameCache[181];
			Lang._mapLegendCache[MapHelper.TileToLookup(178, 1)] = Lang._itemNameCache[180];
			Lang._mapLegendCache[MapHelper.TileToLookup(178, 2)] = Lang._itemNameCache[177];
			Lang._mapLegendCache[MapHelper.TileToLookup(178, 3)] = Lang._itemNameCache[179];
			Lang._mapLegendCache[MapHelper.TileToLookup(178, 4)] = Lang._itemNameCache[178];
			Lang._mapLegendCache[MapHelper.TileToLookup(178, 5)] = Lang._itemNameCache[182];
			Lang._mapLegendCache[MapHelper.TileToLookup(178, 6)] = Lang._itemNameCache[999];
			Lang._mapLegendCache[MapHelper.TileToLookup(191, 0)] = Language.GetText("MapObject.LivingWood");
			Lang._mapLegendCache[MapHelper.TileToLookup(204, 0)] = Language.GetText("MapObject.Crimtane");
			Lang._mapLegendCache[MapHelper.TileToLookup(207, 0)] = Language.GetText("MapObject.WaterFountain");
			Lang._mapLegendCache[MapHelper.TileToLookup(209, 0)] = Lang._itemNameCache[928];
			Lang._mapLegendCache[MapHelper.TileToLookup(211, 0)] = Language.GetText("MapObject.Chlorophyte");
			Lang._mapLegendCache[MapHelper.TileToLookup(212, 0)] = Language.GetText("MapObject.Turret");
			Lang._mapLegendCache[MapHelper.TileToLookup(213, 0)] = Lang._itemNameCache[965];
			Lang._mapLegendCache[MapHelper.TileToLookup(214, 0)] = Lang._itemNameCache[85];
			Lang._mapLegendCache[MapHelper.TileToLookup(215, 0)] = Lang._itemNameCache[966];
			Lang._mapLegendCache[MapHelper.TileToLookup(216, 0)] = Language.GetText("MapObject.Rocket");
			Lang._mapLegendCache[MapHelper.TileToLookup(217, 0)] = Lang._itemNameCache[995];
			Lang._mapLegendCache[MapHelper.TileToLookup(218, 0)] = Lang._itemNameCache[996];
			Lang._mapLegendCache[MapHelper.TileToLookup(219, 0)] = Language.GetText("MapObject.SiltExtractinator");
			Lang._mapLegendCache[MapHelper.TileToLookup(220, 0)] = Lang._itemNameCache[998];
			Lang._mapLegendCache[MapHelper.TileToLookup(221, 0)] = Language.GetText("MapObject.Palladium");
			Lang._mapLegendCache[MapHelper.TileToLookup(222, 0)] = Language.GetText("MapObject.Orichalcum");
			Lang._mapLegendCache[MapHelper.TileToLookup(223, 0)] = Language.GetText("MapObject.Titanium");
			Lang._mapLegendCache[MapHelper.TileToLookup(227, 0)] = Lang._itemNameCache[1107];
			Lang._mapLegendCache[MapHelper.TileToLookup(227, 1)] = Lang._itemNameCache[1108];
			Lang._mapLegendCache[MapHelper.TileToLookup(227, 2)] = Lang._itemNameCache[1109];
			Lang._mapLegendCache[MapHelper.TileToLookup(227, 3)] = Lang._itemNameCache[1110];
			Lang._mapLegendCache[MapHelper.TileToLookup(227, 4)] = Lang._itemNameCache[1111];
			Lang._mapLegendCache[MapHelper.TileToLookup(227, 5)] = Lang._itemNameCache[1112];
			Lang._mapLegendCache[MapHelper.TileToLookup(227, 6)] = Lang._itemNameCache[1113];
			Lang._mapLegendCache[MapHelper.TileToLookup(227, 7)] = Lang._itemNameCache[1114];
			Lang._mapLegendCache[MapHelper.TileToLookup(227, 8)] = Lang._itemNameCache[3385];
			Lang._mapLegendCache[MapHelper.TileToLookup(227, 9)] = Lang._itemNameCache[3386];
			Lang._mapLegendCache[MapHelper.TileToLookup(227, 10)] = Lang._itemNameCache[3387];
			Lang._mapLegendCache[MapHelper.TileToLookup(227, 11)] = Lang._itemNameCache[3388];
			Lang._mapLegendCache[MapHelper.TileToLookup(228, 0)] = Lang._itemNameCache[1120];
			Lang._mapLegendCache[MapHelper.TileToLookup(231, 0)] = Language.GetText("MapObject.Larva");
			Lang._mapLegendCache[MapHelper.TileToLookup(232, 0)] = Lang._itemNameCache[1150];
			Lang._mapLegendCache[MapHelper.TileToLookup(235, 0)] = Lang._itemNameCache[1263];
			Lang._mapLegendCache[MapHelper.TileToLookup(236, 0)] = Lang._itemNameCache[1291];
			Lang._mapLegendCache[MapHelper.TileToLookup(237, 0)] = Lang._itemNameCache[1292];
			Lang._mapLegendCache[MapHelper.TileToLookup(238, 0)] = Language.GetText("MapObject.PlanterasBulb");
			Lang._mapLegendCache[MapHelper.TileToLookup(239, 0)] = Language.GetText("MapObject.MetalBar");
			Lang._mapLegendCache[MapHelper.TileToLookup(240, 0)] = Language.GetText("MapObject.Trophy");
			Lang._mapLegendCache[MapHelper.TileToLookup(240, 2)] = Lang._npcNameCache[21];
			Lang._mapLegendCache[MapHelper.TileToLookup(240, 3)] = Language.GetText("MapObject.ItemRack");
			Lang._mapLegendCache[MapHelper.TileToLookup(240, 4)] = Lang._itemNameCache[2442];
			Lang._mapLegendCache[MapHelper.TileToLookup(241, 0)] = Lang._itemNameCache[1417];
			Lang._mapLegendCache[MapHelper.TileToLookup(242, 0)] = Language.GetText("MapObject.Painting");
			Lang._mapLegendCache[MapHelper.TileToLookup(242, 1)] = Language.GetText("MapObject.AnimalSkin");
			Lang._mapLegendCache[MapHelper.TileToLookup(243, 0)] = Lang._itemNameCache[1430];
			Lang._mapLegendCache[MapHelper.TileToLookup(244, 0)] = Lang._itemNameCache[1449];
			Lang._mapLegendCache[MapHelper.TileToLookup(245, 0)] = Language.GetText("MapObject.Picture");
			Lang._mapLegendCache[MapHelper.TileToLookup(246, 0)] = Language.GetText("MapObject.Picture");
			Lang._mapLegendCache[MapHelper.TileToLookup(247, 0)] = Lang._itemNameCache[1551];
			Lang._mapLegendCache[MapHelper.TileToLookup(254, 0)] = Lang._itemNameCache[1725];
			Lang._mapLegendCache[MapHelper.TileToLookup(269, 0)] = Lang._itemNameCache[1989];
			Lang._mapLegendCache[MapHelper.TileToLookup(270, 0)] = Lang._itemNameCache[1993];
			Lang._mapLegendCache[MapHelper.TileToLookup(271, 0)] = Lang._itemNameCache[2005];
			Lang._mapLegendCache[MapHelper.TileToLookup(275, 0)] = Lang._itemNameCache[2162];
			Lang._mapLegendCache[MapHelper.TileToLookup(276, 0)] = Lang._itemNameCache[2163];
			Lang._mapLegendCache[MapHelper.TileToLookup(277, 0)] = Lang._itemNameCache[2164];
			Lang._mapLegendCache[MapHelper.TileToLookup(278, 0)] = Lang._itemNameCache[2165];
			Lang._mapLegendCache[MapHelper.TileToLookup(279, 0)] = Lang._itemNameCache[2166];
			Lang._mapLegendCache[MapHelper.TileToLookup(280, 0)] = Lang._itemNameCache[2167];
			Lang._mapLegendCache[MapHelper.TileToLookup(281, 0)] = Lang._itemNameCache[2168];
			Lang._mapLegendCache[MapHelper.TileToLookup(282, 0)] = Lang._itemNameCache[250];
			Lang._mapLegendCache[MapHelper.TileToLookup(413, 0)] = Language.GetText("MapObject.OrangeSquirrelCage");
			Lang._mapLegendCache[MapHelper.TileToLookup(283, 0)] = Lang._itemNameCache[2172];
			Lang._mapLegendCache[MapHelper.TileToLookup(285, 0)] = Lang._itemNameCache[2174];
			Lang._mapLegendCache[MapHelper.TileToLookup(286, 0)] = Lang._itemNameCache[2175];
			Lang._mapLegendCache[MapHelper.TileToLookup(287, 0)] = Lang._itemNameCache[2177];
			Lang._mapLegendCache[MapHelper.TileToLookup(288, 0)] = Lang._itemNameCache[2178];
			Lang._mapLegendCache[MapHelper.TileToLookup(289, 0)] = Lang._itemNameCache[2179];
			Lang._mapLegendCache[MapHelper.TileToLookup(290, 0)] = Lang._itemNameCache[2180];
			Lang._mapLegendCache[MapHelper.TileToLookup(291, 0)] = Lang._itemNameCache[2181];
			Lang._mapLegendCache[MapHelper.TileToLookup(292, 0)] = Lang._itemNameCache[2182];
			Lang._mapLegendCache[MapHelper.TileToLookup(293, 0)] = Lang._itemNameCache[2183];
			Lang._mapLegendCache[MapHelper.TileToLookup(294, 0)] = Lang._itemNameCache[2184];
			Lang._mapLegendCache[MapHelper.TileToLookup(295, 0)] = Lang._itemNameCache[2185];
			Lang._mapLegendCache[MapHelper.TileToLookup(296, 0)] = Lang._itemNameCache[2186];
			Lang._mapLegendCache[MapHelper.TileToLookup(297, 0)] = Lang._itemNameCache[2187];
			Lang._mapLegendCache[MapHelper.TileToLookup(298, 0)] = Lang._itemNameCache[2190];
			Lang._mapLegendCache[MapHelper.TileToLookup(299, 0)] = Lang._itemNameCache[2191];
			Lang._mapLegendCache[MapHelper.TileToLookup(300, 0)] = Lang._itemNameCache[2192];
			Lang._mapLegendCache[MapHelper.TileToLookup(301, 0)] = Lang._itemNameCache[2193];
			Lang._mapLegendCache[MapHelper.TileToLookup(302, 0)] = Lang._itemNameCache[2194];
			Lang._mapLegendCache[MapHelper.TileToLookup(303, 0)] = Lang._itemNameCache[2195];
			Lang._mapLegendCache[MapHelper.TileToLookup(304, 0)] = Lang._itemNameCache[2196];
			Lang._mapLegendCache[MapHelper.TileToLookup(305, 0)] = Lang._itemNameCache[2197];
			Lang._mapLegendCache[MapHelper.TileToLookup(306, 0)] = Lang._itemNameCache[2198];
			Lang._mapLegendCache[MapHelper.TileToLookup(307, 0)] = Lang._itemNameCache[2203];
			Lang._mapLegendCache[MapHelper.TileToLookup(308, 0)] = Lang._itemNameCache[2204];
			Lang._mapLegendCache[MapHelper.TileToLookup(309, 0)] = Lang._itemNameCache[2206];
			Lang._mapLegendCache[MapHelper.TileToLookup(310, 0)] = Lang._itemNameCache[2207];
			Lang._mapLegendCache[MapHelper.TileToLookup(316, 0)] = Lang._itemNameCache[2439];
			Lang._mapLegendCache[MapHelper.TileToLookup(317, 0)] = Lang._itemNameCache[2440];
			Lang._mapLegendCache[MapHelper.TileToLookup(318, 0)] = Lang._itemNameCache[2441];
			Lang._mapLegendCache[MapHelper.TileToLookup(319, 0)] = Lang._itemNameCache[2490];
			Lang._mapLegendCache[MapHelper.TileToLookup(320, 0)] = Lang._itemNameCache[2496];
			Lang._mapLegendCache[MapHelper.TileToLookup(323, 0)] = Language.GetText("MapObject.PalmTree");
			Lang._mapLegendCache[MapHelper.TileToLookup(314, 0)] = Lang._itemNameCache[2340];
			Lang._mapLegendCache[MapHelper.TileToLookup(353, 0)] = Lang._itemNameCache[2996];
			Lang._mapLegendCache[MapHelper.TileToLookup(354, 0)] = Lang._itemNameCache[2999];
			Lang._mapLegendCache[MapHelper.TileToLookup(355, 0)] = Lang._itemNameCache[3000];
			Lang._mapLegendCache[MapHelper.TileToLookup(356, 0)] = Lang._itemNameCache[3064];
			Lang._mapLegendCache[MapHelper.TileToLookup(365, 0)] = Lang._itemNameCache[3077];
			Lang._mapLegendCache[MapHelper.TileToLookup(366, 0)] = Lang._itemNameCache[3078];
			Lang._mapLegendCache[MapHelper.TileToLookup(373, 0)] = Language.GetText("MapObject.DrippingWater");
			Lang._mapLegendCache[MapHelper.TileToLookup(374, 0)] = Language.GetText("MapObject.DrippingLava");
			Lang._mapLegendCache[MapHelper.TileToLookup(375, 0)] = Language.GetText("MapObject.DrippingHoney");
			Lang._mapLegendCache[MapHelper.TileToLookup(461, 0)] = Language.GetText("MapObject.SandFlow");
			Lang._mapLegendCache[MapHelper.TileToLookup(377, 0)] = Lang._itemNameCache[3198];
			Lang._mapLegendCache[MapHelper.TileToLookup(372, 0)] = Lang._itemNameCache[3117];
			Lang._mapLegendCache[MapHelper.TileToLookup(425, 0)] = Lang._itemNameCache[3617];
			Lang._mapLegendCache[MapHelper.TileToLookup(420, 0)] = Lang._itemNameCache[3603];
			Lang._mapLegendCache[MapHelper.TileToLookup(420, 1)] = Lang._itemNameCache[3604];
			Lang._mapLegendCache[MapHelper.TileToLookup(420, 2)] = Lang._itemNameCache[3605];
			Lang._mapLegendCache[MapHelper.TileToLookup(420, 3)] = Lang._itemNameCache[3606];
			Lang._mapLegendCache[MapHelper.TileToLookup(420, 4)] = Lang._itemNameCache[3607];
			Lang._mapLegendCache[MapHelper.TileToLookup(420, 5)] = Lang._itemNameCache[3608];
			Lang._mapLegendCache[MapHelper.TileToLookup(423, 0)] = Lang._itemNameCache[3613];
			Lang._mapLegendCache[MapHelper.TileToLookup(423, 1)] = Lang._itemNameCache[3614];
			Lang._mapLegendCache[MapHelper.TileToLookup(423, 2)] = Lang._itemNameCache[3615];
			Lang._mapLegendCache[MapHelper.TileToLookup(423, 3)] = Lang._itemNameCache[3726];
			Lang._mapLegendCache[MapHelper.TileToLookup(423, 4)] = Lang._itemNameCache[3727];
			Lang._mapLegendCache[MapHelper.TileToLookup(423, 5)] = Lang._itemNameCache[3728];
			Lang._mapLegendCache[MapHelper.TileToLookup(423, 6)] = Lang._itemNameCache[3729];
			Lang._mapLegendCache[MapHelper.TileToLookup(440, 0)] = Lang._itemNameCache[3644];
			Lang._mapLegendCache[MapHelper.TileToLookup(440, 1)] = Lang._itemNameCache[3645];
			Lang._mapLegendCache[MapHelper.TileToLookup(440, 2)] = Lang._itemNameCache[3646];
			Lang._mapLegendCache[MapHelper.TileToLookup(440, 3)] = Lang._itemNameCache[3647];
			Lang._mapLegendCache[MapHelper.TileToLookup(440, 4)] = Lang._itemNameCache[3648];
			Lang._mapLegendCache[MapHelper.TileToLookup(440, 5)] = Lang._itemNameCache[3649];
			Lang._mapLegendCache[MapHelper.TileToLookup(440, 6)] = Lang._itemNameCache[3650];
			Lang._mapLegendCache[MapHelper.TileToLookup(424, 0)] = Lang._itemNameCache[3616];
			Lang._mapLegendCache[MapHelper.TileToLookup(444, 0)] = Language.GetText("MapObject.BeeHive");
			Lang._mapLegendCache[MapHelper.TileToLookup(466, 0)] = Lang._itemNameCache[3816];
			Lang._mapLegendCache[MapHelper.TileToLookup(463, 0)] = Lang._itemNameCache[3813];
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000120C4 File Offset: 0x000102C4
		public static NetworkText CreateDeathMessage(string deadPlayerName, int plr = -1, int npc = -1, int proj = -1, int other = -1, int projType = 0, int plrItemType = 0)
		{
			NetworkText networkText = NetworkText.Empty;
			NetworkText networkText2 = NetworkText.Empty;
			NetworkText networkText3 = NetworkText.Empty;
			NetworkText networkText4 = NetworkText.Empty;
			if (proj >= 0)
			{
				networkText = NetworkText.FromKey(Lang.GetProjectileName(projType).Key, new object[0]);
			}
			if (npc >= 0)
			{
				networkText2 = Main.npc[npc].GetGivenOrTypeNetName();
			}
			if (plr >= 0 && plr < 255)
			{
				networkText3 = NetworkText.FromLiteral(Main.player[plr].name);
			}
			if (plrItemType >= 0)
			{
				networkText4 = NetworkText.FromKey(Lang.GetItemName(plrItemType).Key, new object[0]);
			}
			bool flag = networkText != NetworkText.Empty;
			bool flag2 = plr >= 0 && plr < 255;
			bool flag3 = networkText2 != NetworkText.Empty;
			NetworkText result = NetworkText.Empty;
			NetworkText networkText5 = NetworkText.Empty;
			networkText5 = NetworkText.FromKey(Language.RandomFromCategory("DeathTextGeneric", null).Key, new object[]
			{
				deadPlayerName,
				Main.worldName
			});
			if (flag2)
			{
				result = NetworkText.FromKey("DeathSource.Player", new object[]
				{
					networkText5,
					networkText3,
					flag ? networkText : networkText4
				});
			}
			else if (flag3)
			{
				result = NetworkText.FromKey("DeathSource.NPC", new object[]
				{
					networkText5,
					networkText2
				});
			}
			else if (flag)
			{
				result = NetworkText.FromKey("DeathSource.Projectile", new object[]
				{
					networkText5,
					networkText
				});
			}
			else if (other >= 0)
			{
				if (other == 0)
				{
					result = NetworkText.FromKey("DeathText.Fell_" + (Main.rand.Next(2) + 1), new object[]
					{
						deadPlayerName
					});
				}
				else if (other == 1)
				{
					result = NetworkText.FromKey("DeathText.Drowned_" + (Main.rand.Next(4) + 1), new object[]
					{
						deadPlayerName
					});
				}
				else if (other == 2)
				{
					result = NetworkText.FromKey("DeathText.Lava_" + (Main.rand.Next(4) + 1), new object[]
					{
						deadPlayerName
					});
				}
				else if (other == 3)
				{
					result = NetworkText.FromKey("DeathText.Default", new object[]
					{
						networkText5
					});
				}
				else if (other == 4)
				{
					result = NetworkText.FromKey("DeathText.Slain", new object[]
					{
						deadPlayerName
					});
				}
				else if (other == 5)
				{
					result = NetworkText.FromKey("DeathText.Petrified_" + (Main.rand.Next(4) + 1), new object[]
					{
						deadPlayerName
					});
				}
				else if (other == 6)
				{
					result = NetworkText.FromKey("DeathText.Stabbed", new object[]
					{
						deadPlayerName
					});
				}
				else if (other == 7)
				{
					result = NetworkText.FromKey("DeathText.Suffocated", new object[]
					{
						deadPlayerName
					});
				}
				else if (other == 8)
				{
					result = NetworkText.FromKey("DeathText.Burned", new object[]
					{
						deadPlayerName
					});
				}
				else if (other == 9)
				{
					result = NetworkText.FromKey("DeathText.Poisoned", new object[]
					{
						deadPlayerName
					});
				}
				else if (other == 10)
				{
					result = NetworkText.FromKey("DeathText.Electrocuted", new object[]
					{
						deadPlayerName
					});
				}
				else if (other == 11)
				{
					result = NetworkText.FromKey("DeathText.TriedToEscape", new object[]
					{
						deadPlayerName
					});
				}
				else if (other == 12)
				{
					result = NetworkText.FromKey("DeathText.WasLicked", new object[]
					{
						deadPlayerName
					});
				}
				else if (other == 13)
				{
					result = NetworkText.FromKey("DeathText.Teleport_1", new object[]
					{
						deadPlayerName
					});
				}
				else if (other == 14)
				{
					result = NetworkText.FromKey("DeathText.Teleport_2_Male", new object[]
					{
						deadPlayerName
					});
				}
				else if (other == 15)
				{
					result = NetworkText.FromKey("DeathText.Teleport_2_Female", new object[]
					{
						deadPlayerName
					});
				}
				else if (other == 254)
				{
					result = NetworkText.Empty;
				}
				else if (other == 255)
				{
					result = NetworkText.FromKey("DeathText.Slain", new object[]
					{
						deadPlayerName
					});
				}
			}
			return result;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000FEB7 File Offset: 0x0000E0B7
		public static LanguageSearchFilter CreateDialogFilter(string startsWith)
		{
			return (string key, LocalizedText text) => key.StartsWith(startsWith);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000FE97 File Offset: 0x0000E097
		public static LanguageSearchFilter CreateDialogFilter(string startsWith, object substitutions)
		{
			return (string key, LocalizedText text) => key.StartsWith(startsWith) && text.CanFormatWith(substitutions);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000F90C File Offset: 0x0000DB0C
		public static object CreateDialogSubstitutionObject(NPC npc = null)
		{
			return new
			{
				Nurse = NPC.GetFirstNPCNameOrNull(18),
				Merchant = NPC.GetFirstNPCNameOrNull(17),
				ArmsDealer = NPC.GetFirstNPCNameOrNull(19),
				Dryad = NPC.GetFirstNPCNameOrNull(20),
				Demolitionist = NPC.GetFirstNPCNameOrNull(38),
				Clothier = NPC.GetFirstNPCNameOrNull(54),
				Guide = NPC.GetFirstNPCNameOrNull(22),
				Wizard = NPC.GetFirstNPCNameOrNull(108),
				GoblinTinkerer = NPC.GetFirstNPCNameOrNull(107),
				Mechanic = NPC.GetFirstNPCNameOrNull(124),
				Truffle = NPC.GetFirstNPCNameOrNull(160),
				Steampunker = NPC.GetFirstNPCNameOrNull(178),
				DyeTrader = NPC.GetFirstNPCNameOrNull(207),
				PartyGirl = NPC.GetFirstNPCNameOrNull(208),
				Cyborg = NPC.GetFirstNPCNameOrNull(209),
				Painter = NPC.GetFirstNPCNameOrNull(227),
				WitchDoctor = NPC.GetFirstNPCNameOrNull(228),
				Pirate = NPC.GetFirstNPCNameOrNull(229),
				Stylist = NPC.GetFirstNPCNameOrNull(353),
				TravelingMerchant = NPC.GetFirstNPCNameOrNull(368),
				Angler = NPC.GetFirstNPCNameOrNull(369),
				Bartender = NPC.GetFirstNPCNameOrNull(550),
				WorldName = Main.ActiveWorldFileData.Name,
				Day = Main.dayTime,
				BloodMoon = Main.bloodMoon,
				MoonLordDefeated = NpcMgr.downedMoonlord,
				HardMode = Main.hardMode,
				Homeless = (npc != null && npc.homeless),
				InventoryKey = Main.cInv,
				PlayerName = Main.player[Main.myPlayer].name
			};
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000FA1B File Offset: 0x0000DC1B
		[Obsolete("dialog is deprecated. Please use Language.GetText instead.")]
		public static string dialog(int l, bool english = false)
		{
			return Language.GetTextValueWith("LegacyDialog." + l, Lang.CreateDialogSubstitutionObject(null));
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000FCC4 File Offset: 0x0000DEC4
		public static string DyeTraderQuestChat(bool gotDye = false)
		{
			object obj = Lang.CreateDialogSubstitutionObject(null);
			LocalizedText[] array = Language.FindAll(Lang.CreateDialogFilter(gotDye ? "DyeTraderSpecialText.HasPlant" : "DyeTraderSpecialText.NoPlant", obj));
			return array[Main.rand.Next(array.Length)].FormatWith(obj);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000FF74 File Offset: 0x0000E174
		private static void FillNameCacheArray<IdClass, IdType>(string category, LocalizedText[] nameCache, bool leaveMissingEntriesBlank = false) where IdType : IConvertible
		{
			for (int i = 0; i < nameCache.Length; i++)
			{
				nameCache[i] = LocalizedText.Empty;
			}
			IEnumerable<FieldInfo> arg_6B_0 = typeof(IdClass).GetFields(BindingFlags.Static | BindingFlags.Public);
			arg_6B_0.Where((f) =>
			{
				return f.FieldType == typeof(IdType);
			}).ToList<FieldInfo>().ForEach(delegate (FieldInfo field)
			{
				long num = Convert.ToInt64((IdType)((object)field.GetValue(null)));
				if (num > 0L && num < (long)nameCache.Length)
				{
					nameCache[(int)(checked((IntPtr)num))] = ((!leaveMissingEntriesBlank || Language.Exists(category + "." + field.Name)) ? Language.GetText(category + "." + field.Name) : LocalizedText.Empty);
					return;
				}
				if (num == 0L && field.Name == "None")
				{
					nameCache[(int)(checked((IntPtr)num))] = LocalizedText.Empty;
				}
			});
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000FACD File Offset: 0x0000DCCD
		public static string GetBuffDescription(int id)
		{
			return Lang._buffDescriptionCache[id].Value;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000FABF File Offset: 0x0000DCBF
		public static string GetBuffName(int id)
		{
			return Lang._buffNameCache[id].Value;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000FADC File Offset: 0x0000DCDC
		public static string GetDryadWorldStatusDialog()
		{
			int tGood = (int)WorldGen.tGood;
			int tEvil = (int)WorldGen.tEvil;
			int tBlood = (int)WorldGen.tBlood;
			string textValue;
			if (tGood > 0 && tEvil > 0 && tBlood > 0)
			{
				textValue = Language.GetTextValue("DryadSpecialText.WorldStatusAll", new object[]
				{
					Main.worldName,
					tGood,
					tEvil,
					tBlood
				});
			}
			else if (tGood > 0 && tEvil > 0)
			{
				textValue = Language.GetTextValue("DryadSpecialText.WorldStatusHallowCorrupt", Main.worldName, tGood, tEvil);
			}
			else if (tGood > 0 && tBlood > 0)
			{
				textValue = Language.GetTextValue("DryadSpecialText.WorldStatusHallowCrimson", Main.worldName, tGood, tBlood);
			}
			else if (tEvil > 0 && tBlood > 0)
			{
				textValue = Language.GetTextValue("DryadSpecialText.WorldStatusCorruptCrimson", Main.worldName, tEvil, tBlood);
			}
			else if (tEvil > 0)
			{
				textValue = Language.GetTextValue("DryadSpecialText.WorldStatusCorrupt", Main.worldName, tEvil);
			}
			else if (tBlood > 0)
			{
				textValue = Language.GetTextValue("DryadSpecialText.WorldStatusCrimson", Main.worldName, tBlood);
			}
			else
			{
				if (tGood <= 0)
				{
					return Language.GetTextValue("DryadSpecialText.WorldStatusPure", Main.worldName);
				}
				textValue = Language.GetTextValue("DryadSpecialText.WorldStatusHallow", Main.worldName, tGood);
			}
			string textValue2;
			if ((double)tGood * 1.2 >= (double)(tEvil + tBlood) && (double)tGood * 0.8 <= (double)(tEvil + tBlood))
			{
				textValue2 = Language.GetTextValue("DryadSpecialText.WorldDescriptionBalanced");
			}
			else if (tGood >= tEvil + tBlood)
			{
				textValue2 = Language.GetTextValue("DryadSpecialText.WorldDescriptionFairyTale");
			}
			else if (tEvil + tBlood > tGood + 20)
			{
				textValue2 = Language.GetTextValue("DryadSpecialText.WorldDescriptionGrim");
			}
			else if (tEvil + tBlood > 10)
			{
				textValue2 = Language.GetTextValue("DryadSpecialText.WorldDescriptionWork");
			}
			else
			{
				textValue2 = Language.GetTextValue("DryadSpecialText.WorldDescriptionClose");
			}
			return string.Format("{0} {1}", textValue, textValue2);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000124C0 File Offset: 0x000106C0
		public static NetworkText GetInvasionWaveText(int wave, params short[] npcIds)
		{
			NetworkText[] array = new NetworkText[npcIds.Length + 1];
			for (int i = 0; i < npcIds.Length; i++)
			{
				array[i + 1] = NetworkText.FromKey(Lang.GetNPCName((int)npcIds[i]).Key, new object[0]);
			}
			if (wave == -1)
			{
				array[0] = NetworkText.FromKey("Game.FinalWave", new object[0]);
			}
			else if (wave == 1)
			{
				array[0] = NetworkText.FromKey("Game.FirstWave", new object[0]);
			}
			else
			{
				array[0] = NetworkText.FromKey("Game.Wave", new object[]
				{
					wave
				});
			}
			return NetworkText.FromKey("Game.InvasionWave_Type" + npcIds.Length, array);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000FA85 File Offset: 0x0000DC85
		public static LocalizedText GetItemName(int id)
		{
			id = (int)ItemID.FromNetId((short)id);
			if (id > 0 && id < 3930 && Lang._itemNameCache[id] != null)
			{
				return Lang._itemNameCache[id];
			}
			return LocalizedText.Empty;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000FAB2 File Offset: 0x0000DCB2
		public static string GetItemNameValue(int id)
		{
			return Lang.GetItemName(id).Value;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000F8EE File Offset: 0x0000DAEE
		public static string GetMapObjectName(int id)
		{
			if (Lang._mapLegendCache != null)
			{
				return Lang._mapLegendCache[id].Value;
			}
			return string.Empty;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000FA45 File Offset: 0x0000DC45
		public static LocalizedText GetNPCName(int netID)
		{
			if (netID > 0 && netID < 580)
			{
				return Lang._npcNameCache[netID];
			}
			if (netID < 0 && -netID - 1 < Lang._negativeNpcNameCache.Length)
			{
				return Lang._negativeNpcNameCache[-netID - 1];
			}
			return LocalizedText.Empty;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000FA38 File Offset: 0x0000DC38
		public static string GetNPCNameValue(int netID)
		{
			return Lang.GetNPCName(netID).Value;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000FF4B File Offset: 0x0000E14B
		public static LocalizedText GetProjectileName(int type)
		{
			if (type >= 0 && type < Lang._projectileNameCache.Length && Lang._projectileNameCache[type] != null)
			{
				return Lang._projectileNameCache[type];
			}
			return LocalizedText.Empty;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000FCB1 File Offset: 0x0000DEB1
		public static string GetRandomGameTitle()
		{
			return Language.RandomFromCategory("GameTitle", null).Value;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000FA7C File Offset: 0x0000DC7C
		public static ItemTooltip GetTooltip(int itemId)
		{
			return Lang._itemTooltipCache[itemId];
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00010008 File Offset: 0x0000E208
		public static void InitializeLegacyLocalization()
		{
			Lang.FillNameCacheArray<PrefixID, int>("Prefix", Lang.prefix, false);
			for (int i = 0; i < Lang.gen.Length; i++)
			{
				Lang.gen[i] = Language.GetText("LegacyWorldGen." + i);
			}
			for (int j = 0; j < Lang.menu.Length; j++)
			{
				Lang.menu[j] = Language.GetText("LegacyMenu." + j);
			}
			for (int k = 0; k < Lang.inter.Length; k++)
			{
				Lang.inter[k] = Language.GetText("LegacyInterface." + k);
			}
			for (int l = 0; l < Lang.misc.Length; l++)
			{
				Lang.misc[l] = Language.GetText("LegacyMisc." + l);
			}
			for (int m = 0; m < Lang.mp.Length; m++)
			{
				Lang.mp[m] = Language.GetText("LegacyMultiplayer." + m);
			}
			for (int n = 0; n < Lang.tip.Length; n++)
			{
				Lang.tip[n] = Language.GetText("LegacyTooltip." + n);
			}
			for (int num = 0; num < Lang.chestType.Length; num++)
			{
				Lang.chestType[num] = Language.GetText("LegacyChestType." + num);
			}
			for (int num2 = 0; num2 < Lang.chestType2.Length; num2++)
			{
				Lang.chestType2[num2] = Language.GetText("LegacyChestType2." + num2);
			}
			for (int num3 = 0; num3 < Lang.dresserType.Length; num3++)
			{
				Lang.dresserType[num3] = Language.GetText("LegacyDresserType." + num3);
			}
			Lang.FillNameCacheArray<ItemID, short>("ItemName", Lang._itemNameCache, false);
			Lang.FillNameCacheArray<ProjectileID, short>("ProjectileName", Lang._projectileNameCache, false);
			Lang.FillNameCacheArray<NPCID, short>("NPCName", Lang._npcNameCache, false);
			Lang.FillNameCacheArray<BuffID, int>("BuffName", Lang._buffNameCache, false);
			Lang.FillNameCacheArray<BuffID, int>("BuffDescription", Lang._buffDescriptionCache, false);
			for (int num4 = -65; num4 < 0; num4++)
			{
				Lang._negativeNpcNameCache[-num4 - 1] = Lang._npcNameCache[NPCID.FromNetId(num4)];
			}
			Lang._negativeNpcNameCache[0] = Language.GetText("NPCName.Slimeling");
			Lang._negativeNpcNameCache[1] = Language.GetText("NPCName.Slimer2");
			Lang._negativeNpcNameCache[2] = Language.GetText("NPCName.GreenSlime");
			Lang._negativeNpcNameCache[3] = Language.GetText("NPCName.Pinky");
			Lang._negativeNpcNameCache[4] = Language.GetText("NPCName.BabySlime");
			Lang._negativeNpcNameCache[5] = Language.GetText("NPCName.BlackSlime");
			Lang._negativeNpcNameCache[6] = Language.GetText("NPCName.PurpleSlime");
			Lang._negativeNpcNameCache[7] = Language.GetText("NPCName.RedSlime");
			Lang._negativeNpcNameCache[8] = Language.GetText("NPCName.YellowSlime");
			Lang._negativeNpcNameCache[9] = Language.GetText("NPCName.JungleSlime");
			Lang._negativeNpcNameCache[53] = Language.GetText("NPCName.SmallRainZombie");
			Lang._negativeNpcNameCache[54] = Language.GetText("NPCName.BigRainZombie");
			ItemTooltip.AddGlobalProcessor((tooltip) =>
			{
				if (tooltip.Contains("<right>"))
				{
					InputMode inputMode = InputMode.XBoxGamepad;
					if (PlayerInput.UsingGamepad)
					{
						inputMode = InputMode.XBoxGamepadUI;
					}
					if (inputMode == InputMode.XBoxGamepadUI)
					{
						KeyConfiguration keyConfiguration = PlayerInput.CurrentProfile.InputModes[inputMode];
						string text = PlayerInput.BuildCommand("", true, new List<string>[]
						{
							keyConfiguration.KeyStatus["MouseRight"]
						});
						text = text.Replace(": ", "");
						tooltip = tooltip.Replace("<right>", text);
					}
					else
					{
						tooltip = tooltip.Replace("<right>", Language.GetTextValue("Controls.RightClick"));
					}
				}
				return tooltip;
			});
			for (int num5 = 0; num5 < Lang._itemTooltipCache.Length; num5++)
			{
				Lang._itemTooltipCache[num5] = ItemTooltip.None;
			}
			IEnumerable<FieldInfo> arg_38B_0 = typeof(ItemID).GetFields(BindingFlags.Static | BindingFlags.Public);
			List<FieldInfo> arg_3B4_0 = arg_38B_0.Where((f) =>
			{
				return f.FieldType == typeof(short);
			}).ToList<FieldInfo>();
			arg_3B4_0.ForEach((field) =>
			{
				short num = (short)field.GetValue(null);
				if (num > 0 && (int)num < Lang._itemTooltipCache.Length)
				{
					Lang._itemTooltipCache[(int)num] = ItemTooltip.FromLanguageKey("ItemTooltip." + field.Name);
				}
			});
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0001256C File Offset: 0x0001076C
		public static string LocalizedDuration(TimeSpan time, bool abbreviated, bool showAllAvailableUnits)
		{
			string text = "";
			abbreviated |= !GameCulture.English.IsActive;
			if (time.Days > 0)
			{
				text = text + time.Days + (abbreviated ? (" " + Language.GetTextValue("Misc.ShortDays")) : ((time.Days == 1) ? " day" : " days"));
				if (!showAllAvailableUnits)
				{
					return text;
				}
				text += " ";
			}
			if (time.Hours > 0)
			{
				text = text + time.Hours + (abbreviated ? (" " + Language.GetTextValue("Misc.ShortHours")) : ((time.Hours == 1) ? " hour" : " hours"));
				if (!showAllAvailableUnits)
				{
					return text;
				}
				text += " ";
			}
			if (time.Minutes > 0)
			{
				text = text + time.Minutes + (abbreviated ? (" " + Language.GetTextValue("Misc.ShortMinutes")) : ((time.Minutes == 1) ? " minute" : " minutes"));
				if (!showAllAvailableUnits)
				{
					return text;
				}
				text += " ";
			}
			return text + time.Seconds + (abbreviated ? (" " + Language.GetTextValue("Misc.ShortSeconds")) : ((time.Seconds == 1) ? " second" : " seconds"));
		}

		// Token: 0x04000097 RID: 151
		[Obsolete("Lang arrays have been replaced with the new Language.GetText system.")]
		public static LocalizedText[] chestType = new LocalizedText[52];

		// Token: 0x04000099 RID: 153
		[Obsolete("Lang arrays have been replaced with the new Language.GetText system.")]
		public static LocalizedText[] chestType2 = new LocalizedText[2];

		// Token: 0x04000098 RID: 152
		[Obsolete("Lang arrays have been replaced with the new Language.GetText system.")]
		public static LocalizedText[] dresserType = new LocalizedText[32];

		// Token: 0x04000092 RID: 146
		[Obsolete("Lang arrays have been replaced with the new Language.GetText system.")]
		public static LocalizedText[] gen = new LocalizedText[82];

		// Token: 0x04000094 RID: 148
		[Obsolete("Lang arrays have been replaced with the new Language.GetText system.")]
		public static LocalizedText[] inter = new LocalizedText[129];

		// Token: 0x04000091 RID: 145
		[Obsolete("Lang arrays have been replaced with the new Language.GetText system.")]
		public static LocalizedText[] menu = new LocalizedText[253];

		// Token: 0x04000093 RID: 147
		[Obsolete("Lang arrays have been replaced with the new Language.GetText system.")]
		public static LocalizedText[] misc = new LocalizedText[201];

		// Token: 0x04000096 RID: 150
		[Obsolete("Lang arrays have been replaced with the new Language.GetText system.")]
		public static LocalizedText[] mp = new LocalizedText[23];

		// Token: 0x0400009A RID: 154
		public static LocalizedText[] prefix = new LocalizedText[84];

		// Token: 0x04000095 RID: 149
		[Obsolete("Lang arrays have been replaced with the new Language.GetText system.")]
		public static LocalizedText[] tip = new LocalizedText[60];

		// Token: 0x040000A1 RID: 161
		private static LocalizedText[] _buffDescriptionCache = new LocalizedText[206];

		// Token: 0x040000A0 RID: 160
		private static LocalizedText[] _buffNameCache = new LocalizedText[206];

		// Token: 0x0400009C RID: 156
		private static LocalizedText[] _itemNameCache = new LocalizedText[3930];

		// Token: 0x040000A2 RID: 162
		private static ItemTooltip[] _itemTooltipCache = new ItemTooltip[3930];

		// Token: 0x0400009B RID: 155
		public static LocalizedText[] _mapLegendCache;

		// Token: 0x0400009F RID: 159
		private static LocalizedText[] _negativeNpcNameCache = new LocalizedText[65];

		// Token: 0x0400009E RID: 158
		private static LocalizedText[] _npcNameCache = new LocalizedText[580];

		// Token: 0x0400009D RID: 157
		private static LocalizedText[] _projectileNameCache = new LocalizedText[714];

		// Token: 0x020001BD RID: 445
	}
}

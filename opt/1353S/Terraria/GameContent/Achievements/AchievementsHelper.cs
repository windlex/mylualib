using System;
using System.Runtime.CompilerServices;

namespace Terraria.GameContent.Achievements
{
	// Token: 0x0200012D RID: 301
	public class AchievementsHelper
	{
		// Token: 0x14000028 RID: 40
		// (add) Token: 0x06000FD8 RID: 4056 RVA: 0x003FC678 File Offset: 0x003FA878
		// (remove) Token: 0x06000FD9 RID: 4057 RVA: 0x003FC6AC File Offset: 0x003FA8AC
		[method: CompilerGenerated]
		[CompilerGenerated]
		public static event AchievementsHelper.ItemPickupEvent OnItemPickup;

		// Token: 0x14000029 RID: 41
		// (add) Token: 0x06000FDA RID: 4058 RVA: 0x003FC6E0 File Offset: 0x003FA8E0
		// (remove) Token: 0x06000FDB RID: 4059 RVA: 0x003FC714 File Offset: 0x003FA914
		[method: CompilerGenerated]
		[CompilerGenerated]
		public static event AchievementsHelper.ItemCraftEvent OnItemCraft;

		// Token: 0x1400002A RID: 42
		// (add) Token: 0x06000FDC RID: 4060 RVA: 0x003FC748 File Offset: 0x003FA948
		// (remove) Token: 0x06000FDD RID: 4061 RVA: 0x003FC77C File Offset: 0x003FA97C
		[method: CompilerGenerated]
		[CompilerGenerated]
		public static event AchievementsHelper.TileDestroyedEvent OnTileDestroyed;

		// Token: 0x1400002B RID: 43
		// (add) Token: 0x06000FDE RID: 4062 RVA: 0x003FC7B0 File Offset: 0x003FA9B0
		// (remove) Token: 0x06000FDF RID: 4063 RVA: 0x003FC7E4 File Offset: 0x003FA9E4
		[method: CompilerGenerated]
		[CompilerGenerated]
		public static event AchievementsHelper.NPCKilledEvent OnNPCKilled;

		// Token: 0x1400002C RID: 44
		// (add) Token: 0x06000FE0 RID: 4064 RVA: 0x003FC818 File Offset: 0x003FAA18
		// (remove) Token: 0x06000FE1 RID: 4065 RVA: 0x003FC84C File Offset: 0x003FAA4C
		[method: CompilerGenerated]
		[CompilerGenerated]
		public static event AchievementsHelper.ProgressionEventEvent OnProgressionEvent;

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000FE2 RID: 4066 RVA: 0x003FC880 File Offset: 0x003FAA80
		// (set) Token: 0x06000FE3 RID: 4067 RVA: 0x003FC888 File Offset: 0x003FAA88
		public static bool CurrentlyMining
		{
			get
			{
				return AchievementsHelper._isMining;
			}
			set
			{
				AchievementsHelper._isMining = value;
			}
		}

		// Token: 0x06000FE4 RID: 4068 RVA: 0x003FC890 File Offset: 0x003FAA90
		public static void NotifyTileDestroyed(Player player, ushort tile)
		{
			if (Main.gameMenu || !AchievementsHelper._isMining)
			{
				return;
			}
			if (AchievementsHelper.OnTileDestroyed != null)
			{
				AchievementsHelper.OnTileDestroyed(player, tile);
			}
		}

		// Token: 0x06000FE5 RID: 4069 RVA: 0x003FC8B4 File Offset: 0x003FAAB4
		public static void NotifyItemPickup(Player player, Item item)
		{
			if (AchievementsHelper.OnItemPickup != null)
			{
				AchievementsHelper.OnItemPickup(player, (short)item.netID, item.stack);
			}
		}

		// Token: 0x06000FE6 RID: 4070 RVA: 0x003FC8D8 File Offset: 0x003FAAD8
		public static void NotifyItemPickup(Player player, Item item, int customStack)
		{
			if (AchievementsHelper.OnItemPickup != null)
			{
				AchievementsHelper.OnItemPickup(player, (short)item.netID, customStack);
			}
		}

		// Token: 0x06000FE7 RID: 4071 RVA: 0x003FC8F4 File Offset: 0x003FAAF4
		public static void NotifyItemCraft(Recipe recipe)
		{
			if (AchievementsHelper.OnItemCraft != null)
			{
				AchievementsHelper.OnItemCraft((short)recipe.createItem.netID, recipe.createItem.stack);
			}
		}

		// Token: 0x06000FE8 RID: 4072 RVA: 0x003FC920 File Offset: 0x003FAB20
		public static void Initialize()
		{
			Player.Hooks.OnEnterWorld += new Action<Player>(AchievementsHelper.OnPlayerEnteredWorld);
		}

		// Token: 0x06000FE9 RID: 4073 RVA: 0x003FC934 File Offset: 0x003FAB34
		private static void OnPlayerEnteredWorld(Player player)
		{
			if (AchievementsHelper.OnItemPickup != null)
			{
				for (int i = 0; i < 58; i++)
				{
					AchievementsHelper.OnItemPickup(player, (short)player.inventory[i].type, player.inventory[i].stack);
				}
				for (int j = 0; j < player.armor.Length; j++)
				{
					AchievementsHelper.OnItemPickup(player, (short)player.armor[j].type, player.armor[j].stack);
				}
				for (int k = 0; k < player.dye.Length; k++)
				{
					AchievementsHelper.OnItemPickup(player, (short)player.dye[k].type, player.dye[k].stack);
				}
				for (int l = 0; l < player.miscEquips.Length; l++)
				{
					AchievementsHelper.OnItemPickup(player, (short)player.miscEquips[l].type, player.miscEquips[l].stack);
				}
				for (int m = 0; m < player.miscDyes.Length; m++)
				{
					AchievementsHelper.OnItemPickup(player, (short)player.miscDyes[m].type, player.miscDyes[m].stack);
				}
				for (int n = 0; n < player.bank.item.Length; n++)
				{
					AchievementsHelper.OnItemPickup(player, (short)player.bank.item[n].type, player.bank.item[n].stack);
				}
				for (int num = 0; num < player.bank2.item.Length; num++)
				{
					AchievementsHelper.OnItemPickup(player, (short)player.bank2.item[num].type, player.bank2.item[num].stack);
				}
				for (int num2 = 0; num2 < player.bank3.item.Length; num2++)
				{
					AchievementsHelper.OnItemPickup(player, (short)player.bank3.item[num2].type, player.bank3.item[num2].stack);
				}
			}
			if (player.statManaMax > 20)
			{
				Main.Achievements.GetCondition("STAR_POWER", "Use").Complete();
			}
			if (player.statLifeMax == 500 && player.statManaMax == 200)
			{
				Main.Achievements.GetCondition("TOPPED_OFF", "Use").Complete();
			}
			if (player.miscEquips[4].type > 0)
			{
				Main.Achievements.GetCondition("HOLD_ON_TIGHT", "Equip").Complete();
			}
			if (player.miscEquips[3].type > 0)
			{
				Main.Achievements.GetCondition("THE_CAVALRY", "Equip").Complete();
			}
			for (int num3 = 0; num3 < player.armor.Length; num3++)
			{
				if (player.armor[num3].wingSlot > 0)
				{
					Main.Achievements.GetCondition("HEAD_IN_THE_CLOUDS", "Equip").Complete();
					break;
				}
			}
			if (player.armor[0].stack > 0 && player.armor[1].stack > 0 && player.armor[2].stack > 0)
			{
				Main.Achievements.GetCondition("MATCHING_ATTIRE", "Equip").Complete();
			}
			if (player.armor[10].stack > 0 && player.armor[11].stack > 0 && player.armor[12].stack > 0)
			{
				Main.Achievements.GetCondition("FASHION_STATEMENT", "Equip").Complete();
			}
			bool flag = true;
			for (int num4 = 0; num4 < player.extraAccessorySlots + 3 + 5; num4++)
			{
				if (player.dye[num4].type < 1 || player.dye[num4].stack < 1)
				{
					flag = false;
				}
			}
			if (flag)
			{
				Main.Achievements.GetCondition("DYE_HARD", "Equip").Complete();
			}
		}

		// Token: 0x06000FEA RID: 4074 RVA: 0x003FCD34 File Offset: 0x003FAF34
		public static void NotifyNPCKilled(NPC npc)
		{
			if (Main.netMode == 0)
			{
				if (npc.playerInteraction[Main.myPlayer])
				{
					AchievementsHelper.NotifyNPCKilledDirect(Main.player[Main.myPlayer], npc.netID);
					return;
				}
			}
			else
			{
				for (int i = 0; i < 255; i++)
				{
					if (npc.playerInteraction[i])
					{
						NetMessage.SendData(97, i, -1, null, npc.netID, 0f, 0f, 0f, 0, 0, 0);
					}
				}
			}
		}

		// Token: 0x06000FEB RID: 4075 RVA: 0x003FCDAC File Offset: 0x003FAFAC
		public static void NotifyNPCKilledDirect(Player player, int npcNetID)
		{
			if (AchievementsHelper.OnNPCKilled != null)
			{
				AchievementsHelper.OnNPCKilled(player, (short)npcNetID);
			}
		}

		// Token: 0x06000FEC RID: 4076 RVA: 0x003FCDC4 File Offset: 0x003FAFC4
		public static void NotifyProgressionEvent(int eventID)
		{
			if (Main.netMode == 2)
			{
				NetMessage.SendData(98, -1, -1, null, eventID, 0f, 0f, 0f, 0, 0, 0);
				return;
			}
			if (AchievementsHelper.OnProgressionEvent != null)
			{
				AchievementsHelper.OnProgressionEvent(eventID);
			}
		}

		// Token: 0x06000FED RID: 4077 RVA: 0x003FCE0C File Offset: 0x003FB00C
		public static void HandleOnEquip(Player player, Item item, int context)
		{
			if (context == 16)
			{
				Main.Achievements.GetCondition("HOLD_ON_TIGHT", "Equip").Complete();
			}
			if (context == 17)
			{
				Main.Achievements.GetCondition("THE_CAVALRY", "Equip").Complete();
			}
			if ((context == 10 || context == 11) && item.wingSlot > 0)
			{
				Main.Achievements.GetCondition("HEAD_IN_THE_CLOUDS", "Equip").Complete();
			}
			if (context == 8 && player.armor[0].stack > 0 && player.armor[1].stack > 0 && player.armor[2].stack > 0)
			{
				Main.Achievements.GetCondition("MATCHING_ATTIRE", "Equip").Complete();
			}
			if (context == 9 && player.armor[10].stack > 0 && player.armor[11].stack > 0 && player.armor[12].stack > 0)
			{
				Main.Achievements.GetCondition("FASHION_STATEMENT", "Equip").Complete();
			}
			if (context == 12)
			{
				for (int i = 0; i < player.extraAccessorySlots + 3 + 5; i++)
				{
					if (player.dye[i].type < 1 || player.dye[i].stack < 1)
					{
						return;
					}
				}
				for (int j = 0; j < player.miscDyes.Length; j++)
				{
					if (player.miscDyes[j].type < 1 || player.miscDyes[j].stack < 1)
					{
						return;
					}
				}
				Main.Achievements.GetCondition("DYE_HARD", "Equip").Complete();
			}
		}

		// Token: 0x06000FEE RID: 4078 RVA: 0x003FCFAC File Offset: 0x003FB1AC
		public static void HandleSpecialEvent(Player player, int eventID)
		{
			if (player.whoAmI != Main.myPlayer)
			{
				return;
			}
			switch (eventID)
			{
			case 1:
				Main.Achievements.GetCondition("STAR_POWER", "Use").Complete();
				if (player.statLifeMax == 500 && player.statManaMax == 200)
				{
					Main.Achievements.GetCondition("TOPPED_OFF", "Use").Complete();
					return;
				}
				break;
			case 2:
				Main.Achievements.GetCondition("GET_A_LIFE", "Use").Complete();
				if (player.statLifeMax == 500 && player.statManaMax == 200)
				{
					Main.Achievements.GetCondition("TOPPED_OFF", "Use").Complete();
					return;
				}
				break;
			case 3:
				Main.Achievements.GetCondition("NOT_THE_BEES", "Use").Complete();
				return;
			case 4:
				Main.Achievements.GetCondition("WATCH_YOUR_STEP", "Hit").Complete();
				return;
			case 5:
				Main.Achievements.GetCondition("RAINBOWS_AND_UNICORNS", "Use").Complete();
				return;
			case 6:
				Main.Achievements.GetCondition("YOU_AND_WHAT_ARMY", "Spawn").Complete();
				return;
			case 7:
				Main.Achievements.GetCondition("THROWING_LINES", "Use").Complete();
				return;
			case 8:
				Main.Achievements.GetCondition("LUCKY_BREAK", "Hit").Complete();
				return;
			case 9:
				Main.Achievements.GetCondition("VEHICULAR_MANSLAUGHTER", "Hit").Complete();
				return;
			case 10:
				Main.Achievements.GetCondition("ROCK_BOTTOM", "Reach").Complete();
				return;
			case 11:
				Main.Achievements.GetCondition("INTO_ORBIT", "Reach").Complete();
				return;
			case 12:
				Main.Achievements.GetCondition("WHERES_MY_HONEY", "Reach").Complete();
				return;
			case 13:
				Main.Achievements.GetCondition("JEEPERS_CREEPERS", "Reach").Complete();
				return;
			case 14:
				Main.Achievements.GetCondition("ITS_GETTING_HOT_IN_HERE", "Reach").Complete();
				return;
			case 15:
				Main.Achievements.GetCondition("FUNKYTOWN", "Reach").Complete();
				return;
			case 16:
				Main.Achievements.GetCondition("I_AM_LOOT", "Peek").Complete();
				break;
			default:
				return;
			}
		}

		// Token: 0x06000FEF RID: 4079 RVA: 0x003FD224 File Offset: 0x003FB424
		public static void HandleNurseService(int coinsSpent)
		{
			((CustomFloatCondition)Main.Achievements.GetCondition("FREQUENT_FLYER", "Pay")).Value += (float)coinsSpent;
		}

		// Token: 0x06000FF0 RID: 4080 RVA: 0x003FD250 File Offset: 0x003FB450
		public static void HandleAnglerService()
		{
			Main.Achievements.GetCondition("SERVANT_IN_TRAINING", "Finish").Complete();
			CustomIntCondition expr_32 = (CustomIntCondition)Main.Achievements.GetCondition("GOOD_LITTLE_SLAVE", "Finish");
			int value = expr_32.Value;
			expr_32.Value = value + 1;
			CustomIntCondition expr_5A = (CustomIntCondition)Main.Achievements.GetCondition("TROUT_MONKEY", "Finish");
			value = expr_5A.Value;
			expr_5A.Value = value + 1;
			CustomIntCondition expr_82 = (CustomIntCondition)Main.Achievements.GetCondition("FAST_AND_FISHIOUS", "Finish");
			value = expr_82.Value;
			expr_82.Value = value + 1;
			CustomIntCondition expr_AA = (CustomIntCondition)Main.Achievements.GetCondition("SUPREME_HELPER_MINION", "Finish");
			value = expr_AA.Value;
			expr_AA.Value = value + 1;
		}

		// Token: 0x06000FF1 RID: 4081 RVA: 0x003FD318 File Offset: 0x003FB518
		public static void HandleRunning(float pixelsMoved)
		{
			((CustomFloatCondition)Main.Achievements.GetCondition("MARATHON_MEDALIST", "Move")).Value += pixelsMoved;
		}

		// Token: 0x06000FF2 RID: 4082 RVA: 0x003FD340 File Offset: 0x003FB540
		public static void HandleMining()
		{
			CustomIntCondition expr_19 = (CustomIntCondition)Main.Achievements.GetCondition("BULLDOZER", "Pick");
			int value = expr_19.Value;
			expr_19.Value = value + 1;
		}

		// Token: 0x06000FF3 RID: 4083 RVA: 0x003FD378 File Offset: 0x003FB578
		public static void CheckMechaMayhem(int justKilled = -1)
		{
			if (!AchievementsHelper.mayhemOK)
			{
				if (NPC.AnyNPCs(127) && NPC.AnyNPCs(134) && NPC.AnyNPCs(126) && NPC.AnyNPCs(125))
				{
					AchievementsHelper.mayhemOK = true;
					AchievementsHelper.mayhem1down = false;
					AchievementsHelper.mayhem2down = false;
					AchievementsHelper.mayhem3down = false;
					return;
				}
			}
			else
			{
				if (justKilled == 125 || justKilled == 126)
				{
					AchievementsHelper.mayhem1down = true;
				}
				else if (!NPC.AnyNPCs(125) && !NPC.AnyNPCs(126) && !AchievementsHelper.mayhem1down)
				{
					AchievementsHelper.mayhemOK = false;
					return;
				}
				if (justKilled == 134)
				{
					AchievementsHelper.mayhem2down = true;
				}
				else if (!NPC.AnyNPCs(134) && !AchievementsHelper.mayhem2down)
				{
					AchievementsHelper.mayhemOK = false;
					return;
				}
				if (justKilled == 127)
				{
					AchievementsHelper.mayhem3down = true;
				}
				else if (!NPC.AnyNPCs(127) && !AchievementsHelper.mayhem3down)
				{
					AchievementsHelper.mayhemOK = false;
					return;
				}
				if (AchievementsHelper.mayhem1down && AchievementsHelper.mayhem2down && AchievementsHelper.mayhem3down)
				{
					AchievementsHelper.NotifyProgressionEvent(21);
				}
			}
		}

		// Token: 0x04003080 RID: 12416
		private static bool _isMining;

		// Token: 0x04003081 RID: 12417
		private static bool mayhemOK;

		// Token: 0x04003082 RID: 12418
		private static bool mayhem1down;

		// Token: 0x04003083 RID: 12419
		private static bool mayhem2down;

		// Token: 0x04003084 RID: 12420
		private static bool mayhem3down;

		// Token: 0x02000295 RID: 661
		// (Invoke) Token: 0x060016D5 RID: 5845
		public delegate void ItemPickupEvent(Player player, short itemId, int count);

		// Token: 0x02000296 RID: 662
		// (Invoke) Token: 0x060016D9 RID: 5849
		public delegate void ItemCraftEvent(short itemId, int count);

		// Token: 0x02000297 RID: 663
		// (Invoke) Token: 0x060016DD RID: 5853
		public delegate void TileDestroyedEvent(Player player, ushort tileId);

		// Token: 0x02000298 RID: 664
		// (Invoke) Token: 0x060016E1 RID: 5857
		public delegate void NPCKilledEvent(Player player, short npcId);

		// Token: 0x02000299 RID: 665
		// (Invoke) Token: 0x060016E5 RID: 5861
		public delegate void ProgressionEventEvent(int eventID);
	}
}

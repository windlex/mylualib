using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Effects;
using Terraria.Localization;

namespace Terraria.GameContent.Events
{
	// Token: 0x02000172 RID: 370
	public class BirthdayParty
	{
		// Token: 0x0600121A RID: 4634 RVA: 0x00411E55 File Offset: 0x00410055
		public static void CheckMorning()
		{
			BirthdayParty.NaturalAttempt();
		}

		// Token: 0x0600121B RID: 4635 RVA: 0x00411E5C File Offset: 0x0041005C
		public static void CheckNight()
		{
			bool flag = false;
			if (BirthdayParty.GenuineParty)
			{
				flag = true;
				BirthdayParty.GenuineParty = false;
				BirthdayParty.CelebratingNPCs.Clear();
			}
			if (BirthdayParty.ManualParty)
			{
				flag = true;
				BirthdayParty.ManualParty = false;
			}
			if (flag)
			{
				Color color = new Color(255, 0, 160);
				WorldGen.BroadcastText(NetworkText.FromKey(Lang.misc[99].Key, new object[0]), color);
			}
		}

		// Token: 0x0600121C RID: 4636 RVA: 0x00411EC8 File Offset: 0x004100C8
		private static void NaturalAttempt()
		{
			if (Main.netMode == 1)
			{
				return;
			}
			if (BirthdayParty.PartyDaysOnCooldown > 0)
			{
				BirthdayParty.PartyDaysOnCooldown--;
				return;
			}
			if (Main.rand.Next(10) != 0)
			{
				return;
			}
			List<NPC> list = new List<NPC>();
			for (int i = 0; i < 200; i++)
			{
				NPC nPC = Main.npc[i];
				if (nPC.active && nPC.townNPC && nPC.type != 37 && nPC.type != 453 && nPC.aiStyle != 0)
				{
					list.Add(nPC);
				}
			}
			if (list.Count < 5)
			{
				return;
			}
			BirthdayParty.GenuineParty = true;
			BirthdayParty.PartyDaysOnCooldown = Main.rand.Next(5, 11);
			BirthdayParty.CelebratingNPCs.Clear();
			List<int> list2 = new List<int>();
			int num = 1;
			if (Main.rand.Next(5) == 0 && list.Count > 12)
			{
				num = 3;
			}
			else if (Main.rand.Next(3) == 0)
			{
				num = 2;
			}
			IEnumerable<NPC> arg_10B_0 = list;
			list = arg_10B_0.OrderBy((i) => { return Main.rand.Next(); }).ToList<NPC>();
			for (int j = 0; j < num; j++)
			{
				list2.Add(j);
			}
			for (int k = 0; k < list2.Count; k++)
			{
				BirthdayParty.CelebratingNPCs.Add(list[list2[k]].whoAmI);
			}
			Color color = new Color(255, 0, 160);
			if (BirthdayParty.CelebratingNPCs.Count == 3)
			{
				WorldGen.BroadcastText(NetworkText.FromKey("Game.BirthdayParty_3", new object[]
				{
					Main.npc[BirthdayParty.CelebratingNPCs[0]].GetGivenOrTypeNetName(),
					Main.npc[BirthdayParty.CelebratingNPCs[1]].GetGivenOrTypeNetName(),
					Main.npc[BirthdayParty.CelebratingNPCs[2]].GetGivenOrTypeNetName()
				}), color);
				return;
			}
			if (BirthdayParty.CelebratingNPCs.Count == 2)
			{
				WorldGen.BroadcastText(NetworkText.FromKey("Game.BirthdayParty_2", new object[]
				{
					Main.npc[BirthdayParty.CelebratingNPCs[0]].GetGivenOrTypeNetName(),
					Main.npc[BirthdayParty.CelebratingNPCs[1]].GetGivenOrTypeNetName()
				}), color);
				return;
			}
			WorldGen.BroadcastText(NetworkText.FromKey("Game.BirthdayParty_1", new object[]
			{
				Main.npc[BirthdayParty.CelebratingNPCs[0]].GetGivenOrTypeNetName()
			}), color);
		}

		// Token: 0x0600121D RID: 4637 RVA: 0x0041213C File Offset: 0x0041033C
		public static void ToggleManualParty()
		{
			bool arg_3E_0 = BirthdayParty.PartyIsUp;
			if (Main.netMode != 1)
			{
				BirthdayParty.ManualParty = !BirthdayParty.ManualParty;
			}
			else
			{
				NetMessage.SendData(111, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
			}
			if (arg_3E_0 != BirthdayParty.PartyIsUp && Main.netMode == 2)
			{
				NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
			}
		}

		// Token: 0x0600121F RID: 4639 RVA: 0x004121D4 File Offset: 0x004103D4
		public static void UpdateTime()
		{
			if (BirthdayParty._wasCelebrating != BirthdayParty.PartyIsUp)
			{
				if (Main.netMode != 2)
				{
					if (BirthdayParty.PartyIsUp)
					{
						SkyManager.Instance.Activate("Party", default(Vector2), new object[0]);
					}
					else
					{
						SkyManager.Instance.Deactivate("Party", new object[0]);
					}
				}
				if (Main.netMode != 1 && BirthdayParty.CelebratingNPCs.Count > 0)
				{
					for (int i = 0; i < BirthdayParty.CelebratingNPCs.Count; i++)
					{
						NPC nPC = Main.npc[BirthdayParty.CelebratingNPCs[i]];
						if (!nPC.active || !nPC.townNPC || nPC.type == 37 || nPC.type == 453 || nPC.aiStyle == 0)
						{
							BirthdayParty.CelebratingNPCs.RemoveAt(i);
						}
					}
					if (BirthdayParty.CelebratingNPCs.Count == 0)
					{
						BirthdayParty.GenuineParty = false;
						if (!BirthdayParty.ManualParty)
						{
							Color color = new Color(255, 0, 160);
							WorldGen.BroadcastText(NetworkText.FromKey(Lang.misc[99].Key, new object[0]), color);
							NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
						}
					}
				}
			}
			BirthdayParty._wasCelebrating = BirthdayParty.PartyIsUp;
		}

		// Token: 0x0600121E RID: 4638 RVA: 0x004121AD File Offset: 0x004103AD
		public static void WorldClear()
		{
			BirthdayParty.ManualParty = false;
			BirthdayParty.GenuineParty = false;
			BirthdayParty.PartyDaysOnCooldown = 0;
			BirthdayParty.CelebratingNPCs.Clear();
			BirthdayParty._wasCelebrating = false;
		}

		// Token: 0x1700017E RID: 382
		public static bool PartyIsUp
		{
			// Token: 0x06001219 RID: 4633 RVA: 0x00411E45 File Offset: 0x00410045
			get
			{
				return BirthdayParty.GenuineParty || BirthdayParty.ManualParty;
			}
		}

		// Token: 0x04003277 RID: 12919
		public static List<int> CelebratingNPCs = new List<int>();

		// Token: 0x04003275 RID: 12917
		public static bool GenuineParty = false;

		// Token: 0x04003274 RID: 12916
		public static bool ManualParty = false;

		// Token: 0x04003276 RID: 12918
		public static int PartyDaysOnCooldown = 0;

		// Token: 0x04003278 RID: 12920
		private static bool _wasCelebrating = false;

		// Token: 0x020002BE RID: 702
	}
}

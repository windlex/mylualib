using System;
using System.Collections.Generic;
using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
	// Token: 0x02000133 RID: 307
	public class NPCKilledCondition : AchievementCondition
	{
		// Token: 0x06001016 RID: 4118 RVA: 0x003FD98C File Offset: 0x003FBB8C
		private NPCKilledCondition(short npcId) : base("NPC_KILLED_" + npcId)
		{
			this._npcIds = new short[]
			{
				npcId
			};
			NPCKilledCondition.ListenForPickup(this);
		}

		// Token: 0x06001017 RID: 4119 RVA: 0x003FD9BC File Offset: 0x003FBBBC
		private NPCKilledCondition(short[] npcIds) : base("NPC_KILLED_" + npcIds[0])
		{
			this._npcIds = npcIds;
			NPCKilledCondition.ListenForPickup(this);
		}

		// Token: 0x06001018 RID: 4120 RVA: 0x003FD9E4 File Offset: 0x003FBBE4
		private static void ListenForPickup(NPCKilledCondition condition)
		{
			if (!NPCKilledCondition._isListenerHooked)
			{
				AchievementsHelper.OnNPCKilled += new AchievementsHelper.NPCKilledEvent(NPCKilledCondition.NPCKilledListener);
				NPCKilledCondition._isListenerHooked = true;
			}
			for (int i = 0; i < condition._npcIds.Length; i++)
			{
				if (!NPCKilledCondition._listeners.ContainsKey(condition._npcIds[i]))
				{
					NPCKilledCondition._listeners[condition._npcIds[i]] = new List<NPCKilledCondition>();
				}
				NPCKilledCondition._listeners[condition._npcIds[i]].Add(condition);
			}
		}

		// Token: 0x06001019 RID: 4121 RVA: 0x003FDA68 File Offset: 0x003FBC68
		private static void NPCKilledListener(Player player, short npcId)
		{
			if (player.whoAmI != Main.myPlayer)
			{
				return;
			}
			if (NPCKilledCondition._listeners.ContainsKey(npcId))
			{
				using (List<NPCKilledCondition>.Enumerator enumerator = NPCKilledCondition._listeners[npcId].GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						enumerator.Current.Complete();
					}
				}
			}
		}

		// Token: 0x0600101A RID: 4122 RVA: 0x003FDAD8 File Offset: 0x003FBCD8
		public static AchievementCondition Create(params short[] npcIds)
		{
			return new NPCKilledCondition(npcIds);
		}

		// Token: 0x0600101B RID: 4123 RVA: 0x003FDAE0 File Offset: 0x003FBCE0
		public static AchievementCondition Create(short npcId)
		{
			return new NPCKilledCondition(npcId);
		}

		// Token: 0x0600101C RID: 4124 RVA: 0x003FDAE8 File Offset: 0x003FBCE8
		public static AchievementCondition[] CreateMany(params short[] npcs)
		{
			AchievementCondition[] array = new AchievementCondition[npcs.Length];
			for (int i = 0; i < npcs.Length; i++)
			{
				array[i] = new NPCKilledCondition(npcs[i]);
			}
			return array;
		}

		// Token: 0x04003091 RID: 12433
		private const string Identifier = "NPC_KILLED";

		// Token: 0x04003092 RID: 12434
		private static Dictionary<short, List<NPCKilledCondition>> _listeners = new Dictionary<short, List<NPCKilledCondition>>();

		// Token: 0x04003093 RID: 12435
		private static bool _isListenerHooked = false;

		// Token: 0x04003094 RID: 12436
		private short[] _npcIds;
	}
}

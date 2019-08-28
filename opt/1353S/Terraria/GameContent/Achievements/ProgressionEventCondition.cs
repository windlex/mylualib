using System;
using System.Collections.Generic;
using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
	// Token: 0x02000134 RID: 308
	public class ProgressionEventCondition : AchievementCondition
	{
		// Token: 0x0600101E RID: 4126 RVA: 0x003FDB2C File Offset: 0x003FBD2C
		private ProgressionEventCondition(int eventID) : base("PROGRESSION_EVENT_" + eventID)
		{
			this._eventIDs = new int[]
			{
				eventID
			};
			ProgressionEventCondition.ListenForPickup(this);
		}

		// Token: 0x0600101F RID: 4127 RVA: 0x003FDB5C File Offset: 0x003FBD5C
		private ProgressionEventCondition(int[] eventIDs) : base("PROGRESSION_EVENT_" + eventIDs[0])
		{
			this._eventIDs = eventIDs;
			ProgressionEventCondition.ListenForPickup(this);
		}

		// Token: 0x06001020 RID: 4128 RVA: 0x003FDB84 File Offset: 0x003FBD84
		private static void ListenForPickup(ProgressionEventCondition condition)
		{
			if (!ProgressionEventCondition._isListenerHooked)
			{
				AchievementsHelper.OnProgressionEvent += new AchievementsHelper.ProgressionEventEvent(ProgressionEventCondition.ProgressionEventListener);
				ProgressionEventCondition._isListenerHooked = true;
			}
			for (int i = 0; i < condition._eventIDs.Length; i++)
			{
				if (!ProgressionEventCondition._listeners.ContainsKey(condition._eventIDs[i]))
				{
					ProgressionEventCondition._listeners[condition._eventIDs[i]] = new List<ProgressionEventCondition>();
				}
				ProgressionEventCondition._listeners[condition._eventIDs[i]].Add(condition);
			}
		}

		// Token: 0x06001021 RID: 4129 RVA: 0x003FDC08 File Offset: 0x003FBE08
		private static void ProgressionEventListener(int eventID)
		{
			if (ProgressionEventCondition._listeners.ContainsKey(eventID))
			{
				using (List<ProgressionEventCondition>.Enumerator enumerator = ProgressionEventCondition._listeners[eventID].GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						enumerator.Current.Complete();
					}
				}
			}
		}

		// Token: 0x06001022 RID: 4130 RVA: 0x003FDC6C File Offset: 0x003FBE6C
		public static ProgressionEventCondition Create(params int[] eventIDs)
		{
			return new ProgressionEventCondition(eventIDs);
		}

		// Token: 0x06001023 RID: 4131 RVA: 0x003FDC74 File Offset: 0x003FBE74
		public static ProgressionEventCondition Create(int eventID)
		{
			return new ProgressionEventCondition(eventID);
		}

		// Token: 0x06001024 RID: 4132 RVA: 0x003FDC7C File Offset: 0x003FBE7C
		public static ProgressionEventCondition[] CreateMany(params int[] eventIDs)
		{
			ProgressionEventCondition[] array = new ProgressionEventCondition[eventIDs.Length];
			for (int i = 0; i < eventIDs.Length; i++)
			{
				array[i] = new ProgressionEventCondition(eventIDs[i]);
			}
			return array;
		}

		// Token: 0x04003095 RID: 12437
		private const string Identifier = "PROGRESSION_EVENT";

		// Token: 0x04003096 RID: 12438
		private static Dictionary<int, List<ProgressionEventCondition>> _listeners = new Dictionary<int, List<ProgressionEventCondition>>();

		// Token: 0x04003097 RID: 12439
		private static bool _isListenerHooked = false;

		// Token: 0x04003098 RID: 12440
		private int[] _eventIDs;
	}
}

using System;
using System.Collections.Generic;
using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
	// Token: 0x02000132 RID: 306
	public class ItemPickupCondition : AchievementCondition
	{
		// Token: 0x0600100E RID: 4110 RVA: 0x003FD7EC File Offset: 0x003FB9EC
		private ItemPickupCondition(short itemId) : base("ITEM_PICKUP_" + itemId)
		{
			this._itemIds = new short[]
			{
				itemId
			};
			ItemPickupCondition.ListenForPickup(this);
		}

		// Token: 0x0600100F RID: 4111 RVA: 0x003FD81C File Offset: 0x003FBA1C
		private ItemPickupCondition(short[] itemIds) : base("ITEM_PICKUP_" + itemIds[0])
		{
			this._itemIds = itemIds;
			ItemPickupCondition.ListenForPickup(this);
		}

		// Token: 0x06001010 RID: 4112 RVA: 0x003FD844 File Offset: 0x003FBA44
		private static void ListenForPickup(ItemPickupCondition condition)
		{
			if (!ItemPickupCondition._isListenerHooked)
			{
				AchievementsHelper.OnItemPickup += new AchievementsHelper.ItemPickupEvent(ItemPickupCondition.ItemPickupListener);
				ItemPickupCondition._isListenerHooked = true;
			}
			for (int i = 0; i < condition._itemIds.Length; i++)
			{
				if (!ItemPickupCondition._listeners.ContainsKey(condition._itemIds[i]))
				{
					ItemPickupCondition._listeners[condition._itemIds[i]] = new List<ItemPickupCondition>();
				}
				ItemPickupCondition._listeners[condition._itemIds[i]].Add(condition);
			}
		}

		// Token: 0x06001011 RID: 4113 RVA: 0x003FD8C8 File Offset: 0x003FBAC8
		private static void ItemPickupListener(Player player, short itemId, int count)
		{
			if (player.whoAmI != Main.myPlayer)
			{
				return;
			}
			if (ItemPickupCondition._listeners.ContainsKey(itemId))
			{
				using (List<ItemPickupCondition>.Enumerator enumerator = ItemPickupCondition._listeners[itemId].GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						enumerator.Current.Complete();
					}
				}
			}
		}

		// Token: 0x06001012 RID: 4114 RVA: 0x003FD938 File Offset: 0x003FBB38
		public static AchievementCondition Create(params short[] items)
		{
			return new ItemPickupCondition(items);
		}

		// Token: 0x06001013 RID: 4115 RVA: 0x003FD940 File Offset: 0x003FBB40
		public static AchievementCondition Create(short item)
		{
			return new ItemPickupCondition(item);
		}

		// Token: 0x06001014 RID: 4116 RVA: 0x003FD948 File Offset: 0x003FBB48
		public static AchievementCondition[] CreateMany(params short[] items)
		{
			AchievementCondition[] array = new AchievementCondition[items.Length];
			for (int i = 0; i < items.Length; i++)
			{
				array[i] = new ItemPickupCondition(items[i]);
			}
			return array;
		}

		// Token: 0x0400308D RID: 12429
		private const string Identifier = "ITEM_PICKUP";

		// Token: 0x0400308E RID: 12430
		private static Dictionary<short, List<ItemPickupCondition>> _listeners = new Dictionary<short, List<ItemPickupCondition>>();

		// Token: 0x0400308F RID: 12431
		private static bool _isListenerHooked = false;

		// Token: 0x04003090 RID: 12432
		private short[] _itemIds;
	}
}

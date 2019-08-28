using System;
using System.Collections.Generic;
using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
	// Token: 0x02000131 RID: 305
	public class ItemCraftCondition : AchievementCondition
	{
		// Token: 0x06001006 RID: 4102 RVA: 0x003FD658 File Offset: 0x003FB858
		private ItemCraftCondition(short itemId) : base("ITEM_PICKUP_" + itemId)
		{
			this._itemIds = new short[]
			{
				itemId
			};
			ItemCraftCondition.ListenForCraft(this);
		}

		// Token: 0x06001007 RID: 4103 RVA: 0x003FD688 File Offset: 0x003FB888
		private ItemCraftCondition(short[] itemIds) : base("ITEM_PICKUP_" + itemIds[0])
		{
			this._itemIds = itemIds;
			ItemCraftCondition.ListenForCraft(this);
		}

		// Token: 0x06001008 RID: 4104 RVA: 0x003FD6B0 File Offset: 0x003FB8B0
		private static void ListenForCraft(ItemCraftCondition condition)
		{
			if (!ItemCraftCondition._isListenerHooked)
			{
				AchievementsHelper.OnItemCraft += new AchievementsHelper.ItemCraftEvent(ItemCraftCondition.ItemCraftListener);
				ItemCraftCondition._isListenerHooked = true;
			}
			for (int i = 0; i < condition._itemIds.Length; i++)
			{
				if (!ItemCraftCondition._listeners.ContainsKey(condition._itemIds[i]))
				{
					ItemCraftCondition._listeners[condition._itemIds[i]] = new List<ItemCraftCondition>();
				}
				ItemCraftCondition._listeners[condition._itemIds[i]].Add(condition);
			}
		}

		// Token: 0x06001009 RID: 4105 RVA: 0x003FD734 File Offset: 0x003FB934
		private static void ItemCraftListener(short itemId, int count)
		{
			if (ItemCraftCondition._listeners.ContainsKey(itemId))
			{
				using (List<ItemCraftCondition>.Enumerator enumerator = ItemCraftCondition._listeners[itemId].GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						enumerator.Current.Complete();
					}
				}
			}
		}

		// Token: 0x0600100A RID: 4106 RVA: 0x003FD798 File Offset: 0x003FB998
		public static AchievementCondition Create(params short[] items)
		{
			return new ItemCraftCondition(items);
		}

		// Token: 0x0600100B RID: 4107 RVA: 0x003FD7A0 File Offset: 0x003FB9A0
		public static AchievementCondition Create(short item)
		{
			return new ItemCraftCondition(item);
		}

		// Token: 0x0600100C RID: 4108 RVA: 0x003FD7A8 File Offset: 0x003FB9A8
		public static AchievementCondition[] CreateMany(params short[] items)
		{
			AchievementCondition[] array = new AchievementCondition[items.Length];
			for (int i = 0; i < items.Length; i++)
			{
				array[i] = new ItemCraftCondition(items[i]);
			}
			return array;
		}

		// Token: 0x04003089 RID: 12425
		private const string Identifier = "ITEM_PICKUP";

		// Token: 0x0400308A RID: 12426
		private static Dictionary<short, List<ItemCraftCondition>> _listeners = new Dictionary<short, List<ItemCraftCondition>>();

		// Token: 0x0400308B RID: 12427
		private static bool _isListenerHooked = false;

		// Token: 0x0400308C RID: 12428
		private short[] _itemIds;
	}
}

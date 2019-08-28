using System;
using System.Collections.Generic;
using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
	// Token: 0x02000135 RID: 309
	public class TileDestroyedCondition : AchievementCondition
	{
		// Token: 0x06001026 RID: 4134 RVA: 0x003FDCC0 File Offset: 0x003FBEC0
		private TileDestroyedCondition(ushort[] tileIds) : base("TILE_DESTROYED_" + tileIds[0])
		{
			this._tileIds = tileIds;
			TileDestroyedCondition.ListenForDestruction(this);
		}

		// Token: 0x06001027 RID: 4135 RVA: 0x003FDCE8 File Offset: 0x003FBEE8
		private static void ListenForDestruction(TileDestroyedCondition condition)
		{
			if (!TileDestroyedCondition._isListenerHooked)
			{
				AchievementsHelper.OnTileDestroyed += new AchievementsHelper.TileDestroyedEvent(TileDestroyedCondition.TileDestroyedListener);
				TileDestroyedCondition._isListenerHooked = true;
			}
			for (int i = 0; i < condition._tileIds.Length; i++)
			{
				if (!TileDestroyedCondition._listeners.ContainsKey(condition._tileIds[i]))
				{
					TileDestroyedCondition._listeners[condition._tileIds[i]] = new List<TileDestroyedCondition>();
				}
				TileDestroyedCondition._listeners[condition._tileIds[i]].Add(condition);
			}
		}

		// Token: 0x06001028 RID: 4136 RVA: 0x003FDD6C File Offset: 0x003FBF6C
		private static void TileDestroyedListener(Player player, ushort tileId)
		{
			if (player.whoAmI != Main.myPlayer)
			{
				return;
			}
			if (TileDestroyedCondition._listeners.ContainsKey(tileId))
			{
				using (List<TileDestroyedCondition>.Enumerator enumerator = TileDestroyedCondition._listeners[tileId].GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						enumerator.Current.Complete();
					}
				}
			}
		}

		// Token: 0x06001029 RID: 4137 RVA: 0x003FDDDC File Offset: 0x003FBFDC
		public static AchievementCondition Create(params ushort[] tileIds)
		{
			return new TileDestroyedCondition(tileIds);
		}

		// Token: 0x04003099 RID: 12441
		private const string Identifier = "TILE_DESTROYED";

		// Token: 0x0400309A RID: 12442
		private static Dictionary<ushort, List<TileDestroyedCondition>> _listeners = new Dictionary<ushort, List<TileDestroyedCondition>>();

		// Token: 0x0400309B RID: 12443
		private static bool _isListenerHooked = false;

		// Token: 0x0400309C RID: 12444
		private ushort[] _tileIds;
	}
}

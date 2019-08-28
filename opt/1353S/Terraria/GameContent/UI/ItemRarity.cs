using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace Terraria.GameContent.UI
{
	// Token: 0x0200013C RID: 316
	public class ItemRarity
	{
		// Token: 0x06001061 RID: 4193 RVA: 0x004007F4 File Offset: 0x003FE9F4
		public static void Initialize()
		{
			ItemRarity._rarities.Clear();
			ItemRarity._rarities.Add(-11, Colors.RarityAmber);
			ItemRarity._rarities.Add(-1, Colors.RarityTrash);
			ItemRarity._rarities.Add(1, Colors.RarityBlue);
			ItemRarity._rarities.Add(2, Colors.RarityGreen);
			ItemRarity._rarities.Add(3, Colors.RarityOrange);
			ItemRarity._rarities.Add(4, Colors.RarityRed);
			ItemRarity._rarities.Add(5, Colors.RarityPink);
			ItemRarity._rarities.Add(6, Colors.RarityPurple);
			ItemRarity._rarities.Add(7, Colors.RarityLime);
			ItemRarity._rarities.Add(8, Colors.RarityYellow);
			ItemRarity._rarities.Add(9, Colors.RarityCyan);
		}

		// Token: 0x06001062 RID: 4194 RVA: 0x004008C0 File Offset: 0x003FEAC0
		public static Color GetColor(int rarity)
		{
			Color result = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
			if (ItemRarity._rarities.ContainsKey(rarity))
			{
				return ItemRarity._rarities[rarity];
			}
			return result;
		}

		// Token: 0x0400313A RID: 12602
		private static Dictionary<int, Color> _rarities = new Dictionary<int, Color>();
	}
}

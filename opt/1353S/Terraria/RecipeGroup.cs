using System;
using System.Collections.Generic;

namespace Terraria
{
	// Token: 0x02000026 RID: 38
	public class RecipeGroup
	{
		// Token: 0x060001F3 RID: 499 RVA: 0x000BFB4C File Offset: 0x000BDD4C
		public RecipeGroup(Func<string> getName, params int[] validItems)
		{
			this.GetText = getName;
			this.ValidItems = new List<int>(validItems);
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x000BFB68 File Offset: 0x000BDD68
		public static int RegisterGroup(string name, RecipeGroup rec)
		{
			int num = RecipeGroup.nextRecipeGroupIndex++;
			RecipeGroup.recipeGroups.Add(num, rec);
			RecipeGroup.recipeGroupIDs.Add(name, num);
			return num;
		}

		// Token: 0x040001FB RID: 507
		public Func<string> GetText;

		// Token: 0x040001FC RID: 508
		public List<int> ValidItems;

		// Token: 0x040001FD RID: 509
		public int IconicItemIndex;

		// Token: 0x040001FE RID: 510
		public static Dictionary<int, RecipeGroup> recipeGroups = new Dictionary<int, RecipeGroup>();

		// Token: 0x040001FF RID: 511
		public static Dictionary<string, int> recipeGroupIDs = new Dictionary<string, int>();

		// Token: 0x04000200 RID: 512
		public static int nextRecipeGroupIndex = 0;
	}
}

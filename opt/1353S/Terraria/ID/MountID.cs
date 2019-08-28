using System;

namespace Terraria.ID
{
	// Token: 0x020000CF RID: 207
	public static class MountID
	{
		// Token: 0x04001465 RID: 5221
		public static int Count = 15;

		// Token: 0x02000270 RID: 624
		public static class Sets
		{
			// Token: 0x04003BAE RID: 15278
			public static SetFactory Factory = new SetFactory(MountID.Count);

			// Token: 0x04003BAF RID: 15279
			public static bool[] Cart = MountID.Sets.Factory.CreateBoolSet(new int[]
			{
				6,
				11,
				13
			});
		}
	}
}

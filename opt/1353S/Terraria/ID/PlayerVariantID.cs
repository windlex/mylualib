using System;

namespace Terraria.ID
{
	// Token: 0x020000D0 RID: 208
	public static class PlayerVariantID
	{
		// Token: 0x04001466 RID: 5222
		public static SetFactory Factory = new SetFactory(10);

		// Token: 0x04001467 RID: 5223
		public const int MaleStarter = 0;

		// Token: 0x04001468 RID: 5224
		public const int MaleSticker = 1;

		// Token: 0x04001469 RID: 5225
		public const int MaleGangster = 2;

		// Token: 0x0400146A RID: 5226
		public const int MaleCoat = 3;

		// Token: 0x0400146B RID: 5227
		public const int FemaleStarter = 4;

		// Token: 0x0400146C RID: 5228
		public const int FemaleSticker = 5;

		// Token: 0x0400146D RID: 5229
		public const int FemaleGangster = 6;

		// Token: 0x0400146E RID: 5230
		public const int FemaleCoat = 7;

		// Token: 0x0400146F RID: 5231
		public const int MaleDress = 8;

		// Token: 0x04001470 RID: 5232
		public const int FemaleDress = 9;

		// Token: 0x04001471 RID: 5233
		public const int Count = 10;

		// Token: 0x02000271 RID: 625
		public class Sets
		{
			// Token: 0x04003BB0 RID: 15280
			public static bool[] Male = PlayerVariantID.Factory.CreateBoolSet(new int[]
			{
				0,
				1,
				2,
				3,
				8
			});

			// Token: 0x04003BB1 RID: 15281
			public static int[] AltGenderReference = PlayerVariantID.Factory.CreateIntSet(0, new int[]
			{
				0,
				4,
				4,
				0,
				1,
				5,
				5,
				1,
				2,
				6,
				6,
				2,
				3,
				7,
				7,
				3,
				8,
				9,
				9,
				8
			});

			// Token: 0x04003BB2 RID: 15282
			public static int[] VariantOrderMale = new int[]
			{
				0,
				1,
				2,
				3,
				8
			};

			// Token: 0x04003BB3 RID: 15283
			public static int[] VariantOrderFemale = new int[]
			{
				4,
				5,
				6,
				7,
				9
			};
		}
	}
}

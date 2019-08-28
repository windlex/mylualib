using System;
using Microsoft.Xna.Framework;

namespace Terraria.ID
{
	// Token: 0x020000CC RID: 204
	public static class Colors
	{
		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000D0D RID: 3341 RVA: 0x003DD5F8 File Offset: 0x003DB7F8
		public static Color CurrentLiquidColor
		{
			get
			{
				Color color = Color.Transparent;
				bool flag = true;
				for (int i = 0; i < 11; i++)
				{
					if (Main.liquidAlpha[i] > 0f)
					{
						if (flag)
						{
							flag = false;
							color = Colors._liquidColors[i];
						}
						else
						{
							color = Color.Lerp(color, Colors._liquidColors[i], Main.liquidAlpha[i]);
						}
					}
				}
				return color;
			}
		}

		// Token: 0x06000D0E RID: 3342 RVA: 0x003DD658 File Offset: 0x003DB858
		public static Color AlphaDarken(Color input)
		{
			return input * ((float)Main.mouseTextColor / 255f);
		}

		// Token: 0x0400124B RID: 4683
		public static readonly Color RarityAmber = new Color(255, 175, 0);

		// Token: 0x0400124C RID: 4684
		public static readonly Color RarityTrash = new Color(130, 130, 130);

		// Token: 0x0400124D RID: 4685
		public static readonly Color RarityNormal = Color.White;

		// Token: 0x0400124E RID: 4686
		public static readonly Color RarityBlue = new Color(150, 150, 255);

		// Token: 0x0400124F RID: 4687
		public static readonly Color RarityGreen = new Color(150, 255, 150);

		// Token: 0x04001250 RID: 4688
		public static readonly Color RarityOrange = new Color(255, 200, 150);

		// Token: 0x04001251 RID: 4689
		public static readonly Color RarityRed = new Color(255, 150, 150);

		// Token: 0x04001252 RID: 4690
		public static readonly Color RarityPink = new Color(255, 150, 255);

		// Token: 0x04001253 RID: 4691
		public static readonly Color RarityPurple = new Color(210, 160, 255);

		// Token: 0x04001254 RID: 4692
		public static readonly Color RarityLime = new Color(150, 255, 10);

		// Token: 0x04001255 RID: 4693
		public static readonly Color RarityYellow = new Color(255, 255, 10);

		// Token: 0x04001256 RID: 4694
		public static readonly Color RarityCyan = new Color(5, 200, 255);

		// Token: 0x04001257 RID: 4695
		public static readonly Color CoinPlatinum = new Color(220, 220, 198);

		// Token: 0x04001258 RID: 4696
		public static readonly Color CoinGold = new Color(224, 201, 92);

		// Token: 0x04001259 RID: 4697
		public static readonly Color CoinSilver = new Color(181, 192, 193);

		// Token: 0x0400125A RID: 4698
		public static readonly Color CoinCopper = new Color(246, 138, 96);

		// Token: 0x0400125B RID: 4699
		public static readonly Color[] _waterfallColors = new Color[]
		{
			new Color(9, 61, 191),
			new Color(253, 32, 3),
			new Color(143, 143, 143),
			new Color(59, 29, 131),
			new Color(7, 145, 142),
			new Color(171, 11, 209),
			new Color(9, 137, 191),
			new Color(168, 106, 32),
			new Color(36, 60, 148),
			new Color(65, 59, 101),
			new Color(200, 0, 0),
			default(Color),
			default(Color),
			new Color(177, 54, 79),
			new Color(255, 156, 12),
			new Color(91, 34, 104),
			new Color(102, 104, 34),
			new Color(34, 43, 104),
			new Color(34, 104, 38),
			new Color(104, 34, 34),
			new Color(76, 79, 102),
			new Color(104, 61, 34)
		};

		// Token: 0x0400125C RID: 4700
		public static readonly Color[] _liquidColors = new Color[]
		{
			new Color(9, 61, 191),
			new Color(253, 32, 3),
			new Color(59, 29, 131),
			new Color(7, 145, 142),
			new Color(171, 11, 209),
			new Color(9, 137, 191),
			new Color(168, 106, 32),
			new Color(36, 60, 148),
			new Color(65, 59, 101),
			new Color(200, 0, 0),
			new Color(177, 54, 79),
			new Color(255, 156, 12)
		};
	}
}

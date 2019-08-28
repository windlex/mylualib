﻿using System;

namespace Terraria
{
	// Token: 0x0200002E RID: 46
	public class Sign
	{
		// Token: 0x0600044D RID: 1101 RVA: 0x002936C0 File Offset: 0x002918C0
		public static void KillSign(int x, int y)
		{
			for (int i = 0; i < 1000; i++)
			{
				if (Main.sign[i] != null && Main.sign[i].x == x && Main.sign[i].y == y)
				{
					Main.sign[i] = null;
				}
			}
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x0029370C File Offset: 0x0029190C
		public static int ReadSign(int i, int j, bool CreateIfMissing = true)
		{
			int num = (int)(Main.tile[i, j].frameX / 18);
			int num2 = (int)(Main.tile[i, j].frameY / 18);
			num %= 2;
			int num3 = i - num;
			int num4 = j - num2;
			if (!Main.tileSign[(int)Main.tile[num3, num4].type])
			{
				Sign.KillSign(num3, num4);
				return -1;
			}
			int num5 = -1;
			for (int k = 0; k < 1000; k++)
			{
				if (Main.sign[k] != null && Main.sign[k].x == num3 && Main.sign[k].y == num4)
				{
					num5 = k;
					break;
				}
			}
			if (num5 < 0 & CreateIfMissing)
			{
				for (int l = 0; l < 1000; l++)
				{
					if (Main.sign[l] == null)
					{
						num5 = l;
						Main.sign[l] = new Sign();
						Main.sign[l].x = num3;
						Main.sign[l].y = num4;
						Main.sign[l].text = "";
						break;
					}
				}
			}
			return num5;
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00293824 File Offset: 0x00291A24
		public static void TextSign(int i, string text)
		{
			if (Main.tile[Main.sign[i].x, Main.sign[i].y] == null || !Main.tile[Main.sign[i].x, Main.sign[i].y].active() || !Main.tileSign[(int)Main.tile[Main.sign[i].x, Main.sign[i].y].type])
			{
				Main.sign[i] = null;
				return;
			}
			Main.sign[i].text = text;
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x002938C4 File Offset: 0x00291AC4
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"x",
				this.x,
				"\ty",
				this.y,
				"\t",
				this.text
			});
		}

		// Token: 0x040006B6 RID: 1718
		public const int maxSigns = 1000;

		// Token: 0x040006B7 RID: 1719
		public int x;

		// Token: 0x040006B8 RID: 1720
		public int y;

		// Token: 0x040006B9 RID: 1721
		public string text;
	}
}

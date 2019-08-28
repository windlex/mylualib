using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics;

namespace Terraria.Initializers
{
	// Token: 0x02000085 RID: 133
	public static class PlayerDataInitializer
	{
		// Token: 0x06000ABB RID: 2747 RVA: 0x003C7038 File Offset: 0x003C5238
		public static void Load()
		{
			Main.playerTextures = new Texture2D[10, 15];
			PlayerDataInitializer.LoadStarterMale();
			PlayerDataInitializer.LoadStarterFemale();
			PlayerDataInitializer.LoadStickerMale();
			PlayerDataInitializer.LoadStickerFemale();
			PlayerDataInitializer.LoadGangsterMale();
			PlayerDataInitializer.LoadGangsterFemale();
			PlayerDataInitializer.LoadCoatMale();
			PlayerDataInitializer.LoadDressFemale();
			PlayerDataInitializer.LoadDressMale();
			PlayerDataInitializer.LoadCoatFemale();
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x003C7088 File Offset: 0x003C5288
		private static void LoadDebugs()
		{
			PlayerDataInitializer.CopyVariant(8, 0);
			PlayerDataInitializer.CopyVariant(9, 4);
			for (int i = 8; i < 10; i++)
			{
				Main.playerTextures[i, 4] = Main.armorArmTexture[191];
				Main.playerTextures[i, 6] = Main.armorArmTexture[191];
				Main.playerTextures[i, 11] = Main.armorArmTexture[191];
				Main.playerTextures[i, 12] = Main.armorArmTexture[191];
				Main.playerTextures[i, 13] = Main.armorArmTexture[191];
				Main.playerTextures[i, 8] = Main.armorArmTexture[191];
			}
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x003C7144 File Offset: 0x003C5344
		private static void LoadVariant(int ID, int[] pieceIDs)
		{
			for (int i = 0; i < pieceIDs.Length; i++)
			{
				Main.playerTextures[ID, pieceIDs[i]] = TextureManager.Load(string.Concat(new object[]
				{
					"Images/Player_",
					ID,
					"_",
					pieceIDs[i]
				}));
			}
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x003C71A4 File Offset: 0x003C53A4
		private static void CopyVariant(int to, int from)
		{
			for (int i = 0; i < 15; i++)
			{
				Main.playerTextures[to, i] = Main.playerTextures[from, i];
			}
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x003C71D8 File Offset: 0x003C53D8
		private static void LoadStarterMale()
		{
			PlayerDataInitializer.LoadVariant(0, new int[]
			{
				0,
				1,
				2,
				3,
				4,
				5,
				6,
				7,
				8,
				9,
				10,
				11,
				12,
				13
			});
			Main.playerTextures[0, 14] = TextureManager.BlankTexture;
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x003C7204 File Offset: 0x003C5404
		private static void LoadStickerMale()
		{
			PlayerDataInitializer.CopyVariant(1, 0);
			PlayerDataInitializer.LoadVariant(1, new int[]
			{
				4,
				6,
				8,
				11,
				12,
				13
			});
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x003C7224 File Offset: 0x003C5424
		private static void LoadGangsterMale()
		{
			PlayerDataInitializer.CopyVariant(2, 0);
			PlayerDataInitializer.LoadVariant(2, new int[]
			{
				4,
				6,
				8,
				11,
				12,
				13
			});
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x003C7244 File Offset: 0x003C5444
		private static void LoadCoatMale()
		{
			PlayerDataInitializer.CopyVariant(3, 0);
			PlayerDataInitializer.LoadVariant(3, new int[]
			{
				4,
				6,
				8,
				11,
				12,
				13,
				14
			});
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x003C7264 File Offset: 0x003C5464
		private static void LoadDressMale()
		{
			PlayerDataInitializer.CopyVariant(8, 0);
			PlayerDataInitializer.LoadVariant(8, new int[]
			{
				4,
				6,
				8,
				11,
				12,
				13,
				14
			});
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x003C7284 File Offset: 0x003C5484
		private static void LoadStarterFemale()
		{
			PlayerDataInitializer.CopyVariant(4, 0);
			PlayerDataInitializer.LoadVariant(4, new int[]
			{
				3,
				4,
				5,
				6,
				7,
				8,
				9,
				10,
				11,
				12,
				13
			});
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x003C72A8 File Offset: 0x003C54A8
		private static void LoadStickerFemale()
		{
			PlayerDataInitializer.CopyVariant(5, 4);
			PlayerDataInitializer.LoadVariant(5, new int[]
			{
				4,
				6,
				8,
				11,
				12,
				13
			});
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x003C72C8 File Offset: 0x003C54C8
		private static void LoadGangsterFemale()
		{
			PlayerDataInitializer.CopyVariant(6, 4);
			PlayerDataInitializer.LoadVariant(6, new int[]
			{
				4,
				6,
				8,
				11,
				12,
				13
			});
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x003C72E8 File Offset: 0x003C54E8
		private static void LoadCoatFemale()
		{
			PlayerDataInitializer.CopyVariant(7, 4);
			PlayerDataInitializer.LoadVariant(7, new int[]
			{
				4,
				6,
				8,
				11,
				12,
				13,
				14
			});
		}

		// Token: 0x06000AC8 RID: 2760 RVA: 0x003C7308 File Offset: 0x003C5508
		private static void LoadDressFemale()
		{
			PlayerDataInitializer.CopyVariant(9, 4);
			PlayerDataInitializer.LoadVariant(9, new int[]
			{
				4,
				6,
				8,
				11,
				12,
				13
			});
		}
	}
}

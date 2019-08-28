using System;
using System.Text.RegularExpressions;
using Terraria.Utilities;

namespace Terraria.Localization
{
	// Token: 0x020000BF RID: 191
	public static class Language
	{
		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000CB1 RID: 3249 RVA: 0x003DB01C File Offset: 0x003D921C
		public static GameCulture ActiveCulture
		{
			get
			{
				return LanguageManager.Instance.ActiveCulture;
			}
		}

		// Token: 0x06000CB2 RID: 3250 RVA: 0x003DB028 File Offset: 0x003D9228
		public static LocalizedText GetText(string key)
		{
			return LanguageManager.Instance.GetText(key);
		}

		// Token: 0x06000CB3 RID: 3251 RVA: 0x003DB038 File Offset: 0x003D9238
		public static string GetTextValue(string key)
		{
			return LanguageManager.Instance.GetTextValue(key);
		}

		// Token: 0x06000CB4 RID: 3252 RVA: 0x003DB048 File Offset: 0x003D9248
		public static string GetTextValue(string key, object arg0)
		{
			return LanguageManager.Instance.GetTextValue(key, arg0);
		}

		// Token: 0x06000CB5 RID: 3253 RVA: 0x003DB058 File Offset: 0x003D9258
		public static string GetTextValue(string key, object arg0, object arg1)
		{
			return LanguageManager.Instance.GetTextValue(key, arg0, arg1);
		}

		// Token: 0x06000CB6 RID: 3254 RVA: 0x003DB068 File Offset: 0x003D9268
		public static string GetTextValue(string key, object arg0, object arg1, object arg2)
		{
			return LanguageManager.Instance.GetTextValue(key, arg0, arg1, arg2);
		}

		// Token: 0x06000CB7 RID: 3255 RVA: 0x003DB078 File Offset: 0x003D9278
		public static string GetTextValue(string key, params object[] args)
		{
			return LanguageManager.Instance.GetTextValue(key, args);
		}

		// Token: 0x06000CB8 RID: 3256 RVA: 0x003DB088 File Offset: 0x003D9288
		public static string GetTextValueWith(string key, object obj)
		{
			return LanguageManager.Instance.GetText(key).FormatWith(obj);
		}

		// Token: 0x06000CB9 RID: 3257 RVA: 0x003DB09C File Offset: 0x003D929C
		public static bool Exists(string key)
		{
			return LanguageManager.Instance.Exists(key);
		}

		// Token: 0x06000CBA RID: 3258 RVA: 0x003DB0AC File Offset: 0x003D92AC
		public static int GetCategorySize(string key)
		{
			return LanguageManager.Instance.GetCategorySize(key);
		}

		// Token: 0x06000CBB RID: 3259 RVA: 0x003DB0BC File Offset: 0x003D92BC
		public static LocalizedText[] FindAll(Regex regex)
		{
			return LanguageManager.Instance.FindAll(regex);
		}

		// Token: 0x06000CBC RID: 3260 RVA: 0x003DB0CC File Offset: 0x003D92CC
		public static LocalizedText[] FindAll(LanguageSearchFilter filter)
		{
			return LanguageManager.Instance.FindAll(filter);
		}

		// Token: 0x06000CBD RID: 3261 RVA: 0x003DB0DC File Offset: 0x003D92DC
		public static LocalizedText SelectRandom(LanguageSearchFilter filter, UnifiedRandom random = null)
		{
			return LanguageManager.Instance.SelectRandom(filter, random);
		}

		// Token: 0x06000CBE RID: 3262 RVA: 0x003DB0EC File Offset: 0x003D92EC
		public static LocalizedText RandomFromCategory(string categoryName, UnifiedRandom random = null)
		{
			return LanguageManager.Instance.RandomFromCategory(categoryName, random);
		}
	}
}

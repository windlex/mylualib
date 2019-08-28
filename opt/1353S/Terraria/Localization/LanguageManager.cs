using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json;
using ReLogic.Graphics;
using Terraria.Utilities;

namespace Terraria.Localization
{
	// Token: 0x020000C0 RID: 192
	public class LanguageManager
	{
		// Token: 0x14000024 RID: 36
		// (add) Token: 0x06000CBF RID: 3263 RVA: 0x003DB0FC File Offset: 0x003D92FC
		// (remove) Token: 0x06000CC0 RID: 3264 RVA: 0x003DB134 File Offset: 0x003D9334
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event LanguageChangeCallback OnLanguageChanging;

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x06000CC1 RID: 3265 RVA: 0x003DB16C File Offset: 0x003D936C
		// (remove) Token: 0x06000CC2 RID: 3266 RVA: 0x003DB1A4 File Offset: 0x003D93A4
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event LanguageChangeCallback OnLanguageChanged;

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000CC3 RID: 3267 RVA: 0x003DB1DC File Offset: 0x003D93DC
		// (set) Token: 0x06000CC4 RID: 3268 RVA: 0x003DB1E4 File Offset: 0x003D93E4
		public GameCulture ActiveCulture
		{
			get;
			private set;
		}

		// Token: 0x06000CC5 RID: 3269 RVA: 0x003DB1F0 File Offset: 0x003D93F0
		private LanguageManager()
		{
			this._localizedTexts[""] = LocalizedText.Empty;
		}

		// Token: 0x06000CC6 RID: 3270 RVA: 0x003DB230 File Offset: 0x003D9430
		public int GetCategorySize(string name)
		{
			if (this._categoryGroupedKeys.ContainsKey(name))
			{
				return this._categoryGroupedKeys[name].Count;
			}
			return 0;
		}

		// Token: 0x06000CC7 RID: 3271 RVA: 0x003DB254 File Offset: 0x003D9454
		public void SetLanguage(int legacyId)
		{
			GameCulture language = GameCulture.FromLegacyId(legacyId);
			this.SetLanguage(language);
		}

		// Token: 0x06000CC8 RID: 3272 RVA: 0x003DB270 File Offset: 0x003D9470
		public void SetLanguage(string cultureName)
		{
			GameCulture language = GameCulture.FromName(cultureName);
			this.SetLanguage(language);
		}

		// Token: 0x06000CC9 RID: 3273 RVA: 0x003DB28C File Offset: 0x003D948C
		private void SetAllTextValuesToKeys()
		{
			foreach (KeyValuePair<string, LocalizedText> current in this._localizedTexts)
			{
				current.Value.SetValue(current.Key);
			}
		}

		// Token: 0x06000CCA RID: 3274 RVA: 0x003DB2EC File Offset: 0x003D94EC
		private string[] GetLanguageFilesForCulture(GameCulture culture)
		{
			Assembly.GetExecutingAssembly();
			return Array.FindAll<string>(typeof(Program).Assembly.GetManifestResourceNames(), (string element) => element.StartsWith("Terraria.Localization.Content." + culture.CultureInfo.Name) && element.EndsWith(".json"));
		}

		// Token: 0x06000CCB RID: 3275 RVA: 0x003DB334 File Offset: 0x003D9534
		public void SetLanguage(GameCulture culture)
		{
			if (this.ActiveCulture == culture)
			{
				return;
			}
			if (culture != this._fallbackCulture && this.ActiveCulture != this._fallbackCulture)
			{
				this.SetAllTextValuesToKeys();
				this.LoadLanguage(this._fallbackCulture);
			}
			this.LoadLanguage(culture);
			this.ActiveCulture = culture;
			Thread.CurrentThread.CurrentCulture = culture.CultureInfo;
			Thread.CurrentThread.CurrentUICulture = culture.CultureInfo;
			if (this.OnLanguageChanged != null)
			{
				this.OnLanguageChanged(this);
			}
		}

		// Token: 0x06000CCC RID: 3276 RVA: 0x003DB3B8 File Offset: 0x003D95B8
		private void LoadLanguage(GameCulture culture)
		{
			this.LoadFilesForCulture(culture);
			if (this.OnLanguageChanging != null)
			{
				this.OnLanguageChanging(this);
			}
			this.ProcessCopyCommandsInTexts();
		}

		// Token: 0x06000CCD RID: 3277 RVA: 0x003DB3DC File Offset: 0x003D95DC
		private void LoadFilesForCulture(GameCulture culture)
		{
			string[] languageFilesForCulture = this.GetLanguageFilesForCulture(culture);
			for (int i = 0; i < languageFilesForCulture.Length; i++)
			{
				string text = languageFilesForCulture[i];
				try
				{
					string text2 = LanguageManager.ReadEmbeddedResource(text);
					if (text2 == null || text2.Length < 2)
					{
						throw new FileFormatException();
					}
					this.LoadLanguageFromFileText(text2);
				}
				catch (Exception)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					Console.WriteLine("Failed to load language file: " + text);
					break;
				}
			}
		}

		// Token: 0x06000CCE RID: 3278 RVA: 0x003DB454 File Offset: 0x003D9654
		private static string ReadEmbeddedResource(string path)
		{
			string result;
			using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path))
			{
				using (StreamReader streamReader = new StreamReader(manifestResourceStream))
				{
					result = streamReader.ReadToEnd();
				}
			}
			return result;
		}

		// Token: 0x06000CCF RID: 3279 RVA: 0x003DB4B0 File Offset: 0x003D96B0
		private void ProcessCopyCommandsInTexts()
		{
			Regex regex = new Regex("{\\$(\\w+\\.\\w+)}", RegexOptions.Compiled);
			foreach (KeyValuePair<string, LocalizedText> current in this._localizedTexts)
			{
				LocalizedText value = current.Value;
				for (int i = 0; i < 100; i++)
				{
					string text = regex.Replace(value.Value, (Match match) => this.GetTextValue(match.Groups[1].ToString()));
					if (text == value.Value)
					{
						break;
					}
					value.SetValue(text);
				}
			}
		}

		// Token: 0x06000CD0 RID: 3280 RVA: 0x003DB554 File Offset: 0x003D9754
		public void LoadLanguageFromFileText(string fileText)
		{
			foreach (KeyValuePair<string, Dictionary<string, string>> current in JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(fileText))
			{
				string arg_20_0 = current.Key;
				foreach (KeyValuePair<string, string> current2 in current.Value)
				{
					string key = current.Key + "." + current2.Key;
					if (this._localizedTexts.ContainsKey(key))
					{
						this._localizedTexts[key].SetValue(current2.Value);
					}
					else
					{
						this._localizedTexts.Add(key, new LocalizedText(key, current2.Value));
						if (!this._categoryGroupedKeys.ContainsKey(current.Key))
						{
							this._categoryGroupedKeys.Add(current.Key, new List<string>());
						}
						this._categoryGroupedKeys[current.Key].Add(current2.Key);
					}
				}
			}
		}

		// Token: 0x06000CD1 RID: 3281 RVA: 0x003DB6B0 File Offset: 0x003D98B0
		[Conditional("DEBUG")]
		private void ValidateAllCharactersContainedInFont(DynamicSpriteFont font)
		{
			if (font == null)
			{
				return;
			}
			using (Dictionary<string, LocalizedText>.ValueCollection.Enumerator enumerator = this._localizedTexts.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					string value = enumerator.Current.Value;
					for (int i = 0; i < value.Length; i++)
					{
						char arg_2F_0 = value[i];
					}
				}
			}
		}

		// Token: 0x06000CD2 RID: 3282 RVA: 0x003DB724 File Offset: 0x003D9924
		public LocalizedText[] FindAll(Regex regex)
		{
			int num = 0;
			foreach (KeyValuePair<string, LocalizedText> current in this._localizedTexts)
			{
				if (regex.IsMatch(current.Key))
				{
					num++;
				}
			}
			LocalizedText[] array = new LocalizedText[num];
			int num2 = 0;
			foreach (KeyValuePair<string, LocalizedText> current2 in this._localizedTexts)
			{
				if (regex.IsMatch(current2.Key))
				{
					array[num2] = current2.Value;
					num2++;
				}
			}
			return array;
		}

		// Token: 0x06000CD3 RID: 3283 RVA: 0x003DB7EC File Offset: 0x003D99EC
		public LocalizedText[] FindAll(LanguageSearchFilter filter)
		{
			LinkedList<LocalizedText> linkedList = new LinkedList<LocalizedText>();
			foreach (KeyValuePair<string, LocalizedText> current in this._localizedTexts)
			{
				if (filter(current.Key, current.Value))
				{
					linkedList.AddLast(current.Value);
				}
			}
			return linkedList.ToArray<LocalizedText>();
		}

		// Token: 0x06000CD4 RID: 3284 RVA: 0x003DB868 File Offset: 0x003D9A68
		public LocalizedText SelectRandom(LanguageSearchFilter filter, UnifiedRandom random = null)
		{
			int num = 0;
			foreach (KeyValuePair<string, LocalizedText> current in this._localizedTexts)
			{
				if (filter(current.Key, current.Value))
				{
					num++;
				}
			}
			int num2 = (random ?? Main.rand).Next(num);
			foreach (KeyValuePair<string, LocalizedText> current2 in this._localizedTexts)
			{
				if (filter(current2.Key, current2.Value) && --num == num2)
				{
					return current2.Value;
				}
			}
			return LocalizedText.Empty;
		}

		// Token: 0x06000CD5 RID: 3285 RVA: 0x003DB950 File Offset: 0x003D9B50
		public LocalizedText RandomFromCategory(string categoryName, UnifiedRandom random = null)
		{
			if (!this._categoryGroupedKeys.ContainsKey(categoryName))
			{
				return new LocalizedText(categoryName + ".RANDOM", categoryName + ".RANDOM");
			}
			List<string> list = this._categoryGroupedKeys[categoryName];
			return this.GetText(categoryName + "." + list[(random ?? Main.rand).Next(list.Count)]);
		}

		// Token: 0x06000CD6 RID: 3286 RVA: 0x003DB9C0 File Offset: 0x003D9BC0
		public bool Exists(string key)
		{
			return this._localizedTexts.ContainsKey(key);
		}

		// Token: 0x06000CD7 RID: 3287 RVA: 0x003DB9D0 File Offset: 0x003D9BD0
		public LocalizedText GetText(string key)
		{
			if (!this._localizedTexts.ContainsKey(key))
			{
				return new LocalizedText(key, key);
			}
			return this._localizedTexts[key];
		}

		// Token: 0x06000CD8 RID: 3288 RVA: 0x003DB9F4 File Offset: 0x003D9BF4
		public string GetTextValue(string key)
		{
			if (this._localizedTexts.ContainsKey(key))
			{
				return this._localizedTexts[key].Value;
			}
			return key;
		}

		// Token: 0x06000CD9 RID: 3289 RVA: 0x003DBA18 File Offset: 0x003D9C18
		public string GetTextValue(string key, object arg0)
		{
			if (this._localizedTexts.ContainsKey(key))
			{
				return this._localizedTexts[key].Format(arg0);
			}
			return key;
		}

		// Token: 0x06000CDA RID: 3290 RVA: 0x003DBA3C File Offset: 0x003D9C3C
		public string GetTextValue(string key, object arg0, object arg1)
		{
			if (this._localizedTexts.ContainsKey(key))
			{
				return this._localizedTexts[key].Format(arg0, arg1);
			}
			return key;
		}

		// Token: 0x06000CDB RID: 3291 RVA: 0x003DBA64 File Offset: 0x003D9C64
		public string GetTextValue(string key, object arg0, object arg1, object arg2)
		{
			if (this._localizedTexts.ContainsKey(key))
			{
				return this._localizedTexts[key].Format(arg0, arg1, arg2);
			}
			return key;
		}

		// Token: 0x06000CDC RID: 3292 RVA: 0x003DBA8C File Offset: 0x003D9C8C
		public string GetTextValue(string key, params object[] args)
		{
			if (this._localizedTexts.ContainsKey(key))
			{
				return this._localizedTexts[key].Format(args);
			}
			return key;
		}

		// Token: 0x06000CDD RID: 3293 RVA: 0x003DBAB0 File Offset: 0x003D9CB0
		public void SetFallbackCulture(GameCulture culture)
		{
			this._fallbackCulture = culture;
		}

		// Token: 0x0400103C RID: 4156
		public static LanguageManager Instance = new LanguageManager();

		// Token: 0x04001040 RID: 4160
		private Dictionary<string, LocalizedText> _localizedTexts = new Dictionary<string, LocalizedText>();

		// Token: 0x04001041 RID: 4161
		private Dictionary<string, List<string>> _categoryGroupedKeys = new Dictionary<string, List<string>>();

		// Token: 0x04001042 RID: 4162
		private GameCulture _fallbackCulture = GameCulture.English;
	}
}

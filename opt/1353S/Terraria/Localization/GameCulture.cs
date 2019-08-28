using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Terraria.Localization
{
	// Token: 0x020000BC RID: 188
	public class GameCulture
	{
		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000CA2 RID: 3234 RVA: 0x003DAEC8 File Offset: 0x003D90C8
		public bool IsActive
		{
			get
			{
				return Language.ActiveCulture == this;
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000CA3 RID: 3235 RVA: 0x003DAED4 File Offset: 0x003D90D4
		public string Name
		{
			get
			{
				return this.CultureInfo.Name;
			}
		}

		// Token: 0x06000CA4 RID: 3236 RVA: 0x003DAEE4 File Offset: 0x003D90E4
		public static GameCulture FromLegacyId(int id)
		{
			if (id < 1)
			{
				id = 1;
			}
			return GameCulture._legacyCultures[id];
		}

		// Token: 0x06000CA5 RID: 3237 RVA: 0x003DAEF8 File Offset: 0x003D90F8
		public static GameCulture FromName(string name)
		{
			return GameCulture._legacyCultures.Values.SingleOrDefault((GameCulture culture) => culture.Name == name) ?? GameCulture.English;
		}

		// Token: 0x06000CA6 RID: 3238 RVA: 0x003DAF38 File Offset: 0x003D9138
		public GameCulture(string name, int legacyId)
		{
			this.CultureInfo = new CultureInfo(name);
			this.LegacyId = legacyId;
			GameCulture.RegisterLegacyCulture(this, legacyId);
		}

		// Token: 0x06000CA7 RID: 3239 RVA: 0x003DAF5C File Offset: 0x003D915C
		private static void RegisterLegacyCulture(GameCulture culture, int legacyId)
		{
			if (GameCulture._legacyCultures == null)
			{
				GameCulture._legacyCultures = new Dictionary<int, GameCulture>();
			}
			GameCulture._legacyCultures.Add(legacyId, culture);
		}

		// Token: 0x04001030 RID: 4144
		public static readonly GameCulture English = new GameCulture("en-US", 1);

		// Token: 0x04001031 RID: 4145
		public static readonly GameCulture German = new GameCulture("de-DE", 2);

		// Token: 0x04001032 RID: 4146
		public static readonly GameCulture Italian = new GameCulture("it-IT", 3);

		// Token: 0x04001033 RID: 4147
		public static readonly GameCulture French = new GameCulture("fr-FR", 4);

		// Token: 0x04001034 RID: 4148
		public static readonly GameCulture Spanish = new GameCulture("es-ES", 5);

		// Token: 0x04001035 RID: 4149
		public static readonly GameCulture Russian = new GameCulture("ru-RU", 6);

		// Token: 0x04001036 RID: 4150
		public static readonly GameCulture Chinese = new GameCulture("zh-Hans", 7);

		// Token: 0x04001037 RID: 4151
		public static readonly GameCulture Portuguese = new GameCulture("pt-BR", 8);

		// Token: 0x04001038 RID: 4152
		public static readonly GameCulture Polish = new GameCulture("pl-PL", 9);

		// Token: 0x04001039 RID: 4153
		private static Dictionary<int, GameCulture> _legacyCultures;

		// Token: 0x0400103A RID: 4154
		public readonly CultureInfo CultureInfo;

		// Token: 0x0400103B RID: 4155
		public readonly int LegacyId;
	}
}

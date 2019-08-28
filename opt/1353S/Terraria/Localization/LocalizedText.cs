using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Terraria.Localization
{
	// Token: 0x020000C1 RID: 193
	public class LocalizedText
	{
		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000CE0 RID: 3296 RVA: 0x003DBAE4 File Offset: 0x003D9CE4
		// (set) Token: 0x06000CE1 RID: 3297 RVA: 0x003DBAEC File Offset: 0x003D9CEC
		public string Value
		{
			get;
			private set;
		}

		// Token: 0x06000CE2 RID: 3298 RVA: 0x003DBAF8 File Offset: 0x003D9CF8
		internal LocalizedText(string key, string text)
		{
			this.Key = key;
			this.Value = text;
		}

		// Token: 0x06000CE3 RID: 3299 RVA: 0x003DBB10 File Offset: 0x003D9D10
		internal void SetValue(string text)
		{
			this.Value = text;
		}

		// Token: 0x06000CE4 RID: 3300 RVA: 0x003DBB1C File Offset: 0x003D9D1C
		public string FormatWith(object obj)
		{
			string value = this.Value;
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj);
			return LocalizedText._substitutionRegex.Replace(value, delegate(Match match)
			{
				if (match.Groups[1].Length != 0)
				{
					return "";
				}
				string name = match.Groups[2].ToString();
				PropertyDescriptor propertyDescriptor = properties.Find(name, false);
				if (propertyDescriptor == null)
				{
					return "";
				}
				return (propertyDescriptor.GetValue(obj) ?? "").ToString();
			});
		}

		// Token: 0x06000CE5 RID: 3301 RVA: 0x003DBB68 File Offset: 0x003D9D68
		public bool CanFormatWith(object obj)
		{
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj);
			foreach (Match match in LocalizedText._substitutionRegex.Matches(this.Value))
			{
				string name = match.Groups[2].ToString();
				PropertyDescriptor propertyDescriptor = properties.Find(name, false);
				if (propertyDescriptor == null)
				{
					bool result = false;
					return result;
				}
				object value = propertyDescriptor.GetValue(obj);
				if (value == null)
				{
					bool result = false;
					return result;
				}
				if (match.Groups[1].Length != 0 && (((value as bool?) ?? false) ^ match.Groups[1].Length == 1))
				{
					bool result = false;
					return result;
				}
			}
			return true;
		}

		// Token: 0x06000CE6 RID: 3302 RVA: 0x003DBC64 File Offset: 0x003D9E64
		public NetworkText ToNetworkText()
		{
			return NetworkText.FromKey(this.Key, new object[0]);
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x003DBC78 File Offset: 0x003D9E78
		public NetworkText ToNetworkText(params object[] substitutions)
		{
			return NetworkText.FromKey(this.Key, substitutions);
		}

		// Token: 0x06000CE8 RID: 3304 RVA: 0x003DBC88 File Offset: 0x003D9E88
		public static explicit operator string(LocalizedText text)
		{
			return text.Value;
		}

		// Token: 0x06000CE9 RID: 3305 RVA: 0x003DBC90 File Offset: 0x003D9E90
		public string Format(object arg0)
		{
			return string.Format(this.Value, arg0);
		}

		// Token: 0x06000CEA RID: 3306 RVA: 0x003DBCA0 File Offset: 0x003D9EA0
		public string Format(object arg0, object arg1)
		{
			return string.Format(this.Value, arg0, arg1);
		}

		// Token: 0x06000CEB RID: 3307 RVA: 0x003DBCB0 File Offset: 0x003D9EB0
		public string Format(object arg0, object arg1, object arg2)
		{
			return string.Format(this.Value, arg0, arg1, arg2);
		}

		// Token: 0x06000CEC RID: 3308 RVA: 0x003DBCC0 File Offset: 0x003D9EC0
		public string Format(params object[] args)
		{
			return string.Format(this.Value, args);
		}

		// Token: 0x06000CED RID: 3309 RVA: 0x003DBCD0 File Offset: 0x003D9ED0
		public override string ToString()
		{
			return this.Value;
		}

		// Token: 0x04001043 RID: 4163
		public static readonly LocalizedText Empty = new LocalizedText("", "");

		// Token: 0x04001044 RID: 4164
		private static Regex _substitutionRegex = new Regex("{(\\?(?:!)?)?([a-zA-Z][\\w\\.]*)}", RegexOptions.Compiled);

		// Token: 0x04001045 RID: 4165
		public readonly string Key;
	}
}

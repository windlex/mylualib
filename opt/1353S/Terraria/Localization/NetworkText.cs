using System;
using System.IO;
using System.Text;

namespace Terraria.Localization
{
	// Token: 0x020000C2 RID: 194
	public class NetworkText
	{
		// Token: 0x06000CEF RID: 3311 RVA: 0x003DB30E File Offset: 0x003D950E
		private NetworkText(string text, NetworkText.Mode mode)
		{
			this._text = text;
			this._mode = mode;
		}

		// Token: 0x06000CF0 RID: 3312 RVA: 0x003DB324 File Offset: 0x003D9524
		private static NetworkText[] ConvertSubstitutionsToNetworkText(object[] substitutions)
		{
			NetworkText[] array = new NetworkText[substitutions.Length];
			for (int i = 0; i < substitutions.Length; i++)
			{
				NetworkText networkText = substitutions[i] as NetworkText;
				if (networkText == null)
				{
					networkText = NetworkText.FromLiteral(substitutions[i].ToString());
				}
				array[i] = networkText;
			}
			return array;
		}

		// Token: 0x06000CF7 RID: 3319 RVA: 0x003DB464 File Offset: 0x003D9664
		public static NetworkText Deserialize(BinaryReader reader)
		{
			NetworkText.Mode mode = (NetworkText.Mode)reader.ReadByte();
			NetworkText expr_13 = new NetworkText(reader.ReadString(), mode);
			expr_13.DeserializeSubstitutionList(reader);
			return expr_13;
		}

		// Token: 0x06000CF8 RID: 3320 RVA: 0x003DB48C File Offset: 0x003D968C
		public static NetworkText DeserializeLiteral(BinaryReader reader)
		{
			NetworkText.Mode mode = (NetworkText.Mode)reader.ReadByte();
			NetworkText networkText = new NetworkText(reader.ReadString(), mode);
			networkText.DeserializeSubstitutionList(reader);
			if (mode != NetworkText.Mode.Literal)
			{
				networkText.SetToEmptyLiteral();
			}
			return networkText;
		}

		// Token: 0x06000CF9 RID: 3321 RVA: 0x003DB4C0 File Offset: 0x003D96C0
		private void DeserializeSubstitutionList(BinaryReader reader)
		{
			if (this._mode == NetworkText.Mode.Literal)
			{
				return;
			}
			this._substitutions = new NetworkText[(int)reader.ReadByte()];
			for (int i = 0; i < this._substitutions.Length; i++)
			{
				this._substitutions[i] = NetworkText.Deserialize(reader);
			}
		}

		// Token: 0x06000CF1 RID: 3313 RVA: 0x003DB367 File Offset: 0x003D9567
		public static NetworkText FromFormattable(string text, params object[] substitutions)
		{
			return new NetworkText(text, NetworkText.Mode.Formattable)
			{
				_substitutions = NetworkText.ConvertSubstitutionsToNetworkText(substitutions)
			};
		}

		// Token: 0x06000CF3 RID: 3315 RVA: 0x003DB385 File Offset: 0x003D9585
		public static NetworkText FromKey(string key, params object[] substitutions)
		{
			return new NetworkText(key, NetworkText.Mode.LocalizationKey)
			{
				_substitutions = NetworkText.ConvertSubstitutionsToNetworkText(substitutions)
			};
		}

		// Token: 0x06000CF2 RID: 3314 RVA: 0x003DB37C File Offset: 0x003D957C
		public static NetworkText FromLiteral(string text)
		{
			return new NetworkText(text, NetworkText.Mode.Literal);
		}

		// Token: 0x06000CF4 RID: 3316 RVA: 0x003DB39C File Offset: 0x003D959C
		public int GetMaxSerializedSize()
		{
			int num = 0;
			num++;
			num += 4 + Encoding.UTF8.GetByteCount(this._text);
			if (this._mode != NetworkText.Mode.Literal)
			{
				num++;
				for (int i = 0; i < this._substitutions.Length; i++)
				{
					num += this._substitutions[i].GetMaxSerializedSize();
				}
			}
			return num;
		}

		// Token: 0x06000CF5 RID: 3317 RVA: 0x003DB3F4 File Offset: 0x003D95F4
		public void Serialize(BinaryWriter writer)
		{
			writer.Write((byte)this._mode);
			writer.Write(this._text);
			this.SerializeSubstitutionList(writer);
		}

		// Token: 0x06000CF6 RID: 3318 RVA: 0x003DB418 File Offset: 0x003D9618
		private void SerializeSubstitutionList(BinaryWriter writer)
		{
			if (this._mode == NetworkText.Mode.Literal)
			{
				return;
			}
			writer.Write((byte)this._substitutions.Length);
			for (int i = 0; i < (this._substitutions.Length & 255); i++)
			{
				this._substitutions[i].Serialize(writer);
			}
		}

		// Token: 0x06000CFA RID: 3322 RVA: 0x003DB508 File Offset: 0x003D9708
		private void SetToEmptyLiteral()
		{
			this._mode = NetworkText.Mode.Literal;
			this._text = string.Empty;
			this._substitutions = null;
		}

		// Token: 0x06000CFC RID: 3324 RVA: 0x003DB5D8 File Offset: 0x003D97D8
		private string ToDebugInfoString(string linePrefix = "")
		{
			string text = string.Format("{0}Mode: {1}\n{0}Text: {2}\n", linePrefix, this._mode, this._text);
			if (this._mode == NetworkText.Mode.LocalizationKey)
			{
				text += string.Format("{0}Localized Text: {1}\n", linePrefix, Language.GetTextValue(this._text));
			}
			if (this._mode != NetworkText.Mode.Literal)
			{
				for (int i = 0; i < this._substitutions.Length; i++)
				{
					text += string.Format("{0}Substitution {1}:\n", linePrefix, i);
					text += this._substitutions[i].ToDebugInfoString(linePrefix + "\t");
				}
			}
			return text;
		}

		// Token: 0x06000CFB RID: 3323 RVA: 0x003DB524 File Offset: 0x003D9724
		public override string ToString()
		{
			try
			{
				switch (this._mode)
				{
					case NetworkText.Mode.Literal:
						{
							string result = this._text;
							return result;
						}
					case NetworkText.Mode.Formattable:
						{
							string result = string.Format(this._text, this._substitutions);
							return result;
						}
					case NetworkText.Mode.LocalizationKey:
						{
							string result = Language.GetTextValue(this._text, this._substitutions);
							return result;
						}
					default:
						{
							string result = this._text;
							return result;
						}
				}
			}
			catch (Exception ex)
			{
				//				"NetworkText.ToString() threw an exception.\n" + this.ToDebugInfoString("") + "\n" + "Exception: " + ex.ToString();
				this.SetToEmptyLiteral();
			}
			return this._text;
		}

		// Token: 0x04001047 RID: 4167
		public static readonly NetworkText Empty = NetworkText.FromLiteral("");

		// Token: 0x0400104A RID: 4170
		private NetworkText.Mode _mode;

		// Token: 0x04001048 RID: 4168
		private NetworkText[] _substitutions;

		// Token: 0x04001049 RID: 4169
		private string _text;

		// Token: 0x0200025D RID: 605
		private enum Mode : byte
		{
			// Token: 0x040038DD RID: 14557
			Literal,
			// Token: 0x040038DE RID: 14558
			Formattable,
			// Token: 0x040038DF RID: 14559
			LocalizationKey
		}
	}
}

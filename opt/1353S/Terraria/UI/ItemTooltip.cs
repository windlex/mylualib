using System;
using System.Collections.Generic;
using Terraria.Localization;

namespace Terraria.UI
{
	// Token: 0x020000A1 RID: 161
	public class ItemTooltip
	{
		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000B9D RID: 2973 RVA: 0x003CF418 File Offset: 0x003CD618
		public int Lines
		{
			get
			{
				this.ValidateTooltip();
				if (this._tooltipLines == null)
				{
					return 0;
				}
				return this._tooltipLines.Length;
			}
		}

		// Token: 0x06000B9E RID: 2974 RVA: 0x003CF434 File Offset: 0x003CD634
		private ItemTooltip()
		{
		}

		// Token: 0x06000B9F RID: 2975 RVA: 0x003CF43C File Offset: 0x003CD63C
		private ItemTooltip(string key)
		{
			this._text = Language.GetText(key);
		}

		// Token: 0x06000BA0 RID: 2976 RVA: 0x003CF450 File Offset: 0x003CD650
		public static ItemTooltip FromLanguageKey(string key)
		{
			if (!Language.Exists(key))
			{
				return ItemTooltip.None;
			}
			return new ItemTooltip(key);
		}

		// Token: 0x06000BA1 RID: 2977 RVA: 0x003CF468 File Offset: 0x003CD668
		public string GetLine(int line)
		{
			this.ValidateTooltip();
			return this._tooltipLines[line];
		}

		// Token: 0x06000BA2 RID: 2978 RVA: 0x003CF478 File Offset: 0x003CD678
		private void ValidateTooltip()
		{
			if (this._lastCulture != Language.ActiveCulture)
			{
				this._lastCulture = Language.ActiveCulture;
				if (this._text == null)
				{
					this._tooltipLines = null;
					this._processedText = string.Empty;
					return;
				}
				string text = this._text.Value;
				using (List<TooltipProcessor>.Enumerator enumerator = ItemTooltip._globalProcessors.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						text = enumerator.Current(text);
					}
				}
				this._tooltipLines = text.Split(new char[]
				{
					'\n'
				});
				this._processedText = text;
			}
		}

		// Token: 0x06000BA3 RID: 2979 RVA: 0x003CF52C File Offset: 0x003CD72C
		public static void AddGlobalProcessor(TooltipProcessor processor)
		{
			ItemTooltip._globalProcessors.Add(processor);
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x003CF53C File Offset: 0x003CD73C
		public static void RemoveGlobalProcessor(TooltipProcessor processor)
		{
			ItemTooltip._globalProcessors.Remove(processor);
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x003CF54C File Offset: 0x003CD74C
		public static void ClearGlobalProcessors()
		{
			ItemTooltip._globalProcessors.Clear();
		}

		// Token: 0x04000EAE RID: 3758
		public static readonly ItemTooltip None = new ItemTooltip();

		// Token: 0x04000EAF RID: 3759
		private static List<TooltipProcessor> _globalProcessors = new List<TooltipProcessor>();

		// Token: 0x04000EB0 RID: 3760
		private string[] _tooltipLines;

		// Token: 0x04000EB1 RID: 3761
		private GameCulture _lastCulture;

		// Token: 0x04000EB2 RID: 3762
		private LocalizedText _text;

		// Token: 0x04000EB3 RID: 3763
		private string _processedText;
	}
}

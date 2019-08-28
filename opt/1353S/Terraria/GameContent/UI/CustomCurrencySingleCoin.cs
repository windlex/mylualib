using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI
{
	// Token: 0x02000137 RID: 311
	public class CustomCurrencySingleCoin : CustomCurrencySystem
	{
		// Token: 0x06001038 RID: 4152 RVA: 0x003FE694 File Offset: 0x003FC894
		public CustomCurrencySingleCoin(int coinItemID, long currencyCap)
		{
			base.Include(coinItemID, 1);
			base.SetCurrencyCap(currencyCap);
		}

		// Token: 0x06001039 RID: 4153 RVA: 0x003FE6E0 File Offset: 0x003FC8E0
		public override bool TryPurchasing(int price, List<Item[]> inv, List<Point> slotCoins, List<Point> slotsEmpty, List<Point> slotEmptyBank, List<Point> slotEmptyBank2, List<Point> slotEmptyBank3)
		{
			List<Tuple<Point, Item>> cache = base.ItemCacheCreate(inv);
			int num = price;
			for (int i = 0; i < slotCoins.Count; i++)
			{
				Point point = slotCoins[i];
				int num2 = num;
				if (inv[point.X][point.Y].stack < num2)
				{
					num2 = inv[point.X][point.Y].stack;
				}
				num -= num2;
				inv[point.X][point.Y].stack -= num2;
				if (inv[point.X][point.Y].stack == 0)
				{
					switch (point.X)
					{
					case 0:
						slotsEmpty.Add(point);
						break;
					case 1:
						slotEmptyBank.Add(point);
						break;
					case 2:
						slotEmptyBank2.Add(point);
						break;
					case 3:
						slotEmptyBank3.Add(point);
						break;
					}
					slotCoins.Remove(point);
					i--;
				}
				if (num == 0)
				{
					break;
				}
			}
			if (num != 0)
			{
				base.ItemCacheRestore(cache, inv);
				return false;
			}
			return true;
		}

		// Token: 0x0600103A RID: 4154 RVA: 0x003FE7F4 File Offset: 0x003FC9F4
		public override void DrawSavingsMoney(SpriteBatch sb, string text, float shopx, float shopy, long totalCoins, bool horizontal = false)
		{
			int num = this._valuePerUnit.Keys.ElementAt(0);
			Texture2D texture2D = Main.itemTexture[num];
			if (horizontal)
			{
				Vector2 vector = new Vector2(shopx + ChatManager.GetStringSize(Main.fontMouseText, text, Vector2.One, -1f).X + 45f, shopy + 50f);
				sb.Draw(texture2D, vector, null, Color.White, 0f, texture2D.Size() / 2f, this.CurrencyDrawScale, SpriteEffects.None, 0f);
				Utils.DrawBorderStringFourWay(sb, Main.fontItemStack, totalCoins.ToString(), vector.X - 11f, vector.Y, Color.White, Color.Black, new Vector2(0.3f), 0.75f);
				return;
			}
			int num2 = (totalCoins > 99L) ? -6 : 0;
			sb.Draw(texture2D, new Vector2(shopx + 11f, shopy + 75f), null, Color.White, 0f, texture2D.Size() / 2f, this.CurrencyDrawScale, SpriteEffects.None, 0f);
			Utils.DrawBorderStringFourWay(sb, Main.fontItemStack, totalCoins.ToString(), shopx + (float)num2, shopy + 75f, Color.White, Color.Black, new Vector2(0.3f), 0.75f);
		}

		// Token: 0x0600103B RID: 4155 RVA: 0x003FE960 File Offset: 0x003FCB60
		public override void GetPriceText(string[] lines, ref int currentLine, int price)
		{
			Color color = this.CurrencyTextColor * ((float)Main.mouseTextColor / 255f);
			int num = currentLine;
			currentLine = num + 1;
			lines[num] = string.Format("[c/{0:X2}{1:X2}{2:X2}:{3} {4} {5}]", new object[]
			{
				color.R,
				color.G,
				color.B,
				Lang.tip[50].Value,
				price,
				Language.GetTextValue(this.CurrencyTextKey).ToLower()
			});
		}

		// Token: 0x0400309F RID: 12447
		public float CurrencyDrawScale = 0.8f;

		// Token: 0x040030A0 RID: 12448
		public string CurrencyTextKey = "Currency.DefenderMedals";

		// Token: 0x040030A1 RID: 12449
		public Color CurrencyTextColor = new Color(240, 100, 120);
	}
}

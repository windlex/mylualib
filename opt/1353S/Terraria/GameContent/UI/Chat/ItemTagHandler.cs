using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.UI;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Chat
{
	// Token: 0x0200015D RID: 349
	public class ItemTagHandler : ITagHandler
	{
		// Token: 0x06001189 RID: 4489 RVA: 0x0040DE6C File Offset: 0x0040C06C
		TextSnippet ITagHandler.Parse(string text, Color baseColor, string options)
		{
			Item item = new Item();
			int type;
			if (int.TryParse(text, out type))
			{
				item.netDefaults(type);
			}
			if (item.type <= 0)
			{
				return new TextSnippet(text);
			}
			item.stack = 1;
			if (options != null)
			{
				string[] array = options.Split(new char[]
				{
					','
				});
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].Length != 0)
					{
						char c = array[i][0];
						int value2;
						if (c != 'p')
						{
							int value;
							if ((c == 's' || c == 'x') && int.TryParse(array[i].Substring(1), out value))
							{
								item.stack = Utils.Clamp<int>(value, 1, item.maxStack);
							}
						}
						else if (int.TryParse(array[i].Substring(1), out value2))
						{
							item.Prefix((int)((byte)Utils.Clamp<int>(value2, 0, 84)));
						}
					}
				}
			}
			string str = "";
			if (item.stack > 1)
			{
				str = " (" + item.stack + ")";
			}
			return new ItemTagHandler.ItemSnippet(item)
			{
				Text = "[" + item.AffixName() + str + "]",
				CheckForHover = true,
				DeleteWhole = true
			};
		}

		// Token: 0x0600118A RID: 4490 RVA: 0x0040DFA8 File Offset: 0x0040C1A8
		public static string GenerateTag(Item I)
		{
			string text = "[i";
			if (I.prefix != 0)
			{
				text = text + "/p" + I.prefix;
			}
			if (I.stack != 1)
			{
				text = text + "/s" + I.stack;
			}
			return string.Concat(new object[]
			{
				text,
				":",
				I.netID,
				"]"
			});
		}

		// Token: 0x020002B0 RID: 688
		private class ItemSnippet : TextSnippet
		{
			// Token: 0x06001773 RID: 6003 RVA: 0x0043C100 File Offset: 0x0043A300
			public ItemSnippet(Item item) : base("")
			{
				this._item = item;
				this.Color = ItemRarity.GetColor(item.rare);
			}

			// Token: 0x06001774 RID: 6004 RVA: 0x0043C128 File Offset: 0x0043A328
			public override void OnHover()
			{
				Main.HoverItem = this._item.Clone();
				Main.instance.MouseText(this._item.Name, this._item.rare, 0, -1, -1, -1, -1);
			}

			// Token: 0x06001775 RID: 6005 RVA: 0x0043C160 File Offset: 0x0043A360
			public override bool UniqueDraw(bool justCheckingString, out Vector2 size, SpriteBatch spriteBatch, Vector2 position = default(Vector2), Color color = default(Color), float scale = 1f)
			{
				float num = 1f;
				float num2 = 1f;
				if (Main.netMode != 2 && !Main.dedServ)
				{
					Texture2D texture2D = Main.itemTexture[this._item.type];
					Rectangle rectangle;
					if (Main.itemAnimations[this._item.type] != null)
					{
						rectangle = Main.itemAnimations[this._item.type].GetFrame(texture2D);
					}
					else
					{
						rectangle = texture2D.Frame(1, 1, 0, 0);
					}
					if (rectangle.Height > 32)
					{
						num2 = 32f / (float)rectangle.Height;
					}
				}
				num2 *= scale;
				num *= num2;
				if (num > 0.75f)
				{
					num = 0.75f;
				}
				if (!justCheckingString && color != Color.Black)
				{
					float arg_E4_0 = Main.inventoryScale;
					Main.inventoryScale = scale * num;
					ItemSlot.Draw(spriteBatch, ref this._item, 14, position - new Vector2(10f) * scale * num, Color.White);
					Main.inventoryScale = arg_E4_0;
				}
				size = new Vector2(32f) * scale * num;
				return true;
			}

			// Token: 0x06001776 RID: 6006 RVA: 0x0043C274 File Offset: 0x0043A474
			public override float GetStringLength(DynamicSpriteFont font)
			{
				return 32f * this.Scale * 0.65f;
			}

			// Token: 0x04003D20 RID: 15648
			private Item _item;
		}
	}
}

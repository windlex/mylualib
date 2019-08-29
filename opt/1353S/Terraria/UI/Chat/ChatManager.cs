using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.Chat;
using Terraria.GameContent.UI.Chat;

namespace Terraria.UI.Chat
{
	// Token: 0x020000B3 RID: 179
	public static class ChatManager
	{
		// Token: 0x06000C57 RID: 3159 RVA: 0x003D88B0 File Offset: 0x003D6AB0
		public static bool AddChatText(DynamicSpriteFont font, string text, Vector2 baseScale)
		{
            Console.WriteLine("AddChatText+++++++++++++");
            Console.WriteLine(font.ToString());
            Console.WriteLine(text);
            Console.WriteLine(baseScale.ToString());
			int num = Main.screenWidth - 330;
			if (ChatManager.GetStringSize(font, Main.chatText + text, baseScale, -1f).X > (float)num)
			{
				return false;
			}
			Main.chatText += text;
			return true;
		}

		// Token: 0x06000C53 RID: 3155 RVA: 0x003D8698 File Offset: 0x003D6898
		public static void ConvertNormalSnippets(TextSnippet[] snippets)
		{
			for (int i = 0; i < snippets.Length; i++)
			{
				TextSnippet textSnippet = snippets[i];
				if (snippets[i].GetType() == typeof(TextSnippet))
				{
					PlainTagHandler.PlainSnippet plainSnippet = new PlainTagHandler.PlainSnippet(textSnippet.Text, textSnippet.Color, textSnippet.Scale);
					snippets[i] = plainSnippet;
				}
			}
		}

		// Token: 0x06000C5E RID: 3166 RVA: 0x003D8F9C File Offset: 0x003D719C
		public static Vector2 DrawColorCodedString(SpriteBatch spriteBatch, DynamicSpriteFont font, string text, Vector2 position, Color baseColor, float rotation, Vector2 origin, Vector2 baseScale, float maxWidth = -1f, bool ignoreColors = false)
		{
			Vector2 vector = position;
			Vector2 vector2 = vector;
			string[] arg_37_0 = text.Split(new char[]
			{
				'\n'
			});
			float x = font.MeasureString(" ").X;
			Color color = baseColor;
			float num = 1f;
			float num2 = 0f;
			string[] array = arg_37_0;
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					':'
				});
				for (int j = 0; j < array2.Length; j++)
				{
					string text2 = array2[j];
					if (text2.StartsWith("sss"))
					{
						if (text2.StartsWith("sss1"))
						{
							if (!ignoreColors)
							{
								color = Color.Red;
							}
						}
						else if (text2.StartsWith("sss2"))
						{
							if (!ignoreColors)
							{
								color = Color.Blue;
							}
						}
						else if (text2.StartsWith("sssr") && !ignoreColors)
						{
							color = Color.White;
						}
					}
					else
					{
						string[] array3 = text2.Split(new char[]
						{
							' '
						});
						for (int k = 0; k < array3.Length; k++)
						{
							if (k != 0)
							{
								vector.X += x * baseScale.X * num;
							}
							if (maxWidth > 0f)
							{
								float num3 = font.MeasureString(array3[k]).X * baseScale.X * num;
								if (vector.X - position.X + num3 > maxWidth)
								{
									vector.X = position.X;
									vector.Y += (float)font.LineSpacing * num2 * baseScale.Y;
									vector2.Y = Math.Max(vector2.Y, vector.Y);
									num2 = 0f;
								}
							}
							if (num2 < num)
							{
								num2 = num;
							}
							spriteBatch.DrawString(font, array3[k], vector, color, rotation, origin, baseScale * num, SpriteEffects.None, 0f);
							vector.X += font.MeasureString(array3[k]).X * baseScale.X * num;
							vector2.X = Math.Max(vector2.X, vector.X);
						}
					}
				}
				vector.X = position.X;
				vector.Y += (float)font.LineSpacing * num2 * baseScale.Y;
				vector2.Y = Math.Max(vector2.Y, vector.Y);
				num2 = 0f;
			}
			return vector2;
		}

		// Token: 0x06000C5B RID: 3163 RVA: 0x003D8C40 File Offset: 0x003D6E40
		public static Vector2 DrawColorCodedString(SpriteBatch spriteBatch, DynamicSpriteFont font, TextSnippet[] snippets, Vector2 position, Color baseColor, float rotation, Vector2 origin, Vector2 baseScale, out int hoveredSnippet, float maxWidth, bool ignoreColors = false)
		{
			int num = -1;
			Vector2 vec = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			Vector2 vector = position;
			Vector2 vector2 = vector;
			float x = font.MeasureString(" ").X;
			Color color = baseColor;
			float num2 = 0f;
			for (int i = 0; i < snippets.Length; i++)
			{
				TextSnippet textSnippet = snippets[i];
				textSnippet.Update();
				if (!ignoreColors)
				{
					color = textSnippet.GetVisibleColor();
				}
				float scale = textSnippet.Scale;
				Vector2 vector3;
				if (textSnippet.UniqueDraw(false, out vector3, spriteBatch, vector, color, scale))
				{
					if (vec.Between(vector, vector + vector3))
					{
						num = i;
					}
					vector.X += vector3.X * baseScale.X * scale;
					vector2.X = Math.Max(vector2.X, vector.X);
				}
				else
				{
					string[] array = textSnippet.Text.Split(new char[]
					{
						'\n'
					});
					string[] array2 = array;
					for (int j = 0; j < array2.Length; j++)
					{
						string[] array3 = array2[j].Split(new char[]
						{
							' '
						});
						for (int k = 0; k < array3.Length; k++)
						{
							if (k != 0)
							{
								vector.X += x * baseScale.X * scale;
							}
							if (maxWidth > 0f)
							{
								float num3 = font.MeasureString(array3[k]).X * baseScale.X * scale;
								if (vector.X - position.X + num3 > maxWidth)
								{
									vector.X = position.X;
									vector.Y += (float)font.LineSpacing * num2 * baseScale.Y;
									vector2.Y = Math.Max(vector2.Y, vector.Y);
									num2 = 0f;
								}
							}
							if (num2 < scale)
							{
								num2 = scale;
							}
							spriteBatch.DrawString(font, array3[k], vector, color, rotation, origin, baseScale * textSnippet.Scale * scale, SpriteEffects.None, 0f);
							Vector2 vector4 = font.MeasureString(array3[k]);
							if (vec.Between(vector, vector + vector4))
							{
								num = i;
							}
							vector.X += vector4.X * baseScale.X * scale;
							vector2.X = Math.Max(vector2.X, vector.X);
						}
						if (array.Length > 1)
						{
							vector.Y += (float)font.LineSpacing * num2 * baseScale.Y;
							vector.X = position.X;
							vector2.Y = Math.Max(vector2.Y, vector.Y);
							num2 = 0f;
						}
					}
				}
			}
			hoveredSnippet = num;
			return vector2;
		}

		// Token: 0x06000C5A RID: 3162 RVA: 0x003D8BF0 File Offset: 0x003D6DF0
		public static void DrawColorCodedStringShadow(SpriteBatch spriteBatch, DynamicSpriteFont font, TextSnippet[] snippets, Vector2 position, Color baseColor, float rotation, Vector2 origin, Vector2 baseScale, float maxWidth = -1f, float spread = 2f)
		{
			for (int i = 0; i < ChatManager.ShadowDirections.Length; i++)
			{
				int num;
				ChatManager.DrawColorCodedString(spriteBatch, font, snippets, position + ChatManager.ShadowDirections[i] * spread, baseColor, rotation, origin, baseScale, out num, maxWidth, true);
			}
		}

		// Token: 0x06000C5D RID: 3165 RVA: 0x003D8F50 File Offset: 0x003D7150
		public static void DrawColorCodedStringShadow(SpriteBatch spriteBatch, DynamicSpriteFont font, string text, Vector2 position, Color baseColor, float rotation, Vector2 origin, Vector2 baseScale, float maxWidth = -1f, float spread = 2f)
		{
			for (int i = 0; i < ChatManager.ShadowDirections.Length; i++)
			{
				ChatManager.DrawColorCodedString(spriteBatch, font, text, position + ChatManager.ShadowDirections[i] * spread, baseColor, rotation, origin, baseScale, maxWidth, true);
			}
		}

		// Token: 0x06000C5C RID: 3164 RVA: 0x003D8F10 File Offset: 0x003D7110
		public static Vector2 DrawColorCodedStringWithShadow(SpriteBatch spriteBatch, DynamicSpriteFont font, TextSnippet[] snippets, Vector2 position, float rotation, Vector2 origin, Vector2 baseScale, out int hoveredSnippet, float maxWidth = -1f, float spread = 2f)
		{
			ChatManager.DrawColorCodedStringShadow(spriteBatch, font, snippets, position, Color.Black, rotation, origin, baseScale, maxWidth, spread);
			return ChatManager.DrawColorCodedString(spriteBatch, font, snippets, position, Color.White, rotation, origin, baseScale, out hoveredSnippet, maxWidth, false);
		}

		// Token: 0x06000C5F RID: 3167 RVA: 0x003D9224 File Offset: 0x003D7424
		public static Vector2 DrawColorCodedStringWithShadow(SpriteBatch spriteBatch, DynamicSpriteFont font, string text, Vector2 position, Color baseColor, float rotation, Vector2 origin, Vector2 baseScale, float maxWidth = -1f, float spread = 2f)
		{
			TextSnippet[] snippets = ChatManager.ParseMessage(text, baseColor).ToArray();
			ChatManager.ConvertNormalSnippets(snippets);
			ChatManager.DrawColorCodedStringShadow(spriteBatch, font, snippets, position, Color.Black, rotation, origin, baseScale, maxWidth, spread);
			int num;
			return ChatManager.DrawColorCodedString(spriteBatch, font, snippets, position, Color.White, rotation, origin, baseScale, out num, maxWidth, false);
		}

		// Token: 0x06000C55 RID: 3157 RVA: 0x003D8728 File Offset: 0x003D6928
		private static ITagHandler GetHandler(string tagName)
		{
			string key = tagName.ToLower();
			if (ChatManager._handlers.ContainsKey(key))
			{
				return ChatManager._handlers[key];
			}
			return null;
		}

		// Token: 0x06000C58 RID: 3160 RVA: 0x003D8904 File Offset: 0x003D6B04
		public static Vector2 GetStringSize(DynamicSpriteFont font, string text, Vector2 baseScale, float maxWidth = -1f)
		{
			TextSnippet[] snippets = ChatManager.ParseMessage(text, Color.White).ToArray();
			return ChatManager.GetStringSize(font, snippets, baseScale, maxWidth);
		}

		// Token: 0x06000C59 RID: 3161 RVA: 0x003D892C File Offset: 0x003D6B2C
		public static Vector2 GetStringSize(DynamicSpriteFont font, TextSnippet[] snippets, Vector2 baseScale, float maxWidth = -1f)
		{
			Vector2 vec = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			Vector2 zero = Vector2.Zero;
			Vector2 vector = zero;
			Vector2 vector2 = vector;
			float x = font.MeasureString(" ").X;
			float num = 0f;
			for (int i = 0; i < snippets.Length; i++)
			{
				TextSnippet textSnippet = snippets[i];
				textSnippet.Update();
				float scale = textSnippet.Scale;
				Vector2 vector3;
				if (textSnippet.UniqueDraw(true, out vector3, null, default(Vector2), default(Color), 1f))
				{
					vector.X += vector3.X * baseScale.X * scale;
					vector2.X = Math.Max(vector2.X, vector.X);
					vector2.Y = Math.Max(vector2.Y, vector.Y + vector3.Y);
				}
				else
				{
					string[] array = textSnippet.Text.Split(new char[]
					{
						'\n'
					});
					string[] array2 = array;
					for (int j = 0; j < array2.Length; j++)
					{
						string[] array3 = array2[j].Split(new char[]
						{
							' '
						});
						for (int k = 0; k < array3.Length; k++)
						{
							if (k != 0)
							{
								vector.X += x * baseScale.X * scale;
							}
							if (maxWidth > 0f)
							{
								float num2 = font.MeasureString(array3[k]).X * baseScale.X * scale;
								if (vector.X - zero.X + num2 > maxWidth)
								{
									vector.X = zero.X;
									vector.Y += (float)font.LineSpacing * num * baseScale.Y;
									vector2.Y = Math.Max(vector2.Y, vector.Y);
									num = 0f;
								}
							}
							if (num < scale)
							{
								num = scale;
							}
							Vector2 vector4 = font.MeasureString(array3[k]);
							vec.Between(vector, vector + vector4);
							vector.X += vector4.X * baseScale.X * scale;
							vector2.X = Math.Max(vector2.X, vector.X);
							vector2.Y = Math.Max(vector2.Y, vector.Y + vector4.Y);
						}
						if (array.Length > 1)
						{
							vector.X = zero.X;
							vector.Y += (float)font.LineSpacing * num * baseScale.Y;
							vector2.Y = Math.Max(vector2.Y, vector.Y);
							num = 0f;
						}
					}
				}
			}
			return vector2;
		}

		// Token: 0x06000C56 RID: 3158 RVA: 0x003D8758 File Offset: 0x003D6958
		public static List<TextSnippet> ParseMessage(string text, Color baseColor)
		{
			MatchCollection arg_13_0 = ChatManager.Regexes.Format.Matches(text);
			List<TextSnippet> list = new List<TextSnippet>();
			int num = 0;
			foreach (Match match in arg_13_0)
			{
				if (match.Index > num)
				{
					list.Add(new TextSnippet(text.Substring(num, match.Index - num), baseColor, 1f));
				}
				num = match.Index + match.Length;
				string arg_A4_0 = match.Groups["tag"].Value;
				string value = match.Groups["text"].Value;
				string value2 = match.Groups["options"].Value;
				ITagHandler handler = ChatManager.GetHandler(arg_A4_0);
				if (handler != null)
				{
					list.Add(handler.Parse(value, baseColor, value2));
					list[list.Count - 1].TextOriginal = match.ToString();
				}
				else
				{
					list.Add(new TextSnippet(value, baseColor, 1f));
				}
			}
			if (text.Length > num)
			{
				list.Add(new TextSnippet(text.Substring(num, text.Length - num), baseColor, 1f));
			}
			return list;
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x003D86EC File Offset: 0x003D68EC
		public static void Register<T>(params string[] names) where T : ITagHandler, new()
		{
			T t = Activator.CreateInstance<T>();
			for (int i = 0; i < names.Length; i++)
			{
				ChatManager._handlers[names[i].ToLower()] = t;
			}
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x003D865C File Offset: 0x003D685C
		public static Color WaveColor(Color color)
		{
			float num = (float)Main.mouseTextColor / 255f;
			color = Color.Lerp(color, Color.Black, 1f - num);
			color.A = Main.mouseTextColor;
			return color;
		}

		// Token: 0x04000F18 RID: 3864
		public static readonly ChatCommandProcessor Commands = new ChatCommandProcessor();

		// Token: 0x04000F1A RID: 3866
		public static readonly Vector2[] ShadowDirections = new Vector2[]
		{
			-Vector2.UnitX,
			Vector2.UnitX,
			-Vector2.UnitY,
			Vector2.UnitY
		};

		// Token: 0x04000F19 RID: 3865
		private static ConcurrentDictionary<string, ITagHandler> _handlers = new ConcurrentDictionary<string, ITagHandler>();

		// Token: 0x02000258 RID: 600
		public static class Regexes
		{
			// Token: 0x040038BE RID: 14526
			public static readonly Regex Format = new Regex("(?<!\\\\)\\[(?<tag>[a-zA-Z]{1,10})(\\/(?<options>[^:]+))?:(?<text>.+?)(?<!\\\\)\\]", RegexOptions.Compiled);
		}
	}
}

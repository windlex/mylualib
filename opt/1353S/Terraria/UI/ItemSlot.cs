﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.UI;
using Terraria.GameContent.UI.Chat;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;

namespace Terraria.UI
{
	// Token: 0x020000A7 RID: 167
	public class ItemSlot
	{
		// Token: 0x06000BD4 RID: 3028 RVA: 0x003D27D4 File Offset: 0x003D09D4
		static ItemSlot()
		{
			ItemSlot.canFavoriteAt[0] = true;
			ItemSlot.canFavoriteAt[1] = true;
			ItemSlot.canFavoriteAt[2] = true;
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000BD5 RID: 3029 RVA: 0x003D286C File Offset: 0x003D0A6C
		public static bool ShiftInUse
		{
			get
			{
				return Main.keyState.PressingShift() || ItemSlot.ShiftForcedOn;
			}
		}

		// Token: 0x06000BD6 RID: 3030 RVA: 0x003D2884 File Offset: 0x003D0A84
		public static void SetGlow(int index, float hue, bool chest)
		{
			if (chest)
			{
				ItemSlot.inventoryGlowTimeChest[index] = 300;
				ItemSlot.inventoryGlowHueChest[index] = hue;
				return;
			}
			ItemSlot.inventoryGlowTime[index] = 300;
			ItemSlot.inventoryGlowHue[index] = hue;
		}

		// Token: 0x06000BD7 RID: 3031 RVA: 0x003D28B4 File Offset: 0x003D0AB4
		public static void UpdateInterface()
		{
			if (!Main.playerInventory || Main.player[Main.myPlayer].talkNPC == -1)
			{
				ItemSlot._customCurrencyForSavings = -1;
			}
			for (int i = 0; i < ItemSlot.inventoryGlowTime.Length; i++)
			{
				if (ItemSlot.inventoryGlowTime[i] > 0)
				{
					ItemSlot.inventoryGlowTime[i]--;
					if (ItemSlot.inventoryGlowTime[i] == 0)
					{
						ItemSlot.inventoryGlowHue[i] = 0f;
					}
				}
			}
			for (int j = 0; j < ItemSlot.inventoryGlowTimeChest.Length; j++)
			{
				if (ItemSlot.inventoryGlowTimeChest[j] > 0)
				{
					ItemSlot.inventoryGlowTimeChest[j]--;
					if (ItemSlot.inventoryGlowTimeChest[j] == 0)
					{
						ItemSlot.inventoryGlowHueChest[j] = 0f;
					}
				}
			}
		}

		// Token: 0x06000BD8 RID: 3032 RVA: 0x003D2964 File Offset: 0x003D0B64
		public static void Handle(ref Item inv, int context = 0)
		{
			ItemSlot.singleSlotArray[0] = inv;
			ItemSlot.Handle(ItemSlot.singleSlotArray, context, 0);
			inv = ItemSlot.singleSlotArray[0];
			Recipe.FindRecipes();
		}

		// Token: 0x06000BD9 RID: 3033 RVA: 0x003D298C File Offset: 0x003D0B8C
		public static void Handle(Item[] inv, int context = 0, int slot = 0)
		{
			ItemSlot.OverrideHover(inv, context, slot);
			if (Main.mouseLeftRelease && Main.mouseLeft)
			{
				ItemSlot.LeftClick(inv, context, slot);
				Recipe.FindRecipes();
			}
			else
			{
				ItemSlot.RightClick(inv, context, slot);
			}
			ItemSlot.MouseHover(inv, context, slot);
		}

		// Token: 0x06000BDA RID: 3034 RVA: 0x003D29C4 File Offset: 0x003D0BC4
		public static void OverrideHover(Item[] inv, int context = 0, int slot = 0)
		{
			Item item = inv[slot];
			if (ItemSlot.ShiftInUse && item.type > 0 && item.stack > 0 && !inv[slot].favorited)
			{
				switch (context)
				{
				case 0:
				case 1:
				case 2:
					if (Main.npcShop > 0 && !item.favorited)
					{
						Main.cursorOverride = 10;
					}
					else if (Main.player[Main.myPlayer].chest != -1)
					{
						if (ChestUI.TryPlacingInChest(item, true))
						{
							Main.cursorOverride = 9;
						}
					}
					else
					{
						Main.cursorOverride = 6;
					}
					break;
				case 3:
				case 4:
					if (Main.player[Main.myPlayer].ItemSpace(item))
					{
						Main.cursorOverride = 8;
					}
					break;
				case 5:
				case 8:
				case 9:
				case 10:
				case 11:
				case 12:
				case 16:
				case 17:
				case 18:
				case 19:
				case 20:
					if (Main.player[Main.myPlayer].ItemSpace(inv[slot]))
					{
						Main.cursorOverride = 7;
					}
					break;
				}
			}
			if (Main.keyState.IsKeyDown(Main.FavoriteKey) && ItemSlot.canFavoriteAt[context])
			{
				if (item.type > 0 && item.stack > 0 && Main.drawingPlayerChat)
				{
					Main.cursorOverride = 2;
					return;
				}
				if (item.type > 0 && item.stack > 0)
				{
					Main.cursorOverride = 3;
				}
			}
		}

		// Token: 0x06000BDB RID: 3035 RVA: 0x003D2B30 File Offset: 0x003D0D30
		private static bool OverrideLeftClick(Item[] inv, int context = 0, int slot = 0)
		{
			Item item = inv[slot];
			if (Main.cursorOverride == 2)
			{
				if (ChatManager.AddChatText(Main.fontMouseText, ItemTagHandler.GenerateTag(item), Vector2.One))
				{
					Main.PlaySound(12, -1, -1, 1, 1f, 0f);
				}
				return true;
			}
			if (Main.cursorOverride == 3)
			{
				if (!ItemSlot.canFavoriteAt[context])
				{
					return false;
				}
				item.favorited = !item.favorited;
				Main.PlaySound(12, -1, -1, 1, 1f, 0f);
				return true;
			}
			else
			{
				if (Main.cursorOverride == 7)
				{
					inv[slot] = Main.player[Main.myPlayer].GetItem(Main.myPlayer, inv[slot], false, true);
					Main.PlaySound(12, -1, -1, 1, 1f, 0f);
					return true;
				}
				if (Main.cursorOverride == 8)
				{
					inv[slot] = Main.player[Main.myPlayer].GetItem(Main.myPlayer, inv[slot], false, true);
					if (Main.player[Main.myPlayer].chest > -1)
					{
						NetMessage.SendData(32, -1, -1, null, Main.player[Main.myPlayer].chest, (float)slot, 0f, 0f, 0, 0, 0);
					}
					return true;
				}
				if (Main.cursorOverride == 9)
				{
					ChestUI.TryPlacingInChest(inv[slot], false);
					return true;
				}
				return false;
			}
		}

		// Token: 0x06000BDC RID: 3036 RVA: 0x003D2C68 File Offset: 0x003D0E68
		public static void LeftClick(ref Item inv, int context = 0)
		{
			ItemSlot.singleSlotArray[0] = inv;
			ItemSlot.LeftClick(ItemSlot.singleSlotArray, context, 0);
			inv = ItemSlot.singleSlotArray[0];
		}

		// Token: 0x06000BDD RID: 3037 RVA: 0x003D2C88 File Offset: 0x003D0E88
		public static void LeftClick(Item[] inv, int context = 0, int slot = 0)
		{
			if (ItemSlot.OverrideLeftClick(inv, context, slot))
			{
				return;
			}
			inv[slot].newAndShiny = false;
			Player player = Main.player[Main.myPlayer];
			bool flag = false;
			if (context <= 4)
			{
				flag = (player.chest == -1);
			}
			if (ItemSlot.ShiftInUse & flag)
			{
				ItemSlot.SellOrTrash(inv, context, slot);
				return;
			}
			if (player.itemAnimation == 0 && player.itemTime == 0)
			{
				int num = ItemSlot.PickItemMovementAction(inv, context, slot, Main.mouseItem);
				if (num == 0)
				{
					if (context == 6 && Main.mouseItem.type != 0)
					{
						inv[slot].SetDefaults(0, false);
					}
					Utils.Swap<Item>(ref inv[slot], ref Main.mouseItem);
					if (inv[slot].stack > 0)
					{
						if (context != 0)
						{
							if (context - 8 <= 4 || context - 16 <= 1)
							{
								AchievementsHelper.HandleOnEquip(player, inv[slot], context);
							}
						}
						else
						{
							AchievementsHelper.NotifyItemPickup(player, inv[slot]);
						}
					}
					if (inv[slot].type == 0 || inv[slot].stack < 1)
					{
						inv[slot] = new Item();
					}
					if (Main.mouseItem.IsTheSameAs(inv[slot]))
					{
						Utils.Swap<bool>(ref inv[slot].favorited, ref Main.mouseItem.favorited);
						if (inv[slot].stack != inv[slot].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
						{
							if (Main.mouseItem.stack + inv[slot].stack <= Main.mouseItem.maxStack)
							{
								inv[slot].stack += Main.mouseItem.stack;
								Main.mouseItem.stack = 0;
							}
							else
							{
								int num2 = Main.mouseItem.maxStack - inv[slot].stack;
								inv[slot].stack += num2;
								Main.mouseItem.stack -= num2;
							}
						}
					}
					if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
					{
						Main.mouseItem = new Item();
					}
					if (Main.mouseItem.type > 0 || inv[slot].type > 0)
					{
						Recipe.FindRecipes();
						Main.PlaySound(7, -1, -1, 1, 1f, 0f);
					}
					if (context == 3 && Main.netMode == 1)
					{
						NetMessage.SendData(32, -1, -1, null, player.chest, (float)slot, 0f, 0f, 0, 0, 0);
					}
				}
				else if (num == 1)
				{
					if (Main.mouseItem.stack == 1 && Main.mouseItem.type > 0 && inv[slot].type > 0 && inv[slot].IsNotTheSameAs(Main.mouseItem))
					{
						Utils.Swap<Item>(ref inv[slot], ref Main.mouseItem);
						Main.PlaySound(7, -1, -1, 1, 1f, 0f);
						if (inv[slot].stack > 0)
						{
							if (context != 0)
							{
								if (context - 8 <= 4 || context - 16 <= 1)
								{
									AchievementsHelper.HandleOnEquip(player, inv[slot], context);
								}
							}
							else
							{
								AchievementsHelper.NotifyItemPickup(player, inv[slot]);
							}
						}
					}
					else if (Main.mouseItem.type == 0 && inv[slot].type > 0)
					{
						Utils.Swap<Item>(ref inv[slot], ref Main.mouseItem);
						if (inv[slot].type == 0 || inv[slot].stack < 1)
						{
							inv[slot] = new Item();
						}
						if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
						{
							Main.mouseItem = new Item();
						}
						if (Main.mouseItem.type > 0 || inv[slot].type > 0)
						{
							Recipe.FindRecipes();
							Main.PlaySound(7, -1, -1, 1, 1f, 0f);
						}
					}
					else if (Main.mouseItem.type > 0 && inv[slot].type == 0)
					{
						if (Main.mouseItem.stack == 1)
						{
							Utils.Swap<Item>(ref inv[slot], ref Main.mouseItem);
							if (inv[slot].type == 0 || inv[slot].stack < 1)
							{
								inv[slot] = new Item();
							}
							if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
							{
								Main.mouseItem = new Item();
							}
							if (Main.mouseItem.type > 0 || inv[slot].type > 0)
							{
								Recipe.FindRecipes();
								Main.PlaySound(7, -1, -1, 1, 1f, 0f);
							}
						}
						else
						{
							Main.mouseItem.stack--;
							inv[slot].SetDefaults(Main.mouseItem.type, false);
							Recipe.FindRecipes();
							Main.PlaySound(7, -1, -1, 1, 1f, 0f);
						}
						if (inv[slot].stack > 0)
						{
							if (context != 0)
							{
								if (context - 8 <= 4 || context - 16 <= 1)
								{
									AchievementsHelper.HandleOnEquip(player, inv[slot], context);
								}
							}
							else
							{
								AchievementsHelper.NotifyItemPickup(player, inv[slot]);
							}
						}
					}
				}
				else if (num == 2)
				{
					if (Main.mouseItem.stack == 1 && Main.mouseItem.dye > 0 && inv[slot].type > 0 && inv[slot].type != Main.mouseItem.type)
					{
						Utils.Swap<Item>(ref inv[slot], ref Main.mouseItem);
						Main.PlaySound(7, -1, -1, 1, 1f, 0f);
						if (inv[slot].stack > 0)
						{
							if (context != 0)
							{
								if (context - 8 <= 4 || context - 16 <= 1)
								{
									AchievementsHelper.HandleOnEquip(player, inv[slot], context);
								}
							}
							else
							{
								AchievementsHelper.NotifyItemPickup(player, inv[slot]);
							}
						}
					}
					else if (Main.mouseItem.type == 0 && inv[slot].type > 0)
					{
						Utils.Swap<Item>(ref inv[slot], ref Main.mouseItem);
						if (inv[slot].type == 0 || inv[slot].stack < 1)
						{
							inv[slot] = new Item();
						}
						if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
						{
							Main.mouseItem = new Item();
						}
						if (Main.mouseItem.type > 0 || inv[slot].type > 0)
						{
							Recipe.FindRecipes();
							Main.PlaySound(7, -1, -1, 1, 1f, 0f);
						}
					}
					else if (Main.mouseItem.dye > 0 && inv[slot].type == 0)
					{
						if (Main.mouseItem.stack == 1)
						{
							Utils.Swap<Item>(ref inv[slot], ref Main.mouseItem);
							if (inv[slot].type == 0 || inv[slot].stack < 1)
							{
								inv[slot] = new Item();
							}
							if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
							{
								Main.mouseItem = new Item();
							}
							if (Main.mouseItem.type > 0 || inv[slot].type > 0)
							{
								Recipe.FindRecipes();
								Main.PlaySound(7, -1, -1, 1, 1f, 0f);
							}
						}
						else
						{
							Main.mouseItem.stack--;
							inv[slot].SetDefaults(Main.mouseItem.type, false);
							Recipe.FindRecipes();
							Main.PlaySound(7, -1, -1, 1, 1f, 0f);
						}
						if (inv[slot].stack > 0)
						{
							if (context != 0)
							{
								if (context - 8 <= 4 || context - 16 <= 1)
								{
									AchievementsHelper.HandleOnEquip(player, inv[slot], context);
								}
							}
							else
							{
								AchievementsHelper.NotifyItemPickup(player, inv[slot]);
							}
						}
					}
				}
				else if (num == 3)
				{
					Main.mouseItem.netDefaults(inv[slot].netID);
					if (inv[slot].buyOnce)
					{
						Main.mouseItem.Prefix((int)inv[slot].prefix);
					}
					else
					{
						Main.mouseItem.Prefix(-1);
					}
					Main.mouseItem.position = player.Center - new Vector2((float)Main.mouseItem.width, (float)Main.mouseItem.headSlot) / 2f;
					ItemText.NewText(Main.mouseItem, Main.mouseItem.stack, false, false);
					if (inv[slot].buyOnce)
					{
						Item expr_7DA = inv[slot];
						int num3 = expr_7DA.stack - 1;
						expr_7DA.stack = num3;
						if (num3 <= 0)
						{
							inv[slot].SetDefaults(0, false);
						}
					}
					if (inv[slot].value > 0)
					{
						Main.PlaySound(18, -1, -1, 1, 1f, 0f);
					}
					else
					{
						Main.PlaySound(7, -1, -1, 1, 1f, 0f);
					}
				}
				else if (num == 4)
				{
					Chest chest = Main.instance.shop[Main.npcShop];
					if (player.SellItem(Main.mouseItem.value, Main.mouseItem.stack))
					{
						chest.AddShop(Main.mouseItem);
						Main.mouseItem.SetDefaults(0, false);
						Main.PlaySound(18, -1, -1, 1, 1f, 0f);
					}
					else if (Main.mouseItem.value == 0)
					{
						chest.AddShop(Main.mouseItem);
						Main.mouseItem.SetDefaults(0, false);
						Main.PlaySound(7, -1, -1, 1, 1f, 0f);
					}
					Recipe.FindRecipes();
				}
				if (context > 2 && context != 5)
				{
					inv[slot].favorited = false;
				}
			}
		}

		// Token: 0x06000BDE RID: 3038 RVA: 0x003D3580 File Offset: 0x003D1780
		private static void SellOrTrash(Item[] inv, int context, int slot)
		{
			Player player = Main.player[Main.myPlayer];
			if (inv[slot].type > 0)
			{
				if (Main.npcShop > 0 && !inv[slot].favorited)
				{
					Chest chest = Main.instance.shop[Main.npcShop];
					if (inv[slot].type < 71 || inv[slot].type > 74)
					{
						if (player.SellItem(inv[slot].value, inv[slot].stack))
						{
							chest.AddShop(inv[slot]);
							inv[slot].SetDefaults(0, false);
							Main.PlaySound(18, -1, -1, 1, 1f, 0f);
							Recipe.FindRecipes();
							return;
						}
						if (inv[slot].value == 0)
						{
							chest.AddShop(inv[slot]);
							inv[slot].SetDefaults(0, false);
							Main.PlaySound(7, -1, -1, 1, 1f, 0f);
							Recipe.FindRecipes();
							return;
						}
					}
				}
				else if (!inv[slot].favorited && !ItemSlot.Options.DisableLeftShiftTrashCan)
				{
					Main.PlaySound(7, -1, -1, 1, 1f, 0f);
					player.trashItem = inv[slot].Clone();
					inv[slot].SetDefaults(0, false);
					if (context == 3 && Main.netMode == 1)
					{
						NetMessage.SendData(32, -1, -1, null, player.chest, (float)slot, 0f, 0f, 0, 0, 0);
					}
					Recipe.FindRecipes();
				}
			}
		}

		// Token: 0x06000BDF RID: 3039 RVA: 0x003D36D8 File Offset: 0x003D18D8
		private static string GetOverrideInstructions(Item[] inv, int context, int slot)
		{
			Player player = Main.player[Main.myPlayer];
			if (inv[slot].type > 0 && inv[slot].stack > 0)
			{
				if (!inv[slot].favorited)
				{
					switch (context)
					{
					case 0:
					case 1:
					case 2:
						if (Main.npcShop > 0 && !inv[slot].favorited)
						{
							return Lang.misc[75].Value;
						}
						if (Main.player[Main.myPlayer].chest == -1)
						{
							return Lang.misc[74].Value;
						}
						if (ChestUI.TryPlacingInChest(inv[slot], true))
						{
							return Lang.misc[76].Value;
						}
						break;
					case 3:
					case 4:
						if (Main.player[Main.myPlayer].ItemSpace(inv[slot]))
						{
							return Lang.misc[76].Value;
						}
						break;
					case 5:
					case 8:
					case 9:
					case 10:
					case 11:
					case 12:
					case 16:
					case 17:
					case 18:
					case 19:
					case 20:
						if (Main.player[Main.myPlayer].ItemSpace(inv[slot]))
						{
							return Lang.misc[68].Value;
						}
						break;
					}
				}
				bool flag = false;
				if (context <= 4)
				{
					flag = (player.chest == -1);
				}
				if (flag)
				{
					if (Main.npcShop > 0 && !inv[slot].favorited)
					{
						Chest arg_169_0 = Main.instance.shop[Main.npcShop];
						if (inv[slot].type >= 71 && inv[slot].type <= 74)
						{
							return "";
						}
						return Lang.misc[75].Value;
					}
					else if (!inv[slot].favorited && !ItemSlot.Options.DisableLeftShiftTrashCan)
					{
						return Lang.misc[74].Value;
					}
				}
			}
			return "";
		}

		// Token: 0x06000BE0 RID: 3040 RVA: 0x003D38A0 File Offset: 0x003D1AA0
		public static int PickItemMovementAction(Item[] inv, int context, int slot, Item checkItem)
		{
			Player player = Main.player[Main.myPlayer];
			int result = -1;
			if (context == 0)
			{
				result = 0;
			}
			else if (context == 1)
			{
				if (checkItem.type == 0 || checkItem.type == 71 || checkItem.type == 72 || checkItem.type == 73 || checkItem.type == 74)
				{
					result = 0;
				}
			}
			else if (context == 2)
			{
				if (((checkItem.type == 0 || checkItem.ammo > 0 || checkItem.bait > 0) && !checkItem.notAmmo) || checkItem.type == 530)
				{
					result = 0;
				}
			}
			else if (context == 3)
			{
				result = 0;
			}
			else if (context == 4)
			{
				result = 0;
			}
			else if (context == 5)
			{
				if (checkItem.Prefix(-3) || checkItem.type == 0)
				{
					result = 0;
				}
			}
			else if (context == 6)
			{
				result = 0;
			}
			else if (context == 7)
			{
				if (checkItem.material || checkItem.type == 0)
				{
					result = 0;
				}
			}
			else if (context == 8)
			{
				if (checkItem.type == 0 || (checkItem.headSlot > -1 && slot == 0) || (checkItem.bodySlot > -1 && slot == 1) || (checkItem.legSlot > -1 && slot == 2))
				{
					result = 1;
				}
			}
			else if (context == 9)
			{
				if (checkItem.type == 0 || (checkItem.headSlot > -1 && slot == 10) || (checkItem.bodySlot > -1 && slot == 11) || (checkItem.legSlot > -1 && slot == 12))
				{
					result = 1;
				}
			}
			else if (context == 10)
			{
				if (checkItem.type == 0 || (checkItem.accessory && !ItemSlot.AccCheck(checkItem, slot)))
				{
					result = 1;
				}
			}
			else if (context == 11)
			{
				if (checkItem.type == 0 || (checkItem.accessory && !ItemSlot.AccCheck(checkItem, slot)))
				{
					result = 1;
				}
			}
			else if (context == 12)
			{
				result = 2;
			}
			else if (context == 15)
			{
				if (checkItem.type == 0 && inv[slot].type > 0)
				{
					if (player.BuyItem(inv[slot].GetStoreValue(), inv[slot].shopSpecialCurrency))
					{
						result = 3;
					}
				}
				else if (inv[slot].type == 0 && checkItem.type > 0 && (checkItem.type < 71 || checkItem.type > 74))
				{
					result = 4;
				}
			}
			else if (context == 16)
			{
				if (checkItem.type == 0 || Main.projHook[checkItem.shoot])
				{
					result = 1;
				}
			}
			else if (context == 17)
			{
				if (checkItem.type == 0 || (checkItem.mountType != -1 && !MountID.Sets.Cart[checkItem.mountType]))
				{
					result = 1;
				}
			}
			else if (context == 19)
			{
				if (checkItem.type == 0 || (checkItem.buffType > 0 && Main.vanityPet[checkItem.buffType] && !Main.lightPet[checkItem.buffType]))
				{
					result = 1;
				}
			}
			else if (context == 18)
			{
				if (checkItem.type == 0 || (checkItem.mountType != -1 && MountID.Sets.Cart[checkItem.mountType]))
				{
					result = 1;
				}
			}
			else if (context == 20 && (checkItem.type == 0 || (checkItem.buffType > 0 && Main.lightPet[checkItem.buffType])))
			{
				result = 1;
			}
			return result;
		}

		// Token: 0x06000BE1 RID: 3041 RVA: 0x003D3BD0 File Offset: 0x003D1DD0
		public static void RightClick(ref Item inv, int context = 0)
		{
			ItemSlot.singleSlotArray[0] = inv;
			ItemSlot.RightClick(ItemSlot.singleSlotArray, context, 0);
			inv = ItemSlot.singleSlotArray[0];
		}

		// Token: 0x06000BE2 RID: 3042 RVA: 0x003D3BF0 File Offset: 0x003D1DF0
		public static void RightClick(Item[] inv, int context = 0, int slot = 0)
		{
			Player player = Main.player[Main.myPlayer];
			inv[slot].newAndShiny = false;
			if (player.itemAnimation > 0)
			{
				return;
			}
			bool flag = false;
			if (context == 0)
			{
				flag = true;
				if (Main.mouseRight && ((inv[slot].type >= 3318 && inv[slot].type <= 3332) || inv[slot].type == 3860 || inv[slot].type == 3862 || inv[slot].type == 3861))
				{
					if (Main.mouseRightRelease)
					{
						player.OpenBossBag(inv[slot].type);
						inv[slot].stack--;
						if (inv[slot].stack == 0)
						{
							inv[slot].SetDefaults(0, false);
						}
						Main.PlaySound(7, -1, -1, 1, 1f, 0f);
						Main.stackSplit = 30;
						Main.mouseRightRelease = false;
						Recipe.FindRecipes();
					}
				}
				else if (Main.mouseRight && ((inv[slot].type >= 2334 && inv[slot].type <= 2336) || (inv[slot].type >= 3203 && inv[slot].type <= 3208)))
				{
					if (Main.mouseRightRelease)
					{
						player.openCrate(inv[slot].type);
						inv[slot].stack--;
						if (inv[slot].stack == 0)
						{
							inv[slot].SetDefaults(0, false);
						}
						Main.PlaySound(7, -1, -1, 1, 1f, 0f);
						Main.stackSplit = 30;
						Main.mouseRightRelease = false;
						Recipe.FindRecipes();
					}
				}
				else if (Main.mouseRight && inv[slot].type == 3093)
				{
					if (Main.mouseRightRelease)
					{
						player.openHerbBag();
						inv[slot].stack--;
						if (inv[slot].stack == 0)
						{
							inv[slot].SetDefaults(0, false);
						}
						Main.PlaySound(7, -1, -1, 1, 1f, 0f);
						Main.stackSplit = 30;
						Main.mouseRightRelease = false;
						Recipe.FindRecipes();
					}
				}
				else if (Main.mouseRight && inv[slot].type == 1774)
				{
					if (Main.mouseRightRelease)
					{
						inv[slot].stack--;
						if (inv[slot].stack == 0)
						{
							inv[slot].SetDefaults(0, false);
						}
						Main.PlaySound(7, -1, -1, 1, 1f, 0f);
						Main.stackSplit = 30;
						Main.mouseRightRelease = false;
						player.openGoodieBag();
						Recipe.FindRecipes();
					}
				}
				else if (Main.mouseRight && inv[slot].type == 3085)
				{
					if (Main.mouseRightRelease && player.ConsumeItem(327, false))
					{
						inv[slot].stack--;
						if (inv[slot].stack == 0)
						{
							inv[slot].SetDefaults(0, false);
						}
						Main.PlaySound(7, -1, -1, 1, 1f, 0f);
						Main.stackSplit = 30;
						Main.mouseRightRelease = false;
						player.openLockBox();
						Recipe.FindRecipes();
					}
				}
				else if (Main.mouseRight && inv[slot].type == 1869)
				{
					if (Main.mouseRightRelease)
					{
						inv[slot].stack--;
						if (inv[slot].stack == 0)
						{
							inv[slot].SetDefaults(0, false);
						}
						Main.PlaySound(7, -1, -1, 1, 1f, 0f);
						Main.stackSplit = 30;
						Main.mouseRightRelease = false;
						player.openPresent();
						Recipe.FindRecipes();
					}
				}
				else if (Main.mouseRight && Main.mouseRightRelease && (inv[slot].type == 599 || inv[slot].type == 600 || inv[slot].type == 601))
				{
					Main.PlaySound(7, -1, -1, 1, 1f, 0f);
					Main.stackSplit = 30;
					Main.mouseRightRelease = false;
					int num = Main.rand.Next(14);
					if (num == 0 && Main.hardMode)
					{
						inv[slot].SetDefaults(602, false);
					}
					else if (num <= 7)
					{
						inv[slot].SetDefaults(586, false);
						inv[slot].stack = Main.rand.Next(20, 50);
					}
					else
					{
						inv[slot].SetDefaults(591, false);
						inv[slot].stack = Main.rand.Next(20, 50);
					}
					Recipe.FindRecipes();
				}
				else
				{
					flag = false;
				}
			}
			else if (context == 9 || context == 11)
			{
				flag = true;
				if (Main.mouseRight && Main.mouseRightRelease && ((inv[slot].type > 0 && inv[slot].stack > 0) || (inv[slot - 10].type > 0 && inv[slot - 10].stack > 0)))
				{
					bool flag2 = true;
					if (flag2 && context == 11 && inv[slot].wingSlot > 0)
					{
						for (int i = 3; i < 10; i++)
						{
							if (inv[i].wingSlot > 0 && i != slot - 10)
							{
								flag2 = false;
							}
						}
					}
					if (flag2)
					{
						Utils.Swap<Item>(ref inv[slot], ref inv[slot - 10]);
						Main.PlaySound(7, -1, -1, 1, 1f, 0f);
						Recipe.FindRecipes();
						if (inv[slot].stack > 0)
						{
							if (context != 0)
							{
								if (context - 8 <= 4 || context - 16 <= 1)
								{
									AchievementsHelper.HandleOnEquip(player, inv[slot], context);
								}
							}
							else
							{
								AchievementsHelper.NotifyItemPickup(player, inv[slot]);
							}
						}
					}
				}
			}
			else if (context == 12)
			{
				flag = true;
				if (Main.mouseRight && Main.mouseRightRelease && Main.mouseItem.stack < Main.mouseItem.maxStack && Main.mouseItem.type > 0 && inv[slot].type > 0 && Main.mouseItem.type == inv[slot].type)
				{
					Main.mouseItem.stack++;
					inv[slot].SetDefaults(0, false);
					Main.PlaySound(7, -1, -1, 1, 1f, 0f);
				}
			}
			else if (context == 15)
			{
				flag = true;
				Chest arg_629_0 = Main.instance.shop[Main.npcShop];
				if (Main.stackSplit <= 1 && Main.mouseRight && inv[slot].type > 0 && (Main.mouseItem.IsTheSameAs(inv[slot]) || Main.mouseItem.type == 0))
				{
					int num2 = Main.superFastStack + 1;
					for (int j = 0; j < num2; j++)
					{
						if ((Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0) && player.BuyItem(inv[slot].GetStoreValue(), inv[slot].shopSpecialCurrency) && inv[slot].stack > 0)
						{
							if (j == 0)
							{
								Main.PlaySound(18, -1, -1, 1, 1f, 0f);
							}
							if (Main.mouseItem.type == 0)
							{
								Main.mouseItem.netDefaults(inv[slot].netID);
								if (inv[slot].prefix != 0)
								{
									Main.mouseItem.Prefix((int)inv[slot].prefix);
								}
								Main.mouseItem.stack = 0;
							}
							Main.mouseItem.stack++;
							if (Main.stackSplit == 0)
							{
								Main.stackSplit = 15;
							}
							else
							{
								Main.stackSplit = Main.stackDelay;
							}
							if (inv[slot].buyOnce)
							{
								Item expr_762 = inv[slot];
								int num3 = expr_762.stack - 1;
								expr_762.stack = num3;
								if (num3 <= 0)
								{
									inv[slot].SetDefaults(0, false);
								}
							}
						}
					}
				}
			}
			if (!flag)
			{
				if ((context == 0 || context == 4 || context == 3) && Main.mouseRight && Main.mouseRightRelease && inv[slot].maxStack == 1)
				{
					ItemSlot.SwapEquip(inv, context, slot);
					return;
				}
				if (Main.stackSplit <= 1 && Main.mouseRight)
				{
					bool flag3 = true;
					if (context == 0 && inv[slot].maxStack <= 1)
					{
						flag3 = false;
					}
					if (context == 3 && inv[slot].maxStack <= 1)
					{
						flag3 = false;
					}
					if (context == 4 && inv[slot].maxStack <= 1)
					{
						flag3 = false;
					}
					if (flag3 && (Main.mouseItem.IsTheSameAs(inv[slot]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
					{
						if (Main.mouseItem.type == 0)
						{
							Main.mouseItem = inv[slot].Clone();
							Main.mouseItem.stack = 0;
							if (inv[slot].favorited && inv[slot].maxStack == 1)
							{
								Main.mouseItem.favorited = true;
							}
							else
							{
								Main.mouseItem.favorited = false;
							}
						}
						Main.mouseItem.stack++;
						inv[slot].stack--;
						if (inv[slot].stack <= 0)
						{
							inv[slot] = new Item();
						}
						Recipe.FindRecipes();
						Main.soundInstanceMenuTick.Stop();
						Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
						Main.PlaySound(12, -1, -1, 1, 1f, 0f);
						if (Main.stackSplit == 0)
						{
							Main.stackSplit = 15;
						}
						else
						{
							Main.stackSplit = Main.stackDelay;
						}
						if (context == 3 && Main.netMode == 1)
						{
							NetMessage.SendData(32, -1, -1, null, player.chest, (float)slot, 0f, 0f, 0, 0, 0);
						}
					}
				}
			}
		}

		// Token: 0x06000BE3 RID: 3043 RVA: 0x003D4558 File Offset: 0x003D2758
		public static bool Equippable(ref Item inv, int context = 0)
		{
			ItemSlot.singleSlotArray[0] = inv;
			bool arg_1E_0 = ItemSlot.Equippable(ItemSlot.singleSlotArray, context, 0);
			inv = ItemSlot.singleSlotArray[0];
			return arg_1E_0;
		}

		// Token: 0x06000BE4 RID: 3044 RVA: 0x003D4578 File Offset: 0x003D2778
		public static bool Equippable(Item[] inv, int context, int slot)
		{
			Player arg_0B_0 = Main.player[Main.myPlayer];
			return inv[slot].dye > 0 || Main.projHook[inv[slot].shoot] || inv[slot].mountType != -1 || (inv[slot].buffType > 0 && Main.lightPet[inv[slot].buffType]) || (inv[slot].buffType > 0 && Main.vanityPet[inv[slot].buffType]) || inv[slot].headSlot >= 0 || inv[slot].bodySlot >= 0 || inv[slot].legSlot >= 0 || inv[slot].accessory;
		}

		// Token: 0x06000BE5 RID: 3045 RVA: 0x003D461C File Offset: 0x003D281C
		public static void SwapEquip(ref Item inv, int context = 0)
		{
			ItemSlot.singleSlotArray[0] = inv;
			ItemSlot.SwapEquip(ItemSlot.singleSlotArray, context, 0);
			inv = ItemSlot.singleSlotArray[0];
		}

		// Token: 0x06000BE6 RID: 3046 RVA: 0x003D463C File Offset: 0x003D283C
		public static void SwapEquip(Item[] inv, int context, int slot)
		{
			Player player = Main.player[Main.myPlayer];
			if (inv[slot].dye > 0)
			{
				bool flag;
				inv[slot] = ItemSlot.DyeSwap(inv[slot], out flag);
				if (flag)
				{
					Main.EquipPageSelected = 0;
					AchievementsHelper.HandleOnEquip(player, inv[slot], 12);
				}
			}
			else if (Main.projHook[inv[slot].shoot])
			{
				bool flag;
				inv[slot] = ItemSlot.EquipSwap(inv[slot], player.miscEquips, 4, out flag);
				if (flag)
				{
					Main.EquipPageSelected = 2;
					AchievementsHelper.HandleOnEquip(player, inv[slot], 16);
				}
			}
			else if (inv[slot].mountType != -1 && !MountID.Sets.Cart[inv[slot].mountType])
			{
				bool flag;
				inv[slot] = ItemSlot.EquipSwap(inv[slot], player.miscEquips, 3, out flag);
				if (flag)
				{
					Main.EquipPageSelected = 2;
					AchievementsHelper.HandleOnEquip(player, inv[slot], 17);
				}
			}
			else if (inv[slot].mountType != -1 && MountID.Sets.Cart[inv[slot].mountType])
			{
				bool flag;
				inv[slot] = ItemSlot.EquipSwap(inv[slot], player.miscEquips, 2, out flag);
				if (flag)
				{
					Main.EquipPageSelected = 2;
				}
			}
			else if (inv[slot].buffType > 0 && Main.lightPet[inv[slot].buffType])
			{
				bool flag;
				inv[slot] = ItemSlot.EquipSwap(inv[slot], player.miscEquips, 1, out flag);
				if (flag)
				{
					Main.EquipPageSelected = 2;
				}
			}
			else if (inv[slot].buffType > 0 && Main.vanityPet[inv[slot].buffType])
			{
				bool flag;
				inv[slot] = ItemSlot.EquipSwap(inv[slot], player.miscEquips, 0, out flag);
				if (flag)
				{
					Main.EquipPageSelected = 2;
				}
			}
			else
			{
				Item item = inv[slot];
				bool flag;
				inv[slot] = ItemSlot.ArmorSwap(inv[slot], out flag);
				if (flag)
				{
					Main.EquipPageSelected = 0;
					AchievementsHelper.HandleOnEquip(player, item, item.accessory ? 10 : 8);
				}
			}
			Recipe.FindRecipes();
			if (context == 3 && Main.netMode == 1)
			{
				NetMessage.SendData(32, -1, -1, null, player.chest, (float)slot, 0f, 0f, 0, 0, 0);
			}
		}

		// Token: 0x06000BE7 RID: 3047 RVA: 0x003D4828 File Offset: 0x003D2A28
		public static void Draw(SpriteBatch spriteBatch, ref Item inv, int context, Vector2 position, Color lightColor = default(Color))
		{
			ItemSlot.singleSlotArray[0] = inv;
			ItemSlot.Draw(spriteBatch, ItemSlot.singleSlotArray, context, 0, position, lightColor);
			inv = ItemSlot.singleSlotArray[0];
		}

		// Token: 0x06000BE8 RID: 3048 RVA: 0x003D484C File Offset: 0x003D2A4C
		public static void Draw(SpriteBatch spriteBatch, Item[] inv, int context, int slot, Vector2 position, Color lightColor = default(Color))
		{
			Player player = Main.player[Main.myPlayer];
			Item item = inv[slot];
			float inventoryScale = Main.inventoryScale;
			Color color = Color.White;
			if (lightColor != Color.Transparent)
			{
				color = lightColor;
			}
			int num = -1;
			bool flag = false;
			int num2 = 0;
			if (PlayerInput.UsingGamepadUI)
			{
				switch (context)
				{
				case 0:
				case 1:
				case 2:
					num = slot;
					break;
				case 3:
				case 4:
					num = 400 + slot;
					break;
				case 5:
					num = 303;
					break;
				case 6:
					num = 300;
					break;
				case 7:
					num = 1500;
					break;
				case 8:
				case 9:
				case 10:
				case 11:
					num = 100 + slot;
					break;
				case 12:
					if (inv == player.dye)
					{
						num = 120 + slot;
					}
					if (inv == player.miscDyes)
					{
						num = 185 + slot;
					}
					break;
				case 15:
					num = 2700 + slot;
					break;
				case 16:
					num = 184;
					break;
				case 17:
					num = 183;
					break;
				case 18:
					num = 182;
					break;
				case 19:
					num = 180;
					break;
				case 20:
					num = 181;
					break;
				case 22:
					if (UILinkPointNavigator.Shortcuts.CRAFT_CurrentRecipeBig != -1)
					{
						num = 700 + UILinkPointNavigator.Shortcuts.CRAFT_CurrentRecipeBig;
					}
					if (UILinkPointNavigator.Shortcuts.CRAFT_CurrentRecipeSmall != -1)
					{
						num = 1500 + UILinkPointNavigator.Shortcuts.CRAFT_CurrentRecipeSmall + 1;
					}
					break;
				}
				flag = (UILinkPointNavigator.CurrentPoint == num);
				if (context == 0)
				{
					num2 = player.DpadRadial.GetDrawMode(slot);
					if (num2 > 0 && !PlayerInput.CurrentProfile.UsingDpadHotbar())
					{
						num2 = 0;
					}
				}
			}
			Texture2D texture2D = Main.inventoryBackTexture;
			Color color2 = Main.inventoryBack;
			bool flag2 = false;
			if (item.type > 0 && item.stack > 0 && item.favorited && context != 13 && context != 21 && context != 22 && context != 14)
			{
				texture2D = Main.inventoryBack10Texture;
			}
			else if (item.type > 0 && item.stack > 0 && ItemSlot.Options.HighlightNewItems && item.newAndShiny && context != 13 && context != 21 && context != 14 && context != 22)
			{
				texture2D = Main.inventoryBack15Texture;
				float num3 = (float)Main.mouseTextColor / 255f;
				num3 = num3 * 0.2f + 0.8f;
				color2 = color2.MultiplyRGBA(new Color(num3, num3, num3));
			}
			else if (PlayerInput.UsingGamepadUI && item.type > 0 && item.stack > 0 && num2 != 0 && context != 13 && context != 21 && context != 22)
			{
				texture2D = Main.inventoryBack15Texture;
				float num4 = (float)Main.mouseTextColor / 255f;
				num4 = num4 * 0.2f + 0.8f;
				if (num2 == 1)
				{
					color2 = color2.MultiplyRGBA(new Color(num4, num4 / 2f, num4 / 2f));
				}
				else
				{
					color2 = color2.MultiplyRGBA(new Color(num4 / 2f, num4, num4 / 2f));
				}
			}
			else if (context == 0 && slot < 10)
			{
				texture2D = Main.inventoryBack9Texture;
			}
			else if (context == 10 || context == 8 || context == 16 || context == 17 || context == 19 || context == 18 || context == 20)
			{
				texture2D = Main.inventoryBack3Texture;
			}
			else if (context == 11 || context == 9)
			{
				texture2D = Main.inventoryBack8Texture;
			}
			else if (context == 12)
			{
				texture2D = Main.inventoryBack12Texture;
			}
			else if (context == 3)
			{
				texture2D = Main.inventoryBack5Texture;
			}
			else if (context == 4)
			{
				texture2D = Main.inventoryBack2Texture;
			}
			else if (context == 7 || context == 5)
			{
				texture2D = Main.inventoryBack4Texture;
			}
			else if (context == 6)
			{
				texture2D = Main.inventoryBack7Texture;
			}
			else if (context == 13)
			{
				byte b = 200;
				if (slot == Main.player[Main.myPlayer].selectedItem)
				{
					texture2D = Main.inventoryBack14Texture;
					b = 255;
				}
				color2 = new Color((int)b, (int)b, (int)b, (int)b);
			}
			else if (context == 14 || context == 21)
			{
				flag2 = true;
			}
			else if (context == 15)
			{
				texture2D = Main.inventoryBack6Texture;
			}
			else if (context == 22)
			{
				texture2D = Main.inventoryBack4Texture;
			}
			if (context == 0 && ItemSlot.inventoryGlowTime[slot] > 0 && !inv[slot].favorited)
			{
				float scale = Main.invAlpha / 255f;
				Color arg_499_0 = new Color(63, 65, 151, 255) * scale;
				Color value = Main.hslToRgb(ItemSlot.inventoryGlowHue[slot], 1f, 0.5f) * scale;
				float num5 = (float)ItemSlot.inventoryGlowTime[slot] / 300f;
				num5 *= num5;
				color2 = Color.Lerp(arg_499_0, value, num5 / 2f);
				texture2D = Main.inventoryBack13Texture;
			}
			if ((context == 4 || context == 3) && ItemSlot.inventoryGlowTimeChest[slot] > 0 && !inv[slot].favorited)
			{
				float scale2 = Main.invAlpha / 255f;
				Color value2 = new Color(130, 62, 102, 255) * scale2;
				if (context == 3)
				{
					value2 = new Color(104, 52, 52, 255) * scale2;
				}
				Color value3 = Main.hslToRgb(ItemSlot.inventoryGlowHueChest[slot], 1f, 0.5f) * scale2;
				float num6 = (float)ItemSlot.inventoryGlowTimeChest[slot] / 300f;
				num6 *= num6;
				color2 = Color.Lerp(value2, value3, num6 / 2f);
				texture2D = Main.inventoryBack13Texture;
			}
			if (flag)
			{
				texture2D = Main.inventoryBack14Texture;
				color2 = Color.White;
			}
			if (!flag2)
			{
				spriteBatch.Draw(texture2D, position, null, color2, 0f, default(Vector2), inventoryScale, SpriteEffects.None, 0f);
			}
			int num7 = -1;
			switch (context)
			{
			case 8:
				if (slot == 0)
				{
					num7 = 0;
				}
				if (slot == 1)
				{
					num7 = 6;
				}
				if (slot == 2)
				{
					num7 = 12;
				}
				break;
			case 9:
				if (slot == 10)
				{
					num7 = 3;
				}
				if (slot == 11)
				{
					num7 = 9;
				}
				if (slot == 12)
				{
					num7 = 15;
				}
				break;
			case 10:
				num7 = 11;
				break;
			case 11:
				num7 = 2;
				break;
			case 12:
				num7 = 1;
				break;
			case 16:
				num7 = 4;
				break;
			case 17:
				num7 = 13;
				break;
			case 18:
				num7 = 7;
				break;
			case 19:
				num7 = 10;
				break;
			case 20:
				num7 = 17;
				break;
			}
			if ((item.type <= 0 || item.stack <= 0) && num7 != -1)
			{
				Texture2D texture2D2 = Main.extraTexture[54];
				Rectangle rectangle = texture2D2.Frame(3, 6, num7 % 3, num7 / 3);
				rectangle.Width -= 2;
				rectangle.Height -= 2;
				spriteBatch.Draw(texture2D2, position + texture2D.Size() / 2f * inventoryScale, new Rectangle?(rectangle), Color.White * 0.35f, 0f, rectangle.Size() / 2f, inventoryScale, SpriteEffects.None, 0f);
			}
			Vector2 vector = texture2D.Size() * inventoryScale;
			if (item.type > 0 && item.stack > 0)
			{
				Texture2D texture2D3 = Main.itemTexture[item.type];
				Rectangle rectangle2;
				if (Main.itemAnimations[item.type] != null)
				{
					rectangle2 = Main.itemAnimations[item.type].GetFrame(texture2D3);
				}
				else
				{
					rectangle2 = texture2D3.Frame(1, 1, 0, 0);
				}
				Color newColor = color;
				float num8 = 1f;
				ItemSlot.GetItemLight(ref newColor, ref num8, item, false);
				float num9 = 1f;
				if (rectangle2.Width > 32 || rectangle2.Height > 32)
				{
					if (rectangle2.Width > rectangle2.Height)
					{
						num9 = 32f / (float)rectangle2.Width;
					}
					else
					{
						num9 = 32f / (float)rectangle2.Height;
					}
				}
				num9 *= inventoryScale;
				Vector2 position2 = position + vector / 2f - rectangle2.Size() * num9 / 2f;
				Vector2 origin = rectangle2.Size() * (num8 / 2f - 0.5f);
				spriteBatch.Draw(texture2D3, position2, new Rectangle?(rectangle2), item.GetAlpha(newColor), 0f, origin, num9 * num8, SpriteEffects.None, 0f);
				if (item.color != Color.Transparent)
				{
					spriteBatch.Draw(texture2D3, position2, new Rectangle?(rectangle2), item.GetColor(color), 0f, origin, num9 * num8, SpriteEffects.None, 0f);
				}
				if (ItemID.Sets.TrapSigned[item.type])
				{
					spriteBatch.Draw(Main.wireTexture, position + new Vector2(40f, 40f) * inventoryScale, new Rectangle?(new Rectangle(4, 58, 8, 8)), color, 0f, new Vector2(4f), 1f, SpriteEffects.None, 0f);
				}
				if (item.stack > 1)
				{
					ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, item.stack.ToString(), position + new Vector2(10f, 26f) * inventoryScale, color, 0f, Vector2.Zero, new Vector2(inventoryScale), -1f, inventoryScale);
				}
				int num10 = -1;
				if (context == 13)
				{
					if (item.DD2Summon)
					{
						for (int i = 0; i < 58; i++)
						{
							if (inv[i].type == 3822)
							{
								num10 += inv[i].stack;
							}
						}
						if (num10 >= 0)
						{
							num10++;
						}
					}
					if (item.useAmmo > 0)
					{
						int useAmmo = item.useAmmo;
						num10 = 0;
						for (int j = 0; j < 58; j++)
						{
							if (inv[j].ammo == useAmmo)
							{
								num10 += inv[j].stack;
							}
						}
					}
					if (item.fishingPole > 0)
					{
						num10 = 0;
						for (int k = 0; k < 58; k++)
						{
							if (inv[k].bait > 0)
							{
								num10 += inv[k].stack;
							}
						}
					}
					if (item.tileWand > 0)
					{
						int tileWand = item.tileWand;
						num10 = 0;
						for (int l = 0; l < 58; l++)
						{
							if (inv[l].type == tileWand)
							{
								num10 += inv[l].stack;
							}
						}
					}
					if (item.type == 509 || item.type == 851 || item.type == 850 || item.type == 3612 || item.type == 3625 || item.type == 3611)
					{
						num10 = 0;
						for (int m = 0; m < 58; m++)
						{
							if (inv[m].type == 530)
							{
								num10 += inv[m].stack;
							}
						}
					}
				}
				if (num10 != -1)
				{
					ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, num10.ToString(), position + new Vector2(8f, 30f) * inventoryScale, color, 0f, Vector2.Zero, new Vector2(inventoryScale * 0.8f), -1f, inventoryScale);
				}
				if (context == 13)
				{
					string text = string.Concat(slot + 1);
					if (text == "10")
					{
						text = "0";
					}
					ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, text, position + new Vector2(8f, 4f) * inventoryScale, color, 0f, Vector2.Zero, new Vector2(inventoryScale), -1f, inventoryScale);
				}
				if (context == 13 && item.potion)
				{
					Vector2 position3 = position + texture2D.Size() * inventoryScale / 2f - Main.cdTexture.Size() * inventoryScale / 2f;
					Color color3 = item.GetAlpha(color) * ((float)player.potionDelay / (float)player.potionDelayTime);
					spriteBatch.Draw(Main.cdTexture, position3, null, color3, 0f, default(Vector2), num9, SpriteEffects.None, 0f);
				}
				if ((context == 10 || context == 18) && item.expertOnly && !Main.expertMode)
				{
					Vector2 position4 = position + texture2D.Size() * inventoryScale / 2f - Main.cdTexture.Size() * inventoryScale / 2f;
					Color white = Color.White;
					spriteBatch.Draw(Main.cdTexture, position4, null, white, 0f, default(Vector2), num9, SpriteEffects.None, 0f);
				}
			}
			else if (context == 6)
			{
				Texture2D trashTexture = Main.trashTexture;
				Vector2 position5 = position + texture2D.Size() * inventoryScale / 2f - trashTexture.Size() * inventoryScale / 2f;
				spriteBatch.Draw(trashTexture, position5, null, new Color(100, 100, 100, 100), 0f, default(Vector2), inventoryScale, SpriteEffects.None, 0f);
			}
			if (context == 0 && slot < 10)
			{
				float num11 = inventoryScale;
				string text2 = string.Concat(slot + 1);
				if (text2 == "10")
				{
					text2 = "0";
				}
				Color inventoryBack = Main.inventoryBack;
				int num12 = 0;
				if (Main.player[Main.myPlayer].selectedItem == slot)
				{
					num12 -= 3;
					inventoryBack.R = 255;
					inventoryBack.B = 0;
					inventoryBack.G = 210;
					inventoryBack.A = 100;
					num11 *= 1.4f;
				}
				ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, text2, position + new Vector2(6f, (float)(4 + num12)) * inventoryScale, inventoryBack, 0f, Vector2.Zero, new Vector2(inventoryScale), -1f, inventoryScale);
			}
			if (num != -1)
			{
				UILinkPointNavigator.SetPosition(num, position + vector * 0.75f);
			}
		}

		// Token: 0x06000BE9 RID: 3049 RVA: 0x003D5660 File Offset: 0x003D3860
		public static void MouseHover(ref Item inv, int context = 0)
		{
			ItemSlot.singleSlotArray[0] = inv;
			ItemSlot.MouseHover(ItemSlot.singleSlotArray, context, 0);
			inv = ItemSlot.singleSlotArray[0];
		}

		// Token: 0x06000BEA RID: 3050 RVA: 0x003D5680 File Offset: 0x003D3880
		public static void MouseHover(Item[] inv, int context = 0, int slot = 0)
		{
			if (context == 6 && Main.hoverItemName == null)
			{
				Main.hoverItemName = Lang.inter[3].Value;
			}
			if (inv[slot].type > 0 && inv[slot].stack > 0)
			{
				ItemSlot._customCurrencyForSavings = inv[slot].shopSpecialCurrency;
				Main.hoverItemName = inv[slot].Name;
				if (inv[slot].stack > 1)
				{
					Main.hoverItemName = string.Concat(new object[]
					{
						Main.hoverItemName,
						" (",
						inv[slot].stack,
						")"
					});
				}
				Main.HoverItem = inv[slot].Clone();
				if (context == 8 && slot <= 2)
				{
					Main.HoverItem.wornArmor = true;
				}
				if (context == 11 || context == 9)
				{
					Main.HoverItem.social = true;
				}
				if (context == 15)
				{
					Main.HoverItem.buy = true;
					return;
				}
			}
			else
			{
				if (context == 10 || context == 11)
				{
					Main.hoverItemName = Lang.inter[9].Value;
				}
				if (context == 11)
				{
					Main.hoverItemName = Lang.inter[11].Value + " " + Main.hoverItemName;
				}
				if (context == 8 || context == 9)
				{
					if (slot == 0 || slot == 10)
					{
						Main.hoverItemName = Lang.inter[12].Value;
					}
					if (slot == 1 || slot == 11)
					{
						Main.hoverItemName = Lang.inter[13].Value;
					}
					if (slot == 2 || slot == 12)
					{
						Main.hoverItemName = Lang.inter[14].Value;
					}
					if (slot >= 10)
					{
						Main.hoverItemName = Lang.inter[11].Value + " " + Main.hoverItemName;
					}
				}
				if (context == 12)
				{
					Main.hoverItemName = Lang.inter[57].Value;
				}
				if (context == 16)
				{
					Main.hoverItemName = Lang.inter[90].Value;
				}
				if (context == 17)
				{
					Main.hoverItemName = Lang.inter[91].Value;
				}
				if (context == 19)
				{
					Main.hoverItemName = Lang.inter[92].Value;
				}
				if (context == 18)
				{
					Main.hoverItemName = Lang.inter[93].Value;
				}
				if (context == 20)
				{
					Main.hoverItemName = Lang.inter[94].Value;
				}
			}
		}

		// Token: 0x06000BEB RID: 3051 RVA: 0x003D58B8 File Offset: 0x003D3AB8
		private static bool AccCheck(Item item, int slot)
		{
			Player player = Main.player[Main.myPlayer];
			if (slot != -1)
			{
				if (player.armor[slot].IsTheSameAs(item))
				{
					return false;
				}
				if (player.armor[slot].wingSlot > 0 && item.wingSlot > 0)
				{
					return false;
				}
			}
			for (int i = 0; i < player.armor.Length; i++)
			{
				if (slot < 10 && i < 10)
				{
					if (item.wingSlot > 0 && player.armor[i].wingSlot > 0)
					{
						return true;
					}
					if (slot >= 10 && i >= 10 && item.wingSlot > 0 && player.armor[i].wingSlot > 0)
					{
						return true;
					}
				}
				if (item.IsTheSameAs(player.armor[i]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x003D5974 File Offset: 0x003D3B74
		private static Item DyeSwap(Item item, out bool success)
		{
			success = false;
			if (item.dye <= 0)
			{
				return item;
			}
			Player player = Main.player[Main.myPlayer];
			for (int i = 0; i < 10; i++)
			{
				if (player.dye[i].type == 0)
				{
					ItemSlot.dyeSlotCount = i;
					break;
				}
			}
			if (ItemSlot.dyeSlotCount >= 10)
			{
				ItemSlot.dyeSlotCount = 0;
			}
			if (ItemSlot.dyeSlotCount < 0)
			{
				ItemSlot.dyeSlotCount = 9;
			}
			Item result = player.dye[ItemSlot.dyeSlotCount].Clone();
			player.dye[ItemSlot.dyeSlotCount] = item.Clone();
			ItemSlot.dyeSlotCount++;
			if (ItemSlot.dyeSlotCount >= 10)
			{
				ItemSlot.accSlotCount = 0;
			}
			Main.PlaySound(7, -1, -1, 1, 1f, 0f);
			Recipe.FindRecipes();
			success = true;
			return result;
		}

		// Token: 0x06000BED RID: 3053 RVA: 0x003D5A3C File Offset: 0x003D3C3C
		private static Item ArmorSwap(Item item, out bool success)
		{
			success = false;
			if (item.headSlot == -1 && item.bodySlot == -1 && item.legSlot == -1 && !item.accessory)
			{
				return item;
			}
			Player player = Main.player[Main.myPlayer];
			int num = (item.vanity && !item.accessory) ? 10 : 0;
			item.favorited = false;
			Item result = item;
			if (item.headSlot != -1)
			{
				result = player.armor[num].Clone();
				player.armor[num] = item.Clone();
			}
			else if (item.bodySlot != -1)
			{
				result = player.armor[num + 1].Clone();
				player.armor[num + 1] = item.Clone();
			}
			else if (item.legSlot != -1)
			{
				result = player.armor[num + 2].Clone();
				player.armor[num + 2] = item.Clone();
			}
			else if (item.accessory)
			{
				int num2 = 5 + Main.player[Main.myPlayer].extraAccessorySlots;
				for (int i = 3; i < 3 + num2; i++)
				{
					if (player.armor[i].type == 0)
					{
						ItemSlot.accSlotCount = i - 3;
						break;
					}
				}
				for (int j = 0; j < player.armor.Length; j++)
				{
					if (item.IsTheSameAs(player.armor[j]))
					{
						ItemSlot.accSlotCount = j - 3;
					}
					if (j < 10 && item.wingSlot > 0 && player.armor[j].wingSlot > 0)
					{
						ItemSlot.accSlotCount = j - 3;
					}
				}
				if (ItemSlot.accSlotCount >= num2)
				{
					ItemSlot.accSlotCount = 0;
				}
				if (ItemSlot.accSlotCount < 0)
				{
					ItemSlot.accSlotCount = num2 - 1;
				}
				int num3 = 3 + ItemSlot.accSlotCount;
				for (int k = 0; k < player.armor.Length; k++)
				{
					if (item.IsTheSameAs(player.armor[k]))
					{
						num3 = k;
					}
				}
				result = player.armor[num3].Clone();
				player.armor[num3] = item.Clone();
				ItemSlot.accSlotCount++;
				if (ItemSlot.accSlotCount >= num2)
				{
					ItemSlot.accSlotCount = 0;
				}
			}
			Main.PlaySound(7, -1, -1, 1, 1f, 0f);
			Recipe.FindRecipes();
			success = true;
			return result;
		}

		// Token: 0x06000BEE RID: 3054 RVA: 0x003D5C70 File Offset: 0x003D3E70
		private static Item EquipSwap(Item item, Item[] inv, int slot, out bool success)
		{
			success = false;
			Player arg_0E_0 = Main.player[Main.myPlayer];
			item.favorited = false;
			Item arg_43_0 = inv[slot].Clone();
			inv[slot] = item.Clone();
			Main.PlaySound(7, -1, -1, 1, 1f, 0f);
			Recipe.FindRecipes();
			success = true;
			return arg_43_0;
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x003D5CC0 File Offset: 0x003D3EC0
		public static void EquipPage(Item item)
		{
			Main.EquipPage = -1;
			if (Main.projHook[item.shoot])
			{
				Main.EquipPage = 2;
				return;
			}
			if (item.mountType != -1)
			{
				Main.EquipPage = 2;
				return;
			}
			if (item.buffType > 0 && Main.vanityPet[item.buffType])
			{
				Main.EquipPage = 2;
				return;
			}
			if (item.buffType > 0 && Main.lightPet[item.buffType])
			{
				Main.EquipPage = 2;
				return;
			}
			if (item.dye > 0 && Main.EquipPageSelected == 1)
			{
				Main.EquipPage = 0;
				return;
			}
			if (item.legSlot != -1 || item.headSlot != -1 || item.bodySlot != -1 || item.accessory)
			{
				Main.EquipPage = 0;
			}
		}

		// Token: 0x06000BF0 RID: 3056 RVA: 0x003D5D78 File Offset: 0x003D3F78
		public static void DrawMoney(SpriteBatch sb, string text, float shopx, float shopy, int[] coinsArray, bool horizontal = false)
		{
			Utils.DrawBorderStringFourWay(sb, Main.fontMouseText, text, shopx, shopy + 40f, Color.White * ((float)Main.mouseTextColor / 255f), Color.Black, Vector2.Zero, 1f);
			if (horizontal)
			{
				for (int i = 0; i < 4; i++)
				{
					if (i == 0)
					{
						int arg_53_0 = coinsArray[3 - i];
					}
					Vector2 vector = new Vector2(shopx + ChatManager.GetStringSize(Main.fontMouseText, text, Vector2.One, -1f).X + (float)(24 * i) + 45f, shopy + 50f);
					sb.Draw(Main.itemTexture[74 - i], vector, null, Color.White, 0f, Main.itemTexture[74 - i].Size() / 2f, 1f, SpriteEffects.None, 0f);
					Utils.DrawBorderStringFourWay(sb, Main.fontItemStack, coinsArray[3 - i].ToString(), vector.X - 11f, vector.Y, Color.White, Color.Black, new Vector2(0.3f), 0.75f);
				}
				return;
			}
			for (int j = 0; j < 4; j++)
			{
				int num = (j == 0 && coinsArray[3 - j] > 99) ? -6 : 0;
				sb.Draw(Main.itemTexture[74 - j], new Vector2(shopx + 11f + (float)(24 * j), shopy + 75f), null, Color.White, 0f, Main.itemTexture[74 - j].Size() / 2f, 1f, SpriteEffects.None, 0f);
				Utils.DrawBorderStringFourWay(sb, Main.fontItemStack, coinsArray[3 - j].ToString(), shopx + (float)(24 * j) + (float)num, shopy + 75f, Color.White, Color.Black, new Vector2(0.3f), 0.75f);
			}
		}

		// Token: 0x06000BF1 RID: 3057 RVA: 0x003D5F74 File Offset: 0x003D4174
		public static void DrawSavings(SpriteBatch sb, float shopx, float shopy, bool horizontal = false)
		{
			Player player = Main.player[Main.myPlayer];
			if (ItemSlot._customCurrencyForSavings != -1)
			{
				CustomCurrencyManager.DrawSavings(sb, ItemSlot._customCurrencyForSavings, shopx, shopy, horizontal);
				return;
			}
			bool flag;
			long num = Utils.CoinsCount(out flag, player.bank.item, new int[0]);
			long num2 = Utils.CoinsCount(out flag, player.bank2.item, new int[0]);
			long num3 = Utils.CoinsCount(out flag, player.bank3.item, new int[0]);
			long num4 = Utils.CoinsCombineStacks(out flag, new long[]
			{
				num,
				num2,
				num3
			});
			if (num4 > 0L)
			{
				if (num3 > 0L)
				{
					sb.Draw(Main.itemTexture[3813], Utils.CenteredRectangle(new Vector2(shopx + 92f, shopy + 45f), Main.itemTexture[3813].Size() * 0.65f), null, Color.White);
				}
				if (num2 > 0L)
				{
					sb.Draw(Main.itemTexture[346], Utils.CenteredRectangle(new Vector2(shopx + 80f, shopy + 50f), Main.itemTexture[346].Size() * 0.65f), null, Color.White);
				}
				if (num > 0L)
				{
					sb.Draw(Main.itemTexture[87], Utils.CenteredRectangle(new Vector2(shopx + 70f, shopy + 60f), Main.itemTexture[87].Size() * 0.65f), null, Color.White);
				}
				ItemSlot.DrawMoney(sb, Lang.inter[66].Value, shopx, shopy, Utils.CoinsSplit(num4), horizontal);
			}
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x003D6134 File Offset: 0x003D4334
		public static void DrawRadialDpad(SpriteBatch sb, Vector2 position)
		{
			if (!PlayerInput.UsingGamepad || !PlayerInput.CurrentProfile.UsingDpadHotbar())
			{
				return;
			}
			Player player = Main.player[Main.myPlayer];
			if (player.chest != -1)
			{
				return;
			}
			Texture2D texture2D = Main.hotbarRadialTexture[0];
			float num = (float)Main.mouseTextColor / 255f;
			float num2 = 1f - (1f - num) * (1f - num);
			num2 *= 0.785f;
			Color color = Color.White * num2;
			sb.Draw(texture2D, position, null, color, 0f, texture2D.Size() / 2f, Main.inventoryScale, SpriteEffects.None, 0f);
			for (int i = 0; i < 4; i++)
			{
				int num3 = player.DpadRadial.Bindings[i];
				if (num3 != -1)
				{
					ItemSlot.Draw(sb, player.inventory, 14, num3, position + new Vector2((float)(texture2D.Width / 3), 0f).RotatedBy((double)(-1.57079637f + 1.57079637f * (float)i), default(Vector2)) + new Vector2(-26f * Main.inventoryScale), Color.White);
				}
			}
		}

		// Token: 0x06000BF3 RID: 3059 RVA: 0x003D626C File Offset: 0x003D446C
		public static void DrawRadialCircular(SpriteBatch sb, Vector2 position)
		{
			ItemSlot.CircularRadialOpacity = MathHelper.Clamp(ItemSlot.CircularRadialOpacity + ((PlayerInput.UsingGamepad && PlayerInput.Triggers.Current.RadialHotbar) ? 0.25f : -0.15f), 0f, 1f);
			if (ItemSlot.CircularRadialOpacity == 0f)
			{
				return;
			}
			Player player = Main.player[Main.myPlayer];
			Texture2D texture2D = Main.hotbarRadialTexture[2];
			float scale = ItemSlot.CircularRadialOpacity * 0.9f;
			float num = ItemSlot.CircularRadialOpacity * 1f;
			float num2 = (float)Main.mouseTextColor / 255f;
			float num3 = 1f - (1f - num2) * (1f - num2);
			num3 *= 0.785f;
			Color value = Color.White * num3 * scale;
			texture2D = Main.hotbarRadialTexture[1];
			float num4 = 6.28318548f / (float)player.CircularRadial.RadialCount;
			float num5 = -1.57079637f;
			for (int i = 0; i < player.CircularRadial.RadialCount; i++)
			{
				int num6 = player.CircularRadial.Bindings[i];
				Vector2 value2 = new Vector2(150f, 0f).RotatedBy((double)(num5 + num4 * (float)i), default(Vector2)) * num;
				float num7 = 0.85f;
				if (player.CircularRadial.SelectedBinding == i)
				{
					num7 = 1.7f;
				}
				sb.Draw(texture2D, position + value2, null, value * num7, 0f, texture2D.Size() / 2f, num * num7, SpriteEffects.None, 0f);
				if (num6 != -1)
				{
					float arg_1C9_0 = Main.inventoryScale;
					Main.inventoryScale = num * num7;
					ItemSlot.Draw(sb, player.inventory, 14, num6, position + value2 + new Vector2(-26f * num * num7), Color.White);
					Main.inventoryScale = arg_1C9_0;
				}
			}
		}

		// Token: 0x06000BF4 RID: 3060 RVA: 0x003D6460 File Offset: 0x003D4660
		public static void DrawRadialQuicks(SpriteBatch sb, Vector2 position)
		{
			ItemSlot.QuicksRadialOpacity = MathHelper.Clamp(ItemSlot.QuicksRadialOpacity + ((PlayerInput.UsingGamepad && PlayerInput.Triggers.Current.RadialQuickbar) ? 0.25f : -0.15f), 0f, 1f);
			if (ItemSlot.QuicksRadialOpacity == 0f)
			{
				return;
			}
			Player player = Main.player[Main.myPlayer];
			Texture2D texture2D = Main.hotbarRadialTexture[2];
			Texture2D quicksIconTexture = Main.quicksIconTexture;
			float scale = ItemSlot.QuicksRadialOpacity * 0.9f;
			float num = ItemSlot.QuicksRadialOpacity * 1f;
			float num2 = (float)Main.mouseTextColor / 255f;
			float num3 = 1f - (1f - num2) * (1f - num2);
			num3 *= 0.785f;
			Color value = Color.White * num3 * scale;
			float num4 = 6.28318548f / (float)player.QuicksRadial.RadialCount;
			float num5 = -1.57079637f;
			Item item = player.QuickHeal_GetItemToUse();
			Item item2 = player.QuickMana_GetItemToUse();
			Item item3 = null;
			if (item == null)
			{
				item = new Item();
				item.SetDefaults(28, false);
			}
			if (item2 == null)
			{
				item2 = new Item();
				item2.SetDefaults(110, false);
			}
			if (item3 == null)
			{
				item3 = new Item();
				item3.SetDefaults(292, false);
			}
			for (int i = 0; i < player.QuicksRadial.RadialCount; i++)
			{
				Item item4 = item;
				if (i == 1)
				{
					item4 = item3;
				}
				if (i == 2)
				{
					item4 = item2;
				}
				int arg_15F_0 = player.QuicksRadial.Bindings[i];
				Vector2 value2 = new Vector2(120f, 0f).RotatedBy((double)(num5 + num4 * (float)i), default(Vector2)) * num;
				float num6 = 0.85f;
				if (player.QuicksRadial.SelectedBinding == i)
				{
					num6 = 1.7f;
				}
				sb.Draw(texture2D, position + value2, null, value * num6, 0f, texture2D.Size() / 2f, num * num6 * 1.3f, SpriteEffects.None, 0f);
				float arg_231_0 = Main.inventoryScale;
				Main.inventoryScale = num * num6;
				ItemSlot.Draw(sb, ref item4, 14, position + value2 + new Vector2(-26f * num * num6), Color.White);
				Main.inventoryScale = arg_231_0;
				sb.Draw(quicksIconTexture, position + value2 + new Vector2(34f, 20f) * 0.85f * num * num6, null, value * num6, 0f, texture2D.Size() / 2f, num * num6 * 1.3f, SpriteEffects.None, 0f);
			}
		}

		// Token: 0x06000BF5 RID: 3061 RVA: 0x003D6730 File Offset: 0x003D4930
		public static void GetItemLight(ref Color currentColor, Item item, bool outInTheWorld = false)
		{
			float num = 1f;
			ItemSlot.GetItemLight(ref currentColor, ref num, item, outInTheWorld);
		}

		// Token: 0x06000BF6 RID: 3062 RVA: 0x003D6750 File Offset: 0x003D4950
		public static void GetItemLight(ref Color currentColor, int type, bool outInTheWorld = false)
		{
			float num = 1f;
			ItemSlot.GetItemLight(ref currentColor, ref num, type, outInTheWorld);
		}

		// Token: 0x06000BF7 RID: 3063 RVA: 0x003D6770 File Offset: 0x003D4970
		public static void GetItemLight(ref Color currentColor, ref float scale, Item item, bool outInTheWorld = false)
		{
			ItemSlot.GetItemLight(ref currentColor, ref scale, item.type, outInTheWorld);
		}

		// Token: 0x06000BF8 RID: 3064 RVA: 0x003D6784 File Offset: 0x003D4984
		public static Color GetItemLight(ref Color currentColor, ref float scale, int type, bool outInTheWorld = false)
		{
			if (type < 0 || type > 3930)
			{
				return currentColor;
			}
			if (type == 662 || type == 663)
			{
				currentColor.R = (byte)Main.DiscoR;
				currentColor.G = (byte)Main.DiscoG;
				currentColor.B = (byte)Main.DiscoB;
				currentColor.A = 255;
			}
			else if (ItemID.Sets.ItemIconPulse[type])
			{
				scale = Main.essScale;
				currentColor.R = (byte)((float)currentColor.R * scale);
				currentColor.G = (byte)((float)currentColor.G * scale);
				currentColor.B = (byte)((float)currentColor.B * scale);
				currentColor.A = (byte)((float)currentColor.A * scale);
			}
			else if (type == 58 || type == 184)
			{
				scale = Main.essScale * 0.25f + 0.75f;
				currentColor.R = (byte)((float)currentColor.R * scale);
				currentColor.G = (byte)((float)currentColor.G * scale);
				currentColor.B = (byte)((float)currentColor.B * scale);
				currentColor.A = (byte)((float)currentColor.A * scale);
			}
			return currentColor;
		}

		// Token: 0x06000BF9 RID: 3065 RVA: 0x003D68A8 File Offset: 0x003D4AA8
		public static string GetGamepadInstructions(ref Item inv, int context = 0)
		{
			ItemSlot.singleSlotArray[0] = inv;
			string arg_1E_0 = ItemSlot.GetGamepadInstructions(ItemSlot.singleSlotArray, context, 0);
			inv = ItemSlot.singleSlotArray[0];
			return arg_1E_0;
		}

		// Token: 0x06000BFA RID: 3066 RVA: 0x003D68C8 File Offset: 0x003D4AC8
		public static string GetGamepadInstructions(Item[] inv, int context = 0, int slot = 0)
		{
			Player player = Main.player[Main.myPlayer];
			string text = "";
			if (inv == null || inv[slot] == null || Main.mouseItem == null)
			{
				return text;
			}
			if (context == 0 || context == 1 || context == 2)
			{
				if (inv[slot].type > 0 && inv[slot].stack > 0)
				{
					if (Main.mouseItem.type > 0)
					{
						text += PlayerInput.BuildCommand(Lang.misc[65].Value, false, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
						});
						if (inv[slot].type == Main.mouseItem.type && Main.mouseItem.stack < inv[slot].maxStack && inv[slot].maxStack > 1)
						{
							text += PlayerInput.BuildCommand(Lang.misc[55].Value, false, new List<string>[]
							{
								PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]
							});
						}
					}
					else
					{
						if (context == 0 && player.chest == -1)
						{
							player.DpadRadial.ChangeBinding(slot);
						}
						text += PlayerInput.BuildCommand(Lang.misc[54].Value, false, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
						});
						if (inv[slot].maxStack > 1)
						{
							text += PlayerInput.BuildCommand(Lang.misc[55].Value, false, new List<string>[]
							{
								PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]
							});
						}
					}
					if (inv[slot].maxStack == 1 && ItemSlot.Equippable(inv, context, slot))
					{
						text += PlayerInput.BuildCommand(Lang.misc[67].Value, false, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]
						});
						if (PlayerInput.Triggers.JustPressed.Grapple)
						{
							ItemSlot.SwapEquip(inv, context, slot);
						}
					}
					text += PlayerInput.BuildCommand(Lang.misc[83].Value, false, new List<string>[]
					{
						PlayerInput.ProfileGamepadUI.KeyStatus["SmartCursor"]
					});
					if (PlayerInput.Triggers.JustPressed.SmartCursor)
					{
						inv[slot].favorited = !inv[slot].favorited;
					}
				}
				else if (Main.mouseItem.type > 0)
				{
					text += PlayerInput.BuildCommand(Lang.misc[65].Value, false, new List<string>[]
					{
						PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
					});
				}
			}
			if (context == 3 || context == 4)
			{
				if (inv[slot].type > 0 && inv[slot].stack > 0)
				{
					if (Main.mouseItem.type > 0)
					{
						text += PlayerInput.BuildCommand(Lang.misc[65].Value, false, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
						});
						if (inv[slot].type == Main.mouseItem.type && Main.mouseItem.stack < inv[slot].maxStack && inv[slot].maxStack > 1)
						{
							text += PlayerInput.BuildCommand(Lang.misc[55].Value, false, new List<string>[]
							{
								PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]
							});
						}
					}
					else
					{
						text += PlayerInput.BuildCommand(Lang.misc[54].Value, false, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
						});
						if (inv[slot].maxStack > 1)
						{
							text += PlayerInput.BuildCommand(Lang.misc[55].Value, false, new List<string>[]
							{
								PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]
							});
						}
					}
					if (inv[slot].maxStack == 1 && ItemSlot.Equippable(inv, context, slot))
					{
						text += PlayerInput.BuildCommand(Lang.misc[67].Value, false, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]
						});
						if (PlayerInput.Triggers.JustPressed.Grapple)
						{
							ItemSlot.SwapEquip(inv, context, slot);
						}
					}
				}
				else if (Main.mouseItem.type > 0)
				{
					text += PlayerInput.BuildCommand(Lang.misc[65].Value, false, new List<string>[]
					{
						PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
					});
				}
			}
			if (context == 15)
			{
				if (inv[slot].type > 0 && inv[slot].stack > 0)
				{
					if (Main.mouseItem.type > 0)
					{
						if (inv[slot].type == Main.mouseItem.type && Main.mouseItem.stack < inv[slot].maxStack && inv[slot].maxStack > 1)
						{
							text += PlayerInput.BuildCommand(Lang.misc[91].Value, false, new List<string>[]
							{
								PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]
							});
						}
					}
					else
					{
						text += PlayerInput.BuildCommand(Lang.misc[90].Value, false, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"],
							PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]
						});
					}
				}
				else if (Main.mouseItem.type > 0)
				{
					text += PlayerInput.BuildCommand(Lang.misc[92].Value, false, new List<string>[]
					{
						PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
					});
				}
			}
			if (context == 8 || context == 9 || context == 16 || context == 17 || context == 18 || context == 19 || context == 20)
			{
				if (inv[slot].type > 0 && inv[slot].stack > 0)
				{
					if (Main.mouseItem.type > 0)
					{
						if (ItemSlot.Equippable(ref Main.mouseItem, context))
						{
							text += PlayerInput.BuildCommand(Lang.misc[65].Value, false, new List<string>[]
							{
								PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
							});
						}
					}
					else
					{
						text += PlayerInput.BuildCommand(Lang.misc[54].Value, false, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
						});
					}
					if (context == 8 && slot >= 3)
					{
						bool flag = player.hideVisual[slot];
						text += PlayerInput.BuildCommand(Lang.misc[flag ? 77 : 78].Value, false, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]
						});
						if (PlayerInput.Triggers.JustPressed.Grapple)
						{
							player.hideVisual[slot] = !player.hideVisual[slot];
							Main.PlaySound(12, -1, -1, 1, 1f, 0f);
							if (Main.netMode == 1)
							{
								NetMessage.SendData(4, -1, -1, null, Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
							}
						}
					}
					if ((context == 16 || context == 17 || context == 18 || context == 19 || context == 20) && slot < 2)
					{
						bool flag2 = player.hideMisc[slot];
						text += PlayerInput.BuildCommand(Lang.misc[flag2 ? 77 : 78].Value, false, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]
						});
						if (PlayerInput.Triggers.JustPressed.Grapple)
						{
							player.hideMisc[slot] = !player.hideMisc[slot];
							Main.PlaySound(12, -1, -1, 1, 1f, 0f);
							if (Main.netMode == 1)
							{
								NetMessage.SendData(4, -1, -1, null, Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
							}
						}
					}
				}
				else
				{
					if (Main.mouseItem.type > 0 && ItemSlot.Equippable(ref Main.mouseItem, context))
					{
						text += PlayerInput.BuildCommand(Lang.misc[65].Value, false, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
						});
					}
					if (context == 8 && slot >= 3)
					{
						bool flag3 = player.hideVisual[slot];
						text += PlayerInput.BuildCommand(Lang.misc[flag3 ? 77 : 78].Value, false, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]
						});
						if (PlayerInput.Triggers.JustPressed.Grapple)
						{
							player.hideVisual[slot] = !player.hideVisual[slot];
							Main.PlaySound(12, -1, -1, 1, 1f, 0f);
							if (Main.netMode == 1)
							{
								NetMessage.SendData(4, -1, -1, null, Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
							}
						}
					}
					if ((context == 16 || context == 17 || context == 18 || context == 19 || context == 20) && slot < 2)
					{
						bool flag4 = player.hideMisc[slot];
						text += PlayerInput.BuildCommand(Lang.misc[flag4 ? 77 : 78].Value, false, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]
						});
						if (PlayerInput.Triggers.JustPressed.Grapple)
						{
							if (slot == 0)
							{
								player.TogglePet();
							}
							if (slot == 1)
							{
								player.ToggleLight();
							}
							Main.mouseLeftRelease = false;
							Main.PlaySound(12, -1, -1, 1, 1f, 0f);
							if (Main.netMode == 1)
							{
								NetMessage.SendData(4, -1, -1, null, Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
							}
						}
					}
				}
			}
			if (context == 12)
			{
				if (inv[slot].type > 0 && inv[slot].stack > 0)
				{
					if (Main.mouseItem.type > 0)
					{
						if (Main.mouseItem.dye > 0)
						{
							text += PlayerInput.BuildCommand(Lang.misc[65].Value, false, new List<string>[]
							{
								PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
							});
						}
					}
					else
					{
						text += PlayerInput.BuildCommand(Lang.misc[54].Value, false, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
						});
					}
					if (context == 12)
					{
						int num = -1;
						if (inv == player.dye)
						{
							num = slot;
						}
						if (inv == player.miscDyes)
						{
							num = 10 + slot;
						}
						if (num != -1)
						{
							if (num < 10)
							{
								bool flag5 = player.hideVisual[slot];
								text += PlayerInput.BuildCommand(Lang.misc[flag5 ? 77 : 78].Value, false, new List<string>[]
								{
									PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]
								});
								if (PlayerInput.Triggers.JustPressed.Grapple)
								{
									player.hideVisual[slot] = !player.hideVisual[slot];
									Main.PlaySound(12, -1, -1, 1, 1f, 0f);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(4, -1, -1, null, Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
									}
								}
							}
							else
							{
								bool flag6 = player.hideMisc[slot];
								text += PlayerInput.BuildCommand(Lang.misc[flag6 ? 77 : 78].Value, false, new List<string>[]
								{
									PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]
								});
								if (PlayerInput.Triggers.JustPressed.Grapple)
								{
									player.hideMisc[slot] = !player.hideMisc[slot];
									Main.PlaySound(12, -1, -1, 1, 1f, 0f);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(4, -1, -1, null, Main.myPlayer, 0f, 0f, 0f, 0, 0, 0);
									}
								}
							}
						}
					}
				}
				else if (Main.mouseItem.type > 0 && Main.mouseItem.dye > 0)
				{
					text += PlayerInput.BuildCommand(Lang.misc[65].Value, false, new List<string>[]
					{
						PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
					});
				}
				return text;
			}
			if (context == 6)
			{
				if (inv[slot].type > 0 && inv[slot].stack > 0)
				{
					if (Main.mouseItem.type > 0)
					{
						text += PlayerInput.BuildCommand(Lang.misc[74].Value, false, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
						});
					}
					else
					{
						text += PlayerInput.BuildCommand(Lang.misc[54].Value, false, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
						});
					}
				}
				else if (Main.mouseItem.type > 0)
				{
					text += PlayerInput.BuildCommand(Lang.misc[74].Value, false, new List<string>[]
					{
						PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
					});
				}
				return text;
			}
			if (context == 5 || context == 7)
			{
				bool flag7 = false;
				if (context == 5)
				{
					flag7 = (Main.mouseItem.Prefix(-3) || Main.mouseItem.type == 0);
				}
				if (context == 7)
				{
					flag7 = Main.mouseItem.material;
				}
				if (inv[slot].type > 0 && inv[slot].stack > 0)
				{
					if (Main.mouseItem.type > 0)
					{
						if (flag7)
						{
							text += PlayerInput.BuildCommand(Lang.misc[65].Value, false, new List<string>[]
							{
								PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
							});
						}
					}
					else
					{
						text += PlayerInput.BuildCommand(Lang.misc[54].Value, false, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
						});
					}
				}
				else if (Main.mouseItem.type > 0 & flag7)
				{
					text += PlayerInput.BuildCommand(Lang.misc[65].Value, false, new List<string>[]
					{
						PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]
					});
				}
				return text;
			}
			string overrideInstructions = ItemSlot.GetOverrideInstructions(inv, context, slot);
			if (Main.mouseItem.type > 0 && (context == 0 || context == 1 || context == 2 || context == 6 || context == 15 || context == 7) && string.IsNullOrEmpty(overrideInstructions))
			{
				text += PlayerInput.BuildCommand(Lang.inter[121].Value, false, new List<string>[]
				{
					PlayerInput.ProfileGamepadUI.KeyStatus["SmartSelect"]
				});
				if (PlayerInput.Triggers.JustPressed.SmartSelect)
				{
					player.DropSelectedItem();
				}
			}
			else if (!string.IsNullOrEmpty(overrideInstructions))
			{
				ItemSlot.ShiftForcedOn = true;
				int cursorOverride = Main.cursorOverride;
				ItemSlot.OverrideHover(inv, context, slot);
				if (-1 != Main.cursorOverride)
				{
					text += PlayerInput.BuildCommand(overrideInstructions, false, new List<string>[]
					{
						PlayerInput.ProfileGamepadUI.KeyStatus["SmartSelect"]
					});
					if (PlayerInput.Triggers.JustPressed.SmartSelect)
					{
						ItemSlot.LeftClick(inv, context, slot);
					}
				}
				Main.cursorOverride = cursorOverride;
				ItemSlot.ShiftForcedOn = false;
			}
			int num2 = 0;
			if (ItemSlot.IsABuildingItem(Main.mouseItem))
			{
				num2 = 1;
			}
			if (num2 == 0 && Main.mouseItem.stack <= 0 && context == 0 && ItemSlot.IsABuildingItem(inv[slot]))
			{
				num2 = 2;
			}
			if (Main.autoPause)
			{
				num2 = 0;
			}
			if (num2 > 0)
			{
				Item item = Main.mouseItem;
				if (num2 == 1)
				{
					item = Main.mouseItem;
				}
				if (num2 == 2)
				{
					item = inv[slot];
				}
				if (num2 != 1 || player.ItemSpace(item))
				{
					if (item.damage > 0 && item.ammo == 0)
					{
						text += PlayerInput.BuildCommand(Lang.misc[60].Value, false, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["QuickMount"]
						});
					}
					else if (item.createTile >= 0 || item.createWall > 0)
					{
						text += PlayerInput.BuildCommand(Lang.misc[61].Value, false, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["QuickMount"]
						});
					}
					else
					{
						text += PlayerInput.BuildCommand(Lang.misc[63].Value, false, new List<string>[]
						{
							PlayerInput.ProfileGamepadUI.KeyStatus["QuickMount"]
						});
					}
				}
				if (PlayerInput.Triggers.JustPressed.QuickMount)
				{
					PlayerInput.EnterBuildingMode();
				}
			}
			return text;
		}

		// Token: 0x06000BFB RID: 3067 RVA: 0x003D7A24 File Offset: 0x003D5C24
		public static bool IsABuildingItem(Item item)
		{
			return item.type > 0 && item.stack > 0 && item.useStyle > 0 && item.useTime > 0;
		}

		// Token: 0x04000EBD RID: 3773
		public static bool ShiftForcedOn = false;

		// Token: 0x04000EBE RID: 3774
		private static Item[] singleSlotArray = new Item[1];

		// Token: 0x04000EBF RID: 3775
		private static bool[] canFavoriteAt = new bool[23];

		// Token: 0x04000EC0 RID: 3776
		private static float[] inventoryGlowHue = new float[58];

		// Token: 0x04000EC1 RID: 3777
		private static int[] inventoryGlowTime = new int[58];

		// Token: 0x04000EC2 RID: 3778
		private static float[] inventoryGlowHueChest = new float[58];

		// Token: 0x04000EC3 RID: 3779
		private static int[] inventoryGlowTimeChest = new int[58];

		// Token: 0x04000EC4 RID: 3780
		private static int _customCurrencyForSavings = -1;

		// Token: 0x04000EC5 RID: 3781
		private static int dyeSlotCount = 0;

		// Token: 0x04000EC6 RID: 3782
		private static int accSlotCount = 0;

		// Token: 0x04000EC7 RID: 3783
		public static float CircularRadialOpacity = 0f;

		// Token: 0x04000EC8 RID: 3784
		public static float QuicksRadialOpacity = 0f;

		// Token: 0x02000254 RID: 596
		public class Options
		{
			// Token: 0x040038A4 RID: 14500
			public static bool DisableLeftShiftTrashCan = false;

			// Token: 0x040038A5 RID: 14501
			public static bool HighlightNewItems = true;
		}

		// Token: 0x02000255 RID: 597
		public class Context
		{
			// Token: 0x040038A6 RID: 14502
			public const int InventoryItem = 0;

			// Token: 0x040038A7 RID: 14503
			public const int InventoryCoin = 1;

			// Token: 0x040038A8 RID: 14504
			public const int InventoryAmmo = 2;

			// Token: 0x040038A9 RID: 14505
			public const int ChestItem = 3;

			// Token: 0x040038AA RID: 14506
			public const int BankItem = 4;

			// Token: 0x040038AB RID: 14507
			public const int PrefixItem = 5;

			// Token: 0x040038AC RID: 14508
			public const int TrashItem = 6;

			// Token: 0x040038AD RID: 14509
			public const int GuideItem = 7;

			// Token: 0x040038AE RID: 14510
			public const int EquipArmor = 8;

			// Token: 0x040038AF RID: 14511
			public const int EquipArmorVanity = 9;

			// Token: 0x040038B0 RID: 14512
			public const int EquipAccessory = 10;

			// Token: 0x040038B1 RID: 14513
			public const int EquipAccessoryVanity = 11;

			// Token: 0x040038B2 RID: 14514
			public const int EquipDye = 12;

			// Token: 0x040038B3 RID: 14515
			public const int HotbarItem = 13;

			// Token: 0x040038B4 RID: 14516
			public const int ChatItem = 14;

			// Token: 0x040038B5 RID: 14517
			public const int ShopItem = 15;

			// Token: 0x040038B6 RID: 14518
			public const int EquipGrapple = 16;

			// Token: 0x040038B7 RID: 14519
			public const int EquipMount = 17;

			// Token: 0x040038B8 RID: 14520
			public const int EquipMinecart = 18;

			// Token: 0x040038B9 RID: 14521
			public const int EquipPet = 19;

			// Token: 0x040038BA RID: 14522
			public const int EquipLight = 20;

			// Token: 0x040038BB RID: 14523
			public const int MouseItem = 21;

			// Token: 0x040038BC RID: 14524
			public const int CraftingMaterial = 22;

			// Token: 0x040038BD RID: 14525
			public const int Count = 23;
		}
	}
}
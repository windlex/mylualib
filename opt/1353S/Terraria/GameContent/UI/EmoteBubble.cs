using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.Events;
using Terraria.ID;

namespace Terraria.GameContent.UI
{
	// Token: 0x0200013B RID: 315
	public class EmoteBubble
	{
		// Token: 0x06001050 RID: 4176 RVA: 0x003FE4DB File Offset: 0x003FC6DB
		public EmoteBubble(int emotion, WorldUIAnchor bubbleAnchor, int time = 180)
		{
			this.anchor = bubbleAnchor;
			this.emote = emotion;
			this.lifeTime = time;
			this.lifeTimeStart = time;
		}

		// Token: 0x0600104D RID: 4173 RVA: 0x003FE3E5 File Offset: 0x003FC5E5
		public static int AssignNewID()
		{
			return EmoteBubble.NextID++;
		}

		// Token: 0x0600104C RID: 4172 RVA: 0x003FE3A7 File Offset: 0x003FC5A7
		public static WorldUIAnchor DeserializeNetAnchor(int type, int meta)
		{
			if (type == 0)
			{
				return new WorldUIAnchor(Main.npc[meta]);
			}
			if (type == 1)
			{
				return new WorldUIAnchor(Main.player[meta]);
			}
			if (type == 2)
			{
				return new WorldUIAnchor(Main.projectile[meta]);
			}
			throw new Exception("How did you end up getting this?");
		}

		// Token: 0x06001052 RID: 4178 RVA: 0x003FE558 File Offset: 0x003FC758
		private void Draw(SpriteBatch sb)
		{
			Texture2D texture2D = Main.extraTexture[48];
			SpriteEffects spriteEffects = SpriteEffects.None;
			Vector2 vector = this.GetPosition(out spriteEffects);
			bool flag = this.lifeTime < 6 || this.lifeTimeStart - this.lifeTime < 6;
			Rectangle rectangle = texture2D.Frame(8, 33, flag ? 0 : 1, 0);
			Vector2 origin = new Vector2((float)(rectangle.Width / 2), (float)rectangle.Height);
			if (Main.player[Main.myPlayer].gravDir == -1f)
			{
				origin.Y = 0f;
				spriteEffects |= SpriteEffects.FlipVertically;
				vector = Main.ReverseGravitySupport(vector, 0f);
			}
			sb.Draw(texture2D, vector, new Rectangle?(rectangle), Color.White, 0f, origin, 1f, spriteEffects, 0f);
			if (!flag)
			{
				if (this.emote >= 0)
				{
					if (this.emote == 87)
					{
						spriteEffects = SpriteEffects.None;
					}
					sb.Draw(texture2D, vector, new Rectangle?(texture2D.Frame(8, 35, this.emote * 2 % 8 + this.frame, 1 + this.emote / 4)), Color.White, 0f, origin, 1f, spriteEffects, 0f);
					return;
				}
				if (this.emote == -1)
				{
					texture2D = Main.npcHeadTexture[this.metadata];
					float num = 1f;
					if ((float)texture2D.Width / 22f > 1f)
					{
						num = 22f / (float)texture2D.Width;
					}
					if ((float)texture2D.Height / 16f > 1f / num)
					{
						num = 16f / (float)texture2D.Height;
					}
					sb.Draw(texture2D, vector + new Vector2((float)(spriteEffects.HasFlag(SpriteEffects.FlipHorizontally) ? 1 : -1), (float)(-(float)rectangle.Height + 3)), null, Color.White, 0f, new Vector2((float)(texture2D.Width / 2), 0f), num, spriteEffects, 0f);
				}
			}
		}

		// Token: 0x0600104A RID: 4170 RVA: 0x003FE2C4 File Offset: 0x003FC4C4
		public static void DrawAll(SpriteBatch sb)
		{
			Dictionary<int, EmoteBubble> obj = EmoteBubble.byID;
			lock (obj)
			{
				foreach (KeyValuePair<int, EmoteBubble> current in EmoteBubble.byID)
				{
					current.Value.Draw(sb);
				}
			}
		}

		// Token: 0x06001053 RID: 4179 RVA: 0x003FE74C File Offset: 0x003FC94C
		private Vector2 GetPosition(out SpriteEffects effect)
		{
			switch (this.anchor.type)
			{
				case WorldUIAnchor.AnchorType.Entity:
					effect = ((this.anchor.entity.direction == -1) ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
					return this.anchor.entity.Top + new Vector2((float)(-(float)this.anchor.entity.direction * this.anchor.entity.width) * 0.75f, 2f) - Main.screenPosition;
				case WorldUIAnchor.AnchorType.Tile:
					effect = SpriteEffects.None;
					return this.anchor.pos - Main.screenPosition + new Vector2(0f, -this.anchor.size.Y / 2f);
				case WorldUIAnchor.AnchorType.Pos:
					effect = SpriteEffects.None;
					return this.anchor.pos - Main.screenPosition;
				default:
					effect = SpriteEffects.None;
					return new Vector2((float)Main.screenWidth, (float)Main.screenHeight) / 2f;
			}
		}

		// Token: 0x0600104E RID: 4174 RVA: 0x003FE3F4 File Offset: 0x003FC5F4
		public static int NewBubble(int emoticon, WorldUIAnchor bubbleAnchor, int time)
		{
			EmoteBubble emoteBubble = new EmoteBubble(emoticon, bubbleAnchor, time);
			emoteBubble.ID = EmoteBubble.AssignNewID();
			EmoteBubble.byID[emoteBubble.ID] = emoteBubble;
			if (Main.netMode == 2)
			{
				Tuple<int, int> tuple = EmoteBubble.SerializeNetAnchor(bubbleAnchor);
				NetMessage.SendData(91, -1, -1, null, emoteBubble.ID, (float)tuple.Item1, (float)tuple.Item2, (float)time, emoticon, 0, 0);
			}
			return emoteBubble.ID;
		}

		// Token: 0x0600104F RID: 4175 RVA: 0x003FE460 File Offset: 0x003FC660
		public static int NewBubbleNPC(WorldUIAnchor bubbleAnchor, int time, WorldUIAnchor other = null)
		{
			EmoteBubble emoteBubble = new EmoteBubble(0, bubbleAnchor, time);
			emoteBubble.ID = EmoteBubble.AssignNewID();
			EmoteBubble.byID[emoteBubble.ID] = emoteBubble;
			emoteBubble.PickNPCEmote(other);
			if (Main.netMode == 2)
			{
				Tuple<int, int> tuple = EmoteBubble.SerializeNetAnchor(bubbleAnchor);
				NetMessage.SendData(91, -1, -1, null, emoteBubble.ID, (float)tuple.Item1, (float)tuple.Item2, (float)time, emoteBubble.emote, emoteBubble.metadata, 0);
			}
			return emoteBubble.ID;
		}

		// Token: 0x06001054 RID: 4180 RVA: 0x003FE860 File Offset: 0x003FCA60
		public void PickNPCEmote(WorldUIAnchor other = null)
		{
			Player plr = Main.player[(int)Player.FindClosest(((NPC)this.anchor.entity).Center, 0, 0)];
			List<int> list = new List<int>();
			bool flag = false;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && Main.npc[i].boss)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				if (Main.rand.Next(3) == 0)
				{
					this.ProbeTownNPCs(list);
				}
				if (Main.rand.Next(3) == 0)
				{
					this.ProbeEmotions(list);
				}
				if (Main.rand.Next(3) == 0)
				{
					this.ProbeBiomes(list, plr);
				}
				if (Main.rand.Next(2) == 0)
				{
					this.ProbeCritters(list);
				}
				if (Main.rand.Next(2) == 0)
				{
					this.ProbeItems(list, plr);
				}
				if (Main.rand.Next(5) == 0)
				{
					this.ProbeBosses(list);
				}
				if (Main.rand.Next(2) == 0)
				{
					this.ProbeDebuffs(list, plr);
				}
				if (Main.rand.Next(2) == 0)
				{
					this.ProbeEvents(list);
				}
				if (Main.rand.Next(2) == 0)
				{
					this.ProbeWeather(list, plr);
				}
				this.ProbeExceptions(list, plr, other);
			}
			else
			{
				this.ProbeCombat(list);
			}
			if (list.Count > 0)
			{
				this.emote = list[Main.rand.Next(list.Count)];
			}
		}

		// Token: 0x0600105B RID: 4187 RVA: 0x003FED90 File Offset: 0x003FCF90
		private void ProbeBiomes(List<int> list, Player plr)
		{
			if ((double)(plr.position.Y / 16f) < Main.worldSurface * 0.45)
			{
				list.Add(22);
				return;
			}
			if ((double)(plr.position.Y / 16f) > Main.rockLayer + (double)(Main.maxTilesY / 2) - 100.0)
			{
				list.Add(31);
				return;
			}
			if ((double)(plr.position.Y / 16f) > Main.rockLayer)
			{
				list.Add(30);
				return;
			}
			if (plr.ZoneHoly)
			{
				list.Add(27);
				return;
			}
			if (plr.ZoneCorrupt)
			{
				list.Add(26);
				return;
			}
			if (plr.ZoneCrimson)
			{
				list.Add(25);
				return;
			}
			if (plr.ZoneJungle)
			{
				list.Add(24);
				return;
			}
			if (plr.ZoneSnow)
			{
				list.Add(32);
				return;
			}
			if ((double)(plr.position.Y / 16f) < Main.worldSurface && (plr.position.X < 4000f || plr.position.X > (float)(16 * (Main.maxTilesX - 250))))
			{
				list.Add(29);
				return;
			}
			if (plr.ZoneDesert)
			{
				list.Add(28);
				return;
			}
			list.Add(23);
		}

		// Token: 0x0600105E RID: 4190 RVA: 0x003FF0AC File Offset: 0x003FD2AC
		private void ProbeBosses(List<int> list)
		{
			int num = 0;
			if ((!NPC.downedBoss1 && !Main.dayTime) || NPC.downedBoss1)
			{
				num = 1;
			}
			if (NPC.downedBoss2)
			{
				num = 2;
			}
			if (NPC.downedQueenBee || NPC.downedBoss3)
			{
				num = 3;
			}
			if (Main.hardMode)
			{
				num = 4;
			}
			if (NPC.downedMechBossAny)
			{
				num = 5;
			}
			if (NPC.downedPlantBoss)
			{
				num = 6;
			}
			if (NPC.downedGolemBoss)
			{
				num = 7;
			}
			if (NPC.downedAncientCultist)
			{
				num = 8;
			}
			int maxValue = 10;
			if (NPC.downedMoonlord)
			{
				maxValue = 1;
			}
			if ((num >= 1 && num <= 2) || (num >= 1 && Main.rand.Next(maxValue) == 0))
			{
				list.Add(39);
				if (WorldGen.crimson)
				{
					list.Add(41);
				}
				else
				{
					list.Add(40);
				}
				list.Add(51);
			}
			if ((num >= 2 && num <= 3) || (num >= 2 && Main.rand.Next(maxValue) == 0))
			{
				list.Add(43);
				list.Add(42);
			}
			if ((num >= 4 && num <= 5) || (num >= 4 && Main.rand.Next(maxValue) == 0))
			{
				list.Add(44);
				list.Add(47);
				list.Add(45);
				list.Add(46);
			}
			if ((num >= 5 && num <= 6) || (num >= 5 && Main.rand.Next(maxValue) == 0))
			{
				if (!NPC.downedMechBoss1)
				{
					list.Add(47);
				}
				if (!NPC.downedMechBoss2)
				{
					list.Add(45);
				}
				if (!NPC.downedMechBoss3)
				{
					list.Add(46);
				}
				list.Add(48);
			}
			if (num == 6 || (num >= 6 && Main.rand.Next(maxValue) == 0))
			{
				list.Add(48);
				list.Add(49);
				list.Add(50);
			}
			if (num == 7 || (num >= 7 && Main.rand.Next(maxValue) == 0))
			{
				list.Add(49);
				list.Add(50);
				list.Add(52);
			}
			if (num == 8 || (num >= 8 && Main.rand.Next(maxValue) == 0))
			{
				list.Add(52);
				list.Add(53);
			}
			if (NPC.downedPirates && Main.expertMode)
			{
				list.Add(59);
			}
			if (NPC.downedMartians)
			{
				list.Add(60);
			}
			if (NPC.downedChristmasIceQueen)
			{
				list.Add(57);
			}
			if (NPC.downedChristmasSantank)
			{
				list.Add(58);
			}
			if (NPC.downedChristmasTree)
			{
				list.Add(56);
			}
			if (NPC.downedHalloweenKing)
			{
				list.Add(55);
			}
			if (NPC.downedHalloweenTree)
			{
				list.Add(54);
			}
		}

		// Token: 0x06001055 RID: 4181 RVA: 0x003FE9BB File Offset: 0x003FCBBB
		private void ProbeCombat(List<int> list)
		{
			list.Add(16);
			list.Add(1);
			list.Add(2);
			list.Add(91);
			list.Add(93);
			list.Add(84);
			list.Add(84);
		}

		// Token: 0x0600105C RID: 4188 RVA: 0x003FEEE0 File Offset: 0x003FD0E0
		private unsafe void ProbeCritters(List<int> list)
		{
			Vector2 arg_1C_0 = this.anchor.entity.Center;
			float num = 1f;
			float num2 = 1f;
			if ((double)arg_1C_0.Y < Main.rockLayer * 16.0)
			{
				num2 = 0.2f;
			}
			else
			{
				num = 0.2f;
			}
			if (Main.rand.NextFloat() <= num)
			{
				if (Main.dayTime)
				{
					list.Add(13);
					list.Add(12);
					list.Add(68);
					list.Add(62);
					list.Add(63);
					list.Add(69);
					list.Add(70);
				}
				if (!Main.dayTime || (Main.dayTime && (Main.time < 5400.0 || Main.time > 48600.0)))
				{
					list.Add(61);
				}
				if (NPC.downedGoblins)
				{
					list.Add(64);
				}
				if (NPC.downedFrost)
				{
					list.Add(66);
				}
				if (NPC.downedPirates)
				{
					list.Add(65);
				}
				if (NPC.downedMartians)
				{
					list.Add(71);
				}
				if (WorldGen.crimson)
				{
					list.Add(67);
				}
			}
			if (Main.rand.NextFloat() <= num2)
			{
				list.Add(72);
				list.Add(69);
			}
		}

		// Token: 0x06001058 RID: 4184 RVA: 0x003FEBC4 File Offset: 0x003FCDC4
		private void ProbeDebuffs(List<int> list, Player plr)
		{
			if (plr.Center.Y > (float)(Main.maxTilesY * 16 - 3200) || plr.onFire || ((NPC)this.anchor.entity).onFire || plr.onFire2)
			{
				list.Add(9);
			}
			if (Main.rand.Next(2) == 0)
			{
				list.Add(11);
			}
			if (plr.poisoned || ((NPC)this.anchor.entity).poisoned || plr.ZoneJungle)
			{
				list.Add(8);
			}
			if (plr.inventory[plr.selectedItem].type == 215 || Main.rand.Next(3) == 0)
			{
				list.Add(10);
			}
		}

		// Token: 0x0600105D RID: 4189 RVA: 0x003FF01C File Offset: 0x003FD21C
		private void ProbeEmotions(List<int> list)
		{
			list.Add(0);
			list.Add(1);
			list.Add(2);
			list.Add(3);
			list.Add(15);
			list.Add(16);
			list.Add(17);
			list.Add(87);
			list.Add(91);
			if (Main.bloodMoon && !Main.dayTime)
			{
				int item = Utils.SelectRandom<int>(Main.rand, new int[]
				{
					16,
					1
				});
				list.Add(item);
				list.Add(item);
				list.Add(item);
			}
		}

		// Token: 0x06001057 RID: 4183 RVA: 0x003FEAB4 File Offset: 0x003FCCB4
		private void ProbeEvents(List<int> list)
		{
			if (BirthdayParty.PartyIsUp && Main.rand.Next(3) == 0)
			{
				list.Add(Utils.SelectRandom<int>(Main.rand, new int[]
				{
					127,
					128,
					129,
					126
				}));
			}
			if (Main.bloodMoon || (!Main.dayTime && Main.rand.Next(4) == 0))
			{
				list.Add(18);
			}
			if (Main.eclipse || (Main.hardMode && Main.rand.Next(4) == 0))
			{
				list.Add(19);
			}
			if ((!Main.dayTime || WorldGen.spawnMeteor) && WorldGen.shadowOrbSmashed)
			{
				list.Add(99);
			}
			if (Main.pumpkinMoon || ((NPC.downedHalloweenKing || NPC.downedHalloweenTree) && !Main.dayTime))
			{
				list.Add(20);
			}
			if (Main.snowMoon || ((NPC.downedChristmasIceQueen || NPC.downedChristmasSantank || NPC.downedChristmasTree) && !Main.dayTime))
			{
				list.Add(21);
			}
			if (DD2Event.Ongoing || DD2Event.DownedInvasionAnyDifficulty)
			{
				list.Add(133);
			}
		}

		// Token: 0x0600105F RID: 4191 RVA: 0x003FF308 File Offset: 0x003FD508
		private void ProbeExceptions(List<int> list, Player plr, WorldUIAnchor other)
		{
			NPC nPC = (NPC)this.anchor.entity;
			if (nPC.type == 17)
			{
				list.Add(80);
				list.Add(85);
				list.Add(85);
				list.Add(85);
				list.Add(85);
			}
			else if (nPC.type == 18)
			{
				list.Add(73);
				list.Add(73);
				list.Add(84);
				list.Add(75);
			}
			else if (nPC.type == 19)
			{
				if (other != null && ((NPC)other.entity).type == 22)
				{
					list.Add(1);
					list.Add(1);
					list.Add(93);
					list.Add(92);
				}
				else if (other != null && ((NPC)other.entity).type == 22)
				{
					list.Add(1);
					list.Add(1);
					list.Add(93);
					list.Add(92);
				}
				else
				{
					list.Add(82);
					list.Add(82);
					list.Add(85);
					list.Add(85);
					list.Add(77);
					list.Add(93);
				}
			}
			else if (nPC.type == 20)
			{
				if (list.Contains(121))
				{
					list.Add(121);
					list.Add(121);
				}
				list.Add(14);
				list.Add(14);
			}
			else if (nPC.type == 22)
			{
				if (!Main.bloodMoon)
				{
					if (other != null && ((NPC)other.entity).type == 19)
					{
						list.Add(1);
						list.Add(1);
						list.Add(93);
						list.Add(92);
					}
					else
					{
						list.Add(79);
					}
				}
				if (!Main.dayTime)
				{
					list.Add(16);
					list.Add(16);
					list.Add(16);
				}
			}
			else if (nPC.type == 37)
			{
				list.Add(43);
				list.Add(43);
				list.Add(43);
				list.Add(72);
				list.Add(72);
			}
			else if (nPC.type == 38)
			{
				if (Main.bloodMoon)
				{
					list.Add(77);
					list.Add(77);
					list.Add(77);
					list.Add(81);
				}
				else
				{
					list.Add(77);
					list.Add(77);
					list.Add(81);
					list.Add(81);
					list.Add(81);
					list.Add(90);
					list.Add(90);
				}
			}
			else if (nPC.type == 54)
			{
				if (Main.bloodMoon)
				{
					list.Add(43);
					list.Add(72);
					list.Add(1);
				}
				else
				{
					if (list.Contains(111))
					{
						list.Add(111);
					}
					list.Add(17);
				}
			}
			else if (nPC.type == 107)
			{
				if (other != null && ((NPC)other.entity).type == 124)
				{
					list.Remove(111);
					list.Add(0);
					list.Add(0);
					list.Add(0);
					list.Add(17);
					list.Add(17);
					list.Add(86);
					list.Add(88);
					list.Add(88);
				}
				else
				{
					if (list.Contains(111))
					{
						list.Add(111);
						list.Add(111);
						list.Add(111);
					}
					list.Add(91);
					list.Add(92);
					list.Add(91);
					list.Add(92);
				}
			}
			else if (nPC.type == 108)
			{
				list.Add(100);
				list.Add(89);
				list.Add(11);
			}
			if (nPC.type == 124)
			{
				if (other != null && ((NPC)other.entity).type == 107)
				{
					list.Remove(111);
					list.Add(0);
					list.Add(0);
					list.Add(0);
					list.Add(17);
					list.Add(17);
					list.Add(88);
					list.Add(88);
					return;
				}
				if (list.Contains(109))
				{
					list.Add(109);
					list.Add(109);
					list.Add(109);
				}
				if (list.Contains(108))
				{
					list.Remove(108);
					if (Main.hardMode)
					{
						list.Add(108);
						list.Add(108);
					}
					else
					{
						list.Add(106);
						list.Add(106);
					}
				}
				list.Add(43);
				list.Add(2);
				return;
			}
			else
			{
				if (nPC.type == 142)
				{
					list.Add(32);
					list.Add(66);
					list.Add(17);
					list.Add(15);
					list.Add(15);
					return;
				}
				if (nPC.type == 160)
				{
					list.Add(10);
					list.Add(89);
					list.Add(94);
					list.Add(8);
					return;
				}
				if (nPC.type == 178)
				{
					list.Add(83);
					list.Add(83);
					return;
				}
				if (nPC.type == 207)
				{
					list.Add(28);
					list.Add(95);
					list.Add(93);
					return;
				}
				if (nPC.type == 208)
				{
					list.Add(94);
					list.Add(17);
					list.Add(3);
					list.Add(77);
					return;
				}
				if (nPC.type == 209)
				{
					list.Add(48);
					list.Add(83);
					list.Add(5);
					list.Add(5);
					return;
				}
				if (nPC.type == 227)
				{
					list.Add(63);
					list.Add(68);
					return;
				}
				if (nPC.type == 228)
				{
					list.Add(24);
					list.Add(24);
					list.Add(95);
					list.Add(8);
					return;
				}
				if (nPC.type == 229)
				{
					list.Add(93);
					list.Add(9);
					list.Add(65);
					list.Add(120);
					list.Add(59);
					return;
				}
				if (nPC.type == 353)
				{
					if (list.Contains(104))
					{
						list.Add(104);
						list.Add(104);
					}
					if (list.Contains(111))
					{
						list.Add(111);
						list.Add(111);
					}
					list.Add(67);
					return;
				}
				if (nPC.type == 368)
				{
					list.Add(85);
					list.Add(7);
					list.Add(79);
					return;
				}
				if (nPC.type == 369)
				{
					if (!Main.bloodMoon)
					{
						list.Add(70);
						list.Add(70);
						list.Add(76);
						list.Add(76);
						list.Add(79);
						list.Add(79);
						if ((double)nPC.position.Y < Main.worldSurface)
						{
							list.Add(29);
							return;
						}
					}
				}
				else
				{
					if (nPC.type == 453)
					{
						list.Add(72);
						list.Add(69);
						list.Add(87);
						list.Add(3);
						return;
					}
					if (nPC.type == 441)
					{
						list.Add(100);
						list.Add(100);
						list.Add(1);
						list.Add(1);
						list.Add(1);
						list.Add(87);
					}
				}
				return;
			}
		}

		// Token: 0x06001059 RID: 4185 RVA: 0x003FEC90 File Offset: 0x003FCE90
		private void ProbeItems(List<int> list, Player plr)
		{
			list.Add(7);
			list.Add(73);
			list.Add(74);
			list.Add(75);
			list.Add(78);
			list.Add(90);
			if (plr.statLife < plr.statLifeMax2 / 2)
			{
				list.Add(84);
			}
		}

		// Token: 0x0600105A RID: 4186 RVA: 0x003FECE4 File Offset: 0x003FCEE4
		private void ProbeTownNPCs(List<int> list)
		{
			for (int i = 0; i < 580; i++)
			{
				EmoteBubble.CountNPCs[i] = 0;
			}
			for (int j = 0; j < 200; j++)
			{
				if (Main.npc[j].active)
				{
					EmoteBubble.CountNPCs[Main.npc[j].type]++;
				}
			}
			int type = ((NPC)this.anchor.entity).type;
			for (int k = 0; k < 580; k++)
			{
				if (NPCID.Sets.FaceEmote[k] > 0 && EmoteBubble.CountNPCs[k] > 0 && k != type)
				{
					list.Add(NPCID.Sets.FaceEmote[k]);
				}
			}
		}

		// Token: 0x06001056 RID: 4182 RVA: 0x003FE9F4 File Offset: 0x003FCBF4
		private void ProbeWeather(List<int> list, Player plr)
		{
			if (Main.cloudBGActive > 0f)
			{
				list.Add(96);
			}
			if (Main.cloudAlpha > 0f)
			{
				if (!Main.dayTime)
				{
					list.Add(5);
				}
				list.Add(4);
				if (plr.ZoneSnow)
				{
					list.Add(98);
				}
				if (plr.position.X < 4000f || (plr.position.X > (float)(Main.maxTilesX * 16 - 4000) && (double)plr.position.Y < Main.worldSurface / 16.0))
				{
					list.Add(97);
				}
			}
			else
			{
				list.Add(95);
			}
			if (plr.ZoneHoly)
			{
				list.Add(6);
			}
		}

		// Token: 0x0600104B RID: 4171 RVA: 0x003FE344 File Offset: 0x003FC544
		public static Tuple<int, int> SerializeNetAnchor(WorldUIAnchor anch)
		{
			if (anch.type == WorldUIAnchor.AnchorType.Entity)
			{
				int item = 0;
				if (anch.entity is NPC)
				{
					item = 0;
				}
				else if (anch.entity is Player)
				{
					item = 1;
				}
				else if (anch.entity is Projectile)
				{
					item = 2;
				}
				return Tuple.Create<int, int>(item, anch.entity.whoAmI);
			}
			return Tuple.Create<int, int>(0, 0);
		}

		// Token: 0x06001051 RID: 4177 RVA: 0x003FE500 File Offset: 0x003FC700
		private void Update()
		{
			int num = this.lifeTime - 1;
			this.lifeTime = num;
			if (num <= 0)
			{
				return;
			}
			num = this.frameCounter + 1;
			this.frameCounter = num;
			if (num >= 8)
			{
				this.frameCounter = 0;
				num = this.frame + 1;
				this.frame = num;
				if (num >= 2)
				{
					this.frame = 0;
				}
			}
		}

		// Token: 0x06001049 RID: 4169 RVA: 0x003FE1C8 File Offset: 0x003FC3C8
		public static void UpdateAll()
		{
			Dictionary<int, EmoteBubble> obj = EmoteBubble.byID;
			lock (obj)
			{
				EmoteBubble.toClean.Clear();
				foreach (KeyValuePair<int, EmoteBubble> current in EmoteBubble.byID)
				{
					current.Value.Update();
					if (current.Value.lifeTime <= 0)
					{
						EmoteBubble.toClean.Add(current.Key);
					}
				}
				foreach (int current2 in EmoteBubble.toClean)
				{
					EmoteBubble.byID.Remove(current2);
				}
				EmoteBubble.toClean.Clear();
			}
		}

		// Token: 0x04003132 RID: 12594
		public WorldUIAnchor anchor;

		// Token: 0x0400312E RID: 12590
		public static Dictionary<int, EmoteBubble> byID = new Dictionary<int, EmoteBubble>();

		// Token: 0x0400312D RID: 12589
		private static int[] CountNPCs = new int[580];

		// Token: 0x04003135 RID: 12597
		public int emote;

		// Token: 0x04003139 RID: 12601
		public int frame;

		// Token: 0x04003138 RID: 12600
		public int frameCounter;

		// Token: 0x04003137 RID: 12599
		private const int frameSpeed = 8;

		// Token: 0x04003131 RID: 12593
		public int ID;

		// Token: 0x04003133 RID: 12595
		public int lifeTime;

		// Token: 0x04003134 RID: 12596
		public int lifeTimeStart;

		// Token: 0x04003136 RID: 12598
		public int metadata;

		// Token: 0x04003130 RID: 12592
		public static int NextID;

		// Token: 0x0400312F RID: 12591
		private static List<int> toClean = new List<int>();
	}
}

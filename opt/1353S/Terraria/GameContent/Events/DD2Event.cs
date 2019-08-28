using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.Localization;
using Terraria.World.Generation;

namespace Terraria.GameContent.Events
{
	// Token: 0x02000173 RID: 371
	public class DD2Event
	{
		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06001222 RID: 4642 RVA: 0x00413474 File Offset: 0x00411674
		public static bool ReadyToFindBartender
		{
			get
			{
                return NpcMgr.downedBoss2;
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06001223 RID: 4643 RVA: 0x0041347C File Offset: 0x0041167C
		public static bool DownedInvasionAnyDifficulty
		{
			get
			{
				return DD2Event.DownedInvasionT1 || DD2Event.DownedInvasionT2 || DD2Event.DownedInvasionT3;
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06001224 RID: 4644 RVA: 0x00413494 File Offset: 0x00411694
		// (set) Token: 0x06001225 RID: 4645 RVA: 0x0041349C File Offset: 0x0041169C
		public static int TimeLeftBetweenWaves
		{
			get
			{
				return DD2Event._timeLeftUntilSpawningBegins;
			}
			set
			{
				DD2Event._timeLeftUntilSpawningBegins = value;
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06001226 RID: 4646 RVA: 0x004134A4 File Offset: 0x004116A4
		public static bool EnemySpawningIsOnHold
		{
			get
			{
				return DD2Event._timeLeftUntilSpawningBegins != 0;
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06001227 RID: 4647 RVA: 0x004134B0 File Offset: 0x004116B0
		public static bool EnemiesShouldChasePlayers
		{
			get
			{
				return DD2Event.Ongoing || true;
			}
		}

		// Token: 0x06001228 RID: 4648 RVA: 0x004134BC File Offset: 0x004116BC
		public static void Save(BinaryWriter writer)
		{
			writer.Write(DD2Event.DownedInvasionT1);
			writer.Write(DD2Event.DownedInvasionT2);
			writer.Write(DD2Event.DownedInvasionT3);
		}

		// Token: 0x06001229 RID: 4649 RVA: 0x004134E0 File Offset: 0x004116E0
		public static void Load(BinaryReader reader, int gameVersionNumber)
		{
			if (gameVersionNumber < 178)
			{
                NpcMgr.savedBartender = false;
				DD2Event.ResetProgressEntirely();
				return;
			}
            NpcMgr.savedBartender = reader.ReadBoolean();
			DD2Event.DownedInvasionT1 = reader.ReadBoolean();
			DD2Event.DownedInvasionT2 = reader.ReadBoolean();
			DD2Event.DownedInvasionT3 = reader.ReadBoolean();
		}

		// Token: 0x0600122A RID: 4650 RVA: 0x00413530 File Offset: 0x00411730
		public static void ResetProgressEntirely()
		{
			DD2Event.DownedInvasionT1 = (DD2Event.DownedInvasionT2 = (DD2Event.DownedInvasionT3 = false));
			DD2Event.Ongoing = false;
			DD2Event.ArenaHitbox = default(Rectangle);
			DD2Event._arenaHitboxingCooldown = 0;
			DD2Event._timeLeftUntilSpawningBegins = 0;
		}

		// Token: 0x0600122B RID: 4651 RVA: 0x00413564 File Offset: 0x00411764
		public static void ReportEventProgress()
		{
			int progressWave;
			int progressMax;
			int progress;
			DD2Event.GetInvasionStatus(out progressWave, out progressMax, out progress, false);
			Main.ReportInvasionProgress(progress, progressMax, 3, progressWave);
		}

		// Token: 0x0600122C RID: 4652 RVA: 0x00413588 File Offset: 0x00411788
		public static void SyncInvasionProgress(int toWho)
		{
			int num;
			int num2;
			int number;
			DD2Event.GetInvasionStatus(out num, out num2, out number, false);
			NetMessage.SendData(78, toWho, -1, null, number, (float)num2, 3f, (float)num, 0, 0, 0);
		}

		// Token: 0x0600122D RID: 4653 RVA: 0x004135B8 File Offset: 0x004117B8
		public static void SpawnNPC(ref int newNPC)
		{
		}

		// Token: 0x0600122E RID: 4654 RVA: 0x004135BC File Offset: 0x004117BC
		public static void UpdateTime()
		{
			if (!DD2Event.Ongoing && !Main.dedServ)
			{
				Filters.Scene.Deactivate("CrystalDestructionVortex", new object[0]);
				Filters.Scene.Deactivate("CrystalDestructionColor", new object[0]);
				Filters.Scene.Deactivate("CrystalWin", new object[0]);
				return;
			}
			if (Main.netMode != 1 && !NPC.AnyNPCs(548))
			{
				DD2Event.StopInvasion(false);
			}
			if (Main.netMode == 1)
			{
				if (DD2Event._timeLeftUntilSpawningBegins > 0)
				{
					DD2Event._timeLeftUntilSpawningBegins--;
				}
				if (DD2Event._timeLeftUntilSpawningBegins < 0)
				{
					DD2Event._timeLeftUntilSpawningBegins = 0;
				}
				return;
			}
			if (DD2Event._timeLeftUntilSpawningBegins > 0)
			{
				DD2Event._timeLeftUntilSpawningBegins--;
				if (DD2Event._timeLeftUntilSpawningBegins == 0)
				{
					int num;
					int progressMax;
					int progress;
					DD2Event.GetInvasionStatus(out num, out progressMax, out progress, false);
					WorldGen.BroadcastText(Lang.GetInvasionWaveText(num, DD2Event.GetEnemiesForWave(num)), DD2Event.INFO_NEW_WAVE_COLOR);
					if (num == 7 && DD2Event.OngoingDifficulty == 3)
					{
						DD2Event.SummonBetsy();
					}
					if (Main.netMode != 1)
					{
						Main.ReportInvasionProgress(progress, progressMax, 3, num);
					}
					if (Main.netMode == 2)
					{
						NetMessage.SendData(78, -1, -1, null, Main.invasionProgress, (float)Main.invasionProgressMax, 3f, (float)num, 0, 0, 0);
					}
				}
			}
			if (DD2Event._timeLeftUntilSpawningBegins < 0)
			{
				DD2Event._timeLeftUntilSpawningBegins = 0;
			}
		}

		// Token: 0x0600122F RID: 4655 RVA: 0x004136F0 File Offset: 0x004118F0
		public static void StartInvasion(int difficultyOverride = -1)
		{
			if (Main.netMode != 1)
			{
				DD2Event._crystalsDropping_toDrop = 0;
				DD2Event._crystalsDropping_alreadyDropped = 0;
				DD2Event._crystalsDropping_lastWave = 0;
				DD2Event._timeLeftUntilSpawningBegins = 0;
				DD2Event.Ongoing = true;
				DD2Event.FindProperDifficulty();
				if (difficultyOverride != -1)
				{
					DD2Event.OngoingDifficulty = difficultyOverride;
				}
				DD2Event._deadGoblinSpots.Clear();
				DD2Event._downedDarkMageT1 = false;
				DD2Event._downedOgreT2 = false;
				DD2Event._spawnedBetsyT3 = false;
				DD2Event.LostThisRun = false;
				DD2Event.WonThisRun = false;
				NpcMgr.waveKills = 0f;
				NpcMgr.waveNumber = 1;
				DD2Event.ClearAllTowersInGame();
				WorldGen.BroadcastText(NetworkText.FromKey("DungeonDefenders2.InvasionStart", new object[0]), DD2Event.INFO_START_INVASION_COLOR);
				NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
				if (Main.netMode != 1)
				{
					Main.ReportInvasionProgress(0, 1, 3, 1);
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData(78, -1, -1, null, 0, 1f, 3f, 1f, 0, 0, 0);
				}
				DD2Event.SetEnemySpawningOnHold(300);
				DD2Event.WipeEntities();
			}
		}

		// Token: 0x06001230 RID: 4656 RVA: 0x004137F0 File Offset: 0x004119F0
		public static void StopInvasion(bool win = false)
		{
			if (DD2Event.Ongoing)
			{
				if (win)
				{
					DD2Event.WinInvasionInternal();
				}
				DD2Event.Ongoing = false;
				DD2Event._deadGoblinSpots.Clear();
				if (Main.netMode != 1)
				{
					NpcMgr.waveKills = 0f;
					NpcMgr.waveNumber = 0;
					DD2Event.WipeEntities();
					NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
				}
			}
		}

		// Token: 0x06001231 RID: 4657 RVA: 0x00413858 File Offset: 0x00411A58
		private static void WinInvasionInternal()
		{
			if (DD2Event.OngoingDifficulty <= 1)
			{
				DD2Event.DownedInvasionT1 = true;
			}
			if (DD2Event.OngoingDifficulty <= 2)
			{
				DD2Event.DownedInvasionT2 = true;
			}
			if (DD2Event.OngoingDifficulty <= 3)
			{
				DD2Event.DownedInvasionT3 = true;
			}
			if (DD2Event.OngoingDifficulty == 1)
			{
				DD2Event.DropMedals(3);
			}
			if (DD2Event.OngoingDifficulty == 2)
			{
				DD2Event.DropMedals(15);
			}
			if (DD2Event.OngoingDifficulty == 3)
			{
				DD2Event.DropMedals(60);
			}
			WorldGen.BroadcastText(NetworkText.FromKey("DungeonDefenders2.InvasionWin", new object[0]), DD2Event.INFO_START_INVASION_COLOR);
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06001232 RID: 4658 RVA: 0x004138D8 File Offset: 0x00411AD8
		public static bool ReadyForTier2
		{
			get
			{
				return Main.hardMode && NpcMgr.downedMechBossAny;
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06001233 RID: 4659 RVA: 0x004138E8 File Offset: 0x00411AE8
		public static bool ReadyForTier3
		{
			get
			{
				return Main.hardMode && NpcMgr.downedGolemBoss;
			}
		}

		// Token: 0x06001234 RID: 4660 RVA: 0x004138F8 File Offset: 0x00411AF8
		private static void FindProperDifficulty()
		{
			DD2Event.OngoingDifficulty = 1;
			if (DD2Event.ReadyForTier2)
			{
				DD2Event.OngoingDifficulty = 2;
			}
			if (DD2Event.ReadyForTier3)
			{
				DD2Event.OngoingDifficulty = 3;
			}
		}

		// Token: 0x06001235 RID: 4661 RVA: 0x0041391C File Offset: 0x00411B1C
		public static void CheckProgress(int slainMonsterID)
		{
			if (Main.netMode == 1)
			{
				return;
			}
			if (!DD2Event.Ongoing)
			{
				return;
			}
			if (DD2Event.LostThisRun || DD2Event.WonThisRun)
			{
				return;
			}
			if (DD2Event.EnemySpawningIsOnHold)
			{
				return;
			}
			int num;
			int num2;
			int num3;
			DD2Event.GetInvasionStatus(out num, out num2, out num3, false);
			float num4 = (float)DD2Event.GetMonsterPointsWorth(slainMonsterID);
			float waveKills = NpcMgr.waveKills;
			NpcMgr.waveKills += num4;
			num3 += (int)num4;
			bool flag = false;
			int num5 = num;
			if (NpcMgr.waveKills >= (float)num2 && num2 != 0)
			{
				NpcMgr.waveKills = 0f;
				NpcMgr.waveNumber++;
				flag = true;
				DD2Event.GetInvasionStatus(out num, out num2, out num3, true);
				if (DD2Event.WonThisRun)
				{
					if ((float)num3 != waveKills && num4 != 0f)
					{
						if (Main.netMode != 1)
						{
							Main.ReportInvasionProgress(num3, num2, 3, num);
						}
						if (Main.netMode == 2)
						{
							NetMessage.SendData(78, -1, -1, null, Main.invasionProgress, (float)Main.invasionProgressMax, 3f, (float)num, 0, 0, 0);
						}
					}
					return;
				}
				int num6 = num;
				WorldGen.BroadcastText(NetworkText.FromKey("DungeonDefenders2.WaveComplete", new object[0]), DD2Event.INFO_NEW_WAVE_COLOR);
				DD2Event.SetEnemySpawningOnHold(1800);
				if (DD2Event.OngoingDifficulty == 1)
				{
					if (num6 == 5)
					{
						DD2Event.DropMedals(1);
					}
					if (num6 == 4)
					{
						DD2Event.DropMedals(1);
					}
				}
				if (DD2Event.OngoingDifficulty == 2)
				{
					if (num6 == 7)
					{
						DD2Event.DropMedals(6);
					}
					if (num6 == 6)
					{
						DD2Event.DropMedals(3);
					}
					if (num6 == 5)
					{
						DD2Event.DropMedals(1);
					}
				}
				if (DD2Event.OngoingDifficulty == 3)
				{
					if (num6 == 7)
					{
						DD2Event.DropMedals(25);
					}
					if (num6 == 6)
					{
						DD2Event.DropMedals(11);
					}
					if (num6 == 5)
					{
						DD2Event.DropMedals(3);
					}
					if (num6 == 4)
					{
						DD2Event.DropMedals(1);
					}
				}
			}
			if ((float)num3 != waveKills)
			{
				if (flag)
				{
					int num7 = 1;
					int num8 = 1;
					if (Main.netMode != 1)
					{
						Main.ReportInvasionProgress(num7, num8, 3, num5);
					}
					if (Main.netMode == 2)
					{
						NetMessage.SendData(78, -1, -1, null, num7, (float)num8, 3f, (float)num5, 0, 0, 0);
						return;
					}
				}
				else
				{
					if (Main.netMode != 1)
					{
						Main.ReportInvasionProgress(num3, num2, 3, num);
					}
					if (Main.netMode == 2)
					{
						NetMessage.SendData(78, -1, -1, null, Main.invasionProgress, (float)Main.invasionProgressMax, 3f, (float)num, 0, 0, 0);
					}
				}
			}
		}

		// Token: 0x06001236 RID: 4662 RVA: 0x00413B2C File Offset: 0x00411D2C
		public static void StartVictoryScene()
		{
			DD2Event.WonThisRun = true;
			int num = NPC.FindFirstNPC(548);
			if (num == -1)
			{
				return;
			}
			Main.npc[num].ai[1] = 2f;
			Main.npc[num].ai[0] = 2f;
			Main.npc[num].netUpdate = true;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i] != null && Main.npc[i].active && Main.npc[i].type == 549)
				{
					Main.npc[i].ai[0] = 0f;
					Main.npc[i].ai[1] = 1f;
					Main.npc[i].netUpdate = true;
				}
			}
		}

		// Token: 0x06001237 RID: 4663 RVA: 0x00413BF0 File Offset: 0x00411DF0
		public static void ReportLoss()
		{
			DD2Event.LostThisRun = true;
			DD2Event.SetEnemySpawningOnHold(30);
		}

		// Token: 0x06001238 RID: 4664 RVA: 0x00413C00 File Offset: 0x00411E00
		private static void GetInvasionStatus(out int currentWave, out int requiredKillCount, out int currentKillCount, bool currentlyInCheckProgress = false)
		{
			currentWave = NpcMgr.waveNumber;
			requiredKillCount = 10;
			currentKillCount = (int)NpcMgr.waveKills;
			int ongoingDifficulty = DD2Event.OngoingDifficulty;
			if (ongoingDifficulty == 2)
			{
				requiredKillCount = DD2Event.Difficulty_2_GetRequiredWaveKills(ref currentWave, ref currentKillCount, currentlyInCheckProgress);
				return;
			}
			if (ongoingDifficulty == 3)
			{
				requiredKillCount = DD2Event.Difficulty_3_GetRequiredWaveKills(ref currentWave, ref currentKillCount, currentlyInCheckProgress);
				return;
			}
			requiredKillCount = DD2Event.Difficulty_1_GetRequiredWaveKills(ref currentWave, ref currentKillCount, currentlyInCheckProgress);
		}

		// Token: 0x06001239 RID: 4665 RVA: 0x00413C50 File Offset: 0x00411E50
		private static short[] GetEnemiesForWave(int wave)
		{
			int ongoingDifficulty = DD2Event.OngoingDifficulty;
			if (ongoingDifficulty == 2)
			{
				return DD2Event.Difficulty_2_GetEnemiesForWave(wave);
			}
			if (ongoingDifficulty == 3)
			{
				return DD2Event.Difficulty_3_GetEnemiesForWave(wave);
			}
			return DD2Event.Difficulty_1_GetEnemiesForWave(wave);
		}

		// Token: 0x0600123A RID: 4666 RVA: 0x00413C80 File Offset: 0x00411E80
		private static int GetMonsterPointsWorth(int slainMonsterID)
		{
			int ongoingDifficulty = DD2Event.OngoingDifficulty;
			if (ongoingDifficulty == 2)
			{
				return DD2Event.Difficulty_2_GetMonsterPointsWorth(slainMonsterID);
			}
			if (ongoingDifficulty == 3)
			{
				return DD2Event.Difficulty_3_GetMonsterPointsWorth(slainMonsterID);
			}
			return DD2Event.Difficulty_1_GetMonsterPointsWorth(slainMonsterID);
		}

		// Token: 0x0600123B RID: 4667 RVA: 0x00413CB0 File Offset: 0x00411EB0
		public static void SpawnMonsterFromGate(Vector2 gateBottom)
		{
			int ongoingDifficulty = DD2Event.OngoingDifficulty;
			if (ongoingDifficulty == 2)
			{
				DD2Event.Difficulty_2_SpawnMonsterFromGate(gateBottom);
				return;
			}
			if (ongoingDifficulty == 3)
			{
				DD2Event.Difficulty_3_SpawnMonsterFromGate(gateBottom);
				return;
			}
			DD2Event.Difficulty_1_SpawnMonsterFromGate(gateBottom);
		}

		// Token: 0x0600123C RID: 4668 RVA: 0x00413CE0 File Offset: 0x00411EE0
		public static void SummonCrystal(int x, int y)
		{
			if (Main.netMode == 1)
			{
				NetMessage.SendData(113, -1, -1, null, x, (float)y, 0f, 0f, 0, 0, 0);
				return;
			}
			DD2Event.SummonCrystalDirect(x, y);
		}

		// Token: 0x0600123D RID: 4669 RVA: 0x00413D18 File Offset: 0x00411F18
		public static void SummonCrystalDirect(int x, int y)
		{
			if (NPC.AnyNPCs(548))
			{
				return;
			}
			Tile tileSafely = Framing.GetTileSafely(x, y);
			if (!tileSafely.active() || tileSafely.type != 466)
			{
				return;
			}
			Point point = new Point(x * 16, y * 16);
			point.X -= (int)(tileSafely.frameX / 18 * 16);
			point.Y -= (int)(tileSafely.frameY / 18 * 16);
			point.X += 40;
			point.Y += 64;
			DD2Event.StartInvasion(-1);
			NPC.NewNPC(point.X, point.Y, 548, 0, 0f, 0f, 0f, 0f, 255);
			DD2Event.DropStarterCrystals();
		}

		// Token: 0x0600123E RID: 4670 RVA: 0x00413DE4 File Offset: 0x00411FE4
		public static bool WouldFailSpawningHere(int x, int y)
		{
			Point point;
			Point point2;
			StrayMethods.CheckArenaScore(new Point(x, y).ToWorldCoordinates(8f, 8f), out point, out point2, 5, 10);
			int arg_35_0 = point2.X - x;
			int num = x - point.X;
			return arg_35_0 < 60 || num < 60;
		}

		// Token: 0x0600123F RID: 4671 RVA: 0x00413E30 File Offset: 0x00412030
		public static void FailureMessage(int client)
		{
			LocalizedText text = Language.GetText("DungeonDefenders2.BartenderWarning");
			Color color = new Color(255, 255, 0);
			if (Main.netMode == 2)
			{
				NetMessage.SendChatMessageToClient(NetworkText.FromKey(text.Key, new object[0]), color, client);
				return;
			}
			Main.NewText(text.Value, color.R, color.G, color.B, false);
		}

		// Token: 0x06001240 RID: 4672 RVA: 0x00413E9C File Offset: 0x0041209C
		public static void WipeEntities()
		{
			DD2Event.ClearAllTowersInGame();
			DD2Event.ClearAllDD2HostilesInGame();
			if (Main.netMode == 2)
			{
				NetMessage.SendData(114, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
			}
		}

		// Token: 0x06001241 RID: 4673 RVA: 0x00413ED8 File Offset: 0x004120D8
		public static void ClearAllTowersInGame()
		{
			for (int i = 0; i < 1000; i++)
			{
				if (Main.projectile[i].active && ProjectileID.Sets.IsADD2Turret[Main.projectile[i].type])
				{
					Main.projectile[i].Kill();
				}
			}
		}

		// Token: 0x06001242 RID: 4674 RVA: 0x00413F24 File Offset: 0x00412124
		public static void ClearAllDD2HostilesInGame()
		{
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && NPCID.Sets.BelongsToInvasionOldOnesArmy[Main.npc[i].type])
				{
					Main.npc[i].active = false;
					if (Main.netMode == 2)
					{
						NetMessage.SendData(23, -1, -1, null, i, 0f, 0f, 0f, 0, 0, 0);
					}
				}
			}
		}

		// Token: 0x06001243 RID: 4675 RVA: 0x00413F98 File Offset: 0x00412198
		public static void ClearAllDD2EnergyCrystalsInGame()
		{
			for (int i = 0; i < 400; i++)
			{
				Item item = Main.item[i];
				if (item.active && item.type == 3822)
				{
					item.active = false;
					if (Main.netMode == 2)
					{
						NetMessage.SendData(21, -1, -1, null, i, 0f, 0f, 0f, 0, 0, 0);
					}
				}
			}
		}

		// Token: 0x06001244 RID: 4676 RVA: 0x00414000 File Offset: 0x00412200
		public static void AnnounceGoblinDeath(NPC n)
		{
			DD2Event._deadGoblinSpots.Add(n.Bottom);
		}

		// Token: 0x06001245 RID: 4677 RVA: 0x00414014 File Offset: 0x00412214
		public static bool CanRaiseGoblinsHere(Vector2 spot)
		{
			int num = 0;
			using (List<Vector2>.Enumerator enumerator = DD2Event._deadGoblinSpots.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (Vector2.DistanceSquared(enumerator.Current, spot) <= 640000f)
					{
						num++;
						if (num >= 3)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06001246 RID: 4678 RVA: 0x0041407C File Offset: 0x0041227C
		public static void RaiseGoblins(Vector2 spot)
		{
			List<Vector2> list = new List<Vector2>();
			foreach (Vector2 current in DD2Event._deadGoblinSpots)
			{
				if (Vector2.DistanceSquared(current, spot) <= 722500f)
				{
					list.Add(current);
				}
			}
			foreach (Vector2 current2 in list)
			{
				DD2Event._deadGoblinSpots.Remove(current2);
			}
			int num = 0;
			using (List<Vector2>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Point origin = enumerator.Current.ToTileCoordinates();
					origin.X += Main.rand.Next(-15, 16);
					Point point;
					if (WorldUtils.Find(origin, Searches.Chain(new Searches.Down(50), new GenCondition[]
					{
						new Conditions.IsSolid()
					}), out point))
					{
						if (DD2Event.OngoingDifficulty == 3)
						{
							NPC.NewNPC(point.X * 16 + 8, point.Y * 16, 567, 0, 0f, 0f, 0f, 0f, 255);
						}
						else
						{
							NPC.NewNPC(point.X * 16 + 8, point.Y * 16, 566, 0, 0f, 0f, 0f, 0f, 255);
						}
						if (++num >= 8)
						{
							break;
						}
					}
				}
			}
		}

		// Token: 0x06001247 RID: 4679 RVA: 0x00414238 File Offset: 0x00412438
		public static void FindArenaHitbox()
		{
			if (DD2Event._arenaHitboxingCooldown > 0)
			{
				DD2Event._arenaHitboxingCooldown--;
				return;
			}
			DD2Event._arenaHitboxingCooldown = 60;
			Vector2 vector = new Vector2(3.40282347E+38f, 3.40282347E+38f);
			Vector2 vector2 = new Vector2(0f, 0f);
			for (int i = 0; i < 200; i++)
			{
				NPC nPC = Main.npc[i];
				if (nPC.active && (nPC.type == 549 || nPC.type == 548))
				{
					Vector2 vector3 = nPC.TopLeft;
					if (vector.X > vector3.X)
					{
						vector.X = vector3.X;
					}
					if (vector.Y > vector3.Y)
					{
						vector.Y = vector3.Y;
					}
					vector3 = nPC.BottomRight;
					if (vector2.X < vector3.X)
					{
						vector2.X = vector3.X;
					}
					if (vector2.Y < vector3.Y)
					{
						vector2.Y = vector3.Y;
					}
				}
			}
			Vector2 value = new Vector2(16f, 16f) * 50f;
			vector -= value;
			vector2 += value;
			Vector2 vector4 = vector2 - vector;
			DD2Event.ArenaHitbox.X = (int)vector.X;
			DD2Event.ArenaHitbox.Y = (int)vector.Y;
			DD2Event.ArenaHitbox.Width = (int)vector4.X;
			DD2Event.ArenaHitbox.Height = (int)vector4.Y;
		}

		// Token: 0x06001248 RID: 4680 RVA: 0x004143D0 File Offset: 0x004125D0
		public static bool ShouldBlockBuilding(Vector2 worldPosition)
		{
			return DD2Event.ArenaHitbox.Contains(worldPosition.ToPoint());
		}

		// Token: 0x06001249 RID: 4681 RVA: 0x004143E4 File Offset: 0x004125E4
		public static void DropMedals(int numberOfMedals)
		{
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && Main.npc[i].type == 548)
				{
					Main.npc[i].DropItemInstanced(Main.npc[i].position, Main.npc[i].Size, 3817, numberOfMedals, false);
				}
			}
		}

		// Token: 0x0600124A RID: 4682 RVA: 0x00414450 File Offset: 0x00412650
		public static bool ShouldDropCrystals()
		{
			int num;
			int num2;
			int num3;
			DD2Event.GetInvasionStatus(out num, out num2, out num3, false);
			if (DD2Event._crystalsDropping_lastWave < num)
			{
				DD2Event._crystalsDropping_lastWave++;
				if (DD2Event._crystalsDropping_alreadyDropped > 0)
				{
					DD2Event._crystalsDropping_alreadyDropped -= DD2Event._crystalsDropping_toDrop;
				}
				if (DD2Event.OngoingDifficulty == 1)
				{
					switch (num)
					{
					case 1:
						DD2Event._crystalsDropping_toDrop = 20;
						break;
					case 2:
						DD2Event._crystalsDropping_toDrop = 20;
						break;
					case 3:
						DD2Event._crystalsDropping_toDrop = 30;
						break;
					case 4:
						DD2Event._crystalsDropping_toDrop = 30;
						break;
					case 5:
						DD2Event._crystalsDropping_toDrop = 40;
						break;
					}
				}
				else if (DD2Event.OngoingDifficulty == 2)
				{
					switch (num)
					{
					case 1:
						DD2Event._crystalsDropping_toDrop = 20;
						break;
					case 2:
						DD2Event._crystalsDropping_toDrop = 20;
						break;
					case 3:
						DD2Event._crystalsDropping_toDrop = 20;
						break;
					case 4:
						DD2Event._crystalsDropping_toDrop = 20;
						break;
					case 5:
						DD2Event._crystalsDropping_toDrop = 20;
						break;
					case 6:
						DD2Event._crystalsDropping_toDrop = 30;
						break;
					case 7:
						DD2Event._crystalsDropping_toDrop = 30;
						break;
					}
				}
				else if (DD2Event.OngoingDifficulty == 3)
				{
					switch (num)
					{
					case 1:
						DD2Event._crystalsDropping_toDrop = 20;
						break;
					case 2:
						DD2Event._crystalsDropping_toDrop = 20;
						break;
					case 3:
						DD2Event._crystalsDropping_toDrop = 20;
						break;
					case 4:
						DD2Event._crystalsDropping_toDrop = 20;
						break;
					case 5:
						DD2Event._crystalsDropping_toDrop = 30;
						break;
					case 6:
						DD2Event._crystalsDropping_toDrop = 30;
						break;
					case 7:
						DD2Event._crystalsDropping_toDrop = 30;
						break;
					}
				}
			}
			float num4 = (float)num3 / (float)num2;
			if ((float)DD2Event._crystalsDropping_alreadyDropped < (float)DD2Event._crystalsDropping_toDrop * num4)
			{
				DD2Event._crystalsDropping_alreadyDropped++;
				return true;
			}
			return false;
		}

		// Token: 0x0600124B RID: 4683 RVA: 0x0041460C File Offset: 0x0041280C
		private static void SummonBetsy()
		{
			if (DD2Event._spawnedBetsyT3)
			{
				return;
			}
			if (NPC.AnyNPCs(551))
			{
				return;
			}
			Vector2 center = new Vector2(1f, 1f);
			int num = NPC.FindFirstNPC(548);
			if (num != -1)
			{
				center = Main.npc[num].Center;
			}
			NpcMgr.SpawnOnPlayer((int)Player.FindClosest(center, 1, 1), 551);
			DD2Event._spawnedBetsyT3 = true;
		}

		// Token: 0x0600124C RID: 4684 RVA: 0x00414674 File Offset: 0x00412874
		private static void DropStarterCrystals()
		{
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && Main.npc[i].type == 548)
				{
					for (int j = 0; j < 5; j++)
					{
						Item.NewItem(Main.npc[i].position, Main.npc[i].width, Main.npc[i].height, 3822, 2, false, 0, false, false);
					}
					return;
				}
			}
		}

		// Token: 0x0600124D RID: 4685 RVA: 0x004146F4 File Offset: 0x004128F4
		private static void SetEnemySpawningOnHold(int forHowLong)
		{
			DD2Event._timeLeftUntilSpawningBegins = forHowLong;
			if (Main.netMode == 2)
			{
				NetMessage.SendData(116, -1, -1, null, DD2Event._timeLeftUntilSpawningBegins, 0f, 0f, 0f, 0, 0, 0);
			}
		}

		// Token: 0x0600124E RID: 4686 RVA: 0x00414730 File Offset: 0x00412930
		private static short[] Difficulty_1_GetEnemiesForWave(int wave)
		{
			DD2Event.LaneSpawnRate = 60;
			switch (wave)
			{
			case 1:
				DD2Event.LaneSpawnRate = 90;
				return new short[]
				{
					552
				};
			case 2:
				return new short[]
				{
					552,
					555
				};
			case 3:
				DD2Event.LaneSpawnRate = 55;
				return new short[]
				{
					552,
					555,
					561
				};
			case 4:
				DD2Event.LaneSpawnRate = 50;
				return new short[]
				{
					552,
					555,
					561,
					558
				};
			case 5:
				DD2Event.LaneSpawnRate = 40;
				return new short[]
				{
					552,
					555,
					561,
					558,
					564
				};
			default:
				return new short[]
				{
					552
				};
			}
		}

		// Token: 0x0600124F RID: 4687 RVA: 0x004147E8 File Offset: 0x004129E8
		private static int Difficulty_1_GetRequiredWaveKills(ref int waveNumber, ref int currentKillCount, bool currentlyInCheckProgress)
		{
			switch (waveNumber)
			{
			case -1:
				return 0;
			case 1:
				return 60;
			case 2:
				return 80;
			case 3:
				return 100;
			case 4:
				DD2Event._deadGoblinSpots.Clear();
				return 120;
			case 5:
				if (!DD2Event._downedDarkMageT1 && currentKillCount > 139)
				{
					currentKillCount = 139;
				}
				return 140;
			case 6:
				waveNumber = 5;
				currentKillCount = 1;
				if (currentlyInCheckProgress)
				{
					DD2Event.StartVictoryScene();
				}
				return 1;
			}
			return 10;
		}

		// Token: 0x06001250 RID: 4688 RVA: 0x0041486C File Offset: 0x00412A6C
		private static void Difficulty_1_SpawnMonsterFromGate(Vector2 gateBottom)
		{
			int x = (int)gateBottom.X;
			int y = (int)gateBottom.Y;
			int num = 50;
			int num2 = 6;
			if (NpcMgr.waveNumber > 4)
			{
				num2 = 12;
			}
			else if (NpcMgr.waveNumber > 3)
			{
				num2 = 8;
			}
			int num3 = 6;
			if (NpcMgr.waveNumber > 4)
			{
				num3 = 8;
			}
			for (int i = 1; i < Main.ActivePlayersCount; i++)
			{
				num = (int)((double)num * 1.3);
				num2 = (int)((double)num2 * 1.3);
				num3 = (int)((double)num3 * 1.3);
			}
			int num4 = 200;
			switch (NpcMgr.waveNumber)
			{
			case 1:
				if (NPC.CountNPCS(552) + NPC.CountNPCS(555) < num)
				{
					num4 = NPC.NewNPC(x, y, 552, 0, 0f, 0f, 0f, 0f, 255);
				}
				break;
			case 2:
				if (NPC.CountNPCS(552) + NPC.CountNPCS(555) < num)
				{
					if (Main.rand.Next(7) == 0)
					{
						num4 = NPC.NewNPC(x, y, 555, 0, 0f, 0f, 0f, 0f, 255);
					}
					else
					{
						num4 = NPC.NewNPC(x, y, 552, 0, 0f, 0f, 0f, 0f, 255);
					}
				}
				break;
			case 3:
				if (Main.rand.Next(6) == 0 && NPC.CountNPCS(561) < num2)
				{
					num4 = NPC.NewNPC(x, y, 561, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (NPC.CountNPCS(552) + NPC.CountNPCS(555) < num)
				{
					if (Main.rand.Next(5) == 0)
					{
						num4 = NPC.NewNPC(x, y, 555, 0, 0f, 0f, 0f, 0f, 255);
					}
					else
					{
						num4 = NPC.NewNPC(x, y, 552, 0, 0f, 0f, 0f, 0f, 255);
					}
				}
				break;
			case 4:
				if (Main.rand.Next(12) == 0 && NPC.CountNPCS(558) < num3)
				{
					num4 = NPC.NewNPC(x, y, 558, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(5) == 0 && NPC.CountNPCS(561) < num2)
				{
					num4 = NPC.NewNPC(x, y, 561, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (NPC.CountNPCS(552) + NPC.CountNPCS(555) < num)
				{
					if (Main.rand.Next(5) == 0)
					{
						num4 = NPC.NewNPC(x, y, 555, 0, 0f, 0f, 0f, 0f, 255);
					}
					else
					{
						num4 = NPC.NewNPC(x, y, 552, 0, 0f, 0f, 0f, 0f, 255);
					}
				}
				break;
			case 5:
			{
				int num5;
				int num6;
				int num7;
				DD2Event.GetInvasionStatus(out num5, out num6, out num7, false);
				if ((float)num7 > (float)num6 * 0.5f && !NPC.AnyNPCs(564))
				{
					num4 = NPC.NewNPC(x, y, 564, 0, 0f, 0f, 0f, 0f, 255);
				}
				if (Main.rand.Next(10) == 0 && NPC.CountNPCS(558) < num3)
				{
					num4 = NPC.NewNPC(x, y, 558, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(4) == 0 && NPC.CountNPCS(561) < num2)
				{
					num4 = NPC.NewNPC(x, y, 561, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (NPC.CountNPCS(552) + NPC.CountNPCS(555) < num)
				{
					if (Main.rand.Next(4) == 0)
					{
						num4 = NPC.NewNPC(x, y, 555, 0, 0f, 0f, 0f, 0f, 255);
					}
					else
					{
						num4 = NPC.NewNPC(x, y, 552, 0, 0f, 0f, 0f, 0f, 255);
					}
				}
				break;
			}
			default:
				num4 = NPC.NewNPC(x, y, 552, 0, 0f, 0f, 0f, 0f, 255);
				break;
			}
			if (Main.netMode == 2 && num4 < 200)
			{
				NetMessage.SendData(23, -1, -1, null, num4, 0f, 0f, 0f, 0, 0, 0);
			}
		}

		// Token: 0x06001251 RID: 4689 RVA: 0x00414D7C File Offset: 0x00412F7C
		private static int Difficulty_1_GetMonsterPointsWorth(int slainMonsterID)
		{
			if (NpcMgr.waveNumber == 5 && NpcMgr.waveKills >= 139f)
			{
				if (slainMonsterID == 564 || slainMonsterID == 565)
				{
					DD2Event._downedDarkMageT1 = true;
					return 1;
				}
				return 0;
			}
			else
			{
				if (slainMonsterID - 551 > 14 && slainMonsterID - 568 > 10)
				{
					return 0;
				}
				if (NpcMgr.waveNumber == 5 && NpcMgr.waveKills == 138f)
				{
					return 1;
				}
				if (!Main.expertMode)
				{
					return 1;
				}
				return 2;
			}
		}

		// Token: 0x06001252 RID: 4690 RVA: 0x00414DF0 File Offset: 0x00412FF0
		private static short[] Difficulty_2_GetEnemiesForWave(int wave)
		{
			DD2Event.LaneSpawnRate = 60;
			switch (wave)
			{
			case 1:
				DD2Event.LaneSpawnRate = 90;
				return new short[]
				{
					553,
					562
				};
			case 2:
				DD2Event.LaneSpawnRate = 70;
				return new short[]
				{
					553,
					562,
					572
				};
			case 3:
				return new short[]
				{
					553,
					556,
					562,
					559,
					572
				};
			case 4:
				DD2Event.LaneSpawnRate = 55;
				return new short[]
				{
					553,
					559,
					570,
					572,
					562
				};
			case 5:
				DD2Event.LaneSpawnRate = 50;
				return new short[]
				{
					553,
					556,
					559,
					572,
					574,
					570
				};
			case 6:
				DD2Event.LaneSpawnRate = 45;
				return new short[]
				{
					553,
					556,
					562,
					559,
					568,
					570,
					572,
					574
				};
			case 7:
				DD2Event.LaneSpawnRate = 42;
				return new short[]
				{
					553,
					556,
					572,
					559,
					568,
					574,
					570,
					576
				};
			default:
				return new short[]
				{
					553
				};
			}
		}

		// Token: 0x06001253 RID: 4691 RVA: 0x00414EE8 File Offset: 0x004130E8
		private static int Difficulty_2_GetRequiredWaveKills(ref int waveNumber, ref int currentKillCount, bool currentlyInCheckProgress)
		{
			switch (waveNumber)
			{
			case -1:
				return 0;
			case 1:
				return 60;
			case 2:
				return 80;
			case 3:
				return 100;
			case 4:
				return 120;
			case 5:
				return 140;
			case 6:
				return 180;
			case 7:
				if (!DD2Event._downedOgreT2 && currentKillCount > 219)
				{
					currentKillCount = 219;
				}
				return 220;
			case 8:
				waveNumber = 7;
				currentKillCount = 1;
				if (currentlyInCheckProgress)
				{
					DD2Event.StartVictoryScene();
				}
				return 1;
			}
			return 10;
		}

		// Token: 0x06001254 RID: 4692 RVA: 0x00414F74 File Offset: 0x00413174
		private static int Difficulty_2_GetMonsterPointsWorth(int slainMonsterID)
		{
			if (NpcMgr.waveNumber == 7 && NpcMgr.waveKills >= 219f)
			{
				if (slainMonsterID == 576 || slainMonsterID == 577)
				{
					DD2Event._downedOgreT2 = true;
					return 1;
				}
				return 0;
			}
			else
			{
				if (slainMonsterID - 551 > 14 && slainMonsterID - 568 > 10)
				{
					return 0;
				}
				if (NpcMgr.waveNumber == 7 && NpcMgr.waveKills == 218f)
				{
					return 1;
				}
				if (!Main.expertMode)
				{
					return 1;
				}
				return 2;
			}
		}

		// Token: 0x06001255 RID: 4693 RVA: 0x00414FE8 File Offset: 0x004131E8
		private static void Difficulty_2_SpawnMonsterFromGate(Vector2 gateBottom)
		{
			int x = (int)gateBottom.X;
			int y = (int)gateBottom.Y;
			int num = 50;
			int num2 = 5;
			if (NpcMgr.waveNumber > 1)
			{
				num2 = 8;
			}
			if (NpcMgr.waveNumber > 3)
			{
				num2 = 10;
			}
			if (NpcMgr.waveNumber > 5)
			{
				num2 = 12;
			}
			int num3 = 5;
			if (NpcMgr.waveNumber > 4)
			{
				num3 = 7;
			}
			int num4 = 2;
			int num5 = 8;
			if (NpcMgr.waveNumber > 3)
			{
				num5 = 12;
			}
			int num6 = 3;
			if (NpcMgr.waveNumber > 5)
			{
				num6 = 5;
			}
			for (int i = 1; i < Main.ActivePlayersCount; i++)
			{
				num = (int)((double)num * 1.3);
				num2 = (int)((double)num2 * 1.3);
				num5 = (int)((double)num * 1.3);
				num6 = (int)((double)num * 1.35);
			}
			int num7 = 200;
			int num8 = 200;
			switch (NpcMgr.waveNumber)
			{
			case 1:
				if (Main.rand.Next(20) == 0 && NPC.CountNPCS(562) < num2)
				{
					num7 = NPC.NewNPC(x, y, 562, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (NPC.CountNPCS(553) < num)
				{
					num7 = NPC.NewNPC(x, y, 553, 0, 0f, 0f, 0f, 0f, 255);
				}
				break;
			case 2:
				if (Main.rand.Next(3) == 0 && NPC.CountNPCS(572) < num5)
				{
					num7 = NPC.NewNPC(x, y, 572, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(8) == 0 && NPC.CountNPCS(562) < num2)
				{
					num7 = NPC.NewNPC(x, y, 562, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (NPC.CountNPCS(553) < num)
				{
					num7 = NPC.NewNPC(x, y, 553, 0, 0f, 0f, 0f, 0f, 255);
				}
				break;
			case 3:
				if (Main.rand.Next(7) == 0 && NPC.CountNPCS(572) < num5)
				{
					num7 = NPC.NewNPC(x, y, 572, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(10) == 0 && NPC.CountNPCS(559) < num3)
				{
					num7 = NPC.NewNPC(x, y, 559, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(8) == 0 && NPC.CountNPCS(562) < num2)
				{
					num7 = NPC.NewNPC(x, y, 562, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (NPC.CountNPCS(553) + NPC.CountNPCS(556) < num)
				{
					if (Main.rand.Next(4) == 0)
					{
						num7 = NPC.NewNPC(x, y, 556, 0, 0f, 0f, 0f, 0f, 255);
					}
					num8 = NPC.NewNPC(x, y, 553, 0, 0f, 0f, 0f, 0f, 255);
				}
				break;
			case 4:
				if (Main.rand.Next(10) == 0 && NPC.CountNPCS(570) < num6)
				{
					num7 = NPC.NewNPC(x, y, 570, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(12) == 0 && NPC.CountNPCS(559) < num3)
				{
					num7 = NPC.NewNPC(x, y, 559, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(6) == 0 && NPC.CountNPCS(562) < num2)
				{
					num7 = NPC.NewNPC(x, y, 562, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(3) == 0 && NPC.CountNPCS(572) < num5)
				{
					num7 = NPC.NewNPC(x, y, 572, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (NPC.CountNPCS(553) < num)
				{
					num7 = NPC.NewNPC(x, y, 553, 0, 0f, 0f, 0f, 0f, 255);
				}
				break;
			case 5:
				if (Main.rand.Next(7) == 0 && NPC.CountNPCS(570) < num6)
				{
					num7 = NPC.NewNPC(x, y, 570, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(10) == 0 && NPC.CountNPCS(559) < num3)
				{
					num7 = NPC.NewNPC(x, y, 559, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(4) == 0 && NPC.CountNPCS(572) + NPC.CountNPCS(574) < num5)
				{
					if (Main.rand.Next(2) == 0)
					{
						num7 = NPC.NewNPC(x, y, 572, 0, 0f, 0f, 0f, 0f, 255);
					}
					else
					{
						num7 = NPC.NewNPC(x, y, 574, 0, 0f, 0f, 0f, 0f, 255);
					}
				}
				else if (NPC.CountNPCS(553) + NPC.CountNPCS(556) < num)
				{
					if (Main.rand.Next(3) == 0)
					{
						num7 = NPC.NewNPC(x, y, 556, 0, 0f, 0f, 0f, 0f, 255);
					}
					num8 = NPC.NewNPC(x, y, 553, 0, 0f, 0f, 0f, 0f, 255);
				}
				break;
			case 6:
				if (Main.rand.Next(7) == 0 && NPC.CountNPCS(570) < num6)
				{
					num7 = NPC.NewNPC(x, y, 570, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(17) == 0 && NPC.CountNPCS(568) < num4)
				{
					num7 = NPC.NewNPC(x, y, 568, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(5) == 0 && NPC.CountNPCS(572) + NPC.CountNPCS(574) < num5)
				{
					if (Main.rand.Next(2) != 0)
					{
						num7 = NPC.NewNPC(x, y, 572, 0, 0f, 0f, 0f, 0f, 255);
					}
					else
					{
						num7 = NPC.NewNPC(x, y, 574, 0, 0f, 0f, 0f, 0f, 255);
					}
				}
				else if (Main.rand.Next(9) == 0 && NPC.CountNPCS(559) < num3)
				{
					num7 = NPC.NewNPC(x, y, 559, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(3) == 0 && NPC.CountNPCS(562) < num2)
				{
					num7 = NPC.NewNPC(x, y, 562, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (NPC.CountNPCS(553) + NPC.CountNPCS(556) < num)
				{
					if (Main.rand.Next(3) != 0)
					{
						num7 = NPC.NewNPC(x, y, 556, 0, 0f, 0f, 0f, 0f, 255);
					}
					num8 = NPC.NewNPC(x, y, 553, 0, 0f, 0f, 0f, 0f, 255);
				}
				break;
			case 7:
			{
				int num9;
				int num10;
				int num11;
				DD2Event.GetInvasionStatus(out num9, out num10, out num11, false);
				if ((float)num11 > (float)num10 * 0.1f && !NPC.AnyNPCs(576))
				{
					num7 = NPC.NewNPC(x, y, 576, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(7) == 0 && NPC.CountNPCS(570) < num6)
				{
					num7 = NPC.NewNPC(x, y, 570, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(17) == 0 && NPC.CountNPCS(568) < num4)
				{
					num7 = NPC.NewNPC(x, y, 568, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(7) == 0 && NPC.CountNPCS(572) + NPC.CountNPCS(574) < num5)
				{
					if (Main.rand.Next(3) != 0)
					{
						num7 = NPC.NewNPC(x, y, 572, 0, 0f, 0f, 0f, 0f, 255);
					}
					else
					{
						num7 = NPC.NewNPC(x, y, 574, 0, 0f, 0f, 0f, 0f, 255);
					}
				}
				else if (Main.rand.Next(11) == 0 && NPC.CountNPCS(559) < num3)
				{
					num7 = NPC.NewNPC(x, y, 559, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (NPC.CountNPCS(553) + NPC.CountNPCS(556) < num)
				{
					if (Main.rand.Next(2) == 0)
					{
						num7 = NPC.NewNPC(x, y, 556, 0, 0f, 0f, 0f, 0f, 255);
					}
					num8 = NPC.NewNPC(x, y, 553, 0, 0f, 0f, 0f, 0f, 255);
				}
				break;
			}
			default:
				num7 = NPC.NewNPC(x, y, 553, 0, 0f, 0f, 0f, 0f, 255);
				break;
			}
			if (Main.netMode == 2 && num7 < 200)
			{
				NetMessage.SendData(23, -1, -1, null, num7, 0f, 0f, 0f, 0, 0, 0);
			}
			if (Main.netMode == 2 && num8 < 200)
			{
				NetMessage.SendData(23, -1, -1, null, num8, 0f, 0f, 0f, 0, 0, 0);
			}
		}

		// Token: 0x06001256 RID: 4694 RVA: 0x00415B74 File Offset: 0x00413D74
		private static short[] Difficulty_3_GetEnemiesForWave(int wave)
		{
			DD2Event.LaneSpawnRate = 60;
			switch (wave)
			{
			case 1:
				DD2Event.LaneSpawnRate = 85;
				return new short[]
				{
					554,
					557,
					563
				};
			case 2:
				DD2Event.LaneSpawnRate = 75;
				return new short[]
				{
					554,
					557,
					563,
					573,
					578
				};
			case 3:
				DD2Event.LaneSpawnRate = 60;
				return new short[]
				{
					554,
					563,
					560,
					573,
					571
				};
			case 4:
				DD2Event.LaneSpawnRate = 60;
				return new short[]
				{
					554,
					560,
					571,
					573,
					563,
					575,
					565
				};
			case 5:
				DD2Event.LaneSpawnRate = 55;
				return new short[]
				{
					554,
					557,
					573,
					575,
					571,
					569,
					577
				};
			case 6:
				DD2Event.LaneSpawnRate = 60;
				return new short[]
				{
					554,
					557,
					563,
					560,
					569,
					571,
					577,
					565
				};
			case 7:
				DD2Event.LaneSpawnRate = 90;
				return new short[]
				{
					554,
					557,
					563,
					569,
					571,
					551
				};
			default:
				return new short[]
				{
					554
				};
			}
		}

		// Token: 0x06001257 RID: 4695 RVA: 0x00415C70 File Offset: 0x00413E70
		private static int Difficulty_3_GetRequiredWaveKills(ref int waveNumber, ref int currentKillCount, bool currentlyInCheckProgress)
		{
			switch (waveNumber)
			{
			case -1:
				return 0;
			case 1:
				return 60;
			case 2:
				return 80;
			case 3:
				return 100;
			case 4:
				return 120;
			case 5:
				return 140;
			case 6:
				return 180;
			case 7:
			{
				int num = NPC.FindFirstNPC(551);
				if (num == -1)
				{
					return 1;
				}
				currentKillCount = 100 - (int)((float)Main.npc[num].life / (float)Main.npc[num].lifeMax * 100f);
				return 100;
			}
			case 8:
				waveNumber = 7;
				currentKillCount = 1;
				if (currentlyInCheckProgress)
				{
					DD2Event.StartVictoryScene();
				}
				return 1;
			}
			return 10;
		}

		// Token: 0x06001258 RID: 4696 RVA: 0x00415D1C File Offset: 0x00413F1C
		private static int Difficulty_3_GetMonsterPointsWorth(int slainMonsterID)
		{
			if (NpcMgr.waveNumber == 7)
			{
				if (slainMonsterID == 551)
				{
					return 1;
				}
				return 0;
			}
			else
			{
				if (slainMonsterID - 551 > 14 && slainMonsterID - 568 > 10)
				{
					return 0;
				}
				if (!Main.expertMode)
				{
					return 1;
				}
				return 2;
			}
		}

		// Token: 0x06001259 RID: 4697 RVA: 0x00415D54 File Offset: 0x00413F54
		private static void Difficulty_3_SpawnMonsterFromGate(Vector2 gateBottom)
		{
			int x = (int)gateBottom.X;
			int y = (int)gateBottom.Y;
			int num = 60;
			int num2 = 7;
			if (NpcMgr.waveNumber > 1)
			{
				num2 = 9;
			}
			if (NpcMgr.waveNumber > 3)
			{
				num2 = 12;
			}
			if (NpcMgr.waveNumber > 5)
			{
				num2 = 15;
			}
			int num3 = 7;
			if (NpcMgr.waveNumber > 4)
			{
				num3 = 10;
			}
			int num4 = 2;
			if (NpcMgr.waveNumber > 5)
			{
				num4 = 3;
			}
			int num5 = 12;
			if (NpcMgr.waveNumber > 3)
			{
				num5 = 18;
			}
			int num6 = 4;
			if (NpcMgr.waveNumber > 5)
			{
				num6 = 6;
			}
			int num7 = 4;
			for (int i = 1; i < Main.ActivePlayersCount; i++)
			{
				num = (int)((double)num * 1.3);
				num2 = (int)((double)num2 * 1.3);
				num5 = (int)((double)num * 1.3);
				num6 = (int)((double)num * 1.35);
				num7 = (int)((double)num7 * 1.3);
			}
			int num8 = 200;
			int num9 = 200;
			switch (NpcMgr.waveNumber)
			{
			case 1:
				if (Main.rand.Next(18) == 0 && NPC.CountNPCS(563) < num2)
				{
					num8 = NPC.NewNPC(x, y, 563, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (NPC.CountNPCS(554) < num)
				{
					if (Main.rand.Next(7) == 0)
					{
						num8 = NPC.NewNPC(x, y, 557, 0, 0f, 0f, 0f, 0f, 255);
					}
					num9 = NPC.NewNPC(x, y, 554, 0, 0f, 0f, 0f, 0f, 255);
				}
				break;
			case 2:
				if (Main.rand.Next(3) == 0 && NPC.CountNPCS(578) < num7)
				{
					num8 = NPC.NewNPC(x, y, 578, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(7) == 0 && NPC.CountNPCS(563) < num2)
				{
					num8 = NPC.NewNPC(x, y, 563, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(3) == 0 && NPC.CountNPCS(573) < num5)
				{
					num8 = NPC.NewNPC(x, y, 573, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (NPC.CountNPCS(554) < num)
				{
					if (Main.rand.Next(4) == 0)
					{
						num8 = NPC.NewNPC(x, y, 557, 0, 0f, 0f, 0f, 0f, 255);
					}
					num9 = NPC.NewNPC(x, y, 554, 0, 0f, 0f, 0f, 0f, 255);
				}
				break;
			case 3:
				if (Main.rand.Next(13) == 0 && NPC.CountNPCS(571) < num6)
				{
					num8 = NPC.NewNPC(x, y, 571, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(7) == 0 && NPC.CountNPCS(573) < num5)
				{
					num8 = NPC.NewNPC(x, y, 573, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(10) == 0 && NPC.CountNPCS(560) < num3)
				{
					num8 = NPC.NewNPC(x, y, 560, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(8) == 0 && NPC.CountNPCS(563) < num2)
				{
					num8 = NPC.NewNPC(x, y, 563, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (NPC.CountNPCS(554) + NPC.CountNPCS(557) < num)
				{
					num8 = NPC.NewNPC(x, y, 554, 0, 0f, 0f, 0f, 0f, 255);
				}
				break;
			case 4:
				if (Main.rand.Next(24) == 0 && !NPC.AnyNPCs(565))
				{
					num8 = NPC.NewNPC(x, y, 565, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(12) == 0 && NPC.CountNPCS(571) < num6)
				{
					num8 = NPC.NewNPC(x, y, 571, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(15) == 0 && NPC.CountNPCS(560) < num3)
				{
					num8 = NPC.NewNPC(x, y, 560, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(7) == 0 && NPC.CountNPCS(563) < num2)
				{
					num8 = NPC.NewNPC(x, y, 563, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(5) == 0 && NPC.CountNPCS(573) + NPC.CountNPCS(575) < num5)
				{
					if (Main.rand.Next(3) != 0)
					{
						num8 = NPC.NewNPC(x, y, 573, 0, 0f, 0f, 0f, 0f, 255);
					}
					else
					{
						num8 = NPC.NewNPC(x, y, 575, 0, 0f, 0f, 0f, 0f, 255);
					}
				}
				else if (NPC.CountNPCS(554) < num)
				{
					num8 = NPC.NewNPC(x, y, 554, 0, 0f, 0f, 0f, 0f, 255);
				}
				break;
			case 5:
				if (Main.rand.Next(20) == 0 && !NPC.AnyNPCs(577))
				{
					num8 = NPC.NewNPC(x, y, 577, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(17) == 0 && NPC.CountNPCS(569) < num4)
				{
					num8 = NPC.NewNPC(x, y, 569, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(8) == 0 && NPC.CountNPCS(571) < num6)
				{
					num8 = NPC.NewNPC(x, y, 571, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(7) == 0 && NPC.CountNPCS(573) + NPC.CountNPCS(575) < num5)
				{
					if (Main.rand.Next(4) != 0)
					{
						num8 = NPC.NewNPC(x, y, 573, 0, 0f, 0f, 0f, 0f, 255);
					}
					else
					{
						num8 = NPC.NewNPC(x, y, 575, 0, 0f, 0f, 0f, 0f, 255);
					}
				}
				else if (NPC.CountNPCS(554) + NPC.CountNPCS(557) < num)
				{
					if (Main.rand.Next(3) == 0)
					{
						num8 = NPC.NewNPC(x, y, 557, 0, 0f, 0f, 0f, 0f, 255);
					}
					num9 = NPC.NewNPC(x, y, 554, 0, 0f, 0f, 0f, 0f, 255);
				}
				break;
			case 6:
				if (Main.rand.Next(20) == 0 && !NPC.AnyNPCs(577))
				{
					num8 = NPC.NewNPC(x, y, 577, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(20) == 0 && !NPC.AnyNPCs(565))
				{
					num8 = NPC.NewNPC(x, y, 565, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(12) == 0 && NPC.CountNPCS(571) < num6)
				{
					num8 = NPC.NewNPC(x, y, 571, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(25) == 0 && NPC.CountNPCS(569) < num4)
				{
					num8 = NPC.NewNPC(x, y, 569, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(7) == 0 && NPC.CountNPCS(573) + NPC.CountNPCS(575) < num5)
				{
					if (Main.rand.Next(3) != 0)
					{
						num8 = NPC.NewNPC(x, y, 573, 0, 0f, 0f, 0f, 0f, 255);
					}
					else
					{
						num8 = NPC.NewNPC(x, y, 575, 0, 0f, 0f, 0f, 0f, 255);
					}
				}
				else if (Main.rand.Next(10) == 0 && NPC.CountNPCS(560) < num3)
				{
					num8 = NPC.NewNPC(x, y, 560, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(5) == 0 && NPC.CountNPCS(563) < num2)
				{
					num8 = NPC.NewNPC(x, y, 563, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (NPC.CountNPCS(554) + NPC.CountNPCS(557) < num)
				{
					if (Main.rand.Next(3) == 0)
					{
						num8 = NPC.NewNPC(x, y, 557, 0, 0f, 0f, 0f, 0f, 255);
					}
					num9 = NPC.NewNPC(x, y, 554, 0, 0f, 0f, 0f, 0f, 255);
				}
				break;
			case 7:
				if (Main.rand.Next(20) == 0 && NPC.CountNPCS(571) < num6)
				{
					num8 = NPC.NewNPC(x, y, 571, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(17) == 0 && NPC.CountNPCS(569) < num4)
				{
					num8 = NPC.NewNPC(x, y, 569, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (Main.rand.Next(10) == 0 && NPC.CountNPCS(563) < num2)
				{
					num8 = NPC.NewNPC(x, y, 563, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if (NPC.CountNPCS(554) + NPC.CountNPCS(557) < num)
				{
					if (Main.rand.Next(5) == 0)
					{
						num8 = NPC.NewNPC(x, y, 557, 0, 0f, 0f, 0f, 0f, 255);
					}
					num9 = NPC.NewNPC(x, y, 554, 0, 0f, 0f, 0f, 0f, 255);
				}
				break;
			default:
				num8 = NPC.NewNPC(x, y, 554, 0, 0f, 0f, 0f, 0f, 255);
				break;
			}
			if (Main.netMode == 2 && num8 < 200)
			{
				NetMessage.SendData(23, -1, -1, null, num8, 0f, 0f, 0f, 0, 0, 0);
			}
			if (Main.netMode == 2 && num9 < 200)
			{
				NetMessage.SendData(23, -1, -1, null, num9, 0f, 0f, 0f, 0, 0, 0);
			}
		}

		// Token: 0x04003279 RID: 12921
		private static readonly Color INFO_NEW_WAVE_COLOR = new Color(175, 55, 255);

		// Token: 0x0400327A RID: 12922
		private static readonly Color INFO_START_INVASION_COLOR = new Color(50, 255, 130);

		// Token: 0x0400327B RID: 12923
		private const int INVASION_ID = 3;

		// Token: 0x0400327C RID: 12924
		public static bool DownedInvasionT1 = false;

		// Token: 0x0400327D RID: 12925
		public static bool DownedInvasionT2 = false;

		// Token: 0x0400327E RID: 12926
		public static bool DownedInvasionT3 = false;

		// Token: 0x0400327F RID: 12927
		public static bool LostThisRun = false;

		// Token: 0x04003280 RID: 12928
		public static bool WonThisRun = false;

		// Token: 0x04003281 RID: 12929
		public static int LaneSpawnRate = 60;

		// Token: 0x04003282 RID: 12930
		private static bool _downedDarkMageT1 = false;

		// Token: 0x04003283 RID: 12931
		private static bool _downedOgreT2 = false;

		// Token: 0x04003284 RID: 12932
		private static bool _spawnedBetsyT3 = false;

		// Token: 0x04003285 RID: 12933
		public static bool Ongoing = false;

		// Token: 0x04003286 RID: 12934
		public static Rectangle ArenaHitbox = default(Rectangle);

		// Token: 0x04003287 RID: 12935
		private static int _arenaHitboxingCooldown = 0;

		// Token: 0x04003288 RID: 12936
		public static int OngoingDifficulty = 0;

		// Token: 0x04003289 RID: 12937
		private static List<Vector2> _deadGoblinSpots = new List<Vector2>();

		// Token: 0x0400328A RID: 12938
		private static int _crystalsDropping_lastWave = 0;

		// Token: 0x0400328B RID: 12939
		private static int _crystalsDropping_toDrop = 0;

		// Token: 0x0400328C RID: 12940
		private static int _crystalsDropping_alreadyDropped = 0;

		// Token: 0x0400328D RID: 12941
		private static int _timeLeftUntilSpawningBegins = 0;
	}
}

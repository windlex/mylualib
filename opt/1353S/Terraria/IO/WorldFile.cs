﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Social;
using Terraria.Utilities;

namespace Terraria.IO
{
	// Token: 0x02000080 RID: 128
	public class WorldFile
	{
		// Token: 0x06000A83 RID: 2691 RVA: 0x003BFC78 File Offset: 0x003BDE78
		public static void CacheSaveTime()
		{
			WorldFile.HasCache = true;
			WorldFile.CachedDayTime = new bool?(Main.dayTime);
			WorldFile.CachedTime = new double?(Main.time);
			WorldFile.CachedMoonPhase = new int?(Main.moonPhase);
			WorldFile.CachedBloodMoon = new bool?(Main.bloodMoon);
			WorldFile.CachedEclipse = new bool?(Main.eclipse);
			WorldFile.CachedCultistDelay = new int?(CultistRitual.delay);
			WorldFile.CachedPartyGenuine = new bool?(BirthdayParty.GenuineParty);
			WorldFile.CachedPartyManual = new bool?(BirthdayParty.ManualParty);
			WorldFile.CachedPartyDaysOnCooldown = new int?(BirthdayParty.PartyDaysOnCooldown);
			WorldFile.CachedCelebratingNPCs.Clear();
			WorldFile.CachedCelebratingNPCs.AddRange(BirthdayParty.CelebratingNPCs);
			WorldFile.Cached_Sandstorm_Happening = new bool?(Sandstorm.Happening);
			WorldFile.Cached_Sandstorm_TimeLeft = new int?(Sandstorm.TimeLeft);
			WorldFile.Cached_Sandstorm_Severity = new float?(Sandstorm.Severity);
			WorldFile.Cached_Sandstorm_IntendedSeverity = new float?(Sandstorm.IntendedSeverity);
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x003C409C File Offset: 0x003C229C
		public static WorldFileData CreateMetadata(string name, bool cloudSave, bool isExpertMode)
		{
			WorldFileData worldFileData = new WorldFileData(Main.GetWorldPathFromName(name, cloudSave), cloudSave);
			worldFileData.Name = name;
			worldFileData.IsExpertMode = isExpertMode;
			worldFileData.CreationTime = DateTime.Now;
			worldFileData.Metadata = FileMetadata.FromCurrentSettings(FileType.World);
			worldFileData.SetFavorite(false, true);
			// worldFileData.WorldGeneratorVersion = 833223655425uL;
			worldFileData.WorldGeneratorVersion = 824633720833UL;
			worldFileData.UniqueId = Guid.NewGuid();
			if (Main.DefaultSeed == "")
			{
				worldFileData.SetSeedToRandom();
			}
			else
			{
				worldFileData.SetSeed(Main.DefaultSeed);
			}
			return worldFileData;
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x003C4220 File Offset: 0x003C2420
		public static void FixDresserChests()
		{
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				for (int j = 0; j < Main.maxTilesY; j++)
				{
					Tile tile = Main.tile[i, j];
					if (tile.active() && tile.type == 88 && tile.frameX % 54 == 0 && tile.frameY % 36 == 0)
					{
						Chest.CreateChest(i, j, -1);
					}
				}
			}
		}

		// Token: 0x06000AA3 RID: 2723 RVA: 0x003C3CE4 File Offset: 0x003C1EE4
		public static WorldFileData GetAllMetadata(string file, bool cloudSave)
		{
			if (file == null || (cloudSave && SocialAPI.Cloud == null))
			{
				return null;
			}
			WorldFileData worldFileData = new WorldFileData(file, cloudSave);
			if (!FileUtilities.Exists(file, cloudSave))
			{
				worldFileData.CreationTime = DateTime.Now;
				worldFileData.Metadata = FileMetadata.FromCurrentSettings(FileType.World);
				return worldFileData;
			}
			try
			{
				using (Stream stream = cloudSave ? (Stream)new MemoryStream(SocialAPI.Cloud.Read(file)) : new FileStream(file, FileMode.Open))
				{
					using (BinaryReader binaryReader = new BinaryReader(stream))
					{
						int num = binaryReader.ReadInt32();
						if (num >= 135)
						{
							worldFileData.Metadata = FileMetadata.Read(binaryReader, FileType.World);
						}
						else
						{
							worldFileData.Metadata = FileMetadata.FromCurrentSettings(FileType.World);
						}
						if (num <= 194)
						{
							binaryReader.ReadInt16();
							stream.Position = (long)binaryReader.ReadInt32();
							worldFileData.Name = binaryReader.ReadString();
							if (num >= 179)
							{
								string seed;
								if (num == 179)
								{
									seed = binaryReader.ReadInt32().ToString();
								}
								else
								{
									seed = binaryReader.ReadString();
								}
								worldFileData.SetSeed(seed);
								worldFileData.WorldGeneratorVersion = binaryReader.ReadUInt64();
							}
							else
							{
								worldFileData.SetSeedToEmpty();
								worldFileData.WorldGeneratorVersion = 0uL;
							}
							if (num >= 181)
							{
								worldFileData.UniqueId = new Guid(binaryReader.ReadBytes(16));
							}
							else
							{
								worldFileData.UniqueId = Guid.Empty;
							}
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							int y = binaryReader.ReadInt32();
							int x = binaryReader.ReadInt32();
							worldFileData.SetWorldSize(x, y);
							worldFileData.IsExpertMode = (num >= 112 && binaryReader.ReadBoolean());
							if (num >= 141)
							{
								worldFileData.CreationTime = DateTime.FromBinary(binaryReader.ReadInt64());
							}
							else if (!cloudSave)
							{
								worldFileData.CreationTime = File.GetCreationTime(file);
							}
							else
							{
								worldFileData.CreationTime = DateTime.Now;
							}
							binaryReader.ReadByte();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadDouble();
							binaryReader.ReadDouble();
							binaryReader.ReadDouble();
							binaryReader.ReadBoolean();
							binaryReader.ReadInt32();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							worldFileData.HasCrimson = binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							if (num >= 118)
							{
								binaryReader.ReadBoolean();
							}
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadByte();
							binaryReader.ReadInt32();
							worldFileData.IsHardMode = binaryReader.ReadBoolean();
							return worldFileData;
						}
					}
				}
			}
			catch (Exception)
			{
			}
			return null;
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x003C4124 File Offset: 0x003C2324
		public static FileMetadata GetFileMetadata(string file, bool cloudSave)
		{
			if (file == null)
			{
				return null;
			}
			try
			{
				byte[] buffer = null;
				bool expr_16 = cloudSave && SocialAPI.Cloud != null;
				if (expr_16)
				{
					int num = 24;
					buffer = new byte[num];
					SocialAPI.Cloud.Read(file, buffer, num);
				}
				using (Stream stream = expr_16 ? (Stream)new MemoryStream(buffer) : new FileStream(file, FileMode.Open))
				{
					using (BinaryReader binaryReader = new BinaryReader(stream))
					{
						FileMetadata result;
						if (binaryReader.ReadInt32() >= 135)
						{
							result = FileMetadata.Read(binaryReader, FileType.World);
							return result;
						}
						result = FileMetadata.FromCurrentSettings(FileType.World);
						return result;
					}
				}
			}
			catch
			{
			}
			return null;
		}

		// Token: 0x06000AA1 RID: 2721 RVA: 0x003C3BE8 File Offset: 0x003C1DE8
		public static bool GetWorldDifficulty(string WorldFileName)
		{
			if (WorldFileName == null)
			{
				return false;
			}
			try
			{
				using (FileStream fileStream = new FileStream(WorldFileName, FileMode.Open))
				{
					using (BinaryReader binaryReader = new BinaryReader(fileStream))
					{
						int num = binaryReader.ReadInt32();
						if (num >= 135)
						{
							binaryReader.BaseStream.Position += 20L;
						}
						if (num >= 112 && num <= 194)
						{
							binaryReader.ReadInt16();
							fileStream.Position = (long)binaryReader.ReadInt32();
							binaryReader.ReadString();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							return binaryReader.ReadBoolean();
						}
					}
				}
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x003C3AE4 File Offset: 0x003C1CE4
		public static string GetWorldName(string WorldFileName)
		{
			if (WorldFileName == null)
			{
				return string.Empty;
			}
			try
			{
				using (FileStream fileStream = new FileStream(WorldFileName, FileMode.Open))
				{
					using (BinaryReader binaryReader = new BinaryReader(fileStream))
					{
						int num = binaryReader.ReadInt32();
						if (num > 0 && num <= 194)
						{
							string result;
							if (num <= 87)
							{
								string arg_3D_0 = binaryReader.ReadString();
								binaryReader.Close();
								result = arg_3D_0;
								return result;
							}
							if (num >= 135)
							{
								binaryReader.BaseStream.Position += 20L;
							}
							binaryReader.ReadInt16();
							fileStream.Position = (long)binaryReader.ReadInt32();
							string arg_81_0 = binaryReader.ReadString();
							binaryReader.Close();
							result = arg_81_0;
							return result;
						}
					}
				}
			}
			catch
			{
			}
			string[] expr_B6 = WorldFileName.Split(new char[]
			{
				Path.DirectorySeparatorChar
			});
			string text = expr_B6[expr_B6.Length - 1];
			return text.Substring(0, text.Length - 4);
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x003C3CD8 File Offset: 0x003C1ED8
		public static bool IsValidWorld(string file, bool cloudSave)
		{
			return WorldFile.GetFileMetadata(file, cloudSave) != null;
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x003C31A4 File Offset: 0x003C13A4
		private static void LoadChests(BinaryReader reader)
		{
			int num = (int)reader.ReadInt16();
			int num2 = (int)reader.ReadInt16();
			int num3;
			int num4;
			if (num2 < 40)
			{
				num3 = num2;
				num4 = 0;
			}
			else
			{
				num3 = 40;
				num4 = num2 - 40;
			}
			int i;
			for (i = 0; i < num; i++)
			{
				Chest chest = new Chest(false);
				chest.x = reader.ReadInt32();
				chest.y = reader.ReadInt32();
				chest.name = reader.ReadString();
				for (int j = 0; j < num3; j++)
				{
					short num5 = reader.ReadInt16();
					Item item = new Item();
					if (num5 > 0)
					{
						item.netDefaults(reader.ReadInt32());
						item.stack = (int)num5;
						item.Prefix((int)reader.ReadByte());
					}
					else if (num5 < 0)
					{
						item.netDefaults(reader.ReadInt32());
						item.Prefix((int)reader.ReadByte());
						item.stack = 1;
					}
					chest.item[j] = item;
				}
				for (int j = 0; j < num4; j++)
				{
					short num5 = reader.ReadInt16();
					if (num5 > 0)
					{
						reader.ReadInt32();
						reader.ReadByte();
					}
				}
				Main.chest[i] = chest;
			}
			List<Point16> list = new List<Point16>();
			for (int k = 0; k < i; k++)
			{
				if (Main.chest[k] != null)
				{
					Point16 item2 = new Point16(Main.chest[k].x, Main.chest[k].y);
					if (list.Contains(item2))
					{
						Main.chest[k] = null;
					}
					else
					{
						list.Add(item2);
					}
				}
			}
			while (i < 1000)
			{
				Main.chest[i] = null;
				i++;
			}
			if (WorldFile.versionNumber < 115)
			{
				WorldFile.FixDresserChests();
			}
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x003C3448 File Offset: 0x003C1648
		private static void LoadDummies(BinaryReader reader)
		{
			int num = reader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				DeprecatedClassLeftInForLoading.dummies[i] = new DeprecatedClassLeftInForLoading((int)reader.ReadInt16(), (int)reader.ReadInt16());
			}
			for (int j = num; j < 1000; j++)
			{
				DeprecatedClassLeftInForLoading.dummies[j] = null;
			}
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x003C259C File Offset: 0x003C079C
		private static bool LoadFileFormatHeader(BinaryReader reader, out bool[] importance, out int[] positions)
		{
			importance = null;
			positions = null;
			if ((WorldFile.versionNumber = reader.ReadInt32()) >= 135)
			{
				try
				{
					Main.WorldFileMetadata = FileMetadata.Read(reader, FileType.World);
					goto IL_4B;
				}
				catch (FileFormatException arg_36_0)
				{
					Console.WriteLine(Language.GetTextValue("Error.UnableToLoadWorld"));
					Console.WriteLine(arg_36_0);
					return false;
				}
			}
			Main.WorldFileMetadata = FileMetadata.FromCurrentSettings(FileType.World);
			IL_4B:
			short num = reader.ReadInt16();
			positions = new int[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				positions[i] = reader.ReadInt32();
			}
			short num2 = reader.ReadInt16();
			importance = new bool[(int)num2];
			byte b = 0;
			byte b2 = 128;
			for (int i = 0; i < (int)num2; i++)
			{
				if (b2 == 128)
				{
					b = reader.ReadByte();
					b2 = 1;
				}
				else
				{
					b2 = (byte)(b2 << 1);
				}
				if ((b & b2) == b2)
				{
					importance[i] = true;
				}
			}
			return true;
		}

		// Token: 0x06000A9E RID: 2718 RVA: 0x003C35C0 File Offset: 0x003C17C0
		private static int LoadFooter(BinaryReader reader)
		{
			if (!reader.ReadBoolean())
			{
				return 6;
			}
			if (reader.ReadString() != Main.worldName)
			{
				return 6;
			}
			if (reader.ReadInt32() != Main.worldID)
			{
				return 6;
			}
			return 0;
		}

		// Token: 0x06000A98 RID: 2712 RVA: 0x003C267C File Offset: 0x003C087C
		private static void LoadHeader(BinaryReader reader)
		{
			int num = WorldFile.versionNumber;
			Main.worldName = reader.ReadString();
			if (num >= 179)
			{
				string seed;
				if (num == 179)
				{
					seed = reader.ReadInt32().ToString();
				}
				else
				{
					seed = reader.ReadString();
				}
				Main.ActiveWorldFileData.SetSeed(seed);
				Main.ActiveWorldFileData.WorldGeneratorVersion = reader.ReadUInt64();
			}
			if (num >= 181)
			{
				Main.ActiveWorldFileData.UniqueId = new Guid(reader.ReadBytes(16));
			}
			else
			{
				Main.ActiveWorldFileData.UniqueId = Guid.NewGuid();
			}
			Main.worldID = reader.ReadInt32();
			Main.leftWorld = (float)reader.ReadInt32();
			Main.rightWorld = (float)reader.ReadInt32();
			Main.topWorld = (float)reader.ReadInt32();
			Main.bottomWorld = (float)reader.ReadInt32();
			Main.maxTilesY = reader.ReadInt32();
			Main.maxTilesX = reader.ReadInt32();
			WorldGen.clearWorld();
			if (num >= 112)
			{
				Main.expertMode = reader.ReadBoolean();
			}
			else
			{
				Main.expertMode = false;
			}
			if (num >= 141)
			{
				Main.ActiveWorldFileData.CreationTime = DateTime.FromBinary(reader.ReadInt64());
			}
			Main.moonType = (int)reader.ReadByte();
			Main.treeX[0] = reader.ReadInt32();
			Main.treeX[1] = reader.ReadInt32();
			Main.treeX[2] = reader.ReadInt32();
			Main.treeStyle[0] = reader.ReadInt32();
			Main.treeStyle[1] = reader.ReadInt32();
			Main.treeStyle[2] = reader.ReadInt32();
			Main.treeStyle[3] = reader.ReadInt32();
			Main.caveBackX[0] = reader.ReadInt32();
			Main.caveBackX[1] = reader.ReadInt32();
			Main.caveBackX[2] = reader.ReadInt32();
			Main.caveBackStyle[0] = reader.ReadInt32();
			Main.caveBackStyle[1] = reader.ReadInt32();
			Main.caveBackStyle[2] = reader.ReadInt32();
			Main.caveBackStyle[3] = reader.ReadInt32();
			Main.iceBackStyle = reader.ReadInt32();
			Main.jungleBackStyle = reader.ReadInt32();
			Main.hellBackStyle = reader.ReadInt32();
			Main.spawnTileX = reader.ReadInt32();
			Main.spawnTileY = reader.ReadInt32();
			Main.worldSurface = reader.ReadDouble();
			Main.rockLayer = reader.ReadDouble();
			WorldFile.tempTime = reader.ReadDouble();
			WorldFile.tempDayTime = reader.ReadBoolean();
			WorldFile.tempMoonPhase = reader.ReadInt32();
			WorldFile.tempBloodMoon = reader.ReadBoolean();
			WorldFile.tempEclipse = reader.ReadBoolean();
			Main.eclipse = WorldFile.tempEclipse;
			Main.dungeonX = reader.ReadInt32();
			Main.dungeonY = reader.ReadInt32();
			WorldGen.crimson = reader.ReadBoolean();
			NpcMgr.downedBoss1 = reader.ReadBoolean();
			NpcMgr.downedBoss2 = reader.ReadBoolean();
			NpcMgr.downedBoss3 = reader.ReadBoolean();
			NpcMgr.downedQueenBee = reader.ReadBoolean();
			NpcMgr.downedMechBoss1 = reader.ReadBoolean();
			NpcMgr.downedMechBoss2 = reader.ReadBoolean();
			NpcMgr.downedMechBoss3 = reader.ReadBoolean();
			NpcMgr.downedMechBossAny = reader.ReadBoolean();
			NpcMgr.downedPlantBoss = reader.ReadBoolean();
			NpcMgr.downedGolemBoss = reader.ReadBoolean();
			if (num >= 118)
			{
				NpcMgr.downedSlimeKing = reader.ReadBoolean();
			}
            NpcMgr.savedGoblin = reader.ReadBoolean();
            NpcMgr.savedWizard = reader.ReadBoolean();
            NpcMgr.savedMech = reader.ReadBoolean();
			NpcMgr.downedGoblins = reader.ReadBoolean();
			NpcMgr.downedClown = reader.ReadBoolean();
			NpcMgr.downedFrost = reader.ReadBoolean();
			NpcMgr.downedPirates = reader.ReadBoolean();
			WorldGen.shadowOrbSmashed = reader.ReadBoolean();
			WorldGen.spawnMeteor = reader.ReadBoolean();
			WorldGen.shadowOrbCount = (int)reader.ReadByte();
			WorldGen.altarCount = reader.ReadInt32();
			Main.hardMode = reader.ReadBoolean();
			Main.invasionDelay = reader.ReadInt32();
			Main.invasionSize = reader.ReadInt32();
			Main.invasionType = reader.ReadInt32();
			Main.invasionX = reader.ReadDouble();
			if (num >= 118)
			{
				Main.slimeRainTime = reader.ReadDouble();
			}
			if (num >= 113)
			{
				Main.sundialCooldown = (int)reader.ReadByte();
			}
			WorldFile.tempRaining = reader.ReadBoolean();
			WorldFile.tempRainTime = reader.ReadInt32();
			WorldFile.tempMaxRain = reader.ReadSingle();
			WorldGen.oreTier1 = reader.ReadInt32();
			WorldGen.oreTier2 = reader.ReadInt32();
			WorldGen.oreTier3 = reader.ReadInt32();
			WorldGen.setBG(0, (int)reader.ReadByte());
			WorldGen.setBG(1, (int)reader.ReadByte());
			WorldGen.setBG(2, (int)reader.ReadByte());
			WorldGen.setBG(3, (int)reader.ReadByte());
			WorldGen.setBG(4, (int)reader.ReadByte());
			WorldGen.setBG(5, (int)reader.ReadByte());
			WorldGen.setBG(6, (int)reader.ReadByte());
			WorldGen.setBG(7, (int)reader.ReadByte());
			Main.cloudBGActive = (float)reader.ReadInt32();
			Main.cloudBGAlpha = (((double)Main.cloudBGActive < 1.0) ? 0f : 1f);
			Main.cloudBGActive = (float)(-(float)WorldGen.genRand.Next(8640, 86400));
			Main.numClouds = (int)reader.ReadInt16();
			Main.windSpeedSet = reader.ReadSingle();
			Main.windSpeed = Main.windSpeedSet;
			if (num < 95)
			{
				return;
			}
			Main.anglerWhoFinishedToday.Clear();
			for (int i = reader.ReadInt32(); i > 0; i--)
			{
				Main.anglerWhoFinishedToday.Add(reader.ReadString());
			}
			if (num < 99)
			{
				return;
			}
			NpcMgr.savedAngler = reader.ReadBoolean();
			if (num < 101)
			{
				return;
			}
			Main.anglerQuest = reader.ReadInt32();
			if (num < 104)
			{
				return;
			}
			NpcMgr.savedStylist = reader.ReadBoolean();
			if (num >= 129)
			{
				NpcMgr.savedTaxCollector = reader.ReadBoolean();
			}
			if (num < 107)
			{
				if (Main.invasionType > 0 && Main.invasionSize > 0)
				{
					Main.FakeLoadInvasionStart();
				}
			}
			else
			{
				Main.invasionSizeStart = reader.ReadInt32();
			}
			if (num < 108)
			{
				WorldFile.tempCultistDelay = 86400;
			}
			else
			{
				WorldFile.tempCultistDelay = reader.ReadInt32();
			}
			if (num < 109)
			{
				return;
			}
			int num2 = (int)reader.ReadInt16();
			for (int j = 0; j < num2; j++)
			{
				if (j < 580)
				{
					NPC.killCount[j] = reader.ReadInt32();
				}
				else
				{
					reader.ReadInt32();
				}
			}
			if (num < 128)
			{
				return;
			}
			Main.fastForwardTime = reader.ReadBoolean();
			Main.UpdateSundial();
			if (num < 131)
			{
				return;
			}
			NpcMgr.downedFishron = reader.ReadBoolean();
			NpcMgr.downedMartians = reader.ReadBoolean();
			NpcMgr.downedAncientCultist = reader.ReadBoolean();
			NpcMgr.downedMoonlord = reader.ReadBoolean();
			NpcMgr.downedHalloweenKing = reader.ReadBoolean();
			NpcMgr.downedHalloweenTree = reader.ReadBoolean();
			NpcMgr.downedChristmasIceQueen = reader.ReadBoolean();
			NpcMgr.downedChristmasSantank = reader.ReadBoolean();
			NpcMgr.downedChristmasTree = reader.ReadBoolean();
			if (num < 140)
			{
				return;
			}
			NpcMgr.downedTowerSolar = reader.ReadBoolean();
			NpcMgr.downedTowerVortex = reader.ReadBoolean();
			NpcMgr.downedTowerNebula = reader.ReadBoolean();
			NpcMgr.downedTowerStardust = reader.ReadBoolean();
			NpcMgr.TowerActiveSolar = reader.ReadBoolean();
			NpcMgr.TowerActiveVortex = reader.ReadBoolean();
			NpcMgr.TowerActiveNebula = reader.ReadBoolean();
			NpcMgr.TowerActiveStardust = reader.ReadBoolean();
			NPC.LunarApocalypseIsUp = reader.ReadBoolean();
			if (NpcMgr.TowerActiveSolar)
			{
				NpcMgr.ShieldStrengthTowerSolar = NpcMgr.ShieldStrengthTowerMax;
			}
			if (NpcMgr.TowerActiveVortex)
			{
				NpcMgr.ShieldStrengthTowerVortex = NpcMgr.ShieldStrengthTowerMax;
			}
			if (NpcMgr.TowerActiveNebula)
			{
				NpcMgr.ShieldStrengthTowerNebula = NpcMgr.ShieldStrengthTowerMax;
			}
			if (NpcMgr.TowerActiveStardust)
			{
				NpcMgr.ShieldStrengthTowerStardust = NpcMgr.ShieldStrengthTowerMax;
			}
			if (num < 170)
			{
				WorldFile.tempPartyManual = false;
				WorldFile.tempPartyGenuine = false;
				WorldFile.tempPartyCooldown = 0;
				WorldFile.tempPartyCelebratingNPCs.Clear();
			}
			else
			{
				WorldFile.tempPartyManual = reader.ReadBoolean();
				WorldFile.tempPartyGenuine = reader.ReadBoolean();
				WorldFile.tempPartyCooldown = reader.ReadInt32();
				int num3 = reader.ReadInt32();
				WorldFile.tempPartyCelebratingNPCs.Clear();
				for (int k = 0; k < num3; k++)
				{
					WorldFile.tempPartyCelebratingNPCs.Add(reader.ReadInt32());
				}
			}
			if (num < 174)
			{
				WorldFile.Temp_Sandstorm_Happening = false;
				WorldFile.Temp_Sandstorm_TimeLeft = 0;
				WorldFile.Temp_Sandstorm_Severity = 0f;
				WorldFile.Temp_Sandstorm_IntendedSeverity = 0f;
			}
			else
			{
				WorldFile.Temp_Sandstorm_Happening = reader.ReadBoolean();
				WorldFile.Temp_Sandstorm_TimeLeft = reader.ReadInt32();
				WorldFile.Temp_Sandstorm_Severity = reader.ReadSingle();
				WorldFile.Temp_Sandstorm_IntendedSeverity = reader.ReadSingle();
			}
			DD2Event.Load(reader, num);
		}

		// Token: 0x06000A9D RID: 2717 RVA: 0x003C3498 File Offset: 0x003C1698
		private static void LoadNPCs(BinaryReader reader)
		{
			int num = 0;
			bool flag = reader.ReadBoolean();
			while (flag)
			{
				NPC nPC = Main.npc[num];
				if (WorldFile.versionNumber >= 190)
				{
					nPC.SetDefaults(reader.ReadInt32(), -1f);
				}
				else
				{
					nPC.SetDefaults(NPCID.FromLegacyName(reader.ReadString()), -1f);
				}
				nPC.GivenName = reader.ReadString();
				nPC.position.X = reader.ReadSingle();
				nPC.position.Y = reader.ReadSingle();
				nPC.homeless = reader.ReadBoolean();
				nPC.homeTileX = reader.ReadInt32();
				nPC.homeTileY = reader.ReadInt32();
				num++;
				flag = reader.ReadBoolean();
			}
			if (WorldFile.versionNumber < 140)
			{
				return;
			}
			flag = reader.ReadBoolean();
			while (flag)
			{
				NPC nPC = Main.npc[num];
				if (WorldFile.versionNumber >= 190)
				{
					nPC.SetDefaults(reader.ReadInt32(), -1f);
				}
				else
				{
					nPC.SetDefaults(NPCID.FromLegacyName(reader.ReadString()), -1f);
				}
				nPC.position = reader.ReadVector2();
				num++;
				flag = reader.ReadBoolean();
			}
		}

		// Token: 0x06000A9B RID: 2715 RVA: 0x003C3344 File Offset: 0x003C1544
		private static void LoadSigns(BinaryReader reader)
		{
			short num = reader.ReadInt16();
			int i;
			for (i = 0; i < (int)num; i++)
			{
				string text = reader.ReadString();
				int num2 = reader.ReadInt32();
				int num3 = reader.ReadInt32();
				Tile tile = Main.tile[num2, num3];
				Sign sign;
				if (tile.active() && Main.tileSign[(int)tile.type])
				{
					sign = new Sign();
					sign.text = text;
					sign.x = num2;
					sign.y = num3;
				}
				else
				{
					sign = null;
				}
				Main.sign[i] = sign;
			}
			List<Point16> list = new List<Point16>();
			for (int j = 0; j < 1000; j++)
			{
				if (Main.sign[j] != null)
				{
					Point16 item = new Point16(Main.sign[j].x, Main.sign[j].y);
					if (list.Contains(item))
					{
						Main.sign[j] = null;
					}
					else
					{
						list.Add(item);
					}
				}
			}
			while (i < 1000)
			{
				Main.sign[i] = null;
				i++;
			}
		}

		// Token: 0x06000AA9 RID: 2729 RVA: 0x003C4304 File Offset: 0x003C2504
		private static void LoadTileEntities(BinaryReader reader)
		{
			TileEntity.ByID.Clear();
			TileEntity.ByPosition.Clear();
			int num = reader.ReadInt32();
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				TileEntity tileEntity = TileEntity.Read(reader, false);
				tileEntity.ID = num2++;
				TileEntity.ByID[tileEntity.ID] = tileEntity;
				TileEntity tileEntity2;
				if (TileEntity.ByPosition.TryGetValue(tileEntity.Position, out tileEntity2))
				{
					TileEntity.ByID.Remove(tileEntity2.ID);
				}
				TileEntity.ByPosition[tileEntity.Position] = tileEntity;
			}
			TileEntity.TileEntitiesNextID = num;
			List<Point16> list = new List<Point16>();
			foreach (KeyValuePair<Point16, TileEntity> current in TileEntity.ByPosition)
			{
				if (!WorldGen.InWorld((int)current.Value.Position.X, (int)current.Value.Position.Y, 1))
				{
					list.Add(current.Value.Position);
				}
				else
				{
					if (current.Value.type == 0 && !TETrainingDummy.ValidTile((int)current.Value.Position.X, (int)current.Value.Position.Y))
					{
						list.Add(current.Value.Position);
					}
					if (current.Value.type == 2 && !TELogicSensor.ValidTile((int)current.Value.Position.X, (int)current.Value.Position.Y))
					{
						list.Add(current.Value.Position);
					}
					if (current.Value.type == 1 && !TEItemFrame.ValidTile((int)current.Value.Position.X, (int)current.Value.Position.Y))
					{
						list.Add(current.Value.Position);
					}
				}
			}
			try
			{
				foreach (Point16 current2 in list)
				{
					TileEntity tileEntity3 = TileEntity.ByPosition[current2];
					if (TileEntity.ByID.ContainsKey(tileEntity3.ID))
					{
						TileEntity.ByID.Remove(tileEntity3.ID);
					}
					if (TileEntity.ByPosition.ContainsKey(current2))
					{
						TileEntity.ByPosition.Remove(current2);
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000AAD RID: 2733 RVA: 0x003C46C0 File Offset: 0x003C28C0
		private static void LoadTownManager(BinaryReader reader)
		{
			WorldGen.TownManager.Load(reader);
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x003C4654 File Offset: 0x003C2854
		private static void LoadWeightedPressurePlates(BinaryReader reader)
		{
			PressurePlateHelper.Reset();
			PressurePlateHelper.NeedsFirstUpdate = true;
			int num = reader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				Point key = new Point(reader.ReadInt32(), reader.ReadInt32());
				PressurePlateHelper.PressurePlatesPressed.Add(key, new bool[255]);
			}
		}

		// Token: 0x06000A88 RID: 2696 RVA: 0x003C004C File Offset: 0x003BE24C
		public static void loadWorld(bool loadFromCloud)
		{
			WorldFile.IsWorldOnCloud = loadFromCloud;
			Main.checkXMas();
			Main.checkHalloween();
			bool flag = loadFromCloud && SocialAPI.Cloud != null;
			if (!FileUtilities.Exists(Main.worldPathName, flag) && Main.autoGen)
			{
				if (!flag)
				{
					for (int i = Main.worldPathName.Length - 1; i >= 0; i--)
					{
						if (Main.worldPathName.Substring(i, 1) == (Path.DirectorySeparatorChar.ToString() ?? ""))
						{
							Directory.CreateDirectory(Main.worldPathName.Substring(0, i));
							break;
						}
					}
				}
				WorldGen.clearWorld();
				Main.ActiveWorldFileData = WorldFile.CreateMetadata((Main.worldName == "") ? "World" : Main.worldName, flag, Main.expertMode);
				string text = (Main.AutogenSeedName ?? "").Trim();
				if (text.Length == 0)
				{
					Main.ActiveWorldFileData.SetSeedToRandom();
				}
				else
				{
					Main.ActiveWorldFileData.SetSeed(text);
				}
				WorldGen.generateWorld(Main.ActiveWorldFileData.Seed, Main.AutogenProgress);
				WorldFile.saveWorld();
			}
			using (MemoryStream memoryStream = new MemoryStream(FileUtilities.ReadAllBytes(Main.worldPathName, flag)))
			{
				using (BinaryReader binaryReader = new BinaryReader(memoryStream))
				{
					try
					{
						WorldGen.loadFailed = false;
						WorldGen.loadSuccess = false;
						int expr_13C = WorldFile.versionNumber = binaryReader.ReadInt32();
						int num;
						if (expr_13C <= 87)
						{
							num = WorldFile.LoadWorld_Version1(binaryReader);
						}
						else
						{
							num = WorldFile.LoadWorld_Version2(binaryReader);
						}
						if (expr_13C < 141)
						{
							if (!loadFromCloud)
							{
								Main.ActiveWorldFileData.CreationTime = File.GetCreationTime(Main.worldPathName);
							}
							else
							{
								Main.ActiveWorldFileData.CreationTime = DateTime.Now;
							}
						}
						binaryReader.Close();
						memoryStream.Close();
						if (num != 0)
						{
							WorldGen.loadFailed = true;
						}
						else
						{
							WorldGen.loadSuccess = true;
						}
						if (WorldGen.loadFailed || !WorldGen.loadSuccess)
						{
							return;
						}
						WorldGen.gen = true;
						WorldGen.waterLine = Main.maxTilesY;
						Liquid.QuickWater(2, -1, -1);
						WorldGen.WaterCheck();
						int num2 = 0;
						Liquid.quickSettle = true;
						int num3 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
						float num4 = 0f;
						while (Liquid.numLiquid > 0 && num2 < 100000)
						{
							num2++;
							float num5 = (float)(num3 - (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer)) / (float)num3;
							if (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer > num3)
							{
								num3 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
							}
							if (num5 > num4)
							{
								num4 = num5;
							}
							else
							{
								num5 = num4;
							}
							Main.statusText = string.Concat(new object[]
							{
								Lang.gen[27].Value,
								" ",
								(int)(num5 * 100f / 2f + 50f),
								"%"
							});
							Liquid.UpdateLiquid();
						}
						Liquid.quickSettle = false;
						Main.weatherCounter = WorldGen.genRand.Next(3600, 18000);
						Cloud.resetClouds();
						WorldGen.WaterCheck();
						WorldGen.gen = false;
						NPC.setFireFlyChance();
						Main.InitLifeBytes();
						if (Main.slimeRainTime > 0.0)
						{
							Main.StartSlimeRain(false);
						}
						NPC.setWorldMonsters();
					}
					catch
					{
						WorldGen.loadFailed = true;
						WorldGen.loadSuccess = false;
						try
						{
							binaryReader.Close();
							memoryStream.Close();
						}
						catch
						{
						}
						return;
					}
				}
			}
			if (WorldFile.OnWorldLoad != null)
			{
				WorldFile.OnWorldLoad();
			}
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x003C2E68 File Offset: 0x003C1068
		private static void LoadWorldTiles(BinaryReader reader, bool[] importance)
		{
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				float num = (float)i / (float)Main.maxTilesX;
				Main.statusText = string.Concat(new object[]
				{
					Lang.gen[51].Value,
					" ",
					(int)((double)num * 100.0 + 1.0),
					"%"
				});
				for (int j = 0; j < Main.maxTilesY; j++)
				{
					int num2 = -1;
					byte b2;
					byte b = b2 = 0;
					Tile tile = Main.tile[i, j];
					byte b3 = reader.ReadByte();
					if ((b3 & 1) == 1)
					{
						b2 = reader.ReadByte();
						if ((b2 & 1) == 1)
						{
							b = reader.ReadByte();
						}
					}
					byte b4;
					if ((b3 & 2) == 2)
					{
						tile.active(true);
						if ((b3 & 32) == 32)
						{
							b4 = reader.ReadByte();
							num2 = (int)reader.ReadByte();
							num2 = (num2 << 8 | (int)b4);
						}
						else
						{
							num2 = (int)reader.ReadByte();
						}
						tile.type = (ushort)num2;
						if (importance[num2])
						{
							tile.frameX = reader.ReadInt16();
							tile.frameY = reader.ReadInt16();
							if (tile.type == 144)
							{
								tile.frameY = 0;
							}
						}
						else
						{
							tile.frameX = -1;
							tile.frameY = -1;
						}
						if ((b & 8) == 8)
						{
							tile.color(reader.ReadByte());
						}
					}
					if ((b3 & 4) == 4)
					{
						tile.wall = reader.ReadByte();
						if ((b & 16) == 16)
						{
							tile.wallColor(reader.ReadByte());
						}
					}
					b4 = (byte)((b3 & 24) >> 3);
					if (b4 != 0)
					{
						tile.liquid = reader.ReadByte();
						if (b4 > 1)
						{
							if (b4 == 2)
							{
								tile.lava(true);
							}
							else
							{
								tile.honey(true);
							}
						}
					}
					if (b2 > 1)
					{
						if ((b2 & 2) == 2)
						{
							tile.wire(true);
						}
						if ((b2 & 4) == 4)
						{
							tile.wire2(true);
						}
						if ((b2 & 8) == 8)
						{
							tile.wire3(true);
						}
						b4 = (byte)((b2 & 112) >> 4);
						if (b4 != 0 && Main.tileSolid[(int)tile.type])
						{
							if (b4 == 1)
							{
								tile.halfBrick(true);
							}
							else
							{
								tile.slope((byte)(b4 - 1));
							}
						}
					}
					if (b > 0)
					{
						if ((b & 2) == 2)
						{
							tile.actuator(true);
						}
						if ((b & 4) == 4)
						{
							tile.inActive(true);
						}
						if ((b & 32) == 32)
						{
							tile.wire4(true);
						}
					}
					b4 = (byte)((b3 & 192) >> 6);
					int k;
					if (b4 == 0)
					{
						k = 0;
					}
					else if (b4 == 1)
					{
						k = (int)reader.ReadByte();
					}
					else
					{
						k = (int)reader.ReadInt16();
					}
					if (num2 != -1)
					{
						if ((double)j <= Main.worldSurface)
						{
							if ((double)(j + k) <= Main.worldSurface)
							{
								WorldGen.tileCounts[num2] += (k + 1) * 5;
							}
							else
							{
								int num3 = (int)(Main.worldSurface - (double)j + 1.0);
								int num4 = k + 1 - num3;
								WorldGen.tileCounts[num2] += num3 * 5 + num4;
							}
						}
						else
						{
							WorldGen.tileCounts[num2] += k + 1;
						}
					}
					while (k > 0)
					{
						j++;
						Main.tile[i, j].CopyFrom(tile);
						k--;
					}
				}
			}
			WorldGen.AddUpAlignmentCounts(true);
			if (WorldFile.versionNumber < 105)
			{
				WorldGen.FixHearts();
			}
		}

		// Token: 0x06000A8B RID: 2699 RVA: 0x003C068C File Offset: 0x003BE88C
		public static int LoadWorld_Version1(BinaryReader fileIO)
		{
			Main.WorldFileMetadata = FileMetadata.FromCurrentSettings(FileType.World);
			int num = WorldFile.versionNumber;
			if (num > 194)
			{
				return 1;
			}
			Main.worldName = fileIO.ReadString();
			Main.worldID = fileIO.ReadInt32();
			Main.leftWorld = (float)fileIO.ReadInt32();
			Main.rightWorld = (float)fileIO.ReadInt32();
			Main.topWorld = (float)fileIO.ReadInt32();
			Main.bottomWorld = (float)fileIO.ReadInt32();
			Main.maxTilesY = fileIO.ReadInt32();
			Main.maxTilesX = fileIO.ReadInt32();
			if (num >= 112)
			{
				Main.expertMode = fileIO.ReadBoolean();
			}
			else
			{
				Main.expertMode = false;
			}
			if (num >= 63)
			{
				Main.moonType = (int)fileIO.ReadByte();
			}
			else
			{
				WorldGen.RandomizeMoonState();
			}
			WorldGen.clearWorld();
			if (num >= 44)
			{
				Main.treeX[0] = fileIO.ReadInt32();
				Main.treeX[1] = fileIO.ReadInt32();
				Main.treeX[2] = fileIO.ReadInt32();
				Main.treeStyle[0] = fileIO.ReadInt32();
				Main.treeStyle[1] = fileIO.ReadInt32();
				Main.treeStyle[2] = fileIO.ReadInt32();
				Main.treeStyle[3] = fileIO.ReadInt32();
			}
			if (num >= 60)
			{
				Main.caveBackX[0] = fileIO.ReadInt32();
				Main.caveBackX[1] = fileIO.ReadInt32();
				Main.caveBackX[2] = fileIO.ReadInt32();
				Main.caveBackStyle[0] = fileIO.ReadInt32();
				Main.caveBackStyle[1] = fileIO.ReadInt32();
				Main.caveBackStyle[2] = fileIO.ReadInt32();
				Main.caveBackStyle[3] = fileIO.ReadInt32();
				Main.iceBackStyle = fileIO.ReadInt32();
				if (num >= 61)
				{
					Main.jungleBackStyle = fileIO.ReadInt32();
					Main.hellBackStyle = fileIO.ReadInt32();
				}
			}
			else
			{
				WorldGen.RandomizeCaveBackgrounds();
			}
			Main.spawnTileX = fileIO.ReadInt32();
			Main.spawnTileY = fileIO.ReadInt32();
			Main.worldSurface = fileIO.ReadDouble();
			Main.rockLayer = fileIO.ReadDouble();
			WorldFile.tempTime = fileIO.ReadDouble();
			WorldFile.tempDayTime = fileIO.ReadBoolean();
			WorldFile.tempMoonPhase = fileIO.ReadInt32();
			WorldFile.tempBloodMoon = fileIO.ReadBoolean();
			if (num >= 70)
			{
				WorldFile.tempEclipse = fileIO.ReadBoolean();
				Main.eclipse = WorldFile.tempEclipse;
			}
			Main.dungeonX = fileIO.ReadInt32();
			Main.dungeonY = fileIO.ReadInt32();
			if (num >= 56)
			{
				WorldGen.crimson = fileIO.ReadBoolean();
			}
			else
			{
				WorldGen.crimson = false;
			}
			NpcMgr.downedBoss1 = fileIO.ReadBoolean();
			NpcMgr.downedBoss2 = fileIO.ReadBoolean();
			NpcMgr.downedBoss3 = fileIO.ReadBoolean();
			if (num >= 66)
			{
				NpcMgr.downedQueenBee = fileIO.ReadBoolean();
			}
			if (num >= 44)
			{
				NpcMgr.downedMechBoss1 = fileIO.ReadBoolean();
				NpcMgr.downedMechBoss2 = fileIO.ReadBoolean();
				NpcMgr.downedMechBoss3 = fileIO.ReadBoolean();
				NpcMgr.downedMechBossAny = fileIO.ReadBoolean();
			}
			if (num >= 64)
			{
				NpcMgr.downedPlantBoss = fileIO.ReadBoolean();
				NpcMgr.downedGolemBoss = fileIO.ReadBoolean();
			}
			if (num >= 29)
			{
				NpcMgr.savedGoblin = fileIO.ReadBoolean();
				NpcMgr.savedWizard = fileIO.ReadBoolean();
				if (num >= 34)
				{
					NpcMgr.savedMech = fileIO.ReadBoolean();
					if (num >= 80)
					{
						NpcMgr.savedStylist = fileIO.ReadBoolean();
					}
				}
				if (num >= 129)
				{
					NpcMgr.savedTaxCollector = fileIO.ReadBoolean();
				}
				NpcMgr.downedGoblins = fileIO.ReadBoolean();
			}
			if (num >= 32)
			{
				NpcMgr.downedClown = fileIO.ReadBoolean();
			}
			if (num >= 37)
			{
				NpcMgr.downedFrost = fileIO.ReadBoolean();
			}
			if (num >= 56)
			{
				NpcMgr.downedPirates = fileIO.ReadBoolean();
			}
			WorldGen.shadowOrbSmashed = fileIO.ReadBoolean();
			WorldGen.spawnMeteor = fileIO.ReadBoolean();
			WorldGen.shadowOrbCount = (int)fileIO.ReadByte();
			if (num >= 23)
			{
				WorldGen.altarCount = fileIO.ReadInt32();
				Main.hardMode = fileIO.ReadBoolean();
			}
			Main.invasionDelay = fileIO.ReadInt32();
			Main.invasionSize = fileIO.ReadInt32();
			Main.invasionType = fileIO.ReadInt32();
			Main.invasionX = fileIO.ReadDouble();
			if (num >= 113)
			{
				Main.sundialCooldown = (int)fileIO.ReadByte();
			}
			if (num >= 53)
			{
				WorldFile.tempRaining = fileIO.ReadBoolean();
				WorldFile.tempRainTime = fileIO.ReadInt32();
				WorldFile.tempMaxRain = fileIO.ReadSingle();
			}
			if (num >= 54)
			{
				WorldGen.oreTier1 = fileIO.ReadInt32();
				WorldGen.oreTier2 = fileIO.ReadInt32();
				WorldGen.oreTier3 = fileIO.ReadInt32();
			}
			else if (num >= 23 && WorldGen.altarCount == 0)
			{
				WorldGen.oreTier1 = -1;
				WorldGen.oreTier2 = -1;
				WorldGen.oreTier3 = -1;
			}
			else
			{
				WorldGen.oreTier1 = 107;
				WorldGen.oreTier2 = 108;
				WorldGen.oreTier3 = 111;
			}
			int style = 0;
			int style2 = 0;
			int style3 = 0;
			int style4 = 0;
			int style5 = 0;
			int style6 = 0;
			int style7 = 0;
			int style8 = 0;
			if (num >= 55)
			{
				style = (int)fileIO.ReadByte();
				style2 = (int)fileIO.ReadByte();
				style3 = (int)fileIO.ReadByte();
			}
			if (num >= 60)
			{
				style4 = (int)fileIO.ReadByte();
				style5 = (int)fileIO.ReadByte();
				style6 = (int)fileIO.ReadByte();
				style7 = (int)fileIO.ReadByte();
				style8 = (int)fileIO.ReadByte();
			}
			WorldGen.setBG(0, style);
			WorldGen.setBG(1, style2);
			WorldGen.setBG(2, style3);
			WorldGen.setBG(3, style4);
			WorldGen.setBG(4, style5);
			WorldGen.setBG(5, style6);
			WorldGen.setBG(6, style7);
			WorldGen.setBG(7, style8);
			if (num >= 60)
			{
				Main.cloudBGActive = (float)fileIO.ReadInt32();
				if (Main.cloudBGActive >= 1f)
				{
					Main.cloudBGAlpha = 1f;
				}
				else
				{
					Main.cloudBGAlpha = 0f;
				}
			}
			else
			{
				Main.cloudBGActive = (float)(-(float)WorldGen.genRand.Next(8640, 86400));
			}
			if (num >= 62)
			{
				Main.numClouds = (int)fileIO.ReadInt16();
				Main.windSpeedSet = fileIO.ReadSingle();
				Main.windSpeed = Main.windSpeedSet;
			}
			else
			{
				WorldGen.RandomizeWeather();
			}
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				float num2 = (float)i / (float)Main.maxTilesX;
				Main.statusText = string.Concat(new object[]
				{
					Lang.gen[51].Value,
					" ",
					(int)(num2 * 100f + 1f),
					"%"
				});
				for (int j = 0; j < Main.maxTilesY; j++)
				{
					Tile tile = Main.tile[i, j];
					int num3 = -1;
					tile.active(fileIO.ReadBoolean());
					if (tile.active())
					{
						if (num > 77)
						{
							num3 = (int)fileIO.ReadUInt16();
						}
						else
						{
							num3 = (int)fileIO.ReadByte();
						}
						tile.type = (ushort)num3;
						if (tile.type == 127)
						{
							tile.active(false);
						}
						if (num < 72 && (tile.type == 35 || tile.type == 36 || tile.type == 170 || tile.type == 171 || tile.type == 172))
						{
							tile.frameX = fileIO.ReadInt16();
							tile.frameY = fileIO.ReadInt16();
						}
						else if (Main.tileFrameImportant[num3])
						{
							if (num < 28 && num3 == 4)
							{
								tile.frameX = 0;
								tile.frameY = 0;
							}
							else if (num < 40 && tile.type == 19)
							{
								tile.frameX = 0;
								tile.frameY = 0;
							}
							else
							{
								tile.frameX = fileIO.ReadInt16();
								tile.frameY = fileIO.ReadInt16();
								if (tile.type == 144)
								{
									tile.frameY = 0;
								}
							}
						}
						else
						{
							tile.frameX = -1;
							tile.frameY = -1;
						}
						if (num >= 48 && fileIO.ReadBoolean())
						{
							tile.color(fileIO.ReadByte());
						}
					}
					if (num <= 25)
					{
						fileIO.ReadBoolean();
					}
					if (fileIO.ReadBoolean())
					{
						tile.wall = fileIO.ReadByte();
						if (num >= 48 && fileIO.ReadBoolean())
						{
							tile.wallColor(fileIO.ReadByte());
						}
					}
					if (fileIO.ReadBoolean())
					{
						tile.liquid = fileIO.ReadByte();
						tile.lava(fileIO.ReadBoolean());
						if (num >= 51)
						{
							tile.honey(fileIO.ReadBoolean());
						}
					}
					if (num >= 33)
					{
						tile.wire(fileIO.ReadBoolean());
					}
					if (num >= 43)
					{
						tile.wire2(fileIO.ReadBoolean());
						tile.wire3(fileIO.ReadBoolean());
					}
					if (num >= 41)
					{
						tile.halfBrick(fileIO.ReadBoolean());
						if (!Main.tileSolid[(int)tile.type])
						{
							tile.halfBrick(false);
						}
						if (num >= 49)
						{
							tile.slope(fileIO.ReadByte());
							if (!Main.tileSolid[(int)tile.type])
							{
								tile.slope(0);
							}
						}
					}
					if (num >= 42)
					{
						tile.actuator(fileIO.ReadBoolean());
						tile.inActive(fileIO.ReadBoolean());
					}
					int num4 = 0;
					if (num >= 25)
					{
						num4 = (int)fileIO.ReadInt16();
					}
					if (num3 != -1)
					{
						if ((double)j <= Main.worldSurface)
						{
							if ((double)(j + num4) <= Main.worldSurface)
							{
								WorldGen.tileCounts[num3] += (num4 + 1) * 5;
							}
							else
							{
								int num5 = (int)(Main.worldSurface - (double)j + 1.0);
								int num6 = num4 + 1 - num5;
								WorldGen.tileCounts[num3] += num5 * 5 + num6;
							}
						}
						else
						{
							WorldGen.tileCounts[num3] += num4 + 1;
						}
					}
					if (num4 > 0)
					{
						for (int k = j + 1; k < j + num4 + 1; k++)
						{
							Main.tile[i, k].CopyFrom(Main.tile[i, j]);
						}
						j += num4;
					}
				}
			}
			WorldGen.AddUpAlignmentCounts(true);
			if (num < 67)
			{
				WorldGen.FixSunflowers();
			}
			if (num < 72)
			{
				WorldGen.FixChands();
			}
			int num7 = 40;
			if (num < 58)
			{
				num7 = 20;
			}
			for (int l = 0; l < 1000; l++)
			{
				if (fileIO.ReadBoolean())
				{
					Main.chest[l] = new Chest(false);
					Main.chest[l].x = fileIO.ReadInt32();
					Main.chest[l].y = fileIO.ReadInt32();
					if (num >= 85)
					{
						string text = fileIO.ReadString();
						if (text.Length > 20)
						{
							text = text.Substring(0, 20);
						}
						Main.chest[l].name = text;
					}
					for (int m = 0; m < 40; m++)
					{
						Main.chest[l].item[m] = new Item();
						if (m < num7)
						{
							int num8;
							if (num >= 59)
							{
								num8 = (int)fileIO.ReadInt16();
							}
							else
							{
								num8 = (int)fileIO.ReadByte();
							}
							if (num8 > 0)
							{
								if (num >= 38)
								{
									Main.chest[l].item[m].netDefaults(fileIO.ReadInt32());
								}
								else
								{
									short type = ItemID.FromLegacyName(fileIO.ReadString(), num);
									Main.chest[l].item[m].SetDefaults((int)type, false);
								}
								Main.chest[l].item[m].stack = num8;
								if (num >= 36)
								{
									Main.chest[l].item[m].Prefix((int)fileIO.ReadByte());
								}
							}
						}
					}
				}
			}
			for (int n = 0; n < 1000; n++)
			{
				if (fileIO.ReadBoolean())
				{
					string text2 = fileIO.ReadString();
					int num9 = fileIO.ReadInt32();
					int num10 = fileIO.ReadInt32();
					if (Main.tile[num9, num10].active() && (Main.tile[num9, num10].type == 55 || Main.tile[num9, num10].type == 85))
					{
						Main.sign[n] = new Sign();
						Main.sign[n].x = num9;
						Main.sign[n].y = num10;
						Main.sign[n].text = text2;
					}
				}
			}
			bool flag = fileIO.ReadBoolean();
			int num11 = 0;
			while (flag)
			{
				if (num >= 190)
				{
					Main.npc[num11].SetDefaults(fileIO.ReadInt32(), -1f);
				}
				else
				{
					Main.npc[num11].SetDefaults(NPCID.FromLegacyName(fileIO.ReadString()), -1f);
				}
				if (num >= 83)
				{
					Main.npc[num11].GivenName = fileIO.ReadString();
				}
				Main.npc[num11].position.X = fileIO.ReadSingle();
				Main.npc[num11].position.Y = fileIO.ReadSingle();
				Main.npc[num11].homeless = fileIO.ReadBoolean();
				Main.npc[num11].homeTileX = fileIO.ReadInt32();
				Main.npc[num11].homeTileY = fileIO.ReadInt32();
				flag = fileIO.ReadBoolean();
				num11++;
			}
			if (num >= 31 && num <= 83)
			{
				NPC.setNPCName(fileIO.ReadString(), 17, true);
				NPC.setNPCName(fileIO.ReadString(), 18, true);
				NPC.setNPCName(fileIO.ReadString(), 19, true);
				NPC.setNPCName(fileIO.ReadString(), 20, true);
				NPC.setNPCName(fileIO.ReadString(), 22, true);
				NPC.setNPCName(fileIO.ReadString(), 54, true);
				NPC.setNPCName(fileIO.ReadString(), 38, true);
				NPC.setNPCName(fileIO.ReadString(), 107, true);
				NPC.setNPCName(fileIO.ReadString(), 108, true);
				if (num >= 35)
				{
					NPC.setNPCName(fileIO.ReadString(), 124, true);
					if (num >= 65)
					{
						NPC.setNPCName(fileIO.ReadString(), 160, true);
						NPC.setNPCName(fileIO.ReadString(), 178, true);
						NPC.setNPCName(fileIO.ReadString(), 207, true);
						NPC.setNPCName(fileIO.ReadString(), 208, true);
						NPC.setNPCName(fileIO.ReadString(), 209, true);
						NPC.setNPCName(fileIO.ReadString(), 227, true);
						NPC.setNPCName(fileIO.ReadString(), 228, true);
						NPC.setNPCName(fileIO.ReadString(), 229, true);
						if (num >= 79)
						{
							NPC.setNPCName(fileIO.ReadString(), 353, true);
						}
					}
				}
			}
			if (Main.invasionType > 0 && Main.invasionSize > 0)
			{
				Main.FakeLoadInvasionStart();
			}
			if (num < 7)
			{
				return 0;
			}
			bool arg_DC2_0 = fileIO.ReadBoolean();
			string a = fileIO.ReadString();
			int num12 = fileIO.ReadInt32();
			if (arg_DC2_0 && (a == Main.worldName || num12 == Main.worldID))
			{
				return 0;
			}
			return 2;
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x003C244C File Offset: 0x003C064C
		public static int LoadWorld_Version2(BinaryReader reader)
		{
			reader.BaseStream.Position = 0L;
			bool[] importance;
			int[] array;
			if (!WorldFile.LoadFileFormatHeader(reader, out importance, out array))
			{
				return 5;
			}
			if (reader.BaseStream.Position != (long)array[0])
			{
				return 5;
			}
			WorldFile.LoadHeader(reader);
			if (reader.BaseStream.Position != (long)array[1])
			{
				return 5;
			}
			WorldFile.LoadWorldTiles(reader, importance);
			if (reader.BaseStream.Position != (long)array[2])
			{
				return 5;
			}
			WorldFile.LoadChests(reader);
			if (reader.BaseStream.Position != (long)array[3])
			{
				return 5;
			}
			WorldFile.LoadSigns(reader);
			if (reader.BaseStream.Position != (long)array[4])
			{
				return 5;
			}
			WorldFile.LoadNPCs(reader);
			if (reader.BaseStream.Position != (long)array[5])
			{
				return 5;
			}
			if (WorldFile.versionNumber >= 116)
			{
				if (WorldFile.versionNumber < 122)
				{
					WorldFile.LoadDummies(reader);
					if (reader.BaseStream.Position != (long)array[6])
					{
						return 5;
					}
				}
				else
				{
					WorldFile.LoadTileEntities(reader);
					if (reader.BaseStream.Position != (long)array[6])
					{
						return 5;
					}
				}
			}
			if (WorldFile.versionNumber >= 170)
			{
				WorldFile.LoadWeightedPressurePlates(reader);
				if (reader.BaseStream.Position != (long)array[7])
				{
					return 5;
				}
			}
			if (WorldFile.versionNumber >= 189)
			{
				WorldFile.LoadTownManager(reader);
				if (reader.BaseStream.Position != (long)array[8])
				{
					return 5;
				}
			}
			return WorldFile.LoadFooter(reader);
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x003C41E0 File Offset: 0x003C23E0
		public static void ResetTemps()
		{
			WorldFile.tempRaining = false;
			WorldFile.tempMaxRain = 0f;
			WorldFile.tempRainTime = 0;
			WorldFile.tempDayTime = true;
			WorldFile.tempBloodMoon = false;
			WorldFile.tempEclipse = false;
			WorldFile.tempMoonPhase = 0;
			Main.anglerWhoFinishedToday.Clear();
			Main.anglerQuestFinished = false;
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x003BFD68 File Offset: 0x003BDF68
		private static void ResetTempsToDayTime()
		{
			WorldFile.tempDayTime = true;
			WorldFile.tempTime = 13500.0;
			WorldFile.tempMoonPhase = 0;
			WorldFile.tempBloodMoon = false;
			WorldFile.tempEclipse = false;
			WorldFile.tempCultistDelay = 86400;
			WorldFile.tempPartyManual = false;
			WorldFile.tempPartyGenuine = false;
			WorldFile.tempPartyCooldown = 0;
			WorldFile.tempPartyCelebratingNPCs.Clear();
			WorldFile.Temp_Sandstorm_Happening = false;
			WorldFile.Temp_Sandstorm_TimeLeft = 0;
			WorldFile.Temp_Sandstorm_Severity = 0f;
			WorldFile.Temp_Sandstorm_IntendedSeverity = 0f;
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x003C2044 File Offset: 0x003C0244
		private static int SaveChests(BinaryWriter writer)
		{
			short num = 0;
			for (int i = 0; i < 1000; i++)
			{
				Chest chest = Main.chest[i];
				if (chest != null)
				{
					bool flag = false;
					for (int j = chest.x; j <= chest.x + 1; j++)
					{
						for (int k = chest.y; k <= chest.y + 1; k++)
						{
							if (j < 0 || k < 0 || j >= Main.maxTilesX || k >= Main.maxTilesY)
							{
								flag = true;
								break;
							}
							Tile tile = Main.tile[j, k];
							if (!tile.active() || !Main.tileContainer[(int)tile.type])
							{
								flag = true;
								break;
							}
						}
					}
					if (flag)
					{
						Main.chest[i] = null;
					}
					else
					{
						num += 1;
					}
				}
			}
			writer.Write(num);
			writer.Write(40);
			for (int i = 0; i < 1000; i++)
			{
				Chest chest = Main.chest[i];
				if (chest != null)
				{
					writer.Write(chest.x);
					writer.Write(chest.y);
					writer.Write(chest.name);
					for (int l = 0; l < 40; l++)
					{
						Item item = chest.item[l];
						if (item == null)
						{
							writer.Write(0);
						}
						else
						{
							if (item.stack > item.maxStack)
							{
								item.stack = item.maxStack;
							}
							if (item.stack < 0)
							{
								item.stack = 1;
							}
							writer.Write((short)item.stack);
							if (item.stack > 0)
							{
								writer.Write(item.netID);
								writer.Write(item.prefix);
							}
						}
					}
				}
			}
			return (int)writer.BaseStream.Position;
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x003C2288 File Offset: 0x003C0488
		private static int SaveDummies(BinaryWriter writer)
		{
			int num = 0;
			for (int i = 0; i < 1000; i++)
			{
				DeprecatedClassLeftInForLoading deprecatedClassLeftInForLoading = DeprecatedClassLeftInForLoading.dummies[i];
				if (deprecatedClassLeftInForLoading != null)
				{
					num++;
				}
			}
			writer.Write(num);
			for (int j = 0; j < 1000; j++)
			{
				DeprecatedClassLeftInForLoading deprecatedClassLeftInForLoading = DeprecatedClassLeftInForLoading.dummies[j];
				if (deprecatedClassLeftInForLoading != null)
				{
					writer.Write(deprecatedClassLeftInForLoading.x);
					writer.Write(deprecatedClassLeftInForLoading.y);
				}
			}
			return (int)writer.BaseStream.Position;
		}

		// Token: 0x06000A8D RID: 2701 RVA: 0x003C14F4 File Offset: 0x003BF6F4
		private static int SaveFileFormatHeader(BinaryWriter writer)
		{
			short num = 470;
			short num2 = 10;
			writer.Write(194);
			Main.WorldFileMetadata.IncrementAndWrite(writer);
			writer.Write(num2);
			for (int i = 0; i < (int)num2; i++)
			{
				writer.Write(0);
			}
			writer.Write(num);
			byte b = 0;
			byte b2 = 1;
			for (int i = 0; i < (int)num; i++)
			{
				if (Main.tileFrameImportant[i])
				{
					b |= b2;
				}
				if (b2 == 128)
				{
					writer.Write(b);
					b = 0;
					b2 = 1;
				}
				else
				{
					b2 = (byte)(b2 << 1);
				}
			}
			if (b2 != 1)
			{
				writer.Write(b);
			}
			return (int)writer.BaseStream.Position;
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x003C241E File Offset: 0x003C061E
		private static int SaveFooter(BinaryWriter writer)
		{
			writer.Write(true);
			writer.Write(Main.worldName);
			writer.Write(Main.worldID);
			return (int)writer.BaseStream.Position;
		}

		// Token: 0x06000A8E RID: 2702 RVA: 0x003C1598 File Offset: 0x003BF798
		private static int SaveHeaderPointers(BinaryWriter writer, int[] pointers)
		{
			writer.BaseStream.Position = 0L;
			writer.Write(194);
			writer.BaseStream.Position += 20L;
			writer.Write((short)pointers.Length);
			for (int i = 0; i < pointers.Length; i++)
			{
				writer.Write(pointers[i]);
			}
			return (int)writer.BaseStream.Position;
		}

		// Token: 0x06000A94 RID: 2708 RVA: 0x003C22FC File Offset: 0x003C04FC
		private static int SaveNPCs(BinaryWriter writer)
		{
			for (int i = 0; i < Main.npc.Length; i++)
			{
				NPC nPC = Main.npc[i];
				if (nPC.active && nPC.townNPC && nPC.type != 368)
				{
					writer.Write(nPC.active);
					writer.Write(nPC.netID);
					writer.Write(nPC.GivenName);
					writer.Write(nPC.position.X);
					writer.Write(nPC.position.Y);
					writer.Write(nPC.homeless);
					writer.Write(nPC.homeTileX);
					writer.Write(nPC.homeTileY);
				}
			}
			writer.Write(false);
			for (int j = 0; j < Main.npc.Length; j++)
			{
				NPC nPC2 = Main.npc[j];
				if (nPC2.active && NPCID.Sets.SavesAndLoads[nPC2.type])
				{
					writer.Write(nPC2.active);
					writer.Write(nPC2.netID);
					writer.WriteVector2(nPC2.position);
				}
			}
			writer.Write(false);
			return (int)writer.BaseStream.Position;
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x003C21F4 File Offset: 0x003C03F4
		private static int SaveSigns(BinaryWriter writer)
		{
			short num = 0;
			for (int i = 0; i < 1000; i++)
			{
				Sign sign = Main.sign[i];
				if (sign != null && sign.text != null)
				{
					num += 1;
				}
			}
			writer.Write(num);
			for (int j = 0; j < 1000; j++)
			{
				Sign sign = Main.sign[j];
				if (sign != null && sign.text != null)
				{
					writer.Write(sign.text);
					writer.Write(sign.x);
					writer.Write(sign.y);
				}
			}
			return (int)writer.BaseStream.Position;
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x003C428C File Offset: 0x003C248C
		private static int SaveTileEntities(BinaryWriter writer)
		{
			writer.Write(TileEntity.ByID.Count);
			foreach (KeyValuePair<int, TileEntity> current in TileEntity.ByID)
			{
				TileEntity.Write(writer, current.Value, false);
			}
			return (int)writer.BaseStream.Position;
		}

		// Token: 0x06000AAC RID: 2732 RVA: 0x003C46A7 File Offset: 0x003C28A7
		private static int SaveTownManager(BinaryWriter writer)
		{
			WorldGen.TownManager.Save(writer);
			return (int)writer.BaseStream.Position;
		}

		// Token: 0x06000AAA RID: 2730 RVA: 0x003C45C8 File Offset: 0x003C27C8
		private static int SaveWeightedPressurePlates(BinaryWriter writer)
		{
			writer.Write(PressurePlateHelper.PressurePlatesPressed.Count);
			foreach (KeyValuePair<Point, bool[]> current in PressurePlateHelper.PressurePlatesPressed)
			{
				writer.Write(current.Key.X);
				writer.Write(current.Key.Y);
			}
			return (int)writer.BaseStream.Position;
		}

		// Token: 0x06000A89 RID: 2697 RVA: 0x003C040C File Offset: 0x003BE60C
		public static void saveWorld()
		{
			WorldFile.saveWorld(WorldFile.IsWorldOnCloud, false);
		}

		// Token: 0x06000A8A RID: 2698 RVA: 0x003C041C File Offset: 0x003BE61C
		public static void saveWorld(bool useCloudSaving, bool resetTime = false)
		{
			if (useCloudSaving && SocialAPI.Cloud == null)
			{
				return;
			}
			if (Main.worldName == "")
			{
				Main.worldName = "World";
			}
			if (WorldGen.saveLock)
			{
				return;
			}
			WorldGen.saveLock = true;
			while (WorldGen.IsGeneratingHardMode)
			{
				Main.statusText = Lang.gen[48].Value;
			}
			object obj = WorldFile.padlock;
			lock (obj)
			{
				try
				{
					Directory.CreateDirectory(Main.WorldPath);
				}
				catch
				{
				}
				if (Main.skipMenu)
				{
					return;
				}
				if (WorldFile.HasCache)
				{
					WorldFile.SetTempToCache();
				}
				else
				{
					WorldFile.SetTempToOngoing();
				}
				if (resetTime)
				{
					WorldFile.ResetTempsToDayTime();
				}
				if (Main.worldPathName == null)
				{
					return;
				}
				new Stopwatch().Start();
				byte[] array = null;
				int num = 0;
				using (MemoryStream memoryStream = new MemoryStream(7000000))
				{
					using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
					{
						WorldFile.SaveWorld_Version2(binaryWriter);
					}
					array = memoryStream.ToArray();
					num = array.Length;
				}
				if (array == null)
				{
					return;
				}
				byte[] array2 = null;
				if (FileUtilities.Exists(Main.worldPathName, useCloudSaving))
				{
					array2 = FileUtilities.ReadAllBytes(Main.worldPathName, useCloudSaving);
				}
				FileUtilities.Write(Main.worldPathName, array, num, useCloudSaving);
				array = FileUtilities.ReadAllBytes(Main.worldPathName, useCloudSaving);
				string text = null;
				using (MemoryStream memoryStream2 = new MemoryStream(array, 0, num, false))
				{
					using (BinaryReader binaryReader = new BinaryReader(memoryStream2))
					{
						if (!Main.validateSaves || WorldFile.validateWorld(binaryReader))
						{
							if (array2 != null)
							{
								text = Main.worldPathName + ".bak";
								Main.statusText = Lang.gen[50].Value;
							}
						}
						else
						{
							text = Main.worldPathName;
						}
					}
				}
				if (text != null && array2 != null)
				{
					FileUtilities.WriteAllBytes(text, array2, useCloudSaving);
				}
				WorldGen.saveLock = false;
			}
			Main.serverGenLock = false;
		}

		// Token: 0x06000A8F RID: 2703 RVA: 0x003C1600 File Offset: 0x003BF800
		private static int SaveWorldHeader(BinaryWriter writer)
		{
			writer.Write(Main.worldName);
			writer.Write(Main.ActiveWorldFileData.SeedText);
			writer.Write(Main.ActiveWorldFileData.WorldGeneratorVersion);
			writer.Write(Main.ActiveWorldFileData.UniqueId.ToByteArray());
			writer.Write(Main.worldID);
			writer.Write((int)Main.leftWorld);
			writer.Write((int)Main.rightWorld);
			writer.Write((int)Main.topWorld);
			writer.Write((int)Main.bottomWorld);
			writer.Write(Main.maxTilesY);
			writer.Write(Main.maxTilesX);
			writer.Write(Main.expertMode);
			writer.Write(Main.ActiveWorldFileData.CreationTime.ToBinary());
			writer.Write((byte)Main.moonType);
			writer.Write(Main.treeX[0]);
			writer.Write(Main.treeX[1]);
			writer.Write(Main.treeX[2]);
			writer.Write(Main.treeStyle[0]);
			writer.Write(Main.treeStyle[1]);
			writer.Write(Main.treeStyle[2]);
			writer.Write(Main.treeStyle[3]);
			writer.Write(Main.caveBackX[0]);
			writer.Write(Main.caveBackX[1]);
			writer.Write(Main.caveBackX[2]);
			writer.Write(Main.caveBackStyle[0]);
			writer.Write(Main.caveBackStyle[1]);
			writer.Write(Main.caveBackStyle[2]);
			writer.Write(Main.caveBackStyle[3]);
			writer.Write(Main.iceBackStyle);
			writer.Write(Main.jungleBackStyle);
			writer.Write(Main.hellBackStyle);
			writer.Write(Main.spawnTileX);
			writer.Write(Main.spawnTileY);
			writer.Write(Main.worldSurface);
			writer.Write(Main.rockLayer);
			writer.Write(WorldFile.tempTime);
			writer.Write(WorldFile.tempDayTime);
			writer.Write(WorldFile.tempMoonPhase);
			writer.Write(WorldFile.tempBloodMoon);
			writer.Write(WorldFile.tempEclipse);
			writer.Write(Main.dungeonX);
			writer.Write(Main.dungeonY);
			writer.Write(WorldGen.crimson);
			writer.Write(NpcMgr.downedBoss1);
			writer.Write(NpcMgr.downedBoss2);
			writer.Write(NpcMgr.downedBoss3);
			writer.Write(NpcMgr.downedQueenBee);
			writer.Write(NpcMgr.downedMechBoss1);
			writer.Write(NpcMgr.downedMechBoss2);
			writer.Write(NpcMgr.downedMechBoss3);
			writer.Write(NpcMgr.downedMechBossAny);
			writer.Write(NpcMgr.downedPlantBoss);
			writer.Write(NpcMgr.downedGolemBoss);
			writer.Write(NpcMgr.downedSlimeKing);
			writer.Write(NpcMgr.savedGoblin);
			writer.Write(NpcMgr.savedWizard);
			writer.Write(NpcMgr.savedMech);
			writer.Write(NpcMgr.downedGoblins);
			writer.Write(NpcMgr.downedClown);
			writer.Write(NpcMgr.downedFrost);
			writer.Write(NpcMgr.downedPirates);
			writer.Write(WorldGen.shadowOrbSmashed);
			writer.Write(WorldGen.spawnMeteor);
			writer.Write((byte)WorldGen.shadowOrbCount);
			writer.Write(WorldGen.altarCount);
			writer.Write(Main.hardMode);
			writer.Write(Main.invasionDelay);
			writer.Write(Main.invasionSize);
			writer.Write(Main.invasionType);
			writer.Write(Main.invasionX);
			writer.Write(Main.slimeRainTime);
			writer.Write((byte)Main.sundialCooldown);
			writer.Write(WorldFile.tempRaining);
			writer.Write(WorldFile.tempRainTime);
			writer.Write(WorldFile.tempMaxRain);
			writer.Write(WorldGen.oreTier1);
			writer.Write(WorldGen.oreTier2);
			writer.Write(WorldGen.oreTier3);
			writer.Write((byte)WorldGen.treeBG);
			writer.Write((byte)WorldGen.corruptBG);
			writer.Write((byte)WorldGen.jungleBG);
			writer.Write((byte)WorldGen.snowBG);
			writer.Write((byte)WorldGen.hallowBG);
			writer.Write((byte)WorldGen.crimsonBG);
			writer.Write((byte)WorldGen.desertBG);
			writer.Write((byte)WorldGen.oceanBG);
			writer.Write((int)Main.cloudBGActive);
			writer.Write((short)Main.numClouds);
			writer.Write(Main.windSpeedSet);
			writer.Write(Main.anglerWhoFinishedToday.Count);
			for (int i = 0; i < Main.anglerWhoFinishedToday.Count; i++)
			{
				writer.Write(Main.anglerWhoFinishedToday[i]);
			}
			writer.Write(NpcMgr.savedAngler);
			writer.Write(Main.anglerQuest);
			writer.Write(NpcMgr.savedStylist);
			writer.Write(NpcMgr.savedTaxCollector);
			writer.Write(Main.invasionSizeStart);
			writer.Write(WorldFile.tempCultistDelay);
			writer.Write(580);
			for (int j = 0; j < 580; j++)
			{
				writer.Write(NPC.killCount[j]);
			}
			writer.Write(Main.fastForwardTime);
			writer.Write(NpcMgr.downedFishron);
			writer.Write(NpcMgr.downedMartians);
			writer.Write(NpcMgr.downedAncientCultist);
			writer.Write(NpcMgr.downedMoonlord);
			writer.Write(NpcMgr.downedHalloweenKing);
			writer.Write(NpcMgr.downedHalloweenTree);
			writer.Write(NpcMgr.downedChristmasIceQueen);
			writer.Write(NpcMgr.downedChristmasSantank);
			writer.Write(NpcMgr.downedChristmasTree);
			writer.Write(NpcMgr.downedTowerSolar);
			writer.Write(NpcMgr.downedTowerVortex);
			writer.Write(NpcMgr.downedTowerNebula);
			writer.Write(NpcMgr.downedTowerStardust);
			writer.Write(NpcMgr.TowerActiveSolar);
			writer.Write(NpcMgr.TowerActiveVortex);
			writer.Write(NpcMgr.TowerActiveNebula);
			writer.Write(NpcMgr.TowerActiveStardust);
			writer.Write(NPC.LunarApocalypseIsUp);
			writer.Write(WorldFile.tempPartyManual);
			writer.Write(WorldFile.tempPartyGenuine);
			writer.Write(WorldFile.tempPartyCooldown);
			writer.Write(WorldFile.tempPartyCelebratingNPCs.Count);
			for (int k = 0; k < WorldFile.tempPartyCelebratingNPCs.Count; k++)
			{
				writer.Write(WorldFile.tempPartyCelebratingNPCs[k]);
			}
			writer.Write(WorldFile.Temp_Sandstorm_Happening);
			writer.Write(WorldFile.Temp_Sandstorm_TimeLeft);
			writer.Write(WorldFile.Temp_Sandstorm_Severity);
			writer.Write(WorldFile.Temp_Sandstorm_IntendedSeverity);
			writer.Write(NpcMgr.savedBartender);
			DD2Event.Save(writer);
			return (int)writer.BaseStream.Position;
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x003C1C40 File Offset: 0x003BFE40
		private static int SaveWorldTiles(BinaryWriter writer)
		{
			byte[] array = new byte[13];
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				float num = (float)i / (float)Main.maxTilesX;
				Main.statusText = string.Concat(new object[]
				{
					Lang.gen[49].Value,
					" ",
					(int)(num * 100f + 1f),
					"%"
				});
				for (int j = 0; j < Main.maxTilesY; j++)
				{
					Tile tile = Main.tile[i, j];
					int num2 = 3;
					byte b3;
					byte b2;
					byte b = b2 = (b3 = 0);
					bool flag = false;
					if (tile.active())
					{
						flag = true;
						if (tile.type == 127)
						{
							WorldGen.KillTile(i, j, false, false, false);
							if (!tile.active())
							{
								flag = false;
								if (Main.netMode != 0)
								{
									NetMessage.SendData(17, -1, -1, null, 0, (float)i, (float)j, 0f, 0, 0, 0);
								}
							}
						}
					}
					if (flag)
					{
						b2 |= 2;
						if (tile.type == 127)
						{
							WorldGen.KillTile(i, j, false, false, false);
							if (!tile.active() && Main.netMode != 0)
							{
								NetMessage.SendData(17, -1, -1, null, 0, (float)i, (float)j, 0f, 0, 0, 0);
							}
						}
						array[num2] = (byte)tile.type;
						num2++;
						if (tile.type > 255)
						{
							array[num2] = (byte)(tile.type >> 8);
							num2++;
							b2 |= 32;
						}
						if (Main.tileFrameImportant[(int)tile.type])
						{
							array[num2] = (byte)(tile.frameX & 255);
							num2++;
							array[num2] = (byte)(((int)tile.frameX & 65280) >> 8);
							num2++;
							array[num2] = (byte)(tile.frameY & 255);
							num2++;
							array[num2] = (byte)(((int)tile.frameY & 65280) >> 8);
							num2++;
						}
						if (tile.color() != 0)
						{
							b3 |= 8;
							array[num2] = tile.color();
							num2++;
						}
					}
					if (tile.wall != 0)
					{
						b2 |= 4;
						array[num2] = tile.wall;
						num2++;
						if (tile.wallColor() != 0)
						{
							b3 |= 16;
							array[num2] = tile.wallColor();
							num2++;
						}
					}
					if (tile.liquid != 0)
					{
						if (tile.lava())
						{
							b2 |= 16;
						}
						else if (tile.honey())
						{
							b2 |= 24;
						}
						else
						{
							b2 |= 8;
						}
						array[num2] = tile.liquid;
						num2++;
					}
					if (tile.wire())
					{
						b |= 2;
					}
					if (tile.wire2())
					{
						b |= 4;
					}
					if (tile.wire3())
					{
						b |= 8;
					}
					int num3;
					if (tile.halfBrick())
					{
						num3 = 16;
					}
					else if (tile.slope() != 0)
					{
						num3 = (int)(tile.slope() + 1) << 4;
					}
					else
					{
						num3 = 0;
					}
					b |= (byte)num3;
					if (tile.actuator())
					{
						b3 |= 2;
					}
					if (tile.inActive())
					{
						b3 |= 4;
					}
					if (tile.wire4())
					{
						b3 |= 32;
					}
					int num4 = 2;
					if (b3 != 0)
					{
						b |= 1;
						array[num4] = b3;
						num4--;
					}
					if (b != 0)
					{
						b2 |= 1;
						array[num4] = b;
						num4--;
					}
					short num5 = 0;
					int num6 = j + 1;
					int num7 = Main.maxTilesY - j - 1;
					while (num7 > 0 && tile.isTheSameAs(Main.tile[i, num6]))
					{
						num5 += 1;
						num7--;
						num6++;
					}
					j += (int)num5;
					if (num5 > 0)
					{
						array[num2] = (byte)(num5 & 255);
						num2++;
						if (num5 > 255)
						{
							b2 |= 128;
							array[num2] = (byte)(((int)num5 & 65280) >> 8);
							num2++;
						}
						else
						{
							b2 |= 64;
						}
					}
					array[num4] = b2;
					writer.Write(array, num4, num2 - num4);
				}
			}
			return (int)writer.BaseStream.Position;
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x003C147C File Offset: 0x003BF67C
		public static void SaveWorld_Version2(BinaryWriter writer)
		{
			int[] array = new int[10];
			array[0] = WorldFile.SaveFileFormatHeader(writer);
			array[1] = WorldFile.SaveWorldHeader(writer);
			array[2] = WorldFile.SaveWorldTiles(writer);
			array[3] = WorldFile.SaveChests(writer);
			array[4] = WorldFile.SaveSigns(writer);
			array[5] = WorldFile.SaveNPCs(writer);
			array[6] = WorldFile.SaveTileEntities(writer);
			array[7] = WorldFile.SaveWeightedPressurePlates(writer);
			array[8] = WorldFile.SaveTownManager(writer);
			WorldFile.SaveFooter(writer);
			WorldFile.SaveHeaderPointers(writer, array);
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x003BFF7C File Offset: 0x003BE17C
		public static void SetOngoingToTemps()
		{
			Main.dayTime = WorldFile.tempDayTime;
			Main.time = WorldFile.tempTime;
			Main.moonPhase = WorldFile.tempMoonPhase;
			Main.bloodMoon = WorldFile.tempBloodMoon;
			Main.eclipse = WorldFile.tempEclipse;
			Main.raining = WorldFile.tempRaining;
			Main.rainTime = WorldFile.tempRainTime;
			Main.maxRaining = WorldFile.tempMaxRain;
			Main.cloudAlpha = WorldFile.tempMaxRain;
			CultistRitual.delay = WorldFile.tempCultistDelay;
			BirthdayParty.ManualParty = WorldFile.tempPartyManual;
			BirthdayParty.GenuineParty = WorldFile.tempPartyGenuine;
			BirthdayParty.PartyDaysOnCooldown = WorldFile.tempPartyCooldown;
			BirthdayParty.CelebratingNPCs.Clear();
			BirthdayParty.CelebratingNPCs.AddRange(WorldFile.tempPartyCelebratingNPCs);
			Sandstorm.Happening = WorldFile.Temp_Sandstorm_Happening;
			Sandstorm.TimeLeft = WorldFile.Temp_Sandstorm_TimeLeft;
			Sandstorm.Severity = WorldFile.Temp_Sandstorm_Severity;
			Sandstorm.IntendedSeverity = WorldFile.Temp_Sandstorm_IntendedSeverity;
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x003BFE8C File Offset: 0x003BE08C
		private static void SetTempToCache()
		{
			WorldFile.HasCache = false;
			WorldFile.tempDayTime = WorldFile.CachedDayTime.Value;
			WorldFile.tempTime = WorldFile.CachedTime.Value;
			WorldFile.tempMoonPhase = WorldFile.CachedMoonPhase.Value;
			WorldFile.tempBloodMoon = WorldFile.CachedBloodMoon.Value;
			WorldFile.tempEclipse = WorldFile.CachedEclipse.Value;
			WorldFile.tempCultistDelay = WorldFile.CachedCultistDelay.Value;
			WorldFile.tempPartyManual = WorldFile.CachedPartyManual.Value;
			WorldFile.tempPartyGenuine = WorldFile.CachedPartyGenuine.Value;
			WorldFile.tempPartyCooldown = WorldFile.CachedPartyDaysOnCooldown.Value;
			WorldFile.tempPartyCelebratingNPCs.Clear();
			WorldFile.tempPartyCelebratingNPCs.AddRange(WorldFile.CachedCelebratingNPCs);
			WorldFile.Temp_Sandstorm_Happening = WorldFile.Cached_Sandstorm_Happening.Value;
			WorldFile.Temp_Sandstorm_TimeLeft = WorldFile.Cached_Sandstorm_TimeLeft.Value;
			WorldFile.Temp_Sandstorm_Severity = WorldFile.Cached_Sandstorm_Severity.Value;
			WorldFile.Temp_Sandstorm_IntendedSeverity = WorldFile.Cached_Sandstorm_IntendedSeverity.Value;
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x003BFDE4 File Offset: 0x003BDFE4
		private static void SetTempToOngoing()
		{
			WorldFile.tempDayTime = Main.dayTime;
			WorldFile.tempTime = Main.time;
			WorldFile.tempMoonPhase = Main.moonPhase;
			WorldFile.tempBloodMoon = Main.bloodMoon;
			WorldFile.tempEclipse = Main.eclipse;
			WorldFile.tempCultistDelay = CultistRitual.delay;
			WorldFile.tempPartyManual = BirthdayParty.ManualParty;
			WorldFile.tempPartyGenuine = BirthdayParty.GenuineParty;
			WorldFile.tempPartyCooldown = BirthdayParty.PartyDaysOnCooldown;
			WorldFile.tempPartyCelebratingNPCs.Clear();
			WorldFile.tempPartyCelebratingNPCs.AddRange(BirthdayParty.CelebratingNPCs);
			WorldFile.Temp_Sandstorm_Happening = Sandstorm.Happening;
			WorldFile.Temp_Sandstorm_TimeLeft = Sandstorm.TimeLeft;
			WorldFile.Temp_Sandstorm_Severity = Sandstorm.Severity;
			WorldFile.Temp_Sandstorm_IntendedSeverity = Sandstorm.IntendedSeverity;
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x003C35F0 File Offset: 0x003C17F0
		public static bool validateWorld(BinaryReader fileIO)
		{
			new Stopwatch().Start();
			bool result;
			try
			{
				Stream baseStream = fileIO.BaseStream;
				int num = fileIO.ReadInt32();
				if (num == 0 || num > 194)
				{
					result = false;
				}
				else
				{
					baseStream.Position = 0L;
					bool[] array;
					int[] array2;
					if (!WorldFile.LoadFileFormatHeader(fileIO, out array, out array2))
					{
						result = false;
					}
					else
					{
						string b = fileIO.ReadString();
						if (num >= 179)
						{
							if (num == 179)
							{
								fileIO.ReadInt32();
							}
							else
							{
								fileIO.ReadString();
							}
							fileIO.ReadUInt64();
						}
						if (num >= 181)
						{
							fileIO.ReadBytes(16);
						}
						int num2 = fileIO.ReadInt32();
						fileIO.ReadInt32();
						fileIO.ReadInt32();
						fileIO.ReadInt32();
						fileIO.ReadInt32();
						int num3 = fileIO.ReadInt32();
						int num4 = fileIO.ReadInt32();
						baseStream.Position = (long)array2[1];
						for (int i = 0; i < num4; i++)
						{
							float num5 = (float)i / (float)Main.maxTilesX;
							Main.statusText = string.Concat(new object[]
							{
								Lang.gen[73].Value,
								" ",
								(int)(num5 * 100f + 1f),
								"%"
							});
							for (int j = 0; j < num3; j++)
							{
								byte b2 = 0;
								byte b3 = fileIO.ReadByte();
								if ((b3 & 1) == 1 && (fileIO.ReadByte() & 1) == 1)
								{
									b2 = fileIO.ReadByte();
								}
								byte b4;
								if ((b3 & 2) == 2)
								{
									int num6;
									if ((b3 & 32) == 32)
									{
										b4 = fileIO.ReadByte();
										num6 = (int)fileIO.ReadByte();
										num6 = (num6 << 8 | (int)b4);
									}
									else
									{
										num6 = (int)fileIO.ReadByte();
									}
									if (array[num6])
									{
										fileIO.ReadInt16();
										fileIO.ReadInt16();
									}
									if ((b2 & 8) == 8)
									{
										fileIO.ReadByte();
									}
								}
								if ((b3 & 4) == 4)
								{
									fileIO.ReadByte();
									if ((b2 & 16) == 16)
									{
										fileIO.ReadByte();
									}
								}
								if ((b3 & 24) >> 3 != 0)
								{
									fileIO.ReadByte();
								}
								b4 = (byte)((b3 & 192) >> 6);
								int num7;
								if (b4 == 0)
								{
									num7 = 0;
								}
								else if (b4 == 1)
								{
									num7 = (int)fileIO.ReadByte();
								}
								else
								{
									num7 = (int)fileIO.ReadInt16();
								}
								j += num7;
							}
						}
						if (baseStream.Position != (long)array2[2])
						{
							result = false;
						}
						else
						{
							int num8 = (int)fileIO.ReadInt16();
							int num9 = (int)fileIO.ReadInt16();
							for (int k = 0; k < num8; k++)
							{
								fileIO.ReadInt32();
								fileIO.ReadInt32();
								fileIO.ReadString();
								for (int l = 0; l < num9; l++)
								{
									if (fileIO.ReadInt16() > 0)
									{
										fileIO.ReadInt32();
										fileIO.ReadByte();
									}
								}
							}
							if (baseStream.Position != (long)array2[3])
							{
								result = false;
							}
							else
							{
								int num10 = (int)fileIO.ReadInt16();
								for (int m = 0; m < num10; m++)
								{
									fileIO.ReadString();
									fileIO.ReadInt32();
									fileIO.ReadInt32();
								}
								if (baseStream.Position != (long)array2[4])
								{
									result = false;
								}
								else
								{
									bool flag = fileIO.ReadBoolean();
									while (flag)
									{
										fileIO.ReadInt32();
										fileIO.ReadString();
										fileIO.ReadSingle();
										fileIO.ReadSingle();
										fileIO.ReadBoolean();
										fileIO.ReadInt32();
										fileIO.ReadInt32();
										flag = fileIO.ReadBoolean();
									}
									flag = fileIO.ReadBoolean();
									while (flag)
									{
										fileIO.ReadInt32();
										fileIO.ReadSingle();
										fileIO.ReadSingle();
										flag = fileIO.ReadBoolean();
									}
									if (baseStream.Position != (long)array2[5])
									{
										result = false;
									}
									else
									{
										if (WorldFile.versionNumber >= 116 && WorldFile.versionNumber <= 121)
										{
											int num11 = fileIO.ReadInt32();
											for (int n = 0; n < num11; n++)
											{
												fileIO.ReadInt16();
												fileIO.ReadInt16();
											}
											if (baseStream.Position != (long)array2[6])
											{
												result = false;
												return result;
											}
										}
										if (WorldFile.versionNumber >= 122)
										{
											int num12 = fileIO.ReadInt32();
											for (int num13 = 0; num13 < num12; num13++)
											{
												TileEntity.Read(fileIO, false);
											}
										}
										if (WorldFile.versionNumber >= 170)
										{
											int num14 = fileIO.ReadInt32();
											for (int num15 = 0; num15 < num14; num15++)
											{
												fileIO.ReadInt64();
											}
										}
										if (WorldFile.versionNumber >= 189)
										{
											int num16 = fileIO.ReadInt32();
											fileIO.ReadBytes(12 * num16);
										}
										bool arg_44C_0 = fileIO.ReadBoolean();
										string a = fileIO.ReadString();
										int num17 = fileIO.ReadInt32();
										bool flag2 = false;
										if (arg_44C_0 && (a == b || num17 == num2))
										{
											flag2 = true;
										}
										result = flag2;
									}
								}
							}
						}
					}
				}
			}
			catch (Exception value)
			{
				using (StreamWriter streamWriter = new StreamWriter("client-crashlog.txt", true))
				{
					streamWriter.WriteLine(DateTime.Now);
					streamWriter.WriteLine(value);
					streamWriter.WriteLine("");
				}
				result = false;
			}
			return result;
		}

		// Token: 0x14000012 RID: 18
		// Token: 0x06000A81 RID: 2689 RVA: 0x003BFC10 File Offset: 0x003BDE10
		// Token: 0x06000A82 RID: 2690 RVA: 0x003BFC44 File Offset: 0x003BDE44
		[method: CompilerGenerated]
		[CompilerGenerated]
		public static event Action OnWorldLoad;

		// Token: 0x04000E48 RID: 3656
		private static bool? CachedBloodMoon = null;

		// Token: 0x04000E4E RID: 3662
		private static List<int> CachedCelebratingNPCs = new List<int>();

		// Token: 0x04000E4A RID: 3658
		private static int? CachedCultistDelay = null;

		// Token: 0x04000E45 RID: 3653
		private static bool? CachedDayTime = null;

		// Token: 0x04000E49 RID: 3657
		private static bool? CachedEclipse = null;

		// Token: 0x04000E47 RID: 3655
		private static int? CachedMoonPhase = null;

		// Token: 0x04000E4D RID: 3661
		private static int? CachedPartyDaysOnCooldown = null;

		// Token: 0x04000E4B RID: 3659
		private static bool? CachedPartyGenuine = null;

		// Token: 0x04000E4C RID: 3660
		private static bool? CachedPartyManual = null;

		// Token: 0x04000E46 RID: 3654
		private static double? CachedTime = null;

		// Token: 0x04000E4F RID: 3663
		private static bool? Cached_Sandstorm_Happening = null;

		// Token: 0x04000E55 RID: 3669
		private static float? Cached_Sandstorm_IntendedSeverity = null;

		// Token: 0x04000E53 RID: 3667
		private static float? Cached_Sandstorm_Severity = null;

		// Token: 0x04000E51 RID: 3665
		private static int? Cached_Sandstorm_TimeLeft = null;

		// Token: 0x04000E44 RID: 3652
		private static bool HasCache = false;

		// Token: 0x04000E3F RID: 3647
		public static bool IsWorldOnCloud = false;

		// Token: 0x04000E34 RID: 3636
		private static object padlock = new object();

		// Token: 0x04000E3A RID: 3642
		public static bool tempBloodMoon = Main.bloodMoon;

		// Token: 0x04000E3D RID: 3645
		public static int tempCultistDelay = CultistRitual.delay;

		// Token: 0x04000E39 RID: 3641
		public static bool tempDayTime = Main.dayTime;

		// Token: 0x04000E3B RID: 3643
		public static bool tempEclipse = Main.eclipse;

		// Token: 0x04000E37 RID: 3639
		public static float tempMaxRain = 0f;

		// Token: 0x04000E3C RID: 3644
		public static int tempMoonPhase = Main.moonPhase;

		// Token: 0x04000E43 RID: 3651
		public static List<int> tempPartyCelebratingNPCs = new List<int>();

		// Token: 0x04000E42 RID: 3650
		public static int tempPartyCooldown = 0;

		// Token: 0x04000E40 RID: 3648
		public static bool tempPartyGenuine = false;

		// Token: 0x04000E41 RID: 3649
		public static bool tempPartyManual = false;

		// Token: 0x04000E36 RID: 3638
		public static bool tempRaining = false;

		// Token: 0x04000E38 RID: 3640
		public static int tempRainTime = 0;

		// Token: 0x04000E35 RID: 3637
		public static double tempTime = Main.time;

		// Token: 0x04000E50 RID: 3664
		private static bool Temp_Sandstorm_Happening = false;

		// Token: 0x04000E56 RID: 3670
		private static float Temp_Sandstorm_IntendedSeverity = 0f;

		// Token: 0x04000E54 RID: 3668
		private static float Temp_Sandstorm_Severity = 0f;

		// Token: 0x04000E52 RID: 3666
		private static int Temp_Sandstorm_TimeLeft = 0;

		// Token: 0x04000E3E RID: 3646
		public static int versionNumber;
	}
}

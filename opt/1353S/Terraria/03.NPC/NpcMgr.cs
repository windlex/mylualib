using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Utilities;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Utilities;
using Terraria.World.Generation;

namespace Terraria
{
    public class NpcMgr
    {
        // Token: 0x1700005A RID: 90
        public static bool downedTowers
        {
            // Token: 0x06000217 RID: 535 RVA: 0x000EBD16 File Offset: 0x000E9F16
            get
            {
                return NpcMgr.downedTowerSolar && NpcMgr.downedTowerVortex && NpcMgr.downedTowerNebula && NpcMgr.downedTowerStardust;
            }
        }
        // Token: 0x1700005B RID: 91
        public static int ShieldStrengthTowerMax
        {
            // Token: 0x06000218 RID: 536 RVA: 0x000EBD34 File Offset: 0x000E9F34
            get
            {
                if (!Main.expertMode)
                {
                    return NPC.LunarShieldPowerNormal;
                }
                return NPC.LunarShieldPowerExpert;
            }
        }
        // Token: 0x1700005C RID: 92
        public static bool TowersDefeated
        {
            // Token: 0x06000219 RID: 537 RVA: 0x000EBD48 File Offset: 0x000E9F48
            get
            {
                return NpcMgr.TowerActiveSolar && NpcMgr.TowerActiveVortex && NpcMgr.TowerActiveNebula && NpcMgr.TowerActiveStardust;
            }
        }


        // Token: 0x040002DB RID: 731
        public static bool travelNPC = false;

        // Token: 0x0400027F RID: 639
        public static bool savedAngler = false;

        // Token: 0x04000281 RID: 641
        public static bool savedBartender = false;

        // Token: 0x0400027C RID: 636
        public static bool savedGoblin = false;

        // Token: 0x0400027E RID: 638
        public static bool savedMech = false;

        // Token: 0x04000280 RID: 640
        public static bool savedStylist = false;

        // Token: 0x0400027B RID: 635
        public static bool savedTaxCollector = false;

        // Token: 0x0400027D RID: 637
        public static bool savedWizard = false;
        
        
        // Token: 0x040002A2 RID: 674
        public static bool TowerActiveNebula = false;

        // Token: 0x040002A0 RID: 672
        public static bool TowerActiveSolar = false;

        // Token: 0x040002A3 RID: 675
        public static bool TowerActiveStardust = false;

        // Token: 0x040002A1 RID: 673
        public static bool TowerActiveVortex = false;
        
        
        // Token: 0x04000222 RID: 546
        public static float waveKills = 0f;

        // Token: 0x04000223 RID: 547
        public static int waveNumber = 0;

        // Token: 0x0400024D RID: 589
        public static int sWidth = 1920;
        // Token: 0x0400024E RID: 590
        public static int sHeight = 1080;
        // Token: 0x04000251 RID: 593
        public static int safeRangeX = (int)((double)(NpcMgr.sWidth / 16) * 0.52);

        // Token: 0x04000252 RID: 594
        public static int safeRangeY = (int)((double)(NpcMgr.sHeight / 16) * 0.52);

        // Token: 0x0400024F RID: 591
        public static int spawnRangeX = (int)((double)(NpcMgr.sWidth / 16) * 0.7);

        // Token: 0x04000250 RID: 592
        public static int spawnRangeY = (int)((double)(NpcMgr.sHeight / 16) * 0.7);
        // Token: 0x04000258 RID: 600
        public static bool noSpawnCycle = false;


        // Token: 0x0400025B RID: 603
        public static int defaultMaxSpawns = 5;

        // Token: 0x0400025A RID: 602
        public static int defaultSpawnRate = 600;
        // Token: 0x040002AB RID: 683
        public static int maxSpawns = NpcMgr.defaultMaxSpawns;
        // Token: 0x040002AA RID: 682
        public static int spawnRate = NpcMgr.defaultSpawnRate;

        // Token: 0x04000233 RID: 563
        public static int spawnSpaceX = 3;

        // Token: 0x04000234 RID: 564
        public static int spawnSpaceY = 3;

        // Token: 0x04000255 RID: 597
        public static int townRangeX = NpcMgr.sWidth;

        // Token: 0x04000256 RID: 598
        public static int townRangeY = NpcMgr.sHeight;


        // Token: 0x04000294 RID: 660
        public static bool downedAncientCultist = false;

        // Token: 0x04000282 RID: 642
        public static bool downedBoss1 = false;

        // Token: 0x04000283 RID: 643
        public static bool downedBoss2 = false;

        // Token: 0x04000284 RID: 644
        public static bool downedBoss3 = false;

        // Token: 0x04000291 RID: 657
        public static bool downedChristmasIceQueen = false;

        // Token: 0x04000293 RID: 659
        public static bool downedChristmasSantank = false;

        // Token: 0x04000292 RID: 658
        public static bool downedChristmasTree = false;

        // Token: 0x0400028A RID: 650
        public static bool downedClown = false;

        // Token: 0x0400028E RID: 654
        public static bool downedFishron = false;

        // Token: 0x04000288 RID: 648
        public static bool downedFrost = false;

        // Token: 0x04000287 RID: 647
        public static bool downedGoblins = false;

        // Token: 0x0400028C RID: 652
        public static bool downedGolemBoss = false;

        // Token: 0x04000290 RID: 656
        public static bool downedHalloweenKing = false;

        // Token: 0x0400028F RID: 655
        public static bool downedHalloweenTree = false;

        // Token: 0x0400028D RID: 653
        public static bool downedMartians = false;

        // Token: 0x040002A6 RID: 678
        public static bool downedMechBoss1 = false;

        // Token: 0x040002A7 RID: 679
        public static bool downedMechBoss2 = false;

        // Token: 0x040002A8 RID: 680
        public static bool downedMechBoss3 = false;

        // Token: 0x040002A5 RID: 677
        public static bool downedMechBossAny = false;

        // Token: 0x04000295 RID: 661
        public static bool downedMoonlord = false;

        // Token: 0x04000289 RID: 649
        public static bool downedPirates = false;

        // Token: 0x0400028B RID: 651
        public static bool downedPlantBoss = false;

        // Token: 0x04000285 RID: 645
        public static bool downedQueenBee = false;

        // Token: 0x04000286 RID: 646
        public static bool downedSlimeKing = false;

        // Token: 0x04000298 RID: 664
        public static bool downedTowerNebula = false;

        // Token: 0x04000296 RID: 662
        public static bool downedTowerSolar = false;

        // Token: 0x04000299 RID: 665
        public static bool downedTowerStardust = false;

        // Token: 0x04000297 RID: 663
        public static bool downedTowerVortex = false;
        // Token: 0x0400029C RID: 668
        public static int ShieldStrengthTowerNebula = 0;

        // Token: 0x0400029A RID: 666
        public static int ShieldStrengthTowerSolar = 0;

        // Token: 0x0400029D RID: 669
        public static int ShieldStrengthTowerStardust = 0;

        // Token: 0x0400029B RID: 667
        public static int ShieldStrengthTowerVortex = 0;


        // Token: 0x04000217 RID: 535
        public static readonly int[, , ,] MoonLordAttacksArray = NpcMgr.InitializeMoonLordAttacks();

        // Token: 0x04000218 RID: 536
        public static readonly int[,] MoonLordAttacksArray2 = NpcMgr.InitializeMoonLordAttacks2();

        // Token: 0x04000219 RID: 537
        public static int MoonLordCountdown = 0;

        // Token: 0x0600020F RID: 527 RVA: 0x000EB700 File Offset: 0x000E9900
        public static int[, , ,] InitializeMoonLordAttacks()
        {
            int[, , ,] array;
            if (NpcMgr.MoonLordAttacksArray != null)
            {
                array = NpcMgr.MoonLordAttacksArray;
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        for (int k = 0; k < array.GetLength(2); k++)
                        {
                            for (int l = 0; l < array.GetLength(3); l++)
                            {
                                array[i, j, k, l] = 0;
                            }
                        }
                    }
                }
            }
            else
            {
                array = new int[3, 3, 2, 5];
            }
            array[0, 0, 0, 0] = 0;
            array[0, 0, 1, 0] = 60;
            array[0, 0, 0, 1] = 1;
            array[0, 0, 1, 1] = 70;
            array[0, 0, 0, 2] = 2;
            array[0, 0, 1, 2] = 330;
            array[0, 0, 0, 3] = 0;
            array[0, 0, 1, 3] = 60;
            array[0, 0, 0, 4] = 3;
            array[0, 0, 1, 4] = 90;
            array[0, 1, 0, 0] = 1;
            array[0, 1, 1, 0] = 70;
            array[0, 1, 0, 1] = 0;
            array[0, 1, 1, 1] = 120;
            array[0, 1, 0, 2] = 3;
            array[0, 1, 1, 2] = 90;
            array[0, 1, 0, 3] = 0;
            array[0, 1, 1, 3] = 120;
            array[0, 1, 0, 4] = 2;
            array[0, 1, 1, 4] = 390;
            array[0, 2, 0, 0] = 3;
            array[0, 2, 1, 0] = 90;
            array[0, 2, 0, 1] = 0;
            array[0, 2, 1, 1] = 120;
            array[0, 2, 0, 2] = 2;
            array[0, 2, 1, 2] = 435;
            array[0, 2, 0, 3] = 0;
            array[0, 2, 1, 3] = 120;
            array[0, 2, 0, 4] = 1;
            array[0, 2, 1, 4] = 375;
            array[1, 0, 0, 0] = 0;
            array[1, 0, 1, 0] = 0;
            array[1, 0, 0, 1] = 0;
            array[1, 0, 1, 1] = 0;
            array[1, 0, 0, 2] = 0;
            array[1, 0, 1, 2] = 0;
            array[1, 0, 0, 3] = 0;
            array[1, 0, 1, 3] = 0;
            array[1, 0, 0, 4] = 0;
            array[1, 0, 1, 4] = 0;
            array[1, 1, 0, 0] = 0;
            array[1, 1, 1, 0] = 0;
            array[1, 1, 0, 1] = 0;
            array[1, 1, 1, 1] = 0;
            array[1, 1, 0, 2] = 0;
            array[1, 1, 1, 2] = 0;
            array[1, 1, 0, 3] = 0;
            array[1, 1, 1, 3] = 0;
            array[1, 1, 0, 4] = 0;
            array[1, 1, 1, 4] = 0;
            array[1, 2, 0, 0] = 0;
            array[1, 2, 1, 0] = 0;
            array[1, 2, 0, 1] = 0;
            array[1, 2, 1, 1] = 0;
            array[1, 2, 0, 2] = 0;
            array[1, 2, 1, 2] = 0;
            array[1, 2, 0, 3] = 0;
            array[1, 2, 1, 3] = 0;
            array[1, 2, 0, 4] = 0;
            array[1, 2, 1, 4] = 0;
            array[2, 0, 0, 0] = 0;
            array[2, 0, 1, 0] = 0;
            array[2, 0, 0, 1] = 0;
            array[2, 0, 1, 1] = 0;
            array[2, 0, 0, 2] = 0;
            array[2, 0, 1, 2] = 0;
            array[2, 0, 0, 3] = 0;
            array[2, 0, 1, 3] = 0;
            array[2, 0, 0, 4] = 0;
            array[2, 0, 1, 4] = 0;
            array[2, 1, 0, 0] = 0;
            array[2, 1, 1, 0] = 0;
            array[2, 1, 0, 1] = 0;
            array[2, 1, 1, 1] = 0;
            array[2, 1, 0, 2] = 0;
            array[2, 1, 1, 2] = 0;
            array[2, 1, 0, 3] = 0;
            array[2, 1, 1, 3] = 0;
            array[2, 1, 0, 4] = 0;
            array[2, 1, 1, 4] = 0;
            array[2, 2, 0, 0] = 0;
            array[2, 2, 1, 0] = 0;
            array[2, 2, 0, 1] = 0;
            array[2, 2, 1, 1] = 0;
            array[2, 2, 0, 2] = 0;
            array[2, 2, 1, 2] = 0;
            array[2, 2, 0, 3] = 0;
            array[2, 2, 1, 3] = 0;
            array[2, 2, 0, 4] = 0;
            array[2, 2, 1, 4] = 0;
            NpcMgr.InitializeMoonLordAttacks2();
            return array;
        }

        // Token: 0x06000210 RID: 528 RVA: 0x000EBB80 File Offset: 0x000E9D80
        public static int[,] InitializeMoonLordAttacks2()
        {
            int[,] array;
            if (NpcMgr.MoonLordAttacksArray2 != null)
            {
                array = NpcMgr.MoonLordAttacksArray2;
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        array[i, j] = 0;
                    }
                }
            }
            else
            {
                array = new int[2, 10];
            }
            array[0, 0] = 0;
            array[1, 0] = 90;
            array[0, 1] = 1;
            array[1, 1] = 90;
            array[0, 2] = 0;
            array[1, 2] = 90;
            array[0, 3] = 2;
            array[1, 3] = 135;
            array[0, 4] = 0;
            array[1, 4] = 90;
            array[0, 5] = 3;
            array[1, 5] = 200;
            array[0, 6] = 0;
            array[1, 6] = 90;
            array[0, 7] = 4;
            array[1, 7] = 375;
            array[0, 8] = 0;
            array[1, 8] = 90;
            array[0, 9] = 2;
            array[1, 9] = 135;
            return array;
        }

        // Token: 0x06000266 RID: 614 RVA: 0x0019AF40 File Offset: 0x00199140
        public static void SlimeRainSpawns(int plr)
        {
            int logicCheckScreenHeight = Main.LogicCheckScreenHeight;
            int logicCheckScreenWidth = Main.LogicCheckScreenWidth;
            float num = 15f;
            Player player = Main.player[plr];
            if ((double)player.position.Y > Main.worldSurface * 16.0 + (double)(logicCheckScreenHeight / 2))
            {
                return;
            }
            if (player.activeNPCs > num)
            {
                return;
            }
            float num2 = player.activeNPCs / num;
            int num3 = 45 + (int)(450f * num2);
            if (Main.expertMode)
            {
                num3 = (int)((double)num3 * 0.85);
            }
            if (Main.rand.Next(num3) != 0)
            {
                return;
            }
            int num4 = (int)(player.Center.X - (float)logicCheckScreenWidth);
            int maxValue = num4 + logicCheckScreenWidth * 2;
            int minValue = (int)((double)player.Center.Y - (double)logicCheckScreenHeight * 1.5);
            int maxValue2 = (int)((double)player.Center.Y - (double)logicCheckScreenHeight * 0.75);
            int num5 = Main.rand.Next(num4, maxValue);
            int num6 = Main.rand.Next(minValue, maxValue2);
            num5 /= 16;
            num6 /= 16;
            if (num5 < 10 || num5 > Main.maxTilesX + 10)
            {
                return;
            }
            if ((double)num6 < Main.worldSurface * 0.3 || (double)num6 > Main.worldSurface)
            {
                return;
            }
            if (Collision.SolidTiles(num5 - 3, num5 + 3, num6 - 5, num6 + 2))
            {
                return;
            }
            if (Main.wallHouse[(int)Main.tile[num5, num6].wall])
            {
                return;
            }
            int num7 = NPC.NewNPC(num5 * 16 + 8, num6 * 16, 1, 0, 0f, 0f, 0f, 0f, 255);
            if (Main.rand.Next(200) == 0)
            {
                Main.npc[num7].SetDefaults(-4, -1f);
                return;
            }
            if (Main.expertMode)
            {
                if (Main.rand.Next(7) == 0)
                {
                    Main.npc[num7].SetDefaults(-7, -1f);
                    return;
                }
                if (Main.rand.Next(3) == 0)
                {
                    Main.npc[num7].SetDefaults(-3, -1f);
                    return;
                }
            }
            else
            {
                if (Main.rand.Next(10) == 0)
                {
                    Main.npc[num7].SetDefaults(-7, -1f);
                    return;
                }
                if (Main.rand.Next(5) < 2)
                {
                    Main.npc[num7].SetDefaults(-3, -1f);
                }
            }
        }

        // Token: 0x06000267 RID: 615 RVA: 0x0019B19C File Offset: 0x0019939C
        public static bool Spawning_SandstoneCheck(int x, int y)
        {
            if (!WorldGen.InWorld(x, y, 10))
            {
                return false;
            }
            int num = 0;
            for (int i = 0; i < 8; i++)
            {
                Tile tile = Main.tile[x, y + i];
                if (!tile.active() || !TileID.Sets.Conversion.Sand[(int)tile.type])
                {
                    break;
                }
                num++;
                for (int j = 1; j <= 4; j++)
                {
                    tile = Main.tile[x + j, y + i];
                    if (!tile.active() || !TileID.Sets.Conversion.Sand[(int)tile.type])
                    {
                        break;
                    }
                    num++;
                }
                for (int k = 1; k <= 4; k++)
                {
                    tile = Main.tile[x - k, y + i];
                    if (!tile.active() || !TileID.Sets.Conversion.Sand[(int)tile.type])
                    {
                        break;
                    }
                    num++;
                }
            }
            return num >= 40;
        }

        // Token: 0x06000268 RID: 616 RVA: 0x0019B274 File Offset: 0x00199474
        public static void SpawnNPC()
        {
            if (NpcMgr.noSpawnCycle)
            {
                NpcMgr.noSpawnCycle = false;
                return;
            }
            bool flag = false;
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            for (int i = 0; i < 255; i++)
            {
                if (Main.player[i].active)
                {
                    num4++;
                }
            }
            for (int j = 0; j < 255; j++)
            {
                if (Main.player[j].active && !Main.player[j].dead)
                {
                    if (Main.slimeRain)
                    {
                        NpcMgr.SlimeRainSpawns(j);
                    }
                    bool flag2 = false;
                    bool flag3 = false;
                    bool flag4 = false;
                    bool flag5 = false;
                    bool flag6 = false;
                    bool flag7 = false;
                    bool flag8 = false;
                    bool flag9 = false;
                    bool flag10 = false;
                    bool flag11 = false;
                    bool flag12 = NpcMgr.downedPlantBoss && Main.hardMode;
                    if (Main.player[j].active && Main.invasionType > 0 && Main.invasionDelay == 0 && Main.invasionSize > 0 && (double)Main.player[j].position.Y < Main.worldSurface * 16.0 + (double)NpcMgr.sHeight)
                    {
                        int num5 = 3000;
                        if ((double)Main.player[j].position.X > Main.invasionX * 16.0 - (double)num5 && (double)Main.player[j].position.X < Main.invasionX * 16.0 + (double)num5)
                        {
                            flag4 = true;
                        }
                        else if (Main.invasionX >= (double)(Main.maxTilesX / 2 - 5) && Main.invasionX <= (double)(Main.maxTilesX / 2 + 5))
                        {
                            int k = 0;
                            while (k < 200)
                            {
                                if (Main.npc[k].townNPC && Math.Abs(Main.player[j].position.X - Main.npc[k].Center.X) < (float)num5)
                                {
                                    if (Main.rand.Next(3) == 0)
                                    {
                                        flag4 = true;
                                        break;
                                    }
                                    break;
                                }
                                else
                                {
                                    k++;
                                }
                            }
                        }
                    }
                    if (Main.player[j].ZoneTowerSolar || Main.player[j].ZoneTowerNebula || Main.player[j].ZoneTowerVortex || Main.player[j].ZoneTowerStardust)
                    {
                        flag4 = true;
                    }
                    bool flag13 = false;
                    NpcMgr.spawnRate = NpcMgr.defaultSpawnRate;
                    NpcMgr.maxSpawns = NpcMgr.defaultMaxSpawns;
                    if (Main.hardMode)
                    {
                        NpcMgr.spawnRate = (int)((double)NpcMgr.defaultSpawnRate * 0.9);
                        NpcMgr.maxSpawns = NpcMgr.defaultMaxSpawns + 1;
                    }
                    if (Main.player[j].position.Y > (float)((Main.maxTilesY - 200) * 16))
                    {
                        NpcMgr.maxSpawns = (int)((float)NpcMgr.maxSpawns * 2f);
                    }
                    else if ((double)Main.player[j].position.Y > Main.rockLayer * 16.0 + (double)NpcMgr.sHeight)
                    {
                        NpcMgr.spawnRate = (int)((double)NpcMgr.spawnRate * 0.4);
                        NpcMgr.maxSpawns = (int)((float)NpcMgr.maxSpawns * 1.9f);
                    }
                    else if ((double)Main.player[j].position.Y > Main.worldSurface * 16.0 + (double)NpcMgr.sHeight)
                    {
                        if (Main.hardMode)
                        {
                            NpcMgr.spawnRate = (int)((double)NpcMgr.spawnRate * 0.45);
                            NpcMgr.maxSpawns = (int)((float)NpcMgr.maxSpawns * 1.8f);
                        }
                        else
                        {
                            NpcMgr.spawnRate = (int)((double)NpcMgr.spawnRate * 0.5);
                            NpcMgr.maxSpawns = (int)((float)NpcMgr.maxSpawns * 1.7f);
                        }
                    }
                    else if (!Main.dayTime)
                    {
                        NpcMgr.spawnRate = (int)((double)NpcMgr.spawnRate * 0.6);
                        NpcMgr.maxSpawns = (int)((float)NpcMgr.maxSpawns * 1.3f);
                        if (Main.bloodMoon)
                        {
                            NpcMgr.spawnRate = (int)((double)NpcMgr.spawnRate * 0.3);
                            NpcMgr.maxSpawns = (int)((float)NpcMgr.maxSpawns * 1.8f);
                        }
                        if ((Main.pumpkinMoon || Main.snowMoon) && (double)Main.player[j].position.Y < Main.worldSurface * 16.0)
                        {
                            NpcMgr.spawnRate = (int)((double)NpcMgr.spawnRate * 0.2);
                            NpcMgr.maxSpawns *= 2;
                        }
                    }
                    else if (Main.dayTime && Main.eclipse)
                    {
                        NpcMgr.spawnRate = (int)((double)NpcMgr.spawnRate * 0.2);
                        NpcMgr.maxSpawns = (int)((float)NpcMgr.maxSpawns * 1.9f);
                    }
                    if (Main.player[j].ZoneSnow && (double)(Main.player[j].position.Y / 16f) < Main.worldSurface)
                    {
                        NpcMgr.maxSpawns = (int)((float)NpcMgr.maxSpawns + (float)NpcMgr.maxSpawns * Main.cloudAlpha);
                        NpcMgr.spawnRate = (int)((float)NpcMgr.spawnRate * (1f - Main.cloudAlpha + 1f) / 2f);
                    }
                    if (Main.player[j].ZoneDungeon)
                    {
                        NpcMgr.spawnRate = (int)((double)NpcMgr.spawnRate * 0.4);
                        NpcMgr.maxSpawns = (int)((float)NpcMgr.maxSpawns * 1.7f);
                    }
                    else if (Main.player[j].ZoneSandstorm)
                    {
                        NpcMgr.spawnRate = (int)((float)NpcMgr.spawnRate * (Main.hardMode ? 0.4f : 0.9f));
                        NpcMgr.maxSpawns = (int)((float)NpcMgr.maxSpawns * (Main.hardMode ? 1.5f : 1.2f));
                    }
                    else if (Main.player[j].ZoneUndergroundDesert)
                    {
                        NpcMgr.spawnRate = (int)((float)NpcMgr.spawnRate * (Main.hardMode ? 0.2f : 0.3f));
                        NpcMgr.maxSpawns = (int)((float)NpcMgr.maxSpawns * 2f);
                    }
                    else if (Main.player[j].ZoneJungle)
                    {
                        NpcMgr.spawnRate = (int)((double)NpcMgr.spawnRate * 0.4);
                        NpcMgr.maxSpawns = (int)((float)NpcMgr.maxSpawns * 1.5f);
                    }
                    else if (Main.player[j].ZoneCorrupt || Main.player[j].ZoneCrimson)
                    {
                        NpcMgr.spawnRate = (int)((double)NpcMgr.spawnRate * 0.65);
                        NpcMgr.maxSpawns = (int)((float)NpcMgr.maxSpawns * 1.3f);
                    }
                    else if (Main.player[j].ZoneMeteor)
                    {
                        NpcMgr.spawnRate = (int)((double)NpcMgr.spawnRate * 0.4);
                        NpcMgr.maxSpawns = (int)((float)NpcMgr.maxSpawns * 1.1f);
                    }
                    if (Main.player[j].ZoneHoly && (double)Main.player[j].position.Y > Main.rockLayer * 16.0 + (double)NpcMgr.sHeight)
                    {
                        NpcMgr.spawnRate = (int)((double)NpcMgr.spawnRate * 0.65);
                        NpcMgr.maxSpawns = (int)((float)NpcMgr.maxSpawns * 1.3f);
                    }
                    if (Main.wof >= 0 && Main.player[j].position.Y > (float)((Main.maxTilesY - 200) * 16))
                    {
                        NpcMgr.maxSpawns = (int)((float)NpcMgr.maxSpawns * 0.3f);
                        NpcMgr.spawnRate *= 3;
                    }
                    if ((double)Main.player[j].activeNPCs < (double)NpcMgr.maxSpawns * 0.2)
                    {
                        NpcMgr.spawnRate = (int)((float)NpcMgr.spawnRate * 0.6f);
                    }
                    else if ((double)Main.player[j].activeNPCs < (double)NpcMgr.maxSpawns * 0.4)
                    {
                        NpcMgr.spawnRate = (int)((float)NpcMgr.spawnRate * 0.7f);
                    }
                    else if ((double)Main.player[j].activeNPCs < (double)NpcMgr.maxSpawns * 0.6)
                    {
                        NpcMgr.spawnRate = (int)((float)NpcMgr.spawnRate * 0.8f);
                    }
                    else if ((double)Main.player[j].activeNPCs < (double)NpcMgr.maxSpawns * 0.8)
                    {
                        NpcMgr.spawnRate = (int)((float)NpcMgr.spawnRate * 0.9f);
                    }
                    if ((double)(Main.player[j].position.Y / 16f) > (Main.worldSurface + Main.rockLayer) / 2.0 || Main.player[j].ZoneCorrupt || Main.player[j].ZoneCrimson)
                    {
                        if ((double)Main.player[j].activeNPCs < (double)NpcMgr.maxSpawns * 0.2)
                        {
                            NpcMgr.spawnRate = (int)((float)NpcMgr.spawnRate * 0.7f);
                        }
                        else if ((double)Main.player[j].activeNPCs < (double)NpcMgr.maxSpawns * 0.4)
                        {
                            NpcMgr.spawnRate = (int)((float)NpcMgr.spawnRate * 0.9f);
                        }
                    }
                    if (Main.player[j].calmed)
                    {
                        NpcMgr.spawnRate = (int)((float)NpcMgr.spawnRate * 1.3f);
                        NpcMgr.maxSpawns = (int)((float)NpcMgr.maxSpawns * 0.7f);
                    }
                    if (Main.player[j].sunflower)
                    {
                        NpcMgr.spawnRate = (int)((float)NpcMgr.spawnRate * 1.2f);
                        NpcMgr.maxSpawns = (int)((float)NpcMgr.maxSpawns * 0.8f);
                    }
                    if (Main.player[j].enemySpawns)
                    {
                        NpcMgr.spawnRate = (int)((double)NpcMgr.spawnRate * 0.5);
                        NpcMgr.maxSpawns = (int)((float)NpcMgr.maxSpawns * 2f);
                    }
                    if (Main.player[j].ZoneWaterCandle || Main.player[j].inventory[Main.player[j].selectedItem].type == 148)
                    {
                        if (!Main.player[j].ZonePeaceCandle && Main.player[j].inventory[Main.player[j].selectedItem].type != 3117)
                        {
                            NpcMgr.spawnRate = (int)((double)NpcMgr.spawnRate * 0.75);
                            NpcMgr.maxSpawns = (int)((float)NpcMgr.maxSpawns * 1.5f);
                        }
                    }
                    else if (Main.player[j].ZonePeaceCandle || Main.player[j].inventory[Main.player[j].selectedItem].type == 3117)
                    {
                        NpcMgr.spawnRate = (int)((double)NpcMgr.spawnRate * 1.3);
                        NpcMgr.maxSpawns = (int)((float)NpcMgr.maxSpawns * 0.7f);
                    }
                    if (Main.player[j].ZoneWaterCandle && (double)(Main.player[j].position.Y / 16f) < Main.worldSurface * 0.34999999403953552)
                    {
                        NpcMgr.spawnRate = (int)((double)NpcMgr.spawnRate * 0.5);
                    }
                    if ((double)NpcMgr.spawnRate < (double)NpcMgr.defaultSpawnRate * 0.1)
                    {
                        NpcMgr.spawnRate = (int)((double)NpcMgr.defaultSpawnRate * 0.1);
                    }
                    if (NpcMgr.maxSpawns > NpcMgr.defaultMaxSpawns * 3)
                    {
                        NpcMgr.maxSpawns = NpcMgr.defaultMaxSpawns * 3;
                    }
                    if ((Main.pumpkinMoon || Main.snowMoon) && (double)Main.player[j].position.Y < Main.worldSurface * 16.0)
                    {
                        NpcMgr.maxSpawns = (int)((double)NpcMgr.defaultMaxSpawns * (2.0 + 0.3 * (double)num4));
                        NpcMgr.spawnRate = 20;
                    }
                    if (DD2Event.Ongoing && Main.player[j].ZoneOldOneArmy)
                    {
                        NpcMgr.maxSpawns = NpcMgr.defaultMaxSpawns;
                        NpcMgr.spawnRate = NpcMgr.defaultSpawnRate;
                    }
                    if (flag4)
                    {
                        NpcMgr.maxSpawns = (int)((double)NpcMgr.defaultMaxSpawns * (2.0 + 0.3 * (double)num4));
                        NpcMgr.spawnRate = 20;
                    }
                    if (Main.player[j].ZoneDungeon && !NpcMgr.downedBoss3)
                    {
                        NpcMgr.spawnRate = 10;
                    }
                    if (!flag4 && ((!Main.bloodMoon && !Main.pumpkinMoon && !Main.snowMoon) || Main.dayTime) && (!Main.eclipse || !Main.dayTime) && !Main.player[j].ZoneDungeon && !Main.player[j].ZoneCorrupt && !Main.player[j].ZoneCrimson && !Main.player[j].ZoneMeteor && !Main.player[j].ZoneOldOneArmy)
                    {
                        if (Main.player[j].Center.Y / 16f > (float)(Main.maxTilesY - 200))
                        {
                            if (Main.player[j].townNPCs == 1f)
                            {
                                if (Main.rand.Next(2) == 0)
                                {
                                    flag3 = true;
                                }
                                if (Main.rand.Next(10) == 0)
                                {
                                    flag10 = true;
                                    NpcMgr.maxSpawns = (int)((double)((float)NpcMgr.maxSpawns) * 0.5);
                                }
                                else
                                {
                                    NpcMgr.spawnRate = (int)((double)((float)NpcMgr.spawnRate) * 1.25);
                                }
                            }
                            else if (Main.player[j].townNPCs == 2f)
                            {
                                if (Main.rand.Next(4) != 0)
                                {
                                    flag3 = true;
                                }
                                if (Main.rand.Next(5) == 0)
                                {
                                    flag10 = true;
                                    NpcMgr.maxSpawns = (int)((double)((float)NpcMgr.maxSpawns) * 0.5);
                                }
                                else
                                {
                                    NpcMgr.spawnRate = (int)((double)((float)NpcMgr.spawnRate) * 1.5);
                                }
                            }
                            else if (Main.player[j].townNPCs >= 3f)
                            {
                                if (Main.rand.Next(10) != 0)
                                {
                                    flag3 = true;
                                }
                                if (Main.rand.Next(3) == 0)
                                {
                                    flag10 = true;
                                    NpcMgr.maxSpawns = (int)((double)((float)NpcMgr.maxSpawns) * 0.5);
                                }
                                else
                                {
                                    NpcMgr.spawnRate = (int)((float)NpcMgr.spawnRate * 2f);
                                }
                            }
                        }
                        else if (Main.player[j].townNPCs == 1f)
                        {
                            flag3 = true;
                            if (Main.rand.Next(3) == 1)
                            {
                                flag10 = true;
                                NpcMgr.maxSpawns = (int)((double)((float)NpcMgr.maxSpawns) * 0.6);
                            }
                            else
                            {
                                NpcMgr.spawnRate = (int)((float)NpcMgr.spawnRate * 2f);
                            }
                        }
                        else if (Main.player[j].townNPCs == 2f)
                        {
                            flag3 = true;
                            if (Main.rand.Next(3) != 0)
                            {
                                flag10 = true;
                                NpcMgr.maxSpawns = (int)((double)((float)NpcMgr.maxSpawns) * 0.6);
                            }
                            else
                            {
                                NpcMgr.spawnRate = (int)((float)NpcMgr.spawnRate * 3f);
                            }
                        }
                        else if (Main.player[j].townNPCs >= 3f)
                        {
                            flag3 = true;
                            if (!Main.expertMode || Main.rand.Next(30) != 0)
                            {
                                flag10 = true;
                            }
                            NpcMgr.maxSpawns = (int)((double)((float)NpcMgr.maxSpawns) * 0.6);
                        }
                    }
                    int num6 = (int)(Main.player[j].position.X + (float)(Main.player[j].width / 2)) / 16;
                    int num7 = (int)(Main.player[j].position.Y + (float)(Main.player[j].height / 2)) / 16;
                    if (Main.wallHouse[(int)Main.tile[num6, num7].wall])
                    {
                        flag3 = true;
                    }
                    if (Main.tile[num6, num7].wall == 87)
                    {
                        flag2 = true;
                    }
                    bool flag14 = false;
                    if (Main.player[j].active && !Main.player[j].dead && Main.player[j].activeNPCs < (float)NpcMgr.maxSpawns && Main.rand.Next(NpcMgr.spawnRate) == 0)
                    {
                        NpcMgr.spawnRangeX = (int)((double)(NpcMgr.sWidth / 16) * 0.7);
                        NpcMgr.spawnRangeY = (int)((double)(NpcMgr.sHeight / 16) * 0.7);
                        NpcMgr.safeRangeX = (int)((double)(NpcMgr.sWidth / 16) * 0.52);
                        NpcMgr.safeRangeY = (int)((double)(NpcMgr.sHeight / 16) * 0.52);
                        if (Main.player[j].inventory[Main.player[j].selectedItem].type == 1254 || Main.player[j].inventory[Main.player[j].selectedItem].type == 1299 || Main.player[j].scope)
                        {
                            float num8 = 1.5f;
                            if (Main.player[j].inventory[Main.player[j].selectedItem].type == 1254 && Main.player[j].scope)
                            {
                                num8 = 1.25f;
                            }
                            else if (Main.player[j].inventory[Main.player[j].selectedItem].type == 1254)
                            {
                                num8 = 1.5f;
                            }
                            else if (Main.player[j].inventory[Main.player[j].selectedItem].type == 1299)
                            {
                                num8 = 1.5f;
                            }
                            else if (Main.player[j].scope)
                            {
                                num8 = 2f;
                            }
                            NpcMgr.spawnRangeX += (int)((double)(NpcMgr.sWidth / 16) * 0.5 / (double)num8);
                            NpcMgr.spawnRangeY += (int)((double)(NpcMgr.sHeight / 16) * 0.5 / (double)num8);
                            NpcMgr.safeRangeX += (int)((double)(NpcMgr.sWidth / 16) * 0.5 / (double)num8);
                            NpcMgr.safeRangeY += (int)((double)(NpcMgr.sHeight / 16) * 0.5 / (double)num8);
                        }
                        int num9 = (int)(Main.player[j].position.X / 16f) - NpcMgr.spawnRangeX;
                        int num10 = (int)(Main.player[j].position.X / 16f) + NpcMgr.spawnRangeX;
                        int num11 = (int)(Main.player[j].position.Y / 16f) - NpcMgr.spawnRangeY;
                        int num12 = (int)(Main.player[j].position.Y / 16f) + NpcMgr.spawnRangeY;
                        int num13 = (int)(Main.player[j].position.X / 16f) - NpcMgr.safeRangeX;
                        int num14 = (int)(Main.player[j].position.X / 16f) + NpcMgr.safeRangeX;
                        int num15 = (int)(Main.player[j].position.Y / 16f) - NpcMgr.safeRangeY;
                        int num16 = (int)(Main.player[j].position.Y / 16f) + NpcMgr.safeRangeY;
                        if (num9 < 0)
                        {
                            num9 = 0;
                        }
                        if (num10 > Main.maxTilesX)
                        {
                            num10 = Main.maxTilesX;
                        }
                        if (num11 < 0)
                        {
                            num11 = 0;
                        }
                        if (num12 > Main.maxTilesY)
                        {
                            num12 = Main.maxTilesY;
                        }
                        int l = 0;
                        while (l < 50)
                        {
                            int num17 = Main.rand.Next(num9, num10);
                            int num18 = Main.rand.Next(num11, num12);
                            if (Main.tile[num17, num18].nactive() && Main.tileSolid[(int)Main.tile[num17, num18].type])
                            {
                                goto IL_1540;
                            }
                            if (!Main.wallHouse[(int)Main.tile[num17, num18].wall])
                            {
                                if (!flag4 && (double)num18 < Main.worldSurface * 0.34999999403953552 && !flag10 && ((double)num17 < (double)Main.maxTilesX * 0.45 || (double)num17 > (double)Main.maxTilesX * 0.55 || Main.hardMode))
                                {
                                    num3 = (int)Main.tile[num17, num18].type;
                                    num = num17;
                                    num2 = num18;
                                    flag13 = true;
                                    flag = true;
                                }
                                else if (!flag4 && (double)num18 < Main.worldSurface * 0.44999998807907104 && !flag10 && Main.hardMode && Main.rand.Next(10) == 0)
                                {
                                    num3 = (int)Main.tile[num17, num18].type;
                                    num = num17;
                                    num2 = num18;
                                    flag13 = true;
                                    flag = true;
                                }
                                else
                                {
                                    int m = num18;
                                    while (m < Main.maxTilesY)
                                    {
                                        if (Main.tile[num17, m].nactive() && Main.tileSolid[(int)Main.tile[num17, m].type])
                                        {
                                            if (num17 < num13 || num17 > num14 || m < num15 || m > num16)
                                            {
                                                num3 = (int)Main.tile[num17, m].type;
                                                num = num17;
                                                num2 = m;
                                                flag13 = true;
                                                break;
                                            }
                                            break;
                                        }
                                        else
                                        {
                                            m++;
                                        }
                                    }
                                }
                                if (!flag13)
                                {
                                    goto IL_1540;
                                }
                                int num19 = num - NpcMgr.spawnSpaceX / 2;
                                int num20 = num + NpcMgr.spawnSpaceX / 2;
                                int num21 = num2 - NpcMgr.spawnSpaceY;
                                int num22 = num2;
                                if (num19 < 0)
                                {
                                    flag13 = false;
                                }
                                if (num20 > Main.maxTilesX)
                                {
                                    flag13 = false;
                                }
                                if (num21 < 0)
                                {
                                    flag13 = false;
                                }
                                if (num22 > Main.maxTilesY)
                                {
                                    flag13 = false;
                                }
                                if (flag13)
                                {
                                    for (int n = num19; n < num20; n++)
                                    {
                                        for (int num23 = num21; num23 < num22; num23++)
                                        {
                                            if (Main.tile[n, num23].nactive() && Main.tileSolid[(int)Main.tile[n, num23].type])
                                            {
                                                flag13 = false;
                                                break;
                                            }
                                            if (Main.tile[n, num23].lava())
                                            {
                                                flag13 = false;
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (num >= num13 && num <= num14)
                                {
                                    flag14 = true;
                                    goto IL_1540;
                                }
                                goto IL_1540;
                            }
                        IL_1546:
                            l++;
                            continue;
                        IL_1540:
                            if (!flag13 && !flag13)
                            {
                                goto IL_1546;
                            }
                            break;
                        }
                    }
                    if (flag13)
                    {
                        Rectangle rectangle = new Rectangle(num * 16, num2 * 16, 16, 16);
                        for (int num24 = 0; num24 < 255; num24++)
                        {
                            if (Main.player[num24].active)
                            {
                                Rectangle rectangle2 = new Rectangle((int)(Main.player[num24].position.X + (float)(Main.player[num24].width / 2) - (float)(NpcMgr.sWidth / 2) - (float)NpcMgr.safeRangeX), (int)(Main.player[num24].position.Y + (float)(Main.player[num24].height / 2) - (float)(NpcMgr.sHeight / 2) - (float)NpcMgr.safeRangeY), NpcMgr.sWidth + NpcMgr.safeRangeX * 2, NpcMgr.sHeight + NpcMgr.safeRangeY * 2);
                                if (rectangle.Intersects(rectangle2))
                                {
                                    flag13 = false;
                                }
                            }
                        }
                    }
                    if (flag13)
                    {
                        if (Main.player[j].ZoneDungeon && (!Main.tileDungeon[(int)Main.tile[num, num2].type] || Main.tile[num, num2 - 1].wall == 0))
                        {
                            flag13 = false;
                        }
                        if (Main.tile[num, num2 - 1].liquid > 0 && Main.tile[num, num2 - 2].liquid > 0 && !Main.tile[num, num2 - 1].lava())
                        {
                            if (Main.tile[num, num2 - 1].honey())
                            {
                                flag6 = true;
                            }
                            else
                            {
                                flag5 = true;
                            }
                        }
                        int num25 = (int)Main.player[j].Center.X / 16;
                        int num26 = (int)(Main.player[j].Bottom.Y + 8f) / 16;
                        if (Main.tile[num, num2].type == 367)
                        {
                            flag8 = true;
                        }
                        else if (Main.tile[num, num2].type == 368)
                        {
                            flag7 = true;
                        }
                        else if (Main.tile[num25, num26].type == 367)
                        {
                            flag8 = true;
                        }
                        else if (Main.tile[num25, num26].type == 368)
                        {
                            flag7 = true;
                        }
                        else
                        {
                            int num27 = Main.rand.Next(20, 31);
                            int num28 = Main.rand.Next(1, 4);
                            if (num - num27 < 0)
                            {
                                num27 = num;
                            }
                            if (num2 - num27 < 0)
                            {
                                num27 = num2;
                            }
                            if (num + num27 >= Main.maxTilesX)
                            {
                                num27 = Main.maxTilesX - num - 1;
                            }
                            if (num2 + num27 >= Main.maxTilesY)
                            {
                                num27 = Main.maxTilesY - num2 - 1;
                            }
                            for (int num29 = num - num27; num29 <= num + num27; num29 += num28)
                            {
                                int num30 = Main.rand.Next(1, 4);
                                for (int num31 = num2 - num27; num31 <= num2 + num27; num31 += num30)
                                {
                                    if (Main.tile[num29, num31].type == 367)
                                    {
                                        flag8 = true;
                                    }
                                    if (Main.tile[num29, num31].type == 368)
                                    {
                                        flag7 = true;
                                    }
                                }
                            }
                            num27 = Main.rand.Next(30, 61);
                            num28 = Main.rand.Next(3, 7);
                            if (num25 - num27 < 0)
                            {
                                num27 = num25;
                            }
                            if (num26 - num27 < 0)
                            {
                                num27 = num26;
                            }
                            if (num25 + num27 >= Main.maxTilesX)
                            {
                                num27 = Main.maxTilesX - num25 - 2;
                            }
                            if (num26 + num27 >= Main.maxTilesY)
                            {
                                num27 = Main.maxTilesY - num26 - 2;
                            }
                            for (int num32 = num25 - num27; num32 <= num25 + num27; num32 += num28)
                            {
                                int num33 = Main.rand.Next(3, 7);
                                for (int num34 = num26 - num27; num34 <= num26 + num27; num34 += num33)
                                {
                                    if (Main.tile[num32, num34].type == 367)
                                    {
                                        flag8 = true;
                                    }
                                    if (Main.tile[num32, num34].type == 368)
                                    {
                                        flag7 = true;
                                    }
                                }
                            }
                        }
                    }
                    if (flag6)
                    {
                        flag13 = false;
                    }
                    if (flag13)
                    {
                        if ((double)num2 > Main.rockLayer && num2 < Main.maxTilesY - 200 && !Main.player[j].ZoneDungeon && !flag4)
                        {
                            if (Main.rand.Next(3) == 0)
                            {
                                int num35 = Main.rand.Next(5, 15);
                                if (num - num35 >= 0 && num + num35 < Main.maxTilesX)
                                {
                                    for (int num36 = num - num35; num36 < num + num35; num36++)
                                    {
                                        for (int num37 = num2 - num35; num37 < num2 + num35; num37++)
                                        {
                                            if (Main.tile[num36, num37].wall == 62)
                                            {
                                                flag9 = true;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                int num38 = (int)Main.player[j].position.X / 16;
                                int num39 = (int)Main.player[j].position.Y / 16;
                                if (Main.tile[num38, num39].wall == 62)
                                {
                                    flag9 = true;
                                }
                            }
                        }
                        if ((double)num2 < Main.rockLayer && num2 > 200 && !Main.player[j].ZoneDungeon && !flag4)
                        {
                            if (Main.rand.Next(3) == 0)
                            {
                                int num40 = Main.rand.Next(5, 15);
                                if (num - num40 >= 0 && num + num40 < Main.maxTilesX)
                                {
                                    for (int num41 = num - num40; num41 < num + num40; num41++)
                                    {
                                        for (int num42 = num2 - num40; num42 < num2 + num40; num42++)
                                        {
                                            if (WallID.Sets.Conversion.Sandstone[(int)Main.tile[num41, num42].wall] || WallID.Sets.Conversion.HardenedSand[(int)Main.tile[num41, num42].wall])
                                            {
                                                flag11 = true;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                int num43 = (int)Main.player[j].position.X / 16;
                                int num44 = (int)Main.player[j].position.Y / 16;
                                if (WallID.Sets.Conversion.Sandstone[(int)Main.tile[num43, num44].wall] || WallID.Sets.Conversion.HardenedSand[(int)Main.tile[num43, num44].wall])
                                {
                                    flag11 = true;
                                }
                            }
                        }
                        int num45 = (int)Main.tile[num, num2].type;
                        int num46 = 200;
                        if (Main.player[j].ZoneTowerNebula)
                        {
                            bool flag15 = true;
                            int num47 = 0;
                            while (flag15)
                            {
                                num47 = Utils.SelectRandom<int>(Main.rand, new int[]
								{
									424,
									424,
									424,
									423,
									423,
									423,
									421,
									421,
									421,
									421,
									421,
									420
								});
                                flag15 = false;
                                if (num47 == 424 && NPC.CountNPCS(num47) >= 2)
                                {
                                    flag15 = true;
                                }
                                if (num47 == 423 && NPC.CountNPCS(num47) >= 3)
                                {
                                    flag15 = true;
                                }
                                if (num47 == 420 && NPC.CountNPCS(num47) >= 2)
                                {
                                    flag15 = true;
                                }
                            }
                            if (num47 != 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, num47, 1, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if (Main.player[j].ZoneTowerVortex)
                        {
                            bool flag16 = true;
                            int num48 = 0;
                            while (flag16)
                            {
                                num48 = Utils.SelectRandom<int>(Main.rand, new int[]
								{
									429,
									429,
									429,
									429,
									427,
									427,
									425,
									425,
									426
								});
                                flag16 = false;
                                if (num48 == 425 && NPC.CountNPCS(num48) >= 3)
                                {
                                    flag16 = true;
                                }
                                if (num48 == 426 && NPC.CountNPCS(num48) >= 3)
                                {
                                    flag16 = true;
                                }
                                if (num48 == 429 && NPC.CountNPCS(num48) >= 4)
                                {
                                    flag16 = true;
                                }
                            }
                            if (num48 != 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, num48, 1, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if (Main.player[j].ZoneTowerStardust)
                        {
                            int num49 = Utils.SelectRandom<int>(Main.rand, new int[]
							{
								411,
								411,
								411,
								409,
								409,
								407,
								402,
								405
							});
                            if (num49 != 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, num49, 1, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if (Main.player[j].ZoneTowerSolar)
                        {
                            bool flag17 = true;
                            int num50 = 0;
                            while (flag17)
                            {
                                num50 = Utils.SelectRandom<int>(Main.rand, new int[]
								{
									518,
									419,
									418,
									412,
									417,
									416,
									415
								});
                                flag17 = false;
                                if (num50 == 415 && NPC.CountNPCS(num50) >= 2)
                                {
                                    flag17 = true;
                                }
                                if (num50 == 416 && NPC.CountNPCS(num50) >= 1)
                                {
                                    flag17 = true;
                                }
                                if (num50 == 518 && NPC.CountNPCS(num50) >= 2)
                                {
                                    flag17 = true;
                                }
                                if (num50 == 412 && NPC.CountNPCS(num50) >= 1)
                                {
                                    flag17 = true;
                                }
                            }
                            if (num50 != 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, num50, 1, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if (flag)
                        {
                            int maxValue = 8;
                            int maxValue2 = 30;
                            bool flag18 = (float)Math.Abs(num - Main.maxTilesX / 2) / (float)(Main.maxTilesX / 2) > 0.33f && (Main.wallLight[(int)Main.tile[num6, num7].wall] || Main.tile[num6, num7].wall == 73);
                            if (flag18 && NPC.AnyDanger())
                            {
                                flag18 = false;
                            }
                            if (Main.player[j].ZoneWaterCandle)
                            {
                                maxValue = 3;
                                maxValue2 = 10;
                            }
                            if (flag4 && Main.invasionType == 4)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 388, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (flag18 && Main.hardMode && NpcMgr.downedGolemBoss && ((!NpcMgr.downedMartians && Main.rand.Next(maxValue) == 0) || Main.rand.Next(maxValue2) == 0) && !NPC.AnyNPCs(399))
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 399, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (flag18 && Main.hardMode && NpcMgr.downedGolemBoss && ((!NpcMgr.downedMartians && Main.rand.Next(maxValue) == 0) || Main.rand.Next(maxValue2) == 0) && !NPC.AnyNPCs(399) && (Main.player[j].inventory[Main.player[j].selectedItem].type == 148 || Main.player[j].ZoneWaterCandle))
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 399, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.hardMode && !NPC.AnyNPCs(87) && !flag3 && Main.rand.Next(10) == 0)
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 87, 1, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.hardMode && !NPC.AnyNPCs(87) && !flag3 && Main.rand.Next(10) == 0 && (Main.player[j].inventory[Main.player[j].selectedItem].type == 148 || Main.player[j].ZoneWaterCandle))
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 87, 1, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 48, 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if (flag4)
                        {
                            if (Main.invasionType == 1)
                            {
                                if (Main.hardMode && !NPC.AnyNPCs(471) && Main.rand.Next(30) == 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 471, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(9) == 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 29, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(5) == 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 26, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 111, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 27, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 28, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (Main.invasionType == 2)
                            {
                                if (Main.rand.Next(7) == 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 145, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 143, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 144, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (Main.invasionType == 3)
                            {
                                if (Main.invasionSize < Main.invasionSizeStart / 2 && Main.rand.Next(20) == 0 && !NPC.AnyNPCs(491) && !Collision.SolidTiles(num - 20, num + 20, num2 - 40, num2 - 10))
                                {
                                    NPC.NewNPC(num * 16 + 8, (num2 - 10) * 16, 491, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(30) == 0 && !NPC.AnyNPCs(216))
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 216, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(11) == 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 215, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(9) == 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 252, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(7) == 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 214, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 213, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 212, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (Main.invasionType == 4)
                            {
                                int num51 = 0;
                                int num52 = Main.rand.Next(7);
                                if (Main.invasionSize <= 100 && Main.rand.Next(10) == 0 && !NPC.AnyNPCs(395))
                                {
                                    num51 = 395;
                                }
                                else if (num52 >= 6)
                                {
                                    if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(395))
                                    {
                                        num51 = 395;
                                    }
                                    else
                                    {
                                        int expr_2623 = Main.rand.Next(2);
                                        if (expr_2623 == 0)
                                        {
                                            num51 = 390;
                                        }
                                        if (expr_2623 == 1)
                                        {
                                            num51 = 386;
                                        }
                                    }
                                }
                                else if (num52 >= 4)
                                {
                                    int num53 = Main.rand.Next(5);
                                    if (num53 < 2)
                                    {
                                        num51 = 382;
                                    }
                                    else if (num53 < 4)
                                    {
                                        num51 = 381;
                                    }
                                    else
                                    {
                                        num51 = 388;
                                    }
                                }
                                else
                                {
                                    int num54 = Main.rand.Next(4);
                                    if (num54 == 3)
                                    {
                                        if (!NPC.AnyNPCs(520))
                                        {
                                            num51 = 520;
                                        }
                                        else
                                        {
                                            num54 = Main.rand.Next(3);
                                        }
                                    }
                                    if (num54 == 0)
                                    {
                                        num51 = 385;
                                    }
                                    if (num54 == 1)
                                    {
                                        num51 = 389;
                                    }
                                    if (num54 == 2)
                                    {
                                        num51 = 383;
                                    }
                                }
                                if (num51 != 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, num51, 1, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                        }
                        else if (!NpcMgr.savedBartender && DD2Event.ReadyToFindBartender && !NPC.AnyNPCs(579) && Main.rand.Next(80) == 0 && !flag5)
                        {
                            NPC.NewNPC(num * 16 + 8, num2 * 16, 579, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if (Main.tile[num, num2].wall == 62 | flag9)
                        {
                            if (Main.tile[num, num2].wall == 62 && Main.rand.Next(8) == 0 && !flag5 && (double)num2 >= Main.rockLayer && num2 < Main.maxTilesY - 210 && !NpcMgr.savedStylist && !NPC.AnyNPCs(354))
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 354, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.hardMode)
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 163, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 164, 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if (((WallID.Sets.Conversion.HardenedSand[(int)Main.tile[num, num2].wall] || WallID.Sets.Conversion.Sandstone[(int)Main.tile[num, num2].wall]) | flag11) && WorldGen.checkUnderground(num, num2))
                        {
                            if (Main.hardMode && Main.rand.Next(33) == 0 && !flag3 && (double)num2 > Main.worldSurface + 100.0)
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 510, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(22) == 0 && !flag3 && (double)num2 > Main.worldSurface + 100.0)
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 513, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.hardMode && Main.rand.Next(5) != 0)
                            {
                                List<int> list = new List<int>();
                                if (Main.player[j].ZoneCorrupt)
                                {
                                    list.Add(525);
                                    list.Add(525);
                                }
                                if (Main.player[j].ZoneCrimson)
                                {
                                    list.Add(526);
                                    list.Add(526);
                                }
                                if (Main.player[j].ZoneHoly)
                                {
                                    list.Add(527);
                                    list.Add(527);
                                }
                                if (list.Count == 0)
                                {
                                    list.Add(524);
                                    list.Add(524);
                                }
                                if (Main.player[j].ZoneCorrupt || Main.player[j].ZoneCrimson)
                                {
                                    list.Add(533);
                                    list.Add(529);
                                }
                                else
                                {
                                    list.Add(530);
                                    list.Add(528);
                                }
                                list.Add(532);
                                int num55 = Utils.SelectRandom<int>(Main.rand, list.ToArray());
                                NPC.NewNPC(num * 16 + 8, num2 * 16, num55, 0, 0f, 0f, 0f, 0f, 255);
                                list.Clear();
                            }
                            else
                            {
                                int num56 = Utils.SelectRandom<int>(Main.rand, new int[]
								{
									69,
									508,
									508,
									508,
									509
								});
                                NPC.NewNPC(num * 16 + 8, num2 * 16, num56, 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if ((Main.hardMode & flag5) && Main.player[j].ZoneJungle && Main.rand.Next(3) != 0)
                        {
                            NPC.NewNPC(num * 16 + 8, num2 * 16, 157, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if ((Main.hardMode & flag5) && Main.player[j].ZoneCrimson && Main.rand.Next(3) != 0)
                        {
                            NPC.NewNPC(num * 16 + 8, num2 * 16, 242, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if ((Main.hardMode & flag5) && Main.player[j].ZoneCrimson && Main.rand.Next(3) != 0)
                        {
                            NPC.NewNPC(num * 16 + 8, num2 * 16, 241, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if (flag5 && (num < 250 || num > Main.maxTilesX - 250) && Main.tileSand[num45] && (double)num2 < Main.rockLayer)
                        {
                            bool flag19 = false;
                            if (!NpcMgr.savedAngler && !NPC.AnyNPCs(376))
                            {
                                int num57 = -1;
                                for (int num58 = num2 - 1; num58 > num2 - 50; num58--)
                                {
                                    if (Main.tile[num, num58].liquid == 0 && !WorldGen.SolidTile(num, num58) && !WorldGen.SolidTile(num, num58 + 1) && !WorldGen.SolidTile(num, num58 + 2))
                                    {
                                        num57 = num58 + 2;
                                        break;
                                    }
                                }
                                if (num57 > num2)
                                {
                                    num57 = num2;
                                }
                                if (num57 > 0 && !flag14)
                                {
                                    NPC.NewNPC(num * 16 + 8, num57 * 16, 376, 0, 0f, 0f, 0f, 0f, 255);
                                    flag19 = true;
                                }
                            }
                            if (!flag19)
                            {
                                if (Main.rand.Next(60) == 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 220, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(25) == 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 221, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(8) == 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 65, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 67, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 64, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                        }
                        else if (!flag5 && !NpcMgr.savedAngler && !NPC.AnyNPCs(376) && (num < 340 || num > Main.maxTilesX - 340) && Main.tileSand[num45] && (double)num2 < Main.worldSurface)
                        {
                            NPC.NewNPC(num * 16 + 8, num2 * 16, 376, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if (flag5 && (((double)num2 > Main.rockLayer && Main.rand.Next(2) == 0) || num45 == 60))
                        {
                            if (Main.hardMode && Main.rand.Next(3) > 0)
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 102, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 58, 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if (flag5 && (double)num2 > Main.worldSurface && Main.rand.Next(3) == 0)
                        {
                            if (Main.hardMode)
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 103, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 63, 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if (flag5 && Main.rand.Next(4) == 0)
                        {
                            if (Main.player[j].ZoneCorrupt)
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 57, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if ((double)num2 < Main.worldSurface && num2 > 50 && Main.rand.Next(3) != 0 && Main.dayTime)
                            {
                                int num59 = -1;
                                for (int num60 = num2 - 1; num60 > num2 - 50; num60--)
                                {
                                    if (Main.tile[num, num60].liquid == 0 && !WorldGen.SolidTile(num, num60) && !WorldGen.SolidTile(num, num60 + 1) && !WorldGen.SolidTile(num, num60 + 2))
                                    {
                                        num59 = num60 + 2;
                                        break;
                                    }
                                }
                                if (num59 > num2)
                                {
                                    num59 = num2;
                                }
                                if (num59 > 0 && !flag14)
                                {
                                    if (Main.rand.Next(2) == 0)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num59 * 16, 362, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else
                                    {
                                        NPC.NewNPC(num * 16 + 8, num59 * 16, 364, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                }
                                else
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 55, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 55, 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if (NpcMgr.downedGoblins && Main.rand.Next(20) == 0 && !flag5 && (double)num2 >= Main.rockLayer && num2 < Main.maxTilesY - 210 && !NpcMgr.savedGoblin && !NPC.AnyNPCs(105))
                        {
                            NPC.NewNPC(num * 16 + 8, num2 * 16, 105, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if (Main.hardMode && Main.rand.Next(20) == 0 && !flag5 && (double)num2 >= Main.rockLayer && num2 < Main.maxTilesY - 210 && !NpcMgr.savedWizard && !NPC.AnyNPCs(106))
                        {
                            NPC.NewNPC(num * 16 + 8, num2 * 16, 106, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if (flag10)
                        {
                            if (flag5)
                            {
                                if ((double)num2 < Main.worldSurface && num2 > 50 && Main.rand.Next(3) != 0 && Main.dayTime)
                                {
                                    int num61 = -1;
                                    for (int num62 = num2 - 1; num62 > num2 - 50; num62--)
                                    {
                                        if (Main.tile[num, num62].liquid == 0 && !WorldGen.SolidTile(num, num62) && !WorldGen.SolidTile(num, num62 + 1) && !WorldGen.SolidTile(num, num62 + 2))
                                        {
                                            num61 = num62 + 2;
                                            break;
                                        }
                                    }
                                    if (num61 > num2)
                                    {
                                        num61 = num2;
                                    }
                                    if (num61 > 0 && !flag14)
                                    {
                                        if (Main.rand.Next(2) == 0)
                                        {
                                            NPC.NewNPC(num * 16 + 8, num61 * 16, 362, 0, 0f, 0f, 0f, 0f, 255);
                                        }
                                        else
                                        {
                                            NPC.NewNPC(num * 16 + 8, num61 * 16, 364, 0, 0f, 0f, 0f, 0f, 255);
                                        }
                                    }
                                    else
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 55, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                }
                                else
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 55, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num45 == 147 || num45 == 161)
                            {
                                if (Main.rand.Next(2) == 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 148, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 149, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num45 == 60)
                            {
                                if (Main.rand.Next(NPC.goldCritterChance) == 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 445, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 361, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else
                            {
                                if (num45 != 2 && num45 != 109 && (double)num2 <= Main.worldSurface)
                                {
                                    return;
                                }
                                if (Main.raining)
                                {
                                    if (Main.rand.Next(NPC.goldCritterChance) == 0)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 448, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else if (Main.rand.Next(3) != 0)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 357, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 230, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                }
                                else if (!Main.dayTime && Main.rand.Next(NPC.fireFlyFriendly) == 0 && (double)num2 <= Main.worldSurface)
                                {
                                    int num63 = 355;
                                    if (num45 == 109)
                                    {
                                        num63 = 358;
                                    }
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, num63, 0, 0f, 0f, 0f, 0f, 255);
                                    if (Main.rand.Next(NPC.fireFlyMultiple) == 0)
                                    {
                                        NPC.NewNPC(num * 16 + 8 - 16, num2 * 16, num63, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    if (Main.rand.Next(NPC.fireFlyMultiple) == 0)
                                    {
                                        NPC.NewNPC(num * 16 + 8 + 16, num2 * 16, num63, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    if (Main.rand.Next(NPC.fireFlyMultiple) == 0)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16 - 16, num63, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    if (Main.rand.Next(NPC.fireFlyMultiple) == 0)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16 + 16, num63, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                }
                                else if (Main.dayTime && Main.time < 18000.0 && Main.rand.Next(3) != 0 && (double)num2 <= Main.worldSurface)
                                {
                                    int num64 = Main.rand.Next(4);
                                    if (Main.rand.Next(NPC.goldCritterChance) == 0)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 442, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else if (num64 == 0)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 297, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else if (num64 == 1)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 298, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 74, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                }
                                else if (Main.dayTime && Main.rand.Next(NPC.butterflyChance) == 0 && (double)num2 <= Main.worldSurface)
                                {
                                    if (Main.rand.Next(NPC.goldCritterChance) == 0)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 444, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 356, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    if (Main.rand.Next(4) == 0)
                                    {
                                        NPC.NewNPC(num * 16 + 8 - 16, num2 * 16, 356, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    if (Main.rand.Next(4) == 0)
                                    {
                                        NPC.NewNPC(num * 16 + 8 + 16, num2 * 16, 356, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                }
                                else if (Main.rand.Next(2) == 0 && (double)num2 <= Main.worldSurface)
                                {
                                    int num65 = Main.rand.Next(4);
                                    if (Main.rand.Next(NPC.goldCritterChance) == 0)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 442, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else if (num65 == 0)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 297, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else if (num65 == 1)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 298, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 74, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                }
                                else if (num45 == 53)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(366, 368), 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(NPC.goldCritterChance) == 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 443, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(NPC.goldCritterChance) == 0 && (double)num2 <= Main.worldSurface)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 539, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.halloween && Main.rand.Next(3) != 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 303, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.xMas && Main.rand.Next(3) != 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 337, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (BirthdayParty.PartyIsUp && Main.rand.Next(3) != 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 540, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0 && (double)num2 <= Main.worldSurface)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, (int)Utils.SelectRandom<short>(Main.rand, new short[]
									{
										299,
										538
									}), 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, 46, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                        }
                        else if (Main.player[j].ZoneDungeon)
                        {
                            int num66 = 0;
                            if (Main.tile[num, num2].wall == 94 || Main.tile[num, num2].wall == 96 || Main.tile[num, num2].wall == 98)
                            {
                                num66 = 1;
                            }
                            if (Main.tile[num, num2].wall == 95 || Main.tile[num, num2].wall == 97 || Main.tile[num, num2].wall == 99)
                            {
                                num66 = 2;
                            }
                            if (Main.rand.Next(7) == 0)
                            {
                                num66 = Main.rand.Next(3);
                            }
                            if (!NpcMgr.downedBoss3)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 68, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (!NpcMgr.savedMech && Main.rand.Next(5) == 0 && !flag5 && !NPC.AnyNPCs(123) && (double)num2 > Main.rockLayer)
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 123, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (flag12 && Main.rand.Next(30) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 287, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (flag12 && num66 == 0 && Main.rand.Next(15) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 293, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (flag12 && num66 == 1 && Main.rand.Next(15) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 291, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (flag12 && num66 == 2 && Main.rand.Next(15) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 292, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (flag12 && !NPC.AnyNPCs(290) && num66 == 0 && Main.rand.Next(35) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 290, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (flag12 && (num66 == 1 || num66 == 2) && Main.rand.Next(30) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 289, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (flag12 && Main.rand.Next(20) == 0)
                            {
                                int num67 = 281;
                                if (num66 == 0)
                                {
                                    num67 += 2;
                                }
                                if (num66 == 2)
                                {
                                    num67 += 4;
                                }
                                num67 += Main.rand.Next(2);
                                if (!NPC.AnyNPCs(num67))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, num67, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (flag12 && Main.rand.Next(3) != 0)
                            {
                                int num68 = 269;
                                if (num66 == 0)
                                {
                                    num68 += 4;
                                }
                                if (num66 == 2)
                                {
                                    num68 += 8;
                                }
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, num68 + Main.rand.Next(4), 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(37) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 71, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (num66 == 1 && Main.rand.Next(4) == 0 && !NPC.NearSpikeBall(num, num2))
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 70, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (num66 == 2 && Main.rand.Next(15) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 72, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (num66 == 0 && Main.rand.Next(9) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 34, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(7) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 32, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                int num69 = Main.rand.Next(5);
                                if (num69 == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 294, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (num69 == 1)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 295, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (num69 == 2)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 296, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 31, 0, 0f, 0f, 0f, 0f, 255);
                                    if (Main.rand.Next(4) == 0)
                                    {
                                        Main.npc[num46].SetDefaults(-14, -1f);
                                    }
                                    else if (Main.rand.Next(5) == 0)
                                    {
                                        Main.npc[num46].SetDefaults(-13, -1f);
                                    }
                                }
                            }
                        }
                        else if (Main.player[j].ZoneMeteor)
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 23, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if (DD2Event.Ongoing && Main.player[j].ZoneOldOneArmy)
                        {
                            DD2Event.SpawnNPC(ref num46);
                        }
                        else if ((double)num2 <= Main.worldSurface && !Main.dayTime && Main.snowMoon)
                        {
                            int num70 = NpcMgr.waveNumber;
                            if (Main.rand.Next(30) == 0 && NPC.CountNPCS(341) < 4)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 341, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (num70 >= 20)
                            {
                                int num71 = Main.rand.Next(3);
                                if (num71 == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 345, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (num71 == 1)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 346, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 344, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num70 >= 19)
                            {
                                if (Main.rand.Next(10) == 0 && NPC.CountNPCS(345) < 4)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 345, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(10) == 0 && NPC.CountNPCS(346) < 5)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 346, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(10) == 0 && NPC.CountNPCS(344) < 7)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 344, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 343, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num70 >= 18)
                            {
                                if (Main.rand.Next(10) == 0 && NPC.CountNPCS(345) < 3)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 345, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(10) == 0 && NPC.CountNPCS(346) < 4)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 346, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(10) == 0 && NPC.CountNPCS(344) < 6)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 344, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 348, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 351, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 343, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num70 >= 17)
                            {
                                if (Main.rand.Next(10) == 0 && NPC.CountNPCS(345) < 2)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 345, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(10) == 0 && NPC.CountNPCS(346) < 3)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 346, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(10) == 0 && NPC.CountNPCS(344) < 5)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 344, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(4) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 347, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(2) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 351, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 343, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num70 >= 16)
                            {
                                if (Main.rand.Next(10) == 0 && NPC.CountNPCS(345) < 2)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 345, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(10) == 0 && NPC.CountNPCS(346) < 2)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 346, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(10) == 0 && NPC.CountNPCS(344) < 4)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 344, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(2) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 352, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 343, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num70 >= 15)
                            {
                                if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(345))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 345, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(10) == 0 && NPC.CountNPCS(346) < 2)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 346, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(10) == 0 && NPC.CountNPCS(344) < 3)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 344, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 347, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 343, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num70 == 14)
                            {
                                if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(345))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 345, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(346))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 346, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(344))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 344, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 343, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num70 == 13)
                            {
                                if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(345))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 345, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(346))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 346, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 352, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(6) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 343, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 342, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 347, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num70 == 12)
                            {
                                if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(345))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 345, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(344))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 344, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(8) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 343, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 342, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(338, 341), 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num70 == 11)
                            {
                                if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(345))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 345, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(6) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 352, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(2) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 342, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(338, 341), 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num70 == 10)
                            {
                                if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(346))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 346, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(10) == 0 && NPC.CountNPCS(344) < 2)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 344, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(6) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 351, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 348, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 347, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(338, 341), 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num70 == 9)
                            {
                                if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(346))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 346, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(344))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 344, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(2) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 348, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 347, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 342, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num70 == 8)
                            {
                                if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(346))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 346, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(8) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 351, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 348, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 347, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 350, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num70 == 7)
                            {
                                if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(346))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 346, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 342, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(4) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 350, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(338, 341), 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num70 == 6)
                            {
                                if (Main.rand.Next(10) == 0 && NPC.CountNPCS(344) < 2)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 344, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(4) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 347, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(2) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 348, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 350, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num70 == 5)
                            {
                                if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(344))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 344, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(4) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 350, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(8) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 348, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(338, 341), 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num70 == 4)
                            {
                                if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(344))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 344, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(4) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 350, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 342, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(338, 341), 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num70 == 3)
                            {
                                if (Main.rand.Next(8) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 348, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(4) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 350, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 342, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(338, 341), 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num70 == 2)
                            {
                                if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 350, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(338, 341), 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (Main.rand.Next(3) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 342, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(338, 341), 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if ((double)num2 <= Main.worldSurface && !Main.dayTime && Main.pumpkinMoon)
                        {
                            int num72 = NpcMgr.waveNumber;
                            if (NpcMgr.waveNumber >= 15)
                            {
                                if (Main.rand.Next(2) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 327, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 325, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num72 == 14)
                            {
                                if (Main.rand.Next(5) == 0 && NPC.CountNPCS(327) < 3)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 327, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(5) == 0 && NPC.CountNPCS(325) < 3)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 325, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 315, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num72 == 13)
                            {
                                if (Main.rand.Next(7) == 0 && NPC.CountNPCS(327) < 2)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 327, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                if (Main.rand.Next(5) == 0 && NPC.CountNPCS(325) < 3)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 325, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(5) == 0 && NPC.CountNPCS(315) < 3)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 315, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 330, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 329, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num72 == 12)
                            {
                                if (Main.rand.Next(7) == 0 && NPC.CountNPCS(327) < 2)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 327, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                if (Main.rand.Next(7) == 0 && NPC.CountNPCS(325) < 2)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 325, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(7) == 0 && NPC.CountNPCS(315) < 2)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 315, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(7) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 330, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(5) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 329, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 326, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num72 == 11)
                            {
                                if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(327))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 327, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                if (Main.rand.Next(7) == 0 && NPC.CountNPCS(325) < 2)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 325, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(315))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 315, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(10) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 330, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(7) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 329, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 326, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(305, 315), 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num72 == 10)
                            {
                                if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(327))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 327, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(325))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 325, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(315))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 315, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(8) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 330, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(5) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 329, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 326, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num72 == 9)
                            {
                                if (Main.rand.Next(8) == 0 && !NPC.AnyNPCs(327))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 327, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(8) == 0 && !NPC.AnyNPCs(325))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 325, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(315))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 315, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(305, 315), 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num72 == 8)
                            {
                                if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(327))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 327, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(5) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 330, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 329, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 326, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num72 == 7)
                            {
                                if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(327))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 327, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(8) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 330, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(5) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 329, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(305, 315), 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num72 == 6)
                            {
                                if (Main.rand.Next(7) == 0 && NPC.CountNPCS(325) < 2)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 325, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(6) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 330, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 329, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 326, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num72 == 5)
                            {
                                if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(325))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 325, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(8) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 330, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(5) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 329, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(2) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 326, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(305, 315), 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num72 == 4)
                            {
                                if (Main.rand.Next(10) == 0 && !NPC.AnyNPCs(325))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 325, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(10) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 329, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(2) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 326, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(305, 315), 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num72 == 3)
                            {
                                if (Main.rand.Next(6) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 329, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 326, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(305, 315), 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num72 == 2)
                            {
                                if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 326, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(305, 315), 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(305, 315), 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if ((double)num2 <= Main.worldSurface && Main.dayTime && Main.eclipse)
                        {
                            bool flag20 = false;
                            if (NpcMgr.downedMechBoss1 && NpcMgr.downedMechBoss2 && NpcMgr.downedMechBoss3)
                            {
                                flag20 = true;
                            }
                            if (flag20 && Main.rand.Next(80) == 0 && !NPC.AnyNPCs(477))
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 477, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(50) == 0 && !NPC.AnyNPCs(251))
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 251, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (NpcMgr.downedPlantBoss && Main.rand.Next(5) == 0 && !NPC.AnyNPCs(466))
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 466, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (NpcMgr.downedPlantBoss && Main.rand.Next(20) == 0 && !NPC.AnyNPCs(463))
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 463, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (NpcMgr.downedPlantBoss && Main.rand.Next(20) == 0 && NPC.CountNPCS(467) < 2)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 467, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(15) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 159, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (flag20 && Main.rand.Next(13) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 253, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(8) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 469, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (NpcMgr.downedPlantBoss && Main.rand.Next(7) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 468, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (NpcMgr.downedPlantBoss && Main.rand.Next(5) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 460, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(4) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 162, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(3) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 461, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(2) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 462, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 166, 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if ((Main.hardMode && num3 == 70) & flag5)
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 256, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if (num3 == 70 && (double)num2 <= Main.worldSurface && Main.rand.Next(3) != 0)
                        {
                            if ((!Main.hardMode && Main.rand.Next(6) == 0) || Main.rand.Next(12) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 360, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(3) == 0)
                            {
                                if (Main.rand.Next(4) == 0)
                                {
                                    if (Main.hardMode && Main.rand.Next(3) != 0)
                                    {
                                        num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 260, 0, 0f, 0f, 0f, 0f, 255);
                                        Main.npc[num46].ai[0] = (float)num;
                                        Main.npc[num46].ai[1] = (float)num2;
                                        Main.npc[num46].netUpdate = true;
                                    }
                                    else
                                    {
                                        num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 259, 0, 0f, 0f, 0f, 0f, 255);
                                        Main.npc[num46].ai[0] = (float)num;
                                        Main.npc[num46].ai[1] = (float)num2;
                                        Main.npc[num46].netUpdate = true;
                                    }
                                }
                                else if (Main.rand.Next(2) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 257, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 258, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (Main.rand.Next(2) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 254, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 255, 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if (num3 == 70 && Main.hardMode && (double)num2 >= Main.worldSurface && Main.rand.Next(3) != 0)
                        {
                            if (Main.hardMode && Main.rand.Next(5) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 374, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if ((!Main.hardMode && Main.rand.Next(4) == 0) || Main.rand.Next(8) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 360, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(4) == 0)
                            {
                                if (Main.hardMode && Main.rand.Next(3) != 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 260, 0, 0f, 0f, 0f, 0f, 255);
                                    Main.npc[num46].ai[0] = (float)num;
                                    Main.npc[num46].ai[1] = (float)num2;
                                    Main.npc[num46].netUpdate = true;
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 259, 0, 0f, 0f, 0f, 0f, 255);
                                    Main.npc[num46].ai[0] = (float)num;
                                    Main.npc[num46].ai[1] = (float)num2;
                                    Main.npc[num46].netUpdate = true;
                                }
                            }
                            else if (Main.rand.Next(2) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 257, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 258, 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if (Main.player[j].ZoneCorrupt && Main.rand.Next(65) == 0 && !flag3)
                        {
                            if (Main.hardMode && Main.rand.Next(4) != 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 98, 1, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 7, 1, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if (Main.hardMode && (double)num2 > Main.worldSurface && Main.rand.Next(75) == 0)
                        {
                            if (Main.rand.Next(2) == 0 && Main.player[j].ZoneCorrupt && !NPC.AnyNPCs(473))
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 473, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(2) == 0 && Main.player[j].ZoneCrimson && !NPC.AnyNPCs(474))
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 474, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(2) == 0 && Main.player[j].ZoneHoly && !NPC.AnyNPCs(475))
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 475, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 85, 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if (Main.hardMode && Main.tile[num, num2 - 1].wall == 2 && Main.rand.Next(20) == 0)
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 85, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if (Main.hardMode && (double)num2 <= Main.worldSurface && !Main.dayTime && (Main.rand.Next(20) == 0 || (Main.rand.Next(5) == 0 && Main.moonPhase == 4)))
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 82, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if (Main.hardMode && Main.halloween && (double)num2 <= Main.worldSurface && !Main.dayTime && Main.rand.Next(10) == 0)
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 304, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if (num45 == 60 && Main.rand.Next(500) == 0 && !Main.dayTime)
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 52, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if (num45 == 60 && (double)num2 > Main.worldSurface && Main.rand.Next(60) == 0)
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 219, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if ((double)num2 > Main.worldSurface && num2 < Main.maxTilesY - 210 && !Main.player[j].ZoneSnow && !Main.player[j].ZoneCrimson && !Main.player[j].ZoneCorrupt && !Main.player[j].ZoneJungle && !Main.player[j].ZoneHoly && Main.rand.Next(8) == 0)
                        {
                            if (Main.rand.Next(NPC.goldCritterChance) == 0)
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 448, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 357, 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if ((double)num2 > Main.worldSurface && num2 < Main.maxTilesY - 210 && !Main.player[j].ZoneSnow && !Main.player[j].ZoneCrimson && !Main.player[j].ZoneCorrupt && !Main.player[j].ZoneJungle && !Main.player[j].ZoneHoly && Main.rand.Next(13) == 0)
                        {
                            if (Main.rand.Next(NPC.goldCritterChance) == 0)
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 447, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 300, 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if ((double)num2 > Main.worldSurface && (double)num2 < (Main.rockLayer + (double)Main.maxTilesY) / 2.0 && !Main.player[j].ZoneSnow && !Main.player[j].ZoneCrimson && !Main.player[j].ZoneCorrupt && !Main.player[j].ZoneHoly && Main.rand.Next(13) == 0)
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 359, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if ((double)num2 < Main.worldSurface && Main.player[j].ZoneJungle && Main.rand.Next(9) == 0)
                        {
                            if (Main.rand.Next(NPC.goldCritterChance) == 0)
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 445, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 361, 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if (num45 == 60 && Main.hardMode && Main.rand.Next(3) != 0)
                        {
                            if ((double)num2 < Main.worldSurface && !Main.dayTime && Main.rand.Next(3) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 152, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if ((double)num2 < Main.worldSurface && Main.dayTime && Main.rand.Next(4) != 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 177, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if ((double)num2 > Main.worldSurface && Main.rand.Next(100) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 205, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if ((double)num2 > Main.worldSurface && Main.rand.Next(5) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 236, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if ((double)num2 > Main.worldSurface && Main.rand.Next(4) != 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 176, 0, 0f, 0f, 0f, 0f, 255);
                                if (Main.rand.Next(10) == 0)
                                {
                                    Main.npc[num46].SetDefaults(-18, -1f);
                                }
                                if (Main.rand.Next(10) == 0)
                                {
                                    Main.npc[num46].SetDefaults(-19, -1f);
                                }
                                if (Main.rand.Next(10) == 0)
                                {
                                    Main.npc[num46].SetDefaults(-20, -1f);
                                }
                                if (Main.rand.Next(10) == 0)
                                {
                                    Main.npc[num46].SetDefaults(-21, -1f);
                                }
                            }
                            else if (Main.rand.Next(3) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 175, 0, 0f, 0f, 0f, 0f, 255);
                                Main.npc[num46].ai[0] = (float)num;
                                Main.npc[num46].ai[1] = (float)num2;
                                Main.npc[num46].netUpdate = true;
                            }
                            else
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 153, 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if (num45 == 226 & flag2)
                        {
                            if (Main.rand.Next(3) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 226, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 198, 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if (num45 == 60 && (double)num2 > (Main.worldSurface + Main.rockLayer) / 2.0)
                        {
                            if (Main.rand.Next(4) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 204, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(4) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 43, 0, 0f, 0f, 0f, 0f, 255);
                                Main.npc[num46].ai[0] = (float)num;
                                Main.npc[num46].ai[1] = (float)num2;
                                Main.npc[num46].netUpdate = true;
                            }
                            else
                            {
                                int num73 = Main.rand.Next(8);
                                if (num73 == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 231, 0, 0f, 0f, 0f, 0f, 255);
                                    if (Main.rand.Next(4) == 0)
                                    {
                                        Main.npc[num46].SetDefaults(-56, -1f);
                                    }
                                    else if (Main.rand.Next(4) == 0)
                                    {
                                        Main.npc[num46].SetDefaults(-57, -1f);
                                    }
                                }
                                else if (num73 == 1)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 232, 0, 0f, 0f, 0f, 0f, 255);
                                    if (Main.rand.Next(4) == 0)
                                    {
                                        Main.npc[num46].SetDefaults(-58, -1f);
                                    }
                                    else if (Main.rand.Next(4) == 0)
                                    {
                                        Main.npc[num46].SetDefaults(-59, -1f);
                                    }
                                }
                                else if (num73 == 2)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 233, 0, 0f, 0f, 0f, 0f, 255);
                                    if (Main.rand.Next(4) == 0)
                                    {
                                        Main.npc[num46].SetDefaults(-60, -1f);
                                    }
                                    else if (Main.rand.Next(4) == 0)
                                    {
                                        Main.npc[num46].SetDefaults(-61, -1f);
                                    }
                                }
                                else if (num73 == 3)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 234, 0, 0f, 0f, 0f, 0f, 255);
                                    if (Main.rand.Next(4) == 0)
                                    {
                                        Main.npc[num46].SetDefaults(-62, -1f);
                                    }
                                    else if (Main.rand.Next(4) == 0)
                                    {
                                        Main.npc[num46].SetDefaults(-63, -1f);
                                    }
                                }
                                else if (num73 == 4)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 235, 0, 0f, 0f, 0f, 0f, 255);
                                    if (Main.rand.Next(4) == 0)
                                    {
                                        Main.npc[num46].SetDefaults(-64, -1f);
                                    }
                                    else if (Main.rand.Next(4) == 0)
                                    {
                                        Main.npc[num46].SetDefaults(-65, -1f);
                                    }
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 42, 0, 0f, 0f, 0f, 0f, 255);
                                    if (Main.rand.Next(4) == 0)
                                    {
                                        Main.npc[num46].SetDefaults(-16, -1f);
                                    }
                                    else if (Main.rand.Next(4) == 0)
                                    {
                                        Main.npc[num46].SetDefaults(-17, -1f);
                                    }
                                }
                            }
                        }
                        else if (num45 == 60 && Main.rand.Next(4) == 0)
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 51, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if (num45 == 60 && Main.rand.Next(8) == 0)
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 56, 0, 0f, 0f, 0f, 0f, 255);
                            Main.npc[num46].ai[0] = (float)num;
                            Main.npc[num46].ai[1] = (float)num2;
                            Main.npc[num46].netUpdate = true;
                        }
                        else if (Sandstorm.Happening && Main.player[j].ZoneSandstorm && TileID.Sets.Conversion.Sand[num45] && NpcMgr.Spawning_SandstoneCheck(num, num2))
                        {
                            if (!NpcMgr.downedBoss1 && !Main.hardMode)
                            {
                                if (Main.rand.Next(2) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 546, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(2) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 508, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(2) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 61, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 69, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (Main.hardMode && Main.rand.Next(20) == 0 && !NPC.AnyNPCs(541))
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 541, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.hardMode && !flag3 && Main.rand.Next(3) == 0 && NPC.CountNPCS(510) < 4)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, (num2 + 10) * 16, 510, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.hardMode && !flag3 && Main.rand.Next(2) == 0)
                            {
                                int num74 = 542;
                                if (TileID.Sets.Corrupt[num45])
                                {
                                    num74 = 543;
                                }
                                if (TileID.Sets.Crimson[num45])
                                {
                                    num74 = 544;
                                }
                                if (TileID.Sets.Hallow[num45])
                                {
                                    num74 = 545;
                                }
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, num74, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.hardMode && num45 == 53 && Main.rand.Next(3) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 78, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.hardMode && (num45 == 112 || num45 == 234) && Main.rand.Next(3) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 79, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.hardMode && num45 == 116 && Main.rand.Next(3) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 80, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(2) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 546, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(2) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 508, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 509, 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if (Main.hardMode && num45 == 53 && Main.rand.Next(3) == 0)
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 78, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if (Main.hardMode && (num45 == 112 || num45 == 234) && Main.rand.Next(2) == 0)
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 79, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if (Main.hardMode && num45 == 116 && Main.rand.Next(2) == 0)
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 80, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if (Main.hardMode && !flag5 && (double)num2 < Main.rockLayer && (num45 == 116 || num45 == 117 || num45 == 109 || num45 == 164))
                        {
                            if (!Main.dayTime && Main.rand.Next(2) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 122, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(10) == 0 || (Main.player[j].ZoneWaterCandle && Main.rand.Next(10) == 0))
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 86, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 75, 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if (!flag3 && Main.hardMode && Main.rand.Next(50) == 0 && !flag5 && (double)num2 >= Main.rockLayer && (num45 == 116 || num45 == 117 || num45 == 109 || num45 == 164))
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 84, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if ((num45 == 204 && Main.player[j].ZoneCrimson) || num45 == 199 || num45 == 200 || num45 == 203 || num45 == 234)
                        {
                            if (Main.hardMode && (double)num2 >= Main.rockLayer && Main.rand.Next(5) == 0 && !flag3)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 182, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.hardMode && (double)num2 >= Main.rockLayer && Main.rand.Next(2) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 268, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.hardMode && Main.rand.Next(3) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 183, 0, 0f, 0f, 0f, 0f, 255);
                                if (Main.rand.Next(3) == 0)
                                {
                                    Main.npc[num46].SetDefaults(-24, -1f);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    Main.npc[num46].SetDefaults(-25, -1f);
                                }
                            }
                            else if (Main.hardMode && (double)num2 >= Main.rockLayer && Main.rand.Next(40) == 0 && !flag3)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 179, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.hardMode && (Main.rand.Next(2) == 0 || (double)num2 > Main.worldSurface))
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 174, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if ((Main.tile[num, num2].wall > 0 && Main.rand.Next(4) != 0) || Main.rand.Next(8) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 239, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(2) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 181, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 173, 0, 0f, 0f, 0f, 0f, 255);
                                if (Main.rand.Next(3) == 0)
                                {
                                    Main.npc[num46].SetDefaults(-22, -1f);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    Main.npc[num46].SetDefaults(-23, -1f);
                                }
                            }
                        }
                        else if ((num45 == 22 && Main.player[j].ZoneCorrupt) || num45 == 23 || num45 == 25 || num45 == 112 || num45 == 163)
                        {
                            if (Main.hardMode && (double)num2 >= Main.rockLayer && Main.rand.Next(3) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 101, 0, 0f, 0f, 0f, 0f, 255);
                                Main.npc[num46].ai[0] = (float)num;
                                Main.npc[num46].ai[1] = (float)num2;
                                Main.npc[num46].netUpdate = true;
                            }
                            else if (Main.hardMode && Main.rand.Next(3) == 0)
                            {
                                if (Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 121, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 81, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (Main.hardMode && (double)num2 >= Main.rockLayer && Main.rand.Next(40) == 0 && !flag3)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 83, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.hardMode && (Main.rand.Next(2) == 0 || (double)num2 > Main.rockLayer))
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 94, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 6, 0, 0f, 0f, 0f, 0f, 255);
                                if (Main.rand.Next(3) == 0)
                                {
                                    Main.npc[num46].SetDefaults(-11, -1f);
                                }
                                else if (Main.rand.Next(3) == 0)
                                {
                                    Main.npc[num46].SetDefaults(-12, -1f);
                                }
                            }
                        }
                        else if ((double)num2 <= Main.worldSurface)
                        {
                            bool flag21 = (float)Math.Abs(num - Main.maxTilesX / 2) / (float)(Main.maxTilesX / 2) > 0.33f;
                            if (flag21 && NPC.AnyDanger())
                            {
                                flag21 = false;
                            }
                            if (Main.player[j].ZoneSnow && Main.hardMode && Main.cloudAlpha > 0f && !NPC.AnyNPCs(243) && Main.rand.Next(20) == 0)
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 243, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.player[j].ZoneHoly && Main.hardMode && Main.cloudAlpha > 0f && !NPC.AnyNPCs(244) && Main.rand.Next(20) == 0)
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 244, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (!Main.player[j].ZoneSnow && Main.hardMode && Main.cloudAlpha > 0f && NPC.CountNPCS(250) < 2 && Main.rand.Next(10) == 0)
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 250, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (flag21 && Main.hardMode && NpcMgr.downedGolemBoss && ((!NpcMgr.downedMartians && Main.rand.Next(100) == 0) || Main.rand.Next(400) == 0) && !NPC.AnyNPCs(399))
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 399, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.dayTime)
                            {
                                int num75 = Math.Abs(num - Main.spawnTileX);
                                if (num75 < Main.maxTilesX / 3 && Main.rand.Next(15) == 0 && (num45 == 2 || num45 == 109 || num45 == 147 || num45 == 161))
                                {
                                    if (num45 == 147 || num45 == 161)
                                    {
                                        if (Main.rand.Next(2) == 0)
                                        {
                                            NPC.NewNPC(num * 16 + 8, num2 * 16, 148, 0, 0f, 0f, 0f, 0f, 255);
                                        }
                                        else
                                        {
                                            NPC.NewNPC(num * 16 + 8, num2 * 16, 149, 0, 0f, 0f, 0f, 0f, 255);
                                        }
                                    }
                                    else if (Main.dayTime && Main.rand.Next(NPC.butterflyChance) == 0 && (double)num2 <= Main.worldSurface)
                                    {
                                        if (Main.rand.Next(NPC.goldCritterChance) == 0)
                                        {
                                            NPC.NewNPC(num * 16 + 8, num2 * 16, 444, 0, 0f, 0f, 0f, 0f, 255);
                                        }
                                        else
                                        {
                                            NPC.NewNPC(num * 16 + 8, num2 * 16, 356, 0, 0f, 0f, 0f, 0f, 255);
                                        }
                                        if (Main.rand.Next(4) == 0)
                                        {
                                            NPC.NewNPC(num * 16 + 8 - 16, num2 * 16, 356, 0, 0f, 0f, 0f, 0f, 255);
                                        }
                                        if (Main.rand.Next(4) == 0)
                                        {
                                            NPC.NewNPC(num * 16 + 8 + 16, num2 * 16, 356, 0, 0f, 0f, 0f, 0f, 255);
                                        }
                                    }
                                    else if (Main.rand.Next(NPC.goldCritterChance) == 0)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 443, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else if (Main.rand.Next(NPC.goldCritterChance) == 0 && (double)num2 <= Main.worldSurface)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 539, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else if (Main.halloween && Main.rand.Next(3) != 0)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 303, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else if (Main.xMas && Main.rand.Next(3) != 0)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 337, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else if (BirthdayParty.PartyIsUp && Main.rand.Next(3) != 0)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 540, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else if (Main.rand.Next(3) == 0 && (double)num2 <= Main.worldSurface)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, (int)Utils.SelectRandom<short>(Main.rand, new short[]
										{
											299,
											538
										}), 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 46, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                }
                                else if (num75 < Main.maxTilesX / 3 && Main.rand.Next(15) == 0 && num45 == 53)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(366, 368), 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (num75 < Main.maxTilesX / 3 && Main.dayTime && Main.time < 18000.0 && (num45 == 2 || num45 == 109) && Main.rand.Next(4) == 0 && (double)num2 <= Main.worldSurface && NPC.CountNPCS(74) + NPC.CountNPCS(297) + NPC.CountNPCS(298) < 6)
                                {
                                    int num76 = Main.rand.Next(4);
                                    if (Main.rand.Next(NPC.goldCritterChance) == 0)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 442, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else if (num76 == 0)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 297, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else if (num76 == 1)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 298, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 74, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                }
                                else if (num75 < Main.maxTilesX / 3 && Main.rand.Next(15) == 0 && (num45 == 2 || num45 == 109 || num45 == 147))
                                {
                                    int num77 = Main.rand.Next(4);
                                    if (Main.rand.Next(NPC.goldCritterChance) == 0)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 442, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else if (num77 == 0)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 297, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else if (num77 == 1)
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 298, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else
                                    {
                                        NPC.NewNPC(num * 16 + 8, num2 * 16, 74, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                }
                                else if (num75 > Main.maxTilesX / 3 && num45 == 2 && Main.rand.Next(300) == 0 && !NPC.AnyNPCs(50))
                                {
                                    NpcMgr.SpawnOnPlayer(j, 50);
                                }
                                else if (num45 == 53 && Main.rand.Next(5) == 0 && NpcMgr.Spawning_SandstoneCheck(num, num2) && !flag5)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 69, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (num45 == 53 && Main.rand.Next(3) == 0 && !flag5)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 537, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (num45 == 53 && !flag5)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 61, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (num75 > Main.maxTilesX / 3 && (Main.rand.Next(15) == 0 || (!NpcMgr.downedGoblins && WorldGen.shadowOrbSmashed && Main.rand.Next(7) == 0)))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 73, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.raining && Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 224, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.raining && Main.rand.Next(2) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 225, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 1, 0, 0f, 0f, 0f, 0f, 255);
                                    if (num45 == 60)
                                    {
                                        Main.npc[num46].SetDefaults(-10, -1f);
                                    }
                                    else if (num45 == 161 || num45 == 147)
                                    {
                                        Main.npc[num46].SetDefaults(147, -1f);
                                    }
                                    else if (Main.halloween && Main.rand.Next(3) != 0)
                                    {
                                        Main.npc[num46].SetDefaults(302, -1f);
                                    }
                                    else if (Main.xMas && Main.rand.Next(3) != 0)
                                    {
                                        Main.npc[num46].SetDefaults(Main.rand.Next(333, 337), -1f);
                                    }
                                    else if (Main.rand.Next(3) == 0 || (num75 < 200 && !Main.expertMode))
                                    {
                                        Main.npc[num46].SetDefaults(-3, -1f);
                                    }
                                    else if (Main.rand.Next(10) == 0 && (num75 > 400 || Main.expertMode))
                                    {
                                        Main.npc[num46].SetDefaults(-7, -1f);
                                    }
                                }
                            }
                            else if ((num3 == 2 || num3 == 109) && Main.rand.Next(NPC.fireFlyChance) == 0 && (double)num2 <= Main.worldSurface)
                            {
                                int num78 = 355;
                                if (num45 == 109)
                                {
                                    num78 = 358;
                                }
                                NPC.NewNPC(num * 16 + 8, num2 * 16, num78, 0, 0f, 0f, 0f, 0f, 255);
                                if (Main.rand.Next(NPC.fireFlyMultiple) == 0)
                                {
                                    NPC.NewNPC(num * 16 + 8 - 16, num2 * 16, num78, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                if (Main.rand.Next(NPC.fireFlyMultiple) == 0)
                                {
                                    NPC.NewNPC(num * 16 + 8 + 16, num2 * 16, num78, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                if (Main.rand.Next(NPC.fireFlyMultiple) == 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16 - 16, num78, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                if (Main.rand.Next(NPC.fireFlyMultiple) == 0)
                                {
                                    NPC.NewNPC(num * 16 + 8, num2 * 16 + 16, num78, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (Main.rand.Next(10) == 0 && Main.halloween)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 301, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(6) == 0 || (Main.moonPhase == 4 && Main.rand.Next(2) == 0))
                            {
                                if (Main.hardMode && Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 133, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.halloween && Main.rand.Next(2) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(317, 319), 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.rand.Next(2) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 2, 0, 0f, 0f, 0f, 0f, 255);
                                    if (Main.rand.Next(4) == 0)
                                    {
                                        Main.npc[num46].SetDefaults(-43, -1f);
                                    }
                                }
                                else
                                {
                                    int num79 = Main.rand.Next(5);
                                    if (num79 == 0)
                                    {
                                        num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 190, 0, 0f, 0f, 0f, 0f, 255);
                                        if (Main.rand.Next(3) == 0)
                                        {
                                            Main.npc[num46].SetDefaults(-38, -1f);
                                        }
                                    }
                                    else if (num79 == 1)
                                    {
                                        num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 191, 0, 0f, 0f, 0f, 0f, 255);
                                        if (Main.rand.Next(3) == 0)
                                        {
                                            Main.npc[num46].SetDefaults(-39, -1f);
                                        }
                                    }
                                    else if (num79 == 2)
                                    {
                                        num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 192, 0, 0f, 0f, 0f, 0f, 255);
                                        if (Main.rand.Next(3) == 0)
                                        {
                                            Main.npc[num46].SetDefaults(-40, -1f);
                                        }
                                    }
                                    else if (num79 == 3)
                                    {
                                        num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 193, 0, 0f, 0f, 0f, 0f, 255);
                                        if (Main.rand.Next(3) == 0)
                                        {
                                            Main.npc[num46].SetDefaults(-41, -1f);
                                        }
                                    }
                                    else if (num79 == 4)
                                    {
                                        num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 194, 0, 0f, 0f, 0f, 0f, 255);
                                        if (Main.rand.Next(3) == 0)
                                        {
                                            Main.npc[num46].SetDefaults(-42, -1f);
                                        }
                                    }
                                }
                            }
                            else if (Main.hardMode && Main.rand.Next(50) == 0 && Main.bloodMoon && !NPC.AnyNPCs(109))
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 109, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(250) == 0 && Main.bloodMoon)
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 53, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(250) == 0 && Main.bloodMoon)
                            {
                                NPC.NewNPC(num * 16 + 8, num2 * 16, 536, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.moonPhase == 0 && Main.hardMode && Main.rand.Next(3) != 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 104, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.hardMode && Main.rand.Next(3) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 140, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.bloodMoon && Main.rand.Next(5) < 2)
                            {
                                if (Main.rand.Next(2) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 489, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 490, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (num3 == 147 || num3 == 161 || num3 == 163 || num3 == 164 || num3 == 162)
                            {
                                if (Main.hardMode && Main.rand.Next(4) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 169, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.hardMode && Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 155, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.expertMode && Main.rand.Next(2) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 431, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 161, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (Main.raining && Main.rand.Next(2) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 223, 0, 0f, 0f, 0f, 0f, 255);
                                if (Main.rand.Next(3) == 0)
                                {
                                    if (Main.rand.Next(2) == 0)
                                    {
                                        Main.npc[num46].SetDefaults(-54, -1f);
                                    }
                                    else
                                    {
                                        Main.npc[num46].SetDefaults(-55, -1f);
                                    }
                                }
                            }
                            else
                            {
                                int num80 = Main.rand.Next(7);
                                if (Main.halloween && Main.rand.Next(2) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(319, 322), 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.xMas && Main.rand.Next(2) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(331, 333), 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (num80 == 0 && Main.expertMode && Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 430, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (num80 == 2 && Main.expertMode && Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 432, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (num80 == 3 && Main.expertMode && Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 433, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (num80 == 4 && Main.expertMode && Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 434, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (num80 == 5 && Main.expertMode && Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 435, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (num80 == 6 && Main.expertMode && Main.rand.Next(3) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 436, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (num80 == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 3, 0, 0f, 0f, 0f, 0f, 255);
                                    if (Main.rand.Next(3) == 0)
                                    {
                                        if (Main.rand.Next(2) == 0)
                                        {
                                            Main.npc[num46].SetDefaults(-26, -1f);
                                        }
                                        else
                                        {
                                            Main.npc[num46].SetDefaults(-27, -1f);
                                        }
                                    }
                                }
                                else if (num80 == 1)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 132, 0, 0f, 0f, 0f, 0f, 255);
                                    if (Main.rand.Next(3) == 0)
                                    {
                                        if (Main.rand.Next(2) == 0)
                                        {
                                            Main.npc[num46].SetDefaults(-28, -1f);
                                        }
                                        else
                                        {
                                            Main.npc[num46].SetDefaults(-29, -1f);
                                        }
                                    }
                                }
                                else if (num80 == 2)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 186, 0, 0f, 0f, 0f, 0f, 255);
                                    if (Main.rand.Next(3) == 0)
                                    {
                                        if (Main.rand.Next(2) == 0)
                                        {
                                            Main.npc[num46].SetDefaults(-30, -1f);
                                        }
                                        else
                                        {
                                            Main.npc[num46].SetDefaults(-31, -1f);
                                        }
                                    }
                                }
                                else if (num80 == 3)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 187, 0, 0f, 0f, 0f, 0f, 255);
                                    if (Main.rand.Next(3) == 0)
                                    {
                                        if (Main.rand.Next(2) == 0)
                                        {
                                            Main.npc[num46].SetDefaults(-32, -1f);
                                        }
                                        else
                                        {
                                            Main.npc[num46].SetDefaults(-33, -1f);
                                        }
                                    }
                                }
                                else if (num80 == 4)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 188, 0, 0f, 0f, 0f, 0f, 255);
                                    if (Main.rand.Next(3) == 0)
                                    {
                                        if (Main.rand.Next(2) == 0)
                                        {
                                            Main.npc[num46].SetDefaults(-34, -1f);
                                        }
                                        else
                                        {
                                            Main.npc[num46].SetDefaults(-35, -1f);
                                        }
                                    }
                                }
                                else if (num80 == 5)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 189, 0, 0f, 0f, 0f, 0f, 255);
                                    if (Main.rand.Next(3) == 0)
                                    {
                                        if (Main.rand.Next(2) == 0)
                                        {
                                            Main.npc[num46].SetDefaults(-36, -1f);
                                        }
                                        else
                                        {
                                            Main.npc[num46].SetDefaults(-37, -1f);
                                        }
                                    }
                                }
                                else if (num80 == 6)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 200, 0, 0f, 0f, 0f, 0f, 255);
                                    if (Main.rand.Next(3) == 0)
                                    {
                                        if (Main.rand.Next(2) == 0)
                                        {
                                            Main.npc[num46].SetDefaults(-44, -1f);
                                        }
                                        else
                                        {
                                            Main.npc[num46].SetDefaults(-45, -1f);
                                        }
                                    }
                                }
                            }
                        }
                        else if ((double)num2 <= Main.rockLayer)
                        {
                            if (!flag3 && Main.rand.Next(50) == 0 && !Main.player[j].ZoneSnow)
                            {
                                if (Main.hardMode)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 95, 1, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.player[j].ZoneSnow)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 185, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 10, 1, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (Main.hardMode && Main.rand.Next(3) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 140, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.hardMode && Main.rand.Next(4) != 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 141, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (num45 == 147 || num45 == 161 || Main.player[j].ZoneSnow)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 147, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 1, 0, 0f, 0f, 0f, 0f, 255);
                                if (Main.rand.Next(5) == 0)
                                {
                                    Main.npc[num46].SetDefaults(-9, -1f);
                                }
                                else if (Main.rand.Next(2) == 0)
                                {
                                    Main.npc[num46].SetDefaults(1, -1f);
                                }
                                else
                                {
                                    Main.npc[num46].SetDefaults(-8, -1f);
                                }
                            }
                        }
                        else if (num2 > Main.maxTilesY - 190)
                        {
                            if (Main.hardMode && !NpcMgr.savedTaxCollector && Main.rand.Next(20) == 0 && !NPC.AnyNPCs(534))
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 534, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(40) == 0 && !NPC.AnyNPCs(39))
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 39, 1, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(14) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 24, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(7) == 0)
                            {
                                if (Main.rand.Next(7) == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 66, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (Main.hardMode && NpcMgr.downedMechBossAny && Main.rand.Next(5) != 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 156, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 62, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (Main.rand.Next(3) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 59, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.hardMode && NpcMgr.downedMechBossAny && Main.rand.Next(5) != 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 151, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 60, 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if (Main.rand.Next(60) == 0)
                        {
                            if (Main.player[j].ZoneSnow)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 218, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 217, 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if ((num45 == 116 || num45 == 117 || num45 == 164) && Main.hardMode && !flag3 && Main.rand.Next(8) == 0)
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 120, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if ((num3 == 147 || num3 == 161 || num3 == 162 || num3 == 163 || num3 == 164) && !flag3 && Main.hardMode && Main.player[j].ZoneCorrupt && Main.rand.Next(30) == 0)
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 170, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if ((num3 == 147 || num3 == 161 || num3 == 162 || num3 == 163 || num3 == 164) && !flag3 && Main.hardMode && Main.player[j].ZoneHoly && Main.rand.Next(30) == 0)
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 171, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if ((num3 == 147 || num3 == 161 || num3 == 162 || num3 == 163 || num3 == 164) && !flag3 && Main.hardMode && Main.player[j].ZoneCrimson && Main.rand.Next(30) == 0)
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 180, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if (Main.hardMode && Main.player[j].ZoneSnow && Main.rand.Next(10) == 0)
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 154, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if (!flag3 && Main.rand.Next(100) == 0 && !Main.player[j].ZoneHoly)
                        {
                            if (Main.hardMode)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 95, 1, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.player[j].ZoneSnow)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 185, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 10, 1, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if (Main.player[j].ZoneSnow && Main.rand.Next(20) == 0)
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 185, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if (!Main.hardMode && Main.rand.Next(10) == 0)
                        {
                            if (Main.player[j].ZoneSnow)
                            {
                                Main.npc[num46].SetDefaults(184, -1f);
                            }
                            else
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 16, 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else if (!Main.hardMode && Main.rand.Next(4) == 0)
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 1, 0, 0f, 0f, 0f, 0f, 255);
                            if (Main.player[j].ZoneJungle)
                            {
                                Main.npc[num46].SetDefaults(-10, -1f);
                            }
                            else if (Main.player[j].ZoneSnow)
                            {
                                Main.npc[num46].SetDefaults(184, -1f);
                            }
                            else
                            {
                                Main.npc[num46].SetDefaults(-6, -1f);
                            }
                        }
                        else if (Main.rand.Next(2) == 0)
                        {
                            if (Main.rand.Next(35) == 0 && NPC.CountNPCS(453) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 453, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if ((!Main.hardMode && Main.rand.Next(80) == 0) || Main.rand.Next(200) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 195, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.hardMode && (double)num2 > (Main.rockLayer + (double)Main.maxTilesY) / 2.0 && Main.rand.Next(300) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 172, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if ((double)num2 > (Main.rockLayer + (double)Main.maxTilesY) / 2.0 && (Main.rand.Next(200) == 0 || (Main.rand.Next(50) == 0 && Main.player[j].armor[1].type >= 1282 && Main.player[j].armor[1].type <= 1287 && Main.player[j].armor[0].type != 238)))
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 45, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (flag8 && Main.rand.Next(4) != 0)
                            {
                                if (Main.rand.Next(6) != 0 && !NPC.AnyNPCs(480) && Main.hardMode)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 480, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 481, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (flag7 && Main.rand.Next(5) != 0)
                            {
                                if (Main.rand.Next(6) != 0 && !NPC.AnyNPCs(483))
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 483, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 482, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (Main.hardMode && Main.rand.Next(10) != 0)
                            {
                                if (Main.rand.Next(2) == 0)
                                {
                                    if (Main.player[j].ZoneSnow)
                                    {
                                        num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 197, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else if (Main.halloween && Main.rand.Next(5) == 0)
                                    {
                                        num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 316, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    else
                                    {
                                        num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 77, 0, 0f, 0f, 0f, 0f, 255);
                                        if ((double)num2 > (Main.rockLayer + (double)Main.maxTilesY) / 2.0 && Main.rand.Next(5) == 0)
                                        {
                                            Main.npc[num46].SetDefaults(-15, -1f);
                                        }
                                    }
                                }
                                else if (Main.player[j].ZoneSnow)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 206, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 110, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if (Main.rand.Next(20) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 44, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (num3 == 147 || num3 == 161 || num3 == 162)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 167, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.player[j].ZoneSnow)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 185, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.rand.Next(3) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, NPC.cavernMonsterType[Main.rand.Next(2), Main.rand.Next(3)], 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.halloween && Main.rand.Next(2) == 0)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, Main.rand.Next(322, 325), 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else if (Main.expertMode && Main.rand.Next(3) == 0)
                            {
                                int num81 = Main.rand.Next(4);
                                if (num81 == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 449, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (num81 == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 450, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else if (num81 == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 451, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                else
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 452, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else
                            {
                                int num82 = Main.rand.Next(4);
                                if (num82 == 0)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 21, 0, 0f, 0f, 0f, 0f, 255);
                                    if (Main.rand.Next(3) == 0)
                                    {
                                        if (Main.rand.Next(2) == 0)
                                        {
                                            Main.npc[num46].SetDefaults(-47, -1f);
                                        }
                                        else
                                        {
                                            Main.npc[num46].SetDefaults(-46, -1f);
                                        }
                                    }
                                }
                                else if (num82 == 1)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 201, 0, 0f, 0f, 0f, 0f, 255);
                                    if (Main.rand.Next(3) == 0)
                                    {
                                        if (Main.rand.Next(2) == 0)
                                        {
                                            Main.npc[num46].SetDefaults(-49, -1f);
                                        }
                                        else
                                        {
                                            Main.npc[num46].SetDefaults(-48, -1f);
                                        }
                                    }
                                }
                                else if (num82 == 2)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 202, 0, 0f, 0f, 0f, 0f, 255);
                                    if (Main.rand.Next(3) == 0)
                                    {
                                        if (Main.rand.Next(2) == 0)
                                        {
                                            Main.npc[num46].SetDefaults(-51, -1f);
                                        }
                                        else
                                        {
                                            Main.npc[num46].SetDefaults(-50, -1f);
                                        }
                                    }
                                }
                                else if (num82 == 3)
                                {
                                    num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 203, 0, 0f, 0f, 0f, 0f, 255);
                                    if (Main.rand.Next(3) == 0)
                                    {
                                        if (Main.rand.Next(2) == 0)
                                        {
                                            Main.npc[num46].SetDefaults(-53, -1f);
                                        }
                                        else
                                        {
                                            Main.npc[num46].SetDefaults(-52, -1f);
                                        }
                                    }
                                }
                            }
                        }
                        else if (Main.hardMode && (Main.player[j].ZoneHoly & Main.rand.Next(2) == 0))
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 138, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if (Main.player[j].ZoneJungle)
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 51, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if (Main.hardMode && Main.player[j].ZoneHoly)
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 137, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if (Main.hardMode && Main.rand.Next(6) > 0)
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 93, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        else if (num3 == 147 || num3 == 161 || num3 == 162)
                        {
                            if (Main.hardMode)
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 169, 0, 0f, 0f, 0f, 0f, 255);
                            }
                            else
                            {
                                num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 150, 0, 0f, 0f, 0f, 0f, 255);
                            }
                        }
                        else
                        {
                            num46 = NPC.NewNPC(num * 16 + 8, num2 * 16, 49, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        if (Main.npc[num46].type == 1 && Main.rand.Next(180) == 0)
                        {
                            Main.npc[num46].SetDefaults(-4, -1f);
                        }
                        if (Main.netMode == 2 && num46 < 200)
                        {
                            NetMessage.SendData(23, -1, -1, null, num46, 0f, 0f, 0f, 0, 0, 0);
                            return;
                        }
                        break;
                    }
                }
            }
        }

        // Token: 0x0600026D RID: 621 RVA: 0x001A7B60 File Offset: 0x001A5D60
        public static void SpawnOnPlayer(int plr, int Type)
        {
            if (Main.netMode == 1)
            {
                return;
            }
            if (Type == 262 && NPC.AnyNPCs(262))
            {
                return;
            }
            if (Type == 245)
            {
                if (NPC.AnyNPCs(245))
                {
                    return;
                }
                try
                {
                    int num = (int)Main.player[plr].Center.X / 16;
                    int num2 = (int)Main.player[plr].Center.Y / 16;
                    int num3 = 0;
                    int num4 = 0;
                    for (int i = num - 20; i < num + 20; i++)
                    {
                        for (int j = num2 - 20; j < num2 + 20; j++)
                        {
                            if (Main.tile[i, j].active() && Main.tile[i, j].type == 237 && Main.tile[i, j].frameX == 18 && Main.tile[i, j].frameY == 0)
                            {
                                num3 = i;
                                num4 = j;
                            }
                        }
                    }
                    if (num3 > 0 && num4 > 0)
                    {
                        int num5 = num4 - 15;
                        int num6 = num4 - 15;
                        for (int k = num4; k > num4 - 100; k--)
                        {
                            if (WorldGen.SolidTile(num3, k))
                            {
                                num5 = k;
                                break;
                            }
                        }
                        for (int l = num4; l < num4 + 100; l++)
                        {
                            if (WorldGen.SolidTile(num3, l))
                            {
                                num6 = l;
                                break;
                            }
                        }
                        num4 = (num5 + num5 + num6) / 3;
                        int num7 = NPC.NewNPC(num3 * 16 + 8, num4 * 16, 245, 100, 0f, 0f, 0f, 0f, 255);
                        Main.npc[num7].target = plr;
                        string typeName = Main.npc[num7].TypeName;
                        if (Main.netMode == 0)
                        {
                            Main.NewText(Language.GetTextValue("Announcement.HasAwoken", typeName), 175, 75, 255, false);
                        }
                        else if (Main.netMode == 2)
                        {
                            NetMessage.BroadcastChatMessage(NetworkText.FromKey("Announcement.HasAwoken", new object[]
							{
								Main.npc[num7].GetTypeNetName()
							}), new Color(175, 75, 255), -1);
                        }
                    }
                }
                catch
                {
                }
                return;
            }
            else if (Type == 370)
            {
                Player player = Main.player[plr];
                if (!player.active || player.dead)
                {
                    return;
                }
                int m = 0;
                while (m < 1000)
                {
                    Projectile projectile = Main.projectile[m];
                    if (projectile.active && projectile.bobber && projectile.owner == plr)
                    {
                        int num8 = NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y + 100, 370, 0, 0f, 0f, 0f, 0f, 255);
                        string typeName2 = Main.npc[num8].TypeName;
                        if (Main.netMode == 0)
                        {
                            Main.NewText(Language.GetTextValue("Announcement.HasAwoken", typeName2), 175, 75, 255, false);
                            return;
                        }
                        if (Main.netMode == 2)
                        {
                            NetMessage.BroadcastChatMessage(NetworkText.FromKey("Announcement.HasAwoken", new object[]
							{
								Main.npc[num8].GetTypeNetName()
							}), new Color(175, 75, 255), -1);
                            return;
                        }
                        break;
                    }
                    else
                    {
                        m++;
                    }
                }
                return;
            }
            else
            {
                if (Type != 398)
                {
                    bool flag = false;
                    int num9 = 0;
                    int num10 = 0;
                    int num11 = (int)(Main.player[plr].position.X / 16f) - NpcMgr.spawnRangeX * 2;
                    int num12 = (int)(Main.player[plr].position.X / 16f) + NpcMgr.spawnRangeX * 2;
                    int num13 = (int)(Main.player[plr].position.Y / 16f) - NpcMgr.spawnRangeY * 2;
                    int num14 = (int)(Main.player[plr].position.Y / 16f) + NpcMgr.spawnRangeY * 2;
                    int num15 = (int)(Main.player[plr].position.X / 16f) - NpcMgr.safeRangeX;
                    int num16 = (int)(Main.player[plr].position.X / 16f) + NpcMgr.safeRangeX;
                    int num17 = (int)(Main.player[plr].position.Y / 16f) - NpcMgr.safeRangeY;
                    int num18 = (int)(Main.player[plr].position.Y / 16f) + NpcMgr.safeRangeY;
                    if (num11 < 0)
                    {
                        num11 = 0;
                    }
                    if (num12 > Main.maxTilesX)
                    {
                        num12 = Main.maxTilesX;
                    }
                    if (num13 < 0)
                    {
                        num13 = 0;
                    }
                    if (num14 > Main.maxTilesY)
                    {
                        num14 = Main.maxTilesY;
                    }
                    for (int n = 0; n < 1000; n++)
                    {
                        int num19 = 0;
                        while (num19 < 100)
                        {
                            int num20 = Main.rand.Next(num11, num12);
                            int num21 = Main.rand.Next(num13, num14);
                            if (Main.tile[num20, num21].nactive() && Main.tileSolid[(int)Main.tile[num20, num21].type])
                            {
                                goto IL_7DE;
                            }
                            if ((!Main.wallHouse[(int)Main.tile[num20, num21].wall] || n >= 999) && (Type != 50 || n >= 500 || Main.tile[num21, num21].wall <= 0))
                            {
                                int num22 = num21;
                                while (num22 < Main.maxTilesY)
                                {
                                    if (Main.tile[num20, num22].nactive() && Main.tileSolid[(int)Main.tile[num20, num22].type])
                                    {
                                        if (num20 < num15 || num20 > num16 || num22 < num17 || num22 > num18 || n == 999)
                                        {
                                            ushort arg_683_0 = Main.tile[num20, num22].type;
                                            num9 = num20;
                                            num10 = num22;
                                            flag = true;
                                            break;
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        num22++;
                                    }
                                }
                                if (flag && Type == 50 && n < 900)
                                {
                                    int num23 = 20;
                                    if (!Collision.CanHit(new Vector2((float)num9, (float)(num10 - 1)) * 16f, 16, 16, new Vector2((float)num9, (float)(num10 - 1 - num23)) * 16f, 16, 16) || !Collision.CanHit(new Vector2((float)num9, (float)(num10 - 1 - num23)) * 16f, 16, 16, Main.player[plr].Center, 0, 0))
                                    {
                                        num9 = 0;
                                        num10 = 0;
                                        flag = false;
                                    }
                                }
                                if (!flag || n >= 999)
                                {
                                    goto IL_7DE;
                                }
                                int num24 = num9 - NpcMgr.spawnSpaceX / 2;
                                int num25 = num9 + NpcMgr.spawnSpaceX / 2;
                                int num26 = num10 - NpcMgr.spawnSpaceY;
                                int num27 = num10;
                                if (num24 < 0)
                                {
                                    flag = false;
                                }
                                if (num25 > Main.maxTilesX)
                                {
                                    flag = false;
                                }
                                if (num26 < 0)
                                {
                                    flag = false;
                                }
                                if (num27 > Main.maxTilesY)
                                {
                                    flag = false;
                                }
                                if (flag)
                                {
                                    for (int num28 = num24; num28 < num25; num28++)
                                    {
                                        for (int num29 = num26; num29 < num27; num29++)
                                        {
                                            if (Main.tile[num28, num29].nactive() && Main.tileSolid[(int)Main.tile[num28, num29].type])
                                            {
                                                flag = false;
                                                break;
                                            }
                                        }
                                    }
                                    goto IL_7DE;
                                }
                                goto IL_7DE;
                            }
                        IL_7E4:
                            num19++;
                            continue;
                        IL_7DE:
                            if (!flag && !flag)
                            {
                                goto IL_7E4;
                            }
                            break;
                        }
                        if (flag && n < 999)
                        {
                            Rectangle rectangle = new Rectangle(num9 * 16, num10 * 16, 16, 16);
                            for (int num30 = 0; num30 < 255; num30++)
                            {
                                if (Main.player[num30].active)
                                {
                                    Rectangle rectangle2 = new Rectangle((int)(Main.player[num30].position.X + (float)(Main.player[num30].width / 2) - (float)(NpcMgr.sWidth / 2) - (float)NpcMgr.safeRangeX), (int)(Main.player[num30].position.Y + (float)(Main.player[num30].height / 2) - (float)(NpcMgr.sHeight / 2) - (float)NpcMgr.safeRangeY), NpcMgr.sWidth + NpcMgr.safeRangeX * 2, NpcMgr.sHeight + NpcMgr.safeRangeY * 2);
                                    if (rectangle.Intersects(rectangle2))
                                    {
                                        flag = false;
                                    }
                                }
                            }
                        }
                        if (flag)
                        {
                            break;
                        }
                    }
                    if (flag)
                    {
                        int num31 = NPC.NewNPC(num9 * 16 + 8, num10 * 16, Type, 1, 0f, 0f, 0f, 0f, 255);
                        if (num31 == 200)
                        {
                            return;
                        }
                        Main.npc[num31].target = plr;
                        Main.npc[num31].timeLeft *= 20;
                        string typeName3 = Main.npc[num31].TypeName;
                        if (Main.netMode == 2 && num31 < 200)
                        {
                            NetMessage.SendData(23, -1, -1, null, num31, 0f, 0f, 0f, 0, 0, 0);
                        }
                        if (Type == 134 || Type == 127 || Type == 126 || Type == 125)
                        {
                            AchievementsHelper.CheckMechaMayhem(-1);
                        }
                        if (Type == 125)
                        {
                            if (Main.netMode == 0)
                            {
                                Main.NewText(Lang.misc[48].Value, 175, 75, 255, false);
                                return;
                            }
                            if (Main.netMode == 2)
                            {
                                NetMessage.BroadcastChatMessage(Lang.misc[48].ToNetworkText(), new Color(175, 75, 255), -1);
                                return;
                            }
                        }
                        else if (Type != 82 && Type != 126 && Type != 50 && Type != 398 && Type != 551)
                        {
                            if (Main.netMode == 0)
                            {
                                Main.NewText(Language.GetTextValue("Announcement.HasAwoken", typeName3), 175, 75, 255, false);
                                return;
                            }
                            if (Main.netMode == 2)
                            {
                                NetMessage.BroadcastChatMessage(NetworkText.FromKey("Announcement.HasAwoken", new object[]
								{
									Main.npc[num31].GetTypeNetName()
								}), new Color(175, 75, 255), -1);
                            }
                        }
                    }
                    return;
                }
                if (NPC.AnyNPCs(Type))
                {
                    return;
                }
                Player player2 = Main.player[plr];
                NPC.NewNPC((int)player2.Center.X, (int)player2.Center.Y - 150, Type, 0, 0f, 0f, 0f, 0f, 255);
                if (Main.netMode == 0)
                {
                    Main.NewText(Language.GetTextValue("Announcement.HasAwoken", Language.GetTextValue("Enemies.MoonLord")), 175, 75, 255, false);
                    return;
                }
                if (Main.netMode == 2)
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromKey("Announcement.HasAwoken", new object[]
					{
						NetworkText.FromKey("Enemies.MoonLord", new object[0])
					}), new Color(175, 75, 255), -1);
                }
                return;
            }
        }

        // Token: 0x0600026C RID: 620 RVA: 0x001A7968 File Offset: 0x001A5B68
        public static void SpawnSkeletron()
        {
            bool flag = true;
            bool flag2 = false;
            Vector2 vector = Vector2.Zero;
            int num = 0;
            int num2 = 0;
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].active && Main.npc[i].type == 35)
                {
                    flag = false;
                    break;
                }
            }
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].active)
                {
                    if (Main.npc[j].type == 37)
                    {
                        flag2 = true;
                        Main.npc[j].ai[3] = 1f;
                        vector = Main.npc[j].position;
                        num = Main.npc[j].width;
                        num2 = Main.npc[j].height;
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(23, -1, -1, null, j, 0f, 0f, 0f, 0, 0, 0);
                        }
                    }
                    else if (Main.npc[j].type == 54)
                    {
                        flag2 = true;
                        vector = Main.npc[j].position;
                        num = Main.npc[j].width;
                        num2 = Main.npc[j].height;
                    }
                }
            }
            if (flag & flag2)
            {
                int num3 = NPC.NewNPC((int)vector.X + num / 2, (int)vector.Y + num2 / 2, 35, 0, 0f, 0f, 0f, 0f, 255);
                Main.npc[num3].netUpdate = true;
                string nPCNameValue = Lang.GetNPCNameValue(35);
                if (Main.netMode == 0)
                {
                    Main.NewText(Language.GetTextValue("Announcement.HasAwoken", nPCNameValue), 175, 75, 255, false);
                    return;
                }
                if (Main.netMode == 2)
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromKey("Announcement.HasAwoken", new object[]
					{
						Lang.GetNPCName(35).ToNetworkText()
					}), new Color(175, 75, 255), -1);
                }
            }
        }

        // Token: 0x0600026B RID: 619 RVA: 0x001A772C File Offset: 0x001A592C
        public static void SpawnWOF(Vector2 pos)
        {
            if (pos.Y / 16f < (float)(Main.maxTilesY - 205))
            {
                return;
            }
            if (Main.wof >= 0)
            {
                return;
            }
            if (Main.netMode == 1)
            {
                return;
            }
            Player.FindClosest(pos, 16, 16);
            int num = 1;
            if (pos.X / 16f > (float)(Main.maxTilesX / 2))
            {
                num = -1;
            }
            bool flag = false;
            int num2 = (int)pos.X;
            while (!flag)
            {
                flag = true;
                for (int i = 0; i < 255; i++)
                {
                    if (Main.player[i].active && Main.player[i].position.X > (float)(num2 - 1200) && Main.player[i].position.X < (float)(num2 + 1200))
                    {
                        num2 -= num * 16;
                        flag = false;
                    }
                }
                if (num2 / 16 < 20 || num2 / 16 > Main.maxTilesX - 20)
                {
                    flag = true;
                }
            }
            int num3 = (int)pos.Y;
            int num4 = num2 / 16;
            int num5 = num3 / 16;
            int num6 = 0;
            while (true)
            {
                try
                {
                    if (!WorldGen.SolidTile(num4, num5 - num6) && Main.tile[num4, num5 - num6].liquid < 100)
                    {
                        num5 -= num6;
                    }
                    else
                    {
                        if (WorldGen.SolidTile(num4, num5 + num6) || Main.tile[num4, num5 + num6].liquid >= 100)
                        {
                            num6++;
                            continue;
                        }
                        num5 += num6;
                    }
                }
                catch
                {
                }
                break;
            }
            if (num5 < Main.maxTilesY - 180)
            {
                num5 = Main.maxTilesY - 180;
            }
            num3 = num5 * 16;
            int num7 = NPC.NewNPC(num2, num3, 113, 0, 0f, 0f, 0f, 0f, 255);
            if (Main.netMode == 0)
            {
                Main.NewText(Language.GetTextValue("Announcement.HasAwoken", Main.npc[num7].TypeName), 175, 75, 255, false);
                return;
            }
            if (Main.netMode == 2)
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromKey("Announcement.HasAwoken", new object[]
				{
					Main.npc[num7].GetTypeNetName()
				}), new Color(175, 75, 255), -1);
            }
        }

    }
}

using System;
using Microsoft.Xna.Framework;

namespace Terraria.GameContent.Events
{
	// Token: 0x02000178 RID: 376
	public class CultistRitual
	{
		// Token: 0x06001279 RID: 4729 RVA: 0x00417D34 File Offset: 0x00415F34
		public static void UpdateTime()
		{
			if (Main.netMode == 1)
			{
				return;
			}
			CultistRitual.delay -= Main.dayRate;
			if (CultistRitual.delay < 0)
			{
				CultistRitual.delay = 0;
			}
			CultistRitual.recheck -= Main.dayRate;
			if (CultistRitual.recheck < 0)
			{
				CultistRitual.recheck = 0;
			}
			if (CultistRitual.delay == 0 && CultistRitual.recheck == 0)
			{
				CultistRitual.recheck = 600;
				if (NPC.AnyDanger())
				{
					CultistRitual.recheck *= 6;
					return;
				}
				CultistRitual.TrySpawning(Main.dungeonX, Main.dungeonY);
			}
		}

		// Token: 0x0600127A RID: 4730 RVA: 0x00417DC4 File Offset: 0x00415FC4
		public static void CultistSlain()
		{
			CultistRitual.delay -= 3600;
		}

		// Token: 0x0600127B RID: 4731 RVA: 0x00417DD8 File Offset: 0x00415FD8
		public static void TabletDestroyed()
		{
			CultistRitual.delay = 43200;
		}

		// Token: 0x0600127C RID: 4732 RVA: 0x00417DE4 File Offset: 0x00415FE4
		public static void TrySpawning(int x, int y)
		{
			if (WorldGen.PlayerLOS(x - 6, y) || WorldGen.PlayerLOS(x + 6, y))
			{
				return;
			}
			if (!CultistRitual.CheckRitual(x, y))
			{
				return;
			}
			NPC.NewNPC(x * 16 + 8, (y - 4) * 16 - 8, 437, 0, 0f, 0f, 0f, 0f, 255);
		}

		// Token: 0x0600127D RID: 4733 RVA: 0x00417E48 File Offset: 0x00416048
		private static bool CheckRitual(int x, int y)
		{
			if (CultistRitual.delay != 0 || !Main.hardMode || !NPC.downedGolemBoss || !NPC.downedBoss3)
			{
				return false;
			}
			if (y < 7 || WorldGen.SolidTile(Main.tile[x, y - 7]))
			{
				return false;
			}
			if (NPC.AnyNPCs(437))
			{
				return false;
			}
			Vector2 arg_64_0 = new Vector2((float)(x * 16 + 8), (float)(y * 16 - 64 - 8 - 27));
			Point[] array = null;
			return CultistRitual.CheckFloor(arg_64_0, out array);
		}

		// Token: 0x0600127E RID: 4734 RVA: 0x00417EC4 File Offset: 0x004160C4
		public static bool CheckFloor(Vector2 Center, out Point[] spawnPoints)
		{
			Point[] array = new Point[4];
			int num = 0;
			Point point = Center.ToTileCoordinates();
			for (int i = -5; i <= 5; i += 2)
			{
				if (i != -1 && i != 1)
				{
					for (int j = -5; j < 12; j++)
					{
						int num2 = point.X + i * 2;
						int num3 = point.Y + j;
						if (WorldGen.SolidTile(num2, num3) && !Collision.SolidTiles(num2 - 1, num2 + 1, num3 - 3, num3 - 1))
						{
							array[num++] = new Point(num2, num3);
							break;
						}
					}
				}
			}
			if (num != 4)
			{
				spawnPoints = null;
				return false;
			}
			spawnPoints = array;
			return true;
		}

		// Token: 0x0400329A RID: 12954
		public const int delayStart = 86400;

		// Token: 0x0400329B RID: 12955
		public const int respawnDelay = 43200;

		// Token: 0x0400329C RID: 12956
		private const int timePerCultist = 3600;

		// Token: 0x0400329D RID: 12957
		private const int recheckStart = 600;

		// Token: 0x0400329E RID: 12958
		public static int delay;

		// Token: 0x0400329F RID: 12959
		public static int recheck;
	}
}

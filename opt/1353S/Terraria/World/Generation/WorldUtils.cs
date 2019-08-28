using System;
using Microsoft.Xna.Framework;

namespace Terraria.World.Generation
{
	// Token: 0x0200005E RID: 94
	public static class WorldUtils
	{
		// Token: 0x06000950 RID: 2384 RVA: 0x003B5B3C File Offset: 0x003B3D3C
		public static bool Gen(Point origin, GenShape shape, GenAction action)
		{
			return shape.Perform(origin, action);
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x003B5B48 File Offset: 0x003B3D48
		public static bool Find(Point origin, GenSearch search, out Point result)
		{
			result = search.Find(origin);
			return !(result == GenSearch.NOT_FOUND);
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x003B5B6C File Offset: 0x003B3D6C
		public static void ClearTile(int x, int y, bool frameNeighbors = false)
		{
			Main.tile[x, y].ClearTile();
			if (frameNeighbors)
			{
				WorldGen.TileFrame(x + 1, y, false, false);
				WorldGen.TileFrame(x - 1, y, false, false);
				WorldGen.TileFrame(x, y + 1, false, false);
				WorldGen.TileFrame(x, y - 1, false, false);
			}
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x003B5BBC File Offset: 0x003B3DBC
		public static void ClearWall(int x, int y, bool frameNeighbors = false)
		{
			Main.tile[x, y].wall = 0;
			if (frameNeighbors)
			{
				WorldGen.SquareWallFrame(x + 1, y, true);
				WorldGen.SquareWallFrame(x - 1, y, true);
				WorldGen.SquareWallFrame(x, y + 1, true);
				WorldGen.SquareWallFrame(x, y - 1, true);
			}
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x003B5BFC File Offset: 0x003B3DFC
		public static void TileFrame(int x, int y, bool frameNeighbors = false)
		{
			WorldGen.TileFrame(x, y, true, false);
			if (frameNeighbors)
			{
				WorldGen.TileFrame(x + 1, y, true, false);
				WorldGen.TileFrame(x - 1, y, true, false);
				WorldGen.TileFrame(x, y + 1, true, false);
				WorldGen.TileFrame(x, y - 1, true, false);
			}
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x003B5C38 File Offset: 0x003B3E38
		public static void ClearChestLocation(int x, int y)
		{
			WorldUtils.ClearTile(x, y, true);
			WorldUtils.ClearTile(x - 1, y, true);
			WorldUtils.ClearTile(x, y - 1, true);
			WorldUtils.ClearTile(x - 1, y - 1, true);
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x003B5C64 File Offset: 0x003B3E64
		public static void WireLine(Point start, Point end)
		{
			Point point = start;
			Point point2 = end;
			if (end.X < start.X)
			{
				Utils.Swap<int>(ref end.X, ref start.X);
			}
			if (end.Y < start.Y)
			{
				Utils.Swap<int>(ref end.Y, ref start.Y);
			}
			for (int i = start.X; i <= end.X; i++)
			{
				WorldGen.PlaceWire(i, point.Y);
			}
			for (int j = start.Y; j <= end.Y; j++)
			{
				WorldGen.PlaceWire(point2.X, j);
			}
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x003B5D00 File Offset: 0x003B3F00
		public static void DebugRegen()
		{
			WorldGen.clearWorld();
			WorldGen.generateWorld(Main.ActiveWorldFileData.Seed, null);
			Main.NewText("World Regen Complete.", 255, 255, 255, false);
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x003B5D34 File Offset: 0x003B3F34
		public static void DebugRotate()
		{
			int num = 0;
			int num2 = 0;
			int maxTilesY = Main.maxTilesY;
			for (int i = 0; i < Main.maxTilesX / Main.maxTilesY; i++)
			{
				for (int j = 0; j < maxTilesY / 2; j++)
				{
					for (int k = j; k < maxTilesY - j; k++)
					{
						Tile tile = Main.tile[k + num, j + num2];
						Main.tile[k + num, j + num2] = Main.tile[j + num, maxTilesY - k + num2];
						Main.tile[j + num, maxTilesY - k + num2] = Main.tile[maxTilesY - k + num, maxTilesY - j + num2];
						Main.tile[maxTilesY - k + num, maxTilesY - j + num2] = Main.tile[maxTilesY - j + num, k + num2];
						Main.tile[maxTilesY - j + num, k + num2] = tile;
					}
				}
				num += maxTilesY;
			}
		}
	}
}

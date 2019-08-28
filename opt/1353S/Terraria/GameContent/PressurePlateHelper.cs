using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Terraria.GameContent
{
	// Token: 0x0200010C RID: 268
	public class PressurePlateHelper
	{
		// Token: 0x06000F12 RID: 3858 RVA: 0x003F0A74 File Offset: 0x003EEC74
		public static void Update()
		{
			if (!PressurePlateHelper.NeedsFirstUpdate)
			{
				return;
			}
			using (Dictionary<Point, bool[]>.KeyCollection.Enumerator enumerator = PressurePlateHelper.PressurePlatesPressed.Keys.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PressurePlateHelper.PokeLocation(enumerator.Current);
				}
			}
			PressurePlateHelper.PressurePlatesPressed.Clear();
			PressurePlateHelper.NeedsFirstUpdate = false;
		}

		// Token: 0x06000F13 RID: 3859 RVA: 0x003F0AE0 File Offset: 0x003EECE0
		public static void Reset()
		{
			PressurePlateHelper.PressurePlatesPressed.Clear();
			for (int i = 0; i < PressurePlateHelper.PlayerLastPosition.Length; i++)
			{
				PressurePlateHelper.PlayerLastPosition[i] = Vector2.Zero;
			}
		}

		// Token: 0x06000F14 RID: 3860 RVA: 0x003F0B1C File Offset: 0x003EED1C
		public static void ResetPlayer(int player)
		{
			using (Dictionary<Point, bool[]>.ValueCollection.Enumerator enumerator = PressurePlateHelper.PressurePlatesPressed.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current[player] = false;
				}
			}
		}

		// Token: 0x06000F15 RID: 3861 RVA: 0x003F0B70 File Offset: 0x003EED70
		public static void UpdatePlayerPosition(Player player)
		{
			Point point = new Point(1, 1);
			Vector2 vector = point.ToVector2();
			List<Point> tilesIn = Collision.GetTilesIn(PressurePlateHelper.PlayerLastPosition[player.whoAmI] + vector, PressurePlateHelper.PlayerLastPosition[player.whoAmI] + player.Size - vector * 2f);
			List<Point> tilesIn2 = Collision.GetTilesIn(player.TopLeft + vector, player.BottomRight - vector * 2f);
			Rectangle hitbox = player.Hitbox;
			Rectangle hitbox2 = player.Hitbox;
			hitbox.Inflate(-point.X, -point.Y);
			hitbox2.Inflate(-point.X, -point.Y);
			hitbox2.X = (int)PressurePlateHelper.PlayerLastPosition[player.whoAmI].X;
			hitbox2.Y = (int)PressurePlateHelper.PlayerLastPosition[player.whoAmI].Y;
			for (int i = 0; i < tilesIn.Count; i++)
			{
				Point point2 = tilesIn[i];
				Tile tile = Main.tile[point2.X, point2.Y];
				if (tile.active() && tile.type == 428)
				{
					PressurePlateHelper.pressurePlateBounds.X = point2.X * 16;
					PressurePlateHelper.pressurePlateBounds.Y = point2.Y * 16 + 16 - PressurePlateHelper.pressurePlateBounds.Height;
					if (!hitbox.Intersects(PressurePlateHelper.pressurePlateBounds) && !tilesIn2.Contains(point2))
					{
						PressurePlateHelper.MoveAwayFrom(point2, player.whoAmI);
					}
				}
			}
			for (int j = 0; j < tilesIn2.Count; j++)
			{
				Point point3 = tilesIn2[j];
				Tile tile2 = Main.tile[point3.X, point3.Y];
				if (tile2.active() && tile2.type == 428)
				{
					PressurePlateHelper.pressurePlateBounds.X = point3.X * 16;
					PressurePlateHelper.pressurePlateBounds.Y = point3.Y * 16 + 16 - PressurePlateHelper.pressurePlateBounds.Height;
					if (hitbox.Intersects(PressurePlateHelper.pressurePlateBounds) && (!tilesIn.Contains(point3) || !hitbox2.Intersects(PressurePlateHelper.pressurePlateBounds)))
					{
						PressurePlateHelper.MoveInto(point3, player.whoAmI);
					}
				}
			}
			PressurePlateHelper.PlayerLastPosition[player.whoAmI] = player.position;
		}

		// Token: 0x06000F16 RID: 3862 RVA: 0x003F0DF8 File Offset: 0x003EEFF8
		public static void DestroyPlate(Point location)
		{
			bool[] array;
			if (PressurePlateHelper.PressurePlatesPressed.TryGetValue(location, out array))
			{
				PressurePlateHelper.PressurePlatesPressed.Remove(location);
				PressurePlateHelper.PokeLocation(location);
			}
		}

		// Token: 0x06000F17 RID: 3863 RVA: 0x003F0E28 File Offset: 0x003EF028
		private static void UpdatePlatePosition(Point location, int player, bool onIt)
		{
			if (onIt)
			{
				PressurePlateHelper.MoveInto(location, player);
				return;
			}
			PressurePlateHelper.MoveAwayFrom(location, player);
		}

		// Token: 0x06000F18 RID: 3864 RVA: 0x003F0E3C File Offset: 0x003EF03C
		private static void MoveInto(Point location, int player)
		{
			bool[] array;
			if (PressurePlateHelper.PressurePlatesPressed.TryGetValue(location, out array))
			{
				array[player] = true;
				return;
			}
			PressurePlateHelper.PressurePlatesPressed[location] = new bool[255];
			PressurePlateHelper.PressurePlatesPressed[location][player] = true;
			PressurePlateHelper.PokeLocation(location);
		}

		// Token: 0x06000F19 RID: 3865 RVA: 0x003F0E88 File Offset: 0x003EF088
		private static void MoveAwayFrom(Point location, int player)
		{
			bool[] array;
			if (PressurePlateHelper.PressurePlatesPressed.TryGetValue(location, out array))
			{
				array[player] = false;
				bool flag = false;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i])
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					PressurePlateHelper.PressurePlatesPressed.Remove(location);
					PressurePlateHelper.PokeLocation(location);
				}
			}
		}

		// Token: 0x06000F1A RID: 3866 RVA: 0x003F0ED8 File Offset: 0x003EF0D8
		private static void PokeLocation(Point location)
		{
			if (Main.netMode != 1)
			{
				Wiring.blockPlayerTeleportationForOneIteration = true;
				Wiring.HitSwitch(location.X, location.Y);
				NetMessage.SendData(59, -1, -1, null, location.X, (float)location.Y, 0f, 0f, 0, 0, 0);
			}
		}

		// Token: 0x04003028 RID: 12328
		public static Dictionary<Point, bool[]> PressurePlatesPressed = new Dictionary<Point, bool[]>();

		// Token: 0x04003029 RID: 12329
		public static bool NeedsFirstUpdate = false;

		// Token: 0x0400302A RID: 12330
		private static Vector2[] PlayerLastPosition = new Vector2[255];

		// Token: 0x0400302B RID: 12331
		private static Rectangle pressurePlateBounds = new Rectangle(0, 0, 16, 10);
	}
}

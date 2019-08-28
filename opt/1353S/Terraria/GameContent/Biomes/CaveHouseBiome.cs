using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
	// Token: 0x02000125 RID: 293
	public class CaveHouseBiome : MicroBiome
	{
		// Token: 0x06000FBC RID: 4028 RVA: 0x003F8B90 File Offset: 0x003F6D90
		internal static void AgeDefaultRoom(Rectangle room)
		{
			for (int i = 0; i < room.Width * room.Height / 16; i++)
			{
				int arg_3D_0 = GenBase._random.Next(1, room.Width - 1) + room.X;
				int y = GenBase._random.Next(1, room.Height - 1) + room.Y;
				WorldUtils.Gen(new Point(arg_3D_0, y), new Shapes.Rectangle(2, 2), Actions.Chain(new GenAction[]
				{
					new Modifiers.Dither(0.5),
					new Modifiers.Blotches(2, 2.0),
					new Modifiers.IsEmpty(),
					new Actions.SetTile(51, true, true)
				}));
			}
			WorldUtils.Gen(new Point(room.X, room.Y), new Shapes.Rectangle(room.Width, room.Height), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.85000002384185791),
				new Modifiers.Blotches(2, 0.3),
				new Modifiers.OnlyWalls(new byte[]
				{
					CaveHouseBiome.BuildData.Default.Wall
				}),
				((double)room.Y > Main.worldSurface) ? (GenAction) new Actions.ClearWall(true) : new Actions.PlaceWall(2, true)
			}));
			WorldUtils.Gen(new Point(room.X, room.Y), new Shapes.Rectangle(room.Width, room.Height), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.949999988079071),
				new Modifiers.OnlyTiles(new ushort[]
				{
					30,
					321,
					158
				}),
				new Actions.ClearTile(true)
			}));
		}

		// Token: 0x06000FBE RID: 4030 RVA: 0x003F8F44 File Offset: 0x003F7144
		internal static void AgeDesertRoom(Rectangle room)
		{
			WorldUtils.Gen(new Point(room.X, room.Y), new Shapes.Rectangle(room.Width, room.Height), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.800000011920929),
				new Modifiers.Blotches(2, 0.20000000298023224),
				new Modifiers.OnlyTiles(new ushort[]
				{
					CaveHouseBiome.BuildData.Desert.Tile
				}),
				new Actions.SetTile(396, true, true),
				new Modifiers.Dither(0.5),
				new Actions.SetTile(397, true, true)
			}));
			WorldUtils.Gen(new Point(room.X + 1, room.Y), new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.5),
				new Modifiers.OnlyTiles(new ushort[]
				{
					397,
					396
				}),
				new Modifiers.Offset(0, 1),
				new ActionStalagtite()
			}));
			WorldUtils.Gen(new Point(room.X + 1, room.Y + room.Height - 1), new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.5),
				new Modifiers.OnlyTiles(new ushort[]
				{
					397,
					396
				}),
				new Modifiers.Offset(0, 1),
				new ActionStalagtite()
			}));
			WorldUtils.Gen(new Point(room.X, room.Y), new Shapes.Rectangle(room.Width, room.Height), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.800000011920929),
				new Modifiers.Blotches(2, 0.3),
				new Modifiers.OnlyWalls(new byte[]
				{
					CaveHouseBiome.BuildData.Desert.Wall
				}),
				new Actions.PlaceWall(216, true)
			}));
		}

		// Token: 0x06000FBF RID: 4031 RVA: 0x003F9160 File Offset: 0x003F7360
		internal static void AgeGraniteRoom(Rectangle room)
		{
			WorldUtils.Gen(new Point(room.X, room.Y), new Shapes.Rectangle(room.Width, room.Height), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.60000002384185791),
				new Modifiers.Blotches(2, 0.60000002384185791),
				new Modifiers.OnlyTiles(new ushort[]
				{
					CaveHouseBiome.BuildData.Granite.Tile
				}),
				new Actions.SetTile(368, true, true)
			}));
			WorldUtils.Gen(new Point(room.X + 1, room.Y), new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.800000011920929),
				new Modifiers.OnlyTiles(new ushort[]
				{
					368
				}),
				new Modifiers.Offset(0, 1),
				new ActionStalagtite()
			}));
			WorldUtils.Gen(new Point(room.X + 1, room.Y + room.Height - 1), new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.800000011920929),
				new Modifiers.OnlyTiles(new ushort[]
				{
					368
				}),
				new Modifiers.Offset(0, 1),
				new ActionStalagtite()
			}));
			WorldUtils.Gen(new Point(room.X, room.Y), new Shapes.Rectangle(room.Width, room.Height), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.85000002384185791),
				new Modifiers.Blotches(2, 0.3),
				new Actions.PlaceWall(180, true)
			}));
		}

		// Token: 0x06000FC2 RID: 4034 RVA: 0x003F96CC File Offset: 0x003F78CC
		internal static void AgeJungleRoom(Rectangle room)
		{
			WorldUtils.Gen(new Point(room.X, room.Y), new Shapes.Rectangle(room.Width, room.Height), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.60000002384185791),
				new Modifiers.Blotches(2, 0.60000002384185791),
				new Modifiers.OnlyTiles(new ushort[]
				{
					CaveHouseBiome.BuildData.Jungle.Tile
				}),
				new Actions.SetTile(60, true, true),
				new Modifiers.Dither(0.800000011920929),
				new Actions.SetTile(59, true, true)
			}));
			WorldUtils.Gen(new Point(room.X + 1, room.Y), new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.5),
				new Modifiers.OnlyTiles(new ushort[]
				{
					60
				}),
				new Modifiers.Offset(0, 1),
				new ActionVines(3, room.Height, 62)
			}));
			WorldUtils.Gen(new Point(room.X + 1, room.Y + room.Height - 1), new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.5),
				new Modifiers.OnlyTiles(new ushort[]
				{
					60
				}),
				new Modifiers.Offset(0, 1),
				new ActionVines(3, room.Height, 62)
			}));
			WorldUtils.Gen(new Point(room.X, room.Y), new Shapes.Rectangle(room.Width, room.Height), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.85000002384185791),
				new Modifiers.Blotches(2, 0.3),
				new Actions.PlaceWall(64, true)
			}));
		}

		// Token: 0x06000FC0 RID: 4032 RVA: 0x003F9330 File Offset: 0x003F7530
		internal static void AgeMarbleRoom(Rectangle room)
		{
			WorldUtils.Gen(new Point(room.X, room.Y), new Shapes.Rectangle(room.Width, room.Height), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.60000002384185791),
				new Modifiers.Blotches(2, 0.60000002384185791),
				new Modifiers.OnlyTiles(new ushort[]
				{
					CaveHouseBiome.BuildData.Marble.Tile
				}),
				new Actions.SetTile(367, true, true)
			}));
			WorldUtils.Gen(new Point(room.X + 1, room.Y), new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.800000011920929),
				new Modifiers.OnlyTiles(new ushort[]
				{
					367
				}),
				new Modifiers.Offset(0, 1),
				new ActionStalagtite()
			}));
			WorldUtils.Gen(new Point(room.X + 1, room.Y + room.Height - 1), new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.800000011920929),
				new Modifiers.OnlyTiles(new ushort[]
				{
					367
				}),
				new Modifiers.Offset(0, 1),
				new ActionStalagtite()
			}));
			WorldUtils.Gen(new Point(room.X, room.Y), new Shapes.Rectangle(room.Width, room.Height), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.85000002384185791),
				new Modifiers.Blotches(2, 0.3),
				new Actions.PlaceWall(178, true)
			}));
		}

		// Token: 0x06000FC1 RID: 4033 RVA: 0x003F9500 File Offset: 0x003F7700
		internal static void AgeMushroomRoom(Rectangle room)
		{
			WorldUtils.Gen(new Point(room.X, room.Y), new Shapes.Rectangle(room.Width, room.Height), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.699999988079071),
				new Modifiers.Blotches(2, 0.5),
				new Modifiers.OnlyTiles(new ushort[]
				{
					CaveHouseBiome.BuildData.Mushroom.Tile
				}),
				new Actions.SetTile(70, true, true)
			}));
			WorldUtils.Gen(new Point(room.X + 1, room.Y), new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.60000002384185791),
				new Modifiers.OnlyTiles(new ushort[]
				{
					70
				}),
				new Modifiers.Offset(0, -1),
				new Actions.SetTile(71, false, true)
			}));
			WorldUtils.Gen(new Point(room.X + 1, room.Y + room.Height - 1), new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.60000002384185791),
				new Modifiers.OnlyTiles(new ushort[]
				{
					70
				}),
				new Modifiers.Offset(0, -1),
				new Actions.SetTile(71, false, true)
			}));
			WorldUtils.Gen(new Point(room.X, room.Y), new Shapes.Rectangle(room.Width, room.Height), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.85000002384185791),
				new Modifiers.Blotches(2, 0.3),
				new Actions.ClearWall(false)
			}));
		}

		// Token: 0x06000FBD RID: 4029 RVA: 0x003F8D40 File Offset: 0x003F6F40
		internal static void AgeSnowRoom(Rectangle room)
		{
			WorldUtils.Gen(new Point(room.X, room.Y), new Shapes.Rectangle(room.Width, room.Height), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.60000002384185791),
				new Modifiers.Blotches(2, 0.60000002384185791),
				new Modifiers.OnlyTiles(new ushort[]
				{
					CaveHouseBiome.BuildData.Snow.Tile
				}),
				new Actions.SetTile(161, true, true),
				new Modifiers.Dither(0.8),
				new Actions.SetTile(147, true, true)
			}));
			WorldUtils.Gen(new Point(room.X + 1, room.Y), new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.5),
				new Modifiers.OnlyTiles(new ushort[]
				{
					161
				}),
				new Modifiers.Offset(0, 1),
				new ActionStalagtite()
			}));
			WorldUtils.Gen(new Point(room.X + 1, room.Y + room.Height - 1), new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.5),
				new Modifiers.OnlyTiles(new ushort[]
				{
					161
				}),
				new Modifiers.Offset(0, 1),
				new ActionStalagtite()
			}));
			WorldUtils.Gen(new Point(room.X, room.Y), new Shapes.Rectangle(room.Width, room.Height), Actions.Chain(new GenAction[]
			{
				new Modifiers.Dither(0.85000002384185791),
				new Modifiers.Blotches(2, 0.8),
				((double)room.Y > Main.worldSurface) ? (GenAction) new Actions.ClearWall(true) : new Actions.PlaceWall(40, true)
			}));
		}

		// Token: 0x06000FB8 RID: 4024 RVA: 0x003F7544 File Offset: 0x003F5744
		private bool FindSideExit(Rectangle wall, bool isLeft, out int exitY)
		{
			Point point;
			bool arg_5E_0 = WorldUtils.Find(new Point(wall.X + (isLeft ? -4 : 0), wall.Y + wall.Height - 3), Searches.Chain(new Searches.Up(wall.Height - 3), new GenCondition[]
			{
				new Conditions.IsSolid().Not().AreaOr(4, 3)
			}), out point);
			exitY = point.Y;
			return arg_5E_0;
		}

		// Token: 0x06000FB7 RID: 4023 RVA: 0x003F74D8 File Offset: 0x003F56D8
		private bool FindVerticalExit(Rectangle wall, bool isUp, out int exitX)
		{
			Point point;
			bool arg_5E_0 = WorldUtils.Find(new Point(wall.X + wall.Width - 3, wall.Y + (isUp ? -5 : 0)), Searches.Chain(new Searches.Left(wall.Width - 3), new GenCondition[]
			{
				new Conditions.IsSolid().Not().AreaOr(3, 5)
			}), out point);
			exitX = point.X;
			return arg_5E_0;
		}

		// Token: 0x06000FB5 RID: 4021 RVA: 0x003F729C File Offset: 0x003F549C
		private Rectangle GetRoom(Point origin)
		{
			Point point;
			bool flag = WorldUtils.Find(origin, Searches.Chain(new Searches.Left(25), new GenCondition[]
			{
				new Conditions.IsSolid()
			}), out point);
			Point point2;
			bool arg_5E_0 = WorldUtils.Find(origin, Searches.Chain(new Searches.Right(25), new GenCondition[]
			{
				new Conditions.IsSolid()
			}), out point2);
			if (!flag)
			{
				point = new Point(origin.X - 25, origin.Y);
			}
			if (!arg_5E_0)
			{
				point2 = new Point(origin.X + 25, origin.Y);
			}
			Rectangle rectangle = new Rectangle(origin.X, origin.Y, 0, 0);
			if (origin.X - point.X > point2.X - origin.X)
			{
				rectangle.X = point.X;
				rectangle.Width = Utils.Clamp<int>(point2.X - point.X, 15, 30);
			}
			else
			{
				rectangle.Width = Utils.Clamp<int>(point2.X - point.X, 15, 30);
				rectangle.X = point2.X - rectangle.Width;
			}
			Point point3;
			bool flag2 = WorldUtils.Find(point, Searches.Chain(new Searches.Up(10), new GenCondition[]
			{
				new Conditions.IsSolid()
			}), out point3);
			Point point4;
			bool arg_164_0 = WorldUtils.Find(point2, Searches.Chain(new Searches.Up(10), new GenCondition[]
			{
				new Conditions.IsSolid()
			}), out point4);
			if (!flag2)
			{
				point3 = new Point(origin.X, origin.Y - 10);
			}
			if (!arg_164_0)
			{
				point4 = new Point(origin.X, origin.Y - 10);
			}
			rectangle.Height = Utils.Clamp<int>(Math.Max(origin.Y - point3.Y, origin.Y - point4.Y), 8, 12);
			rectangle.Y -= rectangle.Height;
			return rectangle;
		}

		// Token: 0x06000FBA RID: 4026 RVA: 0x003F75D4 File Offset: 0x003F57D4
		public override bool Place(Point origin, StructureMap structures)
		{
			Point point;
			if (!WorldUtils.Find(origin, Searches.Chain(new Searches.Down(200), new GenCondition[]
			{
				new Conditions.IsSolid()
			}), out point) || point == origin)
			{
				return false;
			}
			Rectangle room = this.GetRoom(point);
			Rectangle rectangle = this.GetRoom(new Point(room.Center.X, room.Y + 1));
			Rectangle rectangle2 = this.GetRoom(new Point(room.Center.X, room.Y + room.Height + 10));
			rectangle2.Y = room.Y + room.Height - 1;
			float num = this.RoomSolidPrecentage(rectangle);
			float num2 = this.RoomSolidPrecentage(rectangle2);
			room.Y += 3;
			rectangle.Y += 3;
			rectangle2.Y += 3;
			List<Rectangle> list = new List<Rectangle>();
			if (GenBase._random.NextFloat() > num + 0.2f)
			{
				list.Add(rectangle);
			}
			else
			{
				rectangle = room;
			}
			list.Add(room);
			if (GenBase._random.NextFloat() > num2 + 0.2f)
			{
				list.Add(rectangle2);
			}
			else
			{
				rectangle2 = room;
			}
			foreach (Rectangle current in list)
			{
				if (current.Y + current.Height > Main.maxTilesY - 220)
				{
					bool result = false;
					return result;
				}
			}
			Dictionary<ushort, int> dictionary = new Dictionary<ushort, int>();
			foreach (Rectangle current2 in list)
			{
				WorldUtils.Gen(new Point(current2.X - 10, current2.Y - 10), new Shapes.Rectangle(current2.Width + 20, current2.Height + 20), new Actions.TileScanner(new ushort[]
				{
					0,
					59,
					147,
					1,
					161,
					53,
					396,
					397,
					368,
					367,
					60,
					70
				}).Output(dictionary));
			}
			List<Tuple<CaveHouseBiome.BuildData, int>> expr_1FD = new List<Tuple<CaveHouseBiome.BuildData, int>>();
			expr_1FD.Add(Tuple.Create<CaveHouseBiome.BuildData, int>(CaveHouseBiome.BuildData.Default, dictionary[0] + dictionary[1]));
			expr_1FD.Add(Tuple.Create<CaveHouseBiome.BuildData, int>(CaveHouseBiome.BuildData.Jungle, dictionary[59] + dictionary[60] * 10));
			expr_1FD.Add(Tuple.Create<CaveHouseBiome.BuildData, int>(CaveHouseBiome.BuildData.Mushroom, dictionary[59] + dictionary[70] * 10));
			expr_1FD.Add(Tuple.Create<CaveHouseBiome.BuildData, int>(CaveHouseBiome.BuildData.Snow, dictionary[147] + dictionary[161]));
			expr_1FD.Add(Tuple.Create<CaveHouseBiome.BuildData, int>(CaveHouseBiome.BuildData.Desert, dictionary[397] + dictionary[396] + dictionary[53]));
			expr_1FD.Add(Tuple.Create<CaveHouseBiome.BuildData, int>(CaveHouseBiome.BuildData.Granite, dictionary[368]));
			expr_1FD.Add(Tuple.Create<CaveHouseBiome.BuildData, int>(CaveHouseBiome.BuildData.Marble, dictionary[367]));
			expr_1FD.Sort(new Comparison<Tuple<CaveHouseBiome.BuildData, int>>(this.SortBiomeResults));
			CaveHouseBiome.BuildData item = expr_1FD[0].Item1;
			foreach (Rectangle current3 in list)
			{
				Point point2;
				if (item != CaveHouseBiome.BuildData.Granite && WorldUtils.Find(new Point(current3.X - 2, current3.Y - 2), Searches.Chain(new Searches.Rectangle(current3.Width + 4, current3.Height + 4).RequireAll(false), new GenCondition[]
				{
					new Conditions.HasLava()
				}), out point2))
				{
					bool result = false;
					return result;
				}
				if (!structures.CanPlace(current3, CaveHouseBiome._blacklistedTiles, 5))
				{
					bool result = false;
					return result;
				}
			}
			int num3 = room.X;
			int num4 = room.X + room.Width - 1;
			List<Rectangle> list2 = new List<Rectangle>();
			foreach (Rectangle current4 in list)
			{
				num3 = Math.Min(num3, current4.X);
				num4 = Math.Max(num4, current4.X + current4.Width - 1);
			}
			int num5 = 6;
			while (num5 > 4 && (num4 - num3) % num5 != 0)
			{
				num5--;
			}
			for (int i = num3; i <= num4; i += num5)
			{
				for (int j = 0; j < list.Count; j++)
				{
					Rectangle rectangle3 = list[j];
					if (i >= rectangle3.X && i < rectangle3.X + rectangle3.Width)
					{
						int num6 = rectangle3.Y + rectangle3.Height;
						int num7 = 50;
						for (int k = j + 1; k < list.Count; k++)
						{
							if (i >= list[k].X && i < list[k].X + list[k].Width)
							{
								num7 = Math.Min(num7, list[k].Y - num6);
							}
						}
						if (num7 > 0)
						{
							Point point3;
							bool flag = WorldUtils.Find(new Point(i, num6), Searches.Chain(new Searches.Down(num7), new GenCondition[]
							{
								new Conditions.IsSolid()
							}), out point3);
							if (num7 < 50)
							{
								flag = true;
								point3 = new Point(i, num6 + num7);
							}
							if (flag)
							{
								list2.Add(new Rectangle(i, num6, 1, point3.Y - num6));
							}
						}
					}
				}
			}
			List<Point> list3 = new List<Point>();
			foreach (Rectangle current5 in list)
			{
				int y;
				if (this.FindSideExit(new Rectangle(current5.X + current5.Width, current5.Y + 1, 1, current5.Height - 2), false, out y))
				{
					list3.Add(new Point(current5.X + current5.Width - 1, y));
				}
				if (this.FindSideExit(new Rectangle(current5.X, current5.Y + 1, 1, current5.Height - 2), true, out y))
				{
					list3.Add(new Point(current5.X, y));
				}
			}
			List<Tuple<Point, Point>> list4 = new List<Tuple<Point, Point>>();
			for (int l = 1; l < list.Count; l++)
			{
				Rectangle rectangle4 = list[l];
				Rectangle rectangle5 = list[l - 1];
				int arg_6C3_0 = rectangle5.X - rectangle4.X;
				int num8 = rectangle4.X + rectangle4.Width - (rectangle5.X + rectangle5.Width);
				if (arg_6C3_0 > num8)
				{
					list4.Add(new Tuple<Point, Point>(new Point(rectangle4.X + rectangle4.Width - 1, rectangle4.Y + 1), new Point(rectangle4.X + rectangle4.Width - rectangle4.Height + 1, rectangle4.Y + rectangle4.Height - 1)));
				}
				else
				{
					list4.Add(new Tuple<Point, Point>(new Point(rectangle4.X, rectangle4.Y + 1), new Point(rectangle4.X + rectangle4.Height - 1, rectangle4.Y + rectangle4.Height - 1)));
				}
			}
			List<Point> list5 = new List<Point>();
			int x;
			if (this.FindVerticalExit(new Rectangle(rectangle.X + 2, rectangle.Y, rectangle.Width - 4, 1), true, out x))
			{
				list5.Add(new Point(x, rectangle.Y));
			}
			if (this.FindVerticalExit(new Rectangle(rectangle2.X + 2, rectangle2.Y + rectangle2.Height - 1, rectangle2.Width - 4, 1), false, out x))
			{
				list5.Add(new Point(x, rectangle2.Y + rectangle2.Height - 1));
			}
			foreach (Rectangle current6 in list)
			{
				WorldUtils.Gen(new Point(current6.X, current6.Y), new Shapes.Rectangle(current6.Width, current6.Height), Actions.Chain(new GenAction[]
				{
					new Actions.SetTile(item.Tile, false, true),
					new Actions.SetFrames(true)
				}));
				WorldUtils.Gen(new Point(current6.X + 1, current6.Y + 1), new Shapes.Rectangle(current6.Width - 2, current6.Height - 2), Actions.Chain(new GenAction[]
				{
					new Actions.ClearTile(true),
					new Actions.PlaceWall(item.Wall, true)
				}));
				structures.AddStructure(current6, 8);
			}
			foreach (Tuple<Point, Point> expr_906 in list4)
			{
				Point item2 = expr_906.Item1;
				Point item3 = expr_906.Item2;
				int num9 = (item3.X > item2.X) ? 1 : -1;
				ShapeData shapeData = new ShapeData();
				for (int m = 0; m < item3.Y - item2.Y; m++)
				{
					shapeData.Add(num9 * (m + 1), m);
				}
				WorldUtils.Gen(item2, new ModShapes.All(shapeData), Actions.Chain(new GenAction[]
				{
					new Actions.PlaceTile(19, item.PlatformStyle),
					new Actions.SetSlope((num9 == 1) ? 1 : 2),
					new Actions.SetFrames(true)
				}));
				WorldUtils.Gen(new Point(item2.X + ((num9 == 1) ? 1 : -4), item2.Y - 1), new Shapes.Rectangle(4, 1), Actions.Chain(new GenAction[]
				{
					new Actions.Clear(),
					new Actions.PlaceWall(item.Wall, true),
					new Actions.PlaceTile(19, item.PlatformStyle),
					new Actions.SetFrames(true)
				}));
			}
			foreach (Point current7 in list3)
			{
				WorldUtils.Gen(current7, new Shapes.Rectangle(1, 3), new Actions.ClearTile(true));
				WorldGen.PlaceTile(current7.X, current7.Y, 10, true, true, -1, item.DoorStyle);
			}
			using (List<Point>.Enumerator enumerator3 = list5.GetEnumerator())
			{
				while (enumerator3.MoveNext())
				{
					WorldUtils.Gen(enumerator3.Current, new Shapes.Rectangle(3, 1), Actions.Chain(new GenAction[]
					{
						new Actions.ClearMetadata(),
						new Actions.PlaceTile(19, item.PlatformStyle),
						new Actions.SetFrames(true)
					}));
				}
			}
			foreach (Rectangle current8 in list2)
			{
				if (current8.Height > 1 && GenBase._tiles[current8.X, current8.Y - 1].type != 19)
				{
					WorldUtils.Gen(new Point(current8.X, current8.Y), new Shapes.Rectangle(current8.Width, current8.Height), Actions.Chain(new GenAction[]
					{
						new Actions.SetTile(124, false, true),
						new Actions.SetFrames(true)
					}));
					Tile expr_BA5 = GenBase._tiles[current8.X, current8.Y + current8.Height];
					expr_BA5.slope(0);
					expr_BA5.halfBrick(false);
				}
			}
			Point[] choices = new Point[]
			{
				new Point(14, item.TableStyle),
				new Point(16, 0),
				new Point(18, item.WorkbenchStyle),
				new Point(86, 0),
				new Point(87, item.PianoStyle),
				new Point(94, 0),
				new Point(101, item.BookcaseStyle)
			};
			foreach (Rectangle current9 in list)
			{
				int num10 = current9.Width / 8;
				int num11 = current9.Width / (num10 + 1);
				int num12 = GenBase._random.Next(2);
				for (int n = 0; n < num10; n++)
				{
					int num13 = (n + 1) * num11 + current9.X;
					int num14 = n + num12 % 2;
					if (num14 != 0)
					{
						if (num14 == 1)
						{
							int num15 = current9.Y + 1;
							WorldGen.PlaceTile(num13, num15, 34, true, false, -1, GenBase._random.Next(6));
							for (int num16 = -1; num16 < 2; num16++)
							{
								for (int num17 = 0; num17 < 3; num17++)
								{
									Tile expr_D5C = GenBase._tiles[num16 + num13, num17 + num15];
									expr_D5C.frameX += 54;
								}
							}
						}
					}
					else
					{
						int num15 = current9.Y + Math.Min(current9.Height / 2, current9.Height - 5);
						Vector2 expr_CEA = WorldGen.randHousePicture();
						int type = (int)expr_CEA.X;
						int style = (int)expr_CEA.Y;
						if (!WorldGen.nearPicture(num13, num15))
						{
							WorldGen.PlaceTile(num13, num15, type, true, false, -1, style);
						}
					}
				}
				int num18 = current9.Width / 8 + 3;
				WorldGen.SetupStatueList();
				while (num18 > 0)
				{
					int num19 = GenBase._random.Next(current9.Width - 3) + 1 + current9.X;
					int num20 = current9.Y + current9.Height - 2;
					switch (GenBase._random.Next(4))
					{
						case 0:
							WorldGen.PlaceSmallPile(num19, num20, GenBase._random.Next(31, 34), 1, 185);
							break;
						case 1:
							WorldGen.PlaceTile(num19, num20, 186, true, false, -1, GenBase._random.Next(22, 26));
							break;
						case 2:
							{
								int num21 = GenBase._random.Next(2, WorldGen.statueList.Length);
								WorldGen.PlaceTile(num19, num20, (int)WorldGen.statueList[num21].X, true, false, -1, (int)WorldGen.statueList[num21].Y);
								if (WorldGen.StatuesWithTraps.Contains(num21))
								{
									WorldGen.PlaceStatueTrap(num19, num20);
								}
								break;
							}
						case 3:
							{
								Point point4 = Utils.SelectRandom<Point>(GenBase._random, choices);
								WorldGen.PlaceTile(num19, num20, point4.X, true, false, -1, point4.Y);
								break;
							}
					}
					num18--;
				}
			}
			foreach (Rectangle current10 in list)
			{
				item.ProcessRoom(current10);
			}
			bool flag2 = false;
			foreach (Rectangle current11 in list)
			{
				int num22 = current11.Height - 1 + current11.Y;
				int style2 = (num22 > (int)Main.worldSurface) ? item.ChestStyle : 0;
				int num23 = 0;
				while (num23 < 10 && !(flag2 = WorldGen.AddBuriedChest(GenBase._random.Next(2, current11.Width - 2) + current11.X, num22, 0, false, style2)))
				{
					num23++;
				}
				if (flag2)
				{
					break;
				}
				int num24 = current11.X + 2;
				while (num24 <= current11.X + current11.Width - 2 && !(flag2 = WorldGen.AddBuriedChest(num24, num22, 0, false, style2)))
				{
					num24++;
				}
				if (flag2)
				{
					break;
				}
			}
			if (!flag2)
			{
				foreach (Rectangle current12 in list)
				{
					int num25 = current12.Y - 1;
					int style3 = (num25 > (int)Main.worldSurface) ? item.ChestStyle : 0;
					int num26 = 0;
					while (num26 < 10 && !(flag2 = WorldGen.AddBuriedChest(GenBase._random.Next(2, current12.Width - 2) + current12.X, num25, 0, false, style3)))
					{
						num26++;
					}
					if (flag2)
					{
						break;
					}
					int num27 = current12.X + 2;
					while (num27 <= current12.X + current12.Width - 2 && !(flag2 = WorldGen.AddBuriedChest(num27, num25, 0, false, style3)))
					{
						num27++;
					}
					if (flag2)
					{
						break;
					}
				}
			}
			if (!flag2)
			{
				for (int num28 = 0; num28 < 1000; num28++)
				{
					int arg_1175_0 = GenBase._random.Next(list[0].X - 30, list[0].X + 30);
					int num29 = GenBase._random.Next(list[0].Y - 30, list[0].Y + 30);
					int style4 = (num29 > (int)Main.worldSurface) ? item.ChestStyle : 0;
					if (flag2 = WorldGen.AddBuriedChest(arg_1175_0, num29, 0, false, style4))
					{
						break;
					}
				}
			}
			if (item == CaveHouseBiome.BuildData.Jungle && this._sharpenerCount < GenBase._random.Next(2, 5))
			{
				bool flag3 = false;
				foreach (Rectangle current13 in list)
				{
					int num30 = current13.Height - 2 + current13.Y;
					for (int num31 = 0; num31 < 10; num31++)
					{
						int num32 = GenBase._random.Next(2, current13.Width - 2) + current13.X;
						WorldGen.PlaceTile(num32, num30, 377, true, true, -1, 0);
						if (flag3 = (GenBase._tiles[num32, num30].active() && GenBase._tiles[num32, num30].type == 377))
						{
							break;
						}
					}
					if (flag3)
					{
						break;
					}
					int num33 = current13.X + 2;
					while (num33 <= current13.X + current13.Width - 2 && !(flag3 = WorldGen.PlaceTile(num33, num30, 377, true, true, -1, 0)))
					{
						num33++;
					}
					if (flag3)
					{
						break;
					}
				}
				if (flag3)
				{
					this._sharpenerCount++;
				}
			}
			if (item == CaveHouseBiome.BuildData.Desert && this._extractinatorCount < GenBase._random.Next(2, 5))
			{
				bool flag4 = false;
				foreach (Rectangle current14 in list)
				{
					int num34 = current14.Height - 2 + current14.Y;
					for (int num35 = 0; num35 < 10; num35++)
					{
						int num36 = GenBase._random.Next(2, current14.Width - 2) + current14.X;
						WorldGen.PlaceTile(num36, num34, 219, true, true, -1, 0);
						if (flag4 = (GenBase._tiles[num36, num34].active() && GenBase._tiles[num36, num34].type == 219))
						{
							break;
						}
					}
					if (flag4)
					{
						break;
					}
					int num37 = current14.X + 2;
					while (num37 <= current14.X + current14.Width - 2 && !(flag4 = WorldGen.PlaceTile(num37, num34, 219, true, true, -1, 0)))
					{
						num37++;
					}
					if (flag4)
					{
						break;
					}
				}
				if (flag4)
				{
					this._extractinatorCount++;
				}
			}
			return true;
		}

		// Token: 0x06000FBB RID: 4027 RVA: 0x003F8B80 File Offset: 0x003F6D80
		public override void Reset()
		{
			this._sharpenerCount = 0;
			this._extractinatorCount = 0;
		}

		// Token: 0x06000FB6 RID: 4022 RVA: 0x003F7468 File Offset: 0x003F5668
		private float RoomSolidPrecentage(Rectangle room)
		{
			float num = (float)(room.Width * room.Height);
			Ref<int> @ref = new Ref<int>(0);
			WorldUtils.Gen(new Point(room.X, room.Y), new Shapes.Rectangle(room.Width, room.Height), Actions.Chain(new GenAction[]
			{
				new Modifiers.IsSolid(),
				new Actions.Count(@ref)
			}));
			return (float)@ref.Value / num;
		}

		// Token: 0x06000FB9 RID: 4025 RVA: 0x003F75B0 File Offset: 0x003F57B0
		private int SortBiomeResults(Tuple<CaveHouseBiome.BuildData, int> item1, Tuple<CaveHouseBiome.BuildData, int> item2)
		{
			return item2.Item2.CompareTo(item1.Item2);
		}

		// Token: 0x04003076 RID: 12406
		private const int VERTICAL_EXIT_WIDTH = 3;

		// Token: 0x04003077 RID: 12407
		private static readonly bool[] _blacklistedTiles = TileID.Sets.Factory.CreateBoolSet(true, new int[]
		{
			225,
			41,
			43,
			44,
			226,
			203,
			112,
			25,
			151
		});

		// Token: 0x04003079 RID: 12409
		private int _extractinatorCount;

		// Token: 0x04003078 RID: 12408
		private int _sharpenerCount;

		// Token: 0x02000291 RID: 657
		private class BuildData
		{
			// Token: 0x060016CA RID: 5834 RVA: 0x004379BC File Offset: 0x00435BBC
			public static CaveHouseBiome.BuildData CreateDefaultData()
			{
				return new CaveHouseBiome.BuildData
				{
					Tile = 30,
					Wall = 27,
					PlatformStyle = 0,
					DoorStyle = 0,
					TableStyle = 0,
					WorkbenchStyle = 0,
					PianoStyle = 0,
					BookcaseStyle = 0,
					ChairStyle = 0,
					ChestStyle = 1,
					ProcessRoom = new CaveHouseBiome.BuildData.ProcessRoomMethod(CaveHouseBiome.AgeDefaultRoom)
				};
			}

			// Token: 0x060016C5 RID: 5829 RVA: 0x00437768 File Offset: 0x00435968
			public static CaveHouseBiome.BuildData CreateDesertData()
			{
				return new CaveHouseBiome.BuildData
				{
					Tile = 396,
					Wall = 187,
					PlatformStyle = 0,
					DoorStyle = 0,
					TableStyle = 0,
					WorkbenchStyle = 0,
					PianoStyle = 0,
					BookcaseStyle = 0,
					ChairStyle = 0,
					ChestStyle = 1,
					ProcessRoom = new CaveHouseBiome.BuildData.ProcessRoomMethod(CaveHouseBiome.AgeDesertRoom)
				};
			}

			// Token: 0x060016C7 RID: 5831 RVA: 0x0043784C File Offset: 0x00435A4C
			public static CaveHouseBiome.BuildData CreateGraniteData()
			{
				return new CaveHouseBiome.BuildData
				{
					Tile = 369,
					Wall = 181,
					PlatformStyle = 28,
					DoorStyle = 34,
					TableStyle = 33,
					WorkbenchStyle = 29,
					PianoStyle = 28,
					BookcaseStyle = 30,
					ChairStyle = 34,
					ChestStyle = 50,
					ProcessRoom = new CaveHouseBiome.BuildData.ProcessRoomMethod(CaveHouseBiome.AgeGraniteRoom)
				};
			}

			// Token: 0x060016C6 RID: 5830 RVA: 0x004377DC File Offset: 0x004359DC
			public static CaveHouseBiome.BuildData CreateJungleData()
			{
				return new CaveHouseBiome.BuildData
				{
					Tile = 158,
					Wall = 42,
					PlatformStyle = 2,
					DoorStyle = 2,
					TableStyle = 2,
					WorkbenchStyle = 2,
					PianoStyle = 2,
					BookcaseStyle = 12,
					ChairStyle = 3,
					ChestStyle = 8,
					ProcessRoom = new CaveHouseBiome.BuildData.ProcessRoomMethod(CaveHouseBiome.AgeJungleRoom)
				};
			}

			// Token: 0x060016C8 RID: 5832 RVA: 0x004378C8 File Offset: 0x00435AC8
			public static CaveHouseBiome.BuildData CreateMarbleData()
			{
				return new CaveHouseBiome.BuildData
				{
					Tile = 357,
					Wall = 179,
					PlatformStyle = 29,
					DoorStyle = 35,
					TableStyle = 34,
					WorkbenchStyle = 30,
					PianoStyle = 29,
					BookcaseStyle = 31,
					ChairStyle = 35,
					ChestStyle = 51,
					ProcessRoom = new CaveHouseBiome.BuildData.ProcessRoomMethod(CaveHouseBiome.AgeMarbleRoom)
				};
			}

			// Token: 0x060016C9 RID: 5833 RVA: 0x00437944 File Offset: 0x00435B44
			public static CaveHouseBiome.BuildData CreateMushroomData()
			{
				return new CaveHouseBiome.BuildData
				{
					Tile = 190,
					Wall = 74,
					PlatformStyle = 18,
					DoorStyle = 6,
					TableStyle = 27,
					WorkbenchStyle = 7,
					PianoStyle = 22,
					BookcaseStyle = 24,
					ChairStyle = 9,
					ChestStyle = 32,
					ProcessRoom = new CaveHouseBiome.BuildData.ProcessRoomMethod(CaveHouseBiome.AgeMushroomRoom)
				};
			}

			// Token: 0x060016C4 RID: 5828 RVA: 0x004376EC File Offset: 0x004358EC
			public static CaveHouseBiome.BuildData CreateSnowData()
			{
				return new CaveHouseBiome.BuildData
				{
					Tile = 321,
					Wall = 149,
					DoorStyle = 30,
					PlatformStyle = 19,
					TableStyle = 28,
					WorkbenchStyle = 23,
					PianoStyle = 23,
					BookcaseStyle = 25,
					ChairStyle = 30,
					ChestStyle = 11,
					ProcessRoom = new CaveHouseBiome.BuildData.ProcessRoomMethod(CaveHouseBiome.AgeSnowRoom)
				};
			}

			// Token: 0x04003CA9 RID: 15529
			public int BookcaseStyle;

			// Token: 0x04003CAA RID: 15530
			public int ChairStyle;

			// Token: 0x04003CAB RID: 15531
			public int ChestStyle;

			// Token: 0x04003C9D RID: 15517
			public static CaveHouseBiome.BuildData Default = CaveHouseBiome.BuildData.CreateDefaultData();

			// Token: 0x04003CA1 RID: 15521
			public static CaveHouseBiome.BuildData Desert = CaveHouseBiome.BuildData.CreateDesertData();

			// Token: 0x04003CA5 RID: 15525
			public int DoorStyle;

			// Token: 0x04003C9E RID: 15518
			public static CaveHouseBiome.BuildData Granite = CaveHouseBiome.BuildData.CreateGraniteData();

			// Token: 0x04003C9C RID: 15516
			public static CaveHouseBiome.BuildData Jungle = CaveHouseBiome.BuildData.CreateJungleData();

			// Token: 0x04003C9F RID: 15519
			public static CaveHouseBiome.BuildData Marble = CaveHouseBiome.BuildData.CreateMarbleData();

			// Token: 0x04003CA0 RID: 15520
			public static CaveHouseBiome.BuildData Mushroom = CaveHouseBiome.BuildData.CreateMushroomData();

			// Token: 0x04003CA8 RID: 15528
			public int PianoStyle;

			// Token: 0x04003CA4 RID: 15524
			public int PlatformStyle;

			// Token: 0x04003CAC RID: 15532
			public CaveHouseBiome.BuildData.ProcessRoomMethod ProcessRoom;

			// Token: 0x04003C9B RID: 15515
			public static CaveHouseBiome.BuildData Snow = CaveHouseBiome.BuildData.CreateSnowData();

			// Token: 0x04003CA6 RID: 15526
			public int TableStyle;

			// Token: 0x04003CA2 RID: 15522
			public ushort Tile;

			// Token: 0x04003CA3 RID: 15523
			public byte Wall;

			// Token: 0x04003CA7 RID: 15527
			public int WorkbenchStyle;

			// Token: 0x02000334 RID: 820
			// Token: 0x06001871 RID: 6257
			public delegate void ProcessRoomMethod(Rectangle room);
		}
	}
}

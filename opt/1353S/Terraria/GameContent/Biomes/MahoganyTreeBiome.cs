﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
	// Token: 0x0200012A RID: 298
	public class MahoganyTreeBiome : MicroBiome
	{
		// Token: 0x06000FD2 RID: 4050 RVA: 0x003FBA94 File Offset: 0x003F9C94
		public override bool Place(Point origin, StructureMap structures)
		{
			Point point;
			if (!WorldUtils.Find(new Point(origin.X - 3, origin.Y), Searches.Chain(new Searches.Down(200), new GenCondition[]
			{
				new Conditions.IsSolid().AreaAnd(6, 1)
			}), out point))
			{
				return false;
			}
			Point point2;
			if (!WorldUtils.Find(new Point(point.X, point.Y - 5), Searches.Chain(new Searches.Up(120), new GenCondition[]
			{
				new Conditions.IsSolid().AreaOr(6, 1)
			}), out point2) || point.Y - 5 - point2.Y > 60)
			{
				return false;
			}
			if (point.Y - point2.Y < 30)
			{
				return false;
			}
			if (!structures.CanPlace(new Rectangle(point.X - 30, point.Y - 60, 60, 90), 0))
			{
				return false;
			}
			Dictionary<ushort, int> dictionary = new Dictionary<ushort, int>();
			WorldUtils.Gen(new Point(point.X - 25, point.Y - 25), new Shapes.Rectangle(50, 50), new Actions.TileScanner(new ushort[]
			{
				0,
				59,
				147,
				1
			}).Output(dictionary));
			int num = dictionary[0] + dictionary[1];
			int num2 = dictionary[59];
			if (dictionary[147] > num2 || num > num2 || num2 < 50)
			{
				return false;
			}
			int num3 = (point.Y - point2.Y - 9) / 5;
			int num4 = num3 * 5;
			int num5 = 0;
			double num6 = GenBase._random.NextDouble() + 1.0;
			double num7 = GenBase._random.NextDouble() + 2.0;
			if (GenBase._random.Next(2) == 0)
			{
				num7 = -num7;
			}
			for (int i = 0; i < num3; i++)
			{
				int num8 = (int)(Math.Sin((double)(i + 1) / 12.0 * num6 * 3.1415927410125732) * num7);
				int num9 = (num8 < num5) ? (num8 - num5) : 0;
				WorldUtils.Gen(new Point(point.X + num5 + num9, point.Y - (i + 1) * 5), new Shapes.Rectangle(6 + Math.Abs(num8 - num5), 7), Actions.Chain(new GenAction[]
				{
					new Actions.RemoveWall(),
					new Actions.SetTile(383, false, true),
					new Actions.SetFrames(false)
				}));
				WorldUtils.Gen(new Point(point.X + num5 + num9 + 2, point.Y - (i + 1) * 5), new Shapes.Rectangle(2 + Math.Abs(num8 - num5), 5), Actions.Chain(new GenAction[]
				{
					new Actions.ClearTile(true),
					new Actions.PlaceWall(78, true)
				}));
				WorldUtils.Gen(new Point(point.X + num5 + 2, point.Y - i * 5), new Shapes.Rectangle(2, 2), Actions.Chain(new GenAction[]
				{
					new Actions.ClearTile(true),
					new Actions.PlaceWall(78, true)
				}));
				num5 = num8;
			}
			int num10 = 6;
			if (num7 < 0.0)
			{
				num10 = 0;
			}
			List<Point> list = new List<Point>();
			for (int j = 0; j < 2; j++)
			{
				double num11 = ((double)j + 1.0) / 3.0;
				int num12 = num10 + (int)(Math.Sin((double)num3 * num11 / 12.0 * num6 * 3.1415927410125732) * num7);
				double num13 = GenBase._random.NextDouble() * 0.78539818525314331 - 0.78539818525314331 - 0.20000000298023224;
				if (num10 == 0)
				{
					num13 -= 1.5707963705062866;
				}
				WorldUtils.Gen(new Point(point.X + num12, point.Y - (int)((double)(num3 * 5) * num11)), new ShapeBranch(num13, (double)GenBase._random.Next(12, 16)).OutputEndpoints(list), Actions.Chain(new GenAction[]
				{
					new Actions.SetTile(383, false, true),
					new Actions.SetFrames(true)
				}));
				num10 = 6 - num10;
			}
			int num14 = (int)(Math.Sin((double)num3 / 12.0 * num6 * 3.1415927410125732) * num7);
			WorldUtils.Gen(new Point(point.X + 6 + num14, point.Y - num4), new ShapeBranch(-0.68539818525314333, (double)GenBase._random.Next(16, 22)).OutputEndpoints(list), Actions.Chain(new GenAction[]
			{
				new Actions.SetTile(383, false, true),
				new Actions.SetFrames(true)
			}));
			WorldUtils.Gen(new Point(point.X + num14, point.Y - num4), new ShapeBranch(-2.4561944961547852, (double)GenBase._random.Next(16, 22)).OutputEndpoints(list), Actions.Chain(new GenAction[]
			{
				new Actions.SetTile(383, false, true),
				new Actions.SetFrames(true)
			}));
			using (List<Point>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					WorldUtils.Gen(enumerator.Current, new Shapes.Circle(4), Actions.Chain(new GenAction[]
					{
						new Modifiers.Blotches(4, 2, 0.3),
						new Modifiers.SkipTiles(new ushort[]
						{
							383
						}),
						new Modifiers.SkipWalls(new byte[]
						{
							78
						}),
						new Actions.SetTile(384, false, true),
						new Actions.SetFrames(true)
					}));
				}
			}
			for (int k = 0; k < 4; k++)
			{
				float angle = (float)k / 3f * 2f + 0.57075f;
				WorldUtils.Gen(point, new ShapeRoot(angle, (float)GenBase._random.Next(40, 60), 4f, 1f), new Actions.SetTile(383, true, true));
			}
			WorldGen.AddBuriedChest(point.X + 3, point.Y - 1, (GenBase._random.Next(4) == 0) ? 0 : WorldGen.GetNextJungleChestItem(), false, 10);
			structures.AddStructure(new Rectangle(point.X - 30, point.Y - 30, 60, 60), 0);
			return true;
		}
	}
}

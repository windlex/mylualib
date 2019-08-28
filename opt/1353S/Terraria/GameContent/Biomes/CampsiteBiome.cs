using System;
using Microsoft.Xna.Framework;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
	// Token: 0x02000124 RID: 292
	public class CampsiteBiome : MicroBiome
	{
		// Token: 0x06000FB3 RID: 4019 RVA: 0x003F7BAC File Offset: 0x003F5DAC
		public override bool Place(Point origin, StructureMap structures)
		{
			Ref<int> @ref = new Ref<int>(0);
			Ref<int> ref2 = new Ref<int>(0);
			WorldUtils.Gen(origin, new Shapes.Circle(10), Actions.Chain(new GenAction[]
			{
				new Actions.Scanner(ref2),
				new Modifiers.IsSolid(),
				new Actions.Scanner(@ref)
			}));
			if (@ref.Value < ref2.Value - 5)
			{
				return false;
			}
			int num = GenBase._random.Next(6, 10);
			int num2 = GenBase._random.Next(5);
			if (!structures.CanPlace(new Rectangle(origin.X - num, origin.Y - num, num * 2, num * 2), 0))
			{
				return false;
			}
			ShapeData data = new ShapeData();
			WorldUtils.Gen(origin, new Shapes.Slime(num), Actions.Chain(new GenAction[]
			{
				new Modifiers.Blotches(num2, num2, num2, 1, 0.3).Output(data),
				new Modifiers.Offset(0, -2),
				new Modifiers.OnlyTiles(new ushort[]
				{
					53
				}),
				new Actions.SetTile(397, true, true),
				new Modifiers.OnlyWalls(new byte[1]),
				new Actions.PlaceWall(16, true)
			}));
			WorldUtils.Gen(origin, new ModShapes.All(data), Actions.Chain(new GenAction[]
			{
				new Actions.ClearTile(false),
				new Actions.SetLiquid(0, 0),
				new Actions.SetFrames(true),
				new Modifiers.OnlyWalls(new byte[1]),
				new Actions.PlaceWall(16, true)
			}));
			Point point;
			if (!WorldUtils.Find(origin, Searches.Chain(new Searches.Down(10), new GenCondition[]
			{
				new Conditions.IsSolid()
			}), out point))
			{
				return false;
			}
			int num3 = point.Y - 1;
			bool flag = GenBase._random.Next() % 2 == 0;
			if (GenBase._random.Next() % 10 != 0)
			{
				int num4 = GenBase._random.Next(1, 4);
				int num5 = flag ? 4 : (-(num >> 1));
				for (int i = 0; i < num4; i++)
				{
					int num6 = GenBase._random.Next(1, 3);
					for (int j = 0; j < num6; j++)
					{
						WorldGen.PlaceTile(origin.X + num5 - i, num3 - j, 331, false, false, -1, 0);
					}
				}
			}
			int num7 = (num - 3) * (flag ? -1 : 1);
			if (GenBase._random.Next() % 10 != 0)
			{
				WorldGen.PlaceTile(origin.X + num7, num3, 186, false, false, -1, 0);
			}
			if (GenBase._random.Next() % 10 != 0)
			{
				WorldGen.PlaceTile(origin.X, num3, 215, true, false, -1, 0);
				if (GenBase._tiles[origin.X, num3].active() && GenBase._tiles[origin.X, num3].type == 215)
				{
					Tile expr_2CD = GenBase._tiles[origin.X, num3];
					expr_2CD.frameY += 36;
					Tile expr_2F0 = GenBase._tiles[origin.X - 1, num3];
					expr_2F0.frameY += 36;
					Tile expr_313 = GenBase._tiles[origin.X + 1, num3];
					expr_313.frameY += 36;
					Tile expr_336 = GenBase._tiles[origin.X, num3 - 1];
					expr_336.frameY += 36;
					Tile expr_35B = GenBase._tiles[origin.X - 1, num3 - 1];
					expr_35B.frameY += 36;
					Tile expr_380 = GenBase._tiles[origin.X + 1, num3 - 1];
					expr_380.frameY += 36;
				}
			}
			structures.AddStructure(new Rectangle(origin.X - num, origin.Y - num, num * 2, num * 2), 4);
			return true;
		}
	}
}

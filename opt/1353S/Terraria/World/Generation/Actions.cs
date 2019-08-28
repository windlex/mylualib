using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.World.Generation
{
	// Token: 0x02000048 RID: 72
	public static class Actions
	{
		// Token: 0x06000905 RID: 2309 RVA: 0x003B4FE4 File Offset: 0x003B31E4
		public static GenAction Chain(params GenAction[] actions)
		{
			for (int i = 0; i < actions.Length - 1; i++)
			{
				actions[i].NextAction = actions[i + 1];
			}
			return actions[0];
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x003B5014 File Offset: 0x003B3214
		public static GenAction Continue(GenAction action)
		{
			return new Actions.ContinueWrapper(action);
		}

		// Token: 0x020001E0 RID: 480
		public class ContinueWrapper : GenAction
		{
			// Token: 0x060014D2 RID: 5330 RVA: 0x0042E83C File Offset: 0x0042CA3C
			public ContinueWrapper(GenAction action)
			{
				this._action = action;
			}

			// Token: 0x060014D3 RID: 5331 RVA: 0x0042E84C File Offset: 0x0042CA4C
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				this._action.Apply(origin, x, y, args);
				return base.UnitApply(origin, x, y, args);
			}

			// Token: 0x04003731 RID: 14129
			private GenAction _action;
		}

		// Token: 0x020001E1 RID: 481
		public class Count : GenAction
		{
			// Token: 0x060014D4 RID: 5332 RVA: 0x0042E86C File Offset: 0x0042CA6C
			public Count(Ref<int> count)
			{
				this._count = count;
			}

			// Token: 0x060014D5 RID: 5333 RVA: 0x0042E87C File Offset: 0x0042CA7C
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				this._count.Value++;
				return base.UnitApply(origin, x, y, args);
			}

			// Token: 0x04003732 RID: 14130
			private Ref<int> _count;
		}

		// Token: 0x020001E2 RID: 482
		public class Scanner : GenAction
		{
			// Token: 0x060014D6 RID: 5334 RVA: 0x0042E89C File Offset: 0x0042CA9C
			public Scanner(Ref<int> count)
			{
				this._count = count;
			}

			// Token: 0x060014D7 RID: 5335 RVA: 0x0042E8AC File Offset: 0x0042CAAC
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				this._count.Value++;
				return base.UnitApply(origin, x, y, args);
			}

			// Token: 0x04003733 RID: 14131
			private Ref<int> _count;
		}

		// Token: 0x020001E3 RID: 483
		public class TileScanner : GenAction
		{
			// Token: 0x060014D8 RID: 5336 RVA: 0x0042E8CC File Offset: 0x0042CACC
			public TileScanner(params ushort[] tiles)
			{
				this._tileIds = tiles;
				this._tileCounts = new Dictionary<ushort, int>();
				for (int i = 0; i < tiles.Length; i++)
				{
					this._tileCounts[this._tileIds[i]] = 0;
				}
			}

			// Token: 0x060014D9 RID: 5337 RVA: 0x0042E914 File Offset: 0x0042CB14
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				Tile tile = GenBase._tiles[x, y];
				if (tile.active() && this._tileCounts.ContainsKey(tile.type))
				{
					Dictionary<ushort, int> arg_35_0 = this._tileCounts;
					ushort type = tile.type;
					int num = arg_35_0[type];
					arg_35_0[type] = num + 1;
				}
				return base.UnitApply(origin, x, y, args);
			}

			// Token: 0x060014DA RID: 5338 RVA: 0x0042E974 File Offset: 0x0042CB74
			public Actions.TileScanner Output(Dictionary<ushort, int> resultsOutput)
			{
				this._tileCounts = resultsOutput;
				for (int i = 0; i < this._tileIds.Length; i++)
				{
					if (!this._tileCounts.ContainsKey(this._tileIds[i]))
					{
						this._tileCounts[this._tileIds[i]] = 0;
					}
				}
				return this;
			}

			// Token: 0x060014DB RID: 5339 RVA: 0x0042E9C8 File Offset: 0x0042CBC8
			public Dictionary<ushort, int> GetResults()
			{
				return this._tileCounts;
			}

			// Token: 0x060014DC RID: 5340 RVA: 0x0042E9D0 File Offset: 0x0042CBD0
			public int GetCount(ushort tileId)
			{
				if (!this._tileCounts.ContainsKey(tileId))
				{
					return -1;
				}
				return this._tileCounts[tileId];
			}

			// Token: 0x04003734 RID: 14132
			private ushort[] _tileIds;

			// Token: 0x04003735 RID: 14133
			private Dictionary<ushort, int> _tileCounts;
		}

		// Token: 0x020001E4 RID: 484
		public class Blank : GenAction
		{
			// Token: 0x060014DD RID: 5341 RVA: 0x0042E9F0 File Offset: 0x0042CBF0
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				return base.UnitApply(origin, x, y, args);
			}
		}

		// Token: 0x020001E5 RID: 485
		public class Custom : GenAction
		{
			// Token: 0x060014DF RID: 5343 RVA: 0x0042EA08 File Offset: 0x0042CC08
			public Custom(GenBase.CustomPerUnitAction perUnit)
			{
				this._perUnit = perUnit;
			}

			// Token: 0x060014E0 RID: 5344 RVA: 0x0042EA18 File Offset: 0x0042CC18
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				return this._perUnit(x, y, args) | base.UnitApply(origin, x, y, args);
			}

			// Token: 0x04003736 RID: 14134
			private GenBase.CustomPerUnitAction _perUnit;
		}

		// Token: 0x020001E6 RID: 486
		public class ClearMetadata : GenAction
		{
			// Token: 0x060014E1 RID: 5345 RVA: 0x0042EA38 File Offset: 0x0042CC38
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				GenBase._tiles[x, y].ClearMetadata();
				return base.UnitApply(origin, x, y, args);
			}
		}

		// Token: 0x020001E7 RID: 487
		public class Clear : GenAction
		{
			// Token: 0x060014E3 RID: 5347 RVA: 0x0042EA60 File Offset: 0x0042CC60
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				GenBase._tiles[x, y].ClearEverything();
				return base.UnitApply(origin, x, y, args);
			}
		}

		// Token: 0x020001E8 RID: 488
		public class ClearTile : GenAction
		{
			// Token: 0x060014E5 RID: 5349 RVA: 0x0042EA88 File Offset: 0x0042CC88
			public ClearTile(bool frameNeighbors = false)
			{
				this._frameNeighbors = frameNeighbors;
			}

			// Token: 0x060014E6 RID: 5350 RVA: 0x0042EA98 File Offset: 0x0042CC98
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				WorldUtils.ClearTile(x, y, this._frameNeighbors);
				return base.UnitApply(origin, x, y, args);
			}

			// Token: 0x04003737 RID: 14135
			private bool _frameNeighbors;
		}

		// Token: 0x020001E9 RID: 489
		public class ClearWall : GenAction
		{
			// Token: 0x060014E7 RID: 5351 RVA: 0x0042EAB4 File Offset: 0x0042CCB4
			public ClearWall(bool frameNeighbors = false)
			{
				this._frameNeighbors = frameNeighbors;
			}

			// Token: 0x060014E8 RID: 5352 RVA: 0x0042EAC4 File Offset: 0x0042CCC4
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				WorldUtils.ClearWall(x, y, this._frameNeighbors);
				return base.UnitApply(origin, x, y, args);
			}

			// Token: 0x04003738 RID: 14136
			private bool _frameNeighbors;
		}

		// Token: 0x020001EA RID: 490
		public class HalfBlock : GenAction
		{
			// Token: 0x060014E9 RID: 5353 RVA: 0x0042EAE0 File Offset: 0x0042CCE0
			public HalfBlock(bool value = true)
			{
				this._value = value;
			}

			// Token: 0x060014EA RID: 5354 RVA: 0x0042EAF0 File Offset: 0x0042CCF0
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				GenBase._tiles[x, y].halfBrick(this._value);
				return base.UnitApply(origin, x, y, args);
			}

			// Token: 0x04003739 RID: 14137
			private bool _value;
		}

		// Token: 0x020001EB RID: 491
		public class SetTile : GenAction
		{
			// Token: 0x060014EB RID: 5355 RVA: 0x0042EB14 File Offset: 0x0042CD14
			public SetTile(ushort type, bool setSelfFrames = false, bool setNeighborFrames = true)
			{
				this._type = type;
				this._doFraming = setSelfFrames;
				this._doNeighborFraming = setNeighborFrames;
			}

			// Token: 0x060014EC RID: 5356 RVA: 0x0042EB34 File Offset: 0x0042CD34
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				GenBase._tiles[x, y].ResetToType(this._type);
				if (this._doFraming)
				{
					WorldUtils.TileFrame(x, y, this._doNeighborFraming);
				}
				return base.UnitApply(origin, x, y, args);
			}

			// Token: 0x0400373A RID: 14138
			private ushort _type;

			// Token: 0x0400373B RID: 14139
			private bool _doFraming;

			// Token: 0x0400373C RID: 14140
			private bool _doNeighborFraming;
		}

		// Token: 0x020001EC RID: 492
		public class DebugDraw : GenAction
		{
			// Token: 0x060014ED RID: 5357 RVA: 0x0042EB70 File Offset: 0x0042CD70
			public DebugDraw(SpriteBatch spriteBatch, Color color = default(Color))
			{
				this._spriteBatch = spriteBatch;
				this._color = color;
			}

			// Token: 0x060014EE RID: 5358 RVA: 0x0042EB88 File Offset: 0x0042CD88
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				this._spriteBatch.Draw(Main.magicPixel, new Rectangle((x << 4) - (int)Main.screenPosition.X, (y << 4) - (int)Main.screenPosition.Y, 16, 16), this._color);
				return base.UnitApply(origin, x, y, args);
			}

			// Token: 0x0400373D RID: 14141
			private Color _color;

			// Token: 0x0400373E RID: 14142
			private SpriteBatch _spriteBatch;
		}

		// Token: 0x020001ED RID: 493
		public class SetSlope : GenAction
		{
			// Token: 0x060014EF RID: 5359 RVA: 0x0042EBE0 File Offset: 0x0042CDE0
			public SetSlope(int slope)
			{
				this._slope = slope;
			}

			// Token: 0x060014F0 RID: 5360 RVA: 0x0042EBF0 File Offset: 0x0042CDF0
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				WorldGen.SlopeTile(x, y, this._slope);
				return base.UnitApply(origin, x, y, args);
			}

			// Token: 0x0400373F RID: 14143
			private int _slope;
		}

		// Token: 0x020001EE RID: 494
		public class SetHalfTile : GenAction
		{
			// Token: 0x060014F1 RID: 5361 RVA: 0x0042EC0C File Offset: 0x0042CE0C
			public SetHalfTile(bool halfTile)
			{
				this._halfTile = halfTile;
			}

			// Token: 0x060014F2 RID: 5362 RVA: 0x0042EC1C File Offset: 0x0042CE1C
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				GenBase._tiles[x, y].halfBrick(this._halfTile);
				return base.UnitApply(origin, x, y, args);
			}

			// Token: 0x04003740 RID: 14144
			private bool _halfTile;
		}

		// Token: 0x020001EF RID: 495
		public class PlaceTile : GenAction
		{
			// Token: 0x060014F3 RID: 5363 RVA: 0x0042EC40 File Offset: 0x0042CE40
			public PlaceTile(ushort type, int style = 0)
			{
				this._type = type;
				this._style = style;
			}

			// Token: 0x060014F4 RID: 5364 RVA: 0x0042EC58 File Offset: 0x0042CE58
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				WorldGen.PlaceTile(x, y, (int)this._type, true, false, -1, this._style);
				return base.UnitApply(origin, x, y, args);
			}

			// Token: 0x04003741 RID: 14145
			private ushort _type;

			// Token: 0x04003742 RID: 14146
			private int _style;
		}

		// Token: 0x020001F0 RID: 496
		public class RemoveWall : GenAction
		{
			// Token: 0x060014F5 RID: 5365 RVA: 0x0042EC7C File Offset: 0x0042CE7C
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				GenBase._tiles[x, y].wall = 0;
				return base.UnitApply(origin, x, y, args);
			}
		}

		// Token: 0x020001F1 RID: 497
		public class PlaceWall : GenAction
		{
			// Token: 0x060014F7 RID: 5367 RVA: 0x0042ECA4 File Offset: 0x0042CEA4
			public PlaceWall(byte type, bool neighbors = true)
			{
				this._type = type;
				this._neighbors = neighbors;
			}

			// Token: 0x060014F8 RID: 5368 RVA: 0x0042ECBC File Offset: 0x0042CEBC
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				GenBase._tiles[x, y].wall = this._type;
				WorldGen.SquareWallFrame(x, y, true);
				if (this._neighbors)
				{
					WorldGen.SquareWallFrame(x + 1, y, true);
					WorldGen.SquareWallFrame(x - 1, y, true);
					WorldGen.SquareWallFrame(x, y - 1, true);
					WorldGen.SquareWallFrame(x, y + 1, true);
				}
				return base.UnitApply(origin, x, y, args);
			}

			// Token: 0x04003743 RID: 14147
			private byte _type;

			// Token: 0x04003744 RID: 14148
			private bool _neighbors;
		}

		// Token: 0x020001F2 RID: 498
		public class SetLiquid : GenAction
		{
			// Token: 0x060014F9 RID: 5369 RVA: 0x0042ED24 File Offset: 0x0042CF24
			public SetLiquid(int type = 0, byte value = 255)
			{
				this._value = value;
				this._type = type;
			}

			// Token: 0x060014FA RID: 5370 RVA: 0x0042ED3C File Offset: 0x0042CF3C
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				GenBase._tiles[x, y].liquidType(this._type);
				GenBase._tiles[x, y].liquid = this._value;
				return base.UnitApply(origin, x, y, args);
			}

			// Token: 0x04003745 RID: 14149
			private int _type;

			// Token: 0x04003746 RID: 14150
			private byte _value;
		}

		// Token: 0x020001F3 RID: 499
		public class SwapSolidTile : GenAction
		{
			// Token: 0x060014FB RID: 5371 RVA: 0x0042ED78 File Offset: 0x0042CF78
			public SwapSolidTile(ushort type)
			{
				this._type = type;
			}

			// Token: 0x060014FC RID: 5372 RVA: 0x0042ED88 File Offset: 0x0042CF88
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				Tile tile = GenBase._tiles[x, y];
				if (WorldGen.SolidTile(tile))
				{
					tile.ResetToType(this._type);
					return base.UnitApply(origin, x, y, args);
				}
				return base.Fail();
			}

			// Token: 0x04003747 RID: 14151
			private ushort _type;
		}

		// Token: 0x020001F4 RID: 500
		public class SetFrames : GenAction
		{
			// Token: 0x060014FD RID: 5373 RVA: 0x0042EDC8 File Offset: 0x0042CFC8
			public SetFrames(bool frameNeighbors = false)
			{
				this._frameNeighbors = frameNeighbors;
			}

			// Token: 0x060014FE RID: 5374 RVA: 0x0042EDD8 File Offset: 0x0042CFD8
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				WorldUtils.TileFrame(x, y, this._frameNeighbors);
				return base.UnitApply(origin, x, y, args);
			}

			// Token: 0x04003748 RID: 14152
			private bool _frameNeighbors;
		}

		// Token: 0x020001F5 RID: 501
		public class Smooth : GenAction
		{
			// Token: 0x060014FF RID: 5375 RVA: 0x0042EDF4 File Offset: 0x0042CFF4
			public Smooth(bool applyToNeighbors = false)
			{
				this._applyToNeighbors = applyToNeighbors;
			}

			// Token: 0x06001500 RID: 5376 RVA: 0x0042EE04 File Offset: 0x0042D004
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				Tile.SmoothSlope(x, y, this._applyToNeighbors);
				return base.UnitApply(origin, x, y, args);
			}

			// Token: 0x04003749 RID: 14153
			private bool _applyToNeighbors;
		}
	}
}

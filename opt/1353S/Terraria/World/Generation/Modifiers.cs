using System;
using Microsoft.Xna.Framework;

namespace Terraria.World.Generation
{
	// Token: 0x0200004D RID: 77
	public static class Modifiers
	{
		// Token: 0x020001FC RID: 508
		public class ShapeScale : GenAction
		{
			// Token: 0x0600150D RID: 5389 RVA: 0x0042EEFC File Offset: 0x0042D0FC
			public ShapeScale(int scale)
			{
				this._scale = scale;
			}

			// Token: 0x0600150E RID: 5390 RVA: 0x0042EF0C File Offset: 0x0042D10C
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				bool flag = false;
				for (int i = 0; i < this._scale; i++)
				{
					for (int j = 0; j < this._scale; j++)
					{
						flag |= !base.UnitApply(origin, (x - origin.X << 1) + i + origin.X, (y - origin.Y << 1) + j + origin.Y, new object[0]);
					}
				}
				return !flag;
			}

			// Token: 0x0400374F RID: 14159
			private int _scale;
		}

		// Token: 0x020001FD RID: 509
		public class Expand : GenAction
		{
			// Token: 0x0600150F RID: 5391 RVA: 0x0042EF7C File Offset: 0x0042D17C
			public Expand(int expansion)
			{
				this._xExpansion = expansion;
				this._yExpansion = expansion;
			}

			// Token: 0x06001510 RID: 5392 RVA: 0x0042EF94 File Offset: 0x0042D194
			public Expand(int xExpansion, int yExpansion)
			{
				this._xExpansion = xExpansion;
				this._yExpansion = yExpansion;
			}

			// Token: 0x06001511 RID: 5393 RVA: 0x0042EFAC File Offset: 0x0042D1AC
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				bool flag = false;
				for (int i = -this._xExpansion; i <= this._xExpansion; i++)
				{
					for (int j = -this._yExpansion; j <= this._yExpansion; j++)
					{
						flag |= !base.UnitApply(origin, x + i, y + j, args);
					}
				}
				return !flag;
			}

			// Token: 0x04003750 RID: 14160
			private int _xExpansion;

			// Token: 0x04003751 RID: 14161
			private int _yExpansion;
		}

		// Token: 0x020001FE RID: 510
		public class RadialDither : GenAction
		{
			// Token: 0x06001512 RID: 5394 RVA: 0x0042F004 File Offset: 0x0042D204
			public RadialDither(float innerRadius, float outerRadius)
			{
				this._innerRadius = innerRadius;
				this._outerRadius = outerRadius;
			}

			// Token: 0x06001513 RID: 5395 RVA: 0x0042F01C File Offset: 0x0042D21C
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				Vector2 value = new Vector2((float)origin.X, (float)origin.Y);
				float num = Vector2.Distance(new Vector2((float)x, (float)y), value);
				float num2 = Math.Max(0f, Math.Min(1f, (num - this._innerRadius) / (this._outerRadius - this._innerRadius)));
				if (GenBase._random.NextDouble() > (double)num2)
				{
					return base.UnitApply(origin, x, y, args);
				}
				return base.Fail();
			}

			// Token: 0x04003752 RID: 14162
			private float _innerRadius;

			// Token: 0x04003753 RID: 14163
			private float _outerRadius;
		}

		// Token: 0x020001FF RID: 511
		public class Blotches : GenAction
		{
			// Token: 0x06001514 RID: 5396 RVA: 0x0042F09C File Offset: 0x0042D29C
			public Blotches(int scale = 2, double chance = 0.3)
			{
				this._minX = scale;
				this._minY = scale;
				this._maxX = scale;
				this._maxY = scale;
				this._chance = chance;
			}

			// Token: 0x06001515 RID: 5397 RVA: 0x0042F0C8 File Offset: 0x0042D2C8
			public Blotches(int xScale, int yScale, double chance = 0.3)
			{
				this._minX = xScale;
				this._maxX = xScale;
				this._minY = yScale;
				this._maxY = yScale;
				this._chance = chance;
			}

			// Token: 0x06001516 RID: 5398 RVA: 0x0042F0F4 File Offset: 0x0042D2F4
			public Blotches(int leftScale, int upScale, int rightScale, int downScale, double chance = 0.3)
			{
				this._minX = leftScale;
				this._maxX = rightScale;
				this._minY = upScale;
				this._maxY = downScale;
				this._chance = chance;
			}

			// Token: 0x06001517 RID: 5399 RVA: 0x0042F124 File Offset: 0x0042D324
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				GenBase._random.NextDouble();
				if (GenBase._random.NextDouble() < this._chance)
				{
					bool flag = false;
					int arg_6D_0 = GenBase._random.Next(1 - this._minX, 1);
					int num = GenBase._random.Next(0, this._maxX);
					int num2 = GenBase._random.Next(1 - this._minY, 1);
					int num3 = GenBase._random.Next(0, this._maxY);
					for (int i = arg_6D_0; i <= num; i++)
					{
						for (int j = num2; j <= num3; j++)
						{
							flag |= !base.UnitApply(origin, x + i, y + j, args);
						}
					}
					return !flag;
				}
				return base.UnitApply(origin, x, y, args);
			}

			// Token: 0x04003754 RID: 14164
			private int _minX;

			// Token: 0x04003755 RID: 14165
			private int _minY;

			// Token: 0x04003756 RID: 14166
			private int _maxX;

			// Token: 0x04003757 RID: 14167
			private int _maxY;

			// Token: 0x04003758 RID: 14168
			private double _chance;
		}

		// Token: 0x02000200 RID: 512
		public class Conditions : GenAction
		{
			// Token: 0x06001518 RID: 5400 RVA: 0x0042F1E4 File Offset: 0x0042D3E4
			public Conditions(params GenCondition[] conditions)
			{
				this._conditions = conditions;
			}

			// Token: 0x06001519 RID: 5401 RVA: 0x0042F1F4 File Offset: 0x0042D3F4
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				bool flag = true;
				for (int i = 0; i < this._conditions.Length; i++)
				{
					flag &= this._conditions[i].IsValid(x, y);
				}
				if (flag)
				{
					return base.UnitApply(origin, x, y, args);
				}
				return base.Fail();
			}

			// Token: 0x04003759 RID: 14169
			private GenCondition[] _conditions;
		}

		// Token: 0x02000201 RID: 513
		public class OnlyWalls : GenAction
		{
			// Token: 0x0600151A RID: 5402 RVA: 0x0042F240 File Offset: 0x0042D440
			public OnlyWalls(params byte[] types)
			{
				this._types = types;
			}

			// Token: 0x0600151B RID: 5403 RVA: 0x0042F250 File Offset: 0x0042D450
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				for (int i = 0; i < this._types.Length; i++)
				{
					if (GenBase._tiles[x, y].wall == this._types[i])
					{
						return base.UnitApply(origin, x, y, args);
					}
				}
				return base.Fail();
			}

			// Token: 0x0400375A RID: 14170
			private byte[] _types;
		}

		// Token: 0x02000202 RID: 514
		public class OnlyTiles : GenAction
		{
			// Token: 0x0600151C RID: 5404 RVA: 0x0042F2A0 File Offset: 0x0042D4A0
			public OnlyTiles(params ushort[] types)
			{
				this._types = types;
			}

			// Token: 0x0600151D RID: 5405 RVA: 0x0042F2B0 File Offset: 0x0042D4B0
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				if (!GenBase._tiles[x, y].active())
				{
					return base.Fail();
				}
				for (int i = 0; i < this._types.Length; i++)
				{
					if (GenBase._tiles[x, y].type == this._types[i])
					{
						return base.UnitApply(origin, x, y, args);
					}
				}
				return base.Fail();
			}

			// Token: 0x0400375B RID: 14171
			private ushort[] _types;
		}

		// Token: 0x02000203 RID: 515
		public class IsTouching : GenAction
		{
			// Token: 0x0600151E RID: 5406 RVA: 0x0042F318 File Offset: 0x0042D518
			public IsTouching(bool useDiagonals, params ushort[] tileIds)
			{
				this._useDiagonals = useDiagonals;
				this._tileIds = tileIds;
			}

			// Token: 0x0600151F RID: 5407 RVA: 0x0042F330 File Offset: 0x0042D530
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				int num = this._useDiagonals ? 16 : 8;
				for (int i = 0; i < num; i += 2)
				{
					Tile tile = GenBase._tiles[x + Modifiers.IsTouching.DIRECTIONS[i], y + Modifiers.IsTouching.DIRECTIONS[i + 1]];
					if (tile.active())
					{
						for (int j = 0; j < this._tileIds.Length; j++)
						{
							if (tile.type == this._tileIds[j])
							{
								return base.UnitApply(origin, x, y, args);
							}
						}
					}
				}
				return base.Fail();
			}

			// Token: 0x0400375C RID: 14172
			private static readonly int[] DIRECTIONS = new int[]
			{
				0,
				-1,
				1,
				0,
				-1,
				0,
				0,
				1,
				-1,
				-1,
				1,
				-1,
				-1,
				1,
				1,
				1
			};

			// Token: 0x0400375D RID: 14173
			private bool _useDiagonals;

			// Token: 0x0400375E RID: 14174
			private ushort[] _tileIds;
		}

		// Token: 0x02000204 RID: 516
		public class NotTouching : GenAction
		{
			// Token: 0x06001521 RID: 5409 RVA: 0x0042F3D0 File Offset: 0x0042D5D0
			public NotTouching(bool useDiagonals, params ushort[] tileIds)
			{
				this._useDiagonals = useDiagonals;
				this._tileIds = tileIds;
			}

			// Token: 0x06001522 RID: 5410 RVA: 0x0042F3E8 File Offset: 0x0042D5E8
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				int num = this._useDiagonals ? 16 : 8;
				for (int i = 0; i < num; i += 2)
				{
					Tile tile = GenBase._tiles[x + Modifiers.NotTouching.DIRECTIONS[i], y + Modifiers.NotTouching.DIRECTIONS[i + 1]];
					if (tile.active())
					{
						for (int j = 0; j < this._tileIds.Length; j++)
						{
							if (tile.type == this._tileIds[j])
							{
								return base.Fail();
							}
						}
					}
				}
				return base.UnitApply(origin, x, y, args);
			}

			// Token: 0x0400375F RID: 14175
			private static readonly int[] DIRECTIONS = new int[]
			{
				0,
				-1,
				1,
				0,
				-1,
				0,
				0,
				1,
				-1,
				-1,
				1,
				-1,
				-1,
				1,
				1,
				1
			};

			// Token: 0x04003760 RID: 14176
			private bool _useDiagonals;

			// Token: 0x04003761 RID: 14177
			private ushort[] _tileIds;
		}

		// Token: 0x02000205 RID: 517
		public class IsTouchingAir : GenAction
		{
			// Token: 0x06001524 RID: 5412 RVA: 0x0042F488 File Offset: 0x0042D688
			public IsTouchingAir(bool useDiagonals = false)
			{
				this._useDiagonals = useDiagonals;
			}

			// Token: 0x06001525 RID: 5413 RVA: 0x0042F498 File Offset: 0x0042D698
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				int num = this._useDiagonals ? 16 : 8;
				for (int i = 0; i < num; i += 2)
				{
					if (!GenBase._tiles[x + Modifiers.IsTouchingAir.DIRECTIONS[i], y + Modifiers.IsTouchingAir.DIRECTIONS[i + 1]].active())
					{
						return base.UnitApply(origin, x, y, args);
					}
				}
				return base.Fail();
			}

			// Token: 0x04003762 RID: 14178
			private static readonly int[] DIRECTIONS = new int[]
			{
				0,
				-1,
				1,
				0,
				-1,
				0,
				0,
				1,
				-1,
				-1,
				1,
				-1,
				-1,
				1,
				1,
				1
			};

			// Token: 0x04003763 RID: 14179
			private bool _useDiagonals;
		}

		// Token: 0x02000206 RID: 518
		public class SkipTiles : GenAction
		{
			// Token: 0x06001527 RID: 5415 RVA: 0x0042F514 File Offset: 0x0042D714
			public SkipTiles(params ushort[] types)
			{
				this._types = types;
			}

			// Token: 0x06001528 RID: 5416 RVA: 0x0042F524 File Offset: 0x0042D724
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				if (!GenBase._tiles[x, y].active())
				{
					return base.UnitApply(origin, x, y, args);
				}
				for (int i = 0; i < this._types.Length; i++)
				{
					if (GenBase._tiles[x, y].type == this._types[i])
					{
						return base.Fail();
					}
				}
				return base.UnitApply(origin, x, y, args);
			}

			// Token: 0x04003764 RID: 14180
			private ushort[] _types;
		}

		// Token: 0x02000207 RID: 519
		public class HasLiquid : GenAction
		{
			// Token: 0x06001529 RID: 5417 RVA: 0x0042F590 File Offset: 0x0042D790
			public HasLiquid(int liquidLevel = -1, int liquidType = -1)
			{
				this._liquidLevel = liquidLevel;
				this._liquidType = liquidType;
			}

			// Token: 0x0600152A RID: 5418 RVA: 0x0042F5A8 File Offset: 0x0042D7A8
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				Tile tile = GenBase._tiles[x, y];
				if ((this._liquidType == -1 || this._liquidType == (int)tile.liquidType()) && ((this._liquidLevel == -1 && tile.liquid != 0) || this._liquidLevel == (int)tile.liquid))
				{
					return base.UnitApply(origin, x, y, args);
				}
				return base.Fail();
			}

			// Token: 0x04003765 RID: 14181
			private int _liquidType;

			// Token: 0x04003766 RID: 14182
			private int _liquidLevel;
		}

		// Token: 0x02000208 RID: 520
		public class SkipWalls : GenAction
		{
			// Token: 0x0600152B RID: 5419 RVA: 0x0042F60C File Offset: 0x0042D80C
			public SkipWalls(params byte[] types)
			{
				this._types = types;
			}

			// Token: 0x0600152C RID: 5420 RVA: 0x0042F61C File Offset: 0x0042D81C
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				for (int i = 0; i < this._types.Length; i++)
				{
					if (GenBase._tiles[x, y].wall == this._types[i])
					{
						return base.Fail();
					}
				}
				return base.UnitApply(origin, x, y, args);
			}

			// Token: 0x04003767 RID: 14183
			private byte[] _types;
		}

		// Token: 0x02000209 RID: 521
		public class IsEmpty : GenAction
		{
			// Token: 0x0600152D RID: 5421 RVA: 0x0042F66C File Offset: 0x0042D86C
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				if (!GenBase._tiles[x, y].active())
				{
					return base.UnitApply(origin, x, y, args);
				}
				return base.Fail();
			}
		}

		// Token: 0x0200020A RID: 522
		public class IsSolid : GenAction
		{
			// Token: 0x0600152F RID: 5423 RVA: 0x0042F69C File Offset: 0x0042D89C
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				if (GenBase._tiles[x, y].active() && WorldGen.SolidTile(x, y))
				{
					return base.UnitApply(origin, x, y, args);
				}
				return base.Fail();
			}
		}

		// Token: 0x0200020B RID: 523
		public class IsNotSolid : GenAction
		{
			// Token: 0x06001531 RID: 5425 RVA: 0x0042F6D4 File Offset: 0x0042D8D4
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				if (!GenBase._tiles[x, y].active() || !WorldGen.SolidTile(x, y))
				{
					return base.UnitApply(origin, x, y, args);
				}
				return base.Fail();
			}
		}

		// Token: 0x0200020C RID: 524
		public class RectangleMask : GenAction
		{
			// Token: 0x06001533 RID: 5427 RVA: 0x0042F70C File Offset: 0x0042D90C
			public RectangleMask(int xMin, int xMax, int yMin, int yMax)
			{
				this._xMin = xMin;
				this._yMin = yMin;
				this._xMax = xMax;
				this._yMax = yMax;
			}

			// Token: 0x06001534 RID: 5428 RVA: 0x0042F734 File Offset: 0x0042D934
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				if (x >= this._xMin + origin.X && x <= this._xMax + origin.X && y >= this._yMin + origin.Y && y <= this._yMax + origin.Y)
				{
					return base.UnitApply(origin, x, y, args);
				}
				return base.Fail();
			}

			// Token: 0x04003768 RID: 14184
			private int _xMin;

			// Token: 0x04003769 RID: 14185
			private int _yMin;

			// Token: 0x0400376A RID: 14186
			private int _xMax;

			// Token: 0x0400376B RID: 14187
			private int _yMax;
		}

		// Token: 0x0200020D RID: 525
		public class Offset : GenAction
		{
			// Token: 0x06001535 RID: 5429 RVA: 0x0042F794 File Offset: 0x0042D994
			public Offset(int x, int y)
			{
				this._xOffset = x;
				this._yOffset = y;
			}

			// Token: 0x06001536 RID: 5430 RVA: 0x0042F7AC File Offset: 0x0042D9AC
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				return base.UnitApply(origin, x + this._xOffset, y + this._yOffset, args);
			}

			// Token: 0x0400376C RID: 14188
			private int _xOffset;

			// Token: 0x0400376D RID: 14189
			private int _yOffset;
		}

		// Token: 0x0200020E RID: 526
		public class Dither : GenAction
		{
			// Token: 0x06001537 RID: 5431 RVA: 0x0042F7C8 File Offset: 0x0042D9C8
			public Dither(double failureChance = 0.5)
			{
				this._failureChance = failureChance;
			}

			// Token: 0x06001538 RID: 5432 RVA: 0x0042F7D8 File Offset: 0x0042D9D8
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				if (GenBase._random.NextDouble() >= this._failureChance)
				{
					return base.UnitApply(origin, x, y, args);
				}
				return base.Fail();
			}

			// Token: 0x0400376E RID: 14190
			private double _failureChance;
		}

		// Token: 0x0200020F RID: 527
		public class Flip : GenAction
		{
			// Token: 0x06001539 RID: 5433 RVA: 0x0042F800 File Offset: 0x0042DA00
			public Flip(bool flipX, bool flipY)
			{
				this._flipX = flipX;
				this._flipY = flipY;
			}

			// Token: 0x0600153A RID: 5434 RVA: 0x0042F818 File Offset: 0x0042DA18
			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				if (this._flipX)
				{
					x = origin.X * 2 - x;
				}
				if (this._flipY)
				{
					y = origin.Y * 2 - y;
				}
				return base.UnitApply(origin, x, y, args);
			}

			// Token: 0x0400376F RID: 14191
			private bool _flipX;

			// Token: 0x04003770 RID: 14192
			private bool _flipY;
		}
	}
}

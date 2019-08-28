using System;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Terraria.World.Generation
{
	// Token: 0x0200004F RID: 79
	public static class ModShapes
	{
		// Token: 0x02000210 RID: 528
		public class All : GenModShape
		{
			// Token: 0x0600153B RID: 5435 RVA: 0x0042F850 File Offset: 0x0042DA50
			public All(ShapeData data) : base(data)
			{
			}

			// Token: 0x0600153C RID: 5436 RVA: 0x0042F85C File Offset: 0x0042DA5C
			public override bool Perform(Point origin, GenAction action)
			{
				foreach (Point16 current in this._data.GetData())
				{
					if (!base.UnitApply(action, origin, (int)current.X + origin.X, (int)current.Y + origin.Y, new object[0]) && this._quitOnFail)
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x02000211 RID: 529
		public class OuterOutline : GenModShape
		{
			// Token: 0x0600153D RID: 5437 RVA: 0x0042F8E8 File Offset: 0x0042DAE8
			public OuterOutline(ShapeData data, bool useDiagonals = true, bool useInterior = false) : base(data)
			{
				this._useDiagonals = useDiagonals;
				this._useInterior = useInterior;
			}

			// Token: 0x0600153E RID: 5438 RVA: 0x0042F900 File Offset: 0x0042DB00
			public override bool Perform(Point origin, GenAction action)
			{
				int num = this._useDiagonals ? 16 : 8;
				foreach (Point16 current in this._data.GetData())
				{
					if (this._useInterior && !base.UnitApply(action, origin, (int)current.X + origin.X, (int)current.Y + origin.Y, new object[0]) && this._quitOnFail)
					{
						bool result = false;
						return result;
					}
					for (int i = 0; i < num; i += 2)
					{
						if (!this._data.Contains((int)current.X + ModShapes.OuterOutline.POINT_OFFSETS[i], (int)current.Y + ModShapes.OuterOutline.POINT_OFFSETS[i + 1]) && !base.UnitApply(action, origin, origin.X + (int)current.X + ModShapes.OuterOutline.POINT_OFFSETS[i], origin.Y + (int)current.Y + ModShapes.OuterOutline.POINT_OFFSETS[i + 1], new object[0]) && this._quitOnFail)
						{
							bool result = false;
							return result;
						}
					}
				}
				return true;
			}

			// Token: 0x04003771 RID: 14193
			private static readonly int[] POINT_OFFSETS = new int[]
			{
				1,
				0,
				-1,
				0,
				0,
				1,
				0,
				-1,
				1,
				1,
				1,
				-1,
				-1,
				1,
				-1,
				-1
			};

			// Token: 0x04003772 RID: 14194
			private bool _useDiagonals;

			// Token: 0x04003773 RID: 14195
			private bool _useInterior;
		}

		// Token: 0x02000212 RID: 530
		public class InnerOutline : GenModShape
		{
			// Token: 0x06001540 RID: 5440 RVA: 0x0042FA50 File Offset: 0x0042DC50
			public InnerOutline(ShapeData data, bool useDiagonals = true) : base(data)
			{
				this._useDiagonals = useDiagonals;
			}

			// Token: 0x06001541 RID: 5441 RVA: 0x0042FA60 File Offset: 0x0042DC60
			public override bool Perform(Point origin, GenAction action)
			{
				int num = this._useDiagonals ? 16 : 8;
				foreach (Point16 current in this._data.GetData())
				{
					bool flag = false;
					for (int i = 0; i < num; i += 2)
					{
						if (!this._data.Contains((int)current.X + ModShapes.InnerOutline.POINT_OFFSETS[i], (int)current.Y + ModShapes.InnerOutline.POINT_OFFSETS[i + 1]))
						{
							flag = true;
							break;
						}
					}
					if (flag && !base.UnitApply(action, origin, (int)current.X + origin.X, (int)current.Y + origin.Y, new object[0]) && this._quitOnFail)
					{
						return false;
					}
				}
				return true;
			}

			// Token: 0x04003774 RID: 14196
			private static readonly int[] POINT_OFFSETS = new int[]
			{
				1,
				0,
				-1,
				0,
				0,
				1,
				0,
				-1,
				1,
				1,
				1,
				-1,
				-1,
				1,
				-1,
				-1
			};

			// Token: 0x04003775 RID: 14197
			private bool _useDiagonals;
		}
	}
}

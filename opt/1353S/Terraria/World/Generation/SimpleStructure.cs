using System;
using Microsoft.Xna.Framework;

namespace Terraria.World.Generation
{
	// Token: 0x0200005B RID: 91
	public class SimpleStructure : GenStructure
	{
		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000940 RID: 2368 RVA: 0x003B5690 File Offset: 0x003B3890
		public int Width
		{
			get
			{
				return this._width;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000941 RID: 2369 RVA: 0x003B5698 File Offset: 0x003B3898
		public int Height
		{
			get
			{
				return this._height;
			}
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x003B56A0 File Offset: 0x003B38A0
		public SimpleStructure(params string[] data)
		{
			this.ReadData(data);
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x003B56B0 File Offset: 0x003B38B0
		public SimpleStructure(string data)
		{
			this.ReadData(data.Split(new char[]
			{
				'\n'
			}));
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x003B56D0 File Offset: 0x003B38D0
		private void ReadData(string[] lines)
		{
			this._height = lines.Length;
			this._width = lines[0].Length;
			this._data = new int[this._width, this._height];
			for (int i = 0; i < this._height; i++)
			{
				for (int j = 0; j < this._width; j++)
				{
					int num = (int)lines[i][j];
					if (num >= 48 && num <= 57)
					{
						this._data[j, i] = num - 48;
					}
					else
					{
						this._data[j, i] = -1;
					}
				}
			}
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x003B5764 File Offset: 0x003B3964
		public SimpleStructure SetActions(params GenAction[] actions)
		{
			this._actions = actions;
			return this;
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x003B5770 File Offset: 0x003B3970
		public SimpleStructure Mirror(bool horizontalMirror, bool verticalMirror)
		{
			this._xMirror = horizontalMirror;
			this._yMirror = verticalMirror;
			return this;
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x003B5784 File Offset: 0x003B3984
		public override bool Place(Point origin, StructureMap structures)
		{
			if (!structures.CanPlace(new Rectangle(origin.X, origin.Y, this._width, this._height), 0))
			{
				return false;
			}
			for (int i = 0; i < this._width; i++)
			{
				for (int j = 0; j < this._height; j++)
				{
					int num = this._xMirror ? (-i) : i;
					int num2 = this._yMirror ? (-j) : j;
					if (this._data[i, j] != -1 && !this._actions[this._data[i, j]].Apply(origin, num + origin.X, num2 + origin.Y, new object[0]))
					{
						return false;
					}
				}
			}
			structures.AddStructure(new Rectangle(origin.X, origin.Y, this._width, this._height), 0);
			return true;
		}

		// Token: 0x04000D95 RID: 3477
		private int[,] _data;

		// Token: 0x04000D96 RID: 3478
		private int _width;

		// Token: 0x04000D97 RID: 3479
		private int _height;

		// Token: 0x04000D98 RID: 3480
		private GenAction[] _actions;

		// Token: 0x04000D99 RID: 3481
		private bool _xMirror;

		// Token: 0x04000D9A RID: 3482
		private bool _yMirror;
	}
}

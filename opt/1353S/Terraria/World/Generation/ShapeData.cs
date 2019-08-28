using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Terraria.World.Generation
{
	// Token: 0x0200005A RID: 90
	public class ShapeData
	{
		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000935 RID: 2357 RVA: 0x003B541C File Offset: 0x003B361C
		public int Count
		{
			get
			{
				return this._points.Count;
			}
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x003B542C File Offset: 0x003B362C
		public ShapeData()
		{
			this._points = new HashSet<Point16>();
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x003B5440 File Offset: 0x003B3640
		public ShapeData(ShapeData original)
		{
			this._points = new HashSet<Point16>(original._points);
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x003B545C File Offset: 0x003B365C
		public void Add(int x, int y)
		{
			this._points.Add(new Point16(x, y));
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x003B5474 File Offset: 0x003B3674
		public void Remove(int x, int y)
		{
			this._points.Remove(new Point16(x, y));
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x003B548C File Offset: 0x003B368C
		public HashSet<Point16> GetData()
		{
			return this._points;
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x003B5494 File Offset: 0x003B3694
		public void Clear()
		{
			this._points.Clear();
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x003B54A4 File Offset: 0x003B36A4
		public bool Contains(int x, int y)
		{
			return this._points.Contains(new Point16(x, y));
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x003B54B8 File Offset: 0x003B36B8
		public void Add(ShapeData shapeData, Point localOrigin, Point remoteOrigin)
		{
			foreach (Point16 current in shapeData.GetData())
			{
				this.Add(remoteOrigin.X - localOrigin.X + (int)current.X, remoteOrigin.Y - localOrigin.Y + (int)current.Y);
			}
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x003B5534 File Offset: 0x003B3734
		public void Subtract(ShapeData shapeData, Point localOrigin, Point remoteOrigin)
		{
			foreach (Point16 current in shapeData.GetData())
			{
				this.Remove(remoteOrigin.X - localOrigin.X + (int)current.X, remoteOrigin.Y - localOrigin.Y + (int)current.Y);
			}
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x003B55B0 File Offset: 0x003B37B0
		public static Rectangle GetBounds(Point origin, params ShapeData[] shapes)
		{
			int num = (int)shapes[0]._points.First<Point16>().X;
			int num2 = num;
			int num3 = (int)shapes[0]._points.First<Point16>().Y;
			int num4 = num3;
			for (int i = 0; i < shapes.Length; i++)
			{
				foreach (Point16 current in shapes[i]._points)
				{
					num = Math.Max(num, (int)current.X);
					num2 = Math.Min(num2, (int)current.X);
					num3 = Math.Max(num3, (int)current.Y);
					num4 = Math.Min(num4, (int)current.Y);
				}
			}
			return new Rectangle(num2 + origin.X, num4 + origin.Y, num - num2, num3 - num4);
		}

		// Token: 0x04000D94 RID: 3476
		private HashSet<Point16> _points;
	}
}

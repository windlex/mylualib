using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace Terraria.World.Generation
{
	// Token: 0x0200005C RID: 92
	public class StructureMap
	{
		// Token: 0x06000949 RID: 2377 RVA: 0x003B5878 File Offset: 0x003B3A78
		public bool CanPlace(Rectangle area, int padding = 0)
		{
			return this.CanPlace(area, TileID.Sets.GeneralPlacementTiles, padding);
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x003B5888 File Offset: 0x003B3A88
		public bool CanPlace(Rectangle area, bool[] validTiles, int padding = 0)
		{
			if (area.X < 0 || area.Y < 0 || area.X + area.Width > Main.maxTilesX - 1 || area.Y + area.Height > Main.maxTilesY - 1)
			{
				return false;
			}
			Rectangle rectangle = new Rectangle(area.X - padding, area.Y - padding, area.Width + padding * 2, area.Height + padding * 2);
			for (int i = 0; i < this._structures.Count; i++)
			{
				if (rectangle.Intersects(this._structures[i]))
				{
					return false;
				}
			}
			for (int j = rectangle.X; j < rectangle.X + rectangle.Width; j++)
			{
				for (int k = rectangle.Y; k < rectangle.Y + rectangle.Height; k++)
				{
					if (Main.tile[j, k].active())
					{
						ushort type = Main.tile[j, k].type;
						if (!validTiles[(int)type])
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x003B5998 File Offset: 0x003B3B98
		public void AddStructure(Rectangle area, int padding = 0)
		{
			Rectangle item = new Rectangle(area.X - padding, area.Y - padding, area.Width + padding * 2, area.Height + padding * 2);
			this._structures.Add(item);
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x003B59DC File Offset: 0x003B3BDC
		public void Reset()
		{
			this._structures.Clear();
		}

		// Token: 0x04000D9B RID: 3483
		private List<Rectangle> _structures = new List<Rectangle>(2048);
	}
}

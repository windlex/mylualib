using System;
using Microsoft.Xna.Framework;

namespace Terraria.GameContent.UI
{
	// Token: 0x0200013D RID: 317
	public class WorldUIAnchor
	{
		// Token: 0x06001065 RID: 4197 RVA: 0x00400918 File Offset: 0x003FEB18
		public WorldUIAnchor()
		{
			this.type = WorldUIAnchor.AnchorType.None;
		}

		// Token: 0x06001066 RID: 4198 RVA: 0x00400940 File Offset: 0x003FEB40
		public WorldUIAnchor(Entity anchor)
		{
			this.type = WorldUIAnchor.AnchorType.Entity;
			this.entity = anchor;
		}

		// Token: 0x06001067 RID: 4199 RVA: 0x0040096C File Offset: 0x003FEB6C
		public WorldUIAnchor(Vector2 anchor)
		{
			this.type = WorldUIAnchor.AnchorType.Pos;
			this.pos = anchor;
		}

		// Token: 0x06001068 RID: 4200 RVA: 0x00400998 File Offset: 0x003FEB98
		public WorldUIAnchor(int topLeftX, int topLeftY, int width, int height)
		{
			this.type = WorldUIAnchor.AnchorType.Tile;
			this.pos = new Vector2((float)topLeftX + (float)width / 2f, (float)topLeftY + (float)height / 2f) * 16f;
			this.size = new Vector2((float)width, (float)height) * 16f;
		}

		// Token: 0x06001069 RID: 4201 RVA: 0x00400A10 File Offset: 0x003FEC10
		public bool InRange(Vector2 target, float tileRangeX, float tileRangeY)
		{
			switch (this.type)
			{
			case WorldUIAnchor.AnchorType.Entity:
				return Math.Abs(target.X - this.entity.Center.X) <= tileRangeX * 16f + (float)this.entity.width / 2f && Math.Abs(target.Y - this.entity.Center.Y) <= tileRangeY * 16f + (float)this.entity.height / 2f;
			case WorldUIAnchor.AnchorType.Tile:
				return Math.Abs(target.X - this.pos.X) <= tileRangeX * 16f + this.size.X / 2f && Math.Abs(target.Y - this.pos.Y) <= tileRangeY * 16f + this.size.Y / 2f;
			case WorldUIAnchor.AnchorType.Pos:
				return Math.Abs(target.X - this.pos.X) <= tileRangeX * 16f && Math.Abs(target.Y - this.pos.Y) <= tileRangeY * 16f;
			default:
				return true;
			}
		}

		// Token: 0x0400313B RID: 12603
		public WorldUIAnchor.AnchorType type;

		// Token: 0x0400313C RID: 12604
		public Entity entity;

		// Token: 0x0400313D RID: 12605
		public Vector2 pos = Vector2.Zero;

		// Token: 0x0400313E RID: 12606
		public Vector2 size = Vector2.Zero;

		// Token: 0x0200029C RID: 668
		public enum AnchorType
		{
			// Token: 0x04003CB7 RID: 15543
			Entity,
			// Token: 0x04003CB8 RID: 15544
			Tile,
			// Token: 0x04003CB9 RID: 15545
			Pos,
			// Token: 0x04003CBA RID: 15546
			None
		}
	}
}

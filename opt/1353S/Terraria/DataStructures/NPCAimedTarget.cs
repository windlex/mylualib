using System;
using Microsoft.Xna.Framework;
using Terraria.Enums;

namespace Terraria.DataStructures
{
	// Token: 0x0200018C RID: 396
	public struct NPCAimedTarget
	{
		// Token: 0x17000189 RID: 393
		// (get) Token: 0x060012B5 RID: 4789 RVA: 0x00418EC0 File Offset: 0x004170C0
		public bool Invalid
		{
			get
			{
				return this.Type == NPCTargetType.None;
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x060012B6 RID: 4790 RVA: 0x00418ECC File Offset: 0x004170CC
		public Vector2 Center
		{
			get
			{
				return this.Position + this.Size / 2f;
			}
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x060012B7 RID: 4791 RVA: 0x00418EEC File Offset: 0x004170EC
		public Vector2 Size
		{
			get
			{
				return new Vector2((float)this.Width, (float)this.Height);
			}
		}

		// Token: 0x060012B8 RID: 4792 RVA: 0x00418F04 File Offset: 0x00417104
		public NPCAimedTarget(NPC npc)
		{
			this.Type = NPCTargetType.NPC;
			this.Hitbox = npc.Hitbox;
			this.Width = npc.width;
			this.Height = npc.height;
			this.Position = npc.position;
			this.Velocity = npc.velocity;
		}

		// Token: 0x060012B9 RID: 4793 RVA: 0x00418F54 File Offset: 0x00417154
		public NPCAimedTarget(Player player, bool ignoreTank = true)
		{
			this.Type = NPCTargetType.Player;
			this.Hitbox = player.Hitbox;
			this.Width = player.width;
			this.Height = player.height;
			this.Position = player.position;
			this.Velocity = player.velocity;
			if (!ignoreTank && player.tankPet > -1)
			{
				Projectile projectile = Main.projectile[player.tankPet];
				this.Type = NPCTargetType.PlayerTankPet;
				this.Hitbox = projectile.Hitbox;
				this.Width = projectile.width;
				this.Height = projectile.height;
				this.Position = projectile.position;
				this.Velocity = projectile.velocity;
			}
		}

		// Token: 0x04003462 RID: 13410
		public NPCTargetType Type;

		// Token: 0x04003463 RID: 13411
		public Rectangle Hitbox;

		// Token: 0x04003464 RID: 13412
		public int Width;

		// Token: 0x04003465 RID: 13413
		public int Height;

		// Token: 0x04003466 RID: 13414
		public Vector2 Position;

		// Token: 0x04003467 RID: 13415
		public Vector2 Velocity;
	}
}

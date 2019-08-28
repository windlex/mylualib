using System;
using Microsoft.Xna.Framework;

namespace Terraria
{
	// Token: 0x0200000B RID: 11
	public abstract class Entity
	{
		// Token: 0x06000055 RID: 85 RVA: 0x00008650 File Offset: 0x00006850
		public float AngleTo(Vector2 Destination)
		{
			return (float)Math.Atan2((double)(Destination.Y - this.Center.Y), (double)(Destination.X - this.Center.X));
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00008680 File Offset: 0x00006880
		public float AngleFrom(Vector2 Source)
		{
			return (float)Math.Atan2((double)(this.Center.Y - Source.Y), (double)(this.Center.X - Source.X));
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000086B0 File Offset: 0x000068B0
		public float Distance(Vector2 Other)
		{
			return Vector2.Distance(this.Center, Other);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000086C0 File Offset: 0x000068C0
		public float DistanceSQ(Vector2 Other)
		{
			return Vector2.DistanceSquared(this.Center, Other);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000086D0 File Offset: 0x000068D0
		public Vector2 DirectionTo(Vector2 Destination)
		{
			return Vector2.Normalize(Destination - this.Center);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000086E4 File Offset: 0x000068E4
		public Vector2 DirectionFrom(Vector2 Source)
		{
			return Vector2.Normalize(this.Center - Source);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000086F8 File Offset: 0x000068F8
		public bool WithinRange(Vector2 Target, float MaxRange)
		{
			return Vector2.DistanceSquared(this.Center, Target) <= MaxRange * MaxRange;
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00008710 File Offset: 0x00006910
		// (set) Token: 0x0600005D RID: 93 RVA: 0x00008744 File Offset: 0x00006944
		public Vector2 Center
		{
			get
			{
				return new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2));
			}
			set
			{
				this.position = new Vector2(value.X - (float)(this.width / 2), value.Y - (float)(this.height / 2));
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00008774 File Offset: 0x00006974
		// (set) Token: 0x0600005F RID: 95 RVA: 0x0000879C File Offset: 0x0000699C
		public Vector2 Left
		{
			get
			{
				return new Vector2(this.position.X, this.position.Y + (float)(this.height / 2));
			}
			set
			{
				this.position = new Vector2(value.X, value.Y - (float)(this.height / 2));
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000060 RID: 96 RVA: 0x000087C0 File Offset: 0x000069C0
		// (set) Token: 0x06000061 RID: 97 RVA: 0x000087F0 File Offset: 0x000069F0
		public Vector2 Right
		{
			get
			{
				return new Vector2(this.position.X + (float)this.width, this.position.Y + (float)(this.height / 2));
			}
			set
			{
				this.position = new Vector2(value.X - (float)this.width, value.Y - (float)(this.height / 2));
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000062 RID: 98 RVA: 0x0000881C File Offset: 0x00006A1C
		// (set) Token: 0x06000063 RID: 99 RVA: 0x00008844 File Offset: 0x00006A44
		public Vector2 Top
		{
			get
			{
				return new Vector2(this.position.X + (float)(this.width / 2), this.position.Y);
			}
			set
			{
				this.position = new Vector2(value.X - (float)(this.width / 2), value.Y);
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00008868 File Offset: 0x00006A68
		// (set) Token: 0x06000065 RID: 101 RVA: 0x00008870 File Offset: 0x00006A70
		public Vector2 TopLeft
		{
			get
			{
				return this.position;
			}
			set
			{
				this.position = value;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000066 RID: 102 RVA: 0x0000887C File Offset: 0x00006A7C
		// (set) Token: 0x06000067 RID: 103 RVA: 0x000088A4 File Offset: 0x00006AA4
		public Vector2 TopRight
		{
			get
			{
				return new Vector2(this.position.X + (float)this.width, this.position.Y);
			}
			set
			{
				this.position = new Vector2(value.X - (float)this.width, value.Y);
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000068 RID: 104 RVA: 0x000088C8 File Offset: 0x00006AC8
		// (set) Token: 0x06000069 RID: 105 RVA: 0x000088F8 File Offset: 0x00006AF8
		public Vector2 Bottom
		{
			get
			{
				return new Vector2(this.position.X + (float)(this.width / 2), this.position.Y + (float)this.height);
			}
			set
			{
				this.position = new Vector2(value.X - (float)(this.width / 2), value.Y - (float)this.height);
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00008924 File Offset: 0x00006B24
		// (set) Token: 0x0600006B RID: 107 RVA: 0x0000894C File Offset: 0x00006B4C
		public Vector2 BottomLeft
		{
			get
			{
				return new Vector2(this.position.X, this.position.Y + (float)this.height);
			}
			set
			{
				this.position = new Vector2(value.X, value.Y - (float)this.height);
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00008970 File Offset: 0x00006B70
		// (set) Token: 0x0600006D RID: 109 RVA: 0x000089A0 File Offset: 0x00006BA0
		public Vector2 BottomRight
		{
			get
			{
				return new Vector2(this.position.X + (float)this.width, this.position.Y + (float)this.height);
			}
			set
			{
				this.position = new Vector2(value.X - (float)this.width, value.Y - (float)this.height);
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600006E RID: 110 RVA: 0x000089CC File Offset: 0x00006BCC
		// (set) Token: 0x0600006F RID: 111 RVA: 0x000089E4 File Offset: 0x00006BE4
		public Vector2 Size
		{
			get
			{
				return new Vector2((float)this.width, (float)this.height);
			}
			set
			{
				this.width = (int)value.X;
				this.height = (int)value.Y;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000070 RID: 112 RVA: 0x00008A00 File Offset: 0x00006C00
		// (set) Token: 0x06000071 RID: 113 RVA: 0x00008A2C File Offset: 0x00006C2C
		public Rectangle Hitbox
		{
			get
			{
				return new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
			}
			set
			{
				this.position = new Vector2((float)value.X, (float)value.Y);
				this.width = value.Width;
				this.height = value.Height;
			}
		}

		// Token: 0x04000051 RID: 81
		public int whoAmI;

		// Token: 0x04000052 RID: 82
		public bool active;

		// Token: 0x04000053 RID: 83
		public Vector2 position;

		// Token: 0x04000054 RID: 84
		public Vector2 velocity;

		// Token: 0x04000055 RID: 85
		public Vector2 oldPosition;

		// Token: 0x04000056 RID: 86
		public Vector2 oldVelocity;

		// Token: 0x04000057 RID: 87
		public int oldDirection;

		// Token: 0x04000058 RID: 88
		public int direction = 1;

		// Token: 0x04000059 RID: 89
		public int width;

		// Token: 0x0400005A RID: 90
		public int height;

		// Token: 0x0400005B RID: 91
		public bool wet;

		// Token: 0x0400005C RID: 92
		public bool honeyWet;

		// Token: 0x0400005D RID: 93
		public byte wetCount;

		// Token: 0x0400005E RID: 94
		public bool lavaWet;
	}
}

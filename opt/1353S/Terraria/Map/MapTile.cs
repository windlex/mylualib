using System;

namespace Terraria.Map
{
	// Token: 0x02000077 RID: 119
	public struct MapTile
	{
		// Token: 0x06000A2A RID: 2602 RVA: 0x003BE785 File Offset: 0x003BC985
		private MapTile(ushort type, byte light, byte extraData)
		{
			this.Type = type;
			this.Light = light;
			this._extraData = extraData;
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x003BE7EA File Offset: 0x003BC9EA
		public void Clear()
		{
			this.Type = 0;
			this.Light = 0;
			this._extraData = 0;
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x003BE81C File Offset: 0x003BCA1C
		public static MapTile Create(ushort type, byte light, byte color)
		{
			return new MapTile(type, light, (byte)(color | 128));
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x003BE79C File Offset: 0x003BC99C
		public bool Equals(ref MapTile other)
		{
			return this.Light == other.Light && this.Type == other.Type && this.Color == other.Color;
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x003BE7CA File Offset: 0x003BC9CA
		public bool EqualsWithoutLight(ref MapTile other)
		{
			return this.Type == other.Type && this.Color == other.Color;
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x003BE801 File Offset: 0x003BCA01
		public MapTile WithLight(byte light)
		{
			return new MapTile(this.Type, light, (byte)(this._extraData | 128));
		}

		// Token: 0x170000F2 RID: 242
		public byte Color
		{
			// Token: 0x06000A28 RID: 2600 RVA: 0x003BE75F File Offset: 0x003BC95F
			get
			{
				return (byte)(this._extraData & 127);
			}
			// Token: 0x06000A29 RID: 2601 RVA: 0x003BE76B File Offset: 0x003BC96B
			set
			{
				this._extraData = ((byte)((this._extraData & 128) | (value & 127)));
			}
		}

		// Token: 0x170000F1 RID: 241
		public bool IsChanged
		{
			// Token: 0x06000A26 RID: 2598 RVA: 0x003BE721 File Offset: 0x003BC921
			get
			{
				return (this._extraData & 128) == 128;
			}
			// Token: 0x06000A27 RID: 2599 RVA: 0x003BE736 File Offset: 0x003BC936
			set
			{
				if (value)
				{
					this._extraData |= 128;
					return;
				}
				this._extraData &= 127;
			}
		}

		// Token: 0x04000E00 RID: 3584
		public ushort Type;

		// Token: 0x04000E01 RID: 3585
		public byte Light;

		// Token: 0x04000E02 RID: 3586
		private byte _extraData;
	}
}

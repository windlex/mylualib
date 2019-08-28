using System;
using Terraria.Enums;

namespace Terraria.DataStructures
{
	// Token: 0x02000182 RID: 386
	public struct AnchorData
	{
		// Token: 0x06001281 RID: 4737 RVA: 0x00417F70 File Offset: 0x00416170
		public AnchorData(AnchorType type, int count, int start)
		{
			this.type = type;
			this.tileCount = count;
			this.checkStart = start;
		}

		// Token: 0x06001282 RID: 4738 RVA: 0x00417F88 File Offset: 0x00416188
		public static bool operator ==(AnchorData data1, AnchorData data2)
		{
			return data1.type == data2.type && data1.tileCount == data2.tileCount && data1.checkStart == data2.checkStart;
		}

		// Token: 0x06001283 RID: 4739 RVA: 0x00417FB8 File Offset: 0x004161B8
		public static bool operator !=(AnchorData data1, AnchorData data2)
		{
			return data1.type != data2.type || data1.tileCount != data2.tileCount || data1.checkStart != data2.checkStart;
		}

		// Token: 0x06001284 RID: 4740 RVA: 0x00417FEC File Offset: 0x004161EC
		public override bool Equals(object obj)
		{
			return obj is AnchorData && (this.type == ((AnchorData)obj).type && this.tileCount == ((AnchorData)obj).tileCount) && this.checkStart == ((AnchorData)obj).checkStart;
		}

		// Token: 0x06001285 RID: 4741 RVA: 0x00418040 File Offset: 0x00416240
		public override int GetHashCode()
		{
			byte b = (byte)this.checkStart;
			byte b2 = (byte)this.tileCount;
			return (int)((ushort)this.type) << 16 | (int)b2 << 8 | (int)b;
		}

		// Token: 0x0400342F RID: 13359
		public AnchorType type;

		// Token: 0x04003430 RID: 13360
		public int tileCount;

		// Token: 0x04003431 RID: 13361
		public int checkStart;

		// Token: 0x04003432 RID: 13362
		public static AnchorData Empty;
	}
}

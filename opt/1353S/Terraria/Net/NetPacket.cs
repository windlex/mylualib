using System;
using System.IO;
using Terraria.DataStructures;

namespace Terraria.Net
{
	// Token: 0x0200006F RID: 111
	public struct NetPacket
	{
		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060009E2 RID: 2530 RVA: 0x003B75FC File Offset: 0x003B57FC
		// (set) Token: 0x060009E3 RID: 2531 RVA: 0x003B7604 File Offset: 0x003B5804
		public int Length
		{
			get;
			private set;
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060009E4 RID: 2532 RVA: 0x003B7610 File Offset: 0x003B5810
		public BinaryWriter Writer
		{
			get
			{
				return this.Buffer.Writer;
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060009E5 RID: 2533 RVA: 0x003B7620 File Offset: 0x003B5820
		public BinaryReader Reader
		{
			get
			{
				return this.Buffer.Reader;
			}
		}

		// Token: 0x060009E6 RID: 2534 RVA: 0x003B7630 File Offset: 0x003B5830
		public NetPacket(ushort id, int size)
		{
			this = default(NetPacket);
			this.Id = id;
			this.Buffer = BufferPool.Request(size + 5);
			this.Length = size + 5;
			this.Writer.Write((ushort)(size + 5));
			this.Writer.Write(82);
			this.Writer.Write(id);
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x003B768C File Offset: 0x003B588C
		public void Recycle()
		{
			this.Buffer.Recycle();
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x003B769C File Offset: 0x003B589C
		public void ShrinkToFit()
		{
			if (this.Length == (int)this.Writer.BaseStream.Position)
			{
				return;
			}
			this.Length = (int)this.Writer.BaseStream.Position;
			this.Writer.Seek(0, SeekOrigin.Begin);
			this.Writer.Write((ushort)this.Length);
			this.Writer.Seek(this.Length, SeekOrigin.Begin);
		}

		// Token: 0x04000DCE RID: 3534
		private const int HEADER_SIZE = 5;

		// Token: 0x04000DCF RID: 3535
		public readonly ushort Id;

		// Token: 0x04000DD1 RID: 3537
		public readonly CachedBuffer Buffer;
	}
}

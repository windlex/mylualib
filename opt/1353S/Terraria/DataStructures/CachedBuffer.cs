using System;
using System.IO;

namespace Terraria.DataStructures
{
	// Token: 0x02000184 RID: 388
	public class CachedBuffer
	{
		// Token: 0x17000186 RID: 390
		// (get) Token: 0x0600128C RID: 4748 RVA: 0x004182D0 File Offset: 0x004164D0
		public int Length
		{
			get
			{
				return this.Data.Length;
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x0600128D RID: 4749 RVA: 0x004182DC File Offset: 0x004164DC
		public bool IsActive
		{
			get
			{
				return this._isActive;
			}
		}

		// Token: 0x0600128E RID: 4750 RVA: 0x004182E4 File Offset: 0x004164E4
		public CachedBuffer(byte[] data)
		{
			this.Data = data;
			this._memoryStream = new MemoryStream(data);
			this.Writer = new BinaryWriter(this._memoryStream);
			this.Reader = new BinaryReader(this._memoryStream);
		}

		// Token: 0x0600128F RID: 4751 RVA: 0x00418334 File Offset: 0x00416534
		internal CachedBuffer Activate()
		{
			this._isActive = true;
			this._memoryStream.Position = 0L;
			return this;
		}

		// Token: 0x06001290 RID: 4752 RVA: 0x0041834C File Offset: 0x0041654C
		public void Recycle()
		{
			if (this._isActive)
			{
				this._isActive = false;
				BufferPool.Recycle(this);
			}
		}

		// Token: 0x0400343A RID: 13370
		public readonly byte[] Data;

		// Token: 0x0400343B RID: 13371
		public readonly BinaryWriter Writer;

		// Token: 0x0400343C RID: 13372
		public readonly BinaryReader Reader;

		// Token: 0x0400343D RID: 13373
		private readonly MemoryStream _memoryStream;

		// Token: 0x0400343E RID: 13374
		private bool _isActive = true;
	}
}

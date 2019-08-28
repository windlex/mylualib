using System;
using System.Collections.Generic;
using Steamworks;
using Terraria.Social.Base;

namespace Terraria.Social.Steam
{
	// Token: 0x0200008E RID: 142
	public class CloudSocialModule : Terraria.Social.Base.CloudSocialModule
	{
		// Token: 0x06000B01 RID: 2817 RVA: 0x003CC620 File Offset: 0x003CA820
		public override bool Delete(string path)
		{
			object obj = this.ioLock;
			bool result;
			lock (obj)
			{
				result = SteamRemoteStorage.FileDelete(path);
			}
			return result;
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x003CC454 File Offset: 0x003CA654
		public override IEnumerable<string> GetFiles()
		{
			object obj = this.ioLock;
			IEnumerable<string> result;
			lock (obj)
			{
				int fileCount = SteamRemoteStorage.GetFileCount();
				List<string> list = new List<string>(fileCount);
				for (int i = 0; i < fileCount; i++)
				{
					int num;
					list.Add(SteamRemoteStorage.GetFileNameAndSize(i, out num));
				}
				result = list;
			}
			return result;
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x003CC554 File Offset: 0x003CA754
		public override int GetFileSize(string path)
		{
			object obj = this.ioLock;
			int fileSize;
			lock (obj)
			{
				fileSize = SteamRemoteStorage.GetFileSize(path);
			}
			return fileSize;
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x003CC5DC File Offset: 0x003CA7DC
		public override bool HasFile(string path)
		{
			object obj = this.ioLock;
			bool result;
			lock (obj)
			{
				result = SteamRemoteStorage.FileExists(path);
			}
			return result;
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x003CC449 File Offset: 0x003CA649
		public override void Initialize()
		{
			base.Initialize();
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x003CC598 File Offset: 0x003CA798
		public override void Read(string path, byte[] buffer, int size)
		{
			object obj = this.ioLock;
			lock (obj)
			{
				SteamRemoteStorage.FileRead(path, buffer, size);
			}
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x00029F71 File Offset: 0x00028171
		public override void Shutdown()
		{
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x003CC4C0 File Offset: 0x003CA6C0
		public override bool Write(string path, byte[] data, int length)
		{
			object obj = this.ioLock;
			bool result;
			lock (obj)
			{
				UGCFileWriteStreamHandle_t writeHandle = SteamRemoteStorage.FileWriteStreamOpen(path);
				uint num = 0u;
				while ((ulong)num < (ulong)((long)length))
				{
					int num2 = (int)Math.Min(1024L, (long)length - (long)((ulong)num));
					Array.Copy(data, (long)((ulong)num), this.writeBuffer, 0L, (long)num2);
					SteamRemoteStorage.FileWriteStreamWriteChunk(writeHandle, this.writeBuffer, num2);
					num += 1024u;
				}
				result = SteamRemoteStorage.FileWriteStreamClose(writeHandle);
			}
			return result;
		}

		// Token: 0x04000E69 RID: 3689
		private object ioLock = new object();

		// Token: 0x04000E6A RID: 3690
		private byte[] writeBuffer = new byte[1024];

		// Token: 0x04000E68 RID: 3688
		private const uint WRITE_CHUNK_SIZE = 1024u;
	}
}

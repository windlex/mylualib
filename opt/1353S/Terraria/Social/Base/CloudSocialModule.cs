using System;
using System.Collections.Generic;
using Terraria.IO;

namespace Terraria.Social.Base
{
	// Token: 0x02000099 RID: 153
	public abstract class CloudSocialModule : ISocialModule
	{
		// Token: 0x06000B62 RID: 2914 RVA: 0x003CE788 File Offset: 0x003CC988
		public virtual void Initialize()
		{
			Main.Configuration.OnLoad += delegate(Preferences preferences)
			{
				this.EnabledByDefault = preferences.Get<bool>("CloudSavingDefault", false);
			};
			Main.Configuration.OnSave += delegate(Preferences preferences)
			{
				preferences.Put("CloudSavingDefault", this.EnabledByDefault);
			};
		}

		// Token: 0x06000B63 RID: 2915
		public abstract void Shutdown();

		// Token: 0x06000B64 RID: 2916
		public abstract IEnumerable<string> GetFiles();

		// Token: 0x06000B65 RID: 2917
		public abstract bool Write(string path, byte[] data, int length);

		// Token: 0x06000B66 RID: 2918
		public abstract void Read(string path, byte[] buffer, int length);

		// Token: 0x06000B67 RID: 2919
		public abstract bool HasFile(string path);

		// Token: 0x06000B68 RID: 2920
		public abstract int GetFileSize(string path);

		// Token: 0x06000B69 RID: 2921
		public abstract bool Delete(string path);

		// Token: 0x06000B6A RID: 2922 RVA: 0x003CE7B8 File Offset: 0x003CC9B8
		public byte[] Read(string path)
		{
			byte[] array = new byte[this.GetFileSize(path)];
			this.Read(path, array, array.Length);
			return array;
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x003CE7E0 File Offset: 0x003CC9E0
		public void Read(string path, byte[] buffer)
		{
			this.Read(path, buffer, buffer.Length);
		}

		// Token: 0x06000B6C RID: 2924 RVA: 0x003CE7F0 File Offset: 0x003CC9F0
		public bool Write(string path, byte[] data)
		{
			return this.Write(path, data, data.Length);
		}

		// Token: 0x04000EA5 RID: 3749
		public bool EnabledByDefault;
	}
}

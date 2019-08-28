using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Terraria.Utilities;

namespace Terraria.IO
{
	// Token: 0x02000079 RID: 121
	public class FavoritesFile
	{
		// Token: 0x06000A3C RID: 2620 RVA: 0x003BEB89 File Offset: 0x003BCD89
		public FavoritesFile(string path, bool isCloud)
		{
			this.Path = path;
			this.IsCloudSave = isCloud;
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x003BEC0B File Offset: 0x003BCE0B
		public void ClearEntry(FileData fileData)
		{
			if (!this._data.ContainsKey(fileData.Type))
			{
				return;
			}
			this._data[fileData.Type].Remove(fileData.GetFileName(true));
			this.Save();
		}

		// Token: 0x06000A3F RID: 2623 RVA: 0x003BEC48 File Offset: 0x003BCE48
		public bool IsFavorite(FileData fileData)
		{
			if (!this._data.ContainsKey(fileData.Type))
			{
				return false;
			}
			string fileName = fileData.GetFileName(true);
			bool flag;
			return this._data[fileData.Type].TryGetValue(fileName, out flag) && flag;
		}

		// Token: 0x06000A41 RID: 2625 RVA: 0x003BECC8 File Offset: 0x003BCEC8
		public void Load()
		{
			if (!FileUtilities.Exists(this.Path, this.IsCloudSave))
			{
				this._data.Clear();
				return;
			}
			byte[] bytes = FileUtilities.ReadAllBytes(this.Path, this.IsCloudSave);
			string @string = Encoding.ASCII.GetString(bytes);
			this._data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, bool>>>(@string);
			if (this._data == null)
			{
				this._data = new Dictionary<string, Dictionary<string, bool>>();
			}
		}

		// Token: 0x06000A40 RID: 2624 RVA: 0x003BEC90 File Offset: 0x003BCE90
		public void Save()
		{
			string s = JsonConvert.SerializeObject(this._data, Formatting.Indented);
			byte[] bytes = Encoding.ASCII.GetBytes(s);
			FileUtilities.WriteAllBytes(this.Path, bytes, this.IsCloudSave);
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x003BEBAC File Offset: 0x003BCDAC
		public void SaveFavorite(FileData fileData)
		{
			if (!this._data.ContainsKey(fileData.Type))
			{
				this._data.Add(fileData.Type, new Dictionary<string, bool>());
			}
			this._data[fileData.Type][fileData.GetFileName(true)] = fileData.IsFavorite;
			this.Save();
		}

		// Token: 0x04000E07 RID: 3591
		public readonly bool IsCloudSave;

		// Token: 0x04000E06 RID: 3590
		public readonly string Path;

		// Token: 0x04000E08 RID: 3592
		private Dictionary<string, Dictionary<string, bool>> _data = new Dictionary<string, Dictionary<string, bool>>();
	}
}

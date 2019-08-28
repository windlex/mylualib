using System;
using Terraria.Utilities;

namespace Terraria.IO
{
	// Token: 0x0200007A RID: 122
	public abstract class FileData
	{
		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000A42 RID: 2626 RVA: 0x003BF49C File Offset: 0x003BD69C
		public string Path
		{
			get
			{
				return this._path;
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000A43 RID: 2627 RVA: 0x003BF4A4 File Offset: 0x003BD6A4
		public bool IsCloudSave
		{
			get
			{
				return this._isCloudSave;
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000A44 RID: 2628 RVA: 0x003BF4AC File Offset: 0x003BD6AC
		public bool IsFavorite
		{
			get
			{
				return this._isFavorite;
			}
		}

		// Token: 0x06000A45 RID: 2629 RVA: 0x003BF4B4 File Offset: 0x003BD6B4
		protected FileData(string type)
		{
			this.Type = type;
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x003BF4C4 File Offset: 0x003BD6C4
		protected FileData(string type, string path, bool isCloud)
		{
			this.Type = type;
			this._path = path;
			this._isCloudSave = isCloud;
			this._isFavorite = (isCloud ? Main.CloudFavoritesData : Main.LocalFavoriteData).IsFavorite(this);
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x003BF4FC File Offset: 0x003BD6FC
		public void ToggleFavorite()
		{
			this.SetFavorite(!this.IsFavorite, true);
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x003BF510 File Offset: 0x003BD710
		public string GetFileName(bool includeExtension = true)
		{
			return FileUtilities.GetFileName(this.Path, includeExtension);
		}

		// Token: 0x06000A49 RID: 2633 RVA: 0x003BF520 File Offset: 0x003BD720
		public void SetFavorite(bool favorite, bool saveChanges = true)
		{
			this._isFavorite = favorite;
			if (saveChanges)
			{
				(this.IsCloudSave ? Main.CloudFavoritesData : Main.LocalFavoriteData).SaveFavorite(this);
			}
		}

		// Token: 0x06000A4A RID: 2634
		public abstract void SetAsActive();

		// Token: 0x06000A4B RID: 2635
		public abstract void MoveToCloud();

		// Token: 0x06000A4C RID: 2636
		public abstract void MoveToLocal();

		// Token: 0x04000E09 RID: 3593
		protected string _path;

		// Token: 0x04000E0A RID: 3594
		protected bool _isCloudSave;

		// Token: 0x04000E0B RID: 3595
		public FileMetadata Metadata;

		// Token: 0x04000E0C RID: 3596
		public string Name;

		// Token: 0x04000E0D RID: 3597
		public readonly string Type;

		// Token: 0x04000E0E RID: 3598
		protected bool _isFavorite;
	}
}

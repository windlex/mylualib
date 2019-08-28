using System;
using System.IO;
using Terraria.Localization;
using Terraria.Utilities;

namespace Terraria.IO
{
	// Token: 0x0200007C RID: 124
	public class WorldFileData : FileData
	{
		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000A5B RID: 2651 RVA: 0x003BF920 File Offset: 0x003BDB20
		public string SeedText
		{
			get
			{
				return this._seedText;
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000A5C RID: 2652 RVA: 0x003BF928 File Offset: 0x003BDB28
		public int Seed
		{
			get
			{
				return this._seed;
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000A5D RID: 2653 RVA: 0x003BF930 File Offset: 0x003BDB30
		public string WorldSizeName
		{
			get
			{
				return this._worldSizeName.Value;
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000A5E RID: 2654 RVA: 0x003BF940 File Offset: 0x003BDB40
		// (set) Token: 0x06000A5F RID: 2655 RVA: 0x003BF94C File Offset: 0x003BDB4C
		public bool HasCrimson
		{
			get
			{
				return !this.HasCorruption;
			}
			set
			{
				this.HasCorruption = !value;
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000A60 RID: 2656 RVA: 0x003BF958 File Offset: 0x003BDB58
		public bool HasValidSeed
		{
			get
			{
				return this.WorldGeneratorVersion > 0uL;
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000A61 RID: 2657 RVA: 0x003BF964 File Offset: 0x003BDB64
		public bool UseGuidAsMapName
		{
			get
			{
				return this.WorldGeneratorVersion >= 777389080577uL;
			}
		}

		// Token: 0x06000A62 RID: 2658 RVA: 0x003BF97C File Offset: 0x003BDB7C
		public WorldFileData() : base("World")
		{
		}

		// Token: 0x06000A63 RID: 2659 RVA: 0x003BF9A4 File Offset: 0x003BDBA4
		public WorldFileData(string path, bool cloudSave) : base("World", path, cloudSave)
		{
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x003BF9CC File Offset: 0x003BDBCC
		public override void SetAsActive()
		{
			Main.ActiveWorldFileData = this;
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x003BF9D4 File Offset: 0x003BDBD4
		public void SetWorldSize(int x, int y)
		{
			this.WorldSizeX = x;
			this.WorldSizeY = y;
			if (x == 4200)
			{
				this._worldSizeName = Language.GetText("UI.WorldSizeSmall");
				return;
			}
			if (x == 6400)
			{
				this._worldSizeName = Language.GetText("UI.WorldSizeMedium");
				return;
			}
			if (x != 8400)
			{
				this._worldSizeName = Language.GetText("UI.WorldSizeUnknown");
				return;
			}
			this._worldSizeName = Language.GetText("UI.WorldSizeLarge");
		}

		// Token: 0x06000A66 RID: 2662 RVA: 0x003BFA4C File Offset: 0x003BDC4C
		public static WorldFileData FromInvalidWorld(string path, bool cloudSave)
		{
			WorldFileData worldFileData = new WorldFileData(path, cloudSave);
			worldFileData.IsExpertMode = false;
			worldFileData.SetSeedToEmpty();
			worldFileData.WorldGeneratorVersion = 0uL;
			worldFileData.Metadata = FileMetadata.FromCurrentSettings(FileType.World);
			worldFileData.SetWorldSize(1, 1);
			worldFileData.HasCorruption = true;
			worldFileData.IsHardMode = false;
			worldFileData.IsValid = false;
			worldFileData.Name = FileUtilities.GetFileName(path, false);
			worldFileData.UniqueId = Guid.Empty;
			if (!cloudSave)
			{
				worldFileData.CreationTime = File.GetCreationTime(path);
			}
			else
			{
				worldFileData.CreationTime = DateTime.Now;
			}
			return worldFileData;
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x003BFAD4 File Offset: 0x003BDCD4
		public void SetSeedToEmpty()
		{
			this.SetSeed("");
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x003BFAE4 File Offset: 0x003BDCE4
		public void SetSeed(string seedText)
		{
			this._seedText = seedText;
			if (!int.TryParse(seedText, out this._seed))
			{
				this._seed = seedText.GetHashCode();
			}
			this._seed = Math.Abs(this._seed);
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x003BFB18 File Offset: 0x003BDD18
		public void SetSeedToRandom()
		{
			this.SetSeed(new UnifiedRandom().Next().ToString());
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x003BFB40 File Offset: 0x003BDD40
		public override void MoveToCloud()
		{
			if (base.IsCloudSave)
			{
				return;
			}
			string worldPathFromName = Main.GetWorldPathFromName(this.Name, true);
			if (FileUtilities.MoveToCloud(base.Path, worldPathFromName))
			{
				Main.LocalFavoriteData.ClearEntry(this);
				this._isCloudSave = true;
				this._path = worldPathFromName;
				Main.CloudFavoritesData.SaveFavorite(this);
			}
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x003BFB98 File Offset: 0x003BDD98
		public override void MoveToLocal()
		{
			if (!base.IsCloudSave)
			{
				return;
			}
			string worldPathFromName = Main.GetWorldPathFromName(this.Name, false);
			if (FileUtilities.MoveToLocal(base.Path, worldPathFromName))
			{
				Main.CloudFavoritesData.ClearEntry(this);
				this._isCloudSave = false;
				this._path = worldPathFromName;
				Main.LocalFavoriteData.SaveFavorite(this);
			}
		}

		// Token: 0x04000E13 RID: 3603
		private const ulong GUID_IN_WORLD_FILE_VERSION = 777389080577uL;

		// Token: 0x04000E14 RID: 3604
		public DateTime CreationTime;

		// Token: 0x04000E15 RID: 3605
		public int WorldSizeX;

		// Token: 0x04000E16 RID: 3606
		public int WorldSizeY;

		// Token: 0x04000E17 RID: 3607
		public ulong WorldGeneratorVersion;

		// Token: 0x04000E18 RID: 3608
		private string _seedText = "";

		// Token: 0x04000E19 RID: 3609
		private int _seed;

		// Token: 0x04000E1A RID: 3610
		public bool IsValid = true;

		// Token: 0x04000E1B RID: 3611
		public Guid UniqueId;

		// Token: 0x04000E1C RID: 3612
		public LocalizedText _worldSizeName;

		// Token: 0x04000E1D RID: 3613
		public bool IsExpertMode;

		// Token: 0x04000E1E RID: 3614
		public bool HasCorruption = true;

		// Token: 0x04000E1F RID: 3615
		public bool IsHardMode;
	}
}

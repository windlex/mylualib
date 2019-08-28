using System;
using System.IO;
using Terraria.IO;
using Terraria.Social;
using Terraria.Utilities;

namespace Terraria.Map
{
	// Token: 0x02000078 RID: 120
	public class WorldMap
	{
		// Token: 0x170000F3 RID: 243
		public MapTile this[int x, int y]
		{
			get
			{
				return this._tiles[x, y];
			}
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x003BEF94 File Offset: 0x003BD194
		public WorldMap(int maxWidth, int maxHeight)
		{
			this.MaxWidth = maxWidth;
			this.MaxHeight = maxHeight;
			this._tiles = new MapTile[this.MaxWidth, this.MaxHeight];
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x003BEFC4 File Offset: 0x003BD1C4
		public void ConsumeUpdate(int x, int y)
		{
			this._tiles[x, y].IsChanged = false;
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x003BEFDC File Offset: 0x003BD1DC
		public void Update(int x, int y, byte light)
		{
			this._tiles[x, y] = MapHelper.CreateMapTile(x, y, light);
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x003BEFF4 File Offset: 0x003BD1F4
		public void SetTile(int x, int y, ref MapTile tile)
		{
			this._tiles[x, y] = tile;
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x003BF00C File Offset: 0x003BD20C
		public bool IsRevealed(int x, int y)
		{
			return this._tiles[x, y].Light > 0;
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x003BF024 File Offset: 0x003BD224
		public bool UpdateLighting(int x, int y, byte light)
		{
			MapTile mapTile = this._tiles[x, y];
			MapTile mapTile2 = MapHelper.CreateMapTile(x, y, Math.Max(mapTile.Light, light));
			if (mapTile2.Equals(ref mapTile))
			{
				return false;
			}
			this._tiles[x, y] = mapTile2;
			return true;
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x003BF070 File Offset: 0x003BD270
		public bool UpdateType(int x, int y)
		{
			MapTile mapTile = MapHelper.CreateMapTile(x, y, this._tiles[x, y].Light);
			if (mapTile.Equals(ref this._tiles[x, y]))
			{
				return false;
			}
			this._tiles[x, y] = mapTile;
			return true;
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x003BF0C0 File Offset: 0x003BD2C0
		public void UnlockMapSection(int sectionX, int sectionY)
		{
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x003BF0C4 File Offset: 0x003BD2C4
		public void Load()
		{
			bool isCloudSave = Main.ActivePlayerFileData.IsCloudSave;
			if (isCloudSave && SocialAPI.Cloud == null)
			{
				return;
			}
			if (!Main.mapEnabled)
			{
				return;
			}
			string text = Main.playerPathName.Substring(0, Main.playerPathName.Length - 4) + Path.DirectorySeparatorChar.ToString();
			if (Main.ActiveWorldFileData.UseGuidAsMapName)
			{
				string arg = text;
				text = text + Main.ActiveWorldFileData.UniqueId.ToString() + ".map";
				if (!FileUtilities.Exists(text, isCloudSave))
				{
					text = arg + Main.worldID + ".map";
				}
			}
			else
			{
				text = text + Main.worldID + ".map";
			}
			if (!FileUtilities.Exists(text, isCloudSave))
			{
				Main.MapFileMetadata = FileMetadata.FromCurrentSettings(FileType.Map);
				return;
			}
			using (MemoryStream memoryStream = new MemoryStream(FileUtilities.ReadAllBytes(text, isCloudSave)))
			{
				using (BinaryReader binaryReader = new BinaryReader(memoryStream))
				{
					try
					{
						int num = binaryReader.ReadInt32();
						if (num <= 194)
						{
							if (num <= 91)
							{
								MapHelper.LoadMapVersion1(binaryReader, num);
							}
							else
							{
								MapHelper.LoadMapVersion2(binaryReader, num);
							}
							Main.clearMap = true;
							Main.loadMap = true;
							Main.loadMapLock = true;
							Main.refreshMap = false;
						}
					}
					catch (Exception value)
					{
						using (StreamWriter streamWriter = new StreamWriter("client-crashlog.txt", true))
						{
							streamWriter.WriteLine(DateTime.Now);
							streamWriter.WriteLine(value);
							streamWriter.WriteLine("");
						}
						if (!isCloudSave)
						{
							File.Copy(text, text + ".bad", true);
						}
						this.Clear();
					}
				}
			}
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x003BF2A4 File Offset: 0x003BD4A4
		public void Save()
		{
			MapHelper.SaveMap();
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x003BF2AC File Offset: 0x003BD4AC
		public void Clear()
		{
			for (int i = 0; i < this.MaxWidth; i++)
			{
				for (int j = 0; j < this.MaxHeight; j++)
				{
					this._tiles[i, j].Clear();
				}
			}
		}

		// Token: 0x04000E03 RID: 3587
		public readonly int MaxWidth;

		// Token: 0x04000E04 RID: 3588
		public readonly int MaxHeight;

		// Token: 0x04000E05 RID: 3589
		private MapTile[,] _tiles;
	}
}

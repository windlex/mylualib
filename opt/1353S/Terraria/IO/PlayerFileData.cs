using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Terraria.Social;
using Terraria.Utilities;

namespace Terraria.IO
{
	// Token: 0x0200007B RID: 123
	public class PlayerFileData : FileData
	{
		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000A4D RID: 2637 RVA: 0x003BF548 File Offset: 0x003BD748
		// (set) Token: 0x06000A4E RID: 2638 RVA: 0x003BF550 File Offset: 0x003BD750
		public Player Player
		{
			get
			{
				return this._player;
			}
			set
			{
				this._player = value;
				if (value != null)
				{
					this.Name = this._player.name;
				}
			}
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x003BF570 File Offset: 0x003BD770
		public PlayerFileData() : base("Player")
		{
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x003BF594 File Offset: 0x003BD794
		public PlayerFileData(string path, bool cloudSave) : base("Player", path, cloudSave)
		{
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x003BF5BC File Offset: 0x003BD7BC
		public static PlayerFileData CreateAndSave(Player player)
		{
			PlayerFileData playerFileData = new PlayerFileData();
			playerFileData.Metadata = FileMetadata.FromCurrentSettings(FileType.Player);
			playerFileData.Player = player;
			playerFileData._isCloudSave = (SocialAPI.Cloud != null && SocialAPI.Cloud.EnabledByDefault);
			playerFileData._path = Main.GetPlayerPathFromName(player.name, playerFileData.IsCloudSave);
			(playerFileData.IsCloudSave ? Main.CloudFavoritesData : Main.LocalFavoriteData).ClearEntry(playerFileData);
			Player.SavePlayer(playerFileData, true);
			return playerFileData;
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x003BF638 File Offset: 0x003BD838
		public override void SetAsActive()
		{
			Main.ActivePlayerFileData = this;
			Main.player[Main.myPlayer] = this.Player;
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x003BF654 File Offset: 0x003BD854
		public override void MoveToCloud()
		{
			if (base.IsCloudSave || SocialAPI.Cloud == null)
			{
				return;
			}
			string playerPathFromName = Main.GetPlayerPathFromName(this.Name, true);
			if (FileUtilities.MoveToCloud(base.Path, playerPathFromName))
			{
				string fileName = base.GetFileName(false);
				string path = Main.PlayerPath + System.IO.Path.DirectorySeparatorChar.ToString() + fileName + System.IO.Path.DirectorySeparatorChar.ToString();
				if (Directory.Exists(path))
				{
					string[] files = Directory.GetFiles(path);
					for (int i = 0; i < files.Length; i++)
					{
						string cloudPath = string.Concat(new string[]
						{
							Main.CloudPlayerPath,
							"/",
							fileName,
							"/",
							FileUtilities.GetFileName(files[i], true)
						});
						FileUtilities.MoveToCloud(files[i], cloudPath);
					}
				}
				Main.LocalFavoriteData.ClearEntry(this);
				this._isCloudSave = true;
				this._path = playerPathFromName;
				Main.CloudFavoritesData.SaveFavorite(this);
			}
		}

		// Token: 0x06000A54 RID: 2644 RVA: 0x003BF748 File Offset: 0x003BD948
		public override void MoveToLocal()
		{
			if (!base.IsCloudSave || SocialAPI.Cloud == null)
			{
				return;
			}
			string playerPathFromName = Main.GetPlayerPathFromName(this.Name, false);
			if (FileUtilities.MoveToLocal(base.Path, playerPathFromName))
			{
				string fileName = base.GetFileName(false);
				string mapPath = System.IO.Path.Combine(Main.CloudPlayerPath, fileName);
				foreach (string current in from path in SocialAPI.Cloud.GetFiles()
				where path.StartsWith(mapPath, StringComparison.CurrentCultureIgnoreCase) && path.EndsWith(".map", StringComparison.CurrentCultureIgnoreCase)
				select path)
				{
					string localPath = System.IO.Path.Combine(Main.PlayerPath, fileName, FileUtilities.GetFileName(current, true));
					FileUtilities.MoveToLocal(current, localPath);
				}
				Main.CloudFavoritesData.ClearEntry(this);
				this._isCloudSave = false;
				this._path = playerPathFromName;
				Main.LocalFavoriteData.SaveFavorite(this);
			}
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x003BF834 File Offset: 0x003BDA34
		public void UpdatePlayTimer()
		{
			if (Main.instance.IsActive && !Main.gamePaused && Main.hasFocus && this._isTimerActive)
			{
				this.StartPlayTimer();
				return;
			}
			this.PausePlayTimer();
		}

		// Token: 0x06000A56 RID: 2646 RVA: 0x003BF868 File Offset: 0x003BDA68
		public void StartPlayTimer()
		{
			this._isTimerActive = true;
			if (!this._timer.IsRunning)
			{
				this._timer.Start();
			}
		}

		// Token: 0x06000A57 RID: 2647 RVA: 0x003BF88C File Offset: 0x003BDA8C
		public void PausePlayTimer()
		{
			if (this._timer.IsRunning)
			{
				this._timer.Stop();
			}
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x003BF8A8 File Offset: 0x003BDAA8
		public TimeSpan GetPlayTime()
		{
			if (this._timer.IsRunning)
			{
				return this._playTime + this._timer.Elapsed;
			}
			return this._playTime;
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x003BF8D4 File Offset: 0x003BDAD4
		public void StopPlayTimer()
		{
			this._isTimerActive = false;
			if (this._timer.IsRunning)
			{
				this._playTime += this._timer.Elapsed;
				this._timer.Reset();
			}
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x003BF914 File Offset: 0x003BDB14
		public void SetPlayTime(TimeSpan time)
		{
			this._playTime = time;
		}

		// Token: 0x04000E0F RID: 3599
		private Player _player;

		// Token: 0x04000E10 RID: 3600
		private TimeSpan _playTime = TimeSpan.Zero;

		// Token: 0x04000E11 RID: 3601
		private Stopwatch _timer = new Stopwatch();

		// Token: 0x04000E12 RID: 3602
		private bool _isTimerActive;
	}
}

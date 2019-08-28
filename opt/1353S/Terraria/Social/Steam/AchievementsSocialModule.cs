using System;
using System.Collections.Generic;
using System.Threading;
using Steamworks;
using Terraria.Social.Base;

namespace Terraria.Social.Steam
{
	// Token: 0x0200008D RID: 141
	public class AchievementsSocialModule : Terraria.Social.Base.AchievementsSocialModule
	{
		// Token: 0x06000AF7 RID: 2807 RVA: 0x003CC3F9 File Offset: 0x003CA5F9
		public override void CompleteAchievement(string name)
		{
			SteamUserStats.SetAchievement(name);
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x003CC2EC File Offset: 0x003CA4EC
		public override byte[] GetEncryptionKey()
		{
			byte[] array = new byte[16];
			byte[] expr_17 = BitConverter.GetBytes(SteamUser.GetSteamID().m_SteamID);
			Array.Copy(expr_17, array, 8);
			Array.Copy(expr_17, 0, array, 8, 8);
			return array;
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x003CC364 File Offset: 0x003CA564
		private float GetFloatStat(string name)
		{
			float num;
			if (this._floatStatCache.TryGetValue(name, out num))
			{
				return num;
			}
			if (SteamUserStats.GetStat(name, out num))
			{
				this._floatStatCache.Add(name, num);
			}
			return num;
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x003CC32C File Offset: 0x003CA52C
		private int GetIntStat(string name)
		{
			int num;
			if (this._intStatCache.TryGetValue(name, out num))
			{
				return num;
			}
			if (SteamUserStats.GetStat(name, out num))
			{
				this._intStatCache.Add(name, num);
			}
			return num;
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x003CC322 File Offset: 0x003CA522
		public override string GetSavePath()
		{
			return "/achievements-steam.dat";
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x003CC296 File Offset: 0x003CA496
		public override void Initialize()
		{
			this._userStatsReceived = Callback<UserStatsReceived_t>.Create(new Callback<UserStatsReceived_t>.DispatchDelegate(this.OnUserStatsReceived));
			SteamUserStats.RequestCurrentStats();
			while (!this._areStatsReceived)
			{
				CoreSocialModule.Pulse();
				Thread.Sleep(10);
			}
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x003CC2D4 File Offset: 0x003CA4D4
		public override bool IsAchievementCompleted(string name)
		{
			bool flag;
			return SteamUserStats.GetAchievement(name, out flag) & flag;
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x003CC402 File Offset: 0x003CA602
		private void OnUserStatsReceived(UserStatsReceived_t results)
		{
			if (results.m_nGameID == 105600uL && results.m_steamIDUser == SteamUser.GetSteamID())
			{
				this._areStatsReceived = true;
			}
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x003CC39B File Offset: 0x003CA59B
		private bool SetFloatStat(string name, float value)
		{
			this._floatStatCache[name] = value;
			return SteamUserStats.SetStat(name, value);
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x003CC3C6 File Offset: 0x003CA5C6
		private bool SetIntStat(string name, int value)
		{
			this._intStatCache[name] = value;
			return SteamUserStats.SetStat(name, value);
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x003CC2CB File Offset: 0x003CA4CB
		public override void Shutdown()
		{
			this.StoreStats();
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x003CC3F1 File Offset: 0x003CA5F1
		public override void StoreStats()
		{
			SteamUserStats.StoreStats();
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x003CC3DC File Offset: 0x003CA5DC
		public override void UpdateFloatStat(string name, float value)
		{
			if (this.GetFloatStat(name) < value)
			{
				this.SetFloatStat(name, value);
			}
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x003CC3B1 File Offset: 0x003CA5B1
		public override void UpdateIntStat(string name, int value)
		{
			if (this.GetIntStat(name) < value)
			{
				this.SetIntStat(name, value);
			}
		}

		// Token: 0x04000E63 RID: 3683
		private const string FILE_NAME = "/achievements-steam.dat";

		// Token: 0x04000E65 RID: 3685
		private bool _areStatsReceived;

		// Token: 0x04000E67 RID: 3687
		private Dictionary<string, float> _floatStatCache = new Dictionary<string, float>();

		// Token: 0x04000E66 RID: 3686
		private Dictionary<string, int> _intStatCache = new Dictionary<string, int>();

		// Token: 0x04000E64 RID: 3684
		private Callback<UserStatsReceived_t> _userStatsReceived;
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Linq;
using Terraria.Social;
using Terraria.Utilities;

namespace Terraria.Achievements
{
	// Token: 0x020001AC RID: 428
	public class AchievementManager
	{
		// Token: 0x14000033 RID: 51
		// (add) Token: 0x060013BA RID: 5050 RVA: 0x0041C3E8 File Offset: 0x0041A5E8
		// (remove) Token: 0x060013BB RID: 5051 RVA: 0x0041C420 File Offset: 0x0041A620
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event Achievement.AchievementCompleted OnAchievementCompleted;

		// Token: 0x060013BC RID: 5052 RVA: 0x0041C458 File Offset: 0x0041A658
		public AchievementManager()
		{
			if (SocialAPI.Achievements != null)
			{
				this._savePath = SocialAPI.Achievements.GetSavePath();
				this._isCloudSave = true;
				this._cryptoKey = SocialAPI.Achievements.GetEncryptionKey();
				return;
			}
			this._savePath = Main.SavePath + Path.DirectorySeparatorChar.ToString() + "achievements.dat";
			this._isCloudSave = false;
			this._cryptoKey = Encoding.ASCII.GetBytes("RELOGIC-TERRARIA");
		}

		// Token: 0x060013BD RID: 5053 RVA: 0x0041C4FC File Offset: 0x0041A6FC
		public void Save()
		{
			this.Save(this._savePath, this._isCloudSave);
		}

		// Token: 0x060013BE RID: 5054 RVA: 0x0041C510 File Offset: 0x0041A710
		private void Save(string path, bool cloud)
		{
			object ioLock = AchievementManager._ioLock;
			lock (ioLock)
			{
				if (SocialAPI.Achievements != null)
				{
					SocialAPI.Achievements.StoreStats();
				}
				try
				{
					using (MemoryStream memoryStream = new MemoryStream())
					{
						using (CryptoStream cryptoStream = new CryptoStream(memoryStream, new RijndaelManaged().CreateEncryptor(this._cryptoKey, this._cryptoKey), CryptoStreamMode.Write))
						{
							using (BsonWriter bsonWriter = new BsonWriter(cryptoStream))
							{
								JsonSerializer.Create(this._serializerSettings).Serialize(bsonWriter, this._achievements);
								bsonWriter.Flush();
								cryptoStream.FlushFinalBlock();
								FileUtilities.WriteAllBytes(path, memoryStream.ToArray(), cloud);
							}
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x060013BF RID: 5055 RVA: 0x0041C614 File Offset: 0x0041A814
		public List<Achievement> CreateAchievementsList()
		{
			return this._achievements.Values.ToList<Achievement>();
		}

		// Token: 0x060013C0 RID: 5056 RVA: 0x0041C628 File Offset: 0x0041A828
		public void Load()
		{
			this.Load(this._savePath, this._isCloudSave);
		}

		// Token: 0x060013C1 RID: 5057 RVA: 0x0041C63C File Offset: 0x0041A83C
		private void Load(string path, bool cloud)
		{
			bool flag = false;
			object ioLock = AchievementManager._ioLock;
			lock (ioLock)
			{
				if (!FileUtilities.Exists(path, cloud))
				{
					return;
				}
				byte[] buffer = FileUtilities.ReadAllBytes(path, cloud);
				Dictionary<string, AchievementManager.StoredAchievement> dictionary = null;
				try
				{
					using (MemoryStream memoryStream = new MemoryStream(buffer))
					{
						using (CryptoStream cryptoStream = new CryptoStream(memoryStream, new RijndaelManaged().CreateDecryptor(this._cryptoKey, this._cryptoKey), CryptoStreamMode.Read))
						{
							using (BsonReader bsonReader = new BsonReader(cryptoStream))
							{
								dictionary = JsonSerializer.Create(this._serializerSettings).Deserialize<Dictionary<string, AchievementManager.StoredAchievement>>(bsonReader);
							}
						}
					}
				}
				catch (Exception)
				{
					FileUtilities.Delete(path, cloud);
					return;
				}
				if (dictionary == null)
				{
					return;
				}
				foreach (KeyValuePair<string, AchievementManager.StoredAchievement> current in dictionary)
				{
					if (this._achievements.ContainsKey(current.Key))
					{
						this._achievements[current.Key].Load(current.Value.Conditions);
					}
				}
				if (SocialAPI.Achievements != null)
				{
					foreach (KeyValuePair<string, Achievement> current2 in this._achievements)
					{
						if (current2.Value.IsCompleted && !SocialAPI.Achievements.IsAchievementCompleted(current2.Key))
						{
							flag = true;
							current2.Value.ClearProgress();
						}
					}
				}
			}
			if (flag)
			{
				this.Save();
			}
		}

		// Token: 0x060013C2 RID: 5058 RVA: 0x0041C888 File Offset: 0x0041AA88
		private void AchievementCompleted(Achievement achievement)
		{
			this.Save();
			if (this.OnAchievementCompleted != null)
			{
				this.OnAchievementCompleted(achievement);
			}
		}

		// Token: 0x060013C3 RID: 5059 RVA: 0x0041C8A4 File Offset: 0x0041AAA4
		public void Register(Achievement achievement)
		{
			this._achievements.Add(achievement.Name, achievement);
			achievement.OnCompleted += new Achievement.AchievementCompleted(this.AchievementCompleted);
		}

		// Token: 0x060013C4 RID: 5060 RVA: 0x0041C8CC File Offset: 0x0041AACC
		public void RegisterIconIndex(string achievementName, int iconIndex)
		{
			this._achievementIconIndexes.Add(achievementName, iconIndex);
		}

		// Token: 0x060013C5 RID: 5061 RVA: 0x0041C8DC File Offset: 0x0041AADC
		public void RegisterAchievementCategory(string achievementName, AchievementCategory category)
		{
			this._achievements[achievementName].SetCategory(category);
		}

		// Token: 0x060013C6 RID: 5062 RVA: 0x0041C8F0 File Offset: 0x0041AAF0
		public Achievement GetAchievement(string achievementName)
		{
			Achievement result;
			if (this._achievements.TryGetValue(achievementName, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060013C7 RID: 5063 RVA: 0x0041C910 File Offset: 0x0041AB10
		public T GetCondition<T>(string achievementName, string conditionName) where T : AchievementCondition
		{
			return this.GetCondition(achievementName, conditionName) as T;
		}

		// Token: 0x060013C8 RID: 5064 RVA: 0x0041C924 File Offset: 0x0041AB24
		public AchievementCondition GetCondition(string achievementName, string conditionName)
		{
			Achievement achievement;
			if (this._achievements.TryGetValue(achievementName, out achievement))
			{
				return achievement.GetCondition(conditionName);
			}
			return null;
		}

		// Token: 0x060013C9 RID: 5065 RVA: 0x0041C94C File Offset: 0x0041AB4C
		public int GetIconIndex(string achievementName)
		{
			int result;
			if (this._achievementIconIndexes.TryGetValue(achievementName, out result))
			{
				return result;
			}
			return 0;
		}

		// Token: 0x040034D3 RID: 13523
		private string _savePath;

		// Token: 0x040034D4 RID: 13524
		private bool _isCloudSave;

		// Token: 0x040034D6 RID: 13526
		private Dictionary<string, Achievement> _achievements = new Dictionary<string, Achievement>();

		// Token: 0x040034D7 RID: 13527
		private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings();

		// Token: 0x040034D8 RID: 13528
		private byte[] _cryptoKey;

		// Token: 0x040034D9 RID: 13529
		private Dictionary<string, int> _achievementIconIndexes = new Dictionary<string, int>();

		// Token: 0x040034DA RID: 13530
		private static object _ioLock = new object();

		// Token: 0x020002C7 RID: 711
		private class StoredAchievement
		{
			// Token: 0x04003D7A RID: 15738
			public Dictionary<string, JObject> Conditions;
		}
	}
}

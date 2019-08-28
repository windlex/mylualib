using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Linq;
using Terraria.Localization;

namespace Terraria.IO
{
	// Token: 0x0200007F RID: 127
	public class Preferences
	{
		// Token: 0x06000A78 RID: 2680 RVA: 0x003BF754 File Offset: 0x003BD954
		public Preferences(string path, bool parseAllTypes = false, bool useBson = false)
		{
			this._path = path;
			this.UseBson = useBson;
			if (parseAllTypes)
			{
				this._serializerSettings = new JsonSerializerSettings
				{
					TypeNameHandling = TypeNameHandling.Auto,
					MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
					Formatting = Formatting.Indented
				};
				return;
			}
			this._serializerSettings = new JsonSerializerSettings
			{
				Formatting = Formatting.Indented
			};
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x003BFA94 File Offset: 0x003BDC94
		public void Clear()
		{
			this._data.Clear();
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x003BFAFC File Offset: 0x003BDCFC
		public bool Contains(string name)
		{
			object @lock = this._lock;
			bool result;
			lock (@lock)
			{
				result = this._data.ContainsKey(name);
			}
			return result;
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x003BFB44 File Offset: 0x003BDD44
		public T Get<T>(string name, T defaultValue)
		{
			object @lock = this._lock;
			T result;
			lock (@lock)
			{
				try
				{
					object obj;
					if (this._data.TryGetValue(name, out obj))
					{
						if (obj is T)
						{
							result = (T)((object)obj);
						}
						else if (obj is JObject)
						{
							result = JsonConvert.DeserializeObject<T>(((JObject)obj).ToString());
						}
						else
						{
							result = (T)((object)Convert.ChangeType(obj, typeof(T)));
						}
					}
					else
					{
						result = defaultValue;
					}
				}
				catch
				{
					result = defaultValue;
				}
			}
			return result;
		}

		// Token: 0x06000A7F RID: 2687 RVA: 0x003BFBE8 File Offset: 0x003BDDE8
		public void Get<T>(string name, ref T currentValue)
		{
			currentValue = this.Get<T>(name, currentValue);
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x003BFBFD File Offset: 0x003BDDFD
		public List<string> GetAllKeys()
		{
			return this._data.Keys.ToList<string>();
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x003BF7C4 File Offset: 0x003BD9C4
		public bool Load()
		{
			object @lock = this._lock;
			bool result;
			lock (@lock)
			{
				if (!File.Exists(this._path))
				{
					result = false;
				}
				else
				{
					try
					{
						if (!this.UseBson)
						{
							string value = File.ReadAllText(this._path);
							this._data = JsonConvert.DeserializeObject<Dictionary<string, object>>(value, this._serializerSettings);
						}
						else
						{
							using (FileStream fileStream = File.OpenRead(this._path))
							{
								using (BsonReader bsonReader = new BsonReader(fileStream))
								{
									JsonSerializer jsonSerializer = JsonSerializer.Create(this._serializerSettings);
									this._data = jsonSerializer.Deserialize<Dictionary<string, object>>(bsonReader);
								}
							}
						}
						if (this._data == null)
						{
							this._data = new Dictionary<string, object>();
						}
						if (this.OnLoad != null)
						{
							this.OnLoad(this);
						}
						result = true;
					}
					catch (Exception)
					{
						result = false;
					}
				}
			}
			return result;
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x003BFAA4 File Offset: 0x003BDCA4
		public void Put(string name, object value)
		{
			object @lock = this._lock;
			lock (@lock)
			{
				this._data[name] = value;
				if (this.AutoSave)
				{
					this.Save(true);
				}
			}
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x003BF8DC File Offset: 0x003BDADC
		public bool Save(bool createFile = true)
		{
			object @lock = this._lock;
			bool result;
			lock (@lock)
			{
				try
				{
					if (this.OnSave != null)
					{
						this.OnSave(this);
					}
					if (!createFile && !File.Exists(this._path))
					{
						result = false;
						return result;
					}
					Directory.GetParent(this._path).Create();
					if (!createFile)
					{
						File.SetAttributes(this._path, FileAttributes.Normal);
					}
					if (!this.UseBson)
					{
						string contents = JsonConvert.SerializeObject(this._data, this._serializerSettings);
						if (this.OnProcessText != null)
						{
							this.OnProcessText(ref contents);
						}
						File.WriteAllText(this._path, contents);
						File.SetAttributes(this._path, FileAttributes.Normal);
					}
					else
					{
						using (FileStream fileStream = File.Create(this._path))
						{
							using (BsonWriter bsonWriter = new BsonWriter(fileStream))
							{
								File.SetAttributes(this._path, FileAttributes.Normal);
								JsonSerializer.Create(this._serializerSettings).Serialize(bsonWriter, this._data);
							}
						}
					}
				}
				catch (Exception arg_11D_0)
				{
					Console.WriteLine(Language.GetTextValue("Error.UnableToWritePreferences", this._path));
					Console.WriteLine(arg_11D_0.ToString());
					Monitor.Exit(this._lock);
					result = false;
					return result;
				}
				result = true;
			}
			return result;
		}

		// Token: 0x14000010 RID: 16
		// Token: 0x06000A74 RID: 2676 RVA: 0x003BF674 File Offset: 0x003BD874
		// Token: 0x06000A75 RID: 2677 RVA: 0x003BF6AC File Offset: 0x003BD8AC
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event Action<Preferences> OnLoad;

		// Token: 0x14000011 RID: 17
		// Token: 0x06000A76 RID: 2678 RVA: 0x003BF6E4 File Offset: 0x003BD8E4
		// Token: 0x06000A77 RID: 2679 RVA: 0x003BF71C File Offset: 0x003BD91C
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event Preferences.TextProcessAction OnProcessText;

		// Token: 0x1400000F RID: 15
		// Token: 0x06000A72 RID: 2674 RVA: 0x003BF604 File Offset: 0x003BD804
		// Token: 0x06000A73 RID: 2675 RVA: 0x003BF63C File Offset: 0x003BD83C
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event Action<Preferences> OnSave;

		// Token: 0x04000E2F RID: 3631
		public bool AutoSave;

		// Token: 0x04000E2D RID: 3629
		public readonly bool UseBson;

		// Token: 0x04000E2A RID: 3626
		private Dictionary<string, object> _data = new Dictionary<string, object>();

		// Token: 0x04000E2E RID: 3630
		private readonly object _lock = new object();

		// Token: 0x04000E2B RID: 3627
		private readonly string _path;

		// Token: 0x04000E2C RID: 3628
		private readonly JsonSerializerSettings _serializerSettings;

		// Token: 0x0200022F RID: 559
		// Token: 0x06001585 RID: 5509
		public delegate void TextProcessAction(ref string text);
	}
}

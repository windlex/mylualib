using System;
using System.Collections.Generic;
using System.Linq;

namespace Terraria.GameInput
{
	// Token: 0x02000101 RID: 257
	public class KeyConfiguration
	{
		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000E25 RID: 3621 RVA: 0x003E78BC File Offset: 0x003E5ABC
		public bool DoGrappleAndInteractShareTheSameKey
		{
			get
			{
				return this.KeyStatus["Grapple"].Count > 0 && this.KeyStatus["MouseRight"].Count > 0 && this.KeyStatus["MouseRight"].Contains(this.KeyStatus["Grapple"][0]);
			}
		}

		// Token: 0x06000E26 RID: 3622 RVA: 0x003E7928 File Offset: 0x003E5B28
		public void SetupKeys()
		{
			this.KeyStatus.Clear();
			foreach (string current in PlayerInput.KnownTriggers)
			{
				this.KeyStatus.Add(current, new List<string>());
			}
		}

		// Token: 0x06000E27 RID: 3623 RVA: 0x003E7990 File Offset: 0x003E5B90
		public void Processkey(TriggersSet set, string newKey)
		{
			foreach (KeyValuePair<string, List<string>> current in this.KeyStatus)
			{
				if (current.Value.Contains(newKey))
				{
					set.KeyStatus[current.Key] = true;
				}
			}
			if (set.Up || set.Down || set.Left || set.Right || set.HotbarPlus || set.HotbarMinus || ((Main.gameMenu || Main.ingameOptionsWindow) && (set.MenuUp || set.MenuDown || set.MenuLeft || set.MenuRight)))
			{
				set.UsedMovementKey = true;
			}
		}

		// Token: 0x06000E28 RID: 3624 RVA: 0x003E7A64 File Offset: 0x003E5C64
		public void CopyKeyState(TriggersSet oldSet, TriggersSet newSet, string newKey)
		{
			foreach (KeyValuePair<string, List<string>> current in this.KeyStatus)
			{
				if (current.Value.Contains(newKey))
				{
					newSet.KeyStatus[current.Key] = oldSet.KeyStatus[current.Key];
				}
			}
		}

		// Token: 0x06000E29 RID: 3625 RVA: 0x003E7AE4 File Offset: 0x003E5CE4
		public void ReadPreferences(Dictionary<string, List<string>> dict)
		{
			foreach (KeyValuePair<string, List<string>> current in dict)
			{
				if (this.KeyStatus.ContainsKey(current.Key))
				{
					this.KeyStatus[current.Key].Clear();
					foreach (string current2 in current.Value)
					{
						this.KeyStatus[current.Key].Add(current2);
					}
				}
			}
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x003E7BB0 File Offset: 0x003E5DB0
		public Dictionary<string, List<string>> WritePreferences()
		{
			Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
			foreach (KeyValuePair<string, List<string>> current in this.KeyStatus)
			{
				if (current.Value.Count > 0)
				{
					dictionary.Add(current.Key, current.Value.ToList<string>());
				}
			}
			if (!dictionary.ContainsKey("MouseLeft") || dictionary["MouseLeft"].Count == 0)
			{
				dictionary.Add("MouseLeft", new List<string>
				{
					"Mouse1"
				});
			}
			if (!dictionary.ContainsKey("Inventory") || dictionary["Inventory"].Count == 0)
			{
				dictionary.Add("Inventory", new List<string>
				{
					"Escape"
				});
			}
			return dictionary;
		}

		// Token: 0x04002F95 RID: 12181
		public Dictionary<string, List<string>> KeyStatus = new Dictionary<string, List<string>>();
	}
}

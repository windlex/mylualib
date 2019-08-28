using System;
using System.Linq;

namespace Terraria.GameInput
{
	// Token: 0x02000105 RID: 261
	public class TriggersPack
	{
		// Token: 0x06000E53 RID: 3667 RVA: 0x003E99BC File Offset: 0x003E7BBC
		public void Initialize()
		{
			this.Current.SetupKeys();
			this.Old.SetupKeys();
			this.JustPressed.SetupKeys();
			this.JustReleased.SetupKeys();
		}

		// Token: 0x06000E54 RID: 3668 RVA: 0x003E99EC File Offset: 0x003E7BEC
		public void Reset()
		{
			this.Old = this.Current.Clone();
			this.Current.Reset();
		}

		// Token: 0x06000E55 RID: 3669 RVA: 0x003E9A0C File Offset: 0x003E7C0C
		public void Update()
		{
			this.CompareDiffs(this.JustPressed, this.Old, this.Current);
			this.CompareDiffs(this.JustReleased, this.Current, this.Old);
		}

		// Token: 0x06000E56 RID: 3670 RVA: 0x003E9A40 File Offset: 0x003E7C40
		public void CompareDiffs(TriggersSet Bearer, TriggersSet oldset, TriggersSet newset)
		{
			Bearer.Reset();
			foreach (string current in Bearer.KeyStatus.Keys.ToList<string>())
			{
				Bearer.KeyStatus[current] = (newset.KeyStatus[current] && !oldset.KeyStatus[current]);
			}
		}

		// Token: 0x04002FE3 RID: 12259
		public TriggersSet Current = new TriggersSet();

		// Token: 0x04002FE4 RID: 12260
		public TriggersSet Old = new TriggersSet();

		// Token: 0x04002FE5 RID: 12261
		public TriggersSet JustPressed = new TriggersSet();

		// Token: 0x04002FE6 RID: 12262
		public TriggersSet JustReleased = new TriggersSet();
	}
}

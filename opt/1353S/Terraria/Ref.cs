using System;

namespace Terraria
{
	// Token: 0x0200000D RID: 13
	public class Ref<T>
	{
		// Token: 0x06000076 RID: 118 RVA: 0x00008AF0 File Offset: 0x00006CF0
		public Ref()
		{
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00008AF8 File Offset: 0x00006CF8
		public Ref(T value)
		{
			this.Value = value;
		}

		// Token: 0x04000060 RID: 96
		public T Value;
	}
}

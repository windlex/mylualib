using System;

namespace Terraria.Modules
{
	// Token: 0x0200003D RID: 61
	public class AnchorTypesModule
	{
		// Token: 0x060008F5 RID: 2293 RVA: 0x003B4A30 File Offset: 0x003B2C30
		public AnchorTypesModule(AnchorTypesModule copyFrom = null)
		{
			if (copyFrom == null)
			{
				this.tileValid = null;
				this.tileInvalid = null;
				this.tileAlternates = null;
				this.wallValid = null;
				return;
			}
			if (copyFrom.tileValid == null)
			{
				this.tileValid = null;
			}
			else
			{
				this.tileValid = new int[copyFrom.tileValid.Length];
				Array.Copy(copyFrom.tileValid, this.tileValid, this.tileValid.Length);
			}
			if (copyFrom.tileInvalid == null)
			{
				this.tileInvalid = null;
			}
			else
			{
				this.tileInvalid = new int[copyFrom.tileInvalid.Length];
				Array.Copy(copyFrom.tileInvalid, this.tileInvalid, this.tileInvalid.Length);
			}
			if (copyFrom.tileAlternates == null)
			{
				this.tileAlternates = null;
			}
			else
			{
				this.tileAlternates = new int[copyFrom.tileAlternates.Length];
				Array.Copy(copyFrom.tileAlternates, this.tileAlternates, this.tileAlternates.Length);
			}
			if (copyFrom.wallValid == null)
			{
				this.wallValid = null;
				return;
			}
			this.wallValid = new int[copyFrom.wallValid.Length];
			Array.Copy(copyFrom.wallValid, this.wallValid, this.wallValid.Length);
		}

		// Token: 0x04000D5A RID: 3418
		public int[] tileValid;

		// Token: 0x04000D5B RID: 3419
		public int[] tileInvalid;

		// Token: 0x04000D5C RID: 3420
		public int[] tileAlternates;

		// Token: 0x04000D5D RID: 3421
		public int[] wallValid;
	}
}

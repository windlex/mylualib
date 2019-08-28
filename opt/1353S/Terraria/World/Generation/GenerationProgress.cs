using System;

namespace Terraria.World.Generation
{
	// Token: 0x0200004C RID: 76
	public class GenerationProgress
	{
		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000912 RID: 2322 RVA: 0x003B515C File Offset: 0x003B335C
		// (set) Token: 0x06000913 RID: 2323 RVA: 0x003B5174 File Offset: 0x003B3374
		public string Message
		{
			get
			{
				return string.Format(this._message, this.Value);
			}
			set
			{
				this._message = value.Replace("%", "{0:0.0%}");
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000915 RID: 2325 RVA: 0x003B51A4 File Offset: 0x003B33A4
		// (set) Token: 0x06000914 RID: 2324 RVA: 0x003B518C File Offset: 0x003B338C
		public float Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = Utils.Clamp<float>(value, 0f, 1f);
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000916 RID: 2326 RVA: 0x003B51AC File Offset: 0x003B33AC
		public float TotalProgress
		{
			get
			{
				if (this.TotalWeight == 0f)
				{
					return 0f;
				}
				return (this.Value * this.CurrentPassWeight + this._totalProgress) / this.TotalWeight;
			}
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x003B51DC File Offset: 0x003B33DC
		public void Set(float value)
		{
			this.Value = value;
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x003B51E8 File Offset: 0x003B33E8
		public void Start(float weight)
		{
			this.CurrentPassWeight = weight;
			this._value = 0f;
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x003B51FC File Offset: 0x003B33FC
		public void End()
		{
			this._totalProgress += this.CurrentPassWeight;
		}

		// Token: 0x04000D85 RID: 3461
		private string _message = "";

		// Token: 0x04000D86 RID: 3462
		private float _value;

		// Token: 0x04000D87 RID: 3463
		private float _totalProgress;

		// Token: 0x04000D88 RID: 3464
		public float TotalWeight;

		// Token: 0x04000D89 RID: 3465
		public float CurrentPassWeight = 1f;
	}
}

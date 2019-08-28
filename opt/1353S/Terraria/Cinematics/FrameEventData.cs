using System;

namespace Terraria.Cinematics
{
	// Token: 0x02000195 RID: 405
	public struct FrameEventData
	{
		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06001324 RID: 4900 RVA: 0x0041AFC8 File Offset: 0x004191C8
		public int AbsoluteFrame
		{
			get
			{
				return this._absoluteFrame;
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06001325 RID: 4901 RVA: 0x0041AFD0 File Offset: 0x004191D0
		public int Start
		{
			get
			{
				return this._start;
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06001326 RID: 4902 RVA: 0x0041AFD8 File Offset: 0x004191D8
		public int Duration
		{
			get
			{
				return this._duration;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06001327 RID: 4903 RVA: 0x0041AFE0 File Offset: 0x004191E0
		public int Frame
		{
			get
			{
				return this._absoluteFrame - this._start;
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06001328 RID: 4904 RVA: 0x0041AFF0 File Offset: 0x004191F0
		public bool IsFirstFrame
		{
			get
			{
				return this._start == this._absoluteFrame;
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06001329 RID: 4905 RVA: 0x0041B000 File Offset: 0x00419200
		public bool IsLastFrame
		{
			get
			{
				return this.Remaining == 0;
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x0600132A RID: 4906 RVA: 0x0041B00C File Offset: 0x0041920C
		public int Remaining
		{
			get
			{
				return this._start + this._duration - this._absoluteFrame - 1;
			}
		}

		// Token: 0x0600132B RID: 4907 RVA: 0x0041B024 File Offset: 0x00419224
		public FrameEventData(int absoluteFrame, int start, int duration)
		{
			this._absoluteFrame = absoluteFrame;
			this._start = start;
			this._duration = duration;
		}

		// Token: 0x0400349F RID: 13471
		private int _absoluteFrame;

		// Token: 0x040034A0 RID: 13472
		private int _start;

		// Token: 0x040034A1 RID: 13473
		private int _duration;
	}
}

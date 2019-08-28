using System;
using Microsoft.Xna.Framework.Audio;
using Terraria.Utilities;

namespace Terraria.Audio
{
	// Token: 0x020001A7 RID: 423
	public abstract class SoundStyle
	{
		// Token: 0x170001AB RID: 427
		// (get) Token: 0x0600138B RID: 5003 RVA: 0x0041BDE4 File Offset: 0x00419FE4
		public float Volume
		{
			get
			{
				return this._volume;
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x0600138C RID: 5004 RVA: 0x0041BDEC File Offset: 0x00419FEC
		public float PitchVariance
		{
			get
			{
				return this._pitchVariance;
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x0600138D RID: 5005 RVA: 0x0041BDF4 File Offset: 0x00419FF4
		public SoundType Type
		{
			get
			{
				return this._type;
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x0600138E RID: 5006
		public abstract bool IsTrackable
		{
			get;
		}

		// Token: 0x0600138F RID: 5007 RVA: 0x0041BDFC File Offset: 0x00419FFC
		public SoundStyle(float volume, float pitchVariance, SoundType type = SoundType.Sound)
		{
			this._volume = volume;
			this._pitchVariance = pitchVariance;
			this._type = type;
		}

		// Token: 0x06001390 RID: 5008 RVA: 0x0041BE1C File Offset: 0x0041A01C
		public SoundStyle(SoundType type = SoundType.Sound)
		{
			this._volume = 1f;
			this._pitchVariance = 0f;
			this._type = type;
		}

		// Token: 0x06001391 RID: 5009 RVA: 0x0041BE44 File Offset: 0x0041A044
		public float GetRandomPitch()
		{
			return SoundStyle._random.NextFloat() * this.PitchVariance - this.PitchVariance * 0.5f;
		}

		// Token: 0x06001392 RID: 5010
		public abstract SoundEffect GetRandomSound();

		// Token: 0x040034C1 RID: 13505
		private static UnifiedRandom _random = new UnifiedRandom();

		// Token: 0x040034C2 RID: 13506
		private float _volume;

		// Token: 0x040034C3 RID: 13507
		private float _pitchVariance;

		// Token: 0x040034C4 RID: 13508
		private SoundType _type;
	}
}

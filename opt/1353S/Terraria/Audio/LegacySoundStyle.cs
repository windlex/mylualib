using System;
using Microsoft.Xna.Framework.Audio;
using Terraria.Utilities;

namespace Terraria.Audio
{
	// Token: 0x020001A5 RID: 421
	public class LegacySoundStyle : SoundStyle
	{
		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x0600137C RID: 4988 RVA: 0x0041BC20 File Offset: 0x00419E20
		public int Style
		{
			get
			{
				if (this._styleVariations != 1)
				{
					return LegacySoundStyle._random.Next(this._style, this._style + this._styleVariations);
				}
				return this._style;
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x0600137D RID: 4989 RVA: 0x0041BC50 File Offset: 0x00419E50
		public int Variations
		{
			get
			{
				return this._styleVariations;
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x0600137E RID: 4990 RVA: 0x0041BC58 File Offset: 0x00419E58
		public int SoundId
		{
			get
			{
				return this._soundId;
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x0600137F RID: 4991 RVA: 0x0041BC60 File Offset: 0x00419E60
		public override bool IsTrackable
		{
			get
			{
				return this._soundId == 42;
			}
		}

		// Token: 0x06001380 RID: 4992 RVA: 0x0041BC6C File Offset: 0x00419E6C
		public LegacySoundStyle(int soundId, int style, SoundType type = SoundType.Sound) : base(type)
		{
			this._style = style;
			this._styleVariations = 1;
			this._soundId = soundId;
		}

		// Token: 0x06001381 RID: 4993 RVA: 0x0041BC8C File Offset: 0x00419E8C
		public LegacySoundStyle(int soundId, int style, int variations, SoundType type = SoundType.Sound) : base(type)
		{
			this._style = style;
			this._styleVariations = variations;
			this._soundId = soundId;
		}

		// Token: 0x06001382 RID: 4994 RVA: 0x0041BCAC File Offset: 0x00419EAC
		private LegacySoundStyle(int soundId, int style, int variations, SoundType type, float volume, float pitchVariance) : base(volume, pitchVariance, type)
		{
			this._style = style;
			this._styleVariations = variations;
			this._soundId = soundId;
		}

		// Token: 0x06001383 RID: 4995 RVA: 0x0041BCD0 File Offset: 0x00419ED0
		public LegacySoundStyle WithVolume(float volume)
		{
			return new LegacySoundStyle(this._soundId, this._style, this._styleVariations, base.Type, volume, base.PitchVariance);
		}

		// Token: 0x06001384 RID: 4996 RVA: 0x0041BCF8 File Offset: 0x00419EF8
		public LegacySoundStyle WithPitchVariance(float pitchVariance)
		{
			return new LegacySoundStyle(this._soundId, this._style, this._styleVariations, base.Type, base.Volume, pitchVariance);
		}

		// Token: 0x06001385 RID: 4997 RVA: 0x0041BD20 File Offset: 0x00419F20
		public LegacySoundStyle AsMusic()
		{
			return new LegacySoundStyle(this._soundId, this._style, this._styleVariations, SoundType.Music, base.Volume, base.PitchVariance);
		}

		// Token: 0x06001386 RID: 4998 RVA: 0x0041BD48 File Offset: 0x00419F48
		public LegacySoundStyle AsAmbient()
		{
			return new LegacySoundStyle(this._soundId, this._style, this._styleVariations, SoundType.Ambient, base.Volume, base.PitchVariance);
		}

		// Token: 0x06001387 RID: 4999 RVA: 0x0041BD70 File Offset: 0x00419F70
		public LegacySoundStyle AsSound()
		{
			return new LegacySoundStyle(this._soundId, this._style, this._styleVariations, SoundType.Sound, base.Volume, base.PitchVariance);
		}

		// Token: 0x06001388 RID: 5000 RVA: 0x0041BD98 File Offset: 0x00419F98
		public bool Includes(int soundId, int style)
		{
			return this._soundId == soundId && style >= this._style && style < this._style + this._styleVariations;
		}

		// Token: 0x06001389 RID: 5001 RVA: 0x0041BDC0 File Offset: 0x00419FC0
		public override SoundEffect GetRandomSound()
		{
			if (this.IsTrackable)
			{
				return Main.trackableSounds[this.Style];
			}
			return null;
		}

		// Token: 0x040034B9 RID: 13497
		private static UnifiedRandom _random = new UnifiedRandom();

		// Token: 0x040034BA RID: 13498
		private int _style;

		// Token: 0x040034BB RID: 13499
		private int _styleVariations;

		// Token: 0x040034BC RID: 13500
		private int _soundId;
	}
}

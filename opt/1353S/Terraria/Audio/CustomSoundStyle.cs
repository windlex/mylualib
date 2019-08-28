using System;
using Microsoft.Xna.Framework.Audio;
using Terraria.Utilities;

namespace Terraria.Audio
{
	// Token: 0x020001A4 RID: 420
	public class CustomSoundStyle : SoundStyle
	{
		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06001377 RID: 4983 RVA: 0x0041BBC4 File Offset: 0x00419DC4
		public override bool IsTrackable
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06001378 RID: 4984 RVA: 0x0041BBC8 File Offset: 0x00419DC8
		public CustomSoundStyle(SoundEffect soundEffect, SoundType type = SoundType.Sound, float volume = 1f, float pitchVariance = 0f) : base(volume, pitchVariance, type)
		{
			this._soundEffects = new SoundEffect[]
			{
				soundEffect
			};
		}

		// Token: 0x06001379 RID: 4985 RVA: 0x0041BBE4 File Offset: 0x00419DE4
		public CustomSoundStyle(SoundEffect[] soundEffects, SoundType type = SoundType.Sound, float volume = 1f, float pitchVariance = 0f) : base(volume, pitchVariance, type)
		{
			this._soundEffects = soundEffects;
		}

		// Token: 0x0600137A RID: 4986 RVA: 0x0041BBF8 File Offset: 0x00419DF8
		public override SoundEffect GetRandomSound()
		{
			return this._soundEffects[CustomSoundStyle._random.Next(this._soundEffects.Length)];
		}

		// Token: 0x040034B7 RID: 13495
		private static UnifiedRandom _random = new UnifiedRandom();

		// Token: 0x040034B8 RID: 13496
		private SoundEffect[] _soundEffects;
	}
}

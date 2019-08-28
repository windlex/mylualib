using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Terraria.Audio
{
	// Token: 0x020001A3 RID: 419
	public class ActiveSound
	{
		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x0600136D RID: 4973 RVA: 0x0041B980 File Offset: 0x00419B80
		public SoundEffectInstance Sound
		{
			get
			{
				return this._sound;
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x0600136E RID: 4974 RVA: 0x0041B988 File Offset: 0x00419B88
		public SoundStyle Style
		{
			get
			{
				return this._style;
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x0600136F RID: 4975 RVA: 0x0041B990 File Offset: 0x00419B90
		public bool IsPlaying
		{
			get
			{
				return this.Sound.State == SoundState.Playing;
			}
		}

		// Token: 0x06001370 RID: 4976 RVA: 0x0041B9A0 File Offset: 0x00419BA0
		public ActiveSound(SoundStyle style, Vector2 position)
		{
			this.Position = position;
			this.Volume = 1f;
			this.IsGlobal = false;
			this._style = style;
			this.Play();
		}

		// Token: 0x06001371 RID: 4977 RVA: 0x0041B9D0 File Offset: 0x00419BD0
		public ActiveSound(SoundStyle style)
		{
			this.Position = Vector2.Zero;
			this.Volume = 1f;
			this.IsGlobal = true;
			this._style = style;
			this.Play();
		}

		// Token: 0x06001372 RID: 4978 RVA: 0x0041BA04 File Offset: 0x00419C04
		private void Play()
		{
			SoundEffectInstance soundEffectInstance = this._style.GetRandomSound().CreateInstance();
			soundEffectInstance.Pitch += this._style.GetRandomPitch();
			Main.PlaySoundInstance(soundEffectInstance);
			this._sound = soundEffectInstance;
			this.Update();
		}

		// Token: 0x06001373 RID: 4979 RVA: 0x0041BA50 File Offset: 0x00419C50
		public void Stop()
		{
			if (this._sound != null)
			{
				this._sound.Stop();
			}
		}

		// Token: 0x06001374 RID: 4980 RVA: 0x0041BA68 File Offset: 0x00419C68
		public void Pause()
		{
			if (this._sound != null && this._sound.State == SoundState.Playing)
			{
				this._sound.Pause();
			}
		}

		// Token: 0x06001375 RID: 4981 RVA: 0x0041BA8C File Offset: 0x00419C8C
		public void Resume()
		{
			if (this._sound != null && this._sound.State == SoundState.Paused)
			{
				this._sound.Resume();
			}
		}

		// Token: 0x06001376 RID: 4982 RVA: 0x0041BAB0 File Offset: 0x00419CB0
		public void Update()
		{
			if (this._sound == null)
			{
				return;
			}
			Vector2 vector = Main.screenPosition + new Vector2((float)(Main.screenWidth / 2), (float)(Main.screenHeight / 2));
			float num = 1f;
			if (!this.IsGlobal)
			{
				float num2 = (this.Position.X - vector.X) / ((float)Main.screenWidth * 0.5f);
				num2 = MathHelper.Clamp(num2, -1f, 1f);
				this.Sound.Pan = num2;
				float num3 = Vector2.Distance(this.Position, vector);
				num = 1f - num3 / ((float)Main.screenWidth * 1.5f);
			}
			num *= this._style.Volume * this.Volume;
			switch (this._style.Type)
			{
			case SoundType.Sound:
				num *= Main.soundVolume;
				break;
			case SoundType.Ambient:
				num *= Main.ambientVolume;
				break;
			case SoundType.Music:
				num *= Main.musicVolume;
				break;
			}
			num = MathHelper.Clamp(num, 0f, 1f);
			this.Sound.Volume = num;
		}

		// Token: 0x040034B2 RID: 13490
		private SoundEffectInstance _sound;

		// Token: 0x040034B3 RID: 13491
		public readonly bool IsGlobal;

		// Token: 0x040034B4 RID: 13492
		public Vector2 Position;

		// Token: 0x040034B5 RID: 13493
		public float Volume;

		// Token: 0x040034B6 RID: 13494
		private SoundStyle _style;
	}
}

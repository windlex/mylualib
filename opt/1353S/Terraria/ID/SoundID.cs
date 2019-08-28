using System;
using System.Collections.Generic;
using Terraria.Audio;

namespace Terraria.ID
{
	// Token: 0x020000C9 RID: 201
	public static class SoundID
	{
		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000D05 RID: 3333 RVA: 0x003DC18C File Offset: 0x003DA38C
		public static int TrackableLegacySoundCount
		{
			get
			{
				return SoundID._trackableLegacySoundPathList.Count;
			}
		}

		// Token: 0x06000D06 RID: 3334 RVA: 0x003DC198 File Offset: 0x003DA398
		public static string GetTrackableLegacySoundPath(int id)
		{
			return SoundID._trackableLegacySoundPathList[id];
		}

		// Token: 0x06000D07 RID: 3335 RVA: 0x003DC1A8 File Offset: 0x003DA3A8
		private static LegacySoundStyle CreateTrackable(string name, SoundID.SoundStyleDefaults defaults)
		{
			return SoundID.CreateTrackable(name, 1, defaults.Type).WithPitchVariance(defaults.PitchVariance).WithVolume(defaults.Volume);
		}

		// Token: 0x06000D08 RID: 3336 RVA: 0x003DC1D0 File Offset: 0x003DA3D0
		private static LegacySoundStyle CreateTrackable(string name, int variations, SoundID.SoundStyleDefaults defaults)
		{
			return SoundID.CreateTrackable(name, variations, defaults.Type).WithPitchVariance(defaults.PitchVariance).WithVolume(defaults.Volume);
		}

		// Token: 0x06000D09 RID: 3337 RVA: 0x003DC1F8 File Offset: 0x003DA3F8
		private static LegacySoundStyle CreateTrackable(string name, SoundType type = SoundType.Sound)
		{
			return SoundID.CreateTrackable(name, 1, type);
		}

		// Token: 0x06000D0A RID: 3338 RVA: 0x003DC204 File Offset: 0x003DA404
		private static LegacySoundStyle CreateTrackable(string name, int variations, SoundType type = SoundType.Sound)
		{
			if (SoundID._trackableLegacySoundPathList == null)
			{
				SoundID._trackableLegacySoundPathList = new List<string>();
			}
			int count = SoundID._trackableLegacySoundPathList.Count;
			if (variations == 1)
			{
				SoundID._trackableLegacySoundPathList.Add(name);
			}
			else
			{
				for (int i = 0; i < variations; i++)
				{
					SoundID._trackableLegacySoundPathList.Add(name + "_" + i);
				}
			}
			return new LegacySoundStyle(42, count, variations, type);
		}

		// Token: 0x040010BD RID: 4285
		private static readonly SoundID.SoundStyleDefaults ItemDefaults = new SoundID.SoundStyleDefaults(1f, 0.06f, SoundType.Sound);

		// Token: 0x040010BE RID: 4286
		public const int Dig = 0;

		// Token: 0x040010BF RID: 4287
		public const int PlayerHit = 1;

		// Token: 0x040010C0 RID: 4288
		public const int Item = 2;

		// Token: 0x040010C1 RID: 4289
		public const int NPCHit = 3;

		// Token: 0x040010C2 RID: 4290
		public const int NPCKilled = 4;

		// Token: 0x040010C3 RID: 4291
		public const int PlayerKilled = 5;

		// Token: 0x040010C4 RID: 4292
		public const int Grass = 6;

		// Token: 0x040010C5 RID: 4293
		public const int Grab = 7;

		// Token: 0x040010C6 RID: 4294
		public const int DoorOpen = 8;

		// Token: 0x040010C7 RID: 4295
		public const int DoorClosed = 9;

		// Token: 0x040010C8 RID: 4296
		public const int MenuOpen = 10;

		// Token: 0x040010C9 RID: 4297
		public const int MenuClose = 11;

		// Token: 0x040010CA RID: 4298
		public const int MenuTick = 12;

		// Token: 0x040010CB RID: 4299
		public const int Shatter = 13;

		// Token: 0x040010CC RID: 4300
		public const int ZombieMoan = 14;

		// Token: 0x040010CD RID: 4301
		public const int Roar = 15;

		// Token: 0x040010CE RID: 4302
		public const int DoubleJump = 16;

		// Token: 0x040010CF RID: 4303
		public const int Run = 17;

		// Token: 0x040010D0 RID: 4304
		public const int Coins = 18;

		// Token: 0x040010D1 RID: 4305
		public const int Splash = 19;

		// Token: 0x040010D2 RID: 4306
		public const int FemaleHit = 20;

		// Token: 0x040010D3 RID: 4307
		public const int Tink = 21;

		// Token: 0x040010D4 RID: 4308
		public const int Unlock = 22;

		// Token: 0x040010D5 RID: 4309
		public const int Drown = 23;

		// Token: 0x040010D6 RID: 4310
		public const int Chat = 24;

		// Token: 0x040010D7 RID: 4311
		public const int MaxMana = 25;

		// Token: 0x040010D8 RID: 4312
		public const int Mummy = 26;

		// Token: 0x040010D9 RID: 4313
		public const int Pixie = 27;

		// Token: 0x040010DA RID: 4314
		public const int Mech = 28;

		// Token: 0x040010DB RID: 4315
		public const int Zombie = 29;

		// Token: 0x040010DC RID: 4316
		public const int Duck = 30;

		// Token: 0x040010DD RID: 4317
		public const int Frog = 31;

		// Token: 0x040010DE RID: 4318
		public const int Bird = 32;

		// Token: 0x040010DF RID: 4319
		public const int Critter = 33;

		// Token: 0x040010E0 RID: 4320
		public const int Waterfall = 34;

		// Token: 0x040010E1 RID: 4321
		public const int Lavafall = 35;

		// Token: 0x040010E2 RID: 4322
		public const int ForceRoar = 36;

		// Token: 0x040010E3 RID: 4323
		public const int Meowmere = 37;

		// Token: 0x040010E4 RID: 4324
		public const int CoinPickup = 38;

		// Token: 0x040010E5 RID: 4325
		public const int Drip = 39;

		// Token: 0x040010E6 RID: 4326
		public const int Camera = 40;

		// Token: 0x040010E7 RID: 4327
		public const int MoonLord = 41;

		// Token: 0x040010E8 RID: 4328
		public const int Trackable = 42;

		// Token: 0x040010E9 RID: 4329
		public static readonly LegacySoundStyle NPCHit1 = new LegacySoundStyle(3, 1, SoundType.Sound);

		// Token: 0x040010EA RID: 4330
		public static readonly LegacySoundStyle NPCHit2 = new LegacySoundStyle(3, 2, SoundType.Sound);

		// Token: 0x040010EB RID: 4331
		public static readonly LegacySoundStyle NPCHit3 = new LegacySoundStyle(3, 3, SoundType.Sound);

		// Token: 0x040010EC RID: 4332
		public static readonly LegacySoundStyle NPCHit4 = new LegacySoundStyle(3, 4, SoundType.Sound);

		// Token: 0x040010ED RID: 4333
		public static readonly LegacySoundStyle NPCHit5 = new LegacySoundStyle(3, 5, SoundType.Sound);

		// Token: 0x040010EE RID: 4334
		public static readonly LegacySoundStyle NPCHit6 = new LegacySoundStyle(3, 6, SoundType.Sound);

		// Token: 0x040010EF RID: 4335
		public static readonly LegacySoundStyle NPCHit7 = new LegacySoundStyle(3, 7, SoundType.Sound);

		// Token: 0x040010F0 RID: 4336
		public static readonly LegacySoundStyle NPCHit8 = new LegacySoundStyle(3, 8, SoundType.Sound);

		// Token: 0x040010F1 RID: 4337
		public static readonly LegacySoundStyle NPCHit9 = new LegacySoundStyle(3, 9, SoundType.Sound);

		// Token: 0x040010F2 RID: 4338
		public static readonly LegacySoundStyle NPCHit10 = new LegacySoundStyle(3, 10, SoundType.Sound);

		// Token: 0x040010F3 RID: 4339
		public static readonly LegacySoundStyle NPCHit11 = new LegacySoundStyle(3, 11, SoundType.Sound);

		// Token: 0x040010F4 RID: 4340
		public static readonly LegacySoundStyle NPCHit12 = new LegacySoundStyle(3, 12, SoundType.Sound);

		// Token: 0x040010F5 RID: 4341
		public static readonly LegacySoundStyle NPCHit13 = new LegacySoundStyle(3, 13, SoundType.Sound);

		// Token: 0x040010F6 RID: 4342
		public static readonly LegacySoundStyle NPCHit14 = new LegacySoundStyle(3, 14, SoundType.Sound);

		// Token: 0x040010F7 RID: 4343
		public static readonly LegacySoundStyle NPCHit15 = new LegacySoundStyle(3, 15, SoundType.Sound);

		// Token: 0x040010F8 RID: 4344
		public static readonly LegacySoundStyle NPCHit16 = new LegacySoundStyle(3, 16, SoundType.Sound);

		// Token: 0x040010F9 RID: 4345
		public static readonly LegacySoundStyle NPCHit17 = new LegacySoundStyle(3, 17, SoundType.Sound);

		// Token: 0x040010FA RID: 4346
		public static readonly LegacySoundStyle NPCHit18 = new LegacySoundStyle(3, 18, SoundType.Sound);

		// Token: 0x040010FB RID: 4347
		public static readonly LegacySoundStyle NPCHit19 = new LegacySoundStyle(3, 19, SoundType.Sound);

		// Token: 0x040010FC RID: 4348
		public static readonly LegacySoundStyle NPCHit20 = new LegacySoundStyle(3, 20, SoundType.Sound);

		// Token: 0x040010FD RID: 4349
		public static readonly LegacySoundStyle NPCHit21 = new LegacySoundStyle(3, 21, SoundType.Sound);

		// Token: 0x040010FE RID: 4350
		public static readonly LegacySoundStyle NPCHit22 = new LegacySoundStyle(3, 22, SoundType.Sound);

		// Token: 0x040010FF RID: 4351
		public static readonly LegacySoundStyle NPCHit23 = new LegacySoundStyle(3, 23, SoundType.Sound);

		// Token: 0x04001100 RID: 4352
		public static readonly LegacySoundStyle NPCHit24 = new LegacySoundStyle(3, 24, SoundType.Sound);

		// Token: 0x04001101 RID: 4353
		public static readonly LegacySoundStyle NPCHit25 = new LegacySoundStyle(3, 25, SoundType.Sound);

		// Token: 0x04001102 RID: 4354
		public static readonly LegacySoundStyle NPCHit26 = new LegacySoundStyle(3, 26, SoundType.Sound);

		// Token: 0x04001103 RID: 4355
		public static readonly LegacySoundStyle NPCHit27 = new LegacySoundStyle(3, 27, SoundType.Sound);

		// Token: 0x04001104 RID: 4356
		public static readonly LegacySoundStyle NPCHit28 = new LegacySoundStyle(3, 28, SoundType.Sound);

		// Token: 0x04001105 RID: 4357
		public static readonly LegacySoundStyle NPCHit29 = new LegacySoundStyle(3, 29, SoundType.Sound);

		// Token: 0x04001106 RID: 4358
		public static readonly LegacySoundStyle NPCHit30 = new LegacySoundStyle(3, 30, SoundType.Sound);

		// Token: 0x04001107 RID: 4359
		public static readonly LegacySoundStyle NPCHit31 = new LegacySoundStyle(3, 31, SoundType.Sound);

		// Token: 0x04001108 RID: 4360
		public static readonly LegacySoundStyle NPCHit32 = new LegacySoundStyle(3, 32, SoundType.Sound);

		// Token: 0x04001109 RID: 4361
		public static readonly LegacySoundStyle NPCHit33 = new LegacySoundStyle(3, 33, SoundType.Sound);

		// Token: 0x0400110A RID: 4362
		public static readonly LegacySoundStyle NPCHit34 = new LegacySoundStyle(3, 34, SoundType.Sound);

		// Token: 0x0400110B RID: 4363
		public static readonly LegacySoundStyle NPCHit35 = new LegacySoundStyle(3, 35, SoundType.Sound);

		// Token: 0x0400110C RID: 4364
		public static readonly LegacySoundStyle NPCHit36 = new LegacySoundStyle(3, 36, SoundType.Sound);

		// Token: 0x0400110D RID: 4365
		public static readonly LegacySoundStyle NPCHit37 = new LegacySoundStyle(3, 37, SoundType.Sound);

		// Token: 0x0400110E RID: 4366
		public static readonly LegacySoundStyle NPCHit38 = new LegacySoundStyle(3, 38, SoundType.Sound);

		// Token: 0x0400110F RID: 4367
		public static readonly LegacySoundStyle NPCHit39 = new LegacySoundStyle(3, 39, SoundType.Sound);

		// Token: 0x04001110 RID: 4368
		public static readonly LegacySoundStyle NPCHit40 = new LegacySoundStyle(3, 40, SoundType.Sound);

		// Token: 0x04001111 RID: 4369
		public static readonly LegacySoundStyle NPCHit41 = new LegacySoundStyle(3, 41, SoundType.Sound);

		// Token: 0x04001112 RID: 4370
		public static readonly LegacySoundStyle NPCHit42 = new LegacySoundStyle(3, 42, SoundType.Sound);

		// Token: 0x04001113 RID: 4371
		public static readonly LegacySoundStyle NPCHit43 = new LegacySoundStyle(3, 43, SoundType.Sound);

		// Token: 0x04001114 RID: 4372
		public static readonly LegacySoundStyle NPCHit44 = new LegacySoundStyle(3, 44, SoundType.Sound);

		// Token: 0x04001115 RID: 4373
		public static readonly LegacySoundStyle NPCHit45 = new LegacySoundStyle(3, 45, SoundType.Sound);

		// Token: 0x04001116 RID: 4374
		public static readonly LegacySoundStyle NPCHit46 = new LegacySoundStyle(3, 46, SoundType.Sound);

		// Token: 0x04001117 RID: 4375
		public static readonly LegacySoundStyle NPCHit47 = new LegacySoundStyle(3, 47, SoundType.Sound);

		// Token: 0x04001118 RID: 4376
		public static readonly LegacySoundStyle NPCHit48 = new LegacySoundStyle(3, 48, SoundType.Sound);

		// Token: 0x04001119 RID: 4377
		public static readonly LegacySoundStyle NPCHit49 = new LegacySoundStyle(3, 49, SoundType.Sound);

		// Token: 0x0400111A RID: 4378
		public static readonly LegacySoundStyle NPCHit50 = new LegacySoundStyle(3, 50, SoundType.Sound);

		// Token: 0x0400111B RID: 4379
		public static readonly LegacySoundStyle NPCHit51 = new LegacySoundStyle(3, 51, SoundType.Sound);

		// Token: 0x0400111C RID: 4380
		public static readonly LegacySoundStyle NPCHit52 = new LegacySoundStyle(3, 52, SoundType.Sound);

		// Token: 0x0400111D RID: 4381
		public static readonly LegacySoundStyle NPCHit53 = new LegacySoundStyle(3, 53, SoundType.Sound);

		// Token: 0x0400111E RID: 4382
		public static readonly LegacySoundStyle NPCHit54 = new LegacySoundStyle(3, 54, SoundType.Sound);

		// Token: 0x0400111F RID: 4383
		public static readonly LegacySoundStyle NPCHit55 = new LegacySoundStyle(3, 55, SoundType.Sound);

		// Token: 0x04001120 RID: 4384
		public static readonly LegacySoundStyle NPCHit56 = new LegacySoundStyle(3, 56, SoundType.Sound);

		// Token: 0x04001121 RID: 4385
		public static readonly LegacySoundStyle NPCHit57 = new LegacySoundStyle(3, 57, SoundType.Sound);

		// Token: 0x04001122 RID: 4386
		public static readonly LegacySoundStyle NPCDeath1 = new LegacySoundStyle(4, 1, SoundType.Sound);

		// Token: 0x04001123 RID: 4387
		public static readonly LegacySoundStyle NPCDeath2 = new LegacySoundStyle(4, 2, SoundType.Sound);

		// Token: 0x04001124 RID: 4388
		public static readonly LegacySoundStyle NPCDeath3 = new LegacySoundStyle(4, 3, SoundType.Sound);

		// Token: 0x04001125 RID: 4389
		public static readonly LegacySoundStyle NPCDeath4 = new LegacySoundStyle(4, 4, SoundType.Sound);

		// Token: 0x04001126 RID: 4390
		public static readonly LegacySoundStyle NPCDeath5 = new LegacySoundStyle(4, 5, SoundType.Sound);

		// Token: 0x04001127 RID: 4391
		public static readonly LegacySoundStyle NPCDeath6 = new LegacySoundStyle(4, 6, SoundType.Sound);

		// Token: 0x04001128 RID: 4392
		public static readonly LegacySoundStyle NPCDeath7 = new LegacySoundStyle(4, 7, SoundType.Sound);

		// Token: 0x04001129 RID: 4393
		public static readonly LegacySoundStyle NPCDeath8 = new LegacySoundStyle(4, 8, SoundType.Sound);

		// Token: 0x0400112A RID: 4394
		public static readonly LegacySoundStyle NPCDeath9 = new LegacySoundStyle(4, 9, SoundType.Sound);

		// Token: 0x0400112B RID: 4395
		public static readonly LegacySoundStyle NPCDeath10 = new LegacySoundStyle(4, 10, SoundType.Sound);

		// Token: 0x0400112C RID: 4396
		public static readonly LegacySoundStyle NPCDeath11 = new LegacySoundStyle(4, 11, SoundType.Sound);

		// Token: 0x0400112D RID: 4397
		public static readonly LegacySoundStyle NPCDeath12 = new LegacySoundStyle(4, 12, SoundType.Sound);

		// Token: 0x0400112E RID: 4398
		public static readonly LegacySoundStyle NPCDeath13 = new LegacySoundStyle(4, 13, SoundType.Sound);

		// Token: 0x0400112F RID: 4399
		public static readonly LegacySoundStyle NPCDeath14 = new LegacySoundStyle(4, 14, SoundType.Sound);

		// Token: 0x04001130 RID: 4400
		public static readonly LegacySoundStyle NPCDeath15 = new LegacySoundStyle(4, 15, SoundType.Sound);

		// Token: 0x04001131 RID: 4401
		public static readonly LegacySoundStyle NPCDeath16 = new LegacySoundStyle(4, 16, SoundType.Sound);

		// Token: 0x04001132 RID: 4402
		public static readonly LegacySoundStyle NPCDeath17 = new LegacySoundStyle(4, 17, SoundType.Sound);

		// Token: 0x04001133 RID: 4403
		public static readonly LegacySoundStyle NPCDeath18 = new LegacySoundStyle(4, 18, SoundType.Sound);

		// Token: 0x04001134 RID: 4404
		public static readonly LegacySoundStyle NPCDeath19 = new LegacySoundStyle(4, 19, SoundType.Sound);

		// Token: 0x04001135 RID: 4405
		public static readonly LegacySoundStyle NPCDeath20 = new LegacySoundStyle(4, 20, SoundType.Sound);

		// Token: 0x04001136 RID: 4406
		public static readonly LegacySoundStyle NPCDeath21 = new LegacySoundStyle(4, 21, SoundType.Sound);

		// Token: 0x04001137 RID: 4407
		public static readonly LegacySoundStyle NPCDeath22 = new LegacySoundStyle(4, 22, SoundType.Sound);

		// Token: 0x04001138 RID: 4408
		public static readonly LegacySoundStyle NPCDeath23 = new LegacySoundStyle(4, 23, SoundType.Sound);

		// Token: 0x04001139 RID: 4409
		public static readonly LegacySoundStyle NPCDeath24 = new LegacySoundStyle(4, 24, SoundType.Sound);

		// Token: 0x0400113A RID: 4410
		public static readonly LegacySoundStyle NPCDeath25 = new LegacySoundStyle(4, 25, SoundType.Sound);

		// Token: 0x0400113B RID: 4411
		public static readonly LegacySoundStyle NPCDeath26 = new LegacySoundStyle(4, 26, SoundType.Sound);

		// Token: 0x0400113C RID: 4412
		public static readonly LegacySoundStyle NPCDeath27 = new LegacySoundStyle(4, 27, SoundType.Sound);

		// Token: 0x0400113D RID: 4413
		public static readonly LegacySoundStyle NPCDeath28 = new LegacySoundStyle(4, 28, SoundType.Sound);

		// Token: 0x0400113E RID: 4414
		public static readonly LegacySoundStyle NPCDeath29 = new LegacySoundStyle(4, 29, SoundType.Sound);

		// Token: 0x0400113F RID: 4415
		public static readonly LegacySoundStyle NPCDeath30 = new LegacySoundStyle(4, 30, SoundType.Sound);

		// Token: 0x04001140 RID: 4416
		public static readonly LegacySoundStyle NPCDeath31 = new LegacySoundStyle(4, 31, SoundType.Sound);

		// Token: 0x04001141 RID: 4417
		public static readonly LegacySoundStyle NPCDeath32 = new LegacySoundStyle(4, 32, SoundType.Sound);

		// Token: 0x04001142 RID: 4418
		public static readonly LegacySoundStyle NPCDeath33 = new LegacySoundStyle(4, 33, SoundType.Sound);

		// Token: 0x04001143 RID: 4419
		public static readonly LegacySoundStyle NPCDeath34 = new LegacySoundStyle(4, 34, SoundType.Sound);

		// Token: 0x04001144 RID: 4420
		public static readonly LegacySoundStyle NPCDeath35 = new LegacySoundStyle(4, 35, SoundType.Sound);

		// Token: 0x04001145 RID: 4421
		public static readonly LegacySoundStyle NPCDeath36 = new LegacySoundStyle(4, 36, SoundType.Sound);

		// Token: 0x04001146 RID: 4422
		public static readonly LegacySoundStyle NPCDeath37 = new LegacySoundStyle(4, 37, SoundType.Sound);

		// Token: 0x04001147 RID: 4423
		public static readonly LegacySoundStyle NPCDeath38 = new LegacySoundStyle(4, 38, SoundType.Sound);

		// Token: 0x04001148 RID: 4424
		public static readonly LegacySoundStyle NPCDeath39 = new LegacySoundStyle(4, 39, SoundType.Sound);

		// Token: 0x04001149 RID: 4425
		public static readonly LegacySoundStyle NPCDeath40 = new LegacySoundStyle(4, 40, SoundType.Sound);

		// Token: 0x0400114A RID: 4426
		public static readonly LegacySoundStyle NPCDeath41 = new LegacySoundStyle(4, 41, SoundType.Sound);

		// Token: 0x0400114B RID: 4427
		public static readonly LegacySoundStyle NPCDeath42 = new LegacySoundStyle(4, 42, SoundType.Sound);

		// Token: 0x0400114C RID: 4428
		public static readonly LegacySoundStyle NPCDeath43 = new LegacySoundStyle(4, 43, SoundType.Sound);

		// Token: 0x0400114D RID: 4429
		public static readonly LegacySoundStyle NPCDeath44 = new LegacySoundStyle(4, 44, SoundType.Sound);

		// Token: 0x0400114E RID: 4430
		public static readonly LegacySoundStyle NPCDeath45 = new LegacySoundStyle(4, 45, SoundType.Sound);

		// Token: 0x0400114F RID: 4431
		public static readonly LegacySoundStyle NPCDeath46 = new LegacySoundStyle(4, 46, SoundType.Sound);

		// Token: 0x04001150 RID: 4432
		public static readonly LegacySoundStyle NPCDeath47 = new LegacySoundStyle(4, 47, SoundType.Sound);

		// Token: 0x04001151 RID: 4433
		public static readonly LegacySoundStyle NPCDeath48 = new LegacySoundStyle(4, 48, SoundType.Sound);

		// Token: 0x04001152 RID: 4434
		public static readonly LegacySoundStyle NPCDeath49 = new LegacySoundStyle(4, 49, SoundType.Sound);

		// Token: 0x04001153 RID: 4435
		public static readonly LegacySoundStyle NPCDeath50 = new LegacySoundStyle(4, 50, SoundType.Sound);

		// Token: 0x04001154 RID: 4436
		public static readonly LegacySoundStyle NPCDeath51 = new LegacySoundStyle(4, 51, SoundType.Sound);

		// Token: 0x04001155 RID: 4437
		public static readonly LegacySoundStyle NPCDeath52 = new LegacySoundStyle(4, 52, SoundType.Sound);

		// Token: 0x04001156 RID: 4438
		public static readonly LegacySoundStyle NPCDeath53 = new LegacySoundStyle(4, 53, SoundType.Sound);

		// Token: 0x04001157 RID: 4439
		public static readonly LegacySoundStyle NPCDeath54 = new LegacySoundStyle(4, 54, SoundType.Sound);

		// Token: 0x04001158 RID: 4440
		public static readonly LegacySoundStyle NPCDeath55 = new LegacySoundStyle(4, 55, SoundType.Sound);

		// Token: 0x04001159 RID: 4441
		public static readonly LegacySoundStyle NPCDeath56 = new LegacySoundStyle(4, 56, SoundType.Sound);

		// Token: 0x0400115A RID: 4442
		public static readonly LegacySoundStyle NPCDeath57 = new LegacySoundStyle(4, 57, SoundType.Sound);

		// Token: 0x0400115B RID: 4443
		public static readonly LegacySoundStyle NPCDeath58 = new LegacySoundStyle(4, 58, SoundType.Sound);

		// Token: 0x0400115C RID: 4444
		public static readonly LegacySoundStyle NPCDeath59 = new LegacySoundStyle(4, 59, SoundType.Sound);

		// Token: 0x0400115D RID: 4445
		public static readonly LegacySoundStyle NPCDeath60 = new LegacySoundStyle(4, 60, SoundType.Sound);

		// Token: 0x0400115E RID: 4446
		public static readonly LegacySoundStyle NPCDeath61 = new LegacySoundStyle(4, 61, SoundType.Sound);

		// Token: 0x0400115F RID: 4447
		public static readonly LegacySoundStyle NPCDeath62 = new LegacySoundStyle(4, 62, SoundType.Sound);

		// Token: 0x04001160 RID: 4448
		public static readonly LegacySoundStyle Item1 = new LegacySoundStyle(2, 1, SoundType.Sound);

		// Token: 0x04001161 RID: 4449
		public static readonly LegacySoundStyle Item2 = new LegacySoundStyle(2, 2, SoundType.Sound);

		// Token: 0x04001162 RID: 4450
		public static readonly LegacySoundStyle Item3 = new LegacySoundStyle(2, 3, SoundType.Sound);

		// Token: 0x04001163 RID: 4451
		public static readonly LegacySoundStyle Item4 = new LegacySoundStyle(2, 4, SoundType.Sound);

		// Token: 0x04001164 RID: 4452
		public static readonly LegacySoundStyle Item5 = new LegacySoundStyle(2, 5, SoundType.Sound);

		// Token: 0x04001165 RID: 4453
		public static readonly LegacySoundStyle Item6 = new LegacySoundStyle(2, 6, SoundType.Sound);

		// Token: 0x04001166 RID: 4454
		public static readonly LegacySoundStyle Item7 = new LegacySoundStyle(2, 7, SoundType.Sound);

		// Token: 0x04001167 RID: 4455
		public static readonly LegacySoundStyle Item8 = new LegacySoundStyle(2, 8, SoundType.Sound);

		// Token: 0x04001168 RID: 4456
		public static readonly LegacySoundStyle Item9 = new LegacySoundStyle(2, 9, SoundType.Sound);

		// Token: 0x04001169 RID: 4457
		public static readonly LegacySoundStyle Item10 = new LegacySoundStyle(2, 10, SoundType.Sound);

		// Token: 0x0400116A RID: 4458
		public static readonly LegacySoundStyle Item11 = new LegacySoundStyle(2, 11, SoundType.Sound);

		// Token: 0x0400116B RID: 4459
		public static readonly LegacySoundStyle Item12 = new LegacySoundStyle(2, 12, SoundType.Sound);

		// Token: 0x0400116C RID: 4460
		public static readonly LegacySoundStyle Item13 = new LegacySoundStyle(2, 13, SoundType.Sound);

		// Token: 0x0400116D RID: 4461
		public static readonly LegacySoundStyle Item14 = new LegacySoundStyle(2, 14, SoundType.Sound);

		// Token: 0x0400116E RID: 4462
		public static readonly LegacySoundStyle Item15 = new LegacySoundStyle(2, 15, SoundType.Sound);

		// Token: 0x0400116F RID: 4463
		public static readonly LegacySoundStyle Item16 = new LegacySoundStyle(2, 16, SoundType.Sound);

		// Token: 0x04001170 RID: 4464
		public static readonly LegacySoundStyle Item17 = new LegacySoundStyle(2, 17, SoundType.Sound);

		// Token: 0x04001171 RID: 4465
		public static readonly LegacySoundStyle Item18 = new LegacySoundStyle(2, 18, SoundType.Sound);

		// Token: 0x04001172 RID: 4466
		public static readonly LegacySoundStyle Item19 = new LegacySoundStyle(2, 19, SoundType.Sound);

		// Token: 0x04001173 RID: 4467
		public static readonly LegacySoundStyle Item20 = new LegacySoundStyle(2, 20, SoundType.Sound);

		// Token: 0x04001174 RID: 4468
		public static readonly LegacySoundStyle Item21 = new LegacySoundStyle(2, 21, SoundType.Sound);

		// Token: 0x04001175 RID: 4469
		public static readonly LegacySoundStyle Item22 = new LegacySoundStyle(2, 22, SoundType.Sound);

		// Token: 0x04001176 RID: 4470
		public static readonly LegacySoundStyle Item23 = new LegacySoundStyle(2, 23, SoundType.Sound);

		// Token: 0x04001177 RID: 4471
		public static readonly LegacySoundStyle Item24 = new LegacySoundStyle(2, 24, SoundType.Sound);

		// Token: 0x04001178 RID: 4472
		public static readonly LegacySoundStyle Item25 = new LegacySoundStyle(2, 25, SoundType.Sound);

		// Token: 0x04001179 RID: 4473
		public static readonly LegacySoundStyle Item26 = new LegacySoundStyle(2, 26, SoundType.Sound);

		// Token: 0x0400117A RID: 4474
		public static readonly LegacySoundStyle Item27 = new LegacySoundStyle(2, 27, SoundType.Sound);

		// Token: 0x0400117B RID: 4475
		public static readonly LegacySoundStyle Item28 = new LegacySoundStyle(2, 28, SoundType.Sound);

		// Token: 0x0400117C RID: 4476
		public static readonly LegacySoundStyle Item29 = new LegacySoundStyle(2, 29, SoundType.Sound);

		// Token: 0x0400117D RID: 4477
		public static readonly LegacySoundStyle Item30 = new LegacySoundStyle(2, 30, SoundType.Sound);

		// Token: 0x0400117E RID: 4478
		public static readonly LegacySoundStyle Item31 = new LegacySoundStyle(2, 31, SoundType.Sound);

		// Token: 0x0400117F RID: 4479
		public static readonly LegacySoundStyle Item32 = new LegacySoundStyle(2, 32, SoundType.Sound);

		// Token: 0x04001180 RID: 4480
		public static readonly LegacySoundStyle Item33 = new LegacySoundStyle(2, 33, SoundType.Sound);

		// Token: 0x04001181 RID: 4481
		public static readonly LegacySoundStyle Item34 = new LegacySoundStyle(2, 34, SoundType.Sound);

		// Token: 0x04001182 RID: 4482
		public static readonly LegacySoundStyle Item35 = new LegacySoundStyle(2, 35, SoundType.Sound);

		// Token: 0x04001183 RID: 4483
		public static readonly LegacySoundStyle Item36 = new LegacySoundStyle(2, 36, SoundType.Sound);

		// Token: 0x04001184 RID: 4484
		public static readonly LegacySoundStyle Item37 = new LegacySoundStyle(2, 37, SoundType.Sound);

		// Token: 0x04001185 RID: 4485
		public static readonly LegacySoundStyle Item38 = new LegacySoundStyle(2, 38, SoundType.Sound);

		// Token: 0x04001186 RID: 4486
		public static readonly LegacySoundStyle Item39 = new LegacySoundStyle(2, 39, SoundType.Sound);

		// Token: 0x04001187 RID: 4487
		public static readonly LegacySoundStyle Item40 = new LegacySoundStyle(2, 40, SoundType.Sound);

		// Token: 0x04001188 RID: 4488
		public static readonly LegacySoundStyle Item41 = new LegacySoundStyle(2, 41, SoundType.Sound);

		// Token: 0x04001189 RID: 4489
		public static readonly LegacySoundStyle Item42 = new LegacySoundStyle(2, 42, SoundType.Sound);

		// Token: 0x0400118A RID: 4490
		public static readonly LegacySoundStyle Item43 = new LegacySoundStyle(2, 43, SoundType.Sound);

		// Token: 0x0400118B RID: 4491
		public static readonly LegacySoundStyle Item44 = new LegacySoundStyle(2, 44, SoundType.Sound);

		// Token: 0x0400118C RID: 4492
		public static readonly LegacySoundStyle Item45 = new LegacySoundStyle(2, 45, SoundType.Sound);

		// Token: 0x0400118D RID: 4493
		public static readonly LegacySoundStyle Item46 = new LegacySoundStyle(2, 46, SoundType.Sound);

		// Token: 0x0400118E RID: 4494
		public static readonly LegacySoundStyle Item47 = new LegacySoundStyle(2, 47, SoundType.Sound);

		// Token: 0x0400118F RID: 4495
		public static readonly LegacySoundStyle Item48 = new LegacySoundStyle(2, 48, SoundType.Sound);

		// Token: 0x04001190 RID: 4496
		public static readonly LegacySoundStyle Item49 = new LegacySoundStyle(2, 49, SoundType.Sound);

		// Token: 0x04001191 RID: 4497
		public static readonly LegacySoundStyle Item50 = new LegacySoundStyle(2, 50, SoundType.Sound);

		// Token: 0x04001192 RID: 4498
		public static readonly LegacySoundStyle Item51 = new LegacySoundStyle(2, 51, SoundType.Sound);

		// Token: 0x04001193 RID: 4499
		public static readonly LegacySoundStyle Item52 = new LegacySoundStyle(2, 52, SoundType.Sound);

		// Token: 0x04001194 RID: 4500
		public static readonly LegacySoundStyle Item53 = new LegacySoundStyle(2, 53, SoundType.Sound);

		// Token: 0x04001195 RID: 4501
		public static readonly LegacySoundStyle Item54 = new LegacySoundStyle(2, 54, SoundType.Sound);

		// Token: 0x04001196 RID: 4502
		public static readonly LegacySoundStyle Item55 = new LegacySoundStyle(2, 55, SoundType.Sound);

		// Token: 0x04001197 RID: 4503
		public static readonly LegacySoundStyle Item56 = new LegacySoundStyle(2, 56, SoundType.Sound);

		// Token: 0x04001198 RID: 4504
		public static readonly LegacySoundStyle Item57 = new LegacySoundStyle(2, 57, SoundType.Sound);

		// Token: 0x04001199 RID: 4505
		public static readonly LegacySoundStyle Item58 = new LegacySoundStyle(2, 58, SoundType.Sound);

		// Token: 0x0400119A RID: 4506
		public static readonly LegacySoundStyle Item59 = new LegacySoundStyle(2, 59, SoundType.Sound);

		// Token: 0x0400119B RID: 4507
		public static readonly LegacySoundStyle Item60 = new LegacySoundStyle(2, 60, SoundType.Sound);

		// Token: 0x0400119C RID: 4508
		public static readonly LegacySoundStyle Item61 = new LegacySoundStyle(2, 61, SoundType.Sound);

		// Token: 0x0400119D RID: 4509
		public static readonly LegacySoundStyle Item62 = new LegacySoundStyle(2, 62, SoundType.Sound);

		// Token: 0x0400119E RID: 4510
		public static readonly LegacySoundStyle Item63 = new LegacySoundStyle(2, 63, SoundType.Sound);

		// Token: 0x0400119F RID: 4511
		public static readonly LegacySoundStyle Item64 = new LegacySoundStyle(2, 64, SoundType.Sound);

		// Token: 0x040011A0 RID: 4512
		public static readonly LegacySoundStyle Item65 = new LegacySoundStyle(2, 65, SoundType.Sound);

		// Token: 0x040011A1 RID: 4513
		public static readonly LegacySoundStyle Item66 = new LegacySoundStyle(2, 66, SoundType.Sound);

		// Token: 0x040011A2 RID: 4514
		public static readonly LegacySoundStyle Item67 = new LegacySoundStyle(2, 67, SoundType.Sound);

		// Token: 0x040011A3 RID: 4515
		public static readonly LegacySoundStyle Item68 = new LegacySoundStyle(2, 68, SoundType.Sound);

		// Token: 0x040011A4 RID: 4516
		public static readonly LegacySoundStyle Item69 = new LegacySoundStyle(2, 69, SoundType.Sound);

		// Token: 0x040011A5 RID: 4517
		public static readonly LegacySoundStyle Item70 = new LegacySoundStyle(2, 70, SoundType.Sound);

		// Token: 0x040011A6 RID: 4518
		public static readonly LegacySoundStyle Item71 = new LegacySoundStyle(2, 71, SoundType.Sound);

		// Token: 0x040011A7 RID: 4519
		public static readonly LegacySoundStyle Item72 = new LegacySoundStyle(2, 72, SoundType.Sound);

		// Token: 0x040011A8 RID: 4520
		public static readonly LegacySoundStyle Item73 = new LegacySoundStyle(2, 73, SoundType.Sound);

		// Token: 0x040011A9 RID: 4521
		public static readonly LegacySoundStyle Item74 = new LegacySoundStyle(2, 74, SoundType.Sound);

		// Token: 0x040011AA RID: 4522
		public static readonly LegacySoundStyle Item75 = new LegacySoundStyle(2, 75, SoundType.Sound);

		// Token: 0x040011AB RID: 4523
		public static readonly LegacySoundStyle Item76 = new LegacySoundStyle(2, 76, SoundType.Sound);

		// Token: 0x040011AC RID: 4524
		public static readonly LegacySoundStyle Item77 = new LegacySoundStyle(2, 77, SoundType.Sound);

		// Token: 0x040011AD RID: 4525
		public static readonly LegacySoundStyle Item78 = new LegacySoundStyle(2, 78, SoundType.Sound);

		// Token: 0x040011AE RID: 4526
		public static readonly LegacySoundStyle Item79 = new LegacySoundStyle(2, 79, SoundType.Sound);

		// Token: 0x040011AF RID: 4527
		public static readonly LegacySoundStyle Item80 = new LegacySoundStyle(2, 80, SoundType.Sound);

		// Token: 0x040011B0 RID: 4528
		public static readonly LegacySoundStyle Item81 = new LegacySoundStyle(2, 81, SoundType.Sound);

		// Token: 0x040011B1 RID: 4529
		public static readonly LegacySoundStyle Item82 = new LegacySoundStyle(2, 82, SoundType.Sound);

		// Token: 0x040011B2 RID: 4530
		public static readonly LegacySoundStyle Item83 = new LegacySoundStyle(2, 83, SoundType.Sound);

		// Token: 0x040011B3 RID: 4531
		public static readonly LegacySoundStyle Item84 = new LegacySoundStyle(2, 84, SoundType.Sound);

		// Token: 0x040011B4 RID: 4532
		public static readonly LegacySoundStyle Item85 = new LegacySoundStyle(2, 85, SoundType.Sound);

		// Token: 0x040011B5 RID: 4533
		public static readonly LegacySoundStyle Item86 = new LegacySoundStyle(2, 86, SoundType.Sound);

		// Token: 0x040011B6 RID: 4534
		public static readonly LegacySoundStyle Item87 = new LegacySoundStyle(2, 87, SoundType.Sound);

		// Token: 0x040011B7 RID: 4535
		public static readonly LegacySoundStyle Item88 = new LegacySoundStyle(2, 88, SoundType.Sound);

		// Token: 0x040011B8 RID: 4536
		public static readonly LegacySoundStyle Item89 = new LegacySoundStyle(2, 89, SoundType.Sound);

		// Token: 0x040011B9 RID: 4537
		public static readonly LegacySoundStyle Item90 = new LegacySoundStyle(2, 90, SoundType.Sound);

		// Token: 0x040011BA RID: 4538
		public static readonly LegacySoundStyle Item91 = new LegacySoundStyle(2, 91, SoundType.Sound);

		// Token: 0x040011BB RID: 4539
		public static readonly LegacySoundStyle Item92 = new LegacySoundStyle(2, 92, SoundType.Sound);

		// Token: 0x040011BC RID: 4540
		public static readonly LegacySoundStyle Item93 = new LegacySoundStyle(2, 93, SoundType.Sound);

		// Token: 0x040011BD RID: 4541
		public static readonly LegacySoundStyle Item94 = new LegacySoundStyle(2, 94, SoundType.Sound);

		// Token: 0x040011BE RID: 4542
		public static readonly LegacySoundStyle Item95 = new LegacySoundStyle(2, 95, SoundType.Sound);

		// Token: 0x040011BF RID: 4543
		public static readonly LegacySoundStyle Item96 = new LegacySoundStyle(2, 96, SoundType.Sound);

		// Token: 0x040011C0 RID: 4544
		public static readonly LegacySoundStyle Item97 = new LegacySoundStyle(2, 97, SoundType.Sound);

		// Token: 0x040011C1 RID: 4545
		public static readonly LegacySoundStyle Item98 = new LegacySoundStyle(2, 98, SoundType.Sound);

		// Token: 0x040011C2 RID: 4546
		public static readonly LegacySoundStyle Item99 = new LegacySoundStyle(2, 99, SoundType.Sound);

		// Token: 0x040011C3 RID: 4547
		public static readonly LegacySoundStyle Item100 = new LegacySoundStyle(2, 100, SoundType.Sound);

		// Token: 0x040011C4 RID: 4548
		public static readonly LegacySoundStyle Item101 = new LegacySoundStyle(2, 101, SoundType.Sound);

		// Token: 0x040011C5 RID: 4549
		public static readonly LegacySoundStyle Item102 = new LegacySoundStyle(2, 102, SoundType.Sound);

		// Token: 0x040011C6 RID: 4550
		public static readonly LegacySoundStyle Item103 = new LegacySoundStyle(2, 103, SoundType.Sound);

		// Token: 0x040011C7 RID: 4551
		public static readonly LegacySoundStyle Item104 = new LegacySoundStyle(2, 104, SoundType.Sound);

		// Token: 0x040011C8 RID: 4552
		public static readonly LegacySoundStyle Item105 = new LegacySoundStyle(2, 105, SoundType.Sound);

		// Token: 0x040011C9 RID: 4553
		public static readonly LegacySoundStyle Item106 = new LegacySoundStyle(2, 106, SoundType.Sound);

		// Token: 0x040011CA RID: 4554
		public static readonly LegacySoundStyle Item107 = new LegacySoundStyle(2, 107, SoundType.Sound);

		// Token: 0x040011CB RID: 4555
		public static readonly LegacySoundStyle Item108 = new LegacySoundStyle(2, 108, SoundType.Sound);

		// Token: 0x040011CC RID: 4556
		public static readonly LegacySoundStyle Item109 = new LegacySoundStyle(2, 109, SoundType.Sound);

		// Token: 0x040011CD RID: 4557
		public static readonly LegacySoundStyle Item110 = new LegacySoundStyle(2, 110, SoundType.Sound);

		// Token: 0x040011CE RID: 4558
		public static readonly LegacySoundStyle Item111 = new LegacySoundStyle(2, 111, SoundType.Sound);

		// Token: 0x040011CF RID: 4559
		public static readonly LegacySoundStyle Item112 = new LegacySoundStyle(2, 112, SoundType.Sound);

		// Token: 0x040011D0 RID: 4560
		public static readonly LegacySoundStyle Item113 = new LegacySoundStyle(2, 113, SoundType.Sound);

		// Token: 0x040011D1 RID: 4561
		public static readonly LegacySoundStyle Item114 = new LegacySoundStyle(2, 114, SoundType.Sound);

		// Token: 0x040011D2 RID: 4562
		public static readonly LegacySoundStyle Item115 = new LegacySoundStyle(2, 115, SoundType.Sound);

		// Token: 0x040011D3 RID: 4563
		public static readonly LegacySoundStyle Item116 = new LegacySoundStyle(2, 116, SoundType.Sound);

		// Token: 0x040011D4 RID: 4564
		public static readonly LegacySoundStyle Item117 = new LegacySoundStyle(2, 117, SoundType.Sound);

		// Token: 0x040011D5 RID: 4565
		public static readonly LegacySoundStyle Item118 = new LegacySoundStyle(2, 118, SoundType.Sound);

		// Token: 0x040011D6 RID: 4566
		public static readonly LegacySoundStyle Item119 = new LegacySoundStyle(2, 119, SoundType.Sound);

		// Token: 0x040011D7 RID: 4567
		public static readonly LegacySoundStyle Item120 = new LegacySoundStyle(2, 120, SoundType.Sound);

		// Token: 0x040011D8 RID: 4568
		public static readonly LegacySoundStyle Item121 = new LegacySoundStyle(2, 121, SoundType.Sound);

		// Token: 0x040011D9 RID: 4569
		public static readonly LegacySoundStyle Item122 = new LegacySoundStyle(2, 122, SoundType.Sound);

		// Token: 0x040011DA RID: 4570
		public static readonly LegacySoundStyle Item123 = new LegacySoundStyle(2, 123, SoundType.Sound);

		// Token: 0x040011DB RID: 4571
		public static readonly LegacySoundStyle Item124 = new LegacySoundStyle(2, 124, SoundType.Sound);

		// Token: 0x040011DC RID: 4572
		public static readonly LegacySoundStyle Item125 = new LegacySoundStyle(2, 125, SoundType.Sound);

		// Token: 0x040011DD RID: 4573
		public static readonly LegacySoundStyle DD2_GoblinBomb = new LegacySoundStyle(2, 14, SoundType.Sound).WithVolume(0.5f);

		// Token: 0x040011DE RID: 4574
		public static readonly LegacySoundStyle BlizzardInsideBuildingLoop = SoundID.CreateTrackable("blizzard_inside_building_loop", SoundType.Ambient);

		// Token: 0x040011DF RID: 4575
		public static readonly LegacySoundStyle BlizzardStrongLoop = SoundID.CreateTrackable("blizzard_strong_loop", SoundType.Ambient).WithVolume(0.5f);

		// Token: 0x040011E0 RID: 4576
		public static readonly LegacySoundStyle LiquidsHoneyWater = SoundID.CreateTrackable("liquids_honey_water", 3, SoundType.Ambient);

		// Token: 0x040011E1 RID: 4577
		public static readonly LegacySoundStyle LiquidsHoneyLava = SoundID.CreateTrackable("liquids_honey_lava", 3, SoundType.Ambient);

		// Token: 0x040011E2 RID: 4578
		public static readonly LegacySoundStyle LiquidsWaterLava = SoundID.CreateTrackable("liquids_water_lava", 3, SoundType.Ambient);

		// Token: 0x040011E3 RID: 4579
		public static readonly LegacySoundStyle DD2_BallistaTowerShot = SoundID.CreateTrackable("dd2_ballista_tower_shot", 3, SoundType.Sound);

		// Token: 0x040011E4 RID: 4580
		public static readonly LegacySoundStyle DD2_ExplosiveTrapExplode = SoundID.CreateTrackable("dd2_explosive_trap_explode", 3, SoundType.Sound);

		// Token: 0x040011E5 RID: 4581
		public static readonly LegacySoundStyle DD2_FlameburstTowerShot = SoundID.CreateTrackable("dd2_flameburst_tower_shot", 3, SoundType.Sound);

		// Token: 0x040011E6 RID: 4582
		public static readonly LegacySoundStyle DD2_LightningAuraZap = SoundID.CreateTrackable("dd2_lightning_aura_zap", 4, SoundType.Sound);

		// Token: 0x040011E7 RID: 4583
		public static readonly LegacySoundStyle DD2_DefenseTowerSpawn = SoundID.CreateTrackable("dd2_defense_tower_spawn", SoundType.Sound);

		// Token: 0x040011E8 RID: 4584
		public static readonly LegacySoundStyle DD2_BetsyDeath = SoundID.CreateTrackable("dd2_betsy_death", 3, SoundType.Sound);

		// Token: 0x040011E9 RID: 4585
		public static readonly LegacySoundStyle DD2_BetsyFireballShot = SoundID.CreateTrackable("dd2_betsy_fireball_shot", 3, SoundType.Sound);

		// Token: 0x040011EA RID: 4586
		public static readonly LegacySoundStyle DD2_BetsyFireballImpact = SoundID.CreateTrackable("dd2_betsy_fireball_impact", 3, SoundType.Sound);

		// Token: 0x040011EB RID: 4587
		public static readonly LegacySoundStyle DD2_BetsyFlameBreath = SoundID.CreateTrackable("dd2_betsy_flame_breath", SoundType.Sound);

		// Token: 0x040011EC RID: 4588
		public static readonly LegacySoundStyle DD2_BetsyFlyingCircleAttack = SoundID.CreateTrackable("dd2_betsy_flying_circle_attack", SoundType.Sound);

		// Token: 0x040011ED RID: 4589
		public static readonly LegacySoundStyle DD2_BetsyHurt = SoundID.CreateTrackable("dd2_betsy_hurt", 3, SoundType.Sound);

		// Token: 0x040011EE RID: 4590
		public static readonly LegacySoundStyle DD2_BetsyScream = SoundID.CreateTrackable("dd2_betsy_scream", SoundType.Sound);

		// Token: 0x040011EF RID: 4591
		public static readonly LegacySoundStyle DD2_BetsySummon = SoundID.CreateTrackable("dd2_betsy_summon", 3, SoundType.Sound);

		// Token: 0x040011F0 RID: 4592
		public static readonly LegacySoundStyle DD2_BetsyWindAttack = SoundID.CreateTrackable("dd2_betsy_wind_attack", 3, SoundType.Sound);

		// Token: 0x040011F1 RID: 4593
		public static readonly LegacySoundStyle DD2_DarkMageAttack = SoundID.CreateTrackable("dd2_dark_mage_attack", 3, SoundType.Sound);

		// Token: 0x040011F2 RID: 4594
		public static readonly LegacySoundStyle DD2_DarkMageCastHeal = SoundID.CreateTrackable("dd2_dark_mage_cast_heal", 3, SoundType.Sound);

		// Token: 0x040011F3 RID: 4595
		public static readonly LegacySoundStyle DD2_DarkMageDeath = SoundID.CreateTrackable("dd2_dark_mage_death", 3, SoundType.Sound);

		// Token: 0x040011F4 RID: 4596
		public static readonly LegacySoundStyle DD2_DarkMageHealImpact = SoundID.CreateTrackable("dd2_dark_mage_heal_impact", 3, SoundType.Sound);

		// Token: 0x040011F5 RID: 4597
		public static readonly LegacySoundStyle DD2_DarkMageHurt = SoundID.CreateTrackable("dd2_dark_mage_hurt", 3, SoundType.Sound);

		// Token: 0x040011F6 RID: 4598
		public static readonly LegacySoundStyle DD2_DarkMageSummonSkeleton = SoundID.CreateTrackable("dd2_dark_mage_summon_skeleton", 3, SoundType.Sound);

		// Token: 0x040011F7 RID: 4599
		public static readonly LegacySoundStyle DD2_DrakinBreathIn = SoundID.CreateTrackable("dd2_drakin_breath_in", 3, SoundType.Sound);

		// Token: 0x040011F8 RID: 4600
		public static readonly LegacySoundStyle DD2_DrakinDeath = SoundID.CreateTrackable("dd2_drakin_death", 3, SoundType.Sound);

		// Token: 0x040011F9 RID: 4601
		public static readonly LegacySoundStyle DD2_DrakinHurt = SoundID.CreateTrackable("dd2_drakin_hurt", 3, SoundType.Sound);

		// Token: 0x040011FA RID: 4602
		public static readonly LegacySoundStyle DD2_DrakinShot = SoundID.CreateTrackable("dd2_drakin_shot", 3, SoundType.Sound);

		// Token: 0x040011FB RID: 4603
		public static readonly LegacySoundStyle DD2_GoblinDeath = SoundID.CreateTrackable("dd2_goblin_death", 3, SoundType.Sound);

		// Token: 0x040011FC RID: 4604
		public static readonly LegacySoundStyle DD2_GoblinHurt = SoundID.CreateTrackable("dd2_goblin_hurt", 6, SoundType.Sound);

		// Token: 0x040011FD RID: 4605
		public static readonly LegacySoundStyle DD2_GoblinScream = SoundID.CreateTrackable("dd2_goblin_scream", 3, SoundType.Sound);

		// Token: 0x040011FE RID: 4606
		public static readonly LegacySoundStyle DD2_GoblinBomberDeath = SoundID.CreateTrackable("dd2_goblin_bomber_death", 3, SoundType.Sound);

		// Token: 0x040011FF RID: 4607
		public static readonly LegacySoundStyle DD2_GoblinBomberHurt = SoundID.CreateTrackable("dd2_goblin_bomber_hurt", 3, SoundType.Sound);

		// Token: 0x04001200 RID: 4608
		public static readonly LegacySoundStyle DD2_GoblinBomberScream = SoundID.CreateTrackable("dd2_goblin_bomber_scream", 3, SoundType.Sound);

		// Token: 0x04001201 RID: 4609
		public static readonly LegacySoundStyle DD2_GoblinBomberThrow = SoundID.CreateTrackable("dd2_goblin_bomber_throw", 3, SoundType.Sound);

		// Token: 0x04001202 RID: 4610
		public static readonly LegacySoundStyle DD2_JavelinThrowersAttack = SoundID.CreateTrackable("dd2_javelin_throwers_attack", 3, SoundType.Sound);

		// Token: 0x04001203 RID: 4611
		public static readonly LegacySoundStyle DD2_JavelinThrowersDeath = SoundID.CreateTrackable("dd2_javelin_throwers_death", 3, SoundType.Sound);

		// Token: 0x04001204 RID: 4612
		public static readonly LegacySoundStyle DD2_JavelinThrowersHurt = SoundID.CreateTrackable("dd2_javelin_throwers_hurt", 3, SoundType.Sound);

		// Token: 0x04001205 RID: 4613
		public static readonly LegacySoundStyle DD2_JavelinThrowersTaunt = SoundID.CreateTrackable("dd2_javelin_throwers_taunt", 3, SoundType.Sound);

		// Token: 0x04001206 RID: 4614
		public static readonly LegacySoundStyle DD2_KoboldDeath = SoundID.CreateTrackable("dd2_kobold_death", 3, SoundType.Sound);

		// Token: 0x04001207 RID: 4615
		public static readonly LegacySoundStyle DD2_KoboldExplosion = SoundID.CreateTrackable("dd2_kobold_explosion", 3, SoundType.Sound);

		// Token: 0x04001208 RID: 4616
		public static readonly LegacySoundStyle DD2_KoboldHurt = SoundID.CreateTrackable("dd2_kobold_hurt", 3, SoundType.Sound);

		// Token: 0x04001209 RID: 4617
		public static readonly LegacySoundStyle DD2_KoboldIgnite = SoundID.CreateTrackable("dd2_kobold_ignite", SoundType.Sound);

		// Token: 0x0400120A RID: 4618
		public static readonly LegacySoundStyle DD2_KoboldIgniteLoop = SoundID.CreateTrackable("dd2_kobold_ignite_loop", SoundType.Sound);

		// Token: 0x0400120B RID: 4619
		public static readonly LegacySoundStyle DD2_KoboldScreamChargeLoop = SoundID.CreateTrackable("dd2_kobold_scream_charge_loop", SoundType.Sound);

		// Token: 0x0400120C RID: 4620
		public static readonly LegacySoundStyle DD2_KoboldFlyerChargeScream = SoundID.CreateTrackable("dd2_kobold_flyer_charge_scream", 3, SoundType.Sound);

		// Token: 0x0400120D RID: 4621
		public static readonly LegacySoundStyle DD2_KoboldFlyerDeath = SoundID.CreateTrackable("dd2_kobold_flyer_death", 3, SoundType.Sound);

		// Token: 0x0400120E RID: 4622
		public static readonly LegacySoundStyle DD2_KoboldFlyerHurt = SoundID.CreateTrackable("dd2_kobold_flyer_hurt", 3, SoundType.Sound);

		// Token: 0x0400120F RID: 4623
		public static readonly LegacySoundStyle DD2_LightningBugDeath = SoundID.CreateTrackable("dd2_lightning_bug_death", 3, SoundType.Sound);

		// Token: 0x04001210 RID: 4624
		public static readonly LegacySoundStyle DD2_LightningBugHurt = SoundID.CreateTrackable("dd2_lightning_bug_hurt", 3, SoundType.Sound);

		// Token: 0x04001211 RID: 4625
		public static readonly LegacySoundStyle DD2_LightningBugZap = SoundID.CreateTrackable("dd2_lightning_bug_zap", 3, SoundType.Sound);

		// Token: 0x04001212 RID: 4626
		public static readonly LegacySoundStyle DD2_OgreAttack = SoundID.CreateTrackable("dd2_ogre_attack", 3, SoundType.Sound);

		// Token: 0x04001213 RID: 4627
		public static readonly LegacySoundStyle DD2_OgreDeath = SoundID.CreateTrackable("dd2_ogre_death", 3, SoundType.Sound);

		// Token: 0x04001214 RID: 4628
		public static readonly LegacySoundStyle DD2_OgreGroundPound = SoundID.CreateTrackable("dd2_ogre_ground_pound", SoundType.Sound);

		// Token: 0x04001215 RID: 4629
		public static readonly LegacySoundStyle DD2_OgreHurt = SoundID.CreateTrackable("dd2_ogre_hurt", 3, SoundType.Sound);

		// Token: 0x04001216 RID: 4630
		public static readonly LegacySoundStyle DD2_OgreRoar = SoundID.CreateTrackable("dd2_ogre_roar", 3, SoundType.Sound);

		// Token: 0x04001217 RID: 4631
		public static readonly LegacySoundStyle DD2_OgreSpit = SoundID.CreateTrackable("dd2_ogre_spit", SoundType.Sound);

		// Token: 0x04001218 RID: 4632
		public static readonly LegacySoundStyle DD2_SkeletonDeath = SoundID.CreateTrackable("dd2_skeleton_death", 3, SoundType.Sound);

		// Token: 0x04001219 RID: 4633
		public static readonly LegacySoundStyle DD2_SkeletonHurt = SoundID.CreateTrackable("dd2_skeleton_hurt", 3, SoundType.Sound);

		// Token: 0x0400121A RID: 4634
		public static readonly LegacySoundStyle DD2_SkeletonSummoned = SoundID.CreateTrackable("dd2_skeleton_summoned", SoundType.Sound);

		// Token: 0x0400121B RID: 4635
		public static readonly LegacySoundStyle DD2_WitherBeastAuraPulse = SoundID.CreateTrackable("dd2_wither_beast_aura_pulse", 2, SoundType.Sound);

		// Token: 0x0400121C RID: 4636
		public static readonly LegacySoundStyle DD2_WitherBeastCrystalImpact = SoundID.CreateTrackable("dd2_wither_beast_crystal_impact", 3, SoundType.Sound);

		// Token: 0x0400121D RID: 4637
		public static readonly LegacySoundStyle DD2_WitherBeastDeath = SoundID.CreateTrackable("dd2_wither_beast_death", 3, SoundType.Sound);

		// Token: 0x0400121E RID: 4638
		public static readonly LegacySoundStyle DD2_WitherBeastHurt = SoundID.CreateTrackable("dd2_wither_beast_hurt", 3, SoundType.Sound);

		// Token: 0x0400121F RID: 4639
		public static readonly LegacySoundStyle DD2_WyvernDeath = SoundID.CreateTrackable("dd2_wyvern_death", 3, SoundType.Sound);

		// Token: 0x04001220 RID: 4640
		public static readonly LegacySoundStyle DD2_WyvernHurt = SoundID.CreateTrackable("dd2_wyvern_hurt", 3, SoundType.Sound);

		// Token: 0x04001221 RID: 4641
		public static readonly LegacySoundStyle DD2_WyvernScream = SoundID.CreateTrackable("dd2_wyvern_scream", 3, SoundType.Sound);

		// Token: 0x04001222 RID: 4642
		public static readonly LegacySoundStyle DD2_WyvernDiveDown = SoundID.CreateTrackable("dd2_wyvern_dive_down", 3, SoundType.Sound);

		// Token: 0x04001223 RID: 4643
		public static readonly LegacySoundStyle DD2_EtherianPortalDryadTouch = SoundID.CreateTrackable("dd2_etherian_portal_dryad_touch", SoundType.Sound);

		// Token: 0x04001224 RID: 4644
		public static readonly LegacySoundStyle DD2_EtherianPortalIdleLoop = SoundID.CreateTrackable("dd2_etherian_portal_idle_loop", SoundType.Sound);

		// Token: 0x04001225 RID: 4645
		public static readonly LegacySoundStyle DD2_EtherianPortalOpen = SoundID.CreateTrackable("dd2_etherian_portal_open", SoundType.Sound);

		// Token: 0x04001226 RID: 4646
		public static readonly LegacySoundStyle DD2_EtherianPortalSpawnEnemy = SoundID.CreateTrackable("dd2_etherian_portal_spawn_enemy", 3, SoundType.Sound);

		// Token: 0x04001227 RID: 4647
		public static readonly LegacySoundStyle DD2_CrystalCartImpact = SoundID.CreateTrackable("dd2_crystal_cart_impact", 3, SoundType.Sound);

		// Token: 0x04001228 RID: 4648
		public static readonly LegacySoundStyle DD2_DefeatScene = SoundID.CreateTrackable("dd2_defeat_scene", SoundType.Sound);

		// Token: 0x04001229 RID: 4649
		public static readonly LegacySoundStyle DD2_WinScene = SoundID.CreateTrackable("dd2_win_scene", SoundType.Sound);

		// Token: 0x0400122A RID: 4650
		public static readonly LegacySoundStyle DD2_BetsysWrathShot = SoundID.DD2_BetsyFireballShot.WithVolume(0.4f);

		// Token: 0x0400122B RID: 4651
		public static readonly LegacySoundStyle DD2_BetsysWrathImpact = SoundID.DD2_BetsyFireballImpact.WithVolume(0.4f);

		// Token: 0x0400122C RID: 4652
		public static readonly LegacySoundStyle DD2_BookStaffCast = SoundID.CreateTrackable("dd2_book_staff_cast", 3, SoundType.Sound);

		// Token: 0x0400122D RID: 4653
		public static readonly LegacySoundStyle DD2_BookStaffTwisterLoop = SoundID.CreateTrackable("dd2_book_staff_twister_loop", SoundType.Sound);

		// Token: 0x0400122E RID: 4654
		public static readonly LegacySoundStyle DD2_GhastlyGlaiveImpactGhost = SoundID.CreateTrackable("dd2_ghastly_glaive_impact_ghost", 3, SoundType.Sound);

		// Token: 0x0400122F RID: 4655
		public static readonly LegacySoundStyle DD2_GhastlyGlaivePierce = SoundID.CreateTrackable("dd2_ghastly_glaive_pierce", 3, SoundType.Sound);

		// Token: 0x04001230 RID: 4656
		public static readonly LegacySoundStyle DD2_MonkStaffGroundImpact = SoundID.CreateTrackable("dd2_monk_staff_ground_impact", 3, SoundType.Sound);

		// Token: 0x04001231 RID: 4657
		public static readonly LegacySoundStyle DD2_MonkStaffGroundMiss = SoundID.CreateTrackable("dd2_monk_staff_ground_miss", 3, SoundType.Sound);

		// Token: 0x04001232 RID: 4658
		public static readonly LegacySoundStyle DD2_MonkStaffSwing = SoundID.CreateTrackable("dd2_monk_staff_swing", 4, SoundType.Sound);

		// Token: 0x04001233 RID: 4659
		public static readonly LegacySoundStyle DD2_PhantomPhoenixShot = SoundID.CreateTrackable("dd2_phantom_phoenix_shot", 3, SoundType.Sound);

		// Token: 0x04001234 RID: 4660
		public static readonly LegacySoundStyle DD2_SonicBoomBladeSlash = SoundID.CreateTrackable("dd2_sonic_boom_blade_slash", 3, SoundID.ItemDefaults).WithVolume(0.5f);

		// Token: 0x04001235 RID: 4661
		public static readonly LegacySoundStyle DD2_SkyDragonsFuryCircle = SoundID.CreateTrackable("dd2_sky_dragons_fury_circle", 3, SoundType.Sound);

		// Token: 0x04001236 RID: 4662
		public static readonly LegacySoundStyle DD2_SkyDragonsFuryShot = SoundID.CreateTrackable("dd2_sky_dragons_fury_shot", 3, SoundType.Sound);

		// Token: 0x04001237 RID: 4663
		public static readonly LegacySoundStyle DD2_SkyDragonsFurySwing = SoundID.CreateTrackable("dd2_sky_dragons_fury_swing", 4, SoundType.Sound);

		// Token: 0x04001238 RID: 4664
		private static List<string> _trackableLegacySoundPathList;

		// Token: 0x0200026C RID: 620
		private struct SoundStyleDefaults
		{
			// Token: 0x0600166B RID: 5739 RVA: 0x004356EC File Offset: 0x004338EC
			public SoundStyleDefaults(float volume, float pitchVariance, SoundType type = SoundType.Sound)
			{
				this.PitchVariance = pitchVariance;
				this.Volume = volume;
				this.Type = type;
			}

			// Token: 0x04003B80 RID: 15232
			public readonly float PitchVariance;

			// Token: 0x04003B81 RID: 15233
			public readonly float Volume;

			// Token: 0x04003B82 RID: 15234
			public readonly SoundType Type;
		}
	}
}

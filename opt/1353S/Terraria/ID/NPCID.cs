using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Terraria.ID
{
	// Token: 0x020000DF RID: 223
	public class NPCID
	{
		// Token: 0x06000D2A RID: 3370 RVA: 0x003E09AC File Offset: 0x003DEBAC
		public static int FromLegacyName(string name)
		{
			int result;
			if (NPCID.LegacyNameToIdMap.TryGetValue(name, out result))
			{
				return result;
			}
			return 0;
		}

		// Token: 0x06000D2B RID: 3371 RVA: 0x003E09CC File Offset: 0x003DEBCC
		public static int FromNetId(int id)
		{
			if (id < 0)
			{
				return NPCID.NetIdMap[-id - 1];
			}
			return id;
		}

		// Token: 0x04002A85 RID: 10885
		private static readonly int[] NetIdMap = new int[]
		{
			81,
			81,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			6,
			6,
			31,
			31,
			77,
			42,
			42,
			176,
			176,
			176,
			176,
			173,
			173,
			183,
			183,
			3,
			3,
			132,
			132,
			186,
			186,
			187,
			187,
			188,
			188,
			189,
			189,
			190,
			191,
			192,
			193,
			194,
			2,
			200,
			200,
			21,
			21,
			201,
			201,
			202,
			202,
			203,
			203,
			223,
			223,
			231,
			231,
			232,
			232,
			233,
			233,
			234,
			234,
			235,
			235
		};

		// Token: 0x04002A86 RID: 10886
		private static readonly Dictionary<string, int> LegacyNameToIdMap = new Dictionary<string, int>
		{
			{
				"Slimeling",
				-1
			},
			{
				"Slimer2",
				-2
			},
			{
				"Green Slime",
				-3
			},
			{
				"Pinky",
				-4
			},
			{
				"Baby Slime",
				-5
			},
			{
				"Black Slime",
				-6
			},
			{
				"Purple Slime",
				-7
			},
			{
				"Red Slime",
				-8
			},
			{
				"Yellow Slime",
				-9
			},
			{
				"Jungle Slime",
				-10
			},
			{
				"Little Eater",
				-11
			},
			{
				"Big Eater",
				-12
			},
			{
				"Short Bones",
				-13
			},
			{
				"Big Boned",
				-14
			},
			{
				"Heavy Skeleton",
				-15
			},
			{
				"Little Stinger",
				-16
			},
			{
				"Big Stinger",
				-17
			},
			{
				"Tiny Moss Hornet",
				-18
			},
			{
				"Little Moss Hornet",
				-19
			},
			{
				"Big Moss Hornet",
				-20
			},
			{
				"Giant Moss Hornet",
				-21
			},
			{
				"Little Crimera",
				-22
			},
			{
				"Big Crimera",
				-23
			},
			{
				"Little Crimslime",
				-24
			},
			{
				"Big Crimslime",
				-25
			},
			{
				"Small Zombie",
				-26
			},
			{
				"Big Zombie",
				-27
			},
			{
				"Small Bald Zombie",
				-28
			},
			{
				"Big Bald Zombie",
				-29
			},
			{
				"Small Pincushion Zombie",
				-30
			},
			{
				"Big Pincushion Zombie",
				-31
			},
			{
				"Small Slimed Zombie",
				-32
			},
			{
				"Big Slimed Zombie",
				-33
			},
			{
				"Small Swamp Zombie",
				-34
			},
			{
				"Big Swamp Zombie",
				-35
			},
			{
				"Small Twiggy Zombie",
				-36
			},
			{
				"Big Twiggy Zombie",
				-37
			},
			{
				"Cataract Eye 2",
				-38
			},
			{
				"Sleepy Eye 2",
				-39
			},
			{
				"Dialated Eye 2",
				-40
			},
			{
				"Green Eye 2",
				-41
			},
			{
				"Purple Eye 2",
				-42
			},
			{
				"Demon Eye 2",
				-43
			},
			{
				"Small Female Zombie",
				-44
			},
			{
				"Big Female Zombie",
				-45
			},
			{
				"Small Skeleton",
				-46
			},
			{
				"Big Skeleton",
				-47
			},
			{
				"Small Headache Skeleton",
				-48
			},
			{
				"Big Headache Skeleton",
				-49
			},
			{
				"Small Misassembled Skeleton",
				-50
			},
			{
				"Big Misassembled Skeleton",
				-51
			},
			{
				"Small Pantless Skeleton",
				-52
			},
			{
				"Big Pantless Skeleton",
				-53
			},
			{
				"Small Rain Zombie",
				-54
			},
			{
				"Big Rain Zombie",
				-55
			},
			{
				"Little Hornet Fatty",
				-56
			},
			{
				"Big Hornet Fatty",
				-57
			},
			{
				"Little Hornet Honey",
				-58
			},
			{
				"Big Hornet Honey",
				-59
			},
			{
				"Little Hornet Leafy",
				-60
			},
			{
				"Big Hornet Leafy",
				-61
			},
			{
				"Little Hornet Spikey",
				-62
			},
			{
				"Big Hornet Spikey",
				-63
			},
			{
				"Little Hornet Stingy",
				-64
			},
			{
				"Big Hornet Stingy",
				-65
			},
			{
				"Blue Slime",
				1
			},
			{
				"Demon Eye",
				2
			},
			{
				"Zombie",
				3
			},
			{
				"Eye of Cthulhu",
				4
			},
			{
				"Servant of Cthulhu",
				5
			},
			{
				"Eater of Souls",
				6
			},
			{
				"Devourer",
				7
			},
			{
				"Giant Worm",
				10
			},
			{
				"Eater of Worlds",
				13
			},
			{
				"Mother Slime",
				16
			},
			{
				"Merchant",
				17
			},
			{
				"Nurse",
				18
			},
			{
				"Arms Dealer",
				19
			},
			{
				"Dryad",
				20
			},
			{
				"Skeleton",
				21
			},
			{
				"Guide",
				22
			},
			{
				"Meteor Head",
				23
			},
			{
				"Fire Imp",
				24
			},
			{
				"Burning Sphere",
				25
			},
			{
				"Goblin Peon",
				26
			},
			{
				"Goblin Thief",
				27
			},
			{
				"Goblin Warrior",
				28
			},
			{
				"Goblin Sorcerer",
				29
			},
			{
				"Chaos Ball",
				30
			},
			{
				"Angry Bones",
				31
			},
			{
				"Dark Caster",
				32
			},
			{
				"Water Sphere",
				33
			},
			{
				"Cursed Skull",
				34
			},
			{
				"Skeletron",
				35
			},
			{
				"Old Man",
				37
			},
			{
				"Demolitionist",
				38
			},
			{
				"Bone Serpent",
				39
			},
			{
				"Hornet",
				42
			},
			{
				"Man Eater",
				43
			},
			{
				"Undead Miner",
				44
			},
			{
				"Tim",
				45
			},
			{
				"Bunny",
				46
			},
			{
				"Corrupt Bunny",
				47
			},
			{
				"Harpy",
				48
			},
			{
				"Cave Bat",
				49
			},
			{
				"King Slime",
				50
			},
			{
				"Jungle Bat",
				51
			},
			{
				"Doctor Bones",
				52
			},
			{
				"The Groom",
				53
			},
			{
				"Clothier",
				54
			},
			{
				"Goldfish",
				55
			},
			{
				"Snatcher",
				56
			},
			{
				"Corrupt Goldfish",
				57
			},
			{
				"Piranha",
				58
			},
			{
				"Lava Slime",
				59
			},
			{
				"Hellbat",
				60
			},
			{
				"Vulture",
				61
			},
			{
				"Demon",
				62
			},
			{
				"Blue Jellyfish",
				63
			},
			{
				"Pink Jellyfish",
				64
			},
			{
				"Shark",
				65
			},
			{
				"Voodoo Demon",
				66
			},
			{
				"Crab",
				67
			},
			{
				"Dungeon Guardian",
				68
			},
			{
				"Antlion",
				69
			},
			{
				"Spike Ball",
				70
			},
			{
				"Dungeon Slime",
				71
			},
			{
				"Blazing Wheel",
				72
			},
			{
				"Goblin Scout",
				73
			},
			{
				"Bird",
				74
			},
			{
				"Pixie",
				75
			},
			{
				"Armored Skeleton",
				77
			},
			{
				"Mummy",
				78
			},
			{
				"Dark Mummy",
				79
			},
			{
				"Light Mummy",
				80
			},
			{
				"Corrupt Slime",
				81
			},
			{
				"Wraith",
				82
			},
			{
				"Cursed Hammer",
				83
			},
			{
				"Enchanted Sword",
				84
			},
			{
				"Mimic",
				85
			},
			{
				"Unicorn",
				86
			},
			{
				"Wyvern",
				87
			},
			{
				"Giant Bat",
				93
			},
			{
				"Corruptor",
				94
			},
			{
				"Digger",
				95
			},
			{
				"World Feeder",
				98
			},
			{
				"Clinger",
				101
			},
			{
				"Angler Fish",
				102
			},
			{
				"Green Jellyfish",
				103
			},
			{
				"Werewolf",
				104
			},
			{
				"Bound Goblin",
				105
			},
			{
				"Bound Wizard",
				106
			},
			{
				"Goblin Tinkerer",
				107
			},
			{
				"Wizard",
				108
			},
			{
				"Clown",
				109
			},
			{
				"Skeleton Archer",
				110
			},
			{
				"Goblin Archer",
				111
			},
			{
				"Vile Spit",
				112
			},
			{
				"Wall of Flesh",
				113
			},
			{
				"The Hungry",
				115
			},
			{
				"Leech",
				117
			},
			{
				"Chaos Elemental",
				120
			},
			{
				"Slimer",
				121
			},
			{
				"Gastropod",
				122
			},
			{
				"Bound Mechanic",
				123
			},
			{
				"Mechanic",
				124
			},
			{
				"Retinazer",
				125
			},
			{
				"Spazmatism",
				126
			},
			{
				"Skeletron Prime",
				127
			},
			{
				"Prime Cannon",
				128
			},
			{
				"Prime Saw",
				129
			},
			{
				"Prime Vice",
				130
			},
			{
				"Prime Laser",
				131
			},
			{
				"Wandering Eye",
				133
			},
			{
				"The Destroyer",
				134
			},
			{
				"Illuminant Bat",
				137
			},
			{
				"Illuminant Slime",
				138
			},
			{
				"Probe",
				139
			},
			{
				"Possessed Armor",
				140
			},
			{
				"Toxic Sludge",
				141
			},
			{
				"Santa Claus",
				142
			},
			{
				"Snowman Gangsta",
				143
			},
			{
				"Mister Stabby",
				144
			},
			{
				"Snow Balla",
				145
			},
			{
				"Ice Slime",
				147
			},
			{
				"Penguin",
				148
			},
			{
				"Ice Bat",
				150
			},
			{
				"Lava Bat",
				151
			},
			{
				"Giant Flying Fox",
				152
			},
			{
				"Giant Tortoise",
				153
			},
			{
				"Ice Tortoise",
				154
			},
			{
				"Wolf",
				155
			},
			{
				"Red Devil",
				156
			},
			{
				"Arapaima",
				157
			},
			{
				"Vampire",
				158
			},
			{
				"Truffle",
				160
			},
			{
				"Zombie Eskimo",
				161
			},
			{
				"Frankenstein",
				162
			},
			{
				"Black Recluse",
				163
			},
			{
				"Wall Creeper",
				164
			},
			{
				"Swamp Thing",
				166
			},
			{
				"Undead Viking",
				167
			},
			{
				"Corrupt Penguin",
				168
			},
			{
				"Ice Elemental",
				169
			},
			{
				"Pigron",
				170
			},
			{
				"Rune Wizard",
				172
			},
			{
				"Crimera",
				173
			},
			{
				"Herpling",
				174
			},
			{
				"Angry Trapper",
				175
			},
			{
				"Moss Hornet",
				176
			},
			{
				"Derpling",
				177
			},
			{
				"Steampunker",
				178
			},
			{
				"Crimson Axe",
				179
			},
			{
				"Face Monster",
				181
			},
			{
				"Floaty Gross",
				182
			},
			{
				"Crimslime",
				183
			},
			{
				"Spiked Ice Slime",
				184
			},
			{
				"Snow Flinx",
				185
			},
			{
				"Lost Girl",
				195
			},
			{
				"Nymph",
				196
			},
			{
				"Armored Viking",
				197
			},
			{
				"Lihzahrd",
				198
			},
			{
				"Spiked Jungle Slime",
				204
			},
			{
				"Moth",
				205
			},
			{
				"Icy Merman",
				206
			},
			{
				"Dye Trader",
				207
			},
			{
				"Party Girl",
				208
			},
			{
				"Cyborg",
				209
			},
			{
				"Bee",
				210
			},
			{
				"Pirate Deckhand",
				212
			},
			{
				"Pirate Corsair",
				213
			},
			{
				"Pirate Deadeye",
				214
			},
			{
				"Pirate Crossbower",
				215
			},
			{
				"Pirate Captain",
				216
			},
			{
				"Cochineal Beetle",
				217
			},
			{
				"Cyan Beetle",
				218
			},
			{
				"Lac Beetle",
				219
			},
			{
				"Sea Snail",
				220
			},
			{
				"Squid",
				221
			},
			{
				"Queen Bee",
				222
			},
			{
				"Raincoat Zombie",
				223
			},
			{
				"Flying Fish",
				224
			},
			{
				"Umbrella Slime",
				225
			},
			{
				"Flying Snake",
				226
			},
			{
				"Painter",
				227
			},
			{
				"Witch Doctor",
				228
			},
			{
				"Pirate",
				229
			},
			{
				"Jungle Creeper",
				236
			},
			{
				"Blood Crawler",
				239
			},
			{
				"Blood Feeder",
				241
			},
			{
				"Blood Jelly",
				242
			},
			{
				"Ice Golem",
				243
			},
			{
				"Rainbow Slime",
				244
			},
			{
				"Golem",
				245
			},
			{
				"Golem Head",
				246
			},
			{
				"Golem Fist",
				247
			},
			{
				"Angry Nimbus",
				250
			},
			{
				"Eyezor",
				251
			},
			{
				"Parrot",
				252
			},
			{
				"Reaper",
				253
			},
			{
				"Spore Zombie",
				254
			},
			{
				"Fungo Fish",
				256
			},
			{
				"Anomura Fungus",
				257
			},
			{
				"Mushi Ladybug",
				258
			},
			{
				"Fungi Bulb",
				259
			},
			{
				"Giant Fungi Bulb",
				260
			},
			{
				"Fungi Spore",
				261
			},
			{
				"Plantera",
				262
			},
			{
				"Plantera's Hook",
				263
			},
			{
				"Plantera's Tentacle",
				264
			},
			{
				"Spore",
				265
			},
			{
				"Brain of Cthulhu",
				266
			},
			{
				"Creeper",
				267
			},
			{
				"Ichor Sticker",
				268
			},
			{
				"Rusty Armored Bones",
				269
			},
			{
				"Blue Armored Bones",
				273
			},
			{
				"Hell Armored Bones",
				277
			},
			{
				"Ragged Caster",
				281
			},
			{
				"Necromancer",
				283
			},
			{
				"Diabolist",
				285
			},
			{
				"Bone Lee",
				287
			},
			{
				"Dungeon Spirit",
				288
			},
			{
				"Giant Cursed Skull",
				289
			},
			{
				"Paladin",
				290
			},
			{
				"Skeleton Sniper",
				291
			},
			{
				"Tactical Skeleton",
				292
			},
			{
				"Skeleton Commando",
				293
			},
			{
				"Blue Jay",
				297
			},
			{
				"Cardinal",
				298
			},
			{
				"Squirrel",
				299
			},
			{
				"Mouse",
				300
			},
			{
				"Raven",
				301
			},
			{
				"Slime",
				302
			},
			{
				"Hoppin' Jack",
				304
			},
			{
				"Scarecrow",
				305
			},
			{
				"Headless Horseman",
				315
			},
			{
				"Ghost",
				316
			},
			{
				"Mourning Wood",
				325
			},
			{
				"Splinterling",
				326
			},
			{
				"Pumpking",
				327
			},
			{
				"Hellhound",
				329
			},
			{
				"Poltergeist",
				330
			},
			{
				"Zombie Elf",
				338
			},
			{
				"Present Mimic",
				341
			},
			{
				"Gingerbread Man",
				342
			},
			{
				"Yeti",
				343
			},
			{
				"Everscream",
				344
			},
			{
				"Ice Queen",
				345
			},
			{
				"Santa",
				346
			},
			{
				"Elf Copter",
				347
			},
			{
				"Nutcracker",
				348
			},
			{
				"Elf Archer",
				350
			},
			{
				"Krampus",
				351
			},
			{
				"Flocko",
				352
			},
			{
				"Stylist",
				353
			},
			{
				"Webbed Stylist",
				354
			},
			{
				"Firefly",
				355
			},
			{
				"Butterfly",
				356
			},
			{
				"Worm",
				357
			},
			{
				"Lightning Bug",
				358
			},
			{
				"Snail",
				359
			},
			{
				"Glowing Snail",
				360
			},
			{
				"Frog",
				361
			},
			{
				"Duck",
				362
			},
			{
				"Scorpion",
				366
			},
			{
				"Traveling Merchant",
				368
			},
			{
				"Angler",
				369
			},
			{
				"Duke Fishron",
				370
			},
			{
				"Detonating Bubble",
				371
			},
			{
				"Sharkron",
				372
			},
			{
				"Truffle Worm",
				374
			},
			{
				"Sleeping Angler",
				376
			},
			{
				"Grasshopper",
				377
			},
			{
				"Chattering Teeth Bomb",
				378
			},
			{
				"Blue Cultist Archer",
				379
			},
			{
				"White Cultist Archer",
				380
			},
			{
				"Brain Scrambler",
				381
			},
			{
				"Ray Gunner",
				382
			},
			{
				"Martian Officer",
				383
			},
			{
				"Bubble Shield",
				384
			},
			{
				"Gray Grunt",
				385
			},
			{
				"Martian Engineer",
				386
			},
			{
				"Tesla Turret",
				387
			},
			{
				"Martian Drone",
				388
			},
			{
				"Gigazapper",
				389
			},
			{
				"Scutlix Gunner",
				390
			},
			{
				"Scutlix",
				391
			},
			{
				"Martian Saucer",
				392
			},
			{
				"Martian Saucer Turret",
				393
			},
			{
				"Martian Saucer Cannon",
				394
			},
			{
				"Moon Lord",
				396
			},
			{
				"Moon Lord's Hand",
				397
			},
			{
				"Moon Lord's Core",
				398
			},
			{
				"Martian Probe",
				399
			},
			{
				"Milkyway Weaver",
				402
			},
			{
				"Star Cell",
				405
			},
			{
				"Flow Invader",
				407
			},
			{
				"Twinkle Popper",
				409
			},
			{
				"Twinkle",
				410
			},
			{
				"Stargazer",
				411
			},
			{
				"Crawltipede",
				412
			},
			{
				"Drakomire",
				415
			},
			{
				"Drakomire Rider",
				416
			},
			{
				"Sroller",
				417
			},
			{
				"Corite",
				418
			},
			{
				"Selenian",
				419
			},
			{
				"Nebula Floater",
				420
			},
			{
				"Brain Suckler",
				421
			},
			{
				"Vortex Pillar",
				422
			},
			{
				"Evolution Beast",
				423
			},
			{
				"Predictor",
				424
			},
			{
				"Storm Diver",
				425
			},
			{
				"Alien Queen",
				426
			},
			{
				"Alien Hornet",
				427
			},
			{
				"Alien Larva",
				428
			},
			{
				"Vortexian",
				429
			},
			{
				"Mysterious Tablet",
				437
			},
			{
				"Lunatic Devote",
				438
			},
			{
				"Lunatic Cultist",
				439
			},
			{
				"Tax Collector",
				441
			},
			{
				"Gold Bird",
				442
			},
			{
				"Gold Bunny",
				443
			},
			{
				"Gold Butterfly",
				444
			},
			{
				"Gold Frog",
				445
			},
			{
				"Gold Grasshopper",
				446
			},
			{
				"Gold Mouse",
				447
			},
			{
				"Gold Worm",
				448
			},
			{
				"Phantasm Dragon",
				454
			},
			{
				"Butcher",
				460
			},
			{
				"Creature from the Deep",
				461
			},
			{
				"Fritz",
				462
			},
			{
				"Nailhead",
				463
			},
			{
				"Crimtane Bunny",
				464
			},
			{
				"Crimtane Goldfish",
				465
			},
			{
				"Psycho",
				466
			},
			{
				"Deadly Sphere",
				467
			},
			{
				"Dr. Man Fly",
				468
			},
			{
				"The Possessed",
				469
			},
			{
				"Vicious Penguin",
				470
			},
			{
				"Goblin Summoner",
				471
			},
			{
				"Shadowflame Apparation",
				472
			},
			{
				"Corrupt Mimic",
				473
			},
			{
				"Crimson Mimic",
				474
			},
			{
				"Hallowed Mimic",
				475
			},
			{
				"Jungle Mimic",
				476
			},
			{
				"Mothron",
				477
			},
			{
				"Mothron Egg",
				478
			},
			{
				"Baby Mothron",
				479
			},
			{
				"Medusa",
				480
			},
			{
				"Hoplite",
				481
			},
			{
				"Granite Golem",
				482
			},
			{
				"Granite Elemental",
				483
			},
			{
				"Enchanted Nightcrawler",
				484
			},
			{
				"Grubby",
				485
			},
			{
				"Sluggy",
				486
			},
			{
				"Buggy",
				487
			},
			{
				"Target Dummy",
				488
			},
			{
				"Blood Zombie",
				489
			},
			{
				"Drippler",
				490
			},
			{
				"Stardust Pillar",
				493
			},
			{
				"Crawdad",
				494
			},
			{
				"Giant Shelly",
				496
			},
			{
				"Salamander",
				498
			},
			{
				"Nebula Pillar",
				507
			},
			{
				"Antlion Charger",
				508
			},
			{
				"Antlion Swarmer",
				509
			},
			{
				"Dune Splicer",
				510
			},
			{
				"Tomb Crawler",
				513
			},
			{
				"Solar Flare",
				516
			},
			{
				"Solar Pillar",
				517
			},
			{
				"Drakanian",
				518
			},
			{
				"Solar Fragment",
				519
			},
			{
				"Martian Walker",
				520
			},
			{
				"Ancient Vision",
				521
			},
			{
				"Ancient Light",
				522
			},
			{
				"Ancient Doom",
				523
			},
			{
				"Ghoul",
				524
			},
			{
				"Vile Ghoul",
				525
			},
			{
				"Tainted Ghoul",
				526
			},
			{
				"Dreamer Ghoul",
				527
			},
			{
				"Lamia",
				528
			},
			{
				"Sand Poacher",
				530
			},
			{
				"Basilisk",
				532
			},
			{
				"Desert Spirit",
				533
			},
			{
				"Tortured Soul",
				534
			},
			{
				"Spiked Slime",
				535
			},
			{
				"The Bride",
				536
			},
			{
				"Sand Slime",
				537
			},
			{
				"Red Squirrel",
				538
			},
			{
				"Gold Squirrel",
				539
			},
			{
				"Sand Elemental",
				541
			},
			{
				"Sand Shark",
				542
			},
			{
				"Bone Biter",
				543
			},
			{
				"Flesh Reaver",
				544
			},
			{
				"Crystal Thresher",
				545
			},
			{
				"Angry Tumbler",
				546
			},
			{
				"???",
				547
			},
			{
				"Eternia Crystal",
				548
			},
			{
				"Mysterious Portal",
				549
			},
			{
				"Tavernkeep",
				550
			},
			{
				"Betsy",
				551
			},
			{
				"Etherian Goblin",
				552
			},
			{
				"Etherian Goblin Bomber",
				555
			},
			{
				"Etherian Wyvern",
				558
			},
			{
				"Etherian Javelin Thrower",
				561
			},
			{
				"Dark Mage",
				564
			},
			{
				"Old One's Skeleton",
				566
			},
			{
				"Wither Beast",
				568
			},
			{
				"Drakin",
				570
			},
			{
				"Kobold",
				572
			},
			{
				"Kobold Glider",
				574
			},
			{
				"Ogre",
				576
			},
			{
				"Etherian Lightning Bug",
				578
			}
		};

		// Token: 0x04002A87 RID: 10887
		public const short BigHornetStingy = -65;

		// Token: 0x04002A88 RID: 10888
		public const short LittleHornetStingy = -64;

		// Token: 0x04002A89 RID: 10889
		public const short BigHornetSpikey = -63;

		// Token: 0x04002A8A RID: 10890
		public const short LittleHornetSpikey = -62;

		// Token: 0x04002A8B RID: 10891
		public const short BigHornetLeafy = -61;

		// Token: 0x04002A8C RID: 10892
		public const short LittleHornetLeafy = -60;

		// Token: 0x04002A8D RID: 10893
		public const short BigHornetHoney = -59;

		// Token: 0x04002A8E RID: 10894
		public const short LittleHornetHoney = -58;

		// Token: 0x04002A8F RID: 10895
		public const short BigHornetFatty = -57;

		// Token: 0x04002A90 RID: 10896
		public const short LittleHornetFatty = -56;

		// Token: 0x04002A91 RID: 10897
		public const short BigRainZombie = -55;

		// Token: 0x04002A92 RID: 10898
		public const short SmallRainZombie = -54;

		// Token: 0x04002A93 RID: 10899
		public const short BigPantlessSkeleton = -53;

		// Token: 0x04002A94 RID: 10900
		public const short SmallPantlessSkeleton = -52;

		// Token: 0x04002A95 RID: 10901
		public const short BigMisassembledSkeleton = -51;

		// Token: 0x04002A96 RID: 10902
		public const short SmallMisassembledSkeleton = -50;

		// Token: 0x04002A97 RID: 10903
		public const short BigHeadacheSkeleton = -49;

		// Token: 0x04002A98 RID: 10904
		public const short SmallHeadacheSkeleton = -48;

		// Token: 0x04002A99 RID: 10905
		public const short BigSkeleton = -47;

		// Token: 0x04002A9A RID: 10906
		public const short SmallSkeleton = -46;

		// Token: 0x04002A9B RID: 10907
		public const short BigFemaleZombie = -45;

		// Token: 0x04002A9C RID: 10908
		public const short SmallFemaleZombie = -44;

		// Token: 0x04002A9D RID: 10909
		public const short DemonEye2 = -43;

		// Token: 0x04002A9E RID: 10910
		public const short PurpleEye2 = -42;

		// Token: 0x04002A9F RID: 10911
		public const short GreenEye2 = -41;

		// Token: 0x04002AA0 RID: 10912
		public const short DialatedEye2 = -40;

		// Token: 0x04002AA1 RID: 10913
		public const short SleepyEye2 = -39;

		// Token: 0x04002AA2 RID: 10914
		public const short CataractEye2 = -38;

		// Token: 0x04002AA3 RID: 10915
		public const short BigTwiggyZombie = -37;

		// Token: 0x04002AA4 RID: 10916
		public const short SmallTwiggyZombie = -36;

		// Token: 0x04002AA5 RID: 10917
		public const short BigSwampZombie = -35;

		// Token: 0x04002AA6 RID: 10918
		public const short SmallSwampZombie = -34;

		// Token: 0x04002AA7 RID: 10919
		public const short BigSlimedZombie = -33;

		// Token: 0x04002AA8 RID: 10920
		public const short SmallSlimedZombie = -32;

		// Token: 0x04002AA9 RID: 10921
		public const short BigPincushionZombie = -31;

		// Token: 0x04002AAA RID: 10922
		public const short SmallPincushionZombie = -30;

		// Token: 0x04002AAB RID: 10923
		public const short BigBaldZombie = -29;

		// Token: 0x04002AAC RID: 10924
		public const short SmallBaldZombie = -28;

		// Token: 0x04002AAD RID: 10925
		public const short BigZombie = -27;

		// Token: 0x04002AAE RID: 10926
		public const short SmallZombie = -26;

		// Token: 0x04002AAF RID: 10927
		public const short BigCrimslime = -25;

		// Token: 0x04002AB0 RID: 10928
		public const short LittleCrimslime = -24;

		// Token: 0x04002AB1 RID: 10929
		public const short BigCrimera = -23;

		// Token: 0x04002AB2 RID: 10930
		public const short LittleCrimera = -22;

		// Token: 0x04002AB3 RID: 10931
		public const short GiantMossHornet = -21;

		// Token: 0x04002AB4 RID: 10932
		public const short BigMossHornet = -20;

		// Token: 0x04002AB5 RID: 10933
		public const short LittleMossHornet = -19;

		// Token: 0x04002AB6 RID: 10934
		public const short TinyMossHornet = -18;

		// Token: 0x04002AB7 RID: 10935
		public const short BigStinger = -17;

		// Token: 0x04002AB8 RID: 10936
		public const short LittleStinger = -16;

		// Token: 0x04002AB9 RID: 10937
		public const short HeavySkeleton = -15;

		// Token: 0x04002ABA RID: 10938
		public const short BigBoned = -14;

		// Token: 0x04002ABB RID: 10939
		public const short ShortBones = -13;

		// Token: 0x04002ABC RID: 10940
		public const short BigEater = -12;

		// Token: 0x04002ABD RID: 10941
		public const short LittleEater = -11;

		// Token: 0x04002ABE RID: 10942
		public const short JungleSlime = -10;

		// Token: 0x04002ABF RID: 10943
		public const short YellowSlime = -9;

		// Token: 0x04002AC0 RID: 10944
		public const short RedSlime = -8;

		// Token: 0x04002AC1 RID: 10945
		public const short PurpleSlime = -7;

		// Token: 0x04002AC2 RID: 10946
		public const short BlackSlime = -6;

		// Token: 0x04002AC3 RID: 10947
		public const short BabySlime = -5;

		// Token: 0x04002AC4 RID: 10948
		public const short Pinky = -4;

		// Token: 0x04002AC5 RID: 10949
		public const short GreenSlime = -3;

		// Token: 0x04002AC6 RID: 10950
		public const short Slimer2 = -2;

		// Token: 0x04002AC7 RID: 10951
		public const short Slimeling = -1;

		// Token: 0x04002AC8 RID: 10952
		public const short None = 0;

		// Token: 0x04002AC9 RID: 10953
		public const short BlueSlime = 1;

		// Token: 0x04002ACA RID: 10954
		public const short DemonEye = 2;

		// Token: 0x04002ACB RID: 10955
		public const short Zombie = 3;

		// Token: 0x04002ACC RID: 10956
		public const short EyeofCthulhu = 4;

		// Token: 0x04002ACD RID: 10957
		public const short ServantofCthulhu = 5;

		// Token: 0x04002ACE RID: 10958
		public const short EaterofSouls = 6;

		// Token: 0x04002ACF RID: 10959
		public const short DevourerHead = 7;

		// Token: 0x04002AD0 RID: 10960
		public const short DevourerBody = 8;

		// Token: 0x04002AD1 RID: 10961
		public const short DevourerTail = 9;

		// Token: 0x04002AD2 RID: 10962
		public const short GiantWormHead = 10;

		// Token: 0x04002AD3 RID: 10963
		public const short GiantWormBody = 11;

		// Token: 0x04002AD4 RID: 10964
		public const short GiantWormTail = 12;

		// Token: 0x04002AD5 RID: 10965
		public const short EaterofWorldsHead = 13;

		// Token: 0x04002AD6 RID: 10966
		public const short EaterofWorldsBody = 14;

		// Token: 0x04002AD7 RID: 10967
		public const short EaterofWorldsTail = 15;

		// Token: 0x04002AD8 RID: 10968
		public const short MotherSlime = 16;

		// Token: 0x04002AD9 RID: 10969
		public const short Merchant = 17;

		// Token: 0x04002ADA RID: 10970
		public const short Nurse = 18;

		// Token: 0x04002ADB RID: 10971
		public const short ArmsDealer = 19;

		// Token: 0x04002ADC RID: 10972
		public const short Dryad = 20;

		// Token: 0x04002ADD RID: 10973
		public const short Skeleton = 21;

		// Token: 0x04002ADE RID: 10974
		public const short Guide = 22;

		// Token: 0x04002ADF RID: 10975
		public const short MeteorHead = 23;

		// Token: 0x04002AE0 RID: 10976
		public const short FireImp = 24;

		// Token: 0x04002AE1 RID: 10977
		public const short BurningSphere = 25;

		// Token: 0x04002AE2 RID: 10978
		public const short GoblinPeon = 26;

		// Token: 0x04002AE3 RID: 10979
		public const short GoblinThief = 27;

		// Token: 0x04002AE4 RID: 10980
		public const short GoblinWarrior = 28;

		// Token: 0x04002AE5 RID: 10981
		public const short GoblinSorcerer = 29;

		// Token: 0x04002AE6 RID: 10982
		public const short ChaosBall = 30;

		// Token: 0x04002AE7 RID: 10983
		public const short AngryBones = 31;

		// Token: 0x04002AE8 RID: 10984
		public const short DarkCaster = 32;

		// Token: 0x04002AE9 RID: 10985
		public const short WaterSphere = 33;

		// Token: 0x04002AEA RID: 10986
		public const short CursedSkull = 34;

		// Token: 0x04002AEB RID: 10987
		public const short SkeletronHead = 35;

		// Token: 0x04002AEC RID: 10988
		public const short SkeletronHand = 36;

		// Token: 0x04002AED RID: 10989
		public const short OldMan = 37;

		// Token: 0x04002AEE RID: 10990
		public const short Demolitionist = 38;

		// Token: 0x04002AEF RID: 10991
		public const short BoneSerpentHead = 39;

		// Token: 0x04002AF0 RID: 10992
		public const short BoneSerpentBody = 40;

		// Token: 0x04002AF1 RID: 10993
		public const short BoneSerpentTail = 41;

		// Token: 0x04002AF2 RID: 10994
		public const short Hornet = 42;

		// Token: 0x04002AF3 RID: 10995
		public const short ManEater = 43;

		// Token: 0x04002AF4 RID: 10996
		public const short UndeadMiner = 44;

		// Token: 0x04002AF5 RID: 10997
		public const short Tim = 45;

		// Token: 0x04002AF6 RID: 10998
		public const short Bunny = 46;

		// Token: 0x04002AF7 RID: 10999
		public const short CorruptBunny = 47;

		// Token: 0x04002AF8 RID: 11000
		public const short Harpy = 48;

		// Token: 0x04002AF9 RID: 11001
		public const short CaveBat = 49;

		// Token: 0x04002AFA RID: 11002
		public const short KingSlime = 50;

		// Token: 0x04002AFB RID: 11003
		public const short JungleBat = 51;

		// Token: 0x04002AFC RID: 11004
		public const short DoctorBones = 52;

		// Token: 0x04002AFD RID: 11005
		public const short TheGroom = 53;

		// Token: 0x04002AFE RID: 11006
		public const short Clothier = 54;

		// Token: 0x04002AFF RID: 11007
		public const short Goldfish = 55;

		// Token: 0x04002B00 RID: 11008
		public const short Snatcher = 56;

		// Token: 0x04002B01 RID: 11009
		public const short CorruptGoldfish = 57;

		// Token: 0x04002B02 RID: 11010
		public const short Piranha = 58;

		// Token: 0x04002B03 RID: 11011
		public const short LavaSlime = 59;

		// Token: 0x04002B04 RID: 11012
		public const short Hellbat = 60;

		// Token: 0x04002B05 RID: 11013
		public const short Vulture = 61;

		// Token: 0x04002B06 RID: 11014
		public const short Demon = 62;

		// Token: 0x04002B07 RID: 11015
		public const short BlueJellyfish = 63;

		// Token: 0x04002B08 RID: 11016
		public const short PinkJellyfish = 64;

		// Token: 0x04002B09 RID: 11017
		public const short Shark = 65;

		// Token: 0x04002B0A RID: 11018
		public const short VoodooDemon = 66;

		// Token: 0x04002B0B RID: 11019
		public const short Crab = 67;

		// Token: 0x04002B0C RID: 11020
		public const short DungeonGuardian = 68;

		// Token: 0x04002B0D RID: 11021
		public const short Antlion = 69;

		// Token: 0x04002B0E RID: 11022
		public const short SpikeBall = 70;

		// Token: 0x04002B0F RID: 11023
		public const short DungeonSlime = 71;

		// Token: 0x04002B10 RID: 11024
		public const short BlazingWheel = 72;

		// Token: 0x04002B11 RID: 11025
		public const short GoblinScout = 73;

		// Token: 0x04002B12 RID: 11026
		public const short Bird = 74;

		// Token: 0x04002B13 RID: 11027
		public const short Pixie = 75;

		// Token: 0x04002B14 RID: 11028
		public const short None2 = 76;

		// Token: 0x04002B15 RID: 11029
		public const short ArmoredSkeleton = 77;

		// Token: 0x04002B16 RID: 11030
		public const short Mummy = 78;

		// Token: 0x04002B17 RID: 11031
		public const short DarkMummy = 79;

		// Token: 0x04002B18 RID: 11032
		public const short LightMummy = 80;

		// Token: 0x04002B19 RID: 11033
		public const short CorruptSlime = 81;

		// Token: 0x04002B1A RID: 11034
		public const short Wraith = 82;

		// Token: 0x04002B1B RID: 11035
		public const short CursedHammer = 83;

		// Token: 0x04002B1C RID: 11036
		public const short EnchantedSword = 84;

		// Token: 0x04002B1D RID: 11037
		public const short Mimic = 85;

		// Token: 0x04002B1E RID: 11038
		public const short Unicorn = 86;

		// Token: 0x04002B1F RID: 11039
		public const short WyvernHead = 87;

		// Token: 0x04002B20 RID: 11040
		public const short WyvernLegs = 88;

		// Token: 0x04002B21 RID: 11041
		public const short WyvernBody = 89;

		// Token: 0x04002B22 RID: 11042
		public const short WyvernBody2 = 90;

		// Token: 0x04002B23 RID: 11043
		public const short WyvernBody3 = 91;

		// Token: 0x04002B24 RID: 11044
		public const short WyvernTail = 92;

		// Token: 0x04002B25 RID: 11045
		public const short GiantBat = 93;

		// Token: 0x04002B26 RID: 11046
		public const short Corruptor = 94;

		// Token: 0x04002B27 RID: 11047
		public const short DiggerHead = 95;

		// Token: 0x04002B28 RID: 11048
		public const short DiggerBody = 96;

		// Token: 0x04002B29 RID: 11049
		public const short DiggerTail = 97;

		// Token: 0x04002B2A RID: 11050
		public const short SeekerHead = 98;

		// Token: 0x04002B2B RID: 11051
		public const short SeekerBody = 99;

		// Token: 0x04002B2C RID: 11052
		public const short SeekerTail = 100;

		// Token: 0x04002B2D RID: 11053
		public const short Clinger = 101;

		// Token: 0x04002B2E RID: 11054
		public const short AnglerFish = 102;

		// Token: 0x04002B2F RID: 11055
		public const short GreenJellyfish = 103;

		// Token: 0x04002B30 RID: 11056
		public const short Werewolf = 104;

		// Token: 0x04002B31 RID: 11057
		public const short BoundGoblin = 105;

		// Token: 0x04002B32 RID: 11058
		public const short BoundWizard = 106;

		// Token: 0x04002B33 RID: 11059
		public const short GoblinTinkerer = 107;

		// Token: 0x04002B34 RID: 11060
		public const short Wizard = 108;

		// Token: 0x04002B35 RID: 11061
		public const short Clown = 109;

		// Token: 0x04002B36 RID: 11062
		public const short SkeletonArcher = 110;

		// Token: 0x04002B37 RID: 11063
		public const short GoblinArcher = 111;

		// Token: 0x04002B38 RID: 11064
		public const short VileSpit = 112;

		// Token: 0x04002B39 RID: 11065
		public const short WallofFlesh = 113;

		// Token: 0x04002B3A RID: 11066
		public const short WallofFleshEye = 114;

		// Token: 0x04002B3B RID: 11067
		public const short TheHungry = 115;

		// Token: 0x04002B3C RID: 11068
		public const short TheHungryII = 116;

		// Token: 0x04002B3D RID: 11069
		public const short LeechHead = 117;

		// Token: 0x04002B3E RID: 11070
		public const short LeechBody = 118;

		// Token: 0x04002B3F RID: 11071
		public const short LeechTail = 119;

		// Token: 0x04002B40 RID: 11072
		public const short ChaosElemental = 120;

		// Token: 0x04002B41 RID: 11073
		public const short Slimer = 121;

		// Token: 0x04002B42 RID: 11074
		public const short Gastropod = 122;

		// Token: 0x04002B43 RID: 11075
		public const short BoundMechanic = 123;

		// Token: 0x04002B44 RID: 11076
		public const short Mechanic = 124;

		// Token: 0x04002B45 RID: 11077
		public const short Retinazer = 125;

		// Token: 0x04002B46 RID: 11078
		public const short Spazmatism = 126;

		// Token: 0x04002B47 RID: 11079
		public const short SkeletronPrime = 127;

		// Token: 0x04002B48 RID: 11080
		public const short PrimeCannon = 128;

		// Token: 0x04002B49 RID: 11081
		public const short PrimeSaw = 129;

		// Token: 0x04002B4A RID: 11082
		public const short PrimeVice = 130;

		// Token: 0x04002B4B RID: 11083
		public const short PrimeLaser = 131;

		// Token: 0x04002B4C RID: 11084
		public const short BaldZombie = 132;

		// Token: 0x04002B4D RID: 11085
		public const short WanderingEye = 133;

		// Token: 0x04002B4E RID: 11086
		public const short TheDestroyer = 134;

		// Token: 0x04002B4F RID: 11087
		public const short TheDestroyerBody = 135;

		// Token: 0x04002B50 RID: 11088
		public const short TheDestroyerTail = 136;

		// Token: 0x04002B51 RID: 11089
		public const short IlluminantBat = 137;

		// Token: 0x04002B52 RID: 11090
		public const short IlluminantSlime = 138;

		// Token: 0x04002B53 RID: 11091
		public const short Probe = 139;

		// Token: 0x04002B54 RID: 11092
		public const short PossessedArmor = 140;

		// Token: 0x04002B55 RID: 11093
		public const short ToxicSludge = 141;

		// Token: 0x04002B56 RID: 11094
		public const short SantaClaus = 142;

		// Token: 0x04002B57 RID: 11095
		public const short SnowmanGangsta = 143;

		// Token: 0x04002B58 RID: 11096
		public const short MisterStabby = 144;

		// Token: 0x04002B59 RID: 11097
		public const short SnowBalla = 145;

		// Token: 0x04002B5A RID: 11098
		public const short None3 = 146;

		// Token: 0x04002B5B RID: 11099
		public const short IceSlime = 147;

		// Token: 0x04002B5C RID: 11100
		public const short Penguin = 148;

		// Token: 0x04002B5D RID: 11101
		public const short PenguinBlack = 149;

		// Token: 0x04002B5E RID: 11102
		public const short IceBat = 150;

		// Token: 0x04002B5F RID: 11103
		public const short Lavabat = 151;

		// Token: 0x04002B60 RID: 11104
		public const short GiantFlyingFox = 152;

		// Token: 0x04002B61 RID: 11105
		public const short GiantTortoise = 153;

		// Token: 0x04002B62 RID: 11106
		public const short IceTortoise = 154;

		// Token: 0x04002B63 RID: 11107
		public const short Wolf = 155;

		// Token: 0x04002B64 RID: 11108
		public const short RedDevil = 156;

		// Token: 0x04002B65 RID: 11109
		public const short Arapaima = 157;

		// Token: 0x04002B66 RID: 11110
		public const short VampireBat = 158;

		// Token: 0x04002B67 RID: 11111
		public const short Vampire = 159;

		// Token: 0x04002B68 RID: 11112
		public const short Truffle = 160;

		// Token: 0x04002B69 RID: 11113
		public const short ZombieEskimo = 161;

		// Token: 0x04002B6A RID: 11114
		public const short Frankenstein = 162;

		// Token: 0x04002B6B RID: 11115
		public const short BlackRecluse = 163;

		// Token: 0x04002B6C RID: 11116
		public const short WallCreeper = 164;

		// Token: 0x04002B6D RID: 11117
		public const short WallCreeperWall = 165;

		// Token: 0x04002B6E RID: 11118
		public const short SwampThing = 166;

		// Token: 0x04002B6F RID: 11119
		public const short UndeadViking = 167;

		// Token: 0x04002B70 RID: 11120
		public const short CorruptPenguin = 168;

		// Token: 0x04002B71 RID: 11121
		public const short IceElemental = 169;

		// Token: 0x04002B72 RID: 11122
		public const short PigronCorruption = 170;

		// Token: 0x04002B73 RID: 11123
		public const short PigronHallow = 171;

		// Token: 0x04002B74 RID: 11124
		public const short RuneWizard = 172;

		// Token: 0x04002B75 RID: 11125
		public const short Crimera = 173;

		// Token: 0x04002B76 RID: 11126
		public const short Herpling = 174;

		// Token: 0x04002B77 RID: 11127
		public const short AngryTrapper = 175;

		// Token: 0x04002B78 RID: 11128
		public const short MossHornet = 176;

		// Token: 0x04002B79 RID: 11129
		public const short Derpling = 177;

		// Token: 0x04002B7A RID: 11130
		public const short Steampunker = 178;

		// Token: 0x04002B7B RID: 11131
		public const short CrimsonAxe = 179;

		// Token: 0x04002B7C RID: 11132
		public const short PigronCrimson = 180;

		// Token: 0x04002B7D RID: 11133
		public const short FaceMonster = 181;

		// Token: 0x04002B7E RID: 11134
		public const short FloatyGross = 182;

		// Token: 0x04002B7F RID: 11135
		public const short Crimslime = 183;

		// Token: 0x04002B80 RID: 11136
		public const short SpikedIceSlime = 184;

		// Token: 0x04002B81 RID: 11137
		public const short SnowFlinx = 185;

		// Token: 0x04002B82 RID: 11138
		public const short PincushionZombie = 186;

		// Token: 0x04002B83 RID: 11139
		public const short SlimedZombie = 187;

		// Token: 0x04002B84 RID: 11140
		public const short SwampZombie = 188;

		// Token: 0x04002B85 RID: 11141
		public const short TwiggyZombie = 189;

		// Token: 0x04002B86 RID: 11142
		public const short CataractEye = 190;

		// Token: 0x04002B87 RID: 11143
		public const short SleepyEye = 191;

		// Token: 0x04002B88 RID: 11144
		public const short DialatedEye = 192;

		// Token: 0x04002B89 RID: 11145
		public const short GreenEye = 193;

		// Token: 0x04002B8A RID: 11146
		public const short PurpleEye = 194;

		// Token: 0x04002B8B RID: 11147
		public const short LostGirl = 195;

		// Token: 0x04002B8C RID: 11148
		public const short Nymph = 196;

		// Token: 0x04002B8D RID: 11149
		public const short ArmoredViking = 197;

		// Token: 0x04002B8E RID: 11150
		public const short Lihzahrd = 198;

		// Token: 0x04002B8F RID: 11151
		public const short LihzahrdCrawler = 199;

		// Token: 0x04002B90 RID: 11152
		public const short FemaleZombie = 200;

		// Token: 0x04002B91 RID: 11153
		public const short HeadacheSkeleton = 201;

		// Token: 0x04002B92 RID: 11154
		public const short MisassembledSkeleton = 202;

		// Token: 0x04002B93 RID: 11155
		public const short PantlessSkeleton = 203;

		// Token: 0x04002B94 RID: 11156
		public const short SpikedJungleSlime = 204;

		// Token: 0x04002B95 RID: 11157
		public const short Moth = 205;

		// Token: 0x04002B96 RID: 11158
		public const short IcyMerman = 206;

		// Token: 0x04002B97 RID: 11159
		public const short DyeTrader = 207;

		// Token: 0x04002B98 RID: 11160
		public const short PartyGirl = 208;

		// Token: 0x04002B99 RID: 11161
		public const short Cyborg = 209;

		// Token: 0x04002B9A RID: 11162
		public const short Bee = 210;

		// Token: 0x04002B9B RID: 11163
		public const short BeeSmall = 211;

		// Token: 0x04002B9C RID: 11164
		public const short PirateDeckhand = 212;

		// Token: 0x04002B9D RID: 11165
		public const short PirateCorsair = 213;

		// Token: 0x04002B9E RID: 11166
		public const short PirateDeadeye = 214;

		// Token: 0x04002B9F RID: 11167
		public const short PirateCrossbower = 215;

		// Token: 0x04002BA0 RID: 11168
		public const short PirateCaptain = 216;

		// Token: 0x04002BA1 RID: 11169
		public const short CochinealBeetle = 217;

		// Token: 0x04002BA2 RID: 11170
		public const short CyanBeetle = 218;

		// Token: 0x04002BA3 RID: 11171
		public const short LacBeetle = 219;

		// Token: 0x04002BA4 RID: 11172
		public const short SeaSnail = 220;

		// Token: 0x04002BA5 RID: 11173
		public const short Squid = 221;

		// Token: 0x04002BA6 RID: 11174
		public const short QueenBee = 222;

		// Token: 0x04002BA7 RID: 11175
		public const short ZombieRaincoat = 223;

		// Token: 0x04002BA8 RID: 11176
		public const short FlyingFish = 224;

		// Token: 0x04002BA9 RID: 11177
		public const short UmbrellaSlime = 225;

		// Token: 0x04002BAA RID: 11178
		public const short FlyingSnake = 226;

		// Token: 0x04002BAB RID: 11179
		public const short Painter = 227;

		// Token: 0x04002BAC RID: 11180
		public const short WitchDoctor = 228;

		// Token: 0x04002BAD RID: 11181
		public const short Pirate = 229;

		// Token: 0x04002BAE RID: 11182
		public const short GoldfishWalker = 230;

		// Token: 0x04002BAF RID: 11183
		public const short HornetFatty = 231;

		// Token: 0x04002BB0 RID: 11184
		public const short HornetHoney = 232;

		// Token: 0x04002BB1 RID: 11185
		public const short HornetLeafy = 233;

		// Token: 0x04002BB2 RID: 11186
		public const short HornetSpikey = 234;

		// Token: 0x04002BB3 RID: 11187
		public const short HornetStingy = 235;

		// Token: 0x04002BB4 RID: 11188
		public const short JungleCreeper = 236;

		// Token: 0x04002BB5 RID: 11189
		public const short JungleCreeperWall = 237;

		// Token: 0x04002BB6 RID: 11190
		public const short BlackRecluseWall = 238;

		// Token: 0x04002BB7 RID: 11191
		public const short BloodCrawler = 239;

		// Token: 0x04002BB8 RID: 11192
		public const short BloodCrawlerWall = 240;

		// Token: 0x04002BB9 RID: 11193
		public const short BloodFeeder = 241;

		// Token: 0x04002BBA RID: 11194
		public const short BloodJelly = 242;

		// Token: 0x04002BBB RID: 11195
		public const short IceGolem = 243;

		// Token: 0x04002BBC RID: 11196
		public const short RainbowSlime = 244;

		// Token: 0x04002BBD RID: 11197
		public const short Golem = 245;

		// Token: 0x04002BBE RID: 11198
		public const short GolemHead = 246;

		// Token: 0x04002BBF RID: 11199
		public const short GolemFistLeft = 247;

		// Token: 0x04002BC0 RID: 11200
		public const short GolemFistRight = 248;

		// Token: 0x04002BC1 RID: 11201
		public const short GolemHeadFree = 249;

		// Token: 0x04002BC2 RID: 11202
		public const short AngryNimbus = 250;

		// Token: 0x04002BC3 RID: 11203
		public const short Eyezor = 251;

		// Token: 0x04002BC4 RID: 11204
		public const short Parrot = 252;

		// Token: 0x04002BC5 RID: 11205
		public const short Reaper = 253;

		// Token: 0x04002BC6 RID: 11206
		public const short ZombieMushroom = 254;

		// Token: 0x04002BC7 RID: 11207
		public const short ZombieMushroomHat = 255;

		// Token: 0x04002BC8 RID: 11208
		public const short FungoFish = 256;

		// Token: 0x04002BC9 RID: 11209
		public const short AnomuraFungus = 257;

		// Token: 0x04002BCA RID: 11210
		public const short MushiLadybug = 258;

		// Token: 0x04002BCB RID: 11211
		public const short FungiBulb = 259;

		// Token: 0x04002BCC RID: 11212
		public const short GiantFungiBulb = 260;

		// Token: 0x04002BCD RID: 11213
		public const short FungiSpore = 261;

		// Token: 0x04002BCE RID: 11214
		public const short Plantera = 262;

		// Token: 0x04002BCF RID: 11215
		public const short PlanterasHook = 263;

		// Token: 0x04002BD0 RID: 11216
		public const short PlanterasTentacle = 264;

		// Token: 0x04002BD1 RID: 11217
		public const short Spore = 265;

		// Token: 0x04002BD2 RID: 11218
		public const short BrainofCthulhu = 266;

		// Token: 0x04002BD3 RID: 11219
		public const short Creeper = 267;

		// Token: 0x04002BD4 RID: 11220
		public const short IchorSticker = 268;

		// Token: 0x04002BD5 RID: 11221
		public const short RustyArmoredBonesAxe = 269;

		// Token: 0x04002BD6 RID: 11222
		public const short RustyArmoredBonesFlail = 270;

		// Token: 0x04002BD7 RID: 11223
		public const short RustyArmoredBonesSword = 271;

		// Token: 0x04002BD8 RID: 11224
		public const short RustyArmoredBonesSwordNoArmor = 272;

		// Token: 0x04002BD9 RID: 11225
		public const short BlueArmoredBones = 273;

		// Token: 0x04002BDA RID: 11226
		public const short BlueArmoredBonesMace = 274;

		// Token: 0x04002BDB RID: 11227
		public const short BlueArmoredBonesNoPants = 275;

		// Token: 0x04002BDC RID: 11228
		public const short BlueArmoredBonesSword = 276;

		// Token: 0x04002BDD RID: 11229
		public const short HellArmoredBones = 277;

		// Token: 0x04002BDE RID: 11230
		public const short HellArmoredBonesSpikeShield = 278;

		// Token: 0x04002BDF RID: 11231
		public const short HellArmoredBonesMace = 279;

		// Token: 0x04002BE0 RID: 11232
		public const short HellArmoredBonesSword = 280;

		// Token: 0x04002BE1 RID: 11233
		public const short RaggedCaster = 281;

		// Token: 0x04002BE2 RID: 11234
		public const short RaggedCasterOpenCoat = 282;

		// Token: 0x04002BE3 RID: 11235
		public const short Necromancer = 283;

		// Token: 0x04002BE4 RID: 11236
		public const short NecromancerArmored = 284;

		// Token: 0x04002BE5 RID: 11237
		public const short DiabolistRed = 285;

		// Token: 0x04002BE6 RID: 11238
		public const short DiabolistWhite = 286;

		// Token: 0x04002BE7 RID: 11239
		public const short BoneLee = 287;

		// Token: 0x04002BE8 RID: 11240
		public const short DungeonSpirit = 288;

		// Token: 0x04002BE9 RID: 11241
		public const short GiantCursedSkull = 289;

		// Token: 0x04002BEA RID: 11242
		public const short Paladin = 290;

		// Token: 0x04002BEB RID: 11243
		public const short SkeletonSniper = 291;

		// Token: 0x04002BEC RID: 11244
		public const short TacticalSkeleton = 292;

		// Token: 0x04002BED RID: 11245
		public const short SkeletonCommando = 293;

		// Token: 0x04002BEE RID: 11246
		public const short AngryBonesBig = 294;

		// Token: 0x04002BEF RID: 11247
		public const short AngryBonesBigMuscle = 295;

		// Token: 0x04002BF0 RID: 11248
		public const short AngryBonesBigHelmet = 296;

		// Token: 0x04002BF1 RID: 11249
		public const short BirdBlue = 297;

		// Token: 0x04002BF2 RID: 11250
		public const short BirdRed = 298;

		// Token: 0x04002BF3 RID: 11251
		public const short Squirrel = 299;

		// Token: 0x04002BF4 RID: 11252
		public const short Mouse = 300;

		// Token: 0x04002BF5 RID: 11253
		public const short Raven = 301;

		// Token: 0x04002BF6 RID: 11254
		public const short SlimeMasked = 302;

		// Token: 0x04002BF7 RID: 11255
		public const short BunnySlimed = 303;

		// Token: 0x04002BF8 RID: 11256
		public const short HoppinJack = 304;

		// Token: 0x04002BF9 RID: 11257
		public const short Scarecrow1 = 305;

		// Token: 0x04002BFA RID: 11258
		public const short Scarecrow2 = 306;

		// Token: 0x04002BFB RID: 11259
		public const short Scarecrow3 = 307;

		// Token: 0x04002BFC RID: 11260
		public const short Scarecrow4 = 308;

		// Token: 0x04002BFD RID: 11261
		public const short Scarecrow5 = 309;

		// Token: 0x04002BFE RID: 11262
		public const short Scarecrow6 = 310;

		// Token: 0x04002BFF RID: 11263
		public const short Scarecrow7 = 311;

		// Token: 0x04002C00 RID: 11264
		public const short Scarecrow8 = 312;

		// Token: 0x04002C01 RID: 11265
		public const short Scarecrow9 = 313;

		// Token: 0x04002C02 RID: 11266
		public const short Scarecrow10 = 314;

		// Token: 0x04002C03 RID: 11267
		public const short HeadlessHorseman = 315;

		// Token: 0x04002C04 RID: 11268
		public const short Ghost = 316;

		// Token: 0x04002C05 RID: 11269
		public const short DemonEyeOwl = 317;

		// Token: 0x04002C06 RID: 11270
		public const short DemonEyeSpaceship = 318;

		// Token: 0x04002C07 RID: 11271
		public const short ZombieDoctor = 319;

		// Token: 0x04002C08 RID: 11272
		public const short ZombieSuperman = 320;

		// Token: 0x04002C09 RID: 11273
		public const short ZombiePixie = 321;

		// Token: 0x04002C0A RID: 11274
		public const short SkeletonTopHat = 322;

		// Token: 0x04002C0B RID: 11275
		public const short SkeletonAstonaut = 323;

		// Token: 0x04002C0C RID: 11276
		public const short SkeletonAlien = 324;

		// Token: 0x04002C0D RID: 11277
		public const short MourningWood = 325;

		// Token: 0x04002C0E RID: 11278
		public const short Splinterling = 326;

		// Token: 0x04002C0F RID: 11279
		public const short Pumpking = 327;

		// Token: 0x04002C10 RID: 11280
		public const short PumpkingBlade = 328;

		// Token: 0x04002C11 RID: 11281
		public const short Hellhound = 329;

		// Token: 0x04002C12 RID: 11282
		public const short Poltergeist = 330;

		// Token: 0x04002C13 RID: 11283
		public const short ZombieXmas = 331;

		// Token: 0x04002C14 RID: 11284
		public const short ZombieSweater = 332;

		// Token: 0x04002C15 RID: 11285
		public const short SlimeRibbonWhite = 333;

		// Token: 0x04002C16 RID: 11286
		public const short SlimeRibbonYellow = 334;

		// Token: 0x04002C17 RID: 11287
		public const short SlimeRibbonGreen = 335;

		// Token: 0x04002C18 RID: 11288
		public const short SlimeRibbonRed = 336;

		// Token: 0x04002C19 RID: 11289
		public const short BunnyXmas = 337;

		// Token: 0x04002C1A RID: 11290
		public const short ZombieElf = 338;

		// Token: 0x04002C1B RID: 11291
		public const short ZombieElfBeard = 339;

		// Token: 0x04002C1C RID: 11292
		public const short ZombieElfGirl = 340;

		// Token: 0x04002C1D RID: 11293
		public const short PresentMimic = 341;

		// Token: 0x04002C1E RID: 11294
		public const short GingerbreadMan = 342;

		// Token: 0x04002C1F RID: 11295
		public const short Yeti = 343;

		// Token: 0x04002C20 RID: 11296
		public const short Everscream = 344;

		// Token: 0x04002C21 RID: 11297
		public const short IceQueen = 345;

		// Token: 0x04002C22 RID: 11298
		public const short SantaNK1 = 346;

		// Token: 0x04002C23 RID: 11299
		public const short ElfCopter = 347;

		// Token: 0x04002C24 RID: 11300
		public const short Nutcracker = 348;

		// Token: 0x04002C25 RID: 11301
		public const short NutcrackerSpinning = 349;

		// Token: 0x04002C26 RID: 11302
		public const short ElfArcher = 350;

		// Token: 0x04002C27 RID: 11303
		public const short Krampus = 351;

		// Token: 0x04002C28 RID: 11304
		public const short Flocko = 352;

		// Token: 0x04002C29 RID: 11305
		public const short Stylist = 353;

		// Token: 0x04002C2A RID: 11306
		public const short WebbedStylist = 354;

		// Token: 0x04002C2B RID: 11307
		public const short Firefly = 355;

		// Token: 0x04002C2C RID: 11308
		public const short Butterfly = 356;

		// Token: 0x04002C2D RID: 11309
		public const short Worm = 357;

		// Token: 0x04002C2E RID: 11310
		public const short LightningBug = 358;

		// Token: 0x04002C2F RID: 11311
		public const short Snail = 359;

		// Token: 0x04002C30 RID: 11312
		public const short GlowingSnail = 360;

		// Token: 0x04002C31 RID: 11313
		public const short Frog = 361;

		// Token: 0x04002C32 RID: 11314
		public const short Duck = 362;

		// Token: 0x04002C33 RID: 11315
		public const short Duck2 = 363;

		// Token: 0x04002C34 RID: 11316
		public const short DuckWhite = 364;

		// Token: 0x04002C35 RID: 11317
		public const short DuckWhite2 = 365;

		// Token: 0x04002C36 RID: 11318
		public const short ScorpionBlack = 366;

		// Token: 0x04002C37 RID: 11319
		public const short Scorpion = 367;

		// Token: 0x04002C38 RID: 11320
		public const short TravellingMerchant = 368;

		// Token: 0x04002C39 RID: 11321
		public const short Angler = 369;

		// Token: 0x04002C3A RID: 11322
		public const short DukeFishron = 370;

		// Token: 0x04002C3B RID: 11323
		public const short DetonatingBubble = 371;

		// Token: 0x04002C3C RID: 11324
		public const short Sharkron = 372;

		// Token: 0x04002C3D RID: 11325
		public const short Sharkron2 = 373;

		// Token: 0x04002C3E RID: 11326
		public const short TruffleWorm = 374;

		// Token: 0x04002C3F RID: 11327
		public const short TruffleWormDigger = 375;

		// Token: 0x04002C40 RID: 11328
		public const short SleepingAngler = 376;

		// Token: 0x04002C41 RID: 11329
		public const short Grasshopper = 377;

		// Token: 0x04002C42 RID: 11330
		public const short ChatteringTeethBomb = 378;

		// Token: 0x04002C43 RID: 11331
		public const short CultistArcherBlue = 379;

		// Token: 0x04002C44 RID: 11332
		public const short CultistArcherWhite = 380;

		// Token: 0x04002C45 RID: 11333
		public const short BrainScrambler = 381;

		// Token: 0x04002C46 RID: 11334
		public const short RayGunner = 382;

		// Token: 0x04002C47 RID: 11335
		public const short MartianOfficer = 383;

		// Token: 0x04002C48 RID: 11336
		public const short ForceBubble = 384;

		// Token: 0x04002C49 RID: 11337
		public const short GrayGrunt = 385;

		// Token: 0x04002C4A RID: 11338
		public const short MartianEngineer = 386;

		// Token: 0x04002C4B RID: 11339
		public const short MartianTurret = 387;

		// Token: 0x04002C4C RID: 11340
		public const short MartianDrone = 388;

		// Token: 0x04002C4D RID: 11341
		public const short GigaZapper = 389;

		// Token: 0x04002C4E RID: 11342
		public const short ScutlixRider = 390;

		// Token: 0x04002C4F RID: 11343
		public const short Scutlix = 391;

		// Token: 0x04002C50 RID: 11344
		public const short MartianSaucer = 392;

		// Token: 0x04002C51 RID: 11345
		public const short MartianSaucerTurret = 393;

		// Token: 0x04002C52 RID: 11346
		public const short MartianSaucerCannon = 394;

		// Token: 0x04002C53 RID: 11347
		public const short MartianSaucerCore = 395;

		// Token: 0x04002C54 RID: 11348
		public const short MoonLordHead = 396;

		// Token: 0x04002C55 RID: 11349
		public const short MoonLordHand = 397;

		// Token: 0x04002C56 RID: 11350
		public const short MoonLordCore = 398;

		// Token: 0x04002C57 RID: 11351
		public const short MartianProbe = 399;

		// Token: 0x04002C58 RID: 11352
		public const short MoonLordFreeEye = 400;

		// Token: 0x04002C59 RID: 11353
		public const short MoonLordLeechBlob = 401;

		// Token: 0x04002C5A RID: 11354
		public const short StardustWormHead = 402;

		// Token: 0x04002C5B RID: 11355
		public const short StardustWormBody = 403;

		// Token: 0x04002C5C RID: 11356
		public const short StardustWormTail = 404;

		// Token: 0x04002C5D RID: 11357
		public const short StardustCellBig = 405;

		// Token: 0x04002C5E RID: 11358
		public const short StardustCellSmall = 406;

		// Token: 0x04002C5F RID: 11359
		public const short StardustJellyfishBig = 407;

		// Token: 0x04002C60 RID: 11360
		public const short StardustJellyfishSmall = 408;

		// Token: 0x04002C61 RID: 11361
		public const short StardustSpiderBig = 409;

		// Token: 0x04002C62 RID: 11362
		public const short StardustSpiderSmall = 410;

		// Token: 0x04002C63 RID: 11363
		public const short StardustSoldier = 411;

		// Token: 0x04002C64 RID: 11364
		public const short SolarCrawltipedeHead = 412;

		// Token: 0x04002C65 RID: 11365
		public const short SolarCrawltipedeBody = 413;

		// Token: 0x04002C66 RID: 11366
		public const short SolarCrawltipedeTail = 414;

		// Token: 0x04002C67 RID: 11367
		public const short SolarDrakomire = 415;

		// Token: 0x04002C68 RID: 11368
		public const short SolarDrakomireRider = 416;

		// Token: 0x04002C69 RID: 11369
		public const short SolarSroller = 417;

		// Token: 0x04002C6A RID: 11370
		public const short SolarCorite = 418;

		// Token: 0x04002C6B RID: 11371
		public const short SolarSolenian = 419;

		// Token: 0x04002C6C RID: 11372
		public const short NebulaBrain = 420;

		// Token: 0x04002C6D RID: 11373
		public const short NebulaHeadcrab = 421;

		// Token: 0x04002C6E RID: 11374
		public const short NebulaBeast = 423;

		// Token: 0x04002C6F RID: 11375
		public const short NebulaSoldier = 424;

		// Token: 0x04002C70 RID: 11376
		public const short VortexRifleman = 425;

		// Token: 0x04002C71 RID: 11377
		public const short VortexHornetQueen = 426;

		// Token: 0x04002C72 RID: 11378
		public const short VortexHornet = 427;

		// Token: 0x04002C73 RID: 11379
		public const short VortexLarva = 428;

		// Token: 0x04002C74 RID: 11380
		public const short VortexSoldier = 429;

		// Token: 0x04002C75 RID: 11381
		public const short ArmedZombie = 430;

		// Token: 0x04002C76 RID: 11382
		public const short ArmedZombieEskimo = 431;

		// Token: 0x04002C77 RID: 11383
		public const short ArmedZombiePincussion = 432;

		// Token: 0x04002C78 RID: 11384
		public const short ArmedZombieSlimed = 433;

		// Token: 0x04002C79 RID: 11385
		public const short ArmedZombieSwamp = 434;

		// Token: 0x04002C7A RID: 11386
		public const short ArmedZombieTwiggy = 435;

		// Token: 0x04002C7B RID: 11387
		public const short ArmedZombieCenx = 436;

		// Token: 0x04002C7C RID: 11388
		public const short CultistTablet = 437;

		// Token: 0x04002C7D RID: 11389
		public const short CultistDevote = 438;

		// Token: 0x04002C7E RID: 11390
		public const short CultistBoss = 439;

		// Token: 0x04002C7F RID: 11391
		public const short CultistBossClone = 440;

		// Token: 0x04002C80 RID: 11392
		public const short GoldBird = 442;

		// Token: 0x04002C81 RID: 11393
		public const short GoldBunny = 443;

		// Token: 0x04002C82 RID: 11394
		public const short GoldButterfly = 444;

		// Token: 0x04002C83 RID: 11395
		public const short GoldFrog = 445;

		// Token: 0x04002C84 RID: 11396
		public const short GoldGrasshopper = 446;

		// Token: 0x04002C85 RID: 11397
		public const short GoldMouse = 447;

		// Token: 0x04002C86 RID: 11398
		public const short GoldWorm = 448;

		// Token: 0x04002C87 RID: 11399
		public const short BoneThrowingSkeleton = 449;

		// Token: 0x04002C88 RID: 11400
		public const short BoneThrowingSkeleton2 = 450;

		// Token: 0x04002C89 RID: 11401
		public const short BoneThrowingSkeleton3 = 451;

		// Token: 0x04002C8A RID: 11402
		public const short BoneThrowingSkeleton4 = 452;

		// Token: 0x04002C8B RID: 11403
		public const short SkeletonMerchant = 453;

		// Token: 0x04002C8C RID: 11404
		public const short CultistDragonHead = 454;

		// Token: 0x04002C8D RID: 11405
		public const short CultistDragonBody1 = 455;

		// Token: 0x04002C8E RID: 11406
		public const short CultistDragonBody2 = 456;

		// Token: 0x04002C8F RID: 11407
		public const short CultistDragonBody3 = 457;

		// Token: 0x04002C90 RID: 11408
		public const short CultistDragonBody4 = 458;

		// Token: 0x04002C91 RID: 11409
		public const short CultistDragonTail = 459;

		// Token: 0x04002C92 RID: 11410
		public const short Butcher = 460;

		// Token: 0x04002C93 RID: 11411
		public const short CreatureFromTheDeep = 461;

		// Token: 0x04002C94 RID: 11412
		public const short Fritz = 462;

		// Token: 0x04002C95 RID: 11413
		public const short Nailhead = 463;

		// Token: 0x04002C96 RID: 11414
		public const short CrimsonBunny = 464;

		// Token: 0x04002C97 RID: 11415
		public const short CrimsonGoldfish = 465;

		// Token: 0x04002C98 RID: 11416
		public const short Psycho = 466;

		// Token: 0x04002C99 RID: 11417
		public const short DeadlySphere = 467;

		// Token: 0x04002C9A RID: 11418
		public const short DrManFly = 468;

		// Token: 0x04002C9B RID: 11419
		public const short ThePossessed = 469;

		// Token: 0x04002C9C RID: 11420
		public const short CrimsonPenguin = 470;

		// Token: 0x04002C9D RID: 11421
		public const short GoblinSummoner = 471;

		// Token: 0x04002C9E RID: 11422
		public const short ShadowFlameApparition = 472;

		// Token: 0x04002C9F RID: 11423
		public const short BigMimicCorruption = 473;

		// Token: 0x04002CA0 RID: 11424
		public const short BigMimicCrimson = 474;

		// Token: 0x04002CA1 RID: 11425
		public const short BigMimicHallow = 475;

		// Token: 0x04002CA2 RID: 11426
		public const short BigMimicJungle = 476;

		// Token: 0x04002CA3 RID: 11427
		public const short Mothron = 477;

		// Token: 0x04002CA4 RID: 11428
		public const short MothronEgg = 478;

		// Token: 0x04002CA5 RID: 11429
		public const short MothronSpawn = 479;

		// Token: 0x04002CA6 RID: 11430
		public const short Medusa = 480;

		// Token: 0x04002CA7 RID: 11431
		public const short GreekSkeleton = 481;

		// Token: 0x04002CA8 RID: 11432
		public const short GraniteGolem = 482;

		// Token: 0x04002CA9 RID: 11433
		public const short GraniteFlyer = 483;

		// Token: 0x04002CAA RID: 11434
		public const short EnchantedNightcrawler = 484;

		// Token: 0x04002CAB RID: 11435
		public const short Grubby = 485;

		// Token: 0x04002CAC RID: 11436
		public const short Sluggy = 486;

		// Token: 0x04002CAD RID: 11437
		public const short Buggy = 487;

		// Token: 0x04002CAE RID: 11438
		public const short TargetDummy = 488;

		// Token: 0x04002CAF RID: 11439
		public const short BloodZombie = 489;

		// Token: 0x04002CB0 RID: 11440
		public const short Drippler = 490;

		// Token: 0x04002CB1 RID: 11441
		public const short PirateShip = 491;

		// Token: 0x04002CB2 RID: 11442
		public const short PirateShipCannon = 492;

		// Token: 0x04002CB3 RID: 11443
		public const short LunarTowerStardust = 493;

		// Token: 0x04002CB4 RID: 11444
		public const short Crawdad = 494;

		// Token: 0x04002CB5 RID: 11445
		public const short Crawdad2 = 495;

		// Token: 0x04002CB6 RID: 11446
		public const short GiantShelly = 496;

		// Token: 0x04002CB7 RID: 11447
		public const short GiantShelly2 = 497;

		// Token: 0x04002CB8 RID: 11448
		public const short Salamander = 498;

		// Token: 0x04002CB9 RID: 11449
		public const short Salamander2 = 499;

		// Token: 0x04002CBA RID: 11450
		public const short Salamander3 = 500;

		// Token: 0x04002CBB RID: 11451
		public const short Salamander4 = 501;

		// Token: 0x04002CBC RID: 11452
		public const short Salamander5 = 502;

		// Token: 0x04002CBD RID: 11453
		public const short Salamander6 = 503;

		// Token: 0x04002CBE RID: 11454
		public const short Salamander7 = 504;

		// Token: 0x04002CBF RID: 11455
		public const short Salamander8 = 505;

		// Token: 0x04002CC0 RID: 11456
		public const short Salamander9 = 506;

		// Token: 0x04002CC1 RID: 11457
		public const short LunarTowerNebula = 507;

		// Token: 0x04002CC2 RID: 11458
		public const short LunarTowerVortex = 422;

		// Token: 0x04002CC3 RID: 11459
		public const short TaxCollector = 441;

		// Token: 0x04002CC4 RID: 11460
		public const short WalkingAntlion = 508;

		// Token: 0x04002CC5 RID: 11461
		public const short FlyingAntlion = 509;

		// Token: 0x04002CC6 RID: 11462
		public const short DuneSplicerHead = 510;

		// Token: 0x04002CC7 RID: 11463
		public const short DuneSplicerBody = 511;

		// Token: 0x04002CC8 RID: 11464
		public const short DuneSplicerTail = 512;

		// Token: 0x04002CC9 RID: 11465
		public const short TombCrawlerHead = 513;

		// Token: 0x04002CCA RID: 11466
		public const short TombCrawlerBody = 514;

		// Token: 0x04002CCB RID: 11467
		public const short TombCrawlerTail = 515;

		// Token: 0x04002CCC RID: 11468
		public const short SolarFlare = 516;

		// Token: 0x04002CCD RID: 11469
		public const short LunarTowerSolar = 517;

		// Token: 0x04002CCE RID: 11470
		public const short SolarSpearman = 518;

		// Token: 0x04002CCF RID: 11471
		public const short SolarGoop = 519;

		// Token: 0x04002CD0 RID: 11472
		public const short MartianWalker = 520;

		// Token: 0x04002CD1 RID: 11473
		public const short AncientCultistSquidhead = 521;

		// Token: 0x04002CD2 RID: 11474
		public const short AncientLight = 522;

		// Token: 0x04002CD3 RID: 11475
		public const short AncientDoom = 523;

		// Token: 0x04002CD4 RID: 11476
		public const short DesertGhoul = 524;

		// Token: 0x04002CD5 RID: 11477
		public const short DesertGhoulCorruption = 525;

		// Token: 0x04002CD6 RID: 11478
		public const short DesertGhoulCrimson = 526;

		// Token: 0x04002CD7 RID: 11479
		public const short DesertGhoulHallow = 527;

		// Token: 0x04002CD8 RID: 11480
		public const short DesertLamiaLight = 528;

		// Token: 0x04002CD9 RID: 11481
		public const short DesertLamiaDark = 529;

		// Token: 0x04002CDA RID: 11482
		public const short DesertScorpionWalk = 530;

		// Token: 0x04002CDB RID: 11483
		public const short DesertScorpionWall = 531;

		// Token: 0x04002CDC RID: 11484
		public const short DesertBeast = 532;

		// Token: 0x04002CDD RID: 11485
		public const short DesertDjinn = 533;

		// Token: 0x04002CDE RID: 11486
		public const short DemonTaxCollector = 534;

		// Token: 0x04002CDF RID: 11487
		public const short SlimeSpiked = 535;

		// Token: 0x04002CE0 RID: 11488
		public const short TheBride = 536;

		// Token: 0x04002CE1 RID: 11489
		public const short SandSlime = 537;

		// Token: 0x04002CE2 RID: 11490
		public const short SquirrelRed = 538;

		// Token: 0x04002CE3 RID: 11491
		public const short SquirrelGold = 539;

		// Token: 0x04002CE4 RID: 11492
		public const short PartyBunny = 540;

		// Token: 0x04002CE5 RID: 11493
		public const short SandElemental = 541;

		// Token: 0x04002CE6 RID: 11494
		public const short SandShark = 542;

		// Token: 0x04002CE7 RID: 11495
		public const short SandsharkCorrupt = 543;

		// Token: 0x04002CE8 RID: 11496
		public const short SandsharkCrimson = 544;

		// Token: 0x04002CE9 RID: 11497
		public const short SandsharkHallow = 545;

		// Token: 0x04002CEA RID: 11498
		public const short Tumbleweed = 546;

		// Token: 0x04002CEB RID: 11499
		public const short DD2AttackerTest = 547;

		// Token: 0x04002CEC RID: 11500
		public const short DD2EterniaCrystal = 548;

		// Token: 0x04002CED RID: 11501
		public const short DD2LanePortal = 549;

		// Token: 0x04002CEE RID: 11502
		public const short DD2Bartender = 550;

		// Token: 0x04002CEF RID: 11503
		public const short DD2Betsy = 551;

		// Token: 0x04002CF0 RID: 11504
		public const short DD2GoblinT1 = 552;

		// Token: 0x04002CF1 RID: 11505
		public const short DD2GoblinT2 = 553;

		// Token: 0x04002CF2 RID: 11506
		public const short DD2GoblinT3 = 554;

		// Token: 0x04002CF3 RID: 11507
		public const short DD2GoblinBomberT1 = 555;

		// Token: 0x04002CF4 RID: 11508
		public const short DD2GoblinBomberT2 = 556;

		// Token: 0x04002CF5 RID: 11509
		public const short DD2GoblinBomberT3 = 557;

		// Token: 0x04002CF6 RID: 11510
		public const short DD2WyvernT1 = 558;

		// Token: 0x04002CF7 RID: 11511
		public const short DD2WyvernT2 = 559;

		// Token: 0x04002CF8 RID: 11512
		public const short DD2WyvernT3 = 560;

		// Token: 0x04002CF9 RID: 11513
		public const short DD2JavelinstT1 = 561;

		// Token: 0x04002CFA RID: 11514
		public const short DD2JavelinstT2 = 562;

		// Token: 0x04002CFB RID: 11515
		public const short DD2JavelinstT3 = 563;

		// Token: 0x04002CFC RID: 11516
		public const short DD2DarkMageT1 = 564;

		// Token: 0x04002CFD RID: 11517
		public const short DD2DarkMageT3 = 565;

		// Token: 0x04002CFE RID: 11518
		public const short DD2SkeletonT1 = 566;

		// Token: 0x04002CFF RID: 11519
		public const short DD2SkeletonT3 = 567;

		// Token: 0x04002D00 RID: 11520
		public const short DD2WitherBeastT2 = 568;

		// Token: 0x04002D01 RID: 11521
		public const short DD2WitherBeastT3 = 569;

		// Token: 0x04002D02 RID: 11522
		public const short DD2DrakinT2 = 570;

		// Token: 0x04002D03 RID: 11523
		public const short DD2DrakinT3 = 571;

		// Token: 0x04002D04 RID: 11524
		public const short DD2KoboldWalkerT2 = 572;

		// Token: 0x04002D05 RID: 11525
		public const short DD2KoboldWalkerT3 = 573;

		// Token: 0x04002D06 RID: 11526
		public const short DD2KoboldFlyerT2 = 574;

		// Token: 0x04002D07 RID: 11527
		public const short DD2KoboldFlyerT3 = 575;

		// Token: 0x04002D08 RID: 11528
		public const short DD2OgreT2 = 576;

		// Token: 0x04002D09 RID: 11529
		public const short DD2OgreT3 = 577;

		// Token: 0x04002D0A RID: 11530
		public const short DD2LightningBugT3 = 578;

		// Token: 0x04002D0B RID: 11531
		public const short BartenderUnconscious = 579;

		// Token: 0x04002D0C RID: 11532
		public const short Count = 580;

		// Token: 0x02000276 RID: 630
		public static class Sets
		{
			// Token: 0x04003BF4 RID: 15348
			public static SetFactory Factory = new SetFactory(580);

			// Token: 0x04003BF5 RID: 15349
			public static int[] TrailingMode = NPCID.Sets.Factory.CreateIntSet(-1, new int[]
			{
				439,
				0,
				440,
				0,
				370,
				1,
				372,
				1,
				373,
				1,
				396,
				1,
				400,
				1,
				401,
				1,
				473,
				2,
				474,
				2,
				475,
				2,
				476,
				2,
				4,
				3,
				471,
				3,
				477,
				3,
				479,
				3,
				120,
				4,
				137,
				4,
				138,
				4,
				94,
				5,
				125,
				6,
				126,
				6,
				127,
				6,
				128,
				6,
				129,
				6,
				130,
				6,
				131,
				6,
				139,
				6,
				140,
				6,
				407,
				6,
				420,
				6,
				425,
				6,
				427,
				6,
				426,
				6,
				509,
				6,
				516,
				6,
				542,
				6,
				543,
				6,
				544,
				6,
				545,
				6,
				402,
				7,
				417,
				7,
				419,
				7,
				418,
				7,
				574,
				7,
				575,
				7,
				519,
				7,
				521,
				7,
				522,
				7,
				546,
				7,
				558,
				7,
				559,
				7,
				560,
				7,
				551,
				7
			});

			// Token: 0x04003BF6 RID: 15350
			public static bool[] BelongsToInvasionOldOnesArmy = NPCID.Sets.Factory.CreateBoolSet(new int[]
			{
				552,
				553,
				554,
				561,
				562,
				563,
				555,
				556,
				557,
				558,
				559,
				560,
				576,
				577,
				568,
				569,
				566,
				567,
				570,
				571,
				572,
				573,
				548,
				549,
				564,
				565,
				574,
				575,
				551,
				578
			});

			// Token: 0x04003BF7 RID: 15351
			public static bool[] TeleportationImmune = NPCID.Sets.Factory.CreateBoolSet(new int[]
			{
				552,
				553,
				554,
				561,
				562,
				563,
				555,
				556,
				557,
				558,
				559,
				560,
				576,
				577,
				568,
				569,
				566,
				567,
				570,
				571,
				572,
				573,
				548,
				549,
				564,
				565,
				574,
				575,
				551,
				578
			});

			// Token: 0x04003BF8 RID: 15352
			public static bool[] UsesNewTargetting = NPCID.Sets.Factory.CreateBoolSet(new int[]
			{
				547,
				552,
				553,
				554,
				561,
				562,
				563,
				555,
				556,
				557,
				558,
				559,
				560,
				576,
				577,
				568,
				569,
				566,
				567,
				570,
				571,
				572,
				573,
				564,
				565,
				574,
				575,
				551,
				578
			});

			// Token: 0x04003BF9 RID: 15353
			public static bool[] FighterUsesDD2PortalAppearEffect = NPCID.Sets.Factory.CreateBoolSet(new int[]
			{
				552,
				553,
				554,
				561,
				562,
				563,
				555,
				556,
				557,
				576,
				577,
				568,
				569,
				570,
				571,
				572,
				573,
				564,
				565
			});

			// Token: 0x04003BFA RID: 15354
			public static float[] StatueSpawnedDropRarity = NPCID.Sets.Factory.CreateCustomSet<float>(-1f, new object[]
			{
				480,
				0.05f,
				82,
				0.05f,
				86,
				0.05f,
				48,
				0.05f,
				490,
				0.05f,
				489,
				0.05f,
				170,
				0.05f,
				180,
				0.05f,
				171,
				0.05f,
				167,
				0.25f
			});

			// Token: 0x04003BFB RID: 15355
			public static bool[] NoEarlymodeLootWhenSpawnedFromStatue = NPCID.Sets.Factory.CreateBoolSet(new int[]
			{
				480,
				82,
				86,
				170,
				180,
				171
			});

			// Token: 0x04003BFC RID: 15356
			public static bool[] NeedsExpertScaling = NPCID.Sets.Factory.CreateBoolSet(new int[]
			{
				25,
				30,
				33,
				112,
				261,
				265,
				371,
				516,
				519,
				522,
				397,
				396,
				398
			});

			// Token: 0x04003BFD RID: 15357
			public static bool[] ProjectileNPC = NPCID.Sets.Factory.CreateBoolSet(new int[]
			{
				25,
				30,
				33,
				112,
				261,
				265,
				371,
				516,
				519,
				522
			});

			// Token: 0x04003BFE RID: 15358
			public static bool[] SavesAndLoads = NPCID.Sets.Factory.CreateBoolSet(new int[]
			{
				422,
				507,
				517,
				493
			});

			// Token: 0x04003BFF RID: 15359
			public static int[] TrailCacheLength = NPCID.Sets.Factory.CreateIntSet(10, new int[]
			{
				402,
				36,
				519,
				20,
				522,
				20
			});

			// Token: 0x04003C00 RID: 15360
			public static bool[] MPAllowedEnemies = NPCID.Sets.Factory.CreateBoolSet(new int[]
			{
				4,
				13,
				50,
				126,
				125,
				134,
				127,
				128,
				131,
				129,
				130,
				222,
				245,
				266,
				370
			});

			// Token: 0x04003C01 RID: 15361
			public static bool[] TownCritter = NPCID.Sets.Factory.CreateBoolSet(new int[]
			{
				46,
				148,
				149,
				230,
				299,
				300,
				303,
				337,
				361,
				362,
				364,
				366,
				367,
				443,
				445,
				447,
				538,
				539,
				540
			});

			// Token: 0x04003C02 RID: 15362
			public static int[] HatOffsetY = NPCID.Sets.Factory.CreateIntSet(0, new int[]
			{
				227,
				4,
				107,
				2,
				108,
				2,
				229,
				4,
				17,
				2,
				38,
				8,
				160,
				-10,
				208,
				2,
				142,
				2,
				124,
				2,
				453,
				2,
				37,
				4,
				54,
				4,
				209,
				4,
				369,
				6,
				441,
				6,
				353,
				-2,
				550,
				-2
			});

			// Token: 0x04003C03 RID: 15363
			public static int[] FaceEmote = NPCID.Sets.Factory.CreateIntSet(0, new int[]
			{
				17,
				101,
				18,
				102,
				19,
				103,
				20,
				104,
				22,
				105,
				37,
				106,
				38,
				107,
				54,
				108,
				107,
				109,
				108,
				110,
				124,
				111,
				142,
				112,
				160,
				113,
				178,
				114,
				207,
				115,
				208,
				116,
				209,
				117,
				227,
				118,
				228,
				119,
				229,
				120,
				353,
				121,
				368,
				122,
				369,
				123,
				453,
				124,
				441,
				125
			});

			// Token: 0x04003C04 RID: 15364
			public static int[] ExtraFramesCount = NPCID.Sets.Factory.CreateIntSet(0, new int[]
			{
				17,
				9,
				18,
				9,
				19,
				9,
				20,
				7,
				22,
				10,
				37,
				5,
				38,
				9,
				54,
				7,
				107,
				9,
				108,
				7,
				124,
				9,
				142,
				9,
				160,
				7,
				178,
				9,
				207,
				9,
				208,
				9,
				209,
				10,
				227,
				9,
				228,
				10,
				229,
				10,
				353,
				9,
				368,
				10,
				369,
				9,
				453,
				9,
				441,
				9,
				550,
				9
			});

			// Token: 0x04003C05 RID: 15365
			public static int[] AttackFrameCount = NPCID.Sets.Factory.CreateIntSet(0, new int[]
			{
				17,
				4,
				18,
				4,
				19,
				4,
				20,
				2,
				22,
				5,
				37,
				0,
				38,
				4,
				54,
				2,
				107,
				4,
				108,
				2,
				124,
				4,
				142,
				4,
				160,
				2,
				178,
				4,
				207,
				4,
				208,
				4,
				209,
				5,
				227,
				4,
				228,
				5,
				229,
				5,
				353,
				4,
				368,
				5,
				369,
				4,
				453,
				4,
				441,
				4,
				550,
				4
			});

			// Token: 0x04003C06 RID: 15366
			public static int[] DangerDetectRange = NPCID.Sets.Factory.CreateIntSet(-1, new int[]
			{
				38,
				300,
				17,
				320,
				107,
				300,
				19,
				900,
				22,
				700,
				124,
				800,
				228,
				800,
				178,
				900,
				18,
				300,
				229,
				1000,
				209,
				1000,
				54,
				700,
				108,
				700,
				160,
				700,
				20,
				1200,
				369,
				300,
				453,
				300,
				368,
				900,
				207,
				60,
				227,
				800,
				208,
				400,
				142,
				500,
				441,
				50,
				353,
				60,
				550,
				120
			});

			// Token: 0x04003C07 RID: 15367
			public static int[] AttackTime = NPCID.Sets.Factory.CreateIntSet(-1, new int[]
			{
				38,
				34,
				17,
				34,
				107,
				60,
				19,
				40,
				22,
				30,
				124,
				34,
				228,
				40,
				178,
				24,
				18,
				34,
				229,
				60,
				209,
				60,
				54,
				60,
				108,
				30,
				160,
				60,
				20,
				600,
				369,
				34,
				453,
				34,
				368,
				60,
				207,
				15,
				227,
				60,
				208,
				34,
				142,
				34,
				441,
				15,
				353,
				12,
				550,
				34
			});

			// Token: 0x04003C08 RID: 15368
			public static int[] AttackAverageChance = NPCID.Sets.Factory.CreateIntSet(1, new int[]
			{
				38,
				40,
				17,
				30,
				107,
				60,
				19,
				30,
				22,
				30,
				124,
				30,
				228,
				50,
				178,
				50,
				18,
				60,
				229,
				40,
				209,
				30,
				54,
				30,
				108,
				30,
				160,
				60,
				20,
				60,
				369,
				50,
				453,
				30,
				368,
				40,
				207,
				1,
				227,
				30,
				208,
				50,
				142,
				50,
				441,
				1,
				353,
				1,
				550,
				40
			});

			// Token: 0x04003C09 RID: 15369
			public static int[] AttackType = NPCID.Sets.Factory.CreateIntSet(-1, new int[]
			{
				38,
				0,
				17,
				0,
				107,
				0,
				19,
				1,
				22,
				1,
				124,
				0,
				228,
				1,
				178,
				1,
				18,
				0,
				229,
				1,
				209,
				1,
				54,
				2,
				108,
				2,
				160,
				2,
				20,
				2,
				369,
				0,
				453,
				0,
				368,
				1,
				207,
				3,
				227,
				1,
				208,
				0,
				142,
				0,
				441,
				3,
				353,
				3,
				550,
				0
			});

			// Token: 0x04003C0A RID: 15370
			public static int[] PrettySafe = NPCID.Sets.Factory.CreateIntSet(-1, new int[]
			{
				19,
				300,
				22,
				200,
				124,
				200,
				228,
				300,
				178,
				300,
				229,
				300,
				209,
				300,
				54,
				100,
				108,
				100,
				160,
				100,
				20,
				200,
				368,
				200,
				227,
				200
			});

			// Token: 0x04003C0B RID: 15371
			public static Color[] MagicAuraColor = NPCID.Sets.Factory.CreateCustomSet<Color>(Color.White, new object[]
			{
				54,
				new Color(100, 4, 227, 127),
				108,
				new Color(255, 80, 60, 127),
				160,
				new Color(40, 80, 255, 127),
				20,
				new Color(40, 255, 80, 127)
			});

			// Token: 0x04003C0C RID: 15372
			public static List<int> Skeletons = new List<int>
			{
				77,
				-49,
				-51,
				-53,
				-47,
				449,
				450,
				451,
				452,
				481,
				201,
				-15,
				202,
				203,
				21,
				324,
				110,
				323,
				293,
				291,
				322,
				-48,
				-50,
				-52,
				-46,
				292,
				197,
				167,
				44
			};

			// Token: 0x04003C0D RID: 15373
			public static int[] BossHeadTextures = NPCID.Sets.Factory.CreateIntSet(-1, new int[]
			{
				4,
				0,
				13,
				2,
				344,
				3,
				370,
				4,
				246,
				5,
				249,
				5,
				345,
				6,
				50,
				7,
				396,
				8,
				395,
				9,
				325,
				10,
				262,
				11,
				327,
				13,
				222,
				14,
				125,
				15,
				126,
				16,
				346,
				17,
				127,
				18,
				35,
				19,
				68,
				19,
				113,
				22,
				266,
				23,
				439,
				24,
				440,
				24,
				134,
				25,
				491,
				26,
				517,
				27,
				422,
				28,
				507,
				29,
				493,
				30,
				549,
				35,
				564,
				32,
				565,
				32,
				576,
				33,
				577,
				33,
				551,
				34,
				548,
				36
			});

			// Token: 0x04003C0E RID: 15374
			public static bool[] ExcludedFromDeathTally = NPCID.Sets.Factory.CreateBoolSet(false, new int[]
			{
				121,
				384,
				406
			});

			// Token: 0x04003C0F RID: 15375
			public static bool[] TechnicallyABoss = NPCID.Sets.Factory.CreateBoolSet(new int[]
			{
				517,
				422,
				507,
				493,
				399
			});

			// Token: 0x04003C10 RID: 15376
			public static bool[] MustAlwaysDraw = NPCID.Sets.Factory.CreateBoolSet(new int[]
			{
				113,
				114,
				115,
				116,
				126,
				125
			});

			// Token: 0x04003C11 RID: 15377
			public static int[] ExtraTextureCount = NPCID.Sets.Factory.CreateIntSet(0, new int[]
			{
				38,
				1,
				17,
				1,
				107,
				0,
				19,
				0,
				22,
				0,
				124,
				1,
				228,
				0,
				178,
				1,
				18,
				1,
				229,
				1,
				209,
				1,
				54,
				1,
				108,
				1,
				160,
				0,
				20,
				0,
				369,
				1,
				453,
				1,
				368,
				1,
				207,
				1,
				227,
				1,
				208,
				0,
				142,
				1,
				441,
				1,
				353,
				1,
				550,
				0
			});

			// Token: 0x04003C12 RID: 15378
			public static int[] NPCFramingGroup = NPCID.Sets.Factory.CreateIntSet(0, new int[]
			{
				18,
				1,
				20,
				1,
				208,
				1,
				178,
				1,
				124,
				1,
				353,
				1,
				369,
				2,
				160,
				3
			});

			// Token: 0x04003C13 RID: 15379
			public static int[][] TownNPCsFramingGroups = new int[][]
			{
				new int[]
				{
					0,
					0,
					0,
					-2,
					-2,
					-2,
					0,
					0,
					0,
					0,
					-2,
					-2,
					-2,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0
				},
				new int[]
				{
					0,
					0,
					0,
					-2,
					-2,
					-2,
					0,
					0,
					0,
					-2,
					-2,
					-2,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0
				},
				new int[]
				{
					0,
					0,
					0,
					-2,
					-2,
					-2,
					0,
					0,
					-2,
					-2,
					-2,
					-2,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0
				},
				new int[]
				{
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					-2,
					-2,
					-2,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					2,
					6
				}
			};
		}
	}
}

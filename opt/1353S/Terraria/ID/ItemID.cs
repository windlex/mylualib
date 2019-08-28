using System;
using System.Collections.Generic;
using ReLogic.Reflection;

namespace Terraria.ID
{
	// Token: 0x020000D8 RID: 216
	public class ItemID
	{
		// Token: 0x06000D21 RID: 3361 RVA: 0x003DDF08 File Offset: 0x003DC108
		private static Dictionary<string, short> GenerateLegacyItemDictionary()
		{
			return new Dictionary<string, short>
			{
				{
					"Iron Pickaxe",
					1
				},
				{
					"Dirt Block",
					2
				},
				{
					"Stone Block",
					3
				},
				{
					"Iron Broadsword",
					4
				},
				{
					"Mushroom",
					5
				},
				{
					"Iron Shortsword",
					6
				},
				{
					"Iron Hammer",
					7
				},
				{
					"Torch",
					8
				},
				{
					"Wood",
					9
				},
				{
					"Iron Axe",
					10
				},
				{
					"Iron Ore",
					11
				},
				{
					"Copper Ore",
					12
				},
				{
					"Gold Ore",
					13
				},
				{
					"Silver Ore",
					14
				},
				{
					"Copper Watch",
					15
				},
				{
					"Silver Watch",
					16
				},
				{
					"Gold Watch",
					17
				},
				{
					"Depth Meter",
					18
				},
				{
					"Gold Bar",
					19
				},
				{
					"Copper Bar",
					20
				},
				{
					"Silver Bar",
					21
				},
				{
					"Iron Bar",
					22
				},
				{
					"Gel",
					23
				},
				{
					"Wooden Sword",
					24
				},
				{
					"Wooden Door",
					25
				},
				{
					"Stone Wall",
					26
				},
				{
					"Acorn",
					27
				},
				{
					"Lesser Healing Potion",
					28
				},
				{
					"Life Crystal",
					29
				},
				{
					"Dirt Wall",
					30
				},
				{
					"Bottle",
					31
				},
				{
					"Wooden Table",
					32
				},
				{
					"Furnace",
					33
				},
				{
					"Wooden Chair",
					34
				},
				{
					"Iron Anvil",
					35
				},
				{
					"Work Bench",
					36
				},
				{
					"Goggles",
					37
				},
				{
					"Lens",
					38
				},
				{
					"Wooden Bow",
					39
				},
				{
					"Wooden Arrow",
					40
				},
				{
					"Flaming Arrow",
					41
				},
				{
					"Shuriken",
					42
				},
				{
					"Suspicious Looking Eye",
					43
				},
				{
					"Demon Bow",
					44
				},
				{
					"War Axe of the Night",
					45
				},
				{
					"Light's Bane",
					46
				},
				{
					"Unholy Arrow",
					47
				},
				{
					"Chest",
					48
				},
				{
					"Band of Regeneration",
					49
				},
				{
					"Magic Mirror",
					50
				},
				{
					"Jester's Arrow",
					51
				},
				{
					"Angel Statue",
					52
				},
				{
					"Cloud in a Bottle",
					53
				},
				{
					"Hermes Boots",
					54
				},
				{
					"Enchanted Boomerang",
					55
				},
				{
					"Demonite Ore",
					56
				},
				{
					"Demonite Bar",
					57
				},
				{
					"Heart",
					58
				},
				{
					"Corrupt Seeds",
					59
				},
				{
					"Vile Mushroom",
					60
				},
				{
					"Ebonstone Block",
					61
				},
				{
					"Grass Seeds",
					62
				},
				{
					"Sunflower",
					63
				},
				{
					"Vilethorn",
					64
				},
				{
					"Starfury",
					65
				},
				{
					"Purification Powder",
					66
				},
				{
					"Vile Powder",
					67
				},
				{
					"Rotten Chunk",
					68
				},
				{
					"Worm Tooth",
					69
				},
				{
					"Worm Food",
					70
				},
				{
					"Copper Coin",
					71
				},
				{
					"Silver Coin",
					72
				},
				{
					"Gold Coin",
					73
				},
				{
					"Platinum Coin",
					74
				},
				{
					"Fallen Star",
					75
				},
				{
					"Copper Greaves",
					76
				},
				{
					"Iron Greaves",
					77
				},
				{
					"Silver Greaves",
					78
				},
				{
					"Gold Greaves",
					79
				},
				{
					"Copper Chainmail",
					80
				},
				{
					"Iron Chainmail",
					81
				},
				{
					"Silver Chainmail",
					82
				},
				{
					"Gold Chainmail",
					83
				},
				{
					"Grappling Hook",
					84
				},
				{
					"Chain",
					85
				},
				{
					"Shadow Scale",
					86
				},
				{
					"Piggy Bank",
					87
				},
				{
					"Mining Helmet",
					88
				},
				{
					"Copper Helmet",
					89
				},
				{
					"Iron Helmet",
					90
				},
				{
					"Silver Helmet",
					91
				},
				{
					"Gold Helmet",
					92
				},
				{
					"Wood Wall",
					93
				},
				{
					"Wood Platform",
					94
				},
				{
					"Flintlock Pistol",
					95
				},
				{
					"Musket",
					96
				},
				{
					"Musket Ball",
					97
				},
				{
					"Minishark",
					98
				},
				{
					"Iron Bow",
					99
				},
				{
					"Shadow Greaves",
					100
				},
				{
					"Shadow Scalemail",
					101
				},
				{
					"Shadow Helmet",
					102
				},
				{
					"Nightmare Pickaxe",
					103
				},
				{
					"The Breaker",
					104
				},
				{
					"Candle",
					105
				},
				{
					"Copper Chandelier",
					106
				},
				{
					"Silver Chandelier",
					107
				},
				{
					"Gold Chandelier",
					108
				},
				{
					"Mana Crystal",
					109
				},
				{
					"Lesser Mana Potion",
					110
				},
				{
					"Band of Starpower",
					111
				},
				{
					"Flower of Fire",
					112
				},
				{
					"Magic Missile",
					113
				},
				{
					"Dirt Rod",
					114
				},
				{
					"Shadow Orb",
					115
				},
				{
					"Meteorite",
					116
				},
				{
					"Meteorite Bar",
					117
				},
				{
					"Hook",
					118
				},
				{
					"Flamarang",
					119
				},
				{
					"Molten Fury",
					120
				},
				{
					"Fiery Greatsword",
					121
				},
				{
					"Molten Pickaxe",
					122
				},
				{
					"Meteor Helmet",
					123
				},
				{
					"Meteor Suit",
					124
				},
				{
					"Meteor Leggings",
					125
				},
				{
					"Bottled Water",
					126
				},
				{
					"Space Gun",
					127
				},
				{
					"Rocket Boots",
					128
				},
				{
					"Gray Brick",
					129
				},
				{
					"Gray Brick Wall",
					130
				},
				{
					"Red Brick",
					131
				},
				{
					"Red Brick Wall",
					132
				},
				{
					"Clay Block",
					133
				},
				{
					"Blue Brick",
					134
				},
				{
					"Blue Brick Wall",
					135
				},
				{
					"Chain Lantern",
					136
				},
				{
					"Green Brick",
					137
				},
				{
					"Green Brick Wall",
					138
				},
				{
					"Pink Brick",
					139
				},
				{
					"Pink Brick Wall",
					140
				},
				{
					"Gold Brick",
					141
				},
				{
					"Gold Brick Wall",
					142
				},
				{
					"Silver Brick",
					143
				},
				{
					"Silver Brick Wall",
					144
				},
				{
					"Copper Brick",
					145
				},
				{
					"Copper Brick Wall",
					146
				},
				{
					"Spike",
					147
				},
				{
					"Water Candle",
					148
				},
				{
					"Book",
					149
				},
				{
					"Cobweb",
					150
				},
				{
					"Necro Helmet",
					151
				},
				{
					"Necro Breastplate",
					152
				},
				{
					"Necro Greaves",
					153
				},
				{
					"Bone",
					154
				},
				{
					"Muramasa",
					155
				},
				{
					"Cobalt Shield",
					156
				},
				{
					"Aqua Scepter",
					157
				},
				{
					"Lucky Horseshoe",
					158
				},
				{
					"Shiny Red Balloon",
					159
				},
				{
					"Harpoon",
					160
				},
				{
					"Spiky Ball",
					161
				},
				{
					"Ball O' Hurt",
					162
				},
				{
					"Blue Moon",
					163
				},
				{
					"Handgun",
					164
				},
				{
					"Water Bolt",
					165
				},
				{
					"Bomb",
					166
				},
				{
					"Dynamite",
					167
				},
				{
					"Grenade",
					168
				},
				{
					"Sand Block",
					169
				},
				{
					"Glass",
					170
				},
				{
					"Sign",
					171
				},
				{
					"Ash Block",
					172
				},
				{
					"Obsidian",
					173
				},
				{
					"Hellstone",
					174
				},
				{
					"Hellstone Bar",
					175
				},
				{
					"Mud Block",
					176
				},
				{
					"Sapphire",
					177
				},
				{
					"Ruby",
					178
				},
				{
					"Emerald",
					179
				},
				{
					"Topaz",
					180
				},
				{
					"Amethyst",
					181
				},
				{
					"Diamond",
					182
				},
				{
					"Glowing Mushroom",
					183
				},
				{
					"Star",
					184
				},
				{
					"Ivy Whip",
					185
				},
				{
					"Breathing Reed",
					186
				},
				{
					"Flipper",
					187
				},
				{
					"Healing Potion",
					188
				},
				{
					"Mana Potion",
					189
				},
				{
					"Blade of Grass",
					190
				},
				{
					"Thorn Chakram",
					191
				},
				{
					"Obsidian Brick",
					192
				},
				{
					"Obsidian Skull",
					193
				},
				{
					"Mushroom Grass Seeds",
					194
				},
				{
					"Jungle Grass Seeds",
					195
				},
				{
					"Wooden Hammer",
					196
				},
				{
					"Star Cannon",
					197
				},
				{
					"Blue Phaseblade",
					198
				},
				{
					"Red Phaseblade",
					199
				},
				{
					"Green Phaseblade",
					200
				},
				{
					"Purple Phaseblade",
					201
				},
				{
					"White Phaseblade",
					202
				},
				{
					"Yellow Phaseblade",
					203
				},
				{
					"Meteor Hamaxe",
					204
				},
				{
					"Empty Bucket",
					205
				},
				{
					"Water Bucket",
					206
				},
				{
					"Lava Bucket",
					207
				},
				{
					"Jungle Rose",
					208
				},
				{
					"Stinger",
					209
				},
				{
					"Vine",
					210
				},
				{
					"Feral Claws",
					211
				},
				{
					"Anklet of the Wind",
					212
				},
				{
					"Staff of Regrowth",
					213
				},
				{
					"Hellstone Brick",
					214
				},
				{
					"Whoopie Cushion",
					215
				},
				{
					"Shackle",
					216
				},
				{
					"Molten Hamaxe",
					217
				},
				{
					"Flamelash",
					218
				},
				{
					"Phoenix Blaster",
					219
				},
				{
					"Sunfury",
					220
				},
				{
					"Hellforge",
					221
				},
				{
					"Clay Pot",
					222
				},
				{
					"Nature's Gift",
					223
				},
				{
					"Bed",
					224
				},
				{
					"Silk",
					225
				},
				{
					"Lesser Restoration Potion",
					226
				},
				{
					"Restoration Potion",
					227
				},
				{
					"Jungle Hat",
					228
				},
				{
					"Jungle Shirt",
					229
				},
				{
					"Jungle Pants",
					230
				},
				{
					"Molten Helmet",
					231
				},
				{
					"Molten Breastplate",
					232
				},
				{
					"Molten Greaves",
					233
				},
				{
					"Meteor Shot",
					234
				},
				{
					"Sticky Bomb",
					235
				},
				{
					"Black Lens",
					236
				},
				{
					"Sunglasses",
					237
				},
				{
					"Wizard Hat",
					238
				},
				{
					"Top Hat",
					239
				},
				{
					"Tuxedo Shirt",
					240
				},
				{
					"Tuxedo Pants",
					241
				},
				{
					"Summer Hat",
					242
				},
				{
					"Bunny Hood",
					243
				},
				{
					"Plumber's Hat",
					244
				},
				{
					"Plumber's Shirt",
					245
				},
				{
					"Plumber's Pants",
					246
				},
				{
					"Hero's Hat",
					247
				},
				{
					"Hero's Shirt",
					248
				},
				{
					"Hero's Pants",
					249
				},
				{
					"Fish Bowl",
					250
				},
				{
					"Archaeologist's Hat",
					251
				},
				{
					"Archaeologist's Jacket",
					252
				},
				{
					"Archaeologist's Pants",
					253
				},
				{
					"Black Thread",
					254
				},
				{
					"Green Thread",
					255
				},
				{
					"Ninja Hood",
					256
				},
				{
					"Ninja Shirt",
					257
				},
				{
					"Ninja Pants",
					258
				},
				{
					"Leather",
					259
				},
				{
					"Red Hat",
					260
				},
				{
					"Goldfish",
					261
				},
				{
					"Robe",
					262
				},
				{
					"Robot Hat",
					263
				},
				{
					"Gold Crown",
					264
				},
				{
					"Hellfire Arrow",
					265
				},
				{
					"Sandgun",
					266
				},
				{
					"Guide Voodoo Doll",
					267
				},
				{
					"Diving Helmet",
					268
				},
				{
					"Familiar Shirt",
					269
				},
				{
					"Familiar Pants",
					270
				},
				{
					"Familiar Wig",
					271
				},
				{
					"Demon Scythe",
					272
				},
				{
					"Night's Edge",
					273
				},
				{
					"Dark Lance",
					274
				},
				{
					"Coral",
					275
				},
				{
					"Cactus",
					276
				},
				{
					"Trident",
					277
				},
				{
					"Silver Bullet",
					278
				},
				{
					"Throwing Knife",
					279
				},
				{
					"Spear",
					280
				},
				{
					"Blowpipe",
					281
				},
				{
					"Glowstick",
					282
				},
				{
					"Seed",
					283
				},
				{
					"Wooden Boomerang",
					284
				},
				{
					"Aglet",
					285
				},
				{
					"Sticky Glowstick",
					286
				},
				{
					"Poisoned Knife",
					287
				},
				{
					"Obsidian Skin Potion",
					288
				},
				{
					"Regeneration Potion",
					289
				},
				{
					"Swiftness Potion",
					290
				},
				{
					"Gills Potion",
					291
				},
				{
					"Ironskin Potion",
					292
				},
				{
					"Mana Regeneration Potion",
					293
				},
				{
					"Magic Power Potion",
					294
				},
				{
					"Featherfall Potion",
					295
				},
				{
					"Spelunker Potion",
					296
				},
				{
					"Invisibility Potion",
					297
				},
				{
					"Shine Potion",
					298
				},
				{
					"Night Owl Potion",
					299
				},
				{
					"Battle Potion",
					300
				},
				{
					"Thorns Potion",
					301
				},
				{
					"Water Walking Potion",
					302
				},
				{
					"Archery Potion",
					303
				},
				{
					"Hunter Potion",
					304
				},
				{
					"Gravitation Potion",
					305
				},
				{
					"Gold Chest",
					306
				},
				{
					"Daybloom Seeds",
					307
				},
				{
					"Moonglow Seeds",
					308
				},
				{
					"Blinkroot Seeds",
					309
				},
				{
					"Deathweed Seeds",
					310
				},
				{
					"Waterleaf Seeds",
					311
				},
				{
					"Fireblossom Seeds",
					312
				},
				{
					"Daybloom",
					313
				},
				{
					"Moonglow",
					314
				},
				{
					"Blinkroot",
					315
				},
				{
					"Deathweed",
					316
				},
				{
					"Waterleaf",
					317
				},
				{
					"Fireblossom",
					318
				},
				{
					"Shark Fin",
					319
				},
				{
					"Feather",
					320
				},
				{
					"Tombstone",
					321
				},
				{
					"Mime Mask",
					322
				},
				{
					"Antlion Mandible",
					323
				},
				{
					"Illegal Gun Parts",
					324
				},
				{
					"The Doctor's Shirt",
					325
				},
				{
					"The Doctor's Pants",
					326
				},
				{
					"Golden Key",
					327
				},
				{
					"Shadow Chest",
					328
				},
				{
					"Shadow Key",
					329
				},
				{
					"Obsidian Brick Wall",
					330
				},
				{
					"Jungle Spores",
					331
				},
				{
					"Loom",
					332
				},
				{
					"Piano",
					333
				},
				{
					"Dresser",
					334
				},
				{
					"Bench",
					335
				},
				{
					"Bathtub",
					336
				},
				{
					"Red Banner",
					337
				},
				{
					"Green Banner",
					338
				},
				{
					"Blue Banner",
					339
				},
				{
					"Yellow Banner",
					340
				},
				{
					"Lamp Post",
					341
				},
				{
					"Tiki Torch",
					342
				},
				{
					"Barrel",
					343
				},
				{
					"Chinese Lantern",
					344
				},
				{
					"Cooking Pot",
					345
				},
				{
					"Safe",
					346
				},
				{
					"Skull Lantern",
					347
				},
				{
					"Trash Can",
					348
				},
				{
					"Candelabra",
					349
				},
				{
					"Pink Vase",
					350
				},
				{
					"Mug",
					351
				},
				{
					"Keg",
					352
				},
				{
					"Ale",
					353
				},
				{
					"Bookcase",
					354
				},
				{
					"Throne",
					355
				},
				{
					"Bowl",
					356
				},
				{
					"Bowl of Soup",
					357
				},
				{
					"Toilet",
					358
				},
				{
					"Grandfather Clock",
					359
				},
				{
					"Armor Statue",
					360
				},
				{
					"Goblin Battle Standard",
					361
				},
				{
					"Tattered Cloth",
					362
				},
				{
					"Sawmill",
					363
				},
				{
					"Cobalt Ore",
					364
				},
				{
					"Mythril Ore",
					365
				},
				{
					"Adamantite Ore",
					366
				},
				{
					"Pwnhammer",
					367
				},
				{
					"Excalibur",
					368
				},
				{
					"Hallowed Seeds",
					369
				},
				{
					"Ebonsand Block",
					370
				},
				{
					"Cobalt Hat",
					371
				},
				{
					"Cobalt Helmet",
					372
				},
				{
					"Cobalt Mask",
					373
				},
				{
					"Cobalt Breastplate",
					374
				},
				{
					"Cobalt Leggings",
					375
				},
				{
					"Mythril Hood",
					376
				},
				{
					"Mythril Helmet",
					377
				},
				{
					"Mythril Hat",
					378
				},
				{
					"Mythril Chainmail",
					379
				},
				{
					"Mythril Greaves",
					380
				},
				{
					"Cobalt Bar",
					381
				},
				{
					"Mythril Bar",
					382
				},
				{
					"Cobalt Chainsaw",
					383
				},
				{
					"Mythril Chainsaw",
					384
				},
				{
					"Cobalt Drill",
					385
				},
				{
					"Mythril Drill",
					386
				},
				{
					"Adamantite Chainsaw",
					387
				},
				{
					"Adamantite Drill",
					388
				},
				{
					"Dao of Pow",
					389
				},
				{
					"Mythril Halberd",
					390
				},
				{
					"Adamantite Bar",
					391
				},
				{
					"Glass Wall",
					392
				},
				{
					"Compass",
					393
				},
				{
					"Diving Gear",
					394
				},
				{
					"GPS",
					395
				},
				{
					"Obsidian Horseshoe",
					396
				},
				{
					"Obsidian Shield",
					397
				},
				{
					"Tinkerer's Workshop",
					398
				},
				{
					"Cloud in a Balloon",
					399
				},
				{
					"Adamantite Headgear",
					400
				},
				{
					"Adamantite Helmet",
					401
				},
				{
					"Adamantite Mask",
					402
				},
				{
					"Adamantite Breastplate",
					403
				},
				{
					"Adamantite Leggings",
					404
				},
				{
					"Spectre Boots",
					405
				},
				{
					"Adamantite Glaive",
					406
				},
				{
					"Toolbelt",
					407
				},
				{
					"Pearlsand Block",
					408
				},
				{
					"Pearlstone Block",
					409
				},
				{
					"Mining Shirt",
					410
				},
				{
					"Mining Pants",
					411
				},
				{
					"Pearlstone Brick",
					412
				},
				{
					"Iridescent Brick",
					413
				},
				{
					"Mudstone Brick",
					414
				},
				{
					"Cobalt Brick",
					415
				},
				{
					"Mythril Brick",
					416
				},
				{
					"Pearlstone Brick Wall",
					417
				},
				{
					"Iridescent Brick Wall",
					418
				},
				{
					"Mudstone Brick Wall",
					419
				},
				{
					"Cobalt Brick Wall",
					420
				},
				{
					"Mythril Brick Wall",
					421
				},
				{
					"Holy Water",
					422
				},
				{
					"Unholy Water",
					423
				},
				{
					"Silt Block",
					424
				},
				{
					"Fairy Bell",
					425
				},
				{
					"Breaker Blade",
					426
				},
				{
					"Blue Torch",
					427
				},
				{
					"Red Torch",
					428
				},
				{
					"Green Torch",
					429
				},
				{
					"Purple Torch",
					430
				},
				{
					"White Torch",
					431
				},
				{
					"Yellow Torch",
					432
				},
				{
					"Demon Torch",
					433
				},
				{
					"Clockwork Assault Rifle",
					434
				},
				{
					"Cobalt Repeater",
					435
				},
				{
					"Mythril Repeater",
					436
				},
				{
					"Dual Hook",
					437
				},
				{
					"Star Statue",
					438
				},
				{
					"Sword Statue",
					439
				},
				{
					"Slime Statue",
					440
				},
				{
					"Goblin Statue",
					441
				},
				{
					"Shield Statue",
					442
				},
				{
					"Bat Statue",
					443
				},
				{
					"Fish Statue",
					444
				},
				{
					"Bunny Statue",
					445
				},
				{
					"Skeleton Statue",
					446
				},
				{
					"Reaper Statue",
					447
				},
				{
					"Woman Statue",
					448
				},
				{
					"Imp Statue",
					449
				},
				{
					"Gargoyle Statue",
					450
				},
				{
					"Gloom Statue",
					451
				},
				{
					"Hornet Statue",
					452
				},
				{
					"Bomb Statue",
					453
				},
				{
					"Crab Statue",
					454
				},
				{
					"Hammer Statue",
					455
				},
				{
					"Potion Statue",
					456
				},
				{
					"Spear Statue",
					457
				},
				{
					"Cross Statue",
					458
				},
				{
					"Jellyfish Statue",
					459
				},
				{
					"Bow Statue",
					460
				},
				{
					"Boomerang Statue",
					461
				},
				{
					"Boot Statue",
					462
				},
				{
					"Chest Statue",
					463
				},
				{
					"Bird Statue",
					464
				},
				{
					"Axe Statue",
					465
				},
				{
					"Corrupt Statue",
					466
				},
				{
					"Tree Statue",
					467
				},
				{
					"Anvil Statue",
					468
				},
				{
					"Pickaxe Statue",
					469
				},
				{
					"Mushroom Statue",
					470
				},
				{
					"Eyeball Statue",
					471
				},
				{
					"Pillar Statue",
					472
				},
				{
					"Heart Statue",
					473
				},
				{
					"Pot Statue",
					474
				},
				{
					"Sunflower Statue",
					475
				},
				{
					"King Statue",
					476
				},
				{
					"Queen Statue",
					477
				},
				{
					"Piranha Statue",
					478
				},
				{
					"Planked Wall",
					479
				},
				{
					"Wooden Beam",
					480
				},
				{
					"Adamantite Repeater",
					481
				},
				{
					"Adamantite Sword",
					482
				},
				{
					"Cobalt Sword",
					483
				},
				{
					"Mythril Sword",
					484
				},
				{
					"Moon Charm",
					485
				},
				{
					"Ruler",
					486
				},
				{
					"Crystal Ball",
					487
				},
				{
					"Disco Ball",
					488
				},
				{
					"Sorcerer Emblem",
					489
				},
				{
					"Warrior Emblem",
					490
				},
				{
					"Ranger Emblem",
					491
				},
				{
					"Demon Wings",
					492
				},
				{
					"Angel Wings",
					493
				},
				{
					"Magical Harp",
					494
				},
				{
					"Rainbow Rod",
					495
				},
				{
					"Ice Rod",
					496
				},
				{
					"Neptune's Shell",
					497
				},
				{
					"Mannequin",
					498
				},
				{
					"Greater Healing Potion",
					499
				},
				{
					"Greater Mana Potion",
					500
				},
				{
					"Pixie Dust",
					501
				},
				{
					"Crystal Shard",
					502
				},
				{
					"Clown Hat",
					503
				},
				{
					"Clown Shirt",
					504
				},
				{
					"Clown Pants",
					505
				},
				{
					"Flamethrower",
					506
				},
				{
					"Bell",
					507
				},
				{
					"Harp",
					508
				},
				{
					"Red Wrench",
					509
				},
				{
					"Wire Cutter",
					510
				},
				{
					"Active Stone Block",
					511
				},
				{
					"Inactive Stone Block",
					512
				},
				{
					"Lever",
					513
				},
				{
					"Laser Rifle",
					514
				},
				{
					"Crystal Bullet",
					515
				},
				{
					"Holy Arrow",
					516
				},
				{
					"Magic Dagger",
					517
				},
				{
					"Crystal Storm",
					518
				},
				{
					"Cursed Flames",
					519
				},
				{
					"Soul of Light",
					520
				},
				{
					"Soul of Night",
					521
				},
				{
					"Cursed Flame",
					522
				},
				{
					"Cursed Torch",
					523
				},
				{
					"Adamantite Forge",
					524
				},
				{
					"Mythril Anvil",
					525
				},
				{
					"Unicorn Horn",
					526
				},
				{
					"Dark Shard",
					527
				},
				{
					"Light Shard",
					528
				},
				{
					"Red Pressure Plate",
					529
				},
				{
					"Wire",
					530
				},
				{
					"Spell Tome",
					531
				},
				{
					"Star Cloak",
					532
				},
				{
					"Megashark",
					533
				},
				{
					"Shotgun",
					534
				},
				{
					"Philosopher's Stone",
					535
				},
				{
					"Titan Glove",
					536
				},
				{
					"Cobalt Naginata",
					537
				},
				{
					"Switch",
					538
				},
				{
					"Dart Trap",
					539
				},
				{
					"Boulder",
					540
				},
				{
					"Green Pressure Plate",
					541
				},
				{
					"Gray Pressure Plate",
					542
				},
				{
					"Brown Pressure Plate",
					543
				},
				{
					"Mechanical Eye",
					544
				},
				{
					"Cursed Arrow",
					545
				},
				{
					"Cursed Bullet",
					546
				},
				{
					"Soul of Fright",
					547
				},
				{
					"Soul of Might",
					548
				},
				{
					"Soul of Sight",
					549
				},
				{
					"Gungnir",
					550
				},
				{
					"Hallowed Plate Mail",
					551
				},
				{
					"Hallowed Greaves",
					552
				},
				{
					"Hallowed Helmet",
					553
				},
				{
					"Cross Necklace",
					554
				},
				{
					"Mana Flower",
					555
				},
				{
					"Mechanical Worm",
					556
				},
				{
					"Mechanical Skull",
					557
				},
				{
					"Hallowed Headgear",
					558
				},
				{
					"Hallowed Mask",
					559
				},
				{
					"Slime Crown",
					560
				},
				{
					"Light Disc",
					561
				},
				{
					"Music Box (Overworld Day)",
					562
				},
				{
					"Music Box (Eerie)",
					563
				},
				{
					"Music Box (Night)",
					564
				},
				{
					"Music Box (Title)",
					565
				},
				{
					"Music Box (Underground)",
					566
				},
				{
					"Music Box (Boss 1)",
					567
				},
				{
					"Music Box (Jungle)",
					568
				},
				{
					"Music Box (Corruption)",
					569
				},
				{
					"Music Box (Underground Corruption)",
					570
				},
				{
					"Music Box (The Hallow)",
					571
				},
				{
					"Music Box (Boss 2)",
					572
				},
				{
					"Music Box (Underground Hallow)",
					573
				},
				{
					"Music Box (Boss 3)",
					574
				},
				{
					"Soul of Flight",
					575
				},
				{
					"Music Box",
					576
				},
				{
					"Demonite Brick",
					577
				},
				{
					"Hallowed Repeater",
					578
				},
				{
					"Drax",
					579
				},
				{
					"Explosives",
					580
				},
				{
					"Inlet Pump",
					581
				},
				{
					"Outlet Pump",
					582
				},
				{
					"1 Second Timer",
					583
				},
				{
					"3 Second Timer",
					584
				},
				{
					"5 Second Timer",
					585
				},
				{
					"Candy Cane Block",
					586
				},
				{
					"Candy Cane Wall",
					587
				},
				{
					"Santa Hat",
					588
				},
				{
					"Santa Shirt",
					589
				},
				{
					"Santa Pants",
					590
				},
				{
					"Green Candy Cane Block",
					591
				},
				{
					"Green Candy Cane Wall",
					592
				},
				{
					"Snow Block",
					593
				},
				{
					"Snow Brick",
					594
				},
				{
					"Snow Brick Wall",
					595
				},
				{
					"Blue Light",
					596
				},
				{
					"Red Light",
					597
				},
				{
					"Green Light",
					598
				},
				{
					"Blue Present",
					599
				},
				{
					"Green Present",
					600
				},
				{
					"Yellow Present",
					601
				},
				{
					"Snow Globe",
					602
				},
				{
					"Carrot",
					603
				},
				{
					"Yellow Phasesaber",
					3769
				},
				{
					"White Phasesaber",
					3768
				},
				{
					"Purple Phasesaber",
					3767
				},
				{
					"Green Phasesaber",
					3766
				},
				{
					"Red Phasesaber",
					3765
				},
				{
					"Blue Phasesaber",
					3764
				},
				{
					"Platinum Bow",
					3480
				},
				{
					"Platinum Hammer",
					3481
				},
				{
					"Platinum Axe",
					3482
				},
				{
					"Platinum Shortsword",
					3483
				},
				{
					"Platinum Broadsword",
					3484
				},
				{
					"Platinum Pickaxe",
					3485
				},
				{
					"Tungsten Bow",
					3486
				},
				{
					"Tungsten Hammer",
					3487
				},
				{
					"Tungsten Axe",
					3488
				},
				{
					"Tungsten Shortsword",
					3489
				},
				{
					"Tungsten Broadsword",
					3490
				},
				{
					"Tungsten Pickaxe",
					3491
				},
				{
					"Lead Bow",
					3492
				},
				{
					"Lead Hammer",
					3493
				},
				{
					"Lead Axe",
					3494
				},
				{
					"Lead Shortsword",
					3495
				},
				{
					"Lead Broadsword",
					3496
				},
				{
					"Lead Pickaxe",
					3497
				},
				{
					"Tin Bow",
					3498
				},
				{
					"Tin Hammer",
					3499
				},
				{
					"Tin Axe",
					3500
				},
				{
					"Tin Shortsword",
					3501
				},
				{
					"Tin Broadsword",
					3502
				},
				{
					"Tin Pickaxe",
					3503
				},
				{
					"Copper Bow",
					3504
				},
				{
					"Copper Hammer",
					3505
				},
				{
					"Copper Axe",
					3506
				},
				{
					"Copper Shortsword",
					3507
				},
				{
					"Copper Broadsword",
					3508
				},
				{
					"Copper Pickaxe",
					3509
				},
				{
					"Silver Bow",
					3510
				},
				{
					"Silver Hammer",
					3511
				},
				{
					"Silver Axe",
					3512
				},
				{
					"Silver Shortsword",
					3513
				},
				{
					"Silver Broadsword",
					3514
				},
				{
					"Silver Pickaxe",
					3515
				},
				{
					"Gold Bow",
					3516
				},
				{
					"Gold Hammer",
					3517
				},
				{
					"Gold Axe",
					3518
				},
				{
					"Gold Shortsword",
					3519
				},
				{
					"Gold Broadsword",
					3520
				},
				{
					"Gold Pickaxe",
					3521
				}
			};
		}

		// Token: 0x06000D22 RID: 3362 RVA: 0x003E0648 File Offset: 0x003DE848
		public static short FromNetId(short id)
		{
			switch (id)
			{
			case -48:
				return 3480;
			case -47:
				return 3481;
			case -46:
				return 3482;
			case -45:
				return 3483;
			case -44:
				return 3484;
			case -43:
				return 3485;
			case -42:
				return 3486;
			case -41:
				return 3487;
			case -40:
				return 3488;
			case -39:
				return 3489;
			case -38:
				return 3490;
			case -37:
				return 3491;
			case -36:
				return 3492;
			case -35:
				return 3493;
			case -34:
				return 3494;
			case -33:
				return 3495;
			case -32:
				return 3496;
			case -31:
				return 3497;
			case -30:
				return 3498;
			case -29:
				return 3499;
			case -28:
				return 3500;
			case -27:
				return 3501;
			case -26:
				return 3502;
			case -25:
				return 3503;
			case -24:
				return 3769;
			case -23:
				return 3768;
			case -22:
				return 3767;
			case -21:
				return 3766;
			case -20:
				return 3765;
			case -19:
				return 3764;
			case -18:
				return 3504;
			case -17:
				return 3505;
			case -16:
				return 3506;
			case -15:
				return 3507;
			case -14:
				return 3508;
			case -13:
				return 3509;
			case -12:
				return 3510;
			case -11:
				return 3511;
			case -10:
				return 3512;
			case -9:
				return 3513;
			case -8:
				return 3514;
			case -7:
				return 3515;
			case -6:
				return 3516;
			case -5:
				return 3517;
			case -4:
				return 3518;
			case -3:
				return 3519;
			case -2:
				return 3520;
			case -1:
				return 3521;
			default:
				return id;
			}
		}

		// Token: 0x06000D23 RID: 3363 RVA: 0x003E0844 File Offset: 0x003DEA44
		public static short FromLegacyName(string name, int release)
		{
			if (ItemID._legacyItemLookup == null)
			{
				ItemID._legacyItemLookup = ItemID.GenerateLegacyItemDictionary();
			}
			if (release <= 4)
			{
				if (name == "Cobalt Helmet")
				{
					name = "Jungle Hat";
				}
				else if (name == "Cobalt Breastplate")
				{
					name = "Jungle Shirt";
				}
				else if (name == "Cobalt Greaves")
				{
					name = "Jungle Pants";
				}
			}
			if (release <= 13 && name == "Jungle Rose")
			{
				name = "Jungle Spores";
			}
			if (release <= 20)
			{
				if (name == "Gills potion")
				{
					name = "Gills Potion";
				}
				else if (name == "Thorn Chakrum")
				{
					name = "Thorn Chakram";
				}
				else if (name == "Ball 'O Hurt")
				{
					name = "Ball O' Hurt";
				}
			}
			if (release <= 41 && name == "Iron Chain")
			{
				name = "Chain";
			}
			if (release <= 44 && name == "Orb of Light")
			{
				name = "Shadow Orb";
			}
			if (release <= 46)
			{
				if (name == "Black Dye")
				{
					name = "Black Thread";
				}
				if (name == "Green Dye")
				{
					name = "Green Thread";
				}
			}
			short result;
			if (ItemID._legacyItemLookup.TryGetValue(name, out result))
			{
				return result;
			}
			return 0;
		}

		// Token: 0x040016B6 RID: 5814
		private static Dictionary<string, short> _legacyItemLookup;

		// Token: 0x040016B7 RID: 5815
		public static readonly IdDictionary Search = IdDictionary.Create<ItemID, short>();

		// Token: 0x040016B8 RID: 5816
		public const short YellowPhasesaberOld = -24;

		// Token: 0x040016B9 RID: 5817
		public const short WhitePhasesaberOld = -23;

		// Token: 0x040016BA RID: 5818
		public const short PurplePhasesaberOld = -22;

		// Token: 0x040016BB RID: 5819
		public const short GreenPhasesaberOld = -21;

		// Token: 0x040016BC RID: 5820
		public const short RedPhasesaberOld = -20;

		// Token: 0x040016BD RID: 5821
		public const short BluePhasesaberOld = -19;

		// Token: 0x040016BE RID: 5822
		public const short PlatinumBowOld = -48;

		// Token: 0x040016BF RID: 5823
		public const short PlatinumHammerOld = -47;

		// Token: 0x040016C0 RID: 5824
		public const short PlatinumAxeOld = -46;

		// Token: 0x040016C1 RID: 5825
		public const short PlatinumShortswordOld = -45;

		// Token: 0x040016C2 RID: 5826
		public const short PlatinumBroadswordOld = -44;

		// Token: 0x040016C3 RID: 5827
		public const short PlatinumPickaxeOld = -43;

		// Token: 0x040016C4 RID: 5828
		public const short TungstenBowOld = -42;

		// Token: 0x040016C5 RID: 5829
		public const short TungstenHammerOld = -41;

		// Token: 0x040016C6 RID: 5830
		public const short TungstenAxeOld = -40;

		// Token: 0x040016C7 RID: 5831
		public const short TungstenShortswordOld = -39;

		// Token: 0x040016C8 RID: 5832
		public const short TungstenBroadswordOld = -38;

		// Token: 0x040016C9 RID: 5833
		public const short TungstenPickaxeOld = -37;

		// Token: 0x040016CA RID: 5834
		public const short LeadBowOld = -36;

		// Token: 0x040016CB RID: 5835
		public const short LeadHammerOld = -35;

		// Token: 0x040016CC RID: 5836
		public const short LeadAxeOld = -34;

		// Token: 0x040016CD RID: 5837
		public const short LeadShortswordOld = -33;

		// Token: 0x040016CE RID: 5838
		public const short LeadBroadswordOld = -32;

		// Token: 0x040016CF RID: 5839
		public const short LeadPickaxeOld = -31;

		// Token: 0x040016D0 RID: 5840
		public const short TinBowOld = -30;

		// Token: 0x040016D1 RID: 5841
		public const short TinHammerOld = -29;

		// Token: 0x040016D2 RID: 5842
		public const short TinAxeOld = -28;

		// Token: 0x040016D3 RID: 5843
		public const short TinShortswordOld = -27;

		// Token: 0x040016D4 RID: 5844
		public const short TinBroadswordOld = -26;

		// Token: 0x040016D5 RID: 5845
		public const short TinPickaxeOld = -25;

		// Token: 0x040016D6 RID: 5846
		public const short CopperBowOld = -18;

		// Token: 0x040016D7 RID: 5847
		public const short CopperHammerOld = -17;

		// Token: 0x040016D8 RID: 5848
		public const short CopperAxeOld = -16;

		// Token: 0x040016D9 RID: 5849
		public const short CopperShortswordOld = -15;

		// Token: 0x040016DA RID: 5850
		public const short CopperBroadswordOld = -14;

		// Token: 0x040016DB RID: 5851
		public const short CopperPickaxeOld = -13;

		// Token: 0x040016DC RID: 5852
		public const short SilverBowOld = -12;

		// Token: 0x040016DD RID: 5853
		public const short SilverHammerOld = -11;

		// Token: 0x040016DE RID: 5854
		public const short SilverAxeOld = -10;

		// Token: 0x040016DF RID: 5855
		public const short SilverShortswordOld = -9;

		// Token: 0x040016E0 RID: 5856
		public const short SilverBroadswordOld = -8;

		// Token: 0x040016E1 RID: 5857
		public const short SilverPickaxeOld = -7;

		// Token: 0x040016E2 RID: 5858
		public const short GoldBowOld = -6;

		// Token: 0x040016E3 RID: 5859
		public const short GoldHammerOld = -5;

		// Token: 0x040016E4 RID: 5860
		public const short GoldAxeOld = -4;

		// Token: 0x040016E5 RID: 5861
		public const short GoldShortswordOld = -3;

		// Token: 0x040016E6 RID: 5862
		public const short GoldBroadswordOld = -2;

		// Token: 0x040016E7 RID: 5863
		public const short GoldPickaxeOld = -1;

		// Token: 0x040016E8 RID: 5864
		public const short None = 0;

		// Token: 0x040016E9 RID: 5865
		public const short IronPickaxe = 1;

		// Token: 0x040016EA RID: 5866
		public const short DirtBlock = 2;

		// Token: 0x040016EB RID: 5867
		public const short StoneBlock = 3;

		// Token: 0x040016EC RID: 5868
		public const short IronBroadsword = 4;

		// Token: 0x040016ED RID: 5869
		public const short Mushroom = 5;

		// Token: 0x040016EE RID: 5870
		public const short IronShortsword = 6;

		// Token: 0x040016EF RID: 5871
		public const short IronHammer = 7;

		// Token: 0x040016F0 RID: 5872
		public const short Torch = 8;

		// Token: 0x040016F1 RID: 5873
		public const short Wood = 9;

		// Token: 0x040016F2 RID: 5874
		public const short IronAxe = 10;

		// Token: 0x040016F3 RID: 5875
		public const short IronOre = 11;

		// Token: 0x040016F4 RID: 5876
		public const short CopperOre = 12;

		// Token: 0x040016F5 RID: 5877
		public const short GoldOre = 13;

		// Token: 0x040016F6 RID: 5878
		public const short SilverOre = 14;

		// Token: 0x040016F7 RID: 5879
		public const short CopperWatch = 15;

		// Token: 0x040016F8 RID: 5880
		public const short SilverWatch = 16;

		// Token: 0x040016F9 RID: 5881
		public const short GoldWatch = 17;

		// Token: 0x040016FA RID: 5882
		public const short DepthMeter = 18;

		// Token: 0x040016FB RID: 5883
		public const short GoldBar = 19;

		// Token: 0x040016FC RID: 5884
		public const short CopperBar = 20;

		// Token: 0x040016FD RID: 5885
		public const short SilverBar = 21;

		// Token: 0x040016FE RID: 5886
		public const short IronBar = 22;

		// Token: 0x040016FF RID: 5887
		public const short Gel = 23;

		// Token: 0x04001700 RID: 5888
		public const short WoodenSword = 24;

		// Token: 0x04001701 RID: 5889
		public const short WoodenDoor = 25;

		// Token: 0x04001702 RID: 5890
		public const short StoneWall = 26;

		// Token: 0x04001703 RID: 5891
		public const short Acorn = 27;

		// Token: 0x04001704 RID: 5892
		public const short LesserHealingPotion = 28;

		// Token: 0x04001705 RID: 5893
		public const short LifeCrystal = 29;

		// Token: 0x04001706 RID: 5894
		public const short DirtWall = 30;

		// Token: 0x04001707 RID: 5895
		public const short Bottle = 31;

		// Token: 0x04001708 RID: 5896
		public const short WoodenTable = 32;

		// Token: 0x04001709 RID: 5897
		public const short Furnace = 33;

		// Token: 0x0400170A RID: 5898
		public const short WoodenChair = 34;

		// Token: 0x0400170B RID: 5899
		public const short IronAnvil = 35;

		// Token: 0x0400170C RID: 5900
		public const short WorkBench = 36;

		// Token: 0x0400170D RID: 5901
		public const short Goggles = 37;

		// Token: 0x0400170E RID: 5902
		public const short Lens = 38;

		// Token: 0x0400170F RID: 5903
		public const short WoodenBow = 39;

		// Token: 0x04001710 RID: 5904
		public const short WoodenArrow = 40;

		// Token: 0x04001711 RID: 5905
		public const short FlamingArrow = 41;

		// Token: 0x04001712 RID: 5906
		public const short Shuriken = 42;

		// Token: 0x04001713 RID: 5907
		public const short SuspiciousLookingEye = 43;

		// Token: 0x04001714 RID: 5908
		public const short DemonBow = 44;

		// Token: 0x04001715 RID: 5909
		public const short WarAxeoftheNight = 45;

		// Token: 0x04001716 RID: 5910
		public const short LightsBane = 46;

		// Token: 0x04001717 RID: 5911
		public const short UnholyArrow = 47;

		// Token: 0x04001718 RID: 5912
		public const short Chest = 48;

		// Token: 0x04001719 RID: 5913
		public const short BandofRegeneration = 49;

		// Token: 0x0400171A RID: 5914
		public const short MagicMirror = 50;

		// Token: 0x0400171B RID: 5915
		public const short JestersArrow = 51;

		// Token: 0x0400171C RID: 5916
		public const short AngelStatue = 52;

		// Token: 0x0400171D RID: 5917
		public const short CloudinaBottle = 53;

		// Token: 0x0400171E RID: 5918
		public const short HermesBoots = 54;

		// Token: 0x0400171F RID: 5919
		public const short EnchantedBoomerang = 55;

		// Token: 0x04001720 RID: 5920
		public const short DemoniteOre = 56;

		// Token: 0x04001721 RID: 5921
		public const short DemoniteBar = 57;

		// Token: 0x04001722 RID: 5922
		public const short Heart = 58;

		// Token: 0x04001723 RID: 5923
		public const short CorruptSeeds = 59;

		// Token: 0x04001724 RID: 5924
		public const short VileMushroom = 60;

		// Token: 0x04001725 RID: 5925
		public const short EbonstoneBlock = 61;

		// Token: 0x04001726 RID: 5926
		public const short GrassSeeds = 62;

		// Token: 0x04001727 RID: 5927
		public const short Sunflower = 63;

		// Token: 0x04001728 RID: 5928
		public const short Vilethorn = 64;

		// Token: 0x04001729 RID: 5929
		public const short Starfury = 65;

		// Token: 0x0400172A RID: 5930
		public const short PurificationPowder = 66;

		// Token: 0x0400172B RID: 5931
		public const short VilePowder = 67;

		// Token: 0x0400172C RID: 5932
		public const short RottenChunk = 68;

		// Token: 0x0400172D RID: 5933
		public const short WormTooth = 69;

		// Token: 0x0400172E RID: 5934
		public const short WormFood = 70;

		// Token: 0x0400172F RID: 5935
		public const short CopperCoin = 71;

		// Token: 0x04001730 RID: 5936
		public const short SilverCoin = 72;

		// Token: 0x04001731 RID: 5937
		public const short GoldCoin = 73;

		// Token: 0x04001732 RID: 5938
		public const short PlatinumCoin = 74;

		// Token: 0x04001733 RID: 5939
		public const short FallenStar = 75;

		// Token: 0x04001734 RID: 5940
		public const short CopperGreaves = 76;

		// Token: 0x04001735 RID: 5941
		public const short IronGreaves = 77;

		// Token: 0x04001736 RID: 5942
		public const short SilverGreaves = 78;

		// Token: 0x04001737 RID: 5943
		public const short GoldGreaves = 79;

		// Token: 0x04001738 RID: 5944
		public const short CopperChainmail = 80;

		// Token: 0x04001739 RID: 5945
		public const short IronChainmail = 81;

		// Token: 0x0400173A RID: 5946
		public const short SilverChainmail = 82;

		// Token: 0x0400173B RID: 5947
		public const short GoldChainmail = 83;

		// Token: 0x0400173C RID: 5948
		public const short GrapplingHook = 84;

		// Token: 0x0400173D RID: 5949
		public const short Chain = 85;

		// Token: 0x0400173E RID: 5950
		public const short ShadowScale = 86;

		// Token: 0x0400173F RID: 5951
		public const short PiggyBank = 87;

		// Token: 0x04001740 RID: 5952
		public const short MiningHelmet = 88;

		// Token: 0x04001741 RID: 5953
		public const short CopperHelmet = 89;

		// Token: 0x04001742 RID: 5954
		public const short IronHelmet = 90;

		// Token: 0x04001743 RID: 5955
		public const short SilverHelmet = 91;

		// Token: 0x04001744 RID: 5956
		public const short GoldHelmet = 92;

		// Token: 0x04001745 RID: 5957
		public const short WoodWall = 93;

		// Token: 0x04001746 RID: 5958
		public const short WoodPlatform = 94;

		// Token: 0x04001747 RID: 5959
		public const short FlintlockPistol = 95;

		// Token: 0x04001748 RID: 5960
		public const short Musket = 96;

		// Token: 0x04001749 RID: 5961
		public const short MusketBall = 97;

		// Token: 0x0400174A RID: 5962
		public const short Minishark = 98;

		// Token: 0x0400174B RID: 5963
		public const short IronBow = 99;

		// Token: 0x0400174C RID: 5964
		public const short ShadowGreaves = 100;

		// Token: 0x0400174D RID: 5965
		public const short ShadowScalemail = 101;

		// Token: 0x0400174E RID: 5966
		public const short ShadowHelmet = 102;

		// Token: 0x0400174F RID: 5967
		public const short NightmarePickaxe = 103;

		// Token: 0x04001750 RID: 5968
		public const short TheBreaker = 104;

		// Token: 0x04001751 RID: 5969
		public const short Candle = 105;

		// Token: 0x04001752 RID: 5970
		public const short CopperChandelier = 106;

		// Token: 0x04001753 RID: 5971
		public const short SilverChandelier = 107;

		// Token: 0x04001754 RID: 5972
		public const short GoldChandelier = 108;

		// Token: 0x04001755 RID: 5973
		public const short ManaCrystal = 109;

		// Token: 0x04001756 RID: 5974
		public const short LesserManaPotion = 110;

		// Token: 0x04001757 RID: 5975
		public const short BandofStarpower = 111;

		// Token: 0x04001758 RID: 5976
		public const short FlowerofFire = 112;

		// Token: 0x04001759 RID: 5977
		public const short MagicMissile = 113;

		// Token: 0x0400175A RID: 5978
		public const short DirtRod = 114;

		// Token: 0x0400175B RID: 5979
		public const short ShadowOrb = 115;

		// Token: 0x0400175C RID: 5980
		public const short Meteorite = 116;

		// Token: 0x0400175D RID: 5981
		public const short MeteoriteBar = 117;

		// Token: 0x0400175E RID: 5982
		public const short Hook = 118;

		// Token: 0x0400175F RID: 5983
		public const short Flamarang = 119;

		// Token: 0x04001760 RID: 5984
		public const short MoltenFury = 120;

		// Token: 0x04001761 RID: 5985
		public const short FieryGreatsword = 121;

		// Token: 0x04001762 RID: 5986
		public const short MoltenPickaxe = 122;

		// Token: 0x04001763 RID: 5987
		public const short MeteorHelmet = 123;

		// Token: 0x04001764 RID: 5988
		public const short MeteorSuit = 124;

		// Token: 0x04001765 RID: 5989
		public const short MeteorLeggings = 125;

		// Token: 0x04001766 RID: 5990
		public const short BottledWater = 126;

		// Token: 0x04001767 RID: 5991
		public const short SpaceGun = 127;

		// Token: 0x04001768 RID: 5992
		public const short RocketBoots = 128;

		// Token: 0x04001769 RID: 5993
		public const short GrayBrick = 129;

		// Token: 0x0400176A RID: 5994
		public const short GrayBrickWall = 130;

		// Token: 0x0400176B RID: 5995
		public const short RedBrick = 131;

		// Token: 0x0400176C RID: 5996
		public const short RedBrickWall = 132;

		// Token: 0x0400176D RID: 5997
		public const short ClayBlock = 133;

		// Token: 0x0400176E RID: 5998
		public const short BlueBrick = 134;

		// Token: 0x0400176F RID: 5999
		public const short BlueBrickWall = 135;

		// Token: 0x04001770 RID: 6000
		public const short ChainLantern = 136;

		// Token: 0x04001771 RID: 6001
		public const short GreenBrick = 137;

		// Token: 0x04001772 RID: 6002
		public const short GreenBrickWall = 138;

		// Token: 0x04001773 RID: 6003
		public const short PinkBrick = 139;

		// Token: 0x04001774 RID: 6004
		public const short PinkBrickWall = 140;

		// Token: 0x04001775 RID: 6005
		public const short GoldBrick = 141;

		// Token: 0x04001776 RID: 6006
		public const short GoldBrickWall = 142;

		// Token: 0x04001777 RID: 6007
		public const short SilverBrick = 143;

		// Token: 0x04001778 RID: 6008
		public const short SilverBrickWall = 144;

		// Token: 0x04001779 RID: 6009
		public const short CopperBrick = 145;

		// Token: 0x0400177A RID: 6010
		public const short CopperBrickWall = 146;

		// Token: 0x0400177B RID: 6011
		public const short Spike = 147;

		// Token: 0x0400177C RID: 6012
		public const short WaterCandle = 148;

		// Token: 0x0400177D RID: 6013
		public const short Book = 149;

		// Token: 0x0400177E RID: 6014
		public const short Cobweb = 150;

		// Token: 0x0400177F RID: 6015
		public const short NecroHelmet = 151;

		// Token: 0x04001780 RID: 6016
		public const short NecroBreastplate = 152;

		// Token: 0x04001781 RID: 6017
		public const short NecroGreaves = 153;

		// Token: 0x04001782 RID: 6018
		public const short Bone = 154;

		// Token: 0x04001783 RID: 6019
		public const short Muramasa = 155;

		// Token: 0x04001784 RID: 6020
		public const short CobaltShield = 156;

		// Token: 0x04001785 RID: 6021
		public const short AquaScepter = 157;

		// Token: 0x04001786 RID: 6022
		public const short LuckyHorseshoe = 158;

		// Token: 0x04001787 RID: 6023
		public const short ShinyRedBalloon = 159;

		// Token: 0x04001788 RID: 6024
		public const short Harpoon = 160;

		// Token: 0x04001789 RID: 6025
		public const short SpikyBall = 161;

		// Token: 0x0400178A RID: 6026
		public const short BallOHurt = 162;

		// Token: 0x0400178B RID: 6027
		public const short BlueMoon = 163;

		// Token: 0x0400178C RID: 6028
		public const short Handgun = 164;

		// Token: 0x0400178D RID: 6029
		public const short WaterBolt = 165;

		// Token: 0x0400178E RID: 6030
		public const short Bomb = 166;

		// Token: 0x0400178F RID: 6031
		public const short Dynamite = 167;

		// Token: 0x04001790 RID: 6032
		public const short Grenade = 168;

		// Token: 0x04001791 RID: 6033
		public const short SandBlock = 169;

		// Token: 0x04001792 RID: 6034
		public const short Glass = 170;

		// Token: 0x04001793 RID: 6035
		public const short Sign = 171;

		// Token: 0x04001794 RID: 6036
		public const short AshBlock = 172;

		// Token: 0x04001795 RID: 6037
		public const short Obsidian = 173;

		// Token: 0x04001796 RID: 6038
		public const short Hellstone = 174;

		// Token: 0x04001797 RID: 6039
		public const short HellstoneBar = 175;

		// Token: 0x04001798 RID: 6040
		public const short MudBlock = 176;

		// Token: 0x04001799 RID: 6041
		public const short Sapphire = 177;

		// Token: 0x0400179A RID: 6042
		public const short Ruby = 178;

		// Token: 0x0400179B RID: 6043
		public const short Emerald = 179;

		// Token: 0x0400179C RID: 6044
		public const short Topaz = 180;

		// Token: 0x0400179D RID: 6045
		public const short Amethyst = 181;

		// Token: 0x0400179E RID: 6046
		public const short Diamond = 182;

		// Token: 0x0400179F RID: 6047
		public const short GlowingMushroom = 183;

		// Token: 0x040017A0 RID: 6048
		public const short Star = 184;

		// Token: 0x040017A1 RID: 6049
		public const short IvyWhip = 185;

		// Token: 0x040017A2 RID: 6050
		public const short BreathingReed = 186;

		// Token: 0x040017A3 RID: 6051
		public const short Flipper = 187;

		// Token: 0x040017A4 RID: 6052
		public const short HealingPotion = 188;

		// Token: 0x040017A5 RID: 6053
		public const short ManaPotion = 189;

		// Token: 0x040017A6 RID: 6054
		public const short BladeofGrass = 190;

		// Token: 0x040017A7 RID: 6055
		public const short ThornChakram = 191;

		// Token: 0x040017A8 RID: 6056
		public const short ObsidianBrick = 192;

		// Token: 0x040017A9 RID: 6057
		public const short ObsidianSkull = 193;

		// Token: 0x040017AA RID: 6058
		public const short MushroomGrassSeeds = 194;

		// Token: 0x040017AB RID: 6059
		public const short JungleGrassSeeds = 195;

		// Token: 0x040017AC RID: 6060
		public const short WoodenHammer = 196;

		// Token: 0x040017AD RID: 6061
		public const short StarCannon = 197;

		// Token: 0x040017AE RID: 6062
		public const short BluePhaseblade = 198;

		// Token: 0x040017AF RID: 6063
		public const short RedPhaseblade = 199;

		// Token: 0x040017B0 RID: 6064
		public const short GreenPhaseblade = 200;

		// Token: 0x040017B1 RID: 6065
		public const short PurplePhaseblade = 201;

		// Token: 0x040017B2 RID: 6066
		public const short WhitePhaseblade = 202;

		// Token: 0x040017B3 RID: 6067
		public const short YellowPhaseblade = 203;

		// Token: 0x040017B4 RID: 6068
		public const short MeteorHamaxe = 204;

		// Token: 0x040017B5 RID: 6069
		public const short EmptyBucket = 205;

		// Token: 0x040017B6 RID: 6070
		public const short WaterBucket = 206;

		// Token: 0x040017B7 RID: 6071
		public const short LavaBucket = 207;

		// Token: 0x040017B8 RID: 6072
		public const short JungleRose = 208;

		// Token: 0x040017B9 RID: 6073
		public const short Stinger = 209;

		// Token: 0x040017BA RID: 6074
		public const short Vine = 210;

		// Token: 0x040017BB RID: 6075
		public const short FeralClaws = 211;

		// Token: 0x040017BC RID: 6076
		public const short AnkletoftheWind = 212;

		// Token: 0x040017BD RID: 6077
		public const short StaffofRegrowth = 213;

		// Token: 0x040017BE RID: 6078
		public const short HellstoneBrick = 214;

		// Token: 0x040017BF RID: 6079
		public const short WhoopieCushion = 215;

		// Token: 0x040017C0 RID: 6080
		public const short Shackle = 216;

		// Token: 0x040017C1 RID: 6081
		public const short MoltenHamaxe = 217;

		// Token: 0x040017C2 RID: 6082
		public const short Flamelash = 218;

		// Token: 0x040017C3 RID: 6083
		public const short PhoenixBlaster = 219;

		// Token: 0x040017C4 RID: 6084
		public const short Sunfury = 220;

		// Token: 0x040017C5 RID: 6085
		public const short Hellforge = 221;

		// Token: 0x040017C6 RID: 6086
		public const short ClayPot = 222;

		// Token: 0x040017C7 RID: 6087
		public const short NaturesGift = 223;

		// Token: 0x040017C8 RID: 6088
		public const short Bed = 224;

		// Token: 0x040017C9 RID: 6089
		public const short Silk = 225;

		// Token: 0x040017CA RID: 6090
		public const short LesserRestorationPotion = 226;

		// Token: 0x040017CB RID: 6091
		public const short RestorationPotion = 227;

		// Token: 0x040017CC RID: 6092
		public const short JungleHat = 228;

		// Token: 0x040017CD RID: 6093
		public const short JungleShirt = 229;

		// Token: 0x040017CE RID: 6094
		public const short JunglePants = 230;

		// Token: 0x040017CF RID: 6095
		public const short MoltenHelmet = 231;

		// Token: 0x040017D0 RID: 6096
		public const short MoltenBreastplate = 232;

		// Token: 0x040017D1 RID: 6097
		public const short MoltenGreaves = 233;

		// Token: 0x040017D2 RID: 6098
		public const short MeteorShot = 234;

		// Token: 0x040017D3 RID: 6099
		public const short StickyBomb = 235;

		// Token: 0x040017D4 RID: 6100
		public const short BlackLens = 236;

		// Token: 0x040017D5 RID: 6101
		public const short Sunglasses = 237;

		// Token: 0x040017D6 RID: 6102
		public const short WizardHat = 238;

		// Token: 0x040017D7 RID: 6103
		public const short TopHat = 239;

		// Token: 0x040017D8 RID: 6104
		public const short TuxedoShirt = 240;

		// Token: 0x040017D9 RID: 6105
		public const short TuxedoPants = 241;

		// Token: 0x040017DA RID: 6106
		public const short SummerHat = 242;

		// Token: 0x040017DB RID: 6107
		public const short BunnyHood = 243;

		// Token: 0x040017DC RID: 6108
		public const short PlumbersHat = 244;

		// Token: 0x040017DD RID: 6109
		public const short PlumbersShirt = 245;

		// Token: 0x040017DE RID: 6110
		public const short PlumbersPants = 246;

		// Token: 0x040017DF RID: 6111
		public const short HerosHat = 247;

		// Token: 0x040017E0 RID: 6112
		public const short HerosShirt = 248;

		// Token: 0x040017E1 RID: 6113
		public const short HerosPants = 249;

		// Token: 0x040017E2 RID: 6114
		public const short FishBowl = 250;

		// Token: 0x040017E3 RID: 6115
		public const short ArchaeologistsHat = 251;

		// Token: 0x040017E4 RID: 6116
		public const short ArchaeologistsJacket = 252;

		// Token: 0x040017E5 RID: 6117
		public const short ArchaeologistsPants = 253;

		// Token: 0x040017E6 RID: 6118
		public const short BlackThread = 254;

		// Token: 0x040017E7 RID: 6119
		public const short GreenThread = 255;

		// Token: 0x040017E8 RID: 6120
		public const short NinjaHood = 256;

		// Token: 0x040017E9 RID: 6121
		public const short NinjaShirt = 257;

		// Token: 0x040017EA RID: 6122
		public const short NinjaPants = 258;

		// Token: 0x040017EB RID: 6123
		public const short Leather = 259;

		// Token: 0x040017EC RID: 6124
		public const short RedHat = 260;

		// Token: 0x040017ED RID: 6125
		public const short Goldfish = 261;

		// Token: 0x040017EE RID: 6126
		public const short Robe = 262;

		// Token: 0x040017EF RID: 6127
		public const short RobotHat = 263;

		// Token: 0x040017F0 RID: 6128
		public const short GoldCrown = 264;

		// Token: 0x040017F1 RID: 6129
		public const short HellfireArrow = 265;

		// Token: 0x040017F2 RID: 6130
		public const short Sandgun = 266;

		// Token: 0x040017F3 RID: 6131
		public const short GuideVoodooDoll = 267;

		// Token: 0x040017F4 RID: 6132
		public const short DivingHelmet = 268;

		// Token: 0x040017F5 RID: 6133
		public const short FamiliarShirt = 269;

		// Token: 0x040017F6 RID: 6134
		public const short FamiliarPants = 270;

		// Token: 0x040017F7 RID: 6135
		public const short FamiliarWig = 271;

		// Token: 0x040017F8 RID: 6136
		public const short DemonScythe = 272;

		// Token: 0x040017F9 RID: 6137
		public const short NightsEdge = 273;

		// Token: 0x040017FA RID: 6138
		public const short DarkLance = 274;

		// Token: 0x040017FB RID: 6139
		public const short Coral = 275;

		// Token: 0x040017FC RID: 6140
		public const short Cactus = 276;

		// Token: 0x040017FD RID: 6141
		public const short Trident = 277;

		// Token: 0x040017FE RID: 6142
		public const short SilverBullet = 278;

		// Token: 0x040017FF RID: 6143
		public const short ThrowingKnife = 279;

		// Token: 0x04001800 RID: 6144
		public const short Spear = 280;

		// Token: 0x04001801 RID: 6145
		public const short Blowpipe = 281;

		// Token: 0x04001802 RID: 6146
		public const short Glowstick = 282;

		// Token: 0x04001803 RID: 6147
		public const short Seed = 283;

		// Token: 0x04001804 RID: 6148
		public const short WoodenBoomerang = 284;

		// Token: 0x04001805 RID: 6149
		public const short Aglet = 285;

		// Token: 0x04001806 RID: 6150
		public const short StickyGlowstick = 286;

		// Token: 0x04001807 RID: 6151
		public const short PoisonedKnife = 287;

		// Token: 0x04001808 RID: 6152
		public const short ObsidianSkinPotion = 288;

		// Token: 0x04001809 RID: 6153
		public const short RegenerationPotion = 289;

		// Token: 0x0400180A RID: 6154
		public const short SwiftnessPotion = 290;

		// Token: 0x0400180B RID: 6155
		public const short GillsPotion = 291;

		// Token: 0x0400180C RID: 6156
		public const short IronskinPotion = 292;

		// Token: 0x0400180D RID: 6157
		public const short ManaRegenerationPotion = 293;

		// Token: 0x0400180E RID: 6158
		public const short MagicPowerPotion = 294;

		// Token: 0x0400180F RID: 6159
		public const short FeatherfallPotion = 295;

		// Token: 0x04001810 RID: 6160
		public const short SpelunkerPotion = 296;

		// Token: 0x04001811 RID: 6161
		public const short InvisibilityPotion = 297;

		// Token: 0x04001812 RID: 6162
		public const short ShinePotion = 298;

		// Token: 0x04001813 RID: 6163
		public const short NightOwlPotion = 299;

		// Token: 0x04001814 RID: 6164
		public const short BattlePotion = 300;

		// Token: 0x04001815 RID: 6165
		public const short ThornsPotion = 301;

		// Token: 0x04001816 RID: 6166
		public const short WaterWalkingPotion = 302;

		// Token: 0x04001817 RID: 6167
		public const short ArcheryPotion = 303;

		// Token: 0x04001818 RID: 6168
		public const short HunterPotion = 304;

		// Token: 0x04001819 RID: 6169
		public const short GravitationPotion = 305;

		// Token: 0x0400181A RID: 6170
		public const short GoldChest = 306;

		// Token: 0x0400181B RID: 6171
		public const short DaybloomSeeds = 307;

		// Token: 0x0400181C RID: 6172
		public const short MoonglowSeeds = 308;

		// Token: 0x0400181D RID: 6173
		public const short BlinkrootSeeds = 309;

		// Token: 0x0400181E RID: 6174
		public const short DeathweedSeeds = 310;

		// Token: 0x0400181F RID: 6175
		public const short WaterleafSeeds = 311;

		// Token: 0x04001820 RID: 6176
		public const short FireblossomSeeds = 312;

		// Token: 0x04001821 RID: 6177
		public const short Daybloom = 313;

		// Token: 0x04001822 RID: 6178
		public const short Moonglow = 314;

		// Token: 0x04001823 RID: 6179
		public const short Blinkroot = 315;

		// Token: 0x04001824 RID: 6180
		public const short Deathweed = 316;

		// Token: 0x04001825 RID: 6181
		public const short Waterleaf = 317;

		// Token: 0x04001826 RID: 6182
		public const short Fireblossom = 318;

		// Token: 0x04001827 RID: 6183
		public const short SharkFin = 319;

		// Token: 0x04001828 RID: 6184
		public const short Feather = 320;

		// Token: 0x04001829 RID: 6185
		public const short Tombstone = 321;

		// Token: 0x0400182A RID: 6186
		public const short MimeMask = 322;

		// Token: 0x0400182B RID: 6187
		public const short AntlionMandible = 323;

		// Token: 0x0400182C RID: 6188
		public const short IllegalGunParts = 324;

		// Token: 0x0400182D RID: 6189
		public const short TheDoctorsShirt = 325;

		// Token: 0x0400182E RID: 6190
		public const short TheDoctorsPants = 326;

		// Token: 0x0400182F RID: 6191
		public const short GoldenKey = 327;

		// Token: 0x04001830 RID: 6192
		public const short ShadowChest = 328;

		// Token: 0x04001831 RID: 6193
		public const short ShadowKey = 329;

		// Token: 0x04001832 RID: 6194
		public const short ObsidianBrickWall = 330;

		// Token: 0x04001833 RID: 6195
		public const short JungleSpores = 331;

		// Token: 0x04001834 RID: 6196
		public const short Loom = 332;

		// Token: 0x04001835 RID: 6197
		public const short Piano = 333;

		// Token: 0x04001836 RID: 6198
		public const short Dresser = 334;

		// Token: 0x04001837 RID: 6199
		public const short Bench = 335;

		// Token: 0x04001838 RID: 6200
		public const short Bathtub = 336;

		// Token: 0x04001839 RID: 6201
		public const short RedBanner = 337;

		// Token: 0x0400183A RID: 6202
		public const short GreenBanner = 338;

		// Token: 0x0400183B RID: 6203
		public const short BlueBanner = 339;

		// Token: 0x0400183C RID: 6204
		public const short YellowBanner = 340;

		// Token: 0x0400183D RID: 6205
		public const short LampPost = 341;

		// Token: 0x0400183E RID: 6206
		public const short TikiTorch = 342;

		// Token: 0x0400183F RID: 6207
		public const short Barrel = 343;

		// Token: 0x04001840 RID: 6208
		public const short ChineseLantern = 344;

		// Token: 0x04001841 RID: 6209
		public const short CookingPot = 345;

		// Token: 0x04001842 RID: 6210
		public const short Safe = 346;

		// Token: 0x04001843 RID: 6211
		public const short SkullLantern = 347;

		// Token: 0x04001844 RID: 6212
		public const short TrashCan = 348;

		// Token: 0x04001845 RID: 6213
		public const short Candelabra = 349;

		// Token: 0x04001846 RID: 6214
		public const short PinkVase = 350;

		// Token: 0x04001847 RID: 6215
		public const short Mug = 351;

		// Token: 0x04001848 RID: 6216
		public const short Keg = 352;

		// Token: 0x04001849 RID: 6217
		public const short Ale = 353;

		// Token: 0x0400184A RID: 6218
		public const short Bookcase = 354;

		// Token: 0x0400184B RID: 6219
		public const short Throne = 355;

		// Token: 0x0400184C RID: 6220
		public const short Bowl = 356;

		// Token: 0x0400184D RID: 6221
		public const short BowlofSoup = 357;

		// Token: 0x0400184E RID: 6222
		public const short Toilet = 358;

		// Token: 0x0400184F RID: 6223
		public const short GrandfatherClock = 359;

		// Token: 0x04001850 RID: 6224
		public const short ArmorStatue = 360;

		// Token: 0x04001851 RID: 6225
		public const short GoblinBattleStandard = 361;

		// Token: 0x04001852 RID: 6226
		public const short TatteredCloth = 362;

		// Token: 0x04001853 RID: 6227
		public const short Sawmill = 363;

		// Token: 0x04001854 RID: 6228
		public const short CobaltOre = 364;

		// Token: 0x04001855 RID: 6229
		public const short MythrilOre = 365;

		// Token: 0x04001856 RID: 6230
		public const short AdamantiteOre = 366;

		// Token: 0x04001857 RID: 6231
		public const short Pwnhammer = 367;

		// Token: 0x04001858 RID: 6232
		public const short Excalibur = 368;

		// Token: 0x04001859 RID: 6233
		public const short HallowedSeeds = 369;

		// Token: 0x0400185A RID: 6234
		public const short EbonsandBlock = 370;

		// Token: 0x0400185B RID: 6235
		public const short CobaltHat = 371;

		// Token: 0x0400185C RID: 6236
		public const short CobaltHelmet = 372;

		// Token: 0x0400185D RID: 6237
		public const short CobaltMask = 373;

		// Token: 0x0400185E RID: 6238
		public const short CobaltBreastplate = 374;

		// Token: 0x0400185F RID: 6239
		public const short CobaltLeggings = 375;

		// Token: 0x04001860 RID: 6240
		public const short MythrilHood = 376;

		// Token: 0x04001861 RID: 6241
		public const short MythrilHelmet = 377;

		// Token: 0x04001862 RID: 6242
		public const short MythrilHat = 378;

		// Token: 0x04001863 RID: 6243
		public const short MythrilChainmail = 379;

		// Token: 0x04001864 RID: 6244
		public const short MythrilGreaves = 380;

		// Token: 0x04001865 RID: 6245
		public const short CobaltBar = 381;

		// Token: 0x04001866 RID: 6246
		public const short MythrilBar = 382;

		// Token: 0x04001867 RID: 6247
		public const short CobaltChainsaw = 383;

		// Token: 0x04001868 RID: 6248
		public const short MythrilChainsaw = 384;

		// Token: 0x04001869 RID: 6249
		public const short CobaltDrill = 385;

		// Token: 0x0400186A RID: 6250
		public const short MythrilDrill = 386;

		// Token: 0x0400186B RID: 6251
		public const short AdamantiteChainsaw = 387;

		// Token: 0x0400186C RID: 6252
		public const short AdamantiteDrill = 388;

		// Token: 0x0400186D RID: 6253
		public const short DaoofPow = 389;

		// Token: 0x0400186E RID: 6254
		public const short MythrilHalberd = 390;

		// Token: 0x0400186F RID: 6255
		public const short AdamantiteBar = 391;

		// Token: 0x04001870 RID: 6256
		public const short GlassWall = 392;

		// Token: 0x04001871 RID: 6257
		public const short Compass = 393;

		// Token: 0x04001872 RID: 6258
		public const short DivingGear = 394;

		// Token: 0x04001873 RID: 6259
		public const short GPS = 395;

		// Token: 0x04001874 RID: 6260
		public const short ObsidianHorseshoe = 396;

		// Token: 0x04001875 RID: 6261
		public const short ObsidianShield = 397;

		// Token: 0x04001876 RID: 6262
		public const short TinkerersWorkshop = 398;

		// Token: 0x04001877 RID: 6263
		public const short CloudinaBalloon = 399;

		// Token: 0x04001878 RID: 6264
		public const short AdamantiteHeadgear = 400;

		// Token: 0x04001879 RID: 6265
		public const short AdamantiteHelmet = 401;

		// Token: 0x0400187A RID: 6266
		public const short AdamantiteMask = 402;

		// Token: 0x0400187B RID: 6267
		public const short AdamantiteBreastplate = 403;

		// Token: 0x0400187C RID: 6268
		public const short AdamantiteLeggings = 404;

		// Token: 0x0400187D RID: 6269
		public const short SpectreBoots = 405;

		// Token: 0x0400187E RID: 6270
		public const short AdamantiteGlaive = 406;

		// Token: 0x0400187F RID: 6271
		public const short Toolbelt = 407;

		// Token: 0x04001880 RID: 6272
		public const short PearlsandBlock = 408;

		// Token: 0x04001881 RID: 6273
		public const short PearlstoneBlock = 409;

		// Token: 0x04001882 RID: 6274
		public const short MiningShirt = 410;

		// Token: 0x04001883 RID: 6275
		public const short MiningPants = 411;

		// Token: 0x04001884 RID: 6276
		public const short PearlstoneBrick = 412;

		// Token: 0x04001885 RID: 6277
		public const short IridescentBrick = 413;

		// Token: 0x04001886 RID: 6278
		public const short MudstoneBlock = 414;

		// Token: 0x04001887 RID: 6279
		public const short CobaltBrick = 415;

		// Token: 0x04001888 RID: 6280
		public const short MythrilBrick = 416;

		// Token: 0x04001889 RID: 6281
		public const short PearlstoneBrickWall = 417;

		// Token: 0x0400188A RID: 6282
		public const short IridescentBrickWall = 418;

		// Token: 0x0400188B RID: 6283
		public const short MudstoneBrickWall = 419;

		// Token: 0x0400188C RID: 6284
		public const short CobaltBrickWall = 420;

		// Token: 0x0400188D RID: 6285
		public const short MythrilBrickWall = 421;

		// Token: 0x0400188E RID: 6286
		public const short HolyWater = 422;

		// Token: 0x0400188F RID: 6287
		public const short UnholyWater = 423;

		// Token: 0x04001890 RID: 6288
		public const short SiltBlock = 424;

		// Token: 0x04001891 RID: 6289
		public const short FairyBell = 425;

		// Token: 0x04001892 RID: 6290
		public const short BreakerBlade = 426;

		// Token: 0x04001893 RID: 6291
		public const short BlueTorch = 427;

		// Token: 0x04001894 RID: 6292
		public const short RedTorch = 428;

		// Token: 0x04001895 RID: 6293
		public const short GreenTorch = 429;

		// Token: 0x04001896 RID: 6294
		public const short PurpleTorch = 430;

		// Token: 0x04001897 RID: 6295
		public const short WhiteTorch = 431;

		// Token: 0x04001898 RID: 6296
		public const short YellowTorch = 432;

		// Token: 0x04001899 RID: 6297
		public const short DemonTorch = 433;

		// Token: 0x0400189A RID: 6298
		public const short ClockworkAssaultRifle = 434;

		// Token: 0x0400189B RID: 6299
		public const short CobaltRepeater = 435;

		// Token: 0x0400189C RID: 6300
		public const short MythrilRepeater = 436;

		// Token: 0x0400189D RID: 6301
		public const short DualHook = 437;

		// Token: 0x0400189E RID: 6302
		public const short StarStatue = 438;

		// Token: 0x0400189F RID: 6303
		public const short SwordStatue = 439;

		// Token: 0x040018A0 RID: 6304
		public const short SlimeStatue = 440;

		// Token: 0x040018A1 RID: 6305
		public const short GoblinStatue = 441;

		// Token: 0x040018A2 RID: 6306
		public const short ShieldStatue = 442;

		// Token: 0x040018A3 RID: 6307
		public const short BatStatue = 443;

		// Token: 0x040018A4 RID: 6308
		public const short FishStatue = 444;

		// Token: 0x040018A5 RID: 6309
		public const short BunnyStatue = 445;

		// Token: 0x040018A6 RID: 6310
		public const short SkeletonStatue = 446;

		// Token: 0x040018A7 RID: 6311
		public const short ReaperStatue = 447;

		// Token: 0x040018A8 RID: 6312
		public const short WomanStatue = 448;

		// Token: 0x040018A9 RID: 6313
		public const short ImpStatue = 449;

		// Token: 0x040018AA RID: 6314
		public const short GargoyleStatue = 450;

		// Token: 0x040018AB RID: 6315
		public const short GloomStatue = 451;

		// Token: 0x040018AC RID: 6316
		public const short HornetStatue = 452;

		// Token: 0x040018AD RID: 6317
		public const short BombStatue = 453;

		// Token: 0x040018AE RID: 6318
		public const short CrabStatue = 454;

		// Token: 0x040018AF RID: 6319
		public const short HammerStatue = 455;

		// Token: 0x040018B0 RID: 6320
		public const short PotionStatue = 456;

		// Token: 0x040018B1 RID: 6321
		public const short SpearStatue = 457;

		// Token: 0x040018B2 RID: 6322
		public const short CrossStatue = 458;

		// Token: 0x040018B3 RID: 6323
		public const short JellyfishStatue = 459;

		// Token: 0x040018B4 RID: 6324
		public const short BowStatue = 460;

		// Token: 0x040018B5 RID: 6325
		public const short BoomerangStatue = 461;

		// Token: 0x040018B6 RID: 6326
		public const short BootStatue = 462;

		// Token: 0x040018B7 RID: 6327
		public const short ChestStatue = 463;

		// Token: 0x040018B8 RID: 6328
		public const short BirdStatue = 464;

		// Token: 0x040018B9 RID: 6329
		public const short AxeStatue = 465;

		// Token: 0x040018BA RID: 6330
		public const short CorruptStatue = 466;

		// Token: 0x040018BB RID: 6331
		public const short TreeStatue = 467;

		// Token: 0x040018BC RID: 6332
		public const short AnvilStatue = 468;

		// Token: 0x040018BD RID: 6333
		public const short PickaxeStatue = 469;

		// Token: 0x040018BE RID: 6334
		public const short MushroomStatue = 470;

		// Token: 0x040018BF RID: 6335
		public const short EyeballStatue = 471;

		// Token: 0x040018C0 RID: 6336
		public const short PillarStatue = 472;

		// Token: 0x040018C1 RID: 6337
		public const short HeartStatue = 473;

		// Token: 0x040018C2 RID: 6338
		public const short PotStatue = 474;

		// Token: 0x040018C3 RID: 6339
		public const short SunflowerStatue = 475;

		// Token: 0x040018C4 RID: 6340
		public const short KingStatue = 476;

		// Token: 0x040018C5 RID: 6341
		public const short QueenStatue = 477;

		// Token: 0x040018C6 RID: 6342
		public const short PiranhaStatue = 478;

		// Token: 0x040018C7 RID: 6343
		public const short PlankedWall = 479;

		// Token: 0x040018C8 RID: 6344
		public const short WoodenBeam = 480;

		// Token: 0x040018C9 RID: 6345
		public const short AdamantiteRepeater = 481;

		// Token: 0x040018CA RID: 6346
		public const short AdamantiteSword = 482;

		// Token: 0x040018CB RID: 6347
		public const short CobaltSword = 483;

		// Token: 0x040018CC RID: 6348
		public const short MythrilSword = 484;

		// Token: 0x040018CD RID: 6349
		public const short MoonCharm = 485;

		// Token: 0x040018CE RID: 6350
		public const short Ruler = 486;

		// Token: 0x040018CF RID: 6351
		public const short CrystalBall = 487;

		// Token: 0x040018D0 RID: 6352
		public const short DiscoBall = 488;

		// Token: 0x040018D1 RID: 6353
		public const short SorcererEmblem = 489;

		// Token: 0x040018D2 RID: 6354
		public const short WarriorEmblem = 490;

		// Token: 0x040018D3 RID: 6355
		public const short RangerEmblem = 491;

		// Token: 0x040018D4 RID: 6356
		public const short DemonWings = 492;

		// Token: 0x040018D5 RID: 6357
		public const short AngelWings = 493;

		// Token: 0x040018D6 RID: 6358
		public const short MagicalHarp = 494;

		// Token: 0x040018D7 RID: 6359
		public const short RainbowRod = 495;

		// Token: 0x040018D8 RID: 6360
		public const short IceRod = 496;

		// Token: 0x040018D9 RID: 6361
		public const short NeptunesShell = 497;

		// Token: 0x040018DA RID: 6362
		public const short Mannequin = 498;

		// Token: 0x040018DB RID: 6363
		public const short GreaterHealingPotion = 499;

		// Token: 0x040018DC RID: 6364
		public const short GreaterManaPotion = 500;

		// Token: 0x040018DD RID: 6365
		public const short PixieDust = 501;

		// Token: 0x040018DE RID: 6366
		public const short CrystalShard = 502;

		// Token: 0x040018DF RID: 6367
		public const short ClownHat = 503;

		// Token: 0x040018E0 RID: 6368
		public const short ClownShirt = 504;

		// Token: 0x040018E1 RID: 6369
		public const short ClownPants = 505;

		// Token: 0x040018E2 RID: 6370
		public const short Flamethrower = 506;

		// Token: 0x040018E3 RID: 6371
		public const short Bell = 507;

		// Token: 0x040018E4 RID: 6372
		public const short Harp = 508;

		// Token: 0x040018E5 RID: 6373
		public const short Wrench = 509;

		// Token: 0x040018E6 RID: 6374
		public const short WireCutter = 510;

		// Token: 0x040018E7 RID: 6375
		public const short ActiveStoneBlock = 511;

		// Token: 0x040018E8 RID: 6376
		public const short InactiveStoneBlock = 512;

		// Token: 0x040018E9 RID: 6377
		public const short Lever = 513;

		// Token: 0x040018EA RID: 6378
		public const short LaserRifle = 514;

		// Token: 0x040018EB RID: 6379
		public const short CrystalBullet = 515;

		// Token: 0x040018EC RID: 6380
		public const short HolyArrow = 516;

		// Token: 0x040018ED RID: 6381
		public const short MagicDagger = 517;

		// Token: 0x040018EE RID: 6382
		public const short CrystalStorm = 518;

		// Token: 0x040018EF RID: 6383
		public const short CursedFlames = 519;

		// Token: 0x040018F0 RID: 6384
		public const short SoulofLight = 520;

		// Token: 0x040018F1 RID: 6385
		public const short SoulofNight = 521;

		// Token: 0x040018F2 RID: 6386
		public const short CursedFlame = 522;

		// Token: 0x040018F3 RID: 6387
		public const short CursedTorch = 523;

		// Token: 0x040018F4 RID: 6388
		public const short AdamantiteForge = 524;

		// Token: 0x040018F5 RID: 6389
		public const short MythrilAnvil = 525;

		// Token: 0x040018F6 RID: 6390
		public const short UnicornHorn = 526;

		// Token: 0x040018F7 RID: 6391
		public const short DarkShard = 527;

		// Token: 0x040018F8 RID: 6392
		public const short LightShard = 528;

		// Token: 0x040018F9 RID: 6393
		public const short RedPressurePlate = 529;

		// Token: 0x040018FA RID: 6394
		public const short Wire = 530;

		// Token: 0x040018FB RID: 6395
		public const short SpellTome = 531;

		// Token: 0x040018FC RID: 6396
		public const short StarCloak = 532;

		// Token: 0x040018FD RID: 6397
		public const short Megashark = 533;

		// Token: 0x040018FE RID: 6398
		public const short Shotgun = 534;

		// Token: 0x040018FF RID: 6399
		public const short PhilosophersStone = 535;

		// Token: 0x04001900 RID: 6400
		public const short TitanGlove = 536;

		// Token: 0x04001901 RID: 6401
		public const short CobaltNaginata = 537;

		// Token: 0x04001902 RID: 6402
		public const short Switch = 538;

		// Token: 0x04001903 RID: 6403
		public const short DartTrap = 539;

		// Token: 0x04001904 RID: 6404
		public const short Boulder = 540;

		// Token: 0x04001905 RID: 6405
		public const short GreenPressurePlate = 541;

		// Token: 0x04001906 RID: 6406
		public const short GrayPressurePlate = 542;

		// Token: 0x04001907 RID: 6407
		public const short BrownPressurePlate = 543;

		// Token: 0x04001908 RID: 6408
		public const short MechanicalEye = 544;

		// Token: 0x04001909 RID: 6409
		public const short CursedArrow = 545;

		// Token: 0x0400190A RID: 6410
		public const short CursedBullet = 546;

		// Token: 0x0400190B RID: 6411
		public const short SoulofFright = 547;

		// Token: 0x0400190C RID: 6412
		public const short SoulofMight = 548;

		// Token: 0x0400190D RID: 6413
		public const short SoulofSight = 549;

		// Token: 0x0400190E RID: 6414
		public const short Gungnir = 550;

		// Token: 0x0400190F RID: 6415
		public const short HallowedPlateMail = 551;

		// Token: 0x04001910 RID: 6416
		public const short HallowedGreaves = 552;

		// Token: 0x04001911 RID: 6417
		public const short HallowedHelmet = 553;

		// Token: 0x04001912 RID: 6418
		public const short CrossNecklace = 554;

		// Token: 0x04001913 RID: 6419
		public const short ManaFlower = 555;

		// Token: 0x04001914 RID: 6420
		public const short MechanicalWorm = 556;

		// Token: 0x04001915 RID: 6421
		public const short MechanicalSkull = 557;

		// Token: 0x04001916 RID: 6422
		public const short HallowedHeadgear = 558;

		// Token: 0x04001917 RID: 6423
		public const short HallowedMask = 559;

		// Token: 0x04001918 RID: 6424
		public const short SlimeCrown = 560;

		// Token: 0x04001919 RID: 6425
		public const short LightDisc = 561;

		// Token: 0x0400191A RID: 6426
		public const short MusicBoxOverworldDay = 562;

		// Token: 0x0400191B RID: 6427
		public const short MusicBoxEerie = 563;

		// Token: 0x0400191C RID: 6428
		public const short MusicBoxNight = 564;

		// Token: 0x0400191D RID: 6429
		public const short MusicBoxTitle = 565;

		// Token: 0x0400191E RID: 6430
		public const short MusicBoxUnderground = 566;

		// Token: 0x0400191F RID: 6431
		public const short MusicBoxBoss1 = 567;

		// Token: 0x04001920 RID: 6432
		public const short MusicBoxJungle = 568;

		// Token: 0x04001921 RID: 6433
		public const short MusicBoxCorruption = 569;

		// Token: 0x04001922 RID: 6434
		public const short MusicBoxUndergroundCorruption = 570;

		// Token: 0x04001923 RID: 6435
		public const short MusicBoxTheHallow = 571;

		// Token: 0x04001924 RID: 6436
		public const short MusicBoxBoss2 = 572;

		// Token: 0x04001925 RID: 6437
		public const short MusicBoxUndergroundHallow = 573;

		// Token: 0x04001926 RID: 6438
		public const short MusicBoxBoss3 = 574;

		// Token: 0x04001927 RID: 6439
		public const short SoulofFlight = 575;

		// Token: 0x04001928 RID: 6440
		public const short MusicBox = 576;

		// Token: 0x04001929 RID: 6441
		public const short DemoniteBrick = 577;

		// Token: 0x0400192A RID: 6442
		public const short HallowedRepeater = 578;

		// Token: 0x0400192B RID: 6443
		public const short Drax = 579;

		// Token: 0x0400192C RID: 6444
		public const short Explosives = 580;

		// Token: 0x0400192D RID: 6445
		public const short InletPump = 581;

		// Token: 0x0400192E RID: 6446
		public const short OutletPump = 582;

		// Token: 0x0400192F RID: 6447
		public const short Timer1Second = 583;

		// Token: 0x04001930 RID: 6448
		public const short Timer3Second = 584;

		// Token: 0x04001931 RID: 6449
		public const short Timer5Second = 585;

		// Token: 0x04001932 RID: 6450
		public const short CandyCaneBlock = 586;

		// Token: 0x04001933 RID: 6451
		public const short CandyCaneWall = 587;

		// Token: 0x04001934 RID: 6452
		public const short SantaHat = 588;

		// Token: 0x04001935 RID: 6453
		public const short SantaShirt = 589;

		// Token: 0x04001936 RID: 6454
		public const short SantaPants = 590;

		// Token: 0x04001937 RID: 6455
		public const short GreenCandyCaneBlock = 591;

		// Token: 0x04001938 RID: 6456
		public const short GreenCandyCaneWall = 592;

		// Token: 0x04001939 RID: 6457
		public const short SnowBlock = 593;

		// Token: 0x0400193A RID: 6458
		public const short SnowBrick = 594;

		// Token: 0x0400193B RID: 6459
		public const short SnowBrickWall = 595;

		// Token: 0x0400193C RID: 6460
		public const short BlueLight = 596;

		// Token: 0x0400193D RID: 6461
		public const short RedLight = 597;

		// Token: 0x0400193E RID: 6462
		public const short GreenLight = 598;

		// Token: 0x0400193F RID: 6463
		public const short BluePresent = 599;

		// Token: 0x04001940 RID: 6464
		public const short GreenPresent = 600;

		// Token: 0x04001941 RID: 6465
		public const short YellowPresent = 601;

		// Token: 0x04001942 RID: 6466
		public const short SnowGlobe = 602;

		// Token: 0x04001943 RID: 6467
		public const short Carrot = 603;

		// Token: 0x04001944 RID: 6468
		public const short AdamantiteBeam = 604;

		// Token: 0x04001945 RID: 6469
		public const short AdamantiteBeamWall = 605;

		// Token: 0x04001946 RID: 6470
		public const short DemoniteBrickWall = 606;

		// Token: 0x04001947 RID: 6471
		public const short SandstoneBrick = 607;

		// Token: 0x04001948 RID: 6472
		public const short SandstoneBrickWall = 608;

		// Token: 0x04001949 RID: 6473
		public const short EbonstoneBrick = 609;

		// Token: 0x0400194A RID: 6474
		public const short EbonstoneBrickWall = 610;

		// Token: 0x0400194B RID: 6475
		public const short RedStucco = 611;

		// Token: 0x0400194C RID: 6476
		public const short YellowStucco = 612;

		// Token: 0x0400194D RID: 6477
		public const short GreenStucco = 613;

		// Token: 0x0400194E RID: 6478
		public const short GrayStucco = 614;

		// Token: 0x0400194F RID: 6479
		public const short RedStuccoWall = 615;

		// Token: 0x04001950 RID: 6480
		public const short YellowStuccoWall = 616;

		// Token: 0x04001951 RID: 6481
		public const short GreenStuccoWall = 617;

		// Token: 0x04001952 RID: 6482
		public const short GrayStuccoWall = 618;

		// Token: 0x04001953 RID: 6483
		public const short Ebonwood = 619;

		// Token: 0x04001954 RID: 6484
		public const short RichMahogany = 620;

		// Token: 0x04001955 RID: 6485
		public const short Pearlwood = 621;

		// Token: 0x04001956 RID: 6486
		public const short EbonwoodWall = 622;

		// Token: 0x04001957 RID: 6487
		public const short RichMahoganyWall = 623;

		// Token: 0x04001958 RID: 6488
		public const short PearlwoodWall = 624;

		// Token: 0x04001959 RID: 6489
		public const short EbonwoodChest = 625;

		// Token: 0x0400195A RID: 6490
		public const short RichMahoganyChest = 626;

		// Token: 0x0400195B RID: 6491
		public const short PearlwoodChest = 627;

		// Token: 0x0400195C RID: 6492
		public const short EbonwoodChair = 628;

		// Token: 0x0400195D RID: 6493
		public const short RichMahoganyChair = 629;

		// Token: 0x0400195E RID: 6494
		public const short PearlwoodChair = 630;

		// Token: 0x0400195F RID: 6495
		public const short EbonwoodPlatform = 631;

		// Token: 0x04001960 RID: 6496
		public const short RichMahoganyPlatform = 632;

		// Token: 0x04001961 RID: 6497
		public const short PearlwoodPlatform = 633;

		// Token: 0x04001962 RID: 6498
		public const short BonePlatform = 634;

		// Token: 0x04001963 RID: 6499
		public const short EbonwoodWorkBench = 635;

		// Token: 0x04001964 RID: 6500
		public const short RichMahoganyWorkBench = 636;

		// Token: 0x04001965 RID: 6501
		public const short PearlwoodWorkBench = 637;

		// Token: 0x04001966 RID: 6502
		public const short EbonwoodTable = 638;

		// Token: 0x04001967 RID: 6503
		public const short RichMahoganyTable = 639;

		// Token: 0x04001968 RID: 6504
		public const short PearlwoodTable = 640;

		// Token: 0x04001969 RID: 6505
		public const short EbonwoodPiano = 641;

		// Token: 0x0400196A RID: 6506
		public const short RichMahoganyPiano = 642;

		// Token: 0x0400196B RID: 6507
		public const short PearlwoodPiano = 643;

		// Token: 0x0400196C RID: 6508
		public const short EbonwoodBed = 644;

		// Token: 0x0400196D RID: 6509
		public const short RichMahoganyBed = 645;

		// Token: 0x0400196E RID: 6510
		public const short PearlwoodBed = 646;

		// Token: 0x0400196F RID: 6511
		public const short EbonwoodDresser = 647;

		// Token: 0x04001970 RID: 6512
		public const short RichMahoganyDresser = 648;

		// Token: 0x04001971 RID: 6513
		public const short PearlwoodDresser = 649;

		// Token: 0x04001972 RID: 6514
		public const short EbonwoodDoor = 650;

		// Token: 0x04001973 RID: 6515
		public const short RichMahoganyDoor = 651;

		// Token: 0x04001974 RID: 6516
		public const short PearlwoodDoor = 652;

		// Token: 0x04001975 RID: 6517
		public const short EbonwoodSword = 653;

		// Token: 0x04001976 RID: 6518
		public const short EbonwoodHammer = 654;

		// Token: 0x04001977 RID: 6519
		public const short EbonwoodBow = 655;

		// Token: 0x04001978 RID: 6520
		public const short RichMahoganySword = 656;

		// Token: 0x04001979 RID: 6521
		public const short RichMahoganyHammer = 657;

		// Token: 0x0400197A RID: 6522
		public const short RichMahoganyBow = 658;

		// Token: 0x0400197B RID: 6523
		public const short PearlwoodSword = 659;

		// Token: 0x0400197C RID: 6524
		public const short PearlwoodHammer = 660;

		// Token: 0x0400197D RID: 6525
		public const short PearlwoodBow = 661;

		// Token: 0x0400197E RID: 6526
		public const short RainbowBrick = 662;

		// Token: 0x0400197F RID: 6527
		public const short RainbowBrickWall = 663;

		// Token: 0x04001980 RID: 6528
		public const short IceBlock = 664;

		// Token: 0x04001981 RID: 6529
		public const short RedsWings = 665;

		// Token: 0x04001982 RID: 6530
		public const short RedsHelmet = 666;

		// Token: 0x04001983 RID: 6531
		public const short RedsBreastplate = 667;

		// Token: 0x04001984 RID: 6532
		public const short RedsLeggings = 668;

		// Token: 0x04001985 RID: 6533
		public const short Fish = 669;

		// Token: 0x04001986 RID: 6534
		public const short IceBoomerang = 670;

		// Token: 0x04001987 RID: 6535
		public const short Keybrand = 671;

		// Token: 0x04001988 RID: 6536
		public const short Cutlass = 672;

		// Token: 0x04001989 RID: 6537
		public const short BorealWoodWorkBench = 673;

		// Token: 0x0400198A RID: 6538
		public const short TrueExcalibur = 674;

		// Token: 0x0400198B RID: 6539
		public const short TrueNightsEdge = 675;

		// Token: 0x0400198C RID: 6540
		public const short Frostbrand = 676;

		// Token: 0x0400198D RID: 6541
		public const short BorealWoodTable = 677;

		// Token: 0x0400198E RID: 6542
		public const short RedPotion = 678;

		// Token: 0x0400198F RID: 6543
		public const short TacticalShotgun = 679;

		// Token: 0x04001990 RID: 6544
		public const short IvyChest = 680;

		// Token: 0x04001991 RID: 6545
		public const short IceChest = 681;

		// Token: 0x04001992 RID: 6546
		public const short Marrow = 682;

		// Token: 0x04001993 RID: 6547
		public const short UnholyTrident = 683;

		// Token: 0x04001994 RID: 6548
		public const short FrostHelmet = 684;

		// Token: 0x04001995 RID: 6549
		public const short FrostBreastplate = 685;

		// Token: 0x04001996 RID: 6550
		public const short FrostLeggings = 686;

		// Token: 0x04001997 RID: 6551
		public const short TinHelmet = 687;

		// Token: 0x04001998 RID: 6552
		public const short TinChainmail = 688;

		// Token: 0x04001999 RID: 6553
		public const short TinGreaves = 689;

		// Token: 0x0400199A RID: 6554
		public const short LeadHelmet = 690;

		// Token: 0x0400199B RID: 6555
		public const short LeadChainmail = 691;

		// Token: 0x0400199C RID: 6556
		public const short LeadGreaves = 692;

		// Token: 0x0400199D RID: 6557
		public const short TungstenHelmet = 693;

		// Token: 0x0400199E RID: 6558
		public const short TungstenChainmail = 694;

		// Token: 0x0400199F RID: 6559
		public const short TungstenGreaves = 695;

		// Token: 0x040019A0 RID: 6560
		public const short PlatinumHelmet = 696;

		// Token: 0x040019A1 RID: 6561
		public const short PlatinumChainmail = 697;

		// Token: 0x040019A2 RID: 6562
		public const short PlatinumGreaves = 698;

		// Token: 0x040019A3 RID: 6563
		public const short TinOre = 699;

		// Token: 0x040019A4 RID: 6564
		public const short LeadOre = 700;

		// Token: 0x040019A5 RID: 6565
		public const short TungstenOre = 701;

		// Token: 0x040019A6 RID: 6566
		public const short PlatinumOre = 702;

		// Token: 0x040019A7 RID: 6567
		public const short TinBar = 703;

		// Token: 0x040019A8 RID: 6568
		public const short LeadBar = 704;

		// Token: 0x040019A9 RID: 6569
		public const short TungstenBar = 705;

		// Token: 0x040019AA RID: 6570
		public const short PlatinumBar = 706;

		// Token: 0x040019AB RID: 6571
		public const short TinWatch = 707;

		// Token: 0x040019AC RID: 6572
		public const short TungstenWatch = 708;

		// Token: 0x040019AD RID: 6573
		public const short PlatinumWatch = 709;

		// Token: 0x040019AE RID: 6574
		public const short TinChandelier = 710;

		// Token: 0x040019AF RID: 6575
		public const short TungstenChandelier = 711;

		// Token: 0x040019B0 RID: 6576
		public const short PlatinumChandelier = 712;

		// Token: 0x040019B1 RID: 6577
		public const short PlatinumCandle = 713;

		// Token: 0x040019B2 RID: 6578
		public const short PlatinumCandelabra = 714;

		// Token: 0x040019B3 RID: 6579
		public const short PlatinumCrown = 715;

		// Token: 0x040019B4 RID: 6580
		public const short LeadAnvil = 716;

		// Token: 0x040019B5 RID: 6581
		public const short TinBrick = 717;

		// Token: 0x040019B6 RID: 6582
		public const short TungstenBrick = 718;

		// Token: 0x040019B7 RID: 6583
		public const short PlatinumBrick = 719;

		// Token: 0x040019B8 RID: 6584
		public const short TinBrickWall = 720;

		// Token: 0x040019B9 RID: 6585
		public const short TungstenBrickWall = 721;

		// Token: 0x040019BA RID: 6586
		public const short PlatinumBrickWall = 722;

		// Token: 0x040019BB RID: 6587
		public const short BeamSword = 723;

		// Token: 0x040019BC RID: 6588
		public const short IceBlade = 724;

		// Token: 0x040019BD RID: 6589
		public const short IceBow = 725;

		// Token: 0x040019BE RID: 6590
		public const short FrostStaff = 726;

		// Token: 0x040019BF RID: 6591
		public const short WoodHelmet = 727;

		// Token: 0x040019C0 RID: 6592
		public const short WoodBreastplate = 728;

		// Token: 0x040019C1 RID: 6593
		public const short WoodGreaves = 729;

		// Token: 0x040019C2 RID: 6594
		public const short EbonwoodHelmet = 730;

		// Token: 0x040019C3 RID: 6595
		public const short EbonwoodBreastplate = 731;

		// Token: 0x040019C4 RID: 6596
		public const short EbonwoodGreaves = 732;

		// Token: 0x040019C5 RID: 6597
		public const short RichMahoganyHelmet = 733;

		// Token: 0x040019C6 RID: 6598
		public const short RichMahoganyBreastplate = 734;

		// Token: 0x040019C7 RID: 6599
		public const short RichMahoganyGreaves = 735;

		// Token: 0x040019C8 RID: 6600
		public const short PearlwoodHelmet = 736;

		// Token: 0x040019C9 RID: 6601
		public const short PearlwoodBreastplate = 737;

		// Token: 0x040019CA RID: 6602
		public const short PearlwoodGreaves = 738;

		// Token: 0x040019CB RID: 6603
		public const short AmethystStaff = 739;

		// Token: 0x040019CC RID: 6604
		public const short TopazStaff = 740;

		// Token: 0x040019CD RID: 6605
		public const short SapphireStaff = 741;

		// Token: 0x040019CE RID: 6606
		public const short EmeraldStaff = 742;

		// Token: 0x040019CF RID: 6607
		public const short RubyStaff = 743;

		// Token: 0x040019D0 RID: 6608
		public const short DiamondStaff = 744;

		// Token: 0x040019D1 RID: 6609
		public const short GrassWall = 745;

		// Token: 0x040019D2 RID: 6610
		public const short JungleWall = 746;

		// Token: 0x040019D3 RID: 6611
		public const short FlowerWall = 747;

		// Token: 0x040019D4 RID: 6612
		public const short Jetpack = 748;

		// Token: 0x040019D5 RID: 6613
		public const short ButterflyWings = 749;

		// Token: 0x040019D6 RID: 6614
		public const short CactusWall = 750;

		// Token: 0x040019D7 RID: 6615
		public const short Cloud = 751;

		// Token: 0x040019D8 RID: 6616
		public const short CloudWall = 752;

		// Token: 0x040019D9 RID: 6617
		public const short Seaweed = 753;

		// Token: 0x040019DA RID: 6618
		public const short RuneHat = 754;

		// Token: 0x040019DB RID: 6619
		public const short RuneRobe = 755;

		// Token: 0x040019DC RID: 6620
		public const short MushroomSpear = 756;

		// Token: 0x040019DD RID: 6621
		public const short TerraBlade = 757;

		// Token: 0x040019DE RID: 6622
		public const short GrenadeLauncher = 758;

		// Token: 0x040019DF RID: 6623
		public const short RocketLauncher = 759;

		// Token: 0x040019E0 RID: 6624
		public const short ProximityMineLauncher = 760;

		// Token: 0x040019E1 RID: 6625
		public const short FairyWings = 761;

		// Token: 0x040019E2 RID: 6626
		public const short SlimeBlock = 762;

		// Token: 0x040019E3 RID: 6627
		public const short FleshBlock = 763;

		// Token: 0x040019E4 RID: 6628
		public const short MushroomWall = 764;

		// Token: 0x040019E5 RID: 6629
		public const short RainCloud = 765;

		// Token: 0x040019E6 RID: 6630
		public const short BoneBlock = 766;

		// Token: 0x040019E7 RID: 6631
		public const short FrozenSlimeBlock = 767;

		// Token: 0x040019E8 RID: 6632
		public const short BoneBlockWall = 768;

		// Token: 0x040019E9 RID: 6633
		public const short SlimeBlockWall = 769;

		// Token: 0x040019EA RID: 6634
		public const short FleshBlockWall = 770;

		// Token: 0x040019EB RID: 6635
		public const short RocketI = 771;

		// Token: 0x040019EC RID: 6636
		public const short RocketII = 772;

		// Token: 0x040019ED RID: 6637
		public const short RocketIII = 773;

		// Token: 0x040019EE RID: 6638
		public const short RocketIV = 774;

		// Token: 0x040019EF RID: 6639
		public const short AsphaltBlock = 775;

		// Token: 0x040019F0 RID: 6640
		public const short CobaltPickaxe = 776;

		// Token: 0x040019F1 RID: 6641
		public const short MythrilPickaxe = 777;

		// Token: 0x040019F2 RID: 6642
		public const short AdamantitePickaxe = 778;

		// Token: 0x040019F3 RID: 6643
		public const short Clentaminator = 779;

		// Token: 0x040019F4 RID: 6644
		public const short GreenSolution = 780;

		// Token: 0x040019F5 RID: 6645
		public const short BlueSolution = 781;

		// Token: 0x040019F6 RID: 6646
		public const short PurpleSolution = 782;

		// Token: 0x040019F7 RID: 6647
		public const short DarkBlueSolution = 783;

		// Token: 0x040019F8 RID: 6648
		public const short RedSolution = 784;

		// Token: 0x040019F9 RID: 6649
		public const short HarpyWings = 785;

		// Token: 0x040019FA RID: 6650
		public const short BoneWings = 786;

		// Token: 0x040019FB RID: 6651
		public const short Hammush = 787;

		// Token: 0x040019FC RID: 6652
		public const short NettleBurst = 788;

		// Token: 0x040019FD RID: 6653
		public const short AnkhBanner = 789;

		// Token: 0x040019FE RID: 6654
		public const short SnakeBanner = 790;

		// Token: 0x040019FF RID: 6655
		public const short OmegaBanner = 791;

		// Token: 0x04001A00 RID: 6656
		public const short CrimsonHelmet = 792;

		// Token: 0x04001A01 RID: 6657
		public const short CrimsonScalemail = 793;

		// Token: 0x04001A02 RID: 6658
		public const short CrimsonGreaves = 794;

		// Token: 0x04001A03 RID: 6659
		public const short BloodButcherer = 795;

		// Token: 0x04001A04 RID: 6660
		public const short TendonBow = 796;

		// Token: 0x04001A05 RID: 6661
		public const short FleshGrinder = 797;

		// Token: 0x04001A06 RID: 6662
		public const short DeathbringerPickaxe = 798;

		// Token: 0x04001A07 RID: 6663
		public const short BloodLustCluster = 799;

		// Token: 0x04001A08 RID: 6664
		public const short TheUndertaker = 800;

		// Token: 0x04001A09 RID: 6665
		public const short TheMeatball = 801;

		// Token: 0x04001A0A RID: 6666
		public const short TheRottedFork = 802;

		// Token: 0x04001A0B RID: 6667
		public const short EskimoHood = 803;

		// Token: 0x04001A0C RID: 6668
		public const short EskimoCoat = 804;

		// Token: 0x04001A0D RID: 6669
		public const short EskimoPants = 805;

		// Token: 0x04001A0E RID: 6670
		public const short LivingWoodChair = 806;

		// Token: 0x04001A0F RID: 6671
		public const short CactusChair = 807;

		// Token: 0x04001A10 RID: 6672
		public const short BoneChair = 808;

		// Token: 0x04001A11 RID: 6673
		public const short FleshChair = 809;

		// Token: 0x04001A12 RID: 6674
		public const short MushroomChair = 810;

		// Token: 0x04001A13 RID: 6675
		public const short BoneWorkBench = 811;

		// Token: 0x04001A14 RID: 6676
		public const short CactusWorkBench = 812;

		// Token: 0x04001A15 RID: 6677
		public const short FleshWorkBench = 813;

		// Token: 0x04001A16 RID: 6678
		public const short MushroomWorkBench = 814;

		// Token: 0x04001A17 RID: 6679
		public const short SlimeWorkBench = 815;

		// Token: 0x04001A18 RID: 6680
		public const short CactusDoor = 816;

		// Token: 0x04001A19 RID: 6681
		public const short FleshDoor = 817;

		// Token: 0x04001A1A RID: 6682
		public const short MushroomDoor = 818;

		// Token: 0x04001A1B RID: 6683
		public const short LivingWoodDoor = 819;

		// Token: 0x04001A1C RID: 6684
		public const short BoneDoor = 820;

		// Token: 0x04001A1D RID: 6685
		public const short FlameWings = 821;

		// Token: 0x04001A1E RID: 6686
		public const short FrozenWings = 822;

		// Token: 0x04001A1F RID: 6687
		public const short GhostWings = 823;

		// Token: 0x04001A20 RID: 6688
		public const short SunplateBlock = 824;

		// Token: 0x04001A21 RID: 6689
		public const short DiscWall = 825;

		// Token: 0x04001A22 RID: 6690
		public const short SkywareChair = 826;

		// Token: 0x04001A23 RID: 6691
		public const short BoneTable = 827;

		// Token: 0x04001A24 RID: 6692
		public const short FleshTable = 828;

		// Token: 0x04001A25 RID: 6693
		public const short LivingWoodTable = 829;

		// Token: 0x04001A26 RID: 6694
		public const short SkywareTable = 830;

		// Token: 0x04001A27 RID: 6695
		public const short LivingWoodChest = 831;

		// Token: 0x04001A28 RID: 6696
		public const short LivingWoodWand = 832;

		// Token: 0x04001A29 RID: 6697
		public const short PurpleIceBlock = 833;

		// Token: 0x04001A2A RID: 6698
		public const short PinkIceBlock = 834;

		// Token: 0x04001A2B RID: 6699
		public const short RedIceBlock = 835;

		// Token: 0x04001A2C RID: 6700
		public const short CrimstoneBlock = 836;

		// Token: 0x04001A2D RID: 6701
		public const short SkywareDoor = 837;

		// Token: 0x04001A2E RID: 6702
		public const short SkywareChest = 838;

		// Token: 0x04001A2F RID: 6703
		public const short SteampunkHat = 839;

		// Token: 0x04001A30 RID: 6704
		public const short SteampunkShirt = 840;

		// Token: 0x04001A31 RID: 6705
		public const short SteampunkPants = 841;

		// Token: 0x04001A32 RID: 6706
		public const short BeeHat = 842;

		// Token: 0x04001A33 RID: 6707
		public const short BeeShirt = 843;

		// Token: 0x04001A34 RID: 6708
		public const short BeePants = 844;

		// Token: 0x04001A35 RID: 6709
		public const short WorldBanner = 845;

		// Token: 0x04001A36 RID: 6710
		public const short SunBanner = 846;

		// Token: 0x04001A37 RID: 6711
		public const short GravityBanner = 847;

		// Token: 0x04001A38 RID: 6712
		public const short PharaohsMask = 848;

		// Token: 0x04001A39 RID: 6713
		public const short Actuator = 849;

		// Token: 0x04001A3A RID: 6714
		public const short BlueWrench = 850;

		// Token: 0x04001A3B RID: 6715
		public const short GreenWrench = 851;

		// Token: 0x04001A3C RID: 6716
		public const short BluePressurePlate = 852;

		// Token: 0x04001A3D RID: 6717
		public const short YellowPressurePlate = 853;

		// Token: 0x04001A3E RID: 6718
		public const short DiscountCard = 854;

		// Token: 0x04001A3F RID: 6719
		public const short LuckyCoin = 855;

		// Token: 0x04001A40 RID: 6720
		public const short UnicornonaStick = 856;

		// Token: 0x04001A41 RID: 6721
		public const short SandstorminaBottle = 857;

		// Token: 0x04001A42 RID: 6722
		public const short BorealWoodSofa = 858;

		// Token: 0x04001A43 RID: 6723
		public const short BeachBall = 859;

		// Token: 0x04001A44 RID: 6724
		public const short CharmofMyths = 860;

		// Token: 0x04001A45 RID: 6725
		public const short MoonShell = 861;

		// Token: 0x04001A46 RID: 6726
		public const short StarVeil = 862;

		// Token: 0x04001A47 RID: 6727
		public const short WaterWalkingBoots = 863;

		// Token: 0x04001A48 RID: 6728
		public const short Tiara = 864;

		// Token: 0x04001A49 RID: 6729
		public const short PrincessDress = 865;

		// Token: 0x04001A4A RID: 6730
		public const short PharaohsRobe = 866;

		// Token: 0x04001A4B RID: 6731
		public const short GreenCap = 867;

		// Token: 0x04001A4C RID: 6732
		public const short MushroomCap = 868;

		// Token: 0x04001A4D RID: 6733
		public const short TamOShanter = 869;

		// Token: 0x04001A4E RID: 6734
		public const short MummyMask = 870;

		// Token: 0x04001A4F RID: 6735
		public const short MummyShirt = 871;

		// Token: 0x04001A50 RID: 6736
		public const short MummyPants = 872;

		// Token: 0x04001A51 RID: 6737
		public const short CowboyHat = 873;

		// Token: 0x04001A52 RID: 6738
		public const short CowboyJacket = 874;

		// Token: 0x04001A53 RID: 6739
		public const short CowboyPants = 875;

		// Token: 0x04001A54 RID: 6740
		public const short PirateHat = 876;

		// Token: 0x04001A55 RID: 6741
		public const short PirateShirt = 877;

		// Token: 0x04001A56 RID: 6742
		public const short PiratePants = 878;

		// Token: 0x04001A57 RID: 6743
		public const short VikingHelmet = 879;

		// Token: 0x04001A58 RID: 6744
		public const short CrimtaneOre = 880;

		// Token: 0x04001A59 RID: 6745
		public const short CactusSword = 881;

		// Token: 0x04001A5A RID: 6746
		public const short CactusPickaxe = 882;

		// Token: 0x04001A5B RID: 6747
		public const short IceBrick = 883;

		// Token: 0x04001A5C RID: 6748
		public const short IceBrickWall = 884;

		// Token: 0x04001A5D RID: 6749
		public const short AdhesiveBandage = 885;

		// Token: 0x04001A5E RID: 6750
		public const short ArmorPolish = 886;

		// Token: 0x04001A5F RID: 6751
		public const short Bezoar = 887;

		// Token: 0x04001A60 RID: 6752
		public const short Blindfold = 888;

		// Token: 0x04001A61 RID: 6753
		public const short FastClock = 889;

		// Token: 0x04001A62 RID: 6754
		public const short Megaphone = 890;

		// Token: 0x04001A63 RID: 6755
		public const short Nazar = 891;

		// Token: 0x04001A64 RID: 6756
		public const short Vitamins = 892;

		// Token: 0x04001A65 RID: 6757
		public const short TrifoldMap = 893;

		// Token: 0x04001A66 RID: 6758
		public const short CactusHelmet = 894;

		// Token: 0x04001A67 RID: 6759
		public const short CactusBreastplate = 895;

		// Token: 0x04001A68 RID: 6760
		public const short CactusLeggings = 896;

		// Token: 0x04001A69 RID: 6761
		public const short PowerGlove = 897;

		// Token: 0x04001A6A RID: 6762
		public const short LightningBoots = 898;

		// Token: 0x04001A6B RID: 6763
		public const short SunStone = 899;

		// Token: 0x04001A6C RID: 6764
		public const short MoonStone = 900;

		// Token: 0x04001A6D RID: 6765
		public const short ArmorBracing = 901;

		// Token: 0x04001A6E RID: 6766
		public const short MedicatedBandage = 902;

		// Token: 0x04001A6F RID: 6767
		public const short ThePlan = 903;

		// Token: 0x04001A70 RID: 6768
		public const short CountercurseMantra = 904;

		// Token: 0x04001A71 RID: 6769
		public const short CoinGun = 905;

		// Token: 0x04001A72 RID: 6770
		public const short LavaCharm = 906;

		// Token: 0x04001A73 RID: 6771
		public const short ObsidianWaterWalkingBoots = 907;

		// Token: 0x04001A74 RID: 6772
		public const short LavaWaders = 908;

		// Token: 0x04001A75 RID: 6773
		public const short PureWaterFountain = 909;

		// Token: 0x04001A76 RID: 6774
		public const short DesertWaterFountain = 910;

		// Token: 0x04001A77 RID: 6775
		public const short Shadewood = 911;

		// Token: 0x04001A78 RID: 6776
		public const short ShadewoodDoor = 912;

		// Token: 0x04001A79 RID: 6777
		public const short ShadewoodPlatform = 913;

		// Token: 0x04001A7A RID: 6778
		public const short ShadewoodChest = 914;

		// Token: 0x04001A7B RID: 6779
		public const short ShadewoodChair = 915;

		// Token: 0x04001A7C RID: 6780
		public const short ShadewoodWorkBench = 916;

		// Token: 0x04001A7D RID: 6781
		public const short ShadewoodTable = 917;

		// Token: 0x04001A7E RID: 6782
		public const short ShadewoodDresser = 918;

		// Token: 0x04001A7F RID: 6783
		public const short ShadewoodPiano = 919;

		// Token: 0x04001A80 RID: 6784
		public const short ShadewoodBed = 920;

		// Token: 0x04001A81 RID: 6785
		public const short ShadewoodSword = 921;

		// Token: 0x04001A82 RID: 6786
		public const short ShadewoodHammer = 922;

		// Token: 0x04001A83 RID: 6787
		public const short ShadewoodBow = 923;

		// Token: 0x04001A84 RID: 6788
		public const short ShadewoodHelmet = 924;

		// Token: 0x04001A85 RID: 6789
		public const short ShadewoodBreastplate = 925;

		// Token: 0x04001A86 RID: 6790
		public const short ShadewoodGreaves = 926;

		// Token: 0x04001A87 RID: 6791
		public const short ShadewoodWall = 927;

		// Token: 0x04001A88 RID: 6792
		public const short Cannon = 928;

		// Token: 0x04001A89 RID: 6793
		public const short Cannonball = 929;

		// Token: 0x04001A8A RID: 6794
		public const short FlareGun = 930;

		// Token: 0x04001A8B RID: 6795
		public const short Flare = 931;

		// Token: 0x04001A8C RID: 6796
		public const short BoneWand = 932;

		// Token: 0x04001A8D RID: 6797
		public const short LeafWand = 933;

		// Token: 0x04001A8E RID: 6798
		public const short FlyingCarpet = 934;

		// Token: 0x04001A8F RID: 6799
		public const short AvengerEmblem = 935;

		// Token: 0x04001A90 RID: 6800
		public const short MechanicalGlove = 936;

		// Token: 0x04001A91 RID: 6801
		public const short LandMine = 937;

		// Token: 0x04001A92 RID: 6802
		public const short PaladinsShield = 938;

		// Token: 0x04001A93 RID: 6803
		public const short WebSlinger = 939;

		// Token: 0x04001A94 RID: 6804
		public const short JungleWaterFountain = 940;

		// Token: 0x04001A95 RID: 6805
		public const short IcyWaterFountain = 941;

		// Token: 0x04001A96 RID: 6806
		public const short CorruptWaterFountain = 942;

		// Token: 0x04001A97 RID: 6807
		public const short CrimsonWaterFountain = 943;

		// Token: 0x04001A98 RID: 6808
		public const short HallowedWaterFountain = 944;

		// Token: 0x04001A99 RID: 6809
		public const short BloodWaterFountain = 945;

		// Token: 0x04001A9A RID: 6810
		public const short Umbrella = 946;

		// Token: 0x04001A9B RID: 6811
		public const short ChlorophyteOre = 947;

		// Token: 0x04001A9C RID: 6812
		public const short SteampunkWings = 948;

		// Token: 0x04001A9D RID: 6813
		public const short Snowball = 949;

		// Token: 0x04001A9E RID: 6814
		public const short IceSkates = 950;

		// Token: 0x04001A9F RID: 6815
		public const short SnowballLauncher = 951;

		// Token: 0x04001AA0 RID: 6816
		public const short WebCoveredChest = 952;

		// Token: 0x04001AA1 RID: 6817
		public const short ClimbingClaws = 953;

		// Token: 0x04001AA2 RID: 6818
		public const short AncientIronHelmet = 954;

		// Token: 0x04001AA3 RID: 6819
		public const short AncientGoldHelmet = 955;

		// Token: 0x04001AA4 RID: 6820
		public const short AncientShadowHelmet = 956;

		// Token: 0x04001AA5 RID: 6821
		public const short AncientShadowScalemail = 957;

		// Token: 0x04001AA6 RID: 6822
		public const short AncientShadowGreaves = 958;

		// Token: 0x04001AA7 RID: 6823
		public const short AncientNecroHelmet = 959;

		// Token: 0x04001AA8 RID: 6824
		public const short AncientCobaltHelmet = 960;

		// Token: 0x04001AA9 RID: 6825
		public const short AncientCobaltBreastplate = 961;

		// Token: 0x04001AAA RID: 6826
		public const short AncientCobaltLeggings = 962;

		// Token: 0x04001AAB RID: 6827
		public const short BlackBelt = 963;

		// Token: 0x04001AAC RID: 6828
		public const short Boomstick = 964;

		// Token: 0x04001AAD RID: 6829
		public const short Rope = 965;

		// Token: 0x04001AAE RID: 6830
		public const short Campfire = 966;

		// Token: 0x04001AAF RID: 6831
		public const short Marshmallow = 967;

		// Token: 0x04001AB0 RID: 6832
		public const short MarshmallowonaStick = 968;

		// Token: 0x04001AB1 RID: 6833
		public const short CookedMarshmallow = 969;

		// Token: 0x04001AB2 RID: 6834
		public const short RedRocket = 970;

		// Token: 0x04001AB3 RID: 6835
		public const short GreenRocket = 971;

		// Token: 0x04001AB4 RID: 6836
		public const short BlueRocket = 972;

		// Token: 0x04001AB5 RID: 6837
		public const short YellowRocket = 973;

		// Token: 0x04001AB6 RID: 6838
		public const short IceTorch = 974;

		// Token: 0x04001AB7 RID: 6839
		public const short ShoeSpikes = 975;

		// Token: 0x04001AB8 RID: 6840
		public const short TigerClimbingGear = 976;

		// Token: 0x04001AB9 RID: 6841
		public const short Tabi = 977;

		// Token: 0x04001ABA RID: 6842
		public const short PinkEskimoHood = 978;

		// Token: 0x04001ABB RID: 6843
		public const short PinkEskimoCoat = 979;

		// Token: 0x04001ABC RID: 6844
		public const short PinkEskimoPants = 980;

		// Token: 0x04001ABD RID: 6845
		public const short PinkThread = 981;

		// Token: 0x04001ABE RID: 6846
		public const short ManaRegenerationBand = 982;

		// Token: 0x04001ABF RID: 6847
		public const short SandstorminaBalloon = 983;

		// Token: 0x04001AC0 RID: 6848
		public const short MasterNinjaGear = 984;

		// Token: 0x04001AC1 RID: 6849
		public const short RopeCoil = 985;

		// Token: 0x04001AC2 RID: 6850
		public const short Blowgun = 986;

		// Token: 0x04001AC3 RID: 6851
		public const short BlizzardinaBottle = 987;

		// Token: 0x04001AC4 RID: 6852
		public const short FrostburnArrow = 988;

		// Token: 0x04001AC5 RID: 6853
		public const short EnchantedSword = 989;

		// Token: 0x04001AC6 RID: 6854
		public const short PickaxeAxe = 990;

		// Token: 0x04001AC7 RID: 6855
		public const short CobaltWaraxe = 991;

		// Token: 0x04001AC8 RID: 6856
		public const short MythrilWaraxe = 992;

		// Token: 0x04001AC9 RID: 6857
		public const short AdamantiteWaraxe = 993;

		// Token: 0x04001ACA RID: 6858
		public const short EatersBone = 994;

		// Token: 0x04001ACB RID: 6859
		public const short BlendOMatic = 995;

		// Token: 0x04001ACC RID: 6860
		public const short MeatGrinder = 996;

		// Token: 0x04001ACD RID: 6861
		public const short Extractinator = 997;

		// Token: 0x04001ACE RID: 6862
		public const short Solidifier = 998;

		// Token: 0x04001ACF RID: 6863
		public const short Amber = 999;

		// Token: 0x04001AD0 RID: 6864
		public const short ConfettiGun = 1000;

		// Token: 0x04001AD1 RID: 6865
		public const short ChlorophyteMask = 1001;

		// Token: 0x04001AD2 RID: 6866
		public const short ChlorophyteHelmet = 1002;

		// Token: 0x04001AD3 RID: 6867
		public const short ChlorophyteHeadgear = 1003;

		// Token: 0x04001AD4 RID: 6868
		public const short ChlorophytePlateMail = 1004;

		// Token: 0x04001AD5 RID: 6869
		public const short ChlorophyteGreaves = 1005;

		// Token: 0x04001AD6 RID: 6870
		public const short ChlorophyteBar = 1006;

		// Token: 0x04001AD7 RID: 6871
		public const short RedDye = 1007;

		// Token: 0x04001AD8 RID: 6872
		public const short OrangeDye = 1008;

		// Token: 0x04001AD9 RID: 6873
		public const short YellowDye = 1009;

		// Token: 0x04001ADA RID: 6874
		public const short LimeDye = 1010;

		// Token: 0x04001ADB RID: 6875
		public const short GreenDye = 1011;

		// Token: 0x04001ADC RID: 6876
		public const short TealDye = 1012;

		// Token: 0x04001ADD RID: 6877
		public const short CyanDye = 1013;

		// Token: 0x04001ADE RID: 6878
		public const short SkyBlueDye = 1014;

		// Token: 0x04001ADF RID: 6879
		public const short BlueDye = 1015;

		// Token: 0x04001AE0 RID: 6880
		public const short PurpleDye = 1016;

		// Token: 0x04001AE1 RID: 6881
		public const short VioletDye = 1017;

		// Token: 0x04001AE2 RID: 6882
		public const short PinkDye = 1018;

		// Token: 0x04001AE3 RID: 6883
		public const short RedandBlackDye = 1019;

		// Token: 0x04001AE4 RID: 6884
		public const short OrangeandBlackDye = 1020;

		// Token: 0x04001AE5 RID: 6885
		public const short YellowandBlackDye = 1021;

		// Token: 0x04001AE6 RID: 6886
		public const short LimeandBlackDye = 1022;

		// Token: 0x04001AE7 RID: 6887
		public const short GreenandBlackDye = 1023;

		// Token: 0x04001AE8 RID: 6888
		public const short TealandBlackDye = 1024;

		// Token: 0x04001AE9 RID: 6889
		public const short CyanandBlackDye = 1025;

		// Token: 0x04001AEA RID: 6890
		public const short SkyBlueandBlackDye = 1026;

		// Token: 0x04001AEB RID: 6891
		public const short BlueandBlackDye = 1027;

		// Token: 0x04001AEC RID: 6892
		public const short PurpleandBlackDye = 1028;

		// Token: 0x04001AED RID: 6893
		public const short VioletandBlackDye = 1029;

		// Token: 0x04001AEE RID: 6894
		public const short PinkandBlackDye = 1030;

		// Token: 0x04001AEF RID: 6895
		public const short FlameDye = 1031;

		// Token: 0x04001AF0 RID: 6896
		public const short FlameAndBlackDye = 1032;

		// Token: 0x04001AF1 RID: 6897
		public const short GreenFlameDye = 1033;

		// Token: 0x04001AF2 RID: 6898
		public const short GreenFlameAndBlackDye = 1034;

		// Token: 0x04001AF3 RID: 6899
		public const short BlueFlameDye = 1035;

		// Token: 0x04001AF4 RID: 6900
		public const short BlueFlameAndBlackDye = 1036;

		// Token: 0x04001AF5 RID: 6901
		public const short SilverDye = 1037;

		// Token: 0x04001AF6 RID: 6902
		public const short BrightRedDye = 1038;

		// Token: 0x04001AF7 RID: 6903
		public const short BrightOrangeDye = 1039;

		// Token: 0x04001AF8 RID: 6904
		public const short BrightYellowDye = 1040;

		// Token: 0x04001AF9 RID: 6905
		public const short BrightLimeDye = 1041;

		// Token: 0x04001AFA RID: 6906
		public const short BrightGreenDye = 1042;

		// Token: 0x04001AFB RID: 6907
		public const short BrightTealDye = 1043;

		// Token: 0x04001AFC RID: 6908
		public const short BrightCyanDye = 1044;

		// Token: 0x04001AFD RID: 6909
		public const short BrightSkyBlueDye = 1045;

		// Token: 0x04001AFE RID: 6910
		public const short BrightBlueDye = 1046;

		// Token: 0x04001AFF RID: 6911
		public const short BrightPurpleDye = 1047;

		// Token: 0x04001B00 RID: 6912
		public const short BrightVioletDye = 1048;

		// Token: 0x04001B01 RID: 6913
		public const short BrightPinkDye = 1049;

		// Token: 0x04001B02 RID: 6914
		public const short BlackDye = 1050;

		// Token: 0x04001B03 RID: 6915
		public const short RedandSilverDye = 1051;

		// Token: 0x04001B04 RID: 6916
		public const short OrangeandSilverDye = 1052;

		// Token: 0x04001B05 RID: 6917
		public const short YellowandSilverDye = 1053;

		// Token: 0x04001B06 RID: 6918
		public const short LimeandSilverDye = 1054;

		// Token: 0x04001B07 RID: 6919
		public const short GreenandSilverDye = 1055;

		// Token: 0x04001B08 RID: 6920
		public const short TealandSilverDye = 1056;

		// Token: 0x04001B09 RID: 6921
		public const short CyanandSilverDye = 1057;

		// Token: 0x04001B0A RID: 6922
		public const short SkyBlueandSilverDye = 1058;

		// Token: 0x04001B0B RID: 6923
		public const short BlueandSilverDye = 1059;

		// Token: 0x04001B0C RID: 6924
		public const short PurpleandSilverDye = 1060;

		// Token: 0x04001B0D RID: 6925
		public const short VioletandSilverDye = 1061;

		// Token: 0x04001B0E RID: 6926
		public const short PinkandSilverDye = 1062;

		// Token: 0x04001B0F RID: 6927
		public const short IntenseFlameDye = 1063;

		// Token: 0x04001B10 RID: 6928
		public const short IntenseGreenFlameDye = 1064;

		// Token: 0x04001B11 RID: 6929
		public const short IntenseBlueFlameDye = 1065;

		// Token: 0x04001B12 RID: 6930
		public const short RainbowDye = 1066;

		// Token: 0x04001B13 RID: 6931
		public const short IntenseRainbowDye = 1067;

		// Token: 0x04001B14 RID: 6932
		public const short YellowGradientDye = 1068;

		// Token: 0x04001B15 RID: 6933
		public const short CyanGradientDye = 1069;

		// Token: 0x04001B16 RID: 6934
		public const short VioletGradientDye = 1070;

		// Token: 0x04001B17 RID: 6935
		public const short Paintbrush = 1071;

		// Token: 0x04001B18 RID: 6936
		public const short PaintRoller = 1072;

		// Token: 0x04001B19 RID: 6937
		public const short RedPaint = 1073;

		// Token: 0x04001B1A RID: 6938
		public const short OrangePaint = 1074;

		// Token: 0x04001B1B RID: 6939
		public const short YellowPaint = 1075;

		// Token: 0x04001B1C RID: 6940
		public const short LimePaint = 1076;

		// Token: 0x04001B1D RID: 6941
		public const short GreenPaint = 1077;

		// Token: 0x04001B1E RID: 6942
		public const short TealPaint = 1078;

		// Token: 0x04001B1F RID: 6943
		public const short CyanPaint = 1079;

		// Token: 0x04001B20 RID: 6944
		public const short SkyBluePaint = 1080;

		// Token: 0x04001B21 RID: 6945
		public const short BluePaint = 1081;

		// Token: 0x04001B22 RID: 6946
		public const short PurplePaint = 1082;

		// Token: 0x04001B23 RID: 6947
		public const short VioletPaint = 1083;

		// Token: 0x04001B24 RID: 6948
		public const short PinkPaint = 1084;

		// Token: 0x04001B25 RID: 6949
		public const short DeepRedPaint = 1085;

		// Token: 0x04001B26 RID: 6950
		public const short DeepOrangePaint = 1086;

		// Token: 0x04001B27 RID: 6951
		public const short DeepYellowPaint = 1087;

		// Token: 0x04001B28 RID: 6952
		public const short DeepLimePaint = 1088;

		// Token: 0x04001B29 RID: 6953
		public const short DeepGreenPaint = 1089;

		// Token: 0x04001B2A RID: 6954
		public const short DeepTealPaint = 1090;

		// Token: 0x04001B2B RID: 6955
		public const short DeepCyanPaint = 1091;

		// Token: 0x04001B2C RID: 6956
		public const short DeepSkyBluePaint = 1092;

		// Token: 0x04001B2D RID: 6957
		public const short DeepBluePaint = 1093;

		// Token: 0x04001B2E RID: 6958
		public const short DeepPurplePaint = 1094;

		// Token: 0x04001B2F RID: 6959
		public const short DeepVioletPaint = 1095;

		// Token: 0x04001B30 RID: 6960
		public const short DeepPinkPaint = 1096;

		// Token: 0x04001B31 RID: 6961
		public const short BlackPaint = 1097;

		// Token: 0x04001B32 RID: 6962
		public const short WhitePaint = 1098;

		// Token: 0x04001B33 RID: 6963
		public const short GrayPaint = 1099;

		// Token: 0x04001B34 RID: 6964
		public const short PaintScraper = 1100;

		// Token: 0x04001B35 RID: 6965
		public const short LihzahrdBrick = 1101;

		// Token: 0x04001B36 RID: 6966
		public const short LihzahrdBrickWall = 1102;

		// Token: 0x04001B37 RID: 6967
		public const short SlushBlock = 1103;

		// Token: 0x04001B38 RID: 6968
		public const short PalladiumOre = 1104;

		// Token: 0x04001B39 RID: 6969
		public const short OrichalcumOre = 1105;

		// Token: 0x04001B3A RID: 6970
		public const short TitaniumOre = 1106;

		// Token: 0x04001B3B RID: 6971
		public const short TealMushroom = 1107;

		// Token: 0x04001B3C RID: 6972
		public const short GreenMushroom = 1108;

		// Token: 0x04001B3D RID: 6973
		public const short SkyBlueFlower = 1109;

		// Token: 0x04001B3E RID: 6974
		public const short YellowMarigold = 1110;

		// Token: 0x04001B3F RID: 6975
		public const short BlueBerries = 1111;

		// Token: 0x04001B40 RID: 6976
		public const short LimeKelp = 1112;

		// Token: 0x04001B41 RID: 6977
		public const short PinkPricklyPear = 1113;

		// Token: 0x04001B42 RID: 6978
		public const short OrangeBloodroot = 1114;

		// Token: 0x04001B43 RID: 6979
		public const short RedHusk = 1115;

		// Token: 0x04001B44 RID: 6980
		public const short CyanHusk = 1116;

		// Token: 0x04001B45 RID: 6981
		public const short VioletHusk = 1117;

		// Token: 0x04001B46 RID: 6982
		public const short PurpleMucos = 1118;

		// Token: 0x04001B47 RID: 6983
		public const short BlackInk = 1119;

		// Token: 0x04001B48 RID: 6984
		public const short DyeVat = 1120;

		// Token: 0x04001B49 RID: 6985
		public const short BeeGun = 1121;

		// Token: 0x04001B4A RID: 6986
		public const short PossessedHatchet = 1122;

		// Token: 0x04001B4B RID: 6987
		public const short BeeKeeper = 1123;

		// Token: 0x04001B4C RID: 6988
		public const short Hive = 1124;

		// Token: 0x04001B4D RID: 6989
		public const short HoneyBlock = 1125;

		// Token: 0x04001B4E RID: 6990
		public const short HiveWall = 1126;

		// Token: 0x04001B4F RID: 6991
		public const short CrispyHoneyBlock = 1127;

		// Token: 0x04001B50 RID: 6992
		public const short HoneyBucket = 1128;

		// Token: 0x04001B51 RID: 6993
		public const short HiveWand = 1129;

		// Token: 0x04001B52 RID: 6994
		public const short Beenade = 1130;

		// Token: 0x04001B53 RID: 6995
		public const short GravityGlobe = 1131;

		// Token: 0x04001B54 RID: 6996
		public const short HoneyComb = 1132;

		// Token: 0x04001B55 RID: 6997
		public const short Abeemination = 1133;

		// Token: 0x04001B56 RID: 6998
		public const short BottledHoney = 1134;

		// Token: 0x04001B57 RID: 6999
		public const short RainHat = 1135;

		// Token: 0x04001B58 RID: 7000
		public const short RainCoat = 1136;

		// Token: 0x04001B59 RID: 7001
		public const short LihzahrdDoor = 1137;

		// Token: 0x04001B5A RID: 7002
		public const short DungeonDoor = 1138;

		// Token: 0x04001B5B RID: 7003
		public const short LeadDoor = 1139;

		// Token: 0x04001B5C RID: 7004
		public const short IronDoor = 1140;

		// Token: 0x04001B5D RID: 7005
		public const short TempleKey = 1141;

		// Token: 0x04001B5E RID: 7006
		public const short LihzahrdChest = 1142;

		// Token: 0x04001B5F RID: 7007
		public const short LihzahrdChair = 1143;

		// Token: 0x04001B60 RID: 7008
		public const short LihzahrdTable = 1144;

		// Token: 0x04001B61 RID: 7009
		public const short LihzahrdWorkBench = 1145;

		// Token: 0x04001B62 RID: 7010
		public const short SuperDartTrap = 1146;

		// Token: 0x04001B63 RID: 7011
		public const short FlameTrap = 1147;

		// Token: 0x04001B64 RID: 7012
		public const short SpikyBallTrap = 1148;

		// Token: 0x04001B65 RID: 7013
		public const short SpearTrap = 1149;

		// Token: 0x04001B66 RID: 7014
		public const short WoodenSpike = 1150;

		// Token: 0x04001B67 RID: 7015
		public const short LihzahrdPressurePlate = 1151;

		// Token: 0x04001B68 RID: 7016
		public const short LihzahrdStatue = 1152;

		// Token: 0x04001B69 RID: 7017
		public const short LihzahrdWatcherStatue = 1153;

		// Token: 0x04001B6A RID: 7018
		public const short LihzahrdGuardianStatue = 1154;

		// Token: 0x04001B6B RID: 7019
		public const short WaspGun = 1155;

		// Token: 0x04001B6C RID: 7020
		public const short PiranhaGun = 1156;

		// Token: 0x04001B6D RID: 7021
		public const short PygmyStaff = 1157;

		// Token: 0x04001B6E RID: 7022
		public const short PygmyNecklace = 1158;

		// Token: 0x04001B6F RID: 7023
		public const short TikiMask = 1159;

		// Token: 0x04001B70 RID: 7024
		public const short TikiShirt = 1160;

		// Token: 0x04001B71 RID: 7025
		public const short TikiPants = 1161;

		// Token: 0x04001B72 RID: 7026
		public const short LeafWings = 1162;

		// Token: 0x04001B73 RID: 7027
		public const short BlizzardinaBalloon = 1163;

		// Token: 0x04001B74 RID: 7028
		public const short BundleofBalloons = 1164;

		// Token: 0x04001B75 RID: 7029
		public const short BatWings = 1165;

		// Token: 0x04001B76 RID: 7030
		public const short BoneSword = 1166;

		// Token: 0x04001B77 RID: 7031
		public const short HerculesBeetle = 1167;

		// Token: 0x04001B78 RID: 7032
		public const short SmokeBomb = 1168;

		// Token: 0x04001B79 RID: 7033
		public const short BoneKey = 1169;

		// Token: 0x04001B7A RID: 7034
		public const short Nectar = 1170;

		// Token: 0x04001B7B RID: 7035
		public const short TikiTotem = 1171;

		// Token: 0x04001B7C RID: 7036
		public const short LizardEgg = 1172;

		// Token: 0x04001B7D RID: 7037
		public const short GraveMarker = 1173;

		// Token: 0x04001B7E RID: 7038
		public const short CrossGraveMarker = 1174;

		// Token: 0x04001B7F RID: 7039
		public const short Headstone = 1175;

		// Token: 0x04001B80 RID: 7040
		public const short Gravestone = 1176;

		// Token: 0x04001B81 RID: 7041
		public const short Obelisk = 1177;

		// Token: 0x04001B82 RID: 7042
		public const short LeafBlower = 1178;

		// Token: 0x04001B83 RID: 7043
		public const short ChlorophyteBullet = 1179;

		// Token: 0x04001B84 RID: 7044
		public const short ParrotCracker = 1180;

		// Token: 0x04001B85 RID: 7045
		public const short StrangeGlowingMushroom = 1181;

		// Token: 0x04001B86 RID: 7046
		public const short Seedling = 1182;

		// Token: 0x04001B87 RID: 7047
		public const short WispinaBottle = 1183;

		// Token: 0x04001B88 RID: 7048
		public const short PalladiumBar = 1184;

		// Token: 0x04001B89 RID: 7049
		public const short PalladiumSword = 1185;

		// Token: 0x04001B8A RID: 7050
		public const short PalladiumPike = 1186;

		// Token: 0x04001B8B RID: 7051
		public const short PalladiumRepeater = 1187;

		// Token: 0x04001B8C RID: 7052
		public const short PalladiumPickaxe = 1188;

		// Token: 0x04001B8D RID: 7053
		public const short PalladiumDrill = 1189;

		// Token: 0x04001B8E RID: 7054
		public const short PalladiumChainsaw = 1190;

		// Token: 0x04001B8F RID: 7055
		public const short OrichalcumBar = 1191;

		// Token: 0x04001B90 RID: 7056
		public const short OrichalcumSword = 1192;

		// Token: 0x04001B91 RID: 7057
		public const short OrichalcumHalberd = 1193;

		// Token: 0x04001B92 RID: 7058
		public const short OrichalcumRepeater = 1194;

		// Token: 0x04001B93 RID: 7059
		public const short OrichalcumPickaxe = 1195;

		// Token: 0x04001B94 RID: 7060
		public const short OrichalcumDrill = 1196;

		// Token: 0x04001B95 RID: 7061
		public const short OrichalcumChainsaw = 1197;

		// Token: 0x04001B96 RID: 7062
		public const short TitaniumBar = 1198;

		// Token: 0x04001B97 RID: 7063
		public const short TitaniumSword = 1199;

		// Token: 0x04001B98 RID: 7064
		public const short TitaniumTrident = 1200;

		// Token: 0x04001B99 RID: 7065
		public const short TitaniumRepeater = 1201;

		// Token: 0x04001B9A RID: 7066
		public const short TitaniumPickaxe = 1202;

		// Token: 0x04001B9B RID: 7067
		public const short TitaniumDrill = 1203;

		// Token: 0x04001B9C RID: 7068
		public const short TitaniumChainsaw = 1204;

		// Token: 0x04001B9D RID: 7069
		public const short PalladiumMask = 1205;

		// Token: 0x04001B9E RID: 7070
		public const short PalladiumHelmet = 1206;

		// Token: 0x04001B9F RID: 7071
		public const short PalladiumHeadgear = 1207;

		// Token: 0x04001BA0 RID: 7072
		public const short PalladiumBreastplate = 1208;

		// Token: 0x04001BA1 RID: 7073
		public const short PalladiumLeggings = 1209;

		// Token: 0x04001BA2 RID: 7074
		public const short OrichalcumMask = 1210;

		// Token: 0x04001BA3 RID: 7075
		public const short OrichalcumHelmet = 1211;

		// Token: 0x04001BA4 RID: 7076
		public const short OrichalcumHeadgear = 1212;

		// Token: 0x04001BA5 RID: 7077
		public const short OrichalcumBreastplate = 1213;

		// Token: 0x04001BA6 RID: 7078
		public const short OrichalcumLeggings = 1214;

		// Token: 0x04001BA7 RID: 7079
		public const short TitaniumMask = 1215;

		// Token: 0x04001BA8 RID: 7080
		public const short TitaniumHelmet = 1216;

		// Token: 0x04001BA9 RID: 7081
		public const short TitaniumHeadgear = 1217;

		// Token: 0x04001BAA RID: 7082
		public const short TitaniumBreastplate = 1218;

		// Token: 0x04001BAB RID: 7083
		public const short TitaniumLeggings = 1219;

		// Token: 0x04001BAC RID: 7084
		public const short OrichalcumAnvil = 1220;

		// Token: 0x04001BAD RID: 7085
		public const short TitaniumForge = 1221;

		// Token: 0x04001BAE RID: 7086
		public const short PalladiumWaraxe = 1222;

		// Token: 0x04001BAF RID: 7087
		public const short OrichalcumWaraxe = 1223;

		// Token: 0x04001BB0 RID: 7088
		public const short TitaniumWaraxe = 1224;

		// Token: 0x04001BB1 RID: 7089
		public const short HallowedBar = 1225;

		// Token: 0x04001BB2 RID: 7090
		public const short ChlorophyteClaymore = 1226;

		// Token: 0x04001BB3 RID: 7091
		public const short ChlorophyteSaber = 1227;

		// Token: 0x04001BB4 RID: 7092
		public const short ChlorophytePartisan = 1228;

		// Token: 0x04001BB5 RID: 7093
		public const short ChlorophyteShotbow = 1229;

		// Token: 0x04001BB6 RID: 7094
		public const short ChlorophytePickaxe = 1230;

		// Token: 0x04001BB7 RID: 7095
		public const short ChlorophyteDrill = 1231;

		// Token: 0x04001BB8 RID: 7096
		public const short ChlorophyteChainsaw = 1232;

		// Token: 0x04001BB9 RID: 7097
		public const short ChlorophyteGreataxe = 1233;

		// Token: 0x04001BBA RID: 7098
		public const short ChlorophyteWarhammer = 1234;

		// Token: 0x04001BBB RID: 7099
		public const short ChlorophyteArrow = 1235;

		// Token: 0x04001BBC RID: 7100
		public const short AmethystHook = 1236;

		// Token: 0x04001BBD RID: 7101
		public const short TopazHook = 1237;

		// Token: 0x04001BBE RID: 7102
		public const short SapphireHook = 1238;

		// Token: 0x04001BBF RID: 7103
		public const short EmeraldHook = 1239;

		// Token: 0x04001BC0 RID: 7104
		public const short RubyHook = 1240;

		// Token: 0x04001BC1 RID: 7105
		public const short DiamondHook = 1241;

		// Token: 0x04001BC2 RID: 7106
		public const short AmberMosquito = 1242;

		// Token: 0x04001BC3 RID: 7107
		public const short UmbrellaHat = 1243;

		// Token: 0x04001BC4 RID: 7108
		public const short NimbusRod = 1244;

		// Token: 0x04001BC5 RID: 7109
		public const short OrangeTorch = 1245;

		// Token: 0x04001BC6 RID: 7110
		public const short CrimsandBlock = 1246;

		// Token: 0x04001BC7 RID: 7111
		public const short BeeCloak = 1247;

		// Token: 0x04001BC8 RID: 7112
		public const short EyeoftheGolem = 1248;

		// Token: 0x04001BC9 RID: 7113
		public const short HoneyBalloon = 1249;

		// Token: 0x04001BCA RID: 7114
		public const short BlueHorseshoeBalloon = 1250;

		// Token: 0x04001BCB RID: 7115
		public const short WhiteHorseshoeBalloon = 1251;

		// Token: 0x04001BCC RID: 7116
		public const short YellowHorseshoeBalloon = 1252;

		// Token: 0x04001BCD RID: 7117
		public const short FrozenTurtleShell = 1253;

		// Token: 0x04001BCE RID: 7118
		public const short SniperRifle = 1254;

		// Token: 0x04001BCF RID: 7119
		public const short VenusMagnum = 1255;

		// Token: 0x04001BD0 RID: 7120
		public const short CrimsonRod = 1256;

		// Token: 0x04001BD1 RID: 7121
		public const short CrimtaneBar = 1257;

		// Token: 0x04001BD2 RID: 7122
		public const short Stynger = 1258;

		// Token: 0x04001BD3 RID: 7123
		public const short FlowerPow = 1259;

		// Token: 0x04001BD4 RID: 7124
		public const short RainbowGun = 1260;

		// Token: 0x04001BD5 RID: 7125
		public const short StyngerBolt = 1261;

		// Token: 0x04001BD6 RID: 7126
		public const short ChlorophyteJackhammer = 1262;

		// Token: 0x04001BD7 RID: 7127
		public const short Teleporter = 1263;

		// Token: 0x04001BD8 RID: 7128
		public const short FlowerofFrost = 1264;

		// Token: 0x04001BD9 RID: 7129
		public const short Uzi = 1265;

		// Token: 0x04001BDA RID: 7130
		public const short MagnetSphere = 1266;

		// Token: 0x04001BDB RID: 7131
		public const short PurpleStainedGlass = 1267;

		// Token: 0x04001BDC RID: 7132
		public const short YellowStainedGlass = 1268;

		// Token: 0x04001BDD RID: 7133
		public const short BlueStainedGlass = 1269;

		// Token: 0x04001BDE RID: 7134
		public const short GreenStainedGlass = 1270;

		// Token: 0x04001BDF RID: 7135
		public const short RedStainedGlass = 1271;

		// Token: 0x04001BE0 RID: 7136
		public const short MulticoloredStainedGlass = 1272;

		// Token: 0x04001BE1 RID: 7137
		public const short SkeletronHand = 1273;

		// Token: 0x04001BE2 RID: 7138
		public const short Skull = 1274;

		// Token: 0x04001BE3 RID: 7139
		public const short BallaHat = 1275;

		// Token: 0x04001BE4 RID: 7140
		public const short GangstaHat = 1276;

		// Token: 0x04001BE5 RID: 7141
		public const short SailorHat = 1277;

		// Token: 0x04001BE6 RID: 7142
		public const short EyePatch = 1278;

		// Token: 0x04001BE7 RID: 7143
		public const short SailorShirt = 1279;

		// Token: 0x04001BE8 RID: 7144
		public const short SailorPants = 1280;

		// Token: 0x04001BE9 RID: 7145
		public const short SkeletronMask = 1281;

		// Token: 0x04001BEA RID: 7146
		public const short AmethystRobe = 1282;

		// Token: 0x04001BEB RID: 7147
		public const short TopazRobe = 1283;

		// Token: 0x04001BEC RID: 7148
		public const short SapphireRobe = 1284;

		// Token: 0x04001BED RID: 7149
		public const short EmeraldRobe = 1285;

		// Token: 0x04001BEE RID: 7150
		public const short RubyRobe = 1286;

		// Token: 0x04001BEF RID: 7151
		public const short DiamondRobe = 1287;

		// Token: 0x04001BF0 RID: 7152
		public const short WhiteTuxedoShirt = 1288;

		// Token: 0x04001BF1 RID: 7153
		public const short WhiteTuxedoPants = 1289;

		// Token: 0x04001BF2 RID: 7154
		public const short PanicNecklace = 1290;

		// Token: 0x04001BF3 RID: 7155
		public const short LifeFruit = 1291;

		// Token: 0x04001BF4 RID: 7156
		public const short LihzahrdAltar = 1292;

		// Token: 0x04001BF5 RID: 7157
		public const short LihzahrdPowerCell = 1293;

		// Token: 0x04001BF6 RID: 7158
		public const short Picksaw = 1294;

		// Token: 0x04001BF7 RID: 7159
		public const short HeatRay = 1295;

		// Token: 0x04001BF8 RID: 7160
		public const short StaffofEarth = 1296;

		// Token: 0x04001BF9 RID: 7161
		public const short GolemFist = 1297;

		// Token: 0x04001BFA RID: 7162
		public const short WaterChest = 1298;

		// Token: 0x04001BFB RID: 7163
		public const short Binoculars = 1299;

		// Token: 0x04001BFC RID: 7164
		public const short RifleScope = 1300;

		// Token: 0x04001BFD RID: 7165
		public const short DestroyerEmblem = 1301;

		// Token: 0x04001BFE RID: 7166
		public const short HighVelocityBullet = 1302;

		// Token: 0x04001BFF RID: 7167
		public const short JellyfishNecklace = 1303;

		// Token: 0x04001C00 RID: 7168
		public const short ZombieArm = 1304;

		// Token: 0x04001C01 RID: 7169
		public const short TheAxe = 1305;

		// Token: 0x04001C02 RID: 7170
		public const short IceSickle = 1306;

		// Token: 0x04001C03 RID: 7171
		public const short ClothierVoodooDoll = 1307;

		// Token: 0x04001C04 RID: 7172
		public const short PoisonStaff = 1308;

		// Token: 0x04001C05 RID: 7173
		public const short SlimeStaff = 1309;

		// Token: 0x04001C06 RID: 7174
		public const short PoisonDart = 1310;

		// Token: 0x04001C07 RID: 7175
		public const short EyeSpring = 1311;

		// Token: 0x04001C08 RID: 7176
		public const short ToySled = 1312;

		// Token: 0x04001C09 RID: 7177
		public const short BookofSkulls = 1313;

		// Token: 0x04001C0A RID: 7178
		public const short KOCannon = 1314;

		// Token: 0x04001C0B RID: 7179
		public const short PirateMap = 1315;

		// Token: 0x04001C0C RID: 7180
		public const short TurtleHelmet = 1316;

		// Token: 0x04001C0D RID: 7181
		public const short TurtleScaleMail = 1317;

		// Token: 0x04001C0E RID: 7182
		public const short TurtleLeggings = 1318;

		// Token: 0x04001C0F RID: 7183
		public const short SnowballCannon = 1319;

		// Token: 0x04001C10 RID: 7184
		public const short BonePickaxe = 1320;

		// Token: 0x04001C11 RID: 7185
		public const short MagicQuiver = 1321;

		// Token: 0x04001C12 RID: 7186
		public const short MagmaStone = 1322;

		// Token: 0x04001C13 RID: 7187
		public const short ObsidianRose = 1323;

		// Token: 0x04001C14 RID: 7188
		public const short Bananarang = 1324;

		// Token: 0x04001C15 RID: 7189
		public const short ChainKnife = 1325;

		// Token: 0x04001C16 RID: 7190
		public const short RodofDiscord = 1326;

		// Token: 0x04001C17 RID: 7191
		public const short DeathSickle = 1327;

		// Token: 0x04001C18 RID: 7192
		public const short TurtleShell = 1328;

		// Token: 0x04001C19 RID: 7193
		public const short TissueSample = 1329;

		// Token: 0x04001C1A RID: 7194
		public const short Vertebrae = 1330;

		// Token: 0x04001C1B RID: 7195
		public const short BloodySpine = 1331;

		// Token: 0x04001C1C RID: 7196
		public const short Ichor = 1332;

		// Token: 0x04001C1D RID: 7197
		public const short IchorTorch = 1333;

		// Token: 0x04001C1E RID: 7198
		public const short IchorArrow = 1334;

		// Token: 0x04001C1F RID: 7199
		public const short IchorBullet = 1335;

		// Token: 0x04001C20 RID: 7200
		public const short GoldenShower = 1336;

		// Token: 0x04001C21 RID: 7201
		public const short BunnyCannon = 1337;

		// Token: 0x04001C22 RID: 7202
		public const short ExplosiveBunny = 1338;

		// Token: 0x04001C23 RID: 7203
		public const short VialofVenom = 1339;

		// Token: 0x04001C24 RID: 7204
		public const short FlaskofVenom = 1340;

		// Token: 0x04001C25 RID: 7205
		public const short VenomArrow = 1341;

		// Token: 0x04001C26 RID: 7206
		public const short VenomBullet = 1342;

		// Token: 0x04001C27 RID: 7207
		public const short FireGauntlet = 1343;

		// Token: 0x04001C28 RID: 7208
		public const short Cog = 1344;

		// Token: 0x04001C29 RID: 7209
		public const short Confetti = 1345;

		// Token: 0x04001C2A RID: 7210
		public const short Nanites = 1346;

		// Token: 0x04001C2B RID: 7211
		public const short ExplosivePowder = 1347;

		// Token: 0x04001C2C RID: 7212
		public const short GoldDust = 1348;

		// Token: 0x04001C2D RID: 7213
		public const short PartyBullet = 1349;

		// Token: 0x04001C2E RID: 7214
		public const short NanoBullet = 1350;

		// Token: 0x04001C2F RID: 7215
		public const short ExplodingBullet = 1351;

		// Token: 0x04001C30 RID: 7216
		public const short GoldenBullet = 1352;

		// Token: 0x04001C31 RID: 7217
		public const short FlaskofCursedFlames = 1353;

		// Token: 0x04001C32 RID: 7218
		public const short FlaskofFire = 1354;

		// Token: 0x04001C33 RID: 7219
		public const short FlaskofGold = 1355;

		// Token: 0x04001C34 RID: 7220
		public const short FlaskofIchor = 1356;

		// Token: 0x04001C35 RID: 7221
		public const short FlaskofNanites = 1357;

		// Token: 0x04001C36 RID: 7222
		public const short FlaskofParty = 1358;

		// Token: 0x04001C37 RID: 7223
		public const short FlaskofPoison = 1359;

		// Token: 0x04001C38 RID: 7224
		public const short EyeofCthulhuTrophy = 1360;

		// Token: 0x04001C39 RID: 7225
		public const short EaterofWorldsTrophy = 1361;

		// Token: 0x04001C3A RID: 7226
		public const short BrainofCthulhuTrophy = 1362;

		// Token: 0x04001C3B RID: 7227
		public const short SkeletronTrophy = 1363;

		// Token: 0x04001C3C RID: 7228
		public const short QueenBeeTrophy = 1364;

		// Token: 0x04001C3D RID: 7229
		public const short WallofFleshTrophy = 1365;

		// Token: 0x04001C3E RID: 7230
		public const short DestroyerTrophy = 1366;

		// Token: 0x04001C3F RID: 7231
		public const short SkeletronPrimeTrophy = 1367;

		// Token: 0x04001C40 RID: 7232
		public const short RetinazerTrophy = 1368;

		// Token: 0x04001C41 RID: 7233
		public const short SpazmatismTrophy = 1369;

		// Token: 0x04001C42 RID: 7234
		public const short PlanteraTrophy = 1370;

		// Token: 0x04001C43 RID: 7235
		public const short GolemTrophy = 1371;

		// Token: 0x04001C44 RID: 7236
		public const short BloodMoonRising = 1372;

		// Token: 0x04001C45 RID: 7237
		public const short TheHangedMan = 1373;

		// Token: 0x04001C46 RID: 7238
		public const short GloryoftheFire = 1374;

		// Token: 0x04001C47 RID: 7239
		public const short BoneWarp = 1375;

		// Token: 0x04001C48 RID: 7240
		public const short WallSkeleton = 1376;

		// Token: 0x04001C49 RID: 7241
		public const short HangingSkeleton = 1377;

		// Token: 0x04001C4A RID: 7242
		public const short BlueSlabWall = 1378;

		// Token: 0x04001C4B RID: 7243
		public const short BlueTiledWall = 1379;

		// Token: 0x04001C4C RID: 7244
		public const short PinkSlabWall = 1380;

		// Token: 0x04001C4D RID: 7245
		public const short PinkTiledWall = 1381;

		// Token: 0x04001C4E RID: 7246
		public const short GreenSlabWall = 1382;

		// Token: 0x04001C4F RID: 7247
		public const short GreenTiledWall = 1383;

		// Token: 0x04001C50 RID: 7248
		public const short BlueBrickPlatform = 1384;

		// Token: 0x04001C51 RID: 7249
		public const short PinkBrickPlatform = 1385;

		// Token: 0x04001C52 RID: 7250
		public const short GreenBrickPlatform = 1386;

		// Token: 0x04001C53 RID: 7251
		public const short MetalShelf = 1387;

		// Token: 0x04001C54 RID: 7252
		public const short BrassShelf = 1388;

		// Token: 0x04001C55 RID: 7253
		public const short WoodShelf = 1389;

		// Token: 0x04001C56 RID: 7254
		public const short BrassLantern = 1390;

		// Token: 0x04001C57 RID: 7255
		public const short CagedLantern = 1391;

		// Token: 0x04001C58 RID: 7256
		public const short CarriageLantern = 1392;

		// Token: 0x04001C59 RID: 7257
		public const short AlchemyLantern = 1393;

		// Token: 0x04001C5A RID: 7258
		public const short DiablostLamp = 1394;

		// Token: 0x04001C5B RID: 7259
		public const short OilRagSconse = 1395;

		// Token: 0x04001C5C RID: 7260
		public const short BlueDungeonChair = 1396;

		// Token: 0x04001C5D RID: 7261
		public const short BlueDungeonTable = 1397;

		// Token: 0x04001C5E RID: 7262
		public const short BlueDungeonWorkBench = 1398;

		// Token: 0x04001C5F RID: 7263
		public const short GreenDungeonChair = 1399;

		// Token: 0x04001C60 RID: 7264
		public const short GreenDungeonTable = 1400;

		// Token: 0x04001C61 RID: 7265
		public const short GreenDungeonWorkBench = 1401;

		// Token: 0x04001C62 RID: 7266
		public const short PinkDungeonChair = 1402;

		// Token: 0x04001C63 RID: 7267
		public const short PinkDungeonTable = 1403;

		// Token: 0x04001C64 RID: 7268
		public const short PinkDungeonWorkBench = 1404;

		// Token: 0x04001C65 RID: 7269
		public const short BlueDungeonCandle = 1405;

		// Token: 0x04001C66 RID: 7270
		public const short GreenDungeonCandle = 1406;

		// Token: 0x04001C67 RID: 7271
		public const short PinkDungeonCandle = 1407;

		// Token: 0x04001C68 RID: 7272
		public const short BlueDungeonVase = 1408;

		// Token: 0x04001C69 RID: 7273
		public const short GreenDungeonVase = 1409;

		// Token: 0x04001C6A RID: 7274
		public const short PinkDungeonVase = 1410;

		// Token: 0x04001C6B RID: 7275
		public const short BlueDungeonDoor = 1411;

		// Token: 0x04001C6C RID: 7276
		public const short GreenDungeonDoor = 1412;

		// Token: 0x04001C6D RID: 7277
		public const short PinkDungeonDoor = 1413;

		// Token: 0x04001C6E RID: 7278
		public const short BlueDungeonBookcase = 1414;

		// Token: 0x04001C6F RID: 7279
		public const short GreenDungeonBookcase = 1415;

		// Token: 0x04001C70 RID: 7280
		public const short PinkDungeonBookcase = 1416;

		// Token: 0x04001C71 RID: 7281
		public const short Catacomb = 1417;

		// Token: 0x04001C72 RID: 7282
		public const short DungeonShelf = 1418;

		// Token: 0x04001C73 RID: 7283
		public const short SkellingtonJSkellingsworth = 1419;

		// Token: 0x04001C74 RID: 7284
		public const short TheCursedMan = 1420;

		// Token: 0x04001C75 RID: 7285
		public const short TheEyeSeestheEnd = 1421;

		// Token: 0x04001C76 RID: 7286
		public const short SomethingEvilisWatchingYou = 1422;

		// Token: 0x04001C77 RID: 7287
		public const short TheTwinsHaveAwoken = 1423;

		// Token: 0x04001C78 RID: 7288
		public const short TheScreamer = 1424;

		// Token: 0x04001C79 RID: 7289
		public const short GoblinsPlayingPoker = 1425;

		// Token: 0x04001C7A RID: 7290
		public const short Dryadisque = 1426;

		// Token: 0x04001C7B RID: 7291
		public const short Sunflowers = 1427;

		// Token: 0x04001C7C RID: 7292
		public const short TerrarianGothic = 1428;

		// Token: 0x04001C7D RID: 7293
		public const short Beanie = 1429;

		// Token: 0x04001C7E RID: 7294
		public const short ImbuingStation = 1430;

		// Token: 0x04001C7F RID: 7295
		public const short StarinaBottle = 1431;

		// Token: 0x04001C80 RID: 7296
		public const short EmptyBullet = 1432;

		// Token: 0x04001C81 RID: 7297
		public const short Impact = 1433;

		// Token: 0x04001C82 RID: 7298
		public const short PoweredbyBirds = 1434;

		// Token: 0x04001C83 RID: 7299
		public const short TheDestroyer = 1435;

		// Token: 0x04001C84 RID: 7300
		public const short ThePersistencyofEyes = 1436;

		// Token: 0x04001C85 RID: 7301
		public const short UnicornCrossingtheHallows = 1437;

		// Token: 0x04001C86 RID: 7302
		public const short GreatWave = 1438;

		// Token: 0x04001C87 RID: 7303
		public const short StarryNight = 1439;

		// Token: 0x04001C88 RID: 7304
		public const short GuidePicasso = 1440;

		// Token: 0x04001C89 RID: 7305
		public const short TheGuardiansGaze = 1441;

		// Token: 0x04001C8A RID: 7306
		public const short FatherofSomeone = 1442;

		// Token: 0x04001C8B RID: 7307
		public const short NurseLisa = 1443;

		// Token: 0x04001C8C RID: 7308
		public const short ShadowbeamStaff = 1444;

		// Token: 0x04001C8D RID: 7309
		public const short InfernoFork = 1445;

		// Token: 0x04001C8E RID: 7310
		public const short SpectreStaff = 1446;

		// Token: 0x04001C8F RID: 7311
		public const short WoodenFence = 1447;

		// Token: 0x04001C90 RID: 7312
		public const short LeadFence = 1448;

		// Token: 0x04001C91 RID: 7313
		public const short BubbleMachine = 1449;

		// Token: 0x04001C92 RID: 7314
		public const short BubbleWand = 1450;

		// Token: 0x04001C93 RID: 7315
		public const short MarchingBonesBanner = 1451;

		// Token: 0x04001C94 RID: 7316
		public const short NecromanticSign = 1452;

		// Token: 0x04001C95 RID: 7317
		public const short RustedCompanyStandard = 1453;

		// Token: 0x04001C96 RID: 7318
		public const short RaggedBrotherhoodSigil = 1454;

		// Token: 0x04001C97 RID: 7319
		public const short MoltenLegionFlag = 1455;

		// Token: 0x04001C98 RID: 7320
		public const short DiabolicSigil = 1456;

		// Token: 0x04001C99 RID: 7321
		public const short ObsidianPlatform = 1457;

		// Token: 0x04001C9A RID: 7322
		public const short ObsidianDoor = 1458;

		// Token: 0x04001C9B RID: 7323
		public const short ObsidianChair = 1459;

		// Token: 0x04001C9C RID: 7324
		public const short ObsidianTable = 1460;

		// Token: 0x04001C9D RID: 7325
		public const short ObsidianWorkBench = 1461;

		// Token: 0x04001C9E RID: 7326
		public const short ObsidianVase = 1462;

		// Token: 0x04001C9F RID: 7327
		public const short ObsidianBookcase = 1463;

		// Token: 0x04001CA0 RID: 7328
		public const short HellboundBanner = 1464;

		// Token: 0x04001CA1 RID: 7329
		public const short HellHammerBanner = 1465;

		// Token: 0x04001CA2 RID: 7330
		public const short HelltowerBanner = 1466;

		// Token: 0x04001CA3 RID: 7331
		public const short LostHopesofManBanner = 1467;

		// Token: 0x04001CA4 RID: 7332
		public const short ObsidianWatcherBanner = 1468;

		// Token: 0x04001CA5 RID: 7333
		public const short LavaEruptsBanner = 1469;

		// Token: 0x04001CA6 RID: 7334
		public const short BlueDungeonBed = 1470;

		// Token: 0x04001CA7 RID: 7335
		public const short GreenDungeonBed = 1471;

		// Token: 0x04001CA8 RID: 7336
		public const short PinkDungeonBed = 1472;

		// Token: 0x04001CA9 RID: 7337
		public const short ObsidianBed = 1473;

		// Token: 0x04001CAA RID: 7338
		public const short Waldo = 1474;

		// Token: 0x04001CAB RID: 7339
		public const short Darkness = 1475;

		// Token: 0x04001CAC RID: 7340
		public const short DarkSoulReaper = 1476;

		// Token: 0x04001CAD RID: 7341
		public const short Land = 1477;

		// Token: 0x04001CAE RID: 7342
		public const short TrappedGhost = 1478;

		// Token: 0x04001CAF RID: 7343
		public const short DemonsEye = 1479;

		// Token: 0x04001CB0 RID: 7344
		public const short FindingGold = 1480;

		// Token: 0x04001CB1 RID: 7345
		public const short FirstEncounter = 1481;

		// Token: 0x04001CB2 RID: 7346
		public const short GoodMorning = 1482;

		// Token: 0x04001CB3 RID: 7347
		public const short UndergroundReward = 1483;

		// Token: 0x04001CB4 RID: 7348
		public const short ThroughtheWindow = 1484;

		// Token: 0x04001CB5 RID: 7349
		public const short PlaceAbovetheClouds = 1485;

		// Token: 0x04001CB6 RID: 7350
		public const short DoNotStepontheGrass = 1486;

		// Token: 0x04001CB7 RID: 7351
		public const short ColdWatersintheWhiteLand = 1487;

		// Token: 0x04001CB8 RID: 7352
		public const short LightlessChasms = 1488;

		// Token: 0x04001CB9 RID: 7353
		public const short TheLandofDeceivingLooks = 1489;

		// Token: 0x04001CBA RID: 7354
		public const short Daylight = 1490;

		// Token: 0x04001CBB RID: 7355
		public const short SecretoftheSands = 1491;

		// Token: 0x04001CBC RID: 7356
		public const short DeadlandComesAlive = 1492;

		// Token: 0x04001CBD RID: 7357
		public const short EvilPresence = 1493;

		// Token: 0x04001CBE RID: 7358
		public const short SkyGuardian = 1494;

		// Token: 0x04001CBF RID: 7359
		public const short AmericanExplosive = 1495;

		// Token: 0x04001CC0 RID: 7360
		public const short Discover = 1496;

		// Token: 0x04001CC1 RID: 7361
		public const short HandEarth = 1497;

		// Token: 0x04001CC2 RID: 7362
		public const short OldMiner = 1498;

		// Token: 0x04001CC3 RID: 7363
		public const short Skelehead = 1499;

		// Token: 0x04001CC4 RID: 7364
		public const short FacingtheCerebralMastermind = 1500;

		// Token: 0x04001CC5 RID: 7365
		public const short LakeofFire = 1501;

		// Token: 0x04001CC6 RID: 7366
		public const short TrioSuperHeroes = 1502;

		// Token: 0x04001CC7 RID: 7367
		public const short SpectreHood = 1503;

		// Token: 0x04001CC8 RID: 7368
		public const short SpectreRobe = 1504;

		// Token: 0x04001CC9 RID: 7369
		public const short SpectrePants = 1505;

		// Token: 0x04001CCA RID: 7370
		public const short SpectrePickaxe = 1506;

		// Token: 0x04001CCB RID: 7371
		public const short SpectreHamaxe = 1507;

		// Token: 0x04001CCC RID: 7372
		public const short Ectoplasm = 1508;

		// Token: 0x04001CCD RID: 7373
		public const short GothicChair = 1509;

		// Token: 0x04001CCE RID: 7374
		public const short GothicTable = 1510;

		// Token: 0x04001CCF RID: 7375
		public const short GothicWorkBench = 1511;

		// Token: 0x04001CD0 RID: 7376
		public const short GothicBookcase = 1512;

		// Token: 0x04001CD1 RID: 7377
		public const short PaladinsHammer = 1513;

		// Token: 0x04001CD2 RID: 7378
		public const short SWATHelmet = 1514;

		// Token: 0x04001CD3 RID: 7379
		public const short BeeWings = 1515;

		// Token: 0x04001CD4 RID: 7380
		public const short GiantHarpyFeather = 1516;

		// Token: 0x04001CD5 RID: 7381
		public const short BoneFeather = 1517;

		// Token: 0x04001CD6 RID: 7382
		public const short FireFeather = 1518;

		// Token: 0x04001CD7 RID: 7383
		public const short IceFeather = 1519;

		// Token: 0x04001CD8 RID: 7384
		public const short BrokenBatWing = 1520;

		// Token: 0x04001CD9 RID: 7385
		public const short TatteredBeeWing = 1521;

		// Token: 0x04001CDA RID: 7386
		public const short LargeAmethyst = 1522;

		// Token: 0x04001CDB RID: 7387
		public const short LargeTopaz = 1523;

		// Token: 0x04001CDC RID: 7388
		public const short LargeSapphire = 1524;

		// Token: 0x04001CDD RID: 7389
		public const short LargeEmerald = 1525;

		// Token: 0x04001CDE RID: 7390
		public const short LargeRuby = 1526;

		// Token: 0x04001CDF RID: 7391
		public const short LargeDiamond = 1527;

		// Token: 0x04001CE0 RID: 7392
		public const short JungleChest = 1528;

		// Token: 0x04001CE1 RID: 7393
		public const short CorruptionChest = 1529;

		// Token: 0x04001CE2 RID: 7394
		public const short CrimsonChest = 1530;

		// Token: 0x04001CE3 RID: 7395
		public const short HallowedChest = 1531;

		// Token: 0x04001CE4 RID: 7396
		public const short FrozenChest = 1532;

		// Token: 0x04001CE5 RID: 7397
		public const short JungleKey = 1533;

		// Token: 0x04001CE6 RID: 7398
		public const short CorruptionKey = 1534;

		// Token: 0x04001CE7 RID: 7399
		public const short CrimsonKey = 1535;

		// Token: 0x04001CE8 RID: 7400
		public const short HallowedKey = 1536;

		// Token: 0x04001CE9 RID: 7401
		public const short FrozenKey = 1537;

		// Token: 0x04001CEA RID: 7402
		public const short ImpFace = 1538;

		// Token: 0x04001CEB RID: 7403
		public const short OminousPresence = 1539;

		// Token: 0x04001CEC RID: 7404
		public const short ShiningMoon = 1540;

		// Token: 0x04001CED RID: 7405
		public const short LivingGore = 1541;

		// Token: 0x04001CEE RID: 7406
		public const short FlowingMagma = 1542;

		// Token: 0x04001CEF RID: 7407
		public const short SpectrePaintbrush = 1543;

		// Token: 0x04001CF0 RID: 7408
		public const short SpectrePaintRoller = 1544;

		// Token: 0x04001CF1 RID: 7409
		public const short SpectrePaintScraper = 1545;

		// Token: 0x04001CF2 RID: 7410
		public const short ShroomiteHeadgear = 1546;

		// Token: 0x04001CF3 RID: 7411
		public const short ShroomiteMask = 1547;

		// Token: 0x04001CF4 RID: 7412
		public const short ShroomiteHelmet = 1548;

		// Token: 0x04001CF5 RID: 7413
		public const short ShroomiteBreastplate = 1549;

		// Token: 0x04001CF6 RID: 7414
		public const short ShroomiteLeggings = 1550;

		// Token: 0x04001CF7 RID: 7415
		public const short Autohammer = 1551;

		// Token: 0x04001CF8 RID: 7416
		public const short ShroomiteBar = 1552;

		// Token: 0x04001CF9 RID: 7417
		public const short SDMG = 1553;

		// Token: 0x04001CFA RID: 7418
		public const short CenxsTiara = 1554;

		// Token: 0x04001CFB RID: 7419
		public const short CenxsBreastplate = 1555;

		// Token: 0x04001CFC RID: 7420
		public const short CenxsLeggings = 1556;

		// Token: 0x04001CFD RID: 7421
		public const short CrownosMask = 1557;

		// Token: 0x04001CFE RID: 7422
		public const short CrownosBreastplate = 1558;

		// Token: 0x04001CFF RID: 7423
		public const short CrownosLeggings = 1559;

		// Token: 0x04001D00 RID: 7424
		public const short WillsHelmet = 1560;

		// Token: 0x04001D01 RID: 7425
		public const short WillsBreastplate = 1561;

		// Token: 0x04001D02 RID: 7426
		public const short WillsLeggings = 1562;

		// Token: 0x04001D03 RID: 7427
		public const short JimsHelmet = 1563;

		// Token: 0x04001D04 RID: 7428
		public const short JimsBreastplate = 1564;

		// Token: 0x04001D05 RID: 7429
		public const short JimsLeggings = 1565;

		// Token: 0x04001D06 RID: 7430
		public const short AaronsHelmet = 1566;

		// Token: 0x04001D07 RID: 7431
		public const short AaronsBreastplate = 1567;

		// Token: 0x04001D08 RID: 7432
		public const short AaronsLeggings = 1568;

		// Token: 0x04001D09 RID: 7433
		public const short VampireKnives = 1569;

		// Token: 0x04001D0A RID: 7434
		public const short BrokenHeroSword = 1570;

		// Token: 0x04001D0B RID: 7435
		public const short ScourgeoftheCorruptor = 1571;

		// Token: 0x04001D0C RID: 7436
		public const short StaffoftheFrostHydra = 1572;

		// Token: 0x04001D0D RID: 7437
		public const short TheCreationoftheGuide = 1573;

		// Token: 0x04001D0E RID: 7438
		public const short TheMerchant = 1574;

		// Token: 0x04001D0F RID: 7439
		public const short CrownoDevoursHisLunch = 1575;

		// Token: 0x04001D10 RID: 7440
		public const short RareEnchantment = 1576;

		// Token: 0x04001D11 RID: 7441
		public const short GloriousNight = 1577;

		// Token: 0x04001D12 RID: 7442
		public const short SweetheartNecklace = 1578;

		// Token: 0x04001D13 RID: 7443
		public const short FlurryBoots = 1579;

		// Token: 0x04001D14 RID: 7444
		public const short DTownsHelmet = 1580;

		// Token: 0x04001D15 RID: 7445
		public const short DTownsBreastplate = 1581;

		// Token: 0x04001D16 RID: 7446
		public const short DTownsLeggings = 1582;

		// Token: 0x04001D17 RID: 7447
		public const short DTownsWings = 1583;

		// Token: 0x04001D18 RID: 7448
		public const short WillsWings = 1584;

		// Token: 0x04001D19 RID: 7449
		public const short CrownosWings = 1585;

		// Token: 0x04001D1A RID: 7450
		public const short CenxsWings = 1586;

		// Token: 0x04001D1B RID: 7451
		public const short CenxsDress = 1587;

		// Token: 0x04001D1C RID: 7452
		public const short CenxsDressPants = 1588;

		// Token: 0x04001D1D RID: 7453
		public const short PalladiumColumn = 1589;

		// Token: 0x04001D1E RID: 7454
		public const short PalladiumColumnWall = 1590;

		// Token: 0x04001D1F RID: 7455
		public const short BubblegumBlock = 1591;

		// Token: 0x04001D20 RID: 7456
		public const short BubblegumBlockWall = 1592;

		// Token: 0x04001D21 RID: 7457
		public const short TitanstoneBlock = 1593;

		// Token: 0x04001D22 RID: 7458
		public const short TitanstoneBlockWall = 1594;

		// Token: 0x04001D23 RID: 7459
		public const short MagicCuffs = 1595;

		// Token: 0x04001D24 RID: 7460
		public const short MusicBoxSnow = 1596;

		// Token: 0x04001D25 RID: 7461
		public const short MusicBoxSpace = 1597;

		// Token: 0x04001D26 RID: 7462
		public const short MusicBoxCrimson = 1598;

		// Token: 0x04001D27 RID: 7463
		public const short MusicBoxBoss4 = 1599;

		// Token: 0x04001D28 RID: 7464
		public const short MusicBoxAltOverworldDay = 1600;

		// Token: 0x04001D29 RID: 7465
		public const short MusicBoxRain = 1601;

		// Token: 0x04001D2A RID: 7466
		public const short MusicBoxIce = 1602;

		// Token: 0x04001D2B RID: 7467
		public const short MusicBoxDesert = 1603;

		// Token: 0x04001D2C RID: 7468
		public const short MusicBoxOcean = 1604;

		// Token: 0x04001D2D RID: 7469
		public const short MusicBoxDungeon = 1605;

		// Token: 0x04001D2E RID: 7470
		public const short MusicBoxPlantera = 1606;

		// Token: 0x04001D2F RID: 7471
		public const short MusicBoxBoss5 = 1607;

		// Token: 0x04001D30 RID: 7472
		public const short MusicBoxTemple = 1608;

		// Token: 0x04001D31 RID: 7473
		public const short MusicBoxEclipse = 1609;

		// Token: 0x04001D32 RID: 7474
		public const short MusicBoxMushrooms = 1610;

		// Token: 0x04001D33 RID: 7475
		public const short ButterflyDust = 1611;

		// Token: 0x04001D34 RID: 7476
		public const short AnkhCharm = 1612;

		// Token: 0x04001D35 RID: 7477
		public const short AnkhShield = 1613;

		// Token: 0x04001D36 RID: 7478
		public const short BlueFlare = 1614;

		// Token: 0x04001D37 RID: 7479
		public const short AnglerFishBanner = 1615;

		// Token: 0x04001D38 RID: 7480
		public const short AngryNimbusBanner = 1616;

		// Token: 0x04001D39 RID: 7481
		public const short AnomuraFungusBanner = 1617;

		// Token: 0x04001D3A RID: 7482
		public const short AntlionBanner = 1618;

		// Token: 0x04001D3B RID: 7483
		public const short ArapaimaBanner = 1619;

		// Token: 0x04001D3C RID: 7484
		public const short ArmoredSkeletonBanner = 1620;

		// Token: 0x04001D3D RID: 7485
		public const short BatBanner = 1621;

		// Token: 0x04001D3E RID: 7486
		public const short BirdBanner = 1622;

		// Token: 0x04001D3F RID: 7487
		public const short BlackRecluseBanner = 1623;

		// Token: 0x04001D40 RID: 7488
		public const short BloodFeederBanner = 1624;

		// Token: 0x04001D41 RID: 7489
		public const short BloodJellyBanner = 1625;

		// Token: 0x04001D42 RID: 7490
		public const short BloodCrawlerBanner = 1626;

		// Token: 0x04001D43 RID: 7491
		public const short BoneSerpentBanner = 1627;

		// Token: 0x04001D44 RID: 7492
		public const short BunnyBanner = 1628;

		// Token: 0x04001D45 RID: 7493
		public const short ChaosElementalBanner = 1629;

		// Token: 0x04001D46 RID: 7494
		public const short MimicBanner = 1630;

		// Token: 0x04001D47 RID: 7495
		public const short ClownBanner = 1631;

		// Token: 0x04001D48 RID: 7496
		public const short CorruptBunnyBanner = 1632;

		// Token: 0x04001D49 RID: 7497
		public const short CorruptGoldfishBanner = 1633;

		// Token: 0x04001D4A RID: 7498
		public const short CrabBanner = 1634;

		// Token: 0x04001D4B RID: 7499
		public const short CrimeraBanner = 1635;

		// Token: 0x04001D4C RID: 7500
		public const short CrimsonAxeBanner = 1636;

		// Token: 0x04001D4D RID: 7501
		public const short CursedHammerBanner = 1637;

		// Token: 0x04001D4E RID: 7502
		public const short DemonBanner = 1638;

		// Token: 0x04001D4F RID: 7503
		public const short DemonEyeBanner = 1639;

		// Token: 0x04001D50 RID: 7504
		public const short DerplingBanner = 1640;

		// Token: 0x04001D51 RID: 7505
		public const short EaterofSoulsBanner = 1641;

		// Token: 0x04001D52 RID: 7506
		public const short EnchantedSwordBanner = 1642;

		// Token: 0x04001D53 RID: 7507
		public const short ZombieEskimoBanner = 1643;

		// Token: 0x04001D54 RID: 7508
		public const short FaceMonsterBanner = 1644;

		// Token: 0x04001D55 RID: 7509
		public const short FloatyGrossBanner = 1645;

		// Token: 0x04001D56 RID: 7510
		public const short FlyingFishBanner = 1646;

		// Token: 0x04001D57 RID: 7511
		public const short FlyingSnakeBanner = 1647;

		// Token: 0x04001D58 RID: 7512
		public const short FrankensteinBanner = 1648;

		// Token: 0x04001D59 RID: 7513
		public const short FungiBulbBanner = 1649;

		// Token: 0x04001D5A RID: 7514
		public const short FungoFishBanner = 1650;

		// Token: 0x04001D5B RID: 7515
		public const short GastropodBanner = 1651;

		// Token: 0x04001D5C RID: 7516
		public const short GoblinThiefBanner = 1652;

		// Token: 0x04001D5D RID: 7517
		public const short GoblinSorcererBanner = 1653;

		// Token: 0x04001D5E RID: 7518
		public const short GoblinPeonBanner = 1654;

		// Token: 0x04001D5F RID: 7519
		public const short GoblinScoutBanner = 1655;

		// Token: 0x04001D60 RID: 7520
		public const short GoblinWarriorBanner = 1656;

		// Token: 0x04001D61 RID: 7521
		public const short GoldfishBanner = 1657;

		// Token: 0x04001D62 RID: 7522
		public const short HarpyBanner = 1658;

		// Token: 0x04001D63 RID: 7523
		public const short HellbatBanner = 1659;

		// Token: 0x04001D64 RID: 7524
		public const short HerplingBanner = 1660;

		// Token: 0x04001D65 RID: 7525
		public const short HornetBanner = 1661;

		// Token: 0x04001D66 RID: 7526
		public const short IceElementalBanner = 1662;

		// Token: 0x04001D67 RID: 7527
		public const short IcyMermanBanner = 1663;

		// Token: 0x04001D68 RID: 7528
		public const short FireImpBanner = 1664;

		// Token: 0x04001D69 RID: 7529
		public const short JellyfishBanner = 1665;

		// Token: 0x04001D6A RID: 7530
		public const short JungleCreeperBanner = 1666;

		// Token: 0x04001D6B RID: 7531
		public const short LihzahrdBanner = 1667;

		// Token: 0x04001D6C RID: 7532
		public const short ManEaterBanner = 1668;

		// Token: 0x04001D6D RID: 7533
		public const short MeteorHeadBanner = 1669;

		// Token: 0x04001D6E RID: 7534
		public const short MothBanner = 1670;

		// Token: 0x04001D6F RID: 7535
		public const short MummyBanner = 1671;

		// Token: 0x04001D70 RID: 7536
		public const short MushiLadybugBanner = 1672;

		// Token: 0x04001D71 RID: 7537
		public const short ParrotBanner = 1673;

		// Token: 0x04001D72 RID: 7538
		public const short PigronBanner = 1674;

		// Token: 0x04001D73 RID: 7539
		public const short PiranhaBanner = 1675;

		// Token: 0x04001D74 RID: 7540
		public const short PirateBanner = 1676;

		// Token: 0x04001D75 RID: 7541
		public const short PixieBanner = 1677;

		// Token: 0x04001D76 RID: 7542
		public const short RaincoatZombieBanner = 1678;

		// Token: 0x04001D77 RID: 7543
		public const short ReaperBanner = 1679;

		// Token: 0x04001D78 RID: 7544
		public const short SharkBanner = 1680;

		// Token: 0x04001D79 RID: 7545
		public const short SkeletonBanner = 1681;

		// Token: 0x04001D7A RID: 7546
		public const short SkeletonMageBanner = 1682;

		// Token: 0x04001D7B RID: 7547
		public const short SlimeBanner = 1683;

		// Token: 0x04001D7C RID: 7548
		public const short SnowFlinxBanner = 1684;

		// Token: 0x04001D7D RID: 7549
		public const short SpiderBanner = 1685;

		// Token: 0x04001D7E RID: 7550
		public const short SporeZombieBanner = 1686;

		// Token: 0x04001D7F RID: 7551
		public const short SwampThingBanner = 1687;

		// Token: 0x04001D80 RID: 7552
		public const short TortoiseBanner = 1688;

		// Token: 0x04001D81 RID: 7553
		public const short ToxicSludgeBanner = 1689;

		// Token: 0x04001D82 RID: 7554
		public const short UmbrellaSlimeBanner = 1690;

		// Token: 0x04001D83 RID: 7555
		public const short UnicornBanner = 1691;

		// Token: 0x04001D84 RID: 7556
		public const short VampireBanner = 1692;

		// Token: 0x04001D85 RID: 7557
		public const short VultureBanner = 1693;

		// Token: 0x04001D86 RID: 7558
		public const short NypmhBanner = 1694;

		// Token: 0x04001D87 RID: 7559
		public const short WerewolfBanner = 1695;

		// Token: 0x04001D88 RID: 7560
		public const short WolfBanner = 1696;

		// Token: 0x04001D89 RID: 7561
		public const short WorldFeederBanner = 1697;

		// Token: 0x04001D8A RID: 7562
		public const short WormBanner = 1698;

		// Token: 0x04001D8B RID: 7563
		public const short WraithBanner = 1699;

		// Token: 0x04001D8C RID: 7564
		public const short WyvernBanner = 1700;

		// Token: 0x04001D8D RID: 7565
		public const short ZombieBanner = 1701;

		// Token: 0x04001D8E RID: 7566
		public const short GlassPlatform = 1702;

		// Token: 0x04001D8F RID: 7567
		public const short GlassChair = 1703;

		// Token: 0x04001D90 RID: 7568
		public const short GoldenChair = 1704;

		// Token: 0x04001D91 RID: 7569
		public const short GoldenToilet = 1705;

		// Token: 0x04001D92 RID: 7570
		public const short BarStool = 1706;

		// Token: 0x04001D93 RID: 7571
		public const short HoneyChair = 1707;

		// Token: 0x04001D94 RID: 7572
		public const short SteampunkChair = 1708;

		// Token: 0x04001D95 RID: 7573
		public const short GlassDoor = 1709;

		// Token: 0x04001D96 RID: 7574
		public const short GoldenDoor = 1710;

		// Token: 0x04001D97 RID: 7575
		public const short HoneyDoor = 1711;

		// Token: 0x04001D98 RID: 7576
		public const short SteampunkDoor = 1712;

		// Token: 0x04001D99 RID: 7577
		public const short GlassTable = 1713;

		// Token: 0x04001D9A RID: 7578
		public const short BanquetTable = 1714;

		// Token: 0x04001D9B RID: 7579
		public const short Bar = 1715;

		// Token: 0x04001D9C RID: 7580
		public const short GoldenTable = 1716;

		// Token: 0x04001D9D RID: 7581
		public const short HoneyTable = 1717;

		// Token: 0x04001D9E RID: 7582
		public const short SteampunkTable = 1718;

		// Token: 0x04001D9F RID: 7583
		public const short GlassBed = 1719;

		// Token: 0x04001DA0 RID: 7584
		public const short GoldenBed = 1720;

		// Token: 0x04001DA1 RID: 7585
		public const short HoneyBed = 1721;

		// Token: 0x04001DA2 RID: 7586
		public const short SteampunkBed = 1722;

		// Token: 0x04001DA3 RID: 7587
		public const short LivingWoodWall = 1723;

		// Token: 0x04001DA4 RID: 7588
		public const short FartinaJar = 1724;

		// Token: 0x04001DA5 RID: 7589
		public const short Pumpkin = 1725;

		// Token: 0x04001DA6 RID: 7590
		public const short PumpkinWall = 1726;

		// Token: 0x04001DA7 RID: 7591
		public const short Hay = 1727;

		// Token: 0x04001DA8 RID: 7592
		public const short HayWall = 1728;

		// Token: 0x04001DA9 RID: 7593
		public const short SpookyWood = 1729;

		// Token: 0x04001DAA RID: 7594
		public const short SpookyWoodWall = 1730;

		// Token: 0x04001DAB RID: 7595
		public const short PumpkinHelmet = 1731;

		// Token: 0x04001DAC RID: 7596
		public const short PumpkinBreastplate = 1732;

		// Token: 0x04001DAD RID: 7597
		public const short PumpkinLeggings = 1733;

		// Token: 0x04001DAE RID: 7598
		public const short CandyApple = 1734;

		// Token: 0x04001DAF RID: 7599
		public const short SoulCake = 1735;

		// Token: 0x04001DB0 RID: 7600
		public const short NurseHat = 1736;

		// Token: 0x04001DB1 RID: 7601
		public const short NurseShirt = 1737;

		// Token: 0x04001DB2 RID: 7602
		public const short NursePants = 1738;

		// Token: 0x04001DB3 RID: 7603
		public const short WizardsHat = 1739;

		// Token: 0x04001DB4 RID: 7604
		public const short GuyFawkesMask = 1740;

		// Token: 0x04001DB5 RID: 7605
		public const short DyeTraderRobe = 1741;

		// Token: 0x04001DB6 RID: 7606
		public const short SteampunkGoggles = 1742;

		// Token: 0x04001DB7 RID: 7607
		public const short CyborgHelmet = 1743;

		// Token: 0x04001DB8 RID: 7608
		public const short CyborgShirt = 1744;

		// Token: 0x04001DB9 RID: 7609
		public const short CyborgPants = 1745;

		// Token: 0x04001DBA RID: 7610
		public const short CreeperMask = 1746;

		// Token: 0x04001DBB RID: 7611
		public const short CreeperShirt = 1747;

		// Token: 0x04001DBC RID: 7612
		public const short CreeperPants = 1748;

		// Token: 0x04001DBD RID: 7613
		public const short CatMask = 1749;

		// Token: 0x04001DBE RID: 7614
		public const short CatShirt = 1750;

		// Token: 0x04001DBF RID: 7615
		public const short CatPants = 1751;

		// Token: 0x04001DC0 RID: 7616
		public const short GhostMask = 1752;

		// Token: 0x04001DC1 RID: 7617
		public const short GhostShirt = 1753;

		// Token: 0x04001DC2 RID: 7618
		public const short PumpkinMask = 1754;

		// Token: 0x04001DC3 RID: 7619
		public const short PumpkinShirt = 1755;

		// Token: 0x04001DC4 RID: 7620
		public const short PumpkinPants = 1756;

		// Token: 0x04001DC5 RID: 7621
		public const short RobotMask = 1757;

		// Token: 0x04001DC6 RID: 7622
		public const short RobotShirt = 1758;

		// Token: 0x04001DC7 RID: 7623
		public const short RobotPants = 1759;

		// Token: 0x04001DC8 RID: 7624
		public const short UnicornMask = 1760;

		// Token: 0x04001DC9 RID: 7625
		public const short UnicornShirt = 1761;

		// Token: 0x04001DCA RID: 7626
		public const short UnicornPants = 1762;

		// Token: 0x04001DCB RID: 7627
		public const short VampireMask = 1763;

		// Token: 0x04001DCC RID: 7628
		public const short VampireShirt = 1764;

		// Token: 0x04001DCD RID: 7629
		public const short VampirePants = 1765;

		// Token: 0x04001DCE RID: 7630
		public const short WitchHat = 1766;

		// Token: 0x04001DCF RID: 7631
		public const short LeprechaunHat = 1767;

		// Token: 0x04001DD0 RID: 7632
		public const short LeprechaunShirt = 1768;

		// Token: 0x04001DD1 RID: 7633
		public const short LeprechaunPants = 1769;

		// Token: 0x04001DD2 RID: 7634
		public const short PixieShirt = 1770;

		// Token: 0x04001DD3 RID: 7635
		public const short PixiePants = 1771;

		// Token: 0x04001DD4 RID: 7636
		public const short PrincessHat = 1772;

		// Token: 0x04001DD5 RID: 7637
		public const short PrincessDressNew = 1773;

		// Token: 0x04001DD6 RID: 7638
		public const short GoodieBag = 1774;

		// Token: 0x04001DD7 RID: 7639
		public const short WitchDress = 1775;

		// Token: 0x04001DD8 RID: 7640
		public const short WitchBoots = 1776;

		// Token: 0x04001DD9 RID: 7641
		public const short BrideofFrankensteinMask = 1777;

		// Token: 0x04001DDA RID: 7642
		public const short BrideofFrankensteinDress = 1778;

		// Token: 0x04001DDB RID: 7643
		public const short KarateTortoiseMask = 1779;

		// Token: 0x04001DDC RID: 7644
		public const short KarateTortoiseShirt = 1780;

		// Token: 0x04001DDD RID: 7645
		public const short KarateTortoisePants = 1781;

		// Token: 0x04001DDE RID: 7646
		public const short CandyCornRifle = 1782;

		// Token: 0x04001DDF RID: 7647
		public const short CandyCorn = 1783;

		// Token: 0x04001DE0 RID: 7648
		public const short JackOLanternLauncher = 1784;

		// Token: 0x04001DE1 RID: 7649
		public const short ExplosiveJackOLantern = 1785;

		// Token: 0x04001DE2 RID: 7650
		public const short Sickle = 1786;

		// Token: 0x04001DE3 RID: 7651
		public const short PumpkinPie = 1787;

		// Token: 0x04001DE4 RID: 7652
		public const short ScarecrowHat = 1788;

		// Token: 0x04001DE5 RID: 7653
		public const short ScarecrowShirt = 1789;

		// Token: 0x04001DE6 RID: 7654
		public const short ScarecrowPants = 1790;

		// Token: 0x04001DE7 RID: 7655
		public const short Cauldron = 1791;

		// Token: 0x04001DE8 RID: 7656
		public const short PumpkinChair = 1792;

		// Token: 0x04001DE9 RID: 7657
		public const short PumpkinDoor = 1793;

		// Token: 0x04001DEA RID: 7658
		public const short PumpkinTable = 1794;

		// Token: 0x04001DEB RID: 7659
		public const short PumpkinWorkBench = 1795;

		// Token: 0x04001DEC RID: 7660
		public const short PumpkinPlatform = 1796;

		// Token: 0x04001DED RID: 7661
		public const short TatteredFairyWings = 1797;

		// Token: 0x04001DEE RID: 7662
		public const short SpiderEgg = 1798;

		// Token: 0x04001DEF RID: 7663
		public const short MagicalPumpkinSeed = 1799;

		// Token: 0x04001DF0 RID: 7664
		public const short BatHook = 1800;

		// Token: 0x04001DF1 RID: 7665
		public const short BatScepter = 1801;

		// Token: 0x04001DF2 RID: 7666
		public const short RavenStaff = 1802;

		// Token: 0x04001DF3 RID: 7667
		public const short JungleKeyMold = 1803;

		// Token: 0x04001DF4 RID: 7668
		public const short CorruptionKeyMold = 1804;

		// Token: 0x04001DF5 RID: 7669
		public const short CrimsonKeyMold = 1805;

		// Token: 0x04001DF6 RID: 7670
		public const short HallowedKeyMold = 1806;

		// Token: 0x04001DF7 RID: 7671
		public const short FrozenKeyMold = 1807;

		// Token: 0x04001DF8 RID: 7672
		public const short HangingJackOLantern = 1808;

		// Token: 0x04001DF9 RID: 7673
		public const short RottenEgg = 1809;

		// Token: 0x04001DFA RID: 7674
		public const short UnluckyYarn = 1810;

		// Token: 0x04001DFB RID: 7675
		public const short BlackFairyDust = 1811;

		// Token: 0x04001DFC RID: 7676
		public const short Jackelier = 1812;

		// Token: 0x04001DFD RID: 7677
		public const short JackOLantern = 1813;

		// Token: 0x04001DFE RID: 7678
		public const short SpookyChair = 1814;

		// Token: 0x04001DFF RID: 7679
		public const short SpookyDoor = 1815;

		// Token: 0x04001E00 RID: 7680
		public const short SpookyTable = 1816;

		// Token: 0x04001E01 RID: 7681
		public const short SpookyWorkBench = 1817;

		// Token: 0x04001E02 RID: 7682
		public const short SpookyPlatform = 1818;

		// Token: 0x04001E03 RID: 7683
		public const short ReaperHood = 1819;

		// Token: 0x04001E04 RID: 7684
		public const short ReaperRobe = 1820;

		// Token: 0x04001E05 RID: 7685
		public const short FoxMask = 1821;

		// Token: 0x04001E06 RID: 7686
		public const short FoxShirt = 1822;

		// Token: 0x04001E07 RID: 7687
		public const short FoxPants = 1823;

		// Token: 0x04001E08 RID: 7688
		public const short CatEars = 1824;

		// Token: 0x04001E09 RID: 7689
		public const short BloodyMachete = 1825;

		// Token: 0x04001E0A RID: 7690
		public const short TheHorsemansBlade = 1826;

		// Token: 0x04001E0B RID: 7691
		public const short BladedGlove = 1827;

		// Token: 0x04001E0C RID: 7692
		public const short PumpkinSeed = 1828;

		// Token: 0x04001E0D RID: 7693
		public const short SpookyHook = 1829;

		// Token: 0x04001E0E RID: 7694
		public const short SpookyWings = 1830;

		// Token: 0x04001E0F RID: 7695
		public const short SpookyTwig = 1831;

		// Token: 0x04001E10 RID: 7696
		public const short SpookyHelmet = 1832;

		// Token: 0x04001E11 RID: 7697
		public const short SpookyBreastplate = 1833;

		// Token: 0x04001E12 RID: 7698
		public const short SpookyLeggings = 1834;

		// Token: 0x04001E13 RID: 7699
		public const short StakeLauncher = 1835;

		// Token: 0x04001E14 RID: 7700
		public const short Stake = 1836;

		// Token: 0x04001E15 RID: 7701
		public const short CursedSapling = 1837;

		// Token: 0x04001E16 RID: 7702
		public const short SpaceCreatureMask = 1838;

		// Token: 0x04001E17 RID: 7703
		public const short SpaceCreatureShirt = 1839;

		// Token: 0x04001E18 RID: 7704
		public const short SpaceCreaturePants = 1840;

		// Token: 0x04001E19 RID: 7705
		public const short WolfMask = 1841;

		// Token: 0x04001E1A RID: 7706
		public const short WolfShirt = 1842;

		// Token: 0x04001E1B RID: 7707
		public const short WolfPants = 1843;

		// Token: 0x04001E1C RID: 7708
		public const short PumpkinMoonMedallion = 1844;

		// Token: 0x04001E1D RID: 7709
		public const short NecromanticScroll = 1845;

		// Token: 0x04001E1E RID: 7710
		public const short JackingSkeletron = 1846;

		// Token: 0x04001E1F RID: 7711
		public const short BitterHarvest = 1847;

		// Token: 0x04001E20 RID: 7712
		public const short BloodMoonCountess = 1848;

		// Token: 0x04001E21 RID: 7713
		public const short HallowsEve = 1849;

		// Token: 0x04001E22 RID: 7714
		public const short MorbidCuriosity = 1850;

		// Token: 0x04001E23 RID: 7715
		public const short TreasureHunterShirt = 1851;

		// Token: 0x04001E24 RID: 7716
		public const short TreasureHunterPants = 1852;

		// Token: 0x04001E25 RID: 7717
		public const short DryadCoverings = 1853;

		// Token: 0x04001E26 RID: 7718
		public const short DryadLoincloth = 1854;

		// Token: 0x04001E27 RID: 7719
		public const short MourningWoodTrophy = 1855;

		// Token: 0x04001E28 RID: 7720
		public const short PumpkingTrophy = 1856;

		// Token: 0x04001E29 RID: 7721
		public const short JackOLanternMask = 1857;

		// Token: 0x04001E2A RID: 7722
		public const short SniperScope = 1858;

		// Token: 0x04001E2B RID: 7723
		public const short HeartLantern = 1859;

		// Token: 0x04001E2C RID: 7724
		public const short JellyfishDivingGear = 1860;

		// Token: 0x04001E2D RID: 7725
		public const short ArcticDivingGear = 1861;

		// Token: 0x04001E2E RID: 7726
		public const short FrostsparkBoots = 1862;

		// Token: 0x04001E2F RID: 7727
		public const short FartInABalloon = 1863;

		// Token: 0x04001E30 RID: 7728
		public const short PapyrusScarab = 1864;

		// Token: 0x04001E31 RID: 7729
		public const short CelestialStone = 1865;

		// Token: 0x04001E32 RID: 7730
		public const short Hoverboard = 1866;

		// Token: 0x04001E33 RID: 7731
		public const short CandyCane = 1867;

		// Token: 0x04001E34 RID: 7732
		public const short SugarPlum = 1868;

		// Token: 0x04001E35 RID: 7733
		public const short Present = 1869;

		// Token: 0x04001E36 RID: 7734
		public const short RedRyder = 1870;

		// Token: 0x04001E37 RID: 7735
		public const short FestiveWings = 1871;

		// Token: 0x04001E38 RID: 7736
		public const short PineTreeBlock = 1872;

		// Token: 0x04001E39 RID: 7737
		public const short ChristmasTree = 1873;

		// Token: 0x04001E3A RID: 7738
		public const short StarTopper1 = 1874;

		// Token: 0x04001E3B RID: 7739
		public const short StarTopper2 = 1875;

		// Token: 0x04001E3C RID: 7740
		public const short StarTopper3 = 1876;

		// Token: 0x04001E3D RID: 7741
		public const short BowTopper = 1877;

		// Token: 0x04001E3E RID: 7742
		public const short WhiteGarland = 1878;

		// Token: 0x04001E3F RID: 7743
		public const short WhiteAndRedGarland = 1879;

		// Token: 0x04001E40 RID: 7744
		public const short RedGardland = 1880;

		// Token: 0x04001E41 RID: 7745
		public const short RedAndGreenGardland = 1881;

		// Token: 0x04001E42 RID: 7746
		public const short GreenGardland = 1882;

		// Token: 0x04001E43 RID: 7747
		public const short GreenAndWhiteGarland = 1883;

		// Token: 0x04001E44 RID: 7748
		public const short MulticoloredBulb = 1884;

		// Token: 0x04001E45 RID: 7749
		public const short RedBulb = 1885;

		// Token: 0x04001E46 RID: 7750
		public const short YellowBulb = 1886;

		// Token: 0x04001E47 RID: 7751
		public const short GreenBulb = 1887;

		// Token: 0x04001E48 RID: 7752
		public const short RedAndGreenBulb = 1888;

		// Token: 0x04001E49 RID: 7753
		public const short YellowAndGreenBulb = 1889;

		// Token: 0x04001E4A RID: 7754
		public const short RedAndYellowBulb = 1890;

		// Token: 0x04001E4B RID: 7755
		public const short WhiteBulb = 1891;

		// Token: 0x04001E4C RID: 7756
		public const short WhiteAndRedBulb = 1892;

		// Token: 0x04001E4D RID: 7757
		public const short WhiteAndYellowBulb = 1893;

		// Token: 0x04001E4E RID: 7758
		public const short WhiteAndGreenBulb = 1894;

		// Token: 0x04001E4F RID: 7759
		public const short MulticoloredLights = 1895;

		// Token: 0x04001E50 RID: 7760
		public const short RedLights = 1896;

		// Token: 0x04001E51 RID: 7761
		public const short GreenLights = 1897;

		// Token: 0x04001E52 RID: 7762
		public const short BlueLights = 1898;

		// Token: 0x04001E53 RID: 7763
		public const short YellowLights = 1899;

		// Token: 0x04001E54 RID: 7764
		public const short RedAndYellowLights = 1900;

		// Token: 0x04001E55 RID: 7765
		public const short RedAndGreenLights = 1901;

		// Token: 0x04001E56 RID: 7766
		public const short YellowAndGreenLights = 1902;

		// Token: 0x04001E57 RID: 7767
		public const short BlueAndGreenLights = 1903;

		// Token: 0x04001E58 RID: 7768
		public const short RedAndBlueLights = 1904;

		// Token: 0x04001E59 RID: 7769
		public const short BlueAndYellowLights = 1905;

		// Token: 0x04001E5A RID: 7770
		public const short GiantBow = 1906;

		// Token: 0x04001E5B RID: 7771
		public const short ReindeerAntlers = 1907;

		// Token: 0x04001E5C RID: 7772
		public const short Holly = 1908;

		// Token: 0x04001E5D RID: 7773
		public const short CandyCaneSword = 1909;

		// Token: 0x04001E5E RID: 7774
		public const short EldMelter = 1910;

		// Token: 0x04001E5F RID: 7775
		public const short ChristmasPudding = 1911;

		// Token: 0x04001E60 RID: 7776
		public const short Eggnog = 1912;

		// Token: 0x04001E61 RID: 7777
		public const short StarAnise = 1913;

		// Token: 0x04001E62 RID: 7778
		public const short ReindeerBells = 1914;

		// Token: 0x04001E63 RID: 7779
		public const short CandyCaneHook = 1915;

		// Token: 0x04001E64 RID: 7780
		public const short ChristmasHook = 1916;

		// Token: 0x04001E65 RID: 7781
		public const short CnadyCanePickaxe = 1917;

		// Token: 0x04001E66 RID: 7782
		public const short FruitcakeChakram = 1918;

		// Token: 0x04001E67 RID: 7783
		public const short SugarCookie = 1919;

		// Token: 0x04001E68 RID: 7784
		public const short GingerbreadCookie = 1920;

		// Token: 0x04001E69 RID: 7785
		public const short HandWarmer = 1921;

		// Token: 0x04001E6A RID: 7786
		public const short Coal = 1922;

		// Token: 0x04001E6B RID: 7787
		public const short Toolbox = 1923;

		// Token: 0x04001E6C RID: 7788
		public const short PineDoor = 1924;

		// Token: 0x04001E6D RID: 7789
		public const short PineChair = 1925;

		// Token: 0x04001E6E RID: 7790
		public const short PineTable = 1926;

		// Token: 0x04001E6F RID: 7791
		public const short DogWhistle = 1927;

		// Token: 0x04001E70 RID: 7792
		public const short ChristmasTreeSword = 1928;

		// Token: 0x04001E71 RID: 7793
		public const short ChainGun = 1929;

		// Token: 0x04001E72 RID: 7794
		public const short Razorpine = 1930;

		// Token: 0x04001E73 RID: 7795
		public const short BlizzardStaff = 1931;

		// Token: 0x04001E74 RID: 7796
		public const short MrsClauseHat = 1932;

		// Token: 0x04001E75 RID: 7797
		public const short MrsClauseShirt = 1933;

		// Token: 0x04001E76 RID: 7798
		public const short MrsClauseHeels = 1934;

		// Token: 0x04001E77 RID: 7799
		public const short ParkaHood = 1935;

		// Token: 0x04001E78 RID: 7800
		public const short ParkaCoat = 1936;

		// Token: 0x04001E79 RID: 7801
		public const short ParkaPants = 1937;

		// Token: 0x04001E7A RID: 7802
		public const short SnowHat = 1938;

		// Token: 0x04001E7B RID: 7803
		public const short UglySweater = 1939;

		// Token: 0x04001E7C RID: 7804
		public const short TreeMask = 1940;

		// Token: 0x04001E7D RID: 7805
		public const short TreeShirt = 1941;

		// Token: 0x04001E7E RID: 7806
		public const short TreeTrunks = 1942;

		// Token: 0x04001E7F RID: 7807
		public const short ElfHat = 1943;

		// Token: 0x04001E80 RID: 7808
		public const short ElfShirt = 1944;

		// Token: 0x04001E81 RID: 7809
		public const short ElfPants = 1945;

		// Token: 0x04001E82 RID: 7810
		public const short SnowmanCannon = 1946;

		// Token: 0x04001E83 RID: 7811
		public const short NorthPole = 1947;

		// Token: 0x04001E84 RID: 7812
		public const short ChristmasTreeWallpaper = 1948;

		// Token: 0x04001E85 RID: 7813
		public const short OrnamentWallpaper = 1949;

		// Token: 0x04001E86 RID: 7814
		public const short CandyCaneWallpaper = 1950;

		// Token: 0x04001E87 RID: 7815
		public const short FestiveWallpaper = 1951;

		// Token: 0x04001E88 RID: 7816
		public const short StarsWallpaper = 1952;

		// Token: 0x04001E89 RID: 7817
		public const short SquigglesWallpaper = 1953;

		// Token: 0x04001E8A RID: 7818
		public const short SnowflakeWallpaper = 1954;

		// Token: 0x04001E8B RID: 7819
		public const short KrampusHornWallpaper = 1955;

		// Token: 0x04001E8C RID: 7820
		public const short BluegreenWallpaper = 1956;

		// Token: 0x04001E8D RID: 7821
		public const short GrinchFingerWallpaper = 1957;

		// Token: 0x04001E8E RID: 7822
		public const short NaughtyPresent = 1958;

		// Token: 0x04001E8F RID: 7823
		public const short BabyGrinchMischiefWhistle = 1959;

		// Token: 0x04001E90 RID: 7824
		public const short IceQueenTrophy = 1960;

		// Token: 0x04001E91 RID: 7825
		public const short SantaNK1Trophy = 1961;

		// Token: 0x04001E92 RID: 7826
		public const short EverscreamTrophy = 1962;

		// Token: 0x04001E93 RID: 7827
		public const short MusicBoxPumpkinMoon = 1963;

		// Token: 0x04001E94 RID: 7828
		public const short MusicBoxAltUnderground = 1964;

		// Token: 0x04001E95 RID: 7829
		public const short MusicBoxFrostMoon = 1965;

		// Token: 0x04001E96 RID: 7830
		public const short BrownPaint = 1966;

		// Token: 0x04001E97 RID: 7831
		public const short ShadowPaint = 1967;

		// Token: 0x04001E98 RID: 7832
		public const short NegativePaint = 1968;

		// Token: 0x04001E99 RID: 7833
		public const short TeamDye = 1969;

		// Token: 0x04001E9A RID: 7834
		public const short AmethystGemsparkBlock = 1970;

		// Token: 0x04001E9B RID: 7835
		public const short TopazGemsparkBlock = 1971;

		// Token: 0x04001E9C RID: 7836
		public const short SapphireGemsparkBlock = 1972;

		// Token: 0x04001E9D RID: 7837
		public const short EmeraldGemsparkBlock = 1973;

		// Token: 0x04001E9E RID: 7838
		public const short RubyGemsparkBlock = 1974;

		// Token: 0x04001E9F RID: 7839
		public const short DiamondGemsparkBlock = 1975;

		// Token: 0x04001EA0 RID: 7840
		public const short AmberGemsparkBlock = 1976;

		// Token: 0x04001EA1 RID: 7841
		public const short LifeHairDye = 1977;

		// Token: 0x04001EA2 RID: 7842
		public const short ManaHairDye = 1978;

		// Token: 0x04001EA3 RID: 7843
		public const short DepthHairDye = 1979;

		// Token: 0x04001EA4 RID: 7844
		public const short MoneyHairDye = 1980;

		// Token: 0x04001EA5 RID: 7845
		public const short TimeHairDye = 1981;

		// Token: 0x04001EA6 RID: 7846
		public const short TeamHairDye = 1982;

		// Token: 0x04001EA7 RID: 7847
		public const short BiomeHairDye = 1983;

		// Token: 0x04001EA8 RID: 7848
		public const short PartyHairDye = 1984;

		// Token: 0x04001EA9 RID: 7849
		public const short RainbowHairDye = 1985;

		// Token: 0x04001EAA RID: 7850
		public const short SpeedHairDye = 1986;

		// Token: 0x04001EAB RID: 7851
		public const short AngelHalo = 1987;

		// Token: 0x04001EAC RID: 7852
		public const short Fez = 1988;

		// Token: 0x04001EAD RID: 7853
		public const short Womannquin = 1989;

		// Token: 0x04001EAE RID: 7854
		public const short HairDyeRemover = 1990;

		// Token: 0x04001EAF RID: 7855
		public const short BugNet = 1991;

		// Token: 0x04001EB0 RID: 7856
		public const short Firefly = 1992;

		// Token: 0x04001EB1 RID: 7857
		public const short FireflyinaBottle = 1993;

		// Token: 0x04001EB2 RID: 7858
		public const short MonarchButterfly = 1994;

		// Token: 0x04001EB3 RID: 7859
		public const short PurpleEmperorButterfly = 1995;

		// Token: 0x04001EB4 RID: 7860
		public const short RedAdmiralButterfly = 1996;

		// Token: 0x04001EB5 RID: 7861
		public const short UlyssesButterfly = 1997;

		// Token: 0x04001EB6 RID: 7862
		public const short SulphurButterfly = 1998;

		// Token: 0x04001EB7 RID: 7863
		public const short TreeNymphButterfly = 1999;

		// Token: 0x04001EB8 RID: 7864
		public const short ZebraSwallowtailButterfly = 2000;

		// Token: 0x04001EB9 RID: 7865
		public const short JuliaButterfly = 2001;

		// Token: 0x04001EBA RID: 7866
		public const short Worm = 2002;

		// Token: 0x04001EBB RID: 7867
		public const short Mouse = 2003;

		// Token: 0x04001EBC RID: 7868
		public const short LightningBug = 2004;

		// Token: 0x04001EBD RID: 7869
		public const short LightningBuginaBottle = 2005;

		// Token: 0x04001EBE RID: 7870
		public const short Snail = 2006;

		// Token: 0x04001EBF RID: 7871
		public const short GlowingSnail = 2007;

		// Token: 0x04001EC0 RID: 7872
		public const short FancyGreyWallpaper = 2008;

		// Token: 0x04001EC1 RID: 7873
		public const short IceFloeWallpaper = 2009;

		// Token: 0x04001EC2 RID: 7874
		public const short MusicWallpaper = 2010;

		// Token: 0x04001EC3 RID: 7875
		public const short PurpleRainWallpaper = 2011;

		// Token: 0x04001EC4 RID: 7876
		public const short RainbowWallpaper = 2012;

		// Token: 0x04001EC5 RID: 7877
		public const short SparkleStoneWallpaper = 2013;

		// Token: 0x04001EC6 RID: 7878
		public const short StarlitHeavenWallpaper = 2014;

		// Token: 0x04001EC7 RID: 7879
		public const short Bird = 2015;

		// Token: 0x04001EC8 RID: 7880
		public const short BlueJay = 2016;

		// Token: 0x04001EC9 RID: 7881
		public const short Cardinal = 2017;

		// Token: 0x04001ECA RID: 7882
		public const short Squirrel = 2018;

		// Token: 0x04001ECB RID: 7883
		public const short Bunny = 2019;

		// Token: 0x04001ECC RID: 7884
		public const short CactusBookcase = 2020;

		// Token: 0x04001ECD RID: 7885
		public const short EbonwoodBookcase = 2021;

		// Token: 0x04001ECE RID: 7886
		public const short FleshBookcase = 2022;

		// Token: 0x04001ECF RID: 7887
		public const short HoneyBookcase = 2023;

		// Token: 0x04001ED0 RID: 7888
		public const short SteampunkBookcase = 2024;

		// Token: 0x04001ED1 RID: 7889
		public const short GlassBookcase = 2025;

		// Token: 0x04001ED2 RID: 7890
		public const short RichMahoganyBookcase = 2026;

		// Token: 0x04001ED3 RID: 7891
		public const short PearlwoodBookcase = 2027;

		// Token: 0x04001ED4 RID: 7892
		public const short SpookyBookcase = 2028;

		// Token: 0x04001ED5 RID: 7893
		public const short SkywareBookcase = 2029;

		// Token: 0x04001ED6 RID: 7894
		public const short LihzahrdBookcase = 2030;

		// Token: 0x04001ED7 RID: 7895
		public const short FrozenBookcase = 2031;

		// Token: 0x04001ED8 RID: 7896
		public const short CactusLantern = 2032;

		// Token: 0x04001ED9 RID: 7897
		public const short EbonwoodLantern = 2033;

		// Token: 0x04001EDA RID: 7898
		public const short FleshLantern = 2034;

		// Token: 0x04001EDB RID: 7899
		public const short HoneyLantern = 2035;

		// Token: 0x04001EDC RID: 7900
		public const short SteampunkLantern = 2036;

		// Token: 0x04001EDD RID: 7901
		public const short GlassLantern = 2037;

		// Token: 0x04001EDE RID: 7902
		public const short RichMahoganyLantern = 2038;

		// Token: 0x04001EDF RID: 7903
		public const short PearlwoodLantern = 2039;

		// Token: 0x04001EE0 RID: 7904
		public const short FrozenLantern = 2040;

		// Token: 0x04001EE1 RID: 7905
		public const short LihzahrdLantern = 2041;

		// Token: 0x04001EE2 RID: 7906
		public const short SkywareLantern = 2042;

		// Token: 0x04001EE3 RID: 7907
		public const short SpookyLantern = 2043;

		// Token: 0x04001EE4 RID: 7908
		public const short FrozenDoor = 2044;

		// Token: 0x04001EE5 RID: 7909
		public const short CactusCandle = 2045;

		// Token: 0x04001EE6 RID: 7910
		public const short EbonwoodCandle = 2046;

		// Token: 0x04001EE7 RID: 7911
		public const short FleshCandle = 2047;

		// Token: 0x04001EE8 RID: 7912
		public const short GlassCandle = 2048;

		// Token: 0x04001EE9 RID: 7913
		public const short FrozenCandle = 2049;

		// Token: 0x04001EEA RID: 7914
		public const short RichMahoganyCandle = 2050;

		// Token: 0x04001EEB RID: 7915
		public const short PearlwoodCandle = 2051;

		// Token: 0x04001EEC RID: 7916
		public const short LihzahrdCandle = 2052;

		// Token: 0x04001EED RID: 7917
		public const short SkywareCandle = 2053;

		// Token: 0x04001EEE RID: 7918
		public const short PumpkinCandle = 2054;

		// Token: 0x04001EEF RID: 7919
		public const short CactusChandelier = 2055;

		// Token: 0x04001EF0 RID: 7920
		public const short EbonwoodChandelier = 2056;

		// Token: 0x04001EF1 RID: 7921
		public const short FleshChandelier = 2057;

		// Token: 0x04001EF2 RID: 7922
		public const short HoneyChandelier = 2058;

		// Token: 0x04001EF3 RID: 7923
		public const short FrozenChandelier = 2059;

		// Token: 0x04001EF4 RID: 7924
		public const short RichMahoganyChandelier = 2060;

		// Token: 0x04001EF5 RID: 7925
		public const short PearlwoodChandelier = 2061;

		// Token: 0x04001EF6 RID: 7926
		public const short LihzahrdChandelier = 2062;

		// Token: 0x04001EF7 RID: 7927
		public const short SkywareChandelier = 2063;

		// Token: 0x04001EF8 RID: 7928
		public const short SpookyChandelier = 2064;

		// Token: 0x04001EF9 RID: 7929
		public const short GlassChandelier = 2065;

		// Token: 0x04001EFA RID: 7930
		public const short CactusBed = 2066;

		// Token: 0x04001EFB RID: 7931
		public const short FleshBed = 2067;

		// Token: 0x04001EFC RID: 7932
		public const short FrozenBed = 2068;

		// Token: 0x04001EFD RID: 7933
		public const short LihzahrdBed = 2069;

		// Token: 0x04001EFE RID: 7934
		public const short SkywareBed = 2070;

		// Token: 0x04001EFF RID: 7935
		public const short SpookyBed = 2071;

		// Token: 0x04001F00 RID: 7936
		public const short CactusBathtub = 2072;

		// Token: 0x04001F01 RID: 7937
		public const short EbonwoodBathtub = 2073;

		// Token: 0x04001F02 RID: 7938
		public const short FleshBathtub = 2074;

		// Token: 0x04001F03 RID: 7939
		public const short GlassBathtub = 2075;

		// Token: 0x04001F04 RID: 7940
		public const short FrozenBathtub = 2076;

		// Token: 0x04001F05 RID: 7941
		public const short RichMahoganyBathtub = 2077;

		// Token: 0x04001F06 RID: 7942
		public const short PearlwoodBathtub = 2078;

		// Token: 0x04001F07 RID: 7943
		public const short LihzahrdBathtub = 2079;

		// Token: 0x04001F08 RID: 7944
		public const short SkywareBathtub = 2080;

		// Token: 0x04001F09 RID: 7945
		public const short SpookyBathtub = 2081;

		// Token: 0x04001F0A RID: 7946
		public const short CactusLamp = 2082;

		// Token: 0x04001F0B RID: 7947
		public const short EbonwoodLamp = 2083;

		// Token: 0x04001F0C RID: 7948
		public const short FleshLamp = 2084;

		// Token: 0x04001F0D RID: 7949
		public const short GlassLamp = 2085;

		// Token: 0x04001F0E RID: 7950
		public const short FrozenLamp = 2086;

		// Token: 0x04001F0F RID: 7951
		public const short RichMahoganyLamp = 2087;

		// Token: 0x04001F10 RID: 7952
		public const short PearlwoodLamp = 2088;

		// Token: 0x04001F11 RID: 7953
		public const short LihzahrdLamp = 2089;

		// Token: 0x04001F12 RID: 7954
		public const short SkywareLamp = 2090;

		// Token: 0x04001F13 RID: 7955
		public const short SpookyLamp = 2091;

		// Token: 0x04001F14 RID: 7956
		public const short CactusCandelabra = 2092;

		// Token: 0x04001F15 RID: 7957
		public const short EbonwoodCandelabra = 2093;

		// Token: 0x04001F16 RID: 7958
		public const short FleshCandelabra = 2094;

		// Token: 0x04001F17 RID: 7959
		public const short HoneyCandelabra = 2095;

		// Token: 0x04001F18 RID: 7960
		public const short SteampunkCandelabra = 2096;

		// Token: 0x04001F19 RID: 7961
		public const short GlassCandelabra = 2097;

		// Token: 0x04001F1A RID: 7962
		public const short RichMahoganyCandelabra = 2098;

		// Token: 0x04001F1B RID: 7963
		public const short PearlwoodCandelabra = 2099;

		// Token: 0x04001F1C RID: 7964
		public const short FrozenCandelabra = 2100;

		// Token: 0x04001F1D RID: 7965
		public const short LihzahrdCandelabra = 2101;

		// Token: 0x04001F1E RID: 7966
		public const short SkywareCandelabra = 2102;

		// Token: 0x04001F1F RID: 7967
		public const short SpookyCandelabra = 2103;

		// Token: 0x04001F20 RID: 7968
		public const short BrainMask = 2104;

		// Token: 0x04001F21 RID: 7969
		public const short FleshMask = 2105;

		// Token: 0x04001F22 RID: 7970
		public const short TwinMask = 2106;

		// Token: 0x04001F23 RID: 7971
		public const short SkeletronPrimeMask = 2107;

		// Token: 0x04001F24 RID: 7972
		public const short BeeMask = 2108;

		// Token: 0x04001F25 RID: 7973
		public const short PlanteraMask = 2109;

		// Token: 0x04001F26 RID: 7974
		public const short GolemMask = 2110;

		// Token: 0x04001F27 RID: 7975
		public const short EaterMask = 2111;

		// Token: 0x04001F28 RID: 7976
		public const short EyeMask = 2112;

		// Token: 0x04001F29 RID: 7977
		public const short DestroyerMask = 2113;

		// Token: 0x04001F2A RID: 7978
		public const short BlacksmithRack = 2114;

		// Token: 0x04001F2B RID: 7979
		public const short CarpentryRack = 2115;

		// Token: 0x04001F2C RID: 7980
		public const short HelmetRack = 2116;

		// Token: 0x04001F2D RID: 7981
		public const short SpearRack = 2117;

		// Token: 0x04001F2E RID: 7982
		public const short SwordRack = 2118;

		// Token: 0x04001F2F RID: 7983
		public const short StoneSlab = 2119;

		// Token: 0x04001F30 RID: 7984
		public const short SandstoneSlab = 2120;

		// Token: 0x04001F31 RID: 7985
		public const short Frog = 2121;

		// Token: 0x04001F32 RID: 7986
		public const short MallardDuck = 2122;

		// Token: 0x04001F33 RID: 7987
		public const short Duck = 2123;

		// Token: 0x04001F34 RID: 7988
		public const short HoneyBathtub = 2124;

		// Token: 0x04001F35 RID: 7989
		public const short SteampunkBathtub = 2125;

		// Token: 0x04001F36 RID: 7990
		public const short LivingWoodBathtub = 2126;

		// Token: 0x04001F37 RID: 7991
		public const short ShadewoodBathtub = 2127;

		// Token: 0x04001F38 RID: 7992
		public const short BoneBathtub = 2128;

		// Token: 0x04001F39 RID: 7993
		public const short HoneyLamp = 2129;

		// Token: 0x04001F3A RID: 7994
		public const short SteampunkLamp = 2130;

		// Token: 0x04001F3B RID: 7995
		public const short LivingWoodLamp = 2131;

		// Token: 0x04001F3C RID: 7996
		public const short ShadewoodLamp = 2132;

		// Token: 0x04001F3D RID: 7997
		public const short GoldenLamp = 2133;

		// Token: 0x04001F3E RID: 7998
		public const short BoneLamp = 2134;

		// Token: 0x04001F3F RID: 7999
		public const short LivingWoodBookcase = 2135;

		// Token: 0x04001F40 RID: 8000
		public const short ShadewoodBookcase = 2136;

		// Token: 0x04001F41 RID: 8001
		public const short GoldenBookcase = 2137;

		// Token: 0x04001F42 RID: 8002
		public const short BoneBookcase = 2138;

		// Token: 0x04001F43 RID: 8003
		public const short LivingWoodBed = 2139;

		// Token: 0x04001F44 RID: 8004
		public const short BoneBed = 2140;

		// Token: 0x04001F45 RID: 8005
		public const short LivingWoodChandelier = 2141;

		// Token: 0x04001F46 RID: 8006
		public const short ShadewoodChandelier = 2142;

		// Token: 0x04001F47 RID: 8007
		public const short GoldenChandelier = 2143;

		// Token: 0x04001F48 RID: 8008
		public const short BoneChandelier = 2144;

		// Token: 0x04001F49 RID: 8009
		public const short LivingWoodLantern = 2145;

		// Token: 0x04001F4A RID: 8010
		public const short ShadewoodLantern = 2146;

		// Token: 0x04001F4B RID: 8011
		public const short GoldenLantern = 2147;

		// Token: 0x04001F4C RID: 8012
		public const short BoneLantern = 2148;

		// Token: 0x04001F4D RID: 8013
		public const short LivingWoodCandelabra = 2149;

		// Token: 0x04001F4E RID: 8014
		public const short ShadewoodCandelabra = 2150;

		// Token: 0x04001F4F RID: 8015
		public const short GoldenCandelabra = 2151;

		// Token: 0x04001F50 RID: 8016
		public const short BoneCandelabra = 2152;

		// Token: 0x04001F51 RID: 8017
		public const short LivingWoodCandle = 2153;

		// Token: 0x04001F52 RID: 8018
		public const short ShadewoodCandle = 2154;

		// Token: 0x04001F53 RID: 8019
		public const short GoldenCandle = 2155;

		// Token: 0x04001F54 RID: 8020
		public const short BlackScorpion = 2156;

		// Token: 0x04001F55 RID: 8021
		public const short Scorpion = 2157;

		// Token: 0x04001F56 RID: 8022
		public const short BubbleWallpaper = 2158;

		// Token: 0x04001F57 RID: 8023
		public const short CopperPipeWallpaper = 2159;

		// Token: 0x04001F58 RID: 8024
		public const short DuckyWallpaper = 2160;

		// Token: 0x04001F59 RID: 8025
		public const short FrostCore = 2161;

		// Token: 0x04001F5A RID: 8026
		public const short BunnyCage = 2162;

		// Token: 0x04001F5B RID: 8027
		public const short SquirrelCage = 2163;

		// Token: 0x04001F5C RID: 8028
		public const short MallardDuckCage = 2164;

		// Token: 0x04001F5D RID: 8029
		public const short DuckCage = 2165;

		// Token: 0x04001F5E RID: 8030
		public const short BirdCage = 2166;

		// Token: 0x04001F5F RID: 8031
		public const short BlueJayCage = 2167;

		// Token: 0x04001F60 RID: 8032
		public const short CardinalCage = 2168;

		// Token: 0x04001F61 RID: 8033
		public const short WaterfallWall = 2169;

		// Token: 0x04001F62 RID: 8034
		public const short LavafallWall = 2170;

		// Token: 0x04001F63 RID: 8035
		public const short CrimsonSeeds = 2171;

		// Token: 0x04001F64 RID: 8036
		public const short HeavyWorkBench = 2172;

		// Token: 0x04001F65 RID: 8037
		public const short CopperPlating = 2173;

		// Token: 0x04001F66 RID: 8038
		public const short SnailCage = 2174;

		// Token: 0x04001F67 RID: 8039
		public const short GlowingSnailCage = 2175;

		// Token: 0x04001F68 RID: 8040
		public const short ShroomiteDiggingClaw = 2176;

		// Token: 0x04001F69 RID: 8041
		public const short AmmoBox = 2177;

		// Token: 0x04001F6A RID: 8042
		public const short MonarchButterflyJar = 2178;

		// Token: 0x04001F6B RID: 8043
		public const short PurpleEmperorButterflyJar = 2179;

		// Token: 0x04001F6C RID: 8044
		public const short RedAdmiralButterflyJar = 2180;

		// Token: 0x04001F6D RID: 8045
		public const short UlyssesButterflyJar = 2181;

		// Token: 0x04001F6E RID: 8046
		public const short SulphurButterflyJar = 2182;

		// Token: 0x04001F6F RID: 8047
		public const short TreeNymphButterflyJar = 2183;

		// Token: 0x04001F70 RID: 8048
		public const short ZebraSwallowtailButterflyJar = 2184;

		// Token: 0x04001F71 RID: 8049
		public const short JuliaButterflyJar = 2185;

		// Token: 0x04001F72 RID: 8050
		public const short ScorpionCage = 2186;

		// Token: 0x04001F73 RID: 8051
		public const short BlackScorpionCage = 2187;

		// Token: 0x04001F74 RID: 8052
		public const short VenomStaff = 2188;

		// Token: 0x04001F75 RID: 8053
		public const short SpectreMask = 2189;

		// Token: 0x04001F76 RID: 8054
		public const short FrogCage = 2190;

		// Token: 0x04001F77 RID: 8055
		public const short MouseCage = 2191;

		// Token: 0x04001F78 RID: 8056
		public const short BoneWelder = 2192;

		// Token: 0x04001F79 RID: 8057
		public const short FleshCloningVaat = 2193;

		// Token: 0x04001F7A RID: 8058
		public const short GlassKiln = 2194;

		// Token: 0x04001F7B RID: 8059
		public const short LihzahrdFurnace = 2195;

		// Token: 0x04001F7C RID: 8060
		public const short LivingLoom = 2196;

		// Token: 0x04001F7D RID: 8061
		public const short SkyMill = 2197;

		// Token: 0x04001F7E RID: 8062
		public const short IceMachine = 2198;

		// Token: 0x04001F7F RID: 8063
		public const short BeetleHelmet = 2199;

		// Token: 0x04001F80 RID: 8064
		public const short BeetleScaleMail = 2200;

		// Token: 0x04001F81 RID: 8065
		public const short BeetleShell = 2201;

		// Token: 0x04001F82 RID: 8066
		public const short BeetleLeggings = 2202;

		// Token: 0x04001F83 RID: 8067
		public const short SteampunkBoiler = 2203;

		// Token: 0x04001F84 RID: 8068
		public const short HoneyDispenser = 2204;

		// Token: 0x04001F85 RID: 8069
		public const short Penguin = 2205;

		// Token: 0x04001F86 RID: 8070
		public const short PenguinCage = 2206;

		// Token: 0x04001F87 RID: 8071
		public const short WormCage = 2207;

		// Token: 0x04001F88 RID: 8072
		public const short Terrarium = 2208;

		// Token: 0x04001F89 RID: 8073
		public const short SuperManaPotion = 2209;

		// Token: 0x04001F8A RID: 8074
		public const short EbonwoodFence = 2210;

		// Token: 0x04001F8B RID: 8075
		public const short RichMahoganyFence = 2211;

		// Token: 0x04001F8C RID: 8076
		public const short PearlwoodFence = 2212;

		// Token: 0x04001F8D RID: 8077
		public const short ShadewoodFence = 2213;

		// Token: 0x04001F8E RID: 8078
		public const short BrickLayer = 2214;

		// Token: 0x04001F8F RID: 8079
		public const short ExtendoGrip = 2215;

		// Token: 0x04001F90 RID: 8080
		public const short PaintSprayer = 2216;

		// Token: 0x04001F91 RID: 8081
		public const short PortableCementMixer = 2217;

		// Token: 0x04001F92 RID: 8082
		public const short BeetleHusk = 2218;

		// Token: 0x04001F93 RID: 8083
		public const short CelestialMagnet = 2219;

		// Token: 0x04001F94 RID: 8084
		public const short CelestialEmblem = 2220;

		// Token: 0x04001F95 RID: 8085
		public const short CelestialCuffs = 2221;

		// Token: 0x04001F96 RID: 8086
		public const short PeddlersHat = 2222;

		// Token: 0x04001F97 RID: 8087
		public const short PulseBow = 2223;

		// Token: 0x04001F98 RID: 8088
		public const short DynastyChandelier = 2224;

		// Token: 0x04001F99 RID: 8089
		public const short DynastyLamp = 2225;

		// Token: 0x04001F9A RID: 8090
		public const short DynastyLantern = 2226;

		// Token: 0x04001F9B RID: 8091
		public const short DynastyCandelabra = 2227;

		// Token: 0x04001F9C RID: 8092
		public const short DynastyChair = 2228;

		// Token: 0x04001F9D RID: 8093
		public const short DynastyWorkBench = 2229;

		// Token: 0x04001F9E RID: 8094
		public const short DynastyChest = 2230;

		// Token: 0x04001F9F RID: 8095
		public const short DynastyBed = 2231;

		// Token: 0x04001FA0 RID: 8096
		public const short DynastyBathtub = 2232;

		// Token: 0x04001FA1 RID: 8097
		public const short DynastyBookcase = 2233;

		// Token: 0x04001FA2 RID: 8098
		public const short DynastyCup = 2234;

		// Token: 0x04001FA3 RID: 8099
		public const short DynastyBowl = 2235;

		// Token: 0x04001FA4 RID: 8100
		public const short DynastyCandle = 2236;

		// Token: 0x04001FA5 RID: 8101
		public const short DynastyClock = 2237;

		// Token: 0x04001FA6 RID: 8102
		public const short GoldenClock = 2238;

		// Token: 0x04001FA7 RID: 8103
		public const short GlassClock = 2239;

		// Token: 0x04001FA8 RID: 8104
		public const short HoneyClock = 2240;

		// Token: 0x04001FA9 RID: 8105
		public const short SteampunkClock = 2241;

		// Token: 0x04001FAA RID: 8106
		public const short FancyDishes = 2242;

		// Token: 0x04001FAB RID: 8107
		public const short GlassBowl = 2243;

		// Token: 0x04001FAC RID: 8108
		public const short WineGlass = 2244;

		// Token: 0x04001FAD RID: 8109
		public const short LivingWoodPiano = 2245;

		// Token: 0x04001FAE RID: 8110
		public const short FleshPiano = 2246;

		// Token: 0x04001FAF RID: 8111
		public const short FrozenPiano = 2247;

		// Token: 0x04001FB0 RID: 8112
		public const short FrozenTable = 2248;

		// Token: 0x04001FB1 RID: 8113
		public const short HoneyChest = 2249;

		// Token: 0x04001FB2 RID: 8114
		public const short SteampunkChest = 2250;

		// Token: 0x04001FB3 RID: 8115
		public const short HoneyWorkBench = 2251;

		// Token: 0x04001FB4 RID: 8116
		public const short FrozenWorkBench = 2252;

		// Token: 0x04001FB5 RID: 8117
		public const short SteampunkWorkBench = 2253;

		// Token: 0x04001FB6 RID: 8118
		public const short GlassPiano = 2254;

		// Token: 0x04001FB7 RID: 8119
		public const short HoneyPiano = 2255;

		// Token: 0x04001FB8 RID: 8120
		public const short SteampunkPiano = 2256;

		// Token: 0x04001FB9 RID: 8121
		public const short HoneyCup = 2257;

		// Token: 0x04001FBA RID: 8122
		public const short SteampunkCup = 2258;

		// Token: 0x04001FBB RID: 8123
		public const short DynastyTable = 2259;

		// Token: 0x04001FBC RID: 8124
		public const short DynastyWood = 2260;

		// Token: 0x04001FBD RID: 8125
		public const short RedDynastyShingles = 2261;

		// Token: 0x04001FBE RID: 8126
		public const short BlueDynastyShingles = 2262;

		// Token: 0x04001FBF RID: 8127
		public const short WhiteDynastyWall = 2263;

		// Token: 0x04001FC0 RID: 8128
		public const short BlueDynastyWall = 2264;

		// Token: 0x04001FC1 RID: 8129
		public const short DynastyDoor = 2265;

		// Token: 0x04001FC2 RID: 8130
		public const short Sake = 2266;

		// Token: 0x04001FC3 RID: 8131
		public const short PadThai = 2267;

		// Token: 0x04001FC4 RID: 8132
		public const short Pho = 2268;

		// Token: 0x04001FC5 RID: 8133
		public const short Revolver = 2269;

		// Token: 0x04001FC6 RID: 8134
		public const short Gatligator = 2270;

		// Token: 0x04001FC7 RID: 8135
		public const short ArcaneRuneWall = 2271;

		// Token: 0x04001FC8 RID: 8136
		public const short WaterGun = 2272;

		// Token: 0x04001FC9 RID: 8137
		public const short Katana = 2273;

		// Token: 0x04001FCA RID: 8138
		public const short UltrabrightTorch = 2274;

		// Token: 0x04001FCB RID: 8139
		public const short MagicHat = 2275;

		// Token: 0x04001FCC RID: 8140
		public const short DiamondRing = 2276;

		// Token: 0x04001FCD RID: 8141
		public const short Gi = 2277;

		// Token: 0x04001FCE RID: 8142
		public const short Kimono = 2278;

		// Token: 0x04001FCF RID: 8143
		public const short GypsyRobe = 2279;

		// Token: 0x04001FD0 RID: 8144
		public const short BeetleWings = 2280;

		// Token: 0x04001FD1 RID: 8145
		public const short TigerSkin = 2281;

		// Token: 0x04001FD2 RID: 8146
		public const short LeopardSkin = 2282;

		// Token: 0x04001FD3 RID: 8147
		public const short ZebraSkin = 2283;

		// Token: 0x04001FD4 RID: 8148
		public const short CrimsonCloak = 2284;

		// Token: 0x04001FD5 RID: 8149
		public const short MysteriousCape = 2285;

		// Token: 0x04001FD6 RID: 8150
		public const short RedCape = 2286;

		// Token: 0x04001FD7 RID: 8151
		public const short WinterCape = 2287;

		// Token: 0x04001FD8 RID: 8152
		public const short FrozenChair = 2288;

		// Token: 0x04001FD9 RID: 8153
		public const short WoodFishingPole = 2289;

		// Token: 0x04001FDA RID: 8154
		public const short Bass = 2290;

		// Token: 0x04001FDB RID: 8155
		public const short ReinforcedFishingPole = 2291;

		// Token: 0x04001FDC RID: 8156
		public const short FiberglassFishingPole = 2292;

		// Token: 0x04001FDD RID: 8157
		public const short FisherofSouls = 2293;

		// Token: 0x04001FDE RID: 8158
		public const short GoldenFishingRod = 2294;

		// Token: 0x04001FDF RID: 8159
		public const short MechanicsRod = 2295;

		// Token: 0x04001FE0 RID: 8160
		public const short SittingDucksFishingRod = 2296;

		// Token: 0x04001FE1 RID: 8161
		public const short Trout = 2297;

		// Token: 0x04001FE2 RID: 8162
		public const short Salmon = 2298;

		// Token: 0x04001FE3 RID: 8163
		public const short AtlanticCod = 2299;

		// Token: 0x04001FE4 RID: 8164
		public const short Tuna = 2300;

		// Token: 0x04001FE5 RID: 8165
		public const short RedSnapper = 2301;

		// Token: 0x04001FE6 RID: 8166
		public const short NeonTetra = 2302;

		// Token: 0x04001FE7 RID: 8167
		public const short ArmoredCavefish = 2303;

		// Token: 0x04001FE8 RID: 8168
		public const short Damselfish = 2304;

		// Token: 0x04001FE9 RID: 8169
		public const short CrimsonTigerfish = 2305;

		// Token: 0x04001FEA RID: 8170
		public const short FrostMinnow = 2306;

		// Token: 0x04001FEB RID: 8171
		public const short PrincessFish = 2307;

		// Token: 0x04001FEC RID: 8172
		public const short GoldenCarp = 2308;

		// Token: 0x04001FED RID: 8173
		public const short SpecularFish = 2309;

		// Token: 0x04001FEE RID: 8174
		public const short Prismite = 2310;

		// Token: 0x04001FEF RID: 8175
		public const short VariegatedLardfish = 2311;

		// Token: 0x04001FF0 RID: 8176
		public const short FlarefinKoi = 2312;

		// Token: 0x04001FF1 RID: 8177
		public const short DoubleCod = 2313;

		// Token: 0x04001FF2 RID: 8178
		public const short Honeyfin = 2314;

		// Token: 0x04001FF3 RID: 8179
		public const short Obsidifish = 2315;

		// Token: 0x04001FF4 RID: 8180
		public const short Shrimp = 2316;

		// Token: 0x04001FF5 RID: 8181
		public const short ChaosFish = 2317;

		// Token: 0x04001FF6 RID: 8182
		public const short Ebonkoi = 2318;

		// Token: 0x04001FF7 RID: 8183
		public const short Hemopiranha = 2319;

		// Token: 0x04001FF8 RID: 8184
		public const short Rockfish = 2320;

		// Token: 0x04001FF9 RID: 8185
		public const short Stinkfish = 2321;

		// Token: 0x04001FFA RID: 8186
		public const short MiningPotion = 2322;

		// Token: 0x04001FFB RID: 8187
		public const short HeartreachPotion = 2323;

		// Token: 0x04001FFC RID: 8188
		public const short CalmingPotion = 2324;

		// Token: 0x04001FFD RID: 8189
		public const short BuilderPotion = 2325;

		// Token: 0x04001FFE RID: 8190
		public const short TitanPotion = 2326;

		// Token: 0x04001FFF RID: 8191
		public const short FlipperPotion = 2327;

		// Token: 0x04002000 RID: 8192
		public const short SummoningPotion = 2328;

		// Token: 0x04002001 RID: 8193
		public const short TrapsightPotion = 2329;

		// Token: 0x04002002 RID: 8194
		public const short PurpleClubberfish = 2330;

		// Token: 0x04002003 RID: 8195
		public const short ObsidianSwordfish = 2331;

		// Token: 0x04002004 RID: 8196
		public const short Swordfish = 2332;

		// Token: 0x04002005 RID: 8197
		public const short IronFence = 2333;

		// Token: 0x04002006 RID: 8198
		public const short WoodenCrate = 2334;

		// Token: 0x04002007 RID: 8199
		public const short IronCrate = 2335;

		// Token: 0x04002008 RID: 8200
		public const short GoldenCrate = 2336;

		// Token: 0x04002009 RID: 8201
		public const short OldShoe = 2337;

		// Token: 0x0400200A RID: 8202
		public const short FishingSeaweed = 2338;

		// Token: 0x0400200B RID: 8203
		public const short TinCan = 2339;

		// Token: 0x0400200C RID: 8204
		public const short MinecartTrack = 2340;

		// Token: 0x0400200D RID: 8205
		public const short ReaverShark = 2341;

		// Token: 0x0400200E RID: 8206
		public const short SawtoothShark = 2342;

		// Token: 0x0400200F RID: 8207
		public const short Minecart = 2343;

		// Token: 0x04002010 RID: 8208
		public const short AmmoReservationPotion = 2344;

		// Token: 0x04002011 RID: 8209
		public const short LifeforcePotion = 2345;

		// Token: 0x04002012 RID: 8210
		public const short EndurancePotion = 2346;

		// Token: 0x04002013 RID: 8211
		public const short RagePotion = 2347;

		// Token: 0x04002014 RID: 8212
		public const short InfernoPotion = 2348;

		// Token: 0x04002015 RID: 8213
		public const short WrathPotion = 2349;

		// Token: 0x04002016 RID: 8214
		public const short RecallPotion = 2350;

		// Token: 0x04002017 RID: 8215
		public const short TeleportationPotion = 2351;

		// Token: 0x04002018 RID: 8216
		public const short LovePotion = 2352;

		// Token: 0x04002019 RID: 8217
		public const short StinkPotion = 2353;

		// Token: 0x0400201A RID: 8218
		public const short FishingPotion = 2354;

		// Token: 0x0400201B RID: 8219
		public const short SonarPotion = 2355;

		// Token: 0x0400201C RID: 8220
		public const short CratePotion = 2356;

		// Token: 0x0400201D RID: 8221
		public const short ShiverthornSeeds = 2357;

		// Token: 0x0400201E RID: 8222
		public const short Shiverthorn = 2358;

		// Token: 0x0400201F RID: 8223
		public const short WarmthPotion = 2359;

		// Token: 0x04002020 RID: 8224
		public const short FishHook = 2360;

		// Token: 0x04002021 RID: 8225
		public const short BeeHeadgear = 2361;

		// Token: 0x04002022 RID: 8226
		public const short BeeBreastplate = 2362;

		// Token: 0x04002023 RID: 8227
		public const short BeeGreaves = 2363;

		// Token: 0x04002024 RID: 8228
		public const short HornetStaff = 2364;

		// Token: 0x04002025 RID: 8229
		public const short ImpStaff = 2365;

		// Token: 0x04002026 RID: 8230
		public const short QueenSpiderStaff = 2366;

		// Token: 0x04002027 RID: 8231
		public const short AnglerHat = 2367;

		// Token: 0x04002028 RID: 8232
		public const short AnglerVest = 2368;

		// Token: 0x04002029 RID: 8233
		public const short AnglerPants = 2369;

		// Token: 0x0400202A RID: 8234
		public const short SpiderMask = 2370;

		// Token: 0x0400202B RID: 8235
		public const short SpiderBreastplate = 2371;

		// Token: 0x0400202C RID: 8236
		public const short SpiderGreaves = 2372;

		// Token: 0x0400202D RID: 8237
		public const short HighTestFishingLine = 2373;

		// Token: 0x0400202E RID: 8238
		public const short AnglerEarring = 2374;

		// Token: 0x0400202F RID: 8239
		public const short TackleBox = 2375;

		// Token: 0x04002030 RID: 8240
		public const short BlueDungeonPiano = 2376;

		// Token: 0x04002031 RID: 8241
		public const short GreenDungeonPiano = 2377;

		// Token: 0x04002032 RID: 8242
		public const short PinkDungeonPiano = 2378;

		// Token: 0x04002033 RID: 8243
		public const short GoldenPiano = 2379;

		// Token: 0x04002034 RID: 8244
		public const short ObsidianPiano = 2380;

		// Token: 0x04002035 RID: 8245
		public const short BonePiano = 2381;

		// Token: 0x04002036 RID: 8246
		public const short CactusPiano = 2382;

		// Token: 0x04002037 RID: 8247
		public const short SpookyPiano = 2383;

		// Token: 0x04002038 RID: 8248
		public const short SkywarePiano = 2384;

		// Token: 0x04002039 RID: 8249
		public const short LihzahrdPiano = 2385;

		// Token: 0x0400203A RID: 8250
		public const short BlueDungeonDresser = 2386;

		// Token: 0x0400203B RID: 8251
		public const short GreenDungeonDresser = 2387;

		// Token: 0x0400203C RID: 8252
		public const short PinkDungeonDresser = 2388;

		// Token: 0x0400203D RID: 8253
		public const short GoldenDresser = 2389;

		// Token: 0x0400203E RID: 8254
		public const short ObsidianDresser = 2390;

		// Token: 0x0400203F RID: 8255
		public const short BoneDresser = 2391;

		// Token: 0x04002040 RID: 8256
		public const short CactusDresser = 2392;

		// Token: 0x04002041 RID: 8257
		public const short SpookyDresser = 2393;

		// Token: 0x04002042 RID: 8258
		public const short SkywareDresser = 2394;

		// Token: 0x04002043 RID: 8259
		public const short HoneyDresser = 2395;

		// Token: 0x04002044 RID: 8260
		public const short LihzahrdDresser = 2396;

		// Token: 0x04002045 RID: 8261
		public const short Sofa = 2397;

		// Token: 0x04002046 RID: 8262
		public const short EbonwoodSofa = 2398;

		// Token: 0x04002047 RID: 8263
		public const short RichMahoganySofa = 2399;

		// Token: 0x04002048 RID: 8264
		public const short PearlwoodSofa = 2400;

		// Token: 0x04002049 RID: 8265
		public const short ShadewoodSofa = 2401;

		// Token: 0x0400204A RID: 8266
		public const short BlueDungeonSofa = 2402;

		// Token: 0x0400204B RID: 8267
		public const short GreenDungeonSofa = 2403;

		// Token: 0x0400204C RID: 8268
		public const short PinkDungeonSofa = 2404;

		// Token: 0x0400204D RID: 8269
		public const short GoldenSofa = 2405;

		// Token: 0x0400204E RID: 8270
		public const short ObsidianSofa = 2406;

		// Token: 0x0400204F RID: 8271
		public const short BoneSofa = 2407;

		// Token: 0x04002050 RID: 8272
		public const short CactusSofa = 2408;

		// Token: 0x04002051 RID: 8273
		public const short SpookySofa = 2409;

		// Token: 0x04002052 RID: 8274
		public const short SkywareSofa = 2410;

		// Token: 0x04002053 RID: 8275
		public const short HoneySofa = 2411;

		// Token: 0x04002054 RID: 8276
		public const short SteampunkSofa = 2412;

		// Token: 0x04002055 RID: 8277
		public const short MushroomSofa = 2413;

		// Token: 0x04002056 RID: 8278
		public const short GlassSofa = 2414;

		// Token: 0x04002057 RID: 8279
		public const short PumpkinSofa = 2415;

		// Token: 0x04002058 RID: 8280
		public const short LihzahrdSofa = 2416;

		// Token: 0x04002059 RID: 8281
		public const short SeashellHairpin = 2417;

		// Token: 0x0400205A RID: 8282
		public const short MermaidAdornment = 2418;

		// Token: 0x0400205B RID: 8283
		public const short MermaidTail = 2419;

		// Token: 0x0400205C RID: 8284
		public const short ZephyrFish = 2420;

		// Token: 0x0400205D RID: 8285
		public const short Fleshcatcher = 2421;

		// Token: 0x0400205E RID: 8286
		public const short HotlineFishingHook = 2422;

		// Token: 0x0400205F RID: 8287
		public const short FrogLeg = 2423;

		// Token: 0x04002060 RID: 8288
		public const short Anchor = 2424;

		// Token: 0x04002061 RID: 8289
		public const short CookedFish = 2425;

		// Token: 0x04002062 RID: 8290
		public const short CookedShrimp = 2426;

		// Token: 0x04002063 RID: 8291
		public const short Sashimi = 2427;

		// Token: 0x04002064 RID: 8292
		public const short FuzzyCarrot = 2428;

		// Token: 0x04002065 RID: 8293
		public const short ScalyTruffle = 2429;

		// Token: 0x04002066 RID: 8294
		public const short SlimySaddle = 2430;

		// Token: 0x04002067 RID: 8295
		public const short BeeWax = 2431;

		// Token: 0x04002068 RID: 8296
		public const short CopperPlatingWall = 2432;

		// Token: 0x04002069 RID: 8297
		public const short StoneSlabWall = 2433;

		// Token: 0x0400206A RID: 8298
		public const short Sail = 2434;

		// Token: 0x0400206B RID: 8299
		public const short CoralstoneBlock = 2435;

		// Token: 0x0400206C RID: 8300
		public const short BlueJellyfish = 2436;

		// Token: 0x0400206D RID: 8301
		public const short GreenJellyfish = 2437;

		// Token: 0x0400206E RID: 8302
		public const short PinkJellyfish = 2438;

		// Token: 0x0400206F RID: 8303
		public const short BlueJellyfishJar = 2439;

		// Token: 0x04002070 RID: 8304
		public const short GreenJellyfishJar = 2440;

		// Token: 0x04002071 RID: 8305
		public const short PinkJellyfishJar = 2441;

		// Token: 0x04002072 RID: 8306
		public const short LifePreserver = 2442;

		// Token: 0x04002073 RID: 8307
		public const short ShipsWheel = 2443;

		// Token: 0x04002074 RID: 8308
		public const short CompassRose = 2444;

		// Token: 0x04002075 RID: 8309
		public const short WallAnchor = 2445;

		// Token: 0x04002076 RID: 8310
		public const short GoldfishTrophy = 2446;

		// Token: 0x04002077 RID: 8311
		public const short BunnyfishTrophy = 2447;

		// Token: 0x04002078 RID: 8312
		public const short SwordfishTrophy = 2448;

		// Token: 0x04002079 RID: 8313
		public const short SharkteethTrophy = 2449;

		// Token: 0x0400207A RID: 8314
		public const short Batfish = 2450;

		// Token: 0x0400207B RID: 8315
		public const short BumblebeeTuna = 2451;

		// Token: 0x0400207C RID: 8316
		public const short Catfish = 2452;

		// Token: 0x0400207D RID: 8317
		public const short Cloudfish = 2453;

		// Token: 0x0400207E RID: 8318
		public const short Cursedfish = 2454;

		// Token: 0x0400207F RID: 8319
		public const short Dirtfish = 2455;

		// Token: 0x04002080 RID: 8320
		public const short DynamiteFish = 2456;

		// Token: 0x04002081 RID: 8321
		public const short EaterofPlankton = 2457;

		// Token: 0x04002082 RID: 8322
		public const short FallenStarfish = 2458;

		// Token: 0x04002083 RID: 8323
		public const short TheFishofCthulu = 2459;

		// Token: 0x04002084 RID: 8324
		public const short Fishotron = 2460;

		// Token: 0x04002085 RID: 8325
		public const short Harpyfish = 2461;

		// Token: 0x04002086 RID: 8326
		public const short Hungerfish = 2462;

		// Token: 0x04002087 RID: 8327
		public const short Ichorfish = 2463;

		// Token: 0x04002088 RID: 8328
		public const short Jewelfish = 2464;

		// Token: 0x04002089 RID: 8329
		public const short MirageFish = 2465;

		// Token: 0x0400208A RID: 8330
		public const short MutantFlinxfin = 2466;

		// Token: 0x0400208B RID: 8331
		public const short Pengfish = 2467;

		// Token: 0x0400208C RID: 8332
		public const short Pixiefish = 2468;

		// Token: 0x0400208D RID: 8333
		public const short Spiderfish = 2469;

		// Token: 0x0400208E RID: 8334
		public const short TundraTrout = 2470;

		// Token: 0x0400208F RID: 8335
		public const short UnicornFish = 2471;

		// Token: 0x04002090 RID: 8336
		public const short GuideVoodooFish = 2472;

		// Token: 0x04002091 RID: 8337
		public const short Wyverntail = 2473;

		// Token: 0x04002092 RID: 8338
		public const short ZombieFish = 2474;

		// Token: 0x04002093 RID: 8339
		public const short AmanitiaFungifin = 2475;

		// Token: 0x04002094 RID: 8340
		public const short Angelfish = 2476;

		// Token: 0x04002095 RID: 8341
		public const short BloodyManowar = 2477;

		// Token: 0x04002096 RID: 8342
		public const short Bonefish = 2478;

		// Token: 0x04002097 RID: 8343
		public const short Bunnyfish = 2479;

		// Token: 0x04002098 RID: 8344
		public const short CapnTunabeard = 2480;

		// Token: 0x04002099 RID: 8345
		public const short Clownfish = 2481;

		// Token: 0x0400209A RID: 8346
		public const short DemonicHellfish = 2482;

		// Token: 0x0400209B RID: 8347
		public const short Derpfish = 2483;

		// Token: 0x0400209C RID: 8348
		public const short Fishron = 2484;

		// Token: 0x0400209D RID: 8349
		public const short InfectedScabbardfish = 2485;

		// Token: 0x0400209E RID: 8350
		public const short Mudfish = 2486;

		// Token: 0x0400209F RID: 8351
		public const short Slimefish = 2487;

		// Token: 0x040020A0 RID: 8352
		public const short TropicalBarracuda = 2488;

		// Token: 0x040020A1 RID: 8353
		public const short KingSlimeTrophy = 2489;

		// Token: 0x040020A2 RID: 8354
		public const short ShipInABottle = 2490;

		// Token: 0x040020A3 RID: 8355
		public const short HardySaddle = 2491;

		// Token: 0x040020A4 RID: 8356
		public const short PressureTrack = 2492;

		// Token: 0x040020A5 RID: 8357
		public const short KingSlimeMask = 2493;

		// Token: 0x040020A6 RID: 8358
		public const short FinWings = 2494;

		// Token: 0x040020A7 RID: 8359
		public const short TreasureMap = 2495;

		// Token: 0x040020A8 RID: 8360
		public const short SeaweedPlanter = 2496;

		// Token: 0x040020A9 RID: 8361
		public const short PillaginMePixels = 2497;

		// Token: 0x040020AA RID: 8362
		public const short FishCostumeMask = 2498;

		// Token: 0x040020AB RID: 8363
		public const short FishCostumeShirt = 2499;

		// Token: 0x040020AC RID: 8364
		public const short FishCostumeFinskirt = 2500;

		// Token: 0x040020AD RID: 8365
		public const short GingerBeard = 2501;

		// Token: 0x040020AE RID: 8366
		public const short HoneyedGoggles = 2502;

		// Token: 0x040020AF RID: 8367
		public const short BorealWood = 2503;

		// Token: 0x040020B0 RID: 8368
		public const short PalmWood = 2504;

		// Token: 0x040020B1 RID: 8369
		public const short BorealWoodWall = 2505;

		// Token: 0x040020B2 RID: 8370
		public const short PalmWoodWall = 2506;

		// Token: 0x040020B3 RID: 8371
		public const short BorealWoodFence = 2507;

		// Token: 0x040020B4 RID: 8372
		public const short PalmWoodFence = 2508;

		// Token: 0x040020B5 RID: 8373
		public const short BorealWoodHelmet = 2509;

		// Token: 0x040020B6 RID: 8374
		public const short BorealWoodBreastplate = 2510;

		// Token: 0x040020B7 RID: 8375
		public const short BorealWoodGreaves = 2511;

		// Token: 0x040020B8 RID: 8376
		public const short PalmWoodHelmet = 2512;

		// Token: 0x040020B9 RID: 8377
		public const short PalmWoodBreastplate = 2513;

		// Token: 0x040020BA RID: 8378
		public const short PalmWoodGreaves = 2514;

		// Token: 0x040020BB RID: 8379
		public const short PalmWoodBow = 2515;

		// Token: 0x040020BC RID: 8380
		public const short PalmWoodHammer = 2516;

		// Token: 0x040020BD RID: 8381
		public const short PalmWoodSword = 2517;

		// Token: 0x040020BE RID: 8382
		public const short PalmWoodPlatform = 2518;

		// Token: 0x040020BF RID: 8383
		public const short PalmWoodBathtub = 2519;

		// Token: 0x040020C0 RID: 8384
		public const short PalmWoodBed = 2520;

		// Token: 0x040020C1 RID: 8385
		public const short PalmWoodBench = 2521;

		// Token: 0x040020C2 RID: 8386
		public const short PalmWoodCandelabra = 2522;

		// Token: 0x040020C3 RID: 8387
		public const short PalmWoodCandle = 2523;

		// Token: 0x040020C4 RID: 8388
		public const short PalmWoodChair = 2524;

		// Token: 0x040020C5 RID: 8389
		public const short PalmWoodChandelier = 2525;

		// Token: 0x040020C6 RID: 8390
		public const short PalmWoodChest = 2526;

		// Token: 0x040020C7 RID: 8391
		public const short PalmWoodSofa = 2527;

		// Token: 0x040020C8 RID: 8392
		public const short PalmWoodDoor = 2528;

		// Token: 0x040020C9 RID: 8393
		public const short PalmWoodDresser = 2529;

		// Token: 0x040020CA RID: 8394
		public const short PalmWoodLantern = 2530;

		// Token: 0x040020CB RID: 8395
		public const short PalmWoodPiano = 2531;

		// Token: 0x040020CC RID: 8396
		public const short PalmWoodTable = 2532;

		// Token: 0x040020CD RID: 8397
		public const short PalmWoodLamp = 2533;

		// Token: 0x040020CE RID: 8398
		public const short PalmWoodWorkBench = 2534;

		// Token: 0x040020CF RID: 8399
		public const short OpticStaff = 2535;

		// Token: 0x040020D0 RID: 8400
		public const short PalmWoodBookcase = 2536;

		// Token: 0x040020D1 RID: 8401
		public const short MushroomBathtub = 2537;

		// Token: 0x040020D2 RID: 8402
		public const short MushroomBed = 2538;

		// Token: 0x040020D3 RID: 8403
		public const short MushroomBench = 2539;

		// Token: 0x040020D4 RID: 8404
		public const short MushroomBookcase = 2540;

		// Token: 0x040020D5 RID: 8405
		public const short MushroomCandelabra = 2541;

		// Token: 0x040020D6 RID: 8406
		public const short MushroomCandle = 2542;

		// Token: 0x040020D7 RID: 8407
		public const short MushroomChandelier = 2543;

		// Token: 0x040020D8 RID: 8408
		public const short MushroomChest = 2544;

		// Token: 0x040020D9 RID: 8409
		public const short MushroomDresser = 2545;

		// Token: 0x040020DA RID: 8410
		public const short MushroomLantern = 2546;

		// Token: 0x040020DB RID: 8411
		public const short MushroomLamp = 2547;

		// Token: 0x040020DC RID: 8412
		public const short MushroomPiano = 2548;

		// Token: 0x040020DD RID: 8413
		public const short MushroomPlatform = 2549;

		// Token: 0x040020DE RID: 8414
		public const short MushroomTable = 2550;

		// Token: 0x040020DF RID: 8415
		public const short SpiderStaff = 2551;

		// Token: 0x040020E0 RID: 8416
		public const short BorealWoodBathtub = 2552;

		// Token: 0x040020E1 RID: 8417
		public const short BorealWoodBed = 2553;

		// Token: 0x040020E2 RID: 8418
		public const short BorealWoodBookcase = 2554;

		// Token: 0x040020E3 RID: 8419
		public const short BorealWoodCandelabra = 2555;

		// Token: 0x040020E4 RID: 8420
		public const short BorealWoodCandle = 2556;

		// Token: 0x040020E5 RID: 8421
		public const short BorealWoodChair = 2557;

		// Token: 0x040020E6 RID: 8422
		public const short BorealWoodChandelier = 2558;

		// Token: 0x040020E7 RID: 8423
		public const short BorealWoodChest = 2559;

		// Token: 0x040020E8 RID: 8424
		public const short BorealWoodClock = 2560;

		// Token: 0x040020E9 RID: 8425
		public const short BorealWoodDoor = 2561;

		// Token: 0x040020EA RID: 8426
		public const short BorealWoodDresser = 2562;

		// Token: 0x040020EB RID: 8427
		public const short BorealWoodLamp = 2563;

		// Token: 0x040020EC RID: 8428
		public const short BorealWoodLantern = 2564;

		// Token: 0x040020ED RID: 8429
		public const short BorealWoodPiano = 2565;

		// Token: 0x040020EE RID: 8430
		public const short BorealWoodPlatform = 2566;

		// Token: 0x040020EF RID: 8431
		public const short SlimeBathtub = 2567;

		// Token: 0x040020F0 RID: 8432
		public const short SlimeBed = 2568;

		// Token: 0x040020F1 RID: 8433
		public const short SlimeBookcase = 2569;

		// Token: 0x040020F2 RID: 8434
		public const short SlimeCandelabra = 2570;

		// Token: 0x040020F3 RID: 8435
		public const short SlimeCandle = 2571;

		// Token: 0x040020F4 RID: 8436
		public const short SlimeChair = 2572;

		// Token: 0x040020F5 RID: 8437
		public const short SlimeChandelier = 2573;

		// Token: 0x040020F6 RID: 8438
		public const short SlimeChest = 2574;

		// Token: 0x040020F7 RID: 8439
		public const short SlimeClock = 2575;

		// Token: 0x040020F8 RID: 8440
		public const short SlimeDoor = 2576;

		// Token: 0x040020F9 RID: 8441
		public const short SlimeDresser = 2577;

		// Token: 0x040020FA RID: 8442
		public const short SlimeLamp = 2578;

		// Token: 0x040020FB RID: 8443
		public const short SlimeLantern = 2579;

		// Token: 0x040020FC RID: 8444
		public const short SlimePiano = 2580;

		// Token: 0x040020FD RID: 8445
		public const short SlimePlatform = 2581;

		// Token: 0x040020FE RID: 8446
		public const short SlimeSofa = 2582;

		// Token: 0x040020FF RID: 8447
		public const short SlimeTable = 2583;

		// Token: 0x04002100 RID: 8448
		public const short PirateStaff = 2584;

		// Token: 0x04002101 RID: 8449
		public const short SlimeHook = 2585;

		// Token: 0x04002102 RID: 8450
		public const short StickyGrenade = 2586;

		// Token: 0x04002103 RID: 8451
		public const short TartarSauce = 2587;

		// Token: 0x04002104 RID: 8452
		public const short DukeFishronMask = 2588;

		// Token: 0x04002105 RID: 8453
		public const short DukeFishronTrophy = 2589;

		// Token: 0x04002106 RID: 8454
		public const short MolotovCocktail = 2590;

		// Token: 0x04002107 RID: 8455
		public const short BoneClock = 2591;

		// Token: 0x04002108 RID: 8456
		public const short CactusClock = 2592;

		// Token: 0x04002109 RID: 8457
		public const short EbonwoodClock = 2593;

		// Token: 0x0400210A RID: 8458
		public const short FrozenClock = 2594;

		// Token: 0x0400210B RID: 8459
		public const short LihzahrdClock = 2595;

		// Token: 0x0400210C RID: 8460
		public const short LivingWoodClock = 2596;

		// Token: 0x0400210D RID: 8461
		public const short RichMahoganyClock = 2597;

		// Token: 0x0400210E RID: 8462
		public const short FleshClock = 2598;

		// Token: 0x0400210F RID: 8463
		public const short MushroomClock = 2599;

		// Token: 0x04002110 RID: 8464
		public const short ObsidianClock = 2600;

		// Token: 0x04002111 RID: 8465
		public const short PalmWoodClock = 2601;

		// Token: 0x04002112 RID: 8466
		public const short PearlwoodClock = 2602;

		// Token: 0x04002113 RID: 8467
		public const short PumpkinClock = 2603;

		// Token: 0x04002114 RID: 8468
		public const short ShadewoodClock = 2604;

		// Token: 0x04002115 RID: 8469
		public const short SpookyClock = 2605;

		// Token: 0x04002116 RID: 8470
		public const short SkywareClock = 2606;

		// Token: 0x04002117 RID: 8471
		public const short SpiderFang = 2607;

		// Token: 0x04002118 RID: 8472
		public const short FalconBlade = 2608;

		// Token: 0x04002119 RID: 8473
		public const short FishronWings = 2609;

		// Token: 0x0400211A RID: 8474
		public const short SlimeGun = 2610;

		// Token: 0x0400211B RID: 8475
		public const short Flairon = 2611;

		// Token: 0x0400211C RID: 8476
		public const short GreenDungeonChest = 2612;

		// Token: 0x0400211D RID: 8477
		public const short PinkDungeonChest = 2613;

		// Token: 0x0400211E RID: 8478
		public const short BlueDungeonChest = 2614;

		// Token: 0x0400211F RID: 8479
		public const short BoneChest = 2615;

		// Token: 0x04002120 RID: 8480
		public const short CactusChest = 2616;

		// Token: 0x04002121 RID: 8481
		public const short FleshChest = 2617;

		// Token: 0x04002122 RID: 8482
		public const short ObsidianChest = 2618;

		// Token: 0x04002123 RID: 8483
		public const short PumpkinChest = 2619;

		// Token: 0x04002124 RID: 8484
		public const short SpookyChest = 2620;

		// Token: 0x04002125 RID: 8485
		public const short TempestStaff = 2621;

		// Token: 0x04002126 RID: 8486
		public const short RazorbladeTyphoon = 2622;

		// Token: 0x04002127 RID: 8487
		public const short BubbleGun = 2623;

		// Token: 0x04002128 RID: 8488
		public const short Tsunami = 2624;

		// Token: 0x04002129 RID: 8489
		public const short Seashell = 2625;

		// Token: 0x0400212A RID: 8490
		public const short Starfish = 2626;

		// Token: 0x0400212B RID: 8491
		public const short SteampunkPlatform = 2627;

		// Token: 0x0400212C RID: 8492
		public const short SkywarePlatform = 2628;

		// Token: 0x0400212D RID: 8493
		public const short LivingWoodPlatform = 2629;

		// Token: 0x0400212E RID: 8494
		public const short HoneyPlatform = 2630;

		// Token: 0x0400212F RID: 8495
		public const short SkywareWorkbench = 2631;

		// Token: 0x04002130 RID: 8496
		public const short GlassWorkBench = 2632;

		// Token: 0x04002131 RID: 8497
		public const short LivingWoodWorkBench = 2633;

		// Token: 0x04002132 RID: 8498
		public const short FleshSofa = 2634;

		// Token: 0x04002133 RID: 8499
		public const short FrozenSofa = 2635;

		// Token: 0x04002134 RID: 8500
		public const short LivingWoodSofa = 2636;

		// Token: 0x04002135 RID: 8501
		public const short PumpkinDresser = 2637;

		// Token: 0x04002136 RID: 8502
		public const short SteampunkDresser = 2638;

		// Token: 0x04002137 RID: 8503
		public const short GlassDresser = 2639;

		// Token: 0x04002138 RID: 8504
		public const short FleshDresser = 2640;

		// Token: 0x04002139 RID: 8505
		public const short PumpkinLantern = 2641;

		// Token: 0x0400213A RID: 8506
		public const short ObsidianLantern = 2642;

		// Token: 0x0400213B RID: 8507
		public const short PumpkinLamp = 2643;

		// Token: 0x0400213C RID: 8508
		public const short ObsidianLamp = 2644;

		// Token: 0x0400213D RID: 8509
		public const short BlueDungeonLamp = 2645;

		// Token: 0x0400213E RID: 8510
		public const short GreenDungeonLamp = 2646;

		// Token: 0x0400213F RID: 8511
		public const short PinkDungeonLamp = 2647;

		// Token: 0x04002140 RID: 8512
		public const short HoneyCandle = 2648;

		// Token: 0x04002141 RID: 8513
		public const short SteampunkCandle = 2649;

		// Token: 0x04002142 RID: 8514
		public const short SpookyCandle = 2650;

		// Token: 0x04002143 RID: 8515
		public const short ObsidianCandle = 2651;

		// Token: 0x04002144 RID: 8516
		public const short BlueDungeonChandelier = 2652;

		// Token: 0x04002145 RID: 8517
		public const short GreenDungeonChandelier = 2653;

		// Token: 0x04002146 RID: 8518
		public const short PinkDungeonChandelier = 2654;

		// Token: 0x04002147 RID: 8519
		public const short SteampunkChandelier = 2655;

		// Token: 0x04002148 RID: 8520
		public const short PumpkinChandelier = 2656;

		// Token: 0x04002149 RID: 8521
		public const short ObsidianChandelier = 2657;

		// Token: 0x0400214A RID: 8522
		public const short BlueDungeonBathtub = 2658;

		// Token: 0x0400214B RID: 8523
		public const short GreenDungeonBathtub = 2659;

		// Token: 0x0400214C RID: 8524
		public const short PinkDungeonBathtub = 2660;

		// Token: 0x0400214D RID: 8525
		public const short PumpkinBathtub = 2661;

		// Token: 0x0400214E RID: 8526
		public const short ObsidianBathtub = 2662;

		// Token: 0x0400214F RID: 8527
		public const short GoldenBathtub = 2663;

		// Token: 0x04002150 RID: 8528
		public const short BlueDungeonCandelabra = 2664;

		// Token: 0x04002151 RID: 8529
		public const short GreenDungeonCandelabra = 2665;

		// Token: 0x04002152 RID: 8530
		public const short PinkDungeonCandelabra = 2666;

		// Token: 0x04002153 RID: 8531
		public const short ObsidianCandelabra = 2667;

		// Token: 0x04002154 RID: 8532
		public const short PumpkinCandelabra = 2668;

		// Token: 0x04002155 RID: 8533
		public const short PumpkinBed = 2669;

		// Token: 0x04002156 RID: 8534
		public const short PumpkinBookcase = 2670;

		// Token: 0x04002157 RID: 8535
		public const short PumpkinPiano = 2671;

		// Token: 0x04002158 RID: 8536
		public const short SharkStatue = 2672;

		// Token: 0x04002159 RID: 8537
		public const short TruffleWorm = 2673;

		// Token: 0x0400215A RID: 8538
		public const short ApprenticeBait = 2674;

		// Token: 0x0400215B RID: 8539
		public const short JourneymanBait = 2675;

		// Token: 0x0400215C RID: 8540
		public const short MasterBait = 2676;

		// Token: 0x0400215D RID: 8541
		public const short AmberGemsparkWall = 2677;

		// Token: 0x0400215E RID: 8542
		public const short AmberGemsparkWallOff = 2678;

		// Token: 0x0400215F RID: 8543
		public const short AmethystGemsparkWall = 2679;

		// Token: 0x04002160 RID: 8544
		public const short AmethystGemsparkWallOff = 2680;

		// Token: 0x04002161 RID: 8545
		public const short DiamondGemsparkWall = 2681;

		// Token: 0x04002162 RID: 8546
		public const short DiamondGemsparkWallOff = 2682;

		// Token: 0x04002163 RID: 8547
		public const short EmeraldGemsparkWall = 2683;

		// Token: 0x04002164 RID: 8548
		public const short EmeraldGemsparkWallOff = 2684;

		// Token: 0x04002165 RID: 8549
		public const short RubyGemsparkWall = 2685;

		// Token: 0x04002166 RID: 8550
		public const short RubyGemsparkWallOff = 2686;

		// Token: 0x04002167 RID: 8551
		public const short SapphireGemsparkWall = 2687;

		// Token: 0x04002168 RID: 8552
		public const short SapphireGemsparkWallOff = 2688;

		// Token: 0x04002169 RID: 8553
		public const short TopazGemsparkWall = 2689;

		// Token: 0x0400216A RID: 8554
		public const short TopazGemsparkWallOff = 2690;

		// Token: 0x0400216B RID: 8555
		public const short TinPlatingWall = 2691;

		// Token: 0x0400216C RID: 8556
		public const short TinPlating = 2692;

		// Token: 0x0400216D RID: 8557
		public const short WaterfallBlock = 2693;

		// Token: 0x0400216E RID: 8558
		public const short LavafallBlock = 2694;

		// Token: 0x0400216F RID: 8559
		public const short ConfettiBlock = 2695;

		// Token: 0x04002170 RID: 8560
		public const short ConfettiWall = 2696;

		// Token: 0x04002171 RID: 8561
		public const short ConfettiBlockBlack = 2697;

		// Token: 0x04002172 RID: 8562
		public const short ConfettiWallBlack = 2698;

		// Token: 0x04002173 RID: 8563
		public const short WeaponRack = 2699;

		// Token: 0x04002174 RID: 8564
		public const short FireworksBox = 2700;

		// Token: 0x04002175 RID: 8565
		public const short LivingFireBlock = 2701;

		// Token: 0x04002176 RID: 8566
		public const short AlphabetStatue0 = 2702;

		// Token: 0x04002177 RID: 8567
		public const short AlphabetStatue1 = 2703;

		// Token: 0x04002178 RID: 8568
		public const short AlphabetStatue2 = 2704;

		// Token: 0x04002179 RID: 8569
		public const short AlphabetStatue3 = 2705;

		// Token: 0x0400217A RID: 8570
		public const short AlphabetStatue4 = 2706;

		// Token: 0x0400217B RID: 8571
		public const short AlphabetStatue5 = 2707;

		// Token: 0x0400217C RID: 8572
		public const short AlphabetStatue6 = 2708;

		// Token: 0x0400217D RID: 8573
		public const short AlphabetStatue7 = 2709;

		// Token: 0x0400217E RID: 8574
		public const short AlphabetStatue8 = 2710;

		// Token: 0x0400217F RID: 8575
		public const short AlphabetStatue9 = 2711;

		// Token: 0x04002180 RID: 8576
		public const short AlphabetStatueA = 2712;

		// Token: 0x04002181 RID: 8577
		public const short AlphabetStatueB = 2713;

		// Token: 0x04002182 RID: 8578
		public const short AlphabetStatueC = 2714;

		// Token: 0x04002183 RID: 8579
		public const short AlphabetStatueD = 2715;

		// Token: 0x04002184 RID: 8580
		public const short AlphabetStatueE = 2716;

		// Token: 0x04002185 RID: 8581
		public const short AlphabetStatueF = 2717;

		// Token: 0x04002186 RID: 8582
		public const short AlphabetStatueG = 2718;

		// Token: 0x04002187 RID: 8583
		public const short AlphabetStatueH = 2719;

		// Token: 0x04002188 RID: 8584
		public const short AlphabetStatueI = 2720;

		// Token: 0x04002189 RID: 8585
		public const short AlphabetStatueJ = 2721;

		// Token: 0x0400218A RID: 8586
		public const short AlphabetStatueK = 2722;

		// Token: 0x0400218B RID: 8587
		public const short AlphabetStatueL = 2723;

		// Token: 0x0400218C RID: 8588
		public const short AlphabetStatueM = 2724;

		// Token: 0x0400218D RID: 8589
		public const short AlphabetStatueN = 2725;

		// Token: 0x0400218E RID: 8590
		public const short AlphabetStatueO = 2726;

		// Token: 0x0400218F RID: 8591
		public const short AlphabetStatueP = 2727;

		// Token: 0x04002190 RID: 8592
		public const short AlphabetStatueQ = 2728;

		// Token: 0x04002191 RID: 8593
		public const short AlphabetStatueR = 2729;

		// Token: 0x04002192 RID: 8594
		public const short AlphabetStatueS = 2730;

		// Token: 0x04002193 RID: 8595
		public const short AlphabetStatueT = 2731;

		// Token: 0x04002194 RID: 8596
		public const short AlphabetStatueU = 2732;

		// Token: 0x04002195 RID: 8597
		public const short AlphabetStatueV = 2733;

		// Token: 0x04002196 RID: 8598
		public const short AlphabetStatueW = 2734;

		// Token: 0x04002197 RID: 8599
		public const short AlphabetStatueX = 2735;

		// Token: 0x04002198 RID: 8600
		public const short AlphabetStatueY = 2736;

		// Token: 0x04002199 RID: 8601
		public const short AlphabetStatueZ = 2737;

		// Token: 0x0400219A RID: 8602
		public const short FireworkFountain = 2738;

		// Token: 0x0400219B RID: 8603
		public const short BoosterTrack = 2739;

		// Token: 0x0400219C RID: 8604
		public const short Grasshopper = 2740;

		// Token: 0x0400219D RID: 8605
		public const short GrasshopperCage = 2741;

		// Token: 0x0400219E RID: 8606
		public const short MusicBoxUndergroundCrimson = 2742;

		// Token: 0x0400219F RID: 8607
		public const short CactusTable = 2743;

		// Token: 0x040021A0 RID: 8608
		public const short CactusPlatform = 2744;

		// Token: 0x040021A1 RID: 8609
		public const short BorealWoodSword = 2745;

		// Token: 0x040021A2 RID: 8610
		public const short BorealWoodHammer = 2746;

		// Token: 0x040021A3 RID: 8611
		public const short BorealWoodBow = 2747;

		// Token: 0x040021A4 RID: 8612
		public const short GlassChest = 2748;

		// Token: 0x040021A5 RID: 8613
		public const short XenoStaff = 2749;

		// Token: 0x040021A6 RID: 8614
		public const short MeteorStaff = 2750;

		// Token: 0x040021A7 RID: 8615
		public const short LivingCursedFireBlock = 2751;

		// Token: 0x040021A8 RID: 8616
		public const short LivingDemonFireBlock = 2752;

		// Token: 0x040021A9 RID: 8617
		public const short LivingFrostFireBlock = 2753;

		// Token: 0x040021AA RID: 8618
		public const short LivingIchorBlock = 2754;

		// Token: 0x040021AB RID: 8619
		public const short LivingUltrabrightFireBlock = 2755;

		// Token: 0x040021AC RID: 8620
		public const short GenderChangePotion = 2756;

		// Token: 0x040021AD RID: 8621
		public const short VortexHelmet = 2757;

		// Token: 0x040021AE RID: 8622
		public const short VortexBreastplate = 2758;

		// Token: 0x040021AF RID: 8623
		public const short VortexLeggings = 2759;

		// Token: 0x040021B0 RID: 8624
		public const short NebulaHelmet = 2760;

		// Token: 0x040021B1 RID: 8625
		public const short NebulaBreastplate = 2761;

		// Token: 0x040021B2 RID: 8626
		public const short NebulaLeggings = 2762;

		// Token: 0x040021B3 RID: 8627
		public const short SolarFlareHelmet = 2763;

		// Token: 0x040021B4 RID: 8628
		public const short SolarFlareBreastplate = 2764;

		// Token: 0x040021B5 RID: 8629
		public const short SolarFlareLeggings = 2765;

		// Token: 0x040021B6 RID: 8630
		public const short LunarTabletFragment = 2766;

		// Token: 0x040021B7 RID: 8631
		public const short SolarTablet = 2767;

		// Token: 0x040021B8 RID: 8632
		public const short DrillContainmentUnit = 2768;

		// Token: 0x040021B9 RID: 8633
		public const short CosmicCarKey = 2769;

		// Token: 0x040021BA RID: 8634
		public const short MothronWings = 2770;

		// Token: 0x040021BB RID: 8635
		public const short BrainScrambler = 2771;

		// Token: 0x040021BC RID: 8636
		public const short VortexAxe = 2772;

		// Token: 0x040021BD RID: 8637
		public const short VortexChainsaw = 2773;

		// Token: 0x040021BE RID: 8638
		public const short VortexDrill = 2774;

		// Token: 0x040021BF RID: 8639
		public const short VortexHammer = 2775;

		// Token: 0x040021C0 RID: 8640
		public const short VortexPickaxe = 2776;

		// Token: 0x040021C1 RID: 8641
		public const short NebulaAxe = 2777;

		// Token: 0x040021C2 RID: 8642
		public const short NebulaChainsaw = 2778;

		// Token: 0x040021C3 RID: 8643
		public const short NebulaDrill = 2779;

		// Token: 0x040021C4 RID: 8644
		public const short NebulaHammer = 2780;

		// Token: 0x040021C5 RID: 8645
		public const short NebulaPickaxe = 2781;

		// Token: 0x040021C6 RID: 8646
		public const short SolarFlareAxe = 2782;

		// Token: 0x040021C7 RID: 8647
		public const short SolarFlareChainsaw = 2783;

		// Token: 0x040021C8 RID: 8648
		public const short SolarFlareDrill = 2784;

		// Token: 0x040021C9 RID: 8649
		public const short SolarFlareHammer = 2785;

		// Token: 0x040021CA RID: 8650
		public const short SolarFlarePickaxe = 2786;

		// Token: 0x040021CB RID: 8651
		public const short HoneyfallBlock = 2787;

		// Token: 0x040021CC RID: 8652
		public const short HoneyfallWall = 2788;

		// Token: 0x040021CD RID: 8653
		public const short ChlorophyteBrickWall = 2789;

		// Token: 0x040021CE RID: 8654
		public const short CrimtaneBrickWall = 2790;

		// Token: 0x040021CF RID: 8655
		public const short ShroomitePlatingWall = 2791;

		// Token: 0x040021D0 RID: 8656
		public const short ChlorophyteBrick = 2792;

		// Token: 0x040021D1 RID: 8657
		public const short CrimtaneBrick = 2793;

		// Token: 0x040021D2 RID: 8658
		public const short ShroomitePlating = 2794;

		// Token: 0x040021D3 RID: 8659
		public const short LaserMachinegun = 2795;

		// Token: 0x040021D4 RID: 8660
		public const short ElectrosphereLauncher = 2796;

		// Token: 0x040021D5 RID: 8661
		public const short Xenopopper = 2797;

		// Token: 0x040021D6 RID: 8662
		public const short LaserDrill = 2798;

		// Token: 0x040021D7 RID: 8663
		public const short LaserRuler = 2799;

		// Token: 0x040021D8 RID: 8664
		public const short AntiGravityHook = 2800;

		// Token: 0x040021D9 RID: 8665
		public const short MoonMask = 2801;

		// Token: 0x040021DA RID: 8666
		public const short SunMask = 2802;

		// Token: 0x040021DB RID: 8667
		public const short MartianCostumeMask = 2803;

		// Token: 0x040021DC RID: 8668
		public const short MartianCostumeShirt = 2804;

		// Token: 0x040021DD RID: 8669
		public const short MartianCostumePants = 2805;

		// Token: 0x040021DE RID: 8670
		public const short MartianUniformHelmet = 2806;

		// Token: 0x040021DF RID: 8671
		public const short MartianUniformTorso = 2807;

		// Token: 0x040021E0 RID: 8672
		public const short MartianUniformPants = 2808;

		// Token: 0x040021E1 RID: 8673
		public const short MartianAstroClock = 2809;

		// Token: 0x040021E2 RID: 8674
		public const short MartianBathtub = 2810;

		// Token: 0x040021E3 RID: 8675
		public const short MartianBed = 2811;

		// Token: 0x040021E4 RID: 8676
		public const short MartianHoverChair = 2812;

		// Token: 0x040021E5 RID: 8677
		public const short MartianChandelier = 2813;

		// Token: 0x040021E6 RID: 8678
		public const short MartianChest = 2814;

		// Token: 0x040021E7 RID: 8679
		public const short MartianDoor = 2815;

		// Token: 0x040021E8 RID: 8680
		public const short MartianDresser = 2816;

		// Token: 0x040021E9 RID: 8681
		public const short MartianHolobookcase = 2817;

		// Token: 0x040021EA RID: 8682
		public const short MartianHoverCandle = 2818;

		// Token: 0x040021EB RID: 8683
		public const short MartianLamppost = 2819;

		// Token: 0x040021EC RID: 8684
		public const short MartianLantern = 2820;

		// Token: 0x040021ED RID: 8685
		public const short MartianPiano = 2821;

		// Token: 0x040021EE RID: 8686
		public const short MartianPlatform = 2822;

		// Token: 0x040021EF RID: 8687
		public const short MartianSofa = 2823;

		// Token: 0x040021F0 RID: 8688
		public const short MartianTable = 2824;

		// Token: 0x040021F1 RID: 8689
		public const short MartianTableLamp = 2825;

		// Token: 0x040021F2 RID: 8690
		public const short MartianWorkBench = 2826;

		// Token: 0x040021F3 RID: 8691
		public const short WoodenSink = 2827;

		// Token: 0x040021F4 RID: 8692
		public const short EbonwoodSink = 2828;

		// Token: 0x040021F5 RID: 8693
		public const short RichMahoganySink = 2829;

		// Token: 0x040021F6 RID: 8694
		public const short PearlwoodSink = 2830;

		// Token: 0x040021F7 RID: 8695
		public const short BoneSink = 2831;

		// Token: 0x040021F8 RID: 8696
		public const short FleshSink = 2832;

		// Token: 0x040021F9 RID: 8697
		public const short LivingWoodSink = 2833;

		// Token: 0x040021FA RID: 8698
		public const short SkywareSink = 2834;

		// Token: 0x040021FB RID: 8699
		public const short ShadewoodSink = 2835;

		// Token: 0x040021FC RID: 8700
		public const short LihzahrdSink = 2836;

		// Token: 0x040021FD RID: 8701
		public const short BlueDungeonSink = 2837;

		// Token: 0x040021FE RID: 8702
		public const short GreenDungeonSink = 2838;

		// Token: 0x040021FF RID: 8703
		public const short PinkDungeonSink = 2839;

		// Token: 0x04002200 RID: 8704
		public const short ObsidianSink = 2840;

		// Token: 0x04002201 RID: 8705
		public const short MetalSink = 2841;

		// Token: 0x04002202 RID: 8706
		public const short GlassSink = 2842;

		// Token: 0x04002203 RID: 8707
		public const short GoldenSink = 2843;

		// Token: 0x04002204 RID: 8708
		public const short HoneySink = 2844;

		// Token: 0x04002205 RID: 8709
		public const short SteampunkSink = 2845;

		// Token: 0x04002206 RID: 8710
		public const short PumpkinSink = 2846;

		// Token: 0x04002207 RID: 8711
		public const short SpookySink = 2847;

		// Token: 0x04002208 RID: 8712
		public const short FrozenSink = 2848;

		// Token: 0x04002209 RID: 8713
		public const short DynastySink = 2849;

		// Token: 0x0400220A RID: 8714
		public const short PalmWoodSink = 2850;

		// Token: 0x0400220B RID: 8715
		public const short MushroomSink = 2851;

		// Token: 0x0400220C RID: 8716
		public const short BorealWoodSink = 2852;

		// Token: 0x0400220D RID: 8717
		public const short SlimeSink = 2853;

		// Token: 0x0400220E RID: 8718
		public const short CactusSink = 2854;

		// Token: 0x0400220F RID: 8719
		public const short MartianSink = 2855;

		// Token: 0x04002210 RID: 8720
		public const short WhiteLunaticHood = 2856;

		// Token: 0x04002211 RID: 8721
		public const short BlueLunaticHood = 2857;

		// Token: 0x04002212 RID: 8722
		public const short WhiteLunaticRobe = 2858;

		// Token: 0x04002213 RID: 8723
		public const short BlueLunaticRobe = 2859;

		// Token: 0x04002214 RID: 8724
		public const short MartianConduitPlating = 2860;

		// Token: 0x04002215 RID: 8725
		public const short MartianConduitWall = 2861;

		// Token: 0x04002216 RID: 8726
		public const short HiTekSunglasses = 2862;

		// Token: 0x04002217 RID: 8727
		public const short MartianHairDye = 2863;

		// Token: 0x04002218 RID: 8728
		public const short MartianArmorDye = 2864;

		// Token: 0x04002219 RID: 8729
		public const short PaintingCastleMarsberg = 2865;

		// Token: 0x0400221A RID: 8730
		public const short PaintingMartiaLisa = 2866;

		// Token: 0x0400221B RID: 8731
		public const short PaintingTheTruthIsUpThere = 2867;

		// Token: 0x0400221C RID: 8732
		public const short SmokeBlock = 2868;

		// Token: 0x0400221D RID: 8733
		public const short LivingFlameDye = 2869;

		// Token: 0x0400221E RID: 8734
		public const short LivingRainbowDye = 2870;

		// Token: 0x0400221F RID: 8735
		public const short ShadowDye = 2871;

		// Token: 0x04002220 RID: 8736
		public const short NegativeDye = 2872;

		// Token: 0x04002221 RID: 8737
		public const short LivingOceanDye = 2873;

		// Token: 0x04002222 RID: 8738
		public const short BrownDye = 2874;

		// Token: 0x04002223 RID: 8739
		public const short BrownAndBlackDye = 2875;

		// Token: 0x04002224 RID: 8740
		public const short BrightBrownDye = 2876;

		// Token: 0x04002225 RID: 8741
		public const short BrownAndSilverDye = 2877;

		// Token: 0x04002226 RID: 8742
		public const short WispDye = 2878;

		// Token: 0x04002227 RID: 8743
		public const short PixieDye = 2879;

		// Token: 0x04002228 RID: 8744
		public const short InfluxWaver = 2880;

		// Token: 0x04002229 RID: 8745
		public const short PhasicWarpEjector = 2881;

		// Token: 0x0400222A RID: 8746
		public const short ChargedBlasterCannon = 2882;

		// Token: 0x0400222B RID: 8747
		public const short ChlorophyteDye = 2883;

		// Token: 0x0400222C RID: 8748
		public const short UnicornWispDye = 2884;

		// Token: 0x0400222D RID: 8749
		public const short InfernalWispDye = 2885;

		// Token: 0x0400222E RID: 8750
		public const short ViciousPowder = 2886;

		// Token: 0x0400222F RID: 8751
		public const short ViciousMushroom = 2887;

		// Token: 0x04002230 RID: 8752
		public const short BeesKnees = 2888;

		// Token: 0x04002231 RID: 8753
		public const short GoldBird = 2889;

		// Token: 0x04002232 RID: 8754
		public const short GoldBunny = 2890;

		// Token: 0x04002233 RID: 8755
		public const short GoldButterfly = 2891;

		// Token: 0x04002234 RID: 8756
		public const short GoldFrog = 2892;

		// Token: 0x04002235 RID: 8757
		public const short GoldGrasshopper = 2893;

		// Token: 0x04002236 RID: 8758
		public const short GoldMouse = 2894;

		// Token: 0x04002237 RID: 8759
		public const short GoldWorm = 2895;

		// Token: 0x04002238 RID: 8760
		public const short StickyDynamite = 2896;

		// Token: 0x04002239 RID: 8761
		public const short AngryTrapperBanner = 2897;

		// Token: 0x0400223A RID: 8762
		public const short ArmoredVikingBanner = 2898;

		// Token: 0x0400223B RID: 8763
		public const short BlackSlimeBanner = 2899;

		// Token: 0x0400223C RID: 8764
		public const short BlueArmoredBonesBanner = 2900;

		// Token: 0x0400223D RID: 8765
		public const short BlueCultistArcherBanner = 2901;

		// Token: 0x0400223E RID: 8766
		public const short BlueCultistCasterBanner = 2902;

		// Token: 0x0400223F RID: 8767
		public const short BlueCultistFighterBanner = 2903;

		// Token: 0x04002240 RID: 8768
		public const short BoneLeeBanner = 2904;

		// Token: 0x04002241 RID: 8769
		public const short ClingerBanner = 2905;

		// Token: 0x04002242 RID: 8770
		public const short CochinealBeetleBanner = 2906;

		// Token: 0x04002243 RID: 8771
		public const short CorruptPenguinBanner = 2907;

		// Token: 0x04002244 RID: 8772
		public const short CorruptSlimeBanner = 2908;

		// Token: 0x04002245 RID: 8773
		public const short CorruptorBanner = 2909;

		// Token: 0x04002246 RID: 8774
		public const short CrimslimeBanner = 2910;

		// Token: 0x04002247 RID: 8775
		public const short CursedSkullBanner = 2911;

		// Token: 0x04002248 RID: 8776
		public const short CyanBeetleBanner = 2912;

		// Token: 0x04002249 RID: 8777
		public const short DevourerBanner = 2913;

		// Token: 0x0400224A RID: 8778
		public const short DiablolistBanner = 2914;

		// Token: 0x0400224B RID: 8779
		public const short DoctorBonesBanner = 2915;

		// Token: 0x0400224C RID: 8780
		public const short DungeonSlimeBanner = 2916;

		// Token: 0x0400224D RID: 8781
		public const short DungeonSpiritBanner = 2917;

		// Token: 0x0400224E RID: 8782
		public const short ElfArcherBanner = 2918;

		// Token: 0x0400224F RID: 8783
		public const short ElfCopterBanner = 2919;

		// Token: 0x04002250 RID: 8784
		public const short EyezorBanner = 2920;

		// Token: 0x04002251 RID: 8785
		public const short FlockoBanner = 2921;

		// Token: 0x04002252 RID: 8786
		public const short GhostBanner = 2922;

		// Token: 0x04002253 RID: 8787
		public const short GiantBatBanner = 2923;

		// Token: 0x04002254 RID: 8788
		public const short GiantCursedSkullBanner = 2924;

		// Token: 0x04002255 RID: 8789
		public const short GiantFlyingFoxBanner = 2925;

		// Token: 0x04002256 RID: 8790
		public const short GingerbreadManBanner = 2926;

		// Token: 0x04002257 RID: 8791
		public const short GoblinArcherBanner = 2927;

		// Token: 0x04002258 RID: 8792
		public const short GreenSlimeBanner = 2928;

		// Token: 0x04002259 RID: 8793
		public const short HeadlessHorsemanBanner = 2929;

		// Token: 0x0400225A RID: 8794
		public const short HellArmoredBonesBanner = 2930;

		// Token: 0x0400225B RID: 8795
		public const short HellhoundBanner = 2931;

		// Token: 0x0400225C RID: 8796
		public const short HoppinJackBanner = 2932;

		// Token: 0x0400225D RID: 8797
		public const short IceBatBanner = 2933;

		// Token: 0x0400225E RID: 8798
		public const short IceGolemBanner = 2934;

		// Token: 0x0400225F RID: 8799
		public const short IceSlimeBanner = 2935;

		// Token: 0x04002260 RID: 8800
		public const short IchorStickerBanner = 2936;

		// Token: 0x04002261 RID: 8801
		public const short IlluminantBatBanner = 2937;

		// Token: 0x04002262 RID: 8802
		public const short IlluminantSlimeBanner = 2938;

		// Token: 0x04002263 RID: 8803
		public const short JungleBatBanner = 2939;

		// Token: 0x04002264 RID: 8804
		public const short JungleSlimeBanner = 2940;

		// Token: 0x04002265 RID: 8805
		public const short KrampusBanner = 2941;

		// Token: 0x04002266 RID: 8806
		public const short LacBeetleBanner = 2942;

		// Token: 0x04002267 RID: 8807
		public const short LavaBatBanner = 2943;

		// Token: 0x04002268 RID: 8808
		public const short LavaSlimeBanner = 2944;

		// Token: 0x04002269 RID: 8809
		public const short MartianBrainscramblerBanner = 2945;

		// Token: 0x0400226A RID: 8810
		public const short MartianDroneBanner = 2946;

		// Token: 0x0400226B RID: 8811
		public const short MartianEngineerBanner = 2947;

		// Token: 0x0400226C RID: 8812
		public const short MartianGigazapperBanner = 2948;

		// Token: 0x0400226D RID: 8813
		public const short MartianGreyGruntBanner = 2949;

		// Token: 0x0400226E RID: 8814
		public const short MartianOfficerBanner = 2950;

		// Token: 0x0400226F RID: 8815
		public const short MartianRaygunnerBanner = 2951;

		// Token: 0x04002270 RID: 8816
		public const short MartianScutlixGunnerBanner = 2952;

		// Token: 0x04002271 RID: 8817
		public const short MartianTeslaTurretBanner = 2953;

		// Token: 0x04002272 RID: 8818
		public const short MisterStabbyBanner = 2954;

		// Token: 0x04002273 RID: 8819
		public const short MotherSlimeBanner = 2955;

		// Token: 0x04002274 RID: 8820
		public const short NecromancerBanner = 2956;

		// Token: 0x04002275 RID: 8821
		public const short NutcrackerBanner = 2957;

		// Token: 0x04002276 RID: 8822
		public const short PaladinBanner = 2958;

		// Token: 0x04002277 RID: 8823
		public const short PenguinBanner = 2959;

		// Token: 0x04002278 RID: 8824
		public const short PinkyBanner = 2960;

		// Token: 0x04002279 RID: 8825
		public const short PoltergeistBanner = 2961;

		// Token: 0x0400227A RID: 8826
		public const short PossessedArmorBanner = 2962;

		// Token: 0x0400227B RID: 8827
		public const short PresentMimicBanner = 2963;

		// Token: 0x0400227C RID: 8828
		public const short PurpleSlimeBanner = 2964;

		// Token: 0x0400227D RID: 8829
		public const short RaggedCasterBanner = 2965;

		// Token: 0x0400227E RID: 8830
		public const short RainbowSlimeBanner = 2966;

		// Token: 0x0400227F RID: 8831
		public const short RavenBanner = 2967;

		// Token: 0x04002280 RID: 8832
		public const short RedSlimeBanner = 2968;

		// Token: 0x04002281 RID: 8833
		public const short RuneWizardBanner = 2969;

		// Token: 0x04002282 RID: 8834
		public const short RustyArmoredBonesBanner = 2970;

		// Token: 0x04002283 RID: 8835
		public const short ScarecrowBanner = 2971;

		// Token: 0x04002284 RID: 8836
		public const short ScutlixBanner = 2972;

		// Token: 0x04002285 RID: 8837
		public const short SkeletonArcherBanner = 2973;

		// Token: 0x04002286 RID: 8838
		public const short SkeletonCommandoBanner = 2974;

		// Token: 0x04002287 RID: 8839
		public const short SkeletonSniperBanner = 2975;

		// Token: 0x04002288 RID: 8840
		public const short SlimerBanner = 2976;

		// Token: 0x04002289 RID: 8841
		public const short SnatcherBanner = 2977;

		// Token: 0x0400228A RID: 8842
		public const short SnowBallaBanner = 2978;

		// Token: 0x0400228B RID: 8843
		public const short SnowmanGangstaBanner = 2979;

		// Token: 0x0400228C RID: 8844
		public const short SpikedIceSlimeBanner = 2980;

		// Token: 0x0400228D RID: 8845
		public const short SpikedJungleSlimeBanner = 2981;

		// Token: 0x0400228E RID: 8846
		public const short SplinterlingBanner = 2982;

		// Token: 0x0400228F RID: 8847
		public const short SquidBanner = 2983;

		// Token: 0x04002290 RID: 8848
		public const short TacticalSkeletonBanner = 2984;

		// Token: 0x04002291 RID: 8849
		public const short TheGroomBanner = 2985;

		// Token: 0x04002292 RID: 8850
		public const short TimBanner = 2986;

		// Token: 0x04002293 RID: 8851
		public const short UndeadMinerBanner = 2987;

		// Token: 0x04002294 RID: 8852
		public const short UndeadVikingBanner = 2988;

		// Token: 0x04002295 RID: 8853
		public const short WhiteCultistArcherBanner = 2989;

		// Token: 0x04002296 RID: 8854
		public const short WhiteCultistCasterBanner = 2990;

		// Token: 0x04002297 RID: 8855
		public const short WhiteCultistFighterBanner = 2991;

		// Token: 0x04002298 RID: 8856
		public const short YellowSlimeBanner = 2992;

		// Token: 0x04002299 RID: 8857
		public const short YetiBanner = 2993;

		// Token: 0x0400229A RID: 8858
		public const short ZombieElfBanner = 2994;

		// Token: 0x0400229B RID: 8859
		public const short SparkyPainting = 2995;

		// Token: 0x0400229C RID: 8860
		public const short VineRope = 2996;

		// Token: 0x0400229D RID: 8861
		public const short WormholePotion = 2997;

		// Token: 0x0400229E RID: 8862
		public const short SummonerEmblem = 2998;

		// Token: 0x0400229F RID: 8863
		public const short BewitchingTable = 2999;

		// Token: 0x040022A0 RID: 8864
		public const short AlchemyTable = 3000;

		// Token: 0x040022A1 RID: 8865
		public const short StrangeBrew = 3001;

		// Token: 0x040022A2 RID: 8866
		public const short SpelunkerGlowstick = 3002;

		// Token: 0x040022A3 RID: 8867
		public const short BoneArrow = 3003;

		// Token: 0x040022A4 RID: 8868
		public const short BoneTorch = 3004;

		// Token: 0x040022A5 RID: 8869
		public const short VineRopeCoil = 3005;

		// Token: 0x040022A6 RID: 8870
		public const short SoulDrain = 3006;

		// Token: 0x040022A7 RID: 8871
		public const short DartPistol = 3007;

		// Token: 0x040022A8 RID: 8872
		public const short DartRifle = 3008;

		// Token: 0x040022A9 RID: 8873
		public const short CrystalDart = 3009;

		// Token: 0x040022AA RID: 8874
		public const short CursedDart = 3010;

		// Token: 0x040022AB RID: 8875
		public const short IchorDart = 3011;

		// Token: 0x040022AC RID: 8876
		public const short ChainGuillotines = 3012;

		// Token: 0x040022AD RID: 8877
		public const short FetidBaghnakhs = 3013;

		// Token: 0x040022AE RID: 8878
		public const short ClingerStaff = 3014;

		// Token: 0x040022AF RID: 8879
		public const short PutridScent = 3015;

		// Token: 0x040022B0 RID: 8880
		public const short FleshKnuckles = 3016;

		// Token: 0x040022B1 RID: 8881
		public const short FlowerBoots = 3017;

		// Token: 0x040022B2 RID: 8882
		public const short Seedler = 3018;

		// Token: 0x040022B3 RID: 8883
		public const short HellwingBow = 3019;

		// Token: 0x040022B4 RID: 8884
		public const short TendonHook = 3020;

		// Token: 0x040022B5 RID: 8885
		public const short ThornHook = 3021;

		// Token: 0x040022B6 RID: 8886
		public const short IlluminantHook = 3022;

		// Token: 0x040022B7 RID: 8887
		public const short WormHook = 3023;

		// Token: 0x040022B8 RID: 8888
		public const short DevDye = 3024;

		// Token: 0x040022B9 RID: 8889
		public const short PurpleOozeDye = 3025;

		// Token: 0x040022BA RID: 8890
		public const short ReflectiveSilverDye = 3026;

		// Token: 0x040022BB RID: 8891
		public const short ReflectiveGoldDye = 3027;

		// Token: 0x040022BC RID: 8892
		public const short BlueAcidDye = 3028;

		// Token: 0x040022BD RID: 8893
		public const short DaedalusStormbow = 3029;

		// Token: 0x040022BE RID: 8894
		public const short FlyingKnife = 3030;

		// Token: 0x040022BF RID: 8895
		public const short BottomlessBucket = 3031;

		// Token: 0x040022C0 RID: 8896
		public const short SuperAbsorbantSponge = 3032;

		// Token: 0x040022C1 RID: 8897
		public const short GoldRing = 3033;

		// Token: 0x040022C2 RID: 8898
		public const short CoinRing = 3034;

		// Token: 0x040022C3 RID: 8899
		public const short GreedyRing = 3035;

		// Token: 0x040022C4 RID: 8900
		public const short FishFinder = 3036;

		// Token: 0x040022C5 RID: 8901
		public const short WeatherRadio = 3037;

		// Token: 0x040022C6 RID: 8902
		public const short HadesDye = 3038;

		// Token: 0x040022C7 RID: 8903
		public const short TwilightDye = 3039;

		// Token: 0x040022C8 RID: 8904
		public const short AcidDye = 3040;

		// Token: 0x040022C9 RID: 8905
		public const short MushroomDye = 3041;

		// Token: 0x040022CA RID: 8906
		public const short PhaseDye = 3042;

		// Token: 0x040022CB RID: 8907
		public const short MagicLantern = 3043;

		// Token: 0x040022CC RID: 8908
		public const short MusicBoxLunarBoss = 3044;

		// Token: 0x040022CD RID: 8909
		public const short RainbowTorch = 3045;

		// Token: 0x040022CE RID: 8910
		public const short CursedCampfire = 3046;

		// Token: 0x040022CF RID: 8911
		public const short DemonCampfire = 3047;

		// Token: 0x040022D0 RID: 8912
		public const short FrozenCampfire = 3048;

		// Token: 0x040022D1 RID: 8913
		public const short IchorCampfire = 3049;

		// Token: 0x040022D2 RID: 8914
		public const short RainbowCampfire = 3050;

		// Token: 0x040022D3 RID: 8915
		public const short CrystalVileShard = 3051;

		// Token: 0x040022D4 RID: 8916
		public const short ShadowFlameBow = 3052;

		// Token: 0x040022D5 RID: 8917
		public const short ShadowFlameHexDoll = 3053;

		// Token: 0x040022D6 RID: 8918
		public const short ShadowFlameKnife = 3054;

		// Token: 0x040022D7 RID: 8919
		public const short PaintingAcorns = 3055;

		// Token: 0x040022D8 RID: 8920
		public const short PaintingColdSnap = 3056;

		// Token: 0x040022D9 RID: 8921
		public const short PaintingCursedSaint = 3057;

		// Token: 0x040022DA RID: 8922
		public const short PaintingSnowfellas = 3058;

		// Token: 0x040022DB RID: 8923
		public const short PaintingTheSeason = 3059;

		// Token: 0x040022DC RID: 8924
		public const short BoneRattle = 3060;

		// Token: 0x040022DD RID: 8925
		public const short ArchitectGizmoPack = 3061;

		// Token: 0x040022DE RID: 8926
		public const short CrimsonHeart = 3062;

		// Token: 0x040022DF RID: 8927
		public const short Meowmere = 3063;

		// Token: 0x040022E0 RID: 8928
		public const short Sundial = 3064;

		// Token: 0x040022E1 RID: 8929
		public const short StarWrath = 3065;

		// Token: 0x040022E2 RID: 8930
		public const short MarbleBlock = 3066;

		// Token: 0x040022E3 RID: 8931
		public const short HellstoneBrickWall = 3067;

		// Token: 0x040022E4 RID: 8932
		public const short CordageGuide = 3068;

		// Token: 0x040022E5 RID: 8933
		public const short WandofSparking = 3069;

		// Token: 0x040022E6 RID: 8934
		public const short GoldBirdCage = 3070;

		// Token: 0x040022E7 RID: 8935
		public const short GoldBunnyCage = 3071;

		// Token: 0x040022E8 RID: 8936
		public const short GoldButterflyCage = 3072;

		// Token: 0x040022E9 RID: 8937
		public const short GoldFrogCage = 3073;

		// Token: 0x040022EA RID: 8938
		public const short GoldGrasshopperCage = 3074;

		// Token: 0x040022EB RID: 8939
		public const short GoldMouseCage = 3075;

		// Token: 0x040022EC RID: 8940
		public const short GoldWormCage = 3076;

		// Token: 0x040022ED RID: 8941
		public const short SilkRope = 3077;

		// Token: 0x040022EE RID: 8942
		public const short WebRope = 3078;

		// Token: 0x040022EF RID: 8943
		public const short SilkRopeCoil = 3079;

		// Token: 0x040022F0 RID: 8944
		public const short WebRopeCoil = 3080;

		// Token: 0x040022F1 RID: 8945
		public const short Marble = 3081;

		// Token: 0x040022F2 RID: 8946
		public const short MarbleWall = 3082;

		// Token: 0x040022F3 RID: 8947
		public const short MarbleBlockWall = 3083;

		// Token: 0x040022F4 RID: 8948
		public const short Radar = 3084;

		// Token: 0x040022F5 RID: 8949
		public const short LockBox = 3085;

		// Token: 0x040022F6 RID: 8950
		public const short Granite = 3086;

		// Token: 0x040022F7 RID: 8951
		public const short GraniteBlock = 3087;

		// Token: 0x040022F8 RID: 8952
		public const short GraniteWall = 3088;

		// Token: 0x040022F9 RID: 8953
		public const short GraniteBlockWall = 3089;

		// Token: 0x040022FA RID: 8954
		public const short RoyalGel = 3090;

		// Token: 0x040022FB RID: 8955
		public const short NightKey = 3091;

		// Token: 0x040022FC RID: 8956
		public const short LightKey = 3092;

		// Token: 0x040022FD RID: 8957
		public const short HerbBag = 3093;

		// Token: 0x040022FE RID: 8958
		public const short Javelin = 3094;

		// Token: 0x040022FF RID: 8959
		public const short TallyCounter = 3095;

		// Token: 0x04002300 RID: 8960
		public const short Sextant = 3096;

		// Token: 0x04002301 RID: 8961
		public const short EoCShield = 3097;

		// Token: 0x04002302 RID: 8962
		public const short ButchersChainsaw = 3098;

		// Token: 0x04002303 RID: 8963
		public const short Stopwatch = 3099;

		// Token: 0x04002304 RID: 8964
		public const short MeteoriteBrick = 3100;

		// Token: 0x04002305 RID: 8965
		public const short MeteoriteBrickWall = 3101;

		// Token: 0x04002306 RID: 8966
		public const short MetalDetector = 3102;

		// Token: 0x04002307 RID: 8967
		public const short EndlessQuiver = 3103;

		// Token: 0x04002308 RID: 8968
		public const short EndlessMusketPouch = 3104;

		// Token: 0x04002309 RID: 8969
		public const short ToxicFlask = 3105;

		// Token: 0x0400230A RID: 8970
		public const short PsychoKnife = 3106;

		// Token: 0x0400230B RID: 8971
		public const short NailGun = 3107;

		// Token: 0x0400230C RID: 8972
		public const short Nail = 3108;

		// Token: 0x0400230D RID: 8973
		public const short NightVisionHelmet = 3109;

		// Token: 0x0400230E RID: 8974
		public const short CelestialShell = 3110;

		// Token: 0x0400230F RID: 8975
		public const short PinkGel = 3111;

		// Token: 0x04002310 RID: 8976
		public const short BouncyGlowstick = 3112;

		// Token: 0x04002311 RID: 8977
		public const short PinkSlimeBlock = 3113;

		// Token: 0x04002312 RID: 8978
		public const short PinkTorch = 3114;

		// Token: 0x04002313 RID: 8979
		public const short BouncyBomb = 3115;

		// Token: 0x04002314 RID: 8980
		public const short BouncyGrenade = 3116;

		// Token: 0x04002315 RID: 8981
		public const short PeaceCandle = 3117;

		// Token: 0x04002316 RID: 8982
		public const short LifeformAnalyzer = 3118;

		// Token: 0x04002317 RID: 8983
		public const short DPSMeter = 3119;

		// Token: 0x04002318 RID: 8984
		public const short FishermansGuide = 3120;

		// Token: 0x04002319 RID: 8985
		public const short GoblinTech = 3121;

		// Token: 0x0400231A RID: 8986
		public const short REK = 3122;

		// Token: 0x0400231B RID: 8987
		public const short PDA = 3123;

		// Token: 0x0400231C RID: 8988
		public const short CellPhone = 3124;

		// Token: 0x0400231D RID: 8989
		public const short GraniteChest = 3125;

		// Token: 0x0400231E RID: 8990
		public const short MeteoriteClock = 3126;

		// Token: 0x0400231F RID: 8991
		public const short MarbleClock = 3127;

		// Token: 0x04002320 RID: 8992
		public const short GraniteClock = 3128;

		// Token: 0x04002321 RID: 8993
		public const short MeteoriteDoor = 3129;

		// Token: 0x04002322 RID: 8994
		public const short MarbleDoor = 3130;

		// Token: 0x04002323 RID: 8995
		public const short GraniteDoor = 3131;

		// Token: 0x04002324 RID: 8996
		public const short MeteoriteDresser = 3132;

		// Token: 0x04002325 RID: 8997
		public const short MarbleDresser = 3133;

		// Token: 0x04002326 RID: 8998
		public const short GraniteDresser = 3134;

		// Token: 0x04002327 RID: 8999
		public const short MeteoriteLamp = 3135;

		// Token: 0x04002328 RID: 9000
		public const short MarbleLamp = 3136;

		// Token: 0x04002329 RID: 9001
		public const short GraniteLamp = 3137;

		// Token: 0x0400232A RID: 9002
		public const short MeteoriteLantern = 3138;

		// Token: 0x0400232B RID: 9003
		public const short MarbleLantern = 3139;

		// Token: 0x0400232C RID: 9004
		public const short GraniteLantern = 3140;

		// Token: 0x0400232D RID: 9005
		public const short MeteoritePiano = 3141;

		// Token: 0x0400232E RID: 9006
		public const short MarblePiano = 3142;

		// Token: 0x0400232F RID: 9007
		public const short GranitePiano = 3143;

		// Token: 0x04002330 RID: 9008
		public const short MeteoritePlatform = 3144;

		// Token: 0x04002331 RID: 9009
		public const short MarblePlatform = 3145;

		// Token: 0x04002332 RID: 9010
		public const short GranitePlatform = 3146;

		// Token: 0x04002333 RID: 9011
		public const short MeteoriteSink = 3147;

		// Token: 0x04002334 RID: 9012
		public const short MarbleSink = 3148;

		// Token: 0x04002335 RID: 9013
		public const short GraniteSink = 3149;

		// Token: 0x04002336 RID: 9014
		public const short MeteoriteSofa = 3150;

		// Token: 0x04002337 RID: 9015
		public const short MarbleSofa = 3151;

		// Token: 0x04002338 RID: 9016
		public const short GraniteSofa = 3152;

		// Token: 0x04002339 RID: 9017
		public const short MeteoriteTable = 3153;

		// Token: 0x0400233A RID: 9018
		public const short MarbleTable = 3154;

		// Token: 0x0400233B RID: 9019
		public const short GraniteTable = 3155;

		// Token: 0x0400233C RID: 9020
		public const short MeteoriteWorkBench = 3156;

		// Token: 0x0400233D RID: 9021
		public const short MarbleWorkBench = 3157;

		// Token: 0x0400233E RID: 9022
		public const short GraniteWorkBench = 3158;

		// Token: 0x0400233F RID: 9023
		public const short MeteoriteBathtub = 3159;

		// Token: 0x04002340 RID: 9024
		public const short MarbleBathtub = 3160;

		// Token: 0x04002341 RID: 9025
		public const short GraniteBathtub = 3161;

		// Token: 0x04002342 RID: 9026
		public const short MeteoriteBed = 3162;

		// Token: 0x04002343 RID: 9027
		public const short MarbleBed = 3163;

		// Token: 0x04002344 RID: 9028
		public const short GraniteBed = 3164;

		// Token: 0x04002345 RID: 9029
		public const short MeteoriteBookcase = 3165;

		// Token: 0x04002346 RID: 9030
		public const short MarbleBookcase = 3166;

		// Token: 0x04002347 RID: 9031
		public const short GraniteBookcase = 3167;

		// Token: 0x04002348 RID: 9032
		public const short MeteoriteCandelabra = 3168;

		// Token: 0x04002349 RID: 9033
		public const short MarbleCandelabra = 3169;

		// Token: 0x0400234A RID: 9034
		public const short GraniteCandelabra = 3170;

		// Token: 0x0400234B RID: 9035
		public const short MeteoriteCandle = 3171;

		// Token: 0x0400234C RID: 9036
		public const short MarbleCandle = 3172;

		// Token: 0x0400234D RID: 9037
		public const short GraniteCandle = 3173;

		// Token: 0x0400234E RID: 9038
		public const short MeteoriteChair = 3174;

		// Token: 0x0400234F RID: 9039
		public const short MarbleChair = 3175;

		// Token: 0x04002350 RID: 9040
		public const short GraniteChair = 3176;

		// Token: 0x04002351 RID: 9041
		public const short MeteoriteChandelier = 3177;

		// Token: 0x04002352 RID: 9042
		public const short MarbleChandelier = 3178;

		// Token: 0x04002353 RID: 9043
		public const short GraniteChandelier = 3179;

		// Token: 0x04002354 RID: 9044
		public const short MeteoriteChest = 3180;

		// Token: 0x04002355 RID: 9045
		public const short MarbleChest = 3181;

		// Token: 0x04002356 RID: 9046
		public const short MagicWaterDropper = 3182;

		// Token: 0x04002357 RID: 9047
		public const short GoldenBugNet = 3183;

		// Token: 0x04002358 RID: 9048
		public const short MagicLavaDropper = 3184;

		// Token: 0x04002359 RID: 9049
		public const short MagicHoneyDropper = 3185;

		// Token: 0x0400235A RID: 9050
		public const short EmptyDropper = 3186;

		// Token: 0x0400235B RID: 9051
		public const short GladiatorHelmet = 3187;

		// Token: 0x0400235C RID: 9052
		public const short GladiatorBreastplate = 3188;

		// Token: 0x0400235D RID: 9053
		public const short GladiatorLeggings = 3189;

		// Token: 0x0400235E RID: 9054
		public const short ReflectiveDye = 3190;

		// Token: 0x0400235F RID: 9055
		public const short EnchantedNightcrawler = 3191;

		// Token: 0x04002360 RID: 9056
		public const short Grubby = 3192;

		// Token: 0x04002361 RID: 9057
		public const short Sluggy = 3193;

		// Token: 0x04002362 RID: 9058
		public const short Buggy = 3194;

		// Token: 0x04002363 RID: 9059
		public const short GrubSoup = 3195;

		// Token: 0x04002364 RID: 9060
		public const short BombFish = 3196;

		// Token: 0x04002365 RID: 9061
		public const short FrostDaggerfish = 3197;

		// Token: 0x04002366 RID: 9062
		public const short SharpeningStation = 3198;

		// Token: 0x04002367 RID: 9063
		public const short IceMirror = 3199;

		// Token: 0x04002368 RID: 9064
		public const short SailfishBoots = 3200;

		// Token: 0x04002369 RID: 9065
		public const short TsunamiInABottle = 3201;

		// Token: 0x0400236A RID: 9066
		public const short TargetDummy = 3202;

		// Token: 0x0400236B RID: 9067
		public const short CorruptFishingCrate = 3203;

		// Token: 0x0400236C RID: 9068
		public const short CrimsonFishingCrate = 3204;

		// Token: 0x0400236D RID: 9069
		public const short DungeonFishingCrate = 3205;

		// Token: 0x0400236E RID: 9070
		public const short FloatingIslandFishingCrate = 3206;

		// Token: 0x0400236F RID: 9071
		public const short HallowedFishingCrate = 3207;

		// Token: 0x04002370 RID: 9072
		public const short JungleFishingCrate = 3208;

		// Token: 0x04002371 RID: 9073
		public const short CrystalSerpent = 3209;

		// Token: 0x04002372 RID: 9074
		public const short Toxikarp = 3210;

		// Token: 0x04002373 RID: 9075
		public const short Bladetongue = 3211;

		// Token: 0x04002374 RID: 9076
		public const short SharkToothNecklace = 3212;

		// Token: 0x04002375 RID: 9077
		public const short MoneyTrough = 3213;

		// Token: 0x04002376 RID: 9078
		public const short Bubble = 3214;

		// Token: 0x04002377 RID: 9079
		public const short DayBloomPlanterBox = 3215;

		// Token: 0x04002378 RID: 9080
		public const short MoonglowPlanterBox = 3216;

		// Token: 0x04002379 RID: 9081
		public const short CorruptPlanterBox = 3217;

		// Token: 0x0400237A RID: 9082
		public const short CrimsonPlanterBox = 3218;

		// Token: 0x0400237B RID: 9083
		public const short BlinkrootPlanterBox = 3219;

		// Token: 0x0400237C RID: 9084
		public const short WaterleafPlanterBox = 3220;

		// Token: 0x0400237D RID: 9085
		public const short ShiverthornPlanterBox = 3221;

		// Token: 0x0400237E RID: 9086
		public const short FireBlossomPlanterBox = 3222;

		// Token: 0x0400237F RID: 9087
		public const short BrainOfConfusion = 3223;

		// Token: 0x04002380 RID: 9088
		public const short WormScarf = 3224;

		// Token: 0x04002381 RID: 9089
		public const short BalloonPufferfish = 3225;

		// Token: 0x04002382 RID: 9090
		public const short BejeweledValkyrieHead = 3226;

		// Token: 0x04002383 RID: 9091
		public const short BejeweledValkyrieBody = 3227;

		// Token: 0x04002384 RID: 9092
		public const short BejeweledValkyrieWing = 3228;

		// Token: 0x04002385 RID: 9093
		public const short RichGravestone1 = 3229;

		// Token: 0x04002386 RID: 9094
		public const short RichGravestone2 = 3230;

		// Token: 0x04002387 RID: 9095
		public const short RichGravestone3 = 3231;

		// Token: 0x04002388 RID: 9096
		public const short RichGravestone4 = 3232;

		// Token: 0x04002389 RID: 9097
		public const short RichGravestone5 = 3233;

		// Token: 0x0400238A RID: 9098
		public const short CrystalBlock = 3234;

		// Token: 0x0400238B RID: 9099
		public const short MusicBoxMartians = 3235;

		// Token: 0x0400238C RID: 9100
		public const short MusicBoxPirates = 3236;

		// Token: 0x0400238D RID: 9101
		public const short MusicBoxHell = 3237;

		// Token: 0x0400238E RID: 9102
		public const short CrystalBlockWall = 3238;

		// Token: 0x0400238F RID: 9103
		public const short Trapdoor = 3239;

		// Token: 0x04002390 RID: 9104
		public const short TallGate = 3240;

		// Token: 0x04002391 RID: 9105
		public const short SharkronBalloon = 3241;

		// Token: 0x04002392 RID: 9106
		public const short TaxCollectorHat = 3242;

		// Token: 0x04002393 RID: 9107
		public const short TaxCollectorSuit = 3243;

		// Token: 0x04002394 RID: 9108
		public const short TaxCollectorPants = 3244;

		// Token: 0x04002395 RID: 9109
		public const short BoneGlove = 3245;

		// Token: 0x04002396 RID: 9110
		public const short ClothierJacket = 3246;

		// Token: 0x04002397 RID: 9111
		public const short ClothierPants = 3247;

		// Token: 0x04002398 RID: 9112
		public const short DyeTraderTurban = 3248;

		// Token: 0x04002399 RID: 9113
		public const short DeadlySphereStaff = 3249;

		// Token: 0x0400239A RID: 9114
		public const short BalloonHorseshoeFart = 3250;

		// Token: 0x0400239B RID: 9115
		public const short BalloonHorseshoeHoney = 3251;

		// Token: 0x0400239C RID: 9116
		public const short BalloonHorseshoeSharkron = 3252;

		// Token: 0x0400239D RID: 9117
		public const short LavaLamp = 3253;

		// Token: 0x0400239E RID: 9118
		public const short CageEnchantedNightcrawler = 3254;

		// Token: 0x0400239F RID: 9119
		public const short CageBuggy = 3255;

		// Token: 0x040023A0 RID: 9120
		public const short CageGrubby = 3256;

		// Token: 0x040023A1 RID: 9121
		public const short CageSluggy = 3257;

		// Token: 0x040023A2 RID: 9122
		public const short SlapHand = 3258;

		// Token: 0x040023A3 RID: 9123
		public const short TwilightHairDye = 3259;

		// Token: 0x040023A4 RID: 9124
		public const short BlessedApple = 3260;

		// Token: 0x040023A5 RID: 9125
		public const short SpectreBar = 3261;

		// Token: 0x040023A6 RID: 9126
		public const short Code1 = 3262;

		// Token: 0x040023A7 RID: 9127
		public const short BuccaneerBandana = 3263;

		// Token: 0x040023A8 RID: 9128
		public const short BuccaneerShirt = 3264;

		// Token: 0x040023A9 RID: 9129
		public const short BuccaneerPants = 3265;

		// Token: 0x040023AA RID: 9130
		public const short ObsidianHelm = 3266;

		// Token: 0x040023AB RID: 9131
		public const short ObsidianShirt = 3267;

		// Token: 0x040023AC RID: 9132
		public const short ObsidianPants = 3268;

		// Token: 0x040023AD RID: 9133
		public const short MedusaHead = 3269;

		// Token: 0x040023AE RID: 9134
		public const short ItemFrame = 3270;

		// Token: 0x040023AF RID: 9135
		public const short Sandstone = 3271;

		// Token: 0x040023B0 RID: 9136
		public const short HardenedSand = 3272;

		// Token: 0x040023B1 RID: 9137
		public const short SandstoneWall = 3273;

		// Token: 0x040023B2 RID: 9138
		public const short CorruptHardenedSand = 3274;

		// Token: 0x040023B3 RID: 9139
		public const short CrimsonHardenedSand = 3275;

		// Token: 0x040023B4 RID: 9140
		public const short CorruptSandstone = 3276;

		// Token: 0x040023B5 RID: 9141
		public const short CrimsonSandstone = 3277;

		// Token: 0x040023B6 RID: 9142
		public const short WoodYoyo = 3278;

		// Token: 0x040023B7 RID: 9143
		public const short CorruptYoyo = 3279;

		// Token: 0x040023B8 RID: 9144
		public const short CrimsonYoyo = 3280;

		// Token: 0x040023B9 RID: 9145
		public const short JungleYoyo = 3281;

		// Token: 0x040023BA RID: 9146
		public const short Cascade = 3282;

		// Token: 0x040023BB RID: 9147
		public const short Chik = 3283;

		// Token: 0x040023BC RID: 9148
		public const short Code2 = 3284;

		// Token: 0x040023BD RID: 9149
		public const short Rally = 3285;

		// Token: 0x040023BE RID: 9150
		public const short Yelets = 3286;

		// Token: 0x040023BF RID: 9151
		public const short RedsYoyo = 3287;

		// Token: 0x040023C0 RID: 9152
		public const short ValkyrieYoyo = 3288;

		// Token: 0x040023C1 RID: 9153
		public const short Amarok = 3289;

		// Token: 0x040023C2 RID: 9154
		public const short HelFire = 3290;

		// Token: 0x040023C3 RID: 9155
		public const short Kraken = 3291;

		// Token: 0x040023C4 RID: 9156
		public const short TheEyeOfCthulhu = 3292;

		// Token: 0x040023C5 RID: 9157
		public const short RedString = 3293;

		// Token: 0x040023C6 RID: 9158
		public const short OrangeString = 3294;

		// Token: 0x040023C7 RID: 9159
		public const short YellowString = 3295;

		// Token: 0x040023C8 RID: 9160
		public const short LimeString = 3296;

		// Token: 0x040023C9 RID: 9161
		public const short GreenString = 3297;

		// Token: 0x040023CA RID: 9162
		public const short TealString = 3298;

		// Token: 0x040023CB RID: 9163
		public const short CyanString = 3299;

		// Token: 0x040023CC RID: 9164
		public const short SkyBlueString = 3300;

		// Token: 0x040023CD RID: 9165
		public const short BlueString = 3301;

		// Token: 0x040023CE RID: 9166
		public const short PurpleString = 3302;

		// Token: 0x040023CF RID: 9167
		public const short VioletString = 3303;

		// Token: 0x040023D0 RID: 9168
		public const short PinkString = 3304;

		// Token: 0x040023D1 RID: 9169
		public const short BrownString = 3305;

		// Token: 0x040023D2 RID: 9170
		public const short WhiteString = 3306;

		// Token: 0x040023D3 RID: 9171
		public const short RainbowString = 3307;

		// Token: 0x040023D4 RID: 9172
		public const short BlackString = 3308;

		// Token: 0x040023D5 RID: 9173
		public const short BlackCounterweight = 3309;

		// Token: 0x040023D6 RID: 9174
		public const short BlueCounterweight = 3310;

		// Token: 0x040023D7 RID: 9175
		public const short GreenCounterweight = 3311;

		// Token: 0x040023D8 RID: 9176
		public const short PurpleCounterweight = 3312;

		// Token: 0x040023D9 RID: 9177
		public const short RedCounterweight = 3313;

		// Token: 0x040023DA RID: 9178
		public const short YellowCounterweight = 3314;

		// Token: 0x040023DB RID: 9179
		public const short FormatC = 3315;

		// Token: 0x040023DC RID: 9180
		public const short Gradient = 3316;

		// Token: 0x040023DD RID: 9181
		public const short Valor = 3317;

		// Token: 0x040023DE RID: 9182
		public const short KingSlimeBossBag = 3318;

		// Token: 0x040023DF RID: 9183
		public const short EyeOfCthulhuBossBag = 3319;

		// Token: 0x040023E0 RID: 9184
		public const short EaterOfWorldsBossBag = 3320;

		// Token: 0x040023E1 RID: 9185
		public const short BrainOfCthulhuBossBag = 3321;

		// Token: 0x040023E2 RID: 9186
		public const short QueenBeeBossBag = 3322;

		// Token: 0x040023E3 RID: 9187
		public const short SkeletronBossBag = 3323;

		// Token: 0x040023E4 RID: 9188
		public const short WallOfFleshBossBag = 3324;

		// Token: 0x040023E5 RID: 9189
		public const short DestroyerBossBag = 3325;

		// Token: 0x040023E6 RID: 9190
		public const short TwinsBossBag = 3326;

		// Token: 0x040023E7 RID: 9191
		public const short SkeletronPrimeBossBag = 3327;

		// Token: 0x040023E8 RID: 9192
		public const short PlanteraBossBag = 3328;

		// Token: 0x040023E9 RID: 9193
		public const short GolemBossBag = 3329;

		// Token: 0x040023EA RID: 9194
		public const short FishronBossBag = 3330;

		// Token: 0x040023EB RID: 9195
		public const short CultistBossBag = 3331;

		// Token: 0x040023EC RID: 9196
		public const short MoonLordBossBag = 3332;

		// Token: 0x040023ED RID: 9197
		public const short HiveBackpack = 3333;

		// Token: 0x040023EE RID: 9198
		public const short YoYoGlove = 3334;

		// Token: 0x040023EF RID: 9199
		public const short DemonHeart = 3335;

		// Token: 0x040023F0 RID: 9200
		public const short SporeSac = 3336;

		// Token: 0x040023F1 RID: 9201
		public const short ShinyStone = 3337;

		// Token: 0x040023F2 RID: 9202
		public const short HallowHardenedSand = 3338;

		// Token: 0x040023F3 RID: 9203
		public const short HallowSandstone = 3339;

		// Token: 0x040023F4 RID: 9204
		public const short HardenedSandWall = 3340;

		// Token: 0x040023F5 RID: 9205
		public const short CorruptHardenedSandWall = 3341;

		// Token: 0x040023F6 RID: 9206
		public const short CrimsonHardenedSandWall = 3342;

		// Token: 0x040023F7 RID: 9207
		public const short HallowHardenedSandWall = 3343;

		// Token: 0x040023F8 RID: 9208
		public const short CorruptSandstoneWall = 3344;

		// Token: 0x040023F9 RID: 9209
		public const short CrimsonSandstoneWall = 3345;

		// Token: 0x040023FA RID: 9210
		public const short HallowSandstoneWall = 3346;

		// Token: 0x040023FB RID: 9211
		public const short DesertFossil = 3347;

		// Token: 0x040023FC RID: 9212
		public const short DesertFossilWall = 3348;

		// Token: 0x040023FD RID: 9213
		public const short DyeTradersScimitar = 3349;

		// Token: 0x040023FE RID: 9214
		public const short PainterPaintballGun = 3350;

		// Token: 0x040023FF RID: 9215
		public const short TaxCollectorsStickOfDoom = 3351;

		// Token: 0x04002400 RID: 9216
		public const short StylistKilLaKillScissorsIWish = 3352;

		// Token: 0x04002401 RID: 9217
		public const short MinecartMech = 3353;

		// Token: 0x04002402 RID: 9218
		public const short MechanicalWheelPiece = 3354;

		// Token: 0x04002403 RID: 9219
		public const short MechanicalWagonPiece = 3355;

		// Token: 0x04002404 RID: 9220
		public const short MechanicalBatteryPiece = 3356;

		// Token: 0x04002405 RID: 9221
		public const short AncientCultistTrophy = 3357;

		// Token: 0x04002406 RID: 9222
		public const short MartianSaucerTrophy = 3358;

		// Token: 0x04002407 RID: 9223
		public const short FlyingDutchmanTrophy = 3359;

		// Token: 0x04002408 RID: 9224
		public const short LivingMahoganyWand = 3360;

		// Token: 0x04002409 RID: 9225
		public const short LivingMahoganyLeafWand = 3361;

		// Token: 0x0400240A RID: 9226
		public const short FallenTuxedoShirt = 3362;

		// Token: 0x0400240B RID: 9227
		public const short FallenTuxedoPants = 3363;

		// Token: 0x0400240C RID: 9228
		public const short Fireplace = 3364;

		// Token: 0x0400240D RID: 9229
		public const short Chimney = 3365;

		// Token: 0x0400240E RID: 9230
		public const short YoyoBag = 3366;

		// Token: 0x0400240F RID: 9231
		public const short ShrimpyTruffle = 3367;

		// Token: 0x04002410 RID: 9232
		public const short Arkhalis = 3368;

		// Token: 0x04002411 RID: 9233
		public const short ConfettiCannon = 3369;

		// Token: 0x04002412 RID: 9234
		public const short MusicBoxTowers = 3370;

		// Token: 0x04002413 RID: 9235
		public const short MusicBoxGoblins = 3371;

		// Token: 0x04002414 RID: 9236
		public const short BossMaskCultist = 3372;

		// Token: 0x04002415 RID: 9237
		public const short BossMaskMoonlord = 3373;

		// Token: 0x04002416 RID: 9238
		public const short FossilHelm = 3374;

		// Token: 0x04002417 RID: 9239
		public const short FossilShirt = 3375;

		// Token: 0x04002418 RID: 9240
		public const short FossilPants = 3376;

		// Token: 0x04002419 RID: 9241
		public const short AmberStaff = 3377;

		// Token: 0x0400241A RID: 9242
		public const short BoneJavelin = 3378;

		// Token: 0x0400241B RID: 9243
		public const short BoneDagger = 3379;

		// Token: 0x0400241C RID: 9244
		public const short FossilOre = 3380;

		// Token: 0x0400241D RID: 9245
		public const short StardustHelmet = 3381;

		// Token: 0x0400241E RID: 9246
		public const short StardustBreastplate = 3382;

		// Token: 0x0400241F RID: 9247
		public const short StardustLeggings = 3383;

		// Token: 0x04002420 RID: 9248
		public const short PortalGun = 3384;

		// Token: 0x04002421 RID: 9249
		public const short StrangePlant1 = 3385;

		// Token: 0x04002422 RID: 9250
		public const short StrangePlant2 = 3386;

		// Token: 0x04002423 RID: 9251
		public const short StrangePlant3 = 3387;

		// Token: 0x04002424 RID: 9252
		public const short StrangePlant4 = 3388;

		// Token: 0x04002425 RID: 9253
		public const short Terrarian = 3389;

		// Token: 0x04002426 RID: 9254
		public const short GoblinSummonerBanner = 3390;

		// Token: 0x04002427 RID: 9255
		public const short SalamanderBanner = 3391;

		// Token: 0x04002428 RID: 9256
		public const short GiantShellyBanner = 3392;

		// Token: 0x04002429 RID: 9257
		public const short CrawdadBanner = 3393;

		// Token: 0x0400242A RID: 9258
		public const short FritzBanner = 3394;

		// Token: 0x0400242B RID: 9259
		public const short CreatureFromTheDeepBanner = 3395;

		// Token: 0x0400242C RID: 9260
		public const short DrManFlyBanner = 3396;

		// Token: 0x0400242D RID: 9261
		public const short MothronBanner = 3397;

		// Token: 0x0400242E RID: 9262
		public const short SeveredHandBanner = 3398;

		// Token: 0x0400242F RID: 9263
		public const short ThePossessedBanner = 3399;

		// Token: 0x04002430 RID: 9264
		public const short ButcherBanner = 3400;

		// Token: 0x04002431 RID: 9265
		public const short PsychoBanner = 3401;

		// Token: 0x04002432 RID: 9266
		public const short DeadlySphereBanner = 3402;

		// Token: 0x04002433 RID: 9267
		public const short NailheadBanner = 3403;

		// Token: 0x04002434 RID: 9268
		public const short PoisonousSporeBanner = 3404;

		// Token: 0x04002435 RID: 9269
		public const short MedusaBanner = 3405;

		// Token: 0x04002436 RID: 9270
		public const short GreekSkeletonBanner = 3406;

		// Token: 0x04002437 RID: 9271
		public const short GraniteFlyerBanner = 3407;

		// Token: 0x04002438 RID: 9272
		public const short GraniteGolemBanner = 3408;

		// Token: 0x04002439 RID: 9273
		public const short BloodZombieBanner = 3409;

		// Token: 0x0400243A RID: 9274
		public const short DripplerBanner = 3410;

		// Token: 0x0400243B RID: 9275
		public const short TombCrawlerBanner = 3411;

		// Token: 0x0400243C RID: 9276
		public const short DuneSplicerBanner = 3412;

		// Token: 0x0400243D RID: 9277
		public const short FlyingAntlionBanner = 3413;

		// Token: 0x0400243E RID: 9278
		public const short WalkingAntlionBanner = 3414;

		// Token: 0x0400243F RID: 9279
		public const short DesertGhoulBanner = 3415;

		// Token: 0x04002440 RID: 9280
		public const short DesertLamiaBanner = 3416;

		// Token: 0x04002441 RID: 9281
		public const short DesertDjinnBanner = 3417;

		// Token: 0x04002442 RID: 9282
		public const short DesertBasiliskBanner = 3418;

		// Token: 0x04002443 RID: 9283
		public const short RavagerScorpionBanner = 3419;

		// Token: 0x04002444 RID: 9284
		public const short StardustSoldierBanner = 3420;

		// Token: 0x04002445 RID: 9285
		public const short StardustWormBanner = 3421;

		// Token: 0x04002446 RID: 9286
		public const short StardustJellyfishBanner = 3422;

		// Token: 0x04002447 RID: 9287
		public const short StardustSpiderBanner = 3423;

		// Token: 0x04002448 RID: 9288
		public const short StardustSmallCellBanner = 3424;

		// Token: 0x04002449 RID: 9289
		public const short StardustLargeCellBanner = 3425;

		// Token: 0x0400244A RID: 9290
		public const short SolarCoriteBanner = 3426;

		// Token: 0x0400244B RID: 9291
		public const short SolarSrollerBanner = 3427;

		// Token: 0x0400244C RID: 9292
		public const short SolarCrawltipedeBanner = 3428;

		// Token: 0x0400244D RID: 9293
		public const short SolarDrakomireRiderBanner = 3429;

		// Token: 0x0400244E RID: 9294
		public const short SolarDrakomireBanner = 3430;

		// Token: 0x0400244F RID: 9295
		public const short SolarSolenianBanner = 3431;

		// Token: 0x04002450 RID: 9296
		public const short NebulaSoldierBanner = 3432;

		// Token: 0x04002451 RID: 9297
		public const short NebulaHeadcrabBanner = 3433;

		// Token: 0x04002452 RID: 9298
		public const short NebulaBrainBanner = 3434;

		// Token: 0x04002453 RID: 9299
		public const short NebulaBeastBanner = 3435;

		// Token: 0x04002454 RID: 9300
		public const short VortexLarvaBanner = 3436;

		// Token: 0x04002455 RID: 9301
		public const short VortexHornetQueenBanner = 3437;

		// Token: 0x04002456 RID: 9302
		public const short VortexHornetBanner = 3438;

		// Token: 0x04002457 RID: 9303
		public const short VortexSoldierBanner = 3439;

		// Token: 0x04002458 RID: 9304
		public const short VortexRiflemanBanner = 3440;

		// Token: 0x04002459 RID: 9305
		public const short PirateCaptainBanner = 3441;

		// Token: 0x0400245A RID: 9306
		public const short PirateDeadeyeBanner = 3442;

		// Token: 0x0400245B RID: 9307
		public const short PirateCorsairBanner = 3443;

		// Token: 0x0400245C RID: 9308
		public const short PirateCrossbowerBanner = 3444;

		// Token: 0x0400245D RID: 9309
		public const short MartianWalkerBanner = 3445;

		// Token: 0x0400245E RID: 9310
		public const short RedDevilBanner = 3446;

		// Token: 0x0400245F RID: 9311
		public const short PinkJellyfishBanner = 3447;

		// Token: 0x04002460 RID: 9312
		public const short GreenJellyfishBanner = 3448;

		// Token: 0x04002461 RID: 9313
		public const short DarkMummyBanner = 3449;

		// Token: 0x04002462 RID: 9314
		public const short LightMummyBanner = 3450;

		// Token: 0x04002463 RID: 9315
		public const short AngryBonesBanner = 3451;

		// Token: 0x04002464 RID: 9316
		public const short IceTortoiseBanner = 3452;

		// Token: 0x04002465 RID: 9317
		public const short NebulaPickup1 = 3453;

		// Token: 0x04002466 RID: 9318
		public const short NebulaPickup2 = 3454;

		// Token: 0x04002467 RID: 9319
		public const short NebulaPickup3 = 3455;

		// Token: 0x04002468 RID: 9320
		public const short FragmentVortex = 3456;

		// Token: 0x04002469 RID: 9321
		public const short FragmentNebula = 3457;

		// Token: 0x0400246A RID: 9322
		public const short FragmentSolar = 3458;

		// Token: 0x0400246B RID: 9323
		public const short FragmentStardust = 3459;

		// Token: 0x0400246C RID: 9324
		public const short LunarOre = 3460;

		// Token: 0x0400246D RID: 9325
		public const short LunarBrick = 3461;

		// Token: 0x0400246E RID: 9326
		public const short StardustAxe = 3462;

		// Token: 0x0400246F RID: 9327
		public const short StardustChainsaw = 3463;

		// Token: 0x04002470 RID: 9328
		public const short StardustDrill = 3464;

		// Token: 0x04002471 RID: 9329
		public const short StardustHammer = 3465;

		// Token: 0x04002472 RID: 9330
		public const short StardustPickaxe = 3466;

		// Token: 0x04002473 RID: 9331
		public const short LunarBar = 3467;

		// Token: 0x04002474 RID: 9332
		public const short WingsSolar = 3468;

		// Token: 0x04002475 RID: 9333
		public const short WingsVortex = 3469;

		// Token: 0x04002476 RID: 9334
		public const short WingsNebula = 3470;

		// Token: 0x04002477 RID: 9335
		public const short WingsStardust = 3471;

		// Token: 0x04002478 RID: 9336
		public const short LunarBrickWall = 3472;

		// Token: 0x04002479 RID: 9337
		public const short SolarEruption = 3473;

		// Token: 0x0400247A RID: 9338
		public const short StardustCellStaff = 3474;

		// Token: 0x0400247B RID: 9339
		public const short VortexBeater = 3475;

		// Token: 0x0400247C RID: 9340
		public const short NebulaArcanum = 3476;

		// Token: 0x0400247D RID: 9341
		public const short BloodWater = 3477;

		// Token: 0x0400247E RID: 9342
		public const short TheBrideHat = 3478;

		// Token: 0x0400247F RID: 9343
		public const short TheBrideDress = 3479;

		// Token: 0x04002480 RID: 9344
		public const short PlatinumBow = 3480;

		// Token: 0x04002481 RID: 9345
		public const short PlatinumHammer = 3481;

		// Token: 0x04002482 RID: 9346
		public const short PlatinumAxe = 3482;

		// Token: 0x04002483 RID: 9347
		public const short PlatinumShortsword = 3483;

		// Token: 0x04002484 RID: 9348
		public const short PlatinumBroadsword = 3484;

		// Token: 0x04002485 RID: 9349
		public const short PlatinumPickaxe = 3485;

		// Token: 0x04002486 RID: 9350
		public const short TungstenBow = 3486;

		// Token: 0x04002487 RID: 9351
		public const short TungstenHammer = 3487;

		// Token: 0x04002488 RID: 9352
		public const short TungstenAxe = 3488;

		// Token: 0x04002489 RID: 9353
		public const short TungstenShortsword = 3489;

		// Token: 0x0400248A RID: 9354
		public const short TungstenBroadsword = 3490;

		// Token: 0x0400248B RID: 9355
		public const short TungstenPickaxe = 3491;

		// Token: 0x0400248C RID: 9356
		public const short LeadBow = 3492;

		// Token: 0x0400248D RID: 9357
		public const short LeadHammer = 3493;

		// Token: 0x0400248E RID: 9358
		public const short LeadAxe = 3494;

		// Token: 0x0400248F RID: 9359
		public const short LeadShortsword = 3495;

		// Token: 0x04002490 RID: 9360
		public const short LeadBroadsword = 3496;

		// Token: 0x04002491 RID: 9361
		public const short LeadPickaxe = 3497;

		// Token: 0x04002492 RID: 9362
		public const short TinBow = 3498;

		// Token: 0x04002493 RID: 9363
		public const short TinHammer = 3499;

		// Token: 0x04002494 RID: 9364
		public const short TinAxe = 3500;

		// Token: 0x04002495 RID: 9365
		public const short TinShortsword = 3501;

		// Token: 0x04002496 RID: 9366
		public const short TinBroadsword = 3502;

		// Token: 0x04002497 RID: 9367
		public const short TinPickaxe = 3503;

		// Token: 0x04002498 RID: 9368
		public const short CopperBow = 3504;

		// Token: 0x04002499 RID: 9369
		public const short CopperHammer = 3505;

		// Token: 0x0400249A RID: 9370
		public const short CopperAxe = 3506;

		// Token: 0x0400249B RID: 9371
		public const short CopperShortsword = 3507;

		// Token: 0x0400249C RID: 9372
		public const short CopperBroadsword = 3508;

		// Token: 0x0400249D RID: 9373
		public const short CopperPickaxe = 3509;

		// Token: 0x0400249E RID: 9374
		public const short SilverBow = 3510;

		// Token: 0x0400249F RID: 9375
		public const short SilverHammer = 3511;

		// Token: 0x040024A0 RID: 9376
		public const short SilverAxe = 3512;

		// Token: 0x040024A1 RID: 9377
		public const short SilverShortsword = 3513;

		// Token: 0x040024A2 RID: 9378
		public const short SilverBroadsword = 3514;

		// Token: 0x040024A3 RID: 9379
		public const short SilverPickaxe = 3515;

		// Token: 0x040024A4 RID: 9380
		public const short GoldBow = 3516;

		// Token: 0x040024A5 RID: 9381
		public const short GoldHammer = 3517;

		// Token: 0x040024A6 RID: 9382
		public const short GoldAxe = 3518;

		// Token: 0x040024A7 RID: 9383
		public const short GoldShortsword = 3519;

		// Token: 0x040024A8 RID: 9384
		public const short GoldBroadsword = 3520;

		// Token: 0x040024A9 RID: 9385
		public const short GoldPickaxe = 3521;

		// Token: 0x040024AA RID: 9386
		public const short LunarHamaxeSolar = 3522;

		// Token: 0x040024AB RID: 9387
		public const short LunarHamaxeVortex = 3523;

		// Token: 0x040024AC RID: 9388
		public const short LunarHamaxeNebula = 3524;

		// Token: 0x040024AD RID: 9389
		public const short LunarHamaxeStardust = 3525;

		// Token: 0x040024AE RID: 9390
		public const short SolarDye = 3526;

		// Token: 0x040024AF RID: 9391
		public const short NebulaDye = 3527;

		// Token: 0x040024B0 RID: 9392
		public const short VortexDye = 3528;

		// Token: 0x040024B1 RID: 9393
		public const short StardustDye = 3529;

		// Token: 0x040024B2 RID: 9394
		public const short VoidDye = 3530;

		// Token: 0x040024B3 RID: 9395
		public const short StardustDragonStaff = 3531;

		// Token: 0x040024B4 RID: 9396
		public const short Bacon = 3532;

		// Token: 0x040024B5 RID: 9397
		public const short ShiftingSandsDye = 3533;

		// Token: 0x040024B6 RID: 9398
		public const short MirageDye = 3534;

		// Token: 0x040024B7 RID: 9399
		public const short ShiftingPearlSandsDye = 3535;

		// Token: 0x040024B8 RID: 9400
		public const short VortexMonolith = 3536;

		// Token: 0x040024B9 RID: 9401
		public const short NebulaMonolith = 3537;

		// Token: 0x040024BA RID: 9402
		public const short StardustMonolith = 3538;

		// Token: 0x040024BB RID: 9403
		public const short SolarMonolith = 3539;

		// Token: 0x040024BC RID: 9404
		public const short Phantasm = 3540;

		// Token: 0x040024BD RID: 9405
		public const short LastPrism = 3541;

		// Token: 0x040024BE RID: 9406
		public const short NebulaBlaze = 3542;

		// Token: 0x040024BF RID: 9407
		public const short DayBreak = 3543;

		// Token: 0x040024C0 RID: 9408
		public const short SuperHealingPotion = 3544;

		// Token: 0x040024C1 RID: 9409
		public const short Detonator = 3545;

		// Token: 0x040024C2 RID: 9410
		public const short FireworksLauncher = 3546;

		// Token: 0x040024C3 RID: 9411
		public const short BouncyDynamite = 3547;

		// Token: 0x040024C4 RID: 9412
		public const short PartyGirlGrenade = 3548;

		// Token: 0x040024C5 RID: 9413
		public const short LunarCraftingStation = 3549;

		// Token: 0x040024C6 RID: 9414
		public const short FlameAndSilverDye = 3550;

		// Token: 0x040024C7 RID: 9415
		public const short GreenFlameAndSilverDye = 3551;

		// Token: 0x040024C8 RID: 9416
		public const short BlueFlameAndSilverDye = 3552;

		// Token: 0x040024C9 RID: 9417
		public const short ReflectiveCopperDye = 3553;

		// Token: 0x040024CA RID: 9418
		public const short ReflectiveObsidianDye = 3554;

		// Token: 0x040024CB RID: 9419
		public const short ReflectiveMetalDye = 3555;

		// Token: 0x040024CC RID: 9420
		public const short MidnightRainbowDye = 3556;

		// Token: 0x040024CD RID: 9421
		public const short BlackAndWhiteDye = 3557;

		// Token: 0x040024CE RID: 9422
		public const short BrightSilverDye = 3558;

		// Token: 0x040024CF RID: 9423
		public const short SilverAndBlackDye = 3559;

		// Token: 0x040024D0 RID: 9424
		public const short RedAcidDye = 3560;

		// Token: 0x040024D1 RID: 9425
		public const short GelDye = 3561;

		// Token: 0x040024D2 RID: 9426
		public const short PinkGelDye = 3562;

		// Token: 0x040024D3 RID: 9427
		public const short SquirrelRed = 3563;

		// Token: 0x040024D4 RID: 9428
		public const short SquirrelGold = 3564;

		// Token: 0x040024D5 RID: 9429
		public const short SquirrelOrangeCage = 3565;

		// Token: 0x040024D6 RID: 9430
		public const short SquirrelGoldCage = 3566;

		// Token: 0x040024D7 RID: 9431
		public const short MoonlordBullet = 3567;

		// Token: 0x040024D8 RID: 9432
		public const short MoonlordArrow = 3568;

		// Token: 0x040024D9 RID: 9433
		public const short MoonlordTurretStaff = 3569;

		// Token: 0x040024DA RID: 9434
		public const short LunarFlareBook = 3570;

		// Token: 0x040024DB RID: 9435
		public const short RainbowCrystalStaff = 3571;

		// Token: 0x040024DC RID: 9436
		public const short LunarHook = 3572;

		// Token: 0x040024DD RID: 9437
		public const short LunarBlockSolar = 3573;

		// Token: 0x040024DE RID: 9438
		public const short LunarBlockVortex = 3574;

		// Token: 0x040024DF RID: 9439
		public const short LunarBlockNebula = 3575;

		// Token: 0x040024E0 RID: 9440
		public const short LunarBlockStardust = 3576;

		// Token: 0x040024E1 RID: 9441
		public const short SuspiciousLookingTentacle = 3577;

		// Token: 0x040024E2 RID: 9442
		public const short Yoraiz0rShirt = 3578;

		// Token: 0x040024E3 RID: 9443
		public const short Yoraiz0rPants = 3579;

		// Token: 0x040024E4 RID: 9444
		public const short Yoraiz0rWings = 3580;

		// Token: 0x040024E5 RID: 9445
		public const short Yoraiz0rDarkness = 3581;

		// Token: 0x040024E6 RID: 9446
		public const short JimsWings = 3582;

		// Token: 0x040024E7 RID: 9447
		public const short Yoraiz0rHead = 3583;

		// Token: 0x040024E8 RID: 9448
		public const short LivingLeafWall = 3584;

		// Token: 0x040024E9 RID: 9449
		public const short SkiphsHelm = 3585;

		// Token: 0x040024EA RID: 9450
		public const short SkiphsShirt = 3586;

		// Token: 0x040024EB RID: 9451
		public const short SkiphsPants = 3587;

		// Token: 0x040024EC RID: 9452
		public const short SkiphsWings = 3588;

		// Token: 0x040024ED RID: 9453
		public const short LokisHelm = 3589;

		// Token: 0x040024EE RID: 9454
		public const short LokisShirt = 3590;

		// Token: 0x040024EF RID: 9455
		public const short LokisPants = 3591;

		// Token: 0x040024F0 RID: 9456
		public const short LokisWings = 3592;

		// Token: 0x040024F1 RID: 9457
		public const short SandSlimeBanner = 3593;

		// Token: 0x040024F2 RID: 9458
		public const short SeaSnailBanner = 3594;

		// Token: 0x040024F3 RID: 9459
		public const short MoonLordTrophy = 3595;

		// Token: 0x040024F4 RID: 9460
		public const short MoonLordPainting = 3596;

		// Token: 0x040024F5 RID: 9461
		public const short BurningHadesDye = 3597;

		// Token: 0x040024F6 RID: 9462
		public const short GrimDye = 3598;

		// Token: 0x040024F7 RID: 9463
		public const short LokisDye = 3599;

		// Token: 0x040024F8 RID: 9464
		public const short ShadowflameHadesDye = 3600;

		// Token: 0x040024F9 RID: 9465
		public const short CelestialSigil = 3601;

		// Token: 0x040024FA RID: 9466
		public const short LogicGateLamp_Off = 3602;

		// Token: 0x040024FB RID: 9467
		public const short LogicGate_AND = 3603;

		// Token: 0x040024FC RID: 9468
		public const short LogicGate_OR = 3604;

		// Token: 0x040024FD RID: 9469
		public const short LogicGate_NAND = 3605;

		// Token: 0x040024FE RID: 9470
		public const short LogicGate_NOR = 3606;

		// Token: 0x040024FF RID: 9471
		public const short LogicGate_XOR = 3607;

		// Token: 0x04002500 RID: 9472
		public const short LogicGate_NXOR = 3608;

		// Token: 0x04002501 RID: 9473
		public const short ConveyorBeltLeft = 3609;

		// Token: 0x04002502 RID: 9474
		public const short ConveyorBeltRight = 3610;

		// Token: 0x04002503 RID: 9475
		public const short WireKite = 3611;

		// Token: 0x04002504 RID: 9476
		public const short YellowWrench = 3612;

		// Token: 0x04002505 RID: 9477
		public const short LogicSensor_Sun = 3613;

		// Token: 0x04002506 RID: 9478
		public const short LogicSensor_Moon = 3614;

		// Token: 0x04002507 RID: 9479
		public const short LogicSensor_Above = 3615;

		// Token: 0x04002508 RID: 9480
		public const short WirePipe = 3616;

		// Token: 0x04002509 RID: 9481
		public const short AnnouncementBox = 3617;

		// Token: 0x0400250A RID: 9482
		public const short LogicGateLamp_On = 3618;

		// Token: 0x0400250B RID: 9483
		public const short MechanicalLens = 3619;

		// Token: 0x0400250C RID: 9484
		public const short ActuationRod = 3620;

		// Token: 0x0400250D RID: 9485
		public const short TeamBlockRed = 3621;

		// Token: 0x0400250E RID: 9486
		public const short TeamBlockRedPlatform = 3622;

		// Token: 0x0400250F RID: 9487
		public const short StaticHook = 3623;

		// Token: 0x04002510 RID: 9488
		public const short ActuationAccessory = 3624;

		// Token: 0x04002511 RID: 9489
		public const short MulticolorWrench = 3625;

		// Token: 0x04002512 RID: 9490
		public const short WeightedPressurePlatePink = 3626;

		// Token: 0x04002513 RID: 9491
		public const short EngineeringHelmet = 3627;

		// Token: 0x04002514 RID: 9492
		public const short CompanionCube = 3628;

		// Token: 0x04002515 RID: 9493
		public const short WireBulb = 3629;

		// Token: 0x04002516 RID: 9494
		public const short WeightedPressurePlateOrange = 3630;

		// Token: 0x04002517 RID: 9495
		public const short WeightedPressurePlatePurple = 3631;

		// Token: 0x04002518 RID: 9496
		public const short WeightedPressurePlateCyan = 3632;

		// Token: 0x04002519 RID: 9497
		public const short TeamBlockGreen = 3633;

		// Token: 0x0400251A RID: 9498
		public const short TeamBlockBlue = 3634;

		// Token: 0x0400251B RID: 9499
		public const short TeamBlockYellow = 3635;

		// Token: 0x0400251C RID: 9500
		public const short TeamBlockPink = 3636;

		// Token: 0x0400251D RID: 9501
		public const short TeamBlockWhite = 3637;

		// Token: 0x0400251E RID: 9502
		public const short TeamBlockGreenPlatform = 3638;

		// Token: 0x0400251F RID: 9503
		public const short TeamBlockBluePlatform = 3639;

		// Token: 0x04002520 RID: 9504
		public const short TeamBlockYellowPlatform = 3640;

		// Token: 0x04002521 RID: 9505
		public const short TeamBlockPinkPlatform = 3641;

		// Token: 0x04002522 RID: 9506
		public const short TeamBlockWhitePlatform = 3642;

		// Token: 0x04002523 RID: 9507
		public const short LargeAmber = 3643;

		// Token: 0x04002524 RID: 9508
		public const short GemLockRuby = 3644;

		// Token: 0x04002525 RID: 9509
		public const short GemLockSapphire = 3645;

		// Token: 0x04002526 RID: 9510
		public const short GemLockEmerald = 3646;

		// Token: 0x04002527 RID: 9511
		public const short GemLockTopaz = 3647;

		// Token: 0x04002528 RID: 9512
		public const short GemLockAmethyst = 3648;

		// Token: 0x04002529 RID: 9513
		public const short GemLockDiamond = 3649;

		// Token: 0x0400252A RID: 9514
		public const short GemLockAmber = 3650;

		// Token: 0x0400252B RID: 9515
		public const short SquirrelStatue = 3651;

		// Token: 0x0400252C RID: 9516
		public const short ButterflyStatue = 3652;

		// Token: 0x0400252D RID: 9517
		public const short WormStatue = 3653;

		// Token: 0x0400252E RID: 9518
		public const short FireflyStatue = 3654;

		// Token: 0x0400252F RID: 9519
		public const short ScorpionStatue = 3655;

		// Token: 0x04002530 RID: 9520
		public const short SnailStatue = 3656;

		// Token: 0x04002531 RID: 9521
		public const short GrasshopperStatue = 3657;

		// Token: 0x04002532 RID: 9522
		public const short MouseStatue = 3658;

		// Token: 0x04002533 RID: 9523
		public const short DuckStatue = 3659;

		// Token: 0x04002534 RID: 9524
		public const short PenguinStatue = 3660;

		// Token: 0x04002535 RID: 9525
		public const short FrogStatue = 3661;

		// Token: 0x04002536 RID: 9526
		public const short BuggyStatue = 3662;

		// Token: 0x04002537 RID: 9527
		public const short LogicGateLamp_Faulty = 3663;

		// Token: 0x04002538 RID: 9528
		public const short PortalGunStation = 3664;

		// Token: 0x04002539 RID: 9529
		public const short Fake_Chest = 3665;

		// Token: 0x0400253A RID: 9530
		public const short Fake_GoldChest = 3666;

		// Token: 0x0400253B RID: 9531
		public const short Fake_ShadowChest = 3667;

		// Token: 0x0400253C RID: 9532
		public const short Fake_EbonwoodChest = 3668;

		// Token: 0x0400253D RID: 9533
		public const short Fake_RichMahoganyChest = 3669;

		// Token: 0x0400253E RID: 9534
		public const short Fake_PearlwoodChest = 3670;

		// Token: 0x0400253F RID: 9535
		public const short Fake_IvyChest = 3671;

		// Token: 0x04002540 RID: 9536
		public const short Fake_IceChest = 3672;

		// Token: 0x04002541 RID: 9537
		public const short Fake_LivingWoodChest = 3673;

		// Token: 0x04002542 RID: 9538
		public const short Fake_SkywareChest = 3674;

		// Token: 0x04002543 RID: 9539
		public const short Fake_ShadewoodChest = 3675;

		// Token: 0x04002544 RID: 9540
		public const short Fake_WebCoveredChest = 3676;

		// Token: 0x04002545 RID: 9541
		public const short Fake_LihzahrdChest = 3677;

		// Token: 0x04002546 RID: 9542
		public const short Fake_WaterChest = 3678;

		// Token: 0x04002547 RID: 9543
		public const short Fake_JungleChest = 3679;

		// Token: 0x04002548 RID: 9544
		public const short Fake_CorruptionChest = 3680;

		// Token: 0x04002549 RID: 9545
		public const short Fake_CrimsonChest = 3681;

		// Token: 0x0400254A RID: 9546
		public const short Fake_HallowedChest = 3682;

		// Token: 0x0400254B RID: 9547
		public const short Fake_FrozenChest = 3683;

		// Token: 0x0400254C RID: 9548
		public const short Fake_DynastyChest = 3684;

		// Token: 0x0400254D RID: 9549
		public const short Fake_HoneyChest = 3685;

		// Token: 0x0400254E RID: 9550
		public const short Fake_SteampunkChest = 3686;

		// Token: 0x0400254F RID: 9551
		public const short Fake_PalmWoodChest = 3687;

		// Token: 0x04002550 RID: 9552
		public const short Fake_MushroomChest = 3688;

		// Token: 0x04002551 RID: 9553
		public const short Fake_BorealWoodChest = 3689;

		// Token: 0x04002552 RID: 9554
		public const short Fake_SlimeChest = 3690;

		// Token: 0x04002553 RID: 9555
		public const short Fake_GreenDungeonChest = 3691;

		// Token: 0x04002554 RID: 9556
		public const short Fake_PinkDungeonChest = 3692;

		// Token: 0x04002555 RID: 9557
		public const short Fake_BlueDungeonChest = 3693;

		// Token: 0x04002556 RID: 9558
		public const short Fake_BoneChest = 3694;

		// Token: 0x04002557 RID: 9559
		public const short Fake_CactusChest = 3695;

		// Token: 0x04002558 RID: 9560
		public const short Fake_FleshChest = 3696;

		// Token: 0x04002559 RID: 9561
		public const short Fake_ObsidianChest = 3697;

		// Token: 0x0400255A RID: 9562
		public const short Fake_PumpkinChest = 3698;

		// Token: 0x0400255B RID: 9563
		public const short Fake_SpookyChest = 3699;

		// Token: 0x0400255C RID: 9564
		public const short Fake_GlassChest = 3700;

		// Token: 0x0400255D RID: 9565
		public const short Fake_MartianChest = 3701;

		// Token: 0x0400255E RID: 9566
		public const short Fake_MeteoriteChest = 3702;

		// Token: 0x0400255F RID: 9567
		public const short Fake_GraniteChest = 3703;

		// Token: 0x04002560 RID: 9568
		public const short Fake_MarbleChest = 3704;

		// Token: 0x04002561 RID: 9569
		public const short Fake_newchest1 = 3705;

		// Token: 0x04002562 RID: 9570
		public const short Fake_newchest2 = 3706;

		// Token: 0x04002563 RID: 9571
		public const short ProjectilePressurePad = 3707;

		// Token: 0x04002564 RID: 9572
		public const short WallCreeperStatue = 3708;

		// Token: 0x04002565 RID: 9573
		public const short UnicornStatue = 3709;

		// Token: 0x04002566 RID: 9574
		public const short DripplerStatue = 3710;

		// Token: 0x04002567 RID: 9575
		public const short WraithStatue = 3711;

		// Token: 0x04002568 RID: 9576
		public const short BoneSkeletonStatue = 3712;

		// Token: 0x04002569 RID: 9577
		public const short UndeadVikingStatue = 3713;

		// Token: 0x0400256A RID: 9578
		public const short MedusaStatue = 3714;

		// Token: 0x0400256B RID: 9579
		public const short HarpyStatue = 3715;

		// Token: 0x0400256C RID: 9580
		public const short PigronStatue = 3716;

		// Token: 0x0400256D RID: 9581
		public const short HopliteStatue = 3717;

		// Token: 0x0400256E RID: 9582
		public const short GraniteGolemStatue = 3718;

		// Token: 0x0400256F RID: 9583
		public const short ZombieArmStatue = 3719;

		// Token: 0x04002570 RID: 9584
		public const short BloodZombieStatue = 3720;

		// Token: 0x04002571 RID: 9585
		public const short AnglerTackleBag = 3721;

		// Token: 0x04002572 RID: 9586
		public const short GeyserTrap = 3722;

		// Token: 0x04002573 RID: 9587
		public const short UltraBrightCampfire = 3723;

		// Token: 0x04002574 RID: 9588
		public const short BoneCampfire = 3724;

		// Token: 0x04002575 RID: 9589
		public const short PixelBox = 3725;

		// Token: 0x04002576 RID: 9590
		public const short LogicSensor_Water = 3726;

		// Token: 0x04002577 RID: 9591
		public const short LogicSensor_Lava = 3727;

		// Token: 0x04002578 RID: 9592
		public const short LogicSensor_Honey = 3728;

		// Token: 0x04002579 RID: 9593
		public const short LogicSensor_Liquid = 3729;

		// Token: 0x0400257A RID: 9594
		public const short PartyBundleOfBalloonsAccessory = 3730;

		// Token: 0x0400257B RID: 9595
		public const short PartyBalloonAnimal = 3731;

		// Token: 0x0400257C RID: 9596
		public const short PartyHat = 3732;

		// Token: 0x0400257D RID: 9597
		public const short FlowerBoyHat = 3733;

		// Token: 0x0400257E RID: 9598
		public const short FlowerBoyShirt = 3734;

		// Token: 0x0400257F RID: 9599
		public const short FlowerBoyPants = 3735;

		// Token: 0x04002580 RID: 9600
		public const short SillyBalloonPink = 3736;

		// Token: 0x04002581 RID: 9601
		public const short SillyBalloonPurple = 3737;

		// Token: 0x04002582 RID: 9602
		public const short SillyBalloonGreen = 3738;

		// Token: 0x04002583 RID: 9603
		public const short SillyStreamerBlue = 3739;

		// Token: 0x04002584 RID: 9604
		public const short SillyStreamerGreen = 3740;

		// Token: 0x04002585 RID: 9605
		public const short SillyStreamerPink = 3741;

		// Token: 0x04002586 RID: 9606
		public const short SillyBalloonMachine = 3742;

		// Token: 0x04002587 RID: 9607
		public const short SillyBalloonTiedPink = 3743;

		// Token: 0x04002588 RID: 9608
		public const short SillyBalloonTiedPurple = 3744;

		// Token: 0x04002589 RID: 9609
		public const short SillyBalloonTiedGreen = 3745;

		// Token: 0x0400258A RID: 9610
		public const short Pigronata = 3746;

		// Token: 0x0400258B RID: 9611
		public const short PartyMonolith = 3747;

		// Token: 0x0400258C RID: 9612
		public const short PartyBundleOfBalloonTile = 3748;

		// Token: 0x0400258D RID: 9613
		public const short PartyPresent = 3749;

		// Token: 0x0400258E RID: 9614
		public const short SliceOfCake = 3750;

		// Token: 0x0400258F RID: 9615
		public const short CogWall = 3751;

		// Token: 0x04002590 RID: 9616
		public const short SandFallWall = 3752;

		// Token: 0x04002591 RID: 9617
		public const short SnowFallWall = 3753;

		// Token: 0x04002592 RID: 9618
		public const short SandFallBlock = 3754;

		// Token: 0x04002593 RID: 9619
		public const short SnowFallBlock = 3755;

		// Token: 0x04002594 RID: 9620
		public const short SnowCloudBlock = 3756;

		// Token: 0x04002595 RID: 9621
		public const short PedguinHat = 3757;

		// Token: 0x04002596 RID: 9622
		public const short PedguinShirt = 3758;

		// Token: 0x04002597 RID: 9623
		public const short PedguinPants = 3759;

		// Token: 0x04002598 RID: 9624
		public const short SillyBalloonPinkWall = 3760;

		// Token: 0x04002599 RID: 9625
		public const short SillyBalloonPurpleWall = 3761;

		// Token: 0x0400259A RID: 9626
		public const short SillyBalloonGreenWall = 3762;

		// Token: 0x0400259B RID: 9627
		public const short AviatorSunglasses = 3763;

		// Token: 0x0400259C RID: 9628
		public const short BluePhasesaber = 3764;

		// Token: 0x0400259D RID: 9629
		public const short RedPhasesaber = 3765;

		// Token: 0x0400259E RID: 9630
		public const short GreenPhasesaber = 3766;

		// Token: 0x0400259F RID: 9631
		public const short PurplePhasesaber = 3767;

		// Token: 0x040025A0 RID: 9632
		public const short WhitePhasesaber = 3768;

		// Token: 0x040025A1 RID: 9633
		public const short YellowPhasesaber = 3769;

		// Token: 0x040025A2 RID: 9634
		public const short DjinnsCurse = 3770;

		// Token: 0x040025A3 RID: 9635
		public const short AncientHorn = 3771;

		// Token: 0x040025A4 RID: 9636
		public const short AntlionClaw = 3772;

		// Token: 0x040025A5 RID: 9637
		public const short AncientArmorHat = 3773;

		// Token: 0x040025A6 RID: 9638
		public const short AncientArmorShirt = 3774;

		// Token: 0x040025A7 RID: 9639
		public const short AncientArmorPants = 3775;

		// Token: 0x040025A8 RID: 9640
		public const short AncientBattleArmorHat = 3776;

		// Token: 0x040025A9 RID: 9641
		public const short AncientBattleArmorShirt = 3777;

		// Token: 0x040025AA RID: 9642
		public const short AncientBattleArmorPants = 3778;

		// Token: 0x040025AB RID: 9643
		public const short SpiritFlame = 3779;

		// Token: 0x040025AC RID: 9644
		public const short SandElementalBanner = 3780;

		// Token: 0x040025AD RID: 9645
		public const short PocketMirror = 3781;

		// Token: 0x040025AE RID: 9646
		public const short MagicSandDropper = 3782;

		// Token: 0x040025AF RID: 9647
		public const short AncientBattleArmorMaterial = 3783;

		// Token: 0x040025B0 RID: 9648
		public const short LamiaPants = 3784;

		// Token: 0x040025B1 RID: 9649
		public const short LamiaShirt = 3785;

		// Token: 0x040025B2 RID: 9650
		public const short LamiaHat = 3786;

		// Token: 0x040025B3 RID: 9651
		public const short SkyFracture = 3787;

		// Token: 0x040025B4 RID: 9652
		public const short OnyxBlaster = 3788;

		// Token: 0x040025B5 RID: 9653
		public const short SandsharkBanner = 3789;

		// Token: 0x040025B6 RID: 9654
		public const short SandsharkCorruptBanner = 3790;

		// Token: 0x040025B7 RID: 9655
		public const short SandsharkCrimsonBanner = 3791;

		// Token: 0x040025B8 RID: 9656
		public const short SandsharkHallowedBanner = 3792;

		// Token: 0x040025B9 RID: 9657
		public const short TumbleweedBanner = 3793;

		// Token: 0x040025BA RID: 9658
		public const short AncientCloth = 3794;

		// Token: 0x040025BB RID: 9659
		public const short DjinnLamp = 3795;

		// Token: 0x040025BC RID: 9660
		public const short MusicBoxSandstorm = 3796;

		// Token: 0x040025BD RID: 9661
		public const short ApprenticeHat = 3797;

		// Token: 0x040025BE RID: 9662
		public const short ApprenticeRobe = 3798;

		// Token: 0x040025BF RID: 9663
		public const short ApprenticeTrousers = 3799;

		// Token: 0x040025C0 RID: 9664
		public const short SquireGreatHelm = 3800;

		// Token: 0x040025C1 RID: 9665
		public const short SquirePlating = 3801;

		// Token: 0x040025C2 RID: 9666
		public const short SquireGreaves = 3802;

		// Token: 0x040025C3 RID: 9667
		public const short HuntressWig = 3803;

		// Token: 0x040025C4 RID: 9668
		public const short HuntressJerkin = 3804;

		// Token: 0x040025C5 RID: 9669
		public const short HuntressPants = 3805;

		// Token: 0x040025C6 RID: 9670
		public const short MonkBrows = 3806;

		// Token: 0x040025C7 RID: 9671
		public const short MonkShirt = 3807;

		// Token: 0x040025C8 RID: 9672
		public const short MonkPants = 3808;

		// Token: 0x040025C9 RID: 9673
		public const short ApprenticeScarf = 3809;

		// Token: 0x040025CA RID: 9674
		public const short SquireShield = 3810;

		// Token: 0x040025CB RID: 9675
		public const short HuntressBuckler = 3811;

		// Token: 0x040025CC RID: 9676
		public const short MonkBelt = 3812;

		// Token: 0x040025CD RID: 9677
		public const short DefendersForge = 3813;

		// Token: 0x040025CE RID: 9678
		public const short WarTable = 3814;

		// Token: 0x040025CF RID: 9679
		public const short WarTableBanner = 3815;

		// Token: 0x040025D0 RID: 9680
		public const short DD2ElderCrystalStand = 3816;

		// Token: 0x040025D1 RID: 9681
		public const short DefenderMedal = 3817;

		// Token: 0x040025D2 RID: 9682
		public const short DD2FlameburstTowerT1Popper = 3818;

		// Token: 0x040025D3 RID: 9683
		public const short DD2FlameburstTowerT2Popper = 3819;

		// Token: 0x040025D4 RID: 9684
		public const short DD2FlameburstTowerT3Popper = 3820;

		// Token: 0x040025D5 RID: 9685
		public const short AleThrowingGlove = 3821;

		// Token: 0x040025D6 RID: 9686
		public const short DD2EnergyCrystal = 3822;

		// Token: 0x040025D7 RID: 9687
		public const short DD2SquireDemonSword = 3823;

		// Token: 0x040025D8 RID: 9688
		public const short DD2BallistraTowerT1Popper = 3824;

		// Token: 0x040025D9 RID: 9689
		public const short DD2BallistraTowerT2Popper = 3825;

		// Token: 0x040025DA RID: 9690
		public const short DD2BallistraTowerT3Popper = 3826;

		// Token: 0x040025DB RID: 9691
		public const short DD2SquireBetsySword = 3827;

		// Token: 0x040025DC RID: 9692
		public const short DD2ElderCrystal = 3828;

		// Token: 0x040025DD RID: 9693
		public const short DD2LightningAuraT1Popper = 3829;

		// Token: 0x040025DE RID: 9694
		public const short DD2LightningAuraT2Popper = 3830;

		// Token: 0x040025DF RID: 9695
		public const short DD2LightningAuraT3Popper = 3831;

		// Token: 0x040025E0 RID: 9696
		public const short DD2ExplosiveTrapT1Popper = 3832;

		// Token: 0x040025E1 RID: 9697
		public const short DD2ExplosiveTrapT2Popper = 3833;

		// Token: 0x040025E2 RID: 9698
		public const short DD2ExplosiveTrapT3Popper = 3834;

		// Token: 0x040025E3 RID: 9699
		public const short MonkStaffT1 = 3835;

		// Token: 0x040025E4 RID: 9700
		public const short MonkStaffT2 = 3836;

		// Token: 0x040025E5 RID: 9701
		public const short DD2GoblinBomberBanner = 3837;

		// Token: 0x040025E6 RID: 9702
		public const short DD2GoblinBanner = 3838;

		// Token: 0x040025E7 RID: 9703
		public const short DD2SkeletonBanner = 3839;

		// Token: 0x040025E8 RID: 9704
		public const short DD2DrakinBanner = 3840;

		// Token: 0x040025E9 RID: 9705
		public const short DD2KoboldFlyerBanner = 3841;

		// Token: 0x040025EA RID: 9706
		public const short DD2KoboldBanner = 3842;

		// Token: 0x040025EB RID: 9707
		public const short DD2WitherBeastBanner = 3843;

		// Token: 0x040025EC RID: 9708
		public const short DD2WyvernBanner = 3844;

		// Token: 0x040025ED RID: 9709
		public const short DD2JavelinThrowerBanner = 3845;

		// Token: 0x040025EE RID: 9710
		public const short DD2LightningBugBanner = 3846;

		// Token: 0x040025EF RID: 9711
		public const short OgreMask = 3847;

		// Token: 0x040025F0 RID: 9712
		public const short GoblinMask = 3848;

		// Token: 0x040025F1 RID: 9713
		public const short GoblinBomberCap = 3849;

		// Token: 0x040025F2 RID: 9714
		public const short EtherianJavelin = 3850;

		// Token: 0x040025F3 RID: 9715
		public const short KoboldDynamiteBackpack = 3851;

		// Token: 0x040025F4 RID: 9716
		public const short BookStaff = 3852;

		// Token: 0x040025F5 RID: 9717
		public const short BoringBow = 3853;

		// Token: 0x040025F6 RID: 9718
		public const short DD2PhoenixBow = 3854;

		// Token: 0x040025F7 RID: 9719
		public const short DD2PetGato = 3855;

		// Token: 0x040025F8 RID: 9720
		public const short DD2PetGhost = 3856;

		// Token: 0x040025F9 RID: 9721
		public const short DD2PetDragon = 3857;

		// Token: 0x040025FA RID: 9722
		public const short MonkStaffT3 = 3858;

		// Token: 0x040025FB RID: 9723
		public const short DD2BetsyBow = 3859;

		// Token: 0x040025FC RID: 9724
		public const short BossBagBetsy = 3860;

		// Token: 0x040025FD RID: 9725
		public const short BossBagOgre = 3861;

		// Token: 0x040025FE RID: 9726
		public const short BossBagDarkMage = 3862;

		// Token: 0x040025FF RID: 9727
		public const short BossMaskBetsy = 3863;

		// Token: 0x04002600 RID: 9728
		public const short BossMaskDarkMage = 3864;

		// Token: 0x04002601 RID: 9729
		public const short BossMaskOgre = 3865;

		// Token: 0x04002602 RID: 9730
		public const short BossTrophyBetsy = 3866;

		// Token: 0x04002603 RID: 9731
		public const short BossTrophyDarkmage = 3867;

		// Token: 0x04002604 RID: 9732
		public const short BossTrophyOgre = 3868;

		// Token: 0x04002605 RID: 9733
		public const short MusicBoxDD2 = 3869;

		// Token: 0x04002606 RID: 9734
		public const short ApprenticeStaffT3 = 3870;

		// Token: 0x04002607 RID: 9735
		public const short SquireAltHead = 3871;

		// Token: 0x04002608 RID: 9736
		public const short SquireAltShirt = 3872;

		// Token: 0x04002609 RID: 9737
		public const short SquireAltPants = 3873;

		// Token: 0x0400260A RID: 9738
		public const short ApprenticeAltHead = 3874;

		// Token: 0x0400260B RID: 9739
		public const short ApprenticeAltShirt = 3875;

		// Token: 0x0400260C RID: 9740
		public const short ApprenticeAltPants = 3876;

		// Token: 0x0400260D RID: 9741
		public const short HuntressAltHead = 3877;

		// Token: 0x0400260E RID: 9742
		public const short HuntressAltShirt = 3878;

		// Token: 0x0400260F RID: 9743
		public const short HuntressAltPants = 3879;

		// Token: 0x04002610 RID: 9744
		public const short MonkAltHead = 3880;

		// Token: 0x04002611 RID: 9745
		public const short MonkAltShirt = 3881;

		// Token: 0x04002612 RID: 9746
		public const short MonkAltPants = 3882;

		// Token: 0x04002613 RID: 9747
		public const short BetsyWings = 3883;

		// Token: 0x04002614 RID: 9748
		public const short CrystalChest = 3884;

		// Token: 0x04002615 RID: 9749
		public const short GoldenChest = 3885;

		// Token: 0x04002616 RID: 9750
		public const short Fake_CrystalChest = 3886;

		// Token: 0x04002617 RID: 9751
		public const short Fake_GoldenChest = 3887;

		// Token: 0x04002618 RID: 9752
		public const short CrystalDoor = 3888;

		// Token: 0x04002619 RID: 9753
		public const short CrystalChair = 3889;

		// Token: 0x0400261A RID: 9754
		public const short CrystalCandle = 3890;

		// Token: 0x0400261B RID: 9755
		public const short CrystalLantern = 3891;

		// Token: 0x0400261C RID: 9756
		public const short CrystalLamp = 3892;

		// Token: 0x0400261D RID: 9757
		public const short CrystalCandelabra = 3893;

		// Token: 0x0400261E RID: 9758
		public const short CrystalChandelier = 3894;

		// Token: 0x0400261F RID: 9759
		public const short CrystalBathtub = 3895;

		// Token: 0x04002620 RID: 9760
		public const short CrystalSink = 3896;

		// Token: 0x04002621 RID: 9761
		public const short CrystalBed = 3897;

		// Token: 0x04002622 RID: 9762
		public const short CrystalClock = 3898;

		// Token: 0x04002623 RID: 9763
		public const short SkywareClock2 = 3899;

		// Token: 0x04002624 RID: 9764
		public const short DungeonClockBlue = 3900;

		// Token: 0x04002625 RID: 9765
		public const short DungeonClockGreen = 3901;

		// Token: 0x04002626 RID: 9766
		public const short DungeonClockPink = 3902;

		// Token: 0x04002627 RID: 9767
		public const short CrystalPlatform = 3903;

		// Token: 0x04002628 RID: 9768
		public const short GoldenPlatform = 3904;

		// Token: 0x04002629 RID: 9769
		public const short DynastyPlatform = 3905;

		// Token: 0x0400262A RID: 9770
		public const short LihzahrdPlatform = 3906;

		// Token: 0x0400262B RID: 9771
		public const short FleshPlatform = 3907;

		// Token: 0x0400262C RID: 9772
		public const short FrozenPlatform = 3908;

		// Token: 0x0400262D RID: 9773
		public const short CrystalWorkbench = 3909;

		// Token: 0x0400262E RID: 9774
		public const short GoldenWorkbench = 3910;

		// Token: 0x0400262F RID: 9775
		public const short CrystalDresser = 3911;

		// Token: 0x04002630 RID: 9776
		public const short DynastyDresser = 3912;

		// Token: 0x04002631 RID: 9777
		public const short FrozenDresser = 3913;

		// Token: 0x04002632 RID: 9778
		public const short LivingWoodDresser = 3914;

		// Token: 0x04002633 RID: 9779
		public const short CrystalPiano = 3915;

		// Token: 0x04002634 RID: 9780
		public const short DynastyPiano = 3916;

		// Token: 0x04002635 RID: 9781
		public const short CrystalBookCase = 3917;

		// Token: 0x04002636 RID: 9782
		public const short CrystalSofaHowDoesThatEvenWork = 3918;

		// Token: 0x04002637 RID: 9783
		public const short DynastySofa = 3919;

		// Token: 0x04002638 RID: 9784
		public const short CrystalTable = 3920;

		// Token: 0x04002639 RID: 9785
		public const short ArkhalisHat = 3921;

		// Token: 0x0400263A RID: 9786
		public const short ArkhalisShirt = 3922;

		// Token: 0x0400263B RID: 9787
		public const short ArkhalisPants = 3923;

		// Token: 0x0400263C RID: 9788
		public const short ArkhalisWings = 3924;

		// Token: 0x0400263D RID: 9789
		public const short LeinforsHat = 3925;

		// Token: 0x0400263E RID: 9790
		public const short LeinforsShirt = 3926;

		// Token: 0x0400263F RID: 9791
		public const short LeinforsPants = 3927;

		// Token: 0x04002640 RID: 9792
		public const short LeinforsWings = 3928;

		// Token: 0x04002641 RID: 9793
		public const short LeinforsAccessory = 3929;

		// Token: 0x04002642 RID: 9794
		public const short Count = 3930;

		// Token: 0x02000272 RID: 626
		public struct BannerEffect
		{
			// Token: 0x06001672 RID: 5746 RVA: 0x00435850 File Offset: 0x00433A50
			public BannerEffect(float strength = 1f)
			{
				this.NormalDamageDealt = 1f + strength * 0.5f;
				this.ExpertDamageDealt = 1f + strength;
				this.ExpertDamageReceived = 1f / (strength + 1f);
				this.NormalDamageReceived = 1f - (1f - this.ExpertDamageReceived) * 0.5f;
				this.Enabled = (strength != 0f);
			}

			// Token: 0x06001673 RID: 5747 RVA: 0x004358C0 File Offset: 0x00433AC0
			public BannerEffect(float normalDamageDealt, float expertDamageDealt, float normalDamageReceived, float expertDamageReceived)
			{
				this.NormalDamageDealt = normalDamageDealt;
				this.ExpertDamageDealt = expertDamageDealt;
				this.NormalDamageReceived = normalDamageReceived;
				this.ExpertDamageReceived = expertDamageReceived;
				this.Enabled = true;
			}

			// Token: 0x04003BB4 RID: 15284
			public static readonly ItemID.BannerEffect None = new ItemID.BannerEffect(0f);

			// Token: 0x04003BB5 RID: 15285
			public readonly float NormalDamageDealt;

			// Token: 0x04003BB6 RID: 15286
			public readonly float ExpertDamageDealt;

			// Token: 0x04003BB7 RID: 15287
			public readonly float NormalDamageReceived;

			// Token: 0x04003BB8 RID: 15288
			public readonly float ExpertDamageReceived;

			// Token: 0x04003BB9 RID: 15289
			public readonly bool Enabled;
		}

		// Token: 0x02000273 RID: 627
		public class Sets
		{
			// Token: 0x04003BBA RID: 15290
			public static SetFactory Factory = new SetFactory(3930);

			// Token: 0x04003BBB RID: 15291
			private static ItemID.BannerEffect DD2BannerEffect = ItemID.BannerEffect.None;

			// Token: 0x04003BBC RID: 15292
			public static ItemID.BannerEffect[] BannerStrength = ItemID.Sets.Factory.CreateCustomSet<ItemID.BannerEffect>(new ItemID.BannerEffect(1f), new object[]
			{
				3838,
				ItemID.Sets.DD2BannerEffect,
				3845,
				ItemID.Sets.DD2BannerEffect,
				3837,
				ItemID.Sets.DD2BannerEffect,
				3844,
				ItemID.Sets.DD2BannerEffect,
				3843,
				ItemID.Sets.DD2BannerEffect,
				3839,
				ItemID.Sets.DD2BannerEffect,
				3840,
				ItemID.Sets.DD2BannerEffect,
				3842,
				ItemID.Sets.DD2BannerEffect,
				3841,
				ItemID.Sets.DD2BannerEffect,
				3846,
				ItemID.Sets.DD2BannerEffect
			});

			// Token: 0x04003BBD RID: 15293
			public static int[] KillsToBanner = ItemID.Sets.Factory.CreateIntSet(50, new int[]
			{
				3838,
				1000,
				3845,
				200,
				3837,
				500,
				3844,
				200,
				3843,
				50,
				3839,
				200,
				3840,
				100,
				3842,
				200,
				3841,
				100,
				3846,
				50
			});

			// Token: 0x04003BBE RID: 15294
			public static bool[] CanFishInLava = ItemID.Sets.Factory.CreateBoolSet(new int[]
			{
				2422
			});

			// Token: 0x04003BBF RID: 15295
			public static int[] TextureCopyLoad = ItemID.Sets.Factory.CreateIntSet(-1, new int[]
			{
				3665,
				48,
				3666,
				306,
				3667,
				328,
				3668,
				625,
				3669,
				626,
				3670,
				627,
				3671,
				680,
				3672,
				681,
				3673,
				831,
				3674,
				838,
				3675,
				914,
				3676,
				952,
				3677,
				1142,
				3678,
				1298,
				3679,
				1528,
				3680,
				1529,
				3681,
				1530,
				3682,
				1531,
				3683,
				1532,
				3684,
				2230,
				3685,
				2249,
				3686,
				2250,
				3687,
				2526,
				3688,
				2544,
				3689,
				2559,
				3690,
				2574,
				3691,
				2612,
				3692,
				2613,
				3693,
				2614,
				3694,
				2615,
				3695,
				2616,
				3696,
				2617,
				3697,
				2618,
				3698,
				2619,
				3699,
				2620,
				3700,
				2748,
				3701,
				2814,
				3703,
				3125,
				3702,
				3180,
				3704,
				3181,
				3705,
				3665,
				3706,
				3665
			});

			// Token: 0x04003BC0 RID: 15296
			public static bool[] TrapSigned = ItemID.Sets.Factory.CreateBoolSet(false, new int[]
			{
				3665,
				3666,
				3667,
				3668,
				3669,
				3670,
				3671,
				3672,
				3673,
				3674,
				3675,
				3676,
				3677,
				3678,
				3679,
				3680,
				3681,
				3682,
				3683,
				3684,
				3685,
				3686,
				3687,
				3688,
				3689,
				3690,
				3691,
				3692,
				3693,
				3694,
				3695,
				3696,
				3697,
				3698,
				3699,
				3700,
				3701,
				3703,
				3702,
				3704,
				3705,
				3706,
				3886,
				3887
			});

			// Token: 0x04003BC1 RID: 15297
			public static bool[] Deprecated = ItemID.Sets.Factory.CreateBoolSet(new int[]
			{
				2784,
				2783,
				2785,
				2782,
				2774,
				2773,
				2775,
				2772,
				2779,
				2778,
				2780,
				2777,
				3464,
				3463,
				3465,
				3462,
				3341,
				3342,
				3343,
				3340,
				3344,
				3345,
				3346,
				3273,
				2881,
				3750,
				3847,
				3848,
				3849,
				3850,
				3851,
				3850,
				3861,
				3862
			});

			// Token: 0x04003BC2 RID: 15298
			public static bool[] NeverShiny = ItemID.Sets.Factory.CreateBoolSet(new int[]
			{
				71,
				72,
				73,
				74
			});

			// Token: 0x04003BC3 RID: 15299
			public static bool[] ItemIconPulse = ItemID.Sets.Factory.CreateBoolSet(new int[]
			{
				520,
				521,
				575,
				549,
				548,
				547,
				3456,
				3457,
				3458,
				3459,
				3580,
				3581
			});

			// Token: 0x04003BC4 RID: 15300
			public static bool[] ItemNoGravity = ItemID.Sets.Factory.CreateBoolSet(new int[]
			{
				520,
				521,
				575,
				549,
				548,
				547,
				3453,
				3454,
				3455,
				3456,
				3457,
				3458,
				3459,
				3580,
				3581
			});

			// Token: 0x04003BC5 RID: 15301
			public static int[] ExtractinatorMode = ItemID.Sets.Factory.CreateIntSet(-1, new int[]
			{
				424,
				0,
				1103,
				0,
				3347,
				1
			});

			// Token: 0x04003BC6 RID: 15302
			public static int[] StaffMinionSlotsRequired = ItemID.Sets.Factory.CreateIntSet(1, new int[0]);

			// Token: 0x04003BC7 RID: 15303
			public static bool[] ExoticPlantsForDyeTrade = ItemID.Sets.Factory.CreateBoolSet(new int[]
			{
				3385,
				3386,
				3387,
				3388
			});

			// Token: 0x04003BC8 RID: 15304
			public static bool[] NebulaPickup = ItemID.Sets.Factory.CreateBoolSet(new int[]
			{
				3453,
				3454,
				3455
			});

			// Token: 0x04003BC9 RID: 15305
			public static bool[] AnimatesAsSoul = ItemID.Sets.Factory.CreateBoolSet(new int[]
			{
				575,
				547,
				520,
				548,
				521,
				549,
				3580,
				3581
			});

			// Token: 0x04003BCA RID: 15306
			public static bool[] gunProj = ItemID.Sets.Factory.CreateBoolSet(new int[]
			{
				3475,
				3540,
				3854
			});

			// Token: 0x04003BCB RID: 15307
			public static int[] SortingPriorityBossSpawns = ItemID.Sets.Factory.CreateIntSet(-1, new int[]
			{
				43,
				1,
				560,
				2,
				70,
				3,
				1331,
				3,
				361,
				4,
				1133,
				5,
				544,
				6,
				556,
				7,
				557,
				8,
				2495,
				9,
				2673,
				10,
				602,
				11,
				1844,
				12,
				1958,
				13,
				1293,
				14,
				2767,
				15,
				3601,
				16,
				1291,
				17,
				109,
				18,
				29,
				19,
				50,
				20,
				3199,
				20,
				3124,
				21
			});

			// Token: 0x04003BCC RID: 15308
			public static int[] SortingPriorityWiring = ItemID.Sets.Factory.CreateIntSet(-1, new int[]
			{
				510,
				101,
				3625,
				100,
				509,
				99,
				851,
				98,
				850,
				97,
				3612,
				96,
				849,
				95,
				583,
				94,
				584,
				93,
				585,
				92,
				538,
				91,
				513,
				90,
				3545,
				90,
				853,
				89,
				541,
				88,
				529,
				88,
				1151,
				87,
				852,
				87,
				543,
				87,
				542,
				87,
				3707,
				87,
				2492,
				86,
				530,
				85,
				581,
				84,
				582,
				84,
				1263,
				83
			});

			// Token: 0x04003BCD RID: 15309
			public static int[] SortingPriorityMaterials = ItemID.Sets.Factory.CreateIntSet(-1, new int[]
			{
				3467,
				100,
				3460,
				99,
				3458,
				98,
				3456,
				97,
				3457,
				96,
				3459,
				95,
				3261,
				94,
				1508,
				93,
				1552,
				92,
				1006,
				91,
				947,
				90,
				1225,
				89,
				1198,
				88,
				1106,
				87,
				391,
				86,
				366,
				85,
				1191,
				84,
				1105,
				83,
				382,
				82,
				365,
				81,
				1184,
				80,
				1104,
				79,
				381,
				78,
				364,
				77,
				548,
				76,
				547,
				75,
				549,
				74,
				575,
				73,
				521,
				72,
				520,
				71,
				175,
				70,
				174,
				69,
				3380,
				68,
				1329,
				67,
				1257,
				66,
				880,
				65,
				86,
				64,
				57,
				63,
				56,
				62,
				117,
				61,
				116,
				60,
				706,
				59,
				702,
				58,
				19,
				57,
				13,
				56,
				705,
				55,
				701,
				54,
				21,
				53,
				14,
				52,
				704,
				51,
				700,
				50,
				22,
				49,
				11,
				48,
				703,
				47,
				699,
				46,
				20,
				45,
				12,
				44,
				999,
				43,
				182,
				42,
				178,
				41,
				179,
				40,
				177,
				39,
				180,
				38,
				181,
				37
			});

			// Token: 0x04003BCE RID: 15310
			public static int[] SortingPriorityExtractibles = ItemID.Sets.Factory.CreateIntSet(-1, new int[]
			{
				997,
				4,
				3347,
				3,
				1103,
				2,
				424,
				1
			});

			// Token: 0x04003BCF RID: 15311
			public static int[] SortingPriorityRopes = ItemID.Sets.Factory.CreateIntSet(-1, new int[]
			{
				965,
				1,
				85,
				1,
				210,
				1,
				3077,
				1,
				3078,
				1
			});

			// Token: 0x04003BD0 RID: 15312
			public static int[] SortingPriorityPainting = ItemID.Sets.Factory.CreateIntSet(-1, new int[]
			{
				1543,
				100,
				1544,
				99,
				1545,
				98,
				1071,
				97,
				1072,
				96,
				1100,
				95
			});

			// Token: 0x04003BD1 RID: 15313
			public static int[] SortingPriorityTerraforming = ItemID.Sets.Factory.CreateIntSet(-1, new int[]
			{
				779,
				100,
				780,
				99,
				783,
				98,
				781,
				97,
				782,
				96,
				784,
				95,
				422,
				94,
				423,
				93,
				3477,
				92,
				66,
				91,
				67,
				90,
				2886,
				89
			});

			// Token: 0x04003BD2 RID: 15314
			public static int[] GamepadExtraRange = ItemID.Sets.Factory.CreateIntSet(0, new int[]
			{
				2797,
				20,
				3278,
				4,
				3285,
				6,
				3279,
				8,
				3280,
				8,
				3281,
				9,
				3262,
				10,
				3317,
				10,
				3282,
				10,
				3315,
				10,
				3316,
				11,
				3283,
				12,
				3290,
				13,
				3289,
				11,
				3284,
				13,
				3286,
				13,
				3287,
				18,
				3288,
				18,
				3291,
				17,
				3292,
				18,
				3389,
				21
			});

			// Token: 0x04003BD3 RID: 15315
			public static bool[] GamepadWholeScreenUseRange = ItemID.Sets.Factory.CreateBoolSet(new int[]
			{
				1326,
				1256,
				1244,
				3014,
				113,
				218,
				495,
				114,
				496,
				2796,
				494,
				3006,
				65,
				1931,
				3570,
				2750,
				3065,
				3029,
				3030,
				1309,
				2364,
				2365,
				2551,
				2535,
				2584,
				1157,
				2749,
				1802,
				2621,
				3249,
				3531,
				3474,
				2366,
				1572,
				3569,
				3571,
				3611,
				1299,
				1254
			});

			// Token: 0x04003BD4 RID: 15316
			public static bool[] GamepadSmartQuickReach = ItemID.Sets.Factory.CreateBoolSet(new int[]
			{
				2798,
				2797,
				3030,
				3262,
				3278,
				3279,
				3280,
				3281,
				3282,
				3283,
				3284,
				3285,
				3286,
				3287,
				3288,
				3289,
				3290,
				3291,
				3292,
				3315,
				3316,
				3317,
				3389,
				2798,
				65,
				1931,
				3570,
				2750,
				3065,
				3029,
				1256,
				1244,
				3014,
				113,
				218,
				495
			});

			// Token: 0x04003BD5 RID: 15317
			public static bool[] Yoyo = ItemID.Sets.Factory.CreateBoolSet(new int[]
			{
				3262,
				3278,
				3279,
				3280,
				3281,
				3282,
				3283,
				3284,
				3285,
				3286,
				3287,
				3288,
				3289,
				3290,
				3291,
				3292,
				3315,
				3316,
				3317,
				3389
			});

			// Token: 0x04003BD6 RID: 15318
			public static bool[] AlsoABuildingItem = ItemID.Sets.Factory.CreateBoolSet(new int[]
			{
				3031,
				205,
				1128,
				207,
				206,
				3032,
				849,
				3620,
				509,
				851,
				850,
				3625,
				510,
				1071,
				1543,
				1072,
				1544,
				1100,
				1545
			});

			// Token: 0x04003BD7 RID: 15319
			public static bool[] LockOnIgnoresCollision = ItemID.Sets.Factory.CreateBoolSet(new int[]
			{
				64,
				3570,
				1327,
				3006,
				1227,
				788,
				756,
				1228,
				65,
				3065,
				3473,
				3051,
				1309,
				2364,
				2365,
				2551,
				2535,
				2584,
				1157,
				2749,
				1802,
				2621,
				3249,
				3531,
				3474,
				2366,
				1572,
				3014,
				3569,
				3571
			});

			// Token: 0x04003BD8 RID: 15320
			public static int[] LockOnAimAbove = ItemID.Sets.Factory.CreateIntSet(0, new int[]
			{
				1256,
				15,
				1244,
				15,
				3014,
				15,
				3569,
				15,
				3571,
				15
			});

			// Token: 0x04003BD9 RID: 15321
			public static float?[] LockOnAimCompensation = ItemID.Sets.Factory.CreateCustomSet<float?>(null, new object[]
			{
				1336,
				0.2f,
				157,
				0.29f,
				2590,
				0.4f,
				3821,
				0.4f,
				160,
				0.4f
			});

			// Token: 0x04003BDA RID: 15322
			public static bool[] SingleUseInGamepad = ItemID.Sets.Factory.CreateBoolSet(new int[]
			{
				8,
				427,
				3004,
				523,
				433,
				429,
				974,
				1333,
				1245,
				3114,
				430,
				3045,
				428,
				2274,
				431,
				432
			});
		}
	}
}

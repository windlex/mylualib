using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Terraria.GameInput
{
	// Token: 0x02000106 RID: 262
	public class TriggersSet
	{
		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000E58 RID: 3672 RVA: 0x003E9AFC File Offset: 0x003E7CFC
		// (set) Token: 0x06000E59 RID: 3673 RVA: 0x003E9B10 File Offset: 0x003E7D10
		public bool MouseLeft
		{
			get
			{
				return this.KeyStatus["MouseLeft"];
			}
			set
			{
				this.KeyStatus["MouseLeft"] = value;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000E5A RID: 3674 RVA: 0x003E9B24 File Offset: 0x003E7D24
		// (set) Token: 0x06000E5B RID: 3675 RVA: 0x003E9B38 File Offset: 0x003E7D38
		public bool MouseRight
		{
			get
			{
				return this.KeyStatus["MouseRight"];
			}
			set
			{
				this.KeyStatus["MouseRight"] = value;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000E5C RID: 3676 RVA: 0x003E9B4C File Offset: 0x003E7D4C
		// (set) Token: 0x06000E5D RID: 3677 RVA: 0x003E9B60 File Offset: 0x003E7D60
		public bool Up
		{
			get
			{
				return this.KeyStatus["Up"];
			}
			set
			{
				this.KeyStatus["Up"] = value;
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000E5E RID: 3678 RVA: 0x003E9B74 File Offset: 0x003E7D74
		// (set) Token: 0x06000E5F RID: 3679 RVA: 0x003E9B88 File Offset: 0x003E7D88
		public bool Down
		{
			get
			{
				return this.KeyStatus["Down"];
			}
			set
			{
				this.KeyStatus["Down"] = value;
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000E60 RID: 3680 RVA: 0x003E9B9C File Offset: 0x003E7D9C
		// (set) Token: 0x06000E61 RID: 3681 RVA: 0x003E9BB0 File Offset: 0x003E7DB0
		public bool Left
		{
			get
			{
				return this.KeyStatus["Left"];
			}
			set
			{
				this.KeyStatus["Left"] = value;
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000E62 RID: 3682 RVA: 0x003E9BC4 File Offset: 0x003E7DC4
		// (set) Token: 0x06000E63 RID: 3683 RVA: 0x003E9BD8 File Offset: 0x003E7DD8
		public bool Right
		{
			get
			{
				return this.KeyStatus["Right"];
			}
			set
			{
				this.KeyStatus["Right"] = value;
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000E64 RID: 3684 RVA: 0x003E9BEC File Offset: 0x003E7DEC
		// (set) Token: 0x06000E65 RID: 3685 RVA: 0x003E9C00 File Offset: 0x003E7E00
		public bool Jump
		{
			get
			{
				return this.KeyStatus["Jump"];
			}
			set
			{
				this.KeyStatus["Jump"] = value;
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000E66 RID: 3686 RVA: 0x003E9C14 File Offset: 0x003E7E14
		// (set) Token: 0x06000E67 RID: 3687 RVA: 0x003E9C28 File Offset: 0x003E7E28
		public bool Throw
		{
			get
			{
				return this.KeyStatus["Throw"];
			}
			set
			{
				this.KeyStatus["Throw"] = value;
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000E68 RID: 3688 RVA: 0x003E9C3C File Offset: 0x003E7E3C
		// (set) Token: 0x06000E69 RID: 3689 RVA: 0x003E9C50 File Offset: 0x003E7E50
		public bool Inventory
		{
			get
			{
				return this.KeyStatus["Inventory"];
			}
			set
			{
				this.KeyStatus["Inventory"] = value;
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000E6A RID: 3690 RVA: 0x003E9C64 File Offset: 0x003E7E64
		// (set) Token: 0x06000E6B RID: 3691 RVA: 0x003E9C78 File Offset: 0x003E7E78
		public bool Grapple
		{
			get
			{
				return this.KeyStatus["Grapple"];
			}
			set
			{
				this.KeyStatus["Grapple"] = value;
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000E6C RID: 3692 RVA: 0x003E9C8C File Offset: 0x003E7E8C
		// (set) Token: 0x06000E6D RID: 3693 RVA: 0x003E9CA0 File Offset: 0x003E7EA0
		public bool SmartSelect
		{
			get
			{
				return this.KeyStatus["SmartSelect"];
			}
			set
			{
				this.KeyStatus["SmartSelect"] = value;
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000E6E RID: 3694 RVA: 0x003E9CB4 File Offset: 0x003E7EB4
		// (set) Token: 0x06000E6F RID: 3695 RVA: 0x003E9CC8 File Offset: 0x003E7EC8
		public bool SmartCursor
		{
			get
			{
				return this.KeyStatus["SmartCursor"];
			}
			set
			{
				this.KeyStatus["SmartCursor"] = value;
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000E70 RID: 3696 RVA: 0x003E9CDC File Offset: 0x003E7EDC
		// (set) Token: 0x06000E71 RID: 3697 RVA: 0x003E9CF0 File Offset: 0x003E7EF0
		public bool QuickMount
		{
			get
			{
				return this.KeyStatus["QuickMount"];
			}
			set
			{
				this.KeyStatus["QuickMount"] = value;
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000E72 RID: 3698 RVA: 0x003E9D04 File Offset: 0x003E7F04
		// (set) Token: 0x06000E73 RID: 3699 RVA: 0x003E9D18 File Offset: 0x003E7F18
		public bool QuickHeal
		{
			get
			{
				return this.KeyStatus["QuickHeal"];
			}
			set
			{
				this.KeyStatus["QuickHeal"] = value;
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000E74 RID: 3700 RVA: 0x003E9D2C File Offset: 0x003E7F2C
		// (set) Token: 0x06000E75 RID: 3701 RVA: 0x003E9D40 File Offset: 0x003E7F40
		public bool QuickMana
		{
			get
			{
				return this.KeyStatus["QuickMana"];
			}
			set
			{
				this.KeyStatus["QuickMana"] = value;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000E76 RID: 3702 RVA: 0x003E9D54 File Offset: 0x003E7F54
		// (set) Token: 0x06000E77 RID: 3703 RVA: 0x003E9D68 File Offset: 0x003E7F68
		public bool QuickBuff
		{
			get
			{
				return this.KeyStatus["QuickBuff"];
			}
			set
			{
				this.KeyStatus["QuickBuff"] = value;
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000E78 RID: 3704 RVA: 0x003E9D7C File Offset: 0x003E7F7C
		// (set) Token: 0x06000E79 RID: 3705 RVA: 0x003E9D90 File Offset: 0x003E7F90
		public bool MapZoomIn
		{
			get
			{
				return this.KeyStatus["MapZoomIn"];
			}
			set
			{
				this.KeyStatus["MapZoomIn"] = value;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000E7A RID: 3706 RVA: 0x003E9DA4 File Offset: 0x003E7FA4
		// (set) Token: 0x06000E7B RID: 3707 RVA: 0x003E9DB8 File Offset: 0x003E7FB8
		public bool MapZoomOut
		{
			get
			{
				return this.KeyStatus["MapZoomOut"];
			}
			set
			{
				this.KeyStatus["MapZoomOut"] = value;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000E7C RID: 3708 RVA: 0x003E9DCC File Offset: 0x003E7FCC
		// (set) Token: 0x06000E7D RID: 3709 RVA: 0x003E9DE0 File Offset: 0x003E7FE0
		public bool MapAlphaUp
		{
			get
			{
				return this.KeyStatus["MapAlphaUp"];
			}
			set
			{
				this.KeyStatus["MapAlphaUp"] = value;
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000E7E RID: 3710 RVA: 0x003E9DF4 File Offset: 0x003E7FF4
		// (set) Token: 0x06000E7F RID: 3711 RVA: 0x003E9E08 File Offset: 0x003E8008
		public bool MapAlphaDown
		{
			get
			{
				return this.KeyStatus["MapAlphaDown"];
			}
			set
			{
				this.KeyStatus["MapAlphaDown"] = value;
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000E80 RID: 3712 RVA: 0x003E9E1C File Offset: 0x003E801C
		// (set) Token: 0x06000E81 RID: 3713 RVA: 0x003E9E30 File Offset: 0x003E8030
		public bool MapFull
		{
			get
			{
				return this.KeyStatus["MapFull"];
			}
			set
			{
				this.KeyStatus["MapFull"] = value;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000E82 RID: 3714 RVA: 0x003E9E44 File Offset: 0x003E8044
		// (set) Token: 0x06000E83 RID: 3715 RVA: 0x003E9E58 File Offset: 0x003E8058
		public bool MapStyle
		{
			get
			{
				return this.KeyStatus["MapStyle"];
			}
			set
			{
				this.KeyStatus["MapStyle"] = value;
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000E84 RID: 3716 RVA: 0x003E9E6C File Offset: 0x003E806C
		// (set) Token: 0x06000E85 RID: 3717 RVA: 0x003E9E80 File Offset: 0x003E8080
		public bool Hotbar1
		{
			get
			{
				return this.KeyStatus["Hotbar1"];
			}
			set
			{
				this.KeyStatus["Hotbar1"] = value;
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000E86 RID: 3718 RVA: 0x003E9E94 File Offset: 0x003E8094
		// (set) Token: 0x06000E87 RID: 3719 RVA: 0x003E9EA8 File Offset: 0x003E80A8
		public bool Hotbar2
		{
			get
			{
				return this.KeyStatus["Hotbar2"];
			}
			set
			{
				this.KeyStatus["Hotbar2"] = value;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000E88 RID: 3720 RVA: 0x003E9EBC File Offset: 0x003E80BC
		// (set) Token: 0x06000E89 RID: 3721 RVA: 0x003E9ED0 File Offset: 0x003E80D0
		public bool Hotbar3
		{
			get
			{
				return this.KeyStatus["Hotbar3"];
			}
			set
			{
				this.KeyStatus["Hotbar3"] = value;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000E8A RID: 3722 RVA: 0x003E9EE4 File Offset: 0x003E80E4
		// (set) Token: 0x06000E8B RID: 3723 RVA: 0x003E9EF8 File Offset: 0x003E80F8
		public bool Hotbar4
		{
			get
			{
				return this.KeyStatus["Hotbar4"];
			}
			set
			{
				this.KeyStatus["Hotbar4"] = value;
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000E8C RID: 3724 RVA: 0x003E9F0C File Offset: 0x003E810C
		// (set) Token: 0x06000E8D RID: 3725 RVA: 0x003E9F20 File Offset: 0x003E8120
		public bool Hotbar5
		{
			get
			{
				return this.KeyStatus["Hotbar5"];
			}
			set
			{
				this.KeyStatus["Hotbar5"] = value;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000E8E RID: 3726 RVA: 0x003E9F34 File Offset: 0x003E8134
		// (set) Token: 0x06000E8F RID: 3727 RVA: 0x003E9F48 File Offset: 0x003E8148
		public bool Hotbar6
		{
			get
			{
				return this.KeyStatus["Hotbar6"];
			}
			set
			{
				this.KeyStatus["Hotbar6"] = value;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000E90 RID: 3728 RVA: 0x003E9F5C File Offset: 0x003E815C
		// (set) Token: 0x06000E91 RID: 3729 RVA: 0x003E9F70 File Offset: 0x003E8170
		public bool Hotbar7
		{
			get
			{
				return this.KeyStatus["Hotbar7"];
			}
			set
			{
				this.KeyStatus["Hotbar7"] = value;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000E92 RID: 3730 RVA: 0x003E9F84 File Offset: 0x003E8184
		// (set) Token: 0x06000E93 RID: 3731 RVA: 0x003E9F98 File Offset: 0x003E8198
		public bool Hotbar8
		{
			get
			{
				return this.KeyStatus["Hotbar8"];
			}
			set
			{
				this.KeyStatus["Hotbar8"] = value;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000E94 RID: 3732 RVA: 0x003E9FAC File Offset: 0x003E81AC
		// (set) Token: 0x06000E95 RID: 3733 RVA: 0x003E9FC0 File Offset: 0x003E81C0
		public bool Hotbar9
		{
			get
			{
				return this.KeyStatus["Hotbar9"];
			}
			set
			{
				this.KeyStatus["Hotbar9"] = value;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000E96 RID: 3734 RVA: 0x003E9FD4 File Offset: 0x003E81D4
		// (set) Token: 0x06000E97 RID: 3735 RVA: 0x003E9FE8 File Offset: 0x003E81E8
		public bool Hotbar10
		{
			get
			{
				return this.KeyStatus["Hotbar10"];
			}
			set
			{
				this.KeyStatus["Hotbar10"] = value;
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000E98 RID: 3736 RVA: 0x003E9FFC File Offset: 0x003E81FC
		// (set) Token: 0x06000E99 RID: 3737 RVA: 0x003EA010 File Offset: 0x003E8210
		public bool HotbarMinus
		{
			get
			{
				return this.KeyStatus["HotbarMinus"];
			}
			set
			{
				this.KeyStatus["HotbarMinus"] = value;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000E9A RID: 3738 RVA: 0x003EA024 File Offset: 0x003E8224
		// (set) Token: 0x06000E9B RID: 3739 RVA: 0x003EA038 File Offset: 0x003E8238
		public bool HotbarPlus
		{
			get
			{
				return this.KeyStatus["HotbarPlus"];
			}
			set
			{
				this.KeyStatus["HotbarPlus"] = value;
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000E9C RID: 3740 RVA: 0x003EA04C File Offset: 0x003E824C
		// (set) Token: 0x06000E9D RID: 3741 RVA: 0x003EA060 File Offset: 0x003E8260
		public bool DpadRadial1
		{
			get
			{
				return this.KeyStatus["DpadRadial1"];
			}
			set
			{
				this.KeyStatus["DpadRadial1"] = value;
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000E9E RID: 3742 RVA: 0x003EA074 File Offset: 0x003E8274
		// (set) Token: 0x06000E9F RID: 3743 RVA: 0x003EA088 File Offset: 0x003E8288
		public bool DpadRadial2
		{
			get
			{
				return this.KeyStatus["DpadRadial2"];
			}
			set
			{
				this.KeyStatus["DpadRadial2"] = value;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000EA0 RID: 3744 RVA: 0x003EA09C File Offset: 0x003E829C
		// (set) Token: 0x06000EA1 RID: 3745 RVA: 0x003EA0B0 File Offset: 0x003E82B0
		public bool DpadRadial3
		{
			get
			{
				return this.KeyStatus["DpadRadial3"];
			}
			set
			{
				this.KeyStatus["DpadRadial3"] = value;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06000EA2 RID: 3746 RVA: 0x003EA0C4 File Offset: 0x003E82C4
		// (set) Token: 0x06000EA3 RID: 3747 RVA: 0x003EA0D8 File Offset: 0x003E82D8
		public bool DpadRadial4
		{
			get
			{
				return this.KeyStatus["DpadRadial4"];
			}
			set
			{
				this.KeyStatus["DpadRadial4"] = value;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000EA4 RID: 3748 RVA: 0x003EA0EC File Offset: 0x003E82EC
		// (set) Token: 0x06000EA5 RID: 3749 RVA: 0x003EA100 File Offset: 0x003E8300
		public bool RadialHotbar
		{
			get
			{
				return this.KeyStatus["RadialHotbar"];
			}
			set
			{
				this.KeyStatus["RadialHotbar"] = value;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000EA6 RID: 3750 RVA: 0x003EA114 File Offset: 0x003E8314
		// (set) Token: 0x06000EA7 RID: 3751 RVA: 0x003EA128 File Offset: 0x003E8328
		public bool RadialQuickbar
		{
			get
			{
				return this.KeyStatus["RadialQuickbar"];
			}
			set
			{
				this.KeyStatus["RadialQuickbar"] = value;
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000EA8 RID: 3752 RVA: 0x003EA13C File Offset: 0x003E833C
		// (set) Token: 0x06000EA9 RID: 3753 RVA: 0x003EA150 File Offset: 0x003E8350
		public bool DpadMouseSnap1
		{
			get
			{
				return this.KeyStatus["DpadSnap1"];
			}
			set
			{
				this.KeyStatus["DpadSnap1"] = value;
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000EAA RID: 3754 RVA: 0x003EA164 File Offset: 0x003E8364
		// (set) Token: 0x06000EAB RID: 3755 RVA: 0x003EA178 File Offset: 0x003E8378
		public bool DpadMouseSnap2
		{
			get
			{
				return this.KeyStatus["DpadSnap2"];
			}
			set
			{
				this.KeyStatus["DpadSnap2"] = value;
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000EAC RID: 3756 RVA: 0x003EA18C File Offset: 0x003E838C
		// (set) Token: 0x06000EAD RID: 3757 RVA: 0x003EA1A0 File Offset: 0x003E83A0
		public bool DpadMouseSnap3
		{
			get
			{
				return this.KeyStatus["DpadSnap3"];
			}
			set
			{
				this.KeyStatus["DpadSnap3"] = value;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000EAE RID: 3758 RVA: 0x003EA1B4 File Offset: 0x003E83B4
		// (set) Token: 0x06000EAF RID: 3759 RVA: 0x003EA1C8 File Offset: 0x003E83C8
		public bool DpadMouseSnap4
		{
			get
			{
				return this.KeyStatus["DpadSnap4"];
			}
			set
			{
				this.KeyStatus["DpadSnap4"] = value;
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000EB0 RID: 3760 RVA: 0x003EA1DC File Offset: 0x003E83DC
		// (set) Token: 0x06000EB1 RID: 3761 RVA: 0x003EA1F0 File Offset: 0x003E83F0
		public bool MenuUp
		{
			get
			{
				return this.KeyStatus["MenuUp"];
			}
			set
			{
				this.KeyStatus["MenuUp"] = value;
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06000EB2 RID: 3762 RVA: 0x003EA204 File Offset: 0x003E8404
		// (set) Token: 0x06000EB3 RID: 3763 RVA: 0x003EA218 File Offset: 0x003E8418
		public bool MenuDown
		{
			get
			{
				return this.KeyStatus["MenuDown"];
			}
			set
			{
				this.KeyStatus["MenuDown"] = value;
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06000EB4 RID: 3764 RVA: 0x003EA22C File Offset: 0x003E842C
		// (set) Token: 0x06000EB5 RID: 3765 RVA: 0x003EA240 File Offset: 0x003E8440
		public bool MenuLeft
		{
			get
			{
				return this.KeyStatus["MenuLeft"];
			}
			set
			{
				this.KeyStatus["MenuLeft"] = value;
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000EB6 RID: 3766 RVA: 0x003EA254 File Offset: 0x003E8454
		// (set) Token: 0x06000EB7 RID: 3767 RVA: 0x003EA268 File Offset: 0x003E8468
		public bool MenuRight
		{
			get
			{
				return this.KeyStatus["MenuRight"];
			}
			set
			{
				this.KeyStatus["MenuRight"] = value;
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000EB8 RID: 3768 RVA: 0x003EA27C File Offset: 0x003E847C
		// (set) Token: 0x06000EB9 RID: 3769 RVA: 0x003EA290 File Offset: 0x003E8490
		public bool LockOn
		{
			get
			{
				return this.KeyStatus["LockOn"];
			}
			set
			{
				this.KeyStatus["LockOn"] = value;
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000EBA RID: 3770 RVA: 0x003EA2A4 File Offset: 0x003E84A4
		// (set) Token: 0x06000EBB RID: 3771 RVA: 0x003EA2B8 File Offset: 0x003E84B8
		public bool ViewZoomIn
		{
			get
			{
				return this.KeyStatus["ViewZoomIn"];
			}
			set
			{
				this.KeyStatus["ViewZoomIn"] = value;
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000EBC RID: 3772 RVA: 0x003EA2CC File Offset: 0x003E84CC
		// (set) Token: 0x06000EBD RID: 3773 RVA: 0x003EA2E0 File Offset: 0x003E84E0
		public bool ViewZoomOut
		{
			get
			{
				return this.KeyStatus["ViewZoomOut"];
			}
			set
			{
				this.KeyStatus["ViewZoomOut"] = value;
			}
		}

		// Token: 0x06000EBE RID: 3774 RVA: 0x003EA2F4 File Offset: 0x003E84F4
		public void Reset()
		{
			string[] array = this.KeyStatus.Keys.ToArray<string>();
			for (int i = 0; i < array.Length; i++)
			{
				this.KeyStatus[array[i]] = false;
			}
		}

		// Token: 0x06000EBF RID: 3775 RVA: 0x003EA330 File Offset: 0x003E8530
		public TriggersSet Clone()
		{
			TriggersSet triggersSet = new TriggersSet();
			foreach (string current in this.KeyStatus.Keys)
			{
				triggersSet.KeyStatus.Add(current, this.KeyStatus[current]);
			}
			triggersSet.UsedMovementKey = this.UsedMovementKey;
			triggersSet.HotbarScrollCD = this.HotbarScrollCD;
			triggersSet.HotbarHoldTime = this.HotbarHoldTime;
			return triggersSet;
		}

		// Token: 0x06000EC0 RID: 3776 RVA: 0x003EA3C4 File Offset: 0x003E85C4
		public void SetupKeys()
		{
			this.KeyStatus.Clear();
			foreach (string current in PlayerInput.KnownTriggers)
			{
				this.KeyStatus.Add(current, false);
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000EC1 RID: 3777 RVA: 0x003EA428 File Offset: 0x003E8628
		public Vector2 DirectionsRaw
		{
			get
			{
				return new Vector2((float)(this.Right.ToInt() - this.Left.ToInt()), (float)(this.Down.ToInt() - this.Up.ToInt()));
			}
		}

		// Token: 0x06000EC2 RID: 3778 RVA: 0x003EA460 File Offset: 0x003E8660
		public Vector2 GetNavigatorDirections()
		{
			bool flag = Main.gameMenu || Main.ingameOptionsWindow || Main.editChest || Main.editSign || (Main.playerInventory && PlayerInput.CurrentProfile.UsingDpadMovekeys());
			bool value = this.Up || (flag && this.MenuUp);
			bool arg_93_0 = this.Right || (flag && this.MenuRight);
			bool value2 = this.Down || (flag && this.MenuDown);
			bool value3 = this.Left || (flag && this.MenuLeft);
			return new Vector2((float)(arg_93_0.ToInt() - value3.ToInt()), (float)(value2.ToInt() - value.ToInt()));
		}

		// Token: 0x06000EC3 RID: 3779 RVA: 0x003EA520 File Offset: 0x003E8720
		public void CopyInto(Player p)
		{
			if (PlayerInput.CurrentInputMode != InputMode.XBoxGamepadUI && !PlayerInput.CursorIsBusy)
			{
				p.controlUp = this.Up;
				p.controlDown = this.Down;
				p.controlLeft = this.Left;
				p.controlRight = this.Right;
				p.controlJump = this.Jump;
				p.controlHook = this.Grapple;
				p.controlTorch = this.SmartSelect;
				p.controlSmart = this.SmartCursor;
				p.controlMount = this.QuickMount;
				p.controlQuickHeal = this.QuickHeal;
				p.controlQuickMana = this.QuickMana;
				if (this.QuickBuff)
				{
					p.QuickBuff();
				}
			}
			p.controlInv = this.Inventory;
			p.controlThrow = this.Throw;
			p.mapZoomIn = this.MapZoomIn;
			p.mapZoomOut = this.MapZoomOut;
			p.mapAlphaUp = this.MapAlphaUp;
			p.mapAlphaDown = this.MapAlphaDown;
			p.mapFullScreen = this.MapFull;
			p.mapStyle = this.MapStyle;
			if (this.MouseLeft)
			{
				if (!Main.blockMouse && !p.mouseInterface)
				{
					p.controlUseItem = true;
				}
			}
			else
			{
				Main.blockMouse = false;
			}
			if (!this.MouseRight && !Main.playerInventory)
			{
				PlayerInput.LockTileUseButton = false;
			}
			if (this.MouseRight && !p.mouseInterface && (!Main.blockMouse & !PlayerInput.LockTileUseButton) && !PlayerInput.InBuildingMode)
			{
				p.controlUseTile = true;
			}
			if (PlayerInput.InBuildingMode && this.MouseRight)
			{
				p.controlInv = true;
			}
			bool flag = PlayerInput.Triggers.Current.HotbarPlus || PlayerInput.Triggers.Current.HotbarMinus;
			if (flag)
			{
				this.HotbarHoldTime++;
			}
			else
			{
				this.HotbarHoldTime = 0;
			}
			if (this.HotbarScrollCD > 0 && (!(this.HotbarScrollCD == 1 & flag) || PlayerInput.CurrentProfile.HotbarRadialHoldTimeRequired <= 0))
			{
				this.HotbarScrollCD--;
			}
		}

		// Token: 0x06000EC4 RID: 3780 RVA: 0x003EA728 File Offset: 0x003E8928
		public void CopyIntoDuringChat(Player p)
		{
			if (this.MouseLeft)
			{
				if (!Main.blockMouse && !p.mouseInterface)
				{
					p.controlUseItem = true;
				}
			}
			else
			{
				Main.blockMouse = false;
			}
			if (!this.MouseRight && !Main.playerInventory)
			{
				PlayerInput.LockTileUseButton = false;
			}
			if (this.MouseRight && !p.mouseInterface && (!Main.blockMouse & !PlayerInput.LockTileUseButton) && !PlayerInput.InBuildingMode)
			{
				p.controlUseTile = true;
			}
			bool flag = PlayerInput.Triggers.Current.HotbarPlus || PlayerInput.Triggers.Current.HotbarMinus;
			if (flag)
			{
				this.HotbarHoldTime++;
			}
			else
			{
				this.HotbarHoldTime = 0;
			}
			if (this.HotbarScrollCD > 0 && (!(this.HotbarScrollCD == 1 & flag) || PlayerInput.CurrentProfile.HotbarRadialHoldTimeRequired <= 0))
			{
				this.HotbarScrollCD--;
			}
		}

		// Token: 0x04002FE7 RID: 12263
		public Dictionary<string, bool> KeyStatus = new Dictionary<string, bool>();

		// Token: 0x04002FE8 RID: 12264
		public bool UsedMovementKey = true;

		// Token: 0x04002FE9 RID: 12265
		public int HotbarScrollCD;

		// Token: 0x04002FEA RID: 12266
		public int HotbarHoldTime;
	}
}

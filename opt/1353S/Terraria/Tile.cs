using System;
using Microsoft.Xna.Framework;

namespace Terraria
{
	// Token: 0x0200002F RID: 47
	public class Tile
	{
		// Token: 0x06000452 RID: 1106 RVA: 0x002935FC File Offset: 0x002917FC
		public Tile()
		{
			this.type = 0;
			this.wall = 0;
			this.liquid = 0;
			this.sTileHeader = 0;
			this.bTileHeader = 0;
			this.bTileHeader2 = 0;
			this.bTileHeader3 = 0;
			this.frameX = 0;
			this.frameY = 0;
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x00293650 File Offset: 0x00291850
		public Tile(Tile copy)
		{
			if (copy == null)
			{
				this.type = 0;
				this.wall = 0;
				this.liquid = 0;
				this.sTileHeader = 0;
				this.bTileHeader = 0;
				this.bTileHeader2 = 0;
				this.bTileHeader3 = 0;
				this.frameX = 0;
				this.frameY = 0;
				return;
			}
			this.type = copy.type;
			this.wall = copy.wall;
			this.liquid = copy.liquid;
			this.sTileHeader = copy.sTileHeader;
			this.bTileHeader = copy.bTileHeader;
			this.bTileHeader2 = copy.bTileHeader2;
			this.bTileHeader3 = copy.bTileHeader3;
			this.frameX = copy.frameX;
			this.frameY = copy.frameY;
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x002939F0 File Offset: 0x00291BF0
		public Color actColor(Color oldColor)
		{
			if (!this.inActive())
			{
				return oldColor;
			}
			double num = 0.4;
			return new Color((int)((byte)(num * (double)oldColor.R)), (int)((byte)(num * (double)oldColor.G)), (int)((byte)(num * (double)oldColor.B)), (int)oldColor.A);
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x00293CFF File Offset: 0x00291EFF
		public bool active()
		{
			return (this.sTileHeader & 32) == 32;
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x00293D0E File Offset: 0x00291F0E
		public void active(bool active)
		{
			if (active)
			{
				this.sTileHeader |= 32;
				return;
			}
			this.sTileHeader = (short)((int)this.sTileHeader & 65503);
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x00293E73 File Offset: 0x00292073
		public bool actuator()
		{
			return (this.sTileHeader & 2048) == 2048;
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x00293E88 File Offset: 0x00292088
		public void actuator(bool actuator)
		{
			if (actuator)
			{
				this.sTileHeader |= 2048;
				return;
			}
			this.sTileHeader = (short)((int)this.sTileHeader & 63487);
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00293908 File Offset: 0x00291B08
		public int blockType()
		{
			if (this.halfBrick())
			{
				return 1;
			}
			int num = (int)this.slope();
			if (num > 0)
			{
				num++;
			}
			return num;
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x00293A60 File Offset: 0x00291C60
		public bool bottomSlope()
		{
			byte b = this.slope();
			return b == 3 || b == 4;
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x00293C66 File Offset: 0x00291E66
		public bool checkingLiquid()
		{
			return (this.bTileHeader3 & 8) == 8;
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x00293C73 File Offset: 0x00291E73
		public void checkingLiquid(bool checkingLiquid)
		{
			if (checkingLiquid)
			{
				this.bTileHeader3 |= 8;
				return;
			}
			this.bTileHeader3 &= 247;
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00293714 File Offset: 0x00291914
		public void ClearEverything()
		{
			this.type = 0;
			this.wall = 0;
			this.liquid = 0;
			this.sTileHeader = 0;
			this.bTileHeader = 0;
			this.bTileHeader2 = 0;
			this.bTileHeader3 = 0;
			this.frameX = 0;
			this.frameY = 0;
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x002939BA File Offset: 0x00291BBA
		internal void ClearMetadata()
		{
			this.liquid = 0;
			this.sTileHeader = 0;
			this.bTileHeader = 0;
			this.bTileHeader2 = 0;
			this.bTileHeader3 = 0;
			this.frameX = 0;
			this.frameY = 0;
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00293760 File Offset: 0x00291960
		public void ClearTile()
		{
			this.slope(0);
			this.halfBrick(false);
			this.active(false);
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00003C56 File Offset: 0x00001E56
		public object Clone()
		{
			return base.MemberwiseClone();
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x00293CD3 File Offset: 0x00291ED3
		public byte color()
		{
			return (byte)(this.sTileHeader & 31);
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x00293CDF File Offset: 0x00291EDF
		public void color(byte color)
		{
			if (color > 30)
			{
				color = 30;
			}
			this.sTileHeader = (short)(((int)this.sTileHeader & 65504) | (int)color);
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x00293778 File Offset: 0x00291978
		public void CopyFrom(Tile from)
		{
			this.type = from.type;
			this.wall = from.wall;
			this.liquid = from.liquid;
			this.sTileHeader = from.sTileHeader;
			this.bTileHeader = from.bTileHeader;
			this.bTileHeader2 = from.bTileHeader2;
			this.bTileHeader3 = from.bTileHeader3;
			this.frameX = from.frameX;
			this.frameY = from.frameY;
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x00293BEB File Offset: 0x00291DEB
		public byte frameNumber()
		{
			return (byte)((this.bTileHeader2 & 48) >> 4);
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00293BF9 File Offset: 0x00291DF9
		public void frameNumber(byte frameNumber)
		{
			this.bTileHeader2 = (byte)((int)(this.bTileHeader2 & 207) | (int)(frameNumber & 3) << 4);
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x00293E32 File Offset: 0x00292032
		public bool halfBrick()
		{
			return (this.sTileHeader & 1024) == 1024;
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00293E47 File Offset: 0x00292047
		public void halfBrick(bool halfBrick)
		{
			if (halfBrick)
			{
				this.sTileHeader |= 1024;
				return;
			}
			this.sTileHeader = (short)((int)this.sTileHeader & 64511);
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00293ABE File Offset: 0x00291CBE
		public bool HasSameSlope(Tile tile)
		{
			return (this.sTileHeader & 29696) == (tile.sTileHeader & 29696);
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x00293B44 File Offset: 0x00291D44
		public bool honey()
		{
			return (this.bTileHeader & 64) == 64;
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x00293B53 File Offset: 0x00291D53
		public void honey(bool honey)
		{
			if (honey)
			{
				this.bTileHeader = ((byte)((this.bTileHeader & 159) | 64));
				return;
			}
			this.bTileHeader &= 191;
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x00293D37 File Offset: 0x00291F37
		public bool inActive()
		{
			return (this.sTileHeader & 64) == 64;
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x00293D46 File Offset: 0x00291F46
		public void inActive(bool inActive)
		{
			if (inActive)
			{
				this.sTileHeader |= 64;
				return;
			}
			this.sTileHeader = (short)((int)this.sTileHeader & 65471);
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00293848 File Offset: 0x00291A48
		public bool isTheSameAs(Tile compTile)
		{
			if (compTile == null)
			{
				return false;
			}
			if (this.sTileHeader != compTile.sTileHeader)
			{
				return false;
			}
			if (this.active())
			{
				if (this.type != compTile.type)
				{
					return false;
				}
				if (Main.tileFrameImportant[(int)this.type] && (this.frameX != compTile.frameX || this.frameY != compTile.frameY))
				{
					return false;
				}
			}
			if (this.wall != compTile.wall || this.liquid != compTile.liquid)
			{
				return false;
			}
			if (compTile.liquid == 0)
			{
				if (this.wallColor() != compTile.wallColor())
				{
					return false;
				}
				if (this.wire4() != compTile.wire4())
				{
					return false;
				}
			}
			else if (this.bTileHeader != compTile.bTileHeader)
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x00293B06 File Offset: 0x00291D06
		public bool lava()
		{
			return (this.bTileHeader & 32) == 32;
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x00293B15 File Offset: 0x00291D15
		public void lava(bool lava)
		{
			if (lava)
			{
				this.bTileHeader = ((byte)((this.bTileHeader & 159) | 32));
				return;
			}
			this.bTileHeader &= 223;
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x00293A80 File Offset: 0x00291C80
		public bool leftSlope()
		{
			byte b = this.slope();
			return b == 2 || b == 4;
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x0029395F File Offset: 0x00291B5F
		public byte liquidType()
		{
			return (byte)((this.bTileHeader & 96) >> 5);
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x0029392F File Offset: 0x00291B2F
		public void liquidType(int liquidType)
		{
			if (liquidType == 0)
			{
				this.bTileHeader &= 159;
				return;
			}
			if (liquidType == 1)
			{
				this.lava(true);
				return;
			}
			if (liquidType == 2)
			{
				this.honey(true);
			}
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x0029396D File Offset: 0x00291B6D
		public bool nactive()
		{
			return (this.sTileHeader & 96) == 32;
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x0029397F File Offset: 0x00291B7F
		public void ResetToType(ushort type)
		{
			this.liquid = 0;
			this.sTileHeader = 32;
			this.bTileHeader = 0;
			this.bTileHeader2 = 0;
			this.bTileHeader3 = 0;
			this.frameX = 0;
			this.frameY = 0;
			this.type = type;
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00293AA0 File Offset: 0x00291CA0
		public bool rightSlope()
		{
			byte b = this.slope();
			return b == 1 || b == 3;
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x00293C9B File Offset: 0x00291E9B
		public bool skipLiquid()
		{
			return (this.bTileHeader3 & 16) == 16;
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x00293CAA File Offset: 0x00291EAA
		public void skipLiquid(bool skipLiquid)
		{
			if (skipLiquid)
			{
				this.bTileHeader3 |= 16;
				return;
			}
			this.bTileHeader3 &= 239;
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x00293EB4 File Offset: 0x002920B4
		public byte slope()
		{
			return (byte)((this.sTileHeader & 28672) >> 12);
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x00293EC6 File Offset: 0x002920C6
		public void slope(byte slope)
		{
			this.sTileHeader = (short)(((int)this.sTileHeader & 36863) | (int)(slope & 7) << 12);
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x00293EE4 File Offset: 0x002920E4
		public static void SmoothSlope(int x, int y, bool applyToNeighbors = true)
		{
			if (applyToNeighbors)
			{
				Tile.SmoothSlope(x + 1, y, false);
				Tile.SmoothSlope(x - 1, y, false);
				Tile.SmoothSlope(x, y + 1, false);
				Tile.SmoothSlope(x, y - 1, false);
			}
			Tile tile = Main.tile[x, y];
			if (!WorldGen.SolidOrSlopedTile(x, y))
			{
				return;
			}
			bool flag = !WorldGen.TileEmpty(x, y - 1);
			bool flag2 = !WorldGen.SolidOrSlopedTile(x, y - 1) & flag;
			bool flag3 = WorldGen.SolidOrSlopedTile(x, y + 1);
			bool flag4 = WorldGen.SolidOrSlopedTile(x - 1, y);
			bool flag5 = WorldGen.SolidOrSlopedTile(x + 1, y);
			switch ((flag ? 1 : 0) << 3 | (flag3 ? 1 : 0) << 2 | (flag4 ? 1 : 0) << 1 | (flag5 ? 1 : 0))
			{
				case 4:
					tile.slope(0);
					tile.halfBrick(true);
					return;
				case 5:
					tile.halfBrick(false);
					tile.slope(2);
					return;
				case 6:
					tile.halfBrick(false);
					tile.slope(1);
					return;
				case 9:
					if (!flag2)
					{
						tile.halfBrick(false);
						tile.slope(4);
						return;
					}
					return;
				case 10:
					if (!flag2)
					{
						tile.halfBrick(false);
						tile.slope(3);
						return;
					}
					return;
			}
			tile.halfBrick(false);
			tile.slope(0);
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00293A40 File Offset: 0x00291C40
		public bool topSlope()
		{
			byte b = this.slope();
			return b == 1 || b == 2;
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x00294020 File Offset: 0x00292220
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"Tile Type:",
				this.type,
				" Active:",
				this.active().ToString(),
				" Wall:",
				this.wall,
				" Slope:",
				this.slope(),
				" fX:",
				this.frameX,
				" fY:",
				this.frameY
			});
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x00293ADA File Offset: 0x00291CDA
		public byte wallColor()
		{
			return (byte)(this.bTileHeader & 31);
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00293AE6 File Offset: 0x00291CE6
		public void wallColor(byte wallColor)
		{
			if (wallColor > 30)
			{
				wallColor = 30;
			}
			this.bTileHeader = ((byte)((this.bTileHeader & 224) | wallColor));
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x00293C14 File Offset: 0x00291E14
		public byte wallFrameNumber()
		{
			return (byte)((this.bTileHeader2 & 192) >> 6);
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x00293C25 File Offset: 0x00291E25
		public void wallFrameNumber(byte wallFrameNumber)
		{
			this.bTileHeader2 = (byte)((int)(this.bTileHeader2 & 63) | (int)(wallFrameNumber & 3) << 6);
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00293BC0 File Offset: 0x00291DC0
		public int wallFrameX()
		{
			return (int)((this.bTileHeader2 & 15) * 36);
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x00293BCE File Offset: 0x00291DCE
		public void wallFrameX(int wallFrameX)
		{
			this.bTileHeader2 = (byte)((int)(this.bTileHeader2 & 240) | (wallFrameX / 36 & 15));
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x00293C3D File Offset: 0x00291E3D
		public int wallFrameY()
		{
			return (int)((this.bTileHeader3 & 7) * 36);
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x00293C4A File Offset: 0x00291E4A
		public void wallFrameY(int wallFrameY)
		{
			this.bTileHeader3 = (byte)((int)(this.bTileHeader3 & 248) | (wallFrameY / 36 & 7));
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x00293D6F File Offset: 0x00291F6F
		public bool wire()
		{
			return (this.sTileHeader & 128) == 128;
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x00293D84 File Offset: 0x00291F84
		public void wire(bool wire)
		{
			if (wire)
			{
				this.sTileHeader |= 128;
				return;
			}
			this.sTileHeader = (short)((int)this.sTileHeader & 65407);
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x00293DB0 File Offset: 0x00291FB0
		public bool wire2()
		{
			return (this.sTileHeader & 256) == 256;
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x00293DC5 File Offset: 0x00291FC5
		public void wire2(bool wire2)
		{
			if (wire2)
			{
				this.sTileHeader |= 256;
				return;
			}
			this.sTileHeader = (short)((int)this.sTileHeader & 65279);
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x00293DF1 File Offset: 0x00291FF1
		public bool wire3()
		{
			return (this.sTileHeader & 512) == 512;
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x00293E06 File Offset: 0x00292006
		public void wire3(bool wire3)
		{
			if (wire3)
			{
				this.sTileHeader |= 512;
				return;
			}
			this.sTileHeader = (short)((int)this.sTileHeader & 65023);
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x00293B82 File Offset: 0x00291D82
		public bool wire4()
		{
			return (this.bTileHeader & 128) == 128;
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x00293B97 File Offset: 0x00291D97
		public void wire4(bool wire4)
		{
			if (wire4)
			{
				this.bTileHeader |= 128;
				return;
			}
			this.bTileHeader &= 127;
		}

		// Token: 0x1700008A RID: 138
		public int collisionType
		{
			// Token: 0x06000458 RID: 1112 RVA: 0x002937F4 File Offset: 0x002919F4
			get
			{
				if (!this.active())
				{
					return 0;
				}
				if (this.halfBrick())
				{
					return 2;
				}
				if (this.slope() > 0)
				{
					return (int)(2 + this.slope());
				}
				if (Main.tileSolid[(int)this.type] && !Main.tileSolidTop[(int)this.type])
				{
					return 1;
				}
				return -1;
			}
		}

		// Token: 0x040006BE RID: 1726
		public byte bTileHeader;

		// Token: 0x040006BF RID: 1727
		public byte bTileHeader2;

		// Token: 0x040006C0 RID: 1728
		public byte bTileHeader3;

		// Token: 0x040006C1 RID: 1729
		public short frameX;

		// Token: 0x040006C2 RID: 1730
		public short frameY;

		// Token: 0x040006BC RID: 1724
		public byte liquid;

		// Token: 0x040006CB RID: 1739
		public const int Liquid_Honey = 2;

		// Token: 0x040006CA RID: 1738
		public const int Liquid_Lava = 1;

		// Token: 0x040006C9 RID: 1737
		public const int Liquid_Water = 0;

		// Token: 0x040006BD RID: 1725
		public short sTileHeader;

		// Token: 0x040006BA RID: 1722
		public ushort type;

		// Token: 0x040006C4 RID: 1732
		public const int Type_Halfbrick = 1;

		// Token: 0x040006C6 RID: 1734
		public const int Type_SlopeDownLeft = 3;

		// Token: 0x040006C5 RID: 1733
		public const int Type_SlopeDownRight = 2;

		// Token: 0x040006C8 RID: 1736
		public const int Type_SlopeUpLeft = 5;

		// Token: 0x040006C7 RID: 1735
		public const int Type_SlopeUpRight = 4;

		// Token: 0x040006C3 RID: 1731
		public const int Type_Solid = 0;

		// Token: 0x040006BB RID: 1723
		public byte wall;
	}
}

using System;
using System.IO;
using Terraria.Localization;

namespace Terraria.DataStructures
{
	// Token: 0x0200018D RID: 397
	public class PlayerDeathReason
	{
		// Token: 0x060012BB RID: 4795 RVA: 0x00419024 File Offset: 0x00417224
		public static PlayerDeathReason LegacyEmpty()
		{
			return new PlayerDeathReason
			{
				SourceOtherIndex = 254
			};
		}

		// Token: 0x060012BC RID: 4796 RVA: 0x00419038 File Offset: 0x00417238
		public static PlayerDeathReason LegacyDefault()
		{
			return new PlayerDeathReason
			{
				SourceOtherIndex = 255
			};
		}

		// Token: 0x060012BD RID: 4797 RVA: 0x0041904C File Offset: 0x0041724C
		public static PlayerDeathReason ByNPC(int index)
		{
			return new PlayerDeathReason
			{
				SourceNPCIndex = index
			};
		}

		// Token: 0x060012BE RID: 4798 RVA: 0x0041905C File Offset: 0x0041725C
		public static PlayerDeathReason ByCustomReason(string reasonInEnglish)
		{
			return new PlayerDeathReason
			{
				SourceCustomReason = reasonInEnglish
			};
		}

		// Token: 0x060012BF RID: 4799 RVA: 0x0041906C File Offset: 0x0041726C
		public static PlayerDeathReason ByPlayer(int index)
		{
			return new PlayerDeathReason
			{
				SourcePlayerIndex = index,
				SourceItemType = Main.player[index].inventory[Main.player[index].selectedItem].type,
				SourceItemPrefix = (int)Main.player[index].inventory[Main.player[index].selectedItem].prefix
			};
		}

		// Token: 0x060012C0 RID: 4800 RVA: 0x004190D0 File Offset: 0x004172D0
		public static PlayerDeathReason ByOther(int type)
		{
			return new PlayerDeathReason
			{
				SourceOtherIndex = type
			};
		}

		// Token: 0x060012C1 RID: 4801 RVA: 0x004190E0 File Offset: 0x004172E0
		public static PlayerDeathReason ByProjectile(int playerIndex, int projectileIndex)
		{
			PlayerDeathReason playerDeathReason = new PlayerDeathReason
			{
				SourcePlayerIndex = playerIndex,
				SourceProjectileIndex = projectileIndex,
				SourceProjectileType = Main.projectile[projectileIndex].type
			};
			if (playerIndex >= 0 && playerIndex <= 255)
			{
				playerDeathReason.SourceItemType = Main.player[playerIndex].inventory[Main.player[playerIndex].selectedItem].type;
				playerDeathReason.SourceItemPrefix = (int)Main.player[playerIndex].inventory[Main.player[playerIndex].selectedItem].prefix;
			}
			return playerDeathReason;
		}

		// Token: 0x060012C2 RID: 4802 RVA: 0x00419168 File Offset: 0x00417368
		public NetworkText GetDeathText(string deadPlayerName)
		{
			if (this.SourceCustomReason != null)
			{
				return NetworkText.FromLiteral(this.SourceCustomReason);
			}
			return Lang.CreateDeathMessage(deadPlayerName, this.SourcePlayerIndex, this.SourceNPCIndex, this.SourceProjectileIndex, this.SourceOtherIndex, this.SourceProjectileType, this.SourceItemType);
		}

		// Token: 0x060012C3 RID: 4803 RVA: 0x004191A8 File Offset: 0x004173A8
		public void WriteSelfTo(BinaryWriter writer)
		{
			BitsByte bb = 0;
			bb[0] = (this.SourcePlayerIndex != -1);
			bb[1] = (this.SourceNPCIndex != -1);
			bb[2] = (this.SourceProjectileIndex != -1);
			bb[3] = (this.SourceOtherIndex != -1);
			bb[4] = (this.SourceProjectileType != 0);
			bb[5] = (this.SourceItemType != 0);
			bb[6] = (this.SourceItemPrefix != 0);
			bb[7] = (this.SourceCustomReason != null);
			writer.Write(bb);
			if (bb[0])
			{
				writer.Write((short)this.SourcePlayerIndex);
			}
			if (bb[1])
			{
				writer.Write((short)this.SourceNPCIndex);
			}
			if (bb[2])
			{
				writer.Write((short)this.SourceProjectileIndex);
			}
			if (bb[3])
			{
				writer.Write((byte)this.SourceOtherIndex);
			}
			if (bb[4])
			{
				writer.Write((short)this.SourceProjectileType);
			}
			if (bb[5])
			{
				writer.Write((short)this.SourceItemType);
			}
			if (bb[6])
			{
				writer.Write((byte)this.SourceItemPrefix);
			}
			if (bb[7])
			{
				writer.Write(this.SourceCustomReason);
			}
		}

		// Token: 0x060012C4 RID: 4804 RVA: 0x00419314 File Offset: 0x00417514
		public static PlayerDeathReason FromReader(BinaryReader reader)
		{
			PlayerDeathReason playerDeathReason = new PlayerDeathReason();
			BitsByte bitsByte = reader.ReadByte();
			if (bitsByte[0])
			{
				playerDeathReason.SourcePlayerIndex = (int)reader.ReadInt16();
			}
			if (bitsByte[1])
			{
				playerDeathReason.SourceNPCIndex = (int)reader.ReadInt16();
			}
			if (bitsByte[2])
			{
				playerDeathReason.SourceProjectileIndex = (int)reader.ReadInt16();
			}
			if (bitsByte[3])
			{
				playerDeathReason.SourceOtherIndex = (int)reader.ReadByte();
			}
			if (bitsByte[4])
			{
				playerDeathReason.SourceProjectileType = (int)reader.ReadInt16();
			}
			if (bitsByte[5])
			{
				playerDeathReason.SourceItemType = (int)reader.ReadInt16();
			}
			if (bitsByte[6])
			{
				playerDeathReason.SourceItemPrefix = (int)reader.ReadByte();
			}
			if (bitsByte[7])
			{
				playerDeathReason.SourceCustomReason = reader.ReadString();
			}
			return playerDeathReason;
		}

		// Token: 0x04003468 RID: 13416
		private int SourcePlayerIndex = -1;

		// Token: 0x04003469 RID: 13417
		private int SourceNPCIndex = -1;

		// Token: 0x0400346A RID: 13418
		private int SourceProjectileIndex = -1;

		// Token: 0x0400346B RID: 13419
		private int SourceOtherIndex = -1;

		// Token: 0x0400346C RID: 13420
		private int SourceProjectileType;

		// Token: 0x0400346D RID: 13421
		private int SourceItemType;

		// Token: 0x0400346E RID: 13422
		private int SourceItemPrefix;

		// Token: 0x0400346F RID: 13423
		private string SourceCustomReason;
	}
}

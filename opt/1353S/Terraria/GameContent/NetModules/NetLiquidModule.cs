using System;
using System.Collections.Generic;
using System.IO;
using Terraria.Net;

namespace Terraria.GameContent.NetModules
{
	// Token: 0x02000171 RID: 369
	public class NetLiquidModule : NetModule
	{
		// Token: 0x06001216 RID: 4630 RVA: 0x00412E2C File Offset: 0x0041102C
		public static NetPacket Serialize(HashSet<int> changes)
		{
			NetPacket result = NetModule.CreatePacket<NetLiquidModule>(changes.Count * 6 + 2);
			result.Writer.Write((ushort)changes.Count);
			foreach (int current in changes)
			{
				int num = current >> 16 & 65535;
				int num2 = current & 65535;
				result.Writer.Write(current);
				result.Writer.Write(Main.tile[num, num2].liquid);
				result.Writer.Write(Main.tile[num, num2].liquidType());
			}
			return result;
		}

		// Token: 0x06001217 RID: 4631 RVA: 0x00412EF4 File Offset: 0x004110F4
		public override bool Deserialize(BinaryReader reader, int userId)
		{
			int num = (int)reader.ReadUInt16();
			for (int i = 0; i < num; i++)
			{
				int arg_1F_0 = reader.ReadInt32();
				byte liquid = reader.ReadByte();
				byte liquidType = reader.ReadByte();
				int num2 = arg_1F_0 >> 16 & 65535;
				int num3 = arg_1F_0 & 65535;
				Tile tile = Main.tile[num2, num3];
				if (tile != null)
				{
					tile.liquid = liquid;
					tile.liquidType((int)liquidType);
				}
			}
			return true;
		}
	}
}

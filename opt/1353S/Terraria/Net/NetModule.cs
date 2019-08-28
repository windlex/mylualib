using System;
using System.IO;

namespace Terraria.Net
{
	// Token: 0x0200006D RID: 109
	public abstract class NetModule
	{
		// Token: 0x060009D4 RID: 2516 RVA: 0x003B7418 File Offset: 0x003B5618
		public NetModule()
		{
		}

		// Token: 0x060009D5 RID: 2517
		public abstract bool Deserialize(BinaryReader reader, int userId);

		// Token: 0x060009D6 RID: 2518 RVA: 0x003B7420 File Offset: 0x003B5620
		protected static NetPacket CreatePacket<T>(int maxSize) where T : NetModule
		{
			ushort id = NetManager.Instance.GetId<T>();
			return new NetPacket(id, maxSize);
		}
	}
}

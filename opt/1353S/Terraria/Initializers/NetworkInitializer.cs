using System;
using Terraria.GameContent.NetModules;
using Terraria.Net;

namespace Terraria.Initializers
{
	// Token: 0x02000084 RID: 132
	public static class NetworkInitializer
	{
		// Token: 0x06000ABA RID: 2746 RVA: 0x003C7020 File Offset: 0x003C5220
		public static void Load()
		{
			NetManager.Instance.Register<NetLiquidModule>();
			NetManager.Instance.Register<NetTextModule>();
		}
	}
}

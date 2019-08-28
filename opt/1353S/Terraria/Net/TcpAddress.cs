﻿using System;
using System.Net;

namespace Terraria.Net
{
	// Token: 0x02000069 RID: 105
	public class TcpAddress : RemoteAddress
	{
		// Token: 0x060009C3 RID: 2499 RVA: 0x003B6E50 File Offset: 0x003B5050
		public TcpAddress(IPAddress address, int port)
		{
			this.Type = AddressType.Tcp;
			this.Address = address;
			this.Port = port;
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x003B6E70 File Offset: 0x003B5070
		public override string GetIdentifier()
		{
			return this.Address.ToString();
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x003B6E80 File Offset: 0x003B5080
		public override bool IsLocalHost()
		{
			return this.Address.Equals(IPAddress.Loopback);
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x003B6E94 File Offset: 0x003B5094
		public override string ToString()
		{
			return new IPEndPoint(this.Address, this.Port).ToString();
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x003B6EAC File Offset: 0x003B50AC
		public override string GetFriendlyName()
		{
			return this.ToString();
		}

		// Token: 0x04000DB7 RID: 3511
		public IPAddress Address;

		// Token: 0x04000DB8 RID: 3512
		public int Port;
	}
}

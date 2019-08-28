using System;
using System.IO;
using Terraria.Localization;
using Terraria.Net.Sockets;

namespace Terraria
{
	// Token: 0x0200001B RID: 27
	public class RemoteServer
	{
		// Token: 0x06000147 RID: 327 RVA: 0x00029ED4 File Offset: 0x000280D4
		public void ClientWriteCallBack(object state)
		{
			NetMessage.buffer[256].spamCount--;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00029EF0 File Offset: 0x000280F0
		public void ClientReadCallBack(object state, int length)
		{
			try
			{
				if (!Netplay.disconnect)
				{
					if (length == 0)
					{
						Netplay.disconnect = true;
						Main.statusText = Language.GetTextValue("Net.LostConnection");
					}
					else
					{
						if (Main.ignoreErrors)
						{
							try
							{
								NetMessage.ReceiveBytes(this.ReadBuffer, length, 256);
								goto IL_51;
							}
							catch
							{
								goto IL_51;
							}
						}
						NetMessage.ReceiveBytes(this.ReadBuffer, length, 256);
					}
				}
				IL_51:
				this.IsReading = false;
			}
			catch (Exception value)
			{
				try
				{
					using (StreamWriter streamWriter = new StreamWriter("client-crashlog.txt", true))
					{
						streamWriter.WriteLine(DateTime.Now);
						streamWriter.WriteLine(value);
						streamWriter.WriteLine("");
					}
				}
				catch
				{
				}
				Netplay.disconnect = true;
			}
		}

		// Token: 0x04000147 RID: 327
		public ISocket Socket = new TcpSocket();

		// Token: 0x04000148 RID: 328
		public bool IsActive;

		// Token: 0x04000149 RID: 329
		public int State;

		// Token: 0x0400014A RID: 330
		public int TimeOutTimer;

		// Token: 0x0400014B RID: 331
		public bool IsReading;

		// Token: 0x0400014C RID: 332
		public byte[] ReadBuffer;

		// Token: 0x0400014D RID: 333
		public string StatusText;

		// Token: 0x0400014E RID: 334
		public int StatusCount;

		// Token: 0x0400014F RID: 335
		public int StatusMax;
	}
}

using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Terraria.Social;

namespace Terraria
{
	// Token: 0x0200000C RID: 12
	public static class WindowsLaunch
	{
		// Token: 0x06000073 RID: 115 RVA: 0x00008A20 File Offset: 0x00006C20
		private static bool ConsoleCtrlCheck(WindowsLaunch.CtrlTypes ctrlType)
		{
			bool flag = false;
			switch (ctrlType)
			{
				case WindowsLaunch.CtrlTypes.CTRL_C_EVENT:
					flag = true;
					break;
				case WindowsLaunch.CtrlTypes.CTRL_BREAK_EVENT:
					flag = true;
					break;
				case WindowsLaunch.CtrlTypes.CTRL_CLOSE_EVENT:
					flag = true;
					break;
				case WindowsLaunch.CtrlTypes.CTRL_LOGOFF_EVENT:
				case WindowsLaunch.CtrlTypes.CTRL_SHUTDOWN_EVENT:
					flag = true;
					break;
			}
			if (flag)
			{
				SocialAPI.Shutdown();
			}
			return true;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00008A6A File Offset: 0x00006C6A
		[STAThread]
		private static void Main(string[] args)
		{
			AppDomain arg_24_0 = AppDomain.CurrentDomain;
			ResolveEventHandler arg_24_1;
			arg_24_0.AssemblyResolve += (sender, sargs) => {
				string resourceName = new AssemblyName(sargs.Name).Name + ".dll";
				string text = Array.Find<string>(typeof(Program).Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));
				if (text == null)
				{
					return null;
				}
				Assembly result;
				using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(text))
				{
					byte[] array = new byte[manifestResourceStream.Length];
					manifestResourceStream.Read(array, 0, array.Length);
					result = Assembly.Load(array);
				}
				return result;
			};
			Program.LaunchGame(args, false);
		}

		// Token: 0x06000074 RID: 116
		[DllImport("Kernel32")]
		public static extern bool SetConsoleCtrlHandler(WindowsLaunch.HandlerRoutine Handler, bool Add);

		// Token: 0x0400005F RID: 95
		private static WindowsLaunch.HandlerRoutine _handleRoutine;


		// Token: 0x020001B5 RID: 437
		public enum CtrlTypes
		{
			// Token: 0x0400360A RID: 13834
			CTRL_C_EVENT,
			// Token: 0x0400360B RID: 13835
			CTRL_BREAK_EVENT,
			// Token: 0x0400360C RID: 13836
			CTRL_CLOSE_EVENT,
			// Token: 0x0400360D RID: 13837
			CTRL_LOGOFF_EVENT = 5,
			// Token: 0x0400360E RID: 13838
			CTRL_SHUTDOWN_EVENT
		}

		// Token: 0x020001B4 RID: 436
		// Token: 0x060013E2 RID: 5090
		public delegate bool HandlerRoutine(WindowsLaunch.CtrlTypes CtrlType);
	}
}

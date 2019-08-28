using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ReLogic.IO;
using ReLogic.OS;
using Terraria.Initializers;
using Terraria.Localization;
using Terraria.Social;
using Terraria.Utilities;

namespace Terraria
{
	// Token: 0x02000030 RID: 48
	public static class Program
	{
		// Token: 0x06000499 RID: 1177 RVA: 0x002944A8 File Offset: 0x002926A8
		private static void DisplayException(Exception e)
		{
			try
			{
				using (StreamWriter streamWriter = new StreamWriter("client-crashlog.txt", true))
				{
					streamWriter.WriteLine(DateTime.Now);
					streamWriter.WriteLine(e);
					streamWriter.WriteLine("");
				}
				MessageBox.Show(e.ToString(), "Terraria: Error");
			}
			catch
			{
			}
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x00294114 File Offset: 0x00292314
		private static void ForceJITOnAssembly(Assembly assembly)
		{
			Type[] types = assembly.GetTypes();
			for (int i = 0; i < types.Length; i++)
			{
				MethodInfo[] methods = types[i].GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				for (int j = 0; j < methods.Length; j++)
				{
					MethodInfo methodInfo = methods[j];
					if (!methodInfo.IsAbstract && !methodInfo.ContainsGenericParameters && methodInfo.GetMethodBody() != null)
					{
						RuntimeHelpers.PrepareMethod(methodInfo.MethodHandle);
					}
				}
				Program.ThingsLoaded++;
			}
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x002941C1 File Offset: 0x002923C1
		private static void ForceLoadAssembly(Assembly assembly, bool initializeStaticMembers)
		{
			Program.ThingsToLoad = assembly.GetTypes().Length;
			Program.ForceJITOnAssembly(assembly);
			if (initializeStaticMembers)
			{
				Program.ForceStaticInitializers(assembly);
			}
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x002941E0 File Offset: 0x002923E0
		private static void ForceLoadAssembly(string name, bool initializeStaticMembers)
		{
			Assembly assembly = null;
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				if (assemblies[i].GetName().Name.Equals(name))
				{
					assembly = assemblies[i];
					break;
				}
			}
			if (assembly == null)
			{
				assembly = Assembly.Load(name);
			}
			Program.ForceLoadAssembly(assembly, initializeStaticMembers);
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x00294101 File Offset: 0x00292301
		public static void ForceLoadThread(object ThreadContext)
		{
			Program.ForceLoadAssembly(Assembly.GetExecutingAssembly(), true);
			Program.LoadedEverything = true;
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x00294188 File Offset: 0x00292388
		private static void ForceStaticInitializers(Assembly assembly)
		{
			Type[] types = assembly.GetTypes();
			for (int i = 0; i < types.Length; i++)
			{
				Type type = types[i];
				if (!type.IsGenericType)
				{
					RuntimeHelpers.RunClassConstructor(type.TypeHandle);
				}
			}
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x002942F4 File Offset: 0x002924F4
		private static void HookAllExceptions()
		{
			bool useMiniDumps = Program.LaunchParameters.ContainsKey("-minidump");
			bool useFullDumps = Program.LaunchParameters.ContainsKey("-fulldump");
			Console.WriteLine("Error Logging Enabled.");
			CrashDump.Options dumpOptions = CrashDump.Options.WithFullMemory;
			if (useFullDumps)
			{
				Console.WriteLine("Full Dump logs enabled.");
			}
			AppDomain.CurrentDomain.FirstChanceException += delegate (object sender, FirstChanceExceptionEventArgs exceptionArgs)
			{
				string arg = exceptionArgs.Exception.ToString();
				Console.Write("================\r\n" + string.Format("{0}: First-Chance Exception\r\nCulture: {1}\r\nException: {2}\r\n", DateTime.Now, Thread.CurrentThread.CurrentCulture.Name, arg) + "================\r\n\r\n");
				if (useMiniDumps)
				{
					CrashDump.WriteException(CrashDump.Options.WithIndirectlyReferencedMemory, Path.Combine(Main.SavePath, "Dumps"));
				}
			};
			AppDomain.CurrentDomain.UnhandledException += delegate (object sender, UnhandledExceptionEventArgs exceptionArgs)
			{
				string arg = exceptionArgs.ExceptionObject.ToString();
				Console.Write("================\r\n" + string.Format("{0}: Unhandled Exception\r\nCulture: {1}\r\nException: {2}\r\n", DateTime.Now, Thread.CurrentThread.CurrentCulture.Name, arg) + "================\r\n");
				if (useFullDumps)
				{
					CrashDump.WriteException(dumpOptions, Path.Combine(Main.SavePath, "Dumps"));
				}
			};
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x00294380 File Offset: 0x00292580
		private static void InitializeConsoleOutput()
		{
			if (Debugger.IsAttached)
			{
				return;
			}
			try
			{
				Console.OutputEncoding = Encoding.UTF8;
				if (Platform.IsWindows)
				{
					Console.InputEncoding = Encoding.Unicode;
				}
				else
				{
					Console.InputEncoding = Encoding.UTF8;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x002943D4 File Offset: 0x002925D4
		public static void LaunchGame(string[] args, bool monoArgs = false)
		{
			if (monoArgs)
			{
				args = Utils.ConvertMonoArgsToDotNet(args);
			}
			if (Platform.IsOSX)
			{
				Main.OnEngineLoad += () => { Main.instance.IsMouseVisible = false; };
			}
			Program.LaunchParameters = Utils.ParseArguements(args);
			ThreadPool.SetMinThreads(8, 8);
			LanguageManager.Instance.SetLanguage(GameCulture.English);
			Program.SetupLogging();
			using (Main main = new Main())
			{
				try
				{
					Program.InitializeConsoleOutput();
					Lang.InitializeLegacyLocalization();
					SocialAPI.Initialize(null);
					LaunchInitializer.LoadParameters(main);
					Main.OnEnginePreload += new Action(Program.StartForceLoad);
					main.Run();
				}
				catch (Exception arg_9A_0)
				{
					Program.DisplayException(arg_9A_0);
				}
			}
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x0029423C File Offset: 0x0029243C
		private static void SetupLogging()
		{
			if (Program.LaunchParameters.ContainsKey("-logfile"))
			{
				string text = Program.LaunchParameters["-logfile"];
				if (text == null || text.Trim() == "")
				{
					text = Path.Combine(Main.SavePath, "Logs", string.Format("Log_{0}.log", DateTime.Now.ToString("yyyyMMddHHmmssfff")));
				}
				else
				{
					text = Path.Combine(text, string.Format("Log_{0}.log", DateTime.Now.ToString("yyyyMMddHHmmssfff")));
				}
				ConsoleOutputMirror.ToFile(text);
			}
			if (Program.LaunchParameters.ContainsKey("-logerrors"))
			{
				Program.HookAllExceptions();
			}
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x002940DF File Offset: 0x002922DF
		public static void StartForceLoad()
		{
			if (!Main.SkipAssemblyLoad)
			{
				ThreadPool.QueueUserWorkItem(new WaitCallback(Program.ForceLoadThread));
				return;
			}
			Program.LoadedEverything = true;
		}

		// Token: 0x1700008B RID: 139
		public static float LoadedPercentage
		{
			// Token: 0x0600048E RID: 1166 RVA: 0x002940C3 File Offset: 0x002922C3
			get
			{
				if (Program.ThingsToLoad == 0)
				{
					return 1f;
				}
				return (float)Program.ThingsLoaded / (float)Program.ThingsToLoad;
			}
		}

		// Token: 0x040006CC RID: 1740
		public const bool IsServer = false;

		// Token: 0x040006D1 RID: 1745
		public static IntPtr JitForcedMethodCache;

		// Token: 0x040006CD RID: 1741
		public static Dictionary<string, string> LaunchParameters = new Dictionary<string, string>();

		// Token: 0x040006D0 RID: 1744
		public static bool LoadedEverything = false;

		// Token: 0x040006CF RID: 1743
		private static int ThingsLoaded = 0;

		// Token: 0x040006CE RID: 1742
		private static int ThingsToLoad = 0;

	}
}

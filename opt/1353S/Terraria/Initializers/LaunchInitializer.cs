using System;
using System.Diagnostics;
using Terraria.Localization;
using Terraria.Social;

namespace Terraria.Initializers
{
	// Token: 0x02000082 RID: 130
	public static class LaunchInitializer
	{
		// Token: 0x06000AB3 RID: 2739 RVA: 0x003C6B18 File Offset: 0x003C4D18
		public static void LoadParameters(Main game)
		{
			LaunchInitializer.LoadSharedParameters(game);
			LaunchInitializer.LoadClientParameters(game);
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x003C6B28 File Offset: 0x003C4D28
		private static void LoadSharedParameters(Main game)
		{
			string path;
			if ((path = LaunchInitializer.TryParameter(new string[]
			{
				"-loadlib"
			})) != null)
			{
				game.loadLib(path);
			}
			string s;
			int listenPort;
			if ((s = LaunchInitializer.TryParameter(new string[]
			{
				"-p",
				"-port"
			})) != null && int.TryParse(s, out listenPort))
			{
				Netplay.ListenPort = listenPort;
			}
		}

		// Token: 0x06000AB5 RID: 2741 RVA: 0x003C6B84 File Offset: 0x003C4D84
		private static void LoadClientParameters(Main game)
		{
			string iP;
			if ((iP = LaunchInitializer.TryParameter(new string[]
			{
				"-j",
				"-join"
			})) != null)
			{
				game.AutoJoin(iP);
			}
			string serverPassword;
			if ((serverPassword = LaunchInitializer.TryParameter(new string[]
			{
				"-pass",
				"-password"
			})) != null)
			{
				Netplay.ServerPassword = serverPassword;
				game.AutoPass();
			}
			if (LaunchInitializer.HasParameter(new string[]
			{
				"-host"
			}))
			{
				game.AutoHost();
			}
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x003C6C00 File Offset: 0x003C4E00
		private static void LoadServerParameters(Main game)
		{
			try
			{
				string s;
				if ((s = LaunchInitializer.TryParameter(new string[]
				{
					"-forcepriority"
				})) != null)
				{
					Process currentProcess = Process.GetCurrentProcess();
					int num;
					if (int.TryParse(s, out num))
					{
						switch (num)
						{
						case 0:
							currentProcess.PriorityClass = ProcessPriorityClass.RealTime;
							break;
						case 1:
							currentProcess.PriorityClass = ProcessPriorityClass.High;
							break;
						case 2:
							currentProcess.PriorityClass = ProcessPriorityClass.AboveNormal;
							break;
						case 3:
							currentProcess.PriorityClass = ProcessPriorityClass.Normal;
							break;
						case 4:
							currentProcess.PriorityClass = ProcessPriorityClass.BelowNormal;
							break;
						case 5:
							currentProcess.PriorityClass = ProcessPriorityClass.Idle;
							break;
						default:
							currentProcess.PriorityClass = ProcessPriorityClass.High;
							break;
						}
					}
					else
					{
						currentProcess.PriorityClass = ProcessPriorityClass.High;
					}
				}
				else
				{
					Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
				}
			}
			catch
			{
			}
			string s2;
			int netPlayers;
			if ((s2 = LaunchInitializer.TryParameter(new string[]
			{
				"-maxplayers",
				"-players"
			})) != null && int.TryParse(s2, out netPlayers))
			{
				game.SetNetPlayers(netPlayers);
			}
			string serverPassword;
			if ((serverPassword = LaunchInitializer.TryParameter(new string[]
			{
				"-pass",
				"-password"
			})) != null)
			{
				Netplay.ServerPassword = serverPassword;
			}
			string text;
			int language;
			if ((text = LaunchInitializer.TryParameter(new string[]
			{
				"-lang"
			})) != null && int.TryParse(text, out language))
			{
				LanguageManager.Instance.SetLanguage(language);
			}
			if ((text = LaunchInitializer.TryParameter(new string[]
			{
				"-language"
			})) != null)
			{
				LanguageManager.Instance.SetLanguage(text);
			}
			string worldName;
			if ((worldName = LaunchInitializer.TryParameter(new string[]
			{
				"-worldname"
			})) != null)
			{
				game.SetWorldName(worldName);
			}
			string newMOTD;
			if ((newMOTD = LaunchInitializer.TryParameter(new string[]
			{
				"-motd"
			})) != null)
			{
				game.NewMOTD(newMOTD);
			}
			string banFilePath;
			if ((banFilePath = LaunchInitializer.TryParameter(new string[]
			{
				"-banlist"
			})) != null)
			{
				Netplay.BanFilePath = banFilePath;
			}
			if (LaunchInitializer.HasParameter(new string[]
			{
				"-autoshutdown"
			}))
			{
				game.EnableAutoShutdown();
			}
			if (LaunchInitializer.HasParameter(new string[]
			{
				"-secure"
			}))
			{
				Netplay.spamCheck = true;
			}
			string worldSize;
			if ((worldSize = LaunchInitializer.TryParameter(new string[]
			{
				"-autocreate"
			})) != null)
			{
				game.autoCreate(worldSize);
			}
			if (LaunchInitializer.HasParameter(new string[]
			{
				"-noupnp"
			}))
			{
				Netplay.UseUPNP = false;
			}
			if (LaunchInitializer.HasParameter(new string[]
			{
				"-experimental"
			}))
			{
				Main.UseExperimentalFeatures = true;
			}
			string world;
			if ((world = LaunchInitializer.TryParameter(new string[]
			{
				"-world"
			})) != null)
			{
				game.SetWorld(world, false);
			}
			else if (SocialAPI.Mode == SocialMode.Steam && (world = LaunchInitializer.TryParameter(new string[]
			{
				"-cloudworld"
			})) != null)
			{
				game.SetWorld(world, true);
			}
			string configPath;
			if ((configPath = LaunchInitializer.TryParameter(new string[]
			{
				"-config"
			})) != null)
			{
				game.LoadDedConfig(configPath);
			}
			string autogenSeedName;
			if ((autogenSeedName = LaunchInitializer.TryParameter(new string[]
			{
				"-seed"
			})) != null)
			{
				Main.AutogenSeedName = autogenSeedName;
			}
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x003C6F04 File Offset: 0x003C5104
		private static bool HasParameter(params string[] keys)
		{
			for (int i = 0; i < keys.Length; i++)
			{
				if (Program.LaunchParameters.ContainsKey(keys[i]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x003C6F34 File Offset: 0x003C5134
		private static string TryParameter(params string[] keys)
		{
			for (int i = 0; i < keys.Length; i++)
			{
				string text;
				if (Program.LaunchParameters.TryGetValue(keys[i], out text))
				{
					if (text == null)
					{
						text = "";
					}
					return text;
				}
			}
			return null;
		}
	}
}

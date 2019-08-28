using System;
using System.Collections.Generic;
using Terraria.Social.Base;
using Terraria.Social.Steam;

namespace Terraria.Social
{
	// Token: 0x0200008B RID: 139
	public static class SocialAPI
	{
		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000ADD RID: 2781 RVA: 0x003CC880 File Offset: 0x003CAA80
		public static SocialMode Mode
		{
			get
			{
				return SocialAPI._mode;
			}
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x003CC888 File Offset: 0x003CAA88
		public static void Initialize(SocialMode? mode = null)
		{
			if (!mode.HasValue)
			{
				mode = new SocialMode?(SocialMode.None);
				mode = new SocialMode?(SocialMode.None);
			}
			SocialAPI._mode = mode.Value;
			SocialAPI._modules = new List<ISocialModule>();
			SocialMode mode2 = SocialAPI.Mode;
			/*if (mode2 == SocialMode.Steam)
			{
				SocialAPI.LoadSteam();
			}*/
			using (List<ISocialModule>.Enumerator enumerator = SocialAPI._modules.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.Initialize();
				}
			}
		}

		// Token: 0x06000ADF RID: 2783 RVA: 0x003CC918 File Offset: 0x003CAB18
		public static void Shutdown()
		{
			SocialAPI._modules.Reverse();
			using (List<ISocialModule>.Enumerator enumerator = SocialAPI._modules.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.Shutdown();
				}
			}
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x003CC974 File Offset: 0x003CAB74
		private static T LoadModule<T>() where T : ISocialModule, new()
		{
			T t = Activator.CreateInstance<T>();
			SocialAPI._modules.Add(t);
			return t;
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x003CC998 File Offset: 0x003CAB98
		private static T LoadModule<T>(T module) where T : ISocialModule
		{
			SocialAPI._modules.Add(module);
			return module;
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x003CC9AC File Offset: 0x003CABAC
		private static void LoadSteam()
		{
			SocialAPI.LoadModule<CoreSocialModule>();
			SocialAPI.Friends = SocialAPI.LoadModule<Terraria.Social.Steam.FriendsSocialModule>();
			SocialAPI.Achievements = SocialAPI.LoadModule<Terraria.Social.Steam.AchievementsSocialModule>();
			SocialAPI.Cloud = SocialAPI.LoadModule<Terraria.Social.Steam.CloudSocialModule>();
			SocialAPI.Overlay = SocialAPI.LoadModule<Terraria.Social.Steam.OverlaySocialModule>();
			SocialAPI.Network = SocialAPI.LoadModule<NetClientSocialModule>();
		}

		// Token: 0x04000E5A RID: 3674
		private static SocialMode _mode;

		// Token: 0x04000E5B RID: 3675
		public static Terraria.Social.Base.FriendsSocialModule Friends;

		// Token: 0x04000E5C RID: 3676
		public static Terraria.Social.Base.AchievementsSocialModule Achievements;

		// Token: 0x04000E5D RID: 3677
		public static Terraria.Social.Base.CloudSocialModule Cloud;

		// Token: 0x04000E5E RID: 3678
		public static Terraria.Social.Base.NetSocialModule Network;

		// Token: 0x04000E5F RID: 3679
		public static Terraria.Social.Base.OverlaySocialModule Overlay;

		// Token: 0x04000E60 RID: 3680
		private static List<ISocialModule> _modules;
	}
}

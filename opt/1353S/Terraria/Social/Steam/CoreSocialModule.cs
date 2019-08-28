using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Steamworks;
using Terraria.Localization;

namespace Terraria.Social.Steam
{
	// Token: 0x0200008F RID: 143
	public class CoreSocialModule : ISocialModule
	{
		// Token: 0x14000013 RID: 19
		// (add) Token: 0x06000B03 RID: 2819 RVA: 0x003CCE80 File Offset: 0x003CB080
		// (remove) Token: 0x06000B04 RID: 2820 RVA: 0x003CCEB4 File Offset: 0x003CB0B4
		[method: CompilerGenerated]
		[CompilerGenerated]
		public static event Action OnTick;

		// Token: 0x06000B05 RID: 2821 RVA: 0x003CCEE8 File Offset: 0x003CB0E8
		public void Initialize()
		{
			CoreSocialModule._instance = this;
			if (SteamAPI.RestartAppIfNecessary(new AppId_t(105600u)))
			{
				Environment.Exit(1);
				return;
			}
			if (!SteamAPI.Init())
			{
				MessageBox.Show(Language.GetTextValue("Error.LaunchFromSteam"), Language.GetTextValue("Error.Error"));
				Environment.Exit(1);
			}
			this.IsSteamValid = true;
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.SteamCallbackLoop), null);
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.SteamTickLoop), null);
			Main.OnTick += new Action(this.PulseSteamTick);
			Main.OnTick += new Action(this.PulseSteamCallback);
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x003CCF8C File Offset: 0x003CB18C
		public void PulseSteamTick()
		{
			if (Monitor.TryEnter(this._steamTickLock))
			{
				Monitor.Pulse(this._steamTickLock);
				Monitor.Exit(this._steamTickLock);
			}
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x003CCFB4 File Offset: 0x003CB1B4
		public void PulseSteamCallback()
		{
			if (Monitor.TryEnter(this._steamCallbackLock))
			{
				Monitor.Pulse(this._steamCallbackLock);
				Monitor.Exit(this._steamCallbackLock);
			}
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x003CCFDC File Offset: 0x003CB1DC
		public static void Pulse()
		{
			CoreSocialModule._instance.PulseSteamTick();
			CoreSocialModule._instance.PulseSteamCallback();
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x003CCFF4 File Offset: 0x003CB1F4
		private void SteamTickLoop(object context)
		{
			Monitor.Enter(this._steamTickLock);
			while (this.IsSteamValid)
			{
				if (CoreSocialModule.OnTick != null)
				{
					CoreSocialModule.OnTick();
				}
				Monitor.Wait(this._steamTickLock);
			}
			Monitor.Exit(this._steamTickLock);
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x003CD034 File Offset: 0x003CB234
		private void SteamCallbackLoop(object context)
		{
			Monitor.Enter(this._steamCallbackLock);
			while (this.IsSteamValid)
			{
				SteamAPI.RunCallbacks();
				Monitor.Wait(this._steamCallbackLock);
			}
			Monitor.Exit(this._steamCallbackLock);
			SteamAPI.Shutdown();
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x003CD06C File Offset: 0x003CB26C
		public void Shutdown()
		{
			Application.ApplicationExit += delegate(object obj, EventArgs evt)
			{
				this.IsSteamValid = false;
			};
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x003CD080 File Offset: 0x003CB280
		public void OnOverlayActivated(GameOverlayActivated_t result)
		{
			Main.instance.IsMouseVisible = (result.m_bActive == 1);
		}

		// Token: 0x04000E6B RID: 3691
		private static CoreSocialModule _instance;

		// Token: 0x04000E6C RID: 3692
		public const int SteamAppId = 105600;

		// Token: 0x04000E6D RID: 3693
		private bool IsSteamValid;

		// Token: 0x04000E6F RID: 3695
		private object _steamTickLock = new object();

		// Token: 0x04000E70 RID: 3696
		private object _steamCallbackLock = new object();

		// Token: 0x04000E71 RID: 3697
		private Callback<GameOverlayActivated_t> _onOverlayActivated;
	}
}

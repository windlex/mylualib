using System;
using System.Collections.Concurrent;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Graphics
{
	// Token: 0x020000E2 RID: 226
	public static class TextureManager
	{
		// Token: 0x06000D3C RID: 3388 RVA: 0x003E2898 File Offset: 0x003E0A98
		public static void Initialize()
		{
			TextureManager.BlankTexture = new Texture2D(Main.graphics.GraphicsDevice, 4, 4);
		}

		// Token: 0x06000D3D RID: 3389 RVA: 0x003E28B0 File Offset: 0x003E0AB0
		public static Texture2D Load(string name)
		{
			if (!TextureManager._textures.ContainsKey(name))
			{
				Texture2D texture2D = TextureManager.BlankTexture;
				if (name != "" && name != null)
				{
					try
					{
						texture2D = Main.instance.OurLoad<Texture2D>(name);
					}
					catch (Exception)
					{
						texture2D = TextureManager.BlankTexture;
					}
				}
				TextureManager._textures[name] = texture2D;
				return texture2D;
			}
			return TextureManager._textures[name];
		}

		// Token: 0x06000D3E RID: 3390 RVA: 0x003E2920 File Offset: 0x003E0B20
		public static Ref<Texture2D> AsyncLoad(string name)
		{
			return new Ref<Texture2D>(TextureManager.Load(name));
		}

		// Token: 0x06000D3F RID: 3391 RVA: 0x003E2938 File Offset: 0x003E0B38
		private static void Run(object context)
		{
			bool looping = true;
			Main.instance.Exiting += delegate(object obj, EventArgs args)
			{
				looping = false;
				if (Monitor.TryEnter(TextureManager._loadThreadLock))
				{
					Monitor.Pulse(TextureManager._loadThreadLock);
					Monitor.Exit(TextureManager._loadThreadLock);
				}
			};
			Monitor.Enter(TextureManager._loadThreadLock);
			while (looping)
			{
				if (TextureManager._loadQueue.Count != 0)
				{
					TextureManager.LoadPair loadPair;
					if (TextureManager._loadQueue.TryDequeue(out loadPair))
					{
						loadPair.TextureRef.Value = TextureManager.Load(loadPair.Path);
					}
				}
				else
				{
					Monitor.Wait(TextureManager._loadThreadLock);
				}
			}
			Monitor.Exit(TextureManager._loadThreadLock);
		}

		// Token: 0x04002EEE RID: 12014
		private static ConcurrentDictionary<string, Texture2D> _textures = new ConcurrentDictionary<string, Texture2D>();

		// Token: 0x04002EEF RID: 12015
		private static ConcurrentQueue<TextureManager.LoadPair> _loadQueue = new ConcurrentQueue<TextureManager.LoadPair>();

		// Token: 0x04002EF0 RID: 12016
		private static Thread _loadThread;

		// Token: 0x04002EF1 RID: 12017
		private static readonly object _loadThreadLock = new object();

		// Token: 0x04002EF2 RID: 12018
		public static Texture2D BlankTexture;

		// Token: 0x02000278 RID: 632
		private struct LoadPair
		{
			// Token: 0x0600167B RID: 5755 RVA: 0x004370D0 File Offset: 0x004352D0
			public LoadPair(string path, Ref<Texture2D> textureRef)
			{
				this.Path = path;
				this.TextureRef = textureRef;
			}

			// Token: 0x04003C40 RID: 15424
			public string Path;

			// Token: 0x04003C41 RID: 15425
			public Ref<Texture2D> TextureRef;
		}
	}
}

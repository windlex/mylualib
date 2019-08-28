using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Ionic.Zip;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria
{
	// Token: 0x0200000A RID: 10
	public class TexturePackSupport
	{
		// Token: 0x06000050 RID: 80 RVA: 0x000084A4 File Offset: 0x000066A4
		public static bool FetchTexture(string path, out Texture2D tex)
		{
			ZipEntry zipEntry;
			if (TexturePackSupport.entries.TryGetValue(path, out zipEntry))
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					zipEntry.Extract(memoryStream);
					tex = TexturePackSupport.FromStreamSlow(Main.instance.GraphicsDevice, memoryStream);
					TexturePackSupport.ReplacedTextures++;
					return true;
				}
			}
			tex = null;
			return false;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00008570 File Offset: 0x00006770
		public static void FindTexturePack()
		{
			string path = Main.SavePath + "/Texture Pack.zip";
			if (!File.Exists(path))
			{
				return;
			}
			TexturePackSupport.entries.Clear();
			TexturePackSupport.texturePack = ZipFile.Read(File.OpenRead(path));
			foreach (ZipEntry current in TexturePackSupport.texturePack.Entries)
			{
				TexturePackSupport.entries.Add(current.FileName.Replace("/", "\\"), current);
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00008510 File Offset: 0x00006710
		public static Texture2D FromStreamSlow(GraphicsDevice graphicsDevice, Stream stream)
		{
			Texture2D texture2D = Texture2D.FromStream(graphicsDevice, stream);
			Color[] array = new Color[texture2D.Width * texture2D.Height];
			texture2D.GetData<Color>(array);
			for (int num = 0; num != array.Length; num++)
			{
				array[num] = Color.FromNonPremultiplied(array[num].ToVector4());
			}
			texture2D.SetData<Color>(array);
			return texture2D;
		}

		// Token: 0x0400004C RID: 76
		public static bool Enabled = false;

		// Token: 0x0400004F RID: 79
		private static Dictionary<string, ZipEntry> entries = new Dictionary<string, ZipEntry>();

		// Token: 0x0400004D RID: 77
		public static int ReplacedTextures = 0;

		// Token: 0x04000050 RID: 80
		private static Stopwatch test = new Stopwatch();

		// Token: 0x0400004E RID: 78
		private static ZipFile texturePack;
	}
}

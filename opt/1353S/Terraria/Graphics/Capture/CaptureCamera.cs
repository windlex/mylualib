using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;

namespace Terraria.Graphics.Capture
{
	// Token: 0x020000E7 RID: 231
	internal class CaptureCamera
	{
		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000D6E RID: 3438 RVA: 0x003E48B4 File Offset: 0x003E2AB4
		public bool IsCapturing
		{
			get
			{
				Monitor.Enter(this._captureLock);
				bool arg_1F_0 = this._activeSettings != null;
				Monitor.Exit(this._captureLock);
				return arg_1F_0;
			}
		}

		// Token: 0x06000D6F RID: 3439 RVA: 0x003E48D8 File Offset: 0x003E2AD8
		public CaptureCamera(GraphicsDevice graphics)
		{
			CaptureCamera.CameraExists = true;
			this._graphics = graphics;
			this._spriteBatch = new SpriteBatch(graphics);
			try
			{
				this._frameBuffer = new RenderTarget2D(graphics, 2048, 2048, false, graphics.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
			}
			catch
			{
				Main.CaptureModeDisabled = true;
				return;
			}
			this._downscaleSampleState = SamplerState.AnisotropicClamp;
		}

		// Token: 0x06000D70 RID: 3440 RVA: 0x003E4964 File Offset: 0x003E2B64
		~CaptureCamera()
		{
			this.Dispose();
		}

		// Token: 0x06000D71 RID: 3441 RVA: 0x003E4990 File Offset: 0x003E2B90
		public void Capture(CaptureSettings settings)
		{
			Main.GlobalTimerPaused = true;
			Monitor.Enter(this._captureLock);
			if (this._activeSettings != null)
			{
				throw new InvalidOperationException("Capture called while another capture was already active.");
			}
			this._activeSettings = settings;
			Microsoft.Xna.Framework.Rectangle area = settings.Area;
			float num = 1f;
			if (settings.UseScaling)
			{
				if (area.Width << 4 > 4096)
				{
					num = 4096f / (float)(area.Width << 4);
				}
				if (area.Height << 4 > 4096)
				{
					num = Math.Min(num, 4096f / (float)(area.Height << 4));
				}
				num = Math.Min(1f, num);
				this._outputImageSize = new Size((int)MathHelper.Clamp((float)((int)(num * (float)(area.Width << 4))), 1f, 4096f), (int)MathHelper.Clamp((float)((int)(num * (float)(area.Height << 4))), 1f, 4096f));
				this._outputData = new byte[4 * this._outputImageSize.Width * this._outputImageSize.Height];
				int num2 = (int)Math.Floor((double)(num * 2048f));
				this._scaledFrameData = new byte[4 * num2 * num2];
				this._scaledFrameBuffer = new RenderTarget2D(this._graphics, num2, num2, false, this._graphics.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
			}
			else
			{
				this._outputData = new byte[16777216];
			}
			this._tilesProcessed = 0f;
			this._totalTiles = (float)(area.Width * area.Height);
			for (int i = area.X; i < area.X + area.Width; i += 126)
			{
				for (int j = area.Y; j < area.Y + area.Height; j += 126)
				{
					int num3 = Math.Min(128, area.X + area.Width - i);
					int num4 = Math.Min(128, area.Y + area.Height - j);
					int width = (int)Math.Floor((double)(num * (float)(num3 << 4)));
					int height = (int)Math.Floor((double)(num * (float)(num4 << 4)));
					int x = (int)Math.Floor((double)(num * (float)(i - area.X << 4)));
					int y = (int)Math.Floor((double)(num * (float)(j - area.Y << 4)));
					this._renderQueue.Enqueue(new CaptureCamera.CaptureChunk(new Microsoft.Xna.Framework.Rectangle(i, j, num3, num4), new Microsoft.Xna.Framework.Rectangle(x, y, width, height)));
				}
			}
			Monitor.Exit(this._captureLock);
		}

		// Token: 0x06000D72 RID: 3442 RVA: 0x003E4C14 File Offset: 0x003E2E14
		public void DrawTick()
		{
			Monitor.Enter(this._captureLock);
			if (this._activeSettings == null)
			{
				return;
			}
			if (this._renderQueue.Count > 0)
			{
				CaptureCamera.CaptureChunk captureChunk = this._renderQueue.Dequeue();
				this._graphics.SetRenderTarget(this._frameBuffer);
				this._graphics.Clear(Microsoft.Xna.Framework.Color.Transparent);
				Main.instance.DrawCapture(captureChunk.Area, this._activeSettings);
				if (this._activeSettings.UseScaling)
				{
					this._graphics.SetRenderTarget(this._scaledFrameBuffer);
					this._graphics.Clear(Microsoft.Xna.Framework.Color.Transparent);
					this._spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, this._downscaleSampleState, DepthStencilState.Default, RasterizerState.CullNone);
					this._spriteBatch.Draw(this._frameBuffer, new Microsoft.Xna.Framework.Rectangle(0, 0, this._scaledFrameBuffer.Width, this._scaledFrameBuffer.Height), Microsoft.Xna.Framework.Color.White);
					this._spriteBatch.End();
					this._graphics.SetRenderTarget(null);
					this._scaledFrameBuffer.GetData<byte>(this._scaledFrameData, 0, this._scaledFrameBuffer.Width * this._scaledFrameBuffer.Height * 4);
					this.DrawBytesToBuffer(this._scaledFrameData, this._outputData, this._scaledFrameBuffer.Width, this._outputImageSize.Width, captureChunk.ScaledArea);
				}
				else
				{
					this._graphics.SetRenderTarget(null);
					this.SaveImage(this._frameBuffer, captureChunk.ScaledArea.Width, captureChunk.ScaledArea.Height, ImageFormat.Png, this._activeSettings.OutputName, string.Concat(new object[]
					{
						captureChunk.Area.X,
						"-",
						captureChunk.Area.Y,
						".png"
					}));
				}
				this._tilesProcessed += (float)(captureChunk.Area.Width * captureChunk.Area.Height);
			}
			if (this._renderQueue.Count == 0)
			{
				this.FinishCapture();
			}
			Monitor.Exit(this._captureLock);
		}

		// Token: 0x06000D73 RID: 3443 RVA: 0x003E4E44 File Offset: 0x003E3044
		private unsafe void DrawBytesToBuffer(byte[] sourceBuffer, byte[] destinationBuffer, int sourceBufferWidth, int destinationBufferWidth, Microsoft.Xna.Framework.Rectangle area)
		{
			fixed (byte* ptr = &destinationBuffer[0])
			{
				byte* ptr2 = ptr;
				fixed (byte* ptr3 = &sourceBuffer[0])
				{
					byte* ptr4 = ptr3;
					ptr2 += destinationBufferWidth * area.Y + area.X << 2;
					for (int i = 0; i < area.Height; i++)
					{
						for (int j = 0; j < area.Width; j++)
						{
							ptr2[2] = *ptr4;
							ptr2[1] = ptr4[1];
							*ptr2 = ptr4[2];
							ptr2[3] = ptr4[3];
							ptr4 += 4;
							ptr2 += 4;
						}
						ptr4 += sourceBufferWidth - area.Width << 2;
						ptr2 += destinationBufferWidth - area.Width << 2;
					}
				}
			}
		}

		// Token: 0x06000D74 RID: 3444 RVA: 0x003E4EF4 File Offset: 0x003E30F4
		public float GetProgress()
		{
			return this._tilesProcessed / this._totalTiles;
		}

		// Token: 0x06000D75 RID: 3445 RVA: 0x003E4F04 File Offset: 0x003E3104
		private bool SaveImage(int width, int height, ImageFormat imageFormat, string filename)
		{
			bool result;
			try
			{
				Directory.CreateDirectory(Main.SavePath + Path.DirectorySeparatorChar.ToString() + "Captures" + Path.DirectorySeparatorChar.ToString());
				using (Bitmap bitmap = new Bitmap(width, height))
				{
					System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, width, height);
					BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
					IntPtr scan = bitmapData.Scan0;
					Marshal.Copy(this._outputData, 0, scan, width * height * 4);
					bitmap.UnlockBits(bitmapData);
					bitmap.Save(filename, imageFormat);
					bitmap.Dispose();
				}
				result = true;
			}
			catch (Exception arg_92_0)
			{
				Console.WriteLine(arg_92_0);
				result = false;
			}
			return result;
		}

		// Token: 0x06000D76 RID: 3446 RVA: 0x003E4FCC File Offset: 0x003E31CC
		private void SaveImage(Texture2D texture, int width, int height, ImageFormat imageFormat, string foldername, string filename)
		{
			string expr_40 = string.Concat(new string[]
			{
				Main.SavePath,
				Path.DirectorySeparatorChar.ToString(),
				"Captures",
				Path.DirectorySeparatorChar.ToString(),
				foldername
			});
			string filename2 = Path.Combine(expr_40, filename);
			Directory.CreateDirectory(expr_40);
			using (Bitmap bitmap = new Bitmap(width, height))
			{
				System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, width, height);
				int elementCount = texture.Width * texture.Height * 4;
				texture.GetData<byte>(this._outputData, 0, elementCount);
				int num = 0;
				int num2 = 0;
				for (int i = 0; i < height; i++)
				{
					for (int j = 0; j < width; j++)
					{
						byte b = this._outputData[num + 2];
						this._outputData[num2 + 2] = this._outputData[num];
						this._outputData[num2] = b;
						this._outputData[num2 + 1] = this._outputData[num + 1];
						this._outputData[num2 + 3] = this._outputData[num + 3];
						num += 4;
						num2 += 4;
					}
					num += texture.Width - width << 2;
				}
				BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
				IntPtr scan = bitmapData.Scan0;
				Marshal.Copy(this._outputData, 0, scan, width * height * 4);
				bitmap.UnlockBits(bitmapData);
				bitmap.Save(filename2, imageFormat);
			}
		}

		// Token: 0x06000D77 RID: 3447 RVA: 0x003E5160 File Offset: 0x003E3360
		private void FinishCapture()
		{
			if (this._activeSettings.UseScaling)
			{
				int num = 0;
				while (!this.SaveImage(this._outputImageSize.Width, this._outputImageSize.Height, ImageFormat.Png, string.Concat(new string[]
				{
					Main.SavePath,
					Path.DirectorySeparatorChar.ToString(),
					"Captures",
					Path.DirectorySeparatorChar.ToString(),
					this._activeSettings.OutputName,
					".png"
				})))
				{
					GC.Collect();
					Thread.Sleep(5);
					num++;
					Console.WriteLine(Language.GetTextValue("Error.CaptureError"));
					if (num > 5)
					{
						Console.WriteLine(Language.GetTextValue("Error.UnableToCapture"));
						break;
					}
				}
			}
			this._outputData = null;
			this._scaledFrameData = null;
			Main.GlobalTimerPaused = false;
			CaptureInterface.EndCamera();
			if (this._scaledFrameBuffer != null)
			{
				this._scaledFrameBuffer.Dispose();
				this._scaledFrameBuffer = null;
			}
			this._activeSettings = null;
		}

		// Token: 0x06000D78 RID: 3448 RVA: 0x003E5268 File Offset: 0x003E3468
		public void Dispose()
		{
			Monitor.Enter(this._captureLock);
			if (this._isDisposed)
			{
				return;
			}
			this._frameBuffer.Dispose();
			if (this._scaledFrameBuffer != null)
			{
				this._scaledFrameBuffer.Dispose();
				this._scaledFrameBuffer = null;
			}
			CaptureCamera.CameraExists = false;
			this._isDisposed = true;
			Monitor.Exit(this._captureLock);
		}

		// Token: 0x04002F1B RID: 12059
		private static bool CameraExists;

		// Token: 0x04002F1C RID: 12060
		public const int CHUNK_SIZE = 128;

		// Token: 0x04002F1D RID: 12061
		public const int FRAMEBUFFER_PIXEL_SIZE = 2048;

		// Token: 0x04002F1E RID: 12062
		public const int INNER_CHUNK_SIZE = 126;

		// Token: 0x04002F1F RID: 12063
		public const int MAX_IMAGE_SIZE = 4096;

		// Token: 0x04002F20 RID: 12064
		public const string CAPTURE_DIRECTORY = "Captures";

		// Token: 0x04002F21 RID: 12065
		private RenderTarget2D _frameBuffer;

		// Token: 0x04002F22 RID: 12066
		private RenderTarget2D _scaledFrameBuffer;

		// Token: 0x04002F23 RID: 12067
		private GraphicsDevice _graphics;

		// Token: 0x04002F24 RID: 12068
		private readonly object _captureLock = new object();

		// Token: 0x04002F25 RID: 12069
		private bool _isDisposed;

		// Token: 0x04002F26 RID: 12070
		private CaptureSettings _activeSettings;

		// Token: 0x04002F27 RID: 12071
		private Queue<CaptureCamera.CaptureChunk> _renderQueue = new Queue<CaptureCamera.CaptureChunk>();

		// Token: 0x04002F28 RID: 12072
		private SpriteBatch _spriteBatch;

		// Token: 0x04002F29 RID: 12073
		private byte[] _scaledFrameData;

		// Token: 0x04002F2A RID: 12074
		private byte[] _outputData;

		// Token: 0x04002F2B RID: 12075
		private Size _outputImageSize;

		// Token: 0x04002F2C RID: 12076
		private SamplerState _downscaleSampleState;

		// Token: 0x04002F2D RID: 12077
		private float _tilesProcessed;

		// Token: 0x04002F2E RID: 12078
		private float _totalTiles;

		// Token: 0x02000281 RID: 641
		private class CaptureChunk
		{
			// Token: 0x0600169F RID: 5791 RVA: 0x00438DE4 File Offset: 0x00436FE4
			public CaptureChunk(Microsoft.Xna.Framework.Rectangle area, Microsoft.Xna.Framework.Rectangle scaledArea)
			{
				this.Area = area;
				this.ScaledArea = scaledArea;
			}

			// Token: 0x04003C5D RID: 15453
			public readonly Microsoft.Xna.Framework.Rectangle Area;

			// Token: 0x04003C5E RID: 15454
			public readonly Microsoft.Xna.Framework.Rectangle ScaledArea;
		}
	}
}

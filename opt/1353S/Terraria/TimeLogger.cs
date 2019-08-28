using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Terraria
{
	// Token: 0x02000033 RID: 51
	public static class TimeLogger
	{
		// Token: 0x06000658 RID: 1624 RVA: 0x00344534 File Offset: 0x00342734
		public static void Initialize()
		{
			TimeLogger.currentFrame = 0;
			TimeLogger.framesToLog = -1;
			TimeLogger.detailedDrawTimer = new Stopwatch();
			TimeLogger.renderTimes = new TimeLogger.TimeLogData[10];
			TimeLogger.drawTimes = new TimeLogger.TimeLogData[10];
			TimeLogger.lightingTimes = new TimeLogger.TimeLogData[5];
			TimeLogger.detailedDrawTimes = new TimeLogger.TimeLogData[40];
			for (int i = 0; i < TimeLogger.renderTimes.Length; i++)
			{
				TimeLogger.renderTimes[i].logText = string.Format("Render #{0}", i);
			}
			TimeLogger.drawTimes[0].logText = "Drawing Solid Tiles";
			TimeLogger.drawTimes[1].logText = "Drawing Non-Solid Tiles";
			TimeLogger.drawTimes[2].logText = "Drawing Wall Tiles";
			TimeLogger.drawTimes[3].logText = "Drawing Underground Background";
			TimeLogger.drawTimes[4].logText = "Drawing Water Tiles";
			TimeLogger.drawTimes[5].logText = "Drawing Black Tiles";
			TimeLogger.lightingTimes[0].logText = "Lighting Initialization";
			for (int j = 1; j < TimeLogger.lightingTimes.Length; j++)
			{
				TimeLogger.lightingTimes[j].logText = string.Format("Lighting Pass #{0}", j);
			}
			TimeLogger.detailedDrawTimes[0].logText = "Finding color tiles";
			TimeLogger.detailedDrawTimes[1].logText = "Initial Map Update";
			TimeLogger.detailedDrawTimes[2].logText = "Finding Waterfalls";
			TimeLogger.detailedDrawTimes[3].logText = "Map Section Update";
			TimeLogger.detailedDrawTimes[4].logText = "Map Update";
			TimeLogger.detailedDrawTimes[5].logText = "Section Framing";
			TimeLogger.detailedDrawTimes[6].logText = "Sky Background";
			TimeLogger.detailedDrawTimes[7].logText = "Sun, Moon & Stars";
			TimeLogger.detailedDrawTimes[8].logText = "Surface Background";
			TimeLogger.detailedDrawTimes[9].logText = "Map";
			TimeLogger.detailedDrawTimes[10].logText = "Player Chat";
			TimeLogger.detailedDrawTimes[11].logText = "Water Target";
			TimeLogger.detailedDrawTimes[12].logText = "Background Target";
			TimeLogger.detailedDrawTimes[13].logText = "Black Tile Target";
			TimeLogger.detailedDrawTimes[14].logText = "Wall Target";
			TimeLogger.detailedDrawTimes[15].logText = "Non Solid Tile Target";
			TimeLogger.detailedDrawTimes[16].logText = "Waterfalls";
			TimeLogger.detailedDrawTimes[17].logText = "Solid Tile Target";
			TimeLogger.detailedDrawTimes[18].logText = "NPCs (Behind Tiles)";
			TimeLogger.detailedDrawTimes[19].logText = "NPC";
			TimeLogger.detailedDrawTimes[20].logText = "Projectiles";
			TimeLogger.detailedDrawTimes[21].logText = "Players";
			TimeLogger.detailedDrawTimes[22].logText = "Items";
			TimeLogger.detailedDrawTimes[23].logText = "Rain";
			TimeLogger.detailedDrawTimes[24].logText = "Gore";
			TimeLogger.detailedDrawTimes[25].logText = "Dust";
			TimeLogger.detailedDrawTimes[26].logText = "Water Target";
			TimeLogger.detailedDrawTimes[27].logText = "Interface";
			TimeLogger.detailedDrawTimes[28].logText = "Render Solid Tiles";
			TimeLogger.detailedDrawTimes[29].logText = "Render Non Solid Tiles";
			TimeLogger.detailedDrawTimes[30].logText = "Render Black Tiles";
			TimeLogger.detailedDrawTimes[31].logText = "Render Water/Wires";
			TimeLogger.detailedDrawTimes[32].logText = "Render Walls";
			TimeLogger.detailedDrawTimes[33].logText = "Render Backgrounds";
			TimeLogger.detailedDrawTimes[34].logText = "Drawing Wires";
			TimeLogger.detailedDrawTimes[35].logText = "Render layers up to Players";
			TimeLogger.detailedDrawTimes[36].logText = "Render Items/Rain/Gore/Dust/Water/Map";
			TimeLogger.detailedDrawTimes[37].logText = "Render Interface";
			for (int k = 0; k < TimeLogger.detailedDrawTimes.Length; k++)
			{
				if (string.IsNullOrEmpty(TimeLogger.detailedDrawTimes[k].logText))
				{
					TimeLogger.detailedDrawTimes[k].logText = string.Format("Unnamed detailed draw #{0}", k);
				}
			}
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x00344A04 File Offset: 0x00342C04
		public static void Start()
		{
			if (TimeLogger.currentlyLogging)
			{
				TimeLogger.endLoggingThisFrame = true;
				TimeLogger.startLoggingNextFrame = false;
				return;
			}
			TimeLogger.startLoggingNextFrame = true;
			TimeLogger.endLoggingThisFrame = false;
			Main.NewText("Detailed logging started", 250, 250, 0, false);
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x00344A3C File Offset: 0x00342C3C
		public static void NewDrawFrame()
		{
			for (int i = 0; i < TimeLogger.renderTimes.Length; i++)
			{
				TimeLogger.renderTimes[i].usedLastDraw = false;
			}
			for (int j = 0; j < TimeLogger.drawTimes.Length; j++)
			{
				TimeLogger.drawTimes[j].usedLastDraw = false;
			}
			for (int k = 0; k < TimeLogger.lightingTimes.Length; k++)
			{
				TimeLogger.lightingTimes[k].usedLastDraw = false;
			}
			if (TimeLogger.startLoggingNextFrame)
			{
				TimeLogger.startLoggingNextFrame = false;
				DateTime arg_7E_0 = DateTime.Now;
				string path = Main.SavePath + Path.DirectorySeparatorChar.ToString() + "TerrariaDrawLog.7z";
				try
				{
					TimeLogger.logWriter = new StreamWriter(new GZipStream(new FileStream(path, FileMode.Create), CompressionMode.Compress));
					TimeLogger.logBuilder = new StringBuilder(5000);
					TimeLogger.framesToLog = 600;
					TimeLogger.currentFrame = 1;
					TimeLogger.currentlyLogging = true;
				}
				catch
				{
					Main.NewText("Detailed logging could not be started.", 250, 250, 0, false);
				}
			}
			if (TimeLogger.currentlyLogging)
			{
				TimeLogger.logBuilder.AppendLine(string.Format("Start of Frame #{0}", TimeLogger.currentFrame));
			}
			TimeLogger.detailedDrawTimer.Restart();
			TimeLogger.lastDetailedDrawTime = TimeLogger.detailedDrawTimer.Elapsed.TotalMilliseconds;
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x00344B98 File Offset: 0x00342D98
		public static void EndDrawFrame()
		{
			if (TimeLogger.currentFrame <= TimeLogger.framesToLog)
			{
				TimeLogger.logBuilder.AppendLine(string.Format("End of Frame #{0}", TimeLogger.currentFrame));
				TimeLogger.logBuilder.AppendLine();
				if (TimeLogger.endLoggingThisFrame)
				{
					TimeLogger.endLoggingThisFrame = false;
					TimeLogger.logBuilder.AppendLine("Logging ended early");
					TimeLogger.currentFrame = TimeLogger.framesToLog;
				}
				if (TimeLogger.logBuilder.Length > 4000)
				{
					TimeLogger.logWriter.Write(TimeLogger.logBuilder.ToString());
					TimeLogger.logBuilder.Clear();
				}
				TimeLogger.currentFrame++;
				if (TimeLogger.currentFrame > TimeLogger.framesToLog)
				{
					Main.NewText("Detailed logging ended.", 250, 250, 0, false);
					TimeLogger.logWriter.Write(TimeLogger.logBuilder.ToString());
					TimeLogger.logBuilder.Clear();
					TimeLogger.logBuilder = null;
					TimeLogger.logWriter.Flush();
					TimeLogger.logWriter.Close();
					TimeLogger.logWriter = null;
					TimeLogger.framesToLog = -1;
					TimeLogger.currentFrame = 0;
					TimeLogger.currentlyLogging = false;
				}
			}
			TimeLogger.detailedDrawTimer.Stop();
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x00344CC0 File Offset: 0x00342EC0
		private static void UpdateTime(TimeLogger.TimeLogData[] times, int type, double time)
		{
			bool flag = false;
			if (times[type].resetMaxTime > 0)
			{
				times[type].resetMaxTime = times[type].resetMaxTime - 1;
			}
			else
			{
				times[type].timeMax = 0f;
			}
			times[type].time = (float)time;
			if ((double)times[type].timeMax < time)
			{
				flag = true;
				times[type].timeMax = (float)time;
				times[type].resetMaxTime = 100;
			}
			times[type].usedLastDraw = true;
			if (TimeLogger.currentFrame != 0)
			{
				TimeLogger.logBuilder.AppendLine(string.Format("    {0} : {1:F4}ms {2}", times[type].logText, time, flag ? " - New Maximum" : string.Empty));
			}
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x00344D88 File Offset: 0x00342F88
		public static void RenderTime(int renderType, double timeElapsed)
		{
			if (renderType < 0 || renderType >= TimeLogger.renderTimes.Length)
			{
				return;
			}
			TimeLogger.UpdateTime(TimeLogger.renderTimes, renderType, timeElapsed);
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x00344DA8 File Offset: 0x00342FA8
		public static float GetRenderTime(int renderType)
		{
			return TimeLogger.renderTimes[renderType].time;
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x00344DBC File Offset: 0x00342FBC
		public static float GetRenderMax(int renderType)
		{
			return TimeLogger.renderTimes[renderType].timeMax;
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x00344DD0 File Offset: 0x00342FD0
		public static void DrawTime(int drawType, double timeElapsed)
		{
			if (drawType < 0 || drawType >= TimeLogger.drawTimes.Length)
			{
				return;
			}
			TimeLogger.UpdateTime(TimeLogger.drawTimes, drawType, timeElapsed);
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x00344DF0 File Offset: 0x00342FF0
		public static float GetDrawTime(int drawType)
		{
			return TimeLogger.drawTimes[drawType].time;
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x00344E04 File Offset: 0x00343004
		public static float GetDrawTotal()
		{
			float num = 0f;
			for (int i = 0; i < TimeLogger.drawTimes.Length; i++)
			{
				num += TimeLogger.drawTimes[i].time;
			}
			return num;
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x00344E40 File Offset: 0x00343040
		public static void LightingTime(int lightingType, double timeElapsed)
		{
			if (lightingType < 0 || lightingType >= TimeLogger.lightingTimes.Length)
			{
				return;
			}
			TimeLogger.UpdateTime(TimeLogger.lightingTimes, lightingType, timeElapsed);
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x00344E60 File Offset: 0x00343060
		public static float GetLightingTime(int lightingType)
		{
			return TimeLogger.lightingTimes[lightingType].time;
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x00344E74 File Offset: 0x00343074
		public static float GetLightingTotal()
		{
			float num = 0f;
			for (int i = 0; i < TimeLogger.lightingTimes.Length; i++)
			{
				num += TimeLogger.lightingTimes[i].time;
			}
			return num;
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x00344EB0 File Offset: 0x003430B0
		public static void DetailedDrawReset()
		{
			TimeLogger.lastDetailedDrawTime = TimeLogger.detailedDrawTimer.Elapsed.TotalMilliseconds;
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x00344ED4 File Offset: 0x003430D4
		public static void DetailedDrawTime(int detailedDrawType)
		{
			if (detailedDrawType < 0 || detailedDrawType >= TimeLogger.detailedDrawTimes.Length)
			{
				return;
			}
			double expr_21 = TimeLogger.detailedDrawTimer.Elapsed.TotalMilliseconds;
			double time = expr_21 - TimeLogger.lastDetailedDrawTime;
			TimeLogger.lastDetailedDrawTime = expr_21;
			TimeLogger.UpdateTime(TimeLogger.detailedDrawTimes, detailedDrawType, time);
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x00344F1C File Offset: 0x0034311C
		public static float GetDetailedDrawTime(int detailedDrawType)
		{
			return TimeLogger.detailedDrawTimes[detailedDrawType].time;
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x00344F30 File Offset: 0x00343130
		public static float GetDetailedDrawTotal()
		{
			float num = 0f;
			for (int i = 0; i < TimeLogger.detailedDrawTimes.Length; i++)
			{
				if (TimeLogger.detailedDrawTimes[i].usedLastDraw)
				{
					num += TimeLogger.detailedDrawTimes[i].time;
				}
			}
			return num;
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x00344F7C File Offset: 0x0034317C
		public static void MenuDrawTime(double timeElapsed)
		{
			if (TimeLogger.currentlyLogging)
			{
				TimeLogger.logBuilder.AppendLine(string.Format("Menu Render Time : {0:F4}", timeElapsed));
			}
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x00344FA0 File Offset: 0x003431A0
		public static void SplashDrawTime(double timeElapsed)
		{
			if (TimeLogger.currentlyLogging)
			{
				TimeLogger.logBuilder.AppendLine(string.Format("Splash Render Time : {0:F4}", timeElapsed));
			}
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x00344FC4 File Offset: 0x003431C4
		public static void MapDrawTime(double timeElapsed)
		{
			if (TimeLogger.currentlyLogging)
			{
				TimeLogger.logBuilder.AppendLine(string.Format("Full Screen Map Render Time : {0:F4}", timeElapsed));
			}
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x00344FE8 File Offset: 0x003431E8
		public static void DrawException(Exception e)
		{
			if (TimeLogger.currentlyLogging)
			{
				TimeLogger.logBuilder.AppendLine(e.ToString());
			}
		}

		// Token: 0x04000C11 RID: 3089
		private static StreamWriter logWriter;

		// Token: 0x04000C12 RID: 3090
		private static StringBuilder logBuilder;

		// Token: 0x04000C13 RID: 3091
		private static int framesToLog;

		// Token: 0x04000C14 RID: 3092
		private static int currentFrame;

		// Token: 0x04000C15 RID: 3093
		private static bool startLoggingNextFrame;

		// Token: 0x04000C16 RID: 3094
		private static bool endLoggingThisFrame;

		// Token: 0x04000C17 RID: 3095
		private static bool currentlyLogging;

		// Token: 0x04000C18 RID: 3096
		private static Stopwatch detailedDrawTimer;

		// Token: 0x04000C19 RID: 3097
		private static double lastDetailedDrawTime;

		// Token: 0x04000C1A RID: 3098
		private static TimeLogger.TimeLogData[] renderTimes;

		// Token: 0x04000C1B RID: 3099
		private static TimeLogger.TimeLogData[] drawTimes;

		// Token: 0x04000C1C RID: 3100
		private static TimeLogger.TimeLogData[] lightingTimes;

		// Token: 0x04000C1D RID: 3101
		private static TimeLogger.TimeLogData[] detailedDrawTimes;

		// Token: 0x04000C1E RID: 3102
		private const int maxTimeDelay = 100;

		// Token: 0x020001D2 RID: 466
		private struct TimeLogData
		{
			// Token: 0x040036C5 RID: 14021
			public float time;

			// Token: 0x040036C6 RID: 14022
			public float timeMax;

			// Token: 0x040036C7 RID: 14023
			public int resetMaxTime;

			// Token: 0x040036C8 RID: 14024
			public bool usedLastDraw;

			// Token: 0x040036C9 RID: 14025
			public string logText;
		}
	}
}

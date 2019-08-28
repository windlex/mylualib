using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using ReLogic.Utilities;

namespace Terraria
{
	// Token: 0x02000007 RID: 7
	public class FrameSkipTest
	{
		// Token: 0x0600003F RID: 63 RVA: 0x00007D38 File Offset: 0x00005F38
		public static void Update(GameTime gameTime)
		{
			float num = 60f;
			float arg_1E_0 = 1f / num;
			float num2 = (float)gameTime.ElapsedGameTime.TotalSeconds;
			Thread.Sleep((int)MathHelper.Clamp((arg_1E_0 - num2) * 1000f + 1f, 0f, 1000f));
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00007D88 File Offset: 0x00005F88
		public static void CheckReset(GameTime gameTime)
		{
			if (FrameSkipTest.LastRecordedSecondNumber != gameTime.TotalGameTime.Seconds)
			{
				FrameSkipTest.DeltaSamples.Add(FrameSkipTest.DeltasThisSecond / FrameSkipTest.CallsThisSecond);
				if (FrameSkipTest.DeltaSamples.Count > 5)
				{
					FrameSkipTest.DeltaSamples.RemoveAt(0);
				}
				FrameSkipTest.CallsThisSecond = 0f;
				FrameSkipTest.DeltasThisSecond = 0f;
				FrameSkipTest.LastRecordedSecondNumber = gameTime.TotalGameTime.Seconds;
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00007E00 File Offset: 0x00006000
		public static void UpdateServerTest()
		{
			FrameSkipTest.serverFramerateTest.Record("frame time");
			FrameSkipTest.serverFramerateTest.StopAndPrint();
			FrameSkipTest.serverFramerateTest.Start();
		}

		// Token: 0x0400003E RID: 62
		private static int LastRecordedSecondNumber;

		// Token: 0x0400003F RID: 63
		private static float CallsThisSecond = 0f;

		// Token: 0x04000040 RID: 64
		private static float DeltasThisSecond = 0f;

		// Token: 0x04000041 RID: 65
		private static List<float> DeltaSamples = new List<float>();

		// Token: 0x04000042 RID: 66
		private const int SamplesCount = 5;

		// Token: 0x04000043 RID: 67
		private static MultiTimer serverFramerateTest = new MultiTimer(60);
	}
}

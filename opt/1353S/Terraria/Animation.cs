using System;
using System.Collections.Generic;
using Terraria.DataStructures;

namespace Terraria
{
	// Token: 0x02000039 RID: 57
	public class Animation
	{
		// Token: 0x0600086E RID: 2158 RVA: 0x003AC658 File Offset: 0x003AA858
		public static void Initialize()
		{
			Animation._animations = new List<Animation>();
			Animation._temporaryAnimations = new Dictionary<Point16, Animation>();
			Animation._awaitingRemoval = new List<Point16>();
			Animation._awaitingAddition = new List<Animation>();
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x003AC684 File Offset: 0x003AA884
		private void SetDefaults(int type)
		{
			this._tileType = 0;
			this._frame = 0;
			this._frameMax = 0;
			this._frameCounter = 0;
			this._frameCounterMax = 0;
			this._temporary = false;
			switch (type)
			{
			case 0:
				this._frameMax = 5;
				this._frameCounterMax = 12;
				this._frameData = new int[this._frameMax];
				for (int i = 0; i < this._frameMax; i++)
				{
					this._frameData[i] = i + 1;
				}
				return;
			case 1:
				this._frameMax = 5;
				this._frameCounterMax = 12;
				this._frameData = new int[this._frameMax];
				for (int j = 0; j < this._frameMax; j++)
				{
					this._frameData[j] = 5 - j;
				}
				return;
			case 2:
				this._frameCounterMax = 6;
				this._frameData = new int[]
				{
					1,
					2,
					2,
					2,
					1
				};
				this._frameMax = this._frameData.Length;
				return;
			default:
				return;
			}
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x003AC774 File Offset: 0x003AA974
		public static void NewTemporaryAnimation(int type, ushort tileType, int x, int y)
		{
			Point16 coordinates = new Point16(x, y);
			if (x < 0 || x >= Main.maxTilesX || y < 0 || y >= Main.maxTilesY)
			{
				return;
			}
			Animation animation = new Animation();
			animation.SetDefaults(type);
			animation._tileType = tileType;
			animation._coordinates = coordinates;
			animation._temporary = true;
			Animation._awaitingAddition.Add(animation);
			if (Main.netMode == 2)
			{
				NetMessage.SendTemporaryAnimation(-1, type, (int)tileType, x, y);
			}
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x003AC7E4 File Offset: 0x003AA9E4
		private static void RemoveTemporaryAnimation(short x, short y)
		{
			Point16 point = new Point16(x, y);
			if (Animation._temporaryAnimations.ContainsKey(point))
			{
				Animation._awaitingRemoval.Add(point);
			}
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x003AC814 File Offset: 0x003AAA14
		public static void UpdateAll()
		{
			for (int i = 0; i < Animation._animations.Count; i++)
			{
				Animation._animations[i].Update();
			}
			if (Animation._awaitingAddition.Count > 0)
			{
				for (int j = 0; j < Animation._awaitingAddition.Count; j++)
				{
					Animation animation = Animation._awaitingAddition[j];
					Animation._temporaryAnimations[animation._coordinates] = animation;
				}
				Animation._awaitingAddition.Clear();
			}
			foreach (KeyValuePair<Point16, Animation> current in Animation._temporaryAnimations)
			{
				current.Value.Update();
			}
			if (Animation._awaitingRemoval.Count > 0)
			{
				for (int k = 0; k < Animation._awaitingRemoval.Count; k++)
				{
					Animation._temporaryAnimations.Remove(Animation._awaitingRemoval[k]);
				}
				Animation._awaitingRemoval.Clear();
			}
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x003AC924 File Offset: 0x003AAB24
		public void Update()
		{
			if (this._temporary)
			{
				Tile tile = Main.tile[(int)this._coordinates.X, (int)this._coordinates.Y];
				if (tile != null && tile.type != this._tileType)
				{
					Animation.RemoveTemporaryAnimation(this._coordinates.X, this._coordinates.Y);
					return;
				}
			}
			this._frameCounter++;
			if (this._frameCounter >= this._frameCounterMax)
			{
				this._frameCounter = 0;
				this._frame++;
				if (this._frame >= this._frameMax)
				{
					this._frame = 0;
					if (this._temporary)
					{
						Animation.RemoveTemporaryAnimation(this._coordinates.X, this._coordinates.Y);
					}
				}
			}
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x003AC9F0 File Offset: 0x003AABF0
		public static bool GetTemporaryFrame(int x, int y, out int frameData)
		{
			Point16 key = new Point16(x, y);
			Animation animation;
			if (!Animation._temporaryAnimations.TryGetValue(key, out animation))
			{
				frameData = 0;
				return false;
			}
			frameData = animation._frameData[animation._frame];
			return true;
		}

		// Token: 0x04000D0E RID: 3342
		private static List<Animation> _animations;

		// Token: 0x04000D0F RID: 3343
		private static Dictionary<Point16, Animation> _temporaryAnimations;

		// Token: 0x04000D10 RID: 3344
		private static List<Point16> _awaitingRemoval;

		// Token: 0x04000D11 RID: 3345
		private static List<Animation> _awaitingAddition;

		// Token: 0x04000D12 RID: 3346
		private bool _temporary;

		// Token: 0x04000D13 RID: 3347
		private Point16 _coordinates;

		// Token: 0x04000D14 RID: 3348
		private ushort _tileType;

		// Token: 0x04000D15 RID: 3349
		private int _frame;

		// Token: 0x04000D16 RID: 3350
		private int _frameMax;

		// Token: 0x04000D17 RID: 3351
		private int _frameCounter;

		// Token: 0x04000D18 RID: 3352
		private int _frameCounterMax;

		// Token: 0x04000D19 RID: 3353
		private int[] _frameData;
	}
}

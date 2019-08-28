using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Graphics.Effects
{
	// Token: 0x020000F4 RID: 244
	public class SkyManager : EffectManager<CustomSky>
	{
		// Token: 0x06000DE0 RID: 3552 RVA: 0x003E6908 File Offset: 0x003E4B08
		public void Reset()
		{
			using (Dictionary<string, CustomSky>.ValueCollection.Enumerator enumerator = this._effects.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.Reset();
				}
			}
			this._activeSkies.Clear();
		}

		// Token: 0x06000DE1 RID: 3553 RVA: 0x003E6968 File Offset: 0x003E4B68
		public void Update(GameTime gameTime)
		{
			LinkedListNode<CustomSky> next;
			for (LinkedListNode<CustomSky> linkedListNode = this._activeSkies.First; linkedListNode != null; linkedListNode = next)
			{
				CustomSky arg_1B_0 = linkedListNode.Value;
				next = linkedListNode.Next;
				arg_1B_0.Update(gameTime);
				if (!arg_1B_0.IsActive())
				{
					this._activeSkies.Remove(linkedListNode);
				}
			}
		}

		// Token: 0x06000DE2 RID: 3554 RVA: 0x003E69B0 File Offset: 0x003E4BB0
		public void Draw(SpriteBatch spriteBatch)
		{
			this.DrawDepthRange(spriteBatch, -3.40282347E+38f, 3.40282347E+38f);
		}

		// Token: 0x06000DE3 RID: 3555 RVA: 0x003E69C4 File Offset: 0x003E4BC4
		public void DrawToDepth(SpriteBatch spriteBatch, float minDepth)
		{
			if (this._lastDepth <= minDepth)
			{
				return;
			}
			this.DrawDepthRange(spriteBatch, minDepth, this._lastDepth);
			this._lastDepth = minDepth;
		}

		// Token: 0x06000DE4 RID: 3556 RVA: 0x003E69E8 File Offset: 0x003E4BE8
		public void DrawDepthRange(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			using (LinkedList<CustomSky>.Enumerator enumerator = this._activeSkies.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.Draw(spriteBatch, minDepth, maxDepth);
				}
			}
		}

		// Token: 0x06000DE5 RID: 3557 RVA: 0x003E6A3C File Offset: 0x003E4C3C
		public void DrawRemainingDepth(SpriteBatch spriteBatch)
		{
			this.DrawDepthRange(spriteBatch, -3.40282347E+38f, this._lastDepth);
			this._lastDepth = -3.40282347E+38f;
		}

		// Token: 0x06000DE6 RID: 3558 RVA: 0x003E6A5C File Offset: 0x003E4C5C
		public void ResetDepthTracker()
		{
			this._lastDepth = 3.40282347E+38f;
		}

		// Token: 0x06000DE7 RID: 3559 RVA: 0x003E6A6C File Offset: 0x003E4C6C
		public void SetStartingDepth(float depth)
		{
			this._lastDepth = depth;
		}

		// Token: 0x06000DE8 RID: 3560 RVA: 0x003E6A78 File Offset: 0x003E4C78
		public override void OnActivate(CustomSky effect, Vector2 position)
		{
			this._activeSkies.Remove(effect);
			this._activeSkies.AddLast(effect);
		}

		// Token: 0x06000DE9 RID: 3561 RVA: 0x003E6A94 File Offset: 0x003E4C94
		public Color ProcessTileColor(Color color)
		{
			using (LinkedList<CustomSky>.Enumerator enumerator = this._activeSkies.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					color = enumerator.Current.OnTileColor(color);
				}
			}
			return color;
		}

		// Token: 0x06000DEA RID: 3562 RVA: 0x003E6AE8 File Offset: 0x003E4CE8
		public float ProcessCloudAlpha()
		{
			float num = 1f;
			foreach (CustomSky current in this._activeSkies)
			{
				num *= current.GetCloudAlpha();
			}
			return MathHelper.Clamp(num, 0f, 1f);
		}

		// Token: 0x04002F6D RID: 12141
		public static SkyManager Instance = new SkyManager();

		// Token: 0x04002F6E RID: 12142
		private float _lastDepth;

		// Token: 0x04002F6F RID: 12143
		private LinkedList<CustomSky> _activeSkies = new LinkedList<CustomSky>();
	}
}

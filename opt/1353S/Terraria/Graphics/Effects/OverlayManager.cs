using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Graphics.Effects
{
	// Token: 0x020000FF RID: 255
	public class OverlayManager : EffectManager<Overlay>
	{
		// Token: 0x06000E19 RID: 3609 RVA: 0x003E74B4 File Offset: 0x003E56B4
		public OverlayManager()
		{
			for (int i = 0; i < this._activeOverlays.Length; i++)
			{
				this._activeOverlays[i] = new LinkedList<Overlay>();
			}
		}

		// Token: 0x06000E1A RID: 3610 RVA: 0x003E7504 File Offset: 0x003E5704
		public override void OnActivate(Overlay overlay, Vector2 position)
		{
			LinkedList<Overlay> linkedList = this._activeOverlays[(int)overlay.Priority];
			if (overlay.Mode == OverlayMode.FadeIn || overlay.Mode == OverlayMode.Active)
			{
				return;
			}
			if (overlay.Mode == OverlayMode.FadeOut)
			{
				linkedList.Remove(overlay);
				this._overlayCount--;
			}
			else
			{
				overlay.Opacity = 0f;
			}
			if (linkedList.Count != 0)
			{
				using (LinkedList<Overlay>.Enumerator enumerator = linkedList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						enumerator.Current.Mode = OverlayMode.FadeOut;
					}
				}
			}
			linkedList.AddLast(overlay);
			this._overlayCount++;
		}

		// Token: 0x06000E1B RID: 3611 RVA: 0x003E75BC File Offset: 0x003E57BC
		public void Update(GameTime gameTime)
		{
			for (int i = 0; i < this._activeOverlays.Length; i++)
			{
				LinkedListNode<Overlay> next;
				for (LinkedListNode<Overlay> linkedListNode = this._activeOverlays[i].First; linkedListNode != null; linkedListNode = next)
				{
					Overlay value = linkedListNode.Value;
					next = linkedListNode.Next;
					value.Update(gameTime);
					switch (value.Mode)
					{
					case OverlayMode.FadeIn:
						value.Opacity += (float)gameTime.ElapsedGameTime.TotalSeconds * 1f;
						if (value.Opacity >= 1f)
						{
							value.Opacity = 1f;
							value.Mode = OverlayMode.Active;
						}
						break;
					case OverlayMode.Active:
						value.Opacity = Math.Min(1f, value.Opacity + (float)gameTime.ElapsedGameTime.TotalSeconds * 1f);
						break;
					case OverlayMode.FadeOut:
						value.Opacity -= (float)gameTime.ElapsedGameTime.TotalSeconds * 1f;
						if (value.Opacity <= 0f)
						{
							value.Opacity = 0f;
							value.Mode = OverlayMode.Inactive;
							this._activeOverlays[i].Remove(linkedListNode);
							this._overlayCount--;
						}
						break;
					}
				}
			}
		}

		// Token: 0x06000E1C RID: 3612 RVA: 0x003E7708 File Offset: 0x003E5908
		public void Draw(SpriteBatch spriteBatch, RenderLayers layer)
		{
			if (this._overlayCount == 0)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < this._activeOverlays.Length; i++)
			{
				for (LinkedListNode<Overlay> linkedListNode = this._activeOverlays[i].First; linkedListNode != null; linkedListNode = linkedListNode.Next)
				{
					Overlay value = linkedListNode.Value;
					if (value.Layer == layer && value.IsVisible())
					{
						if (!flag)
						{
							spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Main.Transform);
							flag = true;
						}
						value.Draw(spriteBatch);
					}
				}
			}
			if (flag)
			{
				spriteBatch.End();
			}
		}

		// Token: 0x04002F8F RID: 12175
		private const float OPACITY_RATE = 1f;

		// Token: 0x04002F90 RID: 12176
		private LinkedList<Overlay>[] _activeOverlays = new LinkedList<Overlay>[Enum.GetNames(typeof(EffectPriority)).Length];

		// Token: 0x04002F91 RID: 12177
		private int _overlayCount;
	}
}

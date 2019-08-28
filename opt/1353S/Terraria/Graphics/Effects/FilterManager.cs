using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.IO;

namespace Terraria.Graphics.Effects
{
	// Token: 0x020000F9 RID: 249
	public class FilterManager : EffectManager<Filter>
	{
		// Token: 0x14000026 RID: 38
		// (add) Token: 0x06000E00 RID: 3584 RVA: 0x003E6E0C File Offset: 0x003E500C
		// (remove) Token: 0x06000E01 RID: 3585 RVA: 0x003E6E44 File Offset: 0x003E5044
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event Action OnPostDraw;

		// Token: 0x06000E02 RID: 3586 RVA: 0x003E6E7C File Offset: 0x003E507C
		public FilterManager()
		{
			Main.Configuration.OnLoad += delegate(Preferences preferences)
			{
				this._filterLimit = preferences.Get<int>("FilterLimit", 16);
				EffectPriority priorityThreshold;
				if (Enum.TryParse<EffectPriority>(preferences.Get<string>("FilterPriorityThreshold", "VeryLow"), out priorityThreshold))
				{
					this._priorityThreshold = priorityThreshold;
				}
			};
			Main.Configuration.OnSave += delegate(Preferences preferences)
			{
				preferences.Put("FilterLimit", this._filterLimit);
				preferences.Put("FilterPriorityThreshold", Enum.GetName(typeof(EffectPriority), this._priorityThreshold));
			};
		}

		// Token: 0x06000E03 RID: 3587 RVA: 0x003E6ED0 File Offset: 0x003E50D0
		public override void OnActivate(Filter effect, Vector2 position)
		{
			if (this._activeFilters.Contains(effect))
			{
				if (effect.Active)
				{
					return;
				}
				if (effect.Priority >= this._priorityThreshold)
				{
					this._activeFilterCount--;
				}
				this._activeFilters.Remove(effect);
			}
			else
			{
				effect.Opacity = 0f;
			}
			if (effect.Priority >= this._priorityThreshold)
			{
				this._activeFilterCount++;
			}
			if (this._activeFilters.Count == 0)
			{
				this._activeFilters.AddLast(effect);
				return;
			}
			for (LinkedListNode<Filter> linkedListNode = this._activeFilters.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				Filter value = linkedListNode.Value;
				if (effect.Priority <= value.Priority)
				{
					this._activeFilters.AddAfter(linkedListNode, effect);
					return;
				}
			}
			this._activeFilters.AddLast(effect);
		}

		// Token: 0x06000E04 RID: 3588 RVA: 0x003E6FAC File Offset: 0x003E51AC
		public void BeginCapture()
		{
			if (this._activeFilterCount == 0 && this.OnPostDraw == null)
			{
				this._captureThisFrame = false;
				return;
			}
			this._captureThisFrame = true;
			Main.instance.GraphicsDevice.SetRenderTarget(Main.screenTarget);
			Main.instance.GraphicsDevice.Clear(Color.Black);
		}

		// Token: 0x06000E05 RID: 3589 RVA: 0x003E7000 File Offset: 0x003E5200
		public void Update(GameTime gameTime)
		{
			LinkedListNode<Filter> linkedListNode = this._activeFilters.First;
			int arg_17_0 = this._activeFilters.Count;
			int num = 0;
			while (linkedListNode != null)
			{
				Filter value = linkedListNode.Value;
				LinkedListNode<Filter> arg_FC_0 = linkedListNode.Next;
				bool flag = false;
				if (value.Priority >= this._priorityThreshold)
				{
					num++;
					if (num > this._activeFilterCount - this._filterLimit)
					{
						value.Update(gameTime);
						flag = true;
					}
				}
				if (value.Active & flag)
				{
					value.Opacity = Math.Min(value.Opacity + (float)gameTime.ElapsedGameTime.TotalSeconds * 1f, 1f);
				}
				else
				{
					value.Opacity = Math.Max(value.Opacity - (float)gameTime.ElapsedGameTime.TotalSeconds * 1f, 0f);
				}
				if (!value.Active && value.Opacity == 0f)
				{
					if (value.Priority >= this._priorityThreshold)
					{
						this._activeFilterCount--;
					}
					this._activeFilters.Remove(linkedListNode);
				}
				linkedListNode = arg_FC_0;
			}
		}

		// Token: 0x06000E06 RID: 3590 RVA: 0x003E7110 File Offset: 0x003E5310
		public void EndCapture()
		{
			if (!this._captureThisFrame)
			{
				return;
			}
			LinkedListNode<Filter> linkedListNode = this._activeFilters.First;
			int arg_20_0 = this._activeFilters.Count;
			Filter filter = null;
			RenderTarget2D renderTarget2D = Main.screenTarget;
			GraphicsDevice graphicsDevice = Main.instance.GraphicsDevice;
			int num = 0;
			if (Main.player[Main.myPlayer].gravDir == -1f)
			{
				RenderTarget2D renderTarget = Main.screenTargetSwap;
				graphicsDevice.SetRenderTarget(renderTarget);
				graphicsDevice.Clear(Color.Black);
				Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Matrix.Invert(Main.GameViewMatrix.EffectMatrix));
				Main.spriteBatch.Draw(renderTarget2D, Vector2.Zero, Color.White);
				Main.spriteBatch.End();
				renderTarget2D = Main.screenTargetSwap;
			}
			while (linkedListNode != null)
			{
				Filter value = linkedListNode.Value;
				LinkedListNode<Filter> arg_185_0 = linkedListNode.Next;
				if (value.Priority >= this._priorityThreshold)
				{
					num++;
					if (num > this._activeFilterCount - this._filterLimit && value.IsVisible())
					{
						if (filter != null)
						{
							RenderTarget2D renderTarget;
							if (renderTarget2D == Main.screenTarget)
							{
								renderTarget = Main.screenTargetSwap;
							}
							else
							{
								renderTarget = Main.screenTarget;
							}
							graphicsDevice.SetRenderTarget(renderTarget);
							graphicsDevice.Clear(Color.Black);
							Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
							filter.Apply();
							Main.spriteBatch.Draw(renderTarget2D, Vector2.Zero, Main.bgColor);
							Main.spriteBatch.End();
							if (renderTarget2D == Main.screenTarget)
							{
								renderTarget2D = Main.screenTargetSwap;
							}
							else
							{
								renderTarget2D = Main.screenTarget;
							}
						}
						filter = value;
					}
				}
				linkedListNode = arg_185_0;
			}
			graphicsDevice.SetRenderTarget(null);
			graphicsDevice.Clear(Color.Black);
			if (Main.player[Main.myPlayer].gravDir == -1f)
			{
				Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Main.GameViewMatrix.EffectMatrix);
			}
			else
			{
				Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
			}
			if (filter != null)
			{
				filter.Apply();
				Main.spriteBatch.Draw(renderTarget2D, Vector2.Zero, Main.bgColor);
			}
			else
			{
				Main.spriteBatch.Draw(renderTarget2D, Vector2.Zero, Color.White);
			}
			Main.spriteBatch.End();
			for (int i = 0; i < 8; i++)
			{
				graphicsDevice.Textures[i] = null;
			}
			if (this.OnPostDraw != null)
			{
				this.OnPostDraw();
			}
		}

		// Token: 0x06000E07 RID: 3591 RVA: 0x003E7384 File Offset: 0x003E5584
		public bool HasActiveFilter()
		{
			return this._activeFilters.Count != 0;
		}

		// Token: 0x06000E08 RID: 3592 RVA: 0x003E7394 File Offset: 0x003E5594
		public bool CanCapture()
		{
			return this.HasActiveFilter() || this.OnPostDraw != null;
		}

		// Token: 0x04002F7C RID: 12156
		private const float OPACITY_RATE = 1f;

		// Token: 0x04002F7E RID: 12158
		private LinkedList<Filter> _activeFilters = new LinkedList<Filter>();

		// Token: 0x04002F7F RID: 12159
		private int _filterLimit = 16;

		// Token: 0x04002F80 RID: 12160
		private EffectPriority _priorityThreshold;

		// Token: 0x04002F81 RID: 12161
		private int _activeFilterCount;

		// Token: 0x04002F82 RID: 12162
		private bool _captureThisFrame;
	}
}

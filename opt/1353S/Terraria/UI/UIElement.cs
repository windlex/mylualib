using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.UI.Elements;

namespace Terraria.UI
{
	// Token: 0x020000AC RID: 172
	public class UIElement : IComparable
	{
		// Token: 0x14000014 RID: 20
		// (add) Token: 0x06000C0B RID: 3083 RVA: 0x003D7C04 File Offset: 0x003D5E04
		// (remove) Token: 0x06000C0C RID: 3084 RVA: 0x003D7C3C File Offset: 0x003D5E3C
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event UIElement.MouseEvent OnMouseDown;

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x06000C0D RID: 3085 RVA: 0x003D7C74 File Offset: 0x003D5E74
		// (remove) Token: 0x06000C0E RID: 3086 RVA: 0x003D7CAC File Offset: 0x003D5EAC
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event UIElement.MouseEvent OnMouseUp;

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000C0F RID: 3087 RVA: 0x003D7CE4 File Offset: 0x003D5EE4
		// (remove) Token: 0x06000C10 RID: 3088 RVA: 0x003D7D1C File Offset: 0x003D5F1C
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event UIElement.MouseEvent OnClick;

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x06000C11 RID: 3089 RVA: 0x003D7D54 File Offset: 0x003D5F54
		// (remove) Token: 0x06000C12 RID: 3090 RVA: 0x003D7D8C File Offset: 0x003D5F8C
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event UIElement.MouseEvent OnMouseOver;

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x06000C13 RID: 3091 RVA: 0x003D7DC4 File Offset: 0x003D5FC4
		// (remove) Token: 0x06000C14 RID: 3092 RVA: 0x003D7DFC File Offset: 0x003D5FFC
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event UIElement.MouseEvent OnMouseOut;

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x06000C15 RID: 3093 RVA: 0x003D7E34 File Offset: 0x003D6034
		// (remove) Token: 0x06000C16 RID: 3094 RVA: 0x003D7E6C File Offset: 0x003D606C
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event UIElement.MouseEvent OnDoubleClick;

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x06000C17 RID: 3095 RVA: 0x003D7EA4 File Offset: 0x003D60A4
		// (remove) Token: 0x06000C18 RID: 3096 RVA: 0x003D7EDC File Offset: 0x003D60DC
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event UIElement.ScrollWheelEvent OnScrollWheel;

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000C19 RID: 3097 RVA: 0x003D7F14 File Offset: 0x003D6114
		public bool IsMouseHovering
		{
			get
			{
				return this._isMouseHovering;
			}
		}

		// Token: 0x06000C1A RID: 3098 RVA: 0x003D7F1C File Offset: 0x003D611C
		public UIElement()
		{
			if (UIElement._overflowHiddenRasterizerState == null)
			{
				UIElement._overflowHiddenRasterizerState = new RasterizerState
				{
					CullMode = CullMode.None,
					ScissorTestEnable = true
				};
			}
		}

		// Token: 0x06000C1B RID: 3099 RVA: 0x003D7F90 File Offset: 0x003D6190
		public void SetSnapPoint(string name, int id, Vector2? anchor = null, Vector2? offset = null)
		{
			if (!anchor.HasValue)
			{
				anchor = new Vector2?(new Vector2(0.5f));
			}
			if (!offset.HasValue)
			{
				offset = new Vector2?(Vector2.Zero);
			}
			this._snapPoint = new SnapPoint(name, id, anchor.Value, offset.Value);
		}

		// Token: 0x06000C1C RID: 3100 RVA: 0x003D7FE8 File Offset: 0x003D61E8
		public bool GetSnapPoint(out SnapPoint point)
		{
			point = this._snapPoint;
			if (this._snapPoint != null)
			{
				this._snapPoint.Calculate(this);
			}
			return this._snapPoint != null;
		}

		// Token: 0x06000C1D RID: 3101 RVA: 0x003D8010 File Offset: 0x003D6210
		protected virtual void DrawSelf(SpriteBatch spriteBatch)
		{
		}

		// Token: 0x06000C1E RID: 3102 RVA: 0x003D8014 File Offset: 0x003D6214
		protected virtual void DrawChildren(SpriteBatch spriteBatch)
		{
			using (List<UIElement>.Enumerator enumerator = this.Elements.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.Draw(spriteBatch);
				}
			}
		}

		// Token: 0x06000C1F RID: 3103 RVA: 0x003D8068 File Offset: 0x003D6268
		public void Append(UIElement element)
		{
			element.Remove();
			element.Parent = this;
			this.Elements.Add(element);
			element.Recalculate();
		}

		// Token: 0x06000C20 RID: 3104 RVA: 0x003D808C File Offset: 0x003D628C
		public void Remove()
		{
			if (this.Parent != null)
			{
				this.Parent.RemoveChild(this);
			}
		}

		// Token: 0x06000C21 RID: 3105 RVA: 0x003D80A4 File Offset: 0x003D62A4
		public void RemoveChild(UIElement child)
		{
			this.Elements.Remove(child);
			child.Parent = null;
		}

		// Token: 0x06000C22 RID: 3106 RVA: 0x003D80BC File Offset: 0x003D62BC
		public void RemoveAllChildren()
		{
			using (List<UIElement>.Enumerator enumerator = this.Elements.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.Parent = null;
				}
			}
			this.Elements.Clear();
		}

		// Token: 0x06000C23 RID: 3107 RVA: 0x003D8118 File Offset: 0x003D6318
		public virtual void Draw(SpriteBatch spriteBatch)
		{
			bool arg_82_0 = this.OverflowHidden;
			bool arg_2A_0 = this._useImmediateMode;
			RasterizerState rasterizerState = spriteBatch.GraphicsDevice.RasterizerState;
			Rectangle scissorRectangle = spriteBatch.GraphicsDevice.ScissorRectangle;
			SamplerState anisotropicClamp = SamplerState.AnisotropicClamp;
			if (arg_2A_0)
			{
				spriteBatch.End();
				spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, anisotropicClamp, DepthStencilState.None, UIElement._overflowHiddenRasterizerState, null, Main.UIScaleMatrix);
				this.DrawSelf(spriteBatch);
				spriteBatch.End();
				spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, anisotropicClamp, DepthStencilState.None, UIElement._overflowHiddenRasterizerState, null, Main.UIScaleMatrix);
			}
			else
			{
				this.DrawSelf(spriteBatch);
			}
			if (arg_82_0)
			{
				spriteBatch.End();
				Rectangle clippingRectangle = this.GetClippingRectangle(spriteBatch);
				spriteBatch.GraphicsDevice.ScissorRectangle = clippingRectangle;
				spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, anisotropicClamp, DepthStencilState.None, UIElement._overflowHiddenRasterizerState, null, Main.UIScaleMatrix);
			}
			this.DrawChildren(spriteBatch);
			if (arg_82_0)
			{
				spriteBatch.End();
				spriteBatch.GraphicsDevice.ScissorRectangle = scissorRectangle;
				spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, anisotropicClamp, DepthStencilState.None, rasterizerState, null, Main.UIScaleMatrix);
			}
		}

		// Token: 0x06000C24 RID: 3108 RVA: 0x003D8218 File Offset: 0x003D6418
		public virtual void Update(GameTime gameTime)
		{
			using (List<UIElement>.Enumerator enumerator = this.Elements.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.Update(gameTime);
				}
			}
		}

		// Token: 0x06000C25 RID: 3109 RVA: 0x003D826C File Offset: 0x003D646C
		public Rectangle GetClippingRectangle(SpriteBatch spriteBatch)
		{
			Vector2 vector = new Vector2(this._innerDimensions.X, this._innerDimensions.Y);
			Vector2 vector2 = new Vector2(this._innerDimensions.Width, this._innerDimensions.Height) + vector;
			vector = Vector2.Transform(vector, Main.UIScaleMatrix);
			vector2 = Vector2.Transform(vector2, Main.UIScaleMatrix);
			Rectangle rectangle = new Rectangle((int)vector.X, (int)vector.Y, (int)(vector2.X - vector.X), (int)(vector2.Y - vector.Y));
			int width = spriteBatch.GraphicsDevice.Viewport.Width;
			int height = spriteBatch.GraphicsDevice.Viewport.Height;
			rectangle.X = Utils.Clamp<int>(rectangle.X, 0, width);
			rectangle.Y = Utils.Clamp<int>(rectangle.Y, 0, height);
			rectangle.Width = Utils.Clamp<int>(rectangle.Width, 0, width - rectangle.X);
			rectangle.Height = Utils.Clamp<int>(rectangle.Height, 0, height - rectangle.Y);
			return rectangle;
		}

		// Token: 0x06000C26 RID: 3110 RVA: 0x003D8390 File Offset: 0x003D6590
		public virtual List<SnapPoint> GetSnapPoints()
		{
			List<SnapPoint> list = new List<SnapPoint>();
			SnapPoint item;
			if (this.GetSnapPoint(out item))
			{
				list.Add(item);
			}
			foreach (UIElement current in this.Elements)
			{
				list.AddRange(current.GetSnapPoints());
			}
			return list;
		}

		// Token: 0x06000C27 RID: 3111 RVA: 0x003D8400 File Offset: 0x003D6600
		public virtual void Recalculate()
		{
			CalculatedStyle calculatedStyle;
			if (this.Parent != null)
			{
				calculatedStyle = this.Parent.GetInnerDimensions();
			}
			else
			{
				calculatedStyle = UserInterface.ActiveInstance.GetDimensions();
			}
			if (this.Parent != null && this.Parent is UIList)
			{
				calculatedStyle.Height = 3.40282347E+38f;
			}
			CalculatedStyle calculatedStyle2;
			calculatedStyle2.X = this.Left.GetValue(calculatedStyle.Width) + calculatedStyle.X;
			calculatedStyle2.Y = this.Top.GetValue(calculatedStyle.Height) + calculatedStyle.Y;
			float value = this.MinWidth.GetValue(calculatedStyle.Width);
			float value2 = this.MaxWidth.GetValue(calculatedStyle.Width);
			float value3 = this.MinHeight.GetValue(calculatedStyle.Height);
			float value4 = this.MaxHeight.GetValue(calculatedStyle.Height);
			calculatedStyle2.Width = MathHelper.Clamp(this.Width.GetValue(calculatedStyle.Width), value, value2);
			calculatedStyle2.Height = MathHelper.Clamp(this.Height.GetValue(calculatedStyle.Height), value3, value4);
			calculatedStyle2.Width += this.MarginLeft + this.MarginRight;
			calculatedStyle2.Height += this.MarginTop + this.MarginBottom;
			calculatedStyle2.X += calculatedStyle.Width * this.HAlign - calculatedStyle2.Width * this.HAlign;
			calculatedStyle2.Y += calculatedStyle.Height * this.VAlign - calculatedStyle2.Height * this.VAlign;
			this._outerDimensions = calculatedStyle2;
			calculatedStyle2.X += this.MarginLeft;
			calculatedStyle2.Y += this.MarginTop;
			calculatedStyle2.Width -= this.MarginLeft + this.MarginRight;
			calculatedStyle2.Height -= this.MarginTop + this.MarginBottom;
			this._dimensions = calculatedStyle2;
			calculatedStyle2.X += this.PaddingLeft;
			calculatedStyle2.Y += this.PaddingTop;
			calculatedStyle2.Width -= this.PaddingLeft + this.PaddingRight;
			calculatedStyle2.Height -= this.PaddingTop + this.PaddingBottom;
			this._innerDimensions = calculatedStyle2;
			this.RecalculateChildren();
		}

		// Token: 0x06000C28 RID: 3112 RVA: 0x003D8658 File Offset: 0x003D6858
		public UIElement GetElementAt(Vector2 point)
		{
			UIElement uIElement = null;
			foreach (UIElement current in this.Elements)
			{
				if (current.ContainsPoint(point))
				{
					uIElement = current;
					break;
				}
			}
			if (uIElement != null)
			{
				return uIElement.GetElementAt(point);
			}
			if (this.ContainsPoint(point))
			{
				return this;
			}
			return null;
		}

		// Token: 0x06000C29 RID: 3113 RVA: 0x003D86CC File Offset: 0x003D68CC
		public virtual bool ContainsPoint(Vector2 point)
		{
			return point.X > this._dimensions.X && point.Y > this._dimensions.Y && point.X < this._dimensions.X + this._dimensions.Width && point.Y < this._dimensions.Y + this._dimensions.Height;
		}

		// Token: 0x06000C2A RID: 3114 RVA: 0x003D8740 File Offset: 0x003D6940
		public void SetPadding(float pixels)
		{
			this.PaddingBottom = pixels;
			this.PaddingLeft = pixels;
			this.PaddingRight = pixels;
			this.PaddingTop = pixels;
		}

		// Token: 0x06000C2B RID: 3115 RVA: 0x003D8760 File Offset: 0x003D6960
		public virtual void RecalculateChildren()
		{
			using (List<UIElement>.Enumerator enumerator = this.Elements.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.Recalculate();
				}
			}
		}

		// Token: 0x06000C2C RID: 3116 RVA: 0x003D87B0 File Offset: 0x003D69B0
		public CalculatedStyle GetInnerDimensions()
		{
			return this._innerDimensions;
		}

		// Token: 0x06000C2D RID: 3117 RVA: 0x003D87B8 File Offset: 0x003D69B8
		public CalculatedStyle GetDimensions()
		{
			return this._dimensions;
		}

		// Token: 0x06000C2E RID: 3118 RVA: 0x003D87C0 File Offset: 0x003D69C0
		public CalculatedStyle GetOuterDimensions()
		{
			return this._outerDimensions;
		}

		// Token: 0x06000C2F RID: 3119 RVA: 0x003D87C8 File Offset: 0x003D69C8
		public void CopyStyle(UIElement element)
		{
			this.Top = element.Top;
			this.Left = element.Left;
			this.Width = element.Width;
			this.Height = element.Height;
			this.PaddingBottom = element.PaddingBottom;
			this.PaddingLeft = element.PaddingLeft;
			this.PaddingRight = element.PaddingRight;
			this.PaddingTop = element.PaddingTop;
			this.HAlign = element.HAlign;
			this.VAlign = element.VAlign;
			this.MinWidth = element.MinWidth;
			this.MaxWidth = element.MaxWidth;
			this.MinHeight = element.MinHeight;
			this.MaxHeight = element.MaxHeight;
			this.Recalculate();
		}

		// Token: 0x06000C30 RID: 3120 RVA: 0x003D8884 File Offset: 0x003D6A84
		public virtual void MouseDown(UIMouseEvent evt)
		{
			if (this.OnMouseDown != null)
			{
				this.OnMouseDown(evt, this);
			}
			if (this.Parent != null)
			{
				this.Parent.MouseDown(evt);
			}
		}

		// Token: 0x06000C31 RID: 3121 RVA: 0x003D88B0 File Offset: 0x003D6AB0
		public virtual void MouseUp(UIMouseEvent evt)
		{
			if (this.OnMouseUp != null)
			{
				this.OnMouseUp(evt, this);
			}
			if (this.Parent != null)
			{
				this.Parent.MouseUp(evt);
			}
		}

		// Token: 0x06000C32 RID: 3122 RVA: 0x003D88DC File Offset: 0x003D6ADC
		public virtual void MouseOver(UIMouseEvent evt)
		{
			this._isMouseHovering = true;
			if (this.OnMouseOver != null)
			{
				this.OnMouseOver(evt, this);
			}
			if (this.Parent != null)
			{
				this.Parent.MouseOver(evt);
			}
		}

		// Token: 0x06000C33 RID: 3123 RVA: 0x003D8910 File Offset: 0x003D6B10
		public virtual void MouseOut(UIMouseEvent evt)
		{
			this._isMouseHovering = false;
			if (this.OnMouseOut != null)
			{
				this.OnMouseOut(evt, this);
			}
			if (this.Parent != null)
			{
				this.Parent.MouseOut(evt);
			}
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x003D8944 File Offset: 0x003D6B44
		public virtual void Click(UIMouseEvent evt)
		{
			if (this.OnClick != null)
			{
				this.OnClick(evt, this);
			}
			if (this.Parent != null)
			{
				this.Parent.Click(evt);
			}
		}

		// Token: 0x06000C35 RID: 3125 RVA: 0x003D8970 File Offset: 0x003D6B70
		public virtual void DoubleClick(UIMouseEvent evt)
		{
			if (this.OnDoubleClick != null)
			{
				this.OnDoubleClick(evt, this);
			}
			if (this.Parent != null)
			{
				this.Parent.DoubleClick(evt);
			}
		}

		// Token: 0x06000C36 RID: 3126 RVA: 0x003D899C File Offset: 0x003D6B9C
		public virtual void ScrollWheel(UIScrollWheelEvent evt)
		{
			if (this.OnScrollWheel != null)
			{
				this.OnScrollWheel(evt, this);
			}
			if (this.Parent != null)
			{
				this.Parent.ScrollWheel(evt);
			}
		}

		// Token: 0x06000C37 RID: 3127 RVA: 0x003D89C8 File Offset: 0x003D6BC8
		public void Activate()
		{
			if (!this._isInitialized)
			{
				this.Initialize();
			}
			this.OnActivate();
			using (List<UIElement>.Enumerator enumerator = this.Elements.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.Activate();
				}
			}
		}

		// Token: 0x06000C38 RID: 3128 RVA: 0x003D8A2C File Offset: 0x003D6C2C
		public virtual void OnActivate()
		{
		}

		// Token: 0x06000C39 RID: 3129 RVA: 0x003D8A30 File Offset: 0x003D6C30
		public void Deactivate()
		{
			this.OnDeactivate();
			using (List<UIElement>.Enumerator enumerator = this.Elements.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.Deactivate();
				}
			}
		}

		// Token: 0x06000C3A RID: 3130 RVA: 0x003D8A88 File Offset: 0x003D6C88
		public virtual void OnDeactivate()
		{
		}

		// Token: 0x06000C3B RID: 3131 RVA: 0x003D8A8C File Offset: 0x003D6C8C
		public void Initialize()
		{
			this.OnInitialize();
			this._isInitialized = true;
		}

		// Token: 0x06000C3C RID: 3132 RVA: 0x003D8A9C File Offset: 0x003D6C9C
		public virtual void OnInitialize()
		{
		}

		// Token: 0x06000C3D RID: 3133 RVA: 0x003D8AA0 File Offset: 0x003D6CA0
		public virtual int CompareTo(object obj)
		{
			return 0;
		}

		// Token: 0x04000EDD RID: 3805
		public string Id = "";

		// Token: 0x04000EDE RID: 3806
		public UIElement Parent;

		// Token: 0x04000EDF RID: 3807
		protected List<UIElement> Elements = new List<UIElement>();

		// Token: 0x04000EE0 RID: 3808
		public StyleDimension Top;

		// Token: 0x04000EE1 RID: 3809
		public StyleDimension Left;

		// Token: 0x04000EE2 RID: 3810
		public StyleDimension Width;

		// Token: 0x04000EE3 RID: 3811
		public StyleDimension Height;

		// Token: 0x04000EE4 RID: 3812
		public StyleDimension MaxWidth = StyleDimension.Fill;

		// Token: 0x04000EE5 RID: 3813
		public StyleDimension MaxHeight = StyleDimension.Fill;

		// Token: 0x04000EE6 RID: 3814
		public StyleDimension MinWidth = StyleDimension.Empty;

		// Token: 0x04000EE7 RID: 3815
		public StyleDimension MinHeight = StyleDimension.Empty;

		// Token: 0x04000EEF RID: 3823
		private bool _isInitialized;

		// Token: 0x04000EF0 RID: 3824
		public bool OverflowHidden;

		// Token: 0x04000EF1 RID: 3825
		public float PaddingTop;

		// Token: 0x04000EF2 RID: 3826
		public float PaddingLeft;

		// Token: 0x04000EF3 RID: 3827
		public float PaddingRight;

		// Token: 0x04000EF4 RID: 3828
		public float PaddingBottom;

		// Token: 0x04000EF5 RID: 3829
		public float MarginTop;

		// Token: 0x04000EF6 RID: 3830
		public float MarginLeft;

		// Token: 0x04000EF7 RID: 3831
		public float MarginRight;

		// Token: 0x04000EF8 RID: 3832
		public float MarginBottom;

		// Token: 0x04000EF9 RID: 3833
		public float HAlign;

		// Token: 0x04000EFA RID: 3834
		public float VAlign;

		// Token: 0x04000EFB RID: 3835
		private CalculatedStyle _innerDimensions;

		// Token: 0x04000EFC RID: 3836
		private CalculatedStyle _dimensions;

		// Token: 0x04000EFD RID: 3837
		private CalculatedStyle _outerDimensions;

		// Token: 0x04000EFE RID: 3838
		private static RasterizerState _overflowHiddenRasterizerState;

		// Token: 0x04000EFF RID: 3839
		protected bool _useImmediateMode;

		// Token: 0x04000F00 RID: 3840
		private SnapPoint _snapPoint;

		// Token: 0x04000F01 RID: 3841
		private bool _isMouseHovering;

		// Token: 0x02000256 RID: 598
		// (Invoke) Token: 0x0600164E RID: 5710
		public delegate void MouseEvent(UIMouseEvent evt, UIElement listeningElement);

		// Token: 0x02000257 RID: 599
		// (Invoke) Token: 0x06001652 RID: 5714
		public delegate void ScrollWheelEvent(UIScrollWheelEvent evt, UIElement listeningElement);
	}
}

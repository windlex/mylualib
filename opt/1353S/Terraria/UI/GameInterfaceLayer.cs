using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameInput;

namespace Terraria.UI
{
	// Token: 0x0200009E RID: 158
	public class GameInterfaceLayer
	{
		// Token: 0x06000B8F RID: 2959 RVA: 0x003CE84C File Offset: 0x003CCA4C
		public GameInterfaceLayer(string name, InterfaceScaleType scaleType)
		{
			this.Name = name;
			this.ScaleType = scaleType;
		}

		// Token: 0x06000B90 RID: 2960 RVA: 0x003CE864 File Offset: 0x003CCA64
		public bool Draw()
		{
			Matrix transformMatrix;
			if (this.ScaleType == InterfaceScaleType.Game)
			{
				PlayerInput.SetZoom_World();
				transformMatrix = Main.GameViewMatrix.ZoomMatrix;
			}
			else if (this.ScaleType == InterfaceScaleType.UI)
			{
				PlayerInput.SetZoom_UI();
				transformMatrix = Main.UIScaleMatrix;
			}
			else
			{
				PlayerInput.SetZoom_Unscaled();
				transformMatrix = Matrix.Identity;
			}
			Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, transformMatrix);
			bool arg_5C_0 = this.DrawSelf();
			Main.spriteBatch.End();
			return arg_5C_0;
		}

		// Token: 0x06000B91 RID: 2961 RVA: 0x003CE8D0 File Offset: 0x003CCAD0
		protected virtual bool DrawSelf()
		{
			return true;
		}

		// Token: 0x04000EAA RID: 3754
		public readonly string Name;

		// Token: 0x04000EAB RID: 3755
		public InterfaceScaleType ScaleType;
	}
}

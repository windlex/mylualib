using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.UI;
using Terraria.UI.Gamepad;
using Terraria.World.Generation;

namespace Terraria.GameContent.UI.States
{
	// Token: 0x02000144 RID: 324
	public class UIWorldLoad : UIState
	{
		// Token: 0x060010DA RID: 4314 RVA: 0x00407B80 File Offset: 0x00405D80
		public UIWorldLoad(GenerationProgress progress)
		{
			this._progressBar.Top.Pixels = 370f;
			this._progressBar.HAlign = 0.5f;
			this._progressBar.VAlign = 0f;
			this._progressBar.Recalculate();
			this._progressMessage.CopyStyle(this._progressBar);
			UIHeader expr_7D_cp_0_cp_0 = this._progressMessage;
			expr_7D_cp_0_cp_0.Top.Pixels = expr_7D_cp_0_cp_0.Top.Pixels - 70f;
			this._progressMessage.Recalculate();
			this._progress = progress;
			base.Append(this._progressBar);
			base.Append(this._progressMessage);
		}

		// Token: 0x060010DB RID: 4315 RVA: 0x00407C40 File Offset: 0x00405E40
		public override void OnActivate()
		{
			if (PlayerInput.UsingGamepadUI)
			{
				UILinkPointNavigator.Points[3000].Unlink();
				UILinkPointNavigator.ChangePoint(3000);
			}
		}

		// Token: 0x060010DC RID: 4316 RVA: 0x00407C68 File Offset: 0x00405E68
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			this._progressBar.SetProgress(this._progress.TotalProgress, this._progress.Value);
			this._progressMessage.Text = this._progress.Message;
			this.UpdateGamepadSquiggle();
		}

		// Token: 0x060010DD RID: 4317 RVA: 0x00407CA8 File Offset: 0x00405EA8
		private void UpdateGamepadSquiggle()
		{
			Vector2 value = new Vector2((float)Math.Cos((double)(Main.GlobalTime * 6.28318548f)), (float)Math.Sin((double)(Main.GlobalTime * 6.28318548f * 2f))) * new Vector2(30f, 15f) + Vector2.UnitY * 20f;
			UILinkPointNavigator.Points[3000].Unlink();
			UILinkPointNavigator.SetPosition(3000, new Vector2((float)Main.screenWidth, (float)Main.screenHeight) / 2f + value);
		}

		// Token: 0x060010DE RID: 4318 RVA: 0x00407D4C File Offset: 0x00405F4C
		public string GetStatusText()
		{
			return string.Format("{0:0.0%} - " + this._progress.Message + " - {1:0.0%}", this._progress.TotalProgress, this._progress.Value);
		}

		// Token: 0x04003194 RID: 12692
		private UIGenProgressBar _progressBar = new UIGenProgressBar();

		// Token: 0x04003195 RID: 12693
		private UIHeader _progressMessage = new UIHeader();

		// Token: 0x04003196 RID: 12694
		private GenerationProgress _progress;
	}
}

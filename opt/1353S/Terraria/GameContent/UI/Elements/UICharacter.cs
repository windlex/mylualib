using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	// Token: 0x0200014B RID: 331
	public class UICharacter : UIElement
	{
		// Token: 0x060010FD RID: 4349 RVA: 0x0040A1F0 File Offset: 0x004083F0
		public UICharacter(Player player)
		{
			this._player = player;
			this.Width.Set(59f, 0f);
			this.Height.Set(58f, 0f);
			this._texture = TextureManager.Load("Images/UI/PlayerBackground");
			this._useImmediateMode = true;
		}

		// Token: 0x060010FE RID: 4350 RVA: 0x0040A24C File Offset: 0x0040844C
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			CalculatedStyle dimensions = base.GetDimensions();
			spriteBatch.Draw(this._texture, dimensions.Position(), Color.White);
			Vector2 value = dimensions.Position() + new Vector2(dimensions.Width * 0.5f - (float)(this._player.width >> 1), dimensions.Height * 0.5f - (float)(this._player.height >> 1));
			Item item = this._player.inventory[this._player.selectedItem];
			this._player.inventory[this._player.selectedItem] = UICharacter._blankItem;
			Main.instance.DrawPlayer(this._player, value + Main.screenPosition, 0f, Vector2.Zero, 0f);
			this._player.inventory[this._player.selectedItem] = item;
		}

		// Token: 0x040031B9 RID: 12729
		private Player _player;

		// Token: 0x040031BA RID: 12730
		private Texture2D _texture;

		// Token: 0x040031BB RID: 12731
		private static Item _blankItem = new Item();
	}
}

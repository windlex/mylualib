using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Terraria.Cinematics
{
	// Token: 0x02000193 RID: 403
	public class CinematicManager
	{
		// Token: 0x06001304 RID: 4868 RVA: 0x00419E30 File Offset: 0x00418030
		public void Update(GameTime gameTime)
		{
			if (this._films.Count > 0)
			{
				if (!this._films[0].IsActive)
				{
					this._films[0].OnBegin();
				}
				if (Main.hasFocus && !Main.gamePaused && !this._films[0].OnUpdate(gameTime))
				{
					this._films[0].OnEnd();
					this._films.RemoveAt(0);
				}
			}
		}

		// Token: 0x06001305 RID: 4869 RVA: 0x00419EB0 File Offset: 0x004180B0
		public void PlayFilm(Film film)
		{
			this._films.Add(film);
		}

		// Token: 0x06001306 RID: 4870 RVA: 0x00419EC0 File Offset: 0x004180C0
		public void StopAll()
		{
		}

		// Token: 0x04003497 RID: 13463
		public static CinematicManager Instance = new CinematicManager();

		// Token: 0x04003498 RID: 13464
		private List<Film> _films = new List<Film>();
	}
}

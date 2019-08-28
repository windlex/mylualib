using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Terraria.Graphics.Effects
{
	// Token: 0x020000F5 RID: 245
	public abstract class EffectManager<T> where T : GameEffect
	{
		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000DEC RID: 3564 RVA: 0x003E6B60 File Offset: 0x003E4D60
		public bool IsLoaded
		{
			get
			{
				return this._isLoaded;
			}
		}

		// Token: 0x1700011F RID: 287
		public T this[string key]
		{
			get
			{
				T result;
				if (this._effects.TryGetValue(key, out result))
				{
					return result;
				}
				return default(T);
			}
			set
			{
				this.Bind(key, value);
			}
		}

		// Token: 0x06000DEF RID: 3567 RVA: 0x003E6B9C File Offset: 0x003E4D9C
		public void Bind(string name, T effect)
		{
			this._effects[name] = effect;
			if (this._isLoaded)
			{
				effect.Load();
			}
		}

		// Token: 0x06000DF0 RID: 3568 RVA: 0x003E6BC0 File Offset: 0x003E4DC0
		public void Load()
		{
			if (this._isLoaded)
			{
				return;
			}
			this._isLoaded = true;
			using (Dictionary<string, T>.ValueCollection.Enumerator enumerator = this._effects.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.Load();
				}
			}
		}

		// Token: 0x06000DF1 RID: 3569 RVA: 0x003E6C2C File Offset: 0x003E4E2C
		public T Activate(string name, Vector2 position = default(Vector2), params object[] args)
		{
			if (!this._effects.ContainsKey(name))
			{
				throw new MissingEffectException(string.Concat(new object[]
				{
					"Unable to find effect named: ",
					name,
					". Type: ",
					typeof(T),
					"."
				}));
			}
			T t = this._effects[name];
			this.OnActivate(t, position);
			t.Activate(position, args);
			return t;
		}

		// Token: 0x06000DF2 RID: 3570 RVA: 0x003E6CA4 File Offset: 0x003E4EA4
		public void Deactivate(string name, params object[] args)
		{
			if (!this._effects.ContainsKey(name))
			{
				throw new MissingEffectException(string.Concat(new object[]
				{
					"Unable to find effect named: ",
					name,
					". Type: ",
					typeof(T),
					"."
				}));
			}
			T t = this._effects[name];
			this.OnDeactivate(t);
			t.Deactivate(args);
		}

		// Token: 0x06000DF3 RID: 3571 RVA: 0x003E6D1C File Offset: 0x003E4F1C
		public virtual void OnActivate(T effect, Vector2 position)
		{
		}

		// Token: 0x06000DF4 RID: 3572 RVA: 0x003E6D20 File Offset: 0x003E4F20
		public virtual void OnDeactivate(T effect)
		{
		}

		// Token: 0x04002F70 RID: 12144
		protected bool _isLoaded;

		// Token: 0x04002F71 RID: 12145
		protected Dictionary<string, T> _effects = new Dictionary<string, T>();
	}
}

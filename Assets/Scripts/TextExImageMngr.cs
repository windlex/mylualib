using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class TextExImageMngr : MonoBehaviour {
	protected static TextExImageMngr Instance;
	public Dictionary<string, Sprite> m_Sprites = new Dictionary<string,Sprite>();
	public List<string> sprNames;
	public List<Sprite> sprs;
	public int spriteCount 
	{
		get { return m_Sprites.Count; }
		private set {}
	}

	public static TextExImageMngr GetInstance()
	{
		return Instance;
	}

	// Use this for initialization
	void Start () {
		if (Instance)
		{
			Debug.LogError("[TextExImageMngr] [Error] [不能有多个TextExImageMngr!!!]");
		}
		Instance = this;
		for (int i = 0; i < sprNames.Count; i++)
		{
			Debug.Log(sprNames[i]);
			Debug.Log(sprs[i]);
			m_Sprites.Add(sprNames[i], sprs[i]);
		}
		LinkImageText.funLoadSprite = (spriteName) =>
		{
			Sprite spr = TextExImageMngr.GetInstance().GetSprite(spriteName);
			if (spr == null)
				spr = Resources.Load<Sprite>(spriteName);
			return spr;
		};
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public Sprite GetSprite(string name)
	{
		Sprite spr;
		m_Sprites.TryGetValue(name, out spr);
		return spr;
	}
	public bool AddSprite(string name, Sprite spr)
	{
		if (m_Sprites.ContainsKey(name))
			return false;
		m_Sprites[name] = spr;
		return true;
	}
}

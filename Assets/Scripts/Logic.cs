using UnityEngine;
using System.Collections;

public class Logic : MonoBehaviour {
    public static Logic Instance {get; private set;}

    public UIScrollItemV cmdList;
    public UIScrollText textList;
    public static XLua.LuaEnv L;

	// Use this for initialization
	void Start () {
        if (Instance == null)
            Destroy(Instance);
        Instance = this;
        if (L == null)
        {
            L = new XLua.LuaEnv();
            L.DoString("require ('Lua.Main')");
        }
	}

    void OnDestroy()
    {
        L.Dispose();
    }

	// Update is called once per frame
	void Update () 
    {
	    if (L != null)
        {
            L.Tick();
        }
	
	}
	void FixedUpdate()
	{

	}
    public void AddCommand(string cmd, UnityEngine.Events.UnityAction onCmd)
    {
        cmdList.AddButton(cmd, onCmd);
    }
    public void AddCommand(string label, string cmd)
    {
        cmdList.AddButton(label, () => L.DoString(string.Format("start({0})", cmd)));
    }
    public void ClearCommand()
    {
        cmdList.Clear();
    }

	public void ClearText()
	{
		textList.SetText("");
	}
    public void AddText(string text)
    {
        textList.AppendText(text);
    }

	public void Wait()
	{

	}
	public void OnClick()
	{
		L.DoString("OnClick()");
	}

    public void test()
    {
        ClearCommand();
		ClearText();
		L.Dispose();
		L = new XLua.LuaEnv();
		L.DoString("require ('Lua.Main')");
	}

}

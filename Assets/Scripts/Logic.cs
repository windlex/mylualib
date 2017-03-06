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
    public void AddCommand(string cmd, UnityEngine.Events.UnityAction onCmd)
    {
        cmdList.AddButton(cmd, onCmd);
    }
    public void ClearCommand()
    {
        cmdList.Clear();
    }
    public void AddText(string text)
    {
        textList.AppendText(text);
    }

    public void test()
    {
        Logic.Instance.AddCommand("1", () => Logic.Instance.AddText("OnClick 1\n"));
        Logic.Instance.AddText("1\n");
        Logic.Instance.AddCommand("2", () => Logic.Instance.AddText("OnClick 2\n"));
        Logic.Instance.AddText("2\n");
        Logic.Instance.AddCommand("3", () => Logic.Instance.AddText("OnClick 3\n"));
        Logic.Instance.AddText("3\n");
    }

}

﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Logic : MonoBehaviour {
    public static Logic Instance {get; private set;}

    public UIScrollItemV cmdList;
    public UIScrollText textList;
	public UIScrollItemV selectList;
	public UIScrollText	textInfo;
	public UIScrollText textInv;
	public UIScrollText textStatus;
	public UIScrollText	textLog;
	public UIScrollText textMap;
	public GameObject uiStory;
	public GameObject uiCombat;
	
    public static XLua.LuaEnv L;

	// Use this for initialization
	void Start () {
        if (Instance == null)
            Destroy(Instance);
        Instance = this;
        if (L == null)
        {
            L = new XLua.LuaEnv();
            L.DoString("require ('Main')");
			L.DoString("OnStart()");
		}
		ECSUtils.Setup ();


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
		L.DoString("OnUpdate()");
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
		if (selectList)
			selectList.Clear();
	}
	public void AddSelect(string cmd, UnityEngine.Events.UnityAction onCmd)
	{
		selectList.gameObject.SetActive(true);
		selectList.AddButton(cmd, onCmd);
	}
	public void AddSelect(string label, string cmd)
	{
		selectList.gameObject.SetActive(true);
		selectList.AddButton(label, () => L.DoString(string.Format("start({0})", cmd)));
	}

	public void ClearText()
	{
		textList.Clear();
	}
    public void AddText(string text)
    {
        textList.AppendText(text);
    }

	UIScrollText Name2Pad(string pad)
	{
		if (pad == "textInfo") return textInfo;
		else if (pad == "textInv") return textInv;
		else if (pad == "textStatus") return textStatus;
		else if (pad == "textLog") return textLog;
		else if (pad == "textMap") return textMap;
		return null;
	}
	public void AddTextEx(string pad, string text)
	{
		UIScrollText txtPanel = Name2Pad(pad);
		if (!txtPanel)
			return;
		txtPanel.AppendText(text);
	}
	public void ClearEx(string pad)
	{
		UIScrollText txtPanel = Name2Pad(pad);
		if (!txtPanel)
			return;
		txtPanel.Clear();
	}
	public void Wait()
	{

	}
	public void OnClick()
	{
		L.DoString("OnClick()");
	}

	public void OnHrefEvent(string str)
	{
		Debug.Log("OnHrefEvent: " + str);
		L.DoString(string.Format("start({0})", str));
	}
    public void test()
    {
		Manager.Instance.RemoveAllDaemon ();
        ClearCommand();
		ClearText();
		selectList.Clear();
		L.GC();
		L.Dispose();
		L = new XLua.LuaEnv();
		L.DoString("require ('Main')");
		L.DoString("OnStart()");
	}
}

public class TimerItem
{
	///
	/// 当前时间
	///
	public float currentTime;
	///
	/// 延迟时间
	///
	public float delayTime;
	///
	/// 回调函数
	///
	public Action callback;
	public TimerItem(float time, float delayTime, Action callback)
	{
		this.currentTime = time;
		this.delayTime = delayTime;
		this.callback = callback;
	}
	public void Run(float time)
	{
		// 计算差值
		float offsetTime = time - this.currentTime;
		// 如果差值大等于延迟时间
		if (offsetTime >= this.delayTime)
		{
			float count = offsetTime / this.delayTime - 1;
			float mod = offsetTime % this.delayTime;
			for (int index = 0; index < count; index++)
			{
				this.callback();
			}
			this.currentTime = time - mod;
		}
	}
}
///
/// 移动管理
///
public class TimerManager
{
	public static float time;
	public static Dictionary<object, TimerItem> timerList = new Dictionary<object, TimerItem>();
	public static void Run()
	{
		// 设置时间值
		TimerManager.time = Time.time;
		TimerItem[] objectList = new TimerItem[timerList.Values.Count];
		timerList.Values.CopyTo(objectList, 0);
		// 锁定
		foreach(TimerItem timerItem in objectList)
		{
			if(timerItem != null) 
				timerItem.Run(TimerManager.time);
		}
	}
	public static void Register(object objectItem, float delayTime, Action callback)
	{
		if(!timerList.ContainsKey(objectItem))
		{
			TimerItem timerItem = new TimerItem(TimerManager.time, delayTime, callback);
			timerList.Add(objectItem, timerItem);
		}
	}
	public static void UnRegister(object objectItem)
	{
		if(timerList.ContainsKey(objectItem))
		{
			timerList.Remove(objectItem);
		}
	}
}

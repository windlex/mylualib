using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameMgr : SingletonMono<GameMgr>
{
	public GameObject Player;
}

public class MyUtils
{
	public static string Convert(string code, string str)
	{
		Debug.Log("Convert " + str + " from " + code + " to utf8");
		Encoding utf8;
		Encoding gb2312;
		utf8 = Encoding.GetEncoding("UTF-8");
		gb2312 = Encoding.GetEncoding("GBK");
		byte[] gb = gb2312.GetBytes(str);
		gb = Encoding.Convert(gb2312, utf8, gb);
		Debug.Log(gb);
		string strout = utf8.GetString(gb); 
		Debug.Log(strout);
		return strout;
		//Debug.Log("Convert " + str + " from " + code + " to utf8");
		//Debug.Log(Encoding.GetEncoding("GBK").GetBytes(str));
		//Debug.Log(Encoding.UTF8.GetString(Encoding.GetEncoding("GBK").GetBytes(str)));
		//return Encoding.UTF8.GetString(Encoding.GetEncoding("GBK").GetBytes(str));
	}
}
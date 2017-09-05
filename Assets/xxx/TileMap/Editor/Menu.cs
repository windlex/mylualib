using UnityEngine;
using UnityEditor;

public class MyMenu {
	[MenuItem("R/test world")]
	public static void TestWorld()
	{
		TileMap.Instance.EnterWorld("main", 100, 100);
	}
}
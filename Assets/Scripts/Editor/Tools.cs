using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

public class Tools {

	public static Unity3dEditor e;
	[MenuItem("Tools/Unity3dEditor")]
	public static void OpenUnity3dEditor()
	{
		if (e == null)
			e = EditorWindow.GetWindow<Unity3dEditor>("Unity3dEditor");
		e.Show();
	}


	//[CustomEditor(typeof(AssetBundle), true)]
	public class Unity3dInspe : Editor
	{
		public void OnGUI()
		{
			GUI.Label(new Rect(0,0,100,100), "IN Bigtitle");
		}
	}
	//[CustomEditor(typeof(DefaultAsset), true)]
	public class MeshInspe : Editor
	{
		public void OnGUI()
		{
			GUI.Label(new Rect(0, 0, 100, 100), "IN Bigtitle");
		}
	}

}

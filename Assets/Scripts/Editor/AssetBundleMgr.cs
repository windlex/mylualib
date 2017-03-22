using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class AssetBundleMgr {

}

public class Unity3dEditor : EditorWindow
{
	public static Object sel = null;
	public static Dictionary<string, AssetBundle> abs = new Dictionary<string, AssetBundle>();
	private void OnSelectionChange()
	{
		foreach (string s in Selection.assetGUIDs)
		{
			Debug.Log("[Asset]" + s);
		}
		Object[] ss = Selection.GetFiltered(typeof(Object), SelectionMode.Assets);
		foreach (Object o in ss)
		{
			Debug.Log(o.GetType());
		}
		Object oo = ss[0];
		if (oo is DefaultAsset)
		{
			tryLoadAB(oo);
		}
	}
	public void tryLoadAB(Object oo)
	{
		AssetBundle ab = null;
		try
		{
			string path = AssetDatabase.GetAssetPath(oo);
			Debug.Log("Selected..." + path);
			string guid = AssetDatabase.AssetPathToGUID(path);
			if (abs.TryGetValue(guid, out ab))
				return;
			Debug.Log("Loading..." + path);
			ab = AssetBundle.LoadFromFile(path);
			abs.Add(guid, ab);
			Debug.Log("Loaded..." + path);
		}
		catch (System.Exception e)
		{
			if (ab != null)
				ab.Unload(true);
			Debug.LogError(e);
		}
	}
	public static AssetBundle GetAB(string guid)
	{
		AssetBundle ab = null;
		if (abs.TryGetValue(guid, out ab))
			return ab;
		return null;
	}

	private static void DrawAssetBundle(AssetBundle ab)
	{
		if (ab == null)
		{
			Debug.LogError("Draw Null");
		}
		Debug.Log("DrawAsset:"+ab.ToString());
		GUIStyle wrappedLabel = new GUIStyle("label")
		{
			fixedHeight = 0,
			wordWrap = true
		};
		GUILayout.BeginVertical();
		string[] files = ab.GetAllAssetNames();
		foreach (string f in files)
		{
			GUILayout.Label(f, wrappedLabel);
		}
		Object[] os = ab.LoadAllAssets();
		foreach (Object go in os)
		{
			GUILayout.Label(go.ToString() + "@" + AssetDatabase.GetAssetPath(go), wrappedLabel);
		}
		GUILayout.EndVertical();
	}
	public void OnGUI()
	{
		GUILayout.BeginVertical(EditorStyles.toolbar);
		if (GUILayout.Button("Lock", EditorStyles.toolbarButton, GUILayout.Width(50)))
		{
			Debug.Log("Lock");
		}
		GUILayout.EndVertical();

		//EditorGUILayout.BeginHorizontal();
		GUILayout.BeginVertical("IN Bigtitle");
		//foreach (var res in abs)
		{
			//GUILayout.BeginArea(position, GUIContent.none, "OL box");
			string guid = Selection.assetGUIDs[0];
			AssetBundle ab = GetAB(guid);
			if (ab != null)
				DrawAssetBundle(ab);
			//GUILayout.EndArea();
		}
		GUILayout.EndVertical();
	}
}

public class testAsset
{
	public static AssetBundle ab;
	[MenuItem("Tools/hackAB")]
	public static void hackAB()
	{
		if (ab != null)
			releaseAB();
		string str = EditorUtility.OpenFilePanel("open", "/", "");
		try
		{
			ab = AssetBundle.LoadFromFile(str);
			Debug.LogError(ab.GetAllAssetNames());
			Object[] os = ab.LoadAllAssets();
			foreach (Object go in os)
			{
				Debug.Log(go);
				if (go is GameObject)
				{
					GameObject m = GameObject.Instantiate(go, null) as GameObject;
					m.name += "_x";
					PrefabUtility.CreatePrefab("Assets/00/" + m.name + ".prefab", m);
				}
				else if (go is Material)
				{
					Material m = new Material(go as Material);
					m.name += "_x";
					AssetDatabase.CreateAsset(m, "Assets/" + m.name + ".mat");
				}
				else if (go is AnimationClip)
				{
					AnimationClip m = go as AnimationClip;
					m.name += "_x";
					AssetDatabase.AddObjectToAsset(m, "Assets/" + m.name + ".anim");
				}
			}
		}
		catch (System.Exception e)
		{
			if (ab != null)
				releaseAB();
			Debug.LogError(e.ToString());
		}
	}
	[MenuItem("Tools/release AB")]
	public static void releaseAB()
    {
		Debug.Log("Try Release AB : " + Selection.assetGUIDs[0]);
        string path = AssetDatabase.GUIDToAssetPath(Selection.assetGUIDs[0]);
		Debug.Log("path = " + path);
		//AssetDatabase
    }
	[MenuItem("Tools/testCreateAsset")]
	public static void testCreateAsset()
	{
		Material m = new Material(Shader.Find("Specular"));
		AssetDatabase.CreateAsset(m, "Assets/new.mat");
	}
	[MenuItem("AssetTools/Copy")]
	public static void copyAsset()
	{
		string guid = Selection.assetGUIDs[0];
		Debug.Log("guid=" + guid);
		AssetBundle ab = Unity3dEditor.GetAB(guid);
		if (ab == null)
		{
			Debug.Log("No AB");
			return;
		}

		Object[] os = ab.LoadAllAssets();
		foreach (Object go in os)
		{
			Debug.Log(go);
			Debug.Log(go.name+" is "+go.GetType());
			if (go is GameObject)
			{
				GameObject m = GameObject.Instantiate(go, null) as GameObject;
				m.name += "_x";
				PrefabUtility.CreatePrefab("Assets/00/" + m.name + ".prefab", m);
			}
			else if (go is Material)
			{
				Material m = new Material(go as Material);
				m.name += "_x";
				AssetDatabase.CreateAsset(m, "Assets/" + m.name + ".mat");
			}
			else if (go is AnimationClip)
			{
				AnimationClip m = Object.Instantiate(go) as AnimationClip;
				m.name += "_x";
				AssetDatabase.AddObjectToAsset(m, "Assets/" + m.name + ".anim");
			}
			else if (go is TextAsset)
			{
				TextAsset m = Object.Instantiate(go) as TextAsset;
				m.name += "_x";
				AssetDatabase.CreateAsset(m, "Assets/" + m.name + ".txt");
			}
		}
	}
}

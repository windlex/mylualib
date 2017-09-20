using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using System.Linq;
public class MyMenu {

	[MenuItem("Atlas/AtlasMaker")]
	static private void MakeAtlas()
	{
		string spriteDir = Application.dataPath + "/Resources/Sprite";

		if (!Directory.Exists(spriteDir))
		{
			Directory.CreateDirectory(spriteDir);
		}

		DirectoryInfo rootDirInfo = new DirectoryInfo(Application.dataPath + "/Atlas");
		foreach (DirectoryInfo dirInfo in rootDirInfo.GetDirectories())
		{
			foreach (FileInfo pngFile in dirInfo.GetFiles("*.png", SearchOption.AllDirectories))
			{
				string allPath = pngFile.FullName;
				string assetPath = allPath.Substring(allPath.IndexOf("Assets"));
				Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
				GameObject go = new GameObject(sprite.name);
				go.AddComponent<SpriteRenderer>().sprite = sprite;
				allPath = spriteDir + "/" + sprite.name + ".prefab";
				string prefabPath = allPath.Substring(allPath.IndexOf("Assets"));
				PrefabUtility.CreatePrefab(prefabPath, go);
				GameObject.DestroyImmediate(go);
			}
		}
	}

	[MenuItem("R/test world")]
	public static void TestWorld()
	{
		World home = World.Create("home");
		home.GenerateWorld();
		TileMap.Instance.EnterWorld("main", 100, 100);
	}

	[MenuItem("R/CreateAutoTileset")]
	public static void CreateTileset()
	{
		CreateAssetInSelectedDirectory<Tileset>();
	}
	public static T CreateAssetInSelectedDirectory<T>() where T : ScriptableObject
	{
		T asset = ScriptableObject.CreateInstance<T>();

		string path = AssetDatabase.GetAssetPath(Selection.activeObject);
		if (path == "")
			path = "Assets";
		else if (Path.GetExtension(path) != "")
			path = path.Replace(Path.GetFileName(path), "");

		string objName = typeof(T).ToString();
		string objExt = Path.GetExtension(objName);
		if (!string.IsNullOrEmpty(objExt))
			objName = objExt.Remove(0, 1);
		string assetPathAddName = AssetDatabase.GenerateUniqueAssetPath(path + "/New " + objName + ".asset");

		AssetDatabase.CreateAsset(asset, assetPathAddName);

		AssetDatabase.SaveAssets();
		Selection.activeObject = asset;
		AssetDatabase.Refresh();
		EditorUtility.FocusProjectWindow();
		return asset;
	}
}
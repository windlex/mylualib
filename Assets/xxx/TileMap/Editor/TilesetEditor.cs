using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Linq;

[CustomEditor(typeof(Tilesets))]
public class TilesetEditor : Editor
{
	public Tilesets creator;
	static bool showGeneralWorldSettings = false;
	private void OnEnable()
	{

		//get script Reference
		creator = (Tilesets)target;

		//SceneView.onSceneGUIDelegate = GridUpdate;

		//LoadResources();

		//get all available masks
		//TileWorldMaskLookup.GetMasks(out creator.iMasks, out _maskNames);

		//currentScene = EditorApplication.currentScene;
		//EditorApplication.hierarchyWindowChanged += HierarchyWindowChanged;
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		//SHOW SETTINGS
		//-------------
		GUILayout.BeginHorizontal("Box");

		showGeneralWorldSettings = GUILayout.Toggle(showGeneralWorldSettings, ("Settings"),
			GUI.skin.GetStyle("foldout"), GUILayout.ExpandWidth(true), GUILayout.Height(18));

		if (GUILayout.Button("ToolbarButton", GUILayout.Width(25)))
		{
			TilesetEditWindow.Show();
		}

		GUILayout.EndHorizontal();

		if (showGeneralWorldSettings)
		{
			ShowSettings();
		}
	}

	    //SHOW SETTUNGS
    //-----------------
    public void ShowSettings()
    {
		//SETTINGS
		//--------
		GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true));
		GUILayout.EndVertical();
	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

public class TilesetEditWindow : EditorWindow
{
	bool m_bShowGround = false;
	bool m_bShowRoad = false;
	public Vector2 scrollPosition;
	[MenuItem("R/TilesetEditor")]
	public static void Show()
	{
		TilesetEditWindow wnd = (TilesetEditWindow)EditorWindow.GetWindow(typeof(TilesetEditWindow));
	}
	void OnGUI()
	{
		GUILayout.Label("Tileset Configuration", EditorStyles.boldLabel);
		if (GUILayout.Button("Ground", GUILayout.Height(25)))
			m_bShowGround = !m_bShowGround;
		if (m_bShowGround)
		{
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Height(300));
			GUI.backgroundColor = Color.gray;
			GUILayout.Space(20);
			EditorGUILayout.BeginVertical(GUILayout.MinWidth(300));
			GUILayout.Label("Ground Configuration", EditorStyles.boldLabel);
			EditorGUILayout.EndVertical();
			GUILayout.EndScrollView();

		}
		GUI.backgroundColor = Color.white;
		if (GUILayout.Button("Road", GUILayout.Height(25)))
			m_bShowRoad = !m_bShowRoad;
		if (m_bShowRoad) {
			GUILayout.Label("Road Configuration", EditorStyles.boldLabel);
		}

	}
}
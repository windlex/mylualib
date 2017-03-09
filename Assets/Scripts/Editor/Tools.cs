using UnityEngine;
using System.Collections;
using UnityEditor;

public class Tools {
    public static AssetBundle ab;
    [MenuItem("Tools/hackAB")]
    public static void hackAB()
    {
        if (ab != null)
            releaseAB();
        string str = EditorUtility.OpenFilePanel("open", "", "");
        try
        {
            ab = AssetBundle.LoadFromFile(str);
            Object[] os = ab.LoadAllAssets();
            foreach (Object go in os)
            {
                Debug.Log(go);
                if (go is GameObject)
                {
                    GameObject.Instantiate(go, null);
                    AssetDatabase.CreateAsset(go, "Assets/" + go.name + ".asset");
                }
                else if (go is Material)
                {
                    Material m = go as Material;
                    AssetDatabase.CreateAsset(go, "Assets/" + m.name + ".mat");
                }
                else if (go is AnimationClip)
                {
                    AnimationClip m = go as AnimationClip;
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
        if (ab != null)
        {
            ab.Unload(true);
        }
    }
}

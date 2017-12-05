using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSMesh : MonoBehaviour {

	Mesh	mesh;
	// Use this for initialization
	void Start () {
		mesh = new Mesh ();
		List<Vector3> vb = new List<Vector3> ();
		mesh.SetVertices (vb);
		List<Vector2> uv = new List<Vector2> ();
		mesh.SetUVs (channel, uv);
		int[] triangle;
		mesh.SetTriangles(triangle, submesh);

		//https://docs.unity3d.com/ScriptReference/Mesh-bindposes.html
		// Build basic mesh
		Mesh mesh = new Mesh();
		mesh.vertices = new Vector3[] { new Vector3(-1, 0, 0), new Vector3(1, 0, 0), new Vector3(-1, 5, 0), new Vector3(1, 5, 0) };
		mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1) };
		mesh.triangles = new int[] { 0, 1, 2, 1, 3, 2 };
		mesh.RecalculateNormals();
		rend.material = new Material(Shader.Find("Diffuse"));


		//http://blog.csdn.net/yupu56/article/details/45077217
		//https://www.cnblogs.com/123ing/p/3912099.html
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

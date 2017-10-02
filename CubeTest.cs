using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTest : MonoBehaviour {

  public Texture tex;

	// Use this for initialization
	void Start () {
    Mesh m = new Mesh();
    m.name = "ScriptedMesh";

    m.vertices = new Vector3[] {
         new Vector3(0, 1, 0),
         new Vector3(1, 1, 0),
         new Vector3(1, 0, 0),
         new Vector3(0, 0, 0)
     };

    m.uv = new Vector2[] {
         new Vector2 (0, 1),
         new Vector2 (1, 1),
         new Vector2(1, 0),
         new Vector2 (0, 0)
     };
    m.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
    m.RecalculateNormals();

    GameObject plane = new GameObject("Plane");
    MeshFilter meshFilter = (MeshFilter)plane.AddComponent(typeof(MeshFilter));
    meshFilter.mesh = m;
    MeshRenderer renderer = plane.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
    renderer.material.shader = Shader.Find("Unlit/Texture");
    renderer.material.mainTexture = tex;
  }
	
	// Update is called once per frame
	void Update () {
		
	}
}

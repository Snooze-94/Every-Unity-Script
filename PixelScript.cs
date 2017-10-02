using UnityEngine;
using System.Collections;

public class PixelScript : MonoBehaviour {
	
	public RenderTexture ren;
	public GameObject renderingPlane;

	void Start () {
		float height = 9;
		float width = 16;
		renderingPlane.transform.localScale = new Vector3 (width, 0.1f, height);
		ren.width = 200;
		ren.height = 135;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

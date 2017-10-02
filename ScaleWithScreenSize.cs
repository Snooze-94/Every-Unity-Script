using UnityEngine;
using System.Collections;

public class ScaleWithScreenSize : MonoBehaviour {

	public Camera cam;

	void Start () {
		
		float height = cam.orthographicSize * 2.0f;
		float width = height * Screen.width / Screen.height;
		transform.localScale = new Vector3 (width / 10, 0.1f, height / 10);
	
	}
}

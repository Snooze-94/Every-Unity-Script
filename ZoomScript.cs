using UnityEngine;
using System.Collections;

public class ZoomScript : MonoBehaviour {

	public float normalFOV;
	public float zoomedFOV;
	public float zoomSpeed;
	float currentFOV;
	float targetFOV;

	void Start () {
	
	}

	void Update () {
		if (Input.GetMouseButton (1)) {
			targetFOV = zoomedFOV;
		} else {
			targetFOV = normalFOV;
		}
		currentFOV = Camera.main.fieldOfView;
		float fov = Mathf.SmoothDamp (currentFOV, targetFOV, ref zoomSpeed, Time.fixedDeltaTime * 10);

		Camera.main.fieldOfView = fov;


	}
}

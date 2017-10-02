using UnityEngine;
using System.Collections;

public class CameraFOV : MonoBehaviour {


	public float zoomFOV;
	public float normalFOV;
	public float smoothTime;
	float zoomSmoothing;
	float targetFOV;
	public GameObject renderingPlane;
	public Camera mainCam;


	void Start () {
		targetFOV = normalFOV;


	}

	void Update () {
		
		if(Input.GetMouseButtonDown(1))
        {
			targetFOV = zoomFOV;

		}
        else if(Input.GetMouseButtonUp(1))
        {
			targetFOV = normalFOV;

		}

			
	}

	void FixedUpdate(){

		if (!FirstPersonController.onInventory) {
			float newFOV = Mathf.SmoothDamp (GetComponent<Camera> ().fieldOfView, targetFOV, ref zoomSmoothing, .2f);
			GetComponent<Camera> ().fieldOfView = newFOV;
		} else {
			GetComponent<Camera> ().fieldOfView = normalFOV;
		}

	}
}

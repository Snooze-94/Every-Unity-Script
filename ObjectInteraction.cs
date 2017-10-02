using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour {

	GameObject mainCamera;

	public GameObject testObject;
	public GameObject crosshair;
	public Sprite[] crosshairSprites;
	bool lookingAtObj = false;
	Pickupable pickUpScript;

	[HideInInspector]
	CameraMovement cameraScript;
	public GameObject carriedObject;
	public Vector3 fwd;
	public bool carryingObject = false;

	void Start () {
		mainCamera = GameObject.FindWithTag ("MainCamera");
		cameraScript = mainCamera.GetComponent<CameraMovement>();
	}

	void Update () {
		fwd = Vector3.forward;
	}

	void OnTriggerStay(Collider other){
		Pickupable p = other.GetComponent<Pickupable>();
		if(p != null && !carryingObject){
			pickUpScript = p;
			crosshair.GetComponent<Image>().sprite = crosshairSprites[1];
			if(Input.GetButtonDown("Fire2")){
				carryingObject = true;
				carriedObject = other.gameObject;
				pickUpScript.pickedUp = true;
			}
			if(Input.GetButtonDown("Fire1")){
				pickUpScript.thrown = true;
			}
		}else {
			crosshair.GetComponent<Image>().sprite = crosshairSprites[0];
		}
	}

	void OnTriggerExit(Collider other){
		Pickupable p = other.GetComponent<Pickupable>();
		if(p == pickUpScript) crosshair.GetComponent<Image>().sprite = crosshairSprites[0];
	}

}

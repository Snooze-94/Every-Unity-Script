using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Grabable : MonoBehaviour {

	Vector3 velocity;
	public string objectName = null;
	public bool canBeGrabbed = false;
	public bool grabbed = false;

	void Start () {

	
	}


	void Update () {

		if(Input.GetMouseButtonDown(0) && canBeGrabbed && !FirstPersonController.isPaused && !grabbed){
			grabbed = true;
			gameObject.GetComponent<Rigidbody> ().useGravity = false;
			gameObject.GetComponent<Rigidbody> ().mass = 0;
			gameObject.GetComponent<Rigidbody> ().freezeRotation = true;
			GameObject.FindGameObjectWithTag ("Crosshair").GetComponent<RawImage>().color = Color.clear;
			GrabTriggerScript.isGrabbingObject = true;
		} else if (grabbed && Input.GetMouseButtonUp(0) && !FirstPersonController.isPaused){
			grabbed = false;
			gameObject.GetComponent<Rigidbody> ().useGravity = true;
			gameObject.GetComponent<Rigidbody> ().mass = 1;
			gameObject.GetComponent<Rigidbody> ().freezeRotation = false;
			GameObject.FindGameObjectWithTag ("Crosshair").GetComponent<RawImage>().color = Color.white;
			GrabTriggerScript.isGrabbingObject = false;

		}

		//Uncomment for throw.

		/*if(grabbed && !FirstPersonController.isPaused){
			if(Input.GetMouseButtonDown(1)){
				gameObject.GetComponent<Rigidbody> ().useGravity = true;
				gameObject.GetComponent<Rigidbody> ().mass = 1;
				gameObject.GetComponent<Rigidbody> ().freezeRotation = false;
				GameObject.FindGameObjectWithTag ("Crosshair").GetComponent<RawImage>().color = Color.white;
				grabbed = false;
				GetComponent<Rigidbody> ().velocity = Vector3.zero;
				gameObject.GetComponent<Rigidbody> ().AddForce (Camera.main.transform.forward * 500f);
				GrabTriggerScript.isGrabbingObject = false;
			}
		}*/

	}



	void FixedUpdate(){
		if(grabbed){
			Vector3 moveAmount = Vector3.SmoothDamp (transform.position, GameObject.FindGameObjectWithTag ("Grab Position").transform.position, ref velocity, .05f) + (GameObject.FindGameObjectWithTag("Player").transform.TransformDirection(GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().moveAmount) * Time.fixedDeltaTime);
			transform.position = moveAmount;


		}
	}

	void OnCollisionStay(Collision col){
		if(col.gameObject.layer == LayerMask.NameToLayer("Ground") && grabbed && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag ("Grab Position").transform.position) > 0.4f){
			gameObject.GetComponent<Rigidbody> ().useGravity = true;
			gameObject.GetComponent<Rigidbody> ().mass = 1;
			gameObject.GetComponent<Rigidbody> ().freezeRotation = false;
			GameObject.FindGameObjectWithTag ("Crosshair").GetComponent<RawImage>().color = Color.white;
			grabbed = false;
			GrabTriggerScript.isGrabbingObject = false;
		}

		if(grabbed && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag ("Grab Position").transform.position) > 1.5f){
			gameObject.GetComponent<Rigidbody> ().useGravity = true;
			gameObject.GetComponent<Rigidbody> ().mass = 1;
			gameObject.GetComponent<Rigidbody> ().freezeRotation = false;
			GameObject.FindGameObjectWithTag ("Crosshair").GetComponent<RawImage>().color = Color.white;
			grabbed = false;
			GrabTriggerScript.isGrabbingObject = false;
		}

		if(grabbed && col.gameObject.tag == "Player"){
			gameObject.GetComponent<Rigidbody> ().useGravity = true;
			gameObject.GetComponent<Rigidbody> ().mass = 1;
			gameObject.GetComponent<Rigidbody> ().freezeRotation = false;
			GameObject.FindGameObjectWithTag ("Crosshair").GetComponent<RawImage>().color = Color.white;
			grabbed = false;
			GrabTriggerScript.isGrabbingObject = false;
		}
	}

}

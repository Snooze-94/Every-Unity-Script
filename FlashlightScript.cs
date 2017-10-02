using UnityEngine;
using System.Collections;

public class FlashlightScript : MonoBehaviour {


	void Start () {
	
	}
	
	void Update () {
	
		if(Input.GetKeyUp(KeyCode.F) && !FirstPersonController.isPaused){

			GetComponent<AudioSource> ().PlayOneShot (Resources.Load ("Audio/flashlight/up") as AudioClip);

			if (GetComponent<Light> ().intensity > 0){
				GetComponent<Light> ().intensity = 0f;
			} else {
				GetComponent<Light> ().intensity = 2f;
			}
				
		}

		if(Input.GetKeyDown(KeyCode.F) && !FirstPersonController.isPaused){
			GetComponent<AudioSource> ().PlayOneShot (Resources.Load ("Audio/flashlight/down") as AudioClip);
		}
	}
}

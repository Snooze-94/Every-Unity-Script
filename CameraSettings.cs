using UnityEngine;
using System.Collections;

public class CameraSettings : MonoBehaviour {

	static public bool letterBoxIsEnabled;
	public GameObject letterBox;

	void Start () {
		
	}
	

	void Update () {
		if (Input.GetButtonDown ("Action")) {
			letterBoxIsEnabled = !letterBoxIsEnabled;
		}
		if (letterBoxIsEnabled) {
			letterBox.SetActive (false);
		} else {
			letterBox.SetActive(true);
		}
	}
}

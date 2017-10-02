using UnityEngine;
using System.Collections;

public class PixelPerfect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake () {
		var modificatoreSchermo = 1f;
		var lastTargetResolutionHeight = Screen.height;
		var currentPixelsToUnits = 32;
		if (lastTargetResolutionHeight < 590){
			modificatoreSchermo = 1f;
		}
		if (lastTargetResolutionHeight >= 590 && lastTargetResolutionHeight <= 1080) {
			modificatoreSchermo = 2f;
		}
		if (lastTargetResolutionHeight >= 1080) {
			modificatoreSchermo = 3f;
		}
		Camera.main.orthographicSize = (1.0f*lastTargetResolutionHeight)/2/currentPixelsToUnits/modificatoreSchermo;
	}
}

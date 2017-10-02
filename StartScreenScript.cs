using UnityEngine;
using System.Collections;

public class StartScreenScript : MonoBehaviour {

	static bool sawOnce = false;

	// Use this for initialization
	void Start () {
		if(!sawOnce) {
			GetComponent<SpriteRenderer>().enabled = true;
			Time.timeScale = 0;
		}

		sawOnce = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale==0 && (Input.GetTouch(0).phase == TouchPhase.Began) ) {
			Time.timeScale = 1;
			GetComponent<SpriteRenderer>().enabled = false;

		}
	}
}

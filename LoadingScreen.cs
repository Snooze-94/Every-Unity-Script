using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

	public string levelToLoad;

	void Start () {
	
	}



	void Update () {
	
		if (Input.GetKeyDown ("space")) {
			Application.LoadLevel(levelToLoad);
		}

	}
}

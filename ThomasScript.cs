using UnityEngine;
using System.Collections;

public class ThomasScript : MonoBehaviour {

	public GameObject pokeballs;

	void Update () {

		if(Input.GetKeyDown(KeyCode.F)){
			pokeballs.SetActive (true);
		}


	}
}

using UnityEngine;
using System.Collections;

public class PokeballForce : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().AddForce (new Vector3 (500f, 0f, 0f));
	}
	

}

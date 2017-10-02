using UnityEngine;
using System.Collections;

public class SombraTrigger : MonoBehaviour {

    public GameObject sombra;

	void Start () {
	
	}
	

	void OnTriggerEnter () {
		GetComponent<BoxCollider> ().enabled = false;
		sombra.GetComponent<Animator> ().SetTrigger ("triggered");
		sombra.GetComponent<AudioSource> ().Play ();
	}
}

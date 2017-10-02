using UnityEngine;
using System.Collections;

public class highnoon : MonoBehaviour {


	void Start () {
	
	}
	

	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<AudioSource>().Play();
    }
}

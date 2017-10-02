using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3Script : MonoBehaviour {
	
	float rotation = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (Vector3.up);
	}
}

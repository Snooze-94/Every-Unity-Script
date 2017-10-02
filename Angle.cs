using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Collider2D))]
public class Angle : MonoBehaviour {

    public static float speed = 5f;

  Controller2D controller;

	void Start () {

    controller = GetComponent<Controller2D>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

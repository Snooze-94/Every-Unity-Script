using UnityEngine;
using System.Collections;

public class BGMover : MonoBehaviour {

	public GameObject player;
	bool moving = true;


	void FixedUpdate () {
		if (player.GetComponent<DiCaprioMovement>().dead){
			moving = false;
		}

		if (moving){
			transform.position += new Vector3 (0.02f, 0, 0);

	}
}
}
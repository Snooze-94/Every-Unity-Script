using UnityEngine;
using System.Collections;

public class FocusScript : MonoBehaviour {

	Vector3 smoothMoveVelocity;
	Vector3 moveAmount;

	void FixedUpdate () {
		if (GameObject.Find ("Player2") != null && GameObject.Find ("Player") != null) {
			moveAmount = Vector3.Lerp (GameObject.Find ("Player").transform.position, GameObject.Find ("Player2").transform.position, 0.5f);
		} else if(GameObject.Find("Player") == null){
			moveAmount = GameObject.Find ("Player2").transform.position;
		} else if(GameObject.Find("Player2") == null){
			moveAmount = GameObject.Find ("Player").transform.position;
		} else if(GameObject.Find("Player2") == null && GameObject.Find("Player") == null){
			moveAmount = new Vector3 (0, 7.7f, -2.6f);
		}

		Vector3 localMove = Vector3.SmoothDamp (transform.position, moveAmount, ref smoothMoveVelocity, Time.fixedDeltaTime * 30f);
		GetComponent<Rigidbody> ().MovePosition (localMove);
	
	}

}

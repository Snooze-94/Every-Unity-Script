using UnityEngine;
using System.Collections;

public class TriggerThomas : MonoBehaviour {

	Vector3 velocity;

	void Start () {
	
	}

	void Update () {

		if (GetComponent<MeshRenderer> ().isVisible) {
		} else {
			Vector3 moveAmount = Vector3.SmoothDamp (transform.position, GameObject.FindGameObjectWithTag ("Player").transform.position, ref velocity, 5f);
			transform.position = moveAmount;
		}

	}
}

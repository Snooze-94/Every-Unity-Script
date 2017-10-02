using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {

	void Update () {

		Vector3 lookpos = GameObject.FindGameObjectWithTag ("Player").transform.position - transform.position;
		lookpos.y = 0;
		Quaternion rotation = Quaternion.LookRotation (lookpos);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * 1f);

	}
}

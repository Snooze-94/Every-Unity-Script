using UnityEngine;
using System.Collections;

public class AttackController : MonoBehaviour {


	void Start () {

	}
	

	void Update () {


		Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint (transform.position);
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle + 90, Vector3.forward);

		Vector3 rayOrigin = transform.position;
		Debug.DrawRay(rayOrigin,dir * 5, Color.red);


	
	}
}

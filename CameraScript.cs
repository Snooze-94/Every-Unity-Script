using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Transform focus;
	public Transform normalPos;
	public Transform closePos;
	private Vector3 moveTarget;
	private Vector3 moveVelocity;

	void Start(){
		moveTarget = normalPos.position;
	}

	void FixedUpdate () {
		transform.LookAt (focus,Vector3.up);
		Vector3 moveAmount = Vector3.SmoothDamp (transform.position, moveTarget, ref moveVelocity, Time.fixedDeltaTime * 30f);
		transform.position = moveAmount;


		if(Input.GetKey(KeyCode.F)){
			GetCloser ();
		}else {
			GetFurther ();
		}

	}

	void GetCloser(){
		moveTarget = closePos.position;
	}

	void GetFurther(){
		moveTarget = normalPos.position;
	}
}

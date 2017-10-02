using UnityEngine;
using System.Collections;

public class AngleMovement : MonoBehaviour {


	public float speed;
	Rigidbody2D angleRigidbody;
	Animator angleAnimator;
	public bool canMove = true;
	public float deadZone = 0.1f;

	void Start () {
	
		angleRigidbody = gameObject.GetComponent<Rigidbody2D>();
		angleAnimator = gameObject.GetComponent<Animator> ();

	}
	

	void Update () {

	
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		if (angleAnimator.GetBool("Right") && horizontal < deadZone) angleAnimator.SetBool ("Right", false);
		if (!angleAnimator.GetBool("Right") && horizontal > deadZone) angleAnimator.SetBool ("Right", true);
		if (angleAnimator.GetBool("Up") && vertical < deadZone) angleAnimator.SetBool ("Up", false);
		if (!angleAnimator.GetBool("Up") && vertical > deadZone) angleAnimator.SetBool ("Up", true);
		if (angleAnimator.GetBool("Left") && horizontal > -deadZone) angleAnimator.SetBool ("Left", false);
		if (!angleAnimator.GetBool("Left") && horizontal < -deadZone) angleAnimator.SetBool ("Left", true);
		if (angleAnimator.GetBool("Down") && vertical > -deadZone) angleAnimator.SetBool ("Down", false);
		if (!angleAnimator.GetBool("Down") && vertical < -deadZone) angleAnimator.SetBool ("Down", true);
		if (horizontal > deadZone) {angleAnimator.SetFloat ("RightSpeed", horizontal);} else { angleAnimator.SetFloat("RightSpeed", 0f);}
		if (horizontal < -deadZone) {angleAnimator.SetFloat ("LeftSpeed", Mathf.Abs(horizontal));} else { angleAnimator.SetFloat("LeftSpeed", 0f);}
		if (vertical > deadZone) {angleAnimator.SetFloat ("UpSpeed", vertical);} else { angleAnimator.SetFloat("UpSpeed", 0f);}
		if (vertical < -deadZone) {angleAnimator.SetFloat ("DownSpeed", Mathf.Abs(vertical));} else { angleAnimator.SetFloat("DownSpeed", 0f);}

		if (angleAnimator.GetBool ("Down") && angleAnimator.GetBool ("Left")) {
			if (Mathf.Abs(horizontal) > Mathf.Abs(vertical)){
				angleAnimator.SetBool("Down", false);
			}
			if (Mathf.Abs(horizontal) < Mathf.Abs(vertical)){
				angleAnimator.SetBool("Left", false);
			}
		}
		if (angleAnimator.GetBool ("Down") && angleAnimator.GetBool ("Right")) {
			if (Mathf.Abs(horizontal) > Mathf.Abs(vertical)){
				angleAnimator.SetBool("Down", false);
			}
			if (Mathf.Abs(horizontal) < Mathf.Abs(vertical)){
				angleAnimator.SetBool("Right", false);
			}
		}
		if (angleAnimator.GetBool ("Up") && angleAnimator.GetBool ("Right")) {
			if (Mathf.Abs(horizontal) > Mathf.Abs(vertical)){
				angleAnimator.SetBool("Up", false);
			}
			if (Mathf.Abs(horizontal) < Mathf.Abs(vertical)){
				angleAnimator.SetBool("Right", false);
			}
		}
		if (angleAnimator.GetBool ("Up") && angleAnimator.GetBool ("Left")) {
			if (Mathf.Abs(horizontal) > Mathf.Abs(vertical)){
				angleAnimator.SetBool("Up", false);
			}
			if (Mathf.Abs(horizontal) < Mathf.Abs(vertical)){
				angleAnimator.SetBool("Left", false);
			}
		}



		if (Input.GetAxis ("Horizontal") > 0f) {
			if (Input.GetAxis ("Horizontal") < deadZone) horizontal = 0f;
			if (Input.GetAxis ("Horizontal") > deadZone) horizontal = deadZone;
		}
		if (Input.GetAxis ("Horizontal") < 0f) {
			if (Input.GetAxis ("Horizontal") > -deadZone) horizontal = 0f;
			if (Input.GetAxis ("Horizontal") < -deadZone) horizontal = -deadZone;
		}
		if (Input.GetAxis ("Vertical") > 0f) {
			if (Input.GetAxis ("Vertical") < deadZone) vertical = 0f;
			if (Input.GetAxis ("Vertical") > deadZone) vertical = deadZone;
		}
		if (Input.GetAxis ("Vertical") < 0f) {
			if (Input.GetAxis ("Vertical") > -deadZone) vertical = 0f;
			if (Input.GetAxis ("Vertical") < -deadZone) vertical = -deadZone;
		}

		Vector2 movement = new Vector2 (horizontal, vertical);
		if (canMove) {
			angleRigidbody.velocity = movement * speed;
		} else {
			angleAnimator.SetBool("Right", false);
			angleAnimator.SetBool("Up", false);
			angleAnimator.SetBool("Left", false);
			angleAnimator.SetBool("Down", false);
			angleRigidbody.velocity = Vector2.zero;
			Vector3 currentPos = transform.position;
			transform.position = new Vector3(Mathf.Round(currentPos.x),
			                                 Mathf.Round(currentPos.y),
			                                 Mathf.Round(currentPos.z));
		}
		
	}
}
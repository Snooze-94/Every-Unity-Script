using UnityEngine;
using System.Collections;

public class Pickupable : MonoBehaviour {


	public float thrownSpeed = 15f;
	GameObject pickedUpPosition;
	float speed = 100f;
	float moveSpeed;
	ObjectInteraction playerScript;
	[HideInInspector]
	public bool dropped;
	public bool thrown;
	public bool pickedUp;
	float deltaTime;


	// Use this for initialization
	void Start () {
		pickedUpPosition = GameObject.FindWithTag("Picked Obj");
		playerScript = GameObject.FindWithTag("Camera Collider").GetComponent<ObjectInteraction>();

	}

	void Update () {

		if(pickedUp){
			gameObject.GetComponent<Rigidbody>().freezeRotation = true;
			gameObject.GetComponent<Rigidbody>().useGravity = false;
			moveSpeed = speed * Time.deltaTime;
			gameObject.GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(transform.position, pickedUpPosition.transform.position, moveSpeed));
			Physics.IgnoreCollision(GameObject.FindWithTag("Player").GetComponent<CharacterController>(), GetComponent<Collider>(), true);
			if(Vector3.Distance(gameObject.transform.position, pickedUpPosition.transform.position) > 8){
				dropped = true;
				pickedUp = false;
			}
			if(Input.GetButtonUp("Fire2")){
				dropped = true;
				pickedUp = false;
			}
			if(Input.GetButtonDown("Fire1")){
				thrown = true;
				pickedUp = false;
			}

		} else if(dropped) {
			gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
			gameObject.GetComponent<Rigidbody>().freezeRotation = false;
			gameObject.GetComponent<Rigidbody>().useGravity = true;
			Physics.IgnoreCollision(GameObject.FindWithTag("Player").GetComponent<CharacterController>(), GetComponent<Collider>(), false);
			dropped = false;
			playerScript.carryingObject = false;
			playerScript.carriedObject = null;

		} else if(thrown){
			gameObject.GetComponent<Rigidbody>().freezeRotation = false;
			gameObject.GetComponent<Rigidbody>().useGravity = true;
			GetComponent<Rigidbody>().velocity = GameObject.FindWithTag("MainCamera").transform.forward * thrownSpeed;
			Physics.IgnoreCollision(GameObject.FindWithTag("Player").GetComponent<CharacterController>(), GetComponent<Collider>(), false);
			thrown = false;
			playerScript.carryingObject = false;
			playerScript.carriedObject = null;
		}
	}

	void OnCollisionEnter(Collision collision){
		speed = 5f;
	}
	void OnCollisionExit(Collision collision){
		speed = 100f;
	}
}

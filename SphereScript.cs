using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SphereScript : NetworkBehaviour {

	public float moveSpeed;
	private Vector3 moveAmount;
	private Vector3 smoothMoveVelocity;
	public GameObject explosion;
	public AudioClip explosionSound;


	void FixedUpdate () {

		if(!isLocalPlayer){
			return;
		}

		float inputX = Input.GetAxisRaw ("Horizontal");
		float inputY = Input.GetAxisRaw ("Vertical");
		Vector3 moveDir = new Vector3 (inputX, 0, inputY).normalized;
		Vector3 targetMoveAmount = moveDir * moveSpeed;
		moveAmount = Vector3.SmoothDamp (moveAmount, targetMoveAmount, ref smoothMoveVelocity, .1f);

		Vector3 localMove = transform.TransformDirection (moveAmount) * Time.fixedDeltaTime;
		GetComponent<Rigidbody> ().MovePosition (GetComponent<Rigidbody> ().position + localMove);
	
	}

	void OnTriggerEnter(Collider col){
		
		if(!isLocalPlayer){
			return;
		}

		if(col.tag == "Death"){
			Instantiate (explosion, transform.position, transform.rotation);
			Camera.main.gameObject.GetComponent<AudioSource> ().PlayOneShot (explosionSound);
			Destroy (gameObject);
		}
		if(col.tag == "Player"){
			print (true);
			Vector3 heading = col.transform.position - transform.position;
			float distance = heading.magnitude;
			Vector3 direction = heading / distance;
			col.gameObject.GetComponent<Rigidbody> ().AddForce(direction * 50);
			/*heading = transform.position - col.transform.position;
			distance = heading.magnitude;
			direction = heading / distance;
			GetComponent<Rigidbody> ().AddForce (direction * 20);*/
		}
	}

}
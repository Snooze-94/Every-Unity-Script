using UnityEngine;
using System.Collections;

public class DiCaprioMovement : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
	public Vector3 gravity;
	public Vector3 flapVelocity;
	public float maxSpeed = 10f;
	public float forwardSpeed = 2.5f;
	public bool dead = false;
	public AudioClip[] soundEffects;
	public AudioClip[] whoosh;
	bool control = true;
	bool didFlap = false;
	Rigidbody2D rgbd2d;
	// Use this for initialization
	void Start () {
		rgbd2d = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!dead) {
			if (Input.GetTouch(0).phase == TouchPhase.Began) {
				didFlap = true;
			}
		}
	}

	void FixedUpdate(){
		if (control) {
			velocity.x = forwardSpeed;


			if (didFlap) {
				gameObject.GetComponent<AudioSource>().PlayOneShot(whoosh[Random.Range(0,2)]);
				didFlap = false;
				if (velocity.y > 0) {
					velocity += flapVelocity;
				} else {
					velocity = flapVelocity;
				}
			}

			if (velocity.y > maxSpeed) {
				velocity.y = maxSpeed;
			}


			velocity += gravity * Time.deltaTime;
			transform.position += velocity * Time.deltaTime;
			transform.rotation = Quaternion.Euler (0, 0, velocity.y);
		} else {
			if (Input.GetTouch(0).phase == TouchPhase.Began)
			{
				Application.LoadLevel(0);
			}
		}

	}
	void Death(){

	}

	void OnCollisionEnter2D(Collision2D collision) {
		velocity += new Vector3(0f,6f,0f);
		rgbd2d.gravityScale = 0.4f;
		gameObject.GetComponent<AudioSource>().PlayOneShot(soundEffects[Random.Range(0,9)]);
		dead = true;
		control = false;
	}
}

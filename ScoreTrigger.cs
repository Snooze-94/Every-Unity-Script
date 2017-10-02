using UnityEngine;
using System.Collections;

public class ScoreTrigger : MonoBehaviour {

	public AudioClip[] flashSounds;
	public GameObject canvasEffects;
	Animator canvasAnimator;
	// Use this for initialization
	void Start () {
		canvasAnimator = canvasEffects.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			Score.AddPoint();
			canvasAnimator.SetTrigger("Scored");
			gameObject.GetComponent<AudioSource>().PlayOneShot(flashSounds[Random.Range(0,2)]);
		}
	}
}

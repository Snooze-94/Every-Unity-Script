using UnityEngine;
using System.Collections;

public class BlLooper : MonoBehaviour {
	
	float numBGPanels;
	
	float pipeMin = -6.3f;
	float pipeMax = -1.2f;

	void Start() {
		GameObject[] pipes = GameObject.FindGameObjectsWithTag("Oscars");
		
		foreach(GameObject pipe in pipes) {
			Vector3 pos = pipe.transform.position;
			pos.y = Random.Range(pipeMin, pipeMax);
			pipe.transform.position = pos;
		}
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log ("Triggered: " + collider.name);
		
		float widthOfBGObject = ((BoxCollider2D)collider).size.x;

		switch (collider.tag) {
		case "Ground":
			numBGPanels = 9.68f;
			break;
		case "BG":
			numBGPanels = 4.84f;
			break;
		case "Oscars":
			numBGPanels = 20.835f;
			break;
		}

		Vector3 pos = collider.transform.position;
		
		pos.x += widthOfBGObject * numBGPanels;
		
		if(collider.tag == "Oscars") {
			pos.y = Random.Range(pipeMin, pipeMax);
		}
		
		collider.transform.position = pos;
		
	}

}
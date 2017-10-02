using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {

	public GameObject UIButton;
	GameObject currentButton;

	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.name == "Angle"){
			currentButton = Instantiate (UIButton);
			currentButton.transform.position = gameObject.transform.position;
			currentButton.GetComponent<Animator>().SetBool ("Interact", true);
		}
	}

	void OnTriggerExit(Collider col){
		if(col.name == "Angle"){
			Destroy (currentButton);
		}
	}
}

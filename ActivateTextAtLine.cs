using UnityEngine;
using System.Collections;

public class ActivateTextAtLine : MonoBehaviour {


	public TextAsset theText;

	public int startLine;
	public int endLine;

	public TextImporter theTextBox;

	public bool destroyedWhenActivated;

	public bool requireButtonPress;
	private bool waitForPress;

	void Start () {
	
		theTextBox = FindObjectOfType<TextImporter> ();
	}
	

	void Update () {

		if (waitForPress && Input.GetButtonDown ("A")) {

			theTextBox.ReloadScript(theText);
			theTextBox.currentLine = startLine;
			theTextBox.endAtLine = endLine;
			theTextBox.EnableTextBox();
			
			if(destroyedWhenActivated){
				Destroy(gameObject);
			}
		}

	
	}

	void OnTriggerEnter2D(Collider2D other){



		if (other.tag == "Player") {

			if(requireButtonPress)
			{
				waitForPress = true;
				return;
			}

			theTextBox.ReloadScript(theText);
			theTextBox.currentLine = startLine;
			theTextBox.endAtLine = endLine;
			theTextBox.EnableTextBox();

			if(destroyedWhenActivated){
				Destroy(gameObject);
			}

		}


	}

	void OnTriggerExit2D(Collider2D other){

		if (other.tag == "Player") {
			waitForPress = false;
		}

	}

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextImporter : MonoBehaviour {

	public GameObject textBox;
	public GameObject arrow;

	public Text theText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;
	public int endAtLine;

	public AngleMovement player;

	public bool isActive;
	public bool inputFixer;

	private bool isTyping = false;
	private bool cancelTyping = false;

	public float typeSpeed;

	void Start () {

		player = FindObjectOfType<AngleMovement> ();

		if (textFile != null) {
			textLines = (textFile.text.Split('\n'));

		}

		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;
		}

		if (isActive) {
			EnableTextBox ();
		} else {
			DisableTextBox();
		}

	}

	void Update() {

		if (!isActive) {
			return;
		}

		if (theText.text == textLines[currentLine]) {
			arrow.SetActive (true);
		} else {
			arrow.SetActive(false);
		}

		if (Input.GetButtonDown ("A") && inputFixer) {
			if(!isTyping){

				currentLine += 1;

				if (currentLine > endAtLine) {
					DisableTextBox();
				} else {
					StartCoroutine(TextScroll(textLines[currentLine]));
				}

			} else if(isTyping && !cancelTyping) {
				cancelTyping = true;
			}

		}
		

		if(Input.GetButtonUp("A")) inputFixer = true;

	}

	private IEnumerator TextScroll (string lineOfText){
		int letter = 0;
		theText.text = "";
		isTyping = true;
		cancelTyping = false;
		while(isTyping && !cancelTyping && (letter < lineOfText.Length - 1)){
			theText.text += lineOfText[letter];
			letter +=1;
			yield return new WaitForSeconds(typeSpeed);
		}
		theText.text = lineOfText;
		isTyping = false;
		cancelTyping = false;
	}

	public void EnableTextBox(){

		textBox.SetActive(true);
		player.canMove = false;
		isActive = true;

		StartCoroutine(TextScroll(textLines[currentLine]));
	}

	public void DisableTextBox(){

		textBox.SetActive(false);
		player.canMove = true;
		isActive = false;
		inputFixer = false;

	}

	public void ReloadScript(TextAsset theText){

		if (theText != null) {
			textLines = new string[1];
			textLines = (theText.text.Split('\n'));
		}

	}
	
}

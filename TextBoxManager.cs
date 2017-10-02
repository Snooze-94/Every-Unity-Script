using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

	public GameObject textBox;
	public Image avatar;
	public Text theText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;
	public int endAtLine;

	public Player player;
	public CameraMovement camScript;

	public bool isActive;
	public bool stopPlayerMovement;
	public bool setPointOfInterest;
	public Vector3 poi;

	private bool isTyping = false;
	private bool cancelTyping = false;

	public float typeSpeed;

	void Start () {

		player = FindObjectOfType<Player> ();
		camScript = FindObjectOfType<CameraMovement> ();

		if(textFile != null){
			
			textLines = (textFile.text.Split ('\n'));

		}

		if(endAtLine == 0){
			endAtLine = textLines.Length - 1;
		}

		if(isActive){
			EnableTextBox ();
		} else{
			DisableTextBox ();
		}

	}


	void Update () {

		if(!isActive){
			return;
		}

		//theText.text = textLines [currentLine];

		if(Input.GetKeyDown(KeyCode.Return)){

			if(!isTyping){
				currentLine += 1;
				if(currentLine > endAtLine){
					DisableTextBox ();
				} 
				else {
					StartCoroutine (TextScroll(textLines [currentLine]));
				}
			}
			else if(isTyping && !cancelTyping){
				cancelTyping = true;
			}
		}


	
	}

	private IEnumerator TextScroll(string lineOfText){

		int letter = 0;
		theText.text = "";
		isTyping = true;

		string c = lineOfText.Substring(lineOfText.IndexOf("C:") + 2, lineOfText.IndexOf("M:") - lineOfText.IndexOf("C:") - 2);
		cancelTyping = false;
		Sprite s = Resources.Load<Sprite>("Avatars/" + c);
		avatar.GetComponent<Image>().sprite = s;


		lineOfText = lineOfText.Substring(lineOfText.IndexOf("M:") + 2, lineOfText.IndexOf(":E") - lineOfText.IndexOf("M:") - 2);

		while(isTyping && !cancelTyping && (letter < lineOfText.Length - 1)){
			
				theText.text += lineOfText [letter];
				AudioClip v = Resources.Load ("Letters/Test/" + lineOfText [letter]) as AudioClip;
				GetComponent<AudioSource> ().PlayOneShot (v, 1);
				letter += 1;
				yield return new WaitForSeconds (typeSpeed);

		}

		AudioClip a = Resources.Load ("Letters/Test/" + lineOfText [lineOfText.Length - 1]) as AudioClip;
		GetComponent<AudioSource> ().PlayOneShot (a, 1);
		theText.text = lineOfText;
		isTyping = false;
		cancelTyping = false;

	}

	public void EnableTextBox(){
		textBox.SetActive (true);
		isActive = true;

		if(stopPlayerMovement){
			player.canMove = false;
		}

		if(setPointOfInterest){
			camScript.free = false;
			camScript.pointOfInterest = poi;

		}

		StartCoroutine (TextScroll(textLines [currentLine]));
	}

	public void DisableTextBox(){
		textBox.SetActive (false);
		isActive = false;
		camScript.free = true;
		player.canMove = true;
	}

	public void ReloadText(TextAsset theText){

		if(theText != null){
			textLines = new string[1];
			textLines = (theText.text.Split ('\n'));
		}

	}

	public void ReloadSettings(bool move, bool cam){
		stopPlayerMovement = move;
		setPointOfInterest = cam;
	}
}

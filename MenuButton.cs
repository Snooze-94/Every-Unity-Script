using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour {

	public GameObject newGame;
	public Text newGameText;
	public GameObject credits;
	public Text creditsText;
	public GameObject exitGame;
	public Text exitText;
	public AudioClip selectAudio;
	bool playSound = true;

	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 150f)) {
			if (hit.transform.name == "NEWGAME") {
				Debug.DrawLine (ray.origin, ray.GetPoint (150f), Color.red);
				newGameText.text = ">New game";
				if(Input.GetMouseButtonDown(0)){
					StartNewGame();
				}
				if (playSound) {
					newGame.GetComponent<AudioSource> ().PlayOneShot (selectAudio);
					playSound = false;
				}
			} 
			if (hit.transform.name == "CREDITS") {
				Debug.DrawLine (ray.origin, ray.GetPoint (150f), Color.red);
				creditsText.text = ">Credits";
				if (playSound) {
					credits.GetComponent<AudioSource> ().PlayOneShot (selectAudio);
					playSound = false;
				}
			} 
			if (hit.transform.name == "EXIT") {
				Debug.DrawLine (ray.origin, ray.GetPoint (150f), Color.red);
				exitText.text = ">Quit";
				if(Input.GetMouseButtonDown(0)){
					ExitTheGame();
				}
				if (playSound) {
					exitGame.GetComponent<AudioSource> ().PlayOneShot (selectAudio);
					playSound = false;
				}
			} 
		} else {
			newGameText.text = "New game";
			creditsText.text = "Credits";
			exitText.text = "Quit";
			playSound = true;
		}
			print(hit.transform.name);
		}

	void StartNewGame(){
		Application.LoadLevel (2);
	}

	void GoToCredits(){

	}

	void ExitTheGame(){
		print("GameQuit");
		Application.Quit ();
	}

		
	}


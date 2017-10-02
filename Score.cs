using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	static int score;
	static int highScore;
	private const string AD_UNIT_ID = "";
	private AdMobPlugin admob;

	public bool hidden = true;


	static Score instance;

	static public void AddPoint() {
		if(instance.bird.dead)
			return;

		score++;

		if(score > highScore) {
			highScore = score;
		}
	}

	DiCaprioMovement bird;

	void Start() {

		instance = this;
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		if(player_go == null) {
			Debug.LogError("Could not find an object with tag 'Player'.");
		}

		bird = player_go.GetComponent<DiCaprioMovement>();
		score = 0;
		highScore = PlayerPrefs.GetInt("highScore", 0);
	}

	void OnDestroy() {
		instance = null;
		PlayerPrefs.SetInt("highScore", highScore);
	}

	void Update () {
		if (!bird.dead) {
			gameObject.GetComponent<Text> ().text = "" + score;
		} else {
			gameObject.GetComponent<Text> ().text = "Highscore " + highScore + "\n\nTouch to try again.";
		}
	}
}

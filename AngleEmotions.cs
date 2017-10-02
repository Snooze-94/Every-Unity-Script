using UnityEngine;
using System.Collections;

public class AngleEmotions : MonoBehaviour {

	public  int blink;
	public int blinkTime;
	public  Texture NormalBlink;
	public  Texture Normal;

	void Start () {
		blink = 0;
		blinkTime = Random.Range (200, 600);
	}
	

	void Update () {
		if(blink > blinkTime){
			StartCoroutine (Blink ());
			blink = 0;
			blinkTime = Random.Range (200, 600);
		}

		blink++;
	}

	public  IEnumerator Blink() {
		gameObject.GetComponent<Renderer>().material.mainTexture = NormalBlink;
		yield return new WaitForSeconds(0.1f);
		gameObject.GetComponent<Renderer>().material.mainTexture = Normal;
		
	}
}

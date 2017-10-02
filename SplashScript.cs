using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SplashScript : MonoBehaviour {

	float alpha;
	bool dissapearing;
	Image imageComponent;

	void Start () {
		dissapearing = false;
		imageComponent = GetComponent<Image> ();
		alpha = 0f;
	}
	

	void Update () {
		if (!dissapearing) {
			alpha += 0.01f;
		} else {
			StartCoroutine(Dissapear());
		}

		if (Input.anyKeyDown) {
			dissapearing = true;
			alpha = 0;
			Dissapearing();
		}

		if (alpha >= 1f) {
			dissapearing = true;
		}
		imageComponent.color = new Color (1, 1, 1, alpha);
	}

	IEnumerator Dissapear(){
		yield return new WaitForSeconds (2f);
		Dissapearing();
	}
	void Dissapearing(){
		alpha -= 0.01f;

		if(alpha <= 0){
			Application.LoadLevel(1);
			Destroy(gameObject);
		}
	}
}

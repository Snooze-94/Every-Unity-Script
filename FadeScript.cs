using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour {

	float alpha;
	Image imageComp;
	public float startFadingAt;
	float clock;

	void Start () {
		imageComp = GetComponent<Image> ();
		alpha = 1f;
		clock = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		imageComp.color = new Color (0.083f, 0.083f, 0.083f, alpha);
		if (clock > startFadingAt) {
			alpha -= 0.005f;
		}
		if (alpha <= 0f) {
			Destroy(gameObject);
		}
		clock += 1f;

	}
}

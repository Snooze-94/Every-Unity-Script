using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChrosshairSizeController : MonoBehaviour {

	Sprite currentSprite;
	RectTransform rTransform;

	void Start () {
		rTransform = gameObject.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		currentSprite = gameObject.GetComponent<Image>().sprite;
		switch(currentSprite.name){

			case "normal_crosshair":
				rTransform.sizeDelta = new Vector2(5,5);
				break;

			case "hand_crosshair":
				rTransform.sizeDelta = new Vector2(24,45);
				break;

		}

	}
}

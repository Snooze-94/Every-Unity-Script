using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrosshairManager : MonoBehaviour {
	

	void Start () {
		RecalcSize ();
	}

	void Update(){

	}

	void RecalcSize(){

		GetComponent<RectTransform> ().sizeDelta = new Vector2 (Mathf.Floor(Screen.height / (Screen.width / 36f)), Mathf.Floor(Screen.height / (Screen.width / 36f)));

	}

	public void SetCrosshair(string cross){
		GetComponent<RawImage>().texture = Resources.Load("Graphics/Crosshairs/" + cross) as Texture;
	}
}

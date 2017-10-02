using UnityEngine;
using System.Collections;

public class StartCutsceneText : MonoBehaviour {
	public GameObject startingText;
	void Start () {
		Cursor.visible = false;
		Quaternion startRotation = new Quaternion (0, 0, 0, 0);
		GameObject go = Instantiate (startingText,gameObject.transform.position,startRotation) as GameObject;
		go.transform.parent = gameObject.transform;
	}

}

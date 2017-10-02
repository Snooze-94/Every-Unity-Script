using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FollowMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 clampedPos = Input.mousePosition;
		clampedPos = new Vector3(Mathf.Clamp(clampedPos.x, 0, Screen.width), Mathf.Clamp(clampedPos.y,0,Screen.height), 0);

		GetComponent<RectTransform>().position = clampedPos;
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetText : MonoBehaviour {

	void Update () {
		GetComponent<Text> ().text = ("DEBUG: \n" + "TIME: " +(Mathf.Round (Time.time * 100f) / 100f).ToString () + "\n");
	}

}

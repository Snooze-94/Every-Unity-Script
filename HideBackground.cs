using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBackground : MonoBehaviour {

	private Color leaveColor;

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "BackgroundTile"){
			leaveColor = col.gameObject.GetComponentInChildren<TextMesh> ().color;
			foreach(Transform child in col.gameObject.transform){
				child.gameObject.GetComponent<TextMesh>().color = new Color(0,0,0,0);
			}
		}
	}

	void OnCollisionExit(Collision col){
		if(col.gameObject.tag == "BackgroundTile"){
			foreach(Transform child in col.gameObject.transform){
				child.gameObject.GetComponent<TextMesh>().color = leaveColor;
			}
		}
	}
}

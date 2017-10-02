using UnityEngine;
using System.Collections;

public class Inspect : MonoBehaviour {

	public string itemName;
	public string messageColor;
	public bool canBeGrabbed;
	TextAsset description;

	void Start () {
		description = Resources.Load ("Descriptions/" + itemName) as TextAsset;
	}
	

	void Update () {

		if(canBeGrabbed && Input.GetMouseButtonDown(0)){
			Notifications.CustomText(description.text.ToUpper(), messageColor);
        }
	
	}

}

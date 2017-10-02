using UnityEngine;
using System.Collections;
public class GrabableItem : MonoBehaviour {


	public string itemName;
	public string nameColor;
	public bool canBeGrabbed;
	public AudioClip pickUpSound;


	void Update () {

		if(canBeGrabbed && Input.GetMouseButtonDown(0) && !FirstPersonController.isPaused){
			if (!InventorySystem.IsInventoryFull()) {
				GameObject.FindGameObjectWithTag ("Player").GetComponent<InventorySystem> ().AddItem (itemName, true, pickUpSound);
				Notifications.PickUpText (itemName.ToUpper (), nameColor);
				Destroy (gameObject);
			} else {
				Notifications.CustomText ("THE INVENTORY\nIS FULL", "red");
			}
		}
	
	}
}

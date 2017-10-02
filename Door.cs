using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Door : MonoBehaviour {

	public string neededKey;
	public string neededKeyColor;
	public AudioClip useKeySound;
	public AudioClip openSound;
	public AudioClip closeSound;
	public bool isLocked = false;
	public bool canBeGrabbed = false;
	public bool grabbed = false;
	public bool closed = true;
	public float normalX;
	public float normalY;


	void Update () {


		if (!isLocked) {
			
			if ((canBeGrabbed || grabbed) && Input.GetMouseButton (0)) {
				FirstPersonController.lockCamera = true;
				grabbed = true;
				GetComponent<Rigidbody> ().AddForce (Camera.main.transform.right * 4 * Input.GetAxis ("Mouse X"));
				GetComponent<Rigidbody> ().AddForce (Camera.main.transform.forward * 4 * Input.GetAxis ("Mouse Y"));
				GameObject.FindGameObjectWithTag ("Crosshair").GetComponent<RawImage> ().color = Color.clear;

			}

			if ((transform.localEulerAngles.y < normalY + 2.5f || transform.localEulerAngles.y < normalY - 2.5f) && !grabbed) {
				transform.localEulerAngles = new Vector3 (normalX, normalY, 0);
				closed = true;
			} else {
				closed = false;
			}

			if (grabbed && Input.GetMouseButtonUp (0)) {
				FirstPersonController.lockCamera = false;
				grabbed = false;
				GameObject.FindGameObjectWithTag ("Crosshair").GetComponent<RawImage> ().color = Color.white;
			}

			GetComponent<Rigidbody> ().isKinematic = false;

		} else {

			if(canBeGrabbed && Input.GetMouseButtonDown(0)){

				if(GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySystem>().IsHoldingItem(neededKey)){
					isLocked = false;
					Notifications.UsedText (neededKey.ToUpper(), "yellow");
					GameObject.FindGameObjectWithTag ("Player").GetComponent<InventorySystem> ().RemoveItem (neededKey, true, useKeySound);
				} else {
					Notifications.CustomText ("YOU NEED A " + neededKey.ToUpper (), "red");
				}
			}

			if(canBeGrabbed && Input.GetMouseButtonDown(0)){

				if(GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySystem>().IsHoldingItem(neededKey)){
					Notifications.CustomText ("USE YOUR " + neededKey.ToUpper (), "red");
				} else {
					Notifications.CustomText ("YOU NEED A " + neededKey.ToUpper (), "red");
				}
			}

			GetComponent<Rigidbody> ().isKinematic = true;
			transform.localEulerAngles = new Vector3 (normalX, normalY);

		}

		if(closed){
			GetComponent<Rigidbody> ().isKinematic = !grabbed;
		}




	}
}

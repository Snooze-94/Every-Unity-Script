using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GrabTriggerScript : MonoBehaviour {

	public static string Crosshair;
	public static GameObject grabbedObject;
	public static bool isGrabbingObject;
	public LayerMask lMask;

	void Update(){
		Crosshair = "dot";
		RaycastHit hit;
		bool isObjectStillGrabbable = false;

		if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, lMask)) {
			

			if (hit.distance <= 3 && hit.collider.GetComponent<Grabable> () != null && !isGrabbingObject) {
				
				if (hit.collider.gameObject != grabbedObject && grabbedObject != null) {
					if(grabbedObject.GetComponent<Grabable>() != null){

						grabbedObject.GetComponent<Grabable> ().canBeGrabbed = false;

					} else if(grabbedObject.GetComponent<GrabableItem>() != null){

						grabbedObject.GetComponent<GrabableItem> ().canBeGrabbed = false;

					} else if(grabbedObject.GetComponent<Door>() != null){

						grabbedObject.GetComponent<Door> ().canBeGrabbed = false;

					}
				}

				grabbedObject = hit.collider.gameObject;
				Crosshair = "manograb";
				grabbedObject.GetComponent<Grabable> ().canBeGrabbed = true;
				isObjectStillGrabbable = true;

			}

			if(hit.distance <= 3 && hit.collider.GetComponent<GrabableItem>() != null){
				if (hit.collider.gameObject != grabbedObject && grabbedObject != null) {

					if(grabbedObject.GetComponent<Grabable>() != null){
						
						grabbedObject.GetComponent<Grabable> ().canBeGrabbed = false;

					} else if(grabbedObject.GetComponent<GrabableItem>() != null){
						
						grabbedObject.GetComponent<GrabableItem> ().canBeGrabbed = false;

					} else if(grabbedObject.GetComponent<Door>() != null){
						
						grabbedObject.GetComponent<Door> ().canBeGrabbed = false;

					}


				}

				grabbedObject = hit.collider.gameObject;
				Crosshair = "manograb";
				grabbedObject.GetComponent<GrabableItem> ().canBeGrabbed = true;
				isObjectStillGrabbable = true;
			}

			if(hit.distance <= 3 && hit.collider.GetComponent<Door>() != null){
				if (hit.collider.gameObject != grabbedObject && grabbedObject != null) {
					if(grabbedObject.GetComponent<Grabable>() != null){

						grabbedObject.GetComponent<Grabable> ().canBeGrabbed = false;

					} else if(grabbedObject.GetComponent<GrabableItem>() != null){

						grabbedObject.GetComponent<GrabableItem> ().canBeGrabbed = false;

					} else if(grabbedObject.GetComponent<Door>() != null){

						grabbedObject.GetComponent<Door> ().canBeGrabbed = false;

					}
				}

				grabbedObject = hit.collider.gameObject;
				Crosshair = "manograb";
				grabbedObject.GetComponent<Door> ().canBeGrabbed = true;
				isObjectStillGrabbable = true;
			}

			if(hit.distance <= 3 && hit.collider.GetComponent<Inspect>() != null && !isGrabbingObject){
				grabbedObject = hit.collider.gameObject;
				Crosshair = "eye";
				grabbedObject.GetComponent<Inspect> ().canBeGrabbed = true;
				isObjectStillGrabbable = true;
			}


		}

		if (!isObjectStillGrabbable && grabbedObject != null && grabbedObject.GetComponent<Grabable>() != null && !grabbedObject.GetComponent<Grabable>().grabbed) {
			grabbedObject.GetComponent<Grabable> ().canBeGrabbed = false;
			grabbedObject = null;
		} else if(!isObjectStillGrabbable && grabbedObject != null && grabbedObject.GetComponent<GrabableItem>() != null){
			grabbedObject.GetComponent<GrabableItem> ().canBeGrabbed = false;
			grabbedObject = null;
		} else if(!isObjectStillGrabbable && grabbedObject != null && grabbedObject.GetComponent<Door>() != null){
			grabbedObject.GetComponent<Door> ().canBeGrabbed = false;
			grabbedObject = null;
		} else if(!isObjectStillGrabbable && grabbedObject != null && grabbedObject.GetComponent<Inspect>() != null){
			grabbedObject.GetComponent<Inspect> ().canBeGrabbed = false;
			grabbedObject = null;
		}

		GameObject.FindGameObjectWithTag ("Crosshair").GetComponent<CrosshairManager> ().SetCrosshair (Crosshair);

	}


}

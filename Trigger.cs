using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public enum triggerType{
		OBJECT, HOLDINGITEM, PLAYER
	}
	public triggerType type;
	public string searchedForName;
	public string methodName;
	private string searchedForComponent;


	void Start () {
		switch (type) {
		case triggerType.OBJECT:
			searchedForComponent = "Grabable";
			break;
		case triggerType.HOLDINGITEM:
			searchedForComponent = "InventorySystem";
			break;
		case triggerType.PLAYER:
			searchedForComponent = "FirstPersonController";
			break;
		default:
			throw new System.ArgumentOutOfRangeException ();
		}
	
	}

	void Update(){

	}

	void OnTriggerEnter(Collider col){
		switch(searchedForComponent){

			case "Grabable":
				if(col.GetComponent<Grabable>() != null && col.GetComponent<Grabable>().objectName == searchedForName){
					CallMethod (methodName);
				}
				break;

			case "InventorySystem":
				if(col.GetComponent<InventorySystem>() != null && col.GetComponent<InventorySystem>().IsHoldingItem(searchedForName)){
					CallMethod (methodName);
				}
				break;

			case "FirstPersonController":
				if(col.GetComponent<FirstPersonController>() != null){
					CallMethod (methodName);
				}
				break;

			default:
				break;
		}
	}
	
	public void CallMethod(string method){
		switch(method){
		case "test1":
			TriggerMethods.Test1 ();
			break;
		default:
			print ("Not such method: " + methodName);
			break;
		}
	}
}

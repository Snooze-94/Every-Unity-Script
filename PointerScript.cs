using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointerScript : MonoBehaviour {

	public GameObject infoPanel;
	public GameObject infoText;
	public int selectedItem;

	void Start(){
	}

	void OnTriggerStay(Collider col){
		if(col.GetComponent<ItemScript>() != null){
			
			selectedItem = col.GetComponent<ItemScript> ().itemNumber;
			infoText.GetComponent<Text> ().text = GameObject.FindGameObjectWithTag ("Player").GetComponent<InventorySystem> ().GetNameOfItem(selectedItem).ToUpper ();

			if(GameObject.FindGameObjectWithTag ("Player").GetComponent<InventorySystem> ().GetNameOfItem(selectedItem) != "clear"){
				infoPanel.SetActive (true);
			}


		}
	}

	void OnTriggerExit(Collider col){
		if(col.GetComponent<ItemScript>() != null){
			infoPanel.SetActive (false);
		}
	}




}

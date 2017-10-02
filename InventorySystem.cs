using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour {

	public GameObject inventoryPanel;
	public static int itemAmount;
	public GameObject[] Items;
	public string[] itemNames;

	void Start () {
		itemNames = new string[10];
		ClearItems ();
	
	}

	void Update(){
		if(FirstPersonController.onInventory){
			LoadItems ();
		}

	}
		
	public void ShowInventory(){

		LoadItems ();
		inventoryPanel.SetActive (true);
		
	}

	public void HideInventory(){
		
		inventoryPanel.SetActive (false);

	}

	public void AddItem(string name, bool playSound = false, AudioClip sound = null){

		itemNames [itemAmount] = name;
		itemAmount++;
		if(playSound){
			GetComponent<AudioSource> ().PlayOneShot (sound);
		}

	}

	public void RemoveItem(string name, bool playSound = false, AudioClip sound = null){
		bool found = false;
		for(int i=0; 0<itemNames.Length; i++){

			if(itemNames[i] != null & itemNames[i] == name && !found){
				itemNames[i] = "clear";
				itemAmount--;
				found = true;
			}

			if(found){
				if(itemNames[i] != "clear"){
					itemNames [i - 1] = itemNames [i];
					itemNames [i] = "clear";
				}
			}
		}
	}

	void LoadItems(){
		
		for(int i=0; i<itemNames.Length; i++){
			Items [i].GetComponent<RawImage> ().texture = Resources.Load ("Graphics/Items/" + itemNames [i]) as Texture;
		}

	}

	void ClearItems(){

		for(int i=0; i<itemNames.Length; i++){
			itemNames[i] = "clear";
			Items [i].GetComponent<RawImage> ().texture = Resources.Load ("Graphics/Items/clear") as Texture;
		}

		itemAmount = 0;

	}

	public bool IsHoldingItem(string item){

		for(int i=0; i<itemNames.Length; i++){
			if(itemNames[i] == item) return true;
		}

		return false;

	}

	public static bool IsInventoryFull(){
		if(itemAmount > 9){
			return true;
		} else {
			return false;
		}
	}

	public string GetNameOfItem(int position){
		return itemNames [position];
	}
		
}

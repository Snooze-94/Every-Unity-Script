using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public int itemNumber;
	public GameObject infoPanel;
	public GameObject infoText;
	public GameObject player;


	public void OnPointerEnter(PointerEventData eventData){
		print (itemNumber);
	}

	public void OnPointerExit(PointerEventData eventData){
		print (itemNumber);
	}


}

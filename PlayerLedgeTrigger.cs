using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLedgeTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.layer == 10) PlayerController.onLedge = true;
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.layer == 10) PlayerController.onLedge = false;
	}
}

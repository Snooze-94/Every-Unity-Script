using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlopeTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.layer == 10) PlayerController.onSlope = true;
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.layer == 10) PlayerController.onSlope = false;
	}
}

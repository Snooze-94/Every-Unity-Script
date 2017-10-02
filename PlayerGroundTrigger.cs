using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
		if(col.gameObject.layer == 10) PlayerController.onGround = true;
    }

    void OnTriggerExit(Collider col)
    {
		if (col.gameObject.layer == 10) PlayerController.onGround = false;
    }
}

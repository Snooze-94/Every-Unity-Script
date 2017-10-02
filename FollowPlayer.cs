using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public GameObject player;
    public float distance;
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + new Vector3(0, distance , -distance * 1.2f);
    }
}

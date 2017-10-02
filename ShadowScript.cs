using UnityEngine;
using System.Collections;

public class ShadowScript : MonoBehaviour {


	public GameObject playerObject;


	void Start () {


	}
	

	void Update () {

		if(playerObject.GetComponent<Player>().velocity.x != 0){
			transform.localScale = new Vector3 (0.15f, 0.03f, 1);
		}else{
			transform.localScale = new Vector3 (0.1f, 0.03f, 1);
		}

	}
}

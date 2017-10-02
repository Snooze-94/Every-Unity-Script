using UnityEngine;
using System.Collections;

public class cubominecraftoskriptoxdd : MonoBehaviour {


	void Start () {
		if (transform.position.z < (globalminecraftxd.max * 2)) {
			bool minecraftxdddd = true;
			if(Physics.Raycast(new Vector3(transform.position.x,transform.position.y + 1,transform.position.z), new Vector3(transform.position.x, transform.position.y,transform.position.z + (globalminecraftxd.max * 2)),2)){
				minecraftxdddd = false;
			}
			if(minecraftxdddd){
				Instantiate(gameObject,new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,gameObject.transform.position.z + 2),gameObject.transform.rotation);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

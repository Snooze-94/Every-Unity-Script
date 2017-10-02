using UnityEngine;
using System.Collections;

public class cuboscript : MonoBehaviour {

	void Start () {
		if(transform.position.z < (globalvars.mapmaxsize * 2)){
			bool doordont = true;
			if(Physics.Raycast(new Vector3(transform.position.x,transform.position.y + 1,transform.position.z),new Vector3(transform.position.x,transform.position.y + 1,transform.position.z + (globalvars.mapmaxsize * 2)), 2)){
				doordont = false;
			}
			if (doordont){
				Instantiate(gameObject,new Vector3(gameObject.transform.position.x,gameObject.transform.position.y, gameObject.transform.position.z + 2),gameObject.transform.rotation);
			}
		}
	}

	void Update () {
		
	}
}

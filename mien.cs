using UnityEngine;
using System.Collections;

public class mien : MonoBehaviour {
	public GameObject cubo;

	void Start () {
		for (int i = 0; i <= globalvars.mapmaxsize; i++) {
			print(i);
			Instantiate(cubo,new Vector3(gameObject.transform.position.x + (i * 2),0, gameObject.transform.position.z + (i * 2)),gameObject.transform.rotation);
			Instantiate(cubo,new Vector3(gameObject.transform.position.x,0, gameObject.transform.position.z + (i * 2)),gameObject.transform.rotation);
			Instantiate(cubo,new Vector3(gameObject.transform.position.x + (i * 2),0, gameObject.transform.position.z),gameObject.transform.rotation);
		}
	}
	

	void Update () {

	}
}

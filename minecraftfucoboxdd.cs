using UnityEngine;
using System.Collections;

public class minecraftfucoboxdd : MonoBehaviour {

	public GameObject cubominecraxd;

	// Use this for initialization
	void Start () {
		for (int i = 0; i <= globalminecraftxd.max; i++) {
			Instantiate(cubominecraxd, new Vector3(gameObject.transform.position.x + (i * 2),0,gameObject.transform.position.z + (i*2)),gameObject.transform.rotation);
			Instantiate(cubominecraxd, new Vector3(gameObject.transform.position.x,0,gameObject.transform.position.z + (i*2)),gameObject.transform.rotation);
			Instantiate(cubominecraxd, new Vector3(gameObject.transform.position.x + (i * 2),0,gameObject.transform.position.z),gameObject.transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

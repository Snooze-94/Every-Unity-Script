using UnityEngine;
using System.Collections;

public class OscarsPosition : MonoBehaviour {

	bool touched = false;
	public Vector3 newPosition;
	void Start () {
		newPosition = new Vector3 (transform.position.x, Random.Range (-6.7f, -1.1f));
	}
	

	void Update () {

	}

}

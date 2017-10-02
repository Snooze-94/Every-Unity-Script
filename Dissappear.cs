using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissappear : MonoBehaviour {


  public float seconds;
  private float passed;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    passed += Time.deltaTime;

    if (passed >= seconds)
    {
      Destroy(gameObject);
    }

	}
}

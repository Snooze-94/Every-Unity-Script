using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRope : MonoBehaviour {

  public GameObject ropeSegment;

  private GameObject[] objects = new GameObject[50];


	void Start () {
    for (int i = 0; i < 50; i++) {

      Vector3 positionSpawn = (i == 0) ? gameObject.transform.position :
        objects[i-1].transform.position + new Vector3(0,0.04f,0);

      var instance = Instantiate(ropeSegment, positionSpawn, gameObject.transform.rotation);
      instance.GetComponent<HingeJoint2D>().connectedBody = (i == 0) ? gameObject.GetComponent<Rigidbody2D>() : objects[i - 1].GetComponent<Rigidbody2D>();
      instance.transform.parent = (i == 0) ? gameObject.transform : objects[i - 1].transform;

      objects[i] = instance;
    }
	}
}

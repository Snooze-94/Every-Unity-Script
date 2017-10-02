using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentToCollider : MonoBehaviour {

  void OnCollisionEnter(Collision collision)
  {
    transform.parent = collision.transform;
    Destroy(gameObject.GetComponent<SphereCollider>());
    Destroy(gameObject.GetComponent<ParentToCollider>());
  }

  void OnCollisionStay(Collision collision)
  {
    //transform.parent = collision.transform;
    //Destroy(gameObject.GetComponent<SphereCollider>());
    //Destroy(gameObject.GetComponent<ParentToCollider>());
  }
}

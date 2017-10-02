using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour {

  public static bool grounded = false;

  void OnTriggerEnter(Collider col)
  {
    grounded = true;
  }

  void OnTriggerStay(Collider col)
  {
    grounded = true;
  }

  void OnTriggerExit(Collider col)
  {
    grounded = false;
  }
  
}

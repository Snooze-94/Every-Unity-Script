using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chrosshair : MonoBehaviour {

  public Vector3 target;

	void Update () {
    Vector3 wanted = Camera.main.WorldToScreenPoint(target);
    transform.position = Vector3.Slerp(transform.position, wanted, 10f * Time.deltaTime);
  }
}

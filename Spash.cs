using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spash : MonoBehaviour {

  public ParticleSystem spash;

  private void OnCollisionEnter(Collision collision)
  {
    Instantiate(spash, collision.transform.position, collision.transform.rotation);
    Destroy(collision.gameObject);
  }
}

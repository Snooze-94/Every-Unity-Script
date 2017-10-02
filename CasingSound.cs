using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasingSound : MonoBehaviour {

  private void OnCollisionEnter(Collision collision)
  {
    string path = "Casing" + Mathf.RoundToInt(Random.Range(1f, 4f)).ToString();
    //AudioClip casing = (AudioClip)AssetDatabase.LoadAssetAtPath(path, typeof(AudioClip));
    AudioClip casing = (AudioClip)Resources.Load(path, typeof(AudioClip));
    GetComponent<AudioSource>().PlayOneShot(casing, 1);
    Destroy(GetComponent<CasingSound>());
  }
}

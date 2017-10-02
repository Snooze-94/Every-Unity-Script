using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : MonoBehaviour {

  public string username;
  public GameObject usernameObject;
  public GameObject player;
  public GameObject glock;
  public bool pointing;

  public Transform weaponPos;
  public Transform holsterPos;

  float drawSpeed = 8f;
  float holsterSpeed = 4f;



  void Start ()
  {

    if(username == "player") Destroy(gameObject);
    usernameObject.GetComponent<TextMesh>().text = username;
	}

  private void Update()
  {
    if (pointing)
    {
      glock.transform.position = Vector3.Lerp(glock.transform.position, weaponPos.position, drawSpeed * Time.deltaTime);
      glock.transform.rotation = Quaternion.Slerp(glock.transform.rotation, Quaternion.Euler(player.transform.eulerAngles), drawSpeed * Time.deltaTime);
    }
    else
    {
      glock.transform.position = Vector3.Lerp(glock.transform.position, holsterPos.position, holsterSpeed * Time.deltaTime);
      glock.transform.rotation = Quaternion.Slerp(glock.transform.rotation, Quaternion.Euler(new Vector3(90f, player.transform.eulerAngles.y, player.transform.eulerAngles.z)), drawSpeed * Time.deltaTime);
    }
  }

  internal void Shot(Vector3 shotOrigin, Vector3 shotDest)
  {
    glock.GetComponent<WeaponScript>().NetworkShoot(shotOrigin, shotDest);
  }

  internal void Move(float posX,float posY, float posZ, float rotY)
  {
    player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(posX, posY, posZ), 0.6f);
    player.transform.eulerAngles = new Vector3(0, rotY, 0);
  }
}

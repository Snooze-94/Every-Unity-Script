using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;

public class Weapon : MonoBehaviour
{
  int currentBulletAmount;
  int maxBulletAmount;
  bool loaded;
  UnityEngine.Object weaponObject;
  GameObject weaponGameObject;

  Transform weaponLocation;

  public Transform shootLocation;

  public Type type;

  public enum Type { M1911, M1Garand}

  Dictionary<Type, string> weaponDictionary = new Dictionary<Type, string>()
  {
    { Type.M1911, "M1911" },
    { Type.M1Garand, "M1Garand" }
  };

  private void Start()
  {
    LoadWeaponObject();

  }

  private void Update()
  {
    if (Input.GetButtonDown("Fire1"))
      weaponGameObject.GetComponent<Animator>().SetTrigger("SHOOT");
  }

  private void FixedUpdate()
  {
    UpdateWeaponLocation();
  }

  private void UpdateWeaponLocation()
  {
    Vector3 pos = weaponGameObject.transform.position;
    

    weaponGameObject.transform.position = Vector3.Slerp(
      pos
      , weaponLocation.position, 25f * Time.fixedDeltaTime);
    weaponGameObject.transform.rotation = Quaternion.RotateTowards(weaponGameObject.transform.rotation, weaponLocation.rotation, 1000f);
    
    
  }

  private void LoadWeaponObject()
  {
    weaponLocation = GameObject.Find("WeaponLocation").transform;
    weaponObject = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Weapons/Objects/" + weaponDictionary[type] + ".prefab", typeof(GameObject));

    weaponGameObject = Instantiate(weaponObject, weaponLocation) as GameObject;
    weaponGameObject.name = "WeaponObject";
    weaponGameObject.layer = 8;
    weaponGameObject.transform.parent = gameObject.transform;
  }

}

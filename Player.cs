using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PlayerController))]
public class Player : MonoBehaviour {

  public float walkSpeed = 2f;
  public float runSpeed = 8f;
  private float shootDelay = 0.1f;
  private float shootDelayPassed = 0f;
  public static bool toggleRun = false;
  float moveSpeed;
  public GameObject HUDControllerGameObject;
  public HudController hudControl;
  public GameObject glock;
  public Transform weaponPos;
  public Transform holsterPos;
  public bool isPointing;

  float drawSpeed = 8f;
  float holsterSpeed = 4f;

  PlayerController controller;

	// Use this for initialization
	void Start () {
    hudControl = HUDControllerGameObject.GetComponent<HudController>();
    controller = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
    shootDelayPassed += Time.deltaTime;

    if (Input.GetButtonDown("ToggleRun")) toggleRun = !toggleRun;

    if (Input.GetButtonDown("Reload")) glock.GetComponent<WeaponScript>().Reload();

    if ((Input.GetButton("Run") || toggleRun) && !Input.GetMouseButton(1))
    {
      moveSpeed = runSpeed;
      hudControl.Run();
    }
    else
    {
      moveSpeed = walkSpeed;
      hudControl.Walk();
    }
           

    Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    Vector3 moveVelocity = moveInput.normalized * moveSpeed;
    controller.Move(moveVelocity);

    if (Input.GetMouseButtonDown(1) && !isPointing || Input.GetMouseButtonUp(1) && isPointing)
    {
      //hudControl.ToggleChrosshair();
    }

    if (Input.GetMouseButton(1))
    {
      isPointing = true;
      glock.GetComponent<WeaponScript>().pointing = true;
      glock.transform.position = Vector3.Lerp(glock.transform.position, weaponPos.position, drawSpeed * Time.deltaTime);
      //glock.transform.localRotation = Quaternion.Lerp(glock.transform.localRotation, new Quaternion(0,0,0,0), drawSpeed * Time.deltaTime);
      glock.transform.rotation = Quaternion.Slerp(glock.transform.rotation, Quaternion.Euler(transform.eulerAngles), drawSpeed * Time.deltaTime);
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      Plane groundPlane = new Plane(Vector3.up, transform.position - Vector3.up);
      float rayDistance;
      if (groundPlane.Raycast(ray, out rayDistance))
      {
        Vector3 point = ray.GetPoint(rayDistance);
        controller.LookAt(point);
      }

      if (Input.GetMouseButtonDown(0) && shootDelayPassed > glock.GetComponent<WeaponScript>().construct.shootDelay)
      {
        glock.GetComponent<WeaponScript>().Shoot();
        shootDelayPassed = 0f;
      }

    }
    else
    {
      isPointing = false;
      glock.GetComponent<WeaponScript>().pointing = false;
      glock.transform.position = Vector3.Lerp(glock.transform.position, holsterPos.position, holsterSpeed * Time.deltaTime);
      glock.transform.rotation = Quaternion.Slerp(glock.transform.rotation, Quaternion.Euler(new Vector3(90f, transform.eulerAngles.y, transform.eulerAngles.z)), drawSpeed * Time.deltaTime);
      controller.LookAt(transform.position + (moveVelocity / 4));
    }

        


	}
}

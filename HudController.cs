using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour {

  public UIWalkRun walkRun;
  public Chrosshair chrosshair;

  public void SetChrosshairPosition(Vector3 pos, float dist)
  {
    chrosshair.target = pos;
    Vector3 size = new Vector3(1, 1 , 1);
    chrosshair.GetComponent<RawImage>().transform.localScale = size;
  }

  public void ToggleChrosshair()
  {
    chrosshair.GetComponent<RawImage>().enabled = !chrosshair.GetComponent<RawImage>().IsActive();
  }

  public void Walk()
  {
    walkRun.Walk();
  }

  public void Run()
  {
    walkRun.Run();
  }
}

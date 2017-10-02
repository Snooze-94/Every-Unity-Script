using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWalkRun : MonoBehaviour {

  public GameObject ImageGameObject;
  public GameObject TextGameObject;
  private RawImage guiIcon;
  private Text guiInfoText;

  private Image background;
  private Texture walkTexture;
  private Texture runTexture;

  private Color coolGreen = new Color(115f/255, 214f / 255, 120f / 255);

  private void Start()
  {
    background = GetComponent<Image>();
    walkTexture = (Texture)Resources.Load("walk", typeof(Texture));
    runTexture = (Texture)Resources.Load("run", typeof(Texture));
    guiIcon = ImageGameObject.GetComponent<RawImage>();
    guiInfoText = TextGameObject.GetComponent<Text>();
    

    Walk();
  }

  public void Walk()
  {
    guiIcon.color = Color.white;
    guiInfoText.color = Color.white;
    background.color = coolGreen;

    guiIcon.texture = walkTexture;
    guiInfoText.text = "WALKING";
  }

  public void Run()
  {
    guiIcon.color = coolGreen;
    guiInfoText.color = coolGreen;
    background.color = Color.white;

    guiIcon.texture = runTexture;
    guiInfoText.text = "RUNNING";
  }
}

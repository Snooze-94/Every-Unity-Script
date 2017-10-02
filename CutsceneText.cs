using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CutsceneText : MonoBehaviour {

	float textOpacity;
	CanvasRenderer textComponent;
	public int textDuration;
	bool showingUp;
	bool dissapearing;
	public GameObject nextText;
	float zPosition = 15f;
	GameObject parentGO;

	void Start () {
		textOpacity = 0f;
		textComponent = gameObject.GetComponent<CanvasRenderer> ();
		showingUp = true;
		dissapearing = false;
		textComponent.SetAlpha(0);
		gameObject.transform.localScale = new Vector3 (1, 1, 1);
		parentGO = GameObject.FindGameObjectWithTag ("CutsceneTextParent");
	}

	void Update () {
		textComponent.SetAlpha (textOpacity);
		zPosition -= 0.1f;
		gameObject.transform.localPosition = new Vector3(0,0,zPosition);
		if (showingUp) {
			ShowUp (textDuration);

		}
		if (dissapearing) {
			Dissapear();
		}
		if(Input.GetButtonDown("Action")){
			if(nextText != null){
				GameObject go = Instantiate (nextText,gameObject.transform.position,new Quaternion (0, 0, 0, 0)) as GameObject;
				go.transform.parent = parentGO.transform;
			} else{
				Application.LoadLevel(3);
			}
			Destroy(gameObject);
		}
		
	}

	void ShowUp(int secondsToWait){
		if (textOpacity < 1f) {
			textOpacity += 0.01f;
		} else if(textOpacity > 1f){
			textOpacity = 1f;
			showingUp = false;
			StartCoroutine(wait(secondsToWait));
		}

	}

	IEnumerator wait(int secondsToWait){
		yield return new WaitForSeconds(secondsToWait);
		dissapearing = true;
	}

	void Dissapear(){
		if (textOpacity > 0f) {
			textOpacity -= 0.01f;
		} else if(textOpacity < 0f){
			if(nextText != null){
			GameObject go = Instantiate (nextText,gameObject.transform.position,new Quaternion (0, 0, 0, 0)) as GameObject;
			go.transform.parent = parentGO.transform;
			} else{
				Application.LoadLevel(3);
			}
			Destroy(gameObject);
		}
		
	}
}

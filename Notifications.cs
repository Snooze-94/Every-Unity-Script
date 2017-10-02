using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Notifications : MonoBehaviour {

	public static string theNotificationText;
	public static Color defaultColor = Color.white;
	public static Text notificationText;
	public static bool showingNotification; 
	bool isShowingText;

	void Start(){
		notificationText = GetComponent<Text> ();
		notificationText.enabled = false;
	}

	void Update () {

		if(showingNotification){
			if (isShowingText) {
				StopCoroutine ("ShowText");
				StartCoroutine ("ShowText");
				showingNotification = false;
			
			} else {
				StartCoroutine ("ShowText");
				showingNotification = false;
			}

		}

		if(FirstPersonController.onInventory){
			DisableText ();
		}
	
	}

	public static void PickUpText(string item, string color = "white"){
		theNotificationText = "PICKED UP:\n<color=" + color + ">" + item + "</color>";
		notificationText.text = theNotificationText;
		notificationText.enabled = true;
		showingNotification = true;


	}

	public static void UsedText(string item, string color = "white"){
		theNotificationText = "YOU USED:\n<color=" + color + ">" + item + "</color>";
		notificationText.text = theNotificationText;
		notificationText.enabled = true;
		showingNotification = true;


	}

	public static void CustomText (string message, string color = "white")
	{
		theNotificationText = "<color=" + color + ">" + message + "</color>";
		notificationText.text = theNotificationText;
		notificationText.enabled = true;
		showingNotification = true;
	}

	void DisableText(){
		notificationText.enabled = false;
	}

	IEnumerator ShowText(){
		isShowingText = true;
		yield return new WaitForSeconds (1.3f);
		isShowingText = false;
		notificationText.enabled = false;

	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

	private float movementSpeed = 3f;
	private Vector3 animationSpeed = Vector3.zero;
	private float timeWithoutMovement = 0f;
	private bool moving = false;
	private BoxCollider2D colliderComponent;
	private Vector3 targetPosition;

	void Start ()
	{
		colliderComponent = GetComponent (typeof(BoxCollider2D)) as BoxCollider2D;
		targetPosition = transform.position;
	}

	void Update ()
	{
		timeWithoutMovement += Time.deltaTime * 10;

		bool movementPressed = false;

		if (timeWithoutMovement >= movementSpeed) {
			
			if (Input.GetKey (KeyCode.RightArrow) && !movementPressed) {
				movementPressed = true;
				Move ("RIGHT");
			}
			if (Input.GetKey (KeyCode.UpArrow) && !movementPressed) {
				movementPressed = true;
				Move ("UP");
			}
			if (Input.GetKey (KeyCode.LeftArrow) && !movementPressed) {
				movementPressed = true;
				Move ("LEFT");
			}
			if (Input.GetKey (KeyCode.DownArrow) && !movementPressed) {
				movementPressed = true;
				Move ("DOWN");
			}

		}

		if (moving) {
			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref animationSpeed, 0.1f);
		}

	}

	void Move (string key)
	{
		
		timeWithoutMovement = 0f;
		moving = true;

		switch (key) {
		case "RIGHT":
			targetPosition += new Vector3 (1, 0, 0);
			break;

		case "UP":
			targetPosition += new Vector3 (0, 1, 0);
			break;

		case "LEFT":
			targetPosition += new Vector3 (-1, 0, 0);
			break;

		case "DOWN":
			targetPosition += new Vector3 (0, -1, 0);
			break;
		}
	}
}

using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

	public float cameraSensitivity = 2;
	public Transform target;
	public float distance = 20;
	public Vector2 pitchMinMax = new Vector2 (-25, 80);
	public LayerMask cameraCollision;

	public float rotationSmoothTime = .12f;
	Vector3 rotationSmoothVelocity;
	Vector3 currentRotation;
	float trueDistance;


	float yaw;
	float pitch;

	void LateUpdate () {
		
		yaw += Input.GetAxis ("Horizontal2") * cameraSensitivity;
		pitch -= Input.GetAxis ("Vertical2") * cameraSensitivity;
		pitch = Mathf.Clamp (pitch, pitchMinMax.x, pitchMinMax.y);

		currentRotation = Vector3.SmoothDamp (currentRotation, new Vector3 (pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
		transform.eulerAngles = currentRotation;

		Vector3 cameraDirection = (((target.position - transform.forward * trueDistance) - target.position) / ((target.position - transform.forward * trueDistance) - target.position).magnitude);

		RaycastHit hit;
		Ray ray = new Ray (target.position, cameraDirection);
		trueDistance = distance;
		if (Physics.Raycast (ray, out hit, distance, cameraCollision, QueryTriggerInteraction.Ignore)) {
			trueDistance = hit.distance - 0.6f;
		} else {
			trueDistance = distance - 0.6f;
		}

		//Debug.DrawRay (target.position, cameraDirection * 15, Color.red);

		transform.position = target.position - transform.forward * trueDistance - Vector3.up * -0.6f;

	}
}

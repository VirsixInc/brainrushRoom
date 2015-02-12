using UnityEngine;
using System.Collections;

public class ViewControl : MonoBehaviour {

	float turnSpeed = 4.0f;
	public float panSpeed = 4.0f;

	private Vector3 mouseOrigin; 
	private bool isPanning;
	private bool isRotating;
	float verticalRotation = 0;
	float downRange = 75;
	float upRange = 310;

	void Update () 
	{
		transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
		if (Input.GetMouseButtonDown(0)) 
		{
			mouseOrigin = Input.mousePosition;
			isRotating = true;
		}

		if (Input.GetMouseButtonUp(0))
		{
			isRotating = false;
		}

		if (isRotating) 
		{
			verticalRotation = transform.rotation.eulerAngles.x;
			Vector3 pos = Camera.main.ScreenToViewportPoint (Input.mousePosition - mouseOrigin);
			if (verticalRotation - pos.y > upRange || verticalRotation - pos.y < downRange)
				verticalRotation-=pos.y;
				transform.rotation = Quaternion.Euler(verticalRotation, transform.rotation.eulerAngles.y, 0); //looking up and down around the right to left axis or transform.right
			transform.RotateAround (transform.position, Vector3.up, pos.x * turnSpeed); //turning left to right around up down axis or vector up
		}
	

	}

	void OnTriggerEnter (Collider other) {
		other.enabled = false;
	}

	void OnTriggerExit (Collider other) {
		other.enabled = true;
	}

	

}

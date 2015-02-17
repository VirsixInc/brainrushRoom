using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	float turnSpeed = 4.0f;
	public float panSpeed = 4.0f;
	
	private bool isPanning;
	private bool isRotating = false;
	float verticalRotation = 0;
	float downRange = 75;
	float upRange = 310;

	public GameObject retPrefab;
	Vector3 camRay;
	public float zPos;
	
	public static CameraController s_instance;
	
	void Awake() {
		s_instance = this;
	}
	
	void Update () 
	{	if (isRotating)
			RotateCamera ();
	}
	

	
	// Update is called once per frame
	public void SpawnReticle() {
		camRay = camera.ScreenToWorldPoint (new Vector3(InputManager.positionOfLastTap.x,InputManager.positionOfLastTap.y,zPos));
		GameObject obj = (GameObject) Instantiate(retPrefab, camRay, Quaternion.identity);
		obj.transform.SetParent (Camera.main.transform);
	}

	void EnableRotateCamera(){
		isRotating = true;
	}
	void DisableRotateCamera(){
		isRotating = false;
	}

	void RayCastClick() {
		RaycastHit hit;
		Ray ray = camera.ScreenPointToRay (InputManager.positionOfLastTap);
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.gameObject.tag == "clickableObj") {
				hit.collider.gameObject.SendMessage("OnClick");
				SpawnReticle();
			}
			else if (hit.collider.gameObject.tag == "cameraMove") {
				hit.collider.gameObject.SendMessage("OnClick");
				//spawn opaque circle
			}
		}

	}

	void RotateCamera() {
		transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
		if (isRotating) 
		{
			verticalRotation = transform.rotation.eulerAngles.x;
			Vector3 pos = Camera.main.ScreenToViewportPoint (InputManager.currentCursorPosition - InputManager.positionOfLastTap);
			if (verticalRotation - pos.y > upRange || verticalRotation - pos.y < downRange)
				verticalRotation -= pos.y;
			transform.rotation = Quaternion.Euler(verticalRotation, transform.rotation.eulerAngles.y, 0); //looking up and down around the right to left axis or transform.right
			transform.RotateAround (transform.position, Vector3.up, pos.x * turnSpeed); //turning left to right around up down axis or vector up
		}
	}

	void OnEnable() {
		InputManager.HeldDown += EnableRotateCamera;
		InputManager.ReleaseHold += DisableRotateCamera;
		InputManager.Tapped += RayCastClick;
	}

	void OnDisable() {
		InputManager.HeldDown -= EnableRotateCamera;
		InputManager.ReleaseHold -= DisableRotateCamera;
		InputManager.Tapped -= RayCastClick;

	}
	
}
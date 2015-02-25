using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

	float turnSpeed = 4.0f;

	private bool isPanning;
	private bool isRotating = false;
	float verticalRotation = 0;
	float downRange = 75;
	float upRange = 310;
	public GameObject upArrow, downArrow, rightArrow, leftArrow;
	public Image noteDisplayer;
	public Text textDisplayer; //when you click on a note this is the text it shows
	public Light flashlight;

	


	public GameObject retPrefab;
	Vector3 camRay;
	public float zPos;
	
	public static CameraController s_instance;
	
	void Awake() {
		s_instance = this;
		Screen.orientation = ScreenOrientation.Landscape;
		flashlight = GetComponentInChildren<Light> ();

	}
	
	void Update () 
	{	if (isRotating)
			RotateCamera ();
	}

	public void ToggleFlashLight(){
		flashlight.enabled = !flashlight.enabled;
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
		rightArrow.SetActive(false);
		leftArrow.SetActive(false);
		downArrow.SetActive(false);
		upArrow.SetActive(false);
	}

	void RayCastClick() {

		if (GameManager.s_instance.currentGameState == GameState.Playing) {
				RaycastHit hit;
				Ray ray = camera.ScreenPointToRay (InputManager.positionOfLastTap);
				if (Physics.Raycast (ray, out hit)) {
					if (hit.collider.gameObject.tag == "clickableObj") {
							hit.collider.gameObject.SendMessage ("OnClick");
							SpawnReticle ();
					} else if (hit.collider.gameObject.tag == "cameraMove") {
							hit.collider.gameObject.SendMessage ("OnClick");
							//spawn opaque circle
					} else if (hit.collider.gameObject.tag == "stickyNote") {
						EnableNote(hit.collider.gameObject.GetComponent<StickyNote>().whatStickyNoteSays);
					} 

				}
		} else if (GameManager.s_instance.currentGameState == GameState.ReadingNote) {
			StartCoroutine("DisableNote");
		}
	}

	void RotateCamera() {
		transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0); //make sure that z rotation is always zero
		if (isRotating) 
		{
			verticalRotation = transform.rotation.eulerAngles.x; //vertical rotation is along the x axis
			Vector3 pos = Camera.main.ScreenToViewportPoint (InputManager.currentCursorPosition - InputManager.positionOfLastTap);
			if (verticalRotation - pos.y > upRange || verticalRotation - pos.y < downRange) //makes it so you cannot look all the way up or down
				verticalRotation -= pos.y;
			transform.rotation = Quaternion.Euler(verticalRotation, transform.rotation.eulerAngles.y, 0); //looking up and down around the right to left axis or transform.right
			transform.RotateAround (transform.position, Vector3.up, pos.x * turnSpeed); //turning left to right around up down axis or vector up
			//highlight arrows according to which direction we are turning
			if (pos.y > 0.1f) {
				upArrow.SetActive(true);
				downArrow.SetActive(false);
			}
			else if (pos.y < -.1f) {
				upArrow.SetActive(false);
				downArrow.SetActive(true);
			}

			else if (pos.y <= .1 && pos.y >= -.1) {
				upArrow.SetActive(false);
				downArrow.SetActive(false);
			}
			if (pos.x < -.1f) {
				rightArrow.SetActive(false);
				leftArrow.SetActive(true);
			}
			
			else if (pos.x > 0.1f) {
				rightArrow.SetActive(true);
				leftArrow.SetActive(false);
			}
			else if (pos.x <= .1 && pos.x >= -.1) {
				rightArrow.SetActive(false);
				leftArrow.SetActive(false);
			}
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

	public void EnableNote(string noteContents) {
		print (noteContents);
		textDisplayer.text = noteContents;
		textDisplayer.gameObject.SetActive (true);
		noteDisplayer.gameObject.SetActive (true);
		GameManager.s_instance.currentGameState = GameState.ReadingNote;
		AudioManager.s_instance.PlayAudioSource ("paper");

	}
	
	IEnumerator DisableNote() {
		yield return new WaitForSeconds (0.3f);
		textDisplayer.gameObject.SetActive (false);
		noteDisplayer.gameObject.SetActive (false);
		GameManager.s_instance.currentGameState = GameState.Playing;

	}
	
}
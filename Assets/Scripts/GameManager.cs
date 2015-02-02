using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

  public GameObject highlightedObj;

  public static GameManager s_instance;

  //Vars for camera movement

  Transform camObj;
  bool cameraMove;

  Vector3 startPos;
  Vector3 endPos;
  float startTime;
  float journeyLength;
  float speed = 9f;
  float cameraRotSpeed = 0.5f;

  //Vars for puzzleEvent
	void Start () {
		s_instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if(cameraMove){
			float distCovered = (Time.time-startTime)*speed;
			float fracJourney = distCovered/journeyLength;
			Camera.main.transform.position = Vector3.Lerp(startPos, endPos, fracJourney);
			Vector3 pos = camObj.GetChild(0).transform.position-Camera.main.transform.position; //gets the first child in the the waypoint's hierarchy which is a lookAtObj.
			Quaternion newRot = Quaternion.LookRotation(pos); //lerp to the rotation it would take to look at the lookAtObj from the camera's current rotation
			Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, newRot, cameraRotSpeed);
			if(fracJourney > 1.0f && 1f < Quaternion.Angle(Camera.main.transform.rotation, newRot)){
				cameraMove = false;
			}	
		}
	}

	public void CheckHighlightedInventoryObj(string keyName) {
	}


	public void HandleClick(GameObject objClicked){
		switch(objClicked.tag){
		case "cameraMove":
			print("CAMERA MOVEMENT EVENT");
		cameraMove = true;
		startPos = Camera.main.transform.position;
		endPos = objClicked.transform.position;
		journeyLength = Vector3.Distance(startPos, endPos);
		startTime = Time.time;
		camObj = objClicked.transform; //gets the transform of the collider
		break;
		case "puzzleEvent":
		print("PUZZLE EVENT");
		break;
		default:
		print("UNRECOGNIZED TAG");
		break;
		}
	}
}

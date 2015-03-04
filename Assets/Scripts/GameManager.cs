using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum GameState {Playing, StartMenu, Menu, ReadingNote};


public class GameManager : MonoBehaviour {

	public GameState currentGameState = GameState.Playing;

	public GameObject highlightedObj;

	public static GameManager s_instance;

	public List<GameObject>[] winConditions;
	int curEvent;
	public float cameraDistance = 10;

	public void SaveGame () {
		PlayerPrefs.SetInt (Application.levelCount);
	}



	//Vars for camera movement

	Transform camObj;
	bool cameraMove;

	Vector3 startPos;
	Vector3 endPos;
	float startTime;
	float journeyLength;
	public float speed;
	float cameraRotSpeed = 0.3f;
	bool isSpeedBoosting;

	//Vars for puzzleEvent
	void Start () {
		s_instance = this;
	}

	public delegate void HoldingDownDelegate();
	public static event HoldingDownDelegate OnHoldingDown;
	
	public delegate void ReleaseDelegate();
	public static event ReleaseDelegate OnRelease;



	// Update is called once per frame
	void Update () {

		if(cameraMove){
			if (camObj.childCount >= 2 && camObj.GetChild(0).gameObject.name == "lookAtObj") {
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
			else if (camObj.childCount < 2) {
				float distCovered = (Time.time-startTime)*speed;
				float fracJourney = distCovered/journeyLength;
				Camera.main.transform.position = Vector3.Lerp(startPos, endPos, fracJourney);
				if(fracJourney > 1.0f) {
					cameraMove = false;
				}
			}
		}

		//handles input
		#if UNITY_EDITOR
		
		if (Input.GetMouseButtonDown(0) && OnHoldingDown != null) //event called on right-click down
		{
			OnHoldingDown();
		}
		
		if (Input.GetMouseButtonUp(0) && OnRelease != null) //event called on right-click up
		{
			OnRelease();
		}
		
		#elif UNITY_ANDROID
		
		if (Input.GetTouch(0).phase == TouchPhase.Began) //when finger is held down
		{
			OnHoldingDown();
		}
		
		if (Input.GetTouch(0).phase == TouchPhase.Ended) //when finger is held down
		{
			OnRelease();
		}
		#endif

	}



	public void HandleClick(GameObject objClicked){
		switch(objClicked.tag){
		case "cameraMove":
			if (AudioManager.s_instance != null)
				AudioManager.s_instance.PlayAudioSource("moveToWaypoint");
			cameraMove = true;
			startPos = Camera.main.transform.position;
			endPos = objClicked.transform.position;
			journeyLength = Vector3.Distance(startPos, endPos);
			startTime = Time.time;
			camObj = objClicked.transform; //gets the transform of the collider
			break;
		
		default:
		print("UNRECOGNIZED TAG");
		break;
		}
	}



}

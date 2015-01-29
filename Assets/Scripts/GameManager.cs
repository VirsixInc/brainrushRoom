using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

  public GameObject highlightedObj;

  //Vars for camera movement

  Transform camObj;
  bool cameraMove;

  Vector3 startPos;
  Vector3 endPos;
  float startTime;
  float journeyLength;
  float speed = 3f;
  float cameraRotSpeed = 0.5f;


  //Vars for puzzleEvent
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    if(cameraMove){
      float distCovered = (Time.time-startTime)*speed;
      float fracJourney = distCovered/journeyLength;
      Camera.main.transform.position = Vector3.Lerp(startPos, endPos, fracJourney);
      Vector3 pos = camObj.GetChild(0).transform.position-Camera.main.transform.position;
      Quaternion newRot = Quaternion.LookRotation(pos);
      Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, newRot, cameraRotSpeed);
      print("Frac: " + fracJourney);
      print("CamRot: " + Camera.main.transform.rotation + "    NewRot: " + newRot);
      
      if(fracJourney > 1.0f && Camera.main.transform.rotation == newRot){
        cameraMove = false;
        print("CAM DONE MOVING");
      }
      //Camera.main.transform.LookAt(camObj.GetChild(0));
    }
	}

  public void setHighlightedObj(GameObject obj){
    highlightedObj = obj;
  }
  
  public void wrongItem(){
    highlightedObj.SendMessage("highlight", false);
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
        camObj = objClicked.transform;
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

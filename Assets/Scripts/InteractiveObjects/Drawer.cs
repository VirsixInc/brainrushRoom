using UnityEngine;
using System.Collections;

public class Drawer : MonoBehaviour {
	bool isDrawing = false;
	bool isPulledOut = false;
	float startTime;
	float speed = 3;
	public float journeyLength;
	float currentX;
	public float directionInversion = 1;

	//NOTE: The drawer must have two child transforms, one where it is, and one where its pull out to
	void Awake() {
		currentX = transform.localPosition.x;
	}

	// Use this for initialization
	void OnClick () {
		if (isDrawing == false) { //so that you cant glitch open in the middle of a pull out
						startTime = Time.time;
						isDrawing = true;
				}
	}
	
	// Update is called once per frame
	void Update () {
		if(isDrawing){
			if (!isPulledOut){
			float distCovered = (Time.time-startTime)*speed;
			float fracJourney = distCovered/journeyLength;
				transform.localPosition = Vector3.Lerp(new Vector3(currentX, transform.localPosition.y, transform.localPosition.z),new Vector3(directionInversion*(currentX - journeyLength), transform.localPosition.y, transform.localPosition.z), fracJourney);
			if(fracJourney > 1.0f){
				isDrawing = false;
				isPulledOut = true;
			}
			}
			else {
				print ("else");

				float distCovered = (Time.time-startTime)*speed;
				float fracJourney = distCovered/journeyLength;
				transform.localPosition = Vector3.Lerp(new Vector3(directionInversion*(currentX - journeyLength), transform.localPosition.y, transform.localPosition.z),new Vector3(currentX, transform.localPosition.y, transform.localPosition.z), fracJourney);
				if(fracJourney > 1.0f){
					isDrawing = false;
					isPulledOut = false;
				}
			}
}
	}
}
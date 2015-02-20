using UnityEngine;
using System.Collections;

public class Drawer : MonoBehaviour {
	bool isDrawing = false;
	bool isPulledOut = false;
	float startTime;
	float speed = 3, journeyLength = 5;
	float currentX;

	//NOTE: The drawer must have two child transforms, one where it is, and one where its pull out to
	void Awake() {
		currentX = transform.position.x;
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
				transform.position = Vector3.Lerp(new Vector3(currentX, transform.position.y, transform.position.z),new Vector3(currentX - journeyLength, transform.position.y, transform.position.z), fracJourney);
			if(fracJourney > 1.0f){
				isDrawing = false;
				isPulledOut = true;
			}
			}
			else {
				print ("else");

				float distCovered = (Time.time-startTime)*speed;
				float fracJourney = distCovered/journeyLength;
				transform.position = Vector3.Lerp(new Vector3(currentX - journeyLength, transform.position.y, transform.position.z),new Vector3(currentX, transform.position.y, transform.position.z), fracJourney);
				if(fracJourney > 1.0f){
					isDrawing = false;
					isPulledOut = false;
				}
			}
}
	}
}
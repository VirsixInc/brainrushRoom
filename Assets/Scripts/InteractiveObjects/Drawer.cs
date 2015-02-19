using UnityEngine;
using System.Collections;

public class Drawer : MonoBehaviour {
	bool isDrawing = false;
	bool isPulledOut = false;
	float startTime;
	float speed, journeyLength;

	//NOTE: The drawer must have two child transforms, one where it is, and one where its pull out to

	void Start () {
		journeyLength = Vector3.Distance (transform.GetChild (0).position, transform.GetChild (1).position);
	}

	// Use this for initialization
	void OnClick () {
		startTime = Time.time;
		isDrawing = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(isDrawing){
			if (isPulledOut){
			float distCovered = (Time.time-startTime)*speed;
			float fracJourney = distCovered/journeyLength;
			transform.position = Vector3.Lerp(transform.GetChild (0).position, transform.GetChild (1).position, fracJourney);
			if(fracJourney > 1.0f){
				isDrawing = false;
				isPulledOut = true;
			}
			}
			else {
				float distCovered = (Time.time-startTime)*speed;
				float fracJourney = distCovered/journeyLength;
				transform.position = Vector3.Lerp(transform.GetChild (0).position, transform.GetChild (1).position, fracJourney);
				if(fracJourney > 1.0f){
					isDrawing = false;
					isPulledOut = true;
				}
			}
}
	}
}
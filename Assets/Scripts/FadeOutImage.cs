using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeOutImage : MonoBehaviour {
	
	public bool fadeOut;
	public float startTime, fadeTime = 3;
	public Image thisImage;
	
	void Update() {
		if (fadeOut) {
			float timePassed = (Time.time - startTime);
			float fracJourney = timePassed / fadeTime;
			thisImage.color = Color.Lerp (new Color (1f, 1f, 1f, .75f), new Color (1f, 1f, 1f, 0f), fracJourney);
		}
	}
	
	public void StartFade() {
		startTime = Time.time;
		fadeOut = true;
	}
}
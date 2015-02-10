using UnityEngine;
using System.Collections;

public class Puzzle1 : MonoBehaviour {

	public GameObject[] winConditions;
	bool win = false;
	GameObject winningSpotlight;

	// Use this for initialization
	void Start () {
		winningSpotlight = GameObject.Find("Spotlight1");
	}
	
	// Update is called once per frame
	void Update () {
		if(!win)
		WinCheck ();
	}

	void WinCheck(){
		int count = 0;
		foreach (GameObject x in winConditions) {
			if (x.activeSelf) {
				count++;
			}
		}
		if (count == winConditions.Length) {
			win = true;
			StartCoroutine("Win");
		}
	}

	IEnumerator Win(){
		AudioManager.s_instance.PlayAudioSource ("success");
		while (winningSpotlight.GetComponent<Light>().spotAngle < 160) {
			yield return new WaitForEndOfFrame();
			winningSpotlight.GetComponent<Light>().spotAngle+=5;
		}
		
	}
}

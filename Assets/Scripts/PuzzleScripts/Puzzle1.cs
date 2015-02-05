using UnityEngine;
using System.Collections;

public class Puzzle1 : MonoBehaviour {

	public GameObject[] winConditions = new GameObject[4];
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

		while (winningSpotlight.GetComponent<Light>().spotAngle < 115) {
			yield return new WaitForEndOfFrame();
			winningSpotlight.GetComponent<Light>().spotAngle+=5;
		}
		
	}
}

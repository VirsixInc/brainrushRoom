using UnityEngine;
using System.Collections;

public class Puzzle1 : MonoBehaviour {

	public GameObject[] winConditions;
	bool win = false;
	public GameObject winningPuzzleLight;
	
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
			Win ();
		}
	}

	void Win(){
		AudioManager.s_instance.PlayAudioSource ("success");
		winningPuzzleLight.GetComponent<Light> ().enabled = true;
		
	}
}

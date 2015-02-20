using UnityEngine;
using System.Collections;

public class CassettePlayer : MonoBehaviour {
	public GameObject tape;
	// Use this for initialization
	void OnClick () {
		if (tape.activeSelf) {
			GetComponent<Animator> ().SetTrigger ("start");
			AudioManager.s_instance.PlayAudioSource("music1");
			AudioManager.s_instance.PlayAudioSource("loadUp");
		}

	}
}

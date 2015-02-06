using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public static AudioManager s_instance;

	public void PlayAudioSource(string audioSourceName) {
		GameObject temp = GameObject.Find (audioSourceName);
		temp.GetComponent<AudioSource> ().Play ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
	public GameObject key;
	bool hasBeenOpened = false;

	// Update is called once per frame
	void Update () {
		if (hasBeenOpened == false) {
			if (key.activeSelf == true && key != null){
				GetComponent<Animator>().SetTrigger("start");
			}
		}
	}
}

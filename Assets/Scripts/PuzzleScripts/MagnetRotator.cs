using UnityEngine;
using System.Collections;

public class MagnetRotator : MonoBehaviour {
	
	
	public bool bothRotating = false;
	public Light bulb;
	public GameObject bulbToBePlaced;
	public GameObject key;
	public Animator leverA, leverB;
	public GameObject mag1,mag2,mag3,mag4;

	// Update is called once per frame
	void Update () {

		if (leverA.GetCurrentAnimatorStateInfo (0).IsName ("lever2") && leverB.GetCurrentAnimatorStateInfo (0).IsName ("lever2")) {
			bothRotating = true;	
		}

		if (bothRotating && bulbToBePlaced.activeSelf && mag1.activeSelf&& mag2.activeSelf&& mag3.activeSelf&& mag4.activeSelf) {
			bulb.enabled = true;
		} 

	}

}

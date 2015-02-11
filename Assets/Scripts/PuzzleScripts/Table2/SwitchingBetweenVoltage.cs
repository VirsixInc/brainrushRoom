using UnityEngine;
using System.Collections;

public class SwitchingBetweenVoltage : MonoBehaviour {


	public bool is110v = false;
	public Light bulb;
	public GameObject bulbToBePlaced;
	public Animator switchMover;
	
	// Update is called once per frame
	void Update () {
		if (bulbToBePlaced.activeSelf == true) {
			bulb.enabled = true;
			if (is110v) {
				bulb.intensity = 4;
			}
			else
				bulb.intensity = 2;
			
		}
	}

	void OnMouseDown () {
		switchMover.SetTrigger ("start");
		is110v = !is110v;
	}
}

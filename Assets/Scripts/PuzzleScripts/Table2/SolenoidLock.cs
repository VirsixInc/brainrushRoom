using UnityEngine;
using System.Collections;

public class SolenoidLock : MonoBehaviour {

	// Use this for initialization
	public GameObject battery;
	public bool isOn = false;
	
	// Update is called once per frame
	void Update () {
		if (!isOn && battery.activeSelf == true){
			isOn = true;
			Finish();
		}
	}

	void Finish() {
		//bring out the wire to make the electromagnet


	}
}

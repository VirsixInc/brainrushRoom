using UnityEngine;
using System.Collections;

public class MagnetRotator : MonoBehaviour {
	
	
	public bool fullPower = false;
	public Light bulb;
	public GameObject bulbToBePlaced;
	public GameObject key;
	
	// Update is called once per frame
	void Update () {
		if (bulbToBePlaced.activeSelf == true) {
			bulb.enabled = true;
			if (fullPower) {
				bulb.intensity = 4;
				key.SetActive (true);
			}
			else
				bulb.intensity = 2;
		}
	}

}

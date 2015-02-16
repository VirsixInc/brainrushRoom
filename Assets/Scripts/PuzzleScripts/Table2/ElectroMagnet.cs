using UnityEngine;
using System.Collections;

public class ElectroMagnet : MonoBehaviour {

	public GameObject wire, battery;
	bool isComplete;
	public Animator robotArm;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!isComplete) {

			if (wire.activeSelf && battery.activeSelf) {
				isComplete = true;
				ExecuteWinFunction();
			}
		}
	}

	void ExecuteWinFunction() {
		// have animator of arm
		if (robotArm != null)
			robotArm.SetTrigger ("start");
	}
}

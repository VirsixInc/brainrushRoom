using UnityEngine;
using System.Collections;

public class BreakerBox : MonoBehaviour {

	public Light[] overheadLights;
	public Animator breakerSwitch;
	void OnMouseDown() {
		breakerSwitch.SetTrigger ("pull");
	}
}

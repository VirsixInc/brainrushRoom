using UnityEngine;
using System.Collections;

public class BreakerBox : MonoBehaviour {

	public Light[] overheadLights;
	public Animator breakerSwitch;
	void OnMouseDown() {
		breakerSwitch.SetTrigger ("pull");
		StartCoroutine ("TurnOnLights");



	}

	IEnumerator TurnOnLights() {
		while (!breakerSwitch.GetCurrentAnimatorStateInfo(0).IsName("Rotate-70")) {
			yield return new WaitForSeconds(0);
		}
		print ("LIGHTS");

		foreach (Light x in overheadLights)
			x.gameObject.SetActive (true);
	}

}

using UnityEngine;
using System.Collections;

public class BreakerBox : MonoBehaviour {

	public Light[] overheadLights;
	public Animator breakerSwitch;
	public GameObject breakerHandle;
	bool hasBeenPulled = false;
	void OnClick() {
		if (breakerHandle.activeSelf && hasBeenPulled == false) {
			hasBeenPulled = true;
			breakerSwitch.SetTrigger ("start");
			StartCoroutine ("TurnOnLights");
		}
	}

	IEnumerator TurnOnLights() {
		AudioManager.s_instance.PlayAudioSource ("success");
		while (!breakerSwitch.GetCurrentAnimatorStateInfo(0).IsName("On")) {
			yield return new WaitForSeconds(0);
		}
		print ("LIGHTS");

		foreach (Light x in overheadLights)
			x.gameObject.SetActive (true);
		Camera.main.transform.GetChild (0).gameObject.SetActive (false);
	}

}

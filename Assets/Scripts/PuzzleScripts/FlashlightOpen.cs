using UnityEngine;
using System.Collections;

public class FlashlightOpen : MonoBehaviour {
	Animator myAnimator;
	public GameObject myLight;
	public GameObject battery;
	// Use this for initialization
	void Start () {
		myAnimator = gameObject.GetComponent<Animator>();

	}

	void PickUpFlashlight() {
		print ("PICKUP");
			Camera.main.transform.GetChild(0).gameObject.SetActive(true);
			gameObject.SetActive(false);

	}

	void OnMouseDown(){
		myAnimator.SetTrigger("switch");
		if (myLight.activeSelf == true && battery.activeSelf == true && myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Flashlight_Closed")) {
			PickUpFlashlight();
		}
	}
}

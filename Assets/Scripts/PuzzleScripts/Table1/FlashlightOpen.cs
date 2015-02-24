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
		InventoryManager.s_instance.addItemToInventory (gameObject);
		gameObject.SetActive(false);
		AudioManager.s_instance.PlayAudioSource ("success");

	}

	void OnClick(){
		myAnimator.SetTrigger("switch");
		if (myLight.activeSelf == true && battery.activeSelf == true && myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Flashlight_Closed")) {
			PickUpFlashlight();
		}
	}
}

using UnityEngine;
using System.Collections;

public class FlashlightOpen : MonoBehaviour {
	Animator myAnimator;
	public BoxCollider frontCollider;
	public BoxCollider backCollider;
	public GameObject myLight;
	public GameObject battery;
	public bool isBuilt = false;
	bool lightOn = false;
	// Use this for initialization
	void Start () {
		myAnimator = gameObject.GetComponent<Animator>();

	}

	void PickUpFlashlight() {
		print ("PICKUP");
			Camera.main.transform.GetChild(0).gameObject.SetActive(true);
			lightOn = true;
			gameObject.SetActive(false);

	}

	void OnMouseDown(){
		if(myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Open")){
			backCollider.enabled = false;
			myAnimator.SetTrigger("switch");
			if(!isBuilt && myLight.activeSelf == true && battery.activeSelf == true){
				isBuilt = true;
				print ("BUILT");
			}
		}
		else if(!myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Open")){
			backCollider.enabled = true;
			myAnimator.SetTrigger("switch");
		}
//		else if (isBuilt) {
//			PickUpFlashlight();
//		}
	}
}

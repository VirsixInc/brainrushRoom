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
		if(isBuilt && !lightOn){
			Camera.main.transform.GetChild(0).gameObject.SetActive(true);
			lightOn = true;
			gameObject.SetActive(false);
		}

	}

	void OnMouseDown(){
		if(myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Open")){
			frontCollider.enabled = false;
			backCollider.enabled = false;
			myAnimator.SetTrigger("switch");
			if(!isBuilt){
				if(myLight.activeSelf == true && battery.activeSelf){
					print(isBuilt.ToString());
					isBuilt = true;
				}
			}

		}
		else if(!myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Open")){

			frontCollider.enabled = true;
			backCollider.enabled = true;
			myAnimator.SetTrigger("switch");
		}
	}
}

using UnityEngine;
using System.Collections;

public class FlashlightOpen : MonoBehaviour {
	Animator myAnimator;
	BoxCollider myCollider;
	public BoxCollider frontCollider;
	public BoxCollider backCollider;
	public GameObject light;
	public GameObject battery;
	public bool isBuilt = false;
	bool lightOn = false;
	// Use this for initialization
	void Start () {
		myAnimator = gameObject.GetComponent<Animator>();
		myCollider = gameObject.GetComponent<BoxCollider>();

	}

	void PickUpFlashlight() {
		//print (isBuilt.ToString () + "     " + lightOn.ToString ());
		if(isBuilt && !lightOn){
			Camera.main.transform.GetChild(0).gameObject.SetActive(true);
			Debug.Log ("lightOn");
			lightOn = true;
			gameObject.SetActive(false);
		}

	}

	void OnMouseDown(){
		if(myAnimator.GetBool("isOpen")){
			frontCollider.enabled = false;
			backCollider.enabled = false;
			myAnimator.SetBool("isOpen", false);
			if(!isBuilt){
				print (light.activeSelf.ToString() + "     " + battery.activeSelf.ToString() );
				if(light.activeSelf == true && battery.activeSelf){
					print(isBuilt.ToString());
					isBuilt = true;
				}
			}

		}
		else if(!myAnimator.GetBool("isOpen")){

			frontCollider.enabled = true;
			backCollider.enabled = true;
			myAnimator.SetBool("isOpen", true);
		}
	}
}

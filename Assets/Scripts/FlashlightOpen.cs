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
	
	// Update is called once per frame
	void Update () {
		if(!isBuilt){
			if(light.activeSelf && battery.activeSelf){
				isBuilt = true;
			}
		}
		else if(!lightOn){
			Camera.main.transform.GetChild(0).gameObject.SetActive(true);
			lightOn = true;
		}


	}

	void OnMouseDown(){
		if(myAnimator.GetBool("isOpen")){
			frontCollider.enabled = false;
			backCollider.enabled = false;
			myAnimator.SetBool("isOpen", false);
		}
		else if(!myAnimator.GetBool("isOpen")){
			frontCollider.enabled = true;
			backCollider.enabled = true;
			myAnimator.SetBool("isOpen", true);
		}
	}
}

using UnityEngine;
using System.Collections;

public class PlayAnimation : MonoBehaviour {

	public Animator myAnimator;
	public GameObject activationObject;

	// Use this for initialization
	void Start () {
		myAnimator = gameObject.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		if(activationObject != null){
			playAnimation(activationObject);
		}

	}

	void playAnimation(GameObject activator){

		if(activator.activeSelf){
			myAnimator.SetBool("isOpen", true);
		}
	}
}

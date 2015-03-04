using UnityEngine;
using System.Collections;

public class OSBlastDoor : MonoBehaviour {
	public  Animator myAnim;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){
		myAnim.SetTrigger ("start");
	}
}

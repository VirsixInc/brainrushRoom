using UnityEngine;
using System.Collections;

public class waypointObj : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "MainCamera") {
			transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
		}


	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "MainCamera") {
			transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true;
		}
		
		
	}
}

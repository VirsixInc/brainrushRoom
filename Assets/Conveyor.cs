using UnityEngine;
using System.Collections;

public class Conveyor : MonoBehaviour {

	bool isTriggerFlipped = false;
	public GameObject pieceOfMagnet, lever;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		pieceOfMagnet.GetComponent<Animator> ().SetTrigger ("start");
		lever.GetComponent<Animator> ().SetTrigger ("start");

	}
}

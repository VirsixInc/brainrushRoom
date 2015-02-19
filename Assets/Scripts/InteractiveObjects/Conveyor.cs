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

	void OnClick() {
		if (isTriggerFlipped == false) {
			pieceOfMagnet.GetComponent<Animator> ().SetTrigger ("start");
			lever.GetComponent<Animator> ().SetTrigger ("start");
			AudioManager.s_instance.PlayAudioSource("rattleSnake");
			isTriggerFlipped = true;
		}
	}
}

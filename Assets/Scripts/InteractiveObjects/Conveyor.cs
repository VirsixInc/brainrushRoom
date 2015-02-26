using UnityEngine;
using System.Collections;

public class Conveyor : MonoBehaviour {

	bool isTriggerFlipped = false;
	public GameObject pieceOfMagnet, lever;


	void OnClick() {
		if (isTriggerFlipped == false) {
			pieceOfMagnet.GetComponent<Animator> ().SetTrigger ("start");
			lever.GetComponent<Animator> ().SetTrigger ("start");
			AudioManager.s_instance.PlayAudioSource("rattleSnake");
			isTriggerFlipped = true;
		}
	}
}

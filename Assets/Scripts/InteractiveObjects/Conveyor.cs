using UnityEngine;
using System.Collections;

public class Conveyor : MonoBehaviour {

	bool isTriggerFlipped = false;
	public GameObject pieceOfMagnet, lever;
	public Animator engine;


	void OnClick() {
		if (isTriggerFlipped == false) {
			if (pieceOfMagnet != null)
				pieceOfMagnet.GetComponent<Animator> ().SetTrigger ("start");
			lever.GetComponent<Animator> ().SetTrigger ("start");
			engine.SetTrigger("start");
			AudioManager.s_instance.PlayAudioSource("rattleSnake");
			isTriggerFlipped = true;
		}
	}
}

using UnityEngine;
using System.Collections;

public class KeyPiece : MonoBehaviour {

	//key piece needs a special particle effect to show that it is different than other objects

	public string soundFileName;
	public bool isOnclickable = true;
	
	
	void OnClick() {
		renderer.enabled = false;
		collider.enabled = false;
		InventoryManager.s_instance.PickUpKey ();
		AudioManager.s_instance.PlayAudioSource (soundFileName);
		
	}

}

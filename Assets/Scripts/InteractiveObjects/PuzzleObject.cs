using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PuzzleObject : MonoBehaviour {

	public GameObject gameObjectInActivatedState;
	public Sprite inventoryImage;
	public string soundFileName;
	public bool isOnclickable = true;
	public string displayNotification = "Picked up a PuzzleObject";


	void OnClick() {
		if (isOnclickable) {
			renderer.enabled = false;
			collider.enabled = false;
			InventoryManager.s_instance.addItemToInventory (gameObject);
			AudioManager.s_instance.PlayAudioSource (soundFileName);
			InventoryManager.s_instance.SetNotification(displayNotification);
		}
	}
	
}

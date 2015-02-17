﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PuzzleObject : MonoBehaviour {

	public GameObject gameObjectInActivatedState;
	public Sprite inventoryImage;
	public string soundFileName;


	void OnMouseDown() {
		renderer.enabled = false;
		collider.enabled = false;
		InventoryManager.s_instance.addItemToInventory (gameObject);
		AudioManager.s_instance.PlayAudioSource (soundFileName);
//		ViewControl.s_instance.


	}
	
}

﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PuzzleObject : MonoBehaviour {

	public string nameOfObject;
	public string filePath;
	public GameObject gameObjectInActivatedState;
	public Image inventoryImage;


	void OnMouseDown() {
		renderer.enabled = false;
		InventoryManager.s_instance.addItemToInventory (gameObject);

	}
	
}

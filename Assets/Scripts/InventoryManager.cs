using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class InventoryManager : MonoBehaviour {

	//InventoryManager makes sure that only one slot is highlighted at a time.
	//InventoryManager makes sure that new items goto the correct spot in the inventory aka it manages the array of InventorySlot
	//Does Inventory need to be carried across levels?
	//NOTE: InventoryManager must be on a canvas and the canvas must be called "InventoryManager"

	public static InventoryManager s_instance;

	public int numberOfItemsInInventory = 5;
	public float distanceBetweenInventoryItems, inventoryX, inventoryY, inventoryZ; //set up position of inventory
	public GameObject inventorySlotPrefab;
	public List<GameObject> inventory;
	public int currentHighlightedSlot = 0;
	public bool isASlotHighlighted = false; 


	void Start() {
		s_instance = this;
		//populates the inventory with Inventory Slots - modularly
		for (int i = 0; i < numberOfItemsInInventory; i++) {
			GameObject tempSlot;
			tempSlot = Instantiate(inventorySlotPrefab,new Vector3(inventoryX, inventoryY + (i * distanceBetweenInventoryItems), inventoryZ),Quaternion.identity) as GameObject;
			tempSlot.GetComponent<InventorySlot>().index = i;
			inventory.Add(tempSlot);

		}
	}

	public void HighLightItem(int i) {
		//if clicking on an item that is currently highlighted -> unhighlight it
		if (inventory [i].GetComponent<InventorySlot> ().isHighlighted == true) {
			inventory [i].GetComponent<InventorySlot> ().UnHighlightItem();
			isASlotHighlighted = false;
		}
		//when click on an unhighlighted spot
		else {
			print ("else");
			inventory [i].GetComponent<InventorySlot> ().HighlightItem();
			if (i != currentHighlightedSlot) {
				inventory [currentHighlightedSlot].GetComponent<InventorySlot> ().UnHighlightItem(); //if another is highlighted DE-highlight it
				print ("index");
			}
			currentHighlightedSlot = i;
			isASlotHighlighted = true;

		}
	}

	public void UseItem(string key) {
		//where key would goto lock, key could be key for door, plug for sockey, ammo for gun etc...
		if (isASlotHighlighted)
			if (inventory [currentHighlightedSlot].GetComponent<InventorySlot> ().childedPuzzleObject.GetComponent<PuzzleObject> ().name == key) {
				//do something
				inventory [currentHighlightedSlot].GetComponent<InventorySlot> ().UseItem(); //needs to be way modified
				
			}
	}

	public void addItemToInventory(GameObject item){
		foreach (GameObject x in inventory) {
			//find the first empty spot and put it there
			if (x.GetComponent<InventorySlot>().childedPuzzleObject == null) {
				x.GetComponent<InventorySlot>().childedPuzzleObject = item;
			}
		}
	}

	public void unHighlightCurrent(){
		inventory [currentHighlightedSlot].GetComponent<InventorySlot> ().UnHighlightItem ();
		isASlotHighlighted = false;
	}

}

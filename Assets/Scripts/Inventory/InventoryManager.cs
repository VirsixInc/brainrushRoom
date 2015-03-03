using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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
	public int keyPiecesPickedup = 0, currentKey = 0;
	public Text keyPieces, notificationText;
	public GameObject[] keys; //maybe we need some sort of animation to play when we put in these keys into the doors
	bool fadeOut;
	float startTime, fadeTime = 3;

	void Start() {
		notificationText = GameObject.Find ("Notification").GetComponent<Text>();
		s_instance = this;
		//populates the inventory with Inventory Slots - modularly
		for (int i = 0; i < numberOfItemsInInventory; i++) {
			GameObject tempSlot;
			tempSlot = Instantiate(inventorySlotPrefab, new Vector3(inventoryX, inventoryY + (i * distanceBetweenInventoryItems), inventoryZ),Quaternion.identity) as GameObject;
			tempSlot.GetComponent<InventorySlot>().index = i;
			inventory.Add(tempSlot);

		}
	}

	public void SetNotification(string notification) {
		notificationText.text = notification;
		notificationText.color = new Color (1f, 1f, 1f, 1f);
		startTime = Time.time;
		fadeOut = true;
	}



	void Update() {
		keyPieces.text = keyPiecesPickedup.ToString () + " / 3";
		if (fadeOut) {
			float timePassed = (Time.time - startTime);
			float fracJourney = timePassed / fadeTime;
			notificationText.color = Color.Lerp (new Color (1f, 1f, 1f, 1f), new Color (1f, 1f, 1f, 0f), fracJourney);
			if (notificationText.color.a == 0) {
				fadeOut = false;
			}
		}
		

	}

	public void PickUpKey() {
		keyPiecesPickedup ++;
		if (keyPiecesPickedup == 3) {
			addItemToInventory(keys[currentKey]);
			keyPiecesPickedup = 0;
			currentKey++;
		}

	}

	public void HighLightItem(int i) {
		AudioManager.s_instance.PlayAudioSource ("inventory");
		//if clicking on an item that is currently highlighted -> unhighlight it

		if (inventory [i].GetComponent<InventorySlot> ().isFlashlight == true) {
			CameraController.s_instance.ToggleFlashLight();
		}

		else if (inventory [i].GetComponent<InventorySlot> ().isHighlighted == true) {
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
		//print (isASlotHighlighted.ToString ());
		if (isASlotHighlighted && inventory [currentHighlightedSlot].GetComponent<InventorySlot> ().childedPuzzleObject != null) {
			//print (inventory [currentHighlightedSlot].GetComponent<InventorySlot> ().childedPuzzleObject.GetComponent<PuzzleObject> ().name + " ? " + key);
			if (inventory [currentHighlightedSlot].GetComponent<InventorySlot> ().childedPuzzleObject.GetComponent<PuzzleObject> ().name == key) {
				inventory [currentHighlightedSlot].GetComponent<InventorySlot> ().childedPuzzleObject.GetComponent<PuzzleObject> ().gameObjectInActivatedState.SetActive(true); //object double is activated in scene+
				inventory [currentHighlightedSlot].GetComponent<InventorySlot> ().childedPuzzleObject.SetActive(false);
				inventory [currentHighlightedSlot].GetComponent<InventorySlot> ().childedPuzzleObject = null;
				inventory [currentHighlightedSlot].GetComponent<InventorySlot> ().UseItem();
				inventory [currentHighlightedSlot].GetComponent<InventorySlot> ().UnHighlightItem();

				isASlotHighlighted = false;
			}
		}

	}

	public void addItemToInventory(GameObject item){
		foreach (GameObject x in inventory) {
			//find the first empty spot and put it there
			if (x.GetComponent<InventorySlot>().childedPuzzleObject == null) {
				x.GetComponent<InventorySlot>().AttachItem(item);
				break;
			}
		}
	}

	public void unHighlightCurrent(){
		inventory [currentHighlightedSlot].GetComponent<InventorySlot> ().UnHighlightItem ();
		isASlotHighlighted = false;
	}

}

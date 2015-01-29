using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
	
	public GameObject childedPuzzleObject; //the key that goes to the chest
	Image thisImage;
	public bool isHighlighted = false;
	public int index;

	void Start() {
		GameObject tempGO = GameObject.Find ("InventoryManager") as GameObject;
		gameObject.transform.SetParent(tempGO.transform);
		thisImage = GetComponent<Image> ();
	}

	public void onClick() {
		transform.parent.SendMessage ("HighLightItem", index);
	}

	//happens when you have a match with the chest in the scene
	public void UseItem () {
		isHighlighted = false;
		childedPuzzleObject = null;
	}

	public void HighlightItem () {
		print ("highlight");
		isHighlighted = true;
//		GameManager.SendMessage("setHighlightedObj", childedPuzzleObject);
		thisImage.color = Color.green;
	}

	public void UnHighlightItem () {
		isHighlighted = false;
		thisImage.color = Color.black;
	}

}

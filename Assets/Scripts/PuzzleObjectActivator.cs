using UnityEngine;
using System.Collections;

public class PuzzleObjectActivator : MonoBehaviour {

	public string key;
	public string optionalMessage;
	

	void OnMouseDown() {
		InventoryManager.s_instance.UseItem (key);
	}
}

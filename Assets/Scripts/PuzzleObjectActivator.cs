using UnityEngine;
using System.Collections;

public class PuzzleObjectActivator : MonoBehaviour {

	public string key;

	void OnMouseDown() {
		GameManager.s_instance.CheckHighlightedInventoryObj (key);
	}
}

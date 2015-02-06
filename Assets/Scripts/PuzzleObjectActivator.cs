using UnityEngine;
using System.Collections;

public class PuzzleObjectActivator : MonoBehaviour {

	public string key;
	public string soundFileName;

	void OnMouseDown() {
		InventoryManager.s_instance.UseItem (key);
		AudioManager.s_instance.PlayAudioSource (soundFileName);
	}
}

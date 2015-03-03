using UnityEngine;
using System.Collections;

public class PuzzleObjectActivator : MonoBehaviour {

	public string key;
	public string soundFileName;
	public string displayNotification = "Selected PuzzleObj Activator";


	void OnClick() {
		InventoryManager.s_instance.UseItem (key);
		AudioManager.s_instance.PlayAudioSource (soundFileName);
		InventoryManager.s_instance.SetNotification(displayNotification);

	}
}

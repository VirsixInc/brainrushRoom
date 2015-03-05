using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public int level;

	void OnTriggerEnter() {
		Application.LoadLevel (level);
		GameManager.s_instance.currentGameState = GameState.StartMenu;
	}

	public void OnClick() {
		Application.LoadLevel (level);
		GameManager.s_instance.currentGameState = GameState.StartMenu;

	}
}

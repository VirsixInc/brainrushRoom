using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour {

	public GameObject inGameMenu;

	void Start(){

	}

	public void OnClick() {
		if (inGameMenu.activeSelf == false) {
			inGameMenu.SetActive (true);
			GameManager.s_instance.currentGameState = GameState.Menu;
		}
		else {
			inGameMenu.SetActive (false);
			GameManager.s_instance.currentGameState = GameState.Playing;

		}
	}
}

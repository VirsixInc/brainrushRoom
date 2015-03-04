using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour {

	public void LoadNewGame() {
		StartCoroutine ("Load");
	}


	IEnumerator Load() {
		yield return new WaitForSeconds(1f);
		Application.LoadLevel (1);
	}
}

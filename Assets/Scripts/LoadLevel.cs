using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public int level;

	void OnTriggerEnter() {
		Application.LoadLevel (level);
	}
}

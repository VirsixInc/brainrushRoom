using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {

	void OnClick() {
		GameManager.s_instance.HandleClick (gameObject);
	}
}

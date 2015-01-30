using UnityEngine;
using System.Collections;

public class clickHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
  void OnMouseDown(){
	GameManager.s_instance.SendMessage("HandleClick", gameObject);
  }
}

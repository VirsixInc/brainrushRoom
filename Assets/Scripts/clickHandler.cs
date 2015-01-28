using UnityEngine;
using System.Collections;

public class clickHandler : MonoBehaviour {

  GameObject manager;
	// Use this for initialization
	void Start () {
    manager = GameObject.Find("GameManager");
	}
	
  void OnMouseDown(){
    manager.SendMessage("HandleClick", gameObject);
  }
}

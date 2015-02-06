using UnityEngine;
using System.Collections;

public class clickHandler : MonoBehaviour {

	
  void OnMouseDown(){
	GameManager.s_instance.SendMessage("HandleClick", gameObject);
  }
}

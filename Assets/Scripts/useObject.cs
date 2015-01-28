using UnityEngine;
using System.Collections;

public class useObject : MonoBehaviour {

  public string objectRequired;
  public bool satisfied;

  GameManager manager;

  bool activated;
  

	void Start () {
    manager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
    if(satisfied && !activated){
      activated = true;
    }
	}

  void OnMouseDown(){
    if(objectRequired == manager.highlightedObj.name){
      satisfied = true;
    }else{
      satisfied = false;
      manager.SendMessage("wrongItem");
    }
  }

  void HandleClick(GameObject objClicked){
    switch(objClicked.tag){
      case "cameraMove":
        break;
      case "puzzleEvent":
        break;
    }
  }
}

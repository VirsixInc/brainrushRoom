using UnityEngine;
using System.Collections;

public class reticleAnim : MonoBehaviour {
	public float Time;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		transform.SetParent (player.transform);
		Destroy (gameObject, Time);
	}



//	public void animState(){
//		Destroy (this.gameObject);
//
//		}

}



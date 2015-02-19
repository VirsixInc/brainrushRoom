using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {


	public float offset;
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		offset = Random.Range (1f, 100f);
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("light")) {
		
			if(offset >99){
				obj.light.intensity = Random.Range (0.3f,.5f);
			}
			else
				{
					obj.light.intensity = 1;
				}

		}
	
	}
}


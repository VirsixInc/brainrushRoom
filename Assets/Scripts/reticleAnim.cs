using UnityEngine;
using System.Collections;

public class reticleAnim : MonoBehaviour {
	public float Time;

	void Update () {
		Destroy (gameObject, Time);
	}


}



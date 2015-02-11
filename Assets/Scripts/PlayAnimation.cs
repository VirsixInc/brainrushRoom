using UnityEngine;
using System.Collections;

public class PlayAnimation : MonoBehaviour {

	public bool hasPlayed = false;
	public Animator animator;
	public string animatorTrigger;
	public GameObject keyObject;

	// Update is called once per frame
	void Update () {
	if (keyObject.activeSelf == true) {
		if (!hasPlayed) {
			animator.SetTrigger (animatorTrigger);
			hasPlayed = true;
			}
		}
	}


}

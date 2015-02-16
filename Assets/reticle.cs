using UnityEngine;
using System.Collections;

public class reticle : MonoBehaviour {
	public GameObject retPrefab;
	public float clickX;
	public float clickY;
	public Vector3 camRay;
	public float zPos;

	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			clickX = Input.mousePosition.x;
			clickY = Input.mousePosition.y;
			camRay = camera.ScreenToWorldPoint (new Vector3(clickX,clickY,zPos));
			GameObject obj = (GameObject) Instantiate(retPrefab, camRay, Quaternion.identity);
			Destroy(obj, obj.animation.clip.length);
		}

	
	}
}

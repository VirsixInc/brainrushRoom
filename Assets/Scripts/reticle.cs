using UnityEngine;
using System.Collections;

public class reticle : MonoBehaviour {
	public GameObject retPrefab;
	float clickX;
	float clickY;
	Vector3 camRay;
	public float zPos;


	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			clickX = Input.mousePosition.x;
			clickY = Input.mousePosition.y;
			camRay = camera.ScreenToWorldPoint (new Vector3(clickX,clickY,zPos));
			Instantiate(retPrefab, camRay, Quaternion.identity);

		}

	
	}
}

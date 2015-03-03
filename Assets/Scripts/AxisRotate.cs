using UnityEngine;
using System.Collections;

public class AxisRotate : MonoBehaviour
{
	public float x;
	public float y;
	public float z;
	public float speed;
	
	void Update () 
	{
		transform.Rotate (new Vector3(x, y, z) * speed * Time.deltaTime);
	}
}
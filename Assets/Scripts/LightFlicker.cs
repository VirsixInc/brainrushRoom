using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

	public float fullIntensity = 1f;
	public float flickerPeriod = 1f;
	public float steadyPeriod = 2f;
	public int randomSeed = 128;
	private System.Random randomizer;
	private float offset = 0f;

	// Use this for initialization
	void Start () {
	
		randomizer = new System.Random(randomSeed);
		offset = randomizer.Next((System.Int32)steadyPeriod * 15);

	}
	
	// Update is called once per frame
	void Update () {
	
		float currentIntensity = 0f;
		float cycleTime = Time.time + offset;
		currentIntensity = Mathf.Max (Mathf.Ceil(Mathf.Sin(cycleTime/steadyPeriod)),Mathf.Ceil(Mathf.Sin (cycleTime /(2 * steadyPeriod * 0.333333F))));
		//irregular strobe
		light.intensity = Mathf.Max (currentIntensity, flicker (cycleTime/flickerPeriod)) * fullIntensity;
	}

	private float flicker (float flickerIn)
	{
		flickerIn = flickerIn - Mathf.Floor (flickerIn);
		flickerIn = 0.5f * (1f + (Mathf.Sin (3.0f / flickerIn) * Mathf.Sin (5f / (1 - flickerIn))));
		return flickerIn;
	}
}

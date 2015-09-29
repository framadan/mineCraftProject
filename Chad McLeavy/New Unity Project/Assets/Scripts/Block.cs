using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour 
{
	public GameObject block = null;
	public float breakTimerReset = 3.0f;
	public float breakTimer = 3.0f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		BlockBreak ();
	}

	void BlockBreak ()
	{
		if (breakTimer <= 0.0f) 
		{
			Destroy (block,0.0f);
		}
	}
}

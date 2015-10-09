using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour 
{
	public float breakTimerReset = 3.0f;
	public float breakTimer = 3.0f;

	public GameObject blockDrop;

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
			Instantiate (blockDrop,transform.position,transform.rotation);
			Destroy (gameObject,0.0f);
		}
	}
}

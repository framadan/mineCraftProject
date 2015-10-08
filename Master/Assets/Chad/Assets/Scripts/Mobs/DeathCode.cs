using UnityEngine;
using System.Collections;

public class DeathCode : MonoBehaviour 
{
	public int health = 20;
	public GameObject[] mobDrop = null;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Die ();
	}

	void Die ()
	{
		if (health <= 0.0f)
		{
			Instantiate (mobDrop[Random.Range (0,2)],gameObject.transform.position,gameObject.transform.rotation);
			Destroy (gameObject,0.0f);
		}
	}
}

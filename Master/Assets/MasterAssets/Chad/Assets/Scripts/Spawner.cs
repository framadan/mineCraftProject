using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
	public float fallSpeed = 15.0f;
	public float riseSpeed = 15.0f;
	public float spawnTimer = 5.0f;

	public Collider[] objects;
	public Collider[] detectBlocks;

	public GameObject[] mobs;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		DetectObjects ();
	}

	void DetectObjects ()
	{
		objects = Physics.OverlapSphere (transform.position, 1.5f);
		if (objects.Length == 1) 
		{
			transform.Translate (Vector3.down * fallSpeed * Time.deltaTime);
		}

		detectBlocks = Physics.OverlapSphere (transform.position, 1.0f);
		if (detectBlocks.Length == 1) 
		{
			spawnTimer -= Time.deltaTime;
			if (spawnTimer <= 0.0f)
			{
				Instantiate (mobs [Random.Range (0,6)],transform.position,transform.rotation);
				spawnTimer = Random.Range (10.0f,40.0f);
			}
		}

		if (detectBlocks.Length != 1) 
		{
			transform.Translate (Vector3.up * riseSpeed * Time.deltaTime);
		}
	}
}













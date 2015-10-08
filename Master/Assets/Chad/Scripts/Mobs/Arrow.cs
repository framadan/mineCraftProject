using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour 
{
	public float speed = 10.0f;
	public float destroyTimer = 5.0f;

	public AudioSource arrowHit = null;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		destroyTimer -= Time.deltaTime;
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
		if (destroyTimer <= 0.0f) 
		{
			Destroy (gameObject,0.0f);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag != "Block") 
		{
			other.gameObject.GetComponent <DeathCode>().health -= 3;
			arrowHit.Play ();
		}
		Destroy (gameObject,0.25f);
	}
}











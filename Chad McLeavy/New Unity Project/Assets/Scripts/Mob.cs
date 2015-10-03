using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour 
{
	public float speed = 1.0f;
	public float directionTimer = 0.0f;
	public float directionChange = 0.0f;

	public int health = 20;
	
	public GameObject[] mobDrop = null;
	
	// Use this for initialization
	void Start () 
	{
		directionChange = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		directionTimer += Time.deltaTime;

		ChangeDirection ();
		Die ();
	}

	void ChangeDirection () 
	{

		if (directionTimer > 5)
		{
			directionTimer = 0;
			directionChange = Random.Range (0f, 8f);
		}

		//Changing Directions
		if (directionChange >= 0 && directionChange < 2)
		{
			transform.rotation = Quaternion.Euler (0f,0f,0f);
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
		if (directionChange >= 2 && directionChange < 4)
		{
			transform.rotation = Quaternion.Euler (0f,180f,0f);
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
		if (directionChange >= 4 && directionChange < 6)
		{
			transform.rotation = Quaternion.Euler (0f,90f,0f);
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
		if (directionChange >= 6 && directionChange < 8)
		{
			transform.rotation = Quaternion.Euler (0f,-90f,0f);
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
	}

	void Die ()
	{
		if (health <= 0.0f)
		{
			Instantiate (mobDrop[Random.Range (0,1)],gameObject.transform.position,gameObject.transform.rotation);
			Destroy (gameObject,0.0f);
		}
	}
}
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public int health = 20;
	public int attack = 1;

	public float speed = 1.0f;
	public float jumpHeight = 1.0f;
	public float distance = 8.1f;

	public bool canPlaceBlocks = false;

	public GameObject testCube = null;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Movement ();
		if (Physics.Raycast (transform.position, Vector3.forward, distance)) 
		{
			canPlaceBlocks = true;
			PlaceBlocks ();
		}
	}

	void Movement ()
	{
		if (Input.GetKey (KeyCode.W))
		{
			transform.Translate (Vector3.forward * Time.deltaTime * speed);
		}
		if (Input.GetKey (KeyCode.S))
		{
			transform.Translate (Vector3.back * Time.deltaTime * speed);
		}
		if (Input.GetKey (KeyCode.A))
		{
			transform.Translate (Vector3.left * Time.deltaTime * speed);
		}
		if (Input.GetKey (KeyCode.D))
		{
			transform.Translate (Vector3.right * Time.deltaTime * speed);
		}
		if (Input.GetKeyDown (KeyCode.Space))
		{
			GetComponent<Rigidbody>().AddForce (Vector3.up * jumpHeight);
		}
	}

	void PlaceBlocks ()
	{

		if (Input.GetKeyDown (KeyCode.Mouse1) && canPlaceBlocks == true) 
		{
			Instantiate(testCube,transform.position,transform.rotation);
		}
	}

	//For when hotbar is ready
	void HotbarSwitch ()
	{
		if (Input.GetKeyDown (KeyCode.Keypad1)) 
		{
			
		}
		if (Input.GetKeyDown (KeyCode.Keypad2)) 
		{
			
		}
		if (Input.GetKeyDown (KeyCode.Keypad3)) 
		{
			
		}
		if (Input.GetKeyDown (KeyCode.Keypad4)) 
		{
			
		}
		if (Input.GetKeyDown (KeyCode.Keypad5)) 
		{
			
		}
		if (Input.GetKeyDown (KeyCode.Keypad6)) 
		{
			
		}
		if (Input.GetKeyDown (KeyCode.Keypad7)) 
		{
			
		}
		if (Input.GetKeyDown (KeyCode.Keypad8)) 
		{
			
		}
		if (Input.GetKeyDown (KeyCode.Keypad9)) 
		{
			
		}
	}
}

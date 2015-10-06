using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour 
{
	public float speed = 1.0f;
	public float directionTimer = 0.0f;
	public float directionChange = 0.0f;
	public float jumpHeight = 75f;
	public float detectDistance = 0.5f;

	public Quaternion forwardDirection = Quaternion.Euler (0f,0f,0f);
	public Quaternion backDirection = Quaternion.Euler (0f,180f,0f);
	public Quaternion leftDirection = Quaternion.Euler (0f,90f,0f);
	public Quaternion rightDirection = Quaternion.Euler (0f,-90f,0f);

	public bool canJump = true;

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
		DetectBlock ();
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
			transform.rotation = Quaternion.Slerp (transform.rotation,forwardDirection, 5f * Time.deltaTime);
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
		if (directionChange >= 2 && directionChange < 4)
		{
			transform.rotation = Quaternion.Slerp (transform.rotation,backDirection, 5f * Time.deltaTime);
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
		if (directionChange >= 4 && directionChange < 6)
		{
			transform.rotation = Quaternion.Slerp (transform.rotation,leftDirection, 5f * Time.deltaTime);
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
		if (directionChange >= 6 && directionChange < 8)
		{
			transform.rotation = Quaternion.Slerp (transform.rotation,rightDirection, 5f * Time.deltaTime);
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
	}

	void DetectBlock ()
	{
		Ray rayOrigin = new Ray (transform.position,transform.forward);
		RaycastHit hitInfo;
		if (Physics.Raycast (rayOrigin, out hitInfo, detectDistance)) 
		{
			if (hitInfo.collider.gameObject.tag == "Block" && canJump == true)
			{
				print ("hit");
				canJump = false;
				GetComponent<Rigidbody>().AddForce (transform.up * jumpHeight);
			}
		}
		if (!Physics.Raycast (rayOrigin, out hitInfo, detectDistance)) 
		{
			canJump = true;
		}
	}
}
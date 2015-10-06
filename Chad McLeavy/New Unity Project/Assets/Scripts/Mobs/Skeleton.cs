using UnityEngine;
using System.Collections;

public class Skeleton : MonoBehaviour 
{
	public float aggroRadius = 5.0f;
	public float speed = 1.0f;
	public float jumpHeight = 50.0f;

	public Collider[] possibleTarget;

	public bool canJump = true;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		FindPlayer ();
		DetectBlock ();
	}

	void FindPlayer ()
	{
		int layerMask = 1 << 8;
		possibleTarget = Physics.OverlapSphere (transform.position, aggroRadius, layerMask);
		
		if (possibleTarget.Length == 0) 
		{
			GetComponent<Mob>().enabled = true;
		}
		
		if (possibleTarget.Length > 0) 
		{
			Vector3 direction = (possibleTarget[0].transform.position - transform.position).normalized;
			Quaternion xyzRotation = Quaternion.LookRotation(direction);
			xyzRotation.x = 0f;
			xyzRotation.z = 0f;
			transform.rotation = Quaternion.Slerp (transform.rotation,xyzRotation, 5f * Time.deltaTime);
			GetComponent<Mob>().enabled = false;
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
	}
	
	void DetectBlock ()
	{
		Ray rayOrigin = new Ray (transform.position,transform.forward);
		RaycastHit hitInfo;
		if (Physics.Raycast (rayOrigin, out hitInfo, .5f)) 
		{
			if (hitInfo.collider.gameObject.tag == "Block" && canJump == true)
			{
				print ("hit");
				canJump = false;
				GetComponent<Rigidbody>().AddForce (transform.up * jumpHeight);
			}
		}
		if (!Physics.Raycast (rayOrigin, out hitInfo, .5f)) 
		{
			canJump = true;
		}
	}
}

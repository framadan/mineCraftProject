using UnityEngine;
using System.Collections;

public class Creeper : MonoBehaviour 
{
	public float aggroRadius = 5f;
	public float speed = 1.0f;
	public float jumpHeight = 50;
	public float explosionRadius = 3f;
	public float explosionTimer = 3f;

	public bool canJump = true;
	
	public Collider[] possibleTarget;
	public Collider[] explosionTarget;
	public Collider[] objectsAroundCreeper;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		FindPlayer ();
		DetectBlock ();
		Explode ();
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

	void Explode ()
	{
		int layerMask = 1 << 8;
		explosionTarget =  Physics.OverlapSphere (transform.position, explosionRadius, layerMask);
		objectsAroundCreeper =  Physics.OverlapSphere (transform.position, explosionRadius);

		if (explosionTarget.Length == 0) 
		{
			explosionTimer = 3.0f;
		}

		if (explosionTarget.Length > 0)
		{
			explosionTimer -= Time.deltaTime;
			if (explosionTimer <= 0)
			{
				foreach (Collider _object in objectsAroundCreeper)
				{
					if (_object.gameObject.tag != "Block")
					{
						_object.gameObject.GetComponent<DeathCode>().health -= 10;
					}

					if (_object.gameObject.tag == "Block")
					{
						_object.gameObject.GetComponent<Block>().breakTimer = 0.0f;
					}
				}
				Destroy (gameObject,0.25f);
			}
		}
	}
}













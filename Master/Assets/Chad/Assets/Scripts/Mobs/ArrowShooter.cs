using UnityEngine;
using System.Collections;

public class ArrowShooter : MonoBehaviour 
{
	public float aggroRadius = 5.0f;
	public float jumpHeight = 50.0f;
	public float shootTimer = 3.0f;
	
	public Collider[] possibleTarget;

	public GameObject arrow = null;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		FindPlayer ();
		ShootArrow ();
	}

	void FindPlayer ()
	{
		int layerMask = 1 << 8;
		possibleTarget = Physics.OverlapSphere (transform.position, aggroRadius, layerMask);
		
		if (possibleTarget.Length == 0) 
		{
			shootTimer = 2.0f;
		}
		
		if (possibleTarget.Length > 0) 
		{
			shootTimer -= Time.deltaTime;
			Vector3 direction = (possibleTarget[0].transform.position - transform.position).normalized;
			Quaternion xyzRotation = Quaternion.LookRotation(direction);
			transform.rotation = Quaternion.Slerp (transform.rotation,xyzRotation, 10f * Time.deltaTime);
		}
	}

	void ShootArrow ()
	{
		if (shootTimer <= 0.0f) 
		{
			Instantiate (arrow,transform.position,transform.rotation);
			shootTimer = 2.0f;
		}
	}
}










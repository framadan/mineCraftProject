using UnityEngine;
using System.Collections;

public class GunnerSkill : MonoBehaviour {
	
	//Target Enemy
	public Collider[] possibleTargets;
	public float aggroRadius = 10.0f;
	public GameObject currentTarget= null;
	public Color aggroRadiusColor;
	public bool targetAvailable = false;
	//===========Attacking=======================
	public GameObject bulletPefab = null;

	
	public float timer;
	[Range(0.0f, 3.0f)]
	public float fireRate = 1.0f;
	[Range(0.0f, 10.0f)]
	public float attackspeed = 1.0f;
	private const int SPAWN_DISTANCE = 1;
	[Range(0.0f, 1000.0f)]
	public float bulletSpeed = 1.0f;

	//=============================================
	
	//Debug//
	public bool showDebug  = false;
	
	void Awake()
	{
		
	}
	void OnDrawGizmos()
	{
		if (showDebug != true)
			return;
		Gizmos.color = aggroRadiusColor;
		Gizmos.DrawSphere (transform.position, aggroRadius);
		if (currentTarget != null) 
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine (transform.position, currentTarget.transform.position);
		}
	}
	void Update () 
	{
		possibleTargets = Physics.OverlapSphere(transform.position, aggroRadius);
		foreach (Collider possibleTarget in possibleTargets) 
		{
			if ( possibleTarget.tag != "enemy")
			{
				continue;

			}
			if (currentTarget == null)
			{
				currentTarget = possibleTarget.gameObject;


			}
			else
			{
				if(Vector3.Distance (transform.position, currentTarget.transform.position) >
				   Vector3.Distance (transform.position, possibleTarget.gameObject.transform.position))
				{
					currentTarget = possibleTarget.gameObject;
					
				}
			}
		}
		
		//currentTarget.GetComponent<Enemy1> ().EnemyDamage ();
		// ATTACK
		if (currentTarget != null) 
		{
			targetAvailable = true;
		}
		if (currentTarget == null)
		{
			targetAvailable = false;
		}
		timer += Time.deltaTime;
		if (targetAvailable == true && fireRate < timer) 
		{
			ShootAtEnemy();
			timer = 0;
			
		}
	}
	void ShootAtEnemy()
	{

		GameObject bullet = (GameObject)Instantiate (bulletPefab, transform.position,transform.rotation);
		bullet.transform.LookAt(currentTarget.transform.position);
		bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletSpeed);
	}
	
	
	
}
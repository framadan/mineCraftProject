using UnityEngine;
using System.Collections;

public class RotateToObject : MonoBehaviour 
{
	public float aggroRadius = 5f; //Radius of Detection
	public float speed = 1.0f; //Speed of Rotation
	
	public Collider[] possibleTarget;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		FindPlayer ();
	}
	
	void FindPlayer ()
	{
		int layerMask = 1 << 8; //Creates a variable to use as the "layerMask" in the next line
		possibleTarget = Physics.OverlapSphere (transform.position, aggroRadius, layerMask); //"layerMask" is only neccessary if you want to exclude objects in other layers
		Vector3 direction = (possibleTarget[0].transform.position - transform.position).normalized;
		Quaternion xyzRotation = Quaternion.LookRotation(direction); //Converts the direction variable to a quaternion
		xyzRotation.x = 0f; //Locks rotation along the x-axis
		xyzRotation.z = 0f; //Locks rotation along the z-axis
		transform.rotation = Quaternion.Slerp (transform.rotation,xyzRotation, 5f * Time.deltaTime); //Rotates
	}
}

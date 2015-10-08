using UnityEngine;
using System.Collections;

public class Raycasts : MonoBehaviour 
{
	//Ray casts do much more than place or destroy objects
	//This is just an example
	public GameObject block = null;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void UsingRaycstsToAccessObjects ()
	{
		//Places a prefab where the Raycast hit
		if (Input.GetKeyDown (KeyCode.Mouse1)) 
		{
			//Point at which the ray starts
			Ray rayOrigin = Camera.main.ScreenPointToRay (Input.mousePosition);
			//Allows the ray to return detailed info on the object it hit
			RaycastHit hitInfo;
			
			if (Physics.Raycast (rayOrigin, out hitInfo, 8.0f)) //8.0f is the max distance that you want for your ray
			{
				Instantiate (block, hitInfo.point + Vector3.up * .5f, hitInfo.collider.transform.rotation);
			}
		}

		//Destroys the object that the Raycast hit
		if (Input.GetKey (KeyCode.Mouse0)) 
		{
			Ray rayOrigin = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo;
			
			if (Physics.Raycast (rayOrigin, out hitInfo, 8.0f))
			{
				Destroy (hitInfo.collider.gameObject, 0.1f);
			}
		}
	}
}

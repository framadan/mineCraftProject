using UnityEngine;
using System.Collections;

public class InventorySpace : MonoBehaviour 
{
	public GameObject[] spaces;
	public int sCount = 0;

	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{ 
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Debug.Log (spaces[sCount]);
			sCount++;

		}
	}

	
	

	

}

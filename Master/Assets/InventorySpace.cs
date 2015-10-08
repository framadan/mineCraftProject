using UnityEngine;
using System.Collections;

public class InventorySpace : MonoBehaviour 
{
	//public GameObject[] spaces;
	//public int sCount = 0;
	public int dirt = 0;
	public int stone = 0;
	public int grass = 0;
	public int wood = 0;

	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{ 
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			dirt = dirt + 1;
			stone = stone + 1;
			grass = grass + 1;
			wood = wood + 1;
			//Debug.Log (spaces[sCount]);
			//sCount++;

		}
	}

	
	

	

}

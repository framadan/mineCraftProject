using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public GameObject inventoryPanel = null;
	public bool inventoryActive = false;


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
			if (Input.GetKeyDown (KeyCode.E)) 
		{
			inventoryPanel.SetActive(inventoryActive);
			inventoryActive = !inventoryActive;
		}

		
	}

}

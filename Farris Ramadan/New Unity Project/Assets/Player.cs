﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public GameObject inventoryPanel = null;
	public bool inventoryActive = false;
	public float distance = 10.0f;

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
	void OnMouseDrag()
	{
		Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
		Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);
	}
}
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public int stone=0;
	public int dirt = 0;
	public int wood=0;

	public GameObject hotbarReference;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckBlockCount ();
	}

	void CheckBlockCount ()
	{
		//Stone
		if (stone == 0 && hotbarReference.GetComponent<Hotbar>().slots 
		   [hotbarReference.GetComponent<Hotbar>().selectedSlot - 1].sprite != null) 
		{
			if (hotbarReference.GetComponent<Hotbar>().slots 
			   	[hotbarReference.GetComponent<Hotbar>().selectedSlot - 1].sprite.name == "Stone")
			{
				hotbarReference.GetComponent<Hotbar>().slots 
					[hotbarReference.GetComponent<Hotbar>().selectedSlot - 1].sprite = null;
				hotbarReference.GetComponent<Hotbar>().slots 
					[hotbarReference.GetComponent<Hotbar>().selectedSlot - 1].color = new Color (0,0,0,0);
			}
		}
		//Dirt
		if (dirt == 0 && hotbarReference.GetComponent<Hotbar>().slots 
		    [hotbarReference.GetComponent<Hotbar>().selectedSlot - 1].sprite != null) 
		{
			if (hotbarReference.GetComponent<Hotbar>().slots 
			    [hotbarReference.GetComponent<Hotbar>().selectedSlot - 1].sprite.name == "Dirt")
			{
				hotbarReference.GetComponent<Hotbar>().slots 
					[hotbarReference.GetComponent<Hotbar>().selectedSlot - 1].sprite = null;
				hotbarReference.GetComponent<Hotbar>().slots 
					[hotbarReference.GetComponent<Hotbar>().selectedSlot - 1].color = new Color (0,0,0,0);
			}
		}
		//Wood
		if (wood == 0 && hotbarReference.GetComponent<Hotbar>().slots 
		    [hotbarReference.GetComponent<Hotbar>().selectedSlot - 1].sprite != null) 
		{
			if (hotbarReference.GetComponent<Hotbar>().slots 
			    [hotbarReference.GetComponent<Hotbar>().selectedSlot - 1].sprite.name == "Wood")
			{
				hotbarReference.GetComponent<Hotbar>().slots 
					[hotbarReference.GetComponent<Hotbar>().selectedSlot - 1].sprite = null;
				hotbarReference.GetComponent<Hotbar>().slots 
					[hotbarReference.GetComponent<Hotbar>().selectedSlot - 1].color = new Color (0,0,0,0);
			}
		}
	}
}

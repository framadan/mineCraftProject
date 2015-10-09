using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public int stone = 0;
	public int dirt = 0;
	public int wood = 0;

	public GameObject hotbarReference;
	public GameObject player;

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
		Image hotbarSlot = hotbarReference.GetComponent<Hotbar>().slots [hotbarReference.GetComponent<Hotbar>().selectedSlot - 1];

		//Stone
		if (stone == 0 && hotbarSlot.sprite != null) 
		{
			if (hotbarSlot.sprite.name == "Stone")
			{
				hotbarSlot.sprite = null;
				hotbarSlot.color = new Color (0,0,0,0);
				hotbarSlot.GetComponent<HotbarSlots>().blockType = null;
			}
		}

		//Dirt
		if (dirt == 0)
			if (dirt == 0 && hotbarSlot.sprite != null) 
		{
			if (hotbarSlot.sprite.name == "Dirt")
			{
				hotbarSlot.sprite = null;
				hotbarSlot.color = new Color (0,0,0,0);
				hotbarSlot.GetComponent<HotbarSlots>().blockType = null;
			}
		}

		//Wood
		if (wood == 0 && hotbarSlot.sprite != null) 
		{
			if (hotbarSlot.sprite.name == "Wood")
			{
				hotbarSlot.sprite = null;
				hotbarSlot.color = new Color (0,0,0,0);
				hotbarSlot.GetComponent<HotbarSlots>().blockType = null;
			}
		}

	}
}

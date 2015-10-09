using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour 
{
	public int selectedSlot = 1;
	public int i = 0;

	public Image[] slots;
	public Image selector;

	public GameObject player;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdateScrolling ();
		UpdateSelector ();
	}

	void UpdateScrolling () 
	{
		selectedSlot += (int)Input.mouseScrollDelta.y;

		if (selectedSlot < 1) 
		{
			selectedSlot = 9;
		}
		if (selectedSlot > 9) 
		{
			selectedSlot = 1;
		}
	}

	void UpdateSelector ()
	{
		selector.rectTransform.localPosition = slots [selectedSlot - 1].rectTransform.localPosition;
		player.GetComponent<Player>().blockType = slots [selectedSlot - 1].GetComponent<HotbarSlots> ().blockType;
		player.GetComponent<Player>().armHotbarSprite = slots [selectedSlot - 1].sprite;
		player.GetComponent<Player>().armPunchSprite = slots [selectedSlot - 1].sprite;
	}

	public void UpdateItems ()
	{
		slots [8 - i].GetComponent<HotbarSlots>().blockType = player.GetComponent<Player> ().newBlockType;
		slots [8 - i].sprite = player.GetComponent<Player> ().newSprite;
		slots [8 - i].color = new Color (1, 1, 1, 1);
		i += 1;
		if (i == 9) 
		{
			i = 0;
		}
	}
}













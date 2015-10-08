using UnityEngine;
using UnityEngine.UI;
using System.Collections;




public class Crafting : MonoBehaviour 
{
	public GameObject playerObj = null;
	public Hotbar hotB = null;
	public Player playerScript = null;
	public GameManager manaScript = null;
	public Sprite shovelSprite = null;
	public Sprite swordSprite = null;
	public Sprite torchSprite = null;
	// Use this for initialization
	void Start () 
	{
		gameObject.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void Vince ()
	{
		playerScript.kraftActivity ();


	}
	public void woodenSword ()
	{
	//2wood
		if (manaScript.wood >= 2) 
		{
			manaScript.wood -= 2;
			playerScript.newSprite = swordSprite;
			hotB.UpdateItems ();

		} 

	}
	public void armor ()
	{
	//2stone/
		if (manaScript.stone >= 2) 
		{
			manaScript.stone -= 2;
			playerObj.GetComponent<DeathCode>().armor += 10;

		}
	}
	public void torch ()
	{
	//1wood
		if (manaScript.wood >= 1) 
		{
			manaScript.wood -= 1;
			playerScript.newSprite = torchSprite;
			hotB.UpdateItems ();
		}
	}
	public void shovel ()
	{
	//1wood 1stone
		if (manaScript.wood >= 2 && manaScript.stone >= 2)
		{
			manaScript.wood -= 2;
			manaScript.stone -= 2;
			playerScript.newSprite = shovelSprite;
			hotB.UpdateItems ();
		}
	}

}

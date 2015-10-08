using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{


	public GameObject Stone=null;
	public GameObject Dirt=null;
	public GameObject Grass=null;
	public GameObject Wood=null;
	public int stone=0;
	public int dirt = 0;
	public int grass=0;
	public int wood=0;
	public Text stoneText;
	public Text dirtText;
	public Text grassText;
	public Text woodText;
	

	// Use this for initialization
	void Start () 
	{
		Stone.SetActive(false);
		Dirt.SetActive(false);
		Grass.SetActive(false);
		Wood.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () 
	{	
		//Inventory tes, replace with collision
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			stone=stone+1;
			dirt=dirt+1;
			grass=grass+1;
			wood=wood+1;
		}
		//Disable material selection
		if (stone < 1) 
		{
			Stone.SetActive(false);
		}
		if (dirt < 1) 
		{
			Dirt.SetActive(false);
		}
		if (grass < 1) 
		{
			Grass.SetActive(false);
		}
		if (wood < 1) 
		{
			Wood.SetActive(false);
		}
		//Tower buying conditions
		if (stone >=1) 
		{
			Stone.SetActive(true);

		}
		if (dirt >=1) 
		{
			Dirt.SetActive(true);

		}
		if (grass >=1) 
		{
			Grass.SetActive(true);

		}
		if (wood >=1) 
		{
			Wood.SetActive(true);

		}

		stoneText.text = "   \t \t :" + stone;
		dirtText.text = "   \t \t :" + dirt;
		grassText.text = "   \t \t :" + grass;
		woodText.text = "   \t \t :" + wood;

	}

	//public void Chips ()
	//{
		//chips = chips + enemyChips;
	//}

		
}


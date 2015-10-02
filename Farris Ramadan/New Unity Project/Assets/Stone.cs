using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour 
{
	public GameManager  gm = null;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnMouseDown () 
	{
		if (gm.Stone==true)
		{
		gm.stone=gm.stone-1;
		print("Stone");
		}
		
	}
}

using UnityEngine;
using System.Collections;

public class Dirt : MonoBehaviour 
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
		if (gm.Dirt==true)
		{
			gm.dirt=gm.dirt-1;
			print("Dirt");
		}
		
	}
}
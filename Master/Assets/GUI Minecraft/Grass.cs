using UnityEngine;
using System.Collections;

public class Grass : MonoBehaviour 
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
		if (gm.Grass==true)
		{
			gm.grass=gm.grass-1;
			print("Grass");
		}
		
	}
}
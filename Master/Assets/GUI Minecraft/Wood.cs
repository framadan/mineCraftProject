using UnityEngine;
using System.Collections;

public class Wood : MonoBehaviour 
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
		if (gm.Wood==true)
		{
			gm.wood=gm.wood-1;
			print("Wood");
		}
		
	}
}
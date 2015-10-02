using UnityEngine;
using System.Collections;

public class tower1 : MonoBehaviour 
{
	public BuildPlace[] towersScripts;
	public GameObject gunnerPrefab;

	void Update () 
		{
			towersScripts = FindObjectsOfType<BuildPlace>();
			
		}



			//foreach (BuildPlace tower in towersScripts) 
			//{
				//tower.GetComponent<BuildPlace>().towerPrefab=gunnerPrefab;
			//}
}

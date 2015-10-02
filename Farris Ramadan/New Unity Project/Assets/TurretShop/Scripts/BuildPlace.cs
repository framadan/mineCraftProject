using UnityEngine;
using System.Collections;

public class BuildPlace : MonoBehaviour 
{

	public GameObject towerPrefab;
	public BuildPlace[] towersScripts;
	public bool spaceClosed = false;

	void Update()
	{
		towersScripts = FindObjectsOfType<BuildPlace>();
	}

	void OnMouseUpAsButton() 
	{
		if (spaceClosed == false) 
		{
			GameObject g = (GameObject)Instantiate (towerPrefab);
			g.transform.position = transform.position + Vector3.back;
			spaceClosed = true;
			towerPrefab = null;
			foreach (BuildPlace tower in towersScripts) 
			{
				tower.GetComponent<BuildPlace>().towerPrefab=null;
		} 

	}
	
}
}

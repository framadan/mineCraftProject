using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PerlinNoiseTest1 : MonoBehaviour
{
	public GameObject dirtBlock = null;

	public int size = 50;
	public float scale = 7.0f;
	public float scaleModifier = 5.0f;
	public float offSetHeight = 1.5f;

	public List<GameObject> squares = new List<GameObject> ();

	public bool enableHeight = true;
	public bool move = false;

	void Start()
	{
		for(var x = 0; x < size; x++)
		{
			for(var z = 0; z < size; z++)
			{
				var c = Instantiate(dirtBlock, new Vector3(x,0,z), Quaternion.identity) as GameObject;
				squares.Add(c);
					
				c.transform.parent = transform;
				
			}
		}

	}

	void Update ()
	{
		updateTransform();
	}

	void updateTransform()
	{
		foreach(Transform child in transform)
		{
			var height = Mathf.PerlinNoise(child.transform.position.x/scale, child.transform.position.z/scale);

			setMatColor(child, height);

			if(enableHeight == true)
				applyHeight(child, height);
		}

		foreach(Transform child in transform)
		{
			var height = Mathf.PerlinNoise(child.transform.position.x/scale, child.transform.position.z/scale);
			
			setMatColor(child, height);
			
			if(enableHeight == true)
				applyHeight(child, height);
		}
	}

	void setMatColor(Transform child, float height)
	{
		//child.GetComponent<Renderer>().material.color = new Color(height,height,height,height);
	}

	void applyHeight(Transform child, float height)
	{
		var yValue = Mathf.RoundToInt(height * scaleModifier);

		var newVec3 = new Vector3(child.transform.position.x, yValue, child.transform.position.z);

		child.transform.position = newVec3;
	}
}

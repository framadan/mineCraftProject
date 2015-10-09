using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthGUI : MonoBehaviour 
{
	public Text Health;

	public string health;
	
	public GameObject player = null;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Health.text = health + player.GetComponent<DeathCode>().health;
	}
}

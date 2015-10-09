using UnityEngine;
using System.Collections;

public class MobSounds : MonoBehaviour 
{
	public float timer = 10f;
	public AudioSource sound = null;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;

		if (timer <= 0.0f) 
		{
			sound.Play ();
			timer = Random.Range (7f,15f);
		}
	}
}

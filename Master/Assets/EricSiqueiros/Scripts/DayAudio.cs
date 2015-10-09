using UnityEngine;
using System.Collections;

public class DayAudio : MonoBehaviour 
{

	public AudioClip dayTimeCicle = null;
	public AudioClip nightTimeCicle = null;
	public AudioClip dayToNightCicle = null;
	public AudioClip nightToDayCicle =null;

	public bool dayTimeCicleBool = false;
	public bool nightTimeCicleBool = false;
	public bool dayToNightCicleBool = false;
	public bool nightToDayCicleBool = false;

	public AudioSource audio;

	// Use this for initialization
	void Start ()
	{
		StartAudioTransition();
		audio = GetComponent<AudioSource>();
	}

	void StartAudioTransition()
	{
		dayTimeCicleBool = true;
		nightTimeCicleBool = false;
		dayToNightCicleBool = false;
		nightToDayCicleBool = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(dayTimeCicleBool == true)
		{
			if (!audio.isPlaying) 
			{
				audio.clip = dayTimeCicle;
				audio.Play();
			}
		}
	}
}

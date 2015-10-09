using UnityEngine;
using System.Collections;

public class DayNightCycleAudio : MonoBehaviour 
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
//		dayTimeCicleBool = true;
//		nightTimeCicleBool = false;
//		dayToNightCicleBool = false;
//		nightToDayCicleBool = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		AudioChange ();
	}
	
	void AudioChange ()
	{
		if(dayTimeCicleBool == true)
		{
			audio.clip = dayTimeCicle;
			audio.Play();
			if(dayTimeCicleBool == true)
			{
				dayTimeCicleBool = false;
			}
		}
		
		if(nightTimeCicleBool == true)
		{
			audio.clip = nightTimeCicle;
			audio.Play();
			if(nightTimeCicleBool == true)
			{
				nightTimeCicleBool = false;
			}
		}
		
		if(dayToNightCicleBool == true)
		{
			audio.clip = dayToNightCicle;
			audio.Play();;
			if(dayToNightCicleBool == true)
			{
				dayToNightCicleBool  = false;
			}
		}
		
		if(nightToDayCicleBool == true)
		{
			audio.clip = nightToDayCicle;
			audio.Play();
			if(nightToDayCicleBool == true)
			{
				nightToDayCicleBool = false;
			}
		}
	}
}

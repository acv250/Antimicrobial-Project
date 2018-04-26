using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMusic : MonoBehaviour 
{

	public AudioSource musicSource;
	public bool pauseMusic;

	// Use this for initialization
	void Start () 
	{
		musicSource.Play ();
		pauseMusic = false;
	}

	public void Toggle()
	{
		if (pauseMusic) 
		{
			musicSource.UnPause ();
			pauseMusic = false;
		} else 
		{
			musicSource.Pause ();
			pauseMusic = true;
		}
	}
}

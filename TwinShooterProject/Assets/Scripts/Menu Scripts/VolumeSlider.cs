using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {

	public Slider volumeSlider;
	public AudioSource musicSource;

	// Use this for initialization
	void Start () 
	{
		volumeSlider.value = 1f;
		volumeSlider.value = PlayerPrefs.GetFloat ("bgmVolume");
	}
	
	// Update is called once per frame
	void Update () 
	{
		musicSource.volume = volumeSlider.value;

	}

	public void VolumePrefs()
	{
		PlayerPrefs.SetFloat ("bgmVolume", volumeSlider.value);
	}
}

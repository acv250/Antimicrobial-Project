using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundtrackClass : MonoBehaviour 
{

	//public AudioSource musicSource;

	// Use this for initialization
	void Awake () 
	{
		GameObject[] musicObject = GameObject.FindGameObjectsWithTag ("music");
		if (musicObject.Length > 1) 
		{
			Destroy (this.gameObject);
		}

		DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}

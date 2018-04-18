﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{

	public GameObject playerCharacter;
	//public GameObject enemyCharacter;

	public GameObject gameOverCanvas;

	public PlayerHealthScript pHealthScript;

	// Use this for initialization
	void Start () 
	{
		gameOverCanvas.SetActive (false);
		Instantiate (playerCharacter);
		pHealthScript = FindObjectOfType<PlayerHealthScript> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (pHealthScript.currentHealth <= 0) 
		{
			gameOverCanvas.SetActive (true);
		} else 
		{
			gameOverCanvas.SetActive (false);
		}
	}

	public void RestartGame()
	{
		SceneManager.LoadScene (1);
	}

	public void QuitGame()
	{
		SceneManager.LoadScene (0);
	}
}

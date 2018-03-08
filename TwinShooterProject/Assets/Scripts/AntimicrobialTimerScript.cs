﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntimicrobialTimerScript : MonoBehaviour {

	public float amTimer;
	public Text amTimerText;
	public float amSpeed = 1;
	private float amTimerIncrement;

	public bool useAntimicrobial;

	public PlayerHealthScript pHealthScript;
	public EnemyHealthScript eHealthScript;

	// Use this for initialization
	void Start () 
	{
		amTimer = 30f;	
		amSpeed = 1;
		useAntimicrobial = false;
		amTimerIncrement = 2;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (!pHealthScript.playerIsActive) {
			amSpeed = 0;
		} 

		amTimer -= Time.deltaTime * amSpeed;

		int minutes;
		float seconds;

		minutes = Mathf.FloorToInt (amTimer / 60);
		seconds = amTimer % 60;

		if (amTimer <= 0) 
		{
			amTimerText.text = "NEW ANTIMICROBIAL: AVAILABLE!";
		} else 
		{
			amTimerText.text = "NEW ANTIMICROBIAL: " + string.Format("{00}:{1:00.00}", minutes, seconds);
		}

		if (Input.GetMouseButtonDown (1) && amTimer <= 0) 
		{
			Debug.Log ("Use Antimicrobial");
			amTimer = 30f * amTimerIncrement;

			amTimerIncrement = amTimerIncrement + 1;
		}



	}
}

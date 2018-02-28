using System.Collections;
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

	// Use this for initialization
	void Start () 
	{
		amTimer = 30f;	
		amSpeed = 1;
		useAntimicrobial = false;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (pHealthScript.playerIsActive) {
			amSpeed = 1;
		} else {
			amSpeed = 0;
		}

		amTimer -= Time.deltaTime * amSpeed;

		int minutes;
		float seconds;

		minutes = Mathf.FloorToInt (amTimer / 60);
		seconds = amTimer % 60;

		amTimerText.text = "NEW ANTIMICROBIAL: " + string.Format("{00}:{1:00.00}", minutes, seconds);

		if (amTimer <= 0) 
		{
			amTimerText.text = "NEW ANTIMICROBIAL: AVAILABLE!";
		}

	}
}

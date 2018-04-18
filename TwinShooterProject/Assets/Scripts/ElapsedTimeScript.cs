using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElapsedTimeScript : MonoBehaviour
{

	public static float timer;
	public Text timerText;
	public float speed = 1;

	public PlayerHealthScript pHealthScript;

	void Start()
	{
		pHealthScript = FindObjectOfType<PlayerHealthScript>();
	}

	// Update is called once per frame
	void Update () 
	{
		pHealthScript = FindObjectOfType<PlayerHealthScript>();
		if (pHealthScript.playerIsActive) {
			speed = 1;
		} else {
			speed = 0;
		}

		timer += Time.deltaTime * speed;

		int minutes;
		float seconds;

		minutes = Mathf.FloorToInt (timer / 60);
		seconds = timer % 60;

		timerText.text = string.Format("{00}:{1:00.00}", minutes, seconds);


	}
}

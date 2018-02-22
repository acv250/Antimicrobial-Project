using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElapsedTimeScript : MonoBehaviour
{

	public static float timer;
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
	}

	void OnGUI()
	{
		int minutes = Mathf.FloorToInt (timer / 60F);
		int seconds = Mathf.FloorToInt (timer - minutes * 60);
		string elapsedTime = string.Format ("{0:0}:{1:00}", minutes, seconds);

		GUI.Label (new Rect (10, 10, 250, 100), elapsedTime);

	}
}

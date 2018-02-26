using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElapsedTimeScript : MonoBehaviour
{

	public static float timer;
	public Text timerText;
	public float speed = 1;

	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime * speed;

		string hours = Mathf.Floor ((timer % 21600) / 3600).ToString ("00");
		string minutes = Mathf.Floor((timer % 3600) / 60).ToString ("00");
		string seconds = (timer % 60).ToString ("00");

		timerText.text = hours + ":" + minutes + ":" + seconds;


	}
}

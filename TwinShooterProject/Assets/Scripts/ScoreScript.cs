using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	public Text scoreText;
	public static int scoreAmount;

	// Use this for initialization
	void Start () 
	{
		scoreText = GetComponent<Text> ();
		scoreAmount = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		scoreText.text = "SCORE: " + scoreAmount;
	}

}

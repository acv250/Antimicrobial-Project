using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour 
{

	public int startHealth;
	public int currentHealth;
	public bool playerIsActive;

	public float flashLength;
	private float flashCounter;

	private Renderer rend;
	private Color storedColor;

	public EnemyScript enemyScript;
	public CanvasGroup gameOverCanvas;

	public Text lifeText;

	// Use this for initialization
	void Start () 
	{
		currentHealth = startHealth;
		rend = GetComponent<Renderer> ();
		storedColor = rend.material.GetColor ("_Color");
		playerIsActive = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentHealth <= 0)
		{
			playerIsActive = false;
			gameObject.SetActive (false);
		} else
		{
			gameObject.SetActive (true);
		}
		if (flashCounter > 0) 
		{
			flashCounter -= Time.deltaTime;
			if (flashCounter <= 0)
			{
				rend.material.SetColor ("_Color", storedColor);
			}
		}
		lifeText.text = "LIVES: " + currentHealth;
	}

	public void HurtPlayer(int damageAmount)
	{
		//if (enemyScript.enemyIsActive) 
		//{
			currentHealth -= damageAmount;
			flashCounter = flashLength;
			rend.material.SetColor ("_Color", Color.red);
		//}

	}
}

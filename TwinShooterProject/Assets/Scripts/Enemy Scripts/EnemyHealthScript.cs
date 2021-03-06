﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{

	public float enemyHealth;
	public float currentEnemyHealth;
	//public static float resistVar;
	public int scoreShoot = 1;
	public int scoreAbsorb = 5;
	public int amDamage = 2;

	public float flashLength;
	private float flashCounter;

	private Renderer rend;
	private Color storedColor;

	public GameObject enemyCollider;
	public GameObject playerCollider;
	public EnemyScript enemyScript;

	// Use this for initialization
	void Start ()
	{
		
		this.currentEnemyHealth = enemyHealth * GameManager.resistVar;
		rend = GetComponent<Renderer> ();
		storedColor = rend.material.GetColor ("_Color");
		this.enemyCollider.SetActive (true);
		this.playerCollider.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (this.currentEnemyHealth <= 0) 
		{
			this.enemyScript.enemyIsActive = false;
			rend.material.SetColor ("_Color", Color.gray);
			this.enemyCollider.SetActive (false);
			this.playerCollider.SetActive (true);
		}
		if (flashCounter > 0) 
		{
			flashCounter -= Time.deltaTime;
			if (flashCounter <= 0)
			{
				rend.material.SetColor ("_Color", storedColor);
			}
		}

		if (AntimicrobialTimerScript.useAntimicrobial) 
		{
			flashCounter = flashLength;
			rend.material.SetColor ("_Color", Color.cyan);
			this.currentEnemyHealth -= amDamage;
			ScoreScript.scoreAmount += amDamage;
		}

	}

	public void DamageEnemy(int damage)
	{
		if (this.enemyCollider.activeInHierarchy) 
		{
			this.currentEnemyHealth -= damage;
			flashCounter = flashLength;
			rend.material.SetColor ("_Color", Color.cyan);
			ScoreScript.scoreAmount += scoreShoot;
		}
	}

	public void OnTriggerEnter(Collider other)
	{

		if (this.currentEnemyHealth <= 0 && this.playerCollider.activeInHierarchy) 
		{
			if (other.gameObject.tag == "Player") 
			{
				Destroy (this.gameObject);
				ScoreScript.scoreAmount += scoreAbsorb;
			}
		}
	}
}

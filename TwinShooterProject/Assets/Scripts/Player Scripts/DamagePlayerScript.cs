﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerScript : MonoBehaviour 
{

	public int damageValue;
	public GameObject enemyCollider;

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && this.enemyCollider.activeInHierarchy) 
		{
			other.gameObject.GetComponent<PlayerHealthScript> ().HurtPlayer (damageValue);
		}
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}

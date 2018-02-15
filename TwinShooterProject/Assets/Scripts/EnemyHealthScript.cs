using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{

	public int enemyHealth;
	public int currentEnemyHealth;

	public float flashLength;
	private float flashCounter;

	private Renderer rend;
	private Color storedColor;

	public EnemyScript enemyScript;

	// Use this for initialization
	void Start ()
	{
		currentEnemyHealth = enemyHealth;
		rend = GetComponent<Renderer> ();
		storedColor = rend.material.GetColor ("_Color");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentEnemyHealth <= 0) 
		{
			enemyScript.enemyIsActive = false;
			rend.material.SetColor ("_Color", Color.white);
			//Destroy (gameObject);
		}
		if (flashCounter > 0) 
		{
			flashCounter -= Time.deltaTime;
			if (flashCounter <= 0)
			{
				rend.material.SetColor ("_Color", storedColor);
			}
		}
	}

	public void DamageEnemy(int damage)
	{
		currentEnemyHealth -= damage;
		flashCounter = flashLength;
		rend.material.SetColor ("_Color", Color.white);
	}

	public void OnTriggerEnter(Collider other)
	{
		if (!enemyScript.enemyIsActive) 
		{
			if (other.gameObject.tag == "Player") 
			{
				Destroy (gameObject);
			}
		}
	}
}

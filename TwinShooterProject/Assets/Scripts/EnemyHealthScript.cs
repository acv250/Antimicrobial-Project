using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{

	public int enemyHealth;
	private int currentHealth;

	// Use this for initialization
	void Start ()
	{
		currentHealth = enemyHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentHealth <= 0) 
		{
			Destroy (gameObject);
		}
	}

	public void DamageEnemy(int damage)
	{
		currentHealth -= damage;
	}
}

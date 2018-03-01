using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{

	public int enemyHealth;
	public int currentEnemyHealth;
	private int resistVar;

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
		resistVar = 1;
		this.currentEnemyHealth = enemyHealth * resistVar;
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
			rend.material.SetColor ("_Color", Color.white);
			this.enemyCollider.SetActive (false);
			this.playerCollider.SetActive (true);
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
		this.currentEnemyHealth -= damage;
		flashCounter = flashLength;
		rend.material.SetColor ("_Color", Color.white);
	}

	public void OnTriggerEnter(Collider other)
	{

		if (this.currentEnemyHealth <= 0 && this.playerCollider.activeInHierarchy) 
		{
			Debug.Log ("dab");
			if (other.gameObject.tag == "Player") 
			{
				Destroy (this.gameObject);
			}
		}
	}
}

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

	private SpriteRenderer rend;
	private Color storedColor;

	public EnemyScript enemyScript;

	public Text lifeText;

	// Use this for initialization
	void Start () 
	{

		lifeText = FindObjectOfType<Text> ();

		currentHealth = startHealth;
		rend = GetComponent<SpriteRenderer> ();
		rend.color = new Color (255f, 255f, 255f, 1f);
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
				Debug.Log ("change");
				rend.color = new Color (255f, 255f, 255f, 1f);
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
			rend.color = new Color (255f, 0f, 0f, 1f);
		//}

	}
}

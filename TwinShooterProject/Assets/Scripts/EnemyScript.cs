using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour 
{

	private Rigidbody myRigidbody;
	public float moveSpeed;

	public PlayerScript playerCharacter;

	public bool enemyIsActive;

	// Use this for initialization
	void Start () 
	{
		myRigidbody = GetComponent <Rigidbody> ();
		playerCharacter = FindObjectOfType<PlayerScript>();
		this.enemyIsActive = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.enemyIsActive) 
		{
			this.transform.LookAt (playerCharacter.transform.position);
		}
	}

	void FixedUpdate()
	{
		if (this.enemyIsActive)
		{
			myRigidbody.velocity = (transform.forward * moveSpeed);	
		}
	}
		
}

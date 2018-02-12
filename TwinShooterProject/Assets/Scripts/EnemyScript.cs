using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour 
{

	private Rigidbody myRigidbody;
	public float moveSpeed;

	public PlayerScript playerCharacter;

	// Use this for initialization
	void Start () 
	{
		myRigidbody = GetComponent <Rigidbody> ();
		playerCharacter = FindObjectOfType<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.LookAt (playerCharacter.transform.position);
	}

	void FixedUpdate()
	{
		myRigidbody.velocity = (transform.forward * moveSpeed);
	}
}

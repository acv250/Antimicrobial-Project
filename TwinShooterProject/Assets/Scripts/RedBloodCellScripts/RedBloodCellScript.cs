using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedBloodCellScript : MonoBehaviour 
{

	public float moveSpeed;
	public float rotationSpeed;
	private float bloodVelocity;

	public GameObject bloodSprite;

	// Use this for initialization
	void Start () 
	{
		moveSpeed = Random.Range (2.0f, 6.0f);
		rotationSpeed = Random.Range (-10.0f, 1.0f);

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.left * Time.deltaTime * moveSpeed, Space.World);
		transform.Rotate (0, 0, rotationSpeed);

		if (transform.position.x <= -10f) 
		{
			Destroy (bloodSprite);
		}
	}

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public float moveSpeed;
	private Rigidbody myRigidbody;

	private Vector3 moveInput;
	private Vector3 moveVelocity;

	public PlayerShootScript playerShoot;

	public bool useController;

	// Use this for initialization
	void Start () 
	{
		myRigidbody = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () 
	{
		moveInput = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		moveVelocity = moveInput * moveSpeed;


		//player border limits x-axis
		if (this.transform.position.x <= -8.0f) 
		{
			transform.position = new Vector2 (-8.0f, transform.position.y);
			Debug.Log ("out of bounds");
		} else if (this.transform.position.x >= 8.0f) 
		{
			transform.position = new Vector2(8.0f, transform.position.y);
			Debug.Log ("out of bounds");
		}
		//player border limits y-axis
		if (this.transform.position.y <= -4.0f) 
		{
			transform.position = new Vector2 (transform.position.x, -4.0f);
			Debug.Log ("out of bounds");
		} else if (this.transform.position.y >= 4.0f) 
		{
			transform.position = new Vector2(transform.position.x, 4.0f);
			Debug.Log ("out of bounds");
		}


		Rotation ();
		//Mouse Rotation

		if (!useController) 
		{
			if (Input.GetMouseButtonDown (0)) 
			{
				playerShoot.isFiring = true;
			}
			if (Input.GetMouseButtonUp (0))
			{
				playerShoot.isFiring = false;
			}
		}
		if (useController) 
		{
			if (Input.GetKeyDown (KeyCode.Joystick1Button5)) 
			{
				playerShoot.isFiring = true;
			}

			if (Input.GetKeyUp (KeyCode.Joystick1Button5)) 
			{
				playerShoot.isFiring = false;
			}
		}

		//Rotate with Controller
		/*if (useController) 
		{
			Vector3 playerDirection = Vector3.right * Input.GetAxisRaw ("RHorizontal") 
				+ Vector3.up * Input.GetAxisRaw("RVertical");
			if (playerDirection.sqrMagnitude > 0.0f) 
			{
				transform.rotation = Quaternion.LookRotation (playerDirection, -Vector3.up);
			}

			if (Input.GetKeyDown (KeyCode.Joystick1Button0)) 
			{
				playerShoot.isFiring = true;
			}

			if (Input.GetKeyUp (KeyCode.Joystick1Button0)) 
			{
				playerShoot.isFiring = false;
			}
		}*/

		//Debug.Log (this.transform.position);
	}

	void FixedUpdate()
	{
		myRigidbody.velocity = moveVelocity;
	}

	void Rotation()
	{
		if (!useController) 
		{
			Vector3 worldPos = Input.mousePosition;
			worldPos = Camera.main.ScreenToWorldPoint (worldPos);

			float dx = this.transform.position.x - worldPos.x;
			float dy = this.transform.position.y - worldPos.y;

			float angle = Mathf.Atan2 (dy, dx) * Mathf.Rad2Deg;

			Quaternion rot = Quaternion.Euler (new Vector3 (0, 0, angle + 90));

			this.transform.rotation = rot;
		}

		if (useController) 
		{

			/*Vector3 playerDirection = Vector3.right * Input.GetAxisRaw ("RHorizontal") +
			                          Vector3.up * -Input.GetAxisRaw ("RVertical");

			if (playerDirection.sqrMagnitude > 0.0f) 
			{
				this.transform.rotation = Quaternion.LookRotation (playerDirection);
			}*/

			Vector3 playerDirection = new Vector3 (Input.GetAxisRaw("RHorizontal"), Input.GetAxisRaw("RVertical"), 0.0f);

			if (playerDirection.sqrMagnitude > 0.0f) 
			{
				var rStickAngle = Mathf.Atan2 (Input.GetAxisRaw ("RHorizontal"), Input.GetAxisRaw ("RVertical")) * Mathf.Rad2Deg;
				this.transform.rotation = Quaternion.Euler (0, 0, rStickAngle);
			}
		}

	}
}
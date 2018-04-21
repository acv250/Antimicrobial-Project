using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour {

	public bool isFiring;
	public BulletControlScript bullet;
	public float bulletSpeed;

	public float rateOfFire;
	private float shotCooldown;

	public Transform shootPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isFiring)
		{	
			shotCooldown -= Time.deltaTime;
			if (shotCooldown <= 0) 
			{
				shotCooldown = rateOfFire;
				BulletControlScript newBullet = Instantiate (bullet, shootPoint.position, shootPoint.rotation) as BulletControlScript;
				newBullet.bulletSpeed = bulletSpeed;
			}
		} else 
		{
			shotCooldown = 0;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControlScript : MonoBehaviour {

	public float bulletSpeed;

	public GameObject bulletObject;

	public int damageIntake;

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.up * bulletSpeed * Time.deltaTime);
		Destroy (bulletObject, 2.5f);

	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			other.gameObject.GetComponent<EnemyHealthScript> ().DamageEnemy (damageIntake);
			Destroy (gameObject);
		}
	}
}

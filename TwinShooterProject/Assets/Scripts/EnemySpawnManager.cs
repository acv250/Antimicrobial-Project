using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour 
{

	public PlayerHealthScript pHealthScript;
	public GameObject[] enemies;
	public Vector2 spawnValues;
	public float spawnWait;
	public float spawnMinWait;
	public float spawnMaxWait;
	public int startWait;
	public bool stopSpawn;

	private int enemyID;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (SpawnEnemy());
		stopSpawn = false;
	}

	// Update is called once per frame
	void Update () 
	{
		spawnWait = Random.Range (spawnMinWait, spawnMaxWait);

		if (pHealthScript.currentHealth <= 0) 
		{
			stopSpawn = true;
			StopCoroutine (SpawnEnemy ());
		}
	}

	IEnumerator SpawnEnemy()
	{
		yield return new WaitForSeconds (startWait);

		while (!stopSpawn) 
		{
			enemyID = 0;
			Vector2 spawnPosition = new Vector2 (Random.Range (-spawnValues.x - 10, spawnValues.x + 10), Random.Range (-spawnValues.y - 10, spawnValues.y + 10));

			Instantiate (enemies[enemyID], spawnPosition, gameObject.transform.rotation);

			yield return new WaitForSeconds (spawnWait);
		}
	}
}

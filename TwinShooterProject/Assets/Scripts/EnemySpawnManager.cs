using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour 
{

	public GameObject[] enemies;
	public Vector2 spawnValues;
	public float spawnWait;
	public float spawnMinWait;
	public float spawnMaxWait;
	public int startWait;
	public bool isSpawning;

	private int enemyID;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (SpawnEnemy());
	}

	// Update is called once per frame
	void Update () 
	{
		spawnWait = Random.Range (spawnMinWait, spawnMaxWait);
	}

	IEnumerator SpawnEnemy()
	{
		yield return new WaitForSeconds (startWait);

		while (!isSpawning) 
		{
			enemyID = 0;
			Vector2 spawnPosition = new Vector2 (Random.Range (-spawnValues.x, spawnValues.x), Random.Range (-spawnValues.y, spawnValues.y));

			Instantiate (enemies[enemyID], spawnPosition, gameObject.transform.rotation);

			yield return new WaitForSeconds (spawnWait);
		}
	}
}

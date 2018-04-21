using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBloodSpawnManager : MonoBehaviour 
{

	public GameObject[] bloodSprite;
	public Vector2 spawnValues;
	public float spawnWait;
	public float spawnMinWait;
	public float spawnMaxWait;
	public int startWait;
	public bool stopSpawn;

	private int bloodID;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (SpawnBlood ());
		stopSpawn = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		bloodID = 0;
		spawnWait = Random.Range (spawnMinWait, spawnMaxWait);
	}

	IEnumerator SpawnBlood()
	{
		yield return new WaitForSeconds (startWait);

		while(!stopSpawn)
		{
			
			Vector2 spawnPosition = new Vector2 (spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y));

			Instantiate (bloodSprite [bloodID], spawnPosition, gameObject.transform.rotation);

			yield return new WaitForSeconds (spawnWait);
		}
	}
}

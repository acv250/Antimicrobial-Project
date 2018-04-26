using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{

	public GameObject playerCharacter;
	//public GameObject enemyCharacter;

	public GameObject gameOverCanvas;
	public GameObject gamePausedCanvas;

	public PlayerHealthScript pHealthScript;
	public bool gameOver;

	public static float resistVar;

	private bool gamePaused;

	// Use this for initialization
	void Start () 
	{
		gamePaused = false;
		resistVar = 1.0f;
		gameOver = false;
		gameOverCanvas.SetActive (false);
		gamePausedCanvas.SetActive (false);
		Instantiate (playerCharacter);
		playerCharacter.layer = LayerMask.NameToLayer ("UserLayer");
		pHealthScript = FindObjectOfType<PlayerHealthScript> ();
		StartCoroutine (upResist());
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (pHealthScript.currentHealth <= 0) 
		{
			gameOver = true;
			gameOverCanvas.SetActive (true);
		} else 
		{
			gameOver = false;
			gameOverCanvas.SetActive (false);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (gamePaused) {
				Time.timeScale = 1;
				gamePausedCanvas.SetActive (false);
			} else {
				Time.timeScale = 0;
				gamePausedCanvas.SetActive (true);
			}
			gamePaused = !gamePaused;
		}
	}

	IEnumerator upResist()
	{
		yield return new WaitForSeconds (60f);
		resistVar += 0.1f;
	}

	public void RestartGame()
	{
		SceneManager.LoadScene (1);
	}

	public void QuitGame()
	{
		SceneManager.LoadScene (0);
	}

	public void UnpauseGame()
	{
		gamePaused = false;
	}
}

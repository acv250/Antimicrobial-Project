using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionScript : MonoBehaviour
{
	public Button nextButton;
	public Button backButton;

	public GameObject page1;
	public GameObject page2;
	public GameObject page3;

	public List<GameObject> page = new List<GameObject>();

	int currentPage = 1;
	int maxPage;
	int minPage = 1;

	// Use this for initialization
	void Start () 
	{
		page1.SetActive (true);
		maxPage = page.Count;
		Debug.Log (maxPage);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void CurrentPage()
	{
		for (int i = 1; i <= page.Count; i++) 
		{
			if (i == 1 && currentPage == 1) {
				page1.SetActive (true);
				page2.SetActive (false);
				page3.SetActive (false);
			} else if (i == 2 && currentPage == 2) 
			{
				page1.SetActive (false);
				page2.SetActive (true);
				page3.SetActive (false);
			} else if (i == 3 && currentPage == 3) 
			{
				page1.SetActive (false);
				page2.SetActive (false);
				page3.SetActive (true);
			}
		}
	}

	public void NextPage()
	{
		if (currentPage < maxPage) 
		{
			currentPage++;
		}
		Debug.Log (currentPage);
	}

	public void PreviousPage()
	{
		if (currentPage > minPage)
		{
			currentPage--;
		}
		Debug.Log (currentPage);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactScript : MonoBehaviour 
{

	public Text factText;
	public int factNum;

	// Use this for initialization
	void Start () 
	{
		factNum = Random.Range (0, 7);
		factText.text = "FACT: ";
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (factNum == 0) 
		{
			factText.text = "FACT: Always finish your medicine, even if you feel better.";
		}
		if (factNum == 1) 
		{
			factText.text = "FACT: The type of antimicrobial has to be for the correct treatment! Antibiotics treat bacteria, antivirals treat viruses, and antifungals treat fungi.";
		}
		if (factNum == 2) 
		{
			factText.text = "FACT: Microorganisms (such as bacteria) mutate naturally, but the misuse and overuse of antimicrobials can accelerate mutation quickly, making previous treatments ineffective.";
		}
		if (factNum == 3) 
		{
			factText.text = "FACT: Every year, the World Health Organization recognises a week to increase awareness of antimicrobial resistance.";
		}
		if (factNum == 4) 
		{
			factText.text = "FACT: Microorganisms that are known to resist standard treatments are known as 'Superbugs'.";
		}
		if (factNum == 5) 
		{
			factText.text = "FACT: Antimicrobial resistance is the ability of a microorganism to stop an antimicrobial from working against it, allowing them to survive the most common treatments.";
		}
		if (factNum == 6) 
		{
			factText.text = "FACT: Harmful microorganisms can rapidly mutate and multiply. Finishing the course of your medicine improves the chances of killing all of the harmful pathogens inside your body. Otherwise, any surviving ones can adapt to the medicine and mutate.";
		}
		if (factNum == 7) 
		{
			factText.text = "FACT: As more illnesses become untreatable with standard treatments, effective medicines are rapidly running out, and it is difficult to research and produce new medicines as they are expensive and can take a long time to make.";
		}
			
	}

	void OnEnable()
	{
		Debug.Log ("enabled");
		factNum = Random.Range (0, 7);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chatbox : MonoBehaviour {

	public InputField userText;
	public Button sendButton;
	public Text ChatboxText;

	public List<string> chatHistory = new List<string>();

	public void displayUserText () {
		ChatboxText.text = userText.text;
		chatHistory.Add (userText.text);
		Debug.Log (chatHistory);

	}
}

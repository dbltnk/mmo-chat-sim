using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChatService : MonoBehaviour {

	public GameObject TextObject;
	Text TextBox;
	List<string> textLines = new List<string>();
	public int maxNumberOfLines;

	// Use this for initialization
	void Start () 
	{
		TextBox = TextObject.GetComponent<Text>();
	}

	public void ReceiveChatMessage (string messageReceived)
	{
		BroadcastChatMessage(messageReceived);
	}
	
	void BroadcastChatMessage (string messageToBroadcast)
	{
		AppendChatMessage(messageToBroadcast);
	}
	
	void AppendChatMessage (string messageToAppend)
	{
		textLines.Add(messageToAppend);
	}
	
	// Update is called once per frame
	void Update () 
	{
		int listLength = textLines.Count;

		if (listLength >= 0)
		{
			TextBox.text = "";
			for (int i = 0; i < listLength; i++) 
			{
				TextBox.text = string.Concat(TextBox.text, textLines[i], "\n"); 
			}
		}

		//TODO: this is wrong when a line breaks - how to change?
		if (listLength > maxNumberOfLines)
		{
			int linesToCut = listLength - maxNumberOfLines;
			textLines.RemoveRange(0, linesToCut);
		}

	}

}
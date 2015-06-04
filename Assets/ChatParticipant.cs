using UnityEngine;
using System.Collections;

public class ChatParticipant : MonoBehaviour {
	
	ChatService ChatHandler;
	
	public float MinTimeOutInSeconds;
	public float MaxTimeOutInSeconds;
	public string ParticipantName;

	string[] sentences = 
	{
		"WTB Essences - PST", 
		"Enemy spotted at 46/33", 
		"Is anyone here who can PL me?", 
		"I'm bored ...", 
		"Let's siege Exile!", 
		"STFU NOOB", 
		"LoD = RPK scum", 
		"Why does no one answer my questions? Seriously!", 
		"any clans recruiting?", 
		"someone duel me!", 
		"scythe = IMBA", 
		"nerf Bows, Puncture is too strong", 
		"Cheesecake Factory is recruiting - send tell", 
		"Exile: Your wood camp is now ours. =D", 
		"WTS 5k wood", 
		"45 staff/robe LFG"
	};

	void Awake ()
	{
        // TODO only works if there is one chat service
        ChatHandler = GameObject.FindObjectOfType<ChatService>();
	}

	// Use this for initialization
    IEnumerator Start() 
	{
		while(true)
        {
            // speak
            float randomTimeInSeconds = Random.Range(MinTimeOutInSeconds, MaxTimeOutInSeconds);
            yield return new WaitForSeconds(randomTimeInSeconds);

            string messageToSend = generateChatLine();
            SendChatMessage(messageToSend);
        }
	}


	string generateChatLine () 
	{
		string sentence = selectRandomSentence();

		if (ParticipantName != "") 
		{
			return string.Concat(ParticipantName, ": ", sentence);
		}
			else 
		{
			return string.Concat("Nameless: ", sentence);
		}
	}

	string selectRandomSentence () 
	{
		int maxNumber = sentences.GetLength(0);
		int randomNumber = Random.Range(1, maxNumber);
		return sentences[randomNumber];
	}

	void SendChatMessage (string message)
	{
		ChatHandler.ReceiveChatMessage(message);
	}

	public void Init(string participantName, float minTimeOutInSeconds, float maxTimeOutInSeconds)
    {
		ParticipantName = participantName;
		name = participantName; // This is just for visual debugging, not used anywhere else.
        MinTimeOutInSeconds = minTimeOutInSeconds;
        MaxTimeOutInSeconds = maxTimeOutInSeconds;
    }
}

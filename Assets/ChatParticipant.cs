using UnityEngine;
using System.Collections;

public class ChatParticipant : MonoBehaviour {

	string participantName;
	ChatService ChatHandler;
	
	public float MinTimeOutInSeconds;
	public float MaxTimeOutInSeconds;
	
	string[] names = 
	{
		"Shu Wa-Shi", 
		"Chui To-Ki", 
		"Chua Fu-Biao", 
		"Su Chou-Tu", 
		"Chu Jiu-Hao", 
		"Da Yong-Gui", 
		"Chieu Shi-Hu", 
		"Chao Zhi-Xie", 
		"Saio Chee-Di", 
		"Chuie Pi-Su", 
		"Hu Chu-Fei", 
		"Li Niu-Szi", 
		"Zhai Do-Wai", 
		"Fu Te-Rou", 
		"Zhuo An-Xiao", 
		"Ying Li-Li", 
		"Yan Tai-Na", 
		"Li Chwa-Ku", 
		"Lo Da-Shu", 
		"Sui Chio-Tsao"
	};

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
        Debug.Log("AWAKE");

        // TODO only works if there is one chat service
        ChatHandler = GameObject.FindObjectOfType<ChatService>();
		
		participantName = selectRandomName();
		name = participantName; // This is just for visual debugging, not used anywhere else.
	}

	// Use this for initialization
    IEnumerator Start() 
	{
        Debug.Log("START");

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

		if (participantName != "") 
		{
			return string.Concat(participantName, ": ", sentence);
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

	string selectRandomName()
	{
		int maxNumber = names.GetLength(0);
		int randomNumber = Random.Range(1, maxNumber);
		return names[randomNumber];
	}

	void SendChatMessage (string message)
	{
		ChatHandler.ReceiveChatMessage(message);
	}

    // TODO inject name
    public void Init(float minTimeOutInSeconds, float maxTimeOutInSeconds)
    {
        Debug.Log("INIT");
        MinTimeOutInSeconds = minTimeOutInSeconds;
        MaxTimeOutInSeconds = maxTimeOutInSeconds;
    }
}

using UnityEngine;
using System.Collections;

public class ChatParticipant : MonoBehaviour {
	
	ChatService ChatHandler;
	TradeService TradeService;
	
	public float MinTimeOutInSeconds;
	public float MaxTimeOutInSeconds;
	public string ParticipantName;

	public int EssencesOwned;
	public int WoodOwned;
	public int ClayOwned;
	public int WoodNeeded;
	public int ClayNeeded;

	public bool NeedsWood;
	public bool NeedsClay;

	public int WoodToBuy;
	public int WoodToSell;
	public int ClayToBuy;
	public int ClayToSell;
	
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
		TradeService = GameObject.FindObjectOfType<TradeService>();
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

	void Update ()
	{

		if (CalculateResourceNeed("wood") > 0)
		{
			WoodToBuy = CalculateResourceNeed("wood");
			TradeService.RegisterOrder(ParticipantName, "wood", WoodToBuy);
		}
		else if (CalculateResourceNeed("wood") < 0)
		{
			WoodToSell = CalculateResourceNeed("wood") * -1;
			TradeService.RegisterOrder(ParticipantName, "wood", WoodToSell);
		}
		else
		{
			// nothing happens
		}

		if (CalculateResourceNeed("clay") > 0)
		{
			ClayToBuy = CalculateResourceNeed("clay");
			TradeService.RegisterOrder(ParticipantName, "clay", ClayToBuy);
		}
		else if (CalculateResourceNeed("clay") < 0)
		{
			ClayToSell = CalculateResourceNeed("clay") * -1;
			TradeService.RegisterOrder(ParticipantName, "clay", ClayToSell);
		}
		else
		{
			// nothing happens
		}
	}


	string generateChatLine () 
	{
		//string sentence = selectRandomSentence();
		string sentence = VerbalizeNeeds();

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

	public void Init(string participantName, float minTimeOutInSeconds, float maxTimeOutInSeconds,
	                 int essencesOwned, int woodOwned, int clayOwned, int woodNeeded, int clayNeeded)
    {
		ParticipantName = participantName;
		name = participantName; // This is just for visual debugging, not used anywhere else.
        MinTimeOutInSeconds = minTimeOutInSeconds;
        MaxTimeOutInSeconds = maxTimeOutInSeconds;

		EssencesOwned = essencesOwned;
		WoodOwned = woodOwned;
		ClayOwned = clayOwned;
		WoodNeeded = woodNeeded;
		ClayNeeded = clayNeeded;
    }

	int CalculateResourceNeed (string resourceType)
	{
		if (resourceType == "wood")
		{
			NeedsWood = WoodNeeded > WoodOwned;
			return WoodNeeded - WoodOwned;
		}
		else if (resourceType == "clay")
		{
			NeedsClay = ClayNeeded > ClayOwned;
			return ClayNeeded - ClayOwned;
		}
		else 
		{
			Debug.LogError("unrecognized resource type");
			return 0;
		}
	}

	string VerbalizeNeeds ()
	{
		if (NeedsWood && NeedsClay)
		{
			return string.Concat("I need ", CalculateResourceNeed("wood"), " wood and ", CalculateResourceNeed("clay"), " clay.");
		}
		else if (NeedsWood && !NeedsClay)
		{
			return string.Concat("I need ", CalculateResourceNeed("wood"), " wood.");
		}
		else if (!NeedsWood && NeedsClay)
		{
			return string.Concat("I need ", CalculateResourceNeed("clay"), " clay.");
		}
		else
		{
			return "I am satisfied.";
		}
	}
}

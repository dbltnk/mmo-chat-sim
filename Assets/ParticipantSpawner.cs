using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticipantSpawner : MonoBehaviour {

	public int ChatParticipantsToCreate;
	public GameObject ParticipantBlueprint;
	public GameObject PlayerRoot;

	public float minTimeOutInSeconds;
	public float maxTimeOutInSeconds;

	List<string> namesAvailable = new List<string>()
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

	List<string> namesUsed = new List<string>();


	// Use this for initialization
	void Start () 
	{
		createParticipants(ChatParticipantsToCreate);
	}
	
	void createParticipants (int amount)
	{
		for (int i = 0; i < amount; i++) 
		{
            GameObject participantObject = Instantiate(ParticipantBlueprint) as GameObject;
			participantObject.transform.SetParent(PlayerRoot.transform);
            ChatParticipant chatParticipant = participantObject.GetComponent<ChatParticipant>();

			string participantName = selectRandomName();

			int essencesOwned = Random.Range(10, 50);
			int woodOwned = Random.Range(0, 9);
			int clayOwned = Random.Range(3, 9);
			int woodNeeded = Random.Range(3, 9);
			int clayNeeded = Random.Range(0, 9);

			chatParticipant.Init(participantName, minTimeOutInSeconds, maxTimeOutInSeconds,
			                     essencesOwned, woodOwned, clayOwned, woodNeeded, clayNeeded);
		}
	}

	string selectRandomName()
	{
		int maxNumber = namesAvailable.Count;
		int randomNumber = Random.Range(1, maxNumber);
		string nameSelected = namesAvailable[randomNumber];
		namesUsed.Add(namesAvailable[randomNumber]);
		namesAvailable.RemoveAt(randomNumber);
		return nameSelected;
	}
}


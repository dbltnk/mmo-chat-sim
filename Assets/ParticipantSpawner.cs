using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticipantSpawner : MonoBehaviour {

	public int ChatParticipantsToCreate;
	public GameObject ParticipantBlueprint;
	public GameObject PlayerRoot;

	public float minTimeOutInSeconds;
	public float maxTimeOutInSeconds;

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
			chatParticipant.Init(participantName, minTimeOutInSeconds, maxTimeOutInSeconds);
		}
	}

	string selectRandomName()
	{
		int maxNumber = names.GetLength(0);
		int randomNumber = Random.Range(1, maxNumber);
		return names[randomNumber];
	}
}


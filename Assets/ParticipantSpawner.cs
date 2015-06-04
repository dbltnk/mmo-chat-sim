using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticipantSpawner : MonoBehaviour {

	public int ChatParticipantsToCreate;
	public GameObject ParticipantBlueprint;
	public GameObject PlayerRoot;

	public float minTimeOutInSeconds;
	public float maxTimeOutInSeconds;

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
            chatParticipant.Init(minTimeOutInSeconds, maxTimeOutInSeconds);
		}
	}
}

